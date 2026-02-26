namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This class is the default implementation of <see cref="Godot.MultiplayerApi"/>, used to provide multiplayer functionalities in Godot Engine.</para>
/// <para>This implementation supports RPCs via <see cref="Godot.Node.Rpc(StringName, Variant[])"/> and <see cref="Godot.Node.RpcId(long, StringName, Variant[])"/> and requires <see cref="Godot.MultiplayerApi.Rpc(int, GodotObject, StringName, Godot.Collections.Array)"/> to be passed a <see cref="Godot.Node"/> (it will fail for other object types).</para>
/// <para>This implementation additionally provide <see cref="Godot.SceneTree"/> replication via the <see cref="Godot.MultiplayerSpawner"/> and <see cref="Godot.MultiplayerSynchronizer"/> nodes, and the <see cref="Godot.SceneReplicationConfig"/> resource.</para>
/// <para><b>Note:</b> The high-level multiplayer API protocol is an implementation detail and isn't meant to be used by non-Godot servers. It may change without notice.</para>
/// <para><b>Note:</b> When exporting to Android, make sure to enable the <c>INTERNET</c> permission in the Android export preset before exporting the project or using one-click deploy. Otherwise, network communication of any kind will be blocked by Android.</para>
/// </summary>
public partial class SceneMultiplayer : MultiplayerApi
{
    /// <summary>
    /// <para>The root path to use for RPCs and replication. Instead of an absolute path, a relative path will be used to find the node upon which the RPC should be executed.</para>
    /// <para>This effectively allows to have different branches of the scene tree to be managed by different MultiplayerAPI, allowing for example to run both client and server in the same scene.</para>
    /// </summary>
    public NodePath RootPath
    {
        get
        {
            return GetRootPath();
        }
        set
        {
            SetRootPath(value);
        }
    }

    /// <summary>
    /// <para>The callback to execute when receiving authentication data sent via <see cref="Godot.SceneMultiplayer.SendAuth(int, byte[])"/>. If the <see cref="Godot.Callable"/> is empty (default), peers will be automatically accepted as soon as they connect.</para>
    /// </summary>
    public Callable AuthCallback
    {
        get
        {
            return GetAuthCallback();
        }
        set
        {
            SetAuthCallback(value);
        }
    }

    /// <summary>
    /// <para>If set to a value greater than <c>0.0</c>, the maximum duration in seconds peers can stay in the authenticating state, after which the authentication will automatically fail. See the <see cref="Godot.SceneMultiplayer.PeerAuthenticating"/> and <see cref="Godot.SceneMultiplayer.PeerAuthenticationFailed"/> signals.</para>
    /// </summary>
    public double AuthTimeout
    {
        get
        {
            return GetAuthTimeout();
        }
        set
        {
            SetAuthTimeout(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the MultiplayerAPI will allow encoding and decoding of object during RPCs.</para>
    /// <para><b>Warning:</b> Deserialized objects can contain code which gets executed. Do not use this option if the serialized object comes from untrusted sources to avoid potential security threat such as remote code execution.</para>
    /// </summary>
    public bool AllowObjectDecoding
    {
        get
        {
            return IsObjectDecodingAllowed();
        }
        set
        {
            SetAllowObjectDecoding(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the MultiplayerAPI's <see cref="Godot.MultiplayerApi.MultiplayerPeer"/> refuses new incoming connections.</para>
    /// </summary>
    public bool RefuseNewConnections
    {
        get
        {
            return IsRefusingNewConnections();
        }
        set
        {
            SetRefuseNewConnections(value);
        }
    }

    /// <summary>
    /// <para>Enable or disable the server feature that notifies clients of other peers' connection/disconnection, and relays messages between them. When this option is <see langword="false"/>, clients won't be automatically notified of other peers and won't be able to send them packets through the server.</para>
    /// <para><b>Note:</b> Changing this option while other peers are connected may lead to unexpected behaviors.</para>
    /// <para><b>Note:</b> Support for this feature may depend on the current <see cref="Godot.MultiplayerPeer"/> configuration. See <see cref="Godot.MultiplayerPeer.IsServerRelaySupported()"/>.</para>
    /// </summary>
    public bool ServerRelay
    {
        get
        {
            return IsServerRelayEnabled();
        }
        set
        {
            SetServerRelayEnabled(value);
        }
    }

    /// <summary>
    /// <para>Maximum size of each synchronization packet. Higher values increase the chance of receiving full updates in a single frame, but also the chance of packet loss. See <see cref="Godot.MultiplayerSynchronizer"/>.</para>
    /// </summary>
    public int MaxSyncPacketSize
    {
        get
        {
            return GetMaxSyncPacketSize();
        }
        set
        {
            SetMaxSyncPacketSize(value);
        }
    }

    /// <summary>
    /// <para>Maximum size of each delta packet. Higher values increase the chance of receiving full updates in a single frame, but also the chance of causing networking congestion (higher latency, disconnections). See <see cref="Godot.MultiplayerSynchronizer"/>.</para>
    /// </summary>
    public int MaxDeltaPacketSize
    {
        get
        {
            return GetMaxDeltaPacketSize();
        }
        set
        {
            SetMaxDeltaPacketSize(value);
        }
    }

    private static readonly System.Type CachedType = typeof(SceneMultiplayer);

    private static readonly StringName NativeName = "SceneMultiplayer";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public SceneMultiplayer() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal SceneMultiplayer(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal SceneMultiplayer(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRootPath, 1348162250ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetRootPath(NodePath path)
    {
        NativeCalls.godot_icall_1_123(MethodBind0, GodotObject.GetPtr(this), (godot_node_path)(path?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRootPath, 4075236667ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public NodePath GetRootPath()
    {
        return NativeCalls.godot_icall_0_124(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Clear, 3218959716ul);

    /// <summary>
    /// <para>Clears the current SceneMultiplayer network state (you shouldn't call this unless you know what you are doing).</para>
    /// </summary>
    public void Clear()
    {
        NativeCalls.godot_icall_0_3(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DisconnectPeer, 1286410249ul);

    /// <summary>
    /// <para>Disconnects the peer identified by <paramref name="id"/>, removing it from the list of connected peers, and closing the underlying connection with it.</para>
    /// </summary>
    public void DisconnectPeer(int id)
    {
        NativeCalls.godot_icall_1_38(MethodBind3, GodotObject.GetPtr(this), id);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAuthenticatingPeers, 969006518ul);

    /// <summary>
    /// <para>Returns the IDs of the peers currently trying to authenticate with this <see cref="Godot.MultiplayerApi"/>.</para>
    /// </summary>
    public int[] GetAuthenticatingPeers()
    {
        return NativeCalls.godot_icall_0_151(MethodBind4, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SendAuth, 506032537ul);

    /// <summary>
    /// <para>Sends the specified <paramref name="data"/> to the remote peer identified by <paramref name="id"/> as part of an authentication message. This can be used to authenticate peers, and control when <see cref="Godot.MultiplayerApi.PeerConnected"/> is emitted (and the remote peer accepted as one of the connected peers).</para>
    /// </summary>
    public Error SendAuth(int id, byte[] data)
    {
        return (Error)NativeCalls.godot_icall_2_712(MethodBind5, GodotObject.GetPtr(this), id, data);
    }

    /// <summary>
    /// <para>Sends the specified <paramref name="data"/> to the remote peer identified by <paramref name="id"/> as part of an authentication message. This can be used to authenticate peers, and control when <see cref="Godot.MultiplayerApi.PeerConnected"/> is emitted (and the remote peer accepted as one of the connected peers).</para>
    /// </summary>
    public Error SendAuth(int id, ReadOnlySpan<byte> data)
    {
        return (Error)NativeCalls.godot_icall_2_712(MethodBind5, GodotObject.GetPtr(this), id, data);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CompleteAuth, 844576869ul);

    /// <summary>
    /// <para>Mark the authentication step as completed for the remote peer identified by <paramref name="id"/>. The <see cref="Godot.MultiplayerApi.PeerConnected"/> signal will be emitted for this peer once the remote side also completes the authentication. No further authentication messages are expected to be received from this peer.</para>
    /// <para>If a peer disconnects before completing authentication, either due to a network issue, the <see cref="Godot.SceneMultiplayer.AuthTimeout"/> expiring, or manually calling <see cref="Godot.SceneMultiplayer.DisconnectPeer(int)"/>, the <see cref="Godot.SceneMultiplayer.PeerAuthenticationFailed"/> signal will be emitted instead of <see cref="Godot.MultiplayerApi.PeerDisconnected"/>.</para>
    /// </summary>
    public Error CompleteAuth(int id)
    {
        return (Error)NativeCalls.godot_icall_1_60(MethodBind6, GodotObject.GetPtr(this), id);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAuthCallback, 1611583062ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAuthCallback(Callable callback)
    {
        NativeCalls.godot_icall_1_403(MethodBind7, GodotObject.GetPtr(this), callback);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAuthCallback, 1307783378ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Callable GetAuthCallback()
    {
        return NativeCalls.godot_icall_0_811(MethodBind8, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAuthTimeout, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAuthTimeout(double timeout)
    {
        NativeCalls.godot_icall_1_127(MethodBind9, GodotObject.GetPtr(this), timeout);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAuthTimeout, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public double GetAuthTimeout()
    {
        return NativeCalls.godot_icall_0_144(MethodBind10, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRefuseNewConnections, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetRefuseNewConnections(bool refuse)
    {
        NativeCalls.godot_icall_1_14(MethodBind11, GodotObject.GetPtr(this), refuse.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsRefusingNewConnections, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsRefusingNewConnections()
    {
        return NativeCalls.godot_icall_0_15(MethodBind12, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAllowObjectDecoding, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAllowObjectDecoding(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind13, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsObjectDecodingAllowed, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsObjectDecodingAllowed()
    {
        return NativeCalls.godot_icall_0_15(MethodBind14, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetServerRelayEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetServerRelayEnabled(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind15, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsServerRelayEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsServerRelayEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind16, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SendBytes, 1307428718ul);

    /// <summary>
    /// <para>Sends the given raw <paramref name="bytes"/> to a specific peer identified by <paramref name="id"/> (see <see cref="Godot.MultiplayerPeer.SetTargetPeer(int)"/>). Default ID is <c>0</c>, i.e. broadcast to all peers.</para>
    /// </summary>
    public Error SendBytes(byte[] bytes, int id = 0, MultiplayerPeer.TransferModeEnum mode = (MultiplayerPeer.TransferModeEnum)(2), int channel = 0)
    {
        return (Error)NativeCalls.godot_icall_4_1249(MethodBind17, GodotObject.GetPtr(this), bytes, id, (int)mode, channel);
    }

    /// <summary>
    /// <para>Sends the given raw <paramref name="bytes"/> to a specific peer identified by <paramref name="id"/> (see <see cref="Godot.MultiplayerPeer.SetTargetPeer(int)"/>). Default ID is <c>0</c>, i.e. broadcast to all peers.</para>
    /// </summary>
    public Error SendBytes(ReadOnlySpan<byte> bytes, int id, MultiplayerPeer.TransferModeEnum mode, int channel)
    {
        return (Error)NativeCalls.godot_icall_4_1249(MethodBind17, GodotObject.GetPtr(this), bytes, id, (int)mode, channel);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMaxSyncPacketSize, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetMaxSyncPacketSize()
    {
        return NativeCalls.godot_icall_0_39(MethodBind18, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMaxSyncPacketSize, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMaxSyncPacketSize(int size)
    {
        NativeCalls.godot_icall_1_38(MethodBind19, GodotObject.GetPtr(this), size);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMaxDeltaPacketSize, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetMaxDeltaPacketSize()
    {
        return NativeCalls.godot_icall_0_39(MethodBind20, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMaxDeltaPacketSize, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMaxDeltaPacketSize(int size)
    {
        NativeCalls.godot_icall_1_38(MethodBind21, GodotObject.GetPtr(this), size);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.SceneMultiplayer.PeerAuthenticating"/> event of a <see cref="Godot.SceneMultiplayer"/> class.
    /// </summary>
    public delegate void PeerAuthenticatingEventHandler(long id);

    private static void PeerAuthenticatingTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((PeerAuthenticatingEventHandler)delegateObj)(VariantUtils.ConvertTo<long>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when this MultiplayerAPI's <see cref="Godot.MultiplayerApi.MultiplayerPeer"/> connects to a new peer and a valid <see cref="Godot.SceneMultiplayer.AuthCallback"/> is set. In this case, the <see cref="Godot.MultiplayerApi.PeerConnected"/> will not be emitted until <see cref="Godot.SceneMultiplayer.CompleteAuth(int)"/> is called with given peer <c>id</c>. While in this state, the peer will not be included in the list returned by <see cref="Godot.MultiplayerApi.GetPeers()"/> (but in the one returned by <see cref="Godot.SceneMultiplayer.GetAuthenticatingPeers()"/>), and only authentication data will be sent or received. See <see cref="Godot.SceneMultiplayer.SendAuth(int, byte[])"/> for sending authentication data.</para>
    /// </summary>
    public unsafe event PeerAuthenticatingEventHandler PeerAuthenticating
    {
        add => Connect(SignalName.PeerAuthenticating, Callable.CreateWithUnsafeTrampoline(value, &PeerAuthenticatingTrampoline));
        remove => Disconnect(SignalName.PeerAuthenticating, Callable.CreateWithUnsafeTrampoline(value, &PeerAuthenticatingTrampoline));
    }

    protected void EmitSignalPeerAuthenticating(long id)
    {
        EmitSignal(SignalName.PeerAuthenticating, id);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.SceneMultiplayer.PeerAuthenticationFailed"/> event of a <see cref="Godot.SceneMultiplayer"/> class.
    /// </summary>
    public delegate void PeerAuthenticationFailedEventHandler(long id);

    private static void PeerAuthenticationFailedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((PeerAuthenticationFailedEventHandler)delegateObj)(VariantUtils.ConvertTo<long>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when this MultiplayerAPI's <see cref="Godot.MultiplayerApi.MultiplayerPeer"/> disconnects from a peer for which authentication had not yet completed. See <see cref="Godot.SceneMultiplayer.PeerAuthenticating"/>.</para>
    /// </summary>
    public unsafe event PeerAuthenticationFailedEventHandler PeerAuthenticationFailed
    {
        add => Connect(SignalName.PeerAuthenticationFailed, Callable.CreateWithUnsafeTrampoline(value, &PeerAuthenticationFailedTrampoline));
        remove => Disconnect(SignalName.PeerAuthenticationFailed, Callable.CreateWithUnsafeTrampoline(value, &PeerAuthenticationFailedTrampoline));
    }

    protected void EmitSignalPeerAuthenticationFailed(long id)
    {
        EmitSignal(SignalName.PeerAuthenticationFailed, id);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.SceneMultiplayer.PeerPacket"/> event of a <see cref="Godot.SceneMultiplayer"/> class.
    /// </summary>
    public delegate void PeerPacketEventHandler(long id, byte[] packet);

    private static void PeerPacketTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 2);
        ((PeerPacketEventHandler)delegateObj)(VariantUtils.ConvertTo<long>(args[0]), VariantUtils.ConvertTo<byte[]>(args[1]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when this MultiplayerAPI's <see cref="Godot.MultiplayerApi.MultiplayerPeer"/> receives a <c>packet</c> with custom data (see <see cref="Godot.SceneMultiplayer.SendBytes(byte[], int, MultiplayerPeer.TransferModeEnum, int)"/>). ID is the peer ID of the peer that sent the packet.</para>
    /// </summary>
    public unsafe event PeerPacketEventHandler PeerPacket
    {
        add => Connect(SignalName.PeerPacket, Callable.CreateWithUnsafeTrampoline(value, &PeerPacketTrampoline));
        remove => Disconnect(SignalName.PeerPacket, Callable.CreateWithUnsafeTrampoline(value, &PeerPacketTrampoline));
    }

    protected void EmitSignalPeerPacket(long id, byte[] packet)
    {
        EmitSignal(SignalName.PeerPacket, id, packet);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_peer_authenticating = "PeerAuthenticating";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_peer_authentication_failed = "PeerAuthenticationFailed";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_peer_packet = "PeerPacket";

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
        if (signal == SignalName.PeerAuthenticating)
        {
            if (HasGodotClassSignal(SignalProxyName_peer_authenticating.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.PeerAuthenticationFailed)
        {
            if (HasGodotClassSignal(SignalProxyName_peer_authentication_failed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.PeerPacket)
        {
            if (HasGodotClassSignal(SignalProxyName_peer_packet.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        return base.HasGodotClassSignal(signal);
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : MultiplayerApi.PropertyName
    {
        /// <summary>
        /// Cached name for the 'root_path' property.
        /// </summary>
        public static readonly StringName RootPath = "root_path";
        /// <summary>
        /// Cached name for the 'auth_callback' property.
        /// </summary>
        public static readonly StringName AuthCallback = "auth_callback";
        /// <summary>
        /// Cached name for the 'auth_timeout' property.
        /// </summary>
        public static readonly StringName AuthTimeout = "auth_timeout";
        /// <summary>
        /// Cached name for the 'allow_object_decoding' property.
        /// </summary>
        public static readonly StringName AllowObjectDecoding = "allow_object_decoding";
        /// <summary>
        /// Cached name for the 'refuse_new_connections' property.
        /// </summary>
        public static readonly StringName RefuseNewConnections = "refuse_new_connections";
        /// <summary>
        /// Cached name for the 'server_relay' property.
        /// </summary>
        public static readonly StringName ServerRelay = "server_relay";
        /// <summary>
        /// Cached name for the 'max_sync_packet_size' property.
        /// </summary>
        public static readonly StringName MaxSyncPacketSize = "max_sync_packet_size";
        /// <summary>
        /// Cached name for the 'max_delta_packet_size' property.
        /// </summary>
        public static readonly StringName MaxDeltaPacketSize = "max_delta_packet_size";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : MultiplayerApi.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_root_path' method.
        /// </summary>
        public static readonly StringName SetRootPath = "set_root_path";
        /// <summary>
        /// Cached name for the 'get_root_path' method.
        /// </summary>
        public static readonly StringName GetRootPath = "get_root_path";
        /// <summary>
        /// Cached name for the 'clear' method.
        /// </summary>
        public static readonly StringName Clear = "clear";
        /// <summary>
        /// Cached name for the 'disconnect_peer' method.
        /// </summary>
        public static readonly StringName DisconnectPeer = "disconnect_peer";
        /// <summary>
        /// Cached name for the 'get_authenticating_peers' method.
        /// </summary>
        public static readonly StringName GetAuthenticatingPeers = "get_authenticating_peers";
        /// <summary>
        /// Cached name for the 'send_auth' method.
        /// </summary>
        public static readonly StringName SendAuth = "send_auth";
        /// <summary>
        /// Cached name for the 'complete_auth' method.
        /// </summary>
        public static readonly StringName CompleteAuth = "complete_auth";
        /// <summary>
        /// Cached name for the 'set_auth_callback' method.
        /// </summary>
        public static readonly StringName SetAuthCallback = "set_auth_callback";
        /// <summary>
        /// Cached name for the 'get_auth_callback' method.
        /// </summary>
        public static readonly StringName GetAuthCallback = "get_auth_callback";
        /// <summary>
        /// Cached name for the 'set_auth_timeout' method.
        /// </summary>
        public static readonly StringName SetAuthTimeout = "set_auth_timeout";
        /// <summary>
        /// Cached name for the 'get_auth_timeout' method.
        /// </summary>
        public static readonly StringName GetAuthTimeout = "get_auth_timeout";
        /// <summary>
        /// Cached name for the 'set_refuse_new_connections' method.
        /// </summary>
        public static readonly StringName SetRefuseNewConnections = "set_refuse_new_connections";
        /// <summary>
        /// Cached name for the 'is_refusing_new_connections' method.
        /// </summary>
        public static readonly StringName IsRefusingNewConnections = "is_refusing_new_connections";
        /// <summary>
        /// Cached name for the 'set_allow_object_decoding' method.
        /// </summary>
        public static readonly StringName SetAllowObjectDecoding = "set_allow_object_decoding";
        /// <summary>
        /// Cached name for the 'is_object_decoding_allowed' method.
        /// </summary>
        public static readonly StringName IsObjectDecodingAllowed = "is_object_decoding_allowed";
        /// <summary>
        /// Cached name for the 'set_server_relay_enabled' method.
        /// </summary>
        public static readonly StringName SetServerRelayEnabled = "set_server_relay_enabled";
        /// <summary>
        /// Cached name for the 'is_server_relay_enabled' method.
        /// </summary>
        public static readonly StringName IsServerRelayEnabled = "is_server_relay_enabled";
        /// <summary>
        /// Cached name for the 'send_bytes' method.
        /// </summary>
        public static readonly StringName SendBytes = "send_bytes";
        /// <summary>
        /// Cached name for the 'get_max_sync_packet_size' method.
        /// </summary>
        public static readonly StringName GetMaxSyncPacketSize = "get_max_sync_packet_size";
        /// <summary>
        /// Cached name for the 'set_max_sync_packet_size' method.
        /// </summary>
        public static readonly StringName SetMaxSyncPacketSize = "set_max_sync_packet_size";
        /// <summary>
        /// Cached name for the 'get_max_delta_packet_size' method.
        /// </summary>
        public static readonly StringName GetMaxDeltaPacketSize = "get_max_delta_packet_size";
        /// <summary>
        /// Cached name for the 'set_max_delta_packet_size' method.
        /// </summary>
        public static readonly StringName SetMaxDeltaPacketSize = "set_max_delta_packet_size";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : MultiplayerApi.SignalName
    {
        /// <summary>
        /// Cached name for the 'peer_authenticating' signal.
        /// </summary>
        public static readonly StringName PeerAuthenticating = "peer_authenticating";
        /// <summary>
        /// Cached name for the 'peer_authentication_failed' signal.
        /// </summary>
        public static readonly StringName PeerAuthenticationFailed = "peer_authentication_failed";
        /// <summary>
        /// Cached name for the 'peer_packet' signal.
        /// </summary>
        public static readonly StringName PeerPacket = "peer_packet";
    }
}
