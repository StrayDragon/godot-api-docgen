namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>UDP packet peer. Can be used to send and receive raw UDP packets as well as <see cref="Godot.Variant"/>s.</para>
/// <para><b>Example:</b> Send a packet:</para>
/// <para><code>
/// var peer = PacketPeerUDP.new()
/// 
/// # Optionally, you can select the local port used to send the packet.
/// peer.bind(4444)
/// 
/// peer.set_dest_address("1.1.1.1", 4433)
/// peer.put_packet("hello".to_utf8_buffer())
/// </code></para>
/// <para><b>Example:</b> Listen for packets:</para>
/// <para><code>
/// var peer
/// 
/// func _ready():
/// 	peer = PacketPeerUDP.new()
/// 	peer.bind(4433)
/// 
/// 
/// func _process(_delta):
/// 	if peer.get_available_packet_count() &gt; 0:
/// 		var array_bytes = peer.get_packet()
/// 		var packet_string = array_bytes.get_string_from_ascii()
/// 		print("Received message: ", packet_string)
/// </code></para>
/// <para><b>Note:</b> When exporting to Android, make sure to enable the <c>INTERNET</c> permission in the Android export preset before exporting the project or using one-click deploy. Otherwise, network communication of any kind will be blocked by Android.</para>
/// </summary>
[GodotClassName("PacketPeerUDP")]
public partial class PacketPeerUdp : PacketPeer
{
    private static readonly System.Type CachedType = typeof(PacketPeerUdp);

    private static readonly StringName NativeName = "PacketPeerUDP";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public PacketPeerUdp() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal PacketPeerUdp(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal PacketPeerUdp(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Bind, 4051239242ul);

    /// <summary>
    /// <para>Binds this <see cref="Godot.PacketPeerUdp"/> to the specified <paramref name="port"/> and <paramref name="bindAddress"/> with a buffer size <paramref name="recvBufSize"/>, allowing it to receive incoming packets.</para>
    /// <para>If <paramref name="bindAddress"/> is set to <c>"*"</c> (default), the peer will be bound on all available addresses (both IPv4 and IPv6).</para>
    /// <para>If <paramref name="bindAddress"/> is set to <c>"0.0.0.0"</c> (for IPv4) or <c>"::"</c> (for IPv6), the peer will be bound to all available addresses matching that IP type.</para>
    /// <para>If <paramref name="bindAddress"/> is set to any valid address (e.g. <c>"192.168.1.101"</c>, <c>"::1"</c>, etc.), the peer will only be bound to the interface with that address (or fail if no interface with the given address exists).</para>
    /// </summary>
    public Error Bind(int port, string bindAddress = "*", int recvBufSize = 65536)
    {
        return (Error)NativeCalls.godot_icall_3_973(MethodBind0, GodotObject.GetPtr(this), port, bindAddress, recvBufSize);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Close, 3218959716ul);

    /// <summary>
    /// <para>Closes the <see cref="Godot.PacketPeerUdp"/>'s underlying UDP socket.</para>
    /// </summary>
    public void Close()
    {
        NativeCalls.godot_icall_0_3(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Wait, 166280745ul);

    /// <summary>
    /// <para>Waits for a packet to arrive on the bound address. See <see cref="Godot.PacketPeerUdp.Bind(int, string, int)"/>.</para>
    /// <para><b>Note:</b> <see cref="Godot.PacketPeerUdp.Wait()"/> can't be interrupted once it has been called. This can be worked around by allowing the other party to send a specific "death pill" packet like this:</para>
    /// <para><code>
    /// var socket = new PacketPeerUdp();
    /// // Server
    /// socket.SetDestAddress("127.0.0.1", 789);
    /// socket.PutPacket("Time to stop".ToAsciiBuffer());
    /// 
    /// // Client
    /// while (socket.Wait() == OK)
    /// {
    /// 	string data = socket.GetPacket().GetStringFromASCII();
    /// 	if (data == "Time to stop")
    /// 	{
    /// 		return;
    /// 	}
    /// }
    /// </code></para>
    /// </summary>
    public Error Wait()
    {
        return (Error)NativeCalls.godot_icall_0_39(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsBound, 36873697ul);

    /// <summary>
    /// <para>Returns whether this <see cref="Godot.PacketPeerUdp"/> is bound to an address and can receive packets.</para>
    /// </summary>
    public bool IsBound()
    {
        return NativeCalls.godot_icall_0_15(MethodBind3, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ConnectToHost, 993915709ul);

    /// <summary>
    /// <para>Calling this method connects this UDP peer to the given <paramref name="host"/>/<paramref name="port"/> pair. UDP is in reality connectionless, so this option only means that incoming packets from different addresses are automatically discarded, and that outgoing packets are always sent to the connected address (future calls to <see cref="Godot.PacketPeerUdp.SetDestAddress(string, int)"/> are not allowed). This method does not send any data to the remote peer, to do that, use <see cref="Godot.PacketPeer.PutVar(Variant, bool)"/> or <see cref="Godot.PacketPeer.PutPacket(byte[])"/> as usual. See also <see cref="Godot.UdpServer"/>.</para>
    /// <para><b>Note:</b> Connecting to the remote peer does not help to protect from malicious attacks like IP spoofing, etc. Think about using an encryption technique like TLS or DTLS if you feel like your application is transferring sensitive information.</para>
    /// </summary>
    public Error ConnectToHost(string host, int port)
    {
        return (Error)NativeCalls.godot_icall_2_387(MethodBind4, GodotObject.GetPtr(this), host, port);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsSocketConnected, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the UDP socket is open and has been connected to a remote address. See <see cref="Godot.PacketPeerUdp.ConnectToHost(string, int)"/>.</para>
    /// </summary>
    public bool IsSocketConnected()
    {
        return NativeCalls.godot_icall_0_15(MethodBind5, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPacketIP, 201670096ul);

    /// <summary>
    /// <para>Returns the IP of the remote peer that sent the last packet(that was received with <see cref="Godot.PacketPeer.GetPacket()"/> or <see cref="Godot.PacketPeer.GetVar(bool)"/>).</para>
    /// </summary>
    public string GetPacketIP()
    {
        return NativeCalls.godot_icall_0_58(MethodBind6, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPacketPort, 3905245786ul);

    /// <summary>
    /// <para>Returns the port of the remote peer that sent the last packet(that was received with <see cref="Godot.PacketPeer.GetPacket()"/> or <see cref="Godot.PacketPeer.GetVar(bool)"/>).</para>
    /// </summary>
    public int GetPacketPort()
    {
        return NativeCalls.godot_icall_0_39(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLocalPort, 3905245786ul);

    /// <summary>
    /// <para>Returns the local port to which this peer is bound.</para>
    /// </summary>
    public int GetLocalPort()
    {
        return NativeCalls.godot_icall_0_39(MethodBind8, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDestAddress, 993915709ul);

    /// <summary>
    /// <para>Sets the destination address and port for sending packets and variables. A hostname will be resolved using DNS if needed.</para>
    /// <para><b>Note:</b> <see cref="Godot.PacketPeerUdp.SetBroadcastEnabled(bool)"/> must be enabled before sending packets to a broadcast address (e.g. <c>255.255.255.255</c>).</para>
    /// </summary>
    public Error SetDestAddress(string host, int port)
    {
        return (Error)NativeCalls.godot_icall_2_387(MethodBind9, GodotObject.GetPtr(this), host, port);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBroadcastEnabled, 2586408642ul);

    /// <summary>
    /// <para>Enable or disable sending of broadcast packets (e.g. <c>set_dest_address("255.255.255.255", 4343)</c>. This option is disabled by default.</para>
    /// <para><b>Note:</b> Some Android devices might require the <c>CHANGE_WIFI_MULTICAST_STATE</c> permission and this option to be enabled to receive broadcast packets too.</para>
    /// </summary>
    public void SetBroadcastEnabled(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind10, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.JoinMulticastGroup, 852856452ul);

    /// <summary>
    /// <para>Joins the multicast group specified by <paramref name="multicastAddress"/> using the interface identified by <paramref name="interfaceName"/>.</para>
    /// <para>You can join the same multicast group with multiple interfaces. Use <see cref="Godot.IP.GetLocalInterfaces()"/> to know which are available.</para>
    /// <para><b>Note:</b> Some Android devices might require the <c>CHANGE_WIFI_MULTICAST_STATE</c> permission for multicast to work.</para>
    /// </summary>
    public Error JoinMulticastGroup(string multicastAddress, string interfaceName)
    {
        return (Error)NativeCalls.godot_icall_2_330(MethodBind11, GodotObject.GetPtr(this), multicastAddress, interfaceName);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.LeaveMulticastGroup, 852856452ul);

    /// <summary>
    /// <para>Removes the interface identified by <paramref name="interfaceName"/> from the multicast group specified by <paramref name="multicastAddress"/>.</para>
    /// </summary>
    public Error LeaveMulticastGroup(string multicastAddress, string interfaceName)
    {
        return (Error)NativeCalls.godot_icall_2_330(MethodBind12, GodotObject.GetPtr(this), multicastAddress, interfaceName);
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
    public new class PropertyName : PacketPeer.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : PacketPeer.MethodName
    {
        /// <summary>
        /// Cached name for the 'bind' method.
        /// </summary>
        public static readonly StringName Bind = "bind";
        /// <summary>
        /// Cached name for the 'close' method.
        /// </summary>
        public static readonly StringName Close = "close";
        /// <summary>
        /// Cached name for the 'wait' method.
        /// </summary>
        public static readonly StringName Wait = "wait";
        /// <summary>
        /// Cached name for the 'is_bound' method.
        /// </summary>
        public static readonly StringName IsBound = "is_bound";
        /// <summary>
        /// Cached name for the 'connect_to_host' method.
        /// </summary>
        public static readonly StringName ConnectToHost = "connect_to_host";
        /// <summary>
        /// Cached name for the 'is_socket_connected' method.
        /// </summary>
        public static readonly StringName IsSocketConnected = "is_socket_connected";
        /// <summary>
        /// Cached name for the 'get_packet_ip' method.
        /// </summary>
        public static readonly StringName GetPacketIP = "get_packet_ip";
        /// <summary>
        /// Cached name for the 'get_packet_port' method.
        /// </summary>
        public static readonly StringName GetPacketPort = "get_packet_port";
        /// <summary>
        /// Cached name for the 'get_local_port' method.
        /// </summary>
        public static readonly StringName GetLocalPort = "get_local_port";
        /// <summary>
        /// Cached name for the 'set_dest_address' method.
        /// </summary>
        public static readonly StringName SetDestAddress = "set_dest_address";
        /// <summary>
        /// Cached name for the 'set_broadcast_enabled' method.
        /// </summary>
        public static readonly StringName SetBroadcastEnabled = "set_broadcast_enabled";
        /// <summary>
        /// Cached name for the 'join_multicast_group' method.
        /// </summary>
        public static readonly StringName JoinMulticastGroup = "join_multicast_group";
        /// <summary>
        /// Cached name for the 'leave_multicast_group' method.
        /// </summary>
        public static readonly StringName LeaveMulticastGroup = "leave_multicast_group";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : PacketPeer.SignalName
    {
    }
}
