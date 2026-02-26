namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This resource describes a color transition by defining a set of colored points and how to interpolate between them.</para>
/// <para>See also <see cref="Godot.Curve"/> which supports more complex easing methods, but does not support colors.</para>
/// </summary>
public partial class Gradient : Resource
{
    public enum InterpolationModeEnum : long
    {
        /// <summary>
        /// <para>Linear interpolation.</para>
        /// </summary>
        Linear = 0,
        /// <summary>
        /// <para>Constant interpolation, color changes abruptly at each point and stays uniform between. This might cause visible aliasing when used for a gradient texture in some cases.</para>
        /// </summary>
        Constant = 1,
        /// <summary>
        /// <para>Cubic interpolation.</para>
        /// </summary>
        Cubic = 2
    }

    public enum ColorSpace : long
    {
        /// <summary>
        /// <para>sRGB color space.</para>
        /// </summary>
        Srgb = 0,
        /// <summary>
        /// <para>Linear sRGB color space.</para>
        /// </summary>
        LinearSrgb = 1,
        /// <summary>
        /// <para><a href="https://bottosson.github.io/posts/oklab/">Oklab</a> color space. This color space provides a smooth and uniform-looking transition between colors.</para>
        /// </summary>
        Oklab = 2
    }

    /// <summary>
    /// <para>The algorithm used to interpolate between points of the gradient.</para>
    /// </summary>
    public Gradient.InterpolationModeEnum InterpolationMode
    {
        get
        {
            return GetInterpolationMode();
        }
        set
        {
            SetInterpolationMode(value);
        }
    }

    /// <summary>
    /// <para>The color space used to interpolate between points of the gradient. It does not affect the returned colors, which will always use nonlinear sRGB encoding.</para>
    /// <para><b>Note:</b> This setting has no effect when <see cref="Godot.Gradient.InterpolationMode"/> is set to <see cref="Godot.Gradient.InterpolationModeEnum.Constant"/>.</para>
    /// </summary>
    public Gradient.ColorSpace InterpolationColorSpace
    {
        get
        {
            return GetInterpolationColorSpace();
        }
        set
        {
            SetInterpolationColorSpace(value);
        }
    }

    /// <summary>
    /// <para>Gradient's offsets as a <see cref="float"/>[].</para>
    /// <para><b>Note:</b> Setting this property updates all offsets at once. To update any offset individually use <see cref="Godot.Gradient.SetOffset(int, float)"/>.</para>
    /// </summary>
    public float[] Offsets
    {
        get
        {
            return GetOffsets();
        }
        set
        {
            SetOffsets(value);
        }
    }

    /// <summary>
    /// <para>Gradient's colors as a <see cref="Godot.Color"/>[].</para>
    /// <para><b>Note:</b> Setting this property updates all colors at once. To update any color individually use <see cref="Godot.Gradient.SetColor(int, Color)"/>.</para>
    /// </summary>
    public Color[] Colors
    {
        get
        {
            return GetColors();
        }
        set
        {
            SetColors(value);
        }
    }

    private static readonly System.Type CachedType = typeof(Gradient);

    private static readonly StringName NativeName = "Gradient";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public Gradient() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal Gradient(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal Gradient(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddPoint, 3629403827ul);

    /// <summary>
    /// <para>Adds the specified color to the gradient, with the specified offset.</para>
    /// </summary>
    public unsafe void AddPoint(float offset, Color color)
    {
        NativeCalls.godot_icall_2_686(MethodBind0, GodotObject.GetPtr(this), offset, &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemovePoint, 1286410249ul);

    /// <summary>
    /// <para>Removes the color at index <paramref name="point"/>.</para>
    /// </summary>
    public void RemovePoint(int point)
    {
        NativeCalls.godot_icall_1_38(MethodBind1, GodotObject.GetPtr(this), point);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetOffset, 1602489585ul);

    /// <summary>
    /// <para>Sets the offset for the gradient color at index <paramref name="point"/>.</para>
    /// </summary>
    public void SetOffset(int point, float offset)
    {
        NativeCalls.godot_icall_2_69(MethodBind2, GodotObject.GetPtr(this), point, offset);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOffset, 4025615559ul);

    /// <summary>
    /// <para>Returns the offset of the gradient color at index <paramref name="point"/>.</para>
    /// </summary>
    public float GetOffset(int point)
    {
        return NativeCalls.godot_icall_1_72(MethodBind3, GodotObject.GetPtr(this), point);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Reverse, 3218959716ul);

    /// <summary>
    /// <para>Reverses/mirrors the gradient.</para>
    /// <para><b>Note:</b> This method mirrors all points around the middle of the gradient, which may produce unexpected results when <see cref="Godot.Gradient.InterpolationMode"/> is set to <see cref="Godot.Gradient.InterpolationModeEnum.Constant"/>.</para>
    /// </summary>
    public void Reverse()
    {
        NativeCalls.godot_icall_0_3(MethodBind4, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetColor, 2878471219ul);

    /// <summary>
    /// <para>Sets the color of the gradient color at index <paramref name="point"/>.</para>
    /// </summary>
    public unsafe void SetColor(int point, Color color)
    {
        NativeCalls.godot_icall_2_687(MethodBind5, GodotObject.GetPtr(this), point, &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetColor, 2624840992ul);

    /// <summary>
    /// <para>Returns the color of the gradient color at index <paramref name="point"/>.</para>
    /// </summary>
    public Color GetColor(int point)
    {
        return NativeCalls.godot_icall_1_688(MethodBind6, GodotObject.GetPtr(this), point);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Sample, 1250405064ul);

    /// <summary>
    /// <para>Returns the interpolated color specified by <paramref name="offset"/>. <paramref name="offset"/> should be between <c>0.0</c> and <c>1.0</c> (inclusive). Using a value lower than <c>0.0</c> will return the same color as <c>0.0</c>, and using a value higher than <c>1.0</c> will return the same color as <c>1.0</c>. If your input value is not within this range, consider using <c>@GlobalScope.remap</c> on the input value with output values set to <c>0.0</c> and <c>1.0</c>.</para>
    /// </summary>
    public Color Sample(float offset)
    {
        return NativeCalls.godot_icall_1_689(MethodBind7, GodotObject.GetPtr(this), offset);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPointCount, 3905245786ul);

    /// <summary>
    /// <para>Returns the number of colors in the gradient.</para>
    /// </summary>
    public int GetPointCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind8, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetOffsets, 2899603908ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetOffsets(float[] offsets)
    {
        NativeCalls.godot_icall_1_647(MethodBind9, GodotObject.GetPtr(this), offsets);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetOffsets(ReadOnlySpan<float> offsets)
    {
        NativeCalls.godot_icall_1_647(MethodBind9, GodotObject.GetPtr(this), offsets);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOffsets, 675695659ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float[] GetOffsets()
    {
        return NativeCalls.godot_icall_0_368(MethodBind10, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetColors, 3546319833ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetColors(Color[] colors)
    {
        NativeCalls.godot_icall_1_226(MethodBind11, GodotObject.GetPtr(this), colors);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetColors(ReadOnlySpan<Color> colors)
    {
        NativeCalls.godot_icall_1_226(MethodBind11, GodotObject.GetPtr(this), colors);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetColors, 1392750486ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Color[] GetColors()
    {
        return NativeCalls.godot_icall_0_227(MethodBind12, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetInterpolationMode, 1971444490ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetInterpolationMode(Gradient.InterpolationModeEnum interpolationMode)
    {
        NativeCalls.godot_icall_1_38(MethodBind13, GodotObject.GetPtr(this), (int)interpolationMode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetInterpolationMode, 3674172981ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Gradient.InterpolationModeEnum GetInterpolationMode()
    {
        return (Gradient.InterpolationModeEnum)NativeCalls.godot_icall_0_39(MethodBind14, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetInterpolationColorSpace, 3685995981ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetInterpolationColorSpace(Gradient.ColorSpace interpolationColorSpace)
    {
        NativeCalls.godot_icall_1_38(MethodBind15, GodotObject.GetPtr(this), (int)interpolationColorSpace);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetInterpolationColorSpace, 1538296000ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Gradient.ColorSpace GetInterpolationColorSpace()
    {
        return (Gradient.ColorSpace)NativeCalls.godot_icall_0_39(MethodBind16, GodotObject.GetPtr(this));
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
    public new class PropertyName : Resource.PropertyName
    {
        /// <summary>
        /// Cached name for the 'interpolation_mode' property.
        /// </summary>
        public static readonly StringName InterpolationMode = "interpolation_mode";
        /// <summary>
        /// Cached name for the 'interpolation_color_space' property.
        /// </summary>
        public static readonly StringName InterpolationColorSpace = "interpolation_color_space";
        /// <summary>
        /// Cached name for the 'offsets' property.
        /// </summary>
        public static readonly StringName Offsets = "offsets";
        /// <summary>
        /// Cached name for the 'colors' property.
        /// </summary>
        public static readonly StringName Colors = "colors";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Resource.MethodName
    {
        /// <summary>
        /// Cached name for the 'add_point' method.
        /// </summary>
        public static readonly StringName AddPoint = "add_point";
        /// <summary>
        /// Cached name for the 'remove_point' method.
        /// </summary>
        public static readonly StringName RemovePoint = "remove_point";
        /// <summary>
        /// Cached name for the 'set_offset' method.
        /// </summary>
        public static readonly StringName SetOffset = "set_offset";
        /// <summary>
        /// Cached name for the 'get_offset' method.
        /// </summary>
        public static readonly StringName GetOffset = "get_offset";
        /// <summary>
        /// Cached name for the 'reverse' method.
        /// </summary>
        public static readonly StringName Reverse = "reverse";
        /// <summary>
        /// Cached name for the 'set_color' method.
        /// </summary>
        public static readonly StringName SetColor = "set_color";
        /// <summary>
        /// Cached name for the 'get_color' method.
        /// </summary>
        public static readonly StringName GetColor = "get_color";
        /// <summary>
        /// Cached name for the 'sample' method.
        /// </summary>
        public static readonly StringName Sample = "sample";
        /// <summary>
        /// Cached name for the 'get_point_count' method.
        /// </summary>
        public static readonly StringName GetPointCount = "get_point_count";
        /// <summary>
        /// Cached name for the 'set_offsets' method.
        /// </summary>
        public static readonly StringName SetOffsets = "set_offsets";
        /// <summary>
        /// Cached name for the 'get_offsets' method.
        /// </summary>
        public static readonly StringName GetOffsets = "get_offsets";
        /// <summary>
        /// Cached name for the 'set_colors' method.
        /// </summary>
        public static readonly StringName SetColors = "set_colors";
        /// <summary>
        /// Cached name for the 'get_colors' method.
        /// </summary>
        public static readonly StringName GetColors = "get_colors";
        /// <summary>
        /// Cached name for the 'set_interpolation_mode' method.
        /// </summary>
        public static readonly StringName SetInterpolationMode = "set_interpolation_mode";
        /// <summary>
        /// Cached name for the 'get_interpolation_mode' method.
        /// </summary>
        public static readonly StringName GetInterpolationMode = "get_interpolation_mode";
        /// <summary>
        /// Cached name for the 'set_interpolation_color_space' method.
        /// </summary>
        public static readonly StringName SetInterpolationColorSpace = "set_interpolation_color_space";
        /// <summary>
        /// Cached name for the 'get_interpolation_color_space' method.
        /// </summary>
        public static readonly StringName GetInterpolationColorSpace = "get_interpolation_color_space";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Resource.SignalName
    {
    }
}
