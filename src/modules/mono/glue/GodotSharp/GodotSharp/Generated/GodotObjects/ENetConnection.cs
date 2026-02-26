namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>ENet's purpose is to provide a relatively thin, simple and robust network communication layer on top of UDP (User Datagram Protocol).</para>
/// </summary>
public partial class ENetConnection : RefCounted
{
    public enum CompressionMode : long
    {
        /// <summary>
        /// <para>No compression. This uses the most bandwidth, but has the upside of requiring the fewest CPU resources. This option may also be used to make network debugging using tools like Wireshark easier.</para>
        /// </summary>
        None = 0,
        /// <summary>
        /// <para>ENet's built-in range encoding. Works well on small packets, but is not the most efficient algorithm on packets larger than 4 KB.</para>
        /// </summary>
        RangeCoder = 1,
        /// <summary>
        /// <para><a href="https://fastlz.org/">FastLZ</a> compression. This option uses less CPU resources compared to <see cref="Godot.ENetConnection.CompressionMode.Zlib"/>, at the expense of using more bandwidth.</para>
        /// </summary>
        Fastlz = 2,
        /// <summary>
        /// <para><a href="https://www.zlib.net/">Zlib</a> compression. This option uses less bandwidth compared to <see cref="Godot.ENetConnection.CompressionMode.Fastlz"/>, at the expense of using more CPU resources.</para>
        /// </summary>
        Zlib = 3,
        /// <summary>
        /// <para><a href="https://facebook.github.io/zstd/">Zstandard</a> compression. Note that this algorithm is not very efficient on packets smaller than 4 KB. Therefore, it's recommended to use other compression algorithms in most cases.</para>
        /// </summary>
        Zstd = 4
    }

    public enum EventType : long
    {
        /// <summary>
        /// <para>An error occurred during <see cref="Godot.ENetConnection.Service(int)"/>. You will likely need to <see cref="Godot.ENetConnection.Destroy()"/> the host and recreate it.</para>
        /// </summary>
        Error = -1,
        /// <summary>
        /// <para>No event occurred within the specified time limit.</para>
        /// </summary>
        None = 0,
        /// <summary>
        /// <para>A connection request initiated by enet_host_connect has completed. The array will contain the peer which successfully connected.</para>
        /// </summary>
        Connect = 1,
        /// <summary>
        /// <para>A peer has disconnected. This event is generated on a successful completion of a disconnect initiated by <see cref="Godot.ENetPacketPeer.PeerDisconnect(int)"/>, if a peer has timed out, or if a connection request initialized by <see cref="Godot.ENetConnection.ConnectToHost(string, int, int, int)"/> has timed out. The array will contain the peer which disconnected. The data field contains user supplied data describing the disconnection, or 0, if none is available.</para>
        /// </summary>
        Disconnect = 2,
        /// <summary>
        /// <para>A packet has been received from a peer. The array will contain the peer which sent the packet and the channel number upon which the packet was received. The received packet will be queued to the associated <see cref="Godot.ENetPacketPeer"/>.</para>
        /// </summary>
        Receive = 3
    }

    public enum HostStatistic : long
    {
        /// <summary>
        /// <para>Total data sent.</para>
        /// </summary>
        SentData = 0,
        /// <summary>
        /// <para>Total UDP packets sent.</para>
        /// </summary>
        SentPackets = 1,
        /// <summary>
        /// <para>Total data received.</para>
        /// </summary>
        ReceivedData = 2,
        /// <summary>
        /// <para>Total UDP packets received.</para>
        /// </summary>
        ReceivedPackets = 3
    }

    private static readonly System.Type CachedType = typeof(ENetConnection);

    private static readonly StringName NativeName = "ENetConnection";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public ENetConnection() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal ENetConnection(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal ENetConnection(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CreateHostBound, 1515002313ul);

    /// <summary>
    /// <para>Creates an ENetHost bound to the given <paramref name="bindAddress"/> and <paramref name="bindPort"/> that allows up to <paramref name="maxPeers"/> connected peers, each allocating up to <paramref name="maxChannels"/> channels, optionally limiting bandwidth to <paramref name="inBandwidth"/> and <paramref name="outBandwidth"/> (if greater than zero).</para>
    /// <para><b>Note:</b> It is necessary to create a host in both client and server in order to establish a connection.</para>
    /// </summary>
    public Error CreateHostBound(string bindAddress, int bindPort, int maxPeers = 32, int maxChannels = 0, int inBandwidth = 0, int outBandwidth = 0)
    {
        return (Error)NativeCalls.godot_icall_6_454(MethodBind0, GodotObject.GetPtr(this), bindAddress, bindPort, maxPeers, maxChannels, inBandwidth, outBandwidth);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CreateHost, 117198950ul);

    /// <summary>
    /// <para>Creates an ENetHost that allows up to <paramref name="maxPeers"/> connected peers, each allocating up to <paramref name="maxChannels"/> channels, optionally limiting bandwidth to <paramref name="inBandwidth"/> and <paramref name="outBandwidth"/> (if greater than zero).</para>
    /// <para>This method binds a random available dynamic UDP port on the host machine at the <i>unspecified</i> address. Use <see cref="Godot.ENetConnection.CreateHostBound(string, int, int, int, int, int)"/> to specify the address and port.</para>
    /// <para><b>Note:</b> It is necessary to create a host in both client and server in order to establish a connection.</para>
    /// </summary>
    public Error CreateHost(int maxPeers = 32, int maxChannels = 0, int inBandwidth = 0, int outBandwidth = 0)
    {
        return (Error)NativeCalls.godot_icall_4_455(MethodBind1, GodotObject.GetPtr(this), maxPeers, maxChannels, inBandwidth, outBandwidth);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Destroy, 3218959716ul);

    /// <summary>
    /// <para>Destroys the host and all resources associated with it.</para>
    /// </summary>
    public void Destroy()
    {
        NativeCalls.godot_icall_0_3(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ConnectToHost, 2171300490ul);

    /// <summary>
    /// <para>Initiates a connection to a foreign <paramref name="address"/> using the specified <paramref name="port"/> and allocating the requested <paramref name="channels"/>. Optional <paramref name="data"/> can be passed during connection in the form of a 32 bit integer.</para>
    /// <para><b>Note:</b> You must call either <see cref="Godot.ENetConnection.CreateHost(int, int, int, int)"/> or <see cref="Godot.ENetConnection.CreateHostBound(string, int, int, int, int, int)"/> on both ends before calling this method.</para>
    /// </summary>
    public ENetPacketPeer ConnectToHost(string address, int port, int channels = 0, int data = 0)
    {
        return (ENetPacketPeer)NativeCalls.godot_icall_4_456(MethodBind3, GodotObject.GetPtr(this), address, port, channels, data);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Service, 2402345344ul);

    /// <summary>
    /// <para>Waits for events on this connection and shuttles packets between the host and its peers, with the given <paramref name="timeout"/> (in milliseconds). The returned <see cref="Godot.Collections.Array"/> will have 4 elements. An <see cref="Godot.ENetConnection.EventType"/>, the <see cref="Godot.ENetPacketPeer"/> which generated the event, the event associated data (if any), the event associated channel (if any). If the generated event is <see cref="Godot.ENetConnection.EventType.Receive"/>, the received packet will be queued to the associated <see cref="Godot.ENetPacketPeer"/>.</para>
    /// <para>Call this function regularly to handle connections, disconnections, and to receive new packets.</para>
    /// <para><b>Note:</b> This method must be called on both ends involved in the event (sending and receiving hosts).</para>
    /// </summary>
    public Godot.Collections.Array Service(int timeout = 0)
    {
        return NativeCalls.godot_icall_1_457(MethodBind4, GodotObject.GetPtr(this), timeout);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Flush, 3218959716ul);

    /// <summary>
    /// <para>Sends any queued packets on the host specified to its designated peers.</para>
    /// </summary>
    public void Flush()
    {
        NativeCalls.godot_icall_0_3(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BandwidthLimit, 2302169788ul);

    /// <summary>
    /// <para>Adjusts the bandwidth limits of a host.</para>
    /// </summary>
    public void BandwidthLimit(int inBandwidth = 0, int outBandwidth = 0)
    {
        NativeCalls.godot_icall_2_59(MethodBind6, GodotObject.GetPtr(this), inBandwidth, outBandwidth);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ChannelLimit, 1286410249ul);

    /// <summary>
    /// <para>Limits the maximum allowed channels of future incoming connections.</para>
    /// </summary>
    public void ChannelLimit(int limit)
    {
        NativeCalls.godot_icall_1_38(MethodBind7, GodotObject.GetPtr(this), limit);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Broadcast, 2772371345ul);

    /// <summary>
    /// <para>Queues a <paramref name="packet"/> to be sent to all peers associated with the host over the specified <paramref name="channel"/>. See <see cref="Godot.ENetPacketPeer"/> <c>FLAG_*</c> constants for available packet flags.</para>
    /// </summary>
    public void Broadcast(int channel, byte[] packet, int flags)
    {
        NativeCalls.godot_icall_3_458(MethodBind8, GodotObject.GetPtr(this), channel, packet, flags);
    }

    /// <summary>
    /// <para>Queues a <paramref name="packet"/> to be sent to all peers associated with the host over the specified <paramref name="channel"/>. See <see cref="Godot.ENetPacketPeer"/> <c>FLAG_*</c> constants for available packet flags.</para>
    /// </summary>
    public void Broadcast(int channel, ReadOnlySpan<byte> packet, int flags)
    {
        NativeCalls.godot_icall_3_458(MethodBind8, GodotObject.GetPtr(this), channel, packet, flags);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Compress, 2660215187ul);

    /// <summary>
    /// <para>Sets the compression method used for network packets. These have different tradeoffs of compression speed versus bandwidth, you may need to test which one works best for your use case if you use compression at all.</para>
    /// <para><b>Note:</b> Most games' network design involve sending many small packets frequently (smaller than 4 KB each). If in doubt, it is recommended to keep the default compression algorithm as it works best on these small packets.</para>
    /// <para><b>Note:</b> The compression mode must be set to the same value on both the server and all its clients. Clients will fail to connect if the compression mode set on the client differs from the one set on the server.</para>
    /// </summary>
    public void Compress(ENetConnection.CompressionMode mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind9, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DtlsServerSetup, 1262296096ul);

    /// <summary>
    /// <para>Configure this ENetHost to use the custom Godot extension allowing DTLS encryption for ENet servers. Call this right after <see cref="Godot.ENetConnection.CreateHostBound(string, int, int, int, int, int)"/> to have ENet expect peers to connect using DTLS. See <see cref="Godot.TlsOptions.Server(CryptoKey, X509Certificate)"/>.</para>
    /// </summary>
    public Error DtlsServerSetup(TlsOptions serverOptions)
    {
        return (Error)NativeCalls.godot_icall_1_371(MethodBind10, GodotObject.GetPtr(this), GodotObject.GetPtr(serverOptions));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DtlsClientSetup, 1966198364ul);

    /// <summary>
    /// <para>Configure this ENetHost to use the custom Godot extension allowing DTLS encryption for ENet clients. Call this before <see cref="Godot.ENetConnection.ConnectToHost(string, int, int, int)"/> to have ENet connect using DTLS validating the server certificate against <paramref name="hostname"/>. You can pass the optional <paramref name="clientOptions"/> parameter to customize the trusted certification authorities, or disable the common name verification. See <see cref="Godot.TlsOptions.Client(X509Certificate, string)"/> and <see cref="Godot.TlsOptions.ClientUnsafe(X509Certificate)"/>.</para>
    /// </summary>
    public Error DtlsClientSetup(string hostname, TlsOptions clientOptions = null)
    {
        return (Error)NativeCalls.godot_icall_2_459(MethodBind11, GodotObject.GetPtr(this), hostname, GodotObject.GetPtr(clientOptions));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RefuseNewConnections, 2586408642ul);

    /// <summary>
    /// <para>Configures the DTLS server to automatically drop new connections.</para>
    /// <para><b>Note:</b> This method is only relevant after calling <see cref="Godot.ENetConnection.DtlsServerSetup(TlsOptions)"/>.</para>
    /// </summary>
    public void RefuseNewConnections(bool refuse)
    {
        NativeCalls.godot_icall_1_14(MethodBind12, GodotObject.GetPtr(this), refuse.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PopStatistic, 2166904170ul);

    /// <summary>
    /// <para>Returns and resets host statistics.</para>
    /// </summary>
    public double PopStatistic(ENetConnection.HostStatistic statistic)
    {
        return NativeCalls.godot_icall_1_460(MethodBind13, GodotObject.GetPtr(this), (int)statistic);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMaxChannels, 3905245786ul);

    /// <summary>
    /// <para>Returns the maximum number of channels allowed for connected peers.</para>
    /// </summary>
    public int GetMaxChannels()
    {
        return NativeCalls.godot_icall_0_39(MethodBind14, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLocalPort, 3905245786ul);

    /// <summary>
    /// <para>Returns the local port to which this peer is bound.</para>
    /// </summary>
    public int GetLocalPort()
    {
        return NativeCalls.godot_icall_0_39(MethodBind15, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPeers, 2915620761ul);

    /// <summary>
    /// <para>Returns the list of peers associated with this host.</para>
    /// <para><b>Note:</b> This list might include some peers that are not fully connected or are still being disconnected.</para>
    /// </summary>
    public Godot.Collections.Array<ENetPacketPeer> GetPeers()
    {
        return new Godot.Collections.Array<ENetPacketPeer>(NativeCalls.godot_icall_0_120(MethodBind16, GodotObject.GetPtr(this)));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SocketSend, 1100646812ul);

    /// <summary>
    /// <para>Sends a <paramref name="packet"/> toward a destination from the address and port currently bound by this ENetConnection instance.</para>
    /// <para>This is useful as it serves to establish entries in NAT routing tables on all devices between this bound instance and the public facing internet, allowing a prospective client's connection packets to be routed backward through the NAT device(s) between the public internet and this host.</para>
    /// <para>This requires forward knowledge of a prospective client's address and communication port as seen by the public internet - after any NAT devices have handled their connection request. This information can be obtained by a <a href="https://en.wikipedia.org/wiki/STUN">STUN</a> service, and must be handed off to your host by an entity that is not the prospective client. This will never work for a client behind a Symmetric NAT due to the nature of the Symmetric NAT routing algorithm, as their IP and Port cannot be known beforehand.</para>
    /// </summary>
    public void SocketSend(string destinationAddress, int destinationPort, byte[] packet)
    {
        NativeCalls.godot_icall_3_461(MethodBind17, GodotObject.GetPtr(this), destinationAddress, destinationPort, packet);
    }

    /// <summary>
    /// <para>Sends a <paramref name="packet"/> toward a destination from the address and port currently bound by this ENetConnection instance.</para>
    /// <para>This is useful as it serves to establish entries in NAT routing tables on all devices between this bound instance and the public facing internet, allowing a prospective client's connection packets to be routed backward through the NAT device(s) between the public internet and this host.</para>
    /// <para>This requires forward knowledge of a prospective client's address and communication port as seen by the public internet - after any NAT devices have handled their connection request. This information can be obtained by a <a href="https://en.wikipedia.org/wiki/STUN">STUN</a> service, and must be handed off to your host by an entity that is not the prospective client. This will never work for a client behind a Symmetric NAT due to the nature of the Symmetric NAT routing algorithm, as their IP and Port cannot be known beforehand.</para>
    /// </summary>
    public void SocketSend(string destinationAddress, int destinationPort, ReadOnlySpan<byte> packet)
    {
        NativeCalls.godot_icall_3_461(MethodBind17, GodotObject.GetPtr(this), destinationAddress, destinationPort, packet);
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
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : RefCounted.MethodName
    {
        /// <summary>
        /// Cached name for the 'create_host_bound' method.
        /// </summary>
        public static readonly StringName CreateHostBound = "create_host_bound";
        /// <summary>
        /// Cached name for the 'create_host' method.
        /// </summary>
        public static readonly StringName CreateHost = "create_host";
        /// <summary>
        /// Cached name for the 'destroy' method.
        /// </summary>
        public static readonly StringName Destroy = "destroy";
        /// <summary>
        /// Cached name for the 'connect_to_host' method.
        /// </summary>
        public static readonly StringName ConnectToHost = "connect_to_host";
        /// <summary>
        /// Cached name for the 'service' method.
        /// </summary>
        public static readonly StringName Service = "service";
        /// <summary>
        /// Cached name for the 'flush' method.
        /// </summary>
        public static readonly StringName Flush = "flush";
        /// <summary>
        /// Cached name for the 'bandwidth_limit' method.
        /// </summary>
        public static readonly StringName BandwidthLimit = "bandwidth_limit";
        /// <summary>
        /// Cached name for the 'channel_limit' method.
        /// </summary>
        public static readonly StringName ChannelLimit = "channel_limit";
        /// <summary>
        /// Cached name for the 'broadcast' method.
        /// </summary>
        public static readonly StringName Broadcast = "broadcast";
        /// <summary>
        /// Cached name for the 'compress' method.
        /// </summary>
        public static readonly StringName Compress = "compress";
        /// <summary>
        /// Cached name for the 'dtls_server_setup' method.
        /// </summary>
        public static readonly StringName DtlsServerSetup = "dtls_server_setup";
        /// <summary>
        /// Cached name for the 'dtls_client_setup' method.
        /// </summary>
        public static readonly StringName DtlsClientSetup = "dtls_client_setup";
        /// <summary>
        /// Cached name for the 'refuse_new_connections' method.
        /// </summary>
        public static readonly StringName RefuseNewConnections = "refuse_new_connections";
        /// <summary>
        /// Cached name for the 'pop_statistic' method.
        /// </summary>
        public static readonly StringName PopStatistic = "pop_statistic";
        /// <summary>
        /// Cached name for the 'get_max_channels' method.
        /// </summary>
        public static readonly StringName GetMaxChannels = "get_max_channels";
        /// <summary>
        /// Cached name for the 'get_local_port' method.
        /// </summary>
        public static readonly StringName GetLocalPort = "get_local_port";
        /// <summary>
        /// Cached name for the 'get_peers' method.
        /// </summary>
        public static readonly StringName GetPeers = "get_peers";
        /// <summary>
        /// Cached name for the 'socket_send' method.
        /// </summary>
        public static readonly StringName SocketSend = "socket_send";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : RefCounted.SignalName
    {
    }
}
