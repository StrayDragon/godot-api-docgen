namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Visual shader graphs consist of various nodes. Each node in the graph is a separate object and they are represented as a rectangular boxes with title and a set of properties. Each node also has connection ports that allow to connect it to another nodes and control the flow of the shader.</para>
/// </summary>
public partial class VisualShaderNode : Resource
{
    public enum PortType : long
    {
        /// <summary>
        /// <para>Floating-point scalar. Translated to <c>float</c> type in shader code.</para>
        /// </summary>
        Scalar = 0,
        /// <summary>
        /// <para>Integer scalar. Translated to <c>int</c> type in shader code.</para>
        /// </summary>
        ScalarInt = 1,
        /// <summary>
        /// <para>Unsigned integer scalar. Translated to <c>uint</c> type in shader code.</para>
        /// </summary>
        ScalarUint = 2,
        /// <summary>
        /// <para>2D vector of floating-point values. Translated to <c>vec2</c> type in shader code.</para>
        /// </summary>
        Vector2D = 3,
        /// <summary>
        /// <para>3D vector of floating-point values. Translated to <c>vec3</c> type in shader code.</para>
        /// </summary>
        Vector3D = 4,
        /// <summary>
        /// <para>4D vector of floating-point values. Translated to <c>vec4</c> type in shader code.</para>
        /// </summary>
        Vector4D = 5,
        /// <summary>
        /// <para>Boolean type. Translated to <c>bool</c> type in shader code.</para>
        /// </summary>
        Boolean = 6,
        /// <summary>
        /// <para>Transform type. Translated to <c>mat4</c> type in shader code.</para>
        /// </summary>
        Transform = 7,
        /// <summary>
        /// <para>Sampler type. Translated to reference of sampler uniform in shader code. Can only be used for input ports in non-uniform nodes.</para>
        /// </summary>
        Sampler = 8,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.VisualShaderNode.PortType"/> enum.</para>
        /// </summary>
        Max = 9
    }

    /// <summary>
    /// <para>Sets the output port index which will be showed for preview. If set to <c>-1</c> no port will be open for preview.</para>
    /// </summary>
    public int OutputPortForPreview
    {
        get
        {
            return GetOutputPortForPreview();
        }
        set
        {
            SetOutputPortForPreview(value);
        }
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public Godot.Collections.Array DefaultInputValues
    {
        get
        {
            return GetDefaultInputValues();
        }
        set
        {
            SetDefaultInputValues(value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public Godot.Collections.Array ExpandedOutputPorts
    {
        get
        {
            return _GetOutputPortsExpanded();
        }
        set
        {
            _SetOutputPortsExpanded(value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    /// <summary>
    /// <para>Represents the index of the frame this node is linked to. If set to <c>-1</c> the node is not linked to any frame.</para>
    /// </summary>
    public int LinkedParentGraphFrame
    {
        get
        {
            return GetFrame();
        }
        set
        {
            SetFrame(value);
        }
    }

    private static readonly System.Type CachedType = typeof(VisualShaderNode);

    private static readonly StringName NativeName = "VisualShaderNode";

    internal VisualShaderNode() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal VisualShaderNode(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal VisualShaderNode(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDefaultInputPort, 1894493699ul);

    /// <summary>
    /// <para>Returns the input port which should be connected by default when this node is created as a result of dragging a connection from an existing node to the empty space on the graph.</para>
    /// </summary>
    public int GetDefaultInputPort(VisualShaderNode.PortType type)
    {
        return NativeCalls.godot_icall_1_60(MethodBind0, GodotObject.GetPtr(this), (int)type);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetOutputPortForPreview, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetOutputPortForPreview(int port)
    {
        NativeCalls.godot_icall_1_38(MethodBind1, GodotObject.GetPtr(this), port);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOutputPortForPreview, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetOutputPortForPreview()
    {
        return NativeCalls.godot_icall_0_39(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName._SetOutputPortsExpanded, 381264803ul);

    internal void _SetOutputPortsExpanded(Godot.Collections.Array values)
    {
        NativeCalls.godot_icall_1_138(MethodBind3, GodotObject.GetPtr(this), (godot_array)(values ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName._GetOutputPortsExpanded, 3995934104ul);

    internal Godot.Collections.Array _GetOutputPortsExpanded()
    {
        return NativeCalls.godot_icall_0_120(MethodBind4, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetInputPortDefaultValue, 150923387ul);

    /// <summary>
    /// <para>Sets the default <paramref name="value"/> for the selected input <paramref name="port"/>.</para>
    /// </summary>
    public void SetInputPortDefaultValue(int port, Variant value, Variant prevValue = default)
    {
        NativeCalls.godot_icall_3_1494(MethodBind5, GodotObject.GetPtr(this), port, value, prevValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetInputPortDefaultValue, 4227898402ul);

    /// <summary>
    /// <para>Returns the default value of the input <paramref name="port"/>.</para>
    /// </summary>
    public Variant GetInputPortDefaultValue(int port)
    {
        return NativeCalls.godot_icall_1_702(MethodBind6, GodotObject.GetPtr(this), port);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveInputPortDefaultValue, 1286410249ul);

    /// <summary>
    /// <para>Removes the default value of the input <paramref name="port"/>.</para>
    /// </summary>
    public void RemoveInputPortDefaultValue(int port)
    {
        NativeCalls.godot_icall_1_38(MethodBind7, GodotObject.GetPtr(this), port);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ClearDefaultInputValues, 3218959716ul);

    /// <summary>
    /// <para>Clears the default input ports value.</para>
    /// </summary>
    public void ClearDefaultInputValues()
    {
        NativeCalls.godot_icall_0_3(MethodBind8, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDefaultInputValues, 381264803ul);

    /// <summary>
    /// <para>Sets the default input ports values using an <see cref="Godot.Collections.Array"/> of the form <c>[index0, value0, index1, value1, ...]</c>. For example: <c>[0, Vector3(0, 0, 0), 1, Vector3(0, 0, 0)]</c>.</para>
    /// </summary>
    public void SetDefaultInputValues(Godot.Collections.Array values)
    {
        NativeCalls.godot_icall_1_138(MethodBind9, GodotObject.GetPtr(this), (godot_array)(values ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDefaultInputValues, 3995934104ul);

    /// <summary>
    /// <para>Returns an <see cref="Godot.Collections.Array"/> containing default values for all of the input ports of the node in the form <c>[index0, value0, index1, value1, ...]</c>.</para>
    /// </summary>
    public Godot.Collections.Array GetDefaultInputValues()
    {
        return NativeCalls.godot_icall_0_120(MethodBind10, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFrame, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFrame(int frame)
    {
        NativeCalls.godot_icall_1_38(MethodBind11, GodotObject.GetPtr(this), frame);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFrame, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetFrame()
    {
        return NativeCalls.godot_icall_0_39(MethodBind12, GodotObject.GetPtr(this));
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
        /// Cached name for the 'output_port_for_preview' property.
        /// </summary>
        public static readonly StringName OutputPortForPreview = "output_port_for_preview";
        /// <summary>
        /// Cached name for the 'default_input_values' property.
        /// </summary>
        public static readonly StringName DefaultInputValues = "default_input_values";
        /// <summary>
        /// Cached name for the 'expanded_output_ports' property.
        /// </summary>
        public static readonly StringName ExpandedOutputPorts = "expanded_output_ports";
        /// <summary>
        /// Cached name for the 'linked_parent_graph_frame' property.
        /// </summary>
        public static readonly StringName LinkedParentGraphFrame = "linked_parent_graph_frame";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Resource.MethodName
    {
        /// <summary>
        /// Cached name for the 'get_default_input_port' method.
        /// </summary>
        public static readonly StringName GetDefaultInputPort = "get_default_input_port";
        /// <summary>
        /// Cached name for the 'set_output_port_for_preview' method.
        /// </summary>
        public static readonly StringName SetOutputPortForPreview = "set_output_port_for_preview";
        /// <summary>
        /// Cached name for the 'get_output_port_for_preview' method.
        /// </summary>
        public static readonly StringName GetOutputPortForPreview = "get_output_port_for_preview";
        /// <summary>
        /// Cached name for the '_set_output_ports_expanded' method.
        /// </summary>
        public static readonly StringName _SetOutputPortsExpanded = "_set_output_ports_expanded";
        /// <summary>
        /// Cached name for the '_get_output_ports_expanded' method.
        /// </summary>
        public static readonly StringName _GetOutputPortsExpanded = "_get_output_ports_expanded";
        /// <summary>
        /// Cached name for the 'set_input_port_default_value' method.
        /// </summary>
        public static readonly StringName SetInputPortDefaultValue = "set_input_port_default_value";
        /// <summary>
        /// Cached name for the 'get_input_port_default_value' method.
        /// </summary>
        public static readonly StringName GetInputPortDefaultValue = "get_input_port_default_value";
        /// <summary>
        /// Cached name for the 'remove_input_port_default_value' method.
        /// </summary>
        public static readonly StringName RemoveInputPortDefaultValue = "remove_input_port_default_value";
        /// <summary>
        /// Cached name for the 'clear_default_input_values' method.
        /// </summary>
        public static readonly StringName ClearDefaultInputValues = "clear_default_input_values";
        /// <summary>
        /// Cached name for the 'set_default_input_values' method.
        /// </summary>
        public static readonly StringName SetDefaultInputValues = "set_default_input_values";
        /// <summary>
        /// Cached name for the 'get_default_input_values' method.
        /// </summary>
        public static readonly StringName GetDefaultInputValues = "get_default_input_values";
        /// <summary>
        /// Cached name for the 'set_frame' method.
        /// </summary>
        public static readonly StringName SetFrame = "set_frame";
        /// <summary>
        /// Cached name for the 'get_frame' method.
        /// </summary>
        public static readonly StringName GetFrame = "get_frame";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Resource.SignalName
    {
    }
}
