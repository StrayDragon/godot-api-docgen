namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Returns the boolean result of the comparison between <c>INF</c> or <c>NaN</c> and a scalar parameter.</para>
/// </summary>
public partial class VisualShaderNodeIs : VisualShaderNode
{
    public enum FunctionEnum : long
    {
        /// <summary>
        /// <para>Comparison with <c>INF</c> (Infinity).</para>
        /// </summary>
        IsInf = 0,
        /// <summary>
        /// <para>Comparison with <c>NaN</c> (Not a Number; indicates invalid numeric results, such as division by zero).</para>
        /// </summary>
        IsNan = 1,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.VisualShaderNodeIs.FunctionEnum"/> enum.</para>
        /// </summary>
        Max = 2
    }

    /// <summary>
    /// <para>The comparison function.</para>
    /// </summary>
    public VisualShaderNodeIs.FunctionEnum Function
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

    private static readonly System.Type CachedType = typeof(VisualShaderNodeIs);

    private static readonly StringName NativeName = "VisualShaderNodeIs";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public VisualShaderNodeIs() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal VisualShaderNodeIs(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal VisualShaderNodeIs(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFunction, 1438374690ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFunction(VisualShaderNodeIs.FunctionEnum func)
    {
        NativeCalls.godot_icall_1_38(MethodBind0, GodotObject.GetPtr(this), (int)func);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFunction, 580678557ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public VisualShaderNodeIs.FunctionEnum GetFunction()
    {
        return (VisualShaderNodeIs.FunctionEnum)NativeCalls.godot_icall_0_39(MethodBind1, GodotObject.GetPtr(this));
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
