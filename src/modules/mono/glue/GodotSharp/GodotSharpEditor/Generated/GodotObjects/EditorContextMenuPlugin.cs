namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para><see cref="Godot.EditorContextMenuPlugin"/> allows for the addition of custom options in the editor's context menu.</para>
/// <para>Currently, context menus are supported for three commonly used areas: the file system, scene tree, and editor script list panel.</para>
/// </summary>
public partial class EditorContextMenuPlugin : RefCounted
{
    public enum ContextMenuSlot : long
    {
        /// <summary>
        /// <para>Context menu of Scene dock. <see cref="Godot.EditorContextMenuPlugin._PopupMenu(string[])"/> will be called with a list of paths to currently selected nodes, while option callback will receive the list of currently selected nodes.</para>
        /// </summary>
        SceneTree = 0,
        /// <summary>
        /// <para>Context menu of FileSystem dock. <see cref="Godot.EditorContextMenuPlugin._PopupMenu(string[])"/> and option callback will be called with list of paths of the currently selected files.</para>
        /// </summary>
        Filesystem = 1,
        /// <summary>
        /// <para>Context menu of Script editor's script tabs. <see cref="Godot.EditorContextMenuPlugin._PopupMenu(string[])"/> will be called with the path to the currently edited script, while option callback will receive reference to that script.</para>
        /// </summary>
        ScriptEditor = 2,
        /// <summary>
        /// <para>The "Create..." submenu of FileSystem dock's context menu, or the "New" section of the main context menu when empty space is clicked. <see cref="Godot.EditorContextMenuPlugin._PopupMenu(string[])"/> and option callback will be called with the path of the currently selected folder. When clicking the empty space, the list of paths for popup method will be empty.</para>
        /// <para><code>
        /// func _popup_menu(paths):
        ///     if paths.is_empty():
        ///         add_context_menu_item("New Image File...", create_image)
        ///     else:
        ///         add_context_menu_item("Image File...", create_image)
        /// </code></para>
        /// </summary>
        FilesystemCreate = 3,
        /// <summary>
        /// <para>Context menu of Script editor's code editor. <see cref="Godot.EditorContextMenuPlugin._PopupMenu(string[])"/> will be called with the path to the <see cref="Godot.CodeEdit"/> node. You can fetch it using this code:</para>
        /// <para><code>
        /// func _popup_menu(paths):
        /// 	var code_edit = Engine.get_main_loop().root.get_node(paths[0]);
        /// </code></para>
        /// <para>The option callback will receive reference to that node. You can use <see cref="Godot.CodeEdit"/> methods to perform symbol lookups etc.</para>
        /// </summary>
        ScriptEditorCode = 4,
        /// <summary>
        /// <para>Context menu of scene tabs. <see cref="Godot.EditorContextMenuPlugin._PopupMenu(string[])"/> will be called with the path of the clicked scene, or empty <see cref="string"/>[] if the menu was opened on empty space. The option callback will receive the path of the clicked scene, or empty <see cref="string"/> if none was clicked.</para>
        /// </summary>
        SceneTabs = 5,
        /// <summary>
        /// <para>Context menu of 2D editor's basic right-click menu. <see cref="Godot.EditorContextMenuPlugin._PopupMenu(string[])"/> will be called with paths to all <see cref="Godot.CanvasItem"/> nodes under the cursor. You can fetch them using this code:</para>
        /// <para><code>
        /// func _popup_menu(paths):
        /// 	var canvas_item = Engine.get_main_loop().root.get_node(paths[0]); # Replace 0 with the desired index.
        /// </code></para>
        /// <para>The paths array is empty if there weren't any nodes under cursor. The option callback will receive a typed array of <see cref="Godot.CanvasItem"/> nodes.</para>
        /// </summary>
        Slot2DEditor = 6
    }

    private static readonly System.Type CachedType = typeof(EditorContextMenuPlugin);

    private static readonly StringName NativeName = "EditorContextMenuPlugin";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public EditorContextMenuPlugin() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal EditorContextMenuPlugin(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal EditorContextMenuPlugin(bool memoryOwn) : base(memoryOwn) { }

    /// <summary>
    /// <para>Called when creating a context menu, custom options can be added by using the <see cref="Godot.EditorContextMenuPlugin.AddContextMenuItem(string, Callable, Texture2D)"/> or <see cref="Godot.EditorContextMenuPlugin.AddContextMenuItemFromShortcut(string, Shortcut, Texture2D)"/> functions. <paramref name="paths"/> contains currently selected paths (depending on menu), which can be used to conditionally add options.</para>
    /// </summary>
    public virtual void _PopupMenu(string[] paths)
    {
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddMenuShortcut, 851596305ul);

    /// <summary>
    /// <para>Registers a shortcut associated with the plugin's context menu. This method should be called once (e.g. in plugin's <see cref="Godot.GodotObject.GodotObject()"/>). <paramref name="callback"/> will be called when user presses the specified <paramref name="shortcut"/> while the menu's context is in effect (e.g. FileSystem dock is focused). Callback should take single <see cref="Godot.Collections.Array"/> argument; array contents depend on context menu slot.</para>
    /// <para><code>
    /// func _init():
    /// 	add_menu_shortcut(SHORTCUT, handle)
    /// </code></para>
    /// </summary>
    public void AddMenuShortcut(Shortcut shortcut, Callable callback)
    {
        EditorNativeCalls.godot_icall_2_466(MethodBind0, GodotObject.GetPtr(this), GodotObject.GetPtr(shortcut), callback);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddContextMenuItem, 2748336951ul);

    /// <summary>
    /// <para>Add custom option to the context menu of the plugin's specified slot. When the option is activated, <paramref name="callback"/> will be called. Callback should take single <see cref="Godot.Collections.Array"/> argument; array contents depend on context menu slot.</para>
    /// <para><code>
    /// func _popup_menu(paths):
    /// 	add_context_menu_item("File Custom options", handle, ICON)
    /// </code></para>
    /// <para>If you want to assign shortcut to the menu item, use <see cref="Godot.EditorContextMenuPlugin.AddContextMenuItemFromShortcut(string, Shortcut, Texture2D)"/> instead.</para>
    /// </summary>
    public void AddContextMenuItem(string name, Callable callback, Texture2D icon = null)
    {
        EditorNativeCalls.godot_icall_3_467(MethodBind1, GodotObject.GetPtr(this), name, callback, GodotObject.GetPtr(icon));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddContextMenuItemFromShortcut, 3799546916ul);

    /// <summary>
    /// <para>Add custom option to the context menu of the plugin's specified slot. The option will have the <paramref name="shortcut"/> assigned and reuse its callback. The shortcut has to be registered beforehand with <see cref="Godot.EditorContextMenuPlugin.AddMenuShortcut(Shortcut, Callable)"/>.</para>
    /// <para><code>
    /// func _init():
    /// 	add_menu_shortcut(SHORTCUT, handle)
    /// 
    /// func _popup_menu(paths):
    /// 	add_context_menu_item_from_shortcut("File Custom options", SHORTCUT, ICON)
    /// </code></para>
    /// </summary>
    public void AddContextMenuItemFromShortcut(string name, Shortcut shortcut, Texture2D icon = null)
    {
        EditorNativeCalls.godot_icall_3_468(MethodBind2, GodotObject.GetPtr(this), name, GodotObject.GetPtr(shortcut), GodotObject.GetPtr(icon));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddContextSubmenuItem, 1994674995ul);

    /// <summary>
    /// <para>Add a submenu to the context menu of the plugin's specified slot. The submenu is not automatically handled, you need to connect to its signals yourself. Also the submenu is freed on every popup, so provide a new <see cref="Godot.PopupMenu"/> every time.</para>
    /// <para><code>
    /// func _popup_menu(paths):
    /// 	var popup_menu = PopupMenu.new()
    /// 	popup_menu.add_item("Blue")
    /// 	popup_menu.add_item("White")
    /// 	popup_menu.id_pressed.connect(_on_color_submenu_option)
    /// 
    /// 	add_context_submenu_item("Set Node Color", popup_menu)
    /// </code></para>
    /// </summary>
    public void AddContextSubmenuItem(string name, PopupMenu menu, Texture2D icon = null)
    {
        EditorNativeCalls.godot_icall_3_468(MethodBind3, GodotObject.GetPtr(this), name, GodotObject.GetPtr(menu), GodotObject.GetPtr(icon));
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__popup_menu = "_PopupMenu";

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
        if ((method == MethodProxyName__popup_menu || method == MethodName._PopupMenu) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__popup_menu.NativeValue))
        {
            _PopupMenu(VariantUtils.ConvertTo<string[]>(args[0]));
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
        if (method == MethodName._PopupMenu)
        {
            if (HasGodotClassMethod(MethodProxyName__popup_menu.NativeValue.DangerousSelfRef))
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
        return base.HasGodotClassSignal(signal);
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : RefCounted.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : RefCounted.MethodName
    {
        /// <summary>
        /// Cached name for the '_popup_menu' method.
        /// </summary>
        public static readonly StringName _PopupMenu = "_popup_menu";
        /// <summary>
        /// Cached name for the 'add_menu_shortcut' method.
        /// </summary>
        public static readonly StringName AddMenuShortcut = "add_menu_shortcut";
        /// <summary>
        /// Cached name for the 'add_context_menu_item' method.
        /// </summary>
        public static readonly StringName AddContextMenuItem = "add_context_menu_item";
        /// <summary>
        /// Cached name for the 'add_context_menu_item_from_shortcut' method.
        /// </summary>
        public static readonly StringName AddContextMenuItemFromShortcut = "add_context_menu_item_from_shortcut";
        /// <summary>
        /// Cached name for the 'add_context_submenu_item' method.
        /// </summary>
        public static readonly StringName AddContextSubmenuItem = "add_context_submenu_item";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : RefCounted.SignalName
    {
    }
}
