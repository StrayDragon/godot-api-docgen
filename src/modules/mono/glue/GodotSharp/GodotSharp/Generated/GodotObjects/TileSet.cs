namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A TileSet is a library of tiles for a <see cref="Godot.TileMapLayer"/>. A TileSet handles a list of <see cref="Godot.TileSetSource"/>, each of them storing a set of tiles.</para>
/// <para>Tiles can either be from a <see cref="Godot.TileSetAtlasSource"/>, which renders tiles out of a texture with support for physics, navigation, etc., or from a <see cref="Godot.TileSetScenesCollectionSource"/>, which exposes scene-based tiles.</para>
/// <para>Tiles are referenced by using three IDs: their source ID, their atlas coordinates ID, and their alternative tile ID.</para>
/// <para>A TileSet can be configured so that its tiles expose more or fewer properties. To do so, the TileSet resources use property layers, which you can add or remove depending on your needs.</para>
/// <para>For example, adding a physics layer allows giving collision shapes to your tiles. Each layer has dedicated properties (physics layer and mask), so you may add several TileSet physics layers for each type of collision you need.</para>
/// <para>See the functions to add new layers for more information.</para>
/// </summary>
public partial class TileSet : Resource
{
    public enum TileShapeEnum : long
    {
        /// <summary>
        /// <para>Rectangular tile shape.</para>
        /// </summary>
        Square = 0,
        /// <summary>
        /// <para>Diamond tile shape (for isometric look).</para>
        /// <para><b>Note:</b> Isometric <see cref="Godot.TileSet"/> works best if all sibling <see cref="Godot.TileMapLayer"/>s and their parent inheriting from <see cref="Godot.Node2D"/> have Y-sort enabled.</para>
        /// </summary>
        Isometric = 1,
        /// <summary>
        /// <para>Rectangular tile shape with one row/column out of two offset by half a tile.</para>
        /// </summary>
        HalfOffsetSquare = 2,
        /// <summary>
        /// <para>Hexagonal tile shape.</para>
        /// </summary>
        Hexagon = 3
    }

    public enum TileLayoutEnum : long
    {
        /// <summary>
        /// <para>Tile coordinates layout where both axis stay consistent with their respective local horizontal and vertical axis.</para>
        /// </summary>
        Stacked = 0,
        /// <summary>
        /// <para>Same as <see cref="Godot.TileSet.TileLayoutEnum.Stacked"/>, but the first half-offset is negative instead of positive.</para>
        /// </summary>
        StackedOffset = 1,
        /// <summary>
        /// <para>Tile coordinates layout where the horizontal axis stay horizontal, and the vertical one goes down-right.</para>
        /// </summary>
        StairsRight = 2,
        /// <summary>
        /// <para>Tile coordinates layout where the vertical axis stay vertical, and the horizontal one goes down-right.</para>
        /// </summary>
        StairsDown = 3,
        /// <summary>
        /// <para>Tile coordinates layout where the horizontal axis goes up-right, and the vertical one goes down-right.</para>
        /// </summary>
        DiamondRight = 4,
        /// <summary>
        /// <para>Tile coordinates layout where the horizontal axis goes down-right, and the vertical one goes down-left.</para>
        /// </summary>
        DiamondDown = 5
    }

    public enum TileOffsetAxisEnum : long
    {
        /// <summary>
        /// <para>Horizontal half-offset.</para>
        /// </summary>
        Horizontal = 0,
        /// <summary>
        /// <para>Vertical half-offset.</para>
        /// </summary>
        Vertical = 1
    }

    public enum CellNeighbor : long
    {
        /// <summary>
        /// <para>Neighbor on the right side.</para>
        /// </summary>
        RightSide = 0,
        /// <summary>
        /// <para>Neighbor in the right corner.</para>
        /// </summary>
        RightCorner = 1,
        /// <summary>
        /// <para>Neighbor on the bottom right side.</para>
        /// </summary>
        BottomRightSide = 2,
        /// <summary>
        /// <para>Neighbor in the bottom right corner.</para>
        /// </summary>
        BottomRightCorner = 3,
        /// <summary>
        /// <para>Neighbor on the bottom side.</para>
        /// </summary>
        BottomSide = 4,
        /// <summary>
        /// <para>Neighbor in the bottom corner.</para>
        /// </summary>
        BottomCorner = 5,
        /// <summary>
        /// <para>Neighbor on the bottom left side.</para>
        /// </summary>
        BottomLeftSide = 6,
        /// <summary>
        /// <para>Neighbor in the bottom left corner.</para>
        /// </summary>
        BottomLeftCorner = 7,
        /// <summary>
        /// <para>Neighbor on the left side.</para>
        /// </summary>
        LeftSide = 8,
        /// <summary>
        /// <para>Neighbor in the left corner.</para>
        /// </summary>
        LeftCorner = 9,
        /// <summary>
        /// <para>Neighbor on the top left side.</para>
        /// </summary>
        TopLeftSide = 10,
        /// <summary>
        /// <para>Neighbor in the top left corner.</para>
        /// </summary>
        TopLeftCorner = 11,
        /// <summary>
        /// <para>Neighbor on the top side.</para>
        /// </summary>
        TopSide = 12,
        /// <summary>
        /// <para>Neighbor in the top corner.</para>
        /// </summary>
        TopCorner = 13,
        /// <summary>
        /// <para>Neighbor on the top right side.</para>
        /// </summary>
        TopRightSide = 14,
        /// <summary>
        /// <para>Neighbor in the top right corner.</para>
        /// </summary>
        TopRightCorner = 15
    }

    public enum TerrainMode : long
    {
        /// <summary>
        /// <para>Requires both corners and side to match with neighboring tiles' terrains.</para>
        /// </summary>
        CornersAndSides = 0,
        /// <summary>
        /// <para>Requires corners to match with neighboring tiles' terrains.</para>
        /// </summary>
        Corners = 1,
        /// <summary>
        /// <para>Requires sides to match with neighboring tiles' terrains.</para>
        /// </summary>
        Sides = 2
    }

    /// <summary>
    /// <para>The tile shape.</para>
    /// </summary>
    public TileSet.TileShapeEnum TileShape
    {
        get
        {
            return GetTileShape();
        }
        set
        {
            SetTileShape(value);
        }
    }

    /// <summary>
    /// <para>For all half-offset shapes (Isometric, Hexagonal and Half-Offset square), changes the way tiles are indexed in the <see cref="Godot.TileMapLayer"/> grid.</para>
    /// </summary>
    public TileSet.TileLayoutEnum TileLayout
    {
        get
        {
            return GetTileLayout();
        }
        set
        {
            SetTileLayout(value);
        }
    }

    /// <summary>
    /// <para>For all half-offset shapes (Isometric, Hexagonal and Half-Offset square), determines the offset axis.</para>
    /// </summary>
    public TileSet.TileOffsetAxisEnum TileOffsetAxis
    {
        get
        {
            return GetTileOffsetAxis();
        }
        set
        {
            SetTileOffsetAxis(value);
        }
    }

    /// <summary>
    /// <para>The tile size, in pixels. For all tile shapes, this size corresponds to the encompassing rectangle of the tile shape. This is thus the minimal cell size required in an atlas.</para>
    /// </summary>
    public Vector2I TileSize
    {
        get
        {
            return GetTileSize();
        }
        set
        {
            SetTileSize(value);
        }
    }

    /// <summary>
    /// <para>Enables/Disable uv clipping when rendering the tiles.</para>
    /// </summary>
    public bool UVClipping
    {
        get
        {
            return IsUVClipping();
        }
        set
        {
            SetUVClipping(value);
        }
    }

    private static readonly System.Type CachedType = typeof(TileSet);

    private static readonly StringName NativeName = "TileSet";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public TileSet() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal TileSet(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal TileSet(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNextSourceId, 3905245786ul);

    /// <summary>
    /// <para>Returns a new unused source ID. This generated ID is the same that a call to <see cref="Godot.TileSet.AddSource(TileSetSource, int)"/> would return.</para>
    /// </summary>
    public int GetNextSourceId()
    {
        return NativeCalls.godot_icall_0_39(MethodBind0, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddSource, 1059186179ul);

    /// <summary>
    /// <para>Adds a <see cref="Godot.TileSetSource"/> to the TileSet. If <paramref name="atlasSourceIdOverride"/> is not -1, also set its source ID. Otherwise, a unique identifier is automatically generated.</para>
    /// <para>The function returns the added source ID or -1 if the source could not be added.</para>
    /// <para><b>Warning:</b> A source cannot belong to two TileSets at the same time. If the added source was attached to another <see cref="Godot.TileSet"/>, it will be removed from that one.</para>
    /// </summary>
    public int AddSource(TileSetSource source, int atlasSourceIdOverride = -1)
    {
        return NativeCalls.godot_icall_2_792(MethodBind1, GodotObject.GetPtr(this), GodotObject.GetPtr(source), atlasSourceIdOverride);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveSource, 1286410249ul);

    /// <summary>
    /// <para>Removes the source with the given source ID.</para>
    /// </summary>
    public void RemoveSource(int sourceId)
    {
        NativeCalls.godot_icall_1_38(MethodBind2, GodotObject.GetPtr(this), sourceId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSourceId, 3937882851ul);

    /// <summary>
    /// <para>Changes a source's ID.</para>
    /// </summary>
    public void SetSourceId(int sourceId, int newSourceId)
    {
        NativeCalls.godot_icall_2_59(MethodBind3, GodotObject.GetPtr(this), sourceId, newSourceId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSourceCount, 3905245786ul);

    /// <summary>
    /// <para>Returns the number of <see cref="Godot.TileSetSource"/> in this TileSet.</para>
    /// </summary>
    public int GetSourceCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind4, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSourceId, 923996154ul);

    /// <summary>
    /// <para>Returns the source ID for source with index <paramref name="index"/>.</para>
    /// </summary>
    public int GetSourceId(int index)
    {
        return NativeCalls.godot_icall_1_60(MethodBind5, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasSource, 1116898809ul);

    /// <summary>
    /// <para>Returns if this TileSet has a source for the given source ID.</para>
    /// </summary>
    public bool HasSource(int sourceId)
    {
        return NativeCalls.godot_icall_1_62(MethodBind6, GodotObject.GetPtr(this), sourceId).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSource, 1763540252ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.TileSetSource"/> with ID <paramref name="sourceId"/>.</para>
    /// </summary>
    public TileSetSource GetSource(int sourceId)
    {
        return (TileSetSource)NativeCalls.godot_icall_1_71(MethodBind7, GodotObject.GetPtr(this), sourceId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTileShape, 2131427112ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTileShape(TileSet.TileShapeEnum shape)
    {
        NativeCalls.godot_icall_1_38(MethodBind8, GodotObject.GetPtr(this), (int)shape);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTileShape, 716918169ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public TileSet.TileShapeEnum GetTileShape()
    {
        return (TileSet.TileShapeEnum)NativeCalls.godot_icall_0_39(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTileLayout, 1071216679ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTileLayout(TileSet.TileLayoutEnum layout)
    {
        NativeCalls.godot_icall_1_38(MethodBind10, GodotObject.GetPtr(this), (int)layout);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTileLayout, 194628839ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public TileSet.TileLayoutEnum GetTileLayout()
    {
        return (TileSet.TileLayoutEnum)NativeCalls.godot_icall_0_39(MethodBind11, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTileOffsetAxis, 3300198521ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTileOffsetAxis(TileSet.TileOffsetAxisEnum alignment)
    {
        NativeCalls.godot_icall_1_38(MethodBind12, GodotObject.GetPtr(this), (int)alignment);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTileOffsetAxis, 762494114ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public TileSet.TileOffsetAxisEnum GetTileOffsetAxis()
    {
        return (TileSet.TileOffsetAxisEnum)NativeCalls.godot_icall_0_39(MethodBind13, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTileSize, 1130785943ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetTileSize(Vector2I size)
    {
        NativeCalls.godot_icall_1_34(MethodBind14, GodotObject.GetPtr(this), &size);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTileSize, 3690982128ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2I GetTileSize()
    {
        return NativeCalls.godot_icall_0_35(MethodBind15, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetUVClipping, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetUVClipping(bool uVClipping)
    {
        NativeCalls.godot_icall_1_14(MethodBind16, GodotObject.GetPtr(this), uVClipping.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsUVClipping, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsUVClipping()
    {
        return NativeCalls.godot_icall_0_15(MethodBind17, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOcclusionLayersCount, 3905245786ul);

    /// <summary>
    /// <para>Returns the occlusion layers count.</para>
    /// </summary>
    public int GetOcclusionLayersCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind18, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddOcclusionLayer, 1025054187ul);

    /// <summary>
    /// <para>Adds an occlusion layer to the TileSet at the given position <paramref name="toPosition"/> in the array. If <paramref name="toPosition"/> is -1, adds it at the end of the array.</para>
    /// <para>Occlusion layers allow assigning occlusion polygons to atlas tiles.</para>
    /// </summary>
    public void AddOcclusionLayer(int toPosition = -1)
    {
        NativeCalls.godot_icall_1_38(MethodBind19, GodotObject.GetPtr(this), toPosition);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MoveOcclusionLayer, 3937882851ul);

    /// <summary>
    /// <para>Moves the occlusion layer at index <paramref name="layerIndex"/> to the given position <paramref name="toPosition"/> in the array. Also updates the atlas tiles accordingly.</para>
    /// </summary>
    public void MoveOcclusionLayer(int layerIndex, int toPosition)
    {
        NativeCalls.godot_icall_2_59(MethodBind20, GodotObject.GetPtr(this), layerIndex, toPosition);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveOcclusionLayer, 1286410249ul);

    /// <summary>
    /// <para>Removes the occlusion layer at index <paramref name="layerIndex"/>. Also updates the atlas tiles accordingly.</para>
    /// </summary>
    public void RemoveOcclusionLayer(int layerIndex)
    {
        NativeCalls.godot_icall_1_38(MethodBind21, GodotObject.GetPtr(this), layerIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetOcclusionLayerLightMask, 3937882851ul);

    /// <summary>
    /// <para>Sets the occlusion layer (as in the rendering server) for occluders in the given TileSet occlusion layer.</para>
    /// </summary>
    public void SetOcclusionLayerLightMask(int layerIndex, int lightMask)
    {
        NativeCalls.godot_icall_2_59(MethodBind22, GodotObject.GetPtr(this), layerIndex, lightMask);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOcclusionLayerLightMask, 923996154ul);

    /// <summary>
    /// <para>Returns the light mask of the occlusion layer.</para>
    /// </summary>
    public int GetOcclusionLayerLightMask(int layerIndex)
    {
        return NativeCalls.godot_icall_1_60(MethodBind23, GodotObject.GetPtr(this), layerIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetOcclusionLayerSdfCollision, 300928843ul);

    /// <summary>
    /// <para>Enables or disables SDF collision for occluders in the given TileSet occlusion layer.</para>
    /// </summary>
    public void SetOcclusionLayerSdfCollision(int layerIndex, bool sdfCollision)
    {
        NativeCalls.godot_icall_2_61(MethodBind24, GodotObject.GetPtr(this), layerIndex, sdfCollision.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOcclusionLayerSdfCollision, 1116898809ul);

    /// <summary>
    /// <para>Returns if the occluders from this layer use <c>sdf_collision</c>.</para>
    /// </summary>
    public bool GetOcclusionLayerSdfCollision(int layerIndex)
    {
        return NativeCalls.godot_icall_1_62(MethodBind25, GodotObject.GetPtr(this), layerIndex).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPhysicsLayersCount, 3905245786ul);

    /// <summary>
    /// <para>Returns the physics layers count.</para>
    /// </summary>
    public int GetPhysicsLayersCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind26, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddPhysicsLayer, 1025054187ul);

    /// <summary>
    /// <para>Adds a physics layer to the TileSet at the given position <paramref name="toPosition"/> in the array. If <paramref name="toPosition"/> is -1, adds it at the end of the array.</para>
    /// <para>Physics layers allow assigning collision polygons to atlas tiles.</para>
    /// </summary>
    public void AddPhysicsLayer(int toPosition = -1)
    {
        NativeCalls.godot_icall_1_38(MethodBind27, GodotObject.GetPtr(this), toPosition);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MovePhysicsLayer, 3937882851ul);

    /// <summary>
    /// <para>Moves the physics layer at index <paramref name="layerIndex"/> to the given position <paramref name="toPosition"/> in the array. Also updates the atlas tiles accordingly.</para>
    /// </summary>
    public void MovePhysicsLayer(int layerIndex, int toPosition)
    {
        NativeCalls.godot_icall_2_59(MethodBind28, GodotObject.GetPtr(this), layerIndex, toPosition);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemovePhysicsLayer, 1286410249ul);

    /// <summary>
    /// <para>Removes the physics layer at index <paramref name="layerIndex"/>. Also updates the atlas tiles accordingly.</para>
    /// </summary>
    public void RemovePhysicsLayer(int layerIndex)
    {
        NativeCalls.godot_icall_1_38(MethodBind29, GodotObject.GetPtr(this), layerIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPhysicsLayerCollisionLayer, 3937882851ul);

    /// <summary>
    /// <para>Sets the collision layer (as in the physics server) for bodies in the given TileSet physics layer.</para>
    /// </summary>
    public void SetPhysicsLayerCollisionLayer(int layerIndex, uint layer)
    {
        NativeCalls.godot_icall_2_801(MethodBind30, GodotObject.GetPtr(this), layerIndex, layer);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPhysicsLayerCollisionLayer, 923996154ul);

    /// <summary>
    /// <para>Returns the collision layer (as in the physics server) bodies on the given TileSet's physics layer are in.</para>
    /// </summary>
    public uint GetPhysicsLayerCollisionLayer(int layerIndex)
    {
        return NativeCalls.godot_icall_1_322(MethodBind31, GodotObject.GetPtr(this), layerIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind32 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPhysicsLayerCollisionMask, 3937882851ul);

    /// <summary>
    /// <para>Sets the collision mask for bodies in the given TileSet physics layer.</para>
    /// </summary>
    public void SetPhysicsLayerCollisionMask(int layerIndex, uint mask)
    {
        NativeCalls.godot_icall_2_801(MethodBind32, GodotObject.GetPtr(this), layerIndex, mask);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind33 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPhysicsLayerCollisionMask, 923996154ul);

    /// <summary>
    /// <para>Returns the collision mask of bodies on the given TileSet's physics layer.</para>
    /// </summary>
    public uint GetPhysicsLayerCollisionMask(int layerIndex)
    {
        return NativeCalls.godot_icall_1_322(MethodBind33, GodotObject.GetPtr(this), layerIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind34 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPhysicsLayerCollisionPriority, 1602489585ul);

    /// <summary>
    /// <para>Sets the collision priority for bodies in the given TileSet physics layer.</para>
    /// </summary>
    public void SetPhysicsLayerCollisionPriority(int layerIndex, float priority)
    {
        NativeCalls.godot_icall_2_69(MethodBind34, GodotObject.GetPtr(this), layerIndex, priority);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind35 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPhysicsLayerCollisionPriority, 2339986948ul);

    /// <summary>
    /// <para>Returns the collision priority of bodies on the given TileSet's physics layer.</para>
    /// </summary>
    public float GetPhysicsLayerCollisionPriority(int layerIndex)
    {
        return NativeCalls.godot_icall_1_72(MethodBind35, GodotObject.GetPtr(this), layerIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind36 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPhysicsLayerPhysicsMaterial, 1018687357ul);

    /// <summary>
    /// <para>Sets the physics material for bodies in the given TileSet physics layer.</para>
    /// </summary>
    public void SetPhysicsLayerPhysicsMaterial(int layerIndex, PhysicsMaterial physicsMaterial)
    {
        NativeCalls.godot_icall_2_70(MethodBind36, GodotObject.GetPtr(this), layerIndex, GodotObject.GetPtr(physicsMaterial));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind37 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPhysicsLayerPhysicsMaterial, 788318639ul);

    /// <summary>
    /// <para>Returns the physics material of bodies on the given TileSet's physics layer.</para>
    /// </summary>
    public PhysicsMaterial GetPhysicsLayerPhysicsMaterial(int layerIndex)
    {
        return (PhysicsMaterial)NativeCalls.godot_icall_1_71(MethodBind37, GodotObject.GetPtr(this), layerIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind38 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTerrainSetsCount, 3905245786ul);

    /// <summary>
    /// <para>Returns the terrain sets count.</para>
    /// </summary>
    public int GetTerrainSetsCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind38, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind39 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddTerrainSet, 1025054187ul);

    /// <summary>
    /// <para>Adds a new terrain set at the given position <paramref name="toPosition"/> in the array. If <paramref name="toPosition"/> is -1, adds it at the end of the array.</para>
    /// </summary>
    public void AddTerrainSet(int toPosition = -1)
    {
        NativeCalls.godot_icall_1_38(MethodBind39, GodotObject.GetPtr(this), toPosition);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind40 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MoveTerrainSet, 3937882851ul);

    /// <summary>
    /// <para>Moves the terrain set at index <paramref name="terrainSet"/> to the given position <paramref name="toPosition"/> in the array. Also updates the atlas tiles accordingly.</para>
    /// </summary>
    public void MoveTerrainSet(int terrainSet, int toPosition)
    {
        NativeCalls.godot_icall_2_59(MethodBind40, GodotObject.GetPtr(this), terrainSet, toPosition);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind41 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveTerrainSet, 1286410249ul);

    /// <summary>
    /// <para>Removes the terrain set at index <paramref name="terrainSet"/>. Also updates the atlas tiles accordingly.</para>
    /// </summary>
    public void RemoveTerrainSet(int terrainSet)
    {
        NativeCalls.godot_icall_1_38(MethodBind41, GodotObject.GetPtr(this), terrainSet);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind42 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTerrainSetMode, 3943003916ul);

    /// <summary>
    /// <para>Sets a terrain mode. Each mode determines which bits of a tile shape is used to match the neighboring tiles' terrains.</para>
    /// </summary>
    public void SetTerrainSetMode(int terrainSet, TileSet.TerrainMode mode)
    {
        NativeCalls.godot_icall_2_59(MethodBind42, GodotObject.GetPtr(this), terrainSet, (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind43 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTerrainSetMode, 2084469411ul);

    /// <summary>
    /// <para>Returns a terrain set mode.</para>
    /// </summary>
    public TileSet.TerrainMode GetTerrainSetMode(int terrainSet)
    {
        return (TileSet.TerrainMode)NativeCalls.godot_icall_1_60(MethodBind43, GodotObject.GetPtr(this), terrainSet);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind44 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTerrainsCount, 923996154ul);

    /// <summary>
    /// <para>Returns the number of terrains in the given terrain set.</para>
    /// </summary>
    public int GetTerrainsCount(int terrainSet)
    {
        return NativeCalls.godot_icall_1_60(MethodBind44, GodotObject.GetPtr(this), terrainSet);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind45 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddTerrain, 1230568737ul);

    /// <summary>
    /// <para>Adds a new terrain to the given terrain set <paramref name="terrainSet"/> at the given position <paramref name="toPosition"/> in the array. If <paramref name="toPosition"/> is -1, adds it at the end of the array.</para>
    /// </summary>
    public void AddTerrain(int terrainSet, int toPosition = -1)
    {
        NativeCalls.godot_icall_2_59(MethodBind45, GodotObject.GetPtr(this), terrainSet, toPosition);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind46 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MoveTerrain, 1649997291ul);

    /// <summary>
    /// <para>Moves the terrain at index <paramref name="terrainIndex"/> for terrain set <paramref name="terrainSet"/> to the given position <paramref name="toPosition"/> in the array. Also updates the atlas tiles accordingly.</para>
    /// </summary>
    public void MoveTerrain(int terrainSet, int terrainIndex, int toPosition)
    {
        NativeCalls.godot_icall_3_196(MethodBind46, GodotObject.GetPtr(this), terrainSet, terrainIndex, toPosition);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind47 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveTerrain, 3937882851ul);

    /// <summary>
    /// <para>Removes the terrain at index <paramref name="terrainIndex"/> in the given terrain set <paramref name="terrainSet"/>. Also updates the atlas tiles accordingly.</para>
    /// </summary>
    public void RemoveTerrain(int terrainSet, int terrainIndex)
    {
        NativeCalls.godot_icall_2_59(MethodBind47, GodotObject.GetPtr(this), terrainSet, terrainIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind48 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTerrainName, 2285447957ul);

    /// <summary>
    /// <para>Sets a terrain's name.</para>
    /// </summary>
    public void SetTerrainName(int terrainSet, int terrainIndex, string name)
    {
        NativeCalls.godot_icall_3_1313(MethodBind48, GodotObject.GetPtr(this), terrainSet, terrainIndex, name);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind49 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTerrainName, 1391810591ul);

    /// <summary>
    /// <para>Returns a terrain's name.</para>
    /// </summary>
    public string GetTerrainName(int terrainSet, int terrainIndex)
    {
        return NativeCalls.godot_icall_2_222(MethodBind49, GodotObject.GetPtr(this), terrainSet, terrainIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind50 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTerrainColor, 3733378741ul);

    /// <summary>
    /// <para>Sets a terrain's color. This color is used for identifying the different terrains in the TileSet editor.</para>
    /// </summary>
    public unsafe void SetTerrainColor(int terrainSet, int terrainIndex, Color color)
    {
        NativeCalls.godot_icall_3_736(MethodBind50, GodotObject.GetPtr(this), terrainSet, terrainIndex, &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind51 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTerrainColor, 2165839948ul);

    /// <summary>
    /// <para>Returns a terrain's color.</para>
    /// </summary>
    public Color GetTerrainColor(int terrainSet, int terrainIndex)
    {
        return NativeCalls.godot_icall_2_734(MethodBind51, GodotObject.GetPtr(this), terrainSet, terrainIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind52 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNavigationLayersCount, 3905245786ul);

    /// <summary>
    /// <para>Returns the navigation layers count.</para>
    /// </summary>
    public int GetNavigationLayersCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind52, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind53 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddNavigationLayer, 1025054187ul);

    /// <summary>
    /// <para>Adds a navigation layer to the TileSet at the given position <paramref name="toPosition"/> in the array. If <paramref name="toPosition"/> is -1, adds it at the end of the array.</para>
    /// <para>Navigation layers allow assigning a navigable area to atlas tiles.</para>
    /// </summary>
    public void AddNavigationLayer(int toPosition = -1)
    {
        NativeCalls.godot_icall_1_38(MethodBind53, GodotObject.GetPtr(this), toPosition);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind54 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MoveNavigationLayer, 3937882851ul);

    /// <summary>
    /// <para>Moves the navigation layer at index <paramref name="layerIndex"/> to the given position <paramref name="toPosition"/> in the array. Also updates the atlas tiles accordingly.</para>
    /// </summary>
    public void MoveNavigationLayer(int layerIndex, int toPosition)
    {
        NativeCalls.godot_icall_2_59(MethodBind54, GodotObject.GetPtr(this), layerIndex, toPosition);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind55 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveNavigationLayer, 1286410249ul);

    /// <summary>
    /// <para>Removes the navigation layer at index <paramref name="layerIndex"/>. Also updates the atlas tiles accordingly.</para>
    /// </summary>
    public void RemoveNavigationLayer(int layerIndex)
    {
        NativeCalls.godot_icall_1_38(MethodBind55, GodotObject.GetPtr(this), layerIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind56 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetNavigationLayerLayers, 3937882851ul);

    /// <summary>
    /// <para>Sets the navigation layers (as in the navigation server) for navigation regions in the given TileSet navigation layer.</para>
    /// </summary>
    public void SetNavigationLayerLayers(int layerIndex, uint layers)
    {
        NativeCalls.godot_icall_2_801(MethodBind56, GodotObject.GetPtr(this), layerIndex, layers);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind57 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNavigationLayerLayers, 923996154ul);

    /// <summary>
    /// <para>Returns the navigation layers (as in the Navigation server) of the given TileSet navigation layer.</para>
    /// </summary>
    public uint GetNavigationLayerLayers(int layerIndex)
    {
        return NativeCalls.godot_icall_1_322(MethodBind57, GodotObject.GetPtr(this), layerIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind58 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetNavigationLayerLayerValue, 1383440665ul);

    /// <summary>
    /// <para>Based on <paramref name="value"/>, enables or disables the specified navigation layer of the TileSet navigation data layer identified by the given <paramref name="layerIndex"/>, given a navigation_layers <paramref name="layerNumber"/> between 1 and 32.</para>
    /// </summary>
    public void SetNavigationLayerLayerValue(int layerIndex, int layerNumber, bool value)
    {
        NativeCalls.godot_icall_3_197(MethodBind58, GodotObject.GetPtr(this), layerIndex, layerNumber, value.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind59 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNavigationLayerLayerValue, 2522259332ul);

    /// <summary>
    /// <para>Returns whether or not the specified navigation layer of the TileSet navigation data layer identified by the given <paramref name="layerIndex"/> is enabled, given a navigation_layers <paramref name="layerNumber"/> between 1 and 32.</para>
    /// </summary>
    public bool GetNavigationLayerLayerValue(int layerIndex, int layerNumber)
    {
        return NativeCalls.godot_icall_2_40(MethodBind59, GodotObject.GetPtr(this), layerIndex, layerNumber).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind60 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCustomDataLayersCount, 3905245786ul);

    /// <summary>
    /// <para>Returns the custom data layers count.</para>
    /// </summary>
    public int GetCustomDataLayersCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind60, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind61 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddCustomDataLayer, 1025054187ul);

    /// <summary>
    /// <para>Adds a custom data layer to the TileSet at the given position <paramref name="toPosition"/> in the array. If <paramref name="toPosition"/> is -1, adds it at the end of the array.</para>
    /// <para>Custom data layers allow assigning custom properties to atlas tiles.</para>
    /// </summary>
    public void AddCustomDataLayer(int toPosition = -1)
    {
        NativeCalls.godot_icall_1_38(MethodBind61, GodotObject.GetPtr(this), toPosition);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind62 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MoveCustomDataLayer, 3937882851ul);

    /// <summary>
    /// <para>Moves the custom data layer at index <paramref name="layerIndex"/> to the given position <paramref name="toPosition"/> in the array. Also updates the atlas tiles accordingly.</para>
    /// </summary>
    public void MoveCustomDataLayer(int layerIndex, int toPosition)
    {
        NativeCalls.godot_icall_2_59(MethodBind62, GodotObject.GetPtr(this), layerIndex, toPosition);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind63 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveCustomDataLayer, 1286410249ul);

    /// <summary>
    /// <para>Removes the custom data layer at index <paramref name="layerIndex"/>. Also updates the atlas tiles accordingly.</para>
    /// </summary>
    public void RemoveCustomDataLayer(int layerIndex)
    {
        NativeCalls.godot_icall_1_38(MethodBind63, GodotObject.GetPtr(this), layerIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind64 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCustomDataLayerByName, 1321353865ul);

    /// <summary>
    /// <para>Returns the index of the custom data layer identified by the given name.</para>
    /// </summary>
    public int GetCustomDataLayerByName(string layerName)
    {
        return NativeCalls.godot_icall_1_134(MethodBind64, GodotObject.GetPtr(this), layerName);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind65 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCustomDataLayerName, 501894301ul);

    /// <summary>
    /// <para>Sets the name of the custom data layer identified by the given index. Names are identifiers of the layer therefore if the name is already taken it will fail and raise an error.</para>
    /// </summary>
    public void SetCustomDataLayerName(int layerIndex, string layerName)
    {
        NativeCalls.godot_icall_2_181(MethodBind65, GodotObject.GetPtr(this), layerIndex, layerName);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind66 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasCustomDataLayerByName, 3927539163ul);

    /// <summary>
    /// <para>Returns if there is a custom data layer named <paramref name="layerName"/>.</para>
    /// </summary>
    public bool HasCustomDataLayerByName(string layerName)
    {
        return NativeCalls.godot_icall_1_131(MethodBind66, GodotObject.GetPtr(this), layerName).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind67 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCustomDataLayerName, 844755477ul);

    /// <summary>
    /// <para>Returns the name of the custom data layer identified by the given index.</para>
    /// </summary>
    public string GetCustomDataLayerName(int layerIndex)
    {
        return NativeCalls.godot_icall_1_133(MethodBind67, GodotObject.GetPtr(this), layerIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind68 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCustomDataLayerType, 3492912874ul);

    /// <summary>
    /// <para>Sets the type of the custom data layer identified by the given index.</para>
    /// </summary>
    public void SetCustomDataLayerType(int layerIndex, Variant.Type layerType)
    {
        NativeCalls.godot_icall_2_59(MethodBind68, GodotObject.GetPtr(this), layerIndex, (int)layerType);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind69 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCustomDataLayerType, 2990820875ul);

    /// <summary>
    /// <para>Returns the type of the custom data layer identified by the given index.</para>
    /// </summary>
    public Variant.Type GetCustomDataLayerType(int layerIndex)
    {
        return (Variant.Type)NativeCalls.godot_icall_1_60(MethodBind69, GodotObject.GetPtr(this), layerIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind70 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSourceLevelTileProxy, 3937882851ul);

    /// <summary>
    /// <para>Creates a source-level proxy for the given source ID. A proxy will map set of tile identifiers to another set of identifiers. Both the atlas coordinates ID and the alternative tile ID are kept the same when using source-level proxies.</para>
    /// <para>Proxied tiles can be automatically replaced in TileMapLayer nodes using the editor.</para>
    /// </summary>
    public void SetSourceLevelTileProxy(int sourceFrom, int sourceTo)
    {
        NativeCalls.godot_icall_2_59(MethodBind70, GodotObject.GetPtr(this), sourceFrom, sourceTo);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind71 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSourceLevelTileProxy, 3744713108ul);

    /// <summary>
    /// <para>Returns the source-level proxy for the given source identifier.</para>
    /// <para>If the TileSet has no proxy for the given identifier, returns -1.</para>
    /// </summary>
    public int GetSourceLevelTileProxy(int sourceFrom)
    {
        return NativeCalls.godot_icall_1_60(MethodBind71, GodotObject.GetPtr(this), sourceFrom);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind72 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasSourceLevelTileProxy, 3067735520ul);

    /// <summary>
    /// <para>Returns if there is a source-level proxy for the given source ID.</para>
    /// </summary>
    public bool HasSourceLevelTileProxy(int sourceFrom)
    {
        return NativeCalls.godot_icall_1_62(MethodBind72, GodotObject.GetPtr(this), sourceFrom).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind73 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveSourceLevelTileProxy, 1286410249ul);

    /// <summary>
    /// <para>Removes a source-level tile proxy.</para>
    /// </summary>
    public void RemoveSourceLevelTileProxy(int sourceFrom)
    {
        NativeCalls.godot_icall_1_38(MethodBind73, GodotObject.GetPtr(this), sourceFrom);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind74 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCoordsLevelTileProxy, 1769939278ul);

    /// <summary>
    /// <para>Creates a coordinates-level proxy for the given identifiers. A proxy will map set of tile identifiers to another set of identifiers. The alternative tile ID is kept the same when using coordinates-level proxies.</para>
    /// <para>Proxied tiles can be automatically replaced in TileMapLayer nodes using the editor.</para>
    /// </summary>
    public unsafe void SetCoordsLevelTileProxy(int pSourceFrom, Vector2I coordsFrom, int sourceTo, Vector2I coordsTo)
    {
        NativeCalls.godot_icall_4_1444(MethodBind74, GodotObject.GetPtr(this), pSourceFrom, &coordsFrom, sourceTo, &coordsTo);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind75 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCoordsLevelTileProxy, 2856536371ul);

    /// <summary>
    /// <para>Returns the coordinate-level proxy for the given identifiers. The returned array contains the two target identifiers of the proxy (source ID and atlas coordinates ID).</para>
    /// <para>If the TileSet has no proxy for the given identifiers, returns an empty Array.</para>
    /// </summary>
    public unsafe Godot.Collections.Array GetCoordsLevelTileProxy(int sourceFrom, Vector2I coordsFrom)
    {
        return NativeCalls.godot_icall_2_1445(MethodBind75, GodotObject.GetPtr(this), sourceFrom, &coordsFrom);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind76 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasCoordsLevelTileProxy, 3957903770ul);

    /// <summary>
    /// <para>Returns if there is a coodinates-level proxy for the given identifiers.</para>
    /// </summary>
    public unsafe bool HasCoordsLevelTileProxy(int sourceFrom, Vector2I coordsFrom)
    {
        return NativeCalls.godot_icall_2_1446(MethodBind76, GodotObject.GetPtr(this), sourceFrom, &coordsFrom).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind77 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveCoordsLevelTileProxy, 2311374912ul);

    /// <summary>
    /// <para>Removes a coordinates-level proxy for the given identifiers.</para>
    /// </summary>
    public unsafe void RemoveCoordsLevelTileProxy(int sourceFrom, Vector2I coordsFrom)
    {
        NativeCalls.godot_icall_2_605(MethodBind77, GodotObject.GetPtr(this), sourceFrom, &coordsFrom);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind78 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAlternativeLevelTileProxy, 3862385460ul);

    /// <summary>
    /// <para>Create an alternative-level proxy for the given identifiers. A proxy will map set of tile identifiers to another set of identifiers.</para>
    /// <para>Proxied tiles can be automatically replaced in TileMapLayer nodes using the editor.</para>
    /// </summary>
    public unsafe void SetAlternativeLevelTileProxy(int sourceFrom, Vector2I coordsFrom, int alternativeFrom, int sourceTo, Vector2I coordsTo, int alternativeTo)
    {
        NativeCalls.godot_icall_6_1447(MethodBind78, GodotObject.GetPtr(this), sourceFrom, &coordsFrom, alternativeFrom, sourceTo, &coordsTo, alternativeTo);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind79 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAlternativeLevelTileProxy, 2303761075ul);

    /// <summary>
    /// <para>Returns the alternative-level proxy for the given identifiers. The returned array contains the three proxie's target identifiers (source ID, atlas coords ID and alternative tile ID).</para>
    /// <para>If the TileSet has no proxy for the given identifiers, returns an empty Array.</para>
    /// </summary>
    public unsafe Godot.Collections.Array GetAlternativeLevelTileProxy(int sourceFrom, Vector2I coordsFrom, int alternativeFrom)
    {
        return NativeCalls.godot_icall_3_1440(MethodBind79, GodotObject.GetPtr(this), sourceFrom, &coordsFrom, alternativeFrom);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind80 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasAlternativeLevelTileProxy, 180086755ul);

    /// <summary>
    /// <para>Returns if there is an alternative-level proxy for the given identifiers.</para>
    /// </summary>
    public unsafe bool HasAlternativeLevelTileProxy(int sourceFrom, Vector2I coordsFrom, int alternativeFrom)
    {
        return NativeCalls.godot_icall_3_1448(MethodBind80, GodotObject.GetPtr(this), sourceFrom, &coordsFrom, alternativeFrom).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind81 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveAlternativeLevelTileProxy, 2328951467ul);

    /// <summary>
    /// <para>Removes an alternative-level proxy for the given identifiers.</para>
    /// </summary>
    public unsafe void RemoveAlternativeLevelTileProxy(int sourceFrom, Vector2I coordsFrom, int alternativeFrom)
    {
        NativeCalls.godot_icall_3_613(MethodBind81, GodotObject.GetPtr(this), sourceFrom, &coordsFrom, alternativeFrom);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind82 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MapTileProxy, 4267935328ul);

    /// <summary>
    /// <para>According to the configured proxies, maps the provided identifiers to a new set of identifiers. The source ID, atlas coordinates ID and alternative tile ID are returned as a 3 elements Array.</para>
    /// <para>This function first look for matching alternative-level proxies, then coordinates-level proxies, then source-level proxies.</para>
    /// <para>If no proxy corresponding to provided identifiers are found, returns the same values the ones used as arguments.</para>
    /// </summary>
    public unsafe Godot.Collections.Array MapTileProxy(int sourceFrom, Vector2I coordsFrom, int alternativeFrom)
    {
        return NativeCalls.godot_icall_3_1440(MethodBind82, GodotObject.GetPtr(this), sourceFrom, &coordsFrom, alternativeFrom);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind83 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CleanupInvalidTileProxies, 3218959716ul);

    /// <summary>
    /// <para>Clears tile proxies pointing to invalid tiles.</para>
    /// </summary>
    public void CleanupInvalidTileProxies()
    {
        NativeCalls.godot_icall_0_3(MethodBind83, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind84 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ClearTileProxies, 3218959716ul);

    /// <summary>
    /// <para>Clears all tile proxies.</para>
    /// </summary>
    public void ClearTileProxies()
    {
        NativeCalls.godot_icall_0_3(MethodBind84, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind85 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddPattern, 763712015ul);

    /// <summary>
    /// <para>Adds a <see cref="Godot.TileMapPattern"/> to be stored in the TileSet resource. If provided, insert it at the given <paramref name="index"/>.</para>
    /// </summary>
    public int AddPattern(TileMapPattern pattern, int index = -1)
    {
        return NativeCalls.godot_icall_2_792(MethodBind85, GodotObject.GetPtr(this), GodotObject.GetPtr(pattern), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind86 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPattern, 4207737510ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.TileMapPattern"/> at the given <paramref name="index"/>.</para>
    /// </summary>
    public TileMapPattern GetPattern(int index = -1)
    {
        return (TileMapPattern)NativeCalls.godot_icall_1_71(MethodBind86, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind87 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemovePattern, 1286410249ul);

    /// <summary>
    /// <para>Remove the <see cref="Godot.TileMapPattern"/> at the given index.</para>
    /// </summary>
    public void RemovePattern(int index)
    {
        NativeCalls.godot_icall_1_38(MethodBind87, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind88 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPatternsCount, 2455072627ul);

    /// <summary>
    /// <para>Returns the number of <see cref="Godot.TileMapPattern"/> this tile set handles.</para>
    /// </summary>
    public int GetPatternsCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind88, GodotObject.GetPtr(this));
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
        /// Cached name for the 'tile_shape' property.
        /// </summary>
        public static readonly StringName TileShape = "tile_shape";
        /// <summary>
        /// Cached name for the 'tile_layout' property.
        /// </summary>
        public static readonly StringName TileLayout = "tile_layout";
        /// <summary>
        /// Cached name for the 'tile_offset_axis' property.
        /// </summary>
        public static readonly StringName TileOffsetAxis = "tile_offset_axis";
        /// <summary>
        /// Cached name for the 'tile_size' property.
        /// </summary>
        public static readonly StringName TileSize = "tile_size";
        /// <summary>
        /// Cached name for the 'uv_clipping' property.
        /// </summary>
        public static readonly StringName UVClipping = "uv_clipping";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Resource.MethodName
    {
        /// <summary>
        /// Cached name for the 'get_next_source_id' method.
        /// </summary>
        public static readonly StringName GetNextSourceId = "get_next_source_id";
        /// <summary>
        /// Cached name for the 'add_source' method.
        /// </summary>
        public static readonly StringName AddSource = "add_source";
        /// <summary>
        /// Cached name for the 'remove_source' method.
        /// </summary>
        public static readonly StringName RemoveSource = "remove_source";
        /// <summary>
        /// Cached name for the 'set_source_id' method.
        /// </summary>
        public static readonly StringName SetSourceId = "set_source_id";
        /// <summary>
        /// Cached name for the 'get_source_count' method.
        /// </summary>
        public static readonly StringName GetSourceCount = "get_source_count";
        /// <summary>
        /// Cached name for the 'get_source_id' method.
        /// </summary>
        public static readonly StringName GetSourceId = "get_source_id";
        /// <summary>
        /// Cached name for the 'has_source' method.
        /// </summary>
        public static readonly StringName HasSource = "has_source";
        /// <summary>
        /// Cached name for the 'get_source' method.
        /// </summary>
        public static readonly StringName GetSource = "get_source";
        /// <summary>
        /// Cached name for the 'set_tile_shape' method.
        /// </summary>
        public static readonly StringName SetTileShape = "set_tile_shape";
        /// <summary>
        /// Cached name for the 'get_tile_shape' method.
        /// </summary>
        public static readonly StringName GetTileShape = "get_tile_shape";
        /// <summary>
        /// Cached name for the 'set_tile_layout' method.
        /// </summary>
        public static readonly StringName SetTileLayout = "set_tile_layout";
        /// <summary>
        /// Cached name for the 'get_tile_layout' method.
        /// </summary>
        public static readonly StringName GetTileLayout = "get_tile_layout";
        /// <summary>
        /// Cached name for the 'set_tile_offset_axis' method.
        /// </summary>
        public static readonly StringName SetTileOffsetAxis = "set_tile_offset_axis";
        /// <summary>
        /// Cached name for the 'get_tile_offset_axis' method.
        /// </summary>
        public static readonly StringName GetTileOffsetAxis = "get_tile_offset_axis";
        /// <summary>
        /// Cached name for the 'set_tile_size' method.
        /// </summary>
        public static readonly StringName SetTileSize = "set_tile_size";
        /// <summary>
        /// Cached name for the 'get_tile_size' method.
        /// </summary>
        public static readonly StringName GetTileSize = "get_tile_size";
        /// <summary>
        /// Cached name for the 'set_uv_clipping' method.
        /// </summary>
        public static readonly StringName SetUVClipping = "set_uv_clipping";
        /// <summary>
        /// Cached name for the 'is_uv_clipping' method.
        /// </summary>
        public static readonly StringName IsUVClipping = "is_uv_clipping";
        /// <summary>
        /// Cached name for the 'get_occlusion_layers_count' method.
        /// </summary>
        public static readonly StringName GetOcclusionLayersCount = "get_occlusion_layers_count";
        /// <summary>
        /// Cached name for the 'add_occlusion_layer' method.
        /// </summary>
        public static readonly StringName AddOcclusionLayer = "add_occlusion_layer";
        /// <summary>
        /// Cached name for the 'move_occlusion_layer' method.
        /// </summary>
        public static readonly StringName MoveOcclusionLayer = "move_occlusion_layer";
        /// <summary>
        /// Cached name for the 'remove_occlusion_layer' method.
        /// </summary>
        public static readonly StringName RemoveOcclusionLayer = "remove_occlusion_layer";
        /// <summary>
        /// Cached name for the 'set_occlusion_layer_light_mask' method.
        /// </summary>
        public static readonly StringName SetOcclusionLayerLightMask = "set_occlusion_layer_light_mask";
        /// <summary>
        /// Cached name for the 'get_occlusion_layer_light_mask' method.
        /// </summary>
        public static readonly StringName GetOcclusionLayerLightMask = "get_occlusion_layer_light_mask";
        /// <summary>
        /// Cached name for the 'set_occlusion_layer_sdf_collision' method.
        /// </summary>
        public static readonly StringName SetOcclusionLayerSdfCollision = "set_occlusion_layer_sdf_collision";
        /// <summary>
        /// Cached name for the 'get_occlusion_layer_sdf_collision' method.
        /// </summary>
        public static readonly StringName GetOcclusionLayerSdfCollision = "get_occlusion_layer_sdf_collision";
        /// <summary>
        /// Cached name for the 'get_physics_layers_count' method.
        /// </summary>
        public static readonly StringName GetPhysicsLayersCount = "get_physics_layers_count";
        /// <summary>
        /// Cached name for the 'add_physics_layer' method.
        /// </summary>
        public static readonly StringName AddPhysicsLayer = "add_physics_layer";
        /// <summary>
        /// Cached name for the 'move_physics_layer' method.
        /// </summary>
        public static readonly StringName MovePhysicsLayer = "move_physics_layer";
        /// <summary>
        /// Cached name for the 'remove_physics_layer' method.
        /// </summary>
        public static readonly StringName RemovePhysicsLayer = "remove_physics_layer";
        /// <summary>
        /// Cached name for the 'set_physics_layer_collision_layer' method.
        /// </summary>
        public static readonly StringName SetPhysicsLayerCollisionLayer = "set_physics_layer_collision_layer";
        /// <summary>
        /// Cached name for the 'get_physics_layer_collision_layer' method.
        /// </summary>
        public static readonly StringName GetPhysicsLayerCollisionLayer = "get_physics_layer_collision_layer";
        /// <summary>
        /// Cached name for the 'set_physics_layer_collision_mask' method.
        /// </summary>
        public static readonly StringName SetPhysicsLayerCollisionMask = "set_physics_layer_collision_mask";
        /// <summary>
        /// Cached name for the 'get_physics_layer_collision_mask' method.
        /// </summary>
        public static readonly StringName GetPhysicsLayerCollisionMask = "get_physics_layer_collision_mask";
        /// <summary>
        /// Cached name for the 'set_physics_layer_collision_priority' method.
        /// </summary>
        public static readonly StringName SetPhysicsLayerCollisionPriority = "set_physics_layer_collision_priority";
        /// <summary>
        /// Cached name for the 'get_physics_layer_collision_priority' method.
        /// </summary>
        public static readonly StringName GetPhysicsLayerCollisionPriority = "get_physics_layer_collision_priority";
        /// <summary>
        /// Cached name for the 'set_physics_layer_physics_material' method.
        /// </summary>
        public static readonly StringName SetPhysicsLayerPhysicsMaterial = "set_physics_layer_physics_material";
        /// <summary>
        /// Cached name for the 'get_physics_layer_physics_material' method.
        /// </summary>
        public static readonly StringName GetPhysicsLayerPhysicsMaterial = "get_physics_layer_physics_material";
        /// <summary>
        /// Cached name for the 'get_terrain_sets_count' method.
        /// </summary>
        public static readonly StringName GetTerrainSetsCount = "get_terrain_sets_count";
        /// <summary>
        /// Cached name for the 'add_terrain_set' method.
        /// </summary>
        public static readonly StringName AddTerrainSet = "add_terrain_set";
        /// <summary>
        /// Cached name for the 'move_terrain_set' method.
        /// </summary>
        public static readonly StringName MoveTerrainSet = "move_terrain_set";
        /// <summary>
        /// Cached name for the 'remove_terrain_set' method.
        /// </summary>
        public static readonly StringName RemoveTerrainSet = "remove_terrain_set";
        /// <summary>
        /// Cached name for the 'set_terrain_set_mode' method.
        /// </summary>
        public static readonly StringName SetTerrainSetMode = "set_terrain_set_mode";
        /// <summary>
        /// Cached name for the 'get_terrain_set_mode' method.
        /// </summary>
        public static readonly StringName GetTerrainSetMode = "get_terrain_set_mode";
        /// <summary>
        /// Cached name for the 'get_terrains_count' method.
        /// </summary>
        public static readonly StringName GetTerrainsCount = "get_terrains_count";
        /// <summary>
        /// Cached name for the 'add_terrain' method.
        /// </summary>
        public static readonly StringName AddTerrain = "add_terrain";
        /// <summary>
        /// Cached name for the 'move_terrain' method.
        /// </summary>
        public static readonly StringName MoveTerrain = "move_terrain";
        /// <summary>
        /// Cached name for the 'remove_terrain' method.
        /// </summary>
        public static readonly StringName RemoveTerrain = "remove_terrain";
        /// <summary>
        /// Cached name for the 'set_terrain_name' method.
        /// </summary>
        public static readonly StringName SetTerrainName = "set_terrain_name";
        /// <summary>
        /// Cached name for the 'get_terrain_name' method.
        /// </summary>
        public static readonly StringName GetTerrainName = "get_terrain_name";
        /// <summary>
        /// Cached name for the 'set_terrain_color' method.
        /// </summary>
        public static readonly StringName SetTerrainColor = "set_terrain_color";
        /// <summary>
        /// Cached name for the 'get_terrain_color' method.
        /// </summary>
        public static readonly StringName GetTerrainColor = "get_terrain_color";
        /// <summary>
        /// Cached name for the 'get_navigation_layers_count' method.
        /// </summary>
        public static readonly StringName GetNavigationLayersCount = "get_navigation_layers_count";
        /// <summary>
        /// Cached name for the 'add_navigation_layer' method.
        /// </summary>
        public static readonly StringName AddNavigationLayer = "add_navigation_layer";
        /// <summary>
        /// Cached name for the 'move_navigation_layer' method.
        /// </summary>
        public static readonly StringName MoveNavigationLayer = "move_navigation_layer";
        /// <summary>
        /// Cached name for the 'remove_navigation_layer' method.
        /// </summary>
        public static readonly StringName RemoveNavigationLayer = "remove_navigation_layer";
        /// <summary>
        /// Cached name for the 'set_navigation_layer_layers' method.
        /// </summary>
        public static readonly StringName SetNavigationLayerLayers = "set_navigation_layer_layers";
        /// <summary>
        /// Cached name for the 'get_navigation_layer_layers' method.
        /// </summary>
        public static readonly StringName GetNavigationLayerLayers = "get_navigation_layer_layers";
        /// <summary>
        /// Cached name for the 'set_navigation_layer_layer_value' method.
        /// </summary>
        public static readonly StringName SetNavigationLayerLayerValue = "set_navigation_layer_layer_value";
        /// <summary>
        /// Cached name for the 'get_navigation_layer_layer_value' method.
        /// </summary>
        public static readonly StringName GetNavigationLayerLayerValue = "get_navigation_layer_layer_value";
        /// <summary>
        /// Cached name for the 'get_custom_data_layers_count' method.
        /// </summary>
        public static readonly StringName GetCustomDataLayersCount = "get_custom_data_layers_count";
        /// <summary>
        /// Cached name for the 'add_custom_data_layer' method.
        /// </summary>
        public static readonly StringName AddCustomDataLayer = "add_custom_data_layer";
        /// <summary>
        /// Cached name for the 'move_custom_data_layer' method.
        /// </summary>
        public static readonly StringName MoveCustomDataLayer = "move_custom_data_layer";
        /// <summary>
        /// Cached name for the 'remove_custom_data_layer' method.
        /// </summary>
        public static readonly StringName RemoveCustomDataLayer = "remove_custom_data_layer";
        /// <summary>
        /// Cached name for the 'get_custom_data_layer_by_name' method.
        /// </summary>
        public static readonly StringName GetCustomDataLayerByName = "get_custom_data_layer_by_name";
        /// <summary>
        /// Cached name for the 'set_custom_data_layer_name' method.
        /// </summary>
        public static readonly StringName SetCustomDataLayerName = "set_custom_data_layer_name";
        /// <summary>
        /// Cached name for the 'has_custom_data_layer_by_name' method.
        /// </summary>
        public static readonly StringName HasCustomDataLayerByName = "has_custom_data_layer_by_name";
        /// <summary>
        /// Cached name for the 'get_custom_data_layer_name' method.
        /// </summary>
        public static readonly StringName GetCustomDataLayerName = "get_custom_data_layer_name";
        /// <summary>
        /// Cached name for the 'set_custom_data_layer_type' method.
        /// </summary>
        public static readonly StringName SetCustomDataLayerType = "set_custom_data_layer_type";
        /// <summary>
        /// Cached name for the 'get_custom_data_layer_type' method.
        /// </summary>
        public static readonly StringName GetCustomDataLayerType = "get_custom_data_layer_type";
        /// <summary>
        /// Cached name for the 'set_source_level_tile_proxy' method.
        /// </summary>
        public static readonly StringName SetSourceLevelTileProxy = "set_source_level_tile_proxy";
        /// <summary>
        /// Cached name for the 'get_source_level_tile_proxy' method.
        /// </summary>
        public static readonly StringName GetSourceLevelTileProxy = "get_source_level_tile_proxy";
        /// <summary>
        /// Cached name for the 'has_source_level_tile_proxy' method.
        /// </summary>
        public static readonly StringName HasSourceLevelTileProxy = "has_source_level_tile_proxy";
        /// <summary>
        /// Cached name for the 'remove_source_level_tile_proxy' method.
        /// </summary>
        public static readonly StringName RemoveSourceLevelTileProxy = "remove_source_level_tile_proxy";
        /// <summary>
        /// Cached name for the 'set_coords_level_tile_proxy' method.
        /// </summary>
        public static readonly StringName SetCoordsLevelTileProxy = "set_coords_level_tile_proxy";
        /// <summary>
        /// Cached name for the 'get_coords_level_tile_proxy' method.
        /// </summary>
        public static readonly StringName GetCoordsLevelTileProxy = "get_coords_level_tile_proxy";
        /// <summary>
        /// Cached name for the 'has_coords_level_tile_proxy' method.
        /// </summary>
        public static readonly StringName HasCoordsLevelTileProxy = "has_coords_level_tile_proxy";
        /// <summary>
        /// Cached name for the 'remove_coords_level_tile_proxy' method.
        /// </summary>
        public static readonly StringName RemoveCoordsLevelTileProxy = "remove_coords_level_tile_proxy";
        /// <summary>
        /// Cached name for the 'set_alternative_level_tile_proxy' method.
        /// </summary>
        public static readonly StringName SetAlternativeLevelTileProxy = "set_alternative_level_tile_proxy";
        /// <summary>
        /// Cached name for the 'get_alternative_level_tile_proxy' method.
        /// </summary>
        public static readonly StringName GetAlternativeLevelTileProxy = "get_alternative_level_tile_proxy";
        /// <summary>
        /// Cached name for the 'has_alternative_level_tile_proxy' method.
        /// </summary>
        public static readonly StringName HasAlternativeLevelTileProxy = "has_alternative_level_tile_proxy";
        /// <summary>
        /// Cached name for the 'remove_alternative_level_tile_proxy' method.
        /// </summary>
        public static readonly StringName RemoveAlternativeLevelTileProxy = "remove_alternative_level_tile_proxy";
        /// <summary>
        /// Cached name for the 'map_tile_proxy' method.
        /// </summary>
        public static readonly StringName MapTileProxy = "map_tile_proxy";
        /// <summary>
        /// Cached name for the 'cleanup_invalid_tile_proxies' method.
        /// </summary>
        public static readonly StringName CleanupInvalidTileProxies = "cleanup_invalid_tile_proxies";
        /// <summary>
        /// Cached name for the 'clear_tile_proxies' method.
        /// </summary>
        public static readonly StringName ClearTileProxies = "clear_tile_proxies";
        /// <summary>
        /// Cached name for the 'add_pattern' method.
        /// </summary>
        public static readonly StringName AddPattern = "add_pattern";
        /// <summary>
        /// Cached name for the 'get_pattern' method.
        /// </summary>
        public static readonly StringName GetPattern = "get_pattern";
        /// <summary>
        /// Cached name for the 'remove_pattern' method.
        /// </summary>
        public static readonly StringName RemovePattern = "remove_pattern";
        /// <summary>
        /// Cached name for the 'get_patterns_count' method.
        /// </summary>
        public static readonly StringName GetPatternsCount = "get_patterns_count";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Resource.SignalName
    {
    }
}
