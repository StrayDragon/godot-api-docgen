namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para><see cref="Godot.AStarGrid2D"/> is a variant of <see cref="Godot.AStar2D"/> that is specialized for partial 2D grids. It is simpler to use because it doesn't require you to manually create points and connect them together. This class also supports multiple types of heuristics, modes for diagonal movement, and a jumping mode to speed up calculations.</para>
/// <para>To use <see cref="Godot.AStarGrid2D"/>, you only need to set the <see cref="Godot.AStarGrid2D.Region"/> of the grid, optionally set the <see cref="Godot.AStarGrid2D.CellSize"/>, and then call the <see cref="Godot.AStarGrid2D.Update()"/> method:</para>
/// <para><code>
/// AStarGrid2D astarGrid = new AStarGrid2D();
/// astarGrid.Region = new Rect2I(0, 0, 32, 32);
/// astarGrid.CellSize = new Vector2I(16, 16);
/// astarGrid.Update();
/// GD.Print(astarGrid.GetIdPath(Vector2I.Zero, new Vector2I(3, 4))); // Prints [(0, 0), (1, 1), (2, 2), (3, 3), (3, 4)]
/// GD.Print(astarGrid.GetPointPath(Vector2I.Zero, new Vector2I(3, 4))); // Prints [(0, 0), (16, 16), (32, 32), (48, 48), (48, 64)]
/// </code></para>
/// <para>To remove a point from the pathfinding grid, it must be set as "solid" with <see cref="Godot.AStarGrid2D.SetPointSolid(Vector2I, bool)"/>.</para>
/// </summary>
public partial class AStarGrid2D : RefCounted
{
    public enum Heuristic : long
    {
        /// <summary>
        /// <para>The <a href="https://en.wikipedia.org/wiki/Euclidean_distance">Euclidean heuristic</a> to be used for the pathfinding using the following formula:</para>
        /// <para><code>
        /// dx = abs(to_id.x - from_id.x)
        /// dy = abs(to_id.y - from_id.y)
        /// result = sqrt(dx * dx + dy * dy)
        /// </code></para>
        /// <para><b>Note:</b> This is also the internal heuristic used in <see cref="Godot.AStar3D"/> and <see cref="Godot.AStar2D"/> by default (with the inclusion of possible z-axis coordinate).</para>
        /// </summary>
        Euclidean = 0,
        /// <summary>
        /// <para>The <a href="https://en.wikipedia.org/wiki/Taxicab_geometry">Manhattan heuristic</a> to be used for the pathfinding using the following formula:</para>
        /// <para><code>
        /// dx = abs(to_id.x - from_id.x)
        /// dy = abs(to_id.y - from_id.y)
        /// result = dx + dy
        /// </code></para>
        /// <para><b>Note:</b> This heuristic is intended to be used with 4-side orthogonal movements, provided by setting the <see cref="Godot.AStarGrid2D.DiagonalMode"/> to <see cref="Godot.AStarGrid2D.DiagonalModeEnum.Never"/>.</para>
        /// </summary>
        Manhattan = 1,
        /// <summary>
        /// <para>The Octile heuristic to be used for the pathfinding using the following formula:</para>
        /// <para><code>
        /// dx = abs(to_id.x - from_id.x)
        /// dy = abs(to_id.y - from_id.y)
        /// f = sqrt(2) - 1
        /// result = (dx &lt; dy) ? f * dx + dy : f * dy + dx;
        /// </code></para>
        /// </summary>
        Octile = 2,
        /// <summary>
        /// <para>The <a href="https://en.wikipedia.org/wiki/Chebyshev_distance">Chebyshev heuristic</a> to be used for the pathfinding using the following formula:</para>
        /// <para><code>
        /// dx = abs(to_id.x - from_id.x)
        /// dy = abs(to_id.y - from_id.y)
        /// result = max(dx, dy)
        /// </code></para>
        /// </summary>
        Chebyshev = 3,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.AStarGrid2D.Heuristic"/> enum.</para>
        /// </summary>
        Max = 4
    }

    public enum DiagonalModeEnum : long
    {
        /// <summary>
        /// <para>The pathfinding algorithm will ignore solid neighbors around the target cell and allow passing using diagonals.</para>
        /// </summary>
        Always = 0,
        /// <summary>
        /// <para>The pathfinding algorithm will ignore all diagonals and the way will be always orthogonal.</para>
        /// </summary>
        Never = 1,
        /// <summary>
        /// <para>The pathfinding algorithm will avoid using diagonals if at least two obstacles have been placed around the neighboring cells of the specific path segment.</para>
        /// </summary>
        AtLeastOneWalkable = 2,
        /// <summary>
        /// <para>The pathfinding algorithm will avoid using diagonals if any obstacle has been placed around the neighboring cells of the specific path segment.</para>
        /// </summary>
        OnlyIfNoObstacles = 3,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.AStarGrid2D.DiagonalModeEnum"/> enum.</para>
        /// </summary>
        Max = 4
    }

    public enum CellShapeEnum : long
    {
        /// <summary>
        /// <para>Rectangular cell shape.</para>
        /// </summary>
        Square = 0,
        /// <summary>
        /// <para>Diamond cell shape (for isometric look). Cell coordinates layout where the horizontal axis goes up-right, and the vertical one goes down-right.</para>
        /// </summary>
        IsometricRight = 1,
        /// <summary>
        /// <para>Diamond cell shape (for isometric look). Cell coordinates layout where the horizontal axis goes down-right, and the vertical one goes down-left.</para>
        /// </summary>
        IsometricDown = 2,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.AStarGrid2D.CellShapeEnum"/> enum.</para>
        /// </summary>
        Max = 3
    }

    /// <summary>
    /// <para>The region of grid cells available for pathfinding. If changed, <see cref="Godot.AStarGrid2D.Update()"/> needs to be called before finding the next path.</para>
    /// </summary>
    public Rect2I Region
    {
        get
        {
            return GetRegion();
        }
        set
        {
            SetRegion(value);
        }
    }

    /// <summary>
    /// <para>The size of the grid (number of cells of size <see cref="Godot.AStarGrid2D.CellSize"/> on each axis). If changed, <see cref="Godot.AStarGrid2D.Update()"/> needs to be called before finding the next path.</para>
    /// </summary>
    [Obsolete("Use 'Godot.AStarGrid2D.Region' instead.")]
    public Vector2I Size
    {
        get
        {
            return GetSize();
        }
        set
        {
            SetSize(value);
        }
    }

    /// <summary>
    /// <para>The offset of the grid which will be applied to calculate the resulting point position returned by <see cref="Godot.AStarGrid2D.GetPointPath(Vector2I, Vector2I, bool)"/>. If changed, <see cref="Godot.AStarGrid2D.Update()"/> needs to be called before finding the next path.</para>
    /// </summary>
    public Vector2 Offset
    {
        get
        {
            return GetOffset();
        }
        set
        {
            SetOffset(value);
        }
    }

    /// <summary>
    /// <para>The size of the point cell which will be applied to calculate the resulting point position returned by <see cref="Godot.AStarGrid2D.GetPointPath(Vector2I, Vector2I, bool)"/>. If changed, <see cref="Godot.AStarGrid2D.Update()"/> needs to be called before finding the next path.</para>
    /// </summary>
    public Vector2 CellSize
    {
        get
        {
            return GetCellSize();
        }
        set
        {
            SetCellSize(value);
        }
    }

    /// <summary>
    /// <para>The cell shape. Affects how the positions are placed in the grid. If changed, <see cref="Godot.AStarGrid2D.Update()"/> needs to be called before finding the next path.</para>
    /// </summary>
    public AStarGrid2D.CellShapeEnum CellShape
    {
        get
        {
            return GetCellShape();
        }
        set
        {
            SetCellShape(value);
        }
    }

    /// <summary>
    /// <para>Enables or disables jumping to skip up the intermediate points and speeds up the searching algorithm.</para>
    /// <para><b>Note:</b> Currently, toggling it on disables the consideration of weight scaling in pathfinding.</para>
    /// </summary>
    public bool JumpingEnabled
    {
        get
        {
            return IsJumpingEnabled();
        }
        set
        {
            SetJumpingEnabled(value);
        }
    }

    /// <summary>
    /// <para>The default <see cref="Godot.AStarGrid2D.Heuristic"/> which will be used to calculate the cost between two points if <see cref="Godot.AStarGrid2D._ComputeCost(Vector2I, Vector2I)"/> was not overridden.</para>
    /// </summary>
    public AStarGrid2D.Heuristic DefaultComputeHeuristic
    {
        get
        {
            return GetDefaultComputeHeuristic();
        }
        set
        {
            SetDefaultComputeHeuristic(value);
        }
    }

    /// <summary>
    /// <para>The default <see cref="Godot.AStarGrid2D.Heuristic"/> which will be used to calculate the cost between the point and the end point if <see cref="Godot.AStarGrid2D._EstimateCost(Vector2I, Vector2I)"/> was not overridden.</para>
    /// </summary>
    public AStarGrid2D.Heuristic DefaultEstimateHeuristic
    {
        get
        {
            return GetDefaultEstimateHeuristic();
        }
        set
        {
            SetDefaultEstimateHeuristic(value);
        }
    }

    /// <summary>
    /// <para>A specific <see cref="Godot.AStarGrid2D.DiagonalModeEnum"/> mode which will force the path to avoid or accept the specified diagonals.</para>
    /// </summary>
    public AStarGrid2D.DiagonalModeEnum DiagonalMode
    {
        get
        {
            return GetDiagonalMode();
        }
        set
        {
            SetDiagonalMode(value);
        }
    }

    private static readonly System.Type CachedType = typeof(AStarGrid2D);

    private static readonly StringName NativeName = "AStarGrid2D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public AStarGrid2D() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal AStarGrid2D(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal AStarGrid2D(bool memoryOwn) : base(memoryOwn) { }

    /// <summary>
    /// <para>Called when computing the cost between two connected points.</para>
    /// <para>Note that this function is hidden in the default <see cref="Godot.AStarGrid2D"/> class.</para>
    /// </summary>
    public virtual unsafe float _ComputeCost(Vector2I fromId, Vector2I toId)
    {
        return default;
    }

    /// <summary>
    /// <para>Called when estimating the cost between a point and the path's ending point.</para>
    /// <para>Note that this function is hidden in the default <see cref="Godot.AStarGrid2D"/> class.</para>
    /// </summary>
    public virtual unsafe float _EstimateCost(Vector2I fromId, Vector2I endId)
    {
        return default;
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRegion, 1763793166ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetRegion(Rect2I region)
    {
        NativeCalls.godot_icall_1_32(MethodBind0, GodotObject.GetPtr(this), &region);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRegion, 410525958ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Rect2I GetRegion()
    {
        return NativeCalls.godot_icall_0_33(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSize, 1130785943ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetSize(Vector2I size)
    {
        NativeCalls.godot_icall_1_34(MethodBind2, GodotObject.GetPtr(this), &size);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSize, 3690982128ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2I GetSize()
    {
        return NativeCalls.godot_icall_0_35(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetOffset, 743155724ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetOffset(Vector2 offset)
    {
        NativeCalls.godot_icall_1_36(MethodBind4, GodotObject.GetPtr(this), &offset);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOffset, 3341600327ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2 GetOffset()
    {
        return NativeCalls.godot_icall_0_37(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCellSize, 743155724ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetCellSize(Vector2 cellSize)
    {
        NativeCalls.godot_icall_1_36(MethodBind6, GodotObject.GetPtr(this), &cellSize);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCellSize, 3341600327ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2 GetCellSize()
    {
        return NativeCalls.godot_icall_0_37(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCellShape, 4130591146ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCellShape(AStarGrid2D.CellShapeEnum cellShape)
    {
        NativeCalls.godot_icall_1_38(MethodBind8, GodotObject.GetPtr(this), (int)cellShape);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCellShape, 3293463634ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public AStarGrid2D.CellShapeEnum GetCellShape()
    {
        return (AStarGrid2D.CellShapeEnum)NativeCalls.godot_icall_0_39(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsInBounds, 2522259332ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the <paramref name="x"/> and <paramref name="y"/> is a valid grid coordinate (id), i.e. if it is inside <see cref="Godot.AStarGrid2D.Region"/>. Equivalent to <c>region.has_point(Vector2i(x, y))</c>.</para>
    /// </summary>
    public bool IsInBounds(int x, int y)
    {
        return NativeCalls.godot_icall_2_40(MethodBind10, GodotObject.GetPtr(this), x, y).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsInBoundsv, 3900751641ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the <paramref name="id"/> vector is a valid grid coordinate, i.e. if it is inside <see cref="Godot.AStarGrid2D.Region"/>. Equivalent to <c>region.has_point(id)</c>.</para>
    /// </summary>
    public unsafe bool IsInBoundsv(Vector2I id)
    {
        return NativeCalls.godot_icall_1_41(MethodBind11, GodotObject.GetPtr(this), &id).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsDirty, 36873697ul);

    /// <summary>
    /// <para>Indicates that the grid parameters were changed and <see cref="Godot.AStarGrid2D.Update()"/> needs to be called.</para>
    /// </summary>
    public bool IsDirty()
    {
        return NativeCalls.godot_icall_0_15(MethodBind12, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Update, 3218959716ul);

    /// <summary>
    /// <para>Updates the internal state of the grid according to the parameters to prepare it to search the path. Needs to be called if parameters like <see cref="Godot.AStarGrid2D.Region"/>, <see cref="Godot.AStarGrid2D.CellSize"/> or <see cref="Godot.AStarGrid2D.Offset"/> are changed. <see cref="Godot.AStarGrid2D.IsDirty()"/> will return <see langword="true"/> if this is the case and this needs to be called.</para>
    /// <para><b>Note:</b> All point data (solidity and weight scale) will be cleared.</para>
    /// </summary>
    public void Update()
    {
        NativeCalls.godot_icall_0_3(MethodBind13, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetJumpingEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetJumpingEnabled(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind14, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsJumpingEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsJumpingEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind15, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDiagonalMode, 1017829798ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDiagonalMode(AStarGrid2D.DiagonalModeEnum mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind16, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDiagonalMode, 3129282674ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public AStarGrid2D.DiagonalModeEnum GetDiagonalMode()
    {
        return (AStarGrid2D.DiagonalModeEnum)NativeCalls.godot_icall_0_39(MethodBind17, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDefaultComputeHeuristic, 1044375519ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDefaultComputeHeuristic(AStarGrid2D.Heuristic heuristic)
    {
        NativeCalls.godot_icall_1_38(MethodBind18, GodotObject.GetPtr(this), (int)heuristic);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDefaultComputeHeuristic, 2074731422ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public AStarGrid2D.Heuristic GetDefaultComputeHeuristic()
    {
        return (AStarGrid2D.Heuristic)NativeCalls.godot_icall_0_39(MethodBind19, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDefaultEstimateHeuristic, 1044375519ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDefaultEstimateHeuristic(AStarGrid2D.Heuristic heuristic)
    {
        NativeCalls.godot_icall_1_38(MethodBind20, GodotObject.GetPtr(this), (int)heuristic);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDefaultEstimateHeuristic, 2074731422ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public AStarGrid2D.Heuristic GetDefaultEstimateHeuristic()
    {
        return (AStarGrid2D.Heuristic)NativeCalls.godot_icall_0_39(MethodBind21, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPointSolid, 1765703753ul);

    /// <summary>
    /// <para>Disables or enables the specified point for pathfinding. Useful for making an obstacle. By default, all points are enabled.</para>
    /// <para><b>Note:</b> Calling <see cref="Godot.AStarGrid2D.Update()"/> is not needed after the call of this function.</para>
    /// </summary>
    public unsafe void SetPointSolid(Vector2I id, bool solid = true)
    {
        NativeCalls.godot_icall_2_42(MethodBind22, GodotObject.GetPtr(this), &id, solid.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsPointSolid, 3900751641ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if a point is disabled for pathfinding. By default, all points are enabled.</para>
    /// </summary>
    public unsafe bool IsPointSolid(Vector2I id)
    {
        return NativeCalls.godot_icall_1_41(MethodBind23, GodotObject.GetPtr(this), &id).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPointWeightScale, 2262553149ul);

    /// <summary>
    /// <para>Sets the <paramref name="weightScale"/> for the point with the given <paramref name="id"/>. The <paramref name="weightScale"/> is multiplied by the result of <see cref="Godot.AStarGrid2D._ComputeCost(Vector2I, Vector2I)"/> when determining the overall cost of traveling across a segment from a neighboring point to this point.</para>
    /// <para><b>Note:</b> Calling <see cref="Godot.AStarGrid2D.Update()"/> is not needed after the call of this function.</para>
    /// </summary>
    public unsafe void SetPointWeightScale(Vector2I id, float weightScale)
    {
        NativeCalls.godot_icall_2_43(MethodBind24, GodotObject.GetPtr(this), &id, weightScale);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPointWeightScale, 719993801ul);

    /// <summary>
    /// <para>Returns the weight scale of the point associated with the given <paramref name="id"/>.</para>
    /// </summary>
    public unsafe float GetPointWeightScale(Vector2I id)
    {
        return NativeCalls.godot_icall_1_44(MethodBind25, GodotObject.GetPtr(this), &id);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FillSolidRegion, 2261970063ul);

    /// <summary>
    /// <para>Fills the given <paramref name="region"/> on the grid with the specified value for the solid flag.</para>
    /// <para><b>Note:</b> Calling <see cref="Godot.AStarGrid2D.Update()"/> is not needed after the call of this function.</para>
    /// </summary>
    public unsafe void FillSolidRegion(Rect2I region, bool solid = true)
    {
        NativeCalls.godot_icall_2_45(MethodBind26, GodotObject.GetPtr(this), &region, solid.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FillWeightScaleRegion, 2793244083ul);

    /// <summary>
    /// <para>Fills the given <paramref name="region"/> on the grid with the specified value for the weight scale.</para>
    /// <para><b>Note:</b> Calling <see cref="Godot.AStarGrid2D.Update()"/> is not needed after the call of this function.</para>
    /// </summary>
    public unsafe void FillWeightScaleRegion(Rect2I region, float weightScale)
    {
        NativeCalls.godot_icall_2_46(MethodBind27, GodotObject.GetPtr(this), &region, weightScale);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Clear, 3218959716ul);

    /// <summary>
    /// <para>Clears the grid and sets the <see cref="Godot.AStarGrid2D.Region"/> to <c>Rect2i(0, 0, 0, 0)</c>.</para>
    /// </summary>
    public void Clear()
    {
        NativeCalls.godot_icall_0_3(MethodBind28, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPointPosition, 108438297ul);

    /// <summary>
    /// <para>Returns the position of the point associated with the given <paramref name="id"/>.</para>
    /// </summary>
    public unsafe Vector2 GetPointPosition(Vector2I id)
    {
        return NativeCalls.godot_icall_1_47(MethodBind29, GodotObject.GetPtr(this), &id);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPointDataInRegion, 3893818462ul);

    /// <summary>
    /// <para>Returns an array of dictionaries with point data (<c>id</c>: <see cref="Godot.Vector2I"/>, <c>position</c>: <see cref="Godot.Vector2"/>, <c>solid</c>: <see cref="bool"/>, <c>weight_scale</c>: <see cref="float"/>) within a <paramref name="region"/>.</para>
    /// </summary>
    public unsafe Godot.Collections.Array<Godot.Collections.Dictionary> GetPointDataInRegion(Rect2I region)
    {
        return new Godot.Collections.Array<Godot.Collections.Dictionary>(NativeCalls.godot_icall_1_48(MethodBind30, GodotObject.GetPtr(this), &region));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPointPath, 1641925693ul);

    /// <summary>
    /// <para>Returns an array with the points that are in the path found by <see cref="Godot.AStarGrid2D"/> between the given points. The array is ordered from the starting point to the ending point of the path.</para>
    /// <para>If <paramref name="fromId"/> point is disabled, returns an empty array (even if <c>from_id == to_id</c>).</para>
    /// <para>If <paramref name="fromId"/> point is not disabled, there is no valid path to the target, and <paramref name="allowPartialPath"/> is <see langword="true"/>, returns a path to the point closest to the target that can be reached.</para>
    /// <para><b>Note:</b> This method is not thread-safe; it can only be used from a single <see cref="Godot.GodotThread"/> at a given time. Consider using <see cref="Godot.Mutex"/> to ensure exclusive access to one thread to avoid race conditions.</para>
    /// <para>Additionally, when <paramref name="allowPartialPath"/> is <see langword="true"/> and <paramref name="toId"/> is solid the search may take an unusually long time to finish.</para>
    /// </summary>
    public unsafe Vector2[] GetPointPath(Vector2I fromId, Vector2I toId, bool allowPartialPath = false)
    {
        return NativeCalls.godot_icall_3_49(MethodBind31, GodotObject.GetPtr(this), &fromId, &toId, allowPartialPath.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind32 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetIdPath, 1918132273ul);

    /// <summary>
    /// <para>Returns an array with the IDs of the points that form the path found by AStar2D between the given points. The array is ordered from the starting point to the ending point of the path.</para>
    /// <para>If <paramref name="fromId"/> point is disabled, returns an empty array (even if <c>from_id == to_id</c>).</para>
    /// <para>If <paramref name="fromId"/> point is not disabled, there is no valid path to the target, and <paramref name="allowPartialPath"/> is <see langword="true"/>, returns a path to the point closest to the target that can be reached.</para>
    /// <para><b>Note:</b> When <paramref name="allowPartialPath"/> is <see langword="true"/> and <paramref name="toId"/> is solid the search may take an unusually long time to finish.</para>
    /// </summary>
    public unsafe Godot.Collections.Array<Vector2I> GetIdPath(Vector2I fromId, Vector2I toId, bool allowPartialPath = false)
    {
        return new Godot.Collections.Array<Vector2I>(NativeCalls.godot_icall_3_50(MethodBind32, GodotObject.GetPtr(this), &fromId, &toId, allowPartialPath.ToGodotBool()));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind33 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPointPath, 690373547ul);

    /// <summary>
    /// <para>Returns an array with the points that are in the path found by <see cref="Godot.AStarGrid2D"/> between the given points. The array is ordered from the starting point to the ending point of the path.</para>
    /// <para>If <paramref name="fromId"/> point is disabled, returns an empty array (even if <c>from_id == to_id</c>).</para>
    /// <para>If <paramref name="fromId"/> point is not disabled, there is no valid path to the target, and <paramref name="allowPartialPath"/> is <see langword="true"/>, returns a path to the point closest to the target that can be reached.</para>
    /// <para><b>Note:</b> This method is not thread-safe; it can only be used from a single <see cref="Godot.GodotThread"/> at a given time. Consider using <see cref="Godot.Mutex"/> to ensure exclusive access to one thread to avoid race conditions.</para>
    /// <para>Additionally, when <paramref name="allowPartialPath"/> is <see langword="true"/> and <paramref name="toId"/> is solid the search may take an unusually long time to finish.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe Vector2[] GetPointPath(Vector2I fromId, Vector2I toId)
    {
        return NativeCalls.godot_icall_2_51(MethodBind33, GodotObject.GetPtr(this), &fromId, &toId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind34 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetIdPath, 1989391000ul);

    /// <summary>
    /// <para>Returns an array with the IDs of the points that form the path found by AStar2D between the given points. The array is ordered from the starting point to the ending point of the path.</para>
    /// <para>If <paramref name="fromId"/> point is disabled, returns an empty array (even if <c>from_id == to_id</c>).</para>
    /// <para>If <paramref name="fromId"/> point is not disabled, there is no valid path to the target, and <paramref name="allowPartialPath"/> is <see langword="true"/>, returns a path to the point closest to the target that can be reached.</para>
    /// <para><b>Note:</b> When <paramref name="allowPartialPath"/> is <see langword="true"/> and <paramref name="toId"/> is solid the search may take an unusually long time to finish.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe Godot.Collections.Array<Vector2I> GetIdPath(Vector2I fromId, Vector2I toId)
    {
        return new Godot.Collections.Array<Vector2I>(NativeCalls.godot_icall_2_52(MethodBind34, GodotObject.GetPtr(this), &fromId, &toId));
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__compute_cost = "_ComputeCost";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__estimate_cost = "_EstimateCost";

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
            var callRet = _ComputeCost(VariantUtils.ConvertTo<Vector2I>(args[0]), VariantUtils.ConvertTo<Vector2I>(args[1]));
            ret = VariantUtils.CreateFrom<float>(callRet);
            return true;
        }
        if ((method == MethodProxyName__estimate_cost || method == MethodName._EstimateCost) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__estimate_cost.NativeValue))
        {
            var callRet = _EstimateCost(VariantUtils.ConvertTo<Vector2I>(args[0]), VariantUtils.ConvertTo<Vector2I>(args[1]));
            ret = VariantUtils.CreateFrom<float>(callRet);
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
        /// Cached name for the 'region' property.
        /// </summary>
        public static readonly StringName Region = "region";
        /// <summary>
        /// Cached name for the 'size' property.
        /// </summary>
        public static readonly StringName Size = "size";
        /// <summary>
        /// Cached name for the 'offset' property.
        /// </summary>
        public static readonly StringName Offset = "offset";
        /// <summary>
        /// Cached name for the 'cell_size' property.
        /// </summary>
        public static readonly StringName CellSize = "cell_size";
        /// <summary>
        /// Cached name for the 'cell_shape' property.
        /// </summary>
        public static readonly StringName CellShape = "cell_shape";
        /// <summary>
        /// Cached name for the 'jumping_enabled' property.
        /// </summary>
        public static readonly StringName JumpingEnabled = "jumping_enabled";
        /// <summary>
        /// Cached name for the 'default_compute_heuristic' property.
        /// </summary>
        public static readonly StringName DefaultComputeHeuristic = "default_compute_heuristic";
        /// <summary>
        /// Cached name for the 'default_estimate_heuristic' property.
        /// </summary>
        public static readonly StringName DefaultEstimateHeuristic = "default_estimate_heuristic";
        /// <summary>
        /// Cached name for the 'diagonal_mode' property.
        /// </summary>
        public static readonly StringName DiagonalMode = "diagonal_mode";
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
        /// Cached name for the 'set_region' method.
        /// </summary>
        public static readonly StringName SetRegion = "set_region";
        /// <summary>
        /// Cached name for the 'get_region' method.
        /// </summary>
        public static readonly StringName GetRegion = "get_region";
        /// <summary>
        /// Cached name for the 'set_size' method.
        /// </summary>
        public static readonly StringName SetSize = "set_size";
        /// <summary>
        /// Cached name for the 'get_size' method.
        /// </summary>
        public static readonly StringName GetSize = "get_size";
        /// <summary>
        /// Cached name for the 'set_offset' method.
        /// </summary>
        public static readonly StringName SetOffset = "set_offset";
        /// <summary>
        /// Cached name for the 'get_offset' method.
        /// </summary>
        public static readonly StringName GetOffset = "get_offset";
        /// <summary>
        /// Cached name for the 'set_cell_size' method.
        /// </summary>
        public static readonly StringName SetCellSize = "set_cell_size";
        /// <summary>
        /// Cached name for the 'get_cell_size' method.
        /// </summary>
        public static readonly StringName GetCellSize = "get_cell_size";
        /// <summary>
        /// Cached name for the 'set_cell_shape' method.
        /// </summary>
        public static readonly StringName SetCellShape = "set_cell_shape";
        /// <summary>
        /// Cached name for the 'get_cell_shape' method.
        /// </summary>
        public static readonly StringName GetCellShape = "get_cell_shape";
        /// <summary>
        /// Cached name for the 'is_in_bounds' method.
        /// </summary>
        public static readonly StringName IsInBounds = "is_in_bounds";
        /// <summary>
        /// Cached name for the 'is_in_boundsv' method.
        /// </summary>
        public static readonly StringName IsInBoundsv = "is_in_boundsv";
        /// <summary>
        /// Cached name for the 'is_dirty' method.
        /// </summary>
        public static readonly StringName IsDirty = "is_dirty";
        /// <summary>
        /// Cached name for the 'update' method.
        /// </summary>
        public static readonly StringName Update = "update";
        /// <summary>
        /// Cached name for the 'set_jumping_enabled' method.
        /// </summary>
        public static readonly StringName SetJumpingEnabled = "set_jumping_enabled";
        /// <summary>
        /// Cached name for the 'is_jumping_enabled' method.
        /// </summary>
        public static readonly StringName IsJumpingEnabled = "is_jumping_enabled";
        /// <summary>
        /// Cached name for the 'set_diagonal_mode' method.
        /// </summary>
        public static readonly StringName SetDiagonalMode = "set_diagonal_mode";
        /// <summary>
        /// Cached name for the 'get_diagonal_mode' method.
        /// </summary>
        public static readonly StringName GetDiagonalMode = "get_diagonal_mode";
        /// <summary>
        /// Cached name for the 'set_default_compute_heuristic' method.
        /// </summary>
        public static readonly StringName SetDefaultComputeHeuristic = "set_default_compute_heuristic";
        /// <summary>
        /// Cached name for the 'get_default_compute_heuristic' method.
        /// </summary>
        public static readonly StringName GetDefaultComputeHeuristic = "get_default_compute_heuristic";
        /// <summary>
        /// Cached name for the 'set_default_estimate_heuristic' method.
        /// </summary>
        public static readonly StringName SetDefaultEstimateHeuristic = "set_default_estimate_heuristic";
        /// <summary>
        /// Cached name for the 'get_default_estimate_heuristic' method.
        /// </summary>
        public static readonly StringName GetDefaultEstimateHeuristic = "get_default_estimate_heuristic";
        /// <summary>
        /// Cached name for the 'set_point_solid' method.
        /// </summary>
        public static readonly StringName SetPointSolid = "set_point_solid";
        /// <summary>
        /// Cached name for the 'is_point_solid' method.
        /// </summary>
        public static readonly StringName IsPointSolid = "is_point_solid";
        /// <summary>
        /// Cached name for the 'set_point_weight_scale' method.
        /// </summary>
        public static readonly StringName SetPointWeightScale = "set_point_weight_scale";
        /// <summary>
        /// Cached name for the 'get_point_weight_scale' method.
        /// </summary>
        public static readonly StringName GetPointWeightScale = "get_point_weight_scale";
        /// <summary>
        /// Cached name for the 'fill_solid_region' method.
        /// </summary>
        public static readonly StringName FillSolidRegion = "fill_solid_region";
        /// <summary>
        /// Cached name for the 'fill_weight_scale_region' method.
        /// </summary>
        public static readonly StringName FillWeightScaleRegion = "fill_weight_scale_region";
        /// <summary>
        /// Cached name for the 'clear' method.
        /// </summary>
        public static readonly StringName Clear = "clear";
        /// <summary>
        /// Cached name for the 'get_point_position' method.
        /// </summary>
        public static readonly StringName GetPointPosition = "get_point_position";
        /// <summary>
        /// Cached name for the 'get_point_data_in_region' method.
        /// </summary>
        public static readonly StringName GetPointDataInRegion = "get_point_data_in_region";
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
