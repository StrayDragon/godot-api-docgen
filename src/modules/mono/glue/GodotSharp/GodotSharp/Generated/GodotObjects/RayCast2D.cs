namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A raycast represents a ray from its origin to its <see cref="Godot.RayCast2D.TargetPosition"/> that finds the closest object along its path, if it intersects any.</para>
/// <para><see cref="Godot.RayCast2D"/> can ignore some objects by adding them to an exception list, by making its detection reporting ignore <see cref="Godot.Area2D"/>s (<see cref="Godot.RayCast2D.CollideWithAreas"/>) or <see cref="Godot.PhysicsBody2D"/>s (<see cref="Godot.RayCast2D.CollideWithBodies"/>), or by configuring physics layers.</para>
/// <para><see cref="Godot.RayCast2D"/> calculates intersection every physics frame, and it holds the result until the next physics frame. For an immediate raycast, or if you want to configure a <see cref="Godot.RayCast2D"/> multiple times within the same physics frame, use <see cref="Godot.RayCast2D.ForceRaycastUpdate()"/>.</para>
/// <para>To sweep over a region of 2D space, you can approximate the region with multiple <see cref="Godot.RayCast2D"/>s or use <see cref="Godot.ShapeCast2D"/>.</para>
/// </summary>
public partial class RayCast2D : Node2D
{
    /// <summary>
    /// <para>If <see langword="true"/>, collisions will be reported.</para>
    /// </summary>
    public bool Enabled
    {
        get
        {
            return IsEnabled();
        }
        set
        {
            SetEnabled(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, this raycast will not report collisions with its parent node. This property only has an effect if the parent node is a <see cref="Godot.CollisionObject2D"/>. See also <see cref="Godot.Node.GetParent()"/> and <see cref="Godot.RayCast2D.AddException(CollisionObject2D)"/>.</para>
    /// </summary>
    public bool ExcludeParent
    {
        get
        {
            return GetExcludeParentBody();
        }
        set
        {
            SetExcludeParentBody(value);
        }
    }

    /// <summary>
    /// <para>The ray's destination point, relative to this raycast's <see cref="Godot.Node2D.Position"/>.</para>
    /// </summary>
    public Vector2 TargetPosition
    {
        get
        {
            return GetTargetPosition();
        }
        set
        {
            SetTargetPosition(value);
        }
    }

    /// <summary>
    /// <para>The ray's collision mask. Only objects in at least one collision layer enabled in the mask will be detected. See <a href="$DOCS_URL/tutorials/physics/physics_introduction.html#collision-layers-and-masks">Collision layers and masks</a> in the documentation for more information.</para>
    /// </summary>
    public uint CollisionMask
    {
        get
        {
            return GetCollisionMask();
        }
        set
        {
            SetCollisionMask(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the ray will detect a hit when starting inside shapes. In this case the collision normal will be <c>Vector2(0, 0)</c>. Does not affect concave polygon shapes.</para>
    /// </summary>
    public bool HitFromInside
    {
        get
        {
            return IsHitFromInsideEnabled();
        }
        set
        {
            SetHitFromInside(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, collisions with <see cref="Godot.Area2D"/>s will be reported.</para>
    /// </summary>
    public bool CollideWithAreas
    {
        get
        {
            return IsCollideWithAreasEnabled();
        }
        set
        {
            SetCollideWithAreas(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, collisions with <see cref="Godot.PhysicsBody2D"/>s will be reported.</para>
    /// </summary>
    public bool CollideWithBodies
    {
        get
        {
            return IsCollideWithBodiesEnabled();
        }
        set
        {
            SetCollideWithBodies(value);
        }
    }

    private static readonly System.Type CachedType = typeof(RayCast2D);

    private static readonly StringName NativeName = "RayCast2D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public RayCast2D() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal RayCast2D(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal RayCast2D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEnabled(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind0, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind1, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTargetPosition, 743155724ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetTargetPosition(Vector2 localPoint)
    {
        NativeCalls.godot_icall_1_36(MethodBind2, GodotObject.GetPtr(this), &localPoint);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTargetPosition, 3341600327ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2 GetTargetPosition()
    {
        return NativeCalls.godot_icall_0_37(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsColliding, 36873697ul);

    /// <summary>
    /// <para>Returns whether any object is intersecting with the ray's vector (considering the vector length).</para>
    /// </summary>
    public bool IsColliding()
    {
        return NativeCalls.godot_icall_0_15(MethodBind4, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ForceRaycastUpdate, 3218959716ul);

    /// <summary>
    /// <para>Updates the collision information for the ray immediately, without waiting for the next <c>_physics_process</c> call. Use this method, for example, when the ray or its parent has changed state.</para>
    /// <para><b>Note:</b> <see cref="Godot.RayCast2D.Enabled"/> does not need to be <see langword="true"/> for this to work.</para>
    /// </summary>
    public void ForceRaycastUpdate()
    {
        NativeCalls.godot_icall_0_3(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCollider, 1981248198ul);

    /// <summary>
    /// <para>Returns the first object that the ray intersects, or <see langword="null"/> if no object is intersecting the ray (i.e. <see cref="Godot.RayCast2D.IsColliding()"/> returns <see langword="false"/>).</para>
    /// <para><b>Note:</b> This object is not guaranteed to be a <see cref="Godot.CollisionObject2D"/>. For example, if the ray intersects a <see cref="Godot.TileMapLayer"/>, the method will return a <see cref="Godot.TileMapLayer"/> instance.</para>
    /// </summary>
    public GodotObject GetCollider()
    {
        return (GodotObject)NativeCalls.godot_icall_0_53(MethodBind6, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetColliderRid, 2944877500ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.Rid"/> of the first object that the ray intersects, or an empty <see cref="Godot.Rid"/> if no object is intersecting the ray (i.e. <see cref="Godot.RayCast2D.IsColliding()"/> returns <see langword="false"/>).</para>
    /// </summary>
    public Rid GetColliderRid()
    {
        return NativeCalls.godot_icall_0_238(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetColliderShape, 3905245786ul);

    /// <summary>
    /// <para>Returns the shape ID of the first object that the ray intersects, or <c>0</c> if no object is intersecting the ray (i.e. <see cref="Godot.RayCast2D.IsColliding()"/> returns <see langword="false"/>).</para>
    /// <para>To get the intersected shape node, for a <see cref="Godot.CollisionObject2D"/> target, use:</para>
    /// <para><code>
    /// var target = (CollisionObject2D)GetCollider(); // A CollisionObject2D.
    /// var shapeId = GetColliderShape(); // The shape index in the collider.
    /// var ownerId = target.ShapeFindOwner(shapeId); // The owner ID in the collider.
    /// var shape = target.ShapeOwnerGetOwner(ownerId);
    /// </code></para>
    /// </summary>
    public int GetColliderShape()
    {
        return NativeCalls.godot_icall_0_39(MethodBind8, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCollisionPoint, 3341600327ul);

    /// <summary>
    /// <para>Returns the collision point at which the ray intersects the closest object, in the global coordinate system. If <see cref="Godot.RayCast2D.HitFromInside"/> is <see langword="true"/> and the ray starts inside of a collision shape, this function will return the origin point of the ray.</para>
    /// <para><b>Note:</b> Check that <see cref="Godot.RayCast2D.IsColliding()"/> returns <see langword="true"/> before calling this method to ensure the returned point is valid and up-to-date.</para>
    /// </summary>
    public Vector2 GetCollisionPoint()
    {
        return NativeCalls.godot_icall_0_37(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCollisionNormal, 3341600327ul);

    /// <summary>
    /// <para>Returns the normal of the intersecting object's shape at the collision point, or <c>Vector2(0, 0)</c> if the ray starts inside the shape and <see cref="Godot.RayCast2D.HitFromInside"/> is <see langword="true"/>.</para>
    /// <para><b>Note:</b> Check that <see cref="Godot.RayCast2D.IsColliding()"/> returns <see langword="true"/> before calling this method to ensure the returned normal is valid and up-to-date.</para>
    /// </summary>
    public Vector2 GetCollisionNormal()
    {
        return NativeCalls.godot_icall_0_37(MethodBind10, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddExceptionRid, 2722037293ul);

    /// <summary>
    /// <para>Adds a collision exception so the ray does not report collisions with the specified <see cref="Godot.Rid"/>.</para>
    /// </summary>
    public void AddExceptionRid(Rid rid)
    {
        NativeCalls.godot_icall_1_286(MethodBind11, GodotObject.GetPtr(this), rid);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddException, 3090941106ul);

    /// <summary>
    /// <para>Adds a collision exception so the ray does not report collisions with the specified <paramref name="node"/>.</para>
    /// </summary>
    public void AddException(CollisionObject2D node)
    {
        NativeCalls.godot_icall_1_56(MethodBind12, GodotObject.GetPtr(this), GodotObject.GetPtr(node));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveExceptionRid, 2722037293ul);

    /// <summary>
    /// <para>Removes a collision exception so the ray can report collisions with the specified <see cref="Godot.Rid"/>.</para>
    /// </summary>
    public void RemoveExceptionRid(Rid rid)
    {
        NativeCalls.godot_icall_1_286(MethodBind13, GodotObject.GetPtr(this), rid);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveException, 3090941106ul);

    /// <summary>
    /// <para>Removes a collision exception so the ray can report collisions with the specified <paramref name="node"/>.</para>
    /// </summary>
    public void RemoveException(CollisionObject2D node)
    {
        NativeCalls.godot_icall_1_56(MethodBind14, GodotObject.GetPtr(this), GodotObject.GetPtr(node));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ClearExceptions, 3218959716ul);

    /// <summary>
    /// <para>Removes all collision exceptions for this ray.</para>
    /// </summary>
    public void ClearExceptions()
    {
        NativeCalls.godot_icall_0_3(MethodBind15, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCollisionMask, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCollisionMask(uint mask)
    {
        NativeCalls.godot_icall_1_208(MethodBind16, GodotObject.GetPtr(this), mask);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCollisionMask, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public uint GetCollisionMask()
    {
        return NativeCalls.godot_icall_0_209(MethodBind17, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCollisionMaskValue, 300928843ul);

    /// <summary>
    /// <para>Based on <paramref name="value"/>, enables or disables the specified layer in the <see cref="Godot.RayCast2D.CollisionMask"/>, given a <paramref name="layerNumber"/> between 1 and 32.</para>
    /// </summary>
    public void SetCollisionMaskValue(int layerNumber, bool value)
    {
        NativeCalls.godot_icall_2_61(MethodBind18, GodotObject.GetPtr(this), layerNumber, value.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCollisionMaskValue, 1116898809ul);

    /// <summary>
    /// <para>Returns whether or not the specified layer of the <see cref="Godot.RayCast2D.CollisionMask"/> is enabled, given a <paramref name="layerNumber"/> between 1 and 32.</para>
    /// </summary>
    public bool GetCollisionMaskValue(int layerNumber)
    {
        return NativeCalls.godot_icall_1_62(MethodBind19, GodotObject.GetPtr(this), layerNumber).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetExcludeParentBody, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetExcludeParentBody(bool mask)
    {
        NativeCalls.godot_icall_1_14(MethodBind20, GodotObject.GetPtr(this), mask.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetExcludeParentBody, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetExcludeParentBody()
    {
        return NativeCalls.godot_icall_0_15(MethodBind21, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCollideWithAreas, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCollideWithAreas(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind22, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsCollideWithAreasEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsCollideWithAreasEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind23, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCollideWithBodies, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCollideWithBodies(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind24, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsCollideWithBodiesEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsCollideWithBodiesEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind25, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetHitFromInside, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetHitFromInside(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind26, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsHitFromInsideEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsHitFromInsideEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind27, GodotObject.GetPtr(this)).ToBool();
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
    public new class PropertyName : Node2D.PropertyName
    {
        /// <summary>
        /// Cached name for the 'enabled' property.
        /// </summary>
        public static readonly StringName Enabled = "enabled";
        /// <summary>
        /// Cached name for the 'exclude_parent' property.
        /// </summary>
        public static readonly StringName ExcludeParent = "exclude_parent";
        /// <summary>
        /// Cached name for the 'target_position' property.
        /// </summary>
        public static readonly StringName TargetPosition = "target_position";
        /// <summary>
        /// Cached name for the 'collision_mask' property.
        /// </summary>
        public static readonly StringName CollisionMask = "collision_mask";
        /// <summary>
        /// Cached name for the 'hit_from_inside' property.
        /// </summary>
        public static readonly StringName HitFromInside = "hit_from_inside";
        /// <summary>
        /// Cached name for the 'collide_with_areas' property.
        /// </summary>
        public static readonly StringName CollideWithAreas = "collide_with_areas";
        /// <summary>
        /// Cached name for the 'collide_with_bodies' property.
        /// </summary>
        public static readonly StringName CollideWithBodies = "collide_with_bodies";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Node2D.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_enabled' method.
        /// </summary>
        public static readonly StringName SetEnabled = "set_enabled";
        /// <summary>
        /// Cached name for the 'is_enabled' method.
        /// </summary>
        public static readonly StringName IsEnabled = "is_enabled";
        /// <summary>
        /// Cached name for the 'set_target_position' method.
        /// </summary>
        public static readonly StringName SetTargetPosition = "set_target_position";
        /// <summary>
        /// Cached name for the 'get_target_position' method.
        /// </summary>
        public static readonly StringName GetTargetPosition = "get_target_position";
        /// <summary>
        /// Cached name for the 'is_colliding' method.
        /// </summary>
        public static readonly StringName IsColliding = "is_colliding";
        /// <summary>
        /// Cached name for the 'force_raycast_update' method.
        /// </summary>
        public static readonly StringName ForceRaycastUpdate = "force_raycast_update";
        /// <summary>
        /// Cached name for the 'get_collider' method.
        /// </summary>
        public static readonly StringName GetCollider = "get_collider";
        /// <summary>
        /// Cached name for the 'get_collider_rid' method.
        /// </summary>
        public static readonly StringName GetColliderRid = "get_collider_rid";
        /// <summary>
        /// Cached name for the 'get_collider_shape' method.
        /// </summary>
        public static readonly StringName GetColliderShape = "get_collider_shape";
        /// <summary>
        /// Cached name for the 'get_collision_point' method.
        /// </summary>
        public static readonly StringName GetCollisionPoint = "get_collision_point";
        /// <summary>
        /// Cached name for the 'get_collision_normal' method.
        /// </summary>
        public static readonly StringName GetCollisionNormal = "get_collision_normal";
        /// <summary>
        /// Cached name for the 'add_exception_rid' method.
        /// </summary>
        public static readonly StringName AddExceptionRid = "add_exception_rid";
        /// <summary>
        /// Cached name for the 'add_exception' method.
        /// </summary>
        public static readonly StringName AddException = "add_exception";
        /// <summary>
        /// Cached name for the 'remove_exception_rid' method.
        /// </summary>
        public static readonly StringName RemoveExceptionRid = "remove_exception_rid";
        /// <summary>
        /// Cached name for the 'remove_exception' method.
        /// </summary>
        public static readonly StringName RemoveException = "remove_exception";
        /// <summary>
        /// Cached name for the 'clear_exceptions' method.
        /// </summary>
        public static readonly StringName ClearExceptions = "clear_exceptions";
        /// <summary>
        /// Cached name for the 'set_collision_mask' method.
        /// </summary>
        public static readonly StringName SetCollisionMask = "set_collision_mask";
        /// <summary>
        /// Cached name for the 'get_collision_mask' method.
        /// </summary>
        public static readonly StringName GetCollisionMask = "get_collision_mask";
        /// <summary>
        /// Cached name for the 'set_collision_mask_value' method.
        /// </summary>
        public static readonly StringName SetCollisionMaskValue = "set_collision_mask_value";
        /// <summary>
        /// Cached name for the 'get_collision_mask_value' method.
        /// </summary>
        public static readonly StringName GetCollisionMaskValue = "get_collision_mask_value";
        /// <summary>
        /// Cached name for the 'set_exclude_parent_body' method.
        /// </summary>
        public static readonly StringName SetExcludeParentBody = "set_exclude_parent_body";
        /// <summary>
        /// Cached name for the 'get_exclude_parent_body' method.
        /// </summary>
        public static readonly StringName GetExcludeParentBody = "get_exclude_parent_body";
        /// <summary>
        /// Cached name for the 'set_collide_with_areas' method.
        /// </summary>
        public static readonly StringName SetCollideWithAreas = "set_collide_with_areas";
        /// <summary>
        /// Cached name for the 'is_collide_with_areas_enabled' method.
        /// </summary>
        public static readonly StringName IsCollideWithAreasEnabled = "is_collide_with_areas_enabled";
        /// <summary>
        /// Cached name for the 'set_collide_with_bodies' method.
        /// </summary>
        public static readonly StringName SetCollideWithBodies = "set_collide_with_bodies";
        /// <summary>
        /// Cached name for the 'is_collide_with_bodies_enabled' method.
        /// </summary>
        public static readonly StringName IsCollideWithBodiesEnabled = "is_collide_with_bodies_enabled";
        /// <summary>
        /// Cached name for the 'set_hit_from_inside' method.
        /// </summary>
        public static readonly StringName SetHitFromInside = "set_hit_from_inside";
        /// <summary>
        /// Cached name for the 'is_hit_from_inside_enabled' method.
        /// </summary>
        public static readonly StringName IsHitFromInsideEnabled = "is_hit_from_inside_enabled";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Node2D.SignalName
    {
    }
}
