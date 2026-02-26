namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para><see cref="Godot.TextServer"/> is the API backend for managing fonts and rendering text.</para>
/// <para><b>Note:</b> This is a low-level API, consider using <see cref="Godot.TextLine"/>, <see cref="Godot.TextParagraph"/>, and <see cref="Godot.Font"/> classes instead.</para>
/// <para>This is an abstract class, so to get the currently active <see cref="Godot.TextServer"/> instance, use the following code:</para>
/// <para><code>
/// var ts = TextServerManager.GetPrimaryInterface();
/// </code></para>
/// </summary>
public partial class TextServer : RefCounted
{
    public enum FontAntialiasing : long
    {
        /// <summary>
        /// <para>Font glyphs are rasterized as 1-bit bitmaps.</para>
        /// </summary>
        None = 0,
        /// <summary>
        /// <para>Font glyphs are rasterized as 8-bit grayscale anti-aliased bitmaps.</para>
        /// </summary>
        Gray = 1,
        /// <summary>
        /// <para>Font glyphs are rasterized for LCD screens.</para>
        /// <para>LCD subpixel layout is determined by the value of the <c>ProjectSettings.gui/theme/lcd_subpixel_layout</c> setting.</para>
        /// <para>LCD subpixel anti-aliasing mode is suitable only for rendering horizontal, unscaled text in 2D.</para>
        /// </summary>
        Lcd = 2
    }

    public enum FontLcdSubpixelLayout : long
    {
        /// <summary>
        /// <para>Unknown or unsupported subpixel layout, LCD subpixel antialiasing is disabled.</para>
        /// </summary>
        None = 0,
        /// <summary>
        /// <para>Horizontal RGB subpixel layout.</para>
        /// </summary>
        Hrgb = 1,
        /// <summary>
        /// <para>Horizontal BGR subpixel layout.</para>
        /// </summary>
        Hbgr = 2,
        /// <summary>
        /// <para>Vertical RGB subpixel layout.</para>
        /// </summary>
        Vrgb = 3,
        /// <summary>
        /// <para>Vertical BGR subpixel layout.</para>
        /// </summary>
        Vbgr = 4,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.TextServer.FontLcdSubpixelLayout"/> enum.</para>
        /// </summary>
        Max = 5
    }

    public enum Direction : long
    {
        /// <summary>
        /// <para>Text direction is determined based on contents and current locale.</para>
        /// </summary>
        Auto = 0,
        /// <summary>
        /// <para>Text is written from left to right.</para>
        /// </summary>
        Ltr = 1,
        /// <summary>
        /// <para>Text is written from right to left.</para>
        /// </summary>
        Rtl = 2,
        /// <summary>
        /// <para>Text writing direction is the same as base string writing direction. Used for BiDi override only.</para>
        /// </summary>
        Inherited = 3
    }

    public enum Orientation : long
    {
        /// <summary>
        /// <para>Text is written horizontally.</para>
        /// </summary>
        Horizontal = 0,
        /// <summary>
        /// <para>Left to right text is written vertically from top to bottom.</para>
        /// <para>Right to left text is written vertically from bottom to top.</para>
        /// </summary>
        Vertical = 1
    }

    [System.Flags]
    public enum JustificationFlag : long
    {
        /// <summary>
        /// <para>Do not justify text.</para>
        /// </summary>
        None = 0,
        /// <summary>
        /// <para>Justify text by adding and removing kashidas.</para>
        /// </summary>
        Kashida = 1,
        /// <summary>
        /// <para>Justify text by changing width of the spaces between the words.</para>
        /// </summary>
        WordBound = 2,
        /// <summary>
        /// <para>Remove trailing and leading spaces from the justified text.</para>
        /// </summary>
        TrimEdgeSpaces = 4,
        /// <summary>
        /// <para>Only apply justification to the part of the text after the last tab.</para>
        /// </summary>
        AfterLastTab = 8,
        /// <summary>
        /// <para>Apply justification to the trimmed line with ellipsis.</para>
        /// </summary>
        ConstrainEllipsis = 16,
        /// <summary>
        /// <para>Do not apply justification to the last line of the paragraph.</para>
        /// </summary>
        SkipLastLine = 32,
        /// <summary>
        /// <para>Do not apply justification to the last line of the paragraph with visible characters (takes precedence over <see cref="Godot.TextServer.JustificationFlag.SkipLastLine"/>).</para>
        /// </summary>
        SkipLastLineWithVisibleChars = 64,
        /// <summary>
        /// <para>Always apply justification to the paragraphs with a single line (<see cref="Godot.TextServer.JustificationFlag.SkipLastLine"/> and <see cref="Godot.TextServer.JustificationFlag.SkipLastLineWithVisibleChars"/> are ignored).</para>
        /// </summary>
        DoNotSkipSingleLine = 128
    }

    public enum AutowrapMode : long
    {
        /// <summary>
        /// <para>Autowrap is disabled.</para>
        /// </summary>
        Off = 0,
        /// <summary>
        /// <para>Wraps the text inside the node's bounding rectangle by allowing to break lines at arbitrary positions, which is useful when very limited space is available.</para>
        /// </summary>
        Arbitrary = 1,
        /// <summary>
        /// <para>Wraps the text inside the node's bounding rectangle by soft-breaking between words.</para>
        /// </summary>
        Word = 2,
        /// <summary>
        /// <para>Behaves similarly to <see cref="Godot.TextServer.AutowrapMode.Word"/>, but force-breaks a word if that single word does not fit in one line.</para>
        /// </summary>
        WordSmart = 3
    }

    [System.Flags]
    public enum LineBreakFlag : long
    {
        /// <summary>
        /// <para>Do not break the line.</para>
        /// </summary>
        None = 0,
        /// <summary>
        /// <para>Break the line at the line mandatory break characters (e.g. <c>"\n"</c>).</para>
        /// </summary>
        Mandatory = 1,
        /// <summary>
        /// <para>Break the line between the words.</para>
        /// </summary>
        WordBound = 2,
        /// <summary>
        /// <para>Break the line between any unconnected graphemes.</para>
        /// </summary>
        GraphemeBound = 4,
        /// <summary>
        /// <para>Should be used only in conjunction with <see cref="Godot.TextServer.LineBreakFlag.WordBound"/>, break the line between any unconnected graphemes, if it's impossible to break it between the words.</para>
        /// </summary>
        Adaptive = 8,
        /// <summary>
        /// <para>Remove edge spaces from the broken line segments.</para>
        /// </summary>
        [Obsolete("Use 'BREAK_TRIM_START_EDGE_SPACES | BREAK_TRIM_END_EDGE_SPACES' instead.")]
        TrimEdgeSpaces = 16,
        /// <summary>
        /// <para>Subtract first line indentation width from all lines after the first one.</para>
        /// </summary>
        TrimIndent = 32,
        /// <summary>
        /// <para>Remove spaces and line break characters from the start of broken line segments.</para>
        /// <para>E.g, after line breaking, the second segment of the following text <c>test  \n  next</c>, is <c>next</c> if the flag is set, and <c>  next</c> if it is not.</para>
        /// </summary>
        TrimStartEdgeSpaces = 64,
        /// <summary>
        /// <para>Remove spaces and line break characters from the end of broken line segments.</para>
        /// <para>E.g, after line breaking, the first segment of the following text <c>test  \n  next</c>, is <c>test</c> if the flag is set, and <c>test  \n</c> if it is not.</para>
        /// </summary>
        TrimEndEdgeSpaces = 128
    }

    public enum VisibleCharactersBehavior : long
    {
        /// <summary>
        /// <para>Trims text before the shaping. e.g, increasing <see cref="Godot.Label.VisibleCharacters"/> or <see cref="Godot.RichTextLabel.VisibleCharacters"/> value is visually identical to typing the text.</para>
        /// <para><b>Note:</b> In this mode, trimmed text is not processed at all. It is not accounted for in line breaking and size calculations.</para>
        /// </summary>
        CharsBeforeShaping = 0,
        /// <summary>
        /// <para>Displays glyphs that are mapped to the first <see cref="Godot.Label.VisibleCharacters"/> or <see cref="Godot.RichTextLabel.VisibleCharacters"/> characters from the beginning of the text.</para>
        /// </summary>
        CharsAfterShaping = 1,
        /// <summary>
        /// <para>Displays <see cref="Godot.Label.VisibleRatio"/> or <see cref="Godot.RichTextLabel.VisibleRatio"/> glyphs, starting from the left or from the right, depending on <see cref="Godot.Control.LayoutDirection"/> value.</para>
        /// </summary>
        GlyphsAuto = 2,
        /// <summary>
        /// <para>Displays <see cref="Godot.Label.VisibleRatio"/> or <see cref="Godot.RichTextLabel.VisibleRatio"/> glyphs, starting from the left.</para>
        /// </summary>
        GlyphsLtr = 3,
        /// <summary>
        /// <para>Displays <see cref="Godot.Label.VisibleRatio"/> or <see cref="Godot.RichTextLabel.VisibleRatio"/> glyphs, starting from the right.</para>
        /// </summary>
        GlyphsRtl = 4
    }

    public enum OverrunBehavior : long
    {
        /// <summary>
        /// <para>No text trimming is performed.</para>
        /// </summary>
        NoTrimming = 0,
        /// <summary>
        /// <para>Trims the text per character.</para>
        /// </summary>
        TrimChar = 1,
        /// <summary>
        /// <para>Trims the text per word.</para>
        /// </summary>
        TrimWord = 2,
        /// <summary>
        /// <para>Trims the text per character and adds an ellipsis to indicate that parts are hidden if trimmed text is 6 characters or longer.</para>
        /// </summary>
        TrimEllipsis = 3,
        /// <summary>
        /// <para>Trims the text per word and adds an ellipsis to indicate that parts are hidden if trimmed text is 6 characters or longer.</para>
        /// </summary>
        TrimWordEllipsis = 4,
        /// <summary>
        /// <para>Trims the text per character and adds an ellipsis to indicate that parts are hidden regardless of trimmed text length.</para>
        /// </summary>
        TrimEllipsisForce = 5,
        /// <summary>
        /// <para>Trims the text per word and adds an ellipsis to indicate that parts are hidden regardless of trimmed text length.</para>
        /// </summary>
        TrimWordEllipsisForce = 6
    }

    [System.Flags]
    public enum TextOverrunFlag : long
    {
        /// <summary>
        /// <para>No trimming is performed.</para>
        /// </summary>
        NoTrim = 0,
        /// <summary>
        /// <para>Trims the text when it exceeds the given width.</para>
        /// </summary>
        Trim = 1,
        /// <summary>
        /// <para>Trims the text per word instead of per grapheme.</para>
        /// </summary>
        TrimWordOnly = 2,
        /// <summary>
        /// <para>Determines whether an ellipsis should be added at the end of the text.</para>
        /// </summary>
        AddEllipsis = 4,
        /// <summary>
        /// <para>Determines whether the ellipsis at the end of the text is enforced and may not be hidden.</para>
        /// </summary>
        EnforceEllipsis = 8,
        /// <summary>
        /// <para>Accounts for the text being justified before attempting to trim it (see <see cref="Godot.TextServer.JustificationFlag"/>).</para>
        /// </summary>
        JustificationAware = 16,
        /// <summary>
        /// <para>Determines whether the ellipsis should be added regardless of the string length, otherwise it is added only if the string is 6 characters or longer.</para>
        /// </summary>
        ShortStringEllipsis = 32
    }

    [System.Flags]
    public enum GraphemeFlag : long
    {
        /// <summary>
        /// <para>Grapheme is supported by the font, and can be drawn.</para>
        /// </summary>
        Valid = 1,
        /// <summary>
        /// <para>Grapheme is part of right-to-left or bottom-to-top run.</para>
        /// </summary>
        Rtl = 2,
        /// <summary>
        /// <para>Grapheme is not part of source text, it was added by justification process.</para>
        /// </summary>
        Virtual = 4,
        /// <summary>
        /// <para>Grapheme is whitespace.</para>
        /// </summary>
        Space = 8,
        /// <summary>
        /// <para>Grapheme is mandatory break point (e.g. <c>"\n"</c>).</para>
        /// </summary>
        BreakHard = 16,
        /// <summary>
        /// <para>Grapheme is optional break point (e.g. space).</para>
        /// </summary>
        BreakSoft = 32,
        /// <summary>
        /// <para>Grapheme is the tabulation character.</para>
        /// </summary>
        Tab = 64,
        /// <summary>
        /// <para>Grapheme is kashida.</para>
        /// </summary>
        Elongation = 128,
        /// <summary>
        /// <para>Grapheme is punctuation character.</para>
        /// </summary>
        Punctuation = 256,
        /// <summary>
        /// <para>Grapheme is underscore character.</para>
        /// </summary>
        Underscore = 512,
        /// <summary>
        /// <para>Grapheme is connected to the previous grapheme. Breaking line before this grapheme is not safe.</para>
        /// </summary>
        Connected = 1024,
        /// <summary>
        /// <para>It is safe to insert a U+0640 before this grapheme for elongation.</para>
        /// </summary>
        SafeToInsertTatweel = 2048,
        /// <summary>
        /// <para>Grapheme is an object replacement character for the embedded object.</para>
        /// </summary>
        EmbeddedObject = 4096,
        /// <summary>
        /// <para>Grapheme is a soft hyphen.</para>
        /// </summary>
        SoftHyphen = 8192
    }

    public enum Hinting : long
    {
        /// <summary>
        /// <para>Disables font hinting (smoother but less crisp).</para>
        /// </summary>
        None = 0,
        /// <summary>
        /// <para>Use the light font hinting mode.</para>
        /// </summary>
        Light = 1,
        /// <summary>
        /// <para>Use the default font hinting mode (crisper but less smooth).</para>
        /// <para><b>Note:</b> This hinting mode changes both horizontal and vertical glyph metrics. If applied to monospace font, some glyphs might have different width.</para>
        /// </summary>
        Normal = 2
    }

    public enum SubpixelPositioning : long
    {
        /// <summary>
        /// <para>Glyph horizontal position is rounded to the whole pixel size, each glyph is rasterized once.</para>
        /// </summary>
        Disabled = 0,
        /// <summary>
        /// <para>Glyph horizontal position is rounded based on font size.</para>
        /// <para>- To one quarter of the pixel size if font size is smaller or equal to <see cref="Godot.TextServer.SubpixelPositioning.OneQuarterMaxSize"/>.</para>
        /// <para>- To one half of the pixel size if font size is smaller or equal to <see cref="Godot.TextServer.SubpixelPositioning.OneHalfMaxSize"/>.</para>
        /// <para>- To the whole pixel size for larger fonts.</para>
        /// </summary>
        Auto = 1,
        /// <summary>
        /// <para>Glyph horizontal position is rounded to one half of the pixel size, each glyph is rasterized up to two times.</para>
        /// </summary>
        OneHalf = 2,
        /// <summary>
        /// <para>Glyph horizontal position is rounded to one quarter of the pixel size, each glyph is rasterized up to four times.</para>
        /// </summary>
        OneQuarter = 3,
        /// <summary>
        /// <para>Maximum font size which will use "one half of the pixel" subpixel positioning in <see cref="Godot.TextServer.SubpixelPositioning.Auto"/> mode.</para>
        /// </summary>
        OneHalfMaxSize = 20,
        /// <summary>
        /// <para>Maximum font size which will use "one quarter of the pixel" subpixel positioning in <see cref="Godot.TextServer.SubpixelPositioning.Auto"/> mode.</para>
        /// </summary>
        OneQuarterMaxSize = 16
    }

    public enum Feature : long
    {
        /// <summary>
        /// <para>TextServer supports simple text layouts.</para>
        /// </summary>
        SimpleLayout = 1,
        /// <summary>
        /// <para>TextServer supports bidirectional text layouts.</para>
        /// </summary>
        BidiLayout = 2,
        /// <summary>
        /// <para>TextServer supports vertical layouts.</para>
        /// </summary>
        VerticalLayout = 4,
        /// <summary>
        /// <para>TextServer supports complex text shaping.</para>
        /// </summary>
        Shaping = 8,
        /// <summary>
        /// <para>TextServer supports justification using kashidas.</para>
        /// </summary>
        KashidaJustification = 16,
        /// <summary>
        /// <para>TextServer supports complex line/word breaking rules (e.g. dictionary based).</para>
        /// </summary>
        BreakIterators = 32,
        /// <summary>
        /// <para>TextServer supports loading bitmap fonts.</para>
        /// </summary>
        FontBitmap = 64,
        /// <summary>
        /// <para>TextServer supports loading dynamic (TrueType, OpeType, etc.) fonts.</para>
        /// </summary>
        FontDynamic = 128,
        /// <summary>
        /// <para>TextServer supports multichannel signed distance field dynamic font rendering.</para>
        /// </summary>
        FontMsdf = 256,
        /// <summary>
        /// <para>TextServer supports loading system fonts.</para>
        /// </summary>
        FontSystem = 512,
        /// <summary>
        /// <para>TextServer supports variable fonts.</para>
        /// </summary>
        FontVariable = 1024,
        /// <summary>
        /// <para>TextServer supports locale dependent and context sensitive case conversion.</para>
        /// </summary>
        ContextSensitiveCaseConversion = 2048,
        /// <summary>
        /// <para>TextServer require external data file for some features, see <see cref="Godot.TextServer.LoadSupportData(string)"/>.</para>
        /// </summary>
        UseSupportData = 4096,
        /// <summary>
        /// <para>TextServer supports UAX #31 identifier validation, see <see cref="Godot.TextServer.IsValidIdentifier(string)"/>.</para>
        /// </summary>
        UnicodeIdentifiers = 8192,
        /// <summary>
        /// <para>TextServer supports <a href="https://unicode.org/reports/tr36/">Unicode Technical Report #36</a> and <a href="https://unicode.org/reports/tr39/">Unicode Technical Standard #39</a> based spoof detection features.</para>
        /// </summary>
        UnicodeSecurity = 16384
    }

    public enum ContourPointTag : long
    {
        /// <summary>
        /// <para>Contour point is on the curve.</para>
        /// </summary>
        On = 1,
        /// <summary>
        /// <para>Contour point isn't on the curve, but serves as a control point for a conic (quadratic) Bézier arc.</para>
        /// </summary>
        OffConic = 0,
        /// <summary>
        /// <para>Contour point isn't on the curve, but serves as a control point for a cubic Bézier arc.</para>
        /// </summary>
        OffCubic = 2
    }

    public enum SpacingType : long
    {
        /// <summary>
        /// <para>Spacing for each glyph.</para>
        /// </summary>
        Glyph = 0,
        /// <summary>
        /// <para>Spacing for the space character.</para>
        /// </summary>
        Space = 1,
        /// <summary>
        /// <para>Spacing at the top of the line.</para>
        /// </summary>
        Top = 2,
        /// <summary>
        /// <para>Spacing at the bottom of the line.</para>
        /// </summary>
        Bottom = 3,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.TextServer.SpacingType"/> enum.</para>
        /// </summary>
        Max = 4
    }

    [System.Flags]
    public enum FontStyle : long
    {
        /// <summary>
        /// <para>Font is bold.</para>
        /// </summary>
        Bold = 1,
        /// <summary>
        /// <para>Font is italic or oblique.</para>
        /// </summary>
        Italic = 2,
        /// <summary>
        /// <para>Font has fixed-width characters (also known as monospace).</para>
        /// </summary>
        FixedWidth = 4
    }

    public enum StructuredTextParser : long
    {
        /// <summary>
        /// <para>Use default Unicode BiDi algorithm.</para>
        /// </summary>
        Default = 0,
        /// <summary>
        /// <para>BiDi override for URI.</para>
        /// </summary>
        Uri = 1,
        /// <summary>
        /// <para>BiDi override for file path.</para>
        /// </summary>
        File = 2,
        /// <summary>
        /// <para>BiDi override for email.</para>
        /// </summary>
        Email = 3,
        /// <summary>
        /// <para>BiDi override for lists. Structured text options: list separator <see cref="string"/>.</para>
        /// </summary>
        List = 4,
        /// <summary>
        /// <para>BiDi override for GDScript.</para>
        /// </summary>
        Gdscript = 5,
        /// <summary>
        /// <para>User defined structured text BiDi override function.</para>
        /// </summary>
        Custom = 6
    }

    public enum FixedSizeScaleMode : long
    {
        /// <summary>
        /// <para>Bitmap font is not scaled.</para>
        /// </summary>
        Disable = 0,
        /// <summary>
        /// <para>Bitmap font is scaled to the closest integer multiple of the font's fixed size. This is the recommended option for pixel art fonts.</para>
        /// </summary>
        IntegerOnly = 1,
        /// <summary>
        /// <para>Bitmap font is scaled to an arbitrary (fractional) size. This is the recommended option for non-pixel art fonts.</para>
        /// </summary>
        Enabled = 2
    }

    private static readonly System.Type CachedType = typeof(TextServer);

    private static readonly StringName NativeName = "TextServer";

    internal TextServer() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal TextServer(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal TextServer(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasFeature, 3967367083ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the server supports a feature.</para>
    /// </summary>
    public bool HasFeature(TextServer.Feature feature)
    {
        return NativeCalls.godot_icall_1_62(MethodBind0, GodotObject.GetPtr(this), (int)feature).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetName, 201670096ul);

    /// <summary>
    /// <para>Returns the name of the server interface.</para>
    /// </summary>
    public string GetName()
    {
        return NativeCalls.godot_icall_0_58(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFeatures, 3905245786ul);

    /// <summary>
    /// <para>Returns text server features, see <see cref="Godot.TextServer.Feature"/>.</para>
    /// </summary>
    public long GetFeatures()
    {
        return NativeCalls.godot_icall_0_4(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.LoadSupportData, 2323990056ul);

    /// <summary>
    /// <para>Loads optional TextServer database (e.g. ICU break iterators and dictionaries).</para>
    /// <para><b>Note:</b> This function should be called before any other TextServer functions used, otherwise it won't have any effect.</para>
    /// </summary>
    public bool LoadSupportData(string fileName)
    {
        return NativeCalls.godot_icall_1_131(MethodBind3, GodotObject.GetPtr(this), fileName).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSupportDataFileName, 201670096ul);

    /// <summary>
    /// <para>Returns default TextServer database (e.g. ICU break iterators and dictionaries) filename.</para>
    /// </summary>
    public string GetSupportDataFileName()
    {
        return NativeCalls.godot_icall_0_58(MethodBind4, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSupportDataInfo, 201670096ul);

    /// <summary>
    /// <para>Returns TextServer database (e.g. ICU break iterators and dictionaries) description.</para>
    /// </summary>
    public string GetSupportDataInfo()
    {
        return NativeCalls.godot_icall_0_58(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SaveSupportData, 3927539163ul);

    /// <summary>
    /// <para>Saves optional TextServer database (e.g. ICU break iterators and dictionaries) to the file.</para>
    /// <para><b>Note:</b> This function is used by during project export, to include TextServer database.</para>
    /// </summary>
    public bool SaveSupportData(string fileName)
    {
        return NativeCalls.godot_icall_1_131(MethodBind6, GodotObject.GetPtr(this), fileName).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSupportData, 2362200018ul);

    /// <summary>
    /// <para>Returns default TextServer database (e.g. ICU break iterators and dictionaries).</para>
    /// </summary>
    public byte[] GetSupportData()
    {
        return NativeCalls.godot_icall_0_2(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsLocaleUsingSupportData, 3927539163ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the locale requires text server support data for line/word breaking.</para>
    /// </summary>
    public bool IsLocaleUsingSupportData(string locale)
    {
        return NativeCalls.godot_icall_1_131(MethodBind8, GodotObject.GetPtr(this), locale).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsLocaleRightToLeft, 3927539163ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if locale is right-to-left.</para>
    /// </summary>
    public bool IsLocaleRightToLeft(string locale)
    {
        return NativeCalls.godot_icall_1_131(MethodBind9, GodotObject.GetPtr(this), locale).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.NameToTag, 1321353865ul);

    /// <summary>
    /// <para>Converts the given readable name of a feature, variation, script, or language to an OpenType tag.</para>
    /// </summary>
    public long NameToTag(string name)
    {
        return NativeCalls.godot_icall_1_1225(MethodBind10, GodotObject.GetPtr(this), name);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.TagToName, 844755477ul);

    /// <summary>
    /// <para>Converts the given OpenType tag to the readable name of a feature, variation, script, or language.</para>
    /// </summary>
    public string TagToName(long tag)
    {
        return NativeCalls.godot_icall_1_908(MethodBind11, GodotObject.GetPtr(this), tag);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Has, 3521089500ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if <paramref name="rid"/> is valid resource owned by this text server.</para>
    /// </summary>
    public bool Has(Rid rid)
    {
        return NativeCalls.godot_icall_1_421(MethodBind12, GodotObject.GetPtr(this), rid).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FreeRid, 2722037293ul);

    /// <summary>
    /// <para>Frees an object created by this <see cref="Godot.TextServer"/>.</para>
    /// </summary>
    public void FreeRid(Rid rid)
    {
        NativeCalls.godot_icall_1_286(MethodBind13, GodotObject.GetPtr(this), rid);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CreateFont, 529393457ul);

    /// <summary>
    /// <para>Creates a new, empty font cache entry resource. To free the resulting resource, use the <see cref="Godot.TextServer.FreeRid(Rid)"/> method.</para>
    /// </summary>
    public Rid CreateFont()
    {
        return NativeCalls.godot_icall_0_238(MethodBind14, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CreateFontLinkedVariation, 41030802ul);

    /// <summary>
    /// <para>Creates a new variation existing font which is reusing the same glyph cache and font data. To free the resulting resource, use the <see cref="Godot.TextServer.FreeRid(Rid)"/> method.</para>
    /// </summary>
    public Rid CreateFontLinkedVariation(Rid fontRid)
    {
        return NativeCalls.godot_icall_1_855(MethodBind15, GodotObject.GetPtr(this), fontRid);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontSetData, 1355495400ul);

    /// <summary>
    /// <para>Sets font source data, e.g contents of the dynamic font source file.</para>
    /// </summary>
    public void FontSetData(Rid fontRid, byte[] data)
    {
        NativeCalls.godot_icall_2_1333(MethodBind16, GodotObject.GetPtr(this), fontRid, data);
    }

    /// <summary>
    /// <para>Sets font source data, e.g contents of the dynamic font source file.</para>
    /// </summary>
    public void FontSetData(Rid fontRid, ReadOnlySpan<byte> data)
    {
        NativeCalls.godot_icall_2_1333(MethodBind16, GodotObject.GetPtr(this), fontRid, data);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontSetFaceIndex, 3411492887ul);

    /// <summary>
    /// <para>Sets an active face index in the TrueType / OpenType collection.</para>
    /// </summary>
    public void FontSetFaceIndex(Rid fontRid, long faceIndex)
    {
        NativeCalls.godot_icall_2_1334(MethodBind17, GodotObject.GetPtr(this), fontRid, faceIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontGetFaceIndex, 2198884583ul);

    /// <summary>
    /// <para>Returns an active face index in the TrueType / OpenType collection.</para>
    /// </summary>
    public long FontGetFaceIndex(Rid fontRid)
    {
        return NativeCalls.godot_icall_1_1066(MethodBind18, GodotObject.GetPtr(this), fontRid);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontGetFaceCount, 2198884583ul);

    /// <summary>
    /// <para>Returns number of faces in the TrueType / OpenType collection.</para>
    /// </summary>
    public long FontGetFaceCount(Rid fontRid)
    {
        return NativeCalls.godot_icall_1_1066(MethodBind19, GodotObject.GetPtr(this), fontRid);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontSetStyle, 898466325ul);

    /// <summary>
    /// <para>Sets the font style flags.</para>
    /// <para><b>Note:</b> This value is used for font matching only and will not affect font rendering. Use <see cref="Godot.TextServer.FontSetFaceIndex(Rid, long)"/>, <see cref="Godot.TextServer.FontSetVariationCoordinates(Rid, Godot.Collections.Dictionary)"/>, <see cref="Godot.TextServer.FontSetEmbolden(Rid, double)"/>, or <see cref="Godot.TextServer.FontSetTransform(Rid, Transform2D)"/> instead.</para>
    /// </summary>
    public void FontSetStyle(Rid fontRid, TextServer.FontStyle style)
    {
        NativeCalls.godot_icall_2_426(MethodBind20, GodotObject.GetPtr(this), fontRid, (int)style);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontGetStyle, 3082502592ul);

    /// <summary>
    /// <para>Returns font style flags.</para>
    /// </summary>
    public TextServer.FontStyle FontGetStyle(Rid fontRid)
    {
        return (TextServer.FontStyle)NativeCalls.godot_icall_1_835(MethodBind21, GodotObject.GetPtr(this), fontRid);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontSetName, 2726140452ul);

    /// <summary>
    /// <para>Sets the font family name.</para>
    /// </summary>
    public void FontSetName(Rid fontRid, string name)
    {
        NativeCalls.godot_icall_2_427(MethodBind22, GodotObject.GetPtr(this), fontRid, name);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontGetName, 642473191ul);

    /// <summary>
    /// <para>Returns font family name.</para>
    /// </summary>
    public string FontGetName(Rid fontRid)
    {
        return NativeCalls.godot_icall_1_940(MethodBind23, GodotObject.GetPtr(this), fontRid);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontGetOtNameStrings, 1882737106ul);

    /// <summary>
    /// <para>Returns <see cref="Godot.Collections.Dictionary"/> with OpenType font name strings (localized font names, version, description, license information, sample text, etc.).</para>
    /// </summary>
    public Godot.Collections.Dictionary FontGetOtNameStrings(Rid fontRid)
    {
        return NativeCalls.godot_icall_1_1335(MethodBind24, GodotObject.GetPtr(this), fontRid);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontSetStyleName, 2726140452ul);

    /// <summary>
    /// <para>Sets the font style name.</para>
    /// </summary>
    public void FontSetStyleName(Rid fontRid, string name)
    {
        NativeCalls.godot_icall_2_427(MethodBind25, GodotObject.GetPtr(this), fontRid, name);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontGetStyleName, 642473191ul);

    /// <summary>
    /// <para>Returns font style name.</para>
    /// </summary>
    public string FontGetStyleName(Rid fontRid)
    {
        return NativeCalls.godot_icall_1_940(MethodBind26, GodotObject.GetPtr(this), fontRid);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontSetWeight, 3411492887ul);

    /// <summary>
    /// <para>Sets weight (boldness) of the font. A value in the <c>100...999</c> range, normal font weight is <c>400</c>, bold font weight is <c>700</c>.</para>
    /// <para><b>Note:</b> This value is used for font matching only and will not affect font rendering. Use <see cref="Godot.TextServer.FontSetFaceIndex(Rid, long)"/>, <see cref="Godot.TextServer.FontSetVariationCoordinates(Rid, Godot.Collections.Dictionary)"/>, or <see cref="Godot.TextServer.FontSetEmbolden(Rid, double)"/> instead.</para>
    /// </summary>
    public void FontSetWeight(Rid fontRid, long weight)
    {
        NativeCalls.godot_icall_2_1334(MethodBind27, GodotObject.GetPtr(this), fontRid, weight);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontGetWeight, 2198884583ul);

    /// <summary>
    /// <para>Returns weight (boldness) of the font. A value in the <c>100...999</c> range, normal font weight is <c>400</c>, bold font weight is <c>700</c>.</para>
    /// </summary>
    public long FontGetWeight(Rid fontRid)
    {
        return NativeCalls.godot_icall_1_1066(MethodBind28, GodotObject.GetPtr(this), fontRid);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontSetStretch, 3411492887ul);

    /// <summary>
    /// <para>Sets font stretch amount, compared to a normal width. A percentage value between <c>50%</c> and <c>200%</c>.</para>
    /// <para><b>Note:</b> This value is used for font matching only and will not affect font rendering. Use <see cref="Godot.TextServer.FontSetFaceIndex(Rid, long)"/>, <see cref="Godot.TextServer.FontSetVariationCoordinates(Rid, Godot.Collections.Dictionary)"/>, or <see cref="Godot.TextServer.FontSetTransform(Rid, Transform2D)"/> instead.</para>
    /// </summary>
    public void FontSetStretch(Rid fontRid, long weight)
    {
        NativeCalls.godot_icall_2_1334(MethodBind29, GodotObject.GetPtr(this), fontRid, weight);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontGetStretch, 2198884583ul);

    /// <summary>
    /// <para>Returns font stretch amount, compared to a normal width. A percentage value between <c>50%</c> and <c>200%</c>.</para>
    /// </summary>
    public long FontGetStretch(Rid fontRid)
    {
        return NativeCalls.godot_icall_1_1066(MethodBind30, GodotObject.GetPtr(this), fontRid);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontSetAntialiasing, 958337235ul);

    /// <summary>
    /// <para>Sets font anti-aliasing mode.</para>
    /// </summary>
    public void FontSetAntialiasing(Rid fontRid, TextServer.FontAntialiasing antialiasing)
    {
        NativeCalls.godot_icall_2_426(MethodBind31, GodotObject.GetPtr(this), fontRid, (int)antialiasing);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind32 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontGetAntialiasing, 3389420495ul);

    /// <summary>
    /// <para>Returns font anti-aliasing mode.</para>
    /// </summary>
    public TextServer.FontAntialiasing FontGetAntialiasing(Rid fontRid)
    {
        return (TextServer.FontAntialiasing)NativeCalls.godot_icall_1_835(MethodBind32, GodotObject.GetPtr(this), fontRid);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind33 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontSetDisableEmbeddedBitmaps, 1265174801ul);

    /// <summary>
    /// <para>If set to <see langword="true"/>, embedded font bitmap loading is disabled (bitmap-only and color fonts ignore this property).</para>
    /// </summary>
    public void FontSetDisableEmbeddedBitmaps(Rid fontRid, bool disableEmbeddedBitmaps)
    {
        NativeCalls.godot_icall_2_434(MethodBind33, GodotObject.GetPtr(this), fontRid, disableEmbeddedBitmaps.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind34 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontGetDisableEmbeddedBitmaps, 4155700596ul);

    /// <summary>
    /// <para>Returns whether the font's embedded bitmap loading is disabled.</para>
    /// </summary>
    public bool FontGetDisableEmbeddedBitmaps(Rid fontRid)
    {
        return NativeCalls.godot_icall_1_421(MethodBind34, GodotObject.GetPtr(this), fontRid).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind35 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontSetGenerateMipmaps, 1265174801ul);

    /// <summary>
    /// <para>If set to <see langword="true"/> font texture mipmap generation is enabled.</para>
    /// </summary>
    public void FontSetGenerateMipmaps(Rid fontRid, bool generateMipmaps)
    {
        NativeCalls.godot_icall_2_434(MethodBind35, GodotObject.GetPtr(this), fontRid, generateMipmaps.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind36 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontGetGenerateMipmaps, 4155700596ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if font texture mipmap generation is enabled.</para>
    /// </summary>
    public bool FontGetGenerateMipmaps(Rid fontRid)
    {
        return NativeCalls.godot_icall_1_421(MethodBind36, GodotObject.GetPtr(this), fontRid).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind37 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontSetMultichannelSignedDistanceField, 1265174801ul);

    /// <summary>
    /// <para>If set to <see langword="true"/>, glyphs of all sizes are rendered using single multichannel signed distance field generated from the dynamic font vector data. MSDF rendering allows displaying the font at any scaling factor without blurriness, and without incurring a CPU cost when the font size changes (since the font no longer needs to be rasterized on the CPU). As a downside, font hinting is not available with MSDF. The lack of font hinting may result in less crisp and less readable fonts at small sizes.</para>
    /// <para><b>Note:</b> MSDF font rendering does not render glyphs with overlapping shapes correctly. Overlapping shapes are not valid per the OpenType standard, but are still commonly found in many font files, especially those converted by Google Fonts. To avoid issues with overlapping glyphs, consider downloading the font file directly from the type foundry instead of relying on Google Fonts.</para>
    /// </summary>
    public void FontSetMultichannelSignedDistanceField(Rid fontRid, bool msdf)
    {
        NativeCalls.godot_icall_2_434(MethodBind37, GodotObject.GetPtr(this), fontRid, msdf.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind38 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontIsMultichannelSignedDistanceField, 4155700596ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if glyphs of all sizes are rendered using single multichannel signed distance field generated from the dynamic font vector data.</para>
    /// </summary>
    public bool FontIsMultichannelSignedDistanceField(Rid fontRid)
    {
        return NativeCalls.godot_icall_1_421(MethodBind38, GodotObject.GetPtr(this), fontRid).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind39 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontSetMsdfPixelRange, 3411492887ul);

    /// <summary>
    /// <para>Sets the width of the range around the shape between the minimum and maximum representable signed distance.</para>
    /// </summary>
    public void FontSetMsdfPixelRange(Rid fontRid, long msdfPixelRange)
    {
        NativeCalls.godot_icall_2_1334(MethodBind39, GodotObject.GetPtr(this), fontRid, msdfPixelRange);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind40 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontGetMsdfPixelRange, 2198884583ul);

    /// <summary>
    /// <para>Returns the width of the range around the shape between the minimum and maximum representable signed distance.</para>
    /// </summary>
    public long FontGetMsdfPixelRange(Rid fontRid)
    {
        return NativeCalls.godot_icall_1_1066(MethodBind40, GodotObject.GetPtr(this), fontRid);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind41 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontSetMsdfSize, 3411492887ul);

    /// <summary>
    /// <para>Sets source font size used to generate MSDF textures.</para>
    /// </summary>
    public void FontSetMsdfSize(Rid fontRid, long msdfSize)
    {
        NativeCalls.godot_icall_2_1334(MethodBind41, GodotObject.GetPtr(this), fontRid, msdfSize);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind42 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontGetMsdfSize, 2198884583ul);

    /// <summary>
    /// <para>Returns source font size used to generate MSDF textures.</para>
    /// </summary>
    public long FontGetMsdfSize(Rid fontRid)
    {
        return NativeCalls.godot_icall_1_1066(MethodBind42, GodotObject.GetPtr(this), fontRid);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind43 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontSetFixedSize, 3411492887ul);

    /// <summary>
    /// <para>Sets bitmap font fixed size. If set to value greater than zero, same cache entry will be used for all font sizes.</para>
    /// </summary>
    public void FontSetFixedSize(Rid fontRid, long fixedSize)
    {
        NativeCalls.godot_icall_2_1334(MethodBind43, GodotObject.GetPtr(this), fontRid, fixedSize);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind44 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontGetFixedSize, 2198884583ul);

    /// <summary>
    /// <para>Returns bitmap font fixed size.</para>
    /// </summary>
    public long FontGetFixedSize(Rid fontRid)
    {
        return NativeCalls.godot_icall_1_1066(MethodBind44, GodotObject.GetPtr(this), fontRid);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind45 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontSetFixedSizeScaleMode, 1029390307ul);

    /// <summary>
    /// <para>Sets bitmap font scaling mode. This property is used only if <c>fixed_size</c> is greater than zero.</para>
    /// </summary>
    public void FontSetFixedSizeScaleMode(Rid fontRid, TextServer.FixedSizeScaleMode fixedSizeScaleMode)
    {
        NativeCalls.godot_icall_2_426(MethodBind45, GodotObject.GetPtr(this), fontRid, (int)fixedSizeScaleMode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind46 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontGetFixedSizeScaleMode, 4113120379ul);

    /// <summary>
    /// <para>Returns bitmap font scaling mode.</para>
    /// </summary>
    public TextServer.FixedSizeScaleMode FontGetFixedSizeScaleMode(Rid fontRid)
    {
        return (TextServer.FixedSizeScaleMode)NativeCalls.godot_icall_1_835(MethodBind46, GodotObject.GetPtr(this), fontRid);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind47 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontSetAllowSystemFallback, 1265174801ul);

    /// <summary>
    /// <para>If set to <see langword="true"/>, system fonts can be automatically used as fallbacks.</para>
    /// </summary>
    public void FontSetAllowSystemFallback(Rid fontRid, bool allowSystemFallback)
    {
        NativeCalls.godot_icall_2_434(MethodBind47, GodotObject.GetPtr(this), fontRid, allowSystemFallback.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind48 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontIsAllowSystemFallback, 4155700596ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if system fonts can be automatically used as fallbacks.</para>
    /// </summary>
    public bool FontIsAllowSystemFallback(Rid fontRid)
    {
        return NativeCalls.godot_icall_1_421(MethodBind48, GodotObject.GetPtr(this), fontRid).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind49 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontClearSystemFallbackCache, 3218959716ul);

    /// <summary>
    /// <para>Frees all automatically loaded system fonts.</para>
    /// </summary>
    public void FontClearSystemFallbackCache()
    {
        NativeCalls.godot_icall_0_3(MethodBind49, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind50 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontSetForceAutohinter, 1265174801ul);

    /// <summary>
    /// <para>If set to <see langword="true"/> auto-hinting is preferred over font built-in hinting.</para>
    /// </summary>
    public void FontSetForceAutohinter(Rid fontRid, bool forceAutohinter)
    {
        NativeCalls.godot_icall_2_434(MethodBind50, GodotObject.GetPtr(this), fontRid, forceAutohinter.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind51 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontIsForceAutohinter, 4155700596ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if auto-hinting is supported and preferred over font built-in hinting. Used by dynamic fonts only.</para>
    /// </summary>
    public bool FontIsForceAutohinter(Rid fontRid)
    {
        return NativeCalls.godot_icall_1_421(MethodBind51, GodotObject.GetPtr(this), fontRid).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind52 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontSetModulateColorGlyphs, 1265174801ul);

    /// <summary>
    /// <para>If set to <see langword="true"/>, color modulation is applied when drawing colored glyphs, otherwise it's applied to the monochrome glyphs only.</para>
    /// </summary>
    public void FontSetModulateColorGlyphs(Rid fontRid, bool forceAutohinter)
    {
        NativeCalls.godot_icall_2_434(MethodBind52, GodotObject.GetPtr(this), fontRid, forceAutohinter.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind53 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontIsModulateColorGlyphs, 4155700596ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if color modulation is applied when drawing the font's colored glyphs.</para>
    /// </summary>
    public bool FontIsModulateColorGlyphs(Rid fontRid)
    {
        return NativeCalls.godot_icall_1_421(MethodBind53, GodotObject.GetPtr(this), fontRid).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind54 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontSetHinting, 1520010864ul);

    /// <summary>
    /// <para>Sets font hinting mode. Used by dynamic fonts only.</para>
    /// </summary>
    public void FontSetHinting(Rid fontRid, TextServer.Hinting hinting)
    {
        NativeCalls.godot_icall_2_426(MethodBind54, GodotObject.GetPtr(this), fontRid, (int)hinting);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind55 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontGetHinting, 3971592737ul);

    /// <summary>
    /// <para>Returns the font hinting mode. Used by dynamic fonts only.</para>
    /// </summary>
    public TextServer.Hinting FontGetHinting(Rid fontRid)
    {
        return (TextServer.Hinting)NativeCalls.godot_icall_1_835(MethodBind55, GodotObject.GetPtr(this), fontRid);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind56 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontSetSubpixelPositioning, 3830459669ul);

    /// <summary>
    /// <para>Sets font subpixel glyph positioning mode.</para>
    /// </summary>
    public void FontSetSubpixelPositioning(Rid fontRid, TextServer.SubpixelPositioning subpixelPositioning)
    {
        NativeCalls.godot_icall_2_426(MethodBind56, GodotObject.GetPtr(this), fontRid, (int)subpixelPositioning);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind57 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontGetSubpixelPositioning, 2752233671ul);

    /// <summary>
    /// <para>Returns font subpixel glyph positioning mode.</para>
    /// </summary>
    public TextServer.SubpixelPositioning FontGetSubpixelPositioning(Rid fontRid)
    {
        return (TextServer.SubpixelPositioning)NativeCalls.godot_icall_1_835(MethodBind57, GodotObject.GetPtr(this), fontRid);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind58 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontSetKeepRoundingRemainders, 1265174801ul);

    /// <summary>
    /// <para>Sets glyph position rounding behavior. If set to <see langword="true"/>, when aligning glyphs to the pixel boundaries rounding remainders are accumulated to ensure more uniform glyph distribution. This setting has no effect if subpixel positioning is enabled.</para>
    /// </summary>
    public void FontSetKeepRoundingRemainders(Rid fontRid, bool keepRoundingRemainders)
    {
        NativeCalls.godot_icall_2_434(MethodBind58, GodotObject.GetPtr(this), fontRid, keepRoundingRemainders.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind59 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontGetKeepRoundingRemainders, 4155700596ul);

    /// <summary>
    /// <para>Returns glyph position rounding behavior. If set to <see langword="true"/>, when aligning glyphs to the pixel boundaries rounding remainders are accumulated to ensure more uniform glyph distribution. This setting has no effect if subpixel positioning is enabled.</para>
    /// </summary>
    public bool FontGetKeepRoundingRemainders(Rid fontRid)
    {
        return NativeCalls.godot_icall_1_421(MethodBind59, GodotObject.GetPtr(this), fontRid).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind60 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontSetEmbolden, 1794382983ul);

    /// <summary>
    /// <para>Sets font embolden strength. If <paramref name="strength"/> is not equal to zero, emboldens the font outlines. Negative values reduce the outline thickness.</para>
    /// </summary>
    public void FontSetEmbolden(Rid fontRid, double strength)
    {
        NativeCalls.godot_icall_2_435(MethodBind60, GodotObject.GetPtr(this), fontRid, strength);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind61 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontGetEmbolden, 866169185ul);

    /// <summary>
    /// <para>Returns font embolden strength.</para>
    /// </summary>
    public double FontGetEmbolden(Rid fontRid)
    {
        return NativeCalls.godot_icall_1_1163(MethodBind61, GodotObject.GetPtr(this), fontRid);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind62 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontSetSpacing, 1307259930ul);

    /// <summary>
    /// <para>Sets the spacing for <paramref name="spacing"/> to <paramref name="value"/> in pixels (not relative to the font size).</para>
    /// </summary>
    public void FontSetSpacing(Rid fontRid, TextServer.SpacingType spacing, long value)
    {
        NativeCalls.godot_icall_3_1336(MethodBind62, GodotObject.GetPtr(this), fontRid, (int)spacing, value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind63 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontGetSpacing, 1213653558ul);

    /// <summary>
    /// <para>Returns the spacing for <paramref name="spacing"/> in pixels (not relative to the font size).</para>
    /// </summary>
    public long FontGetSpacing(Rid fontRid, TextServer.SpacingType spacing)
    {
        return NativeCalls.godot_icall_2_1337(MethodBind63, GodotObject.GetPtr(this), fontRid, (int)spacing);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind64 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontSetBaselineOffset, 1794382983ul);

    /// <summary>
    /// <para>Sets extra baseline offset (as a fraction of font height).</para>
    /// </summary>
    public void FontSetBaselineOffset(Rid fontRid, double baselineOffset)
    {
        NativeCalls.godot_icall_2_435(MethodBind64, GodotObject.GetPtr(this), fontRid, baselineOffset);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind65 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontGetBaselineOffset, 866169185ul);

    /// <summary>
    /// <para>Returns extra baseline offset (as a fraction of font height).</para>
    /// </summary>
    public double FontGetBaselineOffset(Rid fontRid)
    {
        return NativeCalls.godot_icall_1_1163(MethodBind65, GodotObject.GetPtr(this), fontRid);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind66 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontSetTransform, 1246044741ul);

    /// <summary>
    /// <para>Sets 2D transform, applied to the font outlines, can be used for slanting, flipping, and rotating glyphs.</para>
    /// <para>For example, to simulate italic typeface by slanting, apply the following transform <c>Transform2D(1.0, slant, 0.0, 1.0, 0.0, 0.0)</c>.</para>
    /// </summary>
    public unsafe void FontSetTransform(Rid fontRid, Transform2D transform)
    {
        NativeCalls.godot_icall_2_429(MethodBind66, GodotObject.GetPtr(this), fontRid, &transform);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind67 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontGetTransform, 213527486ul);

    /// <summary>
    /// <para>Returns 2D transform applied to the font outlines.</para>
    /// </summary>
    public Transform2D FontGetTransform(Rid fontRid)
    {
        return NativeCalls.godot_icall_1_857(MethodBind67, GodotObject.GetPtr(this), fontRid);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind68 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontSetVariationCoordinates, 1217542888ul);

    /// <summary>
    /// <para>Sets variation coordinates for the specified font cache entry. See <see cref="Godot.TextServer.FontSupportedVariationList(Rid)"/> for more info.</para>
    /// </summary>
    public void FontSetVariationCoordinates(Rid fontRid, Godot.Collections.Dictionary variationCoordinates)
    {
        NativeCalls.godot_icall_2_1131(MethodBind68, GodotObject.GetPtr(this), fontRid, (godot_dictionary)(variationCoordinates ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind69 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontGetVariationCoordinates, 1882737106ul);

    /// <summary>
    /// <para>Returns variation coordinates for the specified font cache entry. See <see cref="Godot.TextServer.FontSupportedVariationList(Rid)"/> for more info.</para>
    /// </summary>
    public Godot.Collections.Dictionary FontGetVariationCoordinates(Rid fontRid)
    {
        return NativeCalls.godot_icall_1_1335(MethodBind69, GodotObject.GetPtr(this), fontRid);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind70 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontSetOversampling, 1794382983ul);

    /// <summary>
    /// <para>If set to a positive value, overrides the oversampling factor of the viewport this font is used in. See <see cref="Godot.Viewport.Oversampling"/>. This value doesn't override the <c>oversampling</c> parameter of <c>draw_*</c> methods. Used by dynamic fonts only.</para>
    /// </summary>
    public void FontSetOversampling(Rid fontRid, double oversampling)
    {
        NativeCalls.godot_icall_2_435(MethodBind70, GodotObject.GetPtr(this), fontRid, oversampling);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind71 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontGetOversampling, 866169185ul);

    /// <summary>
    /// <para>Returns oversampling factor override. If set to a positive value, overrides the oversampling factor of the viewport this font is used in. See <see cref="Godot.Viewport.Oversampling"/>. This value doesn't override the <c>oversampling</c> parameter of <c>draw_*</c> methods. Used by dynamic fonts only.</para>
    /// </summary>
    public double FontGetOversampling(Rid fontRid)
    {
        return NativeCalls.godot_icall_1_1163(MethodBind71, GodotObject.GetPtr(this), fontRid);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind72 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontGetSizeCacheList, 2684255073ul);

    /// <summary>
    /// <para>Returns list of the font sizes in the cache. Each size is <see cref="Godot.Vector2I"/> with font size and outline size.</para>
    /// </summary>
    public Godot.Collections.Array<Vector2I> FontGetSizeCacheList(Rid fontRid)
    {
        return new Godot.Collections.Array<Vector2I>(NativeCalls.godot_icall_1_849(MethodBind72, GodotObject.GetPtr(this), fontRid));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind73 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontClearSizeCache, 2722037293ul);

    /// <summary>
    /// <para>Removes all font sizes from the cache entry.</para>
    /// </summary>
    public void FontClearSizeCache(Rid fontRid)
    {
        NativeCalls.godot_icall_1_286(MethodBind73, GodotObject.GetPtr(this), fontRid);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind74 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontRemoveSizeCache, 2450610377ul);

    /// <summary>
    /// <para>Removes specified font size from the cache entry.</para>
    /// </summary>
    public unsafe void FontRemoveSizeCache(Rid fontRid, Vector2I size)
    {
        NativeCalls.godot_icall_2_813(MethodBind74, GodotObject.GetPtr(this), fontRid, &size);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind75 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontGetSizeCacheInfo, 2684255073ul);

    /// <summary>
    /// <para>Returns font cache information, each entry contains the following fields: <c>Vector2i size_px</c> - font size in pixels, <c>float viewport_oversampling</c> - viewport oversampling factor, <c>int glyphs</c> - number of rendered glyphs, <c>int textures</c> - number of used textures, <c>int textures_size</c> - size of texture data in bytes.</para>
    /// </summary>
    public Godot.Collections.Array<Godot.Collections.Dictionary> FontGetSizeCacheInfo(Rid fontRid)
    {
        return new Godot.Collections.Array<Godot.Collections.Dictionary>(NativeCalls.godot_icall_1_849(MethodBind75, GodotObject.GetPtr(this), fontRid));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind76 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontSetAscent, 1892459533ul);

    /// <summary>
    /// <para>Sets the font ascent (number of pixels above the baseline).</para>
    /// </summary>
    public void FontSetAscent(Rid fontRid, long size, double ascent)
    {
        NativeCalls.godot_icall_3_1338(MethodBind76, GodotObject.GetPtr(this), fontRid, size, ascent);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind77 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontGetAscent, 755457166ul);

    /// <summary>
    /// <para>Returns the font ascent (number of pixels above the baseline).</para>
    /// </summary>
    public double FontGetAscent(Rid fontRid, long size)
    {
        return NativeCalls.godot_icall_2_1339(MethodBind77, GodotObject.GetPtr(this), fontRid, size);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind78 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontSetDescent, 1892459533ul);

    /// <summary>
    /// <para>Sets the font descent (number of pixels below the baseline).</para>
    /// </summary>
    public void FontSetDescent(Rid fontRid, long size, double descent)
    {
        NativeCalls.godot_icall_3_1338(MethodBind78, GodotObject.GetPtr(this), fontRid, size, descent);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind79 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontGetDescent, 755457166ul);

    /// <summary>
    /// <para>Returns the font descent (number of pixels below the baseline).</para>
    /// </summary>
    public double FontGetDescent(Rid fontRid, long size)
    {
        return NativeCalls.godot_icall_2_1339(MethodBind79, GodotObject.GetPtr(this), fontRid, size);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind80 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontSetUnderlinePosition, 1892459533ul);

    /// <summary>
    /// <para>Sets pixel offset of the underline below the baseline.</para>
    /// </summary>
    public void FontSetUnderlinePosition(Rid fontRid, long size, double underlinePosition)
    {
        NativeCalls.godot_icall_3_1338(MethodBind80, GodotObject.GetPtr(this), fontRid, size, underlinePosition);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind81 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontGetUnderlinePosition, 755457166ul);

    /// <summary>
    /// <para>Returns pixel offset of the underline below the baseline.</para>
    /// </summary>
    public double FontGetUnderlinePosition(Rid fontRid, long size)
    {
        return NativeCalls.godot_icall_2_1339(MethodBind81, GodotObject.GetPtr(this), fontRid, size);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind82 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontSetUnderlineThickness, 1892459533ul);

    /// <summary>
    /// <para>Sets thickness of the underline in pixels.</para>
    /// </summary>
    public void FontSetUnderlineThickness(Rid fontRid, long size, double underlineThickness)
    {
        NativeCalls.godot_icall_3_1338(MethodBind82, GodotObject.GetPtr(this), fontRid, size, underlineThickness);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind83 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontGetUnderlineThickness, 755457166ul);

    /// <summary>
    /// <para>Returns thickness of the underline in pixels.</para>
    /// </summary>
    public double FontGetUnderlineThickness(Rid fontRid, long size)
    {
        return NativeCalls.godot_icall_2_1339(MethodBind83, GodotObject.GetPtr(this), fontRid, size);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind84 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontSetScale, 1892459533ul);

    /// <summary>
    /// <para>Sets scaling factor of the color bitmap font.</para>
    /// </summary>
    public void FontSetScale(Rid fontRid, long size, double scale)
    {
        NativeCalls.godot_icall_3_1338(MethodBind84, GodotObject.GetPtr(this), fontRid, size, scale);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind85 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontGetScale, 755457166ul);

    /// <summary>
    /// <para>Returns scaling factor of the color bitmap font.</para>
    /// </summary>
    public double FontGetScale(Rid fontRid, long size)
    {
        return NativeCalls.godot_icall_2_1339(MethodBind85, GodotObject.GetPtr(this), fontRid, size);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind86 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontGetTextureCount, 1311001310ul);

    /// <summary>
    /// <para>Returns number of textures used by font cache entry.</para>
    /// </summary>
    public unsafe long FontGetTextureCount(Rid fontRid, Vector2I size)
    {
        return NativeCalls.godot_icall_2_1340(MethodBind86, GodotObject.GetPtr(this), fontRid, &size);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind87 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontClearTextures, 2450610377ul);

    /// <summary>
    /// <para>Removes all textures from font cache entry.</para>
    /// <para><b>Note:</b> This function will not remove glyphs associated with the texture, use <see cref="Godot.TextServer.FontRemoveGlyph(Rid, Vector2I, long)"/> to remove them manually.</para>
    /// </summary>
    public unsafe void FontClearTextures(Rid fontRid, Vector2I size)
    {
        NativeCalls.godot_icall_2_813(MethodBind87, GodotObject.GetPtr(this), fontRid, &size);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind88 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontRemoveTexture, 3810512262ul);

    /// <summary>
    /// <para>Removes specified texture from the cache entry.</para>
    /// <para><b>Note:</b> This function will not remove glyphs associated with the texture, remove them manually, using <see cref="Godot.TextServer.FontRemoveGlyph(Rid, Vector2I, long)"/>.</para>
    /// </summary>
    public unsafe void FontRemoveTexture(Rid fontRid, Vector2I size, long textureIndex)
    {
        NativeCalls.godot_icall_3_1341(MethodBind88, GodotObject.GetPtr(this), fontRid, &size, textureIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind89 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontSetTextureImage, 2354485091ul);

    /// <summary>
    /// <para>Sets font cache texture image data.</para>
    /// </summary>
    public unsafe void FontSetTextureImage(Rid fontRid, Vector2I size, long textureIndex, Image image)
    {
        NativeCalls.godot_icall_4_1342(MethodBind89, GodotObject.GetPtr(this), fontRid, &size, textureIndex, GodotObject.GetPtr(image));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind90 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontGetTextureImage, 2451761155ul);

    /// <summary>
    /// <para>Returns font cache texture image data.</para>
    /// </summary>
    public unsafe Image FontGetTextureImage(Rid fontRid, Vector2I size, long textureIndex)
    {
        return (Image)NativeCalls.godot_icall_3_1343(MethodBind90, GodotObject.GetPtr(this), fontRid, &size, textureIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind91 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontSetTextureOffsets, 3005398047ul);

    /// <summary>
    /// <para>Sets array containing glyph packing data.</para>
    /// </summary>
    public unsafe void FontSetTextureOffsets(Rid fontRid, Vector2I size, long textureIndex, int[] offset)
    {
        NativeCalls.godot_icall_4_1344(MethodBind91, GodotObject.GetPtr(this), fontRid, &size, textureIndex, offset);
    }

    /// <summary>
    /// <para>Sets array containing glyph packing data.</para>
    /// </summary>
    public unsafe void FontSetTextureOffsets(Rid fontRid, Vector2I size, long textureIndex, ReadOnlySpan<int> offset)
    {
        NativeCalls.godot_icall_4_1344(MethodBind91, GodotObject.GetPtr(this), fontRid, &size, textureIndex, offset);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind92 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontGetTextureOffsets, 3420028887ul);

    /// <summary>
    /// <para>Returns array containing glyph packing data.</para>
    /// </summary>
    public unsafe int[] FontGetTextureOffsets(Rid fontRid, Vector2I size, long textureIndex)
    {
        return NativeCalls.godot_icall_3_1345(MethodBind92, GodotObject.GetPtr(this), fontRid, &size, textureIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind93 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontGetGlyphList, 46086620ul);

    /// <summary>
    /// <para>Returns list of rendered glyphs in the cache entry.</para>
    /// </summary>
    public unsafe int[] FontGetGlyphList(Rid fontRid, Vector2I size)
    {
        return NativeCalls.godot_icall_2_1346(MethodBind93, GodotObject.GetPtr(this), fontRid, &size);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind94 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontClearGlyphs, 2450610377ul);

    /// <summary>
    /// <para>Removes all rendered glyph information from the cache entry.</para>
    /// <para><b>Note:</b> This function will not remove textures associated with the glyphs, use <see cref="Godot.TextServer.FontRemoveTexture(Rid, Vector2I, long)"/> to remove them manually.</para>
    /// </summary>
    public unsafe void FontClearGlyphs(Rid fontRid, Vector2I size)
    {
        NativeCalls.godot_icall_2_813(MethodBind94, GodotObject.GetPtr(this), fontRid, &size);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind95 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontRemoveGlyph, 3810512262ul);

    /// <summary>
    /// <para>Removes specified rendered glyph information from the cache entry.</para>
    /// <para><b>Note:</b> This function will not remove textures associated with the glyphs, use <see cref="Godot.TextServer.FontRemoveTexture(Rid, Vector2I, long)"/> to remove them manually.</para>
    /// </summary>
    public unsafe void FontRemoveGlyph(Rid fontRid, Vector2I size, long glyph)
    {
        NativeCalls.godot_icall_3_1341(MethodBind95, GodotObject.GetPtr(this), fontRid, &size, glyph);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind96 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontGetGlyphAdvance, 2555689501ul);

    /// <summary>
    /// <para>Returns glyph advance (offset of the next glyph).</para>
    /// <para><b>Note:</b> Advance for glyphs outlines is the same as the base glyph advance and is not saved.</para>
    /// </summary>
    public Vector2 FontGetGlyphAdvance(Rid fontRid, long size, long glyph)
    {
        return NativeCalls.godot_icall_3_1347(MethodBind96, GodotObject.GetPtr(this), fontRid, size, glyph);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind97 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontSetGlyphAdvance, 3219397315ul);

    /// <summary>
    /// <para>Sets glyph advance (offset of the next glyph).</para>
    /// <para><b>Note:</b> Advance for glyphs outlines is the same as the base glyph advance and is not saved.</para>
    /// </summary>
    public unsafe void FontSetGlyphAdvance(Rid fontRid, long size, long glyph, Vector2 advance)
    {
        NativeCalls.godot_icall_4_1348(MethodBind97, GodotObject.GetPtr(this), fontRid, size, glyph, &advance);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind98 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontGetGlyphOffset, 513728628ul);

    /// <summary>
    /// <para>Returns glyph offset from the baseline.</para>
    /// </summary>
    public unsafe Vector2 FontGetGlyphOffset(Rid fontRid, Vector2I size, long glyph)
    {
        return NativeCalls.godot_icall_3_1349(MethodBind98, GodotObject.GetPtr(this), fontRid, &size, glyph);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind99 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontSetGlyphOffset, 1812632090ul);

    /// <summary>
    /// <para>Sets glyph offset from the baseline.</para>
    /// </summary>
    public unsafe void FontSetGlyphOffset(Rid fontRid, Vector2I size, long glyph, Vector2 offset)
    {
        NativeCalls.godot_icall_4_1350(MethodBind99, GodotObject.GetPtr(this), fontRid, &size, glyph, &offset);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind100 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontGetGlyphSize, 513728628ul);

    /// <summary>
    /// <para>Returns size of the glyph.</para>
    /// </summary>
    public unsafe Vector2 FontGetGlyphSize(Rid fontRid, Vector2I size, long glyph)
    {
        return NativeCalls.godot_icall_3_1349(MethodBind100, GodotObject.GetPtr(this), fontRid, &size, glyph);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind101 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontSetGlyphSize, 1812632090ul);

    /// <summary>
    /// <para>Sets size of the glyph.</para>
    /// </summary>
    public unsafe void FontSetGlyphSize(Rid fontRid, Vector2I size, long glyph, Vector2 glSize)
    {
        NativeCalls.godot_icall_4_1350(MethodBind101, GodotObject.GetPtr(this), fontRid, &size, glyph, &glSize);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind102 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontGetGlyphUVRect, 2274268786ul);

    /// <summary>
    /// <para>Returns rectangle in the cache texture containing the glyph.</para>
    /// </summary>
    public unsafe Rect2 FontGetGlyphUVRect(Rid fontRid, Vector2I size, long glyph)
    {
        return NativeCalls.godot_icall_3_1351(MethodBind102, GodotObject.GetPtr(this), fontRid, &size, glyph);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind103 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontSetGlyphUVRect, 1973324081ul);

    /// <summary>
    /// <para>Sets rectangle in the cache texture containing the glyph.</para>
    /// </summary>
    public unsafe void FontSetGlyphUVRect(Rid fontRid, Vector2I size, long glyph, Rect2 uVRect)
    {
        NativeCalls.godot_icall_4_1352(MethodBind103, GodotObject.GetPtr(this), fontRid, &size, glyph, &uVRect);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind104 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontGetGlyphTextureIdx, 4292800474ul);

    /// <summary>
    /// <para>Returns index of the cache texture containing the glyph.</para>
    /// </summary>
    public unsafe long FontGetGlyphTextureIdx(Rid fontRid, Vector2I size, long glyph)
    {
        return NativeCalls.godot_icall_3_1353(MethodBind104, GodotObject.GetPtr(this), fontRid, &size, glyph);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind105 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontSetGlyphTextureIdx, 4254580980ul);

    /// <summary>
    /// <para>Sets index of the cache texture containing the glyph.</para>
    /// </summary>
    public unsafe void FontSetGlyphTextureIdx(Rid fontRid, Vector2I size, long glyph, long textureIdx)
    {
        NativeCalls.godot_icall_4_1354(MethodBind105, GodotObject.GetPtr(this), fontRid, &size, glyph, textureIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind106 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontGetGlyphTextureRid, 1451696141ul);

    /// <summary>
    /// <para>Returns resource ID of the cache texture containing the glyph.</para>
    /// <para><b>Note:</b> If there are pending glyphs to render, calling this function might trigger the texture cache update.</para>
    /// </summary>
    public unsafe Rid FontGetGlyphTextureRid(Rid fontRid, Vector2I size, long glyph)
    {
        return NativeCalls.godot_icall_3_1355(MethodBind106, GodotObject.GetPtr(this), fontRid, &size, glyph);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind107 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontGetGlyphTextureSize, 513728628ul);

    /// <summary>
    /// <para>Returns size of the cache texture containing the glyph.</para>
    /// <para><b>Note:</b> If there are pending glyphs to render, calling this function might trigger the texture cache update.</para>
    /// </summary>
    public unsafe Vector2 FontGetGlyphTextureSize(Rid fontRid, Vector2I size, long glyph)
    {
        return NativeCalls.godot_icall_3_1349(MethodBind107, GodotObject.GetPtr(this), fontRid, &size, glyph);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind108 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontGetGlyphContours, 2903964473ul);

    /// <summary>
    /// <para>Returns outline contours of the glyph as a <see cref="Godot.Collections.Dictionary"/> with the following contents:</para>
    /// <para><c>points</c>         - <see cref="Godot.Vector3"/>[], containing outline points. <c>x</c> and <c>y</c> are point coordinates. <c>z</c> is the type of the point, using the <see cref="Godot.TextServer.ContourPointTag"/> values.</para>
    /// <para><c>contours</c>       - <see cref="int"/>[], containing indices the end points of each contour.</para>
    /// <para><c>orientation</c>    - <see cref="bool"/>, contour orientation. If <see langword="true"/>, clockwise contours must be filled.</para>
    /// <para>- Two successive <see cref="Godot.TextServer.ContourPointTag.On"/> points indicate a line segment.</para>
    /// <para>- One <see cref="Godot.TextServer.ContourPointTag.OffConic"/> point between two <see cref="Godot.TextServer.ContourPointTag.On"/> points indicates a single conic (quadratic) Bézier arc.</para>
    /// <para>- Two <see cref="Godot.TextServer.ContourPointTag.OffCubic"/> points between two <see cref="Godot.TextServer.ContourPointTag.On"/> points indicate a single cubic Bézier arc.</para>
    /// <para>- Two successive <see cref="Godot.TextServer.ContourPointTag.OffConic"/> points indicate two successive conic (quadratic) Bézier arcs with a virtual <see cref="Godot.TextServer.ContourPointTag.On"/> point at their middle.</para>
    /// <para>- Each contour is closed. The last point of a contour uses the first point of a contour as its next point, and vice versa. The first point can be <see cref="Godot.TextServer.ContourPointTag.OffConic"/> point.</para>
    /// </summary>
    public Godot.Collections.Dictionary FontGetGlyphContours(Rid font, long size, long index)
    {
        return NativeCalls.godot_icall_3_1356(MethodBind108, GodotObject.GetPtr(this), font, size, index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind109 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontGetKerningList, 1778388067ul);

    /// <summary>
    /// <para>Returns list of the kerning overrides.</para>
    /// </summary>
    public Godot.Collections.Array<Vector2I> FontGetKerningList(Rid fontRid, long size)
    {
        return new Godot.Collections.Array<Vector2I>(NativeCalls.godot_icall_2_1357(MethodBind109, GodotObject.GetPtr(this), fontRid, size));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind110 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontClearKerningMap, 3411492887ul);

    /// <summary>
    /// <para>Removes all kerning overrides.</para>
    /// </summary>
    public void FontClearKerningMap(Rid fontRid, long size)
    {
        NativeCalls.godot_icall_2_1334(MethodBind110, GodotObject.GetPtr(this), fontRid, size);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind111 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontRemoveKerning, 2141860016ul);

    /// <summary>
    /// <para>Removes kerning override for the pair of glyphs.</para>
    /// </summary>
    public unsafe void FontRemoveKerning(Rid fontRid, long size, Vector2I glyphPair)
    {
        NativeCalls.godot_icall_3_1358(MethodBind111, GodotObject.GetPtr(this), fontRid, size, &glyphPair);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind112 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontSetKerning, 3630965883ul);

    /// <summary>
    /// <para>Sets kerning for the pair of glyphs.</para>
    /// </summary>
    public unsafe void FontSetKerning(Rid fontRid, long size, Vector2I glyphPair, Vector2 kerning)
    {
        NativeCalls.godot_icall_4_1359(MethodBind112, GodotObject.GetPtr(this), fontRid, size, &glyphPair, &kerning);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind113 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontGetKerning, 1019980169ul);

    /// <summary>
    /// <para>Returns kerning for the pair of glyphs.</para>
    /// </summary>
    public unsafe Vector2 FontGetKerning(Rid fontRid, long size, Vector2I glyphPair)
    {
        return NativeCalls.godot_icall_3_1360(MethodBind113, GodotObject.GetPtr(this), fontRid, size, &glyphPair);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind114 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontGetGlyphIndex, 1765635060ul);

    /// <summary>
    /// <para>Returns the glyph index of a <paramref name="char"/>, optionally modified by the <paramref name="variationSelector"/>. See <see cref="Godot.TextServer.FontGetCharFromGlyphIndex(Rid, long, long)"/>.</para>
    /// </summary>
    public long FontGetGlyphIndex(Rid fontRid, long size, long @char, long variationSelector)
    {
        return NativeCalls.godot_icall_4_1361(MethodBind114, GodotObject.GetPtr(this), fontRid, size, @char, variationSelector);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind115 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontGetCharFromGlyphIndex, 2156738276ul);

    /// <summary>
    /// <para>Returns character code associated with <paramref name="glyphIndex"/>, or <c>0</c> if <paramref name="glyphIndex"/> is invalid. See <see cref="Godot.TextServer.FontGetGlyphIndex(Rid, long, long, long)"/>.</para>
    /// </summary>
    public long FontGetCharFromGlyphIndex(Rid fontRid, long size, long glyphIndex)
    {
        return NativeCalls.godot_icall_3_1362(MethodBind115, GodotObject.GetPtr(this), fontRid, size, glyphIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind116 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontHasChar, 3120086654ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if a Unicode <paramref name="char"/> is available in the font.</para>
    /// </summary>
    public bool FontHasChar(Rid fontRid, long @char)
    {
        return NativeCalls.godot_icall_2_1363(MethodBind116, GodotObject.GetPtr(this), fontRid, @char).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind117 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontGetSupportedChars, 642473191ul);

    /// <summary>
    /// <para>Returns a string containing all the characters available in the font.</para>
    /// </summary>
    public string FontGetSupportedChars(Rid fontRid)
    {
        return NativeCalls.godot_icall_1_940(MethodBind117, GodotObject.GetPtr(this), fontRid);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind118 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontGetSupportedGlyphs, 788230395ul);

    /// <summary>
    /// <para>Returns an array containing all glyph indices in the font.</para>
    /// </summary>
    public int[] FontGetSupportedGlyphs(Rid fontRid)
    {
        return NativeCalls.godot_icall_1_1149(MethodBind118, GodotObject.GetPtr(this), fontRid);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind119 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontRenderRange, 4254580980ul);

    /// <summary>
    /// <para>Renders the range of characters to the font cache texture.</para>
    /// </summary>
    public unsafe void FontRenderRange(Rid fontRid, Vector2I size, long start, long end)
    {
        NativeCalls.godot_icall_4_1354(MethodBind119, GodotObject.GetPtr(this), fontRid, &size, start, end);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind120 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontRenderGlyph, 3810512262ul);

    /// <summary>
    /// <para>Renders specified glyph to the font cache texture.</para>
    /// </summary>
    public unsafe void FontRenderGlyph(Rid fontRid, Vector2I size, long index)
    {
        NativeCalls.godot_icall_3_1341(MethodBind120, GodotObject.GetPtr(this), fontRid, &size, index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind121 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontDrawGlyph, 3103234926ul);

    /// <summary>
    /// <para>Draws single glyph into a canvas item at the position, using <paramref name="fontRid"/> at the size <paramref name="size"/>. If <paramref name="oversampling"/> is greater than zero, it is used as font oversampling factor, otherwise viewport oversampling settings are used.</para>
    /// <para><b>Note:</b> Glyph index is specific to the font, use glyphs indices returned by <see cref="Godot.TextServer.ShapedTextGetGlyphs(Rid)"/> or <see cref="Godot.TextServer.FontGetGlyphIndex(Rid, long, long, long)"/>.</para>
    /// <para><b>Note:</b> If there are pending glyphs to render, calling this function might trigger the texture cache update.</para>
    /// </summary>
    /// <param name="color">If the parameter is null, then the default value is <c>new Color(1.0f, 1.0f, 1.0f, 1.0f)</c>.</param>
    public unsafe void FontDrawGlyph(Rid fontRid, Rid canvas, long size, Vector2 pos, long index, Nullable<Color> color = null, float oversampling = 0.0f)
    {
        Color colorOrDefVal = color.HasValue ? color.Value : new Color(1.0f, 1.0f, 1.0f, 1.0f);
        NativeCalls.godot_icall_7_1364(MethodBind121, GodotObject.GetPtr(this), fontRid, canvas, size, &pos, index, &colorOrDefVal, oversampling);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind122 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontDrawGlyphOutline, 1976041553ul);

    /// <summary>
    /// <para>Draws single glyph outline of size <paramref name="outlineSize"/> into a canvas item at the position, using <paramref name="fontRid"/> at the size <paramref name="size"/>. If <paramref name="oversampling"/> is greater than zero, it is used as font oversampling factor, otherwise viewport oversampling settings are used.</para>
    /// <para><b>Note:</b> Glyph index is specific to the font, use glyphs indices returned by <see cref="Godot.TextServer.ShapedTextGetGlyphs(Rid)"/> or <see cref="Godot.TextServer.FontGetGlyphIndex(Rid, long, long, long)"/>.</para>
    /// <para><b>Note:</b> If there are pending glyphs to render, calling this function might trigger the texture cache update.</para>
    /// </summary>
    /// <param name="color">If the parameter is null, then the default value is <c>new Color(1.0f, 1.0f, 1.0f, 1.0f)</c>.</param>
    public unsafe void FontDrawGlyphOutline(Rid fontRid, Rid canvas, long size, long outlineSize, Vector2 pos, long index, Nullable<Color> color = null, float oversampling = 0.0f)
    {
        Color colorOrDefVal = color.HasValue ? color.Value : new Color(1.0f, 1.0f, 1.0f, 1.0f);
        NativeCalls.godot_icall_8_1365(MethodBind122, GodotObject.GetPtr(this), fontRid, canvas, size, outlineSize, &pos, index, &colorOrDefVal, oversampling);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind123 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontIsLanguageSupported, 3199320846ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the font supports the given language (as a <a href="https://en.wikipedia.org/wiki/ISO_639-1">ISO 639</a> code).</para>
    /// </summary>
    public bool FontIsLanguageSupported(Rid fontRid, string language)
    {
        return NativeCalls.godot_icall_2_1366(MethodBind123, GodotObject.GetPtr(this), fontRid, language).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind124 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontSetLanguageSupportOverride, 2313957094ul);

    /// <summary>
    /// <para>Adds override for <see cref="Godot.TextServer.FontIsLanguageSupported(Rid, string)"/>.</para>
    /// </summary>
    public void FontSetLanguageSupportOverride(Rid fontRid, string language, bool supported)
    {
        NativeCalls.godot_icall_3_1367(MethodBind124, GodotObject.GetPtr(this), fontRid, language, supported.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind125 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontGetLanguageSupportOverride, 2829184646ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if support override is enabled for the <paramref name="language"/>.</para>
    /// </summary>
    public bool FontGetLanguageSupportOverride(Rid fontRid, string language)
    {
        return NativeCalls.godot_icall_2_1366(MethodBind125, GodotObject.GetPtr(this), fontRid, language).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind126 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontRemoveLanguageSupportOverride, 2726140452ul);

    /// <summary>
    /// <para>Remove language support override.</para>
    /// </summary>
    public void FontRemoveLanguageSupportOverride(Rid fontRid, string language)
    {
        NativeCalls.godot_icall_2_427(MethodBind126, GodotObject.GetPtr(this), fontRid, language);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind127 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontGetLanguageSupportOverrides, 2801473409ul);

    /// <summary>
    /// <para>Returns list of language support overrides.</para>
    /// </summary>
    public string[] FontGetLanguageSupportOverrides(Rid fontRid)
    {
        return NativeCalls.godot_icall_1_939(MethodBind127, GodotObject.GetPtr(this), fontRid);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind128 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontIsScriptSupported, 3199320846ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the font supports the given script (as a <a href="https://en.wikipedia.org/wiki/ISO_15924">ISO 15924</a> code).</para>
    /// </summary>
    public bool FontIsScriptSupported(Rid fontRid, string script)
    {
        return NativeCalls.godot_icall_2_1366(MethodBind128, GodotObject.GetPtr(this), fontRid, script).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind129 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontSetScriptSupportOverride, 2313957094ul);

    /// <summary>
    /// <para>Adds override for <see cref="Godot.TextServer.FontIsScriptSupported(Rid, string)"/>.</para>
    /// </summary>
    public void FontSetScriptSupportOverride(Rid fontRid, string script, bool supported)
    {
        NativeCalls.godot_icall_3_1367(MethodBind129, GodotObject.GetPtr(this), fontRid, script, supported.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind130 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontGetScriptSupportOverride, 2829184646ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if support override is enabled for the <paramref name="script"/>.</para>
    /// </summary>
    public bool FontGetScriptSupportOverride(Rid fontRid, string script)
    {
        return NativeCalls.godot_icall_2_1366(MethodBind130, GodotObject.GetPtr(this), fontRid, script).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind131 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontRemoveScriptSupportOverride, 2726140452ul);

    /// <summary>
    /// <para>Removes script support override.</para>
    /// </summary>
    public void FontRemoveScriptSupportOverride(Rid fontRid, string script)
    {
        NativeCalls.godot_icall_2_427(MethodBind131, GodotObject.GetPtr(this), fontRid, script);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind132 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontGetScriptSupportOverrides, 2801473409ul);

    /// <summary>
    /// <para>Returns list of script support overrides.</para>
    /// </summary>
    public string[] FontGetScriptSupportOverrides(Rid fontRid)
    {
        return NativeCalls.godot_icall_1_939(MethodBind132, GodotObject.GetPtr(this), fontRid);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind133 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontSetOpentypeFeatureOverrides, 1217542888ul);

    /// <summary>
    /// <para>Sets font OpenType feature set override.</para>
    /// </summary>
    public void FontSetOpentypeFeatureOverrides(Rid fontRid, Godot.Collections.Dictionary overrides)
    {
        NativeCalls.godot_icall_2_1131(MethodBind133, GodotObject.GetPtr(this), fontRid, (godot_dictionary)(overrides ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind134 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontGetOpentypeFeatureOverrides, 1882737106ul);

    /// <summary>
    /// <para>Returns font OpenType feature set override.</para>
    /// </summary>
    public Godot.Collections.Dictionary FontGetOpentypeFeatureOverrides(Rid fontRid)
    {
        return NativeCalls.godot_icall_1_1335(MethodBind134, GodotObject.GetPtr(this), fontRid);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind135 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontSupportedFeatureList, 1882737106ul);

    /// <summary>
    /// <para>Returns the dictionary of the supported OpenType features.</para>
    /// </summary>
    public Godot.Collections.Dictionary FontSupportedFeatureList(Rid fontRid)
    {
        return NativeCalls.godot_icall_1_1335(MethodBind135, GodotObject.GetPtr(this), fontRid);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind136 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontSupportedVariationList, 1882737106ul);

    /// <summary>
    /// <para>Returns the dictionary of the supported OpenType variation coordinates.</para>
    /// </summary>
    public Godot.Collections.Dictionary FontSupportedVariationList(Rid fontRid)
    {
        return NativeCalls.godot_icall_1_1335(MethodBind136, GodotObject.GetPtr(this), fontRid);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind137 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontGetGlobalOversampling, 1740695150ul);

    /// <summary>
    /// <para>This method does nothing and always returns <c>1.0</c>.</para>
    /// </summary>
    [Obsolete("Use 'Viewport' oversampling, or the 'oversampling' argument of the 'draw_*' methods instead.")]
    public double FontGetGlobalOversampling()
    {
        return NativeCalls.godot_icall_0_144(MethodBind137, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind138 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontSetGlobalOversampling, 373806689ul);

    /// <summary>
    /// <para>This method does nothing.</para>
    /// </summary>
    [Obsolete("Use 'Viewport' oversampling, or the 'oversampling' argument of the 'draw_*' methods instead.")]
    public void FontSetGlobalOversampling(double oversampling)
    {
        NativeCalls.godot_icall_1_127(MethodBind138, GodotObject.GetPtr(this), oversampling);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind139 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetHexCodeBoxSize, 3016396712ul);

    /// <summary>
    /// <para>Returns size of the replacement character (box with character hexadecimal code that is drawn in place of invalid characters).</para>
    /// </summary>
    public Vector2 GetHexCodeBoxSize(long size, long index)
    {
        return NativeCalls.godot_icall_2_1368(MethodBind139, GodotObject.GetPtr(this), size, index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind140 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DrawHexCodeBox, 1602046441ul);

    /// <summary>
    /// <para>Draws box displaying character hexadecimal code. Used for replacing missing characters.</para>
    /// </summary>
    public unsafe void DrawHexCodeBox(Rid canvas, long size, Vector2 pos, long index, Color color)
    {
        NativeCalls.godot_icall_5_1369(MethodBind140, GodotObject.GetPtr(this), canvas, size, &pos, index, &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind141 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CreateShapedText, 1231398698ul);

    /// <summary>
    /// <para>Creates a new buffer for complex text layout, with the given <paramref name="direction"/> and <paramref name="orientation"/>. To free the resulting buffer, use <see cref="Godot.TextServer.FreeRid(Rid)"/> method.</para>
    /// <para><b>Note:</b> Direction is ignored if server does not support <see cref="Godot.TextServer.Feature.BidiLayout"/> feature (supported by <see cref="Godot.TextServerAdvanced"/>).</para>
    /// <para><b>Note:</b> Orientation is ignored if server does not support <see cref="Godot.TextServer.Feature.VerticalLayout"/> feature (supported by <see cref="Godot.TextServerAdvanced"/>).</para>
    /// </summary>
    public Rid CreateShapedText(TextServer.Direction direction = (TextServer.Direction)(0), TextServer.Orientation orientation = (TextServer.Orientation)(0))
    {
        return NativeCalls.godot_icall_2_418(MethodBind141, GodotObject.GetPtr(this), (int)direction, (int)orientation);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind142 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapedTextClear, 2722037293ul);

    /// <summary>
    /// <para>Clears text buffer (removes text and inline objects).</para>
    /// </summary>
    public void ShapedTextClear(Rid rid)
    {
        NativeCalls.godot_icall_1_286(MethodBind142, GodotObject.GetPtr(this), rid);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind143 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapedTextDuplicate, 41030802ul);

    /// <summary>
    /// <para>Duplicates shaped text buffer.</para>
    /// </summary>
    public Rid ShapedTextDuplicate(Rid rid)
    {
        return NativeCalls.godot_icall_1_855(MethodBind143, GodotObject.GetPtr(this), rid);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind144 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapedTextSetDirection, 1551430183ul);

    /// <summary>
    /// <para>Sets desired text direction. If set to <see cref="Godot.TextServer.Direction.Auto"/>, direction will be detected based on the buffer contents and current locale.</para>
    /// <para><b>Note:</b> Direction is ignored if server does not support <see cref="Godot.TextServer.Feature.BidiLayout"/> feature (supported by <see cref="Godot.TextServerAdvanced"/>).</para>
    /// </summary>
    public void ShapedTextSetDirection(Rid shaped, TextServer.Direction direction = (TextServer.Direction)(0))
    {
        NativeCalls.godot_icall_2_426(MethodBind144, GodotObject.GetPtr(this), shaped, (int)direction);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind145 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapedTextGetDirection, 3065904362ul);

    /// <summary>
    /// <para>Returns direction of the text.</para>
    /// </summary>
    public TextServer.Direction ShapedTextGetDirection(Rid shaped)
    {
        return (TextServer.Direction)NativeCalls.godot_icall_1_835(MethodBind145, GodotObject.GetPtr(this), shaped);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind146 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapedTextGetInferredDirection, 3065904362ul);

    /// <summary>
    /// <para>Returns direction of the text, inferred by the BiDi algorithm.</para>
    /// </summary>
    public TextServer.Direction ShapedTextGetInferredDirection(Rid shaped)
    {
        return (TextServer.Direction)NativeCalls.godot_icall_1_835(MethodBind146, GodotObject.GetPtr(this), shaped);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind147 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapedTextSetBidiOverride, 684822712ul);

    /// <summary>
    /// <para>Overrides BiDi for the structured text.</para>
    /// <para>Override ranges should cover full source text without overlaps. BiDi algorithm will be used on each range separately.</para>
    /// </summary>
    public void ShapedTextSetBidiOverride(Rid shaped, Godot.Collections.Array @override)
    {
        NativeCalls.godot_icall_2_1122(MethodBind147, GodotObject.GetPtr(this), shaped, (godot_array)(@override ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind148 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapedTextSetCustomPunctuation, 2726140452ul);

    /// <summary>
    /// <para>Sets custom punctuation character list, used for word breaking. If set to empty string, server defaults are used.</para>
    /// </summary>
    public void ShapedTextSetCustomPunctuation(Rid shaped, string punct)
    {
        NativeCalls.godot_icall_2_427(MethodBind148, GodotObject.GetPtr(this), shaped, punct);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind149 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapedTextGetCustomPunctuation, 642473191ul);

    /// <summary>
    /// <para>Returns custom punctuation character list, used for word breaking. If set to empty string, server defaults are used.</para>
    /// </summary>
    public string ShapedTextGetCustomPunctuation(Rid shaped)
    {
        return NativeCalls.godot_icall_1_940(MethodBind149, GodotObject.GetPtr(this), shaped);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind150 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapedTextSetCustomEllipsis, 3411492887ul);

    /// <summary>
    /// <para>Sets ellipsis character used for text clipping.</para>
    /// </summary>
    public void ShapedTextSetCustomEllipsis(Rid shaped, long @char)
    {
        NativeCalls.godot_icall_2_1334(MethodBind150, GodotObject.GetPtr(this), shaped, @char);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind151 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapedTextGetCustomEllipsis, 2198884583ul);

    /// <summary>
    /// <para>Returns ellipsis character used for text clipping.</para>
    /// </summary>
    public long ShapedTextGetCustomEllipsis(Rid shaped)
    {
        return NativeCalls.godot_icall_1_1066(MethodBind151, GodotObject.GetPtr(this), shaped);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind152 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapedTextSetOrientation, 3019609126ul);

    /// <summary>
    /// <para>Sets desired text orientation.</para>
    /// <para><b>Note:</b> Orientation is ignored if server does not support <see cref="Godot.TextServer.Feature.VerticalLayout"/> feature (supported by <see cref="Godot.TextServerAdvanced"/>).</para>
    /// </summary>
    public void ShapedTextSetOrientation(Rid shaped, TextServer.Orientation orientation = (TextServer.Orientation)(0))
    {
        NativeCalls.godot_icall_2_426(MethodBind152, GodotObject.GetPtr(this), shaped, (int)orientation);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind153 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapedTextGetOrientation, 3142708106ul);

    /// <summary>
    /// <para>Returns text orientation.</para>
    /// </summary>
    public TextServer.Orientation ShapedTextGetOrientation(Rid shaped)
    {
        return (TextServer.Orientation)NativeCalls.godot_icall_1_835(MethodBind153, GodotObject.GetPtr(this), shaped);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind154 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapedTextSetPreserveInvalid, 1265174801ul);

    /// <summary>
    /// <para>If set to <see langword="true"/> text buffer will display invalid characters as hexadecimal codes, otherwise nothing is displayed.</para>
    /// </summary>
    public void ShapedTextSetPreserveInvalid(Rid shaped, bool enabled)
    {
        NativeCalls.godot_icall_2_434(MethodBind154, GodotObject.GetPtr(this), shaped, enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind155 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapedTextGetPreserveInvalid, 4155700596ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if text buffer is configured to display hexadecimal codes in place of invalid characters.</para>
    /// <para><b>Note:</b> If set to <see langword="false"/>, nothing is displayed in place of invalid characters.</para>
    /// </summary>
    public bool ShapedTextGetPreserveInvalid(Rid shaped)
    {
        return NativeCalls.godot_icall_1_421(MethodBind155, GodotObject.GetPtr(this), shaped).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind156 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapedTextSetPreserveControl, 1265174801ul);

    /// <summary>
    /// <para>If set to <see langword="true"/> text buffer will display control characters.</para>
    /// </summary>
    public void ShapedTextSetPreserveControl(Rid shaped, bool enabled)
    {
        NativeCalls.godot_icall_2_434(MethodBind156, GodotObject.GetPtr(this), shaped, enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind157 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapedTextGetPreserveControl, 4155700596ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if text buffer is configured to display control characters.</para>
    /// </summary>
    public bool ShapedTextGetPreserveControl(Rid shaped)
    {
        return NativeCalls.godot_icall_1_421(MethodBind157, GodotObject.GetPtr(this), shaped).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind158 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapedTextSetSpacing, 1307259930ul);

    /// <summary>
    /// <para>Sets extra spacing added between glyphs or lines in pixels.</para>
    /// </summary>
    public void ShapedTextSetSpacing(Rid shaped, TextServer.SpacingType spacing, long value)
    {
        NativeCalls.godot_icall_3_1336(MethodBind158, GodotObject.GetPtr(this), shaped, (int)spacing, value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind159 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapedTextGetSpacing, 1213653558ul);

    /// <summary>
    /// <para>Returns extra spacing added between glyphs or lines in pixels.</para>
    /// </summary>
    public long ShapedTextGetSpacing(Rid shaped, TextServer.SpacingType spacing)
    {
        return NativeCalls.godot_icall_2_1337(MethodBind159, GodotObject.GetPtr(this), shaped, (int)spacing);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind160 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapedTextAddString, 623473029ul);

    /// <summary>
    /// <para>Adds text span and font to draw it to the text buffer.</para>
    /// </summary>
    public bool ShapedTextAddString(Rid shaped, string text, Godot.Collections.Array<Rid> fonts, long size, Godot.Collections.Dictionary opentypeFeatures = null, string language = "", Variant meta = default)
    {
        return NativeCalls.godot_icall_7_1370(MethodBind160, GodotObject.GetPtr(this), shaped, text, (godot_array)(fonts ?? new()).NativeValue, size, (godot_dictionary)(opentypeFeatures ?? new()).NativeValue, language, meta).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind161 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapedTextAddObject, 3664424789ul);

    /// <summary>
    /// <para>Adds inline object to the text buffer, <paramref name="key"/> must be unique. In the text, object is represented as <paramref name="length"/> object replacement characters.</para>
    /// </summary>
    public unsafe bool ShapedTextAddObject(Rid shaped, Variant key, Vector2 size, InlineAlignment inlineAlign = (InlineAlignment)(5), long length = (long)(1), double baseline = 0.0)
    {
        return NativeCalls.godot_icall_6_1371(MethodBind161, GodotObject.GetPtr(this), shaped, key, &size, (int)inlineAlign, length, baseline).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind162 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapedTextResizeObject, 790361552ul);

    /// <summary>
    /// <para>Sets new size and alignment of embedded object.</para>
    /// </summary>
    public unsafe bool ShapedTextResizeObject(Rid shaped, Variant key, Vector2 size, InlineAlignment inlineAlign = (InlineAlignment)(5), double baseline = 0.0)
    {
        return NativeCalls.godot_icall_5_1372(MethodBind162, GodotObject.GetPtr(this), shaped, key, &size, (int)inlineAlign, baseline).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind163 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapedTextHasObject, 2360964694ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if an object with <paramref name="key"/> is embedded in this shaped text buffer.</para>
    /// </summary>
    public bool ShapedTextHasObject(Rid shaped, Variant key)
    {
        return NativeCalls.godot_icall_2_1373(MethodBind163, GodotObject.GetPtr(this), shaped, key).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind164 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapedGetText, 642473191ul);

    /// <summary>
    /// <para>Returns the text buffer source text, including object replacement characters.</para>
    /// </summary>
    public string ShapedGetText(Rid shaped)
    {
        return NativeCalls.godot_icall_1_940(MethodBind164, GodotObject.GetPtr(this), shaped);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind165 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapedGetSpanCount, 2198884583ul);

    /// <summary>
    /// <para>Returns number of text spans added using <see cref="Godot.TextServer.ShapedTextAddString(Rid, string, Godot.Collections.Array{Rid}, long, Godot.Collections.Dictionary, string, Variant)"/> or <see cref="Godot.TextServer.ShapedTextAddObject(Rid, Variant, Vector2, InlineAlignment, long, double)"/>.</para>
    /// </summary>
    public long ShapedGetSpanCount(Rid shaped)
    {
        return NativeCalls.godot_icall_1_1066(MethodBind165, GodotObject.GetPtr(this), shaped);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind166 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapedGetSpanMeta, 4069510997ul);

    /// <summary>
    /// <para>Returns text span metadata.</para>
    /// </summary>
    public Variant ShapedGetSpanMeta(Rid shaped, long index)
    {
        return NativeCalls.godot_icall_2_949(MethodBind166, GodotObject.GetPtr(this), shaped, index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind167 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapedGetSpanEmbeddedObject, 4069510997ul);

    /// <summary>
    /// <para>Returns text embedded object key.</para>
    /// </summary>
    public Variant ShapedGetSpanEmbeddedObject(Rid shaped, long index)
    {
        return NativeCalls.godot_icall_2_949(MethodBind167, GodotObject.GetPtr(this), shaped, index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind168 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapedGetSpanText, 1464764419ul);

    /// <summary>
    /// <para>Returns the text span source text.</para>
    /// </summary>
    public string ShapedGetSpanText(Rid shaped, long index)
    {
        return NativeCalls.godot_icall_2_1374(MethodBind168, GodotObject.GetPtr(this), shaped, index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind169 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapedGetSpanObject, 4069510997ul);

    /// <summary>
    /// <para>Returns the text span embedded object key.</para>
    /// </summary>
    public Variant ShapedGetSpanObject(Rid shaped, long index)
    {
        return NativeCalls.godot_icall_2_949(MethodBind169, GodotObject.GetPtr(this), shaped, index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind170 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapedSetSpanUpdateFont, 2022725822ul);

    /// <summary>
    /// <para>Changes text span font, font size, and OpenType features, without changing the text.</para>
    /// </summary>
    public void ShapedSetSpanUpdateFont(Rid shaped, long index, Godot.Collections.Array<Rid> fonts, long size, Godot.Collections.Dictionary opentypeFeatures = null)
    {
        NativeCalls.godot_icall_5_1375(MethodBind170, GodotObject.GetPtr(this), shaped, index, (godot_array)(fonts ?? new()).NativeValue, size, (godot_dictionary)(opentypeFeatures ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind171 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapedGetRunCount, 2198884583ul);

    /// <summary>
    /// <para>Returns the number of uniform text runs in the buffer.</para>
    /// </summary>
    public long ShapedGetRunCount(Rid shaped)
    {
        return NativeCalls.godot_icall_1_1066(MethodBind171, GodotObject.GetPtr(this), shaped);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind172 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapedGetRunText, 1464764419ul);

    /// <summary>
    /// <para>Returns the source text of the <paramref name="index"/> text run (in visual order).</para>
    /// </summary>
    public string ShapedGetRunText(Rid shaped, long index)
    {
        return NativeCalls.godot_icall_2_1374(MethodBind172, GodotObject.GetPtr(this), shaped, index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind173 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapedGetRunRange, 4069534484ul);

    /// <summary>
    /// <para>Returns the source text range of the <paramref name="index"/> text run (in visual order).</para>
    /// </summary>
    public Vector2I ShapedGetRunRange(Rid shaped, long index)
    {
        return NativeCalls.godot_icall_2_1376(MethodBind173, GodotObject.GetPtr(this), shaped, index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind174 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapedGetRunFontRid, 1066463050ul);

    /// <summary>
    /// <para>Returns the font RID of the <paramref name="index"/> text run (in visual order).</para>
    /// </summary>
    public Rid ShapedGetRunFontRid(Rid shaped, long index)
    {
        return NativeCalls.godot_icall_2_1377(MethodBind174, GodotObject.GetPtr(this), shaped, index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind175 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapedGetRunFontSize, 1120910005ul);

    /// <summary>
    /// <para>Returns the font size of the <paramref name="index"/> text run (in visual order).</para>
    /// </summary>
    public int ShapedGetRunFontSize(Rid shaped, long index)
    {
        return NativeCalls.godot_icall_2_1378(MethodBind175, GodotObject.GetPtr(this), shaped, index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind176 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapedGetRunLanguage, 1464764419ul);

    /// <summary>
    /// <para>Returns the language of the <paramref name="index"/> text run (in visual order).</para>
    /// </summary>
    public string ShapedGetRunLanguage(Rid shaped, long index)
    {
        return NativeCalls.godot_icall_2_1374(MethodBind176, GodotObject.GetPtr(this), shaped, index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind177 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapedGetRunDirection, 2413896864ul);

    /// <summary>
    /// <para>Returns the direction of the <paramref name="index"/> text run (in visual order).</para>
    /// </summary>
    public TextServer.Direction ShapedGetRunDirection(Rid shaped, long index)
    {
        return (TextServer.Direction)NativeCalls.godot_icall_2_1378(MethodBind177, GodotObject.GetPtr(this), shaped, index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind178 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapedGetRunObject, 4069510997ul);

    /// <summary>
    /// <para>Returns the embedded object of the <paramref name="index"/> text run (in visual order).</para>
    /// </summary>
    public Variant ShapedGetRunObject(Rid shaped, long index)
    {
        return NativeCalls.godot_icall_2_949(MethodBind178, GodotObject.GetPtr(this), shaped, index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind179 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapedTextSubstr, 1937682086ul);

    /// <summary>
    /// <para>Returns text buffer for the substring of the text in the <paramref name="shaped"/> text buffer (including inline objects).</para>
    /// </summary>
    public Rid ShapedTextSubstr(Rid shaped, long start, long length)
    {
        return NativeCalls.godot_icall_3_1379(MethodBind179, GodotObject.GetPtr(this), shaped, start, length);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind180 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapedTextGetParent, 3814569979ul);

    /// <summary>
    /// <para>Returns the parent buffer from which the substring originates.</para>
    /// </summary>
    public Rid ShapedTextGetParent(Rid shaped)
    {
        return NativeCalls.godot_icall_1_855(MethodBind180, GodotObject.GetPtr(this), shaped);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind181 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapedTextFitToWidth, 530670926ul);

    /// <summary>
    /// <para>Adjusts text width to fit to specified width, returns new text width.</para>
    /// </summary>
    public double ShapedTextFitToWidth(Rid shaped, double width, TextServer.JustificationFlag justificationFlags = (TextServer.JustificationFlag)(3))
    {
        return NativeCalls.godot_icall_3_1380(MethodBind181, GodotObject.GetPtr(this), shaped, width, (int)justificationFlags);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind182 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapedTextTabAlign, 1283669550ul);

    /// <summary>
    /// <para>Aligns shaped text to the given tab-stops.</para>
    /// </summary>
    public double ShapedTextTabAlign(Rid shaped, float[] tabStops)
    {
        return NativeCalls.godot_icall_2_1381(MethodBind182, GodotObject.GetPtr(this), shaped, tabStops);
    }

    /// <summary>
    /// <para>Aligns shaped text to the given tab-stops.</para>
    /// </summary>
    public double ShapedTextTabAlign(Rid shaped, ReadOnlySpan<float> tabStops)
    {
        return NativeCalls.godot_icall_2_1381(MethodBind182, GodotObject.GetPtr(this), shaped, tabStops);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind183 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapedTextShape, 3521089500ul);

    /// <summary>
    /// <para>Shapes buffer if it's not shaped. Returns <see langword="true"/> if the string is shaped successfully.</para>
    /// <para><b>Note:</b> It is not necessary to call this function manually, buffer will be shaped automatically as soon as any of its output data is requested.</para>
    /// </summary>
    public bool ShapedTextShape(Rid shaped)
    {
        return NativeCalls.godot_icall_1_421(MethodBind183, GodotObject.GetPtr(this), shaped).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind184 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapedTextIsReady, 4155700596ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if buffer is successfully shaped.</para>
    /// </summary>
    public bool ShapedTextIsReady(Rid shaped)
    {
        return NativeCalls.godot_icall_1_421(MethodBind184, GodotObject.GetPtr(this), shaped).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind185 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapedTextHasVisibleChars, 4155700596ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if text buffer contains any visible characters.</para>
    /// </summary>
    public bool ShapedTextHasVisibleChars(Rid shaped)
    {
        return NativeCalls.godot_icall_1_421(MethodBind185, GodotObject.GetPtr(this), shaped).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind186 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapedTextGetGlyphs, 2684255073ul);

    /// <summary>
    /// <para>Returns an array of glyphs in the visual order.</para>
    /// </summary>
    public Godot.Collections.Array<Godot.Collections.Dictionary> ShapedTextGetGlyphs(Rid shaped)
    {
        return new Godot.Collections.Array<Godot.Collections.Dictionary>(NativeCalls.godot_icall_1_849(MethodBind186, GodotObject.GetPtr(this), shaped));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind187 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapedTextSortLogical, 2670461153ul);

    /// <summary>
    /// <para>Returns text glyphs in the logical order.</para>
    /// </summary>
    public Godot.Collections.Array<Godot.Collections.Dictionary> ShapedTextSortLogical(Rid shaped)
    {
        return new Godot.Collections.Array<Godot.Collections.Dictionary>(NativeCalls.godot_icall_1_849(MethodBind187, GodotObject.GetPtr(this), shaped));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind188 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapedTextGetGlyphCount, 2198884583ul);

    /// <summary>
    /// <para>Returns number of glyphs in the buffer.</para>
    /// </summary>
    public long ShapedTextGetGlyphCount(Rid shaped)
    {
        return NativeCalls.godot_icall_1_1066(MethodBind188, GodotObject.GetPtr(this), shaped);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind189 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapedTextGetRange, 733700038ul);

    /// <summary>
    /// <para>Returns substring buffer character range in the parent buffer.</para>
    /// </summary>
    public Vector2I ShapedTextGetRange(Rid shaped)
    {
        return NativeCalls.godot_icall_1_1382(MethodBind189, GodotObject.GetPtr(this), shaped);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind190 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapedTextGetLineBreaksAdv, 2376991424ul);

    /// <summary>
    /// <para>Breaks text to the lines and columns. Returns character ranges for each segment.</para>
    /// </summary>
    public int[] ShapedTextGetLineBreaksAdv(Rid shaped, float[] width, long start = (long)(0), bool once = true, TextServer.LineBreakFlag breakFlags = (TextServer.LineBreakFlag)(3))
    {
        return NativeCalls.godot_icall_5_1383(MethodBind190, GodotObject.GetPtr(this), shaped, width, start, once.ToGodotBool(), (int)breakFlags);
    }

    /// <summary>
    /// <para>Breaks text to the lines and columns. Returns character ranges for each segment.</para>
    /// </summary>
    public int[] ShapedTextGetLineBreaksAdv(Rid shaped, ReadOnlySpan<float> width, long start, bool once, TextServer.LineBreakFlag breakFlags)
    {
        return NativeCalls.godot_icall_5_1383(MethodBind190, GodotObject.GetPtr(this), shaped, width, start, once.ToGodotBool(), (int)breakFlags);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind191 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapedTextGetLineBreaks, 2651359741ul);

    /// <summary>
    /// <para>Breaks text to the lines and returns character ranges for each line.</para>
    /// </summary>
    public int[] ShapedTextGetLineBreaks(Rid shaped, double width, long start = (long)(0), TextServer.LineBreakFlag breakFlags = (TextServer.LineBreakFlag)(3))
    {
        return NativeCalls.godot_icall_4_1384(MethodBind191, GodotObject.GetPtr(this), shaped, width, start, (int)breakFlags);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind192 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapedTextGetWordBreaks, 4099476853ul);

    /// <summary>
    /// <para>Breaks text into words and returns array of character ranges. Use <paramref name="graphemeFlags"/> to set what characters are used for breaking.</para>
    /// </summary>
    public int[] ShapedTextGetWordBreaks(Rid shaped, TextServer.GraphemeFlag graphemeFlags = (TextServer.GraphemeFlag)(264), TextServer.GraphemeFlag skipGraphemeFlags = (TextServer.GraphemeFlag)(4))
    {
        return NativeCalls.godot_icall_3_1385(MethodBind192, GodotObject.GetPtr(this), shaped, (int)graphemeFlags, (int)skipGraphemeFlags);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind193 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapedTextGetTrimPos, 2198884583ul);

    /// <summary>
    /// <para>Returns the position of the overrun trim.</para>
    /// </summary>
    public long ShapedTextGetTrimPos(Rid shaped)
    {
        return NativeCalls.godot_icall_1_1066(MethodBind193, GodotObject.GetPtr(this), shaped);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind194 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapedTextGetEllipsisPos, 2198884583ul);

    /// <summary>
    /// <para>Returns position of the ellipsis.</para>
    /// </summary>
    public long ShapedTextGetEllipsisPos(Rid shaped)
    {
        return NativeCalls.godot_icall_1_1066(MethodBind194, GodotObject.GetPtr(this), shaped);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind195 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapedTextGetEllipsisGlyphs, 2684255073ul);

    /// <summary>
    /// <para>Returns array of the glyphs in the ellipsis.</para>
    /// </summary>
    public Godot.Collections.Array<Godot.Collections.Dictionary> ShapedTextGetEllipsisGlyphs(Rid shaped)
    {
        return new Godot.Collections.Array<Godot.Collections.Dictionary>(NativeCalls.godot_icall_1_849(MethodBind195, GodotObject.GetPtr(this), shaped));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind196 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapedTextGetEllipsisGlyphCount, 2198884583ul);

    /// <summary>
    /// <para>Returns number of glyphs in the ellipsis.</para>
    /// </summary>
    public long ShapedTextGetEllipsisGlyphCount(Rid shaped)
    {
        return NativeCalls.godot_icall_1_1066(MethodBind196, GodotObject.GetPtr(this), shaped);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind197 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapedTextOverrunTrimToWidth, 2723146520ul);

    /// <summary>
    /// <para>Trims text if it exceeds the given width.</para>
    /// </summary>
    public void ShapedTextOverrunTrimToWidth(Rid shaped, double width = (double)(0), TextServer.TextOverrunFlag overrunTrimFlags = (TextServer.TextOverrunFlag)(0))
    {
        NativeCalls.godot_icall_3_1386(MethodBind197, GodotObject.GetPtr(this), shaped, width, (int)overrunTrimFlags);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind198 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapedTextGetObjects, 2684255073ul);

    /// <summary>
    /// <para>Returns array of inline objects.</para>
    /// </summary>
    public Godot.Collections.Array ShapedTextGetObjects(Rid shaped)
    {
        return NativeCalls.godot_icall_1_849(MethodBind198, GodotObject.GetPtr(this), shaped);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind199 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapedTextGetObjectRect, 447978354ul);

    /// <summary>
    /// <para>Returns bounding rectangle of the inline object.</para>
    /// </summary>
    public Rect2 ShapedTextGetObjectRect(Rid shaped, Variant key)
    {
        return NativeCalls.godot_icall_2_1387(MethodBind199, GodotObject.GetPtr(this), shaped, key);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind200 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapedTextGetObjectRange, 2524675647ul);

    /// <summary>
    /// <para>Returns the character range of the inline object.</para>
    /// </summary>
    public Vector2I ShapedTextGetObjectRange(Rid shaped, Variant key)
    {
        return NativeCalls.godot_icall_2_1388(MethodBind200, GodotObject.GetPtr(this), shaped, key);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind201 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapedTextGetObjectGlyph, 1260085030ul);

    /// <summary>
    /// <para>Returns the glyph index of the inline object.</para>
    /// </summary>
    public long ShapedTextGetObjectGlyph(Rid shaped, Variant key)
    {
        return NativeCalls.godot_icall_2_1389(MethodBind201, GodotObject.GetPtr(this), shaped, key);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind202 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapedTextGetSize, 2440833711ul);

    /// <summary>
    /// <para>Returns size of the text.</para>
    /// </summary>
    public Vector2 ShapedTextGetSize(Rid shaped)
    {
        return NativeCalls.godot_icall_1_812(MethodBind202, GodotObject.GetPtr(this), shaped);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind203 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapedTextGetAscent, 866169185ul);

    /// <summary>
    /// <para>Returns the text ascent (number of pixels above the baseline for horizontal layout or to the left of baseline for vertical).</para>
    /// <para><b>Note:</b> Overall ascent can be higher than font ascent, if some glyphs are displaced from the baseline.</para>
    /// </summary>
    public double ShapedTextGetAscent(Rid shaped)
    {
        return NativeCalls.godot_icall_1_1163(MethodBind203, GodotObject.GetPtr(this), shaped);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind204 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapedTextGetDescent, 866169185ul);

    /// <summary>
    /// <para>Returns the text descent (number of pixels below the baseline for horizontal layout or to the right of baseline for vertical).</para>
    /// <para><b>Note:</b> Overall descent can be higher than font descent, if some glyphs are displaced from the baseline.</para>
    /// </summary>
    public double ShapedTextGetDescent(Rid shaped)
    {
        return NativeCalls.godot_icall_1_1163(MethodBind204, GodotObject.GetPtr(this), shaped);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind205 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapedTextGetWidth, 866169185ul);

    /// <summary>
    /// <para>Returns width (for horizontal layout) or height (for vertical) of the text.</para>
    /// </summary>
    public double ShapedTextGetWidth(Rid shaped)
    {
        return NativeCalls.godot_icall_1_1163(MethodBind205, GodotObject.GetPtr(this), shaped);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind206 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapedTextGetUnderlinePosition, 866169185ul);

    /// <summary>
    /// <para>Returns pixel offset of the underline below the baseline.</para>
    /// </summary>
    public double ShapedTextGetUnderlinePosition(Rid shaped)
    {
        return NativeCalls.godot_icall_1_1163(MethodBind206, GodotObject.GetPtr(this), shaped);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind207 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapedTextGetUnderlineThickness, 866169185ul);

    /// <summary>
    /// <para>Returns thickness of the underline.</para>
    /// </summary>
    public double ShapedTextGetUnderlineThickness(Rid shaped)
    {
        return NativeCalls.godot_icall_1_1163(MethodBind207, GodotObject.GetPtr(this), shaped);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind208 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapedTextGetCarets, 1574219346ul);

    /// <summary>
    /// <para>Returns shapes of the carets corresponding to the character offset <paramref name="position"/> in the text. Returned caret shape is 1 pixel wide rectangle.</para>
    /// </summary>
    public Godot.Collections.Dictionary ShapedTextGetCarets(Rid shaped, long position)
    {
        return NativeCalls.godot_icall_2_1390(MethodBind208, GodotObject.GetPtr(this), shaped, position);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind209 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapedTextGetSelection, 3714187733ul);

    /// <summary>
    /// <para>Returns selection rectangles for the specified character range.</para>
    /// </summary>
    public Vector2[] ShapedTextGetSelection(Rid shaped, long start, long end)
    {
        return NativeCalls.godot_icall_3_1391(MethodBind209, GodotObject.GetPtr(this), shaped, start, end);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind210 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapedTextHitTestGrapheme, 3149310417ul);

    /// <summary>
    /// <para>Returns grapheme index at the specified pixel offset at the baseline, or <c>-1</c> if none is found.</para>
    /// </summary>
    public long ShapedTextHitTestGrapheme(Rid shaped, double coords)
    {
        return NativeCalls.godot_icall_2_1392(MethodBind210, GodotObject.GetPtr(this), shaped, coords);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind211 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapedTextHitTestPosition, 3149310417ul);

    /// <summary>
    /// <para>Returns caret character offset at the specified pixel offset at the baseline. This function always returns a valid position.</para>
    /// </summary>
    public long ShapedTextHitTestPosition(Rid shaped, double coords)
    {
        return NativeCalls.godot_icall_2_1392(MethodBind211, GodotObject.GetPtr(this), shaped, coords);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind212 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapedTextGetGraphemeBounds, 2546185844ul);

    /// <summary>
    /// <para>Returns composite character's bounds as offsets from the start of the line.</para>
    /// </summary>
    public Vector2 ShapedTextGetGraphemeBounds(Rid shaped, long pos)
    {
        return NativeCalls.godot_icall_2_1393(MethodBind212, GodotObject.GetPtr(this), shaped, pos);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind213 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapedTextNextGraphemePos, 1120910005ul);

    /// <summary>
    /// <para>Returns grapheme end position closest to the <paramref name="pos"/>.</para>
    /// </summary>
    public long ShapedTextNextGraphemePos(Rid shaped, long pos)
    {
        return NativeCalls.godot_icall_2_1394(MethodBind213, GodotObject.GetPtr(this), shaped, pos);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind214 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapedTextPrevGraphemePos, 1120910005ul);

    /// <summary>
    /// <para>Returns grapheme start position closest to the <paramref name="pos"/>.</para>
    /// </summary>
    public long ShapedTextPrevGraphemePos(Rid shaped, long pos)
    {
        return NativeCalls.godot_icall_2_1394(MethodBind214, GodotObject.GetPtr(this), shaped, pos);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind215 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapedTextGetCharacterBreaks, 788230395ul);

    /// <summary>
    /// <para>Returns array of the composite character boundaries.</para>
    /// </summary>
    public int[] ShapedTextGetCharacterBreaks(Rid shaped)
    {
        return NativeCalls.godot_icall_1_1149(MethodBind215, GodotObject.GetPtr(this), shaped);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind216 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapedTextNextCharacterPos, 1120910005ul);

    /// <summary>
    /// <para>Returns composite character end position closest to the <paramref name="pos"/>.</para>
    /// </summary>
    public long ShapedTextNextCharacterPos(Rid shaped, long pos)
    {
        return NativeCalls.godot_icall_2_1394(MethodBind216, GodotObject.GetPtr(this), shaped, pos);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind217 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapedTextPrevCharacterPos, 1120910005ul);

    /// <summary>
    /// <para>Returns composite character start position closest to the <paramref name="pos"/>.</para>
    /// </summary>
    public long ShapedTextPrevCharacterPos(Rid shaped, long pos)
    {
        return NativeCalls.godot_icall_2_1394(MethodBind217, GodotObject.GetPtr(this), shaped, pos);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind218 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapedTextClosestCharacterPos, 1120910005ul);

    /// <summary>
    /// <para>Returns composite character position closest to the <paramref name="pos"/>.</para>
    /// </summary>
    public long ShapedTextClosestCharacterPos(Rid shaped, long pos)
    {
        return NativeCalls.godot_icall_2_1394(MethodBind218, GodotObject.GetPtr(this), shaped, pos);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind219 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapedTextDraw, 1647687596ul);

    /// <summary>
    /// <para>Draw shaped text into a canvas item at a given position, with <paramref name="color"/>. <paramref name="pos"/> specifies the leftmost point of the baseline (for horizontal layout) or topmost point of the baseline (for vertical layout). If <paramref name="oversampling"/> is greater than zero, it is used as font oversampling factor, otherwise viewport oversampling settings are used.</para>
    /// <para><paramref name="clipL"/> and <paramref name="clipR"/> are offsets relative to <paramref name="pos"/>, going to the right in horizontal layout and downward in vertical layout. If <paramref name="clipL"/> is not negative, glyphs starting before the offset are clipped. If <paramref name="clipR"/> is not negative, glyphs ending after the offset are clipped.</para>
    /// </summary>
    /// <param name="color">If the parameter is null, then the default value is <c>new Color(1.0f, 1.0f, 1.0f, 1.0f)</c>.</param>
    public unsafe void ShapedTextDraw(Rid shaped, Rid canvas, Vector2 pos, double clipL = (double)(-1), double clipR = (double)(-1), Nullable<Color> color = null, float oversampling = 0.0f)
    {
        Color colorOrDefVal = color.HasValue ? color.Value : new Color(1.0f, 1.0f, 1.0f, 1.0f);
        NativeCalls.godot_icall_7_1395(MethodBind219, GodotObject.GetPtr(this), shaped, canvas, &pos, clipL, clipR, &colorOrDefVal, oversampling);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind220 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapedTextDrawOutline, 1217146601ul);

    /// <summary>
    /// <para>Draw the outline of the shaped text into a canvas item at a given position, with <paramref name="color"/>. <paramref name="pos"/> specifies the leftmost point of the baseline (for horizontal layout) or topmost point of the baseline (for vertical layout). If <paramref name="oversampling"/> is greater than zero, it is used as font oversampling factor, otherwise viewport oversampling settings are used.</para>
    /// <para><paramref name="clipL"/> and <paramref name="clipR"/> are offsets relative to <paramref name="pos"/>, going to the right in horizontal layout and downward in vertical layout. If <paramref name="clipL"/> is not negative, glyphs starting before the offset are clipped. If <paramref name="clipR"/> is not negative, glyphs ending after the offset are clipped.</para>
    /// </summary>
    /// <param name="color">If the parameter is null, then the default value is <c>new Color(1.0f, 1.0f, 1.0f, 1.0f)</c>.</param>
    public unsafe void ShapedTextDrawOutline(Rid shaped, Rid canvas, Vector2 pos, double clipL = (double)(-1), double clipR = (double)(-1), long outlineSize = (long)(1), Nullable<Color> color = null, float oversampling = 0.0f)
    {
        Color colorOrDefVal = color.HasValue ? color.Value : new Color(1.0f, 1.0f, 1.0f, 1.0f);
        NativeCalls.godot_icall_8_1396(MethodBind220, GodotObject.GetPtr(this), shaped, canvas, &pos, clipL, clipR, outlineSize, &colorOrDefVal, oversampling);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind221 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapedTextGetDominantDirectionInRange, 3326907668ul);

    /// <summary>
    /// <para>Returns dominant direction of in the range of text.</para>
    /// </summary>
    public TextServer.Direction ShapedTextGetDominantDirectionInRange(Rid shaped, long start, long end)
    {
        return (TextServer.Direction)NativeCalls.godot_icall_3_1397(MethodBind221, GodotObject.GetPtr(this), shaped, start, end);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind222 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FormatNumber, 2664628024ul);

    /// <summary>
    /// <para>Converts a number from Western Arabic (0..9) to the numeral system used in the given <paramref name="language"/>.</para>
    /// <para>If <paramref name="language"/> is an empty string, the active locale will be used.</para>
    /// </summary>
    [Obsolete("Use 'Godot.TranslationServer.FormatNumber(string, string)' instead.")]
    public string FormatNumber(string number, string language = "")
    {
        return NativeCalls.godot_icall_2_1398(MethodBind222, GodotObject.GetPtr(this), number, language);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind223 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ParseNumber, 2664628024ul);

    /// <summary>
    /// <para>Converts <paramref name="number"/> from the numeral system used in the given <paramref name="language"/> to Western Arabic (0..9).</para>
    /// <para>If <paramref name="language"/> is an empty string, the active locale will be used.</para>
    /// </summary>
    [Obsolete("Use 'Godot.TranslationServer.ParseNumber(string, string)' instead.")]
    public string ParseNumber(string number, string language = "")
    {
        return NativeCalls.godot_icall_2_1398(MethodBind223, GodotObject.GetPtr(this), number, language);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind224 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PercentSign, 993269549ul);

    /// <summary>
    /// <para>Returns the percent sign used in the given <paramref name="language"/>.</para>
    /// <para>If <paramref name="language"/> is an empty string, the active locale will be used.</para>
    /// </summary>
    [Obsolete("Use 'Godot.TranslationServer.GetPercentSign(string)' instead.")]
    public string PercentSign(string language = "")
    {
        return NativeCalls.godot_icall_1_304(MethodBind224, GodotObject.GetPtr(this), language);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind225 = ClassDB_get_method_with_compatibility(NativeName, MethodName.StringGetWordBreaks, 581857818ul);

    /// <summary>
    /// <para>Returns an array of the word break boundaries. Elements in the returned array are the offsets of the start and end of words. Therefore the length of the array is always even.</para>
    /// <para>When <paramref name="charsPerLine"/> is greater than zero, line break boundaries are returned instead.</para>
    /// <para><code>
    /// var ts = TextServerManager.get_primary_interface()
    /// # Corresponds to the substrings "The", "Godot", "Engine", and "4".
    /// print(ts.string_get_word_breaks("The Godot Engine, 4")) # Prints [0, 3, 4, 9, 10, 16, 18, 19]
    /// # Corresponds to the substrings "The", "Godot", "Engin", and "e, 4".
    /// print(ts.string_get_word_breaks("The Godot Engine, 4", "en", 5)) # Prints [0, 3, 4, 9, 10, 15, 15, 19]
    /// # Corresponds to the substrings "The Godot" and "Engine, 4".
    /// print(ts.string_get_word_breaks("The Godot Engine, 4", "en", 10)) # Prints [0, 9, 10, 19]
    /// </code></para>
    /// </summary>
    public int[] StringGetWordBreaks(string @string, string language = "", long charsPerLine = (long)(0))
    {
        return NativeCalls.godot_icall_3_1399(MethodBind225, GodotObject.GetPtr(this), @string, language, charsPerLine);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind226 = ClassDB_get_method_with_compatibility(NativeName, MethodName.StringGetCharacterBreaks, 2333794773ul);

    /// <summary>
    /// <para>Returns array of the composite character boundaries.</para>
    /// <para><code>
    /// var ts = TextServerManager.get_primary_interface()
    /// print(ts.string_get_character_breaks("Test ❤️‍🔥 Test")) # Prints [1, 2, 3, 4, 5, 9, 10, 11, 12, 13, 14]
    /// </code></para>
    /// </summary>
    public int[] StringGetCharacterBreaks(string @string, string language = "")
    {
        return NativeCalls.godot_icall_2_1400(MethodBind226, GodotObject.GetPtr(this), @string, language);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind227 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsConfusable, 1433197768ul);

    /// <summary>
    /// <para>Returns index of the first string in <paramref name="dict"/> which is visually confusable with the <paramref name="string"/>, or <c>-1</c> if none is found.</para>
    /// <para><b>Note:</b> This method doesn't detect invisible characters, for spoof detection use it in combination with <see cref="Godot.TextServer.SpoofCheck(string)"/>.</para>
    /// <para><b>Note:</b> Always returns <c>-1</c> if the server does not support the <see cref="Godot.TextServer.Feature.UnicodeSecurity"/> feature.</para>
    /// </summary>
    public long IsConfusable(string @string, string[] dict)
    {
        return NativeCalls.godot_icall_2_1401(MethodBind227, GodotObject.GetPtr(this), @string, dict);
    }

    /// <summary>
    /// <para>Returns index of the first string in <paramref name="dict"/> which is visually confusable with the <paramref name="string"/>, or <c>-1</c> if none is found.</para>
    /// <para><b>Note:</b> This method doesn't detect invisible characters, for spoof detection use it in combination with <see cref="Godot.TextServer.SpoofCheck(string)"/>.</para>
    /// <para><b>Note:</b> Always returns <c>-1</c> if the server does not support the <see cref="Godot.TextServer.Feature.UnicodeSecurity"/> feature.</para>
    /// </summary>
    public long IsConfusable(string @string, ReadOnlySpan<string> dict)
    {
        return NativeCalls.godot_icall_2_1401(MethodBind227, GodotObject.GetPtr(this), @string, dict);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind228 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SpoofCheck, 3927539163ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if <paramref name="string"/> is likely to be an attempt at confusing the reader.</para>
    /// <para><b>Note:</b> Always returns <see langword="false"/> if the server does not support the <see cref="Godot.TextServer.Feature.UnicodeSecurity"/> feature.</para>
    /// </summary>
    public bool SpoofCheck(string @string)
    {
        return NativeCalls.godot_icall_1_131(MethodBind228, GodotObject.GetPtr(this), @string).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind229 = ClassDB_get_method_with_compatibility(NativeName, MethodName.StripDiacritics, 3135753539ul);

    /// <summary>
    /// <para>Strips diacritics from the string.</para>
    /// <para><b>Note:</b> The result may be longer or shorter than the original.</para>
    /// </summary>
    public string StripDiacritics(string @string)
    {
        return NativeCalls.godot_icall_1_304(MethodBind229, GodotObject.GetPtr(this), @string);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind230 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsValidIdentifier, 3927539163ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if <paramref name="string"/> is a valid identifier.</para>
    /// <para>If the text server supports the <see cref="Godot.TextServer.Feature.UnicodeIdentifiers"/> feature, a valid identifier must:</para>
    /// <para>- Conform to normalization form C.</para>
    /// <para>- Begin with a Unicode character of class XID_Start or <c>"_"</c>.</para>
    /// <para>- May contain Unicode characters of class XID_Continue in the other positions.</para>
    /// <para>- Use UAX #31 recommended scripts only (mixed scripts are allowed).</para>
    /// <para>If the <see cref="Godot.TextServer.Feature.UnicodeIdentifiers"/> feature is not supported, a valid identifier must:</para>
    /// <para>- Begin with a Unicode character of class XID_Start or <c>"_"</c>.</para>
    /// <para>- May contain Unicode characters of class XID_Continue in the other positions.</para>
    /// </summary>
    public bool IsValidIdentifier(string @string)
    {
        return NativeCalls.godot_icall_1_131(MethodBind230, GodotObject.GetPtr(this), @string).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind231 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsValidLetter, 1116898809ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the given code point is a valid letter, i.e. it belongs to the Unicode category "L".</para>
    /// </summary>
    public bool IsValidLetter(ulong unicode)
    {
        return NativeCalls.godot_icall_1_567(MethodBind231, GodotObject.GetPtr(this), unicode).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind232 = ClassDB_get_method_with_compatibility(NativeName, MethodName.StringToUpper, 2664628024ul);

    /// <summary>
    /// <para>Returns the string converted to <c>UPPERCASE</c>.</para>
    /// <para><b>Note:</b> Casing is locale dependent and context sensitive if server support <see cref="Godot.TextServer.Feature.ContextSensitiveCaseConversion"/> feature (supported by <see cref="Godot.TextServerAdvanced"/>).</para>
    /// <para><b>Note:</b> The result may be longer or shorter than the original.</para>
    /// </summary>
    public string StringToUpper(string @string, string language = "")
    {
        return NativeCalls.godot_icall_2_1398(MethodBind232, GodotObject.GetPtr(this), @string, language);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind233 = ClassDB_get_method_with_compatibility(NativeName, MethodName.StringToLower, 2664628024ul);

    /// <summary>
    /// <para>Returns the string converted to <c>lowercase</c>.</para>
    /// <para><b>Note:</b> Casing is locale dependent and context sensitive if server support <see cref="Godot.TextServer.Feature.ContextSensitiveCaseConversion"/> feature (supported by <see cref="Godot.TextServerAdvanced"/>).</para>
    /// <para><b>Note:</b> The result may be longer or shorter than the original.</para>
    /// </summary>
    public string StringToLower(string @string, string language = "")
    {
        return NativeCalls.godot_icall_2_1398(MethodBind233, GodotObject.GetPtr(this), @string, language);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind234 = ClassDB_get_method_with_compatibility(NativeName, MethodName.StringToTitle, 2664628024ul);

    /// <summary>
    /// <para>Returns the string converted to <c>Title Case</c>.</para>
    /// <para><b>Note:</b> Casing is locale dependent and context sensitive if server support <see cref="Godot.TextServer.Feature.ContextSensitiveCaseConversion"/> feature (supported by <see cref="Godot.TextServerAdvanced"/>).</para>
    /// <para><b>Note:</b> The result may be longer or shorter than the original.</para>
    /// </summary>
    public string StringToTitle(string @string, string language = "")
    {
        return NativeCalls.godot_icall_2_1398(MethodBind234, GodotObject.GetPtr(this), @string, language);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind235 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ParseStructuredText, 3310685015ul);

    /// <summary>
    /// <para>Default implementation of the BiDi algorithm override function.</para>
    /// </summary>
    public Godot.Collections.Array<Vector3I> ParseStructuredText(TextServer.StructuredTextParser parserType, Godot.Collections.Array args, string text)
    {
        return new Godot.Collections.Array<Vector3I>(NativeCalls.godot_icall_3_1402(MethodBind235, GodotObject.GetPtr(this), (int)parserType, (godot_array)(args ?? new()).NativeValue, text));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind236 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapedTextGetWordBreaks, 185957063ul);

    /// <summary>
    /// <para>Breaks text into words and returns array of character ranges. Use <paramref name="graphemeFlags"/> to set what characters are used for breaking.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int[] ShapedTextGetWordBreaks(Rid shaped, TextServer.GraphemeFlag graphemeFlags)
    {
        return NativeCalls.godot_icall_2_1403(MethodBind236, GodotObject.GetPtr(this), shaped, (int)graphemeFlags);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind237 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapedTextDrawOutline, 2559184194ul);

    /// <summary>
    /// <para>Draw the outline of the shaped text into a canvas item at a given position, with <paramref name="color"/>. <paramref name="pos"/> specifies the leftmost point of the baseline (for horizontal layout) or topmost point of the baseline (for vertical layout). If <paramref name="oversampling"/> is greater than zero, it is used as font oversampling factor, otherwise viewport oversampling settings are used.</para>
    /// <para><paramref name="clipL"/> and <paramref name="clipR"/> are offsets relative to <paramref name="pos"/>, going to the right in horizontal layout and downward in vertical layout. If <paramref name="clipL"/> is not negative, glyphs starting before the offset are clipped. If <paramref name="clipR"/> is not negative, glyphs ending after the offset are clipped.</para>
    /// </summary>
    /// <param name="color">If the parameter is null, then the default value is <c>new Color(1.0f, 1.0f, 1.0f, 1.0f)</c>.</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void ShapedTextDrawOutline(Rid shaped, Rid canvas, Vector2 pos, double clipL, double clipR, long outlineSize, Nullable<Color> color)
    {
        Color colorOrDefVal = color.HasValue ? color.Value : new Color(1.0f, 1.0f, 1.0f, 1.0f);
        NativeCalls.godot_icall_7_1404(MethodBind237, GodotObject.GetPtr(this), shaped, canvas, &pos, clipL, clipR, outlineSize, &colorOrDefVal);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind238 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapedTextDraw, 880389142ul);

    /// <summary>
    /// <para>Draw shaped text into a canvas item at a given position, with <paramref name="color"/>. <paramref name="pos"/> specifies the leftmost point of the baseline (for horizontal layout) or topmost point of the baseline (for vertical layout). If <paramref name="oversampling"/> is greater than zero, it is used as font oversampling factor, otherwise viewport oversampling settings are used.</para>
    /// <para><paramref name="clipL"/> and <paramref name="clipR"/> are offsets relative to <paramref name="pos"/>, going to the right in horizontal layout and downward in vertical layout. If <paramref name="clipL"/> is not negative, glyphs starting before the offset are clipped. If <paramref name="clipR"/> is not negative, glyphs ending after the offset are clipped.</para>
    /// </summary>
    /// <param name="color">If the parameter is null, then the default value is <c>new Color(1.0f, 1.0f, 1.0f, 1.0f)</c>.</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void ShapedTextDraw(Rid shaped, Rid canvas, Vector2 pos, double clipL, double clipR, Nullable<Color> color)
    {
        Color colorOrDefVal = color.HasValue ? color.Value : new Color(1.0f, 1.0f, 1.0f, 1.0f);
        NativeCalls.godot_icall_6_1405(MethodBind238, GodotObject.GetPtr(this), shaped, canvas, &pos, clipL, clipR, &colorOrDefVal);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind239 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontDrawGlyphOutline, 2626165733ul);

    /// <summary>
    /// <para>Draws single glyph outline of size <paramref name="outlineSize"/> into a canvas item at the position, using <paramref name="fontRid"/> at the size <paramref name="size"/>. If <paramref name="oversampling"/> is greater than zero, it is used as font oversampling factor, otherwise viewport oversampling settings are used.</para>
    /// <para><b>Note:</b> Glyph index is specific to the font, use glyphs indices returned by <see cref="Godot.TextServer.ShapedTextGetGlyphs(Rid)"/> or <see cref="Godot.TextServer.FontGetGlyphIndex(Rid, long, long, long)"/>.</para>
    /// <para><b>Note:</b> If there are pending glyphs to render, calling this function might trigger the texture cache update.</para>
    /// </summary>
    /// <param name="color">If the parameter is null, then the default value is <c>new Color(1.0f, 1.0f, 1.0f, 1.0f)</c>.</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void FontDrawGlyphOutline(Rid fontRid, Rid canvas, long size, long outlineSize, Vector2 pos, long index, Nullable<Color> color)
    {
        Color colorOrDefVal = color.HasValue ? color.Value : new Color(1.0f, 1.0f, 1.0f, 1.0f);
        NativeCalls.godot_icall_7_1406(MethodBind239, GodotObject.GetPtr(this), fontRid, canvas, size, outlineSize, &pos, index, &colorOrDefVal);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind240 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FontDrawGlyph, 1339057948ul);

    /// <summary>
    /// <para>Draws single glyph into a canvas item at the position, using <paramref name="fontRid"/> at the size <paramref name="size"/>. If <paramref name="oversampling"/> is greater than zero, it is used as font oversampling factor, otherwise viewport oversampling settings are used.</para>
    /// <para><b>Note:</b> Glyph index is specific to the font, use glyphs indices returned by <see cref="Godot.TextServer.ShapedTextGetGlyphs(Rid)"/> or <see cref="Godot.TextServer.FontGetGlyphIndex(Rid, long, long, long)"/>.</para>
    /// <para><b>Note:</b> If there are pending glyphs to render, calling this function might trigger the texture cache update.</para>
    /// </summary>
    /// <param name="color">If the parameter is null, then the default value is <c>new Color(1.0f, 1.0f, 1.0f, 1.0f)</c>.</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void FontDrawGlyph(Rid fontRid, Rid canvas, long size, Vector2 pos, long index, Nullable<Color> color)
    {
        Color colorOrDefVal = color.HasValue ? color.Value : new Color(1.0f, 1.0f, 1.0f, 1.0f);
        NativeCalls.godot_icall_6_1407(MethodBind240, GodotObject.GetPtr(this), fontRid, canvas, size, &pos, index, &colorOrDefVal);
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
    public new class PropertyName : RefCounted.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : RefCounted.MethodName
    {
        /// <summary>
        /// Cached name for the 'has_feature' method.
        /// </summary>
        public static readonly StringName HasFeature = "has_feature";
        /// <summary>
        /// Cached name for the 'get_name' method.
        /// </summary>
        public static readonly StringName GetName = "get_name";
        /// <summary>
        /// Cached name for the 'get_features' method.
        /// </summary>
        public static readonly StringName GetFeatures = "get_features";
        /// <summary>
        /// Cached name for the 'load_support_data' method.
        /// </summary>
        public static readonly StringName LoadSupportData = "load_support_data";
        /// <summary>
        /// Cached name for the 'get_support_data_filename' method.
        /// </summary>
        public static readonly StringName GetSupportDataFileName = "get_support_data_filename";
        /// <summary>
        /// Cached name for the 'get_support_data_info' method.
        /// </summary>
        public static readonly StringName GetSupportDataInfo = "get_support_data_info";
        /// <summary>
        /// Cached name for the 'save_support_data' method.
        /// </summary>
        public static readonly StringName SaveSupportData = "save_support_data";
        /// <summary>
        /// Cached name for the 'get_support_data' method.
        /// </summary>
        public static readonly StringName GetSupportData = "get_support_data";
        /// <summary>
        /// Cached name for the 'is_locale_using_support_data' method.
        /// </summary>
        public static readonly StringName IsLocaleUsingSupportData = "is_locale_using_support_data";
        /// <summary>
        /// Cached name for the 'is_locale_right_to_left' method.
        /// </summary>
        public static readonly StringName IsLocaleRightToLeft = "is_locale_right_to_left";
        /// <summary>
        /// Cached name for the 'name_to_tag' method.
        /// </summary>
        public static readonly StringName NameToTag = "name_to_tag";
        /// <summary>
        /// Cached name for the 'tag_to_name' method.
        /// </summary>
        public static readonly StringName TagToName = "tag_to_name";
        /// <summary>
        /// Cached name for the 'has' method.
        /// </summary>
        public static readonly StringName Has = "has";
        /// <summary>
        /// Cached name for the 'free_rid' method.
        /// </summary>
        public static readonly StringName FreeRid = "free_rid";
        /// <summary>
        /// Cached name for the 'create_font' method.
        /// </summary>
        public static readonly StringName CreateFont = "create_font";
        /// <summary>
        /// Cached name for the 'create_font_linked_variation' method.
        /// </summary>
        public static readonly StringName CreateFontLinkedVariation = "create_font_linked_variation";
        /// <summary>
        /// Cached name for the 'font_set_data' method.
        /// </summary>
        public static readonly StringName FontSetData = "font_set_data";
        /// <summary>
        /// Cached name for the 'font_set_face_index' method.
        /// </summary>
        public static readonly StringName FontSetFaceIndex = "font_set_face_index";
        /// <summary>
        /// Cached name for the 'font_get_face_index' method.
        /// </summary>
        public static readonly StringName FontGetFaceIndex = "font_get_face_index";
        /// <summary>
        /// Cached name for the 'font_get_face_count' method.
        /// </summary>
        public static readonly StringName FontGetFaceCount = "font_get_face_count";
        /// <summary>
        /// Cached name for the 'font_set_style' method.
        /// </summary>
        public static readonly StringName FontSetStyle = "font_set_style";
        /// <summary>
        /// Cached name for the 'font_get_style' method.
        /// </summary>
        public static readonly StringName FontGetStyle = "font_get_style";
        /// <summary>
        /// Cached name for the 'font_set_name' method.
        /// </summary>
        public static readonly StringName FontSetName = "font_set_name";
        /// <summary>
        /// Cached name for the 'font_get_name' method.
        /// </summary>
        public static readonly StringName FontGetName = "font_get_name";
        /// <summary>
        /// Cached name for the 'font_get_ot_name_strings' method.
        /// </summary>
        public static readonly StringName FontGetOtNameStrings = "font_get_ot_name_strings";
        /// <summary>
        /// Cached name for the 'font_set_style_name' method.
        /// </summary>
        public static readonly StringName FontSetStyleName = "font_set_style_name";
        /// <summary>
        /// Cached name for the 'font_get_style_name' method.
        /// </summary>
        public static readonly StringName FontGetStyleName = "font_get_style_name";
        /// <summary>
        /// Cached name for the 'font_set_weight' method.
        /// </summary>
        public static readonly StringName FontSetWeight = "font_set_weight";
        /// <summary>
        /// Cached name for the 'font_get_weight' method.
        /// </summary>
        public static readonly StringName FontGetWeight = "font_get_weight";
        /// <summary>
        /// Cached name for the 'font_set_stretch' method.
        /// </summary>
        public static readonly StringName FontSetStretch = "font_set_stretch";
        /// <summary>
        /// Cached name for the 'font_get_stretch' method.
        /// </summary>
        public static readonly StringName FontGetStretch = "font_get_stretch";
        /// <summary>
        /// Cached name for the 'font_set_antialiasing' method.
        /// </summary>
        public static readonly StringName FontSetAntialiasing = "font_set_antialiasing";
        /// <summary>
        /// Cached name for the 'font_get_antialiasing' method.
        /// </summary>
        public static readonly StringName FontGetAntialiasing = "font_get_antialiasing";
        /// <summary>
        /// Cached name for the 'font_set_disable_embedded_bitmaps' method.
        /// </summary>
        public static readonly StringName FontSetDisableEmbeddedBitmaps = "font_set_disable_embedded_bitmaps";
        /// <summary>
        /// Cached name for the 'font_get_disable_embedded_bitmaps' method.
        /// </summary>
        public static readonly StringName FontGetDisableEmbeddedBitmaps = "font_get_disable_embedded_bitmaps";
        /// <summary>
        /// Cached name for the 'font_set_generate_mipmaps' method.
        /// </summary>
        public static readonly StringName FontSetGenerateMipmaps = "font_set_generate_mipmaps";
        /// <summary>
        /// Cached name for the 'font_get_generate_mipmaps' method.
        /// </summary>
        public static readonly StringName FontGetGenerateMipmaps = "font_get_generate_mipmaps";
        /// <summary>
        /// Cached name for the 'font_set_multichannel_signed_distance_field' method.
        /// </summary>
        public static readonly StringName FontSetMultichannelSignedDistanceField = "font_set_multichannel_signed_distance_field";
        /// <summary>
        /// Cached name for the 'font_is_multichannel_signed_distance_field' method.
        /// </summary>
        public static readonly StringName FontIsMultichannelSignedDistanceField = "font_is_multichannel_signed_distance_field";
        /// <summary>
        /// Cached name for the 'font_set_msdf_pixel_range' method.
        /// </summary>
        public static readonly StringName FontSetMsdfPixelRange = "font_set_msdf_pixel_range";
        /// <summary>
        /// Cached name for the 'font_get_msdf_pixel_range' method.
        /// </summary>
        public static readonly StringName FontGetMsdfPixelRange = "font_get_msdf_pixel_range";
        /// <summary>
        /// Cached name for the 'font_set_msdf_size' method.
        /// </summary>
        public static readonly StringName FontSetMsdfSize = "font_set_msdf_size";
        /// <summary>
        /// Cached name for the 'font_get_msdf_size' method.
        /// </summary>
        public static readonly StringName FontGetMsdfSize = "font_get_msdf_size";
        /// <summary>
        /// Cached name for the 'font_set_fixed_size' method.
        /// </summary>
        public static readonly StringName FontSetFixedSize = "font_set_fixed_size";
        /// <summary>
        /// Cached name for the 'font_get_fixed_size' method.
        /// </summary>
        public static readonly StringName FontGetFixedSize = "font_get_fixed_size";
        /// <summary>
        /// Cached name for the 'font_set_fixed_size_scale_mode' method.
        /// </summary>
        public static readonly StringName FontSetFixedSizeScaleMode = "font_set_fixed_size_scale_mode";
        /// <summary>
        /// Cached name for the 'font_get_fixed_size_scale_mode' method.
        /// </summary>
        public static readonly StringName FontGetFixedSizeScaleMode = "font_get_fixed_size_scale_mode";
        /// <summary>
        /// Cached name for the 'font_set_allow_system_fallback' method.
        /// </summary>
        public static readonly StringName FontSetAllowSystemFallback = "font_set_allow_system_fallback";
        /// <summary>
        /// Cached name for the 'font_is_allow_system_fallback' method.
        /// </summary>
        public static readonly StringName FontIsAllowSystemFallback = "font_is_allow_system_fallback";
        /// <summary>
        /// Cached name for the 'font_clear_system_fallback_cache' method.
        /// </summary>
        public static readonly StringName FontClearSystemFallbackCache = "font_clear_system_fallback_cache";
        /// <summary>
        /// Cached name for the 'font_set_force_autohinter' method.
        /// </summary>
        public static readonly StringName FontSetForceAutohinter = "font_set_force_autohinter";
        /// <summary>
        /// Cached name for the 'font_is_force_autohinter' method.
        /// </summary>
        public static readonly StringName FontIsForceAutohinter = "font_is_force_autohinter";
        /// <summary>
        /// Cached name for the 'font_set_modulate_color_glyphs' method.
        /// </summary>
        public static readonly StringName FontSetModulateColorGlyphs = "font_set_modulate_color_glyphs";
        /// <summary>
        /// Cached name for the 'font_is_modulate_color_glyphs' method.
        /// </summary>
        public static readonly StringName FontIsModulateColorGlyphs = "font_is_modulate_color_glyphs";
        /// <summary>
        /// Cached name for the 'font_set_hinting' method.
        /// </summary>
        public static readonly StringName FontSetHinting = "font_set_hinting";
        /// <summary>
        /// Cached name for the 'font_get_hinting' method.
        /// </summary>
        public static readonly StringName FontGetHinting = "font_get_hinting";
        /// <summary>
        /// Cached name for the 'font_set_subpixel_positioning' method.
        /// </summary>
        public static readonly StringName FontSetSubpixelPositioning = "font_set_subpixel_positioning";
        /// <summary>
        /// Cached name for the 'font_get_subpixel_positioning' method.
        /// </summary>
        public static readonly StringName FontGetSubpixelPositioning = "font_get_subpixel_positioning";
        /// <summary>
        /// Cached name for the 'font_set_keep_rounding_remainders' method.
        /// </summary>
        public static readonly StringName FontSetKeepRoundingRemainders = "font_set_keep_rounding_remainders";
        /// <summary>
        /// Cached name for the 'font_get_keep_rounding_remainders' method.
        /// </summary>
        public static readonly StringName FontGetKeepRoundingRemainders = "font_get_keep_rounding_remainders";
        /// <summary>
        /// Cached name for the 'font_set_embolden' method.
        /// </summary>
        public static readonly StringName FontSetEmbolden = "font_set_embolden";
        /// <summary>
        /// Cached name for the 'font_get_embolden' method.
        /// </summary>
        public static readonly StringName FontGetEmbolden = "font_get_embolden";
        /// <summary>
        /// Cached name for the 'font_set_spacing' method.
        /// </summary>
        public static readonly StringName FontSetSpacing = "font_set_spacing";
        /// <summary>
        /// Cached name for the 'font_get_spacing' method.
        /// </summary>
        public static readonly StringName FontGetSpacing = "font_get_spacing";
        /// <summary>
        /// Cached name for the 'font_set_baseline_offset' method.
        /// </summary>
        public static readonly StringName FontSetBaselineOffset = "font_set_baseline_offset";
        /// <summary>
        /// Cached name for the 'font_get_baseline_offset' method.
        /// </summary>
        public static readonly StringName FontGetBaselineOffset = "font_get_baseline_offset";
        /// <summary>
        /// Cached name for the 'font_set_transform' method.
        /// </summary>
        public static readonly StringName FontSetTransform = "font_set_transform";
        /// <summary>
        /// Cached name for the 'font_get_transform' method.
        /// </summary>
        public static readonly StringName FontGetTransform = "font_get_transform";
        /// <summary>
        /// Cached name for the 'font_set_variation_coordinates' method.
        /// </summary>
        public static readonly StringName FontSetVariationCoordinates = "font_set_variation_coordinates";
        /// <summary>
        /// Cached name for the 'font_get_variation_coordinates' method.
        /// </summary>
        public static readonly StringName FontGetVariationCoordinates = "font_get_variation_coordinates";
        /// <summary>
        /// Cached name for the 'font_set_oversampling' method.
        /// </summary>
        public static readonly StringName FontSetOversampling = "font_set_oversampling";
        /// <summary>
        /// Cached name for the 'font_get_oversampling' method.
        /// </summary>
        public static readonly StringName FontGetOversampling = "font_get_oversampling";
        /// <summary>
        /// Cached name for the 'font_get_size_cache_list' method.
        /// </summary>
        public static readonly StringName FontGetSizeCacheList = "font_get_size_cache_list";
        /// <summary>
        /// Cached name for the 'font_clear_size_cache' method.
        /// </summary>
        public static readonly StringName FontClearSizeCache = "font_clear_size_cache";
        /// <summary>
        /// Cached name for the 'font_remove_size_cache' method.
        /// </summary>
        public static readonly StringName FontRemoveSizeCache = "font_remove_size_cache";
        /// <summary>
        /// Cached name for the 'font_get_size_cache_info' method.
        /// </summary>
        public static readonly StringName FontGetSizeCacheInfo = "font_get_size_cache_info";
        /// <summary>
        /// Cached name for the 'font_set_ascent' method.
        /// </summary>
        public static readonly StringName FontSetAscent = "font_set_ascent";
        /// <summary>
        /// Cached name for the 'font_get_ascent' method.
        /// </summary>
        public static readonly StringName FontGetAscent = "font_get_ascent";
        /// <summary>
        /// Cached name for the 'font_set_descent' method.
        /// </summary>
        public static readonly StringName FontSetDescent = "font_set_descent";
        /// <summary>
        /// Cached name for the 'font_get_descent' method.
        /// </summary>
        public static readonly StringName FontGetDescent = "font_get_descent";
        /// <summary>
        /// Cached name for the 'font_set_underline_position' method.
        /// </summary>
        public static readonly StringName FontSetUnderlinePosition = "font_set_underline_position";
        /// <summary>
        /// Cached name for the 'font_get_underline_position' method.
        /// </summary>
        public static readonly StringName FontGetUnderlinePosition = "font_get_underline_position";
        /// <summary>
        /// Cached name for the 'font_set_underline_thickness' method.
        /// </summary>
        public static readonly StringName FontSetUnderlineThickness = "font_set_underline_thickness";
        /// <summary>
        /// Cached name for the 'font_get_underline_thickness' method.
        /// </summary>
        public static readonly StringName FontGetUnderlineThickness = "font_get_underline_thickness";
        /// <summary>
        /// Cached name for the 'font_set_scale' method.
        /// </summary>
        public static readonly StringName FontSetScale = "font_set_scale";
        /// <summary>
        /// Cached name for the 'font_get_scale' method.
        /// </summary>
        public static readonly StringName FontGetScale = "font_get_scale";
        /// <summary>
        /// Cached name for the 'font_get_texture_count' method.
        /// </summary>
        public static readonly StringName FontGetTextureCount = "font_get_texture_count";
        /// <summary>
        /// Cached name for the 'font_clear_textures' method.
        /// </summary>
        public static readonly StringName FontClearTextures = "font_clear_textures";
        /// <summary>
        /// Cached name for the 'font_remove_texture' method.
        /// </summary>
        public static readonly StringName FontRemoveTexture = "font_remove_texture";
        /// <summary>
        /// Cached name for the 'font_set_texture_image' method.
        /// </summary>
        public static readonly StringName FontSetTextureImage = "font_set_texture_image";
        /// <summary>
        /// Cached name for the 'font_get_texture_image' method.
        /// </summary>
        public static readonly StringName FontGetTextureImage = "font_get_texture_image";
        /// <summary>
        /// Cached name for the 'font_set_texture_offsets' method.
        /// </summary>
        public static readonly StringName FontSetTextureOffsets = "font_set_texture_offsets";
        /// <summary>
        /// Cached name for the 'font_get_texture_offsets' method.
        /// </summary>
        public static readonly StringName FontGetTextureOffsets = "font_get_texture_offsets";
        /// <summary>
        /// Cached name for the 'font_get_glyph_list' method.
        /// </summary>
        public static readonly StringName FontGetGlyphList = "font_get_glyph_list";
        /// <summary>
        /// Cached name for the 'font_clear_glyphs' method.
        /// </summary>
        public static readonly StringName FontClearGlyphs = "font_clear_glyphs";
        /// <summary>
        /// Cached name for the 'font_remove_glyph' method.
        /// </summary>
        public static readonly StringName FontRemoveGlyph = "font_remove_glyph";
        /// <summary>
        /// Cached name for the 'font_get_glyph_advance' method.
        /// </summary>
        public static readonly StringName FontGetGlyphAdvance = "font_get_glyph_advance";
        /// <summary>
        /// Cached name for the 'font_set_glyph_advance' method.
        /// </summary>
        public static readonly StringName FontSetGlyphAdvance = "font_set_glyph_advance";
        /// <summary>
        /// Cached name for the 'font_get_glyph_offset' method.
        /// </summary>
        public static readonly StringName FontGetGlyphOffset = "font_get_glyph_offset";
        /// <summary>
        /// Cached name for the 'font_set_glyph_offset' method.
        /// </summary>
        public static readonly StringName FontSetGlyphOffset = "font_set_glyph_offset";
        /// <summary>
        /// Cached name for the 'font_get_glyph_size' method.
        /// </summary>
        public static readonly StringName FontGetGlyphSize = "font_get_glyph_size";
        /// <summary>
        /// Cached name for the 'font_set_glyph_size' method.
        /// </summary>
        public static readonly StringName FontSetGlyphSize = "font_set_glyph_size";
        /// <summary>
        /// Cached name for the 'font_get_glyph_uv_rect' method.
        /// </summary>
        public static readonly StringName FontGetGlyphUVRect = "font_get_glyph_uv_rect";
        /// <summary>
        /// Cached name for the 'font_set_glyph_uv_rect' method.
        /// </summary>
        public static readonly StringName FontSetGlyphUVRect = "font_set_glyph_uv_rect";
        /// <summary>
        /// Cached name for the 'font_get_glyph_texture_idx' method.
        /// </summary>
        public static readonly StringName FontGetGlyphTextureIdx = "font_get_glyph_texture_idx";
        /// <summary>
        /// Cached name for the 'font_set_glyph_texture_idx' method.
        /// </summary>
        public static readonly StringName FontSetGlyphTextureIdx = "font_set_glyph_texture_idx";
        /// <summary>
        /// Cached name for the 'font_get_glyph_texture_rid' method.
        /// </summary>
        public static readonly StringName FontGetGlyphTextureRid = "font_get_glyph_texture_rid";
        /// <summary>
        /// Cached name for the 'font_get_glyph_texture_size' method.
        /// </summary>
        public static readonly StringName FontGetGlyphTextureSize = "font_get_glyph_texture_size";
        /// <summary>
        /// Cached name for the 'font_get_glyph_contours' method.
        /// </summary>
        public static readonly StringName FontGetGlyphContours = "font_get_glyph_contours";
        /// <summary>
        /// Cached name for the 'font_get_kerning_list' method.
        /// </summary>
        public static readonly StringName FontGetKerningList = "font_get_kerning_list";
        /// <summary>
        /// Cached name for the 'font_clear_kerning_map' method.
        /// </summary>
        public static readonly StringName FontClearKerningMap = "font_clear_kerning_map";
        /// <summary>
        /// Cached name for the 'font_remove_kerning' method.
        /// </summary>
        public static readonly StringName FontRemoveKerning = "font_remove_kerning";
        /// <summary>
        /// Cached name for the 'font_set_kerning' method.
        /// </summary>
        public static readonly StringName FontSetKerning = "font_set_kerning";
        /// <summary>
        /// Cached name for the 'font_get_kerning' method.
        /// </summary>
        public static readonly StringName FontGetKerning = "font_get_kerning";
        /// <summary>
        /// Cached name for the 'font_get_glyph_index' method.
        /// </summary>
        public static readonly StringName FontGetGlyphIndex = "font_get_glyph_index";
        /// <summary>
        /// Cached name for the 'font_get_char_from_glyph_index' method.
        /// </summary>
        public static readonly StringName FontGetCharFromGlyphIndex = "font_get_char_from_glyph_index";
        /// <summary>
        /// Cached name for the 'font_has_char' method.
        /// </summary>
        public static readonly StringName FontHasChar = "font_has_char";
        /// <summary>
        /// Cached name for the 'font_get_supported_chars' method.
        /// </summary>
        public static readonly StringName FontGetSupportedChars = "font_get_supported_chars";
        /// <summary>
        /// Cached name for the 'font_get_supported_glyphs' method.
        /// </summary>
        public static readonly StringName FontGetSupportedGlyphs = "font_get_supported_glyphs";
        /// <summary>
        /// Cached name for the 'font_render_range' method.
        /// </summary>
        public static readonly StringName FontRenderRange = "font_render_range";
        /// <summary>
        /// Cached name for the 'font_render_glyph' method.
        /// </summary>
        public static readonly StringName FontRenderGlyph = "font_render_glyph";
        /// <summary>
        /// Cached name for the 'font_draw_glyph' method.
        /// </summary>
        public static readonly StringName FontDrawGlyph = "font_draw_glyph";
        /// <summary>
        /// Cached name for the 'font_draw_glyph_outline' method.
        /// </summary>
        public static readonly StringName FontDrawGlyphOutline = "font_draw_glyph_outline";
        /// <summary>
        /// Cached name for the 'font_is_language_supported' method.
        /// </summary>
        public static readonly StringName FontIsLanguageSupported = "font_is_language_supported";
        /// <summary>
        /// Cached name for the 'font_set_language_support_override' method.
        /// </summary>
        public static readonly StringName FontSetLanguageSupportOverride = "font_set_language_support_override";
        /// <summary>
        /// Cached name for the 'font_get_language_support_override' method.
        /// </summary>
        public static readonly StringName FontGetLanguageSupportOverride = "font_get_language_support_override";
        /// <summary>
        /// Cached name for the 'font_remove_language_support_override' method.
        /// </summary>
        public static readonly StringName FontRemoveLanguageSupportOverride = "font_remove_language_support_override";
        /// <summary>
        /// Cached name for the 'font_get_language_support_overrides' method.
        /// </summary>
        public static readonly StringName FontGetLanguageSupportOverrides = "font_get_language_support_overrides";
        /// <summary>
        /// Cached name for the 'font_is_script_supported' method.
        /// </summary>
        public static readonly StringName FontIsScriptSupported = "font_is_script_supported";
        /// <summary>
        /// Cached name for the 'font_set_script_support_override' method.
        /// </summary>
        public static readonly StringName FontSetScriptSupportOverride = "font_set_script_support_override";
        /// <summary>
        /// Cached name for the 'font_get_script_support_override' method.
        /// </summary>
        public static readonly StringName FontGetScriptSupportOverride = "font_get_script_support_override";
        /// <summary>
        /// Cached name for the 'font_remove_script_support_override' method.
        /// </summary>
        public static readonly StringName FontRemoveScriptSupportOverride = "font_remove_script_support_override";
        /// <summary>
        /// Cached name for the 'font_get_script_support_overrides' method.
        /// </summary>
        public static readonly StringName FontGetScriptSupportOverrides = "font_get_script_support_overrides";
        /// <summary>
        /// Cached name for the 'font_set_opentype_feature_overrides' method.
        /// </summary>
        public static readonly StringName FontSetOpentypeFeatureOverrides = "font_set_opentype_feature_overrides";
        /// <summary>
        /// Cached name for the 'font_get_opentype_feature_overrides' method.
        /// </summary>
        public static readonly StringName FontGetOpentypeFeatureOverrides = "font_get_opentype_feature_overrides";
        /// <summary>
        /// Cached name for the 'font_supported_feature_list' method.
        /// </summary>
        public static readonly StringName FontSupportedFeatureList = "font_supported_feature_list";
        /// <summary>
        /// Cached name for the 'font_supported_variation_list' method.
        /// </summary>
        public static readonly StringName FontSupportedVariationList = "font_supported_variation_list";
        /// <summary>
        /// Cached name for the 'font_get_global_oversampling' method.
        /// </summary>
        public static readonly StringName FontGetGlobalOversampling = "font_get_global_oversampling";
        /// <summary>
        /// Cached name for the 'font_set_global_oversampling' method.
        /// </summary>
        public static readonly StringName FontSetGlobalOversampling = "font_set_global_oversampling";
        /// <summary>
        /// Cached name for the 'get_hex_code_box_size' method.
        /// </summary>
        public static readonly StringName GetHexCodeBoxSize = "get_hex_code_box_size";
        /// <summary>
        /// Cached name for the 'draw_hex_code_box' method.
        /// </summary>
        public static readonly StringName DrawHexCodeBox = "draw_hex_code_box";
        /// <summary>
        /// Cached name for the 'create_shaped_text' method.
        /// </summary>
        public static readonly StringName CreateShapedText = "create_shaped_text";
        /// <summary>
        /// Cached name for the 'shaped_text_clear' method.
        /// </summary>
        public static readonly StringName ShapedTextClear = "shaped_text_clear";
        /// <summary>
        /// Cached name for the 'shaped_text_duplicate' method.
        /// </summary>
        public static readonly StringName ShapedTextDuplicate = "shaped_text_duplicate";
        /// <summary>
        /// Cached name for the 'shaped_text_set_direction' method.
        /// </summary>
        public static readonly StringName ShapedTextSetDirection = "shaped_text_set_direction";
        /// <summary>
        /// Cached name for the 'shaped_text_get_direction' method.
        /// </summary>
        public static readonly StringName ShapedTextGetDirection = "shaped_text_get_direction";
        /// <summary>
        /// Cached name for the 'shaped_text_get_inferred_direction' method.
        /// </summary>
        public static readonly StringName ShapedTextGetInferredDirection = "shaped_text_get_inferred_direction";
        /// <summary>
        /// Cached name for the 'shaped_text_set_bidi_override' method.
        /// </summary>
        public static readonly StringName ShapedTextSetBidiOverride = "shaped_text_set_bidi_override";
        /// <summary>
        /// Cached name for the 'shaped_text_set_custom_punctuation' method.
        /// </summary>
        public static readonly StringName ShapedTextSetCustomPunctuation = "shaped_text_set_custom_punctuation";
        /// <summary>
        /// Cached name for the 'shaped_text_get_custom_punctuation' method.
        /// </summary>
        public static readonly StringName ShapedTextGetCustomPunctuation = "shaped_text_get_custom_punctuation";
        /// <summary>
        /// Cached name for the 'shaped_text_set_custom_ellipsis' method.
        /// </summary>
        public static readonly StringName ShapedTextSetCustomEllipsis = "shaped_text_set_custom_ellipsis";
        /// <summary>
        /// Cached name for the 'shaped_text_get_custom_ellipsis' method.
        /// </summary>
        public static readonly StringName ShapedTextGetCustomEllipsis = "shaped_text_get_custom_ellipsis";
        /// <summary>
        /// Cached name for the 'shaped_text_set_orientation' method.
        /// </summary>
        public static readonly StringName ShapedTextSetOrientation = "shaped_text_set_orientation";
        /// <summary>
        /// Cached name for the 'shaped_text_get_orientation' method.
        /// </summary>
        public static readonly StringName ShapedTextGetOrientation = "shaped_text_get_orientation";
        /// <summary>
        /// Cached name for the 'shaped_text_set_preserve_invalid' method.
        /// </summary>
        public static readonly StringName ShapedTextSetPreserveInvalid = "shaped_text_set_preserve_invalid";
        /// <summary>
        /// Cached name for the 'shaped_text_get_preserve_invalid' method.
        /// </summary>
        public static readonly StringName ShapedTextGetPreserveInvalid = "shaped_text_get_preserve_invalid";
        /// <summary>
        /// Cached name for the 'shaped_text_set_preserve_control' method.
        /// </summary>
        public static readonly StringName ShapedTextSetPreserveControl = "shaped_text_set_preserve_control";
        /// <summary>
        /// Cached name for the 'shaped_text_get_preserve_control' method.
        /// </summary>
        public static readonly StringName ShapedTextGetPreserveControl = "shaped_text_get_preserve_control";
        /// <summary>
        /// Cached name for the 'shaped_text_set_spacing' method.
        /// </summary>
        public static readonly StringName ShapedTextSetSpacing = "shaped_text_set_spacing";
        /// <summary>
        /// Cached name for the 'shaped_text_get_spacing' method.
        /// </summary>
        public static readonly StringName ShapedTextGetSpacing = "shaped_text_get_spacing";
        /// <summary>
        /// Cached name for the 'shaped_text_add_string' method.
        /// </summary>
        public static readonly StringName ShapedTextAddString = "shaped_text_add_string";
        /// <summary>
        /// Cached name for the 'shaped_text_add_object' method.
        /// </summary>
        public static readonly StringName ShapedTextAddObject = "shaped_text_add_object";
        /// <summary>
        /// Cached name for the 'shaped_text_resize_object' method.
        /// </summary>
        public static readonly StringName ShapedTextResizeObject = "shaped_text_resize_object";
        /// <summary>
        /// Cached name for the 'shaped_text_has_object' method.
        /// </summary>
        public static readonly StringName ShapedTextHasObject = "shaped_text_has_object";
        /// <summary>
        /// Cached name for the 'shaped_get_text' method.
        /// </summary>
        public static readonly StringName ShapedGetText = "shaped_get_text";
        /// <summary>
        /// Cached name for the 'shaped_get_span_count' method.
        /// </summary>
        public static readonly StringName ShapedGetSpanCount = "shaped_get_span_count";
        /// <summary>
        /// Cached name for the 'shaped_get_span_meta' method.
        /// </summary>
        public static readonly StringName ShapedGetSpanMeta = "shaped_get_span_meta";
        /// <summary>
        /// Cached name for the 'shaped_get_span_embedded_object' method.
        /// </summary>
        public static readonly StringName ShapedGetSpanEmbeddedObject = "shaped_get_span_embedded_object";
        /// <summary>
        /// Cached name for the 'shaped_get_span_text' method.
        /// </summary>
        public static readonly StringName ShapedGetSpanText = "shaped_get_span_text";
        /// <summary>
        /// Cached name for the 'shaped_get_span_object' method.
        /// </summary>
        public static readonly StringName ShapedGetSpanObject = "shaped_get_span_object";
        /// <summary>
        /// Cached name for the 'shaped_set_span_update_font' method.
        /// </summary>
        public static readonly StringName ShapedSetSpanUpdateFont = "shaped_set_span_update_font";
        /// <summary>
        /// Cached name for the 'shaped_get_run_count' method.
        /// </summary>
        public static readonly StringName ShapedGetRunCount = "shaped_get_run_count";
        /// <summary>
        /// Cached name for the 'shaped_get_run_text' method.
        /// </summary>
        public static readonly StringName ShapedGetRunText = "shaped_get_run_text";
        /// <summary>
        /// Cached name for the 'shaped_get_run_range' method.
        /// </summary>
        public static readonly StringName ShapedGetRunRange = "shaped_get_run_range";
        /// <summary>
        /// Cached name for the 'shaped_get_run_font_rid' method.
        /// </summary>
        public static readonly StringName ShapedGetRunFontRid = "shaped_get_run_font_rid";
        /// <summary>
        /// Cached name for the 'shaped_get_run_font_size' method.
        /// </summary>
        public static readonly StringName ShapedGetRunFontSize = "shaped_get_run_font_size";
        /// <summary>
        /// Cached name for the 'shaped_get_run_language' method.
        /// </summary>
        public static readonly StringName ShapedGetRunLanguage = "shaped_get_run_language";
        /// <summary>
        /// Cached name for the 'shaped_get_run_direction' method.
        /// </summary>
        public static readonly StringName ShapedGetRunDirection = "shaped_get_run_direction";
        /// <summary>
        /// Cached name for the 'shaped_get_run_object' method.
        /// </summary>
        public static readonly StringName ShapedGetRunObject = "shaped_get_run_object";
        /// <summary>
        /// Cached name for the 'shaped_text_substr' method.
        /// </summary>
        public static readonly StringName ShapedTextSubstr = "shaped_text_substr";
        /// <summary>
        /// Cached name for the 'shaped_text_get_parent' method.
        /// </summary>
        public static readonly StringName ShapedTextGetParent = "shaped_text_get_parent";
        /// <summary>
        /// Cached name for the 'shaped_text_fit_to_width' method.
        /// </summary>
        public static readonly StringName ShapedTextFitToWidth = "shaped_text_fit_to_width";
        /// <summary>
        /// Cached name for the 'shaped_text_tab_align' method.
        /// </summary>
        public static readonly StringName ShapedTextTabAlign = "shaped_text_tab_align";
        /// <summary>
        /// Cached name for the 'shaped_text_shape' method.
        /// </summary>
        public static readonly StringName ShapedTextShape = "shaped_text_shape";
        /// <summary>
        /// Cached name for the 'shaped_text_is_ready' method.
        /// </summary>
        public static readonly StringName ShapedTextIsReady = "shaped_text_is_ready";
        /// <summary>
        /// Cached name for the 'shaped_text_has_visible_chars' method.
        /// </summary>
        public static readonly StringName ShapedTextHasVisibleChars = "shaped_text_has_visible_chars";
        /// <summary>
        /// Cached name for the 'shaped_text_get_glyphs' method.
        /// </summary>
        public static readonly StringName ShapedTextGetGlyphs = "shaped_text_get_glyphs";
        /// <summary>
        /// Cached name for the 'shaped_text_sort_logical' method.
        /// </summary>
        public static readonly StringName ShapedTextSortLogical = "shaped_text_sort_logical";
        /// <summary>
        /// Cached name for the 'shaped_text_get_glyph_count' method.
        /// </summary>
        public static readonly StringName ShapedTextGetGlyphCount = "shaped_text_get_glyph_count";
        /// <summary>
        /// Cached name for the 'shaped_text_get_range' method.
        /// </summary>
        public static readonly StringName ShapedTextGetRange = "shaped_text_get_range";
        /// <summary>
        /// Cached name for the 'shaped_text_get_line_breaks_adv' method.
        /// </summary>
        public static readonly StringName ShapedTextGetLineBreaksAdv = "shaped_text_get_line_breaks_adv";
        /// <summary>
        /// Cached name for the 'shaped_text_get_line_breaks' method.
        /// </summary>
        public static readonly StringName ShapedTextGetLineBreaks = "shaped_text_get_line_breaks";
        /// <summary>
        /// Cached name for the 'shaped_text_get_word_breaks' method.
        /// </summary>
        public static readonly StringName ShapedTextGetWordBreaks = "shaped_text_get_word_breaks";
        /// <summary>
        /// Cached name for the 'shaped_text_get_trim_pos' method.
        /// </summary>
        public static readonly StringName ShapedTextGetTrimPos = "shaped_text_get_trim_pos";
        /// <summary>
        /// Cached name for the 'shaped_text_get_ellipsis_pos' method.
        /// </summary>
        public static readonly StringName ShapedTextGetEllipsisPos = "shaped_text_get_ellipsis_pos";
        /// <summary>
        /// Cached name for the 'shaped_text_get_ellipsis_glyphs' method.
        /// </summary>
        public static readonly StringName ShapedTextGetEllipsisGlyphs = "shaped_text_get_ellipsis_glyphs";
        /// <summary>
        /// Cached name for the 'shaped_text_get_ellipsis_glyph_count' method.
        /// </summary>
        public static readonly StringName ShapedTextGetEllipsisGlyphCount = "shaped_text_get_ellipsis_glyph_count";
        /// <summary>
        /// Cached name for the 'shaped_text_overrun_trim_to_width' method.
        /// </summary>
        public static readonly StringName ShapedTextOverrunTrimToWidth = "shaped_text_overrun_trim_to_width";
        /// <summary>
        /// Cached name for the 'shaped_text_get_objects' method.
        /// </summary>
        public static readonly StringName ShapedTextGetObjects = "shaped_text_get_objects";
        /// <summary>
        /// Cached name for the 'shaped_text_get_object_rect' method.
        /// </summary>
        public static readonly StringName ShapedTextGetObjectRect = "shaped_text_get_object_rect";
        /// <summary>
        /// Cached name for the 'shaped_text_get_object_range' method.
        /// </summary>
        public static readonly StringName ShapedTextGetObjectRange = "shaped_text_get_object_range";
        /// <summary>
        /// Cached name for the 'shaped_text_get_object_glyph' method.
        /// </summary>
        public static readonly StringName ShapedTextGetObjectGlyph = "shaped_text_get_object_glyph";
        /// <summary>
        /// Cached name for the 'shaped_text_get_size' method.
        /// </summary>
        public static readonly StringName ShapedTextGetSize = "shaped_text_get_size";
        /// <summary>
        /// Cached name for the 'shaped_text_get_ascent' method.
        /// </summary>
        public static readonly StringName ShapedTextGetAscent = "shaped_text_get_ascent";
        /// <summary>
        /// Cached name for the 'shaped_text_get_descent' method.
        /// </summary>
        public static readonly StringName ShapedTextGetDescent = "shaped_text_get_descent";
        /// <summary>
        /// Cached name for the 'shaped_text_get_width' method.
        /// </summary>
        public static readonly StringName ShapedTextGetWidth = "shaped_text_get_width";
        /// <summary>
        /// Cached name for the 'shaped_text_get_underline_position' method.
        /// </summary>
        public static readonly StringName ShapedTextGetUnderlinePosition = "shaped_text_get_underline_position";
        /// <summary>
        /// Cached name for the 'shaped_text_get_underline_thickness' method.
        /// </summary>
        public static readonly StringName ShapedTextGetUnderlineThickness = "shaped_text_get_underline_thickness";
        /// <summary>
        /// Cached name for the 'shaped_text_get_carets' method.
        /// </summary>
        public static readonly StringName ShapedTextGetCarets = "shaped_text_get_carets";
        /// <summary>
        /// Cached name for the 'shaped_text_get_selection' method.
        /// </summary>
        public static readonly StringName ShapedTextGetSelection = "shaped_text_get_selection";
        /// <summary>
        /// Cached name for the 'shaped_text_hit_test_grapheme' method.
        /// </summary>
        public static readonly StringName ShapedTextHitTestGrapheme = "shaped_text_hit_test_grapheme";
        /// <summary>
        /// Cached name for the 'shaped_text_hit_test_position' method.
        /// </summary>
        public static readonly StringName ShapedTextHitTestPosition = "shaped_text_hit_test_position";
        /// <summary>
        /// Cached name for the 'shaped_text_get_grapheme_bounds' method.
        /// </summary>
        public static readonly StringName ShapedTextGetGraphemeBounds = "shaped_text_get_grapheme_bounds";
        /// <summary>
        /// Cached name for the 'shaped_text_next_grapheme_pos' method.
        /// </summary>
        public static readonly StringName ShapedTextNextGraphemePos = "shaped_text_next_grapheme_pos";
        /// <summary>
        /// Cached name for the 'shaped_text_prev_grapheme_pos' method.
        /// </summary>
        public static readonly StringName ShapedTextPrevGraphemePos = "shaped_text_prev_grapheme_pos";
        /// <summary>
        /// Cached name for the 'shaped_text_get_character_breaks' method.
        /// </summary>
        public static readonly StringName ShapedTextGetCharacterBreaks = "shaped_text_get_character_breaks";
        /// <summary>
        /// Cached name for the 'shaped_text_next_character_pos' method.
        /// </summary>
        public static readonly StringName ShapedTextNextCharacterPos = "shaped_text_next_character_pos";
        /// <summary>
        /// Cached name for the 'shaped_text_prev_character_pos' method.
        /// </summary>
        public static readonly StringName ShapedTextPrevCharacterPos = "shaped_text_prev_character_pos";
        /// <summary>
        /// Cached name for the 'shaped_text_closest_character_pos' method.
        /// </summary>
        public static readonly StringName ShapedTextClosestCharacterPos = "shaped_text_closest_character_pos";
        /// <summary>
        /// Cached name for the 'shaped_text_draw' method.
        /// </summary>
        public static readonly StringName ShapedTextDraw = "shaped_text_draw";
        /// <summary>
        /// Cached name for the 'shaped_text_draw_outline' method.
        /// </summary>
        public static readonly StringName ShapedTextDrawOutline = "shaped_text_draw_outline";
        /// <summary>
        /// Cached name for the 'shaped_text_get_dominant_direction_in_range' method.
        /// </summary>
        public static readonly StringName ShapedTextGetDominantDirectionInRange = "shaped_text_get_dominant_direction_in_range";
        /// <summary>
        /// Cached name for the 'format_number' method.
        /// </summary>
        public static readonly StringName FormatNumber = "format_number";
        /// <summary>
        /// Cached name for the 'parse_number' method.
        /// </summary>
        public static readonly StringName ParseNumber = "parse_number";
        /// <summary>
        /// Cached name for the 'percent_sign' method.
        /// </summary>
        public static readonly StringName PercentSign = "percent_sign";
        /// <summary>
        /// Cached name for the 'string_get_word_breaks' method.
        /// </summary>
        public static readonly StringName StringGetWordBreaks = "string_get_word_breaks";
        /// <summary>
        /// Cached name for the 'string_get_character_breaks' method.
        /// </summary>
        public static readonly StringName StringGetCharacterBreaks = "string_get_character_breaks";
        /// <summary>
        /// Cached name for the 'is_confusable' method.
        /// </summary>
        public static readonly StringName IsConfusable = "is_confusable";
        /// <summary>
        /// Cached name for the 'spoof_check' method.
        /// </summary>
        public static readonly StringName SpoofCheck = "spoof_check";
        /// <summary>
        /// Cached name for the 'strip_diacritics' method.
        /// </summary>
        public static readonly StringName StripDiacritics = "strip_diacritics";
        /// <summary>
        /// Cached name for the 'is_valid_identifier' method.
        /// </summary>
        public static readonly StringName IsValidIdentifier = "is_valid_identifier";
        /// <summary>
        /// Cached name for the 'is_valid_letter' method.
        /// </summary>
        public static readonly StringName IsValidLetter = "is_valid_letter";
        /// <summary>
        /// Cached name for the 'string_to_upper' method.
        /// </summary>
        public static readonly StringName StringToUpper = "string_to_upper";
        /// <summary>
        /// Cached name for the 'string_to_lower' method.
        /// </summary>
        public static readonly StringName StringToLower = "string_to_lower";
        /// <summary>
        /// Cached name for the 'string_to_title' method.
        /// </summary>
        public static readonly StringName StringToTitle = "string_to_title";
        /// <summary>
        /// Cached name for the 'parse_structured_text' method.
        /// </summary>
        public static readonly StringName ParseStructuredText = "parse_structured_text";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : RefCounted.SignalName
    {
    }
}
