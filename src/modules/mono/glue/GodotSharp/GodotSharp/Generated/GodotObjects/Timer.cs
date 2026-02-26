namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>The <see cref="Godot.Timer"/> node is a countdown timer and is the simplest way to handle time-based logic in the engine. When a timer reaches the end of its <see cref="Godot.Timer.WaitTime"/>, it will emit the <see cref="Godot.Timer.Timeout"/> signal.</para>
/// <para>After a timer enters the scene tree, it can be manually started with <see cref="Godot.Timer.Start(double)"/>. A timer node is also started automatically if <see cref="Godot.Timer.Autostart"/> is <see langword="true"/>.</para>
/// <para>Without requiring much code, a timer node can be added and configured in the editor. The <see cref="Godot.Timer.Timeout"/> signal it emits can also be connected through the Signals dock in the editor:</para>
/// <para><code>
/// func _on_timer_timeout():
/// 	print("Time to attack!")
/// </code></para>
/// <para><b>Note:</b> To create a one-shot timer without instantiating a node, use <see cref="Godot.SceneTree.CreateTimer(double, bool, bool, bool)"/>.</para>
/// <para><b>Note:</b> Timers are affected by <see cref="Godot.Engine.TimeScale"/> unless <see cref="Godot.Timer.IgnoreTimeScale"/> is <see langword="true"/>. The higher the time scale, the sooner timers will end. How often a timer processes may depend on the framerate or <see cref="Godot.Engine.PhysicsTicksPerSecond"/>.</para>
/// </summary>
public partial class Timer : Node
{
    public enum TimerProcessCallback : long
    {
        /// <summary>
        /// <para>Update the timer every physics process frame (see <see cref="Godot.Node.NotificationInternalPhysicsProcess"/>).</para>
        /// </summary>
        Physics = 0,
        /// <summary>
        /// <para>Update the timer every process (rendered) frame (see <see cref="Godot.Node.NotificationInternalProcess"/>).</para>
        /// </summary>
        Idle = 1
    }

    /// <summary>
    /// <para>Specifies when the timer is updated during the main loop.</para>
    /// </summary>
    public Timer.TimerProcessCallback ProcessCallback
    {
        get
        {
            return GetTimerProcessCallback();
        }
        set
        {
            SetTimerProcessCallback(value);
        }
    }

    /// <summary>
    /// <para>The time required for the timer to end, in seconds. This property can also be set every time <see cref="Godot.Timer.Start(double)"/> is called.</para>
    /// <para><b>Note:</b> Timers can only process once per physics or process frame (depending on the <see cref="Godot.Timer.ProcessCallback"/>). An unstable framerate may cause the timer to end inconsistently, which is especially noticeable if the wait time is lower than roughly <c>0.05</c> seconds. For very short timers, it is recommended to write your own code instead of using a <see cref="Godot.Timer"/> node. Timers are also affected by <see cref="Godot.Engine.TimeScale"/>.</para>
    /// </summary>
    public double WaitTime
    {
        get
        {
            return GetWaitTime();
        }
        set
        {
            SetWaitTime(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the timer will stop after reaching the end. Otherwise, as by default, the timer will automatically restart.</para>
    /// </summary>
    public bool OneShot
    {
        get
        {
            return IsOneShot();
        }
        set
        {
            SetOneShot(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the timer will start immediately when it enters the scene tree.</para>
    /// <para><b>Note:</b> After the timer enters the tree, this property is automatically set to <see langword="false"/>.</para>
    /// <para><b>Note:</b> This property does nothing when the timer is running in the editor.</para>
    /// </summary>
    public bool Autostart
    {
        get
        {
            return HasAutostart();
        }
        set
        {
            SetAutostart(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the timer is paused. A paused timer does not process until this property is set back to <see langword="false"/>, even when <see cref="Godot.Timer.Start(double)"/> is called. See also <see cref="Godot.Timer.Stop()"/>.</para>
    /// </summary>
    public bool Paused
    {
        get
        {
            return IsPaused();
        }
        set
        {
            SetPaused(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the timer will ignore <see cref="Godot.Engine.TimeScale"/> and update with the real, elapsed time.</para>
    /// </summary>
    public bool IgnoreTimeScale
    {
        get
        {
            return IsIgnoringTimeScale();
        }
        set
        {
            SetIgnoreTimeScale(value);
        }
    }

    /// <summary>
    /// <para>The timer's remaining time in seconds. This is always <c>0</c> if the timer is stopped.</para>
    /// <para><b>Note:</b> This property is read-only and cannot be modified. It is based on <see cref="Godot.Timer.WaitTime"/>.</para>
    /// </summary>
    public double TimeLeft
    {
        get
        {
            return GetTimeLeft();
        }
    }

    private static readonly System.Type CachedType = typeof(Timer);

    private static readonly StringName NativeName = "Timer";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public Timer() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal Timer(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal Timer(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetWaitTime, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetWaitTime(double timeSec)
    {
        NativeCalls.godot_icall_1_127(MethodBind0, GodotObject.GetPtr(this), timeSec);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetWaitTime, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public double GetWaitTime()
    {
        return NativeCalls.godot_icall_0_144(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetOneShot, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetOneShot(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind2, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsOneShot, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsOneShot()
    {
        return NativeCalls.godot_icall_0_15(MethodBind3, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAutostart, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAutostart(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind4, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasAutostart, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool HasAutostart()
    {
        return NativeCalls.godot_icall_0_15(MethodBind5, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Start, 1392008558ul);

    /// <summary>
    /// <para>Starts the timer, or resets the timer if it was started already. Fails if the timer is not inside the scene tree. If <paramref name="timeSec"/> is greater than <c>0</c>, this value is used for the <see cref="Godot.Timer.WaitTime"/>.</para>
    /// <para><b>Note:</b> This method does not resume a paused timer. See <see cref="Godot.Timer.Paused"/>.</para>
    /// </summary>
    public void Start(double timeSec = (double)(-1))
    {
        NativeCalls.godot_icall_1_127(MethodBind6, GodotObject.GetPtr(this), timeSec);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Stop, 3218959716ul);

    /// <summary>
    /// <para>Stops the timer. See also <see cref="Godot.Timer.Paused"/>. Unlike <see cref="Godot.Timer.Start(double)"/>, this can safely be called if the timer is not inside the scene tree.</para>
    /// <para><b>Note:</b> Calling <see cref="Godot.Timer.Stop()"/> does not emit the <see cref="Godot.Timer.Timeout"/> signal, as the timer is not considered to have timed out. If this is desired, use <c>$Timer.timeout.emit()</c> after calling <see cref="Godot.Timer.Stop()"/> to manually emit the signal.</para>
    /// </summary>
    public void Stop()
    {
        NativeCalls.godot_icall_0_3(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPaused, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPaused(bool paused)
    {
        NativeCalls.godot_icall_1_14(MethodBind8, GodotObject.GetPtr(this), paused.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsPaused, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsPaused()
    {
        return NativeCalls.godot_icall_0_15(MethodBind9, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetIgnoreTimeScale, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetIgnoreTimeScale(bool ignore)
    {
        NativeCalls.godot_icall_1_14(MethodBind10, GodotObject.GetPtr(this), ignore.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsIgnoringTimeScale, 2240911060ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsIgnoringTimeScale()
    {
        return NativeCalls.godot_icall_0_15(MethodBind11, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsStopped, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the timer is stopped or has not started.</para>
    /// </summary>
    public bool IsStopped()
    {
        return NativeCalls.godot_icall_0_15(MethodBind12, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTimeLeft, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public double GetTimeLeft()
    {
        return NativeCalls.godot_icall_0_144(MethodBind13, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTimerProcessCallback, 3469495063ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTimerProcessCallback(Timer.TimerProcessCallback callback)
    {
        NativeCalls.godot_icall_1_38(MethodBind14, GodotObject.GetPtr(this), (int)callback);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTimerProcessCallback, 2672570227ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Timer.TimerProcessCallback GetTimerProcessCallback()
    {
        return (Timer.TimerProcessCallback)NativeCalls.godot_icall_0_39(MethodBind15, GodotObject.GetPtr(this));
    }

    /// <summary>
    /// <para>Emitted when the timer reaches the end.</para>
    /// </summary>
    public event Action Timeout
    {
        add => Connect(SignalName.Timeout, Callable.From(value));
        remove => Disconnect(SignalName.Timeout, Callable.From(value));
    }

    protected void EmitSignalTimeout()
    {
        EmitSignal(SignalName.Timeout);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_timeout = "Timeout";

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
        if (signal == SignalName.Timeout)
        {
            if (HasGodotClassSignal(SignalProxyName_timeout.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        return base.HasGodotClassSignal(signal);
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : Node.PropertyName
    {
        /// <summary>
        /// Cached name for the 'process_callback' property.
        /// </summary>
        public static readonly StringName ProcessCallback = "process_callback";
        /// <summary>
        /// Cached name for the 'wait_time' property.
        /// </summary>
        public static readonly StringName WaitTime = "wait_time";
        /// <summary>
        /// Cached name for the 'one_shot' property.
        /// </summary>
        public static readonly StringName OneShot = "one_shot";
        /// <summary>
        /// Cached name for the 'autostart' property.
        /// </summary>
        public static readonly StringName Autostart = "autostart";
        /// <summary>
        /// Cached name for the 'paused' property.
        /// </summary>
        public static readonly StringName Paused = "paused";
        /// <summary>
        /// Cached name for the 'ignore_time_scale' property.
        /// </summary>
        public static readonly StringName IgnoreTimeScale = "ignore_time_scale";
        /// <summary>
        /// Cached name for the 'time_left' property.
        /// </summary>
        public static readonly StringName TimeLeft = "time_left";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Node.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_wait_time' method.
        /// </summary>
        public static readonly StringName SetWaitTime = "set_wait_time";
        /// <summary>
        /// Cached name for the 'get_wait_time' method.
        /// </summary>
        public static readonly StringName GetWaitTime = "get_wait_time";
        /// <summary>
        /// Cached name for the 'set_one_shot' method.
        /// </summary>
        public static readonly StringName SetOneShot = "set_one_shot";
        /// <summary>
        /// Cached name for the 'is_one_shot' method.
        /// </summary>
        public static readonly StringName IsOneShot = "is_one_shot";
        /// <summary>
        /// Cached name for the 'set_autostart' method.
        /// </summary>
        public static readonly StringName SetAutostart = "set_autostart";
        /// <summary>
        /// Cached name for the 'has_autostart' method.
        /// </summary>
        public static readonly StringName HasAutostart = "has_autostart";
        /// <summary>
        /// Cached name for the 'start' method.
        /// </summary>
        public static readonly StringName Start = "start";
        /// <summary>
        /// Cached name for the 'stop' method.
        /// </summary>
        public static readonly StringName Stop = "stop";
        /// <summary>
        /// Cached name for the 'set_paused' method.
        /// </summary>
        public static readonly StringName SetPaused = "set_paused";
        /// <summary>
        /// Cached name for the 'is_paused' method.
        /// </summary>
        public static readonly StringName IsPaused = "is_paused";
        /// <summary>
        /// Cached name for the 'set_ignore_time_scale' method.
        /// </summary>
        public static readonly StringName SetIgnoreTimeScale = "set_ignore_time_scale";
        /// <summary>
        /// Cached name for the 'is_ignoring_time_scale' method.
        /// </summary>
        public static readonly StringName IsIgnoringTimeScale = "is_ignoring_time_scale";
        /// <summary>
        /// Cached name for the 'is_stopped' method.
        /// </summary>
        public static readonly StringName IsStopped = "is_stopped";
        /// <summary>
        /// Cached name for the 'get_time_left' method.
        /// </summary>
        public static readonly StringName GetTimeLeft = "get_time_left";
        /// <summary>
        /// Cached name for the 'set_timer_process_callback' method.
        /// </summary>
        public static readonly StringName SetTimerProcessCallback = "set_timer_process_callback";
        /// <summary>
        /// Cached name for the 'get_timer_process_callback' method.
        /// </summary>
        public static readonly StringName GetTimerProcessCallback = "get_timer_process_callback";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Node.SignalName
    {
        /// <summary>
        /// Cached name for the 'timeout' signal.
        /// </summary>
        public static readonly StringName Timeout = "timeout";
    }
}
