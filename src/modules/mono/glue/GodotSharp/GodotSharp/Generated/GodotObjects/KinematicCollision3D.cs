namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Holds collision data from the movement of a <see cref="Godot.PhysicsBody3D"/>, usually from <see cref="Godot.PhysicsBody3D.MoveAndCollide(Vector3, bool, float, bool, int)"/>. When a <see cref="Godot.PhysicsBody3D"/> is moved, it stops if it detects a collision with another body. If a collision is detected, a <see cref="Godot.KinematicCollision3D"/> object is returned.</para>
/// <para>The collision data includes the colliding object, the remaining motion, and the collision position. This data can be used to determine a custom response to the collision.</para>
/// </summary>
public partial class KinematicCollision3D : RefCounted
{
    private static readonly System.Type CachedType = typeof(KinematicCollision3D);

    private static readonly StringName NativeName = "KinematicCollision3D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public KinematicCollision3D() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal KinematicCollision3D(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal KinematicCollision3D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTravel, 3360562783ul);

    /// <summary>
    /// <para>Returns the moving object's travel before collision.</para>
    /// </summary>
    public Vector3 GetTravel()
    {
        return NativeCalls.godot_icall_0_125(MethodBind0, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRemainder, 3360562783ul);

    /// <summary>
    /// <para>Returns the moving object's remaining movement vector.</para>
    /// </summary>
    public Vector3 GetRemainder()
    {
        return NativeCalls.godot_icall_0_125(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDepth, 1740695150ul);

    /// <summary>
    /// <para>Returns the colliding body's length of overlap along the collision normal.</para>
    /// </summary>
    public float GetDepth()
    {
        return NativeCalls.godot_icall_0_68(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCollisionCount, 3905245786ul);

    /// <summary>
    /// <para>Returns the number of detected collisions.</para>
    /// </summary>
    public int GetCollisionCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPosition, 1914908202ul);

    /// <summary>
    /// <para>Returns the point of collision in global coordinates given a collision index (the deepest collision by default).</para>
    /// </summary>
    public Vector3 GetPosition(int collisionIndex = 0)
    {
        return NativeCalls.godot_icall_1_363(MethodBind4, GodotObject.GetPtr(this), collisionIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNormal, 1914908202ul);

    /// <summary>
    /// <para>Returns the colliding body's shape's normal at the point of collision given a collision index (the deepest collision by default).</para>
    /// </summary>
    public Vector3 GetNormal(int collisionIndex = 0)
    {
        return NativeCalls.godot_icall_1_363(MethodBind5, GodotObject.GetPtr(this), collisionIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAngle, 1242741860ul);

    /// <summary>
    /// <para>Returns the collision angle according to <paramref name="upDirection"/>, which is <c>Vector3.UP</c> by default. This value is always positive.</para>
    /// </summary>
    /// <param name="upDirection">If the parameter is null, then the default value is <c>new Vector3(0.0f, 1.0f, 0.0f)</c>.</param>
    public unsafe float GetAngle(int collisionIndex = 0, Nullable<Vector3> upDirection = null)
    {
        Vector3 upDirectionOrDefVal = upDirection.HasValue ? upDirection.Value : new Vector3(0.0f, 1.0f, 0.0f);
        return NativeCalls.godot_icall_2_784(MethodBind6, GodotObject.GetPtr(this), collisionIndex, &upDirectionOrDefVal);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLocalShape, 2639523548ul);

    /// <summary>
    /// <para>Returns the moving object's colliding shape given a collision index (the deepest collision by default).</para>
    /// </summary>
    public GodotObject GetLocalShape(int collisionIndex = 0)
    {
        return (GodotObject)NativeCalls.godot_icall_1_335(MethodBind7, GodotObject.GetPtr(this), collisionIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCollider, 2639523548ul);

    /// <summary>
    /// <para>Returns the colliding body's attached <see cref="Godot.GodotObject"/> given a collision index (the deepest collision by default).</para>
    /// </summary>
    public GodotObject GetCollider(int collisionIndex = 0)
    {
        return (GodotObject)NativeCalls.godot_icall_1_335(MethodBind8, GodotObject.GetPtr(this), collisionIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetColliderId, 1591665591ul);

    /// <summary>
    /// <para>Returns the unique instance ID of the colliding body's attached <see cref="Godot.GodotObject"/> given a collision index (the deepest collision by default). See <see cref="Godot.GodotObject.GetInstanceId()"/>.</para>
    /// </summary>
    public ulong GetColliderId(int collisionIndex = 0)
    {
        return NativeCalls.godot_icall_1_240(MethodBind9, GodotObject.GetPtr(this), collisionIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetColliderRid, 1231817359ul);

    /// <summary>
    /// <para>Returns the colliding body's <see cref="Godot.Rid"/> used by the <see cref="Godot.PhysicsServer3D"/> given a collision index (the deepest collision by default).</para>
    /// </summary>
    public Rid GetColliderRid(int collisionIndex = 0)
    {
        return NativeCalls.godot_icall_1_425(MethodBind10, GodotObject.GetPtr(this), collisionIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetColliderShape, 2639523548ul);

    /// <summary>
    /// <para>Returns the colliding body's shape given a collision index (the deepest collision by default).</para>
    /// </summary>
    public GodotObject GetColliderShape(int collisionIndex = 0)
    {
        return (GodotObject)NativeCalls.godot_icall_1_335(MethodBind11, GodotObject.GetPtr(this), collisionIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetColliderShapeIndex, 1591665591ul);

    /// <summary>
    /// <para>Returns the colliding body's shape index given a collision index (the deepest collision by default). See <see cref="Godot.CollisionObject3D"/>.</para>
    /// </summary>
    public int GetColliderShapeIndex(int collisionIndex = 0)
    {
        return NativeCalls.godot_icall_1_60(MethodBind12, GodotObject.GetPtr(this), collisionIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetColliderVelocity, 1914908202ul);

    /// <summary>
    /// <para>Returns the colliding body's velocity given a collision index (the deepest collision by default).</para>
    /// </summary>
    public Vector3 GetColliderVelocity(int collisionIndex = 0)
    {
        return NativeCalls.godot_icall_1_363(MethodBind13, GodotObject.GetPtr(this), collisionIndex);
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
        /// Cached name for the 'get_travel' method.
        /// </summary>
        public static readonly StringName GetTravel = "get_travel";
        /// <summary>
        /// Cached name for the 'get_remainder' method.
        /// </summary>
        public static readonly StringName GetRemainder = "get_remainder";
        /// <summary>
        /// Cached name for the 'get_depth' method.
        /// </summary>
        public static readonly StringName GetDepth = "get_depth";
        /// <summary>
        /// Cached name for the 'get_collision_count' method.
        /// </summary>
        public static readonly StringName GetCollisionCount = "get_collision_count";
        /// <summary>
        /// Cached name for the 'get_position' method.
        /// </summary>
        public static readonly StringName GetPosition = "get_position";
        /// <summary>
        /// Cached name for the 'get_normal' method.
        /// </summary>
        public static readonly StringName GetNormal = "get_normal";
        /// <summary>
        /// Cached name for the 'get_angle' method.
        /// </summary>
        public static readonly StringName GetAngle = "get_angle";
        /// <summary>
        /// Cached name for the 'get_local_shape' method.
        /// </summary>
        public static readonly StringName GetLocalShape = "get_local_shape";
        /// <summary>
        /// Cached name for the 'get_collider' method.
        /// </summary>
        public static readonly StringName GetCollider = "get_collider";
        /// <summary>
        /// Cached name for the 'get_collider_id' method.
        /// </summary>
        public static readonly StringName GetColliderId = "get_collider_id";
        /// <summary>
        /// Cached name for the 'get_collider_rid' method.
        /// </summary>
        public static readonly StringName GetColliderRid = "get_collider_rid";
        /// <summary>
        /// Cached name for the 'get_collider_shape' method.
        /// </summary>
        public static readonly StringName GetColliderShape = "get_collider_shape";
        /// <summary>
        /// Cached name for the 'get_collider_shape_index' method.
        /// </summary>
        public static readonly StringName GetColliderShapeIndex = "get_collider_shape_index";
        /// <summary>
        /// Cached name for the 'get_collider_velocity' method.
        /// </summary>
        public static readonly StringName GetColliderVelocity = "get_collider_velocity";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : RefCounted.SignalName
    {
    }
}
