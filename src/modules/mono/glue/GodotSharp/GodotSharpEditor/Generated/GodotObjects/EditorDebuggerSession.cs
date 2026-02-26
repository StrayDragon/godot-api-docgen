namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This class cannot be directly instantiated and must be retrieved via an <see cref="Godot.EditorDebuggerPlugin"/>.</para>
/// <para>You can add tabs to the session UI via <see cref="Godot.EditorDebuggerSession.AddSessionTab(Control)"/>, send messages via <see cref="Godot.EditorDebuggerSession.SendMessage(string, Godot.Collections.Array)"/>, and toggle <see cref="Godot.EngineProfiler"/>s via <see cref="Godot.EditorDebuggerSession.ToggleProfiler(string, bool, Godot.Collections.Array)"/>.</para>
/// </summary>
public partial class EditorDebuggerSession : RefCounted
{
    private static readonly System.Type CachedType = typeof(EditorDebuggerSession);

    private static readonly StringName NativeName = "EditorDebuggerSession";

    internal EditorDebuggerSession() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal EditorDebuggerSession(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal EditorDebuggerSession(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SendMessage, 85656714ul);

    /// <summary>
    /// <para>Sends the given <paramref name="message"/> to the attached remote instance, optionally passing additionally <paramref name="data"/>. See <see cref="Godot.EngineDebugger"/> for how to retrieve those messages.</para>
    /// </summary>
    public void SendMessage(string message, Godot.Collections.Array data = null)
    {
        NativeCalls.godot_icall_2_469(MethodBind0, GodotObject.GetPtr(this), message, (godot_array)(data ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ToggleProfiler, 1198443697ul);

    /// <summary>
    /// <para>Toggle the given <paramref name="profiler"/> on the attached remote instance, optionally passing additionally <paramref name="data"/>. See <see cref="Godot.EngineProfiler"/> for more details.</para>
    /// </summary>
    public void ToggleProfiler(string profiler, bool enable, Godot.Collections.Array data = null)
    {
        EditorNativeCalls.godot_icall_3_470(MethodBind1, GodotObject.GetPtr(this), profiler, enable.ToGodotBool(), (godot_array)(data ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsBreaked, 2240911060ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the attached remote instance is currently in the debug loop.</para>
    /// </summary>
    public bool IsBreaked()
    {
        return NativeCalls.godot_icall_0_15(MethodBind2, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsDebuggable, 2240911060ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the attached remote instance can be debugged.</para>
    /// </summary>
    public bool IsDebuggable()
    {
        return NativeCalls.godot_icall_0_15(MethodBind3, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsActive, 2240911060ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the debug session is currently attached to a remote instance.</para>
    /// </summary>
    public bool IsActive()
    {
        return NativeCalls.godot_icall_0_15(MethodBind4, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddSessionTab, 1496901182ul);

    /// <summary>
    /// <para>Adds the given <paramref name="control"/> to the debug session UI in the debugger bottom panel. The <paramref name="control"/>'s node name will be used as the tab title.</para>
    /// </summary>
    public void AddSessionTab(Control control)
    {
        NativeCalls.godot_icall_1_56(MethodBind5, GodotObject.GetPtr(this), GodotObject.GetPtr(control));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveSessionTab, 1496901182ul);

    /// <summary>
    /// <para>Removes the given <paramref name="control"/> from the debug session UI in the debugger bottom panel.</para>
    /// </summary>
    public void RemoveSessionTab(Control control)
    {
        NativeCalls.godot_icall_1_56(MethodBind6, GodotObject.GetPtr(this), GodotObject.GetPtr(control));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBreakpoint, 4108344793ul);

    /// <summary>
    /// <para>Enables or disables a specific breakpoint based on <paramref name="enabled"/>, updating the Editor Breakpoint Panel accordingly.</para>
    /// </summary>
    public void SetBreakpoint(string path, int line, bool enabled)
    {
        NativeCalls.godot_icall_3_394(MethodBind7, GodotObject.GetPtr(this), path, line, enabled.ToGodotBool());
    }

    /// <summary>
    /// <para>Emitted when a remote instance is attached to this session (i.e. the session becomes active).</para>
    /// </summary>
    public event Action Started
    {
        add => Connect(SignalName.Started, Callable.From(value));
        remove => Disconnect(SignalName.Started, Callable.From(value));
    }

    protected void EmitSignalStarted()
    {
        EmitSignal(SignalName.Started);
    }

    /// <summary>
    /// <para>Emitted when a remote instance is detached from this session (i.e. the session becomes inactive).</para>
    /// </summary>
    public event Action Stopped
    {
        add => Connect(SignalName.Stopped, Callable.From(value));
        remove => Disconnect(SignalName.Stopped, Callable.From(value));
    }

    protected void EmitSignalStopped()
    {
        EmitSignal(SignalName.Stopped);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.EditorDebuggerSession.Breaked"/> event of a <see cref="Godot.EditorDebuggerSession"/> class.
    /// </summary>
    public delegate void BreakedEventHandler(bool canDebug);

    private static void BreakedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((BreakedEventHandler)delegateObj)(VariantUtils.ConvertTo<bool>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when the attached remote instance enters a break state. If <c>canDebug</c> is <see langword="true"/>, the remote instance will enter the debug loop.</para>
    /// </summary>
    public unsafe event BreakedEventHandler Breaked
    {
        add => Connect(SignalName.Breaked, Callable.CreateWithUnsafeTrampoline(value, &BreakedTrampoline));
        remove => Disconnect(SignalName.Breaked, Callable.CreateWithUnsafeTrampoline(value, &BreakedTrampoline));
    }

    protected void EmitSignalBreaked(bool canDebug)
    {
        EmitSignal(SignalName.Breaked, canDebug);
    }

    /// <summary>
    /// <para>Emitted when the attached remote instance exits a break state.</para>
    /// </summary>
    public event Action Continued
    {
        add => Connect(SignalName.Continued, Callable.From(value));
        remove => Disconnect(SignalName.Continued, Callable.From(value));
    }

    protected void EmitSignalContinued()
    {
        EmitSignal(SignalName.Continued);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_started = "Started";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_stopped = "Stopped";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_breaked = "Breaked";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_continued = "Continued";

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
        if (signal == SignalName.Started)
        {
            if (HasGodotClassSignal(SignalProxyName_started.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.Stopped)
        {
            if (HasGodotClassSignal(SignalProxyName_stopped.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.Breaked)
        {
            if (HasGodotClassSignal(SignalProxyName_breaked.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.Continued)
        {
            if (HasGodotClassSignal(SignalProxyName_continued.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        return base.HasGodotClassSignal(signal);
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : RefCounted.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : RefCounted.MethodName
    {
        /// <summary>
        /// Cached name for the 'send_message' method.
        /// </summary>
        public static readonly StringName SendMessage = "send_message";
        /// <summary>
        /// Cached name for the 'toggle_profiler' method.
        /// </summary>
        public static readonly StringName ToggleProfiler = "toggle_profiler";
        /// <summary>
        /// Cached name for the 'is_breaked' method.
        /// </summary>
        public static readonly StringName IsBreaked = "is_breaked";
        /// <summary>
        /// Cached name for the 'is_debuggable' method.
        /// </summary>
        public static readonly StringName IsDebuggable = "is_debuggable";
        /// <summary>
        /// Cached name for the 'is_active' method.
        /// </summary>
        public static readonly StringName IsActive = "is_active";
        /// <summary>
        /// Cached name for the 'add_session_tab' method.
        /// </summary>
        public static readonly StringName AddSessionTab = "add_session_tab";
        /// <summary>
        /// Cached name for the 'remove_session_tab' method.
        /// </summary>
        public static readonly StringName RemoveSessionTab = "remove_session_tab";
        /// <summary>
        /// Cached name for the 'set_breakpoint' method.
        /// </summary>
        public static readonly StringName SetBreakpoint = "set_breakpoint";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : RefCounted.SignalName
    {
        /// <summary>
        /// Cached name for the 'started' signal.
        /// </summary>
        public static readonly StringName Started = "started";
        /// <summary>
        /// Cached name for the 'stopped' signal.
        /// </summary>
        public static readonly StringName Stopped = "stopped";
        /// <summary>
        /// Cached name for the 'breaked' signal.
        /// </summary>
        public static readonly StringName Breaked = "breaked";
        /// <summary>
        /// Cached name for the 'continued' signal.
        /// </summary>
        public static readonly StringName Continued = "continued";
    }
}
