namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Abstraction over <see cref="Godot.TextServer"/> for handling a single line of text.</para>
/// </summary>
public partial class TextLine : RefCounted
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
    /// <para>Text line width.</para>
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
    /// <para>Sets text alignment within the line as if the line was horizontal.</para>
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
    /// <para>Line alignment rules. For more info see <see cref="Godot.TextServer"/>.</para>
    /// </summary>
    public TextServer.JustificationFlag Flags
    {
        get
        {
            return GetFlags();
        }
        set
        {
            SetFlags(value);
        }
    }

    /// <summary>
    /// <para>The clipping behavior when the text exceeds the text line's set width.</para>
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

    private static readonly System.Type CachedType = typeof(TextLine);

    private static readonly StringName NativeName = "TextLine";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public TextLine() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal TextLine(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal TextLine(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Clear, 3218959716ul);

    /// <summary>
    /// <para>Clears text line (removes text and inline objects).</para>
    /// </summary>
    public void Clear()
    {
        NativeCalls.godot_icall_0_3(MethodBind0, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Duplicate, 1912703884ul);

    /// <summary>
    /// <para>Duplicates this <see cref="Godot.TextLine"/>.</para>
    /// </summary>
    public TextLine Duplicate()
    {
        return (TextLine)NativeCalls.godot_icall_0_63(MethodBind1, GodotObject.GetPtr(this));
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
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetOrientation, 42823726ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetOrientation(TextServer.Orientation orientation)
    {
        NativeCalls.godot_icall_1_38(MethodBind5, GodotObject.GetPtr(this), (int)orientation);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOrientation, 175768116ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public TextServer.Orientation GetOrientation()
    {
        return (TextServer.Orientation)NativeCalls.godot_icall_0_39(MethodBind6, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPreserveInvalid, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPreserveInvalid(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind7, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPreserveInvalid, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetPreserveInvalid()
    {
        return NativeCalls.godot_icall_0_15(MethodBind8, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPreserveControl, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPreserveControl(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind9, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPreserveControl, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetPreserveControl()
    {
        return NativeCalls.godot_icall_0_15(MethodBind10, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBidiOverride, 381264803ul);

    /// <summary>
    /// <para>Overrides BiDi for the structured text.</para>
    /// <para>Override ranges should cover full source text without overlaps. BiDi algorithm will be used on each range separately.</para>
    /// </summary>
    public void SetBidiOverride(Godot.Collections.Array @override)
    {
        NativeCalls.godot_icall_1_138(MethodBind11, GodotObject.GetPtr(this), (godot_array)(@override ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddString, 621426851ul);

    /// <summary>
    /// <para>Adds text span and font to draw it.</para>
    /// </summary>
    public bool AddString(string text, Font font, int fontSize, string language = "", Variant meta = default)
    {
        return NativeCalls.godot_icall_5_1315(MethodBind12, GodotObject.GetPtr(this), text, GodotObject.GetPtr(font), fontSize, language, meta).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddObject, 1316529304ul);

    /// <summary>
    /// <para>Adds inline object to the text buffer, <paramref name="key"/> must be unique. In the text, object is represented as <paramref name="length"/> object replacement characters.</para>
    /// </summary>
    public unsafe bool AddObject(Variant key, Vector2 size, InlineAlignment inlineAlign = (InlineAlignment)(5), int length = 1, float baseline = 0.0f)
    {
        return NativeCalls.godot_icall_5_1316(MethodBind13, GodotObject.GetPtr(this), key, &size, (int)inlineAlign, length, baseline).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ResizeObject, 2095776372ul);

    /// <summary>
    /// <para>Sets new size and alignment of embedded object.</para>
    /// </summary>
    public unsafe bool ResizeObject(Variant key, Vector2 size, InlineAlignment inlineAlign = (InlineAlignment)(5), float baseline = 0.0f)
    {
        return NativeCalls.godot_icall_4_1317(MethodBind14, GodotObject.GetPtr(this), key, &size, (int)inlineAlign, baseline).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasObject, 77467830ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if an object with <paramref name="key"/> is embedded in this line.</para>
    /// </summary>
    public bool HasObject(Variant key)
    {
        return NativeCalls.godot_icall_1_1318(MethodBind15, GodotObject.GetPtr(this), key).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetWidth, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetWidth(float width)
    {
        NativeCalls.godot_icall_1_67(MethodBind16, GodotObject.GetPtr(this), width);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetWidth, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetWidth()
    {
        return NativeCalls.godot_icall_0_68(MethodBind17, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetHorizontalAlignment, 2312603777ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetHorizontalAlignment(HorizontalAlignment alignment)
    {
        NativeCalls.godot_icall_1_38(MethodBind18, GodotObject.GetPtr(this), (int)alignment);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetHorizontalAlignment, 341400642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public HorizontalAlignment GetHorizontalAlignment()
    {
        return (HorizontalAlignment)NativeCalls.godot_icall_0_39(MethodBind19, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.TabAlign, 2899603908ul);

    /// <summary>
    /// <para>Aligns text to the given tab-stops.</para>
    /// </summary>
    public void TabAlign(float[] tabStops)
    {
        NativeCalls.godot_icall_1_647(MethodBind20, GodotObject.GetPtr(this), tabStops);
    }

    /// <summary>
    /// <para>Aligns text to the given tab-stops.</para>
    /// </summary>
    public void TabAlign(ReadOnlySpan<float> tabStops)
    {
        NativeCalls.godot_icall_1_647(MethodBind20, GodotObject.GetPtr(this), tabStops);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFlags, 2877345813ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFlags(TextServer.JustificationFlag flags)
    {
        NativeCalls.godot_icall_1_38(MethodBind21, GodotObject.GetPtr(this), (int)flags);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFlags, 1583363614ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public TextServer.JustificationFlag GetFlags()
    {
        return (TextServer.JustificationFlag)NativeCalls.godot_icall_0_39(MethodBind22, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTextOverrunBehavior, 1008890932ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTextOverrunBehavior(TextServer.OverrunBehavior overrunBehavior)
    {
        NativeCalls.godot_icall_1_38(MethodBind23, GodotObject.GetPtr(this), (int)overrunBehavior);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTextOverrunBehavior, 3779142101ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public TextServer.OverrunBehavior GetTextOverrunBehavior()
    {
        return (TextServer.OverrunBehavior)NativeCalls.godot_icall_0_39(MethodBind24, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEllipsisChar, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEllipsisChar(string @char)
    {
        NativeCalls.godot_icall_1_57(MethodBind25, GodotObject.GetPtr(this), @char);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEllipsisChar, 201670096ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetEllipsisChar()
    {
        return NativeCalls.godot_icall_0_58(MethodBind26, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetObjects, 3995934104ul);

    /// <summary>
    /// <para>Returns array of inline objects.</para>
    /// </summary>
    public Godot.Collections.Array GetObjects()
    {
        return NativeCalls.godot_icall_0_120(MethodBind27, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetObjectRect, 1742700391ul);

    /// <summary>
    /// <para>Returns bounding rectangle of the inline object.</para>
    /// </summary>
    public Rect2 GetObjectRect(Variant key)
    {
        return NativeCalls.godot_icall_1_1319(MethodBind28, GodotObject.GetPtr(this), key);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSize, 3341600327ul);

    /// <summary>
    /// <para>Returns size of the bounding box of the text.</para>
    /// </summary>
    public Vector2 GetSize()
    {
        return NativeCalls.godot_icall_0_37(MethodBind29, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRid, 2944877500ul);

    /// <summary>
    /// <para>Returns TextServer buffer RID.</para>
    /// </summary>
    public Rid GetRid()
    {
        return NativeCalls.godot_icall_0_238(MethodBind30, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLineAscent, 1740695150ul);

    /// <summary>
    /// <para>Returns the text ascent (number of pixels above the baseline for horizontal layout or to the left of baseline for vertical).</para>
    /// </summary>
    public float GetLineAscent()
    {
        return NativeCalls.godot_icall_0_68(MethodBind31, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind32 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLineDescent, 1740695150ul);

    /// <summary>
    /// <para>Returns the text descent (number of pixels below the baseline for horizontal layout or to the right of baseline for vertical).</para>
    /// </summary>
    public float GetLineDescent()
    {
        return NativeCalls.godot_icall_0_68(MethodBind32, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind33 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLineWidth, 1740695150ul);

    /// <summary>
    /// <para>Returns width (for horizontal layout) or height (for vertical) of the text.</para>
    /// </summary>
    public float GetLineWidth()
    {
        return NativeCalls.godot_icall_0_68(MethodBind33, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind34 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLineUnderlinePosition, 1740695150ul);

    /// <summary>
    /// <para>Returns pixel offset of the underline below the baseline.</para>
    /// </summary>
    public float GetLineUnderlinePosition()
    {
        return NativeCalls.godot_icall_0_68(MethodBind34, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind35 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLineUnderlineThickness, 1740695150ul);

    /// <summary>
    /// <para>Returns thickness of the underline.</para>
    /// </summary>
    public float GetLineUnderlineThickness()
    {
        return NativeCalls.godot_icall_0_68(MethodBind35, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind36 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Draw, 3625105422ul);

    /// <summary>
    /// <para>Draw text into a canvas item at a given position, with <paramref name="color"/>. <paramref name="pos"/> specifies the top left corner of the bounding box. If <paramref name="oversampling"/> is greater than zero, it is used as font oversampling factor, otherwise viewport oversampling settings are used.</para>
    /// </summary>
    /// <param name="color">If the parameter is null, then the default value is <c>new Color(1.0f, 1.0f, 1.0f, 1.0f)</c>.</param>
    public unsafe void Draw(Rid canvas, Vector2 pos, Nullable<Color> color = null, float oversampling = 0.0f)
    {
        Color colorOrDefVal = color.HasValue ? color.Value : new Color(1.0f, 1.0f, 1.0f, 1.0f);
        NativeCalls.godot_icall_4_1320(MethodBind36, GodotObject.GetPtr(this), canvas, &pos, &colorOrDefVal, oversampling);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind37 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DrawOutline, 2592177763ul);

    /// <summary>
    /// <para>Draw text into a canvas item at a given position, with <paramref name="color"/>. <paramref name="pos"/> specifies the top left corner of the bounding box. If <paramref name="oversampling"/> is greater than zero, it is used as font oversampling factor, otherwise viewport oversampling settings are used.</para>
    /// </summary>
    /// <param name="color">If the parameter is null, then the default value is <c>new Color(1.0f, 1.0f, 1.0f, 1.0f)</c>.</param>
    public unsafe void DrawOutline(Rid canvas, Vector2 pos, int outlineSize = 1, Nullable<Color> color = null, float oversampling = 0.0f)
    {
        Color colorOrDefVal = color.HasValue ? color.Value : new Color(1.0f, 1.0f, 1.0f, 1.0f);
        NativeCalls.godot_icall_5_1321(MethodBind37, GodotObject.GetPtr(this), canvas, &pos, outlineSize, &colorOrDefVal, oversampling);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind38 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HitTest, 2401831903ul);

    /// <summary>
    /// <para>Returns caret character offset at the specified pixel offset at the baseline. This function always returns a valid position.</para>
    /// </summary>
    public int HitTest(float coords)
    {
        return NativeCalls.godot_icall_1_1322(MethodBind38, GodotObject.GetPtr(this), coords);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind39 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DrawOutline, 1343401456ul);

    /// <summary>
    /// <para>Draw text into a canvas item at a given position, with <paramref name="color"/>. <paramref name="pos"/> specifies the top left corner of the bounding box. If <paramref name="oversampling"/> is greater than zero, it is used as font oversampling factor, otherwise viewport oversampling settings are used.</para>
    /// </summary>
    /// <param name="color">If the parameter is null, then the default value is <c>new Color(1.0f, 1.0f, 1.0f, 1.0f)</c>.</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void DrawOutline(Rid canvas, Vector2 pos, int outlineSize, Nullable<Color> color)
    {
        Color colorOrDefVal = color.HasValue ? color.Value : new Color(1.0f, 1.0f, 1.0f, 1.0f);
        NativeCalls.godot_icall_4_1323(MethodBind39, GodotObject.GetPtr(this), canvas, &pos, outlineSize, &colorOrDefVal);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind40 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Draw, 856975658ul);

    /// <summary>
    /// <para>Draw text into a canvas item at a given position, with <paramref name="color"/>. <paramref name="pos"/> specifies the top left corner of the bounding box. If <paramref name="oversampling"/> is greater than zero, it is used as font oversampling factor, otherwise viewport oversampling settings are used.</para>
    /// </summary>
    /// <param name="color">If the parameter is null, then the default value is <c>new Color(1.0f, 1.0f, 1.0f, 1.0f)</c>.</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void Draw(Rid canvas, Vector2 pos, Nullable<Color> color)
    {
        Color colorOrDefVal = color.HasValue ? color.Value : new Color(1.0f, 1.0f, 1.0f, 1.0f);
        NativeCalls.godot_icall_3_1324(MethodBind40, GodotObject.GetPtr(this), canvas, &pos, &colorOrDefVal);
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
        /// Cached name for the 'width' property.
        /// </summary>
        public static readonly StringName Width = "width";
        /// <summary>
        /// Cached name for the 'alignment' property.
        /// </summary>
        public static readonly StringName Alignment = "alignment";
        /// <summary>
        /// Cached name for the 'flags' property.
        /// </summary>
        public static readonly StringName Flags = "flags";
        /// <summary>
        /// Cached name for the 'text_overrun_behavior' property.
        /// </summary>
        public static readonly StringName TextOverrunBehavior = "text_overrun_behavior";
        /// <summary>
        /// Cached name for the 'ellipsis_char' property.
        /// </summary>
        public static readonly StringName EllipsisChar = "ellipsis_char";
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
        /// Cached name for the 'set_width' method.
        /// </summary>
        public static readonly StringName SetWidth = "set_width";
        /// <summary>
        /// Cached name for the 'get_width' method.
        /// </summary>
        public static readonly StringName GetWidth = "get_width";
        /// <summary>
        /// Cached name for the 'set_horizontal_alignment' method.
        /// </summary>
        public static readonly StringName SetHorizontalAlignment = "set_horizontal_alignment";
        /// <summary>
        /// Cached name for the 'get_horizontal_alignment' method.
        /// </summary>
        public static readonly StringName GetHorizontalAlignment = "get_horizontal_alignment";
        /// <summary>
        /// Cached name for the 'tab_align' method.
        /// </summary>
        public static readonly StringName TabAlign = "tab_align";
        /// <summary>
        /// Cached name for the 'set_flags' method.
        /// </summary>
        public static readonly StringName SetFlags = "set_flags";
        /// <summary>
        /// Cached name for the 'get_flags' method.
        /// </summary>
        public static readonly StringName GetFlags = "get_flags";
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
        /// Cached name for the 'get_objects' method.
        /// </summary>
        public static readonly StringName GetObjects = "get_objects";
        /// <summary>
        /// Cached name for the 'get_object_rect' method.
        /// </summary>
        public static readonly StringName GetObjectRect = "get_object_rect";
        /// <summary>
        /// Cached name for the 'get_size' method.
        /// </summary>
        public static readonly StringName GetSize = "get_size";
        /// <summary>
        /// Cached name for the 'get_rid' method.
        /// </summary>
        public static readonly StringName GetRid = "get_rid";
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
        /// Cached name for the 'draw' method.
        /// </summary>
        public static readonly StringName Draw = "draw";
        /// <summary>
        /// Cached name for the 'draw_outline' method.
        /// </summary>
        public static readonly StringName DrawOutline = "draw_outline";
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
