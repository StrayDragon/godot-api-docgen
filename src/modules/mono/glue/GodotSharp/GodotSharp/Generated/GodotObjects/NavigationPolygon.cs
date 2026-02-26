namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A navigation mesh can be created either by baking it with the help of the <see cref="Godot.NavigationServer2D"/>, or by adding vertices and convex polygon indices arrays manually.</para>
/// <para>To bake a navigation mesh at least one outline needs to be added that defines the outer bounds of the baked area.</para>
/// <para><code>
/// var newNavigationMesh = new NavigationPolygon();
/// Vector2[] boundingOutline = [new Vector2(0, 0), new Vector2(0, 50), new Vector2(50, 50), new Vector2(50, 0)];
/// newNavigationMesh.AddOutline(boundingOutline);
/// NavigationServer2D.BakeFromSourceGeometryData(newNavigationMesh, new NavigationMeshSourceGeometryData2D());
/// GetNode&lt;NavigationRegion2D&gt;("NavigationRegion2D").NavigationPolygon = newNavigationMesh;
/// </code></para>
/// <para>Adding vertices and polygon indices manually.</para>
/// <para><code>
/// var newNavigationMesh = new NavigationPolygon();
/// Vector2[] newVertices = [new Vector2(0, 0), new Vector2(0, 50), new Vector2(50, 50), new Vector2(50, 0)];
/// newNavigationMesh.Vertices = newVertices;
/// int[] newPolygonIndices = [0, 1, 2, 3];
/// newNavigationMesh.AddPolygon(newPolygonIndices);
/// GetNode&lt;NavigationRegion2D&gt;("NavigationRegion2D").NavigationPolygon = newNavigationMesh;
/// </code></para>
/// </summary>
public partial class NavigationPolygon : Resource
{
    public enum SamplePartitionTypeEnum : long
    {
        /// <summary>
        /// <para>Convex partitioning that results in a navigation mesh with convex polygons.</para>
        /// </summary>
        ConvexPartition = 0,
        /// <summary>
        /// <para>Triangulation partitioning that results in a navigation mesh with triangle polygons.</para>
        /// </summary>
        Triangulate = 1,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.NavigationPolygon.SamplePartitionTypeEnum"/> enum.</para>
        /// </summary>
        Max = 2
    }

    public enum ParsedGeometryTypeEnum : long
    {
        /// <summary>
        /// <para>Parses mesh instances as obstruction geometry. This includes <see cref="Godot.Polygon2D"/>, <see cref="Godot.MeshInstance2D"/>, <see cref="Godot.MultiMeshInstance2D"/>, and <see cref="Godot.TileMap"/> nodes.</para>
        /// <para>Meshes are only parsed when they use a 2D vertices surface format.</para>
        /// </summary>
        MeshInstances = 0,
        /// <summary>
        /// <para>Parses <see cref="Godot.StaticBody2D"/> and <see cref="Godot.TileMap"/> colliders as obstruction geometry. The collider should be in any of the layers specified by <see cref="Godot.NavigationPolygon.ParsedCollisionMask"/>.</para>
        /// </summary>
        StaticColliders = 1,
        /// <summary>
        /// <para>Both <see cref="Godot.NavigationPolygon.ParsedGeometryTypeEnum.MeshInstances"/> and <see cref="Godot.NavigationPolygon.ParsedGeometryTypeEnum.StaticColliders"/>.</para>
        /// </summary>
        Both = 2,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.NavigationPolygon.ParsedGeometryTypeEnum"/> enum.</para>
        /// </summary>
        Max = 3
    }

    public enum SourceGeometryModeEnum : long
    {
        /// <summary>
        /// <para>Scans the child nodes of the root node recursively for geometry.</para>
        /// </summary>
        RootNodeChildren = 0,
        /// <summary>
        /// <para>Scans nodes in a group and their child nodes recursively for geometry. The group is specified by <see cref="Godot.NavigationPolygon.SourceGeometryGroupName"/>.</para>
        /// </summary>
        GroupsWithChildren = 1,
        /// <summary>
        /// <para>Uses nodes in a group for geometry. The group is specified by <see cref="Godot.NavigationPolygon.SourceGeometryGroupName"/>.</para>
        /// </summary>
        GroupsExplicit = 2,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.NavigationPolygon.SourceGeometryModeEnum"/> enum.</para>
        /// </summary>
        Max = 3
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public Vector2[] Vertices
    {
        get
        {
            return GetVertices();
        }
        set
        {
            SetVertices(value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public Godot.Collections.Array<int[]> Polygons
    {
        get
        {
            return _GetPolygons();
        }
        set
        {
            _SetPolygons(value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public Godot.Collections.Array<Vector2[]> Outlines
    {
        get
        {
            return _GetOutlines();
        }
        set
        {
            _SetOutlines(value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    /// <summary>
    /// <para>Partitioning algorithm for creating the navigation mesh polys.</para>
    /// </summary>
    public NavigationPolygon.SamplePartitionTypeEnum SamplePartitionType
    {
        get
        {
            return GetSamplePartitionType();
        }
        set
        {
            SetSamplePartitionType(value);
        }
    }

    /// <summary>
    /// <para>Determines which type of nodes will be parsed as geometry.</para>
    /// </summary>
    public NavigationPolygon.ParsedGeometryTypeEnum ParsedGeometryType
    {
        get
        {
            return GetParsedGeometryType();
        }
        set
        {
            SetParsedGeometryType(value);
        }
    }

    /// <summary>
    /// <para>The physics layers to scan for static colliders.</para>
    /// <para>Only used when <see cref="Godot.NavigationPolygon.ParsedGeometryType"/> is <see cref="Godot.NavigationPolygon.ParsedGeometryTypeEnum.StaticColliders"/> or <see cref="Godot.NavigationPolygon.ParsedGeometryTypeEnum.Both"/>.</para>
    /// </summary>
    public uint ParsedCollisionMask
    {
        get
        {
            return GetParsedCollisionMask();
        }
        set
        {
            SetParsedCollisionMask(value);
        }
    }

    /// <summary>
    /// <para>The source of the geometry used when baking.</para>
    /// </summary>
    public NavigationPolygon.SourceGeometryModeEnum SourceGeometryMode
    {
        get
        {
            return GetSourceGeometryMode();
        }
        set
        {
            SetSourceGeometryMode(value);
        }
    }

    /// <summary>
    /// <para>The group name of nodes that should be parsed for baking source geometry.</para>
    /// <para>Only used when <see cref="Godot.NavigationPolygon.SourceGeometryMode"/> is <see cref="Godot.NavigationPolygon.SourceGeometryModeEnum.GroupsWithChildren"/> or <see cref="Godot.NavigationPolygon.SourceGeometryModeEnum.GroupsExplicit"/>.</para>
    /// </summary>
    public StringName SourceGeometryGroupName
    {
        get
        {
            return GetSourceGeometryGroupName();
        }
        set
        {
            SetSourceGeometryGroupName(value);
        }
    }

    /// <summary>
    /// <para>The cell size used to rasterize the navigation mesh vertices. Must match with the cell size on the navigation map.</para>
    /// </summary>
    public float CellSize
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
    /// <para>The size of the non-navigable border around the bake bounding area defined by the <see cref="Godot.NavigationPolygon.BakingRect"/> <see cref="Godot.Rect2"/>.</para>
    /// <para>In conjunction with the <see cref="Godot.NavigationPolygon.BakingRect"/> the border size can be used to bake tile aligned navigation meshes without the tile edges being shrunk by <see cref="Godot.NavigationPolygon.AgentRadius"/>.</para>
    /// </summary>
    public float BorderSize
    {
        get
        {
            return GetBorderSize();
        }
        set
        {
            SetBorderSize(value);
        }
    }

    /// <summary>
    /// <para>The distance to erode/shrink the walkable surface when baking the navigation mesh.</para>
    /// <para><b>Note:</b> The radius must be equal or higher than <c>0.0</c>. If the radius is <c>0.0</c>, it won't be possible to fix invalid outline overlaps and other precision errors during the baking process. As a result, some obstacles may be excluded incorrectly from the final navigation mesh, or may delete the navigation mesh's polygons.</para>
    /// </summary>
    public float AgentRadius
    {
        get
        {
            return GetAgentRadius();
        }
        set
        {
            SetAgentRadius(value);
        }
    }

    /// <summary>
    /// <para>If the baking <see cref="Godot.Rect2"/> has an area the navigation mesh baking will be restricted to its enclosing area.</para>
    /// </summary>
    public Rect2 BakingRect
    {
        get
        {
            return GetBakingRect();
        }
        set
        {
            SetBakingRect(value);
        }
    }

    /// <summary>
    /// <para>The position offset applied to the <see cref="Godot.NavigationPolygon.BakingRect"/> <see cref="Godot.Rect2"/>.</para>
    /// </summary>
    public Vector2 BakingRectOffset
    {
        get
        {
            return GetBakingRectOffset();
        }
        set
        {
            SetBakingRectOffset(value);
        }
    }

    private static readonly System.Type CachedType = typeof(NavigationPolygon);

    private static readonly StringName NativeName = "NavigationPolygon";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public NavigationPolygon() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal NavigationPolygon(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal NavigationPolygon(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVertices, 1509147220ul);

    /// <summary>
    /// <para>Sets the vertices that can be then indexed to create polygons with the <see cref="Godot.NavigationPolygon.AddPolygon(int[])"/> method.</para>
    /// </summary>
    public void SetVertices(Vector2[] vertices)
    {
        NativeCalls.godot_icall_1_224(MethodBind0, GodotObject.GetPtr(this), vertices);
    }

    /// <summary>
    /// <para>Sets the vertices that can be then indexed to create polygons with the <see cref="Godot.NavigationPolygon.AddPolygon(int[])"/> method.</para>
    /// </summary>
    public void SetVertices(ReadOnlySpan<Vector2> vertices)
    {
        NativeCalls.godot_icall_1_224(MethodBind0, GodotObject.GetPtr(this), vertices);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVertices, 2961356807ul);

    /// <summary>
    /// <para>Returns a <see cref="Godot.Vector2"/>[] containing all the vertices being used to create the polygons.</para>
    /// </summary>
    public Vector2[] GetVertices()
    {
        return NativeCalls.godot_icall_0_225(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddPolygon, 3614634198ul);

    /// <summary>
    /// <para>Adds a polygon using the indices of the vertices you get when calling <see cref="Godot.NavigationPolygon.GetVertices()"/>.</para>
    /// </summary>
    public void AddPolygon(int[] polygon)
    {
        NativeCalls.godot_icall_1_150(MethodBind2, GodotObject.GetPtr(this), polygon);
    }

    /// <summary>
    /// <para>Adds a polygon using the indices of the vertices you get when calling <see cref="Godot.NavigationPolygon.GetVertices()"/>.</para>
    /// </summary>
    public void AddPolygon(ReadOnlySpan<int> polygon)
    {
        NativeCalls.godot_icall_1_150(MethodBind2, GodotObject.GetPtr(this), polygon);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPolygonCount, 3905245786ul);

    /// <summary>
    /// <para>Returns the count of all polygons.</para>
    /// </summary>
    public int GetPolygonCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPolygon, 3668444399ul);

    /// <summary>
    /// <para>Returns a <see cref="int"/>[] containing the indices of the vertices of a created polygon.</para>
    /// </summary>
    public int[] GetPolygon(int idx)
    {
        return NativeCalls.godot_icall_1_797(MethodBind4, GodotObject.GetPtr(this), idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ClearPolygons, 3218959716ul);

    /// <summary>
    /// <para>Clears the array of polygons, but it doesn't clear the array of outlines and vertices.</para>
    /// </summary>
    public void ClearPolygons()
    {
        NativeCalls.godot_icall_0_3(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNavigationMesh, 330232164ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.NavigationMesh"/> resulting from this navigation polygon. This navigation mesh can be used to update the navigation mesh of a region with the <see cref="Godot.NavigationServer3D.RegionSetNavigationMesh(Rid, NavigationMesh)"/> API directly.</para>
    /// </summary>
    public NavigationMesh GetNavigationMesh()
    {
        return (NavigationMesh)NativeCalls.godot_icall_0_63(MethodBind6, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddOutline, 1509147220ul);

    /// <summary>
    /// <para>Appends a <see cref="Godot.Vector2"/>[] that contains the vertices of an outline to the internal array that contains all the outlines.</para>
    /// </summary>
    public void AddOutline(Vector2[] outline)
    {
        NativeCalls.godot_icall_1_224(MethodBind7, GodotObject.GetPtr(this), outline);
    }

    /// <summary>
    /// <para>Appends a <see cref="Godot.Vector2"/>[] that contains the vertices of an outline to the internal array that contains all the outlines.</para>
    /// </summary>
    public void AddOutline(ReadOnlySpan<Vector2> outline)
    {
        NativeCalls.godot_icall_1_224(MethodBind7, GodotObject.GetPtr(this), outline);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddOutlineAtIndex, 1569738947ul);

    /// <summary>
    /// <para>Adds a <see cref="Godot.Vector2"/>[] that contains the vertices of an outline to the internal array that contains all the outlines at a fixed position.</para>
    /// </summary>
    public void AddOutlineAtIndex(Vector2[] outline, int index)
    {
        NativeCalls.godot_icall_2_412(MethodBind8, GodotObject.GetPtr(this), outline, index);
    }

    /// <summary>
    /// <para>Adds a <see cref="Godot.Vector2"/>[] that contains the vertices of an outline to the internal array that contains all the outlines at a fixed position.</para>
    /// </summary>
    public void AddOutlineAtIndex(ReadOnlySpan<Vector2> outline, int index)
    {
        NativeCalls.godot_icall_2_412(MethodBind8, GodotObject.GetPtr(this), outline, index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOutlineCount, 3905245786ul);

    /// <summary>
    /// <para>Returns the number of outlines that were created in the editor or by script.</para>
    /// </summary>
    public int GetOutlineCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetOutline, 1201971903ul);

    /// <summary>
    /// <para>Changes an outline created in the editor or by script. You have to call <see cref="Godot.NavigationPolygon.MakePolygonsFromOutlines()"/> for the polygons to update.</para>
    /// </summary>
    public void SetOutline(int idx, Vector2[] outline)
    {
        NativeCalls.godot_icall_2_845(MethodBind10, GodotObject.GetPtr(this), idx, outline);
    }

    /// <summary>
    /// <para>Changes an outline created in the editor or by script. You have to call <see cref="Godot.NavigationPolygon.MakePolygonsFromOutlines()"/> for the polygons to update.</para>
    /// </summary>
    public void SetOutline(int idx, ReadOnlySpan<Vector2> outline)
    {
        NativeCalls.godot_icall_2_845(MethodBind10, GodotObject.GetPtr(this), idx, outline);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOutline, 3946907486ul);

    /// <summary>
    /// <para>Returns a <see cref="Godot.Vector2"/>[] containing the vertices of an outline that was created in the editor or by script.</para>
    /// </summary>
    public Vector2[] GetOutline(int idx)
    {
        return NativeCalls.godot_icall_1_190(MethodBind11, GodotObject.GetPtr(this), idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveOutline, 1286410249ul);

    /// <summary>
    /// <para>Removes an outline created in the editor or by script. You have to call <see cref="Godot.NavigationPolygon.MakePolygonsFromOutlines()"/> for the polygons to update.</para>
    /// </summary>
    public void RemoveOutline(int idx)
    {
        NativeCalls.godot_icall_1_38(MethodBind12, GodotObject.GetPtr(this), idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ClearOutlines, 3218959716ul);

    /// <summary>
    /// <para>Clears the array of the outlines, but it doesn't clear the vertices and the polygons that were created by them.</para>
    /// </summary>
    public void ClearOutlines()
    {
        NativeCalls.godot_icall_0_3(MethodBind13, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MakePolygonsFromOutlines, 3218959716ul);

    /// <summary>
    /// <para>Creates polygons from the outlines added in the editor or by script.</para>
    /// </summary>
    [Obsolete("Use 'Godot.NavigationServer2D.ParseSourceGeometryData(NavigationPolygon, NavigationMeshSourceGeometryData2D, Node, Callable)' and 'Godot.NavigationServer2D.BakeFromSourceGeometryData(NavigationPolygon, NavigationMeshSourceGeometryData2D, Callable)' instead.")]
    public void MakePolygonsFromOutlines()
    {
        NativeCalls.godot_icall_0_3(MethodBind14, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName._SetPolygons, 381264803ul);

    internal void _SetPolygons(Godot.Collections.Array<int[]> polygons)
    {
        NativeCalls.godot_icall_1_138(MethodBind15, GodotObject.GetPtr(this), (godot_array)(polygons ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName._GetPolygons, 3995934104ul);

    internal Godot.Collections.Array<int[]> _GetPolygons()
    {
        return new Godot.Collections.Array<int[]>(NativeCalls.godot_icall_0_120(MethodBind16, GodotObject.GetPtr(this)));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName._SetOutlines, 381264803ul);

    internal void _SetOutlines(Godot.Collections.Array<Vector2[]> outlines)
    {
        NativeCalls.godot_icall_1_138(MethodBind17, GodotObject.GetPtr(this), (godot_array)(outlines ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName._GetOutlines, 3995934104ul);

    internal Godot.Collections.Array<Vector2[]> _GetOutlines()
    {
        return new Godot.Collections.Array<Vector2[]>(NativeCalls.godot_icall_0_120(MethodBind18, GodotObject.GetPtr(this)));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCellSize, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCellSize(float cellSize)
    {
        NativeCalls.godot_icall_1_67(MethodBind19, GodotObject.GetPtr(this), cellSize);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCellSize, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetCellSize()
    {
        return NativeCalls.godot_icall_0_68(MethodBind20, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBorderSize, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetBorderSize(float borderSize)
    {
        NativeCalls.godot_icall_1_67(MethodBind21, GodotObject.GetPtr(this), borderSize);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBorderSize, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetBorderSize()
    {
        return NativeCalls.godot_icall_0_68(MethodBind22, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSamplePartitionType, 2441478482ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSamplePartitionType(NavigationPolygon.SamplePartitionTypeEnum samplePartitionType)
    {
        NativeCalls.godot_icall_1_38(MethodBind23, GodotObject.GetPtr(this), (int)samplePartitionType);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSamplePartitionType, 3887422851ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public NavigationPolygon.SamplePartitionTypeEnum GetSamplePartitionType()
    {
        return (NavigationPolygon.SamplePartitionTypeEnum)NativeCalls.godot_icall_0_39(MethodBind24, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetParsedGeometryType, 2507971764ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetParsedGeometryType(NavigationPolygon.ParsedGeometryTypeEnum geometryType)
    {
        NativeCalls.godot_icall_1_38(MethodBind25, GodotObject.GetPtr(this), (int)geometryType);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetParsedGeometryType, 1073219508ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public NavigationPolygon.ParsedGeometryTypeEnum GetParsedGeometryType()
    {
        return (NavigationPolygon.ParsedGeometryTypeEnum)NativeCalls.godot_icall_0_39(MethodBind26, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetParsedCollisionMask, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetParsedCollisionMask(uint mask)
    {
        NativeCalls.godot_icall_1_208(MethodBind27, GodotObject.GetPtr(this), mask);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetParsedCollisionMask, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public uint GetParsedCollisionMask()
    {
        return NativeCalls.godot_icall_0_209(MethodBind28, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetParsedCollisionMaskValue, 300928843ul);

    /// <summary>
    /// <para>Based on <paramref name="value"/>, enables or disables the specified layer in the <see cref="Godot.NavigationPolygon.ParsedCollisionMask"/>, given a <paramref name="layerNumber"/> between 1 and 32.</para>
    /// </summary>
    public void SetParsedCollisionMaskValue(int layerNumber, bool value)
    {
        NativeCalls.godot_icall_2_61(MethodBind29, GodotObject.GetPtr(this), layerNumber, value.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetParsedCollisionMaskValue, 1116898809ul);

    /// <summary>
    /// <para>Returns whether or not the specified layer of the <see cref="Godot.NavigationPolygon.ParsedCollisionMask"/> is enabled, given a <paramref name="layerNumber"/> between 1 and 32.</para>
    /// </summary>
    public bool GetParsedCollisionMaskValue(int layerNumber)
    {
        return NativeCalls.godot_icall_1_62(MethodBind30, GodotObject.GetPtr(this), layerNumber).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSourceGeometryMode, 4002316705ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSourceGeometryMode(NavigationPolygon.SourceGeometryModeEnum geometryMode)
    {
        NativeCalls.godot_icall_1_38(MethodBind31, GodotObject.GetPtr(this), (int)geometryMode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind32 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSourceGeometryMode, 459686762ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public NavigationPolygon.SourceGeometryModeEnum GetSourceGeometryMode()
    {
        return (NavigationPolygon.SourceGeometryModeEnum)NativeCalls.godot_icall_0_39(MethodBind32, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind33 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSourceGeometryGroupName, 3304788590ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSourceGeometryGroupName(StringName groupName)
    {
        NativeCalls.godot_icall_1_64(MethodBind33, GodotObject.GetPtr(this), (godot_string_name)(groupName?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind34 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSourceGeometryGroupName, 2002593661ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public StringName GetSourceGeometryGroupName()
    {
        return NativeCalls.godot_icall_0_65(MethodBind34, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind35 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAgentRadius, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAgentRadius(float agentRadius)
    {
        NativeCalls.godot_icall_1_67(MethodBind35, GodotObject.GetPtr(this), agentRadius);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind36 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAgentRadius, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetAgentRadius()
    {
        return NativeCalls.godot_icall_0_68(MethodBind36, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind37 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBakingRect, 2046264180ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetBakingRect(Rect2 rect)
    {
        NativeCalls.godot_icall_1_188(MethodBind37, GodotObject.GetPtr(this), &rect);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind38 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBakingRect, 1639390495ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Rect2 GetBakingRect()
    {
        return NativeCalls.godot_icall_0_189(MethodBind38, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind39 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBakingRectOffset, 743155724ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetBakingRectOffset(Vector2 rectOffset)
    {
        NativeCalls.godot_icall_1_36(MethodBind39, GodotObject.GetPtr(this), &rectOffset);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind40 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBakingRectOffset, 3341600327ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2 GetBakingRectOffset()
    {
        return NativeCalls.godot_icall_0_37(MethodBind40, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind41 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Clear, 3218959716ul);

    /// <summary>
    /// <para>Clears the internal arrays for vertices and polygon indices.</para>
    /// </summary>
    public void Clear()
    {
        NativeCalls.godot_icall_0_3(MethodBind41, GodotObject.GetPtr(this));
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
    public new class PropertyName : Resource.PropertyName
    {
        /// <summary>
        /// Cached name for the 'vertices' property.
        /// </summary>
        public static readonly StringName Vertices = "vertices";
        /// <summary>
        /// Cached name for the 'polygons' property.
        /// </summary>
        public static readonly StringName Polygons = "polygons";
        /// <summary>
        /// Cached name for the 'outlines' property.
        /// </summary>
        public static readonly StringName Outlines = "outlines";
        /// <summary>
        /// Cached name for the 'sample_partition_type' property.
        /// </summary>
        public static readonly StringName SamplePartitionType = "sample_partition_type";
        /// <summary>
        /// Cached name for the 'parsed_geometry_type' property.
        /// </summary>
        public static readonly StringName ParsedGeometryType = "parsed_geometry_type";
        /// <summary>
        /// Cached name for the 'parsed_collision_mask' property.
        /// </summary>
        public static readonly StringName ParsedCollisionMask = "parsed_collision_mask";
        /// <summary>
        /// Cached name for the 'source_geometry_mode' property.
        /// </summary>
        public static readonly StringName SourceGeometryMode = "source_geometry_mode";
        /// <summary>
        /// Cached name for the 'source_geometry_group_name' property.
        /// </summary>
        public static readonly StringName SourceGeometryGroupName = "source_geometry_group_name";
        /// <summary>
        /// Cached name for the 'cell_size' property.
        /// </summary>
        public static readonly StringName CellSize = "cell_size";
        /// <summary>
        /// Cached name for the 'border_size' property.
        /// </summary>
        public static readonly StringName BorderSize = "border_size";
        /// <summary>
        /// Cached name for the 'agent_radius' property.
        /// </summary>
        public static readonly StringName AgentRadius = "agent_radius";
        /// <summary>
        /// Cached name for the 'baking_rect' property.
        /// </summary>
        public static readonly StringName BakingRect = "baking_rect";
        /// <summary>
        /// Cached name for the 'baking_rect_offset' property.
        /// </summary>
        public static readonly StringName BakingRectOffset = "baking_rect_offset";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Resource.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_vertices' method.
        /// </summary>
        public static readonly StringName SetVertices = "set_vertices";
        /// <summary>
        /// Cached name for the 'get_vertices' method.
        /// </summary>
        public static readonly StringName GetVertices = "get_vertices";
        /// <summary>
        /// Cached name for the 'add_polygon' method.
        /// </summary>
        public static readonly StringName AddPolygon = "add_polygon";
        /// <summary>
        /// Cached name for the 'get_polygon_count' method.
        /// </summary>
        public static readonly StringName GetPolygonCount = "get_polygon_count";
        /// <summary>
        /// Cached name for the 'get_polygon' method.
        /// </summary>
        public static readonly StringName GetPolygon = "get_polygon";
        /// <summary>
        /// Cached name for the 'clear_polygons' method.
        /// </summary>
        public static readonly StringName ClearPolygons = "clear_polygons";
        /// <summary>
        /// Cached name for the 'get_navigation_mesh' method.
        /// </summary>
        public static readonly StringName GetNavigationMesh = "get_navigation_mesh";
        /// <summary>
        /// Cached name for the 'add_outline' method.
        /// </summary>
        public static readonly StringName AddOutline = "add_outline";
        /// <summary>
        /// Cached name for the 'add_outline_at_index' method.
        /// </summary>
        public static readonly StringName AddOutlineAtIndex = "add_outline_at_index";
        /// <summary>
        /// Cached name for the 'get_outline_count' method.
        /// </summary>
        public static readonly StringName GetOutlineCount = "get_outline_count";
        /// <summary>
        /// Cached name for the 'set_outline' method.
        /// </summary>
        public static readonly StringName SetOutline = "set_outline";
        /// <summary>
        /// Cached name for the 'get_outline' method.
        /// </summary>
        public static readonly StringName GetOutline = "get_outline";
        /// <summary>
        /// Cached name for the 'remove_outline' method.
        /// </summary>
        public static readonly StringName RemoveOutline = "remove_outline";
        /// <summary>
        /// Cached name for the 'clear_outlines' method.
        /// </summary>
        public static readonly StringName ClearOutlines = "clear_outlines";
        /// <summary>
        /// Cached name for the 'make_polygons_from_outlines' method.
        /// </summary>
        public static readonly StringName MakePolygonsFromOutlines = "make_polygons_from_outlines";
        /// <summary>
        /// Cached name for the '_set_polygons' method.
        /// </summary>
        public static readonly StringName _SetPolygons = "_set_polygons";
        /// <summary>
        /// Cached name for the '_get_polygons' method.
        /// </summary>
        public static readonly StringName _GetPolygons = "_get_polygons";
        /// <summary>
        /// Cached name for the '_set_outlines' method.
        /// </summary>
        public static readonly StringName _SetOutlines = "_set_outlines";
        /// <summary>
        /// Cached name for the '_get_outlines' method.
        /// </summary>
        public static readonly StringName _GetOutlines = "_get_outlines";
        /// <summary>
        /// Cached name for the 'set_cell_size' method.
        /// </summary>
        public static readonly StringName SetCellSize = "set_cell_size";
        /// <summary>
        /// Cached name for the 'get_cell_size' method.
        /// </summary>
        public static readonly StringName GetCellSize = "get_cell_size";
        /// <summary>
        /// Cached name for the 'set_border_size' method.
        /// </summary>
        public static readonly StringName SetBorderSize = "set_border_size";
        /// <summary>
        /// Cached name for the 'get_border_size' method.
        /// </summary>
        public static readonly StringName GetBorderSize = "get_border_size";
        /// <summary>
        /// Cached name for the 'set_sample_partition_type' method.
        /// </summary>
        public static readonly StringName SetSamplePartitionType = "set_sample_partition_type";
        /// <summary>
        /// Cached name for the 'get_sample_partition_type' method.
        /// </summary>
        public static readonly StringName GetSamplePartitionType = "get_sample_partition_type";
        /// <summary>
        /// Cached name for the 'set_parsed_geometry_type' method.
        /// </summary>
        public static readonly StringName SetParsedGeometryType = "set_parsed_geometry_type";
        /// <summary>
        /// Cached name for the 'get_parsed_geometry_type' method.
        /// </summary>
        public static readonly StringName GetParsedGeometryType = "get_parsed_geometry_type";
        /// <summary>
        /// Cached name for the 'set_parsed_collision_mask' method.
        /// </summary>
        public static readonly StringName SetParsedCollisionMask = "set_parsed_collision_mask";
        /// <summary>
        /// Cached name for the 'get_parsed_collision_mask' method.
        /// </summary>
        public static readonly StringName GetParsedCollisionMask = "get_parsed_collision_mask";
        /// <summary>
        /// Cached name for the 'set_parsed_collision_mask_value' method.
        /// </summary>
        public static readonly StringName SetParsedCollisionMaskValue = "set_parsed_collision_mask_value";
        /// <summary>
        /// Cached name for the 'get_parsed_collision_mask_value' method.
        /// </summary>
        public static readonly StringName GetParsedCollisionMaskValue = "get_parsed_collision_mask_value";
        /// <summary>
        /// Cached name for the 'set_source_geometry_mode' method.
        /// </summary>
        public static readonly StringName SetSourceGeometryMode = "set_source_geometry_mode";
        /// <summary>
        /// Cached name for the 'get_source_geometry_mode' method.
        /// </summary>
        public static readonly StringName GetSourceGeometryMode = "get_source_geometry_mode";
        /// <summary>
        /// Cached name for the 'set_source_geometry_group_name' method.
        /// </summary>
        public static readonly StringName SetSourceGeometryGroupName = "set_source_geometry_group_name";
        /// <summary>
        /// Cached name for the 'get_source_geometry_group_name' method.
        /// </summary>
        public static readonly StringName GetSourceGeometryGroupName = "get_source_geometry_group_name";
        /// <summary>
        /// Cached name for the 'set_agent_radius' method.
        /// </summary>
        public static readonly StringName SetAgentRadius = "set_agent_radius";
        /// <summary>
        /// Cached name for the 'get_agent_radius' method.
        /// </summary>
        public static readonly StringName GetAgentRadius = "get_agent_radius";
        /// <summary>
        /// Cached name for the 'set_baking_rect' method.
        /// </summary>
        public static readonly StringName SetBakingRect = "set_baking_rect";
        /// <summary>
        /// Cached name for the 'get_baking_rect' method.
        /// </summary>
        public static readonly StringName GetBakingRect = "get_baking_rect";
        /// <summary>
        /// Cached name for the 'set_baking_rect_offset' method.
        /// </summary>
        public static readonly StringName SetBakingRectOffset = "set_baking_rect_offset";
        /// <summary>
        /// Cached name for the 'get_baking_rect_offset' method.
        /// </summary>
        public static readonly StringName GetBakingRectOffset = "get_baking_rect_offset";
        /// <summary>
        /// Cached name for the 'clear' method.
        /// </summary>
        public static readonly StringName Clear = "clear";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Resource.SignalName
    {
    }
}
