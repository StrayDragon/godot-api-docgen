namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para><see cref="Godot.FontFile"/> contains a set of glyphs to represent Unicode characters imported from a font file, as well as a cache of rasterized glyphs, and a set of fallback <see cref="Godot.Font"/>s to use.</para>
/// <para>Use <see cref="Godot.FontVariation"/> to access specific OpenType variation of the font, create simulated bold / slanted version, and draw lines of text.</para>
/// <para>For more complex text processing, use <see cref="Godot.FontVariation"/> in conjunction with <see cref="Godot.TextLine"/> or <see cref="Godot.TextParagraph"/>.</para>
/// <para>Supported font formats:</para>
/// <para>- Dynamic font importer: TrueType (.ttf), TrueType collection (.ttc), OpenType (.otf), OpenType collection (.otc), WOFF (.woff), WOFF2 (.woff2), Type 1 (.pfb, .pfm).</para>
/// <para>- Bitmap font importer: AngelCode BMFont (.fnt, .font), text and binary (version 3) format variants.</para>
/// <para>- Monospace image font importer: All supported image formats.</para>
/// <para><b>Note:</b> A character is a symbol that represents an item (letter, digit etc.) in an abstract way.</para>
/// <para><b>Note:</b> A glyph is a bitmap or a shape used to draw one or more characters in a context-dependent manner. Glyph indices are bound to the specific font data source.</para>
/// <para><b>Note:</b> If none of the font data sources contain glyphs for a character used in a string, the character in question will be replaced with a box displaying its hexadecimal code.</para>
/// <para><code>
/// var f = ResourceLoader.Load&lt;FontFile&gt;("res://BarlowCondensed-Bold.ttf");
/// GetNode("Label").AddThemeFontOverride("font", f);
/// GetNode("Label").AddThemeFontSizeOverride("font_size", 64);
/// </code></para>
/// </summary>
public partial class FontFile : Font
{
    /// <summary>
    /// <para>Contents of the dynamic font source file.</para>
    /// </summary>
    public byte[] Data
    {
        get
        {
            return GetData();
        }
        set
        {
            SetData(value);
        }
    }

    /// <summary>
    /// <para>If set to <see langword="true"/>, generate mipmaps for the font textures.</para>
    /// </summary>
    public bool GenerateMipmaps
    {
        get
        {
            return GetGenerateMipmaps();
        }
        set
        {
            SetGenerateMipmaps(value);
        }
    }

    /// <summary>
    /// <para>If set to <see langword="true"/>, embedded font bitmap loading is disabled (bitmap-only and color fonts ignore this property).</para>
    /// </summary>
    public bool DisableEmbeddedBitmaps
    {
        get
        {
            return GetDisableEmbeddedBitmaps();
        }
        set
        {
            SetDisableEmbeddedBitmaps(value);
        }
    }

    /// <summary>
    /// <para>Font anti-aliasing mode.</para>
    /// </summary>
    public TextServer.FontAntialiasing Antialiasing
    {
        get
        {
            return GetAntialiasing();
        }
        set
        {
            SetAntialiasing(value);
        }
    }

    /// <summary>
    /// <para>Font family name.</para>
    /// </summary>
    public string FontName
    {
        get
        {
            return GetFontName();
        }
        set
        {
            SetFontName(value);
        }
    }

    /// <summary>
    /// <para>Font style name.</para>
    /// </summary>
    public string StyleName
    {
        get
        {
            return GetFontStyleName();
        }
        set
        {
            SetFontStyleName(value);
        }
    }

    /// <summary>
    /// <para>Font style flags.</para>
    /// </summary>
    public TextServer.FontStyle FontStyle
    {
        get
        {
            return GetFontStyle();
        }
        set
        {
            SetFontStyle(value);
        }
    }

    /// <summary>
    /// <para>Weight (boldness) of the font. A value in the <c>100...999</c> range, normal font weight is <c>400</c>, bold font weight is <c>700</c>.</para>
    /// </summary>
    public int FontWeight
    {
        get
        {
            return GetFontWeight();
        }
        set
        {
            SetFontWeight(value);
        }
    }

    /// <summary>
    /// <para>Font stretch amount, compared to a normal width. A percentage value between <c>50%</c> and <c>200%</c>.</para>
    /// </summary>
    public int FontStretch
    {
        get
        {
            return GetFontStretch();
        }
        set
        {
            SetFontStretch(value);
        }
    }

    /// <summary>
    /// <para>Font glyph subpixel positioning mode. Subpixel positioning provides shaper text and better kerning for smaller font sizes, at the cost of higher memory usage and lower font rasterization speed. Use <see cref="Godot.TextServer.SubpixelPositioning.Auto"/> to automatically enable it based on the font size.</para>
    /// </summary>
    public TextServer.SubpixelPositioning SubpixelPositioning
    {
        get
        {
            return GetSubpixelPositioning();
        }
        set
        {
            SetSubpixelPositioning(value);
        }
    }

    /// <summary>
    /// <para>If set to <see langword="true"/>, when aligning glyphs to the pixel boundaries rounding remainders are accumulated to ensure more uniform glyph distribution. This setting has no effect if subpixel positioning is enabled.</para>
    /// </summary>
    public bool KeepRoundingRemainders
    {
        get
        {
            return GetKeepRoundingRemainders();
        }
        set
        {
            SetKeepRoundingRemainders(value);
        }
    }

    /// <summary>
    /// <para>If set to <see langword="true"/>, glyphs of all sizes are rendered using single multichannel signed distance field (MSDF) generated from the dynamic font vector data. Since this approach does not rely on rasterizing the font every time its size changes, this allows for resizing the font in real-time without any performance penalty. Text will also not look grainy for <see cref="Godot.Control"/>s that are scaled down (or for <see cref="Godot.Label3D"/>s viewed from a long distance). As a downside, font hinting is not available with MSDF. The lack of font hinting may result in less crisp and less readable fonts at small sizes.</para>
    /// <para><b>Note:</b> If using font outlines, <see cref="Godot.FontFile.MsdfPixelRange"/> must be set to at least <i>twice</i> the size of the largest font outline.</para>
    /// <para><b>Note:</b> MSDF font rendering does not render glyphs with overlapping shapes correctly. Overlapping shapes are not valid per the OpenType standard, but are still commonly found in many font files, especially those converted by Google Fonts. To avoid issues with overlapping glyphs, consider downloading the font file directly from the type foundry instead of relying on Google Fonts.</para>
    /// </summary>
    public bool MultichannelSignedDistanceField
    {
        get
        {
            return IsMultichannelSignedDistanceField();
        }
        set
        {
            SetMultichannelSignedDistanceField(value);
        }
    }

    /// <summary>
    /// <para>The width of the range around the shape between the minimum and maximum representable signed distance. If using font outlines, <see cref="Godot.FontFile.MsdfPixelRange"/> must be set to at least <i>twice</i> the size of the largest font outline. The default <see cref="Godot.FontFile.MsdfPixelRange"/> value of <c>16</c> allows outline sizes up to <c>8</c> to look correct.</para>
    /// </summary>
    public int MsdfPixelRange
    {
        get
        {
            return GetMsdfPixelRange();
        }
        set
        {
            SetMsdfPixelRange(value);
        }
    }

    /// <summary>
    /// <para>Source font size used to generate MSDF textures. Higher values allow for more precision, but are slower to render and require more memory. Only increase this value if you notice a visible lack of precision in glyph rendering.</para>
    /// </summary>
    public int MsdfSize
    {
        get
        {
            return GetMsdfSize();
        }
        set
        {
            SetMsdfSize(value);
        }
    }

    /// <summary>
    /// <para>If set to <see langword="true"/>, system fonts can be automatically used as fallbacks.</para>
    /// </summary>
    public bool AllowSystemFallback
    {
        get
        {
            return IsAllowSystemFallback();
        }
        set
        {
            SetAllowSystemFallback(value);
        }
    }

    /// <summary>
    /// <para>If set to <see langword="true"/>, auto-hinting is supported and preferred over font built-in hinting. Used by dynamic fonts only (MSDF fonts don't support hinting).</para>
    /// </summary>
    public bool ForceAutohinter
    {
        get
        {
            return IsForceAutohinter();
        }
        set
        {
            SetForceAutohinter(value);
        }
    }

    /// <summary>
    /// <para>If set to <see langword="true"/>, color modulation is applied when drawing colored glyphs, otherwise it's applied to the monochrome glyphs only.</para>
    /// </summary>
    public bool ModulateColorGlyphs
    {
        get
        {
            return IsModulateColorGlyphs();
        }
        set
        {
            SetModulateColorGlyphs(value);
        }
    }

    /// <summary>
    /// <para>Font hinting mode. Used by dynamic fonts only.</para>
    /// </summary>
    public TextServer.Hinting Hinting
    {
        get
        {
            return GetHinting();
        }
        set
        {
            SetHinting(value);
        }
    }

    /// <summary>
    /// <para>Font size, used only for the bitmap fonts.</para>
    /// </summary>
    public int FixedSize
    {
        get
        {
            return GetFixedSize();
        }
        set
        {
            SetFixedSize(value);
        }
    }

    /// <summary>
    /// <para>Scaling mode, used only for the bitmap fonts with <see cref="Godot.FontFile.FixedSize"/> greater than zero.</para>
    /// </summary>
    public TextServer.FixedSizeScaleMode FixedSizeScaleMode
    {
        get
        {
            return GetFixedSizeScaleMode();
        }
        set
        {
            SetFixedSizeScaleMode(value);
        }
    }

    /// <summary>
    /// <para>Font OpenType feature set override.</para>
    /// </summary>
    public Godot.Collections.Dictionary OpentypeFeatureOverrides
    {
        get
        {
            return GetOpentypeFeatureOverrides();
        }
        set
        {
            SetOpentypeFeatureOverrides(value);
        }
    }

    /// <summary>
    /// <para>If set to a positive value, overrides the oversampling factor of the viewport this font is used in. See <see cref="Godot.Viewport.Oversampling"/>. This value doesn't override the <c>oversampling</c> parameter of <c>draw_*</c> methods.</para>
    /// </summary>
    public float Oversampling
    {
        get
        {
            return GetOversampling();
        }
        set
        {
            SetOversampling(value);
        }
    }

    private static readonly System.Type CachedType = typeof(FontFile);

    private static readonly StringName NativeName = "FontFile";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public FontFile() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal FontFile(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal FontFile(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.LoadBitmapFont, 166001499ul);

    /// <summary>
    /// <para>Loads an AngelCode BMFont (.fnt, .font) bitmap font from file <paramref name="path"/>.</para>
    /// <para><b>Warning:</b> This method should only be used in the editor or in cases when you need to load external fonts at run-time, such as fonts located at the <c>user://</c> directory.</para>
    /// </summary>
    public Error LoadBitmapFont(string path)
    {
        return (Error)NativeCalls.godot_icall_1_134(MethodBind0, GodotObject.GetPtr(this), path);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.LoadDynamicFont, 166001499ul);

    /// <summary>
    /// <para>Loads a TrueType (.ttf), OpenType (.otf), WOFF (.woff), WOFF2 (.woff2) or Type 1 (.pfb, .pfm) dynamic font from file <paramref name="path"/>.</para>
    /// <para><b>Warning:</b> This method should only be used in the editor or in cases when you need to load external fonts at run-time, such as fonts located at the <c>user://</c> directory.</para>
    /// </summary>
    public Error LoadDynamicFont(string path)
    {
        return (Error)NativeCalls.godot_icall_1_134(MethodBind1, GodotObject.GetPtr(this), path);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetData, 2971499966ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetData(byte[] data)
    {
        NativeCalls.godot_icall_1_204(MethodBind2, GodotObject.GetPtr(this), data);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetData(ReadOnlySpan<byte> data)
    {
        NativeCalls.godot_icall_1_204(MethodBind2, GodotObject.GetPtr(this), data);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetData, 2362200018ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public byte[] GetData()
    {
        return NativeCalls.godot_icall_0_2(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFontName, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFontName(string name)
    {
        NativeCalls.godot_icall_1_57(MethodBind4, GodotObject.GetPtr(this), name);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFontStyleName, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFontStyleName(string name)
    {
        NativeCalls.godot_icall_1_57(MethodBind5, GodotObject.GetPtr(this), name);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFontStyle, 918070724ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFontStyle(TextServer.FontStyle style)
    {
        NativeCalls.godot_icall_1_38(MethodBind6, GodotObject.GetPtr(this), (int)style);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFontWeight, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFontWeight(int weight)
    {
        NativeCalls.godot_icall_1_38(MethodBind7, GodotObject.GetPtr(this), weight);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFontStretch, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFontStretch(int stretch)
    {
        NativeCalls.godot_icall_1_38(MethodBind8, GodotObject.GetPtr(this), stretch);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAntialiasing, 1669900ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAntialiasing(TextServer.FontAntialiasing antialiasing)
    {
        NativeCalls.godot_icall_1_38(MethodBind9, GodotObject.GetPtr(this), (int)antialiasing);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAntialiasing, 4262718649ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public TextServer.FontAntialiasing GetAntialiasing()
    {
        return (TextServer.FontAntialiasing)NativeCalls.godot_icall_0_39(MethodBind10, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDisableEmbeddedBitmaps, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDisableEmbeddedBitmaps(bool disableEmbeddedBitmaps)
    {
        NativeCalls.godot_icall_1_14(MethodBind11, GodotObject.GetPtr(this), disableEmbeddedBitmaps.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDisableEmbeddedBitmaps, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetDisableEmbeddedBitmaps()
    {
        return NativeCalls.godot_icall_0_15(MethodBind12, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetGenerateMipmaps, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetGenerateMipmaps(bool generateMipmaps)
    {
        NativeCalls.godot_icall_1_14(MethodBind13, GodotObject.GetPtr(this), generateMipmaps.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetGenerateMipmaps, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetGenerateMipmaps()
    {
        return NativeCalls.godot_icall_0_15(MethodBind14, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMultichannelSignedDistanceField, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMultichannelSignedDistanceField(bool msdf)
    {
        NativeCalls.godot_icall_1_14(MethodBind15, GodotObject.GetPtr(this), msdf.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsMultichannelSignedDistanceField, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsMultichannelSignedDistanceField()
    {
        return NativeCalls.godot_icall_0_15(MethodBind16, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMsdfPixelRange, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMsdfPixelRange(int msdfPixelRange)
    {
        NativeCalls.godot_icall_1_38(MethodBind17, GodotObject.GetPtr(this), msdfPixelRange);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMsdfPixelRange, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetMsdfPixelRange()
    {
        return NativeCalls.godot_icall_0_39(MethodBind18, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMsdfSize, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMsdfSize(int msdfSize)
    {
        NativeCalls.godot_icall_1_38(MethodBind19, GodotObject.GetPtr(this), msdfSize);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMsdfSize, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetMsdfSize()
    {
        return NativeCalls.godot_icall_0_39(MethodBind20, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFixedSize, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFixedSize(int fixedSize)
    {
        NativeCalls.godot_icall_1_38(MethodBind21, GodotObject.GetPtr(this), fixedSize);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFixedSize, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetFixedSize()
    {
        return NativeCalls.godot_icall_0_39(MethodBind22, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFixedSizeScaleMode, 1660989956ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFixedSizeScaleMode(TextServer.FixedSizeScaleMode fixedSizeScaleMode)
    {
        NativeCalls.godot_icall_1_38(MethodBind23, GodotObject.GetPtr(this), (int)fixedSizeScaleMode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFixedSizeScaleMode, 753873478ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public TextServer.FixedSizeScaleMode GetFixedSizeScaleMode()
    {
        return (TextServer.FixedSizeScaleMode)NativeCalls.godot_icall_0_39(MethodBind24, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAllowSystemFallback, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAllowSystemFallback(bool allowSystemFallback)
    {
        NativeCalls.godot_icall_1_14(MethodBind25, GodotObject.GetPtr(this), allowSystemFallback.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsAllowSystemFallback, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsAllowSystemFallback()
    {
        return NativeCalls.godot_icall_0_15(MethodBind26, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetForceAutohinter, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetForceAutohinter(bool forceAutohinter)
    {
        NativeCalls.godot_icall_1_14(MethodBind27, GodotObject.GetPtr(this), forceAutohinter.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsForceAutohinter, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsForceAutohinter()
    {
        return NativeCalls.godot_icall_0_15(MethodBind28, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetModulateColorGlyphs, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetModulateColorGlyphs(bool modulate)
    {
        NativeCalls.godot_icall_1_14(MethodBind29, GodotObject.GetPtr(this), modulate.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsModulateColorGlyphs, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsModulateColorGlyphs()
    {
        return NativeCalls.godot_icall_0_15(MethodBind30, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetHinting, 1827459492ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetHinting(TextServer.Hinting hinting)
    {
        NativeCalls.godot_icall_1_38(MethodBind31, GodotObject.GetPtr(this), (int)hinting);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind32 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetHinting, 3683214614ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public TextServer.Hinting GetHinting()
    {
        return (TextServer.Hinting)NativeCalls.godot_icall_0_39(MethodBind32, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind33 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSubpixelPositioning, 4225742182ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSubpixelPositioning(TextServer.SubpixelPositioning subpixelPositioning)
    {
        NativeCalls.godot_icall_1_38(MethodBind33, GodotObject.GetPtr(this), (int)subpixelPositioning);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind34 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSubpixelPositioning, 1069238588ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public TextServer.SubpixelPositioning GetSubpixelPositioning()
    {
        return (TextServer.SubpixelPositioning)NativeCalls.godot_icall_0_39(MethodBind34, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind35 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetKeepRoundingRemainders, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetKeepRoundingRemainders(bool keepRoundingRemainders)
    {
        NativeCalls.godot_icall_1_14(MethodBind35, GodotObject.GetPtr(this), keepRoundingRemainders.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind36 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetKeepRoundingRemainders, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetKeepRoundingRemainders()
    {
        return NativeCalls.godot_icall_0_15(MethodBind36, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind37 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetOversampling, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetOversampling(float oversampling)
    {
        NativeCalls.godot_icall_1_67(MethodBind37, GodotObject.GetPtr(this), oversampling);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind38 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOversampling, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetOversampling()
    {
        return NativeCalls.godot_icall_0_68(MethodBind38, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind39 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCacheCount, 3905245786ul);

    /// <summary>
    /// <para>Returns number of the font cache entries.</para>
    /// </summary>
    public int GetCacheCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind39, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind40 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ClearCache, 3218959716ul);

    /// <summary>
    /// <para>Removes all font cache entries.</para>
    /// </summary>
    public void ClearCache()
    {
        NativeCalls.godot_icall_0_3(MethodBind40, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind41 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveCache, 1286410249ul);

    /// <summary>
    /// <para>Removes specified font cache entry.</para>
    /// </summary>
    public void RemoveCache(int cacheIndex)
    {
        NativeCalls.godot_icall_1_38(MethodBind41, GodotObject.GetPtr(this), cacheIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind42 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSizeCacheList, 663333327ul);

    /// <summary>
    /// <para>Returns list of the font sizes in the cache. Each size is <see cref="Godot.Vector2I"/> with font size and outline size.</para>
    /// </summary>
    public Godot.Collections.Array<Vector2I> GetSizeCacheList(int cacheIndex)
    {
        return new Godot.Collections.Array<Vector2I>(NativeCalls.godot_icall_1_457(MethodBind42, GodotObject.GetPtr(this), cacheIndex));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind43 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ClearSizeCache, 1286410249ul);

    /// <summary>
    /// <para>Removes all font sizes from the cache entry.</para>
    /// </summary>
    public void ClearSizeCache(int cacheIndex)
    {
        NativeCalls.godot_icall_1_38(MethodBind43, GodotObject.GetPtr(this), cacheIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind44 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveSizeCache, 2311374912ul);

    /// <summary>
    /// <para>Removes specified font size from the cache entry.</para>
    /// </summary>
    public unsafe void RemoveSizeCache(int cacheIndex, Vector2I size)
    {
        NativeCalls.godot_icall_2_605(MethodBind44, GodotObject.GetPtr(this), cacheIndex, &size);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind45 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVariationCoordinates, 64545446ul);

    /// <summary>
    /// <para>Sets variation coordinates for the specified font cache entry. See <see cref="Godot.Font.GetSupportedVariationList()"/> for more info.</para>
    /// </summary>
    public void SetVariationCoordinates(int cacheIndex, Godot.Collections.Dictionary variationCoordinates)
    {
        NativeCalls.godot_icall_2_606(MethodBind45, GodotObject.GetPtr(this), cacheIndex, (godot_dictionary)(variationCoordinates ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind46 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVariationCoordinates, 3485342025ul);

    /// <summary>
    /// <para>Returns variation coordinates for the specified font cache entry. See <see cref="Godot.Font.GetSupportedVariationList()"/> for more info.</para>
    /// </summary>
    public Godot.Collections.Dictionary GetVariationCoordinates(int cacheIndex)
    {
        return NativeCalls.godot_icall_1_307(MethodBind46, GodotObject.GetPtr(this), cacheIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind47 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEmbolden, 1602489585ul);

    /// <summary>
    /// <para>Sets embolden strength, if is not equal to zero, emboldens the font outlines. Negative values reduce the outline thickness.</para>
    /// </summary>
    public void SetEmbolden(int cacheIndex, float strength)
    {
        NativeCalls.godot_icall_2_69(MethodBind47, GodotObject.GetPtr(this), cacheIndex, strength);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind48 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEmbolden, 2339986948ul);

    /// <summary>
    /// <para>Returns embolden strength, if is not equal to zero, emboldens the font outlines. Negative values reduce the outline thickness.</para>
    /// </summary>
    public float GetEmbolden(int cacheIndex)
    {
        return NativeCalls.godot_icall_1_72(MethodBind48, GodotObject.GetPtr(this), cacheIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind49 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTransform, 30160968ul);

    /// <summary>
    /// <para>Sets 2D transform, applied to the font outlines, can be used for slanting, flipping, and rotating glyphs.</para>
    /// </summary>
    public unsafe void SetTransform(int cacheIndex, Transform2D transform)
    {
        NativeCalls.godot_icall_2_607(MethodBind49, GodotObject.GetPtr(this), cacheIndex, &transform);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind50 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTransform, 3836996910ul);

    /// <summary>
    /// <para>Returns 2D transform, applied to the font outlines, can be used for slanting, flipping and rotating glyphs.</para>
    /// </summary>
    public Transform2D GetTransform(int cacheIndex)
    {
        return NativeCalls.godot_icall_1_608(MethodBind50, GodotObject.GetPtr(this), cacheIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind51 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetExtraSpacing, 62942285ul);

    /// <summary>
    /// <para>Sets the spacing for <paramref name="spacing"/> to <paramref name="value"/> in pixels (not relative to the font size).</para>
    /// </summary>
    public void SetExtraSpacing(int cacheIndex, TextServer.SpacingType spacing, long value)
    {
        NativeCalls.godot_icall_3_609(MethodBind51, GodotObject.GetPtr(this), cacheIndex, (int)spacing, value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind52 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetExtraSpacing, 1924257185ul);

    /// <summary>
    /// <para>Returns spacing for <paramref name="spacing"/> in pixels (not relative to the font size).</para>
    /// </summary>
    public long GetExtraSpacing(int cacheIndex, TextServer.SpacingType spacing)
    {
        return NativeCalls.godot_icall_2_410(MethodBind52, GodotObject.GetPtr(this), cacheIndex, (int)spacing);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind53 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetExtraBaselineOffset, 1602489585ul);

    /// <summary>
    /// <para>Sets extra baseline offset (as a fraction of font height).</para>
    /// </summary>
    public void SetExtraBaselineOffset(int cacheIndex, float baselineOffset)
    {
        NativeCalls.godot_icall_2_69(MethodBind53, GodotObject.GetPtr(this), cacheIndex, baselineOffset);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind54 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetExtraBaselineOffset, 2339986948ul);

    /// <summary>
    /// <para>Returns extra baseline offset (as a fraction of font height).</para>
    /// </summary>
    public float GetExtraBaselineOffset(int cacheIndex)
    {
        return NativeCalls.godot_icall_1_72(MethodBind54, GodotObject.GetPtr(this), cacheIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind55 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFaceIndex, 3937882851ul);

    /// <summary>
    /// <para>Sets an active face index in the TrueType / OpenType collection.</para>
    /// </summary>
    public void SetFaceIndex(int cacheIndex, long faceIndex)
    {
        NativeCalls.godot_icall_2_610(MethodBind55, GodotObject.GetPtr(this), cacheIndex, faceIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind56 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFaceIndex, 923996154ul);

    /// <summary>
    /// <para>Returns an active face index in the TrueType / OpenType collection.</para>
    /// </summary>
    public long GetFaceIndex(int cacheIndex)
    {
        return NativeCalls.godot_icall_1_611(MethodBind56, GodotObject.GetPtr(this), cacheIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind57 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCacheAscent, 3506521499ul);

    /// <summary>
    /// <para>Sets the font ascent (number of pixels above the baseline).</para>
    /// </summary>
    public void SetCacheAscent(int cacheIndex, int size, float ascent)
    {
        NativeCalls.godot_icall_3_86(MethodBind57, GodotObject.GetPtr(this), cacheIndex, size, ascent);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind58 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCacheAscent, 3085491603ul);

    /// <summary>
    /// <para>Returns the font ascent (number of pixels above the baseline).</para>
    /// </summary>
    public float GetCacheAscent(int cacheIndex, int size)
    {
        return NativeCalls.godot_icall_2_88(MethodBind58, GodotObject.GetPtr(this), cacheIndex, size);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind59 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCacheDescent, 3506521499ul);

    /// <summary>
    /// <para>Sets the font descent (number of pixels below the baseline).</para>
    /// </summary>
    public void SetCacheDescent(int cacheIndex, int size, float descent)
    {
        NativeCalls.godot_icall_3_86(MethodBind59, GodotObject.GetPtr(this), cacheIndex, size, descent);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind60 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCacheDescent, 3085491603ul);

    /// <summary>
    /// <para>Returns the font descent (number of pixels below the baseline).</para>
    /// </summary>
    public float GetCacheDescent(int cacheIndex, int size)
    {
        return NativeCalls.godot_icall_2_88(MethodBind60, GodotObject.GetPtr(this), cacheIndex, size);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind61 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCacheUnderlinePosition, 3506521499ul);

    /// <summary>
    /// <para>Sets pixel offset of the underline below the baseline.</para>
    /// </summary>
    public void SetCacheUnderlinePosition(int cacheIndex, int size, float underlinePosition)
    {
        NativeCalls.godot_icall_3_86(MethodBind61, GodotObject.GetPtr(this), cacheIndex, size, underlinePosition);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind62 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCacheUnderlinePosition, 3085491603ul);

    /// <summary>
    /// <para>Returns pixel offset of the underline below the baseline.</para>
    /// </summary>
    public float GetCacheUnderlinePosition(int cacheIndex, int size)
    {
        return NativeCalls.godot_icall_2_88(MethodBind62, GodotObject.GetPtr(this), cacheIndex, size);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind63 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCacheUnderlineThickness, 3506521499ul);

    /// <summary>
    /// <para>Sets thickness of the underline in pixels.</para>
    /// </summary>
    public void SetCacheUnderlineThickness(int cacheIndex, int size, float underlineThickness)
    {
        NativeCalls.godot_icall_3_86(MethodBind63, GodotObject.GetPtr(this), cacheIndex, size, underlineThickness);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind64 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCacheUnderlineThickness, 3085491603ul);

    /// <summary>
    /// <para>Returns thickness of the underline in pixels.</para>
    /// </summary>
    public float GetCacheUnderlineThickness(int cacheIndex, int size)
    {
        return NativeCalls.godot_icall_2_88(MethodBind64, GodotObject.GetPtr(this), cacheIndex, size);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind65 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCacheScale, 3506521499ul);

    /// <summary>
    /// <para>Sets scaling factor of the color bitmap font.</para>
    /// </summary>
    public void SetCacheScale(int cacheIndex, int size, float scale)
    {
        NativeCalls.godot_icall_3_86(MethodBind65, GodotObject.GetPtr(this), cacheIndex, size, scale);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind66 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCacheScale, 3085491603ul);

    /// <summary>
    /// <para>Returns scaling factor of the color bitmap font.</para>
    /// </summary>
    public float GetCacheScale(int cacheIndex, int size)
    {
        return NativeCalls.godot_icall_2_88(MethodBind66, GodotObject.GetPtr(this), cacheIndex, size);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind67 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTextureCount, 1987661582ul);

    /// <summary>
    /// <para>Returns number of textures used by font cache entry.</para>
    /// </summary>
    public unsafe int GetTextureCount(int cacheIndex, Vector2I size)
    {
        return NativeCalls.godot_icall_2_612(MethodBind67, GodotObject.GetPtr(this), cacheIndex, &size);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind68 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ClearTextures, 2311374912ul);

    /// <summary>
    /// <para>Removes all textures from font cache entry.</para>
    /// <para><b>Note:</b> This function will not remove glyphs associated with the texture, use <see cref="Godot.FontFile.RemoveGlyph(int, Vector2I, int)"/> to remove them manually.</para>
    /// </summary>
    public unsafe void ClearTextures(int cacheIndex, Vector2I size)
    {
        NativeCalls.godot_icall_2_605(MethodBind68, GodotObject.GetPtr(this), cacheIndex, &size);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind69 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveTexture, 2328951467ul);

    /// <summary>
    /// <para>Removes specified texture from the cache entry.</para>
    /// <para><b>Note:</b> This function will not remove glyphs associated with the texture. Remove them manually using <see cref="Godot.FontFile.RemoveGlyph(int, Vector2I, int)"/>.</para>
    /// </summary>
    public unsafe void RemoveTexture(int cacheIndex, Vector2I size, int textureIndex)
    {
        NativeCalls.godot_icall_3_613(MethodBind69, GodotObject.GetPtr(this), cacheIndex, &size, textureIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind70 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTextureImage, 4157974066ul);

    /// <summary>
    /// <para>Sets font cache texture image.</para>
    /// </summary>
    public unsafe void SetTextureImage(int cacheIndex, Vector2I size, int textureIndex, Image image)
    {
        NativeCalls.godot_icall_4_614(MethodBind70, GodotObject.GetPtr(this), cacheIndex, &size, textureIndex, GodotObject.GetPtr(image));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind71 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTextureImage, 3878418953ul);

    /// <summary>
    /// <para>Returns a copy of the font cache texture image.</para>
    /// </summary>
    public unsafe Image GetTextureImage(int cacheIndex, Vector2I size, int textureIndex)
    {
        return (Image)NativeCalls.godot_icall_3_615(MethodBind71, GodotObject.GetPtr(this), cacheIndex, &size, textureIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind72 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTextureOffsets, 2849993437ul);

    /// <summary>
    /// <para>Sets array containing glyph packing data.</para>
    /// </summary>
    public unsafe void SetTextureOffsets(int cacheIndex, Vector2I size, int textureIndex, int[] offset)
    {
        NativeCalls.godot_icall_4_616(MethodBind72, GodotObject.GetPtr(this), cacheIndex, &size, textureIndex, offset);
    }

    /// <summary>
    /// <para>Sets array containing glyph packing data.</para>
    /// </summary>
    public unsafe void SetTextureOffsets(int cacheIndex, Vector2I size, int textureIndex, ReadOnlySpan<int> offset)
    {
        NativeCalls.godot_icall_4_616(MethodBind72, GodotObject.GetPtr(this), cacheIndex, &size, textureIndex, offset);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind73 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTextureOffsets, 3703444828ul);

    /// <summary>
    /// <para>Returns a copy of the array containing glyph packing data.</para>
    /// </summary>
    public unsafe int[] GetTextureOffsets(int cacheIndex, Vector2I size, int textureIndex)
    {
        return NativeCalls.godot_icall_3_617(MethodBind73, GodotObject.GetPtr(this), cacheIndex, &size, textureIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind74 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetGlyphList, 681709689ul);

    /// <summary>
    /// <para>Returns list of rendered glyphs in the cache entry.</para>
    /// </summary>
    public unsafe int[] GetGlyphList(int cacheIndex, Vector2I size)
    {
        return NativeCalls.godot_icall_2_618(MethodBind74, GodotObject.GetPtr(this), cacheIndex, &size);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind75 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ClearGlyphs, 2311374912ul);

    /// <summary>
    /// <para>Removes all rendered glyph information from the cache entry.</para>
    /// <para><b>Note:</b> This function will not remove textures associated with the glyphs, use <see cref="Godot.FontFile.RemoveTexture(int, Vector2I, int)"/> to remove them manually.</para>
    /// </summary>
    public unsafe void ClearGlyphs(int cacheIndex, Vector2I size)
    {
        NativeCalls.godot_icall_2_605(MethodBind75, GodotObject.GetPtr(this), cacheIndex, &size);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind76 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveGlyph, 2328951467ul);

    /// <summary>
    /// <para>Removes specified rendered glyph information from the cache entry.</para>
    /// <para><b>Note:</b> This function will not remove textures associated with the glyphs, use <see cref="Godot.FontFile.RemoveTexture(int, Vector2I, int)"/> to remove them manually.</para>
    /// </summary>
    public unsafe void RemoveGlyph(int cacheIndex, Vector2I size, int glyph)
    {
        NativeCalls.godot_icall_3_613(MethodBind76, GodotObject.GetPtr(this), cacheIndex, &size, glyph);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind77 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetGlyphAdvance, 947991729ul);

    /// <summary>
    /// <para>Sets glyph advance (offset of the next glyph).</para>
    /// <para><b>Note:</b> Advance for glyphs outlines is the same as the base glyph advance and is not saved.</para>
    /// </summary>
    public unsafe void SetGlyphAdvance(int cacheIndex, int size, int glyph, Vector2 advance)
    {
        NativeCalls.godot_icall_4_619(MethodBind77, GodotObject.GetPtr(this), cacheIndex, size, glyph, &advance);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind78 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetGlyphAdvance, 1601573536ul);

    /// <summary>
    /// <para>Returns glyph advance (offset of the next glyph).</para>
    /// <para><b>Note:</b> Advance for glyphs outlines is the same as the base glyph advance and is not saved.</para>
    /// </summary>
    public Vector2 GetGlyphAdvance(int cacheIndex, int size, int glyph)
    {
        return NativeCalls.godot_icall_3_620(MethodBind78, GodotObject.GetPtr(this), cacheIndex, size, glyph);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind79 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetGlyphOffset, 921719850ul);

    /// <summary>
    /// <para>Sets glyph offset from the baseline.</para>
    /// </summary>
    public unsafe void SetGlyphOffset(int cacheIndex, Vector2I size, int glyph, Vector2 offset)
    {
        NativeCalls.godot_icall_4_621(MethodBind79, GodotObject.GetPtr(this), cacheIndex, &size, glyph, &offset);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind80 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetGlyphOffset, 3205412300ul);

    /// <summary>
    /// <para>Returns glyph offset from the baseline.</para>
    /// </summary>
    public unsafe Vector2 GetGlyphOffset(int cacheIndex, Vector2I size, int glyph)
    {
        return NativeCalls.godot_icall_3_622(MethodBind80, GodotObject.GetPtr(this), cacheIndex, &size, glyph);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind81 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetGlyphSize, 921719850ul);

    /// <summary>
    /// <para>Sets glyph size.</para>
    /// </summary>
    public unsafe void SetGlyphSize(int cacheIndex, Vector2I size, int glyph, Vector2 glSize)
    {
        NativeCalls.godot_icall_4_621(MethodBind81, GodotObject.GetPtr(this), cacheIndex, &size, glyph, &glSize);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind82 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetGlyphSize, 3205412300ul);

    /// <summary>
    /// <para>Returns glyph size.</para>
    /// </summary>
    public unsafe Vector2 GetGlyphSize(int cacheIndex, Vector2I size, int glyph)
    {
        return NativeCalls.godot_icall_3_622(MethodBind82, GodotObject.GetPtr(this), cacheIndex, &size, glyph);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind83 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetGlyphUVRect, 3821620992ul);

    /// <summary>
    /// <para>Sets rectangle in the cache texture containing the glyph.</para>
    /// </summary>
    public unsafe void SetGlyphUVRect(int cacheIndex, Vector2I size, int glyph, Rect2 uVRect)
    {
        NativeCalls.godot_icall_4_623(MethodBind83, GodotObject.GetPtr(this), cacheIndex, &size, glyph, &uVRect);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind84 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetGlyphUVRect, 3927917900ul);

    /// <summary>
    /// <para>Returns rectangle in the cache texture containing the glyph.</para>
    /// </summary>
    public unsafe Rect2 GetGlyphUVRect(int cacheIndex, Vector2I size, int glyph)
    {
        return NativeCalls.godot_icall_3_624(MethodBind84, GodotObject.GetPtr(this), cacheIndex, &size, glyph);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind85 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetGlyphTextureIdx, 355564111ul);

    /// <summary>
    /// <para>Sets index of the cache texture containing the glyph.</para>
    /// </summary>
    public unsafe void SetGlyphTextureIdx(int cacheIndex, Vector2I size, int glyph, int textureIdx)
    {
        NativeCalls.godot_icall_4_625(MethodBind85, GodotObject.GetPtr(this), cacheIndex, &size, glyph, textureIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind86 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetGlyphTextureIdx, 1629411054ul);

    /// <summary>
    /// <para>Returns index of the cache texture containing the glyph.</para>
    /// </summary>
    public unsafe int GetGlyphTextureIdx(int cacheIndex, Vector2I size, int glyph)
    {
        return NativeCalls.godot_icall_3_626(MethodBind86, GodotObject.GetPtr(this), cacheIndex, &size, glyph);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind87 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetKerningList, 2345056839ul);

    /// <summary>
    /// <para>Returns list of the kerning overrides.</para>
    /// </summary>
    public Godot.Collections.Array<Vector2I> GetKerningList(int cacheIndex, int size)
    {
        return new Godot.Collections.Array<Vector2I>(NativeCalls.godot_icall_2_94(MethodBind87, GodotObject.GetPtr(this), cacheIndex, size));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind88 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ClearKerningMap, 3937882851ul);

    /// <summary>
    /// <para>Removes all kerning overrides.</para>
    /// </summary>
    public void ClearKerningMap(int cacheIndex, int size)
    {
        NativeCalls.godot_icall_2_59(MethodBind88, GodotObject.GetPtr(this), cacheIndex, size);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind89 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveKerning, 3930204747ul);

    /// <summary>
    /// <para>Removes kerning override for the pair of glyphs.</para>
    /// </summary>
    public unsafe void RemoveKerning(int cacheIndex, int size, Vector2I glyphPair)
    {
        NativeCalls.godot_icall_3_627(MethodBind89, GodotObject.GetPtr(this), cacheIndex, size, &glyphPair);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind90 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetKerning, 3182200918ul);

    /// <summary>
    /// <para>Sets kerning for the pair of glyphs.</para>
    /// </summary>
    public unsafe void SetKerning(int cacheIndex, int size, Vector2I glyphPair, Vector2 kerning)
    {
        NativeCalls.godot_icall_4_628(MethodBind90, GodotObject.GetPtr(this), cacheIndex, size, &glyphPair, &kerning);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind91 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetKerning, 1611912865ul);

    /// <summary>
    /// <para>Returns kerning for the pair of glyphs.</para>
    /// </summary>
    public unsafe Vector2 GetKerning(int cacheIndex, int size, Vector2I glyphPair)
    {
        return NativeCalls.godot_icall_3_629(MethodBind91, GodotObject.GetPtr(this), cacheIndex, size, &glyphPair);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind92 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RenderRange, 355564111ul);

    /// <summary>
    /// <para>Renders the range of characters to the font cache texture.</para>
    /// </summary>
    public unsafe void RenderRange(int cacheIndex, Vector2I size, long start, long end)
    {
        NativeCalls.godot_icall_4_630(MethodBind92, GodotObject.GetPtr(this), cacheIndex, &size, start, end);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind93 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RenderGlyph, 2328951467ul);

    /// <summary>
    /// <para>Renders specified glyph to the font cache texture.</para>
    /// </summary>
    public unsafe void RenderGlyph(int cacheIndex, Vector2I size, int index)
    {
        NativeCalls.godot_icall_3_613(MethodBind93, GodotObject.GetPtr(this), cacheIndex, &size, index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind94 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLanguageSupportOverride, 2678287736ul);

    /// <summary>
    /// <para>Adds override for <see cref="Godot.Font.IsLanguageSupported(string)"/>.</para>
    /// </summary>
    public void SetLanguageSupportOverride(string language, bool supported)
    {
        NativeCalls.godot_icall_2_497(MethodBind94, GodotObject.GetPtr(this), language, supported.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind95 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLanguageSupportOverride, 3927539163ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if support override is enabled for the <paramref name="language"/>.</para>
    /// </summary>
    public bool GetLanguageSupportOverride(string language)
    {
        return NativeCalls.godot_icall_1_131(MethodBind95, GodotObject.GetPtr(this), language).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind96 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveLanguageSupportOverride, 83702148ul);

    /// <summary>
    /// <para>Remove language support override.</para>
    /// </summary>
    public void RemoveLanguageSupportOverride(string language)
    {
        NativeCalls.godot_icall_1_57(MethodBind96, GodotObject.GetPtr(this), language);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind97 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLanguageSupportOverrides, 1139954409ul);

    /// <summary>
    /// <para>Returns list of language support overrides.</para>
    /// </summary>
    public string[] GetLanguageSupportOverrides()
    {
        return NativeCalls.godot_icall_0_108(MethodBind97, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind98 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetScriptSupportOverride, 2678287736ul);

    /// <summary>
    /// <para>Adds override for <see cref="Godot.Font.IsScriptSupported(string)"/>.</para>
    /// </summary>
    public void SetScriptSupportOverride(string script, bool supported)
    {
        NativeCalls.godot_icall_2_497(MethodBind98, GodotObject.GetPtr(this), script, supported.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind99 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetScriptSupportOverride, 3927539163ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if support override is enabled for the <paramref name="script"/>.</para>
    /// </summary>
    public bool GetScriptSupportOverride(string script)
    {
        return NativeCalls.godot_icall_1_131(MethodBind99, GodotObject.GetPtr(this), script).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind100 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveScriptSupportOverride, 83702148ul);

    /// <summary>
    /// <para>Removes script support override.</para>
    /// </summary>
    public void RemoveScriptSupportOverride(string script)
    {
        NativeCalls.godot_icall_1_57(MethodBind100, GodotObject.GetPtr(this), script);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind101 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetScriptSupportOverrides, 1139954409ul);

    /// <summary>
    /// <para>Returns list of script support overrides.</para>
    /// </summary>
    public string[] GetScriptSupportOverrides()
    {
        return NativeCalls.godot_icall_0_108(MethodBind101, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind102 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetOpentypeFeatureOverrides, 4155329257ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetOpentypeFeatureOverrides(Godot.Collections.Dictionary overrides)
    {
        NativeCalls.godot_icall_1_121(MethodBind102, GodotObject.GetPtr(this), (godot_dictionary)(overrides ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind103 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOpentypeFeatureOverrides, 3102165223ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Godot.Collections.Dictionary GetOpentypeFeatureOverrides()
    {
        return NativeCalls.godot_icall_0_122(MethodBind103, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind104 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetGlyphIndex, 864943070ul);

    /// <summary>
    /// <para>Returns the glyph index of a <paramref name="char"/>, optionally modified by the <paramref name="variationSelector"/>.</para>
    /// </summary>
    public int GetGlyphIndex(int size, long @char, long variationSelector)
    {
        return NativeCalls.godot_icall_3_631(MethodBind104, GodotObject.GetPtr(this), size, @char, variationSelector);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind105 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCharFromGlyphIndex, 3175239445ul);

    /// <summary>
    /// <para>Returns character code associated with <paramref name="glyphIndex"/>, or <c>0</c> if <paramref name="glyphIndex"/> is invalid. See <see cref="Godot.FontFile.GetGlyphIndex(int, long, long)"/>.</para>
    /// </summary>
    public long GetCharFromGlyphIndex(int size, int glyphIndex)
    {
        return NativeCalls.godot_icall_2_410(MethodBind105, GodotObject.GetPtr(this), size, glyphIndex);
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
    public new class PropertyName : Font.PropertyName
    {
        /// <summary>
        /// Cached name for the 'data' property.
        /// </summary>
        public static readonly StringName Data = "data";
        /// <summary>
        /// Cached name for the 'generate_mipmaps' property.
        /// </summary>
        public static readonly StringName GenerateMipmaps = "generate_mipmaps";
        /// <summary>
        /// Cached name for the 'disable_embedded_bitmaps' property.
        /// </summary>
        public static readonly StringName DisableEmbeddedBitmaps = "disable_embedded_bitmaps";
        /// <summary>
        /// Cached name for the 'antialiasing' property.
        /// </summary>
        public static readonly StringName Antialiasing = "antialiasing";
        /// <summary>
        /// Cached name for the 'font_name' property.
        /// </summary>
        public static readonly StringName FontName = "font_name";
        /// <summary>
        /// Cached name for the 'style_name' property.
        /// </summary>
        public static readonly StringName StyleName = "style_name";
        /// <summary>
        /// Cached name for the 'font_style' property.
        /// </summary>
        public static readonly StringName FontStyle = "font_style";
        /// <summary>
        /// Cached name for the 'font_weight' property.
        /// </summary>
        public static readonly StringName FontWeight = "font_weight";
        /// <summary>
        /// Cached name for the 'font_stretch' property.
        /// </summary>
        public static readonly StringName FontStretch = "font_stretch";
        /// <summary>
        /// Cached name for the 'subpixel_positioning' property.
        /// </summary>
        public static readonly StringName SubpixelPositioning = "subpixel_positioning";
        /// <summary>
        /// Cached name for the 'keep_rounding_remainders' property.
        /// </summary>
        public static readonly StringName KeepRoundingRemainders = "keep_rounding_remainders";
        /// <summary>
        /// Cached name for the 'multichannel_signed_distance_field' property.
        /// </summary>
        public static readonly StringName MultichannelSignedDistanceField = "multichannel_signed_distance_field";
        /// <summary>
        /// Cached name for the 'msdf_pixel_range' property.
        /// </summary>
        public static readonly StringName MsdfPixelRange = "msdf_pixel_range";
        /// <summary>
        /// Cached name for the 'msdf_size' property.
        /// </summary>
        public static readonly StringName MsdfSize = "msdf_size";
        /// <summary>
        /// Cached name for the 'allow_system_fallback' property.
        /// </summary>
        public static readonly StringName AllowSystemFallback = "allow_system_fallback";
        /// <summary>
        /// Cached name for the 'force_autohinter' property.
        /// </summary>
        public static readonly StringName ForceAutohinter = "force_autohinter";
        /// <summary>
        /// Cached name for the 'modulate_color_glyphs' property.
        /// </summary>
        public static readonly StringName ModulateColorGlyphs = "modulate_color_glyphs";
        /// <summary>
        /// Cached name for the 'hinting' property.
        /// </summary>
        public static readonly StringName Hinting = "hinting";
        /// <summary>
        /// Cached name for the 'fixed_size' property.
        /// </summary>
        public static readonly StringName FixedSize = "fixed_size";
        /// <summary>
        /// Cached name for the 'fixed_size_scale_mode' property.
        /// </summary>
        public static readonly StringName FixedSizeScaleMode = "fixed_size_scale_mode";
        /// <summary>
        /// Cached name for the 'opentype_feature_overrides' property.
        /// </summary>
        public static readonly StringName OpentypeFeatureOverrides = "opentype_feature_overrides";
        /// <summary>
        /// Cached name for the 'oversampling' property.
        /// </summary>
        public static readonly StringName Oversampling = "oversampling";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Font.MethodName
    {
        /// <summary>
        /// Cached name for the 'load_bitmap_font' method.
        /// </summary>
        public static readonly StringName LoadBitmapFont = "load_bitmap_font";
        /// <summary>
        /// Cached name for the 'load_dynamic_font' method.
        /// </summary>
        public static readonly StringName LoadDynamicFont = "load_dynamic_font";
        /// <summary>
        /// Cached name for the 'set_data' method.
        /// </summary>
        public static readonly StringName SetData = "set_data";
        /// <summary>
        /// Cached name for the 'get_data' method.
        /// </summary>
        public static readonly StringName GetData = "get_data";
        /// <summary>
        /// Cached name for the 'set_font_name' method.
        /// </summary>
        public static readonly StringName SetFontName = "set_font_name";
        /// <summary>
        /// Cached name for the 'set_font_style_name' method.
        /// </summary>
        public static readonly StringName SetFontStyleName = "set_font_style_name";
        /// <summary>
        /// Cached name for the 'set_font_style' method.
        /// </summary>
        public static readonly StringName SetFontStyle = "set_font_style";
        /// <summary>
        /// Cached name for the 'set_font_weight' method.
        /// </summary>
        public static readonly StringName SetFontWeight = "set_font_weight";
        /// <summary>
        /// Cached name for the 'set_font_stretch' method.
        /// </summary>
        public static readonly StringName SetFontStretch = "set_font_stretch";
        /// <summary>
        /// Cached name for the 'set_antialiasing' method.
        /// </summary>
        public static readonly StringName SetAntialiasing = "set_antialiasing";
        /// <summary>
        /// Cached name for the 'get_antialiasing' method.
        /// </summary>
        public static readonly StringName GetAntialiasing = "get_antialiasing";
        /// <summary>
        /// Cached name for the 'set_disable_embedded_bitmaps' method.
        /// </summary>
        public static readonly StringName SetDisableEmbeddedBitmaps = "set_disable_embedded_bitmaps";
        /// <summary>
        /// Cached name for the 'get_disable_embedded_bitmaps' method.
        /// </summary>
        public static readonly StringName GetDisableEmbeddedBitmaps = "get_disable_embedded_bitmaps";
        /// <summary>
        /// Cached name for the 'set_generate_mipmaps' method.
        /// </summary>
        public static readonly StringName SetGenerateMipmaps = "set_generate_mipmaps";
        /// <summary>
        /// Cached name for the 'get_generate_mipmaps' method.
        /// </summary>
        public static readonly StringName GetGenerateMipmaps = "get_generate_mipmaps";
        /// <summary>
        /// Cached name for the 'set_multichannel_signed_distance_field' method.
        /// </summary>
        public static readonly StringName SetMultichannelSignedDistanceField = "set_multichannel_signed_distance_field";
        /// <summary>
        /// Cached name for the 'is_multichannel_signed_distance_field' method.
        /// </summary>
        public static readonly StringName IsMultichannelSignedDistanceField = "is_multichannel_signed_distance_field";
        /// <summary>
        /// Cached name for the 'set_msdf_pixel_range' method.
        /// </summary>
        public static readonly StringName SetMsdfPixelRange = "set_msdf_pixel_range";
        /// <summary>
        /// Cached name for the 'get_msdf_pixel_range' method.
        /// </summary>
        public static readonly StringName GetMsdfPixelRange = "get_msdf_pixel_range";
        /// <summary>
        /// Cached name for the 'set_msdf_size' method.
        /// </summary>
        public static readonly StringName SetMsdfSize = "set_msdf_size";
        /// <summary>
        /// Cached name for the 'get_msdf_size' method.
        /// </summary>
        public static readonly StringName GetMsdfSize = "get_msdf_size";
        /// <summary>
        /// Cached name for the 'set_fixed_size' method.
        /// </summary>
        public static readonly StringName SetFixedSize = "set_fixed_size";
        /// <summary>
        /// Cached name for the 'get_fixed_size' method.
        /// </summary>
        public static readonly StringName GetFixedSize = "get_fixed_size";
        /// <summary>
        /// Cached name for the 'set_fixed_size_scale_mode' method.
        /// </summary>
        public static readonly StringName SetFixedSizeScaleMode = "set_fixed_size_scale_mode";
        /// <summary>
        /// Cached name for the 'get_fixed_size_scale_mode' method.
        /// </summary>
        public static readonly StringName GetFixedSizeScaleMode = "get_fixed_size_scale_mode";
        /// <summary>
        /// Cached name for the 'set_allow_system_fallback' method.
        /// </summary>
        public static readonly StringName SetAllowSystemFallback = "set_allow_system_fallback";
        /// <summary>
        /// Cached name for the 'is_allow_system_fallback' method.
        /// </summary>
        public static readonly StringName IsAllowSystemFallback = "is_allow_system_fallback";
        /// <summary>
        /// Cached name for the 'set_force_autohinter' method.
        /// </summary>
        public static readonly StringName SetForceAutohinter = "set_force_autohinter";
        /// <summary>
        /// Cached name for the 'is_force_autohinter' method.
        /// </summary>
        public static readonly StringName IsForceAutohinter = "is_force_autohinter";
        /// <summary>
        /// Cached name for the 'set_modulate_color_glyphs' method.
        /// </summary>
        public static readonly StringName SetModulateColorGlyphs = "set_modulate_color_glyphs";
        /// <summary>
        /// Cached name for the 'is_modulate_color_glyphs' method.
        /// </summary>
        public static readonly StringName IsModulateColorGlyphs = "is_modulate_color_glyphs";
        /// <summary>
        /// Cached name for the 'set_hinting' method.
        /// </summary>
        public static readonly StringName SetHinting = "set_hinting";
        /// <summary>
        /// Cached name for the 'get_hinting' method.
        /// </summary>
        public static readonly StringName GetHinting = "get_hinting";
        /// <summary>
        /// Cached name for the 'set_subpixel_positioning' method.
        /// </summary>
        public static readonly StringName SetSubpixelPositioning = "set_subpixel_positioning";
        /// <summary>
        /// Cached name for the 'get_subpixel_positioning' method.
        /// </summary>
        public static readonly StringName GetSubpixelPositioning = "get_subpixel_positioning";
        /// <summary>
        /// Cached name for the 'set_keep_rounding_remainders' method.
        /// </summary>
        public static readonly StringName SetKeepRoundingRemainders = "set_keep_rounding_remainders";
        /// <summary>
        /// Cached name for the 'get_keep_rounding_remainders' method.
        /// </summary>
        public static readonly StringName GetKeepRoundingRemainders = "get_keep_rounding_remainders";
        /// <summary>
        /// Cached name for the 'set_oversampling' method.
        /// </summary>
        public static readonly StringName SetOversampling = "set_oversampling";
        /// <summary>
        /// Cached name for the 'get_oversampling' method.
        /// </summary>
        public static readonly StringName GetOversampling = "get_oversampling";
        /// <summary>
        /// Cached name for the 'get_cache_count' method.
        /// </summary>
        public static readonly StringName GetCacheCount = "get_cache_count";
        /// <summary>
        /// Cached name for the 'clear_cache' method.
        /// </summary>
        public static readonly StringName ClearCache = "clear_cache";
        /// <summary>
        /// Cached name for the 'remove_cache' method.
        /// </summary>
        public static readonly StringName RemoveCache = "remove_cache";
        /// <summary>
        /// Cached name for the 'get_size_cache_list' method.
        /// </summary>
        public static readonly StringName GetSizeCacheList = "get_size_cache_list";
        /// <summary>
        /// Cached name for the 'clear_size_cache' method.
        /// </summary>
        public static readonly StringName ClearSizeCache = "clear_size_cache";
        /// <summary>
        /// Cached name for the 'remove_size_cache' method.
        /// </summary>
        public static readonly StringName RemoveSizeCache = "remove_size_cache";
        /// <summary>
        /// Cached name for the 'set_variation_coordinates' method.
        /// </summary>
        public static readonly StringName SetVariationCoordinates = "set_variation_coordinates";
        /// <summary>
        /// Cached name for the 'get_variation_coordinates' method.
        /// </summary>
        public static readonly StringName GetVariationCoordinates = "get_variation_coordinates";
        /// <summary>
        /// Cached name for the 'set_embolden' method.
        /// </summary>
        public static readonly StringName SetEmbolden = "set_embolden";
        /// <summary>
        /// Cached name for the 'get_embolden' method.
        /// </summary>
        public static readonly StringName GetEmbolden = "get_embolden";
        /// <summary>
        /// Cached name for the 'set_transform' method.
        /// </summary>
        public static readonly StringName SetTransform = "set_transform";
        /// <summary>
        /// Cached name for the 'get_transform' method.
        /// </summary>
        public static readonly StringName GetTransform = "get_transform";
        /// <summary>
        /// Cached name for the 'set_extra_spacing' method.
        /// </summary>
        public static readonly StringName SetExtraSpacing = "set_extra_spacing";
        /// <summary>
        /// Cached name for the 'get_extra_spacing' method.
        /// </summary>
        public static readonly StringName GetExtraSpacing = "get_extra_spacing";
        /// <summary>
        /// Cached name for the 'set_extra_baseline_offset' method.
        /// </summary>
        public static readonly StringName SetExtraBaselineOffset = "set_extra_baseline_offset";
        /// <summary>
        /// Cached name for the 'get_extra_baseline_offset' method.
        /// </summary>
        public static readonly StringName GetExtraBaselineOffset = "get_extra_baseline_offset";
        /// <summary>
        /// Cached name for the 'set_face_index' method.
        /// </summary>
        public static readonly StringName SetFaceIndex = "set_face_index";
        /// <summary>
        /// Cached name for the 'get_face_index' method.
        /// </summary>
        public static readonly StringName GetFaceIndex = "get_face_index";
        /// <summary>
        /// Cached name for the 'set_cache_ascent' method.
        /// </summary>
        public static readonly StringName SetCacheAscent = "set_cache_ascent";
        /// <summary>
        /// Cached name for the 'get_cache_ascent' method.
        /// </summary>
        public static readonly StringName GetCacheAscent = "get_cache_ascent";
        /// <summary>
        /// Cached name for the 'set_cache_descent' method.
        /// </summary>
        public static readonly StringName SetCacheDescent = "set_cache_descent";
        /// <summary>
        /// Cached name for the 'get_cache_descent' method.
        /// </summary>
        public static readonly StringName GetCacheDescent = "get_cache_descent";
        /// <summary>
        /// Cached name for the 'set_cache_underline_position' method.
        /// </summary>
        public static readonly StringName SetCacheUnderlinePosition = "set_cache_underline_position";
        /// <summary>
        /// Cached name for the 'get_cache_underline_position' method.
        /// </summary>
        public static readonly StringName GetCacheUnderlinePosition = "get_cache_underline_position";
        /// <summary>
        /// Cached name for the 'set_cache_underline_thickness' method.
        /// </summary>
        public static readonly StringName SetCacheUnderlineThickness = "set_cache_underline_thickness";
        /// <summary>
        /// Cached name for the 'get_cache_underline_thickness' method.
        /// </summary>
        public static readonly StringName GetCacheUnderlineThickness = "get_cache_underline_thickness";
        /// <summary>
        /// Cached name for the 'set_cache_scale' method.
        /// </summary>
        public static readonly StringName SetCacheScale = "set_cache_scale";
        /// <summary>
        /// Cached name for the 'get_cache_scale' method.
        /// </summary>
        public static readonly StringName GetCacheScale = "get_cache_scale";
        /// <summary>
        /// Cached name for the 'get_texture_count' method.
        /// </summary>
        public static readonly StringName GetTextureCount = "get_texture_count";
        /// <summary>
        /// Cached name for the 'clear_textures' method.
        /// </summary>
        public static readonly StringName ClearTextures = "clear_textures";
        /// <summary>
        /// Cached name for the 'remove_texture' method.
        /// </summary>
        public static readonly StringName RemoveTexture = "remove_texture";
        /// <summary>
        /// Cached name for the 'set_texture_image' method.
        /// </summary>
        public static readonly StringName SetTextureImage = "set_texture_image";
        /// <summary>
        /// Cached name for the 'get_texture_image' method.
        /// </summary>
        public static readonly StringName GetTextureImage = "get_texture_image";
        /// <summary>
        /// Cached name for the 'set_texture_offsets' method.
        /// </summary>
        public static readonly StringName SetTextureOffsets = "set_texture_offsets";
        /// <summary>
        /// Cached name for the 'get_texture_offsets' method.
        /// </summary>
        public static readonly StringName GetTextureOffsets = "get_texture_offsets";
        /// <summary>
        /// Cached name for the 'get_glyph_list' method.
        /// </summary>
        public static readonly StringName GetGlyphList = "get_glyph_list";
        /// <summary>
        /// Cached name for the 'clear_glyphs' method.
        /// </summary>
        public static readonly StringName ClearGlyphs = "clear_glyphs";
        /// <summary>
        /// Cached name for the 'remove_glyph' method.
        /// </summary>
        public static readonly StringName RemoveGlyph = "remove_glyph";
        /// <summary>
        /// Cached name for the 'set_glyph_advance' method.
        /// </summary>
        public static readonly StringName SetGlyphAdvance = "set_glyph_advance";
        /// <summary>
        /// Cached name for the 'get_glyph_advance' method.
        /// </summary>
        public static readonly StringName GetGlyphAdvance = "get_glyph_advance";
        /// <summary>
        /// Cached name for the 'set_glyph_offset' method.
        /// </summary>
        public static readonly StringName SetGlyphOffset = "set_glyph_offset";
        /// <summary>
        /// Cached name for the 'get_glyph_offset' method.
        /// </summary>
        public static readonly StringName GetGlyphOffset = "get_glyph_offset";
        /// <summary>
        /// Cached name for the 'set_glyph_size' method.
        /// </summary>
        public static readonly StringName SetGlyphSize = "set_glyph_size";
        /// <summary>
        /// Cached name for the 'get_glyph_size' method.
        /// </summary>
        public static readonly StringName GetGlyphSize = "get_glyph_size";
        /// <summary>
        /// Cached name for the 'set_glyph_uv_rect' method.
        /// </summary>
        public static readonly StringName SetGlyphUVRect = "set_glyph_uv_rect";
        /// <summary>
        /// Cached name for the 'get_glyph_uv_rect' method.
        /// </summary>
        public static readonly StringName GetGlyphUVRect = "get_glyph_uv_rect";
        /// <summary>
        /// Cached name for the 'set_glyph_texture_idx' method.
        /// </summary>
        public static readonly StringName SetGlyphTextureIdx = "set_glyph_texture_idx";
        /// <summary>
        /// Cached name for the 'get_glyph_texture_idx' method.
        /// </summary>
        public static readonly StringName GetGlyphTextureIdx = "get_glyph_texture_idx";
        /// <summary>
        /// Cached name for the 'get_kerning_list' method.
        /// </summary>
        public static readonly StringName GetKerningList = "get_kerning_list";
        /// <summary>
        /// Cached name for the 'clear_kerning_map' method.
        /// </summary>
        public static readonly StringName ClearKerningMap = "clear_kerning_map";
        /// <summary>
        /// Cached name for the 'remove_kerning' method.
        /// </summary>
        public static readonly StringName RemoveKerning = "remove_kerning";
        /// <summary>
        /// Cached name for the 'set_kerning' method.
        /// </summary>
        public static readonly StringName SetKerning = "set_kerning";
        /// <summary>
        /// Cached name for the 'get_kerning' method.
        /// </summary>
        public static readonly StringName GetKerning = "get_kerning";
        /// <summary>
        /// Cached name for the 'render_range' method.
        /// </summary>
        public static readonly StringName RenderRange = "render_range";
        /// <summary>
        /// Cached name for the 'render_glyph' method.
        /// </summary>
        public static readonly StringName RenderGlyph = "render_glyph";
        /// <summary>
        /// Cached name for the 'set_language_support_override' method.
        /// </summary>
        public static readonly StringName SetLanguageSupportOverride = "set_language_support_override";
        /// <summary>
        /// Cached name for the 'get_language_support_override' method.
        /// </summary>
        public static readonly StringName GetLanguageSupportOverride = "get_language_support_override";
        /// <summary>
        /// Cached name for the 'remove_language_support_override' method.
        /// </summary>
        public static readonly StringName RemoveLanguageSupportOverride = "remove_language_support_override";
        /// <summary>
        /// Cached name for the 'get_language_support_overrides' method.
        /// </summary>
        public static readonly StringName GetLanguageSupportOverrides = "get_language_support_overrides";
        /// <summary>
        /// Cached name for the 'set_script_support_override' method.
        /// </summary>
        public static readonly StringName SetScriptSupportOverride = "set_script_support_override";
        /// <summary>
        /// Cached name for the 'get_script_support_override' method.
        /// </summary>
        public static readonly StringName GetScriptSupportOverride = "get_script_support_override";
        /// <summary>
        /// Cached name for the 'remove_script_support_override' method.
        /// </summary>
        public static readonly StringName RemoveScriptSupportOverride = "remove_script_support_override";
        /// <summary>
        /// Cached name for the 'get_script_support_overrides' method.
        /// </summary>
        public static readonly StringName GetScriptSupportOverrides = "get_script_support_overrides";
        /// <summary>
        /// Cached name for the 'set_opentype_feature_overrides' method.
        /// </summary>
        public static readonly StringName SetOpentypeFeatureOverrides = "set_opentype_feature_overrides";
        /// <summary>
        /// Cached name for the 'get_opentype_feature_overrides' method.
        /// </summary>
        public static readonly StringName GetOpentypeFeatureOverrides = "get_opentype_feature_overrides";
        /// <summary>
        /// Cached name for the 'get_glyph_index' method.
        /// </summary>
        public static readonly StringName GetGlyphIndex = "get_glyph_index";
        /// <summary>
        /// Cached name for the 'get_char_from_glyph_index' method.
        /// </summary>
        public static readonly StringName GetCharFromGlyphIndex = "get_char_from_glyph_index";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Font.SignalName
    {
    }
}
