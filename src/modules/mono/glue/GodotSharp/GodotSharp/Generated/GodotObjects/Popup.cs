namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para><see cref="Godot.Popup"/> is a base class for contextual windows and panels with fixed position. It's a modal by default (see <see cref="Godot.Window.PopupWindow"/>) and provides methods for implementing custom popup behavior.</para>
/// <para><b>Note:</b> <see cref="Godot.Popup"/> is invisible by default. To make it visible, call one of the <c>popup_*</c> methods from <see cref="Godot.Window"/> on the node, such as <see cref="Godot.Window.PopupCenteredClamped(Nullable{Vector2I}, float)"/>.</para>
/// </summary>
public partial class Popup : Window
{
    private static readonly System.Type CachedType = typeof(Popup);

    private static readonly StringName NativeName = "Popup";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public Popup() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal Popup(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal Popup(bool memoryOwn) : base(memoryOwn) { }

    /// <summary>
    /// <para>Emitted when the popup is hidden.</para>
    /// </summary>
    public event Action PopupHide
    {
        add => Connect(SignalName.PopupHide, Callable.From(value));
        remove => Disconnect(SignalName.PopupHide, Callable.From(value));
    }

    protected void EmitSignalPopupHide()
    {
        EmitSignal(SignalName.PopupHide);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_popup_hide = "PopupHide";

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
        if (signal == SignalName.PopupHide)
        {
            if (HasGodotClassSignal(SignalProxyName_popup_hide.NativeValue.DangerousSelfRef))
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
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Window.MethodName
    {
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Window.SignalName
    {
        /// <summary>
        /// Cached name for the 'popup_hide' signal.
        /// </summary>
        public static readonly StringName PopupHide = "popup_hide";
    }
}
