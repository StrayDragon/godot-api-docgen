namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>The default use of <see cref="Godot.AcceptDialog"/> is to allow it to only be accepted or closed, with the same result. However, the <see cref="Godot.AcceptDialog.Confirmed"/> and <see cref="Godot.AcceptDialog.Canceled"/> signals allow to make the two actions different, and the <see cref="Godot.AcceptDialog.AddButton(string, bool, string)"/> method allows to add custom buttons and actions.</para>
/// <para><b>Note:</b> <see cref="Godot.AcceptDialog"/> is invisible by default. To make it visible, call one of the <c>popup_*</c> methods from <see cref="Godot.Window"/> on the node, such as <see cref="Godot.Window.PopupCenteredClamped(Nullable{Vector2I}, float)"/>.</para>
/// </summary>
public partial class AcceptDialog : Window
{
    /// <summary>
    /// <para>The text displayed by the OK button (see <see cref="Godot.AcceptDialog.GetOkButton()"/>). If empty, a default text will be used.</para>
    /// </summary>
    public string OkButtonText
    {
        get
        {
            return GetOkButtonText();
        }
        set
        {
            SetOkButtonText(value);
        }
    }

    /// <summary>
    /// <para>The text displayed by the dialog.</para>
    /// </summary>
    public string DialogText
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
    /// <para>If <see langword="true"/>, the dialog is hidden when the OK button is pressed. You can set it to <see langword="false"/> if you want to do e.g. input validation when receiving the <see cref="Godot.AcceptDialog.Confirmed"/> signal, and handle hiding the dialog in your own logic.</para>
    /// <para><b>Note:</b> Some nodes derived from this class can have a different default value, and potentially their own built-in logic overriding this setting. For example <see cref="Godot.FileDialog"/> defaults to <see langword="false"/>, and has its own input validation code that is called when you press OK, which eventually hides the dialog if the input is valid. As such, this property can't be used in <see cref="Godot.FileDialog"/> to disable hiding the dialog when pressing OK.</para>
    /// </summary>
    public bool DialogHideOnOk
    {
        get
        {
            return GetHideOnOk();
        }
        set
        {
            SetHideOnOk(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the dialog will be hidden when the <c>ui_close_dialog</c> action is pressed (by default, this action is bound to Escape, or Cmd + W on macOS).</para>
    /// </summary>
    public bool DialogCloseOnEscape
    {
        get
        {
            return GetCloseOnEscape();
        }
        set
        {
            SetCloseOnEscape(value);
        }
    }

    /// <summary>
    /// <para>Sets autowrapping for the text in the dialog.</para>
    /// </summary>
    public bool DialogAutowrap
    {
        get
        {
            return HasAutowrap();
        }
        set
        {
            SetAutowrap(value);
        }
    }

    private static readonly System.Type CachedType = typeof(AcceptDialog);

    private static readonly StringName NativeName = "AcceptDialog";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public AcceptDialog() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal AcceptDialog(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal AcceptDialog(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOkButton, 1856205918ul);

    /// <summary>
    /// <para>Returns the OK <see cref="Godot.Button"/> instance.</para>
    /// <para><b>Warning:</b> This is a required internal node, removing and freeing it may cause a crash. If you wish to hide it or any of its children, use their <see cref="Godot.CanvasItem.Visible"/> property.</para>
    /// </summary>
    public Button GetOkButton()
    {
        return (Button)NativeCalls.godot_icall_0_53(MethodBind0, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLabel, 566733104ul);

    /// <summary>
    /// <para>Returns the label used for built-in text.</para>
    /// <para><b>Warning:</b> This is a required internal node, removing and freeing it may cause a crash. If you wish to hide it or any of its children, use their <see cref="Godot.CanvasItem.Visible"/> property.</para>
    /// </summary>
    public Label GetLabel()
    {
        return (Label)NativeCalls.godot_icall_0_53(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetHideOnOk, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetHideOnOk(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind2, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetHideOnOk, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetHideOnOk()
    {
        return NativeCalls.godot_icall_0_15(MethodBind3, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCloseOnEscape, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCloseOnEscape(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind4, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCloseOnEscape, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetCloseOnEscape()
    {
        return NativeCalls.godot_icall_0_15(MethodBind5, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddButton, 3328440682ul);

    /// <summary>
    /// <para>Adds a button with label <paramref name="text"/> and a custom <paramref name="action"/> to the dialog and returns the created button.</para>
    /// <para>If <paramref name="action"/> is not empty, pressing the button will emit the <see cref="Godot.AcceptDialog.CustomAction"/> signal with the specified action string.</para>
    /// <para>If <see langword="true"/>, <paramref name="right"/> will place the button to the right of any sibling buttons.</para>
    /// <para>You can use <see cref="Godot.AcceptDialog.RemoveButton(Button)"/> method to remove a button created with this method from the dialog.</para>
    /// </summary>
    public Button AddButton(string text, bool right = false, string action = "")
    {
        return (Button)NativeCalls.godot_icall_3_54(MethodBind6, GodotObject.GetPtr(this), text, right.ToGodotBool(), action);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddCancelButton, 242045556ul);

    /// <summary>
    /// <para>Adds a button with label <paramref name="name"/> and a cancel action to the dialog and returns the created button.</para>
    /// <para>You can use <see cref="Godot.AcceptDialog.RemoveButton(Button)"/> method to remove a button created with this method from the dialog.</para>
    /// </summary>
    public Button AddCancelButton(string name)
    {
        return (Button)NativeCalls.godot_icall_1_55(MethodBind7, GodotObject.GetPtr(this), name);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveButton, 2068354942ul);

    /// <summary>
    /// <para>Removes the <paramref name="button"/> from the dialog. Does NOT free the <paramref name="button"/>. The <paramref name="button"/> must be a <see cref="Godot.Button"/> added with <see cref="Godot.AcceptDialog.AddButton(string, bool, string)"/> or <see cref="Godot.AcceptDialog.AddCancelButton(string)"/> method. After removal, pressing the <paramref name="button"/> will no longer emit this dialog's <see cref="Godot.AcceptDialog.CustomAction"/> or <see cref="Godot.AcceptDialog.Canceled"/> signals.</para>
    /// </summary>
    public void RemoveButton(Button button)
    {
        NativeCalls.godot_icall_1_56(MethodBind8, GodotObject.GetPtr(this), GodotObject.GetPtr(button));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RegisterTextEnter, 3714008017ul);

    /// <summary>
    /// <para>Registers a <see cref="Godot.LineEdit"/> in the dialog. When the enter key is pressed, the dialog will be accepted.</para>
    /// </summary>
    public void RegisterTextEnter(LineEdit lineEdit)
    {
        NativeCalls.godot_icall_1_56(MethodBind9, GodotObject.GetPtr(this), GodotObject.GetPtr(lineEdit));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetText, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetText(string text)
    {
        NativeCalls.godot_icall_1_57(MethodBind10, GodotObject.GetPtr(this), text);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetText, 201670096ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetText()
    {
        return NativeCalls.godot_icall_0_58(MethodBind11, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAutowrap, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAutowrap(bool autowrap)
    {
        NativeCalls.godot_icall_1_14(MethodBind12, GodotObject.GetPtr(this), autowrap.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasAutowrap, 2240911060ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool HasAutowrap()
    {
        return NativeCalls.godot_icall_0_15(MethodBind13, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetOkButtonText, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetOkButtonText(string text)
    {
        NativeCalls.godot_icall_1_57(MethodBind14, GodotObject.GetPtr(this), text);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOkButtonText, 201670096ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetOkButtonText()
    {
        return NativeCalls.godot_icall_0_58(MethodBind15, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveButton, 1496901182ul);

    /// <summary>
    /// <para>Removes the <paramref name="button"/> from the dialog. Does NOT free the <paramref name="button"/>. The <paramref name="button"/> must be a <see cref="Godot.Button"/> added with <see cref="Godot.AcceptDialog.AddButton(string, bool, string)"/> or <see cref="Godot.AcceptDialog.AddCancelButton(string)"/> method. After removal, pressing the <paramref name="button"/> will no longer emit this dialog's <see cref="Godot.AcceptDialog.CustomAction"/> or <see cref="Godot.AcceptDialog.Canceled"/> signals.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void RemoveButton(Control quadrantSize)
    {
        NativeCalls.godot_icall_1_56(MethodBind16, GodotObject.GetPtr(this), GodotObject.GetPtr(quadrantSize));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RegisterTextEnter, 1496901182ul);

    /// <summary>
    /// <para>Registers a <see cref="Godot.LineEdit"/> in the dialog. When the enter key is pressed, the dialog will be accepted.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void RegisterTextEnter(Control _UnnamedArg0)
    {
        NativeCalls.godot_icall_1_56(MethodBind17, GodotObject.GetPtr(this), GodotObject.GetPtr(_UnnamedArg0));
    }

    /// <summary>
    /// <para>Emitted when the dialog is accepted, i.e. the OK button is pressed.</para>
    /// </summary>
    public event Action Confirmed
    {
        add => Connect(SignalName.Confirmed, Callable.From(value));
        remove => Disconnect(SignalName.Confirmed, Callable.From(value));
    }

    protected void EmitSignalConfirmed()
    {
        EmitSignal(SignalName.Confirmed);
    }

    /// <summary>
    /// <para>Emitted when the dialog is closed or the button created with <see cref="Godot.AcceptDialog.AddCancelButton(string)"/> is pressed.</para>
    /// </summary>
    public event Action Canceled
    {
        add => Connect(SignalName.Canceled, Callable.From(value));
        remove => Disconnect(SignalName.Canceled, Callable.From(value));
    }

    protected void EmitSignalCanceled()
    {
        EmitSignal(SignalName.Canceled);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.AcceptDialog.CustomAction"/> event of a <see cref="Godot.AcceptDialog"/> class.
    /// </summary>
    public delegate void CustomActionEventHandler(StringName action);

    private static void CustomActionTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((CustomActionEventHandler)delegateObj)(VariantUtils.ConvertTo<StringName>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when a custom button with an action is pressed. See <see cref="Godot.AcceptDialog.AddButton(string, bool, string)"/>.</para>
    /// </summary>
    public unsafe event CustomActionEventHandler CustomAction
    {
        add => Connect(SignalName.CustomAction, Callable.CreateWithUnsafeTrampoline(value, &CustomActionTrampoline));
        remove => Disconnect(SignalName.CustomAction, Callable.CreateWithUnsafeTrampoline(value, &CustomActionTrampoline));
    }

    protected void EmitSignalCustomAction(StringName action)
    {
        EmitSignal(SignalName.CustomAction, action);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_confirmed = "Confirmed";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_canceled = "Canceled";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_custom_action = "CustomAction";

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
        if (signal == SignalName.Confirmed)
        {
            if (HasGodotClassSignal(SignalProxyName_confirmed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.Canceled)
        {
            if (HasGodotClassSignal(SignalProxyName_canceled.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.CustomAction)
        {
            if (HasGodotClassSignal(SignalProxyName_custom_action.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        return base.HasGodotClassSignal(signal);
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : Window.PropertyName
    {
        /// <summary>
        /// Cached name for the 'ok_button_text' property.
        /// </summary>
        public static readonly StringName OkButtonText = "ok_button_text";
        /// <summary>
        /// Cached name for the 'dialog_text' property.
        /// </summary>
        public static readonly StringName DialogText = "dialog_text";
        /// <summary>
        /// Cached name for the 'dialog_hide_on_ok' property.
        /// </summary>
        public static readonly StringName DialogHideOnOk = "dialog_hide_on_ok";
        /// <summary>
        /// Cached name for the 'dialog_close_on_escape' property.
        /// </summary>
        public static readonly StringName DialogCloseOnEscape = "dialog_close_on_escape";
        /// <summary>
        /// Cached name for the 'dialog_autowrap' property.
        /// </summary>
        public static readonly StringName DialogAutowrap = "dialog_autowrap";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Window.MethodName
    {
        /// <summary>
        /// Cached name for the 'get_ok_button' method.
        /// </summary>
        public static readonly StringName GetOkButton = "get_ok_button";
        /// <summary>
        /// Cached name for the 'get_label' method.
        /// </summary>
        public static readonly StringName GetLabel = "get_label";
        /// <summary>
        /// Cached name for the 'set_hide_on_ok' method.
        /// </summary>
        public static readonly StringName SetHideOnOk = "set_hide_on_ok";
        /// <summary>
        /// Cached name for the 'get_hide_on_ok' method.
        /// </summary>
        public static readonly StringName GetHideOnOk = "get_hide_on_ok";
        /// <summary>
        /// Cached name for the 'set_close_on_escape' method.
        /// </summary>
        public static readonly StringName SetCloseOnEscape = "set_close_on_escape";
        /// <summary>
        /// Cached name for the 'get_close_on_escape' method.
        /// </summary>
        public static readonly StringName GetCloseOnEscape = "get_close_on_escape";
        /// <summary>
        /// Cached name for the 'add_button' method.
        /// </summary>
        public static readonly StringName AddButton = "add_button";
        /// <summary>
        /// Cached name for the 'add_cancel_button' method.
        /// </summary>
        public static readonly StringName AddCancelButton = "add_cancel_button";
        /// <summary>
        /// Cached name for the 'remove_button' method.
        /// </summary>
        public static readonly StringName RemoveButton = "remove_button";
        /// <summary>
        /// Cached name for the 'register_text_enter' method.
        /// </summary>
        public static readonly StringName RegisterTextEnter = "register_text_enter";
        /// <summary>
        /// Cached name for the 'set_text' method.
        /// </summary>
        public static readonly StringName SetText = "set_text";
        /// <summary>
        /// Cached name for the 'get_text' method.
        /// </summary>
        public static readonly StringName GetText = "get_text";
        /// <summary>
        /// Cached name for the 'set_autowrap' method.
        /// </summary>
        public static readonly StringName SetAutowrap = "set_autowrap";
        /// <summary>
        /// Cached name for the 'has_autowrap' method.
        /// </summary>
        public static readonly StringName HasAutowrap = "has_autowrap";
        /// <summary>
        /// Cached name for the 'set_ok_button_text' method.
        /// </summary>
        public static readonly StringName SetOkButtonText = "set_ok_button_text";
        /// <summary>
        /// Cached name for the 'get_ok_button_text' method.
        /// </summary>
        public static readonly StringName GetOkButtonText = "get_ok_button_text";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Window.SignalName
    {
        /// <summary>
        /// Cached name for the 'confirmed' signal.
        /// </summary>
        public static readonly StringName Confirmed = "confirmed";
        /// <summary>
        /// Cached name for the 'canceled' signal.
        /// </summary>
        public static readonly StringName Canceled = "canceled";
        /// <summary>
        /// Cached name for the 'custom_action' signal.
        /// </summary>
        public static readonly StringName CustomAction = "custom_action";
    }
}
