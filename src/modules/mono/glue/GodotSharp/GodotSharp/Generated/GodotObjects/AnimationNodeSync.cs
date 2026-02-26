namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>An animation node used to combine, mix, or blend two or more animations together while keeping them synchronized within an <see cref="Godot.AnimationTree"/>.</para>
/// </summary>
public partial class AnimationNodeSync : AnimationNode
{
    /// <summary>
    /// <para>If <see langword="false"/>, the blended animations' frame are stopped when the blend value is <c>0</c>.</para>
    /// <para>If <see langword="true"/>, forcing the blended animations to advance frame.</para>
    /// </summary>
    public bool Sync
    {
        get
        {
            return IsUsingSync();
        }
        set
        {
            SetUseSync(value);
        }
    }

    private static readonly System.Type CachedType = typeof(AnimationNodeSync);

    private static readonly StringName NativeName = "AnimationNodeSync";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public AnimationNodeSync() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal AnimationNodeSync(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal AnimationNodeSync(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetUseSync, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetUseSync(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind0, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsUsingSync, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsUsingSync()
    {
        return NativeCalls.godot_icall_0_15(MethodBind1, GodotObject.GetPtr(this)).ToBool();
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
    public new class PropertyName : AnimationNode.PropertyName
    {
        /// <summary>
        /// Cached name for the 'sync' property.
        /// </summary>
        public static readonly StringName Sync = "sync";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : AnimationNode.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_use_sync' method.
        /// </summary>
        public static readonly StringName SetUseSync = "set_use_sync";
        /// <summary>
        /// Cached name for the 'is_using_sync' method.
        /// </summary>
        public static readonly StringName IsUsingSync = "is_using_sync";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : AnimationNode.SignalName
    {
    }
}
