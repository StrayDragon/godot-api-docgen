namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This class can be used to discover compatible <see cref="Godot.UpnpDevice"/>s on the local network and execute commands on them, like managing port mappings (for port forwarding/NAT traversal) and querying the local and remote network IP address. Note that methods on this class are synchronous and block the calling thread.</para>
/// <para>To forward a specific port (here <c>7777</c>, note both <see cref="Godot.Upnp.Discover(int, int, string)"/> and <see cref="Godot.Upnp.AddPortMapping(int, int, string, string, int)"/> can return errors that should be checked):</para>
/// <para><code>
/// var upnp = UPNP.new()
/// upnp.discover()
/// upnp.add_port_mapping(7777)
/// </code></para>
/// <para>To close a specific port (e.g. after you have finished using it):</para>
/// <para><code>
/// upnp.delete_port_mapping(port)
/// </code></para>
/// <para><b>Note:</b> UPnP discovery blocks the current thread. To perform discovery without blocking the main thread, use <see cref="Godot.GodotThread"/>s like this:</para>
/// <para><code>
/// # Emitted when UPnP port mapping setup is completed (regardless of success or failure).
/// signal upnp_completed(error)
/// 
/// # Replace this with your own server port number between 1024 and 65535.
/// const SERVER_PORT = 3928
/// var thread = null
/// 
/// func _upnp_setup(server_port):
/// 	# UPNP queries take some time.
/// 	var upnp = UPNP.new()
/// 	var err = upnp.discover()
/// 
/// 	if err != OK:
/// 		push_error(str(err))
/// 		upnp_completed.emit(err)
/// 		return
/// 
/// 	if upnp.get_gateway() and upnp.get_gateway().is_valid_gateway():
/// 		upnp.add_port_mapping(server_port, server_port, ProjectSettings.get_setting("application/config/name"), "UDP")
/// 		upnp.add_port_mapping(server_port, server_port, ProjectSettings.get_setting("application/config/name"), "TCP")
/// 		upnp_completed.emit(OK)
/// 
/// func _ready():
/// 	thread = Thread.new()
/// 	thread.start(_upnp_setup.bind(SERVER_PORT))
/// 
/// func _exit_tree():
/// 	# Wait for thread finish here to handle game exit while the thread is running.
/// 	thread.wait_to_finish()
/// </code></para>
/// <para><b>Terminology:</b> In the context of UPnP networking, "gateway" (or "internet gateway device", short IGD) refers to network devices that allow computers in the local network to access the internet ("wide area network", WAN). These gateways are often also called "routers".</para>
/// <para><b>Pitfalls:</b></para>
/// <para>- As explained above, these calls are blocking and shouldn't be run on the main thread, especially as they can block for multiple seconds at a time. Use threading!</para>
/// <para>- Networking is physical and messy. Packets get lost in transit or get filtered, addresses, free ports and assigned mappings change, and devices may leave or join the network at any time. Be mindful of this, be diligent when checking and handling errors, and handle these gracefully if you can: add clear error UI, timeouts and re-try handling.</para>
/// <para>- Port mappings may change (and be removed) at any time, and the remote/external IP address of the gateway can change likewise. You should consider re-querying the external IP and try to update/refresh the port mapping periodically (for example, every 5 minutes and on networking failures).</para>
/// <para>- Not all devices support UPnP, and some users disable UPnP support. You need to handle this (e.g. documenting and requiring the user to manually forward ports, or adding alternative methods of NAT traversal, like a relay/mirror server, or NAT hole punching, STUN/TURN, etc.).</para>
/// <para>- Consider what happens on mapping conflicts. Maybe multiple users on the same network would like to play your game at the same time, or maybe another application uses the same port. Make the port configurable, and optimally choose a port automatically (re-trying with a different port on failure).</para>
/// <para><b>Further reading:</b> If you want to know more about UPnP (and the Internet Gateway Device (IGD) and Port Control Protocol (PCP) specifically), <a href="https://en.wikipedia.org/wiki/Universal_Plug_and_Play">Wikipedia</a> is a good first stop, the specification can be found at the <a href="https://openconnectivity.org/developer/specifications/upnp-resources/upnp/">Open Connectivity Foundation</a> and Godot's implementation is based on the <a href="https://github.com/miniupnp/miniupnp">MiniUPnP client</a>.</para>
/// </summary>
[GodotClassName("UPNP")]
public partial class Upnp : RefCounted
{
    public enum UpnpResult : long
    {
        /// <summary>
        /// <para>UPNP command or discovery was successful.</para>
        /// </summary>
        Success = 0,
        /// <summary>
        /// <para>Not authorized to use the command on the <see cref="Godot.UpnpDevice"/>. May be returned when the user disabled UPNP on their router.</para>
        /// </summary>
        NotAuthorized = 1,
        /// <summary>
        /// <para>No port mapping was found for the given port, protocol combination on the given <see cref="Godot.UpnpDevice"/>.</para>
        /// </summary>
        PortMappingNotFound = 2,
        /// <summary>
        /// <para>Inconsistent parameters.</para>
        /// </summary>
        InconsistentParameters = 3,
        /// <summary>
        /// <para>No such entry in array. May be returned if a given port, protocol combination is not found on a <see cref="Godot.UpnpDevice"/>.</para>
        /// </summary>
        NoSuchEntryInArray = 4,
        /// <summary>
        /// <para>The action failed.</para>
        /// </summary>
        ActionFailed = 5,
        /// <summary>
        /// <para>The <see cref="Godot.UpnpDevice"/> does not allow wildcard values for the source IP address.</para>
        /// </summary>
        SrcIPWildcardNotPermitted = 6,
        /// <summary>
        /// <para>The <see cref="Godot.UpnpDevice"/> does not allow wildcard values for the external port.</para>
        /// </summary>
        ExtPortWildcardNotPermitted = 7,
        /// <summary>
        /// <para>The <see cref="Godot.UpnpDevice"/> does not allow wildcard values for the internal port.</para>
        /// </summary>
        IntPortWildcardNotPermitted = 8,
        /// <summary>
        /// <para>The remote host value must be a wildcard.</para>
        /// </summary>
        RemoteHostMustBeWildcard = 9,
        /// <summary>
        /// <para>The external port value must be a wildcard.</para>
        /// </summary>
        ExtPortMustBeWildcard = 10,
        /// <summary>
        /// <para>No port maps are available. May also be returned if port mapping functionality is not available.</para>
        /// </summary>
        NoPortMapsAvailable = 11,
        /// <summary>
        /// <para>Conflict with other mechanism. May be returned instead of <see cref="Godot.Upnp.UpnpResult.ConflictWithOtherMapping"/> if a port mapping conflicts with an existing one.</para>
        /// </summary>
        ConflictWithOtherMechanism = 12,
        /// <summary>
        /// <para>Conflict with an existing port mapping.</para>
        /// </summary>
        ConflictWithOtherMapping = 13,
        /// <summary>
        /// <para>External and internal port values must be the same.</para>
        /// </summary>
        SamePortValuesRequired = 14,
        /// <summary>
        /// <para>Only permanent leases are supported. Do not use the <c>duration</c> parameter when adding port mappings.</para>
        /// </summary>
        OnlyPermanentLeaseSupported = 15,
        /// <summary>
        /// <para>Invalid gateway.</para>
        /// </summary>
        InvalidGateway = 16,
        /// <summary>
        /// <para>Invalid port.</para>
        /// </summary>
        InvalidPort = 17,
        /// <summary>
        /// <para>Invalid protocol.</para>
        /// </summary>
        InvalidProtocol = 18,
        /// <summary>
        /// <para>Invalid duration.</para>
        /// </summary>
        InvalidDuration = 19,
        /// <summary>
        /// <para>Invalid arguments.</para>
        /// </summary>
        InvalidArgs = 20,
        /// <summary>
        /// <para>Invalid response.</para>
        /// </summary>
        InvalidResponse = 21,
        /// <summary>
        /// <para>Invalid parameter.</para>
        /// </summary>
        InvalidParam = 22,
        /// <summary>
        /// <para>HTTP error.</para>
        /// </summary>
        HttpError = 23,
        /// <summary>
        /// <para>Socket error.</para>
        /// </summary>
        SocketError = 24,
        /// <summary>
        /// <para>Error allocating memory.</para>
        /// </summary>
        MemAllocError = 25,
        /// <summary>
        /// <para>No gateway available. You may need to call <see cref="Godot.Upnp.Discover(int, int, string)"/> first, or discovery didn't detect any valid IGDs (InternetGatewayDevices).</para>
        /// </summary>
        NoGateway = 26,
        /// <summary>
        /// <para>No devices available. You may need to call <see cref="Godot.Upnp.Discover(int, int, string)"/> first, or discovery didn't detect any valid <see cref="Godot.UpnpDevice"/>s.</para>
        /// </summary>
        NoDevices = 27,
        /// <summary>
        /// <para>Unknown error.</para>
        /// </summary>
        UnknownError = 28
    }

    /// <summary>
    /// <para>Multicast interface to use for discovery. Uses the default multicast interface if empty.</para>
    /// </summary>
    public string DiscoverMulticastIf
    {
        get
        {
            return GetDiscoverMulticastIf();
        }
        set
        {
            SetDiscoverMulticastIf(value);
        }
    }

    /// <summary>
    /// <para>If <c>0</c>, the local port to use for discovery is chosen automatically by the system. If <c>1</c>, discovery will be done from the source port 1900 (same as destination port). Otherwise, the value will be used as the port.</para>
    /// </summary>
    public int DiscoverLocalPort
    {
        get
        {
            return GetDiscoverLocalPort();
        }
        set
        {
            SetDiscoverLocalPort(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, IPv6 is used for <see cref="Godot.UpnpDevice"/> discovery.</para>
    /// </summary>
    public bool DiscoverIpv6
    {
        get
        {
            return IsDiscoverIpv6();
        }
        set
        {
            SetDiscoverIpv6(value);
        }
    }

    private static readonly System.Type CachedType = typeof(Upnp);

    private static readonly StringName NativeName = "UPNP";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public Upnp() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal Upnp(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal Upnp(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDeviceCount, 3905245786ul);

    /// <summary>
    /// <para>Returns the number of discovered <see cref="Godot.UpnpDevice"/>s.</para>
    /// </summary>
    public int GetDeviceCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind0, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDevice, 2193290270ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.UpnpDevice"/> at the given <paramref name="index"/>.</para>
    /// </summary>
    public UpnpDevice GetDevice(int index)
    {
        return (UpnpDevice)NativeCalls.godot_icall_1_71(MethodBind1, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddDevice, 986715920ul);

    /// <summary>
    /// <para>Adds the given <see cref="Godot.UpnpDevice"/> to the list of discovered devices.</para>
    /// </summary>
    public void AddDevice(UpnpDevice device)
    {
        NativeCalls.godot_icall_1_56(MethodBind2, GodotObject.GetPtr(this), GodotObject.GetPtr(device));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDevice, 3015133723ul);

    /// <summary>
    /// <para>Sets the device at <paramref name="index"/> from the list of discovered devices to <paramref name="device"/>.</para>
    /// </summary>
    public void SetDevice(int index, UpnpDevice device)
    {
        NativeCalls.godot_icall_2_70(MethodBind3, GodotObject.GetPtr(this), index, GodotObject.GetPtr(device));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveDevice, 1286410249ul);

    /// <summary>
    /// <para>Removes the device at <paramref name="index"/> from the list of discovered devices.</para>
    /// </summary>
    public void RemoveDevice(int index)
    {
        NativeCalls.godot_icall_1_38(MethodBind4, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ClearDevices, 3218959716ul);

    /// <summary>
    /// <para>Clears the list of discovered devices.</para>
    /// </summary>
    public void ClearDevices()
    {
        NativeCalls.godot_icall_0_3(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetGateway, 2276800779ul);

    /// <summary>
    /// <para>Returns the default gateway. That is the first discovered <see cref="Godot.UpnpDevice"/> that is also a valid IGD (InternetGatewayDevice).</para>
    /// </summary>
    public UpnpDevice GetGateway()
    {
        return (UpnpDevice)NativeCalls.godot_icall_0_63(MethodBind6, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Discover, 1575334765ul);

    /// <summary>
    /// <para>Discovers local <see cref="Godot.UpnpDevice"/>s. Clears the list of previously discovered devices.</para>
    /// <para>Filters for IGD (InternetGatewayDevice) type devices by default, as those manage port forwarding. <paramref name="timeout"/> is the time to wait for responses in milliseconds. <paramref name="ttl"/> is the time-to-live; only touch this if you know what you're doing.</para>
    /// <para>See <see cref="Godot.Upnp.UpnpResult"/> for possible return values.</para>
    /// </summary>
    public int Discover(int timeout = 2000, int ttl = 2, string deviceFilter = "InternetGatewayDevice")
    {
        return NativeCalls.godot_icall_3_1487(MethodBind7, GodotObject.GetPtr(this), timeout, ttl, deviceFilter);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.QueryExternalAddress, 201670096ul);

    /// <summary>
    /// <para>Returns the external <see cref="Godot.IP"/> address of the default gateway (see <see cref="Godot.Upnp.GetGateway()"/>) as string. Returns an empty string on error.</para>
    /// </summary>
    public string QueryExternalAddress()
    {
        return NativeCalls.godot_icall_0_58(MethodBind8, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddPortMapping, 818314583ul);

    /// <summary>
    /// <para>Adds a mapping to forward the external <paramref name="port"/> (between 1 and 65535, although recommended to use port 1024 or above) on the default gateway (see <see cref="Godot.Upnp.GetGateway()"/>) to the <paramref name="portInternal"/> on the local machine for the given protocol <paramref name="proto"/> (either <c>"TCP"</c> or <c>"UDP"</c>, with UDP being the default). If a port mapping for the given port and protocol combination already exists on that gateway device, this method tries to overwrite it. If that is not desired, you can retrieve the gateway manually with <see cref="Godot.Upnp.GetGateway()"/> and call <see cref="Godot.Upnp.AddPortMapping(int, int, string, string, int)"/> on it, if any. Note that forwarding a well-known port (below 1024) with UPnP may fail depending on the device.</para>
    /// <para>Depending on the gateway device, if a mapping for that port already exists, it will either be updated or it will refuse this command due to that conflict, especially if the existing mapping for that port wasn't created via UPnP or points to a different network address (or device) than this one.</para>
    /// <para>If <paramref name="portInternal"/> is <c>0</c> (the default), the same port number is used for both the external and the internal port (the <paramref name="port"/> value).</para>
    /// <para>The description (<paramref name="desc"/>) is shown in some routers management UIs and can be used to point out which application added the mapping.</para>
    /// <para>The mapping's lease <paramref name="duration"/> can be limited by specifying a duration in seconds. The default of <c>0</c> means no duration, i.e. a permanent lease and notably some devices only support these permanent leases. Note that whether permanent or not, this is only a request and the gateway may still decide at any point to remove the mapping (which usually happens on a reboot of the gateway, when its external IP address changes, or on some models when it detects a port mapping has become inactive, i.e. had no traffic for multiple minutes). If not <c>0</c> (permanent), the allowed range according to spec is between <c>120</c> (2 minutes) and <c>86400</c> seconds (24 hours).</para>
    /// <para>See <see cref="Godot.Upnp.UpnpResult"/> for possible return values.</para>
    /// </summary>
    public int AddPortMapping(int port, int portInternal = 0, string desc = "", string proto = "UDP", int duration = 0)
    {
        return NativeCalls.godot_icall_5_1488(MethodBind9, GodotObject.GetPtr(this), port, portInternal, desc, proto, duration);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DeletePortMapping, 3444187325ul);

    /// <summary>
    /// <para>Deletes the port mapping for the given port and protocol combination on the default gateway (see <see cref="Godot.Upnp.GetGateway()"/>) if one exists. <paramref name="port"/> must be a valid port between 1 and 65535, <paramref name="proto"/> can be either <c>"TCP"</c> or <c>"UDP"</c>. May be refused for mappings pointing to addresses other than this one, for well-known ports (below 1024), or for mappings not added via UPnP. See <see cref="Godot.Upnp.UpnpResult"/> for possible return values.</para>
    /// </summary>
    public int DeletePortMapping(int port, string proto = "UDP")
    {
        return NativeCalls.godot_icall_2_1289(MethodBind10, GodotObject.GetPtr(this), port, proto);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDiscoverMulticastIf, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDiscoverMulticastIf(string mIf)
    {
        NativeCalls.godot_icall_1_57(MethodBind11, GodotObject.GetPtr(this), mIf);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDiscoverMulticastIf, 201670096ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetDiscoverMulticastIf()
    {
        return NativeCalls.godot_icall_0_58(MethodBind12, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDiscoverLocalPort, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDiscoverLocalPort(int port)
    {
        NativeCalls.godot_icall_1_38(MethodBind13, GodotObject.GetPtr(this), port);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDiscoverLocalPort, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetDiscoverLocalPort()
    {
        return NativeCalls.godot_icall_0_39(MethodBind14, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDiscoverIpv6, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDiscoverIpv6(bool ipv6)
    {
        NativeCalls.godot_icall_1_14(MethodBind15, GodotObject.GetPtr(this), ipv6.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsDiscoverIpv6, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsDiscoverIpv6()
    {
        return NativeCalls.godot_icall_0_15(MethodBind16, GodotObject.GetPtr(this)).ToBool();
    }

    /// <summary>
    /// Invokes the method with the given name, using the given arguments.
    /// This method is used by Godot to invoke methods from the engine side.
    /// Do not call or override this method.
    /// </summary>
    /// <param name="method">Name of the method to invoke.</param>
    /// <param name="args">Arguments to use with the invoked method.</param>
    /// <param name="ret">Value returned by the invoked method.</param>
#pragma warning disable CS0618 // Member is obsolete
    protected internal override bool InvokeGodotClassMethod(in godot_string_name method, NativeVariantPtrArgs args, out godot_variant ret)
    {
        return base.InvokeGodotClassMethod(method, args, out ret);
    }
#pragma warning restore CS0618

    /// <summary>
    /// Check if the type contains a method with the given name.
    /// This method is used by Godot to check if a method exists before invoking it.
    /// Do not call or override this method.
    /// </summary>
    /// <param name="method">Name of the method to check for.</param>

    protected internal override bool HasGodotClassMethod(in godot_string_name method)
    {
        return base.HasGodotClassMethod(method);
    }

    /// <summary>
    /// Check if the type contains a signal with the given name.
    /// This method is used by Godot to check if a signal exists before raising it.
    /// Do not call or override this method.
    /// </summary>
    /// <param name="signal">Name of the signal to check for.</param>

    protected internal override bool HasGodotClassSignal(in godot_string_name signal)
    {
        return base.HasGodotClassSignal(signal);
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : RefCounted.PropertyName
    {
        /// <summary>
        /// Cached name for the 'discover_multicast_if' property.
        /// </summary>
        public static readonly StringName DiscoverMulticastIf = "discover_multicast_if";
        /// <summary>
        /// Cached name for the 'discover_local_port' property.
        /// </summary>
        public static readonly StringName DiscoverLocalPort = "discover_local_port";
        /// <summary>
        /// Cached name for the 'discover_ipv6' property.
        /// </summary>
        public static readonly StringName DiscoverIpv6 = "discover_ipv6";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : RefCounted.MethodName
    {
        /// <summary>
        /// Cached name for the 'get_device_count' method.
        /// </summary>
        public static readonly StringName GetDeviceCount = "get_device_count";
        /// <summary>
        /// Cached name for the 'get_device' method.
        /// </summary>
        public static readonly StringName GetDevice = "get_device";
        /// <summary>
        /// Cached name for the 'add_device' method.
        /// </summary>
        public static readonly StringName AddDevice = "add_device";
        /// <summary>
        /// Cached name for the 'set_device' method.
        /// </summary>
        public static readonly StringName SetDevice = "set_device";
        /// <summary>
        /// Cached name for the 'remove_device' method.
        /// </summary>
        public static readonly StringName RemoveDevice = "remove_device";
        /// <summary>
        /// Cached name for the 'clear_devices' method.
        /// </summary>
        public static readonly StringName ClearDevices = "clear_devices";
        /// <summary>
        /// Cached name for the 'get_gateway' method.
        /// </summary>
        public static readonly StringName GetGateway = "get_gateway";
        /// <summary>
        /// Cached name for the 'discover' method.
        /// </summary>
        public static readonly StringName Discover = "discover";
        /// <summary>
        /// Cached name for the 'query_external_address' method.
        /// </summary>
        public static readonly StringName QueryExternalAddress = "query_external_address";
        /// <summary>
        /// Cached name for the 'add_port_mapping' method.
        /// </summary>
        public static readonly StringName AddPortMapping = "add_port_mapping";
        /// <summary>
        /// Cached name for the 'delete_port_mapping' method.
        /// </summary>
        public static readonly StringName DeletePortMapping = "delete_port_mapping";
        /// <summary>
        /// Cached name for the 'set_discover_multicast_if' method.
        /// </summary>
        public static readonly StringName SetDiscoverMulticastIf = "set_discover_multicast_if";
        /// <summary>
        /// Cached name for the 'get_discover_multicast_if' method.
        /// </summary>
        public static readonly StringName GetDiscoverMulticastIf = "get_discover_multicast_if";
        /// <summary>
        /// Cached name for the 'set_discover_local_port' method.
        /// </summary>
        public static readonly StringName SetDiscoverLocalPort = "set_discover_local_port";
        /// <summary>
        /// Cached name for the 'get_discover_local_port' method.
        /// </summary>
        public static readonly StringName GetDiscoverLocalPort = "get_discover_local_port";
        /// <summary>
        /// Cached name for the 'set_discover_ipv6' method.
        /// </summary>
        public static readonly StringName SetDiscoverIpv6 = "set_discover_ipv6";
        /// <summary>
        /// Cached name for the 'is_discover_ipv6' method.
        /// </summary>
        public static readonly StringName IsDiscoverIpv6 = "is_discover_ipv6";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : RefCounted.SignalName
    {
    }
}
