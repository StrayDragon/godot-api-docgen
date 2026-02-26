namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Gives access to input variables (built-ins) available for the shader. See the shading reference for the list of available built-ins for each shader type (check <c>Tutorials</c> section for link).</para>
/// </summary>
public partial class VisualShaderNodeInput : VisualShaderNode
{
    /// <summary>
    /// <para>One of the several input constants in lower-case style like: "vertex" (<c>VERTEX</c>) or "point_size" (<c>POINT_SIZE</c>).</para>
    /// </summary>
    public string InputName
    {
        get
        {
            return GetInputName();
        }
        set
        {
            SetInputName(value);
        }
    }

    private static readonly System.Type CachedType = typeof(VisualShaderNodeInput);

    private static readonly StringName NativeName = "VisualShaderNodeInput";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public VisualShaderNodeInput() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal VisualShaderNodeInput(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal VisualShaderNodeInput(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetInputName, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetInputName(string name)
    {
        NativeCalls.godot_icall_1_57(MethodBind0, GodotObject.GetPtr(this), name);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetInputName, 201670096ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetInputName()
    {
        return NativeCalls.godot_icall_0_58(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetInputRealName, 201670096ul);

    /// <summary>
    /// <para>Returns a translated name of the current constant in the Godot Shader Language. E.g. <c>"ALBEDO"</c> if the <see cref="Godot.VisualShaderNodeInput.InputName"/> equal to <c>"albedo"</c>.</para>
    /// </summary>
    public string GetInputRealName()
    {
        return NativeCalls.godot_icall_0_58(MethodBind2, GodotObject.GetPtr(this));
    }

    /// <summary>
    /// <para>Emitted when input is changed via <see cref="Godot.VisualShaderNodeInput.InputName"/>.</para>
    /// </summary>
    public event Action InputTypeChanged
    {
        add => Connect(SignalName.InputTypeChanged, Callable.From(value));
        remove => Disconnect(SignalName.InputTypeChanged, Callable.From(value));
    }

    protected void EmitSignalInputTypeChanged()
    {
        EmitSignal(SignalName.InputTypeChanged);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_input_type_changed = "InputTypeChanged";

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
        if (signal == SignalName.InputTypeChanged)
        {
            if (HasGodotClassSignal(SignalProxyName_input_type_changed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        return base.HasGodotClassSignal(signal);
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : VisualShaderNode.PropertyName
    {
        /// <summary>
        /// Cached name for the 'input_name' property.
        /// </summary>
        public static readonly StringName InputName = "input_name";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : VisualShaderNode.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_input_name' method.
        /// </summary>
        public static readonly StringName SetInputName = "set_input_name";
        /// <summary>
        /// Cached name for the 'get_input_name' method.
        /// </summary>
        public static readonly StringName GetInputName = "get_input_name";
        /// <summary>
        /// Cached name for the 'get_input_real_name' method.
        /// </summary>
        public static readonly StringName GetInputRealName = "get_input_real_name";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : VisualShaderNode.SignalName
    {
        /// <summary>
        /// Cached name for the 'input_type_changed' signal.
        /// </summary>
        public static readonly StringName InputTypeChanged = "input_type_changed";
    }
}
