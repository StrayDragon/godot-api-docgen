namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A horizontal menu bar that creates a menu for each <see cref="Godot.PopupMenu"/> child. New items are created by adding <see cref="Godot.PopupMenu"/>s to this node. Item title is determined by <see cref="Godot.Window.Title"/>, or node name if <see cref="Godot.Window.Title"/> is empty. Item title can be overridden using <see cref="Godot.MenuBar.SetMenuTitle(int, string)"/>.</para>
/// </summary>
public partial class MenuBar : Control
{
    /// <summary>
    /// <para>Flat <see cref="Godot.MenuBar"/> don't display item decoration.</para>
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
    /// <para>Position order in the global menu to insert <see cref="Godot.MenuBar"/> items at. All menu items in the <see cref="Godot.MenuBar"/> are always inserted as a continuous range. Menus with lower <see cref="Godot.MenuBar.StartIndex"/> are inserted first. Menus with <see cref="Godot.MenuBar.StartIndex"/> equal to <c>-1</c> are inserted last.</para>
    /// </summary>
    public int StartIndex
    {
        get
        {
            return GetStartIndex();
        }
        set
        {
            SetStartIndex(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, when the cursor hovers above menu item, it will close the current <see cref="Godot.PopupMenu"/> and open the other one.</para>
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
    /// <para>If <see langword="true"/>, <see cref="Godot.MenuBar"/> will use system global menu when supported.</para>
    /// <para><b>Note:</b> If <see langword="true"/> and global menu is supported, this node is not displayed, has zero size, and all its child nodes except <see cref="Godot.PopupMenu"/>s are inaccessible.</para>
    /// <para><b>Note:</b> This property overrides the value of the <see cref="Godot.PopupMenu.PreferNativeMenu"/> property of the child nodes.</para>
    /// </summary>
    public bool PreferGlobalMenu
    {
        get
        {
            return IsPreferGlobalMenu();
        }
        set
        {
            SetPreferGlobalMenu(value);
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

    private static readonly System.Type CachedType = typeof(MenuBar);

    private static readonly StringName NativeName = "MenuBar";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public MenuBar() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal MenuBar(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal MenuBar(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSwitchOnHover, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSwitchOnHover(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind0, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsSwitchOnHover, 2240911060ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsSwitchOnHover()
    {
        return NativeCalls.godot_icall_0_15(MethodBind1, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDisableShortcuts, 2586408642ul);

    /// <summary>
    /// <para>If <see langword="true"/>, shortcuts are disabled and cannot be used to trigger the button.</para>
    /// </summary>
    public void SetDisableShortcuts(bool disabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind2, GodotObject.GetPtr(this), disabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPreferGlobalMenu, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPreferGlobalMenu(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind3, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsPreferGlobalMenu, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsPreferGlobalMenu()
    {
        return NativeCalls.godot_icall_0_15(MethodBind4, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsNativeMenu, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the current system's global menu is supported and used by this <see cref="Godot.MenuBar"/>.</para>
    /// </summary>
    public bool IsNativeMenu()
    {
        return NativeCalls.godot_icall_0_15(MethodBind5, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMenuCount, 3905245786ul);

    /// <summary>
    /// <para>Returns number of menu items.</para>
    /// </summary>
    public int GetMenuCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind6, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTextDirection, 119160795ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTextDirection(Control.TextDirection direction)
    {
        NativeCalls.godot_icall_1_38(MethodBind7, GodotObject.GetPtr(this), (int)direction);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTextDirection, 797257663ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Control.TextDirection GetTextDirection()
    {
        return (Control.TextDirection)NativeCalls.godot_icall_0_39(MethodBind8, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLanguage, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetLanguage(string language)
    {
        NativeCalls.godot_icall_1_57(MethodBind9, GodotObject.GetPtr(this), language);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLanguage, 201670096ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetLanguage()
    {
        return NativeCalls.godot_icall_0_58(MethodBind10, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFlat, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFlat(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind11, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsFlat, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsFlat()
    {
        return NativeCalls.godot_icall_0_15(MethodBind12, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetStartIndex, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetStartIndex(int enabled)
    {
        NativeCalls.godot_icall_1_38(MethodBind13, GodotObject.GetPtr(this), enabled);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetStartIndex, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetStartIndex()
    {
        return NativeCalls.godot_icall_0_39(MethodBind14, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMenuTitle, 501894301ul);

    /// <summary>
    /// <para>Sets menu item title.</para>
    /// </summary>
    public void SetMenuTitle(int menu, string title)
    {
        NativeCalls.godot_icall_2_181(MethodBind15, GodotObject.GetPtr(this), menu, title);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMenuTitle, 844755477ul);

    /// <summary>
    /// <para>Returns menu item title.</para>
    /// </summary>
    public string GetMenuTitle(int menu)
    {
        return NativeCalls.godot_icall_1_133(MethodBind16, GodotObject.GetPtr(this), menu);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMenuTooltip, 501894301ul);

    /// <summary>
    /// <para>Sets menu item tooltip.</para>
    /// </summary>
    public void SetMenuTooltip(int menu, string tooltip)
    {
        NativeCalls.godot_icall_2_181(MethodBind17, GodotObject.GetPtr(this), menu, tooltip);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMenuTooltip, 844755477ul);

    /// <summary>
    /// <para>Returns menu item tooltip.</para>
    /// </summary>
    public string GetMenuTooltip(int menu)
    {
        return NativeCalls.godot_icall_1_133(MethodBind18, GodotObject.GetPtr(this), menu);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMenuDisabled, 300928843ul);

    /// <summary>
    /// <para>If <see langword="true"/>, menu item is disabled.</para>
    /// </summary>
    public void SetMenuDisabled(int menu, bool disabled)
    {
        NativeCalls.godot_icall_2_61(MethodBind19, GodotObject.GetPtr(this), menu, disabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsMenuDisabled, 1116898809ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the menu item is disabled.</para>
    /// </summary>
    public bool IsMenuDisabled(int menu)
    {
        return NativeCalls.godot_icall_1_62(MethodBind20, GodotObject.GetPtr(this), menu).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMenuHidden, 300928843ul);

    /// <summary>
    /// <para>If <see langword="true"/>, menu item is hidden.</para>
    /// </summary>
    public void SetMenuHidden(int menu, bool hidden)
    {
        NativeCalls.godot_icall_2_61(MethodBind21, GodotObject.GetPtr(this), menu, hidden.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsMenuHidden, 1116898809ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the menu item is hidden.</para>
    /// </summary>
    public bool IsMenuHidden(int menu)
    {
        return NativeCalls.godot_icall_1_62(MethodBind22, GodotObject.GetPtr(this), menu).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMenuPopup, 2100501353ul);

    /// <summary>
    /// <para>Returns <see cref="Godot.PopupMenu"/> associated with menu item.</para>
    /// </summary>
    public PopupMenu GetMenuPopup(int menu)
    {
        return (PopupMenu)NativeCalls.godot_icall_1_335(MethodBind23, GodotObject.GetPtr(this), menu);
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
    public new class PropertyName : Control.PropertyName
    {
        /// <summary>
        /// Cached name for the 'flat' property.
        /// </summary>
        public static readonly StringName Flat = "flat";
        /// <summary>
        /// Cached name for the 'start_index' property.
        /// </summary>
        public static readonly StringName StartIndex = "start_index";
        /// <summary>
        /// Cached name for the 'switch_on_hover' property.
        /// </summary>
        public static readonly StringName SwitchOnHover = "switch_on_hover";
        /// <summary>
        /// Cached name for the 'prefer_global_menu' property.
        /// </summary>
        public static readonly StringName PreferGlobalMenu = "prefer_global_menu";
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
    public new class MethodName : Control.MethodName
    {
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
        /// Cached name for the 'set_prefer_global_menu' method.
        /// </summary>
        public static readonly StringName SetPreferGlobalMenu = "set_prefer_global_menu";
        /// <summary>
        /// Cached name for the 'is_prefer_global_menu' method.
        /// </summary>
        public static readonly StringName IsPreferGlobalMenu = "is_prefer_global_menu";
        /// <summary>
        /// Cached name for the 'is_native_menu' method.
        /// </summary>
        public static readonly StringName IsNativeMenu = "is_native_menu";
        /// <summary>
        /// Cached name for the 'get_menu_count' method.
        /// </summary>
        public static readonly StringName GetMenuCount = "get_menu_count";
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
        /// Cached name for the 'set_flat' method.
        /// </summary>
        public static readonly StringName SetFlat = "set_flat";
        /// <summary>
        /// Cached name for the 'is_flat' method.
        /// </summary>
        public static readonly StringName IsFlat = "is_flat";
        /// <summary>
        /// Cached name for the 'set_start_index' method.
        /// </summary>
        public static readonly StringName SetStartIndex = "set_start_index";
        /// <summary>
        /// Cached name for the 'get_start_index' method.
        /// </summary>
        public static readonly StringName GetStartIndex = "get_start_index";
        /// <summary>
        /// Cached name for the 'set_menu_title' method.
        /// </summary>
        public static readonly StringName SetMenuTitle = "set_menu_title";
        /// <summary>
        /// Cached name for the 'get_menu_title' method.
        /// </summary>
        public static readonly StringName GetMenuTitle = "get_menu_title";
        /// <summary>
        /// Cached name for the 'set_menu_tooltip' method.
        /// </summary>
        public static readonly StringName SetMenuTooltip = "set_menu_tooltip";
        /// <summary>
        /// Cached name for the 'get_menu_tooltip' method.
        /// </summary>
        public static readonly StringName GetMenuTooltip = "get_menu_tooltip";
        /// <summary>
        /// Cached name for the 'set_menu_disabled' method.
        /// </summary>
        public static readonly StringName SetMenuDisabled = "set_menu_disabled";
        /// <summary>
        /// Cached name for the 'is_menu_disabled' method.
        /// </summary>
        public static readonly StringName IsMenuDisabled = "is_menu_disabled";
        /// <summary>
        /// Cached name for the 'set_menu_hidden' method.
        /// </summary>
        public static readonly StringName SetMenuHidden = "set_menu_hidden";
        /// <summary>
        /// Cached name for the 'is_menu_hidden' method.
        /// </summary>
        public static readonly StringName IsMenuHidden = "is_menu_hidden";
        /// <summary>
        /// Cached name for the 'get_menu_popup' method.
        /// </summary>
        public static readonly StringName GetMenuPopup = "get_menu_popup";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Control.SignalName
    {
    }
}
