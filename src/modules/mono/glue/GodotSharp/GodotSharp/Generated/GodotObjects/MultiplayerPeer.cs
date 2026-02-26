namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Manages the connection with one or more remote peers acting as server or client and assigning unique IDs to each of them. See also <see cref="Godot.MultiplayerApi"/>.</para>
/// <para><b>Note:</b> The <see cref="Godot.MultiplayerApi"/> protocol is an implementation detail and isn't meant to be used by non-Godot servers. It may change without notice.</para>
/// <para><b>Note:</b> When exporting to Android, make sure to enable the <c>INTERNET</c> permission in the Android export preset before exporting the project or using one-click deploy. Otherwise, network communication of any kind will be blocked by Android.</para>
/// </summary>
public partial class MultiplayerPeer : PacketPeer
{
    /// <summary>
    /// <para>Packets are sent to all connected peers.</para>
    /// </summary>
    public const long TargetPeerBroadcast = 0;
    /// <summary>
    /// <para>Packets are sent to the remote peer acting as server.</para>
    /// </summary>
    public const long TargetPeerServer = 1;

    public enum ConnectionStatus : long
    {
        /// <summary>
        /// <para>The MultiplayerPeer is disconnected.</para>
        /// </summary>
        Disconnected = 0,
        /// <summary>
        /// <para>The MultiplayerPeer is currently connecting to a server.</para>
        /// </summary>
        Connecting = 1,
        /// <summary>
        /// <para>This MultiplayerPeer is connected.</para>
        /// </summary>
        Connected = 2
    }

    public enum TransferModeEnum : long
    {
        /// <summary>
        /// <para>Packets are not acknowledged, no resend attempts are made for lost packets. Packets may arrive in any order. Potentially faster than <see cref="Godot.MultiplayerPeer.TransferModeEnum.UnreliableOrdered"/>. Use for non-critical data, and always consider whether the order matters.</para>
        /// </summary>
        Unreliable = 0,
        /// <summary>
        /// <para>Packets are not acknowledged, no resend attempts are made for lost packets. Packets are received in the order they were sent in. Potentially faster than <see cref="Godot.MultiplayerPeer.TransferModeEnum.Reliable"/>. Use for non-critical data or data that would be outdated if received late due to resend attempt(s) anyway, for example movement and positional data.</para>
        /// </summary>
        UnreliableOrdered = 1,
        /// <summary>
        /// <para>Packets must be received and resend attempts should be made until the packets are acknowledged. Packets must be received in the order they were sent in. Most reliable transfer mode, but potentially the slowest due to the overhead. Use for critical data that must be transmitted and arrive in order, for example an ability being triggered or a chat message. Consider carefully if the information really is critical, and use sparingly.</para>
        /// </summary>
        Reliable = 2
    }

    /// <summary>
    /// <para>If <see langword="true"/>, this <see cref="Godot.MultiplayerPeer"/> refuses new connections.</para>
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
    /// <para>The manner in which to send packets to the target peer. See the <see cref="Godot.MultiplayerPeer.SetTargetPeer(int)"/> method.</para>
    /// </summary>
    public MultiplayerPeer.TransferModeEnum TransferMode
    {
        get
        {
            return GetTransferMode();
        }
        set
        {
            SetTransferMode(value);
        }
    }

    /// <summary>
    /// <para>The channel to use to send packets. Many network APIs such as ENet and WebRTC allow the creation of multiple independent channels which behaves, in a way, like separate connections. This means that reliable data will only block delivery of other packets on that channel, and ordering will only be in respect to the channel the packet is being sent on. Using different channels to send <b>different and independent</b> state updates is a common way to optimize network usage and decrease latency in fast-paced games.</para>
    /// <para><b>Note:</b> The default channel (<c>0</c>) actually works as 3 separate channels (one for each <see cref="Godot.MultiplayerPeer.TransferModeEnum"/>) so that <see cref="Godot.MultiplayerPeer.TransferModeEnum.Reliable"/> and <see cref="Godot.MultiplayerPeer.TransferModeEnum.UnreliableOrdered"/> does not interact with each other by default. Refer to the specific network API documentation (e.g. ENet or WebRTC) to learn how to set up channels correctly.</para>
    /// </summary>
    public int TransferChannel
    {
        get
        {
            return GetTransferChannel();
        }
        set
        {
            SetTransferChannel(value);
        }
    }

    private static readonly System.Type CachedType = typeof(MultiplayerPeer);

    private static readonly StringName NativeName = "MultiplayerPeer";

    internal MultiplayerPeer() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal MultiplayerPeer(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal MultiplayerPeer(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTransferChannel, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTransferChannel(int channel)
    {
        NativeCalls.godot_icall_1_38(MethodBind0, GodotObject.GetPtr(this), channel);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTransferChannel, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetTransferChannel()
    {
        return NativeCalls.godot_icall_0_39(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTransferMode, 950411049ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTransferMode(MultiplayerPeer.TransferModeEnum mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind2, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTransferMode, 3369852622ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public MultiplayerPeer.TransferModeEnum GetTransferMode()
    {
        return (MultiplayerPeer.TransferModeEnum)NativeCalls.godot_icall_0_39(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTargetPeer, 1286410249ul);

    /// <summary>
    /// <para>Sets the peer to which packets will be sent.</para>
    /// <para>The <paramref name="id"/> can be one of: <see cref="Godot.MultiplayerPeer.TargetPeerBroadcast"/> to send to all connected peers, <see cref="Godot.MultiplayerPeer.TargetPeerServer"/> to send to the peer acting as server, a valid peer ID to send to that specific peer, a negative peer ID to send to all peers except that one. By default, the target peer is <see cref="Godot.MultiplayerPeer.TargetPeerBroadcast"/>.</para>
    /// </summary>
    public void SetTargetPeer(int id)
    {
        NativeCalls.godot_icall_1_38(MethodBind4, GodotObject.GetPtr(this), id);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPacketPeer, 3905245786ul);

    /// <summary>
    /// <para>Returns the ID of the <see cref="Godot.MultiplayerPeer"/> who sent the next available packet. See <see cref="Godot.PacketPeer.GetAvailablePacketCount()"/>.</para>
    /// </summary>
    public int GetPacketPeer()
    {
        return NativeCalls.godot_icall_0_39(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPacketChannel, 3905245786ul);

    /// <summary>
    /// <para>Returns the channel over which the next available packet was received. See <see cref="Godot.PacketPeer.GetAvailablePacketCount()"/>.</para>
    /// </summary>
    public int GetPacketChannel()
    {
        return NativeCalls.godot_icall_0_39(MethodBind6, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPacketMode, 3369852622ul);

    /// <summary>
    /// <para>Returns the transfer mode the remote peer used to send the next available packet. See <see cref="Godot.PacketPeer.GetAvailablePacketCount()"/>.</para>
    /// </summary>
    public MultiplayerPeer.TransferModeEnum GetPacketMode()
    {
        return (MultiplayerPeer.TransferModeEnum)NativeCalls.godot_icall_0_39(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Poll, 3218959716ul);

    /// <summary>
    /// <para>Waits up to 1 second to receive a new network event.</para>
    /// </summary>
    public void Poll()
    {
        NativeCalls.godot_icall_0_3(MethodBind8, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Close, 3218959716ul);

    /// <summary>
    /// <para>Immediately close the multiplayer peer returning to the state <see cref="Godot.MultiplayerPeer.ConnectionStatus.Disconnected"/>. Connected peers will be dropped without emitting <see cref="Godot.MultiplayerPeer.PeerDisconnected"/>.</para>
    /// </summary>
    public void Close()
    {
        NativeCalls.godot_icall_0_3(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DisconnectPeer, 4023243586ul);

    /// <summary>
    /// <para>Disconnects the given <paramref name="peer"/> from this host. If <paramref name="force"/> is <see langword="true"/> the <see cref="Godot.MultiplayerPeer.PeerDisconnected"/> signal will not be emitted for this peer.</para>
    /// </summary>
    public void DisconnectPeer(int peer, bool force = false)
    {
        NativeCalls.godot_icall_2_61(MethodBind10, GodotObject.GetPtr(this), peer, force.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetConnectionStatus, 2147374275ul);

    /// <summary>
    /// <para>Returns the current state of the connection.</para>
    /// </summary>
    public MultiplayerPeer.ConnectionStatus GetConnectionStatus()
    {
        return (MultiplayerPeer.ConnectionStatus)NativeCalls.godot_icall_0_39(MethodBind11, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetUniqueId, 3905245786ul);

    /// <summary>
    /// <para>Returns the ID of this <see cref="Godot.MultiplayerPeer"/>.</para>
    /// </summary>
    public int GetUniqueId()
    {
        return NativeCalls.godot_icall_0_39(MethodBind12, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GenerateUniqueId, 3905245786ul);

    /// <summary>
    /// <para>Returns a randomly generated integer that can be used as a network unique ID.</para>
    /// </summary>
    public uint GenerateUniqueId()
    {
        return NativeCalls.godot_icall_0_209(MethodBind13, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRefuseNewConnections, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetRefuseNewConnections(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind14, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsRefusingNewConnections, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsRefusingNewConnections()
    {
        return NativeCalls.godot_icall_0_15(MethodBind15, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsServerRelaySupported, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the server can act as a relay in the current configuration. That is, if the higher level <see cref="Godot.MultiplayerApi"/> should notify connected clients of other peers, and implement a relay protocol to allow communication between them.</para>
    /// </summary>
    public bool IsServerRelaySupported()
    {
        return NativeCalls.godot_icall_0_15(MethodBind16, GodotObject.GetPtr(this)).ToBool();
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.MultiplayerPeer.PeerConnected"/> event of a <see cref="Godot.MultiplayerPeer"/> class.
    /// </summary>
    public delegate void PeerConnectedEventHandler(long id);

    private static void PeerConnectedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((PeerConnectedEventHandler)delegateObj)(VariantUtils.ConvertTo<long>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when a remote peer connects.</para>
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
    /// Represents the method that handles the <see cref="Godot.MultiplayerPeer.PeerDisconnected"/> event of a <see cref="Godot.MultiplayerPeer"/> class.
    /// </summary>
    public delegate void PeerDisconnectedEventHandler(long id);

    private static void PeerDisconnectedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((PeerDisconnectedEventHandler)delegateObj)(VariantUtils.ConvertTo<long>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when a remote peer has disconnected.</para>
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

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_peer_connected = "PeerConnected";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_peer_disconnected = "PeerDisconnected";

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
        return base.HasGodotClassSignal(signal);
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : PacketPeer.PropertyName
    {
        /// <summary>
        /// Cached name for the 'refuse_new_connections' property.
        /// </summary>
        public static readonly StringName RefuseNewConnections = "refuse_new_connections";
        /// <summary>
        /// Cached name for the 'transfer_mode' property.
        /// </summary>
        public static readonly StringName TransferMode = "transfer_mode";
        /// <summary>
        /// Cached name for the 'transfer_channel' property.
        /// </summary>
        public static readonly StringName TransferChannel = "transfer_channel";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : PacketPeer.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_transfer_channel' method.
        /// </summary>
        public static readonly StringName SetTransferChannel = "set_transfer_channel";
        /// <summary>
        /// Cached name for the 'get_transfer_channel' method.
        /// </summary>
        public static readonly StringName GetTransferChannel = "get_transfer_channel";
        /// <summary>
        /// Cached name for the 'set_transfer_mode' method.
        /// </summary>
        public static readonly StringName SetTransferMode = "set_transfer_mode";
        /// <summary>
        /// Cached name for the 'get_transfer_mode' method.
        /// </summary>
        public static readonly StringName GetTransferMode = "get_transfer_mode";
        /// <summary>
        /// Cached name for the 'set_target_peer' method.
        /// </summary>
        public static readonly StringName SetTargetPeer = "set_target_peer";
        /// <summary>
        /// Cached name for the 'get_packet_peer' method.
        /// </summary>
        public static readonly StringName GetPacketPeer = "get_packet_peer";
        /// <summary>
        /// Cached name for the 'get_packet_channel' method.
        /// </summary>
        public static readonly StringName GetPacketChannel = "get_packet_channel";
        /// <summary>
        /// Cached name for the 'get_packet_mode' method.
        /// </summary>
        public static readonly StringName GetPacketMode = "get_packet_mode";
        /// <summary>
        /// Cached name for the 'poll' method.
        /// </summary>
        public static readonly StringName Poll = "poll";
        /// <summary>
        /// Cached name for the 'close' method.
        /// </summary>
        public static readonly StringName Close = "close";
        /// <summary>
        /// Cached name for the 'disconnect_peer' method.
        /// </summary>
        public static readonly StringName DisconnectPeer = "disconnect_peer";
        /// <summary>
        /// Cached name for the 'get_connection_status' method.
        /// </summary>
        public static readonly StringName GetConnectionStatus = "get_connection_status";
        /// <summary>
        /// Cached name for the 'get_unique_id' method.
        /// </summary>
        public static readonly StringName GetUniqueId = "get_unique_id";
        /// <summary>
        /// Cached name for the 'generate_unique_id' method.
        /// </summary>
        public static readonly StringName GenerateUniqueId = "generate_unique_id";
        /// <summary>
        /// Cached name for the 'set_refuse_new_connections' method.
        /// </summary>
        public static readonly StringName SetRefuseNewConnections = "set_refuse_new_connections";
        /// <summary>
        /// Cached name for the 'is_refusing_new_connections' method.
        /// </summary>
        public static readonly StringName IsRefusingNewConnections = "is_refusing_new_connections";
        /// <summary>
        /// Cached name for the 'is_server_relay_supported' method.
        /// </summary>
        public static readonly StringName IsServerRelaySupported = "is_server_relay_supported";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : PacketPeer.SignalName
    {
        /// <summary>
        /// Cached name for the 'peer_connected' signal.
        /// </summary>
        public static readonly StringName PeerConnected = "peer_connected";
        /// <summary>
        /// Cached name for the 'peer_disconnected' signal.
        /// </summary>
        public static readonly StringName PeerDisconnected = "peer_disconnected";
    }
}
