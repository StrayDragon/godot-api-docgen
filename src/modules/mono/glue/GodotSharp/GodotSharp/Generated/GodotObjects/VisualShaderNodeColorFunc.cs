namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Accept a <see cref="Godot.Color"/> to the input port and transform it according to <see cref="Godot.VisualShaderNodeColorFunc.Function"/>.</para>
/// </summary>
public partial class VisualShaderNodeColorFunc : VisualShaderNode
{
    public enum FunctionEnum : long
    {
        /// <summary>
        /// <para>Converts the color to grayscale using the following formula:</para>
        /// <para><code>
        /// vec3 c = input;
        /// float max1 = max(c.r, c.g);
        /// float max2 = max(max1, c.b);
        /// float max3 = max(max1, max2);
        /// return vec3(max3, max3, max3);
        /// </code></para>
        /// </summary>
        Grayscale = 0,
        /// <summary>
        /// <para>Converts HSV vector to RGB equivalent.</para>
        /// </summary>
        Hsv2Rgb = 1,
        /// <summary>
        /// <para>Converts RGB vector to HSV equivalent.</para>
        /// </summary>
        Rgb2Hsv = 2,
        /// <summary>
        /// <para>Applies sepia tone effect using the following formula:</para>
        /// <para><code>
        /// vec3 c = input;
        /// float r = (c.r * 0.393) + (c.g * 0.769) + (c.b * 0.189);
        /// float g = (c.r * 0.349) + (c.g * 0.686) + (c.b * 0.168);
        /// float b = (c.r * 0.272) + (c.g * 0.534) + (c.b * 0.131);
        /// return vec3(r, g, b);
        /// </code></para>
        /// </summary>
        Sepia = 3,
        /// <summary>
        /// <para>Converts color from linear encoding to nonlinear sRGB encoding using the following formula:</para>
        /// <para><code>
        /// vec3 c = clamp(c, vec3(0.0), vec3(1.0));
        /// const vec3 a = vec3(0.055f);
        /// return mix((vec3(1.0f) + a) * pow(c.rgb, vec3(1.0f / 2.4f)) - a, 12.92f * c.rgb, lessThan(c.rgb, vec3(0.0031308f)));
        /// </code></para>
        /// <para>The Compatibility renderer uses a simpler formula:</para>
        /// <para><code>
        /// vec3 c = input;
        /// return max(vec3(1.055) * pow(c, vec3(0.416666667)) - vec3(0.055), vec3(0.0));
        /// </code></para>
        /// </summary>
        LinearToSrgb = 4,
        /// <summary>
        /// <para>Converts color from nonlinear sRGB encoding to linear encoding using the following formula:</para>
        /// <para><code>
        /// vec3 c = input;
        /// return mix(pow((c.rgb + vec3(0.055)) * (1.0 / (1.0 + 0.055)), vec3(2.4)), c.rgb * (1.0 / 12.92), lessThan(c.rgb, vec3(0.04045)));
        /// </code></para>
        /// <para>The Compatibility renderer uses a simpler formula:</para>
        /// <para><code>
        /// vec3 c = input;
        /// return c * (c * (c * 0.305306011 + 0.682171111) + 0.012522878);
        /// </code></para>
        /// </summary>
        SrgbToLinear = 5,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.VisualShaderNodeColorFunc.FunctionEnum"/> enum.</para>
        /// </summary>
        Max = 6
    }

    /// <summary>
    /// <para>A function to be applied to the input color.</para>
    /// </summary>
    public VisualShaderNodeColorFunc.FunctionEnum Function
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

    private static readonly System.Type CachedType = typeof(VisualShaderNodeColorFunc);

    private static readonly StringName NativeName = "VisualShaderNodeColorFunc";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public VisualShaderNodeColorFunc() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal VisualShaderNodeColorFunc(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal VisualShaderNodeColorFunc(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFunction, 3973396138ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFunction(VisualShaderNodeColorFunc.FunctionEnum func)
    {
        NativeCalls.godot_icall_1_38(MethodBind0, GodotObject.GetPtr(this), (int)func);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFunction, 554863321ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public VisualShaderNodeColorFunc.FunctionEnum GetFunction()
    {
        return (VisualShaderNodeColorFunc.FunctionEnum)NativeCalls.godot_icall_0_39(MethodBind1, GodotObject.GetPtr(this));
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
