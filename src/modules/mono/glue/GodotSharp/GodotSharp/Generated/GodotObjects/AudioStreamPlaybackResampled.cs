namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
public partial class AudioStreamPlaybackResampled : AudioStreamPlayback
{
    private static readonly System.Type CachedType = typeof(AudioStreamPlaybackResampled);

    private static readonly StringName NativeName = "AudioStreamPlaybackResampled";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public AudioStreamPlaybackResampled() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal AudioStreamPlaybackResampled(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal AudioStreamPlaybackResampled(bool memoryOwn) : base(memoryOwn) { }

    public virtual float _GetStreamSamplingRate()
    {
        return default;
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BeginResample, 3218959716ul);

    public void BeginResample()
    {
        NativeCalls.godot_icall_0_3(MethodBind0, GodotObject.GetPtr(this));
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_stream_sampling_rate = "_GetStreamSamplingRate";

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
        if ((method == MethodProxyName__get_stream_sampling_rate || method == MethodName._GetStreamSamplingRate) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_stream_sampling_rate.NativeValue))
        {
            var callRet = _GetStreamSamplingRate();
            ret = VariantUtils.CreateFrom<float>(callRet);
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
        if (method == MethodName._GetStreamSamplingRate)
        {
            if (HasGodotClassMethod(MethodProxyName__get_stream_sampling_rate.NativeValue.DangerousSelfRef))
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
    public new class PropertyName : AudioStreamPlayback.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : AudioStreamPlayback.MethodName
    {
        /// <summary>
        /// Cached name for the '_get_stream_sampling_rate' method.
        /// </summary>
        public static readonly StringName _GetStreamSamplingRate = "_get_stream_sampling_rate";
        /// <summary>
        /// Cached name for the 'begin_resample' method.
        /// </summary>
        public static readonly StringName BeginResample = "begin_resample";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : AudioStreamPlayback.SignalName
    {
    }
}
