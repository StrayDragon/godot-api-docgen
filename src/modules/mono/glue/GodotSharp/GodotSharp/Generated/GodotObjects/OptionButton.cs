namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para><see cref="Godot.OptionButton"/> is a type of button that brings up a dropdown with selectable items when pressed. The item selected becomes the "current" item and is displayed as the button text.</para>
/// <para>See also <see cref="Godot.BaseButton"/> which contains common properties and methods associated with this node.</para>
/// <para><b>Note:</b> The IDs used for items are limited to signed 32-bit integers, not the full 64 bits of <see cref="int"/>. These have a range of <c>-2^31</c> to <c>2^31 - 1</c>, that is, <c>-2147483648</c> to <c>2147483647</c>.</para>
/// <para><b>Note:</b> The <see cref="Godot.Button.Text"/> and <see cref="Godot.Button.Icon"/> properties are set automatically based on the selected item. They shouldn't be changed manually.</para>
/// </summary>
public partial class OptionButton : Button
{
    /// <summary>
    /// <para>The index of the currently selected item, or <c>-1</c> if no item is selected.</para>
    /// </summary>
    public int Selected
    {
        get
        {
            return GetSelected();
        }
        set
        {
            _SelectInt(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, minimum size will be determined by the longest item's text, instead of the currently selected one's.</para>
    /// <para><b>Note:</b> For performance reasons, the minimum size doesn't update immediately when adding, removing or modifying items.</para>
    /// </summary>
    public bool FitToLongestItem
    {
        get
        {
            return IsFitToLongestItem();
        }
        set
        {
            SetFitToLongestItem(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the currently selected item can be selected again.</para>
    /// </summary>
    public bool AllowReselect
    {
        get
        {
            return GetAllowReselect();
        }
        set
        {
            SetAllowReselect(value);
        }
    }

    /// <summary>
    /// <para>The number of items to select from.</para>
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

    private static readonly System.Type CachedType = typeof(OptionButton);

    private static readonly StringName NativeName = "OptionButton";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public OptionButton() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal OptionButton(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal OptionButton(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddItem, 2697778442ul);

    /// <summary>
    /// <para>Adds an item, with text <paramref name="label"/> and (optionally) <paramref name="id"/>. If no <paramref name="id"/> is passed, the item index will be used as the item's ID. New items are appended at the end.</para>
    /// <para><b>Note:</b> The item will be selected if there are no other items.</para>
    /// </summary>
    public void AddItem(string label, int id = -1)
    {
        NativeCalls.godot_icall_2_400(MethodBind0, GodotObject.GetPtr(this), label, id);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddIconItem, 3781678508ul);

    /// <summary>
    /// <para>Adds an item, with a <paramref name="texture"/> icon, text <paramref name="label"/> and (optionally) <paramref name="id"/>. If no <paramref name="id"/> is passed, the item index will be used as the item's ID. New items are appended at the end.</para>
    /// <para><b>Note:</b> The item will be selected if there are no other items.</para>
    /// </summary>
    public void AddIconItem(Texture2D texture, string label, int id = -1)
    {
        NativeCalls.godot_icall_3_967(MethodBind1, GodotObject.GetPtr(this), GodotObject.GetPtr(texture), label, id);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetItemText, 501894301ul);

    /// <summary>
    /// <para>Sets the text of the item at index <paramref name="idx"/>.</para>
    /// </summary>
    public void SetItemText(int idx, string text)
    {
        NativeCalls.godot_icall_2_181(MethodBind2, GodotObject.GetPtr(this), idx, text);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetItemIcon, 666127730ul);

    /// <summary>
    /// <para>Sets the icon of the item at index <paramref name="idx"/>.</para>
    /// </summary>
    public void SetItemIcon(int idx, Texture2D texture)
    {
        NativeCalls.godot_icall_2_70(MethodBind3, GodotObject.GetPtr(this), idx, GodotObject.GetPtr(texture));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetItemDisabled, 300928843ul);

    /// <summary>
    /// <para>Sets whether the item at index <paramref name="idx"/> is disabled.</para>
    /// <para>Disabled items are drawn differently in the dropdown and are not selectable by the user. If the current selected item is set as disabled, it will remain selected.</para>
    /// </summary>
    public void SetItemDisabled(int idx, bool disabled)
    {
        NativeCalls.godot_icall_2_61(MethodBind4, GodotObject.GetPtr(this), idx, disabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetItemId, 3937882851ul);

    /// <summary>
    /// <para>Sets the ID of the item at index <paramref name="idx"/>.</para>
    /// </summary>
    public void SetItemId(int idx, int id)
    {
        NativeCalls.godot_icall_2_59(MethodBind5, GodotObject.GetPtr(this), idx, id);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetItemMetadata, 2152698145ul);

    /// <summary>
    /// <para>Sets the metadata of an item. Metadata may be of any type and can be used to store extra information about an item, such as an external string ID.</para>
    /// </summary>
    public void SetItemMetadata(int idx, Variant metadata)
    {
        NativeCalls.godot_icall_2_701(MethodBind6, GodotObject.GetPtr(this), idx, metadata);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetItemTooltip, 501894301ul);

    /// <summary>
    /// <para>Sets the tooltip of the item at index <paramref name="idx"/>.</para>
    /// </summary>
    public void SetItemTooltip(int idx, string tooltip)
    {
        NativeCalls.godot_icall_2_181(MethodBind7, GodotObject.GetPtr(this), idx, tooltip);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetItemAutoTranslateMode, 287402019ul);

    /// <summary>
    /// <para>Sets the auto translate mode of the item at index <paramref name="idx"/>.</para>
    /// <para>Items use <see cref="Godot.Node.AutoTranslateModeEnum.Inherit"/> by default, which uses the same auto translate mode as the <see cref="Godot.OptionButton"/> itself.</para>
    /// </summary>
    public void SetItemAutoTranslateMode(int idx, Node.AutoTranslateModeEnum mode)
    {
        NativeCalls.godot_icall_2_59(MethodBind8, GodotObject.GetPtr(this), idx, (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetItemText, 844755477ul);

    /// <summary>
    /// <para>Returns the text of the item at index <paramref name="idx"/>.</para>
    /// </summary>
    public string GetItemText(int idx)
    {
        return NativeCalls.godot_icall_1_133(MethodBind9, GodotObject.GetPtr(this), idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetItemIcon, 3536238170ul);

    /// <summary>
    /// <para>Returns the icon of the item at index <paramref name="idx"/>.</para>
    /// </summary>
    public Texture2D GetItemIcon(int idx)
    {
        return (Texture2D)NativeCalls.godot_icall_1_71(MethodBind10, GodotObject.GetPtr(this), idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetItemId, 923996154ul);

    /// <summary>
    /// <para>Returns the ID of the item at index <paramref name="idx"/>.</para>
    /// </summary>
    public int GetItemId(int idx)
    {
        return NativeCalls.godot_icall_1_60(MethodBind11, GodotObject.GetPtr(this), idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetItemIndex, 923996154ul);

    /// <summary>
    /// <para>Returns the index of the item with the given <paramref name="id"/>.</para>
    /// </summary>
    public int GetItemIndex(int id)
    {
        return NativeCalls.godot_icall_1_60(MethodBind12, GodotObject.GetPtr(this), id);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetItemMetadata, 4227898402ul);

    /// <summary>
    /// <para>Retrieves the metadata of an item. Metadata may be any type and can be used to store extra information about an item, such as an external string ID.</para>
    /// </summary>
    public Variant GetItemMetadata(int idx)
    {
        return NativeCalls.godot_icall_1_702(MethodBind13, GodotObject.GetPtr(this), idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetItemTooltip, 844755477ul);

    /// <summary>
    /// <para>Returns the tooltip of the item at index <paramref name="idx"/>.</para>
    /// </summary>
    public string GetItemTooltip(int idx)
    {
        return NativeCalls.godot_icall_1_133(MethodBind14, GodotObject.GetPtr(this), idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetItemAutoTranslateMode, 906302372ul);

    /// <summary>
    /// <para>Returns the auto translate mode of the item at index <paramref name="idx"/>.</para>
    /// </summary>
    public Node.AutoTranslateModeEnum GetItemAutoTranslateMode(int idx)
    {
        return (Node.AutoTranslateModeEnum)NativeCalls.godot_icall_1_60(MethodBind15, GodotObject.GetPtr(this), idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsItemDisabled, 1116898809ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the item at index <paramref name="idx"/> is disabled.</para>
    /// </summary>
    public bool IsItemDisabled(int idx)
    {
        return NativeCalls.godot_icall_1_62(MethodBind16, GodotObject.GetPtr(this), idx).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsItemSeparator, 1116898809ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the item at index <paramref name="idx"/> is marked as a separator.</para>
    /// </summary>
    public bool IsItemSeparator(int idx)
    {
        return NativeCalls.godot_icall_1_62(MethodBind17, GodotObject.GetPtr(this), idx).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddSeparator, 3005725572ul);

    /// <summary>
    /// <para>Adds a separator to the list of items. Separators help to group items, and can optionally be given a <paramref name="text"/> header. A separator also gets an index assigned, and is appended at the end of the item list.</para>
    /// </summary>
    public void AddSeparator(string text = "")
    {
        NativeCalls.godot_icall_1_57(MethodBind18, GodotObject.GetPtr(this), text);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Clear, 3218959716ul);

    /// <summary>
    /// <para>Clears all the items in the <see cref="Godot.OptionButton"/>.</para>
    /// </summary>
    public void Clear()
    {
        NativeCalls.godot_icall_0_3(MethodBind19, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Select, 1286410249ul);

    /// <summary>
    /// <para>Selects an item by index and makes it the current item. This will work even if the item is disabled.</para>
    /// <para>Passing <c>-1</c> as the index deselects any currently selected item.</para>
    /// </summary>
    public void Select(int idx)
    {
        NativeCalls.godot_icall_1_38(MethodBind20, GodotObject.GetPtr(this), idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSelected, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetSelected()
    {
        return NativeCalls.godot_icall_0_39(MethodBind21, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSelectedId, 3905245786ul);

    /// <summary>
    /// <para>Returns the ID of the selected item, or <c>-1</c> if no item is selected.</para>
    /// </summary>
    public int GetSelectedId()
    {
        return NativeCalls.godot_icall_0_39(MethodBind22, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSelectedMetadata, 1214101251ul);

    /// <summary>
    /// <para>Gets the metadata of the selected item. Metadata for items can be set using <see cref="Godot.OptionButton.SetItemMetadata(int, Variant)"/>.</para>
    /// </summary>
    public Variant GetSelectedMetadata()
    {
        return NativeCalls.godot_icall_0_772(MethodBind23, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveItem, 1286410249ul);

    /// <summary>
    /// <para>Removes the item at index <paramref name="idx"/>.</para>
    /// </summary>
    public void RemoveItem(int idx)
    {
        NativeCalls.godot_icall_1_38(MethodBind24, GodotObject.GetPtr(this), idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName._SelectInt, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    internal void _SelectInt(int idx)
    {
        NativeCalls.godot_icall_1_38(MethodBind25, GodotObject.GetPtr(this), idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPopup, 229722558ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.PopupMenu"/> contained in this button.</para>
    /// <para><b>Warning:</b> This is a required internal node, removing and freeing it may cause a crash. If you wish to hide it or any of its children, use their <see cref="Godot.Window.Visible"/> property.</para>
    /// </summary>
    public PopupMenu GetPopup()
    {
        return (PopupMenu)NativeCalls.godot_icall_0_53(MethodBind26, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShowPopup, 3218959716ul);

    /// <summary>
    /// <para>Adjusts popup position and sizing for the <see cref="Godot.OptionButton"/>, then shows the <see cref="Godot.PopupMenu"/>. Prefer this over using <c>get_popup().popup()</c>.</para>
    /// </summary>
    public void ShowPopup()
    {
        NativeCalls.godot_icall_0_3(MethodBind27, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetItemCount, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetItemCount(int count)
    {
        NativeCalls.godot_icall_1_38(MethodBind28, GodotObject.GetPtr(this), count);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetItemCount, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetItemCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind29, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasSelectableItems, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if this button contains at least one item which is not disabled, or marked as a separator.</para>
    /// </summary>
    public bool HasSelectableItems()
    {
        return NativeCalls.godot_icall_0_15(MethodBind30, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSelectableItem, 894402480ul);

    /// <summary>
    /// <para>Returns the index of the first item which is not disabled, or marked as a separator. If <paramref name="fromLast"/> is <see langword="true"/>, the items will be searched in reverse order.</para>
    /// <para>Returns <c>-1</c> if no item is found.</para>
    /// </summary>
    public int GetSelectableItem(bool fromLast = false)
    {
        return NativeCalls.godot_icall_1_198(MethodBind31, GodotObject.GetPtr(this), fromLast.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind32 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFitToLongestItem, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFitToLongestItem(bool fit)
    {
        NativeCalls.godot_icall_1_14(MethodBind32, GodotObject.GetPtr(this), fit.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind33 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsFitToLongestItem, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsFitToLongestItem()
    {
        return NativeCalls.godot_icall_0_15(MethodBind33, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind34 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAllowReselect, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAllowReselect(bool allow)
    {
        NativeCalls.godot_icall_1_14(MethodBind34, GodotObject.GetPtr(this), allow.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind35 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAllowReselect, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetAllowReselect()
    {
        return NativeCalls.godot_icall_0_15(MethodBind35, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind36 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDisableShortcuts, 2586408642ul);

    /// <summary>
    /// <para>If <see langword="true"/>, shortcuts are disabled and cannot be used to trigger the button.</para>
    /// </summary>
    public void SetDisableShortcuts(bool disabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind36, GodotObject.GetPtr(this), disabled.ToGodotBool());
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.OptionButton.ItemSelected"/> event of a <see cref="Godot.OptionButton"/> class.
    /// </summary>
    public delegate void ItemSelectedEventHandler(long index);

    private static void ItemSelectedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((ItemSelectedEventHandler)delegateObj)(VariantUtils.ConvertTo<long>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when the current item has been changed by the user. The index of the item selected is passed as argument.</para>
    /// <para><see cref="Godot.OptionButton.AllowReselect"/> must be enabled to reselect an item.</para>
    /// </summary>
    public unsafe event ItemSelectedEventHandler ItemSelected
    {
        add => Connect(SignalName.ItemSelected, Callable.CreateWithUnsafeTrampoline(value, &ItemSelectedTrampoline));
        remove => Disconnect(SignalName.ItemSelected, Callable.CreateWithUnsafeTrampoline(value, &ItemSelectedTrampoline));
    }

    protected void EmitSignalItemSelected(long index)
    {
        EmitSignal(SignalName.ItemSelected, index);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.OptionButton.ItemFocused"/> event of a <see cref="Godot.OptionButton"/> class.
    /// </summary>
    public delegate void ItemFocusedEventHandler(long index);

    private static void ItemFocusedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((ItemFocusedEventHandler)delegateObj)(VariantUtils.ConvertTo<long>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when the user navigates to an item using the <c>ProjectSettings.input/ui_up</c> or <c>ProjectSettings.input/ui_down</c> input actions. The index of the item selected is passed as argument.</para>
    /// </summary>
    public unsafe event ItemFocusedEventHandler ItemFocused
    {
        add => Connect(SignalName.ItemFocused, Callable.CreateWithUnsafeTrampoline(value, &ItemFocusedTrampoline));
        remove => Disconnect(SignalName.ItemFocused, Callable.CreateWithUnsafeTrampoline(value, &ItemFocusedTrampoline));
    }

    protected void EmitSignalItemFocused(long index)
    {
        EmitSignal(SignalName.ItemFocused, index);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_item_selected = "ItemSelected";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_item_focused = "ItemFocused";

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
        if (signal == SignalName.ItemSelected)
        {
            if (HasGodotClassSignal(SignalProxyName_item_selected.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.ItemFocused)
        {
            if (HasGodotClassSignal(SignalProxyName_item_focused.NativeValue.DangerousSelfRef))
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
        /// Cached name for the 'selected' property.
        /// </summary>
        public static readonly StringName Selected = "selected";
        /// <summary>
        /// Cached name for the 'fit_to_longest_item' property.
        /// </summary>
        public static readonly StringName FitToLongestItem = "fit_to_longest_item";
        /// <summary>
        /// Cached name for the 'allow_reselect' property.
        /// </summary>
        public static readonly StringName AllowReselect = "allow_reselect";
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
        /// Cached name for the 'add_item' method.
        /// </summary>
        public static readonly StringName AddItem = "add_item";
        /// <summary>
        /// Cached name for the 'add_icon_item' method.
        /// </summary>
        public static readonly StringName AddIconItem = "add_icon_item";
        /// <summary>
        /// Cached name for the 'set_item_text' method.
        /// </summary>
        public static readonly StringName SetItemText = "set_item_text";
        /// <summary>
        /// Cached name for the 'set_item_icon' method.
        /// </summary>
        public static readonly StringName SetItemIcon = "set_item_icon";
        /// <summary>
        /// Cached name for the 'set_item_disabled' method.
        /// </summary>
        public static readonly StringName SetItemDisabled = "set_item_disabled";
        /// <summary>
        /// Cached name for the 'set_item_id' method.
        /// </summary>
        public static readonly StringName SetItemId = "set_item_id";
        /// <summary>
        /// Cached name for the 'set_item_metadata' method.
        /// </summary>
        public static readonly StringName SetItemMetadata = "set_item_metadata";
        /// <summary>
        /// Cached name for the 'set_item_tooltip' method.
        /// </summary>
        public static readonly StringName SetItemTooltip = "set_item_tooltip";
        /// <summary>
        /// Cached name for the 'set_item_auto_translate_mode' method.
        /// </summary>
        public static readonly StringName SetItemAutoTranslateMode = "set_item_auto_translate_mode";
        /// <summary>
        /// Cached name for the 'get_item_text' method.
        /// </summary>
        public static readonly StringName GetItemText = "get_item_text";
        /// <summary>
        /// Cached name for the 'get_item_icon' method.
        /// </summary>
        public static readonly StringName GetItemIcon = "get_item_icon";
        /// <summary>
        /// Cached name for the 'get_item_id' method.
        /// </summary>
        public static readonly StringName GetItemId = "get_item_id";
        /// <summary>
        /// Cached name for the 'get_item_index' method.
        /// </summary>
        public static readonly StringName GetItemIndex = "get_item_index";
        /// <summary>
        /// Cached name for the 'get_item_metadata' method.
        /// </summary>
        public static readonly StringName GetItemMetadata = "get_item_metadata";
        /// <summary>
        /// Cached name for the 'get_item_tooltip' method.
        /// </summary>
        public static readonly StringName GetItemTooltip = "get_item_tooltip";
        /// <summary>
        /// Cached name for the 'get_item_auto_translate_mode' method.
        /// </summary>
        public static readonly StringName GetItemAutoTranslateMode = "get_item_auto_translate_mode";
        /// <summary>
        /// Cached name for the 'is_item_disabled' method.
        /// </summary>
        public static readonly StringName IsItemDisabled = "is_item_disabled";
        /// <summary>
        /// Cached name for the 'is_item_separator' method.
        /// </summary>
        public static readonly StringName IsItemSeparator = "is_item_separator";
        /// <summary>
        /// Cached name for the 'add_separator' method.
        /// </summary>
        public static readonly StringName AddSeparator = "add_separator";
        /// <summary>
        /// Cached name for the 'clear' method.
        /// </summary>
        public static readonly StringName Clear = "clear";
        /// <summary>
        /// Cached name for the 'select' method.
        /// </summary>
        public static readonly StringName Select = "select";
        /// <summary>
        /// Cached name for the 'get_selected' method.
        /// </summary>
        public static readonly StringName GetSelected = "get_selected";
        /// <summary>
        /// Cached name for the 'get_selected_id' method.
        /// </summary>
        public static readonly StringName GetSelectedId = "get_selected_id";
        /// <summary>
        /// Cached name for the 'get_selected_metadata' method.
        /// </summary>
        public static readonly StringName GetSelectedMetadata = "get_selected_metadata";
        /// <summary>
        /// Cached name for the 'remove_item' method.
        /// </summary>
        public static readonly StringName RemoveItem = "remove_item";
        /// <summary>
        /// Cached name for the '_select_int' method.
        /// </summary>
        public static readonly StringName _SelectInt = "_select_int";
        /// <summary>
        /// Cached name for the 'get_popup' method.
        /// </summary>
        public static readonly StringName GetPopup = "get_popup";
        /// <summary>
        /// Cached name for the 'show_popup' method.
        /// </summary>
        public static readonly StringName ShowPopup = "show_popup";
        /// <summary>
        /// Cached name for the 'set_item_count' method.
        /// </summary>
        public static readonly StringName SetItemCount = "set_item_count";
        /// <summary>
        /// Cached name for the 'get_item_count' method.
        /// </summary>
        public static readonly StringName GetItemCount = "get_item_count";
        /// <summary>
        /// Cached name for the 'has_selectable_items' method.
        /// </summary>
        public static readonly StringName HasSelectableItems = "has_selectable_items";
        /// <summary>
        /// Cached name for the 'get_selectable_item' method.
        /// </summary>
        public static readonly StringName GetSelectableItem = "get_selectable_item";
        /// <summary>
        /// Cached name for the 'set_fit_to_longest_item' method.
        /// </summary>
        public static readonly StringName SetFitToLongestItem = "set_fit_to_longest_item";
        /// <summary>
        /// Cached name for the 'is_fit_to_longest_item' method.
        /// </summary>
        public static readonly StringName IsFitToLongestItem = "is_fit_to_longest_item";
        /// <summary>
        /// Cached name for the 'set_allow_reselect' method.
        /// </summary>
        public static readonly StringName SetAllowReselect = "set_allow_reselect";
        /// <summary>
        /// Cached name for the 'get_allow_reselect' method.
        /// </summary>
        public static readonly StringName GetAllowReselect = "get_allow_reselect";
        /// <summary>
        /// Cached name for the 'set_disable_shortcuts' method.
        /// </summary>
        public static readonly StringName SetDisableShortcuts = "set_disable_shortcuts";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Button.SignalName
    {
        /// <summary>
        /// Cached name for the 'item_selected' signal.
        /// </summary>
        public static readonly StringName ItemSelected = "item_selected";
        /// <summary>
        /// Cached name for the 'item_focused' signal.
        /// </summary>
        public static readonly StringName ItemFocused = "item_focused";
    }
}
