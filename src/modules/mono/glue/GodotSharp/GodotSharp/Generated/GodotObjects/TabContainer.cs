namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Arranges child controls into a tabbed view, creating a tab for each one. The active tab's corresponding control is made visible, while all other child controls are hidden. Ignores non-control children.</para>
/// <para><b>Note:</b> The drawing of the clickable tabs is handled by this node; <see cref="Godot.TabBar"/> is not needed.</para>
/// </summary>
public partial class TabContainer : Container
{
    public enum TabPosition : long
    {
        /// <summary>
        /// <para>Places the tab bar at the top.</para>
        /// </summary>
        Top = 0,
        /// <summary>
        /// <para>Places the tab bar at the bottom. The tab bar's <see cref="Godot.StyleBox"/> will be flipped vertically.</para>
        /// </summary>
        Bottom = 1,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.TabContainer.TabPosition"/> enum.</para>
        /// </summary>
        Max = 2
    }

    /// <summary>
    /// <para>The position at which tabs will be placed.</para>
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
    /// <para>The current tab index. When set, this index's <see cref="Godot.Control"/> node's <c>visible</c> property is set to <see langword="true"/> and all others are set to <see langword="false"/>.</para>
    /// <para>A value of <c>-1</c> means that no tab is selected.</para>
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
    public TabContainer.TabPosition TabsPosition
    {
        get
        {
            return GetTabsPosition();
        }
        set
        {
            SetTabsPosition(value);
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
    /// <para>If <see langword="true"/>, tabs are visible. If <see langword="false"/>, tabs' content and titles are hidden.</para>
    /// </summary>
    public bool TabsVisible
    {
        get
        {
            return AreTabsVisible();
        }
        set
        {
            SetTabsVisible(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, all tabs are drawn in front of the panel. If <see langword="false"/>, inactive tabs are drawn behind the panel.</para>
    /// </summary>
    public bool AllTabsInFront
    {
        get
        {
            return IsAllTabsInFront();
        }
        set
        {
            SetAllTabsInFront(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, hovering over a tab while dragging something will switch to that tab. Does not have effect when hovering another tab to rearrange.</para>
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
    /// <para><see cref="Godot.TabContainer"/>s with the same rearrange group ID will allow dragging the tabs between them. Enable drag with <see cref="Godot.TabContainer.DragToRearrangeEnabled"/>.</para>
    /// <para>Setting this to <c>-1</c> will disable rearranging between <see cref="Godot.TabContainer"/>s.</para>
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
    /// <para>If <see langword="true"/>, child <see cref="Godot.Control"/> nodes that are hidden have their minimum size take into account in the total, instead of only the currently visible one.</para>
    /// </summary>
    public bool UseHiddenTabsForMinSize
    {
        get
        {
            return GetUseHiddenTabsForMinSize();
        }
        set
        {
            SetUseHiddenTabsForMinSize(value);
        }
    }

    /// <summary>
    /// <para>The focus access mode for the internal <see cref="Godot.TabBar"/> node.</para>
    /// </summary>
    public Control.FocusModeEnum TabFocusMode
    {
        get
        {
            return GetTabFocusMode();
        }
        set
        {
            SetTabFocusMode(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, all tabs can be deselected so that no tab is selected. Click on the <see cref="Godot.TabContainer.CurrentTab"/> to deselect it.</para>
    /// <para>Only the tab header will be shown if no tabs are selected.</para>
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

    private static readonly System.Type CachedType = typeof(TabContainer);

    private static readonly StringName NativeName = "TabContainer";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public TabContainer() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal TabContainer(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal TabContainer(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTabCount, 3905245786ul);

    /// <summary>
    /// <para>Returns the number of tabs.</para>
    /// </summary>
    public int GetTabCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind0, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCurrentTab, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCurrentTab(int tabIdx)
    {
        NativeCalls.godot_icall_1_38(MethodBind1, GodotObject.GetPtr(this), tabIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCurrentTab, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetCurrentTab()
    {
        return NativeCalls.godot_icall_0_39(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPreviousTab, 3905245786ul);

    /// <summary>
    /// <para>Returns the previously active tab index.</para>
    /// </summary>
    public int GetPreviousTab()
    {
        return NativeCalls.godot_icall_0_39(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SelectPreviousAvailable, 2240911060ul);

    /// <summary>
    /// <para>Selects the first available tab with lower index than the currently selected. Returns <see langword="true"/> if tab selection changed.</para>
    /// </summary>
    public bool SelectPreviousAvailable()
    {
        return NativeCalls.godot_icall_0_15(MethodBind4, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SelectNextAvailable, 2240911060ul);

    /// <summary>
    /// <para>Selects the first available tab with greater index than the currently selected. Returns <see langword="true"/> if tab selection changed.</para>
    /// </summary>
    public bool SelectNextAvailable()
    {
        return NativeCalls.godot_icall_0_15(MethodBind5, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCurrentTabControl, 2783021301ul);

    /// <summary>
    /// <para>Returns the child <see cref="Godot.Control"/> node located at the active tab index.</para>
    /// </summary>
    public Control GetCurrentTabControl()
    {
        return (Control)NativeCalls.godot_icall_0_53(MethodBind6, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTabBar, 1865451809ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.TabBar"/> contained in this container.</para>
    /// <para><b>Warning:</b> This is a required internal node, removing and freeing it or editing its tabs may cause a crash. If you wish to edit the tabs, use the methods provided in <see cref="Godot.TabContainer"/>.</para>
    /// </summary>
    public TabBar GetTabBar()
    {
        return (TabBar)NativeCalls.godot_icall_0_53(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTabControl, 1065994134ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.Control"/> node from the tab at index <paramref name="tabIdx"/>.</para>
    /// </summary>
    public Control GetTabControl(int tabIdx)
    {
        return (Control)NativeCalls.godot_icall_1_335(MethodBind8, GodotObject.GetPtr(this), tabIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTabAlignment, 2413632353ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTabAlignment(TabBar.AlignmentMode alignment)
    {
        NativeCalls.godot_icall_1_38(MethodBind9, GodotObject.GetPtr(this), (int)alignment);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTabAlignment, 2178122193ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public TabBar.AlignmentMode GetTabAlignment()
    {
        return (TabBar.AlignmentMode)NativeCalls.godot_icall_0_39(MethodBind10, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTabsPosition, 256673370ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTabsPosition(TabContainer.TabPosition tabsPosition)
    {
        NativeCalls.godot_icall_1_38(MethodBind11, GodotObject.GetPtr(this), (int)tabsPosition);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTabsPosition, 919937023ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public TabContainer.TabPosition GetTabsPosition()
    {
        return (TabContainer.TabPosition)NativeCalls.godot_icall_0_39(MethodBind12, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetClipTabs, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetClipTabs(bool clipTabs)
    {
        NativeCalls.godot_icall_1_14(MethodBind13, GodotObject.GetPtr(this), clipTabs.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetClipTabs, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetClipTabs()
    {
        return NativeCalls.godot_icall_0_15(MethodBind14, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTabsVisible, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTabsVisible(bool visible)
    {
        NativeCalls.godot_icall_1_14(MethodBind15, GodotObject.GetPtr(this), visible.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AreTabsVisible, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool AreTabsVisible()
    {
        return NativeCalls.godot_icall_0_15(MethodBind16, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAllTabsInFront, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAllTabsInFront(bool isFront)
    {
        NativeCalls.godot_icall_1_14(MethodBind17, GodotObject.GetPtr(this), isFront.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsAllTabsInFront, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsAllTabsInFront()
    {
        return NativeCalls.godot_icall_0_15(MethodBind18, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTabTitle, 501894301ul);

    /// <summary>
    /// <para>Sets a custom title for the tab at index <paramref name="tabIdx"/> (tab titles default to the name of the indexed child node). Set it back to the child's name to make the tab default to it again.</para>
    /// </summary>
    public void SetTabTitle(int tabIdx, string title)
    {
        NativeCalls.godot_icall_2_181(MethodBind19, GodotObject.GetPtr(this), tabIdx, title);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTabTitle, 844755477ul);

    /// <summary>
    /// <para>Returns the title of the tab at index <paramref name="tabIdx"/>. Tab titles default to the name of the indexed child node, but this can be overridden with <see cref="Godot.TabContainer.SetTabTitle(int, string)"/>.</para>
    /// </summary>
    public string GetTabTitle(int tabIdx)
    {
        return NativeCalls.godot_icall_1_133(MethodBind20, GodotObject.GetPtr(this), tabIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTabTooltip, 501894301ul);

    /// <summary>
    /// <para>Sets a custom tooltip text for tab at index <paramref name="tabIdx"/>.</para>
    /// <para><b>Note:</b> By default, if the <paramref name="tooltip"/> is empty and the tab text is truncated (not all characters fit into the tab), the title will be displayed as a tooltip. To hide the tooltip, assign <c>" "</c> as the <paramref name="tooltip"/> text.</para>
    /// </summary>
    public void SetTabTooltip(int tabIdx, string tooltip)
    {
        NativeCalls.godot_icall_2_181(MethodBind21, GodotObject.GetPtr(this), tabIdx, tooltip);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTabTooltip, 844755477ul);

    /// <summary>
    /// <para>Returns the tooltip text of the tab at index <paramref name="tabIdx"/>.</para>
    /// </summary>
    public string GetTabTooltip(int tabIdx)
    {
        return NativeCalls.godot_icall_1_133(MethodBind22, GodotObject.GetPtr(this), tabIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTabIcon, 666127730ul);

    /// <summary>
    /// <para>Sets an icon for the tab at index <paramref name="tabIdx"/>.</para>
    /// </summary>
    public void SetTabIcon(int tabIdx, Texture2D icon)
    {
        NativeCalls.godot_icall_2_70(MethodBind23, GodotObject.GetPtr(this), tabIdx, GodotObject.GetPtr(icon));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTabIcon, 3536238170ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.Texture2D"/> for the tab at index <paramref name="tabIdx"/> or <see langword="null"/> if the tab has no <see cref="Godot.Texture2D"/>.</para>
    /// </summary>
    public Texture2D GetTabIcon(int tabIdx)
    {
        return (Texture2D)NativeCalls.godot_icall_1_71(MethodBind24, GodotObject.GetPtr(this), tabIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTabIconMaxWidth, 3937882851ul);

    /// <summary>
    /// <para>Sets the maximum allowed width of the icon for the tab at index <paramref name="tabIdx"/>. This limit is applied on top of the default size of the icon and on top of <c>icon_max_width</c>. The height is adjusted according to the icon's ratio.</para>
    /// </summary>
    public void SetTabIconMaxWidth(int tabIdx, int width)
    {
        NativeCalls.godot_icall_2_59(MethodBind25, GodotObject.GetPtr(this), tabIdx, width);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTabIconMaxWidth, 923996154ul);

    /// <summary>
    /// <para>Returns the maximum allowed width of the icon for the tab at index <paramref name="tabIdx"/>.</para>
    /// </summary>
    public int GetTabIconMaxWidth(int tabIdx)
    {
        return NativeCalls.godot_icall_1_60(MethodBind26, GodotObject.GetPtr(this), tabIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTabDisabled, 300928843ul);

    /// <summary>
    /// <para>If <paramref name="disabled"/> is <see langword="true"/>, disables the tab at index <paramref name="tabIdx"/>, making it non-interactable.</para>
    /// </summary>
    public void SetTabDisabled(int tabIdx, bool disabled)
    {
        NativeCalls.godot_icall_2_61(MethodBind27, GodotObject.GetPtr(this), tabIdx, disabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsTabDisabled, 1116898809ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the tab at index <paramref name="tabIdx"/> is disabled.</para>
    /// </summary>
    public bool IsTabDisabled(int tabIdx)
    {
        return NativeCalls.godot_icall_1_62(MethodBind28, GodotObject.GetPtr(this), tabIdx).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTabHidden, 300928843ul);

    /// <summary>
    /// <para>If <paramref name="hidden"/> is <see langword="true"/>, hides the tab at index <paramref name="tabIdx"/>, making it disappear from the tab area.</para>
    /// </summary>
    public void SetTabHidden(int tabIdx, bool hidden)
    {
        NativeCalls.godot_icall_2_61(MethodBind29, GodotObject.GetPtr(this), tabIdx, hidden.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsTabHidden, 1116898809ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the tab at index <paramref name="tabIdx"/> is hidden.</para>
    /// </summary>
    public bool IsTabHidden(int tabIdx)
    {
        return NativeCalls.godot_icall_1_62(MethodBind30, GodotObject.GetPtr(this), tabIdx).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTabMetadata, 2152698145ul);

    /// <summary>
    /// <para>Sets the metadata value for the tab at index <paramref name="tabIdx"/>, which can be retrieved later using <see cref="Godot.TabContainer.GetTabMetadata(int)"/>.</para>
    /// </summary>
    public void SetTabMetadata(int tabIdx, Variant metadata)
    {
        NativeCalls.godot_icall_2_701(MethodBind31, GodotObject.GetPtr(this), tabIdx, metadata);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind32 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTabMetadata, 4227898402ul);

    /// <summary>
    /// <para>Returns the metadata value set to the tab at index <paramref name="tabIdx"/> using <see cref="Godot.TabContainer.SetTabMetadata(int, Variant)"/>. If no metadata was previously set, returns <see langword="null"/> by default.</para>
    /// </summary>
    public Variant GetTabMetadata(int tabIdx)
    {
        return NativeCalls.godot_icall_1_702(MethodBind32, GodotObject.GetPtr(this), tabIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind33 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTabButtonIcon, 666127730ul);

    /// <summary>
    /// <para>Sets the button icon from the tab at index <paramref name="tabIdx"/>.</para>
    /// </summary>
    public void SetTabButtonIcon(int tabIdx, Texture2D icon)
    {
        NativeCalls.godot_icall_2_70(MethodBind33, GodotObject.GetPtr(this), tabIdx, GodotObject.GetPtr(icon));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind34 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTabButtonIcon, 3536238170ul);

    /// <summary>
    /// <para>Returns the button icon from the tab at index <paramref name="tabIdx"/>.</para>
    /// </summary>
    public Texture2D GetTabButtonIcon(int tabIdx)
    {
        return (Texture2D)NativeCalls.godot_icall_1_71(MethodBind34, GodotObject.GetPtr(this), tabIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind35 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTabIdxAtPoint, 3820158470ul);

    /// <summary>
    /// <para>Returns the index of the tab at local coordinates <paramref name="point"/>. Returns <c>-1</c> if the point is outside the control boundaries or if there's no tab at the queried position.</para>
    /// </summary>
    public unsafe int GetTabIdxAtPoint(Vector2 point)
    {
        return NativeCalls.godot_icall_1_340(MethodBind35, GodotObject.GetPtr(this), &point);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind36 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTabIdxFromControl, 2787397975ul);

    /// <summary>
    /// <para>Returns the index of the tab tied to the given <paramref name="control"/>. The control must be a child of the <see cref="Godot.TabContainer"/>.</para>
    /// </summary>
    public int GetTabIdxFromControl(Control control)
    {
        return NativeCalls.godot_icall_1_371(MethodBind36, GodotObject.GetPtr(this), GodotObject.GetPtr(control));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind37 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPopup, 1078189570ul);

    /// <summary>
    /// <para>If set on a <see cref="Godot.Popup"/> node instance, a popup menu icon appears in the top-right corner of the <see cref="Godot.TabContainer"/> (setting it to <see langword="null"/> will make it go away). Clicking it will expand the <see cref="Godot.Popup"/> node.</para>
    /// </summary>
    public void SetPopup(Node popup)
    {
        NativeCalls.godot_icall_1_56(MethodBind37, GodotObject.GetPtr(this), GodotObject.GetPtr(popup));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind38 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPopup, 111095082ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.Popup"/> node instance if one has been set already with <see cref="Godot.TabContainer.SetPopup(Node)"/>.</para>
    /// <para><b>Warning:</b> This is a required internal node, removing and freeing it may cause a crash. If you wish to hide it or any of its children, use their <see cref="Godot.Window.Visible"/> property.</para>
    /// </summary>
    public Popup GetPopup()
    {
        return (Popup)NativeCalls.godot_icall_0_53(MethodBind38, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind39 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSwitchOnDragHover, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSwitchOnDragHover(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind39, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind40 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSwitchOnDragHover, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetSwitchOnDragHover()
    {
        return NativeCalls.godot_icall_0_15(MethodBind40, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind41 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDragToRearrangeEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDragToRearrangeEnabled(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind41, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind42 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDragToRearrangeEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetDragToRearrangeEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind42, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind43 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTabsRearrangeGroup, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTabsRearrangeGroup(int groupId)
    {
        NativeCalls.godot_icall_1_38(MethodBind43, GodotObject.GetPtr(this), groupId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind44 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTabsRearrangeGroup, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetTabsRearrangeGroup()
    {
        return NativeCalls.godot_icall_0_39(MethodBind44, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind45 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetUseHiddenTabsForMinSize, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetUseHiddenTabsForMinSize(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind45, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind46 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetUseHiddenTabsForMinSize, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetUseHiddenTabsForMinSize()
    {
        return NativeCalls.godot_icall_0_15(MethodBind46, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind47 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTabFocusMode, 3232914922ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTabFocusMode(Control.FocusModeEnum focusMode)
    {
        NativeCalls.godot_icall_1_38(MethodBind47, GodotObject.GetPtr(this), (int)focusMode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind48 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTabFocusMode, 2132829277ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Control.FocusModeEnum GetTabFocusMode()
    {
        return (Control.FocusModeEnum)NativeCalls.godot_icall_0_39(MethodBind48, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind49 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDeselectEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDeselectEnabled(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind49, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind50 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDeselectEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetDeselectEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind50, GodotObject.GetPtr(this)).ToBool();
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.TabContainer.ActiveTabRearranged"/> event of a <see cref="Godot.TabContainer"/> class.
    /// </summary>
    public delegate void ActiveTabRearrangedEventHandler(long idxTo);

    private static void ActiveTabRearrangedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((ActiveTabRearrangedEventHandler)delegateObj)(VariantUtils.ConvertTo<long>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when the active tab is rearranged via mouse drag. See <see cref="Godot.TabContainer.DragToRearrangeEnabled"/>.</para>
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

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.TabContainer.TabChanged"/> event of a <see cref="Godot.TabContainer"/> class.
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
    /// Represents the method that handles the <see cref="Godot.TabContainer.TabClicked"/> event of a <see cref="Godot.TabContainer"/> class.
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
    /// Represents the method that handles the <see cref="Godot.TabContainer.TabHovered"/> event of a <see cref="Godot.TabContainer"/> class.
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
    /// Represents the method that handles the <see cref="Godot.TabContainer.TabSelected"/> event of a <see cref="Godot.TabContainer"/> class.
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
    /// Represents the method that handles the <see cref="Godot.TabContainer.TabButtonPressed"/> event of a <see cref="Godot.TabContainer"/> class.
    /// </summary>
    public delegate void TabButtonPressedEventHandler(long tab);

    private static void TabButtonPressedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((TabButtonPressedEventHandler)delegateObj)(VariantUtils.ConvertTo<long>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when the user clicks on the button icon on this tab.</para>
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
    /// <para>Emitted when the <see cref="Godot.TabContainer"/>'s <see cref="Godot.Popup"/> button is clicked. See <see cref="Godot.TabContainer.SetPopup(Node)"/> for details.</para>
    /// </summary>
    public event Action PrePopupPressed
    {
        add => Connect(SignalName.PrePopupPressed, Callable.From(value));
        remove => Disconnect(SignalName.PrePopupPressed, Callable.From(value));
    }

    protected void EmitSignalPrePopupPressed()
    {
        EmitSignal(SignalName.PrePopupPressed);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_active_tab_rearranged = "ActiveTabRearranged";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_tab_changed = "TabChanged";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_tab_clicked = "TabClicked";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_tab_hovered = "TabHovered";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_tab_selected = "TabSelected";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_tab_button_pressed = "TabButtonPressed";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_pre_popup_pressed = "PrePopupPressed";

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
        if (signal == SignalName.ActiveTabRearranged)
        {
            if (HasGodotClassSignal(SignalProxyName_active_tab_rearranged.NativeValue.DangerousSelfRef))
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
        if (signal == SignalName.TabHovered)
        {
            if (HasGodotClassSignal(SignalProxyName_tab_hovered.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.TabSelected)
        {
            if (HasGodotClassSignal(SignalProxyName_tab_selected.NativeValue.DangerousSelfRef))
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
        if (signal == SignalName.PrePopupPressed)
        {
            if (HasGodotClassSignal(SignalProxyName_pre_popup_pressed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        return base.HasGodotClassSignal(signal);
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : Container.PropertyName
    {
        /// <summary>
        /// Cached name for the 'tab_alignment' property.
        /// </summary>
        public static readonly StringName TabAlignment = "tab_alignment";
        /// <summary>
        /// Cached name for the 'current_tab' property.
        /// </summary>
        public static readonly StringName CurrentTab = "current_tab";
        /// <summary>
        /// Cached name for the 'tabs_position' property.
        /// </summary>
        public static readonly StringName TabsPosition = "tabs_position";
        /// <summary>
        /// Cached name for the 'clip_tabs' property.
        /// </summary>
        public static readonly StringName ClipTabs = "clip_tabs";
        /// <summary>
        /// Cached name for the 'tabs_visible' property.
        /// </summary>
        public static readonly StringName TabsVisible = "tabs_visible";
        /// <summary>
        /// Cached name for the 'all_tabs_in_front' property.
        /// </summary>
        public static readonly StringName AllTabsInFront = "all_tabs_in_front";
        /// <summary>
        /// Cached name for the 'switch_on_drag_hover' property.
        /// </summary>
        public static readonly StringName SwitchOnDragHover = "switch_on_drag_hover";
        /// <summary>
        /// Cached name for the 'drag_to_rearrange_enabled' property.
        /// </summary>
        public static readonly StringName DragToRearrangeEnabled = "drag_to_rearrange_enabled";
        /// <summary>
        /// Cached name for the 'tabs_rearrange_group' property.
        /// </summary>
        public static readonly StringName TabsRearrangeGroup = "tabs_rearrange_group";
        /// <summary>
        /// Cached name for the 'use_hidden_tabs_for_min_size' property.
        /// </summary>
        public static readonly StringName UseHiddenTabsForMinSize = "use_hidden_tabs_for_min_size";
        /// <summary>
        /// Cached name for the 'tab_focus_mode' property.
        /// </summary>
        public static readonly StringName TabFocusMode = "tab_focus_mode";
        /// <summary>
        /// Cached name for the 'deselect_enabled' property.
        /// </summary>
        public static readonly StringName DeselectEnabled = "deselect_enabled";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Container.MethodName
    {
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
        /// Cached name for the 'get_current_tab_control' method.
        /// </summary>
        public static readonly StringName GetCurrentTabControl = "get_current_tab_control";
        /// <summary>
        /// Cached name for the 'get_tab_bar' method.
        /// </summary>
        public static readonly StringName GetTabBar = "get_tab_bar";
        /// <summary>
        /// Cached name for the 'get_tab_control' method.
        /// </summary>
        public static readonly StringName GetTabControl = "get_tab_control";
        /// <summary>
        /// Cached name for the 'set_tab_alignment' method.
        /// </summary>
        public static readonly StringName SetTabAlignment = "set_tab_alignment";
        /// <summary>
        /// Cached name for the 'get_tab_alignment' method.
        /// </summary>
        public static readonly StringName GetTabAlignment = "get_tab_alignment";
        /// <summary>
        /// Cached name for the 'set_tabs_position' method.
        /// </summary>
        public static readonly StringName SetTabsPosition = "set_tabs_position";
        /// <summary>
        /// Cached name for the 'get_tabs_position' method.
        /// </summary>
        public static readonly StringName GetTabsPosition = "get_tabs_position";
        /// <summary>
        /// Cached name for the 'set_clip_tabs' method.
        /// </summary>
        public static readonly StringName SetClipTabs = "set_clip_tabs";
        /// <summary>
        /// Cached name for the 'get_clip_tabs' method.
        /// </summary>
        public static readonly StringName GetClipTabs = "get_clip_tabs";
        /// <summary>
        /// Cached name for the 'set_tabs_visible' method.
        /// </summary>
        public static readonly StringName SetTabsVisible = "set_tabs_visible";
        /// <summary>
        /// Cached name for the 'are_tabs_visible' method.
        /// </summary>
        public static readonly StringName AreTabsVisible = "are_tabs_visible";
        /// <summary>
        /// Cached name for the 'set_all_tabs_in_front' method.
        /// </summary>
        public static readonly StringName SetAllTabsInFront = "set_all_tabs_in_front";
        /// <summary>
        /// Cached name for the 'is_all_tabs_in_front' method.
        /// </summary>
        public static readonly StringName IsAllTabsInFront = "is_all_tabs_in_front";
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
        /// Cached name for the 'set_tab_button_icon' method.
        /// </summary>
        public static readonly StringName SetTabButtonIcon = "set_tab_button_icon";
        /// <summary>
        /// Cached name for the 'get_tab_button_icon' method.
        /// </summary>
        public static readonly StringName GetTabButtonIcon = "get_tab_button_icon";
        /// <summary>
        /// Cached name for the 'get_tab_idx_at_point' method.
        /// </summary>
        public static readonly StringName GetTabIdxAtPoint = "get_tab_idx_at_point";
        /// <summary>
        /// Cached name for the 'get_tab_idx_from_control' method.
        /// </summary>
        public static readonly StringName GetTabIdxFromControl = "get_tab_idx_from_control";
        /// <summary>
        /// Cached name for the 'set_popup' method.
        /// </summary>
        public static readonly StringName SetPopup = "set_popup";
        /// <summary>
        /// Cached name for the 'get_popup' method.
        /// </summary>
        public static readonly StringName GetPopup = "get_popup";
        /// <summary>
        /// Cached name for the 'set_switch_on_drag_hover' method.
        /// </summary>
        public static readonly StringName SetSwitchOnDragHover = "set_switch_on_drag_hover";
        /// <summary>
        /// Cached name for the 'get_switch_on_drag_hover' method.
        /// </summary>
        public static readonly StringName GetSwitchOnDragHover = "get_switch_on_drag_hover";
        /// <summary>
        /// Cached name for the 'set_drag_to_rearrange_enabled' method.
        /// </summary>
        public static readonly StringName SetDragToRearrangeEnabled = "set_drag_to_rearrange_enabled";
        /// <summary>
        /// Cached name for the 'get_drag_to_rearrange_enabled' method.
        /// </summary>
        public static readonly StringName GetDragToRearrangeEnabled = "get_drag_to_rearrange_enabled";
        /// <summary>
        /// Cached name for the 'set_tabs_rearrange_group' method.
        /// </summary>
        public static readonly StringName SetTabsRearrangeGroup = "set_tabs_rearrange_group";
        /// <summary>
        /// Cached name for the 'get_tabs_rearrange_group' method.
        /// </summary>
        public static readonly StringName GetTabsRearrangeGroup = "get_tabs_rearrange_group";
        /// <summary>
        /// Cached name for the 'set_use_hidden_tabs_for_min_size' method.
        /// </summary>
        public static readonly StringName SetUseHiddenTabsForMinSize = "set_use_hidden_tabs_for_min_size";
        /// <summary>
        /// Cached name for the 'get_use_hidden_tabs_for_min_size' method.
        /// </summary>
        public static readonly StringName GetUseHiddenTabsForMinSize = "get_use_hidden_tabs_for_min_size";
        /// <summary>
        /// Cached name for the 'set_tab_focus_mode' method.
        /// </summary>
        public static readonly StringName SetTabFocusMode = "set_tab_focus_mode";
        /// <summary>
        /// Cached name for the 'get_tab_focus_mode' method.
        /// </summary>
        public static readonly StringName GetTabFocusMode = "get_tab_focus_mode";
        /// <summary>
        /// Cached name for the 'set_deselect_enabled' method.
        /// </summary>
        public static readonly StringName SetDeselectEnabled = "set_deselect_enabled";
        /// <summary>
        /// Cached name for the 'get_deselect_enabled' method.
        /// </summary>
        public static readonly StringName GetDeselectEnabled = "get_deselect_enabled";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Container.SignalName
    {
        /// <summary>
        /// Cached name for the 'active_tab_rearranged' signal.
        /// </summary>
        public static readonly StringName ActiveTabRearranged = "active_tab_rearranged";
        /// <summary>
        /// Cached name for the 'tab_changed' signal.
        /// </summary>
        public static readonly StringName TabChanged = "tab_changed";
        /// <summary>
        /// Cached name for the 'tab_clicked' signal.
        /// </summary>
        public static readonly StringName TabClicked = "tab_clicked";
        /// <summary>
        /// Cached name for the 'tab_hovered' signal.
        /// </summary>
        public static readonly StringName TabHovered = "tab_hovered";
        /// <summary>
        /// Cached name for the 'tab_selected' signal.
        /// </summary>
        public static readonly StringName TabSelected = "tab_selected";
        /// <summary>
        /// Cached name for the 'tab_button_pressed' signal.
        /// </summary>
        public static readonly StringName TabButtonPressed = "tab_button_pressed";
        /// <summary>
        /// Cached name for the 'pre_popup_pressed' signal.
        /// </summary>
        public static readonly StringName PrePopupPressed = "pre_popup_pressed";
    }
}
