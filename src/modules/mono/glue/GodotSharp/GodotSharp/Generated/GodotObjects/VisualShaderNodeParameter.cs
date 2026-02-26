namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A parameter represents a variable in the shader which is set externally, i.e. from the <see cref="Godot.ShaderMaterial"/>. Parameters are exposed as properties in the <see cref="Godot.ShaderMaterial"/> and can be assigned from the Inspector or from a script.</para>
/// </summary>
public partial class VisualShaderNodeParameter : VisualShaderNode
{
    public enum QualifierEnum : long
    {
        /// <summary>
        /// <para>The parameter will be tied to the <see cref="Godot.ShaderMaterial"/> using this shader.</para>
        /// </summary>
        None = 0,
        /// <summary>
        /// <para>The parameter will use a global value, defined in Project Settings.</para>
        /// </summary>
        Global = 1,
        /// <summary>
        /// <para>The parameter will be tied to the node with attached <see cref="Godot.ShaderMaterial"/> using this shader.</para>
        /// </summary>
        Instance = 2,
        /// <summary>
        /// <para>The parameter will be tied to the node with attached <see cref="Godot.ShaderMaterial"/> using this shader. Enables setting a <see cref="Godot.VisualShaderNodeParameter.InstanceIndex"/> property.</para>
        /// </summary>
        InstanceIndex = 3,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.VisualShaderNodeParameter.QualifierEnum"/> enum.</para>
        /// </summary>
        Max = 4
    }

    /// <summary>
    /// <para>Name of the parameter, by which it can be accessed through the <see cref="Godot.ShaderMaterial"/> properties.</para>
    /// </summary>
    public string ParameterName
    {
        get
        {
            return GetParameterName();
        }
        set
        {
            SetParameterName(value);
        }
    }

    /// <summary>
    /// <para>Defines the scope of the parameter.</para>
    /// </summary>
    public VisualShaderNodeParameter.QualifierEnum Qualifier
    {
        get
        {
            return GetQualifier();
        }
        set
        {
            SetQualifier(value);
        }
    }

    /// <summary>
    /// <para>The index within 0-15 range, which is used to avoid clashes when shader used on multiple materials.</para>
    /// </summary>
    public int InstanceIndex
    {
        get
        {
            return GetInstanceIndex();
        }
        set
        {
            SetInstanceIndex(value);
        }
    }

    private static readonly System.Type CachedType = typeof(VisualShaderNodeParameter);

    private static readonly StringName NativeName = "VisualShaderNodeParameter";

    internal VisualShaderNodeParameter() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal VisualShaderNodeParameter(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal VisualShaderNodeParameter(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetParameterName, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetParameterName(string name)
    {
        NativeCalls.godot_icall_1_57(MethodBind0, GodotObject.GetPtr(this), name);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetParameterName, 201670096ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetParameterName()
    {
        return NativeCalls.godot_icall_0_58(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetQualifier, 1276489447ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetQualifier(VisualShaderNodeParameter.QualifierEnum qualifier)
    {
        NativeCalls.godot_icall_1_38(MethodBind2, GodotObject.GetPtr(this), (int)qualifier);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetQualifier, 3558406205ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public VisualShaderNodeParameter.QualifierEnum GetQualifier()
    {
        return (VisualShaderNodeParameter.QualifierEnum)NativeCalls.godot_icall_0_39(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetInstanceIndex, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetInstanceIndex(int instanceIndex)
    {
        NativeCalls.godot_icall_1_38(MethodBind4, GodotObject.GetPtr(this), instanceIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetInstanceIndex, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetInstanceIndex()
    {
        return NativeCalls.godot_icall_0_39(MethodBind5, GodotObject.GetPtr(this));
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
    public new class PropertyName : VisualShaderNode.PropertyName
    {
        /// <summary>
        /// Cached name for the 'parameter_name' property.
        /// </summary>
        public static readonly StringName ParameterName = "parameter_name";
        /// <summary>
        /// Cached name for the 'qualifier' property.
        /// </summary>
        public static readonly StringName Qualifier = "qualifier";
        /// <summary>
        /// Cached name for the 'instance_index' property.
        /// </summary>
        public static readonly StringName InstanceIndex = "instance_index";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : VisualShaderNode.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_parameter_name' method.
        /// </summary>
        public static readonly StringName SetParameterName = "set_parameter_name";
        /// <summary>
        /// Cached name for the 'get_parameter_name' method.
        /// </summary>
        public static readonly StringName GetParameterName = "get_parameter_name";
        /// <summary>
        /// Cached name for the 'set_qualifier' method.
        /// </summary>
        public static readonly StringName SetQualifier = "set_qualifier";
        /// <summary>
        /// Cached name for the 'get_qualifier' method.
        /// </summary>
        public static readonly StringName GetQualifier = "get_qualifier";
        /// <summary>
        /// Cached name for the 'set_instance_index' method.
        /// </summary>
        public static readonly StringName SetInstanceIndex = "set_instance_index";
        /// <summary>
        /// Cached name for the 'get_instance_index' method.
        /// </summary>
        public static readonly StringName GetInstanceIndex = "get_instance_index";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : VisualShaderNode.SignalName
    {
    }
}
