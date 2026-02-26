namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>GLTFObjectModelProperty defines a mapping between a property in the glTF object model and a NodePath in the Godot scene tree. This can be used to animate properties in a glTF file using the <c>KHR_animation_pointer</c> extension, or to access them through an engine-agnostic script such as a behavior graph as defined by the <c>KHR_interactivity</c> extension.</para>
/// <para>The glTF property is identified by JSON pointer(s) stored in <see cref="Godot.GltfObjectModelProperty.JsonPointers"/>, while the Godot property it maps to is defined by <see cref="Godot.GltfObjectModelProperty.NodePaths"/>. In most cases <see cref="Godot.GltfObjectModelProperty.JsonPointers"/> and <see cref="Godot.GltfObjectModelProperty.NodePaths"/> will each only have one item, but in some cases a single glTF JSON pointer will map to multiple Godot properties, or a single Godot property will be mapped to multiple glTF JSON pointers, or it might be a many-to-many relationship.</para>
/// <para><see cref="Godot.Expression"/> objects can be used to define conversions between the data, such as when glTF defines an angle in radians and Godot uses degrees. The <see cref="Godot.GltfObjectModelProperty.ObjectModelType"/> property defines the type of data stored in the glTF file as defined by the object model, see <see cref="Godot.GltfObjectModelProperty.GltfObjectModelType"/> for possible values.</para>
/// </summary>
[GodotClassName("GLTFObjectModelProperty")]
public partial class GltfObjectModelProperty : RefCounted
{
    public enum GltfObjectModelType : long
    {
        /// <summary>
        /// <para>Unknown or not set object model type. If the object model type is set to this value, the real type still needs to be determined.</para>
        /// </summary>
        Unknown = 0,
        /// <summary>
        /// <para>Object model type "bool". Represented in the glTF JSON as a boolean, and encoded in a <see cref="Godot.GltfAccessor"/> as "SCALAR". When encoded in an accessor, a value of <c>0</c> is <see langword="false"/>, and any other value is <see langword="true"/>.</para>
        /// </summary>
        Bool = 1,
        /// <summary>
        /// <para>Object model type "float". Represented in the glTF JSON as a number, and encoded in a <see cref="Godot.GltfAccessor"/> as "SCALAR".</para>
        /// </summary>
        Float = 2,
        /// <summary>
        /// <para>Object model type "float[lb][rb]". Represented in the glTF JSON as an array of numbers, and encoded in a <see cref="Godot.GltfAccessor"/> as "SCALAR".</para>
        /// </summary>
        FloatArray = 3,
        /// <summary>
        /// <para>Object model type "float2". Represented in the glTF JSON as an array of two numbers, and encoded in a <see cref="Godot.GltfAccessor"/> as "VEC2".</para>
        /// </summary>
        Float2 = 4,
        /// <summary>
        /// <para>Object model type "float3". Represented in the glTF JSON as an array of three numbers, and encoded in a <see cref="Godot.GltfAccessor"/> as "VEC3".</para>
        /// </summary>
        Float3 = 5,
        /// <summary>
        /// <para>Object model type "float4". Represented in the glTF JSON as an array of four numbers, and encoded in a <see cref="Godot.GltfAccessor"/> as "VEC4".</para>
        /// </summary>
        Float4 = 6,
        /// <summary>
        /// <para>Object model type "float2x2". Represented in the glTF JSON as an array of four numbers, and encoded in a <see cref="Godot.GltfAccessor"/> as "MAT2".</para>
        /// </summary>
        Float2X2 = 7,
        /// <summary>
        /// <para>Object model type "float3x3". Represented in the glTF JSON as an array of nine numbers, and encoded in a <see cref="Godot.GltfAccessor"/> as "MAT3".</para>
        /// </summary>
        Float3X3 = 8,
        /// <summary>
        /// <para>Object model type "float4x4". Represented in the glTF JSON as an array of sixteen numbers, and encoded in a <see cref="Godot.GltfAccessor"/> as "MAT4".</para>
        /// </summary>
        Float4X4 = 9,
        /// <summary>
        /// <para>Object model type "int". Represented in the glTF JSON as a number, and encoded in a <see cref="Godot.GltfAccessor"/> as "SCALAR". The range of values is limited to signed integers. For <c>KHR_interactivity</c>, only 32-bit integers are supported.</para>
        /// </summary>
        Int = 10
    }

    /// <summary>
    /// <para>If set, this <see cref="Godot.Expression"/> will be used to convert the property value from the glTF object model to the value expected by the Godot property. This is useful when the glTF object model uses a different unit system, or when the data needs to be transformed in some way. If <see langword="null"/>, the value will be copied as-is.</para>
    /// </summary>
    public Expression GltfToGodotExpression
    {
        get
        {
            return GetGltfToGodotExpression();
        }
        set
        {
            SetGltfToGodotExpression(value);
        }
    }

    /// <summary>
    /// <para>If set, this <see cref="Godot.Expression"/> will be used to convert the property value from the Godot property to the value expected by the glTF object model. This is useful when the glTF object model uses a different unit system, or when the data needs to be transformed in some way. If <see langword="null"/>, the value will be copied as-is.</para>
    /// </summary>
    public Expression GodotToGltfExpression
    {
        get
        {
            return GetGodotToGltfExpression();
        }
        set
        {
            SetGodotToGltfExpression(value);
        }
    }

    /// <summary>
    /// <para>An array of <see cref="Godot.NodePath"/>s that point to a property, or multiple properties, in the Godot scene tree. On import, this will either be set by <see cref="Godot.GltfDocument"/>, or by a <see cref="Godot.GltfDocumentExtension"/> class. For simple cases, use <see cref="Godot.GltfObjectModelProperty.AppendPathToProperty(NodePath, StringName)"/> to add properties to this array.</para>
    /// <para>In most cases <see cref="Godot.GltfObjectModelProperty.NodePaths"/> will only have one item, but in some cases a single glTF JSON pointer will map to multiple Godot properties. For example, a <see cref="Godot.GltfCamera"/> or <see cref="Godot.GltfLight"/> used on multiple glTF nodes will be represented by multiple Godot nodes.</para>
    /// </summary>
    public Godot.Collections.Array<NodePath> NodePaths
    {
        get
        {
            return GetNodePaths();
        }
        set
        {
            SetNodePaths(value);
        }
    }

    /// <summary>
    /// <para>The type of data stored in the glTF file as defined by the object model. This is a superset of the available accessor types, and determines the accessor type.</para>
    /// </summary>
    public GltfObjectModelProperty.GltfObjectModelType ObjectModelType
    {
        get
        {
            return GetObjectModelType();
        }
        set
        {
            SetObjectModelType(value);
        }
    }

    /// <summary>
    /// <para>The glTF object model JSON pointers used to identify the property in the glTF object model. In most cases, there will be only one item in this array, but specific cases may require multiple pointers. The items are themselves arrays which represent the JSON pointer split into its components.</para>
    /// </summary>
    public Godot.Collections.Array<string[]> JsonPointers
    {
        get
        {
            return GetJsonPointers();
        }
        set
        {
            SetJsonPointers(value);
        }
    }

    /// <summary>
    /// <para>The type of data stored in the Godot property. This is the type of the property that the <see cref="Godot.GltfObjectModelProperty.NodePaths"/> point to.</para>
    /// </summary>
    public Variant.Type VariantType
    {
        get
        {
            return GetVariantType();
        }
        set
        {
            SetVariantType(value);
        }
    }

    private static readonly System.Type CachedType = typeof(GltfObjectModelProperty);

    private static readonly StringName NativeName = "GLTFObjectModelProperty";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public GltfObjectModelProperty() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal GltfObjectModelProperty(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal GltfObjectModelProperty(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AppendNodePath, 1348162250ul);

    /// <summary>
    /// <para>Appends a <see cref="Godot.NodePath"/> to <see cref="Godot.GltfObjectModelProperty.NodePaths"/>. This can be used by <see cref="Godot.GltfDocumentExtension"/> classes to define how a glTF object model property maps to a Godot property, or multiple Godot properties. Prefer using <see cref="Godot.GltfObjectModelProperty.AppendPathToProperty(NodePath, StringName)"/> for simple cases. Be sure to also call <see cref="Godot.GltfObjectModelProperty.SetTypes(Variant.Type, GltfObjectModelProperty.GltfObjectModelType)"/> once (the order does not matter).</para>
    /// </summary>
    public void AppendNodePath(NodePath nodePath)
    {
        NativeCalls.godot_icall_1_123(MethodBind0, GodotObject.GetPtr(this), (godot_node_path)(nodePath?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AppendPathToProperty, 1331931644ul);

    /// <summary>
    /// <para>High-level wrapper over <see cref="Godot.GltfObjectModelProperty.AppendNodePath(NodePath)"/> that handles the most common cases. It constructs a new <see cref="Godot.NodePath"/> using <paramref name="nodePath"/> as a base and appends <paramref name="propName"/> to the subpath. Be sure to also call <see cref="Godot.GltfObjectModelProperty.SetTypes(Variant.Type, GltfObjectModelProperty.GltfObjectModelType)"/> once (the order does not matter).</para>
    /// </summary>
    public void AppendPathToProperty(NodePath nodePath, StringName propName)
    {
        NativeCalls.godot_icall_2_651(MethodBind1, GodotObject.GetPtr(this), (godot_node_path)(nodePath?.NativeValue ?? default), (godot_string_name)(propName?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAccessorType, 1998183368ul);

    /// <summary>
    /// <para>The GLTF accessor type associated with this property's <see cref="Godot.GltfObjectModelProperty.ObjectModelType"/>. See <see cref="Godot.GltfAccessor.AccessorType"/> for possible values, and see <see cref="Godot.GltfObjectModelProperty.GltfObjectModelType"/> for how the object model type maps to accessor types.</para>
    /// </summary>
    public GltfAccessor.GltfAccessorType GetAccessorType()
    {
        return (GltfAccessor.GltfAccessorType)NativeCalls.godot_icall_0_39(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetGltfToGodotExpression, 2240072449ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Expression GetGltfToGodotExpression()
    {
        return (Expression)NativeCalls.godot_icall_0_63(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetGltfToGodotExpression, 1815845073ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetGltfToGodotExpression(Expression gltfToGodotExpr)
    {
        NativeCalls.godot_icall_1_56(MethodBind4, GodotObject.GetPtr(this), GodotObject.GetPtr(gltfToGodotExpr));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetGodotToGltfExpression, 2240072449ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Expression GetGodotToGltfExpression()
    {
        return (Expression)NativeCalls.godot_icall_0_63(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetGodotToGltfExpression, 1815845073ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetGodotToGltfExpression(Expression godotToGltfExpr)
    {
        NativeCalls.godot_icall_1_56(MethodBind6, GodotObject.GetPtr(this), GodotObject.GetPtr(godotToGltfExpr));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNodePaths, 3995934104ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Godot.Collections.Array<NodePath> GetNodePaths()
    {
        return new Godot.Collections.Array<NodePath>(NativeCalls.godot_icall_0_120(MethodBind7, GodotObject.GetPtr(this)));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasNodePaths, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if <see cref="Godot.GltfObjectModelProperty.NodePaths"/> is not empty. This is used during import to determine if a <see cref="Godot.GltfObjectModelProperty"/> can handle converting a glTF object model property to a Godot property.</para>
    /// </summary>
    public bool HasNodePaths()
    {
        return NativeCalls.godot_icall_0_15(MethodBind8, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetNodePaths, 381264803ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetNodePaths(Godot.Collections.Array<NodePath> nodePaths)
    {
        NativeCalls.godot_icall_1_138(MethodBind9, GodotObject.GetPtr(this), (godot_array)(nodePaths ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetObjectModelType, 1094778507ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public GltfObjectModelProperty.GltfObjectModelType GetObjectModelType()
    {
        return (GltfObjectModelProperty.GltfObjectModelType)NativeCalls.godot_icall_0_39(MethodBind10, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetObjectModelType, 4108684086ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetObjectModelType(GltfObjectModelProperty.GltfObjectModelType type)
    {
        NativeCalls.godot_icall_1_38(MethodBind11, GodotObject.GetPtr(this), (int)type);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetJsonPointers, 3995934104ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Godot.Collections.Array<string[]> GetJsonPointers()
    {
        return new Godot.Collections.Array<string[]>(NativeCalls.godot_icall_0_120(MethodBind12, GodotObject.GetPtr(this)));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasJsonPointers, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if <see cref="Godot.GltfObjectModelProperty.JsonPointers"/> is not empty. This is used during export to determine if a <see cref="Godot.GltfObjectModelProperty"/> can handle converting a Godot property to a glTF object model property.</para>
    /// </summary>
    public bool HasJsonPointers()
    {
        return NativeCalls.godot_icall_0_15(MethodBind13, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetJsonPointers, 381264803ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetJsonPointers(Godot.Collections.Array<string[]> jsonPointers)
    {
        NativeCalls.godot_icall_1_138(MethodBind14, GodotObject.GetPtr(this), (godot_array)(jsonPointers ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVariantType, 3416842102ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Variant.Type GetVariantType()
    {
        return (Variant.Type)NativeCalls.godot_icall_0_39(MethodBind15, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVariantType, 2887708385ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetVariantType(Variant.Type variantType)
    {
        NativeCalls.godot_icall_1_38(MethodBind16, GodotObject.GetPtr(this), (int)variantType);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTypes, 4150728237ul);

    /// <summary>
    /// <para>Sets the <see cref="Godot.GltfObjectModelProperty.VariantType"/> and <see cref="Godot.GltfObjectModelProperty.ObjectModelType"/> properties. This is a convenience method to set both properties at once, since they are almost always known at the same time. This method should be called once. Calling it again with the same values will have no effect.</para>
    /// </summary>
    public void SetTypes(Variant.Type variantType, GltfObjectModelProperty.GltfObjectModelType objModelType)
    {
        NativeCalls.godot_icall_2_59(MethodBind17, GodotObject.GetPtr(this), (int)variantType, (int)objModelType);
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
        /// <summary>
        /// Cached name for the 'gltf_to_godot_expression' property.
        /// </summary>
        public static readonly StringName GltfToGodotExpression = "gltf_to_godot_expression";
        /// <summary>
        /// Cached name for the 'godot_to_gltf_expression' property.
        /// </summary>
        public static readonly StringName GodotToGltfExpression = "godot_to_gltf_expression";
        /// <summary>
        /// Cached name for the 'node_paths' property.
        /// </summary>
        public static readonly StringName NodePaths = "node_paths";
        /// <summary>
        /// Cached name for the 'object_model_type' property.
        /// </summary>
        public static readonly StringName ObjectModelType = "object_model_type";
        /// <summary>
        /// Cached name for the 'json_pointers' property.
        /// </summary>
        public static readonly StringName JsonPointers = "json_pointers";
        /// <summary>
        /// Cached name for the 'variant_type' property.
        /// </summary>
        public static readonly StringName VariantType = "variant_type";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : RefCounted.MethodName
    {
        /// <summary>
        /// Cached name for the 'append_node_path' method.
        /// </summary>
        public static readonly StringName AppendNodePath = "append_node_path";
        /// <summary>
        /// Cached name for the 'append_path_to_property' method.
        /// </summary>
        public static readonly StringName AppendPathToProperty = "append_path_to_property";
        /// <summary>
        /// Cached name for the 'get_accessor_type' method.
        /// </summary>
        public static readonly StringName GetAccessorType = "get_accessor_type";
        /// <summary>
        /// Cached name for the 'get_gltf_to_godot_expression' method.
        /// </summary>
        public static readonly StringName GetGltfToGodotExpression = "get_gltf_to_godot_expression";
        /// <summary>
        /// Cached name for the 'set_gltf_to_godot_expression' method.
        /// </summary>
        public static readonly StringName SetGltfToGodotExpression = "set_gltf_to_godot_expression";
        /// <summary>
        /// Cached name for the 'get_godot_to_gltf_expression' method.
        /// </summary>
        public static readonly StringName GetGodotToGltfExpression = "get_godot_to_gltf_expression";
        /// <summary>
        /// Cached name for the 'set_godot_to_gltf_expression' method.
        /// </summary>
        public static readonly StringName SetGodotToGltfExpression = "set_godot_to_gltf_expression";
        /// <summary>
        /// Cached name for the 'get_node_paths' method.
        /// </summary>
        public static readonly StringName GetNodePaths = "get_node_paths";
        /// <summary>
        /// Cached name for the 'has_node_paths' method.
        /// </summary>
        public static readonly StringName HasNodePaths = "has_node_paths";
        /// <summary>
        /// Cached name for the 'set_node_paths' method.
        /// </summary>
        public static readonly StringName SetNodePaths = "set_node_paths";
        /// <summary>
        /// Cached name for the 'get_object_model_type' method.
        /// </summary>
        public static readonly StringName GetObjectModelType = "get_object_model_type";
        /// <summary>
        /// Cached name for the 'set_object_model_type' method.
        /// </summary>
        public static readonly StringName SetObjectModelType = "set_object_model_type";
        /// <summary>
        /// Cached name for the 'get_json_pointers' method.
        /// </summary>
        public static readonly StringName GetJsonPointers = "get_json_pointers";
        /// <summary>
        /// Cached name for the 'has_json_pointers' method.
        /// </summary>
        public static readonly StringName HasJsonPointers = "has_json_pointers";
        /// <summary>
        /// Cached name for the 'set_json_pointers' method.
        /// </summary>
        public static readonly StringName SetJsonPointers = "set_json_pointers";
        /// <summary>
        /// Cached name for the 'get_variant_type' method.
        /// </summary>
        public static readonly StringName GetVariantType = "get_variant_type";
        /// <summary>
        /// Cached name for the 'set_variant_type' method.
        /// </summary>
        public static readonly StringName SetVariantType = "set_variant_type";
        /// <summary>
        /// Cached name for the 'set_types' method.
        /// </summary>
        public static readonly StringName SetTypes = "set_types";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : RefCounted.SignalName
    {
    }
}
