namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Applies <see cref="Godot.VisualShaderNodeColorOp.Operator"/> to two color inputs.</para>
/// </summary>
public partial class VisualShaderNodeColorOp : VisualShaderNode
{
    public enum OperatorEnum : long
    {
        /// <summary>
        /// <para>Produce a screen effect with the following formula:</para>
        /// <para><code>
        /// result = vec3(1.0) - (vec3(1.0) - a) * (vec3(1.0) - b);
        /// </code></para>
        /// </summary>
        Screen = 0,
        /// <summary>
        /// <para>Produce a difference effect with the following formula:</para>
        /// <para><code>
        /// result = abs(a - b);
        /// </code></para>
        /// </summary>
        Difference = 1,
        /// <summary>
        /// <para>Produce a darken effect with the following formula:</para>
        /// <para><code>
        /// result = min(a, b);
        /// </code></para>
        /// </summary>
        Darken = 2,
        /// <summary>
        /// <para>Produce a lighten effect with the following formula:</para>
        /// <para><code>
        /// result = max(a, b);
        /// </code></para>
        /// </summary>
        Lighten = 3,
        /// <summary>
        /// <para>Produce an overlay effect with the following formula:</para>
        /// <para><code>
        /// for (int i = 0; i &lt; 3; i++) {
        /// 	float base = a[i];
        /// 	float blend = b[i];
        /// 	if (base &lt; 0.5) {
        /// 		result[i] = 2.0 * base * blend;
        /// 	} else {
        /// 		result[i] = 1.0 - 2.0 * (1.0 - blend) * (1.0 - base);
        /// 	}
        /// }
        /// </code></para>
        /// </summary>
        Overlay = 4,
        /// <summary>
        /// <para>Produce a dodge effect with the following formula:</para>
        /// <para><code>
        /// result = a / (vec3(1.0) - b);
        /// </code></para>
        /// </summary>
        Dodge = 5,
        /// <summary>
        /// <para>Produce a burn effect with the following formula:</para>
        /// <para><code>
        /// result = vec3(1.0) - (vec3(1.0) - a) / b;
        /// </code></para>
        /// </summary>
        Burn = 6,
        /// <summary>
        /// <para>Produce a soft light effect with the following formula:</para>
        /// <para><code>
        /// for (int i = 0; i &lt; 3; i++) {
        /// 	float base = a[i];
        /// 	float blend = b[i];
        /// 	if (base &lt; 0.5) {
        /// 		result[i] = base * (blend + 0.5);
        /// 	} else {
        /// 		result[i] = 1.0 - (1.0 - base) * (1.0 - (blend - 0.5));
        /// 	}
        /// }
        /// </code></para>
        /// </summary>
        SoftLight = 7,
        /// <summary>
        /// <para>Produce a hard light effect with the following formula:</para>
        /// <para><code>
        /// for (int i = 0; i &lt; 3; i++) {
        /// 	float base = a[i];
        /// 	float blend = b[i];
        /// 	if (base &lt; 0.5) {
        /// 		result[i] = base * (2.0 * blend);
        /// 	} else {
        /// 		result[i] = 1.0 - (1.0 - base) * (1.0 - 2.0 * (blend - 0.5));
        /// 	}
        /// }
        /// </code></para>
        /// </summary>
        HardLight = 8,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.VisualShaderNodeColorOp.OperatorEnum"/> enum.</para>
        /// </summary>
        Max = 9
    }

    /// <summary>
    /// <para>An operator to be applied to the inputs.</para>
    /// </summary>
    public VisualShaderNodeColorOp.OperatorEnum Operator
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

    private static readonly System.Type CachedType = typeof(VisualShaderNodeColorOp);

    private static readonly StringName NativeName = "VisualShaderNodeColorOp";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public VisualShaderNodeColorOp() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal VisualShaderNodeColorOp(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal VisualShaderNodeColorOp(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetOperator, 4260370673ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetOperator(VisualShaderNodeColorOp.OperatorEnum op)
    {
        NativeCalls.godot_icall_1_38(MethodBind0, GodotObject.GetPtr(this), (int)op);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOperator, 1950956529ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public VisualShaderNodeColorOp.OperatorEnum GetOperator()
    {
        return (VisualShaderNodeColorOp.OperatorEnum)NativeCalls.godot_icall_0_39(MethodBind1, GodotObject.GetPtr(this));
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
