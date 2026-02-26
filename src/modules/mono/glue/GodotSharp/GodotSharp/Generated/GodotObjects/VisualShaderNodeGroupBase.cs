namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Currently, has no direct usage, use the derived classes instead.</para>
/// </summary>
public partial class VisualShaderNodeGroupBase : VisualShaderNodeResizableBase
{
    private static readonly System.Type CachedType = typeof(VisualShaderNodeGroupBase);

    private static readonly StringName NativeName = "VisualShaderNodeGroupBase";

    internal VisualShaderNodeGroupBase() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal VisualShaderNodeGroupBase(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal VisualShaderNodeGroupBase(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetInputs, 83702148ul);

    /// <summary>
    /// <para>Defines all input ports using a <see cref="string"/> formatted as a colon-separated list: <c>id,type,name;</c> (see <see cref="Godot.VisualShaderNodeGroupBase.AddInputPort(int, int, string)"/>).</para>
    /// </summary>
    public void SetInputs(string inputs)
    {
        NativeCalls.godot_icall_1_57(MethodBind0, GodotObject.GetPtr(this), inputs);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetInputs, 201670096ul);

    /// <summary>
    /// <para>Returns a <see cref="string"/> description of the input ports as a colon-separated list using the format <c>id,type,name;</c> (see <see cref="Godot.VisualShaderNodeGroupBase.AddInputPort(int, int, string)"/>).</para>
    /// </summary>
    public string GetInputs()
    {
        return NativeCalls.godot_icall_0_58(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetOutputs, 83702148ul);

    /// <summary>
    /// <para>Defines all output ports using a <see cref="string"/> formatted as a colon-separated list: <c>id,type,name;</c> (see <see cref="Godot.VisualShaderNodeGroupBase.AddOutputPort(int, int, string)"/>).</para>
    /// </summary>
    public void SetOutputs(string outputs)
    {
        NativeCalls.godot_icall_1_57(MethodBind2, GodotObject.GetPtr(this), outputs);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOutputs, 201670096ul);

    /// <summary>
    /// <para>Returns a <see cref="string"/> description of the output ports as a colon-separated list using the format <c>id,type,name;</c> (see <see cref="Godot.VisualShaderNodeGroupBase.AddOutputPort(int, int, string)"/>).</para>
    /// </summary>
    public string GetOutputs()
    {
        return NativeCalls.godot_icall_0_58(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsValidPortName, 3927539163ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the specified port name does not override an existed port name and is valid within the shader.</para>
    /// </summary>
    public bool IsValidPortName(string name)
    {
        return NativeCalls.godot_icall_1_131(MethodBind4, GodotObject.GetPtr(this), name).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddInputPort, 2285447957ul);

    /// <summary>
    /// <para>Adds an input port with the specified <paramref name="type"/> (see <see cref="Godot.VisualShaderNode.PortType"/>) and <paramref name="name"/>.</para>
    /// </summary>
    public void AddInputPort(int id, int type, string name)
    {
        NativeCalls.godot_icall_3_1313(MethodBind5, GodotObject.GetPtr(this), id, type, name);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveInputPort, 1286410249ul);

    /// <summary>
    /// <para>Removes the specified input port.</para>
    /// </summary>
    public void RemoveInputPort(int id)
    {
        NativeCalls.godot_icall_1_38(MethodBind6, GodotObject.GetPtr(this), id);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetInputPortCount, 3905245786ul);

    /// <summary>
    /// <para>Returns the number of input ports in use. Alternative for <see cref="Godot.VisualShaderNodeGroupBase.GetFreeInputPortId()"/>.</para>
    /// </summary>
    public int GetInputPortCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasInputPort, 1116898809ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the specified input port exists.</para>
    /// </summary>
    public bool HasInputPort(int id)
    {
        return NativeCalls.godot_icall_1_62(MethodBind8, GodotObject.GetPtr(this), id).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ClearInputPorts, 3218959716ul);

    /// <summary>
    /// <para>Removes all previously specified input ports.</para>
    /// </summary>
    public void ClearInputPorts()
    {
        NativeCalls.godot_icall_0_3(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddOutputPort, 2285447957ul);

    /// <summary>
    /// <para>Adds an output port with the specified <paramref name="type"/> (see <see cref="Godot.VisualShaderNode.PortType"/>) and <paramref name="name"/>.</para>
    /// </summary>
    public void AddOutputPort(int id, int type, string name)
    {
        NativeCalls.godot_icall_3_1313(MethodBind10, GodotObject.GetPtr(this), id, type, name);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveOutputPort, 1286410249ul);

    /// <summary>
    /// <para>Removes the specified output port.</para>
    /// </summary>
    public void RemoveOutputPort(int id)
    {
        NativeCalls.godot_icall_1_38(MethodBind11, GodotObject.GetPtr(this), id);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOutputPortCount, 3905245786ul);

    /// <summary>
    /// <para>Returns the number of output ports in use. Alternative for <see cref="Godot.VisualShaderNodeGroupBase.GetFreeOutputPortId()"/>.</para>
    /// </summary>
    public int GetOutputPortCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind12, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasOutputPort, 1116898809ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the specified output port exists.</para>
    /// </summary>
    public bool HasOutputPort(int id)
    {
        return NativeCalls.godot_icall_1_62(MethodBind13, GodotObject.GetPtr(this), id).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ClearOutputPorts, 3218959716ul);

    /// <summary>
    /// <para>Removes all previously specified output ports.</para>
    /// </summary>
    public void ClearOutputPorts()
    {
        NativeCalls.godot_icall_0_3(MethodBind14, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetInputPortName, 501894301ul);

    /// <summary>
    /// <para>Renames the specified input port.</para>
    /// </summary>
    public void SetInputPortName(int id, string name)
    {
        NativeCalls.godot_icall_2_181(MethodBind15, GodotObject.GetPtr(this), id, name);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetInputPortType, 3937882851ul);

    /// <summary>
    /// <para>Sets the specified input port's type (see <see cref="Godot.VisualShaderNode.PortType"/>).</para>
    /// </summary>
    public void SetInputPortType(int id, int type)
    {
        NativeCalls.godot_icall_2_59(MethodBind16, GodotObject.GetPtr(this), id, type);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetOutputPortName, 501894301ul);

    /// <summary>
    /// <para>Renames the specified output port.</para>
    /// </summary>
    public void SetOutputPortName(int id, string name)
    {
        NativeCalls.godot_icall_2_181(MethodBind17, GodotObject.GetPtr(this), id, name);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetOutputPortType, 3937882851ul);

    /// <summary>
    /// <para>Sets the specified output port's type (see <see cref="Godot.VisualShaderNode.PortType"/>).</para>
    /// </summary>
    public void SetOutputPortType(int id, int type)
    {
        NativeCalls.godot_icall_2_59(MethodBind18, GodotObject.GetPtr(this), id, type);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFreeInputPortId, 3905245786ul);

    /// <summary>
    /// <para>Returns a free input port ID which can be used in <see cref="Godot.VisualShaderNodeGroupBase.AddInputPort(int, int, string)"/>.</para>
    /// </summary>
    public int GetFreeInputPortId()
    {
        return NativeCalls.godot_icall_0_39(MethodBind19, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFreeOutputPortId, 3905245786ul);

    /// <summary>
    /// <para>Returns a free output port ID which can be used in <see cref="Godot.VisualShaderNodeGroupBase.AddOutputPort(int, int, string)"/>.</para>
    /// </summary>
    public int GetFreeOutputPortId()
    {
        return NativeCalls.godot_icall_0_39(MethodBind20, GodotObject.GetPtr(this));
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
    public new class PropertyName : VisualShaderNodeResizableBase.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : VisualShaderNodeResizableBase.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_inputs' method.
        /// </summary>
        public static readonly StringName SetInputs = "set_inputs";
        /// <summary>
        /// Cached name for the 'get_inputs' method.
        /// </summary>
        public static readonly StringName GetInputs = "get_inputs";
        /// <summary>
        /// Cached name for the 'set_outputs' method.
        /// </summary>
        public static readonly StringName SetOutputs = "set_outputs";
        /// <summary>
        /// Cached name for the 'get_outputs' method.
        /// </summary>
        public static readonly StringName GetOutputs = "get_outputs";
        /// <summary>
        /// Cached name for the 'is_valid_port_name' method.
        /// </summary>
        public static readonly StringName IsValidPortName = "is_valid_port_name";
        /// <summary>
        /// Cached name for the 'add_input_port' method.
        /// </summary>
        public static readonly StringName AddInputPort = "add_input_port";
        /// <summary>
        /// Cached name for the 'remove_input_port' method.
        /// </summary>
        public static readonly StringName RemoveInputPort = "remove_input_port";
        /// <summary>
        /// Cached name for the 'get_input_port_count' method.
        /// </summary>
        public static readonly StringName GetInputPortCount = "get_input_port_count";
        /// <summary>
        /// Cached name for the 'has_input_port' method.
        /// </summary>
        public static readonly StringName HasInputPort = "has_input_port";
        /// <summary>
        /// Cached name for the 'clear_input_ports' method.
        /// </summary>
        public static readonly StringName ClearInputPorts = "clear_input_ports";
        /// <summary>
        /// Cached name for the 'add_output_port' method.
        /// </summary>
        public static readonly StringName AddOutputPort = "add_output_port";
        /// <summary>
        /// Cached name for the 'remove_output_port' method.
        /// </summary>
        public static readonly StringName RemoveOutputPort = "remove_output_port";
        /// <summary>
        /// Cached name for the 'get_output_port_count' method.
        /// </summary>
        public static readonly StringName GetOutputPortCount = "get_output_port_count";
        /// <summary>
        /// Cached name for the 'has_output_port' method.
        /// </summary>
        public static readonly StringName HasOutputPort = "has_output_port";
        /// <summary>
        /// Cached name for the 'clear_output_ports' method.
        /// </summary>
        public static readonly StringName ClearOutputPorts = "clear_output_ports";
        /// <summary>
        /// Cached name for the 'set_input_port_name' method.
        /// </summary>
        public static readonly StringName SetInputPortName = "set_input_port_name";
        /// <summary>
        /// Cached name for the 'set_input_port_type' method.
        /// </summary>
        public static readonly StringName SetInputPortType = "set_input_port_type";
        /// <summary>
        /// Cached name for the 'set_output_port_name' method.
        /// </summary>
        public static readonly StringName SetOutputPortName = "set_output_port_name";
        /// <summary>
        /// Cached name for the 'set_output_port_type' method.
        /// </summary>
        public static readonly StringName SetOutputPortType = "set_output_port_type";
        /// <summary>
        /// Cached name for the 'get_free_input_port_id' method.
        /// </summary>
        public static readonly StringName GetFreeInputPortId = "get_free_input_port_id";
        /// <summary>
        /// Cached name for the 'get_free_output_port_id' method.
        /// </summary>
        public static readonly StringName GetFreeOutputPortId = "get_free_output_port_id";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : VisualShaderNodeResizableBase.SignalName
    {
    }
}
