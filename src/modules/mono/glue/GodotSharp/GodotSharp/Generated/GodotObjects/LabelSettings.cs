namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para><see cref="Godot.LabelSettings"/> is a resource that provides common settings to customize the text in a <see cref="Godot.Label"/>. It will take priority over the properties defined in <see cref="Godot.Control.Theme"/>. The resource can be shared between multiple labels and changed on the fly, so it's convenient and flexible way to setup text style.</para>
/// </summary>
public partial class LabelSettings : Resource
{
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
    /// <para>Vertical space between paragraphs. Added on top of <see cref="Godot.LabelSettings.LineSpacing"/>.</para>
    /// </summary>
    public float ParagraphSpacing
    {
        get
        {
            return GetParagraphSpacing();
        }
        set
        {
            SetParagraphSpacing(value);
        }
    }

    /// <summary>
    /// <para><see cref="Godot.Font"/> used for the text.</para>
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
    /// <para>Size of the text.</para>
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
    /// <para>Color of the text.</para>
    /// </summary>
    public Color FontColor
    {
        get
        {
            return GetFontColor();
        }
        set
        {
            SetFontColor(value);
        }
    }

    /// <summary>
    /// <para>Text outline size.</para>
    /// </summary>
    public int OutlineSize
    {
        get
        {
            return GetOutlineSize();
        }
        set
        {
            SetOutlineSize(value);
        }
    }

    /// <summary>
    /// <para>The color of the outline.</para>
    /// </summary>
    public Color OutlineColor
    {
        get
        {
            return GetOutlineColor();
        }
        set
        {
            SetOutlineColor(value);
        }
    }

    /// <summary>
    /// <para>Size of the shadow effect.</para>
    /// </summary>
    public int ShadowSize
    {
        get
        {
            return GetShadowSize();
        }
        set
        {
            SetShadowSize(value);
        }
    }

    /// <summary>
    /// <para>Color of the shadow effect. If alpha is <c>0</c>, no shadow will be drawn.</para>
    /// </summary>
    public Color ShadowColor
    {
        get
        {
            return GetShadowColor();
        }
        set
        {
            SetShadowColor(value);
        }
    }

    /// <summary>
    /// <para>Offset of the shadow effect, in pixels.</para>
    /// </summary>
    public Vector2 ShadowOffset
    {
        get
        {
            return GetShadowOffset();
        }
        set
        {
            SetShadowOffset(value);
        }
    }

    /// <summary>
    /// <para>The number of stacked outlines.</para>
    /// </summary>
    public int StackedOutlineCount
    {
        get
        {
            return GetStackedOutlineCount();
        }
        set
        {
            SetStackedOutlineCount(value);
        }
    }

    /// <summary>
    /// <para>The number of stacked shadows.</para>
    /// </summary>
    public int StackedShadowCount
    {
        get
        {
            return GetStackedShadowCount();
        }
        set
        {
            SetStackedShadowCount(value);
        }
    }

    private static readonly System.Type CachedType = typeof(LabelSettings);

    private static readonly StringName NativeName = "LabelSettings";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public LabelSettings() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal LabelSettings(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal LabelSettings(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLineSpacing, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetLineSpacing(float spacing)
    {
        NativeCalls.godot_icall_1_67(MethodBind0, GodotObject.GetPtr(this), spacing);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLineSpacing, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetLineSpacing()
    {
        return NativeCalls.godot_icall_0_68(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetParagraphSpacing, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetParagraphSpacing(float spacing)
    {
        NativeCalls.godot_icall_1_67(MethodBind2, GodotObject.GetPtr(this), spacing);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetParagraphSpacing, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetParagraphSpacing()
    {
        return NativeCalls.godot_icall_0_68(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFont, 1262170328ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFont(Font font)
    {
        NativeCalls.godot_icall_1_56(MethodBind4, GodotObject.GetPtr(this), GodotObject.GetPtr(font));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFont, 3229501585ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Font GetFont()
    {
        return (Font)NativeCalls.godot_icall_0_63(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFontSize, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFontSize(int size)
    {
        NativeCalls.godot_icall_1_38(MethodBind6, GodotObject.GetPtr(this), size);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFontSize, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetFontSize()
    {
        return NativeCalls.godot_icall_0_39(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFontColor, 2920490490ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetFontColor(Color color)
    {
        NativeCalls.godot_icall_1_213(MethodBind8, GodotObject.GetPtr(this), &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFontColor, 3444240500ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Color GetFontColor()
    {
        return NativeCalls.godot_icall_0_214(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetOutlineSize, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetOutlineSize(int size)
    {
        NativeCalls.godot_icall_1_38(MethodBind10, GodotObject.GetPtr(this), size);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOutlineSize, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetOutlineSize()
    {
        return NativeCalls.godot_icall_0_39(MethodBind11, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetOutlineColor, 2920490490ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetOutlineColor(Color color)
    {
        NativeCalls.godot_icall_1_213(MethodBind12, GodotObject.GetPtr(this), &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOutlineColor, 3444240500ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Color GetOutlineColor()
    {
        return NativeCalls.godot_icall_0_214(MethodBind13, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetShadowSize, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetShadowSize(int size)
    {
        NativeCalls.godot_icall_1_38(MethodBind14, GodotObject.GetPtr(this), size);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetShadowSize, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetShadowSize()
    {
        return NativeCalls.godot_icall_0_39(MethodBind15, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetShadowColor, 2920490490ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetShadowColor(Color color)
    {
        NativeCalls.godot_icall_1_213(MethodBind16, GodotObject.GetPtr(this), &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetShadowColor, 3444240500ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Color GetShadowColor()
    {
        return NativeCalls.godot_icall_0_214(MethodBind17, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetShadowOffset, 743155724ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetShadowOffset(Vector2 offset)
    {
        NativeCalls.godot_icall_1_36(MethodBind18, GodotObject.GetPtr(this), &offset);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetShadowOffset, 3341600327ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2 GetShadowOffset()
    {
        return NativeCalls.godot_icall_0_37(MethodBind19, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetStackedOutlineCount, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetStackedOutlineCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind20, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetStackedOutlineCount, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetStackedOutlineCount(int count)
    {
        NativeCalls.godot_icall_1_38(MethodBind21, GodotObject.GetPtr(this), count);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddStackedOutline, 1025054187ul);

    /// <summary>
    /// <para>Adds a new stacked outline to the label at the given <paramref name="index"/>. If <paramref name="index"/> is <c>-1</c>, the new stacked outline will be added at the end of the list.</para>
    /// </summary>
    public void AddStackedOutline(int index = -1)
    {
        NativeCalls.godot_icall_1_38(MethodBind22, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MoveStackedOutline, 3937882851ul);

    /// <summary>
    /// <para>Moves the stacked outline at index <paramref name="fromIndex"/> to the given position <paramref name="toPosition"/> in the array.</para>
    /// </summary>
    public void MoveStackedOutline(int fromIndex, int toPosition)
    {
        NativeCalls.godot_icall_2_59(MethodBind23, GodotObject.GetPtr(this), fromIndex, toPosition);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveStackedOutline, 1286410249ul);

    /// <summary>
    /// <para>Removes the stacked outline at index <paramref name="index"/>.</para>
    /// </summary>
    public void RemoveStackedOutline(int index)
    {
        NativeCalls.godot_icall_1_38(MethodBind24, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetStackedOutlineSize, 3937882851ul);

    /// <summary>
    /// <para>Sets the size of the stacked outline identified by the given <paramref name="index"/> to <paramref name="size"/>.</para>
    /// </summary>
    public void SetStackedOutlineSize(int index, int size)
    {
        NativeCalls.godot_icall_2_59(MethodBind25, GodotObject.GetPtr(this), index, size);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetStackedOutlineSize, 923996154ul);

    /// <summary>
    /// <para>Returns the size of the stacked outline at <paramref name="index"/>.</para>
    /// </summary>
    public int GetStackedOutlineSize(int index)
    {
        return NativeCalls.godot_icall_1_60(MethodBind26, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetStackedOutlineColor, 2878471219ul);

    /// <summary>
    /// <para>Sets the color of the stacked outline identified by the given <paramref name="index"/> to <paramref name="color"/>.</para>
    /// </summary>
    public unsafe void SetStackedOutlineColor(int index, Color color)
    {
        NativeCalls.godot_icall_2_687(MethodBind27, GodotObject.GetPtr(this), index, &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetStackedOutlineColor, 3457211756ul);

    /// <summary>
    /// <para>Returns the color of the stacked outline at <paramref name="index"/>.</para>
    /// </summary>
    public Color GetStackedOutlineColor(int index)
    {
        return NativeCalls.godot_icall_1_688(MethodBind28, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetStackedShadowCount, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetStackedShadowCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind29, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetStackedShadowCount, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetStackedShadowCount(int count)
    {
        NativeCalls.godot_icall_1_38(MethodBind30, GodotObject.GetPtr(this), count);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddStackedShadow, 1025054187ul);

    /// <summary>
    /// <para>Adds a new stacked shadow to the label at the given <paramref name="index"/>. If <paramref name="index"/> is <c>-1</c>, the new stacked shadow will be added at the end of the list.</para>
    /// </summary>
    public void AddStackedShadow(int index = -1)
    {
        NativeCalls.godot_icall_1_38(MethodBind31, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind32 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MoveStackedShadow, 3937882851ul);

    /// <summary>
    /// <para>Moves the stacked shadow at index <paramref name="fromIndex"/> to the given position <paramref name="toPosition"/> in the array.</para>
    /// </summary>
    public void MoveStackedShadow(int fromIndex, int toPosition)
    {
        NativeCalls.godot_icall_2_59(MethodBind32, GodotObject.GetPtr(this), fromIndex, toPosition);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind33 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveStackedShadow, 1286410249ul);

    /// <summary>
    /// <para>Removes the stacked shadow at index <paramref name="index"/>.</para>
    /// </summary>
    public void RemoveStackedShadow(int index)
    {
        NativeCalls.godot_icall_1_38(MethodBind33, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind34 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetStackedShadowOffset, 163021252ul);

    /// <summary>
    /// <para>Sets the offset of the stacked shadow identified by the given <paramref name="index"/> to <paramref name="offset"/>.</para>
    /// </summary>
    public unsafe void SetStackedShadowOffset(int index, Vector2 offset)
    {
        NativeCalls.godot_icall_2_147(MethodBind34, GodotObject.GetPtr(this), index, &offset);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind35 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetStackedShadowOffset, 2299179447ul);

    /// <summary>
    /// <para>Returns the offset of the stacked shadow at <paramref name="index"/>.</para>
    /// </summary>
    public Vector2 GetStackedShadowOffset(int index)
    {
        return NativeCalls.godot_icall_1_148(MethodBind35, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind36 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetStackedShadowColor, 2878471219ul);

    /// <summary>
    /// <para>Sets the color of the stacked shadow identified by the given <paramref name="index"/> to <paramref name="color"/>.</para>
    /// </summary>
    public unsafe void SetStackedShadowColor(int index, Color color)
    {
        NativeCalls.godot_icall_2_687(MethodBind36, GodotObject.GetPtr(this), index, &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind37 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetStackedShadowColor, 3457211756ul);

    /// <summary>
    /// <para>Returns the color of the stacked shadow at <paramref name="index"/>.</para>
    /// </summary>
    public Color GetStackedShadowColor(int index)
    {
        return NativeCalls.godot_icall_1_688(MethodBind37, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind38 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetStackedShadowOutlineSize, 3937882851ul);

    /// <summary>
    /// <para>Sets the outline size of the stacked shadow identified by the given <paramref name="index"/> to <paramref name="size"/>.</para>
    /// </summary>
    public void SetStackedShadowOutlineSize(int index, int size)
    {
        NativeCalls.godot_icall_2_59(MethodBind38, GodotObject.GetPtr(this), index, size);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind39 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetStackedShadowOutlineSize, 923996154ul);

    /// <summary>
    /// <para>Returns the outline size of the stacked shadow at <paramref name="index"/>.</para>
    /// </summary>
    public int GetStackedShadowOutlineSize(int index)
    {
        return NativeCalls.godot_icall_1_60(MethodBind39, GodotObject.GetPtr(this), index);
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
        /// Cached name for the 'line_spacing' property.
        /// </summary>
        public static readonly StringName LineSpacing = "line_spacing";
        /// <summary>
        /// Cached name for the 'paragraph_spacing' property.
        /// </summary>
        public static readonly StringName ParagraphSpacing = "paragraph_spacing";
        /// <summary>
        /// Cached name for the 'font' property.
        /// </summary>
        public static readonly StringName Font = "font";
        /// <summary>
        /// Cached name for the 'font_size' property.
        /// </summary>
        public static readonly StringName FontSize = "font_size";
        /// <summary>
        /// Cached name for the 'font_color' property.
        /// </summary>
        public static readonly StringName FontColor = "font_color";
        /// <summary>
        /// Cached name for the 'outline_size' property.
        /// </summary>
        public static readonly StringName OutlineSize = "outline_size";
        /// <summary>
        /// Cached name for the 'outline_color' property.
        /// </summary>
        public static readonly StringName OutlineColor = "outline_color";
        /// <summary>
        /// Cached name for the 'shadow_size' property.
        /// </summary>
        public static readonly StringName ShadowSize = "shadow_size";
        /// <summary>
        /// Cached name for the 'shadow_color' property.
        /// </summary>
        public static readonly StringName ShadowColor = "shadow_color";
        /// <summary>
        /// Cached name for the 'shadow_offset' property.
        /// </summary>
        public static readonly StringName ShadowOffset = "shadow_offset";
        /// <summary>
        /// Cached name for the 'stacked_outline_count' property.
        /// </summary>
        public static readonly StringName StackedOutlineCount = "stacked_outline_count";
        /// <summary>
        /// Cached name for the 'stacked_shadow_count' property.
        /// </summary>
        public static readonly StringName StackedShadowCount = "stacked_shadow_count";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Resource.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_line_spacing' method.
        /// </summary>
        public static readonly StringName SetLineSpacing = "set_line_spacing";
        /// <summary>
        /// Cached name for the 'get_line_spacing' method.
        /// </summary>
        public static readonly StringName GetLineSpacing = "get_line_spacing";
        /// <summary>
        /// Cached name for the 'set_paragraph_spacing' method.
        /// </summary>
        public static readonly StringName SetParagraphSpacing = "set_paragraph_spacing";
        /// <summary>
        /// Cached name for the 'get_paragraph_spacing' method.
        /// </summary>
        public static readonly StringName GetParagraphSpacing = "get_paragraph_spacing";
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
        /// Cached name for the 'set_font_color' method.
        /// </summary>
        public static readonly StringName SetFontColor = "set_font_color";
        /// <summary>
        /// Cached name for the 'get_font_color' method.
        /// </summary>
        public static readonly StringName GetFontColor = "get_font_color";
        /// <summary>
        /// Cached name for the 'set_outline_size' method.
        /// </summary>
        public static readonly StringName SetOutlineSize = "set_outline_size";
        /// <summary>
        /// Cached name for the 'get_outline_size' method.
        /// </summary>
        public static readonly StringName GetOutlineSize = "get_outline_size";
        /// <summary>
        /// Cached name for the 'set_outline_color' method.
        /// </summary>
        public static readonly StringName SetOutlineColor = "set_outline_color";
        /// <summary>
        /// Cached name for the 'get_outline_color' method.
        /// </summary>
        public static readonly StringName GetOutlineColor = "get_outline_color";
        /// <summary>
        /// Cached name for the 'set_shadow_size' method.
        /// </summary>
        public static readonly StringName SetShadowSize = "set_shadow_size";
        /// <summary>
        /// Cached name for the 'get_shadow_size' method.
        /// </summary>
        public static readonly StringName GetShadowSize = "get_shadow_size";
        /// <summary>
        /// Cached name for the 'set_shadow_color' method.
        /// </summary>
        public static readonly StringName SetShadowColor = "set_shadow_color";
        /// <summary>
        /// Cached name for the 'get_shadow_color' method.
        /// </summary>
        public static readonly StringName GetShadowColor = "get_shadow_color";
        /// <summary>
        /// Cached name for the 'set_shadow_offset' method.
        /// </summary>
        public static readonly StringName SetShadowOffset = "set_shadow_offset";
        /// <summary>
        /// Cached name for the 'get_shadow_offset' method.
        /// </summary>
        public static readonly StringName GetShadowOffset = "get_shadow_offset";
        /// <summary>
        /// Cached name for the 'get_stacked_outline_count' method.
        /// </summary>
        public static readonly StringName GetStackedOutlineCount = "get_stacked_outline_count";
        /// <summary>
        /// Cached name for the 'set_stacked_outline_count' method.
        /// </summary>
        public static readonly StringName SetStackedOutlineCount = "set_stacked_outline_count";
        /// <summary>
        /// Cached name for the 'add_stacked_outline' method.
        /// </summary>
        public static readonly StringName AddStackedOutline = "add_stacked_outline";
        /// <summary>
        /// Cached name for the 'move_stacked_outline' method.
        /// </summary>
        public static readonly StringName MoveStackedOutline = "move_stacked_outline";
        /// <summary>
        /// Cached name for the 'remove_stacked_outline' method.
        /// </summary>
        public static readonly StringName RemoveStackedOutline = "remove_stacked_outline";
        /// <summary>
        /// Cached name for the 'set_stacked_outline_size' method.
        /// </summary>
        public static readonly StringName SetStackedOutlineSize = "set_stacked_outline_size";
        /// <summary>
        /// Cached name for the 'get_stacked_outline_size' method.
        /// </summary>
        public static readonly StringName GetStackedOutlineSize = "get_stacked_outline_size";
        /// <summary>
        /// Cached name for the 'set_stacked_outline_color' method.
        /// </summary>
        public static readonly StringName SetStackedOutlineColor = "set_stacked_outline_color";
        /// <summary>
        /// Cached name for the 'get_stacked_outline_color' method.
        /// </summary>
        public static readonly StringName GetStackedOutlineColor = "get_stacked_outline_color";
        /// <summary>
        /// Cached name for the 'get_stacked_shadow_count' method.
        /// </summary>
        public static readonly StringName GetStackedShadowCount = "get_stacked_shadow_count";
        /// <summary>
        /// Cached name for the 'set_stacked_shadow_count' method.
        /// </summary>
        public static readonly StringName SetStackedShadowCount = "set_stacked_shadow_count";
        /// <summary>
        /// Cached name for the 'add_stacked_shadow' method.
        /// </summary>
        public static readonly StringName AddStackedShadow = "add_stacked_shadow";
        /// <summary>
        /// Cached name for the 'move_stacked_shadow' method.
        /// </summary>
        public static readonly StringName MoveStackedShadow = "move_stacked_shadow";
        /// <summary>
        /// Cached name for the 'remove_stacked_shadow' method.
        /// </summary>
        public static readonly StringName RemoveStackedShadow = "remove_stacked_shadow";
        /// <summary>
        /// Cached name for the 'set_stacked_shadow_offset' method.
        /// </summary>
        public static readonly StringName SetStackedShadowOffset = "set_stacked_shadow_offset";
        /// <summary>
        /// Cached name for the 'get_stacked_shadow_offset' method.
        /// </summary>
        public static readonly StringName GetStackedShadowOffset = "get_stacked_shadow_offset";
        /// <summary>
        /// Cached name for the 'set_stacked_shadow_color' method.
        /// </summary>
        public static readonly StringName SetStackedShadowColor = "set_stacked_shadow_color";
        /// <summary>
        /// Cached name for the 'get_stacked_shadow_color' method.
        /// </summary>
        public static readonly StringName GetStackedShadowColor = "get_stacked_shadow_color";
        /// <summary>
        /// Cached name for the 'set_stacked_shadow_outline_size' method.
        /// </summary>
        public static readonly StringName SetStackedShadowOutlineSize = "set_stacked_shadow_outline_size";
        /// <summary>
        /// Cached name for the 'get_stacked_shadow_outline_size' method.
        /// </summary>
        public static readonly StringName GetStackedShadowOutlineSize = "get_stacked_shadow_outline_size";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Resource.SignalName
    {
    }
}
