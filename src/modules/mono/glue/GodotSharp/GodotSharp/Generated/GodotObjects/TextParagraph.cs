namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Abstraction over <see cref="Godot.TextServer"/> for handling a single paragraph of text.</para>
/// </summary>
public partial class TextParagraph : RefCounted
{
    /// <summary>
    /// <para>Text writing direction.</para>
    /// </summary>
    public TextServer.Direction Direction
    {
        get
        {
            return GetDirection();
        }
        set
        {
            SetDirection(value);
        }
    }

    /// <summary>
    /// <para>Custom punctuation character list, used for word breaking. If set to empty string, server defaults are used.</para>
    /// </summary>
    public string CustomPunctuation
    {
        get
        {
            return GetCustomPunctuation();
        }
        set
        {
            SetCustomPunctuation(value);
        }
    }

    /// <summary>
    /// <para>Text orientation.</para>
    /// </summary>
    public TextServer.Orientation Orientation
    {
        get
        {
            return GetOrientation();
        }
        set
        {
            SetOrientation(value);
        }
    }

    /// <summary>
    /// <para>If set to <see langword="true"/> text will display invalid characters.</para>
    /// </summary>
    public bool PreserveInvalid
    {
        get
        {
            return GetPreserveInvalid();
        }
        set
        {
            SetPreserveInvalid(value);
        }
    }

    /// <summary>
    /// <para>If set to <see langword="true"/> text will display control characters.</para>
    /// </summary>
    public bool PreserveControl
    {
        get
        {
            return GetPreserveControl();
        }
        set
        {
            SetPreserveControl(value);
        }
    }

    /// <summary>
    /// <para>Paragraph horizontal alignment.</para>
    /// </summary>
    public HorizontalAlignment Alignment
    {
        get
        {
            return GetAlignment();
        }
        set
        {
            SetAlignment(value);
        }
    }

    /// <summary>
    /// <para>Line breaking rules. For more info see <see cref="Godot.TextServer"/>.</para>
    /// </summary>
    public TextServer.LineBreakFlag BreakFlags
    {
        get
        {
            return GetBreakFlags();
        }
        set
        {
            SetBreakFlags(value);
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
    /// <para>The clipping behavior when the text exceeds the paragraph's set width.</para>
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
    /// <para>Paragraph width.</para>
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
    /// <para>Limits the lines of text shown.</para>
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

    private static readonly System.Type CachedType = typeof(TextParagraph);

    private static readonly StringName NativeName = "TextParagraph";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public TextParagraph() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal TextParagraph(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal TextParagraph(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Clear, 3218959716ul);

    /// <summary>
    /// <para>Clears text paragraph (removes text and inline objects).</para>
    /// </summary>
    public void Clear()
    {
        NativeCalls.godot_icall_0_3(MethodBind0, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Duplicate, 3607706709ul);

    /// <summary>
    /// <para>Duplicates this <see cref="Godot.TextParagraph"/>.</para>
    /// </summary>
    public TextParagraph Duplicate()
    {
        return (TextParagraph)NativeCalls.godot_icall_0_63(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDirection, 1418190634ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDirection(TextServer.Direction direction)
    {
        NativeCalls.godot_icall_1_38(MethodBind2, GodotObject.GetPtr(this), (int)direction);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDirection, 2516697328ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public TextServer.Direction GetDirection()
    {
        return (TextServer.Direction)NativeCalls.godot_icall_0_39(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetInferredDirection, 2516697328ul);

    /// <summary>
    /// <para>Returns the text writing direction inferred by the BiDi algorithm.</para>
    /// </summary>
    public TextServer.Direction GetInferredDirection()
    {
        return (TextServer.Direction)NativeCalls.godot_icall_0_39(MethodBind4, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCustomPunctuation, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCustomPunctuation(string customPunctuation)
    {
        NativeCalls.godot_icall_1_57(MethodBind5, GodotObject.GetPtr(this), customPunctuation);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCustomPunctuation, 201670096ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetCustomPunctuation()
    {
        return NativeCalls.godot_icall_0_58(MethodBind6, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetOrientation, 42823726ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetOrientation(TextServer.Orientation orientation)
    {
        NativeCalls.godot_icall_1_38(MethodBind7, GodotObject.GetPtr(this), (int)orientation);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOrientation, 175768116ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public TextServer.Orientation GetOrientation()
    {
        return (TextServer.Orientation)NativeCalls.godot_icall_0_39(MethodBind8, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPreserveInvalid, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPreserveInvalid(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind9, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPreserveInvalid, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetPreserveInvalid()
    {
        return NativeCalls.godot_icall_0_15(MethodBind10, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPreserveControl, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPreserveControl(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind11, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPreserveControl, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetPreserveControl()
    {
        return NativeCalls.godot_icall_0_15(MethodBind12, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBidiOverride, 381264803ul);

    /// <summary>
    /// <para>Overrides BiDi for the structured text.</para>
    /// <para>Override ranges should cover full source text without overlaps. BiDi algorithm will be used on each range separately.</para>
    /// </summary>
    public void SetBidiOverride(Godot.Collections.Array @override)
    {
        NativeCalls.godot_icall_1_138(MethodBind13, GodotObject.GetPtr(this), (godot_array)(@override ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDropcap, 2498990330ul);

    /// <summary>
    /// <para>Sets drop cap, overrides previously set drop cap. Drop cap (dropped capital) is a decorative element at the beginning of a paragraph that is larger than the rest of the text.</para>
    /// </summary>
    /// <param name="dropcapMargins">If the parameter is null, then the default value is <c>new Rect2(new Vector2(0.0f, 0.0f), new Vector2(0.0f, 0.0f))</c>.</param>
    public unsafe bool SetDropcap(string text, Font font, int fontSize, Nullable<Rect2> dropcapMargins = null, string language = "")
    {
        Rect2 dropcapMarginsOrDefVal = dropcapMargins.HasValue ? dropcapMargins.Value : new Rect2(new Vector2(0.0f, 0.0f), new Vector2(0.0f, 0.0f));
        return NativeCalls.godot_icall_5_1325(MethodBind14, GodotObject.GetPtr(this), text, GodotObject.GetPtr(font), fontSize, &dropcapMarginsOrDefVal, language).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ClearDropcap, 3218959716ul);

    /// <summary>
    /// <para>Removes dropcap.</para>
    /// </summary>
    public void ClearDropcap()
    {
        NativeCalls.godot_icall_0_3(MethodBind15, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddString, 621426851ul);

    /// <summary>
    /// <para>Adds text span and font to draw it.</para>
    /// </summary>
    public bool AddString(string text, Font font, int fontSize, string language = "", Variant meta = default)
    {
        return NativeCalls.godot_icall_5_1315(MethodBind16, GodotObject.GetPtr(this), text, GodotObject.GetPtr(font), fontSize, language, meta).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddObject, 1316529304ul);

    /// <summary>
    /// <para>Adds inline object to the text buffer, <paramref name="key"/> must be unique. In the text, object is represented as <paramref name="length"/> object replacement characters.</para>
    /// </summary>
    public unsafe bool AddObject(Variant key, Vector2 size, InlineAlignment inlineAlign = (InlineAlignment)(5), int length = 1, float baseline = 0.0f)
    {
        return NativeCalls.godot_icall_5_1316(MethodBind17, GodotObject.GetPtr(this), key, &size, (int)inlineAlign, length, baseline).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ResizeObject, 2095776372ul);

    /// <summary>
    /// <para>Sets new size and alignment of embedded object.</para>
    /// </summary>
    public unsafe bool ResizeObject(Variant key, Vector2 size, InlineAlignment inlineAlign = (InlineAlignment)(5), float baseline = 0.0f)
    {
        return NativeCalls.godot_icall_4_1317(MethodBind18, GodotObject.GetPtr(this), key, &size, (int)inlineAlign, baseline).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasObject, 77467830ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if an object with <paramref name="key"/> is embedded in this shaped text buffer.</para>
    /// </summary>
    public bool HasObject(Variant key)
    {
        return NativeCalls.godot_icall_1_1318(MethodBind19, GodotObject.GetPtr(this), key).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAlignment, 2312603777ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAlignment(HorizontalAlignment alignment)
    {
        NativeCalls.godot_icall_1_38(MethodBind20, GodotObject.GetPtr(this), (int)alignment);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAlignment, 341400642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public HorizontalAlignment GetAlignment()
    {
        return (HorizontalAlignment)NativeCalls.godot_icall_0_39(MethodBind21, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.TabAlign, 2899603908ul);

    /// <summary>
    /// <para>Aligns paragraph to the given tab-stops.</para>
    /// </summary>
    public void TabAlign(float[] tabStops)
    {
        NativeCalls.godot_icall_1_647(MethodBind22, GodotObject.GetPtr(this), tabStops);
    }

    /// <summary>
    /// <para>Aligns paragraph to the given tab-stops.</para>
    /// </summary>
    public void TabAlign(ReadOnlySpan<float> tabStops)
    {
        NativeCalls.godot_icall_1_647(MethodBind22, GodotObject.GetPtr(this), tabStops);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBreakFlags, 2809697122ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetBreakFlags(TextServer.LineBreakFlag flags)
    {
        NativeCalls.godot_icall_1_38(MethodBind23, GodotObject.GetPtr(this), (int)flags);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBreakFlags, 2340632602ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public TextServer.LineBreakFlag GetBreakFlags()
    {
        return (TextServer.LineBreakFlag)NativeCalls.godot_icall_0_39(MethodBind24, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetJustificationFlags, 2877345813ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetJustificationFlags(TextServer.JustificationFlag flags)
    {
        NativeCalls.godot_icall_1_38(MethodBind25, GodotObject.GetPtr(this), (int)flags);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetJustificationFlags, 1583363614ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public TextServer.JustificationFlag GetJustificationFlags()
    {
        return (TextServer.JustificationFlag)NativeCalls.godot_icall_0_39(MethodBind26, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTextOverrunBehavior, 1008890932ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTextOverrunBehavior(TextServer.OverrunBehavior overrunBehavior)
    {
        NativeCalls.godot_icall_1_38(MethodBind27, GodotObject.GetPtr(this), (int)overrunBehavior);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTextOverrunBehavior, 3779142101ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public TextServer.OverrunBehavior GetTextOverrunBehavior()
    {
        return (TextServer.OverrunBehavior)NativeCalls.godot_icall_0_39(MethodBind28, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEllipsisChar, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEllipsisChar(string @char)
    {
        NativeCalls.godot_icall_1_57(MethodBind29, GodotObject.GetPtr(this), @char);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEllipsisChar, 201670096ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetEllipsisChar()
    {
        return NativeCalls.godot_icall_0_58(MethodBind30, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetWidth, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetWidth(float width)
    {
        NativeCalls.godot_icall_1_67(MethodBind31, GodotObject.GetPtr(this), width);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind32 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetWidth, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetWidth()
    {
        return NativeCalls.godot_icall_0_68(MethodBind32, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind33 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNonWrappedSize, 3341600327ul);

    /// <summary>
    /// <para>Returns the size of the bounding box of the paragraph, without line breaks.</para>
    /// </summary>
    public Vector2 GetNonWrappedSize()
    {
        return NativeCalls.godot_icall_0_37(MethodBind33, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind34 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSize, 3341600327ul);

    /// <summary>
    /// <para>Returns the size of the bounding box of the paragraph.</para>
    /// </summary>
    public Vector2 GetSize()
    {
        return NativeCalls.godot_icall_0_37(MethodBind34, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind35 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRid, 2944877500ul);

    /// <summary>
    /// <para>Returns TextServer full string buffer RID.</para>
    /// </summary>
    public Rid GetRid()
    {
        return NativeCalls.godot_icall_0_238(MethodBind35, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind36 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLineRid, 495598643ul);

    /// <summary>
    /// <para>Returns TextServer line buffer RID.</para>
    /// </summary>
    public Rid GetLineRid(int line)
    {
        return NativeCalls.godot_icall_1_425(MethodBind36, GodotObject.GetPtr(this), line);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind37 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDropcapRid, 2944877500ul);

    /// <summary>
    /// <para>Returns drop cap text buffer RID.</para>
    /// </summary>
    public Rid GetDropcapRid()
    {
        return NativeCalls.godot_icall_0_238(MethodBind37, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind38 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRange, 3690982128ul);

    /// <summary>
    /// <para>Returns the character range of the paragraph.</para>
    /// </summary>
    public Vector2I GetRange()
    {
        return NativeCalls.godot_icall_0_35(MethodBind38, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind39 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLineCount, 3905245786ul);

    /// <summary>
    /// <para>Returns number of lines in the paragraph.</para>
    /// </summary>
    public int GetLineCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind39, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind40 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMaxLinesVisible, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMaxLinesVisible(int maxLinesVisible)
    {
        NativeCalls.godot_icall_1_38(MethodBind40, GodotObject.GetPtr(this), maxLinesVisible);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind41 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMaxLinesVisible, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetMaxLinesVisible()
    {
        return NativeCalls.godot_icall_0_39(MethodBind41, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind42 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLineSpacing, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetLineSpacing(float lineSpacing)
    {
        NativeCalls.godot_icall_1_67(MethodBind42, GodotObject.GetPtr(this), lineSpacing);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind43 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLineSpacing, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetLineSpacing()
    {
        return NativeCalls.godot_icall_0_68(MethodBind43, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind44 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLineObjects, 663333327ul);

    /// <summary>
    /// <para>Returns array of inline objects in the line.</para>
    /// </summary>
    public Godot.Collections.Array GetLineObjects(int line)
    {
        return NativeCalls.godot_icall_1_457(MethodBind44, GodotObject.GetPtr(this), line);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind45 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLineObjectRect, 204315017ul);

    /// <summary>
    /// <para>Returns bounding rectangle of the inline object.</para>
    /// </summary>
    public Rect2 GetLineObjectRect(int line, Variant key)
    {
        return NativeCalls.godot_icall_2_1326(MethodBind45, GodotObject.GetPtr(this), line, key);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind46 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLineSize, 2299179447ul);

    /// <summary>
    /// <para>Returns size of the bounding box of the line of text. Returned size is rounded up.</para>
    /// </summary>
    public Vector2 GetLineSize(int line)
    {
        return NativeCalls.godot_icall_1_148(MethodBind46, GodotObject.GetPtr(this), line);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind47 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLineRange, 880721226ul);

    /// <summary>
    /// <para>Returns character range of the line.</para>
    /// </summary>
    public Vector2I GetLineRange(int line)
    {
        return NativeCalls.godot_icall_1_405(MethodBind47, GodotObject.GetPtr(this), line);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind48 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLineAscent, 2339986948ul);

    /// <summary>
    /// <para>Returns the text line ascent (number of pixels above the baseline for horizontal layout or to the left of baseline for vertical).</para>
    /// </summary>
    public float GetLineAscent(int line)
    {
        return NativeCalls.godot_icall_1_72(MethodBind48, GodotObject.GetPtr(this), line);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind49 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLineDescent, 2339986948ul);

    /// <summary>
    /// <para>Returns the text line descent (number of pixels below the baseline for horizontal layout or to the right of baseline for vertical).</para>
    /// </summary>
    public float GetLineDescent(int line)
    {
        return NativeCalls.godot_icall_1_72(MethodBind49, GodotObject.GetPtr(this), line);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind50 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLineWidth, 2339986948ul);

    /// <summary>
    /// <para>Returns width (for horizontal layout) or height (for vertical) of the line of text.</para>
    /// </summary>
    public float GetLineWidth(int line)
    {
        return NativeCalls.godot_icall_1_72(MethodBind50, GodotObject.GetPtr(this), line);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind51 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLineUnderlinePosition, 2339986948ul);

    /// <summary>
    /// <para>Returns pixel offset of the underline below the baseline.</para>
    /// </summary>
    public float GetLineUnderlinePosition(int line)
    {
        return NativeCalls.godot_icall_1_72(MethodBind51, GodotObject.GetPtr(this), line);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind52 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLineUnderlineThickness, 2339986948ul);

    /// <summary>
    /// <para>Returns thickness of the underline.</para>
    /// </summary>
    public float GetLineUnderlineThickness(int line)
    {
        return NativeCalls.godot_icall_1_72(MethodBind52, GodotObject.GetPtr(this), line);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind53 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDropcapSize, 3341600327ul);

    /// <summary>
    /// <para>Returns drop cap bounding box size.</para>
    /// </summary>
    public Vector2 GetDropcapSize()
    {
        return NativeCalls.godot_icall_0_37(MethodBind53, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind54 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDropcapLines, 3905245786ul);

    /// <summary>
    /// <para>Returns number of lines used by dropcap.</para>
    /// </summary>
    public int GetDropcapLines()
    {
        return NativeCalls.godot_icall_0_39(MethodBind54, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind55 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Draw, 1492808103ul);

    /// <summary>
    /// <para>Draw all lines of the text and drop cap into a canvas item at a given position, with <paramref name="color"/>. <paramref name="pos"/> specifies the top left corner of the bounding box. If <paramref name="oversampling"/> is greater than zero, it is used as font oversampling factor, otherwise viewport oversampling settings are used.</para>
    /// </summary>
    /// <param name="color">If the parameter is null, then the default value is <c>new Color(1.0f, 1.0f, 1.0f, 1.0f)</c>.</param>
    /// <param name="dcColor">If the parameter is null, then the default value is <c>new Color(1.0f, 1.0f, 1.0f, 1.0f)</c>.</param>
    public unsafe void Draw(Rid canvas, Vector2 pos, Nullable<Color> color = null, Nullable<Color> dcColor = null, float oversampling = 0.0f)
    {
        Color colorOrDefVal = color.HasValue ? color.Value : new Color(1.0f, 1.0f, 1.0f, 1.0f);
        Color dcColorOrDefVal = dcColor.HasValue ? dcColor.Value : new Color(1.0f, 1.0f, 1.0f, 1.0f);
        NativeCalls.godot_icall_5_1327(MethodBind55, GodotObject.GetPtr(this), canvas, &pos, &colorOrDefVal, &dcColorOrDefVal, oversampling);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind56 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DrawOutline, 3820500590ul);

    /// <summary>
    /// <para>Draw outlines of all lines of the text and drop cap into a canvas item at a given position, with <paramref name="color"/>. <paramref name="pos"/> specifies the top left corner of the bounding box. If <paramref name="oversampling"/> is greater than zero, it is used as font oversampling factor, otherwise viewport oversampling settings are used.</para>
    /// </summary>
    /// <param name="color">If the parameter is null, then the default value is <c>new Color(1.0f, 1.0f, 1.0f, 1.0f)</c>.</param>
    /// <param name="dcColor">If the parameter is null, then the default value is <c>new Color(1.0f, 1.0f, 1.0f, 1.0f)</c>.</param>
    public unsafe void DrawOutline(Rid canvas, Vector2 pos, int outlineSize = 1, Nullable<Color> color = null, Nullable<Color> dcColor = null, float oversampling = 0.0f)
    {
        Color colorOrDefVal = color.HasValue ? color.Value : new Color(1.0f, 1.0f, 1.0f, 1.0f);
        Color dcColorOrDefVal = dcColor.HasValue ? dcColor.Value : new Color(1.0f, 1.0f, 1.0f, 1.0f);
        NativeCalls.godot_icall_6_1328(MethodBind56, GodotObject.GetPtr(this), canvas, &pos, outlineSize, &colorOrDefVal, &dcColorOrDefVal, oversampling);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind57 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DrawLine, 828033758ul);

    /// <summary>
    /// <para>Draw single line of text into a canvas item at a given position, with <paramref name="color"/>. <paramref name="pos"/> specifies the top left corner of the bounding box. If <paramref name="oversampling"/> is greater than zero, it is used as font oversampling factor, otherwise viewport oversampling settings are used.</para>
    /// </summary>
    /// <param name="color">If the parameter is null, then the default value is <c>new Color(1.0f, 1.0f, 1.0f, 1.0f)</c>.</param>
    public unsafe void DrawLine(Rid canvas, Vector2 pos, int line, Nullable<Color> color = null, float oversampling = 0.0f)
    {
        Color colorOrDefVal = color.HasValue ? color.Value : new Color(1.0f, 1.0f, 1.0f, 1.0f);
        NativeCalls.godot_icall_5_1321(MethodBind57, GodotObject.GetPtr(this), canvas, &pos, line, &colorOrDefVal, oversampling);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind58 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DrawLineOutline, 2822696703ul);

    /// <summary>
    /// <para>Draw outline of the single line of text into a canvas item at a given position, with <paramref name="color"/>. <paramref name="pos"/> specifies the top left corner of the bounding box. If <paramref name="oversampling"/> is greater than zero, it is used as font oversampling factor, otherwise viewport oversampling settings are used.</para>
    /// </summary>
    /// <param name="color">If the parameter is null, then the default value is <c>new Color(1.0f, 1.0f, 1.0f, 1.0f)</c>.</param>
    public unsafe void DrawLineOutline(Rid canvas, Vector2 pos, int line, int outlineSize = 1, Nullable<Color> color = null, float oversampling = 0.0f)
    {
        Color colorOrDefVal = color.HasValue ? color.Value : new Color(1.0f, 1.0f, 1.0f, 1.0f);
        NativeCalls.godot_icall_6_1329(MethodBind58, GodotObject.GetPtr(this), canvas, &pos, line, outlineSize, &colorOrDefVal, oversampling);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind59 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DrawDropcap, 3625105422ul);

    /// <summary>
    /// <para>Draw drop cap into a canvas item at a given position, with <paramref name="color"/>. <paramref name="pos"/> specifies the top left corner of the bounding box. If <paramref name="oversampling"/> is greater than zero, it is used as font oversampling factor, otherwise viewport oversampling settings are used.</para>
    /// </summary>
    /// <param name="color">If the parameter is null, then the default value is <c>new Color(1.0f, 1.0f, 1.0f, 1.0f)</c>.</param>
    public unsafe void DrawDropcap(Rid canvas, Vector2 pos, Nullable<Color> color = null, float oversampling = 0.0f)
    {
        Color colorOrDefVal = color.HasValue ? color.Value : new Color(1.0f, 1.0f, 1.0f, 1.0f);
        NativeCalls.godot_icall_4_1320(MethodBind59, GodotObject.GetPtr(this), canvas, &pos, &colorOrDefVal, oversampling);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind60 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DrawDropcapOutline, 2592177763ul);

    /// <summary>
    /// <para>Draw drop cap outline into a canvas item at a given position, with <paramref name="color"/>. <paramref name="pos"/> specifies the top left corner of the bounding box. If <paramref name="oversampling"/> is greater than zero, it is used as font oversampling factor, otherwise viewport oversampling settings are used.</para>
    /// </summary>
    /// <param name="color">If the parameter is null, then the default value is <c>new Color(1.0f, 1.0f, 1.0f, 1.0f)</c>.</param>
    public unsafe void DrawDropcapOutline(Rid canvas, Vector2 pos, int outlineSize = 1, Nullable<Color> color = null, float oversampling = 0.0f)
    {
        Color colorOrDefVal = color.HasValue ? color.Value : new Color(1.0f, 1.0f, 1.0f, 1.0f);
        NativeCalls.godot_icall_5_1321(MethodBind60, GodotObject.GetPtr(this), canvas, &pos, outlineSize, &colorOrDefVal, oversampling);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind61 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HitTest, 3820158470ul);

    /// <summary>
    /// <para>Returns caret character offset at the specified coordinates. This function always returns a valid position.</para>
    /// </summary>
    public unsafe int HitTest(Vector2 coords)
    {
        return NativeCalls.godot_icall_1_340(MethodBind61, GodotObject.GetPtr(this), &coords);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind62 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DrawDropcapOutline, 1343401456ul);

    /// <summary>
    /// <para>Draw drop cap outline into a canvas item at a given position, with <paramref name="color"/>. <paramref name="pos"/> specifies the top left corner of the bounding box. If <paramref name="oversampling"/> is greater than zero, it is used as font oversampling factor, otherwise viewport oversampling settings are used.</para>
    /// </summary>
    /// <param name="color">If the parameter is null, then the default value is <c>new Color(1.0f, 1.0f, 1.0f, 1.0f)</c>.</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void DrawDropcapOutline(Rid canvas, Vector2 pos, int outlineSize, Nullable<Color> color)
    {
        Color colorOrDefVal = color.HasValue ? color.Value : new Color(1.0f, 1.0f, 1.0f, 1.0f);
        NativeCalls.godot_icall_4_1323(MethodBind62, GodotObject.GetPtr(this), canvas, &pos, outlineSize, &colorOrDefVal);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind63 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DrawDropcap, 856975658ul);

    /// <summary>
    /// <para>Draw drop cap into a canvas item at a given position, with <paramref name="color"/>. <paramref name="pos"/> specifies the top left corner of the bounding box. If <paramref name="oversampling"/> is greater than zero, it is used as font oversampling factor, otherwise viewport oversampling settings are used.</para>
    /// </summary>
    /// <param name="color">If the parameter is null, then the default value is <c>new Color(1.0f, 1.0f, 1.0f, 1.0f)</c>.</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void DrawDropcap(Rid canvas, Vector2 pos, Nullable<Color> color)
    {
        Color colorOrDefVal = color.HasValue ? color.Value : new Color(1.0f, 1.0f, 1.0f, 1.0f);
        NativeCalls.godot_icall_3_1324(MethodBind63, GodotObject.GetPtr(this), canvas, &pos, &colorOrDefVal);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind64 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DrawLineOutline, 2664926980ul);

    /// <summary>
    /// <para>Draw outline of the single line of text into a canvas item at a given position, with <paramref name="color"/>. <paramref name="pos"/> specifies the top left corner of the bounding box. If <paramref name="oversampling"/> is greater than zero, it is used as font oversampling factor, otherwise viewport oversampling settings are used.</para>
    /// </summary>
    /// <param name="color">If the parameter is null, then the default value is <c>new Color(1.0f, 1.0f, 1.0f, 1.0f)</c>.</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void DrawLineOutline(Rid canvas, Vector2 pos, int line, int outlineSize, Nullable<Color> color)
    {
        Color colorOrDefVal = color.HasValue ? color.Value : new Color(1.0f, 1.0f, 1.0f, 1.0f);
        NativeCalls.godot_icall_5_1330(MethodBind64, GodotObject.GetPtr(this), canvas, &pos, line, outlineSize, &colorOrDefVal);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind65 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DrawLine, 1242169894ul);

    /// <summary>
    /// <para>Draw single line of text into a canvas item at a given position, with <paramref name="color"/>. <paramref name="pos"/> specifies the top left corner of the bounding box. If <paramref name="oversampling"/> is greater than zero, it is used as font oversampling factor, otherwise viewport oversampling settings are used.</para>
    /// </summary>
    /// <param name="color">If the parameter is null, then the default value is <c>new Color(1.0f, 1.0f, 1.0f, 1.0f)</c>.</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void DrawLine(Rid canvas, Vector2 pos, int line, Nullable<Color> color)
    {
        Color colorOrDefVal = color.HasValue ? color.Value : new Color(1.0f, 1.0f, 1.0f, 1.0f);
        NativeCalls.godot_icall_4_1323(MethodBind65, GodotObject.GetPtr(this), canvas, &pos, line, &colorOrDefVal);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind66 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DrawOutline, 1893131224ul);

    /// <summary>
    /// <para>Draw outlines of all lines of the text and drop cap into a canvas item at a given position, with <paramref name="color"/>. <paramref name="pos"/> specifies the top left corner of the bounding box. If <paramref name="oversampling"/> is greater than zero, it is used as font oversampling factor, otherwise viewport oversampling settings are used.</para>
    /// </summary>
    /// <param name="color">If the parameter is null, then the default value is <c>new Color(1.0f, 1.0f, 1.0f, 1.0f)</c>.</param>
    /// <param name="dcColor">If the parameter is null, then the default value is <c>new Color(1.0f, 1.0f, 1.0f, 1.0f)</c>.</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void DrawOutline(Rid canvas, Vector2 pos, int outlineSize, Nullable<Color> color, Nullable<Color> dcColor)
    {
        Color colorOrDefVal = color.HasValue ? color.Value : new Color(1.0f, 1.0f, 1.0f, 1.0f);
        Color dcColorOrDefVal = dcColor.HasValue ? dcColor.Value : new Color(1.0f, 1.0f, 1.0f, 1.0f);
        NativeCalls.godot_icall_5_1331(MethodBind66, GodotObject.GetPtr(this), canvas, &pos, outlineSize, &colorOrDefVal, &dcColorOrDefVal);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind67 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Draw, 1567802413ul);

    /// <summary>
    /// <para>Draw all lines of the text and drop cap into a canvas item at a given position, with <paramref name="color"/>. <paramref name="pos"/> specifies the top left corner of the bounding box. If <paramref name="oversampling"/> is greater than zero, it is used as font oversampling factor, otherwise viewport oversampling settings are used.</para>
    /// </summary>
    /// <param name="color">If the parameter is null, then the default value is <c>new Color(1.0f, 1.0f, 1.0f, 1.0f)</c>.</param>
    /// <param name="dcColor">If the parameter is null, then the default value is <c>new Color(1.0f, 1.0f, 1.0f, 1.0f)</c>.</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void Draw(Rid canvas, Vector2 pos, Nullable<Color> color, Nullable<Color> dcColor)
    {
        Color colorOrDefVal = color.HasValue ? color.Value : new Color(1.0f, 1.0f, 1.0f, 1.0f);
        Color dcColorOrDefVal = dcColor.HasValue ? dcColor.Value : new Color(1.0f, 1.0f, 1.0f, 1.0f);
        NativeCalls.godot_icall_4_1332(MethodBind67, GodotObject.GetPtr(this), canvas, &pos, &colorOrDefVal, &dcColorOrDefVal);
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
        /// <summary>
        /// Cached name for the 'direction' property.
        /// </summary>
        public static readonly StringName Direction = "direction";
        /// <summary>
        /// Cached name for the 'custom_punctuation' property.
        /// </summary>
        public static readonly StringName CustomPunctuation = "custom_punctuation";
        /// <summary>
        /// Cached name for the 'orientation' property.
        /// </summary>
        public static readonly StringName Orientation = "orientation";
        /// <summary>
        /// Cached name for the 'preserve_invalid' property.
        /// </summary>
        public static readonly StringName PreserveInvalid = "preserve_invalid";
        /// <summary>
        /// Cached name for the 'preserve_control' property.
        /// </summary>
        public static readonly StringName PreserveControl = "preserve_control";
        /// <summary>
        /// Cached name for the 'alignment' property.
        /// </summary>
        public static readonly StringName Alignment = "alignment";
        /// <summary>
        /// Cached name for the 'break_flags' property.
        /// </summary>
        public static readonly StringName BreakFlags = "break_flags";
        /// <summary>
        /// Cached name for the 'justification_flags' property.
        /// </summary>
        public static readonly StringName JustificationFlags = "justification_flags";
        /// <summary>
        /// Cached name for the 'text_overrun_behavior' property.
        /// </summary>
        public static readonly StringName TextOverrunBehavior = "text_overrun_behavior";
        /// <summary>
        /// Cached name for the 'ellipsis_char' property.
        /// </summary>
        public static readonly StringName EllipsisChar = "ellipsis_char";
        /// <summary>
        /// Cached name for the 'width' property.
        /// </summary>
        public static readonly StringName Width = "width";
        /// <summary>
        /// Cached name for the 'max_lines_visible' property.
        /// </summary>
        public static readonly StringName MaxLinesVisible = "max_lines_visible";
        /// <summary>
        /// Cached name for the 'line_spacing' property.
        /// </summary>
        public static readonly StringName LineSpacing = "line_spacing";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : RefCounted.MethodName
    {
        /// <summary>
        /// Cached name for the 'clear' method.
        /// </summary>
        public static readonly StringName Clear = "clear";
        /// <summary>
        /// Cached name for the 'duplicate' method.
        /// </summary>
        public static readonly StringName Duplicate = "duplicate";
        /// <summary>
        /// Cached name for the 'set_direction' method.
        /// </summary>
        public static readonly StringName SetDirection = "set_direction";
        /// <summary>
        /// Cached name for the 'get_direction' method.
        /// </summary>
        public static readonly StringName GetDirection = "get_direction";
        /// <summary>
        /// Cached name for the 'get_inferred_direction' method.
        /// </summary>
        public static readonly StringName GetInferredDirection = "get_inferred_direction";
        /// <summary>
        /// Cached name for the 'set_custom_punctuation' method.
        /// </summary>
        public static readonly StringName SetCustomPunctuation = "set_custom_punctuation";
        /// <summary>
        /// Cached name for the 'get_custom_punctuation' method.
        /// </summary>
        public static readonly StringName GetCustomPunctuation = "get_custom_punctuation";
        /// <summary>
        /// Cached name for the 'set_orientation' method.
        /// </summary>
        public static readonly StringName SetOrientation = "set_orientation";
        /// <summary>
        /// Cached name for the 'get_orientation' method.
        /// </summary>
        public static readonly StringName GetOrientation = "get_orientation";
        /// <summary>
        /// Cached name for the 'set_preserve_invalid' method.
        /// </summary>
        public static readonly StringName SetPreserveInvalid = "set_preserve_invalid";
        /// <summary>
        /// Cached name for the 'get_preserve_invalid' method.
        /// </summary>
        public static readonly StringName GetPreserveInvalid = "get_preserve_invalid";
        /// <summary>
        /// Cached name for the 'set_preserve_control' method.
        /// </summary>
        public static readonly StringName SetPreserveControl = "set_preserve_control";
        /// <summary>
        /// Cached name for the 'get_preserve_control' method.
        /// </summary>
        public static readonly StringName GetPreserveControl = "get_preserve_control";
        /// <summary>
        /// Cached name for the 'set_bidi_override' method.
        /// </summary>
        public static readonly StringName SetBidiOverride = "set_bidi_override";
        /// <summary>
        /// Cached name for the 'set_dropcap' method.
        /// </summary>
        public static readonly StringName SetDropcap = "set_dropcap";
        /// <summary>
        /// Cached name for the 'clear_dropcap' method.
        /// </summary>
        public static readonly StringName ClearDropcap = "clear_dropcap";
        /// <summary>
        /// Cached name for the 'add_string' method.
        /// </summary>
        public static readonly StringName AddString = "add_string";
        /// <summary>
        /// Cached name for the 'add_object' method.
        /// </summary>
        public static readonly StringName AddObject = "add_object";
        /// <summary>
        /// Cached name for the 'resize_object' method.
        /// </summary>
        public static readonly StringName ResizeObject = "resize_object";
        /// <summary>
        /// Cached name for the 'has_object' method.
        /// </summary>
        public static readonly StringName HasObject = "has_object";
        /// <summary>
        /// Cached name for the 'set_alignment' method.
        /// </summary>
        public static readonly StringName SetAlignment = "set_alignment";
        /// <summary>
        /// Cached name for the 'get_alignment' method.
        /// </summary>
        public static readonly StringName GetAlignment = "get_alignment";
        /// <summary>
        /// Cached name for the 'tab_align' method.
        /// </summary>
        public static readonly StringName TabAlign = "tab_align";
        /// <summary>
        /// Cached name for the 'set_break_flags' method.
        /// </summary>
        public static readonly StringName SetBreakFlags = "set_break_flags";
        /// <summary>
        /// Cached name for the 'get_break_flags' method.
        /// </summary>
        public static readonly StringName GetBreakFlags = "get_break_flags";
        /// <summary>
        /// Cached name for the 'set_justification_flags' method.
        /// </summary>
        public static readonly StringName SetJustificationFlags = "set_justification_flags";
        /// <summary>
        /// Cached name for the 'get_justification_flags' method.
        /// </summary>
        public static readonly StringName GetJustificationFlags = "get_justification_flags";
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
        /// Cached name for the 'set_width' method.
        /// </summary>
        public static readonly StringName SetWidth = "set_width";
        /// <summary>
        /// Cached name for the 'get_width' method.
        /// </summary>
        public static readonly StringName GetWidth = "get_width";
        /// <summary>
        /// Cached name for the 'get_non_wrapped_size' method.
        /// </summary>
        public static readonly StringName GetNonWrappedSize = "get_non_wrapped_size";
        /// <summary>
        /// Cached name for the 'get_size' method.
        /// </summary>
        public static readonly StringName GetSize = "get_size";
        /// <summary>
        /// Cached name for the 'get_rid' method.
        /// </summary>
        public static readonly StringName GetRid = "get_rid";
        /// <summary>
        /// Cached name for the 'get_line_rid' method.
        /// </summary>
        public static readonly StringName GetLineRid = "get_line_rid";
        /// <summary>
        /// Cached name for the 'get_dropcap_rid' method.
        /// </summary>
        public static readonly StringName GetDropcapRid = "get_dropcap_rid";
        /// <summary>
        /// Cached name for the 'get_range' method.
        /// </summary>
        public static readonly StringName GetRange = "get_range";
        /// <summary>
        /// Cached name for the 'get_line_count' method.
        /// </summary>
        public static readonly StringName GetLineCount = "get_line_count";
        /// <summary>
        /// Cached name for the 'set_max_lines_visible' method.
        /// </summary>
        public static readonly StringName SetMaxLinesVisible = "set_max_lines_visible";
        /// <summary>
        /// Cached name for the 'get_max_lines_visible' method.
        /// </summary>
        public static readonly StringName GetMaxLinesVisible = "get_max_lines_visible";
        /// <summary>
        /// Cached name for the 'set_line_spacing' method.
        /// </summary>
        public static readonly StringName SetLineSpacing = "set_line_spacing";
        /// <summary>
        /// Cached name for the 'get_line_spacing' method.
        /// </summary>
        public static readonly StringName GetLineSpacing = "get_line_spacing";
        /// <summary>
        /// Cached name for the 'get_line_objects' method.
        /// </summary>
        public static readonly StringName GetLineObjects = "get_line_objects";
        /// <summary>
        /// Cached name for the 'get_line_object_rect' method.
        /// </summary>
        public static readonly StringName GetLineObjectRect = "get_line_object_rect";
        /// <summary>
        /// Cached name for the 'get_line_size' method.
        /// </summary>
        public static readonly StringName GetLineSize = "get_line_size";
        /// <summary>
        /// Cached name for the 'get_line_range' method.
        /// </summary>
        public static readonly StringName GetLineRange = "get_line_range";
        /// <summary>
        /// Cached name for the 'get_line_ascent' method.
        /// </summary>
        public static readonly StringName GetLineAscent = "get_line_ascent";
        /// <summary>
        /// Cached name for the 'get_line_descent' method.
        /// </summary>
        public static readonly StringName GetLineDescent = "get_line_descent";
        /// <summary>
        /// Cached name for the 'get_line_width' method.
        /// </summary>
        public static readonly StringName GetLineWidth = "get_line_width";
        /// <summary>
        /// Cached name for the 'get_line_underline_position' method.
        /// </summary>
        public static readonly StringName GetLineUnderlinePosition = "get_line_underline_position";
        /// <summary>
        /// Cached name for the 'get_line_underline_thickness' method.
        /// </summary>
        public static readonly StringName GetLineUnderlineThickness = "get_line_underline_thickness";
        /// <summary>
        /// Cached name for the 'get_dropcap_size' method.
        /// </summary>
        public static readonly StringName GetDropcapSize = "get_dropcap_size";
        /// <summary>
        /// Cached name for the 'get_dropcap_lines' method.
        /// </summary>
        public static readonly StringName GetDropcapLines = "get_dropcap_lines";
        /// <summary>
        /// Cached name for the 'draw' method.
        /// </summary>
        public static readonly StringName Draw = "draw";
        /// <summary>
        /// Cached name for the 'draw_outline' method.
        /// </summary>
        public static readonly StringName DrawOutline = "draw_outline";
        /// <summary>
        /// Cached name for the 'draw_line' method.
        /// </summary>
        public static readonly StringName DrawLine = "draw_line";
        /// <summary>
        /// Cached name for the 'draw_line_outline' method.
        /// </summary>
        public static readonly StringName DrawLineOutline = "draw_line_outline";
        /// <summary>
        /// Cached name for the 'draw_dropcap' method.
        /// </summary>
        public static readonly StringName DrawDropcap = "draw_dropcap";
        /// <summary>
        /// Cached name for the 'draw_dropcap_outline' method.
        /// </summary>
        public static readonly StringName DrawDropcapOutline = "draw_dropcap_outline";
        /// <summary>
        /// Cached name for the 'hit_test' method.
        /// </summary>
        public static readonly StringName HitTest = "hit_test";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : RefCounted.SignalName
    {
    }
}
