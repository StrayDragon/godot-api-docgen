namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para><see cref="Godot.PopupMenu"/> is a modal window used to display a list of options. Useful for toolbars and context menus.</para>
/// <para>The size of a <see cref="Godot.PopupMenu"/> can be limited by using <see cref="Godot.Window.MaxSize"/>. If the height of the list of items is larger than the maximum height of the <see cref="Godot.PopupMenu"/>, a <see cref="Godot.ScrollContainer"/> within the popup will allow the user to scroll the contents. If no maximum size is set, or if it is set to <c>0</c>, the <see cref="Godot.PopupMenu"/> height will be limited by its parent rect.</para>
/// <para>All <c>set_*</c> methods allow negative item indices, i.e. <c>-1</c> to access the last item, <c>-2</c> to select the second-to-last item, and so on.</para>
/// <para><b>Incremental search:</b> Like <see cref="Godot.ItemList"/> and <see cref="Godot.Tree"/>, <see cref="Godot.PopupMenu"/> supports searching within the list while the control is focused. Press a key that matches the first letter of an item's name to select the first item starting with the given letter. After that point, there are two ways to perform incremental search: 1) Press the same key again before the timeout duration to select the next item starting with the same letter. 2) Press letter keys that match the rest of the word before the timeout duration to match to select the item in question directly. Both of these actions will be reset to the beginning of the list if the timeout duration has passed since the last keystroke was registered. You can adjust the timeout duration by changing <c>ProjectSettings.gui/timers/incremental_search_max_interval_msec</c>.</para>
/// <para><b>Note:</b> <see cref="Godot.PopupMenu"/> is invisible by default. To make it visible, call one of the <c>popup_*</c> methods from <see cref="Godot.Window"/> on the node, such as <see cref="Godot.Window.PopupCenteredClamped(Nullable{Vector2I}, float)"/>.</para>
/// <para><b>Note:</b> The ID values used for items are limited to 32 bits, not full 64 bits of <see cref="int"/>. This has a range of <c>-2^32</c> to <c>2^32 - 1</c>, i.e. <c>-2147483648</c> to <c>2147483647</c>.</para>
/// </summary>
public partial class PopupMenu : Popup
{
    /// <summary>
    /// <para>If <see langword="true"/>, hides the <see cref="Godot.PopupMenu"/> when an item is selected.</para>
    /// </summary>
    public bool HideOnItemSelection
    {
        get
        {
            return IsHideOnItemSelection();
        }
        set
        {
            SetHideOnItemSelection(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, hides the <see cref="Godot.PopupMenu"/> when a checkbox or radio button is selected.</para>
    /// </summary>
    public bool HideOnCheckableItemSelection
    {
        get
        {
            return IsHideOnCheckableItemSelection();
        }
        set
        {
            SetHideOnCheckableItemSelection(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, hides the <see cref="Godot.PopupMenu"/> when a state item is selected.</para>
    /// </summary>
    public bool HideOnStateItemSelection
    {
        get
        {
            return IsHideOnStateItemSelection();
        }
        set
        {
            SetHideOnStateItemSelection(value);
        }
    }

    /// <summary>
    /// <para>Sets the delay time in seconds for the submenu item to popup on mouse hovering. If the popup menu is added as a child of another (acting as a submenu), it will inherit the delay time of the parent menu item.</para>
    /// <para><b>Note:</b> If the mouse is exiting a submenu item with an open submenu and enters a different submenu item, the submenu popup delay time is affected by the direction of the mouse movement toward the open submenu. If the mouse is moving toward the submenu, the open submenu will wait approximately <c>0.5</c> seconds before closing, which then allows the hovered submenu item to open. This additional delay allows the mouse time to move to the open submenu across other menu items without prematurely closing. If the mouse is not moving toward the open submenu, for example in a downward direction, the open submenu will close immediately.</para>
    /// </summary>
    public float SubmenuPopupDelay
    {
        get
        {
            return GetSubmenuPopupDelay();
        }
        set
        {
            SetSubmenuPopupDelay(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, allows navigating <see cref="Godot.PopupMenu"/> with letter keys.</para>
    /// </summary>
    public bool AllowSearch
    {
        get
        {
            return GetAllowSearch();
        }
        set
        {
            SetAllowSearch(value);
        }
    }

    /// <summary>
    /// <para>If set to one of the values of <see cref="Godot.NativeMenu.SystemMenus"/>, this <see cref="Godot.PopupMenu"/> is bound to the special system menu. Only one <see cref="Godot.PopupMenu"/> can be bound to each special menu at a time.</para>
    /// </summary>
    public NativeMenu.SystemMenus SystemMenuId
    {
        get
        {
            return GetSystemMenu();
        }
        set
        {
            SetSystemMenu(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, <see cref="Godot.MenuBar"/> will use native menu when supported.</para>
    /// <para><b>Note:</b> If <see cref="Godot.PopupMenu"/> is linked to <see cref="Godot.StatusIndicator"/>, <see cref="Godot.MenuBar"/>, or another <see cref="Godot.PopupMenu"/> item it can use native menu regardless of this property, use <see cref="Godot.PopupMenu.IsNativeMenu()"/> to check it.</para>
    /// </summary>
    public bool PreferNativeMenu
    {
        get
        {
            return IsPreferNativeMenu();
        }
        set
        {
            SetPreferNativeMenu(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, shrinks <see cref="Godot.PopupMenu"/> to minimum height when it's shown.</para>
    /// </summary>
    public bool ShrinkHeight
    {
        get
        {
            return GetShrinkHeight();
        }
        set
        {
            SetShrinkHeight(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, shrinks <see cref="Godot.PopupMenu"/> to minimum width when it's shown.</para>
    /// </summary>
    public bool ShrinkWidth
    {
        get
        {
            return GetShrinkWidth();
        }
        set
        {
            SetShrinkWidth(value);
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

    private static readonly System.Type CachedType = typeof(PopupMenu);

    private static readonly StringName NativeName = "PopupMenu";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public PopupMenu() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal PopupMenu(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal PopupMenu(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ActivateItemByEvent, 3716412023ul);

    /// <summary>
    /// <para>Checks the provided <paramref name="event"/> against the <see cref="Godot.PopupMenu"/>'s shortcuts and accelerators, and activates the first item with matching events. If <paramref name="forGlobalOnly"/> is <see langword="true"/>, only shortcuts and accelerators with <c>global</c> set to <see langword="true"/> will be called.</para>
    /// <para>Returns <see langword="true"/> if an item was successfully activated.</para>
    /// <para><b>Note:</b> Certain <see cref="Godot.Control"/>s, such as <see cref="Godot.MenuButton"/>, will call this method automatically.</para>
    /// </summary>
    public bool ActivateItemByEvent(InputEvent @event, bool forGlobalOnly = false)
    {
        return NativeCalls.godot_icall_2_753(MethodBind0, GodotObject.GetPtr(this), GodotObject.GetPtr(@event), forGlobalOnly.ToGodotBool()).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPreferNativeMenu, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPreferNativeMenu(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind1, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsPreferNativeMenu, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsPreferNativeMenu()
    {
        return NativeCalls.godot_icall_0_15(MethodBind2, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsNativeMenu, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the system native menu is supported and currently used by this <see cref="Godot.PopupMenu"/>.</para>
    /// </summary>
    public bool IsNativeMenu()
    {
        return NativeCalls.godot_icall_0_15(MethodBind3, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddItem, 3674230041ul);

    /// <summary>
    /// <para>Adds a new item with text <paramref name="label"/>.</para>
    /// <para>An <paramref name="id"/> can optionally be provided, as well as an accelerator (<paramref name="accel"/>). If no <paramref name="id"/> is provided, one will be created from the index. If no <paramref name="accel"/> is provided, then the default value of 0 (corresponding to <see cref="Godot.Key.None"/>) will be assigned to the item (which means it won't have any accelerator). See <see cref="Godot.PopupMenu.GetItemAccelerator(int)"/> for more info on accelerators.</para>
    /// <para><b>Note:</b> The provided <paramref name="id"/> is used only in <see cref="Godot.PopupMenu.IdPressed"/> and <see cref="Godot.PopupMenu.IdFocused"/> signals. It's not related to the <c>index</c> arguments in e.g. <see cref="Godot.PopupMenu.SetItemChecked(int, bool)"/>.</para>
    /// </summary>
    public void AddItem(string label, int id = -1, Key accel = (Key)(0))
    {
        NativeCalls.godot_icall_3_398(MethodBind4, GodotObject.GetPtr(this), label, id, (int)accel);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddIconItem, 1086190128ul);

    /// <summary>
    /// <para>Adds a new item with text <paramref name="label"/> and icon <paramref name="texture"/>.</para>
    /// <para>An <paramref name="id"/> can optionally be provided, as well as an accelerator (<paramref name="accel"/>). If no <paramref name="id"/> is provided, one will be created from the index. If no <paramref name="accel"/> is provided, then the default value of 0 (corresponding to <see cref="Godot.Key.None"/>) will be assigned to the item (which means it won't have any accelerator). See <see cref="Godot.PopupMenu.GetItemAccelerator(int)"/> for more info on accelerators.</para>
    /// </summary>
    public void AddIconItem(Texture2D texture, string label, int id = -1, Key accel = (Key)(0))
    {
        NativeCalls.godot_icall_4_1015(MethodBind5, GodotObject.GetPtr(this), GodotObject.GetPtr(texture), label, id, (int)accel);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddCheckItem, 3674230041ul);

    /// <summary>
    /// <para>Adds a new checkable item with text <paramref name="label"/>.</para>
    /// <para>An <paramref name="id"/> can optionally be provided, as well as an accelerator (<paramref name="accel"/>). If no <paramref name="id"/> is provided, one will be created from the index. If no <paramref name="accel"/> is provided, then the default value of 0 (corresponding to <see cref="Godot.Key.None"/>) will be assigned to the item (which means it won't have any accelerator). See <see cref="Godot.PopupMenu.GetItemAccelerator(int)"/> for more info on accelerators.</para>
    /// <para><b>Note:</b> Checkable items just display a checkmark, but don't have any built-in checking behavior and must be checked/unchecked manually. See <see cref="Godot.PopupMenu.SetItemChecked(int, bool)"/> for more info on how to control it.</para>
    /// </summary>
    public void AddCheckItem(string label, int id = -1, Key accel = (Key)(0))
    {
        NativeCalls.godot_icall_3_398(MethodBind6, GodotObject.GetPtr(this), label, id, (int)accel);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddIconCheckItem, 1086190128ul);

    /// <summary>
    /// <para>Adds a new checkable item with text <paramref name="label"/> and icon <paramref name="texture"/>.</para>
    /// <para>An <paramref name="id"/> can optionally be provided, as well as an accelerator (<paramref name="accel"/>). If no <paramref name="id"/> is provided, one will be created from the index. If no <paramref name="accel"/> is provided, then the default value of 0 (corresponding to <see cref="Godot.Key.None"/>) will be assigned to the item (which means it won't have any accelerator). See <see cref="Godot.PopupMenu.GetItemAccelerator(int)"/> for more info on accelerators.</para>
    /// <para><b>Note:</b> Checkable items just display a checkmark, but don't have any built-in checking behavior and must be checked/unchecked manually. See <see cref="Godot.PopupMenu.SetItemChecked(int, bool)"/> for more info on how to control it.</para>
    /// </summary>
    public void AddIconCheckItem(Texture2D texture, string label, int id = -1, Key accel = (Key)(0))
    {
        NativeCalls.godot_icall_4_1015(MethodBind7, GodotObject.GetPtr(this), GodotObject.GetPtr(texture), label, id, (int)accel);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddRadioCheckItem, 3674230041ul);

    /// <summary>
    /// <para>Adds a new radio check button with text <paramref name="label"/>.</para>
    /// <para>An <paramref name="id"/> can optionally be provided, as well as an accelerator (<paramref name="accel"/>). If no <paramref name="id"/> is provided, one will be created from the index. If no <paramref name="accel"/> is provided, then the default value of 0 (corresponding to <see cref="Godot.Key.None"/>) will be assigned to the item (which means it won't have any accelerator). See <see cref="Godot.PopupMenu.GetItemAccelerator(int)"/> for more info on accelerators.</para>
    /// <para><b>Note:</b> Checkable items just display a checkmark, but don't have any built-in checking behavior and must be checked/unchecked manually. See <see cref="Godot.PopupMenu.SetItemChecked(int, bool)"/> for more info on how to control it.</para>
    /// </summary>
    public void AddRadioCheckItem(string label, int id = -1, Key accel = (Key)(0))
    {
        NativeCalls.godot_icall_3_398(MethodBind8, GodotObject.GetPtr(this), label, id, (int)accel);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddIconRadioCheckItem, 1086190128ul);

    /// <summary>
    /// <para>Same as <see cref="Godot.PopupMenu.AddIconCheckItem(Texture2D, string, int, Key)"/>, but uses a radio check button.</para>
    /// </summary>
    public void AddIconRadioCheckItem(Texture2D texture, string label, int id = -1, Key accel = (Key)(0))
    {
        NativeCalls.godot_icall_4_1015(MethodBind9, GodotObject.GetPtr(this), GodotObject.GetPtr(texture), label, id, (int)accel);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddMultistateItem, 150780458ul);

    /// <summary>
    /// <para>Adds a new multistate item with text <paramref name="label"/>.</para>
    /// <para>Contrarily to normal binary items, multistate items can have more than two states, as defined by <paramref name="maxStates"/>. The default value is defined by <paramref name="defaultState"/>.</para>
    /// <para>An <paramref name="id"/> can optionally be provided, as well as an accelerator (<paramref name="accel"/>). If no <paramref name="id"/> is provided, one will be created from the index. If no <paramref name="accel"/> is provided, then the default value of 0 (corresponding to <see cref="Godot.Key.None"/>) will be assigned to the item (which means it won't have any accelerator). See <see cref="Godot.PopupMenu.GetItemAccelerator(int)"/> for more info on accelerators.</para>
    /// <para><code>
    /// func _ready():
    /// 	add_multistate_item("Item", 3, 0)
    /// 
    /// 	index_pressed.connect(func(index: int):
    /// 			toggle_item_multistate(index)
    /// 			match get_item_multistate(index):
    /// 				0:
    /// 					print("First state")
    /// 				1:
    /// 					print("Second state")
    /// 				2:
    /// 					print("Third state")
    /// 		)
    /// </code></para>
    /// <para><b>Note:</b> Multistate items don't update their state automatically and must be done manually. See <see cref="Godot.PopupMenu.ToggleItemMultistate(int)"/>, <see cref="Godot.PopupMenu.SetItemMultistate(int, int)"/> and <see cref="Godot.PopupMenu.GetItemMultistate(int)"/> for more info on how to control it.</para>
    /// </summary>
    public void AddMultistateItem(string label, int maxStates, int defaultState = 0, int id = -1, Key accel = (Key)(0))
    {
        NativeCalls.godot_icall_5_1016(MethodBind10, GodotObject.GetPtr(this), label, maxStates, defaultState, id, (int)accel);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddShortcut, 3451850107ul);

    /// <summary>
    /// <para>Adds a <see cref="Godot.Shortcut"/>.</para>
    /// <para>An <paramref name="id"/> can optionally be provided. If no <paramref name="id"/> is provided, one will be created from the index.</para>
    /// <para>If <paramref name="allowEcho"/> is <see langword="true"/>, the shortcut can be activated with echo events.</para>
    /// </summary>
    public void AddShortcut(Shortcut shortcut, int id = -1, bool global = false, bool allowEcho = false)
    {
        NativeCalls.godot_icall_4_1017(MethodBind11, GodotObject.GetPtr(this), GodotObject.GetPtr(shortcut), id, global.ToGodotBool(), allowEcho.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddIconShortcut, 2997871092ul);

    /// <summary>
    /// <para>Adds a new item and assigns the specified <see cref="Godot.Shortcut"/> and icon <paramref name="texture"/> to it. Sets the label of the checkbox to the <see cref="Godot.Shortcut"/>'s name.</para>
    /// <para>An <paramref name="id"/> can optionally be provided. If no <paramref name="id"/> is provided, one will be created from the index.</para>
    /// <para>If <paramref name="allowEcho"/> is <see langword="true"/>, the shortcut can be activated with echo events.</para>
    /// </summary>
    public void AddIconShortcut(Texture2D texture, Shortcut shortcut, int id = -1, bool global = false, bool allowEcho = false)
    {
        NativeCalls.godot_icall_5_1018(MethodBind12, GodotObject.GetPtr(this), GodotObject.GetPtr(texture), GodotObject.GetPtr(shortcut), id, global.ToGodotBool(), allowEcho.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddCheckShortcut, 1642193386ul);

    /// <summary>
    /// <para>Adds a new checkable item and assigns the specified <see cref="Godot.Shortcut"/> to it. Sets the label of the checkbox to the <see cref="Godot.Shortcut"/>'s name.</para>
    /// <para>An <paramref name="id"/> can optionally be provided. If no <paramref name="id"/> is provided, one will be created from the index.</para>
    /// <para><b>Note:</b> Checkable items just display a checkmark, but don't have any built-in checking behavior and must be checked/unchecked manually. See <see cref="Godot.PopupMenu.SetItemChecked(int, bool)"/> for more info on how to control it.</para>
    /// </summary>
    public void AddCheckShortcut(Shortcut shortcut, int id = -1, bool global = false)
    {
        NativeCalls.godot_icall_3_1019(MethodBind13, GodotObject.GetPtr(this), GodotObject.GetPtr(shortcut), id, global.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddIconCheckShortcut, 3856247530ul);

    /// <summary>
    /// <para>Adds a new checkable item and assigns the specified <see cref="Godot.Shortcut"/> and icon <paramref name="texture"/> to it. Sets the label of the checkbox to the <see cref="Godot.Shortcut"/>'s name.</para>
    /// <para>An <paramref name="id"/> can optionally be provided. If no <paramref name="id"/> is provided, one will be created from the index.</para>
    /// <para><b>Note:</b> Checkable items just display a checkmark, but don't have any built-in checking behavior and must be checked/unchecked manually. See <see cref="Godot.PopupMenu.SetItemChecked(int, bool)"/> for more info on how to control it.</para>
    /// </summary>
    public void AddIconCheckShortcut(Texture2D texture, Shortcut shortcut, int id = -1, bool global = false)
    {
        NativeCalls.godot_icall_4_1020(MethodBind14, GodotObject.GetPtr(this), GodotObject.GetPtr(texture), GodotObject.GetPtr(shortcut), id, global.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddRadioCheckShortcut, 1642193386ul);

    /// <summary>
    /// <para>Adds a new radio check button and assigns a <see cref="Godot.Shortcut"/> to it. Sets the label of the checkbox to the <see cref="Godot.Shortcut"/>'s name.</para>
    /// <para>An <paramref name="id"/> can optionally be provided. If no <paramref name="id"/> is provided, one will be created from the index.</para>
    /// <para><b>Note:</b> Checkable items just display a checkmark, but don't have any built-in checking behavior and must be checked/unchecked manually. See <see cref="Godot.PopupMenu.SetItemChecked(int, bool)"/> for more info on how to control it.</para>
    /// </summary>
    public void AddRadioCheckShortcut(Shortcut shortcut, int id = -1, bool global = false)
    {
        NativeCalls.godot_icall_3_1019(MethodBind15, GodotObject.GetPtr(this), GodotObject.GetPtr(shortcut), id, global.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddIconRadioCheckShortcut, 3856247530ul);

    /// <summary>
    /// <para>Same as <see cref="Godot.PopupMenu.AddIconCheckShortcut(Texture2D, Shortcut, int, bool)"/>, but uses a radio check button.</para>
    /// </summary>
    public void AddIconRadioCheckShortcut(Texture2D texture, Shortcut shortcut, int id = -1, bool global = false)
    {
        NativeCalls.godot_icall_4_1020(MethodBind16, GodotObject.GetPtr(this), GodotObject.GetPtr(texture), GodotObject.GetPtr(shortcut), id, global.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddSubmenuItem, 2979222410ul);

    /// <summary>
    /// <para>Adds an item that will act as a submenu of the parent <see cref="Godot.PopupMenu"/> node when clicked. The <paramref name="submenu"/> argument must be the name of an existing <see cref="Godot.PopupMenu"/> that has been added as a child to this node. This submenu will be shown when the item is clicked, hovered for long enough, or activated using the <c>ui_select</c> or <c>ui_right</c> input actions.</para>
    /// <para>An <paramref name="id"/> can optionally be provided. If no <paramref name="id"/> is provided, one will be created from the index.</para>
    /// </summary>
    [Obsolete("Prefer using 'Godot.PopupMenu.AddSubmenuNodeItem(string, PopupMenu, int)' instead.")]
    public void AddSubmenuItem(string label, string submenu, int id = -1)
    {
        NativeCalls.godot_icall_3_1021(MethodBind17, GodotObject.GetPtr(this), label, submenu, id);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddSubmenuNodeItem, 1325455216ul);

    /// <summary>
    /// <para>Adds an item that will act as a submenu of the parent <see cref="Godot.PopupMenu"/> node when clicked. This submenu will be shown when the item is clicked, hovered for long enough, or activated using the <c>ui_select</c> or <c>ui_right</c> input actions.</para>
    /// <para><paramref name="submenu"/> must be either child of this <see cref="Godot.PopupMenu"/> or has no parent node (in which case it will be automatically added as a child). If the <paramref name="submenu"/> popup has another parent, this method will fail.</para>
    /// <para>An <paramref name="id"/> can optionally be provided. If no <paramref name="id"/> is provided, one will be created from the index.</para>
    /// </summary>
    public void AddSubmenuNodeItem(string label, PopupMenu submenu, int id = -1)
    {
        NativeCalls.godot_icall_3_1022(MethodBind18, GodotObject.GetPtr(this), label, GodotObject.GetPtr(submenu), id);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetItemText, 501894301ul);

    /// <summary>
    /// <para>Sets the text of the item at the given <paramref name="index"/>.</para>
    /// </summary>
    public void SetItemText(int index, string text)
    {
        NativeCalls.godot_icall_2_181(MethodBind19, GodotObject.GetPtr(this), index, text);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetItemTextDirection, 1707680378ul);

    /// <summary>
    /// <para>Sets item's text base writing direction.</para>
    /// </summary>
    public void SetItemTextDirection(int index, Control.TextDirection direction)
    {
        NativeCalls.godot_icall_2_59(MethodBind20, GodotObject.GetPtr(this), index, (int)direction);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetItemLanguage, 501894301ul);

    /// <summary>
    /// <para>Sets the language code of the text for the item at the given index to <paramref name="language"/>. This is used for line-breaking and text shaping algorithms. If <paramref name="language"/> is empty, the current locale is used.</para>
    /// </summary>
    public void SetItemLanguage(int index, string language)
    {
        NativeCalls.godot_icall_2_181(MethodBind21, GodotObject.GetPtr(this), index, language);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetItemAutoTranslateMode, 287402019ul);

    /// <summary>
    /// <para>Sets the auto translate mode of the item at the given <paramref name="index"/>.</para>
    /// <para>Items use <see cref="Godot.Node.AutoTranslateModeEnum.Inherit"/> by default, which uses the same auto translate mode as the <see cref="Godot.PopupMenu"/> itself.</para>
    /// </summary>
    public void SetItemAutoTranslateMode(int index, Node.AutoTranslateModeEnum mode)
    {
        NativeCalls.godot_icall_2_59(MethodBind22, GodotObject.GetPtr(this), index, (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetItemIcon, 666127730ul);

    /// <summary>
    /// <para>Replaces the <see cref="Godot.Texture2D"/> icon of the item at the given <paramref name="index"/>.</para>
    /// </summary>
    public void SetItemIcon(int index, Texture2D icon)
    {
        NativeCalls.godot_icall_2_70(MethodBind23, GodotObject.GetPtr(this), index, GodotObject.GetPtr(icon));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetItemIconMaxWidth, 3937882851ul);

    /// <summary>
    /// <para>Sets the maximum allowed width of the icon for the item at the given <paramref name="index"/>. This limit is applied on top of the default size of the icon and on top of <c>icon_max_width</c>. The height is adjusted according to the icon's ratio.</para>
    /// </summary>
    public void SetItemIconMaxWidth(int index, int width)
    {
        NativeCalls.godot_icall_2_59(MethodBind24, GodotObject.GetPtr(this), index, width);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetItemIconModulate, 2878471219ul);

    /// <summary>
    /// <para>Sets a modulating <see cref="Godot.Color"/> of the item's icon at the given <paramref name="index"/>.</para>
    /// </summary>
    public unsafe void SetItemIconModulate(int index, Color modulate)
    {
        NativeCalls.godot_icall_2_687(MethodBind25, GodotObject.GetPtr(this), index, &modulate);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetItemChecked, 300928843ul);

    /// <summary>
    /// <para>Sets the checkstate status of the item at the given <paramref name="index"/>.</para>
    /// </summary>
    public void SetItemChecked(int index, bool @checked)
    {
        NativeCalls.godot_icall_2_61(MethodBind26, GodotObject.GetPtr(this), index, @checked.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetItemId, 3937882851ul);

    /// <summary>
    /// <para>Sets the <paramref name="id"/> of the item at the given <paramref name="index"/>.</para>
    /// <para>The <paramref name="id"/> is used in <see cref="Godot.PopupMenu.IdPressed"/> and <see cref="Godot.PopupMenu.IdFocused"/> signals.</para>
    /// </summary>
    public void SetItemId(int index, int id)
    {
        NativeCalls.godot_icall_2_59(MethodBind27, GodotObject.GetPtr(this), index, id);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetItemAccelerator, 2992817551ul);

    /// <summary>
    /// <para>Sets the accelerator of the item at the given <paramref name="index"/>. An accelerator is a keyboard shortcut that can be pressed to trigger the menu button even if it's not currently open. <paramref name="accel"/> is generally a combination of <see cref="Godot.KeyModifierMask"/>s and <see cref="Godot.Key"/>s using bitwise OR such as <c>KEY_MASK_CTRL | KEY_A</c> (Ctrl + A).</para>
    /// </summary>
    public void SetItemAccelerator(int index, Key accel)
    {
        NativeCalls.godot_icall_2_59(MethodBind28, GodotObject.GetPtr(this), index, (int)accel);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetItemMetadata, 2152698145ul);

    /// <summary>
    /// <para>Sets the metadata of an item, which may be of any type. You can later get it with <see cref="Godot.PopupMenu.GetItemMetadata(int)"/>, which provides a simple way of assigning context data to items.</para>
    /// </summary>
    public void SetItemMetadata(int index, Variant metadata)
    {
        NativeCalls.godot_icall_2_701(MethodBind29, GodotObject.GetPtr(this), index, metadata);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetItemDisabled, 300928843ul);

    /// <summary>
    /// <para>Enables/disables the item at the given <paramref name="index"/>. When it is disabled, it can't be selected and its action can't be invoked.</para>
    /// </summary>
    public void SetItemDisabled(int index, bool disabled)
    {
        NativeCalls.godot_icall_2_61(MethodBind30, GodotObject.GetPtr(this), index, disabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetItemSubmenu, 501894301ul);

    /// <summary>
    /// <para>Sets the submenu of the item at the given <paramref name="index"/>. The submenu is the name of a child <see cref="Godot.PopupMenu"/> node that would be shown when the item is clicked.</para>
    /// </summary>
    [Obsolete("Prefer using 'Godot.PopupMenu.SetItemSubmenuNode(int, PopupMenu)' instead.")]
    public void SetItemSubmenu(int index, string submenu)
    {
        NativeCalls.godot_icall_2_181(MethodBind31, GodotObject.GetPtr(this), index, submenu);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind32 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetItemSubmenuNode, 1068370740ul);

    /// <summary>
    /// <para>Sets the submenu of the item at the given <paramref name="index"/>. The submenu is a <see cref="Godot.PopupMenu"/> node that would be shown when the item is clicked. It must either be a child of this <see cref="Godot.PopupMenu"/> or has no parent (in which case it will be automatically added as a child). If the <paramref name="submenu"/> popup has another parent, this method will fail.</para>
    /// </summary>
    public void SetItemSubmenuNode(int index, PopupMenu submenu)
    {
        NativeCalls.godot_icall_2_70(MethodBind32, GodotObject.GetPtr(this), index, GodotObject.GetPtr(submenu));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind33 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetItemAsSeparator, 300928843ul);

    /// <summary>
    /// <para>Mark the item at the given <paramref name="index"/> as a separator, which means that it would be displayed as a line. If <see langword="false"/>, sets the type of the item to plain text.</para>
    /// </summary>
    public void SetItemAsSeparator(int index, bool enable)
    {
        NativeCalls.godot_icall_2_61(MethodBind33, GodotObject.GetPtr(this), index, enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind34 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetItemAsCheckable, 300928843ul);

    /// <summary>
    /// <para>Sets whether the item at the given <paramref name="index"/> has a checkbox. If <see langword="false"/>, sets the type of the item to plain text.</para>
    /// <para><b>Note:</b> Checkable items just display a checkmark, but don't have any built-in checking behavior and must be checked/unchecked manually.</para>
    /// </summary>
    public void SetItemAsCheckable(int index, bool enable)
    {
        NativeCalls.godot_icall_2_61(MethodBind34, GodotObject.GetPtr(this), index, enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind35 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetItemAsRadioCheckable, 300928843ul);

    /// <summary>
    /// <para>Sets the type of the item at the given <paramref name="index"/> to radio button. If <see langword="false"/>, sets the type of the item to plain text.</para>
    /// </summary>
    public void SetItemAsRadioCheckable(int index, bool enable)
    {
        NativeCalls.godot_icall_2_61(MethodBind35, GodotObject.GetPtr(this), index, enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind36 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetItemTooltip, 501894301ul);

    /// <summary>
    /// <para>Sets the <see cref="string"/> tooltip of the item at the given <paramref name="index"/>.</para>
    /// </summary>
    public void SetItemTooltip(int index, string tooltip)
    {
        NativeCalls.godot_icall_2_181(MethodBind36, GodotObject.GetPtr(this), index, tooltip);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind37 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetItemShortcut, 825127832ul);

    /// <summary>
    /// <para>Sets a <see cref="Godot.Shortcut"/> for the item at the given <paramref name="index"/>.</para>
    /// </summary>
    public void SetItemShortcut(int index, Shortcut shortcut, bool global = false)
    {
        NativeCalls.godot_icall_3_1023(MethodBind37, GodotObject.GetPtr(this), index, GodotObject.GetPtr(shortcut), global.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind38 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetItemIndent, 3937882851ul);

    /// <summary>
    /// <para>Sets the horizontal offset of the item at the given <paramref name="index"/>.</para>
    /// </summary>
    public void SetItemIndent(int index, int indent)
    {
        NativeCalls.godot_icall_2_59(MethodBind38, GodotObject.GetPtr(this), index, indent);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind39 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetItemMultistate, 3937882851ul);

    /// <summary>
    /// <para>Sets the state of a multistate item. See <see cref="Godot.PopupMenu.AddMultistateItem(string, int, int, int, Key)"/> for details.</para>
    /// </summary>
    public void SetItemMultistate(int index, int state)
    {
        NativeCalls.godot_icall_2_59(MethodBind39, GodotObject.GetPtr(this), index, state);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind40 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetItemMultistateMax, 3937882851ul);

    /// <summary>
    /// <para>Sets the max states of a multistate item. See <see cref="Godot.PopupMenu.AddMultistateItem(string, int, int, int, Key)"/> for details.</para>
    /// </summary>
    public void SetItemMultistateMax(int index, int maxStates)
    {
        NativeCalls.godot_icall_2_59(MethodBind40, GodotObject.GetPtr(this), index, maxStates);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind41 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetItemShortcutDisabled, 300928843ul);

    /// <summary>
    /// <para>Disables the <see cref="Godot.Shortcut"/> of the item at the given <paramref name="index"/>.</para>
    /// </summary>
    public void SetItemShortcutDisabled(int index, bool disabled)
    {
        NativeCalls.godot_icall_2_61(MethodBind41, GodotObject.GetPtr(this), index, disabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind42 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ToggleItemChecked, 1286410249ul);

    /// <summary>
    /// <para>Toggles the check state of the item at the given <paramref name="index"/>.</para>
    /// </summary>
    public void ToggleItemChecked(int index)
    {
        NativeCalls.godot_icall_1_38(MethodBind42, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind43 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ToggleItemMultistate, 1286410249ul);

    /// <summary>
    /// <para>Cycle to the next state of a multistate item. See <see cref="Godot.PopupMenu.AddMultistateItem(string, int, int, int, Key)"/> for details.</para>
    /// </summary>
    public void ToggleItemMultistate(int index)
    {
        NativeCalls.godot_icall_1_38(MethodBind43, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind44 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetItemText, 844755477ul);

    /// <summary>
    /// <para>Returns the text of the item at the given <paramref name="index"/>.</para>
    /// </summary>
    public string GetItemText(int index)
    {
        return NativeCalls.godot_icall_1_133(MethodBind44, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind45 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetItemTextDirection, 4235602388ul);

    /// <summary>
    /// <para>Returns item's text base writing direction.</para>
    /// </summary>
    public Control.TextDirection GetItemTextDirection(int index)
    {
        return (Control.TextDirection)NativeCalls.godot_icall_1_60(MethodBind45, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind46 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetItemLanguage, 844755477ul);

    /// <summary>
    /// <para>Returns item's text language code.</para>
    /// </summary>
    public string GetItemLanguage(int index)
    {
        return NativeCalls.godot_icall_1_133(MethodBind46, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind47 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetItemAutoTranslateMode, 906302372ul);

    /// <summary>
    /// <para>Returns the auto translate mode of the item at the given <paramref name="index"/>.</para>
    /// </summary>
    public Node.AutoTranslateModeEnum GetItemAutoTranslateMode(int index)
    {
        return (Node.AutoTranslateModeEnum)NativeCalls.godot_icall_1_60(MethodBind47, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind48 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetItemIcon, 3536238170ul);

    /// <summary>
    /// <para>Returns the icon of the item at the given <paramref name="index"/>.</para>
    /// </summary>
    public Texture2D GetItemIcon(int index)
    {
        return (Texture2D)NativeCalls.godot_icall_1_71(MethodBind48, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind49 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetItemIconMaxWidth, 923996154ul);

    /// <summary>
    /// <para>Returns the maximum allowed width of the icon for the item at the given <paramref name="index"/>.</para>
    /// </summary>
    public int GetItemIconMaxWidth(int index)
    {
        return NativeCalls.godot_icall_1_60(MethodBind49, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind50 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetItemIconModulate, 3457211756ul);

    /// <summary>
    /// <para>Returns a <see cref="Godot.Color"/> modulating the item's icon at the given <paramref name="index"/>.</para>
    /// </summary>
    public Color GetItemIconModulate(int index)
    {
        return NativeCalls.godot_icall_1_688(MethodBind50, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind51 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsItemChecked, 1116898809ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the item at the given <paramref name="index"/> is checked.</para>
    /// </summary>
    public bool IsItemChecked(int index)
    {
        return NativeCalls.godot_icall_1_62(MethodBind51, GodotObject.GetPtr(this), index).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind52 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetItemId, 923996154ul);

    /// <summary>
    /// <para>Returns the ID of the item at the given <paramref name="index"/>. <c>id</c> can be manually assigned, while index can not.</para>
    /// </summary>
    public int GetItemId(int index)
    {
        return NativeCalls.godot_icall_1_60(MethodBind52, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind53 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetItemIndex, 923996154ul);

    /// <summary>
    /// <para>Returns the index of the item containing the specified <paramref name="id"/>. Index is automatically assigned to each item by the engine and can not be set manually.</para>
    /// </summary>
    public int GetItemIndex(int id)
    {
        return NativeCalls.godot_icall_1_60(MethodBind53, GodotObject.GetPtr(this), id);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind54 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetItemAccelerator, 253789942ul);

    /// <summary>
    /// <para>Returns the accelerator of the item at the given <paramref name="index"/>. An accelerator is a keyboard shortcut that can be pressed to trigger the menu button even if it's not currently open. The return value is an integer which is generally a combination of <see cref="Godot.KeyModifierMask"/>s and <see cref="Godot.Key"/>s using bitwise OR such as <c>KEY_MASK_CTRL | KEY_A</c> (Ctrl + A). If no accelerator is defined for the specified <paramref name="index"/>, <see cref="Godot.PopupMenu.GetItemAccelerator(int)"/> returns <c>0</c> (corresponding to <see cref="Godot.Key.None"/>).</para>
    /// </summary>
    public Key GetItemAccelerator(int index)
    {
        return (Key)NativeCalls.godot_icall_1_60(MethodBind54, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind55 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetItemMetadata, 4227898402ul);

    /// <summary>
    /// <para>Returns the metadata of the specified item, which might be of any type. You can set it with <see cref="Godot.PopupMenu.SetItemMetadata(int, Variant)"/>, which provides a simple way of assigning context data to items.</para>
    /// </summary>
    public Variant GetItemMetadata(int index)
    {
        return NativeCalls.godot_icall_1_702(MethodBind55, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind56 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsItemDisabled, 1116898809ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the item at the given <paramref name="index"/> is disabled. When it is disabled it can't be selected, or its action invoked.</para>
    /// <para>See <see cref="Godot.PopupMenu.SetItemDisabled(int, bool)"/> for more info on how to disable an item.</para>
    /// </summary>
    public bool IsItemDisabled(int index)
    {
        return NativeCalls.godot_icall_1_62(MethodBind56, GodotObject.GetPtr(this), index).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind57 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetItemSubmenu, 844755477ul);

    /// <summary>
    /// <para>Returns the submenu name of the item at the given <paramref name="index"/>. See <see cref="Godot.PopupMenu.AddSubmenuItem(string, string, int)"/> for more info on how to add a submenu.</para>
    /// </summary>
    [Obsolete("Prefer using 'Godot.PopupMenu.GetItemSubmenuNode(int)' instead.")]
    public string GetItemSubmenu(int index)
    {
        return NativeCalls.godot_icall_1_133(MethodBind57, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind58 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetItemSubmenuNode, 2100501353ul);

    /// <summary>
    /// <para>Returns the submenu of the item at the given <paramref name="index"/>, or <see langword="null"/> if no submenu was added. See <see cref="Godot.PopupMenu.AddSubmenuNodeItem(string, PopupMenu, int)"/> for more info on how to add a submenu.</para>
    /// </summary>
    public PopupMenu GetItemSubmenuNode(int index)
    {
        return (PopupMenu)NativeCalls.godot_icall_1_335(MethodBind58, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind59 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsItemSeparator, 1116898809ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the item is a separator. If it is, it will be displayed as a line. See <see cref="Godot.PopupMenu.AddSeparator(string, int)"/> for more info on how to add a separator.</para>
    /// </summary>
    public bool IsItemSeparator(int index)
    {
        return NativeCalls.godot_icall_1_62(MethodBind59, GodotObject.GetPtr(this), index).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind60 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsItemCheckable, 1116898809ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the item at the given <paramref name="index"/> is checkable in some way, i.e. if it has a checkbox or radio button.</para>
    /// <para><b>Note:</b> Checkable items just display a checkmark or radio button, but don't have any built-in checking behavior and must be checked/unchecked manually.</para>
    /// </summary>
    public bool IsItemCheckable(int index)
    {
        return NativeCalls.godot_icall_1_62(MethodBind60, GodotObject.GetPtr(this), index).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind61 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsItemRadioCheckable, 1116898809ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the item at the given <paramref name="index"/> has radio button-style checkability.</para>
    /// <para><b>Note:</b> This is purely cosmetic; you must add the logic for checking/unchecking items in radio groups.</para>
    /// </summary>
    public bool IsItemRadioCheckable(int index)
    {
        return NativeCalls.godot_icall_1_62(MethodBind61, GodotObject.GetPtr(this), index).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind62 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsItemShortcutDisabled, 1116898809ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the specified item's shortcut is disabled.</para>
    /// </summary>
    public bool IsItemShortcutDisabled(int index)
    {
        return NativeCalls.godot_icall_1_62(MethodBind62, GodotObject.GetPtr(this), index).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind63 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetItemTooltip, 844755477ul);

    /// <summary>
    /// <para>Returns the tooltip associated with the item at the given <paramref name="index"/>.</para>
    /// </summary>
    public string GetItemTooltip(int index)
    {
        return NativeCalls.godot_icall_1_133(MethodBind63, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind64 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetItemShortcut, 1449483325ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.Shortcut"/> associated with the item at the given <paramref name="index"/>.</para>
    /// </summary>
    public Shortcut GetItemShortcut(int index)
    {
        return (Shortcut)NativeCalls.godot_icall_1_71(MethodBind64, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind65 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetItemIndent, 923996154ul);

    /// <summary>
    /// <para>Returns the horizontal offset of the item at the given <paramref name="index"/>.</para>
    /// </summary>
    public int GetItemIndent(int index)
    {
        return NativeCalls.godot_icall_1_60(MethodBind65, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind66 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetItemMultistateMax, 923996154ul);

    /// <summary>
    /// <para>Returns the max states of the item at the given <paramref name="index"/>.</para>
    /// </summary>
    public int GetItemMultistateMax(int index)
    {
        return NativeCalls.godot_icall_1_60(MethodBind66, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind67 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetItemMultistate, 923996154ul);

    /// <summary>
    /// <para>Returns the state of the item at the given <paramref name="index"/>.</para>
    /// </summary>
    public int GetItemMultistate(int index)
    {
        return NativeCalls.godot_icall_1_60(MethodBind67, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind68 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFocusedItem, 1286410249ul);

    /// <summary>
    /// <para>Sets the currently focused item as the given <paramref name="index"/>.</para>
    /// <para>Passing <c>-1</c> as the index makes so that no item is focused.</para>
    /// </summary>
    public void SetFocusedItem(int index)
    {
        NativeCalls.godot_icall_1_38(MethodBind68, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind69 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFocusedItem, 3905245786ul);

    /// <summary>
    /// <para>Returns the index of the currently focused item. Returns <c>-1</c> if no item is focused.</para>
    /// </summary>
    public int GetFocusedItem()
    {
        return NativeCalls.godot_icall_0_39(MethodBind69, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind70 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetItemCount, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetItemCount(int count)
    {
        NativeCalls.godot_icall_1_38(MethodBind70, GodotObject.GetPtr(this), count);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind71 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetItemCount, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetItemCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind71, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind72 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ScrollToItem, 1286410249ul);

    /// <summary>
    /// <para>Moves the scroll view to make the item at the given <paramref name="index"/> visible.</para>
    /// </summary>
    public void ScrollToItem(int index)
    {
        NativeCalls.godot_icall_1_38(MethodBind72, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind73 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveItem, 1286410249ul);

    /// <summary>
    /// <para>Removes the item at the given <paramref name="index"/> from the menu.</para>
    /// <para><b>Note:</b> The indices of items after the removed item will be shifted by one.</para>
    /// </summary>
    public void RemoveItem(int index)
    {
        NativeCalls.godot_icall_1_38(MethodBind73, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind74 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddSeparator, 2266703459ul);

    /// <summary>
    /// <para>Adds a separator between items. Separators also occupy an index, which you can set by using the <paramref name="id"/> parameter.</para>
    /// <para>A <paramref name="label"/> can optionally be provided, which will appear at the center of the separator.</para>
    /// </summary>
    public void AddSeparator(string label = "", int id = -1)
    {
        NativeCalls.godot_icall_2_400(MethodBind74, GodotObject.GetPtr(this), label, id);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind75 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Clear, 107499316ul);

    /// <summary>
    /// <para>Removes all items from the <see cref="Godot.PopupMenu"/>. If <paramref name="freeSubmenus"/> is <see langword="true"/>, the submenu nodes are automatically freed.</para>
    /// </summary>
    public void Clear(bool freeSubmenus = false)
    {
        NativeCalls.godot_icall_1_14(MethodBind75, GodotObject.GetPtr(this), freeSubmenus.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind76 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetHideOnItemSelection, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetHideOnItemSelection(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind76, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind77 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsHideOnItemSelection, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsHideOnItemSelection()
    {
        return NativeCalls.godot_icall_0_15(MethodBind77, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind78 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetHideOnCheckableItemSelection, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetHideOnCheckableItemSelection(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind78, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind79 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsHideOnCheckableItemSelection, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsHideOnCheckableItemSelection()
    {
        return NativeCalls.godot_icall_0_15(MethodBind79, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind80 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetHideOnStateItemSelection, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetHideOnStateItemSelection(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind80, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind81 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsHideOnStateItemSelection, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsHideOnStateItemSelection()
    {
        return NativeCalls.godot_icall_0_15(MethodBind81, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind82 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSubmenuPopupDelay, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSubmenuPopupDelay(float seconds)
    {
        NativeCalls.godot_icall_1_67(MethodBind82, GodotObject.GetPtr(this), seconds);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind83 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSubmenuPopupDelay, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetSubmenuPopupDelay()
    {
        return NativeCalls.godot_icall_0_68(MethodBind83, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind84 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAllowSearch, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAllowSearch(bool allow)
    {
        NativeCalls.godot_icall_1_14(MethodBind84, GodotObject.GetPtr(this), allow.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind85 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAllowSearch, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetAllowSearch()
    {
        return NativeCalls.godot_icall_0_15(MethodBind85, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind86 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsSystemMenu, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the menu is bound to the special system menu.</para>
    /// </summary>
    public bool IsSystemMenu()
    {
        return NativeCalls.godot_icall_0_15(MethodBind86, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind87 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSystemMenu, 600639674ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSystemMenu(NativeMenu.SystemMenus systemMenuId)
    {
        NativeCalls.godot_icall_1_38(MethodBind87, GodotObject.GetPtr(this), (int)systemMenuId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind88 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSystemMenu, 1222557358ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public NativeMenu.SystemMenus GetSystemMenu()
    {
        return (NativeMenu.SystemMenus)NativeCalls.godot_icall_0_39(MethodBind88, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind89 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetShrinkHeight, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetShrinkHeight(bool shrink)
    {
        NativeCalls.godot_icall_1_14(MethodBind89, GodotObject.GetPtr(this), shrink.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind90 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetShrinkHeight, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetShrinkHeight()
    {
        return NativeCalls.godot_icall_0_15(MethodBind90, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind91 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetShrinkWidth, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetShrinkWidth(bool shrink)
    {
        NativeCalls.godot_icall_1_14(MethodBind91, GodotObject.GetPtr(this), shrink.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind92 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetShrinkWidth, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetShrinkWidth()
    {
        return NativeCalls.godot_icall_0_15(MethodBind92, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind93 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSystemMenuRoot, 201670096ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetSystemMenuRoot()
    {
        return NativeCalls.godot_icall_0_58(MethodBind93, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind94 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSystemMenuRoot, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSystemMenuRoot(string special)
    {
        NativeCalls.godot_icall_1_57(MethodBind94, GodotObject.GetPtr(this), special);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind95 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Clear, 3218959716ul);

    /// <summary>
    /// <para>Removes all items from the <see cref="Godot.PopupMenu"/>. If <paramref name="freeSubmenus"/> is <see langword="true"/>, the submenu nodes are automatically freed.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void Clear()
    {
        NativeCalls.godot_icall_0_3(MethodBind95, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind96 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddIconShortcut, 3856247530ul);

    /// <summary>
    /// <para>Adds a new item and assigns the specified <see cref="Godot.Shortcut"/> and icon <paramref name="texture"/> to it. Sets the label of the checkbox to the <see cref="Godot.Shortcut"/>'s name.</para>
    /// <para>An <paramref name="id"/> can optionally be provided. If no <paramref name="id"/> is provided, one will be created from the index.</para>
    /// <para>If <paramref name="allowEcho"/> is <see langword="true"/>, the shortcut can be activated with echo events.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void AddIconShortcut(Texture2D texture, Shortcut shortcut, int id, bool global)
    {
        NativeCalls.godot_icall_4_1020(MethodBind96, GodotObject.GetPtr(this), GodotObject.GetPtr(texture), GodotObject.GetPtr(shortcut), id, global.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind97 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddShortcut, 1642193386ul);

    /// <summary>
    /// <para>Adds a <see cref="Godot.Shortcut"/>.</para>
    /// <para>An <paramref name="id"/> can optionally be provided. If no <paramref name="id"/> is provided, one will be created from the index.</para>
    /// <para>If <paramref name="allowEcho"/> is <see langword="true"/>, the shortcut can be activated with echo events.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void AddShortcut(Shortcut shortcut, int id, bool global)
    {
        NativeCalls.godot_icall_3_1019(MethodBind97, GodotObject.GetPtr(this), GodotObject.GetPtr(shortcut), id, global.ToGodotBool());
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.PopupMenu.IdPressed"/> event of a <see cref="Godot.PopupMenu"/> class.
    /// </summary>
    public delegate void IdPressedEventHandler(long id);

    private static void IdPressedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((IdPressedEventHandler)delegateObj)(VariantUtils.ConvertTo<long>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when an item of some <c>id</c> is pressed. Also emitted when its accelerator is activated on macOS.</para>
    /// <para><b>Note:</b> If <c>id</c> is negative (either explicitly or due to overflow), this will return the corresponding index instead.</para>
    /// </summary>
    public unsafe event IdPressedEventHandler IdPressed
    {
        add => Connect(SignalName.IdPressed, Callable.CreateWithUnsafeTrampoline(value, &IdPressedTrampoline));
        remove => Disconnect(SignalName.IdPressed, Callable.CreateWithUnsafeTrampoline(value, &IdPressedTrampoline));
    }

    protected void EmitSignalIdPressed(long id)
    {
        EmitSignal(SignalName.IdPressed, id);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.PopupMenu.IdFocused"/> event of a <see cref="Godot.PopupMenu"/> class.
    /// </summary>
    public delegate void IdFocusedEventHandler(long id);

    private static void IdFocusedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((IdFocusedEventHandler)delegateObj)(VariantUtils.ConvertTo<long>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when the user navigated to an item of some <c>id</c> using the <c>ProjectSettings.input/ui_up</c> or <c>ProjectSettings.input/ui_down</c> input action.</para>
    /// </summary>
    public unsafe event IdFocusedEventHandler IdFocused
    {
        add => Connect(SignalName.IdFocused, Callable.CreateWithUnsafeTrampoline(value, &IdFocusedTrampoline));
        remove => Disconnect(SignalName.IdFocused, Callable.CreateWithUnsafeTrampoline(value, &IdFocusedTrampoline));
    }

    protected void EmitSignalIdFocused(long id)
    {
        EmitSignal(SignalName.IdFocused, id);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.PopupMenu.IndexPressed"/> event of a <see cref="Godot.PopupMenu"/> class.
    /// </summary>
    public delegate void IndexPressedEventHandler(long index);

    private static void IndexPressedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((IndexPressedEventHandler)delegateObj)(VariantUtils.ConvertTo<long>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when an item of some <c>index</c> is pressed. Also emitted when its accelerator is activated on macOS.</para>
    /// </summary>
    public unsafe event IndexPressedEventHandler IndexPressed
    {
        add => Connect(SignalName.IndexPressed, Callable.CreateWithUnsafeTrampoline(value, &IndexPressedTrampoline));
        remove => Disconnect(SignalName.IndexPressed, Callable.CreateWithUnsafeTrampoline(value, &IndexPressedTrampoline));
    }

    protected void EmitSignalIndexPressed(long index)
    {
        EmitSignal(SignalName.IndexPressed, index);
    }

    /// <summary>
    /// <para>Emitted when any item is added, modified or removed.</para>
    /// </summary>
    public event Action MenuChanged
    {
        add => Connect(SignalName.MenuChanged, Callable.From(value));
        remove => Disconnect(SignalName.MenuChanged, Callable.From(value));
    }

    protected void EmitSignalMenuChanged()
    {
        EmitSignal(SignalName.MenuChanged);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_id_pressed = "IdPressed";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_id_focused = "IdFocused";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_index_pressed = "IndexPressed";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_menu_changed = "MenuChanged";

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
        if (signal == SignalName.IdPressed)
        {
            if (HasGodotClassSignal(SignalProxyName_id_pressed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.IdFocused)
        {
            if (HasGodotClassSignal(SignalProxyName_id_focused.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.IndexPressed)
        {
            if (HasGodotClassSignal(SignalProxyName_index_pressed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.MenuChanged)
        {
            if (HasGodotClassSignal(SignalProxyName_menu_changed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        return base.HasGodotClassSignal(signal);
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : Popup.PropertyName
    {
        /// <summary>
        /// Cached name for the 'hide_on_item_selection' property.
        /// </summary>
        public static readonly StringName HideOnItemSelection = "hide_on_item_selection";
        /// <summary>
        /// Cached name for the 'hide_on_checkable_item_selection' property.
        /// </summary>
        public static readonly StringName HideOnCheckableItemSelection = "hide_on_checkable_item_selection";
        /// <summary>
        /// Cached name for the 'hide_on_state_item_selection' property.
        /// </summary>
        public static readonly StringName HideOnStateItemSelection = "hide_on_state_item_selection";
        /// <summary>
        /// Cached name for the 'submenu_popup_delay' property.
        /// </summary>
        public static readonly StringName SubmenuPopupDelay = "submenu_popup_delay";
        /// <summary>
        /// Cached name for the 'allow_search' property.
        /// </summary>
        public static readonly StringName AllowSearch = "allow_search";
        /// <summary>
        /// Cached name for the 'system_menu_id' property.
        /// </summary>
        public static readonly StringName SystemMenuId = "system_menu_id";
        /// <summary>
        /// Cached name for the 'prefer_native_menu' property.
        /// </summary>
        public static readonly StringName PreferNativeMenu = "prefer_native_menu";
        /// <summary>
        /// Cached name for the 'shrink_height' property.
        /// </summary>
        public static readonly StringName ShrinkHeight = "shrink_height";
        /// <summary>
        /// Cached name for the 'shrink_width' property.
        /// </summary>
        public static readonly StringName ShrinkWidth = "shrink_width";
        /// <summary>
        /// Cached name for the 'item_count' property.
        /// </summary>
        public static readonly StringName ItemCount = "item_count";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Popup.MethodName
    {
        /// <summary>
        /// Cached name for the 'activate_item_by_event' method.
        /// </summary>
        public static readonly StringName ActivateItemByEvent = "activate_item_by_event";
        /// <summary>
        /// Cached name for the 'set_prefer_native_menu' method.
        /// </summary>
        public static readonly StringName SetPreferNativeMenu = "set_prefer_native_menu";
        /// <summary>
        /// Cached name for the 'is_prefer_native_menu' method.
        /// </summary>
        public static readonly StringName IsPreferNativeMenu = "is_prefer_native_menu";
        /// <summary>
        /// Cached name for the 'is_native_menu' method.
        /// </summary>
        public static readonly StringName IsNativeMenu = "is_native_menu";
        /// <summary>
        /// Cached name for the 'add_item' method.
        /// </summary>
        public static readonly StringName AddItem = "add_item";
        /// <summary>
        /// Cached name for the 'add_icon_item' method.
        /// </summary>
        public static readonly StringName AddIconItem = "add_icon_item";
        /// <summary>
        /// Cached name for the 'add_check_item' method.
        /// </summary>
        public static readonly StringName AddCheckItem = "add_check_item";
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
        /// Cached name for the 'add_shortcut' method.
        /// </summary>
        public static readonly StringName AddShortcut = "add_shortcut";
        /// <summary>
        /// Cached name for the 'add_icon_shortcut' method.
        /// </summary>
        public static readonly StringName AddIconShortcut = "add_icon_shortcut";
        /// <summary>
        /// Cached name for the 'add_check_shortcut' method.
        /// </summary>
        public static readonly StringName AddCheckShortcut = "add_check_shortcut";
        /// <summary>
        /// Cached name for the 'add_icon_check_shortcut' method.
        /// </summary>
        public static readonly StringName AddIconCheckShortcut = "add_icon_check_shortcut";
        /// <summary>
        /// Cached name for the 'add_radio_check_shortcut' method.
        /// </summary>
        public static readonly StringName AddRadioCheckShortcut = "add_radio_check_shortcut";
        /// <summary>
        /// Cached name for the 'add_icon_radio_check_shortcut' method.
        /// </summary>
        public static readonly StringName AddIconRadioCheckShortcut = "add_icon_radio_check_shortcut";
        /// <summary>
        /// Cached name for the 'add_submenu_item' method.
        /// </summary>
        public static readonly StringName AddSubmenuItem = "add_submenu_item";
        /// <summary>
        /// Cached name for the 'add_submenu_node_item' method.
        /// </summary>
        public static readonly StringName AddSubmenuNodeItem = "add_submenu_node_item";
        /// <summary>
        /// Cached name for the 'set_item_text' method.
        /// </summary>
        public static readonly StringName SetItemText = "set_item_text";
        /// <summary>
        /// Cached name for the 'set_item_text_direction' method.
        /// </summary>
        public static readonly StringName SetItemTextDirection = "set_item_text_direction";
        /// <summary>
        /// Cached name for the 'set_item_language' method.
        /// </summary>
        public static readonly StringName SetItemLanguage = "set_item_language";
        /// <summary>
        /// Cached name for the 'set_item_auto_translate_mode' method.
        /// </summary>
        public static readonly StringName SetItemAutoTranslateMode = "set_item_auto_translate_mode";
        /// <summary>
        /// Cached name for the 'set_item_icon' method.
        /// </summary>
        public static readonly StringName SetItemIcon = "set_item_icon";
        /// <summary>
        /// Cached name for the 'set_item_icon_max_width' method.
        /// </summary>
        public static readonly StringName SetItemIconMaxWidth = "set_item_icon_max_width";
        /// <summary>
        /// Cached name for the 'set_item_icon_modulate' method.
        /// </summary>
        public static readonly StringName SetItemIconModulate = "set_item_icon_modulate";
        /// <summary>
        /// Cached name for the 'set_item_checked' method.
        /// </summary>
        public static readonly StringName SetItemChecked = "set_item_checked";
        /// <summary>
        /// Cached name for the 'set_item_id' method.
        /// </summary>
        public static readonly StringName SetItemId = "set_item_id";
        /// <summary>
        /// Cached name for the 'set_item_accelerator' method.
        /// </summary>
        public static readonly StringName SetItemAccelerator = "set_item_accelerator";
        /// <summary>
        /// Cached name for the 'set_item_metadata' method.
        /// </summary>
        public static readonly StringName SetItemMetadata = "set_item_metadata";
        /// <summary>
        /// Cached name for the 'set_item_disabled' method.
        /// </summary>
        public static readonly StringName SetItemDisabled = "set_item_disabled";
        /// <summary>
        /// Cached name for the 'set_item_submenu' method.
        /// </summary>
        public static readonly StringName SetItemSubmenu = "set_item_submenu";
        /// <summary>
        /// Cached name for the 'set_item_submenu_node' method.
        /// </summary>
        public static readonly StringName SetItemSubmenuNode = "set_item_submenu_node";
        /// <summary>
        /// Cached name for the 'set_item_as_separator' method.
        /// </summary>
        public static readonly StringName SetItemAsSeparator = "set_item_as_separator";
        /// <summary>
        /// Cached name for the 'set_item_as_checkable' method.
        /// </summary>
        public static readonly StringName SetItemAsCheckable = "set_item_as_checkable";
        /// <summary>
        /// Cached name for the 'set_item_as_radio_checkable' method.
        /// </summary>
        public static readonly StringName SetItemAsRadioCheckable = "set_item_as_radio_checkable";
        /// <summary>
        /// Cached name for the 'set_item_tooltip' method.
        /// </summary>
        public static readonly StringName SetItemTooltip = "set_item_tooltip";
        /// <summary>
        /// Cached name for the 'set_item_shortcut' method.
        /// </summary>
        public static readonly StringName SetItemShortcut = "set_item_shortcut";
        /// <summary>
        /// Cached name for the 'set_item_indent' method.
        /// </summary>
        public static readonly StringName SetItemIndent = "set_item_indent";
        /// <summary>
        /// Cached name for the 'set_item_multistate' method.
        /// </summary>
        public static readonly StringName SetItemMultistate = "set_item_multistate";
        /// <summary>
        /// Cached name for the 'set_item_multistate_max' method.
        /// </summary>
        public static readonly StringName SetItemMultistateMax = "set_item_multistate_max";
        /// <summary>
        /// Cached name for the 'set_item_shortcut_disabled' method.
        /// </summary>
        public static readonly StringName SetItemShortcutDisabled = "set_item_shortcut_disabled";
        /// <summary>
        /// Cached name for the 'toggle_item_checked' method.
        /// </summary>
        public static readonly StringName ToggleItemChecked = "toggle_item_checked";
        /// <summary>
        /// Cached name for the 'toggle_item_multistate' method.
        /// </summary>
        public static readonly StringName ToggleItemMultistate = "toggle_item_multistate";
        /// <summary>
        /// Cached name for the 'get_item_text' method.
        /// </summary>
        public static readonly StringName GetItemText = "get_item_text";
        /// <summary>
        /// Cached name for the 'get_item_text_direction' method.
        /// </summary>
        public static readonly StringName GetItemTextDirection = "get_item_text_direction";
        /// <summary>
        /// Cached name for the 'get_item_language' method.
        /// </summary>
        public static readonly StringName GetItemLanguage = "get_item_language";
        /// <summary>
        /// Cached name for the 'get_item_auto_translate_mode' method.
        /// </summary>
        public static readonly StringName GetItemAutoTranslateMode = "get_item_auto_translate_mode";
        /// <summary>
        /// Cached name for the 'get_item_icon' method.
        /// </summary>
        public static readonly StringName GetItemIcon = "get_item_icon";
        /// <summary>
        /// Cached name for the 'get_item_icon_max_width' method.
        /// </summary>
        public static readonly StringName GetItemIconMaxWidth = "get_item_icon_max_width";
        /// <summary>
        /// Cached name for the 'get_item_icon_modulate' method.
        /// </summary>
        public static readonly StringName GetItemIconModulate = "get_item_icon_modulate";
        /// <summary>
        /// Cached name for the 'is_item_checked' method.
        /// </summary>
        public static readonly StringName IsItemChecked = "is_item_checked";
        /// <summary>
        /// Cached name for the 'get_item_id' method.
        /// </summary>
        public static readonly StringName GetItemId = "get_item_id";
        /// <summary>
        /// Cached name for the 'get_item_index' method.
        /// </summary>
        public static readonly StringName GetItemIndex = "get_item_index";
        /// <summary>
        /// Cached name for the 'get_item_accelerator' method.
        /// </summary>
        public static readonly StringName GetItemAccelerator = "get_item_accelerator";
        /// <summary>
        /// Cached name for the 'get_item_metadata' method.
        /// </summary>
        public static readonly StringName GetItemMetadata = "get_item_metadata";
        /// <summary>
        /// Cached name for the 'is_item_disabled' method.
        /// </summary>
        public static readonly StringName IsItemDisabled = "is_item_disabled";
        /// <summary>
        /// Cached name for the 'get_item_submenu' method.
        /// </summary>
        public static readonly StringName GetItemSubmenu = "get_item_submenu";
        /// <summary>
        /// Cached name for the 'get_item_submenu_node' method.
        /// </summary>
        public static readonly StringName GetItemSubmenuNode = "get_item_submenu_node";
        /// <summary>
        /// Cached name for the 'is_item_separator' method.
        /// </summary>
        public static readonly StringName IsItemSeparator = "is_item_separator";
        /// <summary>
        /// Cached name for the 'is_item_checkable' method.
        /// </summary>
        public static readonly StringName IsItemCheckable = "is_item_checkable";
        /// <summary>
        /// Cached name for the 'is_item_radio_checkable' method.
        /// </summary>
        public static readonly StringName IsItemRadioCheckable = "is_item_radio_checkable";
        /// <summary>
        /// Cached name for the 'is_item_shortcut_disabled' method.
        /// </summary>
        public static readonly StringName IsItemShortcutDisabled = "is_item_shortcut_disabled";
        /// <summary>
        /// Cached name for the 'get_item_tooltip' method.
        /// </summary>
        public static readonly StringName GetItemTooltip = "get_item_tooltip";
        /// <summary>
        /// Cached name for the 'get_item_shortcut' method.
        /// </summary>
        public static readonly StringName GetItemShortcut = "get_item_shortcut";
        /// <summary>
        /// Cached name for the 'get_item_indent' method.
        /// </summary>
        public static readonly StringName GetItemIndent = "get_item_indent";
        /// <summary>
        /// Cached name for the 'get_item_multistate_max' method.
        /// </summary>
        public static readonly StringName GetItemMultistateMax = "get_item_multistate_max";
        /// <summary>
        /// Cached name for the 'get_item_multistate' method.
        /// </summary>
        public static readonly StringName GetItemMultistate = "get_item_multistate";
        /// <summary>
        /// Cached name for the 'set_focused_item' method.
        /// </summary>
        public static readonly StringName SetFocusedItem = "set_focused_item";
        /// <summary>
        /// Cached name for the 'get_focused_item' method.
        /// </summary>
        public static readonly StringName GetFocusedItem = "get_focused_item";
        /// <summary>
        /// Cached name for the 'set_item_count' method.
        /// </summary>
        public static readonly StringName SetItemCount = "set_item_count";
        /// <summary>
        /// Cached name for the 'get_item_count' method.
        /// </summary>
        public static readonly StringName GetItemCount = "get_item_count";
        /// <summary>
        /// Cached name for the 'scroll_to_item' method.
        /// </summary>
        public static readonly StringName ScrollToItem = "scroll_to_item";
        /// <summary>
        /// Cached name for the 'remove_item' method.
        /// </summary>
        public static readonly StringName RemoveItem = "remove_item";
        /// <summary>
        /// Cached name for the 'add_separator' method.
        /// </summary>
        public static readonly StringName AddSeparator = "add_separator";
        /// <summary>
        /// Cached name for the 'clear' method.
        /// </summary>
        public static readonly StringName Clear = "clear";
        /// <summary>
        /// Cached name for the 'set_hide_on_item_selection' method.
        /// </summary>
        public static readonly StringName SetHideOnItemSelection = "set_hide_on_item_selection";
        /// <summary>
        /// Cached name for the 'is_hide_on_item_selection' method.
        /// </summary>
        public static readonly StringName IsHideOnItemSelection = "is_hide_on_item_selection";
        /// <summary>
        /// Cached name for the 'set_hide_on_checkable_item_selection' method.
        /// </summary>
        public static readonly StringName SetHideOnCheckableItemSelection = "set_hide_on_checkable_item_selection";
        /// <summary>
        /// Cached name for the 'is_hide_on_checkable_item_selection' method.
        /// </summary>
        public static readonly StringName IsHideOnCheckableItemSelection = "is_hide_on_checkable_item_selection";
        /// <summary>
        /// Cached name for the 'set_hide_on_state_item_selection' method.
        /// </summary>
        public static readonly StringName SetHideOnStateItemSelection = "set_hide_on_state_item_selection";
        /// <summary>
        /// Cached name for the 'is_hide_on_state_item_selection' method.
        /// </summary>
        public static readonly StringName IsHideOnStateItemSelection = "is_hide_on_state_item_selection";
        /// <summary>
        /// Cached name for the 'set_submenu_popup_delay' method.
        /// </summary>
        public static readonly StringName SetSubmenuPopupDelay = "set_submenu_popup_delay";
        /// <summary>
        /// Cached name for the 'get_submenu_popup_delay' method.
        /// </summary>
        public static readonly StringName GetSubmenuPopupDelay = "get_submenu_popup_delay";
        /// <summary>
        /// Cached name for the 'set_allow_search' method.
        /// </summary>
        public static readonly StringName SetAllowSearch = "set_allow_search";
        /// <summary>
        /// Cached name for the 'get_allow_search' method.
        /// </summary>
        public static readonly StringName GetAllowSearch = "get_allow_search";
        /// <summary>
        /// Cached name for the 'is_system_menu' method.
        /// </summary>
        public static readonly StringName IsSystemMenu = "is_system_menu";
        /// <summary>
        /// Cached name for the 'set_system_menu' method.
        /// </summary>
        public static readonly StringName SetSystemMenu = "set_system_menu";
        /// <summary>
        /// Cached name for the 'get_system_menu' method.
        /// </summary>
        public static readonly StringName GetSystemMenu = "get_system_menu";
        /// <summary>
        /// Cached name for the 'set_shrink_height' method.
        /// </summary>
        public static readonly StringName SetShrinkHeight = "set_shrink_height";
        /// <summary>
        /// Cached name for the 'get_shrink_height' method.
        /// </summary>
        public static readonly StringName GetShrinkHeight = "get_shrink_height";
        /// <summary>
        /// Cached name for the 'set_shrink_width' method.
        /// </summary>
        public static readonly StringName SetShrinkWidth = "set_shrink_width";
        /// <summary>
        /// Cached name for the 'get_shrink_width' method.
        /// </summary>
        public static readonly StringName GetShrinkWidth = "get_shrink_width";
        /// <summary>
        /// Cached name for the 'get_system_menu_root' method.
        /// </summary>
        public static readonly StringName GetSystemMenuRoot = "get_system_menu_root";
        /// <summary>
        /// Cached name for the 'set_system_menu_root' method.
        /// </summary>
        public static readonly StringName SetSystemMenuRoot = "set_system_menu_root";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Popup.SignalName
    {
        /// <summary>
        /// Cached name for the 'id_pressed' signal.
        /// </summary>
        public static readonly StringName IdPressed = "id_pressed";
        /// <summary>
        /// Cached name for the 'id_focused' signal.
        /// </summary>
        public static readonly StringName IdFocused = "id_focused";
        /// <summary>
        /// Cached name for the 'index_pressed' signal.
        /// </summary>
        public static readonly StringName IndexPressed = "index_pressed";
        /// <summary>
        /// Cached name for the 'menu_changed' signal.
        /// </summary>
        public static readonly StringName MenuChanged = "menu_changed";
    }
}
