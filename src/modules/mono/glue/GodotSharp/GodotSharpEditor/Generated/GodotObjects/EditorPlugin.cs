namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Plugins are used by the editor to extend functionality. The most common types of plugins are those which edit a given node or resource type, import plugins and export plugins. See also <see cref="Godot.EditorScript"/> to add functions to the editor.</para>
/// <para><b>Note:</b> Some names in this class contain "left" or "right" (e.g. <see cref="Godot.EditorPlugin.DockSlot.LeftUl"/>). These APIs assume left-to-right layout, and would be backwards when using right-to-left layout. These names are kept for compatibility reasons.</para>
/// </summary>
public partial class EditorPlugin : Node
{
    public enum CustomControlContainer : long
    {
        /// <summary>
        /// <para>Main editor toolbar, next to play buttons.</para>
        /// </summary>
        Toolbar = 0,
        /// <summary>
        /// <para>The toolbar that appears when 3D editor is active.</para>
        /// </summary>
        SpatialEditorMenu = 1,
        /// <summary>
        /// <para>Left sidebar of the 3D editor.</para>
        /// </summary>
        SpatialEditorSideLeft = 2,
        /// <summary>
        /// <para>Right sidebar of the 3D editor.</para>
        /// </summary>
        SpatialEditorSideRight = 3,
        /// <summary>
        /// <para>Bottom panel of the 3D editor.</para>
        /// </summary>
        SpatialEditorBottom = 4,
        /// <summary>
        /// <para>The toolbar that appears when 2D editor is active.</para>
        /// </summary>
        CanvasEditorMenu = 5,
        /// <summary>
        /// <para>Left sidebar of the 2D editor.</para>
        /// </summary>
        CanvasEditorSideLeft = 6,
        /// <summary>
        /// <para>Right sidebar of the 2D editor.</para>
        /// </summary>
        CanvasEditorSideRight = 7,
        /// <summary>
        /// <para>Bottom panel of the 2D editor.</para>
        /// </summary>
        CanvasEditorBottom = 8,
        /// <summary>
        /// <para>Bottom section of the inspector.</para>
        /// </summary>
        InspectorBottom = 9,
        /// <summary>
        /// <para>Tab of Project Settings dialog, to the left of other tabs.</para>
        /// </summary>
        ProjectSettingTabLeft = 10,
        /// <summary>
        /// <para>Tab of Project Settings dialog, to the right of other tabs.</para>
        /// </summary>
        ProjectSettingTabRight = 11
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
        /// <para>Dock slot, left side, bottom-right (in default layout includes FileSystem dock).</para>
        /// </summary>
        LeftBr = 3,
        /// <summary>
        /// <para>Dock slot, right side, upper-left (in default layout includes Inspector, Node, and History docks).</para>
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
        /// <para>Represents the size of the <see cref="Godot.EditorPlugin.DockSlot"/> enum.</para>
        /// </summary>
        Max = 9
    }

    public enum AfterGuiInput : long
    {
        /// <summary>
        /// <para>Forwards the <see cref="Godot.InputEvent"/> to other EditorPlugins.</para>
        /// </summary>
        Pass = 0,
        /// <summary>
        /// <para>Prevents the <see cref="Godot.InputEvent"/> from reaching other Editor classes.</para>
        /// </summary>
        Stop = 1,
        /// <summary>
        /// <para>Pass the <see cref="Godot.InputEvent"/> to other editor plugins except the main <see cref="Godot.Node3D"/> one. This can be used to prevent node selection changes and work with sub-gizmos instead.</para>
        /// </summary>
        Custom = 2
    }

    private static readonly System.Type CachedType = typeof(EditorPlugin);

    private static readonly StringName NativeName = "EditorPlugin";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public EditorPlugin() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal EditorPlugin(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal EditorPlugin(bool memoryOwn) : base(memoryOwn) { }

    /// <summary>
    /// <para>This method is called when the editor is about to save the project, switch to another tab, etc. It asks the plugin to apply any pending state changes to ensure consistency.</para>
    /// <para>This is used, for example, in shader editors to let the plugin know that it must apply the shader code being written by the user to the object.</para>
    /// </summary>
    public virtual void _ApplyChanges()
    {
    }

    /// <summary>
    /// <para>This method is called when the editor is about to run the project. The plugin can then perform required operations before the project runs.</para>
    /// <para>This method must return a boolean. If this method returns <see langword="false"/>, the project will not run. The run is aborted immediately, so this also prevents all other plugins' <see cref="Godot.EditorPlugin._Build()"/> methods from running.</para>
    /// </summary>
    public virtual bool _Build()
    {
        return default;
    }

    /// <summary>
    /// <para>Clear all the state and reset the object being edited to zero. This ensures your plugin does not keep editing a currently existing node, or a node from the wrong scene.</para>
    /// </summary>
    public virtual void _Clear()
    {
    }

    /// <summary>
    /// <para>Called by the engine when the user disables the <see cref="Godot.EditorPlugin"/> in the Plugin tab of the project settings window.</para>
    /// </summary>
    public virtual void _DisablePlugin()
    {
    }

    /// <summary>
    /// <para>This function is used for plugins that edit specific object types (nodes or resources). It requests the editor to edit the given object.</para>
    /// <para><paramref name="object"/> can be <see langword="null"/> if the plugin was editing an object, but there is no longer any selected object handled by this plugin. It can be used to cleanup editing state.</para>
    /// </summary>
    public virtual void _Edit(GodotObject @object)
    {
    }

    /// <summary>
    /// <para>Called by the engine when the user enables the <see cref="Godot.EditorPlugin"/> in the Plugin tab of the project settings window.</para>
    /// </summary>
    public virtual void _EnablePlugin()
    {
    }

    /// <summary>
    /// <para>Called by the engine when the 3D editor's viewport is updated. <paramref name="viewportControl"/> is an overlay on top of the viewport and it can be used for drawing. You can update the viewport manually by calling <see cref="Godot.EditorPlugin.UpdateOverlays()"/>.</para>
    /// <para><code>
    /// public override void _Forward3DDrawOverViewport(Control viewportControl)
    /// {
    /// 	// Draw a circle at the cursor's position.
    /// 	viewportControl.DrawCircle(viewportControl.GetLocalMousePosition(), 64, Colors.White);
    /// }
    /// 
    /// public override EditorPlugin.AfterGuiInput _Forward3DGuiInput(Camera3D viewportCamera, InputEvent @event)
    /// {
    /// 	if (@event is InputEventMouseMotion)
    /// 	{
    /// 		// Redraw the viewport when the cursor is moved.
    /// 		UpdateOverlays();
    /// 		return EditorPlugin.AfterGuiInput.Stop;
    /// 	}
    /// 	return EditorPlugin.AfterGuiInput.Pass;
    /// }
    /// </code></para>
    /// </summary>
    public virtual void _Forward3DDrawOverViewport(Control viewportControl)
    {
    }

    /// <summary>
    /// <para>This method is the same as <see cref="Godot.EditorPlugin._Forward3DDrawOverViewport(Control)"/>, except it draws on top of everything. Useful when you need an extra layer that shows over anything else.</para>
    /// <para>You need to enable calling of this method by using <see cref="Godot.EditorPlugin.SetForceDrawOverForwardingEnabled()"/>.</para>
    /// </summary>
    public virtual void _Forward3DForceDrawOverViewport(Control viewportControl)
    {
    }

    /// <summary>
    /// <para>Called when there is a root node in the current edited scene, <see cref="Godot.EditorPlugin._Handles(GodotObject)"/> is implemented, and an <see cref="Godot.InputEvent"/> happens in the 3D viewport. The return value decides whether the <see cref="Godot.InputEvent"/> is consumed or forwarded to other <see cref="Godot.EditorPlugin"/>s. See <see cref="Godot.EditorPlugin.AfterGuiInput"/> for options.</para>
    /// <para><code>
    /// // Prevents the InputEvent from reaching other Editor classes.
    /// public override EditorPlugin.AfterGuiInput _Forward3DGuiInput(Camera3D camera, InputEvent @event)
    /// {
    /// 	return EditorPlugin.AfterGuiInput.Stop;
    /// }
    /// </code></para>
    /// <para>This method must return <see cref="Godot.EditorPlugin.AfterGuiInput.Pass"/> in order to forward the <see cref="Godot.InputEvent"/> to other Editor classes.</para>
    /// <para><code>
    /// // Consumes InputEventMouseMotion and forwards other InputEvent types.
    /// public override EditorPlugin.AfterGuiInput _Forward3DGuiInput(Camera3D camera, InputEvent @event)
    /// {
    /// 	return @event is InputEventMouseMotion ? EditorPlugin.AfterGuiInput.Stop : EditorPlugin.AfterGuiInput.Pass;
    /// }
    /// </code></para>
    /// </summary>
    public virtual int _Forward3DGuiInput(Camera3D viewportCamera, InputEvent @event)
    {
        return default;
    }

    /// <summary>
    /// <para>Called by the engine when the 2D editor's viewport is updated. <paramref name="viewportControl"/> is an overlay on top of the viewport and it can be used for drawing. You can update the viewport manually by calling <see cref="Godot.EditorPlugin.UpdateOverlays()"/>.</para>
    /// <para><code>
    /// public override void _ForwardCanvasDrawOverViewport(Control viewportControl)
    /// {
    /// 	// Draw a circle at the cursor's position.
    /// 	viewportControl.DrawCircle(viewportControl.GetLocalMousePosition(), 64, Colors.White);
    /// }
    /// 
    /// public override bool _ForwardCanvasGuiInput(InputEvent @event)
    /// {
    /// 	if (@event is InputEventMouseMotion)
    /// 	{
    /// 		// Redraw the viewport when the cursor is moved.
    /// 		UpdateOverlays();
    /// 		return true;
    /// 	}
    /// 	return false;
    /// }
    /// </code></para>
    /// </summary>
    public virtual void _ForwardCanvasDrawOverViewport(Control viewportControl)
    {
    }

    /// <summary>
    /// <para>This method is the same as <see cref="Godot.EditorPlugin._ForwardCanvasDrawOverViewport(Control)"/>, except it draws on top of everything. Useful when you need an extra layer that shows over anything else.</para>
    /// <para>You need to enable calling of this method by using <see cref="Godot.EditorPlugin.SetForceDrawOverForwardingEnabled()"/>.</para>
    /// </summary>
    public virtual void _ForwardCanvasForceDrawOverViewport(Control viewportControl)
    {
    }

    /// <summary>
    /// <para>Called when there is a root node in the current edited scene, <see cref="Godot.EditorPlugin._Handles(GodotObject)"/> is implemented, and an <see cref="Godot.InputEvent"/> happens in the 2D viewport. If this method returns <see langword="true"/>, <paramref name="event"/> is intercepted by this <see cref="Godot.EditorPlugin"/>, otherwise <paramref name="event"/> is forwarded to other Editor classes.</para>
    /// <para><code>
    /// // Prevents the InputEvent from reaching other Editor classes.
    /// public override bool ForwardCanvasGuiInput(InputEvent @event)
    /// {
    /// 	return true;
    /// }
    /// </code></para>
    /// <para>This method must return <see langword="false"/> in order to forward the <see cref="Godot.InputEvent"/> to other Editor classes.</para>
    /// <para><code>
    /// // Consumes InputEventMouseMotion and forwards other InputEvent types.
    /// public override bool _ForwardCanvasGuiInput(InputEvent @event)
    /// {
    /// 	if (@event is InputEventMouseMotion)
    /// 	{
    /// 		return true;
    /// 	}
    /// 	return false;
    /// }
    /// </code></para>
    /// </summary>
    public virtual bool _ForwardCanvasGuiInput(InputEvent @event)
    {
        return default;
    }

    /// <summary>
    /// <para>This is for editors that edit script-based objects. You can return a list of breakpoints in the format (<c>script:line</c>), for example: <c>res://path_to_script.gd:25</c>.</para>
    /// </summary>
    public virtual string[] _GetBreakpoints()
    {
        return default;
    }

    /// <summary>
    /// <para>Override this method in your plugin to return a <see cref="Godot.Texture2D"/> in order to give it an icon.</para>
    /// <para>For main screen plugins, this appears at the top of the screen, to the right of the "2D", "3D", "Script", "Game", and "AssetLib" buttons.</para>
    /// <para>Ideally, the plugin icon should be white with a transparent background and 16×16 pixels in size.</para>
    /// <para><code>
    /// public override Texture2D _GetPluginIcon()
    /// {
    /// 	// You can use a custom icon:
    /// 	return ResourceLoader.Load&lt;Texture2D&gt;("res://addons/my_plugin/my_plugin_icon.svg");
    /// 	// Or use a built-in icon:
    /// 	return EditorInterface.Singleton.GetEditorTheme().GetIcon("Node", "EditorIcons");
    /// }
    /// </code></para>
    /// </summary>
    public virtual Texture2D _GetPluginIcon()
    {
        return default;
    }

    /// <summary>
    /// <para>Override this method in your plugin to provide the name of the plugin when displayed in the Godot editor.</para>
    /// <para>For main screen plugins, this appears at the top of the screen, to the right of the "2D", "3D", "Script", "Game", and "AssetLib" buttons.</para>
    /// </summary>
    public virtual string _GetPluginName()
    {
        return default;
    }

    /// <summary>
    /// <para>Override this method to provide a state data you want to be saved, like view position, grid settings, folding, etc. This is used when saving the scene (so state is kept when opening it again) and for switching tabs (so state can be restored when the tab returns). This data is automatically saved for each scene in an <c>editstate</c> file in the editor metadata folder. If you want to store global (scene-independent) editor data for your plugin, you can use <see cref="Godot.EditorPlugin._GetWindowLayout(ConfigFile)"/> instead.</para>
    /// <para>Use <see cref="Godot.EditorPlugin._SetState(Godot.Collections.Dictionary)"/> to restore your saved state.</para>
    /// <para><b>Note:</b> This method should not be used to save important settings that should persist with the project.</para>
    /// <para><b>Note:</b> You must implement <see cref="Godot.EditorPlugin._GetPluginName()"/> for the state to be stored and restored correctly.</para>
    /// <para><code>
    /// func _get_state():
    /// 	var state = { "zoom": zoom, "preferred_color": my_color }
    /// 	return state
    /// </code></para>
    /// </summary>
    public virtual Godot.Collections.Dictionary _GetState()
    {
        return default;
    }

    /// <summary>
    /// <para>Override this method to provide a custom message that lists unsaved changes. The editor will call this method when exiting or when closing a scene, and display the returned string in a confirmation dialog. Return empty string if the plugin has no unsaved changes.</para>
    /// <para>When closing a scene, <paramref name="forScene"/> is the path to the scene being closed. You can use it to handle built-in resources in that scene.</para>
    /// <para>If the user confirms saving, <see cref="Godot.EditorPlugin._SaveExternalData()"/> will be called, before closing the editor.</para>
    /// <para><code>
    /// func _get_unsaved_status(for_scene):
    /// 	if not unsaved:
    /// 		return ""
    /// 
    /// 	if for_scene.is_empty():
    /// 		return "Save changes in MyCustomPlugin before closing?"
    /// 	else:
    /// 		return "Scene %s has changes from MyCustomPlugin. Save before closing?" % for_scene.get_file()
    /// 
    /// func _save_external_data():
    /// 	unsaved = false
    /// </code></para>
    /// <para>If the plugin has no scene-specific changes, you can ignore the calls when closing scenes:</para>
    /// <para><code>
    /// func _get_unsaved_status(for_scene):
    /// 	if not for_scene.is_empty():
    /// 		return ""
    /// </code></para>
    /// </summary>
    public virtual string _GetUnsavedStatus(string forScene)
    {
        return default;
    }

    /// <summary>
    /// <para>Override this method to provide the GUI layout of the plugin or any other data you want to be stored. This is used to save the project's editor layout when <see cref="Godot.EditorPlugin.QueueSaveLayout()"/> is called or the editor layout was changed (for example changing the position of a dock). The data is stored in the <c>editor_layout.cfg</c> file in the editor metadata directory.</para>
    /// <para>Use <see cref="Godot.EditorPlugin._SetWindowLayout(ConfigFile)"/> to restore your saved layout.</para>
    /// <para><code>
    /// func _get_window_layout(configuration):
    /// 	configuration.set_value("MyPlugin", "window_position", $Window.position)
    /// 	configuration.set_value("MyPlugin", "icon_color", $Icon.modulate)
    /// </code></para>
    /// </summary>
    public virtual void _GetWindowLayout(ConfigFile configuration)
    {
    }

    /// <summary>
    /// <para>Implement this function if your plugin edits a specific type of object (Resource or Node). If you return <see langword="true"/>, then you will get the functions <see cref="Godot.EditorPlugin._Edit(GodotObject)"/> and <see cref="Godot.EditorPlugin._MakeVisible(bool)"/> called when the editor requests them. If you have declared the methods <see cref="Godot.EditorPlugin._ForwardCanvasGuiInput(InputEvent)"/> and <see cref="Godot.EditorPlugin._Forward3DGuiInput(Camera3D, InputEvent)"/> these will be called too.</para>
    /// <para><b>Note:</b> Each plugin should handle only one type of objects at a time. If a plugin handles more types of objects and they are edited at the same time, it will result in errors.</para>
    /// </summary>
    public virtual bool _Handles(GodotObject @object)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns <see langword="true"/> if this is a main screen editor plugin (it goes in the workspace selector together with <b>2D</b>, <b>3D</b>, <b>Script</b>, <b>Game</b>, and <b>AssetLib</b>).</para>
    /// <para>When the plugin's workspace is selected, other main screen plugins will be hidden, but your plugin will not appear automatically. It needs to be added as a child of <see cref="Godot.EditorInterface.GetEditorMainScreen()"/> and made visible inside <see cref="Godot.EditorPlugin._MakeVisible(bool)"/>.</para>
    /// <para>Use <see cref="Godot.EditorPlugin._GetPluginName()"/> and <see cref="Godot.EditorPlugin._GetPluginIcon()"/> to customize the plugin button's appearance.</para>
    /// <para><code>
    /// var plugin_control
    /// 
    /// func _enter_tree():
    /// 	plugin_control = preload("my_plugin_control.tscn").instantiate()
    /// 	EditorInterface.get_editor_main_screen().add_child(plugin_control)
    /// 	plugin_control.hide()
    /// 
    /// func _has_main_screen():
    /// 	return true
    /// 
    /// func _make_visible(visible):
    /// 	plugin_control.visible = visible
    /// 
    /// func _get_plugin_name():
    /// 	return "My Super Cool Plugin 3000"
    /// 
    /// func _get_plugin_icon():
    /// 	return EditorInterface.get_editor_theme().get_icon("Node", "EditorIcons")
    /// </code></para>
    /// </summary>
    public virtual bool _HasMainScreen()
    {
        return default;
    }

    /// <summary>
    /// <para>This function will be called when the editor is requested to become visible. It is used for plugins that edit a specific object type.</para>
    /// <para>Remember that you have to manage the visibility of all your editor controls manually.</para>
    /// </summary>
    public virtual void _MakeVisible(bool visible)
    {
    }

    /// <summary>
    /// <para>This function is called when an individual scene is about to be played in the editor. <paramref name="args"/> is a list of command line arguments that will be passed to the new Godot instance, which will be replaced by the list returned by this function.</para>
    /// <para><code>
    /// func _run_scene(scene, args):
    /// 	args.append("--an-extra-argument")
    /// 	return args
    /// </code></para>
    /// <para><b>Note:</b> Text that is printed in this method will not be visible in the editor's Output panel unless <c>EditorSettings.run/output/always_clear_output_on_play</c> is <see langword="false"/>.</para>
    /// </summary>
    public virtual string[] _RunScene(string scene, string[] args)
    {
        return default;
    }

    /// <summary>
    /// <para>This method is called after the editor saves the project or when it's closed. It asks the plugin to save edited external scenes/resources.</para>
    /// </summary>
    public virtual void _SaveExternalData()
    {
    }

    /// <summary>
    /// <para>Restore the state saved by <see cref="Godot.EditorPlugin._GetState()"/>. This method is called when the current scene tab is changed in the editor.</para>
    /// <para><b>Note:</b> Your plugin must implement <see cref="Godot.EditorPlugin._GetPluginName()"/>, otherwise it will not be recognized and this method will not be called.</para>
    /// <para><code>
    /// func _set_state(data):
    /// 	zoom = data.get("zoom", 1.0)
    /// 	preferred_color = data.get("my_color", Color.WHITE)
    /// </code></para>
    /// </summary>
    public virtual void _SetState(Godot.Collections.Dictionary state)
    {
    }

    /// <summary>
    /// <para>Restore the plugin GUI layout and data saved by <see cref="Godot.EditorPlugin._GetWindowLayout(ConfigFile)"/>. This method is called for every plugin on editor startup. Use the provided <paramref name="configuration"/> file to read your saved data.</para>
    /// <para><code>
    /// func _set_window_layout(configuration):
    /// 	$Window.position = configuration.get_value("MyPlugin", "window_position", Vector2())
    /// 	$Icon.modulate = configuration.get_value("MyPlugin", "icon_color", Color.WHITE)
    /// </code></para>
    /// </summary>
    public virtual void _SetWindowLayout(ConfigFile configuration)
    {
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddDock, 158651717ul);

    /// <summary>
    /// <para>Adds a new dock.</para>
    /// <para>When your plugin is deactivated, make sure to remove your custom dock with <see cref="Godot.EditorPlugin.RemoveDock(EditorDock)"/> and free it with <see cref="Godot.Node.QueueFree()"/>.</para>
    /// </summary>
    public void AddDock(EditorDock dock)
    {
        NativeCalls.godot_icall_1_56(MethodBind0, GodotObject.GetPtr(this), GodotObject.GetPtr(dock));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveDock, 158651717ul);

    /// <summary>
    /// <para>Removes <paramref name="dock"/> from the available docks. You should manually call <see cref="Godot.Node.QueueFree()"/> to free it.</para>
    /// </summary>
    public void RemoveDock(EditorDock dock)
    {
        NativeCalls.godot_icall_1_56(MethodBind1, GodotObject.GetPtr(this), GodotObject.GetPtr(dock));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddControlToContainer, 3092750152ul);

    /// <summary>
    /// <para>Adds a custom control to a container in the editor UI.</para>
    /// <para>Please remember that you have to manage the visibility of your custom controls yourself (and likely hide it after adding it).</para>
    /// <para>When your plugin is deactivated, make sure to remove your custom control with <see cref="Godot.EditorPlugin.RemoveControlFromContainer(EditorPlugin.CustomControlContainer, Control)"/> and free it with <see cref="Godot.Node.QueueFree()"/>.</para>
    /// </summary>
    public void AddControlToContainer(EditorPlugin.CustomControlContainer container, Control control)
    {
        NativeCalls.godot_icall_2_70(MethodBind2, GodotObject.GetPtr(this), (int)container, GodotObject.GetPtr(control));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveControlFromContainer, 3092750152ul);

    /// <summary>
    /// <para>Removes the control from the specified container. You have to manually <see cref="Godot.Node.QueueFree()"/> the control.</para>
    /// </summary>
    public void RemoveControlFromContainer(EditorPlugin.CustomControlContainer container, Control control)
    {
        NativeCalls.godot_icall_2_70(MethodBind3, GodotObject.GetPtr(this), (int)container, GodotObject.GetPtr(control));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddToolMenuItem, 2137474292ul);

    /// <summary>
    /// <para>Adds a custom menu item to <b>Project &gt; Tools</b> named <paramref name="name"/>. When clicked, the provided <paramref name="callable"/> will be called.</para>
    /// </summary>
    public void AddToolMenuItem(string name, Callable callable)
    {
        NativeCalls.godot_icall_2_519(MethodBind4, GodotObject.GetPtr(this), name, callable);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddToolSubmenuItem, 1019428915ul);

    /// <summary>
    /// <para>Adds a custom <see cref="Godot.PopupMenu"/> submenu under <b>Project &gt; Tools &gt;</b> <paramref name="name"/>. Use <see cref="Godot.EditorPlugin.RemoveToolMenuItem(string)"/> on plugin clean up to remove the menu.</para>
    /// </summary>
    public void AddToolSubmenuItem(string name, PopupMenu submenu)
    {
        NativeCalls.godot_icall_2_517(MethodBind5, GodotObject.GetPtr(this), name, GodotObject.GetPtr(submenu));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveToolMenuItem, 83702148ul);

    /// <summary>
    /// <para>Removes a menu <paramref name="name"/> from <b>Project &gt; Tools</b>.</para>
    /// </summary>
    public void RemoveToolMenuItem(string name)
    {
        NativeCalls.godot_icall_1_57(MethodBind6, GodotObject.GetPtr(this), name);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetExportAsMenu, 1775878644ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.PopupMenu"/> under <b>Scene &gt; Export As...</b>.</para>
    /// </summary>
    public PopupMenu GetExportAsMenu()
    {
        return (PopupMenu)NativeCalls.godot_icall_0_53(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddCustomType, 1986814599ul);

    /// <summary>
    /// <para>Adds a custom type, which will appear in the list of nodes or resources.</para>
    /// <para>When a given node or resource is selected, the base type will be instantiated (e.g. "Node3D", "Control", "Resource"), then the script will be loaded and set to this object.</para>
    /// <para><b>Note:</b> The base type is the base engine class which this type's class hierarchy inherits, not any custom type parent classes.</para>
    /// <para>You can use the virtual method <see cref="Godot.EditorPlugin._Handles(GodotObject)"/> to check if your custom object is being edited by checking the script or using the <c>is</c> keyword.</para>
    /// <para>During run-time, this will be a simple object with a script so this function does not need to be called then.</para>
    /// <para><b>Note:</b> Custom types added this way are not true classes. They are just a helper to create a node with specific script.</para>
    /// </summary>
    public void AddCustomType(string type, string @base, Script script, Texture2D icon)
    {
        EditorNativeCalls.godot_icall_4_520(MethodBind8, GodotObject.GetPtr(this), type, @base, GodotObject.GetPtr(script), GodotObject.GetPtr(icon));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveCustomType, 83702148ul);

    /// <summary>
    /// <para>Removes a custom type added by <see cref="Godot.EditorPlugin.AddCustomType(string, string, Script, Texture2D)"/>.</para>
    /// </summary>
    public void RemoveCustomType(string type)
    {
        NativeCalls.godot_icall_1_57(MethodBind9, GodotObject.GetPtr(this), type);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddControlToDock, 2994930786ul);

    /// <summary>
    /// <para>Adds the control to a specific dock slot.</para>
    /// <para>If the dock is repositioned and as long as the plugin is active, the editor will save the dock position on further sessions.</para>
    /// <para>When your plugin is deactivated, make sure to remove your custom control with <see cref="Godot.EditorPlugin.RemoveControlFromDocks(Control)"/> and free it with <see cref="Godot.Node.QueueFree()"/>.</para>
    /// <para>Optionally, you can specify a shortcut parameter. When pressed, this shortcut will open and focus the dock.</para>
    /// </summary>
    [Obsolete("Use 'Godot.EditorPlugin.AddDock(EditorDock)' instead.")]
    public void AddControlToDock(EditorPlugin.DockSlot slot, Control control, Shortcut shortcut = null)
    {
        EditorNativeCalls.godot_icall_3_521(MethodBind10, GodotObject.GetPtr(this), (int)slot, GodotObject.GetPtr(control), GodotObject.GetPtr(shortcut));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveControlFromDocks, 1496901182ul);

    /// <summary>
    /// <para>Removes the control from the dock. You have to manually <see cref="Godot.Node.QueueFree()"/> the control.</para>
    /// </summary>
    [Obsolete("Use 'Godot.EditorPlugin.RemoveDock(EditorDock)' instead.")]
    public void RemoveControlFromDocks(Control control)
    {
        NativeCalls.godot_icall_1_56(MethodBind11, GodotObject.GetPtr(this), GodotObject.GetPtr(control));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDockTabIcon, 3450529724ul);

    /// <summary>
    /// <para>Sets the tab icon for the given control in a dock slot. Setting to <see langword="null"/> removes the icon.</para>
    /// </summary>
    [Obsolete("Use 'Godot.EditorDock.DockIcon' instead.")]
    public void SetDockTabIcon(Control control, Texture2D icon)
    {
        NativeCalls.godot_icall_2_239(MethodBind12, GodotObject.GetPtr(this), GodotObject.GetPtr(control), GodotObject.GetPtr(icon));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddControlToBottomPanel, 111032269ul);

    /// <summary>
    /// <para>Adds a control to the bottom panel (together with Output, Debug, Animation, etc.). Returns a reference to a button that is outside the scene tree. It's up to you to hide/show the button when needed. When your plugin is deactivated, make sure to remove your custom control with <see cref="Godot.EditorPlugin.RemoveControlFromBottomPanel(Control)"/> and free it with <see cref="Godot.Node.QueueFree()"/>.</para>
    /// <para><paramref name="shortcut"/> is a shortcut that, when activated, will toggle the bottom panel's visibility. The shortcut object is only set when this control is added to the bottom panel.</para>
    /// <para><b>Note</b> See the default editor bottom panel shortcuts in the Editor Settings for inspiration. By convention, they all use Alt modifier.</para>
    /// </summary>
    [Obsolete("Use 'Godot.EditorPlugin.AddDock(EditorDock)' instead, with 'Godot.EditorDock.DefaultSlot' set to 'Godot.EditorPlugin.DockSlot.Bottom'.")]
    public Button AddControlToBottomPanel(Control control, string title, Shortcut shortcut = null)
    {
        return (Button)EditorNativeCalls.godot_icall_3_522(MethodBind13, GodotObject.GetPtr(this), GodotObject.GetPtr(control), title, GodotObject.GetPtr(shortcut));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveControlFromBottomPanel, 1496901182ul);

    /// <summary>
    /// <para>Removes the control from the bottom panel. You have to manually <see cref="Godot.Node.QueueFree()"/> the control.</para>
    /// </summary>
    [Obsolete("Use 'Godot.EditorPlugin.RemoveDock(EditorDock)' instead.")]
    public void RemoveControlFromBottomPanel(Control control)
    {
        NativeCalls.godot_icall_1_56(MethodBind14, GodotObject.GetPtr(this), GodotObject.GetPtr(control));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddAutoloadSingleton, 3186203200ul);

    /// <summary>
    /// <para>Adds a script at <paramref name="path"/> to the Autoload list as <paramref name="name"/>.</para>
    /// </summary>
    public void AddAutoloadSingleton(string name, string path)
    {
        NativeCalls.godot_icall_2_303(MethodBind15, GodotObject.GetPtr(this), name, path);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveAutoloadSingleton, 83702148ul);

    /// <summary>
    /// <para>Removes an Autoload <paramref name="name"/> from the list.</para>
    /// </summary>
    public void RemoveAutoloadSingleton(string name)
    {
        NativeCalls.godot_icall_1_57(MethodBind16, GodotObject.GetPtr(this), name);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.UpdateOverlays, 3905245786ul);

    /// <summary>
    /// <para>Updates the overlays of the 2D and 3D editor viewport. Causes methods <see cref="Godot.EditorPlugin._ForwardCanvasDrawOverViewport(Control)"/>, <see cref="Godot.EditorPlugin._ForwardCanvasForceDrawOverViewport(Control)"/>, <see cref="Godot.EditorPlugin._Forward3DDrawOverViewport(Control)"/> and <see cref="Godot.EditorPlugin._Forward3DForceDrawOverViewport(Control)"/> to be called.</para>
    /// </summary>
    public int UpdateOverlays()
    {
        return NativeCalls.godot_icall_0_39(MethodBind17, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MakeBottomPanelItemVisible, 1496901182ul);

    /// <summary>
    /// <para>Makes a specific item in the bottom panel visible.</para>
    /// </summary>
    public void MakeBottomPanelItemVisible(Control item)
    {
        NativeCalls.godot_icall_1_56(MethodBind18, GodotObject.GetPtr(this), GodotObject.GetPtr(item));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HideBottomPanel, 3218959716ul);

    /// <summary>
    /// <para>Minimizes the bottom panel.</para>
    /// </summary>
    public void HideBottomPanel()
    {
        NativeCalls.godot_icall_0_3(MethodBind19, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetUndoRedo, 773492341ul);

    /// <summary>
    /// <para>Gets the undo/redo object. Most actions in the editor can be undoable, so use this object to make sure this happens when it's worth it.</para>
    /// </summary>
    public EditorUndoRedoManager GetUndoRedo()
    {
        return (EditorUndoRedoManager)NativeCalls.godot_icall_0_53(MethodBind20, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddUndoRedoInspectorHookCallback, 1611583062ul);

    /// <summary>
    /// <para>Hooks a callback into the undo/redo action creation when a property is modified in the inspector. This allows, for example, to save other properties that may be lost when a given property is modified.</para>
    /// <para>The callback should have 4 arguments: <see cref="Godot.GodotObject"/> <c>undo_redo</c>, <see cref="Godot.GodotObject"/> <c>modified_object</c>, <see cref="string"/> <c>property</c> and <see cref="Godot.Variant"/> <c>new_value</c>. They are, respectively, the <see cref="Godot.UndoRedo"/> object used by the inspector, the currently modified object, the name of the modified property and the new value the property is about to take.</para>
    /// </summary>
    public void AddUndoRedoInspectorHookCallback(Callable callable)
    {
        NativeCalls.godot_icall_1_403(MethodBind21, GodotObject.GetPtr(this), callable);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveUndoRedoInspectorHookCallback, 1611583062ul);

    /// <summary>
    /// <para>Removes a callback previously added by <see cref="Godot.EditorPlugin.AddUndoRedoInspectorHookCallback(Callable)"/>.</para>
    /// </summary>
    public void RemoveUndoRedoInspectorHookCallback(Callable callable)
    {
        NativeCalls.godot_icall_1_403(MethodBind22, GodotObject.GetPtr(this), callable);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.QueueSaveLayout, 3218959716ul);

    /// <summary>
    /// <para>Queue save the project's editor layout.</para>
    /// </summary>
    public void QueueSaveLayout()
    {
        NativeCalls.godot_icall_0_3(MethodBind23, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddTranslationParserPlugin, 3116463128ul);

    /// <summary>
    /// <para>Registers a custom translation parser plugin for extracting translatable strings from custom files.</para>
    /// </summary>
    public void AddTranslationParserPlugin(EditorTranslationParserPlugin parser)
    {
        NativeCalls.godot_icall_1_56(MethodBind24, GodotObject.GetPtr(this), GodotObject.GetPtr(parser));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveTranslationParserPlugin, 3116463128ul);

    /// <summary>
    /// <para>Removes a custom translation parser plugin registered by <see cref="Godot.EditorPlugin.AddTranslationParserPlugin(EditorTranslationParserPlugin)"/>.</para>
    /// </summary>
    public void RemoveTranslationParserPlugin(EditorTranslationParserPlugin parser)
    {
        NativeCalls.godot_icall_1_56(MethodBind25, GodotObject.GetPtr(this), GodotObject.GetPtr(parser));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddImportPlugin, 3113975762ul);

    /// <summary>
    /// <para>Registers a new <see cref="Godot.EditorImportPlugin"/>. Import plugins are used to import custom and unsupported assets as a custom <see cref="Godot.Resource"/> type.</para>
    /// <para>If <paramref name="firstPriority"/> is <see langword="true"/>, the new import plugin is inserted first in the list and takes precedence over pre-existing plugins.</para>
    /// <para><b>Note:</b> If you want to import custom 3D asset formats use <see cref="Godot.EditorPlugin.AddSceneFormatImporterPlugin(EditorSceneFormatImporter, bool)"/> instead.</para>
    /// <para>See <see cref="Godot.EditorPlugin.AddInspectorPlugin(EditorInspectorPlugin)"/> for an example of how to register a plugin.</para>
    /// </summary>
    public void AddImportPlugin(EditorImportPlugin importer, bool firstPriority = false)
    {
        NativeCalls.godot_icall_2_508(MethodBind26, GodotObject.GetPtr(this), GodotObject.GetPtr(importer), firstPriority.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveImportPlugin, 2312482773ul);

    /// <summary>
    /// <para>Removes an import plugin registered by <see cref="Godot.EditorPlugin.AddImportPlugin(EditorImportPlugin, bool)"/>.</para>
    /// </summary>
    public void RemoveImportPlugin(EditorImportPlugin importer)
    {
        NativeCalls.godot_icall_1_56(MethodBind27, GodotObject.GetPtr(this), GodotObject.GetPtr(importer));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddSceneFormatImporterPlugin, 2764104752ul);

    /// <summary>
    /// <para>Registers a new <see cref="Godot.EditorSceneFormatImporter"/>. Scene importers are used to import custom 3D asset formats as scenes.</para>
    /// <para>If <paramref name="firstPriority"/> is <see langword="true"/>, the new import plugin is inserted first in the list and takes precedence over pre-existing plugins.</para>
    /// </summary>
    public void AddSceneFormatImporterPlugin(EditorSceneFormatImporter sceneFormatImporter, bool firstPriority = false)
    {
        NativeCalls.godot_icall_2_508(MethodBind28, GodotObject.GetPtr(this), GodotObject.GetPtr(sceneFormatImporter), firstPriority.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveSceneFormatImporterPlugin, 2637776123ul);

    /// <summary>
    /// <para>Removes a scene format importer registered by <see cref="Godot.EditorPlugin.AddSceneFormatImporterPlugin(EditorSceneFormatImporter, bool)"/>.</para>
    /// </summary>
    public void RemoveSceneFormatImporterPlugin(EditorSceneFormatImporter sceneFormatImporter)
    {
        NativeCalls.godot_icall_1_56(MethodBind29, GodotObject.GetPtr(this), GodotObject.GetPtr(sceneFormatImporter));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddScenePostImportPlugin, 3492436322ul);

    /// <summary>
    /// <para>Add an <see cref="Godot.EditorScenePostImportPlugin"/>. These plugins allow customizing the import process of 3D assets by adding new options to the import dialogs.</para>
    /// <para>If <paramref name="firstPriority"/> is <see langword="true"/>, the new import plugin is inserted first in the list and takes precedence over pre-existing plugins.</para>
    /// </summary>
    public void AddScenePostImportPlugin(EditorScenePostImportPlugin sceneImportPlugin, bool firstPriority = false)
    {
        NativeCalls.godot_icall_2_508(MethodBind30, GodotObject.GetPtr(this), GodotObject.GetPtr(sceneImportPlugin), firstPriority.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveScenePostImportPlugin, 3045178206ul);

    /// <summary>
    /// <para>Remove the <see cref="Godot.EditorScenePostImportPlugin"/>, added with <see cref="Godot.EditorPlugin.AddScenePostImportPlugin(EditorScenePostImportPlugin, bool)"/>.</para>
    /// </summary>
    public void RemoveScenePostImportPlugin(EditorScenePostImportPlugin sceneImportPlugin)
    {
        NativeCalls.godot_icall_1_56(MethodBind31, GodotObject.GetPtr(this), GodotObject.GetPtr(sceneImportPlugin));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind32 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddExportPlugin, 4095952207ul);

    /// <summary>
    /// <para>Registers a new <see cref="Godot.EditorExportPlugin"/>. Export plugins are used to perform tasks when the project is being exported.</para>
    /// <para>See <see cref="Godot.EditorPlugin.AddInspectorPlugin(EditorInspectorPlugin)"/> for an example of how to register a plugin.</para>
    /// </summary>
    public void AddExportPlugin(EditorExportPlugin plugin)
    {
        NativeCalls.godot_icall_1_56(MethodBind32, GodotObject.GetPtr(this), GodotObject.GetPtr(plugin));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind33 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveExportPlugin, 4095952207ul);

    /// <summary>
    /// <para>Removes an export plugin registered by <see cref="Godot.EditorPlugin.AddExportPlugin(EditorExportPlugin)"/>.</para>
    /// </summary>
    public void RemoveExportPlugin(EditorExportPlugin plugin)
    {
        NativeCalls.godot_icall_1_56(MethodBind33, GodotObject.GetPtr(this), GodotObject.GetPtr(plugin));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind34 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddExportPlatform, 3431312373ul);

    /// <summary>
    /// <para>Registers a new <see cref="Godot.EditorExportPlatform"/>. Export platforms provides functionality of exporting to the specific platform.</para>
    /// </summary>
    public void AddExportPlatform(EditorExportPlatform platform)
    {
        NativeCalls.godot_icall_1_56(MethodBind34, GodotObject.GetPtr(this), GodotObject.GetPtr(platform));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind35 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveExportPlatform, 3431312373ul);

    /// <summary>
    /// <para>Removes an export platform registered by <see cref="Godot.EditorPlugin.AddExportPlatform(EditorExportPlatform)"/>.</para>
    /// </summary>
    public void RemoveExportPlatform(EditorExportPlatform platform)
    {
        NativeCalls.godot_icall_1_56(MethodBind35, GodotObject.GetPtr(this), GodotObject.GetPtr(platform));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind36 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddNode3DGizmoPlugin, 1541015022ul);

    /// <summary>
    /// <para>Registers a new <see cref="Godot.EditorNode3DGizmoPlugin"/>. Gizmo plugins are used to add custom gizmos to the 3D preview viewport for a <see cref="Godot.Node3D"/>.</para>
    /// <para>See <see cref="Godot.EditorPlugin.AddInspectorPlugin(EditorInspectorPlugin)"/> for an example of how to register a plugin.</para>
    /// </summary>
    public void AddNode3DGizmoPlugin(EditorNode3DGizmoPlugin plugin)
    {
        NativeCalls.godot_icall_1_56(MethodBind36, GodotObject.GetPtr(this), GodotObject.GetPtr(plugin));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind37 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveNode3DGizmoPlugin, 1541015022ul);

    /// <summary>
    /// <para>Removes a gizmo plugin registered by <see cref="Godot.EditorPlugin.AddNode3DGizmoPlugin(EditorNode3DGizmoPlugin)"/>.</para>
    /// </summary>
    public void RemoveNode3DGizmoPlugin(EditorNode3DGizmoPlugin plugin)
    {
        NativeCalls.godot_icall_1_56(MethodBind37, GodotObject.GetPtr(this), GodotObject.GetPtr(plugin));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind38 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddInspectorPlugin, 546395733ul);

    /// <summary>
    /// <para>Registers a new <see cref="Godot.EditorInspectorPlugin"/>. Inspector plugins are used to extend <see cref="Godot.EditorInspector"/> and provide custom configuration tools for your object's properties.</para>
    /// <para><b>Note:</b> Always use <see cref="Godot.EditorPlugin.RemoveInspectorPlugin(EditorInspectorPlugin)"/> to remove the registered <see cref="Godot.EditorInspectorPlugin"/> when your <see cref="Godot.EditorPlugin"/> is disabled to prevent leaks and an unexpected behavior.</para>
    /// <para></para>
    /// </summary>
    public void AddInspectorPlugin(EditorInspectorPlugin plugin)
    {
        NativeCalls.godot_icall_1_56(MethodBind38, GodotObject.GetPtr(this), GodotObject.GetPtr(plugin));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind39 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveInspectorPlugin, 546395733ul);

    /// <summary>
    /// <para>Removes an inspector plugin registered by <see cref="Godot.EditorPlugin.AddInspectorPlugin(EditorInspectorPlugin)"/>.</para>
    /// </summary>
    public void RemoveInspectorPlugin(EditorInspectorPlugin plugin)
    {
        NativeCalls.godot_icall_1_56(MethodBind39, GodotObject.GetPtr(this), GodotObject.GetPtr(plugin));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind40 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddResourceConversionPlugin, 2124849111ul);

    /// <summary>
    /// <para>Registers a new <see cref="Godot.EditorResourceConversionPlugin"/>. Resource conversion plugins are used to add custom resource converters to the editor inspector.</para>
    /// <para>See <see cref="Godot.EditorResourceConversionPlugin"/> for an example of how to create a resource conversion plugin.</para>
    /// </summary>
    public void AddResourceConversionPlugin(EditorResourceConversionPlugin plugin)
    {
        NativeCalls.godot_icall_1_56(MethodBind40, GodotObject.GetPtr(this), GodotObject.GetPtr(plugin));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind41 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveResourceConversionPlugin, 2124849111ul);

    /// <summary>
    /// <para>Removes a resource conversion plugin registered by <see cref="Godot.EditorPlugin.AddResourceConversionPlugin(EditorResourceConversionPlugin)"/>.</para>
    /// </summary>
    public void RemoveResourceConversionPlugin(EditorResourceConversionPlugin plugin)
    {
        NativeCalls.godot_icall_1_56(MethodBind41, GodotObject.GetPtr(this), GodotObject.GetPtr(plugin));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind42 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetInputEventForwardingAlwaysEnabled, 3218959716ul);

    /// <summary>
    /// <para>Use this method if you always want to receive inputs from 3D view screen inside <see cref="Godot.EditorPlugin._Forward3DGuiInput(Camera3D, InputEvent)"/>. It might be especially usable if your plugin will want to use raycast in the scene.</para>
    /// </summary>
    public void SetInputEventForwardingAlwaysEnabled()
    {
        NativeCalls.godot_icall_0_3(MethodBind42, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind43 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetForceDrawOverForwardingEnabled, 3218959716ul);

    /// <summary>
    /// <para>Enables calling of <see cref="Godot.EditorPlugin._ForwardCanvasForceDrawOverViewport(Control)"/> for the 2D editor and <see cref="Godot.EditorPlugin._Forward3DForceDrawOverViewport(Control)"/> for the 3D editor when their viewports are updated. You need to call this method only once and it will work permanently for this plugin.</para>
    /// </summary>
    public void SetForceDrawOverForwardingEnabled()
    {
        NativeCalls.godot_icall_0_3(MethodBind43, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind44 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddContextMenuPlugin, 1904221872ul);

    /// <summary>
    /// <para>Adds a plugin to the context menu. <paramref name="slot"/> is the context menu where the plugin will be added.</para>
    /// <para><b>Note:</b> A plugin instance can belong only to a single context menu slot.</para>
    /// </summary>
    public void AddContextMenuPlugin(EditorContextMenuPlugin.ContextMenuSlot slot, EditorContextMenuPlugin plugin)
    {
        NativeCalls.godot_icall_2_70(MethodBind44, GodotObject.GetPtr(this), (int)slot, GodotObject.GetPtr(plugin));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind45 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveContextMenuPlugin, 2281511854ul);

    /// <summary>
    /// <para>Removes the specified context menu plugin.</para>
    /// </summary>
    public void RemoveContextMenuPlugin(EditorContextMenuPlugin plugin)
    {
        NativeCalls.godot_icall_1_56(MethodBind45, GodotObject.GetPtr(this), GodotObject.GetPtr(plugin));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind46 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEditorInterface, 4223731786ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.EditorInterface"/> singleton instance.</para>
    /// </summary>
    [Obsolete("'EditorInterface' is a global singleton and can be accessed directly by its name.")]
    public EditorInterface GetEditorInterface()
    {
        return (EditorInterface)NativeCalls.godot_icall_0_53(MethodBind46, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind47 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetScriptCreateDialog, 3121871482ul);

    /// <summary>
    /// <para>Gets the Editor's dialog used for making scripts.</para>
    /// <para><b>Note:</b> Users can configure it before use.</para>
    /// <para><b>Warning:</b> Removing and freeing this node will render a part of the editor useless and may cause a crash.</para>
    /// </summary>
    public ScriptCreateDialog GetScriptCreateDialog()
    {
        return (ScriptCreateDialog)NativeCalls.godot_icall_0_53(MethodBind47, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind48 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddDebuggerPlugin, 3749880309ul);

    /// <summary>
    /// <para>Adds a <see cref="Godot.Script"/> as debugger plugin to the Debugger. The script must extend <see cref="Godot.EditorDebuggerPlugin"/>.</para>
    /// </summary>
    public void AddDebuggerPlugin(EditorDebuggerPlugin script)
    {
        NativeCalls.godot_icall_1_56(MethodBind48, GodotObject.GetPtr(this), GodotObject.GetPtr(script));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind49 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveDebuggerPlugin, 3749880309ul);

    /// <summary>
    /// <para>Removes the debugger plugin with given script from the Debugger.</para>
    /// </summary>
    public void RemoveDebuggerPlugin(EditorDebuggerPlugin script)
    {
        NativeCalls.godot_icall_1_56(MethodBind49, GodotObject.GetPtr(this), GodotObject.GetPtr(script));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind50 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPluginVersion, 201670096ul);

    /// <summary>
    /// <para>Provide the version of the plugin declared in the <c>plugin.cfg</c> config file.</para>
    /// </summary>
    public string GetPluginVersion()
    {
        return NativeCalls.godot_icall_0_58(MethodBind50, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind51 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddControlToDock, 3354871258ul);

    /// <summary>
    /// <para>Adds the control to a specific dock slot.</para>
    /// <para>If the dock is repositioned and as long as the plugin is active, the editor will save the dock position on further sessions.</para>
    /// <para>When your plugin is deactivated, make sure to remove your custom control with <see cref="Godot.EditorPlugin.RemoveControlFromDocks(Control)"/> and free it with <see cref="Godot.Node.QueueFree()"/>.</para>
    /// <para>Optionally, you can specify a shortcut parameter. When pressed, this shortcut will open and focus the dock.</para>
    /// </summary>
    [Obsolete("Use 'Godot.EditorPlugin.AddDock(EditorDock)' instead.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void AddControlToDock(EditorPlugin.DockSlot slot, Control control)
    {
        NativeCalls.godot_icall_2_70(MethodBind51, GodotObject.GetPtr(this), (int)slot, GodotObject.GetPtr(control));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind52 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddControlToBottomPanel, 3526039376ul);

    /// <summary>
    /// <para>Adds a control to the bottom panel (together with Output, Debug, Animation, etc.). Returns a reference to a button that is outside the scene tree. It's up to you to hide/show the button when needed. When your plugin is deactivated, make sure to remove your custom control with <see cref="Godot.EditorPlugin.RemoveControlFromBottomPanel(Control)"/> and free it with <see cref="Godot.Node.QueueFree()"/>.</para>
    /// <para><paramref name="shortcut"/> is a shortcut that, when activated, will toggle the bottom panel's visibility. The shortcut object is only set when this control is added to the bottom panel.</para>
    /// <para><b>Note</b> See the default editor bottom panel shortcuts in the Editor Settings for inspiration. By convention, they all use Alt modifier.</para>
    /// </summary>
    [Obsolete("Use 'Godot.EditorPlugin.AddDock(EditorDock)' instead, with 'Godot.EditorDock.DefaultSlot' set to 'Godot.EditorPlugin.DockSlot.Bottom'.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public Button AddControlToBottomPanel(Control control, string title)
    {
        return (Button)EditorNativeCalls.godot_icall_2_523(MethodBind52, GodotObject.GetPtr(this), GodotObject.GetPtr(control), title);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.EditorPlugin.SceneChanged"/> event of a <see cref="Godot.EditorPlugin"/> class.
    /// </summary>
    public delegate void SceneChangedEventHandler(Node sceneRoot);

    private static void SceneChangedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((SceneChangedEventHandler)delegateObj)(VariantUtils.ConvertTo<Node>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when the scene is changed in the editor. The argument will return the root node of the scene that has just become active. If this scene is new and empty, the argument will be <see langword="null"/>.</para>
    /// </summary>
    public unsafe event SceneChangedEventHandler SceneChanged
    {
        add => Connect(SignalName.SceneChanged, Callable.CreateWithUnsafeTrampoline(value, &SceneChangedTrampoline));
        remove => Disconnect(SignalName.SceneChanged, Callable.CreateWithUnsafeTrampoline(value, &SceneChangedTrampoline));
    }

    protected void EmitSignalSceneChanged(Node sceneRoot)
    {
        EmitSignal(SignalName.SceneChanged, sceneRoot);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.EditorPlugin.SceneClosed"/> event of a <see cref="Godot.EditorPlugin"/> class.
    /// </summary>
    public delegate void SceneClosedEventHandler(string filepath);

    private static void SceneClosedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((SceneClosedEventHandler)delegateObj)(VariantUtils.ConvertTo<string>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when user closes a scene. The argument is a file path to the closed scene.</para>
    /// </summary>
    public unsafe event SceneClosedEventHandler SceneClosed
    {
        add => Connect(SignalName.SceneClosed, Callable.CreateWithUnsafeTrampoline(value, &SceneClosedTrampoline));
        remove => Disconnect(SignalName.SceneClosed, Callable.CreateWithUnsafeTrampoline(value, &SceneClosedTrampoline));
    }

    protected void EmitSignalSceneClosed(string filepath)
    {
        EmitSignal(SignalName.SceneClosed, filepath);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.EditorPlugin.MainScreenChanged"/> event of a <see cref="Godot.EditorPlugin"/> class.
    /// </summary>
    public delegate void MainScreenChangedEventHandler(string screenName);

    private static void MainScreenChangedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((MainScreenChangedEventHandler)delegateObj)(VariantUtils.ConvertTo<string>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when user changes the workspace (<b>2D</b>, <b>3D</b>, <b>Script</b>, <b>Game</b>, <b>AssetLib</b>). Also works with custom screens defined by plugins.</para>
    /// </summary>
    public unsafe event MainScreenChangedEventHandler MainScreenChanged
    {
        add => Connect(SignalName.MainScreenChanged, Callable.CreateWithUnsafeTrampoline(value, &MainScreenChangedTrampoline));
        remove => Disconnect(SignalName.MainScreenChanged, Callable.CreateWithUnsafeTrampoline(value, &MainScreenChangedTrampoline));
    }

    protected void EmitSignalMainScreenChanged(string screenName)
    {
        EmitSignal(SignalName.MainScreenChanged, screenName);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.EditorPlugin.ResourceSaved"/> event of a <see cref="Godot.EditorPlugin"/> class.
    /// </summary>
    public delegate void ResourceSavedEventHandler(Resource resource);

    private static void ResourceSavedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((ResourceSavedEventHandler)delegateObj)(VariantUtils.ConvertTo<Resource>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when the given <c>resource</c> was saved on disc. See also <see cref="Godot.EditorPlugin.SceneSaved"/>.</para>
    /// </summary>
    public unsafe event ResourceSavedEventHandler ResourceSaved
    {
        add => Connect(SignalName.ResourceSaved, Callable.CreateWithUnsafeTrampoline(value, &ResourceSavedTrampoline));
        remove => Disconnect(SignalName.ResourceSaved, Callable.CreateWithUnsafeTrampoline(value, &ResourceSavedTrampoline));
    }

    protected void EmitSignalResourceSaved(Resource resource)
    {
        EmitSignal(SignalName.ResourceSaved, resource);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.EditorPlugin.SceneSaved"/> event of a <see cref="Godot.EditorPlugin"/> class.
    /// </summary>
    public delegate void SceneSavedEventHandler(string filepath);

    private static void SceneSavedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((SceneSavedEventHandler)delegateObj)(VariantUtils.ConvertTo<string>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when a scene was saved on disc. The argument is a file path to the saved scene. See also <see cref="Godot.EditorPlugin.ResourceSaved"/>.</para>
    /// </summary>
    public unsafe event SceneSavedEventHandler SceneSaved
    {
        add => Connect(SignalName.SceneSaved, Callable.CreateWithUnsafeTrampoline(value, &SceneSavedTrampoline));
        remove => Disconnect(SignalName.SceneSaved, Callable.CreateWithUnsafeTrampoline(value, &SceneSavedTrampoline));
    }

    protected void EmitSignalSceneSaved(string filepath)
    {
        EmitSignal(SignalName.SceneSaved, filepath);
    }

    /// <summary>
    /// <para>Emitted when any project setting has changed.</para>
    /// </summary>
    [Obsolete("Use 'Godot.ProjectSettings.SettingsChanged' instead.")]
    public event Action ProjectSettingsChanged
    {
        add => Connect(SignalName.ProjectSettingsChanged, Callable.From(value));
        remove => Disconnect(SignalName.ProjectSettingsChanged, Callable.From(value));
    }

    [Obsolete("Use 'Godot.ProjectSettings.SettingsChanged' instead.")]
    protected void EmitSignalProjectSettingsChanged()
    {
        EmitSignal(SignalName.ProjectSettingsChanged);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__apply_changes = "_ApplyChanges";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__build = "_Build";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__clear = "_Clear";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__disable_plugin = "_DisablePlugin";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__edit = "_Edit";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__enable_plugin = "_EnablePlugin";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__forward_3d_draw_over_viewport = "_Forward3DDrawOverViewport";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__forward_3d_force_draw_over_viewport = "_Forward3DForceDrawOverViewport";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__forward_3d_gui_input = "_Forward3DGuiInput";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__forward_canvas_draw_over_viewport = "_ForwardCanvasDrawOverViewport";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__forward_canvas_force_draw_over_viewport = "_ForwardCanvasForceDrawOverViewport";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__forward_canvas_gui_input = "_ForwardCanvasGuiInput";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_breakpoints = "_GetBreakpoints";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_plugin_icon = "_GetPluginIcon";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_plugin_name = "_GetPluginName";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_state = "_GetState";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_unsaved_status = "_GetUnsavedStatus";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_window_layout = "_GetWindowLayout";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__handles = "_Handles";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__has_main_screen = "_HasMainScreen";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__make_visible = "_MakeVisible";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__run_scene = "_RunScene";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__save_external_data = "_SaveExternalData";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__set_state = "_SetState";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__set_window_layout = "_SetWindowLayout";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_scene_changed = "SceneChanged";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_scene_closed = "SceneClosed";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_main_screen_changed = "MainScreenChanged";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_resource_saved = "ResourceSaved";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_scene_saved = "SceneSaved";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_project_settings_changed = "ProjectSettingsChanged";

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
        if ((method == MethodProxyName__apply_changes || method == MethodName._ApplyChanges) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__apply_changes.NativeValue))
        {
            _ApplyChanges();
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__build || method == MethodName._Build) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__build.NativeValue))
        {
            var callRet = _Build();
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__clear || method == MethodName._Clear) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__clear.NativeValue))
        {
            _Clear();
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__disable_plugin || method == MethodName._DisablePlugin) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__disable_plugin.NativeValue))
        {
            _DisablePlugin();
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__edit || method == MethodName._Edit) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__edit.NativeValue))
        {
            _Edit(VariantUtils.ConvertTo<GodotObject>(args[0]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__enable_plugin || method == MethodName._EnablePlugin) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__enable_plugin.NativeValue))
        {
            _EnablePlugin();
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__forward_3d_draw_over_viewport || method == MethodName._Forward3DDrawOverViewport) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__forward_3d_draw_over_viewport.NativeValue))
        {
            _Forward3DDrawOverViewport(VariantUtils.ConvertTo<Control>(args[0]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__forward_3d_force_draw_over_viewport || method == MethodName._Forward3DForceDrawOverViewport) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__forward_3d_force_draw_over_viewport.NativeValue))
        {
            _Forward3DForceDrawOverViewport(VariantUtils.ConvertTo<Control>(args[0]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__forward_3d_gui_input || method == MethodName._Forward3DGuiInput) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__forward_3d_gui_input.NativeValue))
        {
            var callRet = _Forward3DGuiInput(VariantUtils.ConvertTo<Camera3D>(args[0]), VariantUtils.ConvertTo<InputEvent>(args[1]));
            ret = VariantUtils.CreateFrom<int>(callRet);
            return true;
        }
        if ((method == MethodProxyName__forward_canvas_draw_over_viewport || method == MethodName._ForwardCanvasDrawOverViewport) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__forward_canvas_draw_over_viewport.NativeValue))
        {
            _ForwardCanvasDrawOverViewport(VariantUtils.ConvertTo<Control>(args[0]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__forward_canvas_force_draw_over_viewport || method == MethodName._ForwardCanvasForceDrawOverViewport) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__forward_canvas_force_draw_over_viewport.NativeValue))
        {
            _ForwardCanvasForceDrawOverViewport(VariantUtils.ConvertTo<Control>(args[0]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__forward_canvas_gui_input || method == MethodName._ForwardCanvasGuiInput) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__forward_canvas_gui_input.NativeValue))
        {
            var callRet = _ForwardCanvasGuiInput(VariantUtils.ConvertTo<InputEvent>(args[0]));
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_breakpoints || method == MethodName._GetBreakpoints) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_breakpoints.NativeValue))
        {
            var callRet = _GetBreakpoints();
            ret = VariantUtils.CreateFrom<string[]>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_plugin_icon || method == MethodName._GetPluginIcon) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_plugin_icon.NativeValue))
        {
            var callRet = _GetPluginIcon();
            ret = VariantUtils.CreateFrom<Texture2D>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_plugin_name || method == MethodName._GetPluginName) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_plugin_name.NativeValue))
        {
            var callRet = _GetPluginName();
            ret = VariantUtils.CreateFrom<string>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_state || method == MethodName._GetState) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_state.NativeValue))
        {
            var callRet = _GetState();
            ret = VariantUtils.CreateFrom<Godot.Collections.Dictionary>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_unsaved_status || method == MethodName._GetUnsavedStatus) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_unsaved_status.NativeValue))
        {
            var callRet = _GetUnsavedStatus(VariantUtils.ConvertTo<string>(args[0]));
            ret = VariantUtils.CreateFrom<string>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_window_layout || method == MethodName._GetWindowLayout) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_window_layout.NativeValue))
        {
            _GetWindowLayout(VariantUtils.ConvertTo<ConfigFile>(args[0]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__handles || method == MethodName._Handles) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__handles.NativeValue))
        {
            var callRet = _Handles(VariantUtils.ConvertTo<GodotObject>(args[0]));
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__has_main_screen || method == MethodName._HasMainScreen) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__has_main_screen.NativeValue))
        {
            var callRet = _HasMainScreen();
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__make_visible || method == MethodName._MakeVisible) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__make_visible.NativeValue))
        {
            _MakeVisible(VariantUtils.ConvertTo<bool>(args[0]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__run_scene || method == MethodName._RunScene) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__run_scene.NativeValue))
        {
            var callRet = _RunScene(VariantUtils.ConvertTo<string>(args[0]), VariantUtils.ConvertTo<string[]>(args[1]));
            ret = VariantUtils.CreateFrom<string[]>(callRet);
            return true;
        }
        if ((method == MethodProxyName__save_external_data || method == MethodName._SaveExternalData) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__save_external_data.NativeValue))
        {
            _SaveExternalData();
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__set_state || method == MethodName._SetState) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__set_state.NativeValue))
        {
            _SetState(VariantUtils.ConvertTo<Godot.Collections.Dictionary>(args[0]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__set_window_layout || method == MethodName._SetWindowLayout) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__set_window_layout.NativeValue))
        {
            _SetWindowLayout(VariantUtils.ConvertTo<ConfigFile>(args[0]));
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
        if (method == MethodName._ApplyChanges)
        {
            if (HasGodotClassMethod(MethodProxyName__apply_changes.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._Build)
        {
            if (HasGodotClassMethod(MethodProxyName__build.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._Clear)
        {
            if (HasGodotClassMethod(MethodProxyName__clear.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._DisablePlugin)
        {
            if (HasGodotClassMethod(MethodProxyName__disable_plugin.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._Edit)
        {
            if (HasGodotClassMethod(MethodProxyName__edit.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._EnablePlugin)
        {
            if (HasGodotClassMethod(MethodProxyName__enable_plugin.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._Forward3DDrawOverViewport)
        {
            if (HasGodotClassMethod(MethodProxyName__forward_3d_draw_over_viewport.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._Forward3DForceDrawOverViewport)
        {
            if (HasGodotClassMethod(MethodProxyName__forward_3d_force_draw_over_viewport.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._Forward3DGuiInput)
        {
            if (HasGodotClassMethod(MethodProxyName__forward_3d_gui_input.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ForwardCanvasDrawOverViewport)
        {
            if (HasGodotClassMethod(MethodProxyName__forward_canvas_draw_over_viewport.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ForwardCanvasForceDrawOverViewport)
        {
            if (HasGodotClassMethod(MethodProxyName__forward_canvas_force_draw_over_viewport.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ForwardCanvasGuiInput)
        {
            if (HasGodotClassMethod(MethodProxyName__forward_canvas_gui_input.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetBreakpoints)
        {
            if (HasGodotClassMethod(MethodProxyName__get_breakpoints.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetPluginIcon)
        {
            if (HasGodotClassMethod(MethodProxyName__get_plugin_icon.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetPluginName)
        {
            if (HasGodotClassMethod(MethodProxyName__get_plugin_name.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetState)
        {
            if (HasGodotClassMethod(MethodProxyName__get_state.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetUnsavedStatus)
        {
            if (HasGodotClassMethod(MethodProxyName__get_unsaved_status.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetWindowLayout)
        {
            if (HasGodotClassMethod(MethodProxyName__get_window_layout.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._Handles)
        {
            if (HasGodotClassMethod(MethodProxyName__handles.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._HasMainScreen)
        {
            if (HasGodotClassMethod(MethodProxyName__has_main_screen.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._MakeVisible)
        {
            if (HasGodotClassMethod(MethodProxyName__make_visible.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._RunScene)
        {
            if (HasGodotClassMethod(MethodProxyName__run_scene.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._SaveExternalData)
        {
            if (HasGodotClassMethod(MethodProxyName__save_external_data.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._SetState)
        {
            if (HasGodotClassMethod(MethodProxyName__set_state.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._SetWindowLayout)
        {
            if (HasGodotClassMethod(MethodProxyName__set_window_layout.NativeValue.DangerousSelfRef))
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
        if (signal == SignalName.SceneChanged)
        {
            if (HasGodotClassSignal(SignalProxyName_scene_changed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.SceneClosed)
        {
            if (HasGodotClassSignal(SignalProxyName_scene_closed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.MainScreenChanged)
        {
            if (HasGodotClassSignal(SignalProxyName_main_screen_changed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.ResourceSaved)
        {
            if (HasGodotClassSignal(SignalProxyName_resource_saved.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.SceneSaved)
        {
            if (HasGodotClassSignal(SignalProxyName_scene_saved.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.ProjectSettingsChanged)
        {
            if (HasGodotClassSignal(SignalProxyName_project_settings_changed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        return base.HasGodotClassSignal(signal);
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : Node.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Node.MethodName
    {
        /// <summary>
        /// Cached name for the '_apply_changes' method.
        /// </summary>
        public static readonly StringName _ApplyChanges = "_apply_changes";
        /// <summary>
        /// Cached name for the '_build' method.
        /// </summary>
        public static readonly StringName _Build = "_build";
        /// <summary>
        /// Cached name for the '_clear' method.
        /// </summary>
        public static readonly StringName _Clear = "_clear";
        /// <summary>
        /// Cached name for the '_disable_plugin' method.
        /// </summary>
        public static readonly StringName _DisablePlugin = "_disable_plugin";
        /// <summary>
        /// Cached name for the '_edit' method.
        /// </summary>
        public static readonly StringName _Edit = "_edit";
        /// <summary>
        /// Cached name for the '_enable_plugin' method.
        /// </summary>
        public static readonly StringName _EnablePlugin = "_enable_plugin";
        /// <summary>
        /// Cached name for the '_forward_3d_draw_over_viewport' method.
        /// </summary>
        public static readonly StringName _Forward3DDrawOverViewport = "_forward_3d_draw_over_viewport";
        /// <summary>
        /// Cached name for the '_forward_3d_force_draw_over_viewport' method.
        /// </summary>
        public static readonly StringName _Forward3DForceDrawOverViewport = "_forward_3d_force_draw_over_viewport";
        /// <summary>
        /// Cached name for the '_forward_3d_gui_input' method.
        /// </summary>
        public static readonly StringName _Forward3DGuiInput = "_forward_3d_gui_input";
        /// <summary>
        /// Cached name for the '_forward_canvas_draw_over_viewport' method.
        /// </summary>
        public static readonly StringName _ForwardCanvasDrawOverViewport = "_forward_canvas_draw_over_viewport";
        /// <summary>
        /// Cached name for the '_forward_canvas_force_draw_over_viewport' method.
        /// </summary>
        public static readonly StringName _ForwardCanvasForceDrawOverViewport = "_forward_canvas_force_draw_over_viewport";
        /// <summary>
        /// Cached name for the '_forward_canvas_gui_input' method.
        /// </summary>
        public static readonly StringName _ForwardCanvasGuiInput = "_forward_canvas_gui_input";
        /// <summary>
        /// Cached name for the '_get_breakpoints' method.
        /// </summary>
        public static readonly StringName _GetBreakpoints = "_get_breakpoints";
        /// <summary>
        /// Cached name for the '_get_plugin_icon' method.
        /// </summary>
        public static readonly StringName _GetPluginIcon = "_get_plugin_icon";
        /// <summary>
        /// Cached name for the '_get_plugin_name' method.
        /// </summary>
        public static readonly StringName _GetPluginName = "_get_plugin_name";
        /// <summary>
        /// Cached name for the '_get_state' method.
        /// </summary>
        public static readonly StringName _GetState = "_get_state";
        /// <summary>
        /// Cached name for the '_get_unsaved_status' method.
        /// </summary>
        public static readonly StringName _GetUnsavedStatus = "_get_unsaved_status";
        /// <summary>
        /// Cached name for the '_get_window_layout' method.
        /// </summary>
        public static readonly StringName _GetWindowLayout = "_get_window_layout";
        /// <summary>
        /// Cached name for the '_handles' method.
        /// </summary>
        public static readonly StringName _Handles = "_handles";
        /// <summary>
        /// Cached name for the '_has_main_screen' method.
        /// </summary>
        public static readonly StringName _HasMainScreen = "_has_main_screen";
        /// <summary>
        /// Cached name for the '_make_visible' method.
        /// </summary>
        public static readonly StringName _MakeVisible = "_make_visible";
        /// <summary>
        /// Cached name for the '_run_scene' method.
        /// </summary>
        public static readonly StringName _RunScene = "_run_scene";
        /// <summary>
        /// Cached name for the '_save_external_data' method.
        /// </summary>
        public static readonly StringName _SaveExternalData = "_save_external_data";
        /// <summary>
        /// Cached name for the '_set_state' method.
        /// </summary>
        public static readonly StringName _SetState = "_set_state";
        /// <summary>
        /// Cached name for the '_set_window_layout' method.
        /// </summary>
        public static readonly StringName _SetWindowLayout = "_set_window_layout";
        /// <summary>
        /// Cached name for the 'add_dock' method.
        /// </summary>
        public static readonly StringName AddDock = "add_dock";
        /// <summary>
        /// Cached name for the 'remove_dock' method.
        /// </summary>
        public static readonly StringName RemoveDock = "remove_dock";
        /// <summary>
        /// Cached name for the 'add_control_to_container' method.
        /// </summary>
        public static readonly StringName AddControlToContainer = "add_control_to_container";
        /// <summary>
        /// Cached name for the 'remove_control_from_container' method.
        /// </summary>
        public static readonly StringName RemoveControlFromContainer = "remove_control_from_container";
        /// <summary>
        /// Cached name for the 'add_tool_menu_item' method.
        /// </summary>
        public static readonly StringName AddToolMenuItem = "add_tool_menu_item";
        /// <summary>
        /// Cached name for the 'add_tool_submenu_item' method.
        /// </summary>
        public static readonly StringName AddToolSubmenuItem = "add_tool_submenu_item";
        /// <summary>
        /// Cached name for the 'remove_tool_menu_item' method.
        /// </summary>
        public static readonly StringName RemoveToolMenuItem = "remove_tool_menu_item";
        /// <summary>
        /// Cached name for the 'get_export_as_menu' method.
        /// </summary>
        public static readonly StringName GetExportAsMenu = "get_export_as_menu";
        /// <summary>
        /// Cached name for the 'add_custom_type' method.
        /// </summary>
        public static readonly StringName AddCustomType = "add_custom_type";
        /// <summary>
        /// Cached name for the 'remove_custom_type' method.
        /// </summary>
        public static readonly StringName RemoveCustomType = "remove_custom_type";
        /// <summary>
        /// Cached name for the 'add_control_to_dock' method.
        /// </summary>
        public static readonly StringName AddControlToDock = "add_control_to_dock";
        /// <summary>
        /// Cached name for the 'remove_control_from_docks' method.
        /// </summary>
        public static readonly StringName RemoveControlFromDocks = "remove_control_from_docks";
        /// <summary>
        /// Cached name for the 'set_dock_tab_icon' method.
        /// </summary>
        public static readonly StringName SetDockTabIcon = "set_dock_tab_icon";
        /// <summary>
        /// Cached name for the 'add_control_to_bottom_panel' method.
        /// </summary>
        public static readonly StringName AddControlToBottomPanel = "add_control_to_bottom_panel";
        /// <summary>
        /// Cached name for the 'remove_control_from_bottom_panel' method.
        /// </summary>
        public static readonly StringName RemoveControlFromBottomPanel = "remove_control_from_bottom_panel";
        /// <summary>
        /// Cached name for the 'add_autoload_singleton' method.
        /// </summary>
        public static readonly StringName AddAutoloadSingleton = "add_autoload_singleton";
        /// <summary>
        /// Cached name for the 'remove_autoload_singleton' method.
        /// </summary>
        public static readonly StringName RemoveAutoloadSingleton = "remove_autoload_singleton";
        /// <summary>
        /// Cached name for the 'update_overlays' method.
        /// </summary>
        public static readonly StringName UpdateOverlays = "update_overlays";
        /// <summary>
        /// Cached name for the 'make_bottom_panel_item_visible' method.
        /// </summary>
        public static readonly StringName MakeBottomPanelItemVisible = "make_bottom_panel_item_visible";
        /// <summary>
        /// Cached name for the 'hide_bottom_panel' method.
        /// </summary>
        public static readonly StringName HideBottomPanel = "hide_bottom_panel";
        /// <summary>
        /// Cached name for the 'get_undo_redo' method.
        /// </summary>
        public static readonly StringName GetUndoRedo = "get_undo_redo";
        /// <summary>
        /// Cached name for the 'add_undo_redo_inspector_hook_callback' method.
        /// </summary>
        public static readonly StringName AddUndoRedoInspectorHookCallback = "add_undo_redo_inspector_hook_callback";
        /// <summary>
        /// Cached name for the 'remove_undo_redo_inspector_hook_callback' method.
        /// </summary>
        public static readonly StringName RemoveUndoRedoInspectorHookCallback = "remove_undo_redo_inspector_hook_callback";
        /// <summary>
        /// Cached name for the 'queue_save_layout' method.
        /// </summary>
        public static readonly StringName QueueSaveLayout = "queue_save_layout";
        /// <summary>
        /// Cached name for the 'add_translation_parser_plugin' method.
        /// </summary>
        public static readonly StringName AddTranslationParserPlugin = "add_translation_parser_plugin";
        /// <summary>
        /// Cached name for the 'remove_translation_parser_plugin' method.
        /// </summary>
        public static readonly StringName RemoveTranslationParserPlugin = "remove_translation_parser_plugin";
        /// <summary>
        /// Cached name for the 'add_import_plugin' method.
        /// </summary>
        public static readonly StringName AddImportPlugin = "add_import_plugin";
        /// <summary>
        /// Cached name for the 'remove_import_plugin' method.
        /// </summary>
        public static readonly StringName RemoveImportPlugin = "remove_import_plugin";
        /// <summary>
        /// Cached name for the 'add_scene_format_importer_plugin' method.
        /// </summary>
        public static readonly StringName AddSceneFormatImporterPlugin = "add_scene_format_importer_plugin";
        /// <summary>
        /// Cached name for the 'remove_scene_format_importer_plugin' method.
        /// </summary>
        public static readonly StringName RemoveSceneFormatImporterPlugin = "remove_scene_format_importer_plugin";
        /// <summary>
        /// Cached name for the 'add_scene_post_import_plugin' method.
        /// </summary>
        public static readonly StringName AddScenePostImportPlugin = "add_scene_post_import_plugin";
        /// <summary>
        /// Cached name for the 'remove_scene_post_import_plugin' method.
        /// </summary>
        public static readonly StringName RemoveScenePostImportPlugin = "remove_scene_post_import_plugin";
        /// <summary>
        /// Cached name for the 'add_export_plugin' method.
        /// </summary>
        public static readonly StringName AddExportPlugin = "add_export_plugin";
        /// <summary>
        /// Cached name for the 'remove_export_plugin' method.
        /// </summary>
        public static readonly StringName RemoveExportPlugin = "remove_export_plugin";
        /// <summary>
        /// Cached name for the 'add_export_platform' method.
        /// </summary>
        public static readonly StringName AddExportPlatform = "add_export_platform";
        /// <summary>
        /// Cached name for the 'remove_export_platform' method.
        /// </summary>
        public static readonly StringName RemoveExportPlatform = "remove_export_platform";
        /// <summary>
        /// Cached name for the 'add_node_3d_gizmo_plugin' method.
        /// </summary>
        public static readonly StringName AddNode3DGizmoPlugin = "add_node_3d_gizmo_plugin";
        /// <summary>
        /// Cached name for the 'remove_node_3d_gizmo_plugin' method.
        /// </summary>
        public static readonly StringName RemoveNode3DGizmoPlugin = "remove_node_3d_gizmo_plugin";
        /// <summary>
        /// Cached name for the 'add_inspector_plugin' method.
        /// </summary>
        public static readonly StringName AddInspectorPlugin = "add_inspector_plugin";
        /// <summary>
        /// Cached name for the 'remove_inspector_plugin' method.
        /// </summary>
        public static readonly StringName RemoveInspectorPlugin = "remove_inspector_plugin";
        /// <summary>
        /// Cached name for the 'add_resource_conversion_plugin' method.
        /// </summary>
        public static readonly StringName AddResourceConversionPlugin = "add_resource_conversion_plugin";
        /// <summary>
        /// Cached name for the 'remove_resource_conversion_plugin' method.
        /// </summary>
        public static readonly StringName RemoveResourceConversionPlugin = "remove_resource_conversion_plugin";
        /// <summary>
        /// Cached name for the 'set_input_event_forwarding_always_enabled' method.
        /// </summary>
        public static readonly StringName SetInputEventForwardingAlwaysEnabled = "set_input_event_forwarding_always_enabled";
        /// <summary>
        /// Cached name for the 'set_force_draw_over_forwarding_enabled' method.
        /// </summary>
        public static readonly StringName SetForceDrawOverForwardingEnabled = "set_force_draw_over_forwarding_enabled";
        /// <summary>
        /// Cached name for the 'add_context_menu_plugin' method.
        /// </summary>
        public static readonly StringName AddContextMenuPlugin = "add_context_menu_plugin";
        /// <summary>
        /// Cached name for the 'remove_context_menu_plugin' method.
        /// </summary>
        public static readonly StringName RemoveContextMenuPlugin = "remove_context_menu_plugin";
        /// <summary>
        /// Cached name for the 'get_editor_interface' method.
        /// </summary>
        public static readonly StringName GetEditorInterface = "get_editor_interface";
        /// <summary>
        /// Cached name for the 'get_script_create_dialog' method.
        /// </summary>
        public static readonly StringName GetScriptCreateDialog = "get_script_create_dialog";
        /// <summary>
        /// Cached name for the 'add_debugger_plugin' method.
        /// </summary>
        public static readonly StringName AddDebuggerPlugin = "add_debugger_plugin";
        /// <summary>
        /// Cached name for the 'remove_debugger_plugin' method.
        /// </summary>
        public static readonly StringName RemoveDebuggerPlugin = "remove_debugger_plugin";
        /// <summary>
        /// Cached name for the 'get_plugin_version' method.
        /// </summary>
        public static readonly StringName GetPluginVersion = "get_plugin_version";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Node.SignalName
    {
        /// <summary>
        /// Cached name for the 'scene_changed' signal.
        /// </summary>
        public static readonly StringName SceneChanged = "scene_changed";
        /// <summary>
        /// Cached name for the 'scene_closed' signal.
        /// </summary>
        public static readonly StringName SceneClosed = "scene_closed";
        /// <summary>
        /// Cached name for the 'main_screen_changed' signal.
        /// </summary>
        public static readonly StringName MainScreenChanged = "main_screen_changed";
        /// <summary>
        /// Cached name for the 'resource_saved' signal.
        /// </summary>
        public static readonly StringName ResourceSaved = "resource_saved";
        /// <summary>
        /// Cached name for the 'scene_saved' signal.
        /// </summary>
        public static readonly StringName SceneSaved = "scene_saved";
        /// <summary>
        /// Cached name for the 'project_settings_changed' signal.
        /// </summary>
        public static readonly StringName ProjectSettingsChanged = "project_settings_changed";
    }
}
