namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Provides a set of helper functions to create geometric shapes, compute intersections between shapes, and process various other geometric operations in 2D.</para>
/// </summary>
public static partial class Geometry2D
{
    public enum PolyBooleanOperation : long
    {
        /// <summary>
        /// <para>Create regions where either subject or clip polygons (or both) are filled.</para>
        /// </summary>
        Union = 0,
        /// <summary>
        /// <para>Create regions where subject polygons are filled except where clip polygons are filled.</para>
        /// </summary>
        Difference = 1,
        /// <summary>
        /// <para>Create regions where both subject and clip polygons are filled.</para>
        /// </summary>
        Intersection = 2,
        /// <summary>
        /// <para>Create regions where either subject or clip polygons are filled but not where both are filled.</para>
        /// </summary>
        Xor = 3
    }

    public enum PolyJoinType : long
    {
        /// <summary>
        /// <para>Squaring is applied uniformally at all convex edge joins at <c>1 * delta</c>.</para>
        /// </summary>
        Square = 0,
        /// <summary>
        /// <para>While flattened paths can never perfectly trace an arc, they are approximated by a series of arc chords.</para>
        /// </summary>
        Round = 1,
        /// <summary>
        /// <para>There's a necessary limit to mitered joins since offsetting edges that join at very acute angles will produce excessively long and narrow "spikes". For any given edge join, when miter offsetting would exceed that maximum distance, "square" joining is applied.</para>
        /// </summary>
        Miter = 2
    }

    public enum PolyEndType : long
    {
        /// <summary>
        /// <para>Endpoints are joined using the <see cref="Godot.Geometry2D.PolyJoinType"/> value and the path filled as a polygon.</para>
        /// </summary>
        Polygon = 0,
        /// <summary>
        /// <para>Endpoints are joined using the <see cref="Godot.Geometry2D.PolyJoinType"/> value and the path filled as a polyline.</para>
        /// </summary>
        Joined = 1,
        /// <summary>
        /// <para>Endpoints are squared off with no extension.</para>
        /// </summary>
        Butt = 2,
        /// <summary>
        /// <para>Endpoints are squared off and extended by <c>delta</c> units.</para>
        /// </summary>
        Square = 3,
        /// <summary>
        /// <para>Endpoints are rounded off and extended by <c>delta</c> units.</para>
        /// </summary>
        Round = 4
    }

    private static readonly StringName NativeName = "Geometry2D";

    private static Geometry2DInstance singleton;

    public static Geometry2DInstance Singleton =>
        singleton ??= (Geometry2DInstance)InteropUtils.EngineGetSingleton("Geometry2D");

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.IsPointInCircle, 2929491703ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if <paramref name="point"/> is inside the circle or if it's located exactly <i>on</i> the circle's boundary, otherwise returns <see langword="false"/>.</para>
    /// </summary>
    public static unsafe bool IsPointInCircle(Vector2 point, Vector2 circlePosition, float circleRadius)
    {
        return NativeCalls.godot_icall_3_659(MethodBind0, GodotObject.GetPtr(Singleton), &point, &circlePosition, circleRadius).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SegmentIntersectsCircle, 1356928167ul);

    /// <summary>
    /// <para>Given the 2D segment (<paramref name="segmentFrom"/>, <paramref name="segmentTo"/>), returns the position on the segment (as a number between 0 and 1) at which the segment hits the circle that is located at position <paramref name="circlePosition"/> and has radius <paramref name="circleRadius"/>. If the segment does not intersect the circle, -1 is returned (this is also the case if the line extending the segment would intersect the circle, but the segment does not).</para>
    /// </summary>
    public static unsafe float SegmentIntersectsCircle(Vector2 segmentFrom, Vector2 segmentTo, Vector2 circlePosition, float circleRadius)
    {
        return NativeCalls.godot_icall_4_660(MethodBind1, GodotObject.GetPtr(Singleton), &segmentFrom, &segmentTo, &circlePosition, circleRadius);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SegmentIntersectsSegment, 2058025344ul);

    /// <summary>
    /// <para>Checks if the two segments (<paramref name="fromA"/>, <paramref name="toA"/>) and (<paramref name="fromB"/>, <paramref name="toB"/>) intersect. If yes, return the point of intersection as <see cref="Godot.Vector2"/>. If no intersection takes place, returns <see langword="null"/>.</para>
    /// </summary>
    public static unsafe Variant SegmentIntersectsSegment(Vector2 fromA, Vector2 toA, Vector2 fromB, Vector2 toB)
    {
        return NativeCalls.godot_icall_4_661(MethodBind2, GodotObject.GetPtr(Singleton), &fromA, &toA, &fromB, &toB);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.LineIntersectsLine, 2058025344ul);

    /// <summary>
    /// <para>Returns the point of intersection between the two lines (<paramref name="fromA"/>, <paramref name="dirA"/>) and (<paramref name="fromB"/>, <paramref name="dirB"/>). Returns a <see cref="Godot.Vector2"/>, or <see langword="null"/> if the lines are parallel.</para>
    /// <para><c>from</c> and <c>dir</c> are <i>not</i> endpoints of a line segment or ray but the slope (<c>dir</c>) and a known point (<c>from</c>) on that line.</para>
    /// <para><code>
    /// var fromA = Vector2.Zero;
    /// var dirA = Vector2.Right;
    /// var fromB = Vector2.Down;
    /// 
    /// // Returns new Vector2(1, 0)
    /// Geometry2D.LineIntersectsLine(fromA, dirA, fromB, new Vector2(1, -1));
    /// // Returns new Vector2(-1, 0)
    /// Geometry2D.LineIntersectsLine(fromA, dirA, fromB, new Vector2(-1, -1));
    /// // Returns null
    /// Geometry2D.LineIntersectsLine(fromA, dirA, fromB, Vector2.Right);
    /// </code></para>
    /// </summary>
    public static unsafe Variant LineIntersectsLine(Vector2 fromA, Vector2 dirA, Vector2 fromB, Vector2 dirB)
    {
        return NativeCalls.godot_icall_4_661(MethodBind3, GodotObject.GetPtr(Singleton), &fromA, &dirA, &fromB, &dirB);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetClosestPointsBetweenSegments, 3344690961ul);

    /// <summary>
    /// <para>Given the two 2D segments (<paramref name="p1"/>, <paramref name="q1"/>) and (<paramref name="p2"/>, <paramref name="q2"/>), finds those two points on the two segments that are closest to each other. Returns a <see cref="Godot.Vector2"/>[] that contains this point on (<paramref name="p1"/>, <paramref name="q1"/>) as well the accompanying point on (<paramref name="p2"/>, <paramref name="q2"/>).</para>
    /// </summary>
    public static unsafe Vector2[] GetClosestPointsBetweenSegments(Vector2 p1, Vector2 q1, Vector2 p2, Vector2 q2)
    {
        return NativeCalls.godot_icall_4_662(MethodBind4, GodotObject.GetPtr(Singleton), &p1, &q1, &p2, &q2);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetClosestPointToSegment, 4172901909ul);

    /// <summary>
    /// <para>Returns the 2D point on the 2D segment (<paramref name="s1"/>, <paramref name="s2"/>) that is closest to <paramref name="point"/>. The returned point will always be inside the specified segment.</para>
    /// </summary>
    public static unsafe Vector2 GetClosestPointToSegment(Vector2 point, Vector2 s1, Vector2 s2)
    {
        return NativeCalls.godot_icall_3_663(MethodBind5, GodotObject.GetPtr(Singleton), &point, &s1, &s2);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetClosestPointToSegmentUncapped, 4172901909ul);

    /// <summary>
    /// <para>Returns the 2D point on the 2D line defined by (<paramref name="s1"/>, <paramref name="s2"/>) that is closest to <paramref name="point"/>. The returned point can be inside the segment (<paramref name="s1"/>, <paramref name="s2"/>) or outside of it, i.e. somewhere on the line extending from the segment.</para>
    /// </summary>
    public static unsafe Vector2 GetClosestPointToSegmentUncapped(Vector2 point, Vector2 s1, Vector2 s2)
    {
        return NativeCalls.godot_icall_3_663(MethodBind6, GodotObject.GetPtr(Singleton), &point, &s1, &s2);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.PointIsInsideTriangle, 1025948137ul);

    /// <summary>
    /// <para>Returns if <paramref name="point"/> is inside the triangle specified by <paramref name="a"/>, <paramref name="b"/> and <paramref name="c"/>.</para>
    /// </summary>
    public static unsafe bool PointIsInsideTriangle(Vector2 point, Vector2 a, Vector2 b, Vector2 c)
    {
        return NativeCalls.godot_icall_4_664(MethodBind7, GodotObject.GetPtr(Singleton), &point, &a, &b, &c).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.IsPolygonClockwise, 1361156557ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if <paramref name="polygon"/>'s vertices are ordered in clockwise order, otherwise returns <see langword="false"/>.</para>
    /// <para><b>Note:</b> Assumes a Cartesian coordinate system where <c>+x</c> is right and <c>+y</c> is up. If using screen coordinates (<c>+y</c> is down), the result will need to be flipped (i.e. a <see langword="true"/> result will indicate counter-clockwise).</para>
    /// </summary>
    public static bool IsPolygonClockwise(Vector2[] polygon)
    {
        return NativeCalls.godot_icall_1_200(MethodBind8, GodotObject.GetPtr(Singleton), polygon).ToBool();
    }

    /// <summary>
    /// <para>Returns <see langword="true"/> if <paramref name="polygon"/>'s vertices are ordered in clockwise order, otherwise returns <see langword="false"/>.</para>
    /// <para><b>Note:</b> Assumes a Cartesian coordinate system where <c>+x</c> is right and <c>+y</c> is up. If using screen coordinates (<c>+y</c> is down), the result will need to be flipped (i.e. a <see langword="true"/> result will indicate counter-clockwise).</para>
    /// </summary>
    public static bool IsPolygonClockwise(ReadOnlySpan<Vector2> polygon)
    {
        return NativeCalls.godot_icall_1_200(MethodBind8, GodotObject.GetPtr(Singleton), polygon).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.IsPointInPolygon, 738277916ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if <paramref name="point"/> is inside <paramref name="polygon"/> or if it's located exactly <i>on</i> polygon's boundary, otherwise returns <see langword="false"/>.</para>
    /// </summary>
    public static unsafe bool IsPointInPolygon(Vector2 point, Vector2[] polygon)
    {
        return NativeCalls.godot_icall_2_665(MethodBind9, GodotObject.GetPtr(Singleton), &point, polygon).ToBool();
    }

    /// <summary>
    /// <para>Returns <see langword="true"/> if <paramref name="point"/> is inside <paramref name="polygon"/> or if it's located exactly <i>on</i> polygon's boundary, otherwise returns <see langword="false"/>.</para>
    /// </summary>
    public static unsafe bool IsPointInPolygon(Vector2 point, ReadOnlySpan<Vector2> polygon)
    {
        return NativeCalls.godot_icall_2_665(MethodBind9, GodotObject.GetPtr(Singleton), &point, polygon).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.TriangulatePolygon, 1389921771ul);

    /// <summary>
    /// <para>Triangulates the polygon specified by the points in <paramref name="polygon"/>. Returns a <see cref="int"/>[] where each triangle consists of three consecutive point indices into <paramref name="polygon"/> (i.e. the returned array will have <c>n * 3</c> elements, with <c>n</c> being the number of found triangles). Output triangles will always be counter clockwise, and the contour will be flipped if it's clockwise. If the triangulation did not succeed, an empty <see cref="int"/>[] is returned.</para>
    /// </summary>
    public static int[] TriangulatePolygon(Vector2[] polygon)
    {
        return NativeCalls.godot_icall_1_666(MethodBind10, GodotObject.GetPtr(Singleton), polygon);
    }

    /// <summary>
    /// <para>Triangulates the polygon specified by the points in <paramref name="polygon"/>. Returns a <see cref="int"/>[] where each triangle consists of three consecutive point indices into <paramref name="polygon"/> (i.e. the returned array will have <c>n * 3</c> elements, with <c>n</c> being the number of found triangles). Output triangles will always be counter clockwise, and the contour will be flipped if it's clockwise. If the triangulation did not succeed, an empty <see cref="int"/>[] is returned.</para>
    /// </summary>
    public static int[] TriangulatePolygon(ReadOnlySpan<Vector2> polygon)
    {
        return NativeCalls.godot_icall_1_666(MethodBind10, GodotObject.GetPtr(Singleton), polygon);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.TriangulateDelaunay, 1389921771ul);

    /// <summary>
    /// <para>Triangulates the area specified by discrete set of <paramref name="points"/> such that no point is inside the circumcircle of any resulting triangle. Returns a <see cref="int"/>[] where each triangle consists of three consecutive point indices into <paramref name="points"/> (i.e. the returned array will have <c>n * 3</c> elements, with <c>n</c> being the number of found triangles). If the triangulation did not succeed, an empty <see cref="int"/>[] is returned.</para>
    /// </summary>
    public static int[] TriangulateDelaunay(Vector2[] points)
    {
        return NativeCalls.godot_icall_1_666(MethodBind11, GodotObject.GetPtr(Singleton), points);
    }

    /// <summary>
    /// <para>Triangulates the area specified by discrete set of <paramref name="points"/> such that no point is inside the circumcircle of any resulting triangle. Returns a <see cref="int"/>[] where each triangle consists of three consecutive point indices into <paramref name="points"/> (i.e. the returned array will have <c>n * 3</c> elements, with <c>n</c> being the number of found triangles). If the triangulation did not succeed, an empty <see cref="int"/>[] is returned.</para>
    /// </summary>
    public static int[] TriangulateDelaunay(ReadOnlySpan<Vector2> points)
    {
        return NativeCalls.godot_icall_1_666(MethodBind11, GodotObject.GetPtr(Singleton), points);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ConvexHull, 2004331998ul);

    /// <summary>
    /// <para>Given an array of <see cref="Godot.Vector2"/>s, returns the convex hull as a list of points in counterclockwise order. The last point is the same as the first one.</para>
    /// </summary>
    public static Vector2[] ConvexHull(Vector2[] points)
    {
        return NativeCalls.godot_icall_1_667(MethodBind12, GodotObject.GetPtr(Singleton), points);
    }

    /// <summary>
    /// <para>Given an array of <see cref="Godot.Vector2"/>s, returns the convex hull as a list of points in counterclockwise order. The last point is the same as the first one.</para>
    /// </summary>
    public static Vector2[] ConvexHull(ReadOnlySpan<Vector2> points)
    {
        return NativeCalls.godot_icall_1_667(MethodBind12, GodotObject.GetPtr(Singleton), points);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.DecomposePolygonInConvex, 3982393695ul);

    /// <summary>
    /// <para>Decomposes the <paramref name="polygon"/> into multiple convex hulls and returns an array of <see cref="Godot.Vector2"/>[].</para>
    /// </summary>
    public static Godot.Collections.Array<Vector2[]> DecomposePolygonInConvex(Vector2[] polygon)
    {
        return new Godot.Collections.Array<Vector2[]>(NativeCalls.godot_icall_1_668(MethodBind13, GodotObject.GetPtr(Singleton), polygon));
    }

    /// <summary>
    /// <para>Decomposes the <paramref name="polygon"/> into multiple convex hulls and returns an array of <see cref="Godot.Vector2"/>[].</para>
    /// </summary>
    public static Godot.Collections.Array<Vector2[]> DecomposePolygonInConvex(ReadOnlySpan<Vector2> polygon)
    {
        return new Godot.Collections.Array<Vector2[]>(NativeCalls.godot_icall_1_668(MethodBind13, GodotObject.GetPtr(Singleton), polygon));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.MergePolygons, 3637387053ul);

    /// <summary>
    /// <para>Merges (combines) <paramref name="polygonA"/> and <paramref name="polygonB"/> and returns an array of merged polygons. This performs <see cref="Godot.Geometry2D.PolyBooleanOperation.Union"/> between polygons.</para>
    /// <para>The operation may result in an outer polygon (boundary) and multiple inner polygons (holes) produced which could be distinguished by calling <see cref="Godot.Geometry2D.IsPolygonClockwise(Vector2[])"/>.</para>
    /// </summary>
    public static Godot.Collections.Array<Vector2[]> MergePolygons(Vector2[] polygonA, Vector2[] polygonB)
    {
        return new Godot.Collections.Array<Vector2[]>(NativeCalls.godot_icall_2_669(MethodBind14, GodotObject.GetPtr(Singleton), polygonA, polygonB));
    }

    /// <summary>
    /// <para>Merges (combines) <paramref name="polygonA"/> and <paramref name="polygonB"/> and returns an array of merged polygons. This performs <see cref="Godot.Geometry2D.PolyBooleanOperation.Union"/> between polygons.</para>
    /// <para>The operation may result in an outer polygon (boundary) and multiple inner polygons (holes) produced which could be distinguished by calling <see cref="Godot.Geometry2D.IsPolygonClockwise(Vector2[])"/>.</para>
    /// </summary>
    public static Godot.Collections.Array<Vector2[]> MergePolygons(ReadOnlySpan<Vector2> polygonA, ReadOnlySpan<Vector2> polygonB)
    {
        return new Godot.Collections.Array<Vector2[]>(NativeCalls.godot_icall_2_669(MethodBind14, GodotObject.GetPtr(Singleton), polygonA, polygonB));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ClipPolygons, 3637387053ul);

    /// <summary>
    /// <para>Clips <paramref name="polygonA"/> against <paramref name="polygonB"/> and returns an array of clipped polygons. This performs <see cref="Godot.Geometry2D.PolyBooleanOperation.Difference"/> between polygons. Returns an empty array if <paramref name="polygonB"/> completely overlaps <paramref name="polygonA"/>.</para>
    /// <para>If <paramref name="polygonB"/> is enclosed by <paramref name="polygonA"/>, returns an outer polygon (boundary) and inner polygon (hole) which could be distinguished by calling <see cref="Godot.Geometry2D.IsPolygonClockwise(Vector2[])"/>.</para>
    /// </summary>
    public static Godot.Collections.Array<Vector2[]> ClipPolygons(Vector2[] polygonA, Vector2[] polygonB)
    {
        return new Godot.Collections.Array<Vector2[]>(NativeCalls.godot_icall_2_669(MethodBind15, GodotObject.GetPtr(Singleton), polygonA, polygonB));
    }

    /// <summary>
    /// <para>Clips <paramref name="polygonA"/> against <paramref name="polygonB"/> and returns an array of clipped polygons. This performs <see cref="Godot.Geometry2D.PolyBooleanOperation.Difference"/> between polygons. Returns an empty array if <paramref name="polygonB"/> completely overlaps <paramref name="polygonA"/>.</para>
    /// <para>If <paramref name="polygonB"/> is enclosed by <paramref name="polygonA"/>, returns an outer polygon (boundary) and inner polygon (hole) which could be distinguished by calling <see cref="Godot.Geometry2D.IsPolygonClockwise(Vector2[])"/>.</para>
    /// </summary>
    public static Godot.Collections.Array<Vector2[]> ClipPolygons(ReadOnlySpan<Vector2> polygonA, ReadOnlySpan<Vector2> polygonB)
    {
        return new Godot.Collections.Array<Vector2[]>(NativeCalls.godot_icall_2_669(MethodBind15, GodotObject.GetPtr(Singleton), polygonA, polygonB));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.IntersectPolygons, 3637387053ul);

    /// <summary>
    /// <para>Intersects <paramref name="polygonA"/> with <paramref name="polygonB"/> and returns an array of intersected polygons. This performs <see cref="Godot.Geometry2D.PolyBooleanOperation.Intersection"/> between polygons. In other words, returns common area shared by polygons. Returns an empty array if no intersection occurs.</para>
    /// <para>The operation may result in an outer polygon (boundary) and inner polygon (hole) produced which could be distinguished by calling <see cref="Godot.Geometry2D.IsPolygonClockwise(Vector2[])"/>.</para>
    /// </summary>
    public static Godot.Collections.Array<Vector2[]> IntersectPolygons(Vector2[] polygonA, Vector2[] polygonB)
    {
        return new Godot.Collections.Array<Vector2[]>(NativeCalls.godot_icall_2_669(MethodBind16, GodotObject.GetPtr(Singleton), polygonA, polygonB));
    }

    /// <summary>
    /// <para>Intersects <paramref name="polygonA"/> with <paramref name="polygonB"/> and returns an array of intersected polygons. This performs <see cref="Godot.Geometry2D.PolyBooleanOperation.Intersection"/> between polygons. In other words, returns common area shared by polygons. Returns an empty array if no intersection occurs.</para>
    /// <para>The operation may result in an outer polygon (boundary) and inner polygon (hole) produced which could be distinguished by calling <see cref="Godot.Geometry2D.IsPolygonClockwise(Vector2[])"/>.</para>
    /// </summary>
    public static Godot.Collections.Array<Vector2[]> IntersectPolygons(ReadOnlySpan<Vector2> polygonA, ReadOnlySpan<Vector2> polygonB)
    {
        return new Godot.Collections.Array<Vector2[]>(NativeCalls.godot_icall_2_669(MethodBind16, GodotObject.GetPtr(Singleton), polygonA, polygonB));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ExcludePolygons, 3637387053ul);

    /// <summary>
    /// <para>Mutually excludes common area defined by intersection of <paramref name="polygonA"/> and <paramref name="polygonB"/> (see <see cref="Godot.Geometry2D.IntersectPolygons(Vector2[], Vector2[])"/>) and returns an array of excluded polygons. This performs <see cref="Godot.Geometry2D.PolyBooleanOperation.Xor"/> between polygons. In other words, returns all but common area between polygons.</para>
    /// <para>The operation may result in an outer polygon (boundary) and inner polygon (hole) produced which could be distinguished by calling <see cref="Godot.Geometry2D.IsPolygonClockwise(Vector2[])"/>.</para>
    /// </summary>
    public static Godot.Collections.Array<Vector2[]> ExcludePolygons(Vector2[] polygonA, Vector2[] polygonB)
    {
        return new Godot.Collections.Array<Vector2[]>(NativeCalls.godot_icall_2_669(MethodBind17, GodotObject.GetPtr(Singleton), polygonA, polygonB));
    }

    /// <summary>
    /// <para>Mutually excludes common area defined by intersection of <paramref name="polygonA"/> and <paramref name="polygonB"/> (see <see cref="Godot.Geometry2D.IntersectPolygons(Vector2[], Vector2[])"/>) and returns an array of excluded polygons. This performs <see cref="Godot.Geometry2D.PolyBooleanOperation.Xor"/> between polygons. In other words, returns all but common area between polygons.</para>
    /// <para>The operation may result in an outer polygon (boundary) and inner polygon (hole) produced which could be distinguished by calling <see cref="Godot.Geometry2D.IsPolygonClockwise(Vector2[])"/>.</para>
    /// </summary>
    public static Godot.Collections.Array<Vector2[]> ExcludePolygons(ReadOnlySpan<Vector2> polygonA, ReadOnlySpan<Vector2> polygonB)
    {
        return new Godot.Collections.Array<Vector2[]>(NativeCalls.godot_icall_2_669(MethodBind17, GodotObject.GetPtr(Singleton), polygonA, polygonB));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ClipPolylineWithPolygon, 3637387053ul);

    /// <summary>
    /// <para>Clips <paramref name="polyline"/> against <paramref name="polygon"/> and returns an array of clipped polylines. This performs <see cref="Godot.Geometry2D.PolyBooleanOperation.Difference"/> between the polyline and the polygon. This operation can be thought of as cutting a line with a closed shape.</para>
    /// </summary>
    public static Godot.Collections.Array<Vector2[]> ClipPolylineWithPolygon(Vector2[] polyline, Vector2[] polygon)
    {
        return new Godot.Collections.Array<Vector2[]>(NativeCalls.godot_icall_2_669(MethodBind18, GodotObject.GetPtr(Singleton), polyline, polygon));
    }

    /// <summary>
    /// <para>Clips <paramref name="polyline"/> against <paramref name="polygon"/> and returns an array of clipped polylines. This performs <see cref="Godot.Geometry2D.PolyBooleanOperation.Difference"/> between the polyline and the polygon. This operation can be thought of as cutting a line with a closed shape.</para>
    /// </summary>
    public static Godot.Collections.Array<Vector2[]> ClipPolylineWithPolygon(ReadOnlySpan<Vector2> polyline, ReadOnlySpan<Vector2> polygon)
    {
        return new Godot.Collections.Array<Vector2[]>(NativeCalls.godot_icall_2_669(MethodBind18, GodotObject.GetPtr(Singleton), polyline, polygon));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.IntersectPolylineWithPolygon, 3637387053ul);

    /// <summary>
    /// <para>Intersects <paramref name="polyline"/> with <paramref name="polygon"/> and returns an array of intersected polylines. This performs <see cref="Godot.Geometry2D.PolyBooleanOperation.Intersection"/> between the polyline and the polygon. This operation can be thought of as chopping a line with a closed shape.</para>
    /// </summary>
    public static Godot.Collections.Array<Vector2[]> IntersectPolylineWithPolygon(Vector2[] polyline, Vector2[] polygon)
    {
        return new Godot.Collections.Array<Vector2[]>(NativeCalls.godot_icall_2_669(MethodBind19, GodotObject.GetPtr(Singleton), polyline, polygon));
    }

    /// <summary>
    /// <para>Intersects <paramref name="polyline"/> with <paramref name="polygon"/> and returns an array of intersected polylines. This performs <see cref="Godot.Geometry2D.PolyBooleanOperation.Intersection"/> between the polyline and the polygon. This operation can be thought of as chopping a line with a closed shape.</para>
    /// </summary>
    public static Godot.Collections.Array<Vector2[]> IntersectPolylineWithPolygon(ReadOnlySpan<Vector2> polyline, ReadOnlySpan<Vector2> polygon)
    {
        return new Godot.Collections.Array<Vector2[]>(NativeCalls.godot_icall_2_669(MethodBind19, GodotObject.GetPtr(Singleton), polyline, polygon));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.OffsetPolygon, 1275354010ul);

    /// <summary>
    /// <para>Inflates or deflates <paramref name="polygon"/> by <paramref name="delta"/> units (pixels). If <paramref name="delta"/> is positive, makes the polygon grow outward. If <paramref name="delta"/> is negative, shrinks the polygon inward. Returns an array of polygons because inflating/deflating may result in multiple discrete polygons. Returns an empty array if <paramref name="delta"/> is negative and the absolute value of it approximately exceeds the minimum bounding rectangle dimensions of the polygon.</para>
    /// <para>Each polygon's vertices will be rounded as determined by <paramref name="joinType"/>.</para>
    /// <para>The operation may result in an outer polygon (boundary) and inner polygon (hole) produced which could be distinguished by calling <see cref="Godot.Geometry2D.IsPolygonClockwise(Vector2[])"/>.</para>
    /// <para><b>Note:</b> To translate the polygon's vertices specifically, multiply them to a <see cref="Godot.Transform2D"/>:</para>
    /// <para><code>
    /// Vector2[] polygon = [new Vector2(0, 0), new Vector2(100, 0), new Vector2(100, 100), new Vector2(0, 100)];
    /// var offset = new Vector2(50, 50);
    /// polygon = new Transform2D(0, offset) * polygon;
    /// GD.Print((Variant)polygon); // Prints [(50, 50), (150, 50), (150, 150), (50, 150)]
    /// </code></para>
    /// </summary>
    public static Godot.Collections.Array<Vector2[]> OffsetPolygon(Vector2[] polygon, float delta, Geometry2D.PolyJoinType joinType = (Geometry2D.PolyJoinType)(0))
    {
        return new Godot.Collections.Array<Vector2[]>(NativeCalls.godot_icall_3_670(MethodBind20, GodotObject.GetPtr(Singleton), polygon, delta, (int)joinType));
    }

    /// <summary>
    /// <para>Inflates or deflates <paramref name="polygon"/> by <paramref name="delta"/> units (pixels). If <paramref name="delta"/> is positive, makes the polygon grow outward. If <paramref name="delta"/> is negative, shrinks the polygon inward. Returns an array of polygons because inflating/deflating may result in multiple discrete polygons. Returns an empty array if <paramref name="delta"/> is negative and the absolute value of it approximately exceeds the minimum bounding rectangle dimensions of the polygon.</para>
    /// <para>Each polygon's vertices will be rounded as determined by <paramref name="joinType"/>.</para>
    /// <para>The operation may result in an outer polygon (boundary) and inner polygon (hole) produced which could be distinguished by calling <see cref="Godot.Geometry2D.IsPolygonClockwise(Vector2[])"/>.</para>
    /// <para><b>Note:</b> To translate the polygon's vertices specifically, multiply them to a <see cref="Godot.Transform2D"/>:</para>
    /// <para><code>
    /// Vector2[] polygon = [new Vector2(0, 0), new Vector2(100, 0), new Vector2(100, 100), new Vector2(0, 100)];
    /// var offset = new Vector2(50, 50);
    /// polygon = new Transform2D(0, offset) * polygon;
    /// GD.Print((Variant)polygon); // Prints [(50, 50), (150, 50), (150, 150), (50, 150)]
    /// </code></para>
    /// </summary>
    public static Godot.Collections.Array<Vector2[]> OffsetPolygon(ReadOnlySpan<Vector2> polygon, float delta, Geometry2D.PolyJoinType joinType)
    {
        return new Godot.Collections.Array<Vector2[]>(NativeCalls.godot_icall_3_670(MethodBind20, GodotObject.GetPtr(Singleton), polygon, delta, (int)joinType));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.OffsetPolyline, 2328231778ul);

    /// <summary>
    /// <para>Inflates or deflates <paramref name="polyline"/> by <paramref name="delta"/> units (pixels), producing polygons. If <paramref name="delta"/> is positive, makes the polyline grow outward. Returns an array of polygons because inflating/deflating may result in multiple discrete polygons. If <paramref name="delta"/> is negative, returns an empty array.</para>
    /// <para>Each polygon's vertices will be rounded as determined by <paramref name="joinType"/>.</para>
    /// <para>Each polygon's endpoints will be rounded as determined by <paramref name="endType"/>.</para>
    /// <para>The operation may result in an outer polygon (boundary) and inner polygon (hole) produced which could be distinguished by calling <see cref="Godot.Geometry2D.IsPolygonClockwise(Vector2[])"/>.</para>
    /// </summary>
    public static Godot.Collections.Array<Vector2[]> OffsetPolyline(Vector2[] polyline, float delta, Geometry2D.PolyJoinType joinType = (Geometry2D.PolyJoinType)(0), Geometry2D.PolyEndType endType = (Geometry2D.PolyEndType)(3))
    {
        return new Godot.Collections.Array<Vector2[]>(NativeCalls.godot_icall_4_671(MethodBind21, GodotObject.GetPtr(Singleton), polyline, delta, (int)joinType, (int)endType));
    }

    /// <summary>
    /// <para>Inflates or deflates <paramref name="polyline"/> by <paramref name="delta"/> units (pixels), producing polygons. If <paramref name="delta"/> is positive, makes the polyline grow outward. Returns an array of polygons because inflating/deflating may result in multiple discrete polygons. If <paramref name="delta"/> is negative, returns an empty array.</para>
    /// <para>Each polygon's vertices will be rounded as determined by <paramref name="joinType"/>.</para>
    /// <para>Each polygon's endpoints will be rounded as determined by <paramref name="endType"/>.</para>
    /// <para>The operation may result in an outer polygon (boundary) and inner polygon (hole) produced which could be distinguished by calling <see cref="Godot.Geometry2D.IsPolygonClockwise(Vector2[])"/>.</para>
    /// </summary>
    public static Godot.Collections.Array<Vector2[]> OffsetPolyline(ReadOnlySpan<Vector2> polyline, float delta, Geometry2D.PolyJoinType joinType, Geometry2D.PolyEndType endType)
    {
        return new Godot.Collections.Array<Vector2[]>(NativeCalls.godot_icall_4_671(MethodBind21, GodotObject.GetPtr(Singleton), polyline, delta, (int)joinType, (int)endType));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.MakeAtlas, 1337682371ul);

    /// <summary>
    /// <para>Given an array of <see cref="Godot.Vector2"/>s representing tiles, builds an atlas. The returned dictionary has two keys: <c>points</c> is a <see cref="Godot.Vector2"/>[] that specifies the positions of each tile, <c>size</c> contains the overall size of the whole atlas as <see cref="Godot.Vector2I"/>.</para>
    /// </summary>
    public static Godot.Collections.Dictionary MakeAtlas(Vector2[] sizes)
    {
        return NativeCalls.godot_icall_1_672(MethodBind22, GodotObject.GetPtr(Singleton), sizes);
    }

    /// <summary>
    /// <para>Given an array of <see cref="Godot.Vector2"/>s representing tiles, builds an atlas. The returned dictionary has two keys: <c>points</c> is a <see cref="Godot.Vector2"/>[] that specifies the positions of each tile, <c>size</c> contains the overall size of the whole atlas as <see cref="Godot.Vector2I"/>.</para>
    /// </summary>
    public static Godot.Collections.Dictionary MakeAtlas(ReadOnlySpan<Vector2> sizes)
    {
        return NativeCalls.godot_icall_1_672(MethodBind22, GodotObject.GetPtr(Singleton), sizes);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.BresenhamLine, 1989391000ul);

    /// <summary>
    /// <para>Returns the <a href="https://en.wikipedia.org/wiki/Bresenham%27s_line_algorithm">Bresenham line</a> between the <paramref name="from"/> and <paramref name="to"/> points. A Bresenham line is a series of pixels that draws a line and is always 1-pixel thick on every row and column of the drawing (never more, never less).</para>
    /// <para>Example code to draw a line between two <see cref="Godot.Marker2D"/> nodes using a series of <see cref="Godot.CanvasItem.DrawRect(Rect2, Color, bool, float, bool)"/> calls:</para>
    /// <para><code>
    /// func _draw():
    /// 	for pixel in Geometry2D.bresenham_line($MarkerA.position, $MarkerB.position):
    /// 		draw_rect(Rect2(pixel, Vector2.ONE), Color.WHITE)
    /// </code></para>
    /// </summary>
    public static unsafe Godot.Collections.Array<Vector2I> BresenhamLine(Vector2I from, Vector2I to)
    {
        return new Godot.Collections.Array<Vector2I>(NativeCalls.godot_icall_2_52(MethodBind23, GodotObject.GetPtr(Singleton), &from, &to));
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public class PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public class MethodName
    {
        /// <summary>
        /// Cached name for the 'is_point_in_circle' method.
        /// </summary>
        public static readonly StringName IsPointInCircle = "is_point_in_circle";
        /// <summary>
        /// Cached name for the 'segment_intersects_circle' method.
        /// </summary>
        public static readonly StringName SegmentIntersectsCircle = "segment_intersects_circle";
        /// <summary>
        /// Cached name for the 'segment_intersects_segment' method.
        /// </summary>
        public static readonly StringName SegmentIntersectsSegment = "segment_intersects_segment";
        /// <summary>
        /// Cached name for the 'line_intersects_line' method.
        /// </summary>
        public static readonly StringName LineIntersectsLine = "line_intersects_line";
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
        /// Cached name for the 'point_is_inside_triangle' method.
        /// </summary>
        public static readonly StringName PointIsInsideTriangle = "point_is_inside_triangle";
        /// <summary>
        /// Cached name for the 'is_polygon_clockwise' method.
        /// </summary>
        public static readonly StringName IsPolygonClockwise = "is_polygon_clockwise";
        /// <summary>
        /// Cached name for the 'is_point_in_polygon' method.
        /// </summary>
        public static readonly StringName IsPointInPolygon = "is_point_in_polygon";
        /// <summary>
        /// Cached name for the 'triangulate_polygon' method.
        /// </summary>
        public static readonly StringName TriangulatePolygon = "triangulate_polygon";
        /// <summary>
        /// Cached name for the 'triangulate_delaunay' method.
        /// </summary>
        public static readonly StringName TriangulateDelaunay = "triangulate_delaunay";
        /// <summary>
        /// Cached name for the 'convex_hull' method.
        /// </summary>
        public static readonly StringName ConvexHull = "convex_hull";
        /// <summary>
        /// Cached name for the 'decompose_polygon_in_convex' method.
        /// </summary>
        public static readonly StringName DecomposePolygonInConvex = "decompose_polygon_in_convex";
        /// <summary>
        /// Cached name for the 'merge_polygons' method.
        /// </summary>
        public static readonly StringName MergePolygons = "merge_polygons";
        /// <summary>
        /// Cached name for the 'clip_polygons' method.
        /// </summary>
        public static readonly StringName ClipPolygons = "clip_polygons";
        /// <summary>
        /// Cached name for the 'intersect_polygons' method.
        /// </summary>
        public static readonly StringName IntersectPolygons = "intersect_polygons";
        /// <summary>
        /// Cached name for the 'exclude_polygons' method.
        /// </summary>
        public static readonly StringName ExcludePolygons = "exclude_polygons";
        /// <summary>
        /// Cached name for the 'clip_polyline_with_polygon' method.
        /// </summary>
        public static readonly StringName ClipPolylineWithPolygon = "clip_polyline_with_polygon";
        /// <summary>
        /// Cached name for the 'intersect_polyline_with_polygon' method.
        /// </summary>
        public static readonly StringName IntersectPolylineWithPolygon = "intersect_polyline_with_polygon";
        /// <summary>
        /// Cached name for the 'offset_polygon' method.
        /// </summary>
        public static readonly StringName OffsetPolygon = "offset_polygon";
        /// <summary>
        /// Cached name for the 'offset_polyline' method.
        /// </summary>
        public static readonly StringName OffsetPolyline = "offset_polyline";
        /// <summary>
        /// Cached name for the 'make_atlas' method.
        /// </summary>
        public static readonly StringName MakeAtlas = "make_atlas";
        /// <summary>
        /// Cached name for the 'bresenham_line' method.
        /// </summary>
        public static readonly StringName BresenhamLine = "bresenham_line";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public class SignalName
    {
    }
}
