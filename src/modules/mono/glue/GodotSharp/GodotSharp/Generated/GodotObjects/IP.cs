namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>IP contains support functions for the Internet Protocol (IP). TCP/IP support is in different classes (see <see cref="Godot.StreamPeerTcp"/> and <see cref="Godot.TcpServer"/>). IP provides DNS hostname resolution support, both blocking and threaded.</para>
/// </summary>
public static partial class IP
{
    /// <summary>
    /// <para>Maximum number of concurrent DNS resolver queries allowed, <see cref="Godot.IP.ResolverInvalidId"/> is returned if exceeded.</para>
    /// </summary>
    public const long ResolverMaxQueries = 256;
    /// <summary>
    /// <para>Invalid ID constant. Returned if <see cref="Godot.IP.ResolverMaxQueries"/> is exceeded.</para>
    /// </summary>
    public const long ResolverInvalidId = -1;

    public enum ResolverStatus : long
    {
        /// <summary>
        /// <para>DNS hostname resolver status: No status.</para>
        /// </summary>
        None = 0,
        /// <summary>
        /// <para>DNS hostname resolver status: Waiting.</para>
        /// </summary>
        Waiting = 1,
        /// <summary>
        /// <para>DNS hostname resolver status: Done.</para>
        /// </summary>
        Done = 2,
        /// <summary>
        /// <para>DNS hostname resolver status: Error.</para>
        /// </summary>
        Error = 3
    }

    public enum Type : long
    {
        /// <summary>
        /// <para>Address type: None.</para>
        /// </summary>
        None = 0,
        /// <summary>
        /// <para>Address type: Internet protocol version 4 (IPv4).</para>
        /// </summary>
        Ipv4 = 1,
        /// <summary>
        /// <para>Address type: Internet protocol version 6 (IPv6).</para>
        /// </summary>
        Ipv6 = 2,
        /// <summary>
        /// <para>Address type: Any.</para>
        /// </summary>
        Any = 3
    }

    private static readonly StringName NativeName = "IP";

    private static IPInstance singleton;

    public static IPInstance Singleton =>
        singleton ??= (IPInstance)InteropUtils.EngineGetSingleton("IP");

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ResolveHostname, 4283295457ul);

    /// <summary>
    /// <para>Returns a given hostname's IPv4 or IPv6 address when resolved (blocking-type method). The address type returned depends on the <see cref="Godot.IP.Type"/> constant given as <paramref name="iPType"/>.</para>
    /// </summary>
    public static string ResolveHostname(string host, IP.Type iPType = (IP.Type)(3))
    {
        return NativeCalls.godot_icall_2_392(MethodBind0, GodotObject.GetPtr(Singleton), host, (int)iPType);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ResolveHostnameAddresses, 773767525ul);

    /// <summary>
    /// <para>Resolves a given hostname in a blocking way. Addresses are returned as an <see cref="Godot.Collections.Array"/> of IPv4 or IPv6 addresses depending on <paramref name="iPType"/>.</para>
    /// </summary>
    public static string[] ResolveHostnameAddresses(string host, IP.Type iPType = (IP.Type)(3))
    {
        return NativeCalls.godot_icall_2_721(MethodBind1, GodotObject.GetPtr(Singleton), host, (int)iPType);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ResolveHostnameQueueItem, 1749894742ul);

    /// <summary>
    /// <para>Creates a queue item to resolve a hostname to an IPv4 or IPv6 address depending on the <see cref="Godot.IP.Type"/> constant given as <paramref name="iPType"/>. Returns the queue ID if successful, or <see cref="Godot.IP.ResolverInvalidId"/> on error.</para>
    /// </summary>
    public static int ResolveHostnameQueueItem(string host, IP.Type iPType = (IP.Type)(3))
    {
        return NativeCalls.godot_icall_2_387(MethodBind2, GodotObject.GetPtr(Singleton), host, (int)iPType);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetResolveItemStatus, 3812250196ul);

    /// <summary>
    /// <para>Returns a queued hostname's status as a <see cref="Godot.IP.ResolverStatus"/> constant, given its queue <paramref name="id"/>.</para>
    /// </summary>
    public static IP.ResolverStatus GetResolveItemStatus(int id)
    {
        return (IP.ResolverStatus)NativeCalls.godot_icall_1_60(MethodBind3, GodotObject.GetPtr(Singleton), id);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetResolveItemAddress, 844755477ul);

    /// <summary>
    /// <para>Returns a queued hostname's IP address, given its queue <paramref name="id"/>. Returns an empty string on error or if resolution hasn't happened yet (see <see cref="Godot.IP.GetResolveItemStatus(int)"/>).</para>
    /// </summary>
    public static string GetResolveItemAddress(int id)
    {
        return NativeCalls.godot_icall_1_133(MethodBind4, GodotObject.GetPtr(Singleton), id);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetResolveItemAddresses, 663333327ul);

    /// <summary>
    /// <para>Returns resolved addresses, or an empty array if an error happened or resolution didn't happen yet (see <see cref="Godot.IP.GetResolveItemStatus(int)"/>).</para>
    /// </summary>
    public static Godot.Collections.Array GetResolveItemAddresses(int id)
    {
        return NativeCalls.godot_icall_1_457(MethodBind5, GodotObject.GetPtr(Singleton), id);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.EraseResolveItem, 1286410249ul);

    /// <summary>
    /// <para>Removes a given item <paramref name="id"/> from the queue. This should be used to free a queue after it has completed to enable more queries to happen.</para>
    /// </summary>
    public static void EraseResolveItem(int id)
    {
        NativeCalls.godot_icall_1_38(MethodBind6, GodotObject.GetPtr(Singleton), id);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLocalAddresses, 1139954409ul);

    /// <summary>
    /// <para>Returns all the user's current IPv4 and IPv6 addresses as an array.</para>
    /// </summary>
    public static string[] GetLocalAddresses()
    {
        return NativeCalls.godot_icall_0_108(MethodBind7, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLocalInterfaces, 3995934104ul);

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
    public static Godot.Collections.Array<Godot.Collections.Dictionary> GetLocalInterfaces()
    {
        return new Godot.Collections.Array<Godot.Collections.Dictionary>(NativeCalls.godot_icall_0_120(MethodBind8, GodotObject.GetPtr(Singleton)));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ClearCache, 3005725572ul);

    /// <summary>
    /// <para>Removes all of a <paramref name="hostname"/>'s cached references. If no <paramref name="hostname"/> is given, all cached IP addresses are removed.</para>
    /// </summary>
    public static void ClearCache(string hostname = "")
    {
        NativeCalls.godot_icall_1_57(MethodBind9, GodotObject.GetPtr(Singleton), hostname);
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public class PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public class MethodName
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
    public class SignalName
    {
    }
}
