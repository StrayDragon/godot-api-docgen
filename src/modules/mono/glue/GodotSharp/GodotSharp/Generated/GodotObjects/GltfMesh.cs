namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>GLTFMesh handles 3D mesh data imported from glTF files. It includes properties for blend channels, blend weights, instance materials, and the mesh itself.</para>
/// </summary>
[GodotClassName("GLTFMesh")]
public partial class GltfMesh : Resource
{
    /// <summary>
    /// <para>The original name of the mesh.</para>
    /// </summary>
    public string OriginalName
    {
        get
        {
            return GetOriginalName();
        }
        set
        {
            SetOriginalName(value);
        }
    }

    /// <summary>
    /// <para>The <see cref="Godot.ImporterMesh"/> object representing the mesh itself.</para>
    /// </summary>
    public ImporterMesh Mesh
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
    /// <para>An array of floats representing the blend weights of the mesh.</para>
    /// </summary>
    public float[] BlendWeights
    {
        get
        {
            return GetBlendWeights();
        }
        set
        {
            SetBlendWeights(value);
        }
    }

    /// <summary>
    /// <para>An array of Material objects representing the materials used in the mesh.</para>
    /// </summary>
    public Godot.Collections.Array<Material> InstanceMaterials
    {
        get
        {
            return GetInstanceMaterials();
        }
        set
        {
            SetInstanceMaterials(value);
        }
    }

    private static readonly System.Type CachedType = typeof(GltfMesh);

    private static readonly StringName NativeName = "GLTFMesh";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public GltfMesh() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal GltfMesh(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal GltfMesh(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOriginalName, 2841200299ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetOriginalName()
    {
        return NativeCalls.godot_icall_0_58(MethodBind0, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetOriginalName, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetOriginalName(string originalName)
    {
        NativeCalls.godot_icall_1_57(MethodBind1, GodotObject.GetPtr(this), originalName);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMesh, 3754628756ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public ImporterMesh GetMesh()
    {
        return (ImporterMesh)NativeCalls.godot_icall_0_63(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMesh, 2255166972ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMesh(ImporterMesh mesh)
    {
        NativeCalls.godot_icall_1_56(MethodBind3, GodotObject.GetPtr(this), GodotObject.GetPtr(mesh));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBlendWeights, 2445143706ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float[] GetBlendWeights()
    {
        return NativeCalls.godot_icall_0_368(MethodBind4, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBlendWeights, 2899603908ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetBlendWeights(float[] blendWeights)
    {
        NativeCalls.godot_icall_1_647(MethodBind5, GodotObject.GetPtr(this), blendWeights);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetBlendWeights(ReadOnlySpan<float> blendWeights)
    {
        NativeCalls.godot_icall_1_647(MethodBind5, GodotObject.GetPtr(this), blendWeights);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetInstanceMaterials, 2915620761ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Godot.Collections.Array<Material> GetInstanceMaterials()
    {
        return new Godot.Collections.Array<Material>(NativeCalls.godot_icall_0_120(MethodBind6, GodotObject.GetPtr(this)));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetInstanceMaterials, 381264803ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetInstanceMaterials(Godot.Collections.Array<Material> instanceMaterials)
    {
        NativeCalls.godot_icall_1_138(MethodBind7, GodotObject.GetPtr(this), (godot_array)(instanceMaterials ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAdditionalData, 2138907829ul);

    /// <summary>
    /// <para>Gets additional arbitrary data in this <see cref="Godot.GltfMesh"/> instance. This can be used to keep per-node state data in <see cref="Godot.GltfDocumentExtension"/> classes, which is important because they are stateless.</para>
    /// <para>The argument should be the <see cref="Godot.GltfDocumentExtension"/> name (does not have to match the extension name in the glTF file), and the return value can be anything you set. If nothing was set, the return value is <see langword="null"/>.</para>
    /// </summary>
    public Variant GetAdditionalData(StringName extensionName)
    {
        return NativeCalls.godot_icall_1_143(MethodBind8, GodotObject.GetPtr(this), (godot_string_name)(extensionName?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAdditionalData, 3776071444ul);

    /// <summary>
    /// <para>Sets additional arbitrary data in this <see cref="Godot.GltfMesh"/> instance. This can be used to keep per-node state data in <see cref="Godot.GltfDocumentExtension"/> classes, which is important because they are stateless.</para>
    /// <para>The first argument should be the <see cref="Godot.GltfDocumentExtension"/> name (does not have to match the extension name in the glTF file), and the second argument can be anything you want.</para>
    /// </summary>
    public void SetAdditionalData(StringName extensionName, Variant additionalData)
    {
        NativeCalls.godot_icall_2_142(MethodBind9, GodotObject.GetPtr(this), (godot_string_name)(extensionName?.NativeValue ?? default), additionalData);
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
        /// Cached name for the 'original_name' property.
        /// </summary>
        public static readonly StringName OriginalName = "original_name";
        /// <summary>
        /// Cached name for the 'mesh' property.
        /// </summary>
        public static readonly StringName Mesh = "mesh";
        /// <summary>
        /// Cached name for the 'blend_weights' property.
        /// </summary>
        public static readonly StringName BlendWeights = "blend_weights";
        /// <summary>
        /// Cached name for the 'instance_materials' property.
        /// </summary>
        public static readonly StringName InstanceMaterials = "instance_materials";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Resource.MethodName
    {
        /// <summary>
        /// Cached name for the 'get_original_name' method.
        /// </summary>
        public static readonly StringName GetOriginalName = "get_original_name";
        /// <summary>
        /// Cached name for the 'set_original_name' method.
        /// </summary>
        public static readonly StringName SetOriginalName = "set_original_name";
        /// <summary>
        /// Cached name for the 'get_mesh' method.
        /// </summary>
        public static readonly StringName GetMesh = "get_mesh";
        /// <summary>
        /// Cached name for the 'set_mesh' method.
        /// </summary>
        public static readonly StringName SetMesh = "set_mesh";
        /// <summary>
        /// Cached name for the 'get_blend_weights' method.
        /// </summary>
        public static readonly StringName GetBlendWeights = "get_blend_weights";
        /// <summary>
        /// Cached name for the 'set_blend_weights' method.
        /// </summary>
        public static readonly StringName SetBlendWeights = "set_blend_weights";
        /// <summary>
        /// Cached name for the 'get_instance_materials' method.
        /// </summary>
        public static readonly StringName GetInstanceMaterials = "get_instance_materials";
        /// <summary>
        /// Cached name for the 'set_instance_materials' method.
        /// </summary>
        public static readonly StringName SetInstanceMaterials = "set_instance_materials";
        /// <summary>
        /// Cached name for the 'get_additional_data' method.
        /// </summary>
        public static readonly StringName GetAdditionalData = "get_additional_data";
        /// <summary>
        /// Cached name for the 'set_additional_data' method.
        /// </summary>
        public static readonly StringName SetAdditionalData = "set_additional_data";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Resource.SignalName
    {
    }
}
