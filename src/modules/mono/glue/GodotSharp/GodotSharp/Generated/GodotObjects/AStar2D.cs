namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>An implementation of the A* algorithm, used to find the shortest path between two vertices on a connected graph in 2D space.</para>
/// <para>See <see cref="Godot.AStar3D"/> for a more thorough explanation on how to use this class. <see cref="Godot.AStar2D"/> is a wrapper for <see cref="Godot.AStar3D"/> that enforces 2D coordinates.</para>
/// </summary>
public partial class AStar2D : RefCounted
{
    /// <summary>
    /// <para>If <see langword="true"/> enables the filtering of neighbors via <see cref="Godot.AStar2D._FilterNeighbor(long, long)"/>.</para>
    /// </summary>
    public bool NeighborFilterEnabled
    {
        get
        {
            return IsNeighborFilterEnabled();
        }
        set
        {
            SetNeighborFilterEnabled(value);
        }
    }

    private static readonly System.Type CachedType = typeof(AStar2D);

    private static readonly StringName NativeName = "AStar2D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public AStar2D() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal AStar2D(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal AStar2D(bool memoryOwn) : base(memoryOwn) { }

    /// <summary>
    /// <para>Called when computing the cost between two connected points.</para>
    /// <para>Note that this function is hidden in the default <see cref="Godot.AStar2D"/> class.</para>
    /// </summary>
    public virtual float _ComputeCost(long fromId, long toId)
    {
        return default;
    }

    /// <summary>
    /// <para>Called when estimating the cost between a point and the path's ending point.</para>
    /// <para>Note that this function is hidden in the default <see cref="Godot.AStar2D"/> class.</para>
    /// </summary>
    public virtual float _EstimateCost(long fromId, long endId)
    {
        return default;
    }

    /// <summary>
    /// <para>Called when neighboring enters processing and if <see cref="Godot.AStar2D.NeighborFilterEnabled"/> is <see langword="true"/>. If <see langword="true"/> is returned the point will not be processed.</para>
    /// <para>Note that this function is hidden in the default <see cref="Godot.AStar2D"/> class.</para>
    /// </summary>
    public virtual bool _FilterNeighbor(long fromId, long neighborId)
    {
        return default;
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAvailablePointId, 3905245786ul);

    /// <summary>
    /// <para>Returns the next available point ID with no point associated to it.</para>
    /// </summary>
    public long GetAvailablePointId()
    {
        return NativeCalls.godot_icall_0_4(MethodBind0, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddPoint, 4074201818ul);

    /// <summary>
    /// <para>Adds a new point at the given position with the given identifier. The <paramref name="id"/> must be 0 or larger, and the <paramref name="weightScale"/> must be 0.0 or greater.</para>
    /// <para>The <paramref name="weightScale"/> is multiplied by the result of <see cref="Godot.AStar2D._ComputeCost(long, long)"/> when determining the overall cost of traveling across a segment from a neighboring point to this point. Thus, all else being equal, the algorithm prefers points with lower <paramref name="weightScale"/>s to form a path.</para>
    /// <para><code>
    /// var astar = new AStar2D();
    /// astar.AddPoint(1, new Vector2(1, 0), 4); // Adds the point (1, 0) with weight_scale 4 and id 1
    /// </code></para>
    /// <para>If there already exists a point for the given <paramref name="id"/>, its position and weight scale are updated to the given values.</para>
    /// </summary>
    public unsafe void AddPoint(long id, Vector2 position, float weightScale = 1.0f)
    {
        NativeCalls.godot_icall_3_5(MethodBind1, GodotObject.GetPtr(this), id, &position, weightScale);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPointPosition, 2299179447ul);

    /// <summary>
    /// <para>Returns the position of the point associated with the given <paramref name="id"/>.</para>
    /// </summary>
    public Vector2 GetPointPosition(long id)
    {
        return NativeCalls.godot_icall_1_6(MethodBind2, GodotObject.GetPtr(this), id);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPointPosition, 163021252ul);

    /// <summary>
    /// <para>Sets the <paramref name="position"/> for the point with the given <paramref name="id"/>.</para>
    /// </summary>
    public unsafe void SetPointPosition(long id, Vector2 position)
    {
        NativeCalls.godot_icall_2_7(MethodBind3, GodotObject.GetPtr(this), id, &position);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPointWeightScale, 2339986948ul);

    /// <summary>
    /// <para>Returns the weight scale of the point associated with the given <paramref name="id"/>.</para>
    /// </summary>
    public float GetPointWeightScale(long id)
    {
        return NativeCalls.godot_icall_1_8(MethodBind4, GodotObject.GetPtr(this), id);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPointWeightScale, 1602489585ul);

    /// <summary>
    /// <para>Sets the <paramref name="weightScale"/> for the point with the given <paramref name="id"/>. The <paramref name="weightScale"/> is multiplied by the result of <see cref="Godot.AStar2D._ComputeCost(long, long)"/> when determining the overall cost of traveling across a segment from a neighboring point to this point.</para>
    /// </summary>
    public void SetPointWeightScale(long id, float weightScale)
    {
        NativeCalls.godot_icall_2_9(MethodBind5, GodotObject.GetPtr(this), id, weightScale);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemovePoint, 1286410249ul);

    /// <summary>
    /// <para>Removes the point associated with the given <paramref name="id"/> from the points pool.</para>
    /// </summary>
    public void RemovePoint(long id)
    {
        NativeCalls.godot_icall_1_10(MethodBind6, GodotObject.GetPtr(this), id);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasPoint, 1116898809ul);

    /// <summary>
    /// <para>Returns whether a point associated with the given <paramref name="id"/> exists.</para>
    /// </summary>
    public bool HasPoint(long id)
    {
        return NativeCalls.godot_icall_1_11(MethodBind7, GodotObject.GetPtr(this), id).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPointConnections, 2865087369ul);

    /// <summary>
    /// <para>Returns an array with the IDs of the points that form the connection with the given point.</para>
    /// <para><code>
    /// var astar = new AStar2D();
    /// astar.AddPoint(1, new Vector2(0, 0));
    /// astar.AddPoint(2, new Vector2(0, 1));
    /// astar.AddPoint(3, new Vector2(1, 1));
    /// astar.AddPoint(4, new Vector2(2, 0));
    /// 
    /// astar.ConnectPoints(1, 2, true);
    /// astar.ConnectPoints(1, 3, true);
    /// 
    /// long[] neighbors = astar.GetPointConnections(1); // Returns [2, 3]
    /// </code></para>
    /// </summary>
    public long[] GetPointConnections(long id)
    {
        return NativeCalls.godot_icall_1_12(MethodBind8, GodotObject.GetPtr(this), id);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPointIds, 3851388692ul);

    /// <summary>
    /// <para>Returns an array of all point IDs.</para>
    /// </summary>
    public long[] GetPointIds()
    {
        return NativeCalls.godot_icall_0_13(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetNeighborFilterEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetNeighborFilterEnabled(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind10, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsNeighborFilterEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsNeighborFilterEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind11, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPointDisabled, 972357352ul);

    /// <summary>
    /// <para>Disables or enables the specified point for pathfinding. Useful for making a temporary obstacle.</para>
    /// </summary>
    public void SetPointDisabled(long id, bool disabled = true)
    {
        NativeCalls.godot_icall_2_16(MethodBind12, GodotObject.GetPtr(this), id, disabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsPointDisabled, 1116898809ul);

    /// <summary>
    /// <para>Returns whether a point is disabled or not for pathfinding. By default, all points are enabled.</para>
    /// </summary>
    public bool IsPointDisabled(long id)
    {
        return NativeCalls.godot_icall_1_11(MethodBind13, GodotObject.GetPtr(this), id).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ConnectPoints, 3710494224ul);

    /// <summary>
    /// <para>Creates a segment between the given points. If <paramref name="bidirectional"/> is <see langword="false"/>, only movement from <paramref name="id"/> to <paramref name="toId"/> is allowed, not the reverse direction.</para>
    /// <para><code>
    /// var astar = new AStar2D();
    /// astar.AddPoint(1, new Vector2(1, 1));
    /// astar.AddPoint(2, new Vector2(0, 5));
    /// astar.ConnectPoints(1, 2, false);
    /// </code></para>
    /// </summary>
    public void ConnectPoints(long id, long toId, bool bidirectional = true)
    {
        NativeCalls.godot_icall_3_17(MethodBind14, GodotObject.GetPtr(this), id, toId, bidirectional.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DisconnectPoints, 3710494224ul);

    /// <summary>
    /// <para>Deletes the segment between the given points. If <paramref name="bidirectional"/> is <see langword="false"/>, only movement from <paramref name="id"/> to <paramref name="toId"/> is prevented, and a unidirectional segment possibly remains.</para>
    /// </summary>
    public void DisconnectPoints(long id, long toId, bool bidirectional = true)
    {
        NativeCalls.godot_icall_3_17(MethodBind15, GodotObject.GetPtr(this), id, toId, bidirectional.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ArePointsConnected, 2288175859ul);

    /// <summary>
    /// <para>Returns whether there is a connection/segment between the given points. If <paramref name="bidirectional"/> is <see langword="false"/>, returns whether movement from <paramref name="id"/> to <paramref name="toId"/> is possible through this segment.</para>
    /// </summary>
    public bool ArePointsConnected(long id, long toId, bool bidirectional = true)
    {
        return NativeCalls.godot_icall_3_18(MethodBind16, GodotObject.GetPtr(this), id, toId, bidirectional.ToGodotBool()).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPointCount, 3905245786ul);

    /// <summary>
    /// <para>Returns the number of points currently in the points pool.</para>
    /// </summary>
    public long GetPointCount()
    {
        return NativeCalls.godot_icall_0_4(MethodBind17, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPointCapacity, 3905245786ul);

    /// <summary>
    /// <para>Returns the capacity of the structure backing the points, useful in conjunction with <see cref="Godot.AStar2D.ReserveSpace(long)"/>.</para>
    /// </summary>
    public long GetPointCapacity()
    {
        return NativeCalls.godot_icall_0_4(MethodBind18, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ReserveSpace, 1286410249ul);

    /// <summary>
    /// <para>Reserves space internally for <paramref name="numNodes"/> points. Useful if you're adding a known large number of points at once, such as points on a grid.</para>
    /// </summary>
    public void ReserveSpace(long numNodes)
    {
        NativeCalls.godot_icall_1_10(MethodBind19, GodotObject.GetPtr(this), numNodes);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Clear, 3218959716ul);

    /// <summary>
    /// <para>Clears all the points and segments.</para>
    /// </summary>
    public void Clear()
    {
        NativeCalls.godot_icall_0_3(MethodBind20, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetClosestPoint, 2300324924ul);

    /// <summary>
    /// <para>Returns the ID of the closest point to <paramref name="toPosition"/>, optionally taking disabled points into account. Returns <c>-1</c> if there are no points in the points pool.</para>
    /// <para><b>Note:</b> If several points are the closest to <paramref name="toPosition"/>, the one with the smallest ID will be returned, ensuring a deterministic result.</para>
    /// </summary>
    public unsafe long GetClosestPoint(Vector2 toPosition, bool includeDisabled = false)
    {
        return NativeCalls.godot_icall_2_19(MethodBind21, GodotObject.GetPtr(this), &toPosition, includeDisabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetClosestPositionInSegment, 2656412154ul);

    /// <summary>
    /// <para>Returns the closest position to <paramref name="toPosition"/> that resides inside a segment between two connected points.</para>
    /// <para><code>
    /// var astar = new AStar2D();
    /// astar.AddPoint(1, new Vector2(0, 0));
    /// astar.AddPoint(2, new Vector2(0, 5));
    /// astar.ConnectPoints(1, 2);
    /// Vector2 res = astar.GetClosestPositionInSegment(new Vector2(3, 3)); // Returns (0, 3)
    /// </code></para>
    /// <para>The result is in the segment that goes from <c>y = 0</c> to <c>y = 5</c>. It's the closest position in the segment to the given point.</para>
    /// </summary>
    public unsafe Vector2 GetClosestPositionInSegment(Vector2 toPosition)
    {
        return NativeCalls.godot_icall_1_20(MethodBind22, GodotObject.GetPtr(this), &toPosition);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPointPath, 3427490392ul);

    /// <summary>
    /// <para>Returns an array with the points that are in the path found by AStar2D between the given points. The array is ordered from the starting point to the ending point of the path.</para>
    /// <para>If <paramref name="fromId"/> point is disabled, returns an empty array (even if <c>from_id == to_id</c>).</para>
    /// <para>If <paramref name="fromId"/> point is not disabled, there is no valid path to the target, and <paramref name="allowPartialPath"/> is <see langword="true"/>, returns a path to the point closest to the target that can be reached.</para>
    /// <para><b>Note:</b> This method is not thread-safe; it can only be used from a single <see cref="Godot.GodotThread"/> at a given time. Consider using <see cref="Godot.Mutex"/> to ensure exclusive access to one thread to avoid race conditions.</para>
    /// <para>Additionally, when <paramref name="allowPartialPath"/> is <see langword="true"/> and <paramref name="toId"/> is disabled the search may take an unusually long time to finish.</para>
    /// </summary>
    public Vector2[] GetPointPath(long fromId, long toId, bool allowPartialPath = false)
    {
        return NativeCalls.godot_icall_3_21(MethodBind23, GodotObject.GetPtr(this), fromId, toId, allowPartialPath.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetIdPath, 3136199648ul);

    /// <summary>
    /// <para>Returns an array with the IDs of the points that form the path found by AStar2D between the given points. The array is ordered from the starting point to the ending point of the path.</para>
    /// <para>If <paramref name="fromId"/> point is disabled, returns an empty array (even if <c>from_id == to_id</c>).</para>
    /// <para>If <paramref name="fromId"/> point is not disabled, there is no valid path to the target, and <paramref name="allowPartialPath"/> is <see langword="true"/>, returns a path to the point closest to the target that can be reached.</para>
    /// <para><b>Note:</b> When <paramref name="allowPartialPath"/> is <see langword="true"/> and <paramref name="toId"/> is disabled the search may take an unusually long time to finish.</para>
    /// <para><code>
    /// var astar = new AStar2D();
    /// astar.AddPoint(1, new Vector2(0, 0));
    /// astar.AddPoint(2, new Vector2(0, 1), 1); // Default weight is 1
    /// astar.AddPoint(3, new Vector2(1, 1));
    /// astar.AddPoint(4, new Vector2(2, 0));
    /// 
    /// astar.ConnectPoints(1, 2, false);
    /// astar.ConnectPoints(2, 3, false);
    /// astar.ConnectPoints(4, 3, false);
    /// astar.ConnectPoints(1, 4, false);
    /// long[] res = astar.GetIdPath(1, 3); // Returns [1, 2, 3]
    /// </code></para>
    /// <para>If you change the 2nd point's weight to 3, then the result will be <c>[1, 4, 3]</c> instead, because now even though the distance is longer, it's "easier" to get through point 4 than through point 2.</para>
    /// </summary>
    public long[] GetIdPath(long fromId, long toId, bool allowPartialPath = false)
    {
        return NativeCalls.godot_icall_3_22(MethodBind24, GodotObject.GetPtr(this), fromId, toId, allowPartialPath.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPointPath, 281625055ul);

    /// <summary>
    /// <para>Returns an array with the points that are in the path found by AStar2D between the given points. The array is ordered from the starting point to the ending point of the path.</para>
    /// <para>If <paramref name="fromId"/> point is disabled, returns an empty array (even if <c>from_id == to_id</c>).</para>
    /// <para>If <paramref name="fromId"/> point is not disabled, there is no valid path to the target, and <paramref name="allowPartialPath"/> is <see langword="true"/>, returns a path to the point closest to the target that can be reached.</para>
    /// <para><b>Note:</b> This method is not thread-safe; it can only be used from a single <see cref="Godot.GodotThread"/> at a given time. Consider using <see cref="Godot.Mutex"/> to ensure exclusive access to one thread to avoid race conditions.</para>
    /// <para>Additionally, when <paramref name="allowPartialPath"/> is <see langword="true"/> and <paramref name="toId"/> is disabled the search may take an unusually long time to finish.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2[] GetPointPath(long fromId, long toId)
    {
        return NativeCalls.godot_icall_2_23(MethodBind25, GodotObject.GetPtr(this), fromId, toId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetIdPath, 3404614526ul);

    /// <summary>
    /// <para>Returns an array with the IDs of the points that form the path found by AStar2D between the given points. The array is ordered from the starting point to the ending point of the path.</para>
    /// <para>If <paramref name="fromId"/> point is disabled, returns an empty array (even if <c>from_id == to_id</c>).</para>
    /// <para>If <paramref name="fromId"/> point is not disabled, there is no valid path to the target, and <paramref name="allowPartialPath"/> is <see langword="true"/>, returns a path to the point closest to the target that can be reached.</para>
    /// <para><b>Note:</b> When <paramref name="allowPartialPath"/> is <see langword="true"/> and <paramref name="toId"/> is disabled the search may take an unusually long time to finish.</para>
    /// <para><code>
    /// var astar = new AStar2D();
    /// astar.AddPoint(1, new Vector2(0, 0));
    /// astar.AddPoint(2, new Vector2(0, 1), 1); // Default weight is 1
    /// astar.AddPoint(3, new Vector2(1, 1));
    /// astar.AddPoint(4, new Vector2(2, 0));
    /// 
    /// astar.ConnectPoints(1, 2, false);
    /// astar.ConnectPoints(2, 3, false);
    /// astar.ConnectPoints(4, 3, false);
    /// astar.ConnectPoints(1, 4, false);
    /// long[] res = astar.GetIdPath(1, 3); // Returns [1, 2, 3]
    /// </code></para>
    /// <para>If you change the 2nd point's weight to 3, then the result will be <c>[1, 4, 3]</c> instead, because now even though the distance is longer, it's "easier" to get through point 4 than through point 2.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public long[] GetIdPath(long fromId, long toId)
    {
        return NativeCalls.godot_icall_2_24(MethodBind26, GodotObject.GetPtr(this), fromId, toId);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__compute_cost = "_ComputeCost";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__estimate_cost = "_EstimateCost";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__filter_neighbor = "_FilterNeighbor";

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
        if ((method == MethodProxyName__compute_cost || method == MethodName._ComputeCost) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__compute_cost.NativeValue))
        {
            var callRet = _ComputeCost(VariantUtils.ConvertTo<long>(args[0]), VariantUtils.ConvertTo<long>(args[1]));
            ret = VariantUtils.CreateFrom<float>(callRet);
            return true;
        }
        if ((method == MethodProxyName__estimate_cost || method == MethodName._EstimateCost) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__estimate_cost.NativeValue))
        {
            var callRet = _EstimateCost(VariantUtils.ConvertTo<long>(args[0]), VariantUtils.ConvertTo<long>(args[1]));
            ret = VariantUtils.CreateFrom<float>(callRet);
            return true;
        }
        if ((method == MethodProxyName__filter_neighbor || method == MethodName._FilterNeighbor) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__filter_neighbor.NativeValue))
        {
            var callRet = _FilterNeighbor(VariantUtils.ConvertTo<long>(args[0]), VariantUtils.ConvertTo<long>(args[1]));
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
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
        if (method == MethodName._ComputeCost)
        {
            if (HasGodotClassMethod(MethodProxyName__compute_cost.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._EstimateCost)
        {
            if (HasGodotClassMethod(MethodProxyName__estimate_cost.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FilterNeighbor)
        {
            if (HasGodotClassMethod(MethodProxyName__filter_neighbor.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
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
        /// Cached name for the 'neighbor_filter_enabled' property.
        /// </summary>
        public static readonly StringName NeighborFilterEnabled = "neighbor_filter_enabled";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : RefCounted.MethodName
    {
        /// <summary>
        /// Cached name for the '_compute_cost' method.
        /// </summary>
        public static readonly StringName _ComputeCost = "_compute_cost";
        /// <summary>
        /// Cached name for the '_estimate_cost' method.
        /// </summary>
        public static readonly StringName _EstimateCost = "_estimate_cost";
        /// <summary>
        /// Cached name for the '_filter_neighbor' method.
        /// </summary>
        public static readonly StringName _FilterNeighbor = "_filter_neighbor";
        /// <summary>
        /// Cached name for the 'get_available_point_id' method.
        /// </summary>
        public static readonly StringName GetAvailablePointId = "get_available_point_id";
        /// <summary>
        /// Cached name for the 'add_point' method.
        /// </summary>
        public static readonly StringName AddPoint = "add_point";
        /// <summary>
        /// Cached name for the 'get_point_position' method.
        /// </summary>
        public static readonly StringName GetPointPosition = "get_point_position";
        /// <summary>
        /// Cached name for the 'set_point_position' method.
        /// </summary>
        public static readonly StringName SetPointPosition = "set_point_position";
        /// <summary>
        /// Cached name for the 'get_point_weight_scale' method.
        /// </summary>
        public static readonly StringName GetPointWeightScale = "get_point_weight_scale";
        /// <summary>
        /// Cached name for the 'set_point_weight_scale' method.
        /// </summary>
        public static readonly StringName SetPointWeightScale = "set_point_weight_scale";
        /// <summary>
        /// Cached name for the 'remove_point' method.
        /// </summary>
        public static readonly StringName RemovePoint = "remove_point";
        /// <summary>
        /// Cached name for the 'has_point' method.
        /// </summary>
        public static readonly StringName HasPoint = "has_point";
        /// <summary>
        /// Cached name for the 'get_point_connections' method.
        /// </summary>
        public static readonly StringName GetPointConnections = "get_point_connections";
        /// <summary>
        /// Cached name for the 'get_point_ids' method.
        /// </summary>
        public static readonly StringName GetPointIds = "get_point_ids";
        /// <summary>
        /// Cached name for the 'set_neighbor_filter_enabled' method.
        /// </summary>
        public static readonly StringName SetNeighborFilterEnabled = "set_neighbor_filter_enabled";
        /// <summary>
        /// Cached name for the 'is_neighbor_filter_enabled' method.
        /// </summary>
        public static readonly StringName IsNeighborFilterEnabled = "is_neighbor_filter_enabled";
        /// <summary>
        /// Cached name for the 'set_point_disabled' method.
        /// </summary>
        public static readonly StringName SetPointDisabled = "set_point_disabled";
        /// <summary>
        /// Cached name for the 'is_point_disabled' method.
        /// </summary>
        public static readonly StringName IsPointDisabled = "is_point_disabled";
        /// <summary>
        /// Cached name for the 'connect_points' method.
        /// </summary>
        public static readonly StringName ConnectPoints = "connect_points";
        /// <summary>
        /// Cached name for the 'disconnect_points' method.
        /// </summary>
        public static readonly StringName DisconnectPoints = "disconnect_points";
        /// <summary>
        /// Cached name for the 'are_points_connected' method.
        /// </summary>
        public static readonly StringName ArePointsConnected = "are_points_connected";
        /// <summary>
        /// Cached name for the 'get_point_count' method.
        /// </summary>
        public static readonly StringName GetPointCount = "get_point_count";
        /// <summary>
        /// Cached name for the 'get_point_capacity' method.
        /// </summary>
        public static readonly StringName GetPointCapacity = "get_point_capacity";
        /// <summary>
        /// Cached name for the 'reserve_space' method.
        /// </summary>
        public static readonly StringName ReserveSpace = "reserve_space";
        /// <summary>
        /// Cached name for the 'clear' method.
        /// </summary>
        public static readonly StringName Clear = "clear";
        /// <summary>
        /// Cached name for the 'get_closest_point' method.
        /// </summary>
        public static readonly StringName GetClosestPoint = "get_closest_point";
        /// <summary>
        /// Cached name for the 'get_closest_position_in_segment' method.
        /// </summary>
        public static readonly StringName GetClosestPositionInSegment = "get_closest_position_in_segment";
        /// <summary>
        /// Cached name for the 'get_point_path' method.
        /// </summary>
        public static readonly StringName GetPointPath = "get_point_path";
        /// <summary>
        /// Cached name for the 'get_id_path' method.
        /// </summary>
        public static readonly StringName GetIdPath = "get_id_path";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : RefCounted.SignalName
    {
    }
}
