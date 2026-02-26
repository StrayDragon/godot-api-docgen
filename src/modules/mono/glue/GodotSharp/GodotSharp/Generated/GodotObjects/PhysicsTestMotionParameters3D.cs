namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>By changing various properties of this object, such as the motion, you can configure the parameters for <see cref="Godot.PhysicsServer3D.BodyTestMotion(Rid, PhysicsTestMotionParameters3D, PhysicsTestMotionResult3D)"/>.</para>
/// </summary>
public partial class PhysicsTestMotionParameters3D : RefCounted
{
    /// <summary>
    /// <para>Transform in global space where the motion should start. Usually set to <see cref="Godot.Node3D.GlobalTransform"/> for the current body's transform.</para>
    /// </summary>
    public Transform3D From
    {
        get
        {
            return GetFrom();
        }
        set
        {
            SetFrom(value);
        }
    }

    /// <summary>
    /// <para>Motion vector to define the length and direction of the motion to test.</para>
    /// </summary>
    public Vector3 Motion
    {
        get
        {
            return GetMotion();
        }
        set
        {
            SetMotion(value);
        }
    }

    /// <summary>
    /// <para>Increases the size of the shapes involved in the collision detection.</para>
    /// </summary>
    public float Margin
    {
        get
        {
            return GetMargin();
        }
        set
        {
            SetMargin(value);
        }
    }

    /// <summary>
    /// <para>Maximum number of returned collisions, between <c>1</c> and <c>32</c>. Always returns the deepest detected collisions.</para>
    /// </summary>
    public int MaxCollisions
    {
        get
        {
            return GetMaxCollisions();
        }
        set
        {
            SetMaxCollisions(value);
        }
    }

    /// <summary>
    /// <para>If set to <see langword="true"/>, shapes of type <see cref="Godot.PhysicsServer3D.ShapeType.SeparationRay"/> are used to detect collisions and can stop the motion. Can be useful when snapping to the ground.</para>
    /// <para>If set to <see langword="false"/>, shapes of type <see cref="Godot.PhysicsServer3D.ShapeType.SeparationRay"/> are only used for separation when overlapping with other bodies. That's the main use for separation ray shapes.</para>
    /// </summary>
    public bool CollideSeparationRay
    {
        get
        {
            return IsCollideSeparationRayEnabled();
        }
        set
        {
            SetCollideSeparationRayEnabled(value);
        }
    }

    /// <summary>
    /// <para>Optional array of body <see cref="Godot.Rid"/> to exclude from collision. Use <see cref="Godot.CollisionObject3D.GetRid()"/> to get the <see cref="Godot.Rid"/> associated with a <see cref="Godot.CollisionObject3D"/>-derived node.</para>
    /// </summary>
    public Godot.Collections.Array<Rid> ExcludeBodies
    {
        get
        {
            return GetExcludeBodies();
        }
        set
        {
            SetExcludeBodies(value);
        }
    }

    /// <summary>
    /// <para>Optional array of object unique instance ID to exclude from collision. See <see cref="Godot.GodotObject.GetInstanceId()"/>.</para>
    /// </summary>
    public Godot.Collections.Array<int> ExcludeObjects
    {
        get
        {
            return GetExcludeObjects();
        }
        set
        {
            SetExcludeObjects(value);
        }
    }

    /// <summary>
    /// <para>If set to <see langword="true"/>, any depenetration from the recovery phase is reported as a collision; this is used e.g. by <see cref="Godot.CharacterBody3D"/> for improving floor detection during floor snapping.</para>
    /// <para>If set to <see langword="false"/>, only collisions resulting from the motion are reported, which is generally the desired behavior.</para>
    /// </summary>
    public bool RecoveryAsCollision
    {
        get
        {
            return IsRecoveryAsCollisionEnabled();
        }
        set
        {
            SetRecoveryAsCollisionEnabled(value);
        }
    }

    private static readonly System.Type CachedType = typeof(PhysicsTestMotionParameters3D);

    private static readonly StringName NativeName = "PhysicsTestMotionParameters3D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public PhysicsTestMotionParameters3D() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal PhysicsTestMotionParameters3D(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal PhysicsTestMotionParameters3D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFrom, 3229777777ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Transform3D GetFrom()
    {
        return NativeCalls.godot_icall_0_192(MethodBind0, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFrom, 2952846383ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetFrom(Transform3D from)
    {
        NativeCalls.godot_icall_1_648(MethodBind1, GodotObject.GetPtr(this), &from);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMotion, 3360562783ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector3 GetMotion()
    {
        return NativeCalls.godot_icall_0_125(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMotion, 3460891852ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetMotion(Vector3 motion)
    {
        NativeCalls.godot_icall_1_177(MethodBind3, GodotObject.GetPtr(this), &motion);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMargin, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetMargin()
    {
        return NativeCalls.godot_icall_0_68(MethodBind4, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMargin, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMargin(float margin)
    {
        NativeCalls.godot_icall_1_67(MethodBind5, GodotObject.GetPtr(this), margin);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMaxCollisions, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetMaxCollisions()
    {
        return NativeCalls.godot_icall_0_39(MethodBind6, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMaxCollisions, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMaxCollisions(int maxCollisions)
    {
        NativeCalls.godot_icall_1_38(MethodBind7, GodotObject.GetPtr(this), maxCollisions);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsCollideSeparationRayEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsCollideSeparationRayEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind8, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCollideSeparationRayEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCollideSeparationRayEnabled(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind9, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetExcludeBodies, 3995934104ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Godot.Collections.Array<Rid> GetExcludeBodies()
    {
        return new Godot.Collections.Array<Rid>(NativeCalls.godot_icall_0_120(MethodBind10, GodotObject.GetPtr(this)));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetExcludeBodies, 381264803ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetExcludeBodies(Godot.Collections.Array<Rid> excludeList)
    {
        NativeCalls.godot_icall_1_138(MethodBind11, GodotObject.GetPtr(this), (godot_array)(excludeList ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetExcludeObjects, 3995934104ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Godot.Collections.Array<int> GetExcludeObjects()
    {
        return new Godot.Collections.Array<int>(NativeCalls.godot_icall_0_120(MethodBind12, GodotObject.GetPtr(this)));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetExcludeObjects, 381264803ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetExcludeObjects(Godot.Collections.Array<int> excludeList)
    {
        NativeCalls.godot_icall_1_138(MethodBind13, GodotObject.GetPtr(this), (godot_array)(excludeList ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsRecoveryAsCollisionEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsRecoveryAsCollisionEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind14, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRecoveryAsCollisionEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetRecoveryAsCollisionEnabled(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind15, GodotObject.GetPtr(this), enabled.ToGodotBool());
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
        /// <summary>
        /// Cached name for the 'from' property.
        /// </summary>
        public static readonly StringName From = "from";
        /// <summary>
        /// Cached name for the 'motion' property.
        /// </summary>
        public static readonly StringName Motion = "motion";
        /// <summary>
        /// Cached name for the 'margin' property.
        /// </summary>
        public static readonly StringName Margin = "margin";
        /// <summary>
        /// Cached name for the 'max_collisions' property.
        /// </summary>
        public static readonly StringName MaxCollisions = "max_collisions";
        /// <summary>
        /// Cached name for the 'collide_separation_ray' property.
        /// </summary>
        public static readonly StringName CollideSeparationRay = "collide_separation_ray";
        /// <summary>
        /// Cached name for the 'exclude_bodies' property.
        /// </summary>
        public static readonly StringName ExcludeBodies = "exclude_bodies";
        /// <summary>
        /// Cached name for the 'exclude_objects' property.
        /// </summary>
        public static readonly StringName ExcludeObjects = "exclude_objects";
        /// <summary>
        /// Cached name for the 'recovery_as_collision' property.
        /// </summary>
        public static readonly StringName RecoveryAsCollision = "recovery_as_collision";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : RefCounted.MethodName
    {
        /// <summary>
        /// Cached name for the 'get_from' method.
        /// </summary>
        public static readonly StringName GetFrom = "get_from";
        /// <summary>
        /// Cached name for the 'set_from' method.
        /// </summary>
        public static readonly StringName SetFrom = "set_from";
        /// <summary>
        /// Cached name for the 'get_motion' method.
        /// </summary>
        public static readonly StringName GetMotion = "get_motion";
        /// <summary>
        /// Cached name for the 'set_motion' method.
        /// </summary>
        public static readonly StringName SetMotion = "set_motion";
        /// <summary>
        /// Cached name for the 'get_margin' method.
        /// </summary>
        public static readonly StringName GetMargin = "get_margin";
        /// <summary>
        /// Cached name for the 'set_margin' method.
        /// </summary>
        public static readonly StringName SetMargin = "set_margin";
        /// <summary>
        /// Cached name for the 'get_max_collisions' method.
        /// </summary>
        public static readonly StringName GetMaxCollisions = "get_max_collisions";
        /// <summary>
        /// Cached name for the 'set_max_collisions' method.
        /// </summary>
        public static readonly StringName SetMaxCollisions = "set_max_collisions";
        /// <summary>
        /// Cached name for the 'is_collide_separation_ray_enabled' method.
        /// </summary>
        public static readonly StringName IsCollideSeparationRayEnabled = "is_collide_separation_ray_enabled";
        /// <summary>
        /// Cached name for the 'set_collide_separation_ray_enabled' method.
        /// </summary>
        public static readonly StringName SetCollideSeparationRayEnabled = "set_collide_separation_ray_enabled";
        /// <summary>
        /// Cached name for the 'get_exclude_bodies' method.
        /// </summary>
        public static readonly StringName GetExcludeBodies = "get_exclude_bodies";
        /// <summary>
        /// Cached name for the 'set_exclude_bodies' method.
        /// </summary>
        public static readonly StringName SetExcludeBodies = "set_exclude_bodies";
        /// <summary>
        /// Cached name for the 'get_exclude_objects' method.
        /// </summary>
        public static readonly StringName GetExcludeObjects = "get_exclude_objects";
        /// <summary>
        /// Cached name for the 'set_exclude_objects' method.
        /// </summary>
        public static readonly StringName SetExcludeObjects = "set_exclude_objects";
        /// <summary>
        /// Cached name for the 'is_recovery_as_collision_enabled' method.
        /// </summary>
        public static readonly StringName IsRecoveryAsCollisionEnabled = "is_recovery_as_collision_enabled";
        /// <summary>
        /// Cached name for the 'set_recovery_as_collision_enabled' method.
        /// </summary>
        public static readonly StringName SetRecoveryAsCollisionEnabled = "set_recovery_as_collision_enabled";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : RefCounted.SignalName
    {
    }
}
