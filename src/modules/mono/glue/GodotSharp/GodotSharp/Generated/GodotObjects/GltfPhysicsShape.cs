namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Represents a physics shape as defined by the <c>OMI_physics_shape</c> or <c>OMI_collider</c> glTF extensions. This class is an intermediary between the glTF data and Godot's nodes, and it's abstracted in a way that allows adding support for different glTF physics extensions in the future.</para>
/// </summary>
[GodotClassName("GLTFPhysicsShape")]
public partial class GltfPhysicsShape : Resource
{
    /// <summary>
    /// <para>The type of shape this shape represents. Valid values are <c>"box"</c>, <c>"capsule"</c>, <c>"cylinder"</c>, <c>"sphere"</c>, <c>"hull"</c>, and <c>"trimesh"</c>.</para>
    /// </summary>
    public string ShapeType
    {
        get
        {
            return GetShapeType();
        }
        set
        {
            SetShapeType(value);
        }
    }

    /// <summary>
    /// <para>The size of the shape, in meters. This is only used when the shape type is <c>"box"</c>, and it represents the <c>"diameter"</c> of the box. This value should not be negative.</para>
    /// </summary>
    public Vector3 Size
    {
        get
        {
            return GetSize();
        }
        set
        {
            SetSize(value);
        }
    }

    /// <summary>
    /// <para>The radius of the shape, in meters. This is only used when the shape type is <c>"capsule"</c>, <c>"cylinder"</c>, or <c>"sphere"</c>. This value should not be negative.</para>
    /// </summary>
    public float Radius
    {
        get
        {
            return GetRadius();
        }
        set
        {
            SetRadius(value);
        }
    }

    /// <summary>
    /// <para>The height of the shape, in meters. This is only used when the shape type is <c>"capsule"</c> or <c>"cylinder"</c>. This value should not be negative, and for <c>"capsule"</c> it should be at least twice the radius.</para>
    /// </summary>
    public float Height
    {
        get
        {
            return GetHeight();
        }
        set
        {
            SetHeight(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, indicates that this shape is a trigger. For Godot, this means that the shape should be a child of an <see cref="Godot.Area3D"/> node.</para>
    /// <para>This is the only variable not used in the <see cref="Godot.GltfPhysicsShape.ToNode(bool)"/> method, it's intended to be used alongside when deciding where to add the generated node as a child.</para>
    /// </summary>
    public bool IsTrigger
    {
        get
        {
            return GetIsTrigger();
        }
        set
        {
            SetIsTrigger(value);
        }
    }

    /// <summary>
    /// <para>The index of the shape's mesh in the glTF file. This is only used when the shape type is <c>"hull"</c> (convex hull) or <c>"trimesh"</c> (concave trimesh).</para>
    /// </summary>
    public int MeshIndex
    {
        get
        {
            return GetMeshIndex();
        }
        set
        {
            SetMeshIndex(value);
        }
    }

    /// <summary>
    /// <para>The <see cref="Godot.ImporterMesh"/> resource of the shape. This is only used when the shape type is <c>"hull"</c> (convex hull) or <c>"trimesh"</c> (concave trimesh).</para>
    /// </summary>
    public ImporterMesh ImporterMesh
    {
        get
        {
            return GetImporterMesh();
        }
        set
        {
            SetImporterMesh(value);
        }
    }

    private static readonly System.Type CachedType = typeof(GltfPhysicsShape);

    private static readonly StringName NativeName = "GLTFPhysicsShape";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public GltfPhysicsShape() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal GltfPhysicsShape(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal GltfPhysicsShape(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FromNode, 3613751275ul);

    /// <summary>
    /// <para>Creates a new GLTFPhysicsShape instance from the given Godot <see cref="Godot.CollisionShape3D"/> node.</para>
    /// </summary>
    public static GltfPhysicsShape FromNode(CollisionShape3D shapeNode)
    {
        return (GltfPhysicsShape)NativeCalls.godot_icall_1_637(MethodBind0, GodotObject.GetPtr(shapeNode));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ToNode, 563689933ul);

    /// <summary>
    /// <para>Converts this GLTFPhysicsShape instance into a Godot <see cref="Godot.CollisionShape3D"/> node.</para>
    /// </summary>
    public CollisionShape3D ToNode(bool cacheShapes = false)
    {
        return (CollisionShape3D)NativeCalls.godot_icall_1_223(MethodBind1, GodotObject.GetPtr(this), cacheShapes.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FromResource, 3845569786ul);

    /// <summary>
    /// <para>Creates a new GLTFPhysicsShape instance from the given Godot <see cref="Godot.Shape3D"/> resource.</para>
    /// </summary>
    public static GltfPhysicsShape FromResource(Shape3D shapeResource)
    {
        return (GltfPhysicsShape)NativeCalls.godot_icall_1_637(MethodBind2, GodotObject.GetPtr(shapeResource));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ToResource, 1913542110ul);

    /// <summary>
    /// <para>Converts this GLTFPhysicsShape instance into a Godot <see cref="Godot.Shape3D"/> resource.</para>
    /// </summary>
    public Shape3D ToResource(bool cacheShapes = false)
    {
        return (Shape3D)NativeCalls.godot_icall_1_654(MethodBind3, GodotObject.GetPtr(this), cacheShapes.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FromDictionary, 2390691823ul);

    /// <summary>
    /// <para>Creates a new GLTFPhysicsShape instance by parsing the given <see cref="Godot.Collections.Dictionary"/>.</para>
    /// </summary>
    public static GltfPhysicsShape FromDictionary(Godot.Collections.Dictionary dictionary)
    {
        return (GltfPhysicsShape)NativeCalls.godot_icall_1_633(MethodBind4, (godot_dictionary)(dictionary ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ToDictionary, 3102165223ul);

    /// <summary>
    /// <para>Serializes this GLTFPhysicsShape instance into a <see cref="Godot.Collections.Dictionary"/> in the format defined by <c>OMI_physics_shape</c>.</para>
    /// </summary>
    public Godot.Collections.Dictionary ToDictionary()
    {
        return NativeCalls.godot_icall_0_122(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetShapeType, 201670096ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetShapeType()
    {
        return NativeCalls.godot_icall_0_58(MethodBind6, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetShapeType, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetShapeType(string shapeType)
    {
        NativeCalls.godot_icall_1_57(MethodBind7, GodotObject.GetPtr(this), shapeType);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSize, 3360562783ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector3 GetSize()
    {
        return NativeCalls.godot_icall_0_125(MethodBind8, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSize, 3460891852ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetSize(Vector3 size)
    {
        NativeCalls.godot_icall_1_177(MethodBind9, GodotObject.GetPtr(this), &size);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRadius, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetRadius()
    {
        return NativeCalls.godot_icall_0_68(MethodBind10, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRadius, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetRadius(float radius)
    {
        NativeCalls.godot_icall_1_67(MethodBind11, GodotObject.GetPtr(this), radius);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetHeight, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetHeight()
    {
        return NativeCalls.godot_icall_0_68(MethodBind12, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetHeight, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetHeight(float height)
    {
        NativeCalls.godot_icall_1_67(MethodBind13, GodotObject.GetPtr(this), height);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetIsTrigger, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetIsTrigger()
    {
        return NativeCalls.godot_icall_0_15(MethodBind14, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetIsTrigger, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetIsTrigger(bool isTrigger)
    {
        NativeCalls.godot_icall_1_14(MethodBind15, GodotObject.GetPtr(this), isTrigger.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMeshIndex, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetMeshIndex()
    {
        return NativeCalls.godot_icall_0_39(MethodBind16, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMeshIndex, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMeshIndex(int meshIndex)
    {
        NativeCalls.godot_icall_1_38(MethodBind17, GodotObject.GetPtr(this), meshIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetImporterMesh, 3161779525ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public ImporterMesh GetImporterMesh()
    {
        return (ImporterMesh)NativeCalls.godot_icall_0_63(MethodBind18, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetImporterMesh, 2255166972ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetImporterMesh(ImporterMesh importerMesh)
    {
        NativeCalls.godot_icall_1_56(MethodBind19, GodotObject.GetPtr(this), GodotObject.GetPtr(importerMesh));
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
        /// Cached name for the 'shape_type' property.
        /// </summary>
        public static readonly StringName ShapeType = "shape_type";
        /// <summary>
        /// Cached name for the 'size' property.
        /// </summary>
        public static readonly StringName Size = "size";
        /// <summary>
        /// Cached name for the 'radius' property.
        /// </summary>
        public static readonly StringName Radius = "radius";
        /// <summary>
        /// Cached name for the 'height' property.
        /// </summary>
        public static readonly StringName Height = "height";
        /// <summary>
        /// Cached name for the 'is_trigger' property.
        /// </summary>
        public static readonly StringName IsTrigger = "is_trigger";
        /// <summary>
        /// Cached name for the 'mesh_index' property.
        /// </summary>
        public static readonly StringName MeshIndex = "mesh_index";
        /// <summary>
        /// Cached name for the 'importer_mesh' property.
        /// </summary>
        public static readonly StringName ImporterMesh = "importer_mesh";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Resource.MethodName
    {
        /// <summary>
        /// Cached name for the 'from_node' method.
        /// </summary>
        public static readonly StringName FromNode = "from_node";
        /// <summary>
        /// Cached name for the 'to_node' method.
        /// </summary>
        public static readonly StringName ToNode = "to_node";
        /// <summary>
        /// Cached name for the 'from_resource' method.
        /// </summary>
        public static readonly StringName FromResource = "from_resource";
        /// <summary>
        /// Cached name for the 'to_resource' method.
        /// </summary>
        public static readonly StringName ToResource = "to_resource";
        /// <summary>
        /// Cached name for the 'from_dictionary' method.
        /// </summary>
        public static readonly StringName FromDictionary = "from_dictionary";
        /// <summary>
        /// Cached name for the 'to_dictionary' method.
        /// </summary>
        public static readonly StringName ToDictionary = "to_dictionary";
        /// <summary>
        /// Cached name for the 'get_shape_type' method.
        /// </summary>
        public static readonly StringName GetShapeType = "get_shape_type";
        /// <summary>
        /// Cached name for the 'set_shape_type' method.
        /// </summary>
        public static readonly StringName SetShapeType = "set_shape_type";
        /// <summary>
        /// Cached name for the 'get_size' method.
        /// </summary>
        public static readonly StringName GetSize = "get_size";
        /// <summary>
        /// Cached name for the 'set_size' method.
        /// </summary>
        public static readonly StringName SetSize = "set_size";
        /// <summary>
        /// Cached name for the 'get_radius' method.
        /// </summary>
        public static readonly StringName GetRadius = "get_radius";
        /// <summary>
        /// Cached name for the 'set_radius' method.
        /// </summary>
        public static readonly StringName SetRadius = "set_radius";
        /// <summary>
        /// Cached name for the 'get_height' method.
        /// </summary>
        public static readonly StringName GetHeight = "get_height";
        /// <summary>
        /// Cached name for the 'set_height' method.
        /// </summary>
        public static readonly StringName SetHeight = "set_height";
        /// <summary>
        /// Cached name for the 'get_is_trigger' method.
        /// </summary>
        public static readonly StringName GetIsTrigger = "get_is_trigger";
        /// <summary>
        /// Cached name for the 'set_is_trigger' method.
        /// </summary>
        public static readonly StringName SetIsTrigger = "set_is_trigger";
        /// <summary>
        /// Cached name for the 'get_mesh_index' method.
        /// </summary>
        public static readonly StringName GetMeshIndex = "get_mesh_index";
        /// <summary>
        /// Cached name for the 'set_mesh_index' method.
        /// </summary>
        public static readonly StringName SetMeshIndex = "set_mesh_index";
        /// <summary>
        /// Cached name for the 'get_importer_mesh' method.
        /// </summary>
        public static readonly StringName GetImporterMesh = "get_importer_mesh";
        /// <summary>
        /// Cached name for the 'set_importer_mesh' method.
        /// </summary>
        public static readonly StringName SetImporterMesh = "set_importer_mesh";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Resource.SignalName
    {
    }
}
