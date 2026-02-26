namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A dialog used for confirmation of actions. This window is similar to <see cref="Godot.AcceptDialog"/>, but pressing its Cancel button can have a different outcome from pressing the OK button. The order of the two buttons varies depending on the host OS.</para>
/// <para>To get cancel action, you can use:</para>
/// <para><code>
/// GetCancelButton().Pressed += OnCanceled;
/// </code></para>
/// <para><b>Note:</b> <see cref="Godot.AcceptDialog"/> is invisible by default. To make it visible, call one of the <c>popup_*</c> methods from <see cref="Godot.Window"/> on the node, such as <see cref="Godot.Window.PopupCenteredClamped(Nullable{Vector2I}, float)"/>.</para>
/// </summary>
public partial class ConfirmationDialog : AcceptDialog
{
    /// <summary>
    /// <para>The text displayed by the cancel button (see <see cref="Godot.ConfirmationDialog.GetCancelButton()"/>).</para>
    /// </summary>
    public string CancelButtonText
    {
        get
        {
            return GetCancelButtonText();
        }
        set
        {
            SetCancelButtonText(value);
        }
    }

    private static readonly System.Type CachedType = typeof(ConfirmationDialog);

    private static readonly StringName NativeName = "ConfirmationDialog";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public ConfirmationDialog() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal ConfirmationDialog(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal ConfirmationDialog(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCancelButton, 1856205918ul);

    /// <summary>
    /// <para>Returns the cancel button.</para>
    /// <para><b>Warning:</b> This is a required internal node, removing and freeing it may cause a crash. If you wish to hide it or any of its children, use their <see cref="Godot.CanvasItem.Visible"/> property.</para>
    /// </summary>
    public Button GetCancelButton()
    {
        return (Button)NativeCalls.godot_icall_0_53(MethodBind0, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCancelButtonText, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCancelButtonText(string text)
    {
        NativeCalls.godot_icall_1_57(MethodBind1, GodotObject.GetPtr(this), text);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCancelButtonText, 201670096ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetCancelButtonText()
    {
        return NativeCalls.godot_icall_0_58(MethodBind2, GodotObject.GetPtr(this));
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
    public new class PropertyName : AcceptDialog.PropertyName
    {
        /// <summary>
        /// Cached name for the 'cancel_button_text' property.
        /// </summary>
        public static readonly StringName CancelButtonText = "cancel_button_text";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : AcceptDialog.MethodName
    {
        /// <summary>
        /// Cached name for the 'get_cancel_button' method.
        /// </summary>
        public static readonly StringName GetCancelButton = "get_cancel_button";
        /// <summary>
        /// Cached name for the 'set_cancel_button_text' method.
        /// </summary>
        public static readonly StringName SetCancelButtonText = "set_cancel_button_text";
        /// <summary>
        /// Cached name for the 'get_cancel_button_text' method.
        /// </summary>
        public static readonly StringName GetCancelButtonText = "get_cancel_button_text";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : AcceptDialog.SignalName
    {
    }
}
