namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A synchronization semaphore that can be used to synchronize multiple <see cref="Godot.GodotThread"/>s. Initialized to zero on creation. For a binary version, see <see cref="Godot.Mutex"/>.</para>
/// <para><b>Warning:</b> Semaphores must be used carefully to avoid deadlocks.</para>
/// <para><b>Warning:</b> To guarantee that the operating system is able to perform proper cleanup (no crashes, no deadlocks), these conditions must be met:</para>
/// <para>- When a <see cref="Godot.Semaphore"/>'s reference count reaches zero and it is therefore destroyed, no threads must be waiting on it.</para>
/// <para>- When a <see cref="Godot.GodotThread"/>'s reference count reaches zero and it is therefore destroyed, it must not be waiting on any semaphore.</para>
/// </summary>
public partial class Semaphore : RefCounted
{
    private static readonly System.Type CachedType = typeof(Semaphore);

    private static readonly StringName NativeName = "Semaphore";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public Semaphore() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal Semaphore(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal Semaphore(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Wait, 3218959716ul);

    /// <summary>
    /// <para>Waits for the <see cref="Godot.Semaphore"/>, if its value is zero, blocks until non-zero.</para>
    /// </summary>
    public void Wait()
    {
        NativeCalls.godot_icall_0_3(MethodBind0, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.TryWait, 2240911060ul);

    /// <summary>
    /// <para>Like <see cref="Godot.Semaphore.Wait()"/>, but won't block, so if the value is zero, fails immediately and returns <see langword="false"/>. If non-zero, it returns <see langword="true"/> to report success.</para>
    /// </summary>
    public bool TryWait()
    {
        return NativeCalls.godot_icall_0_15(MethodBind1, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Post, 1667783136ul);

    /// <summary>
    /// <para>Lowers the <see cref="Godot.Semaphore"/>, allowing one thread in, or more if <paramref name="count"/> is specified.</para>
    /// </summary>
    public void Post(int count = 1)
    {
        NativeCalls.godot_icall_1_38(MethodBind2, GodotObject.GetPtr(this), count);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Post, 3218959716ul);

    /// <summary>
    /// <para>Lowers the <see cref="Godot.Semaphore"/>, allowing one thread in, or more if <paramref name="count"/> is specified.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void Post()
    {
        NativeCalls.godot_icall_0_3(MethodBind3, GodotObject.GetPtr(this));
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
        /// Cached name for the 'wait' method.
        /// </summary>
        public static readonly StringName Wait = "wait";
        /// <summary>
        /// Cached name for the 'try_wait' method.
        /// </summary>
        public static readonly StringName TryWait = "try_wait";
        /// <summary>
        /// Cached name for the 'post' method.
        /// </summary>
        public static readonly StringName Post = "post";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : RefCounted.SignalName
    {
    }
}
