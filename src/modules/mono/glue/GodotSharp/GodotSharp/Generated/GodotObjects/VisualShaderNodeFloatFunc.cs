namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Accept a floating-point scalar (<c>x</c>) to the input port and transform it according to <see cref="Godot.VisualShaderNodeFloatFunc.Function"/>.</para>
/// </summary>
public partial class VisualShaderNodeFloatFunc : VisualShaderNode
{
    public enum FunctionEnum : long
    {
        /// <summary>
        /// <para>Returns the sine of the parameter. Translates to <c>sin(x)</c> in the Godot Shader Language.</para>
        /// </summary>
        Sin = 0,
        /// <summary>
        /// <para>Returns the cosine of the parameter. Translates to <c>cos(x)</c> in the Godot Shader Language.</para>
        /// </summary>
        Cos = 1,
        /// <summary>
        /// <para>Returns the tangent of the parameter. Translates to <c>tan(x)</c> in the Godot Shader Language.</para>
        /// </summary>
        Tan = 2,
        /// <summary>
        /// <para>Returns the arc-sine of the parameter. Translates to <c>asin(x)</c> in the Godot Shader Language.</para>
        /// </summary>
        Asin = 3,
        /// <summary>
        /// <para>Returns the arc-cosine of the parameter. Translates to <c>acos(x)</c> in the Godot Shader Language.</para>
        /// </summary>
        Acos = 4,
        /// <summary>
        /// <para>Returns the arc-tangent of the parameter. Translates to <c>atan(x)</c> in the Godot Shader Language.</para>
        /// </summary>
        Atan = 5,
        /// <summary>
        /// <para>Returns the hyperbolic sine of the parameter. Translates to <c>sinh(x)</c> in the Godot Shader Language.</para>
        /// </summary>
        Sinh = 6,
        /// <summary>
        /// <para>Returns the hyperbolic cosine of the parameter. Translates to <c>cosh(x)</c> in the Godot Shader Language.</para>
        /// </summary>
        Cosh = 7,
        /// <summary>
        /// <para>Returns the hyperbolic tangent of the parameter. Translates to <c>tanh(x)</c> in the Godot Shader Language.</para>
        /// </summary>
        Tanh = 8,
        /// <summary>
        /// <para>Returns the natural logarithm of the parameter. Translates to <c>log(x)</c> in the Godot Shader Language.</para>
        /// </summary>
        Log = 9,
        /// <summary>
        /// <para>Returns the natural exponentiation of the parameter. Translates to <c>exp(x)</c> in the Godot Shader Language.</para>
        /// </summary>
        Exp = 10,
        /// <summary>
        /// <para>Returns the square root of the parameter. Translates to <c>sqrt(x)</c> in the Godot Shader Language.</para>
        /// </summary>
        Sqrt = 11,
        /// <summary>
        /// <para>Returns the absolute value of the parameter. Translates to <c>abs(x)</c> in the Godot Shader Language.</para>
        /// </summary>
        Abs = 12,
        /// <summary>
        /// <para>Extracts the sign of the parameter. Translates to <c>sign(x)</c> in the Godot Shader Language.</para>
        /// </summary>
        Sign = 13,
        /// <summary>
        /// <para>Finds the nearest integer less than or equal to the parameter. Translates to <c>floor(x)</c> in the Godot Shader Language.</para>
        /// </summary>
        Floor = 14,
        /// <summary>
        /// <para>Finds the nearest integer to the parameter. Translates to <c>round(x)</c> in the Godot Shader Language.</para>
        /// </summary>
        Round = 15,
        /// <summary>
        /// <para>Finds the nearest integer that is greater than or equal to the parameter. Translates to <c>ceil(x)</c> in the Godot Shader Language.</para>
        /// </summary>
        Ceil = 16,
        /// <summary>
        /// <para>Computes the fractional part of the argument. Translates to <c>fract(x)</c> in the Godot Shader Language.</para>
        /// </summary>
        Fract = 17,
        /// <summary>
        /// <para>Clamps the value between <c>0.0</c> and <c>1.0</c> using <c>min(max(x, 0.0), 1.0)</c>.</para>
        /// </summary>
        Saturate = 18,
        /// <summary>
        /// <para>Negates the <c>x</c> using <c>-(x)</c>.</para>
        /// </summary>
        Negate = 19,
        /// <summary>
        /// <para>Returns the arc-hyperbolic-cosine of the parameter. Translates to <c>acosh(x)</c> in the Godot Shader Language.</para>
        /// </summary>
        Acosh = 20,
        /// <summary>
        /// <para>Returns the arc-hyperbolic-sine of the parameter. Translates to <c>asinh(x)</c> in the Godot Shader Language.</para>
        /// </summary>
        Asinh = 21,
        /// <summary>
        /// <para>Returns the arc-hyperbolic-tangent of the parameter. Translates to <c>atanh(x)</c> in the Godot Shader Language.</para>
        /// </summary>
        Atanh = 22,
        /// <summary>
        /// <para>Convert a quantity in radians to degrees. Translates to <c>degrees(x)</c> in the Godot Shader Language.</para>
        /// </summary>
        Degrees = 23,
        /// <summary>
        /// <para>Returns 2 raised by the power of the parameter. Translates to <c>exp2(x)</c> in the Godot Shader Language.</para>
        /// </summary>
        Exp2 = 24,
        /// <summary>
        /// <para>Returns the inverse of the square root of the parameter. Translates to <c>inversesqrt(x)</c> in the Godot Shader Language.</para>
        /// </summary>
        InverseSqrt = 25,
        /// <summary>
        /// <para>Returns the base 2 logarithm of the parameter. Translates to <c>log2(x)</c> in the Godot Shader Language.</para>
        /// </summary>
        Log2 = 26,
        /// <summary>
        /// <para>Convert a quantity in degrees to radians. Translates to <c>radians(x)</c> in the Godot Shader Language.</para>
        /// </summary>
        Radians = 27,
        /// <summary>
        /// <para>Finds reciprocal value of dividing 1 by <c>x</c> (i.e. <c>1 / x</c>).</para>
        /// </summary>
        Reciprocal = 28,
        /// <summary>
        /// <para>Finds the nearest even integer to the parameter. Translates to <c>roundEven(x)</c> in the Godot Shader Language.</para>
        /// </summary>
        Roundeven = 29,
        /// <summary>
        /// <para>Returns a value equal to the nearest integer to <c>x</c> whose absolute value is not larger than the absolute value of <c>x</c>. Translates to <c>trunc(x)</c> in the Godot Shader Language.</para>
        /// </summary>
        Trunc = 30,
        /// <summary>
        /// <para>Subtracts scalar <c>x</c> from 1 (i.e. <c>1 - x</c>).</para>
        /// </summary>
        Oneminus = 31,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.VisualShaderNodeFloatFunc.FunctionEnum"/> enum.</para>
        /// </summary>
        Max = 32
    }

    /// <summary>
    /// <para>A function to be applied to the scalar.</para>
    /// </summary>
    public VisualShaderNodeFloatFunc.FunctionEnum Function
    {
        get
        {
            return GetFunction();
        }
        set
        {
            SetFunction(value);
        }
    }

    private static readonly System.Type CachedType = typeof(VisualShaderNodeFloatFunc);

    private static readonly StringName NativeName = "VisualShaderNodeFloatFunc";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public VisualShaderNodeFloatFunc() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal VisualShaderNodeFloatFunc(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal VisualShaderNodeFloatFunc(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFunction, 536026177ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFunction(VisualShaderNodeFloatFunc.FunctionEnum func)
    {
        NativeCalls.godot_icall_1_38(MethodBind0, GodotObject.GetPtr(this), (int)func);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFunction, 2033948868ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public VisualShaderNodeFloatFunc.FunctionEnum GetFunction()
    {
        return (VisualShaderNodeFloatFunc.FunctionEnum)NativeCalls.godot_icall_0_39(MethodBind1, GodotObject.GetPtr(this));
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
        /// Cached name for the 'function' property.
        /// </summary>
        public static readonly StringName Function = "function";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : VisualShaderNode.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_function' method.
        /// </summary>
        public static readonly StringName SetFunction = "set_function";
        /// <summary>
        /// Cached name for the 'get_function' method.
        /// </summary>
        public static readonly StringName GetFunction = "get_function";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : VisualShaderNode.SignalName
    {
    }
}
