namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This <see cref="Godot.SkeletonModification2D"/> holds a reference to a <see cref="Godot.SkeletonModificationStack2D"/>, allowing you to use multiple modification stacks on a single <see cref="Godot.Skeleton2D"/>.</para>
/// <para><b>Note:</b> The modifications in the held <see cref="Godot.SkeletonModificationStack2D"/> will only be executed if their execution mode matches the execution mode of the SkeletonModification2DStackHolder.</para>
/// </summary>
public partial class SkeletonModification2DStackHolder : SkeletonModification2D
{
    private static readonly System.Type CachedType = typeof(SkeletonModification2DStackHolder);

    private static readonly StringName NativeName = "SkeletonModification2DStackHolder";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public SkeletonModification2DStackHolder() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal SkeletonModification2DStackHolder(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal SkeletonModification2DStackHolder(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetHeldModificationStack, 3907307132ul);

    /// <summary>
    /// <para>Sets the <see cref="Godot.SkeletonModificationStack2D"/> that this modification is holding. This modification stack will then be executed when this modification is executed.</para>
    /// </summary>
    public void SetHeldModificationStack(SkeletonModificationStack2D heldModificationStack)
    {
        NativeCalls.godot_icall_1_56(MethodBind0, GodotObject.GetPtr(this), GodotObject.GetPtr(heldModificationStack));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetHeldModificationStack, 2107508396ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.SkeletonModificationStack2D"/> that this modification is holding.</para>
    /// </summary>
    public SkeletonModificationStack2D GetHeldModificationStack()
    {
        return (SkeletonModificationStack2D)NativeCalls.godot_icall_0_63(MethodBind1, GodotObject.GetPtr(this));
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
    public new class PropertyName : SkeletonModification2D.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : SkeletonModification2D.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_held_modification_stack' method.
        /// </summary>
        public static readonly StringName SetHeldModificationStack = "set_held_modification_stack";
        /// <summary>
        /// Cached name for the 'get_held_modification_stack' method.
        /// </summary>
        public static readonly StringName GetHeldModificationStack = "get_held_modification_stack";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : SkeletonModification2D.SignalName
    {
    }
}
