namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This <see cref="Godot.Control"/> node is used in the editor's Inspector dock to allow editing of numeric values. Can be used with <see cref="Godot.EditorInspectorPlugin"/> to recreate the same behavior.</para>
/// <para>If the <see cref="Godot.Range.Step"/> value is <c>1</c>, the <see cref="Godot.EditorSpinSlider"/> will display up/down arrows, similar to <see cref="Godot.SpinBox"/>. If the <see cref="Godot.Range.Step"/> value is not <c>1</c>, a slider will be displayed instead.</para>
/// </summary>
public partial class EditorSpinSlider : Range
{
    public enum ControlStateEnum : long
    {
        /// <summary>
        /// <para>The type of control used will depend on the value of <see cref="Godot.EditorSpinSlider.EditingInteger"/>. Up-down arrows if <see langword="true"/>, a slider if <see langword="false"/>.</para>
        /// </summary>
        Default = 0,
        /// <summary>
        /// <para>A slider will always be used, even if <see cref="Godot.EditorSpinSlider.EditingInteger"/> is enabled.</para>
        /// </summary>
        PreferSlider = 1,
        /// <summary>
        /// <para>Neither the up-down arrows nor the slider will be shown.</para>
        /// </summary>
        Hide = 2
    }

    /// <summary>
    /// <para>The text that displays to the left of the value.</para>
    /// </summary>
    public string Label
    {
        get
        {
            return GetLabel();
        }
        set
        {
            SetLabel(value);
        }
    }

    /// <summary>
    /// <para>The suffix to display after the value (in a faded color). This should generally be a plural word. You may have to use an abbreviation if the suffix is too long to be displayed.</para>
    /// </summary>
    public string Suffix
    {
        get
        {
            return GetSuffix();
        }
        set
        {
            SetSuffix(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the slider can't be interacted with.</para>
    /// </summary>
    public bool ReadOnly
    {
        get
        {
            return IsReadOnly();
        }
        set
        {
            SetReadOnly(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the slider will not draw background.</para>
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
    /// <para>The state in which the control used to manipulate the value will be.</para>
    /// </summary>
    public EditorSpinSlider.ControlStateEnum ControlState
    {
        get
        {
            return GetControlState();
        }
        set
        {
            SetControlState(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the slider and up/down arrows are hidden.</para>
    /// </summary>
    [Obsolete("Use 'Godot.EditorSpinSlider.ControlState' instead.")]
    public bool HideSlider
    {
        get
        {
            return IsHidingSlider();
        }
        set
        {
            SetHideSlider(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the <see cref="Godot.EditorSpinSlider"/> is considered to be editing an integer value. If <see langword="false"/>, the <see cref="Godot.EditorSpinSlider"/> is considered to be editing a floating-point value. This is used to determine whether a slider should be drawn by default. The slider is only drawn for floats; integers use up-down arrows similar to <see cref="Godot.SpinBox"/> instead, unless <see cref="Godot.EditorSpinSlider.ControlState"/> is set to <see cref="Godot.EditorSpinSlider.ControlStateEnum.PreferSlider"/>. It will also use <c>EditorSettings.interface/inspector/integer_drag_speed</c> instead of <c>EditorSettings.interface/inspector/float_drag_speed</c> if the slider is available.</para>
    /// </summary>
    public bool EditingInteger
    {
        get
        {
            return IsEditingInteger();
        }
        set
        {
            SetEditingInteger(value);
        }
    }

    private static readonly System.Type CachedType = typeof(EditorSpinSlider);

    private static readonly StringName NativeName = "EditorSpinSlider";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public EditorSpinSlider() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal EditorSpinSlider(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal EditorSpinSlider(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLabel, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetLabel(string label)
    {
        NativeCalls.godot_icall_1_57(MethodBind0, GodotObject.GetPtr(this), label);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLabel, 201670096ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetLabel()
    {
        return NativeCalls.godot_icall_0_58(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSuffix, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSuffix(string suffix)
    {
        NativeCalls.godot_icall_1_57(MethodBind2, GodotObject.GetPtr(this), suffix);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSuffix, 201670096ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetSuffix()
    {
        return NativeCalls.godot_icall_0_58(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetReadOnly, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetReadOnly(bool readOnly)
    {
        NativeCalls.godot_icall_1_14(MethodBind4, GodotObject.GetPtr(this), readOnly.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsReadOnly, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsReadOnly()
    {
        return NativeCalls.godot_icall_0_15(MethodBind5, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFlat, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFlat(bool flat)
    {
        NativeCalls.godot_icall_1_14(MethodBind6, GodotObject.GetPtr(this), flat.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsFlat, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsFlat()
    {
        return NativeCalls.godot_icall_0_15(MethodBind7, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetControlState, 1324557109ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetControlState(EditorSpinSlider.ControlStateEnum state)
    {
        NativeCalls.godot_icall_1_38(MethodBind8, GodotObject.GetPtr(this), (int)state);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetControlState, 3406006200ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public EditorSpinSlider.ControlStateEnum GetControlState()
    {
        return (EditorSpinSlider.ControlStateEnum)NativeCalls.godot_icall_0_39(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetHideSlider, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetHideSlider(bool hideSlider)
    {
        NativeCalls.godot_icall_1_14(MethodBind10, GodotObject.GetPtr(this), hideSlider.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsHidingSlider, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsHidingSlider()
    {
        return NativeCalls.godot_icall_0_15(MethodBind11, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEditingInteger, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEditingInteger(bool editingInteger)
    {
        NativeCalls.godot_icall_1_14(MethodBind12, GodotObject.GetPtr(this), editingInteger.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsEditingInteger, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsEditingInteger()
    {
        return NativeCalls.godot_icall_0_15(MethodBind13, GodotObject.GetPtr(this)).ToBool();
    }

    /// <summary>
    /// <para>Emitted when the spinner/slider is grabbed.</para>
    /// </summary>
    public event Action Grabbed
    {
        add => Connect(SignalName.Grabbed, Callable.From(value));
        remove => Disconnect(SignalName.Grabbed, Callable.From(value));
    }

    protected void EmitSignalGrabbed()
    {
        EmitSignal(SignalName.Grabbed);
    }

    /// <summary>
    /// <para>Emitted when the spinner/slider is ungrabbed.</para>
    /// </summary>
    public event Action Ungrabbed
    {
        add => Connect(SignalName.Ungrabbed, Callable.From(value));
        remove => Disconnect(SignalName.Ungrabbed, Callable.From(value));
    }

    protected void EmitSignalUngrabbed()
    {
        EmitSignal(SignalName.Ungrabbed);
    }

    /// <summary>
    /// <para>Emitted when the updown button is pressed.</para>
    /// </summary>
    public event Action UpdownPressed
    {
        add => Connect(SignalName.UpdownPressed, Callable.From(value));
        remove => Disconnect(SignalName.UpdownPressed, Callable.From(value));
    }

    protected void EmitSignalUpdownPressed()
    {
        EmitSignal(SignalName.UpdownPressed);
    }

    /// <summary>
    /// <para>Emitted when the value form gains focus.</para>
    /// </summary>
    public event Action ValueFocusEntered
    {
        add => Connect(SignalName.ValueFocusEntered, Callable.From(value));
        remove => Disconnect(SignalName.ValueFocusEntered, Callable.From(value));
    }

    protected void EmitSignalValueFocusEntered()
    {
        EmitSignal(SignalName.ValueFocusEntered);
    }

    /// <summary>
    /// <para>Emitted when the value form loses focus.</para>
    /// </summary>
    public event Action ValueFocusExited
    {
        add => Connect(SignalName.ValueFocusExited, Callable.From(value));
        remove => Disconnect(SignalName.ValueFocusExited, Callable.From(value));
    }

    protected void EmitSignalValueFocusExited()
    {
        EmitSignal(SignalName.ValueFocusExited);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_grabbed = "Grabbed";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_ungrabbed = "Ungrabbed";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_updown_pressed = "UpdownPressed";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_value_focus_entered = "ValueFocusEntered";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_value_focus_exited = "ValueFocusExited";

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
        if (signal == SignalName.Grabbed)
        {
            if (HasGodotClassSignal(SignalProxyName_grabbed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.Ungrabbed)
        {
            if (HasGodotClassSignal(SignalProxyName_ungrabbed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.UpdownPressed)
        {
            if (HasGodotClassSignal(SignalProxyName_updown_pressed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.ValueFocusEntered)
        {
            if (HasGodotClassSignal(SignalProxyName_value_focus_entered.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.ValueFocusExited)
        {
            if (HasGodotClassSignal(SignalProxyName_value_focus_exited.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        return base.HasGodotClassSignal(signal);
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : Range.PropertyName
    {
        /// <summary>
        /// Cached name for the 'label' property.
        /// </summary>
        public static readonly StringName Label = "label";
        /// <summary>
        /// Cached name for the 'suffix' property.
        /// </summary>
        public static readonly StringName Suffix = "suffix";
        /// <summary>
        /// Cached name for the 'read_only' property.
        /// </summary>
        public static readonly StringName ReadOnly = "read_only";
        /// <summary>
        /// Cached name for the 'flat' property.
        /// </summary>
        public static readonly StringName Flat = "flat";
        /// <summary>
        /// Cached name for the 'control_state' property.
        /// </summary>
        public static readonly StringName ControlState = "control_state";
        /// <summary>
        /// Cached name for the 'hide_slider' property.
        /// </summary>
        public static readonly StringName HideSlider = "hide_slider";
        /// <summary>
        /// Cached name for the 'editing_integer' property.
        /// </summary>
        public static readonly StringName EditingInteger = "editing_integer";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Range.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_label' method.
        /// </summary>
        public static readonly StringName SetLabel = "set_label";
        /// <summary>
        /// Cached name for the 'get_label' method.
        /// </summary>
        public static readonly StringName GetLabel = "get_label";
        /// <summary>
        /// Cached name for the 'set_suffix' method.
        /// </summary>
        public static readonly StringName SetSuffix = "set_suffix";
        /// <summary>
        /// Cached name for the 'get_suffix' method.
        /// </summary>
        public static readonly StringName GetSuffix = "get_suffix";
        /// <summary>
        /// Cached name for the 'set_read_only' method.
        /// </summary>
        public static readonly StringName SetReadOnly = "set_read_only";
        /// <summary>
        /// Cached name for the 'is_read_only' method.
        /// </summary>
        public static readonly StringName IsReadOnly = "is_read_only";
        /// <summary>
        /// Cached name for the 'set_flat' method.
        /// </summary>
        public static readonly StringName SetFlat = "set_flat";
        /// <summary>
        /// Cached name for the 'is_flat' method.
        /// </summary>
        public static readonly StringName IsFlat = "is_flat";
        /// <summary>
        /// Cached name for the 'set_control_state' method.
        /// </summary>
        public static readonly StringName SetControlState = "set_control_state";
        /// <summary>
        /// Cached name for the 'get_control_state' method.
        /// </summary>
        public static readonly StringName GetControlState = "get_control_state";
        /// <summary>
        /// Cached name for the 'set_hide_slider' method.
        /// </summary>
        public static readonly StringName SetHideSlider = "set_hide_slider";
        /// <summary>
        /// Cached name for the 'is_hiding_slider' method.
        /// </summary>
        public static readonly StringName IsHidingSlider = "is_hiding_slider";
        /// <summary>
        /// Cached name for the 'set_editing_integer' method.
        /// </summary>
        public static readonly StringName SetEditingInteger = "set_editing_integer";
        /// <summary>
        /// Cached name for the 'is_editing_integer' method.
        /// </summary>
        public static readonly StringName IsEditingInteger = "is_editing_integer";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Range.SignalName
    {
        /// <summary>
        /// Cached name for the 'grabbed' signal.
        /// </summary>
        public static readonly StringName Grabbed = "grabbed";
        /// <summary>
        /// Cached name for the 'ungrabbed' signal.
        /// </summary>
        public static readonly StringName Ungrabbed = "ungrabbed";
        /// <summary>
        /// Cached name for the 'updown_pressed' signal.
        /// </summary>
        public static readonly StringName UpdownPressed = "updown_pressed";
        /// <summary>
        /// Cached name for the 'value_focus_entered' signal.
        /// </summary>
        public static readonly StringName ValueFocusEntered = "value_focus_entered";
        /// <summary>
        /// Cached name for the 'value_focus_exited' signal.
        /// </summary>
        public static readonly StringName ValueFocusExited = "value_focus_exited";
    }
}
