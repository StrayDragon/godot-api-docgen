namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A simple server that opens a UDP socket and returns connected <see cref="Godot.PacketPeerUdp"/> upon receiving new packets. See also <see cref="Godot.PacketPeerUdp.ConnectToHost(string, int)"/>.</para>
/// <para>After starting the server (<see cref="Godot.UdpServer.Listen(ushort, string)"/>), you will need to <see cref="Godot.UdpServer.Poll()"/> it at regular intervals (e.g. inside <see cref="Godot.Node._Process(double)"/>) for it to process new packets, delivering them to the appropriate <see cref="Godot.PacketPeerUdp"/>, and taking new connections.</para>
/// <para>Below a small example of how it can be used:</para>
/// <para><code>
/// // ServerNode.cs
/// using Godot;
/// using System.Collections.Generic;
/// 
/// public partial class ServerNode : Node
/// {
/// 	private UdpServer _server = new UdpServer();
/// 	private List&lt;PacketPeerUdp&gt; _peers  = new List&lt;PacketPeerUdp&gt;();
/// 
/// 	public override void _Ready()
/// 	{
/// 		_server.Listen(4242);
/// 	}
/// 
/// 	public override void _Process(double delta)
/// 	{
/// 		_server.Poll(); // Important!
/// 		if (_server.IsConnectionAvailable())
/// 		{
/// 			PacketPeerUdp peer = _server.TakeConnection();
/// 			byte[] packet = peer.GetPacket();
/// 			GD.Print($"Accepted Peer: {peer.GetPacketIP()}:{peer.GetPacketPort()}");
/// 			GD.Print($"Received Data: {packet.GetStringFromUtf8()}");
/// 			// Reply so it knows we received the message.
/// 			peer.PutPacket(packet);
/// 			// Keep a reference so we can keep contacting the remote peer.
/// 			_peers.Add(peer);
/// 		}
/// 		foreach (var peer in _peers)
/// 		{
/// 			// Do something with the peers.
/// 		}
/// 	}
/// }
/// </code></para>
/// <para><code>
/// // ClientNode.cs
/// using Godot;
/// 
/// public partial class ClientNode : Node
/// {
/// 	private PacketPeerUdp _udp = new PacketPeerUdp();
/// 	private bool _connected = false;
/// 
/// 	public override void _Ready()
/// 	{
/// 		_udp.ConnectToHost("127.0.0.1", 4242);
/// 	}
/// 
/// 	public override void _Process(double delta)
/// 	{
/// 		if (!_connected)
/// 		{
/// 			// Try to contact server
/// 			_udp.PutPacket("The Answer Is..42!".ToUtf8Buffer());
/// 		}
/// 		if (_udp.GetAvailablePacketCount() &gt; 0)
/// 		{
/// 			GD.Print($"Connected: {_udp.GetPacket().GetStringFromUtf8()}");
/// 			_connected = true;
/// 		}
/// 	}
/// }
/// </code></para>
/// </summary>
[GodotClassName("UDPServer")]
public partial class UdpServer : RefCounted
{
    /// <summary>
    /// <para>Define the maximum number of pending connections, during <see cref="Godot.UdpServer.Poll()"/>, any new pending connection exceeding that value will be automatically dropped. Setting this value to <c>0</c> effectively prevents any new pending connection to be accepted (e.g. when all your players have connected).</para>
    /// </summary>
    public int MaxPendingConnections
    {
        get
        {
            return GetMaxPendingConnections();
        }
        set
        {
            SetMaxPendingConnections(value);
        }
    }

    private static readonly System.Type CachedType = typeof(UdpServer);

    private static readonly StringName NativeName = "UDPServer";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public UdpServer() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal UdpServer(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal UdpServer(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Listen, 3167955072ul);

    /// <summary>
    /// <para>Starts the server by opening a UDP socket listening on the given <paramref name="port"/>. You can optionally specify a <paramref name="bindAddress"/> to only listen for packets sent to that address. See also <see cref="Godot.PacketPeerUdp.Bind(int, string, int)"/>.</para>
    /// </summary>
    public Error Listen(ushort port, string bindAddress = "*")
    {
        return (Error)NativeCalls.godot_icall_2_1297(MethodBind0, GodotObject.GetPtr(this), port, bindAddress);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Poll, 166280745ul);

    /// <summary>
    /// <para>Call this method at regular intervals (e.g. inside <see cref="Godot.Node._Process(double)"/>) to process new packets. Any packet from a known address/port pair will be delivered to the appropriate <see cref="Godot.PacketPeerUdp"/>, while any packet received from an unknown address/port pair will be added as a pending connection (see <see cref="Godot.UdpServer.IsConnectionAvailable()"/> and <see cref="Godot.UdpServer.TakeConnection()"/>). The maximum number of pending connections is defined via <see cref="Godot.UdpServer.MaxPendingConnections"/>.</para>
    /// </summary>
    public Error Poll()
    {
        return (Error)NativeCalls.godot_icall_0_39(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsConnectionAvailable, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if a packet with a new address/port combination was received on the socket.</para>
    /// </summary>
    public bool IsConnectionAvailable()
    {
        return NativeCalls.godot_icall_0_15(MethodBind2, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLocalPort, 3905245786ul);

    /// <summary>
    /// <para>Returns the local port this server is listening to.</para>
    /// </summary>
    public int GetLocalPort()
    {
        return NativeCalls.godot_icall_0_39(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsListening, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the socket is open and listening on a port.</para>
    /// </summary>
    public bool IsListening()
    {
        return NativeCalls.godot_icall_0_15(MethodBind4, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.TakeConnection, 808734560ul);

    /// <summary>
    /// <para>Returns the first pending connection (connected to the appropriate address/port). Will return <see langword="null"/> if no new connection is available. See also <see cref="Godot.UdpServer.IsConnectionAvailable()"/>, <see cref="Godot.PacketPeerUdp.ConnectToHost(string, int)"/>.</para>
    /// </summary>
    public PacketPeerUdp TakeConnection()
    {
        return (PacketPeerUdp)NativeCalls.godot_icall_0_63(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Stop, 3218959716ul);

    /// <summary>
    /// <para>Stops the server, closing the UDP socket if open. Will close all connected <see cref="Godot.PacketPeerUdp"/> accepted via <see cref="Godot.UdpServer.TakeConnection()"/> (remote peers will not be notified).</para>
    /// </summary>
    public void Stop()
    {
        NativeCalls.godot_icall_0_3(MethodBind6, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMaxPendingConnections, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMaxPendingConnections(int maxPendingConnections)
    {
        NativeCalls.godot_icall_1_38(MethodBind7, GodotObject.GetPtr(this), maxPendingConnections);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMaxPendingConnections, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetMaxPendingConnections()
    {
        return NativeCalls.godot_icall_0_39(MethodBind8, GodotObject.GetPtr(this));
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
        /// Cached name for the 'max_pending_connections' property.
        /// </summary>
        public static readonly StringName MaxPendingConnections = "max_pending_connections";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : RefCounted.MethodName
    {
        /// <summary>
        /// Cached name for the 'listen' method.
        /// </summary>
        public static readonly StringName Listen = "listen";
        /// <summary>
        /// Cached name for the 'poll' method.
        /// </summary>
        public static readonly StringName Poll = "poll";
        /// <summary>
        /// Cached name for the 'is_connection_available' method.
        /// </summary>
        public static readonly StringName IsConnectionAvailable = "is_connection_available";
        /// <summary>
        /// Cached name for the 'get_local_port' method.
        /// </summary>
        public static readonly StringName GetLocalPort = "get_local_port";
        /// <summary>
        /// Cached name for the 'is_listening' method.
        /// </summary>
        public static readonly StringName IsListening = "is_listening";
        /// <summary>
        /// Cached name for the 'take_connection' method.
        /// </summary>
        public static readonly StringName TakeConnection = "take_connection";
        /// <summary>
        /// Cached name for the 'stop' method.
        /// </summary>
        public static readonly StringName Stop = "stop";
        /// <summary>
        /// Cached name for the 'set_max_pending_connections' method.
        /// </summary>
        public static readonly StringName SetMaxPendingConnections = "set_max_pending_connections";
        /// <summary>
        /// Cached name for the 'get_max_pending_connections' method.
        /// </summary>
        public static readonly StringName GetMaxPendingConnections = "get_max_pending_connections";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : RefCounted.SignalName
    {
    }
}
