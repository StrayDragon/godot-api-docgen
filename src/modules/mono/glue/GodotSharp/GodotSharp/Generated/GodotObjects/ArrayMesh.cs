namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>The <see cref="Godot.ArrayMesh"/> is used to construct a <see cref="Godot.Mesh"/> by specifying the attributes as arrays.</para>
/// <para>The most basic example is the creation of a single triangle:</para>
/// <para><code>
/// Vector3[] vertices =
/// [
/// 	new Vector3(0, 1, 0),
/// 	new Vector3(1, 0, 0),
/// 	new Vector3(0, 0, 1),
/// ];
/// 
/// // Initialize the ArrayMesh.
/// var arrMesh = new ArrayMesh();
/// Godot.Collections.Array arrays = [];
/// arrays.Resize((int)Mesh.ArrayType.Max);
/// arrays[(int)Mesh.ArrayType.Vertex] = vertices;
/// 
/// // Create the Mesh.
/// arrMesh.AddSurfaceFromArrays(Mesh.PrimitiveType.Triangles, arrays);
/// var m = new MeshInstance3D();
/// m.Mesh = arrMesh;
/// </code></para>
/// <para>The <see cref="Godot.MeshInstance3D"/> is ready to be added to the <see cref="Godot.SceneTree"/> to be shown.</para>
/// <para>See also <see cref="Godot.ImmediateMesh"/>, <see cref="Godot.MeshDataTool"/> and <see cref="Godot.SurfaceTool"/> for procedural geometry generation.</para>
/// <para><b>Note:</b> Godot uses clockwise <a href="https://learnopengl.com/Advanced-OpenGL/Face-culling">winding order</a> for front faces of triangle primitive modes.</para>
/// </summary>
public partial class ArrayMesh : Mesh
{
    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public string[] _BlendShapeNames
    {
        get
        {
            return _GetBlendShapeNames();
        }
        set
        {
            _SetBlendShapeNames(value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public Godot.Collections.Array _Surfaces
    {
        get
        {
            return _GetSurfaces();
        }
        set
        {
            _SetSurfaces(value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    /// <summary>
    /// <para>The blend shape mode.</para>
    /// </summary>
    public new Mesh.BlendShapeMode BlendShapeMode
    {
        get
        {
            return GetBlendShapeMode();
        }
        set
        {
            SetBlendShapeMode(value);
        }
    }

    /// <summary>
    /// <para>Overrides the <see cref="Godot.Aabb"/> with one defined by user for use with frustum culling. Especially useful to avoid unexpected culling when using a shader to offset vertices.</para>
    /// </summary>
    public Aabb CustomAabb
    {
        get
        {
            return GetCustomAabb();
        }
        set
        {
            SetCustomAabb(value);
        }
    }

    /// <summary>
    /// <para>An optional mesh which can be used for rendering shadows and the depth prepass. Can be used to increase performance by supplying a mesh with fused vertices and only vertex position data (without normals, UVs, colors, etc.).</para>
    /// <para><b>Note:</b> This mesh must have exactly the same vertex positions as the source mesh (including the source mesh's LODs, if present). If vertex positions differ, then the mesh will not draw correctly.</para>
    /// </summary>
    public ArrayMesh ShadowMesh
    {
        get
        {
            return GetShadowMesh();
        }
        set
        {
            SetShadowMesh(value);
        }
    }

    private static readonly System.Type CachedType = typeof(ArrayMesh);

    private static readonly StringName NativeName = "ArrayMesh";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public ArrayMesh() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal ArrayMesh(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal ArrayMesh(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddBlendShape, 3304788590ul);

    /// <summary>
    /// <para>Adds name for a blend shape that will be added with <see cref="Godot.ArrayMesh.AddSurfaceFromArrays(Mesh.PrimitiveType, Godot.Collections.Array, Godot.Collections.Array{Godot.Collections.Array}, Godot.Collections.Dictionary, Mesh.ArrayFormat)"/>. Must be called before surface is added.</para>
    /// </summary>
    public void AddBlendShape(StringName name)
    {
        NativeCalls.godot_icall_1_64(MethodBind0, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBlendShapeCount, 3905245786ul);

    /// <summary>
    /// <para>Returns the number of blend shapes that the <see cref="Godot.ArrayMesh"/> holds.</para>
    /// </summary>
    public int GetBlendShapeCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBlendShapeName, 659327637ul);

    /// <summary>
    /// <para>Returns the name of the blend shape at this index.</para>
    /// </summary>
    public StringName GetBlendShapeName(int index)
    {
        return NativeCalls.godot_icall_1_162(MethodBind2, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBlendShapeName, 3780747571ul);

    /// <summary>
    /// <para>Sets the name of the blend shape at this index.</para>
    /// </summary>
    public void SetBlendShapeName(int index, StringName name)
    {
        NativeCalls.godot_icall_2_178(MethodBind3, GodotObject.GetPtr(this), index, (godot_string_name)(name?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ClearBlendShapes, 3218959716ul);

    /// <summary>
    /// <para>Removes all blend shapes from this <see cref="Godot.ArrayMesh"/>.</para>
    /// </summary>
    public void ClearBlendShapes()
    {
        NativeCalls.godot_icall_0_3(MethodBind4, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBlendShapeMode, 227983991ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetBlendShapeMode(Mesh.BlendShapeMode mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind5, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBlendShapeMode, 836485024ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Mesh.BlendShapeMode GetBlendShapeMode()
    {
        return (Mesh.BlendShapeMode)NativeCalls.godot_icall_0_39(MethodBind6, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddSurfaceFromArrays, 1796411378ul);

    /// <summary>
    /// <para>Creates a new surface. <see cref="Godot.Mesh.GetSurfaceCount()"/> will become the <c>surf_idx</c> for this new surface.</para>
    /// <para>Surfaces are created to be rendered using a <paramref name="primitive"/>, which may be any of the values defined in <see cref="Godot.Mesh.PrimitiveType"/>.</para>
    /// <para>The <paramref name="arrays"/> argument is an array of arrays. Each of the <see cref="Godot.Mesh.ArrayType.Max"/> elements contains an array with some of the mesh data for this surface as described by the corresponding member of <see cref="Godot.Mesh.ArrayType"/> or <see langword="null"/> if it is not used by the surface. For example, <c>arrays[0]</c> is the array of vertices. That first vertex sub-array is always required; the others are optional. Adding an index array puts this surface into "index mode" where the vertex and other arrays become the sources of data and the index array defines the vertex order. All sub-arrays must have the same length as the vertex array (or be an exact multiple of the vertex array's length, when multiple elements of a sub-array correspond to a single vertex) or be empty, except for <see cref="Godot.Mesh.ArrayType.Index"/> if it is used.</para>
    /// <para>The <paramref name="blendShapes"/> argument is an array of vertex data for each blend shape. Each element is an array of the same structure as <paramref name="arrays"/>, but <see cref="Godot.Mesh.ArrayType.Vertex"/>, <see cref="Godot.Mesh.ArrayType.Normal"/>, and <see cref="Godot.Mesh.ArrayType.Tangent"/> are set if and only if they are set in <paramref name="arrays"/> and all other entries are <see langword="null"/>.</para>
    /// <para>The <paramref name="lods"/> argument is a dictionary with <see cref="float"/> keys and <see cref="int"/>[] values. Each entry in the dictionary represents an LOD level of the surface, where the value is the <see cref="Godot.Mesh.ArrayType.Index"/> array to use for the LOD level and the key is roughly proportional to the distance at which the LOD stats being used. I.e., increasing the key of an LOD also increases the distance that the objects has to be from the camera before the LOD is used.</para>
    /// <para>The <paramref name="flags"/> argument is the bitwise OR of, as required: One value of <see cref="Godot.Mesh.ArrayCustomFormat"/> left shifted by <c>ARRAY_FORMAT_CUSTOMn_SHIFT</c> for each custom channel in use, <see cref="Godot.Mesh.ArrayFormat.FlagUseDynamicUpdate"/>, <see cref="Godot.Mesh.ArrayFormat.FlagUse8BoneWeights"/>, or <see cref="Godot.Mesh.ArrayFormat.FlagUsesEmptyVertexArray"/>.</para>
    /// <para><b>Note:</b> When using indices, it is recommended to only use points, lines, or triangles.</para>
    /// </summary>
    public void AddSurfaceFromArrays(Mesh.PrimitiveType primitive, Godot.Collections.Array arrays, Godot.Collections.Array<Godot.Collections.Array> blendShapes = null, Godot.Collections.Dictionary lods = null, Mesh.ArrayFormat flags = (Mesh.ArrayFormat)(0))
    {
        NativeCalls.godot_icall_5_179(MethodBind7, GodotObject.GetPtr(this), (int)primitive, (godot_array)(arrays ?? new()).NativeValue, (godot_array)(blendShapes ?? new()).NativeValue, (godot_dictionary)(lods ?? new()).NativeValue, (int)flags);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ClearSurfaces, 3218959716ul);

    /// <summary>
    /// <para>Removes all surfaces from this <see cref="Godot.ArrayMesh"/>.</para>
    /// </summary>
    public void ClearSurfaces()
    {
        NativeCalls.godot_icall_0_3(MethodBind8, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SurfaceRemove, 1286410249ul);

    /// <summary>
    /// <para>Removes the surface at the given index from the Mesh, shifting surfaces with higher index down by one.</para>
    /// </summary>
    public void SurfaceRemove(int surfIdx)
    {
        NativeCalls.godot_icall_1_38(MethodBind9, GodotObject.GetPtr(this), surfIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SurfaceUpdateVertexRegion, 3837166854ul);

    public void SurfaceUpdateVertexRegion(int surfIdx, int offset, byte[] data)
    {
        NativeCalls.godot_icall_3_180(MethodBind10, GodotObject.GetPtr(this), surfIdx, offset, data);
    }

    public void SurfaceUpdateVertexRegion(int surfIdx, int offset, ReadOnlySpan<byte> data)
    {
        NativeCalls.godot_icall_3_180(MethodBind10, GodotObject.GetPtr(this), surfIdx, offset, data);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SurfaceUpdateAttributeRegion, 3837166854ul);

    public void SurfaceUpdateAttributeRegion(int surfIdx, int offset, byte[] data)
    {
        NativeCalls.godot_icall_3_180(MethodBind11, GodotObject.GetPtr(this), surfIdx, offset, data);
    }

    public void SurfaceUpdateAttributeRegion(int surfIdx, int offset, ReadOnlySpan<byte> data)
    {
        NativeCalls.godot_icall_3_180(MethodBind11, GodotObject.GetPtr(this), surfIdx, offset, data);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SurfaceUpdateSkinRegion, 3837166854ul);

    public void SurfaceUpdateSkinRegion(int surfIdx, int offset, byte[] data)
    {
        NativeCalls.godot_icall_3_180(MethodBind12, GodotObject.GetPtr(this), surfIdx, offset, data);
    }

    public void SurfaceUpdateSkinRegion(int surfIdx, int offset, ReadOnlySpan<byte> data)
    {
        NativeCalls.godot_icall_3_180(MethodBind12, GodotObject.GetPtr(this), surfIdx, offset, data);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SurfaceGetArrayLen, 923996154ul);

    /// <summary>
    /// <para>Returns the length in vertices of the vertex array in the requested surface (see <see cref="Godot.ArrayMesh.AddSurfaceFromArrays(Mesh.PrimitiveType, Godot.Collections.Array, Godot.Collections.Array{Godot.Collections.Array}, Godot.Collections.Dictionary, Mesh.ArrayFormat)"/>).</para>
    /// </summary>
    public int SurfaceGetArrayLen(int surfIdx)
    {
        return NativeCalls.godot_icall_1_60(MethodBind13, GodotObject.GetPtr(this), surfIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SurfaceGetArrayIndexLen, 923996154ul);

    /// <summary>
    /// <para>Returns the length in indices of the index array in the requested surface (see <see cref="Godot.ArrayMesh.AddSurfaceFromArrays(Mesh.PrimitiveType, Godot.Collections.Array, Godot.Collections.Array{Godot.Collections.Array}, Godot.Collections.Dictionary, Mesh.ArrayFormat)"/>).</para>
    /// </summary>
    public int SurfaceGetArrayIndexLen(int surfIdx)
    {
        return NativeCalls.godot_icall_1_60(MethodBind14, GodotObject.GetPtr(this), surfIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SurfaceGetFormat, 3718287884ul);

    /// <summary>
    /// <para>Returns the format mask of the requested surface (see <see cref="Godot.ArrayMesh.AddSurfaceFromArrays(Mesh.PrimitiveType, Godot.Collections.Array, Godot.Collections.Array{Godot.Collections.Array}, Godot.Collections.Dictionary, Mesh.ArrayFormat)"/>).</para>
    /// </summary>
    public Mesh.ArrayFormat SurfaceGetFormat(int surfIdx)
    {
        return (Mesh.ArrayFormat)NativeCalls.godot_icall_1_60(MethodBind15, GodotObject.GetPtr(this), surfIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SurfaceGetPrimitiveType, 4141943888ul);

    /// <summary>
    /// <para>Returns the primitive type of the requested surface (see <see cref="Godot.ArrayMesh.AddSurfaceFromArrays(Mesh.PrimitiveType, Godot.Collections.Array, Godot.Collections.Array{Godot.Collections.Array}, Godot.Collections.Dictionary, Mesh.ArrayFormat)"/>).</para>
    /// </summary>
    public Mesh.PrimitiveType SurfaceGetPrimitiveType(int surfIdx)
    {
        return (Mesh.PrimitiveType)NativeCalls.godot_icall_1_60(MethodBind16, GodotObject.GetPtr(this), surfIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SurfaceFindByName, 1321353865ul);

    /// <summary>
    /// <para>Returns the index of the first surface with this name held within this <see cref="Godot.ArrayMesh"/>. If none are found, -1 is returned.</para>
    /// </summary>
    public int SurfaceFindByName(string name)
    {
        return NativeCalls.godot_icall_1_134(MethodBind17, GodotObject.GetPtr(this), name);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SurfaceSetName, 501894301ul);

    /// <summary>
    /// <para>Sets a name for a given surface.</para>
    /// </summary>
    public void SurfaceSetName(int surfIdx, string name)
    {
        NativeCalls.godot_icall_2_181(MethodBind18, GodotObject.GetPtr(this), surfIdx, name);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SurfaceGetName, 844755477ul);

    /// <summary>
    /// <para>Gets the name assigned to this surface.</para>
    /// </summary>
    public string SurfaceGetName(int surfIdx)
    {
        return NativeCalls.godot_icall_1_133(MethodBind19, GodotObject.GetPtr(this), surfIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RegenNormalMaps, 3218959716ul);

    /// <summary>
    /// <para>Regenerates tangents for each of the <see cref="Godot.ArrayMesh"/>'s surfaces.</para>
    /// </summary>
    public void RegenNormalMaps()
    {
        NativeCalls.godot_icall_0_3(MethodBind20, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.LightmapUnwrap, 1476641071ul);

    /// <summary>
    /// <para>Performs a UV unwrap on the <see cref="Godot.ArrayMesh"/> to prepare the mesh for lightmapping.</para>
    /// </summary>
    public unsafe Error LightmapUnwrap(Transform3D transform, float texelSize)
    {
        return (Error)NativeCalls.godot_icall_2_182(MethodBind21, GodotObject.GetPtr(this), &transform, texelSize);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCustomAabb, 259215842ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetCustomAabb(Aabb aabb)
    {
        NativeCalls.godot_icall_1_183(MethodBind22, GodotObject.GetPtr(this), &aabb);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCustomAabb, 1068685055ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Aabb GetCustomAabb()
    {
        return NativeCalls.godot_icall_0_184(MethodBind23, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetShadowMesh, 3377897901ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetShadowMesh(ArrayMesh mesh)
    {
        NativeCalls.godot_icall_1_56(MethodBind24, GodotObject.GetPtr(this), GodotObject.GetPtr(mesh));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetShadowMesh, 3206942465ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public ArrayMesh GetShadowMesh()
    {
        return (ArrayMesh)NativeCalls.godot_icall_0_63(MethodBind25, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName._SetBlendShapeNames, 4015028928ul);

    internal void _SetBlendShapeNames(string[] blendShapeNames)
    {
        NativeCalls.godot_icall_1_185(MethodBind26, GodotObject.GetPtr(this), blendShapeNames);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName._GetBlendShapeNames, 1139954409ul);

    internal string[] _GetBlendShapeNames()
    {
        return NativeCalls.godot_icall_0_108(MethodBind27, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName._SetSurfaces, 381264803ul);

    internal void _SetSurfaces(Godot.Collections.Array surfaces)
    {
        NativeCalls.godot_icall_1_138(MethodBind28, GodotObject.GetPtr(this), (godot_array)(surfaces ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = ClassDB_get_method_with_compatibility(NativeName, MethodName._GetSurfaces, 3995934104ul);

    internal Godot.Collections.Array _GetSurfaces()
    {
        return NativeCalls.godot_icall_0_120(MethodBind29, GodotObject.GetPtr(this));
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
    public new class PropertyName : Mesh.PropertyName
    {
        /// <summary>
        /// Cached name for the '_blend_shape_names' property.
        /// </summary>
        public static readonly StringName _BlendShapeNames = "_blend_shape_names";
        /// <summary>
        /// Cached name for the '_surfaces' property.
        /// </summary>
        public static readonly StringName _Surfaces = "_surfaces";
        /// <summary>
        /// Cached name for the 'blend_shape_mode' property.
        /// </summary>
        public static readonly StringName BlendShapeMode = "blend_shape_mode";
        /// <summary>
        /// Cached name for the 'custom_aabb' property.
        /// </summary>
        public static readonly StringName CustomAabb = "custom_aabb";
        /// <summary>
        /// Cached name for the 'shadow_mesh' property.
        /// </summary>
        public static readonly StringName ShadowMesh = "shadow_mesh";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Mesh.MethodName
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
        /// Cached name for the 'set_blend_shape_name' method.
        /// </summary>
        public static readonly StringName SetBlendShapeName = "set_blend_shape_name";
        /// <summary>
        /// Cached name for the 'clear_blend_shapes' method.
        /// </summary>
        public static readonly StringName ClearBlendShapes = "clear_blend_shapes";
        /// <summary>
        /// Cached name for the 'set_blend_shape_mode' method.
        /// </summary>
        public static readonly StringName SetBlendShapeMode = "set_blend_shape_mode";
        /// <summary>
        /// Cached name for the 'get_blend_shape_mode' method.
        /// </summary>
        public static readonly StringName GetBlendShapeMode = "get_blend_shape_mode";
        /// <summary>
        /// Cached name for the 'add_surface_from_arrays' method.
        /// </summary>
        public static readonly StringName AddSurfaceFromArrays = "add_surface_from_arrays";
        /// <summary>
        /// Cached name for the 'clear_surfaces' method.
        /// </summary>
        public static readonly StringName ClearSurfaces = "clear_surfaces";
        /// <summary>
        /// Cached name for the 'surface_remove' method.
        /// </summary>
        public static readonly StringName SurfaceRemove = "surface_remove";
        /// <summary>
        /// Cached name for the 'surface_update_vertex_region' method.
        /// </summary>
        public static readonly StringName SurfaceUpdateVertexRegion = "surface_update_vertex_region";
        /// <summary>
        /// Cached name for the 'surface_update_attribute_region' method.
        /// </summary>
        public static readonly StringName SurfaceUpdateAttributeRegion = "surface_update_attribute_region";
        /// <summary>
        /// Cached name for the 'surface_update_skin_region' method.
        /// </summary>
        public static readonly StringName SurfaceUpdateSkinRegion = "surface_update_skin_region";
        /// <summary>
        /// Cached name for the 'surface_get_array_len' method.
        /// </summary>
        public static readonly StringName SurfaceGetArrayLen = "surface_get_array_len";
        /// <summary>
        /// Cached name for the 'surface_get_array_index_len' method.
        /// </summary>
        public static readonly StringName SurfaceGetArrayIndexLen = "surface_get_array_index_len";
        /// <summary>
        /// Cached name for the 'surface_get_format' method.
        /// </summary>
        public static readonly StringName SurfaceGetFormat = "surface_get_format";
        /// <summary>
        /// Cached name for the 'surface_get_primitive_type' method.
        /// </summary>
        public static readonly StringName SurfaceGetPrimitiveType = "surface_get_primitive_type";
        /// <summary>
        /// Cached name for the 'surface_find_by_name' method.
        /// </summary>
        public static readonly StringName SurfaceFindByName = "surface_find_by_name";
        /// <summary>
        /// Cached name for the 'surface_set_name' method.
        /// </summary>
        public static readonly StringName SurfaceSetName = "surface_set_name";
        /// <summary>
        /// Cached name for the 'surface_get_name' method.
        /// </summary>
        public static readonly StringName SurfaceGetName = "surface_get_name";
        /// <summary>
        /// Cached name for the 'regen_normal_maps' method.
        /// </summary>
        public static readonly StringName RegenNormalMaps = "regen_normal_maps";
        /// <summary>
        /// Cached name for the 'lightmap_unwrap' method.
        /// </summary>
        public static readonly StringName LightmapUnwrap = "lightmap_unwrap";
        /// <summary>
        /// Cached name for the 'set_custom_aabb' method.
        /// </summary>
        public static readonly StringName SetCustomAabb = "set_custom_aabb";
        /// <summary>
        /// Cached name for the 'get_custom_aabb' method.
        /// </summary>
        public static readonly StringName GetCustomAabb = "get_custom_aabb";
        /// <summary>
        /// Cached name for the 'set_shadow_mesh' method.
        /// </summary>
        public static readonly StringName SetShadowMesh = "set_shadow_mesh";
        /// <summary>
        /// Cached name for the 'get_shadow_mesh' method.
        /// </summary>
        public static readonly StringName GetShadowMesh = "get_shadow_mesh";
        /// <summary>
        /// Cached name for the '_set_blend_shape_names' method.
        /// </summary>
        public static readonly StringName _SetBlendShapeNames = "_set_blend_shape_names";
        /// <summary>
        /// Cached name for the '_get_blend_shape_names' method.
        /// </summary>
        public static readonly StringName _GetBlendShapeNames = "_get_blend_shape_names";
        /// <summary>
        /// Cached name for the '_set_surfaces' method.
        /// </summary>
        public static readonly StringName _SetSurfaces = "_set_surfaces";
        /// <summary>
        /// Cached name for the '_get_surfaces' method.
        /// </summary>
        public static readonly StringName _GetSurfaces = "_get_surfaces";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Mesh.SignalName
    {
    }
}
