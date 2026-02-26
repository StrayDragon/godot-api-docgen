namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This audio effect does not affect sound output, but can be used for real-time audio visualizations.</para>
/// <para>This resource configures an <see cref="Godot.AudioEffectSpectrumAnalyzerInstance"/>, which performs the actual analysis at runtime. An instance can be obtained with <see cref="Godot.AudioServer.GetBusEffectInstance(int, int, int)"/>.</para>
/// <para>See also <see cref="Godot.AudioStreamGenerator"/> for procedurally generating sounds.</para>
/// </summary>
public partial class AudioEffectSpectrumAnalyzer : AudioEffect
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
        /// <para>Represents the size of the <see cref="Godot.AudioEffectSpectrumAnalyzer.FftSizeEnum"/> enum.</para>
        /// </summary>
        Max = 5
    }

    /// <summary>
    /// <para>The length of the buffer to keep (in seconds). Higher values keep data around for longer, but require more memory.</para>
    /// </summary>
    public float BufferLength
    {
        get
        {
            return GetBufferLength();
        }
        set
        {
            SetBufferLength(value);
        }
    }

    public float TapBackPos
    {
        get
        {
            return GetTapBackPos();
        }
        set
        {
            SetTapBackPos(value);
        }
    }

    /// <summary>
    /// <para>The size of the <a href="https://en.wikipedia.org/wiki/Fast_Fourier_transform">Fast Fourier transform</a> buffer. Higher values smooth out the spectrum analysis over time, but have greater latency. The effects of this higher latency are especially noticeable with sudden amplitude changes.</para>
    /// </summary>
    public AudioEffectSpectrumAnalyzer.FftSizeEnum FftSize
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

    private static readonly System.Type CachedType = typeof(AudioEffectSpectrumAnalyzer);

    private static readonly StringName NativeName = "AudioEffectSpectrumAnalyzer";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public AudioEffectSpectrumAnalyzer() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal AudioEffectSpectrumAnalyzer(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal AudioEffectSpectrumAnalyzer(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBufferLength, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetBufferLength(float seconds)
    {
        NativeCalls.godot_icall_1_67(MethodBind0, GodotObject.GetPtr(this), seconds);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBufferLength, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetBufferLength()
    {
        return NativeCalls.godot_icall_0_68(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTapBackPos, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTapBackPos(float seconds)
    {
        NativeCalls.godot_icall_1_67(MethodBind2, GodotObject.GetPtr(this), seconds);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTapBackPos, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetTapBackPos()
    {
        return NativeCalls.godot_icall_0_68(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFftSize, 1202879215ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFftSize(AudioEffectSpectrumAnalyzer.FftSizeEnum size)
    {
        NativeCalls.godot_icall_1_38(MethodBind4, GodotObject.GetPtr(this), (int)size);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFftSize, 3925405343ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public AudioEffectSpectrumAnalyzer.FftSizeEnum GetFftSize()
    {
        return (AudioEffectSpectrumAnalyzer.FftSizeEnum)NativeCalls.godot_icall_0_39(MethodBind5, GodotObject.GetPtr(this));
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
        /// Cached name for the 'buffer_length' property.
        /// </summary>
        public static readonly StringName BufferLength = "buffer_length";
        /// <summary>
        /// Cached name for the 'tap_back_pos' property.
        /// </summary>
        public static readonly StringName TapBackPos = "tap_back_pos";
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
        /// Cached name for the 'set_buffer_length' method.
        /// </summary>
        public static readonly StringName SetBufferLength = "set_buffer_length";
        /// <summary>
        /// Cached name for the 'get_buffer_length' method.
        /// </summary>
        public static readonly StringName GetBufferLength = "get_buffer_length";
        /// <summary>
        /// Cached name for the 'set_tap_back_pos' method.
        /// </summary>
        public static readonly StringName SetTapBackPos = "set_tap_back_pos";
        /// <summary>
        /// Cached name for the 'get_tap_back_pos' method.
        /// </summary>
        public static readonly StringName GetTapBackPos = "get_tap_back_pos";
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
