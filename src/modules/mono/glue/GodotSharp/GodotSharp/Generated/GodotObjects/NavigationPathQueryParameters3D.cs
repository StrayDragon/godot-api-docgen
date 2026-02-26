namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>By changing various properties of this object, such as the start and target position, you can configure path queries to the <see cref="Godot.NavigationServer3D"/>.</para>
/// </summary>
public partial class NavigationPathQueryParameters3D : RefCounted
{
    public enum PathfindingAlgorithmEnum : long
    {
        /// <summary>
        /// <para>The path query uses the default A* pathfinding algorithm.</para>
        /// </summary>
        Astar = 0
    }

    public enum PathPostProcessing : long
    {
        /// <summary>
        /// <para>Applies a funnel algorithm to the raw path corridor found by the pathfinding algorithm. This will result in the shortest path possible inside the path corridor. This postprocessing very much depends on the navigation mesh polygon layout and the created corridor. Especially tile- or gridbased layouts can face artificial corners with diagonal movement due to a jagged path corridor imposed by the cell shapes.</para>
        /// </summary>
        Corridorfunnel = 0,
        /// <summary>
        /// <para>Centers every path position in the middle of the traveled navigation mesh polygon edge. This creates better paths for tile- or gridbased layouts that restrict the movement to the cells center.</para>
        /// </summary>
        Edgecentered = 1,
        /// <summary>
        /// <para>Applies no postprocessing and returns the raw path corridor as found by the pathfinding algorithm.</para>
        /// </summary>
        None = 2
    }

    [System.Flags]
    public enum PathMetadataFlags : long
    {
        /// <summary>
        /// <para>Don't include any additional metadata about the returned path.</para>
        /// </summary>
        None = 0,
        /// <summary>
        /// <para>Include the type of navigation primitive (region or link) that each point of the path goes through.</para>
        /// </summary>
        Types = 1,
        /// <summary>
        /// <para>Include the <see cref="Godot.Rid"/>s of the regions and links that each point of the path goes through.</para>
        /// </summary>
        Rids = 2,
        /// <summary>
        /// <para>Include the <c>ObjectID</c>s of the <see cref="Godot.GodotObject"/>s which manage the regions and links each point of the path goes through.</para>
        /// </summary>
        Owners = 4,
        /// <summary>
        /// <para>Include all available metadata about the returned path.</para>
        /// </summary>
        All = 7
    }

    /// <summary>
    /// <para>The navigation map <see cref="Godot.Rid"/> used in the path query.</para>
    /// </summary>
    public Rid Map
    {
        get
        {
            return GetMap();
        }
        set
        {
            SetMap(value);
        }
    }

    /// <summary>
    /// <para>The pathfinding start position in global coordinates.</para>
    /// </summary>
    public Vector3 StartPosition
    {
        get
        {
            return GetStartPosition();
        }
        set
        {
            SetStartPosition(value);
        }
    }

    /// <summary>
    /// <para>The pathfinding target position in global coordinates.</para>
    /// </summary>
    public Vector3 TargetPosition
    {
        get
        {
            return GetTargetPosition();
        }
        set
        {
            SetTargetPosition(value);
        }
    }

    /// <summary>
    /// <para>The navigation layers the query will use (as a bitmask).</para>
    /// </summary>
    public uint NavigationLayers
    {
        get
        {
            return GetNavigationLayers();
        }
        set
        {
            SetNavigationLayers(value);
        }
    }

    /// <summary>
    /// <para>The pathfinding algorithm used in the path query.</para>
    /// </summary>
    public NavigationPathQueryParameters3D.PathfindingAlgorithmEnum PathfindingAlgorithm
    {
        get
        {
            return GetPathfindingAlgorithm();
        }
        set
        {
            SetPathfindingAlgorithm(value);
        }
    }

    /// <summary>
    /// <para>The path postprocessing applied to the raw path corridor found by the <see cref="Godot.NavigationPathQueryParameters3D.PathfindingAlgorithm"/>.</para>
    /// </summary>
    public NavigationPathQueryParameters3D.PathPostProcessing PathPostprocessing
    {
        get
        {
            return GetPathPostprocessing();
        }
        set
        {
            SetPathPostprocessing(value);
        }
    }

    /// <summary>
    /// <para>Additional information to include with the navigation path.</para>
    /// </summary>
    public NavigationPathQueryParameters3D.PathMetadataFlags MetadataFlags
    {
        get
        {
            return GetMetadataFlags();
        }
        set
        {
            SetMetadataFlags(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/> a simplified version of the path will be returned with less critical path points removed. The simplification amount is controlled by <see cref="Godot.NavigationPathQueryParameters3D.SimplifyEpsilon"/>. The simplification uses a variant of Ramer-Douglas-Peucker algorithm for curve point decimation.</para>
    /// <para>Path simplification can be helpful to mitigate various path following issues that can arise with certain agent types and script behaviors. E.g. "steering" agents or avoidance in "open fields".</para>
    /// </summary>
    public bool SimplifyPath
    {
        get
        {
            return GetSimplifyPath();
        }
        set
        {
            SetSimplifyPath(value);
        }
    }

    /// <summary>
    /// <para>The path simplification amount in worlds units.</para>
    /// </summary>
    public float SimplifyEpsilon
    {
        get
        {
            return GetSimplifyEpsilon();
        }
        set
        {
            SetSimplifyEpsilon(value);
        }
    }

    /// <summary>
    /// <para>The list of region <see cref="Godot.Rid"/>s that will be excluded from the path query. Use <see cref="Godot.NavigationRegion3D.GetRid()"/> to get the <see cref="Godot.Rid"/> associated with a <see cref="Godot.NavigationRegion3D"/> node.</para>
    /// <para><b>Note:</b> The returned array is copied and any changes to it will not update the original property value. To update the value you need to modify the returned array, and then set it to the property again.</para>
    /// </summary>
    public Godot.Collections.Array<Rid> ExcludedRegions
    {
        get
        {
            return GetExcludedRegions();
        }
        set
        {
            SetExcludedRegions(value);
        }
    }

    /// <summary>
    /// <para>The list of region <see cref="Godot.Rid"/>s that will be included by the path query. Use <see cref="Godot.NavigationRegion3D.GetRid()"/> to get the <see cref="Godot.Rid"/> associated with a <see cref="Godot.NavigationRegion3D"/> node. If left empty all regions are included. If a region ends up being both included and excluded at the same time it will be excluded.</para>
    /// <para><b>Note:</b> The returned array is copied and any changes to it will not update the original property value. To update the value you need to modify the returned array, and then set it to the property again.</para>
    /// </summary>
    public Godot.Collections.Array<Rid> IncludedRegions
    {
        get
        {
            return GetIncludedRegions();
        }
        set
        {
            SetIncludedRegions(value);
        }
    }

    /// <summary>
    /// <para>The maximum allowed length of the returned path in world units. A path will be clipped when going over this length. A value of <c>0</c> or below counts as disabled.</para>
    /// </summary>
    public float PathReturnMaxLength
    {
        get
        {
            return GetPathReturnMaxLength();
        }
        set
        {
            SetPathReturnMaxLength(value);
        }
    }

    /// <summary>
    /// <para>The maximum allowed radius in world units that the returned path can be from the path start. The path will be clipped when going over this radius. A value of <c>0</c> or below counts as disabled.</para>
    /// <para><b>Note:</b> This will perform a sphere shaped clip operation on the path with the first path position being the sphere's center position.</para>
    /// </summary>
    public float PathReturnMaxRadius
    {
        get
        {
            return GetPathReturnMaxRadius();
        }
        set
        {
            SetPathReturnMaxRadius(value);
        }
    }

    /// <summary>
    /// <para>The maximum number of polygons that are searched before the pathfinding cancels the search for a path to the (possibly unreachable or very far away) target position polygon. In this case the pathfinding resets and builds a path from the start polygon to the polygon that was found closest to the target position so far. A value of <c>0</c> or below counts as unlimited. In case of unlimited the pathfinding will search all polygons connected with the start polygon until either the target position polygon is found or all available polygon search options are exhausted.</para>
    /// </summary>
    public int PathSearchMaxPolygons
    {
        get
        {
            return GetPathSearchMaxPolygons();
        }
        set
        {
            SetPathSearchMaxPolygons(value);
        }
    }

    /// <summary>
    /// <para>The maximum distance a searched polygon can be away from the start polygon before the pathfinding cancels the search for a path to the (possibly unreachable or very far away) target position polygon. In this case the pathfinding resets and builds a path from the start polygon to the polygon that was found closest to the target position so far. A value of <c>0</c> or below counts as unlimited. In case of unlimited the pathfinding will search all polygons connected with the start polygon until either the target position polygon is found or all available polygon search options are exhausted.</para>
    /// </summary>
    public float PathSearchMaxDistance
    {
        get
        {
            return GetPathSearchMaxDistance();
        }
        set
        {
            SetPathSearchMaxDistance(value);
        }
    }

    private static readonly System.Type CachedType = typeof(NavigationPathQueryParameters3D);

    private static readonly StringName NativeName = "NavigationPathQueryParameters3D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public NavigationPathQueryParameters3D() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal NavigationPathQueryParameters3D(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal NavigationPathQueryParameters3D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPathfindingAlgorithm, 394560454ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPathfindingAlgorithm(NavigationPathQueryParameters3D.PathfindingAlgorithmEnum pathfindingAlgorithm)
    {
        NativeCalls.godot_icall_1_38(MethodBind0, GodotObject.GetPtr(this), (int)pathfindingAlgorithm);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPathfindingAlgorithm, 3398491350ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public NavigationPathQueryParameters3D.PathfindingAlgorithmEnum GetPathfindingAlgorithm()
    {
        return (NavigationPathQueryParameters3D.PathfindingAlgorithmEnum)NativeCalls.godot_icall_0_39(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPathPostprocessing, 2267362344ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPathPostprocessing(NavigationPathQueryParameters3D.PathPostProcessing pathPostprocessing)
    {
        NativeCalls.godot_icall_1_38(MethodBind2, GodotObject.GetPtr(this), (int)pathPostprocessing);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPathPostprocessing, 3883858360ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public NavigationPathQueryParameters3D.PathPostProcessing GetPathPostprocessing()
    {
        return (NavigationPathQueryParameters3D.PathPostProcessing)NativeCalls.godot_icall_0_39(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMap, 2722037293ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMap(Rid map)
    {
        NativeCalls.godot_icall_1_286(MethodBind4, GodotObject.GetPtr(this), map);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMap, 2944877500ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Rid GetMap()
    {
        return NativeCalls.godot_icall_0_238(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetStartPosition, 3460891852ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetStartPosition(Vector3 startPosition)
    {
        NativeCalls.godot_icall_1_177(MethodBind6, GodotObject.GetPtr(this), &startPosition);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetStartPosition, 3360562783ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector3 GetStartPosition()
    {
        return NativeCalls.godot_icall_0_125(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTargetPosition, 3460891852ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetTargetPosition(Vector3 targetPosition)
    {
        NativeCalls.godot_icall_1_177(MethodBind8, GodotObject.GetPtr(this), &targetPosition);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTargetPosition, 3360562783ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector3 GetTargetPosition()
    {
        return NativeCalls.godot_icall_0_125(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetNavigationLayers, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetNavigationLayers(uint navigationLayers)
    {
        NativeCalls.godot_icall_1_208(MethodBind10, GodotObject.GetPtr(this), navigationLayers);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNavigationLayers, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public uint GetNavigationLayers()
    {
        return NativeCalls.godot_icall_0_209(MethodBind11, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMetadataFlags, 2713846708ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMetadataFlags(NavigationPathQueryParameters3D.PathMetadataFlags flags)
    {
        NativeCalls.godot_icall_1_38(MethodBind12, GodotObject.GetPtr(this), (int)flags);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMetadataFlags, 1582332802ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public NavigationPathQueryParameters3D.PathMetadataFlags GetMetadataFlags()
    {
        return (NavigationPathQueryParameters3D.PathMetadataFlags)NativeCalls.godot_icall_0_39(MethodBind13, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSimplifyPath, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSimplifyPath(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind14, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSimplifyPath, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetSimplifyPath()
    {
        return NativeCalls.godot_icall_0_15(MethodBind15, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSimplifyEpsilon, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSimplifyEpsilon(float epsilon)
    {
        NativeCalls.godot_icall_1_67(MethodBind16, GodotObject.GetPtr(this), epsilon);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSimplifyEpsilon, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetSimplifyEpsilon()
    {
        return NativeCalls.godot_icall_0_68(MethodBind17, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetIncludedRegions, 381264803ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetIncludedRegions(Godot.Collections.Array<Rid> regions)
    {
        NativeCalls.godot_icall_1_138(MethodBind18, GodotObject.GetPtr(this), (godot_array)(regions ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetIncludedRegions, 3995934104ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Godot.Collections.Array<Rid> GetIncludedRegions()
    {
        return new Godot.Collections.Array<Rid>(NativeCalls.godot_icall_0_120(MethodBind19, GodotObject.GetPtr(this)));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetExcludedRegions, 381264803ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetExcludedRegions(Godot.Collections.Array<Rid> regions)
    {
        NativeCalls.godot_icall_1_138(MethodBind20, GodotObject.GetPtr(this), (godot_array)(regions ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetExcludedRegions, 3995934104ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Godot.Collections.Array<Rid> GetExcludedRegions()
    {
        return new Godot.Collections.Array<Rid>(NativeCalls.godot_icall_0_120(MethodBind21, GodotObject.GetPtr(this)));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPathReturnMaxLength, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPathReturnMaxLength(float length)
    {
        NativeCalls.godot_icall_1_67(MethodBind22, GodotObject.GetPtr(this), length);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPathReturnMaxLength, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetPathReturnMaxLength()
    {
        return NativeCalls.godot_icall_0_68(MethodBind23, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPathReturnMaxRadius, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPathReturnMaxRadius(float radius)
    {
        NativeCalls.godot_icall_1_67(MethodBind24, GodotObject.GetPtr(this), radius);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPathReturnMaxRadius, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetPathReturnMaxRadius()
    {
        return NativeCalls.godot_icall_0_68(MethodBind25, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPathSearchMaxPolygons, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPathSearchMaxPolygons(int maxPolygons)
    {
        NativeCalls.godot_icall_1_38(MethodBind26, GodotObject.GetPtr(this), maxPolygons);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPathSearchMaxPolygons, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetPathSearchMaxPolygons()
    {
        return NativeCalls.godot_icall_0_39(MethodBind27, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPathSearchMaxDistance, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPathSearchMaxDistance(float distance)
    {
        NativeCalls.godot_icall_1_67(MethodBind28, GodotObject.GetPtr(this), distance);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPathSearchMaxDistance, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetPathSearchMaxDistance()
    {
        return NativeCalls.godot_icall_0_68(MethodBind29, GodotObject.GetPtr(this));
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
        /// Cached name for the 'map' property.
        /// </summary>
        public static readonly StringName Map = "map";
        /// <summary>
        /// Cached name for the 'start_position' property.
        /// </summary>
        public static readonly StringName StartPosition = "start_position";
        /// <summary>
        /// Cached name for the 'target_position' property.
        /// </summary>
        public static readonly StringName TargetPosition = "target_position";
        /// <summary>
        /// Cached name for the 'navigation_layers' property.
        /// </summary>
        public static readonly StringName NavigationLayers = "navigation_layers";
        /// <summary>
        /// Cached name for the 'pathfinding_algorithm' property.
        /// </summary>
        public static readonly StringName PathfindingAlgorithm = "pathfinding_algorithm";
        /// <summary>
        /// Cached name for the 'path_postprocessing' property.
        /// </summary>
        public static readonly StringName PathPostprocessing = "path_postprocessing";
        /// <summary>
        /// Cached name for the 'metadata_flags' property.
        /// </summary>
        public static readonly StringName MetadataFlags = "metadata_flags";
        /// <summary>
        /// Cached name for the 'simplify_path' property.
        /// </summary>
        public static readonly StringName SimplifyPath = "simplify_path";
        /// <summary>
        /// Cached name for the 'simplify_epsilon' property.
        /// </summary>
        public static readonly StringName SimplifyEpsilon = "simplify_epsilon";
        /// <summary>
        /// Cached name for the 'excluded_regions' property.
        /// </summary>
        public static readonly StringName ExcludedRegions = "excluded_regions";
        /// <summary>
        /// Cached name for the 'included_regions' property.
        /// </summary>
        public static readonly StringName IncludedRegions = "included_regions";
        /// <summary>
        /// Cached name for the 'path_return_max_length' property.
        /// </summary>
        public static readonly StringName PathReturnMaxLength = "path_return_max_length";
        /// <summary>
        /// Cached name for the 'path_return_max_radius' property.
        /// </summary>
        public static readonly StringName PathReturnMaxRadius = "path_return_max_radius";
        /// <summary>
        /// Cached name for the 'path_search_max_polygons' property.
        /// </summary>
        public static readonly StringName PathSearchMaxPolygons = "path_search_max_polygons";
        /// <summary>
        /// Cached name for the 'path_search_max_distance' property.
        /// </summary>
        public static readonly StringName PathSearchMaxDistance = "path_search_max_distance";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : RefCounted.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_pathfinding_algorithm' method.
        /// </summary>
        public static readonly StringName SetPathfindingAlgorithm = "set_pathfinding_algorithm";
        /// <summary>
        /// Cached name for the 'get_pathfinding_algorithm' method.
        /// </summary>
        public static readonly StringName GetPathfindingAlgorithm = "get_pathfinding_algorithm";
        /// <summary>
        /// Cached name for the 'set_path_postprocessing' method.
        /// </summary>
        public static readonly StringName SetPathPostprocessing = "set_path_postprocessing";
        /// <summary>
        /// Cached name for the 'get_path_postprocessing' method.
        /// </summary>
        public static readonly StringName GetPathPostprocessing = "get_path_postprocessing";
        /// <summary>
        /// Cached name for the 'set_map' method.
        /// </summary>
        public static readonly StringName SetMap = "set_map";
        /// <summary>
        /// Cached name for the 'get_map' method.
        /// </summary>
        public static readonly StringName GetMap = "get_map";
        /// <summary>
        /// Cached name for the 'set_start_position' method.
        /// </summary>
        public static readonly StringName SetStartPosition = "set_start_position";
        /// <summary>
        /// Cached name for the 'get_start_position' method.
        /// </summary>
        public static readonly StringName GetStartPosition = "get_start_position";
        /// <summary>
        /// Cached name for the 'set_target_position' method.
        /// </summary>
        public static readonly StringName SetTargetPosition = "set_target_position";
        /// <summary>
        /// Cached name for the 'get_target_position' method.
        /// </summary>
        public static readonly StringName GetTargetPosition = "get_target_position";
        /// <summary>
        /// Cached name for the 'set_navigation_layers' method.
        /// </summary>
        public static readonly StringName SetNavigationLayers = "set_navigation_layers";
        /// <summary>
        /// Cached name for the 'get_navigation_layers' method.
        /// </summary>
        public static readonly StringName GetNavigationLayers = "get_navigation_layers";
        /// <summary>
        /// Cached name for the 'set_metadata_flags' method.
        /// </summary>
        public static readonly StringName SetMetadataFlags = "set_metadata_flags";
        /// <summary>
        /// Cached name for the 'get_metadata_flags' method.
        /// </summary>
        public static readonly StringName GetMetadataFlags = "get_metadata_flags";
        /// <summary>
        /// Cached name for the 'set_simplify_path' method.
        /// </summary>
        public static readonly StringName SetSimplifyPath = "set_simplify_path";
        /// <summary>
        /// Cached name for the 'get_simplify_path' method.
        /// </summary>
        public static readonly StringName GetSimplifyPath = "get_simplify_path";
        /// <summary>
        /// Cached name for the 'set_simplify_epsilon' method.
        /// </summary>
        public static readonly StringName SetSimplifyEpsilon = "set_simplify_epsilon";
        /// <summary>
        /// Cached name for the 'get_simplify_epsilon' method.
        /// </summary>
        public static readonly StringName GetSimplifyEpsilon = "get_simplify_epsilon";
        /// <summary>
        /// Cached name for the 'set_included_regions' method.
        /// </summary>
        public static readonly StringName SetIncludedRegions = "set_included_regions";
        /// <summary>
        /// Cached name for the 'get_included_regions' method.
        /// </summary>
        public static readonly StringName GetIncludedRegions = "get_included_regions";
        /// <summary>
        /// Cached name for the 'set_excluded_regions' method.
        /// </summary>
        public static readonly StringName SetExcludedRegions = "set_excluded_regions";
        /// <summary>
        /// Cached name for the 'get_excluded_regions' method.
        /// </summary>
        public static readonly StringName GetExcludedRegions = "get_excluded_regions";
        /// <summary>
        /// Cached name for the 'set_path_return_max_length' method.
        /// </summary>
        public static readonly StringName SetPathReturnMaxLength = "set_path_return_max_length";
        /// <summary>
        /// Cached name for the 'get_path_return_max_length' method.
        /// </summary>
        public static readonly StringName GetPathReturnMaxLength = "get_path_return_max_length";
        /// <summary>
        /// Cached name for the 'set_path_return_max_radius' method.
        /// </summary>
        public static readonly StringName SetPathReturnMaxRadius = "set_path_return_max_radius";
        /// <summary>
        /// Cached name for the 'get_path_return_max_radius' method.
        /// </summary>
        public static readonly StringName GetPathReturnMaxRadius = "get_path_return_max_radius";
        /// <summary>
        /// Cached name for the 'set_path_search_max_polygons' method.
        /// </summary>
        public static readonly StringName SetPathSearchMaxPolygons = "set_path_search_max_polygons";
        /// <summary>
        /// Cached name for the 'get_path_search_max_polygons' method.
        /// </summary>
        public static readonly StringName GetPathSearchMaxPolygons = "get_path_search_max_polygons";
        /// <summary>
        /// Cached name for the 'set_path_search_max_distance' method.
        /// </summary>
        public static readonly StringName SetPathSearchMaxDistance = "set_path_search_max_distance";
        /// <summary>
        /// Cached name for the 'get_path_search_max_distance' method.
        /// </summary>
        public static readonly StringName GetPathSearchMaxDistance = "get_path_search_max_distance";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : RefCounted.SignalName
    {
    }
}
