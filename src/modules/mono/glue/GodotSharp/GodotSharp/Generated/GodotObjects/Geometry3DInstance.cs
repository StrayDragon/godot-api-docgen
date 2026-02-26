namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Provides a set of helper functions to create geometric shapes, compute intersections between shapes, and process various other geometric operations in 3D.</para>
/// </summary>
[GodotClassName("Geometry3D")]
public partial class Geometry3DInstance : GodotObject
{
    private static readonly System.Type CachedType = typeof(Geometry3DInstance);

    private static readonly StringName NativeName = "Geometry3D";

    internal Geometry3DInstance() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal Geometry3DInstance(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal Geometry3DInstance(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ComputeConvexMeshPoints, 1936902142ul);

    /// <summary>
    /// <para>Calculates and returns all the vertex points of a convex shape defined by an array of <paramref name="planes"/>.</para>
    /// </summary>
    public Vector3[] ComputeConvexMeshPoints(Godot.Collections.Array<Plane> planes)
    {
        return NativeCalls.godot_icall_1_673(MethodBind0, GodotObject.GetPtr(this), (godot_array)(planes ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BuildBoxPlanes, 3622277145ul);

    /// <summary>
    /// <para>Returns an array with 6 <see cref="Godot.Plane"/>s that describe the sides of a box centered at the origin. The box size is defined by <paramref name="extents"/>, which represents one (positive) corner of the box (i.e. half its actual size).</para>
    /// </summary>
    public unsafe Godot.Collections.Array<Plane> BuildBoxPlanes(Vector3 extents)
    {
        return new Godot.Collections.Array<Plane>(NativeCalls.godot_icall_1_674(MethodBind1, GodotObject.GetPtr(this), &extents));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BuildCylinderPlanes, 449920067ul);

    /// <summary>
    /// <para>Returns an array of <see cref="Godot.Plane"/>s closely bounding a faceted cylinder centered at the origin with radius <paramref name="radius"/> and height <paramref name="height"/>. The parameter <paramref name="sides"/> defines how many planes will be generated for the round part of the cylinder. The parameter <paramref name="axis"/> describes the axis along which the cylinder is oriented (0 for X, 1 for Y, 2 for Z).</para>
    /// </summary>
    public Godot.Collections.Array<Plane> BuildCylinderPlanes(float radius, float height, int sides, Vector3.Axis axis = (Vector3.Axis)(2))
    {
        return new Godot.Collections.Array<Plane>(NativeCalls.godot_icall_4_675(MethodBind2, GodotObject.GetPtr(this), radius, height, sides, (int)axis));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BuildCapsulePlanes, 2113592876ul);

    /// <summary>
    /// <para>Returns an array of <see cref="Godot.Plane"/>s closely bounding a faceted capsule centered at the origin with radius <paramref name="radius"/> and height <paramref name="height"/>. The parameter <paramref name="sides"/> defines how many planes will be generated for the side part of the capsule, whereas <paramref name="lats"/> gives the number of latitudinal steps at the bottom and top of the capsule. The parameter <paramref name="axis"/> describes the axis along which the capsule is oriented (0 for X, 1 for Y, 2 for Z).</para>
    /// </summary>
    public Godot.Collections.Array<Plane> BuildCapsulePlanes(float radius, float height, int sides, int lats, Vector3.Axis axis = (Vector3.Axis)(2))
    {
        return new Godot.Collections.Array<Plane>(NativeCalls.godot_icall_5_676(MethodBind3, GodotObject.GetPtr(this), radius, height, sides, lats, (int)axis));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetClosestPointsBetweenSegments, 1056373962ul);

    /// <summary>
    /// <para>Given the two 3D segments (<paramref name="p1"/>, <paramref name="p2"/>) and (<paramref name="q1"/>, <paramref name="q2"/>), finds those two points on the two segments that are closest to each other. Returns a <see cref="Godot.Vector3"/>[] that contains this point on (<paramref name="p1"/>, <paramref name="p2"/>) as well the accompanying point on (<paramref name="q1"/>, <paramref name="q2"/>).</para>
    /// </summary>
    public unsafe Vector3[] GetClosestPointsBetweenSegments(Vector3 p1, Vector3 p2, Vector3 q1, Vector3 q2)
    {
        return NativeCalls.godot_icall_4_677(MethodBind4, GodotObject.GetPtr(this), &p1, &p2, &q1, &q2);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetClosestPointToSegment, 2168193209ul);

    /// <summary>
    /// <para>Returns the 3D point on the 3D segment (<paramref name="s1"/>, <paramref name="s2"/>) that is closest to <paramref name="point"/>. The returned point will always be inside the specified segment.</para>
    /// </summary>
    public unsafe Vector3 GetClosestPointToSegment(Vector3 point, Vector3 s1, Vector3 s2)
    {
        return NativeCalls.godot_icall_3_678(MethodBind5, GodotObject.GetPtr(this), &point, &s1, &s2);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetClosestPointToSegmentUncapped, 2168193209ul);

    /// <summary>
    /// <para>Returns the 3D point on the 3D line defined by (<paramref name="s1"/>, <paramref name="s2"/>) that is closest to <paramref name="point"/>. The returned point can be inside the segment (<paramref name="s1"/>, <paramref name="s2"/>) or outside of it, i.e. somewhere on the line extending from the segment.</para>
    /// </summary>
    public unsafe Vector3 GetClosestPointToSegmentUncapped(Vector3 point, Vector3 s1, Vector3 s2)
    {
        return NativeCalls.godot_icall_3_678(MethodBind6, GodotObject.GetPtr(this), &point, &s1, &s2);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTriangleBarycentricCoords, 1362048029ul);

    /// <summary>
    /// <para>Returns a <see cref="Godot.Vector3"/> containing weights based on how close a 3D position (<paramref name="point"/>) is to a triangle's different vertices (<paramref name="a"/>, <paramref name="b"/> and <paramref name="c"/>). This is useful for interpolating between the data of different vertices in a triangle. One example use case is using this to smoothly rotate over a mesh instead of relying solely on face normals.</para>
    /// <para><a href="https://en.wikipedia.org/wiki/Barycentric_coordinate_system">Here is a more detailed explanation of barycentric coordinates.</a></para>
    /// </summary>
    public unsafe Vector3 GetTriangleBarycentricCoords(Vector3 point, Vector3 a, Vector3 b, Vector3 c)
    {
        return NativeCalls.godot_icall_4_679(MethodBind7, GodotObject.GetPtr(this), &point, &a, &b, &c);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RayIntersectsTriangle, 1718655448ul);

    /// <summary>
    /// <para>Tests if the 3D ray starting at <paramref name="from"/> with the direction of <paramref name="dir"/> intersects the triangle specified by <paramref name="a"/>, <paramref name="b"/> and <paramref name="c"/>. If yes, returns the point of intersection as <see cref="Godot.Vector3"/>. If no intersection takes place, returns <see langword="null"/>.</para>
    /// </summary>
    public unsafe Variant RayIntersectsTriangle(Vector3 from, Vector3 dir, Vector3 a, Vector3 b, Vector3 c)
    {
        return NativeCalls.godot_icall_5_680(MethodBind8, GodotObject.GetPtr(this), &from, &dir, &a, &b, &c);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SegmentIntersectsTriangle, 1718655448ul);

    /// <summary>
    /// <para>Tests if the segment (<paramref name="from"/>, <paramref name="to"/>) intersects the triangle <paramref name="a"/>, <paramref name="b"/>, <paramref name="c"/>. If yes, returns the point of intersection as <see cref="Godot.Vector3"/>. If no intersection takes place, returns <see langword="null"/>.</para>
    /// </summary>
    public unsafe Variant SegmentIntersectsTriangle(Vector3 from, Vector3 to, Vector3 a, Vector3 b, Vector3 c)
    {
        return NativeCalls.godot_icall_5_680(MethodBind9, GodotObject.GetPtr(this), &from, &to, &a, &b, &c);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SegmentIntersectsSphere, 4080141172ul);

    /// <summary>
    /// <para>Checks if the segment (<paramref name="from"/>, <paramref name="to"/>) intersects the sphere that is located at <paramref name="spherePosition"/> and has radius <paramref name="sphereRadius"/>. If no, returns an empty <see cref="Godot.Vector3"/>[]. If yes, returns a <see cref="Godot.Vector3"/>[] containing the point of intersection and the sphere's normal at the point of intersection.</para>
    /// </summary>
    public unsafe Vector3[] SegmentIntersectsSphere(Vector3 from, Vector3 to, Vector3 spherePosition, float sphereRadius)
    {
        return NativeCalls.godot_icall_4_681(MethodBind10, GodotObject.GetPtr(this), &from, &to, &spherePosition, sphereRadius);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SegmentIntersectsCylinder, 2361316491ul);

    /// <summary>
    /// <para>Checks if the segment (<paramref name="from"/>, <paramref name="to"/>) intersects the cylinder with height <paramref name="height"/> that is centered at the origin and has radius <paramref name="radius"/>. If no, returns an empty <see cref="Godot.Vector3"/>[]. If an intersection takes place, the returned array contains the point of intersection and the cylinder's normal at the point of intersection.</para>
    /// </summary>
    public unsafe Vector3[] SegmentIntersectsCylinder(Vector3 from, Vector3 to, float height, float radius)
    {
        return NativeCalls.godot_icall_4_682(MethodBind11, GodotObject.GetPtr(this), &from, &to, height, radius);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SegmentIntersectsConvex, 537425332ul);

    /// <summary>
    /// <para>Given a convex hull defined though the <see cref="Godot.Plane"/>s in the array <paramref name="planes"/>, tests if the segment (<paramref name="from"/>, <paramref name="to"/>) intersects with that hull. If an intersection is found, returns a <see cref="Godot.Vector3"/>[] containing the point the intersection and the hull's normal. Otherwise, returns an empty array.</para>
    /// </summary>
    public unsafe Vector3[] SegmentIntersectsConvex(Vector3 from, Vector3 to, Godot.Collections.Array<Plane> planes)
    {
        return NativeCalls.godot_icall_3_683(MethodBind12, GodotObject.GetPtr(this), &from, &to, (godot_array)(planes ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ClipPolygon, 2603188319ul);

    /// <summary>
    /// <para>Clips the polygon defined by the points in <paramref name="points"/> against the <paramref name="plane"/> and returns the points of the clipped polygon.</para>
    /// </summary>
    public unsafe Vector3[] ClipPolygon(Vector3[] points, Plane plane)
    {
        return NativeCalls.godot_icall_2_684(MethodBind13, GodotObject.GetPtr(this), points, &plane);
    }

    /// <summary>
    /// <para>Clips the polygon defined by the points in <paramref name="points"/> against the <paramref name="plane"/> and returns the points of the clipped polygon.</para>
    /// </summary>
    public unsafe Vector3[] ClipPolygon(ReadOnlySpan<Vector3> points, Plane plane)
    {
        return NativeCalls.godot_icall_2_684(MethodBind13, GodotObject.GetPtr(this), points, &plane);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.TetrahedralizeDelaunay, 1230191221ul);

    /// <summary>
    /// <para>Tetrahedralizes the volume specified by a discrete set of <paramref name="points"/> in 3D space, ensuring that no point lies within the circumsphere of any resulting tetrahedron. The method returns a <see cref="int"/>[] where each tetrahedron consists of four consecutive point indices into the <paramref name="points"/> array (resulting in an array with <c>n * 4</c> elements, where <c>n</c> is the number of tetrahedra found). If the tetrahedralization is unsuccessful, an empty <see cref="int"/>[] is returned.</para>
    /// </summary>
    public int[] TetrahedralizeDelaunay(Vector3[] points)
    {
        return NativeCalls.godot_icall_1_685(MethodBind14, GodotObject.GetPtr(this), points);
    }

    /// <summary>
    /// <para>Tetrahedralizes the volume specified by a discrete set of <paramref name="points"/> in 3D space, ensuring that no point lies within the circumsphere of any resulting tetrahedron. The method returns a <see cref="int"/>[] where each tetrahedron consists of four consecutive point indices into the <paramref name="points"/> array (resulting in an array with <c>n * 4</c> elements, where <c>n</c> is the number of tetrahedra found). If the tetrahedralization is unsuccessful, an empty <see cref="int"/>[] is returned.</para>
    /// </summary>
    public int[] TetrahedralizeDelaunay(ReadOnlySpan<Vector3> points)
    {
        return NativeCalls.godot_icall_1_685(MethodBind14, GodotObject.GetPtr(this), points);
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
    public new class PropertyName : GodotObject.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : GodotObject.MethodName
    {
        /// <summary>
        /// Cached name for the 'compute_convex_mesh_points' method.
        /// </summary>
        public static readonly StringName ComputeConvexMeshPoints = "compute_convex_mesh_points";
        /// <summary>
        /// Cached name for the 'build_box_planes' method.
        /// </summary>
        public static readonly StringName BuildBoxPlanes = "build_box_planes";
        /// <summary>
        /// Cached name for the 'build_cylinder_planes' method.
        /// </summary>
        public static readonly StringName BuildCylinderPlanes = "build_cylinder_planes";
        /// <summary>
        /// Cached name for the 'build_capsule_planes' method.
        /// </summary>
        public static readonly StringName BuildCapsulePlanes = "build_capsule_planes";
        /// <summary>
        /// Cached name for the 'get_closest_points_between_segments' method.
        /// </summary>
        public static readonly StringName GetClosestPointsBetweenSegments = "get_closest_points_between_segments";
        /// <summary>
        /// Cached name for the 'get_closest_point_to_segment' method.
        /// </summary>
        public static readonly StringName GetClosestPointToSegment = "get_closest_point_to_segment";
        /// <summary>
        /// Cached name for the 'get_closest_point_to_segment_uncapped' method.
        /// </summary>
        public static readonly StringName GetClosestPointToSegmentUncapped = "get_closest_point_to_segment_uncapped";
        /// <summary>
        /// Cached name for the 'get_triangle_barycentric_coords' method.
        /// </summary>
        public static readonly StringName GetTriangleBarycentricCoords = "get_triangle_barycentric_coords";
        /// <summary>
        /// Cached name for the 'ray_intersects_triangle' method.
        /// </summary>
        public static readonly StringName RayIntersectsTriangle = "ray_intersects_triangle";
        /// <summary>
        /// Cached name for the 'segment_intersects_triangle' method.
        /// </summary>
        public static readonly StringName SegmentIntersectsTriangle = "segment_intersects_triangle";
        /// <summary>
        /// Cached name for the 'segment_intersects_sphere' method.
        /// </summary>
        public static readonly StringName SegmentIntersectsSphere = "segment_intersects_sphere";
        /// <summary>
        /// Cached name for the 'segment_intersects_cylinder' method.
        /// </summary>
        public static readonly StringName SegmentIntersectsCylinder = "segment_intersects_cylinder";
        /// <summary>
        /// Cached name for the 'segment_intersects_convex' method.
        /// </summary>
        public static readonly StringName SegmentIntersectsConvex = "segment_intersects_convex";
        /// <summary>
        /// Cached name for the 'clip_polygon' method.
        /// </summary>
        public static readonly StringName ClipPolygon = "clip_polygon";
        /// <summary>
        /// Cached name for the 'tetrahedralize_delaunay' method.
        /// </summary>
        public static readonly StringName TetrahedralizeDelaunay = "tetrahedralize_delaunay";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : GodotObject.SignalName
    {
    }
}
