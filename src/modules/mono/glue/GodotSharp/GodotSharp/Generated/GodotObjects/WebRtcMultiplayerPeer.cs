namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This class constructs a full mesh of <see cref="Godot.WebRtcPeerConnection"/> (one connection for each peer) that can be used as a <see cref="Godot.MultiplayerApi.MultiplayerPeer"/>.</para>
/// <para>You can add each <see cref="Godot.WebRtcPeerConnection"/> via <see cref="Godot.WebRtcMultiplayerPeer.AddPeer(WebRtcPeerConnection, int, int)"/> or remove them via <see cref="Godot.WebRtcMultiplayerPeer.RemovePeer(int)"/>. Peers must be added in <see cref="Godot.WebRtcPeerConnection.ConnectionState.New"/> state to allow it to create the appropriate channels. This class will not create offers nor set descriptions, it will only poll them, and notify connections and disconnections.</para>
/// <para>When creating the peer via <see cref="Godot.WebRtcMultiplayerPeer.CreateClient(int, Godot.Collections.Array)"/> or <see cref="Godot.WebRtcMultiplayerPeer.CreateServer(Godot.Collections.Array)"/> the <see cref="Godot.MultiplayerPeer.IsServerRelaySupported()"/> method will return <see langword="true"/> enabling peer exchange and packet relaying when supported by the <see cref="Godot.MultiplayerApi"/> implementation.</para>
/// <para><b>Note:</b> When exporting to Android, make sure to enable the <c>INTERNET</c> permission in the Android export preset before exporting the project or using one-click deploy. Otherwise, network communication of any kind will be blocked by Android.</para>
/// </summary>
[GodotClassName("WebRTCMultiplayerPeer")]
public partial class WebRtcMultiplayerPeer : MultiplayerPeer
{
    private static readonly System.Type CachedType = typeof(WebRtcMultiplayerPeer);

    private static readonly StringName NativeName = "WebRTCMultiplayerPeer";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public WebRtcMultiplayerPeer() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal WebRtcMultiplayerPeer(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal WebRtcMultiplayerPeer(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CreateServer, 2865356025ul);

    /// <summary>
    /// <para>Initialize the multiplayer peer as a server (with unique ID of <c>1</c>). This mode enables <see cref="Godot.MultiplayerPeer.IsServerRelaySupported()"/>, allowing the upper <see cref="Godot.MultiplayerApi"/> layer to perform peer exchange and packet relaying.</para>
    /// <para>You can optionally specify a <paramref name="channelsConfig"/> array of <see cref="Godot.MultiplayerPeer.TransferModeEnum"/> which will be used to create extra channels (WebRTC only supports one transfer mode per channel).</para>
    /// </summary>
    public Error CreateServer(Godot.Collections.Array channelsConfig = null)
    {
        return (Error)NativeCalls.godot_icall_1_739(MethodBind0, GodotObject.GetPtr(this), (godot_array)(channelsConfig ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CreateClient, 2641732907ul);

    /// <summary>
    /// <para>Initialize the multiplayer peer as a client with the given <paramref name="peerId"/> (must be between 2 and 2147483647). In this mode, you should only call <see cref="Godot.WebRtcMultiplayerPeer.AddPeer(WebRtcPeerConnection, int, int)"/> once and with <paramref name="peerId"/> of <c>1</c>. This mode enables <see cref="Godot.MultiplayerPeer.IsServerRelaySupported()"/>, allowing the upper <see cref="Godot.MultiplayerApi"/> layer to perform peer exchange and packet relaying.</para>
    /// <para>You can optionally specify a <paramref name="channelsConfig"/> array of <see cref="Godot.MultiplayerPeer.TransferModeEnum"/> which will be used to create extra channels (WebRTC only supports one transfer mode per channel).</para>
    /// </summary>
    public Error CreateClient(int peerId, Godot.Collections.Array channelsConfig = null)
    {
        return (Error)NativeCalls.godot_icall_2_1498(MethodBind1, GodotObject.GetPtr(this), peerId, (godot_array)(channelsConfig ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CreateMesh, 2641732907ul);

    /// <summary>
    /// <para>Initialize the multiplayer peer as a mesh (i.e. all peers connect to each other) with the given <paramref name="peerId"/> (must be between 1 and 2147483647).</para>
    /// </summary>
    public Error CreateMesh(int peerId, Godot.Collections.Array channelsConfig = null)
    {
        return (Error)NativeCalls.godot_icall_2_1498(MethodBind2, GodotObject.GetPtr(this), peerId, (godot_array)(channelsConfig ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddPeer, 4078953270ul);

    /// <summary>
    /// <para>Add a new peer to the mesh with the given <paramref name="peerId"/>. The <see cref="Godot.WebRtcPeerConnection"/> must be in state <see cref="Godot.WebRtcPeerConnection.ConnectionState.New"/>.</para>
    /// <para>Three channels will be created for reliable, unreliable, and ordered transport. The value of <paramref name="unreliableLifetime"/> will be passed to the <c>"maxPacketLifetime"</c> option when creating unreliable and ordered channels (see <see cref="Godot.WebRtcPeerConnection.CreateDataChannel(string, Godot.Collections.Dictionary)"/>).</para>
    /// </summary>
    public Error AddPeer(WebRtcPeerConnection peer, int peerId, int unreliableLifetime = 1)
    {
        return (Error)NativeCalls.godot_icall_3_1499(MethodBind3, GodotObject.GetPtr(this), GodotObject.GetPtr(peer), peerId, unreliableLifetime);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemovePeer, 1286410249ul);

    /// <summary>
    /// <para>Remove the peer with given <paramref name="peerId"/> from the mesh. If the peer was connected, and <see cref="Godot.MultiplayerPeer.PeerConnected"/> was emitted for it, then <see cref="Godot.MultiplayerPeer.PeerDisconnected"/> will be emitted.</para>
    /// </summary>
    public void RemovePeer(int peerId)
    {
        NativeCalls.godot_icall_1_38(MethodBind4, GodotObject.GetPtr(this), peerId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasPeer, 3067735520ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the given <paramref name="peerId"/> is in the peers map (it might not be connected though).</para>
    /// </summary>
    public bool HasPeer(int peerId)
    {
        return NativeCalls.godot_icall_1_62(MethodBind5, GodotObject.GetPtr(this), peerId).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPeer, 3554694381ul);

    /// <summary>
    /// <para>Returns a dictionary representation of the peer with given <paramref name="peerId"/> with three keys. <c>"connection"</c> containing the <see cref="Godot.WebRtcPeerConnection"/> to this peer, <c>"channels"</c> an array of three <see cref="Godot.WebRtcDataChannel"/>, and <c>"connected"</c> a boolean representing if the peer connection is currently connected (all three channels are open).</para>
    /// </summary>
    public Godot.Collections.Dictionary GetPeer(int peerId)
    {
        return NativeCalls.godot_icall_1_307(MethodBind6, GodotObject.GetPtr(this), peerId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPeers, 2382534195ul);

    /// <summary>
    /// <para>Returns a dictionary which keys are the peer ids and values the peer representation as in <see cref="Godot.WebRtcMultiplayerPeer.GetPeer(int)"/>.</para>
    /// </summary>
    public Godot.Collections.Dictionary GetPeers()
    {
        return NativeCalls.godot_icall_0_122(MethodBind7, GodotObject.GetPtr(this));
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
        /// Cached name for the 'add_peer' method.
        /// </summary>
        public static readonly StringName AddPeer = "add_peer";
        /// <summary>
        /// Cached name for the 'remove_peer' method.
        /// </summary>
        public static readonly StringName RemovePeer = "remove_peer";
        /// <summary>
        /// Cached name for the 'has_peer' method.
        /// </summary>
        public static readonly StringName HasPeer = "has_peer";
        /// <summary>
        /// Cached name for the 'get_peer' method.
        /// </summary>
        public static readonly StringName GetPeer = "get_peer";
        /// <summary>
        /// Cached name for the 'get_peers' method.
        /// </summary>
        public static readonly StringName GetPeers = "get_peers";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : MultiplayerPeer.SignalName
    {
    }
}
