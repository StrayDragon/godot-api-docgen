namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Nodes are Godot's building blocks. They can be assigned as the child of another node, resulting in a tree arrangement. A given node can contain any number of nodes as children with the requirement that all siblings (direct children of a node) should have unique names.</para>
/// <para>A tree of nodes is called a <i>scene</i>. Scenes can be saved to the disk and then instantiated into other scenes. This allows for very high flexibility in the architecture and data model of Godot projects.</para>
/// <para><b>Scene tree:</b> The <see cref="Godot.SceneTree"/> contains the active tree of nodes. When a node is added to the scene tree, it receives the <see cref="Godot.Node.NotificationEnterTree"/> notification and its <see cref="Godot.Node._EnterTree()"/> callback is triggered. Child nodes are always added <i>after</i> their parent node, i.e. the <see cref="Godot.Node._EnterTree()"/> callback of a parent node will be triggered before its child's.</para>
/// <para>Once all nodes have been added in the scene tree, they receive the <see cref="Godot.Node.NotificationReady"/> notification and their respective <see cref="Godot.Node._Ready()"/> callbacks are triggered. For groups of nodes, the <see cref="Godot.Node._Ready()"/> callback is called in reverse order, starting with the children and moving up to the parent nodes.</para>
/// <para>This means that when adding a node to the scene tree, the following order will be used for the callbacks: <see cref="Godot.Node._EnterTree()"/> of the parent, <see cref="Godot.Node._EnterTree()"/> of the children, <see cref="Godot.Node._Ready()"/> of the children and finally <see cref="Godot.Node._Ready()"/> of the parent (recursively for the entire scene tree).</para>
/// <para><b>Processing:</b> Nodes can override the "process" state, so that they receive a callback on each frame requesting them to process (do something). Normal processing (callback <see cref="Godot.Node._Process(double)"/>, toggled with <see cref="Godot.Node.SetProcess(bool)"/>) happens as fast as possible and is dependent on the frame rate, so the processing time <i>delta</i> (in seconds) is passed as an argument. Physics processing (callback <see cref="Godot.Node._PhysicsProcess(double)"/>, toggled with <see cref="Godot.Node.SetPhysicsProcess(bool)"/>) happens a fixed number of times per second (60 by default) and is useful for code related to the physics engine.</para>
/// <para>Nodes can also process input events. When present, the <see cref="Godot.Node._Input(InputEvent)"/> function will be called for each input that the program receives. In many cases, this can be overkill (unless used for simple projects), and the <see cref="Godot.Node._UnhandledInput(InputEvent)"/> function might be preferred; it is called when the input event was not handled by anyone else (typically, GUI <see cref="Godot.Control"/> nodes), ensuring that the node only receives the events that were meant for it.</para>
/// <para>To keep track of the scene hierarchy (especially when instantiating scenes into other scenes), an "owner" can be set for the node with the <see cref="Godot.Node.Owner"/> property. This keeps track of who instantiated what. This is mostly useful when writing editors and tools, though.</para>
/// <para>Finally, when a node is freed with <see cref="Godot.GodotObject.Free()"/> or <see cref="Godot.Node.QueueFree()"/>, it will also free all its children.</para>
/// <para><b>Groups:</b> Nodes can be added to as many groups as you want to be easy to manage, you could create groups like "enemies" or "collectables" for example, depending on your game. See <see cref="Godot.Node.AddToGroup(StringName, bool)"/>, <see cref="Godot.Node.IsInGroup(StringName)"/> and <see cref="Godot.Node.RemoveFromGroup(StringName)"/>. You can then retrieve all nodes in these groups, iterate them and even call methods on groups via the methods on <see cref="Godot.SceneTree"/>.</para>
/// <para><b>Networking with nodes:</b> After connecting to a server (or making one, see <see cref="Godot.ENetMultiplayerPeer"/>), it is possible to use the built-in RPC (remote procedure call) system to communicate over the network. By calling <see cref="Godot.Node.Rpc(StringName, Variant[])"/> with a method name, it will be called locally and in all connected peers (peers = clients and the server that accepts connections). To identify which node receives the RPC call, Godot will use its <see cref="Godot.NodePath"/> (make sure node names are the same on all peers). Also, take a look at the high-level networking tutorial and corresponding demos.</para>
/// <para><b>Note:</b> The <c>script</c> property is part of the <see cref="Godot.GodotObject"/> class, not <see cref="Godot.Node"/>. It isn't exposed like most properties but does have a setter and getter (see <see cref="Godot.GodotObject.SetScript(Variant)"/> and <see cref="Godot.GodotObject.GetScript()"/>).</para>
/// </summary>
public partial class Node : GodotObject
{
    /// <summary>
    /// <para>Notification received when the node enters a <see cref="Godot.SceneTree"/>. See <see cref="Godot.Node._EnterTree()"/>.</para>
    /// <para>This notification is received <i>before</i> the related <see cref="Godot.Node.TreeEntered"/> signal.</para>
    /// </summary>
    public const long NotificationEnterTree = 10;
    /// <summary>
    /// <para>Notification received when the node is about to exit a <see cref="Godot.SceneTree"/>. See <see cref="Godot.Node._ExitTree()"/>.</para>
    /// <para>This notification is received <i>after</i> the related <see cref="Godot.Node.TreeExiting"/> signal.</para>
    /// <para>This notification is sent in reversed order.</para>
    /// </summary>
    public const long NotificationExitTree = 11;
    [Obsolete("This notification is no longer sent by the engine. Use 'Godot.Node.NotificationChildOrderChanged' instead.")]
    public const long NotificationMovedInParent = 12;
    /// <summary>
    /// <para>Notification received when the node is ready. See <see cref="Godot.Node._Ready()"/>.</para>
    /// </summary>
    public const long NotificationReady = 13;
    /// <summary>
    /// <para>Notification received when the node is paused. See <see cref="Godot.Node.ProcessMode"/>.</para>
    /// </summary>
    public const long NotificationPaused = 14;
    /// <summary>
    /// <para>Notification received when the node is unpaused. See <see cref="Godot.Node.ProcessMode"/>.</para>
    /// </summary>
    public const long NotificationUnpaused = 15;
    /// <summary>
    /// <para>Notification received from the tree every physics frame when <see cref="Godot.Node.IsPhysicsProcessing()"/> returns <see langword="true"/>. See <see cref="Godot.Node._PhysicsProcess(double)"/>.</para>
    /// </summary>
    public const long NotificationPhysicsProcess = 16;
    /// <summary>
    /// <para>Notification received from the tree every rendered frame when <see cref="Godot.Node.IsProcessing()"/> returns <see langword="true"/>. See <see cref="Godot.Node._Process(double)"/>.</para>
    /// </summary>
    public const long NotificationProcess = 17;
    /// <summary>
    /// <para>Notification received when the node is set as a child of another node (see <see cref="Godot.Node.AddChild(Node, bool, Node.InternalMode)"/> and <see cref="Godot.Node.AddSibling(Node, bool)"/>).</para>
    /// <para><b>Note:</b> This does <i>not</i> mean that the node entered the <see cref="Godot.SceneTree"/>.</para>
    /// </summary>
    public const long NotificationParented = 18;
    /// <summary>
    /// <para>Notification received when the parent node calls <see cref="Godot.Node.RemoveChild(Node)"/> on this node.</para>
    /// <para><b>Note:</b> This does <i>not</i> mean that the node exited the <see cref="Godot.SceneTree"/>.</para>
    /// </summary>
    public const long NotificationUnparented = 19;
    /// <summary>
    /// <para>Notification received <i>only</i> by the newly instantiated scene root node, when <see cref="Godot.PackedScene.Instantiate(PackedScene.GenEditState)"/> is completed.</para>
    /// </summary>
    public const long NotificationSceneInstantiated = 20;
    /// <summary>
    /// <para>Notification received when a drag operation begins. All nodes receive this notification, not only the dragged one.</para>
    /// <para>Can be triggered either by dragging a <see cref="Godot.Control"/> that provides drag data (see <see cref="Godot.Control._GetDragData(Vector2)"/>) or using <see cref="Godot.Control.ForceDrag(Variant, Control)"/>.</para>
    /// <para>Use <see cref="Godot.Viewport.GuiGetDragData()"/> to get the dragged data.</para>
    /// </summary>
    public const long NotificationDragBegin = 21;
    /// <summary>
    /// <para>Notification received when a drag operation ends.</para>
    /// <para>Use <see cref="Godot.Viewport.GuiIsDragSuccessful()"/> to check if the drag succeeded.</para>
    /// </summary>
    public const long NotificationDragEnd = 22;
    /// <summary>
    /// <para>Notification received when the node's <see cref="Godot.Node.Name"/> or one of its ancestors' <see cref="Godot.Node.Name"/> is changed. This notification is <i>not</i> received when the node is removed from the <see cref="Godot.SceneTree"/>.</para>
    /// </summary>
    public const long NotificationPathRenamed = 23;
    /// <summary>
    /// <para>Notification received when the list of children is changed. This happens when child nodes are added, moved or removed.</para>
    /// </summary>
    public const long NotificationChildOrderChanged = 24;
    /// <summary>
    /// <para>Notification received from the tree every rendered frame when <see cref="Godot.Node.IsProcessingInternal()"/> returns <see langword="true"/>.</para>
    /// </summary>
    public const long NotificationInternalProcess = 25;
    /// <summary>
    /// <para>Notification received from the tree every physics frame when <see cref="Godot.Node.IsPhysicsProcessingInternal()"/> returns <see langword="true"/>.</para>
    /// </summary>
    public const long NotificationInternalPhysicsProcess = 26;
    /// <summary>
    /// <para>Notification received when the node enters the tree, just before <see cref="Godot.Node.NotificationReady"/> may be received. Unlike the latter, it is sent every time the node enters tree, not just once.</para>
    /// </summary>
    public const long NotificationPostEnterTree = 27;
    /// <summary>
    /// <para>Notification received when the node is disabled. See <see cref="Godot.Node.ProcessModeEnum.Disabled"/>.</para>
    /// </summary>
    public const long NotificationDisabled = 28;
    /// <summary>
    /// <para>Notification received when the node is enabled again after being disabled. See <see cref="Godot.Node.ProcessModeEnum.Disabled"/>.</para>
    /// </summary>
    public const long NotificationEnabled = 29;
    /// <summary>
    /// <para>Notification received when <see cref="Godot.Node.ResetPhysicsInterpolation()"/> is called on the node or its ancestors.</para>
    /// </summary>
    public const long NotificationResetPhysicsInterpolation = 2001;
    /// <summary>
    /// <para>Notification received right before the scene with the node is saved in the editor. This notification is only sent in the Godot editor and will not occur in exported projects.</para>
    /// </summary>
    public const long NotificationEditorPreSave = 9001;
    /// <summary>
    /// <para>Notification received right after the scene with the node is saved in the editor. This notification is only sent in the Godot editor and will not occur in exported projects.</para>
    /// </summary>
    public const long NotificationEditorPostSave = 9002;
    /// <summary>
    /// <para>Notification received when the mouse enters the window.</para>
    /// <para>Implemented for embedded windows and on desktop and web platforms.</para>
    /// </summary>
    public const long NotificationWMMouseEnter = 1002;
    /// <summary>
    /// <para>Notification received when the mouse leaves the window.</para>
    /// <para>Implemented for embedded windows and on desktop and web platforms.</para>
    /// </summary>
    public const long NotificationWMMouseExit = 1003;
    /// <summary>
    /// <para>Notification received from the OS when the node's <see cref="Godot.Window"/> ancestor is focused. This may be a change of focus between two windows of the same engine instance, or from the OS desktop or a third-party application to a window of the game (in which case <see cref="Godot.Node.NotificationApplicationFocusIn"/> is also received).</para>
    /// <para>A <see cref="Godot.Window"/> node receives this notification when it is focused.</para>
    /// </summary>
    public const long NotificationWMWindowFocusIn = 1004;
    /// <summary>
    /// <para>Notification received from the OS when the node's <see cref="Godot.Window"/> ancestor is defocused. This may be a change of focus between two windows of the same engine instance, or from a window of the game to the OS desktop or a third-party application (in which case <see cref="Godot.Node.NotificationApplicationFocusOut"/> is also received).</para>
    /// <para>A <see cref="Godot.Window"/> node receives this notification when it is defocused.</para>
    /// </summary>
    public const long NotificationWMWindowFocusOut = 1005;
    /// <summary>
    /// <para>Notification received from the OS when a close request is sent (e.g. closing the window with a "Close" button or Alt + F4).</para>
    /// <para>Implemented on desktop platforms.</para>
    /// </summary>
    public const long NotificationWMCloseRequest = 1006;
    /// <summary>
    /// <para>Notification received from the OS when a go back request is sent (e.g. pressing the "Back" button on Android).</para>
    /// <para>Implemented only on Android.</para>
    /// </summary>
    public const long NotificationWMGoBackRequest = 1007;
    /// <summary>
    /// <para>Notification received when the window is resized.</para>
    /// <para><b>Note:</b> Only the resized <see cref="Godot.Window"/> node receives this notification, and it's not propagated to the child nodes.</para>
    /// </summary>
    public const long NotificationWMSizeChanged = 1008;
    /// <summary>
    /// <para>Notification received from the OS when the screen's dots per inch (DPI) scale is changed. Only implemented on macOS.</para>
    /// </summary>
    public const long NotificationWMDpiChange = 1009;
    /// <summary>
    /// <para>Notification received when the mouse cursor enters the <see cref="Godot.Viewport"/>'s visible area, that is not occluded behind other <see cref="Godot.Control"/>s or <see cref="Godot.Window"/>s, provided its <see cref="Godot.Viewport.GuiDisableInput"/> is <see langword="false"/> and regardless if it's currently focused or not.</para>
    /// </summary>
    public const long NotificationVpMouseEnter = 1010;
    /// <summary>
    /// <para>Notification received when the mouse cursor leaves the <see cref="Godot.Viewport"/>'s visible area, that is not occluded behind other <see cref="Godot.Control"/>s or <see cref="Godot.Window"/>s, provided its <see cref="Godot.Viewport.GuiDisableInput"/> is <see langword="false"/> and regardless if it's currently focused or not.</para>
    /// </summary>
    public const long NotificationVpMouseExit = 1011;
    /// <summary>
    /// <para>Notification received when the window is moved.</para>
    /// </summary>
    public const long NotificationWMPositionChanged = 1012;
    /// <summary>
    /// <para>Notification received from the OS when the application is exceeding its allocated memory.</para>
    /// <para>Implemented only on iOS.</para>
    /// </summary>
    public const long NotificationOsMemoryWarning = 2009;
    /// <summary>
    /// <para>Notification received when translations may have changed. Can be triggered by the user changing the locale, changing <see cref="Godot.Node.AutoTranslateMode"/> or when the node enters the scene tree. Can be used to respond to language changes, for example to change the UI strings on the fly. Useful when working with the built-in translation support, like <see cref="Godot.GodotObject.Tr(StringName, StringName)"/>.</para>
    /// <para><b>Note:</b> This notification is received alongside <see cref="Godot.Node.NotificationEnterTree"/>, so if you are instantiating a scene, the child nodes will not be initialized yet. You can use it to setup translations for this node, child nodes created from script, or if you want to access child nodes added in the editor, make sure the node is ready using <see cref="Godot.Node.IsNodeReady()"/>.</para>
    /// <para><code>
    /// func _notification(what):
    /// 	if what == NOTIFICATION_TRANSLATION_CHANGED:
    /// 		if not is_node_ready():
    /// 			await ready # Wait until ready signal.
    /// 		$Label.text = atr("%d Bananas") % banana_counter
    /// </code></para>
    /// </summary>
    public const long NotificationTranslationChanged = 2010;
    /// <summary>
    /// <para>Notification received from the OS when a request for "About" information is sent.</para>
    /// <para>Implemented only on macOS.</para>
    /// </summary>
    public const long NotificationWMAbout = 2011;
    /// <summary>
    /// <para>Notification received from Godot's crash handler when the engine is about to crash.</para>
    /// <para>Implemented on desktop platforms, if the crash handler is enabled.</para>
    /// </summary>
    public const long NotificationCrash = 2012;
    /// <summary>
    /// <para>Notification received from the OS when an update of the Input Method Engine occurs (e.g. change of IME cursor position or composition string).</para>
    /// <para>Implemented on desktop and web platforms.</para>
    /// </summary>
    public const long NotificationOsImeUpdate = 2013;
    /// <summary>
    /// <para>Notification received from the OS when the application is resumed.</para>
    /// <para>Specific to the Android and iOS platforms.</para>
    /// </summary>
    public const long NotificationApplicationResumed = 2014;
    /// <summary>
    /// <para>Notification received from the OS when the application is paused.</para>
    /// <para>Specific to the Android and iOS platforms.</para>
    /// <para><b>Note:</b> On iOS, you only have approximately 5 seconds to finish a task started by this signal. If you go over this allotment, iOS will kill the app instead of pausing it.</para>
    /// </summary>
    public const long NotificationApplicationPaused = 2015;
    /// <summary>
    /// <para>Notification received from the OS when the application is focused, i.e. when changing the focus from the OS desktop or a thirdparty application to any open window of the Godot instance.</para>
    /// <para>Implemented on desktop and mobile platforms.</para>
    /// </summary>
    public const long NotificationApplicationFocusIn = 2016;
    /// <summary>
    /// <para>Notification received from the OS when the application is defocused, i.e. when changing the focus from any open window of the Godot instance to the OS desktop or a thirdparty application.</para>
    /// <para>Implemented on desktop and mobile platforms.</para>
    /// </summary>
    public const long NotificationApplicationFocusOut = 2017;
    /// <summary>
    /// <para>Notification received when the <see cref="Godot.TextServer"/> is changed.</para>
    /// </summary>
    public const long NotificationTextServerChanged = 2018;
    /// <summary>
    /// <para>Notification received when an accessibility information update is required.</para>
    /// </summary>
    public const long NotificationAccessibilityUpdate = 3000;
    /// <summary>
    /// <para>Notification received when accessibility elements are invalidated. All node accessibility elements are automatically deleted after receiving this message, therefore all existing references to such elements should be discarded.</para>
    /// </summary>
    public const long NotificationAccessibilityInvalidate = 3001;

    public enum ProcessModeEnum : long
    {
        /// <summary>
        /// <para>Inherits <see cref="Godot.Node.ProcessMode"/> from the node's parent. This is the default for any newly created node.</para>
        /// </summary>
        Inherit = 0,
        /// <summary>
        /// <para>Stops processing when <see cref="Godot.SceneTree.Paused"/> is <see langword="true"/>. This is the inverse of <see cref="Godot.Node.ProcessModeEnum.WhenPaused"/>, and the default for the root node.</para>
        /// </summary>
        Pausable = 1,
        /// <summary>
        /// <para>Process <b>only</b> when <see cref="Godot.SceneTree.Paused"/> is <see langword="true"/>. This is the inverse of <see cref="Godot.Node.ProcessModeEnum.Pausable"/>.</para>
        /// </summary>
        WhenPaused = 2,
        /// <summary>
        /// <para>Always process. Keeps processing, ignoring <see cref="Godot.SceneTree.Paused"/>. This is the inverse of <see cref="Godot.Node.ProcessModeEnum.Disabled"/>.</para>
        /// </summary>
        Always = 3,
        /// <summary>
        /// <para>Never process. Completely disables processing, ignoring <see cref="Godot.SceneTree.Paused"/>. This is the inverse of <see cref="Godot.Node.ProcessModeEnum.Always"/>.</para>
        /// </summary>
        Disabled = 4
    }

    public enum ProcessThreadGroupEnum : long
    {
        /// <summary>
        /// <para>Process this node based on the thread group mode of the first parent (or grandparent) node that has a thread group mode that is not inherit. See <see cref="Godot.Node.ProcessThreadGroup"/> for more information.</para>
        /// </summary>
        Inherit = 0,
        /// <summary>
        /// <para>Process this node (and child nodes set to inherit) on the main thread. See <see cref="Godot.Node.ProcessThreadGroup"/> for more information.</para>
        /// </summary>
        MainThread = 1,
        /// <summary>
        /// <para>Process this node (and child nodes set to inherit) on a sub-thread. See <see cref="Godot.Node.ProcessThreadGroup"/> for more information.</para>
        /// </summary>
        SubThread = 2
    }

    [System.Flags]
    public enum ProcessThreadMessagesEnum : long
    {
        /// <summary>
        /// <para>Allows this node to process threaded messages created with <see cref="Godot.Node.CallDeferredThreadGroup(StringName, Variant[])"/> right before <see cref="Godot.Node._Process(double)"/> is called.</para>
        /// </summary>
        Messages = 1,
        /// <summary>
        /// <para>Allows this node to process threaded messages created with <see cref="Godot.Node.CallDeferredThreadGroup(StringName, Variant[])"/> right before <see cref="Godot.Node._PhysicsProcess(double)"/> is called.</para>
        /// </summary>
        MessagesPhysics = 2,
        /// <summary>
        /// <para>Allows this node to process threaded messages created with <see cref="Godot.Node.CallDeferredThreadGroup(StringName, Variant[])"/> right before either <see cref="Godot.Node._Process(double)"/> or <see cref="Godot.Node._PhysicsProcess(double)"/> are called.</para>
        /// </summary>
        MessagesAll = 3
    }

    public enum PhysicsInterpolationModeEnum : long
    {
        /// <summary>
        /// <para>Inherits <see cref="Godot.Node.PhysicsInterpolationMode"/> from the node's parent. This is the default for any newly created node.</para>
        /// </summary>
        Inherit = 0,
        /// <summary>
        /// <para>Enables physics interpolation for this node and for children set to <see cref="Godot.Node.PhysicsInterpolationModeEnum.Inherit"/>. This is the default for the root node.</para>
        /// </summary>
        On = 1,
        /// <summary>
        /// <para>Disables physics interpolation for this node and for children set to <see cref="Godot.Node.PhysicsInterpolationModeEnum.Inherit"/>.</para>
        /// </summary>
        Off = 2
    }

    public enum DuplicateFlags : long
    {
        /// <summary>
        /// <para>Duplicate the node's signal connections that are connected with the <see cref="Godot.GodotObject.ConnectFlags.Persist"/> flag.</para>
        /// </summary>
        Signals = 1,
        /// <summary>
        /// <para>Duplicate the node's groups.</para>
        /// </summary>
        Groups = 2,
        /// <summary>
        /// <para>Duplicate the node's script (also overriding the duplicated children's scripts, if combined with <see cref="Godot.Node.DuplicateFlags.UseInstantiation"/>).</para>
        /// </summary>
        Scripts = 4,
        /// <summary>
        /// <para>Duplicate using <see cref="Godot.PackedScene.Instantiate(PackedScene.GenEditState)"/>. If the node comes from a scene saved on disk, reuses <see cref="Godot.PackedScene.Instantiate(PackedScene.GenEditState)"/> as the base for the duplicated node and its children.</para>
        /// </summary>
        UseInstantiation = 8,
        /// <summary>
        /// <para>Duplicate also non-serializable variables (i.e. without <see cref="Godot.PropertyUsageFlags.Storage"/>).</para>
        /// </summary>
        InternalState = 16,
        /// <summary>
        /// <para>Duplicate using default flags. This constant is useful to add or remove a single flag.</para>
        /// <para><code>
        /// # Duplicate non-exported variables.
        /// var dupe = duplicate(DUPLICATE_DEFAULT | DUPLICATE_INTERNAL_STATE)
        /// </code></para>
        /// </summary>
        Default = 15
    }

    public enum InternalMode : long
    {
        /// <summary>
        /// <para>The node will not be internal.</para>
        /// </summary>
        Disabled = 0,
        /// <summary>
        /// <para>The node will be placed at the beginning of the parent's children, before any non-internal sibling.</para>
        /// </summary>
        Front = 1,
        /// <summary>
        /// <para>The node will be placed at the end of the parent's children, after any non-internal sibling.</para>
        /// </summary>
        Back = 2
    }

    public enum AutoTranslateModeEnum : long
    {
        /// <summary>
        /// <para>Inherits <see cref="Godot.Node.AutoTranslateMode"/> from the node's parent. This is the default for any newly created node.</para>
        /// </summary>
        Inherit = 0,
        /// <summary>
        /// <para>Always automatically translate. This is the inverse of <see cref="Godot.Node.AutoTranslateModeEnum.Disabled"/>, and the default for the root node.</para>
        /// </summary>
        Always = 1,
        /// <summary>
        /// <para>Never automatically translate. This is the inverse of <see cref="Godot.Node.AutoTranslateModeEnum.Always"/>.</para>
        /// <para>String parsing for translation template generation will be skipped for this node and children that are set to <see cref="Godot.Node.AutoTranslateModeEnum.Inherit"/>.</para>
        /// </summary>
        Disabled = 2
    }

    /// <summary>
    /// <para>The name of the node. This name must be unique among the siblings (other child nodes from the same parent). When set to an existing sibling's name, the node is automatically renamed.</para>
    /// <para><b>Note:</b> When changing the name, the following characters will be replaced with an underscore: (<c>.</c> <c>:</c> <c>@</c> <c>/</c> <c>"</c> <c>%</c>). In particular, the <c>@</c> character is reserved for auto-generated names. See also <c>String.validate_node_name</c>.</para>
    /// </summary>
    public StringName Name
    {
        get
        {
            return GetName();
        }
        set
        {
            SetName(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the node can be accessed from any node sharing the same <see cref="Godot.Node.Owner"/> or from the <see cref="Godot.Node.Owner"/> itself, with special <c>%Name</c> syntax in <see cref="Godot.Node.GetNode(NodePath)"/>.</para>
    /// <para><b>Note:</b> If another node with the same <see cref="Godot.Node.Owner"/> shares the same <see cref="Godot.Node.Name"/> as this node, the other node will no longer be accessible as unique.</para>
    /// </summary>
    public bool UniqueNameInOwner
    {
        get
        {
            return IsUniqueNameInOwner();
        }
        set
        {
            SetUniqueNameInOwner(value);
        }
    }

    /// <summary>
    /// <para>The original scene's file path, if the node has been instantiated from a <see cref="Godot.PackedScene"/> file. Only scene root nodes contains this.</para>
    /// </summary>
    public string SceneFilePath
    {
        get
        {
            return GetSceneFilePath();
        }
        set
        {
            SetSceneFilePath(value);
        }
    }

    /// <summary>
    /// <para>The owner of this node. The owner must be an ancestor of this node. When packing the owner node in a <see cref="Godot.PackedScene"/>, all the nodes it owns are also saved with it. See also <see cref="Godot.Node.UniqueNameInOwner"/>.</para>
    /// <para><b>Note:</b> In the editor, nodes not owned by the scene root are usually not displayed in the Scene dock, and will <b>not</b> be saved. To prevent this, remember to set the owner after calling <see cref="Godot.Node.AddChild(Node, bool, Node.InternalMode)"/>.</para>
    /// <para><b>Note:</b> The owner needs to be the current scene root. See <a href="$DOCS_URL/tutorials/plugins/running_code_in_the_editor.html#instancing-scenes">Instancing scenes</a> in the documentation for more information.</para>
    /// </summary>
    public Node Owner
    {
        get
        {
            return GetOwner();
        }
        set
        {
            SetOwner(value);
        }
    }

    /// <summary>
    /// <para>The <see cref="Godot.MultiplayerApi"/> instance associated with this node. See <see cref="Godot.SceneTree.GetMultiplayer(NodePath)"/>.</para>
    /// <para><b>Note:</b> Renaming the node, or moving it in the tree, will not move the <see cref="Godot.MultiplayerApi"/> to the new path, you will have to update this manually.</para>
    /// </summary>
    public MultiplayerApi Multiplayer
    {
        get
        {
            return GetMultiplayer();
        }
    }

    /// <summary>
    /// <para>The node's processing behavior. To check if the node can process in its current mode, use <see cref="Godot.Node.CanProcess()"/>.</para>
    /// </summary>
    public Node.ProcessModeEnum ProcessMode
    {
        get
        {
            return GetProcessMode();
        }
        set
        {
            SetProcessMode(value);
        }
    }

    /// <summary>
    /// <para>The node's execution order of the process callbacks (<see cref="Godot.Node._Process(double)"/>, <see cref="Godot.Node.NotificationProcess"/>, and <see cref="Godot.Node.NotificationInternalProcess"/>). Nodes whose priority value is <i>lower</i> call their process callbacks first, regardless of tree order.</para>
    /// </summary>
    public int ProcessPriority
    {
        get
        {
            return GetProcessPriority();
        }
        set
        {
            SetProcessPriority(value);
        }
    }

    /// <summary>
    /// <para>Similar to <see cref="Godot.Node.ProcessPriority"/> but for <see cref="Godot.Node.NotificationPhysicsProcess"/>, <see cref="Godot.Node._PhysicsProcess(double)"/>, or <see cref="Godot.Node.NotificationInternalPhysicsProcess"/>.</para>
    /// </summary>
    public int ProcessPhysicsPriority
    {
        get
        {
            return GetPhysicsProcessPriority();
        }
        set
        {
            SetPhysicsProcessPriority(value);
        }
    }

    /// <summary>
    /// <para>Set the process thread group for this node (basically, whether it receives <see cref="Godot.Node.NotificationProcess"/>, <see cref="Godot.Node.NotificationPhysicsProcess"/>, <see cref="Godot.Node._Process(double)"/> or <see cref="Godot.Node._PhysicsProcess(double)"/> (and the internal versions) on the main thread or in a sub-thread.</para>
    /// <para>By default, the thread group is <see cref="Godot.Node.ProcessThreadGroupEnum.Inherit"/>, which means that this node belongs to the same thread group as the parent node. The thread groups means that nodes in a specific thread group will process together, separate to other thread groups (depending on <see cref="Godot.Node.ProcessThreadGroupOrder"/>). If the value is set is <see cref="Godot.Node.ProcessThreadGroupEnum.SubThread"/>, this thread group will occur on a sub thread (not the main thread), otherwise if set to <see cref="Godot.Node.ProcessThreadGroupEnum.MainThread"/> it will process on the main thread. If there is not a parent or grandparent node set to something other than inherit, the node will belong to the <i>default thread group</i>. This default group will process on the main thread and its group order is 0.</para>
    /// <para>During processing in a sub-thread, accessing most functions in nodes outside the thread group is forbidden (and it will result in an error in debug mode). Use <see cref="Godot.GodotObject.CallDeferred(StringName, Variant[])"/>, <see cref="Godot.Node.CallThreadSafe(StringName, Variant[])"/>, <see cref="Godot.Node.CallDeferredThreadGroup(StringName, Variant[])"/> and the likes in order to communicate from the thread groups to the main thread (or to other thread groups).</para>
    /// <para>To better understand process thread groups, the idea is that any node set to any other value than <see cref="Godot.Node.ProcessThreadGroupEnum.Inherit"/> will include any child (and grandchild) nodes set to inherit into its process thread group. This means that the processing of all the nodes in the group will happen together, at the same time as the node including them.</para>
    /// </summary>
    public Node.ProcessThreadGroupEnum ProcessThreadGroup
    {
        get
        {
            return GetProcessThreadGroup();
        }
        set
        {
            SetProcessThreadGroup(value);
        }
    }

    /// <summary>
    /// <para>Change the process thread group order. Groups with a lesser order will process before groups with a greater order. This is useful when a large amount of nodes process in sub thread and, afterwards, another group wants to collect their result in the main thread, as an example.</para>
    /// </summary>
    public int ProcessThreadGroupOrder
    {
        get
        {
            return GetProcessThreadGroupOrder();
        }
        set
        {
            SetProcessThreadGroupOrder(value);
        }
    }

    /// <summary>
    /// <para>Set whether the current thread group will process messages (calls to <see cref="Godot.Node.CallDeferredThreadGroup(StringName, Variant[])"/> on threads), and whether it wants to receive them during regular process or physics process callbacks.</para>
    /// </summary>
    public Node.ProcessThreadMessagesEnum ProcessThreadMessages
    {
        get
        {
            return GetProcessThreadMessages();
        }
        set
        {
            SetProcessThreadMessages(value);
        }
    }

    /// <summary>
    /// <para>The physics interpolation mode to use for this node. Only effective if <c>ProjectSettings.physics/common/physics_interpolation</c> or <see cref="Godot.SceneTree.PhysicsInterpolation"/> is <see langword="true"/>.</para>
    /// <para>By default, nodes inherit the physics interpolation mode from their parent. This property can enable or disable physics interpolation individually for each node, regardless of their parents' physics interpolation mode.</para>
    /// <para><b>Note:</b> Some node types like <see cref="Godot.VehicleWheel3D"/> have physics interpolation disabled by default, as they rely on their own custom solution.</para>
    /// <para><b>Note:</b> When teleporting a node to a distant position, it's recommended to temporarily disable interpolation with <see cref="Godot.Node.ResetPhysicsInterpolation()"/> <i>after</i> moving the node. This avoids creating a visual streak between the old and new positions.</para>
    /// </summary>
    public Node.PhysicsInterpolationModeEnum PhysicsInterpolationMode
    {
        get
        {
            return GetPhysicsInterpolationMode();
        }
        set
        {
            SetPhysicsInterpolationMode(value);
        }
    }

    /// <summary>
    /// <para>Defines if any text should automatically change to its translated version depending on the current locale (for nodes such as <see cref="Godot.Label"/>, <see cref="Godot.RichTextLabel"/>, <see cref="Godot.Window"/>, etc.). Also decides if the node's strings should be parsed for translation template generation.</para>
    /// <para><b>Note:</b> For the root node, auto translate mode can also be set via <c>ProjectSettings.internationalization/rendering/root_node_auto_translate</c>.</para>
    /// </summary>
    public Node.AutoTranslateModeEnum AutoTranslateMode
    {
        get
        {
            return GetAutoTranslateMode();
        }
        set
        {
            SetAutoTranslateMode(value);
        }
    }

    /// <summary>
    /// <para>An optional description to the node. It will be displayed as a tooltip when hovering over the node in the editor's Scene dock.</para>
    /// </summary>
    public string EditorDescription
    {
        get
        {
            return GetEditorDescription();
        }
        set
        {
            SetEditorDescription(value);
        }
    }

    private static readonly System.Type CachedType = typeof(Node);

    private static readonly StringName NativeName = "Node";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public Node() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal Node(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal Node(bool memoryOwn) : base(memoryOwn) { }

    /// <summary>
    /// <para>Called when the node enters the <see cref="Godot.SceneTree"/> (e.g. upon instantiating, scene changing, or after calling <see cref="Godot.Node.AddChild(Node, bool, Node.InternalMode)"/> in a script). If the node has children, its <see cref="Godot.Node._EnterTree()"/> callback will be called first, and then that of the children.</para>
    /// <para>Corresponds to the <see cref="Godot.Node.NotificationEnterTree"/> notification in <see cref="Godot.GodotObject._Notification(int)"/>.</para>
    /// </summary>
    public virtual void _EnterTree()
    {
    }

    /// <summary>
    /// <para>Called when the node is about to leave the <see cref="Godot.SceneTree"/> (e.g. upon freeing, scene changing, or after calling <see cref="Godot.Node.RemoveChild(Node)"/> in a script). If the node has children, its <see cref="Godot.Node._ExitTree()"/> callback will be called last, after all its children have left the tree.</para>
    /// <para>Corresponds to the <see cref="Godot.Node.NotificationExitTree"/> notification in <see cref="Godot.GodotObject._Notification(int)"/> and signal <see cref="Godot.Node.TreeExiting"/>. To get notified when the node has already left the active tree, connect to the <see cref="Godot.Node.TreeExited"/>.</para>
    /// </summary>
    public virtual void _ExitTree()
    {
    }

    /// <summary>
    /// <para>The elements in the array returned from this method are displayed as warnings in the Scene dock if the script that overrides it is a <c>tool</c> script, and accessibility warnings are enabled in the editor settings.</para>
    /// <para>Returning an empty array produces no warnings.</para>
    /// </summary>
    public virtual string[] _GetAccessibilityConfigurationWarnings()
    {
        return default;
    }

    /// <summary>
    /// <para>The elements in the array returned from this method are displayed as warnings in the Scene dock if the script that overrides it is a <c>tool</c> script.</para>
    /// <para>Returning an empty array produces no warnings.</para>
    /// <para>Call <see cref="Godot.Node.UpdateConfigurationWarnings()"/> when the warnings need to be updated for this node.</para>
    /// <para><code>
    /// @export var energy = 0:
    /// 	set(value):
    /// 		energy = value
    /// 		update_configuration_warnings()
    /// 
    /// func _get_configuration_warnings():
    /// 	if energy &lt; 0:
    /// 		return ["Energy must be 0 or greater."]
    /// 	else:
    /// 		return []
    /// </code></para>
    /// </summary>
    public virtual string[] _GetConfigurationWarnings()
    {
        return default;
    }

    /// <summary>
    /// <para>Called during accessibility information updates to determine the currently focused sub-element, should return a sub-element RID or the value returned by <see cref="Godot.Node.GetAccessibilityElement()"/>.</para>
    /// </summary>
    public virtual Rid _GetFocusedAccessibilityElement()
    {
        return default;
    }

    /// <summary>
    /// <para>Called when there is an input event. The input event propagates up through the node tree until a node consumes it.</para>
    /// <para>It is only called if input processing is enabled, which is done automatically if this method is overridden, and can be toggled with <see cref="Godot.Node.SetProcessInput(bool)"/>.</para>
    /// <para>To consume the input event and stop it propagating further to other nodes, <see cref="Godot.Viewport.SetInputAsHandled()"/> can be called.</para>
    /// <para>For gameplay input, <see cref="Godot.Node._UnhandledInput(InputEvent)"/> and <see cref="Godot.Node._UnhandledKeyInput(InputEvent)"/> are usually a better fit as they allow the GUI to intercept the events first.</para>
    /// <para><b>Note:</b> This method is only called if the node is present in the scene tree (i.e. if it's not an orphan).</para>
    /// </summary>
    public virtual void _Input(InputEvent @event)
    {
    }

    /// <summary>
    /// <para>Called once on each physics tick, and allows Nodes to synchronize their logic with physics ticks. <paramref name="delta"/> is the logical time between physics ticks in seconds and is equal to <see cref="Godot.Engine.TimeScale"/> / <see cref="Godot.Engine.PhysicsTicksPerSecond"/>.</para>
    /// <para>It is only called if physics processing is enabled for this Node, which is done automatically if this method is overridden, and can be toggled with <see cref="Godot.Node.SetPhysicsProcess(bool)"/>.</para>
    /// <para>Processing happens in order of <see cref="Godot.Node.ProcessPhysicsPriority"/>, lower priority values are called first. Nodes with the same priority are processed in tree order, or top to bottom as seen in the editor (also known as pre-order traversal).</para>
    /// <para>Corresponds to the <see cref="Godot.Node.NotificationPhysicsProcess"/> notification in <see cref="Godot.GodotObject._Notification(int)"/>.</para>
    /// <para><b>Note:</b> This method is only called if the node is present in the scene tree (i.e. if it's not an orphan).</para>
    /// <para><b>Note:</b> Accumulated <paramref name="delta"/> may diverge from real world seconds.</para>
    /// </summary>
    public virtual void _PhysicsProcess(double delta)
    {
    }

    /// <summary>
    /// <para>Called on each idle frame, prior to rendering, and after physics ticks have been processed. <paramref name="delta"/> is the time between frames in seconds.</para>
    /// <para>It is only called if processing is enabled for this Node, which is done automatically if this method is overridden, and can be toggled with <see cref="Godot.Node.SetProcess(bool)"/>.</para>
    /// <para>Processing happens in order of <see cref="Godot.Node.ProcessPriority"/>, lower priority values are called first. Nodes with the same priority are processed in tree order, or top to bottom as seen in the editor (also known as pre-order traversal).</para>
    /// <para>Corresponds to the <see cref="Godot.Node.NotificationProcess"/> notification in <see cref="Godot.GodotObject._Notification(int)"/>.</para>
    /// <para><b>Note:</b> This method is only called if the node is present in the scene tree (i.e. if it's not an orphan).</para>
    /// <para><b>Note:</b> When the engine is struggling and the frame rate is lowered, <paramref name="delta"/> will increase. When <paramref name="delta"/> is increased, it's capped at a maximum of <see cref="Godot.Engine.TimeScale"/> * <see cref="Godot.Engine.MaxPhysicsStepsPerFrame"/> / <see cref="Godot.Engine.PhysicsTicksPerSecond"/>. As a result, accumulated <paramref name="delta"/> may not represent real world time.</para>
    /// <para><b>Note:</b> When <c>--fixed-fps</c> is enabled or the engine is running in Movie Maker mode (see <see cref="Godot.MovieWriter"/>), process <paramref name="delta"/> will always be the same for every frame, regardless of how much time the frame took to render.</para>
    /// <para><b>Note:</b> Frame delta may be post-processed by <see cref="Godot.OS.DeltaSmoothing"/> if this is enabled for the project.</para>
    /// </summary>
    public virtual void _Process(double delta)
    {
    }

    /// <summary>
    /// <para>Called when the node is "ready", i.e. when both the node and its children have entered the scene tree. If the node has children, their <see cref="Godot.Node._Ready()"/> callbacks get triggered first, and the parent node will receive the ready notification afterwards.</para>
    /// <para>Corresponds to the <see cref="Godot.Node.NotificationReady"/> notification in <see cref="Godot.GodotObject._Notification(int)"/>. See also the <c>@onready</c> annotation for variables.</para>
    /// <para>Usually used for initialization. For even earlier initialization, <see cref="Godot.GodotObject.GodotObject()"/> may be used. See also <see cref="Godot.Node._EnterTree()"/>.</para>
    /// <para><b>Note:</b> This method may be called only once for each node. After removing a node from the scene tree and adding it again, <see cref="Godot.Node._Ready()"/> will <b>not</b> be called a second time. This can be bypassed by requesting another call with <see cref="Godot.Node.RequestReady()"/>, which may be called anywhere before adding the node again.</para>
    /// </summary>
    public virtual void _Ready()
    {
    }

    /// <summary>
    /// <para>Called when an <see cref="Godot.InputEventKey"/>, <see cref="Godot.InputEventShortcut"/>, or <see cref="Godot.InputEventJoypadButton"/> hasn't been consumed by <see cref="Godot.Node._Input(InputEvent)"/> or any GUI <see cref="Godot.Control"/> item. It is called before <see cref="Godot.Node._UnhandledKeyInput(InputEvent)"/> and <see cref="Godot.Node._UnhandledInput(InputEvent)"/>. The input event propagates up through the node tree until a node consumes it.</para>
    /// <para>It is only called if shortcut processing is enabled, which is done automatically if this method is overridden, and can be toggled with <see cref="Godot.Node.SetProcessShortcutInput(bool)"/>.</para>
    /// <para>To consume the input event and stop it propagating further to other nodes, <see cref="Godot.Viewport.SetInputAsHandled()"/> can be called.</para>
    /// <para>This method can be used to handle shortcuts. For generic GUI events, use <see cref="Godot.Node._Input(InputEvent)"/> instead. Gameplay events should usually be handled with either <see cref="Godot.Node._UnhandledInput(InputEvent)"/> or <see cref="Godot.Node._UnhandledKeyInput(InputEvent)"/>.</para>
    /// <para><b>Note:</b> This method is only called if the node is present in the scene tree (i.e. if it's not orphan).</para>
    /// </summary>
    public virtual void _ShortcutInput(InputEvent @event)
    {
    }

    /// <summary>
    /// <para>Called when an <see cref="Godot.InputEvent"/> hasn't been consumed by <see cref="Godot.Node._Input(InputEvent)"/> or any GUI <see cref="Godot.Control"/> item. It is called after <see cref="Godot.Node._ShortcutInput(InputEvent)"/> and after <see cref="Godot.Node._UnhandledKeyInput(InputEvent)"/>. The input event propagates up through the node tree until a node consumes it.</para>
    /// <para>It is only called if unhandled input processing is enabled, which is done automatically if this method is overridden, and can be toggled with <see cref="Godot.Node.SetProcessUnhandledInput(bool)"/>.</para>
    /// <para>To consume the input event and stop it propagating further to other nodes, <see cref="Godot.Viewport.SetInputAsHandled()"/> can be called.</para>
    /// <para>For gameplay input, this method is usually a better fit than <see cref="Godot.Node._Input(InputEvent)"/>, as GUI events need a higher priority. For keyboard shortcuts, consider using <see cref="Godot.Node._ShortcutInput(InputEvent)"/> instead, as it is called before this method. Finally, to handle keyboard events, consider using <see cref="Godot.Node._UnhandledKeyInput(InputEvent)"/> for performance reasons.</para>
    /// <para><b>Note:</b> This method is only called if the node is present in the scene tree (i.e. if it's not an orphan).</para>
    /// </summary>
    public virtual void _UnhandledInput(InputEvent @event)
    {
    }

    /// <summary>
    /// <para>Called when an <see cref="Godot.InputEventKey"/> hasn't been consumed by <see cref="Godot.Node._Input(InputEvent)"/> or any GUI <see cref="Godot.Control"/> item. It is called after <see cref="Godot.Node._ShortcutInput(InputEvent)"/> but before <see cref="Godot.Node._UnhandledInput(InputEvent)"/>. The input event propagates up through the node tree until a node consumes it.</para>
    /// <para>It is only called if unhandled key input processing is enabled, which is done automatically if this method is overridden, and can be toggled with <see cref="Godot.Node.SetProcessUnhandledKeyInput(bool)"/>.</para>
    /// <para>To consume the input event and stop it propagating further to other nodes, <see cref="Godot.Viewport.SetInputAsHandled()"/> can be called.</para>
    /// <para>This method can be used to handle Unicode character input with Alt, Alt + Ctrl, and Alt + Shift modifiers, after shortcuts were handled.</para>
    /// <para>For gameplay input, this and <see cref="Godot.Node._UnhandledInput(InputEvent)"/> are usually a better fit than <see cref="Godot.Node._Input(InputEvent)"/>, as GUI events should be handled first. This method also performs better than <see cref="Godot.Node._UnhandledInput(InputEvent)"/>, since unrelated events such as <see cref="Godot.InputEventMouseMotion"/> are automatically filtered. For shortcuts, consider using <see cref="Godot.Node._ShortcutInput(InputEvent)"/> instead.</para>
    /// <para><b>Note:</b> This method is only called if the node is present in the scene tree (i.e. if it's not an orphan).</para>
    /// </summary>
    public virtual void _UnhandledKeyInput(InputEvent @event)
    {
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PrintOrphanNodes, 3218959716ul);

    /// <summary>
    /// <para>Prints all orphan nodes (nodes outside the <see cref="Godot.SceneTree"/>). Useful for debugging.</para>
    /// <para><b>Note:</b> This method only works in debug builds. It does nothing in a project exported in release mode.</para>
    /// </summary>
    public static void PrintOrphanNodes()
    {
        NativeCalls.godot_icall_0_880(MethodBind0);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOrphanNodeIds, 2915620761ul);

    /// <summary>
    /// <para>Returns object IDs of all orphan nodes (nodes outside the <see cref="Godot.SceneTree"/>). Used for debugging.</para>
    /// <para><b>Note:</b> <see cref="Godot.Node.GetOrphanNodeIds()"/> only works in debug builds. When called in a project exported in release mode, <see cref="Godot.Node.GetOrphanNodeIds()"/> will return an empty array.</para>
    /// </summary>
    public static Godot.Collections.Array<int> GetOrphanNodeIds()
    {
        return new Godot.Collections.Array<int>(NativeCalls.godot_icall_0_881(MethodBind1));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddSibling, 2570952461ul);

    /// <summary>
    /// <para>Adds a <paramref name="sibling"/> node to this node's parent, and moves the added sibling right below this node.</para>
    /// <para>If <paramref name="forceReadableName"/> is <see langword="true"/>, improves the readability of the added <paramref name="sibling"/>. If not named, the <paramref name="sibling"/> is renamed to its type, and if it shares <see cref="Godot.Node.Name"/> with a sibling, a number is suffixed more appropriately. This operation is very slow. As such, it is recommended leaving this to <see langword="false"/>, which assigns a dummy name featuring <c>@</c> in both situations.</para>
    /// <para>Use <see cref="Godot.Node.AddChild(Node, bool, Node.InternalMode)"/> instead of this method if you don't need the child node to be added below a specific node in the list of children.</para>
    /// <para><b>Note:</b> If this node is internal, the added sibling will be internal too (see <see cref="Godot.Node.AddChild(Node, bool, Node.InternalMode)"/>'s <c>internal</c> parameter).</para>
    /// </summary>
    public void AddSibling(Node sibling, bool forceReadableName = false)
    {
        NativeCalls.godot_icall_2_508(MethodBind2, GodotObject.GetPtr(this), GodotObject.GetPtr(sibling), forceReadableName.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetName, 3304788590ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetName(StringName name)
    {
        NativeCalls.godot_icall_1_64(MethodBind3, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetName, 2002593661ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public StringName GetName()
    {
        return NativeCalls.godot_icall_0_65(MethodBind4, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddChild, 3863233950ul);

    /// <summary>
    /// <para>Adds a child <paramref name="node"/>. Nodes can have any number of children, but every child must have a unique name. Child nodes are automatically deleted when the parent node is deleted, so an entire scene can be removed by deleting its topmost node.</para>
    /// <para>If <paramref name="forceReadableName"/> is <see langword="true"/>, improves the readability of the added <paramref name="node"/>. If not named, the <paramref name="node"/> is renamed to its type, and if it shares <see cref="Godot.Node.Name"/> with a sibling, a number is suffixed more appropriately. This operation is very slow. As such, it is recommended leaving this to <see langword="false"/>, which assigns a dummy name featuring <c>@</c> in both situations.</para>
    /// <para>If <paramref name="internal"/> is different than <see cref="Godot.Node.InternalMode.Disabled"/>, the child will be added as internal node. These nodes are ignored by methods like <see cref="Godot.Node.GetChildren(bool)"/>, unless their parameter <c>include_internal</c> is <see langword="true"/>. It also prevents these nodes being duplicated with their parent. The intended usage is to hide the internal nodes from the user, so the user won't accidentally delete or modify them. Used by some GUI nodes, e.g. <see cref="Godot.ColorPicker"/>.</para>
    /// <para><b>Note:</b> If <paramref name="node"/> already has a parent, this method will fail. Use <see cref="Godot.Node.RemoveChild(Node)"/> first to remove <paramref name="node"/> from its current parent. For example:</para>
    /// <para><code>
    /// Node childNode = GetChild(0);
    /// if (childNode.GetParent() != null)
    /// {
    /// 	childNode.GetParent().RemoveChild(childNode);
    /// }
    /// AddChild(childNode);
    /// </code></para>
    /// <para>If you need the child node to be added below a specific node in the list of children, use <see cref="Godot.Node.AddSibling(Node, bool)"/> instead of this method.</para>
    /// <para><b>Note:</b> If you want a child to be persisted to a <see cref="Godot.PackedScene"/>, you must set <see cref="Godot.Node.Owner"/> in addition to calling <see cref="Godot.Node.AddChild(Node, bool, Node.InternalMode)"/>. This is typically relevant for <a href="$DOCS_URL/tutorials/plugins/running_code_in_the_editor.html">tool scripts</a> and <a href="$DOCS_URL/tutorials/plugins/editor/index.html">editor plugins</a>. If <see cref="Godot.Node.AddChild(Node, bool, Node.InternalMode)"/> is called without setting <see cref="Godot.Node.Owner"/>, the newly added <see cref="Godot.Node"/> will not be visible in the scene tree, though it will be visible in the 2D/3D view.</para>
    /// </summary>
    public void AddChild(Node node, bool forceReadableName = false, Node.InternalMode @internal = (Node.InternalMode)(0))
    {
        NativeCalls.godot_icall_3_882(MethodBind5, GodotObject.GetPtr(this), GodotObject.GetPtr(node), forceReadableName.ToGodotBool(), (int)@internal);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveChild, 1078189570ul);

    /// <summary>
    /// <para>Removes a child <paramref name="node"/>. The <paramref name="node"/>, along with its children, are <b>not</b> deleted. To delete a node, see <see cref="Godot.Node.QueueFree()"/>.</para>
    /// <para><b>Note:</b> When this node is inside the tree, this method sets the <see cref="Godot.Node.Owner"/> of the removed <paramref name="node"/> (or its descendants) to <see langword="null"/>, if their <see cref="Godot.Node.Owner"/> is no longer an ancestor (see <see cref="Godot.Node.IsAncestorOf(Node)"/>).</para>
    /// </summary>
    public void RemoveChild(Node node)
    {
        NativeCalls.godot_icall_1_56(MethodBind6, GodotObject.GetPtr(this), GodotObject.GetPtr(node));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Reparent, 3685795103ul);

    /// <summary>
    /// <para>Changes the parent of this <see cref="Godot.Node"/> to the <paramref name="newParent"/>. The node needs to already have a parent. The node's <see cref="Godot.Node.Owner"/> is preserved if its owner is still reachable from the new location (i.e., the node is still a descendant of the new parent after the operation).</para>
    /// <para>If <paramref name="keepGlobalTransform"/> is <see langword="true"/>, the node's global transform will be preserved if supported. <see cref="Godot.Node2D"/>, <see cref="Godot.Node3D"/> and <see cref="Godot.Control"/> support this argument (but <see cref="Godot.Control"/> keeps only position).</para>
    /// </summary>
    public void Reparent(Node newParent, bool keepGlobalTransform = true)
    {
        NativeCalls.godot_icall_2_508(MethodBind7, GodotObject.GetPtr(this), GodotObject.GetPtr(newParent), keepGlobalTransform.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetChildCount, 894402480ul);

    /// <summary>
    /// <para>Returns the number of children of this node.</para>
    /// <para>If <paramref name="includeInternal"/> is <see langword="false"/>, internal children are not counted (see <see cref="Godot.Node.AddChild(Node, bool, Node.InternalMode)"/>'s <c>internal</c> parameter).</para>
    /// </summary>
    public int GetChildCount(bool includeInternal = false)
    {
        return NativeCalls.godot_icall_1_198(MethodBind8, GodotObject.GetPtr(this), includeInternal.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetChildren, 873284517ul);

    /// <summary>
    /// <para>Returns all children of this node inside an <see cref="Godot.Collections.Array"/>.</para>
    /// <para>If <paramref name="includeInternal"/> is <see langword="false"/>, excludes internal children from the returned array (see <see cref="Godot.Node.AddChild(Node, bool, Node.InternalMode)"/>'s <c>internal</c> parameter).</para>
    /// </summary>
    public Godot.Collections.Array<Node> GetChildren(bool includeInternal = false)
    {
        return new Godot.Collections.Array<Node>(NativeCalls.godot_icall_1_546(MethodBind9, GodotObject.GetPtr(this), includeInternal.ToGodotBool()));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetChild, 541253412ul);

    /// <summary>
    /// <para>Fetches a child node by its index. Each child node has an index relative to its siblings (see <see cref="Godot.Node.GetIndex(bool)"/>). The first child is at index 0. Negative values can also be used to start from the end of the list. This method can be used in combination with <see cref="Godot.Node.GetChildCount(bool)"/> to iterate over this node's children. If no child exists at the given index, this method returns <see langword="null"/> and an error is generated.</para>
    /// <para>If <paramref name="includeInternal"/> is <see langword="false"/>, internal children are ignored (see <see cref="Godot.Node.AddChild(Node, bool, Node.InternalMode)"/>'s <c>internal</c> parameter).</para>
    /// <para><code>
    /// # Assuming the following are children of this node, in order:
    /// # First, Middle, Last.
    /// 
    /// var a = get_child(0).name  # a is "First"
    /// var b = get_child(1).name  # b is "Middle"
    /// var b = get_child(2).name  # b is "Last"
    /// var c = get_child(-1).name # c is "Last"
    /// </code></para>
    /// <para><b>Note:</b> To fetch a node by <see cref="Godot.NodePath"/>, use <see cref="Godot.Node.GetNode(NodePath)"/>.</para>
    /// </summary>
    public Node GetChild(int idx, bool includeInternal = false)
    {
        return (Node)NativeCalls.godot_icall_2_883(MethodBind10, GodotObject.GetPtr(this), idx, includeInternal.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasNode, 861721659ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the <paramref name="path"/> points to a valid node. See also <see cref="Godot.Node.GetNode(NodePath)"/>.</para>
    /// </summary>
    public bool HasNode(NodePath path)
    {
        return NativeCalls.godot_icall_1_136(MethodBind11, GodotObject.GetPtr(this), (godot_node_path)(path?.NativeValue ?? default)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNode, 2734337346ul);

    /// <summary>
    /// <para>Fetches a node. The <see cref="Godot.NodePath"/> can either be a relative path (from this node), or an absolute path (from the <see cref="Godot.SceneTree.Root"/>) to a node. If <paramref name="path"/> does not point to a valid node, generates an error and returns <see langword="null"/>. Attempts to access methods on the return value will result in an <i>"Attempt to call &lt;method&gt; on a null instance."</i> error.</para>
    /// <para><b>Note:</b> Fetching by absolute path only works when the node is inside the scene tree (see <see cref="Godot.Node.IsInsideTree()"/>).</para>
    /// <para><b>Example:</b> Assume this method is called from the Character node, inside the following tree:</para>
    /// <para><code>
    ///  ┖╴root
    ///     ┠╴Character (you are here!)
    ///     ┃  ┠╴Sword
    ///     ┃  ┖╴Backpack
    ///     ┃     ┖╴Dagger
    ///     ┠╴MyGame
    ///     ┖╴Swamp
    ///        ┠╴Alligator
    ///        ┠╴Mosquito
    ///        ┖╴Goblin
    /// </code></para>
    /// <para>The following calls will return a valid node:</para>
    /// <para><code>
    /// GetNode("Sword");
    /// GetNode("Backpack/Dagger");
    /// GetNode("../Swamp/Alligator");
    /// GetNode("/root/MyGame");
    /// </code></para>
    /// </summary>
    public Node GetNode(NodePath path)
    {
        return (Node)NativeCalls.godot_icall_1_884(MethodBind12, GodotObject.GetPtr(this), (godot_node_path)(path?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNodeOrNull, 2734337346ul);

    /// <summary>
    /// <para>Fetches a node by <see cref="Godot.NodePath"/>. Similar to <see cref="Godot.Node.GetNode(NodePath)"/>, but does not generate an error if <paramref name="path"/> does not point to a valid node.</para>
    /// </summary>
    public Node GetNodeOrNull(NodePath path)
    {
        return (Node)NativeCalls.godot_icall_1_884(MethodBind13, GodotObject.GetPtr(this), (godot_node_path)(path?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetParent, 3160264692ul);

    /// <summary>
    /// <para>Returns this node's parent node, or <see langword="null"/> if the node doesn't have a parent.</para>
    /// </summary>
    public Node GetParent()
    {
        return (Node)NativeCalls.godot_icall_0_53(MethodBind14, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FindChild, 2008217037ul);

    /// <summary>
    /// <para>Finds the first descendant of this node whose <see cref="Godot.Node.Name"/> matches <paramref name="pattern"/>, returning <see langword="null"/> if no match is found. The matching is done against node names, <i>not</i> their paths, through <c>String.match</c>. As such, it is case-sensitive, <c>"*"</c> matches zero or more characters, and <c>"?"</c> matches any single character.</para>
    /// <para>If <paramref name="recursive"/> is <see langword="false"/>, only this node's direct children are checked. Nodes are checked in tree order, so this node's first direct child is checked first, then its own direct children, etc., before moving to the second direct child, and so on. Internal children are also included in the search (see <c>internal</c> parameter in <see cref="Godot.Node.AddChild(Node, bool, Node.InternalMode)"/>).</para>
    /// <para>If <paramref name="owned"/> is <see langword="true"/>, only descendants with a valid <see cref="Godot.Node.Owner"/> node are checked.</para>
    /// <para><b>Note:</b> This method can be very slow. Consider storing a reference to the found node in a variable. Alternatively, use <see cref="Godot.Node.GetNode(NodePath)"/> with unique names (see <see cref="Godot.Node.UniqueNameInOwner"/>).</para>
    /// <para><b>Note:</b> To find all descendant nodes matching a pattern or a class type, see <see cref="Godot.Node.FindChildren(string, string, bool, bool)"/>.</para>
    /// </summary>
    public Node FindChild(string pattern, bool recursive = true, bool owned = true)
    {
        return (Node)NativeCalls.godot_icall_3_885(MethodBind15, GodotObject.GetPtr(this), pattern, recursive.ToGodotBool(), owned.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FindChildren, 2560337219ul);

    /// <summary>
    /// <para>Finds all descendants of this node whose names match <paramref name="pattern"/>, returning an empty <see cref="Godot.Collections.Array"/> if no match is found. The matching is done against node names, <i>not</i> their paths, through <c>String.match</c>. As such, it is case-sensitive, <c>"*"</c> matches zero or more characters, and <c>"?"</c> matches any single character.</para>
    /// <para>If <paramref name="type"/> is not empty, only ancestors inheriting from <paramref name="type"/> are included (see <see cref="Godot.GodotObject.IsClass(string)"/>).</para>
    /// <para>If <paramref name="recursive"/> is <see langword="false"/>, only this node's direct children are checked. Nodes are checked in tree order, so this node's first direct child is checked first, then its own direct children, etc., before moving to the second direct child, and so on. Internal children are also included in the search (see <c>internal</c> parameter in <see cref="Godot.Node.AddChild(Node, bool, Node.InternalMode)"/>).</para>
    /// <para>If <paramref name="owned"/> is <see langword="true"/>, only descendants with a valid <see cref="Godot.Node.Owner"/> node are checked.</para>
    /// <para><b>Note:</b> This method can be very slow. Consider storing references to the found nodes in a variable.</para>
    /// <para><b>Note:</b> To find a single descendant node matching a pattern, see <see cref="Godot.Node.FindChild(string, bool, bool)"/>.</para>
    /// </summary>
    public Godot.Collections.Array<Node> FindChildren(string pattern, string type = "", bool recursive = true, bool owned = true)
    {
        return new Godot.Collections.Array<Node>(NativeCalls.godot_icall_4_886(MethodBind16, GodotObject.GetPtr(this), pattern, type, recursive.ToGodotBool(), owned.ToGodotBool()));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FindParent, 1140089439ul);

    /// <summary>
    /// <para>Finds the first ancestor of this node whose <see cref="Godot.Node.Name"/> matches <paramref name="pattern"/>, returning <see langword="null"/> if no match is found. The matching is done through <c>String.match</c>. As such, it is case-sensitive, <c>"*"</c> matches zero or more characters, and <c>"?"</c> matches any single character. See also <see cref="Godot.Node.FindChild(string, bool, bool)"/> and <see cref="Godot.Node.FindChildren(string, string, bool, bool)"/>.</para>
    /// <para><b>Note:</b> As this method walks upwards in the scene tree, it can be slow in large, deeply nested nodes. Consider storing a reference to the found node in a variable. Alternatively, use <see cref="Godot.Node.GetNode(NodePath)"/> with unique names (see <see cref="Godot.Node.UniqueNameInOwner"/>).</para>
    /// </summary>
    public Node FindParent(string pattern)
    {
        return (Node)NativeCalls.godot_icall_1_55(MethodBind17, GodotObject.GetPtr(this), pattern);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasNodeAndResource, 861721659ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if <paramref name="path"/> points to a valid node and its subnames point to a valid <see cref="Godot.Resource"/>, e.g. <c>Area2D/CollisionShape2D:shape</c>. Properties that are not <see cref="Godot.Resource"/> types (such as nodes or other <see cref="Godot.Variant"/> types) are not considered. See also <see cref="Godot.Node.GetNodeAndResource(NodePath)"/>.</para>
    /// </summary>
    public bool HasNodeAndResource(NodePath path)
    {
        return NativeCalls.godot_icall_1_136(MethodBind18, GodotObject.GetPtr(this), (godot_node_path)(path?.NativeValue ?? default)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNodeAndResource, 502563882ul);

    /// <summary>
    /// <para>Fetches a node and its most nested resource as specified by the <see cref="Godot.NodePath"/>'s subname. Returns an <see cref="Godot.Collections.Array"/> of size <c>3</c> where:</para>
    /// <para>- Element <c>0</c> is the <see cref="Godot.Node"/>, or <see langword="null"/> if not found;</para>
    /// <para>- Element <c>1</c> is the subname's last nested <see cref="Godot.Resource"/>, or <see langword="null"/> if not found;</para>
    /// <para>- Element <c>2</c> is the remaining <see cref="Godot.NodePath"/>, referring to an existing, non-<see cref="Godot.Resource"/> property (see <see cref="Godot.GodotObject.GetIndexed(NodePath)"/>).</para>
    /// <para><b>Example:</b> Assume that the child's <see cref="Godot.Sprite2D.Texture"/> has been assigned an <see cref="Godot.AtlasTexture"/>:</para>
    /// <para><code>
    /// var a = GetNodeAndResource(NodePath("Area2D/Sprite2D"));
    /// GD.Print(a[0].Name); // Prints Sprite2D
    /// GD.Print(a[1]);      // Prints &lt;null&gt;
    /// GD.Print(a[2]);      // Prints ^"
    /// 
    /// var b = GetNodeAndResource(NodePath("Area2D/Sprite2D:texture:atlas"));
    /// GD.Print(b[0].name);        // Prints Sprite2D
    /// GD.Print(b[1].get_class()); // Prints AtlasTexture
    /// GD.Print(b[2]);             // Prints ^""
    /// 
    /// var c = GetNodeAndResource(NodePath("Area2D/Sprite2D:texture:atlas:region"));
    /// GD.Print(c[0].name);        // Prints Sprite2D
    /// GD.Print(c[1].get_class()); // Prints AtlasTexture
    /// GD.Print(c[2]);             // Prints ^":region"
    /// </code></para>
    /// </summary>
    public Godot.Collections.Array GetNodeAndResource(NodePath path)
    {
        return NativeCalls.godot_icall_1_887(MethodBind19, GodotObject.GetPtr(this), (godot_node_path)(path?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsInsideTree, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if this node is currently inside a <see cref="Godot.SceneTree"/>. See also <see cref="Godot.Node.GetTree()"/>.</para>
    /// </summary>
    public bool IsInsideTree()
    {
        return NativeCalls.godot_icall_0_15(MethodBind20, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsPartOfEditedScene, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the node is part of the scene currently opened in the editor.</para>
    /// </summary>
    public bool IsPartOfEditedScene()
    {
        return NativeCalls.godot_icall_0_15(MethodBind21, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsAncestorOf, 3093956946ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the given <paramref name="node"/> is a direct or indirect child of this node.</para>
    /// </summary>
    public bool IsAncestorOf(Node node)
    {
        return NativeCalls.godot_icall_1_176(MethodBind22, GodotObject.GetPtr(this), GodotObject.GetPtr(node)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsGreaterThan, 3093956946ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the given <paramref name="node"/> occurs later in the scene hierarchy than this node. A node occurring later is usually processed last.</para>
    /// </summary>
    public bool IsGreaterThan(Node node)
    {
        return NativeCalls.godot_icall_1_176(MethodBind23, GodotObject.GetPtr(this), GodotObject.GetPtr(node)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPath, 4075236667ul);

    /// <summary>
    /// <para>Returns the node's absolute path, relative to the <see cref="Godot.SceneTree.Root"/>. If the node is not inside the scene tree, this method fails and returns an empty <see cref="Godot.NodePath"/>.</para>
    /// </summary>
    public NodePath GetPath()
    {
        return NativeCalls.godot_icall_0_124(MethodBind24, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPathTo, 498846349ul);

    /// <summary>
    /// <para>Returns the relative <see cref="Godot.NodePath"/> from this node to the specified <paramref name="node"/>. Both nodes must be in the same <see cref="Godot.SceneTree"/> or scene hierarchy, otherwise this method fails and returns an empty <see cref="Godot.NodePath"/>.</para>
    /// <para>If <paramref name="useUniquePath"/> is <see langword="true"/>, returns the shortest path accounting for this node's unique name (see <see cref="Godot.Node.UniqueNameInOwner"/>).</para>
    /// <para><b>Note:</b> If you get a relative path which starts from a unique node, the path may be longer than a normal relative path, due to the addition of the unique node's name.</para>
    /// </summary>
    public NodePath GetPathTo(Node node, bool useUniquePath = false)
    {
        return NativeCalls.godot_icall_2_650(MethodBind25, GodotObject.GetPtr(this), GodotObject.GetPtr(node), useUniquePath.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddToGroup, 3683006648ul);

    /// <summary>
    /// <para>Adds the node to the <paramref name="group"/>. Groups can be helpful to organize a subset of nodes, for example <c>"enemies"</c> or <c>"collectables"</c>. See notes in the description, and the group methods in <see cref="Godot.SceneTree"/>.</para>
    /// <para>If <paramref name="persistent"/> is <see langword="true"/>, the group will be stored when saved inside a <see cref="Godot.PackedScene"/>. All groups created and displayed in the Groups dock are persistent.</para>
    /// <para><b>Note:</b> To improve performance, the order of group names is <i>not</i> guaranteed and may vary between project runs. Therefore, do not rely on the group order.</para>
    /// <para><b>Note:</b> <see cref="Godot.SceneTree"/>'s group methods will <i>not</i> work on this node if not inside the tree (see <see cref="Godot.Node.IsInsideTree()"/>).</para>
    /// </summary>
    public void AddToGroup(StringName group, bool persistent = false)
    {
        NativeCalls.godot_icall_2_163(MethodBind26, GodotObject.GetPtr(this), (godot_string_name)(group?.NativeValue ?? default), persistent.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveFromGroup, 3304788590ul);

    /// <summary>
    /// <para>Removes the node from the given <paramref name="group"/>. Does nothing if the node is not in the <paramref name="group"/>. See also notes in the description, and the <see cref="Godot.SceneTree"/>'s group methods.</para>
    /// </summary>
    public void RemoveFromGroup(StringName group)
    {
        NativeCalls.godot_icall_1_64(MethodBind27, GodotObject.GetPtr(this), (godot_string_name)(group?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsInGroup, 2619796661ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if this node has been added to the given <paramref name="group"/>. See <see cref="Godot.Node.AddToGroup(StringName, bool)"/> and <see cref="Godot.Node.RemoveFromGroup(StringName)"/>. See also notes in the description, and the <see cref="Godot.SceneTree"/>'s group methods.</para>
    /// </summary>
    public bool IsInGroup(StringName group)
    {
        return NativeCalls.godot_icall_1_105(MethodBind28, GodotObject.GetPtr(this), (godot_string_name)(group?.NativeValue ?? default)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MoveChild, 3315886247ul);

    /// <summary>
    /// <para>Moves <paramref name="childNode"/> to the given index. A node's index is the order among its siblings. If <paramref name="toIndex"/> is negative, the index is counted from the end of the list. See also <see cref="Godot.Node.GetChild(int, bool)"/> and <see cref="Godot.Node.GetIndex(bool)"/>.</para>
    /// <para><b>Note:</b> The processing order of several engine callbacks (<see cref="Godot.Node._Ready()"/>, <see cref="Godot.Node._Process(double)"/>, etc.) and notifications sent through <see cref="Godot.Node.PropagateNotification(int)"/> is affected by tree order. <see cref="Godot.CanvasItem"/> nodes are also rendered in tree order. See also <see cref="Godot.Node.ProcessPriority"/>.</para>
    /// </summary>
    public void MoveChild(Node childNode, int toIndex)
    {
        NativeCalls.godot_icall_2_740(MethodBind29, GodotObject.GetPtr(this), GodotObject.GetPtr(childNode), toIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetGroups, 3995934104ul);

    /// <summary>
    /// <para>Returns an <see cref="Godot.Collections.Array"/> of group names that the node has been added to.</para>
    /// <para><b>Note:</b> To improve performance, the order of group names is <i>not</i> guaranteed and may vary between project runs. Therefore, do not rely on the group order.</para>
    /// <para><b>Note:</b> This method may also return some group names starting with an underscore (<c>_</c>). These are internally used by the engine. To avoid conflicts, do not use custom groups starting with underscores. To exclude internal groups, see the following code snippet:</para>
    /// <para><code>
    /// // Stores the node's non-internal groups only (as a List of StringNames).
    /// List&lt;string&gt; nonInternalGroups = new List&lt;string&gt;();
    /// foreach (string group in GetGroups())
    /// {
    /// 	if (!group.BeginsWith("_"))
    /// 		nonInternalGroups.Add(group);
    /// }
    /// </code></para>
    /// </summary>
    public Godot.Collections.Array<StringName> GetGroups()
    {
        return new Godot.Collections.Array<StringName>(NativeCalls.godot_icall_0_120(MethodBind30, GodotObject.GetPtr(this)));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetOwner, 1078189570ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetOwner(Node owner)
    {
        NativeCalls.godot_icall_1_56(MethodBind31, GodotObject.GetPtr(this), GodotObject.GetPtr(owner));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind32 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOwner, 3160264692ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Node GetOwner()
    {
        return (Node)NativeCalls.godot_icall_0_53(MethodBind32, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind33 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetIndex, 894402480ul);

    /// <summary>
    /// <para>Returns this node's order among its siblings. The first node's index is <c>0</c>. See also <see cref="Godot.Node.GetChild(int, bool)"/>.</para>
    /// <para>If <paramref name="includeInternal"/> is <see langword="false"/>, returns the index ignoring internal children. The first, non-internal child will have an index of <c>0</c> (see <see cref="Godot.Node.AddChild(Node, bool, Node.InternalMode)"/>'s <c>internal</c> parameter).</para>
    /// </summary>
    public int GetIndex(bool includeInternal = false)
    {
        return NativeCalls.godot_icall_1_198(MethodBind33, GodotObject.GetPtr(this), includeInternal.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind34 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PrintTree, 3218959716ul);

    /// <summary>
    /// <para>Prints the node and its children to the console, recursively. The node does not have to be inside the tree. This method outputs <see cref="Godot.NodePath"/>s relative to this node, and is good for copy/pasting into <see cref="Godot.Node.GetNode(NodePath)"/>. See also <see cref="Godot.Node.PrintTreePretty()"/>.</para>
    /// <para>May print, for example:</para>
    /// <para><code>
    /// .
    /// Menu
    /// Menu/Label
    /// Menu/Camera2D
    /// SplashScreen
    /// SplashScreen/Camera2D
    /// </code></para>
    /// </summary>
    public void PrintTree()
    {
        NativeCalls.godot_icall_0_3(MethodBind34, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind35 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PrintTreePretty, 3218959716ul);

    /// <summary>
    /// <para>Prints the node and its children to the console, recursively. The node does not have to be inside the tree. Similar to <see cref="Godot.Node.PrintTree()"/>, but the graphical representation looks like what is displayed in the editor's Scene dock. It is useful for inspecting larger trees.</para>
    /// <para>May print, for example:</para>
    /// <para><code>
    ///  ┖╴TheGame
    ///     ┠╴Menu
    ///     ┃  ┠╴Label
    ///     ┃  ┖╴Camera2D
    ///     ┖╴SplashScreen
    ///        ┖╴Camera2D
    /// </code></para>
    /// </summary>
    public void PrintTreePretty()
    {
        NativeCalls.godot_icall_0_3(MethodBind35, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind36 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTreeString, 2841200299ul);

    /// <summary>
    /// <para>Returns the tree as a <see cref="string"/>. Used mainly for debugging purposes. This version displays the path relative to the current node, and is good for copy/pasting into the <see cref="Godot.Node.GetNode(NodePath)"/> function. It also can be used in game UI/UX.</para>
    /// <para>May print, for example:</para>
    /// <para><code>
    /// TheGame
    /// TheGame/Menu
    /// TheGame/Menu/Label
    /// TheGame/Menu/Camera2D
    /// TheGame/SplashScreen
    /// TheGame/SplashScreen/Camera2D
    /// </code></para>
    /// </summary>
    public string GetTreeString()
    {
        return NativeCalls.godot_icall_0_58(MethodBind36, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind37 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTreeStringPretty, 2841200299ul);

    /// <summary>
    /// <para>Similar to <see cref="Godot.Node.GetTreeString()"/>, this returns the tree as a <see cref="string"/>. This version displays a more graphical representation similar to what is displayed in the Scene Dock. It is useful for inspecting larger trees.</para>
    /// <para>May print, for example:</para>
    /// <para><code>
    ///  ┖╴TheGame
    ///     ┠╴Menu
    ///     ┃  ┠╴Label
    ///     ┃  ┖╴Camera2D
    ///     ┖╴SplashScreen
    ///        ┖╴Camera2D
    /// </code></para>
    /// </summary>
    public string GetTreeStringPretty()
    {
        return NativeCalls.godot_icall_0_58(MethodBind37, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind38 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSceneFilePath, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSceneFilePath(string sceneFilePath)
    {
        NativeCalls.godot_icall_1_57(MethodBind38, GodotObject.GetPtr(this), sceneFilePath);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind39 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSceneFilePath, 201670096ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetSceneFilePath()
    {
        return NativeCalls.godot_icall_0_58(MethodBind39, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind40 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PropagateNotification, 1286410249ul);

    /// <summary>
    /// <para>Calls <see cref="Godot.GodotObject.Notification(int, bool)"/> with <paramref name="what"/> on this node and all of its children, recursively.</para>
    /// </summary>
    public void PropagateNotification(int what)
    {
        NativeCalls.godot_icall_1_38(MethodBind40, GodotObject.GetPtr(this), what);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind41 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PropagateCall, 1871007965ul);

    /// <summary>
    /// <para>Calls the given <paramref name="method"/> name, passing <paramref name="args"/> as arguments, on this node and all of its children, recursively.</para>
    /// <para>If <paramref name="parentFirst"/> is <see langword="true"/>, the method is called on this node first, then on all of its children. If <see langword="false"/>, the children's methods are called first.</para>
    /// </summary>
    public void PropagateCall(StringName method, Godot.Collections.Array args = null, bool parentFirst = false)
    {
        NativeCalls.godot_icall_3_888(MethodBind41, GodotObject.GetPtr(this), (godot_string_name)(method?.NativeValue ?? default), (godot_array)(args ?? new()).NativeValue, parentFirst.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind42 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPhysicsProcess, 2586408642ul);

    /// <summary>
    /// <para>If set to <see langword="true"/>, enables physics (fixed framerate) processing. When a node is being processed, it will receive a <see cref="Godot.Node.NotificationPhysicsProcess"/> at a fixed (usually 60 FPS, see <see cref="Godot.Engine.PhysicsTicksPerSecond"/> to change) interval (and the <see cref="Godot.Node._PhysicsProcess(double)"/> callback will be called if it exists).</para>
    /// <para><b>Note:</b> If <see cref="Godot.Node._PhysicsProcess(double)"/> is overridden, this will be automatically enabled before <see cref="Godot.Node._Ready()"/> is called.</para>
    /// </summary>
    public void SetPhysicsProcess(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind42, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind43 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPhysicsProcessDeltaTime, 1740695150ul);

    /// <summary>
    /// <para>Returns the time elapsed (in seconds) since the last physics callback. This value is identical to <see cref="Godot.Node._PhysicsProcess(double)"/>'s <c>delta</c> parameter, and is often consistent at run-time, unless <see cref="Godot.Engine.PhysicsTicksPerSecond"/> is changed. See also <see cref="Godot.Node.NotificationPhysicsProcess"/>.</para>
    /// <para><b>Note:</b> The returned value will be larger than expected if running at a framerate lower than <see cref="Godot.Engine.PhysicsTicksPerSecond"/> / <see cref="Godot.Engine.MaxPhysicsStepsPerFrame"/> FPS. This is done to avoid "spiral of death" scenarios where performance would plummet due to an ever-increasing number of physics steps per frame. This behavior affects both <see cref="Godot.Node._Process(double)"/> and <see cref="Godot.Node._PhysicsProcess(double)"/>. As a result, avoid using <c>delta</c> for time measurements in real-world seconds. Use the <see cref="Godot.Time"/> singleton's methods for this purpose instead, such as <see cref="Godot.Time.GetTicksUsec()"/>.</para>
    /// </summary>
    public double GetPhysicsProcessDeltaTime()
    {
        return NativeCalls.godot_icall_0_144(MethodBind43, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind44 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsPhysicsProcessing, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if physics processing is enabled (see <see cref="Godot.Node.SetPhysicsProcess(bool)"/>).</para>
    /// </summary>
    public bool IsPhysicsProcessing()
    {
        return NativeCalls.godot_icall_0_15(MethodBind44, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind45 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetProcessDeltaTime, 1740695150ul);

    /// <summary>
    /// <para>Returns the time elapsed (in seconds) since the last process callback. This value is identical to <see cref="Godot.Node._Process(double)"/>'s <c>delta</c> parameter, and may vary from frame to frame. See also <see cref="Godot.Node.NotificationProcess"/>.</para>
    /// <para><b>Note:</b> The returned value will be larger than expected if running at a framerate lower than <see cref="Godot.Engine.PhysicsTicksPerSecond"/> / <see cref="Godot.Engine.MaxPhysicsStepsPerFrame"/> FPS. This is done to avoid "spiral of death" scenarios where performance would plummet due to an ever-increasing number of physics steps per frame. This behavior affects both <see cref="Godot.Node._Process(double)"/> and <see cref="Godot.Node._PhysicsProcess(double)"/>. As a result, avoid using <c>delta</c> for time measurements in real-world seconds. Use the <see cref="Godot.Time"/> singleton's methods for this purpose instead, such as <see cref="Godot.Time.GetTicksUsec()"/>.</para>
    /// </summary>
    public double GetProcessDeltaTime()
    {
        return NativeCalls.godot_icall_0_144(MethodBind45, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind46 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetProcess, 2586408642ul);

    /// <summary>
    /// <para>If set to <see langword="true"/>, enables processing. When a node is being processed, it will receive a <see cref="Godot.Node.NotificationProcess"/> on every drawn frame (and the <see cref="Godot.Node._Process(double)"/> callback will be called if it exists).</para>
    /// <para><b>Note:</b> If <see cref="Godot.Node._Process(double)"/> is overridden, this will be automatically enabled before <see cref="Godot.Node._Ready()"/> is called.</para>
    /// <para><b>Note:</b> This method only affects the <see cref="Godot.Node._Process(double)"/> callback, i.e. it has no effect on other callbacks like <see cref="Godot.Node._PhysicsProcess(double)"/>. If you want to disable all processing for the node, set <see cref="Godot.Node.ProcessMode"/> to <see cref="Godot.Node.ProcessModeEnum.Disabled"/>.</para>
    /// </summary>
    public void SetProcess(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind46, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind47 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetProcessPriority, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetProcessPriority(int priority)
    {
        NativeCalls.godot_icall_1_38(MethodBind47, GodotObject.GetPtr(this), priority);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind48 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetProcessPriority, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetProcessPriority()
    {
        return NativeCalls.godot_icall_0_39(MethodBind48, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind49 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPhysicsProcessPriority, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPhysicsProcessPriority(int priority)
    {
        NativeCalls.godot_icall_1_38(MethodBind49, GodotObject.GetPtr(this), priority);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind50 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPhysicsProcessPriority, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetPhysicsProcessPriority()
    {
        return NativeCalls.godot_icall_0_39(MethodBind50, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind51 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsProcessing, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if processing is enabled (see <see cref="Godot.Node.SetProcess(bool)"/>).</para>
    /// </summary>
    public bool IsProcessing()
    {
        return NativeCalls.godot_icall_0_15(MethodBind51, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind52 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetProcessInput, 2586408642ul);

    /// <summary>
    /// <para>If set to <see langword="true"/>, enables input processing.</para>
    /// <para><b>Note:</b> If <see cref="Godot.Node._Input(InputEvent)"/> is overridden, this will be automatically enabled before <see cref="Godot.Node._Ready()"/> is called. Input processing is also already enabled for GUI controls, such as <see cref="Godot.Button"/> and <see cref="Godot.TextEdit"/>.</para>
    /// </summary>
    public void SetProcessInput(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind52, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind53 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsProcessingInput, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the node is processing input (see <see cref="Godot.Node.SetProcessInput(bool)"/>).</para>
    /// </summary>
    public bool IsProcessingInput()
    {
        return NativeCalls.godot_icall_0_15(MethodBind53, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind54 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetProcessShortcutInput, 2586408642ul);

    /// <summary>
    /// <para>If set to <see langword="true"/>, enables shortcut processing for this node.</para>
    /// <para><b>Note:</b> If <see cref="Godot.Node._ShortcutInput(InputEvent)"/> is overridden, this will be automatically enabled before <see cref="Godot.Node._Ready()"/> is called.</para>
    /// </summary>
    public void SetProcessShortcutInput(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind54, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind55 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsProcessingShortcutInput, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the node is processing shortcuts (see <see cref="Godot.Node.SetProcessShortcutInput(bool)"/>).</para>
    /// </summary>
    public bool IsProcessingShortcutInput()
    {
        return NativeCalls.godot_icall_0_15(MethodBind55, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind56 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetProcessUnhandledInput, 2586408642ul);

    /// <summary>
    /// <para>If set to <see langword="true"/>, enables unhandled input processing. It enables the node to receive all input that was not previously handled (usually by a <see cref="Godot.Control"/>).</para>
    /// <para><b>Note:</b> If <see cref="Godot.Node._UnhandledInput(InputEvent)"/> is overridden, this will be automatically enabled before <see cref="Godot.Node._Ready()"/> is called. Unhandled input processing is also already enabled for GUI controls, such as <see cref="Godot.Button"/> and <see cref="Godot.TextEdit"/>.</para>
    /// </summary>
    public void SetProcessUnhandledInput(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind56, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind57 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsProcessingUnhandledInput, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the node is processing unhandled input (see <see cref="Godot.Node.SetProcessUnhandledInput(bool)"/>).</para>
    /// </summary>
    public bool IsProcessingUnhandledInput()
    {
        return NativeCalls.godot_icall_0_15(MethodBind57, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind58 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetProcessUnhandledKeyInput, 2586408642ul);

    /// <summary>
    /// <para>If set to <see langword="true"/>, enables unhandled key input processing.</para>
    /// <para><b>Note:</b> If <see cref="Godot.Node._UnhandledKeyInput(InputEvent)"/> is overridden, this will be automatically enabled before <see cref="Godot.Node._Ready()"/> is called.</para>
    /// </summary>
    public void SetProcessUnhandledKeyInput(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind58, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind59 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsProcessingUnhandledKeyInput, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the node is processing unhandled key input (see <see cref="Godot.Node.SetProcessUnhandledKeyInput(bool)"/>).</para>
    /// </summary>
    public bool IsProcessingUnhandledKeyInput()
    {
        return NativeCalls.godot_icall_0_15(MethodBind59, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind60 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetProcessMode, 1841290486ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetProcessMode(Node.ProcessModeEnum mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind60, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind61 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetProcessMode, 739966102ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Node.ProcessModeEnum GetProcessMode()
    {
        return (Node.ProcessModeEnum)NativeCalls.godot_icall_0_39(MethodBind61, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind62 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanProcess, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the node can receive processing notifications and input callbacks (<see cref="Godot.Node.NotificationProcess"/>, <see cref="Godot.Node._Input(InputEvent)"/>, etc.) from the <see cref="Godot.SceneTree"/> and <see cref="Godot.Viewport"/>. The returned value depends on <see cref="Godot.Node.ProcessMode"/>:</para>
    /// <para>- If set to <see cref="Godot.Node.ProcessModeEnum.Pausable"/>, returns <see langword="true"/> when the game is processing, i.e. <see cref="Godot.SceneTree.Paused"/> is <see langword="false"/>;</para>
    /// <para>- If set to <see cref="Godot.Node.ProcessModeEnum.WhenPaused"/>, returns <see langword="true"/> when the game is paused, i.e. <see cref="Godot.SceneTree.Paused"/> is <see langword="true"/>;</para>
    /// <para>- If set to <see cref="Godot.Node.ProcessModeEnum.Always"/>, always returns <see langword="true"/>;</para>
    /// <para>- If set to <see cref="Godot.Node.ProcessModeEnum.Disabled"/>, always returns <see langword="false"/>;</para>
    /// <para>- If set to <see cref="Godot.Node.ProcessModeEnum.Inherit"/>, use the parent node's <see cref="Godot.Node.ProcessMode"/> to determine the result.</para>
    /// <para>If the node is not inside the tree, returns <see langword="false"/> no matter the value of <see cref="Godot.Node.ProcessMode"/>.</para>
    /// </summary>
    public bool CanProcess()
    {
        return NativeCalls.godot_icall_0_15(MethodBind62, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind63 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetProcessThreadGroup, 2275442745ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetProcessThreadGroup(Node.ProcessThreadGroupEnum mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind63, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind64 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetProcessThreadGroup, 1866404740ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Node.ProcessThreadGroupEnum GetProcessThreadGroup()
    {
        return (Node.ProcessThreadGroupEnum)NativeCalls.godot_icall_0_39(MethodBind64, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind65 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetProcessThreadMessages, 1357280998ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetProcessThreadMessages(Node.ProcessThreadMessagesEnum flags)
    {
        NativeCalls.godot_icall_1_38(MethodBind65, GodotObject.GetPtr(this), (int)flags);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind66 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetProcessThreadMessages, 4228993612ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Node.ProcessThreadMessagesEnum GetProcessThreadMessages()
    {
        return (Node.ProcessThreadMessagesEnum)NativeCalls.godot_icall_0_39(MethodBind66, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind67 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetProcessThreadGroupOrder, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetProcessThreadGroupOrder(int order)
    {
        NativeCalls.godot_icall_1_38(MethodBind67, GodotObject.GetPtr(this), order);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind68 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetProcessThreadGroupOrder, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetProcessThreadGroupOrder()
    {
        return NativeCalls.godot_icall_0_39(MethodBind68, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind69 = ClassDB_get_method_with_compatibility(NativeName, MethodName.QueueAccessibilityUpdate, 3218959716ul);

    /// <summary>
    /// <para>Queues an accessibility information update for this node.</para>
    /// </summary>
    public void QueueAccessibilityUpdate()
    {
        NativeCalls.godot_icall_0_3(MethodBind69, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind70 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAccessibilityElement, 2944877500ul);

    /// <summary>
    /// <para>Returns main accessibility element RID.</para>
    /// <para><b>Note:</b> This method should be called only during accessibility information updates (<see cref="Godot.Node.NotificationAccessibilityUpdate"/>).</para>
    /// </summary>
    public Rid GetAccessibilityElement()
    {
        return NativeCalls.godot_icall_0_238(MethodBind70, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind71 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDisplayFolded, 2586408642ul);

    /// <summary>
    /// <para>If set to <see langword="true"/>, the node appears folded in the Scene dock. As a result, all of its children are hidden. This method is intended to be used in editor plugins and tools, but it also works in release builds. See also <see cref="Godot.Node.IsDisplayedFolded()"/>.</para>
    /// </summary>
    public void SetDisplayFolded(bool fold)
    {
        NativeCalls.godot_icall_1_14(MethodBind71, GodotObject.GetPtr(this), fold.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind72 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsDisplayedFolded, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the node is folded (collapsed) in the Scene dock. This method is intended to be used in editor plugins and tools. See also <see cref="Godot.Node.SetDisplayFolded(bool)"/>.</para>
    /// </summary>
    public bool IsDisplayedFolded()
    {
        return NativeCalls.godot_icall_0_15(MethodBind72, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind73 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetProcessInternal, 2586408642ul);

    /// <summary>
    /// <para>If set to <see langword="true"/>, enables internal processing for this node. Internal processing happens in isolation from the normal <see cref="Godot.Node._Process(double)"/> calls and is used by some nodes internally to guarantee proper functioning even if the node is paused or processing is disabled for scripting (<see cref="Godot.Node.SetProcess(bool)"/>).</para>
    /// <para><b>Warning:</b> Built-in nodes rely on internal processing for their internal logic. Disabling it is unsafe and may lead to unexpected behavior. Use this method if you know what you are doing.</para>
    /// </summary>
    public void SetProcessInternal(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind73, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind74 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsProcessingInternal, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if internal processing is enabled (see <see cref="Godot.Node.SetProcessInternal(bool)"/>).</para>
    /// </summary>
    public bool IsProcessingInternal()
    {
        return NativeCalls.godot_icall_0_15(MethodBind74, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind75 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPhysicsProcessInternal, 2586408642ul);

    /// <summary>
    /// <para>If set to <see langword="true"/>, enables internal physics for this node. Internal physics processing happens in isolation from the normal <see cref="Godot.Node._PhysicsProcess(double)"/> calls and is used by some nodes internally to guarantee proper functioning even if the node is paused or physics processing is disabled for scripting (<see cref="Godot.Node.SetPhysicsProcess(bool)"/>).</para>
    /// <para><b>Warning:</b> Built-in nodes rely on internal processing for their internal logic. Disabling it is unsafe and may lead to unexpected behavior. Use this method if you know what you are doing.</para>
    /// </summary>
    public void SetPhysicsProcessInternal(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind75, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind76 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsPhysicsProcessingInternal, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if internal physics processing is enabled (see <see cref="Godot.Node.SetPhysicsProcessInternal(bool)"/>).</para>
    /// </summary>
    public bool IsPhysicsProcessingInternal()
    {
        return NativeCalls.godot_icall_0_15(MethodBind76, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind77 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPhysicsInterpolationMode, 3202404928ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPhysicsInterpolationMode(Node.PhysicsInterpolationModeEnum mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind77, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind78 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPhysicsInterpolationMode, 2920385216ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Node.PhysicsInterpolationModeEnum GetPhysicsInterpolationMode()
    {
        return (Node.PhysicsInterpolationModeEnum)NativeCalls.godot_icall_0_39(MethodBind78, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind79 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsPhysicsInterpolated, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if physics interpolation is enabled for this node (see <see cref="Godot.Node.PhysicsInterpolationMode"/>).</para>
    /// <para><b>Note:</b> Interpolation will only be active if both the flag is set <b>and</b> physics interpolation is enabled within the <see cref="Godot.SceneTree"/>. This can be tested using <see cref="Godot.Node.IsPhysicsInterpolatedAndEnabled()"/>.</para>
    /// </summary>
    public bool IsPhysicsInterpolated()
    {
        return NativeCalls.godot_icall_0_15(MethodBind79, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind80 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsPhysicsInterpolatedAndEnabled, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if physics interpolation is enabled (see <see cref="Godot.Node.PhysicsInterpolationMode"/>) <b>and</b> enabled in the <see cref="Godot.SceneTree"/>.</para>
    /// <para>This is a convenience version of <see cref="Godot.Node.IsPhysicsInterpolated()"/> that also checks whether physics interpolation is enabled globally.</para>
    /// <para>See <see cref="Godot.SceneTree.PhysicsInterpolation"/> and <c>ProjectSettings.physics/common/physics_interpolation</c>.</para>
    /// </summary>
    public bool IsPhysicsInterpolatedAndEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind80, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind81 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ResetPhysicsInterpolation, 3218959716ul);

    /// <summary>
    /// <para>When physics interpolation is active, moving a node to a radically different transform (such as placement within a level) can result in a visible glitch as the object is rendered moving from the old to new position over the physics tick.</para>
    /// <para>That glitch can be prevented by calling this method, which temporarily disables interpolation until the physics tick is complete.</para>
    /// <para>The notification <see cref="Godot.Node.NotificationResetPhysicsInterpolation"/> will be received by the node and all children recursively.</para>
    /// <para><b>Note:</b> This function should be called <b>after</b> moving the node, rather than before.</para>
    /// </summary>
    public void ResetPhysicsInterpolation()
    {
        NativeCalls.godot_icall_0_3(MethodBind81, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind82 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAutoTranslateMode, 776149714ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAutoTranslateMode(Node.AutoTranslateModeEnum mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind82, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind83 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAutoTranslateMode, 2498906432ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Node.AutoTranslateModeEnum GetAutoTranslateMode()
    {
        return (Node.AutoTranslateModeEnum)NativeCalls.godot_icall_0_39(MethodBind83, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind84 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanAutoTranslate, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if this node can automatically translate messages depending on the current locale. See <see cref="Godot.Node.AutoTranslateMode"/>, <see cref="Godot.Node.Atr(string, StringName)"/>, and <see cref="Godot.Node.AtrN(string, StringName, int, StringName)"/>.</para>
    /// </summary>
    public bool CanAutoTranslate()
    {
        return NativeCalls.godot_icall_0_15(MethodBind84, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind85 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTranslationDomainInherited, 3218959716ul);

    /// <summary>
    /// <para>Makes this node inherit the translation domain from its parent node. If this node has no parent, the main translation domain will be used.</para>
    /// <para>This is the default behavior for all nodes. Calling <see cref="Godot.GodotObject.SetTranslationDomain(StringName)"/> disables this behavior.</para>
    /// </summary>
    public void SetTranslationDomainInherited()
    {
        NativeCalls.godot_icall_0_3(MethodBind85, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind86 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetWindow, 1757182445ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.Window"/> that contains this node. If the node is in the main window, this is equivalent to getting the root node (<c>get_tree().get_root()</c>).</para>
    /// </summary>
    public Window GetWindow()
    {
        return (Window)NativeCalls.godot_icall_0_53(MethodBind86, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind87 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLastExclusiveWindow, 1757182445ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.Window"/> that contains this node, or the last exclusive child in a chain of windows starting with the one that contains this node.</para>
    /// </summary>
    public Window GetLastExclusiveWindow()
    {
        return (Window)NativeCalls.godot_icall_0_53(MethodBind87, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind88 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTree, 2958820483ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.SceneTree"/> that contains this node. If this node is not inside the tree, generates an error and returns <see langword="null"/>. See also <see cref="Godot.Node.IsInsideTree()"/>.</para>
    /// </summary>
    public SceneTree GetTree()
    {
        return (SceneTree)NativeCalls.godot_icall_0_53(MethodBind88, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind89 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CreateTween, 3426978995ul);

    /// <summary>
    /// <para>Creates a new <see cref="Godot.Tween"/> and binds it to this node.</para>
    /// <para>This is the equivalent of doing:</para>
    /// <para><code>
    /// GetTree().CreateTween().BindNode(this);
    /// </code></para>
    /// <para>The Tween will start automatically on the next process frame or physics frame (depending on <see cref="Godot.Tween.TweenProcessMode"/>). See <see cref="Godot.Tween.BindNode(Node)"/> for more info on Tweens bound to nodes.</para>
    /// <para><b>Note:</b> The method can still be used when the node is not inside <see cref="Godot.SceneTree"/>. It can fail in an unlikely case of using a custom <see cref="Godot.MainLoop"/>.</para>
    /// </summary>
    public Tween CreateTween()
    {
        return (Tween)NativeCalls.godot_icall_0_63(MethodBind89, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind90 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Duplicate, 3511555459ul);

    /// <summary>
    /// <para>Duplicates the node, returning a new node with all of its properties, signals, groups, and children copied from the original, recursively. The behavior can be tweaked through the <paramref name="flags"/> (see <see cref="Godot.Node.DuplicateFlags"/>). Internal nodes are not duplicated.</para>
    /// <para><b>Note:</b> For nodes with a <see cref="Godot.Script"/> attached, if <see cref="Godot.GodotObject.GodotObject()"/> has been defined with required parameters, the duplicated node will not have a <see cref="Godot.Script"/>.</para>
    /// <para><b>Note:</b> By default, this method will duplicate only properties marked for serialization (i.e. using <see cref="Godot.PropertyUsageFlags.Storage"/>, or in GDScript, [annotation @GDScript.@export]). If you want to duplicate all properties, use <see cref="Godot.Node.DuplicateFlags.InternalState"/>.</para>
    /// </summary>
    public Node Duplicate(int flags = 15)
    {
        return (Node)NativeCalls.godot_icall_1_335(MethodBind90, GodotObject.GetPtr(this), flags);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind91 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ReplaceBy, 2570952461ul);

    /// <summary>
    /// <para>Replaces this node by the given <paramref name="node"/>. All children of this node are moved to <paramref name="node"/>.</para>
    /// <para>If <paramref name="keepGroups"/> is <see langword="true"/>, the <paramref name="node"/> is added to the same groups that the replaced node is in (see <see cref="Godot.Node.AddToGroup(StringName, bool)"/>).</para>
    /// <para><b>Warning:</b> The replaced node is removed from the tree, but it is <b>not</b> deleted. To prevent memory leaks, store a reference to the node in a variable, or use <see cref="Godot.GodotObject.Free()"/>.</para>
    /// </summary>
    public void ReplaceBy(Node node, bool keepGroups = false)
    {
        NativeCalls.godot_icall_2_508(MethodBind91, GodotObject.GetPtr(this), GodotObject.GetPtr(node), keepGroups.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind92 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSceneInstanceLoadPlaceholder, 2586408642ul);

    /// <summary>
    /// <para>If set to <see langword="true"/>, the node becomes an <see cref="Godot.InstancePlaceholder"/> when packed and instantiated from a <see cref="Godot.PackedScene"/>. See also <see cref="Godot.Node.GetSceneInstanceLoadPlaceholder()"/>.</para>
    /// </summary>
    public void SetSceneInstanceLoadPlaceholder(bool loadPlaceholder)
    {
        NativeCalls.godot_icall_1_14(MethodBind92, GodotObject.GetPtr(this), loadPlaceholder.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind93 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSceneInstanceLoadPlaceholder, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if this node is an instance load placeholder. See <see cref="Godot.InstancePlaceholder"/> and <see cref="Godot.Node.SetSceneInstanceLoadPlaceholder(bool)"/>.</para>
    /// </summary>
    public bool GetSceneInstanceLoadPlaceholder()
    {
        return NativeCalls.godot_icall_0_15(MethodBind93, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind94 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEditableInstance, 2731852923ul);

    /// <summary>
    /// <para>Set to <see langword="true"/> to allow all nodes owned by <paramref name="node"/> to be available, and editable, in the Scene dock, even if their <see cref="Godot.Node.Owner"/> is not the scene root. This method is intended to be used in editor plugins and tools, but it also works in release builds. See also <see cref="Godot.Node.IsEditableInstance(Node)"/>.</para>
    /// </summary>
    public void SetEditableInstance(Node node, bool isEditable)
    {
        NativeCalls.godot_icall_2_508(MethodBind94, GodotObject.GetPtr(this), GodotObject.GetPtr(node), isEditable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind95 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsEditableInstance, 3093956946ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if <paramref name="node"/> has editable children enabled relative to this node. This method is intended to be used in editor plugins and tools. See also <see cref="Godot.Node.SetEditableInstance(Node, bool)"/>.</para>
    /// </summary>
    public bool IsEditableInstance(Node node)
    {
        return NativeCalls.godot_icall_1_176(MethodBind95, GodotObject.GetPtr(this), GodotObject.GetPtr(node)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind96 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetViewport, 3596683776ul);

    /// <summary>
    /// <para>Returns the node's closest <see cref="Godot.Viewport"/> ancestor, if the node is inside the tree. Otherwise, returns <see langword="null"/>.</para>
    /// </summary>
    public Viewport GetViewport()
    {
        return (Viewport)NativeCalls.godot_icall_0_53(MethodBind96, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind97 = ClassDB_get_method_with_compatibility(NativeName, MethodName.QueueFree, 3218959716ul);

    /// <summary>
    /// <para>Queues this node to be deleted at the end of the current frame. When deleted, all of its children are deleted as well, and all references to the node and its children become invalid.</para>
    /// <para>Unlike with <see cref="Godot.GodotObject.Free()"/>, the node is not deleted instantly, and it can still be accessed before deletion. It is also safe to call <see cref="Godot.Node.QueueFree()"/> multiple times. Use <see cref="Godot.GodotObject.IsQueuedForDeletion()"/> to check if the node will be deleted at the end of the frame.</para>
    /// <para><b>Note:</b> The node will only be freed after all other deferred calls are finished. Using this method is not always the same as calling <see cref="Godot.GodotObject.Free()"/> through <see cref="Godot.GodotObject.CallDeferred(StringName, Variant[])"/>.</para>
    /// </summary>
    public void QueueFree()
    {
        NativeCalls.godot_icall_0_3(MethodBind97, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind98 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RequestReady, 3218959716ul);

    /// <summary>
    /// <para>Requests <see cref="Godot.Node._Ready()"/> to be called again the next time the node enters the tree. Does <b>not</b> immediately call <see cref="Godot.Node._Ready()"/>.</para>
    /// <para><b>Note:</b> This method only affects the current node. If the node's children also need to request ready, this method needs to be called for each one of them. When the node and its children enter the tree again, the order of <see cref="Godot.Node._Ready()"/> callbacks will be the same as normal.</para>
    /// </summary>
    public void RequestReady()
    {
        NativeCalls.godot_icall_0_3(MethodBind98, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind99 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsNodeReady, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the node is ready, i.e. it's inside scene tree and all its children are initialized.</para>
    /// <para><see cref="Godot.Node.RequestReady()"/> resets it back to <see langword="false"/>.</para>
    /// </summary>
    public bool IsNodeReady()
    {
        return NativeCalls.godot_icall_0_15(MethodBind99, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind100 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMultiplayerAuthority, 972357352ul);

    /// <summary>
    /// <para>Sets the node's multiplayer authority to the peer with the given peer <paramref name="id"/>. The multiplayer authority is the peer that has authority over the node on the network. Defaults to peer ID 1 (the server). Useful in conjunction with <see cref="Godot.Node.RpcConfig(StringName, Variant)"/> and the <see cref="Godot.MultiplayerApi"/>.</para>
    /// <para>If <paramref name="recursive"/> is <see langword="true"/>, the given peer is recursively set as the authority for all children of this node.</para>
    /// <para><b>Warning:</b> This does <b>not</b> automatically replicate the new authority to other peers. It is the developer's responsibility to do so. You may replicate the new authority's information using <see cref="Godot.MultiplayerSpawner.SpawnFunction"/>, an RPC, or a <see cref="Godot.MultiplayerSynchronizer"/>. Furthermore, the parent's authority does <b>not</b> propagate to newly added children.</para>
    /// </summary>
    public void SetMultiplayerAuthority(int id, bool recursive = true)
    {
        NativeCalls.godot_icall_2_61(MethodBind100, GodotObject.GetPtr(this), id, recursive.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind101 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMultiplayerAuthority, 3905245786ul);

    /// <summary>
    /// <para>Returns the peer ID of the multiplayer authority for this node. See <see cref="Godot.Node.SetMultiplayerAuthority(int, bool)"/>.</para>
    /// </summary>
    public int GetMultiplayerAuthority()
    {
        return NativeCalls.godot_icall_0_39(MethodBind101, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind102 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsMultiplayerAuthority, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the local system is the multiplayer authority of this node.</para>
    /// </summary>
    public bool IsMultiplayerAuthority()
    {
        return NativeCalls.godot_icall_0_15(MethodBind102, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind103 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMultiplayer, 406750475ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public MultiplayerApi GetMultiplayer()
    {
        return (MultiplayerApi)NativeCalls.godot_icall_0_63(MethodBind103, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind104 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RpcConfig, 3776071444ul);

    /// <summary>
    /// <para>Changes the RPC configuration for the given <paramref name="method"/>. <paramref name="config"/> should either be <see langword="null"/> to disable the feature (as by default), or a <see cref="Godot.Collections.Dictionary"/> containing the following entries:</para>
    /// <para>- <c>rpc_mode</c>: see <see cref="Godot.MultiplayerApi.RpcMode"/>;</para>
    /// <para>- <c>transfer_mode</c>: see <see cref="Godot.MultiplayerPeer.TransferModeEnum"/>;</para>
    /// <para>- <c>call_local</c>: if <see langword="true"/>, the method will also be called locally;</para>
    /// <para>- <c>channel</c>: an <see cref="int"/> representing the channel to send the RPC on.</para>
    /// <para><b>Note:</b> In GDScript, this method corresponds to the [annotation @GDScript.@rpc] annotation, with various parameters passed (<c>@rpc(any)</c>, <c>@rpc(authority)</c>...). See also the <a href="$DOCS_URL/tutorials/networking/high_level_multiplayer.html">high-level multiplayer</a> tutorial.</para>
    /// </summary>
    public void RpcConfig(StringName method, Variant config)
    {
        NativeCalls.godot_icall_2_142(MethodBind104, GodotObject.GetPtr(this), (godot_string_name)(method?.NativeValue ?? default), config);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind105 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNodeRpcConfig, 1214101251ul);

    /// <summary>
    /// <para>Returns a <see cref="Godot.Collections.Dictionary"/> mapping method names to their RPC configuration defined for this node using <see cref="Godot.Node.RpcConfig(StringName, Variant)"/>.</para>
    /// <para><b>Note:</b> This method only returns the RPC configuration assigned via <see cref="Godot.Node.RpcConfig(StringName, Variant)"/>. See <see cref="Godot.Script.GetRpcConfig()"/> to retrieve the RPCs defined by the <see cref="Godot.Script"/>.</para>
    /// </summary>
    public Variant GetNodeRpcConfig()
    {
        return NativeCalls.godot_icall_0_772(MethodBind105, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind106 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEditorDescription, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEditorDescription(string editorDescription)
    {
        NativeCalls.godot_icall_1_57(MethodBind106, GodotObject.GetPtr(this), editorDescription);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind107 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEditorDescription, 201670096ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetEditorDescription()
    {
        return NativeCalls.godot_icall_0_58(MethodBind107, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind108 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetUniqueNameInOwner, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetUniqueNameInOwner(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind108, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind109 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsUniqueNameInOwner, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsUniqueNameInOwner()
    {
        return NativeCalls.godot_icall_0_15(MethodBind109, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind110 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Atr, 3344478075ul);

    /// <summary>
    /// <para>Translates a <paramref name="message"/>, using the translation catalogs configured in the Project Settings. Further <paramref name="context"/> can be specified to help with the translation. Note that most <see cref="Godot.Control"/> nodes automatically translate their strings, so this method is mostly useful for formatted strings or custom drawn text.</para>
    /// <para>This method works the same as <see cref="Godot.GodotObject.Tr(StringName, StringName)"/>, with the addition of respecting the <see cref="Godot.Node.AutoTranslateMode"/> state.</para>
    /// <para>If <see cref="Godot.GodotObject.CanTranslateMessages()"/> is <see langword="false"/>, or no translation is available, this method returns the <paramref name="message"/> without changes. See <see cref="Godot.GodotObject.SetMessageTranslation(bool)"/>.</para>
    /// <para>For detailed examples, see <a href="$DOCS_URL/tutorials/i18n/internationalizing_games.html">Internationalizing games</a>.</para>
    /// </summary>
    public string Atr(string message, StringName context = null)
    {
        return NativeCalls.godot_icall_2_889(MethodBind110, GodotObject.GetPtr(this), message, (godot_string_name)(context?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind111 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AtrN, 259354841ul);

    /// <summary>
    /// <para>Translates a <paramref name="message"/> or <paramref name="pluralMessage"/>, using the translation catalogs configured in the Project Settings. Further <paramref name="context"/> can be specified to help with the translation.</para>
    /// <para>This method works the same as <see cref="Godot.GodotObject.TrN(StringName, StringName, int, StringName)"/>, with the addition of respecting the <see cref="Godot.Node.AutoTranslateMode"/> state.</para>
    /// <para>If <see cref="Godot.GodotObject.CanTranslateMessages()"/> is <see langword="false"/>, or no translation is available, this method returns <paramref name="message"/> or <paramref name="pluralMessage"/>, without changes. See <see cref="Godot.GodotObject.SetMessageTranslation(bool)"/>.</para>
    /// <para>The <paramref name="n"/> is the number, or amount, of the message's subject. It is used by the translation system to fetch the correct plural form for the current language.</para>
    /// <para>For detailed examples, see <a href="$DOCS_URL/tutorials/i18n/localization_using_gettext.html">Localization using gettext</a>.</para>
    /// <para><b>Note:</b> Negative and <see cref="float"/> numbers may not properly apply to some countable subjects. It's recommended to handle these cases with <see cref="Godot.Node.Atr(string, StringName)"/>.</para>
    /// </summary>
    public string AtrN(string message, StringName pluralMessage, int n, StringName context = null)
    {
        return NativeCalls.godot_icall_4_890(MethodBind111, GodotObject.GetPtr(this), message, (godot_string_name)(pluralMessage?.NativeValue ?? default), n, (godot_string_name)(context?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind112 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Rpc, 4047867050ul);

    /// <summary>
    /// <para>Sends a remote procedure call request for the given <paramref name="method"/> to peers on the network (and locally), sending additional arguments to the method called by the RPC. The call request will only be received by nodes with the same <see cref="Godot.NodePath"/>, including the exact same <see cref="Godot.Node.Name"/>. Behavior depends on the RPC configuration for the given <paramref name="method"/> (see <see cref="Godot.Node.RpcConfig(StringName, Variant)"/> and [annotation @GDScript.@rpc]). By default, methods are not exposed to RPCs.</para>
    /// <para>May return <see cref="Godot.Error.Ok"/> if the call is successful, <see cref="Godot.Error.InvalidParameter"/> if the arguments passed in the <paramref name="method"/> do not match, <see cref="Godot.Error.Unconfigured"/> if the node's <see cref="Godot.Node.Multiplayer"/> cannot be fetched (such as when the node is not inside the tree), <see cref="Godot.Error.ConnectionError"/> if <see cref="Godot.Node.Multiplayer"/>'s connection is not available.</para>
    /// <para><b>Note:</b> You can only safely use RPCs on clients after you received the <see cref="Godot.MultiplayerApi.ConnectedToServer"/> signal from the <see cref="Godot.MultiplayerApi"/>. You also need to keep track of the connection state, either by the <see cref="Godot.MultiplayerApi"/> signals like <see cref="Godot.MultiplayerApi.ServerDisconnected"/> or by checking (<c>get_multiplayer().peer.get_connection_status() == CONNECTION_CONNECTED</c>).</para>
    /// </summary>
    public Error Rpc(StringName method, params Variant[] @args)
    {
        return (Error)NativeCalls.godot_icall_2_891(MethodBind112, GodotObject.GetPtr(this), (godot_string_name)(method?.NativeValue ?? default), @args, (godot_string_name)MethodName.Rpc.NativeValue);
    }

    /// <summary>
    /// <para>Sends a remote procedure call request for the given <paramref name="method"/> to peers on the network (and locally), sending additional arguments to the method called by the RPC. The call request will only be received by nodes with the same <see cref="Godot.NodePath"/>, including the exact same <see cref="Godot.Node.Name"/>. Behavior depends on the RPC configuration for the given <paramref name="method"/> (see <see cref="Godot.Node.RpcConfig(StringName, Variant)"/> and [annotation @GDScript.@rpc]). By default, methods are not exposed to RPCs.</para>
    /// <para>May return <see cref="Godot.Error.Ok"/> if the call is successful, <see cref="Godot.Error.InvalidParameter"/> if the arguments passed in the <paramref name="method"/> do not match, <see cref="Godot.Error.Unconfigured"/> if the node's <see cref="Godot.Node.Multiplayer"/> cannot be fetched (such as when the node is not inside the tree), <see cref="Godot.Error.ConnectionError"/> if <see cref="Godot.Node.Multiplayer"/>'s connection is not available.</para>
    /// <para><b>Note:</b> You can only safely use RPCs on clients after you received the <see cref="Godot.MultiplayerApi.ConnectedToServer"/> signal from the <see cref="Godot.MultiplayerApi"/>. You also need to keep track of the connection state, either by the <see cref="Godot.MultiplayerApi"/> signals like <see cref="Godot.MultiplayerApi.ServerDisconnected"/> or by checking (<c>get_multiplayer().peer.get_connection_status() == CONNECTION_CONNECTED</c>).</para>
    /// </summary>
    public Error Rpc(StringName method, ReadOnlySpan<Variant> @args)
    {
        return (Error)NativeCalls.godot_icall_2_891(MethodBind112, GodotObject.GetPtr(this), (godot_string_name)(method?.NativeValue ?? default), @args, (godot_string_name)MethodName.Rpc.NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind113 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RpcId, 361499283ul);

    /// <summary>
    /// <para>Sends a <see cref="Godot.Node.Rpc(StringName, Variant[])"/> to a specific peer identified by <paramref name="peerId"/> (see <see cref="Godot.MultiplayerPeer.SetTargetPeer(int)"/>).</para>
    /// <para>May return <see cref="Godot.Error.Ok"/> if the call is successful, <see cref="Godot.Error.InvalidParameter"/> if the arguments passed in the <paramref name="method"/> do not match, <see cref="Godot.Error.Unconfigured"/> if the node's <see cref="Godot.Node.Multiplayer"/> cannot be fetched (such as when the node is not inside the tree), <see cref="Godot.Error.ConnectionError"/> if <see cref="Godot.Node.Multiplayer"/>'s connection is not available.</para>
    /// </summary>
    public Error RpcId(long peerId, StringName method, params Variant[] @args)
    {
        return (Error)NativeCalls.godot_icall_3_892(MethodBind113, GodotObject.GetPtr(this), peerId, (godot_string_name)(method?.NativeValue ?? default), @args, (godot_string_name)MethodName.RpcId.NativeValue);
    }

    /// <summary>
    /// <para>Sends a <see cref="Godot.Node.Rpc(StringName, Variant[])"/> to a specific peer identified by <paramref name="peerId"/> (see <see cref="Godot.MultiplayerPeer.SetTargetPeer(int)"/>).</para>
    /// <para>May return <see cref="Godot.Error.Ok"/> if the call is successful, <see cref="Godot.Error.InvalidParameter"/> if the arguments passed in the <paramref name="method"/> do not match, <see cref="Godot.Error.Unconfigured"/> if the node's <see cref="Godot.Node.Multiplayer"/> cannot be fetched (such as when the node is not inside the tree), <see cref="Godot.Error.ConnectionError"/> if <see cref="Godot.Node.Multiplayer"/>'s connection is not available.</para>
    /// </summary>
    public Error RpcId(long peerId, StringName method, ReadOnlySpan<Variant> @args)
    {
        return (Error)NativeCalls.godot_icall_3_892(MethodBind113, GodotObject.GetPtr(this), peerId, (godot_string_name)(method?.NativeValue ?? default), @args, (godot_string_name)MethodName.RpcId.NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind114 = ClassDB_get_method_with_compatibility(NativeName, MethodName.UpdateConfigurationWarnings, 3218959716ul);

    /// <summary>
    /// <para>Refreshes the warnings displayed for this node in the Scene dock. Use <see cref="Godot.Node._GetConfigurationWarnings()"/> to customize the warning messages to display.</para>
    /// </summary>
    public void UpdateConfigurationWarnings()
    {
        NativeCalls.godot_icall_0_3(MethodBind114, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind115 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CallDeferredThreadGroup, 3400424181ul);

    /// <summary>
    /// <para>This function is similar to <see cref="Godot.GodotObject.CallDeferred(StringName, Variant[])"/> except that the call will take place when the node thread group is processed. If the node thread group processes in sub-threads, then the call will be done on that thread, right before <see cref="Godot.Node.NotificationProcess"/> or <see cref="Godot.Node.NotificationPhysicsProcess"/>, the <see cref="Godot.Node._Process(double)"/> or <see cref="Godot.Node._PhysicsProcess(double)"/> or their internal versions are called.</para>
    /// </summary>
    public Variant CallDeferredThreadGroup(StringName method, params Variant[] @args)
    {
        return NativeCalls.godot_icall_2_893(MethodBind115, GodotObject.GetPtr(this), (godot_string_name)(method?.NativeValue ?? default), @args, (godot_string_name)MethodName.CallDeferredThreadGroup.NativeValue);
    }

    /// <summary>
    /// <para>This function is similar to <see cref="Godot.GodotObject.CallDeferred(StringName, Variant[])"/> except that the call will take place when the node thread group is processed. If the node thread group processes in sub-threads, then the call will be done on that thread, right before <see cref="Godot.Node.NotificationProcess"/> or <see cref="Godot.Node.NotificationPhysicsProcess"/>, the <see cref="Godot.Node._Process(double)"/> or <see cref="Godot.Node._PhysicsProcess(double)"/> or their internal versions are called.</para>
    /// </summary>
    public Variant CallDeferredThreadGroup(StringName method, ReadOnlySpan<Variant> @args)
    {
        return NativeCalls.godot_icall_2_893(MethodBind115, GodotObject.GetPtr(this), (godot_string_name)(method?.NativeValue ?? default), @args, (godot_string_name)MethodName.CallDeferredThreadGroup.NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind116 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDeferredThreadGroup, 3776071444ul);

    /// <summary>
    /// <para>Similar to <see cref="Godot.Node.CallDeferredThreadGroup(StringName, Variant[])"/>, but for setting properties.</para>
    /// </summary>
    public void SetDeferredThreadGroup(StringName property, Variant value)
    {
        NativeCalls.godot_icall_2_142(MethodBind116, GodotObject.GetPtr(this), (godot_string_name)(property?.NativeValue ?? default), value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind117 = ClassDB_get_method_with_compatibility(NativeName, MethodName.NotifyDeferredThreadGroup, 1286410249ul);

    /// <summary>
    /// <para>Similar to <see cref="Godot.Node.CallDeferredThreadGroup(StringName, Variant[])"/>, but for notifications.</para>
    /// </summary>
    public void NotifyDeferredThreadGroup(int what)
    {
        NativeCalls.godot_icall_1_38(MethodBind117, GodotObject.GetPtr(this), what);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind118 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CallThreadSafe, 3400424181ul);

    /// <summary>
    /// <para>This function ensures that the calling of this function will succeed, no matter whether it's being done from a thread or not. If called from a thread that is not allowed to call the function, the call will become deferred. Otherwise, the call will go through directly.</para>
    /// </summary>
    public Variant CallThreadSafe(StringName method, params Variant[] @args)
    {
        return NativeCalls.godot_icall_2_893(MethodBind118, GodotObject.GetPtr(this), (godot_string_name)(method?.NativeValue ?? default), @args, (godot_string_name)MethodName.CallThreadSafe.NativeValue);
    }

    /// <summary>
    /// <para>This function ensures that the calling of this function will succeed, no matter whether it's being done from a thread or not. If called from a thread that is not allowed to call the function, the call will become deferred. Otherwise, the call will go through directly.</para>
    /// </summary>
    public Variant CallThreadSafe(StringName method, ReadOnlySpan<Variant> @args)
    {
        return NativeCalls.godot_icall_2_893(MethodBind118, GodotObject.GetPtr(this), (godot_string_name)(method?.NativeValue ?? default), @args, (godot_string_name)MethodName.CallThreadSafe.NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind119 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetThreadSafe, 3776071444ul);

    /// <summary>
    /// <para>Similar to <see cref="Godot.Node.CallThreadSafe(StringName, Variant[])"/>, but for setting properties.</para>
    /// </summary>
    public void SetThreadSafe(StringName property, Variant value)
    {
        NativeCalls.godot_icall_2_142(MethodBind119, GodotObject.GetPtr(this), (godot_string_name)(property?.NativeValue ?? default), value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind120 = ClassDB_get_method_with_compatibility(NativeName, MethodName.NotifyThreadSafe, 1286410249ul);

    /// <summary>
    /// <para>Similar to <see cref="Godot.Node.CallThreadSafe(StringName, Variant[])"/>, but for notifications.</para>
    /// </summary>
    public void NotifyThreadSafe(int what)
    {
        NativeCalls.godot_icall_1_38(MethodBind120, GodotObject.GetPtr(this), what);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind121 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRpcConfig, 1214101251ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Variant GetRpcConfig()
    {
        return NativeCalls.godot_icall_0_772(MethodBind121, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind122 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetName, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetName(string name)
    {
        NativeCalls.godot_icall_1_57(MethodBind122, GodotObject.GetPtr(this), name);
    }

    /// <summary>
    /// <para>Emitted when the node is considered ready, after <see cref="Godot.Node._Ready()"/> is called.</para>
    /// </summary>
    public event Action Ready
    {
        add => Connect(SignalName.Ready, Callable.From(value));
        remove => Disconnect(SignalName.Ready, Callable.From(value));
    }

    protected void EmitSignalReady()
    {
        EmitSignal(SignalName.Ready);
    }

    /// <summary>
    /// <para>Emitted when the node's <see cref="Godot.Node.Name"/> is changed, if the node is inside the tree.</para>
    /// </summary>
    public event Action Renamed
    {
        add => Connect(SignalName.Renamed, Callable.From(value));
        remove => Disconnect(SignalName.Renamed, Callable.From(value));
    }

    protected void EmitSignalRenamed()
    {
        EmitSignal(SignalName.Renamed);
    }

    /// <summary>
    /// <para>Emitted when the node enters the tree.</para>
    /// <para>This signal is emitted <i>after</i> the related <see cref="Godot.Node.NotificationEnterTree"/> notification.</para>
    /// </summary>
    public event Action TreeEntered
    {
        add => Connect(SignalName.TreeEntered, Callable.From(value));
        remove => Disconnect(SignalName.TreeEntered, Callable.From(value));
    }

    protected void EmitSignalTreeEntered()
    {
        EmitSignal(SignalName.TreeEntered);
    }

    /// <summary>
    /// <para>Emitted when the node is just about to exit the tree. The node is still valid. As such, this is the right place for de-initialization (or a "destructor", if you will).</para>
    /// <para>This signal is emitted <i>after</i> the node's <see cref="Godot.Node._ExitTree()"/>, and <i>before</i> the related <see cref="Godot.Node.NotificationExitTree"/>.</para>
    /// </summary>
    public event Action TreeExiting
    {
        add => Connect(SignalName.TreeExiting, Callable.From(value));
        remove => Disconnect(SignalName.TreeExiting, Callable.From(value));
    }

    protected void EmitSignalTreeExiting()
    {
        EmitSignal(SignalName.TreeExiting);
    }

    /// <summary>
    /// <para>Emitted after the node exits the tree and is no longer active.</para>
    /// <para>This signal is emitted <i>after</i> the related <see cref="Godot.Node.NotificationExitTree"/> notification.</para>
    /// </summary>
    public event Action TreeExited
    {
        add => Connect(SignalName.TreeExited, Callable.From(value));
        remove => Disconnect(SignalName.TreeExited, Callable.From(value));
    }

    protected void EmitSignalTreeExited()
    {
        EmitSignal(SignalName.TreeExited);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.Node.ChildEnteredTree"/> event of a <see cref="Godot.Node"/> class.
    /// </summary>
    public delegate void ChildEnteredTreeEventHandler(Node node);

    private static void ChildEnteredTreeTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((ChildEnteredTreeEventHandler)delegateObj)(VariantUtils.ConvertTo<Node>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when the child <c>node</c> enters the <see cref="Godot.SceneTree"/>, usually because this node entered the tree (see <see cref="Godot.Node.TreeEntered"/>), or <see cref="Godot.Node.AddChild(Node, bool, Node.InternalMode)"/> has been called.</para>
    /// <para>This signal is emitted <i>after</i> the child node's own <see cref="Godot.Node.NotificationEnterTree"/> and <see cref="Godot.Node.TreeEntered"/>.</para>
    /// </summary>
    public unsafe event ChildEnteredTreeEventHandler ChildEnteredTree
    {
        add => Connect(SignalName.ChildEnteredTree, Callable.CreateWithUnsafeTrampoline(value, &ChildEnteredTreeTrampoline));
        remove => Disconnect(SignalName.ChildEnteredTree, Callable.CreateWithUnsafeTrampoline(value, &ChildEnteredTreeTrampoline));
    }

    protected void EmitSignalChildEnteredTree(Node node)
    {
        EmitSignal(SignalName.ChildEnteredTree, node);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.Node.ChildExitingTree"/> event of a <see cref="Godot.Node"/> class.
    /// </summary>
    public delegate void ChildExitingTreeEventHandler(Node node);

    private static void ChildExitingTreeTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((ChildExitingTreeEventHandler)delegateObj)(VariantUtils.ConvertTo<Node>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when the child <c>node</c> is about to exit the <see cref="Godot.SceneTree"/>, usually because this node is exiting the tree (see <see cref="Godot.Node.TreeExiting"/>), or because the child <c>node</c> is being removed or freed.</para>
    /// <para>When this signal is received, the child <c>node</c> is still accessible inside the tree. This signal is emitted <i>after</i> the child node's own <see cref="Godot.Node.TreeExiting"/> and <see cref="Godot.Node.NotificationExitTree"/>.</para>
    /// </summary>
    public unsafe event ChildExitingTreeEventHandler ChildExitingTree
    {
        add => Connect(SignalName.ChildExitingTree, Callable.CreateWithUnsafeTrampoline(value, &ChildExitingTreeTrampoline));
        remove => Disconnect(SignalName.ChildExitingTree, Callable.CreateWithUnsafeTrampoline(value, &ChildExitingTreeTrampoline));
    }

    protected void EmitSignalChildExitingTree(Node node)
    {
        EmitSignal(SignalName.ChildExitingTree, node);
    }

    /// <summary>
    /// <para>Emitted when the list of children is changed. This happens when child nodes are added, moved or removed.</para>
    /// </summary>
    public event Action ChildOrderChanged
    {
        add => Connect(SignalName.ChildOrderChanged, Callable.From(value));
        remove => Disconnect(SignalName.ChildOrderChanged, Callable.From(value));
    }

    protected void EmitSignalChildOrderChanged()
    {
        EmitSignal(SignalName.ChildOrderChanged);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.Node.ReplacingBy"/> event of a <see cref="Godot.Node"/> class.
    /// </summary>
    public delegate void ReplacingByEventHandler(Node node);

    private static void ReplacingByTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((ReplacingByEventHandler)delegateObj)(VariantUtils.ConvertTo<Node>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when this node is being replaced by the <c>node</c>, see <see cref="Godot.Node.ReplaceBy(Node, bool)"/>.</para>
    /// <para>This signal is emitted <i>after</i> <c>node</c> has been added as a child of the original parent node, but <i>before</i> all original child nodes have been reparented to <c>node</c>.</para>
    /// </summary>
    public unsafe event ReplacingByEventHandler ReplacingBy
    {
        add => Connect(SignalName.ReplacingBy, Callable.CreateWithUnsafeTrampoline(value, &ReplacingByTrampoline));
        remove => Disconnect(SignalName.ReplacingBy, Callable.CreateWithUnsafeTrampoline(value, &ReplacingByTrampoline));
    }

    protected void EmitSignalReplacingBy(Node node)
    {
        EmitSignal(SignalName.ReplacingBy, node);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.Node.EditorDescriptionChanged"/> event of a <see cref="Godot.Node"/> class.
    /// </summary>
    public delegate void EditorDescriptionChangedEventHandler(Node node);

    private static void EditorDescriptionChangedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((EditorDescriptionChangedEventHandler)delegateObj)(VariantUtils.ConvertTo<Node>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when the node's editor description field changed.</para>
    /// </summary>
    public unsafe event EditorDescriptionChangedEventHandler EditorDescriptionChanged
    {
        add => Connect(SignalName.EditorDescriptionChanged, Callable.CreateWithUnsafeTrampoline(value, &EditorDescriptionChangedTrampoline));
        remove => Disconnect(SignalName.EditorDescriptionChanged, Callable.CreateWithUnsafeTrampoline(value, &EditorDescriptionChangedTrampoline));
    }

    protected void EmitSignalEditorDescriptionChanged(Node node)
    {
        EmitSignal(SignalName.EditorDescriptionChanged, node);
    }

    /// <summary>
    /// <para>Emitted when an attribute of the node that is relevant to the editor is changed. Only emitted in the editor.</para>
    /// </summary>
    public event Action EditorStateChanged
    {
        add => Connect(SignalName.EditorStateChanged, Callable.From(value));
        remove => Disconnect(SignalName.EditorStateChanged, Callable.From(value));
    }

    protected void EmitSignalEditorStateChanged()
    {
        EmitSignal(SignalName.EditorStateChanged);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__enter_tree = "_EnterTree";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__exit_tree = "_ExitTree";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_accessibility_configuration_warnings = "_GetAccessibilityConfigurationWarnings";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_configuration_warnings = "_GetConfigurationWarnings";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_focused_accessibility_element = "_GetFocusedAccessibilityElement";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__input = "_Input";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__physics_process = "_PhysicsProcess";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__process = "_Process";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__ready = "_Ready";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__shortcut_input = "_ShortcutInput";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__unhandled_input = "_UnhandledInput";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__unhandled_key_input = "_UnhandledKeyInput";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_ready = "Ready";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_renamed = "Renamed";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_tree_entered = "TreeEntered";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_tree_exiting = "TreeExiting";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_tree_exited = "TreeExited";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_child_entered_tree = "ChildEnteredTree";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_child_exiting_tree = "ChildExitingTree";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_child_order_changed = "ChildOrderChanged";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_replacing_by = "ReplacingBy";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_editor_description_changed = "EditorDescriptionChanged";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_editor_state_changed = "EditorStateChanged";

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
        if ((method == MethodProxyName__enter_tree || method == MethodName._EnterTree) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__enter_tree.NativeValue))
        {
            _EnterTree();
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__exit_tree || method == MethodName._ExitTree) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__exit_tree.NativeValue))
        {
            _ExitTree();
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__get_accessibility_configuration_warnings || method == MethodName._GetAccessibilityConfigurationWarnings) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_accessibility_configuration_warnings.NativeValue))
        {
            var callRet = _GetAccessibilityConfigurationWarnings();
            ret = VariantUtils.CreateFrom<string[]>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_configuration_warnings || method == MethodName._GetConfigurationWarnings) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_configuration_warnings.NativeValue))
        {
            var callRet = _GetConfigurationWarnings();
            ret = VariantUtils.CreateFrom<string[]>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_focused_accessibility_element || method == MethodName._GetFocusedAccessibilityElement) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_focused_accessibility_element.NativeValue))
        {
            var callRet = _GetFocusedAccessibilityElement();
            ret = VariantUtils.CreateFrom<Rid>(callRet);
            return true;
        }
        if ((method == MethodProxyName__input || method == MethodName._Input) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__input.NativeValue))
        {
            _Input(VariantUtils.ConvertTo<InputEvent>(args[0]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__physics_process || method == MethodName._PhysicsProcess) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__physics_process.NativeValue))
        {
            _PhysicsProcess(VariantUtils.ConvertTo<double>(args[0]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__process || method == MethodName._Process) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__process.NativeValue))
        {
            _Process(VariantUtils.ConvertTo<double>(args[0]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__ready || method == MethodName._Ready) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__ready.NativeValue))
        {
            _Ready();
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__shortcut_input || method == MethodName._ShortcutInput) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__shortcut_input.NativeValue))
        {
            _ShortcutInput(VariantUtils.ConvertTo<InputEvent>(args[0]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__unhandled_input || method == MethodName._UnhandledInput) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__unhandled_input.NativeValue))
        {
            _UnhandledInput(VariantUtils.ConvertTo<InputEvent>(args[0]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__unhandled_key_input || method == MethodName._UnhandledKeyInput) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__unhandled_key_input.NativeValue))
        {
            _UnhandledKeyInput(VariantUtils.ConvertTo<InputEvent>(args[0]));
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
        if (method == MethodName._EnterTree)
        {
            if (HasGodotClassMethod(MethodProxyName__enter_tree.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ExitTree)
        {
            if (HasGodotClassMethod(MethodProxyName__exit_tree.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetAccessibilityConfigurationWarnings)
        {
            if (HasGodotClassMethod(MethodProxyName__get_accessibility_configuration_warnings.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetConfigurationWarnings)
        {
            if (HasGodotClassMethod(MethodProxyName__get_configuration_warnings.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetFocusedAccessibilityElement)
        {
            if (HasGodotClassMethod(MethodProxyName__get_focused_accessibility_element.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._Input)
        {
            if (HasGodotClassMethod(MethodProxyName__input.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._PhysicsProcess)
        {
            if (HasGodotClassMethod(MethodProxyName__physics_process.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._Process)
        {
            if (HasGodotClassMethod(MethodProxyName__process.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._Ready)
        {
            if (HasGodotClassMethod(MethodProxyName__ready.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ShortcutInput)
        {
            if (HasGodotClassMethod(MethodProxyName__shortcut_input.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._UnhandledInput)
        {
            if (HasGodotClassMethod(MethodProxyName__unhandled_input.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._UnhandledKeyInput)
        {
            if (HasGodotClassMethod(MethodProxyName__unhandled_key_input.NativeValue.DangerousSelfRef))
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
        if (signal == SignalName.Ready)
        {
            if (HasGodotClassSignal(SignalProxyName_ready.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.Renamed)
        {
            if (HasGodotClassSignal(SignalProxyName_renamed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.TreeEntered)
        {
            if (HasGodotClassSignal(SignalProxyName_tree_entered.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.TreeExiting)
        {
            if (HasGodotClassSignal(SignalProxyName_tree_exiting.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.TreeExited)
        {
            if (HasGodotClassSignal(SignalProxyName_tree_exited.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.ChildEnteredTree)
        {
            if (HasGodotClassSignal(SignalProxyName_child_entered_tree.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.ChildExitingTree)
        {
            if (HasGodotClassSignal(SignalProxyName_child_exiting_tree.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.ChildOrderChanged)
        {
            if (HasGodotClassSignal(SignalProxyName_child_order_changed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.ReplacingBy)
        {
            if (HasGodotClassSignal(SignalProxyName_replacing_by.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.EditorDescriptionChanged)
        {
            if (HasGodotClassSignal(SignalProxyName_editor_description_changed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.EditorStateChanged)
        {
            if (HasGodotClassSignal(SignalProxyName_editor_state_changed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        return base.HasGodotClassSignal(signal);
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : GodotObject.PropertyName
    {
        /// <summary>
        /// Cached name for the 'name' property.
        /// </summary>
        public static readonly StringName Name = "name";
        /// <summary>
        /// Cached name for the 'unique_name_in_owner' property.
        /// </summary>
        public static readonly StringName UniqueNameInOwner = "unique_name_in_owner";
        /// <summary>
        /// Cached name for the 'scene_file_path' property.
        /// </summary>
        public static readonly StringName SceneFilePath = "scene_file_path";
        /// <summary>
        /// Cached name for the 'owner' property.
        /// </summary>
        public static readonly StringName Owner = "owner";
        /// <summary>
        /// Cached name for the 'multiplayer' property.
        /// </summary>
        public static readonly StringName Multiplayer = "multiplayer";
        /// <summary>
        /// Cached name for the 'process_mode' property.
        /// </summary>
        public static readonly StringName ProcessMode = "process_mode";
        /// <summary>
        /// Cached name for the 'process_priority' property.
        /// </summary>
        public static readonly StringName ProcessPriority = "process_priority";
        /// <summary>
        /// Cached name for the 'process_physics_priority' property.
        /// </summary>
        public static readonly StringName ProcessPhysicsPriority = "process_physics_priority";
        /// <summary>
        /// Cached name for the 'process_thread_group' property.
        /// </summary>
        public static readonly StringName ProcessThreadGroup = "process_thread_group";
        /// <summary>
        /// Cached name for the 'process_thread_group_order' property.
        /// </summary>
        public static readonly StringName ProcessThreadGroupOrder = "process_thread_group_order";
        /// <summary>
        /// Cached name for the 'process_thread_messages' property.
        /// </summary>
        public static readonly StringName ProcessThreadMessages = "process_thread_messages";
        /// <summary>
        /// Cached name for the 'physics_interpolation_mode' property.
        /// </summary>
        public static readonly StringName PhysicsInterpolationMode = "physics_interpolation_mode";
        /// <summary>
        /// Cached name for the 'auto_translate_mode' property.
        /// </summary>
        public static readonly StringName AutoTranslateMode = "auto_translate_mode";
        /// <summary>
        /// Cached name for the 'editor_description' property.
        /// </summary>
        public static readonly StringName EditorDescription = "editor_description";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : GodotObject.MethodName
    {
        /// <summary>
        /// Cached name for the '_enter_tree' method.
        /// </summary>
        public static readonly StringName _EnterTree = "_enter_tree";
        /// <summary>
        /// Cached name for the '_exit_tree' method.
        /// </summary>
        public static readonly StringName _ExitTree = "_exit_tree";
        /// <summary>
        /// Cached name for the '_get_accessibility_configuration_warnings' method.
        /// </summary>
        public static readonly StringName _GetAccessibilityConfigurationWarnings = "_get_accessibility_configuration_warnings";
        /// <summary>
        /// Cached name for the '_get_configuration_warnings' method.
        /// </summary>
        public static readonly StringName _GetConfigurationWarnings = "_get_configuration_warnings";
        /// <summary>
        /// Cached name for the '_get_focused_accessibility_element' method.
        /// </summary>
        public static readonly StringName _GetFocusedAccessibilityElement = "_get_focused_accessibility_element";
        /// <summary>
        /// Cached name for the '_input' method.
        /// </summary>
        public static readonly StringName _Input = "_input";
        /// <summary>
        /// Cached name for the '_physics_process' method.
        /// </summary>
        public static readonly StringName _PhysicsProcess = "_physics_process";
        /// <summary>
        /// Cached name for the '_process' method.
        /// </summary>
        public static readonly StringName _Process = "_process";
        /// <summary>
        /// Cached name for the '_ready' method.
        /// </summary>
        public static readonly StringName _Ready = "_ready";
        /// <summary>
        /// Cached name for the '_shortcut_input' method.
        /// </summary>
        public static readonly StringName _ShortcutInput = "_shortcut_input";
        /// <summary>
        /// Cached name for the '_unhandled_input' method.
        /// </summary>
        public static readonly StringName _UnhandledInput = "_unhandled_input";
        /// <summary>
        /// Cached name for the '_unhandled_key_input' method.
        /// </summary>
        public static readonly StringName _UnhandledKeyInput = "_unhandled_key_input";
        /// <summary>
        /// Cached name for the 'print_orphan_nodes' method.
        /// </summary>
        public static readonly StringName PrintOrphanNodes = "print_orphan_nodes";
        /// <summary>
        /// Cached name for the 'get_orphan_node_ids' method.
        /// </summary>
        public static readonly StringName GetOrphanNodeIds = "get_orphan_node_ids";
        /// <summary>
        /// Cached name for the 'add_sibling' method.
        /// </summary>
        public static readonly StringName AddSibling = "add_sibling";
        /// <summary>
        /// Cached name for the 'set_name' method.
        /// </summary>
        public static readonly StringName SetName = "set_name";
        /// <summary>
        /// Cached name for the 'get_name' method.
        /// </summary>
        public static readonly StringName GetName = "get_name";
        /// <summary>
        /// Cached name for the 'add_child' method.
        /// </summary>
        public static readonly StringName AddChild = "add_child";
        /// <summary>
        /// Cached name for the 'remove_child' method.
        /// </summary>
        public static readonly StringName RemoveChild = "remove_child";
        /// <summary>
        /// Cached name for the 'reparent' method.
        /// </summary>
        public static readonly StringName Reparent = "reparent";
        /// <summary>
        /// Cached name for the 'get_child_count' method.
        /// </summary>
        public static readonly StringName GetChildCount = "get_child_count";
        /// <summary>
        /// Cached name for the 'get_children' method.
        /// </summary>
        public static readonly StringName GetChildren = "get_children";
        /// <summary>
        /// Cached name for the 'get_child' method.
        /// </summary>
        public static readonly StringName GetChild = "get_child";
        /// <summary>
        /// Cached name for the 'has_node' method.
        /// </summary>
        public static readonly StringName HasNode = "has_node";
        /// <summary>
        /// Cached name for the 'get_node' method.
        /// </summary>
        public static readonly StringName GetNode = "get_node";
        /// <summary>
        /// Cached name for the 'get_node_or_null' method.
        /// </summary>
        public static readonly StringName GetNodeOrNull = "get_node_or_null";
        /// <summary>
        /// Cached name for the 'get_parent' method.
        /// </summary>
        public static readonly StringName GetParent = "get_parent";
        /// <summary>
        /// Cached name for the 'find_child' method.
        /// </summary>
        public static readonly StringName FindChild = "find_child";
        /// <summary>
        /// Cached name for the 'find_children' method.
        /// </summary>
        public static readonly StringName FindChildren = "find_children";
        /// <summary>
        /// Cached name for the 'find_parent' method.
        /// </summary>
        public static readonly StringName FindParent = "find_parent";
        /// <summary>
        /// Cached name for the 'has_node_and_resource' method.
        /// </summary>
        public static readonly StringName HasNodeAndResource = "has_node_and_resource";
        /// <summary>
        /// Cached name for the 'get_node_and_resource' method.
        /// </summary>
        public static readonly StringName GetNodeAndResource = "get_node_and_resource";
        /// <summary>
        /// Cached name for the 'is_inside_tree' method.
        /// </summary>
        public static readonly StringName IsInsideTree = "is_inside_tree";
        /// <summary>
        /// Cached name for the 'is_part_of_edited_scene' method.
        /// </summary>
        public static readonly StringName IsPartOfEditedScene = "is_part_of_edited_scene";
        /// <summary>
        /// Cached name for the 'is_ancestor_of' method.
        /// </summary>
        public static readonly StringName IsAncestorOf = "is_ancestor_of";
        /// <summary>
        /// Cached name for the 'is_greater_than' method.
        /// </summary>
        public static readonly StringName IsGreaterThan = "is_greater_than";
        /// <summary>
        /// Cached name for the 'get_path' method.
        /// </summary>
        public static readonly StringName GetPath = "get_path";
        /// <summary>
        /// Cached name for the 'get_path_to' method.
        /// </summary>
        public static readonly StringName GetPathTo = "get_path_to";
        /// <summary>
        /// Cached name for the 'add_to_group' method.
        /// </summary>
        public static readonly StringName AddToGroup = "add_to_group";
        /// <summary>
        /// Cached name for the 'remove_from_group' method.
        /// </summary>
        public static readonly StringName RemoveFromGroup = "remove_from_group";
        /// <summary>
        /// Cached name for the 'is_in_group' method.
        /// </summary>
        public static readonly StringName IsInGroup = "is_in_group";
        /// <summary>
        /// Cached name for the 'move_child' method.
        /// </summary>
        public static readonly StringName MoveChild = "move_child";
        /// <summary>
        /// Cached name for the 'get_groups' method.
        /// </summary>
        public static readonly StringName GetGroups = "get_groups";
        /// <summary>
        /// Cached name for the 'set_owner' method.
        /// </summary>
        public static readonly StringName SetOwner = "set_owner";
        /// <summary>
        /// Cached name for the 'get_owner' method.
        /// </summary>
        public static readonly StringName GetOwner = "get_owner";
        /// <summary>
        /// Cached name for the 'get_index' method.
        /// </summary>
        public static readonly StringName GetIndex = "get_index";
        /// <summary>
        /// Cached name for the 'print_tree' method.
        /// </summary>
        public static readonly StringName PrintTree = "print_tree";
        /// <summary>
        /// Cached name for the 'print_tree_pretty' method.
        /// </summary>
        public static readonly StringName PrintTreePretty = "print_tree_pretty";
        /// <summary>
        /// Cached name for the 'get_tree_string' method.
        /// </summary>
        public static readonly StringName GetTreeString = "get_tree_string";
        /// <summary>
        /// Cached name for the 'get_tree_string_pretty' method.
        /// </summary>
        public static readonly StringName GetTreeStringPretty = "get_tree_string_pretty";
        /// <summary>
        /// Cached name for the 'set_scene_file_path' method.
        /// </summary>
        public static readonly StringName SetSceneFilePath = "set_scene_file_path";
        /// <summary>
        /// Cached name for the 'get_scene_file_path' method.
        /// </summary>
        public static readonly StringName GetSceneFilePath = "get_scene_file_path";
        /// <summary>
        /// Cached name for the 'propagate_notification' method.
        /// </summary>
        public static readonly StringName PropagateNotification = "propagate_notification";
        /// <summary>
        /// Cached name for the 'propagate_call' method.
        /// </summary>
        public static readonly StringName PropagateCall = "propagate_call";
        /// <summary>
        /// Cached name for the 'set_physics_process' method.
        /// </summary>
        public static readonly StringName SetPhysicsProcess = "set_physics_process";
        /// <summary>
        /// Cached name for the 'get_physics_process_delta_time' method.
        /// </summary>
        public static readonly StringName GetPhysicsProcessDeltaTime = "get_physics_process_delta_time";
        /// <summary>
        /// Cached name for the 'is_physics_processing' method.
        /// </summary>
        public static readonly StringName IsPhysicsProcessing = "is_physics_processing";
        /// <summary>
        /// Cached name for the 'get_process_delta_time' method.
        /// </summary>
        public static readonly StringName GetProcessDeltaTime = "get_process_delta_time";
        /// <summary>
        /// Cached name for the 'set_process' method.
        /// </summary>
        public static readonly StringName SetProcess = "set_process";
        /// <summary>
        /// Cached name for the 'set_process_priority' method.
        /// </summary>
        public static readonly StringName SetProcessPriority = "set_process_priority";
        /// <summary>
        /// Cached name for the 'get_process_priority' method.
        /// </summary>
        public static readonly StringName GetProcessPriority = "get_process_priority";
        /// <summary>
        /// Cached name for the 'set_physics_process_priority' method.
        /// </summary>
        public static readonly StringName SetPhysicsProcessPriority = "set_physics_process_priority";
        /// <summary>
        /// Cached name for the 'get_physics_process_priority' method.
        /// </summary>
        public static readonly StringName GetPhysicsProcessPriority = "get_physics_process_priority";
        /// <summary>
        /// Cached name for the 'is_processing' method.
        /// </summary>
        public static readonly StringName IsProcessing = "is_processing";
        /// <summary>
        /// Cached name for the 'set_process_input' method.
        /// </summary>
        public static readonly StringName SetProcessInput = "set_process_input";
        /// <summary>
        /// Cached name for the 'is_processing_input' method.
        /// </summary>
        public static readonly StringName IsProcessingInput = "is_processing_input";
        /// <summary>
        /// Cached name for the 'set_process_shortcut_input' method.
        /// </summary>
        public static readonly StringName SetProcessShortcutInput = "set_process_shortcut_input";
        /// <summary>
        /// Cached name for the 'is_processing_shortcut_input' method.
        /// </summary>
        public static readonly StringName IsProcessingShortcutInput = "is_processing_shortcut_input";
        /// <summary>
        /// Cached name for the 'set_process_unhandled_input' method.
        /// </summary>
        public static readonly StringName SetProcessUnhandledInput = "set_process_unhandled_input";
        /// <summary>
        /// Cached name for the 'is_processing_unhandled_input' method.
        /// </summary>
        public static readonly StringName IsProcessingUnhandledInput = "is_processing_unhandled_input";
        /// <summary>
        /// Cached name for the 'set_process_unhandled_key_input' method.
        /// </summary>
        public static readonly StringName SetProcessUnhandledKeyInput = "set_process_unhandled_key_input";
        /// <summary>
        /// Cached name for the 'is_processing_unhandled_key_input' method.
        /// </summary>
        public static readonly StringName IsProcessingUnhandledKeyInput = "is_processing_unhandled_key_input";
        /// <summary>
        /// Cached name for the 'set_process_mode' method.
        /// </summary>
        public static readonly StringName SetProcessMode = "set_process_mode";
        /// <summary>
        /// Cached name for the 'get_process_mode' method.
        /// </summary>
        public static readonly StringName GetProcessMode = "get_process_mode";
        /// <summary>
        /// Cached name for the 'can_process' method.
        /// </summary>
        public static readonly StringName CanProcess = "can_process";
        /// <summary>
        /// Cached name for the 'set_process_thread_group' method.
        /// </summary>
        public static readonly StringName SetProcessThreadGroup = "set_process_thread_group";
        /// <summary>
        /// Cached name for the 'get_process_thread_group' method.
        /// </summary>
        public static readonly StringName GetProcessThreadGroup = "get_process_thread_group";
        /// <summary>
        /// Cached name for the 'set_process_thread_messages' method.
        /// </summary>
        public static readonly StringName SetProcessThreadMessages = "set_process_thread_messages";
        /// <summary>
        /// Cached name for the 'get_process_thread_messages' method.
        /// </summary>
        public static readonly StringName GetProcessThreadMessages = "get_process_thread_messages";
        /// <summary>
        /// Cached name for the 'set_process_thread_group_order' method.
        /// </summary>
        public static readonly StringName SetProcessThreadGroupOrder = "set_process_thread_group_order";
        /// <summary>
        /// Cached name for the 'get_process_thread_group_order' method.
        /// </summary>
        public static readonly StringName GetProcessThreadGroupOrder = "get_process_thread_group_order";
        /// <summary>
        /// Cached name for the 'queue_accessibility_update' method.
        /// </summary>
        public static readonly StringName QueueAccessibilityUpdate = "queue_accessibility_update";
        /// <summary>
        /// Cached name for the 'get_accessibility_element' method.
        /// </summary>
        public static readonly StringName GetAccessibilityElement = "get_accessibility_element";
        /// <summary>
        /// Cached name for the 'set_display_folded' method.
        /// </summary>
        public static readonly StringName SetDisplayFolded = "set_display_folded";
        /// <summary>
        /// Cached name for the 'is_displayed_folded' method.
        /// </summary>
        public static readonly StringName IsDisplayedFolded = "is_displayed_folded";
        /// <summary>
        /// Cached name for the 'set_process_internal' method.
        /// </summary>
        public static readonly StringName SetProcessInternal = "set_process_internal";
        /// <summary>
        /// Cached name for the 'is_processing_internal' method.
        /// </summary>
        public static readonly StringName IsProcessingInternal = "is_processing_internal";
        /// <summary>
        /// Cached name for the 'set_physics_process_internal' method.
        /// </summary>
        public static readonly StringName SetPhysicsProcessInternal = "set_physics_process_internal";
        /// <summary>
        /// Cached name for the 'is_physics_processing_internal' method.
        /// </summary>
        public static readonly StringName IsPhysicsProcessingInternal = "is_physics_processing_internal";
        /// <summary>
        /// Cached name for the 'set_physics_interpolation_mode' method.
        /// </summary>
        public static readonly StringName SetPhysicsInterpolationMode = "set_physics_interpolation_mode";
        /// <summary>
        /// Cached name for the 'get_physics_interpolation_mode' method.
        /// </summary>
        public static readonly StringName GetPhysicsInterpolationMode = "get_physics_interpolation_mode";
        /// <summary>
        /// Cached name for the 'is_physics_interpolated' method.
        /// </summary>
        public static readonly StringName IsPhysicsInterpolated = "is_physics_interpolated";
        /// <summary>
        /// Cached name for the 'is_physics_interpolated_and_enabled' method.
        /// </summary>
        public static readonly StringName IsPhysicsInterpolatedAndEnabled = "is_physics_interpolated_and_enabled";
        /// <summary>
        /// Cached name for the 'reset_physics_interpolation' method.
        /// </summary>
        public static readonly StringName ResetPhysicsInterpolation = "reset_physics_interpolation";
        /// <summary>
        /// Cached name for the 'set_auto_translate_mode' method.
        /// </summary>
        public static readonly StringName SetAutoTranslateMode = "set_auto_translate_mode";
        /// <summary>
        /// Cached name for the 'get_auto_translate_mode' method.
        /// </summary>
        public static readonly StringName GetAutoTranslateMode = "get_auto_translate_mode";
        /// <summary>
        /// Cached name for the 'can_auto_translate' method.
        /// </summary>
        public static readonly StringName CanAutoTranslate = "can_auto_translate";
        /// <summary>
        /// Cached name for the 'set_translation_domain_inherited' method.
        /// </summary>
        public static readonly StringName SetTranslationDomainInherited = "set_translation_domain_inherited";
        /// <summary>
        /// Cached name for the 'get_window' method.
        /// </summary>
        public static readonly StringName GetWindow = "get_window";
        /// <summary>
        /// Cached name for the 'get_last_exclusive_window' method.
        /// </summary>
        public static readonly StringName GetLastExclusiveWindow = "get_last_exclusive_window";
        /// <summary>
        /// Cached name for the 'get_tree' method.
        /// </summary>
        public static readonly StringName GetTree = "get_tree";
        /// <summary>
        /// Cached name for the 'create_tween' method.
        /// </summary>
        public static readonly StringName CreateTween = "create_tween";
        /// <summary>
        /// Cached name for the 'duplicate' method.
        /// </summary>
        public static readonly StringName Duplicate = "duplicate";
        /// <summary>
        /// Cached name for the 'replace_by' method.
        /// </summary>
        public static readonly StringName ReplaceBy = "replace_by";
        /// <summary>
        /// Cached name for the 'set_scene_instance_load_placeholder' method.
        /// </summary>
        public static readonly StringName SetSceneInstanceLoadPlaceholder = "set_scene_instance_load_placeholder";
        /// <summary>
        /// Cached name for the 'get_scene_instance_load_placeholder' method.
        /// </summary>
        public static readonly StringName GetSceneInstanceLoadPlaceholder = "get_scene_instance_load_placeholder";
        /// <summary>
        /// Cached name for the 'set_editable_instance' method.
        /// </summary>
        public static readonly StringName SetEditableInstance = "set_editable_instance";
        /// <summary>
        /// Cached name for the 'is_editable_instance' method.
        /// </summary>
        public static readonly StringName IsEditableInstance = "is_editable_instance";
        /// <summary>
        /// Cached name for the 'get_viewport' method.
        /// </summary>
        public static readonly StringName GetViewport = "get_viewport";
        /// <summary>
        /// Cached name for the 'queue_free' method.
        /// </summary>
        public static readonly StringName QueueFree = "queue_free";
        /// <summary>
        /// Cached name for the 'request_ready' method.
        /// </summary>
        public static readonly StringName RequestReady = "request_ready";
        /// <summary>
        /// Cached name for the 'is_node_ready' method.
        /// </summary>
        public static readonly StringName IsNodeReady = "is_node_ready";
        /// <summary>
        /// Cached name for the 'set_multiplayer_authority' method.
        /// </summary>
        public static readonly StringName SetMultiplayerAuthority = "set_multiplayer_authority";
        /// <summary>
        /// Cached name for the 'get_multiplayer_authority' method.
        /// </summary>
        public static readonly StringName GetMultiplayerAuthority = "get_multiplayer_authority";
        /// <summary>
        /// Cached name for the 'is_multiplayer_authority' method.
        /// </summary>
        public static readonly StringName IsMultiplayerAuthority = "is_multiplayer_authority";
        /// <summary>
        /// Cached name for the 'get_multiplayer' method.
        /// </summary>
        public static readonly StringName GetMultiplayer = "get_multiplayer";
        /// <summary>
        /// Cached name for the 'rpc_config' method.
        /// </summary>
        public static readonly StringName RpcConfig = "rpc_config";
        /// <summary>
        /// Cached name for the 'get_node_rpc_config' method.
        /// </summary>
        public static readonly StringName GetNodeRpcConfig = "get_node_rpc_config";
        /// <summary>
        /// Cached name for the 'set_editor_description' method.
        /// </summary>
        public static readonly StringName SetEditorDescription = "set_editor_description";
        /// <summary>
        /// Cached name for the 'get_editor_description' method.
        /// </summary>
        public static readonly StringName GetEditorDescription = "get_editor_description";
        /// <summary>
        /// Cached name for the 'set_unique_name_in_owner' method.
        /// </summary>
        public static readonly StringName SetUniqueNameInOwner = "set_unique_name_in_owner";
        /// <summary>
        /// Cached name for the 'is_unique_name_in_owner' method.
        /// </summary>
        public static readonly StringName IsUniqueNameInOwner = "is_unique_name_in_owner";
        /// <summary>
        /// Cached name for the 'atr' method.
        /// </summary>
        public static readonly StringName Atr = "atr";
        /// <summary>
        /// Cached name for the 'atr_n' method.
        /// </summary>
        public static readonly StringName AtrN = "atr_n";
        /// <summary>
        /// Cached name for the 'rpc' method.
        /// </summary>
        public static readonly StringName Rpc = "rpc";
        /// <summary>
        /// Cached name for the 'rpc_id' method.
        /// </summary>
        public static readonly StringName RpcId = "rpc_id";
        /// <summary>
        /// Cached name for the 'update_configuration_warnings' method.
        /// </summary>
        public static readonly StringName UpdateConfigurationWarnings = "update_configuration_warnings";
        /// <summary>
        /// Cached name for the 'call_deferred_thread_group' method.
        /// </summary>
        public static readonly StringName CallDeferredThreadGroup = "call_deferred_thread_group";
        /// <summary>
        /// Cached name for the 'set_deferred_thread_group' method.
        /// </summary>
        public static readonly StringName SetDeferredThreadGroup = "set_deferred_thread_group";
        /// <summary>
        /// Cached name for the 'notify_deferred_thread_group' method.
        /// </summary>
        public static readonly StringName NotifyDeferredThreadGroup = "notify_deferred_thread_group";
        /// <summary>
        /// Cached name for the 'call_thread_safe' method.
        /// </summary>
        public static readonly StringName CallThreadSafe = "call_thread_safe";
        /// <summary>
        /// Cached name for the 'set_thread_safe' method.
        /// </summary>
        public static readonly StringName SetThreadSafe = "set_thread_safe";
        /// <summary>
        /// Cached name for the 'notify_thread_safe' method.
        /// </summary>
        public static readonly StringName NotifyThreadSafe = "notify_thread_safe";
        /// <summary>
        /// Cached name for the 'get_rpc_config' method.
        /// </summary>
        public static readonly StringName GetRpcConfig = "get_rpc_config";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : GodotObject.SignalName
    {
        /// <summary>
        /// Cached name for the 'ready' signal.
        /// </summary>
        public static readonly StringName Ready = "ready";
        /// <summary>
        /// Cached name for the 'renamed' signal.
        /// </summary>
        public static readonly StringName Renamed = "renamed";
        /// <summary>
        /// Cached name for the 'tree_entered' signal.
        /// </summary>
        public static readonly StringName TreeEntered = "tree_entered";
        /// <summary>
        /// Cached name for the 'tree_exiting' signal.
        /// </summary>
        public static readonly StringName TreeExiting = "tree_exiting";
        /// <summary>
        /// Cached name for the 'tree_exited' signal.
        /// </summary>
        public static readonly StringName TreeExited = "tree_exited";
        /// <summary>
        /// Cached name for the 'child_entered_tree' signal.
        /// </summary>
        public static readonly StringName ChildEnteredTree = "child_entered_tree";
        /// <summary>
        /// Cached name for the 'child_exiting_tree' signal.
        /// </summary>
        public static readonly StringName ChildExitingTree = "child_exiting_tree";
        /// <summary>
        /// Cached name for the 'child_order_changed' signal.
        /// </summary>
        public static readonly StringName ChildOrderChanged = "child_order_changed";
        /// <summary>
        /// Cached name for the 'replacing_by' signal.
        /// </summary>
        public static readonly StringName ReplacingBy = "replacing_by";
        /// <summary>
        /// Cached name for the 'editor_description_changed' signal.
        /// </summary>
        public static readonly StringName EditorDescriptionChanged = "editor_description_changed";
        /// <summary>
        /// Cached name for the 'editor_state_changed' signal.
        /// </summary>
        public static readonly StringName EditorStateChanged = "editor_state_changed";
    }
}
