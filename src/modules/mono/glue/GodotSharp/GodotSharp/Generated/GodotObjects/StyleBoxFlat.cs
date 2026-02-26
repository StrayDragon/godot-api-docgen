namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>By configuring various properties of this style box, you can achieve many common looks without the need of a texture. This includes optionally rounded borders, antialiasing, shadows, and skew.</para>
/// <para>Setting corner radius to high values is allowed. As soon as corners overlap, the stylebox will switch to a relative system:</para>
/// <para><code>
/// height = 30
/// corner_radius_top_left = 50
/// corner_radius_bottom_left = 100
/// </code></para>
/// <para>The relative system now would take the 1:2 ratio of the two left corners to calculate the actual corner width. Both corners added will <b>never</b> be more than the height. Result:</para>
/// <para><code>
/// corner_radius_top_left: 10
/// corner_radius_bottom_left: 20
/// </code></para>
/// </summary>
public partial class StyleBoxFlat : StyleBox
{
    /// <summary>
    /// <para>The background color of the stylebox.</para>
    /// </summary>
    public Color BgColor
    {
        get
        {
            return GetBgColor();
        }
        set
        {
            SetBgColor(value);
        }
    }

    /// <summary>
    /// <para>Toggles drawing of the inner part of the stylebox.</para>
    /// </summary>
    public bool DrawCenter
    {
        get
        {
            return IsDrawCenterEnabled();
        }
        set
        {
            SetDrawCenter(value);
        }
    }

    /// <summary>
    /// <para>If set to a non-zero value on either axis, <see cref="Godot.StyleBoxFlat.Skew"/> distorts the StyleBox horizontally and/or vertically. This can be used for "futuristic"-style UIs. Positive values skew the StyleBox towards the right (X axis) and upwards (Y axis), while negative values skew the StyleBox towards the left (X axis) and downwards (Y axis).</para>
    /// <para><b>Note:</b> To ensure text does not touch the StyleBox's edges, consider increasing the <see cref="Godot.StyleBox"/>'s content margin (see <see cref="Godot.StyleBox.ContentMarginBottom"/>). It is preferable to increase the content margin instead of the expand margin (see <see cref="Godot.StyleBoxFlat.ExpandMarginBottom"/>), as increasing the expand margin does not increase the size of the clickable area for <see cref="Godot.Control"/>s.</para>
    /// </summary>
    public Vector2 Skew
    {
        get
        {
            return GetSkew();
        }
        set
        {
            SetSkew(value);
        }
    }

    /// <summary>
    /// <para>Border width for the left border.</para>
    /// </summary>
    public int BorderWidthLeft
    {
        get
        {
            return GetBorderWidth((Side)(0));
        }
        set
        {
            SetBorderWidth((Side)(0), value);
        }
    }

    /// <summary>
    /// <para>Border width for the top border.</para>
    /// </summary>
    public int BorderWidthTop
    {
        get
        {
            return GetBorderWidth((Side)(1));
        }
        set
        {
            SetBorderWidth((Side)(1), value);
        }
    }

    /// <summary>
    /// <para>Border width for the right border.</para>
    /// </summary>
    public int BorderWidthRight
    {
        get
        {
            return GetBorderWidth((Side)(2));
        }
        set
        {
            SetBorderWidth((Side)(2), value);
        }
    }

    /// <summary>
    /// <para>Border width for the bottom border.</para>
    /// </summary>
    public int BorderWidthBottom
    {
        get
        {
            return GetBorderWidth((Side)(3));
        }
        set
        {
            SetBorderWidth((Side)(3), value);
        }
    }

    /// <summary>
    /// <para>Sets the color of the border.</para>
    /// </summary>
    public Color BorderColor
    {
        get
        {
            return GetBorderColor();
        }
        set
        {
            SetBorderColor(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the border will fade into the background color.</para>
    /// </summary>
    public bool BorderBlend
    {
        get
        {
            return GetBorderBlend();
        }
        set
        {
            SetBorderBlend(value);
        }
    }

    /// <summary>
    /// <para>The top-left corner's radius. If <c>0</c>, the corner is not rounded.</para>
    /// </summary>
    public int CornerRadiusTopLeft
    {
        get
        {
            return GetCornerRadius((Corner)(0));
        }
        set
        {
            SetCornerRadius((Corner)(0), value);
        }
    }

    /// <summary>
    /// <para>The top-right corner's radius. If <c>0</c>, the corner is not rounded.</para>
    /// </summary>
    public int CornerRadiusTopRight
    {
        get
        {
            return GetCornerRadius((Corner)(1));
        }
        set
        {
            SetCornerRadius((Corner)(1), value);
        }
    }

    /// <summary>
    /// <para>The bottom-right corner's radius. If <c>0</c>, the corner is not rounded.</para>
    /// </summary>
    public int CornerRadiusBottomRight
    {
        get
        {
            return GetCornerRadius((Corner)(2));
        }
        set
        {
            SetCornerRadius((Corner)(2), value);
        }
    }

    /// <summary>
    /// <para>The bottom-left corner's radius. If <c>0</c>, the corner is not rounded.</para>
    /// </summary>
    public int CornerRadiusBottomLeft
    {
        get
        {
            return GetCornerRadius((Corner)(3));
        }
        set
        {
            SetCornerRadius((Corner)(3), value);
        }
    }

    /// <summary>
    /// <para>This sets the number of vertices used for each corner. Higher values result in rounder corners but take more processing power to compute. When choosing a value, you should take the corner radius (<see cref="Godot.StyleBoxFlat.SetCornerRadiusAll(int)"/>) into account.</para>
    /// <para>For corner radii less than 10, <c>4</c> or <c>5</c> should be enough. For corner radii less than 30, values between <c>8</c> and <c>12</c> should be enough.</para>
    /// <para>A corner detail of <c>1</c> will result in chamfered corners instead of rounded corners, which is useful for some artistic effects.</para>
    /// </summary>
    public int CornerDetail
    {
        get
        {
            return GetCornerDetail();
        }
        set
        {
            SetCornerDetail(value);
        }
    }

    /// <summary>
    /// <para>Expands the stylebox outside of the control rect on the left edge. Useful in combination with <see cref="Godot.StyleBoxFlat.BorderWidthLeft"/> to draw a border outside the control rect.</para>
    /// <para><b>Note:</b> Unlike <see cref="Godot.StyleBox.ContentMarginLeft"/>, <see cref="Godot.StyleBoxFlat.ExpandMarginLeft"/> does <i>not</i> affect the size of the clickable area for <see cref="Godot.Control"/>s. This can negatively impact usability if used wrong, as the user may try to click an area of the StyleBox that cannot actually receive clicks.</para>
    /// </summary>
    public float ExpandMarginLeft
    {
        get
        {
            return GetExpandMargin((Side)(0));
        }
        set
        {
            SetExpandMargin((Side)(0), value);
        }
    }

    /// <summary>
    /// <para>Expands the stylebox outside of the control rect on the top edge. Useful in combination with <see cref="Godot.StyleBoxFlat.BorderWidthTop"/> to draw a border outside the control rect.</para>
    /// <para><b>Note:</b> Unlike <see cref="Godot.StyleBox.ContentMarginTop"/>, <see cref="Godot.StyleBoxFlat.ExpandMarginTop"/> does <i>not</i> affect the size of the clickable area for <see cref="Godot.Control"/>s. This can negatively impact usability if used wrong, as the user may try to click an area of the StyleBox that cannot actually receive clicks.</para>
    /// </summary>
    public float ExpandMarginTop
    {
        get
        {
            return GetExpandMargin((Side)(1));
        }
        set
        {
            SetExpandMargin((Side)(1), value);
        }
    }

    /// <summary>
    /// <para>Expands the stylebox outside of the control rect on the right edge. Useful in combination with <see cref="Godot.StyleBoxFlat.BorderWidthRight"/> to draw a border outside the control rect.</para>
    /// <para><b>Note:</b> Unlike <see cref="Godot.StyleBox.ContentMarginRight"/>, <see cref="Godot.StyleBoxFlat.ExpandMarginRight"/> does <i>not</i> affect the size of the clickable area for <see cref="Godot.Control"/>s. This can negatively impact usability if used wrong, as the user may try to click an area of the StyleBox that cannot actually receive clicks.</para>
    /// </summary>
    public float ExpandMarginRight
    {
        get
        {
            return GetExpandMargin((Side)(2));
        }
        set
        {
            SetExpandMargin((Side)(2), value);
        }
    }

    /// <summary>
    /// <para>Expands the stylebox outside of the control rect on the bottom edge. Useful in combination with <see cref="Godot.StyleBoxFlat.BorderWidthBottom"/> to draw a border outside the control rect.</para>
    /// <para><b>Note:</b> Unlike <see cref="Godot.StyleBox.ContentMarginBottom"/>, <see cref="Godot.StyleBoxFlat.ExpandMarginBottom"/> does <i>not</i> affect the size of the clickable area for <see cref="Godot.Control"/>s. This can negatively impact usability if used wrong, as the user may try to click an area of the StyleBox that cannot actually receive clicks.</para>
    /// </summary>
    public float ExpandMarginBottom
    {
        get
        {
            return GetExpandMargin((Side)(3));
        }
        set
        {
            SetExpandMargin((Side)(3), value);
        }
    }

    /// <summary>
    /// <para>The color of the shadow. This has no effect if <see cref="Godot.StyleBoxFlat.ShadowSize"/> is lower than 1.</para>
    /// </summary>
    public Color ShadowColor
    {
        get
        {
            return GetShadowColor();
        }
        set
        {
            SetShadowColor(value);
        }
    }

    /// <summary>
    /// <para>The shadow size in pixels.</para>
    /// </summary>
    public int ShadowSize
    {
        get
        {
            return GetShadowSize();
        }
        set
        {
            SetShadowSize(value);
        }
    }

    /// <summary>
    /// <para>The shadow offset in pixels. Adjusts the position of the shadow relatively to the stylebox.</para>
    /// </summary>
    public Vector2 ShadowOffset
    {
        get
        {
            return GetShadowOffset();
        }
        set
        {
            SetShadowOffset(value);
        }
    }

    /// <summary>
    /// <para>Antialiasing draws a small ring around the edges, which fades to transparency. As a result, edges look much smoother. This is only noticeable when using rounded corners or <see cref="Godot.StyleBoxFlat.Skew"/>.</para>
    /// <para><b>Note:</b> When using beveled corners with 45-degree angles (<see cref="Godot.StyleBoxFlat.CornerDetail"/> = 1), it is recommended to set <see cref="Godot.StyleBoxFlat.AntiAliasing"/> to <see langword="false"/> to ensure crisp visuals and avoid possible visual glitches.</para>
    /// </summary>
    public bool AntiAliasing
    {
        get
        {
            return IsAntiAliased();
        }
        set
        {
            SetAntiAliased(value);
        }
    }

    /// <summary>
    /// <para>This changes the size of the antialiasing effect. <c>1.0</c> is recommended for an optimal result at 100% scale, identical to how rounded rectangles are rendered in web browsers and most vector drawing software.</para>
    /// <para><b>Note:</b> Higher values may produce a blur effect but can also create undesired artifacts on small boxes with large-radius corners.</para>
    /// </summary>
    public float AntiAliasingSize
    {
        get
        {
            return GetAASize();
        }
        set
        {
            SetAASize(value);
        }
    }

    private static readonly System.Type CachedType = typeof(StyleBoxFlat);

    private static readonly StringName NativeName = "StyleBoxFlat";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public StyleBoxFlat() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal StyleBoxFlat(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal StyleBoxFlat(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBgColor, 2920490490ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetBgColor(Color color)
    {
        NativeCalls.godot_icall_1_213(MethodBind0, GodotObject.GetPtr(this), &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBgColor, 3444240500ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Color GetBgColor()
    {
        return NativeCalls.godot_icall_0_214(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBorderColor, 2920490490ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetBorderColor(Color color)
    {
        NativeCalls.godot_icall_1_213(MethodBind2, GodotObject.GetPtr(this), &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBorderColor, 3444240500ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Color GetBorderColor()
    {
        return NativeCalls.godot_icall_0_214(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBorderWidthAll, 1286410249ul);

    /// <summary>
    /// <para>Sets the border width to <paramref name="width"/> pixels for all sides.</para>
    /// </summary>
    public void SetBorderWidthAll(int width)
    {
        NativeCalls.godot_icall_1_38(MethodBind4, GodotObject.GetPtr(this), width);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBorderWidthMin, 3905245786ul);

    /// <summary>
    /// <para>Returns the smallest border width out of all four borders.</para>
    /// </summary>
    public int GetBorderWidthMin()
    {
        return NativeCalls.godot_icall_0_39(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBorderWidth, 437707142ul);

    /// <summary>
    /// <para>Sets the specified <see cref="Godot.Side"/>'s border width to <paramref name="width"/> pixels.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetBorderWidth(Side margin, int width)
    {
        NativeCalls.godot_icall_2_59(MethodBind6, GodotObject.GetPtr(this), (int)margin, width);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBorderWidth, 1983885014ul);

    /// <summary>
    /// <para>Returns the specified <see cref="Godot.Side"/>'s border width.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetBorderWidth(Side margin)
    {
        return NativeCalls.godot_icall_1_60(MethodBind7, GodotObject.GetPtr(this), (int)margin);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBorderBlend, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetBorderBlend(bool blend)
    {
        NativeCalls.godot_icall_1_14(MethodBind8, GodotObject.GetPtr(this), blend.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBorderBlend, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetBorderBlend()
    {
        return NativeCalls.godot_icall_0_15(MethodBind9, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCornerRadiusAll, 1286410249ul);

    /// <summary>
    /// <para>Sets the corner radius to <paramref name="radius"/> pixels for all corners.</para>
    /// </summary>
    public void SetCornerRadiusAll(int radius)
    {
        NativeCalls.godot_icall_1_38(MethodBind10, GodotObject.GetPtr(this), radius);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCornerRadius, 2696158768ul);

    /// <summary>
    /// <para>Sets the corner radius to <paramref name="radius"/> pixels for the given <paramref name="corner"/>.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCornerRadius(Corner corner, int radius)
    {
        NativeCalls.godot_icall_2_59(MethodBind11, GodotObject.GetPtr(this), (int)corner, radius);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCornerRadius, 3982397690ul);

    /// <summary>
    /// <para>Returns the given <paramref name="corner"/>'s radius.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetCornerRadius(Corner corner)
    {
        return NativeCalls.godot_icall_1_60(MethodBind12, GodotObject.GetPtr(this), (int)corner);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetExpandMargin, 4290182280ul);

    /// <summary>
    /// <para>Sets the expand margin to <paramref name="size"/> pixels for the specified <see cref="Godot.Side"/>.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetExpandMargin(Side margin, float size)
    {
        NativeCalls.godot_icall_2_69(MethodBind13, GodotObject.GetPtr(this), (int)margin, size);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetExpandMarginAll, 373806689ul);

    /// <summary>
    /// <para>Sets the expand margin to <paramref name="size"/> pixels for all sides.</para>
    /// </summary>
    public void SetExpandMarginAll(float size)
    {
        NativeCalls.godot_icall_1_67(MethodBind14, GodotObject.GetPtr(this), size);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetExpandMargin, 2869120046ul);

    /// <summary>
    /// <para>Returns the size of the specified <see cref="Godot.Side"/>'s expand margin.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetExpandMargin(Side margin)
    {
        return NativeCalls.godot_icall_1_72(MethodBind15, GodotObject.GetPtr(this), (int)margin);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDrawCenter, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDrawCenter(bool drawCenter)
    {
        NativeCalls.godot_icall_1_14(MethodBind16, GodotObject.GetPtr(this), drawCenter.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsDrawCenterEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsDrawCenterEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind17, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSkew, 743155724ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetSkew(Vector2 skew)
    {
        NativeCalls.godot_icall_1_36(MethodBind18, GodotObject.GetPtr(this), &skew);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSkew, 3341600327ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2 GetSkew()
    {
        return NativeCalls.godot_icall_0_37(MethodBind19, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetShadowColor, 2920490490ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetShadowColor(Color color)
    {
        NativeCalls.godot_icall_1_213(MethodBind20, GodotObject.GetPtr(this), &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetShadowColor, 3444240500ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Color GetShadowColor()
    {
        return NativeCalls.godot_icall_0_214(MethodBind21, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetShadowSize, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetShadowSize(int size)
    {
        NativeCalls.godot_icall_1_38(MethodBind22, GodotObject.GetPtr(this), size);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetShadowSize, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetShadowSize()
    {
        return NativeCalls.godot_icall_0_39(MethodBind23, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetShadowOffset, 743155724ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetShadowOffset(Vector2 offset)
    {
        NativeCalls.godot_icall_1_36(MethodBind24, GodotObject.GetPtr(this), &offset);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetShadowOffset, 3341600327ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2 GetShadowOffset()
    {
        return NativeCalls.godot_icall_0_37(MethodBind25, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAntiAliased, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAntiAliased(bool antiAliased)
    {
        NativeCalls.godot_icall_1_14(MethodBind26, GodotObject.GetPtr(this), antiAliased.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsAntiAliased, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsAntiAliased()
    {
        return NativeCalls.godot_icall_0_15(MethodBind27, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAASize, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAASize(float size)
    {
        NativeCalls.godot_icall_1_67(MethodBind28, GodotObject.GetPtr(this), size);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAASize, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetAASize()
    {
        return NativeCalls.godot_icall_0_68(MethodBind29, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCornerDetail, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCornerDetail(int detail)
    {
        NativeCalls.godot_icall_1_38(MethodBind30, GodotObject.GetPtr(this), detail);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCornerDetail, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetCornerDetail()
    {
        return NativeCalls.godot_icall_0_39(MethodBind31, GodotObject.GetPtr(this));
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
    public new class PropertyName : StyleBox.PropertyName
    {
        /// <summary>
        /// Cached name for the 'bg_color' property.
        /// </summary>
        public static readonly StringName BgColor = "bg_color";
        /// <summary>
        /// Cached name for the 'draw_center' property.
        /// </summary>
        public static readonly StringName DrawCenter = "draw_center";
        /// <summary>
        /// Cached name for the 'skew' property.
        /// </summary>
        public static readonly StringName Skew = "skew";
        /// <summary>
        /// Cached name for the 'border_width_left' property.
        /// </summary>
        public static readonly StringName BorderWidthLeft = "border_width_left";
        /// <summary>
        /// Cached name for the 'border_width_top' property.
        /// </summary>
        public static readonly StringName BorderWidthTop = "border_width_top";
        /// <summary>
        /// Cached name for the 'border_width_right' property.
        /// </summary>
        public static readonly StringName BorderWidthRight = "border_width_right";
        /// <summary>
        /// Cached name for the 'border_width_bottom' property.
        /// </summary>
        public static readonly StringName BorderWidthBottom = "border_width_bottom";
        /// <summary>
        /// Cached name for the 'border_color' property.
        /// </summary>
        public static readonly StringName BorderColor = "border_color";
        /// <summary>
        /// Cached name for the 'border_blend' property.
        /// </summary>
        public static readonly StringName BorderBlend = "border_blend";
        /// <summary>
        /// Cached name for the 'corner_radius_top_left' property.
        /// </summary>
        public static readonly StringName CornerRadiusTopLeft = "corner_radius_top_left";
        /// <summary>
        /// Cached name for the 'corner_radius_top_right' property.
        /// </summary>
        public static readonly StringName CornerRadiusTopRight = "corner_radius_top_right";
        /// <summary>
        /// Cached name for the 'corner_radius_bottom_right' property.
        /// </summary>
        public static readonly StringName CornerRadiusBottomRight = "corner_radius_bottom_right";
        /// <summary>
        /// Cached name for the 'corner_radius_bottom_left' property.
        /// </summary>
        public static readonly StringName CornerRadiusBottomLeft = "corner_radius_bottom_left";
        /// <summary>
        /// Cached name for the 'corner_detail' property.
        /// </summary>
        public static readonly StringName CornerDetail = "corner_detail";
        /// <summary>
        /// Cached name for the 'expand_margin_left' property.
        /// </summary>
        public static readonly StringName ExpandMarginLeft = "expand_margin_left";
        /// <summary>
        /// Cached name for the 'expand_margin_top' property.
        /// </summary>
        public static readonly StringName ExpandMarginTop = "expand_margin_top";
        /// <summary>
        /// Cached name for the 'expand_margin_right' property.
        /// </summary>
        public static readonly StringName ExpandMarginRight = "expand_margin_right";
        /// <summary>
        /// Cached name for the 'expand_margin_bottom' property.
        /// </summary>
        public static readonly StringName ExpandMarginBottom = "expand_margin_bottom";
        /// <summary>
        /// Cached name for the 'shadow_color' property.
        /// </summary>
        public static readonly StringName ShadowColor = "shadow_color";
        /// <summary>
        /// Cached name for the 'shadow_size' property.
        /// </summary>
        public static readonly StringName ShadowSize = "shadow_size";
        /// <summary>
        /// Cached name for the 'shadow_offset' property.
        /// </summary>
        public static readonly StringName ShadowOffset = "shadow_offset";
        /// <summary>
        /// Cached name for the 'anti_aliasing' property.
        /// </summary>
        public static readonly StringName AntiAliasing = "anti_aliasing";
        /// <summary>
        /// Cached name for the 'anti_aliasing_size' property.
        /// </summary>
        public static readonly StringName AntiAliasingSize = "anti_aliasing_size";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : StyleBox.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_bg_color' method.
        /// </summary>
        public static readonly StringName SetBgColor = "set_bg_color";
        /// <summary>
        /// Cached name for the 'get_bg_color' method.
        /// </summary>
        public static readonly StringName GetBgColor = "get_bg_color";
        /// <summary>
        /// Cached name for the 'set_border_color' method.
        /// </summary>
        public static readonly StringName SetBorderColor = "set_border_color";
        /// <summary>
        /// Cached name for the 'get_border_color' method.
        /// </summary>
        public static readonly StringName GetBorderColor = "get_border_color";
        /// <summary>
        /// Cached name for the 'set_border_width_all' method.
        /// </summary>
        public static readonly StringName SetBorderWidthAll = "set_border_width_all";
        /// <summary>
        /// Cached name for the 'get_border_width_min' method.
        /// </summary>
        public static readonly StringName GetBorderWidthMin = "get_border_width_min";
        /// <summary>
        /// Cached name for the 'set_border_width' method.
        /// </summary>
        public static readonly StringName SetBorderWidth = "set_border_width";
        /// <summary>
        /// Cached name for the 'get_border_width' method.
        /// </summary>
        public static readonly StringName GetBorderWidth = "get_border_width";
        /// <summary>
        /// Cached name for the 'set_border_blend' method.
        /// </summary>
        public static readonly StringName SetBorderBlend = "set_border_blend";
        /// <summary>
        /// Cached name for the 'get_border_blend' method.
        /// </summary>
        public static readonly StringName GetBorderBlend = "get_border_blend";
        /// <summary>
        /// Cached name for the 'set_corner_radius_all' method.
        /// </summary>
        public static readonly StringName SetCornerRadiusAll = "set_corner_radius_all";
        /// <summary>
        /// Cached name for the 'set_corner_radius' method.
        /// </summary>
        public static readonly StringName SetCornerRadius = "set_corner_radius";
        /// <summary>
        /// Cached name for the 'get_corner_radius' method.
        /// </summary>
        public static readonly StringName GetCornerRadius = "get_corner_radius";
        /// <summary>
        /// Cached name for the 'set_expand_margin' method.
        /// </summary>
        public static readonly StringName SetExpandMargin = "set_expand_margin";
        /// <summary>
        /// Cached name for the 'set_expand_margin_all' method.
        /// </summary>
        public static readonly StringName SetExpandMarginAll = "set_expand_margin_all";
        /// <summary>
        /// Cached name for the 'get_expand_margin' method.
        /// </summary>
        public static readonly StringName GetExpandMargin = "get_expand_margin";
        /// <summary>
        /// Cached name for the 'set_draw_center' method.
        /// </summary>
        public static readonly StringName SetDrawCenter = "set_draw_center";
        /// <summary>
        /// Cached name for the 'is_draw_center_enabled' method.
        /// </summary>
        public static readonly StringName IsDrawCenterEnabled = "is_draw_center_enabled";
        /// <summary>
        /// Cached name for the 'set_skew' method.
        /// </summary>
        public static readonly StringName SetSkew = "set_skew";
        /// <summary>
        /// Cached name for the 'get_skew' method.
        /// </summary>
        public static readonly StringName GetSkew = "get_skew";
        /// <summary>
        /// Cached name for the 'set_shadow_color' method.
        /// </summary>
        public static readonly StringName SetShadowColor = "set_shadow_color";
        /// <summary>
        /// Cached name for the 'get_shadow_color' method.
        /// </summary>
        public static readonly StringName GetShadowColor = "get_shadow_color";
        /// <summary>
        /// Cached name for the 'set_shadow_size' method.
        /// </summary>
        public static readonly StringName SetShadowSize = "set_shadow_size";
        /// <summary>
        /// Cached name for the 'get_shadow_size' method.
        /// </summary>
        public static readonly StringName GetShadowSize = "get_shadow_size";
        /// <summary>
        /// Cached name for the 'set_shadow_offset' method.
        /// </summary>
        public static readonly StringName SetShadowOffset = "set_shadow_offset";
        /// <summary>
        /// Cached name for the 'get_shadow_offset' method.
        /// </summary>
        public static readonly StringName GetShadowOffset = "get_shadow_offset";
        /// <summary>
        /// Cached name for the 'set_anti_aliased' method.
        /// </summary>
        public static readonly StringName SetAntiAliased = "set_anti_aliased";
        /// <summary>
        /// Cached name for the 'is_anti_aliased' method.
        /// </summary>
        public static readonly StringName IsAntiAliased = "is_anti_aliased";
        /// <summary>
        /// Cached name for the 'set_aa_size' method.
        /// </summary>
        public static readonly StringName SetAASize = "set_aa_size";
        /// <summary>
        /// Cached name for the 'get_aa_size' method.
        /// </summary>
        public static readonly StringName GetAASize = "get_aa_size";
        /// <summary>
        /// Cached name for the 'set_corner_detail' method.
        /// </summary>
        public static readonly StringName SetCornerDetail = "set_corner_detail";
        /// <summary>
        /// Cached name for the 'get_corner_detail' method.
        /// </summary>
        public static readonly StringName GetCornerDetail = "get_corner_detail";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : StyleBox.SignalName
    {
    }
}
