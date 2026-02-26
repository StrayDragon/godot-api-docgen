namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>MeshInstance3D is a node that takes a <see cref="Godot.Mesh"/> resource and adds it to the current scenario by creating an instance of it. This is the class most often used to render 3D geometry and can be used to instance a single <see cref="Godot.Mesh"/> in many places. This allows reusing geometry, which can save on resources. When a <see cref="Godot.Mesh"/> has to be instantiated more than thousands of times at close proximity, consider using a <see cref="Godot.MultiMesh"/> in a <see cref="Godot.MultiMeshInstance3D"/> instead.</para>
/// </summary>
public partial class MeshInstance3D : GeometryInstance3D
{
    /// <summary>
    /// <para>The <see cref="Godot.Mesh"/> resource for the instance.</para>
    /// </summary>
    public Mesh Mesh
    {
        get
        {
            return GetMesh();
        }
        set
        {
            SetMesh(value);
        }
    }

    /// <summary>
    /// <para>The <see cref="Godot.Skin"/> to be used by this instance.</para>
    /// </summary>
    public Skin Skin
    {
        get
        {
            return GetSkin();
        }
        set
        {
            SetSkin(value);
        }
    }

    /// <summary>
    /// <para><see cref="Godot.NodePath"/> to the <see cref="Godot.Skeleton3D"/> associated with the instance.</para>
    /// <para><b>Note:</b> The default value of this property has changed in Godot 4.6. Enable <c>ProjectSettings.animation/compatibility/default_parent_skeleton_in_mesh_instance_3d</c> if the old behavior is needed for compatibility.</para>
    /// </summary>
    public NodePath Skeleton
    {
        get
        {
            return GetSkeletonPath();
        }
        set
        {
            SetSkeletonPath(value);
        }
    }

    private static readonly System.Type CachedType = typeof(MeshInstance3D);

    private static readonly StringName NativeName = "MeshInstance3D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public MeshInstance3D() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal MeshInstance3D(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal MeshInstance3D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMesh, 194775623ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMesh(Mesh mesh)
    {
        NativeCalls.godot_icall_1_56(MethodBind0, GodotObject.GetPtr(this), GodotObject.GetPtr(mesh));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMesh, 1808005922ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Mesh GetMesh()
    {
        return (Mesh)NativeCalls.godot_icall_0_63(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSkeletonPath, 1348162250ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSkeletonPath(NodePath skeletonPath)
    {
        NativeCalls.godot_icall_1_123(MethodBind2, GodotObject.GetPtr(this), (godot_node_path)(skeletonPath?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSkeletonPath, 277076166ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public NodePath GetSkeletonPath()
    {
        return NativeCalls.godot_icall_0_124(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSkin, 3971435618ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSkin(Skin skin)
    {
        NativeCalls.godot_icall_1_56(MethodBind4, GodotObject.GetPtr(this), GodotObject.GetPtr(skin));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSkin, 2074563878ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Skin GetSkin()
    {
        return (Skin)NativeCalls.godot_icall_0_63(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSkinReference, 2060603409ul);

    /// <summary>
    /// <para>Returns the internal <see cref="Godot.SkinReference"/> containing the skeleton's <see cref="Godot.Rid"/> attached to this RID. See also <see cref="Godot.Resource.GetRid()"/>, <see cref="Godot.SkinReference.GetSkeleton()"/>, and <see cref="Godot.RenderingServer.InstanceAttachSkeleton(Rid, Rid)"/>.</para>
    /// </summary>
    public SkinReference GetSkinReference()
    {
        return (SkinReference)NativeCalls.godot_icall_0_63(MethodBind6, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSurfaceOverrideMaterialCount, 3905245786ul);

    /// <summary>
    /// <para>Returns the number of surface override materials. This is equivalent to <see cref="Godot.Mesh.GetSurfaceCount()"/>. See also <see cref="Godot.MeshInstance3D.GetSurfaceOverrideMaterial(int)"/>.</para>
    /// </summary>
    public int GetSurfaceOverrideMaterialCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSurfaceOverrideMaterial, 3671737478ul);

    /// <summary>
    /// <para>Sets the override <paramref name="material"/> for the specified <paramref name="surface"/> of the <see cref="Godot.Mesh"/> resource. This material is associated with this <see cref="Godot.MeshInstance3D"/> rather than with <see cref="Godot.MeshInstance3D.Mesh"/>.</para>
    /// <para><b>Note:</b> This assigns the <see cref="Godot.Material"/> associated to the <see cref="Godot.MeshInstance3D"/>'s Surface Material Override properties, not the material within the <see cref="Godot.Mesh"/> resource. To set the material within the <see cref="Godot.Mesh"/> resource, use <see cref="Godot.Mesh.SurfaceSetMaterial(int, Material)"/> instead.</para>
    /// </summary>
    public void SetSurfaceOverrideMaterial(int surface, Material material)
    {
        NativeCalls.godot_icall_2_70(MethodBind8, GodotObject.GetPtr(this), surface, GodotObject.GetPtr(material));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSurfaceOverrideMaterial, 2897466400ul);

    /// <summary>
    /// <para>Returns the override <see cref="Godot.Material"/> for the specified <paramref name="surface"/> of the <see cref="Godot.Mesh"/> resource. See also <see cref="Godot.MeshInstance3D.GetSurfaceOverrideMaterialCount()"/>.</para>
    /// <para><b>Note:</b> This returns the <see cref="Godot.Material"/> associated to the <see cref="Godot.MeshInstance3D"/>'s Surface Material Override properties, not the material within the <see cref="Godot.Mesh"/> resource. To get the material within the <see cref="Godot.Mesh"/> resource, use <see cref="Godot.Mesh.SurfaceGetMaterial(int)"/> instead.</para>
    /// </summary>
    public Material GetSurfaceOverrideMaterial(int surface)
    {
        return (Material)NativeCalls.godot_icall_1_71(MethodBind9, GodotObject.GetPtr(this), surface);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetActiveMaterial, 2897466400ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.Material"/> that will be used by the <see cref="Godot.Mesh"/> when drawing. This can return the <see cref="Godot.GeometryInstance3D.MaterialOverride"/>, the surface override <see cref="Godot.Material"/> defined in this <see cref="Godot.MeshInstance3D"/>, or the surface <see cref="Godot.Material"/> defined in the <see cref="Godot.MeshInstance3D.Mesh"/>. For example, if <see cref="Godot.GeometryInstance3D.MaterialOverride"/> is used, all surfaces will return the override material.</para>
    /// <para>Returns <see langword="null"/> if no material is active, including when <see cref="Godot.MeshInstance3D.Mesh"/> is <see langword="null"/>.</para>
    /// </summary>
    public Material GetActiveMaterial(int surface)
    {
        return (Material)NativeCalls.godot_icall_1_71(MethodBind10, GodotObject.GetPtr(this), surface);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CreateTrimeshCollision, 3218959716ul);

    /// <summary>
    /// <para>This helper creates a <see cref="Godot.StaticBody3D"/> child node with a <see cref="Godot.ConcavePolygonShape3D"/> collision shape calculated from the mesh geometry. It's mainly used for testing.</para>
    /// </summary>
    public void CreateTrimeshCollision()
    {
        NativeCalls.godot_icall_0_3(MethodBind11, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CreateConvexCollision, 2751962654ul);

    /// <summary>
    /// <para>This helper creates a <see cref="Godot.StaticBody3D"/> child node with a <see cref="Godot.ConvexPolygonShape3D"/> collision shape calculated from the mesh geometry. It's mainly used for testing.</para>
    /// <para>If <paramref name="clean"/> is <see langword="true"/> (default), duplicate and interior vertices are removed automatically. You can set it to <see langword="false"/> to make the process faster if not needed.</para>
    /// <para>If <paramref name="simplify"/> is <see langword="true"/>, the geometry can be further simplified to reduce the number of vertices. Disabled by default.</para>
    /// </summary>
    public void CreateConvexCollision(bool clean = true, bool simplify = false)
    {
        NativeCalls.godot_icall_2_550(MethodBind12, GodotObject.GetPtr(this), clean.ToGodotBool(), simplify.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CreateMultipleConvexCollisions, 628789669ul);

    /// <summary>
    /// <para>This helper creates a <see cref="Godot.StaticBody3D"/> child node with multiple <see cref="Godot.ConvexPolygonShape3D"/> collision shapes calculated from the mesh geometry via convex decomposition. The convex decomposition operation can be controlled with parameters from the optional <paramref name="settings"/>.</para>
    /// </summary>
    public void CreateMultipleConvexCollisions(MeshConvexDecompositionSettings settings = null)
    {
        NativeCalls.godot_icall_1_56(MethodBind13, GodotObject.GetPtr(this), GodotObject.GetPtr(settings));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBlendShapeCount, 3905245786ul);

    /// <summary>
    /// <para>Returns the number of blend shapes available. Produces an error if <see cref="Godot.MeshInstance3D.Mesh"/> is <see langword="null"/>.</para>
    /// </summary>
    public int GetBlendShapeCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind14, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FindBlendShapeByName, 4150868206ul);

    /// <summary>
    /// <para>Returns the index of the blend shape with the given <paramref name="name"/>. Returns <c>-1</c> if no blend shape with this name exists, including when <see cref="Godot.MeshInstance3D.Mesh"/> is <see langword="null"/>.</para>
    /// </summary>
    public int FindBlendShapeByName(StringName name)
    {
        return NativeCalls.godot_icall_1_193(MethodBind15, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBlendShapeValue, 2339986948ul);

    /// <summary>
    /// <para>Returns the value of the blend shape at the given <paramref name="blendShapeIdx"/>. Returns <c>0.0</c> and produces an error if <see cref="Godot.MeshInstance3D.Mesh"/> is <see langword="null"/> or doesn't have a blend shape at that index.</para>
    /// </summary>
    public float GetBlendShapeValue(int blendShapeIdx)
    {
        return NativeCalls.godot_icall_1_72(MethodBind16, GodotObject.GetPtr(this), blendShapeIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBlendShapeValue, 1602489585ul);

    /// <summary>
    /// <para>Sets the value of the blend shape at <paramref name="blendShapeIdx"/> to <paramref name="value"/>. Produces an error if <see cref="Godot.MeshInstance3D.Mesh"/> is <see langword="null"/> or doesn't have a blend shape at that index.</para>
    /// </summary>
    public void SetBlendShapeValue(int blendShapeIdx, float value)
    {
        NativeCalls.godot_icall_2_69(MethodBind17, GodotObject.GetPtr(this), blendShapeIdx, value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CreateDebugTangents, 3218959716ul);

    /// <summary>
    /// <para>This helper creates a <see cref="Godot.MeshInstance3D"/> child node with gizmos at every vertex calculated from the mesh geometry. It's mainly used for testing.</para>
    /// </summary>
    public void CreateDebugTangents()
    {
        NativeCalls.godot_icall_0_3(MethodBind18, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BakeMeshFromCurrentBlendShapeMix, 1457573577ul);

    /// <summary>
    /// <para>Takes a snapshot from the current <see cref="Godot.ArrayMesh"/> with all blend shapes applied according to their current weights and bakes it to the provided <paramref name="existing"/> mesh. If no <paramref name="existing"/> mesh is provided a new <see cref="Godot.ArrayMesh"/> is created, baked and returned. Mesh surface materials are not copied.</para>
    /// <para><b>Performance:</b> <see cref="Godot.Mesh"/> data needs to be received from the GPU, stalling the <see cref="Godot.RenderingServer"/> in the process.</para>
    /// </summary>
    public ArrayMesh BakeMeshFromCurrentBlendShapeMix(ArrayMesh existing = null)
    {
        return (ArrayMesh)NativeCalls.godot_icall_1_268(MethodBind19, GodotObject.GetPtr(this), GodotObject.GetPtr(existing));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BakeMeshFromCurrentSkeletonPose, 1457573577ul);

    /// <summary>
    /// <para>Takes a snapshot of the current animated skeleton pose of the skinned mesh and bakes it to the provided <paramref name="existing"/> mesh. If no <paramref name="existing"/> mesh is provided a new <see cref="Godot.ArrayMesh"/> is created, baked, and returned. Requires a skeleton with a registered skin to work. Blendshapes are ignored. Mesh surface materials are not copied.</para>
    /// <para><b>Performance:</b> <see cref="Godot.Mesh"/> data needs to be retrieved from the GPU, stalling the <see cref="Godot.RenderingServer"/> in the process.</para>
    /// </summary>
    public ArrayMesh BakeMeshFromCurrentSkeletonPose(ArrayMesh existing = null)
    {
        return (ArrayMesh)NativeCalls.godot_icall_1_268(MethodBind20, GodotObject.GetPtr(this), GodotObject.GetPtr(existing));
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
    public new class PropertyName : GeometryInstance3D.PropertyName
    {
        /// <summary>
        /// Cached name for the 'mesh' property.
        /// </summary>
        public static readonly StringName Mesh = "mesh";
        /// <summary>
        /// Cached name for the 'skin' property.
        /// </summary>
        public static readonly StringName Skin = "skin";
        /// <summary>
        /// Cached name for the 'skeleton' property.
        /// </summary>
        public static readonly StringName Skeleton = "skeleton";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : GeometryInstance3D.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_mesh' method.
        /// </summary>
        public static readonly StringName SetMesh = "set_mesh";
        /// <summary>
        /// Cached name for the 'get_mesh' method.
        /// </summary>
        public static readonly StringName GetMesh = "get_mesh";
        /// <summary>
        /// Cached name for the 'set_skeleton_path' method.
        /// </summary>
        public static readonly StringName SetSkeletonPath = "set_skeleton_path";
        /// <summary>
        /// Cached name for the 'get_skeleton_path' method.
        /// </summary>
        public static readonly StringName GetSkeletonPath = "get_skeleton_path";
        /// <summary>
        /// Cached name for the 'set_skin' method.
        /// </summary>
        public static readonly StringName SetSkin = "set_skin";
        /// <summary>
        /// Cached name for the 'get_skin' method.
        /// </summary>
        public static readonly StringName GetSkin = "get_skin";
        /// <summary>
        /// Cached name for the 'get_skin_reference' method.
        /// </summary>
        public static readonly StringName GetSkinReference = "get_skin_reference";
        /// <summary>
        /// Cached name for the 'get_surface_override_material_count' method.
        /// </summary>
        public static readonly StringName GetSurfaceOverrideMaterialCount = "get_surface_override_material_count";
        /// <summary>
        /// Cached name for the 'set_surface_override_material' method.
        /// </summary>
        public static readonly StringName SetSurfaceOverrideMaterial = "set_surface_override_material";
        /// <summary>
        /// Cached name for the 'get_surface_override_material' method.
        /// </summary>
        public static readonly StringName GetSurfaceOverrideMaterial = "get_surface_override_material";
        /// <summary>
        /// Cached name for the 'get_active_material' method.
        /// </summary>
        public static readonly StringName GetActiveMaterial = "get_active_material";
        /// <summary>
        /// Cached name for the 'create_trimesh_collision' method.
        /// </summary>
        public static readonly StringName CreateTrimeshCollision = "create_trimesh_collision";
        /// <summary>
        /// Cached name for the 'create_convex_collision' method.
        /// </summary>
        public static readonly StringName CreateConvexCollision = "create_convex_collision";
        /// <summary>
        /// Cached name for the 'create_multiple_convex_collisions' method.
        /// </summary>
        public static readonly StringName CreateMultipleConvexCollisions = "create_multiple_convex_collisions";
        /// <summary>
        /// Cached name for the 'get_blend_shape_count' method.
        /// </summary>
        public static readonly StringName GetBlendShapeCount = "get_blend_shape_count";
        /// <summary>
        /// Cached name for the 'find_blend_shape_by_name' method.
        /// </summary>
        public static readonly StringName FindBlendShapeByName = "find_blend_shape_by_name";
        /// <summary>
        /// Cached name for the 'get_blend_shape_value' method.
        /// </summary>
        public static readonly StringName GetBlendShapeValue = "get_blend_shape_value";
        /// <summary>
        /// Cached name for the 'set_blend_shape_value' method.
        /// </summary>
        public static readonly StringName SetBlendShapeValue = "set_blend_shape_value";
        /// <summary>
        /// Cached name for the 'create_debug_tangents' method.
        /// </summary>
        public static readonly StringName CreateDebugTangents = "create_debug_tangents";
        /// <summary>
        /// Cached name for the 'bake_mesh_from_current_blend_shape_mix' method.
        /// </summary>
        public static readonly StringName BakeMeshFromCurrentBlendShapeMix = "bake_mesh_from_current_blend_shape_mix";
        /// <summary>
        /// Cached name for the 'bake_mesh_from_current_skeleton_pose' method.
        /// </summary>
        public static readonly StringName BakeMeshFromCurrentSkeletonPose = "bake_mesh_from_current_skeleton_pose";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : GeometryInstance3D.SignalName
    {
    }
}
