namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>By changing various properties of this object, such as the point position, you can configure the parameters for <see cref="Godot.PhysicsDirectSpaceState2D.IntersectPoint(PhysicsPointQueryParameters2D, int)"/>.</para>
/// </summary>
public partial class PhysicsPointQueryParameters2D : RefCounted
{
    /// <summary>
    /// <para>The position being queried for, in global coordinates.</para>
    /// </summary>
    public Vector2 Position
    {
        get
        {
            return GetPosition();
        }
        set
        {
            SetPosition(value);
        }
    }

    /// <summary>
    /// <para>If different from <c>0</c>, restricts the query to a specific canvas layer specified by its instance ID. See <see cref="Godot.GodotObject.GetInstanceId()"/>.</para>
    /// <para>If <c>0</c>, restricts the query to the Viewport's default canvas layer.</para>
    /// </summary>
    public ulong CanvasInstanceId
    {
        get
        {
            return GetCanvasInstanceId();
        }
        set
        {
            SetCanvasInstanceId(value);
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
    /// <para>The list of object <see cref="Godot.Rid"/>s that will be excluded from collisions. Use <see cref="Godot.CollisionObject2D.GetRid()"/> to get the <see cref="Godot.Rid"/> associated with a <see cref="Godot.CollisionObject2D"/>-derived node.</para>
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
    /// <para>If <see langword="true"/>, the query will take <see cref="Godot.PhysicsBody2D"/>s into account.</para>
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
    /// <para>If <see langword="true"/>, the query will take <see cref="Godot.Area2D"/>s into account.</para>
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

    private static readonly System.Type CachedType = typeof(PhysicsPointQueryParameters2D);

    private static readonly StringName NativeName = "PhysicsPointQueryParameters2D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public PhysicsPointQueryParameters2D() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal PhysicsPointQueryParameters2D(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal PhysicsPointQueryParameters2D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPosition, 743155724ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetPosition(Vector2 position)
    {
        NativeCalls.godot_icall_1_36(MethodBind0, GodotObject.GetPtr(this), &position);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPosition, 3341600327ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2 GetPosition()
    {
        return NativeCalls.godot_icall_0_37(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCanvasInstanceId, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCanvasInstanceId(ulong canvasInstanceId)
    {
        NativeCalls.godot_icall_1_544(MethodBind2, GodotObject.GetPtr(this), canvasInstanceId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCanvasInstanceId, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public ulong GetCanvasInstanceId()
    {
        return NativeCalls.godot_icall_0_137(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCollisionMask, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCollisionMask(uint collisionMask)
    {
        NativeCalls.godot_icall_1_208(MethodBind4, GodotObject.GetPtr(this), collisionMask);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCollisionMask, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public uint GetCollisionMask()
    {
        return NativeCalls.godot_icall_0_209(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetExclude, 381264803ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetExclude(Godot.Collections.Array<Rid> exclude)
    {
        NativeCalls.godot_icall_1_138(MethodBind6, GodotObject.GetPtr(this), (godot_array)(exclude ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetExclude, 3995934104ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Godot.Collections.Array<Rid> GetExclude()
    {
        return new Godot.Collections.Array<Rid>(NativeCalls.godot_icall_0_120(MethodBind7, GodotObject.GetPtr(this)));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCollideWithBodies, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCollideWithBodies(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind8, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsCollideWithBodiesEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsCollideWithBodiesEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind9, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCollideWithAreas, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCollideWithAreas(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind10, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsCollideWithAreasEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsCollideWithAreasEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind11, GodotObject.GetPtr(this)).ToBool();
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
        /// Cached name for the 'position' property.
        /// </summary>
        public static readonly StringName Position = "position";
        /// <summary>
        /// Cached name for the 'canvas_instance_id' property.
        /// </summary>
        public static readonly StringName CanvasInstanceId = "canvas_instance_id";
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
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : RefCounted.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_position' method.
        /// </summary>
        public static readonly StringName SetPosition = "set_position";
        /// <summary>
        /// Cached name for the 'get_position' method.
        /// </summary>
        public static readonly StringName GetPosition = "get_position";
        /// <summary>
        /// Cached name for the 'set_canvas_instance_id' method.
        /// </summary>
        public static readonly StringName SetCanvasInstanceId = "set_canvas_instance_id";
        /// <summary>
        /// Cached name for the 'get_canvas_instance_id' method.
        /// </summary>
        public static readonly StringName GetCanvasInstanceId = "get_canvas_instance_id";
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
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : RefCounted.SignalName
    {
    }
}
