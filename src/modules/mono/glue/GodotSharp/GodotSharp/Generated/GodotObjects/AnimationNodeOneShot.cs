namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A resource to add to an <see cref="Godot.AnimationNodeBlendTree"/>. This animation node will execute a sub-animation and return once it finishes. Blend times for fading in and out can be customized, as well as filters.</para>
/// <para>After setting the request and changing the animation playback, the one-shot node automatically clears the request on the next process frame by setting its <c>request</c> value to <see cref="Godot.AnimationNodeOneShot.OneShotRequest.None"/>.</para>
/// <para><code>
/// // Play child animation connected to "shot" port.
/// animationTree.Set("parameters/OneShot/request", (int)AnimationNodeOneShot.OneShotRequest.Fire);
/// 
/// // Abort child animation connected to "shot" port.
/// animationTree.Set("parameters/OneShot/request", (int)AnimationNodeOneShot.OneShotRequest.Abort);
/// 
/// // Abort child animation with fading out connected to "shot" port.
/// animationTree.Set("parameters/OneShot/request", (int)AnimationNodeOneShot.OneShotRequest.FadeOut);
/// 
/// // Get current state (read-only).
/// animationTree.Get("parameters/OneShot/active");
/// 
/// // Get current internal state (read-only).
/// animationTree.Get("parameters/OneShot/internal_active");
/// </code></para>
/// </summary>
public partial class AnimationNodeOneShot : AnimationNodeSync
{
    public enum OneShotRequest : long
    {
        /// <summary>
        /// <para>The default state of the request. Nothing is done.</para>
        /// </summary>
        None = 0,
        /// <summary>
        /// <para>The request to play the animation connected to "shot" port.</para>
        /// </summary>
        Fire = 1,
        /// <summary>
        /// <para>The request to stop the animation connected to "shot" port.</para>
        /// </summary>
        Abort = 2,
        /// <summary>
        /// <para>The request to fade out the animation connected to "shot" port.</para>
        /// </summary>
        FadeOut = 3
    }

    public enum MixModeEnum : long
    {
        /// <summary>
        /// <para>Blends two animations. See also <see cref="Godot.AnimationNodeBlend2"/>.</para>
        /// </summary>
        Blend = 0,
        /// <summary>
        /// <para>Blends two animations additively. See also <see cref="Godot.AnimationNodeAdd2"/>.</para>
        /// </summary>
        Add = 1
    }

    /// <summary>
    /// <para>The blend type.</para>
    /// </summary>
    public AnimationNodeOneShot.MixModeEnum MixMode
    {
        get
        {
            return GetMixMode();
        }
        set
        {
            SetMixMode(value);
        }
    }

    /// <summary>
    /// <para>The fade-in duration. For example, setting this to <c>1.0</c> for a 5 second length animation will produce a cross-fade that starts at 0 second and ends at 1 second during the animation.</para>
    /// <para><b>Note:</b> <see cref="Godot.AnimationNodeOneShot"/> transitions the current state after the fading has finished.</para>
    /// </summary>
    public double FadeInTime
    {
        get
        {
            return GetFadeInTime();
        }
        set
        {
            SetFadeInTime(value);
        }
    }

    /// <summary>
    /// <para>Determines how cross-fading between animations is eased. If empty, the transition will be linear. Should be a unit <see cref="Godot.Curve"/>.</para>
    /// </summary>
    public Curve FadeInCurve
    {
        get
        {
            return GetFadeInCurve();
        }
        set
        {
            SetFadeInCurve(value);
        }
    }

    /// <summary>
    /// <para>The fade-out duration. For example, setting this to <c>1.0</c> for a 5 second length animation will produce a cross-fade that starts at 4 second and ends at 5 second during the animation.</para>
    /// <para><b>Note:</b> <see cref="Godot.AnimationNodeOneShot"/> transitions the current state after the fading has finished.</para>
    /// </summary>
    public double FadeOutTime
    {
        get
        {
            return GetFadeOutTime();
        }
        set
        {
            SetFadeOutTime(value);
        }
    }

    /// <summary>
    /// <para>Determines how cross-fading between animations is eased. If empty, the transition will be linear. Should be a unit <see cref="Godot.Curve"/>.</para>
    /// </summary>
    public Curve FadeOutCurve
    {
        get
        {
            return GetFadeOutCurve();
        }
        set
        {
            SetFadeOutCurve(value);
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
    /// <para>If <see langword="true"/>, the sub-animation will abort if resumed with a reset after a prior interruption.</para>
    /// </summary>
    public bool AbortOnReset
    {
        get
        {
            return IsAbortedOnReset();
        }
        set
        {
            SetAbortOnReset(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the sub-animation will restart automatically after finishing.</para>
    /// <para>In other words, to start auto restarting, the animation must be played once with the <see cref="Godot.AnimationNodeOneShot.OneShotRequest.Fire"/> request. The <see cref="Godot.AnimationNodeOneShot.OneShotRequest.Abort"/> request stops the auto restarting, but it does not disable the <see cref="Godot.AnimationNodeOneShot.Autorestart"/> itself. So, the <see cref="Godot.AnimationNodeOneShot.OneShotRequest.Fire"/> request will start auto restarting again.</para>
    /// </summary>
    public bool Autorestart
    {
        get
        {
            return HasAutorestart();
        }
        set
        {
            SetAutorestart(value);
        }
    }

    /// <summary>
    /// <para>The delay after which the automatic restart is triggered, in seconds.</para>
    /// </summary>
    public double AutorestartDelay
    {
        get
        {
            return GetAutorestartDelay();
        }
        set
        {
            SetAutorestartDelay(value);
        }
    }

    /// <summary>
    /// <para>If <see cref="Godot.AnimationNodeOneShot.Autorestart"/> is <see langword="true"/>, a random additional delay (in seconds) between 0 and this value will be added to <see cref="Godot.AnimationNodeOneShot.AutorestartDelay"/>.</para>
    /// </summary>
    public double AutorestartRandomDelay
    {
        get
        {
            return GetAutorestartRandomDelay();
        }
        set
        {
            SetAutorestartRandomDelay(value);
        }
    }

    private static readonly System.Type CachedType = typeof(AnimationNodeOneShot);

    private static readonly StringName NativeName = "AnimationNodeOneShot";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public AnimationNodeOneShot() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal AnimationNodeOneShot(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal AnimationNodeOneShot(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFadeInTime, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFadeInTime(double time)
    {
        NativeCalls.godot_icall_1_127(MethodBind0, GodotObject.GetPtr(this), time);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFadeInTime, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public double GetFadeInTime()
    {
        return NativeCalls.godot_icall_0_144(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFadeInCurve, 270443179ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFadeInCurve(Curve curve)
    {
        NativeCalls.godot_icall_1_56(MethodBind2, GodotObject.GetPtr(this), GodotObject.GetPtr(curve));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFadeInCurve, 2460114913ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Curve GetFadeInCurve()
    {
        return (Curve)NativeCalls.godot_icall_0_63(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFadeOutTime, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFadeOutTime(double time)
    {
        NativeCalls.godot_icall_1_127(MethodBind4, GodotObject.GetPtr(this), time);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFadeOutTime, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public double GetFadeOutTime()
    {
        return NativeCalls.godot_icall_0_144(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFadeOutCurve, 270443179ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFadeOutCurve(Curve curve)
    {
        NativeCalls.godot_icall_1_56(MethodBind6, GodotObject.GetPtr(this), GodotObject.GetPtr(curve));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFadeOutCurve, 2460114913ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Curve GetFadeOutCurve()
    {
        return (Curve)NativeCalls.godot_icall_0_63(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBreakLoopAtEnd, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetBreakLoopAtEnd(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind8, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsLoopBrokenAtEnd, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsLoopBrokenAtEnd()
    {
        return NativeCalls.godot_icall_0_15(MethodBind9, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAbortOnReset, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAbortOnReset(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind10, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsAbortedOnReset, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsAbortedOnReset()
    {
        return NativeCalls.godot_icall_0_15(MethodBind11, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAutorestart, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAutorestart(bool active)
    {
        NativeCalls.godot_icall_1_14(MethodBind12, GodotObject.GetPtr(this), active.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasAutorestart, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool HasAutorestart()
    {
        return NativeCalls.godot_icall_0_15(MethodBind13, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAutorestartDelay, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAutorestartDelay(double time)
    {
        NativeCalls.godot_icall_1_127(MethodBind14, GodotObject.GetPtr(this), time);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAutorestartDelay, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public double GetAutorestartDelay()
    {
        return NativeCalls.godot_icall_0_144(MethodBind15, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAutorestartRandomDelay, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAutorestartRandomDelay(double time)
    {
        NativeCalls.godot_icall_1_127(MethodBind16, GodotObject.GetPtr(this), time);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAutorestartRandomDelay, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public double GetAutorestartRandomDelay()
    {
        return NativeCalls.godot_icall_0_144(MethodBind17, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMixMode, 1018899799ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMixMode(AnimationNodeOneShot.MixModeEnum mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind18, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMixMode, 3076550526ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public AnimationNodeOneShot.MixModeEnum GetMixMode()
    {
        return (AnimationNodeOneShot.MixModeEnum)NativeCalls.godot_icall_0_39(MethodBind19, GodotObject.GetPtr(this));
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
        /// Cached name for the 'mix_mode' property.
        /// </summary>
        public static readonly StringName MixMode = "mix_mode";
        /// <summary>
        /// Cached name for the 'fadein_time' property.
        /// </summary>
        public static readonly StringName FadeInTime = "fadein_time";
        /// <summary>
        /// Cached name for the 'fadein_curve' property.
        /// </summary>
        public static readonly StringName FadeInCurve = "fadein_curve";
        /// <summary>
        /// Cached name for the 'fadeout_time' property.
        /// </summary>
        public static readonly StringName FadeOutTime = "fadeout_time";
        /// <summary>
        /// Cached name for the 'fadeout_curve' property.
        /// </summary>
        public static readonly StringName FadeOutCurve = "fadeout_curve";
        /// <summary>
        /// Cached name for the 'break_loop_at_end' property.
        /// </summary>
        public static readonly StringName BreakLoopAtEnd = "break_loop_at_end";
        /// <summary>
        /// Cached name for the 'abort_on_reset' property.
        /// </summary>
        public static readonly StringName AbortOnReset = "abort_on_reset";
        /// <summary>
        /// Cached name for the 'autorestart' property.
        /// </summary>
        public static readonly StringName Autorestart = "autorestart";
        /// <summary>
        /// Cached name for the 'autorestart_delay' property.
        /// </summary>
        public static readonly StringName AutorestartDelay = "autorestart_delay";
        /// <summary>
        /// Cached name for the 'autorestart_random_delay' property.
        /// </summary>
        public static readonly StringName AutorestartRandomDelay = "autorestart_random_delay";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : AnimationNodeSync.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_fadein_time' method.
        /// </summary>
        public static readonly StringName SetFadeInTime = "set_fadein_time";
        /// <summary>
        /// Cached name for the 'get_fadein_time' method.
        /// </summary>
        public static readonly StringName GetFadeInTime = "get_fadein_time";
        /// <summary>
        /// Cached name for the 'set_fadein_curve' method.
        /// </summary>
        public static readonly StringName SetFadeInCurve = "set_fadein_curve";
        /// <summary>
        /// Cached name for the 'get_fadein_curve' method.
        /// </summary>
        public static readonly StringName GetFadeInCurve = "get_fadein_curve";
        /// <summary>
        /// Cached name for the 'set_fadeout_time' method.
        /// </summary>
        public static readonly StringName SetFadeOutTime = "set_fadeout_time";
        /// <summary>
        /// Cached name for the 'get_fadeout_time' method.
        /// </summary>
        public static readonly StringName GetFadeOutTime = "get_fadeout_time";
        /// <summary>
        /// Cached name for the 'set_fadeout_curve' method.
        /// </summary>
        public static readonly StringName SetFadeOutCurve = "set_fadeout_curve";
        /// <summary>
        /// Cached name for the 'get_fadeout_curve' method.
        /// </summary>
        public static readonly StringName GetFadeOutCurve = "get_fadeout_curve";
        /// <summary>
        /// Cached name for the 'set_break_loop_at_end' method.
        /// </summary>
        public static readonly StringName SetBreakLoopAtEnd = "set_break_loop_at_end";
        /// <summary>
        /// Cached name for the 'is_loop_broken_at_end' method.
        /// </summary>
        public static readonly StringName IsLoopBrokenAtEnd = "is_loop_broken_at_end";
        /// <summary>
        /// Cached name for the 'set_abort_on_reset' method.
        /// </summary>
        public static readonly StringName SetAbortOnReset = "set_abort_on_reset";
        /// <summary>
        /// Cached name for the 'is_aborted_on_reset' method.
        /// </summary>
        public static readonly StringName IsAbortedOnReset = "is_aborted_on_reset";
        /// <summary>
        /// Cached name for the 'set_autorestart' method.
        /// </summary>
        public static readonly StringName SetAutorestart = "set_autorestart";
        /// <summary>
        /// Cached name for the 'has_autorestart' method.
        /// </summary>
        public static readonly StringName HasAutorestart = "has_autorestart";
        /// <summary>
        /// Cached name for the 'set_autorestart_delay' method.
        /// </summary>
        public static readonly StringName SetAutorestartDelay = "set_autorestart_delay";
        /// <summary>
        /// Cached name for the 'get_autorestart_delay' method.
        /// </summary>
        public static readonly StringName GetAutorestartDelay = "get_autorestart_delay";
        /// <summary>
        /// Cached name for the 'set_autorestart_random_delay' method.
        /// </summary>
        public static readonly StringName SetAutorestartRandomDelay = "set_autorestart_random_delay";
        /// <summary>
        /// Cached name for the 'get_autorestart_random_delay' method.
        /// </summary>
        public static readonly StringName GetAutorestartRandomDelay = "get_autorestart_random_delay";
        /// <summary>
        /// Cached name for the 'set_mix_mode' method.
        /// </summary>
        public static readonly StringName SetMixMode = "set_mix_mode";
        /// <summary>
        /// Cached name for the 'get_mix_mode' method.
        /// </summary>
        public static readonly StringName GetMixMode = "get_mix_mode";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : AnimationNodeSync.SignalName
    {
    }
}
