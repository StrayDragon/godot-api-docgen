namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A control for displaying plain text. It gives you control over the horizontal and vertical alignment and can wrap the text inside the node's bounding rectangle. It doesn't support bold, italics, or other rich text formatting. For that, use <see cref="Godot.RichTextLabel"/> instead.</para>
/// <para><b>Note:</b> A single Label node is not designed to display huge amounts of text. To display large amounts of text in a single node, consider using <see cref="Godot.RichTextLabel"/> instead as it supports features like an integrated scroll bar and threading. <see cref="Godot.RichTextLabel"/> generally performs better when displaying large amounts of text (several pages or more).</para>
/// </summary>
public partial class Label : Control
{
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
    /// <para>A <see cref="Godot.LabelSettings"/> resource that can be shared between multiple <see cref="Godot.Label"/> nodes. Takes priority over theme properties.</para>
    /// </summary>
    public LabelSettings LabelSettings
    {
        get
        {
            return GetLabelSettings();
        }
        set
        {
            SetLabelSettings(value);
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
    /// <para>Controls the text's vertical alignment. Supports top, center, bottom, and fill.</para>
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
    /// <para>String used as a paragraph separator. Each paragraph is processed independently, in its own BiDi context.</para>
    /// </summary>
    public string ParagraphSeparator
    {
        get
        {
            return GetParagraphSeparator();
        }
        set
        {
            SetParagraphSeparator(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the Label only shows the text that fits inside its bounding rectangle and will clip text horizontally.</para>
    /// </summary>
    public bool ClipText
    {
        get
        {
            return IsClippingText();
        }
        set
        {
            SetClipText(value);
        }
    }

    /// <summary>
    /// <para>The clipping behavior when the text exceeds the node's bounding rectangle.</para>
    /// </summary>
    public TextServer.OverrunBehavior TextOverrunBehavior
    {
        get
        {
            return GetTextOverrunBehavior();
        }
        set
        {
            SetTextOverrunBehavior(value);
        }
    }

    /// <summary>
    /// <para>Ellipsis character used for text clipping.</para>
    /// </summary>
    public string EllipsisChar
    {
        get
        {
            return GetEllipsisChar();
        }
        set
        {
            SetEllipsisChar(value);
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
    /// <para>Aligns text to the given tab-stops.</para>
    /// </summary>
    public float[] TabStops
    {
        get
        {
            return GetTabStops();
        }
        set
        {
            SetTabStops(value);
        }
    }

    /// <summary>
    /// <para>The number of the lines ignored and not displayed from the start of the <see cref="Godot.Label.Text"/> value.</para>
    /// </summary>
    public int LinesSkipped
    {
        get
        {
            return GetLinesSkipped();
        }
        set
        {
            SetLinesSkipped(value);
        }
    }

    /// <summary>
    /// <para>Limits the lines of text the node shows on screen.</para>
    /// </summary>
    public int MaxLinesVisible
    {
        get
        {
            return GetMaxLinesVisible();
        }
        set
        {
            SetMaxLinesVisible(value);
        }
    }

    /// <summary>
    /// <para>The number of characters to display. If set to <c>-1</c>, all characters are displayed. This can be useful when animating the text appearing in a dialog box.</para>
    /// <para><b>Note:</b> Setting this property updates <see cref="Godot.Label.VisibleRatio"/> accordingly.</para>
    /// <para><b>Note:</b> Characters are counted as Unicode codepoints. A single visible grapheme may contain multiple codepoints (e.g. certain emoji use three codepoints). A single codepoint may contain two UTF-16 characters, which are used in C# strings.</para>
    /// </summary>
    public int VisibleCharacters
    {
        get
        {
            return GetVisibleCharacters();
        }
        set
        {
            SetVisibleCharacters(value);
        }
    }

    /// <summary>
    /// <para>The clipping behavior when <see cref="Godot.Label.VisibleCharacters"/> or <see cref="Godot.Label.VisibleRatio"/> is set.</para>
    /// </summary>
    public TextServer.VisibleCharactersBehavior VisibleCharactersBehavior
    {
        get
        {
            return GetVisibleCharactersBehavior();
        }
        set
        {
            SetVisibleCharactersBehavior(value);
        }
    }

    /// <summary>
    /// <para>The fraction of characters to display, relative to the total number of characters (see <see cref="Godot.Label.GetTotalCharacterCount()"/>). If set to <c>1.0</c>, all characters are displayed. If set to <c>0.5</c>, only half of the characters will be displayed. This can be useful when animating the text appearing in a dialog box.</para>
    /// <para><b>Note:</b> Setting this property updates <see cref="Godot.Label.VisibleCharacters"/> accordingly.</para>
    /// </summary>
    public float VisibleRatio
    {
        get
        {
            return GetVisibleRatio();
        }
        set
        {
            SetVisibleRatio(value);
        }
    }

    /// <summary>
    /// <para>Base text writing direction.</para>
    /// </summary>
    public new Control.TextDirection TextDirection
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

    private static readonly System.Type CachedType = typeof(Label);

    private static readonly StringName NativeName = "Label";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public Label() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal Label(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal Label(bool memoryOwn) : base(memoryOwn) { }

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
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetText, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetText(string text)
    {
        NativeCalls.godot_icall_1_57(MethodBind4, GodotObject.GetPtr(this), text);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetText, 201670096ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetText()
    {
        return NativeCalls.godot_icall_0_58(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLabelSettings, 1030653839ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetLabelSettings(LabelSettings settings)
    {
        NativeCalls.godot_icall_1_56(MethodBind6, GodotObject.GetPtr(this), GodotObject.GetPtr(settings));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLabelSettings, 826676056ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public LabelSettings GetLabelSettings()
    {
        return (LabelSettings)NativeCalls.godot_icall_0_63(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTextDirection, 119160795ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTextDirection(Control.TextDirection direction)
    {
        NativeCalls.godot_icall_1_38(MethodBind8, GodotObject.GetPtr(this), (int)direction);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTextDirection, 797257663ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Control.TextDirection GetTextDirection()
    {
        return (Control.TextDirection)NativeCalls.godot_icall_0_39(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLanguage, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetLanguage(string language)
    {
        NativeCalls.godot_icall_1_57(MethodBind10, GodotObject.GetPtr(this), language);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLanguage, 201670096ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetLanguage()
    {
        return NativeCalls.godot_icall_0_58(MethodBind11, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetParagraphSeparator, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetParagraphSeparator(string paragraphSeparator)
    {
        NativeCalls.godot_icall_1_57(MethodBind12, GodotObject.GetPtr(this), paragraphSeparator);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetParagraphSeparator, 201670096ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetParagraphSeparator()
    {
        return NativeCalls.godot_icall_0_58(MethodBind13, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAutowrapMode, 3289138044ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAutowrapMode(TextServer.AutowrapMode autowrapMode)
    {
        NativeCalls.godot_icall_1_38(MethodBind14, GodotObject.GetPtr(this), (int)autowrapMode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAutowrapMode, 1549071663ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public TextServer.AutowrapMode GetAutowrapMode()
    {
        return (TextServer.AutowrapMode)NativeCalls.godot_icall_0_39(MethodBind15, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAutowrapTrimFlags, 2809697122ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAutowrapTrimFlags(TextServer.LineBreakFlag autowrapTrimFlags)
    {
        NativeCalls.godot_icall_1_38(MethodBind16, GodotObject.GetPtr(this), (int)autowrapTrimFlags);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAutowrapTrimFlags, 2340632602ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public TextServer.LineBreakFlag GetAutowrapTrimFlags()
    {
        return (TextServer.LineBreakFlag)NativeCalls.godot_icall_0_39(MethodBind17, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetJustificationFlags, 2877345813ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetJustificationFlags(TextServer.JustificationFlag justificationFlags)
    {
        NativeCalls.godot_icall_1_38(MethodBind18, GodotObject.GetPtr(this), (int)justificationFlags);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetJustificationFlags, 1583363614ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public TextServer.JustificationFlag GetJustificationFlags()
    {
        return (TextServer.JustificationFlag)NativeCalls.godot_icall_0_39(MethodBind19, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetClipText, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetClipText(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind20, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsClippingText, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsClippingText()
    {
        return NativeCalls.godot_icall_0_15(MethodBind21, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTabStops, 2899603908ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTabStops(float[] tabStops)
    {
        NativeCalls.godot_icall_1_647(MethodBind22, GodotObject.GetPtr(this), tabStops);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTabStops(ReadOnlySpan<float> tabStops)
    {
        NativeCalls.godot_icall_1_647(MethodBind22, GodotObject.GetPtr(this), tabStops);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTabStops, 675695659ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float[] GetTabStops()
    {
        return NativeCalls.godot_icall_0_368(MethodBind23, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTextOverrunBehavior, 1008890932ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTextOverrunBehavior(TextServer.OverrunBehavior overrunBehavior)
    {
        NativeCalls.godot_icall_1_38(MethodBind24, GodotObject.GetPtr(this), (int)overrunBehavior);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTextOverrunBehavior, 3779142101ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public TextServer.OverrunBehavior GetTextOverrunBehavior()
    {
        return (TextServer.OverrunBehavior)NativeCalls.godot_icall_0_39(MethodBind25, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEllipsisChar, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEllipsisChar(string @char)
    {
        NativeCalls.godot_icall_1_57(MethodBind26, GodotObject.GetPtr(this), @char);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEllipsisChar, 201670096ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetEllipsisChar()
    {
        return NativeCalls.godot_icall_0_58(MethodBind27, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetUppercase, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetUppercase(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind28, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsUppercase, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsUppercase()
    {
        return NativeCalls.godot_icall_0_15(MethodBind29, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLineHeight, 181039630ul);

    /// <summary>
    /// <para>Returns the height of the line <paramref name="line"/>.</para>
    /// <para>If <paramref name="line"/> is set to <c>-1</c>, returns the biggest line height.</para>
    /// <para>If there are no lines, returns font size in pixels.</para>
    /// </summary>
    public int GetLineHeight(int line = -1)
    {
        return NativeCalls.godot_icall_1_60(MethodBind30, GodotObject.GetPtr(this), line);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLineCount, 3905245786ul);

    /// <summary>
    /// <para>Returns the number of lines of text the Label has.</para>
    /// </summary>
    public int GetLineCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind31, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind32 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVisibleLineCount, 3905245786ul);

    /// <summary>
    /// <para>Returns the number of lines shown. Useful if the <see cref="Godot.Label"/>'s height cannot currently display all lines.</para>
    /// </summary>
    public int GetVisibleLineCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind32, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind33 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTotalCharacterCount, 3905245786ul);

    /// <summary>
    /// <para>Returns the total number of printable characters in the text (excluding spaces and newlines).</para>
    /// </summary>
    public int GetTotalCharacterCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind33, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind34 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVisibleCharacters, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetVisibleCharacters(int amount)
    {
        NativeCalls.godot_icall_1_38(MethodBind34, GodotObject.GetPtr(this), amount);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind35 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVisibleCharacters, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetVisibleCharacters()
    {
        return NativeCalls.godot_icall_0_39(MethodBind35, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind36 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVisibleCharactersBehavior, 258789322ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public TextServer.VisibleCharactersBehavior GetVisibleCharactersBehavior()
    {
        return (TextServer.VisibleCharactersBehavior)NativeCalls.godot_icall_0_39(MethodBind36, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind37 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVisibleCharactersBehavior, 3383839701ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetVisibleCharactersBehavior(TextServer.VisibleCharactersBehavior behavior)
    {
        NativeCalls.godot_icall_1_38(MethodBind37, GodotObject.GetPtr(this), (int)behavior);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind38 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVisibleRatio, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetVisibleRatio(float ratio)
    {
        NativeCalls.godot_icall_1_67(MethodBind38, GodotObject.GetPtr(this), ratio);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind39 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVisibleRatio, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetVisibleRatio()
    {
        return NativeCalls.godot_icall_0_68(MethodBind39, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind40 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLinesSkipped, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetLinesSkipped(int linesSkipped)
    {
        NativeCalls.godot_icall_1_38(MethodBind40, GodotObject.GetPtr(this), linesSkipped);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind41 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLinesSkipped, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetLinesSkipped()
    {
        return NativeCalls.godot_icall_0_39(MethodBind41, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind42 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMaxLinesVisible, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMaxLinesVisible(int linesVisible)
    {
        NativeCalls.godot_icall_1_38(MethodBind42, GodotObject.GetPtr(this), linesVisible);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind43 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMaxLinesVisible, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetMaxLinesVisible()
    {
        return NativeCalls.godot_icall_0_39(MethodBind43, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind44 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetStructuredTextBidiOverride, 55961453ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetStructuredTextBidiOverride(TextServer.StructuredTextParser parser)
    {
        NativeCalls.godot_icall_1_38(MethodBind44, GodotObject.GetPtr(this), (int)parser);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind45 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetStructuredTextBidiOverride, 3385126229ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public TextServer.StructuredTextParser GetStructuredTextBidiOverride()
    {
        return (TextServer.StructuredTextParser)NativeCalls.godot_icall_0_39(MethodBind45, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind46 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetStructuredTextBidiOverrideOptions, 381264803ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetStructuredTextBidiOverrideOptions(Godot.Collections.Array args)
    {
        NativeCalls.godot_icall_1_138(MethodBind46, GodotObject.GetPtr(this), (godot_array)(args ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind47 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetStructuredTextBidiOverrideOptions, 3995934104ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Godot.Collections.Array GetStructuredTextBidiOverrideOptions()
    {
        return NativeCalls.godot_icall_0_120(MethodBind47, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind48 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCharacterBounds, 3327874267ul);

    /// <summary>
    /// <para>Returns the bounding rectangle of the character at position <paramref name="pos"/> in the label's local coordinate system. If the character is a non-visual character or <paramref name="pos"/> is outside the valid range, an empty <see cref="Godot.Rect2"/> is returned. If the character is a part of a composite grapheme, the bounding rectangle of the whole grapheme is returned.</para>
    /// </summary>
    public Rect2 GetCharacterBounds(int pos)
    {
        return NativeCalls.godot_icall_1_450(MethodBind48, GodotObject.GetPtr(this), pos);
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
    public new class PropertyName : Control.PropertyName
    {
        /// <summary>
        /// Cached name for the 'text' property.
        /// </summary>
        public static readonly StringName Text = "text";
        /// <summary>
        /// Cached name for the 'label_settings' property.
        /// </summary>
        public static readonly StringName LabelSettings = "label_settings";
        /// <summary>
        /// Cached name for the 'horizontal_alignment' property.
        /// </summary>
        public static readonly StringName HorizontalAlignment = "horizontal_alignment";
        /// <summary>
        /// Cached name for the 'vertical_alignment' property.
        /// </summary>
        public static readonly StringName VerticalAlignment = "vertical_alignment";
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
        /// Cached name for the 'paragraph_separator' property.
        /// </summary>
        public static readonly StringName ParagraphSeparator = "paragraph_separator";
        /// <summary>
        /// Cached name for the 'clip_text' property.
        /// </summary>
        public static readonly StringName ClipText = "clip_text";
        /// <summary>
        /// Cached name for the 'text_overrun_behavior' property.
        /// </summary>
        public static readonly StringName TextOverrunBehavior = "text_overrun_behavior";
        /// <summary>
        /// Cached name for the 'ellipsis_char' property.
        /// </summary>
        public static readonly StringName EllipsisChar = "ellipsis_char";
        /// <summary>
        /// Cached name for the 'uppercase' property.
        /// </summary>
        public static readonly StringName Uppercase = "uppercase";
        /// <summary>
        /// Cached name for the 'tab_stops' property.
        /// </summary>
        public static readonly StringName TabStops = "tab_stops";
        /// <summary>
        /// Cached name for the 'lines_skipped' property.
        /// </summary>
        public static readonly StringName LinesSkipped = "lines_skipped";
        /// <summary>
        /// Cached name for the 'max_lines_visible' property.
        /// </summary>
        public static readonly StringName MaxLinesVisible = "max_lines_visible";
        /// <summary>
        /// Cached name for the 'visible_characters' property.
        /// </summary>
        public static readonly StringName VisibleCharacters = "visible_characters";
        /// <summary>
        /// Cached name for the 'visible_characters_behavior' property.
        /// </summary>
        public static readonly StringName VisibleCharactersBehavior = "visible_characters_behavior";
        /// <summary>
        /// Cached name for the 'visible_ratio' property.
        /// </summary>
        public static readonly StringName VisibleRatio = "visible_ratio";
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
    public new class MethodName : Control.MethodName
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
        /// Cached name for the 'set_text' method.
        /// </summary>
        public static readonly StringName SetText = "set_text";
        /// <summary>
        /// Cached name for the 'get_text' method.
        /// </summary>
        public static readonly StringName GetText = "get_text";
        /// <summary>
        /// Cached name for the 'set_label_settings' method.
        /// </summary>
        public static readonly StringName SetLabelSettings = "set_label_settings";
        /// <summary>
        /// Cached name for the 'get_label_settings' method.
        /// </summary>
        public static readonly StringName GetLabelSettings = "get_label_settings";
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
        /// Cached name for the 'set_paragraph_separator' method.
        /// </summary>
        public static readonly StringName SetParagraphSeparator = "set_paragraph_separator";
        /// <summary>
        /// Cached name for the 'get_paragraph_separator' method.
        /// </summary>
        public static readonly StringName GetParagraphSeparator = "get_paragraph_separator";
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
        /// Cached name for the 'set_clip_text' method.
        /// </summary>
        public static readonly StringName SetClipText = "set_clip_text";
        /// <summary>
        /// Cached name for the 'is_clipping_text' method.
        /// </summary>
        public static readonly StringName IsClippingText = "is_clipping_text";
        /// <summary>
        /// Cached name for the 'set_tab_stops' method.
        /// </summary>
        public static readonly StringName SetTabStops = "set_tab_stops";
        /// <summary>
        /// Cached name for the 'get_tab_stops' method.
        /// </summary>
        public static readonly StringName GetTabStops = "get_tab_stops";
        /// <summary>
        /// Cached name for the 'set_text_overrun_behavior' method.
        /// </summary>
        public static readonly StringName SetTextOverrunBehavior = "set_text_overrun_behavior";
        /// <summary>
        /// Cached name for the 'get_text_overrun_behavior' method.
        /// </summary>
        public static readonly StringName GetTextOverrunBehavior = "get_text_overrun_behavior";
        /// <summary>
        /// Cached name for the 'set_ellipsis_char' method.
        /// </summary>
        public static readonly StringName SetEllipsisChar = "set_ellipsis_char";
        /// <summary>
        /// Cached name for the 'get_ellipsis_char' method.
        /// </summary>
        public static readonly StringName GetEllipsisChar = "get_ellipsis_char";
        /// <summary>
        /// Cached name for the 'set_uppercase' method.
        /// </summary>
        public static readonly StringName SetUppercase = "set_uppercase";
        /// <summary>
        /// Cached name for the 'is_uppercase' method.
        /// </summary>
        public static readonly StringName IsUppercase = "is_uppercase";
        /// <summary>
        /// Cached name for the 'get_line_height' method.
        /// </summary>
        public static readonly StringName GetLineHeight = "get_line_height";
        /// <summary>
        /// Cached name for the 'get_line_count' method.
        /// </summary>
        public static readonly StringName GetLineCount = "get_line_count";
        /// <summary>
        /// Cached name for the 'get_visible_line_count' method.
        /// </summary>
        public static readonly StringName GetVisibleLineCount = "get_visible_line_count";
        /// <summary>
        /// Cached name for the 'get_total_character_count' method.
        /// </summary>
        public static readonly StringName GetTotalCharacterCount = "get_total_character_count";
        /// <summary>
        /// Cached name for the 'set_visible_characters' method.
        /// </summary>
        public static readonly StringName SetVisibleCharacters = "set_visible_characters";
        /// <summary>
        /// Cached name for the 'get_visible_characters' method.
        /// </summary>
        public static readonly StringName GetVisibleCharacters = "get_visible_characters";
        /// <summary>
        /// Cached name for the 'get_visible_characters_behavior' method.
        /// </summary>
        public static readonly StringName GetVisibleCharactersBehavior = "get_visible_characters_behavior";
        /// <summary>
        /// Cached name for the 'set_visible_characters_behavior' method.
        /// </summary>
        public static readonly StringName SetVisibleCharactersBehavior = "set_visible_characters_behavior";
        /// <summary>
        /// Cached name for the 'set_visible_ratio' method.
        /// </summary>
        public static readonly StringName SetVisibleRatio = "set_visible_ratio";
        /// <summary>
        /// Cached name for the 'get_visible_ratio' method.
        /// </summary>
        public static readonly StringName GetVisibleRatio = "get_visible_ratio";
        /// <summary>
        /// Cached name for the 'set_lines_skipped' method.
        /// </summary>
        public static readonly StringName SetLinesSkipped = "set_lines_skipped";
        /// <summary>
        /// Cached name for the 'get_lines_skipped' method.
        /// </summary>
        public static readonly StringName GetLinesSkipped = "get_lines_skipped";
        /// <summary>
        /// Cached name for the 'set_max_lines_visible' method.
        /// </summary>
        public static readonly StringName SetMaxLinesVisible = "set_max_lines_visible";
        /// <summary>
        /// Cached name for the 'get_max_lines_visible' method.
        /// </summary>
        public static readonly StringName GetMaxLinesVisible = "get_max_lines_visible";
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
        /// Cached name for the 'get_character_bounds' method.
        /// </summary>
        public static readonly StringName GetCharacterBounds = "get_character_bounds";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Control.SignalName
    {
    }
}
