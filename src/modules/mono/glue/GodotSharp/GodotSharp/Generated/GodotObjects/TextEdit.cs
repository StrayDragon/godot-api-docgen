namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A multiline text editor. It also has limited facilities for editing code, such as syntax highlighting support. For more advanced facilities for editing code, see <see cref="Godot.CodeEdit"/>.</para>
/// <para>While entering text, it is possible to insert special characters using Unicode, OEM or Windows alt codes:</para>
/// <para>- To enter Unicode codepoints, hold Alt and type the codepoint on the numpad. For example, to enter the character <c>á</c> (U+00E1), hold Alt and type +E1 on the numpad (the leading zeroes can be omitted).</para>
/// <para>- To enter OEM codepoints, hold Alt and type the code on the numpad. For example, to enter the character <c>á</c> (OEM 160), hold Alt and type <c>160</c> on the numpad.</para>
/// <para>- To enter Windows codepoints, hold Alt and type the code on the numpad. For example, to enter the character <c>á</c> (Windows 0225), hold Alt and type 0, 2, 2, 5 on the numpad. The leading zero here must <b>not</b> be omitted, as this is how Windows codepoints are distinguished from OEM codepoints.</para>
/// <para><b>Note:</b> Most viewport, caret, and edit methods contain a <c>caret_index</c> argument for <see cref="Godot.TextEdit.CaretMultiple"/> support. The argument should be one of the following: <c>-1</c> for all carets, <c>0</c> for the main caret, or greater than <c>0</c> for secondary carets in the order they were created.</para>
/// <para><b>Note:</b> When holding down Alt, the vertical scroll wheel will scroll 5 times as fast as it would normally do. This also works in the Godot script editor.</para>
/// </summary>
public partial class TextEdit : Control
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
        /// <para>Pastes the clipboard text over the selected text (or at the cursor's position).</para>
        /// </summary>
        Paste = 2,
        /// <summary>
        /// <para>Erases the whole <see cref="Godot.TextEdit"/> text.</para>
        /// </summary>
        Clear = 3,
        /// <summary>
        /// <para>Selects the whole <see cref="Godot.TextEdit"/> text.</para>
        /// </summary>
        SelectAll = 4,
        /// <summary>
        /// <para>Undoes the previous action.</para>
        /// </summary>
        Undo = 5,
        /// <summary>
        /// <para>Redoes the previous action.</para>
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
        /// <para>Represents the size of the <see cref="Godot.TextEdit.MenuItems"/> enum.</para>
        /// </summary>
        Max = 31
    }

    public enum EditAction : long
    {
        /// <summary>
        /// <para>No current action.</para>
        /// </summary>
        None = 0,
        /// <summary>
        /// <para>A typing action.</para>
        /// </summary>
        Typing = 1,
        /// <summary>
        /// <para>A backwards delete action.</para>
        /// </summary>
        Backspace = 2,
        /// <summary>
        /// <para>A forward delete action.</para>
        /// </summary>
        Delete = 3
    }

    public enum SearchFlags : long
    {
        /// <summary>
        /// <para>Match case when searching.</para>
        /// </summary>
        MatchCase = 1,
        /// <summary>
        /// <para>Match whole words when searching.</para>
        /// </summary>
        WholeWords = 2,
        /// <summary>
        /// <para>Search from end to beginning.</para>
        /// </summary>
        Backwards = 4
    }

    public enum CaretTypeEnum : long
    {
        /// <summary>
        /// <para>Vertical line caret.</para>
        /// </summary>
        Line = 0,
        /// <summary>
        /// <para>Block caret.</para>
        /// </summary>
        Block = 1
    }

    public enum SelectionMode : long
    {
        /// <summary>
        /// <para>Not selecting.</para>
        /// </summary>
        None = 0,
        /// <summary>
        /// <para>Select as if <c>shift</c> is pressed.</para>
        /// </summary>
        Shift = 1,
        /// <summary>
        /// <para>Select single characters as if the user single clicked.</para>
        /// </summary>
        Pointer = 2,
        /// <summary>
        /// <para>Select whole words as if the user double clicked.</para>
        /// </summary>
        Word = 3,
        /// <summary>
        /// <para>Select whole lines as if the user triple clicked.</para>
        /// </summary>
        Line = 4
    }

    public enum LineWrappingMode : long
    {
        /// <summary>
        /// <para>Line wrapping is disabled.</para>
        /// </summary>
        None = 0,
        /// <summary>
        /// <para>Line wrapping occurs at the control boundary, beyond what would normally be visible.</para>
        /// </summary>
        Boundary = 1
    }

    public enum GutterType : long
    {
        /// <summary>
        /// <para>When a gutter is set to string using <see cref="Godot.TextEdit.SetGutterType(int, TextEdit.GutterType)"/>, it is used to contain text set via the <see cref="Godot.TextEdit.SetLineGutterText(int, int, string)"/> method.</para>
        /// </summary>
        String = 0,
        /// <summary>
        /// <para>When a gutter is set to icon using <see cref="Godot.TextEdit.SetGutterType(int, TextEdit.GutterType)"/>, it is used to contain an icon set via the <see cref="Godot.TextEdit.SetLineGutterIcon(int, int, Texture2D)"/> method.</para>
        /// </summary>
        Icon = 1,
        /// <summary>
        /// <para>When a gutter is set to custom using <see cref="Godot.TextEdit.SetGutterType(int, TextEdit.GutterType)"/>, it is used to contain custom visuals controlled by a callback method set via the <see cref="Godot.TextEdit.SetGutterCustomDraw(int, Callable)"/> method.</para>
        /// </summary>
        Custom = 2
    }

    /// <summary>
    /// <para>String value of the <see cref="Godot.TextEdit"/>.</para>
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
    /// <para>Text shown when the <see cref="Godot.TextEdit"/> is empty. It is <b>not</b> the <see cref="Godot.TextEdit"/>'s default value (see <see cref="Godot.TextEdit.Text"/>).</para>
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
    /// <para>If <see langword="true"/> and <see cref="Godot.TextEdit.CaretMidGrapheme"/> is <see langword="false"/>, backspace deletes an entire composite character such as ❤️‍🩹, instead of deleting part of the composite character.</para>
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
    /// <para>If <see langword="true"/>, text can be selected.</para>
    /// <para>If <see langword="false"/>, text can not be selected by the user or by the <see cref="Godot.TextEdit.Select(int, int, int, int, int)"/> or <see cref="Godot.TextEdit.SelectAll()"/> methods.</para>
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
    /// <para>If <see langword="true"/>, allow drag and drop of selected text. Text can still be dropped from other sources.</para>
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
    /// <para>If <see langword="true"/>, copying or cutting without a selection is performed on all lines with a caret. Otherwise, copy and cut require a selection.</para>
    /// </summary>
    public bool EmptySelectionClipboardEnabled
    {
        get
        {
            return IsEmptySelectionClipboardEnabled();
        }
        set
        {
            SetEmptySelectionClipboardEnabled(value);
        }
    }

    /// <summary>
    /// <para>Sets the line wrapping mode to use.</para>
    /// </summary>
    public TextEdit.LineWrappingMode WrapMode
    {
        get
        {
            return GetLineWrappingMode();
        }
        set
        {
            SetLineWrappingMode(value);
        }
    }

    /// <summary>
    /// <para>If <see cref="Godot.TextEdit.WrapMode"/> is set to <see cref="Godot.TextEdit.LineWrappingMode.Boundary"/>, sets text wrapping mode.</para>
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
    /// <para>If <see langword="true"/>, all wrapped lines are indented to the same amount as the unwrapped line.</para>
    /// </summary>
    public bool IndentWrappedLines
    {
        get
        {
            return IsIndentWrappedLines();
        }
        set
        {
            SetIndentWrappedLines(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, <c>ProjectSettings.input/ui_text_indent</c> input <c>Tab</c> character, otherwise it moves keyboard focus to the next <see cref="Godot.Control"/> in the scene.</para>
    /// </summary>
    public bool TabInputMode
    {
        get
        {
            return GetTabInputMode();
        }
        set
        {
            SetTabInputMode(value);
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
    /// <para>Scroll smoothly over the text rather than jumping to the next location.</para>
    /// </summary>
    public bool ScrollSmooth
    {
        get
        {
            return IsSmoothScrollEnabled();
        }
        set
        {
            SetSmoothScrollEnabled(value);
        }
    }

    /// <summary>
    /// <para>Sets the scroll speed with the minimap or when <see cref="Godot.TextEdit.ScrollSmooth"/> is enabled.</para>
    /// </summary>
    public float ScrollVScrollSpeed
    {
        get
        {
            return GetVScrollSpeed();
        }
        set
        {
            SetVScrollSpeed(value);
        }
    }

    /// <summary>
    /// <para>Allow scrolling past the last line into "virtual" space.</para>
    /// </summary>
    public bool ScrollPastEndOfFile
    {
        get
        {
            return IsScrollPastEndOfFileEnabled();
        }
        set
        {
            SetScrollPastEndOfFileEnabled(value);
        }
    }

    /// <summary>
    /// <para>If there is a vertical scrollbar, this determines the current vertical scroll value in line numbers, starting at 0 for the top line.</para>
    /// </summary>
    public double ScrollVertical
    {
        get
        {
            return GetVScroll();
        }
        set
        {
            SetVScroll(value);
        }
    }

    /// <summary>
    /// <para>If there is a horizontal scrollbar, this determines the current horizontal scroll value in pixels.</para>
    /// </summary>
    public int ScrollHorizontal
    {
        get
        {
            return GetHScroll();
        }
        set
        {
            SetHScroll(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, <see cref="Godot.TextEdit"/> will disable vertical scroll and fit minimum height to the number of visible lines. When both this property and <see cref="Godot.TextEdit.ScrollFitContentWidth"/> are <see langword="true"/>, no scrollbars will be displayed.</para>
    /// </summary>
    public bool ScrollFitContentHeight
    {
        get
        {
            return IsFitContentHeightEnabled();
        }
        set
        {
            SetFitContentHeightEnabled(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, <see cref="Godot.TextEdit"/> will disable horizontal scroll and fit minimum width to the widest line in the text. When both this property and <see cref="Godot.TextEdit.ScrollFitContentHeight"/> are <see langword="true"/>, no scrollbars will be displayed.</para>
    /// </summary>
    public bool ScrollFitContentWidth
    {
        get
        {
            return IsFitContentWidthEnabled();
        }
        set
        {
            SetFitContentWidthEnabled(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, a minimap is shown, providing an outline of your source code. The minimap uses a fixed-width text size.</para>
    /// </summary>
    public bool MinimapDraw
    {
        get
        {
            return IsDrawingMinimap();
        }
        set
        {
            SetDrawMinimap(value);
        }
    }

    /// <summary>
    /// <para>The width, in pixels, of the minimap.</para>
    /// </summary>
    public int MinimapWidth
    {
        get
        {
            return GetMinimapWidth();
        }
        set
        {
            SetMinimapWidth(value);
        }
    }

    /// <summary>
    /// <para>Set the type of caret to draw.</para>
    /// </summary>
    public TextEdit.CaretTypeEnum CaretType
    {
        get
        {
            return GetCaretType();
        }
        set
        {
            SetCaretType(value);
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
    /// <para>If <see langword="true"/>, caret will be visible when <see cref="Godot.TextEdit.Editable"/> is disabled.</para>
    /// </summary>
    public bool CaretDrawWhenEditableDisabled
    {
        get
        {
            return IsDrawingCaretWhenEditableDisabled();
        }
        set
        {
            SetDrawCaretWhenEditableDisabled(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, a right-click moves the caret at the mouse position before displaying the context menu.</para>
    /// <para>If <see langword="false"/>, the context menu ignores mouse location.</para>
    /// </summary>
    public bool CaretMoveOnRightClick
    {
        get
        {
            return IsMoveCaretOnRightClickEnabled();
        }
        set
        {
            SetMoveCaretOnRightClickEnabled(value);
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
    /// <para>If <see langword="true"/>, multiple carets are allowed. Left-clicking with Alt adds a new caret. See <see cref="Godot.TextEdit.AddCaret(int, int)"/> and <see cref="Godot.TextEdit.GetCaretCount()"/>.</para>
    /// </summary>
    public bool CaretMultiple
    {
        get
        {
            return IsMultipleCaretsEnabled();
        }
        set
        {
            SetMultipleCaretsEnabled(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="false"/>, using Ctrl + Left or Ctrl + Right (Cmd + Left or Cmd + Right on macOS) bindings will stop moving caret only if a space or punctuation is detected. If <see langword="true"/>, it will also stop the caret if a character is part of <c>!"#$%&amp;'()*+,-./:;&lt;=&gt;?@[\]^`{|}~</c>, the Unicode General Punctuation table, or the Unicode CJK Punctuation table. Useful for subword moving. This behavior also will be applied to the behavior of text selection.</para>
    /// </summary>
    public bool UseDefaultWordSeparators
    {
        get
        {
            return IsDefaultWordSeparatorsEnabled();
        }
        set
        {
            SetUseDefaultWordSeparators(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="false"/>, using Ctrl + Left or Ctrl + Right (Cmd + Left or Cmd + Right on macOS) bindings will use the behavior of <see cref="Godot.TextEdit.UseDefaultWordSeparators"/>. If <see langword="true"/>, it will also stop the caret if a character within <see cref="Godot.TextEdit.CustomWordSeparators"/> is detected. Useful for subword moving. This behavior also will be applied to the behavior of text selection.</para>
    /// </summary>
    public bool UseCustomWordSeparators
    {
        get
        {
            return IsCustomWordSeparatorsEnabled();
        }
        set
        {
            SetUseCustomWordSeparators(value);
        }
    }

    /// <summary>
    /// <para>The characters to consider as word delimiters if <see cref="Godot.TextEdit.UseCustomWordSeparators"/> is <see langword="true"/>. The characters should be defined without separation, for example <c>#_!</c>.</para>
    /// </summary>
    public string CustomWordSeparators
    {
        get
        {
            return GetCustomWordSeparators();
        }
        set
        {
            SetCustomWordSeparators(value);
        }
    }

    /// <summary>
    /// <para>The syntax highlighter to use.</para>
    /// <para><b>Note:</b> A <see cref="Godot.SyntaxHighlighter"/> instance should not be used across multiple <see cref="Godot.TextEdit"/> nodes.</para>
    /// </summary>
    public SyntaxHighlighter SyntaxHighlighter
    {
        get
        {
            return GetSyntaxHighlighter();
        }
        set
        {
            SetSyntaxHighlighter(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, all occurrences of the selected text will be highlighted.</para>
    /// </summary>
    public bool HighlightAllOccurrences
    {
        get
        {
            return IsHighlightAllOccurrencesEnabled();
        }
        set
        {
            SetHighlightAllOccurrences(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the line containing the cursor is highlighted.</para>
    /// </summary>
    public bool HighlightCurrentLine
    {
        get
        {
            return IsHighlightCurrentLineEnabled();
        }
        set
        {
            SetHighlightCurrentLine(value);
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
    /// <para>If <see langword="true"/>, the "tab" character will have a visible representation.</para>
    /// </summary>
    public bool DrawTabs
    {
        get
        {
            return IsDrawingTabs();
        }
        set
        {
            SetDrawTabs(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the "space" character will have a visible representation.</para>
    /// </summary>
    public bool DrawSpaces
    {
        get
        {
            return IsDrawingSpaces();
        }
        set
        {
            SetDrawSpaces(value);
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

    private static readonly System.Type CachedType = typeof(TextEdit);

    private static readonly StringName NativeName = "TextEdit";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public TextEdit() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal TextEdit(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal TextEdit(bool memoryOwn) : base(memoryOwn) { }

    /// <summary>
    /// <para>Override this method to define what happens when the user presses the backspace key.</para>
    /// </summary>
    public virtual void _Backspace(int caretIndex)
    {
    }

    /// <summary>
    /// <para>Override this method to define what happens when the user performs a copy operation.</para>
    /// </summary>
    public virtual void _Copy(int caretIndex)
    {
    }

    /// <summary>
    /// <para>Override this method to define what happens when the user performs a cut operation.</para>
    /// </summary>
    public virtual void _Cut(int caretIndex)
    {
    }

    /// <summary>
    /// <para>Override this method to define what happens when the user types in the provided key <paramref name="unicodeChar"/>.</para>
    /// </summary>
    public virtual void _HandleUnicodeInput(int unicodeChar, int caretIndex)
    {
    }

    /// <summary>
    /// <para>Override this method to define what happens when the user performs a paste operation.</para>
    /// </summary>
    public virtual void _Paste(int caretIndex)
    {
    }

    /// <summary>
    /// <para>Override this method to define what happens when the user performs a paste operation with middle mouse button.</para>
    /// <para><b>Note:</b> This method is only implemented on Linux.</para>
    /// </summary>
    public virtual void _PastePrimaryClipboard(int caretIndex)
    {
    }

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
    /// <para>Applies text from the <a href="https://en.wikipedia.org/wiki/Input_method">Input Method Editor</a> (IME) to each caret and closes the IME if it is open.</para>
    /// </summary>
    public void ApplyIme()
    {
        NativeCalls.godot_icall_0_3(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEditable, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEditable(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind3, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsEditable, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsEditable()
    {
        return NativeCalls.godot_icall_0_15(MethodBind4, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTextDirection, 119160795ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTextDirection(Control.TextDirection direction)
    {
        NativeCalls.godot_icall_1_38(MethodBind5, GodotObject.GetPtr(this), (int)direction);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTextDirection, 797257663ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Control.TextDirection GetTextDirection()
    {
        return (Control.TextDirection)NativeCalls.godot_icall_0_39(MethodBind6, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLanguage, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetLanguage(string language)
    {
        NativeCalls.godot_icall_1_57(MethodBind7, GodotObject.GetPtr(this), language);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLanguage, 201670096ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetLanguage()
    {
        return NativeCalls.godot_icall_0_58(MethodBind8, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetStructuredTextBidiOverride, 55961453ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetStructuredTextBidiOverride(TextServer.StructuredTextParser parser)
    {
        NativeCalls.godot_icall_1_38(MethodBind9, GodotObject.GetPtr(this), (int)parser);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetStructuredTextBidiOverride, 3385126229ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public TextServer.StructuredTextParser GetStructuredTextBidiOverride()
    {
        return (TextServer.StructuredTextParser)NativeCalls.godot_icall_0_39(MethodBind10, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetStructuredTextBidiOverrideOptions, 381264803ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetStructuredTextBidiOverrideOptions(Godot.Collections.Array args)
    {
        NativeCalls.godot_icall_1_138(MethodBind11, GodotObject.GetPtr(this), (godot_array)(args ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetStructuredTextBidiOverrideOptions, 3995934104ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Godot.Collections.Array GetStructuredTextBidiOverrideOptions()
    {
        return NativeCalls.godot_icall_0_120(MethodBind12, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTabSize, 1286410249ul);

    /// <summary>
    /// <para>Sets the tab size for the <see cref="Godot.TextEdit"/> to use.</para>
    /// </summary>
    public void SetTabSize(int size)
    {
        NativeCalls.godot_icall_1_38(MethodBind13, GodotObject.GetPtr(this), size);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTabSize, 3905245786ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.TextEdit"/>'s' tab size.</para>
    /// </summary>
    public int GetTabSize()
    {
        return NativeCalls.godot_icall_0_39(MethodBind14, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetIndentWrappedLines, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetIndentWrappedLines(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind15, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsIndentWrappedLines, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsIndentWrappedLines()
    {
        return NativeCalls.godot_icall_0_15(MethodBind16, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTabInputMode, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTabInputMode(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind17, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTabInputMode, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetTabInputMode()
    {
        return NativeCalls.godot_icall_0_15(MethodBind18, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetOvertypeModeEnabled, 2586408642ul);

    /// <summary>
    /// <para>If <see langword="true"/>, enables overtype mode. In this mode, typing overrides existing text instead of inserting text. The <c>ProjectSettings.input/ui_text_toggle_insert_mode</c> action toggles overtype mode. See <see cref="Godot.TextEdit.IsOvertypeModeEnabled()"/>.</para>
    /// </summary>
    public void SetOvertypeModeEnabled(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind19, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsOvertypeModeEnabled, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if overtype mode is enabled. See <see cref="Godot.TextEdit.SetOvertypeModeEnabled(bool)"/>.</para>
    /// </summary>
    public bool IsOvertypeModeEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind20, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetContextMenuEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetContextMenuEnabled(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind21, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsContextMenuEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsContextMenuEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind22, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEmojiMenuEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEmojiMenuEnabled(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind23, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsEmojiMenuEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsEmojiMenuEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind24, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBackspaceDeletesCompositeCharacterEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetBackspaceDeletesCompositeCharacterEnabled(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind25, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsBackspaceDeletesCompositeCharacterEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsBackspaceDeletesCompositeCharacterEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind26, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetShortcutKeysEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetShortcutKeysEnabled(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind27, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsShortcutKeysEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsShortcutKeysEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind28, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVirtualKeyboardEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetVirtualKeyboardEnabled(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind29, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsVirtualKeyboardEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsVirtualKeyboardEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind30, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVirtualKeyboardShowOnFocus, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetVirtualKeyboardShowOnFocus(bool showOnFocus)
    {
        NativeCalls.godot_icall_1_14(MethodBind31, GodotObject.GetPtr(this), showOnFocus.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind32 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVirtualKeyboardShowOnFocus, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetVirtualKeyboardShowOnFocus()
    {
        return NativeCalls.godot_icall_0_15(MethodBind32, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind33 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMiddleMousePasteEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMiddleMousePasteEnabled(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind33, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind34 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsMiddleMousePasteEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsMiddleMousePasteEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind34, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind35 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEmptySelectionClipboardEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEmptySelectionClipboardEnabled(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind35, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind36 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsEmptySelectionClipboardEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsEmptySelectionClipboardEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind36, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind37 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Clear, 3218959716ul);

    /// <summary>
    /// <para>Performs a full reset of <see cref="Godot.TextEdit"/>, including undo history.</para>
    /// </summary>
    public void Clear()
    {
        NativeCalls.godot_icall_0_3(MethodBind37, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind38 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetText, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetText(string text)
    {
        NativeCalls.godot_icall_1_57(MethodBind38, GodotObject.GetPtr(this), text);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind39 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetText, 201670096ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetText()
    {
        return NativeCalls.godot_icall_0_58(MethodBind39, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind40 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLineCount, 3905245786ul);

    /// <summary>
    /// <para>Returns the number of lines in the text.</para>
    /// </summary>
    public int GetLineCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind40, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind41 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPlaceholder, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPlaceholder(string text)
    {
        NativeCalls.godot_icall_1_57(MethodBind41, GodotObject.GetPtr(this), text);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind42 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPlaceholder, 201670096ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetPlaceholder()
    {
        return NativeCalls.godot_icall_0_58(MethodBind42, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind43 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLine, 501894301ul);

    /// <summary>
    /// <para>Sets the text for a specific <paramref name="line"/>.</para>
    /// <para>Carets on the line will attempt to keep their visual x position.</para>
    /// </summary>
    public void SetLine(int line, string newText)
    {
        NativeCalls.godot_icall_2_181(MethodBind43, GodotObject.GetPtr(this), line, newText);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind44 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLine, 844755477ul);

    /// <summary>
    /// <para>Returns the text of a specific line.</para>
    /// </summary>
    public string GetLine(int line)
    {
        return NativeCalls.godot_icall_1_133(MethodBind44, GodotObject.GetPtr(this), line);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind45 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLineWithIme, 844755477ul);

    /// <summary>
    /// <para>Returns line text as it is currently displayed, including IME composition string.</para>
    /// </summary>
    public string GetLineWithIme(int line)
    {
        return NativeCalls.godot_icall_1_133(MethodBind45, GodotObject.GetPtr(this), line);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind46 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLineWidth, 688195400ul);

    /// <summary>
    /// <para>Returns the width in pixels of the <paramref name="wrapIndex"/> on <paramref name="line"/>.</para>
    /// </summary>
    public int GetLineWidth(int line, int wrapIndex = -1)
    {
        return NativeCalls.godot_icall_2_73(MethodBind46, GodotObject.GetPtr(this), line, wrapIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind47 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLineHeight, 3905245786ul);

    /// <summary>
    /// <para>Returns the maximum value of the line height among all lines.</para>
    /// <para><b>Note:</b> The return value is influenced by <c>line_spacing</c> and <c>font_size</c>. And it will not be less than <c>1</c>.</para>
    /// </summary>
    public int GetLineHeight()
    {
        return NativeCalls.godot_icall_0_39(MethodBind47, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind48 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetIndentLevel, 923996154ul);

    /// <summary>
    /// <para>Returns the indent level of the given line. This is the number of spaces and tabs at the beginning of the line, with the tabs taking the tab size into account (see <see cref="Godot.TextEdit.GetTabSize()"/>).</para>
    /// </summary>
    public int GetIndentLevel(int line)
    {
        return NativeCalls.godot_icall_1_60(MethodBind48, GodotObject.GetPtr(this), line);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind49 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFirstNonWhiteSpaceColumn, 923996154ul);

    /// <summary>
    /// <para>Returns the first column containing a non-whitespace character on the given line. If there is only whitespace, returns the number of characters.</para>
    /// </summary>
    public int GetFirstNonWhiteSpaceColumn(int line)
    {
        return NativeCalls.godot_icall_1_60(MethodBind49, GodotObject.GetPtr(this), line);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind50 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SwapLines, 3937882851ul);

    /// <summary>
    /// <para>Swaps the two lines. Carets will be swapped with the lines.</para>
    /// </summary>
    public void SwapLines(int fromLine, int toLine)
    {
        NativeCalls.godot_icall_2_59(MethodBind50, GodotObject.GetPtr(this), fromLine, toLine);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind51 = ClassDB_get_method_with_compatibility(NativeName, MethodName.InsertLineAt, 501894301ul);

    /// <summary>
    /// <para>Inserts a new line with <paramref name="text"/> at <paramref name="line"/>.</para>
    /// </summary>
    public void InsertLineAt(int line, string text)
    {
        NativeCalls.godot_icall_2_181(MethodBind51, GodotObject.GetPtr(this), line, text);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind52 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveLineAt, 972357352ul);

    /// <summary>
    /// <para>Removes the line of text at <paramref name="line"/>. Carets on this line will attempt to match their previous visual x position.</para>
    /// <para>If <paramref name="moveCaretsDown"/> is <see langword="true"/> carets will move to the next line down, otherwise carets will move up.</para>
    /// </summary>
    public void RemoveLineAt(int line, bool moveCaretsDown = true)
    {
        NativeCalls.godot_icall_2_61(MethodBind52, GodotObject.GetPtr(this), line, moveCaretsDown.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind53 = ClassDB_get_method_with_compatibility(NativeName, MethodName.InsertTextAtCaret, 2697778442ul);

    /// <summary>
    /// <para>Insert the specified text at the caret position.</para>
    /// </summary>
    public void InsertTextAtCaret(string text, int caretIndex = -1)
    {
        NativeCalls.godot_icall_2_400(MethodBind53, GodotObject.GetPtr(this), text, caretIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind54 = ClassDB_get_method_with_compatibility(NativeName, MethodName.InsertText, 1881564334ul);

    /// <summary>
    /// <para>Inserts the <paramref name="text"/> at <paramref name="line"/> and <paramref name="column"/>.</para>
    /// <para>If <paramref name="beforeSelectionBegin"/> is <see langword="true"/>, carets and selections that begin at <paramref name="line"/> and <paramref name="column"/> will moved to the end of the inserted text, along with all carets after it.</para>
    /// <para>If <paramref name="beforeSelectionEnd"/> is <see langword="true"/>, selections that end at <paramref name="line"/> and <paramref name="column"/> will be extended to the end of the inserted text. These parameters can be used to insert text inside of or outside of selections.</para>
    /// </summary>
    public void InsertText(string text, int line, int column, bool beforeSelectionBegin = true, bool beforeSelectionEnd = false)
    {
        NativeCalls.godot_icall_5_1299(MethodBind54, GodotObject.GetPtr(this), text, line, column, beforeSelectionBegin.ToGodotBool(), beforeSelectionEnd.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind55 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveText, 4275841770ul);

    /// <summary>
    /// <para>Removes text between the given positions.</para>
    /// </summary>
    public void RemoveText(int fromLine, int fromColumn, int toLine, int toColumn)
    {
        NativeCalls.godot_icall_4_149(MethodBind55, GodotObject.GetPtr(this), fromLine, fromColumn, toLine, toColumn);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind56 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLastUnhiddenLine, 3905245786ul);

    /// <summary>
    /// <para>Returns the last unhidden line in the entire <see cref="Godot.TextEdit"/>.</para>
    /// </summary>
    public int GetLastUnhiddenLine()
    {
        return NativeCalls.godot_icall_0_39(MethodBind56, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind57 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNextVisibleLineOffsetFrom, 3175239445ul);

    /// <summary>
    /// <para>Returns the count to the next visible line from <paramref name="line"/> to <c>line + visible_amount</c>. Can also count backwards. For example if a <see cref="Godot.TextEdit"/> has 5 lines with lines 2 and 3 hidden, calling this with <c>line = 1, visible_amount = 1</c> would return 3.</para>
    /// </summary>
    public int GetNextVisibleLineOffsetFrom(int line, int visibleAmount)
    {
        return NativeCalls.godot_icall_2_73(MethodBind57, GodotObject.GetPtr(this), line, visibleAmount);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind58 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNextVisibleLineIndexOffsetFrom, 3386475622ul);

    /// <summary>
    /// <para>Similar to <see cref="Godot.TextEdit.GetNextVisibleLineOffsetFrom(int, int)"/>, but takes into account the line wrap indexes. In the returned vector, <c>x</c> is the line, <c>y</c> is the wrap index.</para>
    /// </summary>
    public Vector2I GetNextVisibleLineIndexOffsetFrom(int line, int wrapIndex, int visibleAmount)
    {
        return NativeCalls.godot_icall_3_1300(MethodBind58, GodotObject.GetPtr(this), line, wrapIndex, visibleAmount);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind59 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Backspace, 1025054187ul);

    /// <summary>
    /// <para>Called when the user presses the backspace key. Can be overridden with <see cref="Godot.TextEdit._Backspace(int)"/>.</para>
    /// </summary>
    public void Backspace(int caretIndex = -1)
    {
        NativeCalls.godot_icall_1_38(MethodBind59, GodotObject.GetPtr(this), caretIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind60 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Cut, 1025054187ul);

    /// <summary>
    /// <para>Cut's the current selection. Can be overridden with <see cref="Godot.TextEdit._Cut(int)"/>.</para>
    /// </summary>
    public void Cut(int caretIndex = -1)
    {
        NativeCalls.godot_icall_1_38(MethodBind60, GodotObject.GetPtr(this), caretIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind61 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Copy, 1025054187ul);

    /// <summary>
    /// <para>Copies the current text selection. Can be overridden with <see cref="Godot.TextEdit._Copy(int)"/>.</para>
    /// </summary>
    public void Copy(int caretIndex = -1)
    {
        NativeCalls.godot_icall_1_38(MethodBind61, GodotObject.GetPtr(this), caretIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind62 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Paste, 1025054187ul);

    /// <summary>
    /// <para>Paste at the current location. Can be overridden with <see cref="Godot.TextEdit._Paste(int)"/>.</para>
    /// </summary>
    public void Paste(int caretIndex = -1)
    {
        NativeCalls.godot_icall_1_38(MethodBind62, GodotObject.GetPtr(this), caretIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind63 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PastePrimaryClipboard, 1025054187ul);

    /// <summary>
    /// <para>Pastes the primary clipboard.</para>
    /// </summary>
    public void PastePrimaryClipboard(int caretIndex = -1)
    {
        NativeCalls.godot_icall_1_38(MethodBind63, GodotObject.GetPtr(this), caretIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind64 = ClassDB_get_method_with_compatibility(NativeName, MethodName.StartAction, 2834827583ul);

    /// <summary>
    /// <para>Starts an action, will end the current action if <paramref name="action"/> is different.</para>
    /// <para>An action will also end after a call to <see cref="Godot.TextEdit.EndAction()"/>, after <c>ProjectSettings.gui/timers/text_edit_idle_detect_sec</c> is triggered or a new undoable step outside the <see cref="Godot.TextEdit.StartAction(TextEdit.EditAction)"/> and <see cref="Godot.TextEdit.EndAction()"/> calls.</para>
    /// </summary>
    public void StartAction(TextEdit.EditAction action)
    {
        NativeCalls.godot_icall_1_38(MethodBind64, GodotObject.GetPtr(this), (int)action);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind65 = ClassDB_get_method_with_compatibility(NativeName, MethodName.EndAction, 3218959716ul);

    /// <summary>
    /// <para>Marks the end of steps in the current action started with <see cref="Godot.TextEdit.StartAction(TextEdit.EditAction)"/>.</para>
    /// </summary>
    public void EndAction()
    {
        NativeCalls.godot_icall_0_3(MethodBind65, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind66 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BeginComplexOperation, 3218959716ul);

    /// <summary>
    /// <para>Starts a multipart edit. All edits will be treated as one action until <see cref="Godot.TextEdit.EndComplexOperation()"/> is called.</para>
    /// </summary>
    public void BeginComplexOperation()
    {
        NativeCalls.godot_icall_0_3(MethodBind66, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind67 = ClassDB_get_method_with_compatibility(NativeName, MethodName.EndComplexOperation, 3218959716ul);

    /// <summary>
    /// <para>Ends a multipart edit, started with <see cref="Godot.TextEdit.BeginComplexOperation()"/>. If called outside a complex operation, the current operation is pushed onto the undo/redo stack.</para>
    /// </summary>
    public void EndComplexOperation()
    {
        NativeCalls.godot_icall_0_3(MethodBind67, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind68 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasUndo, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if an "undo" action is available.</para>
    /// </summary>
    public bool HasUndo()
    {
        return NativeCalls.godot_icall_0_15(MethodBind68, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind69 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasRedo, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if a "redo" action is available.</para>
    /// </summary>
    public bool HasRedo()
    {
        return NativeCalls.godot_icall_0_15(MethodBind69, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind70 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Undo, 3218959716ul);

    /// <summary>
    /// <para>Perform undo operation.</para>
    /// </summary>
    public void Undo()
    {
        NativeCalls.godot_icall_0_3(MethodBind70, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind71 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Redo, 3218959716ul);

    /// <summary>
    /// <para>Perform redo operation.</para>
    /// </summary>
    public void Redo()
    {
        NativeCalls.godot_icall_0_3(MethodBind71, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind72 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ClearUndoHistory, 3218959716ul);

    /// <summary>
    /// <para>Clears the undo history.</para>
    /// </summary>
    public void ClearUndoHistory()
    {
        NativeCalls.godot_icall_0_3(MethodBind72, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind73 = ClassDB_get_method_with_compatibility(NativeName, MethodName.TagSavedVersion, 3218959716ul);

    /// <summary>
    /// <para>Tag the current version as saved.</para>
    /// </summary>
    public void TagSavedVersion()
    {
        NativeCalls.godot_icall_0_3(MethodBind73, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind74 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVersion, 3905245786ul);

    /// <summary>
    /// <para>Returns the current version of the <see cref="Godot.TextEdit"/>. The version is a count of recorded operations by the undo/redo history.</para>
    /// </summary>
    public uint GetVersion()
    {
        return NativeCalls.godot_icall_0_209(MethodBind74, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind75 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSavedVersion, 3905245786ul);

    /// <summary>
    /// <para>Returns the last tagged saved version from <see cref="Godot.TextEdit.TagSavedVersion()"/>.</para>
    /// </summary>
    public uint GetSavedVersion()
    {
        return NativeCalls.godot_icall_0_209(MethodBind75, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind76 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSearchText, 83702148ul);

    /// <summary>
    /// <para>Sets the search text. See <see cref="Godot.TextEdit.SetSearchFlags(uint)"/>.</para>
    /// </summary>
    public void SetSearchText(string searchText)
    {
        NativeCalls.godot_icall_1_57(MethodBind76, GodotObject.GetPtr(this), searchText);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind77 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSearchFlags, 1286410249ul);

    /// <summary>
    /// <para>Sets the search <paramref name="flags"/>. This is used with <see cref="Godot.TextEdit.SetSearchText(string)"/> to highlight occurrences of the searched text. Search flags can be specified from the <see cref="Godot.TextEdit.SearchFlags"/> enum.</para>
    /// </summary>
    public void SetSearchFlags(uint flags)
    {
        NativeCalls.godot_icall_1_208(MethodBind77, GodotObject.GetPtr(this), flags);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind78 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Search, 1203739136ul);

    /// <summary>
    /// <para>Perform a search inside the text. Search flags can be specified in the <see cref="Godot.TextEdit.SearchFlags"/> enum.</para>
    /// <para>In the returned vector, <c>x</c> is the column, <c>y</c> is the line. If no results are found, both are equal to <c>-1</c>.</para>
    /// <para><code>
    /// Vector2I result = Search("print", (uint)TextEdit.SearchFlags.WholeWords, 0, 0);
    /// if (result.X != -1)
    /// {
    /// 	// Result found.
    /// 	int lineNumber = result.Y;
    /// 	int columnNumber = result.X;
    /// }
    /// </code></para>
    /// </summary>
    public Vector2I Search(string text, uint flags, int fromLine, int fromColumn)
    {
        return NativeCalls.godot_icall_4_1301(MethodBind78, GodotObject.GetPtr(this), text, flags, fromLine, fromColumn);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind79 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTooltipRequestFunc, 1611583062ul);

    /// <summary>
    /// <para>Provide custom tooltip text. The callback method must take the following args: <c>hovered_word: String</c>.</para>
    /// </summary>
    public void SetTooltipRequestFunc(Callable callback)
    {
        NativeCalls.godot_icall_1_403(MethodBind79, GodotObject.GetPtr(this), callback);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind80 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLocalMousePos, 3341600327ul);

    /// <summary>
    /// <para>Returns the local mouse position adjusted for the text direction.</para>
    /// </summary>
    public Vector2 GetLocalMousePos()
    {
        return NativeCalls.godot_icall_0_37(MethodBind80, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind81 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetWordAtPos, 3674420000ul);

    /// <summary>
    /// <para>Returns the word at <paramref name="position"/>.</para>
    /// </summary>
    public unsafe string GetWordAtPos(Vector2 position)
    {
        return NativeCalls.godot_icall_1_339(MethodBind81, GodotObject.GetPtr(this), &position);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind82 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLineColumnAtPos, 3472935744ul);

    /// <summary>
    /// <para>Returns the line and column at the given position. In the returned vector, <c>x</c> is the column and <c>y</c> is the line.</para>
    /// <para>If <paramref name="clampLine"/> is <see langword="false"/> and <paramref name="position"/> is below the last line, <c>Vector2i(-1, -1)</c> is returned.</para>
    /// <para>If <paramref name="clampColumn"/> is <see langword="false"/> and <paramref name="position"/> is outside the column range of the line, <c>Vector2i(-1, -1)</c> is returned.</para>
    /// </summary>
    public unsafe Vector2I GetLineColumnAtPos(Vector2I position, bool clampLine = true, bool clampColumn = true)
    {
        return NativeCalls.godot_icall_3_1302(MethodBind82, GodotObject.GetPtr(this), &position, clampLine.ToGodotBool(), clampColumn.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind83 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPosAtLineColumn, 410388347ul);

    /// <summary>
    /// <para>Returns the local position for the given <paramref name="line"/> and <paramref name="column"/>. If <c>x</c> or <c>y</c> of the returned vector equal <c>-1</c>, the position is outside of the viewable area of the control.</para>
    /// <para><b>Note:</b> The Y position corresponds to the bottom side of the line. Use <see cref="Godot.TextEdit.GetRectAtLineColumn(int, int)"/> to get the top side position.</para>
    /// </summary>
    public Vector2I GetPosAtLineColumn(int line, int column)
    {
        return NativeCalls.godot_icall_2_1303(MethodBind83, GodotObject.GetPtr(this), line, column);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind84 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRectAtLineColumn, 3256618057ul);

    /// <summary>
    /// <para>Returns the local position and size for the grapheme at the given <paramref name="line"/> and <paramref name="column"/>. If <c>x</c> or <c>y</c> position of the returned rect equal <c>-1</c>, the position is outside of the viewable area of the control.</para>
    /// <para><b>Note:</b> The Y position of the returned rect corresponds to the top side of the line, unlike <see cref="Godot.TextEdit.GetPosAtLineColumn(int, int)"/> which returns the bottom side.</para>
    /// </summary>
    public Rect2I GetRectAtLineColumn(int line, int column)
    {
        return NativeCalls.godot_icall_2_1304(MethodBind84, GodotObject.GetPtr(this), line, column);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind85 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMinimapLineAtPos, 2485466453ul);

    /// <summary>
    /// <para>Returns the equivalent minimap line at <paramref name="position"/>.</para>
    /// </summary>
    public unsafe int GetMinimapLineAtPos(Vector2I position)
    {
        return NativeCalls.godot_icall_1_409(MethodBind85, GodotObject.GetPtr(this), &position);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind86 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsDraggingCursor, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the user is dragging their mouse for scrolling, selecting, or text dragging.</para>
    /// </summary>
    public bool IsDraggingCursor()
    {
        return NativeCalls.godot_icall_0_15(MethodBind86, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind87 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsMouseOverSelection, 1840282309ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the mouse is over a selection. If <paramref name="edges"/> is <see langword="true"/>, the edges are considered part of the selection.</para>
    /// </summary>
    public bool IsMouseOverSelection(bool edges, int caretIndex = -1)
    {
        return NativeCalls.godot_icall_2_1305(MethodBind87, GodotObject.GetPtr(this), edges.ToGodotBool(), caretIndex).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind88 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCaretType, 1211596914ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCaretType(TextEdit.CaretTypeEnum type)
    {
        NativeCalls.godot_icall_1_38(MethodBind88, GodotObject.GetPtr(this), (int)type);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind89 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCaretType, 2830252959ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public TextEdit.CaretTypeEnum GetCaretType()
    {
        return (TextEdit.CaretTypeEnum)NativeCalls.godot_icall_0_39(MethodBind89, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind90 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCaretBlinkEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCaretBlinkEnabled(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind90, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind91 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsCaretBlinkEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsCaretBlinkEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind91, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind92 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCaretBlinkInterval, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCaretBlinkInterval(float interval)
    {
        NativeCalls.godot_icall_1_67(MethodBind92, GodotObject.GetPtr(this), interval);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind93 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCaretBlinkInterval, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetCaretBlinkInterval()
    {
        return NativeCalls.godot_icall_0_68(MethodBind93, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind94 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDrawCaretWhenEditableDisabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDrawCaretWhenEditableDisabled(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind94, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind95 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsDrawingCaretWhenEditableDisabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsDrawingCaretWhenEditableDisabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind95, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind96 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMoveCaretOnRightClickEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMoveCaretOnRightClickEnabled(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind96, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind97 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsMoveCaretOnRightClickEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsMoveCaretOnRightClickEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind97, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind98 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCaretMidGraphemeEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCaretMidGraphemeEnabled(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind98, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind99 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsCaretMidGraphemeEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsCaretMidGraphemeEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind99, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind100 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMultipleCaretsEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMultipleCaretsEnabled(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind100, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind101 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsMultipleCaretsEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsMultipleCaretsEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind101, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind102 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddCaret, 50157827ul);

    /// <summary>
    /// <para>Adds a new caret at the given location. Returns the index of the new caret, or <c>-1</c> if the location is invalid.</para>
    /// </summary>
    public int AddCaret(int line, int column)
    {
        return NativeCalls.godot_icall_2_73(MethodBind102, GodotObject.GetPtr(this), line, column);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind103 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveCaret, 1286410249ul);

    /// <summary>
    /// <para>Removes the given caret index.</para>
    /// <para><b>Note:</b> This can result in adjustment of all other caret indices.</para>
    /// </summary>
    public void RemoveCaret(int caret)
    {
        NativeCalls.godot_icall_1_38(MethodBind103, GodotObject.GetPtr(this), caret);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind104 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveSecondaryCarets, 3218959716ul);

    /// <summary>
    /// <para>Removes all additional carets.</para>
    /// </summary>
    public void RemoveSecondaryCarets()
    {
        NativeCalls.godot_icall_0_3(MethodBind104, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind105 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCaretCount, 3905245786ul);

    /// <summary>
    /// <para>Returns the number of carets in this <see cref="Godot.TextEdit"/>.</para>
    /// </summary>
    public int GetCaretCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind105, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind106 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddCaretAtCarets, 2586408642ul);

    /// <summary>
    /// <para>Adds an additional caret above or below every caret. If <paramref name="below"/> is <see langword="true"/> the new caret will be added below and above otherwise.</para>
    /// </summary>
    public void AddCaretAtCarets(bool below)
    {
        NativeCalls.godot_icall_1_14(MethodBind106, GodotObject.GetPtr(this), below.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind107 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSortedCarets, 2131714034ul);

    /// <summary>
    /// <para>Returns the carets sorted by selection beginning from lowest line and column to highest (from top to bottom of text).</para>
    /// <para>If <paramref name="includeIgnoredCarets"/> is <see langword="false"/>, carets from <see cref="Godot.TextEdit.MulticaretEditIgnoreCaret(int)"/> will be ignored.</para>
    /// </summary>
    public int[] GetSortedCarets(bool includeIgnoredCarets = false)
    {
        return NativeCalls.godot_icall_1_1306(MethodBind107, GodotObject.GetPtr(this), includeIgnoredCarets.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind108 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CollapseCarets, 228654177ul);

    /// <summary>
    /// <para>Collapse all carets in the given range to the <paramref name="fromLine"/> and <paramref name="fromColumn"/> position.</para>
    /// <para><paramref name="inclusive"/> applies to both ends.</para>
    /// <para>If <see cref="Godot.TextEdit.IsInMulitcaretEdit()"/> is <see langword="true"/>, carets that are collapsed will be <see langword="true"/> for <see cref="Godot.TextEdit.MulticaretEditIgnoreCaret(int)"/>.</para>
    /// <para><see cref="Godot.TextEdit.MergeOverlappingCarets()"/> will be called if any carets were collapsed.</para>
    /// </summary>
    public void CollapseCarets(int fromLine, int fromColumn, int toLine, int toColumn, bool inclusive = false)
    {
        NativeCalls.godot_icall_5_1307(MethodBind108, GodotObject.GetPtr(this), fromLine, fromColumn, toLine, toColumn, inclusive.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind109 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MergeOverlappingCarets, 3218959716ul);

    /// <summary>
    /// <para>Merges any overlapping carets. Will favor the newest caret, or the caret with a selection.</para>
    /// <para>If <see cref="Godot.TextEdit.IsInMulitcaretEdit()"/> is <see langword="true"/>, the merge will be queued to happen at the end of the multicaret edit. See <see cref="Godot.TextEdit.BeginMulticaretEdit()"/> and <see cref="Godot.TextEdit.EndMulticaretEdit()"/>.</para>
    /// <para><b>Note:</b> This is not called when a caret changes position but after certain actions, so it is possible to get into a state where carets overlap.</para>
    /// </summary>
    public void MergeOverlappingCarets()
    {
        NativeCalls.godot_icall_0_3(MethodBind109, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind110 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BeginMulticaretEdit, 3218959716ul);

    /// <summary>
    /// <para>Starts an edit for multiple carets. The edit must be ended with <see cref="Godot.TextEdit.EndMulticaretEdit()"/>. Multicaret edits can be used to edit text at multiple carets and delay merging the carets until the end, so the caret indexes aren't affected immediately. <see cref="Godot.TextEdit.BeginMulticaretEdit()"/> and <see cref="Godot.TextEdit.EndMulticaretEdit()"/> can be nested, and the merge will happen at the last <see cref="Godot.TextEdit.EndMulticaretEdit()"/>.</para>
    /// <para><code>
    /// begin_complex_operation()
    /// begin_multicaret_edit()
    /// for i in range(get_caret_count()):
    /// 	if multicaret_edit_ignore_caret(i):
    /// 		continue
    /// 	# Logic here.
    /// end_multicaret_edit()
    /// end_complex_operation()
    /// </code></para>
    /// </summary>
    public void BeginMulticaretEdit()
    {
        NativeCalls.godot_icall_0_3(MethodBind110, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind111 = ClassDB_get_method_with_compatibility(NativeName, MethodName.EndMulticaretEdit, 3218959716ul);

    /// <summary>
    /// <para>Ends an edit for multiple carets, that was started with <see cref="Godot.TextEdit.BeginMulticaretEdit()"/>. If this was the last <see cref="Godot.TextEdit.EndMulticaretEdit()"/> and <see cref="Godot.TextEdit.MergeOverlappingCarets()"/> was called, carets will be merged.</para>
    /// </summary>
    public void EndMulticaretEdit()
    {
        NativeCalls.godot_icall_0_3(MethodBind111, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind112 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsInMulitcaretEdit, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if a <see cref="Godot.TextEdit.BeginMulticaretEdit()"/> has been called and <see cref="Godot.TextEdit.EndMulticaretEdit()"/> has not yet been called.</para>
    /// </summary>
    public bool IsInMulitcaretEdit()
    {
        return NativeCalls.godot_icall_0_15(MethodBind112, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind113 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MulticaretEditIgnoreCaret, 1116898809ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the given <paramref name="caretIndex"/> should be ignored as part of a multicaret edit. See <see cref="Godot.TextEdit.BeginMulticaretEdit()"/> and <see cref="Godot.TextEdit.EndMulticaretEdit()"/>. Carets that should be ignored are ones that were part of removed text and will likely be merged at the end of the edit, or carets that were added during the edit.</para>
    /// <para>It is recommended to <c>continue</c> within a loop iterating on multiple carets if a caret should be ignored.</para>
    /// </summary>
    public bool MulticaretEditIgnoreCaret(int caretIndex)
    {
        return NativeCalls.godot_icall_1_62(MethodBind113, GodotObject.GetPtr(this), caretIndex).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind114 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsCaretVisible, 1051549951ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the caret is visible, <see langword="false"/> otherwise. A caret will be considered hidden if it is outside the scrollable area when scrolling is enabled.</para>
    /// <para><b>Note:</b> <see cref="Godot.TextEdit.IsCaretVisible(int)"/> does not account for a caret being off-screen if it is still within the scrollable area. It will return <see langword="true"/> even if the caret is off-screen as long as it meets <see cref="Godot.TextEdit"/>'s own conditions for being visible. This includes uses of <see cref="Godot.TextEdit.ScrollFitContentWidth"/> and <see cref="Godot.TextEdit.ScrollFitContentHeight"/> that cause the <see cref="Godot.TextEdit"/> to expand beyond the viewport's bounds.</para>
    /// </summary>
    public bool IsCaretVisible(int caretIndex = 0)
    {
        return NativeCalls.godot_icall_1_62(MethodBind114, GodotObject.GetPtr(this), caretIndex).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind115 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCaretDrawPos, 478253731ul);

    /// <summary>
    /// <para>Returns the caret pixel draw position.</para>
    /// </summary>
    public Vector2 GetCaretDrawPos(int caretIndex = 0)
    {
        return NativeCalls.godot_icall_1_148(MethodBind115, GodotObject.GetPtr(this), caretIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind116 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCaretLine, 1302582944ul);

    /// <summary>
    /// <para>Moves the caret to the specified <paramref name="line"/> index. The caret column will be moved to the same visual position it was at the last time <see cref="Godot.TextEdit.SetCaretColumn(int, bool, int)"/> was called, or clamped to the end of the line.</para>
    /// <para>If <paramref name="adjustViewport"/> is <see langword="true"/>, the viewport will center at the caret position after the move occurs.</para>
    /// <para>If <paramref name="canBeHidden"/> is <see langword="true"/>, the specified <paramref name="line"/> can be hidden.</para>
    /// <para>If <paramref name="wrapIndex"/> is <c>-1</c>, the caret column will be clamped to the <paramref name="line"/>'s length. If <paramref name="wrapIndex"/> is greater than <c>-1</c>, the column will be moved to attempt to match the visual x position on the line's <paramref name="wrapIndex"/> to the position from the last time <see cref="Godot.TextEdit.SetCaretColumn(int, bool, int)"/> was called.</para>
    /// <para><b>Note:</b> If supporting multiple carets this will not check for any overlap. See <see cref="Godot.TextEdit.MergeOverlappingCarets()"/>.</para>
    /// </summary>
    public void SetCaretLine(int line, bool adjustViewport = true, bool canBeHidden = true, int wrapIndex = 0, int caretIndex = 0)
    {
        NativeCalls.godot_icall_5_1308(MethodBind116, GodotObject.GetPtr(this), line, adjustViewport.ToGodotBool(), canBeHidden.ToGodotBool(), wrapIndex, caretIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind117 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCaretLine, 1591665591ul);

    /// <summary>
    /// <para>Returns the line the editing caret is on.</para>
    /// </summary>
    public int GetCaretLine(int caretIndex = 0)
    {
        return NativeCalls.godot_icall_1_60(MethodBind117, GodotObject.GetPtr(this), caretIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind118 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCaretColumn, 3796796178ul);

    /// <summary>
    /// <para>Moves the caret to the specified <paramref name="column"/> index.</para>
    /// <para>If <paramref name="adjustViewport"/> is <see langword="true"/>, the viewport will center at the caret position after the move occurs.</para>
    /// <para><b>Note:</b> If supporting multiple carets this will not check for any overlap. See <see cref="Godot.TextEdit.MergeOverlappingCarets()"/>.</para>
    /// </summary>
    public void SetCaretColumn(int column, bool adjustViewport = true, int caretIndex = 0)
    {
        NativeCalls.godot_icall_3_415(MethodBind118, GodotObject.GetPtr(this), column, adjustViewport.ToGodotBool(), caretIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind119 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCaretColumn, 1591665591ul);

    /// <summary>
    /// <para>Returns the column the editing caret is at.</para>
    /// </summary>
    public int GetCaretColumn(int caretIndex = 0)
    {
        return NativeCalls.godot_icall_1_60(MethodBind119, GodotObject.GetPtr(this), caretIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind120 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNextCompositeCharacterColumn, 3175239445ul);

    /// <summary>
    /// <para>Returns the correct column at the end of a composite character like ❤️‍🩹 (mending heart; Unicode: <c>U+2764 U+FE0F U+200D U+1FA79</c>) which is comprised of more than one Unicode code point, if the caret is at the start of the composite character. Also returns the correct column with the caret at mid grapheme and for non-composite characters.</para>
    /// <para><b>Note:</b> To check at caret location use <c>get_next_composite_character_column(get_caret_line(), get_caret_column())</c></para>
    /// </summary>
    public int GetNextCompositeCharacterColumn(int line, int column)
    {
        return NativeCalls.godot_icall_2_73(MethodBind120, GodotObject.GetPtr(this), line, column);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind121 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPreviousCompositeCharacterColumn, 3175239445ul);

    /// <summary>
    /// <para>Returns the correct column at the start of a composite character like ❤️‍🩹 (mending heart; Unicode: <c>U+2764 U+FE0F U+200D U+1FA79</c>) which is comprised of more than one Unicode code point, if the caret is at the end of the composite character. Also returns the correct column with the caret at mid grapheme and for non-composite characters.</para>
    /// <para><b>Note:</b> To check at caret location use <c>get_previous_composite_character_column(get_caret_line(), get_caret_column())</c></para>
    /// </summary>
    public int GetPreviousCompositeCharacterColumn(int line, int column)
    {
        return NativeCalls.godot_icall_2_73(MethodBind121, GodotObject.GetPtr(this), line, column);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind122 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCaretWrapIndex, 1591665591ul);

    /// <summary>
    /// <para>Returns the wrap index the editing caret is on.</para>
    /// </summary>
    public int GetCaretWrapIndex(int caretIndex = 0)
    {
        return NativeCalls.godot_icall_1_60(MethodBind122, GodotObject.GetPtr(this), caretIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind123 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetWordUnderCaret, 3929349208ul);

    /// <summary>
    /// <para>Returns a <see cref="string"/> text with the word under the caret's location.</para>
    /// </summary>
    public string GetWordUnderCaret(int caretIndex = -1)
    {
        return NativeCalls.godot_icall_1_133(MethodBind123, GodotObject.GetPtr(this), caretIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind124 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetUseDefaultWordSeparators, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetUseDefaultWordSeparators(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind124, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind125 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsDefaultWordSeparatorsEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsDefaultWordSeparatorsEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind125, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind126 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetUseCustomWordSeparators, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetUseCustomWordSeparators(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind126, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind127 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsCustomWordSeparatorsEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsCustomWordSeparatorsEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind127, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind128 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCustomWordSeparators, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCustomWordSeparators(string customWordSeparators)
    {
        NativeCalls.godot_icall_1_57(MethodBind128, GodotObject.GetPtr(this), customWordSeparators);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind129 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCustomWordSeparators, 201670096ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetCustomWordSeparators()
    {
        return NativeCalls.godot_icall_0_58(MethodBind129, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind130 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSelectingEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSelectingEnabled(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind130, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind131 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsSelectingEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsSelectingEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind131, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind132 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDeselectOnFocusLossEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDeselectOnFocusLossEnabled(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind132, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind133 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsDeselectOnFocusLossEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsDeselectOnFocusLossEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind133, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind134 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDragAndDropSelectionEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDragAndDropSelectionEnabled(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind134, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind135 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsDragAndDropSelectionEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsDragAndDropSelectionEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind135, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind136 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSelectionMode, 1658801786ul);

    /// <summary>
    /// <para>Sets the current selection mode.</para>
    /// </summary>
    public void SetSelectionMode(TextEdit.SelectionMode mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind136, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind137 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSelectionMode, 3750106938ul);

    /// <summary>
    /// <para>Returns the current selection mode.</para>
    /// </summary>
    public TextEdit.SelectionMode GetSelectionMode()
    {
        return (TextEdit.SelectionMode)NativeCalls.godot_icall_0_39(MethodBind137, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind138 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SelectAll, 3218959716ul);

    /// <summary>
    /// <para>Select all the text.</para>
    /// <para>If <see cref="Godot.TextEdit.SelectingEnabled"/> is <see langword="false"/>, no selection will occur.</para>
    /// </summary>
    public void SelectAll()
    {
        NativeCalls.godot_icall_0_3(MethodBind138, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind139 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SelectWordUnderCaret, 1025054187ul);

    /// <summary>
    /// <para>Selects the word under the caret.</para>
    /// </summary>
    public void SelectWordUnderCaret(int caretIndex = -1)
    {
        NativeCalls.godot_icall_1_38(MethodBind139, GodotObject.GetPtr(this), caretIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind140 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddSelectionForNextOccurrence, 3218959716ul);

    /// <summary>
    /// <para>Adds a selection and a caret for the next occurrence of the current selection. If there is no active selection, selects word under caret.</para>
    /// </summary>
    public void AddSelectionForNextOccurrence()
    {
        NativeCalls.godot_icall_0_3(MethodBind140, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind141 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SkipSelectionForNextOccurrence, 3218959716ul);

    /// <summary>
    /// <para>Moves a selection and a caret for the next occurrence of the current selection. If there is no active selection, moves to the next occurrence of the word under caret.</para>
    /// </summary>
    public void SkipSelectionForNextOccurrence()
    {
        NativeCalls.godot_icall_0_3(MethodBind141, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind142 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Select, 2560984452ul);

    /// <summary>
    /// <para>Selects text from <paramref name="originLine"/> and <paramref name="originColumn"/> to <paramref name="caretLine"/> and <paramref name="caretColumn"/> for the given <paramref name="caretIndex"/>. This moves the selection origin and the caret. If the positions are the same, the selection will be deselected.</para>
    /// <para>If <see cref="Godot.TextEdit.SelectingEnabled"/> is <see langword="false"/>, no selection will occur.</para>
    /// <para><b>Note:</b> If supporting multiple carets this will not check for any overlap. See <see cref="Godot.TextEdit.MergeOverlappingCarets()"/>.</para>
    /// </summary>
    public void Select(int originLine, int originColumn, int caretLine, int caretColumn, int caretIndex = 0)
    {
        NativeCalls.godot_icall_5_1309(MethodBind142, GodotObject.GetPtr(this), originLine, originColumn, caretLine, caretColumn, caretIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind143 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasSelection, 2824505868ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the user has selected text.</para>
    /// </summary>
    public bool HasSelection(int caretIndex = -1)
    {
        return NativeCalls.godot_icall_1_62(MethodBind143, GodotObject.GetPtr(this), caretIndex).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind144 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSelectedText, 2309358862ul);

    /// <summary>
    /// <para>Returns the text inside the selection of a caret, or all the carets if <paramref name="caretIndex"/> is its default value <c>-1</c>.</para>
    /// </summary>
    public string GetSelectedText(int caretIndex = -1)
    {
        return NativeCalls.godot_icall_1_133(MethodBind144, GodotObject.GetPtr(this), caretIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind145 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSelectionAtLineColumn, 1810224333ul);

    /// <summary>
    /// <para>Returns the caret index of the selection at the given <paramref name="line"/> and <paramref name="column"/>, or <c>-1</c> if there is none.</para>
    /// <para>If <paramref name="includeEdges"/> is <see langword="false"/>, the position must be inside the selection and not at either end. If <paramref name="onlySelections"/> is <see langword="false"/>, carets without a selection will also be considered.</para>
    /// </summary>
    public int GetSelectionAtLineColumn(int line, int column, bool includeEdges = true, bool onlySelections = true)
    {
        return NativeCalls.godot_icall_4_1310(MethodBind145, GodotObject.GetPtr(this), line, column, includeEdges.ToGodotBool(), onlySelections.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind146 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLineRangesFromCarets, 2393089247ul);

    /// <summary>
    /// <para>Returns an <see cref="Godot.Collections.Array"/> of line ranges where <c>x</c> is the first line and <c>y</c> is the last line. All lines within these ranges will have a caret on them or be part of a selection. Each line will only be part of one line range, even if it has multiple carets on it.</para>
    /// <para>If a selection's end column (<see cref="Godot.TextEdit.GetSelectionToColumn(int)"/>) is at column <c>0</c>, that line will not be included. If a selection begins on the line after another selection ends and <paramref name="mergeAdjacent"/> is <see langword="true"/>, or they begin and end on the same line, one line range will include both selections.</para>
    /// </summary>
    public Godot.Collections.Array<Vector2I> GetLineRangesFromCarets(bool onlySelections = false, bool mergeAdjacent = true)
    {
        return new Godot.Collections.Array<Vector2I>(NativeCalls.godot_icall_2_1311(MethodBind146, GodotObject.GetPtr(this), onlySelections.ToGodotBool(), mergeAdjacent.ToGodotBool()));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind147 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSelectionOriginLine, 1591665591ul);

    /// <summary>
    /// <para>Returns the origin line of the selection. This is the opposite end from the caret.</para>
    /// </summary>
    public int GetSelectionOriginLine(int caretIndex = 0)
    {
        return NativeCalls.godot_icall_1_60(MethodBind147, GodotObject.GetPtr(this), caretIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind148 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSelectionOriginColumn, 1591665591ul);

    /// <summary>
    /// <para>Returns the origin column of the selection. This is the opposite end from the caret.</para>
    /// </summary>
    public int GetSelectionOriginColumn(int caretIndex = 0)
    {
        return NativeCalls.godot_icall_1_60(MethodBind148, GodotObject.GetPtr(this), caretIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind149 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSelectionOriginLine, 195434140ul);

    /// <summary>
    /// <para>Sets the selection origin line to the <paramref name="line"/> for the given <paramref name="caretIndex"/>. If the selection origin is moved to the caret position, the selection will deselect.</para>
    /// <para>If <paramref name="canBeHidden"/> is <see langword="false"/>, The line will be set to the nearest unhidden line below or above.</para>
    /// <para>If <paramref name="wrapIndex"/> is <c>-1</c>, the selection origin column will be clamped to the <paramref name="line"/>'s length. If <paramref name="wrapIndex"/> is greater than <c>-1</c>, the column will be moved to attempt to match the visual x position on the line's <paramref name="wrapIndex"/> to the position from the last time <see cref="Godot.TextEdit.SetSelectionOriginColumn(int, int)"/> or <see cref="Godot.TextEdit.Select(int, int, int, int, int)"/> was called.</para>
    /// </summary>
    public void SetSelectionOriginLine(int line, bool canBeHidden = true, int wrapIndex = -1, int caretIndex = 0)
    {
        NativeCalls.godot_icall_4_1312(MethodBind149, GodotObject.GetPtr(this), line, canBeHidden.ToGodotBool(), wrapIndex, caretIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind150 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSelectionOriginColumn, 2230941749ul);

    /// <summary>
    /// <para>Sets the selection origin column to the <paramref name="column"/> for the given <paramref name="caretIndex"/>. If the selection origin is moved to the caret position, the selection will deselect.</para>
    /// </summary>
    public void SetSelectionOriginColumn(int column, int caretIndex = 0)
    {
        NativeCalls.godot_icall_2_59(MethodBind150, GodotObject.GetPtr(this), column, caretIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind151 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSelectionFromLine, 1591665591ul);

    /// <summary>
    /// <para>Returns the selection begin line. Returns the caret line if there is no selection.</para>
    /// </summary>
    public int GetSelectionFromLine(int caretIndex = 0)
    {
        return NativeCalls.godot_icall_1_60(MethodBind151, GodotObject.GetPtr(this), caretIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind152 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSelectionFromColumn, 1591665591ul);

    /// <summary>
    /// <para>Returns the selection begin column. Returns the caret column if there is no selection.</para>
    /// </summary>
    public int GetSelectionFromColumn(int caretIndex = 0)
    {
        return NativeCalls.godot_icall_1_60(MethodBind152, GodotObject.GetPtr(this), caretIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind153 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSelectionToLine, 1591665591ul);

    /// <summary>
    /// <para>Returns the selection end line. Returns the caret line if there is no selection.</para>
    /// </summary>
    public int GetSelectionToLine(int caretIndex = 0)
    {
        return NativeCalls.godot_icall_1_60(MethodBind153, GodotObject.GetPtr(this), caretIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind154 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSelectionToColumn, 1591665591ul);

    /// <summary>
    /// <para>Returns the selection end column. Returns the caret column if there is no selection.</para>
    /// </summary>
    public int GetSelectionToColumn(int caretIndex = 0)
    {
        return NativeCalls.godot_icall_1_60(MethodBind154, GodotObject.GetPtr(this), caretIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind155 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsCaretAfterSelectionOrigin, 1051549951ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the caret of the selection is after the selection origin. This can be used to determine the direction of the selection.</para>
    /// </summary>
    public bool IsCaretAfterSelectionOrigin(int caretIndex = 0)
    {
        return NativeCalls.godot_icall_1_62(MethodBind155, GodotObject.GetPtr(this), caretIndex).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind156 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Deselect, 1025054187ul);

    /// <summary>
    /// <para>Deselects the current selection.</para>
    /// </summary>
    public void Deselect(int caretIndex = -1)
    {
        NativeCalls.godot_icall_1_38(MethodBind156, GodotObject.GetPtr(this), caretIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind157 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DeleteSelection, 1025054187ul);

    /// <summary>
    /// <para>Deletes the selected text.</para>
    /// </summary>
    public void DeleteSelection(int caretIndex = -1)
    {
        NativeCalls.godot_icall_1_38(MethodBind157, GodotObject.GetPtr(this), caretIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind158 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLineWrappingMode, 2525115309ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetLineWrappingMode(TextEdit.LineWrappingMode mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind158, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind159 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLineWrappingMode, 3562716114ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public TextEdit.LineWrappingMode GetLineWrappingMode()
    {
        return (TextEdit.LineWrappingMode)NativeCalls.godot_icall_0_39(MethodBind159, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind160 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAutowrapMode, 3289138044ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAutowrapMode(TextServer.AutowrapMode autowrapMode)
    {
        NativeCalls.godot_icall_1_38(MethodBind160, GodotObject.GetPtr(this), (int)autowrapMode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind161 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAutowrapMode, 1549071663ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public TextServer.AutowrapMode GetAutowrapMode()
    {
        return (TextServer.AutowrapMode)NativeCalls.godot_icall_0_39(MethodBind161, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind162 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsLineWrapped, 1116898809ul);

    /// <summary>
    /// <para>Returns if the given line is wrapped.</para>
    /// </summary>
    public bool IsLineWrapped(int line)
    {
        return NativeCalls.godot_icall_1_62(MethodBind162, GodotObject.GetPtr(this), line).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind163 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLineWrapCount, 923996154ul);

    /// <summary>
    /// <para>Returns the number of times the given line is wrapped.</para>
    /// </summary>
    public int GetLineWrapCount(int line)
    {
        return NativeCalls.godot_icall_1_60(MethodBind163, GodotObject.GetPtr(this), line);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind164 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLineWrapIndexAtColumn, 3175239445ul);

    /// <summary>
    /// <para>Returns the wrap index of the given column on the given line. This ranges from <c>0</c> to <see cref="Godot.TextEdit.GetLineWrapCount(int)"/>.</para>
    /// </summary>
    public int GetLineWrapIndexAtColumn(int line, int column)
    {
        return NativeCalls.godot_icall_2_73(MethodBind164, GodotObject.GetPtr(this), line, column);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind165 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLineWrappedText, 647634434ul);

    /// <summary>
    /// <para>Returns an array of <see cref="string"/>s representing each wrapped index.</para>
    /// </summary>
    public string[] GetLineWrappedText(int line)
    {
        return NativeCalls.godot_icall_1_474(MethodBind165, GodotObject.GetPtr(this), line);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind166 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSmoothScrollEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSmoothScrollEnabled(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind166, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind167 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsSmoothScrollEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsSmoothScrollEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind167, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind168 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVScrollBar, 3226026593ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.VScrollBar"/> of the <see cref="Godot.TextEdit"/>.</para>
    /// </summary>
    public VScrollBar GetVScrollBar()
    {
        return (VScrollBar)NativeCalls.godot_icall_0_53(MethodBind168, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind169 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetHScrollBar, 3774687988ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.HScrollBar"/> used by <see cref="Godot.TextEdit"/>.</para>
    /// </summary>
    public HScrollBar GetHScrollBar()
    {
        return (HScrollBar)NativeCalls.godot_icall_0_53(MethodBind169, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind170 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVScroll, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetVScroll(double value)
    {
        NativeCalls.godot_icall_1_127(MethodBind170, GodotObject.GetPtr(this), value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind171 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVScroll, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public double GetVScroll()
    {
        return NativeCalls.godot_icall_0_144(MethodBind171, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind172 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetHScroll, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetHScroll(int value)
    {
        NativeCalls.godot_icall_1_38(MethodBind172, GodotObject.GetPtr(this), value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind173 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetHScroll, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetHScroll()
    {
        return NativeCalls.godot_icall_0_39(MethodBind173, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind174 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetScrollPastEndOfFileEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetScrollPastEndOfFileEnabled(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind174, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind175 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsScrollPastEndOfFileEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsScrollPastEndOfFileEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind175, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind176 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVScrollSpeed, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetVScrollSpeed(float speed)
    {
        NativeCalls.godot_icall_1_67(MethodBind176, GodotObject.GetPtr(this), speed);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind177 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVScrollSpeed, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetVScrollSpeed()
    {
        return NativeCalls.godot_icall_0_68(MethodBind177, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind178 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFitContentHeightEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFitContentHeightEnabled(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind178, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind179 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsFitContentHeightEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsFitContentHeightEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind179, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind180 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFitContentWidthEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFitContentWidthEnabled(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind180, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind181 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsFitContentWidthEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsFitContentWidthEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind181, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind182 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetScrollPosForLine, 3929084198ul);

    /// <summary>
    /// <para>Returns the scroll position for <paramref name="wrapIndex"/> of <paramref name="line"/>.</para>
    /// </summary>
    public double GetScrollPosForLine(int line, int wrapIndex = 0)
    {
        return NativeCalls.godot_icall_2_90(MethodBind182, GodotObject.GetPtr(this), line, wrapIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind183 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLineAsFirstVisible, 2230941749ul);

    /// <summary>
    /// <para>Positions the <paramref name="wrapIndex"/> of <paramref name="line"/> at the top of the viewport.</para>
    /// </summary>
    public void SetLineAsFirstVisible(int line, int wrapIndex = 0)
    {
        NativeCalls.godot_icall_2_59(MethodBind183, GodotObject.GetPtr(this), line, wrapIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind184 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFirstVisibleLine, 3905245786ul);

    /// <summary>
    /// <para>Returns the first visible line.</para>
    /// </summary>
    public int GetFirstVisibleLine()
    {
        return NativeCalls.godot_icall_0_39(MethodBind184, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind185 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLineAsCenterVisible, 2230941749ul);

    /// <summary>
    /// <para>Positions the <paramref name="wrapIndex"/> of <paramref name="line"/> at the center of the viewport.</para>
    /// </summary>
    public void SetLineAsCenterVisible(int line, int wrapIndex = 0)
    {
        NativeCalls.godot_icall_2_59(MethodBind185, GodotObject.GetPtr(this), line, wrapIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind186 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLineAsLastVisible, 2230941749ul);

    /// <summary>
    /// <para>Positions the <paramref name="wrapIndex"/> of <paramref name="line"/> at the bottom of the viewport.</para>
    /// </summary>
    public void SetLineAsLastVisible(int line, int wrapIndex = 0)
    {
        NativeCalls.godot_icall_2_59(MethodBind186, GodotObject.GetPtr(this), line, wrapIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind187 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLastFullVisibleLine, 3905245786ul);

    /// <summary>
    /// <para>Returns the last visible line. Use <see cref="Godot.TextEdit.GetLastFullVisibleLineWrapIndex()"/> for the wrap index.</para>
    /// </summary>
    public int GetLastFullVisibleLine()
    {
        return NativeCalls.godot_icall_0_39(MethodBind187, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind188 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLastFullVisibleLineWrapIndex, 3905245786ul);

    /// <summary>
    /// <para>Returns the last visible wrap index of the last visible line.</para>
    /// </summary>
    public int GetLastFullVisibleLineWrapIndex()
    {
        return NativeCalls.godot_icall_0_39(MethodBind188, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind189 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVisibleLineCount, 3905245786ul);

    /// <summary>
    /// <para>Returns the number of lines that can visually fit, rounded down, based on this control's height.</para>
    /// </summary>
    public int GetVisibleLineCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind189, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind190 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVisibleLineCountInRange, 3175239445ul);

    /// <summary>
    /// <para>Returns the total number of lines between <paramref name="fromLine"/> and <paramref name="toLine"/> (inclusive) in the text. This includes wrapped lines and excludes folded lines. If the range covers all lines it is equivalent to <see cref="Godot.TextEdit.GetTotalVisibleLineCount()"/>.</para>
    /// </summary>
    public int GetVisibleLineCountInRange(int fromLine, int toLine)
    {
        return NativeCalls.godot_icall_2_73(MethodBind190, GodotObject.GetPtr(this), fromLine, toLine);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind191 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTotalVisibleLineCount, 3905245786ul);

    /// <summary>
    /// <para>Returns the total number of lines in the text. This includes wrapped lines and excludes folded lines. If <see cref="Godot.TextEdit.WrapMode"/> is set to <see cref="Godot.TextEdit.LineWrappingMode.None"/> and no lines are folded (see <see cref="Godot.CodeEdit.IsLineFolded(int)"/>) then this is equivalent to <see cref="Godot.TextEdit.GetLineCount()"/>. See <see cref="Godot.TextEdit.GetVisibleLineCountInRange(int, int)"/> for a limited range of lines.</para>
    /// </summary>
    public int GetTotalVisibleLineCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind191, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind192 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AdjustViewportToCaret, 1995695955ul);

    /// <summary>
    /// <para>Adjust the viewport so the caret is visible.</para>
    /// </summary>
    public void AdjustViewportToCaret(int caretIndex = 0)
    {
        NativeCalls.godot_icall_1_38(MethodBind192, GodotObject.GetPtr(this), caretIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind193 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CenterViewportToCaret, 1995695955ul);

    /// <summary>
    /// <para>Centers the viewport on the line the editing caret is at. This also resets the <see cref="Godot.TextEdit.ScrollHorizontal"/> value to <c>0</c>.</para>
    /// </summary>
    public void CenterViewportToCaret(int caretIndex = 0)
    {
        NativeCalls.godot_icall_1_38(MethodBind193, GodotObject.GetPtr(this), caretIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind194 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDrawMinimap, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDrawMinimap(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind194, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind195 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsDrawingMinimap, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsDrawingMinimap()
    {
        return NativeCalls.godot_icall_0_15(MethodBind195, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind196 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMinimapWidth, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMinimapWidth(int width)
    {
        NativeCalls.godot_icall_1_38(MethodBind196, GodotObject.GetPtr(this), width);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind197 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMinimapWidth, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetMinimapWidth()
    {
        return NativeCalls.godot_icall_0_39(MethodBind197, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind198 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMinimapVisibleLines, 3905245786ul);

    /// <summary>
    /// <para>Returns the number of lines that may be drawn on the minimap.</para>
    /// </summary>
    public int GetMinimapVisibleLines()
    {
        return NativeCalls.godot_icall_0_39(MethodBind198, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind199 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddGutter, 1025054187ul);

    /// <summary>
    /// <para>Register a new gutter to this <see cref="Godot.TextEdit"/>. Use <paramref name="at"/> to have a specific gutter order. A value of <c>-1</c> appends the gutter to the right.</para>
    /// </summary>
    public void AddGutter(int at = -1)
    {
        NativeCalls.godot_icall_1_38(MethodBind199, GodotObject.GetPtr(this), at);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind200 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveGutter, 1286410249ul);

    /// <summary>
    /// <para>Removes the gutter at the given index.</para>
    /// </summary>
    public void RemoveGutter(int gutter)
    {
        NativeCalls.godot_icall_1_38(MethodBind200, GodotObject.GetPtr(this), gutter);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind201 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetGutterCount, 3905245786ul);

    /// <summary>
    /// <para>Returns the number of gutters registered.</para>
    /// </summary>
    public int GetGutterCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind201, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind202 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetGutterName, 501894301ul);

    /// <summary>
    /// <para>Sets the name of the gutter at the given index.</para>
    /// </summary>
    public void SetGutterName(int gutter, string name)
    {
        NativeCalls.godot_icall_2_181(MethodBind202, GodotObject.GetPtr(this), gutter, name);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind203 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetGutterName, 844755477ul);

    /// <summary>
    /// <para>Returns the name of the gutter at the given index.</para>
    /// </summary>
    public string GetGutterName(int gutter)
    {
        return NativeCalls.godot_icall_1_133(MethodBind203, GodotObject.GetPtr(this), gutter);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind204 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetGutterType, 1088959071ul);

    /// <summary>
    /// <para>Sets the type of gutter at the given index. Gutters can contain icons, text, or custom visuals.</para>
    /// </summary>
    public void SetGutterType(int gutter, TextEdit.GutterType type)
    {
        NativeCalls.godot_icall_2_59(MethodBind204, GodotObject.GetPtr(this), gutter, (int)type);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind205 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetGutterType, 1159699127ul);

    /// <summary>
    /// <para>Returns the type of the gutter at the given index. Gutters can contain icons, text, or custom visuals.</para>
    /// </summary>
    public TextEdit.GutterType GetGutterType(int gutter)
    {
        return (TextEdit.GutterType)NativeCalls.godot_icall_1_60(MethodBind205, GodotObject.GetPtr(this), gutter);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind206 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetGutterWidth, 3937882851ul);

    /// <summary>
    /// <para>Set the width of the gutter at the given index.</para>
    /// </summary>
    public void SetGutterWidth(int gutter, int width)
    {
        NativeCalls.godot_icall_2_59(MethodBind206, GodotObject.GetPtr(this), gutter, width);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind207 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetGutterWidth, 923996154ul);

    /// <summary>
    /// <para>Returns the width of the gutter at the given index.</para>
    /// </summary>
    public int GetGutterWidth(int gutter)
    {
        return NativeCalls.godot_icall_1_60(MethodBind207, GodotObject.GetPtr(this), gutter);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind208 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetGutterDraw, 300928843ul);

    /// <summary>
    /// <para>If <see langword="true"/>, the gutter at the given index is drawn. The gutter type (<see cref="Godot.TextEdit.SetGutterType(int, TextEdit.GutterType)"/>) determines how it is drawn. See <see cref="Godot.TextEdit.IsGutterDrawn(int)"/>.</para>
    /// </summary>
    public void SetGutterDraw(int gutter, bool draw)
    {
        NativeCalls.godot_icall_2_61(MethodBind208, GodotObject.GetPtr(this), gutter, draw.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind209 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsGutterDrawn, 1116898809ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the gutter at the given index is currently drawn. See <see cref="Godot.TextEdit.SetGutterDraw(int, bool)"/>.</para>
    /// </summary>
    public bool IsGutterDrawn(int gutter)
    {
        return NativeCalls.godot_icall_1_62(MethodBind209, GodotObject.GetPtr(this), gutter).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind210 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetGutterClickable, 300928843ul);

    /// <summary>
    /// <para>If <see langword="true"/>, the mouse cursor will change to a pointing hand (<see cref="Godot.Control.CursorShape.PointingHand"/>) when hovering over the gutter at the given index. See <see cref="Godot.TextEdit.IsGutterClickable(int)"/> and <see cref="Godot.TextEdit.SetLineGutterClickable(int, int, bool)"/>.</para>
    /// </summary>
    public void SetGutterClickable(int gutter, bool clickable)
    {
        NativeCalls.godot_icall_2_61(MethodBind210, GodotObject.GetPtr(this), gutter, clickable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind211 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsGutterClickable, 1116898809ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the gutter at the given index is clickable. See <see cref="Godot.TextEdit.SetGutterClickable(int, bool)"/>.</para>
    /// </summary>
    public bool IsGutterClickable(int gutter)
    {
        return NativeCalls.godot_icall_1_62(MethodBind211, GodotObject.GetPtr(this), gutter).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind212 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetGutterOverwritable, 300928843ul);

    /// <summary>
    /// <para>If <see langword="true"/>, the line data of the gutter at the given index can be overridden when using <see cref="Godot.TextEdit.MergeGutters(int, int)"/>. See <see cref="Godot.TextEdit.IsGutterOverwritable(int)"/>.</para>
    /// </summary>
    public void SetGutterOverwritable(int gutter, bool overwritable)
    {
        NativeCalls.godot_icall_2_61(MethodBind212, GodotObject.GetPtr(this), gutter, overwritable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind213 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsGutterOverwritable, 1116898809ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the gutter at the given index is overwritable. See <see cref="Godot.TextEdit.SetGutterOverwritable(int, bool)"/>.</para>
    /// </summary>
    public bool IsGutterOverwritable(int gutter)
    {
        return NativeCalls.godot_icall_1_62(MethodBind213, GodotObject.GetPtr(this), gutter).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind214 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MergeGutters, 3937882851ul);

    /// <summary>
    /// <para>Merge the gutters from <paramref name="fromLine"/> into <paramref name="toLine"/>. Only overwritable gutters will be copied. See <see cref="Godot.TextEdit.SetGutterOverwritable(int, bool)"/>.</para>
    /// </summary>
    public void MergeGutters(int fromLine, int toLine)
    {
        NativeCalls.godot_icall_2_59(MethodBind214, GodotObject.GetPtr(this), fromLine, toLine);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind215 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetGutterCustomDraw, 957362965ul);

    /// <summary>
    /// <para>Set a custom draw callback for the gutter at the given index. <paramref name="drawCallback"/> must take the following arguments: A line index <see cref="int"/>, a gutter index <see cref="int"/>, and an area <see cref="Godot.Rect2"/>. This callback only works when the gutter type is <see cref="Godot.TextEdit.GutterType.Custom"/> (see <see cref="Godot.TextEdit.SetGutterType(int, TextEdit.GutterType)"/>).</para>
    /// </summary>
    public void SetGutterCustomDraw(int column, Callable drawCallback)
    {
        NativeCalls.godot_icall_2_402(MethodBind215, GodotObject.GetPtr(this), column, drawCallback);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind216 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTotalGutterWidth, 3905245786ul);

    /// <summary>
    /// <para>Returns the total width of all gutters and internal padding.</para>
    /// </summary>
    public int GetTotalGutterWidth()
    {
        return NativeCalls.godot_icall_0_39(MethodBind216, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind217 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLineGutterMetadata, 2060538656ul);

    /// <summary>
    /// <para>Sets the metadata for <paramref name="gutter"/> on <paramref name="line"/> to <paramref name="metadata"/>.</para>
    /// </summary>
    public void SetLineGutterMetadata(int line, int gutter, Variant metadata)
    {
        NativeCalls.godot_icall_3_85(MethodBind217, GodotObject.GetPtr(this), line, gutter, metadata);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind218 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLineGutterMetadata, 678354945ul);

    /// <summary>
    /// <para>Returns the metadata currently in <paramref name="gutter"/> at <paramref name="line"/>.</para>
    /// </summary>
    public Variant GetLineGutterMetadata(int line, int gutter)
    {
        return NativeCalls.godot_icall_2_89(MethodBind218, GodotObject.GetPtr(this), line, gutter);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind219 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLineGutterText, 2285447957ul);

    /// <summary>
    /// <para>Sets the text for <paramref name="gutter"/> on <paramref name="line"/> to <paramref name="text"/>. This only works when the gutter type is <see cref="Godot.TextEdit.GutterType.String"/> (see <see cref="Godot.TextEdit.SetGutterType(int, TextEdit.GutterType)"/>).</para>
    /// </summary>
    public void SetLineGutterText(int line, int gutter, string text)
    {
        NativeCalls.godot_icall_3_1313(MethodBind219, GodotObject.GetPtr(this), line, gutter, text);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind220 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLineGutterText, 1391810591ul);

    /// <summary>
    /// <para>Returns the text currently in <paramref name="gutter"/> at <paramref name="line"/>. This only works when the gutter type is <see cref="Godot.TextEdit.GutterType.String"/> (see <see cref="Godot.TextEdit.SetGutterType(int, TextEdit.GutterType)"/>).</para>
    /// </summary>
    public string GetLineGutterText(int line, int gutter)
    {
        return NativeCalls.godot_icall_2_222(MethodBind220, GodotObject.GetPtr(this), line, gutter);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind221 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLineGutterIcon, 176101966ul);

    /// <summary>
    /// <para>Sets the icon for <paramref name="gutter"/> on <paramref name="line"/> to <paramref name="icon"/>. This only works when the gutter type is <see cref="Godot.TextEdit.GutterType.Icon"/> (see <see cref="Godot.TextEdit.SetGutterType(int, TextEdit.GutterType)"/>).</para>
    /// </summary>
    public void SetLineGutterIcon(int line, int gutter, Texture2D icon)
    {
        NativeCalls.godot_icall_3_100(MethodBind221, GodotObject.GetPtr(this), line, gutter, GodotObject.GetPtr(icon));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind222 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLineGutterIcon, 2584904275ul);

    /// <summary>
    /// <para>Returns the icon currently in <paramref name="gutter"/> at <paramref name="line"/>. This only works when the gutter type is <see cref="Godot.TextEdit.GutterType.Icon"/> (see <see cref="Godot.TextEdit.SetGutterType(int, TextEdit.GutterType)"/>).</para>
    /// </summary>
    public Texture2D GetLineGutterIcon(int line, int gutter)
    {
        return (Texture2D)NativeCalls.godot_icall_2_101(MethodBind222, GodotObject.GetPtr(this), line, gutter);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind223 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLineGutterItemColor, 3733378741ul);

    /// <summary>
    /// <para>Sets the color for <paramref name="gutter"/> on <paramref name="line"/> to <paramref name="color"/>.</para>
    /// </summary>
    public unsafe void SetLineGutterItemColor(int line, int gutter, Color color)
    {
        NativeCalls.godot_icall_3_736(MethodBind223, GodotObject.GetPtr(this), line, gutter, &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind224 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLineGutterItemColor, 2165839948ul);

    /// <summary>
    /// <para>Returns the color currently in <paramref name="gutter"/> at <paramref name="line"/>.</para>
    /// </summary>
    public Color GetLineGutterItemColor(int line, int gutter)
    {
        return NativeCalls.godot_icall_2_734(MethodBind224, GodotObject.GetPtr(this), line, gutter);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind225 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLineGutterClickable, 1383440665ul);

    /// <summary>
    /// <para>If <paramref name="clickable"/> is <see langword="true"/>, makes the <paramref name="gutter"/> on the given <paramref name="line"/> clickable. This is like <see cref="Godot.TextEdit.SetGutterClickable(int, bool)"/>, but for a single line. If <see cref="Godot.TextEdit.IsGutterClickable(int)"/> is <see langword="true"/>, this will not have any effect. See <see cref="Godot.TextEdit.IsLineGutterClickable(int, int)"/> and <see cref="Godot.TextEdit.GutterClicked"/>.</para>
    /// </summary>
    public void SetLineGutterClickable(int line, int gutter, bool clickable)
    {
        NativeCalls.godot_icall_3_197(MethodBind225, GodotObject.GetPtr(this), line, gutter, clickable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind226 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsLineGutterClickable, 2522259332ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the gutter at the given index on the given line is clickable. See <see cref="Godot.TextEdit.SetLineGutterClickable(int, int, bool)"/>.</para>
    /// </summary>
    public bool IsLineGutterClickable(int line, int gutter)
    {
        return NativeCalls.godot_icall_2_40(MethodBind226, GodotObject.GetPtr(this), line, gutter).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind227 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLineBackgroundColor, 2878471219ul);

    /// <summary>
    /// <para>Sets the custom background color of the given line. If transparent, this color is applied on top of the default background color (See <c>background_color</c>). If set to <c>Color(0, 0, 0, 0)</c>, no additional color is applied.</para>
    /// </summary>
    public unsafe void SetLineBackgroundColor(int line, Color color)
    {
        NativeCalls.godot_icall_2_687(MethodBind227, GodotObject.GetPtr(this), line, &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind228 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLineBackgroundColor, 3457211756ul);

    /// <summary>
    /// <para>Returns the custom background color of the given line. If no color is set, returns <c>Color(0, 0, 0, 0)</c>.</para>
    /// </summary>
    public Color GetLineBackgroundColor(int line)
    {
        return NativeCalls.godot_icall_1_688(MethodBind228, GodotObject.GetPtr(this), line);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind229 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSyntaxHighlighter, 2765644541ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSyntaxHighlighter(SyntaxHighlighter syntaxHighlighter)
    {
        NativeCalls.godot_icall_1_56(MethodBind229, GodotObject.GetPtr(this), GodotObject.GetPtr(syntaxHighlighter));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind230 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSyntaxHighlighter, 2721131626ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public SyntaxHighlighter GetSyntaxHighlighter()
    {
        return (SyntaxHighlighter)NativeCalls.godot_icall_0_63(MethodBind230, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind231 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetHighlightCurrentLine, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetHighlightCurrentLine(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind231, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind232 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsHighlightCurrentLineEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsHighlightCurrentLineEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind232, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind233 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetHighlightAllOccurrences, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetHighlightAllOccurrences(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind233, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind234 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsHighlightAllOccurrencesEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsHighlightAllOccurrencesEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind234, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind235 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDrawControlChars, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetDrawControlChars()
    {
        return NativeCalls.godot_icall_0_15(MethodBind235, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind236 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDrawControlChars, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDrawControlChars(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind236, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind237 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDrawTabs, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDrawTabs(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind237, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind238 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsDrawingTabs, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsDrawingTabs()
    {
        return NativeCalls.godot_icall_0_15(MethodBind238, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind239 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDrawSpaces, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDrawSpaces(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind239, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind240 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsDrawingSpaces, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsDrawingSpaces()
    {
        return NativeCalls.godot_icall_0_15(MethodBind240, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind241 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMenu, 229722558ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.PopupMenu"/> of this <see cref="Godot.TextEdit"/>. By default, this menu is displayed when right-clicking on the <see cref="Godot.TextEdit"/>.</para>
    /// <para>You can add custom menu items or remove standard ones. Make sure your IDs don't conflict with the standard ones (see <see cref="Godot.TextEdit.MenuItems"/>). For example:</para>
    /// <para><code>
    /// public override void _Ready()
    /// {
    /// 	var menu = GetMenu();
    /// 	// Remove all items after "Redo".
    /// 	menu.ItemCount = menu.GetItemIndex(TextEdit.MenuItems.Redo) + 1;
    /// 	// Add custom items.
    /// 	menu.AddSeparator();
    /// 	menu.AddItem("Insert Date", TextEdit.MenuItems.Max + 1);
    /// 	// Add event handler.
    /// 	menu.IdPressed += OnItemPressed;
    /// }
    /// 
    /// public void OnItemPressed(int id)
    /// {
    /// 	if (id == TextEdit.MenuItems.Max + 1)
    /// 	{
    /// 		InsertTextAtCaret(Time.GetDateStringFromSystem());
    /// 	}
    /// }
    /// </code></para>
    /// <para><b>Warning:</b> This is a required internal node, removing and freeing it may cause a crash. If you wish to hide it or any of its children, use their <see cref="Godot.Window.Visible"/> property.</para>
    /// </summary>
    public PopupMenu GetMenu()
    {
        return (PopupMenu)NativeCalls.godot_icall_0_53(MethodBind241, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind242 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsMenuVisible, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the menu is visible. Use this instead of <c>get_menu().visible</c> to improve performance (so the creation of the menu is avoided). See <see cref="Godot.TextEdit.GetMenu()"/>.</para>
    /// </summary>
    public bool IsMenuVisible()
    {
        return NativeCalls.godot_icall_0_15(MethodBind242, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind243 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MenuOption, 1286410249ul);

    /// <summary>
    /// <para>Executes a given action as defined in the <see cref="Godot.TextEdit.MenuItems"/> enum.</para>
    /// </summary>
    public void MenuOption(int option)
    {
        NativeCalls.godot_icall_1_38(MethodBind243, GodotObject.GetPtr(this), option);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind244 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AdjustCaretsAfterEdit, 1770277138ul);

    /// <summary>
    /// <para>This method does nothing.</para>
    /// </summary>
    [Obsolete("No longer necessary since methods now adjust carets themselves.")]
    public void AdjustCaretsAfterEdit(int caret, int fromLine, int fromCol, int toLine, int toCol)
    {
        NativeCalls.godot_icall_5_1309(MethodBind244, GodotObject.GetPtr(this), caret, fromLine, fromCol, toLine, toCol);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind245 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCaretIndexEditOrder, 969006518ul);

    /// <summary>
    /// <para>Returns a list of caret indexes in their edit order, this done from bottom to top. Edit order refers to the way actions such as <see cref="Godot.TextEdit.InsertTextAtCaret(string, int)"/> are applied.</para>
    /// </summary>
    [Obsolete("Carets no longer need to be edited in any specific order. If the carets need to be sorted, use 'Godot.TextEdit.GetSortedCarets(bool)' instead.")]
    public int[] GetCaretIndexEditOrder()
    {
        return NativeCalls.godot_icall_0_151(MethodBind245, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind246 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSelectionLine, 1591665591ul);

    /// <summary>
    /// <para>Returns the original start line of the selection.</para>
    /// </summary>
    [Obsolete("Use 'Godot.TextEdit.GetSelectionOriginLine(int)' instead.")]
    public int GetSelectionLine(int caretIndex = 0)
    {
        return NativeCalls.godot_icall_1_60(MethodBind246, GodotObject.GetPtr(this), caretIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind247 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSelectionColumn, 1591665591ul);

    /// <summary>
    /// <para>Returns the original start column of the selection.</para>
    /// </summary>
    [Obsolete("Use 'Godot.TextEdit.GetSelectionOriginColumn(int)' instead.")]
    public int GetSelectionColumn(int caretIndex = 0)
    {
        return NativeCalls.godot_icall_1_60(MethodBind247, GodotObject.GetPtr(this), caretIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind248 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLineColumnAtPos, 239517838ul);

    /// <summary>
    /// <para>Returns the line and column at the given position. In the returned vector, <c>x</c> is the column and <c>y</c> is the line.</para>
    /// <para>If <paramref name="clampLine"/> is <see langword="false"/> and <paramref name="position"/> is below the last line, <c>Vector2i(-1, -1)</c> is returned.</para>
    /// <para>If <paramref name="clampColumn"/> is <see langword="false"/> and <paramref name="position"/> is outside the column range of the line, <c>Vector2i(-1, -1)</c> is returned.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe Vector2I GetLineColumnAtPos(Vector2I position, bool allowOutOfBounds)
    {
        return NativeCalls.godot_icall_2_1314(MethodBind248, GodotObject.GetPtr(this), &position, allowOutOfBounds.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind249 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSelectionMode, 1443345937ul);

    /// <summary>
    /// <para>Sets the current selection mode.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSelectionMode(TextEdit.SelectionMode mode, int line, int column, int caretIndex)
    {
        NativeCalls.godot_icall_4_149(MethodBind249, GodotObject.GetPtr(this), (int)mode, line, column, caretIndex);
    }

    /// <summary>
    /// <para>Emitted when <see cref="Godot.TextEdit.Clear()"/> is called or <see cref="Godot.TextEdit.Text"/> is set.</para>
    /// </summary>
    public event Action TextSet
    {
        add => Connect(SignalName.TextSet, Callable.From(value));
        remove => Disconnect(SignalName.TextSet, Callable.From(value));
    }

    protected void EmitSignalTextSet()
    {
        EmitSignal(SignalName.TextSet);
    }

    /// <summary>
    /// <para>Emitted when the text changes.</para>
    /// </summary>
    public event Action TextChanged
    {
        add => Connect(SignalName.TextChanged, Callable.From(value));
        remove => Disconnect(SignalName.TextChanged, Callable.From(value));
    }

    protected void EmitSignalTextChanged()
    {
        EmitSignal(SignalName.TextChanged);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.TextEdit.LinesEditedFrom"/> event of a <see cref="Godot.TextEdit"/> class.
    /// </summary>
    public delegate void LinesEditedFromEventHandler(long fromLine, long toLine);

    private static void LinesEditedFromTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 2);
        ((LinesEditedFromEventHandler)delegateObj)(VariantUtils.ConvertTo<long>(args[0]), VariantUtils.ConvertTo<long>(args[1]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted immediately when the text changes.</para>
    /// <para>When text is added <c>fromLine</c> will be less than <c>toLine</c>. On a remove <c>toLine</c> will be less than <c>fromLine</c>.</para>
    /// </summary>
    public unsafe event LinesEditedFromEventHandler LinesEditedFrom
    {
        add => Connect(SignalName.LinesEditedFrom, Callable.CreateWithUnsafeTrampoline(value, &LinesEditedFromTrampoline));
        remove => Disconnect(SignalName.LinesEditedFrom, Callable.CreateWithUnsafeTrampoline(value, &LinesEditedFromTrampoline));
    }

    protected void EmitSignalLinesEditedFrom(long fromLine, long toLine)
    {
        EmitSignal(SignalName.LinesEditedFrom, fromLine, toLine);
    }

    /// <summary>
    /// <para>Emitted when any caret changes position.</para>
    /// </summary>
    public event Action CaretChanged
    {
        add => Connect(SignalName.CaretChanged, Callable.From(value));
        remove => Disconnect(SignalName.CaretChanged, Callable.From(value));
    }

    protected void EmitSignalCaretChanged()
    {
        EmitSignal(SignalName.CaretChanged);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.TextEdit.GutterClicked"/> event of a <see cref="Godot.TextEdit"/> class.
    /// </summary>
    public delegate void GutterClickedEventHandler(long line, long gutter);

    private static void GutterClickedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 2);
        ((GutterClickedEventHandler)delegateObj)(VariantUtils.ConvertTo<long>(args[0]), VariantUtils.ConvertTo<long>(args[1]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when a gutter is clicked.</para>
    /// </summary>
    public unsafe event GutterClickedEventHandler GutterClicked
    {
        add => Connect(SignalName.GutterClicked, Callable.CreateWithUnsafeTrampoline(value, &GutterClickedTrampoline));
        remove => Disconnect(SignalName.GutterClicked, Callable.CreateWithUnsafeTrampoline(value, &GutterClickedTrampoline));
    }

    protected void EmitSignalGutterClicked(long line, long gutter)
    {
        EmitSignal(SignalName.GutterClicked, line, gutter);
    }

    /// <summary>
    /// <para>Emitted when a gutter is added.</para>
    /// </summary>
    public event Action GutterAdded
    {
        add => Connect(SignalName.GutterAdded, Callable.From(value));
        remove => Disconnect(SignalName.GutterAdded, Callable.From(value));
    }

    protected void EmitSignalGutterAdded()
    {
        EmitSignal(SignalName.GutterAdded);
    }

    /// <summary>
    /// <para>Emitted when a gutter is removed.</para>
    /// </summary>
    public event Action GutterRemoved
    {
        add => Connect(SignalName.GutterRemoved, Callable.From(value));
        remove => Disconnect(SignalName.GutterRemoved, Callable.From(value));
    }

    protected void EmitSignalGutterRemoved()
    {
        EmitSignal(SignalName.GutterRemoved);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__backspace = "_Backspace";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__copy = "_Copy";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__cut = "_Cut";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__handle_unicode_input = "_HandleUnicodeInput";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__paste = "_Paste";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__paste_primary_clipboard = "_PastePrimaryClipboard";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_text_set = "TextSet";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_text_changed = "TextChanged";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_lines_edited_from = "LinesEditedFrom";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_caret_changed = "CaretChanged";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_gutter_clicked = "GutterClicked";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_gutter_added = "GutterAdded";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_gutter_removed = "GutterRemoved";

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
        if ((method == MethodProxyName__backspace || method == MethodName._Backspace) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__backspace.NativeValue))
        {
            _Backspace(VariantUtils.ConvertTo<int>(args[0]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__copy || method == MethodName._Copy) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__copy.NativeValue))
        {
            _Copy(VariantUtils.ConvertTo<int>(args[0]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__cut || method == MethodName._Cut) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__cut.NativeValue))
        {
            _Cut(VariantUtils.ConvertTo<int>(args[0]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__handle_unicode_input || method == MethodName._HandleUnicodeInput) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__handle_unicode_input.NativeValue))
        {
            _HandleUnicodeInput(VariantUtils.ConvertTo<int>(args[0]), VariantUtils.ConvertTo<int>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__paste || method == MethodName._Paste) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__paste.NativeValue))
        {
            _Paste(VariantUtils.ConvertTo<int>(args[0]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__paste_primary_clipboard || method == MethodName._PastePrimaryClipboard) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__paste_primary_clipboard.NativeValue))
        {
            _PastePrimaryClipboard(VariantUtils.ConvertTo<int>(args[0]));
            ret = default;
            return true;
        }
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
        if (method == MethodName._Backspace)
        {
            if (HasGodotClassMethod(MethodProxyName__backspace.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._Copy)
        {
            if (HasGodotClassMethod(MethodProxyName__copy.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._Cut)
        {
            if (HasGodotClassMethod(MethodProxyName__cut.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._HandleUnicodeInput)
        {
            if (HasGodotClassMethod(MethodProxyName__handle_unicode_input.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._Paste)
        {
            if (HasGodotClassMethod(MethodProxyName__paste.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._PastePrimaryClipboard)
        {
            if (HasGodotClassMethod(MethodProxyName__paste_primary_clipboard.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
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
        if (signal == SignalName.TextSet)
        {
            if (HasGodotClassSignal(SignalProxyName_text_set.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.TextChanged)
        {
            if (HasGodotClassSignal(SignalProxyName_text_changed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.LinesEditedFrom)
        {
            if (HasGodotClassSignal(SignalProxyName_lines_edited_from.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.CaretChanged)
        {
            if (HasGodotClassSignal(SignalProxyName_caret_changed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.GutterClicked)
        {
            if (HasGodotClassSignal(SignalProxyName_gutter_clicked.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.GutterAdded)
        {
            if (HasGodotClassSignal(SignalProxyName_gutter_added.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.GutterRemoved)
        {
            if (HasGodotClassSignal(SignalProxyName_gutter_removed.NativeValue.DangerousSelfRef))
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
        /// Cached name for the 'editable' property.
        /// </summary>
        public static readonly StringName Editable = "editable";
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
        /// Cached name for the 'shortcut_keys_enabled' property.
        /// </summary>
        public static readonly StringName ShortcutKeysEnabled = "shortcut_keys_enabled";
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
        /// Cached name for the 'middle_mouse_paste_enabled' property.
        /// </summary>
        public static readonly StringName MiddleMousePasteEnabled = "middle_mouse_paste_enabled";
        /// <summary>
        /// Cached name for the 'empty_selection_clipboard_enabled' property.
        /// </summary>
        public static readonly StringName EmptySelectionClipboardEnabled = "empty_selection_clipboard_enabled";
        /// <summary>
        /// Cached name for the 'wrap_mode' property.
        /// </summary>
        public static readonly StringName WrapMode = "wrap_mode";
        /// <summary>
        /// Cached name for the 'autowrap_mode' property.
        /// </summary>
        public static readonly StringName AutowrapMode = "autowrap_mode";
        /// <summary>
        /// Cached name for the 'indent_wrapped_lines' property.
        /// </summary>
        public static readonly StringName IndentWrappedLines = "indent_wrapped_lines";
        /// <summary>
        /// Cached name for the 'tab_input_mode' property.
        /// </summary>
        public static readonly StringName TabInputMode = "tab_input_mode";
        /// <summary>
        /// Cached name for the 'virtual_keyboard_enabled' property.
        /// </summary>
        public static readonly StringName VirtualKeyboardEnabled = "virtual_keyboard_enabled";
        /// <summary>
        /// Cached name for the 'virtual_keyboard_show_on_focus' property.
        /// </summary>
        public static readonly StringName VirtualKeyboardShowOnFocus = "virtual_keyboard_show_on_focus";
        /// <summary>
        /// Cached name for the 'scroll_smooth' property.
        /// </summary>
        public static readonly StringName ScrollSmooth = "scroll_smooth";
        /// <summary>
        /// Cached name for the 'scroll_v_scroll_speed' property.
        /// </summary>
        public static readonly StringName ScrollVScrollSpeed = "scroll_v_scroll_speed";
        /// <summary>
        /// Cached name for the 'scroll_past_end_of_file' property.
        /// </summary>
        public static readonly StringName ScrollPastEndOfFile = "scroll_past_end_of_file";
        /// <summary>
        /// Cached name for the 'scroll_vertical' property.
        /// </summary>
        public static readonly StringName ScrollVertical = "scroll_vertical";
        /// <summary>
        /// Cached name for the 'scroll_horizontal' property.
        /// </summary>
        public static readonly StringName ScrollHorizontal = "scroll_horizontal";
        /// <summary>
        /// Cached name for the 'scroll_fit_content_height' property.
        /// </summary>
        public static readonly StringName ScrollFitContentHeight = "scroll_fit_content_height";
        /// <summary>
        /// Cached name for the 'scroll_fit_content_width' property.
        /// </summary>
        public static readonly StringName ScrollFitContentWidth = "scroll_fit_content_width";
        /// <summary>
        /// Cached name for the 'minimap_draw' property.
        /// </summary>
        public static readonly StringName MinimapDraw = "minimap_draw";
        /// <summary>
        /// Cached name for the 'minimap_width' property.
        /// </summary>
        public static readonly StringName MinimapWidth = "minimap_width";
        /// <summary>
        /// Cached name for the 'caret_type' property.
        /// </summary>
        public static readonly StringName CaretType = "caret_type";
        /// <summary>
        /// Cached name for the 'caret_blink' property.
        /// </summary>
        public static readonly StringName CaretBlink = "caret_blink";
        /// <summary>
        /// Cached name for the 'caret_blink_interval' property.
        /// </summary>
        public static readonly StringName CaretBlinkInterval = "caret_blink_interval";
        /// <summary>
        /// Cached name for the 'caret_draw_when_editable_disabled' property.
        /// </summary>
        public static readonly StringName CaretDrawWhenEditableDisabled = "caret_draw_when_editable_disabled";
        /// <summary>
        /// Cached name for the 'caret_move_on_right_click' property.
        /// </summary>
        public static readonly StringName CaretMoveOnRightClick = "caret_move_on_right_click";
        /// <summary>
        /// Cached name for the 'caret_mid_grapheme' property.
        /// </summary>
        public static readonly StringName CaretMidGrapheme = "caret_mid_grapheme";
        /// <summary>
        /// Cached name for the 'caret_multiple' property.
        /// </summary>
        public static readonly StringName CaretMultiple = "caret_multiple";
        /// <summary>
        /// Cached name for the 'use_default_word_separators' property.
        /// </summary>
        public static readonly StringName UseDefaultWordSeparators = "use_default_word_separators";
        /// <summary>
        /// Cached name for the 'use_custom_word_separators' property.
        /// </summary>
        public static readonly StringName UseCustomWordSeparators = "use_custom_word_separators";
        /// <summary>
        /// Cached name for the 'custom_word_separators' property.
        /// </summary>
        public static readonly StringName CustomWordSeparators = "custom_word_separators";
        /// <summary>
        /// Cached name for the 'syntax_highlighter' property.
        /// </summary>
        public static readonly StringName SyntaxHighlighter = "syntax_highlighter";
        /// <summary>
        /// Cached name for the 'highlight_all_occurrences' property.
        /// </summary>
        public static readonly StringName HighlightAllOccurrences = "highlight_all_occurrences";
        /// <summary>
        /// Cached name for the 'highlight_current_line' property.
        /// </summary>
        public static readonly StringName HighlightCurrentLine = "highlight_current_line";
        /// <summary>
        /// Cached name for the 'draw_control_chars' property.
        /// </summary>
        public static readonly StringName DrawControlChars = "draw_control_chars";
        /// <summary>
        /// Cached name for the 'draw_tabs' property.
        /// </summary>
        public static readonly StringName DrawTabs = "draw_tabs";
        /// <summary>
        /// Cached name for the 'draw_spaces' property.
        /// </summary>
        public static readonly StringName DrawSpaces = "draw_spaces";
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
        /// Cached name for the '_backspace' method.
        /// </summary>
        public static readonly StringName _Backspace = "_backspace";
        /// <summary>
        /// Cached name for the '_copy' method.
        /// </summary>
        public static readonly StringName _Copy = "_copy";
        /// <summary>
        /// Cached name for the '_cut' method.
        /// </summary>
        public static readonly StringName _Cut = "_cut";
        /// <summary>
        /// Cached name for the '_handle_unicode_input' method.
        /// </summary>
        public static readonly StringName _HandleUnicodeInput = "_handle_unicode_input";
        /// <summary>
        /// Cached name for the '_paste' method.
        /// </summary>
        public static readonly StringName _Paste = "_paste";
        /// <summary>
        /// Cached name for the '_paste_primary_clipboard' method.
        /// </summary>
        public static readonly StringName _PastePrimaryClipboard = "_paste_primary_clipboard";
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
        /// Cached name for the 'set_editable' method.
        /// </summary>
        public static readonly StringName SetEditable = "set_editable";
        /// <summary>
        /// Cached name for the 'is_editable' method.
        /// </summary>
        public static readonly StringName IsEditable = "is_editable";
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
        /// Cached name for the 'set_tab_size' method.
        /// </summary>
        public static readonly StringName SetTabSize = "set_tab_size";
        /// <summary>
        /// Cached name for the 'get_tab_size' method.
        /// </summary>
        public static readonly StringName GetTabSize = "get_tab_size";
        /// <summary>
        /// Cached name for the 'set_indent_wrapped_lines' method.
        /// </summary>
        public static readonly StringName SetIndentWrappedLines = "set_indent_wrapped_lines";
        /// <summary>
        /// Cached name for the 'is_indent_wrapped_lines' method.
        /// </summary>
        public static readonly StringName IsIndentWrappedLines = "is_indent_wrapped_lines";
        /// <summary>
        /// Cached name for the 'set_tab_input_mode' method.
        /// </summary>
        public static readonly StringName SetTabInputMode = "set_tab_input_mode";
        /// <summary>
        /// Cached name for the 'get_tab_input_mode' method.
        /// </summary>
        public static readonly StringName GetTabInputMode = "get_tab_input_mode";
        /// <summary>
        /// Cached name for the 'set_overtype_mode_enabled' method.
        /// </summary>
        public static readonly StringName SetOvertypeModeEnabled = "set_overtype_mode_enabled";
        /// <summary>
        /// Cached name for the 'is_overtype_mode_enabled' method.
        /// </summary>
        public static readonly StringName IsOvertypeModeEnabled = "is_overtype_mode_enabled";
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
        /// Cached name for the 'set_shortcut_keys_enabled' method.
        /// </summary>
        public static readonly StringName SetShortcutKeysEnabled = "set_shortcut_keys_enabled";
        /// <summary>
        /// Cached name for the 'is_shortcut_keys_enabled' method.
        /// </summary>
        public static readonly StringName IsShortcutKeysEnabled = "is_shortcut_keys_enabled";
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
        /// Cached name for the 'set_middle_mouse_paste_enabled' method.
        /// </summary>
        public static readonly StringName SetMiddleMousePasteEnabled = "set_middle_mouse_paste_enabled";
        /// <summary>
        /// Cached name for the 'is_middle_mouse_paste_enabled' method.
        /// </summary>
        public static readonly StringName IsMiddleMousePasteEnabled = "is_middle_mouse_paste_enabled";
        /// <summary>
        /// Cached name for the 'set_empty_selection_clipboard_enabled' method.
        /// </summary>
        public static readonly StringName SetEmptySelectionClipboardEnabled = "set_empty_selection_clipboard_enabled";
        /// <summary>
        /// Cached name for the 'is_empty_selection_clipboard_enabled' method.
        /// </summary>
        public static readonly StringName IsEmptySelectionClipboardEnabled = "is_empty_selection_clipboard_enabled";
        /// <summary>
        /// Cached name for the 'clear' method.
        /// </summary>
        public static readonly StringName Clear = "clear";
        /// <summary>
        /// Cached name for the 'set_text' method.
        /// </summary>
        public static readonly StringName SetText = "set_text";
        /// <summary>
        /// Cached name for the 'get_text' method.
        /// </summary>
        public static readonly StringName GetText = "get_text";
        /// <summary>
        /// Cached name for the 'get_line_count' method.
        /// </summary>
        public static readonly StringName GetLineCount = "get_line_count";
        /// <summary>
        /// Cached name for the 'set_placeholder' method.
        /// </summary>
        public static readonly StringName SetPlaceholder = "set_placeholder";
        /// <summary>
        /// Cached name for the 'get_placeholder' method.
        /// </summary>
        public static readonly StringName GetPlaceholder = "get_placeholder";
        /// <summary>
        /// Cached name for the 'set_line' method.
        /// </summary>
        public static readonly StringName SetLine = "set_line";
        /// <summary>
        /// Cached name for the 'get_line' method.
        /// </summary>
        public static readonly StringName GetLine = "get_line";
        /// <summary>
        /// Cached name for the 'get_line_with_ime' method.
        /// </summary>
        public static readonly StringName GetLineWithIme = "get_line_with_ime";
        /// <summary>
        /// Cached name for the 'get_line_width' method.
        /// </summary>
        public static readonly StringName GetLineWidth = "get_line_width";
        /// <summary>
        /// Cached name for the 'get_line_height' method.
        /// </summary>
        public static readonly StringName GetLineHeight = "get_line_height";
        /// <summary>
        /// Cached name for the 'get_indent_level' method.
        /// </summary>
        public static readonly StringName GetIndentLevel = "get_indent_level";
        /// <summary>
        /// Cached name for the 'get_first_non_whitespace_column' method.
        /// </summary>
        public static readonly StringName GetFirstNonWhiteSpaceColumn = "get_first_non_whitespace_column";
        /// <summary>
        /// Cached name for the 'swap_lines' method.
        /// </summary>
        public static readonly StringName SwapLines = "swap_lines";
        /// <summary>
        /// Cached name for the 'insert_line_at' method.
        /// </summary>
        public static readonly StringName InsertLineAt = "insert_line_at";
        /// <summary>
        /// Cached name for the 'remove_line_at' method.
        /// </summary>
        public static readonly StringName RemoveLineAt = "remove_line_at";
        /// <summary>
        /// Cached name for the 'insert_text_at_caret' method.
        /// </summary>
        public static readonly StringName InsertTextAtCaret = "insert_text_at_caret";
        /// <summary>
        /// Cached name for the 'insert_text' method.
        /// </summary>
        public static readonly StringName InsertText = "insert_text";
        /// <summary>
        /// Cached name for the 'remove_text' method.
        /// </summary>
        public static readonly StringName RemoveText = "remove_text";
        /// <summary>
        /// Cached name for the 'get_last_unhidden_line' method.
        /// </summary>
        public static readonly StringName GetLastUnhiddenLine = "get_last_unhidden_line";
        /// <summary>
        /// Cached name for the 'get_next_visible_line_offset_from' method.
        /// </summary>
        public static readonly StringName GetNextVisibleLineOffsetFrom = "get_next_visible_line_offset_from";
        /// <summary>
        /// Cached name for the 'get_next_visible_line_index_offset_from' method.
        /// </summary>
        public static readonly StringName GetNextVisibleLineIndexOffsetFrom = "get_next_visible_line_index_offset_from";
        /// <summary>
        /// Cached name for the 'backspace' method.
        /// </summary>
        public static readonly StringName Backspace = "backspace";
        /// <summary>
        /// Cached name for the 'cut' method.
        /// </summary>
        public static readonly StringName Cut = "cut";
        /// <summary>
        /// Cached name for the 'copy' method.
        /// </summary>
        public static readonly StringName Copy = "copy";
        /// <summary>
        /// Cached name for the 'paste' method.
        /// </summary>
        public static readonly StringName Paste = "paste";
        /// <summary>
        /// Cached name for the 'paste_primary_clipboard' method.
        /// </summary>
        public static readonly StringName PastePrimaryClipboard = "paste_primary_clipboard";
        /// <summary>
        /// Cached name for the 'start_action' method.
        /// </summary>
        public static readonly StringName StartAction = "start_action";
        /// <summary>
        /// Cached name for the 'end_action' method.
        /// </summary>
        public static readonly StringName EndAction = "end_action";
        /// <summary>
        /// Cached name for the 'begin_complex_operation' method.
        /// </summary>
        public static readonly StringName BeginComplexOperation = "begin_complex_operation";
        /// <summary>
        /// Cached name for the 'end_complex_operation' method.
        /// </summary>
        public static readonly StringName EndComplexOperation = "end_complex_operation";
        /// <summary>
        /// Cached name for the 'has_undo' method.
        /// </summary>
        public static readonly StringName HasUndo = "has_undo";
        /// <summary>
        /// Cached name for the 'has_redo' method.
        /// </summary>
        public static readonly StringName HasRedo = "has_redo";
        /// <summary>
        /// Cached name for the 'undo' method.
        /// </summary>
        public static readonly StringName Undo = "undo";
        /// <summary>
        /// Cached name for the 'redo' method.
        /// </summary>
        public static readonly StringName Redo = "redo";
        /// <summary>
        /// Cached name for the 'clear_undo_history' method.
        /// </summary>
        public static readonly StringName ClearUndoHistory = "clear_undo_history";
        /// <summary>
        /// Cached name for the 'tag_saved_version' method.
        /// </summary>
        public static readonly StringName TagSavedVersion = "tag_saved_version";
        /// <summary>
        /// Cached name for the 'get_version' method.
        /// </summary>
        public static readonly StringName GetVersion = "get_version";
        /// <summary>
        /// Cached name for the 'get_saved_version' method.
        /// </summary>
        public static readonly StringName GetSavedVersion = "get_saved_version";
        /// <summary>
        /// Cached name for the 'set_search_text' method.
        /// </summary>
        public static readonly StringName SetSearchText = "set_search_text";
        /// <summary>
        /// Cached name for the 'set_search_flags' method.
        /// </summary>
        public static readonly StringName SetSearchFlags = "set_search_flags";
        /// <summary>
        /// Cached name for the 'search' method.
        /// </summary>
        public static readonly StringName Search = "search";
        /// <summary>
        /// Cached name for the 'set_tooltip_request_func' method.
        /// </summary>
        public static readonly StringName SetTooltipRequestFunc = "set_tooltip_request_func";
        /// <summary>
        /// Cached name for the 'get_local_mouse_pos' method.
        /// </summary>
        public static readonly StringName GetLocalMousePos = "get_local_mouse_pos";
        /// <summary>
        /// Cached name for the 'get_word_at_pos' method.
        /// </summary>
        public static readonly StringName GetWordAtPos = "get_word_at_pos";
        /// <summary>
        /// Cached name for the 'get_line_column_at_pos' method.
        /// </summary>
        public static readonly StringName GetLineColumnAtPos = "get_line_column_at_pos";
        /// <summary>
        /// Cached name for the 'get_pos_at_line_column' method.
        /// </summary>
        public static readonly StringName GetPosAtLineColumn = "get_pos_at_line_column";
        /// <summary>
        /// Cached name for the 'get_rect_at_line_column' method.
        /// </summary>
        public static readonly StringName GetRectAtLineColumn = "get_rect_at_line_column";
        /// <summary>
        /// Cached name for the 'get_minimap_line_at_pos' method.
        /// </summary>
        public static readonly StringName GetMinimapLineAtPos = "get_minimap_line_at_pos";
        /// <summary>
        /// Cached name for the 'is_dragging_cursor' method.
        /// </summary>
        public static readonly StringName IsDraggingCursor = "is_dragging_cursor";
        /// <summary>
        /// Cached name for the 'is_mouse_over_selection' method.
        /// </summary>
        public static readonly StringName IsMouseOverSelection = "is_mouse_over_selection";
        /// <summary>
        /// Cached name for the 'set_caret_type' method.
        /// </summary>
        public static readonly StringName SetCaretType = "set_caret_type";
        /// <summary>
        /// Cached name for the 'get_caret_type' method.
        /// </summary>
        public static readonly StringName GetCaretType = "get_caret_type";
        /// <summary>
        /// Cached name for the 'set_caret_blink_enabled' method.
        /// </summary>
        public static readonly StringName SetCaretBlinkEnabled = "set_caret_blink_enabled";
        /// <summary>
        /// Cached name for the 'is_caret_blink_enabled' method.
        /// </summary>
        public static readonly StringName IsCaretBlinkEnabled = "is_caret_blink_enabled";
        /// <summary>
        /// Cached name for the 'set_caret_blink_interval' method.
        /// </summary>
        public static readonly StringName SetCaretBlinkInterval = "set_caret_blink_interval";
        /// <summary>
        /// Cached name for the 'get_caret_blink_interval' method.
        /// </summary>
        public static readonly StringName GetCaretBlinkInterval = "get_caret_blink_interval";
        /// <summary>
        /// Cached name for the 'set_draw_caret_when_editable_disabled' method.
        /// </summary>
        public static readonly StringName SetDrawCaretWhenEditableDisabled = "set_draw_caret_when_editable_disabled";
        /// <summary>
        /// Cached name for the 'is_drawing_caret_when_editable_disabled' method.
        /// </summary>
        public static readonly StringName IsDrawingCaretWhenEditableDisabled = "is_drawing_caret_when_editable_disabled";
        /// <summary>
        /// Cached name for the 'set_move_caret_on_right_click_enabled' method.
        /// </summary>
        public static readonly StringName SetMoveCaretOnRightClickEnabled = "set_move_caret_on_right_click_enabled";
        /// <summary>
        /// Cached name for the 'is_move_caret_on_right_click_enabled' method.
        /// </summary>
        public static readonly StringName IsMoveCaretOnRightClickEnabled = "is_move_caret_on_right_click_enabled";
        /// <summary>
        /// Cached name for the 'set_caret_mid_grapheme_enabled' method.
        /// </summary>
        public static readonly StringName SetCaretMidGraphemeEnabled = "set_caret_mid_grapheme_enabled";
        /// <summary>
        /// Cached name for the 'is_caret_mid_grapheme_enabled' method.
        /// </summary>
        public static readonly StringName IsCaretMidGraphemeEnabled = "is_caret_mid_grapheme_enabled";
        /// <summary>
        /// Cached name for the 'set_multiple_carets_enabled' method.
        /// </summary>
        public static readonly StringName SetMultipleCaretsEnabled = "set_multiple_carets_enabled";
        /// <summary>
        /// Cached name for the 'is_multiple_carets_enabled' method.
        /// </summary>
        public static readonly StringName IsMultipleCaretsEnabled = "is_multiple_carets_enabled";
        /// <summary>
        /// Cached name for the 'add_caret' method.
        /// </summary>
        public static readonly StringName AddCaret = "add_caret";
        /// <summary>
        /// Cached name for the 'remove_caret' method.
        /// </summary>
        public static readonly StringName RemoveCaret = "remove_caret";
        /// <summary>
        /// Cached name for the 'remove_secondary_carets' method.
        /// </summary>
        public static readonly StringName RemoveSecondaryCarets = "remove_secondary_carets";
        /// <summary>
        /// Cached name for the 'get_caret_count' method.
        /// </summary>
        public static readonly StringName GetCaretCount = "get_caret_count";
        /// <summary>
        /// Cached name for the 'add_caret_at_carets' method.
        /// </summary>
        public static readonly StringName AddCaretAtCarets = "add_caret_at_carets";
        /// <summary>
        /// Cached name for the 'get_sorted_carets' method.
        /// </summary>
        public static readonly StringName GetSortedCarets = "get_sorted_carets";
        /// <summary>
        /// Cached name for the 'collapse_carets' method.
        /// </summary>
        public static readonly StringName CollapseCarets = "collapse_carets";
        /// <summary>
        /// Cached name for the 'merge_overlapping_carets' method.
        /// </summary>
        public static readonly StringName MergeOverlappingCarets = "merge_overlapping_carets";
        /// <summary>
        /// Cached name for the 'begin_multicaret_edit' method.
        /// </summary>
        public static readonly StringName BeginMulticaretEdit = "begin_multicaret_edit";
        /// <summary>
        /// Cached name for the 'end_multicaret_edit' method.
        /// </summary>
        public static readonly StringName EndMulticaretEdit = "end_multicaret_edit";
        /// <summary>
        /// Cached name for the 'is_in_mulitcaret_edit' method.
        /// </summary>
        public static readonly StringName IsInMulitcaretEdit = "is_in_mulitcaret_edit";
        /// <summary>
        /// Cached name for the 'multicaret_edit_ignore_caret' method.
        /// </summary>
        public static readonly StringName MulticaretEditIgnoreCaret = "multicaret_edit_ignore_caret";
        /// <summary>
        /// Cached name for the 'is_caret_visible' method.
        /// </summary>
        public static readonly StringName IsCaretVisible = "is_caret_visible";
        /// <summary>
        /// Cached name for the 'get_caret_draw_pos' method.
        /// </summary>
        public static readonly StringName GetCaretDrawPos = "get_caret_draw_pos";
        /// <summary>
        /// Cached name for the 'set_caret_line' method.
        /// </summary>
        public static readonly StringName SetCaretLine = "set_caret_line";
        /// <summary>
        /// Cached name for the 'get_caret_line' method.
        /// </summary>
        public static readonly StringName GetCaretLine = "get_caret_line";
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
        /// Cached name for the 'get_caret_wrap_index' method.
        /// </summary>
        public static readonly StringName GetCaretWrapIndex = "get_caret_wrap_index";
        /// <summary>
        /// Cached name for the 'get_word_under_caret' method.
        /// </summary>
        public static readonly StringName GetWordUnderCaret = "get_word_under_caret";
        /// <summary>
        /// Cached name for the 'set_use_default_word_separators' method.
        /// </summary>
        public static readonly StringName SetUseDefaultWordSeparators = "set_use_default_word_separators";
        /// <summary>
        /// Cached name for the 'is_default_word_separators_enabled' method.
        /// </summary>
        public static readonly StringName IsDefaultWordSeparatorsEnabled = "is_default_word_separators_enabled";
        /// <summary>
        /// Cached name for the 'set_use_custom_word_separators' method.
        /// </summary>
        public static readonly StringName SetUseCustomWordSeparators = "set_use_custom_word_separators";
        /// <summary>
        /// Cached name for the 'is_custom_word_separators_enabled' method.
        /// </summary>
        public static readonly StringName IsCustomWordSeparatorsEnabled = "is_custom_word_separators_enabled";
        /// <summary>
        /// Cached name for the 'set_custom_word_separators' method.
        /// </summary>
        public static readonly StringName SetCustomWordSeparators = "set_custom_word_separators";
        /// <summary>
        /// Cached name for the 'get_custom_word_separators' method.
        /// </summary>
        public static readonly StringName GetCustomWordSeparators = "get_custom_word_separators";
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
        /// Cached name for the 'set_selection_mode' method.
        /// </summary>
        public static readonly StringName SetSelectionMode = "set_selection_mode";
        /// <summary>
        /// Cached name for the 'get_selection_mode' method.
        /// </summary>
        public static readonly StringName GetSelectionMode = "get_selection_mode";
        /// <summary>
        /// Cached name for the 'select_all' method.
        /// </summary>
        public static readonly StringName SelectAll = "select_all";
        /// <summary>
        /// Cached name for the 'select_word_under_caret' method.
        /// </summary>
        public static readonly StringName SelectWordUnderCaret = "select_word_under_caret";
        /// <summary>
        /// Cached name for the 'add_selection_for_next_occurrence' method.
        /// </summary>
        public static readonly StringName AddSelectionForNextOccurrence = "add_selection_for_next_occurrence";
        /// <summary>
        /// Cached name for the 'skip_selection_for_next_occurrence' method.
        /// </summary>
        public static readonly StringName SkipSelectionForNextOccurrence = "skip_selection_for_next_occurrence";
        /// <summary>
        /// Cached name for the 'select' method.
        /// </summary>
        public static readonly StringName Select = "select";
        /// <summary>
        /// Cached name for the 'has_selection' method.
        /// </summary>
        public static readonly StringName HasSelection = "has_selection";
        /// <summary>
        /// Cached name for the 'get_selected_text' method.
        /// </summary>
        public static readonly StringName GetSelectedText = "get_selected_text";
        /// <summary>
        /// Cached name for the 'get_selection_at_line_column' method.
        /// </summary>
        public static readonly StringName GetSelectionAtLineColumn = "get_selection_at_line_column";
        /// <summary>
        /// Cached name for the 'get_line_ranges_from_carets' method.
        /// </summary>
        public static readonly StringName GetLineRangesFromCarets = "get_line_ranges_from_carets";
        /// <summary>
        /// Cached name for the 'get_selection_origin_line' method.
        /// </summary>
        public static readonly StringName GetSelectionOriginLine = "get_selection_origin_line";
        /// <summary>
        /// Cached name for the 'get_selection_origin_column' method.
        /// </summary>
        public static readonly StringName GetSelectionOriginColumn = "get_selection_origin_column";
        /// <summary>
        /// Cached name for the 'set_selection_origin_line' method.
        /// </summary>
        public static readonly StringName SetSelectionOriginLine = "set_selection_origin_line";
        /// <summary>
        /// Cached name for the 'set_selection_origin_column' method.
        /// </summary>
        public static readonly StringName SetSelectionOriginColumn = "set_selection_origin_column";
        /// <summary>
        /// Cached name for the 'get_selection_from_line' method.
        /// </summary>
        public static readonly StringName GetSelectionFromLine = "get_selection_from_line";
        /// <summary>
        /// Cached name for the 'get_selection_from_column' method.
        /// </summary>
        public static readonly StringName GetSelectionFromColumn = "get_selection_from_column";
        /// <summary>
        /// Cached name for the 'get_selection_to_line' method.
        /// </summary>
        public static readonly StringName GetSelectionToLine = "get_selection_to_line";
        /// <summary>
        /// Cached name for the 'get_selection_to_column' method.
        /// </summary>
        public static readonly StringName GetSelectionToColumn = "get_selection_to_column";
        /// <summary>
        /// Cached name for the 'is_caret_after_selection_origin' method.
        /// </summary>
        public static readonly StringName IsCaretAfterSelectionOrigin = "is_caret_after_selection_origin";
        /// <summary>
        /// Cached name for the 'deselect' method.
        /// </summary>
        public static readonly StringName Deselect = "deselect";
        /// <summary>
        /// Cached name for the 'delete_selection' method.
        /// </summary>
        public static readonly StringName DeleteSelection = "delete_selection";
        /// <summary>
        /// Cached name for the 'set_line_wrapping_mode' method.
        /// </summary>
        public static readonly StringName SetLineWrappingMode = "set_line_wrapping_mode";
        /// <summary>
        /// Cached name for the 'get_line_wrapping_mode' method.
        /// </summary>
        public static readonly StringName GetLineWrappingMode = "get_line_wrapping_mode";
        /// <summary>
        /// Cached name for the 'set_autowrap_mode' method.
        /// </summary>
        public static readonly StringName SetAutowrapMode = "set_autowrap_mode";
        /// <summary>
        /// Cached name for the 'get_autowrap_mode' method.
        /// </summary>
        public static readonly StringName GetAutowrapMode = "get_autowrap_mode";
        /// <summary>
        /// Cached name for the 'is_line_wrapped' method.
        /// </summary>
        public static readonly StringName IsLineWrapped = "is_line_wrapped";
        /// <summary>
        /// Cached name for the 'get_line_wrap_count' method.
        /// </summary>
        public static readonly StringName GetLineWrapCount = "get_line_wrap_count";
        /// <summary>
        /// Cached name for the 'get_line_wrap_index_at_column' method.
        /// </summary>
        public static readonly StringName GetLineWrapIndexAtColumn = "get_line_wrap_index_at_column";
        /// <summary>
        /// Cached name for the 'get_line_wrapped_text' method.
        /// </summary>
        public static readonly StringName GetLineWrappedText = "get_line_wrapped_text";
        /// <summary>
        /// Cached name for the 'set_smooth_scroll_enabled' method.
        /// </summary>
        public static readonly StringName SetSmoothScrollEnabled = "set_smooth_scroll_enabled";
        /// <summary>
        /// Cached name for the 'is_smooth_scroll_enabled' method.
        /// </summary>
        public static readonly StringName IsSmoothScrollEnabled = "is_smooth_scroll_enabled";
        /// <summary>
        /// Cached name for the 'get_v_scroll_bar' method.
        /// </summary>
        public static readonly StringName GetVScrollBar = "get_v_scroll_bar";
        /// <summary>
        /// Cached name for the 'get_h_scroll_bar' method.
        /// </summary>
        public static readonly StringName GetHScrollBar = "get_h_scroll_bar";
        /// <summary>
        /// Cached name for the 'set_v_scroll' method.
        /// </summary>
        public static readonly StringName SetVScroll = "set_v_scroll";
        /// <summary>
        /// Cached name for the 'get_v_scroll' method.
        /// </summary>
        public static readonly StringName GetVScroll = "get_v_scroll";
        /// <summary>
        /// Cached name for the 'set_h_scroll' method.
        /// </summary>
        public static readonly StringName SetHScroll = "set_h_scroll";
        /// <summary>
        /// Cached name for the 'get_h_scroll' method.
        /// </summary>
        public static readonly StringName GetHScroll = "get_h_scroll";
        /// <summary>
        /// Cached name for the 'set_scroll_past_end_of_file_enabled' method.
        /// </summary>
        public static readonly StringName SetScrollPastEndOfFileEnabled = "set_scroll_past_end_of_file_enabled";
        /// <summary>
        /// Cached name for the 'is_scroll_past_end_of_file_enabled' method.
        /// </summary>
        public static readonly StringName IsScrollPastEndOfFileEnabled = "is_scroll_past_end_of_file_enabled";
        /// <summary>
        /// Cached name for the 'set_v_scroll_speed' method.
        /// </summary>
        public static readonly StringName SetVScrollSpeed = "set_v_scroll_speed";
        /// <summary>
        /// Cached name for the 'get_v_scroll_speed' method.
        /// </summary>
        public static readonly StringName GetVScrollSpeed = "get_v_scroll_speed";
        /// <summary>
        /// Cached name for the 'set_fit_content_height_enabled' method.
        /// </summary>
        public static readonly StringName SetFitContentHeightEnabled = "set_fit_content_height_enabled";
        /// <summary>
        /// Cached name for the 'is_fit_content_height_enabled' method.
        /// </summary>
        public static readonly StringName IsFitContentHeightEnabled = "is_fit_content_height_enabled";
        /// <summary>
        /// Cached name for the 'set_fit_content_width_enabled' method.
        /// </summary>
        public static readonly StringName SetFitContentWidthEnabled = "set_fit_content_width_enabled";
        /// <summary>
        /// Cached name for the 'is_fit_content_width_enabled' method.
        /// </summary>
        public static readonly StringName IsFitContentWidthEnabled = "is_fit_content_width_enabled";
        /// <summary>
        /// Cached name for the 'get_scroll_pos_for_line' method.
        /// </summary>
        public static readonly StringName GetScrollPosForLine = "get_scroll_pos_for_line";
        /// <summary>
        /// Cached name for the 'set_line_as_first_visible' method.
        /// </summary>
        public static readonly StringName SetLineAsFirstVisible = "set_line_as_first_visible";
        /// <summary>
        /// Cached name for the 'get_first_visible_line' method.
        /// </summary>
        public static readonly StringName GetFirstVisibleLine = "get_first_visible_line";
        /// <summary>
        /// Cached name for the 'set_line_as_center_visible' method.
        /// </summary>
        public static readonly StringName SetLineAsCenterVisible = "set_line_as_center_visible";
        /// <summary>
        /// Cached name for the 'set_line_as_last_visible' method.
        /// </summary>
        public static readonly StringName SetLineAsLastVisible = "set_line_as_last_visible";
        /// <summary>
        /// Cached name for the 'get_last_full_visible_line' method.
        /// </summary>
        public static readonly StringName GetLastFullVisibleLine = "get_last_full_visible_line";
        /// <summary>
        /// Cached name for the 'get_last_full_visible_line_wrap_index' method.
        /// </summary>
        public static readonly StringName GetLastFullVisibleLineWrapIndex = "get_last_full_visible_line_wrap_index";
        /// <summary>
        /// Cached name for the 'get_visible_line_count' method.
        /// </summary>
        public static readonly StringName GetVisibleLineCount = "get_visible_line_count";
        /// <summary>
        /// Cached name for the 'get_visible_line_count_in_range' method.
        /// </summary>
        public static readonly StringName GetVisibleLineCountInRange = "get_visible_line_count_in_range";
        /// <summary>
        /// Cached name for the 'get_total_visible_line_count' method.
        /// </summary>
        public static readonly StringName GetTotalVisibleLineCount = "get_total_visible_line_count";
        /// <summary>
        /// Cached name for the 'adjust_viewport_to_caret' method.
        /// </summary>
        public static readonly StringName AdjustViewportToCaret = "adjust_viewport_to_caret";
        /// <summary>
        /// Cached name for the 'center_viewport_to_caret' method.
        /// </summary>
        public static readonly StringName CenterViewportToCaret = "center_viewport_to_caret";
        /// <summary>
        /// Cached name for the 'set_draw_minimap' method.
        /// </summary>
        public static readonly StringName SetDrawMinimap = "set_draw_minimap";
        /// <summary>
        /// Cached name for the 'is_drawing_minimap' method.
        /// </summary>
        public static readonly StringName IsDrawingMinimap = "is_drawing_minimap";
        /// <summary>
        /// Cached name for the 'set_minimap_width' method.
        /// </summary>
        public static readonly StringName SetMinimapWidth = "set_minimap_width";
        /// <summary>
        /// Cached name for the 'get_minimap_width' method.
        /// </summary>
        public static readonly StringName GetMinimapWidth = "get_minimap_width";
        /// <summary>
        /// Cached name for the 'get_minimap_visible_lines' method.
        /// </summary>
        public static readonly StringName GetMinimapVisibleLines = "get_minimap_visible_lines";
        /// <summary>
        /// Cached name for the 'add_gutter' method.
        /// </summary>
        public static readonly StringName AddGutter = "add_gutter";
        /// <summary>
        /// Cached name for the 'remove_gutter' method.
        /// </summary>
        public static readonly StringName RemoveGutter = "remove_gutter";
        /// <summary>
        /// Cached name for the 'get_gutter_count' method.
        /// </summary>
        public static readonly StringName GetGutterCount = "get_gutter_count";
        /// <summary>
        /// Cached name for the 'set_gutter_name' method.
        /// </summary>
        public static readonly StringName SetGutterName = "set_gutter_name";
        /// <summary>
        /// Cached name for the 'get_gutter_name' method.
        /// </summary>
        public static readonly StringName GetGutterName = "get_gutter_name";
        /// <summary>
        /// Cached name for the 'set_gutter_type' method.
        /// </summary>
        public static readonly StringName SetGutterType = "set_gutter_type";
        /// <summary>
        /// Cached name for the 'get_gutter_type' method.
        /// </summary>
        public static readonly StringName GetGutterType = "get_gutter_type";
        /// <summary>
        /// Cached name for the 'set_gutter_width' method.
        /// </summary>
        public static readonly StringName SetGutterWidth = "set_gutter_width";
        /// <summary>
        /// Cached name for the 'get_gutter_width' method.
        /// </summary>
        public static readonly StringName GetGutterWidth = "get_gutter_width";
        /// <summary>
        /// Cached name for the 'set_gutter_draw' method.
        /// </summary>
        public static readonly StringName SetGutterDraw = "set_gutter_draw";
        /// <summary>
        /// Cached name for the 'is_gutter_drawn' method.
        /// </summary>
        public static readonly StringName IsGutterDrawn = "is_gutter_drawn";
        /// <summary>
        /// Cached name for the 'set_gutter_clickable' method.
        /// </summary>
        public static readonly StringName SetGutterClickable = "set_gutter_clickable";
        /// <summary>
        /// Cached name for the 'is_gutter_clickable' method.
        /// </summary>
        public static readonly StringName IsGutterClickable = "is_gutter_clickable";
        /// <summary>
        /// Cached name for the 'set_gutter_overwritable' method.
        /// </summary>
        public static readonly StringName SetGutterOverwritable = "set_gutter_overwritable";
        /// <summary>
        /// Cached name for the 'is_gutter_overwritable' method.
        /// </summary>
        public static readonly StringName IsGutterOverwritable = "is_gutter_overwritable";
        /// <summary>
        /// Cached name for the 'merge_gutters' method.
        /// </summary>
        public static readonly StringName MergeGutters = "merge_gutters";
        /// <summary>
        /// Cached name for the 'set_gutter_custom_draw' method.
        /// </summary>
        public static readonly StringName SetGutterCustomDraw = "set_gutter_custom_draw";
        /// <summary>
        /// Cached name for the 'get_total_gutter_width' method.
        /// </summary>
        public static readonly StringName GetTotalGutterWidth = "get_total_gutter_width";
        /// <summary>
        /// Cached name for the 'set_line_gutter_metadata' method.
        /// </summary>
        public static readonly StringName SetLineGutterMetadata = "set_line_gutter_metadata";
        /// <summary>
        /// Cached name for the 'get_line_gutter_metadata' method.
        /// </summary>
        public static readonly StringName GetLineGutterMetadata = "get_line_gutter_metadata";
        /// <summary>
        /// Cached name for the 'set_line_gutter_text' method.
        /// </summary>
        public static readonly StringName SetLineGutterText = "set_line_gutter_text";
        /// <summary>
        /// Cached name for the 'get_line_gutter_text' method.
        /// </summary>
        public static readonly StringName GetLineGutterText = "get_line_gutter_text";
        /// <summary>
        /// Cached name for the 'set_line_gutter_icon' method.
        /// </summary>
        public static readonly StringName SetLineGutterIcon = "set_line_gutter_icon";
        /// <summary>
        /// Cached name for the 'get_line_gutter_icon' method.
        /// </summary>
        public static readonly StringName GetLineGutterIcon = "get_line_gutter_icon";
        /// <summary>
        /// Cached name for the 'set_line_gutter_item_color' method.
        /// </summary>
        public static readonly StringName SetLineGutterItemColor = "set_line_gutter_item_color";
        /// <summary>
        /// Cached name for the 'get_line_gutter_item_color' method.
        /// </summary>
        public static readonly StringName GetLineGutterItemColor = "get_line_gutter_item_color";
        /// <summary>
        /// Cached name for the 'set_line_gutter_clickable' method.
        /// </summary>
        public static readonly StringName SetLineGutterClickable = "set_line_gutter_clickable";
        /// <summary>
        /// Cached name for the 'is_line_gutter_clickable' method.
        /// </summary>
        public static readonly StringName IsLineGutterClickable = "is_line_gutter_clickable";
        /// <summary>
        /// Cached name for the 'set_line_background_color' method.
        /// </summary>
        public static readonly StringName SetLineBackgroundColor = "set_line_background_color";
        /// <summary>
        /// Cached name for the 'get_line_background_color' method.
        /// </summary>
        public static readonly StringName GetLineBackgroundColor = "get_line_background_color";
        /// <summary>
        /// Cached name for the 'set_syntax_highlighter' method.
        /// </summary>
        public static readonly StringName SetSyntaxHighlighter = "set_syntax_highlighter";
        /// <summary>
        /// Cached name for the 'get_syntax_highlighter' method.
        /// </summary>
        public static readonly StringName GetSyntaxHighlighter = "get_syntax_highlighter";
        /// <summary>
        /// Cached name for the 'set_highlight_current_line' method.
        /// </summary>
        public static readonly StringName SetHighlightCurrentLine = "set_highlight_current_line";
        /// <summary>
        /// Cached name for the 'is_highlight_current_line_enabled' method.
        /// </summary>
        public static readonly StringName IsHighlightCurrentLineEnabled = "is_highlight_current_line_enabled";
        /// <summary>
        /// Cached name for the 'set_highlight_all_occurrences' method.
        /// </summary>
        public static readonly StringName SetHighlightAllOccurrences = "set_highlight_all_occurrences";
        /// <summary>
        /// Cached name for the 'is_highlight_all_occurrences_enabled' method.
        /// </summary>
        public static readonly StringName IsHighlightAllOccurrencesEnabled = "is_highlight_all_occurrences_enabled";
        /// <summary>
        /// Cached name for the 'get_draw_control_chars' method.
        /// </summary>
        public static readonly StringName GetDrawControlChars = "get_draw_control_chars";
        /// <summary>
        /// Cached name for the 'set_draw_control_chars' method.
        /// </summary>
        public static readonly StringName SetDrawControlChars = "set_draw_control_chars";
        /// <summary>
        /// Cached name for the 'set_draw_tabs' method.
        /// </summary>
        public static readonly StringName SetDrawTabs = "set_draw_tabs";
        /// <summary>
        /// Cached name for the 'is_drawing_tabs' method.
        /// </summary>
        public static readonly StringName IsDrawingTabs = "is_drawing_tabs";
        /// <summary>
        /// Cached name for the 'set_draw_spaces' method.
        /// </summary>
        public static readonly StringName SetDrawSpaces = "set_draw_spaces";
        /// <summary>
        /// Cached name for the 'is_drawing_spaces' method.
        /// </summary>
        public static readonly StringName IsDrawingSpaces = "is_drawing_spaces";
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
        /// <summary>
        /// Cached name for the 'adjust_carets_after_edit' method.
        /// </summary>
        public static readonly StringName AdjustCaretsAfterEdit = "adjust_carets_after_edit";
        /// <summary>
        /// Cached name for the 'get_caret_index_edit_order' method.
        /// </summary>
        public static readonly StringName GetCaretIndexEditOrder = "get_caret_index_edit_order";
        /// <summary>
        /// Cached name for the 'get_selection_line' method.
        /// </summary>
        public static readonly StringName GetSelectionLine = "get_selection_line";
        /// <summary>
        /// Cached name for the 'get_selection_column' method.
        /// </summary>
        public static readonly StringName GetSelectionColumn = "get_selection_column";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Control.SignalName
    {
        /// <summary>
        /// Cached name for the 'text_set' signal.
        /// </summary>
        public static readonly StringName TextSet = "text_set";
        /// <summary>
        /// Cached name for the 'text_changed' signal.
        /// </summary>
        public static readonly StringName TextChanged = "text_changed";
        /// <summary>
        /// Cached name for the 'lines_edited_from' signal.
        /// </summary>
        public static readonly StringName LinesEditedFrom = "lines_edited_from";
        /// <summary>
        /// Cached name for the 'caret_changed' signal.
        /// </summary>
        public static readonly StringName CaretChanged = "caret_changed";
        /// <summary>
        /// Cached name for the 'gutter_clicked' signal.
        /// </summary>
        public static readonly StringName GutterClicked = "gutter_clicked";
        /// <summary>
        /// Cached name for the 'gutter_added' signal.
        /// </summary>
        public static readonly StringName GutterAdded = "gutter_added";
        /// <summary>
        /// Cached name for the 'gutter_removed' signal.
        /// </summary>
        public static readonly StringName GutterRemoved = "gutter_removed";
    }
}
