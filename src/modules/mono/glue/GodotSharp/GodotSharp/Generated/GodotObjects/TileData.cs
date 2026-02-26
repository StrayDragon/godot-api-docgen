namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para><see cref="Godot.TileData"/> object represents a single tile in a <see cref="Godot.TileSet"/>. It is usually edited using the tileset editor, but it can be modified at runtime using <see cref="Godot.TileMapLayer._TileDataRuntimeUpdate(Vector2I, TileData)"/>.</para>
/// </summary>
public partial class TileData : GodotObject
{
    /// <summary>
    /// <para>If <see langword="true"/>, the tile will have its texture flipped horizontally.</para>
    /// </summary>
    public bool FlipH
    {
        get
        {
            return GetFlipH();
        }
        set
        {
            SetFlipH(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the tile will have its texture flipped vertically.</para>
    /// </summary>
    public bool FlipV
    {
        get
        {
            return GetFlipV();
        }
        set
        {
            SetFlipV(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the tile will display transposed, i.e. with horizontal and vertical texture UVs swapped.</para>
    /// </summary>
    public bool Transpose
    {
        get
        {
            return GetTranspose();
        }
        set
        {
            SetTranspose(value);
        }
    }

    /// <summary>
    /// <para>Offsets the position of where the tile is drawn.</para>
    /// </summary>
    public Vector2I TextureOrigin
    {
        get
        {
            return GetTextureOrigin();
        }
        set
        {
            SetTextureOrigin(value);
        }
    }

    /// <summary>
    /// <para>Color modulation of the tile.</para>
    /// </summary>
    public Color Modulate
    {
        get
        {
            return GetModulate();
        }
        set
        {
            SetModulate(value);
        }
    }

    /// <summary>
    /// <para>The <see cref="Godot.Material"/> to use for this <see cref="Godot.TileData"/>. This can be a <see cref="Godot.CanvasItemMaterial"/> to use the default shader, or a <see cref="Godot.ShaderMaterial"/> to use a custom shader.</para>
    /// </summary>
    public Material Material
    {
        get
        {
            return GetMaterial();
        }
        set
        {
            SetMaterial(value);
        }
    }

    /// <summary>
    /// <para>Ordering index of this tile, relative to <see cref="Godot.TileMapLayer"/>.</para>
    /// </summary>
    public int ZIndex
    {
        get
        {
            return GetZIndex();
        }
        set
        {
            SetZIndex(value);
        }
    }

    /// <summary>
    /// <para>Vertical point of the tile used for determining y-sorted order.</para>
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
    /// <para>ID of the terrain set that the tile uses.</para>
    /// </summary>
    public int TerrainSet
    {
        get
        {
            return GetTerrainSet();
        }
        set
        {
            SetTerrainSet(value);
        }
    }

    /// <summary>
    /// <para>ID of the terrain from the terrain set that the tile uses.</para>
    /// </summary>
    public int Terrain
    {
        get
        {
            return GetTerrain();
        }
        set
        {
            SetTerrain(value);
        }
    }

    /// <summary>
    /// <para>Relative probability of this tile being selected when drawing a pattern of random tiles.</para>
    /// </summary>
    public float Probability
    {
        get
        {
            return GetProbability();
        }
        set
        {
            SetProbability(value);
        }
    }

    private static readonly System.Type CachedType = typeof(TileData);

    private static readonly StringName NativeName = "TileData";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public TileData() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal TileData(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal TileData(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFlipH, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFlipH(bool flipH)
    {
        NativeCalls.godot_icall_1_14(MethodBind0, GodotObject.GetPtr(this), flipH.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFlipH, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetFlipH()
    {
        return NativeCalls.godot_icall_0_15(MethodBind1, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFlipV, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFlipV(bool flipV)
    {
        NativeCalls.godot_icall_1_14(MethodBind2, GodotObject.GetPtr(this), flipV.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFlipV, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetFlipV()
    {
        return NativeCalls.godot_icall_0_15(MethodBind3, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTranspose, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTranspose(bool transpose)
    {
        NativeCalls.godot_icall_1_14(MethodBind4, GodotObject.GetPtr(this), transpose.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTranspose, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetTranspose()
    {
        return NativeCalls.godot_icall_0_15(MethodBind5, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMaterial, 2757459619ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMaterial(Material material)
    {
        NativeCalls.godot_icall_1_56(MethodBind6, GodotObject.GetPtr(this), GodotObject.GetPtr(material));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMaterial, 5934680ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Material GetMaterial()
    {
        return (Material)NativeCalls.godot_icall_0_63(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTextureOrigin, 1130785943ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetTextureOrigin(Vector2I textureOrigin)
    {
        NativeCalls.godot_icall_1_34(MethodBind8, GodotObject.GetPtr(this), &textureOrigin);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTextureOrigin, 3690982128ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2I GetTextureOrigin()
    {
        return NativeCalls.godot_icall_0_35(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetModulate, 2920490490ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetModulate(Color modulate)
    {
        NativeCalls.godot_icall_1_213(MethodBind10, GodotObject.GetPtr(this), &modulate);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetModulate, 3444240500ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Color GetModulate()
    {
        return NativeCalls.godot_icall_0_214(MethodBind11, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetZIndex, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetZIndex(int zIndex)
    {
        NativeCalls.godot_icall_1_38(MethodBind12, GodotObject.GetPtr(this), zIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetZIndex, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetZIndex()
    {
        return NativeCalls.godot_icall_0_39(MethodBind13, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetYSortOrigin, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetYSortOrigin(int ySortOrigin)
    {
        NativeCalls.godot_icall_1_38(MethodBind14, GodotObject.GetPtr(this), ySortOrigin);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetYSortOrigin, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetYSortOrigin()
    {
        return NativeCalls.godot_icall_0_39(MethodBind15, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetOccluderPolygonsCount, 3937882851ul);

    /// <summary>
    /// <para>Sets the occluder polygon count in the TileSet occlusion layer with index <paramref name="layerId"/>.</para>
    /// </summary>
    public void SetOccluderPolygonsCount(int layerId, int polygonsCount)
    {
        NativeCalls.godot_icall_2_59(MethodBind16, GodotObject.GetPtr(this), layerId, polygonsCount);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOccluderPolygonsCount, 923996154ul);

    /// <summary>
    /// <para>Returns the number of occluder polygons of the tile in the TileSet occlusion layer with index <paramref name="layerId"/>.</para>
    /// </summary>
    public int GetOccluderPolygonsCount(int layerId)
    {
        return NativeCalls.godot_icall_1_60(MethodBind17, GodotObject.GetPtr(this), layerId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddOccluderPolygon, 1286410249ul);

    /// <summary>
    /// <para>Adds an occlusion polygon to the tile on the TileSet occlusion layer with index <paramref name="layerId"/>.</para>
    /// </summary>
    public void AddOccluderPolygon(int layerId)
    {
        NativeCalls.godot_icall_1_38(MethodBind18, GodotObject.GetPtr(this), layerId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveOccluderPolygon, 3937882851ul);

    /// <summary>
    /// <para>Removes the polygon at index <paramref name="polygonIndex"/> for TileSet occlusion layer with index <paramref name="layerId"/>.</para>
    /// </summary>
    public void RemoveOccluderPolygon(int layerId, int polygonIndex)
    {
        NativeCalls.godot_icall_2_59(MethodBind19, GodotObject.GetPtr(this), layerId, polygonIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetOccluderPolygon, 164249167ul);

    /// <summary>
    /// <para>Sets the occluder for polygon with index <paramref name="polygonIndex"/> in the TileSet occlusion layer with index <paramref name="layerId"/>.</para>
    /// </summary>
    public void SetOccluderPolygon(int layerId, int polygonIndex, OccluderPolygon2D polygon)
    {
        NativeCalls.godot_icall_3_100(MethodBind20, GodotObject.GetPtr(this), layerId, polygonIndex, GodotObject.GetPtr(polygon));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOccluderPolygon, 971166743ul);

    /// <summary>
    /// <para>Returns the occluder polygon at index <paramref name="polygonIndex"/> from the TileSet occlusion layer with index <paramref name="layerId"/>.</para>
    /// <para>The <paramref name="flipH"/>, <paramref name="flipV"/>, and <paramref name="transpose"/> parameters can be <see langword="true"/> to transform the returned polygon.</para>
    /// </summary>
    public OccluderPolygon2D GetOccluderPolygon(int layerId, int polygonIndex, bool flipH = false, bool flipV = false, bool transpose = false)
    {
        return (OccluderPolygon2D)NativeCalls.godot_icall_5_902(MethodBind21, GodotObject.GetPtr(this), layerId, polygonIndex, flipH.ToGodotBool(), flipV.ToGodotBool(), transpose.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetOccluder, 914399637ul);

    /// <summary>
    /// <para>Sets the occluder for the TileSet occlusion layer with index <paramref name="layerId"/>.</para>
    /// </summary>
    [Obsolete("Use 'Godot.TileData.SetOccluderPolygon(int, int, OccluderPolygon2D)' instead.")]
    public void SetOccluder(int layerId, OccluderPolygon2D occluderPolygon)
    {
        NativeCalls.godot_icall_2_70(MethodBind22, GodotObject.GetPtr(this), layerId, GodotObject.GetPtr(occluderPolygon));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOccluder, 2377324099ul);

    /// <summary>
    /// <para>Returns the occluder polygon of the tile for the TileSet occlusion layer with index <paramref name="layerId"/>.</para>
    /// <para><paramref name="flipH"/>, <paramref name="flipV"/>, and <paramref name="transpose"/> allow transforming the returned polygon.</para>
    /// </summary>
    [Obsolete("Use 'Godot.TileData.GetOccluderPolygon(int, int, bool, bool, bool)' instead.")]
    public OccluderPolygon2D GetOccluder(int layerId, bool flipH = false, bool flipV = false, bool transpose = false)
    {
        return (OccluderPolygon2D)NativeCalls.godot_icall_4_1421(MethodBind23, GodotObject.GetPtr(this), layerId, flipH.ToGodotBool(), flipV.ToGodotBool(), transpose.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetConstantLinearVelocity, 163021252ul);

    /// <summary>
    /// <para>Sets the constant linear velocity. This does not move the tile. This linear velocity is applied to objects colliding with this tile. This is useful to create conveyor belts.</para>
    /// </summary>
    public unsafe void SetConstantLinearVelocity(int layerId, Vector2 velocity)
    {
        NativeCalls.godot_icall_2_147(MethodBind24, GodotObject.GetPtr(this), layerId, &velocity);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetConstantLinearVelocity, 2299179447ul);

    /// <summary>
    /// <para>Returns the constant linear velocity applied to objects colliding with this tile.</para>
    /// </summary>
    public Vector2 GetConstantLinearVelocity(int layerId)
    {
        return NativeCalls.godot_icall_1_148(MethodBind25, GodotObject.GetPtr(this), layerId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetConstantAngularVelocity, 1602489585ul);

    /// <summary>
    /// <para>Sets the constant angular velocity. This does not rotate the tile. This angular velocity is applied to objects colliding with this tile.</para>
    /// </summary>
    public void SetConstantAngularVelocity(int layerId, float velocity)
    {
        NativeCalls.godot_icall_2_69(MethodBind26, GodotObject.GetPtr(this), layerId, velocity);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetConstantAngularVelocity, 2339986948ul);

    /// <summary>
    /// <para>Returns the constant angular velocity applied to objects colliding with this tile.</para>
    /// </summary>
    public float GetConstantAngularVelocity(int layerId)
    {
        return NativeCalls.godot_icall_1_72(MethodBind27, GodotObject.GetPtr(this), layerId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCollisionPolygonsCount, 3937882851ul);

    /// <summary>
    /// <para>Sets the polygons count for TileSet physics layer with index <paramref name="layerId"/>.</para>
    /// </summary>
    public void SetCollisionPolygonsCount(int layerId, int polygonsCount)
    {
        NativeCalls.godot_icall_2_59(MethodBind28, GodotObject.GetPtr(this), layerId, polygonsCount);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCollisionPolygonsCount, 923996154ul);

    /// <summary>
    /// <para>Returns how many polygons the tile has for TileSet physics layer with index <paramref name="layerId"/>.</para>
    /// </summary>
    public int GetCollisionPolygonsCount(int layerId)
    {
        return NativeCalls.godot_icall_1_60(MethodBind29, GodotObject.GetPtr(this), layerId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddCollisionPolygon, 1286410249ul);

    /// <summary>
    /// <para>Adds a collision polygon to the tile on the given TileSet physics layer.</para>
    /// </summary>
    public void AddCollisionPolygon(int layerId)
    {
        NativeCalls.godot_icall_1_38(MethodBind30, GodotObject.GetPtr(this), layerId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveCollisionPolygon, 3937882851ul);

    /// <summary>
    /// <para>Removes the polygon at index <paramref name="polygonIndex"/> for TileSet physics layer with index <paramref name="layerId"/>.</para>
    /// </summary>
    public void RemoveCollisionPolygon(int layerId, int polygonIndex)
    {
        NativeCalls.godot_icall_2_59(MethodBind31, GodotObject.GetPtr(this), layerId, polygonIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind32 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCollisionPolygonPoints, 3230546541ul);

    /// <summary>
    /// <para>Sets the points of the polygon at index <paramref name="polygonIndex"/> for TileSet physics layer with index <paramref name="layerId"/>.</para>
    /// </summary>
    public void SetCollisionPolygonPoints(int layerId, int polygonIndex, Vector2[] polygon)
    {
        NativeCalls.godot_icall_3_1422(MethodBind32, GodotObject.GetPtr(this), layerId, polygonIndex, polygon);
    }

    /// <summary>
    /// <para>Sets the points of the polygon at index <paramref name="polygonIndex"/> for TileSet physics layer with index <paramref name="layerId"/>.</para>
    /// </summary>
    public void SetCollisionPolygonPoints(int layerId, int polygonIndex, ReadOnlySpan<Vector2> polygon)
    {
        NativeCalls.godot_icall_3_1422(MethodBind32, GodotObject.GetPtr(this), layerId, polygonIndex, polygon);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind33 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCollisionPolygonPoints, 103942801ul);

    /// <summary>
    /// <para>Returns the points of the polygon at index <paramref name="polygonIndex"/> for TileSet physics layer with index <paramref name="layerId"/>.</para>
    /// </summary>
    public Vector2[] GetCollisionPolygonPoints(int layerId, int polygonIndex)
    {
        return NativeCalls.godot_icall_2_1423(MethodBind33, GodotObject.GetPtr(this), layerId, polygonIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind34 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCollisionPolygonOneWay, 1383440665ul);

    /// <summary>
    /// <para>Enables/disables one-way collisions on the polygon at index <paramref name="polygonIndex"/> for TileSet physics layer with index <paramref name="layerId"/>.</para>
    /// </summary>
    public void SetCollisionPolygonOneWay(int layerId, int polygonIndex, bool oneWay)
    {
        NativeCalls.godot_icall_3_197(MethodBind34, GodotObject.GetPtr(this), layerId, polygonIndex, oneWay.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind35 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsCollisionPolygonOneWay, 2522259332ul);

    /// <summary>
    /// <para>Returns whether one-way collisions are enabled for the polygon at index <paramref name="polygonIndex"/> for TileSet physics layer with index <paramref name="layerId"/>.</para>
    /// </summary>
    public bool IsCollisionPolygonOneWay(int layerId, int polygonIndex)
    {
        return NativeCalls.godot_icall_2_40(MethodBind35, GodotObject.GetPtr(this), layerId, polygonIndex).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind36 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCollisionPolygonOneWayMargin, 3506521499ul);

    /// <summary>
    /// <para>Sets the one-way margin (for one-way platforms) of the polygon at index <paramref name="polygonIndex"/> for TileSet physics layer with index <paramref name="layerId"/>.</para>
    /// </summary>
    public void SetCollisionPolygonOneWayMargin(int layerId, int polygonIndex, float oneWayMargin)
    {
        NativeCalls.godot_icall_3_86(MethodBind36, GodotObject.GetPtr(this), layerId, polygonIndex, oneWayMargin);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind37 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCollisionPolygonOneWayMargin, 3085491603ul);

    /// <summary>
    /// <para>Returns the one-way margin (for one-way platforms) of the polygon at index <paramref name="polygonIndex"/> for TileSet physics layer with index <paramref name="layerId"/>.</para>
    /// </summary>
    public float GetCollisionPolygonOneWayMargin(int layerId, int polygonIndex)
    {
        return NativeCalls.godot_icall_2_88(MethodBind37, GodotObject.GetPtr(this), layerId, polygonIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind38 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTerrainSet, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTerrainSet(int terrainSet)
    {
        NativeCalls.godot_icall_1_38(MethodBind38, GodotObject.GetPtr(this), terrainSet);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind39 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTerrainSet, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetTerrainSet()
    {
        return NativeCalls.godot_icall_0_39(MethodBind39, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind40 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTerrain, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTerrain(int terrain)
    {
        NativeCalls.godot_icall_1_38(MethodBind40, GodotObject.GetPtr(this), terrain);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind41 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTerrain, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetTerrain()
    {
        return NativeCalls.godot_icall_0_39(MethodBind41, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind42 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTerrainPeeringBit, 1084452308ul);

    /// <summary>
    /// <para>Sets the tile's terrain bit for the given <paramref name="peeringBit"/> direction. To check that a direction is valid, use <see cref="Godot.TileData.IsValidTerrainPeeringBit(TileSet.CellNeighbor)"/>.</para>
    /// </summary>
    public void SetTerrainPeeringBit(TileSet.CellNeighbor peeringBit, int terrain)
    {
        NativeCalls.godot_icall_2_59(MethodBind42, GodotObject.GetPtr(this), (int)peeringBit, terrain);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind43 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTerrainPeeringBit, 3831796792ul);

    /// <summary>
    /// <para>Returns the tile's terrain bit for the given <paramref name="peeringBit"/> direction. To check that a direction is valid, use <see cref="Godot.TileData.IsValidTerrainPeeringBit(TileSet.CellNeighbor)"/>.</para>
    /// </summary>
    public int GetTerrainPeeringBit(TileSet.CellNeighbor peeringBit)
    {
        return NativeCalls.godot_icall_1_60(MethodBind43, GodotObject.GetPtr(this), (int)peeringBit);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind44 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsValidTerrainPeeringBit, 845723972ul);

    /// <summary>
    /// <para>Returns whether the given <paramref name="peeringBit"/> direction is valid for this tile.</para>
    /// </summary>
    public bool IsValidTerrainPeeringBit(TileSet.CellNeighbor peeringBit)
    {
        return NativeCalls.godot_icall_1_62(MethodBind44, GodotObject.GetPtr(this), (int)peeringBit).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind45 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetNavigationPolygon, 2224691167ul);

    /// <summary>
    /// <para>Sets the navigation polygon for the TileSet navigation layer with index <paramref name="layerId"/>.</para>
    /// </summary>
    public void SetNavigationPolygon(int layerId, NavigationPolygon navigationPolygon)
    {
        NativeCalls.godot_icall_2_70(MethodBind45, GodotObject.GetPtr(this), layerId, GodotObject.GetPtr(navigationPolygon));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind46 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNavigationPolygon, 2907127272ul);

    /// <summary>
    /// <para>Returns the navigation polygon of the tile for the TileSet navigation layer with index <paramref name="layerId"/>.</para>
    /// <para><paramref name="flipH"/>, <paramref name="flipV"/>, and <paramref name="transpose"/> allow transforming the returned polygon.</para>
    /// </summary>
    public NavigationPolygon GetNavigationPolygon(int layerId, bool flipH = false, bool flipV = false, bool transpose = false)
    {
        return (NavigationPolygon)NativeCalls.godot_icall_4_1421(MethodBind46, GodotObject.GetPtr(this), layerId, flipH.ToGodotBool(), flipV.ToGodotBool(), transpose.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind47 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetProbability, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetProbability(float probability)
    {
        NativeCalls.godot_icall_1_67(MethodBind47, GodotObject.GetPtr(this), probability);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind48 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetProbability, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetProbability()
    {
        return NativeCalls.godot_icall_0_68(MethodBind48, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind49 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCustomData, 402577236ul);

    /// <summary>
    /// <para>Sets the tile's custom data value for the TileSet custom data layer with name <paramref name="layerName"/>.</para>
    /// </summary>
    public void SetCustomData(string layerName, Variant value)
    {
        NativeCalls.godot_icall_2_528(MethodBind49, GodotObject.GetPtr(this), layerName, value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind50 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCustomData, 1868160156ul);

    /// <summary>
    /// <para>Returns the custom data value for custom data layer named <paramref name="layerName"/>. To check if a custom data layer exists, use <see cref="Godot.TileData.HasCustomData(string)"/>.</para>
    /// </summary>
    public Variant GetCustomData(string layerName)
    {
        return NativeCalls.godot_icall_1_530(MethodBind50, GodotObject.GetPtr(this), layerName);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind51 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasCustomData, 3927539163ul);

    /// <summary>
    /// <para>Returns whether there exists a custom data layer named <paramref name="layerName"/>.</para>
    /// </summary>
    public bool HasCustomData(string layerName)
    {
        return NativeCalls.godot_icall_1_131(MethodBind51, GodotObject.GetPtr(this), layerName).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind52 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCustomDataByLayerId, 2152698145ul);

    /// <summary>
    /// <para>Sets the tile's custom data value for the TileSet custom data layer with index <paramref name="layerId"/>.</para>
    /// </summary>
    public void SetCustomDataByLayerId(int layerId, Variant value)
    {
        NativeCalls.godot_icall_2_701(MethodBind52, GodotObject.GetPtr(this), layerId, value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind53 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCustomDataByLayerId, 4227898402ul);

    /// <summary>
    /// <para>Returns the custom data value for custom data layer with index <paramref name="layerId"/>.</para>
    /// </summary>
    public Variant GetCustomDataByLayerId(int layerId)
    {
        return NativeCalls.godot_icall_1_702(MethodBind53, GodotObject.GetPtr(this), layerId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind54 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOccluder, 2458574231ul);

    /// <summary>
    /// <para>Returns the occluder polygon of the tile for the TileSet occlusion layer with index <paramref name="layerId"/>.</para>
    /// <para><paramref name="flipH"/>, <paramref name="flipV"/>, and <paramref name="transpose"/> allow transforming the returned polygon.</para>
    /// </summary>
    [Obsolete("Use 'Godot.TileData.GetOccluderPolygon(int, int, bool, bool, bool)' instead.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public OccluderPolygon2D GetOccluder(int _UnnamedArg0)
    {
        return (OccluderPolygon2D)NativeCalls.godot_icall_1_71(MethodBind54, GodotObject.GetPtr(this), _UnnamedArg0);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind55 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNavigationPolygon, 3991786031ul);

    /// <summary>
    /// <para>Returns the navigation polygon of the tile for the TileSet navigation layer with index <paramref name="layerId"/>.</para>
    /// <para><paramref name="flipH"/>, <paramref name="flipV"/>, and <paramref name="transpose"/> allow transforming the returned polygon.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public NavigationPolygon GetNavigationPolygon(int _UnnamedArg0)
    {
        return (NavigationPolygon)NativeCalls.godot_icall_1_71(MethodBind55, GodotObject.GetPtr(this), _UnnamedArg0);
    }

    /// <summary>
    /// <para>Emitted when any of the properties are changed.</para>
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
    public new class PropertyName : GodotObject.PropertyName
    {
        /// <summary>
        /// Cached name for the 'flip_h' property.
        /// </summary>
        public static readonly StringName FlipH = "flip_h";
        /// <summary>
        /// Cached name for the 'flip_v' property.
        /// </summary>
        public static readonly StringName FlipV = "flip_v";
        /// <summary>
        /// Cached name for the 'transpose' property.
        /// </summary>
        public static readonly StringName Transpose = "transpose";
        /// <summary>
        /// Cached name for the 'texture_origin' property.
        /// </summary>
        public static readonly StringName TextureOrigin = "texture_origin";
        /// <summary>
        /// Cached name for the 'modulate' property.
        /// </summary>
        public static readonly StringName Modulate = "modulate";
        /// <summary>
        /// Cached name for the 'material' property.
        /// </summary>
        public static readonly StringName Material = "material";
        /// <summary>
        /// Cached name for the 'z_index' property.
        /// </summary>
        public static readonly StringName ZIndex = "z_index";
        /// <summary>
        /// Cached name for the 'y_sort_origin' property.
        /// </summary>
        public static readonly StringName YSortOrigin = "y_sort_origin";
        /// <summary>
        /// Cached name for the 'terrain_set' property.
        /// </summary>
        public static readonly StringName TerrainSet = "terrain_set";
        /// <summary>
        /// Cached name for the 'terrain' property.
        /// </summary>
        public static readonly StringName Terrain = "terrain";
        /// <summary>
        /// Cached name for the 'probability' property.
        /// </summary>
        public static readonly StringName Probability = "probability";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : GodotObject.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_flip_h' method.
        /// </summary>
        public static readonly StringName SetFlipH = "set_flip_h";
        /// <summary>
        /// Cached name for the 'get_flip_h' method.
        /// </summary>
        public static readonly StringName GetFlipH = "get_flip_h";
        /// <summary>
        /// Cached name for the 'set_flip_v' method.
        /// </summary>
        public static readonly StringName SetFlipV = "set_flip_v";
        /// <summary>
        /// Cached name for the 'get_flip_v' method.
        /// </summary>
        public static readonly StringName GetFlipV = "get_flip_v";
        /// <summary>
        /// Cached name for the 'set_transpose' method.
        /// </summary>
        public static readonly StringName SetTranspose = "set_transpose";
        /// <summary>
        /// Cached name for the 'get_transpose' method.
        /// </summary>
        public static readonly StringName GetTranspose = "get_transpose";
        /// <summary>
        /// Cached name for the 'set_material' method.
        /// </summary>
        public static readonly StringName SetMaterial = "set_material";
        /// <summary>
        /// Cached name for the 'get_material' method.
        /// </summary>
        public static readonly StringName GetMaterial = "get_material";
        /// <summary>
        /// Cached name for the 'set_texture_origin' method.
        /// </summary>
        public static readonly StringName SetTextureOrigin = "set_texture_origin";
        /// <summary>
        /// Cached name for the 'get_texture_origin' method.
        /// </summary>
        public static readonly StringName GetTextureOrigin = "get_texture_origin";
        /// <summary>
        /// Cached name for the 'set_modulate' method.
        /// </summary>
        public static readonly StringName SetModulate = "set_modulate";
        /// <summary>
        /// Cached name for the 'get_modulate' method.
        /// </summary>
        public static readonly StringName GetModulate = "get_modulate";
        /// <summary>
        /// Cached name for the 'set_z_index' method.
        /// </summary>
        public static readonly StringName SetZIndex = "set_z_index";
        /// <summary>
        /// Cached name for the 'get_z_index' method.
        /// </summary>
        public static readonly StringName GetZIndex = "get_z_index";
        /// <summary>
        /// Cached name for the 'set_y_sort_origin' method.
        /// </summary>
        public static readonly StringName SetYSortOrigin = "set_y_sort_origin";
        /// <summary>
        /// Cached name for the 'get_y_sort_origin' method.
        /// </summary>
        public static readonly StringName GetYSortOrigin = "get_y_sort_origin";
        /// <summary>
        /// Cached name for the 'set_occluder_polygons_count' method.
        /// </summary>
        public static readonly StringName SetOccluderPolygonsCount = "set_occluder_polygons_count";
        /// <summary>
        /// Cached name for the 'get_occluder_polygons_count' method.
        /// </summary>
        public static readonly StringName GetOccluderPolygonsCount = "get_occluder_polygons_count";
        /// <summary>
        /// Cached name for the 'add_occluder_polygon' method.
        /// </summary>
        public static readonly StringName AddOccluderPolygon = "add_occluder_polygon";
        /// <summary>
        /// Cached name for the 'remove_occluder_polygon' method.
        /// </summary>
        public static readonly StringName RemoveOccluderPolygon = "remove_occluder_polygon";
        /// <summary>
        /// Cached name for the 'set_occluder_polygon' method.
        /// </summary>
        public static readonly StringName SetOccluderPolygon = "set_occluder_polygon";
        /// <summary>
        /// Cached name for the 'get_occluder_polygon' method.
        /// </summary>
        public static readonly StringName GetOccluderPolygon = "get_occluder_polygon";
        /// <summary>
        /// Cached name for the 'set_occluder' method.
        /// </summary>
        public static readonly StringName SetOccluder = "set_occluder";
        /// <summary>
        /// Cached name for the 'get_occluder' method.
        /// </summary>
        public static readonly StringName GetOccluder = "get_occluder";
        /// <summary>
        /// Cached name for the 'set_constant_linear_velocity' method.
        /// </summary>
        public static readonly StringName SetConstantLinearVelocity = "set_constant_linear_velocity";
        /// <summary>
        /// Cached name for the 'get_constant_linear_velocity' method.
        /// </summary>
        public static readonly StringName GetConstantLinearVelocity = "get_constant_linear_velocity";
        /// <summary>
        /// Cached name for the 'set_constant_angular_velocity' method.
        /// </summary>
        public static readonly StringName SetConstantAngularVelocity = "set_constant_angular_velocity";
        /// <summary>
        /// Cached name for the 'get_constant_angular_velocity' method.
        /// </summary>
        public static readonly StringName GetConstantAngularVelocity = "get_constant_angular_velocity";
        /// <summary>
        /// Cached name for the 'set_collision_polygons_count' method.
        /// </summary>
        public static readonly StringName SetCollisionPolygonsCount = "set_collision_polygons_count";
        /// <summary>
        /// Cached name for the 'get_collision_polygons_count' method.
        /// </summary>
        public static readonly StringName GetCollisionPolygonsCount = "get_collision_polygons_count";
        /// <summary>
        /// Cached name for the 'add_collision_polygon' method.
        /// </summary>
        public static readonly StringName AddCollisionPolygon = "add_collision_polygon";
        /// <summary>
        /// Cached name for the 'remove_collision_polygon' method.
        /// </summary>
        public static readonly StringName RemoveCollisionPolygon = "remove_collision_polygon";
        /// <summary>
        /// Cached name for the 'set_collision_polygon_points' method.
        /// </summary>
        public static readonly StringName SetCollisionPolygonPoints = "set_collision_polygon_points";
        /// <summary>
        /// Cached name for the 'get_collision_polygon_points' method.
        /// </summary>
        public static readonly StringName GetCollisionPolygonPoints = "get_collision_polygon_points";
        /// <summary>
        /// Cached name for the 'set_collision_polygon_one_way' method.
        /// </summary>
        public static readonly StringName SetCollisionPolygonOneWay = "set_collision_polygon_one_way";
        /// <summary>
        /// Cached name for the 'is_collision_polygon_one_way' method.
        /// </summary>
        public static readonly StringName IsCollisionPolygonOneWay = "is_collision_polygon_one_way";
        /// <summary>
        /// Cached name for the 'set_collision_polygon_one_way_margin' method.
        /// </summary>
        public static readonly StringName SetCollisionPolygonOneWayMargin = "set_collision_polygon_one_way_margin";
        /// <summary>
        /// Cached name for the 'get_collision_polygon_one_way_margin' method.
        /// </summary>
        public static readonly StringName GetCollisionPolygonOneWayMargin = "get_collision_polygon_one_way_margin";
        /// <summary>
        /// Cached name for the 'set_terrain_set' method.
        /// </summary>
        public static readonly StringName SetTerrainSet = "set_terrain_set";
        /// <summary>
        /// Cached name for the 'get_terrain_set' method.
        /// </summary>
        public static readonly StringName GetTerrainSet = "get_terrain_set";
        /// <summary>
        /// Cached name for the 'set_terrain' method.
        /// </summary>
        public static readonly StringName SetTerrain = "set_terrain";
        /// <summary>
        /// Cached name for the 'get_terrain' method.
        /// </summary>
        public static readonly StringName GetTerrain = "get_terrain";
        /// <summary>
        /// Cached name for the 'set_terrain_peering_bit' method.
        /// </summary>
        public static readonly StringName SetTerrainPeeringBit = "set_terrain_peering_bit";
        /// <summary>
        /// Cached name for the 'get_terrain_peering_bit' method.
        /// </summary>
        public static readonly StringName GetTerrainPeeringBit = "get_terrain_peering_bit";
        /// <summary>
        /// Cached name for the 'is_valid_terrain_peering_bit' method.
        /// </summary>
        public static readonly StringName IsValidTerrainPeeringBit = "is_valid_terrain_peering_bit";
        /// <summary>
        /// Cached name for the 'set_navigation_polygon' method.
        /// </summary>
        public static readonly StringName SetNavigationPolygon = "set_navigation_polygon";
        /// <summary>
        /// Cached name for the 'get_navigation_polygon' method.
        /// </summary>
        public static readonly StringName GetNavigationPolygon = "get_navigation_polygon";
        /// <summary>
        /// Cached name for the 'set_probability' method.
        /// </summary>
        public static readonly StringName SetProbability = "set_probability";
        /// <summary>
        /// Cached name for the 'get_probability' method.
        /// </summary>
        public static readonly StringName GetProbability = "get_probability";
        /// <summary>
        /// Cached name for the 'set_custom_data' method.
        /// </summary>
        public static readonly StringName SetCustomData = "set_custom_data";
        /// <summary>
        /// Cached name for the 'get_custom_data' method.
        /// </summary>
        public static readonly StringName GetCustomData = "get_custom_data";
        /// <summary>
        /// Cached name for the 'has_custom_data' method.
        /// </summary>
        public static readonly StringName HasCustomData = "has_custom_data";
        /// <summary>
        /// Cached name for the 'set_custom_data_by_layer_id' method.
        /// </summary>
        public static readonly StringName SetCustomDataByLayerId = "set_custom_data_by_layer_id";
        /// <summary>
        /// Cached name for the 'get_custom_data_by_layer_id' method.
        /// </summary>
        public static readonly StringName GetCustomDataByLayerId = "get_custom_data_by_layer_id";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : GodotObject.SignalName
    {
        /// <summary>
        /// Cached name for the 'changed' signal.
        /// </summary>
        public static readonly StringName Changed = "changed";
    }
}
