namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>CodeEdit is a specialized <see cref="Godot.TextEdit"/> designed for editing plain text code files. It has many features commonly found in code editors such as line numbers, line folding, code completion, indent management, and string/comment management.</para>
/// <para><b>Note:</b> Regardless of locale, <see cref="Godot.CodeEdit"/> will by default always use left-to-right text direction to correctly display source code.</para>
/// </summary>
public partial class CodeEdit : TextEdit
{
    public enum CodeCompletionKind : long
    {
        /// <summary>
        /// <para>Marks the option as a class.</para>
        /// </summary>
        Class = 0,
        /// <summary>
        /// <para>Marks the option as a function.</para>
        /// </summary>
        Function = 1,
        /// <summary>
        /// <para>Marks the option as a Godot signal.</para>
        /// </summary>
        Signal = 2,
        /// <summary>
        /// <para>Marks the option as a variable.</para>
        /// </summary>
        Variable = 3,
        /// <summary>
        /// <para>Marks the option as a member.</para>
        /// </summary>
        Member = 4,
        /// <summary>
        /// <para>Marks the option as an enum entry.</para>
        /// </summary>
        Enum = 5,
        /// <summary>
        /// <para>Marks the option as a constant.</para>
        /// </summary>
        Constant = 6,
        /// <summary>
        /// <para>Marks the option as a Godot node path.</para>
        /// </summary>
        NodePath = 7,
        /// <summary>
        /// <para>Marks the option as a file path.</para>
        /// </summary>
        FilePath = 8,
        /// <summary>
        /// <para>Marks the option as unclassified or plain text.</para>
        /// </summary>
        PlainText = 9
    }

    public enum CodeCompletionLocation : long
    {
        /// <summary>
        /// <para>The option is local to the location of the code completion query - e.g. a local variable. Subsequent value of location represent options from the outer class, the exact value represent how far they are (in terms of inner classes).</para>
        /// </summary>
        Local = 0,
        /// <summary>
        /// <para>The option is from the containing class or a parent class, relative to the location of the code completion query. Perform a bitwise OR with the class depth (e.g. <c>0</c> for the local class, <c>1</c> for the parent, <c>2</c> for the grandparent, etc.) to store the depth of an option in the class or a parent class.</para>
        /// </summary>
        ParentMask = 256,
        /// <summary>
        /// <para>The option is from user code which is not local and not in a derived class (e.g. Autoload Singletons).</para>
        /// </summary>
        OtherUserCode = 512,
        /// <summary>
        /// <para>The option is from other engine code, not covered by the other enum constants - e.g. built-in classes.</para>
        /// </summary>
        Other = 1024
    }

    /// <summary>
    /// <para>Set when a validated word from <see cref="Godot.CodeEdit.SymbolValidate"/> is clicked, the <see cref="Godot.CodeEdit.SymbolLookup"/> should be emitted.</para>
    /// </summary>
    public bool SymbolLookupOnClick
    {
        get
        {
            return IsSymbolLookupOnClickEnabled();
        }
        set
        {
            SetSymbolLookupOnClickEnabled(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the <see cref="Godot.CodeEdit.SymbolHovered"/> signal is emitted when hovering over a word.</para>
    /// </summary>
    public bool SymbolTooltipOnHover
    {
        get
        {
            return IsSymbolTooltipOnHoverEnabled();
        }
        set
        {
            SetSymbolTooltipOnHoverEnabled(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, lines can be folded. Otherwise, line folding methods like <see cref="Godot.CodeEdit.FoldLine(int)"/> will not work and <see cref="Godot.CodeEdit.CanFoldLine(int)"/> will always return <see langword="false"/>. See <see cref="Godot.CodeEdit.GuttersDrawFoldGutter"/>.</para>
    /// </summary>
    public bool LineFolding
    {
        get
        {
            return IsLineFoldingEnabled();
        }
        set
        {
            SetLineFoldingEnabled(value);
        }
    }

    /// <summary>
    /// <para>Draws vertical lines at the provided columns. The first entry is considered a main hard guideline and is drawn more prominently.</para>
    /// </summary>
    public Godot.Collections.Array<int> LineLengthGuidelines
    {
        get
        {
            return GetLineLengthGuidelines();
        }
        set
        {
            SetLineLengthGuidelines(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, breakpoints are drawn in the gutter. This gutter is shared with bookmarks and executing lines. Clicking the gutter will toggle the breakpoint for the line, see <see cref="Godot.CodeEdit.SetLineAsBreakpoint(int, bool)"/>.</para>
    /// </summary>
    public bool GuttersDrawBreakpointsGutter
    {
        get
        {
            return IsDrawingBreakpointsGutter();
        }
        set
        {
            SetDrawBreakpointsGutter(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, bookmarks are drawn in the gutter. This gutter is shared with breakpoints and executing lines. See <see cref="Godot.CodeEdit.SetLineAsBookmarked(int, bool)"/>.</para>
    /// </summary>
    public bool GuttersDrawBookmarks
    {
        get
        {
            return IsDrawingBookmarksGutter();
        }
        set
        {
            SetDrawBookmarksGutter(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, executing lines are marked in the gutter. This gutter is shared with breakpoints and bookmarks. See <see cref="Godot.CodeEdit.SetLineAsExecuting(int, bool)"/>.</para>
    /// </summary>
    public bool GuttersDrawExecutingLines
    {
        get
        {
            return IsDrawingExecutingLinesGutter();
        }
        set
        {
            SetDrawExecutingLinesGutter(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the line number gutter is drawn. Line numbers start at <c>1</c> and are incremented for each line of text. Clicking and dragging in the line number gutter will select entire lines of text.</para>
    /// </summary>
    public bool GuttersDrawLineNumbers
    {
        get
        {
            return IsDrawLineNumbersEnabled();
        }
        set
        {
            SetDrawLineNumbers(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, line numbers drawn in the gutter are zero padded based on the total line count. Requires <see cref="Godot.CodeEdit.GuttersDrawLineNumbers"/> to be set to <see langword="true"/>.</para>
    /// </summary>
    public bool GuttersZeroPadLineNumbers
    {
        get
        {
            return IsLineNumbersZeroPadded();
        }
        set
        {
            SetLineNumbersZeroPadded(value);
        }
    }

    /// <summary>
    /// <para>The minimum width in digits reserved for the line number gutter.</para>
    /// </summary>
    public int GuttersLineNumbersMinDigits
    {
        get
        {
            return GetLineNumbersMinDigits();
        }
        set
        {
            SetLineNumbersMinDigits(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the fold gutter is drawn. In this gutter, the <c>can_fold_code_region</c> icon is drawn for each foldable line (see <see cref="Godot.CodeEdit.CanFoldLine(int)"/>) and the <c>folded_code_region</c> icon is drawn for each folded line (see <see cref="Godot.CodeEdit.IsLineFolded(int)"/>). These icons can be clicked to toggle the fold state, see <see cref="Godot.CodeEdit.ToggleFoldableLine(int)"/>. <see cref="Godot.CodeEdit.LineFolding"/> must be <see langword="true"/> to show icons.</para>
    /// </summary>
    public bool GuttersDrawFoldGutter
    {
        get
        {
            return IsDrawingFoldGutter();
        }
        set
        {
            SetDrawFoldGutter(value);
        }
    }

    /// <summary>
    /// <para>Sets the string delimiters. All existing string delimiters will be removed.</para>
    /// </summary>
    public Godot.Collections.Array<string> DelimiterStrings
    {
        get
        {
            return GetStringDelimiters();
        }
        set
        {
            SetStringDelimiters(value);
        }
    }

    /// <summary>
    /// <para>Sets the comment delimiters. All existing comment delimiters will be removed.</para>
    /// </summary>
    public Godot.Collections.Array<string> DelimiterComments
    {
        get
        {
            return GetCommentDelimiters();
        }
        set
        {
            SetCommentDelimiters(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the <c>ProjectSettings.input/ui_text_completion_query</c> action requests code completion. To handle it, see <see cref="Godot.CodeEdit._RequestCodeCompletion(bool)"/> or <see cref="Godot.CodeEdit.CodeCompletionRequested"/>.</para>
    /// </summary>
    public bool CodeCompletionEnabled
    {
        get
        {
            return IsCodeCompletionEnabled();
        }
        set
        {
            SetCodeCompletionEnabled(value);
        }
    }

    /// <summary>
    /// <para>Sets prefixes that will trigger code completion.</para>
    /// </summary>
    public Godot.Collections.Array<string> CodeCompletionPrefixes
    {
        get
        {
            return GetCodeCompletionPrefixes();
        }
        set
        {
            SetCodeCompletionPrefixes(value);
        }
    }

    /// <summary>
    /// <para>Size of the tabulation indent (one Tab press) in characters. If <see cref="Godot.CodeEdit.IndentUseSpaces"/> is enabled the number of spaces to use.</para>
    /// </summary>
    public int IndentSize
    {
        get
        {
            return GetIndentSize();
        }
        set
        {
            SetIndentSize(value);
        }
    }

    /// <summary>
    /// <para>Use spaces instead of tabs for indentation.</para>
    /// </summary>
    public bool IndentUseSpaces
    {
        get
        {
            return IsIndentUsingSpaces();
        }
        set
        {
            SetIndentUsingSpaces(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, an extra indent is automatically inserted when a new line is added and a prefix in <see cref="Godot.CodeEdit.IndentAutomaticPrefixes"/> is found. If a brace pair opening key is found, the matching closing brace will be moved to another new line (see <see cref="Godot.CodeEdit.AutoBraceCompletionPairs"/>).</para>
    /// </summary>
    public bool IndentAutomatic
    {
        get
        {
            return IsAutoIndentEnabled();
        }
        set
        {
            SetAutoIndentEnabled(value);
        }
    }

    /// <summary>
    /// <para>Prefixes to trigger an automatic indent. Used when <see cref="Godot.CodeEdit.IndentAutomatic"/> is set to <see langword="true"/>.</para>
    /// </summary>
    public Godot.Collections.Array<string> IndentAutomaticPrefixes
    {
        get
        {
            return GetAutoIndentPrefixes();
        }
        set
        {
            SetAutoIndentPrefixes(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, uses <see cref="Godot.CodeEdit.AutoBraceCompletionPairs"/> to automatically insert the closing brace when the opening brace is inserted by typing or autocompletion. Also automatically removes the closing brace when using backspace on the opening brace.</para>
    /// </summary>
    public bool AutoBraceCompletionEnabled
    {
        get
        {
            return IsAutoBraceCompletionEnabled();
        }
        set
        {
            SetAutoBraceCompletionEnabled(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, highlights brace pairs when the caret is on either one, using <see cref="Godot.CodeEdit.AutoBraceCompletionPairs"/>. If matching, the pairs will be underlined. If a brace is unmatched, it is colored with <c>brace_mismatch_color</c>.</para>
    /// </summary>
    public bool AutoBraceCompletionHighlightMatching
    {
        get
        {
            return IsHighlightMatchingBracesEnabled();
        }
        set
        {
            SetHighlightMatchingBracesEnabled(value);
        }
    }

    /// <summary>
    /// <para>Sets the brace pairs to be autocompleted. For each entry in the dictionary, the key is the opening brace and the value is the closing brace that matches it. A brace is a <see cref="string"/> made of symbols. See <see cref="Godot.CodeEdit.AutoBraceCompletionEnabled"/> and <see cref="Godot.CodeEdit.AutoBraceCompletionHighlightMatching"/>.</para>
    /// </summary>
    public Godot.Collections.Dictionary AutoBraceCompletionPairs
    {
        get
        {
            return GetAutoBraceCompletionPairs();
        }
        set
        {
            SetAutoBraceCompletionPairs(value);
        }
    }

    private static readonly System.Type CachedType = typeof(CodeEdit);

    private static readonly StringName NativeName = "CodeEdit";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public CodeEdit() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal CodeEdit(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal CodeEdit(bool memoryOwn) : base(memoryOwn) { }

    /// <summary>
    /// <para>Override this method to define how the selected entry should be inserted. If <paramref name="replace"/> is <see langword="true"/>, any existing text should be replaced.</para>
    /// </summary>
    public virtual void _ConfirmCodeCompletion(bool replace)
    {
    }

    /// <summary>
    /// <para>Override this method to define what items in <paramref name="candidates"/> should be displayed.</para>
    /// <para>Both <paramref name="candidates"/> and the return is an <see cref="Godot.Collections.Array"/> of <see cref="Godot.Collections.Dictionary"/>, see <see cref="Godot.CodeEdit.GetCodeCompletionOption(int)"/> for <see cref="Godot.Collections.Dictionary"/> content.</para>
    /// </summary>
    public virtual Godot.Collections.Array<Godot.Collections.Dictionary> _FilterCodeCompletionCandidates(Godot.Collections.Array<Godot.Collections.Dictionary> candidates)
    {
        return default;
    }

    /// <summary>
    /// <para>Override this method to define what happens when the user requests code completion. If <paramref name="force"/> is <see langword="true"/>, any checks should be bypassed.</para>
    /// </summary>
    public virtual void _RequestCodeCompletion(bool force)
    {
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetIndentSize, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetIndentSize(int size)
    {
        NativeCalls.godot_icall_1_38(MethodBind0, GodotObject.GetPtr(this), size);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetIndentSize, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetIndentSize()
    {
        return NativeCalls.godot_icall_0_39(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetIndentUsingSpaces, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetIndentUsingSpaces(bool useSpaces)
    {
        NativeCalls.godot_icall_1_14(MethodBind2, GodotObject.GetPtr(this), useSpaces.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsIndentUsingSpaces, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsIndentUsingSpaces()
    {
        return NativeCalls.godot_icall_0_15(MethodBind3, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAutoIndentEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAutoIndentEnabled(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind4, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsAutoIndentEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsAutoIndentEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind5, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAutoIndentPrefixes, 381264803ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAutoIndentPrefixes(Godot.Collections.Array<string> prefixes)
    {
        NativeCalls.godot_icall_1_138(MethodBind6, GodotObject.GetPtr(this), (godot_array)(prefixes ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAutoIndentPrefixes, 3995934104ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Godot.Collections.Array<string> GetAutoIndentPrefixes()
    {
        return new Godot.Collections.Array<string>(NativeCalls.godot_icall_0_120(MethodBind7, GodotObject.GetPtr(this)));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DoIndent, 3218959716ul);

    /// <summary>
    /// <para>If there is no selection, indentation is inserted at the caret. Otherwise, the selected lines are indented like <see cref="Godot.CodeEdit.IndentLines()"/>. Equivalent to the <c>ProjectSettings.input/ui_text_indent</c> action. The indentation characters used depend on <see cref="Godot.CodeEdit.IndentUseSpaces"/> and <see cref="Godot.CodeEdit.IndentSize"/>.</para>
    /// </summary>
    public void DoIndent()
    {
        NativeCalls.godot_icall_0_3(MethodBind8, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IndentLines, 3218959716ul);

    /// <summary>
    /// <para>Indents all lines that are selected or have a caret on them. Uses spaces or a tab depending on <see cref="Godot.CodeEdit.IndentUseSpaces"/>. See <see cref="Godot.CodeEdit.UnindentLines()"/>.</para>
    /// </summary>
    public void IndentLines()
    {
        NativeCalls.godot_icall_0_3(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.UnindentLines, 3218959716ul);

    /// <summary>
    /// <para>Unindents all lines that are selected or have a caret on them. Uses spaces or a tab depending on <see cref="Godot.CodeEdit.IndentUseSpaces"/>. Equivalent to the <c>ProjectSettings.input/ui_text_dedent</c> action. See <see cref="Godot.CodeEdit.IndentLines()"/>.</para>
    /// </summary>
    public void UnindentLines()
    {
        NativeCalls.godot_icall_0_3(MethodBind10, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ConvertIndent, 423910286ul);

    /// <summary>
    /// <para>Converts the indents of lines between <paramref name="fromLine"/> and <paramref name="toLine"/> to tabs or spaces as set by <see cref="Godot.CodeEdit.IndentUseSpaces"/>.</para>
    /// <para>Values of <c>-1</c> convert the entire text.</para>
    /// </summary>
    public void ConvertIndent(int fromLine = -1, int toLine = -1)
    {
        NativeCalls.godot_icall_2_59(MethodBind11, GodotObject.GetPtr(this), fromLine, toLine);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAutoBraceCompletionEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAutoBraceCompletionEnabled(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind12, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsAutoBraceCompletionEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsAutoBraceCompletionEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind13, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetHighlightMatchingBracesEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetHighlightMatchingBracesEnabled(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind14, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsHighlightMatchingBracesEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsHighlightMatchingBracesEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind15, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddAutoBraceCompletionPair, 3186203200ul);

    /// <summary>
    /// <para>Adds a brace pair.</para>
    /// <para>Both the start and end keys must be symbols. Only the start key has to be unique.</para>
    /// </summary>
    public void AddAutoBraceCompletionPair(string startKey, string endKey)
    {
        NativeCalls.godot_icall_2_303(MethodBind16, GodotObject.GetPtr(this), startKey, endKey);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAutoBraceCompletionPairs, 4155329257ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAutoBraceCompletionPairs(Godot.Collections.Dictionary pairs)
    {
        NativeCalls.godot_icall_1_121(MethodBind17, GodotObject.GetPtr(this), (godot_dictionary)(pairs ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAutoBraceCompletionPairs, 3102165223ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Godot.Collections.Dictionary GetAutoBraceCompletionPairs()
    {
        return NativeCalls.godot_icall_0_122(MethodBind18, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasAutoBraceCompletionOpenKey, 3927539163ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if open key <paramref name="openKey"/> exists.</para>
    /// </summary>
    public bool HasAutoBraceCompletionOpenKey(string openKey)
    {
        return NativeCalls.godot_icall_1_131(MethodBind19, GodotObject.GetPtr(this), openKey).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasAutoBraceCompletionCloseKey, 3927539163ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if close key <paramref name="closeKey"/> exists.</para>
    /// </summary>
    public bool HasAutoBraceCompletionCloseKey(string closeKey)
    {
        return NativeCalls.godot_icall_1_131(MethodBind20, GodotObject.GetPtr(this), closeKey).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAutoBraceCompletionCloseKey, 3135753539ul);

    /// <summary>
    /// <para>Gets the matching auto brace close key for <paramref name="openKey"/>.</para>
    /// </summary>
    public string GetAutoBraceCompletionCloseKey(string openKey)
    {
        return NativeCalls.godot_icall_1_304(MethodBind21, GodotObject.GetPtr(this), openKey);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDrawBreakpointsGutter, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDrawBreakpointsGutter(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind22, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsDrawingBreakpointsGutter, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsDrawingBreakpointsGutter()
    {
        return NativeCalls.godot_icall_0_15(MethodBind23, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDrawBookmarksGutter, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDrawBookmarksGutter(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind24, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsDrawingBookmarksGutter, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsDrawingBookmarksGutter()
    {
        return NativeCalls.godot_icall_0_15(MethodBind25, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDrawExecutingLinesGutter, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDrawExecutingLinesGutter(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind26, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsDrawingExecutingLinesGutter, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsDrawingExecutingLinesGutter()
    {
        return NativeCalls.godot_icall_0_15(MethodBind27, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLineAsBreakpoint, 300928843ul);

    /// <summary>
    /// <para>Sets the given line as a breakpoint. If <see langword="true"/> and <see cref="Godot.CodeEdit.GuttersDrawBreakpointsGutter"/> is <see langword="true"/>, draws the <c>breakpoint</c> icon in the gutter for this line. See <see cref="Godot.CodeEdit.GetBreakpointedLines()"/> and <see cref="Godot.CodeEdit.IsLineBreakpointed(int)"/>.</para>
    /// </summary>
    public void SetLineAsBreakpoint(int line, bool breakpointed)
    {
        NativeCalls.godot_icall_2_61(MethodBind28, GodotObject.GetPtr(this), line, breakpointed.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsLineBreakpointed, 1116898809ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the given line is breakpointed. See <see cref="Godot.CodeEdit.SetLineAsBreakpoint(int, bool)"/>.</para>
    /// </summary>
    public bool IsLineBreakpointed(int line)
    {
        return NativeCalls.godot_icall_1_62(MethodBind29, GodotObject.GetPtr(this), line).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ClearBreakpointedLines, 3218959716ul);

    /// <summary>
    /// <para>Clears all breakpointed lines.</para>
    /// </summary>
    public void ClearBreakpointedLines()
    {
        NativeCalls.godot_icall_0_3(MethodBind30, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBreakpointedLines, 1930428628ul);

    /// <summary>
    /// <para>Gets all breakpointed lines.</para>
    /// </summary>
    public int[] GetBreakpointedLines()
    {
        return NativeCalls.godot_icall_0_151(MethodBind31, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind32 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLineAsBookmarked, 300928843ul);

    /// <summary>
    /// <para>Sets the given line as bookmarked. If <see langword="true"/> and <see cref="Godot.CodeEdit.GuttersDrawBookmarks"/> is <see langword="true"/>, draws the <c>bookmark</c> icon in the gutter for this line. See <see cref="Godot.CodeEdit.GetBookmarkedLines()"/> and <see cref="Godot.CodeEdit.IsLineBookmarked(int)"/>.</para>
    /// </summary>
    public void SetLineAsBookmarked(int line, bool bookmarked)
    {
        NativeCalls.godot_icall_2_61(MethodBind32, GodotObject.GetPtr(this), line, bookmarked.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind33 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsLineBookmarked, 1116898809ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the given line is bookmarked. See <see cref="Godot.CodeEdit.SetLineAsBookmarked(int, bool)"/>.</para>
    /// </summary>
    public bool IsLineBookmarked(int line)
    {
        return NativeCalls.godot_icall_1_62(MethodBind33, GodotObject.GetPtr(this), line).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind34 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ClearBookmarkedLines, 3218959716ul);

    /// <summary>
    /// <para>Clears all bookmarked lines.</para>
    /// </summary>
    public void ClearBookmarkedLines()
    {
        NativeCalls.godot_icall_0_3(MethodBind34, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind35 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBookmarkedLines, 1930428628ul);

    /// <summary>
    /// <para>Gets all bookmarked lines.</para>
    /// </summary>
    public int[] GetBookmarkedLines()
    {
        return NativeCalls.godot_icall_0_151(MethodBind35, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind36 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLineAsExecuting, 300928843ul);

    /// <summary>
    /// <para>Sets the given line as executing. If <see langword="true"/> and <see cref="Godot.CodeEdit.GuttersDrawExecutingLines"/> is <see langword="true"/>, draws the <c>executing_line</c> icon in the gutter for this line. See <see cref="Godot.CodeEdit.GetExecutingLines()"/> and <see cref="Godot.CodeEdit.IsLineExecuting(int)"/>.</para>
    /// </summary>
    public void SetLineAsExecuting(int line, bool executing)
    {
        NativeCalls.godot_icall_2_61(MethodBind36, GodotObject.GetPtr(this), line, executing.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind37 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsLineExecuting, 1116898809ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the given line is marked as executing. See <see cref="Godot.CodeEdit.SetLineAsExecuting(int, bool)"/>.</para>
    /// </summary>
    public bool IsLineExecuting(int line)
    {
        return NativeCalls.godot_icall_1_62(MethodBind37, GodotObject.GetPtr(this), line).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind38 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ClearExecutingLines, 3218959716ul);

    /// <summary>
    /// <para>Clears all executed lines.</para>
    /// </summary>
    public void ClearExecutingLines()
    {
        NativeCalls.godot_icall_0_3(MethodBind38, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind39 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetExecutingLines, 1930428628ul);

    /// <summary>
    /// <para>Gets all executing lines.</para>
    /// </summary>
    public int[] GetExecutingLines()
    {
        return NativeCalls.godot_icall_0_151(MethodBind39, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind40 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDrawLineNumbers, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDrawLineNumbers(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind40, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind41 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsDrawLineNumbersEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsDrawLineNumbersEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind41, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind42 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLineNumbersZeroPadded, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetLineNumbersZeroPadded(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind42, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind43 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsLineNumbersZeroPadded, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsLineNumbersZeroPadded()
    {
        return NativeCalls.godot_icall_0_15(MethodBind43, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind44 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLineNumbersMinDigits, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetLineNumbersMinDigits(int count)
    {
        NativeCalls.godot_icall_1_38(MethodBind44, GodotObject.GetPtr(this), count);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind45 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLineNumbersMinDigits, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetLineNumbersMinDigits()
    {
        return NativeCalls.godot_icall_0_39(MethodBind45, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind46 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDrawFoldGutter, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDrawFoldGutter(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind46, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind47 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsDrawingFoldGutter, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsDrawingFoldGutter()
    {
        return NativeCalls.godot_icall_0_15(MethodBind47, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind48 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLineFoldingEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetLineFoldingEnabled(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind48, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind49 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsLineFoldingEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsLineFoldingEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind49, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind50 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanFoldLine, 1116898809ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the given line is foldable. A line is foldable if it is the start of a valid code region (see <see cref="Godot.CodeEdit.GetCodeRegionStartTag()"/>), if it is the start of a comment or string block, or if the next non-empty line is more indented (see <see cref="Godot.TextEdit.GetIndentLevel(int)"/>).</para>
    /// </summary>
    public bool CanFoldLine(int line)
    {
        return NativeCalls.godot_icall_1_62(MethodBind50, GodotObject.GetPtr(this), line).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind51 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FoldLine, 1286410249ul);

    /// <summary>
    /// <para>Folds the given line, if possible (see <see cref="Godot.CodeEdit.CanFoldLine(int)"/>).</para>
    /// </summary>
    public void FoldLine(int line)
    {
        NativeCalls.godot_icall_1_38(MethodBind51, GodotObject.GetPtr(this), line);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind52 = ClassDB_get_method_with_compatibility(NativeName, MethodName.UnfoldLine, 1286410249ul);

    /// <summary>
    /// <para>Unfolds the given line if it is folded or if it is hidden under a folded line.</para>
    /// </summary>
    public void UnfoldLine(int line)
    {
        NativeCalls.godot_icall_1_38(MethodBind52, GodotObject.GetPtr(this), line);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind53 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FoldAllLines, 3218959716ul);

    /// <summary>
    /// <para>Folds all lines that are possible to be folded (see <see cref="Godot.CodeEdit.CanFoldLine(int)"/>).</para>
    /// </summary>
    public void FoldAllLines()
    {
        NativeCalls.godot_icall_0_3(MethodBind53, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind54 = ClassDB_get_method_with_compatibility(NativeName, MethodName.UnfoldAllLines, 3218959716ul);

    /// <summary>
    /// <para>Unfolds all lines that are folded.</para>
    /// </summary>
    public void UnfoldAllLines()
    {
        NativeCalls.godot_icall_0_3(MethodBind54, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind55 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ToggleFoldableLine, 1286410249ul);

    /// <summary>
    /// <para>Toggle the folding of the code block at the given line.</para>
    /// </summary>
    public void ToggleFoldableLine(int line)
    {
        NativeCalls.godot_icall_1_38(MethodBind55, GodotObject.GetPtr(this), line);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind56 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ToggleFoldableLinesAtCarets, 3218959716ul);

    /// <summary>
    /// <para>Toggle the folding of the code block on all lines with a caret on them.</para>
    /// </summary>
    public void ToggleFoldableLinesAtCarets()
    {
        NativeCalls.godot_icall_0_3(MethodBind56, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind57 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsLineFolded, 1116898809ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the given line is folded. See <see cref="Godot.CodeEdit.FoldLine(int)"/>.</para>
    /// </summary>
    public bool IsLineFolded(int line)
    {
        return NativeCalls.godot_icall_1_62(MethodBind57, GodotObject.GetPtr(this), line).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind58 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFoldedLines, 3995934104ul);

    /// <summary>
    /// <para>Returns all lines that are currently folded.</para>
    /// </summary>
    public Godot.Collections.Array<int> GetFoldedLines()
    {
        return new Godot.Collections.Array<int>(NativeCalls.godot_icall_0_120(MethodBind58, GodotObject.GetPtr(this)));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind59 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CreateCodeRegion, 3218959716ul);

    /// <summary>
    /// <para>Creates a new code region with the selection. At least one single line comment delimiter have to be defined (see <see cref="Godot.CodeEdit.AddCommentDelimiter(string, string, bool)"/>).</para>
    /// <para>A code region is a part of code that is highlighted when folded and can help organize your script.</para>
    /// <para>Code region start and end tags can be customized (see <see cref="Godot.CodeEdit.SetCodeRegionTags(string, string)"/>).</para>
    /// <para>Code regions are delimited using start and end tags (respectively <c>region</c> and <c>endregion</c> by default) preceded by one line comment delimiter. (eg. <c>#region</c> and <c>#endregion</c>)</para>
    /// </summary>
    public void CreateCodeRegion()
    {
        NativeCalls.godot_icall_0_3(MethodBind59, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind60 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCodeRegionStartTag, 201670096ul);

    /// <summary>
    /// <para>Returns the code region start tag (without comment delimiter).</para>
    /// </summary>
    public string GetCodeRegionStartTag()
    {
        return NativeCalls.godot_icall_0_58(MethodBind60, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind61 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCodeRegionEndTag, 201670096ul);

    /// <summary>
    /// <para>Returns the code region end tag (without comment delimiter).</para>
    /// </summary>
    public string GetCodeRegionEndTag()
    {
        return NativeCalls.godot_icall_0_58(MethodBind61, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind62 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCodeRegionTags, 708800718ul);

    /// <summary>
    /// <para>Sets the code region start and end tags (without comment delimiter).</para>
    /// </summary>
    public void SetCodeRegionTags(string start = "region", string end = "endregion")
    {
        NativeCalls.godot_icall_2_303(MethodBind62, GodotObject.GetPtr(this), start, end);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind63 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsLineCodeRegionStart, 1116898809ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the given line is a code region start. See <see cref="Godot.CodeEdit.SetCodeRegionTags(string, string)"/>.</para>
    /// </summary>
    public bool IsLineCodeRegionStart(int line)
    {
        return NativeCalls.godot_icall_1_62(MethodBind63, GodotObject.GetPtr(this), line).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind64 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsLineCodeRegionEnd, 1116898809ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the given line is a code region end. See <see cref="Godot.CodeEdit.SetCodeRegionTags(string, string)"/>.</para>
    /// </summary>
    public bool IsLineCodeRegionEnd(int line)
    {
        return NativeCalls.godot_icall_1_62(MethodBind64, GodotObject.GetPtr(this), line).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind65 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddStringDelimiter, 3146098955ul);

    /// <summary>
    /// <para>Defines a string delimiter from <paramref name="startKey"/> to <paramref name="endKey"/>. Both keys should be symbols, and <paramref name="startKey"/> must not be shared with other delimiters.</para>
    /// <para>If <paramref name="lineOnly"/> is <see langword="true"/> or <paramref name="endKey"/> is an empty <see cref="string"/>, the region does not carry over to the next line.</para>
    /// </summary>
    public void AddStringDelimiter(string startKey, string endKey, bool lineOnly = false)
    {
        NativeCalls.godot_icall_3_305(MethodBind65, GodotObject.GetPtr(this), startKey, endKey, lineOnly.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind66 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveStringDelimiter, 83702148ul);

    /// <summary>
    /// <para>Removes the string delimiter with <paramref name="startKey"/>.</para>
    /// </summary>
    public void RemoveStringDelimiter(string startKey)
    {
        NativeCalls.godot_icall_1_57(MethodBind66, GodotObject.GetPtr(this), startKey);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind67 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasStringDelimiter, 3927539163ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if string <paramref name="startKey"/> exists.</para>
    /// </summary>
    public bool HasStringDelimiter(string startKey)
    {
        return NativeCalls.godot_icall_1_131(MethodBind67, GodotObject.GetPtr(this), startKey).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind68 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetStringDelimiters, 381264803ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetStringDelimiters(Godot.Collections.Array<string> stringDelimiters)
    {
        NativeCalls.godot_icall_1_138(MethodBind68, GodotObject.GetPtr(this), (godot_array)(stringDelimiters ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind69 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ClearStringDelimiters, 3218959716ul);

    /// <summary>
    /// <para>Removes all string delimiters.</para>
    /// </summary>
    public void ClearStringDelimiters()
    {
        NativeCalls.godot_icall_0_3(MethodBind69, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind70 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetStringDelimiters, 3995934104ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Godot.Collections.Array<string> GetStringDelimiters()
    {
        return new Godot.Collections.Array<string>(NativeCalls.godot_icall_0_120(MethodBind70, GodotObject.GetPtr(this)));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind71 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsInString, 688195400ul);

    /// <summary>
    /// <para>Returns the delimiter index if <paramref name="line"/> <paramref name="column"/> is in a string. If <paramref name="column"/> is not provided, will return the delimiter index if the entire <paramref name="line"/> is a string. Otherwise <c>-1</c>.</para>
    /// </summary>
    public int IsInString(int line, int column = -1)
    {
        return NativeCalls.godot_icall_2_73(MethodBind71, GodotObject.GetPtr(this), line, column);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind72 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddCommentDelimiter, 3146098955ul);

    /// <summary>
    /// <para>Adds a comment delimiter from <paramref name="startKey"/> to <paramref name="endKey"/>. Both keys should be symbols, and <paramref name="startKey"/> must not be shared with other delimiters.</para>
    /// <para>If <paramref name="lineOnly"/> is <see langword="true"/> or <paramref name="endKey"/> is an empty <see cref="string"/>, the region does not carry over to the next line.</para>
    /// </summary>
    public void AddCommentDelimiter(string startKey, string endKey, bool lineOnly = false)
    {
        NativeCalls.godot_icall_3_305(MethodBind72, GodotObject.GetPtr(this), startKey, endKey, lineOnly.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind73 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveCommentDelimiter, 83702148ul);

    /// <summary>
    /// <para>Removes the comment delimiter with <paramref name="startKey"/>.</para>
    /// </summary>
    public void RemoveCommentDelimiter(string startKey)
    {
        NativeCalls.godot_icall_1_57(MethodBind73, GodotObject.GetPtr(this), startKey);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind74 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasCommentDelimiter, 3927539163ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if comment <paramref name="startKey"/> exists.</para>
    /// </summary>
    public bool HasCommentDelimiter(string startKey)
    {
        return NativeCalls.godot_icall_1_131(MethodBind74, GodotObject.GetPtr(this), startKey).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind75 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCommentDelimiters, 381264803ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCommentDelimiters(Godot.Collections.Array<string> commentDelimiters)
    {
        NativeCalls.godot_icall_1_138(MethodBind75, GodotObject.GetPtr(this), (godot_array)(commentDelimiters ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind76 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ClearCommentDelimiters, 3218959716ul);

    /// <summary>
    /// <para>Removes all comment delimiters.</para>
    /// </summary>
    public void ClearCommentDelimiters()
    {
        NativeCalls.godot_icall_0_3(MethodBind76, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind77 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCommentDelimiters, 3995934104ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Godot.Collections.Array<string> GetCommentDelimiters()
    {
        return new Godot.Collections.Array<string>(NativeCalls.godot_icall_0_120(MethodBind77, GodotObject.GetPtr(this)));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind78 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsInComment, 688195400ul);

    /// <summary>
    /// <para>Returns delimiter index if <paramref name="line"/> <paramref name="column"/> is in a comment. If <paramref name="column"/> is not provided, will return delimiter index if the entire <paramref name="line"/> is a comment. Otherwise <c>-1</c>.</para>
    /// </summary>
    public int IsInComment(int line, int column = -1)
    {
        return NativeCalls.godot_icall_2_73(MethodBind78, GodotObject.GetPtr(this), line, column);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind79 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDelimiterStartKey, 844755477ul);

    /// <summary>
    /// <para>Gets the start key for a string or comment region index.</para>
    /// </summary>
    public string GetDelimiterStartKey(int delimiterIndex)
    {
        return NativeCalls.godot_icall_1_133(MethodBind79, GodotObject.GetPtr(this), delimiterIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind80 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDelimiterEndKey, 844755477ul);

    /// <summary>
    /// <para>Gets the end key for a string or comment region index.</para>
    /// </summary>
    public string GetDelimiterEndKey(int delimiterIndex)
    {
        return NativeCalls.godot_icall_1_133(MethodBind80, GodotObject.GetPtr(this), delimiterIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind81 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDelimiterStartPosition, 3016396712ul);

    /// <summary>
    /// <para>If <paramref name="line"/> <paramref name="column"/> is in a string or comment, returns the start position of the region. If not or no start could be found, both <see cref="Godot.Vector2"/> values will be <c>-1</c>.</para>
    /// </summary>
    public Vector2 GetDelimiterStartPosition(int line, int column)
    {
        return NativeCalls.godot_icall_2_97(MethodBind81, GodotObject.GetPtr(this), line, column);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind82 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDelimiterEndPosition, 3016396712ul);

    /// <summary>
    /// <para>If <paramref name="line"/> <paramref name="column"/> is in a string or comment, returns the end position of the region. If not or no end could be found, both <see cref="Godot.Vector2"/> values will be <c>-1</c>.</para>
    /// </summary>
    public Vector2 GetDelimiterEndPosition(int line, int column)
    {
        return NativeCalls.godot_icall_2_97(MethodBind82, GodotObject.GetPtr(this), line, column);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind83 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCodeHint, 83702148ul);

    /// <summary>
    /// <para>Sets the code hint text. Pass an empty string to clear.</para>
    /// </summary>
    public void SetCodeHint(string codeHint)
    {
        NativeCalls.godot_icall_1_57(MethodBind83, GodotObject.GetPtr(this), codeHint);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind84 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCodeHintDrawBelow, 2586408642ul);

    /// <summary>
    /// <para>If <see langword="true"/>, the code hint will draw below the main caret. If <see langword="false"/>, the code hint will draw above the main caret. See <see cref="Godot.CodeEdit.SetCodeHint(string)"/>.</para>
    /// </summary>
    public void SetCodeHintDrawBelow(bool drawBelow)
    {
        NativeCalls.godot_icall_1_14(MethodBind84, GodotObject.GetPtr(this), drawBelow.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind85 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTextForCodeCompletion, 201670096ul);

    /// <summary>
    /// <para>Returns the full text with char <c>0xFFFF</c> at the caret location.</para>
    /// </summary>
    public string GetTextForCodeCompletion()
    {
        return NativeCalls.godot_icall_0_58(MethodBind85, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind86 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RequestCodeCompletion, 107499316ul);

    /// <summary>
    /// <para>Emits <see cref="Godot.CodeEdit.CodeCompletionRequested"/>, if <paramref name="force"/> is <see langword="true"/> will bypass all checks. Otherwise will check that the caret is in a word or in front of a prefix. Will ignore the request if all current options are of type file path, node path, or signal.</para>
    /// </summary>
    public void RequestCodeCompletion(bool force = false)
    {
        NativeCalls.godot_icall_1_14(MethodBind86, GodotObject.GetPtr(this), force.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind87 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddCodeCompletionOption, 3944379502ul);

    /// <summary>
    /// <para>Submits an item to the queue of potential candidates for the autocomplete menu. Call <see cref="Godot.CodeEdit.UpdateCodeCompletionOptions(bool)"/> to update the list.</para>
    /// <para><paramref name="location"/> indicates location of the option relative to the location of the code completion query. See <see cref="Godot.CodeEdit.CodeCompletionLocation"/> for how to set this value.</para>
    /// <para><b>Note:</b> This list will replace all current candidates.</para>
    /// </summary>
    /// <param name="textColor">If the parameter is null, then the default value is <c>new Color(1.0f, 1.0f, 1.0f, 1.0f)</c>.</param>
    public unsafe void AddCodeCompletionOption(CodeEdit.CodeCompletionKind type, string displayText, string insertText, Nullable<Color> textColor = null, Resource icon = null, Variant value = default, int location = 1024)
    {
        Color textColorOrDefVal = textColor.HasValue ? textColor.Value : new Color(1.0f, 1.0f, 1.0f, 1.0f);
        NativeCalls.godot_icall_7_306(MethodBind87, GodotObject.GetPtr(this), (int)type, displayText, insertText, &textColorOrDefVal, GodotObject.GetPtr(icon), value, location);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind88 = ClassDB_get_method_with_compatibility(NativeName, MethodName.UpdateCodeCompletionOptions, 2586408642ul);

    /// <summary>
    /// <para>Submits all completion options added with <see cref="Godot.CodeEdit.AddCodeCompletionOption(CodeEdit.CodeCompletionKind, string, string, Nullable{Color}, Resource, Variant, int)"/>. Will try to force the autocomplete menu to popup, if <paramref name="force"/> is <see langword="true"/>.</para>
    /// <para><b>Note:</b> This will replace all current candidates.</para>
    /// </summary>
    public void UpdateCodeCompletionOptions(bool force)
    {
        NativeCalls.godot_icall_1_14(MethodBind88, GodotObject.GetPtr(this), force.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind89 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCodeCompletionOptions, 3995934104ul);

    /// <summary>
    /// <para>Gets all completion options, see <see cref="Godot.CodeEdit.GetCodeCompletionOption(int)"/> for return content.</para>
    /// </summary>
    public Godot.Collections.Array<Godot.Collections.Dictionary> GetCodeCompletionOptions()
    {
        return new Godot.Collections.Array<Godot.Collections.Dictionary>(NativeCalls.godot_icall_0_120(MethodBind89, GodotObject.GetPtr(this)));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind90 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCodeCompletionOption, 3485342025ul);

    /// <summary>
    /// <para>Gets the completion option at <paramref name="index"/>. The return <see cref="Godot.Collections.Dictionary"/> has the following key-values:</para>
    /// <para><c>kind</c>: <see cref="Godot.CodeEdit.CodeCompletionKind"/></para>
    /// <para><c>display_text</c>: Text that is shown on the autocomplete menu.</para>
    /// <para><c>insert_text</c>: Text that is to be inserted when this item is selected.</para>
    /// <para><c>font_color</c>: Color of the text on the autocomplete menu.</para>
    /// <para><c>icon</c>: Icon to draw on the autocomplete menu.</para>
    /// <para><c>default_value</c>: Value of the symbol.</para>
    /// </summary>
    public Godot.Collections.Dictionary GetCodeCompletionOption(int index)
    {
        return NativeCalls.godot_icall_1_307(MethodBind90, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind91 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCodeCompletionSelectedIndex, 3905245786ul);

    /// <summary>
    /// <para>Gets the index of the current selected completion option.</para>
    /// </summary>
    public int GetCodeCompletionSelectedIndex()
    {
        return NativeCalls.godot_icall_0_39(MethodBind91, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind92 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCodeCompletionSelectedIndex, 1286410249ul);

    /// <summary>
    /// <para>Sets the current selected completion option.</para>
    /// </summary>
    public void SetCodeCompletionSelectedIndex(int index)
    {
        NativeCalls.godot_icall_1_38(MethodBind92, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind93 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ConfirmCodeCompletion, 107499316ul);

    /// <summary>
    /// <para>Inserts the selected entry into the text. If <paramref name="replace"/> is <see langword="true"/>, any existing text is replaced rather than merged.</para>
    /// </summary>
    public void ConfirmCodeCompletion(bool replace = false)
    {
        NativeCalls.godot_icall_1_14(MethodBind93, GodotObject.GetPtr(this), replace.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind94 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CancelCodeCompletion, 3218959716ul);

    /// <summary>
    /// <para>Cancels the autocomplete menu.</para>
    /// </summary>
    public void CancelCodeCompletion()
    {
        NativeCalls.godot_icall_0_3(MethodBind94, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind95 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCodeCompletionEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCodeCompletionEnabled(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind95, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind96 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsCodeCompletionEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsCodeCompletionEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind96, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind97 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCodeCompletionPrefixes, 381264803ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCodeCompletionPrefixes(Godot.Collections.Array<string> prefixes)
    {
        NativeCalls.godot_icall_1_138(MethodBind97, GodotObject.GetPtr(this), (godot_array)(prefixes ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind98 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCodeCompletionPrefixes, 3995934104ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Godot.Collections.Array<string> GetCodeCompletionPrefixes()
    {
        return new Godot.Collections.Array<string>(NativeCalls.godot_icall_0_120(MethodBind98, GodotObject.GetPtr(this)));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind99 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLineLengthGuidelines, 381264803ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetLineLengthGuidelines(Godot.Collections.Array<int> guidelineColumns)
    {
        NativeCalls.godot_icall_1_138(MethodBind99, GodotObject.GetPtr(this), (godot_array)(guidelineColumns ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind100 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLineLengthGuidelines, 3995934104ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Godot.Collections.Array<int> GetLineLengthGuidelines()
    {
        return new Godot.Collections.Array<int>(NativeCalls.godot_icall_0_120(MethodBind100, GodotObject.GetPtr(this)));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind101 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSymbolLookupOnClickEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSymbolLookupOnClickEnabled(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind101, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind102 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsSymbolLookupOnClickEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsSymbolLookupOnClickEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind102, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind103 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTextForSymbolLookup, 201670096ul);

    /// <summary>
    /// <para>Returns the full text with char <c>0xFFFF</c> at the cursor location.</para>
    /// </summary>
    public string GetTextForSymbolLookup()
    {
        return NativeCalls.godot_icall_0_58(MethodBind103, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind104 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTextWithCursorChar, 1391810591ul);

    /// <summary>
    /// <para>Returns the full text with char <c>0xFFFF</c> at the specified location.</para>
    /// </summary>
    public string GetTextWithCursorChar(int line, int column)
    {
        return NativeCalls.godot_icall_2_222(MethodBind104, GodotObject.GetPtr(this), line, column);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind105 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSymbolLookupWordAsValid, 2586408642ul);

    /// <summary>
    /// <para>Sets the symbol emitted by <see cref="Godot.CodeEdit.SymbolValidate"/> as a valid lookup.</para>
    /// </summary>
    public void SetSymbolLookupWordAsValid(bool valid)
    {
        NativeCalls.godot_icall_1_14(MethodBind105, GodotObject.GetPtr(this), valid.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind106 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSymbolTooltipOnHoverEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSymbolTooltipOnHoverEnabled(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind106, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind107 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsSymbolTooltipOnHoverEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsSymbolTooltipOnHoverEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind107, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind108 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MoveLinesUp, 3218959716ul);

    /// <summary>
    /// <para>Moves all lines up that are selected or have a caret on them.</para>
    /// </summary>
    public void MoveLinesUp()
    {
        NativeCalls.godot_icall_0_3(MethodBind108, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind109 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MoveLinesDown, 3218959716ul);

    /// <summary>
    /// <para>Moves all lines down that are selected or have a caret on them.</para>
    /// </summary>
    public void MoveLinesDown()
    {
        NativeCalls.godot_icall_0_3(MethodBind109, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind110 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DeleteLines, 3218959716ul);

    /// <summary>
    /// <para>Deletes all lines that are selected or have a caret on them.</para>
    /// </summary>
    public void DeleteLines()
    {
        NativeCalls.godot_icall_0_3(MethodBind110, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind111 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DuplicateSelection, 3218959716ul);

    /// <summary>
    /// <para>Duplicates all selected text and duplicates all lines with a caret on them.</para>
    /// </summary>
    public void DuplicateSelection()
    {
        NativeCalls.godot_icall_0_3(MethodBind111, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind112 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DuplicateLines, 3218959716ul);

    /// <summary>
    /// <para>Duplicates all lines currently selected with any caret. Duplicates the entire line beneath the current one no matter where the caret is within the line.</para>
    /// </summary>
    public void DuplicateLines()
    {
        NativeCalls.godot_icall_0_3(MethodBind112, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind113 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddCodeCompletionOption, 947964390ul);

    /// <summary>
    /// <para>Submits an item to the queue of potential candidates for the autocomplete menu. Call <see cref="Godot.CodeEdit.UpdateCodeCompletionOptions(bool)"/> to update the list.</para>
    /// <para><paramref name="location"/> indicates location of the option relative to the location of the code completion query. See <see cref="Godot.CodeEdit.CodeCompletionLocation"/> for how to set this value.</para>
    /// <para><b>Note:</b> This list will replace all current candidates.</para>
    /// </summary>
    /// <param name="textColor">If the parameter is null, then the default value is <c>new Color(1.0f, 1.0f, 1.0f, 1.0f)</c>.</param>
    /// <param name="value">If the parameter is null, then the default value is <c>(Variant)(0)</c>.</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void AddCodeCompletionOption(CodeEdit.CodeCompletionKind type, string displayText, string insertText, Nullable<Color> textColor, Resource icon, Nullable<Variant> value, int location)
    {
        Color textColorOrDefVal = textColor.HasValue ? textColor.Value : new Color(1.0f, 1.0f, 1.0f, 1.0f);
        Variant valueOrDefVal = value.HasValue ? value.Value : (Variant)(0);
        NativeCalls.godot_icall_7_306(MethodBind113, GodotObject.GetPtr(this), (int)type, displayText, insertText, &textColorOrDefVal, GodotObject.GetPtr(icon), valueOrDefVal, location);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.CodeEdit.BreakpointToggled"/> event of a <see cref="Godot.CodeEdit"/> class.
    /// </summary>
    public delegate void BreakpointToggledEventHandler(long line);

    private static void BreakpointToggledTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((BreakpointToggledEventHandler)delegateObj)(VariantUtils.ConvertTo<long>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when a breakpoint is added or removed from a line. If the line is removed via backspace, a signal is emitted at the old line.</para>
    /// </summary>
    public unsafe event BreakpointToggledEventHandler BreakpointToggled
    {
        add => Connect(SignalName.BreakpointToggled, Callable.CreateWithUnsafeTrampoline(value, &BreakpointToggledTrampoline));
        remove => Disconnect(SignalName.BreakpointToggled, Callable.CreateWithUnsafeTrampoline(value, &BreakpointToggledTrampoline));
    }

    protected void EmitSignalBreakpointToggled(long line)
    {
        EmitSignal(SignalName.BreakpointToggled, line);
    }

    /// <summary>
    /// <para>Emitted when the user requests code completion. This signal will not be sent if <see cref="Godot.CodeEdit._RequestCodeCompletion(bool)"/> is overridden or <see cref="Godot.CodeEdit.CodeCompletionEnabled"/> is <see langword="false"/>.</para>
    /// </summary>
    public event Action CodeCompletionRequested
    {
        add => Connect(SignalName.CodeCompletionRequested, Callable.From(value));
        remove => Disconnect(SignalName.CodeCompletionRequested, Callable.From(value));
    }

    protected void EmitSignalCodeCompletionRequested()
    {
        EmitSignal(SignalName.CodeCompletionRequested);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.CodeEdit.SymbolLookup"/> event of a <see cref="Godot.CodeEdit"/> class.
    /// </summary>
    public delegate void SymbolLookupEventHandler(string symbol, long line, long column);

    private static void SymbolLookupTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 3);
        ((SymbolLookupEventHandler)delegateObj)(VariantUtils.ConvertTo<string>(args[0]), VariantUtils.ConvertTo<long>(args[1]), VariantUtils.ConvertTo<long>(args[2]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when the user has clicked on a valid symbol.</para>
    /// </summary>
    public unsafe event SymbolLookupEventHandler SymbolLookup
    {
        add => Connect(SignalName.SymbolLookup, Callable.CreateWithUnsafeTrampoline(value, &SymbolLookupTrampoline));
        remove => Disconnect(SignalName.SymbolLookup, Callable.CreateWithUnsafeTrampoline(value, &SymbolLookupTrampoline));
    }

    protected void EmitSignalSymbolLookup(string symbol, long line, long column)
    {
        EmitSignal(SignalName.SymbolLookup, symbol, line, column);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.CodeEdit.SymbolValidate"/> event of a <see cref="Godot.CodeEdit"/> class.
    /// </summary>
    public delegate void SymbolValidateEventHandler(string symbol);

    private static void SymbolValidateTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((SymbolValidateEventHandler)delegateObj)(VariantUtils.ConvertTo<string>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when the user hovers over a symbol. The symbol should be validated and responded to, by calling <see cref="Godot.CodeEdit.SetSymbolLookupWordAsValid(bool)"/>.</para>
    /// <para><b>Note:</b> <see cref="Godot.CodeEdit.SymbolLookupOnClick"/> must be <see langword="true"/> for this signal to be emitted.</para>
    /// </summary>
    public unsafe event SymbolValidateEventHandler SymbolValidate
    {
        add => Connect(SignalName.SymbolValidate, Callable.CreateWithUnsafeTrampoline(value, &SymbolValidateTrampoline));
        remove => Disconnect(SignalName.SymbolValidate, Callable.CreateWithUnsafeTrampoline(value, &SymbolValidateTrampoline));
    }

    protected void EmitSignalSymbolValidate(string symbol)
    {
        EmitSignal(SignalName.SymbolValidate, symbol);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.CodeEdit.SymbolHovered"/> event of a <see cref="Godot.CodeEdit"/> class.
    /// </summary>
    public delegate void SymbolHoveredEventHandler(string symbol, long line, long column);

    private static void SymbolHoveredTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 3);
        ((SymbolHoveredEventHandler)delegateObj)(VariantUtils.ConvertTo<string>(args[0]), VariantUtils.ConvertTo<long>(args[1]), VariantUtils.ConvertTo<long>(args[2]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when the user hovers over a symbol. Unlike <see cref="Godot.Control.MouseEntered"/>, this signal is not emitted immediately, but when the cursor is over the symbol for <c>ProjectSettings.gui/timers/tooltip_delay_sec</c> seconds.</para>
    /// <para><b>Note:</b> <see cref="Godot.CodeEdit.SymbolTooltipOnHover"/> must be <see langword="true"/> for this signal to be emitted.</para>
    /// </summary>
    public unsafe event SymbolHoveredEventHandler SymbolHovered
    {
        add => Connect(SignalName.SymbolHovered, Callable.CreateWithUnsafeTrampoline(value, &SymbolHoveredTrampoline));
        remove => Disconnect(SignalName.SymbolHovered, Callable.CreateWithUnsafeTrampoline(value, &SymbolHoveredTrampoline));
    }

    protected void EmitSignalSymbolHovered(string symbol, long line, long column)
    {
        EmitSignal(SignalName.SymbolHovered, symbol, line, column);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__confirm_code_completion = "_ConfirmCodeCompletion";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__filter_code_completion_candidates = "_FilterCodeCompletionCandidates";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__request_code_completion = "_RequestCodeCompletion";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_breakpoint_toggled = "BreakpointToggled";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_code_completion_requested = "CodeCompletionRequested";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_symbol_lookup = "SymbolLookup";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_symbol_validate = "SymbolValidate";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_symbol_hovered = "SymbolHovered";

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
        if ((method == MethodProxyName__confirm_code_completion || method == MethodName._ConfirmCodeCompletion) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__confirm_code_completion.NativeValue))
        {
            _ConfirmCodeCompletion(VariantUtils.ConvertTo<bool>(args[0]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__filter_code_completion_candidates || method == MethodName._FilterCodeCompletionCandidates) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__filter_code_completion_candidates.NativeValue))
        {
            var callRet = _FilterCodeCompletionCandidates(new Godot.Collections.Array<Godot.Collections.Dictionary>(VariantUtils.ConvertToArray(args[0])));
            ret = VariantUtils.CreateFromArray(callRet);
            return true;
        }
        if ((method == MethodProxyName__request_code_completion || method == MethodName._RequestCodeCompletion) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__request_code_completion.NativeValue))
        {
            _RequestCodeCompletion(VariantUtils.ConvertTo<bool>(args[0]));
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
        if (method == MethodName._ConfirmCodeCompletion)
        {
            if (HasGodotClassMethod(MethodProxyName__confirm_code_completion.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FilterCodeCompletionCandidates)
        {
            if (HasGodotClassMethod(MethodProxyName__filter_code_completion_candidates.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._RequestCodeCompletion)
        {
            if (HasGodotClassMethod(MethodProxyName__request_code_completion.NativeValue.DangerousSelfRef))
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
        if (signal == SignalName.BreakpointToggled)
        {
            if (HasGodotClassSignal(SignalProxyName_breakpoint_toggled.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.CodeCompletionRequested)
        {
            if (HasGodotClassSignal(SignalProxyName_code_completion_requested.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.SymbolLookup)
        {
            if (HasGodotClassSignal(SignalProxyName_symbol_lookup.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.SymbolValidate)
        {
            if (HasGodotClassSignal(SignalProxyName_symbol_validate.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.SymbolHovered)
        {
            if (HasGodotClassSignal(SignalProxyName_symbol_hovered.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        return base.HasGodotClassSignal(signal);
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : TextEdit.PropertyName
    {
        /// <summary>
        /// Cached name for the 'symbol_lookup_on_click' property.
        /// </summary>
        public static readonly StringName SymbolLookupOnClick = "symbol_lookup_on_click";
        /// <summary>
        /// Cached name for the 'symbol_tooltip_on_hover' property.
        /// </summary>
        public static readonly StringName SymbolTooltipOnHover = "symbol_tooltip_on_hover";
        /// <summary>
        /// Cached name for the 'line_folding' property.
        /// </summary>
        public static readonly StringName LineFolding = "line_folding";
        /// <summary>
        /// Cached name for the 'line_length_guidelines' property.
        /// </summary>
        public static readonly StringName LineLengthGuidelines = "line_length_guidelines";
        /// <summary>
        /// Cached name for the 'gutters_draw_breakpoints_gutter' property.
        /// </summary>
        public static readonly StringName GuttersDrawBreakpointsGutter = "gutters_draw_breakpoints_gutter";
        /// <summary>
        /// Cached name for the 'gutters_draw_bookmarks' property.
        /// </summary>
        public static readonly StringName GuttersDrawBookmarks = "gutters_draw_bookmarks";
        /// <summary>
        /// Cached name for the 'gutters_draw_executing_lines' property.
        /// </summary>
        public static readonly StringName GuttersDrawExecutingLines = "gutters_draw_executing_lines";
        /// <summary>
        /// Cached name for the 'gutters_draw_line_numbers' property.
        /// </summary>
        public static readonly StringName GuttersDrawLineNumbers = "gutters_draw_line_numbers";
        /// <summary>
        /// Cached name for the 'gutters_zero_pad_line_numbers' property.
        /// </summary>
        public static readonly StringName GuttersZeroPadLineNumbers = "gutters_zero_pad_line_numbers";
        /// <summary>
        /// Cached name for the 'gutters_line_numbers_min_digits' property.
        /// </summary>
        public static readonly StringName GuttersLineNumbersMinDigits = "gutters_line_numbers_min_digits";
        /// <summary>
        /// Cached name for the 'gutters_draw_fold_gutter' property.
        /// </summary>
        public static readonly StringName GuttersDrawFoldGutter = "gutters_draw_fold_gutter";
        /// <summary>
        /// Cached name for the 'delimiter_strings' property.
        /// </summary>
        public static readonly StringName DelimiterStrings = "delimiter_strings";
        /// <summary>
        /// Cached name for the 'delimiter_comments' property.
        /// </summary>
        public static readonly StringName DelimiterComments = "delimiter_comments";
        /// <summary>
        /// Cached name for the 'code_completion_enabled' property.
        /// </summary>
        public static readonly StringName CodeCompletionEnabled = "code_completion_enabled";
        /// <summary>
        /// Cached name for the 'code_completion_prefixes' property.
        /// </summary>
        public static readonly StringName CodeCompletionPrefixes = "code_completion_prefixes";
        /// <summary>
        /// Cached name for the 'indent_size' property.
        /// </summary>
        public static readonly StringName IndentSize = "indent_size";
        /// <summary>
        /// Cached name for the 'indent_use_spaces' property.
        /// </summary>
        public static readonly StringName IndentUseSpaces = "indent_use_spaces";
        /// <summary>
        /// Cached name for the 'indent_automatic' property.
        /// </summary>
        public static readonly StringName IndentAutomatic = "indent_automatic";
        /// <summary>
        /// Cached name for the 'indent_automatic_prefixes' property.
        /// </summary>
        public static readonly StringName IndentAutomaticPrefixes = "indent_automatic_prefixes";
        /// <summary>
        /// Cached name for the 'auto_brace_completion_enabled' property.
        /// </summary>
        public static readonly StringName AutoBraceCompletionEnabled = "auto_brace_completion_enabled";
        /// <summary>
        /// Cached name for the 'auto_brace_completion_highlight_matching' property.
        /// </summary>
        public static readonly StringName AutoBraceCompletionHighlightMatching = "auto_brace_completion_highlight_matching";
        /// <summary>
        /// Cached name for the 'auto_brace_completion_pairs' property.
        /// </summary>
        public static readonly StringName AutoBraceCompletionPairs = "auto_brace_completion_pairs";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : TextEdit.MethodName
    {
        /// <summary>
        /// Cached name for the '_confirm_code_completion' method.
        /// </summary>
        public static readonly StringName _ConfirmCodeCompletion = "_confirm_code_completion";
        /// <summary>
        /// Cached name for the '_filter_code_completion_candidates' method.
        /// </summary>
        public static readonly StringName _FilterCodeCompletionCandidates = "_filter_code_completion_candidates";
        /// <summary>
        /// Cached name for the '_request_code_completion' method.
        /// </summary>
        public static readonly StringName _RequestCodeCompletion = "_request_code_completion";
        /// <summary>
        /// Cached name for the 'set_indent_size' method.
        /// </summary>
        public static readonly StringName SetIndentSize = "set_indent_size";
        /// <summary>
        /// Cached name for the 'get_indent_size' method.
        /// </summary>
        public static readonly StringName GetIndentSize = "get_indent_size";
        /// <summary>
        /// Cached name for the 'set_indent_using_spaces' method.
        /// </summary>
        public static readonly StringName SetIndentUsingSpaces = "set_indent_using_spaces";
        /// <summary>
        /// Cached name for the 'is_indent_using_spaces' method.
        /// </summary>
        public static readonly StringName IsIndentUsingSpaces = "is_indent_using_spaces";
        /// <summary>
        /// Cached name for the 'set_auto_indent_enabled' method.
        /// </summary>
        public static readonly StringName SetAutoIndentEnabled = "set_auto_indent_enabled";
        /// <summary>
        /// Cached name for the 'is_auto_indent_enabled' method.
        /// </summary>
        public static readonly StringName IsAutoIndentEnabled = "is_auto_indent_enabled";
        /// <summary>
        /// Cached name for the 'set_auto_indent_prefixes' method.
        /// </summary>
        public static readonly StringName SetAutoIndentPrefixes = "set_auto_indent_prefixes";
        /// <summary>
        /// Cached name for the 'get_auto_indent_prefixes' method.
        /// </summary>
        public static readonly StringName GetAutoIndentPrefixes = "get_auto_indent_prefixes";
        /// <summary>
        /// Cached name for the 'do_indent' method.
        /// </summary>
        public static readonly StringName DoIndent = "do_indent";
        /// <summary>
        /// Cached name for the 'indent_lines' method.
        /// </summary>
        public static readonly StringName IndentLines = "indent_lines";
        /// <summary>
        /// Cached name for the 'unindent_lines' method.
        /// </summary>
        public static readonly StringName UnindentLines = "unindent_lines";
        /// <summary>
        /// Cached name for the 'convert_indent' method.
        /// </summary>
        public static readonly StringName ConvertIndent = "convert_indent";
        /// <summary>
        /// Cached name for the 'set_auto_brace_completion_enabled' method.
        /// </summary>
        public static readonly StringName SetAutoBraceCompletionEnabled = "set_auto_brace_completion_enabled";
        /// <summary>
        /// Cached name for the 'is_auto_brace_completion_enabled' method.
        /// </summary>
        public static readonly StringName IsAutoBraceCompletionEnabled = "is_auto_brace_completion_enabled";
        /// <summary>
        /// Cached name for the 'set_highlight_matching_braces_enabled' method.
        /// </summary>
        public static readonly StringName SetHighlightMatchingBracesEnabled = "set_highlight_matching_braces_enabled";
        /// <summary>
        /// Cached name for the 'is_highlight_matching_braces_enabled' method.
        /// </summary>
        public static readonly StringName IsHighlightMatchingBracesEnabled = "is_highlight_matching_braces_enabled";
        /// <summary>
        /// Cached name for the 'add_auto_brace_completion_pair' method.
        /// </summary>
        public static readonly StringName AddAutoBraceCompletionPair = "add_auto_brace_completion_pair";
        /// <summary>
        /// Cached name for the 'set_auto_brace_completion_pairs' method.
        /// </summary>
        public static readonly StringName SetAutoBraceCompletionPairs = "set_auto_brace_completion_pairs";
        /// <summary>
        /// Cached name for the 'get_auto_brace_completion_pairs' method.
        /// </summary>
        public static readonly StringName GetAutoBraceCompletionPairs = "get_auto_brace_completion_pairs";
        /// <summary>
        /// Cached name for the 'has_auto_brace_completion_open_key' method.
        /// </summary>
        public static readonly StringName HasAutoBraceCompletionOpenKey = "has_auto_brace_completion_open_key";
        /// <summary>
        /// Cached name for the 'has_auto_brace_completion_close_key' method.
        /// </summary>
        public static readonly StringName HasAutoBraceCompletionCloseKey = "has_auto_brace_completion_close_key";
        /// <summary>
        /// Cached name for the 'get_auto_brace_completion_close_key' method.
        /// </summary>
        public static readonly StringName GetAutoBraceCompletionCloseKey = "get_auto_brace_completion_close_key";
        /// <summary>
        /// Cached name for the 'set_draw_breakpoints_gutter' method.
        /// </summary>
        public static readonly StringName SetDrawBreakpointsGutter = "set_draw_breakpoints_gutter";
        /// <summary>
        /// Cached name for the 'is_drawing_breakpoints_gutter' method.
        /// </summary>
        public static readonly StringName IsDrawingBreakpointsGutter = "is_drawing_breakpoints_gutter";
        /// <summary>
        /// Cached name for the 'set_draw_bookmarks_gutter' method.
        /// </summary>
        public static readonly StringName SetDrawBookmarksGutter = "set_draw_bookmarks_gutter";
        /// <summary>
        /// Cached name for the 'is_drawing_bookmarks_gutter' method.
        /// </summary>
        public static readonly StringName IsDrawingBookmarksGutter = "is_drawing_bookmarks_gutter";
        /// <summary>
        /// Cached name for the 'set_draw_executing_lines_gutter' method.
        /// </summary>
        public static readonly StringName SetDrawExecutingLinesGutter = "set_draw_executing_lines_gutter";
        /// <summary>
        /// Cached name for the 'is_drawing_executing_lines_gutter' method.
        /// </summary>
        public static readonly StringName IsDrawingExecutingLinesGutter = "is_drawing_executing_lines_gutter";
        /// <summary>
        /// Cached name for the 'set_line_as_breakpoint' method.
        /// </summary>
        public static readonly StringName SetLineAsBreakpoint = "set_line_as_breakpoint";
        /// <summary>
        /// Cached name for the 'is_line_breakpointed' method.
        /// </summary>
        public static readonly StringName IsLineBreakpointed = "is_line_breakpointed";
        /// <summary>
        /// Cached name for the 'clear_breakpointed_lines' method.
        /// </summary>
        public static readonly StringName ClearBreakpointedLines = "clear_breakpointed_lines";
        /// <summary>
        /// Cached name for the 'get_breakpointed_lines' method.
        /// </summary>
        public static readonly StringName GetBreakpointedLines = "get_breakpointed_lines";
        /// <summary>
        /// Cached name for the 'set_line_as_bookmarked' method.
        /// </summary>
        public static readonly StringName SetLineAsBookmarked = "set_line_as_bookmarked";
        /// <summary>
        /// Cached name for the 'is_line_bookmarked' method.
        /// </summary>
        public static readonly StringName IsLineBookmarked = "is_line_bookmarked";
        /// <summary>
        /// Cached name for the 'clear_bookmarked_lines' method.
        /// </summary>
        public static readonly StringName ClearBookmarkedLines = "clear_bookmarked_lines";
        /// <summary>
        /// Cached name for the 'get_bookmarked_lines' method.
        /// </summary>
        public static readonly StringName GetBookmarkedLines = "get_bookmarked_lines";
        /// <summary>
        /// Cached name for the 'set_line_as_executing' method.
        /// </summary>
        public static readonly StringName SetLineAsExecuting = "set_line_as_executing";
        /// <summary>
        /// Cached name for the 'is_line_executing' method.
        /// </summary>
        public static readonly StringName IsLineExecuting = "is_line_executing";
        /// <summary>
        /// Cached name for the 'clear_executing_lines' method.
        /// </summary>
        public static readonly StringName ClearExecutingLines = "clear_executing_lines";
        /// <summary>
        /// Cached name for the 'get_executing_lines' method.
        /// </summary>
        public static readonly StringName GetExecutingLines = "get_executing_lines";
        /// <summary>
        /// Cached name for the 'set_draw_line_numbers' method.
        /// </summary>
        public static readonly StringName SetDrawLineNumbers = "set_draw_line_numbers";
        /// <summary>
        /// Cached name for the 'is_draw_line_numbers_enabled' method.
        /// </summary>
        public static readonly StringName IsDrawLineNumbersEnabled = "is_draw_line_numbers_enabled";
        /// <summary>
        /// Cached name for the 'set_line_numbers_zero_padded' method.
        /// </summary>
        public static readonly StringName SetLineNumbersZeroPadded = "set_line_numbers_zero_padded";
        /// <summary>
        /// Cached name for the 'is_line_numbers_zero_padded' method.
        /// </summary>
        public static readonly StringName IsLineNumbersZeroPadded = "is_line_numbers_zero_padded";
        /// <summary>
        /// Cached name for the 'set_line_numbers_min_digits' method.
        /// </summary>
        public static readonly StringName SetLineNumbersMinDigits = "set_line_numbers_min_digits";
        /// <summary>
        /// Cached name for the 'get_line_numbers_min_digits' method.
        /// </summary>
        public static readonly StringName GetLineNumbersMinDigits = "get_line_numbers_min_digits";
        /// <summary>
        /// Cached name for the 'set_draw_fold_gutter' method.
        /// </summary>
        public static readonly StringName SetDrawFoldGutter = "set_draw_fold_gutter";
        /// <summary>
        /// Cached name for the 'is_drawing_fold_gutter' method.
        /// </summary>
        public static readonly StringName IsDrawingFoldGutter = "is_drawing_fold_gutter";
        /// <summary>
        /// Cached name for the 'set_line_folding_enabled' method.
        /// </summary>
        public static readonly StringName SetLineFoldingEnabled = "set_line_folding_enabled";
        /// <summary>
        /// Cached name for the 'is_line_folding_enabled' method.
        /// </summary>
        public static readonly StringName IsLineFoldingEnabled = "is_line_folding_enabled";
        /// <summary>
        /// Cached name for the 'can_fold_line' method.
        /// </summary>
        public static readonly StringName CanFoldLine = "can_fold_line";
        /// <summary>
        /// Cached name for the 'fold_line' method.
        /// </summary>
        public static readonly StringName FoldLine = "fold_line";
        /// <summary>
        /// Cached name for the 'unfold_line' method.
        /// </summary>
        public static readonly StringName UnfoldLine = "unfold_line";
        /// <summary>
        /// Cached name for the 'fold_all_lines' method.
        /// </summary>
        public static readonly StringName FoldAllLines = "fold_all_lines";
        /// <summary>
        /// Cached name for the 'unfold_all_lines' method.
        /// </summary>
        public static readonly StringName UnfoldAllLines = "unfold_all_lines";
        /// <summary>
        /// Cached name for the 'toggle_foldable_line' method.
        /// </summary>
        public static readonly StringName ToggleFoldableLine = "toggle_foldable_line";
        /// <summary>
        /// Cached name for the 'toggle_foldable_lines_at_carets' method.
        /// </summary>
        public static readonly StringName ToggleFoldableLinesAtCarets = "toggle_foldable_lines_at_carets";
        /// <summary>
        /// Cached name for the 'is_line_folded' method.
        /// </summary>
        public static readonly StringName IsLineFolded = "is_line_folded";
        /// <summary>
        /// Cached name for the 'get_folded_lines' method.
        /// </summary>
        public static readonly StringName GetFoldedLines = "get_folded_lines";
        /// <summary>
        /// Cached name for the 'create_code_region' method.
        /// </summary>
        public static readonly StringName CreateCodeRegion = "create_code_region";
        /// <summary>
        /// Cached name for the 'get_code_region_start_tag' method.
        /// </summary>
        public static readonly StringName GetCodeRegionStartTag = "get_code_region_start_tag";
        /// <summary>
        /// Cached name for the 'get_code_region_end_tag' method.
        /// </summary>
        public static readonly StringName GetCodeRegionEndTag = "get_code_region_end_tag";
        /// <summary>
        /// Cached name for the 'set_code_region_tags' method.
        /// </summary>
        public static readonly StringName SetCodeRegionTags = "set_code_region_tags";
        /// <summary>
        /// Cached name for the 'is_line_code_region_start' method.
        /// </summary>
        public static readonly StringName IsLineCodeRegionStart = "is_line_code_region_start";
        /// <summary>
        /// Cached name for the 'is_line_code_region_end' method.
        /// </summary>
        public static readonly StringName IsLineCodeRegionEnd = "is_line_code_region_end";
        /// <summary>
        /// Cached name for the 'add_string_delimiter' method.
        /// </summary>
        public static readonly StringName AddStringDelimiter = "add_string_delimiter";
        /// <summary>
        /// Cached name for the 'remove_string_delimiter' method.
        /// </summary>
        public static readonly StringName RemoveStringDelimiter = "remove_string_delimiter";
        /// <summary>
        /// Cached name for the 'has_string_delimiter' method.
        /// </summary>
        public static readonly StringName HasStringDelimiter = "has_string_delimiter";
        /// <summary>
        /// Cached name for the 'set_string_delimiters' method.
        /// </summary>
        public static readonly StringName SetStringDelimiters = "set_string_delimiters";
        /// <summary>
        /// Cached name for the 'clear_string_delimiters' method.
        /// </summary>
        public static readonly StringName ClearStringDelimiters = "clear_string_delimiters";
        /// <summary>
        /// Cached name for the 'get_string_delimiters' method.
        /// </summary>
        public static readonly StringName GetStringDelimiters = "get_string_delimiters";
        /// <summary>
        /// Cached name for the 'is_in_string' method.
        /// </summary>
        public static readonly StringName IsInString = "is_in_string";
        /// <summary>
        /// Cached name for the 'add_comment_delimiter' method.
        /// </summary>
        public static readonly StringName AddCommentDelimiter = "add_comment_delimiter";
        /// <summary>
        /// Cached name for the 'remove_comment_delimiter' method.
        /// </summary>
        public static readonly StringName RemoveCommentDelimiter = "remove_comment_delimiter";
        /// <summary>
        /// Cached name for the 'has_comment_delimiter' method.
        /// </summary>
        public static readonly StringName HasCommentDelimiter = "has_comment_delimiter";
        /// <summary>
        /// Cached name for the 'set_comment_delimiters' method.
        /// </summary>
        public static readonly StringName SetCommentDelimiters = "set_comment_delimiters";
        /// <summary>
        /// Cached name for the 'clear_comment_delimiters' method.
        /// </summary>
        public static readonly StringName ClearCommentDelimiters = "clear_comment_delimiters";
        /// <summary>
        /// Cached name for the 'get_comment_delimiters' method.
        /// </summary>
        public static readonly StringName GetCommentDelimiters = "get_comment_delimiters";
        /// <summary>
        /// Cached name for the 'is_in_comment' method.
        /// </summary>
        public static readonly StringName IsInComment = "is_in_comment";
        /// <summary>
        /// Cached name for the 'get_delimiter_start_key' method.
        /// </summary>
        public static readonly StringName GetDelimiterStartKey = "get_delimiter_start_key";
        /// <summary>
        /// Cached name for the 'get_delimiter_end_key' method.
        /// </summary>
        public static readonly StringName GetDelimiterEndKey = "get_delimiter_end_key";
        /// <summary>
        /// Cached name for the 'get_delimiter_start_position' method.
        /// </summary>
        public static readonly StringName GetDelimiterStartPosition = "get_delimiter_start_position";
        /// <summary>
        /// Cached name for the 'get_delimiter_end_position' method.
        /// </summary>
        public static readonly StringName GetDelimiterEndPosition = "get_delimiter_end_position";
        /// <summary>
        /// Cached name for the 'set_code_hint' method.
        /// </summary>
        public static readonly StringName SetCodeHint = "set_code_hint";
        /// <summary>
        /// Cached name for the 'set_code_hint_draw_below' method.
        /// </summary>
        public static readonly StringName SetCodeHintDrawBelow = "set_code_hint_draw_below";
        /// <summary>
        /// Cached name for the 'get_text_for_code_completion' method.
        /// </summary>
        public static readonly StringName GetTextForCodeCompletion = "get_text_for_code_completion";
        /// <summary>
        /// Cached name for the 'request_code_completion' method.
        /// </summary>
        public static readonly StringName RequestCodeCompletion = "request_code_completion";
        /// <summary>
        /// Cached name for the 'add_code_completion_option' method.
        /// </summary>
        public static readonly StringName AddCodeCompletionOption = "add_code_completion_option";
        /// <summary>
        /// Cached name for the 'update_code_completion_options' method.
        /// </summary>
        public static readonly StringName UpdateCodeCompletionOptions = "update_code_completion_options";
        /// <summary>
        /// Cached name for the 'get_code_completion_options' method.
        /// </summary>
        public static readonly StringName GetCodeCompletionOptions = "get_code_completion_options";
        /// <summary>
        /// Cached name for the 'get_code_completion_option' method.
        /// </summary>
        public static readonly StringName GetCodeCompletionOption = "get_code_completion_option";
        /// <summary>
        /// Cached name for the 'get_code_completion_selected_index' method.
        /// </summary>
        public static readonly StringName GetCodeCompletionSelectedIndex = "get_code_completion_selected_index";
        /// <summary>
        /// Cached name for the 'set_code_completion_selected_index' method.
        /// </summary>
        public static readonly StringName SetCodeCompletionSelectedIndex = "set_code_completion_selected_index";
        /// <summary>
        /// Cached name for the 'confirm_code_completion' method.
        /// </summary>
        public static readonly StringName ConfirmCodeCompletion = "confirm_code_completion";
        /// <summary>
        /// Cached name for the 'cancel_code_completion' method.
        /// </summary>
        public static readonly StringName CancelCodeCompletion = "cancel_code_completion";
        /// <summary>
        /// Cached name for the 'set_code_completion_enabled' method.
        /// </summary>
        public static readonly StringName SetCodeCompletionEnabled = "set_code_completion_enabled";
        /// <summary>
        /// Cached name for the 'is_code_completion_enabled' method.
        /// </summary>
        public static readonly StringName IsCodeCompletionEnabled = "is_code_completion_enabled";
        /// <summary>
        /// Cached name for the 'set_code_completion_prefixes' method.
        /// </summary>
        public static readonly StringName SetCodeCompletionPrefixes = "set_code_completion_prefixes";
        /// <summary>
        /// Cached name for the 'get_code_completion_prefixes' method.
        /// </summary>
        public static readonly StringName GetCodeCompletionPrefixes = "get_code_completion_prefixes";
        /// <summary>
        /// Cached name for the 'set_line_length_guidelines' method.
        /// </summary>
        public static readonly StringName SetLineLengthGuidelines = "set_line_length_guidelines";
        /// <summary>
        /// Cached name for the 'get_line_length_guidelines' method.
        /// </summary>
        public static readonly StringName GetLineLengthGuidelines = "get_line_length_guidelines";
        /// <summary>
        /// Cached name for the 'set_symbol_lookup_on_click_enabled' method.
        /// </summary>
        public static readonly StringName SetSymbolLookupOnClickEnabled = "set_symbol_lookup_on_click_enabled";
        /// <summary>
        /// Cached name for the 'is_symbol_lookup_on_click_enabled' method.
        /// </summary>
        public static readonly StringName IsSymbolLookupOnClickEnabled = "is_symbol_lookup_on_click_enabled";
        /// <summary>
        /// Cached name for the 'get_text_for_symbol_lookup' method.
        /// </summary>
        public static readonly StringName GetTextForSymbolLookup = "get_text_for_symbol_lookup";
        /// <summary>
        /// Cached name for the 'get_text_with_cursor_char' method.
        /// </summary>
        public static readonly StringName GetTextWithCursorChar = "get_text_with_cursor_char";
        /// <summary>
        /// Cached name for the 'set_symbol_lookup_word_as_valid' method.
        /// </summary>
        public static readonly StringName SetSymbolLookupWordAsValid = "set_symbol_lookup_word_as_valid";
        /// <summary>
        /// Cached name for the 'set_symbol_tooltip_on_hover_enabled' method.
        /// </summary>
        public static readonly StringName SetSymbolTooltipOnHoverEnabled = "set_symbol_tooltip_on_hover_enabled";
        /// <summary>
        /// Cached name for the 'is_symbol_tooltip_on_hover_enabled' method.
        /// </summary>
        public static readonly StringName IsSymbolTooltipOnHoverEnabled = "is_symbol_tooltip_on_hover_enabled";
        /// <summary>
        /// Cached name for the 'move_lines_up' method.
        /// </summary>
        public static readonly StringName MoveLinesUp = "move_lines_up";
        /// <summary>
        /// Cached name for the 'move_lines_down' method.
        /// </summary>
        public static readonly StringName MoveLinesDown = "move_lines_down";
        /// <summary>
        /// Cached name for the 'delete_lines' method.
        /// </summary>
        public static readonly StringName DeleteLines = "delete_lines";
        /// <summary>
        /// Cached name for the 'duplicate_selection' method.
        /// </summary>
        public static readonly StringName DuplicateSelection = "duplicate_selection";
        /// <summary>
        /// Cached name for the 'duplicate_lines' method.
        /// </summary>
        public static readonly StringName DuplicateLines = "duplicate_lines";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : TextEdit.SignalName
    {
        /// <summary>
        /// Cached name for the 'breakpoint_toggled' signal.
        /// </summary>
        public static readonly StringName BreakpointToggled = "breakpoint_toggled";
        /// <summary>
        /// Cached name for the 'code_completion_requested' signal.
        /// </summary>
        public static readonly StringName CodeCompletionRequested = "code_completion_requested";
        /// <summary>
        /// Cached name for the 'symbol_lookup' signal.
        /// </summary>
        public static readonly StringName SymbolLookup = "symbol_lookup";
        /// <summary>
        /// Cached name for the 'symbol_validate' signal.
        /// </summary>
        public static readonly StringName SymbolValidate = "symbol_validate";
        /// <summary>
        /// Cached name for the 'symbol_hovered' signal.
        /// </summary>
        public static readonly StringName SymbolHovered = "symbol_hovered";
    }
}
