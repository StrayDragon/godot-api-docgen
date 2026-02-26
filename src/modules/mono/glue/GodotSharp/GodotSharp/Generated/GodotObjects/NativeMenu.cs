namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para><see cref="Godot.NativeMenu"/> handles low-level access to the OS native global menu bar and popup menus.</para>
/// <para><b>Note:</b> This is low-level API, consider using <see cref="Godot.MenuBar"/> with <see cref="Godot.MenuBar.PreferGlobalMenu"/> set to <see langword="true"/>, and <see cref="Godot.PopupMenu"/> with <see cref="Godot.PopupMenu.PreferNativeMenu"/> set to <see langword="true"/>.</para>
/// <para>To create a menu, use <see cref="Godot.NativeMenu.CreateMenu()"/>, add menu items using <c>add_*_item</c> methods. To remove a menu, use <see cref="Godot.NativeMenu.FreeMenu(Rid)"/>.</para>
/// <para><code>
/// var menu
/// 
/// func _menu_callback(item_id):
/// 	if item_id == "ITEM_CUT":
/// 		cut()
/// 	elif item_id == "ITEM_COPY":
/// 		copy()
/// 	elif item_id == "ITEM_PASTE":
/// 		paste()
/// 
/// func _enter_tree():
/// 	# Create new menu and add items:
/// 	menu = NativeMenu.create_menu()
/// 	NativeMenu.add_item(menu, "Cut", _menu_callback, Callable(), "ITEM_CUT")
/// 	NativeMenu.add_item(menu, "Copy", _menu_callback, Callable(), "ITEM_COPY")
/// 	NativeMenu.add_separator(menu)
/// 	NativeMenu.add_item(menu, "Paste", _menu_callback, Callable(), "ITEM_PASTE")
/// 
/// func _on_button_pressed():
/// 	# Show popup menu at mouse position:
/// 	NativeMenu.popup(menu, DisplayServer.mouse_get_position())
/// 
/// func _exit_tree():
/// 	# Remove menu when it's no longer needed:
/// 	NativeMenu.free_menu(menu)
/// </code></para>
/// </summary>
public static partial class NativeMenu
{
    public enum Feature : long
    {
        /// <summary>
        /// <para><see cref="Godot.NativeMenu"/> supports native global main menu.</para>
        /// </summary>
        GlobalMenu = 0,
        /// <summary>
        /// <para><see cref="Godot.NativeMenu"/> supports native popup menus.</para>
        /// </summary>
        PopupMenu = 1,
        /// <summary>
        /// <para><see cref="Godot.NativeMenu"/> supports menu open and close callbacks.</para>
        /// </summary>
        OpenCloseCallback = 2,
        /// <summary>
        /// <para><see cref="Godot.NativeMenu"/> supports menu item hover callback.</para>
        /// </summary>
        HoverCallback = 3,
        /// <summary>
        /// <para><see cref="Godot.NativeMenu"/> supports menu item accelerator/key callback.</para>
        /// </summary>
        KeyCallback = 4
    }

    public enum SystemMenus : long
    {
        /// <summary>
        /// <para>Invalid special system menu ID.</para>
        /// </summary>
        InvalidMenuId = 0,
        /// <summary>
        /// <para>Global main menu ID.</para>
        /// </summary>
        MainMenuId = 1,
        /// <summary>
        /// <para>Application (first menu after "Apple" menu on macOS) menu ID.</para>
        /// </summary>
        ApplicationMenuId = 2,
        /// <summary>
        /// <para>"Window" menu ID (on macOS this menu includes standard window control items and a list of open windows).</para>
        /// </summary>
        WindowMenuId = 3,
        /// <summary>
        /// <para>"Help" menu ID (on macOS this menu includes help search bar).</para>
        /// </summary>
        HelpMenuId = 4,
        /// <summary>
        /// <para>Dock icon right-click menu ID (on macOS this menu include standard application control items and a list of open windows).</para>
        /// </summary>
        DockMenuId = 5
    }

    private static readonly StringName NativeName = "NativeMenu";

    private static NativeMenuInstance singleton;

    public static NativeMenuInstance Singleton =>
        singleton ??= (NativeMenuInstance)InteropUtils.EngineGetSingleton("NativeMenu");

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.HasFeature, 1708975490ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the specified <paramref name="feature"/> is supported by the current <see cref="Godot.NativeMenu"/>, <see langword="false"/> otherwise.</para>
    /// <para><b>Note:</b> This method is implemented on macOS and Windows.</para>
    /// </summary>
    public static bool HasFeature(NativeMenu.Feature feature)
    {
        return NativeCalls.godot_icall_1_62(MethodBind0, GodotObject.GetPtr(Singleton), (int)feature).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.HasSystemMenu, 718213027ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if a special system menu is supported.</para>
    /// <para><b>Note:</b> This method is implemented only on macOS.</para>
    /// </summary>
    public static bool HasSystemMenu(NativeMenu.SystemMenus menuId)
    {
        return NativeCalls.godot_icall_1_62(MethodBind1, GodotObject.GetPtr(Singleton), (int)menuId).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSystemMenu, 469707506ul);

    /// <summary>
    /// <para>Returns RID of a special system menu.</para>
    /// <para><b>Note:</b> This method is implemented only on macOS.</para>
    /// </summary>
    public static Rid GetSystemMenu(NativeMenu.SystemMenus menuId)
    {
        return NativeCalls.godot_icall_1_425(MethodBind2, GodotObject.GetPtr(Singleton), (int)menuId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSystemMenuName, 1281499290ul);

    /// <summary>
    /// <para>Returns readable name of a special system menu.</para>
    /// <para><b>Note:</b> This method is implemented only on macOS.</para>
    /// </summary>
    public static string GetSystemMenuName(NativeMenu.SystemMenus menuId)
    {
        return NativeCalls.godot_icall_1_133(MethodBind3, GodotObject.GetPtr(Singleton), (int)menuId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSystemMenuText, 1281499290ul);

    /// <summary>
    /// <para>Returns the text of the system menu item.</para>
    /// <para><b>Note:</b> This method is implemented on macOS.</para>
    /// </summary>
    public static string GetSystemMenuText(NativeMenu.SystemMenus menuId)
    {
        return NativeCalls.godot_icall_1_133(MethodBind4, GodotObject.GetPtr(Singleton), (int)menuId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSystemMenuText, 3925225603ul);

    /// <summary>
    /// <para>Sets the text of the system menu item.</para>
    /// <para><b>Note:</b> This method is implemented on macOS.</para>
    /// </summary>
    public static void SetSystemMenuText(NativeMenu.SystemMenus menuId, string name)
    {
        NativeCalls.godot_icall_2_181(MethodBind5, GodotObject.GetPtr(Singleton), (int)menuId, name);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CreateMenu, 529393457ul);

    /// <summary>
    /// <para>Creates a new global menu object.</para>
    /// <para><b>Note:</b> This method is implemented on macOS and Windows.</para>
    /// </summary>
    public static Rid CreateMenu()
    {
        return NativeCalls.godot_icall_0_238(MethodBind6, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.HasMenu, 4155700596ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if <paramref name="rid"/> is valid global menu.</para>
    /// <para><b>Note:</b> This method is implemented on macOS and Windows.</para>
    /// </summary>
    public static bool HasMenu(Rid rid)
    {
        return NativeCalls.godot_icall_1_421(MethodBind7, GodotObject.GetPtr(Singleton), rid).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.FreeMenu, 2722037293ul);

    /// <summary>
    /// <para>Frees a global menu object created by this <see cref="Godot.NativeMenu"/>.</para>
    /// <para><b>Note:</b> This method is implemented on macOS and Windows.</para>
    /// </summary>
    public static void FreeMenu(Rid rid)
    {
        NativeCalls.godot_icall_1_286(MethodBind8, GodotObject.GetPtr(Singleton), rid);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSize, 2440833711ul);

    /// <summary>
    /// <para>Returns global menu size.</para>
    /// <para><b>Note:</b> This method is implemented on macOS and Windows.</para>
    /// </summary>
    public static Vector2 GetSize(Rid rid)
    {
        return NativeCalls.godot_icall_1_812(MethodBind9, GodotObject.GetPtr(Singleton), rid);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.Popup, 2450610377ul);

    /// <summary>
    /// <para>Shows the global menu at <paramref name="position"/> in the screen coordinates.</para>
    /// <para><b>Note:</b> This method is implemented on macOS and Windows.</para>
    /// </summary>
    public static unsafe void Popup(Rid rid, Vector2I position)
    {
        NativeCalls.godot_icall_2_813(MethodBind10, GodotObject.GetPtr(Singleton), rid, &position);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SetInterfaceDirection, 1265174801ul);

    /// <summary>
    /// <para>Sets the menu text layout direction from right-to-left if <paramref name="isRtl"/> is <see langword="true"/>.</para>
    /// <para><b>Note:</b> This method is implemented on macOS and Windows.</para>
    /// </summary>
    public static void SetInterfaceDirection(Rid rid, bool isRtl)
    {
        NativeCalls.godot_icall_2_434(MethodBind11, GodotObject.GetPtr(Singleton), rid, isRtl.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPopupOpenCallback, 3379118538ul);

    /// <summary>
    /// <para>Registers callable to emit after the menu is closed.</para>
    /// <para><b>Note:</b> This method is implemented only on macOS.</para>
    /// </summary>
    public static void SetPopupOpenCallback(Rid rid, Callable callback)
    {
        NativeCalls.godot_icall_2_814(MethodBind12, GodotObject.GetPtr(Singleton), rid, callback);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPopupOpenCallback, 3170603026ul);

    /// <summary>
    /// <para>Returns global menu open callback.</para>
    /// <para><b>Note:</b> This method is implemented only on macOS.</para>
    /// </summary>
    public static Callable GetPopupOpenCallback(Rid rid)
    {
        return NativeCalls.godot_icall_1_815(MethodBind13, GodotObject.GetPtr(Singleton), rid);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPopupCloseCallback, 3379118538ul);

    /// <summary>
    /// <para>Registers callable to emit when the menu is about to show.</para>
    /// <para><b>Note:</b> The OS can simulate menu opening to track menu item changes and global shortcuts, in which case the corresponding close callback is not triggered. Use <see cref="Godot.NativeMenu.IsOpened(Rid)"/> to check if the menu is currently opened.</para>
    /// <para><b>Note:</b> This method is implemented on macOS and Windows.</para>
    /// </summary>
    public static void SetPopupCloseCallback(Rid rid, Callable callback)
    {
        NativeCalls.godot_icall_2_814(MethodBind14, GodotObject.GetPtr(Singleton), rid, callback);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPopupCloseCallback, 3170603026ul);

    /// <summary>
    /// <para>Returns global menu close callback.</para>
    /// <para><b>Note:</b> This method is implemented on macOS and Windows.</para>
    /// </summary>
    public static Callable GetPopupCloseCallback(Rid rid)
    {
        return NativeCalls.godot_icall_1_815(MethodBind15, GodotObject.GetPtr(Singleton), rid);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMinimumWidth, 1794382983ul);

    /// <summary>
    /// <para>Sets the minimum width of the global menu.</para>
    /// <para><b>Note:</b> This method is implemented only on macOS.</para>
    /// </summary>
    public static void SetMinimumWidth(Rid rid, float width)
    {
        NativeCalls.godot_icall_2_816(MethodBind16, GodotObject.GetPtr(Singleton), rid, width);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMinimumWidth, 866169185ul);

    /// <summary>
    /// <para>Returns global menu minimum width.</para>
    /// <para><b>Note:</b> This method is implemented only on macOS.</para>
    /// </summary>
    public static float GetMinimumWidth(Rid rid)
    {
        return NativeCalls.godot_icall_1_817(MethodBind17, GodotObject.GetPtr(Singleton), rid);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.IsOpened, 4155700596ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the menu is currently opened.</para>
    /// <para><b>Note:</b> This method is implemented only on macOS.</para>
    /// </summary>
    public static bool IsOpened(Rid rid)
    {
        return NativeCalls.godot_icall_1_421(MethodBind18, GodotObject.GetPtr(Singleton), rid).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AddSubmenuItem, 1002030223ul);

    /// <summary>
    /// <para>Adds an item that will act as a submenu of the global menu <paramref name="rid"/>. The <paramref name="submenuRid"/> argument is the RID of the global menu that will be shown when the item is clicked.</para>
    /// <para>Returns index of the inserted item, it's not guaranteed to be the same as <paramref name="index"/> value.</para>
    /// <para><b>Note:</b> This method is implemented on macOS and Windows.</para>
    /// </summary>
    public static int AddSubmenuItem(Rid rid, string label, Rid submenuRid, Variant tag = default, int index = -1)
    {
        return NativeCalls.godot_icall_5_818(MethodBind19, GodotObject.GetPtr(Singleton), rid, label, submenuRid, tag, index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AddItem, 980552939ul);

    /// <summary>
    /// <para>Adds a new item with text <paramref name="label"/> to the global menu <paramref name="rid"/>.</para>
    /// <para>Returns index of the inserted item, it's not guaranteed to be the same as <paramref name="index"/> value.</para>
    /// <para>An <paramref name="accelerator"/> can optionally be defined, which is a keyboard shortcut that can be pressed to trigger the menu button even if it's not currently open. The <paramref name="accelerator"/> is generally a combination of <see cref="Godot.KeyModifierMask"/>s and <see cref="Godot.Key"/>s using bitwise OR such as <c>KEY_MASK_CTRL | KEY_A</c> (Ctrl + A).</para>
    /// <para><b>Note:</b> The <paramref name="callback"/> and <paramref name="keyCallback"/> Callables need to accept exactly one Variant parameter, the parameter passed to the Callables will be the value passed to <paramref name="tag"/>.</para>
    /// <para><b>Note:</b> This method is implemented on macOS and Windows.</para>
    /// <para><b>Note:</b> On Windows, <paramref name="accelerator"/> and <paramref name="keyCallback"/> are ignored.</para>
    /// </summary>
    public static int AddItem(Rid rid, string label, Callable callback = default, Callable keyCallback = default, Variant tag = default, Key accelerator = (Key)(0), int index = -1)
    {
        return NativeCalls.godot_icall_7_819(MethodBind20, GodotObject.GetPtr(Singleton), rid, label, callback, keyCallback, tag, (int)accelerator, index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AddCheckItem, 980552939ul);

    /// <summary>
    /// <para>Adds a new checkable item with text <paramref name="label"/> to the global menu <paramref name="rid"/>.</para>
    /// <para>Returns index of the inserted item, it's not guaranteed to be the same as <paramref name="index"/> value.</para>
    /// <para>An <paramref name="accelerator"/> can optionally be defined, which is a keyboard shortcut that can be pressed to trigger the menu button even if it's not currently open. The <paramref name="accelerator"/> is generally a combination of <see cref="Godot.KeyModifierMask"/>s and <see cref="Godot.Key"/>s using bitwise OR such as <c>KEY_MASK_CTRL | KEY_A</c> (Ctrl + A).</para>
    /// <para><b>Note:</b> The <paramref name="callback"/> and <paramref name="keyCallback"/> Callables need to accept exactly one Variant parameter, the parameter passed to the Callables will be the value passed to <paramref name="tag"/>.</para>
    /// <para><b>Note:</b> This method is implemented on macOS and Windows.</para>
    /// <para><b>Note:</b> On Windows, <paramref name="accelerator"/> and <paramref name="keyCallback"/> are ignored.</para>
    /// </summary>
    public static int AddCheckItem(Rid rid, string label, Callable callback = default, Callable keyCallback = default, Variant tag = default, Key accelerator = (Key)(0), int index = -1)
    {
        return NativeCalls.godot_icall_7_819(MethodBind21, GodotObject.GetPtr(Singleton), rid, label, callback, keyCallback, tag, (int)accelerator, index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AddIconItem, 1372188274ul);

    /// <summary>
    /// <para>Adds a new item with text <paramref name="label"/> and icon <paramref name="icon"/> to the global menu <paramref name="rid"/>.</para>
    /// <para>Returns index of the inserted item, it's not guaranteed to be the same as <paramref name="index"/> value.</para>
    /// <para>An <paramref name="accelerator"/> can optionally be defined, which is a keyboard shortcut that can be pressed to trigger the menu button even if it's not currently open. The <paramref name="accelerator"/> is generally a combination of <see cref="Godot.KeyModifierMask"/>s and <see cref="Godot.Key"/>s using bitwise OR such as <c>KEY_MASK_CTRL | KEY_A</c> (Ctrl + A).</para>
    /// <para><b>Note:</b> The <paramref name="callback"/> and <paramref name="keyCallback"/> Callables need to accept exactly one Variant parameter, the parameter passed to the Callables will be the value passed to <paramref name="tag"/>.</para>
    /// <para><b>Note:</b> This method is implemented on macOS and Windows.</para>
    /// <para><b>Note:</b> On Windows, <paramref name="accelerator"/> and <paramref name="keyCallback"/> are ignored.</para>
    /// </summary>
    public static int AddIconItem(Rid rid, Texture2D icon, string label, Callable callback = default, Callable keyCallback = default, Variant tag = default, Key accelerator = (Key)(0), int index = -1)
    {
        return NativeCalls.godot_icall_8_820(MethodBind22, GodotObject.GetPtr(Singleton), rid, GodotObject.GetPtr(icon), label, callback, keyCallback, tag, (int)accelerator, index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AddIconCheckItem, 1372188274ul);

    /// <summary>
    /// <para>Adds a new checkable item with text <paramref name="label"/> and icon <paramref name="icon"/> to the global menu <paramref name="rid"/>.</para>
    /// <para>Returns index of the inserted item, it's not guaranteed to be the same as <paramref name="index"/> value.</para>
    /// <para>An <paramref name="accelerator"/> can optionally be defined, which is a keyboard shortcut that can be pressed to trigger the menu button even if it's not currently open. The <paramref name="accelerator"/> is generally a combination of <see cref="Godot.KeyModifierMask"/>s and <see cref="Godot.Key"/>s using bitwise OR such as <c>KEY_MASK_CTRL | KEY_A</c> (Ctrl + A).</para>
    /// <para><b>Note:</b> The <paramref name="callback"/> and <paramref name="keyCallback"/> Callables need to accept exactly one Variant parameter, the parameter passed to the Callables will be the value passed to <paramref name="tag"/>.</para>
    /// <para><b>Note:</b> This method is implemented on macOS and Windows.</para>
    /// <para><b>Note:</b> On Windows, <paramref name="accelerator"/> and <paramref name="keyCallback"/> are ignored.</para>
    /// </summary>
    public static int AddIconCheckItem(Rid rid, Texture2D icon, string label, Callable callback = default, Callable keyCallback = default, Variant tag = default, Key accelerator = (Key)(0), int index = -1)
    {
        return NativeCalls.godot_icall_8_820(MethodBind23, GodotObject.GetPtr(Singleton), rid, GodotObject.GetPtr(icon), label, callback, keyCallback, tag, (int)accelerator, index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AddRadioCheckItem, 980552939ul);

    /// <summary>
    /// <para>Adds a new radio-checkable item with text <paramref name="label"/> to the global menu <paramref name="rid"/>.</para>
    /// <para>Returns index of the inserted item, it's not guaranteed to be the same as <paramref name="index"/> value.</para>
    /// <para>An <paramref name="accelerator"/> can optionally be defined, which is a keyboard shortcut that can be pressed to trigger the menu button even if it's not currently open. The <paramref name="accelerator"/> is generally a combination of <see cref="Godot.KeyModifierMask"/>s and <see cref="Godot.Key"/>s using bitwise OR such as <c>KEY_MASK_CTRL | KEY_A</c> (Ctrl + A).</para>
    /// <para><b>Note:</b> Radio-checkable items just display a checkmark, but don't have any built-in checking behavior and must be checked/unchecked manually. See <see cref="Godot.NativeMenu.SetItemChecked(Rid, int, bool)"/> for more info on how to control it.</para>
    /// <para><b>Note:</b> The <paramref name="callback"/> and <paramref name="keyCallback"/> Callables need to accept exactly one Variant parameter, the parameter passed to the Callables will be the value passed to <paramref name="tag"/>.</para>
    /// <para><b>Note:</b> This method is implemented on macOS and Windows.</para>
    /// <para><b>Note:</b> On Windows, <paramref name="accelerator"/> and <paramref name="keyCallback"/> are ignored.</para>
    /// </summary>
    public static int AddRadioCheckItem(Rid rid, string label, Callable callback = default, Callable keyCallback = default, Variant tag = default, Key accelerator = (Key)(0), int index = -1)
    {
        return NativeCalls.godot_icall_7_819(MethodBind24, GodotObject.GetPtr(Singleton), rid, label, callback, keyCallback, tag, (int)accelerator, index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AddIconRadioCheckItem, 1372188274ul);

    /// <summary>
    /// <para>Adds a new radio-checkable item with text <paramref name="label"/> and icon <paramref name="icon"/> to the global menu <paramref name="rid"/>.</para>
    /// <para>Returns index of the inserted item, it's not guaranteed to be the same as <paramref name="index"/> value.</para>
    /// <para>An <paramref name="accelerator"/> can optionally be defined, which is a keyboard shortcut that can be pressed to trigger the menu button even if it's not currently open. The <paramref name="accelerator"/> is generally a combination of <see cref="Godot.KeyModifierMask"/>s and <see cref="Godot.Key"/>s using bitwise OR such as <c>KEY_MASK_CTRL | KEY_A</c> (Ctrl + A).</para>
    /// <para><b>Note:</b> Radio-checkable items just display a checkmark, but don't have any built-in checking behavior and must be checked/unchecked manually. See <see cref="Godot.NativeMenu.SetItemChecked(Rid, int, bool)"/> for more info on how to control it.</para>
    /// <para><b>Note:</b> The <paramref name="callback"/> and <paramref name="keyCallback"/> Callables need to accept exactly one Variant parameter, the parameter passed to the Callables will be the value passed to <paramref name="tag"/>.</para>
    /// <para><b>Note:</b> This method is implemented on macOS and Windows.</para>
    /// <para><b>Note:</b> On Windows, <paramref name="accelerator"/> and <paramref name="keyCallback"/> are ignored.</para>
    /// </summary>
    public static int AddIconRadioCheckItem(Rid rid, Texture2D icon, string label, Callable callback = default, Callable keyCallback = default, Variant tag = default, Key accelerator = (Key)(0), int index = -1)
    {
        return NativeCalls.godot_icall_8_820(MethodBind25, GodotObject.GetPtr(Singleton), rid, GodotObject.GetPtr(icon), label, callback, keyCallback, tag, (int)accelerator, index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AddMultistateItem, 2674635658ul);

    /// <summary>
    /// <para>Adds a new item with text <paramref name="label"/> to the global menu <paramref name="rid"/>.</para>
    /// <para>Contrarily to normal binary items, multistate items can have more than two states, as defined by <paramref name="maxStates"/>. Each press or activate of the item will increase the state by one. The default value is defined by <paramref name="defaultState"/>.</para>
    /// <para>Returns index of the inserted item, it's not guaranteed to be the same as <paramref name="index"/> value.</para>
    /// <para>An <paramref name="accelerator"/> can optionally be defined, which is a keyboard shortcut that can be pressed to trigger the menu button even if it's not currently open. The <paramref name="accelerator"/> is generally a combination of <see cref="Godot.KeyModifierMask"/>s and <see cref="Godot.Key"/>s using bitwise OR such as <c>KEY_MASK_CTRL | KEY_A</c> (Ctrl + A).</para>
    /// <para><b>Note:</b> By default, there's no indication of the current item state, it should be changed manually.</para>
    /// <para><b>Note:</b> The <paramref name="callback"/> and <paramref name="keyCallback"/> Callables need to accept exactly one Variant parameter, the parameter passed to the Callables will be the value passed to <paramref name="tag"/>.</para>
    /// <para><b>Note:</b> This method is implemented on macOS and Windows.</para>
    /// <para><b>Note:</b> On Windows, <paramref name="accelerator"/> and <paramref name="keyCallback"/> are ignored.</para>
    /// </summary>
    public static int AddMultistateItem(Rid rid, string label, int maxStates, int defaultState, Callable callback = default, Callable keyCallback = default, Variant tag = default, Key accelerator = (Key)(0), int index = -1)
    {
        return NativeCalls.godot_icall_9_821(MethodBind26, GodotObject.GetPtr(Singleton), rid, label, maxStates, defaultState, callback, keyCallback, tag, (int)accelerator, index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AddSeparator, 448810126ul);

    /// <summary>
    /// <para>Adds a separator between items to the global menu <paramref name="rid"/>. Separators also occupy an index.</para>
    /// <para>Returns index of the inserted item, it's not guaranteed to be the same as <paramref name="index"/> value.</para>
    /// <para><b>Note:</b> This method is implemented on macOS and Windows.</para>
    /// </summary>
    public static int AddSeparator(Rid rid, int index = -1)
    {
        return NativeCalls.godot_icall_2_822(MethodBind27, GodotObject.GetPtr(Singleton), rid, index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.FindItemIndexWithText, 1362438794ul);

    /// <summary>
    /// <para>Returns the index of the item with the specified <paramref name="text"/>. Indices are automatically assigned to each item by the engine, and cannot be set manually.</para>
    /// <para><b>Note:</b> This method is implemented on macOS and Windows.</para>
    /// </summary>
    public static int FindItemIndexWithText(Rid rid, string text)
    {
        return NativeCalls.godot_icall_2_823(MethodBind28, GodotObject.GetPtr(Singleton), rid, text);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.FindItemIndexWithTag, 1260085030ul);

    /// <summary>
    /// <para>Returns the index of the item with the specified <paramref name="tag"/>. Indices are automatically assigned to each item by the engine, and cannot be set manually.</para>
    /// <para><b>Note:</b> This method is implemented on macOS and Windows.</para>
    /// </summary>
    public static int FindItemIndexWithTag(Rid rid, Variant tag)
    {
        return NativeCalls.godot_icall_2_824(MethodBind29, GodotObject.GetPtr(Singleton), rid, tag);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.FindItemIndexWithSubmenu, 893635918ul);

    /// <summary>
    /// <para>Returns the index of the item with the submenu specified by <paramref name="submenuRid"/>. Indices are automatically assigned to each item by the engine, and cannot be set manually.</para>
    /// <para><b>Note:</b> This method is implemented on macOS and Windows.</para>
    /// </summary>
    public static int FindItemIndexWithSubmenu(Rid rid, Rid submenuRid)
    {
        return NativeCalls.godot_icall_2_825(MethodBind30, GodotObject.GetPtr(Singleton), rid, submenuRid);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.IsItemChecked, 3120086654ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the item at index <paramref name="idx"/> is checked.</para>
    /// <para><b>Note:</b> This method is implemented on macOS and Windows.</para>
    /// </summary>
    public static bool IsItemChecked(Rid rid, int idx)
    {
        return NativeCalls.godot_icall_2_826(MethodBind31, GodotObject.GetPtr(Singleton), rid, idx).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind32 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.IsItemCheckable, 3120086654ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the item at index <paramref name="idx"/> is checkable in some way, i.e. if it has a checkbox or radio button.</para>
    /// <para><b>Note:</b> This method is implemented on macOS and Windows.</para>
    /// </summary>
    public static bool IsItemCheckable(Rid rid, int idx)
    {
        return NativeCalls.godot_icall_2_826(MethodBind32, GodotObject.GetPtr(Singleton), rid, idx).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind33 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.IsItemRadioCheckable, 3120086654ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the item at index <paramref name="idx"/> has radio button-style checkability.</para>
    /// <para><b>Note:</b> This is purely cosmetic; you must add the logic for checking/unchecking items in radio groups.</para>
    /// <para><b>Note:</b> This method is implemented on macOS and Windows.</para>
    /// </summary>
    public static bool IsItemRadioCheckable(Rid rid, int idx)
    {
        return NativeCalls.godot_icall_2_826(MethodBind33, GodotObject.GetPtr(Singleton), rid, idx).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind34 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetItemCallback, 1639989698ul);

    /// <summary>
    /// <para>Returns the callback of the item at index <paramref name="idx"/>.</para>
    /// <para><b>Note:</b> This method is implemented on macOS and Windows.</para>
    /// </summary>
    public static Callable GetItemCallback(Rid rid, int idx)
    {
        return NativeCalls.godot_icall_2_827(MethodBind34, GodotObject.GetPtr(Singleton), rid, idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind35 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetItemKeyCallback, 1639989698ul);

    /// <summary>
    /// <para>Returns the callback of the item accelerator at index <paramref name="idx"/>.</para>
    /// <para><b>Note:</b> This method is implemented only on macOS.</para>
    /// </summary>
    public static Callable GetItemKeyCallback(Rid rid, int idx)
    {
        return NativeCalls.godot_icall_2_827(MethodBind35, GodotObject.GetPtr(Singleton), rid, idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind36 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetItemTag, 4069510997ul);

    /// <summary>
    /// <para>Returns the metadata of the specified item, which might be of any type. You can set it with <see cref="Godot.NativeMenu.SetItemTag(Rid, int, Variant)"/>, which provides a simple way of assigning context data to items.</para>
    /// <para><b>Note:</b> This method is implemented on macOS and Windows.</para>
    /// </summary>
    public static Variant GetItemTag(Rid rid, int idx)
    {
        return NativeCalls.godot_icall_2_828(MethodBind36, GodotObject.GetPtr(Singleton), rid, idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind37 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetItemText, 1464764419ul);

    /// <summary>
    /// <para>Returns the text of the item at index <paramref name="idx"/>.</para>
    /// <para><b>Note:</b> This method is implemented on macOS and Windows.</para>
    /// </summary>
    public static string GetItemText(Rid rid, int idx)
    {
        return NativeCalls.godot_icall_2_829(MethodBind37, GodotObject.GetPtr(Singleton), rid, idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind38 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetItemSubmenu, 1066463050ul);

    /// <summary>
    /// <para>Returns the submenu ID of the item at index <paramref name="idx"/>. See <see cref="Godot.NativeMenu.AddSubmenuItem(Rid, string, Rid, Variant, int)"/> for more info on how to add a submenu.</para>
    /// <para><b>Note:</b> This method is implemented on macOS and Windows.</para>
    /// </summary>
    public static Rid GetItemSubmenu(Rid rid, int idx)
    {
        return NativeCalls.godot_icall_2_830(MethodBind38, GodotObject.GetPtr(Singleton), rid, idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind39 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetItemAccelerator, 316800700ul);

    /// <summary>
    /// <para>Returns the accelerator of the item at index <paramref name="idx"/>. Accelerators are special combinations of keys that activate the item, no matter which control is focused.</para>
    /// <para><b>Note:</b> This method is implemented only on macOS.</para>
    /// </summary>
    public static Key GetItemAccelerator(Rid rid, int idx)
    {
        return (Key)NativeCalls.godot_icall_2_822(MethodBind39, GodotObject.GetPtr(Singleton), rid, idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind40 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.IsItemDisabled, 3120086654ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the item at index <paramref name="idx"/> is disabled. When it is disabled it can't be selected, or its action invoked.</para>
    /// <para>See <see cref="Godot.NativeMenu.SetItemDisabled(Rid, int, bool)"/> for more info on how to disable an item.</para>
    /// <para><b>Note:</b> This method is implemented on macOS and Windows.</para>
    /// </summary>
    public static bool IsItemDisabled(Rid rid, int idx)
    {
        return NativeCalls.godot_icall_2_826(MethodBind40, GodotObject.GetPtr(Singleton), rid, idx).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind41 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.IsItemHidden, 3120086654ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the item at index <paramref name="idx"/> is hidden.</para>
    /// <para>See <see cref="Godot.NativeMenu.SetItemHidden(Rid, int, bool)"/> for more info on how to hide an item.</para>
    /// <para><b>Note:</b> This method is implemented only on macOS.</para>
    /// </summary>
    public static bool IsItemHidden(Rid rid, int idx)
    {
        return NativeCalls.godot_icall_2_826(MethodBind41, GodotObject.GetPtr(Singleton), rid, idx).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind42 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetItemTooltip, 1464764419ul);

    /// <summary>
    /// <para>Returns the tooltip associated with the specified index <paramref name="idx"/>.</para>
    /// <para><b>Note:</b> This method is implemented only on macOS.</para>
    /// </summary>
    public static string GetItemTooltip(Rid rid, int idx)
    {
        return NativeCalls.godot_icall_2_829(MethodBind42, GodotObject.GetPtr(Singleton), rid, idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind43 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetItemState, 1120910005ul);

    /// <summary>
    /// <para>Returns the state of a multistate item. See <see cref="Godot.NativeMenu.AddMultistateItem(Rid, string, int, int, Callable, Callable, Variant, Key, int)"/> for details.</para>
    /// <para><b>Note:</b> This method is implemented on macOS and Windows.</para>
    /// </summary>
    public static int GetItemState(Rid rid, int idx)
    {
        return NativeCalls.godot_icall_2_822(MethodBind43, GodotObject.GetPtr(Singleton), rid, idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind44 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetItemMaxStates, 1120910005ul);

    /// <summary>
    /// <para>Returns number of states of a multistate item. See <see cref="Godot.NativeMenu.AddMultistateItem(Rid, string, int, int, Callable, Callable, Variant, Key, int)"/> for details.</para>
    /// <para><b>Note:</b> This method is implemented on macOS and Windows.</para>
    /// </summary>
    public static int GetItemMaxStates(Rid rid, int idx)
    {
        return NativeCalls.godot_icall_2_822(MethodBind44, GodotObject.GetPtr(Singleton), rid, idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind45 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetItemIcon, 3391850701ul);

    /// <summary>
    /// <para>Returns the icon of the item at index <paramref name="idx"/>.</para>
    /// <para><b>Note:</b> This method is implemented on macOS and Windows.</para>
    /// </summary>
    public static Texture2D GetItemIcon(Rid rid, int idx)
    {
        return (Texture2D)NativeCalls.godot_icall_2_831(MethodBind45, GodotObject.GetPtr(Singleton), rid, idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind46 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetItemIndentationLevel, 1120910005ul);

    /// <summary>
    /// <para>Returns the horizontal offset of the item at the given <paramref name="idx"/>.</para>
    /// <para><b>Note:</b> This method is implemented only on macOS.</para>
    /// </summary>
    public static int GetItemIndentationLevel(Rid rid, int idx)
    {
        return NativeCalls.godot_icall_2_822(MethodBind46, GodotObject.GetPtr(Singleton), rid, idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind47 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SetItemChecked, 2658558584ul);

    /// <summary>
    /// <para>Sets the checkstate status of the item at index <paramref name="idx"/>.</para>
    /// <para><b>Note:</b> This method is implemented on macOS and Windows.</para>
    /// </summary>
    public static void SetItemChecked(Rid rid, int idx, bool @checked)
    {
        NativeCalls.godot_icall_3_439(MethodBind47, GodotObject.GetPtr(Singleton), rid, idx, @checked.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind48 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SetItemCheckable, 2658558584ul);

    /// <summary>
    /// <para>Sets whether the item at index <paramref name="idx"/> has a checkbox. If <see langword="false"/>, sets the type of the item to plain text.</para>
    /// <para><b>Note:</b> This method is implemented on macOS and Windows.</para>
    /// </summary>
    public static void SetItemCheckable(Rid rid, int idx, bool checkable)
    {
        NativeCalls.godot_icall_3_439(MethodBind48, GodotObject.GetPtr(Singleton), rid, idx, checkable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind49 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SetItemRadioCheckable, 2658558584ul);

    /// <summary>
    /// <para>Sets the type of the item at the specified index <paramref name="idx"/> to radio button. If <see langword="false"/>, sets the type of the item to plain text.</para>
    /// <para><b>Note:</b> This is purely cosmetic; you must add the logic for checking/unchecking items in radio groups.</para>
    /// <para><b>Note:</b> This method is implemented on macOS and Windows.</para>
    /// </summary>
    public static void SetItemRadioCheckable(Rid rid, int idx, bool checkable)
    {
        NativeCalls.godot_icall_3_439(MethodBind49, GodotObject.GetPtr(Singleton), rid, idx, checkable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind50 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SetItemCallback, 2779810226ul);

    /// <summary>
    /// <para>Sets the callback of the item at index <paramref name="idx"/>. Callback is emitted when an item is pressed.</para>
    /// <para><b>Note:</b> The <paramref name="callback"/> Callable needs to accept exactly one Variant parameter, the parameter passed to the Callable will be the value passed to the <c>tag</c> parameter when the menu item was created.</para>
    /// <para><b>Note:</b> This method is implemented on macOS and Windows.</para>
    /// </summary>
    public static void SetItemCallback(Rid rid, int idx, Callable callback)
    {
        NativeCalls.godot_icall_3_431(MethodBind50, GodotObject.GetPtr(Singleton), rid, idx, callback);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind51 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SetItemHoverCallbacks, 2779810226ul);

    /// <summary>
    /// <para>Sets the callback of the item at index <paramref name="idx"/>. The callback is emitted when an item is hovered.</para>
    /// <para><b>Note:</b> The <paramref name="callback"/> Callable needs to accept exactly one Variant parameter, the parameter passed to the Callable will be the value passed to the <c>tag</c> parameter when the menu item was created.</para>
    /// <para><b>Note:</b> This method is implemented only on macOS.</para>
    /// </summary>
    public static void SetItemHoverCallbacks(Rid rid, int idx, Callable callback)
    {
        NativeCalls.godot_icall_3_431(MethodBind51, GodotObject.GetPtr(Singleton), rid, idx, callback);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind52 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SetItemKeyCallback, 2779810226ul);

    /// <summary>
    /// <para>Sets the callback of the item at index <paramref name="idx"/>. Callback is emitted when its accelerator is activated.</para>
    /// <para><b>Note:</b> The <paramref name="keyCallback"/> Callable needs to accept exactly one Variant parameter, the parameter passed to the Callable will be the value passed to the <c>tag</c> parameter when the menu item was created.</para>
    /// <para><b>Note:</b> This method is implemented only on macOS.</para>
    /// </summary>
    public static void SetItemKeyCallback(Rid rid, int idx, Callable keyCallback)
    {
        NativeCalls.godot_icall_3_431(MethodBind52, GodotObject.GetPtr(Singleton), rid, idx, keyCallback);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind53 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SetItemTag, 2706844827ul);

    /// <summary>
    /// <para>Sets the metadata of an item, which may be of any type. You can later get it with <see cref="Godot.NativeMenu.GetItemTag(Rid, int)"/>, which provides a simple way of assigning context data to items.</para>
    /// <para><b>Note:</b> This method is implemented on macOS and Windows.</para>
    /// </summary>
    public static void SetItemTag(Rid rid, int idx, Variant tag)
    {
        NativeCalls.godot_icall_3_832(MethodBind53, GodotObject.GetPtr(Singleton), rid, idx, tag);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind54 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SetItemText, 4153150897ul);

    /// <summary>
    /// <para>Sets the text of the item at index <paramref name="idx"/>.</para>
    /// <para><b>Note:</b> This method is implemented on macOS and Windows.</para>
    /// </summary>
    public static void SetItemText(Rid rid, int idx, string text)
    {
        NativeCalls.godot_icall_3_432(MethodBind54, GodotObject.GetPtr(Singleton), rid, idx, text);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind55 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SetItemSubmenu, 2310537182ul);

    /// <summary>
    /// <para>Sets the submenu RID of the item at index <paramref name="idx"/>. The submenu is a global menu that would be shown when the item is clicked.</para>
    /// <para><b>Note:</b> This method is implemented on macOS and Windows.</para>
    /// </summary>
    public static void SetItemSubmenu(Rid rid, int idx, Rid submenuRid)
    {
        NativeCalls.godot_icall_3_833(MethodBind55, GodotObject.GetPtr(Singleton), rid, idx, submenuRid);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind56 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SetItemAccelerator, 786300043ul);

    /// <summary>
    /// <para>Sets the accelerator of the item at index <paramref name="idx"/>. <paramref name="keycode"/> can be a single <see cref="Godot.Key"/>, or a combination of <see cref="Godot.KeyModifierMask"/>s and <see cref="Godot.Key"/>s using bitwise OR such as <c>KEY_MASK_CTRL | KEY_A</c> (Ctrl + A).</para>
    /// <para><b>Note:</b> This method is implemented only on macOS.</para>
    /// </summary>
    public static void SetItemAccelerator(Rid rid, int idx, Key keycode)
    {
        NativeCalls.godot_icall_3_433(MethodBind56, GodotObject.GetPtr(Singleton), rid, idx, (int)keycode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind57 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SetItemDisabled, 2658558584ul);

    /// <summary>
    /// <para>Enables/disables the item at index <paramref name="idx"/>. When it is disabled, it can't be selected and its action can't be invoked.</para>
    /// <para><b>Note:</b> This method is implemented on macOS and Windows.</para>
    /// </summary>
    public static void SetItemDisabled(Rid rid, int idx, bool disabled)
    {
        NativeCalls.godot_icall_3_439(MethodBind57, GodotObject.GetPtr(Singleton), rid, idx, disabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind58 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SetItemHidden, 2658558584ul);

    /// <summary>
    /// <para>Hides/shows the item at index <paramref name="idx"/>. When it is hidden, an item does not appear in a menu and its action cannot be invoked.</para>
    /// <para><b>Note:</b> This method is implemented only on macOS.</para>
    /// </summary>
    public static void SetItemHidden(Rid rid, int idx, bool hidden)
    {
        NativeCalls.godot_icall_3_439(MethodBind58, GodotObject.GetPtr(Singleton), rid, idx, hidden.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind59 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SetItemTooltip, 4153150897ul);

    /// <summary>
    /// <para>Sets the <see cref="string"/> tooltip of the item at the specified index <paramref name="idx"/>.</para>
    /// <para><b>Note:</b> This method is implemented only on macOS.</para>
    /// </summary>
    public static void SetItemTooltip(Rid rid, int idx, string tooltip)
    {
        NativeCalls.godot_icall_3_432(MethodBind59, GodotObject.GetPtr(Singleton), rid, idx, tooltip);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind60 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SetItemState, 4288446313ul);

    /// <summary>
    /// <para>Sets the state of a multistate item. See <see cref="Godot.NativeMenu.AddMultistateItem(Rid, string, int, int, Callable, Callable, Variant, Key, int)"/> for details.</para>
    /// <para><b>Note:</b> This method is implemented on macOS and Windows.</para>
    /// </summary>
    public static void SetItemState(Rid rid, int idx, int state)
    {
        NativeCalls.godot_icall_3_433(MethodBind60, GodotObject.GetPtr(Singleton), rid, idx, state);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind61 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SetItemMaxStates, 4288446313ul);

    /// <summary>
    /// <para>Sets number of state of a multistate item. See <see cref="Godot.NativeMenu.AddMultistateItem(Rid, string, int, int, Callable, Callable, Variant, Key, int)"/> for details.</para>
    /// <para><b>Note:</b> This method is implemented on macOS and Windows.</para>
    /// </summary>
    public static void SetItemMaxStates(Rid rid, int idx, int maxStates)
    {
        NativeCalls.godot_icall_3_433(MethodBind61, GodotObject.GetPtr(Singleton), rid, idx, maxStates);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind62 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SetItemIcon, 1388763257ul);

    /// <summary>
    /// <para>Replaces the <see cref="Godot.Texture2D"/> icon of the specified <paramref name="idx"/>.</para>
    /// <para><b>Note:</b> This method is implemented on macOS and Windows.</para>
    /// <para><b>Note:</b> This method is not supported by macOS Dock menu items.</para>
    /// </summary>
    public static void SetItemIcon(Rid rid, int idx, Texture2D icon)
    {
        NativeCalls.godot_icall_3_834(MethodBind62, GodotObject.GetPtr(Singleton), rid, idx, GodotObject.GetPtr(icon));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind63 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SetItemIndentationLevel, 4288446313ul);

    /// <summary>
    /// <para>Sets the horizontal offset of the item at the given <paramref name="idx"/>.</para>
    /// <para><b>Note:</b> This method is implemented only on macOS.</para>
    /// </summary>
    public static void SetItemIndentationLevel(Rid rid, int idx, int level)
    {
        NativeCalls.godot_icall_3_433(MethodBind63, GodotObject.GetPtr(Singleton), rid, idx, level);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind64 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetItemCount, 2198884583ul);

    /// <summary>
    /// <para>Returns number of items in the global menu <paramref name="rid"/>.</para>
    /// <para><b>Note:</b> This method is implemented on macOS and Windows.</para>
    /// </summary>
    public static int GetItemCount(Rid rid)
    {
        return NativeCalls.godot_icall_1_835(MethodBind64, GodotObject.GetPtr(Singleton), rid);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind65 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.IsSystemMenu, 4155700596ul);

    /// <summary>
    /// <para>Return <see langword="true"/> is global menu is a special system menu.</para>
    /// <para><b>Note:</b> This method is implemented only on macOS.</para>
    /// </summary>
    public static bool IsSystemMenu(Rid rid)
    {
        return NativeCalls.godot_icall_1_421(MethodBind65, GodotObject.GetPtr(Singleton), rid).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind66 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveItem, 3411492887ul);

    /// <summary>
    /// <para>Removes the item at index <paramref name="idx"/> from the global menu <paramref name="rid"/>.</para>
    /// <para><b>Note:</b> The indices of items after the removed item will be shifted by one.</para>
    /// <para><b>Note:</b> This method is implemented on macOS and Windows.</para>
    /// </summary>
    public static void RemoveItem(Rid rid, int idx)
    {
        NativeCalls.godot_icall_2_426(MethodBind66, GodotObject.GetPtr(Singleton), rid, idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind67 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.Clear, 2722037293ul);

    /// <summary>
    /// <para>Removes all items from the global menu <paramref name="rid"/>.</para>
    /// <para><b>Note:</b> This method is implemented on macOS and Windows.</para>
    /// </summary>
    public static void Clear(Rid rid)
    {
        NativeCalls.godot_icall_1_286(MethodBind67, GodotObject.GetPtr(Singleton), rid);
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public class PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public class MethodName
    {
        /// <summary>
        /// Cached name for the 'has_feature' method.
        /// </summary>
        public static readonly StringName HasFeature = "has_feature";
        /// <summary>
        /// Cached name for the 'has_system_menu' method.
        /// </summary>
        public static readonly StringName HasSystemMenu = "has_system_menu";
        /// <summary>
        /// Cached name for the 'get_system_menu' method.
        /// </summary>
        public static readonly StringName GetSystemMenu = "get_system_menu";
        /// <summary>
        /// Cached name for the 'get_system_menu_name' method.
        /// </summary>
        public static readonly StringName GetSystemMenuName = "get_system_menu_name";
        /// <summary>
        /// Cached name for the 'get_system_menu_text' method.
        /// </summary>
        public static readonly StringName GetSystemMenuText = "get_system_menu_text";
        /// <summary>
        /// Cached name for the 'set_system_menu_text' method.
        /// </summary>
        public static readonly StringName SetSystemMenuText = "set_system_menu_text";
        /// <summary>
        /// Cached name for the 'create_menu' method.
        /// </summary>
        public static readonly StringName CreateMenu = "create_menu";
        /// <summary>
        /// Cached name for the 'has_menu' method.
        /// </summary>
        public static readonly StringName HasMenu = "has_menu";
        /// <summary>
        /// Cached name for the 'free_menu' method.
        /// </summary>
        public static readonly StringName FreeMenu = "free_menu";
        /// <summary>
        /// Cached name for the 'get_size' method.
        /// </summary>
        public static readonly StringName GetSize = "get_size";
        /// <summary>
        /// Cached name for the 'popup' method.
        /// </summary>
        public static readonly StringName Popup = "popup";
        /// <summary>
        /// Cached name for the 'set_interface_direction' method.
        /// </summary>
        public static readonly StringName SetInterfaceDirection = "set_interface_direction";
        /// <summary>
        /// Cached name for the 'set_popup_open_callback' method.
        /// </summary>
        public static readonly StringName SetPopupOpenCallback = "set_popup_open_callback";
        /// <summary>
        /// Cached name for the 'get_popup_open_callback' method.
        /// </summary>
        public static readonly StringName GetPopupOpenCallback = "get_popup_open_callback";
        /// <summary>
        /// Cached name for the 'set_popup_close_callback' method.
        /// </summary>
        public static readonly StringName SetPopupCloseCallback = "set_popup_close_callback";
        /// <summary>
        /// Cached name for the 'get_popup_close_callback' method.
        /// </summary>
        public static readonly StringName GetPopupCloseCallback = "get_popup_close_callback";
        /// <summary>
        /// Cached name for the 'set_minimum_width' method.
        /// </summary>
        public static readonly StringName SetMinimumWidth = "set_minimum_width";
        /// <summary>
        /// Cached name for the 'get_minimum_width' method.
        /// </summary>
        public static readonly StringName GetMinimumWidth = "get_minimum_width";
        /// <summary>
        /// Cached name for the 'is_opened' method.
        /// </summary>
        public static readonly StringName IsOpened = "is_opened";
        /// <summary>
        /// Cached name for the 'add_submenu_item' method.
        /// </summary>
        public static readonly StringName AddSubmenuItem = "add_submenu_item";
        /// <summary>
        /// Cached name for the 'add_item' method.
        /// </summary>
        public static readonly StringName AddItem = "add_item";
        /// <summary>
        /// Cached name for the 'add_check_item' method.
        /// </summary>
        public static readonly StringName AddCheckItem = "add_check_item";
        /// <summary>
        /// Cached name for the 'add_icon_item' method.
        /// </summary>
        public static readonly StringName AddIconItem = "add_icon_item";
        /// <summary>
        /// Cached name for the 'add_icon_check_item' method.
        /// </summary>
        public static readonly StringName AddIconCheckItem = "add_icon_check_item";
        /// <summary>
        /// Cached name for the 'add_radio_check_item' method.
        /// </summary>
        public static readonly StringName AddRadioCheckItem = "add_radio_check_item";
        /// <summary>
        /// Cached name for the 'add_icon_radio_check_item' method.
        /// </summary>
        public static readonly StringName AddIconRadioCheckItem = "add_icon_radio_check_item";
        /// <summary>
        /// Cached name for the 'add_multistate_item' method.
        /// </summary>
        public static readonly StringName AddMultistateItem = "add_multistate_item";
        /// <summary>
        /// Cached name for the 'add_separator' method.
        /// </summary>
        public static readonly StringName AddSeparator = "add_separator";
        /// <summary>
        /// Cached name for the 'find_item_index_with_text' method.
        /// </summary>
        public static readonly StringName FindItemIndexWithText = "find_item_index_with_text";
        /// <summary>
        /// Cached name for the 'find_item_index_with_tag' method.
        /// </summary>
        public static readonly StringName FindItemIndexWithTag = "find_item_index_with_tag";
        /// <summary>
        /// Cached name for the 'find_item_index_with_submenu' method.
        /// </summary>
        public static readonly StringName FindItemIndexWithSubmenu = "find_item_index_with_submenu";
        /// <summary>
        /// Cached name for the 'is_item_checked' method.
        /// </summary>
        public static readonly StringName IsItemChecked = "is_item_checked";
        /// <summary>
        /// Cached name for the 'is_item_checkable' method.
        /// </summary>
        public static readonly StringName IsItemCheckable = "is_item_checkable";
        /// <summary>
        /// Cached name for the 'is_item_radio_checkable' method.
        /// </summary>
        public static readonly StringName IsItemRadioCheckable = "is_item_radio_checkable";
        /// <summary>
        /// Cached name for the 'get_item_callback' method.
        /// </summary>
        public static readonly StringName GetItemCallback = "get_item_callback";
        /// <summary>
        /// Cached name for the 'get_item_key_callback' method.
        /// </summary>
        public static readonly StringName GetItemKeyCallback = "get_item_key_callback";
        /// <summary>
        /// Cached name for the 'get_item_tag' method.
        /// </summary>
        public static readonly StringName GetItemTag = "get_item_tag";
        /// <summary>
        /// Cached name for the 'get_item_text' method.
        /// </summary>
        public static readonly StringName GetItemText = "get_item_text";
        /// <summary>
        /// Cached name for the 'get_item_submenu' method.
        /// </summary>
        public static readonly StringName GetItemSubmenu = "get_item_submenu";
        /// <summary>
        /// Cached name for the 'get_item_accelerator' method.
        /// </summary>
        public static readonly StringName GetItemAccelerator = "get_item_accelerator";
        /// <summary>
        /// Cached name for the 'is_item_disabled' method.
        /// </summary>
        public static readonly StringName IsItemDisabled = "is_item_disabled";
        /// <summary>
        /// Cached name for the 'is_item_hidden' method.
        /// </summary>
        public static readonly StringName IsItemHidden = "is_item_hidden";
        /// <summary>
        /// Cached name for the 'get_item_tooltip' method.
        /// </summary>
        public static readonly StringName GetItemTooltip = "get_item_tooltip";
        /// <summary>
        /// Cached name for the 'get_item_state' method.
        /// </summary>
        public static readonly StringName GetItemState = "get_item_state";
        /// <summary>
        /// Cached name for the 'get_item_max_states' method.
        /// </summary>
        public static readonly StringName GetItemMaxStates = "get_item_max_states";
        /// <summary>
        /// Cached name for the 'get_item_icon' method.
        /// </summary>
        public static readonly StringName GetItemIcon = "get_item_icon";
        /// <summary>
        /// Cached name for the 'get_item_indentation_level' method.
        /// </summary>
        public static readonly StringName GetItemIndentationLevel = "get_item_indentation_level";
        /// <summary>
        /// Cached name for the 'set_item_checked' method.
        /// </summary>
        public static readonly StringName SetItemChecked = "set_item_checked";
        /// <summary>
        /// Cached name for the 'set_item_checkable' method.
        /// </summary>
        public static readonly StringName SetItemCheckable = "set_item_checkable";
        /// <summary>
        /// Cached name for the 'set_item_radio_checkable' method.
        /// </summary>
        public static readonly StringName SetItemRadioCheckable = "set_item_radio_checkable";
        /// <summary>
        /// Cached name for the 'set_item_callback' method.
        /// </summary>
        public static readonly StringName SetItemCallback = "set_item_callback";
        /// <summary>
        /// Cached name for the 'set_item_hover_callbacks' method.
        /// </summary>
        public static readonly StringName SetItemHoverCallbacks = "set_item_hover_callbacks";
        /// <summary>
        /// Cached name for the 'set_item_key_callback' method.
        /// </summary>
        public static readonly StringName SetItemKeyCallback = "set_item_key_callback";
        /// <summary>
        /// Cached name for the 'set_item_tag' method.
        /// </summary>
        public static readonly StringName SetItemTag = "set_item_tag";
        /// <summary>
        /// Cached name for the 'set_item_text' method.
        /// </summary>
        public static readonly StringName SetItemText = "set_item_text";
        /// <summary>
        /// Cached name for the 'set_item_submenu' method.
        /// </summary>
        public static readonly StringName SetItemSubmenu = "set_item_submenu";
        /// <summary>
        /// Cached name for the 'set_item_accelerator' method.
        /// </summary>
        public static readonly StringName SetItemAccelerator = "set_item_accelerator";
        /// <summary>
        /// Cached name for the 'set_item_disabled' method.
        /// </summary>
        public static readonly StringName SetItemDisabled = "set_item_disabled";
        /// <summary>
        /// Cached name for the 'set_item_hidden' method.
        /// </summary>
        public static readonly StringName SetItemHidden = "set_item_hidden";
        /// <summary>
        /// Cached name for the 'set_item_tooltip' method.
        /// </summary>
        public static readonly StringName SetItemTooltip = "set_item_tooltip";
        /// <summary>
        /// Cached name for the 'set_item_state' method.
        /// </summary>
        public static readonly StringName SetItemState = "set_item_state";
        /// <summary>
        /// Cached name for the 'set_item_max_states' method.
        /// </summary>
        public static readonly StringName SetItemMaxStates = "set_item_max_states";
        /// <summary>
        /// Cached name for the 'set_item_icon' method.
        /// </summary>
        public static readonly StringName SetItemIcon = "set_item_icon";
        /// <summary>
        /// Cached name for the 'set_item_indentation_level' method.
        /// </summary>
        public static readonly StringName SetItemIndentationLevel = "set_item_indentation_level";
        /// <summary>
        /// Cached name for the 'get_item_count' method.
        /// </summary>
        public static readonly StringName GetItemCount = "get_item_count";
        /// <summary>
        /// Cached name for the 'is_system_menu' method.
        /// </summary>
        public static readonly StringName IsSystemMenu = "is_system_menu";
        /// <summary>
        /// Cached name for the 'remove_item' method.
        /// </summary>
        public static readonly StringName RemoveItem = "remove_item";
        /// <summary>
        /// Cached name for the 'clear' method.
        /// </summary>
        public static readonly StringName Clear = "clear";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public class SignalName
    {
    }
}
