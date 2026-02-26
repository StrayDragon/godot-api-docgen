namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>ImporterMesh is a type of <see cref="Godot.Resource"/> analogous to <see cref="Godot.ArrayMesh"/>. It contains vertex array-based geometry, divided in <i>surfaces</i>. Each surface contains a completely separate array and a material used to draw it. Design wise, a mesh with multiple surfaces is preferred to a single surface, because objects created in 3D editing software commonly contain multiple materials.</para>
/// <para>Unlike its runtime counterpart, <see cref="Godot.ImporterMesh"/> contains mesh data before various import steps, such as lod and shadow mesh generation, have taken place. Modify surface data by calling <see cref="Godot.ImporterMesh.Clear()"/>, followed by <see cref="Godot.ImporterMesh.AddSurface(Mesh.PrimitiveType, Godot.Collections.Array, Godot.Collections.Array{Godot.Collections.Array}, Godot.Collections.Dictionary, Material, string, ulong)"/> for each surface.</para>
/// </summary>
public partial class ImporterMesh : Resource
{
    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public Godot.Collections.Dictionary _Data
    {
        get
        {
            return _GetData();
        }
        set
        {
            _SetData(value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    private static readonly System.Type CachedType = typeof(ImporterMesh);

    private static readonly StringName NativeName = "ImporterMesh";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public ImporterMesh() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal ImporterMesh(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal ImporterMesh(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddBlendShape, 83702148ul);

    /// <summary>
    /// <para>Adds name for a blend shape that will be added with <see cref="Godot.ImporterMesh.AddSurface(Mesh.PrimitiveType, Godot.Collections.Array, Godot.Collections.Array{Godot.Collections.Array}, Godot.Collections.Dictionary, Material, string, ulong)"/>. Must be called before surface is added.</para>
    /// </summary>
    public void AddBlendShape(string name)
    {
        NativeCalls.godot_icall_1_57(MethodBind0, GodotObject.GetPtr(this), name);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBlendShapeCount, 3905245786ul);

    /// <summary>
    /// <para>Returns the number of blend shapes that the mesh holds.</para>
    /// </summary>
    public int GetBlendShapeCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBlendShapeName, 844755477ul);

    /// <summary>
    /// <para>Returns the name of the blend shape at this index.</para>
    /// </summary>
    public string GetBlendShapeName(int blendShapeIdx)
    {
        return NativeCalls.godot_icall_1_133(MethodBind2, GodotObject.GetPtr(this), blendShapeIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBlendShapeMode, 227983991ul);

    /// <summary>
    /// <para>Sets the blend shape mode.</para>
    /// </summary>
    public void SetBlendShapeMode(Mesh.BlendShapeMode mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind3, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBlendShapeMode, 836485024ul);

    /// <summary>
    /// <para>Returns the blend shape mode for this Mesh.</para>
    /// </summary>
    public Mesh.BlendShapeMode GetBlendShapeMode()
    {
        return (Mesh.BlendShapeMode)NativeCalls.godot_icall_0_39(MethodBind4, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddSurface, 1740448849ul);

    /// <summary>
    /// <para>Creates a new surface. <see cref="Godot.Mesh.GetSurfaceCount()"/> will become the <c>surf_idx</c> for this new surface.</para>
    /// <para>Surfaces are created to be rendered using a <paramref name="primitive"/>, which may be any of the values defined in <see cref="Godot.Mesh.PrimitiveType"/>.</para>
    /// <para>The <paramref name="arrays"/> argument is an array of arrays. Each of the <see cref="Godot.Mesh.ArrayType.Max"/> elements contains an array with some of the mesh data for this surface as described by the corresponding member of <see cref="Godot.Mesh.ArrayType"/> or <see langword="null"/> if it is not used by the surface. For example, <c>arrays[0]</c> is the array of vertices. That first vertex sub-array is always required; the others are optional. Adding an index array puts this surface into "index mode" where the vertex and other arrays become the sources of data and the index array defines the vertex order. All sub-arrays must have the same length as the vertex array (or be an exact multiple of the vertex array's length, when multiple elements of a sub-array correspond to a single vertex) or be empty, except for <see cref="Godot.Mesh.ArrayType.Index"/> if it is used.</para>
    /// <para>The <paramref name="blendShapes"/> argument is an array of vertex data for each blend shape. Each element is an array of the same structure as <paramref name="arrays"/>, but <see cref="Godot.Mesh.ArrayType.Vertex"/>, <see cref="Godot.Mesh.ArrayType.Normal"/>, and <see cref="Godot.Mesh.ArrayType.Tangent"/> are set if and only if they are set in <paramref name="arrays"/> and all other entries are <see langword="null"/>.</para>
    /// <para>The <paramref name="lods"/> argument is a dictionary with <see cref="float"/> keys and <see cref="int"/>[] values. Each entry in the dictionary represents an LOD level of the surface, where the value is the <see cref="Godot.Mesh.ArrayType.Index"/> array to use for the LOD level and the key is roughly proportional to the distance at which the LOD stats being used. I.e., increasing the key of an LOD also increases the distance that the objects has to be from the camera before the LOD is used.</para>
    /// <para>The <paramref name="flags"/> argument is the bitwise OR of, as required: One value of <see cref="Godot.Mesh.ArrayCustomFormat"/> left shifted by <c>ARRAY_FORMAT_CUSTOMn_SHIFT</c> for each custom channel in use, <see cref="Godot.Mesh.ArrayFormat.FlagUseDynamicUpdate"/>, <see cref="Godot.Mesh.ArrayFormat.FlagUse8BoneWeights"/>, or <see cref="Godot.Mesh.ArrayFormat.FlagUsesEmptyVertexArray"/>.</para>
    /// <para><b>Note:</b> When using indices, it is recommended to only use points, lines, or triangles.</para>
    /// </summary>
    public void AddSurface(Mesh.PrimitiveType primitive, Godot.Collections.Array arrays, Godot.Collections.Array<Godot.Collections.Array> blendShapes = null, Godot.Collections.Dictionary lods = null, Material material = null, string name = "", ulong flags = (ulong)(0))
    {
        NativeCalls.godot_icall_7_742(MethodBind5, GodotObject.GetPtr(this), (int)primitive, (godot_array)(arrays ?? new()).NativeValue, (godot_array)(blendShapes ?? new()).NativeValue, (godot_dictionary)(lods ?? new()).NativeValue, GodotObject.GetPtr(material), name, flags);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSurfaceCount, 3905245786ul);

    /// <summary>
    /// <para>Returns the number of surfaces that the mesh holds.</para>
    /// </summary>
    public int GetSurfaceCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind6, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSurfacePrimitiveType, 3552571330ul);

    /// <summary>
    /// <para>Returns the primitive type of the requested surface (see <see cref="Godot.ImporterMesh.AddSurface(Mesh.PrimitiveType, Godot.Collections.Array, Godot.Collections.Array{Godot.Collections.Array}, Godot.Collections.Dictionary, Material, string, ulong)"/>).</para>
    /// </summary>
    public Mesh.PrimitiveType GetSurfacePrimitiveType(int surfaceIdx)
    {
        return (Mesh.PrimitiveType)NativeCalls.godot_icall_1_60(MethodBind7, GodotObject.GetPtr(this), surfaceIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSurfaceName, 844755477ul);

    /// <summary>
    /// <para>Gets the name assigned to this surface.</para>
    /// </summary>
    public string GetSurfaceName(int surfaceIdx)
    {
        return NativeCalls.godot_icall_1_133(MethodBind8, GodotObject.GetPtr(this), surfaceIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSurfaceArrays, 663333327ul);

    /// <summary>
    /// <para>Returns the arrays for the vertices, normals, UVs, etc. that make up the requested surface. See <see cref="Godot.ImporterMesh.AddSurface(Mesh.PrimitiveType, Godot.Collections.Array, Godot.Collections.Array{Godot.Collections.Array}, Godot.Collections.Dictionary, Material, string, ulong)"/>.</para>
    /// </summary>
    public Godot.Collections.Array GetSurfaceArrays(int surfaceIdx)
    {
        return NativeCalls.godot_icall_1_457(MethodBind9, GodotObject.GetPtr(this), surfaceIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSurfaceBlendShapeArrays, 2345056839ul);

    /// <summary>
    /// <para>Returns a single set of blend shape arrays for the requested blend shape index for a surface.</para>
    /// </summary>
    public Godot.Collections.Array GetSurfaceBlendShapeArrays(int surfaceIdx, int blendShapeIdx)
    {
        return NativeCalls.godot_icall_2_94(MethodBind10, GodotObject.GetPtr(this), surfaceIdx, blendShapeIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSurfaceLodCount, 923996154ul);

    /// <summary>
    /// <para>Returns the number of lods that the mesh holds on a given surface.</para>
    /// </summary>
    public int GetSurfaceLodCount(int surfaceIdx)
    {
        return NativeCalls.godot_icall_1_60(MethodBind11, GodotObject.GetPtr(this), surfaceIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSurfaceLodSize, 3085491603ul);

    /// <summary>
    /// <para>Returns the screen ratio which activates a lod for a surface.</para>
    /// </summary>
    public float GetSurfaceLodSize(int surfaceIdx, int lodIdx)
    {
        return NativeCalls.godot_icall_2_88(MethodBind12, GodotObject.GetPtr(this), surfaceIdx, lodIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSurfaceLodIndices, 1265128013ul);

    /// <summary>
    /// <para>Returns the index buffer of a lod for a surface.</para>
    /// </summary>
    public int[] GetSurfaceLodIndices(int surfaceIdx, int lodIdx)
    {
        return NativeCalls.godot_icall_2_743(MethodBind13, GodotObject.GetPtr(this), surfaceIdx, lodIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSurfaceMaterial, 2897466400ul);

    /// <summary>
    /// <para>Returns a <see cref="Godot.Material"/> in a given surface. Surface is rendered using this material.</para>
    /// </summary>
    public Material GetSurfaceMaterial(int surfaceIdx)
    {
        return (Material)NativeCalls.godot_icall_1_71(MethodBind14, GodotObject.GetPtr(this), surfaceIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSurfaceFormat, 923996154ul);

    /// <summary>
    /// <para>Returns the format of the surface that the mesh holds.</para>
    /// </summary>
    public ulong GetSurfaceFormat(int surfaceIdx)
    {
        return NativeCalls.godot_icall_1_240(MethodBind15, GodotObject.GetPtr(this), surfaceIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSurfaceName, 501894301ul);

    /// <summary>
    /// <para>Sets a name for a given surface.</para>
    /// </summary>
    public void SetSurfaceName(int surfaceIdx, string name)
    {
        NativeCalls.godot_icall_2_181(MethodBind16, GodotObject.GetPtr(this), surfaceIdx, name);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSurfaceMaterial, 3671737478ul);

    /// <summary>
    /// <para>Sets a <see cref="Godot.Material"/> for a given surface. Surface will be rendered using this material.</para>
    /// </summary>
    public void SetSurfaceMaterial(int surfaceIdx, Material material)
    {
        NativeCalls.godot_icall_2_70(MethodBind17, GodotObject.GetPtr(this), surfaceIdx, GodotObject.GetPtr(material));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GenerateLods, 2491878677ul);

    /// <summary>
    /// <para>Generates all lods for this ImporterMesh.</para>
    /// <para><paramref name="normalMergeAngle"/> is in degrees and used in the same way as the importer settings in <c>lods</c>.</para>
    /// <para><paramref name="normalSplitAngle"/> is not used and only remains for compatibility with older versions of the API.</para>
    /// <para>The number of generated lods can be accessed using <see cref="Godot.ImporterMesh.GetSurfaceLodCount(int)"/>, and each LOD is available in <see cref="Godot.ImporterMesh.GetSurfaceLodSize(int, int)"/> and <see cref="Godot.ImporterMesh.GetSurfaceLodIndices(int, int)"/>.</para>
    /// <para><paramref name="boneTransformArray"/> is an <see cref="Godot.Collections.Array"/> which can be either empty or contain <see cref="Godot.Transform3D"/>s which, for each of the mesh's bone IDs, will apply mesh skinning when generating the LOD mesh variations. This is usually used to account for discrepancies in scale between the mesh itself and its skinning data.</para>
    /// </summary>
    public void GenerateLods(float normalMergeAngle, float normalSplitAngle, Godot.Collections.Array boneTransformArray)
    {
        NativeCalls.godot_icall_3_744(MethodBind18, GodotObject.GetPtr(this), normalMergeAngle, normalSplitAngle, (godot_array)(boneTransformArray ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMesh, 1457573577ul);

    /// <summary>
    /// <para>Returns the mesh data represented by this <see cref="Godot.ImporterMesh"/> as a usable <see cref="Godot.ArrayMesh"/>.</para>
    /// <para>This method caches the returned mesh, and subsequent calls will return the cached data until <see cref="Godot.ImporterMesh.Clear()"/> is called.</para>
    /// <para>If not yet cached and <paramref name="baseMesh"/> is provided, <paramref name="baseMesh"/> will be used and mutated.</para>
    /// </summary>
    public ArrayMesh GetMesh(ArrayMesh baseMesh = null)
    {
        return (ArrayMesh)NativeCalls.godot_icall_1_268(MethodBind19, GodotObject.GetPtr(this), GodotObject.GetPtr(baseMesh));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FromMesh, 283226343ul);

    /// <summary>
    /// <para>Converts the given <see cref="Godot.Mesh"/> into an <see cref="Godot.ImporterMesh"/> by copying all its surfaces, blend shapes, materials, and metadata into a new <see cref="Godot.ImporterMesh"/> object.</para>
    /// </summary>
    public static ImporterMesh FromMesh(Mesh mesh)
    {
        return (ImporterMesh)NativeCalls.godot_icall_1_637(MethodBind20, GodotObject.GetPtr(mesh));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Clear, 3218959716ul);

    /// <summary>
    /// <para>Removes all surfaces and blend shapes from this <see cref="Godot.ImporterMesh"/>.</para>
    /// </summary>
    public void Clear()
    {
        NativeCalls.godot_icall_0_3(MethodBind21, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName._SetData, 4155329257ul);

    internal void _SetData(Godot.Collections.Dictionary data)
    {
        NativeCalls.godot_icall_1_121(MethodBind22, GodotObject.GetPtr(this), (godot_dictionary)(data ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName._GetData, 3102165223ul);

    internal Godot.Collections.Dictionary _GetData()
    {
        return NativeCalls.godot_icall_0_122(MethodBind23, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLightmapSizeHint, 1130785943ul);

    /// <summary>
    /// <para>Sets the size hint of this mesh for lightmap-unwrapping in UV-space.</para>
    /// </summary>
    public unsafe void SetLightmapSizeHint(Vector2I size)
    {
        NativeCalls.godot_icall_1_34(MethodBind24, GodotObject.GetPtr(this), &size);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLightmapSizeHint, 3690982128ul);

    /// <summary>
    /// <para>Returns the size hint of this mesh for lightmap-unwrapping in UV-space.</para>
    /// </summary>
    public Vector2I GetLightmapSizeHint()
    {
        return NativeCalls.godot_icall_0_35(MethodBind25, GodotObject.GetPtr(this));
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
        /// Cached name for the '_data' property.
        /// </summary>
        public static readonly StringName _Data = "_data";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Resource.MethodName
    {
        /// <summary>
        /// Cached name for the 'add_blend_shape' method.
        /// </summary>
        public static readonly StringName AddBlendShape = "add_blend_shape";
        /// <summary>
        /// Cached name for the 'get_blend_shape_count' method.
        /// </summary>
        public static readonly StringName GetBlendShapeCount = "get_blend_shape_count";
        /// <summary>
        /// Cached name for the 'get_blend_shape_name' method.
        /// </summary>
        public static readonly StringName GetBlendShapeName = "get_blend_shape_name";
        /// <summary>
        /// Cached name for the 'set_blend_shape_mode' method.
        /// </summary>
        public static readonly StringName SetBlendShapeMode = "set_blend_shape_mode";
        /// <summary>
        /// Cached name for the 'get_blend_shape_mode' method.
        /// </summary>
        public static readonly StringName GetBlendShapeMode = "get_blend_shape_mode";
        /// <summary>
        /// Cached name for the 'add_surface' method.
        /// </summary>
        public static readonly StringName AddSurface = "add_surface";
        /// <summary>
        /// Cached name for the 'get_surface_count' method.
        /// </summary>
        public static readonly StringName GetSurfaceCount = "get_surface_count";
        /// <summary>
        /// Cached name for the 'get_surface_primitive_type' method.
        /// </summary>
        public static readonly StringName GetSurfacePrimitiveType = "get_surface_primitive_type";
        /// <summary>
        /// Cached name for the 'get_surface_name' method.
        /// </summary>
        public static readonly StringName GetSurfaceName = "get_surface_name";
        /// <summary>
        /// Cached name for the 'get_surface_arrays' method.
        /// </summary>
        public static readonly StringName GetSurfaceArrays = "get_surface_arrays";
        /// <summary>
        /// Cached name for the 'get_surface_blend_shape_arrays' method.
        /// </summary>
        public static readonly StringName GetSurfaceBlendShapeArrays = "get_surface_blend_shape_arrays";
        /// <summary>
        /// Cached name for the 'get_surface_lod_count' method.
        /// </summary>
        public static readonly StringName GetSurfaceLodCount = "get_surface_lod_count";
        /// <summary>
        /// Cached name for the 'get_surface_lod_size' method.
        /// </summary>
        public static readonly StringName GetSurfaceLodSize = "get_surface_lod_size";
        /// <summary>
        /// Cached name for the 'get_surface_lod_indices' method.
        /// </summary>
        public static readonly StringName GetSurfaceLodIndices = "get_surface_lod_indices";
        /// <summary>
        /// Cached name for the 'get_surface_material' method.
        /// </summary>
        public static readonly StringName GetSurfaceMaterial = "get_surface_material";
        /// <summary>
        /// Cached name for the 'get_surface_format' method.
        /// </summary>
        public static readonly StringName GetSurfaceFormat = "get_surface_format";
        /// <summary>
        /// Cached name for the 'set_surface_name' method.
        /// </summary>
        public static readonly StringName SetSurfaceName = "set_surface_name";
        /// <summary>
        /// Cached name for the 'set_surface_material' method.
        /// </summary>
        public static readonly StringName SetSurfaceMaterial = "set_surface_material";
        /// <summary>
        /// Cached name for the 'generate_lods' method.
        /// </summary>
        public static readonly StringName GenerateLods = "generate_lods";
        /// <summary>
        /// Cached name for the 'get_mesh' method.
        /// </summary>
        public static readonly StringName GetMesh = "get_mesh";
        /// <summary>
        /// Cached name for the 'from_mesh' method.
        /// </summary>
        public static readonly StringName FromMesh = "from_mesh";
        /// <summary>
        /// Cached name for the 'clear' method.
        /// </summary>
        public static readonly StringName Clear = "clear";
        /// <summary>
        /// Cached name for the '_set_data' method.
        /// </summary>
        public static readonly StringName _SetData = "_set_data";
        /// <summary>
        /// Cached name for the '_get_data' method.
        /// </summary>
        public static readonly StringName _GetData = "_get_data";
        /// <summary>
        /// Cached name for the 'set_lightmap_size_hint' method.
        /// </summary>
        public static readonly StringName SetLightmapSizeHint = "set_lightmap_size_hint";
        /// <summary>
        /// Cached name for the 'get_lightmap_size_hint' method.
        /// </summary>
        public static readonly StringName GetLightmapSizeHint = "get_lightmap_size_hint";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Resource.SignalName
    {
    }
}
