namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A visual shader node able to perform different functions using vectors.</para>
/// </summary>
public partial class VisualShaderNodeVectorFunc : VisualShaderNodeVectorBase
{
    public enum FunctionEnum : long
    {
        /// <summary>
        /// <para>Normalizes the vector so that it has a length of <c>1</c> but points in the same direction.</para>
        /// </summary>
        Normalize = 0,
        /// <summary>
        /// <para>Clamps the value between <c>0.0</c> and <c>1.0</c>.</para>
        /// </summary>
        Saturate = 1,
        /// <summary>
        /// <para>Returns the opposite value of the parameter.</para>
        /// </summary>
        Negate = 2,
        /// <summary>
        /// <para>Returns <c>1/vector</c>.</para>
        /// </summary>
        Reciprocal = 3,
        /// <summary>
        /// <para>Returns the absolute value of the parameter.</para>
        /// </summary>
        Abs = 4,
        /// <summary>
        /// <para>Returns the arc-cosine of the parameter.</para>
        /// </summary>
        Acos = 5,
        /// <summary>
        /// <para>Returns the inverse hyperbolic cosine of the parameter.</para>
        /// </summary>
        Acosh = 6,
        /// <summary>
        /// <para>Returns the arc-sine of the parameter.</para>
        /// </summary>
        Asin = 7,
        /// <summary>
        /// <para>Returns the inverse hyperbolic sine of the parameter.</para>
        /// </summary>
        Asinh = 8,
        /// <summary>
        /// <para>Returns the arc-tangent of the parameter.</para>
        /// </summary>
        Atan = 9,
        /// <summary>
        /// <para>Returns the inverse hyperbolic tangent of the parameter.</para>
        /// </summary>
        Atanh = 10,
        /// <summary>
        /// <para>Finds the nearest integer that is greater than or equal to the parameter.</para>
        /// </summary>
        Ceil = 11,
        /// <summary>
        /// <para>Returns the cosine of the parameter.</para>
        /// </summary>
        Cos = 12,
        /// <summary>
        /// <para>Returns the hyperbolic cosine of the parameter.</para>
        /// </summary>
        Cosh = 13,
        /// <summary>
        /// <para>Converts a quantity in radians to degrees.</para>
        /// </summary>
        Degrees = 14,
        /// <summary>
        /// <para>Base-e Exponential.</para>
        /// </summary>
        Exp = 15,
        /// <summary>
        /// <para>Base-2 Exponential.</para>
        /// </summary>
        Exp2 = 16,
        /// <summary>
        /// <para>Finds the nearest integer less than or equal to the parameter.</para>
        /// </summary>
        Floor = 17,
        /// <summary>
        /// <para>Computes the fractional part of the argument.</para>
        /// </summary>
        Fract = 18,
        /// <summary>
        /// <para>Returns the inverse of the square root of the parameter.</para>
        /// </summary>
        InverseSqrt = 19,
        /// <summary>
        /// <para>Natural logarithm.</para>
        /// </summary>
        Log = 20,
        /// <summary>
        /// <para>Base-2 logarithm.</para>
        /// </summary>
        Log2 = 21,
        /// <summary>
        /// <para>Converts a quantity in degrees to radians.</para>
        /// </summary>
        Radians = 22,
        /// <summary>
        /// <para>Finds the nearest integer to the parameter.</para>
        /// </summary>
        Round = 23,
        /// <summary>
        /// <para>Finds the nearest even integer to the parameter.</para>
        /// </summary>
        Roundeven = 24,
        /// <summary>
        /// <para>Extracts the sign of the parameter, i.e. returns <c>-1</c> if the parameter is negative, <c>1</c> if it's positive and <c>0</c> otherwise.</para>
        /// </summary>
        Sign = 25,
        /// <summary>
        /// <para>Returns the sine of the parameter.</para>
        /// </summary>
        Sin = 26,
        /// <summary>
        /// <para>Returns the hyperbolic sine of the parameter.</para>
        /// </summary>
        Sinh = 27,
        /// <summary>
        /// <para>Returns the square root of the parameter.</para>
        /// </summary>
        Sqrt = 28,
        /// <summary>
        /// <para>Returns the tangent of the parameter.</para>
        /// </summary>
        Tan = 29,
        /// <summary>
        /// <para>Returns the hyperbolic tangent of the parameter.</para>
        /// </summary>
        Tanh = 30,
        /// <summary>
        /// <para>Returns a value equal to the nearest integer to the parameter whose absolute value is not larger than the absolute value of the parameter.</para>
        /// </summary>
        Trunc = 31,
        /// <summary>
        /// <para>Returns <c>1.0 - vector</c>.</para>
        /// </summary>
        Oneminus = 32,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.VisualShaderNodeVectorFunc.FunctionEnum"/> enum.</para>
        /// </summary>
        Max = 33
    }

    /// <summary>
    /// <para>The function to be performed.</para>
    /// </summary>
    public VisualShaderNodeVectorFunc.FunctionEnum Function
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

    private static readonly System.Type CachedType = typeof(VisualShaderNodeVectorFunc);

    private static readonly StringName NativeName = "VisualShaderNodeVectorFunc";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public VisualShaderNodeVectorFunc() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal VisualShaderNodeVectorFunc(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal VisualShaderNodeVectorFunc(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFunction, 629964457ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFunction(VisualShaderNodeVectorFunc.FunctionEnum func)
    {
        NativeCalls.godot_icall_1_38(MethodBind0, GodotObject.GetPtr(this), (int)func);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFunction, 4047776843ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public VisualShaderNodeVectorFunc.FunctionEnum GetFunction()
    {
        return (VisualShaderNodeVectorFunc.FunctionEnum)NativeCalls.godot_icall_0_39(MethodBind1, GodotObject.GetPtr(this));
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
    public new class PropertyName : VisualShaderNodeVectorBase.PropertyName
    {
        /// <summary>
        /// Cached name for the 'function' property.
        /// </summary>
        public static readonly StringName Function = "function";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : VisualShaderNodeVectorBase.MethodName
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
    public new class SignalName : VisualShaderNodeVectorBase.SignalName
    {
    }
}
