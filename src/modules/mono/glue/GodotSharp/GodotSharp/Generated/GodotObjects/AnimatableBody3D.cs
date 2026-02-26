namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>An animatable 3D physics body. It can't be moved by external forces or contacts, but can be moved manually by other means such as code, <see cref="Godot.AnimationMixer"/>s (with <see cref="Godot.AnimationMixer.CallbackModeProcess"/> set to <see cref="Godot.AnimationMixer.AnimationCallbackModeProcess.Physics"/>), and <see cref="Godot.RemoteTransform3D"/>.</para>
/// <para>When <see cref="Godot.AnimatableBody3D"/> is moved, its linear and angular velocity are estimated and used to affect other physics bodies in its path. This makes it useful for moving platforms, doors, and other moving objects.</para>
/// </summary>
public partial class AnimatableBody3D : StaticBody3D
{
    /// <summary>
    /// <para>If <see langword="true"/>, the body's movement will be synchronized to the physics frame. This is useful when animating movement via <see cref="Godot.AnimationPlayer"/>, for example on moving platforms. Do <b>not</b> use together with <see cref="Godot.PhysicsBody3D.MoveAndCollide(Vector3, bool, float, bool, int)"/>.</para>
    /// </summary>
    public bool SyncToPhysics
    {
        get
        {
            return IsSyncToPhysicsEnabled();
        }
        set
        {
            SetSyncToPhysics(value);
        }
    }

    private static readonly System.Type CachedType = typeof(AnimatableBody3D);

    private static readonly StringName NativeName = "AnimatableBody3D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public AnimatableBody3D() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal AnimatableBody3D(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal AnimatableBody3D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSyncToPhysics, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSyncToPhysics(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind0, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsSyncToPhysicsEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsSyncToPhysicsEnabled()
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
    public new class PropertyName : StaticBody3D.PropertyName
    {
        /// <summary>
        /// Cached name for the 'sync_to_physics' property.
        /// </summary>
        public static readonly StringName SyncToPhysics = "sync_to_physics";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : StaticBody3D.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_sync_to_physics' method.
        /// </summary>
        public static readonly StringName SetSyncToPhysics = "set_sync_to_physics";
        /// <summary>
        /// Cached name for the 'is_sync_to_physics_enabled' method.
        /// </summary>
        public static readonly StringName IsSyncToPhysicsEnabled = "is_sync_to_physics_enabled";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : StaticBody3D.SignalName
    {
    }
}
