namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A visual shader node for use of vector operators. Operates on vector <c>a</c> and vector <c>b</c>.</para>
/// </summary>
public partial class VisualShaderNodeVectorOp : VisualShaderNodeVectorBase
{
    public enum OperatorEnum : long
    {
        /// <summary>
        /// <para>Adds two vectors.</para>
        /// </summary>
        Add = 0,
        /// <summary>
        /// <para>Subtracts a vector from a vector.</para>
        /// </summary>
        Sub = 1,
        /// <summary>
        /// <para>Multiplies two vectors.</para>
        /// </summary>
        Mul = 2,
        /// <summary>
        /// <para>Divides vector by vector.</para>
        /// </summary>
        Div = 3,
        /// <summary>
        /// <para>Returns the remainder of the two vectors.</para>
        /// </summary>
        Mod = 4,
        /// <summary>
        /// <para>Returns the value of the first parameter raised to the power of the second, for each component of the vectors.</para>
        /// </summary>
        Pow = 5,
        /// <summary>
        /// <para>Returns the greater of two values, for each component of the vectors.</para>
        /// </summary>
        Max = 6,
        /// <summary>
        /// <para>Returns the lesser of two values, for each component of the vectors.</para>
        /// </summary>
        Min = 7,
        /// <summary>
        /// <para>Calculates the cross product of two vectors.</para>
        /// </summary>
        Cross = 8,
        /// <summary>
        /// <para>Returns the arc-tangent of the parameters.</para>
        /// </summary>
        Atan2 = 9,
        /// <summary>
        /// <para>Returns the vector that points in the direction of reflection. <c>a</c> is incident vector and <c>b</c> is the normal vector.</para>
        /// </summary>
        Reflect = 10,
        /// <summary>
        /// <para>Vector step operator. Returns <c>0.0</c> if <c>a</c> is smaller than <c>b</c> and <c>1.0</c> otherwise.</para>
        /// </summary>
        Step = 11,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.VisualShaderNodeVectorOp.OperatorEnum"/> enum.</para>
        /// </summary>
        EnumSize = 12
    }

    /// <summary>
    /// <para>The operator to be used.</para>
    /// </summary>
    public VisualShaderNodeVectorOp.OperatorEnum Operator
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

    private static readonly System.Type CachedType = typeof(VisualShaderNodeVectorOp);

    private static readonly StringName NativeName = "VisualShaderNodeVectorOp";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public VisualShaderNodeVectorOp() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal VisualShaderNodeVectorOp(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal VisualShaderNodeVectorOp(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetOperator, 3371507302ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetOperator(VisualShaderNodeVectorOp.OperatorEnum op)
    {
        NativeCalls.godot_icall_1_38(MethodBind0, GodotObject.GetPtr(this), (int)op);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOperator, 11793929ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public VisualShaderNodeVectorOp.OperatorEnum GetOperator()
    {
        return (VisualShaderNodeVectorOp.OperatorEnum)NativeCalls.godot_icall_0_39(MethodBind1, GodotObject.GetPtr(this));
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
        /// Cached name for the 'operator' property.
        /// </summary>
        public static readonly StringName Operator = "operator";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : VisualShaderNodeVectorBase.MethodName
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
    public new class SignalName : VisualShaderNodeVectorBase.SignalName
    {
    }
}
