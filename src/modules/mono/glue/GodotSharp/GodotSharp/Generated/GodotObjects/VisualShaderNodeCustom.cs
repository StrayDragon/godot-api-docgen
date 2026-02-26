namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>By inheriting this class you can create a custom <see cref="Godot.VisualShader"/> script addon which will be automatically added to the Visual Shader Editor. The <see cref="Godot.VisualShaderNode"/>'s behavior is defined by overriding the provided virtual methods.</para>
/// <para>In order for the node to be registered as an editor addon, you must use the <c>@tool</c> annotation and provide a <c>class_name</c> for your custom script. For example:</para>
/// <para><code>
/// @tool
/// extends VisualShaderNodeCustom
/// class_name VisualShaderNodeNoise
/// </code></para>
/// </summary>
public partial class VisualShaderNodeCustom : VisualShaderNode
{
    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public bool Initialized
    {
        get
        {
            return _IsInitialized();
        }
        set
        {
            _SetInitialized(value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public string Properties
    {
        get
        {
            return _GetProperties();
        }
        set
        {
            _SetProperties(value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    private static readonly System.Type CachedType = typeof(VisualShaderNodeCustom);

    private static readonly StringName NativeName = "VisualShaderNodeCustom";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public VisualShaderNodeCustom() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal VisualShaderNodeCustom(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal VisualShaderNodeCustom(bool memoryOwn) : base(memoryOwn) { }

    /// <summary>
    /// <para>Override this method to define the path to the associated custom node in the Visual Shader Editor's members dialog. The path may look like <c>"MyGame/MyFunctions/Noise"</c>.</para>
    /// <para>Defining this method is <b>optional</b>. If not overridden, the node will be filed under the "Addons" category.</para>
    /// </summary>
    public virtual string _GetCategory()
    {
        return default;
    }

    /// <summary>
    /// <para>Override this method to define the actual shader code of the associated custom node. The shader code should be returned as a string, which can have multiple lines (the <c>"""</c> multiline string construct can be used for convenience).</para>
    /// <para>The <paramref name="inputVars"/> and <paramref name="outputVars"/> arrays contain the string names of the various input and output variables, as defined by <c>_get_input_*</c> and <c>_get_output_*</c> virtual methods in this class.</para>
    /// <para>The output ports can be assigned values in the shader code. For example, <c>return output_vars[0] + " = " + input_vars[0] + ";"</c>.</para>
    /// <para>You can customize the generated code based on the shader <paramref name="mode"/> and/or <paramref name="type"/>.</para>
    /// <para>Defining this method is <b>required</b>.</para>
    /// </summary>
    public virtual string _GetCode(Godot.Collections.Array<string> inputVars, Godot.Collections.Array<string> outputVars, Shader.Mode mode, VisualShader.Type type)
    {
        return default;
    }

    /// <summary>
    /// <para>Override this method to define the input port which should be connected by default when this node is created as a result of dragging a connection from an existing node to the empty space on the graph.</para>
    /// <para>Defining this method is <b>optional</b>. If not overridden, the connection will be created to the first valid port.</para>
    /// </summary>
    public virtual int _GetDefaultInputPort(VisualShaderNode.PortType type)
    {
        return default;
    }

    /// <summary>
    /// <para>Override this method to define the description of the associated custom node in the Visual Shader Editor's members dialog.</para>
    /// <para>Defining this method is <b>optional</b>.</para>
    /// </summary>
    public virtual string _GetDescription()
    {
        return default;
    }

    /// <summary>
    /// <para>Override this method to add a shader code to the beginning of each shader function (once). The shader code should be returned as a string, which can have multiple lines (the <c>"""</c> multiline string construct can be used for convenience).</para>
    /// <para>If there are multiple custom nodes of different types which use this feature the order of each insertion is undefined.</para>
    /// <para>You can customize the generated code based on the shader <paramref name="mode"/> and/or <paramref name="type"/>.</para>
    /// <para>Defining this method is <b>optional</b>.</para>
    /// </summary>
    public virtual string _GetFuncCode(Shader.Mode mode, VisualShader.Type type)
    {
        return default;
    }

    /// <summary>
    /// <para>Override this method to add shader code on top of the global shader, to define your own standard library of reusable methods, varyings, constants, uniforms, etc. The shader code should be returned as a string, which can have multiple lines (the <c>"""</c> multiline string construct can be used for convenience).</para>
    /// <para>Be careful with this functionality as it can cause name conflicts with other custom nodes, so be sure to give the defined entities unique names.</para>
    /// <para>You can customize the generated code based on the shader <paramref name="mode"/>.</para>
    /// <para>Defining this method is <b>optional</b>.</para>
    /// </summary>
    public virtual string _GetGlobalCode(Shader.Mode mode)
    {
        return default;
    }

    /// <summary>
    /// <para>Override this method to define the number of input ports of the associated custom node.</para>
    /// <para>Defining this method is <b>required</b>. If not overridden, the node has no input ports.</para>
    /// </summary>
    public virtual int _GetInputPortCount()
    {
        return default;
    }

    /// <summary>
    /// <para>Override this method to define the default value for the specified input port. Prefer use this over <see cref="Godot.VisualShaderNode.SetInputPortDefaultValue(int, Variant, Variant)"/>.</para>
    /// <para>Defining this method is <b>required</b>. If not overridden, the node has no default values for their input ports.</para>
    /// </summary>
    public virtual Variant _GetInputPortDefaultValue(int port)
    {
        return default;
    }

    /// <summary>
    /// <para>Override this method to define the names of input ports of the associated custom node. The names are used both for the input slots in the editor and as identifiers in the shader code, and are passed in the <c>input_vars</c> array in <see cref="Godot.VisualShaderNodeCustom._GetCode(Godot.Collections.Array{string}, Godot.Collections.Array{string}, Shader.Mode, VisualShader.Type)"/>.</para>
    /// <para>Defining this method is <b>optional</b>, but recommended. If not overridden, input ports are named as <c>"in" + str(port)</c>.</para>
    /// </summary>
    public virtual string _GetInputPortName(int port)
    {
        return default;
    }

    /// <summary>
    /// <para>Override this method to define the returned type of each input port of the associated custom node.</para>
    /// <para>Defining this method is <b>optional</b>, but recommended. If not overridden, input ports will return the <see cref="Godot.VisualShaderNode.PortType.Scalar"/> type.</para>
    /// </summary>
    public virtual VisualShaderNode.PortType _GetInputPortType(int port)
    {
        return default;
    }

    /// <summary>
    /// <para>Override this method to define the name of the associated custom node in the Visual Shader Editor's members dialog and graph.</para>
    /// <para>Defining this method is <b>optional</b>, but recommended. If not overridden, the node will be named as "Unnamed".</para>
    /// </summary>
    public virtual string _GetName()
    {
        return default;
    }

    /// <summary>
    /// <para>Override this method to define the number of output ports of the associated custom node.</para>
    /// <para>Defining this method is <b>required</b>. If not overridden, the node has no output ports.</para>
    /// </summary>
    public virtual int _GetOutputPortCount()
    {
        return default;
    }

    /// <summary>
    /// <para>Override this method to define the names of output ports of the associated custom node. The names are used both for the output slots in the editor and as identifiers in the shader code, and are passed in the <c>output_vars</c> array in <see cref="Godot.VisualShaderNodeCustom._GetCode(Godot.Collections.Array{string}, Godot.Collections.Array{string}, Shader.Mode, VisualShader.Type)"/>.</para>
    /// <para>Defining this method is <b>optional</b>, but recommended. If not overridden, output ports are named as <c>"out" + str(port)</c>.</para>
    /// </summary>
    public virtual string _GetOutputPortName(int port)
    {
        return default;
    }

    /// <summary>
    /// <para>Override this method to define the returned type of each output port of the associated custom node.</para>
    /// <para>Defining this method is <b>optional</b>, but recommended. If not overridden, output ports will return the <see cref="Godot.VisualShaderNode.PortType.Scalar"/> type.</para>
    /// </summary>
    public virtual VisualShaderNode.PortType _GetOutputPortType(int port)
    {
        return default;
    }

    /// <summary>
    /// <para>Override this method to define the number of the properties.</para>
    /// <para>Defining this method is <b>optional</b>.</para>
    /// </summary>
    public virtual int _GetPropertyCount()
    {
        return default;
    }

    /// <summary>
    /// <para>Override this method to define the default index of the property of the associated custom node.</para>
    /// <para>Defining this method is <b>optional</b>.</para>
    /// </summary>
    public virtual int _GetPropertyDefaultIndex(int index)
    {
        return default;
    }

    /// <summary>
    /// <para>Override this method to define the names of the property of the associated custom node.</para>
    /// <para>Defining this method is <b>optional</b>.</para>
    /// </summary>
    public virtual string _GetPropertyName(int index)
    {
        return default;
    }

    /// <summary>
    /// <para>Override this method to define the options inside the drop-down list property of the associated custom node.</para>
    /// <para>Defining this method is <b>optional</b>.</para>
    /// </summary>
    public virtual string[] _GetPropertyOptions(int index)
    {
        return default;
    }

    /// <summary>
    /// <para>Override this method to define the return icon of the associated custom node in the Visual Shader Editor's members dialog.</para>
    /// <para>Defining this method is <b>optional</b>. If not overridden, no return icon is shown.</para>
    /// </summary>
    public virtual VisualShaderNode.PortType _GetReturnIconType()
    {
        return default;
    }

    /// <summary>
    /// <para>Override this method to prevent the node to be visible in the member dialog for the certain <paramref name="mode"/> and/or <paramref name="type"/>.</para>
    /// <para>Defining this method is <b>optional</b>. If not overridden, it's <see langword="true"/>.</para>
    /// </summary>
    public virtual bool _IsAvailable(Shader.Mode mode, VisualShader.Type type)
    {
        return default;
    }

    /// <summary>
    /// <para>Override this method to enable the high-end mark in the Visual Shader Editor's members dialog. This should return <see langword="true"/> for nodes that only work when using the Forward+ and Mobile renderers.</para>
    /// <para>Defining this method is <b>optional</b>. If not overridden, it's <see langword="false"/>, which indicates this node works with all renderers (including Compatibility).</para>
    /// </summary>
    public virtual bool _IsHighend()
    {
        return default;
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName._SetInitialized, 2586408642ul);

    internal void _SetInitialized(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind0, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName._IsInitialized, 2240911060ul);

    internal bool _IsInitialized()
    {
        return NativeCalls.godot_icall_0_15(MethodBind1, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName._SetProperties, 83702148ul);

    internal void _SetProperties(string properties)
    {
        NativeCalls.godot_icall_1_57(MethodBind2, GodotObject.GetPtr(this), properties);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName._GetProperties, 201670096ul);

    internal string _GetProperties()
    {
        return NativeCalls.godot_icall_0_58(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOptionIndex, 923996154ul);

    /// <summary>
    /// <para>Returns the selected index of the drop-down list option within a graph. You may use this function to define the specific behavior in the <see cref="Godot.VisualShaderNodeCustom._GetCode(Godot.Collections.Array{string}, Godot.Collections.Array{string}, Shader.Mode, VisualShader.Type)"/> or <see cref="Godot.VisualShaderNodeCustom._GetGlobalCode(Shader.Mode)"/>.</para>
    /// </summary>
    public int GetOptionIndex(int option)
    {
        return NativeCalls.godot_icall_1_60(MethodBind4, GodotObject.GetPtr(this), option);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_category = "_GetCategory";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_code = "_GetCode";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_default_input_port = "_GetDefaultInputPort";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_description = "_GetDescription";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_func_code = "_GetFuncCode";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_global_code = "_GetGlobalCode";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_input_port_count = "_GetInputPortCount";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_input_port_default_value = "_GetInputPortDefaultValue";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_input_port_name = "_GetInputPortName";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_input_port_type = "_GetInputPortType";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_name = "_GetName";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_output_port_count = "_GetOutputPortCount";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_output_port_name = "_GetOutputPortName";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_output_port_type = "_GetOutputPortType";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_property_count = "_GetPropertyCount";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_property_default_index = "_GetPropertyDefaultIndex";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_property_name = "_GetPropertyName";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_property_options = "_GetPropertyOptions";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_return_icon_type = "_GetReturnIconType";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__is_available = "_IsAvailable";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__is_highend = "_IsHighend";

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
        if ((method == MethodProxyName__get_category || method == MethodName._GetCategory) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_category.NativeValue))
        {
            var callRet = _GetCategory();
            ret = VariantUtils.CreateFrom<string>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_code || method == MethodName._GetCode) && args.Count == 4 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_code.NativeValue))
        {
            var callRet = _GetCode(new Godot.Collections.Array<string>(VariantUtils.ConvertToArray(args[0])), new Godot.Collections.Array<string>(VariantUtils.ConvertToArray(args[1])), VariantUtils.ConvertTo<Shader.Mode>(args[2]), VariantUtils.ConvertTo<VisualShader.Type>(args[3]));
            ret = VariantUtils.CreateFrom<string>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_default_input_port || method == MethodName._GetDefaultInputPort) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_default_input_port.NativeValue))
        {
            var callRet = _GetDefaultInputPort(VariantUtils.ConvertTo<VisualShaderNode.PortType>(args[0]));
            ret = VariantUtils.CreateFrom<int>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_description || method == MethodName._GetDescription) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_description.NativeValue))
        {
            var callRet = _GetDescription();
            ret = VariantUtils.CreateFrom<string>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_func_code || method == MethodName._GetFuncCode) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_func_code.NativeValue))
        {
            var callRet = _GetFuncCode(VariantUtils.ConvertTo<Shader.Mode>(args[0]), VariantUtils.ConvertTo<VisualShader.Type>(args[1]));
            ret = VariantUtils.CreateFrom<string>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_global_code || method == MethodName._GetGlobalCode) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_global_code.NativeValue))
        {
            var callRet = _GetGlobalCode(VariantUtils.ConvertTo<Shader.Mode>(args[0]));
            ret = VariantUtils.CreateFrom<string>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_input_port_count || method == MethodName._GetInputPortCount) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_input_port_count.NativeValue))
        {
            var callRet = _GetInputPortCount();
            ret = VariantUtils.CreateFrom<int>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_input_port_default_value || method == MethodName._GetInputPortDefaultValue) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_input_port_default_value.NativeValue))
        {
            var callRet = _GetInputPortDefaultValue(VariantUtils.ConvertTo<int>(args[0]));
            ret = VariantUtils.CreateFrom<Variant>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_input_port_name || method == MethodName._GetInputPortName) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_input_port_name.NativeValue))
        {
            var callRet = _GetInputPortName(VariantUtils.ConvertTo<int>(args[0]));
            ret = VariantUtils.CreateFrom<string>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_input_port_type || method == MethodName._GetInputPortType) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_input_port_type.NativeValue))
        {
            var callRet = _GetInputPortType(VariantUtils.ConvertTo<int>(args[0]));
            ret = VariantUtils.CreateFrom<VisualShaderNode.PortType>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_name || method == MethodName._GetName) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_name.NativeValue))
        {
            var callRet = _GetName();
            ret = VariantUtils.CreateFrom<string>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_output_port_count || method == MethodName._GetOutputPortCount) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_output_port_count.NativeValue))
        {
            var callRet = _GetOutputPortCount();
            ret = VariantUtils.CreateFrom<int>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_output_port_name || method == MethodName._GetOutputPortName) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_output_port_name.NativeValue))
        {
            var callRet = _GetOutputPortName(VariantUtils.ConvertTo<int>(args[0]));
            ret = VariantUtils.CreateFrom<string>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_output_port_type || method == MethodName._GetOutputPortType) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_output_port_type.NativeValue))
        {
            var callRet = _GetOutputPortType(VariantUtils.ConvertTo<int>(args[0]));
            ret = VariantUtils.CreateFrom<VisualShaderNode.PortType>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_property_count || method == MethodName._GetPropertyCount) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_property_count.NativeValue))
        {
            var callRet = _GetPropertyCount();
            ret = VariantUtils.CreateFrom<int>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_property_default_index || method == MethodName._GetPropertyDefaultIndex) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_property_default_index.NativeValue))
        {
            var callRet = _GetPropertyDefaultIndex(VariantUtils.ConvertTo<int>(args[0]));
            ret = VariantUtils.CreateFrom<int>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_property_name || method == MethodName._GetPropertyName) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_property_name.NativeValue))
        {
            var callRet = _GetPropertyName(VariantUtils.ConvertTo<int>(args[0]));
            ret = VariantUtils.CreateFrom<string>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_property_options || method == MethodName._GetPropertyOptions) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_property_options.NativeValue))
        {
            var callRet = _GetPropertyOptions(VariantUtils.ConvertTo<int>(args[0]));
            ret = VariantUtils.CreateFrom<string[]>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_return_icon_type || method == MethodName._GetReturnIconType) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_return_icon_type.NativeValue))
        {
            var callRet = _GetReturnIconType();
            ret = VariantUtils.CreateFrom<VisualShaderNode.PortType>(callRet);
            return true;
        }
        if ((method == MethodProxyName__is_available || method == MethodName._IsAvailable) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__is_available.NativeValue))
        {
            var callRet = _IsAvailable(VariantUtils.ConvertTo<Shader.Mode>(args[0]), VariantUtils.ConvertTo<VisualShader.Type>(args[1]));
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__is_highend || method == MethodName._IsHighend) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__is_highend.NativeValue))
        {
            var callRet = _IsHighend();
            ret = VariantUtils.CreateFrom<bool>(callRet);
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
        if (method == MethodName._GetCategory)
        {
            if (HasGodotClassMethod(MethodProxyName__get_category.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetCode)
        {
            if (HasGodotClassMethod(MethodProxyName__get_code.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetDefaultInputPort)
        {
            if (HasGodotClassMethod(MethodProxyName__get_default_input_port.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetDescription)
        {
            if (HasGodotClassMethod(MethodProxyName__get_description.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetFuncCode)
        {
            if (HasGodotClassMethod(MethodProxyName__get_func_code.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetGlobalCode)
        {
            if (HasGodotClassMethod(MethodProxyName__get_global_code.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetInputPortCount)
        {
            if (HasGodotClassMethod(MethodProxyName__get_input_port_count.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetInputPortDefaultValue)
        {
            if (HasGodotClassMethod(MethodProxyName__get_input_port_default_value.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetInputPortName)
        {
            if (HasGodotClassMethod(MethodProxyName__get_input_port_name.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetInputPortType)
        {
            if (HasGodotClassMethod(MethodProxyName__get_input_port_type.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetName)
        {
            if (HasGodotClassMethod(MethodProxyName__get_name.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetOutputPortCount)
        {
            if (HasGodotClassMethod(MethodProxyName__get_output_port_count.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetOutputPortName)
        {
            if (HasGodotClassMethod(MethodProxyName__get_output_port_name.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetOutputPortType)
        {
            if (HasGodotClassMethod(MethodProxyName__get_output_port_type.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetPropertyCount)
        {
            if (HasGodotClassMethod(MethodProxyName__get_property_count.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetPropertyDefaultIndex)
        {
            if (HasGodotClassMethod(MethodProxyName__get_property_default_index.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetPropertyName)
        {
            if (HasGodotClassMethod(MethodProxyName__get_property_name.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetPropertyOptions)
        {
            if (HasGodotClassMethod(MethodProxyName__get_property_options.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetReturnIconType)
        {
            if (HasGodotClassMethod(MethodProxyName__get_return_icon_type.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._IsAvailable)
        {
            if (HasGodotClassMethod(MethodProxyName__is_available.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._IsHighend)
        {
            if (HasGodotClassMethod(MethodProxyName__is_highend.NativeValue.DangerousSelfRef))
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
    public new class PropertyName : VisualShaderNode.PropertyName
    {
        /// <summary>
        /// Cached name for the 'initialized' property.
        /// </summary>
        public static readonly StringName Initialized = "initialized";
        /// <summary>
        /// Cached name for the 'properties' property.
        /// </summary>
        public static readonly StringName Properties = "properties";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : VisualShaderNode.MethodName
    {
        /// <summary>
        /// Cached name for the '_get_category' method.
        /// </summary>
        public static readonly StringName _GetCategory = "_get_category";
        /// <summary>
        /// Cached name for the '_get_code' method.
        /// </summary>
        public static readonly StringName _GetCode = "_get_code";
        /// <summary>
        /// Cached name for the '_get_default_input_port' method.
        /// </summary>
        public static readonly StringName _GetDefaultInputPort = "_get_default_input_port";
        /// <summary>
        /// Cached name for the '_get_description' method.
        /// </summary>
        public static readonly StringName _GetDescription = "_get_description";
        /// <summary>
        /// Cached name for the '_get_func_code' method.
        /// </summary>
        public static readonly StringName _GetFuncCode = "_get_func_code";
        /// <summary>
        /// Cached name for the '_get_global_code' method.
        /// </summary>
        public static readonly StringName _GetGlobalCode = "_get_global_code";
        /// <summary>
        /// Cached name for the '_get_input_port_count' method.
        /// </summary>
        public static readonly StringName _GetInputPortCount = "_get_input_port_count";
        /// <summary>
        /// Cached name for the '_get_input_port_default_value' method.
        /// </summary>
        public static readonly StringName _GetInputPortDefaultValue = "_get_input_port_default_value";
        /// <summary>
        /// Cached name for the '_get_input_port_name' method.
        /// </summary>
        public static readonly StringName _GetInputPortName = "_get_input_port_name";
        /// <summary>
        /// Cached name for the '_get_input_port_type' method.
        /// </summary>
        public static readonly StringName _GetInputPortType = "_get_input_port_type";
        /// <summary>
        /// Cached name for the '_get_name' method.
        /// </summary>
        public static readonly StringName _GetName = "_get_name";
        /// <summary>
        /// Cached name for the '_get_output_port_count' method.
        /// </summary>
        public static readonly StringName _GetOutputPortCount = "_get_output_port_count";
        /// <summary>
        /// Cached name for the '_get_output_port_name' method.
        /// </summary>
        public static readonly StringName _GetOutputPortName = "_get_output_port_name";
        /// <summary>
        /// Cached name for the '_get_output_port_type' method.
        /// </summary>
        public static readonly StringName _GetOutputPortType = "_get_output_port_type";
        /// <summary>
        /// Cached name for the '_get_property_count' method.
        /// </summary>
        public static readonly StringName _GetPropertyCount = "_get_property_count";
        /// <summary>
        /// Cached name for the '_get_property_default_index' method.
        /// </summary>
        public static readonly StringName _GetPropertyDefaultIndex = "_get_property_default_index";
        /// <summary>
        /// Cached name for the '_get_property_name' method.
        /// </summary>
        public static readonly StringName _GetPropertyName = "_get_property_name";
        /// <summary>
        /// Cached name for the '_get_property_options' method.
        /// </summary>
        public static readonly StringName _GetPropertyOptions = "_get_property_options";
        /// <summary>
        /// Cached name for the '_get_return_icon_type' method.
        /// </summary>
        public static readonly StringName _GetReturnIconType = "_get_return_icon_type";
        /// <summary>
        /// Cached name for the '_is_available' method.
        /// </summary>
        public static readonly StringName _IsAvailable = "_is_available";
        /// <summary>
        /// Cached name for the '_is_highend' method.
        /// </summary>
        public static readonly StringName _IsHighend = "_is_highend";
        /// <summary>
        /// Cached name for the '_set_initialized' method.
        /// </summary>
        public static readonly StringName _SetInitialized = "_set_initialized";
        /// <summary>
        /// Cached name for the '_is_initialized' method.
        /// </summary>
        public static readonly StringName _IsInitialized = "_is_initialized";
        /// <summary>
        /// Cached name for the '_set_properties' method.
        /// </summary>
        public static readonly StringName _SetProperties = "_set_properties";
        /// <summary>
        /// Cached name for the '_get_properties' method.
        /// </summary>
        public static readonly StringName _GetProperties = "_get_properties";
        /// <summary>
        /// Cached name for the 'get_option_index' method.
        /// </summary>
        public static readonly StringName GetOptionIndex = "get_option_index";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : VisualShaderNode.SignalName
    {
    }
}
