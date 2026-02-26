namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Node for 2D tile-based maps. Tilemaps use a <see cref="Godot.TileSet"/> which contain a list of tiles which are used to create grid-based maps. A TileMap may have several layers, layouting tiles on top of each other.</para>
/// <para>For performance reasons, all TileMap updates are batched at the end of a frame. Notably, this means that scene tiles from a <see cref="Godot.TileSetScenesCollectionSource"/> may be initialized after their parent. This is only queued when inside the scene tree.</para>
/// <para>To force an update earlier on, call <see cref="Godot.TileMap.UpdateInternals()"/>.</para>
/// <para><b>Note:</b> For performance and compatibility reasons, the coordinates serialized by <see cref="Godot.TileMap"/> are limited to 16-bit signed integers, i.e. the range for X and Y coordinates is from <c>-32768</c> to <c>32767</c>. When saving tile data, tiles outside this range are wrapped.</para>
/// </summary>
[Obsolete("Use multiple 'TileMapLayer' nodes instead. To convert a TileMap to a set of TileMapLayer nodes, open the TileMap bottom panel with the node selected, click the toolbox icon in the top-right corner and choose 'Extract TileMap layers as individual TileMapLayer nodes'.")]
public partial class TileMap : Node2D
{
    public enum VisibilityMode : long
    {
        /// <summary>
        /// <para>Use the debug settings to determine visibility.</para>
        /// </summary>
        Default = 0,
        /// <summary>
        /// <para>Always hide.</para>
        /// </summary>
        ForceHide = 2,
        /// <summary>
        /// <para>Always show.</para>
        /// </summary>
        ForceShow = 1
    }

    /// <summary>
    /// <para>The <see cref="Godot.TileSet"/> used by this <see cref="Godot.TileMap"/>. The textures, collisions, and additional behavior of all available tiles are stored here.</para>
    /// </summary>
    public TileSet TileSet
    {
        get
        {
            return GetTileset();
        }
        set
        {
            SetTileset(value);
        }
    }

    /// <summary>
    /// <para>The TileMap's quadrant size. A quadrant is a group of tiles to be drawn together on a single canvas item, for optimization purposes. <see cref="Godot.TileMap.RenderingQuadrantSize"/> defines the length of a square's side, in the map's coordinate system, that forms the quadrant. Thus, the default quadrant size groups together <c>16 * 16 = 256</c> tiles.</para>
    /// <para>The quadrant size does not apply on Y-sorted layers, as tiles are grouped by Y position instead in that case.</para>
    /// <para><b>Note:</b> As quadrants are created according to the map's coordinate system, the quadrant's "square shape" might not look like square in the TileMap's local coordinate system.</para>
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
    /// <para>If enabled, the TileMap will see its collisions synced to the physics tick and change its collision type from static to kinematic. This is required to create TileMap-based moving platform.</para>
    /// <para><b>Note:</b> Enabling <see cref="Godot.TileMap.CollisionAnimatable"/> may have a small performance impact, only do it if the TileMap is moving and has colliding tiles.</para>
    /// </summary>
    public bool CollisionAnimatable
    {
        get
        {
            return IsCollisionAnimatable();
        }
        set
        {
            SetCollisionAnimatable(value);
        }
    }

    /// <summary>
    /// <para>Show or hide the TileMap's collision shapes. If set to <see cref="Godot.TileMap.VisibilityMode.Default"/>, this depends on the show collision debug settings.</para>
    /// </summary>
    public TileMap.VisibilityMode CollisionVisibilityMode
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
    /// <para>Show or hide the TileMap's navigation meshes. If set to <see cref="Godot.TileMap.VisibilityMode.Default"/>, this depends on the show navigation debug settings.</para>
    /// </summary>
    public TileMap.VisibilityMode NavigationVisibilityMode
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

    private static readonly System.Type CachedType = typeof(TileMap);

    private static readonly StringName NativeName = "TileMap";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public TileMap() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal TileMap(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal TileMap(bool memoryOwn) : base(memoryOwn) { }

    /// <summary>
    /// <para>Called with a TileData object about to be used internally by the TileMap, allowing its modification at runtime.</para>
    /// <para>This method is only called if <see cref="Godot.TileMap._UseTileDataRuntimeUpdate(int, Vector2I)"/> is implemented and returns <see langword="true"/> for the given tile <paramref name="coords"/> and <paramref name="layer"/>.</para>
    /// <para><b>Warning:</b> The <paramref name="tileData"/> object's sub-resources are the same as the one in the TileSet. Modifying them might impact the whole TileSet. Instead, make sure to duplicate those resources.</para>
    /// <para><b>Note:</b> If the properties of <paramref name="tileData"/> object should change over time, use <see cref="Godot.TileMap.NotifyRuntimeTileDataUpdate(int)"/> to notify the TileMap it needs an update.</para>
    /// </summary>
    public virtual unsafe void _TileDataRuntimeUpdate(int layer, Vector2I coords, TileData tileData)
    {
    }

    /// <summary>
    /// <para>Should return <see langword="true"/> if the tile at coordinates <paramref name="coords"/> on layer <paramref name="layer"/> requires a runtime update.</para>
    /// <para><b>Warning:</b> Make sure this function only return <see langword="true"/> when needed. Any tile processed at runtime without a need for it will imply a significant performance penalty.</para>
    /// <para><b>Note:</b> If the result of this function should changed, use <see cref="Godot.TileMap.NotifyRuntimeTileDataUpdate(int)"/> to notify the TileMap it needs an update.</para>
    /// </summary>
    public virtual unsafe bool _UseTileDataRuntimeUpdate(int layer, Vector2I coords)
    {
        return default;
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetNavigationMap, 4040184819ul);

    /// <summary>
    /// <para>Assigns <paramref name="map"/> as a <see cref="Godot.NavigationServer2D"/> navigation map for the specified TileMap layer <paramref name="layer"/>.</para>
    /// </summary>
    [Obsolete("Use 'Godot.TileMap.SetLayerNavigationMap(int, Rid)' instead.")]
    public void SetNavigationMap(int layer, Rid map)
    {
        NativeCalls.godot_icall_2_449(MethodBind0, GodotObject.GetPtr(this), layer, map);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNavigationMap, 495598643ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.Rid"/> of the <see cref="Godot.NavigationServer2D"/> navigation map assigned to the specified TileMap layer <paramref name="layer"/>.</para>
    /// </summary>
    [Obsolete("Use 'Godot.TileMap.GetLayerNavigationMap(int)' instead.")]
    public Rid GetNavigationMap(int layer)
    {
        return NativeCalls.godot_icall_1_425(MethodBind1, GodotObject.GetPtr(this), layer);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ForceUpdate, 1025054187ul);

    /// <summary>
    /// <para>Forces the TileMap and the layer <paramref name="layer"/> to update.</para>
    /// </summary>
    [Obsolete("Use 'Godot.TileMap.NotifyRuntimeTileDataUpdate(int)' and/or 'Godot.TileMap.UpdateInternals()' instead.")]
    public void ForceUpdate(int layer = -1)
    {
        NativeCalls.godot_icall_1_38(MethodBind2, GodotObject.GetPtr(this), layer);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTileset, 774531446ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTileset(TileSet tileset)
    {
        NativeCalls.godot_icall_1_56(MethodBind3, GodotObject.GetPtr(this), GodotObject.GetPtr(tileset));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTileset, 2678226422ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public TileSet GetTileset()
    {
        return (TileSet)NativeCalls.godot_icall_0_63(MethodBind4, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRenderingQuadrantSize, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetRenderingQuadrantSize(int size)
    {
        NativeCalls.godot_icall_1_38(MethodBind5, GodotObject.GetPtr(this), size);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRenderingQuadrantSize, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetRenderingQuadrantSize()
    {
        return NativeCalls.godot_icall_0_39(MethodBind6, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLayersCount, 3905245786ul);

    /// <summary>
    /// <para>Returns the number of layers in the TileMap.</para>
    /// </summary>
    public int GetLayersCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddLayer, 1286410249ul);

    /// <summary>
    /// <para>Adds a layer at the given position <paramref name="toPosition"/> in the array. If <paramref name="toPosition"/> is negative, the position is counted from the end, with <c>-1</c> adding the layer at the end of the array.</para>
    /// </summary>
    public void AddLayer(int toPosition)
    {
        NativeCalls.godot_icall_1_38(MethodBind8, GodotObject.GetPtr(this), toPosition);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MoveLayer, 3937882851ul);

    /// <summary>
    /// <para>Moves the layer at index <paramref name="layer"/> to the given position <paramref name="toPosition"/> in the array.</para>
    /// </summary>
    public void MoveLayer(int layer, int toPosition)
    {
        NativeCalls.godot_icall_2_59(MethodBind9, GodotObject.GetPtr(this), layer, toPosition);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveLayer, 1286410249ul);

    /// <summary>
    /// <para>Removes the layer at index <paramref name="layer"/>.</para>
    /// </summary>
    public void RemoveLayer(int layer)
    {
        NativeCalls.godot_icall_1_38(MethodBind10, GodotObject.GetPtr(this), layer);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLayerName, 501894301ul);

    /// <summary>
    /// <para>Sets a layer's name. This is mostly useful in the editor.</para>
    /// <para>If <paramref name="layer"/> is negative, the layers are accessed from the last one.</para>
    /// </summary>
    public void SetLayerName(int layer, string name)
    {
        NativeCalls.godot_icall_2_181(MethodBind11, GodotObject.GetPtr(this), layer, name);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLayerName, 844755477ul);

    /// <summary>
    /// <para>Returns a TileMap layer's name.</para>
    /// <para>If <paramref name="layer"/> is negative, the layers are accessed from the last one.</para>
    /// </summary>
    public string GetLayerName(int layer)
    {
        return NativeCalls.godot_icall_1_133(MethodBind12, GodotObject.GetPtr(this), layer);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLayerEnabled, 300928843ul);

    /// <summary>
    /// <para>Enables or disables the layer <paramref name="layer"/>. A disabled layer is not processed at all (no rendering, no physics, etc.).</para>
    /// <para>If <paramref name="layer"/> is negative, the layers are accessed from the last one.</para>
    /// </summary>
    public void SetLayerEnabled(int layer, bool enabled)
    {
        NativeCalls.godot_icall_2_61(MethodBind13, GodotObject.GetPtr(this), layer, enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsLayerEnabled, 1116898809ul);

    /// <summary>
    /// <para>Returns if a layer is enabled.</para>
    /// <para>If <paramref name="layer"/> is negative, the layers are accessed from the last one.</para>
    /// </summary>
    public bool IsLayerEnabled(int layer)
    {
        return NativeCalls.godot_icall_1_62(MethodBind14, GodotObject.GetPtr(this), layer).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLayerModulate, 2878471219ul);

    /// <summary>
    /// <para>Sets a layer's color. It will be multiplied by tile's color and TileMap's modulate.</para>
    /// <para>If <paramref name="layer"/> is negative, the layers are accessed from the last one.</para>
    /// </summary>
    public unsafe void SetLayerModulate(int layer, Color modulate)
    {
        NativeCalls.godot_icall_2_687(MethodBind15, GodotObject.GetPtr(this), layer, &modulate);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLayerModulate, 3457211756ul);

    /// <summary>
    /// <para>Returns a TileMap layer's modulate.</para>
    /// <para>If <paramref name="layer"/> is negative, the layers are accessed from the last one.</para>
    /// </summary>
    public Color GetLayerModulate(int layer)
    {
        return NativeCalls.godot_icall_1_688(MethodBind16, GodotObject.GetPtr(this), layer);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLayerYSortEnabled, 300928843ul);

    /// <summary>
    /// <para>Enables or disables a layer's Y-sorting. If a layer is Y-sorted, the layer will behave as a CanvasItem node where each of its tile gets Y-sorted.</para>
    /// <para>Y-sorted layers should usually be on different Z-index values than not Y-sorted layers, otherwise, each of those layer will be Y-sorted as whole with the Y-sorted one. This is usually an undesired behavior.</para>
    /// <para>If <paramref name="layer"/> is negative, the layers are accessed from the last one.</para>
    /// </summary>
    public void SetLayerYSortEnabled(int layer, bool ySortEnabled)
    {
        NativeCalls.godot_icall_2_61(MethodBind17, GodotObject.GetPtr(this), layer, ySortEnabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsLayerYSortEnabled, 1116898809ul);

    /// <summary>
    /// <para>Returns if a layer Y-sorts its tiles.</para>
    /// <para>If <paramref name="layer"/> is negative, the layers are accessed from the last one.</para>
    /// </summary>
    public bool IsLayerYSortEnabled(int layer)
    {
        return NativeCalls.godot_icall_1_62(MethodBind18, GodotObject.GetPtr(this), layer).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLayerYSortOrigin, 3937882851ul);

    /// <summary>
    /// <para>Sets a layer's Y-sort origin value. This Y-sort origin value is added to each tile's Y-sort origin value.</para>
    /// <para>This allows, for example, to fake a different height level on each layer. This can be useful for top-down view games.</para>
    /// <para>If <paramref name="layer"/> is negative, the layers are accessed from the last one.</para>
    /// </summary>
    public void SetLayerYSortOrigin(int layer, int ySortOrigin)
    {
        NativeCalls.godot_icall_2_59(MethodBind19, GodotObject.GetPtr(this), layer, ySortOrigin);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLayerYSortOrigin, 923996154ul);

    /// <summary>
    /// <para>Returns a TileMap layer's Y sort origin.</para>
    /// <para>If <paramref name="layer"/> is negative, the layers are accessed from the last one.</para>
    /// </summary>
    public int GetLayerYSortOrigin(int layer)
    {
        return NativeCalls.godot_icall_1_60(MethodBind20, GodotObject.GetPtr(this), layer);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLayerZIndex, 3937882851ul);

    /// <summary>
    /// <para>Sets a layers Z-index value. This Z-index is added to each tile's Z-index value.</para>
    /// <para>If <paramref name="layer"/> is negative, the layers are accessed from the last one.</para>
    /// </summary>
    public void SetLayerZIndex(int layer, int zIndex)
    {
        NativeCalls.godot_icall_2_59(MethodBind21, GodotObject.GetPtr(this), layer, zIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLayerZIndex, 923996154ul);

    /// <summary>
    /// <para>Returns a TileMap layer's Z-index value.</para>
    /// <para>If <paramref name="layer"/> is negative, the layers are accessed from the last one.</para>
    /// </summary>
    public int GetLayerZIndex(int layer)
    {
        return NativeCalls.godot_icall_1_60(MethodBind22, GodotObject.GetPtr(this), layer);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLayerNavigationEnabled, 300928843ul);

    /// <summary>
    /// <para>Enables or disables a layer's built-in navigation regions generation. Disable this if you need to bake navigation regions from a TileMap using a <see cref="Godot.NavigationRegion2D"/> node.</para>
    /// </summary>
    public void SetLayerNavigationEnabled(int layer, bool enabled)
    {
        NativeCalls.godot_icall_2_61(MethodBind23, GodotObject.GetPtr(this), layer, enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsLayerNavigationEnabled, 1116898809ul);

    /// <summary>
    /// <para>Returns if a layer's built-in navigation regions generation is enabled.</para>
    /// </summary>
    public bool IsLayerNavigationEnabled(int layer)
    {
        return NativeCalls.godot_icall_1_62(MethodBind24, GodotObject.GetPtr(this), layer).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLayerNavigationMap, 4040184819ul);

    /// <summary>
    /// <para>Assigns <paramref name="map"/> as a <see cref="Godot.NavigationServer2D"/> navigation map for the specified TileMap layer <paramref name="layer"/>.</para>
    /// <para>By default the TileMap uses the default <see cref="Godot.World2D"/> navigation map for the first TileMap layer. For each additional TileMap layer a new navigation map is created for the additional layer.</para>
    /// <para>In order to make <see cref="Godot.NavigationAgent2D"/> switch between TileMap layer navigation maps use <see cref="Godot.NavigationAgent2D.SetNavigationMap(Rid)"/> with the navigation map received from <see cref="Godot.TileMap.GetLayerNavigationMap(int)"/>.</para>
    /// <para>If <paramref name="layer"/> is negative, the layers are accessed from the last one.</para>
    /// </summary>
    public void SetLayerNavigationMap(int layer, Rid map)
    {
        NativeCalls.godot_icall_2_449(MethodBind25, GodotObject.GetPtr(this), layer, map);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLayerNavigationMap, 495598643ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.Rid"/> of the <see cref="Godot.NavigationServer2D"/> navigation map assigned to the specified TileMap layer <paramref name="layer"/>.</para>
    /// <para>By default the TileMap uses the default <see cref="Godot.World2D"/> navigation map for the first TileMap layer. For each additional TileMap layer a new navigation map is created for the additional layer.</para>
    /// <para>In order to make <see cref="Godot.NavigationAgent2D"/> switch between TileMap layer navigation maps use <see cref="Godot.NavigationAgent2D.SetNavigationMap(Rid)"/> with the navigation map received from <see cref="Godot.TileMap.GetLayerNavigationMap(int)"/>.</para>
    /// <para>If <paramref name="layer"/> is negative, the layers are accessed from the last one.</para>
    /// </summary>
    public Rid GetLayerNavigationMap(int layer)
    {
        return NativeCalls.godot_icall_1_425(MethodBind26, GodotObject.GetPtr(this), layer);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCollisionAnimatable, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCollisionAnimatable(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind27, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsCollisionAnimatable, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsCollisionAnimatable()
    {
        return NativeCalls.godot_icall_0_15(MethodBind28, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCollisionVisibilityMode, 3193440636ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCollisionVisibilityMode(TileMap.VisibilityMode collisionVisibilityMode)
    {
        NativeCalls.godot_icall_1_38(MethodBind29, GodotObject.GetPtr(this), (int)collisionVisibilityMode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCollisionVisibilityMode, 1697018252ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public TileMap.VisibilityMode GetCollisionVisibilityMode()
    {
        return (TileMap.VisibilityMode)NativeCalls.godot_icall_0_39(MethodBind30, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetNavigationVisibilityMode, 3193440636ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetNavigationVisibilityMode(TileMap.VisibilityMode navigationVisibilityMode)
    {
        NativeCalls.godot_icall_1_38(MethodBind31, GodotObject.GetPtr(this), (int)navigationVisibilityMode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind32 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNavigationVisibilityMode, 1697018252ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public TileMap.VisibilityMode GetNavigationVisibilityMode()
    {
        return (TileMap.VisibilityMode)NativeCalls.godot_icall_0_39(MethodBind32, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind33 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCell, 966713560ul);

    /// <summary>
    /// <para>Sets the tile identifiers for the cell on layer <paramref name="layer"/> at coordinates <paramref name="coords"/>. Each tile of the <see cref="Godot.TileSet"/> is identified using three parts:</para>
    /// <para>- The source identifier <paramref name="sourceId"/> identifies a <see cref="Godot.TileSetSource"/> identifier. See <see cref="Godot.TileSet.SetSourceId(int, int)"/>,</para>
    /// <para>- The atlas coordinates identifier <paramref name="atlasCoords"/> identifies a tile coordinates in the atlas (if the source is a <see cref="Godot.TileSetAtlasSource"/>). For <see cref="Godot.TileSetScenesCollectionSource"/> it should always be <c>Vector2i(0, 0)</c>),</para>
    /// <para>- The alternative tile identifier <paramref name="alternativeTile"/> identifies a tile alternative in the atlas (if the source is a <see cref="Godot.TileSetAtlasSource"/>), and the scene for a <see cref="Godot.TileSetScenesCollectionSource"/>.</para>
    /// <para>If <paramref name="sourceId"/> is set to <c>-1</c>, <paramref name="atlasCoords"/> to <c>Vector2i(-1, -1)</c> or <paramref name="alternativeTile"/> to <c>-1</c>, the cell will be erased. An erased cell gets <b>all</b> its identifiers automatically set to their respective invalid values, namely <c>-1</c>, <c>Vector2i(-1, -1)</c> and <c>-1</c>.</para>
    /// <para>If <paramref name="layer"/> is negative, the layers are accessed from the last one.</para>
    /// </summary>
    /// <param name="atlasCoords">If the parameter is null, then the default value is <c>new Vector2I(-1, -1)</c>.</param>
    public unsafe void SetCell(int layer, Vector2I coords, int sourceId = -1, Nullable<Vector2I> atlasCoords = null, int alternativeTile = 0)
    {
        Vector2I atlasCoordsOrDefVal = atlasCoords.HasValue ? atlasCoords.Value : new Vector2I(-1, -1);
        NativeCalls.godot_icall_5_1424(MethodBind33, GodotObject.GetPtr(this), layer, &coords, sourceId, &atlasCoordsOrDefVal, alternativeTile);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind34 = ClassDB_get_method_with_compatibility(NativeName, MethodName.EraseCell, 2311374912ul);

    /// <summary>
    /// <para>Erases the cell on layer <paramref name="layer"/> at coordinates <paramref name="coords"/>.</para>
    /// <para>If <paramref name="layer"/> is negative, the layers are accessed from the last one.</para>
    /// </summary>
    public unsafe void EraseCell(int layer, Vector2I coords)
    {
        NativeCalls.godot_icall_2_605(MethodBind34, GodotObject.GetPtr(this), layer, &coords);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind35 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCellSourceId, 551761942ul);

    /// <summary>
    /// <para>Returns the tile source ID of the cell on layer <paramref name="layer"/> at coordinates <paramref name="coords"/>. Returns <c>-1</c> if the cell does not exist.</para>
    /// <para>If <paramref name="useProxies"/> is <see langword="false"/>, ignores the <see cref="Godot.TileSet"/>'s tile proxies, returning the raw source identifier. See <see cref="Godot.TileSet.MapTileProxy(int, Vector2I, int)"/>.</para>
    /// <para>If <paramref name="layer"/> is negative, the layers are accessed from the last one.</para>
    /// </summary>
    public unsafe int GetCellSourceId(int layer, Vector2I coords, bool useProxies = false)
    {
        return NativeCalls.godot_icall_3_1425(MethodBind35, GodotObject.GetPtr(this), layer, &coords, useProxies.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind36 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCellAtlasCoords, 1869815066ul);

    /// <summary>
    /// <para>Returns the tile atlas coordinates ID of the cell on layer <paramref name="layer"/> at coordinates <paramref name="coords"/>. Returns <c>Vector2i(-1, -1)</c> if the cell does not exist.</para>
    /// <para>If <paramref name="useProxies"/> is <see langword="false"/>, ignores the <see cref="Godot.TileSet"/>'s tile proxies, returning the raw atlas coordinate identifier. See <see cref="Godot.TileSet.MapTileProxy(int, Vector2I, int)"/>.</para>
    /// <para>If <paramref name="layer"/> is negative, the layers are accessed from the last one.</para>
    /// </summary>
    public unsafe Vector2I GetCellAtlasCoords(int layer, Vector2I coords, bool useProxies = false)
    {
        return NativeCalls.godot_icall_3_1426(MethodBind36, GodotObject.GetPtr(this), layer, &coords, useProxies.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind37 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCellAlternativeTile, 551761942ul);

    /// <summary>
    /// <para>Returns the tile alternative ID of the cell on layer <paramref name="layer"/> at <paramref name="coords"/>.</para>
    /// <para>If <paramref name="useProxies"/> is <see langword="false"/>, ignores the <see cref="Godot.TileSet"/>'s tile proxies, returning the raw alternative identifier. See <see cref="Godot.TileSet.MapTileProxy(int, Vector2I, int)"/>.</para>
    /// <para>If <paramref name="layer"/> is negative, the layers are accessed from the last one.</para>
    /// </summary>
    public unsafe int GetCellAlternativeTile(int layer, Vector2I coords, bool useProxies = false)
    {
        return NativeCalls.godot_icall_3_1425(MethodBind37, GodotObject.GetPtr(this), layer, &coords, useProxies.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind38 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCellTileData, 2849631287ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.TileData"/> object associated with the given cell, or <see langword="null"/> if the cell does not exist or is not a <see cref="Godot.TileSetAtlasSource"/>.</para>
    /// <para>If <paramref name="layer"/> is negative, the layers are accessed from the last one.</para>
    /// <para><code>
    /// func get_clicked_tile_power():
    /// 	var clicked_cell = tile_map.local_to_map(tile_map.get_local_mouse_position())
    /// 	var data = tile_map.get_cell_tile_data(0, clicked_cell)
    /// 	if data:
    /// 		return data.get_custom_data("power")
    /// 	else:
    /// 		return 0
    /// </code></para>
    /// <para>If <paramref name="useProxies"/> is <see langword="false"/>, ignores the <see cref="Godot.TileSet"/>'s tile proxies. See <see cref="Godot.TileSet.MapTileProxy(int, Vector2I, int)"/>.</para>
    /// </summary>
    public unsafe TileData GetCellTileData(int layer, Vector2I coords, bool useProxies = false)
    {
        return (TileData)NativeCalls.godot_icall_3_1427(MethodBind38, GodotObject.GetPtr(this), layer, &coords, useProxies.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind39 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsCellFlippedH, 2908343862ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the cell on layer <paramref name="layer"/> at coordinates <paramref name="coords"/> is flipped horizontally. The result is valid only for atlas sources.</para>
    /// </summary>
    public unsafe bool IsCellFlippedH(int layer, Vector2I coords, bool useProxies = false)
    {
        return NativeCalls.godot_icall_3_1428(MethodBind39, GodotObject.GetPtr(this), layer, &coords, useProxies.ToGodotBool()).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind40 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsCellFlippedV, 2908343862ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the cell on layer <paramref name="layer"/> at coordinates <paramref name="coords"/> is flipped vertically. The result is valid only for atlas sources.</para>
    /// </summary>
    public unsafe bool IsCellFlippedV(int layer, Vector2I coords, bool useProxies = false)
    {
        return NativeCalls.godot_icall_3_1428(MethodBind40, GodotObject.GetPtr(this), layer, &coords, useProxies.ToGodotBool()).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind41 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsCellTransposed, 2908343862ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the cell on layer <paramref name="layer"/> at coordinates <paramref name="coords"/> is transposed. The result is valid only for atlas sources.</para>
    /// </summary>
    public unsafe bool IsCellTransposed(int layer, Vector2I coords, bool useProxies = false)
    {
        return NativeCalls.godot_icall_3_1428(MethodBind41, GodotObject.GetPtr(this), layer, &coords, useProxies.ToGodotBool()).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind42 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCoordsForBodyRid, 291584212ul);

    /// <summary>
    /// <para>Returns the coordinates of the tile for given physics body RID. Such RID can be retrieved from <see cref="Godot.KinematicCollision2D.GetColliderRid()"/>, when colliding with a tile.</para>
    /// </summary>
    public Vector2I GetCoordsForBodyRid(Rid body)
    {
        return NativeCalls.godot_icall_1_1382(MethodBind42, GodotObject.GetPtr(this), body);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind43 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLayerForBodyRid, 3917799429ul);

    /// <summary>
    /// <para>Returns the tilemap layer of the tile for given physics body RID. Such RID can be retrieved from <see cref="Godot.KinematicCollision2D.GetColliderRid()"/>, when colliding with a tile.</para>
    /// </summary>
    public int GetLayerForBodyRid(Rid body)
    {
        return NativeCalls.godot_icall_1_835(MethodBind43, GodotObject.GetPtr(this), body);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind44 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPattern, 2833570986ul);

    /// <summary>
    /// <para>Creates a new <see cref="Godot.TileMapPattern"/> from the given layer and set of cells.</para>
    /// <para>If <paramref name="layer"/> is negative, the layers are accessed from the last one.</para>
    /// </summary>
    public TileMapPattern GetPattern(int layer, Godot.Collections.Array<Vector2I> coordsArray)
    {
        return (TileMapPattern)NativeCalls.godot_icall_2_1429(MethodBind44, GodotObject.GetPtr(this), layer, (godot_array)(coordsArray ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind45 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MapPattern, 1864516957ul);

    /// <summary>
    /// <para>Returns for the given coordinate <paramref name="coordsInPattern"/> in a <see cref="Godot.TileMapPattern"/> the corresponding cell coordinates if the pattern was pasted at the <paramref name="positionInTilemap"/> coordinates (see <see cref="Godot.TileMap.SetPattern(int, Vector2I, TileMapPattern)"/>). This mapping is required as in half-offset tile shapes, the mapping might not work by calculating <c>position_in_tile_map + coords_in_pattern</c>.</para>
    /// </summary>
    public unsafe Vector2I MapPattern(Vector2I positionInTilemap, Vector2I coordsInPattern, TileMapPattern pattern)
    {
        return NativeCalls.godot_icall_3_1430(MethodBind45, GodotObject.GetPtr(this), &positionInTilemap, &coordsInPattern, GodotObject.GetPtr(pattern));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind46 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPattern, 1195853946ul);

    /// <summary>
    /// <para>Paste the given <see cref="Godot.TileMapPattern"/> at the given <paramref name="position"/> and <paramref name="layer"/> in the tile map.</para>
    /// <para>If <paramref name="layer"/> is negative, the layers are accessed from the last one.</para>
    /// </summary>
    public unsafe void SetPattern(int layer, Vector2I position, TileMapPattern pattern)
    {
        NativeCalls.godot_icall_3_1431(MethodBind46, GodotObject.GetPtr(this), layer, &position, GodotObject.GetPtr(pattern));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind47 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCellsTerrainConnect, 3578627656ul);

    /// <summary>
    /// <para>Update all the cells in the <paramref name="cells"/> coordinates array so that they use the given <paramref name="terrain"/> for the given <paramref name="terrainSet"/>. If an updated cell has the same terrain as one of its neighboring cells, this function tries to join the two. This function might update neighboring tiles if needed to create correct terrain transitions.</para>
    /// <para>If <paramref name="ignoreEmptyTerrains"/> is <see langword="true"/>, empty terrains will be ignored when trying to find the best fitting tile for the given terrain constraints.</para>
    /// <para>If <paramref name="layer"/> is negative, the layers are accessed from the last one.</para>
    /// <para><b>Note:</b> To work correctly, this method requires the TileMap's TileSet to have terrains set up with all required terrain combinations. Otherwise, it may produce unexpected results.</para>
    /// </summary>
    public void SetCellsTerrainConnect(int layer, Godot.Collections.Array<Vector2I> cells, int terrainSet, int terrain, bool ignoreEmptyTerrains = true)
    {
        NativeCalls.godot_icall_5_1432(MethodBind47, GodotObject.GetPtr(this), layer, (godot_array)(cells ?? new()).NativeValue, terrainSet, terrain, ignoreEmptyTerrains.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind48 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCellsTerrainPath, 3578627656ul);

    /// <summary>
    /// <para>Update all the cells in the <paramref name="path"/> coordinates array so that they use the given <paramref name="terrain"/> for the given <paramref name="terrainSet"/>. The function will also connect two successive cell in the path with the same terrain. This function might update neighboring tiles if needed to create correct terrain transitions.</para>
    /// <para>If <paramref name="ignoreEmptyTerrains"/> is <see langword="true"/>, empty terrains will be ignored when trying to find the best fitting tile for the given terrain constraints.</para>
    /// <para>If <paramref name="layer"/> is negative, the layers are accessed from the last one.</para>
    /// <para><b>Note:</b> To work correctly, this method requires the TileMap's TileSet to have terrains set up with all required terrain combinations. Otherwise, it may produce unexpected results.</para>
    /// </summary>
    public void SetCellsTerrainPath(int layer, Godot.Collections.Array<Vector2I> path, int terrainSet, int terrain, bool ignoreEmptyTerrains = true)
    {
        NativeCalls.godot_icall_5_1432(MethodBind48, GodotObject.GetPtr(this), layer, (godot_array)(path ?? new()).NativeValue, terrainSet, terrain, ignoreEmptyTerrains.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind49 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FixInvalidTiles, 3218959716ul);

    /// <summary>
    /// <para>Clears cells that do not exist in the tileset.</para>
    /// </summary>
    public void FixInvalidTiles()
    {
        NativeCalls.godot_icall_0_3(MethodBind49, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind50 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ClearLayer, 1286410249ul);

    /// <summary>
    /// <para>Clears all cells on the given layer.</para>
    /// <para>If <paramref name="layer"/> is negative, the layers are accessed from the last one.</para>
    /// </summary>
    public void ClearLayer(int layer)
    {
        NativeCalls.godot_icall_1_38(MethodBind50, GodotObject.GetPtr(this), layer);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind51 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Clear, 3218959716ul);

    /// <summary>
    /// <para>Clears all cells.</para>
    /// </summary>
    public void Clear()
    {
        NativeCalls.godot_icall_0_3(MethodBind51, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind52 = ClassDB_get_method_with_compatibility(NativeName, MethodName.UpdateInternals, 3218959716ul);

    /// <summary>
    /// <para>Triggers a direct update of the TileMap. Usually, calling this function is not needed, as TileMap node updates automatically when one of its properties or cells is modified.</para>
    /// <para>However, for performance reasons, those updates are batched and delayed to the end of the frame. Calling this function will force the TileMap to update right away instead.</para>
    /// <para><b>Warning:</b> Updating the TileMap is computationally expensive and may impact performance. Try to limit the number of updates and how many tiles they impact.</para>
    /// </summary>
    public void UpdateInternals()
    {
        NativeCalls.godot_icall_0_3(MethodBind52, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind53 = ClassDB_get_method_with_compatibility(NativeName, MethodName.NotifyRuntimeTileDataUpdate, 1025054187ul);

    /// <summary>
    /// <para>Notifies the TileMap node that calls to <see cref="Godot.TileMap._UseTileDataRuntimeUpdate(int, Vector2I)"/> or <see cref="Godot.TileMap._TileDataRuntimeUpdate(int, Vector2I, TileData)"/> will lead to different results. This will thus trigger a TileMap update.</para>
    /// <para>If <paramref name="layer"/> is provided, only notifies changes for the given layer. Providing the <paramref name="layer"/> argument (when applicable) is usually preferred for performance reasons.</para>
    /// <para><b>Warning:</b> Updating the TileMap is computationally expensive and may impact performance. Try to limit the number of calls to this function to avoid unnecessary update.</para>
    /// <para><b>Note:</b> This does not trigger a direct update of the TileMap, the update will be done at the end of the frame as usual (unless you call <see cref="Godot.TileMap.UpdateInternals()"/>).</para>
    /// </summary>
    public void NotifyRuntimeTileDataUpdate(int layer = -1)
    {
        NativeCalls.godot_icall_1_38(MethodBind53, GodotObject.GetPtr(this), layer);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind54 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSurroundingCells, 2673526557ul);

    /// <summary>
    /// <para>Returns the list of all neighbourings cells to the one at <paramref name="coords"/>.</para>
    /// </summary>
    public unsafe Godot.Collections.Array<Vector2I> GetSurroundingCells(Vector2I coords)
    {
        return new Godot.Collections.Array<Vector2I>(NativeCalls.godot_icall_1_1433(MethodBind54, GodotObject.GetPtr(this), &coords));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind55 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetUsedCells, 663333327ul);

    /// <summary>
    /// <para>Returns a <see cref="Godot.Vector2I"/> array with the positions of all cells containing a tile in the given layer. A cell is considered empty if its source identifier equals -1, its atlas coordinates identifiers is <c>Vector2(-1, -1)</c> and its alternative identifier is -1.</para>
    /// <para>If <paramref name="layer"/> is negative, the layers are accessed from the last one.</para>
    /// </summary>
    public Godot.Collections.Array<Vector2I> GetUsedCells(int layer)
    {
        return new Godot.Collections.Array<Vector2I>(NativeCalls.godot_icall_1_457(MethodBind55, GodotObject.GetPtr(this), layer));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind56 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetUsedCellsById, 2931012785ul);

    /// <summary>
    /// <para>Returns a <see cref="Godot.Vector2I"/> array with the positions of all cells containing a tile in the given layer. Tiles may be filtered according to their source (<paramref name="sourceId"/>), their atlas coordinates (<paramref name="atlasCoords"/>) or alternative id (<paramref name="alternativeTile"/>).</para>
    /// <para>If a parameter has its value set to the default one, this parameter is not used to filter a cell. Thus, if all parameters have their respective default value, this method returns the same result as <see cref="Godot.TileMap.GetUsedCells(int)"/>.</para>
    /// <para>A cell is considered empty if its source identifier equals -1, its atlas coordinates identifiers is <c>Vector2(-1, -1)</c> and its alternative identifier is -1.</para>
    /// <para>If <paramref name="layer"/> is negative, the layers are accessed from the last one.</para>
    /// </summary>
    /// <param name="atlasCoords">If the parameter is null, then the default value is <c>new Vector2I(-1, -1)</c>.</param>
    public unsafe Godot.Collections.Array<Vector2I> GetUsedCellsById(int layer, int sourceId = -1, Nullable<Vector2I> atlasCoords = null, int alternativeTile = -1)
    {
        Vector2I atlasCoordsOrDefVal = atlasCoords.HasValue ? atlasCoords.Value : new Vector2I(-1, -1);
        return new Godot.Collections.Array<Vector2I>(NativeCalls.godot_icall_4_1434(MethodBind56, GodotObject.GetPtr(this), layer, sourceId, &atlasCoordsOrDefVal, alternativeTile));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind57 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetUsedRect, 410525958ul);

    /// <summary>
    /// <para>Returns a rectangle enclosing the used (non-empty) tiles of the map, including all layers.</para>
    /// </summary>
    public Rect2I GetUsedRect()
    {
        return NativeCalls.godot_icall_0_33(MethodBind57, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind58 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MapToLocal, 108438297ul);

    /// <summary>
    /// <para>Returns the centered position of a cell in the TileMap's local coordinate space. To convert the returned value into global coordinates, use <see cref="Godot.Node2D.ToGlobal(Vector2)"/>. See also <see cref="Godot.TileMap.LocalToMap(Vector2)"/>.</para>
    /// <para><b>Note:</b> This may not correspond to the visual position of the tile, i.e. it ignores the <see cref="Godot.TileData.TextureOrigin"/> property of individual tiles.</para>
    /// </summary>
    public unsafe Vector2 MapToLocal(Vector2I mapPosition)
    {
        return NativeCalls.godot_icall_1_47(MethodBind58, GodotObject.GetPtr(this), &mapPosition);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind59 = ClassDB_get_method_with_compatibility(NativeName, MethodName.LocalToMap, 837806996ul);

    /// <summary>
    /// <para>Returns the map coordinates of the cell containing the given <paramref name="localPosition"/>. If <paramref name="localPosition"/> is in global coordinates, consider using <see cref="Godot.Node2D.ToLocal(Vector2)"/> before passing it to this method. See also <see cref="Godot.TileMap.MapToLocal(Vector2I)"/>.</para>
    /// </summary>
    public unsafe Vector2I LocalToMap(Vector2 localPosition)
    {
        return NativeCalls.godot_icall_1_1435(MethodBind59, GodotObject.GetPtr(this), &localPosition);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind60 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNeighborCell, 986575103ul);

    /// <summary>
    /// <para>Returns the neighboring cell to the one at coordinates <paramref name="coords"/>, identified by the <paramref name="neighbor"/> direction. This method takes into account the different layouts a TileMap can take.</para>
    /// </summary>
    public unsafe Vector2I GetNeighborCell(Vector2I coords, TileSet.CellNeighbor neighbor)
    {
        return NativeCalls.godot_icall_2_1436(MethodBind60, GodotObject.GetPtr(this), &coords, (int)neighbor);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind61 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetQuadrantSize, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetQuadrantSize()
    {
        return NativeCalls.godot_icall_0_39(MethodBind61, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind62 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetQuadrantSize, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetQuadrantSize(int quadrantSize)
    {
        NativeCalls.godot_icall_1_38(MethodBind62, GodotObject.GetPtr(this), quadrantSize);
    }

    /// <summary>
    /// <para>Emitted when the <see cref="Godot.TileSet"/> of this TileMap changes.</para>
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
        if ((method == MethodProxyName__tile_data_runtime_update || method == MethodName._TileDataRuntimeUpdate) && args.Count == 3 && HasGodotClassMethod((godot_string_name)MethodProxyName__tile_data_runtime_update.NativeValue))
        {
            _TileDataRuntimeUpdate(VariantUtils.ConvertTo<int>(args[0]), VariantUtils.ConvertTo<Vector2I>(args[1]), VariantUtils.ConvertTo<TileData>(args[2]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__use_tile_data_runtime_update || method == MethodName._UseTileDataRuntimeUpdate) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__use_tile_data_runtime_update.NativeValue))
        {
            var callRet = _UseTileDataRuntimeUpdate(VariantUtils.ConvertTo<int>(args[0]), VariantUtils.ConvertTo<Vector2I>(args[1]));
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
        /// Cached name for the 'tile_set' property.
        /// </summary>
        public static readonly StringName TileSet = "tile_set";
        /// <summary>
        /// Cached name for the 'rendering_quadrant_size' property.
        /// </summary>
        public static readonly StringName RenderingQuadrantSize = "rendering_quadrant_size";
        /// <summary>
        /// Cached name for the 'collision_animatable' property.
        /// </summary>
        public static readonly StringName CollisionAnimatable = "collision_animatable";
        /// <summary>
        /// Cached name for the 'collision_visibility_mode' property.
        /// </summary>
        public static readonly StringName CollisionVisibilityMode = "collision_visibility_mode";
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
        /// Cached name for the '_use_tile_data_runtime_update' method.
        /// </summary>
        public static readonly StringName _UseTileDataRuntimeUpdate = "_use_tile_data_runtime_update";
        /// <summary>
        /// Cached name for the 'set_navigation_map' method.
        /// </summary>
        public static readonly StringName SetNavigationMap = "set_navigation_map";
        /// <summary>
        /// Cached name for the 'get_navigation_map' method.
        /// </summary>
        public static readonly StringName GetNavigationMap = "get_navigation_map";
        /// <summary>
        /// Cached name for the 'force_update' method.
        /// </summary>
        public static readonly StringName ForceUpdate = "force_update";
        /// <summary>
        /// Cached name for the 'set_tileset' method.
        /// </summary>
        public static readonly StringName SetTileset = "set_tileset";
        /// <summary>
        /// Cached name for the 'get_tileset' method.
        /// </summary>
        public static readonly StringName GetTileset = "get_tileset";
        /// <summary>
        /// Cached name for the 'set_rendering_quadrant_size' method.
        /// </summary>
        public static readonly StringName SetRenderingQuadrantSize = "set_rendering_quadrant_size";
        /// <summary>
        /// Cached name for the 'get_rendering_quadrant_size' method.
        /// </summary>
        public static readonly StringName GetRenderingQuadrantSize = "get_rendering_quadrant_size";
        /// <summary>
        /// Cached name for the 'get_layers_count' method.
        /// </summary>
        public static readonly StringName GetLayersCount = "get_layers_count";
        /// <summary>
        /// Cached name for the 'add_layer' method.
        /// </summary>
        public static readonly StringName AddLayer = "add_layer";
        /// <summary>
        /// Cached name for the 'move_layer' method.
        /// </summary>
        public static readonly StringName MoveLayer = "move_layer";
        /// <summary>
        /// Cached name for the 'remove_layer' method.
        /// </summary>
        public static readonly StringName RemoveLayer = "remove_layer";
        /// <summary>
        /// Cached name for the 'set_layer_name' method.
        /// </summary>
        public static readonly StringName SetLayerName = "set_layer_name";
        /// <summary>
        /// Cached name for the 'get_layer_name' method.
        /// </summary>
        public static readonly StringName GetLayerName = "get_layer_name";
        /// <summary>
        /// Cached name for the 'set_layer_enabled' method.
        /// </summary>
        public static readonly StringName SetLayerEnabled = "set_layer_enabled";
        /// <summary>
        /// Cached name for the 'is_layer_enabled' method.
        /// </summary>
        public static readonly StringName IsLayerEnabled = "is_layer_enabled";
        /// <summary>
        /// Cached name for the 'set_layer_modulate' method.
        /// </summary>
        public static readonly StringName SetLayerModulate = "set_layer_modulate";
        /// <summary>
        /// Cached name for the 'get_layer_modulate' method.
        /// </summary>
        public static readonly StringName GetLayerModulate = "get_layer_modulate";
        /// <summary>
        /// Cached name for the 'set_layer_y_sort_enabled' method.
        /// </summary>
        public static readonly StringName SetLayerYSortEnabled = "set_layer_y_sort_enabled";
        /// <summary>
        /// Cached name for the 'is_layer_y_sort_enabled' method.
        /// </summary>
        public static readonly StringName IsLayerYSortEnabled = "is_layer_y_sort_enabled";
        /// <summary>
        /// Cached name for the 'set_layer_y_sort_origin' method.
        /// </summary>
        public static readonly StringName SetLayerYSortOrigin = "set_layer_y_sort_origin";
        /// <summary>
        /// Cached name for the 'get_layer_y_sort_origin' method.
        /// </summary>
        public static readonly StringName GetLayerYSortOrigin = "get_layer_y_sort_origin";
        /// <summary>
        /// Cached name for the 'set_layer_z_index' method.
        /// </summary>
        public static readonly StringName SetLayerZIndex = "set_layer_z_index";
        /// <summary>
        /// Cached name for the 'get_layer_z_index' method.
        /// </summary>
        public static readonly StringName GetLayerZIndex = "get_layer_z_index";
        /// <summary>
        /// Cached name for the 'set_layer_navigation_enabled' method.
        /// </summary>
        public static readonly StringName SetLayerNavigationEnabled = "set_layer_navigation_enabled";
        /// <summary>
        /// Cached name for the 'is_layer_navigation_enabled' method.
        /// </summary>
        public static readonly StringName IsLayerNavigationEnabled = "is_layer_navigation_enabled";
        /// <summary>
        /// Cached name for the 'set_layer_navigation_map' method.
        /// </summary>
        public static readonly StringName SetLayerNavigationMap = "set_layer_navigation_map";
        /// <summary>
        /// Cached name for the 'get_layer_navigation_map' method.
        /// </summary>
        public static readonly StringName GetLayerNavigationMap = "get_layer_navigation_map";
        /// <summary>
        /// Cached name for the 'set_collision_animatable' method.
        /// </summary>
        public static readonly StringName SetCollisionAnimatable = "set_collision_animatable";
        /// <summary>
        /// Cached name for the 'is_collision_animatable' method.
        /// </summary>
        public static readonly StringName IsCollisionAnimatable = "is_collision_animatable";
        /// <summary>
        /// Cached name for the 'set_collision_visibility_mode' method.
        /// </summary>
        public static readonly StringName SetCollisionVisibilityMode = "set_collision_visibility_mode";
        /// <summary>
        /// Cached name for the 'get_collision_visibility_mode' method.
        /// </summary>
        public static readonly StringName GetCollisionVisibilityMode = "get_collision_visibility_mode";
        /// <summary>
        /// Cached name for the 'set_navigation_visibility_mode' method.
        /// </summary>
        public static readonly StringName SetNavigationVisibilityMode = "set_navigation_visibility_mode";
        /// <summary>
        /// Cached name for the 'get_navigation_visibility_mode' method.
        /// </summary>
        public static readonly StringName GetNavigationVisibilityMode = "get_navigation_visibility_mode";
        /// <summary>
        /// Cached name for the 'set_cell' method.
        /// </summary>
        public static readonly StringName SetCell = "set_cell";
        /// <summary>
        /// Cached name for the 'erase_cell' method.
        /// </summary>
        public static readonly StringName EraseCell = "erase_cell";
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
        /// Cached name for the 'get_coords_for_body_rid' method.
        /// </summary>
        public static readonly StringName GetCoordsForBodyRid = "get_coords_for_body_rid";
        /// <summary>
        /// Cached name for the 'get_layer_for_body_rid' method.
        /// </summary>
        public static readonly StringName GetLayerForBodyRid = "get_layer_for_body_rid";
        /// <summary>
        /// Cached name for the 'get_pattern' method.
        /// </summary>
        public static readonly StringName GetPattern = "get_pattern";
        /// <summary>
        /// Cached name for the 'map_pattern' method.
        /// </summary>
        public static readonly StringName MapPattern = "map_pattern";
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
        /// Cached name for the 'fix_invalid_tiles' method.
        /// </summary>
        public static readonly StringName FixInvalidTiles = "fix_invalid_tiles";
        /// <summary>
        /// Cached name for the 'clear_layer' method.
        /// </summary>
        public static readonly StringName ClearLayer = "clear_layer";
        /// <summary>
        /// Cached name for the 'clear' method.
        /// </summary>
        public static readonly StringName Clear = "clear";
        /// <summary>
        /// Cached name for the 'update_internals' method.
        /// </summary>
        public static readonly StringName UpdateInternals = "update_internals";
        /// <summary>
        /// Cached name for the 'notify_runtime_tile_data_update' method.
        /// </summary>
        public static readonly StringName NotifyRuntimeTileDataUpdate = "notify_runtime_tile_data_update";
        /// <summary>
        /// Cached name for the 'get_surrounding_cells' method.
        /// </summary>
        public static readonly StringName GetSurroundingCells = "get_surrounding_cells";
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
        /// Cached name for the 'map_to_local' method.
        /// </summary>
        public static readonly StringName MapToLocal = "map_to_local";
        /// <summary>
        /// Cached name for the 'local_to_map' method.
        /// </summary>
        public static readonly StringName LocalToMap = "local_to_map";
        /// <summary>
        /// Cached name for the 'get_neighbor_cell' method.
        /// </summary>
        public static readonly StringName GetNeighborCell = "get_neighbor_cell";
        /// <summary>
        /// Cached name for the 'get_quadrant_size' method.
        /// </summary>
        public static readonly StringName GetQuadrantSize = "get_quadrant_size";
        /// <summary>
        /// Cached name for the 'set_quadrant_size' method.
        /// </summary>
        public static readonly StringName SetQuadrantSize = "set_quadrant_size";
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
