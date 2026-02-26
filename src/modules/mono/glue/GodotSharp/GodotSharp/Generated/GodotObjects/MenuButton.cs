namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A button that brings up a <see cref="Godot.PopupMenu"/> when clicked. To create new items inside this <see cref="Godot.PopupMenu"/>, use <c>get_popup().add_item("My Item Name")</c>. You can also create them directly from Godot editor's inspector.</para>
/// <para>See also <see cref="Godot.BaseButton"/> which contains common properties and methods associated with this node.</para>
/// </summary>
public partial class MenuButton : Button
{
    /// <summary>
    /// <para>If <see langword="true"/>, when the cursor hovers above another <see cref="Godot.MenuButton"/> within the same parent which also has <see cref="Godot.MenuButton.SwitchOnHover"/> enabled, it will close the current <see cref="Godot.MenuButton"/> and open the other one.</para>
    /// </summary>
    public bool SwitchOnHover
    {
        get
        {
            return IsSwitchOnHover();
        }
        set
        {
            SetSwitchOnHover(value);
        }
    }

    /// <summary>
    /// <para>The number of items currently in the list.</para>
    /// </summary>
    public int ItemCount
    {
        get
        {
            return GetItemCount();
        }
        set
        {
            SetItemCount(value);
        }
    }

    private static readonly System.Type CachedType = typeof(MenuButton);

    private static readonly StringName NativeName = "MenuButton";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public MenuButton() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal MenuButton(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal MenuButton(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPopup, 229722558ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.PopupMenu"/> contained in this button.</para>
    /// <para><b>Warning:</b> This is a required internal node, removing and freeing it may cause a crash. If you wish to hide it or any of its children, use their <see cref="Godot.Window.Visible"/> property.</para>
    /// </summary>
    public PopupMenu GetPopup()
    {
        return (PopupMenu)NativeCalls.godot_icall_0_53(MethodBind0, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShowPopup, 3218959716ul);

    /// <summary>
    /// <para>Adjusts popup position and sizing for the <see cref="Godot.MenuButton"/>, then shows the <see cref="Godot.PopupMenu"/>. Prefer this over using <c>get_popup().popup()</c>.</para>
    /// </summary>
    public void ShowPopup()
    {
        NativeCalls.godot_icall_0_3(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSwitchOnHover, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSwitchOnHover(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind2, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsSwitchOnHover, 2240911060ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsSwitchOnHover()
    {
        return NativeCalls.godot_icall_0_15(MethodBind3, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDisableShortcuts, 2586408642ul);

    /// <summary>
    /// <para>If <see langword="true"/>, shortcuts are disabled and cannot be used to trigger the button.</para>
    /// </summary>
    public void SetDisableShortcuts(bool disabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind4, GodotObject.GetPtr(this), disabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetItemCount, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetItemCount(int count)
    {
        NativeCalls.godot_icall_1_38(MethodBind5, GodotObject.GetPtr(this), count);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetItemCount, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetItemCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind6, GodotObject.GetPtr(this));
    }

    /// <summary>
    /// <para>Emitted when the <see cref="Godot.PopupMenu"/> of this MenuButton is about to show.</para>
    /// </summary>
    public event Action AboutToPopup
    {
        add => Connect(SignalName.AboutToPopup, Callable.From(value));
        remove => Disconnect(SignalName.AboutToPopup, Callable.From(value));
    }

    protected void EmitSignalAboutToPopup()
    {
        EmitSignal(SignalName.AboutToPopup);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_about_to_popup = "AboutToPopup";

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
        if (signal == SignalName.AboutToPopup)
        {
            if (HasGodotClassSignal(SignalProxyName_about_to_popup.NativeValue.DangerousSelfRef))
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
        /// Cached name for the 'switch_on_hover' property.
        /// </summary>
        public static readonly StringName SwitchOnHover = "switch_on_hover";
        /// <summary>
        /// Cached name for the 'item_count' property.
        /// </summary>
        public static readonly StringName ItemCount = "item_count";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Button.MethodName
    {
        /// <summary>
        /// Cached name for the 'get_popup' method.
        /// </summary>
        public static readonly StringName GetPopup = "get_popup";
        /// <summary>
        /// Cached name for the 'show_popup' method.
        /// </summary>
        public static readonly StringName ShowPopup = "show_popup";
        /// <summary>
        /// Cached name for the 'set_switch_on_hover' method.
        /// </summary>
        public static readonly StringName SetSwitchOnHover = "set_switch_on_hover";
        /// <summary>
        /// Cached name for the 'is_switch_on_hover' method.
        /// </summary>
        public static readonly StringName IsSwitchOnHover = "is_switch_on_hover";
        /// <summary>
        /// Cached name for the 'set_disable_shortcuts' method.
        /// </summary>
        public static readonly StringName SetDisableShortcuts = "set_disable_shortcuts";
        /// <summary>
        /// Cached name for the 'set_item_count' method.
        /// </summary>
        public static readonly StringName SetItemCount = "set_item_count";
        /// <summary>
        /// Cached name for the 'get_item_count' method.
        /// </summary>
        public static readonly StringName GetItemCount = "get_item_count";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Button.SignalName
    {
        /// <summary>
        /// Cached name for the 'about_to_popup' signal.
        /// </summary>
        public static readonly StringName AboutToPopup = "about_to_popup";
    }
}
