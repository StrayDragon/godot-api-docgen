namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
[GodotClassName("WebRTCDataChannel")]
public partial class WebRtcDataChannel : PacketPeer
{
    public enum WriteModeEnum : long
    {
        /// <summary>
        /// <para>Tells the channel to send data over this channel as text. An external peer (non-Godot) would receive this as a string.</para>
        /// </summary>
        Text = 0,
        /// <summary>
        /// <para>Tells the channel to send data over this channel as binary. An external peer (non-Godot) would receive this as array buffer or blob.</para>
        /// </summary>
        Binary = 1
    }

    public enum ChannelState : long
    {
        /// <summary>
        /// <para>The channel was created, but it's still trying to connect.</para>
        /// </summary>
        Connecting = 0,
        /// <summary>
        /// <para>The channel is currently open, and data can flow over it.</para>
        /// </summary>
        Open = 1,
        /// <summary>
        /// <para>The channel is being closed, no new messages will be accepted, but those already in queue will be flushed.</para>
        /// </summary>
        Closing = 2,
        /// <summary>
        /// <para>The channel was closed, or connection failed.</para>
        /// </summary>
        Closed = 3
    }

    /// <summary>
    /// <para>The transfer mode to use when sending outgoing packet. Either text or binary.</para>
    /// </summary>
    public WebRtcDataChannel.WriteModeEnum WriteMode
    {
        get
        {
            return GetWriteMode();
        }
        set
        {
            SetWriteMode(value);
        }
    }

    private static readonly System.Type CachedType = typeof(WebRtcDataChannel);

    private static readonly StringName NativeName = "WebRTCDataChannel";

    internal WebRtcDataChannel() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal WebRtcDataChannel(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal WebRtcDataChannel(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Poll, 166280745ul);

    /// <summary>
    /// <para>Reserved, but not used for now.</para>
    /// </summary>
    public Error Poll()
    {
        return (Error)NativeCalls.godot_icall_0_39(MethodBind0, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Close, 3218959716ul);

    /// <summary>
    /// <para>Closes this data channel, notifying the other peer.</para>
    /// </summary>
    public void Close()
    {
        NativeCalls.godot_icall_0_3(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.WasStringPacket, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the last received packet was transferred as text. See <see cref="Godot.WebRtcDataChannel.WriteMode"/>.</para>
    /// </summary>
    public bool WasStringPacket()
    {
        return NativeCalls.godot_icall_0_15(MethodBind2, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetWriteMode, 1999768052ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetWriteMode(WebRtcDataChannel.WriteModeEnum writeMode)
    {
        NativeCalls.godot_icall_1_38(MethodBind3, GodotObject.GetPtr(this), (int)writeMode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetWriteMode, 2848495172ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public WebRtcDataChannel.WriteModeEnum GetWriteMode()
    {
        return (WebRtcDataChannel.WriteModeEnum)NativeCalls.godot_icall_0_39(MethodBind4, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetReadyState, 3501143017ul);

    /// <summary>
    /// <para>Returns the current state of this channel.</para>
    /// </summary>
    public WebRtcDataChannel.ChannelState GetReadyState()
    {
        return (WebRtcDataChannel.ChannelState)NativeCalls.godot_icall_0_39(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLabel, 201670096ul);

    /// <summary>
    /// <para>Returns the label assigned to this channel during creation.</para>
    /// </summary>
    public string GetLabel()
    {
        return NativeCalls.godot_icall_0_58(MethodBind6, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsOrdered, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if this channel was created with ordering enabled (default).</para>
    /// </summary>
    public bool IsOrdered()
    {
        return NativeCalls.godot_icall_0_15(MethodBind7, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetId, 3905245786ul);

    /// <summary>
    /// <para>Returns the ID assigned to this channel during creation (or auto-assigned during negotiation).</para>
    /// <para>If the channel is not negotiated out-of-band the ID will only be available after the connection is established (will return <c>65535</c> until then).</para>
    /// </summary>
    public int GetId()
    {
        return NativeCalls.godot_icall_0_39(MethodBind8, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMaxPacketLifeTime, 3905245786ul);

    /// <summary>
    /// <para>Returns the <c>maxPacketLifeTime</c> value assigned to this channel during creation.</para>
    /// <para>Will be <c>65535</c> if not specified.</para>
    /// </summary>
    public int GetMaxPacketLifeTime()
    {
        return NativeCalls.godot_icall_0_39(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMaxRetransmits, 3905245786ul);

    /// <summary>
    /// <para>Returns the <c>maxRetransmits</c> value assigned to this channel during creation.</para>
    /// <para>Will be <c>65535</c> if not specified.</para>
    /// </summary>
    public int GetMaxRetransmits()
    {
        return NativeCalls.godot_icall_0_39(MethodBind10, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetProtocol, 201670096ul);

    /// <summary>
    /// <para>Returns the sub-protocol assigned to this channel during creation. An empty string if not specified.</para>
    /// </summary>
    public string GetProtocol()
    {
        return NativeCalls.godot_icall_0_58(MethodBind11, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsNegotiated, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if this channel was created with out-of-band configuration.</para>
    /// </summary>
    public bool IsNegotiated()
    {
        return NativeCalls.godot_icall_0_15(MethodBind12, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBufferedAmount, 3905245786ul);

    /// <summary>
    /// <para>Returns the number of bytes currently queued to be sent over this channel.</para>
    /// </summary>
    public int GetBufferedAmount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind13, GodotObject.GetPtr(this));
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
        /// <summary>
        /// Cached name for the 'write_mode' property.
        /// </summary>
        public static readonly StringName WriteMode = "write_mode";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : PacketPeer.MethodName
    {
        /// <summary>
        /// Cached name for the 'poll' method.
        /// </summary>
        public static readonly StringName Poll = "poll";
        /// <summary>
        /// Cached name for the 'close' method.
        /// </summary>
        public static readonly StringName Close = "close";
        /// <summary>
        /// Cached name for the 'was_string_packet' method.
        /// </summary>
        public static readonly StringName WasStringPacket = "was_string_packet";
        /// <summary>
        /// Cached name for the 'set_write_mode' method.
        /// </summary>
        public static readonly StringName SetWriteMode = "set_write_mode";
        /// <summary>
        /// Cached name for the 'get_write_mode' method.
        /// </summary>
        public static readonly StringName GetWriteMode = "get_write_mode";
        /// <summary>
        /// Cached name for the 'get_ready_state' method.
        /// </summary>
        public static readonly StringName GetReadyState = "get_ready_state";
        /// <summary>
        /// Cached name for the 'get_label' method.
        /// </summary>
        public static readonly StringName GetLabel = "get_label";
        /// <summary>
        /// Cached name for the 'is_ordered' method.
        /// </summary>
        public static readonly StringName IsOrdered = "is_ordered";
        /// <summary>
        /// Cached name for the 'get_id' method.
        /// </summary>
        public static readonly StringName GetId = "get_id";
        /// <summary>
        /// Cached name for the 'get_max_packet_life_time' method.
        /// </summary>
        public static readonly StringName GetMaxPacketLifeTime = "get_max_packet_life_time";
        /// <summary>
        /// Cached name for the 'get_max_retransmits' method.
        /// </summary>
        public static readonly StringName GetMaxRetransmits = "get_max_retransmits";
        /// <summary>
        /// Cached name for the 'get_protocol' method.
        /// </summary>
        public static readonly StringName GetProtocol = "get_protocol";
        /// <summary>
        /// Cached name for the 'is_negotiated' method.
        /// </summary>
        public static readonly StringName IsNegotiated = "is_negotiated";
        /// <summary>
        /// Cached name for the 'get_buffered_amount' method.
        /// </summary>
        public static readonly StringName GetBufferedAmount = "get_buffered_amount";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : PacketPeer.SignalName
    {
    }
}
