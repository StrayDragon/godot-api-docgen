namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>The runtime part of an <see cref="Godot.AudioEffectSpectrumAnalyzer"/>, which can be used to query the magnitude of a frequency range on its host bus.</para>
/// <para>An instance of this class can be obtained with <see cref="Godot.AudioServer.GetBusEffectInstance(int, int, int)"/>.</para>
/// </summary>
public partial class AudioEffectSpectrumAnalyzerInstance : AudioEffectInstance
{
    public enum MagnitudeMode : long
    {
        /// <summary>
        /// <para>Use the average value across the frequency range as magnitude.</para>
        /// </summary>
        Average = 0,
        /// <summary>
        /// <para>Use the maximum value of the frequency range as magnitude.</para>
        /// </summary>
        Max = 1
    }

    private static readonly System.Type CachedType = typeof(AudioEffectSpectrumAnalyzerInstance);

    private static readonly StringName NativeName = "AudioEffectSpectrumAnalyzerInstance";

    internal AudioEffectSpectrumAnalyzerInstance() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal AudioEffectSpectrumAnalyzerInstance(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal AudioEffectSpectrumAnalyzerInstance(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMagnitudeForFrequencyRange, 797993915ul);

    /// <summary>
    /// <para>Returns the magnitude of the frequencies from <paramref name="fromHz"/> to <paramref name="toHz"/> in linear energy as a Vector2. The <c>x</c> component of the return value represents the left stereo channel, and <c>y</c> represents the right channel.</para>
    /// <para><paramref name="mode"/> determines how the frequency range will be processed.</para>
    /// </summary>
    public Vector2 GetMagnitudeForFrequencyRange(float fromHz, float toHz, AudioEffectSpectrumAnalyzerInstance.MagnitudeMode mode = (AudioEffectSpectrumAnalyzerInstance.MagnitudeMode)(1))
    {
        return NativeCalls.godot_icall_3_191(MethodBind0, GodotObject.GetPtr(this), fromHz, toHz, (int)mode);
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
    public new class PropertyName : AudioEffectInstance.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : AudioEffectInstance.MethodName
    {
        /// <summary>
        /// Cached name for the 'get_magnitude_for_frequency_range' method.
        /// </summary>
        public static readonly StringName GetMagnitudeForFrequencyRange = "get_magnitude_for_frequency_range";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : AudioEffectInstance.SignalName
    {
    }
}
