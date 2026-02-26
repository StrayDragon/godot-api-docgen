namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>MeshDataTool provides access to individual vertices in a <see cref="Godot.Mesh"/>. It allows users to read and edit vertex data of meshes. It also creates an array of faces and edges.</para>
/// <para>To use MeshDataTool, load a mesh with <see cref="Godot.MeshDataTool.CreateFromSurface(ArrayMesh, int)"/>. When you are finished editing the data commit the data to a mesh with <see cref="Godot.MeshDataTool.CommitToSurface(ArrayMesh, ulong)"/>.</para>
/// <para>Below is an example of how MeshDataTool may be used.</para>
/// <para><code>
/// var mesh = new ArrayMesh();
/// mesh.AddSurfaceFromArrays(Mesh.PrimitiveType.Triangles, new BoxMesh().GetMeshArrays());
/// var mdt = new MeshDataTool();
/// mdt.CreateFromSurface(mesh, 0);
/// for (var i = 0; i &lt; mdt.GetVertexCount(); i++)
/// {
/// 	Vector3 vertex = mdt.GetVertex(i);
/// 	// In this example we extend the mesh by one unit, which results in separated faces as it is flat shaded.
/// 	vertex += mdt.GetVertexNormal(i);
/// 	// Save your change.
/// 	mdt.SetVertex(i, vertex);
/// }
/// mesh.ClearSurfaces();
/// mdt.CommitToSurface(mesh);
/// var mi = new MeshInstance();
/// mi.Mesh = mesh;
/// AddChild(mi);
/// </code></para>
/// <para>See also <see cref="Godot.ArrayMesh"/>, <see cref="Godot.ImmediateMesh"/> and <see cref="Godot.SurfaceTool"/> for procedural geometry generation.</para>
/// <para><b>Note:</b> Godot uses clockwise <a href="https://learnopengl.com/Advanced-OpenGL/Face-culling">winding order</a> for front faces of triangle primitive modes.</para>
/// </summary>
public partial class MeshDataTool : RefCounted
{
    private static readonly System.Type CachedType = typeof(MeshDataTool);

    private static readonly StringName NativeName = "MeshDataTool";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public MeshDataTool() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal MeshDataTool(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal MeshDataTool(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Clear, 3218959716ul);

    /// <summary>
    /// <para>Clears all data currently in MeshDataTool.</para>
    /// </summary>
    public void Clear()
    {
        NativeCalls.godot_icall_0_3(MethodBind0, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CreateFromSurface, 2727020678ul);

    /// <summary>
    /// <para>Uses specified surface of given <see cref="Godot.Mesh"/> to populate data for MeshDataTool.</para>
    /// <para>Requires <see cref="Godot.Mesh"/> with primitive type <see cref="Godot.Mesh.PrimitiveType.Triangles"/>.</para>
    /// </summary>
    public Error CreateFromSurface(ArrayMesh mesh, int surface)
    {
        return (Error)NativeCalls.godot_icall_2_792(MethodBind1, GodotObject.GetPtr(this), GodotObject.GetPtr(mesh), surface);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CommitToSurface, 2021686445ul);

    /// <summary>
    /// <para>Adds a new surface to specified <see cref="Godot.Mesh"/> with edited data.</para>
    /// </summary>
    public Error CommitToSurface(ArrayMesh mesh, ulong compressionFlags = (ulong)(0))
    {
        return (Error)NativeCalls.godot_icall_2_793(MethodBind2, GodotObject.GetPtr(this), GodotObject.GetPtr(mesh), compressionFlags);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFormat, 3905245786ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.Mesh"/>'s format as a combination of the <see cref="Godot.Mesh.ArrayFormat"/> flags. For example, a mesh containing both vertices and normals would return a format of <c>3</c> because <see cref="Godot.Mesh.ArrayFormat.FormatVertex"/> is <c>1</c> and <see cref="Godot.Mesh.ArrayFormat.FormatNormal"/> is <c>2</c>.</para>
    /// </summary>
    public ulong GetFormat()
    {
        return NativeCalls.godot_icall_0_137(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVertexCount, 3905245786ul);

    /// <summary>
    /// <para>Returns the total number of vertices in <see cref="Godot.Mesh"/>.</para>
    /// </summary>
    public int GetVertexCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind4, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEdgeCount, 3905245786ul);

    /// <summary>
    /// <para>Returns the number of edges in this <see cref="Godot.Mesh"/>.</para>
    /// </summary>
    public int GetEdgeCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFaceCount, 3905245786ul);

    /// <summary>
    /// <para>Returns the number of faces in this <see cref="Godot.Mesh"/>.</para>
    /// </summary>
    public int GetFaceCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind6, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVertex, 1530502735ul);

    /// <summary>
    /// <para>Sets the position of the given vertex.</para>
    /// </summary>
    public unsafe void SetVertex(int idx, Vector3 vertex)
    {
        NativeCalls.godot_icall_2_362(MethodBind7, GodotObject.GetPtr(this), idx, &vertex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVertex, 711720468ul);

    /// <summary>
    /// <para>Returns the position of the given vertex.</para>
    /// </summary>
    public Vector3 GetVertex(int idx)
    {
        return NativeCalls.godot_icall_1_363(MethodBind8, GodotObject.GetPtr(this), idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVertexNormal, 1530502735ul);

    /// <summary>
    /// <para>Sets the normal of the given vertex.</para>
    /// </summary>
    public unsafe void SetVertexNormal(int idx, Vector3 normal)
    {
        NativeCalls.godot_icall_2_362(MethodBind9, GodotObject.GetPtr(this), idx, &normal);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVertexNormal, 711720468ul);

    /// <summary>
    /// <para>Returns the normal of the given vertex.</para>
    /// </summary>
    public Vector3 GetVertexNormal(int idx)
    {
        return NativeCalls.godot_icall_1_363(MethodBind10, GodotObject.GetPtr(this), idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVertexTangent, 1104099133ul);

    /// <summary>
    /// <para>Sets the tangent of the given vertex.</para>
    /// <para><b>Note:</b> Even though <paramref name="tangent"/> is a <see cref="Godot.Plane"/>, it does not directly represent the tangent plane. Its <c>Plane.x</c>, <c>Plane.y</c>, and <c>Plane.z</c> represent the tangent vector and <c>Plane.d</c> should be either <c>-1</c> or <c>1</c>. See also <see cref="Godot.Mesh.ArrayType.Tangent"/>.</para>
    /// </summary>
    public unsafe void SetVertexTangent(int idx, Plane tangent)
    {
        NativeCalls.godot_icall_2_794(MethodBind11, GodotObject.GetPtr(this), idx, &tangent);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVertexTangent, 1372055458ul);

    /// <summary>
    /// <para>Returns the tangent of the given vertex.</para>
    /// </summary>
    public Plane GetVertexTangent(int idx)
    {
        return NativeCalls.godot_icall_1_795(MethodBind12, GodotObject.GetPtr(this), idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVertexUV, 163021252ul);

    /// <summary>
    /// <para>Sets the UV of the given vertex.</para>
    /// </summary>
    public unsafe void SetVertexUV(int idx, Vector2 uV)
    {
        NativeCalls.godot_icall_2_147(MethodBind13, GodotObject.GetPtr(this), idx, &uV);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVertexUV, 2299179447ul);

    /// <summary>
    /// <para>Returns the UV of the given vertex.</para>
    /// </summary>
    public Vector2 GetVertexUV(int idx)
    {
        return NativeCalls.godot_icall_1_148(MethodBind14, GodotObject.GetPtr(this), idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVertexUV2, 163021252ul);

    /// <summary>
    /// <para>Sets the UV2 of the given vertex.</para>
    /// </summary>
    public unsafe void SetVertexUV2(int idx, Vector2 uV2)
    {
        NativeCalls.godot_icall_2_147(MethodBind15, GodotObject.GetPtr(this), idx, &uV2);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVertexUV2, 2299179447ul);

    /// <summary>
    /// <para>Returns the UV2 of the given vertex.</para>
    /// </summary>
    public Vector2 GetVertexUV2(int idx)
    {
        return NativeCalls.godot_icall_1_148(MethodBind16, GodotObject.GetPtr(this), idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVertexColor, 2878471219ul);

    /// <summary>
    /// <para>Sets the color of the given vertex.</para>
    /// </summary>
    public unsafe void SetVertexColor(int idx, Color color)
    {
        NativeCalls.godot_icall_2_687(MethodBind17, GodotObject.GetPtr(this), idx, &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVertexColor, 3457211756ul);

    /// <summary>
    /// <para>Returns the color of the given vertex.</para>
    /// </summary>
    public Color GetVertexColor(int idx)
    {
        return NativeCalls.godot_icall_1_688(MethodBind18, GodotObject.GetPtr(this), idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVertexBones, 3500328261ul);

    /// <summary>
    /// <para>Sets the bones of the given vertex.</para>
    /// </summary>
    public void SetVertexBones(int idx, int[] bones)
    {
        NativeCalls.godot_icall_2_796(MethodBind19, GodotObject.GetPtr(this), idx, bones);
    }

    /// <summary>
    /// <para>Sets the bones of the given vertex.</para>
    /// </summary>
    public void SetVertexBones(int idx, ReadOnlySpan<int> bones)
    {
        NativeCalls.godot_icall_2_796(MethodBind19, GodotObject.GetPtr(this), idx, bones);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVertexBones, 1706082319ul);

    /// <summary>
    /// <para>Returns the bones of the given vertex.</para>
    /// </summary>
    public int[] GetVertexBones(int idx)
    {
        return NativeCalls.godot_icall_1_797(MethodBind20, GodotObject.GetPtr(this), idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVertexWeights, 1345852415ul);

    /// <summary>
    /// <para>Sets the bone weights of the given vertex.</para>
    /// </summary>
    public void SetVertexWeights(int idx, float[] weights)
    {
        NativeCalls.godot_icall_2_798(MethodBind21, GodotObject.GetPtr(this), idx, weights);
    }

    /// <summary>
    /// <para>Sets the bone weights of the given vertex.</para>
    /// </summary>
    public void SetVertexWeights(int idx, ReadOnlySpan<float> weights)
    {
        NativeCalls.godot_icall_2_798(MethodBind21, GodotObject.GetPtr(this), idx, weights);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVertexWeights, 1542882410ul);

    /// <summary>
    /// <para>Returns bone weights of the given vertex.</para>
    /// </summary>
    public float[] GetVertexWeights(int idx)
    {
        return NativeCalls.godot_icall_1_799(MethodBind22, GodotObject.GetPtr(this), idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVertexMeta, 2152698145ul);

    /// <summary>
    /// <para>Sets the metadata associated with the given vertex.</para>
    /// </summary>
    public void SetVertexMeta(int idx, Variant meta)
    {
        NativeCalls.godot_icall_2_701(MethodBind23, GodotObject.GetPtr(this), idx, meta);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVertexMeta, 4227898402ul);

    /// <summary>
    /// <para>Returns the metadata associated with the given vertex.</para>
    /// </summary>
    public Variant GetVertexMeta(int idx)
    {
        return NativeCalls.godot_icall_1_702(MethodBind24, GodotObject.GetPtr(this), idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVertexEdges, 1706082319ul);

    /// <summary>
    /// <para>Returns an array of edges that share the given vertex.</para>
    /// </summary>
    public int[] GetVertexEdges(int idx)
    {
        return NativeCalls.godot_icall_1_797(MethodBind25, GodotObject.GetPtr(this), idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVertexFaces, 1706082319ul);

    /// <summary>
    /// <para>Returns an array of faces that share the given vertex.</para>
    /// </summary>
    public int[] GetVertexFaces(int idx)
    {
        return NativeCalls.godot_icall_1_797(MethodBind26, GodotObject.GetPtr(this), idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEdgeVertex, 3175239445ul);

    /// <summary>
    /// <para>Returns the index of the specified <paramref name="vertex"/> connected to the edge at index <paramref name="idx"/>.</para>
    /// <para><paramref name="vertex"/> can only be <c>0</c> or <c>1</c>, as edges are composed of two vertices.</para>
    /// </summary>
    public int GetEdgeVertex(int idx, int vertex)
    {
        return NativeCalls.godot_icall_2_73(MethodBind27, GodotObject.GetPtr(this), idx, vertex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEdgeFaces, 1706082319ul);

    /// <summary>
    /// <para>Returns array of faces that touch given edge.</para>
    /// </summary>
    public int[] GetEdgeFaces(int idx)
    {
        return NativeCalls.godot_icall_1_797(MethodBind28, GodotObject.GetPtr(this), idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEdgeMeta, 2152698145ul);

    /// <summary>
    /// <para>Sets the metadata of the given edge.</para>
    /// </summary>
    public void SetEdgeMeta(int idx, Variant meta)
    {
        NativeCalls.godot_icall_2_701(MethodBind29, GodotObject.GetPtr(this), idx, meta);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEdgeMeta, 4227898402ul);

    /// <summary>
    /// <para>Returns meta information assigned to given edge.</para>
    /// </summary>
    public Variant GetEdgeMeta(int idx)
    {
        return NativeCalls.godot_icall_1_702(MethodBind30, GodotObject.GetPtr(this), idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFaceVertex, 3175239445ul);

    /// <summary>
    /// <para>Returns the specified vertex index of the given face.</para>
    /// <para><paramref name="vertex"/> must be either <c>0</c>, <c>1</c>, or <c>2</c> because faces contain three vertices.</para>
    /// <para><code>
    /// int index = meshDataTool.GetFaceVertex(0, 1); // Gets the index of the second vertex of the first face.
    /// Vector3 position = meshDataTool.GetVertex(index);
    /// Vector3 normal = meshDataTool.GetVertexNormal(index);
    /// </code></para>
    /// </summary>
    public int GetFaceVertex(int idx, int vertex)
    {
        return NativeCalls.godot_icall_2_73(MethodBind31, GodotObject.GetPtr(this), idx, vertex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind32 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFaceEdge, 3175239445ul);

    /// <summary>
    /// <para>Returns the edge associated with the face at index <paramref name="idx"/>.</para>
    /// <para><paramref name="edge"/> argument must be either <c>0</c>, <c>1</c>, or <c>2</c> because a face only has three edges.</para>
    /// </summary>
    public int GetFaceEdge(int idx, int edge)
    {
        return NativeCalls.godot_icall_2_73(MethodBind32, GodotObject.GetPtr(this), idx, edge);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind33 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFaceMeta, 2152698145ul);

    /// <summary>
    /// <para>Sets the metadata of the given face.</para>
    /// </summary>
    public void SetFaceMeta(int idx, Variant meta)
    {
        NativeCalls.godot_icall_2_701(MethodBind33, GodotObject.GetPtr(this), idx, meta);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind34 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFaceMeta, 4227898402ul);

    /// <summary>
    /// <para>Returns the metadata associated with the given face.</para>
    /// </summary>
    public Variant GetFaceMeta(int idx)
    {
        return NativeCalls.godot_icall_1_702(MethodBind34, GodotObject.GetPtr(this), idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind35 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFaceNormal, 711720468ul);

    /// <summary>
    /// <para>Calculates and returns the face normal of the given face.</para>
    /// </summary>
    public Vector3 GetFaceNormal(int idx)
    {
        return NativeCalls.godot_icall_1_363(MethodBind35, GodotObject.GetPtr(this), idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind36 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMaterial, 2757459619ul);

    /// <summary>
    /// <para>Sets the material to be used by newly-constructed <see cref="Godot.Mesh"/>.</para>
    /// </summary>
    public void SetMaterial(Material material)
    {
        NativeCalls.godot_icall_1_56(MethodBind36, GodotObject.GetPtr(this), GodotObject.GetPtr(material));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind37 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMaterial, 5934680ul);

    /// <summary>
    /// <para>Returns the material assigned to the <see cref="Godot.Mesh"/>.</para>
    /// </summary>
    public Material GetMaterial()
    {
        return (Material)NativeCalls.godot_icall_0_63(MethodBind37, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind38 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CommitToSurface, 3521099812ul);

    /// <summary>
    /// <para>Adds a new surface to specified <see cref="Godot.Mesh"/> with edited data.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public Error CommitToSurface(ArrayMesh mesh)
    {
        return (Error)NativeCalls.godot_icall_1_371(MethodBind38, GodotObject.GetPtr(this), GodotObject.GetPtr(mesh));
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
        /// Cached name for the 'clear' method.
        /// </summary>
        public static readonly StringName Clear = "clear";
        /// <summary>
        /// Cached name for the 'create_from_surface' method.
        /// </summary>
        public static readonly StringName CreateFromSurface = "create_from_surface";
        /// <summary>
        /// Cached name for the 'commit_to_surface' method.
        /// </summary>
        public static readonly StringName CommitToSurface = "commit_to_surface";
        /// <summary>
        /// Cached name for the 'get_format' method.
        /// </summary>
        public static readonly StringName GetFormat = "get_format";
        /// <summary>
        /// Cached name for the 'get_vertex_count' method.
        /// </summary>
        public static readonly StringName GetVertexCount = "get_vertex_count";
        /// <summary>
        /// Cached name for the 'get_edge_count' method.
        /// </summary>
        public static readonly StringName GetEdgeCount = "get_edge_count";
        /// <summary>
        /// Cached name for the 'get_face_count' method.
        /// </summary>
        public static readonly StringName GetFaceCount = "get_face_count";
        /// <summary>
        /// Cached name for the 'set_vertex' method.
        /// </summary>
        public static readonly StringName SetVertex = "set_vertex";
        /// <summary>
        /// Cached name for the 'get_vertex' method.
        /// </summary>
        public static readonly StringName GetVertex = "get_vertex";
        /// <summary>
        /// Cached name for the 'set_vertex_normal' method.
        /// </summary>
        public static readonly StringName SetVertexNormal = "set_vertex_normal";
        /// <summary>
        /// Cached name for the 'get_vertex_normal' method.
        /// </summary>
        public static readonly StringName GetVertexNormal = "get_vertex_normal";
        /// <summary>
        /// Cached name for the 'set_vertex_tangent' method.
        /// </summary>
        public static readonly StringName SetVertexTangent = "set_vertex_tangent";
        /// <summary>
        /// Cached name for the 'get_vertex_tangent' method.
        /// </summary>
        public static readonly StringName GetVertexTangent = "get_vertex_tangent";
        /// <summary>
        /// Cached name for the 'set_vertex_uv' method.
        /// </summary>
        public static readonly StringName SetVertexUV = "set_vertex_uv";
        /// <summary>
        /// Cached name for the 'get_vertex_uv' method.
        /// </summary>
        public static readonly StringName GetVertexUV = "get_vertex_uv";
        /// <summary>
        /// Cached name for the 'set_vertex_uv2' method.
        /// </summary>
        public static readonly StringName SetVertexUV2 = "set_vertex_uv2";
        /// <summary>
        /// Cached name for the 'get_vertex_uv2' method.
        /// </summary>
        public static readonly StringName GetVertexUV2 = "get_vertex_uv2";
        /// <summary>
        /// Cached name for the 'set_vertex_color' method.
        /// </summary>
        public static readonly StringName SetVertexColor = "set_vertex_color";
        /// <summary>
        /// Cached name for the 'get_vertex_color' method.
        /// </summary>
        public static readonly StringName GetVertexColor = "get_vertex_color";
        /// <summary>
        /// Cached name for the 'set_vertex_bones' method.
        /// </summary>
        public static readonly StringName SetVertexBones = "set_vertex_bones";
        /// <summary>
        /// Cached name for the 'get_vertex_bones' method.
        /// </summary>
        public static readonly StringName GetVertexBones = "get_vertex_bones";
        /// <summary>
        /// Cached name for the 'set_vertex_weights' method.
        /// </summary>
        public static readonly StringName SetVertexWeights = "set_vertex_weights";
        /// <summary>
        /// Cached name for the 'get_vertex_weights' method.
        /// </summary>
        public static readonly StringName GetVertexWeights = "get_vertex_weights";
        /// <summary>
        /// Cached name for the 'set_vertex_meta' method.
        /// </summary>
        public static readonly StringName SetVertexMeta = "set_vertex_meta";
        /// <summary>
        /// Cached name for the 'get_vertex_meta' method.
        /// </summary>
        public static readonly StringName GetVertexMeta = "get_vertex_meta";
        /// <summary>
        /// Cached name for the 'get_vertex_edges' method.
        /// </summary>
        public static readonly StringName GetVertexEdges = "get_vertex_edges";
        /// <summary>
        /// Cached name for the 'get_vertex_faces' method.
        /// </summary>
        public static readonly StringName GetVertexFaces = "get_vertex_faces";
        /// <summary>
        /// Cached name for the 'get_edge_vertex' method.
        /// </summary>
        public static readonly StringName GetEdgeVertex = "get_edge_vertex";
        /// <summary>
        /// Cached name for the 'get_edge_faces' method.
        /// </summary>
        public static readonly StringName GetEdgeFaces = "get_edge_faces";
        /// <summary>
        /// Cached name for the 'set_edge_meta' method.
        /// </summary>
        public static readonly StringName SetEdgeMeta = "set_edge_meta";
        /// <summary>
        /// Cached name for the 'get_edge_meta' method.
        /// </summary>
        public static readonly StringName GetEdgeMeta = "get_edge_meta";
        /// <summary>
        /// Cached name for the 'get_face_vertex' method.
        /// </summary>
        public static readonly StringName GetFaceVertex = "get_face_vertex";
        /// <summary>
        /// Cached name for the 'get_face_edge' method.
        /// </summary>
        public static readonly StringName GetFaceEdge = "get_face_edge";
        /// <summary>
        /// Cached name for the 'set_face_meta' method.
        /// </summary>
        public static readonly StringName SetFaceMeta = "set_face_meta";
        /// <summary>
        /// Cached name for the 'get_face_meta' method.
        /// </summary>
        public static readonly StringName GetFaceMeta = "get_face_meta";
        /// <summary>
        /// Cached name for the 'get_face_normal' method.
        /// </summary>
        public static readonly StringName GetFaceNormal = "get_face_normal";
        /// <summary>
        /// Cached name for the 'set_material' method.
        /// </summary>
        public static readonly StringName SetMaterial = "set_material";
        /// <summary>
        /// Cached name for the 'get_material' method.
        /// </summary>
        public static readonly StringName GetMaterial = "get_material";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : RefCounted.SignalName
    {
    }
}
