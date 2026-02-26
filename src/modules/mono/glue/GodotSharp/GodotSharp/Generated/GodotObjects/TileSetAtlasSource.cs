namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>An atlas is a grid of tiles laid out on a texture. Each tile in the grid must be exposed using <see cref="Godot.TileSetAtlasSource.CreateTile(Vector2I, Nullable{Vector2I})"/>. Those tiles are then indexed using their coordinates in the grid.</para>
/// <para>Each tile can also have a size in the grid coordinates, making it more or less cells in the atlas.</para>
/// <para>Alternatives version of a tile can be created using <see cref="Godot.TileSetAtlasSource.CreateAlternativeTile(Vector2I, int)"/>, which are then indexed using an alternative ID. The main tile (the one in the grid), is accessed with an alternative ID equal to 0.</para>
/// <para>Each tile alternate has a set of properties that is defined by the source's <see cref="Godot.TileSet"/> layers. Those properties are stored in a TileData object that can be accessed and modified using <see cref="Godot.TileSetAtlasSource.GetTileData(Vector2I, int)"/>.</para>
/// <para>As TileData properties are stored directly in the TileSetAtlasSource resource, their properties might also be set using <c>TileSetAtlasSource.set("&lt;coords_x&gt;:&lt;coords_y&gt;/&lt;alternative_id&gt;/&lt;tile_data_property&gt;")</c>.</para>
/// </summary>
public partial class TileSetAtlasSource : TileSetSource
{
    /// <summary>
    /// <para>Represents cell's horizontal flip flag. Should be used directly with <see cref="Godot.TileMapLayer"/> to flip placed tiles by altering their alternative IDs.</para>
    /// <para><code>
    /// var alternate_id = $TileMapLayer.get_cell_alternative_tile(Vector2i(2, 2))
    /// if not alternate_id &amp; TileSetAtlasSource.TRANSFORM_FLIP_H:
    /// 	# If tile is not already flipped, flip it.
    /// 	$TileMapLayer.set_cell(Vector2i(2, 2), source_id, atlas_coords, alternate_id | TileSetAtlasSource.TRANSFORM_FLIP_H)
    /// </code></para>
    /// <para><b>Note:</b> These transformations can be combined to do the equivalent of 0, 90, 180, and 270 degree rotations, as shown below:</para>
    /// <para><code>
    /// enum TileTransform {
    /// 	ROTATE_0 = 0,
    /// 	ROTATE_90 = TileSetAtlasSource.TRANSFORM_TRANSPOSE | TileSetAtlasSource.TRANSFORM_FLIP_H,
    /// 	ROTATE_180 = TileSetAtlasSource.TRANSFORM_FLIP_H | TileSetAtlasSource.TRANSFORM_FLIP_V,
    /// 	ROTATE_270 = TileSetAtlasSource.TRANSFORM_TRANSPOSE | TileSetAtlasSource.TRANSFORM_FLIP_V,
    /// }
    /// </code></para>
    /// </summary>
    public const long TransformFlipH = 4096;
    /// <summary>
    /// <para>Represents cell's vertical flip flag. See <see cref="Godot.TileSetAtlasSource.TransformFlipH"/> for usage.</para>
    /// </summary>
    public const long TransformFlipV = 8192;
    /// <summary>
    /// <para>Represents cell's transposed flag. See <see cref="Godot.TileSetAtlasSource.TransformFlipH"/> for usage.</para>
    /// </summary>
    public const long TransformTranspose = 16384;

    public enum TileAnimationMode : long
    {
        /// <summary>
        /// <para>Tile animations start at same time, looking identical.</para>
        /// </summary>
        Default = 0,
        /// <summary>
        /// <para>Tile animations start at random times, looking varied.</para>
        /// </summary>
        RandomStartTimes = 1,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.TileSetAtlasSource.TileAnimationMode"/> enum.</para>
        /// </summary>
        Max = 2
    }

    /// <summary>
    /// <para>The atlas texture.</para>
    /// </summary>
    public Texture2D Texture
    {
        get
        {
            return GetTexture();
        }
        set
        {
            SetTexture(value);
        }
    }

    /// <summary>
    /// <para>Margins, in pixels, to offset the origin of the grid in the texture.</para>
    /// </summary>
    public Vector2I Margins
    {
        get
        {
            return GetMargins();
        }
        set
        {
            SetMargins(value);
        }
    }

    /// <summary>
    /// <para>Separation, in pixels, between each tile texture region of the grid.</para>
    /// </summary>
    public Vector2I Separation
    {
        get
        {
            return GetSeparation();
        }
        set
        {
            SetSeparation(value);
        }
    }

    /// <summary>
    /// <para>The base tile size in the texture (in pixel). This size must be bigger than or equal to the TileSet's <c>tile_size</c> value.</para>
    /// </summary>
    public Vector2I TextureRegionSize
    {
        get
        {
            return GetTextureRegionSize();
        }
        set
        {
            SetTextureRegionSize(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, generates an internal texture with an additional one pixel padding around each tile. Texture padding avoids a common artifact where lines appear between tiles.</para>
    /// <para>Disabling this setting might lead a small performance improvement, as generating the internal texture requires both memory and processing time when the TileSetAtlasSource resource is modified.</para>
    /// </summary>
    public bool UseTexturePadding
    {
        get
        {
            return GetUseTexturePadding();
        }
        set
        {
            SetUseTexturePadding(value);
        }
    }

    private static readonly System.Type CachedType = typeof(TileSetAtlasSource);

    private static readonly StringName NativeName = "TileSetAtlasSource";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public TileSetAtlasSource() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal TileSetAtlasSource(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal TileSetAtlasSource(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTexture, 4051416890ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTexture(Texture2D texture)
    {
        NativeCalls.godot_icall_1_56(MethodBind0, GodotObject.GetPtr(this), GodotObject.GetPtr(texture));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTexture, 3635182373ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Texture2D GetTexture()
    {
        return (Texture2D)NativeCalls.godot_icall_0_63(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMargins, 1130785943ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetMargins(Vector2I margins)
    {
        NativeCalls.godot_icall_1_34(MethodBind2, GodotObject.GetPtr(this), &margins);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMargins, 3690982128ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2I GetMargins()
    {
        return NativeCalls.godot_icall_0_35(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSeparation, 1130785943ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetSeparation(Vector2I separation)
    {
        NativeCalls.godot_icall_1_34(MethodBind4, GodotObject.GetPtr(this), &separation);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSeparation, 3690982128ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2I GetSeparation()
    {
        return NativeCalls.godot_icall_0_35(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTextureRegionSize, 1130785943ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetTextureRegionSize(Vector2I textureRegionSize)
    {
        NativeCalls.godot_icall_1_34(MethodBind6, GodotObject.GetPtr(this), &textureRegionSize);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTextureRegionSize, 3690982128ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2I GetTextureRegionSize()
    {
        return NativeCalls.godot_icall_0_35(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetUseTexturePadding, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetUseTexturePadding(bool useTexturePadding)
    {
        NativeCalls.godot_icall_1_14(MethodBind8, GodotObject.GetPtr(this), useTexturePadding.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetUseTexturePadding, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetUseTexturePadding()
    {
        return NativeCalls.godot_icall_0_15(MethodBind9, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CreateTile, 190528769ul);

    /// <summary>
    /// <para>Creates a new tile at coordinates <paramref name="atlasCoords"/> with the given <paramref name="size"/>.</para>
    /// </summary>
    /// <param name="size">If the parameter is null, then the default value is <c>new Vector2I(1, 1)</c>.</param>
    public unsafe void CreateTile(Vector2I atlasCoords, Nullable<Vector2I> size = null)
    {
        Vector2I sizeOrDefVal = size.HasValue ? size.Value : new Vector2I(1, 1);
        NativeCalls.godot_icall_2_1449(MethodBind10, GodotObject.GetPtr(this), &atlasCoords, &sizeOrDefVal);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveTile, 1130785943ul);

    /// <summary>
    /// <para>Remove a tile and its alternative at coordinates <paramref name="atlasCoords"/>.</para>
    /// </summary>
    public unsafe void RemoveTile(Vector2I atlasCoords)
    {
        NativeCalls.godot_icall_1_34(MethodBind11, GodotObject.GetPtr(this), &atlasCoords);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MoveTileInAtlas, 3870111920ul);

    /// <summary>
    /// <para>Move the tile and its alternatives at the <paramref name="atlasCoords"/> coordinates to the <paramref name="newAtlasCoords"/> coordinates with the <paramref name="newSize"/> size. This functions will fail if a tile is already present in the given area.</para>
    /// <para>If <paramref name="newAtlasCoords"/> is <c>Vector2i(-1, -1)</c>, keeps the tile's coordinates. If <paramref name="newSize"/> is <c>Vector2i(-1, -1)</c>, keeps the tile's size.</para>
    /// <para>To avoid an error, first check if a move is possible using <see cref="Godot.TileSetAtlasSource.HasRoomForTile(Vector2I, Vector2I, int, Vector2I, int, Nullable{Vector2I})"/>.</para>
    /// </summary>
    /// <param name="newAtlasCoords">If the parameter is null, then the default value is <c>new Vector2I(-1, -1)</c>.</param>
    /// <param name="newSize">If the parameter is null, then the default value is <c>new Vector2I(-1, -1)</c>.</param>
    public unsafe void MoveTileInAtlas(Vector2I atlasCoords, Nullable<Vector2I> newAtlasCoords = null, Nullable<Vector2I> newSize = null)
    {
        Vector2I newAtlasCoordsOrDefVal = newAtlasCoords.HasValue ? newAtlasCoords.Value : new Vector2I(-1, -1);
        Vector2I newSizeOrDefVal = newSize.HasValue ? newSize.Value : new Vector2I(-1, -1);
        NativeCalls.godot_icall_3_1450(MethodBind12, GodotObject.GetPtr(this), &atlasCoords, &newAtlasCoordsOrDefVal, &newSizeOrDefVal);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTileSizeInAtlas, 3050897911ul);

    /// <summary>
    /// <para>Returns the size of the tile (in the grid coordinates system) at coordinates <paramref name="atlasCoords"/>.</para>
    /// </summary>
    public unsafe Vector2I GetTileSizeInAtlas(Vector2I atlasCoords)
    {
        return NativeCalls.godot_icall_1_1438(MethodBind13, GodotObject.GetPtr(this), &atlasCoords);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasRoomForTile, 3018597268ul);

    /// <summary>
    /// <para>Returns whether there is enough room in an atlas to create/modify a tile with the given properties. If <paramref name="ignoredTile"/> is provided, act as is the given tile was not present in the atlas. This may be used when you want to modify a tile's properties.</para>
    /// </summary>
    /// <param name="ignoredTile">If the parameter is null, then the default value is <c>new Vector2I(-1, -1)</c>.</param>
    public unsafe bool HasRoomForTile(Vector2I atlasCoords, Vector2I size, int animationColumns, Vector2I animationSeparation, int framesCount, Nullable<Vector2I> ignoredTile = null)
    {
        Vector2I ignoredTileOrDefVal = ignoredTile.HasValue ? ignoredTile.Value : new Vector2I(-1, -1);
        return NativeCalls.godot_icall_6_1451(MethodBind14, GodotObject.GetPtr(this), &atlasCoords, &size, animationColumns, &animationSeparation, framesCount, &ignoredTileOrDefVal).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTilesToBeRemovedOnChange, 1240378054ul);

    /// <summary>
    /// <para>Returns an array of tiles coordinates ID that will be automatically removed when modifying one or several of those properties: <paramref name="texture"/>, <paramref name="margins"/>, <paramref name="separation"/> or <paramref name="textureRegionSize"/>. This can be used to undo changes that would have caused tiles data loss.</para>
    /// </summary>
    public unsafe Vector2[] GetTilesToBeRemovedOnChange(Texture2D texture, Vector2I margins, Vector2I separation, Vector2I textureRegionSize)
    {
        return NativeCalls.godot_icall_4_1452(MethodBind15, GodotObject.GetPtr(this), GodotObject.GetPtr(texture), &margins, &separation, &textureRegionSize);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTileAtCoords, 3050897911ul);

    /// <summary>
    /// <para>If there is a tile covering the <paramref name="atlasCoords"/> coordinates, returns the top-left coordinates of the tile (thus its coordinate ID). Returns <c>Vector2i(-1, -1)</c> otherwise.</para>
    /// </summary>
    public unsafe Vector2I GetTileAtCoords(Vector2I atlasCoords)
    {
        return NativeCalls.godot_icall_1_1438(MethodBind16, GodotObject.GetPtr(this), &atlasCoords);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasTilesOutsideTexture, 36873697ul);

    /// <summary>
    /// <para>Checks if the source has any tiles that don't fit the texture area (either partially or completely).</para>
    /// </summary>
    public bool HasTilesOutsideTexture()
    {
        return NativeCalls.godot_icall_0_15(MethodBind17, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ClearTilesOutsideTexture, 3218959716ul);

    /// <summary>
    /// <para>Removes all tiles that don't fit the available texture area. This method iterates over all the source's tiles, so it's advised to use <see cref="Godot.TileSetAtlasSource.HasTilesOutsideTexture()"/> beforehand.</para>
    /// </summary>
    public void ClearTilesOutsideTexture()
    {
        NativeCalls.godot_icall_0_3(MethodBind18, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTileAnimationColumns, 3200960707ul);

    /// <summary>
    /// <para>Sets the number of columns in the animation layout of the tile at coordinates <paramref name="atlasCoords"/>. If set to 0, then the different frames of the animation are laid out as a single horizontal line in the atlas.</para>
    /// </summary>
    public unsafe void SetTileAnimationColumns(Vector2I atlasCoords, int frameColumns)
    {
        NativeCalls.godot_icall_2_413(MethodBind19, GodotObject.GetPtr(this), &atlasCoords, frameColumns);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTileAnimationColumns, 2485466453ul);

    /// <summary>
    /// <para>Returns how many columns the tile at <paramref name="atlasCoords"/> has in its animation layout.</para>
    /// </summary>
    public unsafe int GetTileAnimationColumns(Vector2I atlasCoords)
    {
        return NativeCalls.godot_icall_1_409(MethodBind20, GodotObject.GetPtr(this), &atlasCoords);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTileAnimationSeparation, 1941061099ul);

    /// <summary>
    /// <para>Sets the margin (in grid tiles) between each tile in the animation layout of the tile at coordinates <paramref name="atlasCoords"/> has.</para>
    /// </summary>
    public unsafe void SetTileAnimationSeparation(Vector2I atlasCoords, Vector2I separation)
    {
        NativeCalls.godot_icall_2_1449(MethodBind21, GodotObject.GetPtr(this), &atlasCoords, &separation);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTileAnimationSeparation, 3050897911ul);

    /// <summary>
    /// <para>Returns the separation (as in the atlas grid) between each frame of an animated tile at coordinates <paramref name="atlasCoords"/>.</para>
    /// </summary>
    public unsafe Vector2I GetTileAnimationSeparation(Vector2I atlasCoords)
    {
        return NativeCalls.godot_icall_1_1438(MethodBind22, GodotObject.GetPtr(this), &atlasCoords);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTileAnimationSpeed, 2262553149ul);

    /// <summary>
    /// <para>Sets the animation speed of the tile at coordinates <paramref name="atlasCoords"/> has.</para>
    /// </summary>
    public unsafe void SetTileAnimationSpeed(Vector2I atlasCoords, float speed)
    {
        NativeCalls.godot_icall_2_43(MethodBind23, GodotObject.GetPtr(this), &atlasCoords, speed);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTileAnimationSpeed, 719993801ul);

    /// <summary>
    /// <para>Returns the animation speed of the tile at coordinates <paramref name="atlasCoords"/>.</para>
    /// </summary>
    public unsafe float GetTileAnimationSpeed(Vector2I atlasCoords)
    {
        return NativeCalls.godot_icall_1_44(MethodBind24, GodotObject.GetPtr(this), &atlasCoords);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTileAnimationMode, 3192753483ul);

    /// <summary>
    /// <para>Sets the tile animation mode of the tile at <paramref name="atlasCoords"/> to <paramref name="mode"/>. See also <see cref="Godot.TileSetAtlasSource.GetTileAnimationMode(Vector2I)"/>.</para>
    /// </summary>
    public unsafe void SetTileAnimationMode(Vector2I atlasCoords, TileSetAtlasSource.TileAnimationMode mode)
    {
        NativeCalls.godot_icall_2_413(MethodBind25, GodotObject.GetPtr(this), &atlasCoords, (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTileAnimationMode, 4025349959ul);

    /// <summary>
    /// <para>Returns the tile animation mode of the tile at <paramref name="atlasCoords"/>. See also <see cref="Godot.TileSetAtlasSource.SetTileAnimationMode(Vector2I, TileSetAtlasSource.TileAnimationMode)"/>.</para>
    /// </summary>
    public unsafe TileSetAtlasSource.TileAnimationMode GetTileAnimationMode(Vector2I atlasCoords)
    {
        return (TileSetAtlasSource.TileAnimationMode)NativeCalls.godot_icall_1_409(MethodBind26, GodotObject.GetPtr(this), &atlasCoords);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTileAnimationFramesCount, 3200960707ul);

    /// <summary>
    /// <para>Sets how many animation frames the tile at coordinates <paramref name="atlasCoords"/> has.</para>
    /// </summary>
    public unsafe void SetTileAnimationFramesCount(Vector2I atlasCoords, int framesCount)
    {
        NativeCalls.godot_icall_2_413(MethodBind27, GodotObject.GetPtr(this), &atlasCoords, framesCount);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTileAnimationFramesCount, 2485466453ul);

    /// <summary>
    /// <para>Returns how many animation frames has the tile at coordinates <paramref name="atlasCoords"/>.</para>
    /// </summary>
    public unsafe int GetTileAnimationFramesCount(Vector2I atlasCoords)
    {
        return NativeCalls.godot_icall_1_409(MethodBind28, GodotObject.GetPtr(this), &atlasCoords);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTileAnimationFrameDuration, 2843487787ul);

    /// <summary>
    /// <para>Sets the animation frame <paramref name="duration"/> of frame <paramref name="frameIndex"/> for the tile at coordinates <paramref name="atlasCoords"/>.</para>
    /// </summary>
    public unsafe void SetTileAnimationFrameDuration(Vector2I atlasCoords, int frameIndex, float duration)
    {
        NativeCalls.godot_icall_3_1453(MethodBind29, GodotObject.GetPtr(this), &atlasCoords, frameIndex, duration);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTileAnimationFrameDuration, 1802448425ul);

    /// <summary>
    /// <para>Returns the animation frame duration of frame <paramref name="frameIndex"/> for the tile at coordinates <paramref name="atlasCoords"/>.</para>
    /// </summary>
    public unsafe float GetTileAnimationFrameDuration(Vector2I atlasCoords, int frameIndex)
    {
        return NativeCalls.godot_icall_2_1454(MethodBind30, GodotObject.GetPtr(this), &atlasCoords, frameIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTileAnimationTotalDuration, 719993801ul);

    /// <summary>
    /// <para>Returns the sum of the sum of the frame durations of the tile at coordinates <paramref name="atlasCoords"/>. This value needs to be divided by the animation speed to get the actual animation loop duration.</para>
    /// </summary>
    public unsafe float GetTileAnimationTotalDuration(Vector2I atlasCoords)
    {
        return NativeCalls.godot_icall_1_44(MethodBind31, GodotObject.GetPtr(this), &atlasCoords);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind32 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CreateAlternativeTile, 2226298068ul);

    /// <summary>
    /// <para>Creates an alternative tile for the tile at coordinates <paramref name="atlasCoords"/>. If <paramref name="alternativeIdOverride"/> is -1, give it an automatically generated unique ID, or assigns it the given ID otherwise.</para>
    /// <para>Returns the new alternative identifier, or -1 if the alternative could not be created with a provided <paramref name="alternativeIdOverride"/>.</para>
    /// </summary>
    public unsafe int CreateAlternativeTile(Vector2I atlasCoords, int alternativeIdOverride = -1)
    {
        return NativeCalls.godot_icall_2_1455(MethodBind32, GodotObject.GetPtr(this), &atlasCoords, alternativeIdOverride);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind33 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveAlternativeTile, 3200960707ul);

    /// <summary>
    /// <para>Remove a tile's alternative with alternative ID <paramref name="alternativeTile"/>.</para>
    /// <para>Calling this function with <paramref name="alternativeTile"/> equals to 0 will fail, as the base tile alternative cannot be removed.</para>
    /// </summary>
    public unsafe void RemoveAlternativeTile(Vector2I atlasCoords, int alternativeTile)
    {
        NativeCalls.godot_icall_2_413(MethodBind33, GodotObject.GetPtr(this), &atlasCoords, alternativeTile);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind34 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAlternativeTileId, 1499785778ul);

    /// <summary>
    /// <para>Change a tile's alternative ID from <paramref name="alternativeTile"/> to <paramref name="newId"/>.</para>
    /// <para>Calling this function with <paramref name="newId"/> of 0 will fail, as the base tile alternative cannot be moved.</para>
    /// </summary>
    public unsafe void SetAlternativeTileId(Vector2I atlasCoords, int alternativeTile, int newId)
    {
        NativeCalls.godot_icall_3_1456(MethodBind34, GodotObject.GetPtr(this), &atlasCoords, alternativeTile, newId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind35 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNextAlternativeTileId, 2485466453ul);

    /// <summary>
    /// <para>Returns the alternative ID a following call to <see cref="Godot.TileSetAtlasSource.CreateAlternativeTile(Vector2I, int)"/> would return.</para>
    /// </summary>
    public unsafe int GetNextAlternativeTileId(Vector2I atlasCoords)
    {
        return NativeCalls.godot_icall_1_409(MethodBind35, GodotObject.GetPtr(this), &atlasCoords);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind36 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTileData, 3534028207ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.TileData"/> object for the given atlas coordinates and alternative ID.</para>
    /// </summary>
    public unsafe TileData GetTileData(Vector2I atlasCoords, int alternativeTile)
    {
        return (TileData)NativeCalls.godot_icall_2_1457(MethodBind36, GodotObject.GetPtr(this), &atlasCoords, alternativeTile);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind37 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAtlasGridSize, 3690982128ul);

    /// <summary>
    /// <para>Returns the atlas grid size, which depends on how many tiles can fit in the texture. It thus depends on the <see cref="Godot.TileSetAtlasSource.Texture"/>'s size, the atlas <see cref="Godot.TileSetAtlasSource.Margins"/>, and the tiles' <see cref="Godot.TileSetAtlasSource.TextureRegionSize"/>.</para>
    /// </summary>
    public Vector2I GetAtlasGridSize()
    {
        return NativeCalls.godot_icall_0_35(MethodBind37, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind38 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTileTextureRegion, 241857547ul);

    /// <summary>
    /// <para>Returns a tile's texture region in the atlas texture. For animated tiles, a <paramref name="frame"/> argument might be provided for the different frames of the animation.</para>
    /// </summary>
    public unsafe Rect2I GetTileTextureRegion(Vector2I atlasCoords, int frame = 0)
    {
        return NativeCalls.godot_icall_2_1458(MethodBind38, GodotObject.GetPtr(this), &atlasCoords, frame);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind39 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRuntimeTexture, 3635182373ul);

    /// <summary>
    /// <para>If <see cref="Godot.TileSetAtlasSource.UseTexturePadding"/> is <see langword="false"/>, returns <see cref="Godot.TileSetAtlasSource.Texture"/>. Otherwise, returns an internal <see cref="Godot.ImageTexture"/> created that includes the padding.</para>
    /// </summary>
    public Texture2D GetRuntimeTexture()
    {
        return (Texture2D)NativeCalls.godot_icall_0_63(MethodBind39, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind40 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRuntimeTileTextureRegion, 104874263ul);

    /// <summary>
    /// <para>Returns the region of the tile at coordinates <paramref name="atlasCoords"/> for the given <paramref name="frame"/> inside the texture returned by <see cref="Godot.TileSetAtlasSource.GetRuntimeTexture()"/>.</para>
    /// <para><b>Note:</b> If <see cref="Godot.TileSetAtlasSource.UseTexturePadding"/> is <see langword="false"/>, returns the same as <see cref="Godot.TileSetAtlasSource.GetTileTextureRegion(Vector2I, int)"/>.</para>
    /// </summary>
    public unsafe Rect2I GetRuntimeTileTextureRegion(Vector2I atlasCoords, int frame)
    {
        return NativeCalls.godot_icall_2_1458(MethodBind40, GodotObject.GetPtr(this), &atlasCoords, frame);
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
    public new class PropertyName : TileSetSource.PropertyName
    {
        /// <summary>
        /// Cached name for the 'texture' property.
        /// </summary>
        public static readonly StringName Texture = "texture";
        /// <summary>
        /// Cached name for the 'margins' property.
        /// </summary>
        public static readonly StringName Margins = "margins";
        /// <summary>
        /// Cached name for the 'separation' property.
        /// </summary>
        public static readonly StringName Separation = "separation";
        /// <summary>
        /// Cached name for the 'texture_region_size' property.
        /// </summary>
        public static readonly StringName TextureRegionSize = "texture_region_size";
        /// <summary>
        /// Cached name for the 'use_texture_padding' property.
        /// </summary>
        public static readonly StringName UseTexturePadding = "use_texture_padding";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : TileSetSource.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_texture' method.
        /// </summary>
        public static readonly StringName SetTexture = "set_texture";
        /// <summary>
        /// Cached name for the 'get_texture' method.
        /// </summary>
        public static readonly StringName GetTexture = "get_texture";
        /// <summary>
        /// Cached name for the 'set_margins' method.
        /// </summary>
        public static readonly StringName SetMargins = "set_margins";
        /// <summary>
        /// Cached name for the 'get_margins' method.
        /// </summary>
        public static readonly StringName GetMargins = "get_margins";
        /// <summary>
        /// Cached name for the 'set_separation' method.
        /// </summary>
        public static readonly StringName SetSeparation = "set_separation";
        /// <summary>
        /// Cached name for the 'get_separation' method.
        /// </summary>
        public static readonly StringName GetSeparation = "get_separation";
        /// <summary>
        /// Cached name for the 'set_texture_region_size' method.
        /// </summary>
        public static readonly StringName SetTextureRegionSize = "set_texture_region_size";
        /// <summary>
        /// Cached name for the 'get_texture_region_size' method.
        /// </summary>
        public static readonly StringName GetTextureRegionSize = "get_texture_region_size";
        /// <summary>
        /// Cached name for the 'set_use_texture_padding' method.
        /// </summary>
        public static readonly StringName SetUseTexturePadding = "set_use_texture_padding";
        /// <summary>
        /// Cached name for the 'get_use_texture_padding' method.
        /// </summary>
        public static readonly StringName GetUseTexturePadding = "get_use_texture_padding";
        /// <summary>
        /// Cached name for the 'create_tile' method.
        /// </summary>
        public static readonly StringName CreateTile = "create_tile";
        /// <summary>
        /// Cached name for the 'remove_tile' method.
        /// </summary>
        public static readonly StringName RemoveTile = "remove_tile";
        /// <summary>
        /// Cached name for the 'move_tile_in_atlas' method.
        /// </summary>
        public static readonly StringName MoveTileInAtlas = "move_tile_in_atlas";
        /// <summary>
        /// Cached name for the 'get_tile_size_in_atlas' method.
        /// </summary>
        public static readonly StringName GetTileSizeInAtlas = "get_tile_size_in_atlas";
        /// <summary>
        /// Cached name for the 'has_room_for_tile' method.
        /// </summary>
        public static readonly StringName HasRoomForTile = "has_room_for_tile";
        /// <summary>
        /// Cached name for the 'get_tiles_to_be_removed_on_change' method.
        /// </summary>
        public static readonly StringName GetTilesToBeRemovedOnChange = "get_tiles_to_be_removed_on_change";
        /// <summary>
        /// Cached name for the 'get_tile_at_coords' method.
        /// </summary>
        public static readonly StringName GetTileAtCoords = "get_tile_at_coords";
        /// <summary>
        /// Cached name for the 'has_tiles_outside_texture' method.
        /// </summary>
        public static readonly StringName HasTilesOutsideTexture = "has_tiles_outside_texture";
        /// <summary>
        /// Cached name for the 'clear_tiles_outside_texture' method.
        /// </summary>
        public static readonly StringName ClearTilesOutsideTexture = "clear_tiles_outside_texture";
        /// <summary>
        /// Cached name for the 'set_tile_animation_columns' method.
        /// </summary>
        public static readonly StringName SetTileAnimationColumns = "set_tile_animation_columns";
        /// <summary>
        /// Cached name for the 'get_tile_animation_columns' method.
        /// </summary>
        public static readonly StringName GetTileAnimationColumns = "get_tile_animation_columns";
        /// <summary>
        /// Cached name for the 'set_tile_animation_separation' method.
        /// </summary>
        public static readonly StringName SetTileAnimationSeparation = "set_tile_animation_separation";
        /// <summary>
        /// Cached name for the 'get_tile_animation_separation' method.
        /// </summary>
        public static readonly StringName GetTileAnimationSeparation = "get_tile_animation_separation";
        /// <summary>
        /// Cached name for the 'set_tile_animation_speed' method.
        /// </summary>
        public static readonly StringName SetTileAnimationSpeed = "set_tile_animation_speed";
        /// <summary>
        /// Cached name for the 'get_tile_animation_speed' method.
        /// </summary>
        public static readonly StringName GetTileAnimationSpeed = "get_tile_animation_speed";
        /// <summary>
        /// Cached name for the 'set_tile_animation_mode' method.
        /// </summary>
        public static readonly StringName SetTileAnimationMode = "set_tile_animation_mode";
        /// <summary>
        /// Cached name for the 'get_tile_animation_mode' method.
        /// </summary>
        public static readonly StringName GetTileAnimationMode = "get_tile_animation_mode";
        /// <summary>
        /// Cached name for the 'set_tile_animation_frames_count' method.
        /// </summary>
        public static readonly StringName SetTileAnimationFramesCount = "set_tile_animation_frames_count";
        /// <summary>
        /// Cached name for the 'get_tile_animation_frames_count' method.
        /// </summary>
        public static readonly StringName GetTileAnimationFramesCount = "get_tile_animation_frames_count";
        /// <summary>
        /// Cached name for the 'set_tile_animation_frame_duration' method.
        /// </summary>
        public static readonly StringName SetTileAnimationFrameDuration = "set_tile_animation_frame_duration";
        /// <summary>
        /// Cached name for the 'get_tile_animation_frame_duration' method.
        /// </summary>
        public static readonly StringName GetTileAnimationFrameDuration = "get_tile_animation_frame_duration";
        /// <summary>
        /// Cached name for the 'get_tile_animation_total_duration' method.
        /// </summary>
        public static readonly StringName GetTileAnimationTotalDuration = "get_tile_animation_total_duration";
        /// <summary>
        /// Cached name for the 'create_alternative_tile' method.
        /// </summary>
        public static readonly StringName CreateAlternativeTile = "create_alternative_tile";
        /// <summary>
        /// Cached name for the 'remove_alternative_tile' method.
        /// </summary>
        public static readonly StringName RemoveAlternativeTile = "remove_alternative_tile";
        /// <summary>
        /// Cached name for the 'set_alternative_tile_id' method.
        /// </summary>
        public static readonly StringName SetAlternativeTileId = "set_alternative_tile_id";
        /// <summary>
        /// Cached name for the 'get_next_alternative_tile_id' method.
        /// </summary>
        public static readonly StringName GetNextAlternativeTileId = "get_next_alternative_tile_id";
        /// <summary>
        /// Cached name for the 'get_tile_data' method.
        /// </summary>
        public static readonly StringName GetTileData = "get_tile_data";
        /// <summary>
        /// Cached name for the 'get_atlas_grid_size' method.
        /// </summary>
        public static readonly StringName GetAtlasGridSize = "get_atlas_grid_size";
        /// <summary>
        /// Cached name for the 'get_tile_texture_region' method.
        /// </summary>
        public static readonly StringName GetTileTextureRegion = "get_tile_texture_region";
        /// <summary>
        /// Cached name for the 'get_runtime_texture' method.
        /// </summary>
        public static readonly StringName GetRuntimeTexture = "get_runtime_texture";
        /// <summary>
        /// Cached name for the 'get_runtime_tile_texture_region' method.
        /// </summary>
        public static readonly StringName GetRuntimeTileTextureRegion = "get_runtime_tile_texture_region";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : TileSetSource.SignalName
    {
    }
}
