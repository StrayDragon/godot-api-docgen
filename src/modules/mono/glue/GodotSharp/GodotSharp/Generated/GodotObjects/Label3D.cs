namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A node for displaying plain text in 3D space. By adjusting various properties of this node, you can configure things such as the text's appearance and whether it always faces the camera.</para>
/// </summary>
public partial class Label3D : GeometryInstance3D
{
    public enum DrawFlags : long
    {
        /// <summary>
        /// <para>If set, lights in the environment affect the label.</para>
        /// </summary>
        Shaded = 0,
        /// <summary>
        /// <para>If set, text can be seen from the back as well. If not, the text is invisible when looking at it from behind.</para>
        /// </summary>
        DoubleSided = 1,
        /// <summary>
        /// <para>Disables the depth test, so this object is drawn on top of all others. However, objects drawn after it in the draw order may cover it.</para>
        /// </summary>
        DisableDepthTest = 2,
        /// <summary>
        /// <para>Label is scaled by depth so that it always appears the same size on screen.</para>
        /// </summary>
        FixedSize = 3,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.Label3D.DrawFlags"/> enum.</para>
        /// </summary>
        Max = 4
    }

    public enum AlphaCutMode : long
    {
        /// <summary>
        /// <para>This mode performs standard alpha blending. It can display translucent areas, but transparency sorting issues may be visible when multiple transparent materials are overlapping. <see cref="Godot.GeometryInstance3D.CastShadow"/> has no effect when this transparency mode is used; the <see cref="Godot.Label3D"/> will never cast shadows.</para>
        /// </summary>
        Disabled = 0,
        /// <summary>
        /// <para>This mode only allows fully transparent or fully opaque pixels. Harsh edges will be visible unless some form of screen-space antialiasing is enabled (see <c>ProjectSettings.rendering/anti_aliasing/quality/screen_space_aa</c>). This mode is also known as <i>alpha testing</i> or <i>1-bit transparency</i>.</para>
        /// <para><b>Note:</b> This mode might have issues with anti-aliased fonts and outlines, try adjusting <see cref="Godot.Label3D.AlphaScissorThreshold"/> or using MSDF font.</para>
        /// <para><b>Note:</b> When using text with overlapping glyphs (e.g., cursive scripts), this mode might have transparency sorting issues between the main text and the outline.</para>
        /// </summary>
        Discard = 1,
        /// <summary>
        /// <para>This mode draws fully opaque pixels in the depth prepass. This is slower than <see cref="Godot.Label3D.AlphaCutMode.Disabled"/> or <see cref="Godot.Label3D.AlphaCutMode.Discard"/>, but it allows displaying translucent areas and smooth edges while using proper sorting.</para>
        /// <para><b>Note:</b> When using text with overlapping glyphs (e.g., cursive scripts), this mode might have transparency sorting issues between the main text and the outline.</para>
        /// </summary>
        OpaquePrepass = 2,
        /// <summary>
        /// <para>This mode draws cuts off all values below a spatially-deterministic threshold, the rest will remain opaque.</para>
        /// </summary>
        Hash = 3
    }

    /// <summary>
    /// <para>The size of one pixel's width on the label to scale it in 3D. To make the font look more detailed when up close, increase <see cref="Godot.Label3D.FontSize"/> while decreasing <see cref="Godot.Label3D.PixelSize"/> at the same time.</para>
    /// </summary>
    public float PixelSize
    {
        get
        {
            return GetPixelSize();
        }
        set
        {
            SetPixelSize(value);
        }
    }

    /// <summary>
    /// <para>The text drawing offset (in pixels).</para>
    /// </summary>
    public Vector2 Offset
    {
        get
        {
            return GetOffset();
        }
        set
        {
            SetOffset(value);
        }
    }

    /// <summary>
    /// <para>The billboard mode to use for the label.</para>
    /// </summary>
    public BaseMaterial3D.BillboardModeEnum Billboard
    {
        get
        {
            return GetBillboardMode();
        }
        set
        {
            SetBillboardMode(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the <see cref="Godot.Light3D"/> in the <see cref="Godot.Environment"/> has effects on the label.</para>
    /// </summary>
    public bool Shaded
    {
        get
        {
            return GetDrawFlag((Label3D.DrawFlags)(0));
        }
        set
        {
            SetDrawFlag((Label3D.DrawFlags)(0), value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, text can be seen from the back as well, if <see langword="false"/>, it is invisible when looking at it from behind.</para>
    /// </summary>
    public bool DoubleSided
    {
        get
        {
            return GetDrawFlag((Label3D.DrawFlags)(1));
        }
        set
        {
            SetDrawFlag((Label3D.DrawFlags)(1), value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, depth testing is disabled and the object will be drawn in render order.</para>
    /// </summary>
    public bool NoDepthTest
    {
        get
        {
            return GetDrawFlag((Label3D.DrawFlags)(2));
        }
        set
        {
            SetDrawFlag((Label3D.DrawFlags)(2), value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the label is rendered at the same size regardless of distance. The label's size on screen is the same as if the camera was <c>1.0</c> units away from the label's origin, regardless of the actual distance from the camera. The <see cref="Godot.Camera3D"/>'s field of view (or <see cref="Godot.Camera3D.Size"/> when in orthogonal/frustum mode) still affects the size the label is drawn at.</para>
    /// </summary>
    public bool FixedSize
    {
        get
        {
            return GetDrawFlag((Label3D.DrawFlags)(3));
        }
        set
        {
            SetDrawFlag((Label3D.DrawFlags)(3), value);
        }
    }

    /// <summary>
    /// <para>The alpha cutting mode to use for the sprite.</para>
    /// </summary>
    public Label3D.AlphaCutMode AlphaCut
    {
        get
        {
            return GetAlphaCutMode();
        }
        set
        {
            SetAlphaCutMode(value);
        }
    }

    /// <summary>
    /// <para>Threshold at which the alpha scissor will discard values.</para>
    /// </summary>
    public float AlphaScissorThreshold
    {
        get
        {
            return GetAlphaScissorThreshold();
        }
        set
        {
            SetAlphaScissorThreshold(value);
        }
    }

    /// <summary>
    /// <para>The hashing scale for Alpha Hash. Recommended values between <c>0</c> and <c>2</c>.</para>
    /// </summary>
    public float AlphaHashScale
    {
        get
        {
            return GetAlphaHashScale();
        }
        set
        {
            SetAlphaHashScale(value);
        }
    }

    /// <summary>
    /// <para>The type of alpha antialiasing to apply.</para>
    /// </summary>
    public BaseMaterial3D.AlphaAntiAliasing AlphaAntialiasingMode
    {
        get
        {
            return GetAlphaAntialiasing();
        }
        set
        {
            SetAlphaAntialiasing(value);
        }
    }

    /// <summary>
    /// <para>Threshold at which antialiasing will be applied on the alpha channel.</para>
    /// </summary>
    public float AlphaAntialiasingEdge
    {
        get
        {
            return GetAlphaAntialiasingEdge();
        }
        set
        {
            SetAlphaAntialiasingEdge(value);
        }
    }

    /// <summary>
    /// <para>Filter flags for the texture.</para>
    /// </summary>
    public BaseMaterial3D.TextureFilterEnum TextureFilter
    {
        get
        {
            return GetTextureFilter();
        }
        set
        {
            SetTextureFilter(value);
        }
    }

    /// <summary>
    /// <para>Sets the render priority for the text. Higher priority objects will be sorted in front of lower priority objects.</para>
    /// <para><b>Note:</b> This only applies if <see cref="Godot.Label3D.AlphaCut"/> is set to <see cref="Godot.Label3D.AlphaCutMode.Disabled"/> (default value).</para>
    /// <para><b>Note:</b> This only applies to sorting of transparent objects. This will not impact how transparent objects are sorted relative to opaque objects. This is because opaque objects are not sorted, while transparent objects are sorted from back to front (subject to priority).</para>
    /// </summary>
    public int RenderPriority
    {
        get
        {
            return GetRenderPriority();
        }
        set
        {
            SetRenderPriority(value);
        }
    }

    /// <summary>
    /// <para>Sets the render priority for the text outline. Higher priority objects will be sorted in front of lower priority objects.</para>
    /// <para><b>Note:</b> This only applies if <see cref="Godot.Label3D.AlphaCut"/> is set to <see cref="Godot.Label3D.AlphaCutMode.Disabled"/> (default value).</para>
    /// <para><b>Note:</b> This only applies to sorting of transparent objects. This will not impact how transparent objects are sorted relative to opaque objects. This is because opaque objects are not sorted, while transparent objects are sorted from back to front (subject to priority).</para>
    /// </summary>
    public int OutlineRenderPriority
    {
        get
        {
            return GetOutlineRenderPriority();
        }
        set
        {
            SetOutlineRenderPriority(value);
        }
    }

    /// <summary>
    /// <para>Text <see cref="Godot.Color"/> of the <see cref="Godot.Label3D"/>.</para>
    /// </summary>
    public Color Modulate
    {
        get
        {
            return GetModulate();
        }
        set
        {
            SetModulate(value);
        }
    }

    /// <summary>
    /// <para>The tint of text outline.</para>
    /// </summary>
    public Color OutlineModulate
    {
        get
        {
            return GetOutlineModulate();
        }
        set
        {
            SetOutlineModulate(value);
        }
    }

    /// <summary>
    /// <para>The text to display on screen.</para>
    /// </summary>
    public string Text
    {
        get
        {
            return GetText();
        }
        set
        {
            SetText(value);
        }
    }

    /// <summary>
    /// <para>Font configuration used to display text.</para>
    /// </summary>
    public Font Font
    {
        get
        {
            return GetFont();
        }
        set
        {
            SetFont(value);
        }
    }

    /// <summary>
    /// <para>Font size of the <see cref="Godot.Label3D"/>'s text. To make the font look more detailed when up close, increase <see cref="Godot.Label3D.FontSize"/> while decreasing <see cref="Godot.Label3D.PixelSize"/> at the same time.</para>
    /// <para>Higher font sizes require more time to render new characters, which can cause stuttering during gameplay.</para>
    /// </summary>
    public int FontSize
    {
        get
        {
            return GetFontSize();
        }
        set
        {
            SetFontSize(value);
        }
    }

    /// <summary>
    /// <para>Text outline size.</para>
    /// </summary>
    public int OutlineSize
    {
        get
        {
            return GetOutlineSize();
        }
        set
        {
            SetOutlineSize(value);
        }
    }

    /// <summary>
    /// <para>Controls the text's horizontal alignment. Supports left, center, right, and fill (also known as justify).</para>
    /// </summary>
    public HorizontalAlignment HorizontalAlignment
    {
        get
        {
            return GetHorizontalAlignment();
        }
        set
        {
            SetHorizontalAlignment(value);
        }
    }

    /// <summary>
    /// <para>Controls the text's vertical alignment. Supports top, center, and bottom.</para>
    /// </summary>
    public VerticalAlignment VerticalAlignment
    {
        get
        {
            return GetVerticalAlignment();
        }
        set
        {
            SetVerticalAlignment(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, all the text displays as UPPERCASE.</para>
    /// </summary>
    public bool Uppercase
    {
        get
        {
            return IsUppercase();
        }
        set
        {
            SetUppercase(value);
        }
    }

    /// <summary>
    /// <para>Additional vertical spacing between lines (in pixels), spacing is added to line descent. This value can be negative.</para>
    /// </summary>
    public float LineSpacing
    {
        get
        {
            return GetLineSpacing();
        }
        set
        {
            SetLineSpacing(value);
        }
    }

    /// <summary>
    /// <para>If set to something other than <see cref="Godot.TextServer.AutowrapMode.Off"/>, the text gets wrapped inside the node's bounding rectangle. If you resize the node, it will change its height automatically to show all the text.</para>
    /// </summary>
    public TextServer.AutowrapMode AutowrapMode
    {
        get
        {
            return GetAutowrapMode();
        }
        set
        {
            SetAutowrapMode(value);
        }
    }

    /// <summary>
    /// <para>Autowrap space trimming flags. See <see cref="Godot.TextServer.LineBreakFlag.TrimStartEdgeSpaces"/> and <see cref="Godot.TextServer.LineBreakFlag.TrimEndEdgeSpaces"/> for more info.</para>
    /// </summary>
    public TextServer.LineBreakFlag AutowrapTrimFlags
    {
        get
        {
            return GetAutowrapTrimFlags();
        }
        set
        {
            SetAutowrapTrimFlags(value);
        }
    }

    /// <summary>
    /// <para>Line fill alignment rules.</para>
    /// </summary>
    public TextServer.JustificationFlag JustificationFlags
    {
        get
        {
            return GetJustificationFlags();
        }
        set
        {
            SetJustificationFlags(value);
        }
    }

    /// <summary>
    /// <para>Text width (in pixels), used for autowrap and fill alignment.</para>
    /// </summary>
    public float Width
    {
        get
        {
            return GetWidth();
        }
        set
        {
            SetWidth(value);
        }
    }

    /// <summary>
    /// <para>Base text writing direction.</para>
    /// </summary>
    public TextServer.Direction TextDirection
    {
        get
        {
            return GetTextDirection();
        }
        set
        {
            SetTextDirection(value);
        }
    }

    /// <summary>
    /// <para>Language code used for line-breaking and text shaping algorithms. If left empty, the current locale is used instead.</para>
    /// </summary>
    public string Language
    {
        get
        {
            return GetLanguage();
        }
        set
        {
            SetLanguage(value);
        }
    }

    /// <summary>
    /// <para>Set BiDi algorithm override for the structured text.</para>
    /// </summary>
    public TextServer.StructuredTextParser StructuredTextBidiOverride
    {
        get
        {
            return GetStructuredTextBidiOverride();
        }
        set
        {
            SetStructuredTextBidiOverride(value);
        }
    }

    /// <summary>
    /// <para>Set additional options for BiDi override.</para>
    /// </summary>
    public Godot.Collections.Array StructuredTextBidiOverrideOptions
    {
        get
        {
            return GetStructuredTextBidiOverrideOptions();
        }
        set
        {
            SetStructuredTextBidiOverrideOptions(value);
        }
    }

    private static readonly System.Type CachedType = typeof(Label3D);

    private static readonly StringName NativeName = "Label3D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public Label3D() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal Label3D(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal Label3D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetHorizontalAlignment, 2312603777ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetHorizontalAlignment(HorizontalAlignment alignment)
    {
        NativeCalls.godot_icall_1_38(MethodBind0, GodotObject.GetPtr(this), (int)alignment);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetHorizontalAlignment, 341400642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public HorizontalAlignment GetHorizontalAlignment()
    {
        return (HorizontalAlignment)NativeCalls.godot_icall_0_39(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVerticalAlignment, 1796458609ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetVerticalAlignment(VerticalAlignment alignment)
    {
        NativeCalls.godot_icall_1_38(MethodBind2, GodotObject.GetPtr(this), (int)alignment);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVerticalAlignment, 3274884059ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public VerticalAlignment GetVerticalAlignment()
    {
        return (VerticalAlignment)NativeCalls.godot_icall_0_39(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetModulate, 2920490490ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetModulate(Color modulate)
    {
        NativeCalls.godot_icall_1_213(MethodBind4, GodotObject.GetPtr(this), &modulate);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetModulate, 3444240500ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Color GetModulate()
    {
        return NativeCalls.godot_icall_0_214(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetOutlineModulate, 2920490490ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetOutlineModulate(Color modulate)
    {
        NativeCalls.godot_icall_1_213(MethodBind6, GodotObject.GetPtr(this), &modulate);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOutlineModulate, 3444240500ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Color GetOutlineModulate()
    {
        return NativeCalls.godot_icall_0_214(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetText, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetText(string text)
    {
        NativeCalls.godot_icall_1_57(MethodBind8, GodotObject.GetPtr(this), text);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetText, 201670096ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetText()
    {
        return NativeCalls.godot_icall_0_58(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTextDirection, 1418190634ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTextDirection(TextServer.Direction direction)
    {
        NativeCalls.godot_icall_1_38(MethodBind10, GodotObject.GetPtr(this), (int)direction);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTextDirection, 2516697328ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public TextServer.Direction GetTextDirection()
    {
        return (TextServer.Direction)NativeCalls.godot_icall_0_39(MethodBind11, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLanguage, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetLanguage(string language)
    {
        NativeCalls.godot_icall_1_57(MethodBind12, GodotObject.GetPtr(this), language);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLanguage, 201670096ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetLanguage()
    {
        return NativeCalls.godot_icall_0_58(MethodBind13, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetStructuredTextBidiOverride, 55961453ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetStructuredTextBidiOverride(TextServer.StructuredTextParser parser)
    {
        NativeCalls.godot_icall_1_38(MethodBind14, GodotObject.GetPtr(this), (int)parser);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetStructuredTextBidiOverride, 3385126229ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public TextServer.StructuredTextParser GetStructuredTextBidiOverride()
    {
        return (TextServer.StructuredTextParser)NativeCalls.godot_icall_0_39(MethodBind15, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetStructuredTextBidiOverrideOptions, 381264803ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetStructuredTextBidiOverrideOptions(Godot.Collections.Array args)
    {
        NativeCalls.godot_icall_1_138(MethodBind16, GodotObject.GetPtr(this), (godot_array)(args ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetStructuredTextBidiOverrideOptions, 3995934104ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Godot.Collections.Array GetStructuredTextBidiOverrideOptions()
    {
        return NativeCalls.godot_icall_0_120(MethodBind17, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetUppercase, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetUppercase(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind18, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsUppercase, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsUppercase()
    {
        return NativeCalls.godot_icall_0_15(MethodBind19, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRenderPriority, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetRenderPriority(int priority)
    {
        NativeCalls.godot_icall_1_38(MethodBind20, GodotObject.GetPtr(this), priority);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRenderPriority, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetRenderPriority()
    {
        return NativeCalls.godot_icall_0_39(MethodBind21, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetOutlineRenderPriority, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetOutlineRenderPriority(int priority)
    {
        NativeCalls.godot_icall_1_38(MethodBind22, GodotObject.GetPtr(this), priority);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOutlineRenderPriority, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetOutlineRenderPriority()
    {
        return NativeCalls.godot_icall_0_39(MethodBind23, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFont, 1262170328ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFont(Font font)
    {
        NativeCalls.godot_icall_1_56(MethodBind24, GodotObject.GetPtr(this), GodotObject.GetPtr(font));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFont, 3229501585ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Font GetFont()
    {
        return (Font)NativeCalls.godot_icall_0_63(MethodBind25, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFontSize, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFontSize(int size)
    {
        NativeCalls.godot_icall_1_38(MethodBind26, GodotObject.GetPtr(this), size);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFontSize, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetFontSize()
    {
        return NativeCalls.godot_icall_0_39(MethodBind27, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetOutlineSize, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetOutlineSize(int outlineSize)
    {
        NativeCalls.godot_icall_1_38(MethodBind28, GodotObject.GetPtr(this), outlineSize);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOutlineSize, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetOutlineSize()
    {
        return NativeCalls.godot_icall_0_39(MethodBind29, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLineSpacing, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetLineSpacing(float lineSpacing)
    {
        NativeCalls.godot_icall_1_67(MethodBind30, GodotObject.GetPtr(this), lineSpacing);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLineSpacing, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetLineSpacing()
    {
        return NativeCalls.godot_icall_0_68(MethodBind31, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind32 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAutowrapMode, 3289138044ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAutowrapMode(TextServer.AutowrapMode autowrapMode)
    {
        NativeCalls.godot_icall_1_38(MethodBind32, GodotObject.GetPtr(this), (int)autowrapMode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind33 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAutowrapMode, 1549071663ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public TextServer.AutowrapMode GetAutowrapMode()
    {
        return (TextServer.AutowrapMode)NativeCalls.godot_icall_0_39(MethodBind33, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind34 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAutowrapTrimFlags, 2809697122ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAutowrapTrimFlags(TextServer.LineBreakFlag autowrapTrimFlags)
    {
        NativeCalls.godot_icall_1_38(MethodBind34, GodotObject.GetPtr(this), (int)autowrapTrimFlags);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind35 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAutowrapTrimFlags, 2340632602ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public TextServer.LineBreakFlag GetAutowrapTrimFlags()
    {
        return (TextServer.LineBreakFlag)NativeCalls.godot_icall_0_39(MethodBind35, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind36 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetJustificationFlags, 2877345813ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetJustificationFlags(TextServer.JustificationFlag justificationFlags)
    {
        NativeCalls.godot_icall_1_38(MethodBind36, GodotObject.GetPtr(this), (int)justificationFlags);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind37 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetJustificationFlags, 1583363614ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public TextServer.JustificationFlag GetJustificationFlags()
    {
        return (TextServer.JustificationFlag)NativeCalls.godot_icall_0_39(MethodBind37, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind38 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetWidth, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetWidth(float width)
    {
        NativeCalls.godot_icall_1_67(MethodBind38, GodotObject.GetPtr(this), width);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind39 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetWidth, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetWidth()
    {
        return NativeCalls.godot_icall_0_68(MethodBind39, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind40 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPixelSize, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPixelSize(float pixelSize)
    {
        NativeCalls.godot_icall_1_67(MethodBind40, GodotObject.GetPtr(this), pixelSize);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind41 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPixelSize, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetPixelSize()
    {
        return NativeCalls.godot_icall_0_68(MethodBind41, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind42 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetOffset, 743155724ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetOffset(Vector2 offset)
    {
        NativeCalls.godot_icall_1_36(MethodBind42, GodotObject.GetPtr(this), &offset);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind43 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOffset, 3341600327ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2 GetOffset()
    {
        return NativeCalls.godot_icall_0_37(MethodBind43, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind44 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDrawFlag, 1285833066ul);

    /// <summary>
    /// <para>If <see langword="true"/>, the specified <paramref name="flag"/> will be enabled.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDrawFlag(Label3D.DrawFlags flag, bool enabled)
    {
        NativeCalls.godot_icall_2_61(MethodBind44, GodotObject.GetPtr(this), (int)flag, enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind45 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDrawFlag, 259226453ul);

    /// <summary>
    /// <para>Returns the value of the specified flag.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetDrawFlag(Label3D.DrawFlags flag)
    {
        return NativeCalls.godot_icall_1_62(MethodBind45, GodotObject.GetPtr(this), (int)flag).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind46 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBillboardMode, 4202036497ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetBillboardMode(BaseMaterial3D.BillboardModeEnum mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind46, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind47 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBillboardMode, 1283840139ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public BaseMaterial3D.BillboardModeEnum GetBillboardMode()
    {
        return (BaseMaterial3D.BillboardModeEnum)NativeCalls.godot_icall_0_39(MethodBind47, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind48 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAlphaCutMode, 2549142916ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAlphaCutMode(Label3D.AlphaCutMode mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind48, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind49 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAlphaCutMode, 219468601ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Label3D.AlphaCutMode GetAlphaCutMode()
    {
        return (Label3D.AlphaCutMode)NativeCalls.godot_icall_0_39(MethodBind49, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind50 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAlphaScissorThreshold, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAlphaScissorThreshold(float threshold)
    {
        NativeCalls.godot_icall_1_67(MethodBind50, GodotObject.GetPtr(this), threshold);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind51 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAlphaScissorThreshold, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetAlphaScissorThreshold()
    {
        return NativeCalls.godot_icall_0_68(MethodBind51, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind52 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAlphaHashScale, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAlphaHashScale(float threshold)
    {
        NativeCalls.godot_icall_1_67(MethodBind52, GodotObject.GetPtr(this), threshold);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind53 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAlphaHashScale, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetAlphaHashScale()
    {
        return NativeCalls.godot_icall_0_68(MethodBind53, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind54 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAlphaAntialiasing, 3212649852ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAlphaAntialiasing(BaseMaterial3D.AlphaAntiAliasing alphaAA)
    {
        NativeCalls.godot_icall_1_38(MethodBind54, GodotObject.GetPtr(this), (int)alphaAA);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind55 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAlphaAntialiasing, 2889939400ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public BaseMaterial3D.AlphaAntiAliasing GetAlphaAntialiasing()
    {
        return (BaseMaterial3D.AlphaAntiAliasing)NativeCalls.godot_icall_0_39(MethodBind55, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind56 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAlphaAntialiasingEdge, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAlphaAntialiasingEdge(float edge)
    {
        NativeCalls.godot_icall_1_67(MethodBind56, GodotObject.GetPtr(this), edge);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind57 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAlphaAntialiasingEdge, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetAlphaAntialiasingEdge()
    {
        return NativeCalls.godot_icall_0_68(MethodBind57, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind58 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTextureFilter, 22904437ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTextureFilter(BaseMaterial3D.TextureFilterEnum mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind58, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind59 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTextureFilter, 3289213076ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public BaseMaterial3D.TextureFilterEnum GetTextureFilter()
    {
        return (BaseMaterial3D.TextureFilterEnum)NativeCalls.godot_icall_0_39(MethodBind59, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind60 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GenerateTriangleMesh, 3476533166ul);

    /// <summary>
    /// <para>Returns a <see cref="Godot.TriangleMesh"/> with the label's vertices following its current configuration (such as its <see cref="Godot.Label3D.PixelSize"/>).</para>
    /// </summary>
    public TriangleMesh GenerateTriangleMesh()
    {
        return (TriangleMesh)NativeCalls.godot_icall_0_63(MethodBind60, GodotObject.GetPtr(this));
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
    public new class PropertyName : GeometryInstance3D.PropertyName
    {
        /// <summary>
        /// Cached name for the 'pixel_size' property.
        /// </summary>
        public static readonly StringName PixelSize = "pixel_size";
        /// <summary>
        /// Cached name for the 'offset' property.
        /// </summary>
        public static readonly StringName Offset = "offset";
        /// <summary>
        /// Cached name for the 'billboard' property.
        /// </summary>
        public static readonly StringName Billboard = "billboard";
        /// <summary>
        /// Cached name for the 'shaded' property.
        /// </summary>
        public static readonly StringName Shaded = "shaded";
        /// <summary>
        /// Cached name for the 'double_sided' property.
        /// </summary>
        public static readonly StringName DoubleSided = "double_sided";
        /// <summary>
        /// Cached name for the 'no_depth_test' property.
        /// </summary>
        public static readonly StringName NoDepthTest = "no_depth_test";
        /// <summary>
        /// Cached name for the 'fixed_size' property.
        /// </summary>
        public static readonly StringName FixedSize = "fixed_size";
        /// <summary>
        /// Cached name for the 'alpha_cut' property.
        /// </summary>
        public static readonly StringName AlphaCut = "alpha_cut";
        /// <summary>
        /// Cached name for the 'alpha_scissor_threshold' property.
        /// </summary>
        public static readonly StringName AlphaScissorThreshold = "alpha_scissor_threshold";
        /// <summary>
        /// Cached name for the 'alpha_hash_scale' property.
        /// </summary>
        public static readonly StringName AlphaHashScale = "alpha_hash_scale";
        /// <summary>
        /// Cached name for the 'alpha_antialiasing_mode' property.
        /// </summary>
        public static readonly StringName AlphaAntialiasingMode = "alpha_antialiasing_mode";
        /// <summary>
        /// Cached name for the 'alpha_antialiasing_edge' property.
        /// </summary>
        public static readonly StringName AlphaAntialiasingEdge = "alpha_antialiasing_edge";
        /// <summary>
        /// Cached name for the 'texture_filter' property.
        /// </summary>
        public static readonly StringName TextureFilter = "texture_filter";
        /// <summary>
        /// Cached name for the 'render_priority' property.
        /// </summary>
        public static readonly StringName RenderPriority = "render_priority";
        /// <summary>
        /// Cached name for the 'outline_render_priority' property.
        /// </summary>
        public static readonly StringName OutlineRenderPriority = "outline_render_priority";
        /// <summary>
        /// Cached name for the 'modulate' property.
        /// </summary>
        public static readonly StringName Modulate = "modulate";
        /// <summary>
        /// Cached name for the 'outline_modulate' property.
        /// </summary>
        public static readonly StringName OutlineModulate = "outline_modulate";
        /// <summary>
        /// Cached name for the 'text' property.
        /// </summary>
        public static readonly StringName Text = "text";
        /// <summary>
        /// Cached name for the 'font' property.
        /// </summary>
        public static readonly StringName Font = "font";
        /// <summary>
        /// Cached name for the 'font_size' property.
        /// </summary>
        public static readonly StringName FontSize = "font_size";
        /// <summary>
        /// Cached name for the 'outline_size' property.
        /// </summary>
        public static readonly StringName OutlineSize = "outline_size";
        /// <summary>
        /// Cached name for the 'horizontal_alignment' property.
        /// </summary>
        public static readonly StringName HorizontalAlignment = "horizontal_alignment";
        /// <summary>
        /// Cached name for the 'vertical_alignment' property.
        /// </summary>
        public static readonly StringName VerticalAlignment = "vertical_alignment";
        /// <summary>
        /// Cached name for the 'uppercase' property.
        /// </summary>
        public static readonly StringName Uppercase = "uppercase";
        /// <summary>
        /// Cached name for the 'line_spacing' property.
        /// </summary>
        public static readonly StringName LineSpacing = "line_spacing";
        /// <summary>
        /// Cached name for the 'autowrap_mode' property.
        /// </summary>
        public static readonly StringName AutowrapMode = "autowrap_mode";
        /// <summary>
        /// Cached name for the 'autowrap_trim_flags' property.
        /// </summary>
        public static readonly StringName AutowrapTrimFlags = "autowrap_trim_flags";
        /// <summary>
        /// Cached name for the 'justification_flags' property.
        /// </summary>
        public static readonly StringName JustificationFlags = "justification_flags";
        /// <summary>
        /// Cached name for the 'width' property.
        /// </summary>
        public static readonly StringName Width = "width";
        /// <summary>
        /// Cached name for the 'text_direction' property.
        /// </summary>
        public static readonly StringName TextDirection = "text_direction";
        /// <summary>
        /// Cached name for the 'language' property.
        /// </summary>
        public static readonly StringName Language = "language";
        /// <summary>
        /// Cached name for the 'structured_text_bidi_override' property.
        /// </summary>
        public static readonly StringName StructuredTextBidiOverride = "structured_text_bidi_override";
        /// <summary>
        /// Cached name for the 'structured_text_bidi_override_options' property.
        /// </summary>
        public static readonly StringName StructuredTextBidiOverrideOptions = "structured_text_bidi_override_options";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : GeometryInstance3D.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_horizontal_alignment' method.
        /// </summary>
        public static readonly StringName SetHorizontalAlignment = "set_horizontal_alignment";
        /// <summary>
        /// Cached name for the 'get_horizontal_alignment' method.
        /// </summary>
        public static readonly StringName GetHorizontalAlignment = "get_horizontal_alignment";
        /// <summary>
        /// Cached name for the 'set_vertical_alignment' method.
        /// </summary>
        public static readonly StringName SetVerticalAlignment = "set_vertical_alignment";
        /// <summary>
        /// Cached name for the 'get_vertical_alignment' method.
        /// </summary>
        public static readonly StringName GetVerticalAlignment = "get_vertical_alignment";
        /// <summary>
        /// Cached name for the 'set_modulate' method.
        /// </summary>
        public static readonly StringName SetModulate = "set_modulate";
        /// <summary>
        /// Cached name for the 'get_modulate' method.
        /// </summary>
        public static readonly StringName GetModulate = "get_modulate";
        /// <summary>
        /// Cached name for the 'set_outline_modulate' method.
        /// </summary>
        public static readonly StringName SetOutlineModulate = "set_outline_modulate";
        /// <summary>
        /// Cached name for the 'get_outline_modulate' method.
        /// </summary>
        public static readonly StringName GetOutlineModulate = "get_outline_modulate";
        /// <summary>
        /// Cached name for the 'set_text' method.
        /// </summary>
        public static readonly StringName SetText = "set_text";
        /// <summary>
        /// Cached name for the 'get_text' method.
        /// </summary>
        public static readonly StringName GetText = "get_text";
        /// <summary>
        /// Cached name for the 'set_text_direction' method.
        /// </summary>
        public static readonly StringName SetTextDirection = "set_text_direction";
        /// <summary>
        /// Cached name for the 'get_text_direction' method.
        /// </summary>
        public static readonly StringName GetTextDirection = "get_text_direction";
        /// <summary>
        /// Cached name for the 'set_language' method.
        /// </summary>
        public static readonly StringName SetLanguage = "set_language";
        /// <summary>
        /// Cached name for the 'get_language' method.
        /// </summary>
        public static readonly StringName GetLanguage = "get_language";
        /// <summary>
        /// Cached name for the 'set_structured_text_bidi_override' method.
        /// </summary>
        public static readonly StringName SetStructuredTextBidiOverride = "set_structured_text_bidi_override";
        /// <summary>
        /// Cached name for the 'get_structured_text_bidi_override' method.
        /// </summary>
        public static readonly StringName GetStructuredTextBidiOverride = "get_structured_text_bidi_override";
        /// <summary>
        /// Cached name for the 'set_structured_text_bidi_override_options' method.
        /// </summary>
        public static readonly StringName SetStructuredTextBidiOverrideOptions = "set_structured_text_bidi_override_options";
        /// <summary>
        /// Cached name for the 'get_structured_text_bidi_override_options' method.
        /// </summary>
        public static readonly StringName GetStructuredTextBidiOverrideOptions = "get_structured_text_bidi_override_options";
        /// <summary>
        /// Cached name for the 'set_uppercase' method.
        /// </summary>
        public static readonly StringName SetUppercase = "set_uppercase";
        /// <summary>
        /// Cached name for the 'is_uppercase' method.
        /// </summary>
        public static readonly StringName IsUppercase = "is_uppercase";
        /// <summary>
        /// Cached name for the 'set_render_priority' method.
        /// </summary>
        public static readonly StringName SetRenderPriority = "set_render_priority";
        /// <summary>
        /// Cached name for the 'get_render_priority' method.
        /// </summary>
        public static readonly StringName GetRenderPriority = "get_render_priority";
        /// <summary>
        /// Cached name for the 'set_outline_render_priority' method.
        /// </summary>
        public static readonly StringName SetOutlineRenderPriority = "set_outline_render_priority";
        /// <summary>
        /// Cached name for the 'get_outline_render_priority' method.
        /// </summary>
        public static readonly StringName GetOutlineRenderPriority = "get_outline_render_priority";
        /// <summary>
        /// Cached name for the 'set_font' method.
        /// </summary>
        public static readonly StringName SetFont = "set_font";
        /// <summary>
        /// Cached name for the 'get_font' method.
        /// </summary>
        public static readonly StringName GetFont = "get_font";
        /// <summary>
        /// Cached name for the 'set_font_size' method.
        /// </summary>
        public static readonly StringName SetFontSize = "set_font_size";
        /// <summary>
        /// Cached name for the 'get_font_size' method.
        /// </summary>
        public static readonly StringName GetFontSize = "get_font_size";
        /// <summary>
        /// Cached name for the 'set_outline_size' method.
        /// </summary>
        public static readonly StringName SetOutlineSize = "set_outline_size";
        /// <summary>
        /// Cached name for the 'get_outline_size' method.
        /// </summary>
        public static readonly StringName GetOutlineSize = "get_outline_size";
        /// <summary>
        /// Cached name for the 'set_line_spacing' method.
        /// </summary>
        public static readonly StringName SetLineSpacing = "set_line_spacing";
        /// <summary>
        /// Cached name for the 'get_line_spacing' method.
        /// </summary>
        public static readonly StringName GetLineSpacing = "get_line_spacing";
        /// <summary>
        /// Cached name for the 'set_autowrap_mode' method.
        /// </summary>
        public static readonly StringName SetAutowrapMode = "set_autowrap_mode";
        /// <summary>
        /// Cached name for the 'get_autowrap_mode' method.
        /// </summary>
        public static readonly StringName GetAutowrapMode = "get_autowrap_mode";
        /// <summary>
        /// Cached name for the 'set_autowrap_trim_flags' method.
        /// </summary>
        public static readonly StringName SetAutowrapTrimFlags = "set_autowrap_trim_flags";
        /// <summary>
        /// Cached name for the 'get_autowrap_trim_flags' method.
        /// </summary>
        public static readonly StringName GetAutowrapTrimFlags = "get_autowrap_trim_flags";
        /// <summary>
        /// Cached name for the 'set_justification_flags' method.
        /// </summary>
        public static readonly StringName SetJustificationFlags = "set_justification_flags";
        /// <summary>
        /// Cached name for the 'get_justification_flags' method.
        /// </summary>
        public static readonly StringName GetJustificationFlags = "get_justification_flags";
        /// <summary>
        /// Cached name for the 'set_width' method.
        /// </summary>
        public static readonly StringName SetWidth = "set_width";
        /// <summary>
        /// Cached name for the 'get_width' method.
        /// </summary>
        public static readonly StringName GetWidth = "get_width";
        /// <summary>
        /// Cached name for the 'set_pixel_size' method.
        /// </summary>
        public static readonly StringName SetPixelSize = "set_pixel_size";
        /// <summary>
        /// Cached name for the 'get_pixel_size' method.
        /// </summary>
        public static readonly StringName GetPixelSize = "get_pixel_size";
        /// <summary>
        /// Cached name for the 'set_offset' method.
        /// </summary>
        public static readonly StringName SetOffset = "set_offset";
        /// <summary>
        /// Cached name for the 'get_offset' method.
        /// </summary>
        public static readonly StringName GetOffset = "get_offset";
        /// <summary>
        /// Cached name for the 'set_draw_flag' method.
        /// </summary>
        public static readonly StringName SetDrawFlag = "set_draw_flag";
        /// <summary>
        /// Cached name for the 'get_draw_flag' method.
        /// </summary>
        public static readonly StringName GetDrawFlag = "get_draw_flag";
        /// <summary>
        /// Cached name for the 'set_billboard_mode' method.
        /// </summary>
        public static readonly StringName SetBillboardMode = "set_billboard_mode";
        /// <summary>
        /// Cached name for the 'get_billboard_mode' method.
        /// </summary>
        public static readonly StringName GetBillboardMode = "get_billboard_mode";
        /// <summary>
        /// Cached name for the 'set_alpha_cut_mode' method.
        /// </summary>
        public static readonly StringName SetAlphaCutMode = "set_alpha_cut_mode";
        /// <summary>
        /// Cached name for the 'get_alpha_cut_mode' method.
        /// </summary>
        public static readonly StringName GetAlphaCutMode = "get_alpha_cut_mode";
        /// <summary>
        /// Cached name for the 'set_alpha_scissor_threshold' method.
        /// </summary>
        public static readonly StringName SetAlphaScissorThreshold = "set_alpha_scissor_threshold";
        /// <summary>
        /// Cached name for the 'get_alpha_scissor_threshold' method.
        /// </summary>
        public static readonly StringName GetAlphaScissorThreshold = "get_alpha_scissor_threshold";
        /// <summary>
        /// Cached name for the 'set_alpha_hash_scale' method.
        /// </summary>
        public static readonly StringName SetAlphaHashScale = "set_alpha_hash_scale";
        /// <summary>
        /// Cached name for the 'get_alpha_hash_scale' method.
        /// </summary>
        public static readonly StringName GetAlphaHashScale = "get_alpha_hash_scale";
        /// <summary>
        /// Cached name for the 'set_alpha_antialiasing' method.
        /// </summary>
        public static readonly StringName SetAlphaAntialiasing = "set_alpha_antialiasing";
        /// <summary>
        /// Cached name for the 'get_alpha_antialiasing' method.
        /// </summary>
        public static readonly StringName GetAlphaAntialiasing = "get_alpha_antialiasing";
        /// <summary>
        /// Cached name for the 'set_alpha_antialiasing_edge' method.
        /// </summary>
        public static readonly StringName SetAlphaAntialiasingEdge = "set_alpha_antialiasing_edge";
        /// <summary>
        /// Cached name for the 'get_alpha_antialiasing_edge' method.
        /// </summary>
        public static readonly StringName GetAlphaAntialiasingEdge = "get_alpha_antialiasing_edge";
        /// <summary>
        /// Cached name for the 'set_texture_filter' method.
        /// </summary>
        public static readonly StringName SetTextureFilter = "set_texture_filter";
        /// <summary>
        /// Cached name for the 'get_texture_filter' method.
        /// </summary>
        public static readonly StringName GetTextureFilter = "get_texture_filter";
        /// <summary>
        /// Cached name for the 'generate_triangle_mesh' method.
        /// </summary>
        public static readonly StringName GenerateTriangleMesh = "generate_triangle_mesh";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : GeometryInstance3D.SignalName
    {
    }
}
