namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Applies <see cref="Godot.VisualShaderNodeTransformOp.Operator"/> to two transform (4×4 matrices) inputs.</para>
/// </summary>
public partial class VisualShaderNodeTransformOp : VisualShaderNode
{
    public enum OperatorEnum : long
    {
        /// <summary>
        /// <para>Multiplies transform <c>a</c> by the transform <c>b</c>.</para>
        /// </summary>
        Axb = 0,
        /// <summary>
        /// <para>Multiplies transform <c>b</c> by the transform <c>a</c>.</para>
        /// </summary>
        Bxa = 1,
        /// <summary>
        /// <para>Performs a component-wise multiplication of transform <c>a</c> by the transform <c>b</c>.</para>
        /// </summary>
        AxbComp = 2,
        /// <summary>
        /// <para>Performs a component-wise multiplication of transform <c>b</c> by the transform <c>a</c>.</para>
        /// </summary>
        BxaComp = 3,
        /// <summary>
        /// <para>Adds two transforms.</para>
        /// </summary>
        Add = 4,
        /// <summary>
        /// <para>Subtracts the transform <c>a</c> from the transform <c>b</c>.</para>
        /// </summary>
        AMinusB = 5,
        /// <summary>
        /// <para>Subtracts the transform <c>b</c> from the transform <c>a</c>.</para>
        /// </summary>
        BMinusA = 6,
        /// <summary>
        /// <para>Divides the transform <c>a</c> by the transform <c>b</c>.</para>
        /// </summary>
        ADivB = 7,
        /// <summary>
        /// <para>Divides the transform <c>b</c> by the transform <c>a</c>.</para>
        /// </summary>
        BDivA = 8,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.VisualShaderNodeTransformOp.OperatorEnum"/> enum.</para>
        /// </summary>
        Max = 9
    }

    /// <summary>
    /// <para>The type of the operation to be performed on the transforms.</para>
    /// </summary>
    public VisualShaderNodeTransformOp.OperatorEnum Operator
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

    private static readonly System.Type CachedType = typeof(VisualShaderNodeTransformOp);

    private static readonly StringName NativeName = "VisualShaderNodeTransformOp";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public VisualShaderNodeTransformOp() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal VisualShaderNodeTransformOp(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal VisualShaderNodeTransformOp(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetOperator, 2287310733ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetOperator(VisualShaderNodeTransformOp.OperatorEnum op)
    {
        NativeCalls.godot_icall_1_38(MethodBind0, GodotObject.GetPtr(this), (int)op);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOperator, 1238663601ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public VisualShaderNodeTransformOp.OperatorEnum GetOperator()
    {
        return (VisualShaderNodeTransformOp.OperatorEnum)NativeCalls.godot_icall_0_39(MethodBind1, GodotObject.GetPtr(this));
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
