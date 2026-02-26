namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Remap will transform the input range into output range, e.g. you can change a <c>0..1</c> value to <c>-2..2</c> etc. See <c>@GlobalScope.remap</c> for more details.</para>
/// </summary>
public partial class VisualShaderNodeRemap : VisualShaderNode
{
    public enum OpTypeEnum : long
    {
        /// <summary>
        /// <para>A floating-point scalar type.</para>
        /// </summary>
        Scalar = 0,
        /// <summary>
        /// <para>A 2D vector type.</para>
        /// </summary>
        Vector2D = 1,
        /// <summary>
        /// <para>The <c>value</c> port uses a 2D vector type, while the <c>input min</c>, <c>input max</c>, <c>output min</c>, and <c>output max</c> ports use a floating-point scalar type.</para>
        /// </summary>
        Vector2DScalar = 2,
        /// <summary>
        /// <para>A 3D vector type.</para>
        /// </summary>
        Vector3D = 3,
        /// <summary>
        /// <para>The <c>value</c> port uses a 3D vector type, while the <c>input min</c>, <c>input max</c>, <c>output min</c>, and <c>output max</c> ports use a floating-point scalar type.</para>
        /// </summary>
        Vector3DScalar = 4,
        /// <summary>
        /// <para>A 4D vector type.</para>
        /// </summary>
        Vector4D = 5,
        /// <summary>
        /// <para>The <c>value</c> port uses a 4D vector type, while the <c>input min</c>, <c>input max</c>, <c>output min</c>, and <c>output max</c> ports use a floating-point scalar type.</para>
        /// </summary>
        Vector4DScalar = 6,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.VisualShaderNodeRemap.OpTypeEnum"/> enum.</para>
        /// </summary>
        Max = 7
    }

    public VisualShaderNodeRemap.OpTypeEnum OpType
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

    private static readonly System.Type CachedType = typeof(VisualShaderNodeRemap);

    private static readonly StringName NativeName = "VisualShaderNodeRemap";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public VisualShaderNodeRemap() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal VisualShaderNodeRemap(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal VisualShaderNodeRemap(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetOpType, 1703697889ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetOpType(VisualShaderNodeRemap.OpTypeEnum opType)
    {
        NativeCalls.godot_icall_1_38(MethodBind0, GodotObject.GetPtr(this), (int)opType);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOpType, 1678380563ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public VisualShaderNodeRemap.OpTypeEnum GetOpType()
    {
        return (VisualShaderNodeRemap.OpTypeEnum)NativeCalls.godot_icall_0_39(MethodBind1, GodotObject.GetPtr(this));
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
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : VisualShaderNode.SignalName
    {
    }
}
