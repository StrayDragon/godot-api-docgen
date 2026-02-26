namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A 2D convex polygon shape, intended for use in physics. Used internally in <see cref="Godot.CollisionPolygon2D"/> when it's in <see cref="Godot.CollisionPolygon2D.BuildModeEnum.Solids"/> mode.</para>
/// <para><see cref="Godot.ConvexPolygonShape2D"/> is <i>solid</i>, which means it detects collisions from objects that are fully inside it, unlike <see cref="Godot.ConcavePolygonShape2D"/> which is hollow. This makes it more suitable for both detection and physics.</para>
/// <para><b>Convex decomposition:</b> A concave polygon can be split up into several convex polygons. This allows dynamic physics bodies to have complex concave collisions (at a performance cost) and can be achieved by using several <see cref="Godot.ConvexPolygonShape2D"/> nodes or by using the <see cref="Godot.CollisionPolygon2D"/> node in <see cref="Godot.CollisionPolygon2D.BuildModeEnum.Solids"/> mode. To generate a collision polygon from a sprite, select the <see cref="Godot.Sprite2D"/> node, go to the <b>Sprite2D</b> menu that appears above the viewport, and choose <b>Create Polygon2D Sibling</b>.</para>
/// <para><b>Performance:</b> <see cref="Godot.ConvexPolygonShape2D"/> is faster to check collisions against compared to <see cref="Godot.ConcavePolygonShape2D"/>, but it is slower than primitive collision shapes such as <see cref="Godot.CircleShape2D"/> and <see cref="Godot.RectangleShape2D"/>. Its use should generally be limited to medium-sized objects that cannot have their collision accurately represented by primitive shapes.</para>
/// </summary>
public partial class ConvexPolygonShape2D : Shape2D
{
    /// <summary>
    /// <para>The polygon's list of vertices that form a convex hull. Can be in either clockwise or counterclockwise order.</para>
    /// <para><b>Warning:</b> Only set this property to a list of points that actually form a convex hull. Use <see cref="Godot.ConvexPolygonShape2D.SetPointCloud(Vector2[])"/> to generate the convex hull of an arbitrary set of points.</para>
    /// </summary>
    public Vector2[] Points
    {
        get
        {
            return GetPoints();
        }
        set
        {
            SetPoints(value);
        }
    }

    private static readonly System.Type CachedType = typeof(ConvexPolygonShape2D);

    private static readonly StringName NativeName = "ConvexPolygonShape2D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public ConvexPolygonShape2D() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal ConvexPolygonShape2D(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal ConvexPolygonShape2D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPointCloud, 1509147220ul);

    /// <summary>
    /// <para>Based on the set of points provided, this assigns the <see cref="Godot.ConvexPolygonShape2D.Points"/> property using the convex hull algorithm, removing all unneeded points. See <see cref="Godot.Geometry2D.ConvexHull(Vector2[])"/> for details.</para>
    /// </summary>
    public void SetPointCloud(Vector2[] pointCloud)
    {
        NativeCalls.godot_icall_1_224(MethodBind0, GodotObject.GetPtr(this), pointCloud);
    }

    /// <summary>
    /// <para>Based on the set of points provided, this assigns the <see cref="Godot.ConvexPolygonShape2D.Points"/> property using the convex hull algorithm, removing all unneeded points. See <see cref="Godot.Geometry2D.ConvexHull(Vector2[])"/> for details.</para>
    /// </summary>
    public void SetPointCloud(ReadOnlySpan<Vector2> pointCloud)
    {
        NativeCalls.godot_icall_1_224(MethodBind0, GodotObject.GetPtr(this), pointCloud);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPoints, 1509147220ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPoints(Vector2[] points)
    {
        NativeCalls.godot_icall_1_224(MethodBind1, GodotObject.GetPtr(this), points);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPoints(ReadOnlySpan<Vector2> points)
    {
        NativeCalls.godot_icall_1_224(MethodBind1, GodotObject.GetPtr(this), points);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPoints, 2961356807ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2[] GetPoints()
    {
        return NativeCalls.godot_icall_0_225(MethodBind2, GodotObject.GetPtr(this));
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
    public new class PropertyName : Shape2D.PropertyName
    {
        /// <summary>
        /// Cached name for the 'points' property.
        /// </summary>
        public static readonly StringName Points = "points";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Shape2D.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_point_cloud' method.
        /// </summary>
        public static readonly StringName SetPointCloud = "set_point_cloud";
        /// <summary>
        /// Cached name for the 'set_points' method.
        /// </summary>
        public static readonly StringName SetPoints = "set_points";
        /// <summary>
        /// Cached name for the 'get_points' method.
        /// </summary>
        public static readonly StringName GetPoints = "get_points";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Shape2D.SignalName
    {
    }
}
