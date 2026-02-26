namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A MultiplayerPeer implementation that should be passed to <see cref="Godot.MultiplayerApi.MultiplayerPeer"/> after being initialized as either a client, server, or mesh. Events can then be handled by connecting to <see cref="Godot.MultiplayerApi"/> signals. See <see cref="Godot.ENetConnection"/> for more information on the ENet library wrapper.</para>
/// <para><b>Note:</b> ENet only uses UDP, not TCP. When forwarding the server port to make your server accessible on the public Internet, you only need to forward the server port in UDP. You can use the <see cref="Godot.Upnp"/> class to try to forward the server port automatically when starting the server.</para>
/// </summary>
public partial class ENetMultiplayerPeer : MultiplayerPeer
{
    /// <summary>
    /// <para>The underlying <see cref="Godot.ENetConnection"/> created after <see cref="Godot.ENetMultiplayerPeer.CreateClient(string, int, int, int, int, int)"/> and <see cref="Godot.ENetMultiplayerPeer.CreateServer(int, int, int, int, int)"/>.</para>
    /// </summary>
    public ENetConnection Host
    {
        get
        {
            return GetHost();
        }
    }

    private static readonly System.Type CachedType = typeof(ENetMultiplayerPeer);

    private static readonly StringName NativeName = "ENetMultiplayerPeer";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public ENetMultiplayerPeer() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal ENetMultiplayerPeer(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal ENetMultiplayerPeer(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CreateServer, 2917761309ul);

    /// <summary>
    /// <para>Create server that listens to connections via <paramref name="port"/>. The port needs to be an available, unused port between 0 and 65535. Note that ports below 1024 are privileged and may require elevated permissions depending on the platform. To change the interface the server listens on, use <see cref="Godot.ENetMultiplayerPeer.SetBindIP(string)"/>. The default IP is the wildcard <c>"*"</c>, which listens on all available interfaces. <paramref name="maxClients"/> is the maximum number of clients that are allowed at once, any number up to 4095 may be used, although the achievable number of simultaneous clients may be far lower and depends on the application. For additional details on the bandwidth parameters, see <see cref="Godot.ENetMultiplayerPeer.CreateClient(string, int, int, int, int, int)"/>. Returns <see cref="Godot.Error.Ok"/> if a server was created, <see cref="Godot.Error.AlreadyInUse"/> if this ENetMultiplayerPeer instance already has an open connection (in which case you need to call <see cref="Godot.MultiplayerPeer.Close()"/> first) or <see cref="Godot.Error.CantCreate"/> if the server could not be created.</para>
    /// </summary>
    public Error CreateServer(int port, int maxClients = 32, int maxChannels = 0, int inBandwidth = 0, int outBandwidth = 0)
    {
        return (Error)NativeCalls.godot_icall_5_462(MethodBind0, GodotObject.GetPtr(this), port, maxClients, maxChannels, inBandwidth, outBandwidth);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CreateClient, 2327163476ul);

    /// <summary>
    /// <para>Create client that connects to a server at <paramref name="address"/> using specified <paramref name="port"/>. The given address needs to be either a fully qualified domain name (e.g. <c>"www.example.com"</c>) or an IP address in IPv4 or IPv6 format (e.g. <c>"192.168.1.1"</c>). The <paramref name="port"/> is the port the server is listening on. The <paramref name="channelCount"/> parameter can be used to specify the number of ENet channels allocated for the connection. The <paramref name="inBandwidth"/> and <paramref name="outBandwidth"/> parameters can be used to limit the incoming and outgoing bandwidth to the given number of bytes per second. The default of 0 means unlimited bandwidth. Note that ENet will strategically drop packets on specific sides of a connection between peers to ensure the peer's bandwidth is not overwhelmed. The bandwidth parameters also determine the window size of a connection which limits the amount of reliable packets that may be in transit at any given time. Returns <see cref="Godot.Error.Ok"/> if a client was created, <see cref="Godot.Error.AlreadyInUse"/> if this ENetMultiplayerPeer instance already has an open connection (in which case you need to call <see cref="Godot.MultiplayerPeer.Close()"/> first) or <see cref="Godot.Error.CantCreate"/> if the client could not be created. If <paramref name="localPort"/> is specified, the client will also listen to the given port; this is useful for some NAT traversal techniques.</para>
    /// </summary>
    public Error CreateClient(string address, int port, int channelCount = 0, int inBandwidth = 0, int outBandwidth = 0, int localPort = 0)
    {
        return (Error)NativeCalls.godot_icall_6_454(MethodBind1, GodotObject.GetPtr(this), address, port, channelCount, inBandwidth, outBandwidth, localPort);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CreateMesh, 844576869ul);

    /// <summary>
    /// <para>Initialize this <see cref="Godot.MultiplayerPeer"/> in mesh mode. The provided <paramref name="uniqueId"/> will be used as the local peer network unique ID once assigned as the <see cref="Godot.MultiplayerApi.MultiplayerPeer"/>. In the mesh configuration you will need to set up each new peer manually using <see cref="Godot.ENetConnection"/> before calling <see cref="Godot.ENetMultiplayerPeer.AddMeshPeer(int, ENetConnection)"/>. While this technique is more advanced, it allows for better control over the connection process (e.g. when dealing with NAT punch-through) and for better distribution of the network load (which would otherwise be more taxing on the server).</para>
    /// </summary>
    public Error CreateMesh(int uniqueId)
    {
        return (Error)NativeCalls.godot_icall_1_60(MethodBind2, GodotObject.GetPtr(this), uniqueId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddMeshPeer, 1293458335ul);

    /// <summary>
    /// <para>Add a new remote peer with the given <paramref name="peerId"/> connected to the given <paramref name="host"/>.</para>
    /// <para><b>Note:</b> The <paramref name="host"/> must have exactly one peer in the <see cref="Godot.ENetPacketPeer.PeerState.Connected"/> state.</para>
    /// </summary>
    public Error AddMeshPeer(int peerId, ENetConnection host)
    {
        return (Error)NativeCalls.godot_icall_2_463(MethodBind3, GodotObject.GetPtr(this), peerId, GodotObject.GetPtr(host));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBindIP, 83702148ul);

    /// <summary>
    /// <para>The IP used when creating a server. This is set to the wildcard <c>"*"</c> by default, which binds to all available interfaces. The given IP needs to be in IPv4 or IPv6 address format, for example: <c>"192.168.1.1"</c>.</para>
    /// </summary>
    public void SetBindIP(string iP)
    {
        NativeCalls.godot_icall_1_57(MethodBind4, GodotObject.GetPtr(this), iP);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetHost, 4103238886ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public ENetConnection GetHost()
    {
        return (ENetConnection)NativeCalls.godot_icall_0_63(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPeer, 3793311544ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.ENetPacketPeer"/> associated to the given <paramref name="id"/>.</para>
    /// </summary>
    public ENetPacketPeer GetPeer(int id)
    {
        return (ENetPacketPeer)NativeCalls.godot_icall_1_71(MethodBind6, GodotObject.GetPtr(this), id);
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
    public new class PropertyName : MultiplayerPeer.PropertyName
    {
        /// <summary>
        /// Cached name for the 'host' property.
        /// </summary>
        public static readonly StringName Host = "host";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : MultiplayerPeer.MethodName
    {
        /// <summary>
        /// Cached name for the 'create_server' method.
        /// </summary>
        public static readonly StringName CreateServer = "create_server";
        /// <summary>
        /// Cached name for the 'create_client' method.
        /// </summary>
        public static readonly StringName CreateClient = "create_client";
        /// <summary>
        /// Cached name for the 'create_mesh' method.
        /// </summary>
        public static readonly StringName CreateMesh = "create_mesh";
        /// <summary>
        /// Cached name for the 'add_mesh_peer' method.
        /// </summary>
        public static readonly StringName AddMeshPeer = "add_mesh_peer";
        /// <summary>
        /// Cached name for the 'set_bind_ip' method.
        /// </summary>
        public static readonly StringName SetBindIP = "set_bind_ip";
        /// <summary>
        /// Cached name for the 'get_host' method.
        /// </summary>
        public static readonly StringName GetHost = "get_host";
        /// <summary>
        /// Cached name for the 'get_peer' method.
        /// </summary>
        public static readonly StringName GetPeer = "get_peer";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : MultiplayerPeer.SignalName
    {
    }
}
