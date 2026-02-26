namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Has only one output port and no inputs.</para>
/// <para>Translated to <c>bool</c> in the shader language.</para>
/// </summary>
public partial class VisualShaderNodeBooleanConstant : VisualShaderNodeConstant
{
    /// <summary>
    /// <para>A boolean constant which represents a state of this node.</para>
    /// </summary>
    public bool Constant
    {
        get
        {
            return GetConstant();
        }
        set
        {
            SetConstant(value);
        }
    }

    private static readonly System.Type CachedType = typeof(VisualShaderNodeBooleanConstant);

    private static readonly StringName NativeName = "VisualShaderNodeBooleanConstant";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public VisualShaderNodeBooleanConstant() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal VisualShaderNodeBooleanConstant(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal VisualShaderNodeBooleanConstant(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetConstant, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetConstant(bool constant)
    {
        NativeCalls.godot_icall_1_14(MethodBind0, GodotObject.GetPtr(this), constant.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetConstant, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetConstant()
    {
        return NativeCalls.godot_icall_0_15(MethodBind1, GodotObject.GetPtr(this)).ToBool();
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
    public new class PropertyName : VisualShaderNodeConstant.PropertyName
    {
        /// <summary>
        /// Cached name for the 'constant' property.
        /// </summary>
        public static readonly StringName Constant = "constant";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : VisualShaderNodeConstant.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_constant' method.
        /// </summary>
        public static readonly StringName SetConstant = "set_constant";
        /// <summary>
        /// Cached name for the 'get_constant' method.
        /// </summary>
        public static readonly StringName GetConstant = "get_constant";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : VisualShaderNodeConstant.SignalName
    {
    }
}
