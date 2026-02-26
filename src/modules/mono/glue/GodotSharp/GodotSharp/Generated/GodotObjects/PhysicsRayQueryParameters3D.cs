namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>By changing various properties of this object, such as the ray position, you can configure the parameters for <see cref="Godot.PhysicsDirectSpaceState3D.IntersectRay(PhysicsRayQueryParameters3D)"/>.</para>
/// </summary>
public partial class PhysicsRayQueryParameters3D : RefCounted
{
    /// <summary>
    /// <para>The starting point of the ray being queried for, in global coordinates.</para>
    /// </summary>
    public Vector3 From
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
    /// <para>The ending point of the ray being queried for, in global coordinates.</para>
    /// </summary>
    public Vector3 To
    {
        get
        {
            return GetTo();
        }
        set
        {
            SetTo(value);
        }
    }

    /// <summary>
    /// <para>The physics layers the query will detect (as a bitmask). By default, all collision layers are detected. See <a href="$DOCS_URL/tutorials/physics/physics_introduction.html#collision-layers-and-masks">Collision layers and masks</a> in the documentation for more information.</para>
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
    /// <para>The list of object <see cref="Godot.Rid"/>s that will be excluded from collisions. Use <see cref="Godot.CollisionObject3D.GetRid()"/> to get the <see cref="Godot.Rid"/> associated with a <see cref="Godot.CollisionObject3D"/>-derived node.</para>
    /// <para><b>Note:</b> The returned array is copied and any changes to it will not update the original property value. To update the value you need to modify the returned array, and then assign it to the property again.</para>
    /// </summary>
    public Godot.Collections.Array<Rid> Exclude
    {
        get
        {
            return GetExclude();
        }
        set
        {
            SetExclude(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the query will take <see cref="Godot.PhysicsBody3D"/>s into account.</para>
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

    /// <summary>
    /// <para>If <see langword="true"/>, the query will take <see cref="Godot.Area3D"/>s into account.</para>
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
    /// <para>If <see langword="true"/>, the query will detect a hit when starting inside shapes. In this case the collision normal will be <c>Vector3(0, 0, 0)</c>. Does not affect concave polygon shapes or heightmap shapes.</para>
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
    /// <para>If <see langword="true"/>, the query will hit back faces with concave polygon shapes with back face enabled or heightmap shapes.</para>
    /// </summary>
    public bool HitBackFaces
    {
        get
        {
            return IsHitBackFacesEnabled();
        }
        set
        {
            SetHitBackFaces(value);
        }
    }

    private static readonly System.Type CachedType = typeof(PhysicsRayQueryParameters3D);

    private static readonly StringName NativeName = "PhysicsRayQueryParameters3D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public PhysicsRayQueryParameters3D() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal PhysicsRayQueryParameters3D(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal PhysicsRayQueryParameters3D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Create, 3110599579ul);

    /// <summary>
    /// <para>Returns a new, pre-configured <see cref="Godot.PhysicsRayQueryParameters3D"/> object. Use it to quickly create query parameters using the most common options.</para>
    /// <para><code>
    /// var query = PhysicsRayQueryParameters3D.create(position, position + Vector3(0, -10, 0))
    /// var collision = get_world_3d().direct_space_state.intersect_ray(query)
    /// </code></para>
    /// </summary>
    public static unsafe PhysicsRayQueryParameters3D Create(Vector3 from, Vector3 to, uint collisionMask = (uint)(4294967295), Godot.Collections.Array<Rid> exclude = null)
    {
        return (PhysicsRayQueryParameters3D)NativeCalls.godot_icall_4_987(MethodBind0, &from, &to, collisionMask, (godot_array)(exclude ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFrom, 3460891852ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetFrom(Vector3 from)
    {
        NativeCalls.godot_icall_1_177(MethodBind1, GodotObject.GetPtr(this), &from);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFrom, 3360562783ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector3 GetFrom()
    {
        return NativeCalls.godot_icall_0_125(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTo, 3460891852ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetTo(Vector3 to)
    {
        NativeCalls.godot_icall_1_177(MethodBind3, GodotObject.GetPtr(this), &to);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTo, 3360562783ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector3 GetTo()
    {
        return NativeCalls.godot_icall_0_125(MethodBind4, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCollisionMask, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCollisionMask(uint collisionMask)
    {
        NativeCalls.godot_icall_1_208(MethodBind5, GodotObject.GetPtr(this), collisionMask);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCollisionMask, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public uint GetCollisionMask()
    {
        return NativeCalls.godot_icall_0_209(MethodBind6, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetExclude, 381264803ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetExclude(Godot.Collections.Array<Rid> exclude)
    {
        NativeCalls.godot_icall_1_138(MethodBind7, GodotObject.GetPtr(this), (godot_array)(exclude ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetExclude, 3995934104ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Godot.Collections.Array<Rid> GetExclude()
    {
        return new Godot.Collections.Array<Rid>(NativeCalls.godot_icall_0_120(MethodBind8, GodotObject.GetPtr(this)));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCollideWithBodies, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCollideWithBodies(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind9, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsCollideWithBodiesEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsCollideWithBodiesEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind10, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCollideWithAreas, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCollideWithAreas(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind11, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsCollideWithAreasEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsCollideWithAreasEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind12, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetHitFromInside, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetHitFromInside(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind13, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsHitFromInsideEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsHitFromInsideEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind14, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetHitBackFaces, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetHitBackFaces(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind15, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsHitBackFacesEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsHitBackFacesEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind16, GodotObject.GetPtr(this)).ToBool();
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
        /// Cached name for the 'to' property.
        /// </summary>
        public static readonly StringName To = "to";
        /// <summary>
        /// Cached name for the 'collision_mask' property.
        /// </summary>
        public static readonly StringName CollisionMask = "collision_mask";
        /// <summary>
        /// Cached name for the 'exclude' property.
        /// </summary>
        public static readonly StringName Exclude = "exclude";
        /// <summary>
        /// Cached name for the 'collide_with_bodies' property.
        /// </summary>
        public static readonly StringName CollideWithBodies = "collide_with_bodies";
        /// <summary>
        /// Cached name for the 'collide_with_areas' property.
        /// </summary>
        public static readonly StringName CollideWithAreas = "collide_with_areas";
        /// <summary>
        /// Cached name for the 'hit_from_inside' property.
        /// </summary>
        public static readonly StringName HitFromInside = "hit_from_inside";
        /// <summary>
        /// Cached name for the 'hit_back_faces' property.
        /// </summary>
        public static readonly StringName HitBackFaces = "hit_back_faces";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : RefCounted.MethodName
    {
        /// <summary>
        /// Cached name for the 'create' method.
        /// </summary>
        public static readonly StringName Create = "create";
        /// <summary>
        /// Cached name for the 'set_from' method.
        /// </summary>
        public static readonly StringName SetFrom = "set_from";
        /// <summary>
        /// Cached name for the 'get_from' method.
        /// </summary>
        public static readonly StringName GetFrom = "get_from";
        /// <summary>
        /// Cached name for the 'set_to' method.
        /// </summary>
        public static readonly StringName SetTo = "set_to";
        /// <summary>
        /// Cached name for the 'get_to' method.
        /// </summary>
        public static readonly StringName GetTo = "get_to";
        /// <summary>
        /// Cached name for the 'set_collision_mask' method.
        /// </summary>
        public static readonly StringName SetCollisionMask = "set_collision_mask";
        /// <summary>
        /// Cached name for the 'get_collision_mask' method.
        /// </summary>
        public static readonly StringName GetCollisionMask = "get_collision_mask";
        /// <summary>
        /// Cached name for the 'set_exclude' method.
        /// </summary>
        public static readonly StringName SetExclude = "set_exclude";
        /// <summary>
        /// Cached name for the 'get_exclude' method.
        /// </summary>
        public static readonly StringName GetExclude = "get_exclude";
        /// <summary>
        /// Cached name for the 'set_collide_with_bodies' method.
        /// </summary>
        public static readonly StringName SetCollideWithBodies = "set_collide_with_bodies";
        /// <summary>
        /// Cached name for the 'is_collide_with_bodies_enabled' method.
        /// </summary>
        public static readonly StringName IsCollideWithBodiesEnabled = "is_collide_with_bodies_enabled";
        /// <summary>
        /// Cached name for the 'set_collide_with_areas' method.
        /// </summary>
        public static readonly StringName SetCollideWithAreas = "set_collide_with_areas";
        /// <summary>
        /// Cached name for the 'is_collide_with_areas_enabled' method.
        /// </summary>
        public static readonly StringName IsCollideWithAreasEnabled = "is_collide_with_areas_enabled";
        /// <summary>
        /// Cached name for the 'set_hit_from_inside' method.
        /// </summary>
        public static readonly StringName SetHitFromInside = "set_hit_from_inside";
        /// <summary>
        /// Cached name for the 'is_hit_from_inside_enabled' method.
        /// </summary>
        public static readonly StringName IsHitFromInsideEnabled = "is_hit_from_inside_enabled";
        /// <summary>
        /// Cached name for the 'set_hit_back_faces' method.
        /// </summary>
        public static readonly StringName SetHitBackFaces = "set_hit_back_faces";
        /// <summary>
        /// Cached name for the 'is_hit_back_faces_enabled' method.
        /// </summary>
        public static readonly StringName IsHitBackFacesEnabled = "is_hit_back_faces_enabled";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : RefCounted.SignalName
    {
    }
}
