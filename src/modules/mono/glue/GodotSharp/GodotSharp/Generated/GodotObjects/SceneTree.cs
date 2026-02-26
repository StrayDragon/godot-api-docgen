namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>As one of the most important classes, the <see cref="Godot.SceneTree"/> manages the hierarchy of nodes in a scene, as well as scenes themselves. Nodes can be added, fetched and removed. The whole scene tree (and thus the current scene) can be paused. Scenes can be loaded, switched and reloaded.</para>
/// <para>You can also use the <see cref="Godot.SceneTree"/> to organize your nodes into <b>groups</b>: every node can be added to as many groups as you want to create, e.g. an "enemy" group. You can then iterate these groups or even call methods and set properties on all the nodes belonging to any given group.</para>
/// <para><see cref="Godot.SceneTree"/> is the default <see cref="Godot.MainLoop"/> implementation used by the engine, and is thus in charge of the game loop.</para>
/// </summary>
public partial class SceneTree : MainLoop
{
    public enum GroupCallFlags : long
    {
        /// <summary>
        /// <para>Call nodes within a group with no special behavior (default).</para>
        /// </summary>
        Default = 0,
        /// <summary>
        /// <para>Call nodes within a group in reverse tree hierarchy order (all nested children are called before their respective parent nodes).</para>
        /// </summary>
        Reverse = 1,
        /// <summary>
        /// <para>Call nodes within a group at the end of the current frame (can be either process or physics frame), similar to <see cref="Godot.GodotObject.CallDeferred(StringName, Variant[])"/>.</para>
        /// </summary>
        Deferred = 2,
        /// <summary>
        /// <para>Call nodes within a group only once, even if the call is executed many times in the same frame. Must be combined with <see cref="Godot.SceneTree.GroupCallFlags.Deferred"/> to work.</para>
        /// <para><b>Note:</b> Different arguments are not taken into account. Therefore, when the same call is executed with different arguments, only the first call will be performed.</para>
        /// </summary>
        Unique = 4
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the application automatically accepts quitting requests.</para>
    /// <para>For mobile platforms, see <see cref="Godot.SceneTree.QuitOnGoBack"/>.</para>
    /// </summary>
    public bool AutoAcceptQuit
    {
        get
        {
            return IsAutoAcceptQuit();
        }
        set
        {
            SetAutoAcceptQuit(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the application quits automatically when navigating back (e.g. using the system "Back" button on Android).</para>
    /// <para>To handle 'Go Back' button when this option is disabled, use <see cref="Godot.DisplayServer.WindowEvent.GoBackRequest"/>.</para>
    /// </summary>
    public bool QuitOnGoBack
    {
        get
        {
            return IsQuitOnGoBack();
        }
        set
        {
            SetQuitOnGoBack(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, collision shapes will be visible when running the game from the editor for debugging purposes.</para>
    /// <para><b>Note:</b> This property is not designed to be changed at run-time. Changing the value of <see cref="Godot.SceneTree.DebugCollisionsHint"/> while the project is running will not have the desired effect.</para>
    /// </summary>
    public bool DebugCollisionsHint
    {
        get
        {
            return IsDebuggingCollisionsHint();
        }
        set
        {
            SetDebugCollisionsHint(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, curves from <see cref="Godot.Path2D"/> and <see cref="Godot.Path3D"/> nodes will be visible when running the game from the editor for debugging purposes.</para>
    /// <para><b>Note:</b> This property is not designed to be changed at run-time. Changing the value of <see cref="Godot.SceneTree.DebugPathsHint"/> while the project is running will not have the desired effect.</para>
    /// </summary>
    public bool DebugPathsHint
    {
        get
        {
            return IsDebuggingPathsHint();
        }
        set
        {
            SetDebugPathsHint(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, navigation polygons will be visible when running the game from the editor for debugging purposes.</para>
    /// <para><b>Note:</b> This property is not designed to be changed at run-time. Changing the value of <see cref="Godot.SceneTree.DebugNavigationHint"/> while the project is running will not have the desired effect.</para>
    /// </summary>
    public bool DebugNavigationHint
    {
        get
        {
            return IsDebuggingNavigationHint();
        }
        set
        {
            SetDebugNavigationHint(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the scene tree is considered paused. This causes the following behavior:</para>
    /// <para>- 2D and 3D physics will be stopped, as well as collision detection and related signals.</para>
    /// <para>- Depending on each node's <see cref="Godot.Node.ProcessMode"/>, their <see cref="Godot.Node._Process(double)"/>, <see cref="Godot.Node._PhysicsProcess(double)"/> and <see cref="Godot.Node._Input(InputEvent)"/> callback methods may not called anymore.</para>
    /// </summary>
    public bool Paused
    {
        get
        {
            return IsPaused();
        }
        set
        {
            SetPause(value);
        }
    }

    /// <summary>
    /// <para>The root of the scene currently being edited in the editor. This is usually a direct child of <see cref="Godot.SceneTree.Root"/>.</para>
    /// <para><b>Note:</b> This property does nothing in release builds.</para>
    /// </summary>
    public Node EditedSceneRoot
    {
        get
        {
            return GetEditedSceneRoot();
        }
        set
        {
            SetEditedSceneRoot(value);
        }
    }

    /// <summary>
    /// <para>The root node of the currently loaded main scene, usually as a direct child of <see cref="Godot.SceneTree.Root"/>. See also <see cref="Godot.SceneTree.ChangeSceneToFile(string)"/>, <see cref="Godot.SceneTree.ChangeSceneToPacked(PackedScene)"/>, and <see cref="Godot.SceneTree.ReloadCurrentScene()"/>.</para>
    /// <para><b>Warning:</b> Setting this property directly may not work as expected, as it does <i>not</i> add or remove any nodes from this tree.</para>
    /// </summary>
    public Node CurrentScene
    {
        get
        {
            return GetCurrentScene();
        }
        set
        {
            SetCurrentScene(value);
        }
    }

    /// <summary>
    /// <para>The tree's root <see cref="Godot.Window"/>. This is top-most <see cref="Godot.Node"/> of the scene tree, and is always present. An absolute <see cref="Godot.NodePath"/> always starts from this node. Children of the root node may include the loaded <see cref="Godot.SceneTree.CurrentScene"/>, as well as any <a href="$DOCS_URL/tutorials/scripting/singletons_autoload.html">AutoLoad</a> configured in the Project Settings.</para>
    /// <para><b>Warning:</b> Do not delete this node. This will result in unstable behavior, followed by a crash.</para>
    /// </summary>
    public Window Root
    {
        get
        {
            return GetRoot();
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/> (default value), enables automatic polling of the <see cref="Godot.MultiplayerApi"/> for this SceneTree during <see cref="Godot.SceneTree.ProcessFrame"/>.</para>
    /// <para>If <see langword="false"/>, you need to manually call <see cref="Godot.MultiplayerApi.Poll()"/> to process network packets and deliver RPCs. This allows running RPCs in a different loop (e.g. physics, thread, specific time step) and for manual <see cref="Godot.Mutex"/> protection when accessing the <see cref="Godot.MultiplayerApi"/> from threads.</para>
    /// </summary>
    public bool MultiplayerPoll
    {
        get
        {
            return IsMultiplayerPollEnabled();
        }
        set
        {
            SetMultiplayerPollEnabled(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the renderer will interpolate the transforms of objects (both physics and non-physics) between the last two transforms, so that smooth motion is seen even when physics ticks do not coincide with rendered frames.</para>
    /// <para>The default value of this property is controlled by <c>ProjectSettings.physics/common/physics_interpolation</c>.</para>
    /// <para><b>Note:</b> Although this is a global setting, finer control of individual branches of the <see cref="Godot.SceneTree"/> is possible using <see cref="Godot.Node.PhysicsInterpolationMode"/>.</para>
    /// </summary>
    public bool PhysicsInterpolation
    {
        get
        {
            return IsPhysicsInterpolationEnabled();
        }
        set
        {
            SetPhysicsInterpolationEnabled(value);
        }
    }

    private static readonly System.Type CachedType = typeof(SceneTree);

    private static readonly StringName NativeName = "SceneTree";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public SceneTree() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal SceneTree(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal SceneTree(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRoot, 1757182445ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Window GetRoot()
    {
        return (Window)NativeCalls.godot_icall_0_53(MethodBind0, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasGroup, 2619796661ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if a node added to the given group <paramref name="name"/> exists in the tree.</para>
    /// </summary>
    public bool HasGroup(StringName name)
    {
        return NativeCalls.godot_icall_1_105(MethodBind1, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsAccessibilityEnabled, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if accessibility features are enabled, and accessibility information updates are actively processed.</para>
    /// </summary>
    public bool IsAccessibilityEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind2, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsAccessibilitySupported, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if accessibility features are supported by the OS and enabled in project settings.</para>
    /// </summary>
    public bool IsAccessibilitySupported()
    {
        return NativeCalls.godot_icall_0_15(MethodBind3, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsAutoAcceptQuit, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsAutoAcceptQuit()
    {
        return NativeCalls.godot_icall_0_15(MethodBind4, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAutoAcceptQuit, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAutoAcceptQuit(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind5, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsQuitOnGoBack, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsQuitOnGoBack()
    {
        return NativeCalls.godot_icall_0_15(MethodBind6, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetQuitOnGoBack, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetQuitOnGoBack(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind7, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDebugCollisionsHint, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDebugCollisionsHint(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind8, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsDebuggingCollisionsHint, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsDebuggingCollisionsHint()
    {
        return NativeCalls.godot_icall_0_15(MethodBind9, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDebugPathsHint, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDebugPathsHint(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind10, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsDebuggingPathsHint, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsDebuggingPathsHint()
    {
        return NativeCalls.godot_icall_0_15(MethodBind11, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDebugNavigationHint, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDebugNavigationHint(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind12, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsDebuggingNavigationHint, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsDebuggingNavigationHint()
    {
        return NativeCalls.godot_icall_0_15(MethodBind13, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEditedSceneRoot, 1078189570ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEditedSceneRoot(Node scene)
    {
        NativeCalls.godot_icall_1_56(MethodBind14, GodotObject.GetPtr(this), GodotObject.GetPtr(scene));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEditedSceneRoot, 3160264692ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Node GetEditedSceneRoot()
    {
        return (Node)NativeCalls.godot_icall_0_53(MethodBind15, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPause, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPause(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind16, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsPaused, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsPaused()
    {
        return NativeCalls.godot_icall_0_15(MethodBind17, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CreateTimer, 2709170273ul);

    /// <summary>
    /// <para>Returns a new <see cref="Godot.SceneTreeTimer"/>. After <paramref name="timeSec"/> in seconds have passed, the timer will emit <see cref="Godot.SceneTreeTimer.Timeout"/> and will be automatically freed.</para>
    /// <para>If <paramref name="processAlways"/> is <see langword="false"/>, the timer will be paused when setting <see cref="Godot.SceneTree.Paused"/> to <see langword="true"/>.</para>
    /// <para>If <paramref name="processInPhysics"/> is <see langword="true"/>, the timer will update at the end of the physics frame, instead of the process frame.</para>
    /// <para>If <paramref name="ignoreTimeScale"/> is <see langword="true"/>, the timer will ignore <see cref="Godot.Engine.TimeScale"/> and update with the real, elapsed time.</para>
    /// <para>This method is commonly used to create a one-shot delay timer, as in the following example:</para>
    /// <para><code>
    /// public async Task SomeFunction()
    /// {
    /// 	GD.Print("start");
    /// 	await ToSignal(GetTree().CreateTimer(1.0f), SceneTreeTimer.SignalName.Timeout);
    /// 	GD.Print("end");
    /// }
    /// </code></para>
    /// <para><b>Note:</b> The timer is always updated <i>after</i> all of the nodes in the tree. A node's <see cref="Godot.Node._Process(double)"/> method would be called before the timer updates (or <see cref="Godot.Node._PhysicsProcess(double)"/> if <paramref name="processInPhysics"/> is set to <see langword="true"/>).</para>
    /// </summary>
    public SceneTreeTimer CreateTimer(double timeSec, bool processAlways = true, bool processInPhysics = false, bool ignoreTimeScale = false)
    {
        return (SceneTreeTimer)NativeCalls.godot_icall_4_1253(MethodBind18, GodotObject.GetPtr(this), timeSec, processAlways.ToGodotBool(), processInPhysics.ToGodotBool(), ignoreTimeScale.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CreateTween, 3426978995ul);

    /// <summary>
    /// <para>Creates and returns a new <see cref="Godot.Tween"/> processed in this tree. The Tween will start automatically on the next process frame or physics frame (depending on its <see cref="Godot.Tween.TweenProcessMode"/>).</para>
    /// <para><b>Note:</b> A <see cref="Godot.Tween"/> created using this method is not bound to any <see cref="Godot.Node"/>. It may keep working until there is nothing left to animate. If you want the <see cref="Godot.Tween"/> to be automatically killed when the <see cref="Godot.Node"/> is freed, use <see cref="Godot.Node.CreateTween()"/> or <see cref="Godot.Tween.BindNode(Node)"/>.</para>
    /// </summary>
    public Tween CreateTween()
    {
        return (Tween)NativeCalls.godot_icall_0_63(MethodBind19, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetProcessedTweens, 2915620761ul);

    /// <summary>
    /// <para>Returns an <see cref="Godot.Collections.Array"/> of currently existing <see cref="Godot.Tween"/>s in the tree, including paused tweens.</para>
    /// </summary>
    public Godot.Collections.Array<Tween> GetProcessedTweens()
    {
        return new Godot.Collections.Array<Tween>(NativeCalls.godot_icall_0_120(MethodBind20, GodotObject.GetPtr(this)));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNodeCount, 3905245786ul);

    /// <summary>
    /// <para>Returns the number of nodes inside this tree.</para>
    /// </summary>
    public int GetNodeCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind21, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFrame, 3905245786ul);

    /// <summary>
    /// <para>Returns how many physics process steps have been processed, since the application started. This is <i>not</i> a measurement of elapsed time. See also <see cref="Godot.SceneTree.PhysicsFrame"/>. For the number of frames rendered, see <see cref="Godot.Engine.GetProcessFrames()"/>.</para>
    /// </summary>
    public long GetFrame()
    {
        return NativeCalls.godot_icall_0_4(MethodBind22, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Quit, 1995695955ul);

    /// <summary>
    /// <para>Quits the application at the end of the current iteration, with the given <paramref name="exitCode"/>.</para>
    /// <para>By convention, an exit code of <c>0</c> indicates success, whereas any other exit code indicates an error. For portability reasons, it should be between <c>0</c> and <c>125</c> (inclusive).</para>
    /// <para><b>Note:</b> On iOS this method doesn't work. Instead, as recommended by the <a href="https://developer.apple.com/library/archive/qa/qa1561/_index.html">iOS Human Interface Guidelines</a>, the user is expected to close apps via the Home button.</para>
    /// </summary>
    public void Quit(int exitCode = 0)
    {
        NativeCalls.godot_icall_1_38(MethodBind23, GodotObject.GetPtr(this), exitCode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPhysicsInterpolationEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPhysicsInterpolationEnabled(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind24, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsPhysicsInterpolationEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsPhysicsInterpolationEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind25, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.QueueDelete, 3975164845ul);

    /// <summary>
    /// <para>Queues the given <paramref name="obj"/> to be deleted, calling its <see cref="Godot.GodotObject.Free()"/> at the end of the current frame. This method is similar to <see cref="Godot.Node.QueueFree()"/>.</para>
    /// </summary>
    public void QueueDelete(GodotObject obj)
    {
        NativeCalls.godot_icall_1_56(MethodBind26, GodotObject.GetPtr(this), GodotObject.GetPtr(obj));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CallGroupFlags, 1527739229ul);

    /// <summary>
    /// <para>Calls the given <paramref name="method"/> on each node inside this tree added to the given <paramref name="group"/>. Use <paramref name="flags"/> to customize this method's behavior (see <see cref="Godot.SceneTree.GroupCallFlags"/>). Additional arguments for <paramref name="method"/> can be passed at the end of this method. Nodes that cannot call <paramref name="method"/> (either because the method doesn't exist or the arguments do not match) are ignored.</para>
    /// <para><code>
    /// # Calls "hide" to all nodes of the "enemies" group, at the end of the frame and in reverse tree order.
    /// get_tree().call_group_flags(
    /// 		SceneTree.GROUP_CALL_DEFERRED | SceneTree.GROUP_CALL_REVERSE,
    /// 		"enemies", "hide")
    /// </code></para>
    /// <para><b>Note:</b> In C#, <paramref name="method"/> must be in snake_case when referring to built-in Godot methods. Prefer using the names exposed in the <c>MethodName</c> class to avoid allocating a new <see cref="Godot.StringName"/> on each call.</para>
    /// </summary>
    public void CallGroupFlags(long flags, StringName group, StringName method, params Variant[] @args)
    {
        NativeCalls.godot_icall_4_1254(MethodBind27, GodotObject.GetPtr(this), flags, (godot_string_name)(group?.NativeValue ?? default), (godot_string_name)(method?.NativeValue ?? default), @args, (godot_string_name)MethodName.CallGroupFlags.NativeValue);
    }

    /// <summary>
    /// <para>Calls the given <paramref name="method"/> on each node inside this tree added to the given <paramref name="group"/>. Use <paramref name="flags"/> to customize this method's behavior (see <see cref="Godot.SceneTree.GroupCallFlags"/>). Additional arguments for <paramref name="method"/> can be passed at the end of this method. Nodes that cannot call <paramref name="method"/> (either because the method doesn't exist or the arguments do not match) are ignored.</para>
    /// <para><code>
    /// # Calls "hide" to all nodes of the "enemies" group, at the end of the frame and in reverse tree order.
    /// get_tree().call_group_flags(
    /// 		SceneTree.GROUP_CALL_DEFERRED | SceneTree.GROUP_CALL_REVERSE,
    /// 		"enemies", "hide")
    /// </code></para>
    /// <para><b>Note:</b> In C#, <paramref name="method"/> must be in snake_case when referring to built-in Godot methods. Prefer using the names exposed in the <c>MethodName</c> class to avoid allocating a new <see cref="Godot.StringName"/> on each call.</para>
    /// </summary>
    public void CallGroupFlags(long flags, StringName group, StringName method, ReadOnlySpan<Variant> @args)
    {
        NativeCalls.godot_icall_4_1254(MethodBind27, GodotObject.GetPtr(this), flags, (godot_string_name)(group?.NativeValue ?? default), (godot_string_name)(method?.NativeValue ?? default), @args, (godot_string_name)MethodName.CallGroupFlags.NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName.NotifyGroupFlags, 1245489420ul);

    /// <summary>
    /// <para>Calls <see cref="Godot.GodotObject.Notification(int, bool)"/> with the given <paramref name="notification"/> to all nodes inside this tree added to the <paramref name="group"/>. Use <paramref name="callFlags"/> to customize this method's behavior (see <see cref="Godot.SceneTree.GroupCallFlags"/>).</para>
    /// </summary>
    public void NotifyGroupFlags(uint callFlags, StringName group, int notification)
    {
        NativeCalls.godot_icall_3_1255(MethodBind28, GodotObject.GetPtr(this), callFlags, (godot_string_name)(group?.NativeValue ?? default), notification);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetGroupFlags, 3497599527ul);

    /// <summary>
    /// <para>Sets the given <paramref name="property"/> to <paramref name="value"/> on all nodes inside this tree added to the given <paramref name="group"/>. Nodes that do not have the <paramref name="property"/> are ignored. Use <paramref name="callFlags"/> to customize this method's behavior (see <see cref="Godot.SceneTree.GroupCallFlags"/>).</para>
    /// <para><b>Note:</b> In C#, <paramref name="property"/> must be in snake_case when referring to built-in Godot properties. Prefer using the names exposed in the <c>PropertyName</c> class to avoid allocating a new <see cref="Godot.StringName"/> on each call.</para>
    /// </summary>
    public void SetGroupFlags(uint callFlags, StringName group, string property, Variant value)
    {
        NativeCalls.godot_icall_4_1256(MethodBind29, GodotObject.GetPtr(this), callFlags, (godot_string_name)(group?.NativeValue ?? default), property, value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CallGroup, 1257962832ul);

    /// <summary>
    /// <para>Calls <paramref name="method"/> on each node inside this tree added to the given <paramref name="group"/>. You can pass arguments to <paramref name="method"/> by specifying them at the end of this method call. Nodes that cannot call <paramref name="method"/> (either because the method doesn't exist or the arguments do not match) are ignored. See also <see cref="Godot.SceneTree.SetGroup(StringName, string, Variant)"/> and <see cref="Godot.SceneTree.NotifyGroup(StringName, int)"/>.</para>
    /// <para><b>Note:</b> This method acts immediately on all selected nodes at once, which may cause stuttering in some performance-intensive situations.</para>
    /// <para><b>Note:</b> In C#, <paramref name="method"/> must be in snake_case when referring to built-in Godot methods. Prefer using the names exposed in the <c>MethodName</c> class to avoid allocating a new <see cref="Godot.StringName"/> on each call.</para>
    /// </summary>
    public void CallGroup(StringName group, StringName method, params Variant[] @args)
    {
        NativeCalls.godot_icall_3_1257(MethodBind30, GodotObject.GetPtr(this), (godot_string_name)(group?.NativeValue ?? default), (godot_string_name)(method?.NativeValue ?? default), @args, (godot_string_name)MethodName.CallGroup.NativeValue);
    }

    /// <summary>
    /// <para>Calls <paramref name="method"/> on each node inside this tree added to the given <paramref name="group"/>. You can pass arguments to <paramref name="method"/> by specifying them at the end of this method call. Nodes that cannot call <paramref name="method"/> (either because the method doesn't exist or the arguments do not match) are ignored. See also <see cref="Godot.SceneTree.SetGroup(StringName, string, Variant)"/> and <see cref="Godot.SceneTree.NotifyGroup(StringName, int)"/>.</para>
    /// <para><b>Note:</b> This method acts immediately on all selected nodes at once, which may cause stuttering in some performance-intensive situations.</para>
    /// <para><b>Note:</b> In C#, <paramref name="method"/> must be in snake_case when referring to built-in Godot methods. Prefer using the names exposed in the <c>MethodName</c> class to avoid allocating a new <see cref="Godot.StringName"/> on each call.</para>
    /// </summary>
    public void CallGroup(StringName group, StringName method, ReadOnlySpan<Variant> @args)
    {
        NativeCalls.godot_icall_3_1257(MethodBind30, GodotObject.GetPtr(this), (godot_string_name)(group?.NativeValue ?? default), (godot_string_name)(method?.NativeValue ?? default), @args, (godot_string_name)MethodName.CallGroup.NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = ClassDB_get_method_with_compatibility(NativeName, MethodName.NotifyGroup, 2415702435ul);

    /// <summary>
    /// <para>Calls <see cref="Godot.GodotObject.Notification(int, bool)"/> with the given <paramref name="notification"/> to all nodes inside this tree added to the <paramref name="group"/>. See also <a href="$DOCS_URL/tutorials/best_practices/godot_notifications.html">Godot notifications</a> and <see cref="Godot.SceneTree.CallGroup(StringName, StringName, Variant[])"/> and <see cref="Godot.SceneTree.SetGroup(StringName, string, Variant)"/>.</para>
    /// <para><b>Note:</b> This method acts immediately on all selected nodes at once, which may cause stuttering in some performance-intensive situations.</para>
    /// </summary>
    public void NotifyGroup(StringName group, int notification)
    {
        NativeCalls.godot_icall_2_154(MethodBind31, GodotObject.GetPtr(this), (godot_string_name)(group?.NativeValue ?? default), notification);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind32 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetGroup, 1279312029ul);

    /// <summary>
    /// <para>Sets the given <paramref name="property"/> to <paramref name="value"/> on all nodes inside this tree added to the given <paramref name="group"/>. Nodes that do not have the <paramref name="property"/> are ignored. See also <see cref="Godot.SceneTree.CallGroup(StringName, StringName, Variant[])"/> and <see cref="Godot.SceneTree.NotifyGroup(StringName, int)"/>.</para>
    /// <para><b>Note:</b> This method acts immediately on all selected nodes at once, which may cause stuttering in some performance-intensive situations.</para>
    /// <para><b>Note:</b> In C#, <paramref name="property"/> must be in snake_case when referring to built-in Godot properties. Prefer using the names exposed in the <c>PropertyName</c> class to avoid allocating a new <see cref="Godot.StringName"/> on each call.</para>
    /// </summary>
    public void SetGroup(StringName group, string property, Variant value)
    {
        NativeCalls.godot_icall_3_1258(MethodBind32, GodotObject.GetPtr(this), (godot_string_name)(group?.NativeValue ?? default), property, value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind33 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNodesInGroup, 689397652ul);

    /// <summary>
    /// <para>Returns an <see cref="Godot.Collections.Array"/> containing all nodes inside this tree, that have been added to the given <paramref name="group"/>, in scene hierarchy order.</para>
    /// </summary>
    public Godot.Collections.Array<Node> GetNodesInGroup(StringName group)
    {
        return new Godot.Collections.Array<Node>(NativeCalls.godot_icall_1_696(MethodBind33, GodotObject.GetPtr(this), (godot_string_name)(group?.NativeValue ?? default)));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind34 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFirstNodeInGroup, 4071044623ul);

    /// <summary>
    /// <para>Returns the first <see cref="Godot.Node"/> found inside the tree, that has been added to the given <paramref name="group"/>, in scene hierarchy order. Returns <see langword="null"/> if no match is found. See also <see cref="Godot.SceneTree.GetNodesInGroup(StringName)"/>.</para>
    /// </summary>
    public Node GetFirstNodeInGroup(StringName group)
    {
        return (Node)NativeCalls.godot_icall_1_545(MethodBind34, GodotObject.GetPtr(this), (godot_string_name)(group?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind35 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNodeCountInGroup, 2458036349ul);

    /// <summary>
    /// <para>Returns the number of nodes assigned to the given group.</para>
    /// </summary>
    public int GetNodeCountInGroup(StringName group)
    {
        return NativeCalls.godot_icall_1_193(MethodBind35, GodotObject.GetPtr(this), (godot_string_name)(group?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind36 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCurrentScene, 1078189570ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCurrentScene(Node childNode)
    {
        NativeCalls.godot_icall_1_56(MethodBind36, GodotObject.GetPtr(this), GodotObject.GetPtr(childNode));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind37 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCurrentScene, 3160264692ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Node GetCurrentScene()
    {
        return (Node)NativeCalls.godot_icall_0_53(MethodBind37, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind38 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ChangeSceneToFile, 166001499ul);

    /// <summary>
    /// <para>Changes the running scene to the one at the given <paramref name="path"/>, after loading it into a <see cref="Godot.PackedScene"/> and creating a new instance.</para>
    /// <para>Returns <see cref="Godot.Error.Ok"/> on success, <see cref="Godot.Error.CantOpen"/> if the <paramref name="path"/> cannot be loaded into a <see cref="Godot.PackedScene"/>, or <see cref="Godot.Error.CantCreate"/> if that scene cannot be instantiated.</para>
    /// <para><b>Note:</b> See <see cref="Godot.SceneTree.ChangeSceneToNode(Node)"/> for details on the order of operations.</para>
    /// </summary>
    public Error ChangeSceneToFile(string path)
    {
        return (Error)NativeCalls.godot_icall_1_134(MethodBind38, GodotObject.GetPtr(this), path);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind39 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ChangeSceneToPacked, 107349098ul);

    /// <summary>
    /// <para>Changes the running scene to a new instance of the given <see cref="Godot.PackedScene"/> (which must be valid).</para>
    /// <para>Returns <see cref="Godot.Error.Ok"/> on success, <see cref="Godot.Error.CantCreate"/> if the scene cannot be instantiated, or <see cref="Godot.Error.InvalidParameter"/> if the scene is invalid.</para>
    /// <para><b>Note:</b> See <see cref="Godot.SceneTree.ChangeSceneToNode(Node)"/> for details on the order of operations.</para>
    /// </summary>
    public Error ChangeSceneToPacked(PackedScene packedScene)
    {
        return (Error)NativeCalls.godot_icall_1_371(MethodBind39, GodotObject.GetPtr(this), GodotObject.GetPtr(packedScene));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind40 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ChangeSceneToNode, 2584678054ul);

    /// <summary>
    /// <para>Changes the running scene to the provided <see cref="Godot.Node"/>. Useful when you want to set up the new scene before changing.</para>
    /// <para>Returns <see cref="Godot.Error.Ok"/> on success, <see cref="Godot.Error.InvalidParameter"/> if the <paramref name="node"/> is <see langword="null"/>, or <see cref="Godot.Error.Unconfigured"/> if the <paramref name="node"/> is already inside the scene tree.</para>
    /// <para><b>Note:</b> Operations happen in the following order when <see cref="Godot.SceneTree.ChangeSceneToNode(Node)"/> is called:</para>
    /// <para>1. The current scene node is immediately removed from the tree. From that point, <see cref="Godot.Node.GetTree()"/> called on the current (outgoing) scene will return <see langword="null"/>. <see cref="Godot.SceneTree.CurrentScene"/> will be <see langword="null"/> too, because the new scene is not available yet.</para>
    /// <para>2. At the end of the frame, the formerly current scene, already removed from the tree, will be deleted (freed from memory) and then the new scene node will be added to the tree. <see cref="Godot.Node.GetTree()"/> and <see cref="Godot.SceneTree.CurrentScene"/> will be back to working as usual.</para>
    /// <para>This ensures that both scenes aren't running at the same time, while still freeing the previous scene in a safe way similar to <see cref="Godot.Node.QueueFree()"/>.</para>
    /// <para>If you want to reliably access the new scene, await the <see cref="Godot.SceneTree.SceneChanged"/> signal.</para>
    /// <para><b>Warning:</b> After using this method, the <see cref="Godot.SceneTree"/> will take ownership of the node and will free it automatically when changing scene again. Any references you had to that node will become invalid.</para>
    /// </summary>
    public Error ChangeSceneToNode(Node node)
    {
        return (Error)NativeCalls.godot_icall_1_371(MethodBind40, GodotObject.GetPtr(this), GodotObject.GetPtr(node));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind41 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ReloadCurrentScene, 166280745ul);

    /// <summary>
    /// <para>Reloads the currently active scene, replacing <see cref="Godot.SceneTree.CurrentScene"/> with a new instance of its original <see cref="Godot.PackedScene"/>.</para>
    /// <para>Returns <see cref="Godot.Error.Ok"/> on success, <see cref="Godot.Error.Unconfigured"/> if no <see cref="Godot.SceneTree.CurrentScene"/> is defined, <see cref="Godot.Error.CantOpen"/> if <see cref="Godot.SceneTree.CurrentScene"/> cannot be loaded into a <see cref="Godot.PackedScene"/>, or <see cref="Godot.Error.CantCreate"/> if the scene cannot be instantiated.</para>
    /// </summary>
    public Error ReloadCurrentScene()
    {
        return (Error)NativeCalls.godot_icall_0_39(MethodBind41, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind42 = ClassDB_get_method_with_compatibility(NativeName, MethodName.UnloadCurrentScene, 3218959716ul);

    /// <summary>
    /// <para>If a current scene is loaded, calling this method will unload it.</para>
    /// </summary>
    public void UnloadCurrentScene()
    {
        NativeCalls.godot_icall_0_3(MethodBind42, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind43 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMultiplayer, 2385607013ul);

    /// <summary>
    /// <para>Sets a custom <see cref="Godot.MultiplayerApi"/> with the given <paramref name="rootPath"/> (controlling also the relative subpaths), or override the default one if <paramref name="rootPath"/> is empty.</para>
    /// <para><b>Note:</b> No <see cref="Godot.MultiplayerApi"/> must be configured for the subpath containing <paramref name="rootPath"/>, nested custom multiplayers are not allowed. I.e. if one is configured for <c>"/root/Foo"</c> setting one for <c>"/root/Foo/Bar"</c> will cause an error.</para>
    /// <para><b>Note:</b> <see cref="Godot.SceneTree.SetMultiplayer(MultiplayerApi, NodePath)"/> should be called <i>before</i> the child nodes are ready at the given <paramref name="rootPath"/>. If multiplayer nodes like <see cref="Godot.MultiplayerSpawner"/> or <see cref="Godot.MultiplayerSynchronizer"/> are added to the tree before the custom multiplayer API is set, they will not work.</para>
    /// </summary>
    public void SetMultiplayer(MultiplayerApi multiplayer, NodePath rootPath = null)
    {
        NativeCalls.godot_icall_2_1259(MethodBind43, GodotObject.GetPtr(this), GodotObject.GetPtr(multiplayer), (godot_node_path)(rootPath?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind44 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMultiplayer, 3453401404ul);

    /// <summary>
    /// <para>Searches for the <see cref="Godot.MultiplayerApi"/> configured for the given path, if one does not exist it searches the parent paths until one is found. If the path is empty, or none is found, the default one is returned. See <see cref="Godot.SceneTree.SetMultiplayer(MultiplayerApi, NodePath)"/>.</para>
    /// </summary>
    public MultiplayerApi GetMultiplayer(NodePath forPath = null)
    {
        return (MultiplayerApi)NativeCalls.godot_icall_1_1260(MethodBind44, GodotObject.GetPtr(this), (godot_node_path)(forPath?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind45 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMultiplayerPollEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMultiplayerPollEnabled(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind45, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind46 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsMultiplayerPollEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsMultiplayerPollEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind46, GodotObject.GetPtr(this)).ToBool();
    }

    /// <summary>
    /// <para>Emitted any time the tree's hierarchy changes (nodes being moved, renamed, etc.).</para>
    /// </summary>
    public event Action TreeChanged
    {
        add => Connect(SignalName.TreeChanged, Callable.From(value));
        remove => Disconnect(SignalName.TreeChanged, Callable.From(value));
    }

    protected void EmitSignalTreeChanged()
    {
        EmitSignal(SignalName.TreeChanged);
    }

    /// <summary>
    /// <para>Emitted after the new scene is added to scene tree and initialized. Can be used to reliably access <see cref="Godot.SceneTree.CurrentScene"/> when changing scenes.</para>
    /// <para><code>
    /// # This code should be inside an autoload.
    /// get_tree().change_scene_to_file(other_scene_path)
    /// await get_tree().scene_changed
    /// print(get_tree().current_scene) # Prints the new scene.
    /// </code></para>
    /// </summary>
    public event Action SceneChanged
    {
        add => Connect(SignalName.SceneChanged, Callable.From(value));
        remove => Disconnect(SignalName.SceneChanged, Callable.From(value));
    }

    protected void EmitSignalSceneChanged()
    {
        EmitSignal(SignalName.SceneChanged);
    }

    /// <summary>
    /// <para>Emitted when the <see cref="Godot.Node.ProcessMode"/> of any node inside the tree is changed. Only emitted in the editor, to update the visibility of disabled nodes.</para>
    /// </summary>
    public event Action TreeProcessModeChanged
    {
        add => Connect(SignalName.TreeProcessModeChanged, Callable.From(value));
        remove => Disconnect(SignalName.TreeProcessModeChanged, Callable.From(value));
    }

    protected void EmitSignalTreeProcessModeChanged()
    {
        EmitSignal(SignalName.TreeProcessModeChanged);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.SceneTree.NodeAdded"/> event of a <see cref="Godot.SceneTree"/> class.
    /// </summary>
    public delegate void NodeAddedEventHandler(Node node);

    private static void NodeAddedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((NodeAddedEventHandler)delegateObj)(VariantUtils.ConvertTo<Node>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when the <c>node</c> enters this tree.</para>
    /// </summary>
    public unsafe event NodeAddedEventHandler NodeAdded
    {
        add => Connect(SignalName.NodeAdded, Callable.CreateWithUnsafeTrampoline(value, &NodeAddedTrampoline));
        remove => Disconnect(SignalName.NodeAdded, Callable.CreateWithUnsafeTrampoline(value, &NodeAddedTrampoline));
    }

    protected void EmitSignalNodeAdded(Node node)
    {
        EmitSignal(SignalName.NodeAdded, node);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.SceneTree.NodeRemoved"/> event of a <see cref="Godot.SceneTree"/> class.
    /// </summary>
    public delegate void NodeRemovedEventHandler(Node node);

    private static void NodeRemovedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((NodeRemovedEventHandler)delegateObj)(VariantUtils.ConvertTo<Node>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when the <c>node</c> exits this tree.</para>
    /// </summary>
    public unsafe event NodeRemovedEventHandler NodeRemoved
    {
        add => Connect(SignalName.NodeRemoved, Callable.CreateWithUnsafeTrampoline(value, &NodeRemovedTrampoline));
        remove => Disconnect(SignalName.NodeRemoved, Callable.CreateWithUnsafeTrampoline(value, &NodeRemovedTrampoline));
    }

    protected void EmitSignalNodeRemoved(Node node)
    {
        EmitSignal(SignalName.NodeRemoved, node);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.SceneTree.NodeRenamed"/> event of a <see cref="Godot.SceneTree"/> class.
    /// </summary>
    public delegate void NodeRenamedEventHandler(Node node);

    private static void NodeRenamedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((NodeRenamedEventHandler)delegateObj)(VariantUtils.ConvertTo<Node>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when the <c>node</c>'s <see cref="Godot.Node.Name"/> is changed.</para>
    /// </summary>
    public unsafe event NodeRenamedEventHandler NodeRenamed
    {
        add => Connect(SignalName.NodeRenamed, Callable.CreateWithUnsafeTrampoline(value, &NodeRenamedTrampoline));
        remove => Disconnect(SignalName.NodeRenamed, Callable.CreateWithUnsafeTrampoline(value, &NodeRenamedTrampoline));
    }

    protected void EmitSignalNodeRenamed(Node node)
    {
        EmitSignal(SignalName.NodeRenamed, node);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.SceneTree.NodeConfigurationWarningChanged"/> event of a <see cref="Godot.SceneTree"/> class.
    /// </summary>
    public delegate void NodeConfigurationWarningChangedEventHandler(Node node);

    private static void NodeConfigurationWarningChangedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((NodeConfigurationWarningChangedEventHandler)delegateObj)(VariantUtils.ConvertTo<Node>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when the <c>node</c>'s <see cref="Godot.Node.UpdateConfigurationWarnings()"/> is called. Only emitted in the editor.</para>
    /// </summary>
    public unsafe event NodeConfigurationWarningChangedEventHandler NodeConfigurationWarningChanged
    {
        add => Connect(SignalName.NodeConfigurationWarningChanged, Callable.CreateWithUnsafeTrampoline(value, &NodeConfigurationWarningChangedTrampoline));
        remove => Disconnect(SignalName.NodeConfigurationWarningChanged, Callable.CreateWithUnsafeTrampoline(value, &NodeConfigurationWarningChangedTrampoline));
    }

    protected void EmitSignalNodeConfigurationWarningChanged(Node node)
    {
        EmitSignal(SignalName.NodeConfigurationWarningChanged, node);
    }

    /// <summary>
    /// <para>Emitted immediately before <see cref="Godot.Node._Process(double)"/> is called on every node in this tree.</para>
    /// </summary>
    public event Action ProcessFrame
    {
        add => Connect(SignalName.ProcessFrame, Callable.From(value));
        remove => Disconnect(SignalName.ProcessFrame, Callable.From(value));
    }

    protected void EmitSignalProcessFrame()
    {
        EmitSignal(SignalName.ProcessFrame);
    }

    /// <summary>
    /// <para>Emitted immediately before <see cref="Godot.Node._PhysicsProcess(double)"/> is called on every node in this tree.</para>
    /// </summary>
    public event Action PhysicsFrame
    {
        add => Connect(SignalName.PhysicsFrame, Callable.From(value));
        remove => Disconnect(SignalName.PhysicsFrame, Callable.From(value));
    }

    protected void EmitSignalPhysicsFrame()
    {
        EmitSignal(SignalName.PhysicsFrame);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_tree_changed = "TreeChanged";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_scene_changed = "SceneChanged";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_tree_process_mode_changed = "TreeProcessModeChanged";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_node_added = "NodeAdded";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_node_removed = "NodeRemoved";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_node_renamed = "NodeRenamed";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_node_configuration_warning_changed = "NodeConfigurationWarningChanged";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_process_frame = "ProcessFrame";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_physics_frame = "PhysicsFrame";

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
        if (signal == SignalName.TreeChanged)
        {
            if (HasGodotClassSignal(SignalProxyName_tree_changed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.SceneChanged)
        {
            if (HasGodotClassSignal(SignalProxyName_scene_changed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.TreeProcessModeChanged)
        {
            if (HasGodotClassSignal(SignalProxyName_tree_process_mode_changed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.NodeAdded)
        {
            if (HasGodotClassSignal(SignalProxyName_node_added.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.NodeRemoved)
        {
            if (HasGodotClassSignal(SignalProxyName_node_removed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.NodeRenamed)
        {
            if (HasGodotClassSignal(SignalProxyName_node_renamed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.NodeConfigurationWarningChanged)
        {
            if (HasGodotClassSignal(SignalProxyName_node_configuration_warning_changed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.ProcessFrame)
        {
            if (HasGodotClassSignal(SignalProxyName_process_frame.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.PhysicsFrame)
        {
            if (HasGodotClassSignal(SignalProxyName_physics_frame.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        return base.HasGodotClassSignal(signal);
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : MainLoop.PropertyName
    {
        /// <summary>
        /// Cached name for the 'auto_accept_quit' property.
        /// </summary>
        public static readonly StringName AutoAcceptQuit = "auto_accept_quit";
        /// <summary>
        /// Cached name for the 'quit_on_go_back' property.
        /// </summary>
        public static readonly StringName QuitOnGoBack = "quit_on_go_back";
        /// <summary>
        /// Cached name for the 'debug_collisions_hint' property.
        /// </summary>
        public static readonly StringName DebugCollisionsHint = "debug_collisions_hint";
        /// <summary>
        /// Cached name for the 'debug_paths_hint' property.
        /// </summary>
        public static readonly StringName DebugPathsHint = "debug_paths_hint";
        /// <summary>
        /// Cached name for the 'debug_navigation_hint' property.
        /// </summary>
        public static readonly StringName DebugNavigationHint = "debug_navigation_hint";
        /// <summary>
        /// Cached name for the 'paused' property.
        /// </summary>
        public static readonly StringName Paused = "paused";
        /// <summary>
        /// Cached name for the 'edited_scene_root' property.
        /// </summary>
        public static readonly StringName EditedSceneRoot = "edited_scene_root";
        /// <summary>
        /// Cached name for the 'current_scene' property.
        /// </summary>
        public static readonly StringName CurrentScene = "current_scene";
        /// <summary>
        /// Cached name for the 'root' property.
        /// </summary>
        public static readonly StringName Root = "root";
        /// <summary>
        /// Cached name for the 'multiplayer_poll' property.
        /// </summary>
        public static readonly StringName MultiplayerPoll = "multiplayer_poll";
        /// <summary>
        /// Cached name for the 'physics_interpolation' property.
        /// </summary>
        public static readonly StringName PhysicsInterpolation = "physics_interpolation";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : MainLoop.MethodName
    {
        /// <summary>
        /// Cached name for the 'get_root' method.
        /// </summary>
        public static readonly StringName GetRoot = "get_root";
        /// <summary>
        /// Cached name for the 'has_group' method.
        /// </summary>
        public static readonly StringName HasGroup = "has_group";
        /// <summary>
        /// Cached name for the 'is_accessibility_enabled' method.
        /// </summary>
        public static readonly StringName IsAccessibilityEnabled = "is_accessibility_enabled";
        /// <summary>
        /// Cached name for the 'is_accessibility_supported' method.
        /// </summary>
        public static readonly StringName IsAccessibilitySupported = "is_accessibility_supported";
        /// <summary>
        /// Cached name for the 'is_auto_accept_quit' method.
        /// </summary>
        public static readonly StringName IsAutoAcceptQuit = "is_auto_accept_quit";
        /// <summary>
        /// Cached name for the 'set_auto_accept_quit' method.
        /// </summary>
        public static readonly StringName SetAutoAcceptQuit = "set_auto_accept_quit";
        /// <summary>
        /// Cached name for the 'is_quit_on_go_back' method.
        /// </summary>
        public static readonly StringName IsQuitOnGoBack = "is_quit_on_go_back";
        /// <summary>
        /// Cached name for the 'set_quit_on_go_back' method.
        /// </summary>
        public static readonly StringName SetQuitOnGoBack = "set_quit_on_go_back";
        /// <summary>
        /// Cached name for the 'set_debug_collisions_hint' method.
        /// </summary>
        public static readonly StringName SetDebugCollisionsHint = "set_debug_collisions_hint";
        /// <summary>
        /// Cached name for the 'is_debugging_collisions_hint' method.
        /// </summary>
        public static readonly StringName IsDebuggingCollisionsHint = "is_debugging_collisions_hint";
        /// <summary>
        /// Cached name for the 'set_debug_paths_hint' method.
        /// </summary>
        public static readonly StringName SetDebugPathsHint = "set_debug_paths_hint";
        /// <summary>
        /// Cached name for the 'is_debugging_paths_hint' method.
        /// </summary>
        public static readonly StringName IsDebuggingPathsHint = "is_debugging_paths_hint";
        /// <summary>
        /// Cached name for the 'set_debug_navigation_hint' method.
        /// </summary>
        public static readonly StringName SetDebugNavigationHint = "set_debug_navigation_hint";
        /// <summary>
        /// Cached name for the 'is_debugging_navigation_hint' method.
        /// </summary>
        public static readonly StringName IsDebuggingNavigationHint = "is_debugging_navigation_hint";
        /// <summary>
        /// Cached name for the 'set_edited_scene_root' method.
        /// </summary>
        public static readonly StringName SetEditedSceneRoot = "set_edited_scene_root";
        /// <summary>
        /// Cached name for the 'get_edited_scene_root' method.
        /// </summary>
        public static readonly StringName GetEditedSceneRoot = "get_edited_scene_root";
        /// <summary>
        /// Cached name for the 'set_pause' method.
        /// </summary>
        public static readonly StringName SetPause = "set_pause";
        /// <summary>
        /// Cached name for the 'is_paused' method.
        /// </summary>
        public static readonly StringName IsPaused = "is_paused";
        /// <summary>
        /// Cached name for the 'create_timer' method.
        /// </summary>
        public static readonly StringName CreateTimer = "create_timer";
        /// <summary>
        /// Cached name for the 'create_tween' method.
        /// </summary>
        public static readonly StringName CreateTween = "create_tween";
        /// <summary>
        /// Cached name for the 'get_processed_tweens' method.
        /// </summary>
        public static readonly StringName GetProcessedTweens = "get_processed_tweens";
        /// <summary>
        /// Cached name for the 'get_node_count' method.
        /// </summary>
        public static readonly StringName GetNodeCount = "get_node_count";
        /// <summary>
        /// Cached name for the 'get_frame' method.
        /// </summary>
        public static readonly StringName GetFrame = "get_frame";
        /// <summary>
        /// Cached name for the 'quit' method.
        /// </summary>
        public static readonly StringName Quit = "quit";
        /// <summary>
        /// Cached name for the 'set_physics_interpolation_enabled' method.
        /// </summary>
        public static readonly StringName SetPhysicsInterpolationEnabled = "set_physics_interpolation_enabled";
        /// <summary>
        /// Cached name for the 'is_physics_interpolation_enabled' method.
        /// </summary>
        public static readonly StringName IsPhysicsInterpolationEnabled = "is_physics_interpolation_enabled";
        /// <summary>
        /// Cached name for the 'queue_delete' method.
        /// </summary>
        public static readonly StringName QueueDelete = "queue_delete";
        /// <summary>
        /// Cached name for the 'call_group_flags' method.
        /// </summary>
        public static readonly StringName CallGroupFlags = "call_group_flags";
        /// <summary>
        /// Cached name for the 'notify_group_flags' method.
        /// </summary>
        public static readonly StringName NotifyGroupFlags = "notify_group_flags";
        /// <summary>
        /// Cached name for the 'set_group_flags' method.
        /// </summary>
        public static readonly StringName SetGroupFlags = "set_group_flags";
        /// <summary>
        /// Cached name for the 'call_group' method.
        /// </summary>
        public static readonly StringName CallGroup = "call_group";
        /// <summary>
        /// Cached name for the 'notify_group' method.
        /// </summary>
        public static readonly StringName NotifyGroup = "notify_group";
        /// <summary>
        /// Cached name for the 'set_group' method.
        /// </summary>
        public static readonly StringName SetGroup = "set_group";
        /// <summary>
        /// Cached name for the 'get_nodes_in_group' method.
        /// </summary>
        public static readonly StringName GetNodesInGroup = "get_nodes_in_group";
        /// <summary>
        /// Cached name for the 'get_first_node_in_group' method.
        /// </summary>
        public static readonly StringName GetFirstNodeInGroup = "get_first_node_in_group";
        /// <summary>
        /// Cached name for the 'get_node_count_in_group' method.
        /// </summary>
        public static readonly StringName GetNodeCountInGroup = "get_node_count_in_group";
        /// <summary>
        /// Cached name for the 'set_current_scene' method.
        /// </summary>
        public static readonly StringName SetCurrentScene = "set_current_scene";
        /// <summary>
        /// Cached name for the 'get_current_scene' method.
        /// </summary>
        public static readonly StringName GetCurrentScene = "get_current_scene";
        /// <summary>
        /// Cached name for the 'change_scene_to_file' method.
        /// </summary>
        public static readonly StringName ChangeSceneToFile = "change_scene_to_file";
        /// <summary>
        /// Cached name for the 'change_scene_to_packed' method.
        /// </summary>
        public static readonly StringName ChangeSceneToPacked = "change_scene_to_packed";
        /// <summary>
        /// Cached name for the 'change_scene_to_node' method.
        /// </summary>
        public static readonly StringName ChangeSceneToNode = "change_scene_to_node";
        /// <summary>
        /// Cached name for the 'reload_current_scene' method.
        /// </summary>
        public static readonly StringName ReloadCurrentScene = "reload_current_scene";
        /// <summary>
        /// Cached name for the 'unload_current_scene' method.
        /// </summary>
        public static readonly StringName UnloadCurrentScene = "unload_current_scene";
        /// <summary>
        /// Cached name for the 'set_multiplayer' method.
        /// </summary>
        public static readonly StringName SetMultiplayer = "set_multiplayer";
        /// <summary>
        /// Cached name for the 'get_multiplayer' method.
        /// </summary>
        public static readonly StringName GetMultiplayer = "get_multiplayer";
        /// <summary>
        /// Cached name for the 'set_multiplayer_poll_enabled' method.
        /// </summary>
        public static readonly StringName SetMultiplayerPollEnabled = "set_multiplayer_poll_enabled";
        /// <summary>
        /// Cached name for the 'is_multiplayer_poll_enabled' method.
        /// </summary>
        public static readonly StringName IsMultiplayerPollEnabled = "is_multiplayer_poll_enabled";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : MainLoop.SignalName
    {
        /// <summary>
        /// Cached name for the 'tree_changed' signal.
        /// </summary>
        public static readonly StringName TreeChanged = "tree_changed";
        /// <summary>
        /// Cached name for the 'scene_changed' signal.
        /// </summary>
        public static readonly StringName SceneChanged = "scene_changed";
        /// <summary>
        /// Cached name for the 'tree_process_mode_changed' signal.
        /// </summary>
        public static readonly StringName TreeProcessModeChanged = "tree_process_mode_changed";
        /// <summary>
        /// Cached name for the 'node_added' signal.
        /// </summary>
        public static readonly StringName NodeAdded = "node_added";
        /// <summary>
        /// Cached name for the 'node_removed' signal.
        /// </summary>
        public static readonly StringName NodeRemoved = "node_removed";
        /// <summary>
        /// Cached name for the 'node_renamed' signal.
        /// </summary>
        public static readonly StringName NodeRenamed = "node_renamed";
        /// <summary>
        /// Cached name for the 'node_configuration_warning_changed' signal.
        /// </summary>
        public static readonly StringName NodeConfigurationWarningChanged = "node_configuration_warning_changed";
        /// <summary>
        /// Cached name for the 'process_frame' signal.
        /// </summary>
        public static readonly StringName ProcessFrame = "process_frame";
        /// <summary>
        /// Cached name for the 'physics_frame' signal.
        /// </summary>
        public static readonly StringName PhysicsFrame = "physics_frame";
    }
}
