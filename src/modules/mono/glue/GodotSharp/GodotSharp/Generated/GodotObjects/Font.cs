namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Abstract base class for different font types. It has methods for drawing text and font character introspection.</para>
/// </summary>
public partial class Font : Resource
{
    /// <summary>
    /// <para>Array of fallback <see cref="Godot.Font"/>s to use as a substitute if a glyph is not found in this current <see cref="Godot.Font"/>.</para>
    /// <para>If this array is empty in a <see cref="Godot.FontVariation"/>, the <see cref="Godot.FontVariation.BaseFont"/>'s fallbacks are used instead.</para>
    /// </summary>
    public Godot.Collections.Array<Font> Fallbacks
    {
        get
        {
            return GetFallbacks();
        }
        set
        {
            SetFallbacks(value);
        }
    }

    private static readonly System.Type CachedType = typeof(Font);

    private static readonly StringName NativeName = "Font";

    internal Font() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal Font(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal Font(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFallbacks, 381264803ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFallbacks(Godot.Collections.Array<Font> fallbacks)
    {
        NativeCalls.godot_icall_1_138(MethodBind0, GodotObject.GetPtr(this), (godot_array)(fallbacks ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFallbacks, 3995934104ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Godot.Collections.Array<Font> GetFallbacks()
    {
        return new Godot.Collections.Array<Font>(NativeCalls.godot_icall_0_120(MethodBind1, GodotObject.GetPtr(this)));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FindVariation, 2553855095ul);

    /// <summary>
    /// <para>Returns <see cref="Godot.TextServer"/> RID of the font cache for specific variation.</para>
    /// </summary>
    /// <param name="transform">If the parameter is null, then the default value is <c>Transform2D.Identity</c>.</param>
    public unsafe Rid FindVariation(Godot.Collections.Dictionary variationCoordinates, int faceIndex = 0, float strength = 0.0f, Nullable<Transform2D> transform = null, int spacingTop = 0, int spacingBottom = 0, int spacingSpace = 0, int spacingGlyph = 0, float baselineOffset = 0.0f)
    {
        Transform2D transformOrDefVal = transform.HasValue ? transform.Value : Transform2D.Identity;
        return NativeCalls.godot_icall_9_587(MethodBind2, GodotObject.GetPtr(this), (godot_dictionary)(variationCoordinates ?? new()).NativeValue, faceIndex, strength, &transformOrDefVal, spacingTop, spacingBottom, spacingSpace, spacingGlyph, baselineOffset);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRids, 3995934104ul);

    /// <summary>
    /// <para>Returns <see cref="Godot.Collections.Array"/> of valid <see cref="Godot.Font"/> <see cref="Godot.Rid"/>s, which can be passed to the <see cref="Godot.TextServer"/> methods.</para>
    /// </summary>
    public Godot.Collections.Array<Rid> GetRids()
    {
        return new Godot.Collections.Array<Rid>(NativeCalls.godot_icall_0_120(MethodBind3, GodotObject.GetPtr(this)));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetHeight, 378113874ul);

    /// <summary>
    /// <para>Returns the total average font height (ascent plus descent) in pixels.</para>
    /// <para><b>Note:</b> Real height of the string is context-dependent and can be significantly different from the value returned by this function. Use it only as rough estimate (e.g. as the height of empty line).</para>
    /// </summary>
    public float GetHeight(int fontSize = 16)
    {
        return NativeCalls.godot_icall_1_72(MethodBind4, GodotObject.GetPtr(this), fontSize);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAscent, 378113874ul);

    /// <summary>
    /// <para>Returns the average font ascent (number of pixels above the baseline).</para>
    /// <para><b>Note:</b> Real ascent of the string is context-dependent and can be significantly different from the value returned by this function. Use it only as rough estimate (e.g. as the ascent of empty line).</para>
    /// </summary>
    public float GetAscent(int fontSize = 16)
    {
        return NativeCalls.godot_icall_1_72(MethodBind5, GodotObject.GetPtr(this), fontSize);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDescent, 378113874ul);

    /// <summary>
    /// <para>Returns the average font descent (number of pixels below the baseline).</para>
    /// <para><b>Note:</b> Real descent of the string is context-dependent and can be significantly different from the value returned by this function. Use it only as rough estimate (e.g. as the descent of empty line).</para>
    /// </summary>
    public float GetDescent(int fontSize = 16)
    {
        return NativeCalls.godot_icall_1_72(MethodBind6, GodotObject.GetPtr(this), fontSize);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetUnderlinePosition, 378113874ul);

    /// <summary>
    /// <para>Returns average pixel offset of the underline below the baseline.</para>
    /// <para><b>Note:</b> Real underline position of the string is context-dependent and can be significantly different from the value returned by this function. Use it only as rough estimate.</para>
    /// </summary>
    public float GetUnderlinePosition(int fontSize = 16)
    {
        return NativeCalls.godot_icall_1_72(MethodBind7, GodotObject.GetPtr(this), fontSize);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetUnderlineThickness, 378113874ul);

    /// <summary>
    /// <para>Returns average thickness of the underline.</para>
    /// <para><b>Note:</b> Real underline thickness of the string is context-dependent and can be significantly different from the value returned by this function. Use it only as rough estimate.</para>
    /// </summary>
    public float GetUnderlineThickness(int fontSize = 16)
    {
        return NativeCalls.godot_icall_1_72(MethodBind8, GodotObject.GetPtr(this), fontSize);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFontName, 201670096ul);

    /// <summary>
    /// <para>Returns font family name.</para>
    /// </summary>
    public string GetFontName()
    {
        return NativeCalls.godot_icall_0_58(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFontStyleName, 201670096ul);

    /// <summary>
    /// <para>Returns font style name.</para>
    /// </summary>
    public string GetFontStyleName()
    {
        return NativeCalls.godot_icall_0_58(MethodBind10, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOtNameStrings, 3102165223ul);

    /// <summary>
    /// <para>Returns <see cref="Godot.Collections.Dictionary"/> with OpenType font name strings (localized font names, version, description, license information, sample text, etc.).</para>
    /// </summary>
    public Godot.Collections.Dictionary GetOtNameStrings()
    {
        return NativeCalls.godot_icall_0_122(MethodBind11, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFontStyle, 2520224254ul);

    /// <summary>
    /// <para>Returns font style flags.</para>
    /// </summary>
    public TextServer.FontStyle GetFontStyle()
    {
        return (TextServer.FontStyle)NativeCalls.godot_icall_0_39(MethodBind12, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFontWeight, 3905245786ul);

    /// <summary>
    /// <para>Returns weight (boldness) of the font. A value in the <c>100...999</c> range, normal font weight is <c>400</c>, bold font weight is <c>700</c>.</para>
    /// </summary>
    public int GetFontWeight()
    {
        return NativeCalls.godot_icall_0_39(MethodBind13, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFontStretch, 3905245786ul);

    /// <summary>
    /// <para>Returns font stretch amount, compared to a normal width. A percentage value between <c>50%</c> and <c>200%</c>.</para>
    /// </summary>
    public int GetFontStretch()
    {
        return NativeCalls.godot_icall_0_39(MethodBind14, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSpacing, 1310880908ul);

    /// <summary>
    /// <para>Returns the amount of spacing for the given <paramref name="spacing"/> type.</para>
    /// </summary>
    public int GetSpacing(TextServer.SpacingType spacing)
    {
        return NativeCalls.godot_icall_1_60(MethodBind15, GodotObject.GetPtr(this), (int)spacing);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOpentypeFeatures, 3102165223ul);

    /// <summary>
    /// <para>Returns a set of OpenType feature tags. More info: <a href="https://docs.microsoft.com/en-us/typography/opentype/spec/featuretags">OpenType feature tags</a>.</para>
    /// </summary>
    public Godot.Collections.Dictionary GetOpentypeFeatures()
    {
        return NativeCalls.godot_icall_0_122(MethodBind16, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCacheCapacity, 3937882851ul);

    /// <summary>
    /// <para>Sets LRU cache capacity for <c>draw_*</c> methods.</para>
    /// </summary>
    public void SetCacheCapacity(int singleLine, int multiLine)
    {
        NativeCalls.godot_icall_2_59(MethodBind17, GodotObject.GetPtr(this), singleLine, multiLine);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetStringSize, 1868866121ul);

    /// <summary>
    /// <para>Returns the size of a bounding box of a single-line string, taking kerning, advance and subpixel positioning into account. See also <see cref="Godot.Font.GetMultilineStringSize(string, HorizontalAlignment, float, int, int, TextServer.LineBreakFlag, TextServer.JustificationFlag, TextServer.Direction, TextServer.Orientation)"/> and <see cref="Godot.Font.DrawString(Rid, Vector2, string, HorizontalAlignment, float, int, Nullable{Color}, TextServer.JustificationFlag, TextServer.Direction, TextServer.Orientation, float)"/>.</para>
    /// <para>For example, to get the string size as displayed by a single-line Label, use:</para>
    /// <para><code>
    /// Label label = GetNode&lt;Label&gt;("Label");
    /// Vector2 stringSize = label.GetThemeFont("font").GetStringSize(label.Text, HorizontalAlignment.Left, -1, label.GetThemeFontSize("font_size"));
    /// </code></para>
    /// <para><b>Note:</b> Since kerning, advance and subpixel positioning are taken into account by <see cref="Godot.Font.GetStringSize(string, HorizontalAlignment, float, int, TextServer.JustificationFlag, TextServer.Direction, TextServer.Orientation)"/>, using separate <see cref="Godot.Font.GetStringSize(string, HorizontalAlignment, float, int, TextServer.JustificationFlag, TextServer.Direction, TextServer.Orientation)"/> calls on substrings of a string then adding the results together will return a different result compared to using a single <see cref="Godot.Font.GetStringSize(string, HorizontalAlignment, float, int, TextServer.JustificationFlag, TextServer.Direction, TextServer.Orientation)"/> call on the full string.</para>
    /// <para><b>Note:</b> Real height of the string is context-dependent and can be significantly different from the value returned by <see cref="Godot.Font.GetHeight(int)"/>.</para>
    /// </summary>
    public Vector2 GetStringSize(string text, HorizontalAlignment alignment = (HorizontalAlignment)(0), float width = (float)(-1), int fontSize = 16, TextServer.JustificationFlag justificationFlags = (TextServer.JustificationFlag)(3), TextServer.Direction direction = (TextServer.Direction)(0), TextServer.Orientation orientation = (TextServer.Orientation)(0))
    {
        return NativeCalls.godot_icall_7_588(MethodBind18, GodotObject.GetPtr(this), text, (int)alignment, width, fontSize, (int)justificationFlags, (int)direction, (int)orientation);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMultilineStringSize, 519636710ul);

    /// <summary>
    /// <para>Returns the size of a bounding box of a string broken into the lines, taking kerning and advance into account.</para>
    /// <para>See also <see cref="Godot.Font.DrawMultilineString(Rid, Vector2, string, HorizontalAlignment, float, int, int, Nullable{Color}, TextServer.LineBreakFlag, TextServer.JustificationFlag, TextServer.Direction, TextServer.Orientation, float)"/>.</para>
    /// </summary>
    public Vector2 GetMultilineStringSize(string text, HorizontalAlignment alignment = (HorizontalAlignment)(0), float width = (float)(-1), int fontSize = 16, int maxLines = -1, TextServer.LineBreakFlag brkFlags = (TextServer.LineBreakFlag)(3), TextServer.JustificationFlag justificationFlags = (TextServer.JustificationFlag)(3), TextServer.Direction direction = (TextServer.Direction)(0), TextServer.Orientation orientation = (TextServer.Orientation)(0))
    {
        return NativeCalls.godot_icall_9_589(MethodBind19, GodotObject.GetPtr(this), text, (int)alignment, width, fontSize, maxLines, (int)brkFlags, (int)justificationFlags, (int)direction, (int)orientation);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DrawString, 1976686372ul);

    /// <summary>
    /// <para>Draw <paramref name="text"/> into a canvas item using the font, at a given position, with <paramref name="modulate"/> color, optionally clipping the width and aligning horizontally. <paramref name="pos"/> specifies the baseline, not the top. To draw from the top, <i>ascent</i> must be added to the Y axis. If <paramref name="oversampling"/> is greater than zero, it is used as font oversampling factor, otherwise viewport oversampling settings are used.</para>
    /// <para>See also <see cref="Godot.CanvasItem.DrawString(Font, Vector2, string, HorizontalAlignment, float, int, Nullable{Color}, TextServer.JustificationFlag, TextServer.Direction, TextServer.Orientation, float)"/>.</para>
    /// </summary>
    /// <param name="modulate">If the parameter is null, then the default value is <c>new Color(1.0f, 1.0f, 1.0f, 1.0f)</c>.</param>
    public unsafe void DrawString(Rid canvasItem, Vector2 pos, string text, HorizontalAlignment alignment = (HorizontalAlignment)(0), float width = (float)(-1), int fontSize = 16, Nullable<Color> modulate = null, TextServer.JustificationFlag justificationFlags = (TextServer.JustificationFlag)(3), TextServer.Direction direction = (TextServer.Direction)(0), TextServer.Orientation orientation = (TextServer.Orientation)(0), float oversampling = 0.0f)
    {
        Color modulateOrDefVal = modulate.HasValue ? modulate.Value : new Color(1.0f, 1.0f, 1.0f, 1.0f);
        NativeCalls.godot_icall_11_590(MethodBind20, GodotObject.GetPtr(this), canvasItem, &pos, text, (int)alignment, width, fontSize, &modulateOrDefVal, (int)justificationFlags, (int)direction, (int)orientation, oversampling);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DrawMultilineString, 2686601589ul);

    /// <summary>
    /// <para>Breaks <paramref name="text"/> into lines using rules specified by <paramref name="brkFlags"/> and draws it into a canvas item using the font, at a given position, with <paramref name="modulate"/> color, optionally clipping the width and aligning horizontally. <paramref name="pos"/> specifies the baseline of the first line, not the top. To draw from the top, <i>ascent</i> must be added to the Y axis. If <paramref name="oversampling"/> is greater than zero, it is used as font oversampling factor, otherwise viewport oversampling settings are used.</para>
    /// <para>See also <see cref="Godot.CanvasItem.DrawMultilineString(Font, Vector2, string, HorizontalAlignment, float, int, int, Nullable{Color}, TextServer.LineBreakFlag, TextServer.JustificationFlag, TextServer.Direction, TextServer.Orientation, float)"/>.</para>
    /// </summary>
    /// <param name="modulate">If the parameter is null, then the default value is <c>new Color(1.0f, 1.0f, 1.0f, 1.0f)</c>.</param>
    public unsafe void DrawMultilineString(Rid canvasItem, Vector2 pos, string text, HorizontalAlignment alignment = (HorizontalAlignment)(0), float width = (float)(-1), int fontSize = 16, int maxLines = -1, Nullable<Color> modulate = null, TextServer.LineBreakFlag brkFlags = (TextServer.LineBreakFlag)(3), TextServer.JustificationFlag justificationFlags = (TextServer.JustificationFlag)(3), TextServer.Direction direction = (TextServer.Direction)(0), TextServer.Orientation orientation = (TextServer.Orientation)(0), float oversampling = 0.0f)
    {
        Color modulateOrDefVal = modulate.HasValue ? modulate.Value : new Color(1.0f, 1.0f, 1.0f, 1.0f);
        NativeCalls.godot_icall_13_591(MethodBind21, GodotObject.GetPtr(this), canvasItem, &pos, text, (int)alignment, width, fontSize, maxLines, &modulateOrDefVal, (int)brkFlags, (int)justificationFlags, (int)direction, (int)orientation, oversampling);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DrawStringOutline, 701417663ul);

    /// <summary>
    /// <para>Draw <paramref name="text"/> outline into a canvas item using the font, at a given position, with <paramref name="modulate"/> color and <paramref name="size"/> outline size, optionally clipping the width and aligning horizontally. <paramref name="pos"/> specifies the baseline, not the top. To draw from the top, <i>ascent</i> must be added to the Y axis. If <paramref name="oversampling"/> is greater than zero, it is used as font oversampling factor, otherwise viewport oversampling settings are used.</para>
    /// <para>See also <see cref="Godot.CanvasItem.DrawStringOutline(Font, Vector2, string, HorizontalAlignment, float, int, int, Nullable{Color}, TextServer.JustificationFlag, TextServer.Direction, TextServer.Orientation, float)"/>.</para>
    /// </summary>
    /// <param name="modulate">If the parameter is null, then the default value is <c>new Color(1.0f, 1.0f, 1.0f, 1.0f)</c>.</param>
    public unsafe void DrawStringOutline(Rid canvasItem, Vector2 pos, string text, HorizontalAlignment alignment = (HorizontalAlignment)(0), float width = (float)(-1), int fontSize = 16, int size = 1, Nullable<Color> modulate = null, TextServer.JustificationFlag justificationFlags = (TextServer.JustificationFlag)(3), TextServer.Direction direction = (TextServer.Direction)(0), TextServer.Orientation orientation = (TextServer.Orientation)(0), float oversampling = 0.0f)
    {
        Color modulateOrDefVal = modulate.HasValue ? modulate.Value : new Color(1.0f, 1.0f, 1.0f, 1.0f);
        NativeCalls.godot_icall_12_592(MethodBind22, GodotObject.GetPtr(this), canvasItem, &pos, text, (int)alignment, width, fontSize, size, &modulateOrDefVal, (int)justificationFlags, (int)direction, (int)orientation, oversampling);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DrawMultilineStringOutline, 4147839237ul);

    /// <summary>
    /// <para>Breaks <paramref name="text"/> to the lines using rules specified by <paramref name="brkFlags"/> and draws text outline into a canvas item using the font, at a given position, with <paramref name="modulate"/> color and <paramref name="size"/> outline size, optionally clipping the width and aligning horizontally. <paramref name="pos"/> specifies the baseline of the first line, not the top. To draw from the top, <i>ascent</i> must be added to the Y axis. If <paramref name="oversampling"/> is greater than zero, it is used as font oversampling factor, otherwise viewport oversampling settings are used.</para>
    /// <para>See also <see cref="Godot.CanvasItem.DrawMultilineStringOutline(Font, Vector2, string, HorizontalAlignment, float, int, int, int, Nullable{Color}, TextServer.LineBreakFlag, TextServer.JustificationFlag, TextServer.Direction, TextServer.Orientation, float)"/>.</para>
    /// </summary>
    /// <param name="modulate">If the parameter is null, then the default value is <c>new Color(1.0f, 1.0f, 1.0f, 1.0f)</c>.</param>
    public unsafe void DrawMultilineStringOutline(Rid canvasItem, Vector2 pos, string text, HorizontalAlignment alignment = (HorizontalAlignment)(0), float width = (float)(-1), int fontSize = 16, int maxLines = -1, int size = 1, Nullable<Color> modulate = null, TextServer.LineBreakFlag brkFlags = (TextServer.LineBreakFlag)(3), TextServer.JustificationFlag justificationFlags = (TextServer.JustificationFlag)(3), TextServer.Direction direction = (TextServer.Direction)(0), TextServer.Orientation orientation = (TextServer.Orientation)(0), float oversampling = 0.0f)
    {
        Color modulateOrDefVal = modulate.HasValue ? modulate.Value : new Color(1.0f, 1.0f, 1.0f, 1.0f);
        NativeCalls.godot_icall_14_593(MethodBind23, GodotObject.GetPtr(this), canvasItem, &pos, text, (int)alignment, width, fontSize, maxLines, size, &modulateOrDefVal, (int)brkFlags, (int)justificationFlags, (int)direction, (int)orientation, oversampling);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCharSize, 3016396712ul);

    /// <summary>
    /// <para>Returns the size of a character. Does not take kerning into account.</para>
    /// <para><b>Note:</b> Do not use this function to calculate width of the string character by character, use <see cref="Godot.Font.GetStringSize(string, HorizontalAlignment, float, int, TextServer.JustificationFlag, TextServer.Direction, TextServer.Orientation)"/> or <see cref="Godot.TextLine"/> instead. The height returned is the font height (see also <see cref="Godot.Font.GetHeight(int)"/>) and has no relation to the glyph height.</para>
    /// </summary>
    public Vector2 GetCharSize(long @char, int fontSize)
    {
        return NativeCalls.godot_icall_2_594(MethodBind24, GodotObject.GetPtr(this), @char, fontSize);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DrawChar, 3500170256ul);

    /// <summary>
    /// <para>Draw a single Unicode character <paramref name="char"/> into a canvas item using the font, at a given position, with <paramref name="modulate"/> color. <paramref name="pos"/> specifies the baseline, not the top. To draw from the top, <i>ascent</i> must be added to the Y axis. If <paramref name="oversampling"/> is greater than zero, it is used as font oversampling factor, otherwise viewport oversampling settings are used.</para>
    /// <para><b>Note:</b> Do not use this function to draw strings character by character, use <see cref="Godot.Font.DrawString(Rid, Vector2, string, HorizontalAlignment, float, int, Nullable{Color}, TextServer.JustificationFlag, TextServer.Direction, TextServer.Orientation, float)"/> or <see cref="Godot.TextLine"/> instead.</para>
    /// </summary>
    /// <param name="modulate">If the parameter is null, then the default value is <c>new Color(1.0f, 1.0f, 1.0f, 1.0f)</c>.</param>
    public unsafe float DrawChar(Rid canvasItem, Vector2 pos, long @char, int fontSize, Nullable<Color> modulate = null, float oversampling = 0.0f)
    {
        Color modulateOrDefVal = modulate.HasValue ? modulate.Value : new Color(1.0f, 1.0f, 1.0f, 1.0f);
        return NativeCalls.godot_icall_6_595(MethodBind25, GodotObject.GetPtr(this), canvasItem, &pos, @char, fontSize, &modulateOrDefVal, oversampling);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DrawCharOutline, 1684114874ul);

    /// <summary>
    /// <para>Draw a single Unicode character <paramref name="char"/> outline into a canvas item using the font, at a given position, with <paramref name="modulate"/> color and <paramref name="size"/> outline size. <paramref name="pos"/> specifies the baseline, not the top. To draw from the top, <i>ascent</i> must be added to the Y axis. If <paramref name="oversampling"/> is greater than zero, it is used as font oversampling factor, otherwise viewport oversampling settings are used.</para>
    /// <para><b>Note:</b> Do not use this function to draw strings character by character, use <see cref="Godot.Font.DrawString(Rid, Vector2, string, HorizontalAlignment, float, int, Nullable{Color}, TextServer.JustificationFlag, TextServer.Direction, TextServer.Orientation, float)"/> or <see cref="Godot.TextLine"/> instead.</para>
    /// </summary>
    /// <param name="modulate">If the parameter is null, then the default value is <c>new Color(1.0f, 1.0f, 1.0f, 1.0f)</c>.</param>
    public unsafe float DrawCharOutline(Rid canvasItem, Vector2 pos, long @char, int fontSize, int size = -1, Nullable<Color> modulate = null, float oversampling = 0.0f)
    {
        Color modulateOrDefVal = modulate.HasValue ? modulate.Value : new Color(1.0f, 1.0f, 1.0f, 1.0f);
        return NativeCalls.godot_icall_7_596(MethodBind26, GodotObject.GetPtr(this), canvasItem, &pos, @char, fontSize, size, &modulateOrDefVal, oversampling);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasChar, 1116898809ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if a Unicode <paramref name="char"/> is available in the font.</para>
    /// </summary>
    public bool HasChar(long @char)
    {
        return NativeCalls.godot_icall_1_11(MethodBind27, GodotObject.GetPtr(this), @char).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSupportedChars, 201670096ul);

    /// <summary>
    /// <para>Returns a string containing all the characters available in the font.</para>
    /// <para>If a given character is included in more than one font data source, it appears only once in the returned string.</para>
    /// </summary>
    public string GetSupportedChars()
    {
        return NativeCalls.godot_icall_0_58(MethodBind28, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsLanguageSupported, 3927539163ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the font supports the given language (as a <a href="https://en.wikipedia.org/wiki/ISO_639-1">ISO 639</a> code).</para>
    /// </summary>
    public bool IsLanguageSupported(string language)
    {
        return NativeCalls.godot_icall_1_131(MethodBind29, GodotObject.GetPtr(this), language).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsScriptSupported, 3927539163ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the font supports the given script (as a <a href="https://en.wikipedia.org/wiki/ISO_15924">ISO 15924</a> code).</para>
    /// </summary>
    public bool IsScriptSupported(string script)
    {
        return NativeCalls.godot_icall_1_131(MethodBind30, GodotObject.GetPtr(this), script).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSupportedFeatureList, 3102165223ul);

    /// <summary>
    /// <para>Returns list of OpenType features supported by font.</para>
    /// </summary>
    public Godot.Collections.Dictionary GetSupportedFeatureList()
    {
        return NativeCalls.godot_icall_0_122(MethodBind31, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind32 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSupportedVariationList, 3102165223ul);

    /// <summary>
    /// <para>Returns list of supported <a href="https://docs.microsoft.com/en-us/typography/opentype/spec/dvaraxisreg">variation coordinates</a>, each coordinate is returned as <c>tag: Vector3i(min_value,max_value,default_value)</c>.</para>
    /// <para>Font variations allow for continuous change of glyph characteristics along some given design axis, such as weight, width or slant.</para>
    /// <para>To print available variation axes of a variable font:</para>
    /// <para><code>
    /// var fv = FontVariation.new()
    /// fv.base_font = load("res://RobotoFlex.ttf")
    /// var variation_list = fv.get_supported_variation_list()
    /// for tag in variation_list:
    /// 	var name = TextServerManager.get_primary_interface().tag_to_name(tag)
    /// 	var values = variation_list[tag]
    /// 	print("variation axis: %s (%d)\n\tmin, max, default: %s" % [name, tag, values])
    /// </code></para>
    /// <para><b>Note:</b> To set and get variation coordinates of a <see cref="Godot.FontVariation"/>, use <see cref="Godot.FontVariation.VariationOpentype"/>.</para>
    /// </summary>
    public Godot.Collections.Dictionary GetSupportedVariationList()
    {
        return NativeCalls.godot_icall_0_122(MethodBind32, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind33 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFaceCount, 3905245786ul);

    /// <summary>
    /// <para>Returns number of faces in the TrueType / OpenType collection.</para>
    /// </summary>
    public long GetFaceCount()
    {
        return NativeCalls.godot_icall_0_4(MethodBind33, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind34 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FindVariation, 3344325384ul);

    /// <summary>
    /// <para>Returns <see cref="Godot.TextServer"/> RID of the font cache for specific variation.</para>
    /// </summary>
    /// <param name="transform">If the parameter is null, then the default value is <c>Transform2D.Identity</c>.</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe Rid FindVariation(Godot.Collections.Dictionary variationCoordinates, int faceIndex, float strength, Nullable<Transform2D> transform, int spacingTop, int spacingBottom, int spacingSpace, int spacingGlyph)
    {
        Transform2D transformOrDefVal = transform.HasValue ? transform.Value : Transform2D.Identity;
        return NativeCalls.godot_icall_8_597(MethodBind34, GodotObject.GetPtr(this), (godot_dictionary)(variationCoordinates ?? new()).NativeValue, faceIndex, strength, &transformOrDefVal, spacingTop, spacingBottom, spacingSpace, spacingGlyph);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind35 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FindVariation, 1851767612ul);

    /// <summary>
    /// <para>Returns <see cref="Godot.TextServer"/> RID of the font cache for specific variation.</para>
    /// </summary>
    /// <param name="transform">If the parameter is null, then the default value is <c>Transform2D.Identity</c>.</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe Rid FindVariation(Godot.Collections.Dictionary variationCoordinates, int faceIndex, float strength, Nullable<Transform2D> transform)
    {
        Transform2D transformOrDefVal = transform.HasValue ? transform.Value : Transform2D.Identity;
        return NativeCalls.godot_icall_4_598(MethodBind35, GodotObject.GetPtr(this), (godot_dictionary)(variationCoordinates ?? new()).NativeValue, faceIndex, strength, &transformOrDefVal);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind36 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DrawCharOutline, 209525354ul);

    /// <summary>
    /// <para>Draw a single Unicode character <paramref name="char"/> outline into a canvas item using the font, at a given position, with <paramref name="modulate"/> color and <paramref name="size"/> outline size. <paramref name="pos"/> specifies the baseline, not the top. To draw from the top, <i>ascent</i> must be added to the Y axis. If <paramref name="oversampling"/> is greater than zero, it is used as font oversampling factor, otherwise viewport oversampling settings are used.</para>
    /// <para><b>Note:</b> Do not use this function to draw strings character by character, use <see cref="Godot.Font.DrawString(Rid, Vector2, string, HorizontalAlignment, float, int, Nullable{Color}, TextServer.JustificationFlag, TextServer.Direction, TextServer.Orientation, float)"/> or <see cref="Godot.TextLine"/> instead.</para>
    /// </summary>
    /// <param name="modulate">If the parameter is null, then the default value is <c>new Color(1.0f, 1.0f, 1.0f, 1.0f)</c>.</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe float DrawCharOutline(Rid canvasItem, Vector2 pos, long @char, int fontSize, int size, Nullable<Color> modulate)
    {
        Color modulateOrDefVal = modulate.HasValue ? modulate.Value : new Color(1.0f, 1.0f, 1.0f, 1.0f);
        return NativeCalls.godot_icall_6_599(MethodBind36, GodotObject.GetPtr(this), canvasItem, &pos, @char, fontSize, size, &modulateOrDefVal);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind37 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DrawChar, 3815617597ul);

    /// <summary>
    /// <para>Draw a single Unicode character <paramref name="char"/> into a canvas item using the font, at a given position, with <paramref name="modulate"/> color. <paramref name="pos"/> specifies the baseline, not the top. To draw from the top, <i>ascent</i> must be added to the Y axis. If <paramref name="oversampling"/> is greater than zero, it is used as font oversampling factor, otherwise viewport oversampling settings are used.</para>
    /// <para><b>Note:</b> Do not use this function to draw strings character by character, use <see cref="Godot.Font.DrawString(Rid, Vector2, string, HorizontalAlignment, float, int, Nullable{Color}, TextServer.JustificationFlag, TextServer.Direction, TextServer.Orientation, float)"/> or <see cref="Godot.TextLine"/> instead.</para>
    /// </summary>
    /// <param name="modulate">If the parameter is null, then the default value is <c>new Color(1.0f, 1.0f, 1.0f, 1.0f)</c>.</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe float DrawChar(Rid canvasItem, Vector2 pos, long @char, int fontSize, Nullable<Color> modulate)
    {
        Color modulateOrDefVal = modulate.HasValue ? modulate.Value : new Color(1.0f, 1.0f, 1.0f, 1.0f);
        return NativeCalls.godot_icall_5_600(MethodBind37, GodotObject.GetPtr(this), canvasItem, &pos, @char, fontSize, &modulateOrDefVal);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind38 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DrawMultilineStringOutline, 3206388178ul);

    /// <summary>
    /// <para>Breaks <paramref name="text"/> to the lines using rules specified by <paramref name="brkFlags"/> and draws text outline into a canvas item using the font, at a given position, with <paramref name="modulate"/> color and <paramref name="size"/> outline size, optionally clipping the width and aligning horizontally. <paramref name="pos"/> specifies the baseline of the first line, not the top. To draw from the top, <i>ascent</i> must be added to the Y axis. If <paramref name="oversampling"/> is greater than zero, it is used as font oversampling factor, otherwise viewport oversampling settings are used.</para>
    /// <para>See also <see cref="Godot.CanvasItem.DrawMultilineStringOutline(Font, Vector2, string, HorizontalAlignment, float, int, int, int, Nullable{Color}, TextServer.LineBreakFlag, TextServer.JustificationFlag, TextServer.Direction, TextServer.Orientation, float)"/>.</para>
    /// </summary>
    /// <param name="modulate">If the parameter is null, then the default value is <c>new Color(1.0f, 1.0f, 1.0f, 1.0f)</c>.</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void DrawMultilineStringOutline(Rid canvasItem, Vector2 pos, string text, HorizontalAlignment alignment, float width, int fontSize, int maxLines, int size, Nullable<Color> modulate, TextServer.LineBreakFlag brkFlags, TextServer.JustificationFlag justificationFlags, TextServer.Direction direction, TextServer.Orientation orientation)
    {
        Color modulateOrDefVal = modulate.HasValue ? modulate.Value : new Color(1.0f, 1.0f, 1.0f, 1.0f);
        NativeCalls.godot_icall_13_601(MethodBind38, GodotObject.GetPtr(this), canvasItem, &pos, text, (int)alignment, width, fontSize, maxLines, size, &modulateOrDefVal, (int)brkFlags, (int)justificationFlags, (int)direction, (int)orientation);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind39 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DrawStringOutline, 623754045ul);

    /// <summary>
    /// <para>Draw <paramref name="text"/> outline into a canvas item using the font, at a given position, with <paramref name="modulate"/> color and <paramref name="size"/> outline size, optionally clipping the width and aligning horizontally. <paramref name="pos"/> specifies the baseline, not the top. To draw from the top, <i>ascent</i> must be added to the Y axis. If <paramref name="oversampling"/> is greater than zero, it is used as font oversampling factor, otherwise viewport oversampling settings are used.</para>
    /// <para>See also <see cref="Godot.CanvasItem.DrawStringOutline(Font, Vector2, string, HorizontalAlignment, float, int, int, Nullable{Color}, TextServer.JustificationFlag, TextServer.Direction, TextServer.Orientation, float)"/>.</para>
    /// </summary>
    /// <param name="modulate">If the parameter is null, then the default value is <c>new Color(1.0f, 1.0f, 1.0f, 1.0f)</c>.</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void DrawStringOutline(Rid canvasItem, Vector2 pos, string text, HorizontalAlignment alignment, float width, int fontSize, int size, Nullable<Color> modulate, TextServer.JustificationFlag justificationFlags, TextServer.Direction direction, TextServer.Orientation orientation)
    {
        Color modulateOrDefVal = modulate.HasValue ? modulate.Value : new Color(1.0f, 1.0f, 1.0f, 1.0f);
        NativeCalls.godot_icall_11_602(MethodBind39, GodotObject.GetPtr(this), canvasItem, &pos, text, (int)alignment, width, fontSize, size, &modulateOrDefVal, (int)justificationFlags, (int)direction, (int)orientation);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind40 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DrawMultilineString, 1171506176ul);

    /// <summary>
    /// <para>Breaks <paramref name="text"/> into lines using rules specified by <paramref name="brkFlags"/> and draws it into a canvas item using the font, at a given position, with <paramref name="modulate"/> color, optionally clipping the width and aligning horizontally. <paramref name="pos"/> specifies the baseline of the first line, not the top. To draw from the top, <i>ascent</i> must be added to the Y axis. If <paramref name="oversampling"/> is greater than zero, it is used as font oversampling factor, otherwise viewport oversampling settings are used.</para>
    /// <para>See also <see cref="Godot.CanvasItem.DrawMultilineString(Font, Vector2, string, HorizontalAlignment, float, int, int, Nullable{Color}, TextServer.LineBreakFlag, TextServer.JustificationFlag, TextServer.Direction, TextServer.Orientation, float)"/>.</para>
    /// </summary>
    /// <param name="modulate">If the parameter is null, then the default value is <c>new Color(1.0f, 1.0f, 1.0f, 1.0f)</c>.</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void DrawMultilineString(Rid canvasItem, Vector2 pos, string text, HorizontalAlignment alignment, float width, int fontSize, int maxLines, Nullable<Color> modulate, TextServer.LineBreakFlag brkFlags, TextServer.JustificationFlag justificationFlags, TextServer.Direction direction, TextServer.Orientation orientation)
    {
        Color modulateOrDefVal = modulate.HasValue ? modulate.Value : new Color(1.0f, 1.0f, 1.0f, 1.0f);
        NativeCalls.godot_icall_12_603(MethodBind40, GodotObject.GetPtr(this), canvasItem, &pos, text, (int)alignment, width, fontSize, maxLines, &modulateOrDefVal, (int)brkFlags, (int)justificationFlags, (int)direction, (int)orientation);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind41 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DrawString, 1983721962ul);

    /// <summary>
    /// <para>Draw <paramref name="text"/> into a canvas item using the font, at a given position, with <paramref name="modulate"/> color, optionally clipping the width and aligning horizontally. <paramref name="pos"/> specifies the baseline, not the top. To draw from the top, <i>ascent</i> must be added to the Y axis. If <paramref name="oversampling"/> is greater than zero, it is used as font oversampling factor, otherwise viewport oversampling settings are used.</para>
    /// <para>See also <see cref="Godot.CanvasItem.DrawString(Font, Vector2, string, HorizontalAlignment, float, int, Nullable{Color}, TextServer.JustificationFlag, TextServer.Direction, TextServer.Orientation, float)"/>.</para>
    /// </summary>
    /// <param name="modulate">If the parameter is null, then the default value is <c>new Color(1.0f, 1.0f, 1.0f, 1.0f)</c>.</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void DrawString(Rid canvasItem, Vector2 pos, string text, HorizontalAlignment alignment, float width, int fontSize, Nullable<Color> modulate, TextServer.JustificationFlag justificationFlags, TextServer.Direction direction, TextServer.Orientation orientation)
    {
        Color modulateOrDefVal = modulate.HasValue ? modulate.Value : new Color(1.0f, 1.0f, 1.0f, 1.0f);
        NativeCalls.godot_icall_10_604(MethodBind41, GodotObject.GetPtr(this), canvasItem, &pos, text, (int)alignment, width, fontSize, &modulateOrDefVal, (int)justificationFlags, (int)direction, (int)orientation);
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
        /// Cached name for the 'fallbacks' property.
        /// </summary>
        public static readonly StringName Fallbacks = "fallbacks";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Resource.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_fallbacks' method.
        /// </summary>
        public static readonly StringName SetFallbacks = "set_fallbacks";
        /// <summary>
        /// Cached name for the 'get_fallbacks' method.
        /// </summary>
        public static readonly StringName GetFallbacks = "get_fallbacks";
        /// <summary>
        /// Cached name for the 'find_variation' method.
        /// </summary>
        public static readonly StringName FindVariation = "find_variation";
        /// <summary>
        /// Cached name for the 'get_rids' method.
        /// </summary>
        public static readonly StringName GetRids = "get_rids";
        /// <summary>
        /// Cached name for the 'get_height' method.
        /// </summary>
        public static readonly StringName GetHeight = "get_height";
        /// <summary>
        /// Cached name for the 'get_ascent' method.
        /// </summary>
        public static readonly StringName GetAscent = "get_ascent";
        /// <summary>
        /// Cached name for the 'get_descent' method.
        /// </summary>
        public static readonly StringName GetDescent = "get_descent";
        /// <summary>
        /// Cached name for the 'get_underline_position' method.
        /// </summary>
        public static readonly StringName GetUnderlinePosition = "get_underline_position";
        /// <summary>
        /// Cached name for the 'get_underline_thickness' method.
        /// </summary>
        public static readonly StringName GetUnderlineThickness = "get_underline_thickness";
        /// <summary>
        /// Cached name for the 'get_font_name' method.
        /// </summary>
        public static readonly StringName GetFontName = "get_font_name";
        /// <summary>
        /// Cached name for the 'get_font_style_name' method.
        /// </summary>
        public static readonly StringName GetFontStyleName = "get_font_style_name";
        /// <summary>
        /// Cached name for the 'get_ot_name_strings' method.
        /// </summary>
        public static readonly StringName GetOtNameStrings = "get_ot_name_strings";
        /// <summary>
        /// Cached name for the 'get_font_style' method.
        /// </summary>
        public static readonly StringName GetFontStyle = "get_font_style";
        /// <summary>
        /// Cached name for the 'get_font_weight' method.
        /// </summary>
        public static readonly StringName GetFontWeight = "get_font_weight";
        /// <summary>
        /// Cached name for the 'get_font_stretch' method.
        /// </summary>
        public static readonly StringName GetFontStretch = "get_font_stretch";
        /// <summary>
        /// Cached name for the 'get_spacing' method.
        /// </summary>
        public static readonly StringName GetSpacing = "get_spacing";
        /// <summary>
        /// Cached name for the 'get_opentype_features' method.
        /// </summary>
        public static readonly StringName GetOpentypeFeatures = "get_opentype_features";
        /// <summary>
        /// Cached name for the 'set_cache_capacity' method.
        /// </summary>
        public static readonly StringName SetCacheCapacity = "set_cache_capacity";
        /// <summary>
        /// Cached name for the 'get_string_size' method.
        /// </summary>
        public static readonly StringName GetStringSize = "get_string_size";
        /// <summary>
        /// Cached name for the 'get_multiline_string_size' method.
        /// </summary>
        public static readonly StringName GetMultilineStringSize = "get_multiline_string_size";
        /// <summary>
        /// Cached name for the 'draw_string' method.
        /// </summary>
        public static readonly StringName DrawString = "draw_string";
        /// <summary>
        /// Cached name for the 'draw_multiline_string' method.
        /// </summary>
        public static readonly StringName DrawMultilineString = "draw_multiline_string";
        /// <summary>
        /// Cached name for the 'draw_string_outline' method.
        /// </summary>
        public static readonly StringName DrawStringOutline = "draw_string_outline";
        /// <summary>
        /// Cached name for the 'draw_multiline_string_outline' method.
        /// </summary>
        public static readonly StringName DrawMultilineStringOutline = "draw_multiline_string_outline";
        /// <summary>
        /// Cached name for the 'get_char_size' method.
        /// </summary>
        public static readonly StringName GetCharSize = "get_char_size";
        /// <summary>
        /// Cached name for the 'draw_char' method.
        /// </summary>
        public static readonly StringName DrawChar = "draw_char";
        /// <summary>
        /// Cached name for the 'draw_char_outline' method.
        /// </summary>
        public static readonly StringName DrawCharOutline = "draw_char_outline";
        /// <summary>
        /// Cached name for the 'has_char' method.
        /// </summary>
        public static readonly StringName HasChar = "has_char";
        /// <summary>
        /// Cached name for the 'get_supported_chars' method.
        /// </summary>
        public static readonly StringName GetSupportedChars = "get_supported_chars";
        /// <summary>
        /// Cached name for the 'is_language_supported' method.
        /// </summary>
        public static readonly StringName IsLanguageSupported = "is_language_supported";
        /// <summary>
        /// Cached name for the 'is_script_supported' method.
        /// </summary>
        public static readonly StringName IsScriptSupported = "is_script_supported";
        /// <summary>
        /// Cached name for the 'get_supported_feature_list' method.
        /// </summary>
        public static readonly StringName GetSupportedFeatureList = "get_supported_feature_list";
        /// <summary>
        /// Cached name for the 'get_supported_variation_list' method.
        /// </summary>
        public static readonly StringName GetSupportedVariationList = "get_supported_variation_list";
        /// <summary>
        /// Cached name for the 'get_face_count' method.
        /// </summary>
        public static readonly StringName GetFaceCount = "get_face_count";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Resource.SignalName
    {
    }
}
