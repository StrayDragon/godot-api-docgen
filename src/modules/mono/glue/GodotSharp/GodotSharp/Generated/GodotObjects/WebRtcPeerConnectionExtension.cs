namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
[GodotClassName("WebRTCPeerConnectionExtension")]
public partial class WebRtcPeerConnectionExtension : WebRtcPeerConnection
{
    private static readonly System.Type CachedType = typeof(WebRtcPeerConnectionExtension);

    private static readonly StringName NativeName = "WebRTCPeerConnectionExtension";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public WebRtcPeerConnectionExtension() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal WebRtcPeerConnectionExtension(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal WebRtcPeerConnectionExtension(bool memoryOwn) : base(memoryOwn) { }

    public virtual Error _AddIceCandidate(string pSdpMidName, int pSdpMlineIndex, string pSdpName)
    {
        return default;
    }

    public virtual void _Close()
    {
    }

    public virtual WebRtcDataChannel _CreateDataChannel(string pLabel, Godot.Collections.Dictionary pConfig)
    {
        return default;
    }

    public virtual Error _CreateOffer()
    {
        return default;
    }

    public virtual WebRtcPeerConnection.ConnectionState _GetConnectionState()
    {
        return default;
    }

    public virtual WebRtcPeerConnection.GatheringState _GetGatheringState()
    {
        return default;
    }

    public virtual WebRtcPeerConnection.SignalingState _GetSignalingState()
    {
        return default;
    }

    public virtual Error _Initialize(Godot.Collections.Dictionary pConfig)
    {
        return default;
    }

    public virtual Error _Poll()
    {
        return default;
    }

    public virtual Error _SetLocalDescription(string pType, string pSdp)
    {
        return default;
    }

    public virtual Error _SetRemoteDescription(string pType, string pSdp)
    {
        return default;
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__add_ice_candidate = "_AddIceCandidate";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__close = "_Close";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__create_data_channel = "_CreateDataChannel";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__create_offer = "_CreateOffer";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_connection_state = "_GetConnectionState";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_gathering_state = "_GetGatheringState";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_signaling_state = "_GetSignalingState";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__initialize = "_Initialize";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__poll = "_Poll";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__set_local_description = "_SetLocalDescription";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__set_remote_description = "_SetRemoteDescription";

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
        if ((method == MethodProxyName__add_ice_candidate || method == MethodName._AddIceCandidate) && args.Count == 3 && HasGodotClassMethod((godot_string_name)MethodProxyName__add_ice_candidate.NativeValue))
        {
            var callRet = _AddIceCandidate(VariantUtils.ConvertTo<string>(args[0]), VariantUtils.ConvertTo<int>(args[1]), VariantUtils.ConvertTo<string>(args[2]));
            ret = VariantUtils.CreateFrom<Error>(callRet);
            return true;
        }
        if ((method == MethodProxyName__close || method == MethodName._Close) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__close.NativeValue))
        {
            _Close();
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__create_data_channel || method == MethodName._CreateDataChannel) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__create_data_channel.NativeValue))
        {
            var callRet = _CreateDataChannel(VariantUtils.ConvertTo<string>(args[0]), VariantUtils.ConvertTo<Godot.Collections.Dictionary>(args[1]));
            ret = VariantUtils.CreateFrom<WebRtcDataChannel>(callRet);
            return true;
        }
        if ((method == MethodProxyName__create_offer || method == MethodName._CreateOffer) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__create_offer.NativeValue))
        {
            var callRet = _CreateOffer();
            ret = VariantUtils.CreateFrom<Error>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_connection_state || method == MethodName._GetConnectionState) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_connection_state.NativeValue))
        {
            var callRet = _GetConnectionState();
            ret = VariantUtils.CreateFrom<WebRtcPeerConnection.ConnectionState>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_gathering_state || method == MethodName._GetGatheringState) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_gathering_state.NativeValue))
        {
            var callRet = _GetGatheringState();
            ret = VariantUtils.CreateFrom<WebRtcPeerConnection.GatheringState>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_signaling_state || method == MethodName._GetSignalingState) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_signaling_state.NativeValue))
        {
            var callRet = _GetSignalingState();
            ret = VariantUtils.CreateFrom<WebRtcPeerConnection.SignalingState>(callRet);
            return true;
        }
        if ((method == MethodProxyName__initialize || method == MethodName._Initialize) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__initialize.NativeValue))
        {
            var callRet = _Initialize(VariantUtils.ConvertTo<Godot.Collections.Dictionary>(args[0]));
            ret = VariantUtils.CreateFrom<Error>(callRet);
            return true;
        }
        if ((method == MethodProxyName__poll || method == MethodName._Poll) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__poll.NativeValue))
        {
            var callRet = _Poll();
            ret = VariantUtils.CreateFrom<Error>(callRet);
            return true;
        }
        if ((method == MethodProxyName__set_local_description || method == MethodName._SetLocalDescription) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__set_local_description.NativeValue))
        {
            var callRet = _SetLocalDescription(VariantUtils.ConvertTo<string>(args[0]), VariantUtils.ConvertTo<string>(args[1]));
            ret = VariantUtils.CreateFrom<Error>(callRet);
            return true;
        }
        if ((method == MethodProxyName__set_remote_description || method == MethodName._SetRemoteDescription) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__set_remote_description.NativeValue))
        {
            var callRet = _SetRemoteDescription(VariantUtils.ConvertTo<string>(args[0]), VariantUtils.ConvertTo<string>(args[1]));
            ret = VariantUtils.CreateFrom<Error>(callRet);
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
        if (method == MethodName._AddIceCandidate)
        {
            if (HasGodotClassMethod(MethodProxyName__add_ice_candidate.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._Close)
        {
            if (HasGodotClassMethod(MethodProxyName__close.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._CreateDataChannel)
        {
            if (HasGodotClassMethod(MethodProxyName__create_data_channel.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._CreateOffer)
        {
            if (HasGodotClassMethod(MethodProxyName__create_offer.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetConnectionState)
        {
            if (HasGodotClassMethod(MethodProxyName__get_connection_state.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetGatheringState)
        {
            if (HasGodotClassMethod(MethodProxyName__get_gathering_state.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetSignalingState)
        {
            if (HasGodotClassMethod(MethodProxyName__get_signaling_state.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._Initialize)
        {
            if (HasGodotClassMethod(MethodProxyName__initialize.NativeValue.DangerousSelfRef))
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
        if (method == MethodName._SetLocalDescription)
        {
            if (HasGodotClassMethod(MethodProxyName__set_local_description.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._SetRemoteDescription)
        {
            if (HasGodotClassMethod(MethodProxyName__set_remote_description.NativeValue.DangerousSelfRef))
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
    public new class PropertyName : WebRtcPeerConnection.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : WebRtcPeerConnection.MethodName
    {
        /// <summary>
        /// Cached name for the '_add_ice_candidate' method.
        /// </summary>
        public static readonly StringName _AddIceCandidate = "_add_ice_candidate";
        /// <summary>
        /// Cached name for the '_close' method.
        /// </summary>
        public static readonly StringName _Close = "_close";
        /// <summary>
        /// Cached name for the '_create_data_channel' method.
        /// </summary>
        public static readonly StringName _CreateDataChannel = "_create_data_channel";
        /// <summary>
        /// Cached name for the '_create_offer' method.
        /// </summary>
        public static readonly StringName _CreateOffer = "_create_offer";
        /// <summary>
        /// Cached name for the '_get_connection_state' method.
        /// </summary>
        public static readonly StringName _GetConnectionState = "_get_connection_state";
        /// <summary>
        /// Cached name for the '_get_gathering_state' method.
        /// </summary>
        public static readonly StringName _GetGatheringState = "_get_gathering_state";
        /// <summary>
        /// Cached name for the '_get_signaling_state' method.
        /// </summary>
        public static readonly StringName _GetSignalingState = "_get_signaling_state";
        /// <summary>
        /// Cached name for the '_initialize' method.
        /// </summary>
        public static readonly StringName _Initialize = "_initialize";
        /// <summary>
        /// Cached name for the '_poll' method.
        /// </summary>
        public static readonly StringName _Poll = "_poll";
        /// <summary>
        /// Cached name for the '_set_local_description' method.
        /// </summary>
        public static readonly StringName _SetLocalDescription = "_set_local_description";
        /// <summary>
        /// Cached name for the '_set_remote_description' method.
        /// </summary>
        public static readonly StringName _SetRemoteDescription = "_set_remote_description";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : WebRtcPeerConnection.SignalName
    {
    }
}
