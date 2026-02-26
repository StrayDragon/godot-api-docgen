namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Simple state machine for cases which don't require a more advanced <see cref="Godot.AnimationNodeStateMachine"/>. Animations can be connected to the inputs and transition times can be specified.</para>
/// <para>After setting the request and changing the animation playback, the transition node automatically clears the request on the next process frame by setting its <c>transition_request</c> value to empty.</para>
/// <para><b>Note:</b> When using a cross-fade, <c>current_state</c> and <c>current_index</c> change to the next state immediately after the cross-fade begins.</para>
/// <para><code>
/// // Play child animation connected to "state_2" port.
/// animationTree.Set("parameters/Transition/transition_request", "state_2");
/// 
/// // Get current state name (read-only).
/// animationTree.Get("parameters/Transition/current_state");
/// 
/// // Get current state index (read-only).
/// animationTree.Get("parameters/Transition/current_index");
/// </code></para>
/// </summary>
public partial class AnimationNodeTransition : AnimationNodeSync
{
    /// <summary>
    /// <para>Cross-fading time (in seconds) between each animation connected to the inputs.</para>
    /// <para><b>Note:</b> <see cref="Godot.AnimationNodeTransition"/> transitions the current state immediately after the start of the fading. The precise remaining time can only be inferred from the main animation. When <see cref="Godot.AnimationNodeOutput"/> is considered as the most upstream, so the <see cref="Godot.AnimationNodeTransition.XfadeTime"/> is not scaled depending on the downstream delta. See also <see cref="Godot.AnimationNodeOneShot.FadeOutTime"/>.</para>
    /// </summary>
    public double XfadeTime
    {
        get
        {
            return GetXfadeTime();
        }
        set
        {
            SetXfadeTime(value);
        }
    }

    /// <summary>
    /// <para>Determines how cross-fading between animations is eased. If empty, the transition will be linear. Should be a unit <see cref="Godot.Curve"/>.</para>
    /// </summary>
    public Curve XfadeCurve
    {
        get
        {
            return GetXfadeCurve();
        }
        set
        {
            SetXfadeCurve(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, allows transition to the self state. When the reset option is enabled in input, the animation is restarted. If <see langword="false"/>, nothing happens on the transition to the self state.</para>
    /// </summary>
    public bool AllowTransitionToSelf
    {
        get
        {
            return IsAllowTransitionToSelf();
        }
        set
        {
            SetAllowTransitionToSelf(value);
        }
    }

    /// <summary>
    /// <para>The number of enabled input ports for this animation node.</para>
    /// </summary>
    public int InputCount
    {
        get
        {
            return GetInputCount();
        }
        set
        {
            SetInputCount(value);
        }
    }

    private static readonly System.Type CachedType = typeof(AnimationNodeTransition);

    private static readonly StringName NativeName = "AnimationNodeTransition";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public AnimationNodeTransition() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal AnimationNodeTransition(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal AnimationNodeTransition(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetInputCount, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetInputCount(int inputCount)
    {
        NativeCalls.godot_icall_1_38(MethodBind0, GodotObject.GetPtr(this), inputCount);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetInputAsAutoAdvance, 300928843ul);

    /// <summary>
    /// <para>Enables or disables auto-advance for the given <paramref name="input"/> index. If enabled, state changes to the next input after playing the animation once. If enabled for the last input state, it loops to the first.</para>
    /// </summary>
    public void SetInputAsAutoAdvance(int input, bool enable)
    {
        NativeCalls.godot_icall_2_61(MethodBind1, GodotObject.GetPtr(this), input, enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsInputSetAsAutoAdvance, 1116898809ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if auto-advance is enabled for the given <paramref name="input"/> index.</para>
    /// </summary>
    public bool IsInputSetAsAutoAdvance(int input)
    {
        return NativeCalls.godot_icall_1_62(MethodBind2, GodotObject.GetPtr(this), input).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetInputBreakLoopAtEnd, 300928843ul);

    /// <summary>
    /// <para>If <see langword="true"/>, breaks the loop at the end of the loop cycle for transition, even if the animation is looping.</para>
    /// </summary>
    public void SetInputBreakLoopAtEnd(int input, bool enable)
    {
        NativeCalls.godot_icall_2_61(MethodBind3, GodotObject.GetPtr(this), input, enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsInputLoopBrokenAtEnd, 1116898809ul);

    /// <summary>
    /// <para>Returns whether the animation breaks the loop at the end of the loop cycle for transition.</para>
    /// </summary>
    public bool IsInputLoopBrokenAtEnd(int input)
    {
        return NativeCalls.godot_icall_1_62(MethodBind4, GodotObject.GetPtr(this), input).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetInputReset, 300928843ul);

    /// <summary>
    /// <para>If <see langword="true"/>, the destination animation is restarted when the animation transitions.</para>
    /// </summary>
    public void SetInputReset(int input, bool enable)
    {
        NativeCalls.godot_icall_2_61(MethodBind5, GodotObject.GetPtr(this), input, enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsInputReset, 1116898809ul);

    /// <summary>
    /// <para>Returns whether the animation restarts when the animation transitions from the other animation.</para>
    /// </summary>
    public bool IsInputReset(int input)
    {
        return NativeCalls.godot_icall_1_62(MethodBind6, GodotObject.GetPtr(this), input).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetXfadeTime, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetXfadeTime(double time)
    {
        NativeCalls.godot_icall_1_127(MethodBind7, GodotObject.GetPtr(this), time);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetXfadeTime, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public double GetXfadeTime()
    {
        return NativeCalls.godot_icall_0_144(MethodBind8, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetXfadeCurve, 270443179ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetXfadeCurve(Curve curve)
    {
        NativeCalls.godot_icall_1_56(MethodBind9, GodotObject.GetPtr(this), GodotObject.GetPtr(curve));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetXfadeCurve, 2460114913ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Curve GetXfadeCurve()
    {
        return (Curve)NativeCalls.godot_icall_0_63(MethodBind10, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAllowTransitionToSelf, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAllowTransitionToSelf(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind11, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsAllowTransitionToSelf, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsAllowTransitionToSelf()
    {
        return NativeCalls.godot_icall_0_15(MethodBind12, GodotObject.GetPtr(this)).ToBool();
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
    public new class PropertyName : AnimationNodeSync.PropertyName
    {
        /// <summary>
        /// Cached name for the 'xfade_time' property.
        /// </summary>
        public static readonly StringName XfadeTime = "xfade_time";
        /// <summary>
        /// Cached name for the 'xfade_curve' property.
        /// </summary>
        public static readonly StringName XfadeCurve = "xfade_curve";
        /// <summary>
        /// Cached name for the 'allow_transition_to_self' property.
        /// </summary>
        public static readonly StringName AllowTransitionToSelf = "allow_transition_to_self";
        /// <summary>
        /// Cached name for the 'input_count' property.
        /// </summary>
        public static readonly StringName InputCount = "input_count";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : AnimationNodeSync.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_input_count' method.
        /// </summary>
        public static readonly StringName SetInputCount = "set_input_count";
        /// <summary>
        /// Cached name for the 'set_input_as_auto_advance' method.
        /// </summary>
        public static readonly StringName SetInputAsAutoAdvance = "set_input_as_auto_advance";
        /// <summary>
        /// Cached name for the 'is_input_set_as_auto_advance' method.
        /// </summary>
        public static readonly StringName IsInputSetAsAutoAdvance = "is_input_set_as_auto_advance";
        /// <summary>
        /// Cached name for the 'set_input_break_loop_at_end' method.
        /// </summary>
        public static readonly StringName SetInputBreakLoopAtEnd = "set_input_break_loop_at_end";
        /// <summary>
        /// Cached name for the 'is_input_loop_broken_at_end' method.
        /// </summary>
        public static readonly StringName IsInputLoopBrokenAtEnd = "is_input_loop_broken_at_end";
        /// <summary>
        /// Cached name for the 'set_input_reset' method.
        /// </summary>
        public static readonly StringName SetInputReset = "set_input_reset";
        /// <summary>
        /// Cached name for the 'is_input_reset' method.
        /// </summary>
        public static readonly StringName IsInputReset = "is_input_reset";
        /// <summary>
        /// Cached name for the 'set_xfade_time' method.
        /// </summary>
        public static readonly StringName SetXfadeTime = "set_xfade_time";
        /// <summary>
        /// Cached name for the 'get_xfade_time' method.
        /// </summary>
        public static readonly StringName GetXfadeTime = "get_xfade_time";
        /// <summary>
        /// Cached name for the 'set_xfade_curve' method.
        /// </summary>
        public static readonly StringName SetXfadeCurve = "set_xfade_curve";
        /// <summary>
        /// Cached name for the 'get_xfade_curve' method.
        /// </summary>
        public static readonly StringName GetXfadeCurve = "get_xfade_curve";
        /// <summary>
        /// Cached name for the 'set_allow_transition_to_self' method.
        /// </summary>
        public static readonly StringName SetAllowTransitionToSelf = "set_allow_transition_to_self";
        /// <summary>
        /// Cached name for the 'is_allow_transition_to_self' method.
        /// </summary>
        public static readonly StringName IsAllowTransitionToSelf = "is_allow_transition_to_self";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : AnimationNodeSync.SignalName
    {
    }
}
