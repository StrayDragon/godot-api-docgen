namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A WebRTC connection between the local computer and a remote peer. Provides an interface to connect, maintain, and monitor the connection.</para>
/// <para>Setting up a WebRTC connection between two peers may not seem a trivial task, but it can be broken down into 3 main steps:</para>
/// <para>- The peer that wants to initiate the connection (<c>A</c> from now on) creates an offer and sends it to the other peer (<c>B</c> from now on).</para>
/// <para>- <c>B</c> receives the offer, generates an answer, and sends it to <c>A</c>.</para>
/// <para>- <c>A</c> and <c>B</c> then generate and exchange ICE candidates with each other.</para>
/// <para>After these steps, the connection should be established. Refer to the linked tutorials for details.</para>
/// </summary>
[GodotClassName("WebRTCPeerConnection")]
public partial class WebRtcPeerConnection : RefCounted
{
    public enum ConnectionState : long
    {
        /// <summary>
        /// <para>The connection is new, data channels and an offer can be created in this state.</para>
        /// </summary>
        New = 0,
        /// <summary>
        /// <para>The peer is connecting, ICE is in progress, none of the transports has failed.</para>
        /// </summary>
        Connecting = 1,
        /// <summary>
        /// <para>The peer is connected, all ICE transports are connected.</para>
        /// </summary>
        Connected = 2,
        /// <summary>
        /// <para>At least one ICE transport is disconnected.</para>
        /// </summary>
        Disconnected = 3,
        /// <summary>
        /// <para>One or more of the ICE transports failed.</para>
        /// </summary>
        Failed = 4,
        /// <summary>
        /// <para>The peer connection is closed (after calling <see cref="Godot.WebRtcPeerConnection.Close()"/> for example).</para>
        /// </summary>
        Closed = 5
    }

    public enum GatheringState : long
    {
        /// <summary>
        /// <para>The peer connection was just created and hasn't done any networking yet.</para>
        /// </summary>
        New = 0,
        /// <summary>
        /// <para>The ICE agent is in the process of gathering candidates for the connection.</para>
        /// </summary>
        Gathering = 1,
        /// <summary>
        /// <para>The ICE agent has finished gathering candidates. If something happens that requires collecting new candidates, such as a new interface being added or the addition of a new ICE server, the state will revert to gathering to gather those candidates.</para>
        /// </summary>
        Complete = 2
    }

    public enum SignalingState : long
    {
        /// <summary>
        /// <para>There is no ongoing exchange of offer and answer underway. This may mean that the <see cref="Godot.WebRtcPeerConnection"/> is new (<see cref="Godot.WebRtcPeerConnection.ConnectionState.New"/>) or that negotiation is complete and a connection has been established (<see cref="Godot.WebRtcPeerConnection.ConnectionState.Connected"/>).</para>
        /// </summary>
        Stable = 0,
        /// <summary>
        /// <para>The local peer has called <see cref="Godot.WebRtcPeerConnection.SetLocalDescription(string, string)"/>, passing in SDP representing an offer (usually created by calling <see cref="Godot.WebRtcPeerConnection.CreateOffer()"/>), and the offer has been applied successfully.</para>
        /// </summary>
        HaveLocalOffer = 1,
        /// <summary>
        /// <para>The remote peer has created an offer and used the signaling server to deliver it to the local peer, which has set the offer as the remote description by calling <see cref="Godot.WebRtcPeerConnection.SetRemoteDescription(string, string)"/>.</para>
        /// </summary>
        HaveRemoteOffer = 2,
        /// <summary>
        /// <para>The offer sent by the remote peer has been applied and an answer has been created and applied by calling <see cref="Godot.WebRtcPeerConnection.SetLocalDescription(string, string)"/>. This provisional answer describes the supported media formats and so forth, but may not have a complete set of ICE candidates included. Further candidates will be delivered separately later.</para>
        /// </summary>
        HaveLocalPranswer = 3,
        /// <summary>
        /// <para>A provisional answer has been received and successfully applied in response to an offer previously sent and established by calling <see cref="Godot.WebRtcPeerConnection.SetLocalDescription(string, string)"/>.</para>
        /// </summary>
        HaveRemotePranswer = 4,
        /// <summary>
        /// <para>The <see cref="Godot.WebRtcPeerConnection"/> has been closed.</para>
        /// </summary>
        Closed = 5
    }

    private static readonly System.Type CachedType = typeof(WebRtcPeerConnection);

    private static readonly StringName NativeName = "WebRTCPeerConnection";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public WebRtcPeerConnection() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal WebRtcPeerConnection(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal WebRtcPeerConnection(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDefaultExtension, 3304788590ul);

    /// <summary>
    /// <para>Sets the <paramref name="extensionClass"/> as the default <see cref="Godot.WebRtcPeerConnectionExtension"/> returned when creating a new <see cref="Godot.WebRtcPeerConnection"/>.</para>
    /// </summary>
    public static void SetDefaultExtension(StringName extensionClass)
    {
        NativeCalls.godot_icall_1_807(MethodBind0, (godot_string_name)(extensionClass?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Initialize, 2625064318ul);

    /// <summary>
    /// <para>Re-initialize this peer connection, closing any previously active connection, and going back to state <see cref="Godot.WebRtcPeerConnection.ConnectionState.New"/>. A dictionary of <paramref name="configuration"/> options can be passed to configure the peer connection.</para>
    /// <para>Valid <paramref name="configuration"/> options are:</para>
    /// <para><code>
    /// {
    /// 	"iceServers": [
    /// 		{
    /// 			"urls": [ "stun:stun.example.com:3478" ], # One or more STUN servers.
    /// 		},
    /// 		{
    /// 			"urls": [ "turn:turn.example.com:3478" ], # One or more TURN servers.
    /// 			"username": "a_username", # Optional username for the TURN server.
    /// 			"credential": "a_password", # Optional password for the TURN server.
    /// 		}
    /// 	]
    /// }
    /// </code></para>
    /// </summary>
    public Error Initialize(Godot.Collections.Dictionary configuration = null)
    {
        return (Error)NativeCalls.godot_icall_1_1500(MethodBind1, GodotObject.GetPtr(this), (godot_dictionary)(configuration ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CreateDataChannel, 1288557393ul);

    /// <summary>
    /// <para>Returns a new <see cref="Godot.WebRtcDataChannel"/> (or <see langword="null"/> on failure) with given <paramref name="label"/> and optionally configured via the <paramref name="options"/> dictionary. This method can only be called when the connection is in state <see cref="Godot.WebRtcPeerConnection.ConnectionState.New"/>.</para>
    /// <para>There are two ways to create a working data channel: either call <see cref="Godot.WebRtcPeerConnection.CreateDataChannel(string, Godot.Collections.Dictionary)"/> on only one of the peer and listen to <see cref="Godot.WebRtcPeerConnection.DataChannelReceived"/> on the other, or call <see cref="Godot.WebRtcPeerConnection.CreateDataChannel(string, Godot.Collections.Dictionary)"/> on both peers, with the same values, and the <c>"negotiated"</c> option set to <see langword="true"/>.</para>
    /// <para>Valid <paramref name="options"/> are:</para>
    /// <para><code>
    /// {
    /// 	"negotiated": true, # When set to true (default off), means the channel is negotiated out of band. "id" must be set too. "data_channel_received" will not be called.
    /// 	"id": 1, # When "negotiated" is true this value must also be set to the same value on both peer.
    /// 
    /// 	# Only one of maxRetransmits and maxPacketLifeTime can be specified, not both. They make the channel unreliable (but also better at real time).
    /// 	"maxRetransmits": 1, # Specify the maximum number of attempt the peer will make to retransmits packets if they are not acknowledged.
    /// 	"maxPacketLifeTime": 100, # Specify the maximum amount of time before giving up retransmitions of unacknowledged packets (in milliseconds).
    /// 	"ordered": true, # When in unreliable mode (i.e. either "maxRetransmits" or "maxPacketLifetime" is set), "ordered" (true by default) specify if packet ordering is to be enforced.
    /// 
    /// 	"protocol": "my-custom-protocol", # A custom sub-protocol string for this channel.
    /// }
    /// </code></para>
    /// <para><b>Note:</b> You must keep a reference to channels created this way, or it will be closed.</para>
    /// </summary>
    public WebRtcDataChannel CreateDataChannel(string label, Godot.Collections.Dictionary options = null)
    {
        return (WebRtcDataChannel)NativeCalls.godot_icall_2_1501(MethodBind2, GodotObject.GetPtr(this), label, (godot_dictionary)(options ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CreateOffer, 166280745ul);

    /// <summary>
    /// <para>Creates a new SDP offer to start a WebRTC connection with a remote peer. At least one <see cref="Godot.WebRtcDataChannel"/> must have been created before calling this method.</para>
    /// <para>If this functions returns <see cref="Godot.Error.Ok"/>, <see cref="Godot.WebRtcPeerConnection.SessionDescriptionCreated"/> will be called when the session is ready to be sent.</para>
    /// </summary>
    public Error CreateOffer()
    {
        return (Error)NativeCalls.godot_icall_0_39(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLocalDescription, 852856452ul);

    /// <summary>
    /// <para>Sets the SDP description of the local peer. This should be called in response to <see cref="Godot.WebRtcPeerConnection.SessionDescriptionCreated"/>.</para>
    /// <para>After calling this function the peer will start emitting <see cref="Godot.WebRtcPeerConnection.IceCandidateCreated"/> (unless an <see cref="Godot.Error"/> different from <see cref="Godot.Error.Ok"/> is returned).</para>
    /// </summary>
    public Error SetLocalDescription(string type, string sdp)
    {
        return (Error)NativeCalls.godot_icall_2_330(MethodBind4, GodotObject.GetPtr(this), type, sdp);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRemoteDescription, 852856452ul);

    /// <summary>
    /// <para>Sets the SDP description of the remote peer. This should be called with the values generated by a remote peer and received over the signaling server.</para>
    /// <para>If <paramref name="type"/> is <c>"offer"</c> the peer will emit <see cref="Godot.WebRtcPeerConnection.SessionDescriptionCreated"/> with the appropriate answer.</para>
    /// <para>If <paramref name="type"/> is <c>"answer"</c> the peer will start emitting <see cref="Godot.WebRtcPeerConnection.IceCandidateCreated"/>.</para>
    /// </summary>
    public Error SetRemoteDescription(string type, string sdp)
    {
        return (Error)NativeCalls.godot_icall_2_330(MethodBind5, GodotObject.GetPtr(this), type, sdp);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddIceCandidate, 3958950400ul);

    /// <summary>
    /// <para>Add an ice candidate generated by a remote peer (and received over the signaling server). See <see cref="Godot.WebRtcPeerConnection.IceCandidateCreated"/>.</para>
    /// </summary>
    public Error AddIceCandidate(string media, int index, string name)
    {
        return (Error)NativeCalls.godot_icall_3_1502(MethodBind6, GodotObject.GetPtr(this), media, index, name);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Poll, 166280745ul);

    /// <summary>
    /// <para>Call this method frequently (e.g. in <see cref="Godot.Node._Process(double)"/> or <see cref="Godot.Node._PhysicsProcess(double)"/>) to properly receive signals.</para>
    /// </summary>
    public Error Poll()
    {
        return (Error)NativeCalls.godot_icall_0_39(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Close, 3218959716ul);

    /// <summary>
    /// <para>Close the peer connection and all data channels associated with it.</para>
    /// <para><b>Note:</b> You cannot reuse this object for a new connection unless you call <see cref="Godot.WebRtcPeerConnection.Initialize(Godot.Collections.Dictionary)"/>.</para>
    /// </summary>
    public void Close()
    {
        NativeCalls.godot_icall_0_3(MethodBind8, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetConnectionState, 2275710506ul);

    /// <summary>
    /// <para>Returns the connection state.</para>
    /// </summary>
    public WebRtcPeerConnection.ConnectionState GetConnectionState()
    {
        return (WebRtcPeerConnection.ConnectionState)NativeCalls.godot_icall_0_39(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetGatheringState, 4262591401ul);

    /// <summary>
    /// <para>Returns the ICE <see cref="Godot.WebRtcPeerConnection.GatheringState"/> of the connection. This lets you detect, for example, when collection of ICE candidates has finished.</para>
    /// </summary>
    public WebRtcPeerConnection.GatheringState GetGatheringState()
    {
        return (WebRtcPeerConnection.GatheringState)NativeCalls.godot_icall_0_39(MethodBind10, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSignalingState, 3342956226ul);

    /// <summary>
    /// <para>Returns the signaling state on the local end of the connection while connecting or reconnecting to another peer.</para>
    /// </summary>
    public WebRtcPeerConnection.SignalingState GetSignalingState()
    {
        return (WebRtcPeerConnection.SignalingState)NativeCalls.godot_icall_0_39(MethodBind11, GodotObject.GetPtr(this));
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.WebRtcPeerConnection.SessionDescriptionCreated"/> event of a <see cref="Godot.WebRtcPeerConnection"/> class.
    /// </summary>
    public delegate void SessionDescriptionCreatedEventHandler(string type, string sdp);

    private static void SessionDescriptionCreatedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 2);
        ((SessionDescriptionCreatedEventHandler)delegateObj)(VariantUtils.ConvertTo<string>(args[0]), VariantUtils.ConvertTo<string>(args[1]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted after a successful call to <see cref="Godot.WebRtcPeerConnection.CreateOffer()"/> or <see cref="Godot.WebRtcPeerConnection.SetRemoteDescription(string, string)"/> (when it generates an answer). The parameters are meant to be passed to <see cref="Godot.WebRtcPeerConnection.SetLocalDescription(string, string)"/> on this object, and sent to the remote peer over the signaling server.</para>
    /// </summary>
    public unsafe event SessionDescriptionCreatedEventHandler SessionDescriptionCreated
    {
        add => Connect(SignalName.SessionDescriptionCreated, Callable.CreateWithUnsafeTrampoline(value, &SessionDescriptionCreatedTrampoline));
        remove => Disconnect(SignalName.SessionDescriptionCreated, Callable.CreateWithUnsafeTrampoline(value, &SessionDescriptionCreatedTrampoline));
    }

    protected void EmitSignalSessionDescriptionCreated(string type, string sdp)
    {
        EmitSignal(SignalName.SessionDescriptionCreated, type, sdp);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.WebRtcPeerConnection.IceCandidateCreated"/> event of a <see cref="Godot.WebRtcPeerConnection"/> class.
    /// </summary>
    public delegate void IceCandidateCreatedEventHandler(string media, long index, string name);

    private static void IceCandidateCreatedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 3);
        ((IceCandidateCreatedEventHandler)delegateObj)(VariantUtils.ConvertTo<string>(args[0]), VariantUtils.ConvertTo<long>(args[1]), VariantUtils.ConvertTo<string>(args[2]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when a new ICE candidate has been created. The three parameters are meant to be passed to the remote peer over the signaling server.</para>
    /// </summary>
    public unsafe event IceCandidateCreatedEventHandler IceCandidateCreated
    {
        add => Connect(SignalName.IceCandidateCreated, Callable.CreateWithUnsafeTrampoline(value, &IceCandidateCreatedTrampoline));
        remove => Disconnect(SignalName.IceCandidateCreated, Callable.CreateWithUnsafeTrampoline(value, &IceCandidateCreatedTrampoline));
    }

    protected void EmitSignalIceCandidateCreated(string media, long index, string name)
    {
        EmitSignal(SignalName.IceCandidateCreated, media, index, name);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.WebRtcPeerConnection.DataChannelReceived"/> event of a <see cref="Godot.WebRtcPeerConnection"/> class.
    /// </summary>
    public delegate void DataChannelReceivedEventHandler(WebRtcDataChannel channel);

    private static void DataChannelReceivedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((DataChannelReceivedEventHandler)delegateObj)(VariantUtils.ConvertTo<WebRtcDataChannel>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when a new in-band channel is received, i.e. when the channel was created with <c>negotiated: false</c> (default).</para>
    /// <para>The object will be an instance of <see cref="Godot.WebRtcDataChannel"/>. You must keep a reference of it or it will be closed automatically. See <see cref="Godot.WebRtcPeerConnection.CreateDataChannel(string, Godot.Collections.Dictionary)"/>.</para>
    /// </summary>
    public unsafe event DataChannelReceivedEventHandler DataChannelReceived
    {
        add => Connect(SignalName.DataChannelReceived, Callable.CreateWithUnsafeTrampoline(value, &DataChannelReceivedTrampoline));
        remove => Disconnect(SignalName.DataChannelReceived, Callable.CreateWithUnsafeTrampoline(value, &DataChannelReceivedTrampoline));
    }

    protected void EmitSignalDataChannelReceived(WebRtcDataChannel channel)
    {
        EmitSignal(SignalName.DataChannelReceived, channel);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_session_description_created = "SessionDescriptionCreated";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_ice_candidate_created = "IceCandidateCreated";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_data_channel_received = "DataChannelReceived";

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
        if (signal == SignalName.SessionDescriptionCreated)
        {
            if (HasGodotClassSignal(SignalProxyName_session_description_created.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.IceCandidateCreated)
        {
            if (HasGodotClassSignal(SignalProxyName_ice_candidate_created.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.DataChannelReceived)
        {
            if (HasGodotClassSignal(SignalProxyName_data_channel_received.NativeValue.DangerousSelfRef))
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
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : RefCounted.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_default_extension' method.
        /// </summary>
        public static readonly StringName SetDefaultExtension = "set_default_extension";
        /// <summary>
        /// Cached name for the 'initialize' method.
        /// </summary>
        public static readonly StringName Initialize = "initialize";
        /// <summary>
        /// Cached name for the 'create_data_channel' method.
        /// </summary>
        public static readonly StringName CreateDataChannel = "create_data_channel";
        /// <summary>
        /// Cached name for the 'create_offer' method.
        /// </summary>
        public static readonly StringName CreateOffer = "create_offer";
        /// <summary>
        /// Cached name for the 'set_local_description' method.
        /// </summary>
        public static readonly StringName SetLocalDescription = "set_local_description";
        /// <summary>
        /// Cached name for the 'set_remote_description' method.
        /// </summary>
        public static readonly StringName SetRemoteDescription = "set_remote_description";
        /// <summary>
        /// Cached name for the 'add_ice_candidate' method.
        /// </summary>
        public static readonly StringName AddIceCandidate = "add_ice_candidate";
        /// <summary>
        /// Cached name for the 'poll' method.
        /// </summary>
        public static readonly StringName Poll = "poll";
        /// <summary>
        /// Cached name for the 'close' method.
        /// </summary>
        public static readonly StringName Close = "close";
        /// <summary>
        /// Cached name for the 'get_connection_state' method.
        /// </summary>
        public static readonly StringName GetConnectionState = "get_connection_state";
        /// <summary>
        /// Cached name for the 'get_gathering_state' method.
        /// </summary>
        public static readonly StringName GetGatheringState = "get_gathering_state";
        /// <summary>
        /// Cached name for the 'get_signaling_state' method.
        /// </summary>
        public static readonly StringName GetSignalingState = "get_signaling_state";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : RefCounted.SignalName
    {
        /// <summary>
        /// Cached name for the 'session_description_created' signal.
        /// </summary>
        public static readonly StringName SessionDescriptionCreated = "session_description_created";
        /// <summary>
        /// Cached name for the 'ice_candidate_created' signal.
        /// </summary>
        public static readonly StringName IceCandidateCreated = "ice_candidate_created";
        /// <summary>
        /// Cached name for the 'data_channel_received' signal.
        /// </summary>
        public static readonly StringName DataChannelReceived = "data_channel_received";
    }
}
