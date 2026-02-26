namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Encapsulates a <see cref="Godot.ColorPicker"/>, making it accessible by pressing a button. Pressing the button will toggle the <see cref="Godot.ColorPicker"/>'s visibility.</para>
/// <para>See also <see cref="Godot.BaseButton"/> which contains common properties and methods associated with this node.</para>
/// <para><b>Note:</b> By default, the button may not be wide enough for the color preview swatch to be visible. Make sure to set <see cref="Godot.Control.CustomMinimumSize"/> to a big enough value to give the button enough space.</para>
/// </summary>
public partial class ColorPickerButton : Button
{
    /// <summary>
    /// <para>The currently selected color.</para>
    /// </summary>
    public Color Color
    {
        get
        {
            return GetPickColor();
        }
        set
        {
            SetPickColor(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the alpha channel in the displayed <see cref="Godot.ColorPicker"/> will be visible.</para>
    /// </summary>
    public bool EditAlpha
    {
        get
        {
            return IsEditingAlpha();
        }
        set
        {
            SetEditAlpha(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the intensity slider in the displayed <see cref="Godot.ColorPicker"/> will be visible.</para>
    /// </summary>
    public bool EditIntensity
    {
        get
        {
            return IsEditingIntensity();
        }
        set
        {
            SetEditIntensity(value);
        }
    }

    private static readonly System.Type CachedType = typeof(ColorPickerButton);

    private static readonly StringName NativeName = "ColorPickerButton";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public ColorPickerButton() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal ColorPickerButton(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal ColorPickerButton(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPickColor, 2920490490ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetPickColor(Color color)
    {
        NativeCalls.godot_icall_1_213(MethodBind0, GodotObject.GetPtr(this), &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPickColor, 3444240500ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Color GetPickColor()
    {
        return NativeCalls.godot_icall_0_214(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPicker, 331835996ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.ColorPicker"/> that this node toggles.</para>
    /// <para><b>Warning:</b> This is a required internal node, removing and freeing it may cause a crash. If you wish to hide it or any of its children, use their <see cref="Godot.CanvasItem.Visible"/> property.</para>
    /// </summary>
    public ColorPicker GetPicker()
    {
        return (ColorPicker)NativeCalls.godot_icall_0_53(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPopup, 1322440207ul);

    /// <summary>
    /// <para>Returns the control's <see cref="Godot.PopupPanel"/> which allows you to connect to popup signals. This allows you to handle events when the ColorPicker is shown or hidden.</para>
    /// <para><b>Warning:</b> This is a required internal node, removing and freeing it may cause a crash. If you wish to hide it or any of its children, use their <see cref="Godot.Window.Visible"/> property.</para>
    /// </summary>
    public PopupPanel GetPopup()
    {
        return (PopupPanel)NativeCalls.godot_icall_0_53(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEditAlpha, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEditAlpha(bool show)
    {
        NativeCalls.godot_icall_1_14(MethodBind4, GodotObject.GetPtr(this), show.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsEditingAlpha, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsEditingAlpha()
    {
        return NativeCalls.godot_icall_0_15(MethodBind5, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEditIntensity, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEditIntensity(bool show)
    {
        NativeCalls.godot_icall_1_14(MethodBind6, GodotObject.GetPtr(this), show.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsEditingIntensity, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsEditingIntensity()
    {
        return NativeCalls.godot_icall_0_15(MethodBind7, GodotObject.GetPtr(this)).ToBool();
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.ColorPickerButton.ColorChanged"/> event of a <see cref="Godot.ColorPickerButton"/> class.
    /// </summary>
    public delegate void ColorChangedEventHandler(Color color);

    private static void ColorChangedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((ColorChangedEventHandler)delegateObj)(VariantUtils.ConvertTo<Color>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when the color changes.</para>
    /// </summary>
    public unsafe event ColorChangedEventHandler ColorChanged
    {
        add => Connect(SignalName.ColorChanged, Callable.CreateWithUnsafeTrampoline(value, &ColorChangedTrampoline));
        remove => Disconnect(SignalName.ColorChanged, Callable.CreateWithUnsafeTrampoline(value, &ColorChangedTrampoline));
    }

    protected void EmitSignalColorChanged(Color color)
    {
        EmitSignal(SignalName.ColorChanged, color);
    }

    /// <summary>
    /// <para>Emitted when the <see cref="Godot.ColorPicker"/> is closed.</para>
    /// </summary>
    public event Action PopupClosed
    {
        add => Connect(SignalName.PopupClosed, Callable.From(value));
        remove => Disconnect(SignalName.PopupClosed, Callable.From(value));
    }

    protected void EmitSignalPopupClosed()
    {
        EmitSignal(SignalName.PopupClosed);
    }

    /// <summary>
    /// <para>Emitted when the <see cref="Godot.ColorPicker"/> is created (the button is pressed for the first time).</para>
    /// </summary>
    public event Action PickerCreated
    {
        add => Connect(SignalName.PickerCreated, Callable.From(value));
        remove => Disconnect(SignalName.PickerCreated, Callable.From(value));
    }

    protected void EmitSignalPickerCreated()
    {
        EmitSignal(SignalName.PickerCreated);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_color_changed = "ColorChanged";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_popup_closed = "PopupClosed";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_picker_created = "PickerCreated";

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
        if (signal == SignalName.ColorChanged)
        {
            if (HasGodotClassSignal(SignalProxyName_color_changed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.PopupClosed)
        {
            if (HasGodotClassSignal(SignalProxyName_popup_closed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.PickerCreated)
        {
            if (HasGodotClassSignal(SignalProxyName_picker_created.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        return base.HasGodotClassSignal(signal);
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : Button.PropertyName
    {
        /// <summary>
        /// Cached name for the 'color' property.
        /// </summary>
        public static readonly StringName Color = "color";
        /// <summary>
        /// Cached name for the 'edit_alpha' property.
        /// </summary>
        public static readonly StringName EditAlpha = "edit_alpha";
        /// <summary>
        /// Cached name for the 'edit_intensity' property.
        /// </summary>
        public static readonly StringName EditIntensity = "edit_intensity";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Button.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_pick_color' method.
        /// </summary>
        public static readonly StringName SetPickColor = "set_pick_color";
        /// <summary>
        /// Cached name for the 'get_pick_color' method.
        /// </summary>
        public static readonly StringName GetPickColor = "get_pick_color";
        /// <summary>
        /// Cached name for the 'get_picker' method.
        /// </summary>
        public static readonly StringName GetPicker = "get_picker";
        /// <summary>
        /// Cached name for the 'get_popup' method.
        /// </summary>
        public static readonly StringName GetPopup = "get_popup";
        /// <summary>
        /// Cached name for the 'set_edit_alpha' method.
        /// </summary>
        public static readonly StringName SetEditAlpha = "set_edit_alpha";
        /// <summary>
        /// Cached name for the 'is_editing_alpha' method.
        /// </summary>
        public static readonly StringName IsEditingAlpha = "is_editing_alpha";
        /// <summary>
        /// Cached name for the 'set_edit_intensity' method.
        /// </summary>
        public static readonly StringName SetEditIntensity = "set_edit_intensity";
        /// <summary>
        /// Cached name for the 'is_editing_intensity' method.
        /// </summary>
        public static readonly StringName IsEditingIntensity = "is_editing_intensity";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Button.SignalName
    {
        /// <summary>
        /// Cached name for the 'color_changed' signal.
        /// </summary>
        public static readonly StringName ColorChanged = "color_changed";
        /// <summary>
        /// Cached name for the 'popup_closed' signal.
        /// </summary>
        public static readonly StringName PopupClosed = "popup_closed";
        /// <summary>
        /// Cached name for the 'picker_created' signal.
        /// </summary>
        public static readonly StringName PickerCreated = "picker_created";
    }
}
