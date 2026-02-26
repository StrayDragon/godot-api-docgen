namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This control provides a vertical list of selectable items that may be in a single or in multiple columns, with each item having options for text and an icon. Tooltips are supported and may be different for every item in the list.</para>
/// <para>Selectable items in the list may be selected or deselected and multiple selection may be enabled. Selection with right mouse button may also be enabled to allow use of popup context menus. Items may also be "activated" by double-clicking them or by pressing Enter.</para>
/// <para>Item text only supports single-line strings. Newline characters (e.g. <c>\n</c>) in the string won't produce a newline. Text wrapping is enabled in <see cref="Godot.ItemList.IconModeEnum.Top"/> mode, but the column's width is adjusted to fully fit its content by default. You need to set <see cref="Godot.ItemList.FixedColumnWidth"/> greater than zero to wrap the text.</para>
/// <para>All <c>set_*</c> methods allow negative item indices, i.e. <c>-1</c> to access the last item, <c>-2</c> to select the second-to-last item, and so on.</para>
/// <para><b>Incremental search:</b> Like <see cref="Godot.PopupMenu"/> and <see cref="Godot.Tree"/>, <see cref="Godot.ItemList"/> supports searching within the list while the control is focused. Press a key that matches the first letter of an item's name to select the first item starting with the given letter. After that point, there are two ways to perform incremental search: 1) Press the same key again before the timeout duration to select the next item starting with the same letter. 2) Press letter keys that match the rest of the word before the timeout duration to match to select the item in question directly. Both of these actions will be reset to the beginning of the list if the timeout duration has passed since the last keystroke was registered. You can adjust the timeout duration by changing <c>ProjectSettings.gui/timers/incremental_search_max_interval_msec</c>.</para>
/// </summary>
public partial class ItemList : Control
{
    public enum IconModeEnum : long
    {
        /// <summary>
        /// <para>Icon is drawn above the text.</para>
        /// </summary>
        Top = 0,
        /// <summary>
        /// <para>Icon is drawn to the left of the text.</para>
        /// </summary>
        Left = 1
    }

    public enum SelectModeEnum : long
    {
        /// <summary>
        /// <para>Only allow selecting a single item.</para>
        /// </summary>
        Single = 0,
        /// <summary>
        /// <para>Allows selecting multiple items by holding Ctrl or Shift.</para>
        /// </summary>
        Multi = 1,
        /// <summary>
        /// <para>Allows selecting multiple items by toggling them on and off.</para>
        /// </summary>
        Toggle = 2
    }

    public enum ScrollHintModeEnum : long
    {
        /// <summary>
        /// <para>Scroll hints will never be shown.</para>
        /// </summary>
        Disabled = 0,
        /// <summary>
        /// <para>Scroll hints will be shown at the top and bottom.</para>
        /// </summary>
        Both = 1,
        /// <summary>
        /// <para>Only the top scroll hint will be shown.</para>
        /// </summary>
        Top = 2,
        /// <summary>
        /// <para>Only the bottom scroll hint will be shown.</para>
        /// </summary>
        Bottom = 3
    }

    /// <summary>
    /// <para>Allows single or multiple item selection. See the <see cref="Godot.ItemList.SelectModeEnum"/> constants.</para>
    /// </summary>
    public ItemList.SelectModeEnum SelectMode
    {
        get
        {
            return GetSelectMode();
        }
        set
        {
            SetSelectMode(value);
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
    /// <para>If <see langword="true"/>, right mouse button click can select items.</para>
    /// </summary>
    public bool AllowRmbSelect
    {
        get
        {
            return GetAllowRmbSelect();
        }
        set
        {
            SetAllowRmbSelect(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, allows navigating the <see cref="Godot.ItemList"/> with letter keys through incremental search.</para>
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
    /// <para>Maximum lines of text allowed in each item. Space will be reserved even when there is not enough lines of text to display.</para>
    /// <para><b>Note:</b> This property takes effect only when <see cref="Godot.ItemList.IconMode"/> is <see cref="Godot.ItemList.IconModeEnum.Top"/>. To make the text wrap, <see cref="Godot.ItemList.FixedColumnWidth"/> should be greater than zero.</para>
    /// </summary>
    public int MaxTextLines
    {
        get
        {
            return GetMaxTextLines();
        }
        set
        {
            SetMaxTextLines(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the control will automatically resize the width to fit its content.</para>
    /// </summary>
    public bool AutoWidth
    {
        get
        {
            return HasAutoWidth();
        }
        set
        {
            SetAutoWidth(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the control will automatically resize the height to fit its content.</para>
    /// </summary>
    public bool AutoHeight
    {
        get
        {
            return HasAutoHeight();
        }
        set
        {
            SetAutoHeight(value);
        }
    }

    /// <summary>
    /// <para>The clipping behavior when the text exceeds an item's bounding rectangle.</para>
    /// </summary>
    public TextServer.OverrunBehavior TextOverrunBehavior
    {
        get
        {
            return GetTextOverrunBehavior();
        }
        set
        {
            SetTextOverrunBehavior(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the control will automatically move items into a new row to fit its content. See also <see cref="Godot.HFlowContainer"/> for this behavior.</para>
    /// <para>If <see langword="false"/>, the control will add a horizontal scrollbar to make all items visible.</para>
    /// </summary>
    public bool WraparoundItems
    {
        get
        {
            return HasWraparoundItems();
        }
        set
        {
            SetWraparoundItems(value);
        }
    }

    /// <summary>
    /// <para>The way which scroll hints (indicators that show that the content can still be scrolled in a certain direction) will be shown.</para>
    /// </summary>
    public ItemList.ScrollHintModeEnum ScrollHintMode
    {
        get
        {
            return GetScrollHintMode();
        }
        set
        {
            SetScrollHintMode(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the scroll hint texture will be tiled instead of stretched. See <see cref="Godot.ItemList.ScrollHintMode"/>.</para>
    /// </summary>
    public bool TileScrollHint
    {
        get
        {
            return IsScrollHintTiled();
        }
        set
        {
            SetTileScrollHint(value);
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

    /// <summary>
    /// <para>Maximum columns the list will have.</para>
    /// <para>If greater than zero, the content will be split among the specified columns.</para>
    /// <para>A value of zero means unlimited columns, i.e. all items will be put in the same row.</para>
    /// </summary>
    public int MaxColumns
    {
        get
        {
            return GetMaxColumns();
        }
        set
        {
            SetMaxColumns(value);
        }
    }

    /// <summary>
    /// <para>Whether all columns will have the same width.</para>
    /// <para>If <see langword="true"/>, the width is equal to the largest column width of all columns.</para>
    /// </summary>
    public bool SameColumnWidth
    {
        get
        {
            return IsSameColumnWidth();
        }
        set
        {
            SetSameColumnWidth(value);
        }
    }

    /// <summary>
    /// <para>The width all columns will be adjusted to.</para>
    /// <para>A value of zero disables the adjustment, each item will have a width equal to the width of its content and the columns will have an uneven width.</para>
    /// </summary>
    public int FixedColumnWidth
    {
        get
        {
            return GetFixedColumnWidth();
        }
        set
        {
            SetFixedColumnWidth(value);
        }
    }

    /// <summary>
    /// <para>The icon position, whether above or to the left of the text. See the <see cref="Godot.ItemList.IconModeEnum"/> constants.</para>
    /// </summary>
    public ItemList.IconModeEnum IconMode
    {
        get
        {
            return GetIconMode();
        }
        set
        {
            SetIconMode(value);
        }
    }

    /// <summary>
    /// <para>The scale of icon applied after <see cref="Godot.ItemList.FixedIconSize"/> and transposing takes effect.</para>
    /// </summary>
    public float IconScale
    {
        get
        {
            return GetIconScale();
        }
        set
        {
            SetIconScale(value);
        }
    }

    /// <summary>
    /// <para>The size all icons will be adjusted to.</para>
    /// <para>If either X or Y component is not greater than zero, icon size won't be affected.</para>
    /// </summary>
    public Vector2I FixedIconSize
    {
        get
        {
            return GetFixedIconSize();
        }
        set
        {
            SetFixedIconSize(value);
        }
    }

    private static readonly System.Type CachedType = typeof(ItemList);

    private static readonly StringName NativeName = "ItemList";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public ItemList() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal ItemList(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal ItemList(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddItem, 359861678ul);

    /// <summary>
    /// <para>Adds an item to the item list with specified text. Returns the index of an added item.</para>
    /// <para>Specify an <paramref name="icon"/>, or use <see langword="null"/> as the <paramref name="icon"/> for a list item with no icon.</para>
    /// <para>If <paramref name="selectable"/> is <see langword="true"/>, the list item will be selectable.</para>
    /// </summary>
    public int AddItem(string text, Texture2D icon = default, bool selectable = true)
    {
        return NativeCalls.godot_icall_3_761(MethodBind0, GodotObject.GetPtr(this), text, GodotObject.GetPtr(icon), selectable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddIconItem, 4256579627ul);

    /// <summary>
    /// <para>Adds an item to the item list with no text, only an icon. Returns the index of an added item.</para>
    /// </summary>
    public int AddIconItem(Texture2D icon, bool selectable = true)
    {
        return NativeCalls.godot_icall_2_762(MethodBind1, GodotObject.GetPtr(this), GodotObject.GetPtr(icon), selectable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetItemText, 501894301ul);

    /// <summary>
    /// <para>Sets text of the item associated with the specified index.</para>
    /// </summary>
    public void SetItemText(int idx, string text)
    {
        NativeCalls.godot_icall_2_181(MethodBind2, GodotObject.GetPtr(this), idx, text);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetItemText, 844755477ul);

    /// <summary>
    /// <para>Returns the text associated with the specified index.</para>
    /// </summary>
    public string GetItemText(int idx)
    {
        return NativeCalls.godot_icall_1_133(MethodBind3, GodotObject.GetPtr(this), idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetItemIcon, 666127730ul);

    /// <summary>
    /// <para>Sets (or replaces) the icon's <see cref="Godot.Texture2D"/> associated with the specified index.</para>
    /// </summary>
    public void SetItemIcon(int idx, Texture2D icon)
    {
        NativeCalls.godot_icall_2_70(MethodBind4, GodotObject.GetPtr(this), idx, GodotObject.GetPtr(icon));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetItemIcon, 3536238170ul);

    /// <summary>
    /// <para>Returns the icon associated with the specified index.</para>
    /// </summary>
    public Texture2D GetItemIcon(int idx)
    {
        return (Texture2D)NativeCalls.godot_icall_1_71(MethodBind5, GodotObject.GetPtr(this), idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetItemTextDirection, 1707680378ul);

    /// <summary>
    /// <para>Sets item's text base writing direction.</para>
    /// </summary>
    public void SetItemTextDirection(int idx, Control.TextDirection direction)
    {
        NativeCalls.godot_icall_2_59(MethodBind6, GodotObject.GetPtr(this), idx, (int)direction);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetItemTextDirection, 4235602388ul);

    /// <summary>
    /// <para>Returns item's text base writing direction.</para>
    /// </summary>
    public Control.TextDirection GetItemTextDirection(int idx)
    {
        return (Control.TextDirection)NativeCalls.godot_icall_1_60(MethodBind7, GodotObject.GetPtr(this), idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetItemLanguage, 501894301ul);

    /// <summary>
    /// <para>Sets the language code of the text for the item at the given index to <paramref name="language"/>. This is used for line-breaking and text shaping algorithms. If <paramref name="language"/> is empty, the current locale is used.</para>
    /// </summary>
    public void SetItemLanguage(int idx, string language)
    {
        NativeCalls.godot_icall_2_181(MethodBind8, GodotObject.GetPtr(this), idx, language);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetItemLanguage, 844755477ul);

    /// <summary>
    /// <para>Returns item's text language code.</para>
    /// </summary>
    public string GetItemLanguage(int idx)
    {
        return NativeCalls.godot_icall_1_133(MethodBind9, GodotObject.GetPtr(this), idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetItemAutoTranslateMode, 287402019ul);

    /// <summary>
    /// <para>Sets the auto translate mode of the item associated with the specified index.</para>
    /// <para>Items use <see cref="Godot.Node.AutoTranslateModeEnum.Inherit"/> by default, which uses the same auto translate mode as the <see cref="Godot.ItemList"/> itself.</para>
    /// </summary>
    public void SetItemAutoTranslateMode(int idx, Node.AutoTranslateModeEnum mode)
    {
        NativeCalls.godot_icall_2_59(MethodBind10, GodotObject.GetPtr(this), idx, (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetItemAutoTranslateMode, 906302372ul);

    /// <summary>
    /// <para>Returns item's auto translate mode.</para>
    /// </summary>
    public Node.AutoTranslateModeEnum GetItemAutoTranslateMode(int idx)
    {
        return (Node.AutoTranslateModeEnum)NativeCalls.godot_icall_1_60(MethodBind11, GodotObject.GetPtr(this), idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetItemIconTransposed, 300928843ul);

    /// <summary>
    /// <para>Sets whether the item icon will be drawn transposed.</para>
    /// </summary>
    public void SetItemIconTransposed(int idx, bool transposed)
    {
        NativeCalls.godot_icall_2_61(MethodBind12, GodotObject.GetPtr(this), idx, transposed.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsItemIconTransposed, 1116898809ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the item icon will be drawn transposed, i.e. the X and Y axes are swapped.</para>
    /// </summary>
    public bool IsItemIconTransposed(int idx)
    {
        return NativeCalls.godot_icall_1_62(MethodBind13, GodotObject.GetPtr(this), idx).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetItemIconRegion, 1356297692ul);

    /// <summary>
    /// <para>Sets the region of item's icon used. The whole icon will be used if the region has no area.</para>
    /// </summary>
    public unsafe void SetItemIconRegion(int idx, Rect2 rect)
    {
        NativeCalls.godot_icall_2_763(MethodBind14, GodotObject.GetPtr(this), idx, &rect);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetItemIconRegion, 3327874267ul);

    /// <summary>
    /// <para>Returns the region of item's icon used. The whole icon will be used if the region has no area.</para>
    /// </summary>
    public Rect2 GetItemIconRegion(int idx)
    {
        return NativeCalls.godot_icall_1_450(MethodBind15, GodotObject.GetPtr(this), idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetItemIconModulate, 2878471219ul);

    /// <summary>
    /// <para>Sets a modulating <see cref="Godot.Color"/> of the item associated with the specified index.</para>
    /// </summary>
    public unsafe void SetItemIconModulate(int idx, Color modulate)
    {
        NativeCalls.godot_icall_2_687(MethodBind16, GodotObject.GetPtr(this), idx, &modulate);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetItemIconModulate, 3457211756ul);

    /// <summary>
    /// <para>Returns a <see cref="Godot.Color"/> modulating item's icon at the specified index.</para>
    /// </summary>
    public Color GetItemIconModulate(int idx)
    {
        return NativeCalls.godot_icall_1_688(MethodBind17, GodotObject.GetPtr(this), idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetItemSelectable, 300928843ul);

    /// <summary>
    /// <para>Allows or disallows selection of the item associated with the specified index.</para>
    /// </summary>
    public void SetItemSelectable(int idx, bool selectable)
    {
        NativeCalls.godot_icall_2_61(MethodBind18, GodotObject.GetPtr(this), idx, selectable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsItemSelectable, 1116898809ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the item at the specified index is selectable.</para>
    /// </summary>
    public bool IsItemSelectable(int idx)
    {
        return NativeCalls.godot_icall_1_62(MethodBind19, GodotObject.GetPtr(this), idx).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetItemDisabled, 300928843ul);

    /// <summary>
    /// <para>Disables (or enables) the item at the specified index.</para>
    /// <para>Disabled items cannot be selected and do not trigger activation signals (when double-clicking or pressing Enter).</para>
    /// </summary>
    public void SetItemDisabled(int idx, bool disabled)
    {
        NativeCalls.godot_icall_2_61(MethodBind20, GodotObject.GetPtr(this), idx, disabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsItemDisabled, 1116898809ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the item at the specified index is disabled.</para>
    /// </summary>
    public bool IsItemDisabled(int idx)
    {
        return NativeCalls.godot_icall_1_62(MethodBind21, GodotObject.GetPtr(this), idx).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetItemMetadata, 2152698145ul);

    /// <summary>
    /// <para>Sets a value (of any type) to be stored with the item associated with the specified index.</para>
    /// </summary>
    public void SetItemMetadata(int idx, Variant metadata)
    {
        NativeCalls.godot_icall_2_701(MethodBind22, GodotObject.GetPtr(this), idx, metadata);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetItemMetadata, 4227898402ul);

    /// <summary>
    /// <para>Returns the metadata value of the specified index.</para>
    /// </summary>
    public Variant GetItemMetadata(int idx)
    {
        return NativeCalls.godot_icall_1_702(MethodBind23, GodotObject.GetPtr(this), idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetItemCustomBgColor, 2878471219ul);

    /// <summary>
    /// <para>Sets the background color of the item specified by <paramref name="idx"/> index to the specified <see cref="Godot.Color"/>.</para>
    /// </summary>
    public unsafe void SetItemCustomBgColor(int idx, Color customBgColor)
    {
        NativeCalls.godot_icall_2_687(MethodBind24, GodotObject.GetPtr(this), idx, &customBgColor);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetItemCustomBgColor, 3457211756ul);

    /// <summary>
    /// <para>Returns the custom background color of the item specified by <paramref name="idx"/> index.</para>
    /// </summary>
    public Color GetItemCustomBgColor(int idx)
    {
        return NativeCalls.godot_icall_1_688(MethodBind25, GodotObject.GetPtr(this), idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetItemCustomFgColor, 2878471219ul);

    /// <summary>
    /// <para>Sets the foreground color of the item specified by <paramref name="idx"/> index to the specified <see cref="Godot.Color"/>.</para>
    /// </summary>
    public unsafe void SetItemCustomFgColor(int idx, Color customFgColor)
    {
        NativeCalls.godot_icall_2_687(MethodBind26, GodotObject.GetPtr(this), idx, &customFgColor);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetItemCustomFgColor, 3457211756ul);

    /// <summary>
    /// <para>Returns the custom foreground color of the item specified by <paramref name="idx"/> index.</para>
    /// </summary>
    public Color GetItemCustomFgColor(int idx)
    {
        return NativeCalls.godot_icall_1_688(MethodBind27, GodotObject.GetPtr(this), idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetItemRect, 159227807ul);

    /// <summary>
    /// <para>Returns the position and size of the item with the specified index, in the coordinate system of the <see cref="Godot.ItemList"/> node. If <paramref name="expand"/> is <see langword="true"/> the last column expands to fill the rest of the row.</para>
    /// <para><b>Note:</b> The returned value is unreliable if called right after modifying the <see cref="Godot.ItemList"/>, before it redraws in the next frame.</para>
    /// </summary>
    public Rect2 GetItemRect(int idx, bool expand = true)
    {
        return NativeCalls.godot_icall_2_764(MethodBind28, GodotObject.GetPtr(this), idx, expand.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetItemTooltipEnabled, 300928843ul);

    /// <summary>
    /// <para>Sets whether the tooltip hint is enabled for specified item index.</para>
    /// </summary>
    public void SetItemTooltipEnabled(int idx, bool enable)
    {
        NativeCalls.godot_icall_2_61(MethodBind29, GodotObject.GetPtr(this), idx, enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsItemTooltipEnabled, 1116898809ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the tooltip is enabled for specified item index.</para>
    /// </summary>
    public bool IsItemTooltipEnabled(int idx)
    {
        return NativeCalls.godot_icall_1_62(MethodBind30, GodotObject.GetPtr(this), idx).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetItemTooltip, 501894301ul);

    /// <summary>
    /// <para>Sets the tooltip hint for the item associated with the specified index.</para>
    /// </summary>
    public void SetItemTooltip(int idx, string tooltip)
    {
        NativeCalls.godot_icall_2_181(MethodBind31, GodotObject.GetPtr(this), idx, tooltip);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind32 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetItemTooltip, 844755477ul);

    /// <summary>
    /// <para>Returns the tooltip hint associated with the specified index.</para>
    /// </summary>
    public string GetItemTooltip(int idx)
    {
        return NativeCalls.godot_icall_1_133(MethodBind32, GodotObject.GetPtr(this), idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind33 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Select, 972357352ul);

    /// <summary>
    /// <para>Select the item at the specified index.</para>
    /// <para><b>Note:</b> This method does not trigger the item selection signal.</para>
    /// </summary>
    public void Select(int idx, bool single = true)
    {
        NativeCalls.godot_icall_2_61(MethodBind33, GodotObject.GetPtr(this), idx, single.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind34 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Deselect, 1286410249ul);

    /// <summary>
    /// <para>Ensures the item associated with the specified index is not selected.</para>
    /// </summary>
    public void Deselect(int idx)
    {
        NativeCalls.godot_icall_1_38(MethodBind34, GodotObject.GetPtr(this), idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind35 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DeselectAll, 3218959716ul);

    /// <summary>
    /// <para>Ensures there are no items selected.</para>
    /// </summary>
    public void DeselectAll()
    {
        NativeCalls.godot_icall_0_3(MethodBind35, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind36 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsSelected, 1116898809ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the item at the specified index is currently selected.</para>
    /// </summary>
    public bool IsSelected(int idx)
    {
        return NativeCalls.godot_icall_1_62(MethodBind36, GodotObject.GetPtr(this), idx).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind37 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSelectedItems, 969006518ul);

    /// <summary>
    /// <para>Returns an array with the indexes of the selected items.</para>
    /// </summary>
    public int[] GetSelectedItems()
    {
        return NativeCalls.godot_icall_0_151(MethodBind37, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind38 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MoveItem, 3937882851ul);

    /// <summary>
    /// <para>Moves item from index <paramref name="fromIdx"/> to <paramref name="toIdx"/>.</para>
    /// </summary>
    public void MoveItem(int fromIdx, int toIdx)
    {
        NativeCalls.godot_icall_2_59(MethodBind38, GodotObject.GetPtr(this), fromIdx, toIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind39 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetItemCount, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetItemCount(int count)
    {
        NativeCalls.godot_icall_1_38(MethodBind39, GodotObject.GetPtr(this), count);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind40 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetItemCount, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetItemCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind40, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind41 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveItem, 1286410249ul);

    /// <summary>
    /// <para>Removes the item specified by <paramref name="idx"/> index from the list.</para>
    /// </summary>
    public void RemoveItem(int idx)
    {
        NativeCalls.godot_icall_1_38(MethodBind41, GodotObject.GetPtr(this), idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind42 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Clear, 3218959716ul);

    /// <summary>
    /// <para>Removes all items from the list.</para>
    /// </summary>
    public void Clear()
    {
        NativeCalls.godot_icall_0_3(MethodBind42, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind43 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SortItemsByText, 3218959716ul);

    /// <summary>
    /// <para>Sorts items in the list by their text.</para>
    /// </summary>
    public void SortItemsByText()
    {
        NativeCalls.godot_icall_0_3(MethodBind43, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind44 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFixedColumnWidth, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFixedColumnWidth(int width)
    {
        NativeCalls.godot_icall_1_38(MethodBind44, GodotObject.GetPtr(this), width);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind45 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFixedColumnWidth, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetFixedColumnWidth()
    {
        return NativeCalls.godot_icall_0_39(MethodBind45, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind46 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSameColumnWidth, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSameColumnWidth(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind46, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind47 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsSameColumnWidth, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsSameColumnWidth()
    {
        return NativeCalls.godot_icall_0_15(MethodBind47, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind48 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMaxTextLines, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMaxTextLines(int lines)
    {
        NativeCalls.godot_icall_1_38(MethodBind48, GodotObject.GetPtr(this), lines);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind49 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMaxTextLines, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetMaxTextLines()
    {
        return NativeCalls.godot_icall_0_39(MethodBind49, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind50 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMaxColumns, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMaxColumns(int amount)
    {
        NativeCalls.godot_icall_1_38(MethodBind50, GodotObject.GetPtr(this), amount);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind51 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMaxColumns, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetMaxColumns()
    {
        return NativeCalls.godot_icall_0_39(MethodBind51, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind52 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSelectMode, 928267388ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSelectMode(ItemList.SelectModeEnum mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind52, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind53 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSelectMode, 1191945842ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public ItemList.SelectModeEnum GetSelectMode()
    {
        return (ItemList.SelectModeEnum)NativeCalls.godot_icall_0_39(MethodBind53, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind54 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetIconMode, 2025053633ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetIconMode(ItemList.IconModeEnum mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind54, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind55 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetIconMode, 3353929232ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public ItemList.IconModeEnum GetIconMode()
    {
        return (ItemList.IconModeEnum)NativeCalls.godot_icall_0_39(MethodBind55, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind56 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFixedIconSize, 1130785943ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetFixedIconSize(Vector2I size)
    {
        NativeCalls.godot_icall_1_34(MethodBind56, GodotObject.GetPtr(this), &size);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind57 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFixedIconSize, 3690982128ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2I GetFixedIconSize()
    {
        return NativeCalls.godot_icall_0_35(MethodBind57, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind58 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetIconScale, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetIconScale(float scale)
    {
        NativeCalls.godot_icall_1_67(MethodBind58, GodotObject.GetPtr(this), scale);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind59 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetIconScale, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetIconScale()
    {
        return NativeCalls.godot_icall_0_68(MethodBind59, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind60 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAllowRmbSelect, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAllowRmbSelect(bool allow)
    {
        NativeCalls.godot_icall_1_14(MethodBind60, GodotObject.GetPtr(this), allow.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind61 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAllowRmbSelect, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetAllowRmbSelect()
    {
        return NativeCalls.godot_icall_0_15(MethodBind61, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind62 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAllowReselect, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAllowReselect(bool allow)
    {
        NativeCalls.godot_icall_1_14(MethodBind62, GodotObject.GetPtr(this), allow.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind63 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAllowReselect, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetAllowReselect()
    {
        return NativeCalls.godot_icall_0_15(MethodBind63, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind64 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAllowSearch, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAllowSearch(bool allow)
    {
        NativeCalls.godot_icall_1_14(MethodBind64, GodotObject.GetPtr(this), allow.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind65 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAllowSearch, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetAllowSearch()
    {
        return NativeCalls.godot_icall_0_15(MethodBind65, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind66 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAutoWidth, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAutoWidth(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind66, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind67 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasAutoWidth, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool HasAutoWidth()
    {
        return NativeCalls.godot_icall_0_15(MethodBind67, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind68 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAutoHeight, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAutoHeight(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind68, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind69 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasAutoHeight, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool HasAutoHeight()
    {
        return NativeCalls.godot_icall_0_15(MethodBind69, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind70 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsAnythingSelected, 2240911060ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if one or more items are selected.</para>
    /// </summary>
    public bool IsAnythingSelected()
    {
        return NativeCalls.godot_icall_0_15(MethodBind70, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind71 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetItemAtPosition, 2300324924ul);

    /// <summary>
    /// <para>Returns the item index at the given <paramref name="position"/>.</para>
    /// <para>When there is no item at that point, -1 will be returned if <paramref name="exact"/> is <see langword="true"/>, and the closest item index will be returned otherwise.</para>
    /// <para><b>Note:</b> The returned value is unreliable if called right after modifying the <see cref="Godot.ItemList"/>, before it redraws in the next frame.</para>
    /// </summary>
    public unsafe int GetItemAtPosition(Vector2 position, bool exact = false)
    {
        return NativeCalls.godot_icall_2_765(MethodBind71, GodotObject.GetPtr(this), &position, exact.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind72 = ClassDB_get_method_with_compatibility(NativeName, MethodName.EnsureCurrentIsVisible, 3218959716ul);

    /// <summary>
    /// <para>Ensure current selection is visible, adjusting the scroll position as necessary.</para>
    /// </summary>
    public void EnsureCurrentIsVisible()
    {
        NativeCalls.godot_icall_0_3(MethodBind72, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind73 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVScrollBar, 2630340773ul);

    /// <summary>
    /// <para>Returns the vertical scrollbar.</para>
    /// <para><b>Warning:</b> This is a required internal node, removing and freeing it may cause a crash. If you wish to hide it or any of its children, use their <see cref="Godot.CanvasItem.Visible"/> property.</para>
    /// </summary>
    public VScrollBar GetVScrollBar()
    {
        return (VScrollBar)NativeCalls.godot_icall_0_53(MethodBind73, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind74 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetHScrollBar, 4004517983ul);

    /// <summary>
    /// <para>Returns the horizontal scrollbar.</para>
    /// <para><b>Warning:</b> This is a required internal node, removing and freeing it may cause a crash. If you wish to hide it or any of its children, use their <see cref="Godot.CanvasItem.Visible"/> property.</para>
    /// </summary>
    public HScrollBar GetHScrollBar()
    {
        return (HScrollBar)NativeCalls.godot_icall_0_53(MethodBind74, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind75 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetScrollHintMode, 2917787337ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetScrollHintMode(ItemList.ScrollHintModeEnum scrollHintMode)
    {
        NativeCalls.godot_icall_1_38(MethodBind75, GodotObject.GetPtr(this), (int)scrollHintMode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind76 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetScrollHintMode, 2522227939ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public ItemList.ScrollHintModeEnum GetScrollHintMode()
    {
        return (ItemList.ScrollHintModeEnum)NativeCalls.godot_icall_0_39(MethodBind76, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind77 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTileScrollHint, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTileScrollHint(bool tileScrollHint)
    {
        NativeCalls.godot_icall_1_14(MethodBind77, GodotObject.GetPtr(this), tileScrollHint.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind78 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsScrollHintTiled, 2240911060ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsScrollHintTiled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind78, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind79 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTextOverrunBehavior, 1008890932ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTextOverrunBehavior(TextServer.OverrunBehavior overrunBehavior)
    {
        NativeCalls.godot_icall_1_38(MethodBind79, GodotObject.GetPtr(this), (int)overrunBehavior);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind80 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTextOverrunBehavior, 3779142101ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public TextServer.OverrunBehavior GetTextOverrunBehavior()
    {
        return (TextServer.OverrunBehavior)NativeCalls.godot_icall_0_39(MethodBind80, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind81 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetWraparoundItems, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetWraparoundItems(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind81, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind82 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasWraparoundItems, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool HasWraparoundItems()
    {
        return NativeCalls.godot_icall_0_15(MethodBind82, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind83 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ForceUpdateListSize, 3218959716ul);

    /// <summary>
    /// <para>Forces an update to the list size based on its items. This happens automatically whenever size of the items, or other relevant settings like <see cref="Godot.ItemList.AutoHeight"/>, change. The method can be used to trigger the update ahead of next drawing pass.</para>
    /// </summary>
    public void ForceUpdateListSize()
    {
        NativeCalls.godot_icall_0_3(MethodBind83, GodotObject.GetPtr(this));
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.ItemList.ItemSelected"/> event of a <see cref="Godot.ItemList"/> class.
    /// </summary>
    public delegate void ItemSelectedEventHandler(long index);

    private static void ItemSelectedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((ItemSelectedEventHandler)delegateObj)(VariantUtils.ConvertTo<long>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when specified item has been selected. Only applicable in single selection mode.</para>
    /// <para><see cref="Godot.ItemList.AllowReselect"/> must be enabled to reselect an item.</para>
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
    /// Represents the method that handles the <see cref="Godot.ItemList.EmptyClicked"/> event of a <see cref="Godot.ItemList"/> class.
    /// </summary>
    public delegate void EmptyClickedEventHandler(Vector2 atPosition, long mouseButtonIndex);

    private static void EmptyClickedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 2);
        ((EmptyClickedEventHandler)delegateObj)(VariantUtils.ConvertTo<Vector2>(args[0]), VariantUtils.ConvertTo<long>(args[1]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when any mouse click is issued within the rect of the list but on empty space.</para>
    /// <para><c>atPosition</c> is the click position in this control's local coordinate system.</para>
    /// </summary>
    public unsafe event EmptyClickedEventHandler EmptyClicked
    {
        add => Connect(SignalName.EmptyClicked, Callable.CreateWithUnsafeTrampoline(value, &EmptyClickedTrampoline));
        remove => Disconnect(SignalName.EmptyClicked, Callable.CreateWithUnsafeTrampoline(value, &EmptyClickedTrampoline));
    }

    protected void EmitSignalEmptyClicked(Vector2 atPosition, long mouseButtonIndex)
    {
        EmitSignal(SignalName.EmptyClicked, atPosition, mouseButtonIndex);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.ItemList.ItemClicked"/> event of a <see cref="Godot.ItemList"/> class.
    /// </summary>
    public delegate void ItemClickedEventHandler(long index, Vector2 atPosition, long mouseButtonIndex);

    private static void ItemClickedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 3);
        ((ItemClickedEventHandler)delegateObj)(VariantUtils.ConvertTo<long>(args[0]), VariantUtils.ConvertTo<Vector2>(args[1]), VariantUtils.ConvertTo<long>(args[2]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when specified list item has been clicked with any mouse button.</para>
    /// <para><c>atPosition</c> is the click position in this control's local coordinate system.</para>
    /// </summary>
    public unsafe event ItemClickedEventHandler ItemClicked
    {
        add => Connect(SignalName.ItemClicked, Callable.CreateWithUnsafeTrampoline(value, &ItemClickedTrampoline));
        remove => Disconnect(SignalName.ItemClicked, Callable.CreateWithUnsafeTrampoline(value, &ItemClickedTrampoline));
    }

    protected void EmitSignalItemClicked(long index, Vector2 atPosition, long mouseButtonIndex)
    {
        EmitSignal(SignalName.ItemClicked, index, atPosition, mouseButtonIndex);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.ItemList.MultiSelected"/> event of a <see cref="Godot.ItemList"/> class.
    /// </summary>
    public delegate void MultiSelectedEventHandler(long index, bool selected);

    private static void MultiSelectedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 2);
        ((MultiSelectedEventHandler)delegateObj)(VariantUtils.ConvertTo<long>(args[0]), VariantUtils.ConvertTo<bool>(args[1]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when a multiple selection is altered on a list allowing multiple selection.</para>
    /// </summary>
    public unsafe event MultiSelectedEventHandler MultiSelected
    {
        add => Connect(SignalName.MultiSelected, Callable.CreateWithUnsafeTrampoline(value, &MultiSelectedTrampoline));
        remove => Disconnect(SignalName.MultiSelected, Callable.CreateWithUnsafeTrampoline(value, &MultiSelectedTrampoline));
    }

    protected void EmitSignalMultiSelected(long index, bool selected)
    {
        EmitSignal(SignalName.MultiSelected, index, selected);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.ItemList.ItemActivated"/> event of a <see cref="Godot.ItemList"/> class.
    /// </summary>
    public delegate void ItemActivatedEventHandler(long index);

    private static void ItemActivatedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((ItemActivatedEventHandler)delegateObj)(VariantUtils.ConvertTo<long>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when specified list item is activated via double-clicking or by pressing Enter.</para>
    /// </summary>
    public unsafe event ItemActivatedEventHandler ItemActivated
    {
        add => Connect(SignalName.ItemActivated, Callable.CreateWithUnsafeTrampoline(value, &ItemActivatedTrampoline));
        remove => Disconnect(SignalName.ItemActivated, Callable.CreateWithUnsafeTrampoline(value, &ItemActivatedTrampoline));
    }

    protected void EmitSignalItemActivated(long index)
    {
        EmitSignal(SignalName.ItemActivated, index);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_item_selected = "ItemSelected";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_empty_clicked = "EmptyClicked";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_item_clicked = "ItemClicked";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_multi_selected = "MultiSelected";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_item_activated = "ItemActivated";

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
        if (signal == SignalName.EmptyClicked)
        {
            if (HasGodotClassSignal(SignalProxyName_empty_clicked.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.ItemClicked)
        {
            if (HasGodotClassSignal(SignalProxyName_item_clicked.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.MultiSelected)
        {
            if (HasGodotClassSignal(SignalProxyName_multi_selected.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.ItemActivated)
        {
            if (HasGodotClassSignal(SignalProxyName_item_activated.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        return base.HasGodotClassSignal(signal);
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : Control.PropertyName
    {
        /// <summary>
        /// Cached name for the 'select_mode' property.
        /// </summary>
        public static readonly StringName SelectMode = "select_mode";
        /// <summary>
        /// Cached name for the 'allow_reselect' property.
        /// </summary>
        public static readonly StringName AllowReselect = "allow_reselect";
        /// <summary>
        /// Cached name for the 'allow_rmb_select' property.
        /// </summary>
        public static readonly StringName AllowRmbSelect = "allow_rmb_select";
        /// <summary>
        /// Cached name for the 'allow_search' property.
        /// </summary>
        public static readonly StringName AllowSearch = "allow_search";
        /// <summary>
        /// Cached name for the 'max_text_lines' property.
        /// </summary>
        public static readonly StringName MaxTextLines = "max_text_lines";
        /// <summary>
        /// Cached name for the 'auto_width' property.
        /// </summary>
        public static readonly StringName AutoWidth = "auto_width";
        /// <summary>
        /// Cached name for the 'auto_height' property.
        /// </summary>
        public static readonly StringName AutoHeight = "auto_height";
        /// <summary>
        /// Cached name for the 'text_overrun_behavior' property.
        /// </summary>
        public static readonly StringName TextOverrunBehavior = "text_overrun_behavior";
        /// <summary>
        /// Cached name for the 'wraparound_items' property.
        /// </summary>
        public static readonly StringName WraparoundItems = "wraparound_items";
        /// <summary>
        /// Cached name for the 'scroll_hint_mode' property.
        /// </summary>
        public static readonly StringName ScrollHintMode = "scroll_hint_mode";
        /// <summary>
        /// Cached name for the 'tile_scroll_hint' property.
        /// </summary>
        public static readonly StringName TileScrollHint = "tile_scroll_hint";
        /// <summary>
        /// Cached name for the 'item_count' property.
        /// </summary>
        public static readonly StringName ItemCount = "item_count";
        /// <summary>
        /// Cached name for the 'max_columns' property.
        /// </summary>
        public static readonly StringName MaxColumns = "max_columns";
        /// <summary>
        /// Cached name for the 'same_column_width' property.
        /// </summary>
        public static readonly StringName SameColumnWidth = "same_column_width";
        /// <summary>
        /// Cached name for the 'fixed_column_width' property.
        /// </summary>
        public static readonly StringName FixedColumnWidth = "fixed_column_width";
        /// <summary>
        /// Cached name for the 'icon_mode' property.
        /// </summary>
        public static readonly StringName IconMode = "icon_mode";
        /// <summary>
        /// Cached name for the 'icon_scale' property.
        /// </summary>
        public static readonly StringName IconScale = "icon_scale";
        /// <summary>
        /// Cached name for the 'fixed_icon_size' property.
        /// </summary>
        public static readonly StringName FixedIconSize = "fixed_icon_size";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Control.MethodName
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
        /// Cached name for the 'get_item_text' method.
        /// </summary>
        public static readonly StringName GetItemText = "get_item_text";
        /// <summary>
        /// Cached name for the 'set_item_icon' method.
        /// </summary>
        public static readonly StringName SetItemIcon = "set_item_icon";
        /// <summary>
        /// Cached name for the 'get_item_icon' method.
        /// </summary>
        public static readonly StringName GetItemIcon = "get_item_icon";
        /// <summary>
        /// Cached name for the 'set_item_text_direction' method.
        /// </summary>
        public static readonly StringName SetItemTextDirection = "set_item_text_direction";
        /// <summary>
        /// Cached name for the 'get_item_text_direction' method.
        /// </summary>
        public static readonly StringName GetItemTextDirection = "get_item_text_direction";
        /// <summary>
        /// Cached name for the 'set_item_language' method.
        /// </summary>
        public static readonly StringName SetItemLanguage = "set_item_language";
        /// <summary>
        /// Cached name for the 'get_item_language' method.
        /// </summary>
        public static readonly StringName GetItemLanguage = "get_item_language";
        /// <summary>
        /// Cached name for the 'set_item_auto_translate_mode' method.
        /// </summary>
        public static readonly StringName SetItemAutoTranslateMode = "set_item_auto_translate_mode";
        /// <summary>
        /// Cached name for the 'get_item_auto_translate_mode' method.
        /// </summary>
        public static readonly StringName GetItemAutoTranslateMode = "get_item_auto_translate_mode";
        /// <summary>
        /// Cached name for the 'set_item_icon_transposed' method.
        /// </summary>
        public static readonly StringName SetItemIconTransposed = "set_item_icon_transposed";
        /// <summary>
        /// Cached name for the 'is_item_icon_transposed' method.
        /// </summary>
        public static readonly StringName IsItemIconTransposed = "is_item_icon_transposed";
        /// <summary>
        /// Cached name for the 'set_item_icon_region' method.
        /// </summary>
        public static readonly StringName SetItemIconRegion = "set_item_icon_region";
        /// <summary>
        /// Cached name for the 'get_item_icon_region' method.
        /// </summary>
        public static readonly StringName GetItemIconRegion = "get_item_icon_region";
        /// <summary>
        /// Cached name for the 'set_item_icon_modulate' method.
        /// </summary>
        public static readonly StringName SetItemIconModulate = "set_item_icon_modulate";
        /// <summary>
        /// Cached name for the 'get_item_icon_modulate' method.
        /// </summary>
        public static readonly StringName GetItemIconModulate = "get_item_icon_modulate";
        /// <summary>
        /// Cached name for the 'set_item_selectable' method.
        /// </summary>
        public static readonly StringName SetItemSelectable = "set_item_selectable";
        /// <summary>
        /// Cached name for the 'is_item_selectable' method.
        /// </summary>
        public static readonly StringName IsItemSelectable = "is_item_selectable";
        /// <summary>
        /// Cached name for the 'set_item_disabled' method.
        /// </summary>
        public static readonly StringName SetItemDisabled = "set_item_disabled";
        /// <summary>
        /// Cached name for the 'is_item_disabled' method.
        /// </summary>
        public static readonly StringName IsItemDisabled = "is_item_disabled";
        /// <summary>
        /// Cached name for the 'set_item_metadata' method.
        /// </summary>
        public static readonly StringName SetItemMetadata = "set_item_metadata";
        /// <summary>
        /// Cached name for the 'get_item_metadata' method.
        /// </summary>
        public static readonly StringName GetItemMetadata = "get_item_metadata";
        /// <summary>
        /// Cached name for the 'set_item_custom_bg_color' method.
        /// </summary>
        public static readonly StringName SetItemCustomBgColor = "set_item_custom_bg_color";
        /// <summary>
        /// Cached name for the 'get_item_custom_bg_color' method.
        /// </summary>
        public static readonly StringName GetItemCustomBgColor = "get_item_custom_bg_color";
        /// <summary>
        /// Cached name for the 'set_item_custom_fg_color' method.
        /// </summary>
        public static readonly StringName SetItemCustomFgColor = "set_item_custom_fg_color";
        /// <summary>
        /// Cached name for the 'get_item_custom_fg_color' method.
        /// </summary>
        public static readonly StringName GetItemCustomFgColor = "get_item_custom_fg_color";
        /// <summary>
        /// Cached name for the 'get_item_rect' method.
        /// </summary>
        public static readonly StringName GetItemRect = "get_item_rect";
        /// <summary>
        /// Cached name for the 'set_item_tooltip_enabled' method.
        /// </summary>
        public static readonly StringName SetItemTooltipEnabled = "set_item_tooltip_enabled";
        /// <summary>
        /// Cached name for the 'is_item_tooltip_enabled' method.
        /// </summary>
        public static readonly StringName IsItemTooltipEnabled = "is_item_tooltip_enabled";
        /// <summary>
        /// Cached name for the 'set_item_tooltip' method.
        /// </summary>
        public static readonly StringName SetItemTooltip = "set_item_tooltip";
        /// <summary>
        /// Cached name for the 'get_item_tooltip' method.
        /// </summary>
        public static readonly StringName GetItemTooltip = "get_item_tooltip";
        /// <summary>
        /// Cached name for the 'select' method.
        /// </summary>
        public static readonly StringName Select = "select";
        /// <summary>
        /// Cached name for the 'deselect' method.
        /// </summary>
        public static readonly StringName Deselect = "deselect";
        /// <summary>
        /// Cached name for the 'deselect_all' method.
        /// </summary>
        public static readonly StringName DeselectAll = "deselect_all";
        /// <summary>
        /// Cached name for the 'is_selected' method.
        /// </summary>
        public static readonly StringName IsSelected = "is_selected";
        /// <summary>
        /// Cached name for the 'get_selected_items' method.
        /// </summary>
        public static readonly StringName GetSelectedItems = "get_selected_items";
        /// <summary>
        /// Cached name for the 'move_item' method.
        /// </summary>
        public static readonly StringName MoveItem = "move_item";
        /// <summary>
        /// Cached name for the 'set_item_count' method.
        /// </summary>
        public static readonly StringName SetItemCount = "set_item_count";
        /// <summary>
        /// Cached name for the 'get_item_count' method.
        /// </summary>
        public static readonly StringName GetItemCount = "get_item_count";
        /// <summary>
        /// Cached name for the 'remove_item' method.
        /// </summary>
        public static readonly StringName RemoveItem = "remove_item";
        /// <summary>
        /// Cached name for the 'clear' method.
        /// </summary>
        public static readonly StringName Clear = "clear";
        /// <summary>
        /// Cached name for the 'sort_items_by_text' method.
        /// </summary>
        public static readonly StringName SortItemsByText = "sort_items_by_text";
        /// <summary>
        /// Cached name for the 'set_fixed_column_width' method.
        /// </summary>
        public static readonly StringName SetFixedColumnWidth = "set_fixed_column_width";
        /// <summary>
        /// Cached name for the 'get_fixed_column_width' method.
        /// </summary>
        public static readonly StringName GetFixedColumnWidth = "get_fixed_column_width";
        /// <summary>
        /// Cached name for the 'set_same_column_width' method.
        /// </summary>
        public static readonly StringName SetSameColumnWidth = "set_same_column_width";
        /// <summary>
        /// Cached name for the 'is_same_column_width' method.
        /// </summary>
        public static readonly StringName IsSameColumnWidth = "is_same_column_width";
        /// <summary>
        /// Cached name for the 'set_max_text_lines' method.
        /// </summary>
        public static readonly StringName SetMaxTextLines = "set_max_text_lines";
        /// <summary>
        /// Cached name for the 'get_max_text_lines' method.
        /// </summary>
        public static readonly StringName GetMaxTextLines = "get_max_text_lines";
        /// <summary>
        /// Cached name for the 'set_max_columns' method.
        /// </summary>
        public static readonly StringName SetMaxColumns = "set_max_columns";
        /// <summary>
        /// Cached name for the 'get_max_columns' method.
        /// </summary>
        public static readonly StringName GetMaxColumns = "get_max_columns";
        /// <summary>
        /// Cached name for the 'set_select_mode' method.
        /// </summary>
        public static readonly StringName SetSelectMode = "set_select_mode";
        /// <summary>
        /// Cached name for the 'get_select_mode' method.
        /// </summary>
        public static readonly StringName GetSelectMode = "get_select_mode";
        /// <summary>
        /// Cached name for the 'set_icon_mode' method.
        /// </summary>
        public static readonly StringName SetIconMode = "set_icon_mode";
        /// <summary>
        /// Cached name for the 'get_icon_mode' method.
        /// </summary>
        public static readonly StringName GetIconMode = "get_icon_mode";
        /// <summary>
        /// Cached name for the 'set_fixed_icon_size' method.
        /// </summary>
        public static readonly StringName SetFixedIconSize = "set_fixed_icon_size";
        /// <summary>
        /// Cached name for the 'get_fixed_icon_size' method.
        /// </summary>
        public static readonly StringName GetFixedIconSize = "get_fixed_icon_size";
        /// <summary>
        /// Cached name for the 'set_icon_scale' method.
        /// </summary>
        public static readonly StringName SetIconScale = "set_icon_scale";
        /// <summary>
        /// Cached name for the 'get_icon_scale' method.
        /// </summary>
        public static readonly StringName GetIconScale = "get_icon_scale";
        /// <summary>
        /// Cached name for the 'set_allow_rmb_select' method.
        /// </summary>
        public static readonly StringName SetAllowRmbSelect = "set_allow_rmb_select";
        /// <summary>
        /// Cached name for the 'get_allow_rmb_select' method.
        /// </summary>
        public static readonly StringName GetAllowRmbSelect = "get_allow_rmb_select";
        /// <summary>
        /// Cached name for the 'set_allow_reselect' method.
        /// </summary>
        public static readonly StringName SetAllowReselect = "set_allow_reselect";
        /// <summary>
        /// Cached name for the 'get_allow_reselect' method.
        /// </summary>
        public static readonly StringName GetAllowReselect = "get_allow_reselect";
        /// <summary>
        /// Cached name for the 'set_allow_search' method.
        /// </summary>
        public static readonly StringName SetAllowSearch = "set_allow_search";
        /// <summary>
        /// Cached name for the 'get_allow_search' method.
        /// </summary>
        public static readonly StringName GetAllowSearch = "get_allow_search";
        /// <summary>
        /// Cached name for the 'set_auto_width' method.
        /// </summary>
        public static readonly StringName SetAutoWidth = "set_auto_width";
        /// <summary>
        /// Cached name for the 'has_auto_width' method.
        /// </summary>
        public static readonly StringName HasAutoWidth = "has_auto_width";
        /// <summary>
        /// Cached name for the 'set_auto_height' method.
        /// </summary>
        public static readonly StringName SetAutoHeight = "set_auto_height";
        /// <summary>
        /// Cached name for the 'has_auto_height' method.
        /// </summary>
        public static readonly StringName HasAutoHeight = "has_auto_height";
        /// <summary>
        /// Cached name for the 'is_anything_selected' method.
        /// </summary>
        public static readonly StringName IsAnythingSelected = "is_anything_selected";
        /// <summary>
        /// Cached name for the 'get_item_at_position' method.
        /// </summary>
        public static readonly StringName GetItemAtPosition = "get_item_at_position";
        /// <summary>
        /// Cached name for the 'ensure_current_is_visible' method.
        /// </summary>
        public static readonly StringName EnsureCurrentIsVisible = "ensure_current_is_visible";
        /// <summary>
        /// Cached name for the 'get_v_scroll_bar' method.
        /// </summary>
        public static readonly StringName GetVScrollBar = "get_v_scroll_bar";
        /// <summary>
        /// Cached name for the 'get_h_scroll_bar' method.
        /// </summary>
        public static readonly StringName GetHScrollBar = "get_h_scroll_bar";
        /// <summary>
        /// Cached name for the 'set_scroll_hint_mode' method.
        /// </summary>
        public static readonly StringName SetScrollHintMode = "set_scroll_hint_mode";
        /// <summary>
        /// Cached name for the 'get_scroll_hint_mode' method.
        /// </summary>
        public static readonly StringName GetScrollHintMode = "get_scroll_hint_mode";
        /// <summary>
        /// Cached name for the 'set_tile_scroll_hint' method.
        /// </summary>
        public static readonly StringName SetTileScrollHint = "set_tile_scroll_hint";
        /// <summary>
        /// Cached name for the 'is_scroll_hint_tiled' method.
        /// </summary>
        public static readonly StringName IsScrollHintTiled = "is_scroll_hint_tiled";
        /// <summary>
        /// Cached name for the 'set_text_overrun_behavior' method.
        /// </summary>
        public static readonly StringName SetTextOverrunBehavior = "set_text_overrun_behavior";
        /// <summary>
        /// Cached name for the 'get_text_overrun_behavior' method.
        /// </summary>
        public static readonly StringName GetTextOverrunBehavior = "get_text_overrun_behavior";
        /// <summary>
        /// Cached name for the 'set_wraparound_items' method.
        /// </summary>
        public static readonly StringName SetWraparoundItems = "set_wraparound_items";
        /// <summary>
        /// Cached name for the 'has_wraparound_items' method.
        /// </summary>
        public static readonly StringName HasWraparoundItems = "has_wraparound_items";
        /// <summary>
        /// Cached name for the 'force_update_list_size' method.
        /// </summary>
        public static readonly StringName ForceUpdateListSize = "force_update_list_size";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Control.SignalName
    {
        /// <summary>
        /// Cached name for the 'item_selected' signal.
        /// </summary>
        public static readonly StringName ItemSelected = "item_selected";
        /// <summary>
        /// Cached name for the 'empty_clicked' signal.
        /// </summary>
        public static readonly StringName EmptyClicked = "empty_clicked";
        /// <summary>
        /// Cached name for the 'item_clicked' signal.
        /// </summary>
        public static readonly StringName ItemClicked = "item_clicked";
        /// <summary>
        /// Cached name for the 'multi_selected' signal.
        /// </summary>
        public static readonly StringName MultiSelected = "multi_selected";
        /// <summary>
        /// Cached name for the 'item_activated' signal.
        /// </summary>
        public static readonly StringName ItemActivated = "item_activated";
    }
}
