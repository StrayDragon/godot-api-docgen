namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Node for 2D tile-based maps. A <see cref="Godot.TileMapLayer"/> uses a <see cref="Godot.TileSet"/> which contain a list of tiles which are used to create grid-based maps. Unlike the <see cref="Godot.TileMap"/> node, which is deprecated, <see cref="Godot.TileMapLayer"/> has only one layer of tiles. You can use several <see cref="Godot.TileMapLayer"/> to achieve the same result as a <see cref="Godot.TileMap"/> node.</para>
/// <para>For performance reasons, all TileMap updates are batched at the end of a frame. Notably, this means that scene tiles from a <see cref="Godot.TileSetScenesCollectionSource"/> are initialized after their parent. This is only queued when inside the scene tree.</para>
/// <para>To force an update earlier on, call <see cref="Godot.TileMapLayer.UpdateInternals()"/>.</para>
/// <para><b>Note:</b> For performance and compatibility reasons, the coordinates serialized by <see cref="Godot.TileMapLayer"/> are limited to 16-bit signed integers, i.e. the range for X and Y coordinates is from <c>-32768</c> to <c>32767</c>. When saving tile data, tiles outside this range are wrapped.</para>
/// </summary>
public partial class TileMapLayer : Node2D
{
    public enum DebugVisibilityMode : long
    {
        /// <summary>
        /// <para>Hide the collisions or navigation debug shapes in the editor, and use the debug settings to determine their visibility in game (i.e. <see cref="Godot.SceneTree.DebugCollisionsHint"/> or <see cref="Godot.SceneTree.DebugNavigationHint"/>).</para>
        /// </summary>
        Default = 0,
        /// <summary>
        /// <para>Always hide the collisions or navigation debug shapes.</para>
        /// </summary>
        ForceHide = 2,
        /// <summary>
        /// <para>Always show the collisions or navigation debug shapes.</para>
        /// </summary>
        ForceShow = 1
    }

    /// <summary>
    /// <para>The raw tile map data as a byte array.</para>
    /// </summary>
    public byte[] TileMapData
    {
        get
        {
            return GetTileMapDataAsArray();
        }
        set
        {
            SetTileMapDataFromArray(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="false"/>, disables this <see cref="Godot.TileMapLayer"/> completely (rendering, collision, navigation, scene tiles, etc.)</para>
    /// </summary>
    public bool Enabled
    {
        get
        {
            return IsEnabled();
        }
        set
        {
            SetEnabled(value);
        }
    }

    /// <summary>
    /// <para>The <see cref="Godot.TileSet"/> used by this layer. The textures, collisions, and additional behavior of all available tiles are stored here.</para>
    /// </summary>
    public TileSet TileSet
    {
        get
        {
            return GetTileSet();
        }
        set
        {
            SetTileSet(value);
        }
    }

    /// <summary>
    /// <para>Enable or disable light occlusion.</para>
    /// </summary>
    public bool OcclusionEnabled
    {
        get
        {
            return IsOcclusionEnabled();
        }
        set
        {
            SetOcclusionEnabled(value);
        }
    }

    /// <summary>
    /// <para>This Y-sort origin value is added to each tile's Y-sort origin value. This allows, for example, to fake a different height level. This can be useful for top-down view games.</para>
    /// </summary>
    public int YSortOrigin
    {
        get
        {
            return GetYSortOrigin();
        }
        set
        {
            SetYSortOrigin(value);
        }
    }

    /// <summary>
    /// <para>If <see cref="Godot.CanvasItem.YSortEnabled"/> is enabled, setting this to <see langword="true"/> will reverse the order the tiles are drawn on the X-axis.</para>
    /// </summary>
    public bool XDrawOrderReversed
    {
        get
        {
            return IsXDrawOrderReversed();
        }
        set
        {
            SetXDrawOrderReversed(value);
        }
    }

    /// <summary>
    /// <para>The <see cref="Godot.TileMapLayer"/>'s rendering quadrant size. A quadrant is a group of tiles to be drawn together on a single canvas item, for optimization purposes. <see cref="Godot.TileMapLayer.RenderingQuadrantSize"/> defines the length of a square's side, in the map's coordinate system, that forms the quadrant. Thus, the default quadrant size groups together <c>16 * 16 = 256</c> tiles.</para>
    /// <para>The quadrant size does not apply on a Y-sorted <see cref="Godot.TileMapLayer"/>, as tiles are grouped by Y position instead in that case.</para>
    /// <para><b>Note:</b> As quadrants are created according to the map's coordinate system, the quadrant's "square shape" might not look like square in the <see cref="Godot.TileMapLayer"/>'s local coordinate system.</para>
    /// </summary>
    public int RenderingQuadrantSize
    {
        get
        {
            return GetRenderingQuadrantSize();
        }
        set
        {
            SetRenderingQuadrantSize(value);
        }
    }

    /// <summary>
    /// <para>Enable or disable collisions.</para>
    /// </summary>
    public bool CollisionEnabled
    {
        get
        {
            return IsCollisionEnabled();
        }
        set
        {
            SetCollisionEnabled(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, this <see cref="Godot.TileMapLayer"/> collision shapes will be instantiated as kinematic bodies. This can be needed for moving <see cref="Godot.TileMapLayer"/> nodes (i.e. moving platforms).</para>
    /// </summary>
    public bool UseKinematicBodies
    {
        get
        {
            return IsUsingKinematicBodies();
        }
        set
        {
            SetUseKinematicBodies(value);
        }
    }

    /// <summary>
    /// <para>Show or hide the <see cref="Godot.TileMapLayer"/>'s collision shapes. If set to <see cref="Godot.TileMapLayer.DebugVisibilityMode.Default"/>, this depends on the show collision debug settings.</para>
    /// </summary>
    public TileMapLayer.DebugVisibilityMode CollisionVisibilityMode
    {
        get
        {
            return GetCollisionVisibilityMode();
        }
        set
        {
            SetCollisionVisibilityMode(value);
        }
    }

    /// <summary>
    /// <para>The <see cref="Godot.TileMapLayer"/>'s physics quadrant size. Within a physics quadrant, cells with similar physics properties are grouped together and their collision shapes get merged. <see cref="Godot.TileMapLayer.PhysicsQuadrantSize"/> defines the length of a square's side, in the map's coordinate system, that forms the quadrant. Thus, the default quadrant size groups together <c>16 * 16 = 256</c> tiles.</para>
    /// <para><b>Note:</b> As quadrants are created according to the map's coordinate system, the quadrant's "square shape" might not look like square in the <see cref="Godot.TileMapLayer"/>'s local coordinate system.</para>
    /// <para><b>Note:</b> This impacts the value returned by <see cref="Godot.TileMapLayer.GetCoordsForBodyRid(Rid)"/>. Higher values will make that function less precise. To get the exact cell coordinates, you need to set <see cref="Godot.TileMapLayer.PhysicsQuadrantSize"/> to <c>1</c>, which disables physics chunking.</para>
    /// </summary>
    public int PhysicsQuadrantSize
    {
        get
        {
            return GetPhysicsQuadrantSize();
        }
        set
        {
            SetPhysicsQuadrantSize(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, navigation regions are enabled.</para>
    /// </summary>
    public bool NavigationEnabled
    {
        get
        {
            return IsNavigationEnabled();
        }
        set
        {
            SetNavigationEnabled(value);
        }
    }

    /// <summary>
    /// <para>Show or hide the <see cref="Godot.TileMapLayer"/>'s navigation meshes. If set to <see cref="Godot.TileMapLayer.DebugVisibilityMode.Default"/>, this depends on the show navigation debug settings.</para>
    /// </summary>
    public TileMapLayer.DebugVisibilityMode NavigationVisibilityMode
    {
        get
        {
            return GetNavigationVisibilityMode();
        }
        set
        {
            SetNavigationVisibilityMode(value);
        }
    }

    private static readonly System.Type CachedType = typeof(TileMapLayer);

    private static readonly StringName NativeName = "TileMapLayer";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public TileMapLayer() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal TileMapLayer(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal TileMapLayer(bool memoryOwn) : base(memoryOwn) { }

    /// <summary>
    /// <para>Called with a <see cref="Godot.TileData"/> object about to be used internally by the <see cref="Godot.TileMapLayer"/>, allowing its modification at runtime.</para>
    /// <para>This method is only called if <see cref="Godot.TileMapLayer._UseTileDataRuntimeUpdate(Vector2I)"/> is implemented and returns <see langword="true"/> for the given tile <paramref name="coords"/>.</para>
    /// <para><b>Warning:</b> The <paramref name="tileData"/> object's sub-resources are the same as the one in the TileSet. Modifying them might impact the whole TileSet. Instead, make sure to duplicate those resources.</para>
    /// <para><b>Note:</b> If the properties of <paramref name="tileData"/> object should change over time, use <see cref="Godot.TileMapLayer.NotifyRuntimeTileDataUpdate()"/> to notify the <see cref="Godot.TileMapLayer"/> it needs an update.</para>
    /// </summary>
    public virtual unsafe void _TileDataRuntimeUpdate(Vector2I coords, TileData tileData)
    {
    }

    /// <summary>
    /// <para>Called when this <see cref="Godot.TileMapLayer"/>'s cells need an internal update. This update may be caused from individual cells being modified or by a change in the <see cref="Godot.TileMapLayer.TileSet"/> (causing all cells to be queued for an update). The first call to this function is always for initializing all the <see cref="Godot.TileMapLayer"/>'s cells. <paramref name="coords"/> contains the coordinates of all modified cells, roughly in the order they were modified. <paramref name="forcedCleanup"/> is <see langword="true"/> when the <see cref="Godot.TileMapLayer"/>'s internals should be fully cleaned up. This is the case when:</para>
    /// <para>- The layer is disabled;</para>
    /// <para>- The layer is not visible;</para>
    /// <para>- <see cref="Godot.TileMapLayer.TileSet"/> is set to <see langword="null"/>;</para>
    /// <para>- The node is removed from the tree;</para>
    /// <para>- The node is freed.</para>
    /// <para>Note that any internal update happening while one of these conditions is verified is considered to be a "cleanup". See also <see cref="Godot.TileMapLayer.UpdateInternals()"/>.</para>
    /// <para><b>Warning:</b> Implementing this method may degrade the <see cref="Godot.TileMapLayer"/>'s performance.</para>
    /// </summary>
    public virtual void _UpdateCells(Godot.Collections.Array<Vector2I> coords, bool forcedCleanup)
    {
    }

    /// <summary>
    /// <para>Should return <see langword="true"/> if the tile at coordinates <paramref name="coords"/> requires a runtime update.</para>
    /// <para><b>Warning:</b> Make sure this function only returns <see langword="true"/> when needed. Any tile processed at runtime without a need for it will imply a significant performance penalty.</para>
    /// <para><b>Note:</b> If the result of this function should change, use <see cref="Godot.TileMapLayer.NotifyRuntimeTileDataUpdate()"/> to notify the <see cref="Godot.TileMapLayer"/> it needs an update.</para>
    /// </summary>
    public virtual unsafe bool _UseTileDataRuntimeUpdate(Vector2I coords)
    {
        return default;
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCell, 2428518503ul);

    /// <summary>
    /// <para>Sets the tile identifiers for the cell at coordinates <paramref name="coords"/>. Each tile of the <see cref="Godot.TileSet"/> is identified using three parts:</para>
    /// <para>- The source identifier <paramref name="sourceId"/> identifies a <see cref="Godot.TileSetSource"/> identifier. See <see cref="Godot.TileSet.SetSourceId(int, int)"/>,</para>
    /// <para>- The atlas coordinate identifier <paramref name="atlasCoords"/> identifies a tile coordinates in the atlas (if the source is a <see cref="Godot.TileSetAtlasSource"/>). For <see cref="Godot.TileSetScenesCollectionSource"/> it should always be <c>Vector2i(0, 0)</c>,</para>
    /// <para>- The alternative tile identifier <paramref name="alternativeTile"/> identifies a tile alternative in the atlas (if the source is a <see cref="Godot.TileSetAtlasSource"/>), and the scene for a <see cref="Godot.TileSetScenesCollectionSource"/>.</para>
    /// <para>If <paramref name="sourceId"/> is set to <c>-1</c>, <paramref name="atlasCoords"/> to <c>Vector2i(-1, -1)</c>, or <paramref name="alternativeTile"/> to <c>-1</c>, the cell will be erased. An erased cell gets <b>all</b> its identifiers automatically set to their respective invalid values, namely <c>-1</c>, <c>Vector2i(-1, -1)</c> and <c>-1</c>.</para>
    /// </summary>
    /// <param name="atlasCoords">If the parameter is null, then the default value is <c>new Vector2I(-1, -1)</c>.</param>
    public unsafe void SetCell(Vector2I coords, int sourceId = -1, Nullable<Vector2I> atlasCoords = null, int alternativeTile = 0)
    {
        Vector2I atlasCoordsOrDefVal = atlasCoords.HasValue ? atlasCoords.Value : new Vector2I(-1, -1);
        NativeCalls.godot_icall_4_1437(MethodBind0, GodotObject.GetPtr(this), &coords, sourceId, &atlasCoordsOrDefVal, alternativeTile);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.EraseCell, 1130785943ul);

    /// <summary>
    /// <para>Erases the cell at coordinates <paramref name="coords"/>.</para>
    /// </summary>
    public unsafe void EraseCell(Vector2I coords)
    {
        NativeCalls.godot_icall_1_34(MethodBind1, GodotObject.GetPtr(this), &coords);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FixInvalidTiles, 3218959716ul);

    /// <summary>
    /// <para>Clears cells containing tiles that do not exist in the <see cref="Godot.TileMapLayer.TileSet"/>.</para>
    /// </summary>
    public void FixInvalidTiles()
    {
        NativeCalls.godot_icall_0_3(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Clear, 3218959716ul);

    /// <summary>
    /// <para>Clears all cells.</para>
    /// </summary>
    public void Clear()
    {
        NativeCalls.godot_icall_0_3(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCellSourceId, 2485466453ul);

    /// <summary>
    /// <para>Returns the tile source ID of the cell at coordinates <paramref name="coords"/>. Returns <c>-1</c> if the cell does not exist.</para>
    /// </summary>
    public unsafe int GetCellSourceId(Vector2I coords)
    {
        return NativeCalls.godot_icall_1_409(MethodBind4, GodotObject.GetPtr(this), &coords);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCellAtlasCoords, 3050897911ul);

    /// <summary>
    /// <para>Returns the tile atlas coordinates ID of the cell at coordinates <paramref name="coords"/>. Returns <c>Vector2i(-1, -1)</c> if the cell does not exist.</para>
    /// </summary>
    public unsafe Vector2I GetCellAtlasCoords(Vector2I coords)
    {
        return NativeCalls.godot_icall_1_1438(MethodBind5, GodotObject.GetPtr(this), &coords);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCellAlternativeTile, 2485466453ul);

    /// <summary>
    /// <para>Returns the tile alternative ID of the cell at coordinates <paramref name="coords"/>.</para>
    /// </summary>
    public unsafe int GetCellAlternativeTile(Vector2I coords)
    {
        return NativeCalls.godot_icall_1_409(MethodBind6, GodotObject.GetPtr(this), &coords);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCellTileData, 205084707ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.TileData"/> object associated with the given cell, or <see langword="null"/> if the cell does not exist or is not a <see cref="Godot.TileSetAtlasSource"/>.</para>
    /// <para><code>
    /// func get_clicked_tile_power():
    /// 	var clicked_cell = tile_map_layer.local_to_map(tile_map_layer.get_local_mouse_position())
    /// 	var data = tile_map_layer.get_cell_tile_data(clicked_cell)
    /// 	if data:
    /// 		return data.get_custom_data("power")
    /// 	else:
    /// 		return 0
    /// </code></para>
    /// </summary>
    public unsafe TileData GetCellTileData(Vector2I coords)
    {
        return (TileData)NativeCalls.godot_icall_1_1439(MethodBind7, GodotObject.GetPtr(this), &coords);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsCellFlippedH, 3900751641ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the cell at coordinates <paramref name="coords"/> is flipped horizontally. The result is valid only for atlas sources.</para>
    /// </summary>
    public unsafe bool IsCellFlippedH(Vector2I coords)
    {
        return NativeCalls.godot_icall_1_41(MethodBind8, GodotObject.GetPtr(this), &coords).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsCellFlippedV, 3900751641ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the cell at coordinates <paramref name="coords"/> is flipped vertically. The result is valid only for atlas sources.</para>
    /// </summary>
    public unsafe bool IsCellFlippedV(Vector2I coords)
    {
        return NativeCalls.godot_icall_1_41(MethodBind9, GodotObject.GetPtr(this), &coords).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsCellTransposed, 3900751641ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the cell at coordinates <paramref name="coords"/> is transposed. The result is valid only for atlas sources.</para>
    /// </summary>
    public unsafe bool IsCellTransposed(Vector2I coords)
    {
        return NativeCalls.godot_icall_1_41(MethodBind10, GodotObject.GetPtr(this), &coords).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetUsedCells, 3995934104ul);

    /// <summary>
    /// <para>Returns a <see cref="Godot.Vector2I"/> array with the positions of all cells containing a tile. A cell is considered empty if its source identifier equals <c>-1</c>, its atlas coordinate identifier is <c>Vector2(-1, -1)</c> and its alternative identifier is <c>-1</c>.</para>
    /// </summary>
    public Godot.Collections.Array<Vector2I> GetUsedCells()
    {
        return new Godot.Collections.Array<Vector2I>(NativeCalls.godot_icall_0_120(MethodBind11, GodotObject.GetPtr(this)));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetUsedCellsById, 4175304538ul);

    /// <summary>
    /// <para>Returns a <see cref="Godot.Vector2I"/> array with the positions of all cells containing a tile. Tiles may be filtered according to their source (<paramref name="sourceId"/>), their atlas coordinates (<paramref name="atlasCoords"/>), or alternative id (<paramref name="alternativeTile"/>).</para>
    /// <para>If a parameter has its value set to the default one, this parameter is not used to filter a cell. Thus, if all parameters have their respective default values, this method returns the same result as <see cref="Godot.TileMapLayer.GetUsedCells()"/>.</para>
    /// <para>A cell is considered empty if its source identifier equals <c>-1</c>, its atlas coordinate identifier is <c>Vector2(-1, -1)</c> and its alternative identifier is <c>-1</c>.</para>
    /// </summary>
    /// <param name="atlasCoords">If the parameter is null, then the default value is <c>new Vector2I(-1, -1)</c>.</param>
    public unsafe Godot.Collections.Array<Vector2I> GetUsedCellsById(int sourceId = -1, Nullable<Vector2I> atlasCoords = null, int alternativeTile = -1)
    {
        Vector2I atlasCoordsOrDefVal = atlasCoords.HasValue ? atlasCoords.Value : new Vector2I(-1, -1);
        return new Godot.Collections.Array<Vector2I>(NativeCalls.godot_icall_3_1440(MethodBind12, GodotObject.GetPtr(this), sourceId, &atlasCoordsOrDefVal, alternativeTile));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetUsedRect, 410525958ul);

    /// <summary>
    /// <para>Returns a rectangle enclosing the used (non-empty) tiles of the map.</para>
    /// </summary>
    public Rect2I GetUsedRect()
    {
        return NativeCalls.godot_icall_0_33(MethodBind13, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPattern, 3820813253ul);

    /// <summary>
    /// <para>Creates and returns a new <see cref="Godot.TileMapPattern"/> from the given array of cells. See also <see cref="Godot.TileMapLayer.SetPattern(Vector2I, TileMapPattern)"/>.</para>
    /// </summary>
    public TileMapPattern GetPattern(Godot.Collections.Array<Vector2I> coordsArray)
    {
        return (TileMapPattern)NativeCalls.godot_icall_1_1441(MethodBind14, GodotObject.GetPtr(this), (godot_array)(coordsArray ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPattern, 1491151770ul);

    /// <summary>
    /// <para>Pastes the <see cref="Godot.TileMapPattern"/> at the given <paramref name="position"/> in the tile map. See also <see cref="Godot.TileMapLayer.GetPattern(Godot.Collections.Array{Vector2I})"/>.</para>
    /// </summary>
    public unsafe void SetPattern(Vector2I position, TileMapPattern pattern)
    {
        NativeCalls.godot_icall_2_1442(MethodBind15, GodotObject.GetPtr(this), &position, GodotObject.GetPtr(pattern));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCellsTerrainConnect, 748968311ul);

    /// <summary>
    /// <para>Update all the cells in the <paramref name="cells"/> coordinates array so that they use the given <paramref name="terrain"/> for the given <paramref name="terrainSet"/>. If an updated cell has the same terrain as one of its neighboring cells, this function tries to join the two. This function might update neighboring tiles if needed to create correct terrain transitions.</para>
    /// <para>If <paramref name="ignoreEmptyTerrains"/> is <see langword="true"/>, empty terrains will be ignored when trying to find the best fitting tile for the given terrain constraints.</para>
    /// <para><b>Note:</b> To work correctly, this method requires the <see cref="Godot.TileMapLayer"/>'s TileSet to have terrains set up with all required terrain combinations. Otherwise, it may produce unexpected results.</para>
    /// </summary>
    public void SetCellsTerrainConnect(Godot.Collections.Array<Vector2I> cells, int terrainSet, int terrain, bool ignoreEmptyTerrains = true)
    {
        NativeCalls.godot_icall_4_1443(MethodBind16, GodotObject.GetPtr(this), (godot_array)(cells ?? new()).NativeValue, terrainSet, terrain, ignoreEmptyTerrains.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCellsTerrainPath, 748968311ul);

    /// <summary>
    /// <para>Update all the cells in the <paramref name="path"/> coordinates array so that they use the given <paramref name="terrain"/> for the given <paramref name="terrainSet"/>. The function will also connect two successive cell in the path with the same terrain. This function might update neighboring tiles if needed to create correct terrain transitions.</para>
    /// <para>If <paramref name="ignoreEmptyTerrains"/> is <see langword="true"/>, empty terrains will be ignored when trying to find the best fitting tile for the given terrain constraints.</para>
    /// <para><b>Note:</b> To work correctly, this method requires the <see cref="Godot.TileMapLayer"/>'s TileSet to have terrains set up with all required terrain combinations. Otherwise, it may produce unexpected results.</para>
    /// </summary>
    public void SetCellsTerrainPath(Godot.Collections.Array<Vector2I> path, int terrainSet, int terrain, bool ignoreEmptyTerrains = true)
    {
        NativeCalls.godot_icall_4_1443(MethodBind17, GodotObject.GetPtr(this), (godot_array)(path ?? new()).NativeValue, terrainSet, terrain, ignoreEmptyTerrains.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasBodyRid, 4155700596ul);

    /// <summary>
    /// <para>Returns whether the provided <paramref name="body"/> <see cref="Godot.Rid"/> belongs to one of this <see cref="Godot.TileMapLayer"/>'s cells.</para>
    /// </summary>
    public bool HasBodyRid(Rid body)
    {
        return NativeCalls.godot_icall_1_421(MethodBind18, GodotObject.GetPtr(this), body).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCoordsForBodyRid, 733700038ul);

    /// <summary>
    /// <para>Returns the coordinates of the physics quadrant (see <see cref="Godot.TileMapLayer.PhysicsQuadrantSize"/>) for given physics body <see cref="Godot.Rid"/>. Such an <see cref="Godot.Rid"/> can be retrieved from <see cref="Godot.KinematicCollision2D.GetColliderRid()"/>, when colliding with a tile.</para>
    /// <para><b>Note:</b> Higher values of <see cref="Godot.TileMapLayer.PhysicsQuadrantSize"/> will make this function less precise. To get the exact cell coordinates, you need to set <see cref="Godot.TileMapLayer.PhysicsQuadrantSize"/> to <c>1</c>, which disables physics chunking.</para>
    /// </summary>
    public Vector2I GetCoordsForBodyRid(Rid body)
    {
        return NativeCalls.godot_icall_1_1382(MethodBind19, GodotObject.GetPtr(this), body);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.UpdateInternals, 3218959716ul);

    /// <summary>
    /// <para>Triggers a direct update of the <see cref="Godot.TileMapLayer"/>. Usually, calling this function is not needed, as <see cref="Godot.TileMapLayer"/> node updates automatically when one of its properties or cells is modified.</para>
    /// <para>However, for performance reasons, those updates are batched and delayed to the end of the frame. Calling this function will force the <see cref="Godot.TileMapLayer"/> to update right away instead.</para>
    /// <para><b>Warning:</b> Updating the <see cref="Godot.TileMapLayer"/> is computationally expensive and may impact performance. Try to limit the number of updates and how many tiles they impact.</para>
    /// </summary>
    public void UpdateInternals()
    {
        NativeCalls.godot_icall_0_3(MethodBind20, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.NotifyRuntimeTileDataUpdate, 3218959716ul);

    /// <summary>
    /// <para>Notifies the <see cref="Godot.TileMapLayer"/> node that calls to <see cref="Godot.TileMapLayer._UseTileDataRuntimeUpdate(Vector2I)"/> or <see cref="Godot.TileMapLayer._TileDataRuntimeUpdate(Vector2I, TileData)"/> will lead to different results. This will thus trigger a <see cref="Godot.TileMapLayer"/> update.</para>
    /// <para><b>Warning:</b> Updating the <see cref="Godot.TileMapLayer"/> is computationally expensive and may impact performance. Try to limit the number of calls to this function to avoid unnecessary update.</para>
    /// <para><b>Note:</b> This does not trigger a direct update of the <see cref="Godot.TileMapLayer"/>, the update will be done at the end of the frame as usual (unless you call <see cref="Godot.TileMapLayer.UpdateInternals()"/>).</para>
    /// </summary>
    public void NotifyRuntimeTileDataUpdate()
    {
        NativeCalls.godot_icall_0_3(MethodBind21, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MapPattern, 1864516957ul);

    /// <summary>
    /// <para>Returns for the given coordinates <paramref name="coordsInPattern"/> in a <see cref="Godot.TileMapPattern"/> the corresponding cell coordinates if the pattern was pasted at the <paramref name="positionInTilemap"/> coordinates (see <see cref="Godot.TileMapLayer.SetPattern(Vector2I, TileMapPattern)"/>). This mapping is required as in half-offset tile shapes, the mapping might not work by calculating <c>position_in_tile_map + coords_in_pattern</c>.</para>
    /// </summary>
    public unsafe Vector2I MapPattern(Vector2I positionInTilemap, Vector2I coordsInPattern, TileMapPattern pattern)
    {
        return NativeCalls.godot_icall_3_1430(MethodBind22, GodotObject.GetPtr(this), &positionInTilemap, &coordsInPattern, GodotObject.GetPtr(pattern));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSurroundingCells, 2673526557ul);

    /// <summary>
    /// <para>Returns the list of all neighboring cells to the one at <paramref name="coords"/>. Any neighboring cell is one that is touching edges, so for a square cell 4 cells would be returned, for a hexagon 6 cells are returned.</para>
    /// </summary>
    public unsafe Godot.Collections.Array<Vector2I> GetSurroundingCells(Vector2I coords)
    {
        return new Godot.Collections.Array<Vector2I>(NativeCalls.godot_icall_1_1433(MethodBind23, GodotObject.GetPtr(this), &coords));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNeighborCell, 986575103ul);

    /// <summary>
    /// <para>Returns the neighboring cell to the one at coordinates <paramref name="coords"/>, identified by the <paramref name="neighbor"/> direction. This method takes into account the different layouts a TileMap can take.</para>
    /// </summary>
    public unsafe Vector2I GetNeighborCell(Vector2I coords, TileSet.CellNeighbor neighbor)
    {
        return NativeCalls.godot_icall_2_1436(MethodBind24, GodotObject.GetPtr(this), &coords, (int)neighbor);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MapToLocal, 108438297ul);

    /// <summary>
    /// <para>Returns the centered position of a cell in the <see cref="Godot.TileMapLayer"/>'s local coordinate space. To convert the returned value into global coordinates, use <see cref="Godot.Node2D.ToGlobal(Vector2)"/>. See also <see cref="Godot.TileMapLayer.LocalToMap(Vector2)"/>.</para>
    /// <para><b>Note:</b> This may not correspond to the visual position of the tile, i.e. it ignores the <see cref="Godot.TileData.TextureOrigin"/> property of individual tiles.</para>
    /// </summary>
    public unsafe Vector2 MapToLocal(Vector2I mapPosition)
    {
        return NativeCalls.godot_icall_1_47(MethodBind25, GodotObject.GetPtr(this), &mapPosition);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.LocalToMap, 837806996ul);

    /// <summary>
    /// <para>Returns the map coordinates of the cell containing the given <paramref name="localPosition"/>. If <paramref name="localPosition"/> is in global coordinates, consider using <see cref="Godot.Node2D.ToLocal(Vector2)"/> before passing it to this method. See also <see cref="Godot.TileMapLayer.MapToLocal(Vector2I)"/>.</para>
    /// </summary>
    public unsafe Vector2I LocalToMap(Vector2 localPosition)
    {
        return NativeCalls.godot_icall_1_1435(MethodBind26, GodotObject.GetPtr(this), &localPosition);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTileMapDataFromArray, 2971499966ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTileMapDataFromArray(byte[] tileMapLayerData)
    {
        NativeCalls.godot_icall_1_204(MethodBind27, GodotObject.GetPtr(this), tileMapLayerData);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTileMapDataFromArray(ReadOnlySpan<byte> tileMapLayerData)
    {
        NativeCalls.godot_icall_1_204(MethodBind27, GodotObject.GetPtr(this), tileMapLayerData);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTileMapDataAsArray, 2362200018ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public byte[] GetTileMapDataAsArray()
    {
        return NativeCalls.godot_icall_0_2(MethodBind28, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEnabled(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind29, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind30, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTileSet, 774531446ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTileSet(TileSet tileSet)
    {
        NativeCalls.godot_icall_1_56(MethodBind31, GodotObject.GetPtr(this), GodotObject.GetPtr(tileSet));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind32 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTileSet, 2678226422ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public TileSet GetTileSet()
    {
        return (TileSet)NativeCalls.godot_icall_0_63(MethodBind32, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind33 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetYSortOrigin, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetYSortOrigin(int ySortOrigin)
    {
        NativeCalls.godot_icall_1_38(MethodBind33, GodotObject.GetPtr(this), ySortOrigin);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind34 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetYSortOrigin, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetYSortOrigin()
    {
        return NativeCalls.godot_icall_0_39(MethodBind34, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind35 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetXDrawOrderReversed, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetXDrawOrderReversed(bool xDrawOrderReversed)
    {
        NativeCalls.godot_icall_1_14(MethodBind35, GodotObject.GetPtr(this), xDrawOrderReversed.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind36 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsXDrawOrderReversed, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsXDrawOrderReversed()
    {
        return NativeCalls.godot_icall_0_15(MethodBind36, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind37 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRenderingQuadrantSize, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetRenderingQuadrantSize(int size)
    {
        NativeCalls.godot_icall_1_38(MethodBind37, GodotObject.GetPtr(this), size);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind38 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRenderingQuadrantSize, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetRenderingQuadrantSize()
    {
        return NativeCalls.godot_icall_0_39(MethodBind38, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind39 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCollisionEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCollisionEnabled(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind39, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind40 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsCollisionEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsCollisionEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind40, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind41 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetUseKinematicBodies, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetUseKinematicBodies(bool useKinematicBodies)
    {
        NativeCalls.godot_icall_1_14(MethodBind41, GodotObject.GetPtr(this), useKinematicBodies.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind42 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsUsingKinematicBodies, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsUsingKinematicBodies()
    {
        return NativeCalls.godot_icall_0_15(MethodBind42, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind43 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCollisionVisibilityMode, 3508099847ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCollisionVisibilityMode(TileMapLayer.DebugVisibilityMode visibilityMode)
    {
        NativeCalls.godot_icall_1_38(MethodBind43, GodotObject.GetPtr(this), (int)visibilityMode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind44 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCollisionVisibilityMode, 338220793ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public TileMapLayer.DebugVisibilityMode GetCollisionVisibilityMode()
    {
        return (TileMapLayer.DebugVisibilityMode)NativeCalls.godot_icall_0_39(MethodBind44, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind45 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPhysicsQuadrantSize, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPhysicsQuadrantSize(int size)
    {
        NativeCalls.godot_icall_1_38(MethodBind45, GodotObject.GetPtr(this), size);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind46 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPhysicsQuadrantSize, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetPhysicsQuadrantSize()
    {
        return NativeCalls.godot_icall_0_39(MethodBind46, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind47 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetOcclusionEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetOcclusionEnabled(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind47, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind48 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsOcclusionEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsOcclusionEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind48, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind49 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetNavigationEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetNavigationEnabled(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind49, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind50 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsNavigationEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsNavigationEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind50, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind51 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetNavigationMap, 2722037293ul);

    /// <summary>
    /// <para>Sets a custom <paramref name="map"/> as a <see cref="Godot.NavigationServer2D"/> navigation map. If not set, uses the default <see cref="Godot.World2D"/> navigation map instead.</para>
    /// </summary>
    public void SetNavigationMap(Rid map)
    {
        NativeCalls.godot_icall_1_286(MethodBind51, GodotObject.GetPtr(this), map);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind52 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNavigationMap, 2944877500ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.Rid"/> of the <see cref="Godot.NavigationServer2D"/> navigation used by this <see cref="Godot.TileMapLayer"/>.</para>
    /// <para>By default this returns the default <see cref="Godot.World2D"/> navigation map, unless a custom map was provided using <see cref="Godot.TileMapLayer.SetNavigationMap(Rid)"/>.</para>
    /// </summary>
    public Rid GetNavigationMap()
    {
        return NativeCalls.godot_icall_0_238(MethodBind52, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind53 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetNavigationVisibilityMode, 3508099847ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetNavigationVisibilityMode(TileMapLayer.DebugVisibilityMode showNavigation)
    {
        NativeCalls.godot_icall_1_38(MethodBind53, GodotObject.GetPtr(this), (int)showNavigation);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind54 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNavigationVisibilityMode, 338220793ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public TileMapLayer.DebugVisibilityMode GetNavigationVisibilityMode()
    {
        return (TileMapLayer.DebugVisibilityMode)NativeCalls.godot_icall_0_39(MethodBind54, GodotObject.GetPtr(this));
    }

    /// <summary>
    /// <para>Emitted when this <see cref="Godot.TileMapLayer"/>'s properties changes. This includes modified cells, properties, or changes made to its assigned <see cref="Godot.TileSet"/>.</para>
    /// <para><b>Note:</b> This signal may be emitted very often when batch-modifying a <see cref="Godot.TileMapLayer"/>. Avoid executing complex processing in a connected function, and consider delaying it to the end of the frame instead (i.e. calling <see cref="Godot.GodotObject.CallDeferred(StringName, Variant[])"/>).</para>
    /// </summary>
    public event Action Changed
    {
        add => Connect(SignalName.Changed, Callable.From(value));
        remove => Disconnect(SignalName.Changed, Callable.From(value));
    }

    protected void EmitSignalChanged()
    {
        EmitSignal(SignalName.Changed);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__tile_data_runtime_update = "_TileDataRuntimeUpdate";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__update_cells = "_UpdateCells";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__use_tile_data_runtime_update = "_UseTileDataRuntimeUpdate";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_changed = "Changed";

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
        if ((method == MethodProxyName__tile_data_runtime_update || method == MethodName._TileDataRuntimeUpdate) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__tile_data_runtime_update.NativeValue))
        {
            _TileDataRuntimeUpdate(VariantUtils.ConvertTo<Vector2I>(args[0]), VariantUtils.ConvertTo<TileData>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__update_cells || method == MethodName._UpdateCells) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__update_cells.NativeValue))
        {
            _UpdateCells(new Godot.Collections.Array<Vector2I>(VariantUtils.ConvertToArray(args[0])), VariantUtils.ConvertTo<bool>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__use_tile_data_runtime_update || method == MethodName._UseTileDataRuntimeUpdate) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__use_tile_data_runtime_update.NativeValue))
        {
            var callRet = _UseTileDataRuntimeUpdate(VariantUtils.ConvertTo<Vector2I>(args[0]));
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
        if (method == MethodName._TileDataRuntimeUpdate)
        {
            if (HasGodotClassMethod(MethodProxyName__tile_data_runtime_update.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._UpdateCells)
        {
            if (HasGodotClassMethod(MethodProxyName__update_cells.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._UseTileDataRuntimeUpdate)
        {
            if (HasGodotClassMethod(MethodProxyName__use_tile_data_runtime_update.NativeValue.DangerousSelfRef))
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
        if (signal == SignalName.Changed)
        {
            if (HasGodotClassSignal(SignalProxyName_changed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        return base.HasGodotClassSignal(signal);
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : Node2D.PropertyName
    {
        /// <summary>
        /// Cached name for the 'tile_map_data' property.
        /// </summary>
        public static readonly StringName TileMapData = "tile_map_data";
        /// <summary>
        /// Cached name for the 'enabled' property.
        /// </summary>
        public static readonly StringName Enabled = "enabled";
        /// <summary>
        /// Cached name for the 'tile_set' property.
        /// </summary>
        public static readonly StringName TileSet = "tile_set";
        /// <summary>
        /// Cached name for the 'occlusion_enabled' property.
        /// </summary>
        public static readonly StringName OcclusionEnabled = "occlusion_enabled";
        /// <summary>
        /// Cached name for the 'y_sort_origin' property.
        /// </summary>
        public static readonly StringName YSortOrigin = "y_sort_origin";
        /// <summary>
        /// Cached name for the 'x_draw_order_reversed' property.
        /// </summary>
        public static readonly StringName XDrawOrderReversed = "x_draw_order_reversed";
        /// <summary>
        /// Cached name for the 'rendering_quadrant_size' property.
        /// </summary>
        public static readonly StringName RenderingQuadrantSize = "rendering_quadrant_size";
        /// <summary>
        /// Cached name for the 'collision_enabled' property.
        /// </summary>
        public static readonly StringName CollisionEnabled = "collision_enabled";
        /// <summary>
        /// Cached name for the 'use_kinematic_bodies' property.
        /// </summary>
        public static readonly StringName UseKinematicBodies = "use_kinematic_bodies";
        /// <summary>
        /// Cached name for the 'collision_visibility_mode' property.
        /// </summary>
        public static readonly StringName CollisionVisibilityMode = "collision_visibility_mode";
        /// <summary>
        /// Cached name for the 'physics_quadrant_size' property.
        /// </summary>
        public static readonly StringName PhysicsQuadrantSize = "physics_quadrant_size";
        /// <summary>
        /// Cached name for the 'navigation_enabled' property.
        /// </summary>
        public static readonly StringName NavigationEnabled = "navigation_enabled";
        /// <summary>
        /// Cached name for the 'navigation_visibility_mode' property.
        /// </summary>
        public static readonly StringName NavigationVisibilityMode = "navigation_visibility_mode";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Node2D.MethodName
    {
        /// <summary>
        /// Cached name for the '_tile_data_runtime_update' method.
        /// </summary>
        public static readonly StringName _TileDataRuntimeUpdate = "_tile_data_runtime_update";
        /// <summary>
        /// Cached name for the '_update_cells' method.
        /// </summary>
        public static readonly StringName _UpdateCells = "_update_cells";
        /// <summary>
        /// Cached name for the '_use_tile_data_runtime_update' method.
        /// </summary>
        public static readonly StringName _UseTileDataRuntimeUpdate = "_use_tile_data_runtime_update";
        /// <summary>
        /// Cached name for the 'set_cell' method.
        /// </summary>
        public static readonly StringName SetCell = "set_cell";
        /// <summary>
        /// Cached name for the 'erase_cell' method.
        /// </summary>
        public static readonly StringName EraseCell = "erase_cell";
        /// <summary>
        /// Cached name for the 'fix_invalid_tiles' method.
        /// </summary>
        public static readonly StringName FixInvalidTiles = "fix_invalid_tiles";
        /// <summary>
        /// Cached name for the 'clear' method.
        /// </summary>
        public static readonly StringName Clear = "clear";
        /// <summary>
        /// Cached name for the 'get_cell_source_id' method.
        /// </summary>
        public static readonly StringName GetCellSourceId = "get_cell_source_id";
        /// <summary>
        /// Cached name for the 'get_cell_atlas_coords' method.
        /// </summary>
        public static readonly StringName GetCellAtlasCoords = "get_cell_atlas_coords";
        /// <summary>
        /// Cached name for the 'get_cell_alternative_tile' method.
        /// </summary>
        public static readonly StringName GetCellAlternativeTile = "get_cell_alternative_tile";
        /// <summary>
        /// Cached name for the 'get_cell_tile_data' method.
        /// </summary>
        public static readonly StringName GetCellTileData = "get_cell_tile_data";
        /// <summary>
        /// Cached name for the 'is_cell_flipped_h' method.
        /// </summary>
        public static readonly StringName IsCellFlippedH = "is_cell_flipped_h";
        /// <summary>
        /// Cached name for the 'is_cell_flipped_v' method.
        /// </summary>
        public static readonly StringName IsCellFlippedV = "is_cell_flipped_v";
        /// <summary>
        /// Cached name for the 'is_cell_transposed' method.
        /// </summary>
        public static readonly StringName IsCellTransposed = "is_cell_transposed";
        /// <summary>
        /// Cached name for the 'get_used_cells' method.
        /// </summary>
        public static readonly StringName GetUsedCells = "get_used_cells";
        /// <summary>
        /// Cached name for the 'get_used_cells_by_id' method.
        /// </summary>
        public static readonly StringName GetUsedCellsById = "get_used_cells_by_id";
        /// <summary>
        /// Cached name for the 'get_used_rect' method.
        /// </summary>
        public static readonly StringName GetUsedRect = "get_used_rect";
        /// <summary>
        /// Cached name for the 'get_pattern' method.
        /// </summary>
        public static readonly StringName GetPattern = "get_pattern";
        /// <summary>
        /// Cached name for the 'set_pattern' method.
        /// </summary>
        public static readonly StringName SetPattern = "set_pattern";
        /// <summary>
        /// Cached name for the 'set_cells_terrain_connect' method.
        /// </summary>
        public static readonly StringName SetCellsTerrainConnect = "set_cells_terrain_connect";
        /// <summary>
        /// Cached name for the 'set_cells_terrain_path' method.
        /// </summary>
        public static readonly StringName SetCellsTerrainPath = "set_cells_terrain_path";
        /// <summary>
        /// Cached name for the 'has_body_rid' method.
        /// </summary>
        public static readonly StringName HasBodyRid = "has_body_rid";
        /// <summary>
        /// Cached name for the 'get_coords_for_body_rid' method.
        /// </summary>
        public static readonly StringName GetCoordsForBodyRid = "get_coords_for_body_rid";
        /// <summary>
        /// Cached name for the 'update_internals' method.
        /// </summary>
        public static readonly StringName UpdateInternals = "update_internals";
        /// <summary>
        /// Cached name for the 'notify_runtime_tile_data_update' method.
        /// </summary>
        public static readonly StringName NotifyRuntimeTileDataUpdate = "notify_runtime_tile_data_update";
        /// <summary>
        /// Cached name for the 'map_pattern' method.
        /// </summary>
        public static readonly StringName MapPattern = "map_pattern";
        /// <summary>
        /// Cached name for the 'get_surrounding_cells' method.
        /// </summary>
        public static readonly StringName GetSurroundingCells = "get_surrounding_cells";
        /// <summary>
        /// Cached name for the 'get_neighbor_cell' method.
        /// </summary>
        public static readonly StringName GetNeighborCell = "get_neighbor_cell";
        /// <summary>
        /// Cached name for the 'map_to_local' method.
        /// </summary>
        public static readonly StringName MapToLocal = "map_to_local";
        /// <summary>
        /// Cached name for the 'local_to_map' method.
        /// </summary>
        public static readonly StringName LocalToMap = "local_to_map";
        /// <summary>
        /// Cached name for the 'set_tile_map_data_from_array' method.
        /// </summary>
        public static readonly StringName SetTileMapDataFromArray = "set_tile_map_data_from_array";
        /// <summary>
        /// Cached name for the 'get_tile_map_data_as_array' method.
        /// </summary>
        public static readonly StringName GetTileMapDataAsArray = "get_tile_map_data_as_array";
        /// <summary>
        /// Cached name for the 'set_enabled' method.
        /// </summary>
        public static readonly StringName SetEnabled = "set_enabled";
        /// <summary>
        /// Cached name for the 'is_enabled' method.
        /// </summary>
        public static readonly StringName IsEnabled = "is_enabled";
        /// <summary>
        /// Cached name for the 'set_tile_set' method.
        /// </summary>
        public static readonly StringName SetTileSet = "set_tile_set";
        /// <summary>
        /// Cached name for the 'get_tile_set' method.
        /// </summary>
        public static readonly StringName GetTileSet = "get_tile_set";
        /// <summary>
        /// Cached name for the 'set_y_sort_origin' method.
        /// </summary>
        public static readonly StringName SetYSortOrigin = "set_y_sort_origin";
        /// <summary>
        /// Cached name for the 'get_y_sort_origin' method.
        /// </summary>
        public static readonly StringName GetYSortOrigin = "get_y_sort_origin";
        /// <summary>
        /// Cached name for the 'set_x_draw_order_reversed' method.
        /// </summary>
        public static readonly StringName SetXDrawOrderReversed = "set_x_draw_order_reversed";
        /// <summary>
        /// Cached name for the 'is_x_draw_order_reversed' method.
        /// </summary>
        public static readonly StringName IsXDrawOrderReversed = "is_x_draw_order_reversed";
        /// <summary>
        /// Cached name for the 'set_rendering_quadrant_size' method.
        /// </summary>
        public static readonly StringName SetRenderingQuadrantSize = "set_rendering_quadrant_size";
        /// <summary>
        /// Cached name for the 'get_rendering_quadrant_size' method.
        /// </summary>
        public static readonly StringName GetRenderingQuadrantSize = "get_rendering_quadrant_size";
        /// <summary>
        /// Cached name for the 'set_collision_enabled' method.
        /// </summary>
        public static readonly StringName SetCollisionEnabled = "set_collision_enabled";
        /// <summary>
        /// Cached name for the 'is_collision_enabled' method.
        /// </summary>
        public static readonly StringName IsCollisionEnabled = "is_collision_enabled";
        /// <summary>
        /// Cached name for the 'set_use_kinematic_bodies' method.
        /// </summary>
        public static readonly StringName SetUseKinematicBodies = "set_use_kinematic_bodies";
        /// <summary>
        /// Cached name for the 'is_using_kinematic_bodies' method.
        /// </summary>
        public static readonly StringName IsUsingKinematicBodies = "is_using_kinematic_bodies";
        /// <summary>
        /// Cached name for the 'set_collision_visibility_mode' method.
        /// </summary>
        public static readonly StringName SetCollisionVisibilityMode = "set_collision_visibility_mode";
        /// <summary>
        /// Cached name for the 'get_collision_visibility_mode' method.
        /// </summary>
        public static readonly StringName GetCollisionVisibilityMode = "get_collision_visibility_mode";
        /// <summary>
        /// Cached name for the 'set_physics_quadrant_size' method.
        /// </summary>
        public static readonly StringName SetPhysicsQuadrantSize = "set_physics_quadrant_size";
        /// <summary>
        /// Cached name for the 'get_physics_quadrant_size' method.
        /// </summary>
        public static readonly StringName GetPhysicsQuadrantSize = "get_physics_quadrant_size";
        /// <summary>
        /// Cached name for the 'set_occlusion_enabled' method.
        /// </summary>
        public static readonly StringName SetOcclusionEnabled = "set_occlusion_enabled";
        /// <summary>
        /// Cached name for the 'is_occlusion_enabled' method.
        /// </summary>
        public static readonly StringName IsOcclusionEnabled = "is_occlusion_enabled";
        /// <summary>
        /// Cached name for the 'set_navigation_enabled' method.
        /// </summary>
        public static readonly StringName SetNavigationEnabled = "set_navigation_enabled";
        /// <summary>
        /// Cached name for the 'is_navigation_enabled' method.
        /// </summary>
        public static readonly StringName IsNavigationEnabled = "is_navigation_enabled";
        /// <summary>
        /// Cached name for the 'set_navigation_map' method.
        /// </summary>
        public static readonly StringName SetNavigationMap = "set_navigation_map";
        /// <summary>
        /// Cached name for the 'get_navigation_map' method.
        /// </summary>
        public static readonly StringName GetNavigationMap = "get_navigation_map";
        /// <summary>
        /// Cached name for the 'set_navigation_visibility_mode' method.
        /// </summary>
        public static readonly StringName SetNavigationVisibilityMode = "set_navigation_visibility_mode";
        /// <summary>
        /// Cached name for the 'get_navigation_visibility_mode' method.
        /// </summary>
        public static readonly StringName GetNavigationVisibilityMode = "get_navigation_visibility_mode";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Node2D.SignalName
    {
        /// <summary>
        /// Cached name for the 'changed' signal.
        /// </summary>
        public static readonly StringName Changed = "changed";
    }
}
