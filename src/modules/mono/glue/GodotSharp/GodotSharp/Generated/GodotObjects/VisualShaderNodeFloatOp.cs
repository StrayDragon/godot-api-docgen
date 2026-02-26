namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Applies <see cref="Godot.VisualShaderNodeFloatOp.Operator"/> to two floating-point inputs: <c>a</c> and <c>b</c>.</para>
/// </summary>
public partial class VisualShaderNodeFloatOp : VisualShaderNode
{
    public enum OperatorEnum : long
    {
        /// <summary>
        /// <para>Sums two numbers using <c>a + b</c>.</para>
        /// </summary>
        Add = 0,
        /// <summary>
        /// <para>Subtracts two numbers using <c>a - b</c>.</para>
        /// </summary>
        Sub = 1,
        /// <summary>
        /// <para>Multiplies two numbers using <c>a * b</c>.</para>
        /// </summary>
        Mul = 2,
        /// <summary>
        /// <para>Divides two numbers using <c>a / b</c>.</para>
        /// </summary>
        Div = 3,
        /// <summary>
        /// <para>Calculates the remainder of two numbers. Translates to <c>mod(a, b)</c> in the Godot Shader Language.</para>
        /// </summary>
        Mod = 4,
        /// <summary>
        /// <para>Raises the <c>a</c> to the power of <c>b</c>. Translates to <c>pow(a, b)</c> in the Godot Shader Language.</para>
        /// </summary>
        Pow = 5,
        /// <summary>
        /// <para>Returns the greater of two numbers. Translates to <c>max(a, b)</c> in the Godot Shader Language.</para>
        /// </summary>
        Max = 6,
        /// <summary>
        /// <para>Returns the lesser of two numbers. Translates to <c>min(a, b)</c> in the Godot Shader Language.</para>
        /// </summary>
        Min = 7,
        /// <summary>
        /// <para>Returns the arc-tangent of the parameters. Translates to <c>atan(a, b)</c> in the Godot Shader Language.</para>
        /// </summary>
        Atan2 = 8,
        /// <summary>
        /// <para>Generates a step function by comparing <c>b</c>(x) to <c>a</c>(edge). Returns 0.0 if <c>x</c> is smaller than <c>edge</c> and otherwise 1.0. Translates to <c>step(a, b)</c> in the Godot Shader Language.</para>
        /// </summary>
        Step = 9,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.VisualShaderNodeFloatOp.OperatorEnum"/> enum.</para>
        /// </summary>
        EnumSize = 10
    }

    /// <summary>
    /// <para>An operator to be applied to the inputs.</para>
    /// </summary>
    public VisualShaderNodeFloatOp.OperatorEnum Operator
    {
        get
        {
            return GetOperator();
        }
        set
        {
            SetOperator(value);
        }
    }

    private static readonly System.Type CachedType = typeof(VisualShaderNodeFloatOp);

    private static readonly StringName NativeName = "VisualShaderNodeFloatOp";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public VisualShaderNodeFloatOp() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal VisualShaderNodeFloatOp(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal VisualShaderNodeFloatOp(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetOperator, 2488468047ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetOperator(VisualShaderNodeFloatOp.OperatorEnum op)
    {
        NativeCalls.godot_icall_1_38(MethodBind0, GodotObject.GetPtr(this), (int)op);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOperator, 1867979390ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public VisualShaderNodeFloatOp.OperatorEnum GetOperator()
    {
        return (VisualShaderNodeFloatOp.OperatorEnum)NativeCalls.godot_icall_0_39(MethodBind1, GodotObject.GetPtr(this));
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
        /// Cached name for the 'operator' property.
        /// </summary>
        public static readonly StringName Operator = "operator";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : VisualShaderNode.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_operator' method.
        /// </summary>
        public static readonly StringName SetOperator = "set_operator";
        /// <summary>
        /// Cached name for the 'get_operator' method.
        /// </summary>
        public static readonly StringName GetOperator = "get_operator";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : VisualShaderNode.SignalName
    {
    }
}
