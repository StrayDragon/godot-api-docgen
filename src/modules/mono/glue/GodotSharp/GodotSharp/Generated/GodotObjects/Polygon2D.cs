namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A Polygon2D is defined by a set of points. Each point is connected to the next, with the final point being connected to the first, resulting in a closed polygon. Polygon2Ds can be filled with color (solid or gradient) or filled with a given texture.</para>
/// </summary>
public partial class Polygon2D : Node2D
{
    /// <summary>
    /// <para>The polygon's fill color. If <see cref="Godot.Polygon2D.Texture"/> is set, it will be multiplied by this color. It will also be the default color for vertices not set in <see cref="Godot.Polygon2D.VertexColors"/>.</para>
    /// </summary>
    public Color Color
    {
        get
        {
            return GetColor();
        }
        set
        {
            SetColor(value);
        }
    }

    /// <summary>
    /// <para>The offset applied to each vertex.</para>
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
    /// <para>If <see langword="true"/>, polygon edges will be anti-aliased.</para>
    /// </summary>
    public bool Antialiased
    {
        get
        {
            return GetAntialiased();
        }
        set
        {
            SetAntialiased(value);
        }
    }

    /// <summary>
    /// <para>The polygon's fill texture. Use <see cref="Godot.Polygon2D.UV"/> to set texture coordinates.</para>
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
    /// <para>Amount to offset the polygon's <see cref="Godot.Polygon2D.Texture"/>. If set to <c>Vector2(0, 0)</c>, the texture's origin (its top-left corner) will be placed at the polygon's position.</para>
    /// </summary>
    public Vector2 TextureOffset
    {
        get
        {
            return GetTextureOffset();
        }
        set
        {
            SetTextureOffset(value);
        }
    }

    /// <summary>
    /// <para>Amount to multiply the <see cref="Godot.Polygon2D.UV"/> coordinates when using <see cref="Godot.Polygon2D.Texture"/>. Larger values make the texture smaller, and vice versa.</para>
    /// </summary>
    public Vector2 TextureScale
    {
        get
        {
            return GetTextureScale();
        }
        set
        {
            SetTextureScale(value);
        }
    }

    /// <summary>
    /// <para>The texture's rotation in radians.</para>
    /// </summary>
    public float TextureRotation
    {
        get
        {
            return GetTextureRotation();
        }
        set
        {
            SetTextureRotation(value);
        }
    }

    /// <summary>
    /// <para>Path to a <see cref="Godot.Skeleton2D"/> node used for skeleton-based deformations of this polygon. If empty or invalid, skeletal deformations will not be used.</para>
    /// </summary>
    public NodePath Skeleton
    {
        get
        {
            return GetSkeleton();
        }
        set
        {
            SetSkeleton(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the polygon will be inverted, containing the area outside the defined points and extending to the <see cref="Godot.Polygon2D.InvertBorder"/>.</para>
    /// </summary>
    public bool InvertEnabled
    {
        get
        {
            return GetInvertEnabled();
        }
        set
        {
            SetInvertEnabled(value);
        }
    }

    /// <summary>
    /// <para>Added padding applied to the bounding box when <see cref="Godot.Polygon2D.InvertEnabled"/> is set to <see langword="true"/>. Setting this value too small may result in a "Bad Polygon" error.</para>
    /// </summary>
    public float InvertBorder
    {
        get
        {
            return GetInvertBorder();
        }
        set
        {
            SetInvertBorder(value);
        }
    }

    /// <summary>
    /// <para>The polygon's list of vertices. The final point will be connected to the first.</para>
    /// </summary>
    public Vector2[] Polygon
    {
        get
        {
            return GetPolygon();
        }
        set
        {
            SetPolygon(value);
        }
    }

    /// <summary>
    /// <para>Texture coordinates for each vertex of the polygon. There should be one UV value per polygon vertex. If there are fewer, undefined vertices will use <c>Vector2(0, 0)</c>.</para>
    /// </summary>
    public Vector2[] UV
    {
        get
        {
            return GetUV();
        }
        set
        {
            SetUV(value);
        }
    }

    /// <summary>
    /// <para>Color for each vertex. Colors are interpolated between vertices, resulting in smooth gradients. There should be one per polygon vertex. If there are fewer, undefined vertices will use <see cref="Godot.Polygon2D.Color"/>.</para>
    /// </summary>
    public Color[] VertexColors
    {
        get
        {
            return GetVertexColors();
        }
        set
        {
            SetVertexColors(value);
        }
    }

    /// <summary>
    /// <para>The list of polygons, in case more than one is being represented. Every individual polygon is stored as a <see cref="int"/>[] where each <see cref="int"/> is an index to a point in <see cref="Godot.Polygon2D.Polygon"/>. If empty, this property will be ignored, and the resulting single polygon will be composed of all points in <see cref="Godot.Polygon2D.Polygon"/>, using the order they are stored in.</para>
    /// </summary>
    public Godot.Collections.Array Polygons
    {
        get
        {
            return GetPolygons();
        }
        set
        {
            SetPolygons(value);
        }
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public Godot.Collections.Array Bones
    {
        get
        {
            return _GetBones();
        }
        set
        {
            _SetBones(value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    /// <summary>
    /// <para>Number of internal vertices, used for UV mapping.</para>
    /// </summary>
    public int InternalVertexCount
    {
        get
        {
            return GetInternalVertexCount();
        }
        set
        {
            SetInternalVertexCount(value);
        }
    }

    private static readonly System.Type CachedType = typeof(Polygon2D);

    private static readonly StringName NativeName = "Polygon2D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public Polygon2D() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal Polygon2D(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal Polygon2D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPolygon, 1509147220ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPolygon(Vector2[] polygon)
    {
        NativeCalls.godot_icall_1_224(MethodBind0, GodotObject.GetPtr(this), polygon);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPolygon(ReadOnlySpan<Vector2> polygon)
    {
        NativeCalls.godot_icall_1_224(MethodBind0, GodotObject.GetPtr(this), polygon);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPolygon, 2961356807ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2[] GetPolygon()
    {
        return NativeCalls.godot_icall_0_225(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetUV, 1509147220ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetUV(Vector2[] uV)
    {
        NativeCalls.godot_icall_1_224(MethodBind2, GodotObject.GetPtr(this), uV);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetUV(ReadOnlySpan<Vector2> uV)
    {
        NativeCalls.godot_icall_1_224(MethodBind2, GodotObject.GetPtr(this), uV);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetUV, 2961356807ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2[] GetUV()
    {
        return NativeCalls.godot_icall_0_225(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetColor, 2920490490ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetColor(Color color)
    {
        NativeCalls.godot_icall_1_213(MethodBind4, GodotObject.GetPtr(this), &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetColor, 3444240500ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Color GetColor()
    {
        return NativeCalls.godot_icall_0_214(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPolygons, 381264803ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPolygons(Godot.Collections.Array polygons)
    {
        NativeCalls.godot_icall_1_138(MethodBind6, GodotObject.GetPtr(this), (godot_array)(polygons ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPolygons, 3995934104ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Godot.Collections.Array GetPolygons()
    {
        return NativeCalls.godot_icall_0_120(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVertexColors, 3546319833ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetVertexColors(Color[] vertexColors)
    {
        NativeCalls.godot_icall_1_226(MethodBind8, GodotObject.GetPtr(this), vertexColors);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetVertexColors(ReadOnlySpan<Color> vertexColors)
    {
        NativeCalls.godot_icall_1_226(MethodBind8, GodotObject.GetPtr(this), vertexColors);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVertexColors, 1392750486ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Color[] GetVertexColors()
    {
        return NativeCalls.godot_icall_0_227(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTexture, 4051416890ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTexture(Texture2D texture)
    {
        NativeCalls.godot_icall_1_56(MethodBind10, GodotObject.GetPtr(this), GodotObject.GetPtr(texture));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTexture, 3635182373ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Texture2D GetTexture()
    {
        return (Texture2D)NativeCalls.godot_icall_0_63(MethodBind11, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTextureOffset, 743155724ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetTextureOffset(Vector2 textureOffset)
    {
        NativeCalls.godot_icall_1_36(MethodBind12, GodotObject.GetPtr(this), &textureOffset);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTextureOffset, 3341600327ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2 GetTextureOffset()
    {
        return NativeCalls.godot_icall_0_37(MethodBind13, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTextureRotation, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTextureRotation(float textureRotation)
    {
        NativeCalls.godot_icall_1_67(MethodBind14, GodotObject.GetPtr(this), textureRotation);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTextureRotation, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetTextureRotation()
    {
        return NativeCalls.godot_icall_0_68(MethodBind15, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTextureScale, 743155724ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetTextureScale(Vector2 textureScale)
    {
        NativeCalls.godot_icall_1_36(MethodBind16, GodotObject.GetPtr(this), &textureScale);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTextureScale, 3341600327ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2 GetTextureScale()
    {
        return NativeCalls.godot_icall_0_37(MethodBind17, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetInvertEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetInvertEnabled(bool invert)
    {
        NativeCalls.godot_icall_1_14(MethodBind18, GodotObject.GetPtr(this), invert.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetInvertEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetInvertEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind19, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAntialiased, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAntialiased(bool antialiased)
    {
        NativeCalls.godot_icall_1_14(MethodBind20, GodotObject.GetPtr(this), antialiased.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAntialiased, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetAntialiased()
    {
        return NativeCalls.godot_icall_0_15(MethodBind21, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetInvertBorder, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetInvertBorder(float invertBorder)
    {
        NativeCalls.godot_icall_1_67(MethodBind22, GodotObject.GetPtr(this), invertBorder);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetInvertBorder, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetInvertBorder()
    {
        return NativeCalls.godot_icall_0_68(MethodBind23, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetOffset, 743155724ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetOffset(Vector2 offset)
    {
        NativeCalls.godot_icall_1_36(MethodBind24, GodotObject.GetPtr(this), &offset);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOffset, 3341600327ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2 GetOffset()
    {
        return NativeCalls.godot_icall_0_37(MethodBind25, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddBone, 703042815ul);

    /// <summary>
    /// <para>Adds a bone with the specified <paramref name="path"/> and <paramref name="weights"/>.</para>
    /// </summary>
    public void AddBone(NodePath path, float[] weights)
    {
        NativeCalls.godot_icall_2_1013(MethodBind26, GodotObject.GetPtr(this), (godot_node_path)(path?.NativeValue ?? default), weights);
    }

    /// <summary>
    /// <para>Adds a bone with the specified <paramref name="path"/> and <paramref name="weights"/>.</para>
    /// </summary>
    public void AddBone(NodePath path, ReadOnlySpan<float> weights)
    {
        NativeCalls.godot_icall_2_1013(MethodBind26, GodotObject.GetPtr(this), (godot_node_path)(path?.NativeValue ?? default), weights);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBoneCount, 3905245786ul);

    /// <summary>
    /// <para>Returns the number of bones in this <see cref="Godot.Polygon2D"/>.</para>
    /// </summary>
    public int GetBoneCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind27, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBonePath, 408788394ul);

    /// <summary>
    /// <para>Returns the path to the node associated with the specified bone.</para>
    /// </summary>
    public NodePath GetBonePath(int index)
    {
        return NativeCalls.godot_icall_1_74(MethodBind28, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBoneWeights, 1542882410ul);

    /// <summary>
    /// <para>Returns the weight values of the specified bone.</para>
    /// </summary>
    public float[] GetBoneWeights(int index)
    {
        return NativeCalls.godot_icall_1_799(MethodBind29, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = ClassDB_get_method_with_compatibility(NativeName, MethodName.EraseBone, 1286410249ul);

    /// <summary>
    /// <para>Removes the specified bone from this <see cref="Godot.Polygon2D"/>.</para>
    /// </summary>
    public void EraseBone(int index)
    {
        NativeCalls.godot_icall_1_38(MethodBind30, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ClearBones, 3218959716ul);

    /// <summary>
    /// <para>Removes all bones from this <see cref="Godot.Polygon2D"/>.</para>
    /// </summary>
    public void ClearBones()
    {
        NativeCalls.godot_icall_0_3(MethodBind31, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind32 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBonePath, 2761262315ul);

    /// <summary>
    /// <para>Sets the path to the node associated with the specified bone.</para>
    /// </summary>
    public void SetBonePath(int index, NodePath path)
    {
        NativeCalls.godot_icall_2_75(MethodBind32, GodotObject.GetPtr(this), index, (godot_node_path)(path?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind33 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBoneWeights, 1345852415ul);

    /// <summary>
    /// <para>Sets the weight values for the specified bone.</para>
    /// </summary>
    public void SetBoneWeights(int index, float[] weights)
    {
        NativeCalls.godot_icall_2_798(MethodBind33, GodotObject.GetPtr(this), index, weights);
    }

    /// <summary>
    /// <para>Sets the weight values for the specified bone.</para>
    /// </summary>
    public void SetBoneWeights(int index, ReadOnlySpan<float> weights)
    {
        NativeCalls.godot_icall_2_798(MethodBind33, GodotObject.GetPtr(this), index, weights);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind34 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSkeleton, 1348162250ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSkeleton(NodePath skeleton)
    {
        NativeCalls.godot_icall_1_123(MethodBind34, GodotObject.GetPtr(this), (godot_node_path)(skeleton?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind35 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSkeleton, 4075236667ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public NodePath GetSkeleton()
    {
        return NativeCalls.godot_icall_0_124(MethodBind35, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind36 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetInternalVertexCount, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetInternalVertexCount(int internalVertexCount)
    {
        NativeCalls.godot_icall_1_38(MethodBind36, GodotObject.GetPtr(this), internalVertexCount);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind37 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetInternalVertexCount, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetInternalVertexCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind37, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind38 = ClassDB_get_method_with_compatibility(NativeName, MethodName._SetBones, 381264803ul);

    internal void _SetBones(Godot.Collections.Array bones)
    {
        NativeCalls.godot_icall_1_138(MethodBind38, GodotObject.GetPtr(this), (godot_array)(bones ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind39 = ClassDB_get_method_with_compatibility(NativeName, MethodName._GetBones, 3995934104ul);

    internal Godot.Collections.Array _GetBones()
    {
        return NativeCalls.godot_icall_0_120(MethodBind39, GodotObject.GetPtr(this));
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
    public new class PropertyName : Node2D.PropertyName
    {
        /// <summary>
        /// Cached name for the 'color' property.
        /// </summary>
        public static readonly StringName Color = "color";
        /// <summary>
        /// Cached name for the 'offset' property.
        /// </summary>
        public static readonly StringName Offset = "offset";
        /// <summary>
        /// Cached name for the 'antialiased' property.
        /// </summary>
        public static readonly StringName Antialiased = "antialiased";
        /// <summary>
        /// Cached name for the 'texture' property.
        /// </summary>
        public static readonly StringName Texture = "texture";
        /// <summary>
        /// Cached name for the 'texture_offset' property.
        /// </summary>
        public static readonly StringName TextureOffset = "texture_offset";
        /// <summary>
        /// Cached name for the 'texture_scale' property.
        /// </summary>
        public static readonly StringName TextureScale = "texture_scale";
        /// <summary>
        /// Cached name for the 'texture_rotation' property.
        /// </summary>
        public static readonly StringName TextureRotation = "texture_rotation";
        /// <summary>
        /// Cached name for the 'skeleton' property.
        /// </summary>
        public static readonly StringName Skeleton = "skeleton";
        /// <summary>
        /// Cached name for the 'invert_enabled' property.
        /// </summary>
        public static readonly StringName InvertEnabled = "invert_enabled";
        /// <summary>
        /// Cached name for the 'invert_border' property.
        /// </summary>
        public static readonly StringName InvertBorder = "invert_border";
        /// <summary>
        /// Cached name for the 'polygon' property.
        /// </summary>
        public static readonly StringName Polygon = "polygon";
        /// <summary>
        /// Cached name for the 'uv' property.
        /// </summary>
        public static readonly StringName UV = "uv";
        /// <summary>
        /// Cached name for the 'vertex_colors' property.
        /// </summary>
        public static readonly StringName VertexColors = "vertex_colors";
        /// <summary>
        /// Cached name for the 'polygons' property.
        /// </summary>
        public static readonly StringName Polygons = "polygons";
        /// <summary>
        /// Cached name for the 'bones' property.
        /// </summary>
        public static readonly StringName Bones = "bones";
        /// <summary>
        /// Cached name for the 'internal_vertex_count' property.
        /// </summary>
        public static readonly StringName InternalVertexCount = "internal_vertex_count";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Node2D.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_polygon' method.
        /// </summary>
        public static readonly StringName SetPolygon = "set_polygon";
        /// <summary>
        /// Cached name for the 'get_polygon' method.
        /// </summary>
        public static readonly StringName GetPolygon = "get_polygon";
        /// <summary>
        /// Cached name for the 'set_uv' method.
        /// </summary>
        public static readonly StringName SetUV = "set_uv";
        /// <summary>
        /// Cached name for the 'get_uv' method.
        /// </summary>
        public static readonly StringName GetUV = "get_uv";
        /// <summary>
        /// Cached name for the 'set_color' method.
        /// </summary>
        public static readonly StringName SetColor = "set_color";
        /// <summary>
        /// Cached name for the 'get_color' method.
        /// </summary>
        public static readonly StringName GetColor = "get_color";
        /// <summary>
        /// Cached name for the 'set_polygons' method.
        /// </summary>
        public static readonly StringName SetPolygons = "set_polygons";
        /// <summary>
        /// Cached name for the 'get_polygons' method.
        /// </summary>
        public static readonly StringName GetPolygons = "get_polygons";
        /// <summary>
        /// Cached name for the 'set_vertex_colors' method.
        /// </summary>
        public static readonly StringName SetVertexColors = "set_vertex_colors";
        /// <summary>
        /// Cached name for the 'get_vertex_colors' method.
        /// </summary>
        public static readonly StringName GetVertexColors = "get_vertex_colors";
        /// <summary>
        /// Cached name for the 'set_texture' method.
        /// </summary>
        public static readonly StringName SetTexture = "set_texture";
        /// <summary>
        /// Cached name for the 'get_texture' method.
        /// </summary>
        public static readonly StringName GetTexture = "get_texture";
        /// <summary>
        /// Cached name for the 'set_texture_offset' method.
        /// </summary>
        public static readonly StringName SetTextureOffset = "set_texture_offset";
        /// <summary>
        /// Cached name for the 'get_texture_offset' method.
        /// </summary>
        public static readonly StringName GetTextureOffset = "get_texture_offset";
        /// <summary>
        /// Cached name for the 'set_texture_rotation' method.
        /// </summary>
        public static readonly StringName SetTextureRotation = "set_texture_rotation";
        /// <summary>
        /// Cached name for the 'get_texture_rotation' method.
        /// </summary>
        public static readonly StringName GetTextureRotation = "get_texture_rotation";
        /// <summary>
        /// Cached name for the 'set_texture_scale' method.
        /// </summary>
        public static readonly StringName SetTextureScale = "set_texture_scale";
        /// <summary>
        /// Cached name for the 'get_texture_scale' method.
        /// </summary>
        public static readonly StringName GetTextureScale = "get_texture_scale";
        /// <summary>
        /// Cached name for the 'set_invert_enabled' method.
        /// </summary>
        public static readonly StringName SetInvertEnabled = "set_invert_enabled";
        /// <summary>
        /// Cached name for the 'get_invert_enabled' method.
        /// </summary>
        public static readonly StringName GetInvertEnabled = "get_invert_enabled";
        /// <summary>
        /// Cached name for the 'set_antialiased' method.
        /// </summary>
        public static readonly StringName SetAntialiased = "set_antialiased";
        /// <summary>
        /// Cached name for the 'get_antialiased' method.
        /// </summary>
        public static readonly StringName GetAntialiased = "get_antialiased";
        /// <summary>
        /// Cached name for the 'set_invert_border' method.
        /// </summary>
        public static readonly StringName SetInvertBorder = "set_invert_border";
        /// <summary>
        /// Cached name for the 'get_invert_border' method.
        /// </summary>
        public static readonly StringName GetInvertBorder = "get_invert_border";
        /// <summary>
        /// Cached name for the 'set_offset' method.
        /// </summary>
        public static readonly StringName SetOffset = "set_offset";
        /// <summary>
        /// Cached name for the 'get_offset' method.
        /// </summary>
        public static readonly StringName GetOffset = "get_offset";
        /// <summary>
        /// Cached name for the 'add_bone' method.
        /// </summary>
        public static readonly StringName AddBone = "add_bone";
        /// <summary>
        /// Cached name for the 'get_bone_count' method.
        /// </summary>
        public static readonly StringName GetBoneCount = "get_bone_count";
        /// <summary>
        /// Cached name for the 'get_bone_path' method.
        /// </summary>
        public static readonly StringName GetBonePath = "get_bone_path";
        /// <summary>
        /// Cached name for the 'get_bone_weights' method.
        /// </summary>
        public static readonly StringName GetBoneWeights = "get_bone_weights";
        /// <summary>
        /// Cached name for the 'erase_bone' method.
        /// </summary>
        public static readonly StringName EraseBone = "erase_bone";
        /// <summary>
        /// Cached name for the 'clear_bones' method.
        /// </summary>
        public static readonly StringName ClearBones = "clear_bones";
        /// <summary>
        /// Cached name for the 'set_bone_path' method.
        /// </summary>
        public static readonly StringName SetBonePath = "set_bone_path";
        /// <summary>
        /// Cached name for the 'set_bone_weights' method.
        /// </summary>
        public static readonly StringName SetBoneWeights = "set_bone_weights";
        /// <summary>
        /// Cached name for the 'set_skeleton' method.
        /// </summary>
        public static readonly StringName SetSkeleton = "set_skeleton";
        /// <summary>
        /// Cached name for the 'get_skeleton' method.
        /// </summary>
        public static readonly StringName GetSkeleton = "get_skeleton";
        /// <summary>
        /// Cached name for the 'set_internal_vertex_count' method.
        /// </summary>
        public static readonly StringName SetInternalVertexCount = "set_internal_vertex_count";
        /// <summary>
        /// Cached name for the 'get_internal_vertex_count' method.
        /// </summary>
        public static readonly StringName GetInternalVertexCount = "get_internal_vertex_count";
        /// <summary>
        /// Cached name for the '_set_bones' method.
        /// </summary>
        public static readonly StringName _SetBones = "_set_bones";
        /// <summary>
        /// Cached name for the '_get_bones' method.
        /// </summary>
        public static readonly StringName _GetBones = "_get_bones";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Node2D.SignalName
    {
    }
}
