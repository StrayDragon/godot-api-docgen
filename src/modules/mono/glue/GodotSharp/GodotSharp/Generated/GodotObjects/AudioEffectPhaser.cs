namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Combines phase-shifted signals with the original signal. The movement of the phase-shifted signals is controlled using a low-frequency oscillator.</para>
/// </summary>
public partial class AudioEffectPhaser : AudioEffect
{
    /// <summary>
    /// <para>Determines the minimum frequency affected by the LFO modulations, in Hz. Value can range from 10 to 10000.</para>
    /// </summary>
    public float RangeMinHz
    {
        get
        {
            return GetRangeMinHz();
        }
        set
        {
            SetRangeMinHz(value);
        }
    }

    /// <summary>
    /// <para>Determines the maximum frequency affected by the LFO modulations, in Hz. Value can range from 10 to 10000.</para>
    /// </summary>
    public float RangeMaxHz
    {
        get
        {
            return GetRangeMaxHz();
        }
        set
        {
            SetRangeMaxHz(value);
        }
    }

    /// <summary>
    /// <para>Adjusts the rate in Hz at which the effect sweeps up and down across the frequency range.</para>
    /// </summary>
    public float RateHz
    {
        get
        {
            return GetRateHz();
        }
        set
        {
            SetRateHz(value);
        }
    }

    /// <summary>
    /// <para>Output percent of modified sound. Value can range from 0.1 to 0.9.</para>
    /// </summary>
    public float Feedback
    {
        get
        {
            return GetFeedback();
        }
        set
        {
            SetFeedback(value);
        }
    }

    /// <summary>
    /// <para>Determines how high the filter frequencies sweep. Low value will primarily affect bass frequencies. High value can sweep high into the treble. Value can range from <c>0.1</c> to <c>4.0</c>.</para>
    /// </summary>
    public float Depth
    {
        get
        {
            return GetDepth();
        }
        set
        {
            SetDepth(value);
        }
    }

    private static readonly System.Type CachedType = typeof(AudioEffectPhaser);

    private static readonly StringName NativeName = "AudioEffectPhaser";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public AudioEffectPhaser() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal AudioEffectPhaser(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal AudioEffectPhaser(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRangeMinHz, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetRangeMinHz(float hz)
    {
        NativeCalls.godot_icall_1_67(MethodBind0, GodotObject.GetPtr(this), hz);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRangeMinHz, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetRangeMinHz()
    {
        return NativeCalls.godot_icall_0_68(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRangeMaxHz, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetRangeMaxHz(float hz)
    {
        NativeCalls.godot_icall_1_67(MethodBind2, GodotObject.GetPtr(this), hz);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRangeMaxHz, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetRangeMaxHz()
    {
        return NativeCalls.godot_icall_0_68(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRateHz, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetRateHz(float hz)
    {
        NativeCalls.godot_icall_1_67(MethodBind4, GodotObject.GetPtr(this), hz);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRateHz, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetRateHz()
    {
        return NativeCalls.godot_icall_0_68(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFeedback, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFeedback(float fbk)
    {
        NativeCalls.godot_icall_1_67(MethodBind6, GodotObject.GetPtr(this), fbk);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFeedback, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetFeedback()
    {
        return NativeCalls.godot_icall_0_68(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDepth, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDepth(float depth)
    {
        NativeCalls.godot_icall_1_67(MethodBind8, GodotObject.GetPtr(this), depth);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDepth, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetDepth()
    {
        return NativeCalls.godot_icall_0_68(MethodBind9, GodotObject.GetPtr(this));
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
        /// Cached name for the 'range_min_hz' property.
        /// </summary>
        public static readonly StringName RangeMinHz = "range_min_hz";
        /// <summary>
        /// Cached name for the 'range_max_hz' property.
        /// </summary>
        public static readonly StringName RangeMaxHz = "range_max_hz";
        /// <summary>
        /// Cached name for the 'rate_hz' property.
        /// </summary>
        public static readonly StringName RateHz = "rate_hz";
        /// <summary>
        /// Cached name for the 'feedback' property.
        /// </summary>
        public static readonly StringName Feedback = "feedback";
        /// <summary>
        /// Cached name for the 'depth' property.
        /// </summary>
        public static readonly StringName Depth = "depth";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : AudioEffect.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_range_min_hz' method.
        /// </summary>
        public static readonly StringName SetRangeMinHz = "set_range_min_hz";
        /// <summary>
        /// Cached name for the 'get_range_min_hz' method.
        /// </summary>
        public static readonly StringName GetRangeMinHz = "get_range_min_hz";
        /// <summary>
        /// Cached name for the 'set_range_max_hz' method.
        /// </summary>
        public static readonly StringName SetRangeMaxHz = "set_range_max_hz";
        /// <summary>
        /// Cached name for the 'get_range_max_hz' method.
        /// </summary>
        public static readonly StringName GetRangeMaxHz = "get_range_max_hz";
        /// <summary>
        /// Cached name for the 'set_rate_hz' method.
        /// </summary>
        public static readonly StringName SetRateHz = "set_rate_hz";
        /// <summary>
        /// Cached name for the 'get_rate_hz' method.
        /// </summary>
        public static readonly StringName GetRateHz = "get_rate_hz";
        /// <summary>
        /// Cached name for the 'set_feedback' method.
        /// </summary>
        public static readonly StringName SetFeedback = "set_feedback";
        /// <summary>
        /// Cached name for the 'get_feedback' method.
        /// </summary>
        public static readonly StringName GetFeedback = "get_feedback";
        /// <summary>
        /// Cached name for the 'set_depth' method.
        /// </summary>
        public static readonly StringName SetDepth = "set_depth";
        /// <summary>
        /// Cached name for the 'get_depth' method.
        /// </summary>
        public static readonly StringName GetDepth = "get_depth";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : AudioEffect.SignalName
    {
    }
}
