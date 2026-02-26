namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Base class for high-level multiplayer API implementations. See also <see cref="Godot.MultiplayerPeer"/>.</para>
/// <para>By default, <see cref="Godot.SceneTree"/> has a reference to an implementation of this class and uses it to provide multiplayer capabilities (i.e. RPCs) across the whole scene.</para>
/// <para>It is possible to override the MultiplayerAPI instance used by specific tree branches by calling the <see cref="Godot.SceneTree.SetMultiplayer(MultiplayerApi, NodePath)"/> method, effectively allowing to run both client and server in the same scene.</para>
/// <para>It is also possible to extend or replace the default implementation via scripting or native extensions. See <see cref="Godot.MultiplayerApiExtension"/> for details about extensions, <see cref="Godot.SceneMultiplayer"/> for the details about the default implementation.</para>
/// </summary>
[GodotClassName("MultiplayerAPI")]
public partial class MultiplayerApi : RefCounted
{
    public enum RpcMode : long
    {
        /// <summary>
        /// <para>Used with <see cref="Godot.Node.RpcConfig(StringName, Variant)"/> to disable a method or property for all RPC calls, making it unavailable. Default for all methods.</para>
        /// </summary>
        Disabled = 0,
        /// <summary>
        /// <para>Used with <see cref="Godot.Node.RpcConfig(StringName, Variant)"/> to set a method to be callable remotely by any peer. Analogous to the <c>@rpc("any_peer")</c> annotation. Calls are accepted from all remote peers, no matter if they are node's authority or not.</para>
        /// </summary>
        AnyPeer = 1,
        /// <summary>
        /// <para>Used with <see cref="Godot.Node.RpcConfig(StringName, Variant)"/> to set a method to be callable remotely only by the current multiplayer authority (which is the server by default). Analogous to the <c>@rpc("authority")</c> annotation. See <see cref="Godot.Node.SetMultiplayerAuthority(int, bool)"/>.</para>
        /// </summary>
        Authority = 2
    }

    /// <summary>
    /// <para>The peer object to handle the RPC system (effectively enabling networking when set). Depending on the peer itself, the MultiplayerAPI will become a network server (check with <see cref="Godot.MultiplayerApi.IsServer()"/>) and will set root node's network mode to authority, or it will become a regular client peer. All child nodes are set to inherit the network mode by default. Handling of networking-related events (connection, disconnection, new clients) is done by connecting to MultiplayerAPI's signals.</para>
    /// </summary>
    public MultiplayerPeer MultiplayerPeer
    {
        get
        {
            return GetMultiplayerPeer();
        }
        set
        {
            SetMultiplayerPeer(value);
        }
    }

    private static readonly System.Type CachedType = typeof(MultiplayerApi);

    private static readonly StringName NativeName = "MultiplayerAPI";

    internal MultiplayerApi() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal MultiplayerApi(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal MultiplayerApi(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasMultiplayerPeer, 2240911060ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if there is a <see cref="Godot.MultiplayerApi.MultiplayerPeer"/> set.</para>
    /// </summary>
    public bool HasMultiplayerPeer()
    {
        return NativeCalls.godot_icall_0_15(MethodBind0, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMultiplayerPeer, 3223692825ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public MultiplayerPeer GetMultiplayerPeer()
    {
        return (MultiplayerPeer)NativeCalls.godot_icall_0_63(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMultiplayerPeer, 3694835298ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMultiplayerPeer(MultiplayerPeer peer)
    {
        NativeCalls.godot_icall_1_56(MethodBind2, GodotObject.GetPtr(this), GodotObject.GetPtr(peer));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetUniqueId, 2455072627ul);

    /// <summary>
    /// <para>Returns the unique peer ID of this MultiplayerAPI's <see cref="Godot.MultiplayerApi.MultiplayerPeer"/>.</para>
    /// </summary>
    public int GetUniqueId()
    {
        return NativeCalls.godot_icall_0_39(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsServer, 2240911060ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if this MultiplayerAPI's <see cref="Godot.MultiplayerApi.MultiplayerPeer"/> is valid and in server mode (listening for connections).</para>
    /// </summary>
    public bool IsServer()
    {
        return NativeCalls.godot_icall_0_15(MethodBind4, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRemoteSenderId, 2455072627ul);

    /// <summary>
    /// <para>Returns the sender's peer ID for the RPC currently being executed.</para>
    /// <para><b>Note:</b> This method returns <c>0</c> when called outside of an RPC. As such, the original peer ID may be lost when code execution is delayed (such as with GDScript's <c>await</c> keyword).</para>
    /// </summary>
    public int GetRemoteSenderId()
    {
        return NativeCalls.godot_icall_0_39(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Poll, 166280745ul);

    /// <summary>
    /// <para>Method used for polling the MultiplayerAPI. You only need to worry about this if you set <see cref="Godot.SceneTree.MultiplayerPoll"/> to <see langword="false"/>. By default, <see cref="Godot.SceneTree"/> will poll its MultiplayerAPI(s) for you.</para>
    /// <para><b>Note:</b> This method results in RPCs being called, so they will be executed in the same context of this function (e.g. <c>_process</c>, <c>physics</c>, <see cref="Godot.GodotThread"/>).</para>
    /// </summary>
    public Error Poll()
    {
        return (Error)NativeCalls.godot_icall_0_39(MethodBind6, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Rpc, 2077486355ul);

    /// <summary>
    /// <para>Sends an RPC to the target <paramref name="peer"/>. The given <paramref name="method"/> will be called on the remote <paramref name="object"/> with the provided <paramref name="arguments"/>. The RPC may also be called locally depending on the implementation and RPC configuration. See <see cref="Godot.Node.Rpc(StringName, Variant[])"/> and <see cref="Godot.Node.RpcConfig(StringName, Variant)"/>.</para>
    /// <para><b>Note:</b> Prefer using <see cref="Godot.Node.Rpc(StringName, Variant[])"/>, <see cref="Godot.Node.RpcId(long, StringName, Variant[])"/>, or <c>my_method.rpc(peer, arg1, arg2, ...)</c> (in GDScript), since they are faster. This method is mostly useful in conjunction with <see cref="Godot.MultiplayerApiExtension"/> when extending or replacing the multiplayer capabilities.</para>
    /// </summary>
    public Error Rpc(int peer, GodotObject @object, StringName method, Godot.Collections.Array arguments = null)
    {
        return (Error)NativeCalls.godot_icall_4_805(MethodBind7, GodotObject.GetPtr(this), peer, GodotObject.GetPtr(@object), (godot_string_name)(method?.NativeValue ?? default), (godot_array)(arguments ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ObjectConfigurationAdd, 1171879464ul);

    /// <summary>
    /// <para>Notifies the MultiplayerAPI of a new <paramref name="configuration"/> for the given <paramref name="object"/>. This method is used internally by <see cref="Godot.SceneTree"/> to configure the root path for this MultiplayerAPI (passing <see langword="null"/> and a valid <see cref="Godot.NodePath"/> as <paramref name="configuration"/>). This method can be further used by MultiplayerAPI implementations to provide additional features, refer to specific implementation (e.g. <see cref="Godot.SceneMultiplayer"/>) for details on how they use it.</para>
    /// <para><b>Note:</b> This method is mostly relevant when extending or overriding the MultiplayerAPI behavior via <see cref="Godot.MultiplayerApiExtension"/>.</para>
    /// </summary>
    public Error ObjectConfigurationAdd(GodotObject @object, Variant configuration)
    {
        return (Error)NativeCalls.godot_icall_2_806(MethodBind8, GodotObject.GetPtr(this), GodotObject.GetPtr(@object), configuration);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ObjectConfigurationRemove, 1171879464ul);

    /// <summary>
    /// <para>Notifies the MultiplayerAPI to remove a <paramref name="configuration"/> for the given <paramref name="object"/>. This method is used internally by <see cref="Godot.SceneTree"/> to configure the root path for this MultiplayerAPI (passing <see langword="null"/> and an empty <see cref="Godot.NodePath"/> as <paramref name="configuration"/>). This method can be further used by MultiplayerAPI implementations to provide additional features, refer to specific implementation (e.g. <see cref="Godot.SceneMultiplayer"/>) for details on how they use it.</para>
    /// <para><b>Note:</b> This method is mostly relevant when extending or overriding the MultiplayerAPI behavior via <see cref="Godot.MultiplayerApiExtension"/>.</para>
    /// </summary>
    public Error ObjectConfigurationRemove(GodotObject @object, Variant configuration)
    {
        return (Error)NativeCalls.godot_icall_2_806(MethodBind9, GodotObject.GetPtr(this), GodotObject.GetPtr(@object), configuration);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPeers, 969006518ul);

    /// <summary>
    /// <para>Returns the peer IDs of all connected peers of this MultiplayerAPI's <see cref="Godot.MultiplayerApi.MultiplayerPeer"/>.</para>
    /// </summary>
    public int[] GetPeers()
    {
        return NativeCalls.godot_icall_0_151(MethodBind10, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDefaultInterface, 3304788590ul);

    /// <summary>
    /// <para>Sets the default MultiplayerAPI implementation class. This method can be used by modules and extensions to configure which implementation will be used by <see cref="Godot.SceneTree"/> when the engine starts.</para>
    /// </summary>
    public static void SetDefaultInterface(StringName interfaceName)
    {
        NativeCalls.godot_icall_1_807(MethodBind11, (godot_string_name)(interfaceName?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDefaultInterface, 2737447660ul);

    /// <summary>
    /// <para>Returns the default MultiplayerAPI implementation class name. This is usually <c>"SceneMultiplayer"</c> when <see cref="Godot.SceneMultiplayer"/> is available. See <see cref="Godot.MultiplayerApi.SetDefaultInterface(StringName)"/>.</para>
    /// </summary>
    public static StringName GetDefaultInterface()
    {
        return NativeCalls.godot_icall_0_808(MethodBind12);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CreateDefaultInterface, 3294156723ul);

    /// <summary>
    /// <para>Returns a new instance of the default MultiplayerAPI.</para>
    /// </summary>
    public static MultiplayerApi CreateDefaultInterface()
    {
        return (MultiplayerApi)NativeCalls.godot_icall_0_809(MethodBind13);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.MultiplayerApi.PeerConnected"/> event of a <see cref="Godot.MultiplayerApi"/> class.
    /// </summary>
    public delegate void PeerConnectedEventHandler(long id);

    private static void PeerConnectedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((PeerConnectedEventHandler)delegateObj)(VariantUtils.ConvertTo<long>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when this MultiplayerAPI's <see cref="Godot.MultiplayerApi.MultiplayerPeer"/> connects with a new peer. ID is the peer ID of the new peer. Clients get notified when other clients connect to the same server. Upon connecting to a server, a client also receives this signal for the server (with ID being 1).</para>
    /// </summary>
    public unsafe event PeerConnectedEventHandler PeerConnected
    {
        add => Connect(SignalName.PeerConnected, Callable.CreateWithUnsafeTrampoline(value, &PeerConnectedTrampoline));
        remove => Disconnect(SignalName.PeerConnected, Callable.CreateWithUnsafeTrampoline(value, &PeerConnectedTrampoline));
    }

    protected void EmitSignalPeerConnected(long id)
    {
        EmitSignal(SignalName.PeerConnected, id);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.MultiplayerApi.PeerDisconnected"/> event of a <see cref="Godot.MultiplayerApi"/> class.
    /// </summary>
    public delegate void PeerDisconnectedEventHandler(long id);

    private static void PeerDisconnectedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((PeerDisconnectedEventHandler)delegateObj)(VariantUtils.ConvertTo<long>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when this MultiplayerAPI's <see cref="Godot.MultiplayerApi.MultiplayerPeer"/> disconnects from a peer. Clients get notified when other clients disconnect from the same server.</para>
    /// </summary>
    public unsafe event PeerDisconnectedEventHandler PeerDisconnected
    {
        add => Connect(SignalName.PeerDisconnected, Callable.CreateWithUnsafeTrampoline(value, &PeerDisconnectedTrampoline));
        remove => Disconnect(SignalName.PeerDisconnected, Callable.CreateWithUnsafeTrampoline(value, &PeerDisconnectedTrampoline));
    }

    protected void EmitSignalPeerDisconnected(long id)
    {
        EmitSignal(SignalName.PeerDisconnected, id);
    }

    /// <summary>
    /// <para>Emitted when this MultiplayerAPI's <see cref="Godot.MultiplayerApi.MultiplayerPeer"/> successfully connected to a server. Only emitted on clients.</para>
    /// </summary>
    public event Action ConnectedToServer
    {
        add => Connect(SignalName.ConnectedToServer, Callable.From(value));
        remove => Disconnect(SignalName.ConnectedToServer, Callable.From(value));
    }

    protected void EmitSignalConnectedToServer()
    {
        EmitSignal(SignalName.ConnectedToServer);
    }

    /// <summary>
    /// <para>Emitted when this MultiplayerAPI's <see cref="Godot.MultiplayerApi.MultiplayerPeer"/> fails to establish a connection to a server. Only emitted on clients.</para>
    /// </summary>
    public event Action ConnectionFailed
    {
        add => Connect(SignalName.ConnectionFailed, Callable.From(value));
        remove => Disconnect(SignalName.ConnectionFailed, Callable.From(value));
    }

    protected void EmitSignalConnectionFailed()
    {
        EmitSignal(SignalName.ConnectionFailed);
    }

    /// <summary>
    /// <para>Emitted when this MultiplayerAPI's <see cref="Godot.MultiplayerApi.MultiplayerPeer"/> disconnects from server. Only emitted on clients.</para>
    /// </summary>
    public event Action ServerDisconnected
    {
        add => Connect(SignalName.ServerDisconnected, Callable.From(value));
        remove => Disconnect(SignalName.ServerDisconnected, Callable.From(value));
    }

    protected void EmitSignalServerDisconnected()
    {
        EmitSignal(SignalName.ServerDisconnected);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_peer_connected = "PeerConnected";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_peer_disconnected = "PeerDisconnected";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_connected_to_server = "ConnectedToServer";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_connection_failed = "ConnectionFailed";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_server_disconnected = "ServerDisconnected";

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
        if (signal == SignalName.PeerConnected)
        {
            if (HasGodotClassSignal(SignalProxyName_peer_connected.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.PeerDisconnected)
        {
            if (HasGodotClassSignal(SignalProxyName_peer_disconnected.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.ConnectedToServer)
        {
            if (HasGodotClassSignal(SignalProxyName_connected_to_server.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.ConnectionFailed)
        {
            if (HasGodotClassSignal(SignalProxyName_connection_failed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.ServerDisconnected)
        {
            if (HasGodotClassSignal(SignalProxyName_server_disconnected.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        return base.HasGodotClassSignal(signal);
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : RefCounted.PropertyName
    {
        /// <summary>
        /// Cached name for the 'multiplayer_peer' property.
        /// </summary>
        public static readonly StringName MultiplayerPeer = "multiplayer_peer";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : RefCounted.MethodName
    {
        /// <summary>
        /// Cached name for the 'has_multiplayer_peer' method.
        /// </summary>
        public static readonly StringName HasMultiplayerPeer = "has_multiplayer_peer";
        /// <summary>
        /// Cached name for the 'get_multiplayer_peer' method.
        /// </summary>
        public static readonly StringName GetMultiplayerPeer = "get_multiplayer_peer";
        /// <summary>
        /// Cached name for the 'set_multiplayer_peer' method.
        /// </summary>
        public static readonly StringName SetMultiplayerPeer = "set_multiplayer_peer";
        /// <summary>
        /// Cached name for the 'get_unique_id' method.
        /// </summary>
        public static readonly StringName GetUniqueId = "get_unique_id";
        /// <summary>
        /// Cached name for the 'is_server' method.
        /// </summary>
        public static readonly StringName IsServer = "is_server";
        /// <summary>
        /// Cached name for the 'get_remote_sender_id' method.
        /// </summary>
        public static readonly StringName GetRemoteSenderId = "get_remote_sender_id";
        /// <summary>
        /// Cached name for the 'poll' method.
        /// </summary>
        public static readonly StringName Poll = "poll";
        /// <summary>
        /// Cached name for the 'rpc' method.
        /// </summary>
        public static readonly StringName Rpc = "rpc";
        /// <summary>
        /// Cached name for the 'object_configuration_add' method.
        /// </summary>
        public static readonly StringName ObjectConfigurationAdd = "object_configuration_add";
        /// <summary>
        /// Cached name for the 'object_configuration_remove' method.
        /// </summary>
        public static readonly StringName ObjectConfigurationRemove = "object_configuration_remove";
        /// <summary>
        /// Cached name for the 'get_peers' method.
        /// </summary>
        public static readonly StringName GetPeers = "get_peers";
        /// <summary>
        /// Cached name for the 'set_default_interface' method.
        /// </summary>
        public static readonly StringName SetDefaultInterface = "set_default_interface";
        /// <summary>
        /// Cached name for the 'get_default_interface' method.
        /// </summary>
        public static readonly StringName GetDefaultInterface = "get_default_interface";
        /// <summary>
        /// Cached name for the 'create_default_interface' method.
        /// </summary>
        public static readonly StringName CreateDefaultInterface = "create_default_interface";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : RefCounted.SignalName
    {
        /// <summary>
        /// Cached name for the 'peer_connected' signal.
        /// </summary>
        public static readonly StringName PeerConnected = "peer_connected";
        /// <summary>
        /// Cached name for the 'peer_disconnected' signal.
        /// </summary>
        public static readonly StringName PeerDisconnected = "peer_disconnected";
        /// <summary>
        /// Cached name for the 'connected_to_server' signal.
        /// </summary>
        public static readonly StringName ConnectedToServer = "connected_to_server";
        /// <summary>
        /// Cached name for the 'connection_failed' signal.
        /// </summary>
        public static readonly StringName ConnectionFailed = "connection_failed";
        /// <summary>
        /// Cached name for the 'server_disconnected' signal.
        /// </summary>
        public static readonly StringName ServerDisconnected = "server_disconnected";
    }
}
