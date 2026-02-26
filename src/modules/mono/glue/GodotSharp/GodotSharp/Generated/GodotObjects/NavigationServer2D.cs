namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>NavigationServer2D is the server that handles navigation maps, regions and agents. It does not handle A* navigation from <see cref="Godot.AStar2D"/> or <see cref="Godot.AStarGrid2D"/>.</para>
/// <para>Maps are divided into regions, which are composed of navigation polygons. Together, they define the traversable areas in the 2D world.</para>
/// <para><b>Note:</b> Most <see cref="Godot.NavigationServer2D"/> changes take effect after the next physics frame and not immediately. This includes all changes made to maps, regions or agents by navigation-related nodes in the scene tree or made through scripts.</para>
/// <para>For two regions to be connected to each other, they must share a similar edge. An edge is considered connected to another if both of its two vertices are at a distance less than <c>edge_connection_margin</c> to the respective other edge's vertex.</para>
/// <para>You may assign navigation layers to regions with <see cref="Godot.NavigationServer2D.RegionSetNavigationLayers(Rid, uint)"/>, which then can be checked upon when requesting a path with <see cref="Godot.NavigationServer2D.MapGetPath(Rid, Vector2, Vector2, bool, uint)"/>. This can be used to allow or deny certain areas for some objects.</para>
/// <para>To use the collision avoidance system, you may use agents. You can set an agent's target velocity, then the servers will emit a callback with a modified velocity.</para>
/// <para><b>Note:</b> The collision avoidance system ignores regions. Using the modified velocity directly may move an agent outside of the traversable area. This is a limitation of the collision avoidance system, any more complex situation may require the use of the physics engine.</para>
/// <para>This server keeps tracks of any call and executes them during the sync phase. This means that you can request any change to the map, using any thread, without worrying.</para>
/// </summary>
public static partial class NavigationServer2D
{
    public enum ProcessInfo : long
    {
        /// <summary>
        /// <para>Constant to get the number of active navigation maps.</para>
        /// </summary>
        ActiveMaps = 0,
        /// <summary>
        /// <para>Constant to get the number of active navigation regions.</para>
        /// </summary>
        RegionCount = 1,
        /// <summary>
        /// <para>Constant to get the number of active navigation agents processing avoidance.</para>
        /// </summary>
        AgentCount = 2,
        /// <summary>
        /// <para>Constant to get the number of active navigation links.</para>
        /// </summary>
        LinkCount = 3,
        /// <summary>
        /// <para>Constant to get the number of navigation mesh polygons.</para>
        /// </summary>
        PolygonCount = 4,
        /// <summary>
        /// <para>Constant to get the number of navigation mesh polygon edges.</para>
        /// </summary>
        EdgeCount = 5,
        /// <summary>
        /// <para>Constant to get the number of navigation mesh polygon edges that were merged due to edge key overlap.</para>
        /// </summary>
        EdgeMergeCount = 6,
        /// <summary>
        /// <para>Constant to get the number of navigation mesh polygon edges that are considered connected by edge proximity.</para>
        /// </summary>
        EdgeConnectionCount = 7,
        /// <summary>
        /// <para>Constant to get the number of navigation mesh polygon edges that could not be merged but may be still connected by edge proximity or with links.</para>
        /// </summary>
        EdgeFreeCount = 8,
        /// <summary>
        /// <para>Constant to get the number of active navigation obstacles.</para>
        /// </summary>
        ObstacleCount = 9
    }

    private static readonly StringName NativeName = "NavigationServer2D";

    private static NavigationServer2DInstance singleton;

    public static NavigationServer2DInstance Singleton =>
        singleton ??= (NavigationServer2DInstance)InteropUtils.EngineGetSingleton("NavigationServer2D");

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMaps, 3995934104ul);

    /// <summary>
    /// <para>Returns all created navigation map <see cref="Godot.Rid"/>s on the NavigationServer. This returns both 2D and 3D created navigation maps as there is technically no distinction between them.</para>
    /// </summary>
    public static Godot.Collections.Array<Rid> GetMaps()
    {
        return new Godot.Collections.Array<Rid>(NativeCalls.godot_icall_0_120(MethodBind0, GodotObject.GetPtr(Singleton)));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.MapCreate, 529393457ul);

    /// <summary>
    /// <para>Create a new map.</para>
    /// </summary>
    public static Rid MapCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind1, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.MapSetActive, 1265174801ul);

    /// <summary>
    /// <para>Sets the map active.</para>
    /// </summary>
    public static void MapSetActive(Rid map, bool active)
    {
        NativeCalls.godot_icall_2_434(MethodBind2, GodotObject.GetPtr(Singleton), map, active.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.MapIsActive, 4155700596ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the map is active.</para>
    /// </summary>
    public static bool MapIsActive(Rid map)
    {
        return NativeCalls.godot_icall_1_421(MethodBind3, GodotObject.GetPtr(Singleton), map).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.MapSetCellSize, 1794382983ul);

    /// <summary>
    /// <para>Sets the map cell size used to rasterize the navigation mesh vertices. Must match with the cell size of the used navigation meshes.</para>
    /// </summary>
    public static void MapSetCellSize(Rid map, float cellSize)
    {
        NativeCalls.godot_icall_2_816(MethodBind4, GodotObject.GetPtr(Singleton), map, cellSize);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.MapGetCellSize, 866169185ul);

    /// <summary>
    /// <para>Returns the map cell size used to rasterize the navigation mesh vertices.</para>
    /// </summary>
    public static float MapGetCellSize(Rid map)
    {
        return NativeCalls.godot_icall_1_817(MethodBind5, GodotObject.GetPtr(Singleton), map);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.MapSetMergeRasterizerCellScale, 1794382983ul);

    /// <summary>
    /// <para>Set the map's internal merge rasterizer cell scale used to control merging sensitivity.</para>
    /// </summary>
    public static void MapSetMergeRasterizerCellScale(Rid map, float scale)
    {
        NativeCalls.godot_icall_2_816(MethodBind6, GodotObject.GetPtr(Singleton), map, scale);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.MapGetMergeRasterizerCellScale, 866169185ul);

    /// <summary>
    /// <para>Returns map's internal merge rasterizer cell scale.</para>
    /// </summary>
    public static float MapGetMergeRasterizerCellScale(Rid map)
    {
        return NativeCalls.godot_icall_1_817(MethodBind7, GodotObject.GetPtr(Singleton), map);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.MapSetUseEdgeConnections, 1265174801ul);

    /// <summary>
    /// <para>Set the navigation <paramref name="map"/> edge connection use. If <paramref name="enabled"/> is <see langword="true"/>, the navigation map allows navigation regions to use edge connections to connect with other navigation regions within proximity of the navigation map edge connection margin.</para>
    /// </summary>
    public static void MapSetUseEdgeConnections(Rid map, bool enabled)
    {
        NativeCalls.godot_icall_2_434(MethodBind8, GodotObject.GetPtr(Singleton), map, enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.MapGetUseEdgeConnections, 4155700596ul);

    /// <summary>
    /// <para>Returns whether the navigation <paramref name="map"/> allows navigation regions to use edge connections to connect with other navigation regions within proximity of the navigation map edge connection margin.</para>
    /// </summary>
    public static bool MapGetUseEdgeConnections(Rid map)
    {
        return NativeCalls.godot_icall_1_421(MethodBind9, GodotObject.GetPtr(Singleton), map).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.MapSetEdgeConnectionMargin, 1794382983ul);

    /// <summary>
    /// <para>Set the map edge connection margin used to weld the compatible region edges.</para>
    /// </summary>
    public static void MapSetEdgeConnectionMargin(Rid map, float margin)
    {
        NativeCalls.godot_icall_2_816(MethodBind10, GodotObject.GetPtr(Singleton), map, margin);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.MapGetEdgeConnectionMargin, 866169185ul);

    /// <summary>
    /// <para>Returns the edge connection margin of the map. The edge connection margin is a distance used to connect two regions.</para>
    /// </summary>
    public static float MapGetEdgeConnectionMargin(Rid map)
    {
        return NativeCalls.godot_icall_1_817(MethodBind11, GodotObject.GetPtr(Singleton), map);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.MapSetLinkConnectionRadius, 1794382983ul);

    /// <summary>
    /// <para>Set the map's link connection radius used to connect links to navigation polygons.</para>
    /// </summary>
    public static void MapSetLinkConnectionRadius(Rid map, float radius)
    {
        NativeCalls.godot_icall_2_816(MethodBind12, GodotObject.GetPtr(Singleton), map, radius);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.MapGetLinkConnectionRadius, 866169185ul);

    /// <summary>
    /// <para>Returns the link connection radius of the map. This distance is the maximum range any link will search for navigation mesh polygons to connect to.</para>
    /// </summary>
    public static float MapGetLinkConnectionRadius(Rid map)
    {
        return NativeCalls.godot_icall_1_817(MethodBind13, GodotObject.GetPtr(Singleton), map);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.MapGetPath, 1279824844ul);

    /// <summary>
    /// <para>Returns the navigation path to reach the destination from the origin. <paramref name="navigationLayers"/> is a bitmask of all region navigation layers that are allowed to be in the path.</para>
    /// </summary>
    public static unsafe Vector2[] MapGetPath(Rid map, Vector2 origin, Vector2 destination, bool optimize, uint navigationLayers = (uint)(1))
    {
        return NativeCalls.godot_icall_5_846(MethodBind14, GodotObject.GetPtr(Singleton), map, &origin, &destination, optimize.ToGodotBool(), navigationLayers);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.MapGetClosestPoint, 1358334418ul);

    /// <summary>
    /// <para>Returns the navigation mesh surface point closest to the provided <paramref name="toPoint"/> on the navigation <paramref name="map"/>.</para>
    /// </summary>
    public static unsafe Vector2 MapGetClosestPoint(Rid map, Vector2 toPoint)
    {
        return NativeCalls.godot_icall_2_847(MethodBind15, GodotObject.GetPtr(Singleton), map, &toPoint);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.MapGetClosestPointOwner, 1353467510ul);

    /// <summary>
    /// <para>Returns the owner region RID for the navigation mesh surface point closest to the provided <paramref name="toPoint"/> on the navigation <paramref name="map"/>.</para>
    /// </summary>
    public static unsafe Rid MapGetClosestPointOwner(Rid map, Vector2 toPoint)
    {
        return NativeCalls.godot_icall_2_848(MethodBind16, GodotObject.GetPtr(Singleton), map, &toPoint);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.MapGetLinks, 2684255073ul);

    /// <summary>
    /// <para>Returns all navigation link <see cref="Godot.Rid"/>s that are currently assigned to the requested navigation <paramref name="map"/>.</para>
    /// </summary>
    public static Godot.Collections.Array<Rid> MapGetLinks(Rid map)
    {
        return new Godot.Collections.Array<Rid>(NativeCalls.godot_icall_1_849(MethodBind17, GodotObject.GetPtr(Singleton), map));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.MapGetRegions, 2684255073ul);

    /// <summary>
    /// <para>Returns all navigation regions <see cref="Godot.Rid"/>s that are currently assigned to the requested navigation <paramref name="map"/>.</para>
    /// </summary>
    public static Godot.Collections.Array<Rid> MapGetRegions(Rid map)
    {
        return new Godot.Collections.Array<Rid>(NativeCalls.godot_icall_1_849(MethodBind18, GodotObject.GetPtr(Singleton), map));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.MapGetAgents, 2684255073ul);

    /// <summary>
    /// <para>Returns all navigation agents <see cref="Godot.Rid"/>s that are currently assigned to the requested navigation <paramref name="map"/>.</para>
    /// </summary>
    public static Godot.Collections.Array<Rid> MapGetAgents(Rid map)
    {
        return new Godot.Collections.Array<Rid>(NativeCalls.godot_icall_1_849(MethodBind19, GodotObject.GetPtr(Singleton), map));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.MapGetObstacles, 2684255073ul);

    /// <summary>
    /// <para>Returns all navigation obstacle <see cref="Godot.Rid"/>s that are currently assigned to the requested navigation <paramref name="map"/>.</para>
    /// </summary>
    public static Godot.Collections.Array<Rid> MapGetObstacles(Rid map)
    {
        return new Godot.Collections.Array<Rid>(NativeCalls.godot_icall_1_849(MethodBind20, GodotObject.GetPtr(Singleton), map));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.MapForceUpdate, 2722037293ul);

    /// <summary>
    /// <para>This function immediately forces synchronization of the specified navigation <paramref name="map"/> <see cref="Godot.Rid"/>. By default navigation maps are only synchronized at the end of each physics frame. This function can be used to immediately (re)calculate all the navigation meshes and region connections of the navigation map. This makes it possible to query a navigation path for a changed map immediately and in the same frame (multiple times if needed).</para>
    /// <para>Due to technical restrictions the current NavigationServer command queue will be flushed. This means all already queued update commands for this physics frame will be executed, even those intended for other maps, regions and agents not part of the specified map. The expensive computation of the navigation meshes and region connections of a map will only be done for the specified map. Other maps will receive the normal synchronization at the end of the physics frame. Should the specified map receive changes after the forced update it will update again as well when the other maps receive their update.</para>
    /// <para>Avoidance processing and dispatch of the <c>safe_velocity</c> signals is unaffected by this function and continues to happen for all maps and agents at the end of the physics frame.</para>
    /// <para><b>Note:</b> With great power comes great responsibility. This function should only be used by users that really know what they are doing and have a good reason for it. Forcing an immediate update of a navigation map requires locking the NavigationServer and flushing the entire NavigationServer command queue. Not only can this severely impact the performance of a game but it can also introduce bugs if used inappropriately without much foresight.</para>
    /// </summary>
    [Obsolete("This method is no longer supported, as it is incompatible with asynchronous updates. It can only be used in a single-threaded context, at your own risk.")]
    public static void MapForceUpdate(Rid map)
    {
        NativeCalls.godot_icall_1_286(MethodBind21, GodotObject.GetPtr(Singleton), map);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.MapGetIterationId, 2198884583ul);

    /// <summary>
    /// <para>Returns the current iteration id of the navigation map. Every time the navigation map changes and synchronizes the iteration id increases. An iteration id of 0 means the navigation map has never synchronized.</para>
    /// <para><b>Note:</b> The iteration id will wrap back to 1 after reaching its range limit.</para>
    /// </summary>
    public static uint MapGetIterationId(Rid map)
    {
        return NativeCalls.godot_icall_1_850(MethodBind22, GodotObject.GetPtr(Singleton), map);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.MapSetUseAsyncIterations, 1265174801ul);

    /// <summary>
    /// <para>If <paramref name="enabled"/> is <see langword="true"/> the <paramref name="map"/> synchronization uses an async process that runs on a background thread.</para>
    /// </summary>
    public static void MapSetUseAsyncIterations(Rid map, bool enabled)
    {
        NativeCalls.godot_icall_2_434(MethodBind23, GodotObject.GetPtr(Singleton), map, enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.MapGetUseAsyncIterations, 4155700596ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the <paramref name="map"/> synchronization uses an async process that runs on a background thread.</para>
    /// </summary>
    public static bool MapGetUseAsyncIterations(Rid map)
    {
        return NativeCalls.godot_icall_1_421(MethodBind24, GodotObject.GetPtr(Singleton), map).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.MapGetRandomPoint, 3271000763ul);

    /// <summary>
    /// <para>Returns a random position picked from all map region polygons with matching <paramref name="navigationLayers"/>.</para>
    /// <para>If <paramref name="uniformly"/> is <see langword="true"/>, all map regions, polygons, and faces are weighted by their surface area (slower).</para>
    /// <para>If <paramref name="uniformly"/> is <see langword="false"/>, just a random region and a random polygon are picked (faster).</para>
    /// </summary>
    public static Vector2 MapGetRandomPoint(Rid map, uint navigationLayers, bool uniformly)
    {
        return NativeCalls.godot_icall_3_851(MethodBind25, GodotObject.GetPtr(Singleton), map, navigationLayers, uniformly.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.QueryPath, 1254915886ul);

    /// <summary>
    /// <para>Queries a path in a given navigation map. Start and target position and other parameters are defined through <see cref="Godot.NavigationPathQueryParameters2D"/>. Updates the provided <see cref="Godot.NavigationPathQueryResult2D"/> result object with the path among other results requested by the query. After the process is finished the optional <paramref name="callback"/> will be called.</para>
    /// </summary>
    public static void QueryPath(NavigationPathQueryParameters2D parameters, NavigationPathQueryResult2D result, Callable callback = default)
    {
        NativeCalls.godot_icall_3_837(MethodBind26, GodotObject.GetPtr(Singleton), GodotObject.GetPtr(parameters), GodotObject.GetPtr(result), callback);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.RegionCreate, 529393457ul);

    /// <summary>
    /// <para>Creates a new region.</para>
    /// </summary>
    public static Rid RegionCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind27, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.RegionGetIterationId, 2198884583ul);

    /// <summary>
    /// <para>Returns the current iteration ID of the navigation region. Every time the navigation region changes and synchronizes, the iteration ID increases. An iteration ID of <c>0</c> means the navigation region has never synchronized.</para>
    /// <para><b>Note:</b> The iteration ID will wrap around to <c>1</c> after reaching its range limit.</para>
    /// </summary>
    public static uint RegionGetIterationId(Rid region)
    {
        return NativeCalls.godot_icall_1_850(MethodBind28, GodotObject.GetPtr(Singleton), region);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.RegionSetUseAsyncIterations, 1265174801ul);

    /// <summary>
    /// <para>If <paramref name="enabled"/> is <see langword="true"/> the <paramref name="region"/> uses an async synchronization process that runs on a background thread.</para>
    /// </summary>
    public static void RegionSetUseAsyncIterations(Rid region, bool enabled)
    {
        NativeCalls.godot_icall_2_434(MethodBind29, GodotObject.GetPtr(Singleton), region, enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.RegionGetUseAsyncIterations, 4155700596ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the <paramref name="region"/> uses an async synchronization process that runs on a background thread.</para>
    /// </summary>
    public static bool RegionGetUseAsyncIterations(Rid region)
    {
        return NativeCalls.godot_icall_1_421(MethodBind30, GodotObject.GetPtr(Singleton), region).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.RegionSetEnabled, 1265174801ul);

    /// <summary>
    /// <para>If <paramref name="enabled"/> is <see langword="true"/> the specified <paramref name="region"/> will contribute to its current navigation map.</para>
    /// </summary>
    public static void RegionSetEnabled(Rid region, bool enabled)
    {
        NativeCalls.godot_icall_2_434(MethodBind31, GodotObject.GetPtr(Singleton), region, enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind32 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.RegionGetEnabled, 4155700596ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the specified <paramref name="region"/> is enabled.</para>
    /// </summary>
    public static bool RegionGetEnabled(Rid region)
    {
        return NativeCalls.godot_icall_1_421(MethodBind32, GodotObject.GetPtr(Singleton), region).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind33 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.RegionSetUseEdgeConnections, 1265174801ul);

    /// <summary>
    /// <para>If <paramref name="enabled"/> is <see langword="true"/>, the navigation <paramref name="region"/> will use edge connections to connect with other navigation regions within proximity of the navigation map edge connection margin.</para>
    /// </summary>
    public static void RegionSetUseEdgeConnections(Rid region, bool enabled)
    {
        NativeCalls.godot_icall_2_434(MethodBind33, GodotObject.GetPtr(Singleton), region, enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind34 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.RegionGetUseEdgeConnections, 4155700596ul);

    /// <summary>
    /// <para>Returns whether the navigation <paramref name="region"/> is set to use edge connections to connect with other navigation regions within proximity of the navigation map edge connection margin.</para>
    /// </summary>
    public static bool RegionGetUseEdgeConnections(Rid region)
    {
        return NativeCalls.godot_icall_1_421(MethodBind34, GodotObject.GetPtr(Singleton), region).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind35 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.RegionSetEnterCost, 1794382983ul);

    /// <summary>
    /// <para>Sets the <paramref name="enterCost"/> for this <paramref name="region"/>.</para>
    /// </summary>
    public static void RegionSetEnterCost(Rid region, float enterCost)
    {
        NativeCalls.godot_icall_2_816(MethodBind35, GodotObject.GetPtr(Singleton), region, enterCost);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind36 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.RegionGetEnterCost, 866169185ul);

    /// <summary>
    /// <para>Returns the enter cost of this <paramref name="region"/>.</para>
    /// </summary>
    public static float RegionGetEnterCost(Rid region)
    {
        return NativeCalls.godot_icall_1_817(MethodBind36, GodotObject.GetPtr(Singleton), region);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind37 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.RegionSetTravelCost, 1794382983ul);

    /// <summary>
    /// <para>Sets the <paramref name="travelCost"/> for this <paramref name="region"/>.</para>
    /// </summary>
    public static void RegionSetTravelCost(Rid region, float travelCost)
    {
        NativeCalls.godot_icall_2_816(MethodBind37, GodotObject.GetPtr(Singleton), region, travelCost);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind38 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.RegionGetTravelCost, 866169185ul);

    /// <summary>
    /// <para>Returns the travel cost of this <paramref name="region"/>.</para>
    /// </summary>
    public static float RegionGetTravelCost(Rid region)
    {
        return NativeCalls.godot_icall_1_817(MethodBind38, GodotObject.GetPtr(Singleton), region);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind39 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.RegionSetOwnerId, 3411492887ul);

    /// <summary>
    /// <para>Set the <c>ObjectID</c> of the object which manages this region.</para>
    /// </summary>
    public static void RegionSetOwnerId(Rid region, ulong ownerId)
    {
        NativeCalls.godot_icall_2_852(MethodBind39, GodotObject.GetPtr(Singleton), region, ownerId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind40 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.RegionGetOwnerId, 2198884583ul);

    /// <summary>
    /// <para>Returns the <c>ObjectID</c> of the object which manages this region.</para>
    /// </summary>
    public static ulong RegionGetOwnerId(Rid region)
    {
        return NativeCalls.godot_icall_1_853(MethodBind40, GodotObject.GetPtr(Singleton), region);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind41 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.RegionOwnsPoint, 219849798ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the provided <paramref name="point"/> in world space is currently owned by the provided navigation <paramref name="region"/>. Owned in this context means that one of the region's navigation mesh polygon faces has a possible position at the closest distance to this point compared to all other navigation meshes from other navigation regions that are also registered on the navigation map of the provided region.</para>
    /// <para>If multiple navigation meshes have positions at equal distance the navigation region whose polygons are processed first wins the ownership. Polygons are processed in the same order that navigation regions were registered on the NavigationServer.</para>
    /// <para><b>Note:</b> If navigation meshes from different navigation regions overlap (which should be avoided in general) the result might not be what is expected.</para>
    /// </summary>
    public static unsafe bool RegionOwnsPoint(Rid region, Vector2 point)
    {
        return NativeCalls.godot_icall_2_854(MethodBind41, GodotObject.GetPtr(Singleton), region, &point).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind42 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.RegionSetMap, 395945892ul);

    /// <summary>
    /// <para>Sets the map for the region.</para>
    /// </summary>
    public static void RegionSetMap(Rid region, Rid map)
    {
        NativeCalls.godot_icall_2_430(MethodBind42, GodotObject.GetPtr(Singleton), region, map);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind43 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.RegionGetMap, 3814569979ul);

    /// <summary>
    /// <para>Returns the navigation map <see cref="Godot.Rid"/> the requested <paramref name="region"/> is currently assigned to.</para>
    /// </summary>
    public static Rid RegionGetMap(Rid region)
    {
        return NativeCalls.godot_icall_1_855(MethodBind43, GodotObject.GetPtr(Singleton), region);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind44 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.RegionSetNavigationLayers, 3411492887ul);

    /// <summary>
    /// <para>Set the region's navigation layers. This allows selecting regions from a path request (when using <see cref="Godot.NavigationServer2D.MapGetPath(Rid, Vector2, Vector2, bool, uint)"/>).</para>
    /// </summary>
    public static void RegionSetNavigationLayers(Rid region, uint navigationLayers)
    {
        NativeCalls.godot_icall_2_856(MethodBind44, GodotObject.GetPtr(Singleton), region, navigationLayers);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind45 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.RegionGetNavigationLayers, 2198884583ul);

    /// <summary>
    /// <para>Returns the region's navigation layers.</para>
    /// </summary>
    public static uint RegionGetNavigationLayers(Rid region)
    {
        return NativeCalls.godot_icall_1_850(MethodBind45, GodotObject.GetPtr(Singleton), region);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind46 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.RegionSetTransform, 1246044741ul);

    /// <summary>
    /// <para>Sets the global transformation for the region.</para>
    /// </summary>
    public static unsafe void RegionSetTransform(Rid region, Transform2D transform)
    {
        NativeCalls.godot_icall_2_429(MethodBind46, GodotObject.GetPtr(Singleton), region, &transform);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind47 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.RegionGetTransform, 213527486ul);

    /// <summary>
    /// <para>Returns the global transformation of this <paramref name="region"/>.</para>
    /// </summary>
    public static Transform2D RegionGetTransform(Rid region)
    {
        return NativeCalls.godot_icall_1_857(MethodBind47, GodotObject.GetPtr(Singleton), region);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind48 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.RegionSetNavigationPolygon, 3633623451ul);

    /// <summary>
    /// <para>Sets the <paramref name="navigationPolygon"/> for the region.</para>
    /// </summary>
    public static void RegionSetNavigationPolygon(Rid region, NavigationPolygon navigationPolygon)
    {
        NativeCalls.godot_icall_2_858(MethodBind48, GodotObject.GetPtr(Singleton), region, GodotObject.GetPtr(navigationPolygon));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind49 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.RegionGetConnectionsCount, 2198884583ul);

    /// <summary>
    /// <para>Returns how many connections this <paramref name="region"/> has with other regions in the map.</para>
    /// </summary>
    public static int RegionGetConnectionsCount(Rid region)
    {
        return NativeCalls.godot_icall_1_835(MethodBind49, GodotObject.GetPtr(Singleton), region);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind50 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.RegionGetConnectionPathwayStart, 2546185844ul);

    /// <summary>
    /// <para>Returns the starting point of a connection door. <paramref name="connection"/> is an index between 0 and the return value of <see cref="Godot.NavigationServer2D.RegionGetConnectionsCount(Rid)"/>.</para>
    /// </summary>
    public static Vector2 RegionGetConnectionPathwayStart(Rid region, int connection)
    {
        return NativeCalls.godot_icall_2_859(MethodBind50, GodotObject.GetPtr(Singleton), region, connection);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind51 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.RegionGetConnectionPathwayEnd, 2546185844ul);

    /// <summary>
    /// <para>Returns the ending point of a connection door. <paramref name="connection"/> is an index between 0 and the return value of <see cref="Godot.NavigationServer2D.RegionGetConnectionsCount(Rid)"/>.</para>
    /// </summary>
    public static Vector2 RegionGetConnectionPathwayEnd(Rid region, int connection)
    {
        return NativeCalls.godot_icall_2_859(MethodBind51, GodotObject.GetPtr(Singleton), region, connection);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind52 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.RegionGetClosestPoint, 1358334418ul);

    /// <summary>
    /// <para>Returns the navigation mesh surface point closest to the provided <paramref name="toPoint"/> on the navigation <paramref name="region"/>.</para>
    /// </summary>
    public static unsafe Vector2 RegionGetClosestPoint(Rid region, Vector2 toPoint)
    {
        return NativeCalls.godot_icall_2_847(MethodBind52, GodotObject.GetPtr(Singleton), region, &toPoint);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind53 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.RegionGetRandomPoint, 3271000763ul);

    /// <summary>
    /// <para>Returns a random position picked from all region polygons with matching <paramref name="navigationLayers"/>.</para>
    /// <para>If <paramref name="uniformly"/> is <see langword="true"/>, all region polygons and faces are weighted by their surface area (slower).</para>
    /// <para>If <paramref name="uniformly"/> is <see langword="false"/>, just a random polygon and face is picked (faster).</para>
    /// </summary>
    public static Vector2 RegionGetRandomPoint(Rid region, uint navigationLayers, bool uniformly)
    {
        return NativeCalls.godot_icall_3_851(MethodBind53, GodotObject.GetPtr(Singleton), region, navigationLayers, uniformly.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind54 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.RegionGetBounds, 1097232729ul);

    /// <summary>
    /// <para>Returns the axis-aligned rectangle for the <paramref name="region"/>'s transformed navigation mesh.</para>
    /// </summary>
    public static Rect2 RegionGetBounds(Rid region)
    {
        return NativeCalls.godot_icall_1_860(MethodBind54, GodotObject.GetPtr(Singleton), region);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind55 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.LinkCreate, 529393457ul);

    /// <summary>
    /// <para>Create a new link between two positions on a map.</para>
    /// </summary>
    public static Rid LinkCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind55, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind56 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.LinkGetIterationId, 2198884583ul);

    /// <summary>
    /// <para>Returns the current iteration ID of the navigation link. Every time the navigation link changes and synchronizes, the iteration ID increases. An iteration ID of <c>0</c> means the navigation link has never synchronized.</para>
    /// <para><b>Note:</b> The iteration ID will wrap around to <c>1</c> after reaching its range limit.</para>
    /// </summary>
    public static uint LinkGetIterationId(Rid link)
    {
        return NativeCalls.godot_icall_1_850(MethodBind56, GodotObject.GetPtr(Singleton), link);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind57 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.LinkSetMap, 395945892ul);

    /// <summary>
    /// <para>Sets the navigation map <see cref="Godot.Rid"/> for the link.</para>
    /// </summary>
    public static void LinkSetMap(Rid link, Rid map)
    {
        NativeCalls.godot_icall_2_430(MethodBind57, GodotObject.GetPtr(Singleton), link, map);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind58 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.LinkGetMap, 3814569979ul);

    /// <summary>
    /// <para>Returns the navigation map <see cref="Godot.Rid"/> the requested <paramref name="link"/> is currently assigned to.</para>
    /// </summary>
    public static Rid LinkGetMap(Rid link)
    {
        return NativeCalls.godot_icall_1_855(MethodBind58, GodotObject.GetPtr(Singleton), link);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind59 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.LinkSetEnabled, 1265174801ul);

    /// <summary>
    /// <para>If <paramref name="enabled"/> is <see langword="true"/>, the specified <paramref name="link"/> will contribute to its current navigation map.</para>
    /// </summary>
    public static void LinkSetEnabled(Rid link, bool enabled)
    {
        NativeCalls.godot_icall_2_434(MethodBind59, GodotObject.GetPtr(Singleton), link, enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind60 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.LinkGetEnabled, 4155700596ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the specified <paramref name="link"/> is enabled.</para>
    /// </summary>
    public static bool LinkGetEnabled(Rid link)
    {
        return NativeCalls.godot_icall_1_421(MethodBind60, GodotObject.GetPtr(Singleton), link).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind61 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.LinkSetBidirectional, 1265174801ul);

    /// <summary>
    /// <para>Sets whether this <paramref name="link"/> can be travelled in both directions.</para>
    /// </summary>
    public static void LinkSetBidirectional(Rid link, bool bidirectional)
    {
        NativeCalls.godot_icall_2_434(MethodBind61, GodotObject.GetPtr(Singleton), link, bidirectional.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind62 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.LinkIsBidirectional, 4155700596ul);

    /// <summary>
    /// <para>Returns whether this <paramref name="link"/> can be travelled in both directions.</para>
    /// </summary>
    public static bool LinkIsBidirectional(Rid link)
    {
        return NativeCalls.godot_icall_1_421(MethodBind62, GodotObject.GetPtr(Singleton), link).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind63 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.LinkSetNavigationLayers, 3411492887ul);

    /// <summary>
    /// <para>Set the links's navigation layers. This allows selecting links from a path request (when using <see cref="Godot.NavigationServer2D.MapGetPath(Rid, Vector2, Vector2, bool, uint)"/>).</para>
    /// </summary>
    public static void LinkSetNavigationLayers(Rid link, uint navigationLayers)
    {
        NativeCalls.godot_icall_2_856(MethodBind63, GodotObject.GetPtr(Singleton), link, navigationLayers);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind64 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.LinkGetNavigationLayers, 2198884583ul);

    /// <summary>
    /// <para>Returns the navigation layers for this <paramref name="link"/>.</para>
    /// </summary>
    public static uint LinkGetNavigationLayers(Rid link)
    {
        return NativeCalls.godot_icall_1_850(MethodBind64, GodotObject.GetPtr(Singleton), link);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind65 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.LinkSetStartPosition, 3201125042ul);

    /// <summary>
    /// <para>Sets the entry position for this <paramref name="link"/>.</para>
    /// </summary>
    public static unsafe void LinkSetStartPosition(Rid link, Vector2 position)
    {
        NativeCalls.godot_icall_2_861(MethodBind65, GodotObject.GetPtr(Singleton), link, &position);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind66 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.LinkGetStartPosition, 2440833711ul);

    /// <summary>
    /// <para>Returns the starting position of this <paramref name="link"/>.</para>
    /// </summary>
    public static Vector2 LinkGetStartPosition(Rid link)
    {
        return NativeCalls.godot_icall_1_812(MethodBind66, GodotObject.GetPtr(Singleton), link);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind67 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.LinkSetEndPosition, 3201125042ul);

    /// <summary>
    /// <para>Sets the exit position for the <paramref name="link"/>.</para>
    /// </summary>
    public static unsafe void LinkSetEndPosition(Rid link, Vector2 position)
    {
        NativeCalls.godot_icall_2_861(MethodBind67, GodotObject.GetPtr(Singleton), link, &position);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind68 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.LinkGetEndPosition, 2440833711ul);

    /// <summary>
    /// <para>Returns the ending position of this <paramref name="link"/>.</para>
    /// </summary>
    public static Vector2 LinkGetEndPosition(Rid link)
    {
        return NativeCalls.godot_icall_1_812(MethodBind68, GodotObject.GetPtr(Singleton), link);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind69 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.LinkSetEnterCost, 1794382983ul);

    /// <summary>
    /// <para>Sets the <paramref name="enterCost"/> for this <paramref name="link"/>.</para>
    /// </summary>
    public static void LinkSetEnterCost(Rid link, float enterCost)
    {
        NativeCalls.godot_icall_2_816(MethodBind69, GodotObject.GetPtr(Singleton), link, enterCost);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind70 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.LinkGetEnterCost, 866169185ul);

    /// <summary>
    /// <para>Returns the enter cost of this <paramref name="link"/>.</para>
    /// </summary>
    public static float LinkGetEnterCost(Rid link)
    {
        return NativeCalls.godot_icall_1_817(MethodBind70, GodotObject.GetPtr(Singleton), link);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind71 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.LinkSetTravelCost, 1794382983ul);

    /// <summary>
    /// <para>Sets the <paramref name="travelCost"/> for this <paramref name="link"/>.</para>
    /// </summary>
    public static void LinkSetTravelCost(Rid link, float travelCost)
    {
        NativeCalls.godot_icall_2_816(MethodBind71, GodotObject.GetPtr(Singleton), link, travelCost);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind72 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.LinkGetTravelCost, 866169185ul);

    /// <summary>
    /// <para>Returns the travel cost of this <paramref name="link"/>.</para>
    /// </summary>
    public static float LinkGetTravelCost(Rid link)
    {
        return NativeCalls.godot_icall_1_817(MethodBind72, GodotObject.GetPtr(Singleton), link);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind73 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.LinkSetOwnerId, 3411492887ul);

    /// <summary>
    /// <para>Set the <c>ObjectID</c> of the object which manages this link.</para>
    /// </summary>
    public static void LinkSetOwnerId(Rid link, ulong ownerId)
    {
        NativeCalls.godot_icall_2_852(MethodBind73, GodotObject.GetPtr(Singleton), link, ownerId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind74 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.LinkGetOwnerId, 2198884583ul);

    /// <summary>
    /// <para>Returns the <c>ObjectID</c> of the object which manages this link.</para>
    /// </summary>
    public static ulong LinkGetOwnerId(Rid link)
    {
        return NativeCalls.godot_icall_1_853(MethodBind74, GodotObject.GetPtr(Singleton), link);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind75 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AgentCreate, 529393457ul);

    /// <summary>
    /// <para>Creates the agent.</para>
    /// </summary>
    public static Rid AgentCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind75, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind76 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AgentSetAvoidanceEnabled, 1265174801ul);

    /// <summary>
    /// <para>If <paramref name="enabled"/> is <see langword="true"/>, the specified <paramref name="agent"/> uses avoidance.</para>
    /// </summary>
    public static void AgentSetAvoidanceEnabled(Rid agent, bool enabled)
    {
        NativeCalls.godot_icall_2_434(MethodBind76, GodotObject.GetPtr(Singleton), agent, enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind77 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AgentGetAvoidanceEnabled, 4155700596ul);

    /// <summary>
    /// <para>Return <see langword="true"/> if the specified <paramref name="agent"/> uses avoidance.</para>
    /// </summary>
    public static bool AgentGetAvoidanceEnabled(Rid agent)
    {
        return NativeCalls.godot_icall_1_421(MethodBind77, GodotObject.GetPtr(Singleton), agent).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind78 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AgentSetMap, 395945892ul);

    /// <summary>
    /// <para>Puts the agent in the map.</para>
    /// </summary>
    public static void AgentSetMap(Rid agent, Rid map)
    {
        NativeCalls.godot_icall_2_430(MethodBind78, GodotObject.GetPtr(Singleton), agent, map);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind79 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AgentGetMap, 3814569979ul);

    /// <summary>
    /// <para>Returns the navigation map <see cref="Godot.Rid"/> the requested <paramref name="agent"/> is currently assigned to.</para>
    /// </summary>
    public static Rid AgentGetMap(Rid agent)
    {
        return NativeCalls.godot_icall_1_855(MethodBind79, GodotObject.GetPtr(Singleton), agent);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind80 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AgentSetPaused, 1265174801ul);

    /// <summary>
    /// <para>If <paramref name="paused"/> is <see langword="true"/> the specified <paramref name="agent"/> will not be processed. For example, it will not calculate avoidance velocities or receive avoidance callbacks.</para>
    /// </summary>
    public static void AgentSetPaused(Rid agent, bool paused)
    {
        NativeCalls.godot_icall_2_434(MethodBind80, GodotObject.GetPtr(Singleton), agent, paused.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind81 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AgentGetPaused, 4155700596ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the specified <paramref name="agent"/> is paused.</para>
    /// </summary>
    public static bool AgentGetPaused(Rid agent)
    {
        return NativeCalls.godot_icall_1_421(MethodBind81, GodotObject.GetPtr(Singleton), agent).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind82 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AgentSetNeighborDistance, 1794382983ul);

    /// <summary>
    /// <para>Sets the maximum distance to other agents this agent takes into account in the navigation. The larger this number, the longer the running time of the simulation. If the number is too low, the simulation will not be safe.</para>
    /// </summary>
    public static void AgentSetNeighborDistance(Rid agent, float distance)
    {
        NativeCalls.godot_icall_2_816(MethodBind82, GodotObject.GetPtr(Singleton), agent, distance);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind83 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AgentGetNeighborDistance, 866169185ul);

    /// <summary>
    /// <para>Returns the maximum distance to other agents the specified <paramref name="agent"/> takes into account in the navigation.</para>
    /// </summary>
    public static float AgentGetNeighborDistance(Rid agent)
    {
        return NativeCalls.godot_icall_1_817(MethodBind83, GodotObject.GetPtr(Singleton), agent);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind84 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AgentSetMaxNeighbors, 3411492887ul);

    /// <summary>
    /// <para>Sets the maximum number of other agents the agent takes into account in the navigation. The larger this number, the longer the running time of the simulation. If the number is too low, the simulation will not be safe.</para>
    /// </summary>
    public static void AgentSetMaxNeighbors(Rid agent, int count)
    {
        NativeCalls.godot_icall_2_426(MethodBind84, GodotObject.GetPtr(Singleton), agent, count);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind85 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AgentGetMaxNeighbors, 2198884583ul);

    /// <summary>
    /// <para>Returns the maximum number of other agents the specified <paramref name="agent"/> takes into account in the navigation.</para>
    /// </summary>
    public static int AgentGetMaxNeighbors(Rid agent)
    {
        return NativeCalls.godot_icall_1_835(MethodBind85, GodotObject.GetPtr(Singleton), agent);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind86 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AgentSetTimeHorizonAgents, 1794382983ul);

    /// <summary>
    /// <para>The minimal amount of time for which the agent's velocities that are computed by the simulation are safe with respect to other agents. The larger this number, the sooner this agent will respond to the presence of other agents, but the less freedom this agent has in choosing its velocities. A too high value will slow down agents movement considerably. Must be positive.</para>
    /// </summary>
    public static void AgentSetTimeHorizonAgents(Rid agent, float timeHorizon)
    {
        NativeCalls.godot_icall_2_816(MethodBind86, GodotObject.GetPtr(Singleton), agent, timeHorizon);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind87 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AgentGetTimeHorizonAgents, 866169185ul);

    /// <summary>
    /// <para>Returns the minimal amount of time for which the specified <paramref name="agent"/>'s velocities that are computed by the simulation are safe with respect to other agents.</para>
    /// </summary>
    public static float AgentGetTimeHorizonAgents(Rid agent)
    {
        return NativeCalls.godot_icall_1_817(MethodBind87, GodotObject.GetPtr(Singleton), agent);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind88 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AgentSetTimeHorizonObstacles, 1794382983ul);

    /// <summary>
    /// <para>The minimal amount of time for which the agent's velocities that are computed by the simulation are safe with respect to static avoidance obstacles. The larger this number, the sooner this agent will respond to the presence of static avoidance obstacles, but the less freedom this agent has in choosing its velocities. A too high value will slow down agents movement considerably. Must be positive.</para>
    /// </summary>
    public static void AgentSetTimeHorizonObstacles(Rid agent, float timeHorizon)
    {
        NativeCalls.godot_icall_2_816(MethodBind88, GodotObject.GetPtr(Singleton), agent, timeHorizon);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind89 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AgentGetTimeHorizonObstacles, 866169185ul);

    /// <summary>
    /// <para>Returns the minimal amount of time for which the specified <paramref name="agent"/>'s velocities that are computed by the simulation are safe with respect to static avoidance obstacles.</para>
    /// </summary>
    public static float AgentGetTimeHorizonObstacles(Rid agent)
    {
        return NativeCalls.godot_icall_1_817(MethodBind89, GodotObject.GetPtr(Singleton), agent);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind90 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AgentSetRadius, 1794382983ul);

    /// <summary>
    /// <para>Sets the radius of the agent.</para>
    /// </summary>
    public static void AgentSetRadius(Rid agent, float radius)
    {
        NativeCalls.godot_icall_2_816(MethodBind90, GodotObject.GetPtr(Singleton), agent, radius);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind91 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AgentGetRadius, 866169185ul);

    /// <summary>
    /// <para>Returns the radius of the specified <paramref name="agent"/>.</para>
    /// </summary>
    public static float AgentGetRadius(Rid agent)
    {
        return NativeCalls.godot_icall_1_817(MethodBind91, GodotObject.GetPtr(Singleton), agent);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind92 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AgentSetMaxSpeed, 1794382983ul);

    /// <summary>
    /// <para>Sets the maximum speed of the agent. Must be positive.</para>
    /// </summary>
    public static void AgentSetMaxSpeed(Rid agent, float maxSpeed)
    {
        NativeCalls.godot_icall_2_816(MethodBind92, GodotObject.GetPtr(Singleton), agent, maxSpeed);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind93 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AgentGetMaxSpeed, 866169185ul);

    /// <summary>
    /// <para>Returns the maximum speed of the specified <paramref name="agent"/>.</para>
    /// </summary>
    public static float AgentGetMaxSpeed(Rid agent)
    {
        return NativeCalls.godot_icall_1_817(MethodBind93, GodotObject.GetPtr(Singleton), agent);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind94 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AgentSetVelocityForced, 3201125042ul);

    /// <summary>
    /// <para>Replaces the internal velocity in the collision avoidance simulation with <paramref name="velocity"/> for the specified <paramref name="agent"/>. When an agent is teleported to a new position far away this function should be used in the same frame. If called frequently this function can get agents stuck.</para>
    /// </summary>
    public static unsafe void AgentSetVelocityForced(Rid agent, Vector2 velocity)
    {
        NativeCalls.godot_icall_2_861(MethodBind94, GodotObject.GetPtr(Singleton), agent, &velocity);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind95 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AgentSetVelocity, 3201125042ul);

    /// <summary>
    /// <para>Sets <paramref name="velocity"/> as the new wanted velocity for the specified <paramref name="agent"/>. The avoidance simulation will try to fulfill this velocity if possible but will modify it to avoid collision with other agent's and obstacles. When an agent is teleported to a new position far away use <see cref="Godot.NavigationServer2D.AgentSetVelocityForced(Rid, Vector2)"/> instead to reset the internal velocity state.</para>
    /// </summary>
    public static unsafe void AgentSetVelocity(Rid agent, Vector2 velocity)
    {
        NativeCalls.godot_icall_2_861(MethodBind95, GodotObject.GetPtr(Singleton), agent, &velocity);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind96 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AgentGetVelocity, 2440833711ul);

    /// <summary>
    /// <para>Returns the velocity of the specified <paramref name="agent"/>.</para>
    /// </summary>
    public static Vector2 AgentGetVelocity(Rid agent)
    {
        return NativeCalls.godot_icall_1_812(MethodBind96, GodotObject.GetPtr(Singleton), agent);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind97 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AgentSetPosition, 3201125042ul);

    /// <summary>
    /// <para>Sets the position of the agent in world space.</para>
    /// </summary>
    public static unsafe void AgentSetPosition(Rid agent, Vector2 position)
    {
        NativeCalls.godot_icall_2_861(MethodBind97, GodotObject.GetPtr(Singleton), agent, &position);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind98 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AgentGetPosition, 2440833711ul);

    /// <summary>
    /// <para>Returns the position of the specified <paramref name="agent"/> in world space.</para>
    /// </summary>
    public static Vector2 AgentGetPosition(Rid agent)
    {
        return NativeCalls.godot_icall_1_812(MethodBind98, GodotObject.GetPtr(Singleton), agent);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind99 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AgentIsMapChanged, 4155700596ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the map got changed the previous frame.</para>
    /// </summary>
    public static bool AgentIsMapChanged(Rid agent)
    {
        return NativeCalls.godot_icall_1_421(MethodBind99, GodotObject.GetPtr(Singleton), agent).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind100 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AgentSetAvoidanceCallback, 3379118538ul);

    /// <summary>
    /// <para>Sets the callback <see cref="Godot.Callable"/> that gets called after each avoidance processing step for the <paramref name="agent"/>. The calculated <c>safe_velocity</c> will be dispatched with a signal to the object just before the physics calculations.</para>
    /// <para><b>Note:</b> Created callbacks are always processed independently of the SceneTree state as long as the agent is on a navigation map and not freed. To disable the dispatch of a callback from an agent use <see cref="Godot.NavigationServer2D.AgentSetAvoidanceCallback(Rid, Callable)"/> again with an empty <see cref="Godot.Callable"/>.</para>
    /// </summary>
    public static void AgentSetAvoidanceCallback(Rid agent, Callable callback)
    {
        NativeCalls.godot_icall_2_814(MethodBind100, GodotObject.GetPtr(Singleton), agent, callback);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind101 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AgentHasAvoidanceCallback, 4155700596ul);

    /// <summary>
    /// <para>Return <see langword="true"/> if the specified <paramref name="agent"/> has an avoidance callback.</para>
    /// </summary>
    public static bool AgentHasAvoidanceCallback(Rid agent)
    {
        return NativeCalls.godot_icall_1_421(MethodBind101, GodotObject.GetPtr(Singleton), agent).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind102 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AgentSetAvoidanceLayers, 3411492887ul);

    /// <summary>
    /// <para>Set the agent's <c>avoidance_layers</c> bitmask.</para>
    /// </summary>
    public static void AgentSetAvoidanceLayers(Rid agent, uint layers)
    {
        NativeCalls.godot_icall_2_856(MethodBind102, GodotObject.GetPtr(Singleton), agent, layers);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind103 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AgentGetAvoidanceLayers, 2198884583ul);

    /// <summary>
    /// <para>Returns the <c>avoidance_layers</c> bitmask of the specified <paramref name="agent"/>.</para>
    /// </summary>
    public static uint AgentGetAvoidanceLayers(Rid agent)
    {
        return NativeCalls.godot_icall_1_850(MethodBind103, GodotObject.GetPtr(Singleton), agent);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind104 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AgentSetAvoidanceMask, 3411492887ul);

    /// <summary>
    /// <para>Set the agent's <c>avoidance_mask</c> bitmask.</para>
    /// </summary>
    public static void AgentSetAvoidanceMask(Rid agent, uint mask)
    {
        NativeCalls.godot_icall_2_856(MethodBind104, GodotObject.GetPtr(Singleton), agent, mask);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind105 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AgentGetAvoidanceMask, 2198884583ul);

    /// <summary>
    /// <para>Returns the <c>avoidance_mask</c> bitmask of the specified <paramref name="agent"/>.</para>
    /// </summary>
    public static uint AgentGetAvoidanceMask(Rid agent)
    {
        return NativeCalls.godot_icall_1_850(MethodBind105, GodotObject.GetPtr(Singleton), agent);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind106 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AgentSetAvoidancePriority, 1794382983ul);

    /// <summary>
    /// <para>Set the agent's <c>avoidance_priority</c> with a <paramref name="priority"/> between 0.0 (lowest priority) to 1.0 (highest priority).</para>
    /// <para>The specified <paramref name="agent"/> does not adjust the velocity for other agents that would match the <c>avoidance_mask</c> but have a lower <c>avoidance_priority</c>. This in turn makes the other agents with lower priority adjust their velocities even more to avoid collision with this agent.</para>
    /// </summary>
    public static void AgentSetAvoidancePriority(Rid agent, float priority)
    {
        NativeCalls.godot_icall_2_816(MethodBind106, GodotObject.GetPtr(Singleton), agent, priority);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind107 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AgentGetAvoidancePriority, 866169185ul);

    /// <summary>
    /// <para>Returns the <c>avoidance_priority</c> of the specified <paramref name="agent"/>.</para>
    /// </summary>
    public static float AgentGetAvoidancePriority(Rid agent)
    {
        return NativeCalls.godot_icall_1_817(MethodBind107, GodotObject.GetPtr(Singleton), agent);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind108 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ObstacleCreate, 529393457ul);

    /// <summary>
    /// <para>Creates a new navigation obstacle.</para>
    /// </summary>
    public static Rid ObstacleCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind108, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind109 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ObstacleSetAvoidanceEnabled, 1265174801ul);

    /// <summary>
    /// <para>If <paramref name="enabled"/> is <see langword="true"/>, the provided <paramref name="obstacle"/> affects avoidance using agents.</para>
    /// </summary>
    public static void ObstacleSetAvoidanceEnabled(Rid obstacle, bool enabled)
    {
        NativeCalls.godot_icall_2_434(MethodBind109, GodotObject.GetPtr(Singleton), obstacle, enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind110 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ObstacleGetAvoidanceEnabled, 4155700596ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the provided <paramref name="obstacle"/> has avoidance enabled.</para>
    /// </summary>
    public static bool ObstacleGetAvoidanceEnabled(Rid obstacle)
    {
        return NativeCalls.godot_icall_1_421(MethodBind110, GodotObject.GetPtr(Singleton), obstacle).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind111 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ObstacleSetMap, 395945892ul);

    /// <summary>
    /// <para>Sets the navigation map <see cref="Godot.Rid"/> for the obstacle.</para>
    /// </summary>
    public static void ObstacleSetMap(Rid obstacle, Rid map)
    {
        NativeCalls.godot_icall_2_430(MethodBind111, GodotObject.GetPtr(Singleton), obstacle, map);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind112 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ObstacleGetMap, 3814569979ul);

    /// <summary>
    /// <para>Returns the navigation map <see cref="Godot.Rid"/> the requested <paramref name="obstacle"/> is currently assigned to.</para>
    /// </summary>
    public static Rid ObstacleGetMap(Rid obstacle)
    {
        return NativeCalls.godot_icall_1_855(MethodBind112, GodotObject.GetPtr(Singleton), obstacle);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind113 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ObstacleSetPaused, 1265174801ul);

    /// <summary>
    /// <para>If <paramref name="paused"/> is <see langword="true"/> the specified <paramref name="obstacle"/> will not be processed. For example, it will no longer affect avoidance velocities.</para>
    /// </summary>
    public static void ObstacleSetPaused(Rid obstacle, bool paused)
    {
        NativeCalls.godot_icall_2_434(MethodBind113, GodotObject.GetPtr(Singleton), obstacle, paused.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind114 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ObstacleGetPaused, 4155700596ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the specified <paramref name="obstacle"/> is paused.</para>
    /// </summary>
    public static bool ObstacleGetPaused(Rid obstacle)
    {
        return NativeCalls.godot_icall_1_421(MethodBind114, GodotObject.GetPtr(Singleton), obstacle).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind115 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ObstacleSetRadius, 1794382983ul);

    /// <summary>
    /// <para>Sets the radius of the dynamic obstacle.</para>
    /// </summary>
    public static void ObstacleSetRadius(Rid obstacle, float radius)
    {
        NativeCalls.godot_icall_2_816(MethodBind115, GodotObject.GetPtr(Singleton), obstacle, radius);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind116 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ObstacleGetRadius, 866169185ul);

    /// <summary>
    /// <para>Returns the radius of the specified dynamic <paramref name="obstacle"/>.</para>
    /// </summary>
    public static float ObstacleGetRadius(Rid obstacle)
    {
        return NativeCalls.godot_icall_1_817(MethodBind116, GodotObject.GetPtr(Singleton), obstacle);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind117 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ObstacleSetVelocity, 3201125042ul);

    /// <summary>
    /// <para>Sets <paramref name="velocity"/> of the dynamic <paramref name="obstacle"/>. Allows other agents to better predict the movement of the dynamic obstacle. Only works in combination with the radius of the obstacle.</para>
    /// </summary>
    public static unsafe void ObstacleSetVelocity(Rid obstacle, Vector2 velocity)
    {
        NativeCalls.godot_icall_2_861(MethodBind117, GodotObject.GetPtr(Singleton), obstacle, &velocity);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind118 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ObstacleGetVelocity, 2440833711ul);

    /// <summary>
    /// <para>Returns the velocity of the specified dynamic <paramref name="obstacle"/>.</para>
    /// </summary>
    public static Vector2 ObstacleGetVelocity(Rid obstacle)
    {
        return NativeCalls.godot_icall_1_812(MethodBind118, GodotObject.GetPtr(Singleton), obstacle);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind119 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ObstacleSetPosition, 3201125042ul);

    /// <summary>
    /// <para>Sets the position of the obstacle in world space.</para>
    /// </summary>
    public static unsafe void ObstacleSetPosition(Rid obstacle, Vector2 position)
    {
        NativeCalls.godot_icall_2_861(MethodBind119, GodotObject.GetPtr(Singleton), obstacle, &position);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind120 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ObstacleGetPosition, 2440833711ul);

    /// <summary>
    /// <para>Returns the position of the specified <paramref name="obstacle"/> in world space.</para>
    /// </summary>
    public static Vector2 ObstacleGetPosition(Rid obstacle)
    {
        return NativeCalls.godot_icall_1_812(MethodBind120, GodotObject.GetPtr(Singleton), obstacle);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind121 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ObstacleSetVertices, 29476483ul);

    /// <summary>
    /// <para>Sets the outline vertices for the obstacle. If the vertices are winded in clockwise order agents will be pushed in by the obstacle, else they will be pushed out.</para>
    /// </summary>
    public static void ObstacleSetVertices(Rid obstacle, Vector2[] vertices)
    {
        NativeCalls.godot_icall_2_862(MethodBind121, GodotObject.GetPtr(Singleton), obstacle, vertices);
    }

    /// <summary>
    /// <para>Sets the outline vertices for the obstacle. If the vertices are winded in clockwise order agents will be pushed in by the obstacle, else they will be pushed out.</para>
    /// </summary>
    public static void ObstacleSetVertices(Rid obstacle, ReadOnlySpan<Vector2> vertices)
    {
        NativeCalls.godot_icall_2_862(MethodBind121, GodotObject.GetPtr(Singleton), obstacle, vertices);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind122 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ObstacleGetVertices, 2222557395ul);

    /// <summary>
    /// <para>Returns the outline vertices for the specified <paramref name="obstacle"/>.</para>
    /// </summary>
    public static Vector2[] ObstacleGetVertices(Rid obstacle)
    {
        return NativeCalls.godot_icall_1_863(MethodBind122, GodotObject.GetPtr(Singleton), obstacle);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind123 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ObstacleSetAvoidanceLayers, 3411492887ul);

    /// <summary>
    /// <para>Set the obstacles's <c>avoidance_layers</c> bitmask.</para>
    /// </summary>
    public static void ObstacleSetAvoidanceLayers(Rid obstacle, uint layers)
    {
        NativeCalls.godot_icall_2_856(MethodBind123, GodotObject.GetPtr(Singleton), obstacle, layers);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind124 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ObstacleGetAvoidanceLayers, 2198884583ul);

    /// <summary>
    /// <para>Returns the <c>avoidance_layers</c> bitmask of the specified <paramref name="obstacle"/>.</para>
    /// </summary>
    public static uint ObstacleGetAvoidanceLayers(Rid obstacle)
    {
        return NativeCalls.godot_icall_1_850(MethodBind124, GodotObject.GetPtr(Singleton), obstacle);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind125 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ParseSourceGeometryData, 1766905497ul);

    /// <summary>
    /// <para>Parses the <see cref="Godot.SceneTree"/> for source geometry according to the properties of <paramref name="navigationPolygon"/>. Updates the provided <paramref name="sourceGeometryData"/> resource with the resulting data. The resource can then be used to bake a navigation mesh with <see cref="Godot.NavigationServer2D.BakeFromSourceGeometryData(NavigationPolygon, NavigationMeshSourceGeometryData2D, Callable)"/>. After the process is finished the optional <paramref name="callback"/> will be called.</para>
    /// <para><b>Note:</b> This function needs to run on the main thread or with a deferred call as the SceneTree is not thread-safe.</para>
    /// <para><b>Performance:</b> While convenient, reading data arrays from <see cref="Godot.Mesh"/> resources can affect the frame rate negatively. The data needs to be received from the GPU, stalling the <see cref="Godot.RenderingServer"/> in the process. For performance prefer the use of e.g. collision shapes or creating the data arrays entirely in code.</para>
    /// </summary>
    public static void ParseSourceGeometryData(NavigationPolygon navigationPolygon, NavigationMeshSourceGeometryData2D sourceGeometryData, Node rootNode, Callable callback = default)
    {
        NativeCalls.godot_icall_4_836(MethodBind125, GodotObject.GetPtr(Singleton), GodotObject.GetPtr(navigationPolygon), GodotObject.GetPtr(sourceGeometryData), GodotObject.GetPtr(rootNode), callback);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind126 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.BakeFromSourceGeometryData, 2179660022ul);

    /// <summary>
    /// <para>Bakes the provided <paramref name="navigationPolygon"/> with the data from the provided <paramref name="sourceGeometryData"/>. After the process is finished the optional <paramref name="callback"/> will be called.</para>
    /// </summary>
    public static void BakeFromSourceGeometryData(NavigationPolygon navigationPolygon, NavigationMeshSourceGeometryData2D sourceGeometryData, Callable callback = default)
    {
        NativeCalls.godot_icall_3_837(MethodBind126, GodotObject.GetPtr(Singleton), GodotObject.GetPtr(navigationPolygon), GodotObject.GetPtr(sourceGeometryData), callback);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind127 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.BakeFromSourceGeometryDataAsync, 2179660022ul);

    /// <summary>
    /// <para>Bakes the provided <paramref name="navigationPolygon"/> with the data from the provided <paramref name="sourceGeometryData"/> as an async task running on a background thread. After the process is finished the optional <paramref name="callback"/> will be called.</para>
    /// </summary>
    public static void BakeFromSourceGeometryDataAsync(NavigationPolygon navigationPolygon, NavigationMeshSourceGeometryData2D sourceGeometryData, Callable callback = default)
    {
        NativeCalls.godot_icall_3_837(MethodBind127, GodotObject.GetPtr(Singleton), GodotObject.GetPtr(navigationPolygon), GodotObject.GetPtr(sourceGeometryData), callback);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind128 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.IsBakingNavigationPolygon, 3729405808ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> when the provided navigation polygon is being baked on a background thread.</para>
    /// </summary>
    public static bool IsBakingNavigationPolygon(NavigationPolygon navigationPolygon)
    {
        return NativeCalls.godot_icall_1_176(MethodBind128, GodotObject.GetPtr(Singleton), GodotObject.GetPtr(navigationPolygon)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind129 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SourceGeometryParserCreate, 529393457ul);

    /// <summary>
    /// <para>Creates a new source geometry parser. If a <see cref="Godot.Callable"/> is set for the parser with <see cref="Godot.NavigationServer2D.SourceGeometryParserSetCallback(Rid, Callable)"/> the callback will be called for every single node that gets parsed whenever <see cref="Godot.NavigationServer2D.ParseSourceGeometryData(NavigationPolygon, NavigationMeshSourceGeometryData2D, Node, Callable)"/> is used.</para>
    /// </summary>
    public static Rid SourceGeometryParserCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind129, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind130 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SourceGeometryParserSetCallback, 3379118538ul);

    /// <summary>
    /// <para>Sets the <paramref name="callback"/> <see cref="Godot.Callable"/> for the specific source geometry <paramref name="parser"/>. The <see cref="Godot.Callable"/> will receive a call with the following parameters:</para>
    /// <para>- <c>navigation_mesh</c> - The <see cref="Godot.NavigationPolygon"/> reference used to define the parse settings. Do NOT edit or add directly to the navigation mesh.</para>
    /// <para>- <c>source_geometry_data</c> - The <see cref="Godot.NavigationMeshSourceGeometryData2D"/> reference. Add custom source geometry for navigation mesh baking to this object.</para>
    /// <para>- <c>node</c> - The <see cref="Godot.Node"/> that is parsed.</para>
    /// </summary>
    public static void SourceGeometryParserSetCallback(Rid parser, Callable callback)
    {
        NativeCalls.godot_icall_2_814(MethodBind130, GodotObject.GetPtr(Singleton), parser, callback);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind131 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SimplifyPath, 2457191505ul);

    /// <summary>
    /// <para>Returns a simplified version of <paramref name="path"/> with less critical path points removed. The simplification amount is in worlds units and controlled by <paramref name="epsilon"/>. The simplification uses a variant of Ramer-Douglas-Peucker algorithm for curve point decimation.</para>
    /// <para>Path simplification can be helpful to mitigate various path following issues that can arise with certain agent types and script behaviors. E.g. "steering" agents or avoidance in "open fields".</para>
    /// </summary>
    public static Vector2[] SimplifyPath(Vector2[] path, float epsilon)
    {
        return NativeCalls.godot_icall_2_864(MethodBind131, GodotObject.GetPtr(Singleton), path, epsilon);
    }

    /// <summary>
    /// <para>Returns a simplified version of <paramref name="path"/> with less critical path points removed. The simplification amount is in worlds units and controlled by <paramref name="epsilon"/>. The simplification uses a variant of Ramer-Douglas-Peucker algorithm for curve point decimation.</para>
    /// <para>Path simplification can be helpful to mitigate various path following issues that can arise with certain agent types and script behaviors. E.g. "steering" agents or avoidance in "open fields".</para>
    /// </summary>
    public static Vector2[] SimplifyPath(ReadOnlySpan<Vector2> path, float epsilon)
    {
        return NativeCalls.godot_icall_2_864(MethodBind131, GodotObject.GetPtr(Singleton), path, epsilon);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind132 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.FreeRid, 2722037293ul);

    /// <summary>
    /// <para>Destroys the given RID.</para>
    /// </summary>
    public static void FreeRid(Rid rid)
    {
        NativeCalls.godot_icall_1_286(MethodBind132, GodotObject.GetPtr(Singleton), rid);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind133 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SetActive, 2586408642ul);

    /// <summary>
    /// <para>Control activation of this server.</para>
    /// </summary>
    public static void SetActive(bool active)
    {
        NativeCalls.godot_icall_1_14(MethodBind133, GodotObject.GetPtr(Singleton), active.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind134 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDebugEnabled, 2586408642ul);

    /// <summary>
    /// <para>If <see langword="true"/> enables debug mode on the NavigationServer.</para>
    /// </summary>
    public static void SetDebugEnabled(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind134, GodotObject.GetPtr(Singleton), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind135 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDebugEnabled, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> when the NavigationServer has debug enabled.</para>
    /// </summary>
    public static bool GetDebugEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind135, GodotObject.GetPtr(Singleton)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind136 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetProcessInfo, 1640219858ul);

    /// <summary>
    /// <para>Returns information about the current state of the NavigationServer.</para>
    /// </summary>
    public static int GetProcessInfo(NavigationServer2D.ProcessInfo processInfo)
    {
        return NativeCalls.godot_icall_1_60(MethodBind136, GodotObject.GetPtr(Singleton), (int)processInfo);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind137 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.QueryPath, 3394638789ul);

    /// <summary>
    /// <para>Queries a path in a given navigation map. Start and target position and other parameters are defined through <see cref="Godot.NavigationPathQueryParameters2D"/>. Updates the provided <see cref="Godot.NavigationPathQueryResult2D"/> result object with the path among other results requested by the query. After the process is finished the optional <paramref name="callback"/> will be called.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static void QueryPath(NavigationPathQueryParameters2D parameters, NavigationPathQueryResult2D result)
    {
        NativeCalls.godot_icall_2_239(MethodBind137, GodotObject.GetPtr(Singleton), GodotObject.GetPtr(parameters), GodotObject.GetPtr(result));
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.NavigationServer2D.MapChanged"/> event of a <see cref="Godot.NavigationServer2D"/> class.
    /// </summary>
    public delegate void MapChangedEventHandler(Rid map);

    private static void MapChangedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((MapChangedEventHandler)delegateObj)(VariantUtils.ConvertTo<Rid>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when a navigation map is updated, when a region moves or is modified.</para>
    /// </summary>
    public static unsafe event MapChangedEventHandler MapChanged
    {
        add => Singleton.Connect(SignalName.MapChanged, Callable.CreateWithUnsafeTrampoline(value, &MapChangedTrampoline));
        remove => Singleton.Disconnect(SignalName.MapChanged, Callable.CreateWithUnsafeTrampoline(value, &MapChangedTrampoline));
    }

    /// <summary>
    /// <para>Emitted when navigation debug settings are changed. Only available in debug builds.</para>
    /// </summary>
    public static event Action NavigationDebugChanged
    {
        add => Singleton.Connect(SignalName.NavigationDebugChanged, Callable.From(value));
        remove => Singleton.Disconnect(SignalName.NavigationDebugChanged, Callable.From(value));
    }

    /// <summary>
    /// <para>Emitted when avoidance debug settings are changed. Only available in debug builds.</para>
    /// </summary>
    public static event Action AvoidanceDebugChanged
    {
        add => Singleton.Connect(SignalName.AvoidanceDebugChanged, Callable.From(value));
        remove => Singleton.Disconnect(SignalName.AvoidanceDebugChanged, Callable.From(value));
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
        /// Cached name for the 'get_maps' method.
        /// </summary>
        public static readonly StringName GetMaps = "get_maps";
        /// <summary>
        /// Cached name for the 'map_create' method.
        /// </summary>
        public static readonly StringName MapCreate = "map_create";
        /// <summary>
        /// Cached name for the 'map_set_active' method.
        /// </summary>
        public static readonly StringName MapSetActive = "map_set_active";
        /// <summary>
        /// Cached name for the 'map_is_active' method.
        /// </summary>
        public static readonly StringName MapIsActive = "map_is_active";
        /// <summary>
        /// Cached name for the 'map_set_cell_size' method.
        /// </summary>
        public static readonly StringName MapSetCellSize = "map_set_cell_size";
        /// <summary>
        /// Cached name for the 'map_get_cell_size' method.
        /// </summary>
        public static readonly StringName MapGetCellSize = "map_get_cell_size";
        /// <summary>
        /// Cached name for the 'map_set_merge_rasterizer_cell_scale' method.
        /// </summary>
        public static readonly StringName MapSetMergeRasterizerCellScale = "map_set_merge_rasterizer_cell_scale";
        /// <summary>
        /// Cached name for the 'map_get_merge_rasterizer_cell_scale' method.
        /// </summary>
        public static readonly StringName MapGetMergeRasterizerCellScale = "map_get_merge_rasterizer_cell_scale";
        /// <summary>
        /// Cached name for the 'map_set_use_edge_connections' method.
        /// </summary>
        public static readonly StringName MapSetUseEdgeConnections = "map_set_use_edge_connections";
        /// <summary>
        /// Cached name for the 'map_get_use_edge_connections' method.
        /// </summary>
        public static readonly StringName MapGetUseEdgeConnections = "map_get_use_edge_connections";
        /// <summary>
        /// Cached name for the 'map_set_edge_connection_margin' method.
        /// </summary>
        public static readonly StringName MapSetEdgeConnectionMargin = "map_set_edge_connection_margin";
        /// <summary>
        /// Cached name for the 'map_get_edge_connection_margin' method.
        /// </summary>
        public static readonly StringName MapGetEdgeConnectionMargin = "map_get_edge_connection_margin";
        /// <summary>
        /// Cached name for the 'map_set_link_connection_radius' method.
        /// </summary>
        public static readonly StringName MapSetLinkConnectionRadius = "map_set_link_connection_radius";
        /// <summary>
        /// Cached name for the 'map_get_link_connection_radius' method.
        /// </summary>
        public static readonly StringName MapGetLinkConnectionRadius = "map_get_link_connection_radius";
        /// <summary>
        /// Cached name for the 'map_get_path' method.
        /// </summary>
        public static readonly StringName MapGetPath = "map_get_path";
        /// <summary>
        /// Cached name for the 'map_get_closest_point' method.
        /// </summary>
        public static readonly StringName MapGetClosestPoint = "map_get_closest_point";
        /// <summary>
        /// Cached name for the 'map_get_closest_point_owner' method.
        /// </summary>
        public static readonly StringName MapGetClosestPointOwner = "map_get_closest_point_owner";
        /// <summary>
        /// Cached name for the 'map_get_links' method.
        /// </summary>
        public static readonly StringName MapGetLinks = "map_get_links";
        /// <summary>
        /// Cached name for the 'map_get_regions' method.
        /// </summary>
        public static readonly StringName MapGetRegions = "map_get_regions";
        /// <summary>
        /// Cached name for the 'map_get_agents' method.
        /// </summary>
        public static readonly StringName MapGetAgents = "map_get_agents";
        /// <summary>
        /// Cached name for the 'map_get_obstacles' method.
        /// </summary>
        public static readonly StringName MapGetObstacles = "map_get_obstacles";
        /// <summary>
        /// Cached name for the 'map_force_update' method.
        /// </summary>
        public static readonly StringName MapForceUpdate = "map_force_update";
        /// <summary>
        /// Cached name for the 'map_get_iteration_id' method.
        /// </summary>
        public static readonly StringName MapGetIterationId = "map_get_iteration_id";
        /// <summary>
        /// Cached name for the 'map_set_use_async_iterations' method.
        /// </summary>
        public static readonly StringName MapSetUseAsyncIterations = "map_set_use_async_iterations";
        /// <summary>
        /// Cached name for the 'map_get_use_async_iterations' method.
        /// </summary>
        public static readonly StringName MapGetUseAsyncIterations = "map_get_use_async_iterations";
        /// <summary>
        /// Cached name for the 'map_get_random_point' method.
        /// </summary>
        public static readonly StringName MapGetRandomPoint = "map_get_random_point";
        /// <summary>
        /// Cached name for the 'query_path' method.
        /// </summary>
        public static readonly StringName QueryPath = "query_path";
        /// <summary>
        /// Cached name for the 'region_create' method.
        /// </summary>
        public static readonly StringName RegionCreate = "region_create";
        /// <summary>
        /// Cached name for the 'region_get_iteration_id' method.
        /// </summary>
        public static readonly StringName RegionGetIterationId = "region_get_iteration_id";
        /// <summary>
        /// Cached name for the 'region_set_use_async_iterations' method.
        /// </summary>
        public static readonly StringName RegionSetUseAsyncIterations = "region_set_use_async_iterations";
        /// <summary>
        /// Cached name for the 'region_get_use_async_iterations' method.
        /// </summary>
        public static readonly StringName RegionGetUseAsyncIterations = "region_get_use_async_iterations";
        /// <summary>
        /// Cached name for the 'region_set_enabled' method.
        /// </summary>
        public static readonly StringName RegionSetEnabled = "region_set_enabled";
        /// <summary>
        /// Cached name for the 'region_get_enabled' method.
        /// </summary>
        public static readonly StringName RegionGetEnabled = "region_get_enabled";
        /// <summary>
        /// Cached name for the 'region_set_use_edge_connections' method.
        /// </summary>
        public static readonly StringName RegionSetUseEdgeConnections = "region_set_use_edge_connections";
        /// <summary>
        /// Cached name for the 'region_get_use_edge_connections' method.
        /// </summary>
        public static readonly StringName RegionGetUseEdgeConnections = "region_get_use_edge_connections";
        /// <summary>
        /// Cached name for the 'region_set_enter_cost' method.
        /// </summary>
        public static readonly StringName RegionSetEnterCost = "region_set_enter_cost";
        /// <summary>
        /// Cached name for the 'region_get_enter_cost' method.
        /// </summary>
        public static readonly StringName RegionGetEnterCost = "region_get_enter_cost";
        /// <summary>
        /// Cached name for the 'region_set_travel_cost' method.
        /// </summary>
        public static readonly StringName RegionSetTravelCost = "region_set_travel_cost";
        /// <summary>
        /// Cached name for the 'region_get_travel_cost' method.
        /// </summary>
        public static readonly StringName RegionGetTravelCost = "region_get_travel_cost";
        /// <summary>
        /// Cached name for the 'region_set_owner_id' method.
        /// </summary>
        public static readonly StringName RegionSetOwnerId = "region_set_owner_id";
        /// <summary>
        /// Cached name for the 'region_get_owner_id' method.
        /// </summary>
        public static readonly StringName RegionGetOwnerId = "region_get_owner_id";
        /// <summary>
        /// Cached name for the 'region_owns_point' method.
        /// </summary>
        public static readonly StringName RegionOwnsPoint = "region_owns_point";
        /// <summary>
        /// Cached name for the 'region_set_map' method.
        /// </summary>
        public static readonly StringName RegionSetMap = "region_set_map";
        /// <summary>
        /// Cached name for the 'region_get_map' method.
        /// </summary>
        public static readonly StringName RegionGetMap = "region_get_map";
        /// <summary>
        /// Cached name for the 'region_set_navigation_layers' method.
        /// </summary>
        public static readonly StringName RegionSetNavigationLayers = "region_set_navigation_layers";
        /// <summary>
        /// Cached name for the 'region_get_navigation_layers' method.
        /// </summary>
        public static readonly StringName RegionGetNavigationLayers = "region_get_navigation_layers";
        /// <summary>
        /// Cached name for the 'region_set_transform' method.
        /// </summary>
        public static readonly StringName RegionSetTransform = "region_set_transform";
        /// <summary>
        /// Cached name for the 'region_get_transform' method.
        /// </summary>
        public static readonly StringName RegionGetTransform = "region_get_transform";
        /// <summary>
        /// Cached name for the 'region_set_navigation_polygon' method.
        /// </summary>
        public static readonly StringName RegionSetNavigationPolygon = "region_set_navigation_polygon";
        /// <summary>
        /// Cached name for the 'region_get_connections_count' method.
        /// </summary>
        public static readonly StringName RegionGetConnectionsCount = "region_get_connections_count";
        /// <summary>
        /// Cached name for the 'region_get_connection_pathway_start' method.
        /// </summary>
        public static readonly StringName RegionGetConnectionPathwayStart = "region_get_connection_pathway_start";
        /// <summary>
        /// Cached name for the 'region_get_connection_pathway_end' method.
        /// </summary>
        public static readonly StringName RegionGetConnectionPathwayEnd = "region_get_connection_pathway_end";
        /// <summary>
        /// Cached name for the 'region_get_closest_point' method.
        /// </summary>
        public static readonly StringName RegionGetClosestPoint = "region_get_closest_point";
        /// <summary>
        /// Cached name for the 'region_get_random_point' method.
        /// </summary>
        public static readonly StringName RegionGetRandomPoint = "region_get_random_point";
        /// <summary>
        /// Cached name for the 'region_get_bounds' method.
        /// </summary>
        public static readonly StringName RegionGetBounds = "region_get_bounds";
        /// <summary>
        /// Cached name for the 'link_create' method.
        /// </summary>
        public static readonly StringName LinkCreate = "link_create";
        /// <summary>
        /// Cached name for the 'link_get_iteration_id' method.
        /// </summary>
        public static readonly StringName LinkGetIterationId = "link_get_iteration_id";
        /// <summary>
        /// Cached name for the 'link_set_map' method.
        /// </summary>
        public static readonly StringName LinkSetMap = "link_set_map";
        /// <summary>
        /// Cached name for the 'link_get_map' method.
        /// </summary>
        public static readonly StringName LinkGetMap = "link_get_map";
        /// <summary>
        /// Cached name for the 'link_set_enabled' method.
        /// </summary>
        public static readonly StringName LinkSetEnabled = "link_set_enabled";
        /// <summary>
        /// Cached name for the 'link_get_enabled' method.
        /// </summary>
        public static readonly StringName LinkGetEnabled = "link_get_enabled";
        /// <summary>
        /// Cached name for the 'link_set_bidirectional' method.
        /// </summary>
        public static readonly StringName LinkSetBidirectional = "link_set_bidirectional";
        /// <summary>
        /// Cached name for the 'link_is_bidirectional' method.
        /// </summary>
        public static readonly StringName LinkIsBidirectional = "link_is_bidirectional";
        /// <summary>
        /// Cached name for the 'link_set_navigation_layers' method.
        /// </summary>
        public static readonly StringName LinkSetNavigationLayers = "link_set_navigation_layers";
        /// <summary>
        /// Cached name for the 'link_get_navigation_layers' method.
        /// </summary>
        public static readonly StringName LinkGetNavigationLayers = "link_get_navigation_layers";
        /// <summary>
        /// Cached name for the 'link_set_start_position' method.
        /// </summary>
        public static readonly StringName LinkSetStartPosition = "link_set_start_position";
        /// <summary>
        /// Cached name for the 'link_get_start_position' method.
        /// </summary>
        public static readonly StringName LinkGetStartPosition = "link_get_start_position";
        /// <summary>
        /// Cached name for the 'link_set_end_position' method.
        /// </summary>
        public static readonly StringName LinkSetEndPosition = "link_set_end_position";
        /// <summary>
        /// Cached name for the 'link_get_end_position' method.
        /// </summary>
        public static readonly StringName LinkGetEndPosition = "link_get_end_position";
        /// <summary>
        /// Cached name for the 'link_set_enter_cost' method.
        /// </summary>
        public static readonly StringName LinkSetEnterCost = "link_set_enter_cost";
        /// <summary>
        /// Cached name for the 'link_get_enter_cost' method.
        /// </summary>
        public static readonly StringName LinkGetEnterCost = "link_get_enter_cost";
        /// <summary>
        /// Cached name for the 'link_set_travel_cost' method.
        /// </summary>
        public static readonly StringName LinkSetTravelCost = "link_set_travel_cost";
        /// <summary>
        /// Cached name for the 'link_get_travel_cost' method.
        /// </summary>
        public static readonly StringName LinkGetTravelCost = "link_get_travel_cost";
        /// <summary>
        /// Cached name for the 'link_set_owner_id' method.
        /// </summary>
        public static readonly StringName LinkSetOwnerId = "link_set_owner_id";
        /// <summary>
        /// Cached name for the 'link_get_owner_id' method.
        /// </summary>
        public static readonly StringName LinkGetOwnerId = "link_get_owner_id";
        /// <summary>
        /// Cached name for the 'agent_create' method.
        /// </summary>
        public static readonly StringName AgentCreate = "agent_create";
        /// <summary>
        /// Cached name for the 'agent_set_avoidance_enabled' method.
        /// </summary>
        public static readonly StringName AgentSetAvoidanceEnabled = "agent_set_avoidance_enabled";
        /// <summary>
        /// Cached name for the 'agent_get_avoidance_enabled' method.
        /// </summary>
        public static readonly StringName AgentGetAvoidanceEnabled = "agent_get_avoidance_enabled";
        /// <summary>
        /// Cached name for the 'agent_set_map' method.
        /// </summary>
        public static readonly StringName AgentSetMap = "agent_set_map";
        /// <summary>
        /// Cached name for the 'agent_get_map' method.
        /// </summary>
        public static readonly StringName AgentGetMap = "agent_get_map";
        /// <summary>
        /// Cached name for the 'agent_set_paused' method.
        /// </summary>
        public static readonly StringName AgentSetPaused = "agent_set_paused";
        /// <summary>
        /// Cached name for the 'agent_get_paused' method.
        /// </summary>
        public static readonly StringName AgentGetPaused = "agent_get_paused";
        /// <summary>
        /// Cached name for the 'agent_set_neighbor_distance' method.
        /// </summary>
        public static readonly StringName AgentSetNeighborDistance = "agent_set_neighbor_distance";
        /// <summary>
        /// Cached name for the 'agent_get_neighbor_distance' method.
        /// </summary>
        public static readonly StringName AgentGetNeighborDistance = "agent_get_neighbor_distance";
        /// <summary>
        /// Cached name for the 'agent_set_max_neighbors' method.
        /// </summary>
        public static readonly StringName AgentSetMaxNeighbors = "agent_set_max_neighbors";
        /// <summary>
        /// Cached name for the 'agent_get_max_neighbors' method.
        /// </summary>
        public static readonly StringName AgentGetMaxNeighbors = "agent_get_max_neighbors";
        /// <summary>
        /// Cached name for the 'agent_set_time_horizon_agents' method.
        /// </summary>
        public static readonly StringName AgentSetTimeHorizonAgents = "agent_set_time_horizon_agents";
        /// <summary>
        /// Cached name for the 'agent_get_time_horizon_agents' method.
        /// </summary>
        public static readonly StringName AgentGetTimeHorizonAgents = "agent_get_time_horizon_agents";
        /// <summary>
        /// Cached name for the 'agent_set_time_horizon_obstacles' method.
        /// </summary>
        public static readonly StringName AgentSetTimeHorizonObstacles = "agent_set_time_horizon_obstacles";
        /// <summary>
        /// Cached name for the 'agent_get_time_horizon_obstacles' method.
        /// </summary>
        public static readonly StringName AgentGetTimeHorizonObstacles = "agent_get_time_horizon_obstacles";
        /// <summary>
        /// Cached name for the 'agent_set_radius' method.
        /// </summary>
        public static readonly StringName AgentSetRadius = "agent_set_radius";
        /// <summary>
        /// Cached name for the 'agent_get_radius' method.
        /// </summary>
        public static readonly StringName AgentGetRadius = "agent_get_radius";
        /// <summary>
        /// Cached name for the 'agent_set_max_speed' method.
        /// </summary>
        public static readonly StringName AgentSetMaxSpeed = "agent_set_max_speed";
        /// <summary>
        /// Cached name for the 'agent_get_max_speed' method.
        /// </summary>
        public static readonly StringName AgentGetMaxSpeed = "agent_get_max_speed";
        /// <summary>
        /// Cached name for the 'agent_set_velocity_forced' method.
        /// </summary>
        public static readonly StringName AgentSetVelocityForced = "agent_set_velocity_forced";
        /// <summary>
        /// Cached name for the 'agent_set_velocity' method.
        /// </summary>
        public static readonly StringName AgentSetVelocity = "agent_set_velocity";
        /// <summary>
        /// Cached name for the 'agent_get_velocity' method.
        /// </summary>
        public static readonly StringName AgentGetVelocity = "agent_get_velocity";
        /// <summary>
        /// Cached name for the 'agent_set_position' method.
        /// </summary>
        public static readonly StringName AgentSetPosition = "agent_set_position";
        /// <summary>
        /// Cached name for the 'agent_get_position' method.
        /// </summary>
        public static readonly StringName AgentGetPosition = "agent_get_position";
        /// <summary>
        /// Cached name for the 'agent_is_map_changed' method.
        /// </summary>
        public static readonly StringName AgentIsMapChanged = "agent_is_map_changed";
        /// <summary>
        /// Cached name for the 'agent_set_avoidance_callback' method.
        /// </summary>
        public static readonly StringName AgentSetAvoidanceCallback = "agent_set_avoidance_callback";
        /// <summary>
        /// Cached name for the 'agent_has_avoidance_callback' method.
        /// </summary>
        public static readonly StringName AgentHasAvoidanceCallback = "agent_has_avoidance_callback";
        /// <summary>
        /// Cached name for the 'agent_set_avoidance_layers' method.
        /// </summary>
        public static readonly StringName AgentSetAvoidanceLayers = "agent_set_avoidance_layers";
        /// <summary>
        /// Cached name for the 'agent_get_avoidance_layers' method.
        /// </summary>
        public static readonly StringName AgentGetAvoidanceLayers = "agent_get_avoidance_layers";
        /// <summary>
        /// Cached name for the 'agent_set_avoidance_mask' method.
        /// </summary>
        public static readonly StringName AgentSetAvoidanceMask = "agent_set_avoidance_mask";
        /// <summary>
        /// Cached name for the 'agent_get_avoidance_mask' method.
        /// </summary>
        public static readonly StringName AgentGetAvoidanceMask = "agent_get_avoidance_mask";
        /// <summary>
        /// Cached name for the 'agent_set_avoidance_priority' method.
        /// </summary>
        public static readonly StringName AgentSetAvoidancePriority = "agent_set_avoidance_priority";
        /// <summary>
        /// Cached name for the 'agent_get_avoidance_priority' method.
        /// </summary>
        public static readonly StringName AgentGetAvoidancePriority = "agent_get_avoidance_priority";
        /// <summary>
        /// Cached name for the 'obstacle_create' method.
        /// </summary>
        public static readonly StringName ObstacleCreate = "obstacle_create";
        /// <summary>
        /// Cached name for the 'obstacle_set_avoidance_enabled' method.
        /// </summary>
        public static readonly StringName ObstacleSetAvoidanceEnabled = "obstacle_set_avoidance_enabled";
        /// <summary>
        /// Cached name for the 'obstacle_get_avoidance_enabled' method.
        /// </summary>
        public static readonly StringName ObstacleGetAvoidanceEnabled = "obstacle_get_avoidance_enabled";
        /// <summary>
        /// Cached name for the 'obstacle_set_map' method.
        /// </summary>
        public static readonly StringName ObstacleSetMap = "obstacle_set_map";
        /// <summary>
        /// Cached name for the 'obstacle_get_map' method.
        /// </summary>
        public static readonly StringName ObstacleGetMap = "obstacle_get_map";
        /// <summary>
        /// Cached name for the 'obstacle_set_paused' method.
        /// </summary>
        public static readonly StringName ObstacleSetPaused = "obstacle_set_paused";
        /// <summary>
        /// Cached name for the 'obstacle_get_paused' method.
        /// </summary>
        public static readonly StringName ObstacleGetPaused = "obstacle_get_paused";
        /// <summary>
        /// Cached name for the 'obstacle_set_radius' method.
        /// </summary>
        public static readonly StringName ObstacleSetRadius = "obstacle_set_radius";
        /// <summary>
        /// Cached name for the 'obstacle_get_radius' method.
        /// </summary>
        public static readonly StringName ObstacleGetRadius = "obstacle_get_radius";
        /// <summary>
        /// Cached name for the 'obstacle_set_velocity' method.
        /// </summary>
        public static readonly StringName ObstacleSetVelocity = "obstacle_set_velocity";
        /// <summary>
        /// Cached name for the 'obstacle_get_velocity' method.
        /// </summary>
        public static readonly StringName ObstacleGetVelocity = "obstacle_get_velocity";
        /// <summary>
        /// Cached name for the 'obstacle_set_position' method.
        /// </summary>
        public static readonly StringName ObstacleSetPosition = "obstacle_set_position";
        /// <summary>
        /// Cached name for the 'obstacle_get_position' method.
        /// </summary>
        public static readonly StringName ObstacleGetPosition = "obstacle_get_position";
        /// <summary>
        /// Cached name for the 'obstacle_set_vertices' method.
        /// </summary>
        public static readonly StringName ObstacleSetVertices = "obstacle_set_vertices";
        /// <summary>
        /// Cached name for the 'obstacle_get_vertices' method.
        /// </summary>
        public static readonly StringName ObstacleGetVertices = "obstacle_get_vertices";
        /// <summary>
        /// Cached name for the 'obstacle_set_avoidance_layers' method.
        /// </summary>
        public static readonly StringName ObstacleSetAvoidanceLayers = "obstacle_set_avoidance_layers";
        /// <summary>
        /// Cached name for the 'obstacle_get_avoidance_layers' method.
        /// </summary>
        public static readonly StringName ObstacleGetAvoidanceLayers = "obstacle_get_avoidance_layers";
        /// <summary>
        /// Cached name for the 'parse_source_geometry_data' method.
        /// </summary>
        public static readonly StringName ParseSourceGeometryData = "parse_source_geometry_data";
        /// <summary>
        /// Cached name for the 'bake_from_source_geometry_data' method.
        /// </summary>
        public static readonly StringName BakeFromSourceGeometryData = "bake_from_source_geometry_data";
        /// <summary>
        /// Cached name for the 'bake_from_source_geometry_data_async' method.
        /// </summary>
        public static readonly StringName BakeFromSourceGeometryDataAsync = "bake_from_source_geometry_data_async";
        /// <summary>
        /// Cached name for the 'is_baking_navigation_polygon' method.
        /// </summary>
        public static readonly StringName IsBakingNavigationPolygon = "is_baking_navigation_polygon";
        /// <summary>
        /// Cached name for the 'source_geometry_parser_create' method.
        /// </summary>
        public static readonly StringName SourceGeometryParserCreate = "source_geometry_parser_create";
        /// <summary>
        /// Cached name for the 'source_geometry_parser_set_callback' method.
        /// </summary>
        public static readonly StringName SourceGeometryParserSetCallback = "source_geometry_parser_set_callback";
        /// <summary>
        /// Cached name for the 'simplify_path' method.
        /// </summary>
        public static readonly StringName SimplifyPath = "simplify_path";
        /// <summary>
        /// Cached name for the 'free_rid' method.
        /// </summary>
        public static readonly StringName FreeRid = "free_rid";
        /// <summary>
        /// Cached name for the 'set_active' method.
        /// </summary>
        public static readonly StringName SetActive = "set_active";
        /// <summary>
        /// Cached name for the 'set_debug_enabled' method.
        /// </summary>
        public static readonly StringName SetDebugEnabled = "set_debug_enabled";
        /// <summary>
        /// Cached name for the 'get_debug_enabled' method.
        /// </summary>
        public static readonly StringName GetDebugEnabled = "get_debug_enabled";
        /// <summary>
        /// Cached name for the 'get_process_info' method.
        /// </summary>
        public static readonly StringName GetProcessInfo = "get_process_info";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public class SignalName
    {
        /// <summary>
        /// Cached name for the 'map_changed' signal.
        /// </summary>
        public static readonly StringName MapChanged = "map_changed";
        /// <summary>
        /// Cached name for the 'navigation_debug_changed' signal.
        /// </summary>
        public static readonly StringName NavigationDebugChanged = "navigation_debug_changed";
        /// <summary>
        /// Cached name for the 'avoidance_debug_changed' signal.
        /// </summary>
        public static readonly StringName AvoidanceDebugChanged = "avoidance_debug_changed";
    }
}
