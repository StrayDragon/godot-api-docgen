namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>IP contains support functions for the Internet Protocol (IP). TCP/IP support is in different classes (see <see cref="Godot.StreamPeerTcp"/> and <see cref="Godot.TcpServer"/>). IP provides DNS hostname resolution support, both blocking and threaded.</para>
/// </summary>
[GodotClassName("IP")]
public partial class IPInstance : GodotObject
{
    private static readonly System.Type CachedType = typeof(IPInstance);

    private static readonly StringName NativeName = "IP";

    internal IPInstance() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal IPInstance(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal IPInstance(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ResolveHostname, 4283295457ul);

    /// <summary>
    /// <para>Returns a given hostname's IPv4 or IPv6 address when resolved (blocking-type method). The address type returned depends on the <see cref="Godot.IP.Type"/> constant given as <paramref name="iPType"/>.</para>
    /// </summary>
    public string ResolveHostname(string host, IP.Type iPType = (IP.Type)(3))
    {
        return NativeCalls.godot_icall_2_392(MethodBind0, GodotObject.GetPtr(this), host, (int)iPType);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ResolveHostnameAddresses, 773767525ul);

    /// <summary>
    /// <para>Resolves a given hostname in a blocking way. Addresses are returned as an <see cref="Godot.Collections.Array"/> of IPv4 or IPv6 addresses depending on <paramref name="iPType"/>.</para>
    /// </summary>
    public string[] ResolveHostnameAddresses(string host, IP.Type iPType = (IP.Type)(3))
    {
        return NativeCalls.godot_icall_2_721(MethodBind1, GodotObject.GetPtr(this), host, (int)iPType);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ResolveHostnameQueueItem, 1749894742ul);

    /// <summary>
    /// <para>Creates a queue item to resolve a hostname to an IPv4 or IPv6 address depending on the <see cref="Godot.IP.Type"/> constant given as <paramref name="iPType"/>. Returns the queue ID if successful, or <see cref="Godot.IP.ResolverInvalidId"/> on error.</para>
    /// </summary>
    public int ResolveHostnameQueueItem(string host, IP.Type iPType = (IP.Type)(3))
    {
        return NativeCalls.godot_icall_2_387(MethodBind2, GodotObject.GetPtr(this), host, (int)iPType);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetResolveItemStatus, 3812250196ul);

    /// <summary>
    /// <para>Returns a queued hostname's status as a <see cref="Godot.IP.ResolverStatus"/> constant, given its queue <paramref name="id"/>.</para>
    /// </summary>
    public IP.ResolverStatus GetResolveItemStatus(int id)
    {
        return (IP.ResolverStatus)NativeCalls.godot_icall_1_60(MethodBind3, GodotObject.GetPtr(this), id);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetResolveItemAddress, 844755477ul);

    /// <summary>
    /// <para>Returns a queued hostname's IP address, given its queue <paramref name="id"/>. Returns an empty string on error or if resolution hasn't happened yet (see <see cref="Godot.IPInstance.GetResolveItemStatus(int)"/>).</para>
    /// </summary>
    public string GetResolveItemAddress(int id)
    {
        return NativeCalls.godot_icall_1_133(MethodBind4, GodotObject.GetPtr(this), id);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetResolveItemAddresses, 663333327ul);

    /// <summary>
    /// <para>Returns resolved addresses, or an empty array if an error happened or resolution didn't happen yet (see <see cref="Godot.IPInstance.GetResolveItemStatus(int)"/>).</para>
    /// </summary>
    public Godot.Collections.Array GetResolveItemAddresses(int id)
    {
        return NativeCalls.godot_icall_1_457(MethodBind5, GodotObject.GetPtr(this), id);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.EraseResolveItem, 1286410249ul);

    /// <summary>
    /// <para>Removes a given item <paramref name="id"/> from the queue. This should be used to free a queue after it has completed to enable more queries to happen.</para>
    /// </summary>
    public void EraseResolveItem(int id)
    {
        NativeCalls.godot_icall_1_38(MethodBind6, GodotObject.GetPtr(this), id);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLocalAddresses, 1139954409ul);

    /// <summary>
    /// <para>Returns all the user's current IPv4 and IPv6 addresses as an array.</para>
    /// </summary>
    public string[] GetLocalAddresses()
    {
        return NativeCalls.godot_icall_0_108(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLocalInterfaces, 3995934104ul);

    /// <summary>
    /// <para>Returns all network adapters as an array.</para>
    /// <para>Each adapter is a dictionary of the form:</para>
    /// <para><code>
    /// {
    /// 	"index": "1", # Interface index.
    /// 	"name": "eth0", # Interface name.
    /// 	"friendly": "Ethernet One", # A friendly name (might be empty).
    /// 	"addresses": ["192.168.1.101"], # An array of IP addresses associated to this interface.
    /// }
    /// </code></para>
    /// </summary>
    public Godot.Collections.Array<Godot.Collections.Dictionary> GetLocalInterfaces()
    {
        return new Godot.Collections.Array<Godot.Collections.Dictionary>(NativeCalls.godot_icall_0_120(MethodBind8, GodotObject.GetPtr(this)));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ClearCache, 3005725572ul);

    /// <summary>
    /// <para>Removes all of a <paramref name="hostname"/>'s cached references. If no <paramref name="hostname"/> is given, all cached IP addresses are removed.</para>
    /// </summary>
    public void ClearCache(string hostname = "")
    {
        NativeCalls.godot_icall_1_57(MethodBind9, GodotObject.GetPtr(this), hostname);
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
    public new class PropertyName : GodotObject.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : GodotObject.MethodName
    {
        /// <summary>
        /// Cached name for the 'resolve_hostname' method.
        /// </summary>
        public static readonly StringName ResolveHostname = "resolve_hostname";
        /// <summary>
        /// Cached name for the 'resolve_hostname_addresses' method.
        /// </summary>
        public static readonly StringName ResolveHostnameAddresses = "resolve_hostname_addresses";
        /// <summary>
        /// Cached name for the 'resolve_hostname_queue_item' method.
        /// </summary>
        public static readonly StringName ResolveHostnameQueueItem = "resolve_hostname_queue_item";
        /// <summary>
        /// Cached name for the 'get_resolve_item_status' method.
        /// </summary>
        public static readonly StringName GetResolveItemStatus = "get_resolve_item_status";
        /// <summary>
        /// Cached name for the 'get_resolve_item_address' method.
        /// </summary>
        public static readonly StringName GetResolveItemAddress = "get_resolve_item_address";
        /// <summary>
        /// Cached name for the 'get_resolve_item_addresses' method.
        /// </summary>
        public static readonly StringName GetResolveItemAddresses = "get_resolve_item_addresses";
        /// <summary>
        /// Cached name for the 'erase_resolve_item' method.
        /// </summary>
        public static readonly StringName EraseResolveItem = "erase_resolve_item";
        /// <summary>
        /// Cached name for the 'get_local_addresses' method.
        /// </summary>
        public static readonly StringName GetLocalAddresses = "get_local_addresses";
        /// <summary>
        /// Cached name for the 'get_local_interfaces' method.
        /// </summary>
        public static readonly StringName GetLocalInterfaces = "get_local_interfaces";
        /// <summary>
        /// Cached name for the 'clear_cache' method.
        /// </summary>
        public static readonly StringName ClearCache = "clear_cache";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : GodotObject.SignalName
    {
    }
}
