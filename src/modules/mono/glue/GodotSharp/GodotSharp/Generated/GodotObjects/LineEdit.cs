namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para><see cref="Godot.LineEdit"/> provides an input field for editing a single line of text.</para>
/// <para>- When the <see cref="Godot.LineEdit"/> control is focused using the keyboard arrow keys, it will only gain focus and not enter edit mode.</para>
/// <para>- To enter edit mode, click on the control with the mouse, see also <see cref="Godot.LineEdit.KeepEditingOnTextSubmit"/>.</para>
/// <para>- To exit edit mode, press <c>ui_text_submit</c> or <c>ui_cancel</c> (by default Escape) actions.</para>
/// <para>- Check <see cref="Godot.LineEdit.Edit(bool)"/>, <see cref="Godot.LineEdit.Unedit()"/>, <see cref="Godot.LineEdit.IsEditing()"/>, and <see cref="Godot.LineEdit.EditingToggled"/> for more information.</para>
/// <para>While entering text, it is possible to insert special characters using Unicode, OEM or Windows alt codes:</para>
/// <para>- To enter Unicode codepoints, hold Alt and type the codepoint on the numpad. For example, to enter the character <c>á</c> (U+00E1), hold Alt and type +E1 on the numpad (the leading zeroes can be omitted).</para>
/// <para>- To enter OEM codepoints, hold Alt and type the code on the numpad. For example, to enter the character <c>á</c> (OEM 160), hold Alt and type <c>160</c> on the numpad.</para>
/// <para>- To enter Windows codepoints, hold Alt and type the code on the numpad. For example, to enter the character <c>á</c> (Windows 0225), hold Alt and type 0, 2, 2, 5 on the numpad. The leading zero here must <b>not</b> be omitted, as this is how Windows codepoints are distinguished from OEM codepoints.</para>
/// <para><b>Important:</b></para>
/// <para>- Focusing the <see cref="Godot.LineEdit"/> with <c>ui_focus_next</c> (by default Tab) or <c>ui_focus_prev</c> (by default Shift + Tab) or <see cref="Godot.Control.GrabFocus(bool)"/> still enters edit mode (for compatibility).</para>
/// <para><see cref="Godot.LineEdit"/> features many built-in shortcuts that are always available (Ctrl here maps to Cmd on macOS):</para>
/// <para>- Ctrl + C: Copy</para>
/// <para>- Ctrl + X: Cut</para>
/// <para>- Ctrl + V or Ctrl + Y: Paste/"yank"</para>
/// <para>- Ctrl + Z: Undo</para>
/// <para>- Ctrl + ~: Swap input direction.</para>
/// <para>- Ctrl + Shift + Z: Redo</para>
/// <para>- Ctrl + U: Delete text from the caret position to the beginning of the line</para>
/// <para>- Ctrl + K: Delete text from the caret position to the end of the line</para>
/// <para>- Ctrl + A: Select all text</para>
/// <para>- Up Arrow/Down Arrow: Move the caret to the beginning/end of the line</para>
/// <para>On macOS, some extra keyboard shortcuts are available:</para>
/// <para>- Cmd + F: Same as Right Arrow, move the caret one character right</para>
/// <para>- Cmd + B: Same as Left Arrow, move the caret one character left</para>
/// <para>- Cmd + P: Same as Up Arrow, move the caret to the previous line</para>
/// <para>- Cmd + N: Same as Down Arrow, move the caret to the next line</para>
/// <para>- Cmd + D: Same as Delete, delete the character on the right side of caret</para>
/// <para>- Cmd + H: Same as Backspace, delete the character on the left side of the caret</para>
/// <para>- Cmd + A: Same as Home, move the caret to the beginning of the line</para>
/// <para>- Cmd + E: Same as End, move the caret to the end of the line</para>
/// <para>- Cmd + Left Arrow: Same as Home, move the caret to the beginning of the line</para>
/// <para>- Cmd + Right Arrow: Same as End, move the caret to the end of the line</para>
/// <para><b>Note:</b> Caret movement shortcuts listed above are not affected by <see cref="Godot.LineEdit.ShortcutKeysEnabled"/>.</para>
/// </summary>
public partial class LineEdit : Control
{
    public enum MenuItems : long
    {
        /// <summary>
        /// <para>Cuts (copies and clears) the selected text.</para>
        /// </summary>
        Cut = 0,
        /// <summary>
        /// <para>Copies the selected text.</para>
        /// </summary>
        Copy = 1,
        /// <summary>
        /// <para>Pastes the clipboard text over the selected text (or at the caret's position).</para>
        /// <para>Non-printable escape characters are automatically stripped from the OS clipboard via <c>String.strip_escapes</c>.</para>
        /// </summary>
        Paste = 2,
        /// <summary>
        /// <para>Erases the whole <see cref="Godot.LineEdit"/> text.</para>
        /// </summary>
        Clear = 3,
        /// <summary>
        /// <para>Selects the whole <see cref="Godot.LineEdit"/> text.</para>
        /// </summary>
        SelectAll = 4,
        /// <summary>
        /// <para>Undoes the previous action.</para>
        /// </summary>
        Undo = 5,
        /// <summary>
        /// <para>Reverse the last undo action.</para>
        /// </summary>
        Redo = 6,
        /// <summary>
        /// <para>ID of "Text Writing Direction" submenu.</para>
        /// </summary>
        SubmenuTextDir = 7,
        /// <summary>
        /// <para>Sets text direction to inherited.</para>
        /// </summary>
        DirInherited = 8,
        /// <summary>
        /// <para>Sets text direction to automatic.</para>
        /// </summary>
        DirAuto = 9,
        /// <summary>
        /// <para>Sets text direction to left-to-right.</para>
        /// </summary>
        DirLtr = 10,
        /// <summary>
        /// <para>Sets text direction to right-to-left.</para>
        /// </summary>
        DirRtl = 11,
        /// <summary>
        /// <para>Toggles control character display.</para>
        /// </summary>
        DisplayUcc = 12,
        /// <summary>
        /// <para>ID of "Insert Control Character" submenu.</para>
        /// </summary>
        SubmenuInsertUcc = 13,
        /// <summary>
        /// <para>Inserts left-to-right mark (LRM) character.</para>
        /// </summary>
        InsertLrm = 14,
        /// <summary>
        /// <para>Inserts right-to-left mark (RLM) character.</para>
        /// </summary>
        InsertRlm = 15,
        /// <summary>
        /// <para>Inserts start of left-to-right embedding (LRE) character.</para>
        /// </summary>
        InsertLre = 16,
        /// <summary>
        /// <para>Inserts start of right-to-left embedding (RLE) character.</para>
        /// </summary>
        InsertRle = 17,
        /// <summary>
        /// <para>Inserts start of left-to-right override (LRO) character.</para>
        /// </summary>
        InsertLro = 18,
        /// <summary>
        /// <para>Inserts start of right-to-left override (RLO) character.</para>
        /// </summary>
        InsertRlo = 19,
        /// <summary>
        /// <para>Inserts pop direction formatting (PDF) character.</para>
        /// </summary>
        InsertPdf = 20,
        /// <summary>
        /// <para>Inserts Arabic letter mark (ALM) character.</para>
        /// </summary>
        InsertAlm = 21,
        /// <summary>
        /// <para>Inserts left-to-right isolate (LRI) character.</para>
        /// </summary>
        InsertLri = 22,
        /// <summary>
        /// <para>Inserts right-to-left isolate (RLI) character.</para>
        /// </summary>
        InsertRli = 23,
        /// <summary>
        /// <para>Inserts first strong isolate (FSI) character.</para>
        /// </summary>
        InsertFsi = 24,
        /// <summary>
        /// <para>Inserts pop direction isolate (PDI) character.</para>
        /// </summary>
        InsertPdi = 25,
        /// <summary>
        /// <para>Inserts zero width joiner (ZWJ) character.</para>
        /// </summary>
        InsertZwj = 26,
        /// <summary>
        /// <para>Inserts zero width non-joiner (ZWNJ) character.</para>
        /// </summary>
        InsertZwnj = 27,
        /// <summary>
        /// <para>Inserts word joiner (WJ) character.</para>
        /// </summary>
        InsertWj = 28,
        /// <summary>
        /// <para>Inserts soft hyphen (SHY) character.</para>
        /// </summary>
        InsertShy = 29,
        /// <summary>
        /// <para>Opens system emoji and symbol picker.</para>
        /// </summary>
        EmojiAndSymbol = 30,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.LineEdit.MenuItems"/> enum.</para>
        /// </summary>
        Max = 31
    }

    public enum VirtualKeyboardTypeEnum : long
    {
        /// <summary>
        /// <para>Default text virtual keyboard.</para>
        /// </summary>
        Default = 0,
        /// <summary>
        /// <para>Multiline virtual keyboard.</para>
        /// </summary>
        Multiline = 1,
        /// <summary>
        /// <para>Virtual number keypad, useful for PIN entry.</para>
        /// </summary>
        Number = 2,
        /// <summary>
        /// <para>Virtual number keypad, useful for entering fractional numbers.</para>
        /// </summary>
        NumberDecimal = 3,
        /// <summary>
        /// <para>Virtual phone number keypad.</para>
        /// </summary>
        Phone = 4,
        /// <summary>
        /// <para>Virtual keyboard with additional keys to assist with typing email addresses.</para>
        /// </summary>
        EmailAddress = 5,
        /// <summary>
        /// <para>Virtual keyboard for entering a password. On most platforms, this should disable autocomplete and autocapitalization.</para>
        /// <para><b>Note:</b> This is not supported on Web. Instead, this behaves identically to <see cref="Godot.LineEdit.VirtualKeyboardTypeEnum.Default"/>.</para>
        /// </summary>
        Password = 6,
        /// <summary>
        /// <para>Virtual keyboard with additional keys to assist with typing URLs.</para>
        /// </summary>
        Url = 7
    }

    public enum ExpandMode : long
    {
        /// <summary>
        /// <para>Use the original size for the right icon.</para>
        /// </summary>
        OriginalSize = 0,
        /// <summary>
        /// <para>Scale the right icon's size to match the size of the text.</para>
        /// </summary>
        FitToText = 1,
        /// <summary>
        /// <para>Scale the right icon to fit the LineEdit.</para>
        /// </summary>
        FitToLineEdit = 2
    }

    /// <summary>
    /// <para>String value of the <see cref="Godot.LineEdit"/>.</para>
    /// <para><b>Note:</b> Changing text using this property won't emit the <see cref="Godot.LineEdit.TextChanged"/> signal.</para>
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
    /// <para>Text shown when the <see cref="Godot.LineEdit"/> is empty. It is <b>not</b> the <see cref="Godot.LineEdit"/>'s default value (see <see cref="Godot.LineEdit.Text"/>).</para>
    /// </summary>
    public string PlaceholderText
    {
        get
        {
            return GetPlaceholder();
        }
        set
        {
            SetPlaceholder(value);
        }
    }

    /// <summary>
    /// <para>The text's horizontal alignment.</para>
    /// </summary>
    public HorizontalAlignment Alignment
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
    /// <para>Maximum number of characters that can be entered inside the <see cref="Godot.LineEdit"/>. If <c>0</c>, there is no limit.</para>
    /// <para>When a limit is defined, characters that would exceed <see cref="Godot.LineEdit.MaxLength"/> are truncated. This happens both for existing <see cref="Godot.LineEdit.Text"/> contents when setting the max length, or for new text inserted in the <see cref="Godot.LineEdit"/>, including pasting.</para>
    /// <para>If any input text is truncated, the <see cref="Godot.LineEdit.TextChangeRejected"/> signal is emitted with the truncated substring as a parameter:</para>
    /// <para><code>
    /// Text = "Hello world";
    /// MaxLength = 5;
    /// // `Text` becomes "Hello".
    /// MaxLength = 10;
    /// Text += " goodbye";
    /// // `Text` becomes "Hello good".
    /// // `text_change_rejected` is emitted with "bye" as a parameter.
    /// </code></para>
    /// </summary>
    public int MaxLength
    {
        get
        {
            return GetMaxLength();
        }
        set
        {
            SetMaxLength(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="false"/>, existing text cannot be modified and new text cannot be added.</para>
    /// </summary>
    public bool Editable
    {
        get
        {
            return IsEditable();
        }
        set
        {
            SetEditable(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the <see cref="Godot.LineEdit"/> will not exit edit mode when text is submitted by pressing <c>ui_text_submit</c> action (by default: Enter or Kp Enter).</para>
    /// </summary>
    public bool KeepEditingOnTextSubmit
    {
        get
        {
            return IsEditingKeptOnTextSubmit();
        }
        set
        {
            SetKeepEditingOnTextSubmit(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the <see cref="Godot.LineEdit"/> width will increase to stay longer than the <see cref="Godot.LineEdit.Text"/>. It will <b>not</b> compress if the <see cref="Godot.LineEdit.Text"/> is shortened.</para>
    /// </summary>
    public bool ExpandToTextLength
    {
        get
        {
            return IsExpandToTextLengthEnabled();
        }
        set
        {
            SetExpandToTextLengthEnabled(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the context menu will appear when right-clicked.</para>
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
    /// <para>If <see langword="true"/>, "Emoji and Symbols" menu is enabled.</para>
    /// </summary>
    public bool EmojiMenuEnabled
    {
        get
        {
            return IsEmojiMenuEnabled();
        }
        set
        {
            SetEmojiMenuEnabled(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/> and <see cref="Godot.LineEdit.CaretMidGrapheme"/> is <see langword="false"/>, backspace deletes an entire composite character such as ❤️‍🩹, instead of deleting part of the composite character.</para>
    /// </summary>
    public bool BackspaceDeletesCompositeCharacterEnabled
    {
        get
        {
            return IsBackspaceDeletesCompositeCharacterEnabled();
        }
        set
        {
            SetBackspaceDeletesCompositeCharacterEnabled(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the <see cref="Godot.LineEdit"/> will show a clear button if <see cref="Godot.LineEdit.Text"/> is not empty, which can be used to clear the text quickly.</para>
    /// </summary>
    public bool ClearButtonEnabled
    {
        get
        {
            return IsClearButtonEnabled();
        }
        set
        {
            SetClearButtonEnabled(value);
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
    /// <para>If <see langword="false"/>, using middle mouse button to paste clipboard will be disabled.</para>
    /// <para><b>Note:</b> This method is only implemented on Linux.</para>
    /// </summary>
    public bool MiddleMousePasteEnabled
    {
        get
        {
            return IsMiddleMousePasteEnabled();
        }
        set
        {
            SetMiddleMousePasteEnabled(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="false"/>, it's impossible to select the text using mouse nor keyboard.</para>
    /// </summary>
    public bool SelectingEnabled
    {
        get
        {
            return IsSelectingEnabled();
        }
        set
        {
            SetSelectingEnabled(value);
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
    /// <para>If <see langword="true"/>, the <see cref="Godot.LineEdit"/> doesn't display decoration.</para>
    /// </summary>
    public bool Flat
    {
        get
        {
            return IsFlat();
        }
        set
        {
            SetFlat(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, control characters are displayed.</para>
    /// </summary>
    public bool DrawControlChars
    {
        get
        {
            return GetDrawControlChars();
        }
        set
        {
            SetDrawControlChars(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the <see cref="Godot.LineEdit"/> will select the whole text when it gains focus.</para>
    /// </summary>
    public bool SelectAllOnFocus
    {
        get
        {
            return IsSelectAllOnFocus();
        }
        set
        {
            SetSelectAllOnFocus(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the native virtual keyboard is enabled on platforms that support it.</para>
    /// </summary>
    public bool VirtualKeyboardEnabled
    {
        get
        {
            return IsVirtualKeyboardEnabled();
        }
        set
        {
            SetVirtualKeyboardEnabled(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the native virtual keyboard is shown on focus events on platforms that support it.</para>
    /// </summary>
    public bool VirtualKeyboardShowOnFocus
    {
        get
        {
            return GetVirtualKeyboardShowOnFocus();
        }
        set
        {
            SetVirtualKeyboardShowOnFocus(value);
        }
    }

    /// <summary>
    /// <para>Specifies the type of virtual keyboard to show.</para>
    /// </summary>
    public LineEdit.VirtualKeyboardTypeEnum VirtualKeyboardType
    {
        get
        {
            return GetVirtualKeyboardType();
        }
        set
        {
            SetVirtualKeyboardType(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, makes the caret blink.</para>
    /// </summary>
    public bool CaretBlink
    {
        get
        {
            return IsCaretBlinkEnabled();
        }
        set
        {
            SetCaretBlinkEnabled(value);
        }
    }

    /// <summary>
    /// <para>The interval at which the caret blinks (in seconds).</para>
    /// </summary>
    public float CaretBlinkInterval
    {
        get
        {
            return GetCaretBlinkInterval();
        }
        set
        {
            SetCaretBlinkInterval(value);
        }
    }

    /// <summary>
    /// <para>The caret's column position inside the <see cref="Godot.LineEdit"/>. When set, the text may scroll to accommodate it.</para>
    /// </summary>
    public int CaretColumn
    {
        get
        {
            return GetCaretColumn();
        }
        set
        {
            SetCaretColumn(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the <see cref="Godot.LineEdit"/> will always show the caret, even if not editing or focus is lost.</para>
    /// </summary>
    public bool CaretForceDisplayed
    {
        get
        {
            return IsCaretForceDisplayed();
        }
        set
        {
            SetCaretForceDisplayed(value);
        }
    }

    /// <summary>
    /// <para>Allow moving caret, selecting and removing the individual composite character components.</para>
    /// <para><b>Note:</b> Backspace is always removing individual composite character components.</para>
    /// </summary>
    public bool CaretMidGrapheme
    {
        get
        {
            return IsCaretMidGraphemeEnabled();
        }
        set
        {
            SetCaretMidGraphemeEnabled(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, every character is replaced with the secret character (see <see cref="Godot.LineEdit.SecretCharacter"/>).</para>
    /// </summary>
    public bool Secret
    {
        get
        {
            return IsSecret();
        }
        set
        {
            SetSecret(value);
        }
    }

    /// <summary>
    /// <para>The character to use to mask secret input. Only a single character can be used as the secret character. If it is longer than one character, only the first one will be used. If it is empty, a space will be used instead.</para>
    /// </summary>
    public string SecretCharacter
    {
        get
        {
            return GetSecretCharacter();
        }
        set
        {
            SetSecretCharacter(value);
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

    /// <summary>
    /// <para>Sets the icon that will appear in the right end of the <see cref="Godot.LineEdit"/> if there's no <see cref="Godot.LineEdit.Text"/>, or always, if <see cref="Godot.LineEdit.ClearButtonEnabled"/> is set to <see langword="false"/>.</para>
    /// </summary>
    public Texture2D RightIcon
    {
        get
        {
            return GetRightIcon();
        }
        set
        {
            SetRightIcon(value);
        }
    }

    /// <summary>
    /// <para>Define the scaling behavior of the <see cref="Godot.LineEdit.RightIcon"/>.</para>
    /// </summary>
    public LineEdit.ExpandMode IconExpandMode
    {
        get
        {
            return GetIconExpandMode();
        }
        set
        {
            SetIconExpandMode(value);
        }
    }

    /// <summary>
    /// <para>Scale ratio of the icon when <see cref="Godot.LineEdit.IconExpandMode"/> is set to <see cref="Godot.LineEdit.ExpandMode.FitToLineEdit"/>.</para>
    /// </summary>
    public float RightIconScale
    {
        get
        {
            return GetRightIconScale();
        }
        set
        {
            SetRightIconScale(value);
        }
    }

    private static readonly System.Type CachedType = typeof(LineEdit);

    private static readonly StringName NativeName = "LineEdit";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public LineEdit() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal LineEdit(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal LineEdit(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasImeText, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the user has text in the <a href="https://en.wikipedia.org/wiki/Input_method">Input Method Editor</a> (IME).</para>
    /// </summary>
    public bool HasImeText()
    {
        return NativeCalls.godot_icall_0_15(MethodBind0, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CancelIme, 3218959716ul);

    /// <summary>
    /// <para>Closes the <a href="https://en.wikipedia.org/wiki/Input_method">Input Method Editor</a> (IME) if it is open. Any text in the IME will be lost.</para>
    /// </summary>
    public void CancelIme()
    {
        NativeCalls.godot_icall_0_3(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ApplyIme, 3218959716ul);

    /// <summary>
    /// <para>Applies text from the <a href="https://en.wikipedia.org/wiki/Input_method">Input Method Editor</a> (IME) and closes the IME if it is open.</para>
    /// </summary>
    public void ApplyIme()
    {
        NativeCalls.godot_icall_0_3(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetHorizontalAlignment, 2312603777ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetHorizontalAlignment(HorizontalAlignment alignment)
    {
        NativeCalls.godot_icall_1_38(MethodBind3, GodotObject.GetPtr(this), (int)alignment);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetHorizontalAlignment, 341400642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public HorizontalAlignment GetHorizontalAlignment()
    {
        return (HorizontalAlignment)NativeCalls.godot_icall_0_39(MethodBind4, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Edit, 107499316ul);

    /// <summary>
    /// <para>Allows entering edit mode whether the <see cref="Godot.LineEdit"/> is focused or not. If <paramref name="hideFocus"/> is <see langword="true"/>, the focused state will not be shown (see <see cref="Godot.Control.GrabFocus(bool)"/>).</para>
    /// <para>See also <see cref="Godot.LineEdit.KeepEditingOnTextSubmit"/>.</para>
    /// </summary>
    public void Edit(bool hideFocus = false)
    {
        NativeCalls.godot_icall_1_14(MethodBind5, GodotObject.GetPtr(this), hideFocus.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Unedit, 3218959716ul);

    /// <summary>
    /// <para>Allows exiting edit mode while preserving focus.</para>
    /// </summary>
    public void Unedit()
    {
        NativeCalls.godot_icall_0_3(MethodBind6, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsEditing, 36873697ul);

    /// <summary>
    /// <para>Returns whether the <see cref="Godot.LineEdit"/> is being edited.</para>
    /// </summary>
    public bool IsEditing()
    {
        return NativeCalls.godot_icall_0_15(MethodBind7, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetKeepEditingOnTextSubmit, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetKeepEditingOnTextSubmit(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind8, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsEditingKeptOnTextSubmit, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsEditingKeptOnTextSubmit()
    {
        return NativeCalls.godot_icall_0_15(MethodBind9, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Clear, 3218959716ul);

    /// <summary>
    /// <para>Erases the <see cref="Godot.LineEdit"/>'s <see cref="Godot.LineEdit.Text"/>.</para>
    /// </summary>
    public void Clear()
    {
        NativeCalls.godot_icall_0_3(MethodBind10, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Select, 1328111411ul);

    /// <summary>
    /// <para>Selects characters inside <see cref="Godot.LineEdit"/> between <paramref name="from"/> and <paramref name="to"/>. By default, <paramref name="from"/> is at the beginning and <paramref name="to"/> at the end.</para>
    /// <para><code>
    /// Text = "Welcome";
    /// Select(); // Will select "Welcome".
    /// Select(4); // Will select "ome".
    /// Select(2, 5); // Will select "lco".
    /// </code></para>
    /// </summary>
    public void Select(int from = 0, int to = -1)
    {
        NativeCalls.godot_icall_2_59(MethodBind11, GodotObject.GetPtr(this), from, to);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SelectAll, 3218959716ul);

    /// <summary>
    /// <para>Selects the whole <see cref="string"/>.</para>
    /// </summary>
    public void SelectAll()
    {
        NativeCalls.godot_icall_0_3(MethodBind12, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Deselect, 3218959716ul);

    /// <summary>
    /// <para>Clears the current selection.</para>
    /// </summary>
    public void Deselect()
    {
        NativeCalls.godot_icall_0_3(MethodBind13, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasUndo, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if an "undo" action is available.</para>
    /// </summary>
    public bool HasUndo()
    {
        return NativeCalls.godot_icall_0_15(MethodBind14, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasRedo, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if a "redo" action is available.</para>
    /// </summary>
    public bool HasRedo()
    {
        return NativeCalls.godot_icall_0_15(MethodBind15, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasSelection, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the user has selected text.</para>
    /// </summary>
    public bool HasSelection()
    {
        return NativeCalls.godot_icall_0_15(MethodBind16, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSelectedText, 2841200299ul);

    /// <summary>
    /// <para>Returns the text inside the selection.</para>
    /// </summary>
    public string GetSelectedText()
    {
        return NativeCalls.godot_icall_0_58(MethodBind17, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSelectionFromColumn, 3905245786ul);

    /// <summary>
    /// <para>Returns the selection begin column.</para>
    /// </summary>
    public int GetSelectionFromColumn()
    {
        return NativeCalls.godot_icall_0_39(MethodBind18, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSelectionToColumn, 3905245786ul);

    /// <summary>
    /// <para>Returns the selection end column.</para>
    /// </summary>
    public int GetSelectionToColumn()
    {
        return NativeCalls.godot_icall_0_39(MethodBind19, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetText, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetText(string text)
    {
        NativeCalls.godot_icall_1_57(MethodBind20, GodotObject.GetPtr(this), text);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetText, 201670096ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetText()
    {
        return NativeCalls.godot_icall_0_58(MethodBind21, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDrawControlChars, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetDrawControlChars()
    {
        return NativeCalls.godot_icall_0_15(MethodBind22, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDrawControlChars, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDrawControlChars(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind23, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTextDirection, 119160795ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTextDirection(Control.TextDirection direction)
    {
        NativeCalls.godot_icall_1_38(MethodBind24, GodotObject.GetPtr(this), (int)direction);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTextDirection, 797257663ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Control.TextDirection GetTextDirection()
    {
        return (Control.TextDirection)NativeCalls.godot_icall_0_39(MethodBind25, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLanguage, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetLanguage(string language)
    {
        NativeCalls.godot_icall_1_57(MethodBind26, GodotObject.GetPtr(this), language);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLanguage, 201670096ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetLanguage()
    {
        return NativeCalls.godot_icall_0_58(MethodBind27, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetStructuredTextBidiOverride, 55961453ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetStructuredTextBidiOverride(TextServer.StructuredTextParser parser)
    {
        NativeCalls.godot_icall_1_38(MethodBind28, GodotObject.GetPtr(this), (int)parser);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetStructuredTextBidiOverride, 3385126229ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public TextServer.StructuredTextParser GetStructuredTextBidiOverride()
    {
        return (TextServer.StructuredTextParser)NativeCalls.godot_icall_0_39(MethodBind29, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetStructuredTextBidiOverrideOptions, 381264803ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetStructuredTextBidiOverrideOptions(Godot.Collections.Array args)
    {
        NativeCalls.godot_icall_1_138(MethodBind30, GodotObject.GetPtr(this), (godot_array)(args ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetStructuredTextBidiOverrideOptions, 3995934104ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Godot.Collections.Array GetStructuredTextBidiOverrideOptions()
    {
        return NativeCalls.godot_icall_0_120(MethodBind31, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind32 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPlaceholder, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPlaceholder(string text)
    {
        NativeCalls.godot_icall_1_57(MethodBind32, GodotObject.GetPtr(this), text);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind33 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPlaceholder, 201670096ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetPlaceholder()
    {
        return NativeCalls.godot_icall_0_58(MethodBind33, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind34 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCaretColumn, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCaretColumn(int position)
    {
        NativeCalls.godot_icall_1_38(MethodBind34, GodotObject.GetPtr(this), position);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind35 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCaretColumn, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetCaretColumn()
    {
        return NativeCalls.godot_icall_0_39(MethodBind35, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind36 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNextCompositeCharacterColumn, 923996154ul);

    /// <summary>
    /// <para>Returns the correct column at the end of a composite character like ❤️‍🩹 (mending heart; Unicode: <c>U+2764 U+FE0F U+200D U+1FA79</c>) which is comprised of more than one Unicode code point, if the caret is at the start of the composite character. Also returns the correct column with the caret at mid grapheme and for non-composite characters.</para>
    /// <para><b>Note:</b> To check at caret location use <c>get_next_composite_character_column(get_caret_column())</c></para>
    /// </summary>
    public int GetNextCompositeCharacterColumn(int column)
    {
        return NativeCalls.godot_icall_1_60(MethodBind36, GodotObject.GetPtr(this), column);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind37 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPreviousCompositeCharacterColumn, 923996154ul);

    /// <summary>
    /// <para>Returns the correct column at the start of a composite character like ❤️‍🩹 (mending heart; Unicode: <c>U+2764 U+FE0F U+200D U+1FA79</c>) which is comprised of more than one Unicode code point, if the caret is at the end of the composite character. Also returns the correct column with the caret at mid grapheme and for non-composite characters.</para>
    /// <para><b>Note:</b> To check at caret location use <c>get_previous_composite_character_column(get_caret_column())</c></para>
    /// </summary>
    public int GetPreviousCompositeCharacterColumn(int column)
    {
        return NativeCalls.godot_icall_1_60(MethodBind37, GodotObject.GetPtr(this), column);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind38 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetScrollOffset, 1740695150ul);

    /// <summary>
    /// <para>Returns the scroll offset due to <see cref="Godot.LineEdit.CaretColumn"/>, as a number of characters.</para>
    /// </summary>
    public float GetScrollOffset()
    {
        return NativeCalls.godot_icall_0_68(MethodBind38, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind39 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetExpandToTextLengthEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetExpandToTextLengthEnabled(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind39, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind40 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsExpandToTextLengthEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsExpandToTextLengthEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind40, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind41 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCaretBlinkEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCaretBlinkEnabled(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind41, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind42 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsCaretBlinkEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsCaretBlinkEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind42, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind43 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCaretMidGraphemeEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCaretMidGraphemeEnabled(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind43, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind44 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsCaretMidGraphemeEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsCaretMidGraphemeEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind44, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind45 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCaretForceDisplayed, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCaretForceDisplayed(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind45, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind46 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsCaretForceDisplayed, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsCaretForceDisplayed()
    {
        return NativeCalls.godot_icall_0_15(MethodBind46, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind47 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCaretBlinkInterval, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCaretBlinkInterval(float interval)
    {
        NativeCalls.godot_icall_1_67(MethodBind47, GodotObject.GetPtr(this), interval);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind48 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCaretBlinkInterval, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetCaretBlinkInterval()
    {
        return NativeCalls.godot_icall_0_68(MethodBind48, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind49 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMaxLength, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMaxLength(int chars)
    {
        NativeCalls.godot_icall_1_38(MethodBind49, GodotObject.GetPtr(this), chars);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind50 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMaxLength, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetMaxLength()
    {
        return NativeCalls.godot_icall_0_39(MethodBind50, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind51 = ClassDB_get_method_with_compatibility(NativeName, MethodName.InsertTextAtCaret, 83702148ul);

    /// <summary>
    /// <para>Inserts <paramref name="text"/> at the caret. If the resulting value is longer than <see cref="Godot.LineEdit.MaxLength"/>, nothing happens.</para>
    /// </summary>
    public void InsertTextAtCaret(string text)
    {
        NativeCalls.godot_icall_1_57(MethodBind51, GodotObject.GetPtr(this), text);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind52 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DeleteCharAtCaret, 3218959716ul);

    /// <summary>
    /// <para>Deletes one character at the caret's current position (equivalent to pressing Delete).</para>
    /// </summary>
    public void DeleteCharAtCaret()
    {
        NativeCalls.godot_icall_0_3(MethodBind52, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind53 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DeleteText, 3937882851ul);

    /// <summary>
    /// <para>Deletes a section of the <see cref="Godot.LineEdit.Text"/> going from position <paramref name="fromColumn"/> to <paramref name="toColumn"/>. Both parameters should be within the text's length.</para>
    /// </summary>
    public void DeleteText(int fromColumn, int toColumn)
    {
        NativeCalls.godot_icall_2_59(MethodBind53, GodotObject.GetPtr(this), fromColumn, toColumn);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind54 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEditable, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEditable(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind54, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind55 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsEditable, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsEditable()
    {
        return NativeCalls.godot_icall_0_15(MethodBind55, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind56 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSecret, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSecret(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind56, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind57 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsSecret, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsSecret()
    {
        return NativeCalls.godot_icall_0_15(MethodBind57, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind58 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSecretCharacter, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSecretCharacter(string character)
    {
        NativeCalls.godot_icall_1_57(MethodBind58, GodotObject.GetPtr(this), character);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind59 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSecretCharacter, 201670096ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetSecretCharacter()
    {
        return NativeCalls.godot_icall_0_58(MethodBind59, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind60 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MenuOption, 1286410249ul);

    /// <summary>
    /// <para>Executes a given action as defined in the <see cref="Godot.LineEdit.MenuItems"/> enum.</para>
    /// </summary>
    public void MenuOption(int option)
    {
        NativeCalls.godot_icall_1_38(MethodBind60, GodotObject.GetPtr(this), option);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind61 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMenu, 229722558ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.PopupMenu"/> of this <see cref="Godot.LineEdit"/>. By default, this menu is displayed when right-clicking on the <see cref="Godot.LineEdit"/>.</para>
    /// <para>You can add custom menu items or remove standard ones. Make sure your IDs don't conflict with the standard ones (see <see cref="Godot.LineEdit.MenuItems"/>). For example:</para>
    /// <para><code>
    /// public override void _Ready()
    /// {
    /// 	var menu = GetMenu();
    /// 	// Remove all items after "Redo".
    /// 	menu.ItemCount = menu.GetItemIndex(LineEdit.MenuItems.Redo) + 1;
    /// 	// Add custom items.
    /// 	menu.AddSeparator();
    /// 	menu.AddItem("Insert Date", LineEdit.MenuItems.Max + 1);
    /// 	// Add event handler.
    /// 	menu.IdPressed += OnItemPressed;
    /// }
    /// 
    /// public void OnItemPressed(int id)
    /// {
    /// 	if (id == LineEdit.MenuItems.Max + 1)
    /// 	{
    /// 		InsertTextAtCaret(Time.GetDateStringFromSystem());
    /// 	}
    /// }
    /// </code></para>
    /// <para><b>Warning:</b> This is a required internal node, removing and freeing it may cause a crash. If you wish to hide it or any of its children, use their <see cref="Godot.Window.Visible"/> property.</para>
    /// </summary>
    public PopupMenu GetMenu()
    {
        return (PopupMenu)NativeCalls.godot_icall_0_53(MethodBind61, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind62 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsMenuVisible, 36873697ul);

    /// <summary>
    /// <para>Returns whether the menu is visible. Use this instead of <c>get_menu().visible</c> to improve performance (so the creation of the menu is avoided).</para>
    /// </summary>
    public bool IsMenuVisible()
    {
        return NativeCalls.godot_icall_0_15(MethodBind62, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind63 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetContextMenuEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetContextMenuEnabled(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind63, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind64 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsContextMenuEnabled, 2240911060ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsContextMenuEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind64, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind65 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEmojiMenuEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEmojiMenuEnabled(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind65, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind66 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsEmojiMenuEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsEmojiMenuEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind66, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind67 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBackspaceDeletesCompositeCharacterEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetBackspaceDeletesCompositeCharacterEnabled(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind67, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind68 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsBackspaceDeletesCompositeCharacterEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsBackspaceDeletesCompositeCharacterEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind68, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind69 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVirtualKeyboardEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetVirtualKeyboardEnabled(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind69, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind70 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsVirtualKeyboardEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsVirtualKeyboardEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind70, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind71 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVirtualKeyboardShowOnFocus, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetVirtualKeyboardShowOnFocus(bool showOnFocus)
    {
        NativeCalls.godot_icall_1_14(MethodBind71, GodotObject.GetPtr(this), showOnFocus.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind72 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVirtualKeyboardShowOnFocus, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetVirtualKeyboardShowOnFocus()
    {
        return NativeCalls.godot_icall_0_15(MethodBind72, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind73 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVirtualKeyboardType, 2696893573ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetVirtualKeyboardType(LineEdit.VirtualKeyboardTypeEnum type)
    {
        NativeCalls.godot_icall_1_38(MethodBind73, GodotObject.GetPtr(this), (int)type);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind74 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVirtualKeyboardType, 1928699316ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public LineEdit.VirtualKeyboardTypeEnum GetVirtualKeyboardType()
    {
        return (LineEdit.VirtualKeyboardTypeEnum)NativeCalls.godot_icall_0_39(MethodBind74, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind75 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetClearButtonEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetClearButtonEnabled(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind75, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind76 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsClearButtonEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsClearButtonEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind76, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind77 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetShortcutKeysEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetShortcutKeysEnabled(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind77, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind78 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsShortcutKeysEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsShortcutKeysEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind78, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind79 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMiddleMousePasteEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMiddleMousePasteEnabled(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind79, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind80 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsMiddleMousePasteEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsMiddleMousePasteEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind80, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind81 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSelectingEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSelectingEnabled(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind81, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind82 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsSelectingEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsSelectingEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind82, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind83 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDeselectOnFocusLossEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDeselectOnFocusLossEnabled(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind83, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind84 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsDeselectOnFocusLossEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsDeselectOnFocusLossEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind84, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind85 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDragAndDropSelectionEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDragAndDropSelectionEnabled(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind85, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind86 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsDragAndDropSelectionEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsDragAndDropSelectionEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind86, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind87 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRightIcon, 4051416890ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetRightIcon(Texture2D icon)
    {
        NativeCalls.godot_icall_1_56(MethodBind87, GodotObject.GetPtr(this), GodotObject.GetPtr(icon));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind88 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRightIcon, 255860311ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Texture2D GetRightIcon()
    {
        return (Texture2D)NativeCalls.godot_icall_0_63(MethodBind88, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind89 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetIconExpandMode, 3019903192ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetIconExpandMode(LineEdit.ExpandMode mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind89, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind90 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetIconExpandMode, 3273584435ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public LineEdit.ExpandMode GetIconExpandMode()
    {
        return (LineEdit.ExpandMode)NativeCalls.godot_icall_0_39(MethodBind90, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind91 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRightIconScale, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetRightIconScale(float scale)
    {
        NativeCalls.godot_icall_1_67(MethodBind91, GodotObject.GetPtr(this), scale);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind92 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRightIconScale, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetRightIconScale()
    {
        return NativeCalls.godot_icall_0_68(MethodBind92, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind93 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFlat, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFlat(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind93, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind94 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsFlat, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsFlat()
    {
        return NativeCalls.godot_icall_0_15(MethodBind94, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind95 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSelectAllOnFocus, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSelectAllOnFocus(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind95, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind96 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsSelectAllOnFocus, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsSelectAllOnFocus()
    {
        return NativeCalls.godot_icall_0_15(MethodBind96, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind97 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Edit, 3218959716ul);

    /// <summary>
    /// <para>Allows entering edit mode whether the <see cref="Godot.LineEdit"/> is focused or not. If <paramref name="hideFocus"/> is <see langword="true"/>, the focused state will not be shown (see <see cref="Godot.Control.GrabFocus(bool)"/>).</para>
    /// <para>See also <see cref="Godot.LineEdit.KeepEditingOnTextSubmit"/>.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void Edit()
    {
        NativeCalls.godot_icall_0_3(MethodBind97, GodotObject.GetPtr(this));
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.LineEdit.TextChanged"/> event of a <see cref="Godot.LineEdit"/> class.
    /// </summary>
    public delegate void TextChangedEventHandler(string newText);

    private static void TextChangedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((TextChangedEventHandler)delegateObj)(VariantUtils.ConvertTo<string>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when the text changes.</para>
    /// </summary>
    public unsafe event TextChangedEventHandler TextChanged
    {
        add => Connect(SignalName.TextChanged, Callable.CreateWithUnsafeTrampoline(value, &TextChangedTrampoline));
        remove => Disconnect(SignalName.TextChanged, Callable.CreateWithUnsafeTrampoline(value, &TextChangedTrampoline));
    }

    protected void EmitSignalTextChanged(string newText)
    {
        EmitSignal(SignalName.TextChanged, newText);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.LineEdit.TextChangeRejected"/> event of a <see cref="Godot.LineEdit"/> class.
    /// </summary>
    public delegate void TextChangeRejectedEventHandler(string rejectedSubstring);

    private static void TextChangeRejectedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((TextChangeRejectedEventHandler)delegateObj)(VariantUtils.ConvertTo<string>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when appending text that overflows the <see cref="Godot.LineEdit.MaxLength"/>. The appended text is truncated to fit <see cref="Godot.LineEdit.MaxLength"/>, and the part that couldn't fit is passed as the <c>rejectedSubstring</c> argument.</para>
    /// </summary>
    public unsafe event TextChangeRejectedEventHandler TextChangeRejected
    {
        add => Connect(SignalName.TextChangeRejected, Callable.CreateWithUnsafeTrampoline(value, &TextChangeRejectedTrampoline));
        remove => Disconnect(SignalName.TextChangeRejected, Callable.CreateWithUnsafeTrampoline(value, &TextChangeRejectedTrampoline));
    }

    protected void EmitSignalTextChangeRejected(string rejectedSubstring)
    {
        EmitSignal(SignalName.TextChangeRejected, rejectedSubstring);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.LineEdit.TextSubmitted"/> event of a <see cref="Godot.LineEdit"/> class.
    /// </summary>
    public delegate void TextSubmittedEventHandler(string newText);

    private static void TextSubmittedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((TextSubmittedEventHandler)delegateObj)(VariantUtils.ConvertTo<string>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when the user presses the <c>ui_text_submit</c> action (by default: Enter or Kp Enter) while the <see cref="Godot.LineEdit"/> has focus.</para>
    /// </summary>
    public unsafe event TextSubmittedEventHandler TextSubmitted
    {
        add => Connect(SignalName.TextSubmitted, Callable.CreateWithUnsafeTrampoline(value, &TextSubmittedTrampoline));
        remove => Disconnect(SignalName.TextSubmitted, Callable.CreateWithUnsafeTrampoline(value, &TextSubmittedTrampoline));
    }

    protected void EmitSignalTextSubmitted(string newText)
    {
        EmitSignal(SignalName.TextSubmitted, newText);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.LineEdit.EditingToggled"/> event of a <see cref="Godot.LineEdit"/> class.
    /// </summary>
    public delegate void EditingToggledEventHandler(bool toggledOn);

    private static void EditingToggledTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((EditingToggledEventHandler)delegateObj)(VariantUtils.ConvertTo<bool>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when the <see cref="Godot.LineEdit"/> switches in or out of edit mode.</para>
    /// </summary>
    public unsafe event EditingToggledEventHandler EditingToggled
    {
        add => Connect(SignalName.EditingToggled, Callable.CreateWithUnsafeTrampoline(value, &EditingToggledTrampoline));
        remove => Disconnect(SignalName.EditingToggled, Callable.CreateWithUnsafeTrampoline(value, &EditingToggledTrampoline));
    }

    protected void EmitSignalEditingToggled(bool toggledOn)
    {
        EmitSignal(SignalName.EditingToggled, toggledOn);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_text_changed = "TextChanged";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_text_change_rejected = "TextChangeRejected";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_text_submitted = "TextSubmitted";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_editing_toggled = "EditingToggled";

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
        if (signal == SignalName.TextChanged)
        {
            if (HasGodotClassSignal(SignalProxyName_text_changed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.TextChangeRejected)
        {
            if (HasGodotClassSignal(SignalProxyName_text_change_rejected.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.TextSubmitted)
        {
            if (HasGodotClassSignal(SignalProxyName_text_submitted.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.EditingToggled)
        {
            if (HasGodotClassSignal(SignalProxyName_editing_toggled.NativeValue.DangerousSelfRef))
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
        /// Cached name for the 'text' property.
        /// </summary>
        public static readonly StringName Text = "text";
        /// <summary>
        /// Cached name for the 'placeholder_text' property.
        /// </summary>
        public static readonly StringName PlaceholderText = "placeholder_text";
        /// <summary>
        /// Cached name for the 'alignment' property.
        /// </summary>
        public static readonly StringName Alignment = "alignment";
        /// <summary>
        /// Cached name for the 'max_length' property.
        /// </summary>
        public static readonly StringName MaxLength = "max_length";
        /// <summary>
        /// Cached name for the 'editable' property.
        /// </summary>
        public static readonly StringName Editable = "editable";
        /// <summary>
        /// Cached name for the 'keep_editing_on_text_submit' property.
        /// </summary>
        public static readonly StringName KeepEditingOnTextSubmit = "keep_editing_on_text_submit";
        /// <summary>
        /// Cached name for the 'expand_to_text_length' property.
        /// </summary>
        public static readonly StringName ExpandToTextLength = "expand_to_text_length";
        /// <summary>
        /// Cached name for the 'context_menu_enabled' property.
        /// </summary>
        public static readonly StringName ContextMenuEnabled = "context_menu_enabled";
        /// <summary>
        /// Cached name for the 'emoji_menu_enabled' property.
        /// </summary>
        public static readonly StringName EmojiMenuEnabled = "emoji_menu_enabled";
        /// <summary>
        /// Cached name for the 'backspace_deletes_composite_character_enabled' property.
        /// </summary>
        public static readonly StringName BackspaceDeletesCompositeCharacterEnabled = "backspace_deletes_composite_character_enabled";
        /// <summary>
        /// Cached name for the 'clear_button_enabled' property.
        /// </summary>
        public static readonly StringName ClearButtonEnabled = "clear_button_enabled";
        /// <summary>
        /// Cached name for the 'shortcut_keys_enabled' property.
        /// </summary>
        public static readonly StringName ShortcutKeysEnabled = "shortcut_keys_enabled";
        /// <summary>
        /// Cached name for the 'middle_mouse_paste_enabled' property.
        /// </summary>
        public static readonly StringName MiddleMousePasteEnabled = "middle_mouse_paste_enabled";
        /// <summary>
        /// Cached name for the 'selecting_enabled' property.
        /// </summary>
        public static readonly StringName SelectingEnabled = "selecting_enabled";
        /// <summary>
        /// Cached name for the 'deselect_on_focus_loss_enabled' property.
        /// </summary>
        public static readonly StringName DeselectOnFocusLossEnabled = "deselect_on_focus_loss_enabled";
        /// <summary>
        /// Cached name for the 'drag_and_drop_selection_enabled' property.
        /// </summary>
        public static readonly StringName DragAndDropSelectionEnabled = "drag_and_drop_selection_enabled";
        /// <summary>
        /// Cached name for the 'flat' property.
        /// </summary>
        public static readonly StringName Flat = "flat";
        /// <summary>
        /// Cached name for the 'draw_control_chars' property.
        /// </summary>
        public static readonly StringName DrawControlChars = "draw_control_chars";
        /// <summary>
        /// Cached name for the 'select_all_on_focus' property.
        /// </summary>
        public static readonly StringName SelectAllOnFocus = "select_all_on_focus";
        /// <summary>
        /// Cached name for the 'virtual_keyboard_enabled' property.
        /// </summary>
        public static readonly StringName VirtualKeyboardEnabled = "virtual_keyboard_enabled";
        /// <summary>
        /// Cached name for the 'virtual_keyboard_show_on_focus' property.
        /// </summary>
        public static readonly StringName VirtualKeyboardShowOnFocus = "virtual_keyboard_show_on_focus";
        /// <summary>
        /// Cached name for the 'virtual_keyboard_type' property.
        /// </summary>
        public static readonly StringName VirtualKeyboardType = "virtual_keyboard_type";
        /// <summary>
        /// Cached name for the 'caret_blink' property.
        /// </summary>
        public static readonly StringName CaretBlink = "caret_blink";
        /// <summary>
        /// Cached name for the 'caret_blink_interval' property.
        /// </summary>
        public static readonly StringName CaretBlinkInterval = "caret_blink_interval";
        /// <summary>
        /// Cached name for the 'caret_column' property.
        /// </summary>
        public static readonly StringName CaretColumn = "caret_column";
        /// <summary>
        /// Cached name for the 'caret_force_displayed' property.
        /// </summary>
        public static readonly StringName CaretForceDisplayed = "caret_force_displayed";
        /// <summary>
        /// Cached name for the 'caret_mid_grapheme' property.
        /// </summary>
        public static readonly StringName CaretMidGrapheme = "caret_mid_grapheme";
        /// <summary>
        /// Cached name for the 'secret' property.
        /// </summary>
        public static readonly StringName Secret = "secret";
        /// <summary>
        /// Cached name for the 'secret_character' property.
        /// </summary>
        public static readonly StringName SecretCharacter = "secret_character";
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
        /// <summary>
        /// Cached name for the 'right_icon' property.
        /// </summary>
        public static readonly StringName RightIcon = "right_icon";
        /// <summary>
        /// Cached name for the 'icon_expand_mode' property.
        /// </summary>
        public static readonly StringName IconExpandMode = "icon_expand_mode";
        /// <summary>
        /// Cached name for the 'right_icon_scale' property.
        /// </summary>
        public static readonly StringName RightIconScale = "right_icon_scale";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Control.MethodName
    {
        /// <summary>
        /// Cached name for the 'has_ime_text' method.
        /// </summary>
        public static readonly StringName HasImeText = "has_ime_text";
        /// <summary>
        /// Cached name for the 'cancel_ime' method.
        /// </summary>
        public static readonly StringName CancelIme = "cancel_ime";
        /// <summary>
        /// Cached name for the 'apply_ime' method.
        /// </summary>
        public static readonly StringName ApplyIme = "apply_ime";
        /// <summary>
        /// Cached name for the 'set_horizontal_alignment' method.
        /// </summary>
        public static readonly StringName SetHorizontalAlignment = "set_horizontal_alignment";
        /// <summary>
        /// Cached name for the 'get_horizontal_alignment' method.
        /// </summary>
        public static readonly StringName GetHorizontalAlignment = "get_horizontal_alignment";
        /// <summary>
        /// Cached name for the 'edit' method.
        /// </summary>
        public static readonly StringName Edit = "edit";
        /// <summary>
        /// Cached name for the 'unedit' method.
        /// </summary>
        public static readonly StringName Unedit = "unedit";
        /// <summary>
        /// Cached name for the 'is_editing' method.
        /// </summary>
        public static readonly StringName IsEditing = "is_editing";
        /// <summary>
        /// Cached name for the 'set_keep_editing_on_text_submit' method.
        /// </summary>
        public static readonly StringName SetKeepEditingOnTextSubmit = "set_keep_editing_on_text_submit";
        /// <summary>
        /// Cached name for the 'is_editing_kept_on_text_submit' method.
        /// </summary>
        public static readonly StringName IsEditingKeptOnTextSubmit = "is_editing_kept_on_text_submit";
        /// <summary>
        /// Cached name for the 'clear' method.
        /// </summary>
        public static readonly StringName Clear = "clear";
        /// <summary>
        /// Cached name for the 'select' method.
        /// </summary>
        public static readonly StringName Select = "select";
        /// <summary>
        /// Cached name for the 'select_all' method.
        /// </summary>
        public static readonly StringName SelectAll = "select_all";
        /// <summary>
        /// Cached name for the 'deselect' method.
        /// </summary>
        public static readonly StringName Deselect = "deselect";
        /// <summary>
        /// Cached name for the 'has_undo' method.
        /// </summary>
        public static readonly StringName HasUndo = "has_undo";
        /// <summary>
        /// Cached name for the 'has_redo' method.
        /// </summary>
        public static readonly StringName HasRedo = "has_redo";
        /// <summary>
        /// Cached name for the 'has_selection' method.
        /// </summary>
        public static readonly StringName HasSelection = "has_selection";
        /// <summary>
        /// Cached name for the 'get_selected_text' method.
        /// </summary>
        public static readonly StringName GetSelectedText = "get_selected_text";
        /// <summary>
        /// Cached name for the 'get_selection_from_column' method.
        /// </summary>
        public static readonly StringName GetSelectionFromColumn = "get_selection_from_column";
        /// <summary>
        /// Cached name for the 'get_selection_to_column' method.
        /// </summary>
        public static readonly StringName GetSelectionToColumn = "get_selection_to_column";
        /// <summary>
        /// Cached name for the 'set_text' method.
        /// </summary>
        public static readonly StringName SetText = "set_text";
        /// <summary>
        /// Cached name for the 'get_text' method.
        /// </summary>
        public static readonly StringName GetText = "get_text";
        /// <summary>
        /// Cached name for the 'get_draw_control_chars' method.
        /// </summary>
        public static readonly StringName GetDrawControlChars = "get_draw_control_chars";
        /// <summary>
        /// Cached name for the 'set_draw_control_chars' method.
        /// </summary>
        public static readonly StringName SetDrawControlChars = "set_draw_control_chars";
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
        /// Cached name for the 'set_placeholder' method.
        /// </summary>
        public static readonly StringName SetPlaceholder = "set_placeholder";
        /// <summary>
        /// Cached name for the 'get_placeholder' method.
        /// </summary>
        public static readonly StringName GetPlaceholder = "get_placeholder";
        /// <summary>
        /// Cached name for the 'set_caret_column' method.
        /// </summary>
        public static readonly StringName SetCaretColumn = "set_caret_column";
        /// <summary>
        /// Cached name for the 'get_caret_column' method.
        /// </summary>
        public static readonly StringName GetCaretColumn = "get_caret_column";
        /// <summary>
        /// Cached name for the 'get_next_composite_character_column' method.
        /// </summary>
        public static readonly StringName GetNextCompositeCharacterColumn = "get_next_composite_character_column";
        /// <summary>
        /// Cached name for the 'get_previous_composite_character_column' method.
        /// </summary>
        public static readonly StringName GetPreviousCompositeCharacterColumn = "get_previous_composite_character_column";
        /// <summary>
        /// Cached name for the 'get_scroll_offset' method.
        /// </summary>
        public static readonly StringName GetScrollOffset = "get_scroll_offset";
        /// <summary>
        /// Cached name for the 'set_expand_to_text_length_enabled' method.
        /// </summary>
        public static readonly StringName SetExpandToTextLengthEnabled = "set_expand_to_text_length_enabled";
        /// <summary>
        /// Cached name for the 'is_expand_to_text_length_enabled' method.
        /// </summary>
        public static readonly StringName IsExpandToTextLengthEnabled = "is_expand_to_text_length_enabled";
        /// <summary>
        /// Cached name for the 'set_caret_blink_enabled' method.
        /// </summary>
        public static readonly StringName SetCaretBlinkEnabled = "set_caret_blink_enabled";
        /// <summary>
        /// Cached name for the 'is_caret_blink_enabled' method.
        /// </summary>
        public static readonly StringName IsCaretBlinkEnabled = "is_caret_blink_enabled";
        /// <summary>
        /// Cached name for the 'set_caret_mid_grapheme_enabled' method.
        /// </summary>
        public static readonly StringName SetCaretMidGraphemeEnabled = "set_caret_mid_grapheme_enabled";
        /// <summary>
        /// Cached name for the 'is_caret_mid_grapheme_enabled' method.
        /// </summary>
        public static readonly StringName IsCaretMidGraphemeEnabled = "is_caret_mid_grapheme_enabled";
        /// <summary>
        /// Cached name for the 'set_caret_force_displayed' method.
        /// </summary>
        public static readonly StringName SetCaretForceDisplayed = "set_caret_force_displayed";
        /// <summary>
        /// Cached name for the 'is_caret_force_displayed' method.
        /// </summary>
        public static readonly StringName IsCaretForceDisplayed = "is_caret_force_displayed";
        /// <summary>
        /// Cached name for the 'set_caret_blink_interval' method.
        /// </summary>
        public static readonly StringName SetCaretBlinkInterval = "set_caret_blink_interval";
        /// <summary>
        /// Cached name for the 'get_caret_blink_interval' method.
        /// </summary>
        public static readonly StringName GetCaretBlinkInterval = "get_caret_blink_interval";
        /// <summary>
        /// Cached name for the 'set_max_length' method.
        /// </summary>
        public static readonly StringName SetMaxLength = "set_max_length";
        /// <summary>
        /// Cached name for the 'get_max_length' method.
        /// </summary>
        public static readonly StringName GetMaxLength = "get_max_length";
        /// <summary>
        /// Cached name for the 'insert_text_at_caret' method.
        /// </summary>
        public static readonly StringName InsertTextAtCaret = "insert_text_at_caret";
        /// <summary>
        /// Cached name for the 'delete_char_at_caret' method.
        /// </summary>
        public static readonly StringName DeleteCharAtCaret = "delete_char_at_caret";
        /// <summary>
        /// Cached name for the 'delete_text' method.
        /// </summary>
        public static readonly StringName DeleteText = "delete_text";
        /// <summary>
        /// Cached name for the 'set_editable' method.
        /// </summary>
        public static readonly StringName SetEditable = "set_editable";
        /// <summary>
        /// Cached name for the 'is_editable' method.
        /// </summary>
        public static readonly StringName IsEditable = "is_editable";
        /// <summary>
        /// Cached name for the 'set_secret' method.
        /// </summary>
        public static readonly StringName SetSecret = "set_secret";
        /// <summary>
        /// Cached name for the 'is_secret' method.
        /// </summary>
        public static readonly StringName IsSecret = "is_secret";
        /// <summary>
        /// Cached name for the 'set_secret_character' method.
        /// </summary>
        public static readonly StringName SetSecretCharacter = "set_secret_character";
        /// <summary>
        /// Cached name for the 'get_secret_character' method.
        /// </summary>
        public static readonly StringName GetSecretCharacter = "get_secret_character";
        /// <summary>
        /// Cached name for the 'menu_option' method.
        /// </summary>
        public static readonly StringName MenuOption = "menu_option";
        /// <summary>
        /// Cached name for the 'get_menu' method.
        /// </summary>
        public static readonly StringName GetMenu = "get_menu";
        /// <summary>
        /// Cached name for the 'is_menu_visible' method.
        /// </summary>
        public static readonly StringName IsMenuVisible = "is_menu_visible";
        /// <summary>
        /// Cached name for the 'set_context_menu_enabled' method.
        /// </summary>
        public static readonly StringName SetContextMenuEnabled = "set_context_menu_enabled";
        /// <summary>
        /// Cached name for the 'is_context_menu_enabled' method.
        /// </summary>
        public static readonly StringName IsContextMenuEnabled = "is_context_menu_enabled";
        /// <summary>
        /// Cached name for the 'set_emoji_menu_enabled' method.
        /// </summary>
        public static readonly StringName SetEmojiMenuEnabled = "set_emoji_menu_enabled";
        /// <summary>
        /// Cached name for the 'is_emoji_menu_enabled' method.
        /// </summary>
        public static readonly StringName IsEmojiMenuEnabled = "is_emoji_menu_enabled";
        /// <summary>
        /// Cached name for the 'set_backspace_deletes_composite_character_enabled' method.
        /// </summary>
        public static readonly StringName SetBackspaceDeletesCompositeCharacterEnabled = "set_backspace_deletes_composite_character_enabled";
        /// <summary>
        /// Cached name for the 'is_backspace_deletes_composite_character_enabled' method.
        /// </summary>
        public static readonly StringName IsBackspaceDeletesCompositeCharacterEnabled = "is_backspace_deletes_composite_character_enabled";
        /// <summary>
        /// Cached name for the 'set_virtual_keyboard_enabled' method.
        /// </summary>
        public static readonly StringName SetVirtualKeyboardEnabled = "set_virtual_keyboard_enabled";
        /// <summary>
        /// Cached name for the 'is_virtual_keyboard_enabled' method.
        /// </summary>
        public static readonly StringName IsVirtualKeyboardEnabled = "is_virtual_keyboard_enabled";
        /// <summary>
        /// Cached name for the 'set_virtual_keyboard_show_on_focus' method.
        /// </summary>
        public static readonly StringName SetVirtualKeyboardShowOnFocus = "set_virtual_keyboard_show_on_focus";
        /// <summary>
        /// Cached name for the 'get_virtual_keyboard_show_on_focus' method.
        /// </summary>
        public static readonly StringName GetVirtualKeyboardShowOnFocus = "get_virtual_keyboard_show_on_focus";
        /// <summary>
        /// Cached name for the 'set_virtual_keyboard_type' method.
        /// </summary>
        public static readonly StringName SetVirtualKeyboardType = "set_virtual_keyboard_type";
        /// <summary>
        /// Cached name for the 'get_virtual_keyboard_type' method.
        /// </summary>
        public static readonly StringName GetVirtualKeyboardType = "get_virtual_keyboard_type";
        /// <summary>
        /// Cached name for the 'set_clear_button_enabled' method.
        /// </summary>
        public static readonly StringName SetClearButtonEnabled = "set_clear_button_enabled";
        /// <summary>
        /// Cached name for the 'is_clear_button_enabled' method.
        /// </summary>
        public static readonly StringName IsClearButtonEnabled = "is_clear_button_enabled";
        /// <summary>
        /// Cached name for the 'set_shortcut_keys_enabled' method.
        /// </summary>
        public static readonly StringName SetShortcutKeysEnabled = "set_shortcut_keys_enabled";
        /// <summary>
        /// Cached name for the 'is_shortcut_keys_enabled' method.
        /// </summary>
        public static readonly StringName IsShortcutKeysEnabled = "is_shortcut_keys_enabled";
        /// <summary>
        /// Cached name for the 'set_middle_mouse_paste_enabled' method.
        /// </summary>
        public static readonly StringName SetMiddleMousePasteEnabled = "set_middle_mouse_paste_enabled";
        /// <summary>
        /// Cached name for the 'is_middle_mouse_paste_enabled' method.
        /// </summary>
        public static readonly StringName IsMiddleMousePasteEnabled = "is_middle_mouse_paste_enabled";
        /// <summary>
        /// Cached name for the 'set_selecting_enabled' method.
        /// </summary>
        public static readonly StringName SetSelectingEnabled = "set_selecting_enabled";
        /// <summary>
        /// Cached name for the 'is_selecting_enabled' method.
        /// </summary>
        public static readonly StringName IsSelectingEnabled = "is_selecting_enabled";
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
        /// Cached name for the 'set_right_icon' method.
        /// </summary>
        public static readonly StringName SetRightIcon = "set_right_icon";
        /// <summary>
        /// Cached name for the 'get_right_icon' method.
        /// </summary>
        public static readonly StringName GetRightIcon = "get_right_icon";
        /// <summary>
        /// Cached name for the 'set_icon_expand_mode' method.
        /// </summary>
        public static readonly StringName SetIconExpandMode = "set_icon_expand_mode";
        /// <summary>
        /// Cached name for the 'get_icon_expand_mode' method.
        /// </summary>
        public static readonly StringName GetIconExpandMode = "get_icon_expand_mode";
        /// <summary>
        /// Cached name for the 'set_right_icon_scale' method.
        /// </summary>
        public static readonly StringName SetRightIconScale = "set_right_icon_scale";
        /// <summary>
        /// Cached name for the 'get_right_icon_scale' method.
        /// </summary>
        public static readonly StringName GetRightIconScale = "get_right_icon_scale";
        /// <summary>
        /// Cached name for the 'set_flat' method.
        /// </summary>
        public static readonly StringName SetFlat = "set_flat";
        /// <summary>
        /// Cached name for the 'is_flat' method.
        /// </summary>
        public static readonly StringName IsFlat = "is_flat";
        /// <summary>
        /// Cached name for the 'set_select_all_on_focus' method.
        /// </summary>
        public static readonly StringName SetSelectAllOnFocus = "set_select_all_on_focus";
        /// <summary>
        /// Cached name for the 'is_select_all_on_focus' method.
        /// </summary>
        public static readonly StringName IsSelectAllOnFocus = "is_select_all_on_focus";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Control.SignalName
    {
        /// <summary>
        /// Cached name for the 'text_changed' signal.
        /// </summary>
        public static readonly StringName TextChanged = "text_changed";
        /// <summary>
        /// Cached name for the 'text_change_rejected' signal.
        /// </summary>
        public static readonly StringName TextChangeRejected = "text_change_rejected";
        /// <summary>
        /// Cached name for the 'text_submitted' signal.
        /// </summary>
        public static readonly StringName TextSubmitted = "text_submitted";
        /// <summary>
        /// Cached name for the 'editing_toggled' signal.
        /// </summary>
        public static readonly StringName EditingToggled = "editing_toggled";
    }
}
