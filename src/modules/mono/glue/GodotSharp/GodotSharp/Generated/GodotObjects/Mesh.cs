namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Mesh is a type of <see cref="Godot.Resource"/> that contains vertex array-based geometry, divided in <i>surfaces</i>. Each surface contains a completely separate array and a material used to draw it. Design wise, a mesh with multiple surfaces is preferred to a single surface, because objects created in 3D editing software commonly contain multiple materials. The maximum number of surfaces per mesh is <see cref="Godot.RenderingServer.MaxMeshSurfaces"/>.</para>
/// </summary>
public partial class Mesh : Resource
{
    public enum PrimitiveType : long
    {
        /// <summary>
        /// <para>Render array as points (one vertex equals one point).</para>
        /// </summary>
        Points = 0,
        /// <summary>
        /// <para>Render array as lines (every two vertices a line is created).</para>
        /// </summary>
        Lines = 1,
        /// <summary>
        /// <para>Render array as line strip.</para>
        /// </summary>
        LineStrip = 2,
        /// <summary>
        /// <para>Render array as triangles (every three vertices a triangle is created).</para>
        /// </summary>
        Triangles = 3,
        /// <summary>
        /// <para>Render array as triangle strips.</para>
        /// </summary>
        TriangleStrip = 4
    }

    public enum ArrayType : long
    {
        /// <summary>
        /// <para><see cref="Godot.Vector3"/>[], <see cref="Godot.Vector2"/>[], or <see cref="Godot.Collections.Array"/> of vertex positions.</para>
        /// </summary>
        Vertex = 0,
        /// <summary>
        /// <para><see cref="Godot.Vector3"/>[] of vertex normals.</para>
        /// <para><b>Note:</b> The array has to consist of normal vectors, otherwise they will be normalized by the engine, potentially causing visual discrepancies.</para>
        /// </summary>
        Normal = 1,
        /// <summary>
        /// <para><see cref="float"/>[] of vertex tangents. Each element in groups of 4 floats, first 3 floats determine the tangent, and the last the binormal direction as -1 or 1.</para>
        /// </summary>
        Tangent = 2,
        /// <summary>
        /// <para><see cref="Godot.Color"/>[] of vertex colors.</para>
        /// </summary>
        Color = 3,
        /// <summary>
        /// <para><see cref="Godot.Vector2"/>[] for UV coordinates.</para>
        /// </summary>
        TexUV = 4,
        /// <summary>
        /// <para><see cref="Godot.Vector2"/>[] for second UV coordinates.</para>
        /// </summary>
        TexUV2 = 5,
        /// <summary>
        /// <para>Contains custom color channel 0. <see cref="byte"/>[] if <c>(format &gt;&gt; Mesh.ARRAY_FORMAT_CUSTOM0_SHIFT) &amp; Mesh.ARRAY_FORMAT_CUSTOM_MASK</c> is <see cref="Godot.Mesh.ArrayCustomFormat.Rgba8Unorm"/>, <see cref="Godot.Mesh.ArrayCustomFormat.Rgba8Snorm"/>, <see cref="Godot.Mesh.ArrayCustomFormat.RgHalf"/>, or <see cref="Godot.Mesh.ArrayCustomFormat.RgbaHalf"/>. <see cref="float"/>[] otherwise.</para>
        /// </summary>
        Custom0 = 6,
        /// <summary>
        /// <para>Contains custom color channel 1. <see cref="byte"/>[] if <c>(format &gt;&gt; Mesh.ARRAY_FORMAT_CUSTOM1_SHIFT) &amp; Mesh.ARRAY_FORMAT_CUSTOM_MASK</c> is <see cref="Godot.Mesh.ArrayCustomFormat.Rgba8Unorm"/>, <see cref="Godot.Mesh.ArrayCustomFormat.Rgba8Snorm"/>, <see cref="Godot.Mesh.ArrayCustomFormat.RgHalf"/>, or <see cref="Godot.Mesh.ArrayCustomFormat.RgbaHalf"/>. <see cref="float"/>[] otherwise.</para>
        /// </summary>
        Custom1 = 7,
        /// <summary>
        /// <para>Contains custom color channel 2. <see cref="byte"/>[] if <c>(format &gt;&gt; Mesh.ARRAY_FORMAT_CUSTOM2_SHIFT) &amp; Mesh.ARRAY_FORMAT_CUSTOM_MASK</c> is <see cref="Godot.Mesh.ArrayCustomFormat.Rgba8Unorm"/>, <see cref="Godot.Mesh.ArrayCustomFormat.Rgba8Snorm"/>, <see cref="Godot.Mesh.ArrayCustomFormat.RgHalf"/>, or <see cref="Godot.Mesh.ArrayCustomFormat.RgbaHalf"/>. <see cref="float"/>[] otherwise.</para>
        /// </summary>
        Custom2 = 8,
        /// <summary>
        /// <para>Contains custom color channel 3. <see cref="byte"/>[] if <c>(format &gt;&gt; Mesh.ARRAY_FORMAT_CUSTOM3_SHIFT) &amp; Mesh.ARRAY_FORMAT_CUSTOM_MASK</c> is <see cref="Godot.Mesh.ArrayCustomFormat.Rgba8Unorm"/>, <see cref="Godot.Mesh.ArrayCustomFormat.Rgba8Snorm"/>, <see cref="Godot.Mesh.ArrayCustomFormat.RgHalf"/>, or <see cref="Godot.Mesh.ArrayCustomFormat.RgbaHalf"/>. <see cref="float"/>[] otherwise.</para>
        /// </summary>
        Custom3 = 9,
        /// <summary>
        /// <para><see cref="float"/>[] or <see cref="int"/>[] of bone indices. Contains either 4 or 8 numbers per vertex depending on the presence of the <see cref="Godot.Mesh.ArrayFormat.FlagUse8BoneWeights"/> flag.</para>
        /// </summary>
        Bones = 10,
        /// <summary>
        /// <para><see cref="float"/>[] or <see cref="double"/>[] of bone weights in the range <c>0.0</c> to <c>1.0</c> (inclusive). Contains either 4 or 8 numbers per vertex depending on the presence of the <see cref="Godot.Mesh.ArrayFormat.FlagUse8BoneWeights"/> flag.</para>
        /// </summary>
        Weights = 11,
        /// <summary>
        /// <para><see cref="int"/>[] of integers used as indices referencing vertices, colors, normals, tangents, and textures. All of those arrays must have the same number of elements as the vertex array. No index can be beyond the vertex array size. When this index array is present, it puts the function into "index mode," where the index selects the <i>i</i>'th vertex, normal, tangent, color, UV, etc. This means if you want to have different normals or colors along an edge, you have to duplicate the vertices.</para>
        /// <para>For triangles, the index array is interpreted as triples, referring to the vertices of each triangle. For lines, the index array is in pairs indicating the start and end of each line.</para>
        /// </summary>
        Index = 12,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.Mesh.ArrayType"/> enum.</para>
        /// </summary>
        Max = 13
    }

    public enum ArrayCustomFormat : long
    {
        /// <summary>
        /// <para>Indicates this custom channel contains unsigned normalized byte colors from 0 to 1, encoded as <see cref="byte"/>[].</para>
        /// </summary>
        Rgba8Unorm = 0,
        /// <summary>
        /// <para>Indicates this custom channel contains signed normalized byte colors from -1 to 1, encoded as <see cref="byte"/>[].</para>
        /// </summary>
        Rgba8Snorm = 1,
        /// <summary>
        /// <para>Indicates this custom channel contains half precision float colors, encoded as <see cref="byte"/>[]. Only red and green channels are used.</para>
        /// </summary>
        RgHalf = 2,
        /// <summary>
        /// <para>Indicates this custom channel contains half precision float colors, encoded as <see cref="byte"/>[].</para>
        /// </summary>
        RgbaHalf = 3,
        /// <summary>
        /// <para>Indicates this custom channel contains full float colors, in a <see cref="float"/>[]. Only the red channel is used.</para>
        /// </summary>
        RFloat = 4,
        /// <summary>
        /// <para>Indicates this custom channel contains full float colors, in a <see cref="float"/>[]. Only red and green channels are used.</para>
        /// </summary>
        RgFloat = 5,
        /// <summary>
        /// <para>Indicates this custom channel contains full float colors, in a <see cref="float"/>[]. Only red, green and blue channels are used.</para>
        /// </summary>
        RgbFloat = 6,
        /// <summary>
        /// <para>Indicates this custom channel contains full float colors, in a <see cref="float"/>[].</para>
        /// </summary>
        RgbaFloat = 7,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.Mesh.ArrayCustomFormat"/> enum.</para>
        /// </summary>
        Max = 8
    }

    [System.Flags]
    public enum ArrayFormat : long
    {
        /// <summary>
        /// <para>Mesh array contains vertices. All meshes require a vertex array so this should always be present.</para>
        /// </summary>
        FormatVertex = 1,
        /// <summary>
        /// <para>Mesh array contains normals.</para>
        /// </summary>
        FormatNormal = 2,
        /// <summary>
        /// <para>Mesh array contains tangents.</para>
        /// </summary>
        FormatTangent = 4,
        /// <summary>
        /// <para>Mesh array contains colors.</para>
        /// </summary>
        FormatColor = 8,
        /// <summary>
        /// <para>Mesh array contains UVs.</para>
        /// </summary>
        FormatTexUV = 16,
        /// <summary>
        /// <para>Mesh array contains second UV.</para>
        /// </summary>
        FormatTexUV2 = 32,
        /// <summary>
        /// <para>Mesh array contains custom channel index 0.</para>
        /// </summary>
        FormatCustom0 = 64,
        /// <summary>
        /// <para>Mesh array contains custom channel index 1.</para>
        /// </summary>
        FormatCustom1 = 128,
        /// <summary>
        /// <para>Mesh array contains custom channel index 2.</para>
        /// </summary>
        FormatCustom2 = 256,
        /// <summary>
        /// <para>Mesh array contains custom channel index 3.</para>
        /// </summary>
        FormatCustom3 = 512,
        /// <summary>
        /// <para>Mesh array contains bones.</para>
        /// </summary>
        FormatBones = 1024,
        /// <summary>
        /// <para>Mesh array contains bone weights.</para>
        /// </summary>
        FormatWeights = 2048,
        /// <summary>
        /// <para>Mesh array uses indices.</para>
        /// </summary>
        FormatIndex = 4096,
        /// <summary>
        /// <para>Mask of mesh channels permitted in blend shapes.</para>
        /// </summary>
        FormatBlendShapeMask = 7,
        /// <summary>
        /// <para>Shift of first custom channel.</para>
        /// </summary>
        FormatCustomBase = 13,
        /// <summary>
        /// <para>Number of format bits per custom channel. See <see cref="Godot.Mesh.ArrayCustomFormat"/>.</para>
        /// </summary>
        FormatCustomBits = 3,
        /// <summary>
        /// <para>Amount to shift <see cref="Godot.Mesh.ArrayCustomFormat"/> for custom channel index 0.</para>
        /// </summary>
        FormatCustom0Shift = 13,
        /// <summary>
        /// <para>Amount to shift <see cref="Godot.Mesh.ArrayCustomFormat"/> for custom channel index 1.</para>
        /// </summary>
        FormatCustom1Shift = 16,
        /// <summary>
        /// <para>Amount to shift <see cref="Godot.Mesh.ArrayCustomFormat"/> for custom channel index 2.</para>
        /// </summary>
        FormatCustom2Shift = 19,
        /// <summary>
        /// <para>Amount to shift <see cref="Godot.Mesh.ArrayCustomFormat"/> for custom channel index 3.</para>
        /// </summary>
        FormatCustom3Shift = 22,
        /// <summary>
        /// <para>Mask of custom format bits per custom channel. Must be shifted by one of the SHIFT constants. See <see cref="Godot.Mesh.ArrayCustomFormat"/>.</para>
        /// </summary>
        FormatCustomMask = 7,
        /// <summary>
        /// <para>Shift of first compress flag. Compress flags should be passed to <see cref="Godot.ArrayMesh.AddSurfaceFromArrays(Mesh.PrimitiveType, Godot.Collections.Array, Godot.Collections.Array{Godot.Collections.Array}, Godot.Collections.Dictionary, Mesh.ArrayFormat)"/> and <see cref="Godot.SurfaceTool.Commit(ArrayMesh, ulong)"/>.</para>
        /// </summary>
        CompressFlagsBase = 25,
        /// <summary>
        /// <para>Flag used to mark that the array contains 2D vertices.</para>
        /// </summary>
        FlagUse2DVertices = 33554432,
        /// <summary>
        /// <para>Flag used to mark that the mesh data will use <c>GL_DYNAMIC_DRAW</c> on GLES. Unused on Vulkan.</para>
        /// </summary>
        FlagUseDynamicUpdate = 67108864,
        /// <summary>
        /// <para>Flag used to mark that the mesh contains up to 8 bone influences per vertex. This flag indicates that <see cref="Godot.Mesh.ArrayType.Bones"/> and <see cref="Godot.Mesh.ArrayType.Weights"/> elements will have double length.</para>
        /// </summary>
        FlagUse8BoneWeights = 134217728,
        /// <summary>
        /// <para>Flag used to mark that the mesh intentionally contains no vertex array.</para>
        /// </summary>
        FlagUsesEmptyVertexArray = 268435456,
        /// <summary>
        /// <para>Flag used to mark that a mesh is using compressed attributes (vertices, normals, tangents, UVs). When this form of compression is enabled, vertex positions will be packed into an RGBA16UNORM attribute and scaled in the vertex shader. The normal and tangent will be packed into an RG16UNORM representing an axis, and a 16-bit float stored in the A-channel of the vertex. UVs will use 16-bit normalized floats instead of full 32-bit signed floats. When using this compression mode you must use either vertices, normals, and tangents or only vertices. You cannot use normals without tangents. Importers will automatically enable this compression if they can.</para>
        /// </summary>
        FlagCompressAttributes = 536870912
    }

    public enum BlendShapeMode : long
    {
        /// <summary>
        /// <para>Blend shapes are normalized.</para>
        /// </summary>
        Normalized = 0,
        /// <summary>
        /// <para>Blend shapes are relative to base weight.</para>
        /// </summary>
        Relative = 1
    }

    /// <summary>
    /// <para>Sets a hint to be used for lightmap resolution.</para>
    /// </summary>
    public Vector2I LightmapSizeHint
    {
        get
        {
            return GetLightmapSizeHint();
        }
        set
        {
            SetLightmapSizeHint(value);
        }
    }

    private static readonly System.Type CachedType = typeof(Mesh);

    private static readonly StringName NativeName = "Mesh";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public Mesh() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal Mesh(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal Mesh(bool memoryOwn) : base(memoryOwn) { }

    /// <summary>
    /// <para>Virtual method to override the <see cref="Godot.Aabb"/> for a custom class extending <see cref="Godot.Mesh"/>.</para>
    /// </summary>
    public virtual Aabb _GetAabb()
    {
        return default;
    }

    /// <summary>
    /// <para>Virtual method to override the number of blend shapes for a custom class extending <see cref="Godot.Mesh"/>.</para>
    /// </summary>
    public virtual int _GetBlendShapeCount()
    {
        return default;
    }

    /// <summary>
    /// <para>Virtual method to override the retrieval of blend shape names for a custom class extending <see cref="Godot.Mesh"/>.</para>
    /// </summary>
    public virtual StringName _GetBlendShapeName(int index)
    {
        return default;
    }

    /// <summary>
    /// <para>Virtual method to override the surface count for a custom class extending <see cref="Godot.Mesh"/>.</para>
    /// </summary>
    public virtual int _GetSurfaceCount()
    {
        return default;
    }

    /// <summary>
    /// <para>Virtual method to override the names of blend shapes for a custom class extending <see cref="Godot.Mesh"/>.</para>
    /// </summary>
    public virtual void _SetBlendShapeName(int index, StringName name)
    {
    }

    /// <summary>
    /// <para>Virtual method to override the surface array index length for a custom class extending <see cref="Godot.Mesh"/>.</para>
    /// </summary>
    public virtual int _SurfaceGetArrayIndexLen(int index)
    {
        return default;
    }

    /// <summary>
    /// <para>Virtual method to override the surface array length for a custom class extending <see cref="Godot.Mesh"/>.</para>
    /// </summary>
    public virtual int _SurfaceGetArrayLen(int index)
    {
        return default;
    }

    /// <summary>
    /// <para>Virtual method to override the surface arrays for a custom class extending <see cref="Godot.Mesh"/>.</para>
    /// </summary>
    public virtual Godot.Collections.Array _SurfaceGetArrays(int index)
    {
        return default;
    }

    /// <summary>
    /// <para>Virtual method to override the blend shape arrays for a custom class extending <see cref="Godot.Mesh"/>.</para>
    /// </summary>
    public virtual Godot.Collections.Array<Godot.Collections.Array> _SurfaceGetBlendShapeArrays(int index)
    {
        return default;
    }

    /// <summary>
    /// <para>Virtual method to override the surface format for a custom class extending <see cref="Godot.Mesh"/>.</para>
    /// </summary>
    public virtual uint _SurfaceGetFormat(int index)
    {
        return default;
    }

    /// <summary>
    /// <para>Virtual method to override the surface LODs for a custom class extending <see cref="Godot.Mesh"/>.</para>
    /// </summary>
    public virtual Godot.Collections.Dictionary _SurfaceGetLods(int index)
    {
        return default;
    }

    /// <summary>
    /// <para>Virtual method to override the surface material for a custom class extending <see cref="Godot.Mesh"/>.</para>
    /// </summary>
    public virtual Material _SurfaceGetMaterial(int index)
    {
        return default;
    }

    /// <summary>
    /// <para>Virtual method to override the surface primitive type for a custom class extending <see cref="Godot.Mesh"/>.</para>
    /// </summary>
    public virtual uint _SurfaceGetPrimitiveType(int index)
    {
        return default;
    }

    /// <summary>
    /// <para>Virtual method to override the setting of a <paramref name="material"/> at the given <paramref name="index"/> for a custom class extending <see cref="Godot.Mesh"/>.</para>
    /// </summary>
    public virtual void _SurfaceSetMaterial(int index, Material material)
    {
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLightmapSizeHint, 1130785943ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetLightmapSizeHint(Vector2I size)
    {
        NativeCalls.godot_icall_1_34(MethodBind0, GodotObject.GetPtr(this), &size);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLightmapSizeHint, 3690982128ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2I GetLightmapSizeHint()
    {
        return NativeCalls.godot_icall_0_35(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAabb, 1068685055ul);

    /// <summary>
    /// <para>Returns the smallest <see cref="Godot.Aabb"/> enclosing this mesh in local space. Not affected by <c>custom_aabb</c>.</para>
    /// <para><b>Note:</b> This is only implemented for <see cref="Godot.ArrayMesh"/> and <see cref="Godot.PrimitiveMesh"/>.</para>
    /// </summary>
    public Aabb GetAabb()
    {
        return NativeCalls.godot_icall_0_184(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFaces, 497664490ul);

    /// <summary>
    /// <para>Returns all the vertices that make up the faces of the mesh. Each three vertices represent one triangle.</para>
    /// </summary>
    public Vector3[] GetFaces()
    {
        return NativeCalls.godot_icall_0_228(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSurfaceCount, 3905245786ul);

    /// <summary>
    /// <para>Returns the number of surfaces that the <see cref="Godot.Mesh"/> holds. This is equivalent to <see cref="Godot.MeshInstance3D.GetSurfaceOverrideMaterialCount()"/>.</para>
    /// </summary>
    public int GetSurfaceCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind4, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SurfaceGetArrays, 663333327ul);

    /// <summary>
    /// <para>Returns the arrays for the vertices, normals, UVs, etc. that make up the requested surface (see <see cref="Godot.ArrayMesh.AddSurfaceFromArrays(Mesh.PrimitiveType, Godot.Collections.Array, Godot.Collections.Array{Godot.Collections.Array}, Godot.Collections.Dictionary, Mesh.ArrayFormat)"/>).</para>
    /// </summary>
    public Godot.Collections.Array SurfaceGetArrays(int surfIdx)
    {
        return NativeCalls.godot_icall_1_457(MethodBind5, GodotObject.GetPtr(this), surfIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SurfaceGetBlendShapeArrays, 663333327ul);

    /// <summary>
    /// <para>Returns the blend shape arrays for the requested surface.</para>
    /// </summary>
    public Godot.Collections.Array<Godot.Collections.Array> SurfaceGetBlendShapeArrays(int surfIdx)
    {
        return new Godot.Collections.Array<Godot.Collections.Array>(NativeCalls.godot_icall_1_457(MethodBind6, GodotObject.GetPtr(this), surfIdx));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SurfaceSetMaterial, 3671737478ul);

    /// <summary>
    /// <para>Sets a <see cref="Godot.Material"/> for a given surface. Surface will be rendered using this material.</para>
    /// <para><b>Note:</b> This assigns the material within the <see cref="Godot.Mesh"/> resource, not the <see cref="Godot.Material"/> associated to the <see cref="Godot.MeshInstance3D"/>'s Surface Material Override properties. To set the <see cref="Godot.Material"/> associated to the <see cref="Godot.MeshInstance3D"/>'s Surface Material Override properties, use <see cref="Godot.MeshInstance3D.SetSurfaceOverrideMaterial(int, Material)"/> instead.</para>
    /// </summary>
    public void SurfaceSetMaterial(int surfIdx, Material material)
    {
        NativeCalls.godot_icall_2_70(MethodBind7, GodotObject.GetPtr(this), surfIdx, GodotObject.GetPtr(material));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SurfaceGetMaterial, 2897466400ul);

    /// <summary>
    /// <para>Returns a <see cref="Godot.Material"/> in a given surface. Surface is rendered using this material.</para>
    /// <para><b>Note:</b> This returns the material within the <see cref="Godot.Mesh"/> resource, not the <see cref="Godot.Material"/> associated to the <see cref="Godot.MeshInstance3D"/>'s Surface Material Override properties. To get the <see cref="Godot.Material"/> associated to the <see cref="Godot.MeshInstance3D"/>'s Surface Material Override properties, use <see cref="Godot.MeshInstance3D.GetSurfaceOverrideMaterial(int)"/> instead.</para>
    /// </summary>
    public Material SurfaceGetMaterial(int surfIdx)
    {
        return (Material)NativeCalls.godot_icall_1_71(MethodBind8, GodotObject.GetPtr(this), surfIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CreatePlaceholder, 121922552ul);

    /// <summary>
    /// <para>Creates a placeholder version of this resource (<see cref="Godot.PlaceholderMesh"/>).</para>
    /// </summary>
    public Resource CreatePlaceholder()
    {
        return (Resource)NativeCalls.godot_icall_0_63(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CreateTrimeshShape, 4160111210ul);

    /// <summary>
    /// <para>Calculate a <see cref="Godot.ConcavePolygonShape3D"/> from the mesh.</para>
    /// </summary>
    public ConcavePolygonShape3D CreateTrimeshShape()
    {
        return (ConcavePolygonShape3D)NativeCalls.godot_icall_0_63(MethodBind10, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CreateConvexShape, 2529984628ul);

    /// <summary>
    /// <para>Calculate a <see cref="Godot.ConvexPolygonShape3D"/> from the mesh.</para>
    /// <para>If <paramref name="clean"/> is <see langword="true"/> (default), duplicate and interior vertices are removed automatically. You can set it to <see langword="false"/> to make the process faster if not needed.</para>
    /// <para>If <paramref name="simplify"/> is <see langword="true"/>, the geometry can be further simplified to reduce the number of vertices. Disabled by default.</para>
    /// </summary>
    public ConvexPolygonShape3D CreateConvexShape(bool clean = true, bool simplify = false)
    {
        return (ConvexPolygonShape3D)NativeCalls.godot_icall_2_790(MethodBind11, GodotObject.GetPtr(this), clean.ToGodotBool(), simplify.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CreateOutline, 1208642001ul);

    /// <summary>
    /// <para>Calculate an outline mesh at a defined offset (margin) from the original mesh.</para>
    /// <para><b>Note:</b> This method typically returns the vertices in reverse order (e.g. clockwise to counterclockwise).</para>
    /// </summary>
    public Mesh CreateOutline(float margin)
    {
        return (Mesh)NativeCalls.godot_icall_1_791(MethodBind12, GodotObject.GetPtr(this), margin);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GenerateTriangleMesh, 3476533166ul);

    /// <summary>
    /// <para>Generate a <see cref="Godot.TriangleMesh"/> from the mesh. Considers only surfaces using one of these primitive types: <see cref="Godot.Mesh.PrimitiveType.Triangles"/>, <see cref="Godot.Mesh.PrimitiveType.TriangleStrip"/>.</para>
    /// </summary>
    public TriangleMesh GenerateTriangleMesh()
    {
        return (TriangleMesh)NativeCalls.godot_icall_0_63(MethodBind13, GodotObject.GetPtr(this));
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_aabb = "_GetAabb";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_blend_shape_count = "_GetBlendShapeCount";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_blend_shape_name = "_GetBlendShapeName";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_surface_count = "_GetSurfaceCount";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__set_blend_shape_name = "_SetBlendShapeName";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__surface_get_array_index_len = "_SurfaceGetArrayIndexLen";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__surface_get_array_len = "_SurfaceGetArrayLen";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__surface_get_arrays = "_SurfaceGetArrays";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__surface_get_blend_shape_arrays = "_SurfaceGetBlendShapeArrays";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__surface_get_format = "_SurfaceGetFormat";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__surface_get_lods = "_SurfaceGetLods";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__surface_get_material = "_SurfaceGetMaterial";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__surface_get_primitive_type = "_SurfaceGetPrimitiveType";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__surface_set_material = "_SurfaceSetMaterial";

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
        if ((method == MethodProxyName__get_aabb || method == MethodName._GetAabb) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_aabb.NativeValue))
        {
            var callRet = _GetAabb();
            ret = VariantUtils.CreateFrom<Aabb>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_blend_shape_count || method == MethodName._GetBlendShapeCount) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_blend_shape_count.NativeValue))
        {
            var callRet = _GetBlendShapeCount();
            ret = VariantUtils.CreateFrom<int>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_blend_shape_name || method == MethodName._GetBlendShapeName) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_blend_shape_name.NativeValue))
        {
            var callRet = _GetBlendShapeName(VariantUtils.ConvertTo<int>(args[0]));
            ret = VariantUtils.CreateFrom<StringName>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_surface_count || method == MethodName._GetSurfaceCount) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_surface_count.NativeValue))
        {
            var callRet = _GetSurfaceCount();
            ret = VariantUtils.CreateFrom<int>(callRet);
            return true;
        }
        if ((method == MethodProxyName__set_blend_shape_name || method == MethodName._SetBlendShapeName) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__set_blend_shape_name.NativeValue))
        {
            _SetBlendShapeName(VariantUtils.ConvertTo<int>(args[0]), VariantUtils.ConvertTo<StringName>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__surface_get_array_index_len || method == MethodName._SurfaceGetArrayIndexLen) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__surface_get_array_index_len.NativeValue))
        {
            var callRet = _SurfaceGetArrayIndexLen(VariantUtils.ConvertTo<int>(args[0]));
            ret = VariantUtils.CreateFrom<int>(callRet);
            return true;
        }
        if ((method == MethodProxyName__surface_get_array_len || method == MethodName._SurfaceGetArrayLen) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__surface_get_array_len.NativeValue))
        {
            var callRet = _SurfaceGetArrayLen(VariantUtils.ConvertTo<int>(args[0]));
            ret = VariantUtils.CreateFrom<int>(callRet);
            return true;
        }
        if ((method == MethodProxyName__surface_get_arrays || method == MethodName._SurfaceGetArrays) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__surface_get_arrays.NativeValue))
        {
            var callRet = _SurfaceGetArrays(VariantUtils.ConvertTo<int>(args[0]));
            ret = VariantUtils.CreateFrom<Godot.Collections.Array>(callRet);
            return true;
        }
        if ((method == MethodProxyName__surface_get_blend_shape_arrays || method == MethodName._SurfaceGetBlendShapeArrays) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__surface_get_blend_shape_arrays.NativeValue))
        {
            var callRet = _SurfaceGetBlendShapeArrays(VariantUtils.ConvertTo<int>(args[0]));
            ret = VariantUtils.CreateFromArray(callRet);
            return true;
        }
        if ((method == MethodProxyName__surface_get_format || method == MethodName._SurfaceGetFormat) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__surface_get_format.NativeValue))
        {
            var callRet = _SurfaceGetFormat(VariantUtils.ConvertTo<int>(args[0]));
            ret = VariantUtils.CreateFrom<uint>(callRet);
            return true;
        }
        if ((method == MethodProxyName__surface_get_lods || method == MethodName._SurfaceGetLods) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__surface_get_lods.NativeValue))
        {
            var callRet = _SurfaceGetLods(VariantUtils.ConvertTo<int>(args[0]));
            ret = VariantUtils.CreateFrom<Godot.Collections.Dictionary>(callRet);
            return true;
        }
        if ((method == MethodProxyName__surface_get_material || method == MethodName._SurfaceGetMaterial) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__surface_get_material.NativeValue))
        {
            var callRet = _SurfaceGetMaterial(VariantUtils.ConvertTo<int>(args[0]));
            ret = VariantUtils.CreateFrom<Material>(callRet);
            return true;
        }
        if ((method == MethodProxyName__surface_get_primitive_type || method == MethodName._SurfaceGetPrimitiveType) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__surface_get_primitive_type.NativeValue))
        {
            var callRet = _SurfaceGetPrimitiveType(VariantUtils.ConvertTo<int>(args[0]));
            ret = VariantUtils.CreateFrom<uint>(callRet);
            return true;
        }
        if ((method == MethodProxyName__surface_set_material || method == MethodName._SurfaceSetMaterial) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__surface_set_material.NativeValue))
        {
            _SurfaceSetMaterial(VariantUtils.ConvertTo<int>(args[0]), VariantUtils.ConvertTo<Material>(args[1]));
            ret = default;
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
        if (method == MethodName._GetAabb)
        {
            if (HasGodotClassMethod(MethodProxyName__get_aabb.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetBlendShapeCount)
        {
            if (HasGodotClassMethod(MethodProxyName__get_blend_shape_count.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetBlendShapeName)
        {
            if (HasGodotClassMethod(MethodProxyName__get_blend_shape_name.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetSurfaceCount)
        {
            if (HasGodotClassMethod(MethodProxyName__get_surface_count.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._SetBlendShapeName)
        {
            if (HasGodotClassMethod(MethodProxyName__set_blend_shape_name.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._SurfaceGetArrayIndexLen)
        {
            if (HasGodotClassMethod(MethodProxyName__surface_get_array_index_len.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._SurfaceGetArrayLen)
        {
            if (HasGodotClassMethod(MethodProxyName__surface_get_array_len.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._SurfaceGetArrays)
        {
            if (HasGodotClassMethod(MethodProxyName__surface_get_arrays.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._SurfaceGetBlendShapeArrays)
        {
            if (HasGodotClassMethod(MethodProxyName__surface_get_blend_shape_arrays.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._SurfaceGetFormat)
        {
            if (HasGodotClassMethod(MethodProxyName__surface_get_format.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._SurfaceGetLods)
        {
            if (HasGodotClassMethod(MethodProxyName__surface_get_lods.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._SurfaceGetMaterial)
        {
            if (HasGodotClassMethod(MethodProxyName__surface_get_material.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._SurfaceGetPrimitiveType)
        {
            if (HasGodotClassMethod(MethodProxyName__surface_get_primitive_type.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._SurfaceSetMaterial)
        {
            if (HasGodotClassMethod(MethodProxyName__surface_set_material.NativeValue.DangerousSelfRef))
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
        return base.HasGodotClassSignal(signal);
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : Resource.PropertyName
    {
        /// <summary>
        /// Cached name for the 'lightmap_size_hint' property.
        /// </summary>
        public static readonly StringName LightmapSizeHint = "lightmap_size_hint";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Resource.MethodName
    {
        /// <summary>
        /// Cached name for the '_get_aabb' method.
        /// </summary>
        public static readonly StringName _GetAabb = "_get_aabb";
        /// <summary>
        /// Cached name for the '_get_blend_shape_count' method.
        /// </summary>
        public static readonly StringName _GetBlendShapeCount = "_get_blend_shape_count";
        /// <summary>
        /// Cached name for the '_get_blend_shape_name' method.
        /// </summary>
        public static readonly StringName _GetBlendShapeName = "_get_blend_shape_name";
        /// <summary>
        /// Cached name for the '_get_surface_count' method.
        /// </summary>
        public static readonly StringName _GetSurfaceCount = "_get_surface_count";
        /// <summary>
        /// Cached name for the '_set_blend_shape_name' method.
        /// </summary>
        public static readonly StringName _SetBlendShapeName = "_set_blend_shape_name";
        /// <summary>
        /// Cached name for the '_surface_get_array_index_len' method.
        /// </summary>
        public static readonly StringName _SurfaceGetArrayIndexLen = "_surface_get_array_index_len";
        /// <summary>
        /// Cached name for the '_surface_get_array_len' method.
        /// </summary>
        public static readonly StringName _SurfaceGetArrayLen = "_surface_get_array_len";
        /// <summary>
        /// Cached name for the '_surface_get_arrays' method.
        /// </summary>
        public static readonly StringName _SurfaceGetArrays = "_surface_get_arrays";
        /// <summary>
        /// Cached name for the '_surface_get_blend_shape_arrays' method.
        /// </summary>
        public static readonly StringName _SurfaceGetBlendShapeArrays = "_surface_get_blend_shape_arrays";
        /// <summary>
        /// Cached name for the '_surface_get_format' method.
        /// </summary>
        public static readonly StringName _SurfaceGetFormat = "_surface_get_format";
        /// <summary>
        /// Cached name for the '_surface_get_lods' method.
        /// </summary>
        public static readonly StringName _SurfaceGetLods = "_surface_get_lods";
        /// <summary>
        /// Cached name for the '_surface_get_material' method.
        /// </summary>
        public static readonly StringName _SurfaceGetMaterial = "_surface_get_material";
        /// <summary>
        /// Cached name for the '_surface_get_primitive_type' method.
        /// </summary>
        public static readonly StringName _SurfaceGetPrimitiveType = "_surface_get_primitive_type";
        /// <summary>
        /// Cached name for the '_surface_set_material' method.
        /// </summary>
        public static readonly StringName _SurfaceSetMaterial = "_surface_set_material";
        /// <summary>
        /// Cached name for the 'set_lightmap_size_hint' method.
        /// </summary>
        public static readonly StringName SetLightmapSizeHint = "set_lightmap_size_hint";
        /// <summary>
        /// Cached name for the 'get_lightmap_size_hint' method.
        /// </summary>
        public static readonly StringName GetLightmapSizeHint = "get_lightmap_size_hint";
        /// <summary>
        /// Cached name for the 'get_aabb' method.
        /// </summary>
        public static readonly StringName GetAabb = "get_aabb";
        /// <summary>
        /// Cached name for the 'get_faces' method.
        /// </summary>
        public static readonly StringName GetFaces = "get_faces";
        /// <summary>
        /// Cached name for the 'get_surface_count' method.
        /// </summary>
        public static readonly StringName GetSurfaceCount = "get_surface_count";
        /// <summary>
        /// Cached name for the 'surface_get_arrays' method.
        /// </summary>
        public static readonly StringName SurfaceGetArrays = "surface_get_arrays";
        /// <summary>
        /// Cached name for the 'surface_get_blend_shape_arrays' method.
        /// </summary>
        public static readonly StringName SurfaceGetBlendShapeArrays = "surface_get_blend_shape_arrays";
        /// <summary>
        /// Cached name for the 'surface_set_material' method.
        /// </summary>
        public static readonly StringName SurfaceSetMaterial = "surface_set_material";
        /// <summary>
        /// Cached name for the 'surface_get_material' method.
        /// </summary>
        public static readonly StringName SurfaceGetMaterial = "surface_get_material";
        /// <summary>
        /// Cached name for the 'create_placeholder' method.
        /// </summary>
        public static readonly StringName CreatePlaceholder = "create_placeholder";
        /// <summary>
        /// Cached name for the 'create_trimesh_shape' method.
        /// </summary>
        public static readonly StringName CreateTrimeshShape = "create_trimesh_shape";
        /// <summary>
        /// Cached name for the 'create_convex_shape' method.
        /// </summary>
        public static readonly StringName CreateConvexShape = "create_convex_shape";
        /// <summary>
        /// Cached name for the 'create_outline' method.
        /// </summary>
        public static readonly StringName CreateOutline = "create_outline";
        /// <summary>
        /// Cached name for the 'generate_triangle_mesh' method.
        /// </summary>
        public static readonly StringName GenerateTriangleMesh = "generate_triangle_mesh";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Resource.SignalName
    {
    }
}
