namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A control used to show a set of internal <see cref="Godot.TreeItem"/>s in a hierarchical structure. The tree items can be selected, expanded and collapsed. The tree can have multiple columns with custom controls like <see cref="Godot.LineEdit"/>s, buttons and popups. It can be useful for structured displays and interactions.</para>
/// <para>Trees are built via code, using <see cref="Godot.TreeItem"/> objects to create the structure. They have a single root, but multiple roots can be simulated with <see cref="Godot.Tree.HideRoot"/>:</para>
/// <para><code>
/// public override void _Ready()
/// {
/// 	var tree = new Tree();
/// 	TreeItem root = tree.CreateItem();
/// 	tree.HideRoot = true;
/// 	TreeItem child1 = tree.CreateItem(root);
/// 	TreeItem child2 = tree.CreateItem(root);
/// 	TreeItem subchild1 = tree.CreateItem(child1);
/// 	subchild1.SetText(0, "Subchild1");
/// }
/// </code></para>
/// <para>To iterate over all the <see cref="Godot.TreeItem"/> objects in a <see cref="Godot.Tree"/> object, use <see cref="Godot.TreeItem.GetNext()"/> and <see cref="Godot.TreeItem.GetFirstChild()"/> after getting the root through <see cref="Godot.Tree.GetRoot()"/>. You can use <see cref="Godot.GodotObject.Free()"/> on a <see cref="Godot.TreeItem"/> to remove it from the <see cref="Godot.Tree"/>.</para>
/// <para><b>Incremental search:</b> Like <see cref="Godot.ItemList"/> and <see cref="Godot.PopupMenu"/>, <see cref="Godot.Tree"/> supports searching within the list while the control is focused. Press a key that matches the first letter of an item's name to select the first item starting with the given letter. After that point, there are two ways to perform incremental search: 1) Press the same key again before the timeout duration to select the next item starting with the same letter. 2) Press letter keys that match the rest of the word before the timeout duration to match to select the item in question directly. Both of these actions will be reset to the beginning of the list if the timeout duration has passed since the last keystroke was registered. You can adjust the timeout duration by changing <c>ProjectSettings.gui/timers/incremental_search_max_interval_msec</c>.</para>
/// </summary>
public partial class Tree : Control
{
    public enum SelectModeEnum : long
    {
        /// <summary>
        /// <para>Allows selection of a single cell at a time. From the perspective of items, only a single item is allowed to be selected. And there is only one column selected in the selected item.</para>
        /// <para>The focus cursor is always hidden in this mode, but it is positioned at the current selection, making the currently selected item the currently focused item.</para>
        /// </summary>
        Single = 0,
        /// <summary>
        /// <para>Allows selection of a single row at a time. From the perspective of items, only a single items is allowed to be selected. And all the columns are selected in the selected item.</para>
        /// <para>The focus cursor is always hidden in this mode, but it is positioned at the first column of the current selection, making the currently selected item the currently focused item.</para>
        /// </summary>
        Row = 1,
        /// <summary>
        /// <para>Allows selection of multiple cells at the same time. From the perspective of items, multiple items are allowed to be selected. And there can be multiple columns selected in each selected item.</para>
        /// <para>The focus cursor is visible in this mode, the item or column under the cursor is not necessarily selected.</para>
        /// </summary>
        Multi = 2
    }

    public enum DropModeFlagsEnum : long
    {
        /// <summary>
        /// <para>Disables all drop sections, but still allows to detect the "on item" drop section by <see cref="Godot.Tree.GetDropSectionAtPosition(Vector2)"/>.</para>
        /// <para><b>Note:</b> This is the default flag, it has no effect when combined with other flags.</para>
        /// </summary>
        Disabled = 0,
        /// <summary>
        /// <para>Enables the "on item" drop section. This drop section covers the entire item.</para>
        /// <para>When combined with <see cref="Godot.Tree.DropModeFlagsEnum.Inbetween"/>, this drop section halves the height and stays centered vertically.</para>
        /// </summary>
        OnItem = 1,
        /// <summary>
        /// <para>Enables "above item" and "below item" drop sections. The "above item" drop section covers the top half of the item, and the "below item" drop section covers the bottom half.</para>
        /// <para>When combined with <see cref="Godot.Tree.DropModeFlagsEnum.OnItem"/>, these drop sections halves the height and stays on top / bottom accordingly.</para>
        /// </summary>
        Inbetween = 2
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
    /// <para>The number of columns.</para>
    /// </summary>
    public int Columns
    {
        get
        {
            return GetColumns();
        }
        set
        {
            SetColumns(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, column titles are visible.</para>
    /// </summary>
    public bool ColumnTitlesVisible
    {
        get
        {
            return AreColumnTitlesVisible();
        }
        set
        {
            SetColumnTitlesVisible(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the currently selected cell may be selected again.</para>
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
    /// <para>If <see langword="true"/>, a right mouse button click can select items.</para>
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
    /// <para>If <see langword="true"/>, allows navigating the <see cref="Godot.Tree"/> with letter keys through incremental search.</para>
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
    /// <para>If <see langword="true"/>, the folding arrow is hidden.</para>
    /// </summary>
    public bool HideFolding
    {
        get
        {
            return IsFoldingHidden();
        }
        set
        {
            SetHideFolding(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, recursive folding is enabled for this <see cref="Godot.Tree"/>. Holding down Shift while clicking the fold arrow or using <c>ui_right</c>/<c>ui_left</c> shortcuts collapses or uncollapses the <see cref="Godot.TreeItem"/> and all its descendants.</para>
    /// </summary>
    public bool EnableRecursiveFolding
    {
        get
        {
            return IsRecursiveFoldingEnabled();
        }
        set
        {
            SetEnableRecursiveFolding(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, tree items will unfold when hovered over during a drag-and-drop. The delay for when this happens is dictated by <c>dragging_unfold_wait_msec</c>.</para>
    /// </summary>
    public bool EnableDragUnfolding
    {
        get
        {
            return IsDragUnfoldingEnabled();
        }
        set
        {
            SetEnableDragUnfolding(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the tree's root is hidden.</para>
    /// </summary>
    public bool HideRoot
    {
        get
        {
            return IsRootHidden();
        }
        set
        {
            SetHideRoot(value);
        }
    }

    /// <summary>
    /// <para>The drop mode as an OR combination of flags. See <see cref="Godot.Tree.DropModeFlagsEnum"/> constants. Once dropping is done, reverts to <see cref="Godot.Tree.DropModeFlagsEnum.Disabled"/>. Setting this during <see cref="Godot.Control._CanDropData(Vector2, Variant)"/> is recommended.</para>
    /// <para>This controls the drop sections, i.e. the decision and drawing of possible drop locations based on the mouse position.</para>
    /// </summary>
    public int DropModeFlags
    {
        get
        {
            return GetDropModeFlags();
        }
        set
        {
            SetDropModeFlags(value);
        }
    }

    /// <summary>
    /// <para>Allows single or multiple selection. See the <see cref="Godot.Tree.SelectModeEnum"/> constants.</para>
    /// </summary>
    public Tree.SelectModeEnum SelectMode
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
    /// <para>If <see langword="true"/>, tree items with no tooltip assigned display their text as their tooltip. See also <see cref="Godot.TreeItem.GetTooltipText(int)"/> and <see cref="Godot.TreeItem.GetButtonTooltipText(int, int)"/>.</para>
    /// </summary>
    public bool AutoTooltip
    {
        get
        {
            return IsAutoTooltipEnabled();
        }
        set
        {
            SetAutoTooltip(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, enables horizontal scrolling.</para>
    /// </summary>
    public bool ScrollHorizontalEnabled
    {
        get
        {
            return IsHScrollEnabled();
        }
        set
        {
            SetHScrollEnabled(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, enables vertical scrolling.</para>
    /// </summary>
    public bool ScrollVerticalEnabled
    {
        get
        {
            return IsVScrollEnabled();
        }
        set
        {
            SetVScrollEnabled(value);
        }
    }

    /// <summary>
    /// <para>The way which scroll hints (indicators that show that the content can still be scrolled in a certain direction) will be shown.</para>
    /// </summary>
    public Tree.ScrollHintModeEnum ScrollHintMode
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
    /// <para>If <see langword="true"/>, the scroll hint texture will be tiled instead of stretched. See <see cref="Godot.Tree.ScrollHintMode"/>.</para>
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

    private static readonly System.Type CachedType = typeof(Tree);

    private static readonly StringName NativeName = "Tree";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public Tree() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal Tree(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal Tree(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Clear, 3218959716ul);

    /// <summary>
    /// <para>Clears the tree. This removes all items.</para>
    /// </summary>
    public void Clear()
    {
        NativeCalls.godot_icall_0_3(MethodBind0, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CreateItem, 528467046ul);

    /// <summary>
    /// <para>Creates an item in the tree and adds it as a child of <paramref name="parent"/>, which can be either a valid <see cref="Godot.TreeItem"/> or <see langword="null"/>.</para>
    /// <para>If <paramref name="parent"/> is <see langword="null"/>, the root item will be the parent, or the new item will be the root itself if the tree is empty.</para>
    /// <para>The new item will be the <paramref name="index"/>-th child of parent, or it will be the last child if there are not enough siblings.</para>
    /// </summary>
    public TreeItem CreateItem(TreeItem parent = default, int index = -1)
    {
        return (TreeItem)NativeCalls.godot_icall_2_1471(MethodBind1, GodotObject.GetPtr(this), GodotObject.GetPtr(parent), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRoot, 1514277247ul);

    /// <summary>
    /// <para>Returns the tree's root item, or <see langword="null"/> if the tree is empty.</para>
    /// </summary>
    public TreeItem GetRoot()
    {
        return (TreeItem)NativeCalls.godot_icall_0_53(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetColumnCustomMinimumWidth, 3937882851ul);

    /// <summary>
    /// <para>Overrides the calculated minimum width of a column. It can be set to <c>0</c> to restore the default behavior. Columns that have the "Expand" flag will use their "min_width" in a similar fashion to <see cref="Godot.Control.SizeFlagsStretchRatio"/>.</para>
    /// </summary>
    public void SetColumnCustomMinimumWidth(int column, int minWidth)
    {
        NativeCalls.godot_icall_2_59(MethodBind3, GodotObject.GetPtr(this), column, minWidth);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetColumnExpand, 300928843ul);

    /// <summary>
    /// <para>If <see langword="true"/>, the column will have the "Expand" flag of <see cref="Godot.Control"/>. Columns that have the "Expand" flag will use their expand ratio in a similar fashion to <see cref="Godot.Control.SizeFlagsStretchRatio"/> (see <see cref="Godot.Tree.SetColumnExpandRatio(int, int)"/>).</para>
    /// </summary>
    public void SetColumnExpand(int column, bool expand)
    {
        NativeCalls.godot_icall_2_61(MethodBind4, GodotObject.GetPtr(this), column, expand.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetColumnExpandRatio, 3937882851ul);

    /// <summary>
    /// <para>Sets the relative expand ratio for a column. See <see cref="Godot.Tree.SetColumnExpand(int, bool)"/>.</para>
    /// </summary>
    public void SetColumnExpandRatio(int column, int ratio)
    {
        NativeCalls.godot_icall_2_59(MethodBind5, GodotObject.GetPtr(this), column, ratio);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetColumnClipContent, 300928843ul);

    /// <summary>
    /// <para>Allows to enable clipping for column's content, making the content size ignored.</para>
    /// </summary>
    public void SetColumnClipContent(int column, bool enable)
    {
        NativeCalls.godot_icall_2_61(MethodBind6, GodotObject.GetPtr(this), column, enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsColumnExpanding, 1116898809ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the column has enabled expanding (see <see cref="Godot.Tree.SetColumnExpand(int, bool)"/>).</para>
    /// </summary>
    public bool IsColumnExpanding(int column)
    {
        return NativeCalls.godot_icall_1_62(MethodBind7, GodotObject.GetPtr(this), column).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsColumnClippingContent, 1116898809ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the column has enabled clipping (see <see cref="Godot.Tree.SetColumnClipContent(int, bool)"/>).</para>
    /// </summary>
    public bool IsColumnClippingContent(int column)
    {
        return NativeCalls.godot_icall_1_62(MethodBind8, GodotObject.GetPtr(this), column).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetColumnExpandRatio, 923996154ul);

    /// <summary>
    /// <para>Returns the expand ratio assigned to the column.</para>
    /// </summary>
    public int GetColumnExpandRatio(int column)
    {
        return NativeCalls.godot_icall_1_60(MethodBind9, GodotObject.GetPtr(this), column);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetColumnWidth, 923996154ul);

    /// <summary>
    /// <para>Returns the column's width in pixels.</para>
    /// </summary>
    public int GetColumnWidth(int column)
    {
        return NativeCalls.godot_icall_1_60(MethodBind10, GodotObject.GetPtr(this), column);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetHideRoot, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetHideRoot(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind11, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsRootHidden, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsRootHidden()
    {
        return NativeCalls.godot_icall_0_15(MethodBind12, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNextSelected, 873446299ul);

    /// <summary>
    /// <para>Returns the next selected <see cref="Godot.TreeItem"/> after the given one, or <see langword="null"/> if the end is reached.</para>
    /// <para>If <paramref name="from"/> is <see langword="null"/>, this returns the first selected item.</para>
    /// </summary>
    public TreeItem GetNextSelected(TreeItem from)
    {
        return (TreeItem)NativeCalls.godot_icall_1_1472(MethodBind13, GodotObject.GetPtr(this), GodotObject.GetPtr(from));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSelected, 1514277247ul);

    /// <summary>
    /// <para>Returns the currently focused item, or <see langword="null"/> if no item is focused.</para>
    /// <para>In <see cref="Godot.Tree.SelectModeEnum.Row"/> and <see cref="Godot.Tree.SelectModeEnum.Single"/> modes, the focused item is same as the selected item. In <see cref="Godot.Tree.SelectModeEnum.Multi"/> mode, the focused item is the item under the focus cursor, not necessarily selected.</para>
    /// <para>To get the currently selected item(s), use <see cref="Godot.Tree.GetNextSelected(TreeItem)"/>.</para>
    /// </summary>
    public TreeItem GetSelected()
    {
        return (TreeItem)NativeCalls.godot_icall_0_53(MethodBind14, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSelected, 2662547442ul);

    /// <summary>
    /// <para>Selects the specified <see cref="Godot.TreeItem"/> and column.</para>
    /// </summary>
    public void SetSelected(TreeItem item, int column)
    {
        NativeCalls.godot_icall_2_740(MethodBind15, GodotObject.GetPtr(this), GodotObject.GetPtr(item), column);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSelectedColumn, 3905245786ul);

    /// <summary>
    /// <para>Returns the currently focused column, or -1 if no column is focused.</para>
    /// <para>In <see cref="Godot.Tree.SelectModeEnum.Single"/> mode, the focused column is the selected column. In <see cref="Godot.Tree.SelectModeEnum.Row"/> mode, the focused column is always 0 if any item is selected. In <see cref="Godot.Tree.SelectModeEnum.Multi"/> mode, the focused column is the column under the focus cursor, and there are not necessarily any column selected.</para>
    /// <para>To tell whether a column of an item is selected, use <see cref="Godot.TreeItem.IsSelected(int)"/>.</para>
    /// </summary>
    public int GetSelectedColumn()
    {
        return NativeCalls.godot_icall_0_39(MethodBind16, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPressedButton, 3905245786ul);

    /// <summary>
    /// <para>Returns the last pressed button's index.</para>
    /// </summary>
    public int GetPressedButton()
    {
        return NativeCalls.godot_icall_0_39(MethodBind17, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSelectMode, 3223887270ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSelectMode(Tree.SelectModeEnum mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind18, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSelectMode, 100748571ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Tree.SelectModeEnum GetSelectMode()
    {
        return (Tree.SelectModeEnum)NativeCalls.godot_icall_0_39(MethodBind19, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DeselectAll, 3218959716ul);

    /// <summary>
    /// <para>Deselects all tree items (rows and columns). In <see cref="Godot.Tree.SelectModeEnum.Multi"/> mode also removes selection cursor.</para>
    /// </summary>
    public void DeselectAll()
    {
        NativeCalls.godot_icall_0_3(MethodBind20, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetColumns, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetColumns(int amount)
    {
        NativeCalls.godot_icall_1_38(MethodBind21, GodotObject.GetPtr(this), amount);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetColumns, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetColumns()
    {
        return NativeCalls.godot_icall_0_39(MethodBind22, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEdited, 1514277247ul);

    /// <summary>
    /// <para>Returns the currently edited item. Can be used with <see cref="Godot.Tree.ItemEdited"/> to get the item that was modified.</para>
    /// <para><code>
    /// public override void _Ready()
    /// {
    /// 	GetNode&lt;Tree&gt;("Tree").ItemEdited += OnTreeItemEdited;
    /// }
    /// 
    /// public void OnTreeItemEdited()
    /// {
    /// 	GD.Print(GetNode&lt;Tree&gt;("Tree").GetEdited()); // This item just got edited (e.g. checked).
    /// }
    /// </code></para>
    /// </summary>
    public TreeItem GetEdited()
    {
        return (TreeItem)NativeCalls.godot_icall_0_53(MethodBind23, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEditedColumn, 3905245786ul);

    /// <summary>
    /// <para>Returns the column for the currently edited item.</para>
    /// </summary>
    public int GetEditedColumn()
    {
        return NativeCalls.godot_icall_0_39(MethodBind24, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.EditSelected, 2595650253ul);

    /// <summary>
    /// <para>Edits the selected tree item as if it was clicked.</para>
    /// <para>Either the item must be set editable with <see cref="Godot.TreeItem.SetEditable(int, bool)"/> or <paramref name="forceEdit"/> must be <see langword="true"/>.</para>
    /// <para>Returns <see langword="true"/> if the item could be edited. Fails if no item is selected.</para>
    /// </summary>
    public bool EditSelected(bool forceEdit = false)
    {
        return NativeCalls.godot_icall_1_334(MethodBind25, GodotObject.GetPtr(this), forceEdit.ToGodotBool()).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCustomPopupRect, 1639390495ul);

    /// <summary>
    /// <para>Returns the rectangle for custom popups. Helper to create custom cell controls that display a popup. See <see cref="Godot.TreeItem.SetCellMode(int, TreeItem.TreeCellMode)"/>.</para>
    /// </summary>
    public Rect2 GetCustomPopupRect()
    {
        return NativeCalls.godot_icall_0_189(MethodBind26, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetItemAreaRect, 47968679ul);

    /// <summary>
    /// <para>Returns the rectangle area for the specified <see cref="Godot.TreeItem"/>. If <paramref name="column"/> is specified, only get the position and size of that column, otherwise get the rectangle containing all columns. If a button index is specified, the rectangle of that button will be returned.</para>
    /// </summary>
    public Rect2 GetItemAreaRect(TreeItem item, int column = -1, int buttonIndex = -1)
    {
        return NativeCalls.godot_icall_3_1473(MethodBind27, GodotObject.GetPtr(this), GodotObject.GetPtr(item), column, buttonIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetItemAtPosition, 4193340126ul);

    /// <summary>
    /// <para>Returns the tree item at the specified position (relative to the tree origin position).</para>
    /// </summary>
    public unsafe TreeItem GetItemAtPosition(Vector2 position)
    {
        return (TreeItem)NativeCalls.godot_icall_1_1474(MethodBind28, GodotObject.GetPtr(this), &position);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetColumnAtPosition, 3820158470ul);

    /// <summary>
    /// <para>Returns the column index at <paramref name="position"/>, or -1 if no item is there.</para>
    /// </summary>
    public unsafe int GetColumnAtPosition(Vector2 position)
    {
        return NativeCalls.godot_icall_1_340(MethodBind29, GodotObject.GetPtr(this), &position);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDropSectionAtPosition, 3820158470ul);

    /// <summary>
    /// <para>Returns the drop section at <paramref name="position"/>, or -100 if no item is there.</para>
    /// <para>Values -1, 0, or 1 will be returned for the "above item", "on item", and "below item" drop sections, respectively. See <see cref="Godot.Tree.DropModeFlagsEnum"/> for a description of each drop section.</para>
    /// <para>To get the item which the returned drop section is relative to, use <see cref="Godot.Tree.GetItemAtPosition(Vector2)"/>.</para>
    /// </summary>
    public unsafe int GetDropSectionAtPosition(Vector2 position)
    {
        return NativeCalls.godot_icall_1_340(MethodBind30, GodotObject.GetPtr(this), &position);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetButtonIdAtPosition, 3820158470ul);

    /// <summary>
    /// <para>Returns the button ID at <paramref name="position"/>, or -1 if no button is there.</para>
    /// </summary>
    public unsafe int GetButtonIdAtPosition(Vector2 position)
    {
        return NativeCalls.godot_icall_1_340(MethodBind31, GodotObject.GetPtr(this), &position);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind32 = ClassDB_get_method_with_compatibility(NativeName, MethodName.EnsureCursorIsVisible, 3218959716ul);

    /// <summary>
    /// <para>Makes the currently focused cell visible.</para>
    /// <para>This will scroll the tree if necessary. In <see cref="Godot.Tree.SelectModeEnum.Row"/> mode, this will not do horizontal scrolling, as all the cells in the selected row is focused logically.</para>
    /// <para><b>Note:</b> Despite the name of this method, the focus cursor itself is only visible in <see cref="Godot.Tree.SelectModeEnum.Multi"/> mode.</para>
    /// </summary>
    public void EnsureCursorIsVisible()
    {
        NativeCalls.godot_icall_0_3(MethodBind32, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind33 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetColumnTitlesVisible, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetColumnTitlesVisible(bool visible)
    {
        NativeCalls.godot_icall_1_14(MethodBind33, GodotObject.GetPtr(this), visible.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind34 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AreColumnTitlesVisible, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool AreColumnTitlesVisible()
    {
        return NativeCalls.godot_icall_0_15(MethodBind34, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind35 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetColumnTitle, 501894301ul);

    /// <summary>
    /// <para>Sets the title of a column.</para>
    /// </summary>
    public void SetColumnTitle(int column, string title)
    {
        NativeCalls.godot_icall_2_181(MethodBind35, GodotObject.GetPtr(this), column, title);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind36 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetColumnTitle, 844755477ul);

    /// <summary>
    /// <para>Returns the column's title.</para>
    /// </summary>
    public string GetColumnTitle(int column)
    {
        return NativeCalls.godot_icall_1_133(MethodBind36, GodotObject.GetPtr(this), column);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind37 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetColumnTitleTooltipText, 501894301ul);

    /// <summary>
    /// <para>Sets the column title's tooltip text.</para>
    /// </summary>
    public void SetColumnTitleTooltipText(int column, string tooltipText)
    {
        NativeCalls.godot_icall_2_181(MethodBind37, GodotObject.GetPtr(this), column, tooltipText);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind38 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetColumnTitleTooltipText, 844755477ul);

    /// <summary>
    /// <para>Returns the column title's tooltip text.</para>
    /// </summary>
    public string GetColumnTitleTooltipText(int column)
    {
        return NativeCalls.godot_icall_1_133(MethodBind38, GodotObject.GetPtr(this), column);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind39 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetColumnTitleAlignment, 3276431499ul);

    /// <summary>
    /// <para>Sets the column title alignment. Note that <see cref="Godot.HorizontalAlignment.Fill"/> is not supported for column titles.</para>
    /// </summary>
    public void SetColumnTitleAlignment(int column, HorizontalAlignment titleAlignment)
    {
        NativeCalls.godot_icall_2_59(MethodBind39, GodotObject.GetPtr(this), column, (int)titleAlignment);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind40 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetColumnTitleAlignment, 4171562184ul);

    /// <summary>
    /// <para>Returns the column title alignment.</para>
    /// </summary>
    public HorizontalAlignment GetColumnTitleAlignment(int column)
    {
        return (HorizontalAlignment)NativeCalls.godot_icall_1_60(MethodBind40, GodotObject.GetPtr(this), column);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind41 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetColumnTitleDirection, 1707680378ul);

    /// <summary>
    /// <para>Sets column title base writing direction.</para>
    /// </summary>
    public void SetColumnTitleDirection(int column, Control.TextDirection direction)
    {
        NativeCalls.godot_icall_2_59(MethodBind41, GodotObject.GetPtr(this), column, (int)direction);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind42 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetColumnTitleDirection, 4235602388ul);

    /// <summary>
    /// <para>Returns column title base writing direction.</para>
    /// </summary>
    public Control.TextDirection GetColumnTitleDirection(int column)
    {
        return (Control.TextDirection)NativeCalls.godot_icall_1_60(MethodBind42, GodotObject.GetPtr(this), column);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind43 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetColumnTitleLanguage, 501894301ul);

    /// <summary>
    /// <para>Sets the language code of the given <paramref name="column"/>'s title to <paramref name="language"/>. This is used for line-breaking and text shaping algorithms. If <paramref name="language"/> is empty, the current locale is used.</para>
    /// </summary>
    public void SetColumnTitleLanguage(int column, string language)
    {
        NativeCalls.godot_icall_2_181(MethodBind43, GodotObject.GetPtr(this), column, language);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind44 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetColumnTitleLanguage, 844755477ul);

    /// <summary>
    /// <para>Returns column title language code.</para>
    /// </summary>
    public string GetColumnTitleLanguage(int column)
    {
        return NativeCalls.godot_icall_1_133(MethodBind44, GodotObject.GetPtr(this), column);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind45 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetScroll, 3341600327ul);

    /// <summary>
    /// <para>Returns the current scrolling position.</para>
    /// </summary>
    public Vector2 GetScroll()
    {
        return NativeCalls.godot_icall_0_37(MethodBind45, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind46 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ScrollToItem, 1314737213ul);

    /// <summary>
    /// <para>Causes the <see cref="Godot.Tree"/> to jump to the specified <see cref="Godot.TreeItem"/>.</para>
    /// </summary>
    public void ScrollToItem(TreeItem item, bool centerOnItem = false)
    {
        NativeCalls.godot_icall_2_508(MethodBind46, GodotObject.GetPtr(this), GodotObject.GetPtr(item), centerOnItem.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind47 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetHScrollEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetHScrollEnabled(bool hScroll)
    {
        NativeCalls.godot_icall_1_14(MethodBind47, GodotObject.GetPtr(this), hScroll.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind48 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsHScrollEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsHScrollEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind48, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind49 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVScrollEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetVScrollEnabled(bool hScroll)
    {
        NativeCalls.godot_icall_1_14(MethodBind49, GodotObject.GetPtr(this), hScroll.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind50 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsVScrollEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsVScrollEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind50, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind51 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetScrollHintMode, 415911924ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetScrollHintMode(Tree.ScrollHintModeEnum scrollHintMode)
    {
        NativeCalls.godot_icall_1_38(MethodBind51, GodotObject.GetPtr(this), (int)scrollHintMode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind52 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetScrollHintMode, 553087187ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Tree.ScrollHintModeEnum GetScrollHintMode()
    {
        return (Tree.ScrollHintModeEnum)NativeCalls.godot_icall_0_39(MethodBind52, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind53 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTileScrollHint, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTileScrollHint(bool tileScrollHint)
    {
        NativeCalls.godot_icall_1_14(MethodBind53, GodotObject.GetPtr(this), tileScrollHint.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind54 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsScrollHintTiled, 2240911060ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsScrollHintTiled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind54, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind55 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetHideFolding, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetHideFolding(bool hide)
    {
        NativeCalls.godot_icall_1_14(MethodBind55, GodotObject.GetPtr(this), hide.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind56 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsFoldingHidden, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsFoldingHidden()
    {
        return NativeCalls.godot_icall_0_15(MethodBind56, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind57 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEnableRecursiveFolding, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEnableRecursiveFolding(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind57, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind58 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsRecursiveFoldingEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsRecursiveFoldingEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind58, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind59 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEnableDragUnfolding, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEnableDragUnfolding(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind59, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind60 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsDragUnfoldingEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsDragUnfoldingEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind60, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind61 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDropModeFlags, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDropModeFlags(int flags)
    {
        NativeCalls.godot_icall_1_38(MethodBind61, GodotObject.GetPtr(this), flags);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind62 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDropModeFlags, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetDropModeFlags()
    {
        return NativeCalls.godot_icall_0_39(MethodBind62, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind63 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAllowRmbSelect, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAllowRmbSelect(bool allow)
    {
        NativeCalls.godot_icall_1_14(MethodBind63, GodotObject.GetPtr(this), allow.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind64 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAllowRmbSelect, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetAllowRmbSelect()
    {
        return NativeCalls.godot_icall_0_15(MethodBind64, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind65 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAllowReselect, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAllowReselect(bool allow)
    {
        NativeCalls.godot_icall_1_14(MethodBind65, GodotObject.GetPtr(this), allow.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind66 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAllowReselect, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetAllowReselect()
    {
        return NativeCalls.godot_icall_0_15(MethodBind66, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind67 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAllowSearch, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAllowSearch(bool allow)
    {
        NativeCalls.godot_icall_1_14(MethodBind67, GodotObject.GetPtr(this), allow.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind68 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAllowSearch, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetAllowSearch()
    {
        return NativeCalls.godot_icall_0_15(MethodBind68, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind69 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAutoTooltip, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAutoTooltip(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind69, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind70 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsAutoTooltipEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsAutoTooltipEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind70, GodotObject.GetPtr(this)).ToBool();
    }

    /// <summary>
    /// <para>Emitted when an item is selected.</para>
    /// </summary>
    public event Action ItemSelected
    {
        add => Connect(SignalName.ItemSelected, Callable.From(value));
        remove => Disconnect(SignalName.ItemSelected, Callable.From(value));
    }

    protected void EmitSignalItemSelected()
    {
        EmitSignal(SignalName.ItemSelected);
    }

    /// <summary>
    /// <para>Emitted when a cell is selected.</para>
    /// </summary>
    public event Action CellSelected
    {
        add => Connect(SignalName.CellSelected, Callable.From(value));
        remove => Disconnect(SignalName.CellSelected, Callable.From(value));
    }

    protected void EmitSignalCellSelected()
    {
        EmitSignal(SignalName.CellSelected);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.Tree.MultiSelected"/> event of a <see cref="Godot.Tree"/> class.
    /// </summary>
    public delegate void MultiSelectedEventHandler(TreeItem item, long column, bool selected);

    private static void MultiSelectedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 3);
        ((MultiSelectedEventHandler)delegateObj)(VariantUtils.ConvertTo<TreeItem>(args[0]), VariantUtils.ConvertTo<long>(args[1]), VariantUtils.ConvertTo<bool>(args[2]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted instead of <see cref="Godot.Tree.ItemSelected"/> if <see cref="Godot.Tree.SelectMode"/> is set to <see cref="Godot.Tree.SelectModeEnum.Multi"/>.</para>
    /// </summary>
    public unsafe event MultiSelectedEventHandler MultiSelected
    {
        add => Connect(SignalName.MultiSelected, Callable.CreateWithUnsafeTrampoline(value, &MultiSelectedTrampoline));
        remove => Disconnect(SignalName.MultiSelected, Callable.CreateWithUnsafeTrampoline(value, &MultiSelectedTrampoline));
    }

    protected void EmitSignalMultiSelected(TreeItem item, long column, bool selected)
    {
        EmitSignal(SignalName.MultiSelected, item, column, selected);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.Tree.ItemMouseSelected"/> event of a <see cref="Godot.Tree"/> class.
    /// </summary>
    public delegate void ItemMouseSelectedEventHandler(Vector2 mousePosition, long mouseButtonIndex);

    private static void ItemMouseSelectedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 2);
        ((ItemMouseSelectedEventHandler)delegateObj)(VariantUtils.ConvertTo<Vector2>(args[0]), VariantUtils.ConvertTo<long>(args[1]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when an item is selected with a mouse button.</para>
    /// </summary>
    public unsafe event ItemMouseSelectedEventHandler ItemMouseSelected
    {
        add => Connect(SignalName.ItemMouseSelected, Callable.CreateWithUnsafeTrampoline(value, &ItemMouseSelectedTrampoline));
        remove => Disconnect(SignalName.ItemMouseSelected, Callable.CreateWithUnsafeTrampoline(value, &ItemMouseSelectedTrampoline));
    }

    protected void EmitSignalItemMouseSelected(Vector2 mousePosition, long mouseButtonIndex)
    {
        EmitSignal(SignalName.ItemMouseSelected, mousePosition, mouseButtonIndex);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.Tree.EmptyClicked"/> event of a <see cref="Godot.Tree"/> class.
    /// </summary>
    public delegate void EmptyClickedEventHandler(Vector2 clickPosition, long mouseButtonIndex);

    private static void EmptyClickedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 2);
        ((EmptyClickedEventHandler)delegateObj)(VariantUtils.ConvertTo<Vector2>(args[0]), VariantUtils.ConvertTo<long>(args[1]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when a mouse button is clicked in the empty space of the tree.</para>
    /// </summary>
    public unsafe event EmptyClickedEventHandler EmptyClicked
    {
        add => Connect(SignalName.EmptyClicked, Callable.CreateWithUnsafeTrampoline(value, &EmptyClickedTrampoline));
        remove => Disconnect(SignalName.EmptyClicked, Callable.CreateWithUnsafeTrampoline(value, &EmptyClickedTrampoline));
    }

    protected void EmitSignalEmptyClicked(Vector2 clickPosition, long mouseButtonIndex)
    {
        EmitSignal(SignalName.EmptyClicked, clickPosition, mouseButtonIndex);
    }

    /// <summary>
    /// <para>Emitted when an item is edited.</para>
    /// </summary>
    public event Action ItemEdited
    {
        add => Connect(SignalName.ItemEdited, Callable.From(value));
        remove => Disconnect(SignalName.ItemEdited, Callable.From(value));
    }

    protected void EmitSignalItemEdited()
    {
        EmitSignal(SignalName.ItemEdited);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.Tree.CustomItemClicked"/> event of a <see cref="Godot.Tree"/> class.
    /// </summary>
    public delegate void CustomItemClickedEventHandler(long mouseButtonIndex);

    private static void CustomItemClickedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((CustomItemClickedEventHandler)delegateObj)(VariantUtils.ConvertTo<long>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when an item with <see cref="Godot.TreeItem.TreeCellMode.Custom"/> is clicked with a mouse button.</para>
    /// </summary>
    public unsafe event CustomItemClickedEventHandler CustomItemClicked
    {
        add => Connect(SignalName.CustomItemClicked, Callable.CreateWithUnsafeTrampoline(value, &CustomItemClickedTrampoline));
        remove => Disconnect(SignalName.CustomItemClicked, Callable.CreateWithUnsafeTrampoline(value, &CustomItemClickedTrampoline));
    }

    protected void EmitSignalCustomItemClicked(long mouseButtonIndex)
    {
        EmitSignal(SignalName.CustomItemClicked, mouseButtonIndex);
    }

    /// <summary>
    /// <para>Emitted when an item's icon is double-clicked. For a signal that emits when any part of the item is double-clicked, see <see cref="Godot.Tree.ItemActivated"/>.</para>
    /// </summary>
    public event Action ItemIconDoubleClicked
    {
        add => Connect(SignalName.ItemIconDoubleClicked, Callable.From(value));
        remove => Disconnect(SignalName.ItemIconDoubleClicked, Callable.From(value));
    }

    protected void EmitSignalItemIconDoubleClicked()
    {
        EmitSignal(SignalName.ItemIconDoubleClicked);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.Tree.ItemCollapsed"/> event of a <see cref="Godot.Tree"/> class.
    /// </summary>
    public delegate void ItemCollapsedEventHandler(TreeItem item);

    private static void ItemCollapsedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((ItemCollapsedEventHandler)delegateObj)(VariantUtils.ConvertTo<TreeItem>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when an item is expanded or collapsed by clicking on the folding arrow or through code.</para>
    /// <para><b>Note:</b> Despite its name, this signal is also emitted when an item is expanded.</para>
    /// </summary>
    public unsafe event ItemCollapsedEventHandler ItemCollapsed
    {
        add => Connect(SignalName.ItemCollapsed, Callable.CreateWithUnsafeTrampoline(value, &ItemCollapsedTrampoline));
        remove => Disconnect(SignalName.ItemCollapsed, Callable.CreateWithUnsafeTrampoline(value, &ItemCollapsedTrampoline));
    }

    protected void EmitSignalItemCollapsed(TreeItem item)
    {
        EmitSignal(SignalName.ItemCollapsed, item);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.Tree.CheckPropagatedToItem"/> event of a <see cref="Godot.Tree"/> class.
    /// </summary>
    public delegate void CheckPropagatedToItemEventHandler(TreeItem item, long column);

    private static void CheckPropagatedToItemTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 2);
        ((CheckPropagatedToItemEventHandler)delegateObj)(VariantUtils.ConvertTo<TreeItem>(args[0]), VariantUtils.ConvertTo<long>(args[1]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when <see cref="Godot.TreeItem.PropagateCheck(int, bool)"/> is called. Connect to this signal to process the items that are affected when <see cref="Godot.TreeItem.PropagateCheck(int, bool)"/> is invoked. The order that the items affected will be processed is as follows: the item that invoked the method, children of that item, and finally parents of that item.</para>
    /// </summary>
    public unsafe event CheckPropagatedToItemEventHandler CheckPropagatedToItem
    {
        add => Connect(SignalName.CheckPropagatedToItem, Callable.CreateWithUnsafeTrampoline(value, &CheckPropagatedToItemTrampoline));
        remove => Disconnect(SignalName.CheckPropagatedToItem, Callable.CreateWithUnsafeTrampoline(value, &CheckPropagatedToItemTrampoline));
    }

    protected void EmitSignalCheckPropagatedToItem(TreeItem item, long column)
    {
        EmitSignal(SignalName.CheckPropagatedToItem, item, column);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.Tree.ButtonClicked"/> event of a <see cref="Godot.Tree"/> class.
    /// </summary>
    public delegate void ButtonClickedEventHandler(TreeItem item, long column, long id, long mouseButtonIndex);

    private static void ButtonClickedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 4);
        ((ButtonClickedEventHandler)delegateObj)(VariantUtils.ConvertTo<TreeItem>(args[0]), VariantUtils.ConvertTo<long>(args[1]), VariantUtils.ConvertTo<long>(args[2]), VariantUtils.ConvertTo<long>(args[3]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when a button on the tree was pressed (see <see cref="Godot.TreeItem.AddButton(int, Texture2D, int, bool, string, string)"/>).</para>
    /// </summary>
    public unsafe event ButtonClickedEventHandler ButtonClicked
    {
        add => Connect(SignalName.ButtonClicked, Callable.CreateWithUnsafeTrampoline(value, &ButtonClickedTrampoline));
        remove => Disconnect(SignalName.ButtonClicked, Callable.CreateWithUnsafeTrampoline(value, &ButtonClickedTrampoline));
    }

    protected void EmitSignalButtonClicked(TreeItem item, long column, long id, long mouseButtonIndex)
    {
        EmitSignal(SignalName.ButtonClicked, item, column, id, mouseButtonIndex);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.Tree.CustomPopupEdited"/> event of a <see cref="Godot.Tree"/> class.
    /// </summary>
    public delegate void CustomPopupEditedEventHandler(bool arrowClicked);

    private static void CustomPopupEditedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((CustomPopupEditedEventHandler)delegateObj)(VariantUtils.ConvertTo<bool>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when a cell with the <see cref="Godot.TreeItem.TreeCellMode.Custom"/> is clicked to be edited.</para>
    /// </summary>
    public unsafe event CustomPopupEditedEventHandler CustomPopupEdited
    {
        add => Connect(SignalName.CustomPopupEdited, Callable.CreateWithUnsafeTrampoline(value, &CustomPopupEditedTrampoline));
        remove => Disconnect(SignalName.CustomPopupEdited, Callable.CreateWithUnsafeTrampoline(value, &CustomPopupEditedTrampoline));
    }

    protected void EmitSignalCustomPopupEdited(bool arrowClicked)
    {
        EmitSignal(SignalName.CustomPopupEdited, arrowClicked);
    }

    /// <summary>
    /// <para>Emitted when an item is double-clicked, or selected with a <c>ui_accept</c> input event (e.g. using Enter or Space on the keyboard).</para>
    /// </summary>
    public event Action ItemActivated
    {
        add => Connect(SignalName.ItemActivated, Callable.From(value));
        remove => Disconnect(SignalName.ItemActivated, Callable.From(value));
    }

    protected void EmitSignalItemActivated()
    {
        EmitSignal(SignalName.ItemActivated);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.Tree.ColumnTitleClicked"/> event of a <see cref="Godot.Tree"/> class.
    /// </summary>
    public delegate void ColumnTitleClickedEventHandler(long column, long mouseButtonIndex);

    private static void ColumnTitleClickedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 2);
        ((ColumnTitleClickedEventHandler)delegateObj)(VariantUtils.ConvertTo<long>(args[0]), VariantUtils.ConvertTo<long>(args[1]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when a column's title is clicked with either <see cref="Godot.MouseButton.Left"/> or <see cref="Godot.MouseButton.Right"/>.</para>
    /// </summary>
    public unsafe event ColumnTitleClickedEventHandler ColumnTitleClicked
    {
        add => Connect(SignalName.ColumnTitleClicked, Callable.CreateWithUnsafeTrampoline(value, &ColumnTitleClickedTrampoline));
        remove => Disconnect(SignalName.ColumnTitleClicked, Callable.CreateWithUnsafeTrampoline(value, &ColumnTitleClickedTrampoline));
    }

    protected void EmitSignalColumnTitleClicked(long column, long mouseButtonIndex)
    {
        EmitSignal(SignalName.ColumnTitleClicked, column, mouseButtonIndex);
    }

    /// <summary>
    /// <para>Emitted when a left mouse button click does not select any item.</para>
    /// </summary>
    public event Action NothingSelected
    {
        add => Connect(SignalName.NothingSelected, Callable.From(value));
        remove => Disconnect(SignalName.NothingSelected, Callable.From(value));
    }

    protected void EmitSignalNothingSelected()
    {
        EmitSignal(SignalName.NothingSelected);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_item_selected = "ItemSelected";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_cell_selected = "CellSelected";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_multi_selected = "MultiSelected";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_item_mouse_selected = "ItemMouseSelected";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_empty_clicked = "EmptyClicked";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_item_edited = "ItemEdited";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_custom_item_clicked = "CustomItemClicked";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_item_icon_double_clicked = "ItemIconDoubleClicked";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_item_collapsed = "ItemCollapsed";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_check_propagated_to_item = "CheckPropagatedToItem";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_button_clicked = "ButtonClicked";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_custom_popup_edited = "CustomPopupEdited";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_item_activated = "ItemActivated";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_column_title_clicked = "ColumnTitleClicked";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_nothing_selected = "NothingSelected";

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
        if (signal == SignalName.CellSelected)
        {
            if (HasGodotClassSignal(SignalProxyName_cell_selected.NativeValue.DangerousSelfRef))
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
        if (signal == SignalName.ItemMouseSelected)
        {
            if (HasGodotClassSignal(SignalProxyName_item_mouse_selected.NativeValue.DangerousSelfRef))
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
        if (signal == SignalName.ItemEdited)
        {
            if (HasGodotClassSignal(SignalProxyName_item_edited.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.CustomItemClicked)
        {
            if (HasGodotClassSignal(SignalProxyName_custom_item_clicked.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.ItemIconDoubleClicked)
        {
            if (HasGodotClassSignal(SignalProxyName_item_icon_double_clicked.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.ItemCollapsed)
        {
            if (HasGodotClassSignal(SignalProxyName_item_collapsed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.CheckPropagatedToItem)
        {
            if (HasGodotClassSignal(SignalProxyName_check_propagated_to_item.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.ButtonClicked)
        {
            if (HasGodotClassSignal(SignalProxyName_button_clicked.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.CustomPopupEdited)
        {
            if (HasGodotClassSignal(SignalProxyName_custom_popup_edited.NativeValue.DangerousSelfRef))
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
        if (signal == SignalName.ColumnTitleClicked)
        {
            if (HasGodotClassSignal(SignalProxyName_column_title_clicked.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.NothingSelected)
        {
            if (HasGodotClassSignal(SignalProxyName_nothing_selected.NativeValue.DangerousSelfRef))
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
        /// Cached name for the 'columns' property.
        /// </summary>
        public static readonly StringName Columns = "columns";
        /// <summary>
        /// Cached name for the 'column_titles_visible' property.
        /// </summary>
        public static readonly StringName ColumnTitlesVisible = "column_titles_visible";
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
        /// Cached name for the 'hide_folding' property.
        /// </summary>
        public static readonly StringName HideFolding = "hide_folding";
        /// <summary>
        /// Cached name for the 'enable_recursive_folding' property.
        /// </summary>
        public static readonly StringName EnableRecursiveFolding = "enable_recursive_folding";
        /// <summary>
        /// Cached name for the 'enable_drag_unfolding' property.
        /// </summary>
        public static readonly StringName EnableDragUnfolding = "enable_drag_unfolding";
        /// <summary>
        /// Cached name for the 'hide_root' property.
        /// </summary>
        public static readonly StringName HideRoot = "hide_root";
        /// <summary>
        /// Cached name for the 'drop_mode_flags' property.
        /// </summary>
        public static readonly StringName DropModeFlags = "drop_mode_flags";
        /// <summary>
        /// Cached name for the 'select_mode' property.
        /// </summary>
        public static readonly StringName SelectMode = "select_mode";
        /// <summary>
        /// Cached name for the 'auto_tooltip' property.
        /// </summary>
        public static readonly StringName AutoTooltip = "auto_tooltip";
        /// <summary>
        /// Cached name for the 'scroll_horizontal_enabled' property.
        /// </summary>
        public static readonly StringName ScrollHorizontalEnabled = "scroll_horizontal_enabled";
        /// <summary>
        /// Cached name for the 'scroll_vertical_enabled' property.
        /// </summary>
        public static readonly StringName ScrollVerticalEnabled = "scroll_vertical_enabled";
        /// <summary>
        /// Cached name for the 'scroll_hint_mode' property.
        /// </summary>
        public static readonly StringName ScrollHintMode = "scroll_hint_mode";
        /// <summary>
        /// Cached name for the 'tile_scroll_hint' property.
        /// </summary>
        public static readonly StringName TileScrollHint = "tile_scroll_hint";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Control.MethodName
    {
        /// <summary>
        /// Cached name for the 'clear' method.
        /// </summary>
        public static readonly StringName Clear = "clear";
        /// <summary>
        /// Cached name for the 'create_item' method.
        /// </summary>
        public static readonly StringName CreateItem = "create_item";
        /// <summary>
        /// Cached name for the 'get_root' method.
        /// </summary>
        public static readonly StringName GetRoot = "get_root";
        /// <summary>
        /// Cached name for the 'set_column_custom_minimum_width' method.
        /// </summary>
        public static readonly StringName SetColumnCustomMinimumWidth = "set_column_custom_minimum_width";
        /// <summary>
        /// Cached name for the 'set_column_expand' method.
        /// </summary>
        public static readonly StringName SetColumnExpand = "set_column_expand";
        /// <summary>
        /// Cached name for the 'set_column_expand_ratio' method.
        /// </summary>
        public static readonly StringName SetColumnExpandRatio = "set_column_expand_ratio";
        /// <summary>
        /// Cached name for the 'set_column_clip_content' method.
        /// </summary>
        public static readonly StringName SetColumnClipContent = "set_column_clip_content";
        /// <summary>
        /// Cached name for the 'is_column_expanding' method.
        /// </summary>
        public static readonly StringName IsColumnExpanding = "is_column_expanding";
        /// <summary>
        /// Cached name for the 'is_column_clipping_content' method.
        /// </summary>
        public static readonly StringName IsColumnClippingContent = "is_column_clipping_content";
        /// <summary>
        /// Cached name for the 'get_column_expand_ratio' method.
        /// </summary>
        public static readonly StringName GetColumnExpandRatio = "get_column_expand_ratio";
        /// <summary>
        /// Cached name for the 'get_column_width' method.
        /// </summary>
        public static readonly StringName GetColumnWidth = "get_column_width";
        /// <summary>
        /// Cached name for the 'set_hide_root' method.
        /// </summary>
        public static readonly StringName SetHideRoot = "set_hide_root";
        /// <summary>
        /// Cached name for the 'is_root_hidden' method.
        /// </summary>
        public static readonly StringName IsRootHidden = "is_root_hidden";
        /// <summary>
        /// Cached name for the 'get_next_selected' method.
        /// </summary>
        public static readonly StringName GetNextSelected = "get_next_selected";
        /// <summary>
        /// Cached name for the 'get_selected' method.
        /// </summary>
        public static readonly StringName GetSelected = "get_selected";
        /// <summary>
        /// Cached name for the 'set_selected' method.
        /// </summary>
        public static readonly StringName SetSelected = "set_selected";
        /// <summary>
        /// Cached name for the 'get_selected_column' method.
        /// </summary>
        public static readonly StringName GetSelectedColumn = "get_selected_column";
        /// <summary>
        /// Cached name for the 'get_pressed_button' method.
        /// </summary>
        public static readonly StringName GetPressedButton = "get_pressed_button";
        /// <summary>
        /// Cached name for the 'set_select_mode' method.
        /// </summary>
        public static readonly StringName SetSelectMode = "set_select_mode";
        /// <summary>
        /// Cached name for the 'get_select_mode' method.
        /// </summary>
        public static readonly StringName GetSelectMode = "get_select_mode";
        /// <summary>
        /// Cached name for the 'deselect_all' method.
        /// </summary>
        public static readonly StringName DeselectAll = "deselect_all";
        /// <summary>
        /// Cached name for the 'set_columns' method.
        /// </summary>
        public static readonly StringName SetColumns = "set_columns";
        /// <summary>
        /// Cached name for the 'get_columns' method.
        /// </summary>
        public static readonly StringName GetColumns = "get_columns";
        /// <summary>
        /// Cached name for the 'get_edited' method.
        /// </summary>
        public static readonly StringName GetEdited = "get_edited";
        /// <summary>
        /// Cached name for the 'get_edited_column' method.
        /// </summary>
        public static readonly StringName GetEditedColumn = "get_edited_column";
        /// <summary>
        /// Cached name for the 'edit_selected' method.
        /// </summary>
        public static readonly StringName EditSelected = "edit_selected";
        /// <summary>
        /// Cached name for the 'get_custom_popup_rect' method.
        /// </summary>
        public static readonly StringName GetCustomPopupRect = "get_custom_popup_rect";
        /// <summary>
        /// Cached name for the 'get_item_area_rect' method.
        /// </summary>
        public static readonly StringName GetItemAreaRect = "get_item_area_rect";
        /// <summary>
        /// Cached name for the 'get_item_at_position' method.
        /// </summary>
        public static readonly StringName GetItemAtPosition = "get_item_at_position";
        /// <summary>
        /// Cached name for the 'get_column_at_position' method.
        /// </summary>
        public static readonly StringName GetColumnAtPosition = "get_column_at_position";
        /// <summary>
        /// Cached name for the 'get_drop_section_at_position' method.
        /// </summary>
        public static readonly StringName GetDropSectionAtPosition = "get_drop_section_at_position";
        /// <summary>
        /// Cached name for the 'get_button_id_at_position' method.
        /// </summary>
        public static readonly StringName GetButtonIdAtPosition = "get_button_id_at_position";
        /// <summary>
        /// Cached name for the 'ensure_cursor_is_visible' method.
        /// </summary>
        public static readonly StringName EnsureCursorIsVisible = "ensure_cursor_is_visible";
        /// <summary>
        /// Cached name for the 'set_column_titles_visible' method.
        /// </summary>
        public static readonly StringName SetColumnTitlesVisible = "set_column_titles_visible";
        /// <summary>
        /// Cached name for the 'are_column_titles_visible' method.
        /// </summary>
        public static readonly StringName AreColumnTitlesVisible = "are_column_titles_visible";
        /// <summary>
        /// Cached name for the 'set_column_title' method.
        /// </summary>
        public static readonly StringName SetColumnTitle = "set_column_title";
        /// <summary>
        /// Cached name for the 'get_column_title' method.
        /// </summary>
        public static readonly StringName GetColumnTitle = "get_column_title";
        /// <summary>
        /// Cached name for the 'set_column_title_tooltip_text' method.
        /// </summary>
        public static readonly StringName SetColumnTitleTooltipText = "set_column_title_tooltip_text";
        /// <summary>
        /// Cached name for the 'get_column_title_tooltip_text' method.
        /// </summary>
        public static readonly StringName GetColumnTitleTooltipText = "get_column_title_tooltip_text";
        /// <summary>
        /// Cached name for the 'set_column_title_alignment' method.
        /// </summary>
        public static readonly StringName SetColumnTitleAlignment = "set_column_title_alignment";
        /// <summary>
        /// Cached name for the 'get_column_title_alignment' method.
        /// </summary>
        public static readonly StringName GetColumnTitleAlignment = "get_column_title_alignment";
        /// <summary>
        /// Cached name for the 'set_column_title_direction' method.
        /// </summary>
        public static readonly StringName SetColumnTitleDirection = "set_column_title_direction";
        /// <summary>
        /// Cached name for the 'get_column_title_direction' method.
        /// </summary>
        public static readonly StringName GetColumnTitleDirection = "get_column_title_direction";
        /// <summary>
        /// Cached name for the 'set_column_title_language' method.
        /// </summary>
        public static readonly StringName SetColumnTitleLanguage = "set_column_title_language";
        /// <summary>
        /// Cached name for the 'get_column_title_language' method.
        /// </summary>
        public static readonly StringName GetColumnTitleLanguage = "get_column_title_language";
        /// <summary>
        /// Cached name for the 'get_scroll' method.
        /// </summary>
        public static readonly StringName GetScroll = "get_scroll";
        /// <summary>
        /// Cached name for the 'scroll_to_item' method.
        /// </summary>
        public static readonly StringName ScrollToItem = "scroll_to_item";
        /// <summary>
        /// Cached name for the 'set_h_scroll_enabled' method.
        /// </summary>
        public static readonly StringName SetHScrollEnabled = "set_h_scroll_enabled";
        /// <summary>
        /// Cached name for the 'is_h_scroll_enabled' method.
        /// </summary>
        public static readonly StringName IsHScrollEnabled = "is_h_scroll_enabled";
        /// <summary>
        /// Cached name for the 'set_v_scroll_enabled' method.
        /// </summary>
        public static readonly StringName SetVScrollEnabled = "set_v_scroll_enabled";
        /// <summary>
        /// Cached name for the 'is_v_scroll_enabled' method.
        /// </summary>
        public static readonly StringName IsVScrollEnabled = "is_v_scroll_enabled";
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
        /// Cached name for the 'set_hide_folding' method.
        /// </summary>
        public static readonly StringName SetHideFolding = "set_hide_folding";
        /// <summary>
        /// Cached name for the 'is_folding_hidden' method.
        /// </summary>
        public static readonly StringName IsFoldingHidden = "is_folding_hidden";
        /// <summary>
        /// Cached name for the 'set_enable_recursive_folding' method.
        /// </summary>
        public static readonly StringName SetEnableRecursiveFolding = "set_enable_recursive_folding";
        /// <summary>
        /// Cached name for the 'is_recursive_folding_enabled' method.
        /// </summary>
        public static readonly StringName IsRecursiveFoldingEnabled = "is_recursive_folding_enabled";
        /// <summary>
        /// Cached name for the 'set_enable_drag_unfolding' method.
        /// </summary>
        public static readonly StringName SetEnableDragUnfolding = "set_enable_drag_unfolding";
        /// <summary>
        /// Cached name for the 'is_drag_unfolding_enabled' method.
        /// </summary>
        public static readonly StringName IsDragUnfoldingEnabled = "is_drag_unfolding_enabled";
        /// <summary>
        /// Cached name for the 'set_drop_mode_flags' method.
        /// </summary>
        public static readonly StringName SetDropModeFlags = "set_drop_mode_flags";
        /// <summary>
        /// Cached name for the 'get_drop_mode_flags' method.
        /// </summary>
        public static readonly StringName GetDropModeFlags = "get_drop_mode_flags";
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
        /// Cached name for the 'set_auto_tooltip' method.
        /// </summary>
        public static readonly StringName SetAutoTooltip = "set_auto_tooltip";
        /// <summary>
        /// Cached name for the 'is_auto_tooltip_enabled' method.
        /// </summary>
        public static readonly StringName IsAutoTooltipEnabled = "is_auto_tooltip_enabled";
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
        /// Cached name for the 'cell_selected' signal.
        /// </summary>
        public static readonly StringName CellSelected = "cell_selected";
        /// <summary>
        /// Cached name for the 'multi_selected' signal.
        /// </summary>
        public static readonly StringName MultiSelected = "multi_selected";
        /// <summary>
        /// Cached name for the 'item_mouse_selected' signal.
        /// </summary>
        public static readonly StringName ItemMouseSelected = "item_mouse_selected";
        /// <summary>
        /// Cached name for the 'empty_clicked' signal.
        /// </summary>
        public static readonly StringName EmptyClicked = "empty_clicked";
        /// <summary>
        /// Cached name for the 'item_edited' signal.
        /// </summary>
        public static readonly StringName ItemEdited = "item_edited";
        /// <summary>
        /// Cached name for the 'custom_item_clicked' signal.
        /// </summary>
        public static readonly StringName CustomItemClicked = "custom_item_clicked";
        /// <summary>
        /// Cached name for the 'item_icon_double_clicked' signal.
        /// </summary>
        public static readonly StringName ItemIconDoubleClicked = "item_icon_double_clicked";
        /// <summary>
        /// Cached name for the 'item_collapsed' signal.
        /// </summary>
        public static readonly StringName ItemCollapsed = "item_collapsed";
        /// <summary>
        /// Cached name for the 'check_propagated_to_item' signal.
        /// </summary>
        public static readonly StringName CheckPropagatedToItem = "check_propagated_to_item";
        /// <summary>
        /// Cached name for the 'button_clicked' signal.
        /// </summary>
        public static readonly StringName ButtonClicked = "button_clicked";
        /// <summary>
        /// Cached name for the 'custom_popup_edited' signal.
        /// </summary>
        public static readonly StringName CustomPopupEdited = "custom_popup_edited";
        /// <summary>
        /// Cached name for the 'item_activated' signal.
        /// </summary>
        public static readonly StringName ItemActivated = "item_activated";
        /// <summary>
        /// Cached name for the 'column_title_clicked' signal.
        /// </summary>
        public static readonly StringName ColumnTitleClicked = "column_title_clicked";
        /// <summary>
        /// Cached name for the 'nothing_selected' signal.
        /// </summary>
        public static readonly StringName NothingSelected = "nothing_selected";
    }
}
