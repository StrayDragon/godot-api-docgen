namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>GodotInstance represents a running Godot instance that is controlled from an outside codebase, without a perpetual main loop. It is created by the C API <c>libgodot_create_godot_instance</c>. Only one may be created per process.</para>
/// </summary>
public partial class GodotInstance : GodotObject
{
    private static readonly System.Type CachedType = typeof(GodotInstance);

    private static readonly StringName NativeName = "GodotInstance";

    internal GodotInstance() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal GodotInstance(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal GodotInstance(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Start, 2240911060ul);

    /// <summary>
    /// <para>Finishes this instance's startup sequence. Returns <see langword="true"/> on success.</para>
    /// </summary>
    public bool Start()
    {
        return NativeCalls.godot_icall_0_15(MethodBind0, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsStarted, 2240911060ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if this instance has been fully started.</para>
    /// </summary>
    public bool IsStarted()
    {
        return NativeCalls.godot_icall_0_15(MethodBind1, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Iteration, 2240911060ul);

    /// <summary>
    /// <para>Runs a single iteration of the main loop. Returns <see langword="true"/> if the engine is attempting to quit.</para>
    /// </summary>
    public bool Iteration()
    {
        return NativeCalls.godot_icall_0_15(MethodBind2, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FocusIn, 3218959716ul);

    /// <summary>
    /// <para>Notifies the instance that it is now in focus.</para>
    /// </summary>
    public void FocusIn()
    {
        NativeCalls.godot_icall_0_3(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FocusOut, 3218959716ul);

    /// <summary>
    /// <para>Notifies the instance that it is now not in focus.</para>
    /// </summary>
    public void FocusOut()
    {
        NativeCalls.godot_icall_0_3(MethodBind4, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Pause, 3218959716ul);

    /// <summary>
    /// <para>Notifies the instance that it is going to be paused.</para>
    /// </summary>
    public void Pause()
    {
        NativeCalls.godot_icall_0_3(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Resume, 3218959716ul);

    /// <summary>
    /// <para>Notifies the instance that it is being resumed.</para>
    /// </summary>
    public void Resume()
    {
        NativeCalls.godot_icall_0_3(MethodBind6, GodotObject.GetPtr(this));
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
    public new class PropertyName : GodotObject.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : GodotObject.MethodName
    {
        /// <summary>
        /// Cached name for the 'start' method.
        /// </summary>
        public static readonly StringName Start = "start";
        /// <summary>
        /// Cached name for the 'is_started' method.
        /// </summary>
        public static readonly StringName IsStarted = "is_started";
        /// <summary>
        /// Cached name for the 'iteration' method.
        /// </summary>
        public static readonly StringName Iteration = "iteration";
        /// <summary>
        /// Cached name for the 'focus_in' method.
        /// </summary>
        public static readonly StringName FocusIn = "focus_in";
        /// <summary>
        /// Cached name for the 'focus_out' method.
        /// </summary>
        public static readonly StringName FocusOut = "focus_out";
        /// <summary>
        /// Cached name for the 'pause' method.
        /// </summary>
        public static readonly StringName Pause = "pause";
        /// <summary>
        /// Cached name for the 'resume' method.
        /// </summary>
        public static readonly StringName Resume = "resume";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : GodotObject.SignalName
    {
    }
}
