namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Base class for all primitive meshes. Handles applying a <see cref="Godot.Material"/> to a primitive mesh. Examples include <see cref="Godot.BoxMesh"/>, <see cref="Godot.CapsuleMesh"/>, <see cref="Godot.CylinderMesh"/>, <see cref="Godot.PlaneMesh"/>, <see cref="Godot.PrismMesh"/>, and <see cref="Godot.SphereMesh"/>.</para>
/// </summary>
public partial class PrimitiveMesh : Mesh
{
    /// <summary>
    /// <para>The current <see cref="Godot.Material"/> of the primitive mesh.</para>
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
    /// <para>If <see langword="true"/>, the order of the vertices in each triangle is reversed, resulting in the backside of the mesh being drawn.</para>
    /// <para>This gives the same result as using <see cref="Godot.BaseMaterial3D.CullModeEnum.Front"/> in <see cref="Godot.BaseMaterial3D.CullMode"/>.</para>
    /// </summary>
    public bool FlipFaces
    {
        get
        {
            return GetFlipFaces();
        }
        set
        {
            SetFlipFaces(value);
        }
    }

    /// <summary>
    /// <para>If set, generates UV2 UV coordinates applying a padding using the <see cref="Godot.PrimitiveMesh.UV2Padding"/> setting. UV2 is needed for lightmapping.</para>
    /// </summary>
    public bool AddUV2
    {
        get
        {
            return GetAddUV2();
        }
        set
        {
            SetAddUV2(value);
        }
    }

    /// <summary>
    /// <para>If <see cref="Godot.PrimitiveMesh.AddUV2"/> is set, specifies the padding in pixels applied along seams of the mesh. Lower padding values allow making better use of the lightmap texture (resulting in higher texel density), but may introduce visible lightmap bleeding along edges.</para>
    /// <para>If the size of the lightmap texture can't be determined when generating the mesh, UV2 is calculated assuming a texture size of 1024x1024.</para>
    /// </summary>
    public float UV2Padding
    {
        get
        {
            return GetUV2Padding();
        }
        set
        {
            SetUV2Padding(value);
        }
    }

    private static readonly System.Type CachedType = typeof(PrimitiveMesh);

    private static readonly StringName NativeName = "PrimitiveMesh";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public PrimitiveMesh() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal PrimitiveMesh(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal PrimitiveMesh(bool memoryOwn) : base(memoryOwn) { }

    /// <summary>
    /// <para>Override this method to customize how this primitive mesh should be generated. Should return an <see cref="Godot.Collections.Array"/> where each element is another Array of values required for the mesh (see the <see cref="Godot.Mesh.ArrayType"/> constants).</para>
    /// </summary>
    public virtual Godot.Collections.Array _CreateMeshArray()
    {
        return default;
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMaterial, 2757459619ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMaterial(Material material)
    {
        NativeCalls.godot_icall_1_56(MethodBind0, GodotObject.GetPtr(this), GodotObject.GetPtr(material));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMaterial, 5934680ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Material GetMaterial()
    {
        return (Material)NativeCalls.godot_icall_0_63(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMeshArrays, 3995934104ul);

    /// <summary>
    /// <para>Returns the mesh arrays used to make up the surface of this primitive mesh.</para>
    /// <para><b>Example:</b> Pass the result to <see cref="Godot.ArrayMesh.AddSurfaceFromArrays(Mesh.PrimitiveType, Godot.Collections.Array, Godot.Collections.Array{Godot.Collections.Array}, Godot.Collections.Dictionary, Mesh.ArrayFormat)"/> to create a new surface:</para>
    /// <para><code>
    /// var c = new CylinderMesh();
    /// var arrMesh = new ArrayMesh();
    /// arrMesh.AddSurfaceFromArrays(Mesh.PrimitiveType.Triangles, c.GetMeshArrays());
    /// </code></para>
    /// </summary>
    public Godot.Collections.Array GetMeshArrays()
    {
        return NativeCalls.godot_icall_0_120(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCustomAabb, 259215842ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetCustomAabb(Aabb aabb)
    {
        NativeCalls.godot_icall_1_183(MethodBind3, GodotObject.GetPtr(this), &aabb);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCustomAabb, 1068685055ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Aabb GetCustomAabb()
    {
        return NativeCalls.godot_icall_0_184(MethodBind4, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFlipFaces, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFlipFaces(bool flipFaces)
    {
        NativeCalls.godot_icall_1_14(MethodBind5, GodotObject.GetPtr(this), flipFaces.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFlipFaces, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetFlipFaces()
    {
        return NativeCalls.godot_icall_0_15(MethodBind6, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAddUV2, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAddUV2(bool addUV2)
    {
        NativeCalls.godot_icall_1_14(MethodBind7, GodotObject.GetPtr(this), addUV2.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAddUV2, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetAddUV2()
    {
        return NativeCalls.godot_icall_0_15(MethodBind8, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetUV2Padding, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetUV2Padding(float uV2Padding)
    {
        NativeCalls.godot_icall_1_67(MethodBind9, GodotObject.GetPtr(this), uV2Padding);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetUV2Padding, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetUV2Padding()
    {
        return NativeCalls.godot_icall_0_68(MethodBind10, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RequestUpdate, 3218959716ul);

    /// <summary>
    /// <para>Request an update of this primitive mesh based on its properties.</para>
    /// </summary>
    public void RequestUpdate()
    {
        NativeCalls.godot_icall_0_3(MethodBind11, GodotObject.GetPtr(this));
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__create_mesh_array = "_CreateMeshArray";

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
        if ((method == MethodProxyName__create_mesh_array || method == MethodName._CreateMeshArray) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__create_mesh_array.NativeValue))
        {
            var callRet = _CreateMeshArray();
            ret = VariantUtils.CreateFrom<Godot.Collections.Array>(callRet);
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
        if (method == MethodName._CreateMeshArray)
        {
            if (HasGodotClassMethod(MethodProxyName__create_mesh_array.NativeValue.DangerousSelfRef))
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
    public new class PropertyName : Mesh.PropertyName
    {
        /// <summary>
        /// Cached name for the 'material' property.
        /// </summary>
        public static readonly StringName Material = "material";
        /// <summary>
        /// Cached name for the 'custom_aabb' property.
        /// </summary>
        public static readonly StringName CustomAabb = "custom_aabb";
        /// <summary>
        /// Cached name for the 'flip_faces' property.
        /// </summary>
        public static readonly StringName FlipFaces = "flip_faces";
        /// <summary>
        /// Cached name for the 'add_uv2' property.
        /// </summary>
        public static readonly StringName AddUV2 = "add_uv2";
        /// <summary>
        /// Cached name for the 'uv2_padding' property.
        /// </summary>
        public static readonly StringName UV2Padding = "uv2_padding";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Mesh.MethodName
    {
        /// <summary>
        /// Cached name for the '_create_mesh_array' method.
        /// </summary>
        public static readonly StringName _CreateMeshArray = "_create_mesh_array";
        /// <summary>
        /// Cached name for the 'set_material' method.
        /// </summary>
        public static readonly StringName SetMaterial = "set_material";
        /// <summary>
        /// Cached name for the 'get_material' method.
        /// </summary>
        public static readonly StringName GetMaterial = "get_material";
        /// <summary>
        /// Cached name for the 'get_mesh_arrays' method.
        /// </summary>
        public static readonly StringName GetMeshArrays = "get_mesh_arrays";
        /// <summary>
        /// Cached name for the 'set_custom_aabb' method.
        /// </summary>
        public static readonly StringName SetCustomAabb = "set_custom_aabb";
        /// <summary>
        /// Cached name for the 'get_custom_aabb' method.
        /// </summary>
        public static readonly StringName GetCustomAabb = "get_custom_aabb";
        /// <summary>
        /// Cached name for the 'set_flip_faces' method.
        /// </summary>
        public static readonly StringName SetFlipFaces = "set_flip_faces";
        /// <summary>
        /// Cached name for the 'get_flip_faces' method.
        /// </summary>
        public static readonly StringName GetFlipFaces = "get_flip_faces";
        /// <summary>
        /// Cached name for the 'set_add_uv2' method.
        /// </summary>
        public static readonly StringName SetAddUV2 = "set_add_uv2";
        /// <summary>
        /// Cached name for the 'get_add_uv2' method.
        /// </summary>
        public static readonly StringName GetAddUV2 = "get_add_uv2";
        /// <summary>
        /// Cached name for the 'set_uv2_padding' method.
        /// </summary>
        public static readonly StringName SetUV2Padding = "set_uv2_padding";
        /// <summary>
        /// Cached name for the 'get_uv2_padding' method.
        /// </summary>
        public static readonly StringName GetUV2Padding = "get_uv2_padding";
        /// <summary>
        /// Cached name for the 'request_update' method.
        /// </summary>
        public static readonly StringName RequestUpdate = "request_update";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Mesh.SignalName
    {
    }
}
