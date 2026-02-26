namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para><see cref="Godot.AudioStreamGenerator"/> is a type of audio stream that does not play back sounds on its own; instead, it expects a script to generate audio data for it. See also <see cref="Godot.AudioStreamGeneratorPlayback"/>.</para>
/// <para>Here's a sample on how to use it to generate a sine wave:</para>
/// <para><code>
/// [Export] public AudioStreamPlayer Player { get; set; }
/// 
/// private AudioStreamGeneratorPlayback _playback; // Will hold the AudioStreamGeneratorPlayback.
/// private float _sampleHz;
/// private float _pulseHz = 440.0f; // The frequency of the sound wave.
/// private double phase = 0.0;
/// 
/// public override void _Ready()
/// {
/// 	if (Player.Stream is AudioStreamGenerator generator) // Type as a generator to access MixRate.
/// 	{
/// 		_sampleHz = generator.MixRate;
/// 		Player.Play();
/// 		_playback = (AudioStreamGeneratorPlayback)Player.GetStreamPlayback();
/// 		FillBuffer();
/// 	}
/// }
/// 
/// public void FillBuffer()
/// {
/// 	float increment = _pulseHz / _sampleHz;
/// 	int framesAvailable = _playback.GetFramesAvailable();
/// 
/// 	for (int i = 0; i &lt; framesAvailable; i++)
/// 	{
/// 		_playback.PushFrame(Vector2.One * (float)Mathf.Sin(phase * Mathf.Tau));
/// 		phase = Mathf.PosMod(phase + increment, 1.0);
/// 	}
/// }
/// </code></para>
/// <para>In the example above, the "AudioStreamPlayer" node must use an <see cref="Godot.AudioStreamGenerator"/> as its stream. The <c>fill_buffer</c> function provides audio data for approximating a sine wave.</para>
/// <para>See also <see cref="Godot.AudioEffectSpectrumAnalyzer"/> for performing real-time audio spectrum analysis.</para>
/// <para><b>Note:</b> Due to performance constraints, this class is best used from C# or from a compiled language via GDExtension. If you still want to use this class from GDScript, consider using a lower <see cref="Godot.AudioStreamGenerator.MixRate"/> such as 11,025 Hz or 22,050 Hz.</para>
/// </summary>
public partial class AudioStreamGenerator : AudioStream
{
    public enum AudioStreamGeneratorMixRate : long
    {
        /// <summary>
        /// <para>Current <see cref="Godot.AudioServer"/> output mixing rate.</para>
        /// </summary>
        Output = 0,
        /// <summary>
        /// <para>Current <see cref="Godot.AudioServer"/> input mixing rate.</para>
        /// </summary>
        Input = 1,
        /// <summary>
        /// <para>Custom mixing rate, specified by <see cref="Godot.AudioStreamGenerator.MixRate"/>.</para>
        /// </summary>
        Custom = 2,
        /// <summary>
        /// <para>Maximum value for the mixing rate mode enum.</para>
        /// </summary>
        Max = 3
    }

    /// <summary>
    /// <para>Mixing rate mode. If set to <see cref="Godot.AudioStreamGenerator.AudioStreamGeneratorMixRate.Custom"/>, <see cref="Godot.AudioStreamGenerator.MixRate"/> is used, otherwise current <see cref="Godot.AudioServer"/> mixing rate is used.</para>
    /// </summary>
    public AudioStreamGenerator.AudioStreamGeneratorMixRate MixRateMode
    {
        get
        {
            return GetMixRateMode();
        }
        set
        {
            SetMixRateMode(value);
        }
    }

    /// <summary>
    /// <para>The sample rate to use (in Hz). Higher values are more demanding for the CPU to generate, but result in better quality.</para>
    /// <para>In games, common sample rates in use are <c>11025</c>, <c>16000</c>, <c>22050</c>, <c>32000</c>, <c>44100</c>, and <c>48000</c>.</para>
    /// <para>According to the <a href="https://en.wikipedia.org/wiki/Nyquist%E2%80%93Shannon_sampling_theorem">Nyquist-Shannon sampling theorem</a>, there is no quality difference to human hearing when going past 40,000 Hz (since most humans can only hear up to ~20,000 Hz, often less). If you are generating lower-pitched sounds such as voices, lower sample rates such as <c>32000</c> or <c>22050</c> may be usable with no loss in quality.</para>
    /// <para><b>Note:</b> <see cref="Godot.AudioStreamGenerator"/> is not automatically resampling input data, to produce expected result <see cref="Godot.AudioStreamGenerator.MixRateMode"/> should match the sampling rate of input data.</para>
    /// <para><b>Note:</b> If you are using <see cref="Godot.AudioEffectCapture"/> as the source of your data, set <see cref="Godot.AudioStreamGenerator.MixRateMode"/> to <see cref="Godot.AudioStreamGenerator.AudioStreamGeneratorMixRate.Input"/> or <see cref="Godot.AudioStreamGenerator.AudioStreamGeneratorMixRate.Output"/> to automatically match current <see cref="Godot.AudioServer"/> mixing rate.</para>
    /// </summary>
    public float MixRate
    {
        get
        {
            return GetMixRate();
        }
        set
        {
            SetMixRate(value);
        }
    }

    /// <summary>
    /// <para>The length of the buffer to generate (in seconds). Lower values result in less latency, but require the script to generate audio data faster, resulting in increased CPU usage and more risk for audio cracking if the CPU can't keep up.</para>
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

    private static readonly System.Type CachedType = typeof(AudioStreamGenerator);

    private static readonly StringName NativeName = "AudioStreamGenerator";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public AudioStreamGenerator() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal AudioStreamGenerator(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal AudioStreamGenerator(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMixRate, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMixRate(float hz)
    {
        NativeCalls.godot_icall_1_67(MethodBind0, GodotObject.GetPtr(this), hz);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMixRate, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetMixRate()
    {
        return NativeCalls.godot_icall_0_68(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMixRateMode, 3354885803ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMixRateMode(AudioStreamGenerator.AudioStreamGeneratorMixRate mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind2, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMixRateMode, 3537132591ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public AudioStreamGenerator.AudioStreamGeneratorMixRate GetMixRateMode()
    {
        return (AudioStreamGenerator.AudioStreamGeneratorMixRate)NativeCalls.godot_icall_0_39(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBufferLength, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetBufferLength(float seconds)
    {
        NativeCalls.godot_icall_1_67(MethodBind4, GodotObject.GetPtr(this), seconds);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBufferLength, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetBufferLength()
    {
        return NativeCalls.godot_icall_0_68(MethodBind5, GodotObject.GetPtr(this));
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
    public new class PropertyName : AudioStream.PropertyName
    {
        /// <summary>
        /// Cached name for the 'mix_rate_mode' property.
        /// </summary>
        public static readonly StringName MixRateMode = "mix_rate_mode";
        /// <summary>
        /// Cached name for the 'mix_rate' property.
        /// </summary>
        public static readonly StringName MixRate = "mix_rate";
        /// <summary>
        /// Cached name for the 'buffer_length' property.
        /// </summary>
        public static readonly StringName BufferLength = "buffer_length";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : AudioStream.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_mix_rate' method.
        /// </summary>
        public static readonly StringName SetMixRate = "set_mix_rate";
        /// <summary>
        /// Cached name for the 'get_mix_rate' method.
        /// </summary>
        public static readonly StringName GetMixRate = "get_mix_rate";
        /// <summary>
        /// Cached name for the 'set_mix_rate_mode' method.
        /// </summary>
        public static readonly StringName SetMixRateMode = "set_mix_rate_mode";
        /// <summary>
        /// Cached name for the 'get_mix_rate_mode' method.
        /// </summary>
        public static readonly StringName GetMixRateMode = "get_mix_rate_mode";
        /// <summary>
        /// Cached name for the 'set_buffer_length' method.
        /// </summary>
        public static readonly StringName SetBufferLength = "set_buffer_length";
        /// <summary>
        /// Cached name for the 'get_buffer_length' method.
        /// </summary>
        public static readonly StringName GetBufferLength = "get_buffer_length";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : AudioStream.SignalName
    {
    }
}
