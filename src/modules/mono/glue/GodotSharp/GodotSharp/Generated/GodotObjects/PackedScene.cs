namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A simplified interface to a scene file. Provides access to operations and checks that can be performed on the scene resource itself.</para>
/// <para>Can be used to save a node to a file. When saving, the node as well as all the nodes it owns get saved (see <see cref="Godot.Node.Owner"/> property).</para>
/// <para><b>Note:</b> The node doesn't need to own itself.</para>
/// <para><b>Example:</b> Load a saved scene:</para>
/// <para><code>
/// // C# has no preload, so you have to always use ResourceLoader.Load&lt;PackedScene&gt;().
/// var scene = ResourceLoader.Load&lt;PackedScene&gt;("res://scene.tscn").Instantiate();
/// // Add the node as a child of the node the script is attached to.
/// AddChild(scene);
/// </code></para>
/// <para><b>Example:</b> Save a node with different owners. The following example creates 3 objects: <see cref="Godot.Node2D"/> (<c>node</c>), <see cref="Godot.RigidBody2D"/> (<c>body</c>) and <see cref="Godot.CollisionObject2D"/> (<c>collision</c>). <c>collision</c> is a child of <c>body</c> which is a child of <c>node</c>. Only <c>body</c> is owned by <c>node</c> and <see cref="Godot.PackedScene.Pack(Node)"/> will therefore only save those two nodes, but not <c>collision</c>.</para>
/// <para><code>
/// // Create the objects.
/// var node = new Node2D();
/// var body = new RigidBody2D();
/// var collision = new CollisionShape2D();
/// 
/// // Create the object hierarchy.
/// body.AddChild(collision);
/// node.AddChild(body);
/// 
/// // Change owner of `body`, but not of `collision`.
/// body.Owner = node;
/// var scene = new PackedScene();
/// 
/// // Only `node` and `body` are now packed.
/// Error result = scene.Pack(node);
/// if (result == Error.Ok)
/// {
/// 	Error error = ResourceSaver.Save(scene, "res://path/name.tscn"); // Or "user://..."
/// 	if (error != Error.Ok)
/// 	{
/// 		GD.PushError("An error occurred while saving the scene to disk.");
/// 	}
/// }
/// </code></para>
/// </summary>
public partial class PackedScene : Resource
{
    public enum GenEditState : long
    {
        /// <summary>
        /// <para>If passed to <see cref="Godot.PackedScene.Instantiate(PackedScene.GenEditState)"/>, blocks edits to the scene state.</para>
        /// </summary>
        Disabled = 0,
        /// <summary>
        /// <para>If passed to <see cref="Godot.PackedScene.Instantiate(PackedScene.GenEditState)"/>, provides local scene resources to the local scene.</para>
        /// <para><b>Note:</b> Only available in editor builds.</para>
        /// </summary>
        Instance = 1,
        /// <summary>
        /// <para>If passed to <see cref="Godot.PackedScene.Instantiate(PackedScene.GenEditState)"/>, provides local scene resources to the local scene. Only the main scene should receive the main edit state.</para>
        /// <para><b>Note:</b> Only available in editor builds.</para>
        /// </summary>
        Main = 2,
        /// <summary>
        /// <para>It's similar to <see cref="Godot.PackedScene.GenEditState.Main"/>, but for the case where the scene is being instantiated to be the base of another one.</para>
        /// <para><b>Note:</b> Only available in editor builds.</para>
        /// </summary>
        MainInherited = 3
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public Godot.Collections.Dictionary _Bundled
    {
        get
        {
            return _GetBundledScene();
        }
        set
        {
            _SetBundledScene(value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    private static readonly System.Type CachedType = typeof(PackedScene);

    private static readonly StringName NativeName = "PackedScene";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public PackedScene() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal PackedScene(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal PackedScene(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Pack, 2584678054ul);

    /// <summary>
    /// <para>Packs the <paramref name="path"/> node, and all owned sub-nodes, into this <see cref="Godot.PackedScene"/>. Any existing data will be cleared. See <see cref="Godot.Node.Owner"/>.</para>
    /// </summary>
    public Error Pack(Node path)
    {
        return (Error)NativeCalls.godot_icall_1_371(MethodBind0, GodotObject.GetPtr(this), GodotObject.GetPtr(path));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Instantiate, 2628778455ul);

    /// <summary>
    /// <para>Instantiates the scene's node hierarchy. Triggers child scene instantiation(s). Triggers a <see cref="Godot.Node.NotificationSceneInstantiated"/> notification on the root node.</para>
    /// </summary>
    public Node Instantiate(PackedScene.GenEditState editState = (PackedScene.GenEditState)(0))
    {
        return (Node)NativeCalls.godot_icall_1_335(MethodBind1, GodotObject.GetPtr(this), (int)editState);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanInstantiate, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the scene file has nodes.</para>
    /// </summary>
    public bool CanInstantiate()
    {
        return NativeCalls.godot_icall_0_15(MethodBind2, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName._SetBundledScene, 4155329257ul);

    internal void _SetBundledScene(Godot.Collections.Dictionary scene)
    {
        NativeCalls.godot_icall_1_121(MethodBind3, GodotObject.GetPtr(this), (godot_dictionary)(scene ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName._GetBundledScene, 3102165223ul);

    internal Godot.Collections.Dictionary _GetBundledScene()
    {
        return NativeCalls.godot_icall_0_122(MethodBind4, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetState, 3479783971ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.SceneState"/> representing the scene file contents.</para>
    /// </summary>
    public SceneState GetState()
    {
        return (SceneState)NativeCalls.godot_icall_0_63(MethodBind5, GodotObject.GetPtr(this));
    }

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
        return base.HasGodotClassSignal(signal);
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : Resource.PropertyName
    {
        /// <summary>
        /// Cached name for the '_bundled' property.
        /// </summary>
        public static readonly StringName _Bundled = "_bundled";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Resource.MethodName
    {
        /// <summary>
        /// Cached name for the 'pack' method.
        /// </summary>
        public static readonly StringName Pack = "pack";
        /// <summary>
        /// Cached name for the 'instantiate' method.
        /// </summary>
        public static readonly StringName Instantiate = "instantiate";
        /// <summary>
        /// Cached name for the 'can_instantiate' method.
        /// </summary>
        public static readonly StringName CanInstantiate = "can_instantiate";
        /// <summary>
        /// Cached name for the '_set_bundled_scene' method.
        /// </summary>
        public static readonly StringName _SetBundledScene = "_set_bundled_scene";
        /// <summary>
        /// Cached name for the '_get_bundled_scene' method.
        /// </summary>
        public static readonly StringName _GetBundledScene = "_get_bundled_scene";
        /// <summary>
        /// Cached name for the 'get_state' method.
        /// </summary>
        public static readonly StringName GetState = "get_state";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Resource.SignalName
    {
    }
}
