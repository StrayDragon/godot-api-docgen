namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A control that provides a horizontal bar with tabs. Similar to <see cref="Godot.TabContainer"/> but is only in charge of drawing tabs, not interacting with children.</para>
/// </summary>
public partial class TabBar : Control
{
    public enum AlignmentMode : long
    {
        /// <summary>
        /// <para>Aligns tabs to the left.</para>
        /// </summary>
        Left = 0,
        /// <summary>
        /// <para>Aligns tabs in the middle.</para>
        /// </summary>
        Center = 1,
        /// <summary>
        /// <para>Aligns tabs to the right.</para>
        /// </summary>
        Right = 2,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.TabBar.AlignmentMode"/> enum.</para>
        /// </summary>
        Max = 3
    }

    public enum CloseButtonDisplayPolicy : long
    {
        /// <summary>
        /// <para>Never show the close buttons.</para>
        /// </summary>
        ShowNever = 0,
        /// <summary>
        /// <para>Only show the close button on the currently active tab.</para>
        /// </summary>
        ShowActiveOnly = 1,
        /// <summary>
        /// <para>Show the close button on all tabs.</para>
        /// </summary>
        ShowAlways = 2,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.TabBar.CloseButtonDisplayPolicy"/> enum.</para>
        /// </summary>
        Max = 3
    }

    /// <summary>
    /// <para>The index of the current selected tab. A value of <c>-1</c> means that no tab is selected and can only be set when <see cref="Godot.TabBar.DeselectEnabled"/> is <see langword="true"/> or if all tabs are hidden or disabled.</para>
    /// </summary>
    public int CurrentTab
    {
        get
        {
            return GetCurrentTab();
        }
        set
        {
            SetCurrentTab(value);
        }
    }

    /// <summary>
    /// <para>The horizontal alignment of the tabs.</para>
    /// </summary>
    public TabBar.AlignmentMode TabAlignment
    {
        get
        {
            return GetTabAlignment();
        }
        set
        {
            SetTabAlignment(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, tabs overflowing this node's width will be hidden, displaying two navigation buttons instead. Otherwise, this node's minimum size is updated so that all tabs are visible.</para>
    /// </summary>
    public bool ClipTabs
    {
        get
        {
            return GetClipTabs();
        }
        set
        {
            SetClipTabs(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, middle-clicking on a tab will emit the <see cref="Godot.TabBar.TabClosePressed"/> signal.</para>
    /// </summary>
    public bool CloseWithMiddleMouse
    {
        get
        {
            return GetCloseWithMiddleMouse();
        }
        set
        {
            SetCloseWithMiddleMouse(value);
        }
    }

    /// <summary>
    /// <para>When the close button will appear on the tabs.</para>
    /// </summary>
    public TabBar.CloseButtonDisplayPolicy TabCloseDisplayPolicy
    {
        get
        {
            return GetTabCloseDisplayPolicy();
        }
        set
        {
            SetTabCloseDisplayPolicy(value);
        }
    }

    /// <summary>
    /// <para>Sets the maximum width which all tabs should be limited to. Unlimited if set to <c>0</c>.</para>
    /// </summary>
    public int MaxTabWidth
    {
        get
        {
            return GetMaxTabWidth();
        }
        set
        {
            SetMaxTabWidth(value);
        }
    }

    /// <summary>
    /// <para>if <see langword="true"/>, the mouse's scroll wheel can be used to navigate the scroll view.</para>
    /// </summary>
    public bool ScrollingEnabled
    {
        get
        {
            return GetScrollingEnabled();
        }
        set
        {
            SetScrollingEnabled(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, tabs can be rearranged with mouse drag.</para>
    /// </summary>
    public bool DragToRearrangeEnabled
    {
        get
        {
            return GetDragToRearrangeEnabled();
        }
        set
        {
            SetDragToRearrangeEnabled(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, hovering over a tab while dragging something will switch to that tab. Does not have effect when hovering another tab to rearrange. The delay for when this happens is dictated by <c>hover_switch_wait_msec</c>.</para>
    /// </summary>
    public bool SwitchOnDragHover
    {
        get
        {
            return GetSwitchOnDragHover();
        }
        set
        {
            SetSwitchOnDragHover(value);
        }
    }

    /// <summary>
    /// <para><see cref="Godot.TabBar"/>s with the same rearrange group ID will allow dragging the tabs between them. Enable drag with <see cref="Godot.TabBar.DragToRearrangeEnabled"/>.</para>
    /// <para>Setting this to <c>-1</c> will disable rearranging between <see cref="Godot.TabBar"/>s.</para>
    /// </summary>
    public int TabsRearrangeGroup
    {
        get
        {
            return GetTabsRearrangeGroup();
        }
        set
        {
            SetTabsRearrangeGroup(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the tab offset will be changed to keep the currently selected tab visible.</para>
    /// </summary>
    public bool ScrollToSelected
    {
        get
        {
            return GetScrollToSelected();
        }
        set
        {
            SetScrollToSelected(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, enables selecting a tab with the right mouse button.</para>
    /// </summary>
    public bool SelectWithRmb
    {
        get
        {
            return GetSelectWithRmb();
        }
        set
        {
            SetSelectWithRmb(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, all tabs can be deselected so that no tab is selected. Click on the current tab to deselect it.</para>
    /// </summary>
    public bool DeselectEnabled
    {
        get
        {
            return GetDeselectEnabled();
        }
        set
        {
            SetDeselectEnabled(value);
        }
    }

    /// <summary>
    /// <para>The number of tabs currently in the bar.</para>
    /// </summary>
    public int TabCount
    {
        get
        {
            return GetTabCount();
        }
        set
        {
            SetTabCount(value);
        }
    }

    private static readonly System.Type CachedType = typeof(TabBar);

    private static readonly StringName NativeName = "TabBar";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public TabBar() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal TabBar(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal TabBar(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTabCount, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTabCount(int count)
    {
        NativeCalls.godot_icall_1_38(MethodBind0, GodotObject.GetPtr(this), count);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTabCount, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetTabCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCurrentTab, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCurrentTab(int tabIdx)
    {
        NativeCalls.godot_icall_1_38(MethodBind2, GodotObject.GetPtr(this), tabIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCurrentTab, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetCurrentTab()
    {
        return NativeCalls.godot_icall_0_39(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPreviousTab, 3905245786ul);

    /// <summary>
    /// <para>Returns the previously active tab index.</para>
    /// </summary>
    public int GetPreviousTab()
    {
        return NativeCalls.godot_icall_0_39(MethodBind4, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SelectPreviousAvailable, 2240911060ul);

    /// <summary>
    /// <para>Selects the first available tab with lower index than the currently selected. Returns <see langword="true"/> if tab selection changed.</para>
    /// </summary>
    public bool SelectPreviousAvailable()
    {
        return NativeCalls.godot_icall_0_15(MethodBind5, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SelectNextAvailable, 2240911060ul);

    /// <summary>
    /// <para>Selects the first available tab with greater index than the currently selected. Returns <see langword="true"/> if tab selection changed.</para>
    /// </summary>
    public bool SelectNextAvailable()
    {
        return NativeCalls.godot_icall_0_15(MethodBind6, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTabTitle, 501894301ul);

    /// <summary>
    /// <para>Sets a <paramref name="title"/> for the tab at index <paramref name="tabIdx"/>.</para>
    /// </summary>
    public void SetTabTitle(int tabIdx, string title)
    {
        NativeCalls.godot_icall_2_181(MethodBind7, GodotObject.GetPtr(this), tabIdx, title);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTabTitle, 844755477ul);

    /// <summary>
    /// <para>Returns the title of the tab at index <paramref name="tabIdx"/>.</para>
    /// </summary>
    public string GetTabTitle(int tabIdx)
    {
        return NativeCalls.godot_icall_1_133(MethodBind8, GodotObject.GetPtr(this), tabIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTabTooltip, 501894301ul);

    /// <summary>
    /// <para>Sets a <paramref name="tooltip"/> for tab at index <paramref name="tabIdx"/>.</para>
    /// <para><b>Note:</b> By default, if the <paramref name="tooltip"/> is empty and the tab text is truncated (not all characters fit into the tab), the title will be displayed as a tooltip. To hide the tooltip, assign <c>" "</c> as the <paramref name="tooltip"/> text.</para>
    /// </summary>
    public void SetTabTooltip(int tabIdx, string tooltip)
    {
        NativeCalls.godot_icall_2_181(MethodBind9, GodotObject.GetPtr(this), tabIdx, tooltip);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTabTooltip, 844755477ul);

    /// <summary>
    /// <para>Returns the tooltip text of the tab at index <paramref name="tabIdx"/>.</para>
    /// </summary>
    public string GetTabTooltip(int tabIdx)
    {
        return NativeCalls.godot_icall_1_133(MethodBind10, GodotObject.GetPtr(this), tabIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTabTextDirection, 1707680378ul);

    /// <summary>
    /// <para>Sets tab title base writing direction.</para>
    /// </summary>
    public void SetTabTextDirection(int tabIdx, Control.TextDirection direction)
    {
        NativeCalls.godot_icall_2_59(MethodBind11, GodotObject.GetPtr(this), tabIdx, (int)direction);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTabTextDirection, 4235602388ul);

    /// <summary>
    /// <para>Returns tab title text base writing direction.</para>
    /// </summary>
    public Control.TextDirection GetTabTextDirection(int tabIdx)
    {
        return (Control.TextDirection)NativeCalls.godot_icall_1_60(MethodBind12, GodotObject.GetPtr(this), tabIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTabLanguage, 501894301ul);

    /// <summary>
    /// <para>Sets the language code of the title for the tab at index <paramref name="tabIdx"/> to <paramref name="language"/>. This is used for line-breaking and text shaping algorithms. If <paramref name="language"/> is empty, the current locale is used.</para>
    /// </summary>
    public void SetTabLanguage(int tabIdx, string language)
    {
        NativeCalls.godot_icall_2_181(MethodBind13, GodotObject.GetPtr(this), tabIdx, language);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTabLanguage, 844755477ul);

    /// <summary>
    /// <para>Returns tab title language code.</para>
    /// </summary>
    public string GetTabLanguage(int tabIdx)
    {
        return NativeCalls.godot_icall_1_133(MethodBind14, GodotObject.GetPtr(this), tabIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTabIcon, 666127730ul);

    /// <summary>
    /// <para>Sets an <paramref name="icon"/> for the tab at index <paramref name="tabIdx"/>.</para>
    /// </summary>
    public void SetTabIcon(int tabIdx, Texture2D icon)
    {
        NativeCalls.godot_icall_2_70(MethodBind15, GodotObject.GetPtr(this), tabIdx, GodotObject.GetPtr(icon));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTabIcon, 3536238170ul);

    /// <summary>
    /// <para>Returns the icon for the tab at index <paramref name="tabIdx"/> or <see langword="null"/> if the tab has no icon.</para>
    /// </summary>
    public Texture2D GetTabIcon(int tabIdx)
    {
        return (Texture2D)NativeCalls.godot_icall_1_71(MethodBind16, GodotObject.GetPtr(this), tabIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTabIconMaxWidth, 3937882851ul);

    /// <summary>
    /// <para>Sets the maximum allowed width of the icon for the tab at index <paramref name="tabIdx"/>. This limit is applied on top of the default size of the icon and on top of <c>icon_max_width</c>. The height is adjusted according to the icon's ratio.</para>
    /// </summary>
    public void SetTabIconMaxWidth(int tabIdx, int width)
    {
        NativeCalls.godot_icall_2_59(MethodBind17, GodotObject.GetPtr(this), tabIdx, width);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTabIconMaxWidth, 923996154ul);

    /// <summary>
    /// <para>Returns the maximum allowed width of the icon for the tab at index <paramref name="tabIdx"/>.</para>
    /// </summary>
    public int GetTabIconMaxWidth(int tabIdx)
    {
        return NativeCalls.godot_icall_1_60(MethodBind18, GodotObject.GetPtr(this), tabIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTabButtonIcon, 666127730ul);

    /// <summary>
    /// <para>Sets an <paramref name="icon"/> for the button of the tab at index <paramref name="tabIdx"/> (located to the right, before the close button), making it visible and clickable (See <see cref="Godot.TabBar.TabButtonPressed"/>). Giving it a <see langword="null"/> value will hide the button.</para>
    /// </summary>
    public void SetTabButtonIcon(int tabIdx, Texture2D icon)
    {
        NativeCalls.godot_icall_2_70(MethodBind19, GodotObject.GetPtr(this), tabIdx, GodotObject.GetPtr(icon));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTabButtonIcon, 3536238170ul);

    /// <summary>
    /// <para>Returns the icon for the right button of the tab at index <paramref name="tabIdx"/> or <see langword="null"/> if the right button has no icon.</para>
    /// </summary>
    public Texture2D GetTabButtonIcon(int tabIdx)
    {
        return (Texture2D)NativeCalls.godot_icall_1_71(MethodBind20, GodotObject.GetPtr(this), tabIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTabDisabled, 300928843ul);

    /// <summary>
    /// <para>If <paramref name="disabled"/> is <see langword="true"/>, disables the tab at index <paramref name="tabIdx"/>, making it non-interactable.</para>
    /// </summary>
    public void SetTabDisabled(int tabIdx, bool disabled)
    {
        NativeCalls.godot_icall_2_61(MethodBind21, GodotObject.GetPtr(this), tabIdx, disabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsTabDisabled, 1116898809ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the tab at index <paramref name="tabIdx"/> is disabled.</para>
    /// </summary>
    public bool IsTabDisabled(int tabIdx)
    {
        return NativeCalls.godot_icall_1_62(MethodBind22, GodotObject.GetPtr(this), tabIdx).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTabHidden, 300928843ul);

    /// <summary>
    /// <para>If <paramref name="hidden"/> is <see langword="true"/>, hides the tab at index <paramref name="tabIdx"/>, making it disappear from the tab area.</para>
    /// </summary>
    public void SetTabHidden(int tabIdx, bool hidden)
    {
        NativeCalls.godot_icall_2_61(MethodBind23, GodotObject.GetPtr(this), tabIdx, hidden.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsTabHidden, 1116898809ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the tab at index <paramref name="tabIdx"/> is hidden.</para>
    /// </summary>
    public bool IsTabHidden(int tabIdx)
    {
        return NativeCalls.godot_icall_1_62(MethodBind24, GodotObject.GetPtr(this), tabIdx).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTabMetadata, 2152698145ul);

    /// <summary>
    /// <para>Sets the metadata value for the tab at index <paramref name="tabIdx"/>, which can be retrieved later using <see cref="Godot.TabBar.GetTabMetadata(int)"/>.</para>
    /// </summary>
    public void SetTabMetadata(int tabIdx, Variant metadata)
    {
        NativeCalls.godot_icall_2_701(MethodBind25, GodotObject.GetPtr(this), tabIdx, metadata);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTabMetadata, 4227898402ul);

    /// <summary>
    /// <para>Returns the metadata value set to the tab at index <paramref name="tabIdx"/> using <see cref="Godot.TabBar.SetTabMetadata(int, Variant)"/>. If no metadata was previously set, returns <see langword="null"/> by default.</para>
    /// </summary>
    public Variant GetTabMetadata(int tabIdx)
    {
        return NativeCalls.godot_icall_1_702(MethodBind26, GodotObject.GetPtr(this), tabIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveTab, 1286410249ul);

    /// <summary>
    /// <para>Removes the tab at index <paramref name="tabIdx"/>.</para>
    /// </summary>
    public void RemoveTab(int tabIdx)
    {
        NativeCalls.godot_icall_1_38(MethodBind27, GodotObject.GetPtr(this), tabIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddTab, 1465444425ul);

    /// <summary>
    /// <para>Adds a new tab.</para>
    /// </summary>
    public void AddTab(string title = "", Texture2D icon = null)
    {
        NativeCalls.godot_icall_2_517(MethodBind28, GodotObject.GetPtr(this), title, GodotObject.GetPtr(icon));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTabIdxAtPoint, 3820158470ul);

    /// <summary>
    /// <para>Returns the index of the tab at local coordinates <paramref name="point"/>. Returns <c>-1</c> if the point is outside the control boundaries or if there's no tab at the queried position.</para>
    /// </summary>
    public unsafe int GetTabIdxAtPoint(Vector2 point)
    {
        return NativeCalls.godot_icall_1_340(MethodBind29, GodotObject.GetPtr(this), &point);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTabAlignment, 2413632353ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTabAlignment(TabBar.AlignmentMode alignment)
    {
        NativeCalls.godot_icall_1_38(MethodBind30, GodotObject.GetPtr(this), (int)alignment);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTabAlignment, 2178122193ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public TabBar.AlignmentMode GetTabAlignment()
    {
        return (TabBar.AlignmentMode)NativeCalls.godot_icall_0_39(MethodBind31, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind32 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetClipTabs, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetClipTabs(bool clipTabs)
    {
        NativeCalls.godot_icall_1_14(MethodBind32, GodotObject.GetPtr(this), clipTabs.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind33 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetClipTabs, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetClipTabs()
    {
        return NativeCalls.godot_icall_0_15(MethodBind33, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind34 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTabOffset, 3905245786ul);

    /// <summary>
    /// <para>Returns the number of hidden tabs offsetted to the left.</para>
    /// </summary>
    public int GetTabOffset()
    {
        return NativeCalls.godot_icall_0_39(MethodBind34, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind35 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOffsetButtonsVisible, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the offset buttons (the ones that appear when there's not enough space for all tabs) are visible.</para>
    /// </summary>
    public bool GetOffsetButtonsVisible()
    {
        return NativeCalls.godot_icall_0_15(MethodBind35, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind36 = ClassDB_get_method_with_compatibility(NativeName, MethodName.EnsureTabVisible, 1286410249ul);

    /// <summary>
    /// <para>Moves the scroll view to make the tab visible.</para>
    /// </summary>
    public void EnsureTabVisible(int idx)
    {
        NativeCalls.godot_icall_1_38(MethodBind36, GodotObject.GetPtr(this), idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind37 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTabRect, 3327874267ul);

    /// <summary>
    /// <para>Returns tab <see cref="Godot.Rect2"/> with local position and size.</para>
    /// </summary>
    public Rect2 GetTabRect(int tabIdx)
    {
        return NativeCalls.godot_icall_1_450(MethodBind37, GodotObject.GetPtr(this), tabIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind38 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MoveTab, 3937882851ul);

    /// <summary>
    /// <para>Moves a tab from <paramref name="from"/> to <paramref name="to"/>.</para>
    /// </summary>
    public void MoveTab(int from, int to)
    {
        NativeCalls.godot_icall_2_59(MethodBind38, GodotObject.GetPtr(this), from, to);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind39 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCloseWithMiddleMouse, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCloseWithMiddleMouse(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind39, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind40 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCloseWithMiddleMouse, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetCloseWithMiddleMouse()
    {
        return NativeCalls.godot_icall_0_15(MethodBind40, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind41 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTabCloseDisplayPolicy, 2212906737ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTabCloseDisplayPolicy(TabBar.CloseButtonDisplayPolicy policy)
    {
        NativeCalls.godot_icall_1_38(MethodBind41, GodotObject.GetPtr(this), (int)policy);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind42 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTabCloseDisplayPolicy, 2956568028ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public TabBar.CloseButtonDisplayPolicy GetTabCloseDisplayPolicy()
    {
        return (TabBar.CloseButtonDisplayPolicy)NativeCalls.godot_icall_0_39(MethodBind42, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind43 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMaxTabWidth, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMaxTabWidth(int width)
    {
        NativeCalls.godot_icall_1_38(MethodBind43, GodotObject.GetPtr(this), width);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind44 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMaxTabWidth, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetMaxTabWidth()
    {
        return NativeCalls.godot_icall_0_39(MethodBind44, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind45 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetScrollingEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetScrollingEnabled(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind45, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind46 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetScrollingEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetScrollingEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind46, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind47 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDragToRearrangeEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDragToRearrangeEnabled(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind47, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind48 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDragToRearrangeEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetDragToRearrangeEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind48, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind49 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSwitchOnDragHover, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSwitchOnDragHover(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind49, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind50 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSwitchOnDragHover, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetSwitchOnDragHover()
    {
        return NativeCalls.godot_icall_0_15(MethodBind50, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind51 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTabsRearrangeGroup, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTabsRearrangeGroup(int groupId)
    {
        NativeCalls.godot_icall_1_38(MethodBind51, GodotObject.GetPtr(this), groupId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind52 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTabsRearrangeGroup, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetTabsRearrangeGroup()
    {
        return NativeCalls.godot_icall_0_39(MethodBind52, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind53 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetScrollToSelected, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetScrollToSelected(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind53, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind54 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetScrollToSelected, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetScrollToSelected()
    {
        return NativeCalls.godot_icall_0_15(MethodBind54, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind55 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSelectWithRmb, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSelectWithRmb(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind55, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind56 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSelectWithRmb, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetSelectWithRmb()
    {
        return NativeCalls.godot_icall_0_15(MethodBind56, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind57 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDeselectEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDeselectEnabled(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind57, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind58 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDeselectEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetDeselectEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind58, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind59 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ClearTabs, 3218959716ul);

    /// <summary>
    /// <para>Clears all tabs.</para>
    /// </summary>
    public void ClearTabs()
    {
        NativeCalls.godot_icall_0_3(MethodBind59, GodotObject.GetPtr(this));
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.TabBar.TabSelected"/> event of a <see cref="Godot.TabBar"/> class.
    /// </summary>
    public delegate void TabSelectedEventHandler(long tab);

    private static void TabSelectedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((TabSelectedEventHandler)delegateObj)(VariantUtils.ConvertTo<long>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when a tab is selected via click, directional input, or script, even if it is the current tab.</para>
    /// </summary>
    public unsafe event TabSelectedEventHandler TabSelected
    {
        add => Connect(SignalName.TabSelected, Callable.CreateWithUnsafeTrampoline(value, &TabSelectedTrampoline));
        remove => Disconnect(SignalName.TabSelected, Callable.CreateWithUnsafeTrampoline(value, &TabSelectedTrampoline));
    }

    protected void EmitSignalTabSelected(long tab)
    {
        EmitSignal(SignalName.TabSelected, tab);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.TabBar.TabChanged"/> event of a <see cref="Godot.TabBar"/> class.
    /// </summary>
    public delegate void TabChangedEventHandler(long tab);

    private static void TabChangedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((TabChangedEventHandler)delegateObj)(VariantUtils.ConvertTo<long>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when switching to another tab.</para>
    /// </summary>
    public unsafe event TabChangedEventHandler TabChanged
    {
        add => Connect(SignalName.TabChanged, Callable.CreateWithUnsafeTrampoline(value, &TabChangedTrampoline));
        remove => Disconnect(SignalName.TabChanged, Callable.CreateWithUnsafeTrampoline(value, &TabChangedTrampoline));
    }

    protected void EmitSignalTabChanged(long tab)
    {
        EmitSignal(SignalName.TabChanged, tab);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.TabBar.TabClicked"/> event of a <see cref="Godot.TabBar"/> class.
    /// </summary>
    public delegate void TabClickedEventHandler(long tab);

    private static void TabClickedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((TabClickedEventHandler)delegateObj)(VariantUtils.ConvertTo<long>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when a tab is clicked, even if it is the current tab.</para>
    /// </summary>
    public unsafe event TabClickedEventHandler TabClicked
    {
        add => Connect(SignalName.TabClicked, Callable.CreateWithUnsafeTrampoline(value, &TabClickedTrampoline));
        remove => Disconnect(SignalName.TabClicked, Callable.CreateWithUnsafeTrampoline(value, &TabClickedTrampoline));
    }

    protected void EmitSignalTabClicked(long tab)
    {
        EmitSignal(SignalName.TabClicked, tab);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.TabBar.TabRmbClicked"/> event of a <see cref="Godot.TabBar"/> class.
    /// </summary>
    public delegate void TabRmbClickedEventHandler(long tab);

    private static void TabRmbClickedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((TabRmbClickedEventHandler)delegateObj)(VariantUtils.ConvertTo<long>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when a tab is right-clicked.</para>
    /// </summary>
    public unsafe event TabRmbClickedEventHandler TabRmbClicked
    {
        add => Connect(SignalName.TabRmbClicked, Callable.CreateWithUnsafeTrampoline(value, &TabRmbClickedTrampoline));
        remove => Disconnect(SignalName.TabRmbClicked, Callable.CreateWithUnsafeTrampoline(value, &TabRmbClickedTrampoline));
    }

    protected void EmitSignalTabRmbClicked(long tab)
    {
        EmitSignal(SignalName.TabRmbClicked, tab);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.TabBar.TabClosePressed"/> event of a <see cref="Godot.TabBar"/> class.
    /// </summary>
    public delegate void TabClosePressedEventHandler(long tab);

    private static void TabClosePressedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((TabClosePressedEventHandler)delegateObj)(VariantUtils.ConvertTo<long>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when a tab's close button is pressed or, if <see cref="Godot.TabBar.CloseWithMiddleMouse"/> is <see langword="true"/>, when middle-clicking on a tab.</para>
    /// <para><b>Note:</b> Tabs are not removed automatically; this behavior needs to be coded manually. For example:</para>
    /// <para><code>
    /// GetNode&lt;TabBar&gt;("TabBar").TabClosePressed += GetNode&lt;TabBar&gt;("TabBar").RemoveTab;
    /// </code></para>
    /// </summary>
    public unsafe event TabClosePressedEventHandler TabClosePressed
    {
        add => Connect(SignalName.TabClosePressed, Callable.CreateWithUnsafeTrampoline(value, &TabClosePressedTrampoline));
        remove => Disconnect(SignalName.TabClosePressed, Callable.CreateWithUnsafeTrampoline(value, &TabClosePressedTrampoline));
    }

    protected void EmitSignalTabClosePressed(long tab)
    {
        EmitSignal(SignalName.TabClosePressed, tab);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.TabBar.TabButtonPressed"/> event of a <see cref="Godot.TabBar"/> class.
    /// </summary>
    public delegate void TabButtonPressedEventHandler(long tab);

    private static void TabButtonPressedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((TabButtonPressedEventHandler)delegateObj)(VariantUtils.ConvertTo<long>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when a tab's right button is pressed. See <see cref="Godot.TabBar.SetTabButtonIcon(int, Texture2D)"/>.</para>
    /// </summary>
    public unsafe event TabButtonPressedEventHandler TabButtonPressed
    {
        add => Connect(SignalName.TabButtonPressed, Callable.CreateWithUnsafeTrampoline(value, &TabButtonPressedTrampoline));
        remove => Disconnect(SignalName.TabButtonPressed, Callable.CreateWithUnsafeTrampoline(value, &TabButtonPressedTrampoline));
    }

    protected void EmitSignalTabButtonPressed(long tab)
    {
        EmitSignal(SignalName.TabButtonPressed, tab);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.TabBar.TabHovered"/> event of a <see cref="Godot.TabBar"/> class.
    /// </summary>
    public delegate void TabHoveredEventHandler(long tab);

    private static void TabHoveredTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((TabHoveredEventHandler)delegateObj)(VariantUtils.ConvertTo<long>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when a tab is hovered by the mouse.</para>
    /// </summary>
    public unsafe event TabHoveredEventHandler TabHovered
    {
        add => Connect(SignalName.TabHovered, Callable.CreateWithUnsafeTrampoline(value, &TabHoveredTrampoline));
        remove => Disconnect(SignalName.TabHovered, Callable.CreateWithUnsafeTrampoline(value, &TabHoveredTrampoline));
    }

    protected void EmitSignalTabHovered(long tab)
    {
        EmitSignal(SignalName.TabHovered, tab);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.TabBar.ActiveTabRearranged"/> event of a <see cref="Godot.TabBar"/> class.
    /// </summary>
    public delegate void ActiveTabRearrangedEventHandler(long idxTo);

    private static void ActiveTabRearrangedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((ActiveTabRearrangedEventHandler)delegateObj)(VariantUtils.ConvertTo<long>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when the active tab is rearranged via mouse drag. See <see cref="Godot.TabBar.DragToRearrangeEnabled"/>.</para>
    /// </summary>
    public unsafe event ActiveTabRearrangedEventHandler ActiveTabRearranged
    {
        add => Connect(SignalName.ActiveTabRearranged, Callable.CreateWithUnsafeTrampoline(value, &ActiveTabRearrangedTrampoline));
        remove => Disconnect(SignalName.ActiveTabRearranged, Callable.CreateWithUnsafeTrampoline(value, &ActiveTabRearrangedTrampoline));
    }

    protected void EmitSignalActiveTabRearranged(long idxTo)
    {
        EmitSignal(SignalName.ActiveTabRearranged, idxTo);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_tab_selected = "TabSelected";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_tab_changed = "TabChanged";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_tab_clicked = "TabClicked";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_tab_rmb_clicked = "TabRmbClicked";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_tab_close_pressed = "TabClosePressed";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_tab_button_pressed = "TabButtonPressed";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_tab_hovered = "TabHovered";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_active_tab_rearranged = "ActiveTabRearranged";

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
        if (signal == SignalName.TabSelected)
        {
            if (HasGodotClassSignal(SignalProxyName_tab_selected.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.TabChanged)
        {
            if (HasGodotClassSignal(SignalProxyName_tab_changed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.TabClicked)
        {
            if (HasGodotClassSignal(SignalProxyName_tab_clicked.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.TabRmbClicked)
        {
            if (HasGodotClassSignal(SignalProxyName_tab_rmb_clicked.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.TabClosePressed)
        {
            if (HasGodotClassSignal(SignalProxyName_tab_close_pressed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.TabButtonPressed)
        {
            if (HasGodotClassSignal(SignalProxyName_tab_button_pressed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.TabHovered)
        {
            if (HasGodotClassSignal(SignalProxyName_tab_hovered.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.ActiveTabRearranged)
        {
            if (HasGodotClassSignal(SignalProxyName_active_tab_rearranged.NativeValue.DangerousSelfRef))
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
        /// Cached name for the 'current_tab' property.
        /// </summary>
        public static readonly StringName CurrentTab = "current_tab";
        /// <summary>
        /// Cached name for the 'tab_alignment' property.
        /// </summary>
        public static readonly StringName TabAlignment = "tab_alignment";
        /// <summary>
        /// Cached name for the 'clip_tabs' property.
        /// </summary>
        public static readonly StringName ClipTabs = "clip_tabs";
        /// <summary>
        /// Cached name for the 'close_with_middle_mouse' property.
        /// </summary>
        public static readonly StringName CloseWithMiddleMouse = "close_with_middle_mouse";
        /// <summary>
        /// Cached name for the 'tab_close_display_policy' property.
        /// </summary>
        public static readonly StringName TabCloseDisplayPolicy = "tab_close_display_policy";
        /// <summary>
        /// Cached name for the 'max_tab_width' property.
        /// </summary>
        public static readonly StringName MaxTabWidth = "max_tab_width";
        /// <summary>
        /// Cached name for the 'scrolling_enabled' property.
        /// </summary>
        public static readonly StringName ScrollingEnabled = "scrolling_enabled";
        /// <summary>
        /// Cached name for the 'drag_to_rearrange_enabled' property.
        /// </summary>
        public static readonly StringName DragToRearrangeEnabled = "drag_to_rearrange_enabled";
        /// <summary>
        /// Cached name for the 'switch_on_drag_hover' property.
        /// </summary>
        public static readonly StringName SwitchOnDragHover = "switch_on_drag_hover";
        /// <summary>
        /// Cached name for the 'tabs_rearrange_group' property.
        /// </summary>
        public static readonly StringName TabsRearrangeGroup = "tabs_rearrange_group";
        /// <summary>
        /// Cached name for the 'scroll_to_selected' property.
        /// </summary>
        public static readonly StringName ScrollToSelected = "scroll_to_selected";
        /// <summary>
        /// Cached name for the 'select_with_rmb' property.
        /// </summary>
        public static readonly StringName SelectWithRmb = "select_with_rmb";
        /// <summary>
        /// Cached name for the 'deselect_enabled' property.
        /// </summary>
        public static readonly StringName DeselectEnabled = "deselect_enabled";
        /// <summary>
        /// Cached name for the 'tab_count' property.
        /// </summary>
        public static readonly StringName TabCount = "tab_count";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Control.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_tab_count' method.
        /// </summary>
        public static readonly StringName SetTabCount = "set_tab_count";
        /// <summary>
        /// Cached name for the 'get_tab_count' method.
        /// </summary>
        public static readonly StringName GetTabCount = "get_tab_count";
        /// <summary>
        /// Cached name for the 'set_current_tab' method.
        /// </summary>
        public static readonly StringName SetCurrentTab = "set_current_tab";
        /// <summary>
        /// Cached name for the 'get_current_tab' method.
        /// </summary>
        public static readonly StringName GetCurrentTab = "get_current_tab";
        /// <summary>
        /// Cached name for the 'get_previous_tab' method.
        /// </summary>
        public static readonly StringName GetPreviousTab = "get_previous_tab";
        /// <summary>
        /// Cached name for the 'select_previous_available' method.
        /// </summary>
        public static readonly StringName SelectPreviousAvailable = "select_previous_available";
        /// <summary>
        /// Cached name for the 'select_next_available' method.
        /// </summary>
        public static readonly StringName SelectNextAvailable = "select_next_available";
        /// <summary>
        /// Cached name for the 'set_tab_title' method.
        /// </summary>
        public static readonly StringName SetTabTitle = "set_tab_title";
        /// <summary>
        /// Cached name for the 'get_tab_title' method.
        /// </summary>
        public static readonly StringName GetTabTitle = "get_tab_title";
        /// <summary>
        /// Cached name for the 'set_tab_tooltip' method.
        /// </summary>
        public static readonly StringName SetTabTooltip = "set_tab_tooltip";
        /// <summary>
        /// Cached name for the 'get_tab_tooltip' method.
        /// </summary>
        public static readonly StringName GetTabTooltip = "get_tab_tooltip";
        /// <summary>
        /// Cached name for the 'set_tab_text_direction' method.
        /// </summary>
        public static readonly StringName SetTabTextDirection = "set_tab_text_direction";
        /// <summary>
        /// Cached name for the 'get_tab_text_direction' method.
        /// </summary>
        public static readonly StringName GetTabTextDirection = "get_tab_text_direction";
        /// <summary>
        /// Cached name for the 'set_tab_language' method.
        /// </summary>
        public static readonly StringName SetTabLanguage = "set_tab_language";
        /// <summary>
        /// Cached name for the 'get_tab_language' method.
        /// </summary>
        public static readonly StringName GetTabLanguage = "get_tab_language";
        /// <summary>
        /// Cached name for the 'set_tab_icon' method.
        /// </summary>
        public static readonly StringName SetTabIcon = "set_tab_icon";
        /// <summary>
        /// Cached name for the 'get_tab_icon' method.
        /// </summary>
        public static readonly StringName GetTabIcon = "get_tab_icon";
        /// <summary>
        /// Cached name for the 'set_tab_icon_max_width' method.
        /// </summary>
        public static readonly StringName SetTabIconMaxWidth = "set_tab_icon_max_width";
        /// <summary>
        /// Cached name for the 'get_tab_icon_max_width' method.
        /// </summary>
        public static readonly StringName GetTabIconMaxWidth = "get_tab_icon_max_width";
        /// <summary>
        /// Cached name for the 'set_tab_button_icon' method.
        /// </summary>
        public static readonly StringName SetTabButtonIcon = "set_tab_button_icon";
        /// <summary>
        /// Cached name for the 'get_tab_button_icon' method.
        /// </summary>
        public static readonly StringName GetTabButtonIcon = "get_tab_button_icon";
        /// <summary>
        /// Cached name for the 'set_tab_disabled' method.
        /// </summary>
        public static readonly StringName SetTabDisabled = "set_tab_disabled";
        /// <summary>
        /// Cached name for the 'is_tab_disabled' method.
        /// </summary>
        public static readonly StringName IsTabDisabled = "is_tab_disabled";
        /// <summary>
        /// Cached name for the 'set_tab_hidden' method.
        /// </summary>
        public static readonly StringName SetTabHidden = "set_tab_hidden";
        /// <summary>
        /// Cached name for the 'is_tab_hidden' method.
        /// </summary>
        public static readonly StringName IsTabHidden = "is_tab_hidden";
        /// <summary>
        /// Cached name for the 'set_tab_metadata' method.
        /// </summary>
        public static readonly StringName SetTabMetadata = "set_tab_metadata";
        /// <summary>
        /// Cached name for the 'get_tab_metadata' method.
        /// </summary>
        public static readonly StringName GetTabMetadata = "get_tab_metadata";
        /// <summary>
        /// Cached name for the 'remove_tab' method.
        /// </summary>
        public static readonly StringName RemoveTab = "remove_tab";
        /// <summary>
        /// Cached name for the 'add_tab' method.
        /// </summary>
        public static readonly StringName AddTab = "add_tab";
        /// <summary>
        /// Cached name for the 'get_tab_idx_at_point' method.
        /// </summary>
        public static readonly StringName GetTabIdxAtPoint = "get_tab_idx_at_point";
        /// <summary>
        /// Cached name for the 'set_tab_alignment' method.
        /// </summary>
        public static readonly StringName SetTabAlignment = "set_tab_alignment";
        /// <summary>
        /// Cached name for the 'get_tab_alignment' method.
        /// </summary>
        public static readonly StringName GetTabAlignment = "get_tab_alignment";
        /// <summary>
        /// Cached name for the 'set_clip_tabs' method.
        /// </summary>
        public static readonly StringName SetClipTabs = "set_clip_tabs";
        /// <summary>
        /// Cached name for the 'get_clip_tabs' method.
        /// </summary>
        public static readonly StringName GetClipTabs = "get_clip_tabs";
        /// <summary>
        /// Cached name for the 'get_tab_offset' method.
        /// </summary>
        public static readonly StringName GetTabOffset = "get_tab_offset";
        /// <summary>
        /// Cached name for the 'get_offset_buttons_visible' method.
        /// </summary>
        public static readonly StringName GetOffsetButtonsVisible = "get_offset_buttons_visible";
        /// <summary>
        /// Cached name for the 'ensure_tab_visible' method.
        /// </summary>
        public static readonly StringName EnsureTabVisible = "ensure_tab_visible";
        /// <summary>
        /// Cached name for the 'get_tab_rect' method.
        /// </summary>
        public static readonly StringName GetTabRect = "get_tab_rect";
        /// <summary>
        /// Cached name for the 'move_tab' method.
        /// </summary>
        public static readonly StringName MoveTab = "move_tab";
        /// <summary>
        /// Cached name for the 'set_close_with_middle_mouse' method.
        /// </summary>
        public static readonly StringName SetCloseWithMiddleMouse = "set_close_with_middle_mouse";
        /// <summary>
        /// Cached name for the 'get_close_with_middle_mouse' method.
        /// </summary>
        public static readonly StringName GetCloseWithMiddleMouse = "get_close_with_middle_mouse";
        /// <summary>
        /// Cached name for the 'set_tab_close_display_policy' method.
        /// </summary>
        public static readonly StringName SetTabCloseDisplayPolicy = "set_tab_close_display_policy";
        /// <summary>
        /// Cached name for the 'get_tab_close_display_policy' method.
        /// </summary>
        public static readonly StringName GetTabCloseDisplayPolicy = "get_tab_close_display_policy";
        /// <summary>
        /// Cached name for the 'set_max_tab_width' method.
        /// </summary>
        public static readonly StringName SetMaxTabWidth = "set_max_tab_width";
        /// <summary>
        /// Cached name for the 'get_max_tab_width' method.
        /// </summary>
        public static readonly StringName GetMaxTabWidth = "get_max_tab_width";
        /// <summary>
        /// Cached name for the 'set_scrolling_enabled' method.
        /// </summary>
        public static readonly StringName SetScrollingEnabled = "set_scrolling_enabled";
        /// <summary>
        /// Cached name for the 'get_scrolling_enabled' method.
        /// </summary>
        public static readonly StringName GetScrollingEnabled = "get_scrolling_enabled";
        /// <summary>
        /// Cached name for the 'set_drag_to_rearrange_enabled' method.
        /// </summary>
        public static readonly StringName SetDragToRearrangeEnabled = "set_drag_to_rearrange_enabled";
        /// <summary>
        /// Cached name for the 'get_drag_to_rearrange_enabled' method.
        /// </summary>
        public static readonly StringName GetDragToRearrangeEnabled = "get_drag_to_rearrange_enabled";
        /// <summary>
        /// Cached name for the 'set_switch_on_drag_hover' method.
        /// </summary>
        public static readonly StringName SetSwitchOnDragHover = "set_switch_on_drag_hover";
        /// <summary>
        /// Cached name for the 'get_switch_on_drag_hover' method.
        /// </summary>
        public static readonly StringName GetSwitchOnDragHover = "get_switch_on_drag_hover";
        /// <summary>
        /// Cached name for the 'set_tabs_rearrange_group' method.
        /// </summary>
        public static readonly StringName SetTabsRearrangeGroup = "set_tabs_rearrange_group";
        /// <summary>
        /// Cached name for the 'get_tabs_rearrange_group' method.
        /// </summary>
        public static readonly StringName GetTabsRearrangeGroup = "get_tabs_rearrange_group";
        /// <summary>
        /// Cached name for the 'set_scroll_to_selected' method.
        /// </summary>
        public static readonly StringName SetScrollToSelected = "set_scroll_to_selected";
        /// <summary>
        /// Cached name for the 'get_scroll_to_selected' method.
        /// </summary>
        public static readonly StringName GetScrollToSelected = "get_scroll_to_selected";
        /// <summary>
        /// Cached name for the 'set_select_with_rmb' method.
        /// </summary>
        public static readonly StringName SetSelectWithRmb = "set_select_with_rmb";
        /// <summary>
        /// Cached name for the 'get_select_with_rmb' method.
        /// </summary>
        public static readonly StringName GetSelectWithRmb = "get_select_with_rmb";
        /// <summary>
        /// Cached name for the 'set_deselect_enabled' method.
        /// </summary>
        public static readonly StringName SetDeselectEnabled = "set_deselect_enabled";
        /// <summary>
        /// Cached name for the 'get_deselect_enabled' method.
        /// </summary>
        public static readonly StringName GetDeselectEnabled = "get_deselect_enabled";
        /// <summary>
        /// Cached name for the 'clear_tabs' method.
        /// </summary>
        public static readonly StringName ClearTabs = "clear_tabs";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Control.SignalName
    {
        /// <summary>
        /// Cached name for the 'tab_selected' signal.
        /// </summary>
        public static readonly StringName TabSelected = "tab_selected";
        /// <summary>
        /// Cached name for the 'tab_changed' signal.
        /// </summary>
        public static readonly StringName TabChanged = "tab_changed";
        /// <summary>
        /// Cached name for the 'tab_clicked' signal.
        /// </summary>
        public static readonly StringName TabClicked = "tab_clicked";
        /// <summary>
        /// Cached name for the 'tab_rmb_clicked' signal.
        /// </summary>
        public static readonly StringName TabRmbClicked = "tab_rmb_clicked";
        /// <summary>
        /// Cached name for the 'tab_close_pressed' signal.
        /// </summary>
        public static readonly StringName TabClosePressed = "tab_close_pressed";
        /// <summary>
        /// Cached name for the 'tab_button_pressed' signal.
        /// </summary>
        public static readonly StringName TabButtonPressed = "tab_button_pressed";
        /// <summary>
        /// Cached name for the 'tab_hovered' signal.
        /// </summary>
        public static readonly StringName TabHovered = "tab_hovered";
        /// <summary>
        /// Cached name for the 'active_tab_rearranged' signal.
        /// </summary>
        public static readonly StringName ActiveTabRearranged = "active_tab_rearranged";
    }
}
