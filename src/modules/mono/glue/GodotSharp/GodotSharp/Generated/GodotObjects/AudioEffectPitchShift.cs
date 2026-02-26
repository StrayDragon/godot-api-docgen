namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Allows modulation of pitch independently of tempo. All frequencies can be increased/decreased with minimal effect on transients.</para>
/// </summary>
public partial class AudioEffectPitchShift : AudioEffect
{
    public enum FftSizeEnum : long
    {
        /// <summary>
        /// <para>Use a buffer of 256 samples for the Fast Fourier transform. Lowest latency, but least stable over time.</para>
        /// </summary>
        Size256 = 0,
        /// <summary>
        /// <para>Use a buffer of 512 samples for the Fast Fourier transform. Low latency, but less stable over time.</para>
        /// </summary>
        Size512 = 1,
        /// <summary>
        /// <para>Use a buffer of 1024 samples for the Fast Fourier transform. This is a compromise between latency and stability over time.</para>
        /// </summary>
        Size1024 = 2,
        /// <summary>
        /// <para>Use a buffer of 2048 samples for the Fast Fourier transform. High latency, but stable over time.</para>
        /// </summary>
        Size2048 = 3,
        /// <summary>
        /// <para>Use a buffer of 4096 samples for the Fast Fourier transform. Highest latency, but most stable over time.</para>
        /// </summary>
        Size4096 = 4,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.AudioEffectPitchShift.FftSizeEnum"/> enum.</para>
        /// </summary>
        Max = 5
    }

    /// <summary>
    /// <para>The pitch scale to use. <c>1.0</c> is the default pitch and plays sounds unaffected. <see cref="Godot.AudioEffectPitchShift.PitchScale"/> can range from <c>0.0</c> (infinitely low pitch, inaudible) to <c>16</c> (16 times higher than the initial pitch).</para>
    /// </summary>
    public float PitchScale
    {
        get
        {
            return GetPitchScale();
        }
        set
        {
            SetPitchScale(value);
        }
    }

    /// <summary>
    /// <para>The oversampling factor to use. Higher values result in better quality, but are more demanding on the CPU and may cause audio cracking if the CPU can't keep up.</para>
    /// </summary>
    public int Oversampling
    {
        get
        {
            return GetOversampling();
        }
        set
        {
            SetOversampling(value);
        }
    }

    /// <summary>
    /// <para>The size of the <a href="https://en.wikipedia.org/wiki/Fast_Fourier_transform">Fast Fourier transform</a> buffer. Higher values smooth out the effect over time, but have greater latency. The effects of this higher latency are especially noticeable on sounds that have sudden amplitude changes.</para>
    /// </summary>
    public AudioEffectPitchShift.FftSizeEnum FftSize
    {
        get
        {
            return GetFftSize();
        }
        set
        {
            SetFftSize(value);
        }
    }

    private static readonly System.Type CachedType = typeof(AudioEffectPitchShift);

    private static readonly StringName NativeName = "AudioEffectPitchShift";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public AudioEffectPitchShift() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal AudioEffectPitchShift(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal AudioEffectPitchShift(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPitchScale, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPitchScale(float rate)
    {
        NativeCalls.godot_icall_1_67(MethodBind0, GodotObject.GetPtr(this), rate);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPitchScale, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetPitchScale()
    {
        return NativeCalls.godot_icall_0_68(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetOversampling, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetOversampling(int amount)
    {
        NativeCalls.godot_icall_1_38(MethodBind2, GodotObject.GetPtr(this), amount);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOversampling, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetOversampling()
    {
        return NativeCalls.godot_icall_0_39(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFftSize, 2323518741ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFftSize(AudioEffectPitchShift.FftSizeEnum size)
    {
        NativeCalls.godot_icall_1_38(MethodBind4, GodotObject.GetPtr(this), (int)size);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFftSize, 2361246789ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public AudioEffectPitchShift.FftSizeEnum GetFftSize()
    {
        return (AudioEffectPitchShift.FftSizeEnum)NativeCalls.godot_icall_0_39(MethodBind5, GodotObject.GetPtr(this));
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
    public new class PropertyName : AudioEffect.PropertyName
    {
        /// <summary>
        /// Cached name for the 'pitch_scale' property.
        /// </summary>
        public static readonly StringName PitchScale = "pitch_scale";
        /// <summary>
        /// Cached name for the 'oversampling' property.
        /// </summary>
        public static readonly StringName Oversampling = "oversampling";
        /// <summary>
        /// Cached name for the 'fft_size' property.
        /// </summary>
        public static readonly StringName FftSize = "fft_size";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : AudioEffect.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_pitch_scale' method.
        /// </summary>
        public static readonly StringName SetPitchScale = "set_pitch_scale";
        /// <summary>
        /// Cached name for the 'get_pitch_scale' method.
        /// </summary>
        public static readonly StringName GetPitchScale = "get_pitch_scale";
        /// <summary>
        /// Cached name for the 'set_oversampling' method.
        /// </summary>
        public static readonly StringName SetOversampling = "set_oversampling";
        /// <summary>
        /// Cached name for the 'get_oversampling' method.
        /// </summary>
        public static readonly StringName GetOversampling = "get_oversampling";
        /// <summary>
        /// Cached name for the 'set_fft_size' method.
        /// </summary>
        public static readonly StringName SetFftSize = "set_fft_size";
        /// <summary>
        /// Cached name for the 'get_fft_size' method.
        /// </summary>
        public static readonly StringName GetFftSize = "get_fft_size";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : AudioEffect.SignalName
    {
    }
}
