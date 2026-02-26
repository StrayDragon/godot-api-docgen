namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Generate a <see cref="Godot.PrimitiveMesh"/> from the text.</para>
/// <para>TextMesh can be generated only when using dynamic fonts with vector glyph contours. Bitmap fonts (including bitmap data in the TrueType/OpenType containers, like color emoji fonts) are not supported.</para>
/// <para>The UV layout is arranged in 4 horizontal strips, top to bottom: 40% of the height for the front face, 40% for the back face, 10% for the outer edges and 10% for the inner edges.</para>
/// </summary>
public partial class TextMesh : PrimitiveMesh
{
    /// <summary>
    /// <para>The text to generate mesh from.</para>
    /// <para><b>Note:</b> Due to being a <see cref="Godot.Resource"/>, it doesn't follow the rules of <see cref="Godot.Node.AutoTranslateMode"/>. If disabling translation is desired, it should be done manually with <see cref="Godot.GodotObject.SetMessageTranslation(bool)"/>.</para>
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
    /// <para>Font configuration used to display text.</para>
    /// </summary>
    public Font Font
    {
        get
        {
            return GetFont();
        }
        set
        {
            SetFont(value);
        }
    }

    /// <summary>
    /// <para>Font size of the <see cref="Godot.TextMesh"/>'s text. This property works in tandem with <see cref="Godot.TextMesh.PixelSize"/>. Higher values will result in a more detailed font, regardless of <see cref="Godot.TextMesh.CurveStep"/> and <see cref="Godot.TextMesh.PixelSize"/>. Consider keeping this value below 63 (inclusive) for good performance, and adjust <see cref="Godot.TextMesh.PixelSize"/> as needed to enlarge text.</para>
    /// <para><b>Note:</b> Changing this property will regenerate the mesh, which is a slow operation, especially with large font sizes and long texts. To change the text's size in real-time efficiently, change the node's <see cref="Godot.Node3D.Scale"/> instead.</para>
    /// </summary>
    public int FontSize
    {
        get
        {
            return GetFontSize();
        }
        set
        {
            SetFontSize(value);
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
    /// <para>Controls the text's vertical alignment. Supports top, center, and bottom.</para>
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
    /// <para>The size of one pixel's width on the text to scale it in 3D. This property works in tandem with <see cref="Godot.TextMesh.FontSize"/>.</para>
    /// <para><b>Note:</b> Changing this property will regenerate the mesh, which is a slow operation, especially with large font sizes and long texts. To change the text's size in real-time efficiently, change the node's <see cref="Godot.Node3D.Scale"/> instead.</para>
    /// </summary>
    public float PixelSize
    {
        get
        {
            return GetPixelSize();
        }
        set
        {
            SetPixelSize(value);
        }
    }

    /// <summary>
    /// <para>Step (in pixels) used to approximate Bézier curves. Lower values result in smoother curves, but is slower to generate and render. Consider adjusting this according to the font size and the typical viewing distance.</para>
    /// <para><b>Note:</b> Changing this property will regenerate the mesh, which is a slow operation, especially with large font sizes and long texts.</para>
    /// </summary>
    public float CurveStep
    {
        get
        {
            return GetCurveStep();
        }
        set
        {
            SetCurveStep(value);
        }
    }

    /// <summary>
    /// <para>Depths of the mesh, if set to <c>0.0</c> only front surface, is generated, and UV layout is changed to use full texture for the front face only.</para>
    /// </summary>
    public float Depth
    {
        get
        {
            return GetDepth();
        }
        set
        {
            SetDepth(value);
        }
    }

    /// <summary>
    /// <para>Text width (in pixels), used for fill alignment.</para>
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
    /// <para>The text drawing offset (in pixels).</para>
    /// <para><b>Note:</b> Changing this property will regenerate the mesh, which is a slow operation. To change the text's position in real-time efficiently, change the node's <see cref="Godot.Node3D.Position"/> instead.</para>
    /// </summary>
    public Vector2 Offset
    {
        get
        {
            return GetOffset();
        }
        set
        {
            SetOffset(value);
        }
    }

    /// <summary>
    /// <para>Base text writing direction.</para>
    /// </summary>
    public TextServer.Direction TextDirection
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

    private static readonly System.Type CachedType = typeof(TextMesh);

    private static readonly StringName NativeName = "TextMesh";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public TextMesh() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal TextMesh(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal TextMesh(bool memoryOwn) : base(memoryOwn) { }

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
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFont, 1262170328ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFont(Font font)
    {
        NativeCalls.godot_icall_1_56(MethodBind6, GodotObject.GetPtr(this), GodotObject.GetPtr(font));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFont, 3229501585ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Font GetFont()
    {
        return (Font)NativeCalls.godot_icall_0_63(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFontSize, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFontSize(int fontSize)
    {
        NativeCalls.godot_icall_1_38(MethodBind8, GodotObject.GetPtr(this), fontSize);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFontSize, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetFontSize()
    {
        return NativeCalls.godot_icall_0_39(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLineSpacing, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetLineSpacing(float lineSpacing)
    {
        NativeCalls.godot_icall_1_67(MethodBind10, GodotObject.GetPtr(this), lineSpacing);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLineSpacing, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetLineSpacing()
    {
        return NativeCalls.godot_icall_0_68(MethodBind11, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAutowrapMode, 3289138044ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAutowrapMode(TextServer.AutowrapMode autowrapMode)
    {
        NativeCalls.godot_icall_1_38(MethodBind12, GodotObject.GetPtr(this), (int)autowrapMode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAutowrapMode, 1549071663ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public TextServer.AutowrapMode GetAutowrapMode()
    {
        return (TextServer.AutowrapMode)NativeCalls.godot_icall_0_39(MethodBind13, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetJustificationFlags, 2877345813ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetJustificationFlags(TextServer.JustificationFlag justificationFlags)
    {
        NativeCalls.godot_icall_1_38(MethodBind14, GodotObject.GetPtr(this), (int)justificationFlags);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetJustificationFlags, 1583363614ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public TextServer.JustificationFlag GetJustificationFlags()
    {
        return (TextServer.JustificationFlag)NativeCalls.godot_icall_0_39(MethodBind15, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDepth, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDepth(float depth)
    {
        NativeCalls.godot_icall_1_67(MethodBind16, GodotObject.GetPtr(this), depth);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDepth, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetDepth()
    {
        return NativeCalls.godot_icall_0_68(MethodBind17, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetWidth, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetWidth(float width)
    {
        NativeCalls.godot_icall_1_67(MethodBind18, GodotObject.GetPtr(this), width);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetWidth, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetWidth()
    {
        return NativeCalls.godot_icall_0_68(MethodBind19, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPixelSize, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPixelSize(float pixelSize)
    {
        NativeCalls.godot_icall_1_67(MethodBind20, GodotObject.GetPtr(this), pixelSize);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPixelSize, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetPixelSize()
    {
        return NativeCalls.godot_icall_0_68(MethodBind21, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetOffset, 743155724ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetOffset(Vector2 offset)
    {
        NativeCalls.godot_icall_1_36(MethodBind22, GodotObject.GetPtr(this), &offset);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOffset, 3341600327ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2 GetOffset()
    {
        return NativeCalls.godot_icall_0_37(MethodBind23, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCurveStep, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCurveStep(float curveStep)
    {
        NativeCalls.godot_icall_1_67(MethodBind24, GodotObject.GetPtr(this), curveStep);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCurveStep, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetCurveStep()
    {
        return NativeCalls.godot_icall_0_68(MethodBind25, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTextDirection, 1418190634ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTextDirection(TextServer.Direction direction)
    {
        NativeCalls.godot_icall_1_38(MethodBind26, GodotObject.GetPtr(this), (int)direction);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTextDirection, 2516697328ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public TextServer.Direction GetTextDirection()
    {
        return (TextServer.Direction)NativeCalls.godot_icall_0_39(MethodBind27, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLanguage, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetLanguage(string language)
    {
        NativeCalls.godot_icall_1_57(MethodBind28, GodotObject.GetPtr(this), language);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLanguage, 201670096ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetLanguage()
    {
        return NativeCalls.godot_icall_0_58(MethodBind29, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetStructuredTextBidiOverride, 55961453ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetStructuredTextBidiOverride(TextServer.StructuredTextParser parser)
    {
        NativeCalls.godot_icall_1_38(MethodBind30, GodotObject.GetPtr(this), (int)parser);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetStructuredTextBidiOverride, 3385126229ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public TextServer.StructuredTextParser GetStructuredTextBidiOverride()
    {
        return (TextServer.StructuredTextParser)NativeCalls.godot_icall_0_39(MethodBind31, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind32 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetStructuredTextBidiOverrideOptions, 381264803ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetStructuredTextBidiOverrideOptions(Godot.Collections.Array args)
    {
        NativeCalls.godot_icall_1_138(MethodBind32, GodotObject.GetPtr(this), (godot_array)(args ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind33 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetStructuredTextBidiOverrideOptions, 3995934104ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Godot.Collections.Array GetStructuredTextBidiOverrideOptions()
    {
        return NativeCalls.godot_icall_0_120(MethodBind33, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind34 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetUppercase, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetUppercase(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind34, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind35 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsUppercase, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsUppercase()
    {
        return NativeCalls.godot_icall_0_15(MethodBind35, GodotObject.GetPtr(this)).ToBool();
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
    public new class PropertyName : PrimitiveMesh.PropertyName
    {
        /// <summary>
        /// Cached name for the 'text' property.
        /// </summary>
        public static readonly StringName Text = "text";
        /// <summary>
        /// Cached name for the 'font' property.
        /// </summary>
        public static readonly StringName Font = "font";
        /// <summary>
        /// Cached name for the 'font_size' property.
        /// </summary>
        public static readonly StringName FontSize = "font_size";
        /// <summary>
        /// Cached name for the 'horizontal_alignment' property.
        /// </summary>
        public static readonly StringName HorizontalAlignment = "horizontal_alignment";
        /// <summary>
        /// Cached name for the 'vertical_alignment' property.
        /// </summary>
        public static readonly StringName VerticalAlignment = "vertical_alignment";
        /// <summary>
        /// Cached name for the 'uppercase' property.
        /// </summary>
        public static readonly StringName Uppercase = "uppercase";
        /// <summary>
        /// Cached name for the 'line_spacing' property.
        /// </summary>
        public static readonly StringName LineSpacing = "line_spacing";
        /// <summary>
        /// Cached name for the 'autowrap_mode' property.
        /// </summary>
        public static readonly StringName AutowrapMode = "autowrap_mode";
        /// <summary>
        /// Cached name for the 'justification_flags' property.
        /// </summary>
        public static readonly StringName JustificationFlags = "justification_flags";
        /// <summary>
        /// Cached name for the 'pixel_size' property.
        /// </summary>
        public static readonly StringName PixelSize = "pixel_size";
        /// <summary>
        /// Cached name for the 'curve_step' property.
        /// </summary>
        public static readonly StringName CurveStep = "curve_step";
        /// <summary>
        /// Cached name for the 'depth' property.
        /// </summary>
        public static readonly StringName Depth = "depth";
        /// <summary>
        /// Cached name for the 'width' property.
        /// </summary>
        public static readonly StringName Width = "width";
        /// <summary>
        /// Cached name for the 'offset' property.
        /// </summary>
        public static readonly StringName Offset = "offset";
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
    public new class MethodName : PrimitiveMesh.MethodName
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
        /// Cached name for the 'set_font' method.
        /// </summary>
        public static readonly StringName SetFont = "set_font";
        /// <summary>
        /// Cached name for the 'get_font' method.
        /// </summary>
        public static readonly StringName GetFont = "get_font";
        /// <summary>
        /// Cached name for the 'set_font_size' method.
        /// </summary>
        public static readonly StringName SetFontSize = "set_font_size";
        /// <summary>
        /// Cached name for the 'get_font_size' method.
        /// </summary>
        public static readonly StringName GetFontSize = "get_font_size";
        /// <summary>
        /// Cached name for the 'set_line_spacing' method.
        /// </summary>
        public static readonly StringName SetLineSpacing = "set_line_spacing";
        /// <summary>
        /// Cached name for the 'get_line_spacing' method.
        /// </summary>
        public static readonly StringName GetLineSpacing = "get_line_spacing";
        /// <summary>
        /// Cached name for the 'set_autowrap_mode' method.
        /// </summary>
        public static readonly StringName SetAutowrapMode = "set_autowrap_mode";
        /// <summary>
        /// Cached name for the 'get_autowrap_mode' method.
        /// </summary>
        public static readonly StringName GetAutowrapMode = "get_autowrap_mode";
        /// <summary>
        /// Cached name for the 'set_justification_flags' method.
        /// </summary>
        public static readonly StringName SetJustificationFlags = "set_justification_flags";
        /// <summary>
        /// Cached name for the 'get_justification_flags' method.
        /// </summary>
        public static readonly StringName GetJustificationFlags = "get_justification_flags";
        /// <summary>
        /// Cached name for the 'set_depth' method.
        /// </summary>
        public static readonly StringName SetDepth = "set_depth";
        /// <summary>
        /// Cached name for the 'get_depth' method.
        /// </summary>
        public static readonly StringName GetDepth = "get_depth";
        /// <summary>
        /// Cached name for the 'set_width' method.
        /// </summary>
        public static readonly StringName SetWidth = "set_width";
        /// <summary>
        /// Cached name for the 'get_width' method.
        /// </summary>
        public static readonly StringName GetWidth = "get_width";
        /// <summary>
        /// Cached name for the 'set_pixel_size' method.
        /// </summary>
        public static readonly StringName SetPixelSize = "set_pixel_size";
        /// <summary>
        /// Cached name for the 'get_pixel_size' method.
        /// </summary>
        public static readonly StringName GetPixelSize = "get_pixel_size";
        /// <summary>
        /// Cached name for the 'set_offset' method.
        /// </summary>
        public static readonly StringName SetOffset = "set_offset";
        /// <summary>
        /// Cached name for the 'get_offset' method.
        /// </summary>
        public static readonly StringName GetOffset = "get_offset";
        /// <summary>
        /// Cached name for the 'set_curve_step' method.
        /// </summary>
        public static readonly StringName SetCurveStep = "set_curve_step";
        /// <summary>
        /// Cached name for the 'get_curve_step' method.
        /// </summary>
        public static readonly StringName GetCurveStep = "get_curve_step";
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
        /// Cached name for the 'set_uppercase' method.
        /// </summary>
        public static readonly StringName SetUppercase = "set_uppercase";
        /// <summary>
        /// Cached name for the 'is_uppercase' method.
        /// </summary>
        public static readonly StringName IsUppercase = "is_uppercase";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : PrimitiveMesh.SignalName
    {
    }
}
