namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A PacketPeer implementation representing a peer of an <see cref="Godot.ENetConnection"/>.</para>
/// <para>This class cannot be instantiated directly but can be retrieved during <see cref="Godot.ENetConnection.Service(int)"/> or via <see cref="Godot.ENetConnection.GetPeers()"/>.</para>
/// <para><b>Note:</b> When exporting to Android, make sure to enable the <c>INTERNET</c> permission in the Android export preset before exporting the project or using one-click deploy. Otherwise, network communication of any kind will be blocked by Android.</para>
/// </summary>
public partial class ENetPacketPeer : PacketPeer
{
    /// <summary>
    /// <para>The reference scale for packet loss. See <see cref="Godot.ENetPacketPeer.GetStatistic(ENetPacketPeer.PeerStatistic)"/> and <see cref="Godot.ENetPacketPeer.PeerStatistic.PacketLoss"/>.</para>
    /// </summary>
    public const long PacketLossScale = 65536;
    /// <summary>
    /// <para>The reference value for throttle configuration. The default value is <c>32</c>. See <see cref="Godot.ENetPacketPeer.ThrottleConfigure(int, int, int)"/>.</para>
    /// </summary>
    public const long PacketThrottleScale = 32;
    /// <summary>
    /// <para>Mark the packet to be sent as reliable.</para>
    /// </summary>
    public const long FlagReliable = 1;
    /// <summary>
    /// <para>Mark the packet to be sent unsequenced (unreliable).</para>
    /// </summary>
    public const long FlagUnsequenced = 2;
    /// <summary>
    /// <para>Mark the packet to be sent unreliable even if the packet is too big and needs fragmentation (increasing the chance of it being dropped).</para>
    /// </summary>
    public const long FlagUnreliableFragment = 8;

    public enum PeerState : long
    {
        /// <summary>
        /// <para>The peer is disconnected.</para>
        /// </summary>
        Disconnected = 0,
        /// <summary>
        /// <para>The peer is currently attempting to connect.</para>
        /// </summary>
        Connecting = 1,
        /// <summary>
        /// <para>The peer has acknowledged the connection request.</para>
        /// </summary>
        AcknowledgingConnect = 2,
        /// <summary>
        /// <para>The peer is currently connecting.</para>
        /// </summary>
        ConnectionPending = 3,
        /// <summary>
        /// <para>The peer has successfully connected, but is not ready to communicate with yet (<see cref="Godot.ENetPacketPeer.PeerState.Connected"/>).</para>
        /// </summary>
        ConnectionSucceeded = 4,
        /// <summary>
        /// <para>The peer is currently connected and ready to communicate with.</para>
        /// </summary>
        Connected = 5,
        /// <summary>
        /// <para>The peer is expected to disconnect after it has no more outgoing packets to send.</para>
        /// </summary>
        DisconnectLater = 6,
        /// <summary>
        /// <para>The peer is currently disconnecting.</para>
        /// </summary>
        Disconnecting = 7,
        /// <summary>
        /// <para>The peer has acknowledged the disconnection request.</para>
        /// </summary>
        AcknowledgingDisconnect = 8,
        /// <summary>
        /// <para>The peer has lost connection, but is not considered truly disconnected (as the peer didn't acknowledge the disconnection request).</para>
        /// </summary>
        Zombie = 9
    }

    public enum PeerStatistic : long
    {
        /// <summary>
        /// <para>Mean packet loss of reliable packets as a ratio with respect to the <see cref="Godot.ENetPacketPeer.PacketLossScale"/>.</para>
        /// </summary>
        PacketLoss = 0,
        /// <summary>
        /// <para>Packet loss variance.</para>
        /// </summary>
        PacketLossVariance = 1,
        /// <summary>
        /// <para>The time at which packet loss statistics were last updated (in milliseconds since the connection started). The interval for packet loss statistics updates is 10 seconds, and at least one packet must have been sent since the last statistics update.</para>
        /// </summary>
        PacketLossEpoch = 2,
        /// <summary>
        /// <para>Mean packet round trip time for reliable packets.</para>
        /// </summary>
        RoundTripTime = 3,
        /// <summary>
        /// <para>Variance of the mean round trip time.</para>
        /// </summary>
        RoundTripTimeVariance = 4,
        /// <summary>
        /// <para>Last recorded round trip time for a reliable packet.</para>
        /// </summary>
        LastRoundTripTime = 5,
        /// <summary>
        /// <para>Variance of the last trip time recorded.</para>
        /// </summary>
        LastRoundTripTimeVariance = 6,
        /// <summary>
        /// <para>The peer's current throttle status.</para>
        /// </summary>
        PacketThrottle = 7,
        /// <summary>
        /// <para>The maximum number of unreliable packets that should not be dropped. This value is always greater than or equal to <c>1</c>. The initial value is equal to <see cref="Godot.ENetPacketPeer.PacketThrottleScale"/>.</para>
        /// </summary>
        PacketThrottleLimit = 8,
        /// <summary>
        /// <para>Internal value used to increment the packet throttle counter. The value is hardcoded to <c>7</c> and cannot be changed. You probably want to look at <see cref="Godot.ENetPacketPeer.PeerStatistic.PacketThrottleAcceleration"/> instead.</para>
        /// </summary>
        PacketThrottleCounter = 9,
        /// <summary>
        /// <para>The time at which throttle statistics were last updated (in milliseconds since the connection started). The interval for throttle statistics updates is <see cref="Godot.ENetPacketPeer.PeerStatistic.PacketThrottleInterval"/>.</para>
        /// </summary>
        PacketThrottleEpoch = 10,
        /// <summary>
        /// <para>The throttle's acceleration factor. Higher values will make ENet adapt to fluctuating network conditions faster, causing unrelaible packets to be sent <i>more</i> often. The default value is <c>2</c>.</para>
        /// </summary>
        PacketThrottleAcceleration = 11,
        /// <summary>
        /// <para>The throttle's deceleration factor. Higher values will make ENet adapt to fluctuating network conditions faster, causing unrelaible packets to be sent <i>less</i> often. The default value is <c>2</c>.</para>
        /// </summary>
        PacketThrottleDeceleration = 12,
        /// <summary>
        /// <para>The interval over which the lowest mean round trip time should be measured for use by the throttle mechanism (in milliseconds). The default value is <c>5000</c>.</para>
        /// </summary>
        PacketThrottleInterval = 13
    }

    private static readonly System.Type CachedType = typeof(ENetPacketPeer);

    private static readonly StringName NativeName = "ENetPacketPeer";

    internal ENetPacketPeer() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal ENetPacketPeer(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal ENetPacketPeer(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PeerDisconnect, 1995695955ul);

    /// <summary>
    /// <para>Request a disconnection from a peer. An <see cref="Godot.ENetConnection.EventType.Disconnect"/> will be generated during <see cref="Godot.ENetConnection.Service(int)"/> once the disconnection is complete.</para>
    /// </summary>
    public void PeerDisconnect(int data = 0)
    {
        NativeCalls.godot_icall_1_38(MethodBind0, GodotObject.GetPtr(this), data);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PeerDisconnectLater, 1995695955ul);

    /// <summary>
    /// <para>Request a disconnection from a peer, but only after all queued outgoing packets are sent. An <see cref="Godot.ENetConnection.EventType.Disconnect"/> will be generated during <see cref="Godot.ENetConnection.Service(int)"/> once the disconnection is complete.</para>
    /// </summary>
    public void PeerDisconnectLater(int data = 0)
    {
        NativeCalls.godot_icall_1_38(MethodBind1, GodotObject.GetPtr(this), data);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PeerDisconnectNow, 1995695955ul);

    /// <summary>
    /// <para>Force an immediate disconnection from a peer. No <see cref="Godot.ENetConnection.EventType.Disconnect"/> will be generated. The foreign peer is not guaranteed to receive the disconnect notification, and is reset immediately upon return from this function.</para>
    /// </summary>
    public void PeerDisconnectNow(int data = 0)
    {
        NativeCalls.godot_icall_1_38(MethodBind2, GodotObject.GetPtr(this), data);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Ping, 3218959716ul);

    /// <summary>
    /// <para>Sends a ping request to a peer. ENet automatically pings all connected peers at regular intervals, however, this function may be called to ensure more frequent ping requests.</para>
    /// </summary>
    public void Ping()
    {
        NativeCalls.godot_icall_0_3(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PingInterval, 1286410249ul);

    /// <summary>
    /// <para>Sets the <paramref name="pingInterval"/> in milliseconds at which pings will be sent to a peer. Pings are used both to monitor the liveness of the connection and also to dynamically adjust the throttle during periods of low traffic so that the throttle has reasonable responsiveness during traffic spikes. The default ping interval is <c>500</c> milliseconds.</para>
    /// </summary>
    public void PingInterval(int pingInterval)
    {
        NativeCalls.godot_icall_1_38(MethodBind4, GodotObject.GetPtr(this), pingInterval);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Reset, 3218959716ul);

    /// <summary>
    /// <para>Forcefully disconnects a peer. The foreign host represented by the peer is not notified of the disconnection and will timeout on its connection to the local host.</para>
    /// </summary>
    public void Reset()
    {
        NativeCalls.godot_icall_0_3(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Send, 120522849ul);

    /// <summary>
    /// <para>Queues a <paramref name="packet"/> to be sent over the specified <paramref name="channel"/>. See <c>FLAG_*</c> constants for available packet flags.</para>
    /// </summary>
    public Error Send(int channel, byte[] packet, int flags)
    {
        return (Error)NativeCalls.godot_icall_3_464(MethodBind6, GodotObject.GetPtr(this), channel, packet, flags);
    }

    /// <summary>
    /// <para>Queues a <paramref name="packet"/> to be sent over the specified <paramref name="channel"/>. See <c>FLAG_*</c> constants for available packet flags.</para>
    /// </summary>
    public Error Send(int channel, ReadOnlySpan<byte> packet, int flags)
    {
        return (Error)NativeCalls.godot_icall_3_464(MethodBind6, GodotObject.GetPtr(this), channel, packet, flags);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ThrottleConfigure, 1649997291ul);

    /// <summary>
    /// <para>Configures throttle parameter for a peer.</para>
    /// <para>Unreliable packets are dropped by ENet in response to the varying conditions of the Internet connection to the peer. The throttle represents a probability that an unreliable packet should not be dropped and thus sent by ENet to the peer. By measuring fluctuations in round trip times of reliable packets over the specified <paramref name="interval"/>, ENet will either increase the probability by the amount specified in the <paramref name="acceleration"/> parameter, or decrease it by the amount specified in the <paramref name="deceleration"/> parameter (both are ratios to <see cref="Godot.ENetPacketPeer.PacketThrottleScale"/>).</para>
    /// <para>When the throttle has a value of <see cref="Godot.ENetPacketPeer.PacketThrottleScale"/>, no unreliable packets are dropped by ENet, and so 100% of all unreliable packets will be sent.</para>
    /// <para>When the throttle has a value of <c>0</c>, all unreliable packets are dropped by ENet, and so 0% of all unreliable packets will be sent.</para>
    /// <para>Intermediate values for the throttle represent intermediate probabilities between 0% and 100% of unreliable packets being sent. The bandwidth limits of the local and foreign hosts are taken into account to determine a sensible limit for the throttle probability above which it should not raise even in the best of conditions.</para>
    /// </summary>
    public void ThrottleConfigure(int interval, int acceleration, int deceleration)
    {
        NativeCalls.godot_icall_3_196(MethodBind7, GodotObject.GetPtr(this), interval, acceleration, deceleration);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTimeout, 1649997291ul);

    /// <summary>
    /// <para>Sets the timeout parameters for a peer. The timeout parameters control how and when a peer will timeout from a failure to acknowledge reliable traffic. Timeout values are expressed in milliseconds.</para>
    /// <para>The <paramref name="timeout"/> is a factor that, multiplied by a value based on the average round trip time, will determine the timeout limit for a reliable packet. When that limit is reached, the timeout will be doubled, and the peer will be disconnected if that limit has reached <paramref name="timeoutMin"/>. The <paramref name="timeoutMax"/> parameter, on the other hand, defines a fixed timeout for which any packet must be acknowledged or the peer will be dropped.</para>
    /// </summary>
    public void SetTimeout(int timeout, int timeoutMin, int timeoutMax)
    {
        NativeCalls.godot_icall_3_196(MethodBind8, GodotObject.GetPtr(this), timeout, timeoutMin, timeoutMax);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPacketFlags, 3905245786ul);

    /// <summary>
    /// <para>Returns the ENet flags of the next packet in the received queue. See <c>FLAG_*</c> constants for available packet flags. Note that not all flags are replicated from the sending peer to the receiving peer.</para>
    /// </summary>
    public int GetPacketFlags()
    {
        return NativeCalls.godot_icall_0_39(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRemoteAddress, 201670096ul);

    /// <summary>
    /// <para>Returns the IP address of this peer.</para>
    /// </summary>
    public string GetRemoteAddress()
    {
        return NativeCalls.godot_icall_0_58(MethodBind10, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRemotePort, 3905245786ul);

    /// <summary>
    /// <para>Returns the remote port of this peer.</para>
    /// </summary>
    public int GetRemotePort()
    {
        return NativeCalls.godot_icall_0_39(MethodBind11, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetStatistic, 1642578323ul);

    /// <summary>
    /// <para>Returns the requested <paramref name="statistic"/> for this peer.</para>
    /// </summary>
    public double GetStatistic(ENetPacketPeer.PeerStatistic statistic)
    {
        return NativeCalls.godot_icall_1_460(MethodBind12, GodotObject.GetPtr(this), (int)statistic);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetState, 711068532ul);

    /// <summary>
    /// <para>Returns the current peer state.</para>
    /// </summary>
    public ENetPacketPeer.PeerState GetState()
    {
        return (ENetPacketPeer.PeerState)NativeCalls.godot_icall_0_39(MethodBind13, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetChannels, 3905245786ul);

    /// <summary>
    /// <para>Returns the number of channels allocated for communication with peer.</para>
    /// </summary>
    public int GetChannels()
    {
        return NativeCalls.godot_icall_0_39(MethodBind14, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsActive, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the peer is currently active (i.e. the associated <see cref="Godot.ENetConnection"/> is still valid).</para>
    /// </summary>
    public bool IsActive()
    {
        return NativeCalls.godot_icall_0_15(MethodBind15, GodotObject.GetPtr(this)).ToBool();
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
        /// Cached name for the 'peer_disconnect' method.
        /// </summary>
        public static readonly StringName PeerDisconnect = "peer_disconnect";
        /// <summary>
        /// Cached name for the 'peer_disconnect_later' method.
        /// </summary>
        public static readonly StringName PeerDisconnectLater = "peer_disconnect_later";
        /// <summary>
        /// Cached name for the 'peer_disconnect_now' method.
        /// </summary>
        public static readonly StringName PeerDisconnectNow = "peer_disconnect_now";
        /// <summary>
        /// Cached name for the 'ping' method.
        /// </summary>
        public static readonly StringName Ping = "ping";
        /// <summary>
        /// Cached name for the 'ping_interval' method.
        /// </summary>
        public static readonly StringName PingInterval = "ping_interval";
        /// <summary>
        /// Cached name for the 'reset' method.
        /// </summary>
        public static readonly StringName Reset = "reset";
        /// <summary>
        /// Cached name for the 'send' method.
        /// </summary>
        public static readonly StringName Send = "send";
        /// <summary>
        /// Cached name for the 'throttle_configure' method.
        /// </summary>
        public static readonly StringName ThrottleConfigure = "throttle_configure";
        /// <summary>
        /// Cached name for the 'set_timeout' method.
        /// </summary>
        public static readonly StringName SetTimeout = "set_timeout";
        /// <summary>
        /// Cached name for the 'get_packet_flags' method.
        /// </summary>
        public static readonly StringName GetPacketFlags = "get_packet_flags";
        /// <summary>
        /// Cached name for the 'get_remote_address' method.
        /// </summary>
        public static readonly StringName GetRemoteAddress = "get_remote_address";
        /// <summary>
        /// Cached name for the 'get_remote_port' method.
        /// </summary>
        public static readonly StringName GetRemotePort = "get_remote_port";
        /// <summary>
        /// Cached name for the 'get_statistic' method.
        /// </summary>
        public static readonly StringName GetStatistic = "get_statistic";
        /// <summary>
        /// Cached name for the 'get_state' method.
        /// </summary>
        public static readonly StringName GetState = "get_state";
        /// <summary>
        /// Cached name for the 'get_channels' method.
        /// </summary>
        public static readonly StringName GetChannels = "get_channels";
        /// <summary>
        /// Cached name for the 'is_active' method.
        /// </summary>
        public static readonly StringName IsActive = "is_active";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : PacketPeer.SignalName
    {
    }
}
