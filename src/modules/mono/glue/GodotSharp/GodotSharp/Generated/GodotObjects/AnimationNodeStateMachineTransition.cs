namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>The path generated when using <see cref="Godot.AnimationNodeStateMachinePlayback.Travel(StringName, bool)"/> is limited to the nodes connected by <see cref="Godot.AnimationNodeStateMachineTransition"/>.</para>
/// <para>You can set the timing and conditions of the transition in detail.</para>
/// </summary>
public partial class AnimationNodeStateMachineTransition : Resource
{
    public enum SwitchModeEnum : long
    {
        /// <summary>
        /// <para>Switch to the next state immediately. The current state will end and blend into the beginning of the new one.</para>
        /// </summary>
        Immediate = 0,
        /// <summary>
        /// <para>Switch to the next state immediately, but will seek the new state to the playback position of the old state.</para>
        /// </summary>
        Sync = 1,
        /// <summary>
        /// <para>Wait for the current state playback to end, then switch to the beginning of the next state animation.</para>
        /// </summary>
        AtEnd = 2
    }

    public enum AdvanceModeEnum : long
    {
        /// <summary>
        /// <para>Don't use this transition.</para>
        /// </summary>
        Disabled = 0,
        /// <summary>
        /// <para>Only use this transition during <see cref="Godot.AnimationNodeStateMachinePlayback.Travel(StringName, bool)"/>.</para>
        /// </summary>
        Enabled = 1,
        /// <summary>
        /// <para>Automatically use this transition if the <see cref="Godot.AnimationNodeStateMachineTransition.AdvanceCondition"/> and <see cref="Godot.AnimationNodeStateMachineTransition.AdvanceExpression"/> checks are <see langword="true"/> (if assigned).</para>
        /// </summary>
        Auto = 2
    }

    /// <summary>
    /// <para>The time to cross-fade between this state and the next.</para>
    /// <para><b>Note:</b> <see cref="Godot.AnimationNodeStateMachine"/> transitions the current state immediately after the start of the fading. The precise remaining time can only be inferred from the main animation. When <see cref="Godot.AnimationNodeOutput"/> is considered as the most upstream, so the <see cref="Godot.AnimationNodeStateMachineTransition.XfadeTime"/> is not scaled depending on the downstream delta. See also <see cref="Godot.AnimationNodeOneShot.FadeOutTime"/>.</para>
    /// </summary>
    public float XfadeTime
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
    /// <para>Ease curve for better control over cross-fade between this state and the next. Should be a unit <see cref="Godot.Curve"/>.</para>
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
    /// <para>If <see langword="true"/>, breaks the loop at the end of the loop cycle for transition, even if the animation is looping.</para>
    /// </summary>
    public bool BreakLoopAtEnd
    {
        get
        {
            return IsLoopBrokenAtEnd();
        }
        set
        {
            SetBreakLoopAtEnd(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the destination animation is played back from the beginning when switched.</para>
    /// </summary>
    public bool Reset
    {
        get
        {
            return IsReset();
        }
        set
        {
            SetReset(value);
        }
    }

    /// <summary>
    /// <para>Lower priority transitions are preferred when travelling through the tree via <see cref="Godot.AnimationNodeStateMachinePlayback.Travel(StringName, bool)"/> or <see cref="Godot.AnimationNodeStateMachineTransition.AdvanceMode"/> is set to <see cref="Godot.AnimationNodeStateMachineTransition.AdvanceModeEnum.Auto"/>.</para>
    /// </summary>
    public int Priority
    {
        get
        {
            return GetPriority();
        }
        set
        {
            SetPriority(value);
        }
    }

    /// <summary>
    /// <para>The transition type.</para>
    /// </summary>
    public AnimationNodeStateMachineTransition.SwitchModeEnum SwitchMode
    {
        get
        {
            return GetSwitchMode();
        }
        set
        {
            SetSwitchMode(value);
        }
    }

    /// <summary>
    /// <para>Determines whether the transition should be disabled, enabled when using <see cref="Godot.AnimationNodeStateMachinePlayback.Travel(StringName, bool)"/>, or traversed automatically if the <see cref="Godot.AnimationNodeStateMachineTransition.AdvanceCondition"/> and <see cref="Godot.AnimationNodeStateMachineTransition.AdvanceExpression"/> checks are <see langword="true"/> (if assigned).</para>
    /// </summary>
    public AnimationNodeStateMachineTransition.AdvanceModeEnum AdvanceMode
    {
        get
        {
            return GetAdvanceMode();
        }
        set
        {
            SetAdvanceMode(value);
        }
    }

    /// <summary>
    /// <para>Turn on auto advance when this condition is set. The provided name will become a boolean parameter on the <see cref="Godot.AnimationTree"/> that can be controlled from code (see <a href="$DOCS_URL/tutorials/animation/animation_tree.html#controlling-from-code">Using AnimationTree</a>). For example, if <see cref="Godot.AnimationTree.TreeRoot"/> is an <see cref="Godot.AnimationNodeStateMachine"/> and <see cref="Godot.AnimationNodeStateMachineTransition.AdvanceCondition"/> is set to <c>"idle"</c>:</para>
    /// <para><code>
    /// GetNode&lt;AnimationTree&gt;("animation_tree").Set("parameters/conditions/idle", IsOnFloor &amp;&amp; (LinearVelocity.X == 0));
    /// </code></para>
    /// </summary>
    public StringName AdvanceCondition
    {
        get
        {
            return GetAdvanceCondition();
        }
        set
        {
            SetAdvanceCondition(value);
        }
    }

    /// <summary>
    /// <para>Use an expression as a condition for state machine transitions. It is possible to create complex animation advance conditions for switching between states and gives much greater flexibility for creating complex state machines by directly interfacing with the script code.</para>
    /// </summary>
    public string AdvanceExpression
    {
        get
        {
            return GetAdvanceExpression();
        }
        set
        {
            SetAdvanceExpression(value);
        }
    }

    private static readonly System.Type CachedType = typeof(AnimationNodeStateMachineTransition);

    private static readonly StringName NativeName = "AnimationNodeStateMachineTransition";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public AnimationNodeStateMachineTransition() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal AnimationNodeStateMachineTransition(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal AnimationNodeStateMachineTransition(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSwitchMode, 2074906633ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSwitchMode(AnimationNodeStateMachineTransition.SwitchModeEnum mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind0, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSwitchMode, 2138562085ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public AnimationNodeStateMachineTransition.SwitchModeEnum GetSwitchMode()
    {
        return (AnimationNodeStateMachineTransition.SwitchModeEnum)NativeCalls.godot_icall_0_39(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAdvanceMode, 1210869868ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAdvanceMode(AnimationNodeStateMachineTransition.AdvanceModeEnum mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind2, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAdvanceMode, 61101689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public AnimationNodeStateMachineTransition.AdvanceModeEnum GetAdvanceMode()
    {
        return (AnimationNodeStateMachineTransition.AdvanceModeEnum)NativeCalls.godot_icall_0_39(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAdvanceCondition, 3304788590ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAdvanceCondition(StringName name)
    {
        NativeCalls.godot_icall_1_64(MethodBind4, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAdvanceCondition, 2002593661ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public StringName GetAdvanceCondition()
    {
        return NativeCalls.godot_icall_0_65(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetXfadeTime, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetXfadeTime(float secs)
    {
        NativeCalls.godot_icall_1_67(MethodBind6, GodotObject.GetPtr(this), secs);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetXfadeTime, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetXfadeTime()
    {
        return NativeCalls.godot_icall_0_68(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetXfadeCurve, 270443179ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetXfadeCurve(Curve curve)
    {
        NativeCalls.godot_icall_1_56(MethodBind8, GodotObject.GetPtr(this), GodotObject.GetPtr(curve));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetXfadeCurve, 2460114913ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Curve GetXfadeCurve()
    {
        return (Curve)NativeCalls.godot_icall_0_63(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBreakLoopAtEnd, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetBreakLoopAtEnd(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind10, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsLoopBrokenAtEnd, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsLoopBrokenAtEnd()
    {
        return NativeCalls.godot_icall_0_15(MethodBind11, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetReset, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetReset(bool reset)
    {
        NativeCalls.godot_icall_1_14(MethodBind12, GodotObject.GetPtr(this), reset.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsReset, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsReset()
    {
        return NativeCalls.godot_icall_0_15(MethodBind13, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPriority, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPriority(int priority)
    {
        NativeCalls.godot_icall_1_38(MethodBind14, GodotObject.GetPtr(this), priority);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPriority, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetPriority()
    {
        return NativeCalls.godot_icall_0_39(MethodBind15, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAdvanceExpression, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAdvanceExpression(string text)
    {
        NativeCalls.godot_icall_1_57(MethodBind16, GodotObject.GetPtr(this), text);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAdvanceExpression, 201670096ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetAdvanceExpression()
    {
        return NativeCalls.godot_icall_0_58(MethodBind17, GodotObject.GetPtr(this));
    }

    /// <summary>
    /// <para>Emitted when <see cref="Godot.AnimationNodeStateMachineTransition.AdvanceCondition"/> is changed.</para>
    /// </summary>
    public event Action AdvanceConditionChanged
    {
        add => Connect(SignalName.AdvanceConditionChanged, Callable.From(value));
        remove => Disconnect(SignalName.AdvanceConditionChanged, Callable.From(value));
    }

    protected void EmitSignalAdvanceConditionChanged()
    {
        EmitSignal(SignalName.AdvanceConditionChanged);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_advance_condition_changed = "AdvanceConditionChanged";

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
        if (signal == SignalName.AdvanceConditionChanged)
        {
            if (HasGodotClassSignal(SignalProxyName_advance_condition_changed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        return base.HasGodotClassSignal(signal);
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : Resource.PropertyName
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
        /// Cached name for the 'break_loop_at_end' property.
        /// </summary>
        public static readonly StringName BreakLoopAtEnd = "break_loop_at_end";
        /// <summary>
        /// Cached name for the 'reset' property.
        /// </summary>
        public static readonly StringName Reset = "reset";
        /// <summary>
        /// Cached name for the 'priority' property.
        /// </summary>
        public static readonly StringName Priority = "priority";
        /// <summary>
        /// Cached name for the 'switch_mode' property.
        /// </summary>
        public static readonly StringName SwitchMode = "switch_mode";
        /// <summary>
        /// Cached name for the 'advance_mode' property.
        /// </summary>
        public static readonly StringName AdvanceMode = "advance_mode";
        /// <summary>
        /// Cached name for the 'advance_condition' property.
        /// </summary>
        public static readonly StringName AdvanceCondition = "advance_condition";
        /// <summary>
        /// Cached name for the 'advance_expression' property.
        /// </summary>
        public static readonly StringName AdvanceExpression = "advance_expression";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Resource.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_switch_mode' method.
        /// </summary>
        public static readonly StringName SetSwitchMode = "set_switch_mode";
        /// <summary>
        /// Cached name for the 'get_switch_mode' method.
        /// </summary>
        public static readonly StringName GetSwitchMode = "get_switch_mode";
        /// <summary>
        /// Cached name for the 'set_advance_mode' method.
        /// </summary>
        public static readonly StringName SetAdvanceMode = "set_advance_mode";
        /// <summary>
        /// Cached name for the 'get_advance_mode' method.
        /// </summary>
        public static readonly StringName GetAdvanceMode = "get_advance_mode";
        /// <summary>
        /// Cached name for the 'set_advance_condition' method.
        /// </summary>
        public static readonly StringName SetAdvanceCondition = "set_advance_condition";
        /// <summary>
        /// Cached name for the 'get_advance_condition' method.
        /// </summary>
        public static readonly StringName GetAdvanceCondition = "get_advance_condition";
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
        /// Cached name for the 'set_break_loop_at_end' method.
        /// </summary>
        public static readonly StringName SetBreakLoopAtEnd = "set_break_loop_at_end";
        /// <summary>
        /// Cached name for the 'is_loop_broken_at_end' method.
        /// </summary>
        public static readonly StringName IsLoopBrokenAtEnd = "is_loop_broken_at_end";
        /// <summary>
        /// Cached name for the 'set_reset' method.
        /// </summary>
        public static readonly StringName SetReset = "set_reset";
        /// <summary>
        /// Cached name for the 'is_reset' method.
        /// </summary>
        public static readonly StringName IsReset = "is_reset";
        /// <summary>
        /// Cached name for the 'set_priority' method.
        /// </summary>
        public static readonly StringName SetPriority = "set_priority";
        /// <summary>
        /// Cached name for the 'get_priority' method.
        /// </summary>
        public static readonly StringName GetPriority = "get_priority";
        /// <summary>
        /// Cached name for the 'set_advance_expression' method.
        /// </summary>
        public static readonly StringName SetAdvanceExpression = "set_advance_expression";
        /// <summary>
        /// Cached name for the 'get_advance_expression' method.
        /// </summary>
        public static readonly StringName GetAdvanceExpression = "get_advance_expression";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Resource.SignalName
    {
        /// <summary>
        /// Cached name for the 'advance_condition_changed' signal.
        /// </summary>
        public static readonly StringName AdvanceConditionChanged = "advance_condition_changed";
    }
}
