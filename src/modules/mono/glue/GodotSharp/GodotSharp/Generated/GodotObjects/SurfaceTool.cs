namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>The <see cref="Godot.SurfaceTool"/> is used to construct a <see cref="Godot.Mesh"/> by specifying vertex attributes individually. It can be used to construct a <see cref="Godot.Mesh"/> from a script. All properties except indices need to be added before calling <see cref="Godot.SurfaceTool.AddVertex(Vector3)"/>. For example, to add vertex colors and UVs:</para>
/// <para><code>
/// var st = new SurfaceTool();
/// st.Begin(Mesh.PrimitiveType.Triangles);
/// st.SetColor(new Color(1, 0, 0));
/// st.SetUV(new Vector2(0, 0));
/// st.AddVertex(new Vector3(0, 0, 0));
/// </code></para>
/// <para>The above <see cref="Godot.SurfaceTool"/> now contains one vertex of a triangle which has a UV coordinate and a specified <see cref="Godot.Color"/>. If another vertex were added without calling <see cref="Godot.SurfaceTool.SetUV(Vector2)"/> or <see cref="Godot.SurfaceTool.SetColor(Color)"/>, then the last values would be used.</para>
/// <para>Vertex attributes must be passed <b>before</b> calling <see cref="Godot.SurfaceTool.AddVertex(Vector3)"/>. Failure to do so will result in an error when committing the vertex information to a mesh.</para>
/// <para>Additionally, the attributes used before the first vertex is added determine the format of the mesh. For example, if you only add UVs to the first vertex, you cannot add color to any of the subsequent vertices.</para>
/// <para>See also <see cref="Godot.ArrayMesh"/>, <see cref="Godot.ImmediateMesh"/> and <see cref="Godot.MeshDataTool"/> for procedural geometry generation.</para>
/// <para><b>Note:</b> Godot uses clockwise <a href="https://learnopengl.com/Advanced-OpenGL/Face-culling">winding order</a> for front faces of triangle primitive modes.</para>
/// </summary>
public partial class SurfaceTool : RefCounted
{
    public enum CustomFormat : long
    {
        /// <summary>
        /// <para>Limits range of data passed to <see cref="Godot.SurfaceTool.SetCustom(int, Color)"/> to unsigned normalized 0 to 1 stored in 8 bits per channel. See <see cref="Godot.Mesh.ArrayCustomFormat.Rgba8Unorm"/>.</para>
        /// </summary>
        Rgba8Unorm = 0,
        /// <summary>
        /// <para>Limits range of data passed to <see cref="Godot.SurfaceTool.SetCustom(int, Color)"/> to signed normalized -1 to 1 stored in 8 bits per channel. See <see cref="Godot.Mesh.ArrayCustomFormat.Rgba8Snorm"/>.</para>
        /// </summary>
        Rgba8Snorm = 1,
        /// <summary>
        /// <para>Stores data passed to <see cref="Godot.SurfaceTool.SetCustom(int, Color)"/> as half precision floats, and uses only red and green color channels. See <see cref="Godot.Mesh.ArrayCustomFormat.RgHalf"/>.</para>
        /// </summary>
        RgHalf = 2,
        /// <summary>
        /// <para>Stores data passed to <see cref="Godot.SurfaceTool.SetCustom(int, Color)"/> as half precision floats and uses all color channels. See <see cref="Godot.Mesh.ArrayCustomFormat.RgbaHalf"/>.</para>
        /// </summary>
        RgbaHalf = 3,
        /// <summary>
        /// <para>Stores data passed to <see cref="Godot.SurfaceTool.SetCustom(int, Color)"/> as full precision floats, and uses only red color channel. See <see cref="Godot.Mesh.ArrayCustomFormat.RFloat"/>.</para>
        /// </summary>
        RFloat = 4,
        /// <summary>
        /// <para>Stores data passed to <see cref="Godot.SurfaceTool.SetCustom(int, Color)"/> as full precision floats, and uses only red and green color channels. See <see cref="Godot.Mesh.ArrayCustomFormat.RgFloat"/>.</para>
        /// </summary>
        RgFloat = 5,
        /// <summary>
        /// <para>Stores data passed to <see cref="Godot.SurfaceTool.SetCustom(int, Color)"/> as full precision floats, and uses only red, green and blue color channels. See <see cref="Godot.Mesh.ArrayCustomFormat.RgbFloat"/>.</para>
        /// </summary>
        RgbFloat = 6,
        /// <summary>
        /// <para>Stores data passed to <see cref="Godot.SurfaceTool.SetCustom(int, Color)"/> as full precision floats, and uses all color channels. See <see cref="Godot.Mesh.ArrayCustomFormat.RgbaFloat"/>.</para>
        /// </summary>
        RgbaFloat = 7,
        /// <summary>
        /// <para>Used to indicate a disabled custom channel.</para>
        /// </summary>
        Max = 8
    }

    public enum SkinWeightCount : long
    {
        /// <summary>
        /// <para>Each individual vertex can be influenced by only 4 bone weights.</para>
        /// </summary>
        Skin4Weights = 0,
        /// <summary>
        /// <para>Each individual vertex can be influenced by up to 8 bone weights.</para>
        /// </summary>
        Skin8Weights = 1
    }

    private static readonly System.Type CachedType = typeof(SurfaceTool);

    private static readonly StringName NativeName = "SurfaceTool";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public SurfaceTool() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal SurfaceTool(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal SurfaceTool(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSkinWeightCount, 618679515ul);

    /// <summary>
    /// <para>Set to <see cref="Godot.SurfaceTool.SkinWeightCount.Skin8Weights"/> to indicate that up to 8 bone influences per vertex may be used.</para>
    /// <para>By default, only 4 bone influences are used (<see cref="Godot.SurfaceTool.SkinWeightCount.Skin4Weights"/>).</para>
    /// <para><b>Note:</b> This function takes an enum, not the exact number of weights.</para>
    /// </summary>
    public void SetSkinWeightCount(SurfaceTool.SkinWeightCount count)
    {
        NativeCalls.godot_icall_1_38(MethodBind0, GodotObject.GetPtr(this), (int)count);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSkinWeightCount, 1072401130ul);

    /// <summary>
    /// <para>By default, returns <see cref="Godot.SurfaceTool.SkinWeightCount.Skin4Weights"/> to indicate only 4 bone influences per vertex are used.</para>
    /// <para>Returns <see cref="Godot.SurfaceTool.SkinWeightCount.Skin8Weights"/> if up to 8 influences are used.</para>
    /// <para><b>Note:</b> This function returns an enum, not the exact number of weights.</para>
    /// </summary>
    public SurfaceTool.SkinWeightCount GetSkinWeightCount()
    {
        return (SurfaceTool.SkinWeightCount)NativeCalls.godot_icall_0_39(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCustomFormat, 4087759856ul);

    /// <summary>
    /// <para>Sets the color format for this custom <paramref name="channelIndex"/>. Use <see cref="Godot.SurfaceTool.CustomFormat.Max"/> to disable.</para>
    /// <para>Must be invoked after <see cref="Godot.SurfaceTool.Begin(Mesh.PrimitiveType)"/> and should be set before <see cref="Godot.SurfaceTool.Commit(ArrayMesh, ulong)"/> or <see cref="Godot.SurfaceTool.CommitToArrays()"/>.</para>
    /// </summary>
    public void SetCustomFormat(int channelIndex, SurfaceTool.CustomFormat format)
    {
        NativeCalls.godot_icall_2_59(MethodBind2, GodotObject.GetPtr(this), channelIndex, (int)format);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCustomFormat, 839863283ul);

    /// <summary>
    /// <para>Returns the format for custom <paramref name="channelIndex"/> (currently up to 4). Returns <see cref="Godot.SurfaceTool.CustomFormat.Max"/> if this custom channel is unused.</para>
    /// </summary>
    public SurfaceTool.CustomFormat GetCustomFormat(int channelIndex)
    {
        return (SurfaceTool.CustomFormat)NativeCalls.godot_icall_1_60(MethodBind3, GodotObject.GetPtr(this), channelIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Begin, 2230304113ul);

    /// <summary>
    /// <para>Called before adding any vertices. Takes the primitive type as an argument (e.g. <see cref="Godot.Mesh.PrimitiveType.Triangles"/>).</para>
    /// </summary>
    public void Begin(Mesh.PrimitiveType primitive)
    {
        NativeCalls.godot_icall_1_38(MethodBind4, GodotObject.GetPtr(this), (int)primitive);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddVertex, 3460891852ul);

    /// <summary>
    /// <para>Specifies the position of current vertex. Should be called after specifying other vertex properties (e.g. Color, UV).</para>
    /// </summary>
    public unsafe void AddVertex(Vector3 vertex)
    {
        NativeCalls.godot_icall_1_177(MethodBind5, GodotObject.GetPtr(this), &vertex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetColor, 2920490490ul);

    /// <summary>
    /// <para>Specifies a <see cref="Godot.Color"/> to use for the <i>next</i> vertex. If every vertex needs to have this information set and you fail to submit it for the first vertex, this information may not be used at all.</para>
    /// <para><b>Note:</b> The material must have <see cref="Godot.BaseMaterial3D.VertexColorUseAsAlbedo"/> enabled for the vertex color to be visible.</para>
    /// </summary>
    public unsafe void SetColor(Color color)
    {
        NativeCalls.godot_icall_1_213(MethodBind6, GodotObject.GetPtr(this), &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetNormal, 3460891852ul);

    /// <summary>
    /// <para>Specifies a normal to use for the <i>next</i> vertex. If every vertex needs to have this information set and you fail to submit it for the first vertex, this information may not be used at all.</para>
    /// </summary>
    public unsafe void SetNormal(Vector3 normal)
    {
        NativeCalls.godot_icall_1_177(MethodBind7, GodotObject.GetPtr(this), &normal);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTangent, 3505987427ul);

    /// <summary>
    /// <para>Specifies a tangent to use for the <i>next</i> vertex. If every vertex needs to have this information set and you fail to submit it for the first vertex, this information may not be used at all.</para>
    /// <para><b>Note:</b> Even though <paramref name="tangent"/> is a <see cref="Godot.Plane"/>, it does not directly represent the tangent plane. Its <c>Plane.x</c>, <c>Plane.y</c>, and <c>Plane.z</c> represent the tangent vector and <c>Plane.d</c> should be either <c>-1</c> or <c>1</c>. See also <see cref="Godot.Mesh.ArrayType.Tangent"/>.</para>
    /// </summary>
    public unsafe void SetTangent(Plane tangent)
    {
        NativeCalls.godot_icall_1_741(MethodBind8, GodotObject.GetPtr(this), &tangent);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetUV, 743155724ul);

    /// <summary>
    /// <para>Specifies a set of UV coordinates to use for the <i>next</i> vertex. If every vertex needs to have this information set and you fail to submit it for the first vertex, this information may not be used at all.</para>
    /// </summary>
    public unsafe void SetUV(Vector2 uV)
    {
        NativeCalls.godot_icall_1_36(MethodBind9, GodotObject.GetPtr(this), &uV);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetUV2, 743155724ul);

    /// <summary>
    /// <para>Specifies an optional second set of UV coordinates to use for the <i>next</i> vertex. If every vertex needs to have this information set and you fail to submit it for the first vertex, this information may not be used at all.</para>
    /// </summary>
    public unsafe void SetUV2(Vector2 uV2)
    {
        NativeCalls.godot_icall_1_36(MethodBind10, GodotObject.GetPtr(this), &uV2);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBones, 3614634198ul);

    /// <summary>
    /// <para>Specifies an array of bones to use for the <i>next</i> vertex. <paramref name="bones"/> must contain 4 integers.</para>
    /// </summary>
    public void SetBones(int[] bones)
    {
        NativeCalls.godot_icall_1_150(MethodBind11, GodotObject.GetPtr(this), bones);
    }

    /// <summary>
    /// <para>Specifies an array of bones to use for the <i>next</i> vertex. <paramref name="bones"/> must contain 4 integers.</para>
    /// </summary>
    public void SetBones(ReadOnlySpan<int> bones)
    {
        NativeCalls.godot_icall_1_150(MethodBind11, GodotObject.GetPtr(this), bones);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetWeights, 2899603908ul);

    /// <summary>
    /// <para>Specifies weight values to use for the <i>next</i> vertex. <paramref name="weights"/> must contain 4 values. If every vertex needs to have this information set and you fail to submit it for the first vertex, this information may not be used at all.</para>
    /// </summary>
    public void SetWeights(float[] weights)
    {
        NativeCalls.godot_icall_1_647(MethodBind12, GodotObject.GetPtr(this), weights);
    }

    /// <summary>
    /// <para>Specifies weight values to use for the <i>next</i> vertex. <paramref name="weights"/> must contain 4 values. If every vertex needs to have this information set and you fail to submit it for the first vertex, this information may not be used at all.</para>
    /// </summary>
    public void SetWeights(ReadOnlySpan<float> weights)
    {
        NativeCalls.godot_icall_1_647(MethodBind12, GodotObject.GetPtr(this), weights);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCustom, 2878471219ul);

    /// <summary>
    /// <para>Sets the custom value on this vertex for <paramref name="channelIndex"/>.</para>
    /// <para><see cref="Godot.SurfaceTool.SetCustomFormat(int, SurfaceTool.CustomFormat)"/> must be called first for this <paramref name="channelIndex"/>. Formats which are not RGBA will ignore other color channels.</para>
    /// </summary>
    public unsafe void SetCustom(int channelIndex, Color customColor)
    {
        NativeCalls.godot_icall_2_687(MethodBind13, GodotObject.GetPtr(this), channelIndex, &customColor);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSmoothGroup, 1286410249ul);

    /// <summary>
    /// <para>Specifies the smooth group to use for the <i>next</i> vertex. If this is never called, all vertices will have the default smooth group of <c>0</c> and will be smoothed with adjacent vertices of the same group. To produce a mesh with flat normals, set the smooth group to <c>-1</c>.</para>
    /// <para><b>Note:</b> This function actually takes a <c>uint32_t</c>, so C# users should use <c>uint32.MaxValue</c> instead of <c>-1</c> to produce a mesh with flat normals.</para>
    /// </summary>
    public void SetSmoothGroup(uint index)
    {
        NativeCalls.godot_icall_1_208(MethodBind14, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddTriangleFan, 2235017613ul);

    /// <summary>
    /// <para>Inserts a triangle fan made of array data into <see cref="Godot.Mesh"/> being constructed.</para>
    /// <para>Requires the primitive type be set to <see cref="Godot.Mesh.PrimitiveType.Triangles"/>.</para>
    /// </summary>
    /// <param name="uvs">If the parameter is null, then the default value is <c>Array.Empty&lt;Vector2&gt;()</c>.</param>
    /// <param name="colors">If the parameter is null, then the default value is <c>Array.Empty&lt;Color&gt;()</c>.</param>
    /// <param name="uv2S">If the parameter is null, then the default value is <c>Array.Empty&lt;Vector2&gt;()</c>.</param>
    /// <param name="normals">If the parameter is null, then the default value is <c>Array.Empty&lt;Vector3&gt;()</c>.</param>
    public void AddTriangleFan(Vector3[] vertices, Vector2[] uvs = null, Color[] colors = null, Vector2[] uv2S = null, Vector3[] normals = null, Godot.Collections.Array<Plane> tangents = null)
    {
        Vector2[] uvsOrDefVal = uvs != null ? uvs : Array.Empty<Vector2>();
        Color[] colorsOrDefVal = colors != null ? colors : Array.Empty<Color>();
        Vector2[] uv2SOrDefVal = uv2S != null ? uv2S : Array.Empty<Vector2>();
        Vector3[] normalsOrDefVal = normals != null ? normals : Array.Empty<Vector3>();
        NativeCalls.godot_icall_6_1292(MethodBind15, GodotObject.GetPtr(this), vertices, uvsOrDefVal, colorsOrDefVal, uv2SOrDefVal, normalsOrDefVal, (godot_array)(tangents ?? new()).NativeValue);
    }

    /// <summary>
    /// <para>Inserts a triangle fan made of array data into <see cref="Godot.Mesh"/> being constructed.</para>
    /// <para>Requires the primitive type be set to <see cref="Godot.Mesh.PrimitiveType.Triangles"/>.</para>
    /// </summary>
    public void AddTriangleFan(ReadOnlySpan<Vector3> vertices, ReadOnlySpan<Vector2> uvs, ReadOnlySpan<Color> colors, ReadOnlySpan<Vector2> uv2S, ReadOnlySpan<Vector3> normals, Godot.Collections.Array<Plane> tangents)
    {
        NativeCalls.godot_icall_6_1292(MethodBind15, GodotObject.GetPtr(this), vertices, uvs, colors, uv2S, normals, (godot_array)(tangents ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddIndex, 1286410249ul);

    /// <summary>
    /// <para>Adds a vertex to index array if you are using indexed vertices. Does not need to be called before adding vertices.</para>
    /// </summary>
    public void AddIndex(int index)
    {
        NativeCalls.godot_icall_1_38(MethodBind16, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Index, 3218959716ul);

    /// <summary>
    /// <para>Shrinks the vertex array by creating an index array. This can improve performance by avoiding vertex reuse.</para>
    /// </summary>
    public void Index()
    {
        NativeCalls.godot_icall_0_3(MethodBind17, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Deindex, 3218959716ul);

    /// <summary>
    /// <para>Removes the index array by expanding the vertex array.</para>
    /// </summary>
    public void Deindex()
    {
        NativeCalls.godot_icall_0_3(MethodBind18, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GenerateNormals, 107499316ul);

    /// <summary>
    /// <para>Generates normals from vertices so you do not have to do it manually. If <paramref name="flip"/> is <see langword="true"/>, the resulting normals will be inverted. <see cref="Godot.SurfaceTool.GenerateNormals(bool)"/> should be called <i>after</i> generating geometry and <i>before</i> committing the mesh using <see cref="Godot.SurfaceTool.Commit(ArrayMesh, ulong)"/> or <see cref="Godot.SurfaceTool.CommitToArrays()"/>. For correct display of normal-mapped surfaces, you will also have to generate tangents using <see cref="Godot.SurfaceTool.GenerateTangents()"/>.</para>
    /// <para><b>Note:</b> <see cref="Godot.SurfaceTool.GenerateNormals(bool)"/> only works if the primitive type is set to <see cref="Godot.Mesh.PrimitiveType.Triangles"/>.</para>
    /// <para><b>Note:</b> <see cref="Godot.SurfaceTool.GenerateNormals(bool)"/> takes smooth groups into account. To generate smooth normals, set the smooth group to a value greater than or equal to <c>0</c> using <see cref="Godot.SurfaceTool.SetSmoothGroup(uint)"/> or leave the smooth group at the default of <c>0</c>. To generate flat normals, set the smooth group to <c>-1</c> using <see cref="Godot.SurfaceTool.SetSmoothGroup(uint)"/> prior to adding vertices.</para>
    /// </summary>
    public void GenerateNormals(bool flip = false)
    {
        NativeCalls.godot_icall_1_14(MethodBind19, GodotObject.GetPtr(this), flip.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GenerateTangents, 3218959716ul);

    /// <summary>
    /// <para>Generates a tangent vector for each vertex. Requires that each vertex already has UVs and normals set (see <see cref="Godot.SurfaceTool.GenerateNormals(bool)"/>).</para>
    /// </summary>
    public void GenerateTangents()
    {
        NativeCalls.godot_icall_0_3(MethodBind20, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.OptimizeIndicesForCache, 3218959716ul);

    /// <summary>
    /// <para>Optimizes triangle sorting for performance. Requires that <see cref="Godot.SurfaceTool.GetPrimitiveType()"/> is <see cref="Godot.Mesh.PrimitiveType.Triangles"/>.</para>
    /// </summary>
    public void OptimizeIndicesForCache()
    {
        NativeCalls.godot_icall_0_3(MethodBind21, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAabb, 1068685055ul);

    /// <summary>
    /// <para>Returns the axis-aligned bounding box of the vertex positions.</para>
    /// </summary>
    public Aabb GetAabb()
    {
        return NativeCalls.godot_icall_0_184(MethodBind22, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GenerateLod, 1938056459ul);

    /// <summary>
    /// <para>Generates an LOD for a given <paramref name="ndThreshold"/> in linear units (square root of quadric error metric), using at most <paramref name="targetIndexCount"/> indices.</para>
    /// </summary>
    [Obsolete("This method is unused internally, as it does not preserve normals or UVs. Consider using 'Godot.ImporterMesh.GenerateLods(float, float, Godot.Collections.Array)' instead.")]
    public int[] GenerateLod(float ndThreshold, int targetIndexCount = 3)
    {
        return NativeCalls.godot_icall_2_1293(MethodBind23, GodotObject.GetPtr(this), ndThreshold, targetIndexCount);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMaterial, 2757459619ul);

    /// <summary>
    /// <para>Sets <see cref="Godot.Material"/> to be used by the <see cref="Godot.Mesh"/> you are constructing.</para>
    /// </summary>
    public void SetMaterial(Material material)
    {
        NativeCalls.godot_icall_1_56(MethodBind24, GodotObject.GetPtr(this), GodotObject.GetPtr(material));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPrimitiveType, 768822145ul);

    /// <summary>
    /// <para>Returns the type of mesh geometry, such as <see cref="Godot.Mesh.PrimitiveType.Triangles"/>.</para>
    /// </summary>
    public Mesh.PrimitiveType GetPrimitiveType()
    {
        return (Mesh.PrimitiveType)NativeCalls.godot_icall_0_39(MethodBind25, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Clear, 3218959716ul);

    /// <summary>
    /// <para>Clear all information passed into the surface tool so far.</para>
    /// </summary>
    public void Clear()
    {
        NativeCalls.godot_icall_0_3(MethodBind26, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CreateFrom, 1767024570ul);

    /// <summary>
    /// <para>Creates a vertex array from an existing <see cref="Godot.Mesh"/>.</para>
    /// </summary>
    public void CreateFrom(Mesh existing, int surface)
    {
        NativeCalls.godot_icall_2_740(MethodBind27, GodotObject.GetPtr(this), GodotObject.GetPtr(existing), surface);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CreateFromArrays, 1894639680ul);

    /// <summary>
    /// <para>Creates this SurfaceTool from existing vertex arrays such as returned by <see cref="Godot.SurfaceTool.CommitToArrays()"/>, <see cref="Godot.Mesh.SurfaceGetArrays(int)"/>, <see cref="Godot.Mesh.SurfaceGetBlendShapeArrays(int)"/>, <see cref="Godot.ImporterMesh.GetSurfaceArrays(int)"/>, and <see cref="Godot.ImporterMesh.GetSurfaceBlendShapeArrays(int, int)"/>. <paramref name="primitiveType"/> controls the type of mesh data, defaulting to <see cref="Godot.Mesh.PrimitiveType.Triangles"/>.</para>
    /// </summary>
    public void CreateFromArrays(Godot.Collections.Array arrays, Mesh.PrimitiveType primitiveType = (Mesh.PrimitiveType)(3))
    {
        NativeCalls.godot_icall_2_1294(MethodBind28, GodotObject.GetPtr(this), (godot_array)(arrays ?? new()).NativeValue, (int)primitiveType);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CreateFromBlendShape, 1306185582ul);

    /// <summary>
    /// <para>Creates a vertex array from the specified blend shape of an existing <see cref="Godot.Mesh"/>. This can be used to extract a specific pose from a blend shape.</para>
    /// </summary>
    public void CreateFromBlendShape(Mesh existing, int surface, string blendShape)
    {
        NativeCalls.godot_icall_3_1295(MethodBind29, GodotObject.GetPtr(this), GodotObject.GetPtr(existing), surface, blendShape);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AppendFrom, 2217967155ul);

    /// <summary>
    /// <para>Append vertices from a given <see cref="Godot.Mesh"/> surface onto the current vertex array with specified <see cref="Godot.Transform3D"/>.</para>
    /// </summary>
    public unsafe void AppendFrom(Mesh existing, int surface, Transform3D transform)
    {
        NativeCalls.godot_icall_3_896(MethodBind30, GodotObject.GetPtr(this), GodotObject.GetPtr(existing), surface, &transform);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Commit, 4107864055ul);

    /// <summary>
    /// <para>Returns a constructed <see cref="Godot.ArrayMesh"/> from current information passed in. If an existing <see cref="Godot.ArrayMesh"/> is passed in as an argument, will add an extra surface to the existing <see cref="Godot.ArrayMesh"/>.</para>
    /// <para>The <paramref name="flags"/> argument can be the bitwise OR of <see cref="Godot.Mesh.ArrayFormat.FlagUseDynamicUpdate"/>, <see cref="Godot.Mesh.ArrayFormat.FlagUse8BoneWeights"/>, or <see cref="Godot.Mesh.ArrayFormat.FlagUsesEmptyVertexArray"/>.</para>
    /// </summary>
    public ArrayMesh Commit(ArrayMesh existing = default, ulong flags = (ulong)(0))
    {
        return (ArrayMesh)NativeCalls.godot_icall_2_1296(MethodBind31, GodotObject.GetPtr(this), GodotObject.GetPtr(existing), flags);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind32 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CommitToArrays, 2915620761ul);

    /// <summary>
    /// <para>Commits the data to the same format used by <see cref="Godot.ArrayMesh.AddSurfaceFromArrays(Mesh.PrimitiveType, Godot.Collections.Array, Godot.Collections.Array{Godot.Collections.Array}, Godot.Collections.Dictionary, Mesh.ArrayFormat)"/>, <see cref="Godot.ImporterMesh.AddSurface(Mesh.PrimitiveType, Godot.Collections.Array, Godot.Collections.Array{Godot.Collections.Array}, Godot.Collections.Dictionary, Material, string, ulong)"/>, and <see cref="Godot.SurfaceTool.CreateFromArrays(Godot.Collections.Array, Mesh.PrimitiveType)"/>. This way you can further process the mesh data using the <see cref="Godot.ArrayMesh"/> or <see cref="Godot.ImporterMesh"/> APIs.</para>
    /// </summary>
    public Godot.Collections.Array CommitToArrays()
    {
        return NativeCalls.godot_icall_0_120(MethodBind32, GodotObject.GetPtr(this));
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
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : RefCounted.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_skin_weight_count' method.
        /// </summary>
        public static readonly StringName SetSkinWeightCount = "set_skin_weight_count";
        /// <summary>
        /// Cached name for the 'get_skin_weight_count' method.
        /// </summary>
        public static readonly StringName GetSkinWeightCount = "get_skin_weight_count";
        /// <summary>
        /// Cached name for the 'set_custom_format' method.
        /// </summary>
        public static readonly StringName SetCustomFormat = "set_custom_format";
        /// <summary>
        /// Cached name for the 'get_custom_format' method.
        /// </summary>
        public static readonly StringName GetCustomFormat = "get_custom_format";
        /// <summary>
        /// Cached name for the 'begin' method.
        /// </summary>
        public static readonly StringName Begin = "begin";
        /// <summary>
        /// Cached name for the 'add_vertex' method.
        /// </summary>
        public static readonly StringName AddVertex = "add_vertex";
        /// <summary>
        /// Cached name for the 'set_color' method.
        /// </summary>
        public static readonly StringName SetColor = "set_color";
        /// <summary>
        /// Cached name for the 'set_normal' method.
        /// </summary>
        public static readonly StringName SetNormal = "set_normal";
        /// <summary>
        /// Cached name for the 'set_tangent' method.
        /// </summary>
        public static readonly StringName SetTangent = "set_tangent";
        /// <summary>
        /// Cached name for the 'set_uv' method.
        /// </summary>
        public static readonly StringName SetUV = "set_uv";
        /// <summary>
        /// Cached name for the 'set_uv2' method.
        /// </summary>
        public static readonly StringName SetUV2 = "set_uv2";
        /// <summary>
        /// Cached name for the 'set_bones' method.
        /// </summary>
        public static readonly StringName SetBones = "set_bones";
        /// <summary>
        /// Cached name for the 'set_weights' method.
        /// </summary>
        public static readonly StringName SetWeights = "set_weights";
        /// <summary>
        /// Cached name for the 'set_custom' method.
        /// </summary>
        public static readonly StringName SetCustom = "set_custom";
        /// <summary>
        /// Cached name for the 'set_smooth_group' method.
        /// </summary>
        public static readonly StringName SetSmoothGroup = "set_smooth_group";
        /// <summary>
        /// Cached name for the 'add_triangle_fan' method.
        /// </summary>
        public static readonly StringName AddTriangleFan = "add_triangle_fan";
        /// <summary>
        /// Cached name for the 'add_index' method.
        /// </summary>
        public static readonly StringName AddIndex = "add_index";
        /// <summary>
        /// Cached name for the 'index' method.
        /// </summary>
        public static readonly StringName Index = "index";
        /// <summary>
        /// Cached name for the 'deindex' method.
        /// </summary>
        public static readonly StringName Deindex = "deindex";
        /// <summary>
        /// Cached name for the 'generate_normals' method.
        /// </summary>
        public static readonly StringName GenerateNormals = "generate_normals";
        /// <summary>
        /// Cached name for the 'generate_tangents' method.
        /// </summary>
        public static readonly StringName GenerateTangents = "generate_tangents";
        /// <summary>
        /// Cached name for the 'optimize_indices_for_cache' method.
        /// </summary>
        public static readonly StringName OptimizeIndicesForCache = "optimize_indices_for_cache";
        /// <summary>
        /// Cached name for the 'get_aabb' method.
        /// </summary>
        public static readonly StringName GetAabb = "get_aabb";
        /// <summary>
        /// Cached name for the 'generate_lod' method.
        /// </summary>
        public static readonly StringName GenerateLod = "generate_lod";
        /// <summary>
        /// Cached name for the 'set_material' method.
        /// </summary>
        public static readonly StringName SetMaterial = "set_material";
        /// <summary>
        /// Cached name for the 'get_primitive_type' method.
        /// </summary>
        public static readonly StringName GetPrimitiveType = "get_primitive_type";
        /// <summary>
        /// Cached name for the 'clear' method.
        /// </summary>
        public static readonly StringName Clear = "clear";
        /// <summary>
        /// Cached name for the 'create_from' method.
        /// </summary>
        public static readonly StringName CreateFrom = "create_from";
        /// <summary>
        /// Cached name for the 'create_from_arrays' method.
        /// </summary>
        public static readonly StringName CreateFromArrays = "create_from_arrays";
        /// <summary>
        /// Cached name for the 'create_from_blend_shape' method.
        /// </summary>
        public static readonly StringName CreateFromBlendShape = "create_from_blend_shape";
        /// <summary>
        /// Cached name for the 'append_from' method.
        /// </summary>
        public static readonly StringName AppendFrom = "append_from";
        /// <summary>
        /// Cached name for the 'commit' method.
        /// </summary>
        public static readonly StringName Commit = "commit";
        /// <summary>
        /// Cached name for the 'commit_to_arrays' method.
        /// </summary>
        public static readonly StringName CommitToArrays = "commit_to_arrays";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : RefCounted.SignalName
    {
    }
}
