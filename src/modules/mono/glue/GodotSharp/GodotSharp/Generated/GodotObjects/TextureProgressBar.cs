namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>TextureProgressBar works like <see cref="Godot.ProgressBar"/>, but uses up to 3 textures instead of Godot's <see cref="Godot.Theme"/> resource. It can be used to create horizontal, vertical and radial progress bars.</para>
/// </summary>
public partial class TextureProgressBar : Range
{
    public enum FillModeEnum : long
    {
        /// <summary>
        /// <para>The <see cref="Godot.TextureProgressBar.TextureProgress"/> fills from left to right.</para>
        /// </summary>
        LeftToRight = 0,
        /// <summary>
        /// <para>The <see cref="Godot.TextureProgressBar.TextureProgress"/> fills from right to left.</para>
        /// </summary>
        RightToLeft = 1,
        /// <summary>
        /// <para>The <see cref="Godot.TextureProgressBar.TextureProgress"/> fills from top to bottom.</para>
        /// </summary>
        TopToBottom = 2,
        /// <summary>
        /// <para>The <see cref="Godot.TextureProgressBar.TextureProgress"/> fills from bottom to top.</para>
        /// </summary>
        BottomToTop = 3,
        /// <summary>
        /// <para>Turns the node into a radial bar. The <see cref="Godot.TextureProgressBar.TextureProgress"/> fills clockwise. See <see cref="Godot.TextureProgressBar.RadialCenterOffset"/>, <see cref="Godot.TextureProgressBar.RadialInitialAngle"/> and <see cref="Godot.TextureProgressBar.RadialFillDegrees"/> to control the way the bar fills up.</para>
        /// </summary>
        Clockwise = 4,
        /// <summary>
        /// <para>Turns the node into a radial bar. The <see cref="Godot.TextureProgressBar.TextureProgress"/> fills counterclockwise. See <see cref="Godot.TextureProgressBar.RadialCenterOffset"/>, <see cref="Godot.TextureProgressBar.RadialInitialAngle"/> and <see cref="Godot.TextureProgressBar.RadialFillDegrees"/> to control the way the bar fills up.</para>
        /// </summary>
        CounterClockwise = 5,
        /// <summary>
        /// <para>The <see cref="Godot.TextureProgressBar.TextureProgress"/> fills from the center, expanding both towards the left and the right.</para>
        /// </summary>
        BilinearLeftAndRight = 6,
        /// <summary>
        /// <para>The <see cref="Godot.TextureProgressBar.TextureProgress"/> fills from the center, expanding both towards the top and the bottom.</para>
        /// </summary>
        BilinearTopAndBottom = 7,
        /// <summary>
        /// <para>Turns the node into a radial bar. The <see cref="Godot.TextureProgressBar.TextureProgress"/> fills radially from the center, expanding both clockwise and counterclockwise. See <see cref="Godot.TextureProgressBar.RadialCenterOffset"/>, <see cref="Godot.TextureProgressBar.RadialInitialAngle"/> and <see cref="Godot.TextureProgressBar.RadialFillDegrees"/> to control the way the bar fills up.</para>
        /// </summary>
        ClockwiseAndCounterClockwise = 8
    }

    /// <summary>
    /// <para>The fill direction. See <see cref="Godot.TextureProgressBar.FillModeEnum"/> for possible values.</para>
    /// </summary>
    public int FillMode
    {
        get
        {
            return GetFillMode();
        }
        set
        {
            SetFillMode(value);
        }
    }

    /// <summary>
    /// <para>Starting angle for the fill of <see cref="Godot.TextureProgressBar.TextureProgress"/> if <see cref="Godot.TextureProgressBar.FillMode"/> is <see cref="Godot.TextureProgressBar.FillModeEnum.Clockwise"/>, <see cref="Godot.TextureProgressBar.FillModeEnum.CounterClockwise"/>, or <see cref="Godot.TextureProgressBar.FillModeEnum.ClockwiseAndCounterClockwise"/>. When the node's <c>value</c> is equal to its <c>min_value</c>, the texture doesn't show up at all. When the <c>value</c> increases, the texture fills and tends towards <see cref="Godot.TextureProgressBar.RadialFillDegrees"/>.</para>
    /// <para><b>Note:</b> <see cref="Godot.TextureProgressBar.RadialInitialAngle"/> is wrapped between <c>0</c> and <c>360</c> degrees (inclusive).</para>
    /// </summary>
    public float RadialInitialAngle
    {
        get
        {
            return GetRadialInitialAngle();
        }
        set
        {
            SetRadialInitialAngle(value);
        }
    }

    /// <summary>
    /// <para>Upper limit for the fill of <see cref="Godot.TextureProgressBar.TextureProgress"/> if <see cref="Godot.TextureProgressBar.FillMode"/> is <see cref="Godot.TextureProgressBar.FillModeEnum.Clockwise"/>, <see cref="Godot.TextureProgressBar.FillModeEnum.CounterClockwise"/>, or <see cref="Godot.TextureProgressBar.FillModeEnum.ClockwiseAndCounterClockwise"/>. When the node's <c>value</c> is equal to its <c>max_value</c>, the texture fills up to this angle.</para>
    /// <para>See <see cref="Godot.Range.Value"/>, <see cref="Godot.Range.MaxValue"/>.</para>
    /// </summary>
    public float RadialFillDegrees
    {
        get
        {
            return GetFillDegrees();
        }
        set
        {
            SetFillDegrees(value);
        }
    }

    /// <summary>
    /// <para>Offsets <see cref="Godot.TextureProgressBar.TextureProgress"/> if <see cref="Godot.TextureProgressBar.FillMode"/> is <see cref="Godot.TextureProgressBar.FillModeEnum.Clockwise"/>, <see cref="Godot.TextureProgressBar.FillModeEnum.CounterClockwise"/>, or <see cref="Godot.TextureProgressBar.FillModeEnum.ClockwiseAndCounterClockwise"/>.</para>
    /// <para><b>Note:</b> The effective radial center always stays within the <see cref="Godot.TextureProgressBar.TextureProgress"/> bounds. If you need to move it outside the texture's bounds, modify the <see cref="Godot.TextureProgressBar.TextureProgress"/> to contain additional empty space where needed.</para>
    /// </summary>
    public Vector2 RadialCenterOffset
    {
        get
        {
            return GetRadialCenterOffset();
        }
        set
        {
            SetRadialCenterOffset(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, Godot treats the bar's textures like in <see cref="Godot.NinePatchRect"/>. Use the <c>stretch_margin_*</c> properties like <see cref="Godot.TextureProgressBar.StretchMarginBottom"/> to set up the nine patch's 3×3 grid. When using a radial <see cref="Godot.TextureProgressBar.FillMode"/>, this setting will only enable stretching for <see cref="Godot.TextureProgressBar.TextureProgress"/>, while <see cref="Godot.TextureProgressBar.TextureUnder"/> and <see cref="Godot.TextureProgressBar.TextureOver"/> will be treated like in <see cref="Godot.NinePatchRect"/>.</para>
    /// </summary>
    public bool NinePatchStretch
    {
        get
        {
            return GetNinePatchStretch();
        }
        set
        {
            SetNinePatchStretch(value);
        }
    }

    /// <summary>
    /// <para>The width of the 9-patch's left column. Only effective if <see cref="Godot.TextureProgressBar.NinePatchStretch"/> is <see langword="true"/>.</para>
    /// </summary>
    public int StretchMarginLeft
    {
        get
        {
            return GetStretchMargin((Side)(0));
        }
        set
        {
            SetStretchMargin((Side)(0), value);
        }
    }

    /// <summary>
    /// <para>The height of the 9-patch's top row. Only effective if <see cref="Godot.TextureProgressBar.NinePatchStretch"/> is <see langword="true"/>.</para>
    /// </summary>
    public int StretchMarginTop
    {
        get
        {
            return GetStretchMargin((Side)(1));
        }
        set
        {
            SetStretchMargin((Side)(1), value);
        }
    }

    /// <summary>
    /// <para>The width of the 9-patch's right column. Only effective if <see cref="Godot.TextureProgressBar.NinePatchStretch"/> is <see langword="true"/>.</para>
    /// </summary>
    public int StretchMarginRight
    {
        get
        {
            return GetStretchMargin((Side)(2));
        }
        set
        {
            SetStretchMargin((Side)(2), value);
        }
    }

    /// <summary>
    /// <para>The height of the 9-patch's bottom row. A margin of 16 means the 9-slice's bottom corners and side will have a height of 16 pixels. You can set all 4 margin values individually to create panels with non-uniform borders. Only effective if <see cref="Godot.TextureProgressBar.NinePatchStretch"/> is <see langword="true"/>.</para>
    /// </summary>
    public int StretchMarginBottom
    {
        get
        {
            return GetStretchMargin((Side)(3));
        }
        set
        {
            SetStretchMargin((Side)(3), value);
        }
    }

    /// <summary>
    /// <para><see cref="Godot.Texture2D"/> that draws under the progress bar. The bar's background.</para>
    /// </summary>
    public Texture2D TextureUnder
    {
        get
        {
            return GetUnderTexture();
        }
        set
        {
            SetUnderTexture(value);
        }
    }

    /// <summary>
    /// <para><see cref="Godot.Texture2D"/> that draws over the progress bar. Use it to add highlights or an upper-frame that hides part of <see cref="Godot.TextureProgressBar.TextureProgress"/>.</para>
    /// </summary>
    public Texture2D TextureOver
    {
        get
        {
            return GetOverTexture();
        }
        set
        {
            SetOverTexture(value);
        }
    }

    /// <summary>
    /// <para><see cref="Godot.Texture2D"/> that clips based on the node's <c>value</c> and <see cref="Godot.TextureProgressBar.FillMode"/>. As <c>value</c> increased, the texture fills up. It shows entirely when <c>value</c> reaches <c>max_value</c>. It doesn't show at all if <c>value</c> is equal to <c>min_value</c>.</para>
    /// <para>The <c>value</c> property comes from <see cref="Godot.Range"/>. See <see cref="Godot.Range.Value"/>, <see cref="Godot.Range.MinValue"/>, <see cref="Godot.Range.MaxValue"/>.</para>
    /// </summary>
    public Texture2D TextureProgress
    {
        get
        {
            return GetProgressTexture();
        }
        set
        {
            SetProgressTexture(value);
        }
    }

    /// <summary>
    /// <para>The offset of <see cref="Godot.TextureProgressBar.TextureProgress"/>. Useful for <see cref="Godot.TextureProgressBar.TextureOver"/> and <see cref="Godot.TextureProgressBar.TextureUnder"/> with fancy borders, to avoid transparent margins in your progress texture.</para>
    /// </summary>
    public Vector2 TextureProgressOffset
    {
        get
        {
            return GetTextureProgressOffset();
        }
        set
        {
            SetTextureProgressOffset(value);
        }
    }

    /// <summary>
    /// <para>Multiplies the color of the bar's <see cref="Godot.TextureProgressBar.TextureUnder"/> texture.</para>
    /// </summary>
    public Color TintUnder
    {
        get
        {
            return GetTintUnder();
        }
        set
        {
            SetTintUnder(value);
        }
    }

    /// <summary>
    /// <para>Multiplies the color of the bar's <see cref="Godot.TextureProgressBar.TextureOver"/> texture. The effect is similar to <see cref="Godot.CanvasItem.Modulate"/>, except it only affects this specific texture instead of the entire node.</para>
    /// </summary>
    public Color TintOver
    {
        get
        {
            return GetTintOver();
        }
        set
        {
            SetTintOver(value);
        }
    }

    /// <summary>
    /// <para>Multiplies the color of the bar's <see cref="Godot.TextureProgressBar.TextureProgress"/> texture.</para>
    /// </summary>
    public Color TintProgress
    {
        get
        {
            return GetTintProgress();
        }
        set
        {
            SetTintProgress(value);
        }
    }

    private static readonly System.Type CachedType = typeof(TextureProgressBar);

    private static readonly StringName NativeName = "TextureProgressBar";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public TextureProgressBar() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal TextureProgressBar(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal TextureProgressBar(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetUnderTexture, 4051416890ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetUnderTexture(Texture2D tex)
    {
        NativeCalls.godot_icall_1_56(MethodBind0, GodotObject.GetPtr(this), GodotObject.GetPtr(tex));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetUnderTexture, 3635182373ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Texture2D GetUnderTexture()
    {
        return (Texture2D)NativeCalls.godot_icall_0_63(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetProgressTexture, 4051416890ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetProgressTexture(Texture2D tex)
    {
        NativeCalls.godot_icall_1_56(MethodBind2, GodotObject.GetPtr(this), GodotObject.GetPtr(tex));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetProgressTexture, 3635182373ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Texture2D GetProgressTexture()
    {
        return (Texture2D)NativeCalls.godot_icall_0_63(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetOverTexture, 4051416890ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetOverTexture(Texture2D tex)
    {
        NativeCalls.godot_icall_1_56(MethodBind4, GodotObject.GetPtr(this), GodotObject.GetPtr(tex));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOverTexture, 3635182373ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Texture2D GetOverTexture()
    {
        return (Texture2D)NativeCalls.godot_icall_0_63(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFillMode, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFillMode(int mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind6, GodotObject.GetPtr(this), mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFillMode, 2455072627ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetFillMode()
    {
        return NativeCalls.godot_icall_0_39(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTintUnder, 2920490490ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetTintUnder(Color tint)
    {
        NativeCalls.godot_icall_1_213(MethodBind8, GodotObject.GetPtr(this), &tint);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTintUnder, 3444240500ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Color GetTintUnder()
    {
        return NativeCalls.godot_icall_0_214(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTintProgress, 2920490490ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetTintProgress(Color tint)
    {
        NativeCalls.godot_icall_1_213(MethodBind10, GodotObject.GetPtr(this), &tint);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTintProgress, 3444240500ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Color GetTintProgress()
    {
        return NativeCalls.godot_icall_0_214(MethodBind11, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTintOver, 2920490490ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetTintOver(Color tint)
    {
        NativeCalls.godot_icall_1_213(MethodBind12, GodotObject.GetPtr(this), &tint);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTintOver, 3444240500ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Color GetTintOver()
    {
        return NativeCalls.godot_icall_0_214(MethodBind13, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTextureProgressOffset, 743155724ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetTextureProgressOffset(Vector2 offset)
    {
        NativeCalls.godot_icall_1_36(MethodBind14, GodotObject.GetPtr(this), &offset);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTextureProgressOffset, 3341600327ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2 GetTextureProgressOffset()
    {
        return NativeCalls.godot_icall_0_37(MethodBind15, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRadialInitialAngle, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetRadialInitialAngle(float mode)
    {
        NativeCalls.godot_icall_1_67(MethodBind16, GodotObject.GetPtr(this), mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRadialInitialAngle, 191475506ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetRadialInitialAngle()
    {
        return NativeCalls.godot_icall_0_68(MethodBind17, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRadialCenterOffset, 743155724ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetRadialCenterOffset(Vector2 mode)
    {
        NativeCalls.godot_icall_1_36(MethodBind18, GodotObject.GetPtr(this), &mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRadialCenterOffset, 1497962370ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2 GetRadialCenterOffset()
    {
        return NativeCalls.godot_icall_0_37(MethodBind19, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFillDegrees, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFillDegrees(float mode)
    {
        NativeCalls.godot_icall_1_67(MethodBind20, GodotObject.GetPtr(this), mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFillDegrees, 191475506ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetFillDegrees()
    {
        return NativeCalls.godot_icall_0_68(MethodBind21, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetStretchMargin, 437707142ul);

    /// <summary>
    /// <para>Sets the stretch margin with the specified index. See <see cref="Godot.TextureProgressBar.StretchMarginBottom"/> and related properties.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetStretchMargin(Side margin, int value)
    {
        NativeCalls.godot_icall_2_59(MethodBind22, GodotObject.GetPtr(this), (int)margin, value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetStretchMargin, 1983885014ul);

    /// <summary>
    /// <para>Returns the stretch margin with the specified index. See <see cref="Godot.TextureProgressBar.StretchMarginBottom"/> and related properties.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetStretchMargin(Side margin)
    {
        return NativeCalls.godot_icall_1_60(MethodBind23, GodotObject.GetPtr(this), (int)margin);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetNinePatchStretch, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetNinePatchStretch(bool stretch)
    {
        NativeCalls.godot_icall_1_14(MethodBind24, GodotObject.GetPtr(this), stretch.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNinePatchStretch, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetNinePatchStretch()
    {
        return NativeCalls.godot_icall_0_15(MethodBind25, GodotObject.GetPtr(this)).ToBool();
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
    public new class PropertyName : Range.PropertyName
    {
        /// <summary>
        /// Cached name for the 'fill_mode' property.
        /// </summary>
        public static readonly StringName FillMode = "fill_mode";
        /// <summary>
        /// Cached name for the 'radial_initial_angle' property.
        /// </summary>
        public static readonly StringName RadialInitialAngle = "radial_initial_angle";
        /// <summary>
        /// Cached name for the 'radial_fill_degrees' property.
        /// </summary>
        public static readonly StringName RadialFillDegrees = "radial_fill_degrees";
        /// <summary>
        /// Cached name for the 'radial_center_offset' property.
        /// </summary>
        public static readonly StringName RadialCenterOffset = "radial_center_offset";
        /// <summary>
        /// Cached name for the 'nine_patch_stretch' property.
        /// </summary>
        public static readonly StringName NinePatchStretch = "nine_patch_stretch";
        /// <summary>
        /// Cached name for the 'stretch_margin_left' property.
        /// </summary>
        public static readonly StringName StretchMarginLeft = "stretch_margin_left";
        /// <summary>
        /// Cached name for the 'stretch_margin_top' property.
        /// </summary>
        public static readonly StringName StretchMarginTop = "stretch_margin_top";
        /// <summary>
        /// Cached name for the 'stretch_margin_right' property.
        /// </summary>
        public static readonly StringName StretchMarginRight = "stretch_margin_right";
        /// <summary>
        /// Cached name for the 'stretch_margin_bottom' property.
        /// </summary>
        public static readonly StringName StretchMarginBottom = "stretch_margin_bottom";
        /// <summary>
        /// Cached name for the 'texture_under' property.
        /// </summary>
        public static readonly StringName TextureUnder = "texture_under";
        /// <summary>
        /// Cached name for the 'texture_over' property.
        /// </summary>
        public static readonly StringName TextureOver = "texture_over";
        /// <summary>
        /// Cached name for the 'texture_progress' property.
        /// </summary>
        public static readonly StringName TextureProgress = "texture_progress";
        /// <summary>
        /// Cached name for the 'texture_progress_offset' property.
        /// </summary>
        public static readonly StringName TextureProgressOffset = "texture_progress_offset";
        /// <summary>
        /// Cached name for the 'tint_under' property.
        /// </summary>
        public static readonly StringName TintUnder = "tint_under";
        /// <summary>
        /// Cached name for the 'tint_over' property.
        /// </summary>
        public static readonly StringName TintOver = "tint_over";
        /// <summary>
        /// Cached name for the 'tint_progress' property.
        /// </summary>
        public static readonly StringName TintProgress = "tint_progress";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Range.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_under_texture' method.
        /// </summary>
        public static readonly StringName SetUnderTexture = "set_under_texture";
        /// <summary>
        /// Cached name for the 'get_under_texture' method.
        /// </summary>
        public static readonly StringName GetUnderTexture = "get_under_texture";
        /// <summary>
        /// Cached name for the 'set_progress_texture' method.
        /// </summary>
        public static readonly StringName SetProgressTexture = "set_progress_texture";
        /// <summary>
        /// Cached name for the 'get_progress_texture' method.
        /// </summary>
        public static readonly StringName GetProgressTexture = "get_progress_texture";
        /// <summary>
        /// Cached name for the 'set_over_texture' method.
        /// </summary>
        public static readonly StringName SetOverTexture = "set_over_texture";
        /// <summary>
        /// Cached name for the 'get_over_texture' method.
        /// </summary>
        public static readonly StringName GetOverTexture = "get_over_texture";
        /// <summary>
        /// Cached name for the 'set_fill_mode' method.
        /// </summary>
        public static readonly StringName SetFillMode = "set_fill_mode";
        /// <summary>
        /// Cached name for the 'get_fill_mode' method.
        /// </summary>
        public static readonly StringName GetFillMode = "get_fill_mode";
        /// <summary>
        /// Cached name for the 'set_tint_under' method.
        /// </summary>
        public static readonly StringName SetTintUnder = "set_tint_under";
        /// <summary>
        /// Cached name for the 'get_tint_under' method.
        /// </summary>
        public static readonly StringName GetTintUnder = "get_tint_under";
        /// <summary>
        /// Cached name for the 'set_tint_progress' method.
        /// </summary>
        public static readonly StringName SetTintProgress = "set_tint_progress";
        /// <summary>
        /// Cached name for the 'get_tint_progress' method.
        /// </summary>
        public static readonly StringName GetTintProgress = "get_tint_progress";
        /// <summary>
        /// Cached name for the 'set_tint_over' method.
        /// </summary>
        public static readonly StringName SetTintOver = "set_tint_over";
        /// <summary>
        /// Cached name for the 'get_tint_over' method.
        /// </summary>
        public static readonly StringName GetTintOver = "get_tint_over";
        /// <summary>
        /// Cached name for the 'set_texture_progress_offset' method.
        /// </summary>
        public static readonly StringName SetTextureProgressOffset = "set_texture_progress_offset";
        /// <summary>
        /// Cached name for the 'get_texture_progress_offset' method.
        /// </summary>
        public static readonly StringName GetTextureProgressOffset = "get_texture_progress_offset";
        /// <summary>
        /// Cached name for the 'set_radial_initial_angle' method.
        /// </summary>
        public static readonly StringName SetRadialInitialAngle = "set_radial_initial_angle";
        /// <summary>
        /// Cached name for the 'get_radial_initial_angle' method.
        /// </summary>
        public static readonly StringName GetRadialInitialAngle = "get_radial_initial_angle";
        /// <summary>
        /// Cached name for the 'set_radial_center_offset' method.
        /// </summary>
        public static readonly StringName SetRadialCenterOffset = "set_radial_center_offset";
        /// <summary>
        /// Cached name for the 'get_radial_center_offset' method.
        /// </summary>
        public static readonly StringName GetRadialCenterOffset = "get_radial_center_offset";
        /// <summary>
        /// Cached name for the 'set_fill_degrees' method.
        /// </summary>
        public static readonly StringName SetFillDegrees = "set_fill_degrees";
        /// <summary>
        /// Cached name for the 'get_fill_degrees' method.
        /// </summary>
        public static readonly StringName GetFillDegrees = "get_fill_degrees";
        /// <summary>
        /// Cached name for the 'set_stretch_margin' method.
        /// </summary>
        public static readonly StringName SetStretchMargin = "set_stretch_margin";
        /// <summary>
        /// Cached name for the 'get_stretch_margin' method.
        /// </summary>
        public static readonly StringName GetStretchMargin = "get_stretch_margin";
        /// <summary>
        /// Cached name for the 'set_nine_patch_stretch' method.
        /// </summary>
        public static readonly StringName SetNinePatchStretch = "set_nine_patch_stretch";
        /// <summary>
        /// Cached name for the 'get_nine_patch_stretch' method.
        /// </summary>
        public static readonly StringName GetNinePatchStretch = "get_nine_patch_stretch";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Range.SignalName
    {
    }
}
