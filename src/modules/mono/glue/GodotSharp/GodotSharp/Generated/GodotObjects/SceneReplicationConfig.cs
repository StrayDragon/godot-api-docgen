namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
public partial class SceneReplicationConfig : Resource
{
    public enum ReplicationMode : long
    {
        /// <summary>
        /// <para>Do not keep the given property synchronized.</para>
        /// </summary>
        Never = 0,
        /// <summary>
        /// <para>Replicate the given property on process by constantly sending updates using unreliable transfer mode.</para>
        /// </summary>
        Always = 1,
        /// <summary>
        /// <para>Replicate the given property on process by sending updates using reliable transfer mode when its value changes.</para>
        /// </summary>
        OnChange = 2
    }

    private static readonly System.Type CachedType = typeof(SceneReplicationConfig);

    private static readonly StringName NativeName = "SceneReplicationConfig";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public SceneReplicationConfig() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal SceneReplicationConfig(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal SceneReplicationConfig(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetProperties, 3995934104ul);

    /// <summary>
    /// <para>Returns a list of synchronized property <see cref="Godot.NodePath"/>s.</para>
    /// </summary>
    public Godot.Collections.Array<NodePath> GetProperties()
    {
        return new Godot.Collections.Array<NodePath>(NativeCalls.godot_icall_0_120(MethodBind0, GodotObject.GetPtr(this)));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddProperty, 4094619021ul);

    /// <summary>
    /// <para>Adds the property identified by the given <paramref name="path"/> to the list of the properties being synchronized, optionally passing an <paramref name="index"/>.</para>
    /// <para><b>Note:</b> For details on restrictions and limitations on property synchronization, see <see cref="Godot.MultiplayerSynchronizer"/>.</para>
    /// </summary>
    public void AddProperty(NodePath path, int index = -1)
    {
        NativeCalls.godot_icall_2_1250(MethodBind1, GodotObject.GetPtr(this), (godot_node_path)(path?.NativeValue ?? default), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasProperty, 861721659ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the given <paramref name="path"/> is configured for synchronization.</para>
    /// </summary>
    public bool HasProperty(NodePath path)
    {
        return NativeCalls.godot_icall_1_136(MethodBind2, GodotObject.GetPtr(this), (godot_node_path)(path?.NativeValue ?? default)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveProperty, 1348162250ul);

    /// <summary>
    /// <para>Removes the property identified by the given <paramref name="path"/> from the configuration.</para>
    /// </summary>
    public void RemoveProperty(NodePath path)
    {
        NativeCalls.godot_icall_1_123(MethodBind3, GodotObject.GetPtr(this), (godot_node_path)(path?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PropertyGetIndex, 1382022557ul);

    /// <summary>
    /// <para>Finds the index of the given <paramref name="path"/>.</para>
    /// </summary>
    public int PropertyGetIndex(NodePath path)
    {
        return NativeCalls.godot_icall_1_1251(MethodBind4, GodotObject.GetPtr(this), (godot_node_path)(path?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PropertyGetSpawn, 3456846888ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the property identified by the given <paramref name="path"/> is configured to be synchronized on spawn.</para>
    /// </summary>
    public bool PropertyGetSpawn(NodePath path)
    {
        return NativeCalls.godot_icall_1_136(MethodBind5, GodotObject.GetPtr(this), (godot_node_path)(path?.NativeValue ?? default)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PropertySetSpawn, 3868023870ul);

    /// <summary>
    /// <para>Sets whether the property identified by the given <paramref name="path"/> is configured to be synchronized on spawn.</para>
    /// </summary>
    public void PropertySetSpawn(NodePath path, bool enabled)
    {
        NativeCalls.godot_icall_2_135(MethodBind6, GodotObject.GetPtr(this), (godot_node_path)(path?.NativeValue ?? default), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PropertyGetReplicationMode, 2870606336ul);

    /// <summary>
    /// <para>Returns the replication mode for the property identified by the given <paramref name="path"/>.</para>
    /// </summary>
    public SceneReplicationConfig.ReplicationMode PropertyGetReplicationMode(NodePath path)
    {
        return (SceneReplicationConfig.ReplicationMode)NativeCalls.godot_icall_1_1251(MethodBind7, GodotObject.GetPtr(this), (godot_node_path)(path?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PropertySetReplicationMode, 3200083865ul);

    /// <summary>
    /// <para>Sets the synchronization mode for the property identified by the given <paramref name="path"/>.</para>
    /// </summary>
    public void PropertySetReplicationMode(NodePath path, SceneReplicationConfig.ReplicationMode mode)
    {
        NativeCalls.godot_icall_2_1250(MethodBind8, GodotObject.GetPtr(this), (godot_node_path)(path?.NativeValue ?? default), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PropertyGetSync, 3456846888ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the property identified by the given <paramref name="path"/> is configured to be synchronized on process.</para>
    /// </summary>
    [Obsolete("Use 'Godot.SceneReplicationConfig.PropertyGetReplicationMode(NodePath)' instead.")]
    public bool PropertyGetSync(NodePath path)
    {
        return NativeCalls.godot_icall_1_136(MethodBind9, GodotObject.GetPtr(this), (godot_node_path)(path?.NativeValue ?? default)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PropertySetSync, 3868023870ul);

    /// <summary>
    /// <para>Sets whether the property identified by the given <paramref name="path"/> is configured to be synchronized on process.</para>
    /// </summary>
    [Obsolete("Use 'Godot.SceneReplicationConfig.PropertySetReplicationMode(NodePath, SceneReplicationConfig.ReplicationMode)' with 'Godot.SceneReplicationConfig.ReplicationMode.Always' instead.")]
    public void PropertySetSync(NodePath path, bool enabled)
    {
        NativeCalls.godot_icall_2_135(MethodBind10, GodotObject.GetPtr(this), (godot_node_path)(path?.NativeValue ?? default), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PropertyGetWatch, 3456846888ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the property identified by the given <paramref name="path"/> is configured to be reliably synchronized when changes are detected on process.</para>
    /// </summary>
    [Obsolete("Use 'Godot.SceneReplicationConfig.PropertyGetReplicationMode(NodePath)' instead.")]
    public bool PropertyGetWatch(NodePath path)
    {
        return NativeCalls.godot_icall_1_136(MethodBind11, GodotObject.GetPtr(this), (godot_node_path)(path?.NativeValue ?? default)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PropertySetWatch, 3868023870ul);

    /// <summary>
    /// <para>Sets whether the property identified by the given <paramref name="path"/> is configured to be reliably synchronized when changes are detected on process.</para>
    /// </summary>
    [Obsolete("Use 'Godot.SceneReplicationConfig.PropertySetReplicationMode(NodePath, SceneReplicationConfig.ReplicationMode)' with 'Godot.SceneReplicationConfig.ReplicationMode.OnChange' instead.")]
    public void PropertySetWatch(NodePath path, bool enabled)
    {
        NativeCalls.godot_icall_2_135(MethodBind12, GodotObject.GetPtr(this), (godot_node_path)(path?.NativeValue ?? default), enabled.ToGodotBool());
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
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Resource.MethodName
    {
        /// <summary>
        /// Cached name for the 'get_properties' method.
        /// </summary>
        public static readonly StringName GetProperties = "get_properties";
        /// <summary>
        /// Cached name for the 'add_property' method.
        /// </summary>
        public static readonly StringName AddProperty = "add_property";
        /// <summary>
        /// Cached name for the 'has_property' method.
        /// </summary>
        public static readonly StringName HasProperty = "has_property";
        /// <summary>
        /// Cached name for the 'remove_property' method.
        /// </summary>
        public static readonly StringName RemoveProperty = "remove_property";
        /// <summary>
        /// Cached name for the 'property_get_index' method.
        /// </summary>
        public static readonly StringName PropertyGetIndex = "property_get_index";
        /// <summary>
        /// Cached name for the 'property_get_spawn' method.
        /// </summary>
        public static readonly StringName PropertyGetSpawn = "property_get_spawn";
        /// <summary>
        /// Cached name for the 'property_set_spawn' method.
        /// </summary>
        public static readonly StringName PropertySetSpawn = "property_set_spawn";
        /// <summary>
        /// Cached name for the 'property_get_replication_mode' method.
        /// </summary>
        public static readonly StringName PropertyGetReplicationMode = "property_get_replication_mode";
        /// <summary>
        /// Cached name for the 'property_set_replication_mode' method.
        /// </summary>
        public static readonly StringName PropertySetReplicationMode = "property_set_replication_mode";
        /// <summary>
        /// Cached name for the 'property_get_sync' method.
        /// </summary>
        public static readonly StringName PropertyGetSync = "property_get_sync";
        /// <summary>
        /// Cached name for the 'property_set_sync' method.
        /// </summary>
        public static readonly StringName PropertySetSync = "property_set_sync";
        /// <summary>
        /// Cached name for the 'property_get_watch' method.
        /// </summary>
        public static readonly StringName PropertyGetWatch = "property_get_watch";
        /// <summary>
        /// Cached name for the 'property_set_watch' method.
        /// </summary>
        public static readonly StringName PropertySetWatch = "property_set_watch";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Resource.SignalName
    {
    }
}
