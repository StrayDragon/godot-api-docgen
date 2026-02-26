namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>By default, <see cref="Godot.MultiplayerSynchronizer"/> synchronizes configured properties to all peers.</para>
/// <para>Visibility can be handled directly with <see cref="Godot.MultiplayerSynchronizer.SetVisibilityFor(int, bool)"/> or as-needed with <see cref="Godot.MultiplayerSynchronizer.AddVisibilityFilter(Callable)"/> and <see cref="Godot.MultiplayerSynchronizer.UpdateVisibility(int)"/>.</para>
/// <para><see cref="Godot.MultiplayerSpawner"/>s will handle nodes according to visibility of synchronizers as long as the node at <see cref="Godot.MultiplayerSynchronizer.RootPath"/> was spawned by one.</para>
/// <para>Internally, <see cref="Godot.MultiplayerSynchronizer"/> uses <see cref="Godot.MultiplayerApi.ObjectConfigurationAdd(GodotObject, Variant)"/> to notify synchronization start passing the <see cref="Godot.Node"/> at <see cref="Godot.MultiplayerSynchronizer.RootPath"/> as the <c>object</c> and itself as the <c>configuration</c>, and uses <see cref="Godot.MultiplayerApi.ObjectConfigurationRemove(GodotObject, Variant)"/> to notify synchronization end in a similar way.</para>
/// <para><b>Note:</b> Synchronization is not supported for <see cref="Godot.GodotObject"/> type properties, like <see cref="Godot.Resource"/>. Properties that are unique to each peer, like the instance IDs of <see cref="Godot.GodotObject"/>s (see <see cref="Godot.GodotObject.GetInstanceId()"/>) or <see cref="Godot.Rid"/>s, will also not work in synchronization.</para>
/// </summary>
public partial class MultiplayerSynchronizer : Node
{
    public enum VisibilityUpdateModeEnum : long
    {
        /// <summary>
        /// <para>Visibility filters are updated during process frames (see <see cref="Godot.Node.NotificationInternalProcess"/>).</para>
        /// </summary>
        Idle = 0,
        /// <summary>
        /// <para>Visibility filters are updated during physics frames (see <see cref="Godot.Node.NotificationInternalPhysicsProcess"/>).</para>
        /// </summary>
        Physics = 1,
        /// <summary>
        /// <para>Visibility filters are not updated automatically, and must be updated manually by calling <see cref="Godot.MultiplayerSynchronizer.UpdateVisibility(int)"/>.</para>
        /// </summary>
        None = 2
    }

    /// <summary>
    /// <para>Node path that replicated properties are relative to.</para>
    /// <para>If <see cref="Godot.MultiplayerSynchronizer.RootPath"/> was spawned by a <see cref="Godot.MultiplayerSpawner"/>, the node will be also be spawned and despawned based on this synchronizer visibility options.</para>
    /// </summary>
    public NodePath RootPath
    {
        get
        {
            return GetRootPath();
        }
        set
        {
            SetRootPath(value);
        }
    }

    /// <summary>
    /// <para>Time interval between synchronizations. Used when the replication is set to <see cref="Godot.SceneReplicationConfig.ReplicationMode.Always"/>. If set to <c>0.0</c> (the default), synchronizations happen every network process frame.</para>
    /// </summary>
    public double ReplicationInterval
    {
        get
        {
            return GetReplicationInterval();
        }
        set
        {
            SetReplicationInterval(value);
        }
    }

    /// <summary>
    /// <para>Time interval between delta synchronizations. Used when the replication is set to <see cref="Godot.SceneReplicationConfig.ReplicationMode.OnChange"/>. If set to <c>0.0</c> (the default), delta synchronizations happen every network process frame.</para>
    /// </summary>
    public double DeltaInterval
    {
        get
        {
            return GetDeltaInterval();
        }
        set
        {
            SetDeltaInterval(value);
        }
    }

    /// <summary>
    /// <para>Resource containing which properties to synchronize.</para>
    /// </summary>
    public SceneReplicationConfig ReplicationConfig
    {
        get
        {
            return GetReplicationConfig();
        }
        set
        {
            SetReplicationConfig(value);
        }
    }

    /// <summary>
    /// <para>Specifies when visibility filters are updated.</para>
    /// </summary>
    public MultiplayerSynchronizer.VisibilityUpdateModeEnum VisibilityUpdateMode
    {
        get
        {
            return GetVisibilityUpdateMode();
        }
        set
        {
            SetVisibilityUpdateMode(value);
        }
    }

    /// <summary>
    /// <para>Whether synchronization should be visible to all peers by default. See <see cref="Godot.MultiplayerSynchronizer.SetVisibilityFor(int, bool)"/> and <see cref="Godot.MultiplayerSynchronizer.AddVisibilityFilter(Callable)"/> for ways of configuring fine-grained visibility options.</para>
    /// </summary>
    public bool PublicVisibility
    {
        get
        {
            return IsVisibilityPublic();
        }
        set
        {
            SetVisibilityPublic(value);
        }
    }

    private static readonly System.Type CachedType = typeof(MultiplayerSynchronizer);

    private static readonly StringName NativeName = "MultiplayerSynchronizer";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public MultiplayerSynchronizer() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal MultiplayerSynchronizer(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal MultiplayerSynchronizer(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRootPath, 1348162250ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetRootPath(NodePath path)
    {
        NativeCalls.godot_icall_1_123(MethodBind0, GodotObject.GetPtr(this), (godot_node_path)(path?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRootPath, 4075236667ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public NodePath GetRootPath()
    {
        return NativeCalls.godot_icall_0_124(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetReplicationInterval, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetReplicationInterval(double milliseconds)
    {
        NativeCalls.godot_icall_1_127(MethodBind2, GodotObject.GetPtr(this), milliseconds);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetReplicationInterval, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public double GetReplicationInterval()
    {
        return NativeCalls.godot_icall_0_144(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDeltaInterval, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDeltaInterval(double milliseconds)
    {
        NativeCalls.godot_icall_1_127(MethodBind4, GodotObject.GetPtr(this), milliseconds);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDeltaInterval, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public double GetDeltaInterval()
    {
        return NativeCalls.godot_icall_0_144(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetReplicationConfig, 3889206742ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetReplicationConfig(SceneReplicationConfig config)
    {
        NativeCalls.godot_icall_1_56(MethodBind6, GodotObject.GetPtr(this), GodotObject.GetPtr(config));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetReplicationConfig, 3200254614ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public SceneReplicationConfig GetReplicationConfig()
    {
        return (SceneReplicationConfig)NativeCalls.godot_icall_0_63(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVisibilityUpdateMode, 3494860300ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetVisibilityUpdateMode(MultiplayerSynchronizer.VisibilityUpdateModeEnum mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind8, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVisibilityUpdateMode, 3352241418ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public MultiplayerSynchronizer.VisibilityUpdateModeEnum GetVisibilityUpdateMode()
    {
        return (MultiplayerSynchronizer.VisibilityUpdateModeEnum)NativeCalls.godot_icall_0_39(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.UpdateVisibility, 1995695955ul);

    /// <summary>
    /// <para>Updates the visibility of <paramref name="forPeer"/> according to visibility filters. If <paramref name="forPeer"/> is <c>0</c> (the default), all peers' visibilties are updated.</para>
    /// </summary>
    public void UpdateVisibility(int forPeer = 0)
    {
        NativeCalls.godot_icall_1_38(MethodBind10, GodotObject.GetPtr(this), forPeer);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVisibilityPublic, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetVisibilityPublic(bool visible)
    {
        NativeCalls.godot_icall_1_14(MethodBind11, GodotObject.GetPtr(this), visible.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsVisibilityPublic, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsVisibilityPublic()
    {
        return NativeCalls.godot_icall_0_15(MethodBind12, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddVisibilityFilter, 1611583062ul);

    /// <summary>
    /// <para>Adds a peer visibility filter for this synchronizer.</para>
    /// <para><paramref name="filter"/> should take a peer ID <see cref="int"/> and return a <see cref="bool"/>.</para>
    /// </summary>
    public void AddVisibilityFilter(Callable filter)
    {
        NativeCalls.godot_icall_1_403(MethodBind13, GodotObject.GetPtr(this), filter);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveVisibilityFilter, 1611583062ul);

    /// <summary>
    /// <para>Removes a peer visibility filter from this synchronizer.</para>
    /// </summary>
    public void RemoveVisibilityFilter(Callable filter)
    {
        NativeCalls.godot_icall_1_403(MethodBind14, GodotObject.GetPtr(this), filter);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVisibilityFor, 300928843ul);

    /// <summary>
    /// <para>Sets the visibility of <paramref name="peer"/> to <paramref name="visible"/>. If <paramref name="peer"/> is <c>0</c>, the value of <see cref="Godot.MultiplayerSynchronizer.PublicVisibility"/> will be updated instead.</para>
    /// </summary>
    public void SetVisibilityFor(int peer, bool visible)
    {
        NativeCalls.godot_icall_2_61(MethodBind15, GodotObject.GetPtr(this), peer, visible.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVisibilityFor, 1116898809ul);

    /// <summary>
    /// <para>Queries the current visibility for peer <paramref name="peer"/>.</para>
    /// </summary>
    public bool GetVisibilityFor(int peer)
    {
        return NativeCalls.godot_icall_1_62(MethodBind16, GodotObject.GetPtr(this), peer).ToBool();
    }

    /// <summary>
    /// <para>Emitted when a new synchronization state is received by this synchronizer after the properties have been updated.</para>
    /// </summary>
    public event Action Synchronized
    {
        add => Connect(SignalName.Synchronized, Callable.From(value));
        remove => Disconnect(SignalName.Synchronized, Callable.From(value));
    }

    protected void EmitSignalSynchronized()
    {
        EmitSignal(SignalName.Synchronized);
    }

    /// <summary>
    /// <para>Emitted when a new delta synchronization state is received by this synchronizer after the properties have been updated.</para>
    /// </summary>
    public event Action DeltaSynchronized
    {
        add => Connect(SignalName.DeltaSynchronized, Callable.From(value));
        remove => Disconnect(SignalName.DeltaSynchronized, Callable.From(value));
    }

    protected void EmitSignalDeltaSynchronized()
    {
        EmitSignal(SignalName.DeltaSynchronized);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.MultiplayerSynchronizer.VisibilityChanged"/> event of a <see cref="Godot.MultiplayerSynchronizer"/> class.
    /// </summary>
    public delegate void VisibilityChangedEventHandler(long forPeer);

    private static void VisibilityChangedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((VisibilityChangedEventHandler)delegateObj)(VariantUtils.ConvertTo<long>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when visibility of <c>forPeer</c> is updated. See <see cref="Godot.MultiplayerSynchronizer.UpdateVisibility(int)"/>.</para>
    /// </summary>
    public unsafe event VisibilityChangedEventHandler VisibilityChanged
    {
        add => Connect(SignalName.VisibilityChanged, Callable.CreateWithUnsafeTrampoline(value, &VisibilityChangedTrampoline));
        remove => Disconnect(SignalName.VisibilityChanged, Callable.CreateWithUnsafeTrampoline(value, &VisibilityChangedTrampoline));
    }

    protected void EmitSignalVisibilityChanged(long forPeer)
    {
        EmitSignal(SignalName.VisibilityChanged, forPeer);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_synchronized = "Synchronized";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_delta_synchronized = "DeltaSynchronized";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_visibility_changed = "VisibilityChanged";

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
        if (signal == SignalName.Synchronized)
        {
            if (HasGodotClassSignal(SignalProxyName_synchronized.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.DeltaSynchronized)
        {
            if (HasGodotClassSignal(SignalProxyName_delta_synchronized.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.VisibilityChanged)
        {
            if (HasGodotClassSignal(SignalProxyName_visibility_changed.NativeValue.DangerousSelfRef))
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
        /// Cached name for the 'root_path' property.
        /// </summary>
        public static readonly StringName RootPath = "root_path";
        /// <summary>
        /// Cached name for the 'replication_interval' property.
        /// </summary>
        public static readonly StringName ReplicationInterval = "replication_interval";
        /// <summary>
        /// Cached name for the 'delta_interval' property.
        /// </summary>
        public static readonly StringName DeltaInterval = "delta_interval";
        /// <summary>
        /// Cached name for the 'replication_config' property.
        /// </summary>
        public static readonly StringName ReplicationConfig = "replication_config";
        /// <summary>
        /// Cached name for the 'visibility_update_mode' property.
        /// </summary>
        public static readonly StringName VisibilityUpdateMode = "visibility_update_mode";
        /// <summary>
        /// Cached name for the 'public_visibility' property.
        /// </summary>
        public static readonly StringName PublicVisibility = "public_visibility";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Node.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_root_path' method.
        /// </summary>
        public static readonly StringName SetRootPath = "set_root_path";
        /// <summary>
        /// Cached name for the 'get_root_path' method.
        /// </summary>
        public static readonly StringName GetRootPath = "get_root_path";
        /// <summary>
        /// Cached name for the 'set_replication_interval' method.
        /// </summary>
        public static readonly StringName SetReplicationInterval = "set_replication_interval";
        /// <summary>
        /// Cached name for the 'get_replication_interval' method.
        /// </summary>
        public static readonly StringName GetReplicationInterval = "get_replication_interval";
        /// <summary>
        /// Cached name for the 'set_delta_interval' method.
        /// </summary>
        public static readonly StringName SetDeltaInterval = "set_delta_interval";
        /// <summary>
        /// Cached name for the 'get_delta_interval' method.
        /// </summary>
        public static readonly StringName GetDeltaInterval = "get_delta_interval";
        /// <summary>
        /// Cached name for the 'set_replication_config' method.
        /// </summary>
        public static readonly StringName SetReplicationConfig = "set_replication_config";
        /// <summary>
        /// Cached name for the 'get_replication_config' method.
        /// </summary>
        public static readonly StringName GetReplicationConfig = "get_replication_config";
        /// <summary>
        /// Cached name for the 'set_visibility_update_mode' method.
        /// </summary>
        public static readonly StringName SetVisibilityUpdateMode = "set_visibility_update_mode";
        /// <summary>
        /// Cached name for the 'get_visibility_update_mode' method.
        /// </summary>
        public static readonly StringName GetVisibilityUpdateMode = "get_visibility_update_mode";
        /// <summary>
        /// Cached name for the 'update_visibility' method.
        /// </summary>
        public static readonly StringName UpdateVisibility = "update_visibility";
        /// <summary>
        /// Cached name for the 'set_visibility_public' method.
        /// </summary>
        public static readonly StringName SetVisibilityPublic = "set_visibility_public";
        /// <summary>
        /// Cached name for the 'is_visibility_public' method.
        /// </summary>
        public static readonly StringName IsVisibilityPublic = "is_visibility_public";
        /// <summary>
        /// Cached name for the 'add_visibility_filter' method.
        /// </summary>
        public static readonly StringName AddVisibilityFilter = "add_visibility_filter";
        /// <summary>
        /// Cached name for the 'remove_visibility_filter' method.
        /// </summary>
        public static readonly StringName RemoveVisibilityFilter = "remove_visibility_filter";
        /// <summary>
        /// Cached name for the 'set_visibility_for' method.
        /// </summary>
        public static readonly StringName SetVisibilityFor = "set_visibility_for";
        /// <summary>
        /// Cached name for the 'get_visibility_for' method.
        /// </summary>
        public static readonly StringName GetVisibilityFor = "get_visibility_for";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Node.SignalName
    {
        /// <summary>
        /// Cached name for the 'synchronized' signal.
        /// </summary>
        public static readonly StringName Synchronized = "synchronized";
        /// <summary>
        /// Cached name for the 'delta_synchronized' signal.
        /// </summary>
        public static readonly StringName DeltaSynchronized = "delta_synchronized";
        /// <summary>
        /// Cached name for the 'visibility_changed' signal.
        /// </summary>
        public static readonly StringName VisibilityChanged = "visibility_changed";
    }
}
