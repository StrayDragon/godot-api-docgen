namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Spawnable scenes can be configured in the editor or through code (see <see cref="Godot.MultiplayerSpawner.AddSpawnableScene(string)"/>).</para>
/// <para>Also supports custom node spawns through <see cref="Godot.MultiplayerSpawner.Spawn(Variant)"/>, calling <see cref="Godot.MultiplayerSpawner.SpawnFunction"/> on all peers.</para>
/// <para>Internally, <see cref="Godot.MultiplayerSpawner"/> uses <see cref="Godot.MultiplayerApi.ObjectConfigurationAdd(GodotObject, Variant)"/> to notify spawns passing the spawned node as the <c>object</c> and itself as the <c>configuration</c>, and <see cref="Godot.MultiplayerApi.ObjectConfigurationRemove(GodotObject, Variant)"/> to notify despawns in a similar way.</para>
/// </summary>
public partial class MultiplayerSpawner : Node
{
    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public string[] _SpawnableScenes
    {
        get
        {
            return _GetSpawnableScenes();
        }
        set
        {
            _SetSpawnableScenes(value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    /// <summary>
    /// <para>Path to the spawn root. Spawnable scenes that are added as direct children are replicated to other peers.</para>
    /// </summary>
    public NodePath SpawnPath
    {
        get
        {
            return GetSpawnPath();
        }
        set
        {
            SetSpawnPath(value);
        }
    }

    /// <summary>
    /// <para>Maximum number of nodes allowed to be spawned by this spawner. Includes both spawnable scenes and custom spawns.</para>
    /// <para>When set to <c>0</c> (the default), there is no limit.</para>
    /// </summary>
    public uint SpawnLimit
    {
        get
        {
            return GetSpawnLimit();
        }
        set
        {
            SetSpawnLimit(value);
        }
    }

    /// <summary>
    /// <para>Method called on all peers when a custom <see cref="Godot.MultiplayerSpawner.Spawn(Variant)"/> is requested by the authority. Will receive the <c>data</c> parameter, and should return a <see cref="Godot.Node"/> that is not in the scene tree.</para>
    /// <para><b>Note:</b> The returned node should <b>not</b> be added to the scene with <see cref="Godot.Node.AddChild(Node, bool, Node.InternalMode)"/>. This is done automatically.</para>
    /// </summary>
    public Callable SpawnFunction
    {
        get
        {
            return GetSpawnFunction();
        }
        set
        {
            SetSpawnFunction(value);
        }
    }

    private static readonly System.Type CachedType = typeof(MultiplayerSpawner);

    private static readonly StringName NativeName = "MultiplayerSpawner";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public MultiplayerSpawner() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal MultiplayerSpawner(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal MultiplayerSpawner(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddSpawnableScene, 83702148ul);

    /// <summary>
    /// <para>Adds a scene path to spawnable scenes, making it automatically replicated from the multiplayer authority to other peers when added as children of the node pointed by <see cref="Godot.MultiplayerSpawner.SpawnPath"/>.</para>
    /// </summary>
    public void AddSpawnableScene(string path)
    {
        NativeCalls.godot_icall_1_57(MethodBind0, GodotObject.GetPtr(this), path);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSpawnableSceneCount, 3905245786ul);

    /// <summary>
    /// <para>Returns the count of spawnable scene paths.</para>
    /// </summary>
    public int GetSpawnableSceneCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSpawnableScene, 844755477ul);

    /// <summary>
    /// <para>Returns the spawnable scene path by index.</para>
    /// </summary>
    public string GetSpawnableScene(int index)
    {
        return NativeCalls.godot_icall_1_133(MethodBind2, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ClearSpawnableScenes, 3218959716ul);

    /// <summary>
    /// <para>Clears all spawnable scenes. Does not despawn existing instances on remote peers.</para>
    /// </summary>
    public void ClearSpawnableScenes()
    {
        NativeCalls.godot_icall_0_3(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName._GetSpawnableScenes, 1139954409ul);

    internal string[] _GetSpawnableScenes()
    {
        return NativeCalls.godot_icall_0_108(MethodBind4, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName._SetSpawnableScenes, 4015028928ul);

    internal void _SetSpawnableScenes(string[] scenes)
    {
        NativeCalls.godot_icall_1_185(MethodBind5, GodotObject.GetPtr(this), scenes);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Spawn, 1991184589ul);

    /// <summary>
    /// <para>Requests a custom spawn, with <paramref name="data"/> passed to <see cref="Godot.MultiplayerSpawner.SpawnFunction"/> on all peers. Returns the locally spawned node instance already inside the scene tree, and added as a child of the node pointed by <see cref="Godot.MultiplayerSpawner.SpawnPath"/>.</para>
    /// <para><b>Note:</b> Spawnable scenes are spawned automatically. <see cref="Godot.MultiplayerSpawner.Spawn(Variant)"/> is only needed for custom spawns.</para>
    /// </summary>
    public Node Spawn(Variant data = default)
    {
        return (Node)NativeCalls.godot_icall_1_810(MethodBind6, GodotObject.GetPtr(this), data);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSpawnPath, 4075236667ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public NodePath GetSpawnPath()
    {
        return NativeCalls.godot_icall_0_124(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSpawnPath, 1348162250ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSpawnPath(NodePath path)
    {
        NativeCalls.godot_icall_1_123(MethodBind8, GodotObject.GetPtr(this), (godot_node_path)(path?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSpawnLimit, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public uint GetSpawnLimit()
    {
        return NativeCalls.godot_icall_0_209(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSpawnLimit, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSpawnLimit(uint limit)
    {
        NativeCalls.godot_icall_1_208(MethodBind10, GodotObject.GetPtr(this), limit);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSpawnFunction, 1307783378ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Callable GetSpawnFunction()
    {
        return NativeCalls.godot_icall_0_811(MethodBind11, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSpawnFunction, 1611583062ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSpawnFunction(Callable spawnFunction)
    {
        NativeCalls.godot_icall_1_403(MethodBind12, GodotObject.GetPtr(this), spawnFunction);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.MultiplayerSpawner.Despawned"/> event of a <see cref="Godot.MultiplayerSpawner"/> class.
    /// </summary>
    public delegate void DespawnedEventHandler(Node node);

    private static void DespawnedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((DespawnedEventHandler)delegateObj)(VariantUtils.ConvertTo<Node>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when a spawnable scene or custom spawn was despawned by the multiplayer authority. Only called on remote peers.</para>
    /// </summary>
    public unsafe event DespawnedEventHandler Despawned
    {
        add => Connect(SignalName.Despawned, Callable.CreateWithUnsafeTrampoline(value, &DespawnedTrampoline));
        remove => Disconnect(SignalName.Despawned, Callable.CreateWithUnsafeTrampoline(value, &DespawnedTrampoline));
    }

    protected void EmitSignalDespawned(Node node)
    {
        EmitSignal(SignalName.Despawned, node);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.MultiplayerSpawner.Spawned"/> event of a <see cref="Godot.MultiplayerSpawner"/> class.
    /// </summary>
    public delegate void SpawnedEventHandler(Node node);

    private static void SpawnedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((SpawnedEventHandler)delegateObj)(VariantUtils.ConvertTo<Node>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when a spawnable scene or custom spawn was spawned by the multiplayer authority. Only called on remote peers.</para>
    /// </summary>
    public unsafe event SpawnedEventHandler Spawned
    {
        add => Connect(SignalName.Spawned, Callable.CreateWithUnsafeTrampoline(value, &SpawnedTrampoline));
        remove => Disconnect(SignalName.Spawned, Callable.CreateWithUnsafeTrampoline(value, &SpawnedTrampoline));
    }

    protected void EmitSignalSpawned(Node node)
    {
        EmitSignal(SignalName.Spawned, node);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_despawned = "Despawned";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_spawned = "Spawned";

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
        if (signal == SignalName.Despawned)
        {
            if (HasGodotClassSignal(SignalProxyName_despawned.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.Spawned)
        {
            if (HasGodotClassSignal(SignalProxyName_spawned.NativeValue.DangerousSelfRef))
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
        /// <summary>
        /// Cached name for the '_spawnable_scenes' property.
        /// </summary>
        public static readonly StringName _SpawnableScenes = "_spawnable_scenes";
        /// <summary>
        /// Cached name for the 'spawn_path' property.
        /// </summary>
        public static readonly StringName SpawnPath = "spawn_path";
        /// <summary>
        /// Cached name for the 'spawn_limit' property.
        /// </summary>
        public static readonly StringName SpawnLimit = "spawn_limit";
        /// <summary>
        /// Cached name for the 'spawn_function' property.
        /// </summary>
        public static readonly StringName SpawnFunction = "spawn_function";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Node.MethodName
    {
        /// <summary>
        /// Cached name for the 'add_spawnable_scene' method.
        /// </summary>
        public static readonly StringName AddSpawnableScene = "add_spawnable_scene";
        /// <summary>
        /// Cached name for the 'get_spawnable_scene_count' method.
        /// </summary>
        public static readonly StringName GetSpawnableSceneCount = "get_spawnable_scene_count";
        /// <summary>
        /// Cached name for the 'get_spawnable_scene' method.
        /// </summary>
        public static readonly StringName GetSpawnableScene = "get_spawnable_scene";
        /// <summary>
        /// Cached name for the 'clear_spawnable_scenes' method.
        /// </summary>
        public static readonly StringName ClearSpawnableScenes = "clear_spawnable_scenes";
        /// <summary>
        /// Cached name for the '_get_spawnable_scenes' method.
        /// </summary>
        public static readonly StringName _GetSpawnableScenes = "_get_spawnable_scenes";
        /// <summary>
        /// Cached name for the '_set_spawnable_scenes' method.
        /// </summary>
        public static readonly StringName _SetSpawnableScenes = "_set_spawnable_scenes";
        /// <summary>
        /// Cached name for the 'spawn' method.
        /// </summary>
        public static readonly StringName Spawn = "spawn";
        /// <summary>
        /// Cached name for the 'get_spawn_path' method.
        /// </summary>
        public static readonly StringName GetSpawnPath = "get_spawn_path";
        /// <summary>
        /// Cached name for the 'set_spawn_path' method.
        /// </summary>
        public static readonly StringName SetSpawnPath = "set_spawn_path";
        /// <summary>
        /// Cached name for the 'get_spawn_limit' method.
        /// </summary>
        public static readonly StringName GetSpawnLimit = "get_spawn_limit";
        /// <summary>
        /// Cached name for the 'set_spawn_limit' method.
        /// </summary>
        public static readonly StringName SetSpawnLimit = "set_spawn_limit";
        /// <summary>
        /// Cached name for the 'get_spawn_function' method.
        /// </summary>
        public static readonly StringName GetSpawnFunction = "get_spawn_function";
        /// <summary>
        /// Cached name for the 'set_spawn_function' method.
        /// </summary>
        public static readonly StringName SetSpawnFunction = "set_spawn_function";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Node.SignalName
    {
        /// <summary>
        /// Cached name for the 'despawned' signal.
        /// </summary>
        public static readonly StringName Despawned = "despawned";
        /// <summary>
        /// Cached name for the 'spawned' signal.
        /// </summary>
        public static readonly StringName Spawned = "spawned";
    }
}
