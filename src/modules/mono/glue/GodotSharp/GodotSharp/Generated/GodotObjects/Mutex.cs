namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A synchronization mutex (mutual exclusion). This is used to synchronize multiple <see cref="Godot.GodotThread"/>s, and is equivalent to a binary <see cref="Godot.Semaphore"/>. It guarantees that only one thread can access a critical section at a time.</para>
/// <para>This is a reentrant mutex, meaning that it can be locked multiple times by one thread, provided it also unlocks it as many times.</para>
/// <para><b>Warning:</b> To ensure proper cleanup without crashes or deadlocks, the following conditions must be met:</para>
/// <para>- When a <see cref="Godot.Mutex"/>'s reference count reaches zero and it is therefore destroyed, no threads (including the one on which the destruction will happen) must have it locked.</para>
/// <para>- When a <see cref="Godot.GodotThread"/>'s reference count reaches zero and it is therefore destroyed, it must not have any mutex locked.</para>
/// </summary>
public partial class Mutex : RefCounted
{
    private static readonly System.Type CachedType = typeof(Mutex);

    private static readonly StringName NativeName = "Mutex";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public Mutex() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal Mutex(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal Mutex(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Lock, 3218959716ul);

    /// <summary>
    /// <para>Locks this <see cref="Godot.Mutex"/>, blocks until it is unlocked by the current owner.</para>
    /// <para><b>Note:</b> This function returns without blocking if the thread already has ownership of the mutex.</para>
    /// </summary>
    public void Lock()
    {
        NativeCalls.godot_icall_0_3(MethodBind0, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.TryLock, 2240911060ul);

    /// <summary>
    /// <para>Tries locking this <see cref="Godot.Mutex"/>, but does not block. Returns <see langword="true"/> on success, <see langword="false"/> otherwise.</para>
    /// <para><b>Note:</b> This function returns <see langword="true"/> if the thread already has ownership of the mutex.</para>
    /// </summary>
    public bool TryLock()
    {
        return NativeCalls.godot_icall_0_15(MethodBind1, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Unlock, 3218959716ul);

    /// <summary>
    /// <para>Unlocks this <see cref="Godot.Mutex"/>, leaving it to other threads.</para>
    /// <para><b>Note:</b> If a thread called <see cref="Godot.Mutex.Lock()"/> or <see cref="Godot.Mutex.TryLock()"/> multiple times while already having ownership of the mutex, it must also call <see cref="Godot.Mutex.Unlock()"/> the same number of times in order to unlock it correctly.</para>
    /// <para><b>Warning:</b> Calling <see cref="Godot.Mutex.Unlock()"/> more times than <see cref="Godot.Mutex.Lock()"/> on a given thread, thus ending up trying to unlock a non-locked mutex, is wrong and may causes crashes or deadlocks.</para>
    /// </summary>
    public void Unlock()
    {
        NativeCalls.godot_icall_0_3(MethodBind2, GodotObject.GetPtr(this));
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
        /// Cached name for the 'lock' method.
        /// </summary>
        public static readonly StringName Lock = "lock";
        /// <summary>
        /// Cached name for the 'try_lock' method.
        /// </summary>
        public static readonly StringName TryLock = "try_lock";
        /// <summary>
        /// Cached name for the 'unlock' method.
        /// </summary>
        public static readonly StringName Unlock = "unlock";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : RefCounted.SignalName
    {
    }
}
