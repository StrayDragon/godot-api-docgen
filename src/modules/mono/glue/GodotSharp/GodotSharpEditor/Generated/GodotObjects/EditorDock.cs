namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>EditorDock is a <see cref="Godot.Container"/> node that can be docked in one of the editor's dock slots. Docks are added by plugins to provide space for controls related to an <see cref="Godot.EditorPlugin"/>. The editor comes with a few built-in docks, such as the Scene dock, FileSystem dock, etc.</para>
/// <para>You can add a dock by using <see cref="Godot.EditorPlugin.AddDock(EditorDock)"/>. The dock can be customized by changing its properties.</para>
/// <para><code>
/// @tool
/// extends EditorPlugin
/// 
/// # Dock reference.
/// var dock
/// 
/// # Plugin initialization.
/// func _enter_tree():
/// 	dock = EditorDock.new()
/// 	dock.title = "My Dock"
/// 	dock.dock_icon = preload("./dock_icon.png")
/// 	dock.default_slot = EditorDock.DOCK_SLOT_RIGHT_UL
/// 	var dock_content = preload("./dock_content.tscn").instantiate()
/// 	dock.add_child(dock_content)
/// 	add_dock(dock)
/// 
/// # Plugin clean-up.
/// func _exit_tree():
/// 	remove_dock(dock)
/// 	dock.queue_free()
/// 	dock = null
/// </code></para>
/// </summary>
public partial class EditorDock : MarginContainer
{
    [System.Flags]
    public enum DockLayout : long
    {
        /// <summary>
        /// <para>Allows placing the dock in the vertical dock slots on either side of the editor.</para>
        /// </summary>
        Vertical = 1,
        /// <summary>
        /// <para>Allows placing the dock in the editor's bottom panel.</para>
        /// </summary>
        Horizontal = 2,
        /// <summary>
        /// <para>Allows making the dock floating (opened as a separate window).</para>
        /// </summary>
        Floating = 4,
        /// <summary>
        /// <para>Allows placing the dock in all available slots.</para>
        /// </summary>
        All = 7
    }

    public enum DockSlot : long
    {
        /// <summary>
        /// <para>The dock is closed.</para>
        /// </summary>
        None = -1,
        /// <summary>
        /// <para>Dock slot, left side, upper-left (empty in default layout).</para>
        /// </summary>
        LeftUl = 0,
        /// <summary>
        /// <para>Dock slot, left side, bottom-left (empty in default layout).</para>
        /// </summary>
        LeftBl = 1,
        /// <summary>
        /// <para>Dock slot, left side, upper-right (in default layout includes Scene and Import docks).</para>
        /// </summary>
        LeftUr = 2,
        /// <summary>
        /// <para>Dock slot, left side, bottom-right (in default layout includes FileSystem and History docks).</para>
        /// </summary>
        LeftBr = 3,
        /// <summary>
        /// <para>Dock slot, right side, upper-left (in default layout includes Inspector, Signal, and Group docks).</para>
        /// </summary>
        RightUl = 4,
        /// <summary>
        /// <para>Dock slot, right side, bottom-left (empty in default layout).</para>
        /// </summary>
        RightBl = 5,
        /// <summary>
        /// <para>Dock slot, right side, upper-right (empty in default layout).</para>
        /// </summary>
        RightUr = 6,
        /// <summary>
        /// <para>Dock slot, right side, bottom-right (empty in default layout).</para>
        /// </summary>
        RightBr = 7,
        /// <summary>
        /// <para>Bottom panel.</para>
        /// </summary>
        Bottom = 8,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.EditorDock.DockSlot"/> enum.</para>
        /// </summary>
        Max = 9
    }

    /// <summary>
    /// <para>The title of the dock's tab. If empty, the dock's <see cref="Godot.Node.Name"/> will be used. If the name is auto-generated (contains <c>@</c>), the first child's name will be used instead.</para>
    /// </summary>
    public string Title
    {
        get
        {
            return GetTitle();
        }
        set
        {
            SetTitle(value);
        }
    }

    /// <summary>
    /// <para>The key representing this dock in the editor's layout file. If empty, the dock's displayed name will be used instead.</para>
    /// </summary>
    public string LayoutKey
    {
        get
        {
            return GetLayoutKey();
        }
        set
        {
            SetLayoutKey(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the dock appears in the <b>Editor &gt; Editor Docks</b> menu and can be closed. Non-global docks can still be closed using <see cref="Godot.EditorDock.Close()"/> or when <see cref="Godot.EditorDock.Closable"/> is <see langword="true"/>.</para>
    /// </summary>
    public bool Global
    {
        get
        {
            return IsGlobal();
        }
        set
        {
            SetGlobal(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the dock is not automatically opened or closed when loading an editor layout, only moved. It also can't be opened using a shortcut. This is meant for docks that are opened and closed in specific cases, such as when selecting a <see cref="Godot.TileMap"/> or <see cref="Godot.AnimationTree"/> node.</para>
    /// </summary>
    public bool Transient
    {
        get
        {
            return IsTransient();
        }
        set
        {
            SetTransient(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the dock can be closed with the Close button in the context popup. Docks with <see cref="Godot.EditorDock.Global"/> enabled are always closable.</para>
    /// </summary>
    public bool Closable
    {
        get
        {
            return IsClosable();
        }
        set
        {
            SetClosable(value);
        }
    }

    /// <summary>
    /// <para>The icon for the dock, as a name from the <c>EditorIcons</c> theme type in the editor theme. You can find the list of available icons <a href="https://godot-editor-icons.github.io/">here</a>.</para>
    /// </summary>
    public StringName IconName
    {
        get
        {
            return GetIconName();
        }
        set
        {
            SetIconName(value);
        }
    }

    /// <summary>
    /// <para>The icon for the dock, as a texture. If specified, it will override <see cref="Godot.EditorDock.IconName"/>.</para>
    /// </summary>
    public Texture2D DockIcon
    {
        get
        {
            return GetDockIcon();
        }
        set
        {
            SetDockIcon(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the dock will always display an icon, regardless of <c>EditorSettings.interface/editor/dock_tab_style</c> or <c>EditorSettings.interface/editor/bottom_dock_tab_style</c>.</para>
    /// </summary>
    public bool ForceShowIcon
    {
        get
        {
            return GetForceShowIcon();
        }
        set
        {
            SetForceShowIcon(value);
        }
    }

    /// <summary>
    /// <para>The color of the dock tab's title. If its alpha is <c>0.0</c>, the default font color will be used.</para>
    /// </summary>
    public Color TitleColor
    {
        get
        {
            return GetTitleColor();
        }
        set
        {
            SetTitleColor(value);
        }
    }

    /// <summary>
    /// <para>The shortcut used to open the dock.</para>
    /// </summary>
    public Shortcut DockShortcut
    {
        get
        {
            return GetDockShortcut();
        }
        set
        {
            SetDockShortcut(value);
        }
    }

    /// <summary>
    /// <para>The default dock slot used when adding the dock with <see cref="Godot.EditorPlugin.AddDock(EditorDock)"/>.</para>
    /// <para>After the dock is added, it can be moved to a different slot and the editor will automatically remember its position between sessions. If you remove and re-add the dock, it will be reset to default.</para>
    /// </summary>
    public EditorDock.DockSlot DefaultSlot
    {
        get
        {
            return GetDefaultSlot();
        }
        set
        {
            SetDefaultSlot(value);
        }
    }

    /// <summary>
    /// <para>The available layouts for this dock, as a bitmask. By default, the dock allows vertical and floating layouts.</para>
    /// </summary>
    public EditorDock.DockLayout AvailableLayouts
    {
        get
        {
            return GetAvailableLayouts();
        }
        set
        {
            SetAvailableLayouts(value);
        }
    }

    private static readonly System.Type CachedType = typeof(EditorDock);

    private static readonly StringName NativeName = "EditorDock";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public EditorDock() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal EditorDock(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal EditorDock(bool memoryOwn) : base(memoryOwn) { }

    /// <summary>
    /// <para>Implement this method to handle loading this dock's layout. It's equivalent to <see cref="Godot.EditorPlugin._SetWindowLayout(ConfigFile)"/>. <paramref name="section"/> is a unique section based on <see cref="Godot.EditorDock.LayoutKey"/>.</para>
    /// </summary>
    public virtual void _LoadLayoutFromConfig(ConfigFile config, string section)
    {
    }

    /// <summary>
    /// <para>Implement this method to handle saving this dock's layout. It's equivalent to <see cref="Godot.EditorPlugin._GetWindowLayout(ConfigFile)"/>. <paramref name="section"/> is a unique section based on <see cref="Godot.EditorDock.LayoutKey"/>.</para>
    /// </summary>
    public virtual void _SaveLayoutToConfig(ConfigFile config, string section)
    {
    }

    /// <summary>
    /// <para>Implement this method to handle the layout switching for this dock. <paramref name="layout"/> is one of the <see cref="Godot.EditorDock.DockLayout"/> constants.</para>
    /// <para><code>
    /// func _update_layout(layout):
    /// 	box_container.vertical = (layout == DOCK_LAYOUT_VERTICAL)
    /// </code></para>
    /// </summary>
    public virtual void _UpdateLayout(int layout)
    {
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Open, 3218959716ul);

    /// <summary>
    /// <para>Opens the dock. It will appear in the last used dock slot. If the dock has no default slot, it will be opened floating.</para>
    /// <para><b>Note:</b> This does not focus the dock. If you want to open and focus the dock, use <see cref="Godot.EditorDock.MakeVisible()"/>.</para>
    /// </summary>
    public void Open()
    {
        NativeCalls.godot_icall_0_3(MethodBind0, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MakeVisible, 3218959716ul);

    /// <summary>
    /// <para>Focuses the dock's tab (or window if it's floating). If the dock was closed, it will be opened. If it's a bottom dock, makes the bottom panel visible.</para>
    /// </summary>
    public void MakeVisible()
    {
        NativeCalls.godot_icall_0_3(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Close, 3218959716ul);

    /// <summary>
    /// <para>Closes the dock, making its tab hidden.</para>
    /// </summary>
    public void Close()
    {
        NativeCalls.godot_icall_0_3(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTitle, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTitle(string title)
    {
        NativeCalls.godot_icall_1_57(MethodBind3, GodotObject.GetPtr(this), title);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTitle, 201670096ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetTitle()
    {
        return NativeCalls.godot_icall_0_58(MethodBind4, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLayoutKey, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetLayoutKey(string layoutKey)
    {
        NativeCalls.godot_icall_1_57(MethodBind5, GodotObject.GetPtr(this), layoutKey);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLayoutKey, 201670096ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetLayoutKey()
    {
        return NativeCalls.godot_icall_0_58(MethodBind6, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetGlobal, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetGlobal(bool global)
    {
        NativeCalls.godot_icall_1_14(MethodBind7, GodotObject.GetPtr(this), global.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsGlobal, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsGlobal()
    {
        return NativeCalls.godot_icall_0_15(MethodBind8, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTransient, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTransient(bool transient)
    {
        NativeCalls.godot_icall_1_14(MethodBind9, GodotObject.GetPtr(this), transient.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsTransient, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsTransient()
    {
        return NativeCalls.godot_icall_0_15(MethodBind10, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetClosable, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetClosable(bool closable)
    {
        NativeCalls.godot_icall_1_14(MethodBind11, GodotObject.GetPtr(this), closable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsClosable, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsClosable()
    {
        return NativeCalls.godot_icall_0_15(MethodBind12, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetIconName, 3304788590ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetIconName(StringName iconName)
    {
        NativeCalls.godot_icall_1_64(MethodBind13, GodotObject.GetPtr(this), (godot_string_name)(iconName?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetIconName, 2002593661ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public StringName GetIconName()
    {
        return NativeCalls.godot_icall_0_65(MethodBind14, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDockIcon, 4051416890ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDockIcon(Texture2D icon)
    {
        NativeCalls.godot_icall_1_56(MethodBind15, GodotObject.GetPtr(this), GodotObject.GetPtr(icon));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDockIcon, 3635182373ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Texture2D GetDockIcon()
    {
        return (Texture2D)NativeCalls.godot_icall_0_63(MethodBind16, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetForceShowIcon, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetForceShowIcon(bool force)
    {
        NativeCalls.godot_icall_1_14(MethodBind17, GodotObject.GetPtr(this), force.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetForceShowIcon, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetForceShowIcon()
    {
        return NativeCalls.godot_icall_0_15(MethodBind18, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTitleColor, 2920490490ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetTitleColor(Color color)
    {
        NativeCalls.godot_icall_1_213(MethodBind19, GodotObject.GetPtr(this), &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTitleColor, 3444240500ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Color GetTitleColor()
    {
        return NativeCalls.godot_icall_0_214(MethodBind20, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDockShortcut, 857163497ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDockShortcut(Shortcut shortcut)
    {
        NativeCalls.godot_icall_1_56(MethodBind21, GodotObject.GetPtr(this), GodotObject.GetPtr(shortcut));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDockShortcut, 3415666916ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Shortcut GetDockShortcut()
    {
        return (Shortcut)NativeCalls.godot_icall_0_63(MethodBind22, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDefaultSlot, 4142995464ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDefaultSlot(EditorDock.DockSlot slot)
    {
        NativeCalls.godot_icall_1_38(MethodBind23, GodotObject.GetPtr(this), (int)slot);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDefaultSlot, 3298961740ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public EditorDock.DockSlot GetDefaultSlot()
    {
        return (EditorDock.DockSlot)NativeCalls.godot_icall_0_39(MethodBind24, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAvailableLayouts, 3440531249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAvailableLayouts(EditorDock.DockLayout layouts)
    {
        NativeCalls.godot_icall_1_38(MethodBind25, GodotObject.GetPtr(this), (int)layouts);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAvailableLayouts, 495015512ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public EditorDock.DockLayout GetAvailableLayouts()
    {
        return (EditorDock.DockLayout)NativeCalls.godot_icall_0_39(MethodBind26, GodotObject.GetPtr(this));
    }

    /// <summary>
    /// <para>Emitted when the dock is closed with the Close button in the context popup, before it's removed from its parent. See <see cref="Godot.EditorDock.Closable"/>.</para>
    /// </summary>
    public event Action Closed
    {
        add => Connect(SignalName.Closed, Callable.From(value));
        remove => Disconnect(SignalName.Closed, Callable.From(value));
    }

    protected void EmitSignalClosed()
    {
        EmitSignal(SignalName.Closed);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__load_layout_from_config = "_LoadLayoutFromConfig";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__save_layout_to_config = "_SaveLayoutToConfig";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__update_layout = "_UpdateLayout";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_closed = "Closed";

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
        if ((method == MethodProxyName__load_layout_from_config || method == MethodName._LoadLayoutFromConfig) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__load_layout_from_config.NativeValue))
        {
            _LoadLayoutFromConfig(VariantUtils.ConvertTo<ConfigFile>(args[0]), VariantUtils.ConvertTo<string>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__save_layout_to_config || method == MethodName._SaveLayoutToConfig) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__save_layout_to_config.NativeValue))
        {
            _SaveLayoutToConfig(VariantUtils.ConvertTo<ConfigFile>(args[0]), VariantUtils.ConvertTo<string>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__update_layout || method == MethodName._UpdateLayout) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__update_layout.NativeValue))
        {
            _UpdateLayout(VariantUtils.ConvertTo<int>(args[0]));
            ret = default;
            return true;
        }
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
        if (method == MethodName._LoadLayoutFromConfig)
        {
            if (HasGodotClassMethod(MethodProxyName__load_layout_from_config.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._SaveLayoutToConfig)
        {
            if (HasGodotClassMethod(MethodProxyName__save_layout_to_config.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._UpdateLayout)
        {
            if (HasGodotClassMethod(MethodProxyName__update_layout.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
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
        if (signal == SignalName.Closed)
        {
            if (HasGodotClassSignal(SignalProxyName_closed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        return base.HasGodotClassSignal(signal);
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : MarginContainer.PropertyName
    {
        /// <summary>
        /// Cached name for the 'title' property.
        /// </summary>
        public static readonly StringName Title = "title";
        /// <summary>
        /// Cached name for the 'layout_key' property.
        /// </summary>
        public static readonly StringName LayoutKey = "layout_key";
        /// <summary>
        /// Cached name for the 'global' property.
        /// </summary>
        public static readonly StringName Global = "global";
        /// <summary>
        /// Cached name for the 'transient' property.
        /// </summary>
        public static readonly StringName Transient = "transient";
        /// <summary>
        /// Cached name for the 'closable' property.
        /// </summary>
        public static readonly StringName Closable = "closable";
        /// <summary>
        /// Cached name for the 'icon_name' property.
        /// </summary>
        public static readonly StringName IconName = "icon_name";
        /// <summary>
        /// Cached name for the 'dock_icon' property.
        /// </summary>
        public static readonly StringName DockIcon = "dock_icon";
        /// <summary>
        /// Cached name for the 'force_show_icon' property.
        /// </summary>
        public static readonly StringName ForceShowIcon = "force_show_icon";
        /// <summary>
        /// Cached name for the 'title_color' property.
        /// </summary>
        public static readonly StringName TitleColor = "title_color";
        /// <summary>
        /// Cached name for the 'dock_shortcut' property.
        /// </summary>
        public static readonly StringName DockShortcut = "dock_shortcut";
        /// <summary>
        /// Cached name for the 'default_slot' property.
        /// </summary>
        public static readonly StringName DefaultSlot = "default_slot";
        /// <summary>
        /// Cached name for the 'available_layouts' property.
        /// </summary>
        public static readonly StringName AvailableLayouts = "available_layouts";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : MarginContainer.MethodName
    {
        /// <summary>
        /// Cached name for the '_load_layout_from_config' method.
        /// </summary>
        public static readonly StringName _LoadLayoutFromConfig = "_load_layout_from_config";
        /// <summary>
        /// Cached name for the '_save_layout_to_config' method.
        /// </summary>
        public static readonly StringName _SaveLayoutToConfig = "_save_layout_to_config";
        /// <summary>
        /// Cached name for the '_update_layout' method.
        /// </summary>
        public static readonly StringName _UpdateLayout = "_update_layout";
        /// <summary>
        /// Cached name for the 'open' method.
        /// </summary>
        public static readonly StringName Open = "open";
        /// <summary>
        /// Cached name for the 'make_visible' method.
        /// </summary>
        public static readonly StringName MakeVisible = "make_visible";
        /// <summary>
        /// Cached name for the 'close' method.
        /// </summary>
        public static readonly StringName Close = "close";
        /// <summary>
        /// Cached name for the 'set_title' method.
        /// </summary>
        public static readonly StringName SetTitle = "set_title";
        /// <summary>
        /// Cached name for the 'get_title' method.
        /// </summary>
        public static readonly StringName GetTitle = "get_title";
        /// <summary>
        /// Cached name for the 'set_layout_key' method.
        /// </summary>
        public static readonly StringName SetLayoutKey = "set_layout_key";
        /// <summary>
        /// Cached name for the 'get_layout_key' method.
        /// </summary>
        public static readonly StringName GetLayoutKey = "get_layout_key";
        /// <summary>
        /// Cached name for the 'set_global' method.
        /// </summary>
        public static readonly StringName SetGlobal = "set_global";
        /// <summary>
        /// Cached name for the 'is_global' method.
        /// </summary>
        public static readonly StringName IsGlobal = "is_global";
        /// <summary>
        /// Cached name for the 'set_transient' method.
        /// </summary>
        public static readonly StringName SetTransient = "set_transient";
        /// <summary>
        /// Cached name for the 'is_transient' method.
        /// </summary>
        public static readonly StringName IsTransient = "is_transient";
        /// <summary>
        /// Cached name for the 'set_closable' method.
        /// </summary>
        public static readonly StringName SetClosable = "set_closable";
        /// <summary>
        /// Cached name for the 'is_closable' method.
        /// </summary>
        public static readonly StringName IsClosable = "is_closable";
        /// <summary>
        /// Cached name for the 'set_icon_name' method.
        /// </summary>
        public static readonly StringName SetIconName = "set_icon_name";
        /// <summary>
        /// Cached name for the 'get_icon_name' method.
        /// </summary>
        public static readonly StringName GetIconName = "get_icon_name";
        /// <summary>
        /// Cached name for the 'set_dock_icon' method.
        /// </summary>
        public static readonly StringName SetDockIcon = "set_dock_icon";
        /// <summary>
        /// Cached name for the 'get_dock_icon' method.
        /// </summary>
        public static readonly StringName GetDockIcon = "get_dock_icon";
        /// <summary>
        /// Cached name for the 'set_force_show_icon' method.
        /// </summary>
        public static readonly StringName SetForceShowIcon = "set_force_show_icon";
        /// <summary>
        /// Cached name for the 'get_force_show_icon' method.
        /// </summary>
        public static readonly StringName GetForceShowIcon = "get_force_show_icon";
        /// <summary>
        /// Cached name for the 'set_title_color' method.
        /// </summary>
        public static readonly StringName SetTitleColor = "set_title_color";
        /// <summary>
        /// Cached name for the 'get_title_color' method.
        /// </summary>
        public static readonly StringName GetTitleColor = "get_title_color";
        /// <summary>
        /// Cached name for the 'set_dock_shortcut' method.
        /// </summary>
        public static readonly StringName SetDockShortcut = "set_dock_shortcut";
        /// <summary>
        /// Cached name for the 'get_dock_shortcut' method.
        /// </summary>
        public static readonly StringName GetDockShortcut = "get_dock_shortcut";
        /// <summary>
        /// Cached name for the 'set_default_slot' method.
        /// </summary>
        public static readonly StringName SetDefaultSlot = "set_default_slot";
        /// <summary>
        /// Cached name for the 'get_default_slot' method.
        /// </summary>
        public static readonly StringName GetDefaultSlot = "get_default_slot";
        /// <summary>
        /// Cached name for the 'set_available_layouts' method.
        /// </summary>
        public static readonly StringName SetAvailableLayouts = "set_available_layouts";
        /// <summary>
        /// Cached name for the 'get_available_layouts' method.
        /// </summary>
        public static readonly StringName GetAvailableLayouts = "get_available_layouts";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : MarginContainer.SignalName
    {
        /// <summary>
        /// Cached name for the 'closed' signal.
        /// </summary>
        public static readonly StringName Closed = "closed";
    }
}
