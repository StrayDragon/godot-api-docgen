namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Holds collision data from the movement of a <see cref="Godot.PhysicsBody2D"/>, usually from <see cref="Godot.PhysicsBody2D.MoveAndCollide(Vector2, bool, float, bool)"/>. When a <see cref="Godot.PhysicsBody2D"/> is moved, it stops if it detects a collision with another body. If a collision is detected, a <see cref="Godot.KinematicCollision2D"/> object is returned.</para>
/// <para>The collision data includes the colliding object, the remaining motion, and the collision position. This data can be used to determine a custom response to the collision.</para>
/// </summary>
public partial class KinematicCollision2D : RefCounted
{
    private static readonly System.Type CachedType = typeof(KinematicCollision2D);

    private static readonly StringName NativeName = "KinematicCollision2D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public KinematicCollision2D() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal KinematicCollision2D(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal KinematicCollision2D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPosition, 3341600327ul);

    /// <summary>
    /// <para>Returns the point of collision in global coordinates.</para>
    /// </summary>
    public Vector2 GetPosition()
    {
        return NativeCalls.godot_icall_0_37(MethodBind0, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNormal, 3341600327ul);

    /// <summary>
    /// <para>Returns the colliding body's shape's normal at the point of collision.</para>
    /// </summary>
    public Vector2 GetNormal()
    {
        return NativeCalls.godot_icall_0_37(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTravel, 3341600327ul);

    /// <summary>
    /// <para>Returns the moving object's travel before collision.</para>
    /// </summary>
    public Vector2 GetTravel()
    {
        return NativeCalls.godot_icall_0_37(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRemainder, 3341600327ul);

    /// <summary>
    /// <para>Returns the moving object's remaining movement vector.</para>
    /// </summary>
    public Vector2 GetRemainder()
    {
        return NativeCalls.godot_icall_0_37(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAngle, 2841063350ul);

    /// <summary>
    /// <para>Returns the collision angle according to <paramref name="upDirection"/>, which is <c>Vector2.UP</c> by default. This value is always positive.</para>
    /// </summary>
    /// <param name="upDirection">If the parameter is null, then the default value is <c>new Vector2(0.0f, -1.0f)</c>.</param>
    public unsafe float GetAngle(Nullable<Vector2> upDirection = null)
    {
        Vector2 upDirectionOrDefVal = upDirection.HasValue ? upDirection.Value : new Vector2(0.0f, -1.0f);
        return NativeCalls.godot_icall_1_287(MethodBind4, GodotObject.GetPtr(this), &upDirectionOrDefVal);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDepth, 1740695150ul);

    /// <summary>
    /// <para>Returns the colliding body's length of overlap along the collision normal.</para>
    /// </summary>
    public float GetDepth()
    {
        return NativeCalls.godot_icall_0_68(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLocalShape, 1981248198ul);

    /// <summary>
    /// <para>Returns the moving object's colliding shape.</para>
    /// </summary>
    public GodotObject GetLocalShape()
    {
        return (GodotObject)NativeCalls.godot_icall_0_53(MethodBind6, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCollider, 1981248198ul);

    /// <summary>
    /// <para>Returns the colliding body's attached <see cref="Godot.GodotObject"/>.</para>
    /// </summary>
    public GodotObject GetCollider()
    {
        return (GodotObject)NativeCalls.godot_icall_0_53(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetColliderId, 3905245786ul);

    /// <summary>
    /// <para>Returns the unique instance ID of the colliding body's attached <see cref="Godot.GodotObject"/>. See <see cref="Godot.GodotObject.GetInstanceId()"/>.</para>
    /// </summary>
    public ulong GetColliderId()
    {
        return NativeCalls.godot_icall_0_137(MethodBind8, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetColliderRid, 2944877500ul);

    /// <summary>
    /// <para>Returns the colliding body's <see cref="Godot.Rid"/> used by the <see cref="Godot.PhysicsServer2D"/>.</para>
    /// </summary>
    public Rid GetColliderRid()
    {
        return NativeCalls.godot_icall_0_238(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetColliderShape, 1981248198ul);

    /// <summary>
    /// <para>Returns the colliding body's shape.</para>
    /// </summary>
    public GodotObject GetColliderShape()
    {
        return (GodotObject)NativeCalls.godot_icall_0_53(MethodBind10, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetColliderShapeIndex, 3905245786ul);

    /// <summary>
    /// <para>Returns the colliding body's shape index. See <see cref="Godot.CollisionObject2D"/>.</para>
    /// </summary>
    public int GetColliderShapeIndex()
    {
        return NativeCalls.godot_icall_0_39(MethodBind11, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetColliderVelocity, 3341600327ul);

    /// <summary>
    /// <para>Returns the colliding body's velocity.</para>
    /// </summary>
    public Vector2 GetColliderVelocity()
    {
        return NativeCalls.godot_icall_0_37(MethodBind12, GodotObject.GetPtr(this));
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
        /// Cached name for the 'get_position' method.
        /// </summary>
        public static readonly StringName GetPosition = "get_position";
        /// <summary>
        /// Cached name for the 'get_normal' method.
        /// </summary>
        public static readonly StringName GetNormal = "get_normal";
        /// <summary>
        /// Cached name for the 'get_travel' method.
        /// </summary>
        public static readonly StringName GetTravel = "get_travel";
        /// <summary>
        /// Cached name for the 'get_remainder' method.
        /// </summary>
        public static readonly StringName GetRemainder = "get_remainder";
        /// <summary>
        /// Cached name for the 'get_angle' method.
        /// </summary>
        public static readonly StringName GetAngle = "get_angle";
        /// <summary>
        /// Cached name for the 'get_depth' method.
        /// </summary>
        public static readonly StringName GetDepth = "get_depth";
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
