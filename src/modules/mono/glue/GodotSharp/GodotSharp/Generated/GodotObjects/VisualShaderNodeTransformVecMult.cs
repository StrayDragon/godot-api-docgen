namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A multiplication operation on a transform (4×4 matrix) and a vector, with support for different multiplication operators.</para>
/// </summary>
public partial class VisualShaderNodeTransformVecMult : VisualShaderNode
{
    public enum OperatorEnum : long
    {
        /// <summary>
        /// <para>Multiplies transform <c>a</c> by the vector <c>b</c>.</para>
        /// </summary>
        Axb = 0,
        /// <summary>
        /// <para>Multiplies vector <c>b</c> by the transform <c>a</c>.</para>
        /// </summary>
        Bxa = 1,
        /// <summary>
        /// <para>Multiplies transform <c>a</c> by the vector <c>b</c>, skipping the last row and column of the transform.</para>
        /// </summary>
        Op3X3Axb = 2,
        /// <summary>
        /// <para>Multiplies vector <c>b</c> by the transform <c>a</c>, skipping the last row and column of the transform.</para>
        /// </summary>
        Op3X3Bxa = 3,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.VisualShaderNodeTransformVecMult.OperatorEnum"/> enum.</para>
        /// </summary>
        Max = 4
    }

    /// <summary>
    /// <para>The multiplication type to be performed.</para>
    /// </summary>
    public VisualShaderNodeTransformVecMult.OperatorEnum Operator
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

    private static readonly System.Type CachedType = typeof(VisualShaderNodeTransformVecMult);

    private static readonly StringName NativeName = "VisualShaderNodeTransformVecMult";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public VisualShaderNodeTransformVecMult() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal VisualShaderNodeTransformVecMult(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal VisualShaderNodeTransformVecMult(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetOperator, 1785665912ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetOperator(VisualShaderNodeTransformVecMult.OperatorEnum op)
    {
        NativeCalls.godot_icall_1_38(MethodBind0, GodotObject.GetPtr(this), (int)op);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOperator, 1622088722ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public VisualShaderNodeTransformVecMult.OperatorEnum GetOperator()
    {
        return (VisualShaderNodeTransformVecMult.OperatorEnum)NativeCalls.godot_icall_0_39(MethodBind1, GodotObject.GetPtr(this));
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
