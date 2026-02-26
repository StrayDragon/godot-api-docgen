namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This node is only available in <c>Fragment</c> and <c>Light</c> visual shaders.</para>
/// </summary>
public partial class VisualShaderNodeDerivativeFunc : VisualShaderNode
{
    public enum OpTypeEnum : long
    {
        /// <summary>
        /// <para>A floating-point scalar.</para>
        /// </summary>
        Scalar = 0,
        /// <summary>
        /// <para>A 2D vector type.</para>
        /// </summary>
        Vector2D = 1,
        /// <summary>
        /// <para>A 3D vector type.</para>
        /// </summary>
        Vector3D = 2,
        /// <summary>
        /// <para>A 4D vector type.</para>
        /// </summary>
        Vector4D = 3,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.VisualShaderNodeDerivativeFunc.OpTypeEnum"/> enum.</para>
        /// </summary>
        Max = 4
    }

    public enum FunctionEnum : long
    {
        /// <summary>
        /// <para>Sum of absolute derivative in <c>x</c> and <c>y</c>.</para>
        /// </summary>
        Sum = 0,
        /// <summary>
        /// <para>Derivative in <c>x</c> using local differencing.</para>
        /// </summary>
        X = 1,
        /// <summary>
        /// <para>Derivative in <c>y</c> using local differencing.</para>
        /// </summary>
        Y = 2,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.VisualShaderNodeDerivativeFunc.FunctionEnum"/> enum.</para>
        /// </summary>
        Max = 3
    }

    public enum PrecisionEnum : long
    {
        /// <summary>
        /// <para>No precision is specified, the GPU driver is allowed to use whatever level of precision it chooses. This is the default option and is equivalent to using <c>dFdx()</c> or <c>dFdy()</c> in text shaders.</para>
        /// </summary>
        None = 0,
        /// <summary>
        /// <para>The derivative will be calculated using the current fragment's neighbors (which may not include the current fragment). This tends to be faster than using <see cref="Godot.VisualShaderNodeDerivativeFunc.PrecisionEnum.Fine"/>, but may not be suitable when more precision is needed. This is equivalent to using <c>dFdxCoarse()</c> or <c>dFdyCoarse()</c> in text shaders.</para>
        /// </summary>
        Coarse = 1,
        /// <summary>
        /// <para>The derivative will be calculated using the current fragment and its immediate neighbors. This tends to be slower than using <see cref="Godot.VisualShaderNodeDerivativeFunc.PrecisionEnum.Coarse"/>, but may be necessary when more precision is needed. This is equivalent to using <c>dFdxFine()</c> or <c>dFdyFine()</c> in text shaders.</para>
        /// </summary>
        Fine = 2,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.VisualShaderNodeDerivativeFunc.PrecisionEnum"/> enum.</para>
        /// </summary>
        Max = 3
    }

    /// <summary>
    /// <para>A type of operands and returned value.</para>
    /// </summary>
    public VisualShaderNodeDerivativeFunc.OpTypeEnum OpType
    {
        get
        {
            return GetOpType();
        }
        set
        {
            SetOpType(value);
        }
    }

    /// <summary>
    /// <para>A derivative function type.</para>
    /// </summary>
    public VisualShaderNodeDerivativeFunc.FunctionEnum Function
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

    /// <summary>
    /// <para>Sets the level of precision to use for the derivative function. When using the Compatibility renderer, this setting has no effect.</para>
    /// </summary>
    public VisualShaderNodeDerivativeFunc.PrecisionEnum Precision
    {
        get
        {
            return GetPrecision();
        }
        set
        {
            SetPrecision(value);
        }
    }

    private static readonly System.Type CachedType = typeof(VisualShaderNodeDerivativeFunc);

    private static readonly StringName NativeName = "VisualShaderNodeDerivativeFunc";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public VisualShaderNodeDerivativeFunc() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal VisualShaderNodeDerivativeFunc(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal VisualShaderNodeDerivativeFunc(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetOpType, 377800221ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetOpType(VisualShaderNodeDerivativeFunc.OpTypeEnum type)
    {
        NativeCalls.godot_icall_1_38(MethodBind0, GodotObject.GetPtr(this), (int)type);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOpType, 3997800514ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public VisualShaderNodeDerivativeFunc.OpTypeEnum GetOpType()
    {
        return (VisualShaderNodeDerivativeFunc.OpTypeEnum)NativeCalls.godot_icall_0_39(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFunction, 1944704156ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFunction(VisualShaderNodeDerivativeFunc.FunctionEnum func)
    {
        NativeCalls.godot_icall_1_38(MethodBind2, GodotObject.GetPtr(this), (int)func);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFunction, 2389093396ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public VisualShaderNodeDerivativeFunc.FunctionEnum GetFunction()
    {
        return (VisualShaderNodeDerivativeFunc.FunctionEnum)NativeCalls.godot_icall_0_39(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPrecision, 797270566ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPrecision(VisualShaderNodeDerivativeFunc.PrecisionEnum precision)
    {
        NativeCalls.godot_icall_1_38(MethodBind4, GodotObject.GetPtr(this), (int)precision);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPrecision, 3822547323ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public VisualShaderNodeDerivativeFunc.PrecisionEnum GetPrecision()
    {
        return (VisualShaderNodeDerivativeFunc.PrecisionEnum)NativeCalls.godot_icall_0_39(MethodBind5, GodotObject.GetPtr(this));
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
        /// Cached name for the 'op_type' property.
        /// </summary>
        public static readonly StringName OpType = "op_type";
        /// <summary>
        /// Cached name for the 'function' property.
        /// </summary>
        public static readonly StringName Function = "function";
        /// <summary>
        /// Cached name for the 'precision' property.
        /// </summary>
        public static readonly StringName Precision = "precision";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : VisualShaderNode.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_op_type' method.
        /// </summary>
        public static readonly StringName SetOpType = "set_op_type";
        /// <summary>
        /// Cached name for the 'get_op_type' method.
        /// </summary>
        public static readonly StringName GetOpType = "get_op_type";
        /// <summary>
        /// Cached name for the 'set_function' method.
        /// </summary>
        public static readonly StringName SetFunction = "set_function";
        /// <summary>
        /// Cached name for the 'get_function' method.
        /// </summary>
        public static readonly StringName GetFunction = "get_function";
        /// <summary>
        /// Cached name for the 'set_precision' method.
        /// </summary>
        public static readonly StringName SetPrecision = "set_precision";
        /// <summary>
        /// Cached name for the 'get_precision' method.
        /// </summary>
        public static readonly StringName GetPrecision = "get_precision";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : VisualShaderNode.SignalName
    {
    }
}
