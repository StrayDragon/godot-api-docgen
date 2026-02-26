namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Creating a reference to a <see cref="Godot.VisualShaderNodeParameter"/> allows you to reuse this parameter in different shaders or shader stages easily.</para>
/// </summary>
public partial class VisualShaderNodeParameterRef : VisualShaderNode
{
    /// <summary>
    /// <para>The name of the parameter which this reference points to.</para>
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

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public int ParamType
    {
        get
        {
            return _GetParameterType();
        }
        set
        {
            _SetParameterType(value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    private static readonly System.Type CachedType = typeof(VisualShaderNodeParameterRef);

    private static readonly StringName NativeName = "VisualShaderNodeParameterRef";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public VisualShaderNodeParameterRef() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal VisualShaderNodeParameterRef(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal VisualShaderNodeParameterRef(bool memoryOwn) : base(memoryOwn) { }

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
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName._SetParameterType, 1286410249ul);

    internal void _SetParameterType(int type)
    {
        NativeCalls.godot_icall_1_38(MethodBind2, GodotObject.GetPtr(this), type);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName._GetParameterType, 3905245786ul);

    internal int _GetParameterType()
    {
        return NativeCalls.godot_icall_0_39(MethodBind3, GodotObject.GetPtr(this));
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
        /// Cached name for the 'param_type' property.
        /// </summary>
        public static readonly StringName ParamType = "param_type";
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
        /// Cached name for the '_set_parameter_type' method.
        /// </summary>
        public static readonly StringName _SetParameterType = "_set_parameter_type";
        /// <summary>
        /// Cached name for the '_get_parameter_type' method.
        /// </summary>
        public static readonly StringName _GetParameterType = "_get_parameter_type";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : VisualShaderNode.SignalName
    {
    }
}
