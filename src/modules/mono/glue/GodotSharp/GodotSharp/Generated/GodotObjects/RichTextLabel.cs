namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A control for displaying text that can contain custom fonts, images, and basic formatting. <see cref="Godot.RichTextLabel"/> manages these as an internal tag stack. It also adapts itself to given width/heights.</para>
/// <para><b>Note:</b> <see cref="Godot.RichTextLabel.Newline()"/>, <see cref="Godot.RichTextLabel.PushParagraph(HorizontalAlignment, Control.TextDirection, string, TextServer.StructuredTextParser, TextServer.JustificationFlag, float[])"/>, <c>"\n"</c>, <c>"\r\n"</c>, <c>p</c> tag, and alignment tags start a new paragraph. Each paragraph is processed independently, in its own BiDi context. If you want to force line wrapping within paragraph, any other line breaking character can be used, for example, Form Feed (U+000C), Next Line (U+0085), Line Separator (U+2028).</para>
/// <para><b>Note:</b> Assignments to <see cref="Godot.RichTextLabel.Text"/> clear the tag stack and reconstruct it from the property's contents. Any edits made to <see cref="Godot.RichTextLabel.Text"/> will erase previous edits made from other manual sources such as <see cref="Godot.RichTextLabel.AppendText(string)"/> and the <c>push_*</c> / <see cref="Godot.RichTextLabel.Pop()"/> methods.</para>
/// <para><b>Note:</b> RichTextLabel doesn't support entangled BBCode tags. For example, instead of using <c>[b]bold[i]bold italic[/b]italic[/i]</c>, use <c>[b]bold[i]bold italic[/i][/b][i]italic[/i]</c>.</para>
/// <para><b>Note:</b> <c>push_*/pop_*</c> functions won't affect BBCode.</para>
/// <para><b>Note:</b> While <see cref="Godot.RichTextLabel.BbcodeEnabled"/> is enabled, alignment tags such as <c>[center]</c> will take priority over the <see cref="Godot.RichTextLabel.HorizontalAlignment"/> setting which determines the default text alignment.</para>
/// </summary>
public partial class RichTextLabel : Control
{
    public enum ListType : long
    {
        /// <summary>
        /// <para>Each list item has a number marker.</para>
        /// </summary>
        Numbers = 0,
        /// <summary>
        /// <para>Each list item has a letter marker.</para>
        /// </summary>
        Letters = 1,
        /// <summary>
        /// <para>Each list item has a roman number marker.</para>
        /// </summary>
        Roman = 2,
        /// <summary>
        /// <para>Each list item has a filled circle marker.</para>
        /// </summary>
        Dots = 3
    }

    public enum MenuItems : long
    {
        /// <summary>
        /// <para>Copies the selected text.</para>
        /// </summary>
        Copy = 0,
        /// <summary>
        /// <para>Selects the whole <see cref="Godot.RichTextLabel"/> text.</para>
        /// </summary>
        SelectAll = 1,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.RichTextLabel.MenuItems"/> enum.</para>
        /// </summary>
        Max = 2
    }

    public enum MetaUnderline : long
    {
        /// <summary>
        /// <para>Meta tag does not display an underline, even if <see cref="Godot.RichTextLabel.MetaUnderlined"/> is <see langword="true"/>.</para>
        /// </summary>
        Never = 0,
        /// <summary>
        /// <para>If <see cref="Godot.RichTextLabel.MetaUnderlined"/> is <see langword="true"/>, meta tag always display an underline.</para>
        /// </summary>
        Always = 1,
        /// <summary>
        /// <para>If <see cref="Godot.RichTextLabel.MetaUnderlined"/> is <see langword="true"/>, meta tag display an underline when the mouse cursor is over it.</para>
        /// </summary>
        OnHover = 2
    }

    [System.Flags]
    public enum ImageUpdateMask : long
    {
        /// <summary>
        /// <para>If this bit is set, <see cref="Godot.RichTextLabel.UpdateImage(Variant, RichTextLabel.ImageUpdateMask, Texture2D, int, int, Nullable{Color}, InlineAlignment, Nullable{Rect2}, bool, string, bool, bool)"/> changes image texture.</para>
        /// </summary>
        Texture = 1,
        /// <summary>
        /// <para>If this bit is set, <see cref="Godot.RichTextLabel.UpdateImage(Variant, RichTextLabel.ImageUpdateMask, Texture2D, int, int, Nullable{Color}, InlineAlignment, Nullable{Rect2}, bool, string, bool, bool)"/> changes image size.</para>
        /// </summary>
        Size = 2,
        /// <summary>
        /// <para>If this bit is set, <see cref="Godot.RichTextLabel.UpdateImage(Variant, RichTextLabel.ImageUpdateMask, Texture2D, int, int, Nullable{Color}, InlineAlignment, Nullable{Rect2}, bool, string, bool, bool)"/> changes image color.</para>
        /// </summary>
        Color = 4,
        /// <summary>
        /// <para>If this bit is set, <see cref="Godot.RichTextLabel.UpdateImage(Variant, RichTextLabel.ImageUpdateMask, Texture2D, int, int, Nullable{Color}, InlineAlignment, Nullable{Rect2}, bool, string, bool, bool)"/> changes image inline alignment.</para>
        /// </summary>
        Alignment = 8,
        /// <summary>
        /// <para>If this bit is set, <see cref="Godot.RichTextLabel.UpdateImage(Variant, RichTextLabel.ImageUpdateMask, Texture2D, int, int, Nullable{Color}, InlineAlignment, Nullable{Rect2}, bool, string, bool, bool)"/> changes image texture region.</para>
        /// </summary>
        Region = 16,
        /// <summary>
        /// <para>If this bit is set, <see cref="Godot.RichTextLabel.UpdateImage(Variant, RichTextLabel.ImageUpdateMask, Texture2D, int, int, Nullable{Color}, InlineAlignment, Nullable{Rect2}, bool, string, bool, bool)"/> changes image padding.</para>
        /// </summary>
        Pad = 32,
        /// <summary>
        /// <para>If this bit is set, <see cref="Godot.RichTextLabel.UpdateImage(Variant, RichTextLabel.ImageUpdateMask, Texture2D, int, int, Nullable{Color}, InlineAlignment, Nullable{Rect2}, bool, string, bool, bool)"/> changes image tooltip.</para>
        /// </summary>
        Tooltip = 64,
        /// <summary>
        /// <para>If this bit is set, <see cref="Godot.RichTextLabel.UpdateImage(Variant, RichTextLabel.ImageUpdateMask, Texture2D, int, int, Nullable{Color}, InlineAlignment, Nullable{Rect2}, bool, string, bool, bool)"/> changes image width from/to percents.</para>
        /// </summary>
        WidthInPercent = 128
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the label uses BBCode formatting.</para>
    /// <para><b>Note:</b> This only affects the contents of <see cref="Godot.RichTextLabel.Text"/>, not the tag stack.</para>
    /// </summary>
    public bool BbcodeEnabled
    {
        get
        {
            return IsUsingBbcode();
        }
        set
        {
            SetUseBbcode(value);
        }
    }

    /// <summary>
    /// <para>The label's text in BBCode format. Is not representative of manual modifications to the internal tag stack. Erases changes made by other methods when edited.</para>
    /// <para><b>Note:</b> If <see cref="Godot.RichTextLabel.BbcodeEnabled"/> is <see langword="true"/>, it is unadvised to use the <c>+=</c> operator with <see cref="Godot.RichTextLabel.Text"/> (e.g. <c>text += "some string"</c>) as it replaces the whole text and can cause slowdowns. It will also erase all BBCode that was added to stack using <c>push_*</c> methods. Use <see cref="Godot.RichTextLabel.AppendText(string)"/> for adding text instead, unless you absolutely need to close a tag that was opened in an earlier method call.</para>
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
    /// <para>If <see langword="true"/>, the label's minimum size will be automatically updated to fit its content, matching the behavior of <see cref="Godot.Label"/>.</para>
    /// </summary>
    public bool FitContent
    {
        get
        {
            return IsFitContentEnabled();
        }
        set
        {
            SetFitContent(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the scrollbar is visible. Setting this to <see langword="false"/> does not block scrolling completely. See <see cref="Godot.RichTextLabel.ScrollToLine(int)"/>.</para>
    /// </summary>
    public bool ScrollActive
    {
        get
        {
            return IsScrollActive();
        }
        set
        {
            SetScrollActive(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the window scrolls down to display new content automatically.</para>
    /// </summary>
    public bool ScrollFollowing
    {
        get
        {
            return IsScrollFollowing();
        }
        set
        {
            SetScrollFollow(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the window scrolls to display the last visible line when <see cref="Godot.RichTextLabel.VisibleCharacters"/> or <see cref="Godot.RichTextLabel.VisibleRatio"/> is changed.</para>
    /// </summary>
    public bool ScrollFollowingVisibleCharacters
    {
        get
        {
            return IsScrollFollowingVisibleCharacters();
        }
        set
        {
            SetScrollFollowVisibleCharacters(value);
        }
    }

    /// <summary>
    /// <para>If set to something other than <see cref="Godot.TextServer.AutowrapMode.Off"/>, the text gets wrapped inside the node's bounding rectangle.</para>
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
    /// <para>The number of spaces associated with a single tab length. Does not affect <c>\t</c> in text tags, only indent tags.</para>
    /// </summary>
    public int TabSize
    {
        get
        {
            return GetTabSize();
        }
        set
        {
            SetTabSize(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, a right-click displays the context menu.</para>
    /// </summary>
    public bool ContextMenuEnabled
    {
        get
        {
            return IsContextMenuEnabled();
        }
        set
        {
            SetContextMenuEnabled(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, shortcut keys for context menu items are enabled, even if the context menu is disabled.</para>
    /// </summary>
    public bool ShortcutKeysEnabled
    {
        get
        {
            return IsShortcutKeysEnabled();
        }
        set
        {
            SetShortcutKeysEnabled(value);
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
    /// <para>The currently installed custom effects. This is an array of <see cref="Godot.RichTextEffect"/>s.</para>
    /// <para>To add a custom effect, it's more convenient to use <see cref="Godot.RichTextLabel.InstallEffect(Variant)"/>.</para>
    /// </summary>
    public Godot.Collections.Array CustomEffects
    {
        get
        {
            return GetEffects();
        }
        set
        {
            SetEffects(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the label underlines meta tags such as <c>[url]{text}[/url]</c>. These tags can call a function when clicked if <see cref="Godot.RichTextLabel.MetaClicked"/> is connected to a function.</para>
    /// </summary>
    public bool MetaUnderlined
    {
        get
        {
            return IsMetaUnderlined();
        }
        set
        {
            SetMetaUnderline(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the label underlines hint tags such as <c>[hint=description]{text}[/hint]</c>.</para>
    /// </summary>
    public bool HintUnderlined
    {
        get
        {
            return IsHintUnderlined();
        }
        set
        {
            SetHintUnderline(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, text processing is done in a background thread.</para>
    /// </summary>
    public bool Threaded
    {
        get
        {
            return IsThreaded();
        }
        set
        {
            SetThreaded(value);
        }
    }

    /// <summary>
    /// <para>The delay after which the loading progress bar is displayed, in milliseconds. Set to <c>-1</c> to disable progress bar entirely.</para>
    /// <para><b>Note:</b> Progress bar is displayed only if <see cref="Godot.RichTextLabel.Threaded"/> is enabled.</para>
    /// </summary>
    public int ProgressBarDelay
    {
        get
        {
            return GetProgressBarDelay();
        }
        set
        {
            SetProgressBarDelay(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the label allows text selection.</para>
    /// </summary>
    public bool SelectionEnabled
    {
        get
        {
            return IsSelectionEnabled();
        }
        set
        {
            SetSelectionEnabled(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the selected text will be deselected when focus is lost.</para>
    /// </summary>
    public bool DeselectOnFocusLossEnabled
    {
        get
        {
            return IsDeselectOnFocusLossEnabled();
        }
        set
        {
            SetDeselectOnFocusLossEnabled(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, allow drag and drop of selected text.</para>
    /// </summary>
    public bool DragAndDropSelectionEnabled
    {
        get
        {
            return IsDragAndDropSelectionEnabled();
        }
        set
        {
            SetDragAndDropSelectionEnabled(value);
        }
    }

    /// <summary>
    /// <para>The number of characters to display. If set to <c>-1</c>, all characters are displayed. This can be useful when animating the text appearing in a dialog box.</para>
    /// <para><b>Note:</b> Setting this property updates <see cref="Godot.RichTextLabel.VisibleRatio"/> accordingly.</para>
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
    /// <para>The clipping behavior when <see cref="Godot.RichTextLabel.VisibleCharacters"/> or <see cref="Godot.RichTextLabel.VisibleRatio"/> is set.</para>
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
    /// <para>The fraction of characters to display, relative to the total number of characters (see <see cref="Godot.RichTextLabel.GetTotalCharacterCount()"/>). If set to <c>1.0</c>, all characters are displayed. If set to <c>0.5</c>, only half of the characters will be displayed. This can be useful when animating the text appearing in a dialog box.</para>
    /// <para><b>Note:</b> Setting this property updates <see cref="Godot.RichTextLabel.VisibleCharacters"/> accordingly.</para>
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

    private static readonly System.Type CachedType = typeof(RichTextLabel);

    private static readonly StringName NativeName = "RichTextLabel";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public RichTextLabel() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal RichTextLabel(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal RichTextLabel(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetParsedText, 201670096ul);

    /// <summary>
    /// <para>Returns the text without BBCode mark-up.</para>
    /// </summary>
    public string GetParsedText()
    {
        return NativeCalls.godot_icall_0_58(MethodBind0, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddText, 83702148ul);

    /// <summary>
    /// <para>Adds raw non-BBCode-parsed text to the tag stack.</para>
    /// </summary>
    public void AddText(string text)
    {
        NativeCalls.godot_icall_1_57(MethodBind1, GodotObject.GetPtr(this), text);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetText, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetText(string text)
    {
        NativeCalls.godot_icall_1_57(MethodBind2, GodotObject.GetPtr(this), text);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddHr, 16816895ul);

    /// <summary>
    /// <para>Adds a horizontal rule that can be used to separate content.</para>
    /// <para>If <paramref name="widthInPercent"/> is set, <paramref name="width"/> values are percentages of the control width instead of pixels.</para>
    /// <para>If <paramref name="heightInPercent"/> is set, <paramref name="height"/> values are percentages of the control width instead of pixels.</para>
    /// </summary>
    /// <param name="color">If the parameter is null, then the default value is <c>new Color(1.0f, 1.0f, 1.0f, 1.0f)</c>.</param>
    public unsafe void AddHr(int width = 90, int height = 2, Nullable<Color> color = null, HorizontalAlignment alignment = (HorizontalAlignment)(1), bool widthInPercent = true, bool heightInPercent = false)
    {
        Color colorOrDefVal = color.HasValue ? color.Value : new Color(1.0f, 1.0f, 1.0f, 1.0f);
        NativeCalls.godot_icall_6_1231(MethodBind3, GodotObject.GetPtr(this), width, height, &colorOrDefVal, (int)alignment, widthInPercent.ToGodotBool(), heightInPercent.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddImage, 1390915033ul);

    /// <summary>
    /// <para>Adds an image's opening and closing tags to the tag stack, optionally providing a <paramref name="width"/> and <paramref name="height"/> to resize the image, a <paramref name="color"/> to tint the image and a <paramref name="region"/> to only use parts of the image.</para>
    /// <para>If <paramref name="width"/> or <paramref name="height"/> is set to 0, the image size will be adjusted in order to keep the original aspect ratio.</para>
    /// <para>If <paramref name="width"/> and <paramref name="height"/> are not set, but <paramref name="region"/> is, the region's rect will be used.</para>
    /// <para><paramref name="key"/> is an optional identifier, that can be used to modify the image via <see cref="Godot.RichTextLabel.UpdateImage(Variant, RichTextLabel.ImageUpdateMask, Texture2D, int, int, Nullable{Color}, InlineAlignment, Nullable{Rect2}, bool, string, bool, bool)"/>.</para>
    /// <para>If <paramref name="pad"/> is set, and the image is smaller than the size specified by <paramref name="width"/> and <paramref name="height"/>, the image padding is added to match the size instead of upscaling.</para>
    /// <para>If <paramref name="widthInPercent"/> is set, <paramref name="width"/> values are percentages of the control width instead of pixels.</para>
    /// <para>If <paramref name="heightInPercent"/> is set, <paramref name="height"/> values are percentages of the control width instead of pixels.</para>
    /// <para><paramref name="altText"/> is used as the image description for assistive apps.</para>
    /// </summary>
    /// <param name="color">If the parameter is null, then the default value is <c>new Color(1.0f, 1.0f, 1.0f, 1.0f)</c>.</param>
    /// <param name="region">If the parameter is null, then the default value is <c>new Rect2(new Vector2(0.0f, 0.0f), new Vector2(0.0f, 0.0f))</c>.</param>
    public unsafe void AddImage(Texture2D image, int width = 0, int height = 0, Nullable<Color> color = null, InlineAlignment inlineAlign = (InlineAlignment)(5), Nullable<Rect2> region = null, Variant key = default, bool pad = false, string tooltip = "", bool widthInPercent = false, bool heightInPercent = false, string altText = "")
    {
        Color colorOrDefVal = color.HasValue ? color.Value : new Color(1.0f, 1.0f, 1.0f, 1.0f);
        Rect2 regionOrDefVal = region.HasValue ? region.Value : new Rect2(new Vector2(0.0f, 0.0f), new Vector2(0.0f, 0.0f));
        NativeCalls.godot_icall_12_1232(MethodBind4, GodotObject.GetPtr(this), GodotObject.GetPtr(image), width, height, &colorOrDefVal, (int)inlineAlign, &regionOrDefVal, key, pad.ToGodotBool(), tooltip, widthInPercent.ToGodotBool(), heightInPercent.ToGodotBool(), altText);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.UpdateImage, 6389170ul);

    /// <summary>
    /// <para>Updates the existing images with the key <paramref name="key"/>. Only properties specified by <paramref name="mask"/> bits are updated. See <see cref="Godot.RichTextLabel.AddImage(Texture2D, int, int, Nullable{Color}, InlineAlignment, Nullable{Rect2}, Variant, bool, string, bool, bool, string)"/>.</para>
    /// </summary>
    /// <param name="color">If the parameter is null, then the default value is <c>new Color(1.0f, 1.0f, 1.0f, 1.0f)</c>.</param>
    /// <param name="region">If the parameter is null, then the default value is <c>new Rect2(new Vector2(0.0f, 0.0f), new Vector2(0.0f, 0.0f))</c>.</param>
    public unsafe void UpdateImage(Variant key, RichTextLabel.ImageUpdateMask mask, Texture2D image, int width = 0, int height = 0, Nullable<Color> color = null, InlineAlignment inlineAlign = (InlineAlignment)(5), Nullable<Rect2> region = null, bool pad = false, string tooltip = "", bool widthInPercent = false, bool heightInPercent = false)
    {
        Color colorOrDefVal = color.HasValue ? color.Value : new Color(1.0f, 1.0f, 1.0f, 1.0f);
        Rect2 regionOrDefVal = region.HasValue ? region.Value : new Rect2(new Vector2(0.0f, 0.0f), new Vector2(0.0f, 0.0f));
        NativeCalls.godot_icall_12_1233(MethodBind5, GodotObject.GetPtr(this), key, (int)mask, GodotObject.GetPtr(image), width, height, &colorOrDefVal, (int)inlineAlign, &regionOrDefVal, pad.ToGodotBool(), tooltip, widthInPercent.ToGodotBool(), heightInPercent.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Newline, 3218959716ul);

    /// <summary>
    /// <para>Adds a newline tag to the tag stack.</para>
    /// </summary>
    public void Newline()
    {
        NativeCalls.godot_icall_0_3(MethodBind6, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveParagraph, 3262369265ul);

    /// <summary>
    /// <para>Removes a paragraph of content from the label. Returns <see langword="true"/> if the paragraph exists.</para>
    /// <para>The <paramref name="paragraph"/> argument is the index of the paragraph to remove, it can take values in the interval <c>[0, get_paragraph_count() - 1]</c>.</para>
    /// <para>If <paramref name="noInvalidate"/> is set to <see langword="true"/>, cache for the subsequent paragraphs is not invalidated. Use it for faster updates if deleted paragraph is fully self-contained (have no unclosed tags), or this call is part of the complex edit operation and <see cref="Godot.RichTextLabel.InvalidateParagraph(int)"/> will be called at the end of operation.</para>
    /// </summary>
    public bool RemoveParagraph(int paragraph, bool noInvalidate = false)
    {
        return NativeCalls.godot_icall_2_1234(MethodBind7, GodotObject.GetPtr(this), paragraph, noInvalidate.ToGodotBool()).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.InvalidateParagraph, 3067735520ul);

    /// <summary>
    /// <para>Invalidates <paramref name="paragraph"/> and all subsequent paragraphs cache.</para>
    /// </summary>
    public bool InvalidateParagraph(int paragraph)
    {
        return NativeCalls.godot_icall_1_62(MethodBind8, GodotObject.GetPtr(this), paragraph).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PushFont, 2347424842ul);

    /// <summary>
    /// <para>Adds a <c>[font]</c> tag to the tag stack. Overrides default fonts for its duration.</para>
    /// <para>Passing <c>0</c> to <paramref name="fontSize"/> will use the existing default font size.</para>
    /// </summary>
    public void PushFont(Font font, int fontSize = 0)
    {
        NativeCalls.godot_icall_2_740(MethodBind9, GodotObject.GetPtr(this), GodotObject.GetPtr(font), fontSize);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PushFontSize, 1286410249ul);

    /// <summary>
    /// <para>Adds a <c>[font_size]</c> tag to the tag stack. Overrides default font size for its duration.</para>
    /// </summary>
    public void PushFontSize(int fontSize)
    {
        NativeCalls.godot_icall_1_38(MethodBind10, GodotObject.GetPtr(this), fontSize);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PushNormal, 3218959716ul);

    /// <summary>
    /// <para>Adds a <c>[font]</c> tag with a normal font to the tag stack.</para>
    /// </summary>
    public void PushNormal()
    {
        NativeCalls.godot_icall_0_3(MethodBind11, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PushBold, 3218959716ul);

    /// <summary>
    /// <para>Adds a <c>[font]</c> tag with a bold font to the tag stack. This is the same as adding a <c>[b]</c> tag if not currently in a <c>[i]</c> tag.</para>
    /// </summary>
    public void PushBold()
    {
        NativeCalls.godot_icall_0_3(MethodBind12, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PushBoldItalics, 3218959716ul);

    /// <summary>
    /// <para>Adds a <c>[font]</c> tag with a bold italics font to the tag stack.</para>
    /// </summary>
    public void PushBoldItalics()
    {
        NativeCalls.godot_icall_0_3(MethodBind13, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PushItalics, 3218959716ul);

    /// <summary>
    /// <para>Adds a <c>[font]</c> tag with an italics font to the tag stack. This is the same as adding an <c>[i]</c> tag if not currently in a <c>[b]</c> tag.</para>
    /// </summary>
    public void PushItalics()
    {
        NativeCalls.godot_icall_0_3(MethodBind14, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PushMono, 3218959716ul);

    /// <summary>
    /// <para>Adds a <c>[font]</c> tag with a monospace font to the tag stack.</para>
    /// </summary>
    public void PushMono()
    {
        NativeCalls.godot_icall_0_3(MethodBind15, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PushColor, 2920490490ul);

    /// <summary>
    /// <para>Adds a <c>[color]</c> tag to the tag stack.</para>
    /// </summary>
    public unsafe void PushColor(Color color)
    {
        NativeCalls.godot_icall_1_213(MethodBind16, GodotObject.GetPtr(this), &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PushOutlineSize, 1286410249ul);

    /// <summary>
    /// <para>Adds a <c>[outline_size]</c> tag to the tag stack. Overrides default text outline size for its duration.</para>
    /// </summary>
    public void PushOutlineSize(int outlineSize)
    {
        NativeCalls.godot_icall_1_38(MethodBind17, GodotObject.GetPtr(this), outlineSize);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PushOutlineColor, 2920490490ul);

    /// <summary>
    /// <para>Adds a <c>[outline_color]</c> tag to the tag stack. Adds text outline for its duration.</para>
    /// </summary>
    public unsafe void PushOutlineColor(Color color)
    {
        NativeCalls.godot_icall_1_213(MethodBind18, GodotObject.GetPtr(this), &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PushParagraph, 3089306873ul);

    /// <summary>
    /// <para>Adds a <c>[p]</c> tag to the tag stack.</para>
    /// </summary>
    /// <param name="tabStops">If the parameter is null, then the default value is <c>Array.Empty&lt;float&gt;()</c>.</param>
    public void PushParagraph(HorizontalAlignment alignment, Control.TextDirection baseDirection = (Control.TextDirection)(0), string language = "", TextServer.StructuredTextParser stParser = (TextServer.StructuredTextParser)(0), TextServer.JustificationFlag justificationFlags = (TextServer.JustificationFlag)(163), float[] tabStops = null)
    {
        float[] tabStopsOrDefVal = tabStops != null ? tabStops : Array.Empty<float>();
        NativeCalls.godot_icall_6_1235(MethodBind19, GodotObject.GetPtr(this), (int)alignment, (int)baseDirection, language, (int)stParser, (int)justificationFlags, tabStopsOrDefVal);
    }

    /// <summary>
    /// <para>Adds a <c>[p]</c> tag to the tag stack.</para>
    /// </summary>
    public void PushParagraph(HorizontalAlignment alignment, Control.TextDirection baseDirection, string language, TextServer.StructuredTextParser stParser, TextServer.JustificationFlag justificationFlags, ReadOnlySpan<float> tabStops)
    {
        NativeCalls.godot_icall_6_1235(MethodBind19, GodotObject.GetPtr(this), (int)alignment, (int)baseDirection, language, (int)stParser, (int)justificationFlags, tabStops);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PushIndent, 1286410249ul);

    /// <summary>
    /// <para>Adds an <c>[indent]</c> tag to the tag stack. Multiplies <paramref name="level"/> by current <see cref="Godot.RichTextLabel.TabSize"/> to determine new margin length.</para>
    /// </summary>
    public void PushIndent(int level)
    {
        NativeCalls.godot_icall_1_38(MethodBind20, GodotObject.GetPtr(this), level);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PushList, 3017143144ul);

    /// <summary>
    /// <para>Adds <c>[ol]</c> or <c>[ul]</c> tag to the tag stack. Multiplies <paramref name="level"/> by current <see cref="Godot.RichTextLabel.TabSize"/> to determine new margin length.</para>
    /// </summary>
    public void PushList(int level, RichTextLabel.ListType type, bool capitalize, string bullet = "•")
    {
        NativeCalls.godot_icall_4_1236(MethodBind21, GodotObject.GetPtr(this), level, (int)type, capitalize.ToGodotBool(), bullet);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PushMeta, 3765356747ul);

    /// <summary>
    /// <para>Adds a meta tag to the tag stack. Similar to the BBCode <c>[url=something]{text}[/url]</c>, but supports non-<see cref="string"/> metadata types.</para>
    /// <para>If <see cref="Godot.RichTextLabel.MetaUnderlined"/> is <see langword="true"/>, meta tags display an underline. This behavior can be customized with <paramref name="underlineMode"/>.</para>
    /// <para><b>Note:</b> Meta tags do nothing by default when clicked. To assign behavior when clicked, connect <see cref="Godot.RichTextLabel.MetaClicked"/> to a function that is called when the meta tag is clicked.</para>
    /// </summary>
    public void PushMeta(Variant data, RichTextLabel.MetaUnderline underlineMode = (RichTextLabel.MetaUnderline)(1), string tooltip = "")
    {
        NativeCalls.godot_icall_3_1237(MethodBind22, GodotObject.GetPtr(this), data, (int)underlineMode, tooltip);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PushHint, 83702148ul);

    /// <summary>
    /// <para>Adds a <c>[hint]</c> tag to the tag stack. Same as BBCode <c>[hint=something]{text}[/hint]</c>.</para>
    /// </summary>
    public void PushHint(string description)
    {
        NativeCalls.godot_icall_1_57(MethodBind23, GodotObject.GetPtr(this), description);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PushLanguage, 83702148ul);

    /// <summary>
    /// <para>Adds language code used for text shaping algorithm and Open-Type font features.</para>
    /// </summary>
    public void PushLanguage(string language)
    {
        NativeCalls.godot_icall_1_57(MethodBind24, GodotObject.GetPtr(this), language);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PushUnderline, 1458098034ul);

    /// <summary>
    /// <para>Adds a <c>[u]</c> tag to the tag stack. If <paramref name="color"/>'s alpha value is <c>0.0</c>, the current font's color with its alpha multiplied by <c>underline_alpha</c> is used.</para>
    /// </summary>
    /// <param name="color">If the parameter is null, then the default value is <c>new Color(0.0f, 0.0f, 0.0f, 0.0f)</c>.</param>
    public unsafe void PushUnderline(Nullable<Color> color = null)
    {
        Color colorOrDefVal = color.HasValue ? color.Value : new Color(0.0f, 0.0f, 0.0f, 0.0f);
        NativeCalls.godot_icall_1_213(MethodBind25, GodotObject.GetPtr(this), &colorOrDefVal);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PushStrikethrough, 1458098034ul);

    /// <summary>
    /// <para>Adds a <c>[s]</c> tag to the tag stack. If <paramref name="color"/>'s alpha value is <c>0.0</c>, the current font's color with its alpha multiplied by <c>strikethrough_alpha</c> is used.</para>
    /// </summary>
    /// <param name="color">If the parameter is null, then the default value is <c>new Color(0.0f, 0.0f, 0.0f, 0.0f)</c>.</param>
    public unsafe void PushStrikethrough(Nullable<Color> color = null)
    {
        Color colorOrDefVal = color.HasValue ? color.Value : new Color(0.0f, 0.0f, 0.0f, 0.0f);
        NativeCalls.godot_icall_1_213(MethodBind26, GodotObject.GetPtr(this), &colorOrDefVal);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PushTable, 3426862026ul);

    /// <summary>
    /// <para>Adds a <c>[table=columns,inline_align]</c> tag to the tag stack. Use <see cref="Godot.RichTextLabel.SetTableColumnExpand(int, bool, int, bool)"/> to set column expansion ratio. Use <see cref="Godot.RichTextLabel.PushCell()"/> to add cells. <paramref name="name"/> is used as the table name for assistive apps.</para>
    /// </summary>
    public void PushTable(int columns, InlineAlignment inlineAlign = (InlineAlignment)(0), int alignToRow = -1, string name = "")
    {
        NativeCalls.godot_icall_4_1238(MethodBind27, GodotObject.GetPtr(this), columns, (int)inlineAlign, alignToRow, name);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PushDropcap, 4061635501ul);

    /// <summary>
    /// <para>Adds a <c>[dropcap]</c> tag to the tag stack. Drop cap (dropped capital) is a decorative element at the beginning of a paragraph that is larger than the rest of the text.</para>
    /// </summary>
    /// <param name="dropcapMargins">If the parameter is null, then the default value is <c>new Rect2(new Vector2(0.0f, 0.0f), new Vector2(0.0f, 0.0f))</c>.</param>
    /// <param name="color">If the parameter is null, then the default value is <c>new Color(1.0f, 1.0f, 1.0f, 1.0f)</c>.</param>
    /// <param name="outlineColor">If the parameter is null, then the default value is <c>new Color(0.0f, 0.0f, 0.0f, 0.0f)</c>.</param>
    public unsafe void PushDropcap(string @string, Font font, int size, Nullable<Rect2> dropcapMargins = null, Nullable<Color> color = null, int outlineSize = 0, Nullable<Color> outlineColor = null)
    {
        Rect2 dropcapMarginsOrDefVal = dropcapMargins.HasValue ? dropcapMargins.Value : new Rect2(new Vector2(0.0f, 0.0f), new Vector2(0.0f, 0.0f));
        Color colorOrDefVal = color.HasValue ? color.Value : new Color(1.0f, 1.0f, 1.0f, 1.0f);
        Color outlineColorOrDefVal = outlineColor.HasValue ? outlineColor.Value : new Color(0.0f, 0.0f, 0.0f, 0.0f);
        NativeCalls.godot_icall_7_1239(MethodBind28, GodotObject.GetPtr(this), @string, GodotObject.GetPtr(font), size, &dropcapMarginsOrDefVal, &colorOrDefVal, outlineSize, &outlineColorOrDefVal);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTableColumnExpand, 117236061ul);

    /// <summary>
    /// <para>Edits the selected column's expansion options. If <paramref name="expand"/> is <see langword="true"/>, the column expands in proportion to its expansion ratio versus the other columns' ratios.</para>
    /// <para>For example, 2 columns with ratios 3 and 4 plus 70 pixels in available width would expand 30 and 40 pixels, respectively.</para>
    /// <para>If <paramref name="expand"/> is <see langword="false"/>, the column will not contribute to the total ratio.</para>
    /// </summary>
    public void SetTableColumnExpand(int column, bool expand, int ratio = 1, bool shrink = true)
    {
        NativeCalls.godot_icall_4_1240(MethodBind29, GodotObject.GetPtr(this), column, expand.ToGodotBool(), ratio, shrink.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTableColumnName, 501894301ul);

    /// <summary>
    /// <para>Sets table column name for assistive apps.</para>
    /// </summary>
    public void SetTableColumnName(int column, string name)
    {
        NativeCalls.godot_icall_2_181(MethodBind30, GodotObject.GetPtr(this), column, name);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCellRowBackgroundColor, 3465483165ul);

    /// <summary>
    /// <para>Sets color of a table cell. Separate colors for alternating rows can be specified.</para>
    /// </summary>
    public unsafe void SetCellRowBackgroundColor(Color oddRowBg, Color evenRowBg)
    {
        NativeCalls.godot_icall_2_1241(MethodBind31, GodotObject.GetPtr(this), &oddRowBg, &evenRowBg);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind32 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCellBorderColor, 2920490490ul);

    /// <summary>
    /// <para>Sets color of a table cell border.</para>
    /// </summary>
    public unsafe void SetCellBorderColor(Color color)
    {
        NativeCalls.godot_icall_1_213(MethodBind32, GodotObject.GetPtr(this), &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind33 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCellSizeOverride, 3108078480ul);

    /// <summary>
    /// <para>Sets minimum and maximum size overrides for a table cell.</para>
    /// </summary>
    public unsafe void SetCellSizeOverride(Vector2 minSize, Vector2 maxSize)
    {
        NativeCalls.godot_icall_2_982(MethodBind33, GodotObject.GetPtr(this), &minSize, &maxSize);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind34 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCellPadding, 2046264180ul);

    /// <summary>
    /// <para>Sets inner padding of a table cell.</para>
    /// </summary>
    public unsafe void SetCellPadding(Rect2 padding)
    {
        NativeCalls.godot_icall_1_188(MethodBind34, GodotObject.GetPtr(this), &padding);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind35 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PushCell, 3218959716ul);

    /// <summary>
    /// <para>Adds a <c>[cell]</c> tag to the tag stack. Must be inside a <c>[table]</c> tag. See <see cref="Godot.RichTextLabel.PushTable(int, InlineAlignment, int, string)"/> for details. Use <see cref="Godot.RichTextLabel.SetTableColumnExpand(int, bool, int, bool)"/> to set column expansion ratio, <see cref="Godot.RichTextLabel.SetCellBorderColor(Color)"/> to set cell border, <see cref="Godot.RichTextLabel.SetCellRowBackgroundColor(Color, Color)"/> to set cell background, <see cref="Godot.RichTextLabel.SetCellSizeOverride(Vector2, Vector2)"/> to override cell size, and <see cref="Godot.RichTextLabel.SetCellPadding(Rect2)"/> to set padding.</para>
    /// </summary>
    public void PushCell()
    {
        NativeCalls.godot_icall_0_3(MethodBind35, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind36 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PushFgcolor, 2920490490ul);

    /// <summary>
    /// <para>Adds a <c>[fgcolor]</c> tag to the tag stack.</para>
    /// <para><b>Note:</b> The foreground color has padding applied by default, which is controlled using <c>text_highlight_h_padding</c> and <c>text_highlight_v_padding</c>. This can lead to overlapping highlights if foreground colors are placed on neighboring lines/columns, so consider setting those theme items to <c>0</c> if you want to avoid this.</para>
    /// </summary>
    public unsafe void PushFgcolor(Color fgcolor)
    {
        NativeCalls.godot_icall_1_213(MethodBind36, GodotObject.GetPtr(this), &fgcolor);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind37 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PushBgcolor, 2920490490ul);

    /// <summary>
    /// <para>Adds a <c>[bgcolor]</c> tag to the tag stack.</para>
    /// <para><b>Note:</b> The background color has padding applied by default, which is controlled using <c>text_highlight_h_padding</c> and <c>text_highlight_v_padding</c>. This can lead to overlapping highlights if background colors are placed on neighboring lines/columns, so consider setting those theme items to <c>0</c> if you want to avoid this.</para>
    /// </summary>
    public unsafe void PushBgcolor(Color bgcolor)
    {
        NativeCalls.godot_icall_1_213(MethodBind37, GodotObject.GetPtr(this), &bgcolor);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind38 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PushCustomfx, 2337942958ul);

    /// <summary>
    /// <para>Adds a custom effect tag to the tag stack. The effect does not need to be in <see cref="Godot.RichTextLabel.CustomEffects"/>. The environment is directly passed to the effect.</para>
    /// </summary>
    public void PushCustomfx(RichTextEffect effect, Godot.Collections.Dictionary env)
    {
        NativeCalls.godot_icall_2_1242(MethodBind38, GodotObject.GetPtr(this), GodotObject.GetPtr(effect), (godot_dictionary)(env ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind39 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PushContext, 3218959716ul);

    /// <summary>
    /// <para>Adds a context marker to the tag stack. See <see cref="Godot.RichTextLabel.PopContext()"/>.</para>
    /// </summary>
    public void PushContext()
    {
        NativeCalls.godot_icall_0_3(MethodBind39, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind40 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PopContext, 3218959716ul);

    /// <summary>
    /// <para>Terminates tags opened after the last <see cref="Godot.RichTextLabel.PushContext()"/> call (including context marker), or all tags if there's no context marker on the stack.</para>
    /// </summary>
    public void PopContext()
    {
        NativeCalls.godot_icall_0_3(MethodBind40, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind41 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Pop, 3218959716ul);

    /// <summary>
    /// <para>Terminates the current tag. Use after <c>push_*</c> methods to close BBCodes manually. Does not need to follow <c>add_*</c> methods.</para>
    /// </summary>
    public void Pop()
    {
        NativeCalls.godot_icall_0_3(MethodBind41, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind42 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PopAll, 3218959716ul);

    /// <summary>
    /// <para>Terminates all tags opened by <c>push_*</c> methods.</para>
    /// </summary>
    public void PopAll()
    {
        NativeCalls.godot_icall_0_3(MethodBind42, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind43 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Clear, 3218959716ul);

    /// <summary>
    /// <para>Clears the tag stack, causing the label to display nothing.</para>
    /// <para><b>Note:</b> This method does not affect <see cref="Godot.RichTextLabel.Text"/>, and its contents will show again if the label is redrawn. However, setting <see cref="Godot.RichTextLabel.Text"/> to an empty <see cref="string"/> also clears the stack.</para>
    /// </summary>
    public void Clear()
    {
        NativeCalls.godot_icall_0_3(MethodBind43, GodotObject.GetPtr(this));
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
    private static readonly IntPtr MethodBind48 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTextDirection, 119160795ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTextDirection(Control.TextDirection direction)
    {
        NativeCalls.godot_icall_1_38(MethodBind48, GodotObject.GetPtr(this), (int)direction);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind49 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTextDirection, 797257663ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Control.TextDirection GetTextDirection()
    {
        return (Control.TextDirection)NativeCalls.godot_icall_0_39(MethodBind49, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind50 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLanguage, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetLanguage(string language)
    {
        NativeCalls.godot_icall_1_57(MethodBind50, GodotObject.GetPtr(this), language);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind51 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLanguage, 201670096ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetLanguage()
    {
        return NativeCalls.godot_icall_0_58(MethodBind51, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind52 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetHorizontalAlignment, 2312603777ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetHorizontalAlignment(HorizontalAlignment alignment)
    {
        NativeCalls.godot_icall_1_38(MethodBind52, GodotObject.GetPtr(this), (int)alignment);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind53 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetHorizontalAlignment, 341400642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public HorizontalAlignment GetHorizontalAlignment()
    {
        return (HorizontalAlignment)NativeCalls.godot_icall_0_39(MethodBind53, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind54 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVerticalAlignment, 1796458609ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetVerticalAlignment(VerticalAlignment alignment)
    {
        NativeCalls.godot_icall_1_38(MethodBind54, GodotObject.GetPtr(this), (int)alignment);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind55 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVerticalAlignment, 3274884059ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public VerticalAlignment GetVerticalAlignment()
    {
        return (VerticalAlignment)NativeCalls.godot_icall_0_39(MethodBind55, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind56 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetJustificationFlags, 2877345813ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetJustificationFlags(TextServer.JustificationFlag justificationFlags)
    {
        NativeCalls.godot_icall_1_38(MethodBind56, GodotObject.GetPtr(this), (int)justificationFlags);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind57 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetJustificationFlags, 1583363614ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public TextServer.JustificationFlag GetJustificationFlags()
    {
        return (TextServer.JustificationFlag)NativeCalls.godot_icall_0_39(MethodBind57, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind58 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTabStops, 2899603908ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTabStops(float[] tabStops)
    {
        NativeCalls.godot_icall_1_647(MethodBind58, GodotObject.GetPtr(this), tabStops);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTabStops(ReadOnlySpan<float> tabStops)
    {
        NativeCalls.godot_icall_1_647(MethodBind58, GodotObject.GetPtr(this), tabStops);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind59 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTabStops, 675695659ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float[] GetTabStops()
    {
        return NativeCalls.godot_icall_0_368(MethodBind59, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind60 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAutowrapMode, 3289138044ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAutowrapMode(TextServer.AutowrapMode autowrapMode)
    {
        NativeCalls.godot_icall_1_38(MethodBind60, GodotObject.GetPtr(this), (int)autowrapMode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind61 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAutowrapMode, 1549071663ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public TextServer.AutowrapMode GetAutowrapMode()
    {
        return (TextServer.AutowrapMode)NativeCalls.godot_icall_0_39(MethodBind61, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind62 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAutowrapTrimFlags, 2809697122ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAutowrapTrimFlags(TextServer.LineBreakFlag autowrapTrimFlags)
    {
        NativeCalls.godot_icall_1_38(MethodBind62, GodotObject.GetPtr(this), (int)autowrapTrimFlags);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind63 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAutowrapTrimFlags, 2340632602ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public TextServer.LineBreakFlag GetAutowrapTrimFlags()
    {
        return (TextServer.LineBreakFlag)NativeCalls.godot_icall_0_39(MethodBind63, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind64 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMetaUnderline, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMetaUnderline(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind64, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind65 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsMetaUnderlined, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsMetaUnderlined()
    {
        return NativeCalls.godot_icall_0_15(MethodBind65, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind66 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetHintUnderline, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetHintUnderline(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind66, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind67 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsHintUnderlined, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsHintUnderlined()
    {
        return NativeCalls.godot_icall_0_15(MethodBind67, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind68 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetScrollActive, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetScrollActive(bool active)
    {
        NativeCalls.godot_icall_1_14(MethodBind68, GodotObject.GetPtr(this), active.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind69 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsScrollActive, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsScrollActive()
    {
        return NativeCalls.godot_icall_0_15(MethodBind69, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind70 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetScrollFollowVisibleCharacters, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetScrollFollowVisibleCharacters(bool follow)
    {
        NativeCalls.godot_icall_1_14(MethodBind70, GodotObject.GetPtr(this), follow.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind71 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsScrollFollowingVisibleCharacters, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsScrollFollowingVisibleCharacters()
    {
        return NativeCalls.godot_icall_0_15(MethodBind71, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind72 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetScrollFollow, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetScrollFollow(bool follow)
    {
        NativeCalls.godot_icall_1_14(MethodBind72, GodotObject.GetPtr(this), follow.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind73 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsScrollFollowing, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsScrollFollowing()
    {
        return NativeCalls.godot_icall_0_15(MethodBind73, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind74 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVScrollBar, 2630340773ul);

    /// <summary>
    /// <para>Returns the vertical scrollbar.</para>
    /// <para><b>Warning:</b> This is a required internal node, removing and freeing it may cause a crash. If you wish to hide it or any of its children, use their <see cref="Godot.CanvasItem.Visible"/> property.</para>
    /// </summary>
    public VScrollBar GetVScrollBar()
    {
        return (VScrollBar)NativeCalls.godot_icall_0_53(MethodBind74, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind75 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ScrollToLine, 1286410249ul);

    /// <summary>
    /// <para>Scrolls the window's top line to match <paramref name="line"/>.</para>
    /// </summary>
    public void ScrollToLine(int line)
    {
        NativeCalls.godot_icall_1_38(MethodBind75, GodotObject.GetPtr(this), line);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind76 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ScrollToParagraph, 1286410249ul);

    /// <summary>
    /// <para>Scrolls the window's top line to match first line of the <paramref name="paragraph"/>.</para>
    /// </summary>
    public void ScrollToParagraph(int paragraph)
    {
        NativeCalls.godot_icall_1_38(MethodBind76, GodotObject.GetPtr(this), paragraph);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind77 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ScrollToSelection, 3218959716ul);

    /// <summary>
    /// <para>Scrolls to the beginning of the current selection.</para>
    /// </summary>
    public void ScrollToSelection()
    {
        NativeCalls.godot_icall_0_3(MethodBind77, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind78 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTabSize, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTabSize(int spaces)
    {
        NativeCalls.godot_icall_1_38(MethodBind78, GodotObject.GetPtr(this), spaces);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind79 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTabSize, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetTabSize()
    {
        return NativeCalls.godot_icall_0_39(MethodBind79, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind80 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFitContent, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFitContent(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind80, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind81 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsFitContentEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsFitContentEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind81, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind82 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSelectionEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSelectionEnabled(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind82, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind83 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsSelectionEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsSelectionEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind83, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind84 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetContextMenuEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetContextMenuEnabled(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind84, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind85 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsContextMenuEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsContextMenuEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind85, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind86 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetShortcutKeysEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetShortcutKeysEnabled(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind86, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind87 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsShortcutKeysEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsShortcutKeysEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind87, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind88 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDeselectOnFocusLossEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDeselectOnFocusLossEnabled(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind88, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind89 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsDeselectOnFocusLossEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsDeselectOnFocusLossEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind89, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind90 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDragAndDropSelectionEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDragAndDropSelectionEnabled(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind90, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind91 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsDragAndDropSelectionEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsDragAndDropSelectionEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind91, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind92 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSelectionFrom, 3905245786ul);

    /// <summary>
    /// <para>Returns the current selection first character index if a selection is active, <c>-1</c> otherwise. Does not include BBCodes.</para>
    /// </summary>
    public int GetSelectionFrom()
    {
        return NativeCalls.godot_icall_0_39(MethodBind92, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind93 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSelectionTo, 3905245786ul);

    /// <summary>
    /// <para>Returns the current selection last character index if a selection is active, <c>-1</c> otherwise. Does not include BBCodes.</para>
    /// </summary>
    public int GetSelectionTo()
    {
        return NativeCalls.godot_icall_0_39(MethodBind93, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind94 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSelectionLineOffset, 1740695150ul);

    /// <summary>
    /// <para>Returns the current selection vertical line offset if a selection is active, <c>-1.0</c> otherwise.</para>
    /// </summary>
    public float GetSelectionLineOffset()
    {
        return NativeCalls.godot_icall_0_68(MethodBind94, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind95 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SelectAll, 3218959716ul);

    /// <summary>
    /// <para>Select all the text.</para>
    /// <para>If <see cref="Godot.RichTextLabel.SelectionEnabled"/> is <see langword="false"/>, no selection will occur.</para>
    /// </summary>
    public void SelectAll()
    {
        NativeCalls.godot_icall_0_3(MethodBind95, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind96 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSelectedText, 201670096ul);

    /// <summary>
    /// <para>Returns the current selection text. Does not include BBCodes.</para>
    /// </summary>
    public string GetSelectedText()
    {
        return NativeCalls.godot_icall_0_58(MethodBind96, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind97 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Deselect, 3218959716ul);

    /// <summary>
    /// <para>Clears the current selection.</para>
    /// </summary>
    public void Deselect()
    {
        NativeCalls.godot_icall_0_3(MethodBind97, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind98 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ParseBbcode, 83702148ul);

    /// <summary>
    /// <para>The assignment version of <see cref="Godot.RichTextLabel.AppendText(string)"/>. Clears the tag stack and inserts the new content.</para>
    /// </summary>
    public void ParseBbcode(string bbcode)
    {
        NativeCalls.godot_icall_1_57(MethodBind98, GodotObject.GetPtr(this), bbcode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind99 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AppendText, 83702148ul);

    /// <summary>
    /// <para>Parses <paramref name="bbcode"/> and adds tags to the tag stack as needed.</para>
    /// <para><b>Note:</b> Using this method, you can't close a tag that was opened in a previous <see cref="Godot.RichTextLabel.AppendText(string)"/> call. This is done to improve performance, especially when updating large RichTextLabels since rebuilding the whole BBCode every time would be slower. If you absolutely need to close a tag in a future method call, append the <see cref="Godot.RichTextLabel.Text"/> instead of using <see cref="Godot.RichTextLabel.AppendText(string)"/>.</para>
    /// </summary>
    public void AppendText(string bbcode)
    {
        NativeCalls.godot_icall_1_57(MethodBind99, GodotObject.GetPtr(this), bbcode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind100 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetText, 201670096ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetText()
    {
        return NativeCalls.godot_icall_0_58(MethodBind100, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind101 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsReady, 36873697ul);

    /// <summary>
    /// <para>If <see cref="Godot.RichTextLabel.Threaded"/> is enabled, returns <see langword="true"/> if the background thread has finished text processing, otherwise always return <see langword="true"/>.</para>
    /// </summary>
    [Obsolete("Use 'Godot.RichTextLabel.IsFinished()' instead.")]
    public bool IsReady()
    {
        return NativeCalls.godot_icall_0_15(MethodBind101, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind102 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsFinished, 36873697ul);

    /// <summary>
    /// <para>If <see cref="Godot.RichTextLabel.Threaded"/> is enabled, returns <see langword="true"/> if the background thread has finished text processing, otherwise always return <see langword="true"/>.</para>
    /// </summary>
    public bool IsFinished()
    {
        return NativeCalls.godot_icall_0_15(MethodBind102, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind103 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetThreaded, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetThreaded(bool threaded)
    {
        NativeCalls.godot_icall_1_14(MethodBind103, GodotObject.GetPtr(this), threaded.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind104 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsThreaded, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsThreaded()
    {
        return NativeCalls.godot_icall_0_15(MethodBind104, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind105 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetProgressBarDelay, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetProgressBarDelay(int delayMs)
    {
        NativeCalls.godot_icall_1_38(MethodBind105, GodotObject.GetPtr(this), delayMs);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind106 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetProgressBarDelay, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetProgressBarDelay()
    {
        return NativeCalls.godot_icall_0_39(MethodBind106, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind107 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVisibleCharacters, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetVisibleCharacters(int amount)
    {
        NativeCalls.godot_icall_1_38(MethodBind107, GodotObject.GetPtr(this), amount);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind108 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVisibleCharacters, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetVisibleCharacters()
    {
        return NativeCalls.godot_icall_0_39(MethodBind108, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind109 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVisibleCharactersBehavior, 258789322ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public TextServer.VisibleCharactersBehavior GetVisibleCharactersBehavior()
    {
        return (TextServer.VisibleCharactersBehavior)NativeCalls.godot_icall_0_39(MethodBind109, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind110 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVisibleCharactersBehavior, 3383839701ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetVisibleCharactersBehavior(TextServer.VisibleCharactersBehavior behavior)
    {
        NativeCalls.godot_icall_1_38(MethodBind110, GodotObject.GetPtr(this), (int)behavior);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind111 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVisibleRatio, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetVisibleRatio(float ratio)
    {
        NativeCalls.godot_icall_1_67(MethodBind111, GodotObject.GetPtr(this), ratio);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind112 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVisibleRatio, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetVisibleRatio()
    {
        return NativeCalls.godot_icall_0_68(MethodBind112, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind113 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCharacterLine, 3744713108ul);

    /// <summary>
    /// <para>Returns the line number of the character position provided. Line and character numbers are both zero-indexed.</para>
    /// <para><b>Note:</b> If <see cref="Godot.RichTextLabel.Threaded"/> is enabled, this method returns a value for the loaded part of the document. Use <see cref="Godot.RichTextLabel.IsFinished()"/> or <see cref="Godot.RichTextLabel.Finished"/> to determine whether document is fully loaded.</para>
    /// </summary>
    public int GetCharacterLine(int character)
    {
        return NativeCalls.godot_icall_1_60(MethodBind113, GodotObject.GetPtr(this), character);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind114 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCharacterParagraph, 3744713108ul);

    /// <summary>
    /// <para>Returns the paragraph number of the character position provided. Paragraph and character numbers are both zero-indexed.</para>
    /// <para><b>Note:</b> If <see cref="Godot.RichTextLabel.Threaded"/> is enabled, this method returns a value for the loaded part of the document. Use <see cref="Godot.RichTextLabel.IsFinished()"/> or <see cref="Godot.RichTextLabel.Finished"/> to determine whether document is fully loaded.</para>
    /// </summary>
    public int GetCharacterParagraph(int character)
    {
        return NativeCalls.godot_icall_1_60(MethodBind114, GodotObject.GetPtr(this), character);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind115 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTotalCharacterCount, 3905245786ul);

    /// <summary>
    /// <para>Returns the total number of characters from text tags. Does not include BBCodes.</para>
    /// </summary>
    public int GetTotalCharacterCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind115, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind116 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetUseBbcode, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetUseBbcode(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind116, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind117 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsUsingBbcode, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsUsingBbcode()
    {
        return NativeCalls.godot_icall_0_15(MethodBind117, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind118 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLineCount, 3905245786ul);

    /// <summary>
    /// <para>Returns the total number of lines in the text. Wrapped text is counted as multiple lines.</para>
    /// <para><b>Note:</b> If <see cref="Godot.RichTextLabel.Threaded"/> is enabled, this method returns a value for the loaded part of the document. Use <see cref="Godot.RichTextLabel.IsFinished()"/> or <see cref="Godot.RichTextLabel.Finished"/> to determine whether document is fully loaded.</para>
    /// </summary>
    public int GetLineCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind118, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind119 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLineRange, 3665014314ul);

    /// <summary>
    /// <para>Returns the indexes of the first and last visible characters for the given <paramref name="line"/>, as a <see cref="Godot.Vector2I"/>.</para>
    /// <para><b>Note:</b> If <see cref="Godot.RichTextLabel.VisibleCharactersBehavior"/> is set to <see cref="Godot.TextServer.VisibleCharactersBehavior.CharsBeforeShaping"/> only visible wrapped lines are counted.</para>
    /// <para><b>Note:</b> If <see cref="Godot.RichTextLabel.Threaded"/> is enabled, this method returns a value for the loaded part of the document. Use <see cref="Godot.RichTextLabel.IsFinished()"/> or <see cref="Godot.RichTextLabel.Finished"/> to determine whether document is fully loaded.</para>
    /// </summary>
    public Vector2I GetLineRange(int line)
    {
        return NativeCalls.godot_icall_1_405(MethodBind119, GodotObject.GetPtr(this), line);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind120 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVisibleLineCount, 3905245786ul);

    /// <summary>
    /// <para>Returns the number of visible lines.</para>
    /// <para><b>Note:</b> This method returns a correct value only after the label has been drawn.</para>
    /// <para><b>Note:</b> If <see cref="Godot.RichTextLabel.Threaded"/> is enabled, this method returns a value for the loaded part of the document. Use <see cref="Godot.RichTextLabel.IsFinished()"/> or <see cref="Godot.RichTextLabel.Finished"/> to determine whether document is fully loaded.</para>
    /// </summary>
    public int GetVisibleLineCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind120, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind121 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetParagraphCount, 3905245786ul);

    /// <summary>
    /// <para>Returns the total number of paragraphs (newlines or <c>p</c> tags in the tag stack's text tags). Considers wrapped text as one paragraph.</para>
    /// </summary>
    public int GetParagraphCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind121, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind122 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVisibleParagraphCount, 3905245786ul);

    /// <summary>
    /// <para>Returns the number of visible paragraphs. A paragraph is considered visible if at least one of its lines is visible.</para>
    /// <para><b>Note:</b> This method returns a correct value only after the label has been drawn.</para>
    /// <para><b>Note:</b> If <see cref="Godot.RichTextLabel.Threaded"/> is enabled, this method returns a value for the loaded part of the document. Use <see cref="Godot.RichTextLabel.IsFinished()"/> or <see cref="Godot.RichTextLabel.Finished"/> to determine whether document is fully loaded.</para>
    /// </summary>
    public int GetVisibleParagraphCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind122, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind123 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetContentHeight, 3905245786ul);

    /// <summary>
    /// <para>Returns the height of the content.</para>
    /// <para><b>Note:</b> This method always returns the full content size, and is not affected by <see cref="Godot.RichTextLabel.VisibleRatio"/> and <see cref="Godot.RichTextLabel.VisibleCharacters"/>. To get the visible content size, use <see cref="Godot.RichTextLabel.GetVisibleContentRect()"/>.</para>
    /// <para><b>Note:</b> If <see cref="Godot.RichTextLabel.Threaded"/> is enabled, this method returns a value for the loaded part of the document. Use <see cref="Godot.RichTextLabel.IsFinished()"/> or <see cref="Godot.RichTextLabel.Finished"/> to determine whether document is fully loaded.</para>
    /// </summary>
    public int GetContentHeight()
    {
        return NativeCalls.godot_icall_0_39(MethodBind123, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind124 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetContentWidth, 3905245786ul);

    /// <summary>
    /// <para>Returns the width of the content.</para>
    /// <para><b>Note:</b> This method always returns the full content size, and is not affected by <see cref="Godot.RichTextLabel.VisibleRatio"/> and <see cref="Godot.RichTextLabel.VisibleCharacters"/>. To get the visible content size, use <see cref="Godot.RichTextLabel.GetVisibleContentRect()"/>.</para>
    /// <para><b>Note:</b> If <see cref="Godot.RichTextLabel.Threaded"/> is enabled, this method returns a value for the loaded part of the document. Use <see cref="Godot.RichTextLabel.IsFinished()"/> or <see cref="Godot.RichTextLabel.Finished"/> to determine whether document is fully loaded.</para>
    /// </summary>
    public int GetContentWidth()
    {
        return NativeCalls.godot_icall_0_39(MethodBind124, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind125 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLineHeight, 923996154ul);

    /// <summary>
    /// <para>Returns the height of the line found at the provided index.</para>
    /// <para><b>Note:</b> If <see cref="Godot.RichTextLabel.Threaded"/> is enabled, this method returns a value for the loaded part of the document. Use <see cref="Godot.RichTextLabel.IsFinished()"/> or <see cref="Godot.RichTextLabel.Finished"/> to determine whether the document is fully loaded.</para>
    /// </summary>
    public int GetLineHeight(int line)
    {
        return NativeCalls.godot_icall_1_60(MethodBind125, GodotObject.GetPtr(this), line);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind126 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLineWidth, 923996154ul);

    /// <summary>
    /// <para>Returns the width of the line found at the provided index.</para>
    /// <para><b>Note:</b> If <see cref="Godot.RichTextLabel.Threaded"/> is enabled, this method returns a value for the loaded part of the document. Use <see cref="Godot.RichTextLabel.IsFinished()"/> or <see cref="Godot.RichTextLabel.Finished"/> to determine whether the document is fully loaded.</para>
    /// </summary>
    public int GetLineWidth(int line)
    {
        return NativeCalls.godot_icall_1_60(MethodBind126, GodotObject.GetPtr(this), line);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind127 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVisibleContentRect, 410525958ul);

    /// <summary>
    /// <para>Returns the bounding rectangle of the visible content.</para>
    /// <para><b>Note:</b> This method returns a correct value only after the label has been drawn.</para>
    /// <para><code>
    /// public partial class TestLabel : RichTextLabel
    /// {
    /// 	[Export]
    /// 	public Panel BackgroundPanel { get; set; }
    /// 
    /// 	public override async void _Ready()
    /// 	{
    /// 		await ToSignal(this, Control.SignalName.Draw);
    /// 		BackgroundGPanel.Position = GetVisibleContentRect().Position;
    /// 		BackgroundPanel.Size = GetVisibleContentRect().Size;
    /// 	}
    /// }
    /// </code></para>
    /// </summary>
    public Rect2I GetVisibleContentRect()
    {
        return NativeCalls.godot_icall_0_33(MethodBind127, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind128 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLineOffset, 4025615559ul);

    /// <summary>
    /// <para>Returns the vertical offset of the line found at the provided index.</para>
    /// <para><b>Note:</b> If <see cref="Godot.RichTextLabel.Threaded"/> is enabled, this method returns a value for the loaded part of the document. Use <see cref="Godot.RichTextLabel.IsFinished()"/> or <see cref="Godot.RichTextLabel.Finished"/> to determine whether document is fully loaded.</para>
    /// </summary>
    public float GetLineOffset(int line)
    {
        return NativeCalls.godot_icall_1_72(MethodBind128, GodotObject.GetPtr(this), line);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind129 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetParagraphOffset, 4025615559ul);

    /// <summary>
    /// <para>Returns the vertical offset of the paragraph found at the provided index.</para>
    /// <para><b>Note:</b> If <see cref="Godot.RichTextLabel.Threaded"/> is enabled, this method returns a value for the loaded part of the document. Use <see cref="Godot.RichTextLabel.IsFinished()"/> or <see cref="Godot.RichTextLabel.Finished"/> to determine whether document is fully loaded.</para>
    /// </summary>
    public float GetParagraphOffset(int paragraph)
    {
        return NativeCalls.godot_icall_1_72(MethodBind129, GodotObject.GetPtr(this), paragraph);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind130 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ParseExpressionsForValues, 1522900837ul);

    /// <summary>
    /// <para>Parses BBCode parameter <paramref name="expressions"/> into a dictionary.</para>
    /// </summary>
    public Godot.Collections.Dictionary ParseExpressionsForValues(string[] expressions)
    {
        return NativeCalls.godot_icall_1_1243(MethodBind130, GodotObject.GetPtr(this), expressions);
    }

    /// <summary>
    /// <para>Parses BBCode parameter <paramref name="expressions"/> into a dictionary.</para>
    /// </summary>
    public Godot.Collections.Dictionary ParseExpressionsForValues(ReadOnlySpan<string> expressions)
    {
        return NativeCalls.godot_icall_1_1243(MethodBind130, GodotObject.GetPtr(this), expressions);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind131 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEffects, 381264803ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEffects(Godot.Collections.Array effects)
    {
        NativeCalls.godot_icall_1_138(MethodBind131, GodotObject.GetPtr(this), (godot_array)(effects ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind132 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEffects, 2915620761ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Godot.Collections.Array GetEffects()
    {
        return NativeCalls.godot_icall_0_120(MethodBind132, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind133 = ClassDB_get_method_with_compatibility(NativeName, MethodName.InstallEffect, 1114965689ul);

    /// <summary>
    /// <para>Installs a custom effect. This can also be done in the Inspector through the <see cref="Godot.RichTextLabel.CustomEffects"/> property. <paramref name="effect"/> should be a valid <see cref="Godot.RichTextEffect"/>.</para>
    /// <para><b>Example:</b> With the following script extending from <see cref="Godot.RichTextEffect"/>:</para>
    /// <para><code>
    /// # effect.gd
    /// class_name MyCustomEffect
    /// extends RichTextEffect
    /// 
    /// var bbcode = "my_custom_effect"
    /// 
    /// # ...
    /// </code></para>
    /// <para>The above effect can be installed in <see cref="Godot.RichTextLabel"/> from a script:</para>
    /// <para><code>
    /// # rich_text_label.gd
    /// extends RichTextLabel
    /// 
    /// func _ready():
    /// 	install_effect(MyCustomEffect.new())
    /// 
    /// 	# Alternatively, if not using `class_name` in the script that extends RichTextEffect:
    /// 	install_effect(preload("res://effect.gd").new())
    /// </code></para>
    /// </summary>
    public void InstallEffect(Variant effect)
    {
        NativeCalls.godot_icall_1_773(MethodBind133, GodotObject.GetPtr(this), effect);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind134 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ReloadEffects, 3218959716ul);

    /// <summary>
    /// <para>Reloads custom effects. Useful when <see cref="Godot.RichTextLabel.CustomEffects"/> is modified manually.</para>
    /// </summary>
    public void ReloadEffects()
    {
        NativeCalls.godot_icall_0_3(MethodBind134, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind135 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMenu, 229722558ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.PopupMenu"/> of this <see cref="Godot.RichTextLabel"/>. By default, this menu is displayed when right-clicking on the <see cref="Godot.RichTextLabel"/>.</para>
    /// <para>You can add custom menu items or remove standard ones. Make sure your IDs don't conflict with the standard ones (see <see cref="Godot.RichTextLabel.MenuItems"/>). For example:</para>
    /// <para><code>
    /// public override void _Ready()
    /// {
    /// 	var menu = GetMenu();
    /// 	// Remove "Select All" item.
    /// 	menu.RemoveItem(RichTextLabel.MenuItems.SelectAll);
    /// 	// Add custom items.
    /// 	menu.AddSeparator();
    /// 	menu.AddItem("Duplicate Text", RichTextLabel.MenuItems.Max + 1);
    /// 	// Add event handler.
    /// 	menu.IdPressed += OnItemPressed;
    /// }
    /// 
    /// public void OnItemPressed(int id)
    /// {
    /// 	if (id == TextEdit.MenuItems.Max + 1)
    /// 	{
    /// 		AddText("\n" + GetParsedText());
    /// 	}
    /// }
    /// </code></para>
    /// <para><b>Warning:</b> This is a required internal node, removing and freeing it may cause a crash. If you wish to hide it or any of its children, use their <see cref="Godot.Window.Visible"/> property.</para>
    /// </summary>
    public PopupMenu GetMenu()
    {
        return (PopupMenu)NativeCalls.godot_icall_0_53(MethodBind135, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind136 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsMenuVisible, 36873697ul);

    /// <summary>
    /// <para>Returns whether the menu is visible. Use this instead of <c>get_menu().visible</c> to improve performance (so the creation of the menu is avoided).</para>
    /// </summary>
    public bool IsMenuVisible()
    {
        return NativeCalls.godot_icall_0_15(MethodBind136, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind137 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MenuOption, 1286410249ul);

    /// <summary>
    /// <para>Executes a given action as defined in the <see cref="Godot.RichTextLabel.MenuItems"/> enum.</para>
    /// </summary>
    public void MenuOption(int option)
    {
        NativeCalls.godot_icall_1_38(MethodBind137, GodotObject.GetPtr(this), option);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind138 = ClassDB_get_method_with_compatibility(NativeName, MethodName.UpdateImage, 815048486ul);

    /// <summary>
    /// <para>Updates the existing images with the key <paramref name="key"/>. Only properties specified by <paramref name="mask"/> bits are updated. See <see cref="Godot.RichTextLabel.AddImage(Texture2D, int, int, Nullable{Color}, InlineAlignment, Nullable{Rect2}, Variant, bool, string, bool, bool, string)"/>.</para>
    /// </summary>
    /// <param name="color">If the parameter is null, then the default value is <c>new Color(1.0f, 1.0f, 1.0f, 1.0f)</c>.</param>
    /// <param name="region">If the parameter is null, then the default value is <c>new Rect2(new Vector2(0.0f, 0.0f), new Vector2(0.0f, 0.0f))</c>.</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void UpdateImage(Variant key, RichTextLabel.ImageUpdateMask mask, Texture2D image, int width, int height, Nullable<Color> color, InlineAlignment inlineAlign, Nullable<Rect2> region, bool pad, string tooltip, bool sizeInPercent)
    {
        Color colorOrDefVal = color.HasValue ? color.Value : new Color(1.0f, 1.0f, 1.0f, 1.0f);
        Rect2 regionOrDefVal = region.HasValue ? region.Value : new Rect2(new Vector2(0.0f, 0.0f), new Vector2(0.0f, 0.0f));
        NativeCalls.godot_icall_11_1244(MethodBind138, GodotObject.GetPtr(this), key, (int)mask, GodotObject.GetPtr(image), width, height, &colorOrDefVal, (int)inlineAlign, &regionOrDefVal, pad.ToGodotBool(), tooltip, sizeInPercent.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind139 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddImage, 1389823276ul);

    /// <summary>
    /// <para>Adds an image's opening and closing tags to the tag stack, optionally providing a <paramref name="width"/> and <paramref name="height"/> to resize the image, a <paramref name="color"/> to tint the image and a <paramref name="region"/> to only use parts of the image.</para>
    /// <para>If <paramref name="width"/> or <paramref name="height"/> is set to 0, the image size will be adjusted in order to keep the original aspect ratio.</para>
    /// <para>If <paramref name="width"/> and <paramref name="height"/> are not set, but <paramref name="region"/> is, the region's rect will be used.</para>
    /// <para><paramref name="key"/> is an optional identifier, that can be used to modify the image via <see cref="Godot.RichTextLabel.UpdateImage(Variant, RichTextLabel.ImageUpdateMask, Texture2D, int, int, Nullable{Color}, InlineAlignment, Nullable{Rect2}, bool, string, bool, bool)"/>.</para>
    /// <para>If <paramref name="pad"/> is set, and the image is smaller than the size specified by <paramref name="width"/> and <paramref name="height"/>, the image padding is added to match the size instead of upscaling.</para>
    /// <para>If <paramref name="widthInPercent"/> is set, <paramref name="width"/> values are percentages of the control width instead of pixels.</para>
    /// <para>If <paramref name="heightInPercent"/> is set, <paramref name="height"/> values are percentages of the control width instead of pixels.</para>
    /// <para><paramref name="altText"/> is used as the image description for assistive apps.</para>
    /// </summary>
    /// <param name="color">If the parameter is null, then the default value is <c>new Color(1.0f, 1.0f, 1.0f, 1.0f)</c>.</param>
    /// <param name="region">If the parameter is null, then the default value is <c>new Rect2(new Vector2(0.0f, 0.0f), new Vector2(0.0f, 0.0f))</c>.</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void AddImage(Texture2D image, int width, int height, Nullable<Color> color, InlineAlignment inlineAlign, Nullable<Rect2> region, Variant key, bool pad, string tooltip, bool sizeInPercent, string altText)
    {
        Color colorOrDefVal = color.HasValue ? color.Value : new Color(1.0f, 1.0f, 1.0f, 1.0f);
        Rect2 regionOrDefVal = region.HasValue ? region.Value : new Rect2(new Vector2(0.0f, 0.0f), new Vector2(0.0f, 0.0f));
        NativeCalls.godot_icall_11_1245(MethodBind139, GodotObject.GetPtr(this), GodotObject.GetPtr(image), width, height, &colorOrDefVal, (int)inlineAlign, &regionOrDefVal, key, pad.ToGodotBool(), tooltip, sizeInPercent.ToGodotBool(), altText);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind140 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PushStrikethrough, 3218959716ul);

    /// <summary>
    /// <para>Adds a <c>[s]</c> tag to the tag stack. If <paramref name="color"/>'s alpha value is <c>0.0</c>, the current font's color with its alpha multiplied by <c>strikethrough_alpha</c> is used.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void PushStrikethrough()
    {
        NativeCalls.godot_icall_0_3(MethodBind140, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind141 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PushUnderline, 3218959716ul);

    /// <summary>
    /// <para>Adds a <c>[u]</c> tag to the tag stack. If <paramref name="color"/>'s alpha value is <c>0.0</c>, the current font's color with its alpha multiplied by <c>underline_alpha</c> is used.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void PushUnderline()
    {
        NativeCalls.godot_icall_0_3(MethodBind141, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind142 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveParagraph, 3067735520ul);

    /// <summary>
    /// <para>Removes a paragraph of content from the label. Returns <see langword="true"/> if the paragraph exists.</para>
    /// <para>The <paramref name="paragraph"/> argument is the index of the paragraph to remove, it can take values in the interval <c>[0, get_paragraph_count() - 1]</c>.</para>
    /// <para>If <paramref name="noInvalidate"/> is set to <see langword="true"/>, cache for the subsequent paragraphs is not invalidated. Use it for faster updates if deleted paragraph is fully self-contained (have no unclosed tags), or this call is part of the complex edit operation and <see cref="Godot.RichTextLabel.InvalidateParagraph(int)"/> will be called at the end of operation.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool RemoveParagraph(int paragraph)
    {
        return NativeCalls.godot_icall_1_62(MethodBind142, GodotObject.GetPtr(this), paragraph).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind143 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PushTable, 2623499273ul);

    /// <summary>
    /// <para>Adds a <c>[table=columns,inline_align]</c> tag to the tag stack. Use <see cref="Godot.RichTextLabel.SetTableColumnExpand(int, bool, int, bool)"/> to set column expansion ratio. Use <see cref="Godot.RichTextLabel.PushCell()"/> to add cells. <paramref name="name"/> is used as the table name for assistive apps.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void PushTable(int columns, InlineAlignment inlineAlign, int alignToRow)
    {
        NativeCalls.godot_icall_3_196(MethodBind143, GodotObject.GetPtr(this), columns, (int)inlineAlign, alignToRow);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind144 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddImage, 3017663154ul);

    /// <summary>
    /// <para>Adds an image's opening and closing tags to the tag stack, optionally providing a <paramref name="width"/> and <paramref name="height"/> to resize the image, a <paramref name="color"/> to tint the image and a <paramref name="region"/> to only use parts of the image.</para>
    /// <para>If <paramref name="width"/> or <paramref name="height"/> is set to 0, the image size will be adjusted in order to keep the original aspect ratio.</para>
    /// <para>If <paramref name="width"/> and <paramref name="height"/> are not set, but <paramref name="region"/> is, the region's rect will be used.</para>
    /// <para><paramref name="key"/> is an optional identifier, that can be used to modify the image via <see cref="Godot.RichTextLabel.UpdateImage(Variant, RichTextLabel.ImageUpdateMask, Texture2D, int, int, Nullable{Color}, InlineAlignment, Nullable{Rect2}, bool, string, bool, bool)"/>.</para>
    /// <para>If <paramref name="pad"/> is set, and the image is smaller than the size specified by <paramref name="width"/> and <paramref name="height"/>, the image padding is added to match the size instead of upscaling.</para>
    /// <para>If <paramref name="widthInPercent"/> is set, <paramref name="width"/> values are percentages of the control width instead of pixels.</para>
    /// <para>If <paramref name="heightInPercent"/> is set, <paramref name="height"/> values are percentages of the control width instead of pixels.</para>
    /// <para><paramref name="altText"/> is used as the image description for assistive apps.</para>
    /// </summary>
    /// <param name="color">If the parameter is null, then the default value is <c>new Color(1.0f, 1.0f, 1.0f, 1.0f)</c>.</param>
    /// <param name="region">If the parameter is null, then the default value is <c>new Rect2(new Vector2(0.0f, 0.0f), new Vector2(0.0f, 0.0f))</c>.</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void AddImage(Texture2D image, int width, int height, Nullable<Color> color, InlineAlignment inlineAlign, Nullable<Rect2> region, Variant key, bool pad, string tooltip, bool sizeInPercent)
    {
        Color colorOrDefVal = color.HasValue ? color.Value : new Color(1.0f, 1.0f, 1.0f, 1.0f);
        Rect2 regionOrDefVal = region.HasValue ? region.Value : new Rect2(new Vector2(0.0f, 0.0f), new Vector2(0.0f, 0.0f));
        NativeCalls.godot_icall_10_1246(MethodBind144, GodotObject.GetPtr(this), GodotObject.GetPtr(image), width, height, &colorOrDefVal, (int)inlineAlign, &regionOrDefVal, key, pad.ToGodotBool(), tooltip, sizeInPercent.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind145 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddImage, 3580801207ul);

    /// <summary>
    /// <para>Adds an image's opening and closing tags to the tag stack, optionally providing a <paramref name="width"/> and <paramref name="height"/> to resize the image, a <paramref name="color"/> to tint the image and a <paramref name="region"/> to only use parts of the image.</para>
    /// <para>If <paramref name="width"/> or <paramref name="height"/> is set to 0, the image size will be adjusted in order to keep the original aspect ratio.</para>
    /// <para>If <paramref name="width"/> and <paramref name="height"/> are not set, but <paramref name="region"/> is, the region's rect will be used.</para>
    /// <para><paramref name="key"/> is an optional identifier, that can be used to modify the image via <see cref="Godot.RichTextLabel.UpdateImage(Variant, RichTextLabel.ImageUpdateMask, Texture2D, int, int, Nullable{Color}, InlineAlignment, Nullable{Rect2}, bool, string, bool, bool)"/>.</para>
    /// <para>If <paramref name="pad"/> is set, and the image is smaller than the size specified by <paramref name="width"/> and <paramref name="height"/>, the image padding is added to match the size instead of upscaling.</para>
    /// <para>If <paramref name="widthInPercent"/> is set, <paramref name="width"/> values are percentages of the control width instead of pixels.</para>
    /// <para>If <paramref name="heightInPercent"/> is set, <paramref name="height"/> values are percentages of the control width instead of pixels.</para>
    /// <para><paramref name="altText"/> is used as the image description for assistive apps.</para>
    /// </summary>
    /// <param name="color">If the parameter is null, then the default value is <c>new Color(1.0f, 1.0f, 1.0f, 1.0f)</c>.</param>
    /// <param name="region">If the parameter is null, then the default value is <c>new Rect2(new Vector2(0.0f, 0.0f), new Vector2(0.0f, 0.0f))</c>.</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void AddImage(Texture2D image, int width, int height, Nullable<Color> color, InlineAlignment inlineAlign, Nullable<Rect2> region)
    {
        Color colorOrDefVal = color.HasValue ? color.Value : new Color(1.0f, 1.0f, 1.0f, 1.0f);
        Rect2 regionOrDefVal = region.HasValue ? region.Value : new Rect2(new Vector2(0.0f, 0.0f), new Vector2(0.0f, 0.0f));
        NativeCalls.godot_icall_6_1247(MethodBind145, GodotObject.GetPtr(this), GodotObject.GetPtr(image), width, height, &colorOrDefVal, (int)inlineAlign, &regionOrDefVal);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind146 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PushMeta, 1114965689ul);

    /// <summary>
    /// <para>Adds a meta tag to the tag stack. Similar to the BBCode <c>[url=something]{text}[/url]</c>, but supports non-<see cref="string"/> metadata types.</para>
    /// <para>If <see cref="Godot.RichTextLabel.MetaUnderlined"/> is <see langword="true"/>, meta tags display an underline. This behavior can be customized with <paramref name="underlineMode"/>.</para>
    /// <para><b>Note:</b> Meta tags do nothing by default when clicked. To assign behavior when clicked, connect <see cref="Godot.RichTextLabel.MetaClicked"/> to a function that is called when the meta tag is clicked.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void PushMeta(Variant data)
    {
        NativeCalls.godot_icall_1_773(MethodBind146, GodotObject.GetPtr(this), data);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind147 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PushMeta, 2206155733ul);

    /// <summary>
    /// <para>Adds a meta tag to the tag stack. Similar to the BBCode <c>[url=something]{text}[/url]</c>, but supports non-<see cref="string"/> metadata types.</para>
    /// <para>If <see cref="Godot.RichTextLabel.MetaUnderlined"/> is <see langword="true"/>, meta tags display an underline. This behavior can be customized with <paramref name="underlineMode"/>.</para>
    /// <para><b>Note:</b> Meta tags do nothing by default when clicked. To assign behavior when clicked, connect <see cref="Godot.RichTextLabel.MetaClicked"/> to a function that is called when the meta tag is clicked.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void PushMeta(Variant data, RichTextLabel.MetaUnderline underlineMode)
    {
        NativeCalls.godot_icall_2_1248(MethodBind147, GodotObject.GetPtr(this), data, (int)underlineMode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind148 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTableColumnExpand, 2185176273ul);

    /// <summary>
    /// <para>Edits the selected column's expansion options. If <paramref name="expand"/> is <see langword="true"/>, the column expands in proportion to its expansion ratio versus the other columns' ratios.</para>
    /// <para>For example, 2 columns with ratios 3 and 4 plus 70 pixels in available width would expand 30 and 40 pixels, respectively.</para>
    /// <para>If <paramref name="expand"/> is <see langword="false"/>, the column will not contribute to the total ratio.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTableColumnExpand(int column, bool expand, int ratio)
    {
        NativeCalls.godot_icall_3_415(MethodBind148, GodotObject.GetPtr(this), column, expand.ToGodotBool(), ratio);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.RichTextLabel.MetaClicked"/> event of a <see cref="Godot.RichTextLabel"/> class.
    /// </summary>
    public delegate void MetaClickedEventHandler(Variant meta);

    private static void MetaClickedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((MetaClickedEventHandler)delegateObj)(VariantUtils.ConvertTo<Variant>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Triggered when the user clicks on content between meta (URL) tags. If the meta is defined in BBCode, e.g. <c>[url={"key": "value"}]Text[/url]</c>, then the parameter for this signal will always be a <see cref="string"/> type. If a particular type or an object is desired, the <see cref="Godot.RichTextLabel.PushMeta(Variant, RichTextLabel.MetaUnderline, string)"/> method must be used to manually insert the data into the tag stack. Alternatively, you can convert the <see cref="string"/> input to the desired type based on its contents (such as calling <see cref="Godot.Json.Parse(string, bool)"/> on it).</para>
    /// <para>For example, the following method can be connected to <see cref="Godot.RichTextLabel.MetaClicked"/> to open clicked URLs using the user's default web browser:</para>
    /// <para></para>
    /// </summary>
    public unsafe event MetaClickedEventHandler MetaClicked
    {
        add => Connect(SignalName.MetaClicked, Callable.CreateWithUnsafeTrampoline(value, &MetaClickedTrampoline));
        remove => Disconnect(SignalName.MetaClicked, Callable.CreateWithUnsafeTrampoline(value, &MetaClickedTrampoline));
    }

    protected void EmitSignalMetaClicked(Variant meta)
    {
        EmitSignal(SignalName.MetaClicked, meta);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.RichTextLabel.MetaHoverStarted"/> event of a <see cref="Godot.RichTextLabel"/> class.
    /// </summary>
    public delegate void MetaHoverStartedEventHandler(Variant meta);

    private static void MetaHoverStartedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((MetaHoverStartedEventHandler)delegateObj)(VariantUtils.ConvertTo<Variant>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Triggers when the mouse enters a meta tag.</para>
    /// </summary>
    public unsafe event MetaHoverStartedEventHandler MetaHoverStarted
    {
        add => Connect(SignalName.MetaHoverStarted, Callable.CreateWithUnsafeTrampoline(value, &MetaHoverStartedTrampoline));
        remove => Disconnect(SignalName.MetaHoverStarted, Callable.CreateWithUnsafeTrampoline(value, &MetaHoverStartedTrampoline));
    }

    protected void EmitSignalMetaHoverStarted(Variant meta)
    {
        EmitSignal(SignalName.MetaHoverStarted, meta);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.RichTextLabel.MetaHoverEnded"/> event of a <see cref="Godot.RichTextLabel"/> class.
    /// </summary>
    public delegate void MetaHoverEndedEventHandler(Variant meta);

    private static void MetaHoverEndedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((MetaHoverEndedEventHandler)delegateObj)(VariantUtils.ConvertTo<Variant>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Triggers when the mouse exits a meta tag.</para>
    /// </summary>
    public unsafe event MetaHoverEndedEventHandler MetaHoverEnded
    {
        add => Connect(SignalName.MetaHoverEnded, Callable.CreateWithUnsafeTrampoline(value, &MetaHoverEndedTrampoline));
        remove => Disconnect(SignalName.MetaHoverEnded, Callable.CreateWithUnsafeTrampoline(value, &MetaHoverEndedTrampoline));
    }

    protected void EmitSignalMetaHoverEnded(Variant meta)
    {
        EmitSignal(SignalName.MetaHoverEnded, meta);
    }

    /// <summary>
    /// <para>Triggered when the document is fully loaded.</para>
    /// <para><b>Note:</b> This can happen before the text is processed for drawing. Scrolling values may not be valid until the document is drawn for the first time after this signal.</para>
    /// </summary>
    public event Action Finished
    {
        add => Connect(SignalName.Finished, Callable.From(value));
        remove => Disconnect(SignalName.Finished, Callable.From(value));
    }

    protected void EmitSignalFinished()
    {
        EmitSignal(SignalName.Finished);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_meta_clicked = "MetaClicked";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_meta_hover_started = "MetaHoverStarted";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_meta_hover_ended = "MetaHoverEnded";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_finished = "Finished";

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
        if (signal == SignalName.MetaClicked)
        {
            if (HasGodotClassSignal(SignalProxyName_meta_clicked.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.MetaHoverStarted)
        {
            if (HasGodotClassSignal(SignalProxyName_meta_hover_started.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.MetaHoverEnded)
        {
            if (HasGodotClassSignal(SignalProxyName_meta_hover_ended.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.Finished)
        {
            if (HasGodotClassSignal(SignalProxyName_finished.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        return base.HasGodotClassSignal(signal);
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : Control.PropertyName
    {
        /// <summary>
        /// Cached name for the 'bbcode_enabled' property.
        /// </summary>
        public static readonly StringName BbcodeEnabled = "bbcode_enabled";
        /// <summary>
        /// Cached name for the 'text' property.
        /// </summary>
        public static readonly StringName Text = "text";
        /// <summary>
        /// Cached name for the 'fit_content' property.
        /// </summary>
        public static readonly StringName FitContent = "fit_content";
        /// <summary>
        /// Cached name for the 'scroll_active' property.
        /// </summary>
        public static readonly StringName ScrollActive = "scroll_active";
        /// <summary>
        /// Cached name for the 'scroll_following' property.
        /// </summary>
        public static readonly StringName ScrollFollowing = "scroll_following";
        /// <summary>
        /// Cached name for the 'scroll_following_visible_characters' property.
        /// </summary>
        public static readonly StringName ScrollFollowingVisibleCharacters = "scroll_following_visible_characters";
        /// <summary>
        /// Cached name for the 'autowrap_mode' property.
        /// </summary>
        public static readonly StringName AutowrapMode = "autowrap_mode";
        /// <summary>
        /// Cached name for the 'autowrap_trim_flags' property.
        /// </summary>
        public static readonly StringName AutowrapTrimFlags = "autowrap_trim_flags";
        /// <summary>
        /// Cached name for the 'tab_size' property.
        /// </summary>
        public static readonly StringName TabSize = "tab_size";
        /// <summary>
        /// Cached name for the 'context_menu_enabled' property.
        /// </summary>
        public static readonly StringName ContextMenuEnabled = "context_menu_enabled";
        /// <summary>
        /// Cached name for the 'shortcut_keys_enabled' property.
        /// </summary>
        public static readonly StringName ShortcutKeysEnabled = "shortcut_keys_enabled";
        /// <summary>
        /// Cached name for the 'horizontal_alignment' property.
        /// </summary>
        public static readonly StringName HorizontalAlignment = "horizontal_alignment";
        /// <summary>
        /// Cached name for the 'vertical_alignment' property.
        /// </summary>
        public static readonly StringName VerticalAlignment = "vertical_alignment";
        /// <summary>
        /// Cached name for the 'justification_flags' property.
        /// </summary>
        public static readonly StringName JustificationFlags = "justification_flags";
        /// <summary>
        /// Cached name for the 'tab_stops' property.
        /// </summary>
        public static readonly StringName TabStops = "tab_stops";
        /// <summary>
        /// Cached name for the 'custom_effects' property.
        /// </summary>
        public static readonly StringName CustomEffects = "custom_effects";
        /// <summary>
        /// Cached name for the 'meta_underlined' property.
        /// </summary>
        public static readonly StringName MetaUnderlined = "meta_underlined";
        /// <summary>
        /// Cached name for the 'hint_underlined' property.
        /// </summary>
        public static readonly StringName HintUnderlined = "hint_underlined";
        /// <summary>
        /// Cached name for the 'threaded' property.
        /// </summary>
        public static readonly StringName Threaded = "threaded";
        /// <summary>
        /// Cached name for the 'progress_bar_delay' property.
        /// </summary>
        public static readonly StringName ProgressBarDelay = "progress_bar_delay";
        /// <summary>
        /// Cached name for the 'selection_enabled' property.
        /// </summary>
        public static readonly StringName SelectionEnabled = "selection_enabled";
        /// <summary>
        /// Cached name for the 'deselect_on_focus_loss_enabled' property.
        /// </summary>
        public static readonly StringName DeselectOnFocusLossEnabled = "deselect_on_focus_loss_enabled";
        /// <summary>
        /// Cached name for the 'drag_and_drop_selection_enabled' property.
        /// </summary>
        public static readonly StringName DragAndDropSelectionEnabled = "drag_and_drop_selection_enabled";
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
        /// Cached name for the 'get_parsed_text' method.
        /// </summary>
        public static readonly StringName GetParsedText = "get_parsed_text";
        /// <summary>
        /// Cached name for the 'add_text' method.
        /// </summary>
        public static readonly StringName AddText = "add_text";
        /// <summary>
        /// Cached name for the 'set_text' method.
        /// </summary>
        public static readonly StringName SetText = "set_text";
        /// <summary>
        /// Cached name for the 'add_hr' method.
        /// </summary>
        public static readonly StringName AddHr = "add_hr";
        /// <summary>
        /// Cached name for the 'add_image' method.
        /// </summary>
        public static readonly StringName AddImage = "add_image";
        /// <summary>
        /// Cached name for the 'update_image' method.
        /// </summary>
        public static readonly StringName UpdateImage = "update_image";
        /// <summary>
        /// Cached name for the 'newline' method.
        /// </summary>
        public static readonly StringName Newline = "newline";
        /// <summary>
        /// Cached name for the 'remove_paragraph' method.
        /// </summary>
        public static readonly StringName RemoveParagraph = "remove_paragraph";
        /// <summary>
        /// Cached name for the 'invalidate_paragraph' method.
        /// </summary>
        public static readonly StringName InvalidateParagraph = "invalidate_paragraph";
        /// <summary>
        /// Cached name for the 'push_font' method.
        /// </summary>
        public static readonly StringName PushFont = "push_font";
        /// <summary>
        /// Cached name for the 'push_font_size' method.
        /// </summary>
        public static readonly StringName PushFontSize = "push_font_size";
        /// <summary>
        /// Cached name for the 'push_normal' method.
        /// </summary>
        public static readonly StringName PushNormal = "push_normal";
        /// <summary>
        /// Cached name for the 'push_bold' method.
        /// </summary>
        public static readonly StringName PushBold = "push_bold";
        /// <summary>
        /// Cached name for the 'push_bold_italics' method.
        /// </summary>
        public static readonly StringName PushBoldItalics = "push_bold_italics";
        /// <summary>
        /// Cached name for the 'push_italics' method.
        /// </summary>
        public static readonly StringName PushItalics = "push_italics";
        /// <summary>
        /// Cached name for the 'push_mono' method.
        /// </summary>
        public static readonly StringName PushMono = "push_mono";
        /// <summary>
        /// Cached name for the 'push_color' method.
        /// </summary>
        public static readonly StringName PushColor = "push_color";
        /// <summary>
        /// Cached name for the 'push_outline_size' method.
        /// </summary>
        public static readonly StringName PushOutlineSize = "push_outline_size";
        /// <summary>
        /// Cached name for the 'push_outline_color' method.
        /// </summary>
        public static readonly StringName PushOutlineColor = "push_outline_color";
        /// <summary>
        /// Cached name for the 'push_paragraph' method.
        /// </summary>
        public static readonly StringName PushParagraph = "push_paragraph";
        /// <summary>
        /// Cached name for the 'push_indent' method.
        /// </summary>
        public static readonly StringName PushIndent = "push_indent";
        /// <summary>
        /// Cached name for the 'push_list' method.
        /// </summary>
        public static readonly StringName PushList = "push_list";
        /// <summary>
        /// Cached name for the 'push_meta' method.
        /// </summary>
        public static readonly StringName PushMeta = "push_meta";
        /// <summary>
        /// Cached name for the 'push_hint' method.
        /// </summary>
        public static readonly StringName PushHint = "push_hint";
        /// <summary>
        /// Cached name for the 'push_language' method.
        /// </summary>
        public static readonly StringName PushLanguage = "push_language";
        /// <summary>
        /// Cached name for the 'push_underline' method.
        /// </summary>
        public static readonly StringName PushUnderline = "push_underline";
        /// <summary>
        /// Cached name for the 'push_strikethrough' method.
        /// </summary>
        public static readonly StringName PushStrikethrough = "push_strikethrough";
        /// <summary>
        /// Cached name for the 'push_table' method.
        /// </summary>
        public static readonly StringName PushTable = "push_table";
        /// <summary>
        /// Cached name for the 'push_dropcap' method.
        /// </summary>
        public static readonly StringName PushDropcap = "push_dropcap";
        /// <summary>
        /// Cached name for the 'set_table_column_expand' method.
        /// </summary>
        public static readonly StringName SetTableColumnExpand = "set_table_column_expand";
        /// <summary>
        /// Cached name for the 'set_table_column_name' method.
        /// </summary>
        public static readonly StringName SetTableColumnName = "set_table_column_name";
        /// <summary>
        /// Cached name for the 'set_cell_row_background_color' method.
        /// </summary>
        public static readonly StringName SetCellRowBackgroundColor = "set_cell_row_background_color";
        /// <summary>
        /// Cached name for the 'set_cell_border_color' method.
        /// </summary>
        public static readonly StringName SetCellBorderColor = "set_cell_border_color";
        /// <summary>
        /// Cached name for the 'set_cell_size_override' method.
        /// </summary>
        public static readonly StringName SetCellSizeOverride = "set_cell_size_override";
        /// <summary>
        /// Cached name for the 'set_cell_padding' method.
        /// </summary>
        public static readonly StringName SetCellPadding = "set_cell_padding";
        /// <summary>
        /// Cached name for the 'push_cell' method.
        /// </summary>
        public static readonly StringName PushCell = "push_cell";
        /// <summary>
        /// Cached name for the 'push_fgcolor' method.
        /// </summary>
        public static readonly StringName PushFgcolor = "push_fgcolor";
        /// <summary>
        /// Cached name for the 'push_bgcolor' method.
        /// </summary>
        public static readonly StringName PushBgcolor = "push_bgcolor";
        /// <summary>
        /// Cached name for the 'push_customfx' method.
        /// </summary>
        public static readonly StringName PushCustomfx = "push_customfx";
        /// <summary>
        /// Cached name for the 'push_context' method.
        /// </summary>
        public static readonly StringName PushContext = "push_context";
        /// <summary>
        /// Cached name for the 'pop_context' method.
        /// </summary>
        public static readonly StringName PopContext = "pop_context";
        /// <summary>
        /// Cached name for the 'pop' method.
        /// </summary>
        public static readonly StringName Pop = "pop";
        /// <summary>
        /// Cached name for the 'pop_all' method.
        /// </summary>
        public static readonly StringName PopAll = "pop_all";
        /// <summary>
        /// Cached name for the 'clear' method.
        /// </summary>
        public static readonly StringName Clear = "clear";
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
        /// Cached name for the 'set_justification_flags' method.
        /// </summary>
        public static readonly StringName SetJustificationFlags = "set_justification_flags";
        /// <summary>
        /// Cached name for the 'get_justification_flags' method.
        /// </summary>
        public static readonly StringName GetJustificationFlags = "get_justification_flags";
        /// <summary>
        /// Cached name for the 'set_tab_stops' method.
        /// </summary>
        public static readonly StringName SetTabStops = "set_tab_stops";
        /// <summary>
        /// Cached name for the 'get_tab_stops' method.
        /// </summary>
        public static readonly StringName GetTabStops = "get_tab_stops";
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
        /// Cached name for the 'set_meta_underline' method.
        /// </summary>
        public static readonly StringName SetMetaUnderline = "set_meta_underline";
        /// <summary>
        /// Cached name for the 'is_meta_underlined' method.
        /// </summary>
        public static readonly StringName IsMetaUnderlined = "is_meta_underlined";
        /// <summary>
        /// Cached name for the 'set_hint_underline' method.
        /// </summary>
        public static readonly StringName SetHintUnderline = "set_hint_underline";
        /// <summary>
        /// Cached name for the 'is_hint_underlined' method.
        /// </summary>
        public static readonly StringName IsHintUnderlined = "is_hint_underlined";
        /// <summary>
        /// Cached name for the 'set_scroll_active' method.
        /// </summary>
        public static readonly StringName SetScrollActive = "set_scroll_active";
        /// <summary>
        /// Cached name for the 'is_scroll_active' method.
        /// </summary>
        public static readonly StringName IsScrollActive = "is_scroll_active";
        /// <summary>
        /// Cached name for the 'set_scroll_follow_visible_characters' method.
        /// </summary>
        public static readonly StringName SetScrollFollowVisibleCharacters = "set_scroll_follow_visible_characters";
        /// <summary>
        /// Cached name for the 'is_scroll_following_visible_characters' method.
        /// </summary>
        public static readonly StringName IsScrollFollowingVisibleCharacters = "is_scroll_following_visible_characters";
        /// <summary>
        /// Cached name for the 'set_scroll_follow' method.
        /// </summary>
        public static readonly StringName SetScrollFollow = "set_scroll_follow";
        /// <summary>
        /// Cached name for the 'is_scroll_following' method.
        /// </summary>
        public static readonly StringName IsScrollFollowing = "is_scroll_following";
        /// <summary>
        /// Cached name for the 'get_v_scroll_bar' method.
        /// </summary>
        public static readonly StringName GetVScrollBar = "get_v_scroll_bar";
        /// <summary>
        /// Cached name for the 'scroll_to_line' method.
        /// </summary>
        public static readonly StringName ScrollToLine = "scroll_to_line";
        /// <summary>
        /// Cached name for the 'scroll_to_paragraph' method.
        /// </summary>
        public static readonly StringName ScrollToParagraph = "scroll_to_paragraph";
        /// <summary>
        /// Cached name for the 'scroll_to_selection' method.
        /// </summary>
        public static readonly StringName ScrollToSelection = "scroll_to_selection";
        /// <summary>
        /// Cached name for the 'set_tab_size' method.
        /// </summary>
        public static readonly StringName SetTabSize = "set_tab_size";
        /// <summary>
        /// Cached name for the 'get_tab_size' method.
        /// </summary>
        public static readonly StringName GetTabSize = "get_tab_size";
        /// <summary>
        /// Cached name for the 'set_fit_content' method.
        /// </summary>
        public static readonly StringName SetFitContent = "set_fit_content";
        /// <summary>
        /// Cached name for the 'is_fit_content_enabled' method.
        /// </summary>
        public static readonly StringName IsFitContentEnabled = "is_fit_content_enabled";
        /// <summary>
        /// Cached name for the 'set_selection_enabled' method.
        /// </summary>
        public static readonly StringName SetSelectionEnabled = "set_selection_enabled";
        /// <summary>
        /// Cached name for the 'is_selection_enabled' method.
        /// </summary>
        public static readonly StringName IsSelectionEnabled = "is_selection_enabled";
        /// <summary>
        /// Cached name for the 'set_context_menu_enabled' method.
        /// </summary>
        public static readonly StringName SetContextMenuEnabled = "set_context_menu_enabled";
        /// <summary>
        /// Cached name for the 'is_context_menu_enabled' method.
        /// </summary>
        public static readonly StringName IsContextMenuEnabled = "is_context_menu_enabled";
        /// <summary>
        /// Cached name for the 'set_shortcut_keys_enabled' method.
        /// </summary>
        public static readonly StringName SetShortcutKeysEnabled = "set_shortcut_keys_enabled";
        /// <summary>
        /// Cached name for the 'is_shortcut_keys_enabled' method.
        /// </summary>
        public static readonly StringName IsShortcutKeysEnabled = "is_shortcut_keys_enabled";
        /// <summary>
        /// Cached name for the 'set_deselect_on_focus_loss_enabled' method.
        /// </summary>
        public static readonly StringName SetDeselectOnFocusLossEnabled = "set_deselect_on_focus_loss_enabled";
        /// <summary>
        /// Cached name for the 'is_deselect_on_focus_loss_enabled' method.
        /// </summary>
        public static readonly StringName IsDeselectOnFocusLossEnabled = "is_deselect_on_focus_loss_enabled";
        /// <summary>
        /// Cached name for the 'set_drag_and_drop_selection_enabled' method.
        /// </summary>
        public static readonly StringName SetDragAndDropSelectionEnabled = "set_drag_and_drop_selection_enabled";
        /// <summary>
        /// Cached name for the 'is_drag_and_drop_selection_enabled' method.
        /// </summary>
        public static readonly StringName IsDragAndDropSelectionEnabled = "is_drag_and_drop_selection_enabled";
        /// <summary>
        /// Cached name for the 'get_selection_from' method.
        /// </summary>
        public static readonly StringName GetSelectionFrom = "get_selection_from";
        /// <summary>
        /// Cached name for the 'get_selection_to' method.
        /// </summary>
        public static readonly StringName GetSelectionTo = "get_selection_to";
        /// <summary>
        /// Cached name for the 'get_selection_line_offset' method.
        /// </summary>
        public static readonly StringName GetSelectionLineOffset = "get_selection_line_offset";
        /// <summary>
        /// Cached name for the 'select_all' method.
        /// </summary>
        public static readonly StringName SelectAll = "select_all";
        /// <summary>
        /// Cached name for the 'get_selected_text' method.
        /// </summary>
        public static readonly StringName GetSelectedText = "get_selected_text";
        /// <summary>
        /// Cached name for the 'deselect' method.
        /// </summary>
        public static readonly StringName Deselect = "deselect";
        /// <summary>
        /// Cached name for the 'parse_bbcode' method.
        /// </summary>
        public static readonly StringName ParseBbcode = "parse_bbcode";
        /// <summary>
        /// Cached name for the 'append_text' method.
        /// </summary>
        public static readonly StringName AppendText = "append_text";
        /// <summary>
        /// Cached name for the 'get_text' method.
        /// </summary>
        public static readonly StringName GetText = "get_text";
        /// <summary>
        /// Cached name for the 'is_ready' method.
        /// </summary>
        public static readonly StringName IsReady = "is_ready";
        /// <summary>
        /// Cached name for the 'is_finished' method.
        /// </summary>
        public static readonly StringName IsFinished = "is_finished";
        /// <summary>
        /// Cached name for the 'set_threaded' method.
        /// </summary>
        public static readonly StringName SetThreaded = "set_threaded";
        /// <summary>
        /// Cached name for the 'is_threaded' method.
        /// </summary>
        public static readonly StringName IsThreaded = "is_threaded";
        /// <summary>
        /// Cached name for the 'set_progress_bar_delay' method.
        /// </summary>
        public static readonly StringName SetProgressBarDelay = "set_progress_bar_delay";
        /// <summary>
        /// Cached name for the 'get_progress_bar_delay' method.
        /// </summary>
        public static readonly StringName GetProgressBarDelay = "get_progress_bar_delay";
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
        /// Cached name for the 'get_character_line' method.
        /// </summary>
        public static readonly StringName GetCharacterLine = "get_character_line";
        /// <summary>
        /// Cached name for the 'get_character_paragraph' method.
        /// </summary>
        public static readonly StringName GetCharacterParagraph = "get_character_paragraph";
        /// <summary>
        /// Cached name for the 'get_total_character_count' method.
        /// </summary>
        public static readonly StringName GetTotalCharacterCount = "get_total_character_count";
        /// <summary>
        /// Cached name for the 'set_use_bbcode' method.
        /// </summary>
        public static readonly StringName SetUseBbcode = "set_use_bbcode";
        /// <summary>
        /// Cached name for the 'is_using_bbcode' method.
        /// </summary>
        public static readonly StringName IsUsingBbcode = "is_using_bbcode";
        /// <summary>
        /// Cached name for the 'get_line_count' method.
        /// </summary>
        public static readonly StringName GetLineCount = "get_line_count";
        /// <summary>
        /// Cached name for the 'get_line_range' method.
        /// </summary>
        public static readonly StringName GetLineRange = "get_line_range";
        /// <summary>
        /// Cached name for the 'get_visible_line_count' method.
        /// </summary>
        public static readonly StringName GetVisibleLineCount = "get_visible_line_count";
        /// <summary>
        /// Cached name for the 'get_paragraph_count' method.
        /// </summary>
        public static readonly StringName GetParagraphCount = "get_paragraph_count";
        /// <summary>
        /// Cached name for the 'get_visible_paragraph_count' method.
        /// </summary>
        public static readonly StringName GetVisibleParagraphCount = "get_visible_paragraph_count";
        /// <summary>
        /// Cached name for the 'get_content_height' method.
        /// </summary>
        public static readonly StringName GetContentHeight = "get_content_height";
        /// <summary>
        /// Cached name for the 'get_content_width' method.
        /// </summary>
        public static readonly StringName GetContentWidth = "get_content_width";
        /// <summary>
        /// Cached name for the 'get_line_height' method.
        /// </summary>
        public static readonly StringName GetLineHeight = "get_line_height";
        /// <summary>
        /// Cached name for the 'get_line_width' method.
        /// </summary>
        public static readonly StringName GetLineWidth = "get_line_width";
        /// <summary>
        /// Cached name for the 'get_visible_content_rect' method.
        /// </summary>
        public static readonly StringName GetVisibleContentRect = "get_visible_content_rect";
        /// <summary>
        /// Cached name for the 'get_line_offset' method.
        /// </summary>
        public static readonly StringName GetLineOffset = "get_line_offset";
        /// <summary>
        /// Cached name for the 'get_paragraph_offset' method.
        /// </summary>
        public static readonly StringName GetParagraphOffset = "get_paragraph_offset";
        /// <summary>
        /// Cached name for the 'parse_expressions_for_values' method.
        /// </summary>
        public static readonly StringName ParseExpressionsForValues = "parse_expressions_for_values";
        /// <summary>
        /// Cached name for the 'set_effects' method.
        /// </summary>
        public static readonly StringName SetEffects = "set_effects";
        /// <summary>
        /// Cached name for the 'get_effects' method.
        /// </summary>
        public static readonly StringName GetEffects = "get_effects";
        /// <summary>
        /// Cached name for the 'install_effect' method.
        /// </summary>
        public static readonly StringName InstallEffect = "install_effect";
        /// <summary>
        /// Cached name for the 'reload_effects' method.
        /// </summary>
        public static readonly StringName ReloadEffects = "reload_effects";
        /// <summary>
        /// Cached name for the 'get_menu' method.
        /// </summary>
        public static readonly StringName GetMenu = "get_menu";
        /// <summary>
        /// Cached name for the 'is_menu_visible' method.
        /// </summary>
        public static readonly StringName IsMenuVisible = "is_menu_visible";
        /// <summary>
        /// Cached name for the 'menu_option' method.
        /// </summary>
        public static readonly StringName MenuOption = "menu_option";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Control.SignalName
    {
        /// <summary>
        /// Cached name for the 'meta_clicked' signal.
        /// </summary>
        public static readonly StringName MetaClicked = "meta_clicked";
        /// <summary>
        /// Cached name for the 'meta_hover_started' signal.
        /// </summary>
        public static readonly StringName MetaHoverStarted = "meta_hover_started";
        /// <summary>
        /// Cached name for the 'meta_hover_ended' signal.
        /// </summary>
        public static readonly StringName MetaHoverEnded = "meta_hover_ended";
        /// <summary>
        /// Cached name for the 'finished' signal.
        /// </summary>
        public static readonly StringName Finished = "finished";
    }
}
