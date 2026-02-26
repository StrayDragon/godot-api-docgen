namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para><see cref="Godot.Button"/> is the standard themed button. It can contain text and an icon, and it will display them according to the current <see cref="Godot.Theme"/>.</para>
/// <para><b>Example:</b> Create a button and connect a method that will be called when the button is pressed:</para>
/// <para><code>
/// public override void _Ready()
/// {
/// 	var button = new Button();
/// 	button.Text = "Click me";
/// 	button.Pressed += ButtonPressed;
/// 	AddChild(button);
/// }
/// 
/// private void ButtonPressed()
/// {
/// 	GD.Print("Hello world!");
/// }
/// </code></para>
/// <para>See also <see cref="Godot.BaseButton"/> which contains common properties and methods associated with this node.</para>
/// <para><b>Note:</b> Buttons do not detect touch input and therefore don't support multitouch, since mouse emulation can only press one button at a given time. Use <see cref="Godot.TouchScreenButton"/> for buttons that trigger gameplay movement or actions.</para>
/// </summary>
public partial class Button : BaseButton
{
    /// <summary>
    /// <para>The button's text that will be displayed inside the button's area.</para>
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
    /// <para>Button's icon, if text is present the icon will be placed before the text.</para>
    /// <para>To edit margin and spacing of the icon, use <c>h_separation</c> theme property and <c>content_margin_*</c> properties of the used <see cref="Godot.StyleBox"/>es.</para>
    /// </summary>
    public Texture2D Icon
    {
        get
        {
            return GetButtonIcon();
        }
        set
        {
            SetButtonIcon(value);
        }
    }

    /// <summary>
    /// <para>Flat buttons don't display decoration.</para>
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
    /// <para>Text alignment policy for the button's text.</para>
    /// </summary>
    public HorizontalAlignment Alignment
    {
        get
        {
            return GetTextAlignment();
        }
        set
        {
            SetTextAlignment(value);
        }
    }

    /// <summary>
    /// <para>Sets the clipping behavior when the text exceeds the node's bounding rectangle.</para>
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
    /// <para>If <see langword="true"/>, text that is too large to fit the button is clipped horizontally. If <see langword="false"/>, the button will always be wide enough to hold the text. The text is not vertically clipped, and the button's height is not affected by this property.</para>
    /// </summary>
    public bool ClipText
    {
        get
        {
            return GetClipText();
        }
        set
        {
            SetClipText(value);
        }
    }

    /// <summary>
    /// <para>Specifies if the icon should be aligned horizontally to the left, right, or center of a button. Uses the same <see cref="Godot.HorizontalAlignment"/> constants as the text alignment. If centered horizontally and vertically, text will draw on top of the icon.</para>
    /// </summary>
    public HorizontalAlignment IconAlignment
    {
        get
        {
            return GetIconAlignment();
        }
        set
        {
            SetIconAlignment(value);
        }
    }

    /// <summary>
    /// <para>Specifies if the icon should be aligned vertically to the top, bottom, or center of a button. Uses the same <see cref="Godot.VerticalAlignment"/> constants as the text alignment. If centered horizontally and vertically, text will draw on top of the icon.</para>
    /// </summary>
    public VerticalAlignment VerticalIconAlignment
    {
        get
        {
            return GetVerticalIconAlignment();
        }
        set
        {
            SetVerticalIconAlignment(value);
        }
    }

    /// <summary>
    /// <para>When enabled, the button's icon will expand/shrink to fit the button's size while keeping its aspect. See also <c>icon_max_width</c>.</para>
    /// </summary>
    public bool ExpandIcon
    {
        get
        {
            return IsExpandIcon();
        }
        set
        {
            SetExpandIcon(value);
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

    private static readonly System.Type CachedType = typeof(Button);

    private static readonly StringName NativeName = "Button";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public Button() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal Button(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal Button(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetText, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetText(string text)
    {
        NativeCalls.godot_icall_1_57(MethodBind0, GodotObject.GetPtr(this), text);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetText, 201670096ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetText()
    {
        return NativeCalls.godot_icall_0_58(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTextOverrunBehavior, 1008890932ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTextOverrunBehavior(TextServer.OverrunBehavior overrunBehavior)
    {
        NativeCalls.godot_icall_1_38(MethodBind2, GodotObject.GetPtr(this), (int)overrunBehavior);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTextOverrunBehavior, 3779142101ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public TextServer.OverrunBehavior GetTextOverrunBehavior()
    {
        return (TextServer.OverrunBehavior)NativeCalls.godot_icall_0_39(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAutowrapMode, 3289138044ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAutowrapMode(TextServer.AutowrapMode autowrapMode)
    {
        NativeCalls.godot_icall_1_38(MethodBind4, GodotObject.GetPtr(this), (int)autowrapMode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAutowrapMode, 1549071663ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public TextServer.AutowrapMode GetAutowrapMode()
    {
        return (TextServer.AutowrapMode)NativeCalls.godot_icall_0_39(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAutowrapTrimFlags, 2809697122ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAutowrapTrimFlags(TextServer.LineBreakFlag autowrapTrimFlags)
    {
        NativeCalls.godot_icall_1_38(MethodBind6, GodotObject.GetPtr(this), (int)autowrapTrimFlags);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAutowrapTrimFlags, 2340632602ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public TextServer.LineBreakFlag GetAutowrapTrimFlags()
    {
        return (TextServer.LineBreakFlag)NativeCalls.godot_icall_0_39(MethodBind7, GodotObject.GetPtr(this));
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
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetButtonIcon, 4051416890ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetButtonIcon(Texture2D texture)
    {
        NativeCalls.godot_icall_1_56(MethodBind12, GodotObject.GetPtr(this), GodotObject.GetPtr(texture));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetButtonIcon, 3635182373ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Texture2D GetButtonIcon()
    {
        return (Texture2D)NativeCalls.godot_icall_0_63(MethodBind13, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFlat, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFlat(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind14, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsFlat, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsFlat()
    {
        return NativeCalls.godot_icall_0_15(MethodBind15, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetClipText, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetClipText(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind16, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetClipText, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetClipText()
    {
        return NativeCalls.godot_icall_0_15(MethodBind17, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTextAlignment, 2312603777ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTextAlignment(HorizontalAlignment alignment)
    {
        NativeCalls.godot_icall_1_38(MethodBind18, GodotObject.GetPtr(this), (int)alignment);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTextAlignment, 341400642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public HorizontalAlignment GetTextAlignment()
    {
        return (HorizontalAlignment)NativeCalls.godot_icall_0_39(MethodBind19, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetIconAlignment, 2312603777ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetIconAlignment(HorizontalAlignment iconAlignment)
    {
        NativeCalls.godot_icall_1_38(MethodBind20, GodotObject.GetPtr(this), (int)iconAlignment);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetIconAlignment, 341400642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public HorizontalAlignment GetIconAlignment()
    {
        return (HorizontalAlignment)NativeCalls.godot_icall_0_39(MethodBind21, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVerticalIconAlignment, 1796458609ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetVerticalIconAlignment(VerticalAlignment verticalIconAlignment)
    {
        NativeCalls.godot_icall_1_38(MethodBind22, GodotObject.GetPtr(this), (int)verticalIconAlignment);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVerticalIconAlignment, 3274884059ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public VerticalAlignment GetVerticalIconAlignment()
    {
        return (VerticalAlignment)NativeCalls.godot_icall_0_39(MethodBind23, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetExpandIcon, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetExpandIcon(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind24, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsExpandIcon, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsExpandIcon()
    {
        return NativeCalls.godot_icall_0_15(MethodBind25, GodotObject.GetPtr(this)).ToBool();
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
    public new class PropertyName : BaseButton.PropertyName
    {
        /// <summary>
        /// Cached name for the 'text' property.
        /// </summary>
        public static readonly StringName Text = "text";
        /// <summary>
        /// Cached name for the 'icon' property.
        /// </summary>
        public static readonly StringName Icon = "icon";
        /// <summary>
        /// Cached name for the 'flat' property.
        /// </summary>
        public static readonly StringName Flat = "flat";
        /// <summary>
        /// Cached name for the 'alignment' property.
        /// </summary>
        public static readonly StringName Alignment = "alignment";
        /// <summary>
        /// Cached name for the 'text_overrun_behavior' property.
        /// </summary>
        public static readonly StringName TextOverrunBehavior = "text_overrun_behavior";
        /// <summary>
        /// Cached name for the 'autowrap_mode' property.
        /// </summary>
        public static readonly StringName AutowrapMode = "autowrap_mode";
        /// <summary>
        /// Cached name for the 'autowrap_trim_flags' property.
        /// </summary>
        public static readonly StringName AutowrapTrimFlags = "autowrap_trim_flags";
        /// <summary>
        /// Cached name for the 'clip_text' property.
        /// </summary>
        public static readonly StringName ClipText = "clip_text";
        /// <summary>
        /// Cached name for the 'icon_alignment' property.
        /// </summary>
        public static readonly StringName IconAlignment = "icon_alignment";
        /// <summary>
        /// Cached name for the 'vertical_icon_alignment' property.
        /// </summary>
        public static readonly StringName VerticalIconAlignment = "vertical_icon_alignment";
        /// <summary>
        /// Cached name for the 'expand_icon' property.
        /// </summary>
        public static readonly StringName ExpandIcon = "expand_icon";
        /// <summary>
        /// Cached name for the 'text_direction' property.
        /// </summary>
        public static readonly StringName TextDirection = "text_direction";
        /// <summary>
        /// Cached name for the 'language' property.
        /// </summary>
        public static readonly StringName Language = "language";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : BaseButton.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_text' method.
        /// </summary>
        public static readonly StringName SetText = "set_text";
        /// <summary>
        /// Cached name for the 'get_text' method.
        /// </summary>
        public static readonly StringName GetText = "get_text";
        /// <summary>
        /// Cached name for the 'set_text_overrun_behavior' method.
        /// </summary>
        public static readonly StringName SetTextOverrunBehavior = "set_text_overrun_behavior";
        /// <summary>
        /// Cached name for the 'get_text_overrun_behavior' method.
        /// </summary>
        public static readonly StringName GetTextOverrunBehavior = "get_text_overrun_behavior";
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
        /// Cached name for the 'set_button_icon' method.
        /// </summary>
        public static readonly StringName SetButtonIcon = "set_button_icon";
        /// <summary>
        /// Cached name for the 'get_button_icon' method.
        /// </summary>
        public static readonly StringName GetButtonIcon = "get_button_icon";
        /// <summary>
        /// Cached name for the 'set_flat' method.
        /// </summary>
        public static readonly StringName SetFlat = "set_flat";
        /// <summary>
        /// Cached name for the 'is_flat' method.
        /// </summary>
        public static readonly StringName IsFlat = "is_flat";
        /// <summary>
        /// Cached name for the 'set_clip_text' method.
        /// </summary>
        public static readonly StringName SetClipText = "set_clip_text";
        /// <summary>
        /// Cached name for the 'get_clip_text' method.
        /// </summary>
        public static readonly StringName GetClipText = "get_clip_text";
        /// <summary>
        /// Cached name for the 'set_text_alignment' method.
        /// </summary>
        public static readonly StringName SetTextAlignment = "set_text_alignment";
        /// <summary>
        /// Cached name for the 'get_text_alignment' method.
        /// </summary>
        public static readonly StringName GetTextAlignment = "get_text_alignment";
        /// <summary>
        /// Cached name for the 'set_icon_alignment' method.
        /// </summary>
        public static readonly StringName SetIconAlignment = "set_icon_alignment";
        /// <summary>
        /// Cached name for the 'get_icon_alignment' method.
        /// </summary>
        public static readonly StringName GetIconAlignment = "get_icon_alignment";
        /// <summary>
        /// Cached name for the 'set_vertical_icon_alignment' method.
        /// </summary>
        public static readonly StringName SetVerticalIconAlignment = "set_vertical_icon_alignment";
        /// <summary>
        /// Cached name for the 'get_vertical_icon_alignment' method.
        /// </summary>
        public static readonly StringName GetVerticalIconAlignment = "get_vertical_icon_alignment";
        /// <summary>
        /// Cached name for the 'set_expand_icon' method.
        /// </summary>
        public static readonly StringName SetExpandIcon = "set_expand_icon";
        /// <summary>
        /// Cached name for the 'is_expand_icon' method.
        /// </summary>
        public static readonly StringName IsExpandIcon = "is_expand_icon";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : BaseButton.SignalName
    {
    }
}
