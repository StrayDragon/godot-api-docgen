namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A node that provides a polygon shape to a <see cref="Godot.CollisionObject2D"/> parent and allows it to be edited. The polygon can be concave or convex. This can give a detection shape to an <see cref="Godot.Area2D"/>, turn a <see cref="Godot.PhysicsBody2D"/> into a solid object, or give a hollow shape to a <see cref="Godot.StaticBody2D"/>.</para>
/// <para><b>Warning:</b> A non-uniformly scaled <see cref="Godot.CollisionPolygon2D"/> will likely not behave as expected. Make sure to keep its scale the same on all axes and adjust its polygon instead.</para>
/// </summary>
public partial class CollisionPolygon2D : Node2D
{
    public enum BuildModeEnum : long
    {
        /// <summary>
        /// <para>Collisions will include the polygon and its contained area. In this mode the node has the same effect as several <see cref="Godot.ConvexPolygonShape2D"/> nodes, one for each convex shape in the convex decomposition of the polygon (but without the overhead of multiple nodes).</para>
        /// </summary>
        Solids = 0,
        /// <summary>
        /// <para>Collisions will only include the polygon edges. In this mode the node has the same effect as a single <see cref="Godot.ConcavePolygonShape2D"/> made of segments, with the restriction that each segment (after the first one) starts where the previous one ends, and the last one ends where the first one starts (forming a closed but hollow polygon).</para>
        /// </summary>
        Segments = 1
    }

    /// <summary>
    /// <para>Collision build mode.</para>
    /// </summary>
    public CollisionPolygon2D.BuildModeEnum BuildMode
    {
        get
        {
            return GetBuildMode();
        }
        set
        {
            SetBuildMode(value);
        }
    }

    /// <summary>
    /// <para>The polygon's list of vertices. Each point will be connected to the next, and the final point will be connected to the first.</para>
    /// <para><b>Note:</b> The returned vertices are in the local coordinate space of the given <see cref="Godot.CollisionPolygon2D"/>.</para>
    /// </summary>
    public Vector2[] Polygon
    {
        get
        {
            return GetPolygon();
        }
        set
        {
            SetPolygon(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, no collisions will be detected. This property should be changed with <see cref="Godot.GodotObject.SetDeferred(StringName, Variant)"/>.</para>
    /// </summary>
    public bool Disabled
    {
        get
        {
            return IsDisabled();
        }
        set
        {
            SetDisabled(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, only edges that face up, relative to <see cref="Godot.CollisionPolygon2D"/>'s rotation, will collide with other objects.</para>
    /// <para><b>Note:</b> This property has no effect if this <see cref="Godot.CollisionPolygon2D"/> is a child of an <see cref="Godot.Area2D"/> node.</para>
    /// </summary>
    public bool OneWayCollision
    {
        get
        {
            return IsOneWayCollisionEnabled();
        }
        set
        {
            SetOneWayCollision(value);
        }
    }

    /// <summary>
    /// <para>The margin used for one-way collision (in pixels). Higher values will make the shape thicker, and work better for colliders that enter the polygon at a high velocity.</para>
    /// </summary>
    public float OneWayCollisionMargin
    {
        get
        {
            return GetOneWayCollisionMargin();
        }
        set
        {
            SetOneWayCollisionMargin(value);
        }
    }

    private static readonly System.Type CachedType = typeof(CollisionPolygon2D);

    private static readonly StringName NativeName = "CollisionPolygon2D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public CollisionPolygon2D() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal CollisionPolygon2D(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal CollisionPolygon2D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPolygon, 1509147220ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPolygon(Vector2[] polygon)
    {
        NativeCalls.godot_icall_1_224(MethodBind0, GodotObject.GetPtr(this), polygon);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPolygon(ReadOnlySpan<Vector2> polygon)
    {
        NativeCalls.godot_icall_1_224(MethodBind0, GodotObject.GetPtr(this), polygon);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPolygon, 2961356807ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2[] GetPolygon()
    {
        return NativeCalls.godot_icall_0_225(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBuildMode, 2780803135ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetBuildMode(CollisionPolygon2D.BuildModeEnum buildMode)
    {
        NativeCalls.godot_icall_1_38(MethodBind2, GodotObject.GetPtr(this), (int)buildMode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBuildMode, 3044948800ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public CollisionPolygon2D.BuildModeEnum GetBuildMode()
    {
        return (CollisionPolygon2D.BuildModeEnum)NativeCalls.godot_icall_0_39(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDisabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDisabled(bool disabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind4, GodotObject.GetPtr(this), disabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsDisabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsDisabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind5, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetOneWayCollision, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetOneWayCollision(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind6, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsOneWayCollisionEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsOneWayCollisionEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind7, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetOneWayCollisionMargin, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetOneWayCollisionMargin(float margin)
    {
        NativeCalls.godot_icall_1_67(MethodBind8, GodotObject.GetPtr(this), margin);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOneWayCollisionMargin, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetOneWayCollisionMargin()
    {
        return NativeCalls.godot_icall_0_68(MethodBind9, GodotObject.GetPtr(this));
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
        /// Cached name for the 'build_mode' property.
        /// </summary>
        public static readonly StringName BuildMode = "build_mode";
        /// <summary>
        /// Cached name for the 'polygon' property.
        /// </summary>
        public static readonly StringName Polygon = "polygon";
        /// <summary>
        /// Cached name for the 'disabled' property.
        /// </summary>
        public static readonly StringName Disabled = "disabled";
        /// <summary>
        /// Cached name for the 'one_way_collision' property.
        /// </summary>
        public static readonly StringName OneWayCollision = "one_way_collision";
        /// <summary>
        /// Cached name for the 'one_way_collision_margin' property.
        /// </summary>
        public static readonly StringName OneWayCollisionMargin = "one_way_collision_margin";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Node2D.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_polygon' method.
        /// </summary>
        public static readonly StringName SetPolygon = "set_polygon";
        /// <summary>
        /// Cached name for the 'get_polygon' method.
        /// </summary>
        public static readonly StringName GetPolygon = "get_polygon";
        /// <summary>
        /// Cached name for the 'set_build_mode' method.
        /// </summary>
        public static readonly StringName SetBuildMode = "set_build_mode";
        /// <summary>
        /// Cached name for the 'get_build_mode' method.
        /// </summary>
        public static readonly StringName GetBuildMode = "get_build_mode";
        /// <summary>
        /// Cached name for the 'set_disabled' method.
        /// </summary>
        public static readonly StringName SetDisabled = "set_disabled";
        /// <summary>
        /// Cached name for the 'is_disabled' method.
        /// </summary>
        public static readonly StringName IsDisabled = "is_disabled";
        /// <summary>
        /// Cached name for the 'set_one_way_collision' method.
        /// </summary>
        public static readonly StringName SetOneWayCollision = "set_one_way_collision";
        /// <summary>
        /// Cached name for the 'is_one_way_collision_enabled' method.
        /// </summary>
        public static readonly StringName IsOneWayCollisionEnabled = "is_one_way_collision_enabled";
        /// <summary>
        /// Cached name for the 'set_one_way_collision_margin' method.
        /// </summary>
        public static readonly StringName SetOneWayCollisionMargin = "set_one_way_collision_margin";
        /// <summary>
        /// Cached name for the 'get_one_way_collision_margin' method.
        /// </summary>
        public static readonly StringName GetOneWayCollisionMargin = "get_one_way_collision_margin";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Node2D.SignalName
    {
    }
}
