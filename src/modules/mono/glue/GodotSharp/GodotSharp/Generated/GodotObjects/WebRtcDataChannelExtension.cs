namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
[GodotClassName("WebRTCDataChannelExtension")]
public partial class WebRtcDataChannelExtension : WebRtcDataChannel
{
    private static readonly System.Type CachedType = typeof(WebRtcDataChannelExtension);

    private static readonly StringName NativeName = "WebRTCDataChannelExtension";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public WebRtcDataChannelExtension() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal WebRtcDataChannelExtension(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal WebRtcDataChannelExtension(bool memoryOwn) : base(memoryOwn) { }

    public virtual void _Close()
    {
    }

    public virtual int _GetAvailablePacketCount()
    {
        return default;
    }

    public virtual int _GetBufferedAmount()
    {
        return default;
    }

    public virtual int _GetId()
    {
        return default;
    }

    public virtual string _GetLabel()
    {
        return default;
    }

    public virtual int _GetMaxPacketLifeTime()
    {
        return default;
    }

    public virtual int _GetMaxPacketSize()
    {
        return default;
    }

    public virtual int _GetMaxRetransmits()
    {
        return default;
    }

    public virtual string _GetProtocol()
    {
        return default;
    }

    public virtual WebRtcDataChannel.ChannelState _GetReadyState()
    {
        return default;
    }

    public virtual WebRtcDataChannel.WriteModeEnum _GetWriteMode()
    {
        return default;
    }

    public virtual bool _IsNegotiated()
    {
        return default;
    }

    public virtual bool _IsOrdered()
    {
        return default;
    }

    public virtual Error _Poll()
    {
        return default;
    }

    public virtual void _SetWriteMode(WebRtcDataChannel.WriteModeEnum pWriteMode)
    {
    }

    public virtual bool _WasStringPacket()
    {
        return default;
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__close = "_Close";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_available_packet_count = "_GetAvailablePacketCount";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_buffered_amount = "_GetBufferedAmount";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_id = "_GetId";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_label = "_GetLabel";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_max_packet_life_time = "_GetMaxPacketLifeTime";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_max_packet_size = "_GetMaxPacketSize";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_max_retransmits = "_GetMaxRetransmits";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_protocol = "_GetProtocol";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_ready_state = "_GetReadyState";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_write_mode = "_GetWriteMode";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__is_negotiated = "_IsNegotiated";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__is_ordered = "_IsOrdered";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__poll = "_Poll";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__set_write_mode = "_SetWriteMode";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__was_string_packet = "_WasStringPacket";

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
        if ((method == MethodProxyName__close || method == MethodName._Close) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__close.NativeValue))
        {
            _Close();
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__get_available_packet_count || method == MethodName._GetAvailablePacketCount) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_available_packet_count.NativeValue))
        {
            var callRet = _GetAvailablePacketCount();
            ret = VariantUtils.CreateFrom<int>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_buffered_amount || method == MethodName._GetBufferedAmount) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_buffered_amount.NativeValue))
        {
            var callRet = _GetBufferedAmount();
            ret = VariantUtils.CreateFrom<int>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_id || method == MethodName._GetId) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_id.NativeValue))
        {
            var callRet = _GetId();
            ret = VariantUtils.CreateFrom<int>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_label || method == MethodName._GetLabel) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_label.NativeValue))
        {
            var callRet = _GetLabel();
            ret = VariantUtils.CreateFrom<string>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_max_packet_life_time || method == MethodName._GetMaxPacketLifeTime) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_max_packet_life_time.NativeValue))
        {
            var callRet = _GetMaxPacketLifeTime();
            ret = VariantUtils.CreateFrom<int>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_max_packet_size || method == MethodName._GetMaxPacketSize) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_max_packet_size.NativeValue))
        {
            var callRet = _GetMaxPacketSize();
            ret = VariantUtils.CreateFrom<int>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_max_retransmits || method == MethodName._GetMaxRetransmits) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_max_retransmits.NativeValue))
        {
            var callRet = _GetMaxRetransmits();
            ret = VariantUtils.CreateFrom<int>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_protocol || method == MethodName._GetProtocol) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_protocol.NativeValue))
        {
            var callRet = _GetProtocol();
            ret = VariantUtils.CreateFrom<string>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_ready_state || method == MethodName._GetReadyState) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_ready_state.NativeValue))
        {
            var callRet = _GetReadyState();
            ret = VariantUtils.CreateFrom<WebRtcDataChannel.ChannelState>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_write_mode || method == MethodName._GetWriteMode) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_write_mode.NativeValue))
        {
            var callRet = _GetWriteMode();
            ret = VariantUtils.CreateFrom<WebRtcDataChannel.WriteModeEnum>(callRet);
            return true;
        }
        if ((method == MethodProxyName__is_negotiated || method == MethodName._IsNegotiated) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__is_negotiated.NativeValue))
        {
            var callRet = _IsNegotiated();
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__is_ordered || method == MethodName._IsOrdered) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__is_ordered.NativeValue))
        {
            var callRet = _IsOrdered();
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__poll || method == MethodName._Poll) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__poll.NativeValue))
        {
            var callRet = _Poll();
            ret = VariantUtils.CreateFrom<Error>(callRet);
            return true;
        }
        if ((method == MethodProxyName__set_write_mode || method == MethodName._SetWriteMode) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__set_write_mode.NativeValue))
        {
            _SetWriteMode(VariantUtils.ConvertTo<WebRtcDataChannel.WriteModeEnum>(args[0]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__was_string_packet || method == MethodName._WasStringPacket) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__was_string_packet.NativeValue))
        {
            var callRet = _WasStringPacket();
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
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
        if (method == MethodName._Close)
        {
            if (HasGodotClassMethod(MethodProxyName__close.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetAvailablePacketCount)
        {
            if (HasGodotClassMethod(MethodProxyName__get_available_packet_count.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetBufferedAmount)
        {
            if (HasGodotClassMethod(MethodProxyName__get_buffered_amount.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetId)
        {
            if (HasGodotClassMethod(MethodProxyName__get_id.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetLabel)
        {
            if (HasGodotClassMethod(MethodProxyName__get_label.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetMaxPacketLifeTime)
        {
            if (HasGodotClassMethod(MethodProxyName__get_max_packet_life_time.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetMaxPacketSize)
        {
            if (HasGodotClassMethod(MethodProxyName__get_max_packet_size.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetMaxRetransmits)
        {
            if (HasGodotClassMethod(MethodProxyName__get_max_retransmits.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetProtocol)
        {
            if (HasGodotClassMethod(MethodProxyName__get_protocol.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetReadyState)
        {
            if (HasGodotClassMethod(MethodProxyName__get_ready_state.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetWriteMode)
        {
            if (HasGodotClassMethod(MethodProxyName__get_write_mode.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._IsNegotiated)
        {
            if (HasGodotClassMethod(MethodProxyName__is_negotiated.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._IsOrdered)
        {
            if (HasGodotClassMethod(MethodProxyName__is_ordered.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._Poll)
        {
            if (HasGodotClassMethod(MethodProxyName__poll.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._SetWriteMode)
        {
            if (HasGodotClassMethod(MethodProxyName__set_write_mode.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._WasStringPacket)
        {
            if (HasGodotClassMethod(MethodProxyName__was_string_packet.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
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
    public new class PropertyName : WebRtcDataChannel.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : WebRtcDataChannel.MethodName
    {
        /// <summary>
        /// Cached name for the '_close' method.
        /// </summary>
        public static readonly StringName _Close = "_close";
        /// <summary>
        /// Cached name for the '_get_available_packet_count' method.
        /// </summary>
        public static readonly StringName _GetAvailablePacketCount = "_get_available_packet_count";
        /// <summary>
        /// Cached name for the '_get_buffered_amount' method.
        /// </summary>
        public static readonly StringName _GetBufferedAmount = "_get_buffered_amount";
        /// <summary>
        /// Cached name for the '_get_id' method.
        /// </summary>
        public static readonly StringName _GetId = "_get_id";
        /// <summary>
        /// Cached name for the '_get_label' method.
        /// </summary>
        public static readonly StringName _GetLabel = "_get_label";
        /// <summary>
        /// Cached name for the '_get_max_packet_life_time' method.
        /// </summary>
        public static readonly StringName _GetMaxPacketLifeTime = "_get_max_packet_life_time";
        /// <summary>
        /// Cached name for the '_get_max_packet_size' method.
        /// </summary>
        public static readonly StringName _GetMaxPacketSize = "_get_max_packet_size";
        /// <summary>
        /// Cached name for the '_get_max_retransmits' method.
        /// </summary>
        public static readonly StringName _GetMaxRetransmits = "_get_max_retransmits";
        /// <summary>
        /// Cached name for the '_get_protocol' method.
        /// </summary>
        public static readonly StringName _GetProtocol = "_get_protocol";
        /// <summary>
        /// Cached name for the '_get_ready_state' method.
        /// </summary>
        public static readonly StringName _GetReadyState = "_get_ready_state";
        /// <summary>
        /// Cached name for the '_get_write_mode' method.
        /// </summary>
        public static readonly StringName _GetWriteMode = "_get_write_mode";
        /// <summary>
        /// Cached name for the '_is_negotiated' method.
        /// </summary>
        public static readonly StringName _IsNegotiated = "_is_negotiated";
        /// <summary>
        /// Cached name for the '_is_ordered' method.
        /// </summary>
        public static readonly StringName _IsOrdered = "_is_ordered";
        /// <summary>
        /// Cached name for the '_poll' method.
        /// </summary>
        public static readonly StringName _Poll = "_poll";
        /// <summary>
        /// Cached name for the '_set_write_mode' method.
        /// </summary>
        public static readonly StringName _SetWriteMode = "_set_write_mode";
        /// <summary>
        /// Cached name for the '_was_string_packet' method.
        /// </summary>
        public static readonly StringName _WasStringPacket = "_was_string_packet";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : WebRtcDataChannel.SignalName
    {
    }
}
