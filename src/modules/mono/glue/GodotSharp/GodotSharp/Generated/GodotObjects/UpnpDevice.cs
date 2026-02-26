namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Universal Plug and Play (UPnP) device. See <see cref="Godot.Upnp"/> for UPnP discovery and utility functions. Provides low-level access to UPNP control commands. Allows to manage port mappings (port forwarding) and to query network information of the device (like local and external IP address and status). Note that methods on this class are synchronous and block the calling thread.</para>
/// </summary>
[GodotClassName("UPNPDevice")]
public partial class UpnpDevice : RefCounted
{
    public enum IgdStatusEnum : long
    {
        /// <summary>
        /// <para>OK.</para>
        /// </summary>
        Ok = 0,
        /// <summary>
        /// <para>HTTP error.</para>
        /// </summary>
        HttpError = 1,
        /// <summary>
        /// <para>Empty HTTP response.</para>
        /// </summary>
        HttpEmpty = 2,
        /// <summary>
        /// <para>Returned response contained no URLs.</para>
        /// </summary>
        [Obsolete("This value is no longer used.")]
        NoUrls = 3,
        /// <summary>
        /// <para>Not a valid IGD.</para>
        /// </summary>
        NoIgd = 4,
        /// <summary>
        /// <para>Disconnected.</para>
        /// </summary>
        Disconnected = 5,
        /// <summary>
        /// <para>Unknown device.</para>
        /// </summary>
        UnknownDevice = 6,
        /// <summary>
        /// <para>Invalid control.</para>
        /// </summary>
        InvalidControl = 7,
        /// <summary>
        /// <para>Memory allocation error.</para>
        /// </summary>
        [Obsolete("This value is no longer used.")]
        MallocError = 8,
        /// <summary>
        /// <para>Unknown error.</para>
        /// </summary>
        UnknownError = 9
    }

    /// <summary>
    /// <para>URL to the device description.</para>
    /// </summary>
    public string DescriptionUrl
    {
        get
        {
            return GetDescriptionUrl();
        }
        set
        {
            SetDescriptionUrl(value);
        }
    }

    /// <summary>
    /// <para>Service type.</para>
    /// </summary>
    public string ServiceType
    {
        get
        {
            return GetServiceType();
        }
        set
        {
            SetServiceType(value);
        }
    }

    /// <summary>
    /// <para>IDG control URL.</para>
    /// </summary>
    public string IgdControlUrl
    {
        get
        {
            return GetIgdControlUrl();
        }
        set
        {
            SetIgdControlUrl(value);
        }
    }

    /// <summary>
    /// <para>IGD service type.</para>
    /// </summary>
    public string IgdServiceType
    {
        get
        {
            return GetIgdServiceType();
        }
        set
        {
            SetIgdServiceType(value);
        }
    }

    /// <summary>
    /// <para>Address of the local machine in the network connecting it to this <see cref="Godot.UpnpDevice"/>.</para>
    /// </summary>
    public string IgdOurAddr
    {
        get
        {
            return GetIgdOurAddr();
        }
        set
        {
            SetIgdOurAddr(value);
        }
    }

    /// <summary>
    /// <para>IGD status.</para>
    /// </summary>
    public UpnpDevice.IgdStatusEnum IgdStatus
    {
        get
        {
            return GetIgdStatus();
        }
        set
        {
            SetIgdStatus(value);
        }
    }

    private static readonly System.Type CachedType = typeof(UpnpDevice);

    private static readonly StringName NativeName = "UPNPDevice";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public UpnpDevice() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal UpnpDevice(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal UpnpDevice(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsValidGateway, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if this is a valid IGD (InternetGatewayDevice) which potentially supports port forwarding.</para>
    /// </summary>
    public bool IsValidGateway()
    {
        return NativeCalls.godot_icall_0_15(MethodBind0, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.QueryExternalAddress, 201670096ul);

    /// <summary>
    /// <para>Returns the external IP address of this <see cref="Godot.UpnpDevice"/> or an empty string.</para>
    /// </summary>
    public string QueryExternalAddress()
    {
        return NativeCalls.godot_icall_0_58(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddPortMapping, 818314583ul);

    /// <summary>
    /// <para>Adds a port mapping to forward the given external port on this <see cref="Godot.UpnpDevice"/> for the given protocol to the local machine. See <see cref="Godot.Upnp.AddPortMapping(int, int, string, string, int)"/>.</para>
    /// </summary>
    public int AddPortMapping(int port, int portInternal = 0, string desc = "", string proto = "UDP", int duration = 0)
    {
        return NativeCalls.godot_icall_5_1488(MethodBind2, GodotObject.GetPtr(this), port, portInternal, desc, proto, duration);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DeletePortMapping, 3444187325ul);

    /// <summary>
    /// <para>Deletes the port mapping identified by the given port and protocol combination on this device. See <see cref="Godot.Upnp.DeletePortMapping(int, string)"/>.</para>
    /// </summary>
    public int DeletePortMapping(int port, string proto = "UDP")
    {
        return NativeCalls.godot_icall_2_1289(MethodBind3, GodotObject.GetPtr(this), port, proto);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDescriptionUrl, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDescriptionUrl(string url)
    {
        NativeCalls.godot_icall_1_57(MethodBind4, GodotObject.GetPtr(this), url);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDescriptionUrl, 201670096ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetDescriptionUrl()
    {
        return NativeCalls.godot_icall_0_58(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetServiceType, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetServiceType(string type)
    {
        NativeCalls.godot_icall_1_57(MethodBind6, GodotObject.GetPtr(this), type);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetServiceType, 201670096ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetServiceType()
    {
        return NativeCalls.godot_icall_0_58(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetIgdControlUrl, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetIgdControlUrl(string url)
    {
        NativeCalls.godot_icall_1_57(MethodBind8, GodotObject.GetPtr(this), url);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetIgdControlUrl, 201670096ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetIgdControlUrl()
    {
        return NativeCalls.godot_icall_0_58(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetIgdServiceType, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetIgdServiceType(string type)
    {
        NativeCalls.godot_icall_1_57(MethodBind10, GodotObject.GetPtr(this), type);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetIgdServiceType, 201670096ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetIgdServiceType()
    {
        return NativeCalls.godot_icall_0_58(MethodBind11, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetIgdOurAddr, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetIgdOurAddr(string addr)
    {
        NativeCalls.godot_icall_1_57(MethodBind12, GodotObject.GetPtr(this), addr);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetIgdOurAddr, 201670096ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetIgdOurAddr()
    {
        return NativeCalls.godot_icall_0_58(MethodBind13, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetIgdStatus, 519504122ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetIgdStatus(UpnpDevice.IgdStatusEnum status)
    {
        NativeCalls.godot_icall_1_38(MethodBind14, GodotObject.GetPtr(this), (int)status);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetIgdStatus, 180887011ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public UpnpDevice.IgdStatusEnum GetIgdStatus()
    {
        return (UpnpDevice.IgdStatusEnum)NativeCalls.godot_icall_0_39(MethodBind15, GodotObject.GetPtr(this));
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
        /// Cached name for the 'description_url' property.
        /// </summary>
        public static readonly StringName DescriptionUrl = "description_url";
        /// <summary>
        /// Cached name for the 'service_type' property.
        /// </summary>
        public static readonly StringName ServiceType = "service_type";
        /// <summary>
        /// Cached name for the 'igd_control_url' property.
        /// </summary>
        public static readonly StringName IgdControlUrl = "igd_control_url";
        /// <summary>
        /// Cached name for the 'igd_service_type' property.
        /// </summary>
        public static readonly StringName IgdServiceType = "igd_service_type";
        /// <summary>
        /// Cached name for the 'igd_our_addr' property.
        /// </summary>
        public static readonly StringName IgdOurAddr = "igd_our_addr";
        /// <summary>
        /// Cached name for the 'igd_status' property.
        /// </summary>
        public static readonly StringName IgdStatus = "igd_status";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : RefCounted.MethodName
    {
        /// <summary>
        /// Cached name for the 'is_valid_gateway' method.
        /// </summary>
        public static readonly StringName IsValidGateway = "is_valid_gateway";
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
        /// Cached name for the 'set_description_url' method.
        /// </summary>
        public static readonly StringName SetDescriptionUrl = "set_description_url";
        /// <summary>
        /// Cached name for the 'get_description_url' method.
        /// </summary>
        public static readonly StringName GetDescriptionUrl = "get_description_url";
        /// <summary>
        /// Cached name for the 'set_service_type' method.
        /// </summary>
        public static readonly StringName SetServiceType = "set_service_type";
        /// <summary>
        /// Cached name for the 'get_service_type' method.
        /// </summary>
        public static readonly StringName GetServiceType = "get_service_type";
        /// <summary>
        /// Cached name for the 'set_igd_control_url' method.
        /// </summary>
        public static readonly StringName SetIgdControlUrl = "set_igd_control_url";
        /// <summary>
        /// Cached name for the 'get_igd_control_url' method.
        /// </summary>
        public static readonly StringName GetIgdControlUrl = "get_igd_control_url";
        /// <summary>
        /// Cached name for the 'set_igd_service_type' method.
        /// </summary>
        public static readonly StringName SetIgdServiceType = "set_igd_service_type";
        /// <summary>
        /// Cached name for the 'get_igd_service_type' method.
        /// </summary>
        public static readonly StringName GetIgdServiceType = "get_igd_service_type";
        /// <summary>
        /// Cached name for the 'set_igd_our_addr' method.
        /// </summary>
        public static readonly StringName SetIgdOurAddr = "set_igd_our_addr";
        /// <summary>
        /// Cached name for the 'get_igd_our_addr' method.
        /// </summary>
        public static readonly StringName GetIgdOurAddr = "get_igd_our_addr";
        /// <summary>
        /// Cached name for the 'set_igd_status' method.
        /// </summary>
        public static readonly StringName SetIgdStatus = "set_igd_status";
        /// <summary>
        /// Cached name for the 'get_igd_status' method.
        /// </summary>
        public static readonly StringName GetIgdStatus = "get_igd_status";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : RefCounted.SignalName
    {
    }
}
