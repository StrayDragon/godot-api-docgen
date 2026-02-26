namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para><see cref="Godot.BaseButton"/> is an abstract base class for GUI buttons. It doesn't display anything by itself.</para>
/// </summary>
public partial class BaseButton : Control
{
    public enum DrawMode : long
    {
        /// <summary>
        /// <para>The normal state (i.e. not pressed, not hovered, not toggled and enabled) of buttons.</para>
        /// </summary>
        Normal = 0,
        /// <summary>
        /// <para>The state of buttons are pressed.</para>
        /// </summary>
        Pressed = 1,
        /// <summary>
        /// <para>The state of buttons are hovered.</para>
        /// </summary>
        Hover = 2,
        /// <summary>
        /// <para>The state of buttons are disabled.</para>
        /// </summary>
        Disabled = 3,
        /// <summary>
        /// <para>The state of buttons are both hovered and pressed.</para>
        /// </summary>
        HoverPressed = 4
    }

    public enum ActionModeEnum : long
    {
        /// <summary>
        /// <para>Require just a press to consider the button clicked.</para>
        /// </summary>
        Press = 0,
        /// <summary>
        /// <para>Require a press and a subsequent release before considering the button clicked.</para>
        /// </summary>
        Release = 1
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the button is in disabled state and can't be clicked or toggled.</para>
    /// <para><b>Note:</b> If the button is disabled while held down, <see cref="Godot.BaseButton.ButtonUp"/> will be emitted.</para>
    /// </summary>
    public bool Disabled
    {
        get
        {
            return IsDisabled();
        }
        set
        {
            SetDisabled(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the button is in toggle mode. Makes the button flip state between pressed and unpressed each time its area is clicked.</para>
    /// </summary>
    public bool ToggleMode
    {
        get
        {
            return IsToggleMode();
        }
        set
        {
            SetToggleMode(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the button's state is pressed. Means the button is pressed down or toggled (if <see cref="Godot.BaseButton.ToggleMode"/> is active). Only works if <see cref="Godot.BaseButton.ToggleMode"/> is <see langword="true"/>.</para>
    /// <para><b>Note:</b> Changing the value of <see cref="Godot.BaseButton.ButtonPressed"/> will result in <see cref="Godot.BaseButton.Toggled"/> to be emitted. If you want to change the pressed state without emitting that signal, use <see cref="Godot.BaseButton.SetPressedNoSignal(bool)"/>.</para>
    /// </summary>
    public bool ButtonPressed
    {
        get
        {
            return IsPressed();
        }
        set
        {
            SetPressed(value);
        }
    }

    /// <summary>
    /// <para>Determines when the button is considered clicked.</para>
    /// </summary>
    public BaseButton.ActionModeEnum ActionMode
    {
        get
        {
            return GetActionMode();
        }
        set
        {
            SetActionMode(value);
        }
    }

    /// <summary>
    /// <para>Binary mask to choose which mouse buttons this button will respond to.</para>
    /// <para>To allow both left-click and right-click, use <c>MOUSE_BUTTON_MASK_LEFT | MOUSE_BUTTON_MASK_RIGHT</c>.</para>
    /// </summary>
    public MouseButtonMask ButtonMask
    {
        get
        {
            return GetButtonMask();
        }
        set
        {
            SetButtonMask(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the button stays pressed when moving the cursor outside the button while pressing it.</para>
    /// <para><b>Note:</b> This property only affects the button's visual appearance. Signals will be emitted at the same moment regardless of this property's value.</para>
    /// </summary>
    public bool KeepPressedOutside
    {
        get
        {
            return IsKeepPressedOutside();
        }
        set
        {
            SetKeepPressedOutside(value);
        }
    }

    /// <summary>
    /// <para>The <see cref="Godot.ButtonGroup"/> associated with the button. Not to be confused with node groups.</para>
    /// <para><b>Note:</b> The button will be configured as a radio button if a <see cref="Godot.ButtonGroup"/> is assigned to it.</para>
    /// </summary>
    public ButtonGroup ButtonGroup
    {
        get
        {
            return GetButtonGroup();
        }
        set
        {
            SetButtonGroup(value);
        }
    }

    /// <summary>
    /// <para><see cref="Godot.Shortcut"/> associated to the button.</para>
    /// </summary>
    public Shortcut Shortcut
    {
        get
        {
            return GetShortcut();
        }
        set
        {
            SetShortcut(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the button will highlight for a short amount of time when its shortcut is activated. If <see langword="false"/> and <see cref="Godot.BaseButton.ToggleMode"/> is <see langword="false"/>, the shortcut will activate without any visual feedback.</para>
    /// </summary>
    public bool ShortcutFeedback
    {
        get
        {
            return IsShortcutFeedback();
        }
        set
        {
            SetShortcutFeedback(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the button will add information about its shortcut in the tooltip.</para>
    /// <para><b>Note:</b> This property does nothing when the tooltip control is customized using <see cref="Godot.Control._MakeCustomTooltip(string)"/>.</para>
    /// </summary>
    public bool ShortcutInTooltip
    {
        get
        {
            return IsShortcutInTooltipEnabled();
        }
        set
        {
            SetShortcutInTooltip(value);
        }
    }

    private static readonly System.Type CachedType = typeof(BaseButton);

    private static readonly StringName NativeName = "BaseButton";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public BaseButton() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal BaseButton(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal BaseButton(bool memoryOwn) : base(memoryOwn) { }

    /// <summary>
    /// <para>Called when the button is pressed. If you need to know the button's pressed state (and <see cref="Godot.BaseButton.ToggleMode"/> is active), use <see cref="Godot.BaseButton._Toggled(bool)"/> instead.</para>
    /// </summary>
    public virtual void _Pressed()
    {
    }

    /// <summary>
    /// <para>Called when the button is toggled (only if <see cref="Godot.BaseButton.ToggleMode"/> is active).</para>
    /// </summary>
    public virtual void _Toggled(bool toggledOn)
    {
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPressed, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPressed(bool pressed)
    {
        NativeCalls.godot_icall_1_14(MethodBind0, GodotObject.GetPtr(this), pressed.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsPressed, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsPressed()
    {
        return NativeCalls.godot_icall_0_15(MethodBind1, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPressedNoSignal, 2586408642ul);

    /// <summary>
    /// <para>Changes the <see cref="Godot.BaseButton.ButtonPressed"/> state of the button, without emitting <see cref="Godot.BaseButton.Toggled"/>. Use when you just want to change the state of the button without sending the pressed event (e.g. when initializing scene). Only works if <see cref="Godot.BaseButton.ToggleMode"/> is <see langword="true"/>.</para>
    /// <para><b>Note:</b> This method doesn't unpress other buttons in <see cref="Godot.BaseButton.ButtonGroup"/>.</para>
    /// </summary>
    public void SetPressedNoSignal(bool pressed)
    {
        NativeCalls.godot_icall_1_14(MethodBind2, GodotObject.GetPtr(this), pressed.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsHovered, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the mouse has entered the button and has not left it yet.</para>
    /// </summary>
    public bool IsHovered()
    {
        return NativeCalls.godot_icall_0_15(MethodBind3, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetToggleMode, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetToggleMode(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind4, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsToggleMode, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsToggleMode()
    {
        return NativeCalls.godot_icall_0_15(MethodBind5, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetShortcutInTooltip, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetShortcutInTooltip(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind6, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsShortcutInTooltipEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsShortcutInTooltipEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind7, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDisabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDisabled(bool disabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind8, GodotObject.GetPtr(this), disabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsDisabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsDisabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind9, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetActionMode, 1985162088ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetActionMode(BaseButton.ActionModeEnum mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind10, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetActionMode, 2589712189ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public BaseButton.ActionModeEnum GetActionMode()
    {
        return (BaseButton.ActionModeEnum)NativeCalls.godot_icall_0_39(MethodBind11, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetButtonMask, 3950145251ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetButtonMask(MouseButtonMask mask)
    {
        NativeCalls.godot_icall_1_38(MethodBind12, GodotObject.GetPtr(this), (int)mask);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetButtonMask, 2512161324ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public MouseButtonMask GetButtonMask()
    {
        return (MouseButtonMask)NativeCalls.godot_icall_0_39(MethodBind13, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDrawMode, 2492721305ul);

    /// <summary>
    /// <para>Returns the visual state used to draw the button. This is useful mainly when implementing your own draw code by either overriding _draw() or connecting to "draw" signal. The visual state of the button is defined by the <see cref="Godot.BaseButton.DrawMode"/> enum.</para>
    /// </summary>
    public BaseButton.DrawMode GetDrawMode()
    {
        return (BaseButton.DrawMode)NativeCalls.godot_icall_0_39(MethodBind14, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetKeepPressedOutside, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetKeepPressedOutside(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind15, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsKeepPressedOutside, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsKeepPressedOutside()
    {
        return NativeCalls.godot_icall_0_15(MethodBind16, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetShortcutFeedback, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetShortcutFeedback(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind17, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsShortcutFeedback, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsShortcutFeedback()
    {
        return NativeCalls.godot_icall_0_15(MethodBind18, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetShortcut, 857163497ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetShortcut(Shortcut shortcut)
    {
        NativeCalls.godot_icall_1_56(MethodBind19, GodotObject.GetPtr(this), GodotObject.GetPtr(shortcut));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetShortcut, 3415666916ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Shortcut GetShortcut()
    {
        return (Shortcut)NativeCalls.godot_icall_0_63(MethodBind20, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetButtonGroup, 1794463739ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetButtonGroup(ButtonGroup buttonGroup)
    {
        NativeCalls.godot_icall_1_56(MethodBind21, GodotObject.GetPtr(this), GodotObject.GetPtr(buttonGroup));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetButtonGroup, 281644053ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public ButtonGroup GetButtonGroup()
    {
        return (ButtonGroup)NativeCalls.godot_icall_0_63(MethodBind22, GodotObject.GetPtr(this));
    }

    /// <summary>
    /// <para>Emitted when the button is toggled or pressed. This is on <see cref="Godot.BaseButton.ButtonDown"/> if <see cref="Godot.BaseButton.ActionMode"/> is <see cref="Godot.BaseButton.ActionModeEnum.Press"/> and on <see cref="Godot.BaseButton.ButtonUp"/> otherwise.</para>
    /// <para>If you need to know the button's pressed state (and <see cref="Godot.BaseButton.ToggleMode"/> is active), use <see cref="Godot.BaseButton.Toggled"/> instead.</para>
    /// </summary>
    public event Action Pressed
    {
        add => Connect(SignalName.Pressed, Callable.From(value));
        remove => Disconnect(SignalName.Pressed, Callable.From(value));
    }

    protected void EmitSignalPressed()
    {
        EmitSignal(SignalName.Pressed);
    }

    /// <summary>
    /// <para>Emitted when the button stops being held down.</para>
    /// </summary>
    public event Action ButtonUp
    {
        add => Connect(SignalName.ButtonUp, Callable.From(value));
        remove => Disconnect(SignalName.ButtonUp, Callable.From(value));
    }

    protected void EmitSignalButtonUp()
    {
        EmitSignal(SignalName.ButtonUp);
    }

    /// <summary>
    /// <para>Emitted when the button starts being held down.</para>
    /// </summary>
    public event Action ButtonDown
    {
        add => Connect(SignalName.ButtonDown, Callable.From(value));
        remove => Disconnect(SignalName.ButtonDown, Callable.From(value));
    }

    protected void EmitSignalButtonDown()
    {
        EmitSignal(SignalName.ButtonDown);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.BaseButton.Toggled"/> event of a <see cref="Godot.BaseButton"/> class.
    /// </summary>
    public delegate void ToggledEventHandler(bool toggledOn);

    private static void ToggledTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((ToggledEventHandler)delegateObj)(VariantUtils.ConvertTo<bool>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when the button was just toggled between pressed and normal states (only if <see cref="Godot.BaseButton.ToggleMode"/> is active). The new state is contained in the <c>toggledOn</c> argument.</para>
    /// </summary>
    public unsafe event ToggledEventHandler Toggled
    {
        add => Connect(SignalName.Toggled, Callable.CreateWithUnsafeTrampoline(value, &ToggledTrampoline));
        remove => Disconnect(SignalName.Toggled, Callable.CreateWithUnsafeTrampoline(value, &ToggledTrampoline));
    }

    protected void EmitSignalToggled(bool toggledOn)
    {
        EmitSignal(SignalName.Toggled, toggledOn);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__pressed = "_Pressed";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__toggled = "_Toggled";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_pressed = "Pressed";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_button_up = "ButtonUp";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_button_down = "ButtonDown";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_toggled = "Toggled";

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
        if ((method == MethodProxyName__pressed || method == MethodName._Pressed) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__pressed.NativeValue))
        {
            _Pressed();
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__toggled || method == MethodName._Toggled) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__toggled.NativeValue))
        {
            _Toggled(VariantUtils.ConvertTo<bool>(args[0]));
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
        if (method == MethodName._Pressed)
        {
            if (HasGodotClassMethod(MethodProxyName__pressed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._Toggled)
        {
            if (HasGodotClassMethod(MethodProxyName__toggled.NativeValue.DangerousSelfRef))
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
        if (signal == SignalName.Pressed)
        {
            if (HasGodotClassSignal(SignalProxyName_pressed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.ButtonUp)
        {
            if (HasGodotClassSignal(SignalProxyName_button_up.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.ButtonDown)
        {
            if (HasGodotClassSignal(SignalProxyName_button_down.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.Toggled)
        {
            if (HasGodotClassSignal(SignalProxyName_toggled.NativeValue.DangerousSelfRef))
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
        /// Cached name for the 'disabled' property.
        /// </summary>
        public static readonly StringName Disabled = "disabled";
        /// <summary>
        /// Cached name for the 'toggle_mode' property.
        /// </summary>
        public static readonly StringName ToggleMode = "toggle_mode";
        /// <summary>
        /// Cached name for the 'button_pressed' property.
        /// </summary>
        public static readonly StringName ButtonPressed = "button_pressed";
        /// <summary>
        /// Cached name for the 'action_mode' property.
        /// </summary>
        public static readonly StringName ActionMode = "action_mode";
        /// <summary>
        /// Cached name for the 'button_mask' property.
        /// </summary>
        public static readonly StringName ButtonMask = "button_mask";
        /// <summary>
        /// Cached name for the 'keep_pressed_outside' property.
        /// </summary>
        public static readonly StringName KeepPressedOutside = "keep_pressed_outside";
        /// <summary>
        /// Cached name for the 'button_group' property.
        /// </summary>
        public static readonly StringName ButtonGroup = "button_group";
        /// <summary>
        /// Cached name for the 'shortcut' property.
        /// </summary>
        public static readonly StringName Shortcut = "shortcut";
        /// <summary>
        /// Cached name for the 'shortcut_feedback' property.
        /// </summary>
        public static readonly StringName ShortcutFeedback = "shortcut_feedback";
        /// <summary>
        /// Cached name for the 'shortcut_in_tooltip' property.
        /// </summary>
        public static readonly StringName ShortcutInTooltip = "shortcut_in_tooltip";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Control.MethodName
    {
        /// <summary>
        /// Cached name for the '_pressed' method.
        /// </summary>
        public static readonly StringName _Pressed = "_pressed";
        /// <summary>
        /// Cached name for the '_toggled' method.
        /// </summary>
        public static readonly StringName _Toggled = "_toggled";
        /// <summary>
        /// Cached name for the 'set_pressed' method.
        /// </summary>
        public static readonly StringName SetPressed = "set_pressed";
        /// <summary>
        /// Cached name for the 'is_pressed' method.
        /// </summary>
        public static readonly StringName IsPressed = "is_pressed";
        /// <summary>
        /// Cached name for the 'set_pressed_no_signal' method.
        /// </summary>
        public static readonly StringName SetPressedNoSignal = "set_pressed_no_signal";
        /// <summary>
        /// Cached name for the 'is_hovered' method.
        /// </summary>
        public static readonly StringName IsHovered = "is_hovered";
        /// <summary>
        /// Cached name for the 'set_toggle_mode' method.
        /// </summary>
        public static readonly StringName SetToggleMode = "set_toggle_mode";
        /// <summary>
        /// Cached name for the 'is_toggle_mode' method.
        /// </summary>
        public static readonly StringName IsToggleMode = "is_toggle_mode";
        /// <summary>
        /// Cached name for the 'set_shortcut_in_tooltip' method.
        /// </summary>
        public static readonly StringName SetShortcutInTooltip = "set_shortcut_in_tooltip";
        /// <summary>
        /// Cached name for the 'is_shortcut_in_tooltip_enabled' method.
        /// </summary>
        public static readonly StringName IsShortcutInTooltipEnabled = "is_shortcut_in_tooltip_enabled";
        /// <summary>
        /// Cached name for the 'set_disabled' method.
        /// </summary>
        public static readonly StringName SetDisabled = "set_disabled";
        /// <summary>
        /// Cached name for the 'is_disabled' method.
        /// </summary>
        public static readonly StringName IsDisabled = "is_disabled";
        /// <summary>
        /// Cached name for the 'set_action_mode' method.
        /// </summary>
        public static readonly StringName SetActionMode = "set_action_mode";
        /// <summary>
        /// Cached name for the 'get_action_mode' method.
        /// </summary>
        public static readonly StringName GetActionMode = "get_action_mode";
        /// <summary>
        /// Cached name for the 'set_button_mask' method.
        /// </summary>
        public static readonly StringName SetButtonMask = "set_button_mask";
        /// <summary>
        /// Cached name for the 'get_button_mask' method.
        /// </summary>
        public static readonly StringName GetButtonMask = "get_button_mask";
        /// <summary>
        /// Cached name for the 'get_draw_mode' method.
        /// </summary>
        public static readonly StringName GetDrawMode = "get_draw_mode";
        /// <summary>
        /// Cached name for the 'set_keep_pressed_outside' method.
        /// </summary>
        public static readonly StringName SetKeepPressedOutside = "set_keep_pressed_outside";
        /// <summary>
        /// Cached name for the 'is_keep_pressed_outside' method.
        /// </summary>
        public static readonly StringName IsKeepPressedOutside = "is_keep_pressed_outside";
        /// <summary>
        /// Cached name for the 'set_shortcut_feedback' method.
        /// </summary>
        public static readonly StringName SetShortcutFeedback = "set_shortcut_feedback";
        /// <summary>
        /// Cached name for the 'is_shortcut_feedback' method.
        /// </summary>
        public static readonly StringName IsShortcutFeedback = "is_shortcut_feedback";
        /// <summary>
        /// Cached name for the 'set_shortcut' method.
        /// </summary>
        public static readonly StringName SetShortcut = "set_shortcut";
        /// <summary>
        /// Cached name for the 'get_shortcut' method.
        /// </summary>
        public static readonly StringName GetShortcut = "get_shortcut";
        /// <summary>
        /// Cached name for the 'set_button_group' method.
        /// </summary>
        public static readonly StringName SetButtonGroup = "set_button_group";
        /// <summary>
        /// Cached name for the 'get_button_group' method.
        /// </summary>
        public static readonly StringName GetButtonGroup = "get_button_group";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Control.SignalName
    {
        /// <summary>
        /// Cached name for the 'pressed' signal.
        /// </summary>
        public static readonly StringName Pressed = "pressed";
        /// <summary>
        /// Cached name for the 'button_up' signal.
        /// </summary>
        public static readonly StringName ButtonUp = "button_up";
        /// <summary>
        /// Cached name for the 'button_down' signal.
        /// </summary>
        public static readonly StringName ButtonDown = "button_down";
        /// <summary>
        /// Cached name for the 'toggled' signal.
        /// </summary>
        public static readonly StringName Toggled = "toggled";
    }
}
