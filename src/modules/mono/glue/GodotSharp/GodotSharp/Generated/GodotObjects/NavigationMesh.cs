namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A navigation mesh is a collection of polygons that define which areas of an environment are traversable to aid agents in pathfinding through complicated spaces.</para>
/// </summary>
public partial class NavigationMesh : Resource
{
    public enum SamplePartitionTypeEnum : long
    {
        /// <summary>
        /// <para>Watershed partitioning. Generally the best choice if you precompute the navigation mesh, use this if you have large open areas.</para>
        /// </summary>
        Watershed = 0,
        /// <summary>
        /// <para>Monotone partitioning. Use this if you want fast navigation mesh generation.</para>
        /// </summary>
        Monotone = 1,
        /// <summary>
        /// <para>Layer partitioning. Good choice to use for tiled navigation mesh with medium and small sized tiles.</para>
        /// </summary>
        Layers = 2,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.NavigationMesh.SamplePartitionTypeEnum"/> enum.</para>
        /// </summary>
        Max = 3
    }

    public enum ParsedGeometryType : long
    {
        /// <summary>
        /// <para>Parses mesh instances as geometry. This includes <see cref="Godot.MeshInstance3D"/>, <see cref="Godot.CsgShape3D"/>, and <see cref="Godot.GridMap"/> nodes.</para>
        /// </summary>
        MeshInstances = 0,
        /// <summary>
        /// <para>Parses <see cref="Godot.StaticBody3D"/> colliders as geometry. The collider should be in any of the layers specified by <see cref="Godot.NavigationMesh.GeometryCollisionMask"/>.</para>
        /// </summary>
        StaticColliders = 1,
        /// <summary>
        /// <para>Both <see cref="Godot.NavigationMesh.ParsedGeometryType.MeshInstances"/> and <see cref="Godot.NavigationMesh.ParsedGeometryType.StaticColliders"/>.</para>
        /// </summary>
        Both = 2,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.NavigationMesh.ParsedGeometryType"/> enum.</para>
        /// </summary>
        Max = 3
    }

    public enum SourceGeometryMode : long
    {
        /// <summary>
        /// <para>Scans the child nodes of the root node recursively for geometry.</para>
        /// </summary>
        RootNodeChildren = 0,
        /// <summary>
        /// <para>Scans nodes in a group and their child nodes recursively for geometry. The group is specified by <see cref="Godot.NavigationMesh.GeometrySourceGroupName"/>.</para>
        /// </summary>
        GroupsWithChildren = 1,
        /// <summary>
        /// <para>Uses nodes in a group for geometry. The group is specified by <see cref="Godot.NavigationMesh.GeometrySourceGroupName"/>.</para>
        /// </summary>
        GroupsExplicit = 2,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.NavigationMesh.SourceGeometryMode"/> enum.</para>
        /// </summary>
        Max = 3
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public Vector3[] Vertices
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
    public Godot.Collections.Array Polygons
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

    /// <summary>
    /// <para>Partitioning algorithm for creating the navigation mesh polys.</para>
    /// </summary>
    public NavigationMesh.SamplePartitionTypeEnum SamplePartitionType
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
    public NavigationMesh.ParsedGeometryType GeometryParsedGeometryType
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
    /// <para>Only used when <see cref="Godot.NavigationMesh.GeometryParsedGeometryType"/> is <see cref="Godot.NavigationMesh.ParsedGeometryType.StaticColliders"/> or <see cref="Godot.NavigationMesh.ParsedGeometryType.Both"/>.</para>
    /// </summary>
    public uint GeometryCollisionMask
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
    /// <para>The source of the geometry used when baking.</para>
    /// </summary>
    public NavigationMesh.SourceGeometryMode GeometrySourceGeometryMode
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
    /// <para>The name of the group to scan for geometry.</para>
    /// <para>Only used when <see cref="Godot.NavigationMesh.GeometrySourceGeometryMode"/> is <see cref="Godot.NavigationMesh.SourceGeometryMode.GroupsWithChildren"/> or <see cref="Godot.NavigationMesh.SourceGeometryMode.GroupsExplicit"/>.</para>
    /// </summary>
    public StringName GeometrySourceGroupName
    {
        get
        {
            return GetSourceGroupName();
        }
        set
        {
            SetSourceGroupName(value);
        }
    }

    /// <summary>
    /// <para>The cell size used to rasterize the navigation mesh vertices on the XZ plane. Must match with the cell size on the navigation map.</para>
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
    /// <para>The cell height used to rasterize the navigation mesh vertices on the Y axis. Must match with the cell height on the navigation map.</para>
    /// </summary>
    public float CellHeight
    {
        get
        {
            return GetCellHeight();
        }
        set
        {
            SetCellHeight(value);
        }
    }

    /// <summary>
    /// <para>The size of the non-navigable border around the bake bounding area.</para>
    /// <para>In conjunction with the <see cref="Godot.NavigationMesh.FilterBakingAabb"/> and a <see cref="Godot.NavigationMesh.EdgeMaxError"/> value at <c>1.0</c> or below the border size can be used to bake tile aligned navigation meshes without the tile edges being shrunk by <see cref="Godot.NavigationMesh.AgentRadius"/>.</para>
    /// <para><b>Note:</b> If this value is not <c>0.0</c>, it will be rounded up to the nearest multiple of <see cref="Godot.NavigationMesh.CellSize"/> during baking.</para>
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
    /// <para>The minimum floor to ceiling height that will still allow the floor area to be considered walkable.</para>
    /// <para><b>Note:</b> While baking, this value will be rounded up to the nearest multiple of <see cref="Godot.NavigationMesh.CellHeight"/>.</para>
    /// </summary>
    public float AgentHeight
    {
        get
        {
            return GetAgentHeight();
        }
        set
        {
            SetAgentHeight(value);
        }
    }

    /// <summary>
    /// <para>The distance to erode/shrink the walkable area of the heightfield away from obstructions.</para>
    /// <para><b>Note:</b> While baking, this value will be rounded up to the nearest multiple of <see cref="Godot.NavigationMesh.CellSize"/>.</para>
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
    /// <para>The minimum ledge height that is considered to still be traversable.</para>
    /// <para><b>Note:</b> While baking, this value will be rounded down to the nearest multiple of <see cref="Godot.NavigationMesh.CellHeight"/>.</para>
    /// </summary>
    public float AgentMaxClimb
    {
        get
        {
            return GetAgentMaxClimb();
        }
        set
        {
            SetAgentMaxClimb(value);
        }
    }

    /// <summary>
    /// <para>The maximum slope that is considered walkable, in degrees.</para>
    /// </summary>
    public float AgentMaxSlope
    {
        get
        {
            return GetAgentMaxSlope();
        }
        set
        {
            SetAgentMaxSlope(value);
        }
    }

    /// <summary>
    /// <para>The minimum size of a region for it to be created.</para>
    /// <para><b>Note:</b> This value will be squared to calculate the minimum number of cells allowed to form isolated island areas. For example, a value of 8 will set the number of cells to 64.</para>
    /// </summary>
    public float RegionMinSize
    {
        get
        {
            return GetRegionMinSize();
        }
        set
        {
            SetRegionMinSize(value);
        }
    }

    /// <summary>
    /// <para>Any regions with a size smaller than this will be merged with larger regions if possible.</para>
    /// <para><b>Note:</b> This value will be squared to calculate the number of cells. For example, a value of 20 will set the number of cells to 400.</para>
    /// </summary>
    public float RegionMergeSize
    {
        get
        {
            return GetRegionMergeSize();
        }
        set
        {
            SetRegionMergeSize(value);
        }
    }

    /// <summary>
    /// <para>The maximum allowed length for contour edges along the border of the mesh. A value of <c>0.0</c> disables this feature.</para>
    /// <para><b>Note:</b> While baking, this value will be rounded up to the nearest multiple of <see cref="Godot.NavigationMesh.CellSize"/>.</para>
    /// </summary>
    public float EdgeMaxLength
    {
        get
        {
            return GetEdgeMaxLength();
        }
        set
        {
            SetEdgeMaxLength(value);
        }
    }

    /// <summary>
    /// <para>The maximum distance a simplified contour's border edges should deviate the original raw contour.</para>
    /// </summary>
    public float EdgeMaxError
    {
        get
        {
            return GetEdgeMaxError();
        }
        set
        {
            SetEdgeMaxError(value);
        }
    }

    /// <summary>
    /// <para>The maximum number of vertices allowed for polygons generated during the contour to polygon conversion process.</para>
    /// </summary>
    public float VerticesPerPolygon
    {
        get
        {
            return GetVerticesPerPolygon();
        }
        set
        {
            SetVerticesPerPolygon(value);
        }
    }

    /// <summary>
    /// <para>The sampling distance to use when generating the detail mesh, in cell unit.</para>
    /// </summary>
    public float DetailSampleDistance
    {
        get
        {
            return GetDetailSampleDistance();
        }
        set
        {
            SetDetailSampleDistance(value);
        }
    }

    /// <summary>
    /// <para>The maximum distance the detail mesh surface should deviate from heightfield, in cell unit.</para>
    /// </summary>
    public float DetailSampleMaxError
    {
        get
        {
            return GetDetailSampleMaxError();
        }
        set
        {
            SetDetailSampleMaxError(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, marks non-walkable spans as walkable if their maximum is within <see cref="Godot.NavigationMesh.AgentMaxClimb"/> of a walkable neighbor.</para>
    /// </summary>
    public bool FilterLowHangingObstacles
    {
        get
        {
            return GetFilterLowHangingObstacles();
        }
        set
        {
            SetFilterLowHangingObstacles(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, marks spans that are ledges as non-walkable.</para>
    /// </summary>
    public bool FilterLedgeSpans
    {
        get
        {
            return GetFilterLedgeSpans();
        }
        set
        {
            SetFilterLedgeSpans(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, marks walkable spans as not walkable if the clearance above the span is less than <see cref="Godot.NavigationMesh.AgentHeight"/>.</para>
    /// </summary>
    public bool FilterWalkableLowHeightSpans
    {
        get
        {
            return GetFilterWalkableLowHeightSpans();
        }
        set
        {
            SetFilterWalkableLowHeightSpans(value);
        }
    }

    /// <summary>
    /// <para>If the baking <see cref="Godot.Aabb"/> has a volume the navigation mesh baking will be restricted to its enclosing area.</para>
    /// </summary>
    public Aabb FilterBakingAabb
    {
        get
        {
            return GetFilterBakingAabb();
        }
        set
        {
            SetFilterBakingAabb(value);
        }
    }

    /// <summary>
    /// <para>The position offset applied to the <see cref="Godot.NavigationMesh.FilterBakingAabb"/> <see cref="Godot.Aabb"/>.</para>
    /// </summary>
    public Vector3 FilterBakingAabbOffset
    {
        get
        {
            return GetFilterBakingAabbOffset();
        }
        set
        {
            SetFilterBakingAabbOffset(value);
        }
    }

    private static readonly System.Type CachedType = typeof(NavigationMesh);

    private static readonly StringName NativeName = "NavigationMesh";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public NavigationMesh() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal NavigationMesh(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal NavigationMesh(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSamplePartitionType, 2472437533ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSamplePartitionType(NavigationMesh.SamplePartitionTypeEnum samplePartitionType)
    {
        NativeCalls.godot_icall_1_38(MethodBind0, GodotObject.GetPtr(this), (int)samplePartitionType);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSamplePartitionType, 833513918ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public NavigationMesh.SamplePartitionTypeEnum GetSamplePartitionType()
    {
        return (NavigationMesh.SamplePartitionTypeEnum)NativeCalls.godot_icall_0_39(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetParsedGeometryType, 3064713163ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetParsedGeometryType(NavigationMesh.ParsedGeometryType geometryType)
    {
        NativeCalls.godot_icall_1_38(MethodBind2, GodotObject.GetPtr(this), (int)geometryType);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetParsedGeometryType, 3928011953ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public NavigationMesh.ParsedGeometryType GetParsedGeometryType()
    {
        return (NavigationMesh.ParsedGeometryType)NativeCalls.godot_icall_0_39(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCollisionMask, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCollisionMask(uint mask)
    {
        NativeCalls.godot_icall_1_208(MethodBind4, GodotObject.GetPtr(this), mask);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCollisionMask, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public uint GetCollisionMask()
    {
        return NativeCalls.godot_icall_0_209(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCollisionMaskValue, 300928843ul);

    /// <summary>
    /// <para>Based on <paramref name="value"/>, enables or disables the specified layer in the <see cref="Godot.NavigationMesh.GeometryCollisionMask"/>, given a <paramref name="layerNumber"/> between 1 and 32.</para>
    /// </summary>
    public void SetCollisionMaskValue(int layerNumber, bool value)
    {
        NativeCalls.godot_icall_2_61(MethodBind6, GodotObject.GetPtr(this), layerNumber, value.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCollisionMaskValue, 1116898809ul);

    /// <summary>
    /// <para>Returns whether or not the specified layer of the <see cref="Godot.NavigationMesh.GeometryCollisionMask"/> is enabled, given a <paramref name="layerNumber"/> between 1 and 32.</para>
    /// </summary>
    public bool GetCollisionMaskValue(int layerNumber)
    {
        return NativeCalls.godot_icall_1_62(MethodBind7, GodotObject.GetPtr(this), layerNumber).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSourceGeometryMode, 2700825194ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSourceGeometryMode(NavigationMesh.SourceGeometryMode mask)
    {
        NativeCalls.godot_icall_1_38(MethodBind8, GodotObject.GetPtr(this), (int)mask);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSourceGeometryMode, 2770484141ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public NavigationMesh.SourceGeometryMode GetSourceGeometryMode()
    {
        return (NavigationMesh.SourceGeometryMode)NativeCalls.godot_icall_0_39(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSourceGroupName, 3304788590ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSourceGroupName(StringName mask)
    {
        NativeCalls.godot_icall_1_64(MethodBind10, GodotObject.GetPtr(this), (godot_string_name)(mask?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSourceGroupName, 2002593661ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public StringName GetSourceGroupName()
    {
        return NativeCalls.godot_icall_0_65(MethodBind11, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCellSize, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCellSize(float cellSize)
    {
        NativeCalls.godot_icall_1_67(MethodBind12, GodotObject.GetPtr(this), cellSize);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCellSize, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetCellSize()
    {
        return NativeCalls.godot_icall_0_68(MethodBind13, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCellHeight, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCellHeight(float cellHeight)
    {
        NativeCalls.godot_icall_1_67(MethodBind14, GodotObject.GetPtr(this), cellHeight);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCellHeight, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetCellHeight()
    {
        return NativeCalls.godot_icall_0_68(MethodBind15, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBorderSize, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetBorderSize(float borderSize)
    {
        NativeCalls.godot_icall_1_67(MethodBind16, GodotObject.GetPtr(this), borderSize);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBorderSize, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetBorderSize()
    {
        return NativeCalls.godot_icall_0_68(MethodBind17, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAgentHeight, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAgentHeight(float agentHeight)
    {
        NativeCalls.godot_icall_1_67(MethodBind18, GodotObject.GetPtr(this), agentHeight);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAgentHeight, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetAgentHeight()
    {
        return NativeCalls.godot_icall_0_68(MethodBind19, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAgentRadius, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAgentRadius(float agentRadius)
    {
        NativeCalls.godot_icall_1_67(MethodBind20, GodotObject.GetPtr(this), agentRadius);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAgentRadius, 191475506ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetAgentRadius()
    {
        return NativeCalls.godot_icall_0_68(MethodBind21, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAgentMaxClimb, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAgentMaxClimb(float agentMaxClimb)
    {
        NativeCalls.godot_icall_1_67(MethodBind22, GodotObject.GetPtr(this), agentMaxClimb);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAgentMaxClimb, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetAgentMaxClimb()
    {
        return NativeCalls.godot_icall_0_68(MethodBind23, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAgentMaxSlope, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAgentMaxSlope(float agentMaxSlope)
    {
        NativeCalls.godot_icall_1_67(MethodBind24, GodotObject.GetPtr(this), agentMaxSlope);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAgentMaxSlope, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetAgentMaxSlope()
    {
        return NativeCalls.godot_icall_0_68(MethodBind25, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRegionMinSize, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetRegionMinSize(float regionMinSize)
    {
        NativeCalls.godot_icall_1_67(MethodBind26, GodotObject.GetPtr(this), regionMinSize);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRegionMinSize, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetRegionMinSize()
    {
        return NativeCalls.godot_icall_0_68(MethodBind27, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRegionMergeSize, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetRegionMergeSize(float regionMergeSize)
    {
        NativeCalls.godot_icall_1_67(MethodBind28, GodotObject.GetPtr(this), regionMergeSize);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRegionMergeSize, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetRegionMergeSize()
    {
        return NativeCalls.godot_icall_0_68(MethodBind29, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEdgeMaxLength, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEdgeMaxLength(float edgeMaxLength)
    {
        NativeCalls.godot_icall_1_67(MethodBind30, GodotObject.GetPtr(this), edgeMaxLength);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEdgeMaxLength, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetEdgeMaxLength()
    {
        return NativeCalls.godot_icall_0_68(MethodBind31, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind32 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEdgeMaxError, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEdgeMaxError(float edgeMaxError)
    {
        NativeCalls.godot_icall_1_67(MethodBind32, GodotObject.GetPtr(this), edgeMaxError);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind33 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEdgeMaxError, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetEdgeMaxError()
    {
        return NativeCalls.godot_icall_0_68(MethodBind33, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind34 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVerticesPerPolygon, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetVerticesPerPolygon(float verticesPerPolygon)
    {
        NativeCalls.godot_icall_1_67(MethodBind34, GodotObject.GetPtr(this), verticesPerPolygon);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind35 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVerticesPerPolygon, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetVerticesPerPolygon()
    {
        return NativeCalls.godot_icall_0_68(MethodBind35, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind36 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDetailSampleDistance, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDetailSampleDistance(float detailSampleDist)
    {
        NativeCalls.godot_icall_1_67(MethodBind36, GodotObject.GetPtr(this), detailSampleDist);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind37 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDetailSampleDistance, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetDetailSampleDistance()
    {
        return NativeCalls.godot_icall_0_68(MethodBind37, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind38 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDetailSampleMaxError, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDetailSampleMaxError(float detailSampleMaxError)
    {
        NativeCalls.godot_icall_1_67(MethodBind38, GodotObject.GetPtr(this), detailSampleMaxError);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind39 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDetailSampleMaxError, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetDetailSampleMaxError()
    {
        return NativeCalls.godot_icall_0_68(MethodBind39, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind40 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFilterLowHangingObstacles, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFilterLowHangingObstacles(bool filterLowHangingObstacles)
    {
        NativeCalls.godot_icall_1_14(MethodBind40, GodotObject.GetPtr(this), filterLowHangingObstacles.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind41 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFilterLowHangingObstacles, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetFilterLowHangingObstacles()
    {
        return NativeCalls.godot_icall_0_15(MethodBind41, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind42 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFilterLedgeSpans, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFilterLedgeSpans(bool filterLedgeSpans)
    {
        NativeCalls.godot_icall_1_14(MethodBind42, GodotObject.GetPtr(this), filterLedgeSpans.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind43 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFilterLedgeSpans, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetFilterLedgeSpans()
    {
        return NativeCalls.godot_icall_0_15(MethodBind43, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind44 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFilterWalkableLowHeightSpans, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFilterWalkableLowHeightSpans(bool filterWalkableLowHeightSpans)
    {
        NativeCalls.godot_icall_1_14(MethodBind44, GodotObject.GetPtr(this), filterWalkableLowHeightSpans.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind45 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFilterWalkableLowHeightSpans, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetFilterWalkableLowHeightSpans()
    {
        return NativeCalls.godot_icall_0_15(MethodBind45, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind46 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFilterBakingAabb, 259215842ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetFilterBakingAabb(Aabb bakingAabb)
    {
        NativeCalls.godot_icall_1_183(MethodBind46, GodotObject.GetPtr(this), &bakingAabb);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind47 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFilterBakingAabb, 1068685055ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Aabb GetFilterBakingAabb()
    {
        return NativeCalls.godot_icall_0_184(MethodBind47, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind48 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFilterBakingAabbOffset, 3460891852ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetFilterBakingAabbOffset(Vector3 bakingAabbOffset)
    {
        NativeCalls.godot_icall_1_177(MethodBind48, GodotObject.GetPtr(this), &bakingAabbOffset);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind49 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFilterBakingAabbOffset, 3360562783ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector3 GetFilterBakingAabbOffset()
    {
        return NativeCalls.godot_icall_0_125(MethodBind49, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind50 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVertices, 334873810ul);

    /// <summary>
    /// <para>Sets the vertices that can be then indexed to create polygons with the <see cref="Godot.NavigationMesh.AddPolygon(int[])"/> method.</para>
    /// </summary>
    public void SetVertices(Vector3[] vertices)
    {
        NativeCalls.godot_icall_1_187(MethodBind50, GodotObject.GetPtr(this), vertices);
    }

    /// <summary>
    /// <para>Sets the vertices that can be then indexed to create polygons with the <see cref="Godot.NavigationMesh.AddPolygon(int[])"/> method.</para>
    /// </summary>
    public void SetVertices(ReadOnlySpan<Vector3> vertices)
    {
        NativeCalls.godot_icall_1_187(MethodBind50, GodotObject.GetPtr(this), vertices);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind51 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVertices, 497664490ul);

    /// <summary>
    /// <para>Returns a <see cref="Godot.Vector3"/>[] containing all the vertices being used to create the polygons.</para>
    /// </summary>
    public Vector3[] GetVertices()
    {
        return NativeCalls.godot_icall_0_228(MethodBind51, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind52 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddPolygon, 3614634198ul);

    /// <summary>
    /// <para>Adds a polygon using the indices of the vertices you get when calling <see cref="Godot.NavigationMesh.GetVertices()"/>.</para>
    /// </summary>
    public void AddPolygon(int[] polygon)
    {
        NativeCalls.godot_icall_1_150(MethodBind52, GodotObject.GetPtr(this), polygon);
    }

    /// <summary>
    /// <para>Adds a polygon using the indices of the vertices you get when calling <see cref="Godot.NavigationMesh.GetVertices()"/>.</para>
    /// </summary>
    public void AddPolygon(ReadOnlySpan<int> polygon)
    {
        NativeCalls.godot_icall_1_150(MethodBind52, GodotObject.GetPtr(this), polygon);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind53 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPolygonCount, 3905245786ul);

    /// <summary>
    /// <para>Returns the number of polygons in the navigation mesh.</para>
    /// </summary>
    public int GetPolygonCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind53, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind54 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPolygon, 3668444399ul);

    /// <summary>
    /// <para>Returns a <see cref="int"/>[] containing the indices of the vertices of a created polygon.</para>
    /// </summary>
    public int[] GetPolygon(int idx)
    {
        return NativeCalls.godot_icall_1_797(MethodBind54, GodotObject.GetPtr(this), idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind55 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ClearPolygons, 3218959716ul);

    /// <summary>
    /// <para>Clears the array of polygons, but it doesn't clear the array of vertices.</para>
    /// </summary>
    public void ClearPolygons()
    {
        NativeCalls.godot_icall_0_3(MethodBind55, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind56 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CreateFromMesh, 194775623ul);

    /// <summary>
    /// <para>Initializes the navigation mesh by setting the vertices and indices according to a <see cref="Godot.Mesh"/>.</para>
    /// <para><b>Note:</b> The given <paramref name="mesh"/> must be of type <see cref="Godot.Mesh.PrimitiveType.Triangles"/> and have an index array.</para>
    /// </summary>
    public void CreateFromMesh(Mesh mesh)
    {
        NativeCalls.godot_icall_1_56(MethodBind56, GodotObject.GetPtr(this), GodotObject.GetPtr(mesh));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind57 = ClassDB_get_method_with_compatibility(NativeName, MethodName._SetPolygons, 381264803ul);

    internal void _SetPolygons(Godot.Collections.Array polygons)
    {
        NativeCalls.godot_icall_1_138(MethodBind57, GodotObject.GetPtr(this), (godot_array)(polygons ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind58 = ClassDB_get_method_with_compatibility(NativeName, MethodName._GetPolygons, 3995934104ul);

    internal Godot.Collections.Array _GetPolygons()
    {
        return NativeCalls.godot_icall_0_120(MethodBind58, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind59 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Clear, 3218959716ul);

    /// <summary>
    /// <para>Clears the internal arrays for vertices and polygon indices.</para>
    /// </summary>
    public void Clear()
    {
        NativeCalls.godot_icall_0_3(MethodBind59, GodotObject.GetPtr(this));
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
        /// Cached name for the 'sample_partition_type' property.
        /// </summary>
        public static readonly StringName SamplePartitionType = "sample_partition_type";
        /// <summary>
        /// Cached name for the 'geometry_parsed_geometry_type' property.
        /// </summary>
        public static readonly StringName GeometryParsedGeometryType = "geometry_parsed_geometry_type";
        /// <summary>
        /// Cached name for the 'geometry_collision_mask' property.
        /// </summary>
        public static readonly StringName GeometryCollisionMask = "geometry_collision_mask";
        /// <summary>
        /// Cached name for the 'geometry_source_geometry_mode' property.
        /// </summary>
        public static readonly StringName GeometrySourceGeometryMode = "geometry_source_geometry_mode";
        /// <summary>
        /// Cached name for the 'geometry_source_group_name' property.
        /// </summary>
        public static readonly StringName GeometrySourceGroupName = "geometry_source_group_name";
        /// <summary>
        /// Cached name for the 'cell_size' property.
        /// </summary>
        public static readonly StringName CellSize = "cell_size";
        /// <summary>
        /// Cached name for the 'cell_height' property.
        /// </summary>
        public static readonly StringName CellHeight = "cell_height";
        /// <summary>
        /// Cached name for the 'border_size' property.
        /// </summary>
        public static readonly StringName BorderSize = "border_size";
        /// <summary>
        /// Cached name for the 'agent_height' property.
        /// </summary>
        public static readonly StringName AgentHeight = "agent_height";
        /// <summary>
        /// Cached name for the 'agent_radius' property.
        /// </summary>
        public static readonly StringName AgentRadius = "agent_radius";
        /// <summary>
        /// Cached name for the 'agent_max_climb' property.
        /// </summary>
        public static readonly StringName AgentMaxClimb = "agent_max_climb";
        /// <summary>
        /// Cached name for the 'agent_max_slope' property.
        /// </summary>
        public static readonly StringName AgentMaxSlope = "agent_max_slope";
        /// <summary>
        /// Cached name for the 'region_min_size' property.
        /// </summary>
        public static readonly StringName RegionMinSize = "region_min_size";
        /// <summary>
        /// Cached name for the 'region_merge_size' property.
        /// </summary>
        public static readonly StringName RegionMergeSize = "region_merge_size";
        /// <summary>
        /// Cached name for the 'edge_max_length' property.
        /// </summary>
        public static readonly StringName EdgeMaxLength = "edge_max_length";
        /// <summary>
        /// Cached name for the 'edge_max_error' property.
        /// </summary>
        public static readonly StringName EdgeMaxError = "edge_max_error";
        /// <summary>
        /// Cached name for the 'vertices_per_polygon' property.
        /// </summary>
        public static readonly StringName VerticesPerPolygon = "vertices_per_polygon";
        /// <summary>
        /// Cached name for the 'detail_sample_distance' property.
        /// </summary>
        public static readonly StringName DetailSampleDistance = "detail_sample_distance";
        /// <summary>
        /// Cached name for the 'detail_sample_max_error' property.
        /// </summary>
        public static readonly StringName DetailSampleMaxError = "detail_sample_max_error";
        /// <summary>
        /// Cached name for the 'filter_low_hanging_obstacles' property.
        /// </summary>
        public static readonly StringName FilterLowHangingObstacles = "filter_low_hanging_obstacles";
        /// <summary>
        /// Cached name for the 'filter_ledge_spans' property.
        /// </summary>
        public static readonly StringName FilterLedgeSpans = "filter_ledge_spans";
        /// <summary>
        /// Cached name for the 'filter_walkable_low_height_spans' property.
        /// </summary>
        public static readonly StringName FilterWalkableLowHeightSpans = "filter_walkable_low_height_spans";
        /// <summary>
        /// Cached name for the 'filter_baking_aabb' property.
        /// </summary>
        public static readonly StringName FilterBakingAabb = "filter_baking_aabb";
        /// <summary>
        /// Cached name for the 'filter_baking_aabb_offset' property.
        /// </summary>
        public static readonly StringName FilterBakingAabbOffset = "filter_baking_aabb_offset";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Resource.MethodName
    {
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
        /// Cached name for the 'set_source_geometry_mode' method.
        /// </summary>
        public static readonly StringName SetSourceGeometryMode = "set_source_geometry_mode";
        /// <summary>
        /// Cached name for the 'get_source_geometry_mode' method.
        /// </summary>
        public static readonly StringName GetSourceGeometryMode = "get_source_geometry_mode";
        /// <summary>
        /// Cached name for the 'set_source_group_name' method.
        /// </summary>
        public static readonly StringName SetSourceGroupName = "set_source_group_name";
        /// <summary>
        /// Cached name for the 'get_source_group_name' method.
        /// </summary>
        public static readonly StringName GetSourceGroupName = "get_source_group_name";
        /// <summary>
        /// Cached name for the 'set_cell_size' method.
        /// </summary>
        public static readonly StringName SetCellSize = "set_cell_size";
        /// <summary>
        /// Cached name for the 'get_cell_size' method.
        /// </summary>
        public static readonly StringName GetCellSize = "get_cell_size";
        /// <summary>
        /// Cached name for the 'set_cell_height' method.
        /// </summary>
        public static readonly StringName SetCellHeight = "set_cell_height";
        /// <summary>
        /// Cached name for the 'get_cell_height' method.
        /// </summary>
        public static readonly StringName GetCellHeight = "get_cell_height";
        /// <summary>
        /// Cached name for the 'set_border_size' method.
        /// </summary>
        public static readonly StringName SetBorderSize = "set_border_size";
        /// <summary>
        /// Cached name for the 'get_border_size' method.
        /// </summary>
        public static readonly StringName GetBorderSize = "get_border_size";
        /// <summary>
        /// Cached name for the 'set_agent_height' method.
        /// </summary>
        public static readonly StringName SetAgentHeight = "set_agent_height";
        /// <summary>
        /// Cached name for the 'get_agent_height' method.
        /// </summary>
        public static readonly StringName GetAgentHeight = "get_agent_height";
        /// <summary>
        /// Cached name for the 'set_agent_radius' method.
        /// </summary>
        public static readonly StringName SetAgentRadius = "set_agent_radius";
        /// <summary>
        /// Cached name for the 'get_agent_radius' method.
        /// </summary>
        public static readonly StringName GetAgentRadius = "get_agent_radius";
        /// <summary>
        /// Cached name for the 'set_agent_max_climb' method.
        /// </summary>
        public static readonly StringName SetAgentMaxClimb = "set_agent_max_climb";
        /// <summary>
        /// Cached name for the 'get_agent_max_climb' method.
        /// </summary>
        public static readonly StringName GetAgentMaxClimb = "get_agent_max_climb";
        /// <summary>
        /// Cached name for the 'set_agent_max_slope' method.
        /// </summary>
        public static readonly StringName SetAgentMaxSlope = "set_agent_max_slope";
        /// <summary>
        /// Cached name for the 'get_agent_max_slope' method.
        /// </summary>
        public static readonly StringName GetAgentMaxSlope = "get_agent_max_slope";
        /// <summary>
        /// Cached name for the 'set_region_min_size' method.
        /// </summary>
        public static readonly StringName SetRegionMinSize = "set_region_min_size";
        /// <summary>
        /// Cached name for the 'get_region_min_size' method.
        /// </summary>
        public static readonly StringName GetRegionMinSize = "get_region_min_size";
        /// <summary>
        /// Cached name for the 'set_region_merge_size' method.
        /// </summary>
        public static readonly StringName SetRegionMergeSize = "set_region_merge_size";
        /// <summary>
        /// Cached name for the 'get_region_merge_size' method.
        /// </summary>
        public static readonly StringName GetRegionMergeSize = "get_region_merge_size";
        /// <summary>
        /// Cached name for the 'set_edge_max_length' method.
        /// </summary>
        public static readonly StringName SetEdgeMaxLength = "set_edge_max_length";
        /// <summary>
        /// Cached name for the 'get_edge_max_length' method.
        /// </summary>
        public static readonly StringName GetEdgeMaxLength = "get_edge_max_length";
        /// <summary>
        /// Cached name for the 'set_edge_max_error' method.
        /// </summary>
        public static readonly StringName SetEdgeMaxError = "set_edge_max_error";
        /// <summary>
        /// Cached name for the 'get_edge_max_error' method.
        /// </summary>
        public static readonly StringName GetEdgeMaxError = "get_edge_max_error";
        /// <summary>
        /// Cached name for the 'set_vertices_per_polygon' method.
        /// </summary>
        public static readonly StringName SetVerticesPerPolygon = "set_vertices_per_polygon";
        /// <summary>
        /// Cached name for the 'get_vertices_per_polygon' method.
        /// </summary>
        public static readonly StringName GetVerticesPerPolygon = "get_vertices_per_polygon";
        /// <summary>
        /// Cached name for the 'set_detail_sample_distance' method.
        /// </summary>
        public static readonly StringName SetDetailSampleDistance = "set_detail_sample_distance";
        /// <summary>
        /// Cached name for the 'get_detail_sample_distance' method.
        /// </summary>
        public static readonly StringName GetDetailSampleDistance = "get_detail_sample_distance";
        /// <summary>
        /// Cached name for the 'set_detail_sample_max_error' method.
        /// </summary>
        public static readonly StringName SetDetailSampleMaxError = "set_detail_sample_max_error";
        /// <summary>
        /// Cached name for the 'get_detail_sample_max_error' method.
        /// </summary>
        public static readonly StringName GetDetailSampleMaxError = "get_detail_sample_max_error";
        /// <summary>
        /// Cached name for the 'set_filter_low_hanging_obstacles' method.
        /// </summary>
        public static readonly StringName SetFilterLowHangingObstacles = "set_filter_low_hanging_obstacles";
        /// <summary>
        /// Cached name for the 'get_filter_low_hanging_obstacles' method.
        /// </summary>
        public static readonly StringName GetFilterLowHangingObstacles = "get_filter_low_hanging_obstacles";
        /// <summary>
        /// Cached name for the 'set_filter_ledge_spans' method.
        /// </summary>
        public static readonly StringName SetFilterLedgeSpans = "set_filter_ledge_spans";
        /// <summary>
        /// Cached name for the 'get_filter_ledge_spans' method.
        /// </summary>
        public static readonly StringName GetFilterLedgeSpans = "get_filter_ledge_spans";
        /// <summary>
        /// Cached name for the 'set_filter_walkable_low_height_spans' method.
        /// </summary>
        public static readonly StringName SetFilterWalkableLowHeightSpans = "set_filter_walkable_low_height_spans";
        /// <summary>
        /// Cached name for the 'get_filter_walkable_low_height_spans' method.
        /// </summary>
        public static readonly StringName GetFilterWalkableLowHeightSpans = "get_filter_walkable_low_height_spans";
        /// <summary>
        /// Cached name for the 'set_filter_baking_aabb' method.
        /// </summary>
        public static readonly StringName SetFilterBakingAabb = "set_filter_baking_aabb";
        /// <summary>
        /// Cached name for the 'get_filter_baking_aabb' method.
        /// </summary>
        public static readonly StringName GetFilterBakingAabb = "get_filter_baking_aabb";
        /// <summary>
        /// Cached name for the 'set_filter_baking_aabb_offset' method.
        /// </summary>
        public static readonly StringName SetFilterBakingAabbOffset = "set_filter_baking_aabb_offset";
        /// <summary>
        /// Cached name for the 'get_filter_baking_aabb_offset' method.
        /// </summary>
        public static readonly StringName GetFilterBakingAabbOffset = "get_filter_baking_aabb_offset";
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
        /// Cached name for the 'create_from_mesh' method.
        /// </summary>
        public static readonly StringName CreateFromMesh = "create_from_mesh";
        /// <summary>
        /// Cached name for the '_set_polygons' method.
        /// </summary>
        public static readonly StringName _SetPolygons = "_set_polygons";
        /// <summary>
        /// Cached name for the '_get_polygons' method.
        /// </summary>
        public static readonly StringName _GetPolygons = "_get_polygons";
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
