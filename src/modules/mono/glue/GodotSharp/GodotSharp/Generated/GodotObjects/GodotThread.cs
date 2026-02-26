namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A unit of execution in a process. Can run methods on <see cref="Godot.GodotObject"/>s simultaneously. The use of synchronization via <see cref="Godot.Mutex"/> or <see cref="Godot.Semaphore"/> is advised if working with shared objects.</para>
/// <para><b>Warning:</b> To ensure proper cleanup without crashes or deadlocks, when a <see cref="Godot.GodotThread"/>'s reference count reaches zero and it is therefore destroyed, the following conditions must be met:</para>
/// <para>- It must not have any <see cref="Godot.Mutex"/> objects locked.</para>
/// <para>- It must not be waiting on any <see cref="Godot.Semaphore"/> objects.</para>
/// <para>- <see cref="Godot.GodotThread.WaitToFinish()"/> should have been called on it.</para>
/// </summary>
[GodotClassName("Thread")]
public partial class GodotThread : RefCounted
{
    public enum Priority : long
    {
        /// <summary>
        /// <para>A thread running with lower priority than normally.</para>
        /// </summary>
        Low = 0,
        /// <summary>
        /// <para>A thread with a standard priority.</para>
        /// </summary>
        Normal = 1,
        /// <summary>
        /// <para>A thread running with higher priority than normally.</para>
        /// </summary>
        High = 2
    }

    private static readonly System.Type CachedType = typeof(GodotThread);

    private static readonly StringName NativeName = "Thread";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public GodotThread() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal GodotThread(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal GodotThread(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Start, 1327203254ul);

    /// <summary>
    /// <para>Starts a new <see cref="Godot.GodotThread"/> that calls <paramref name="callable"/>.</para>
    /// <para>If the method takes some arguments, you can pass them using <c>Callable.bind</c>.</para>
    /// <para>The <paramref name="priority"/> of the <see cref="Godot.GodotThread"/> can be changed by passing a value from the <see cref="Godot.GodotThread.Priority"/> enum.</para>
    /// <para>Returns <see cref="Godot.Error.Ok"/> on success, or <see cref="Godot.Error.CantCreate"/> on failure.</para>
    /// </summary>
    public Error Start(Callable callable, GodotThread.Priority priority = (GodotThread.Priority)(1))
    {
        return (Error)NativeCalls.godot_icall_2_1420(MethodBind0, GodotObject.GetPtr(this), callable, (int)priority);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetId, 201670096ul);

    /// <summary>
    /// <para>Returns the current <see cref="Godot.GodotThread"/>'s ID, uniquely identifying it among all threads. If the <see cref="Godot.GodotThread"/> has not started running or if <see cref="Godot.GodotThread.WaitToFinish()"/> has been called, this returns an empty string.</para>
    /// </summary>
    public string GetId()
    {
        return NativeCalls.godot_icall_0_58(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsStarted, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if this <see cref="Godot.GodotThread"/> has been started. Once started, this will return <see langword="true"/> until it is joined using <see cref="Godot.GodotThread.WaitToFinish()"/>. For checking if a <see cref="Godot.GodotThread"/> is still executing its task, use <see cref="Godot.GodotThread.IsAlive()"/>.</para>
    /// </summary>
    public bool IsStarted()
    {
        return NativeCalls.godot_icall_0_15(MethodBind2, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsAlive, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if this <see cref="Godot.GodotThread"/> is currently running the provided function. This is useful for determining if <see cref="Godot.GodotThread.WaitToFinish()"/> can be called without blocking the calling thread.</para>
    /// <para>To check if a <see cref="Godot.GodotThread"/> is joinable, use <see cref="Godot.GodotThread.IsStarted()"/>.</para>
    /// </summary>
    public bool IsAlive()
    {
        return NativeCalls.godot_icall_0_15(MethodBind3, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.WaitToFinish, 1460262497ul);

    /// <summary>
    /// <para>Joins the <see cref="Godot.GodotThread"/> and waits for it to finish. Returns the output of the <see cref="Godot.Callable"/> passed to <see cref="Godot.GodotThread.Start(Callable, GodotThread.Priority)"/>.</para>
    /// <para>Should either be used when you want to retrieve the value returned from the method called by the <see cref="Godot.GodotThread"/> or before freeing the instance that contains the <see cref="Godot.GodotThread"/>.</para>
    /// <para>To determine if this can be called without blocking the calling thread, check if <see cref="Godot.GodotThread.IsAlive()"/> is <see langword="false"/>.</para>
    /// </summary>
    public Variant WaitToFinish()
    {
        return NativeCalls.godot_icall_0_772(MethodBind4, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetThreadSafetyChecksEnabled, 2586408642ul);

    /// <summary>
    /// <para>Sets whether the thread safety checks the engine normally performs in methods of certain classes (e.g., <see cref="Godot.Node"/>) should happen <b>on the current thread</b>.</para>
    /// <para>The default, for every thread, is that they are enabled (as if called with <paramref name="enabled"/> being <see langword="true"/>).</para>
    /// <para>Those checks are conservative. That means that they will only succeed in considering a call thread-safe (and therefore allow it to happen) if the engine can guarantee such safety.</para>
    /// <para>Because of that, there may be cases where the user may want to disable them (<paramref name="enabled"/> being <see langword="false"/>) to make certain operations allowed again. By doing so, it becomes the user's responsibility to ensure thread safety (e.g., by using <see cref="Godot.Mutex"/>) for those objects that are otherwise protected by the engine.</para>
    /// <para><b>Note:</b> This is an advanced usage of the engine. You are advised to use it only if you know what you are doing and there is no safer way.</para>
    /// <para><b>Note:</b> This is useful for scripts running on either arbitrary <see cref="Godot.GodotThread"/> objects or tasks submitted to the <see cref="Godot.WorkerThreadPool"/>. It doesn't apply to code running during <see cref="Godot.Node"/> group processing, where the checks will be always performed.</para>
    /// <para><b>Note:</b> Even in the case of having disabled the checks in a <see cref="Godot.WorkerThreadPool"/> task, there's no need to re-enable them at the end. The engine will do so.</para>
    /// </summary>
    public static void SetThreadSafetyChecksEnabled(bool enabled)
    {
        NativeCalls.godot_icall_1_1025(MethodBind5, enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsMainThread, 2240911060ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the thread this method was called from is the main thread.</para>
    /// <para><b>Note:</b> This is a static method and isn't associated with a specific <see cref="Godot.GodotThread"/> object.</para>
    /// </summary>
    public static bool IsMainThread()
    {
        return NativeCalls.godot_icall_0_1026(MethodBind6).ToBool();
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
    public new class PropertyName : RefCounted.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : RefCounted.MethodName
    {
        /// <summary>
        /// Cached name for the 'start' method.
        /// </summary>
        public static readonly StringName Start = "start";
        /// <summary>
        /// Cached name for the 'get_id' method.
        /// </summary>
        public static readonly StringName GetId = "get_id";
        /// <summary>
        /// Cached name for the 'is_started' method.
        /// </summary>
        public static readonly StringName IsStarted = "is_started";
        /// <summary>
        /// Cached name for the 'is_alive' method.
        /// </summary>
        public static readonly StringName IsAlive = "is_alive";
        /// <summary>
        /// Cached name for the 'wait_to_finish' method.
        /// </summary>
        public static readonly StringName WaitToFinish = "wait_to_finish";
        /// <summary>
        /// Cached name for the 'set_thread_safety_checks_enabled' method.
        /// </summary>
        public static readonly StringName SetThreadSafetyChecksEnabled = "set_thread_safety_checks_enabled";
        /// <summary>
        /// Cached name for the 'is_main_thread' method.
        /// </summary>
        public static readonly StringName IsMainThread = "is_main_thread";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : RefCounted.SignalName
    {
    }
}
