namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Maintains a list of resources, nodes, exported and overridden properties, and built-in scripts associated with a scene. They cannot be modified from a <see cref="Godot.SceneState"/>, only accessed. Useful for peeking into what a <see cref="Godot.PackedScene"/> contains without instantiating it.</para>
/// <para>This class cannot be instantiated directly, it is retrieved for a given scene as the result of <see cref="Godot.PackedScene.GetState()"/>.</para>
/// </summary>
public partial class SceneState : RefCounted
{
    public enum GenEditState : long
    {
        /// <summary>
        /// <para>If passed to <see cref="Godot.PackedScene.Instantiate(PackedScene.GenEditState)"/>, blocks edits to the scene state.</para>
        /// </summary>
        Disabled = 0,
        /// <summary>
        /// <para>If passed to <see cref="Godot.PackedScene.Instantiate(PackedScene.GenEditState)"/>, provides inherited scene resources to the local scene.</para>
        /// <para><b>Note:</b> Only available in editor builds.</para>
        /// </summary>
        Instance = 1,
        /// <summary>
        /// <para>If passed to <see cref="Godot.PackedScene.Instantiate(PackedScene.GenEditState)"/>, provides local scene resources to the local scene. Only the main scene should receive the main edit state.</para>
        /// <para><b>Note:</b> Only available in editor builds.</para>
        /// </summary>
        Main = 2,
        /// <summary>
        /// <para>If passed to <see cref="Godot.PackedScene.Instantiate(PackedScene.GenEditState)"/>, it's similar to <see cref="Godot.SceneState.GenEditState.Main"/>, but for the case where the scene is being instantiated to be the base of another one.</para>
        /// <para><b>Note:</b> Only available in editor builds.</para>
        /// </summary>
        MainInherited = 3
    }

    private static readonly System.Type CachedType = typeof(SceneState);

    private static readonly StringName NativeName = "SceneState";

    internal SceneState() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal SceneState(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal SceneState(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPath, 201670096ul);

    /// <summary>
    /// <para>Returns the resource path to the represented <see cref="Godot.PackedScene"/>.</para>
    /// </summary>
    public string GetPath()
    {
        return NativeCalls.godot_icall_0_58(MethodBind0, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBaseSceneState, 3479783971ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.SceneState"/> of the scene that this scene inherits from, or <see langword="null"/> if it doesn't inherit from any scene.</para>
    /// </summary>
    public SceneState GetBaseSceneState()
    {
        return (SceneState)NativeCalls.godot_icall_0_63(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNodeCount, 3905245786ul);

    /// <summary>
    /// <para>Returns the number of nodes in the scene.</para>
    /// <para>The <c>idx</c> argument used to query node data in other <c>get_node_*</c> methods in the interval <c>[0, get_node_count() - 1]</c>.</para>
    /// </summary>
    public int GetNodeCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNodeType, 659327637ul);

    /// <summary>
    /// <para>Returns the type of the node at <paramref name="idx"/>.</para>
    /// </summary>
    public StringName GetNodeType(int idx)
    {
        return NativeCalls.godot_icall_1_162(MethodBind3, GodotObject.GetPtr(this), idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNodeName, 659327637ul);

    /// <summary>
    /// <para>Returns the name of the node at <paramref name="idx"/>.</para>
    /// </summary>
    public StringName GetNodeName(int idx)
    {
        return NativeCalls.godot_icall_1_162(MethodBind4, GodotObject.GetPtr(this), idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNodePath, 2272487792ul);

    /// <summary>
    /// <para>Returns the path to the node at <paramref name="idx"/>.</para>
    /// <para>If <paramref name="forParent"/> is <see langword="true"/>, returns the path of the <paramref name="idx"/> node's parent instead.</para>
    /// </summary>
    public NodePath GetNodePath(int idx, bool forParent = false)
    {
        return NativeCalls.godot_icall_2_1252(MethodBind5, GodotObject.GetPtr(this), idx, forParent.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNodeOwnerPath, 408788394ul);

    /// <summary>
    /// <para>Returns the path to the owner of the node at <paramref name="idx"/>, relative to the root node.</para>
    /// </summary>
    public NodePath GetNodeOwnerPath(int idx)
    {
        return NativeCalls.godot_icall_1_74(MethodBind6, GodotObject.GetPtr(this), idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsNodeInstancePlaceholder, 1116898809ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the node at <paramref name="idx"/> is an <see cref="Godot.InstancePlaceholder"/>.</para>
    /// </summary>
    public bool IsNodeInstancePlaceholder(int idx)
    {
        return NativeCalls.godot_icall_1_62(MethodBind7, GodotObject.GetPtr(this), idx).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNodeInstancePlaceholder, 844755477ul);

    /// <summary>
    /// <para>Returns the path to the represented scene file if the node at <paramref name="idx"/> is an <see cref="Godot.InstancePlaceholder"/>.</para>
    /// </summary>
    public string GetNodeInstancePlaceholder(int idx)
    {
        return NativeCalls.godot_icall_1_133(MethodBind8, GodotObject.GetPtr(this), idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNodeInstance, 511017218ul);

    /// <summary>
    /// <para>Returns a <see cref="Godot.PackedScene"/> for the node at <paramref name="idx"/> (i.e. the whole branch starting at this node, with its child nodes and resources), or <see langword="null"/> if the node is not an instance.</para>
    /// </summary>
    public PackedScene GetNodeInstance(int idx)
    {
        return (PackedScene)NativeCalls.godot_icall_1_71(MethodBind9, GodotObject.GetPtr(this), idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNodeGroups, 647634434ul);

    /// <summary>
    /// <para>Returns the list of group names associated with the node at <paramref name="idx"/>.</para>
    /// </summary>
    public string[] GetNodeGroups(int idx)
    {
        return NativeCalls.godot_icall_1_474(MethodBind10, GodotObject.GetPtr(this), idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNodeIndex, 923996154ul);

    /// <summary>
    /// <para>Returns the node's index, which is its position relative to its siblings. This is only relevant and saved in scenes for cases where new nodes are added to an instantiated or inherited scene among siblings from the base scene. Despite the name, this index is not related to the <paramref name="idx"/> argument used here and in other methods.</para>
    /// </summary>
    public int GetNodeIndex(int idx)
    {
        return NativeCalls.godot_icall_1_60(MethodBind11, GodotObject.GetPtr(this), idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNodePropertyCount, 923996154ul);

    /// <summary>
    /// <para>Returns the number of exported or overridden properties for the node at <paramref name="idx"/>.</para>
    /// <para>The <c>prop_idx</c> argument used to query node property data in other <c>get_node_property_*</c> methods in the interval <c>[0, get_node_property_count() - 1]</c>.</para>
    /// </summary>
    public int GetNodePropertyCount(int idx)
    {
        return NativeCalls.godot_icall_1_60(MethodBind12, GodotObject.GetPtr(this), idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNodePropertyName, 351665558ul);

    /// <summary>
    /// <para>Returns the name of the property at <paramref name="propIdx"/> for the node at <paramref name="idx"/>.</para>
    /// </summary>
    public StringName GetNodePropertyName(int idx, int propIdx)
    {
        return NativeCalls.godot_icall_2_93(MethodBind13, GodotObject.GetPtr(this), idx, propIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNodePropertyValue, 678354945ul);

    /// <summary>
    /// <para>Returns the value of the property at <paramref name="propIdx"/> for the node at <paramref name="idx"/>.</para>
    /// </summary>
    public Variant GetNodePropertyValue(int idx, int propIdx)
    {
        return NativeCalls.godot_icall_2_89(MethodBind14, GodotObject.GetPtr(this), idx, propIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetConnectionCount, 3905245786ul);

    /// <summary>
    /// <para>Returns the number of signal connections in the scene.</para>
    /// <para>The <c>idx</c> argument used to query connection metadata in other <c>get_connection_*</c> methods in the interval <c>[0, get_connection_count() - 1]</c>.</para>
    /// </summary>
    public int GetConnectionCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind15, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetConnectionSource, 408788394ul);

    /// <summary>
    /// <para>Returns the path to the node that owns the signal at <paramref name="idx"/>, relative to the root node.</para>
    /// </summary>
    public NodePath GetConnectionSource(int idx)
    {
        return NativeCalls.godot_icall_1_74(MethodBind16, GodotObject.GetPtr(this), idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetConnectionSignal, 659327637ul);

    /// <summary>
    /// <para>Returns the name of the signal at <paramref name="idx"/>.</para>
    /// </summary>
    public StringName GetConnectionSignal(int idx)
    {
        return NativeCalls.godot_icall_1_162(MethodBind17, GodotObject.GetPtr(this), idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetConnectionTarget, 408788394ul);

    /// <summary>
    /// <para>Returns the path to the node that owns the method connected to the signal at <paramref name="idx"/>, relative to the root node.</para>
    /// </summary>
    public NodePath GetConnectionTarget(int idx)
    {
        return NativeCalls.godot_icall_1_74(MethodBind18, GodotObject.GetPtr(this), idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetConnectionMethod, 659327637ul);

    /// <summary>
    /// <para>Returns the method connected to the signal at <paramref name="idx"/>.</para>
    /// </summary>
    public StringName GetConnectionMethod(int idx)
    {
        return NativeCalls.godot_icall_1_162(MethodBind19, GodotObject.GetPtr(this), idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetConnectionFlags, 923996154ul);

    /// <summary>
    /// <para>Returns the connection flags for the signal at <paramref name="idx"/>. See <see cref="Godot.GodotObject.ConnectFlags"/> constants.</para>
    /// </summary>
    public int GetConnectionFlags(int idx)
    {
        return NativeCalls.godot_icall_1_60(MethodBind20, GodotObject.GetPtr(this), idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetConnectionBinds, 663333327ul);

    /// <summary>
    /// <para>Returns the list of bound parameters for the signal at <paramref name="idx"/>.</para>
    /// </summary>
    public Godot.Collections.Array GetConnectionBinds(int idx)
    {
        return NativeCalls.godot_icall_1_457(MethodBind21, GodotObject.GetPtr(this), idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetConnectionUnbinds, 923996154ul);

    /// <summary>
    /// <para>Returns the number of unbound parameters for the signal at <paramref name="idx"/>.</para>
    /// </summary>
    public int GetConnectionUnbinds(int idx)
    {
        return NativeCalls.godot_icall_1_60(MethodBind22, GodotObject.GetPtr(this), idx);
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
    public new class PropertyName : RefCounted.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : RefCounted.MethodName
    {
        /// <summary>
        /// Cached name for the 'get_path' method.
        /// </summary>
        public static readonly StringName GetPath = "get_path";
        /// <summary>
        /// Cached name for the 'get_base_scene_state' method.
        /// </summary>
        public static readonly StringName GetBaseSceneState = "get_base_scene_state";
        /// <summary>
        /// Cached name for the 'get_node_count' method.
        /// </summary>
        public static readonly StringName GetNodeCount = "get_node_count";
        /// <summary>
        /// Cached name for the 'get_node_type' method.
        /// </summary>
        public static readonly StringName GetNodeType = "get_node_type";
        /// <summary>
        /// Cached name for the 'get_node_name' method.
        /// </summary>
        public static readonly StringName GetNodeName = "get_node_name";
        /// <summary>
        /// Cached name for the 'get_node_path' method.
        /// </summary>
        public static readonly StringName GetNodePath = "get_node_path";
        /// <summary>
        /// Cached name for the 'get_node_owner_path' method.
        /// </summary>
        public static readonly StringName GetNodeOwnerPath = "get_node_owner_path";
        /// <summary>
        /// Cached name for the 'is_node_instance_placeholder' method.
        /// </summary>
        public static readonly StringName IsNodeInstancePlaceholder = "is_node_instance_placeholder";
        /// <summary>
        /// Cached name for the 'get_node_instance_placeholder' method.
        /// </summary>
        public static readonly StringName GetNodeInstancePlaceholder = "get_node_instance_placeholder";
        /// <summary>
        /// Cached name for the 'get_node_instance' method.
        /// </summary>
        public static readonly StringName GetNodeInstance = "get_node_instance";
        /// <summary>
        /// Cached name for the 'get_node_groups' method.
        /// </summary>
        public static readonly StringName GetNodeGroups = "get_node_groups";
        /// <summary>
        /// Cached name for the 'get_node_index' method.
        /// </summary>
        public static readonly StringName GetNodeIndex = "get_node_index";
        /// <summary>
        /// Cached name for the 'get_node_property_count' method.
        /// </summary>
        public static readonly StringName GetNodePropertyCount = "get_node_property_count";
        /// <summary>
        /// Cached name for the 'get_node_property_name' method.
        /// </summary>
        public static readonly StringName GetNodePropertyName = "get_node_property_name";
        /// <summary>
        /// Cached name for the 'get_node_property_value' method.
        /// </summary>
        public static readonly StringName GetNodePropertyValue = "get_node_property_value";
        /// <summary>
        /// Cached name for the 'get_connection_count' method.
        /// </summary>
        public static readonly StringName GetConnectionCount = "get_connection_count";
        /// <summary>
        /// Cached name for the 'get_connection_source' method.
        /// </summary>
        public static readonly StringName GetConnectionSource = "get_connection_source";
        /// <summary>
        /// Cached name for the 'get_connection_signal' method.
        /// </summary>
        public static readonly StringName GetConnectionSignal = "get_connection_signal";
        /// <summary>
        /// Cached name for the 'get_connection_target' method.
        /// </summary>
        public static readonly StringName GetConnectionTarget = "get_connection_target";
        /// <summary>
        /// Cached name for the 'get_connection_method' method.
        /// </summary>
        public static readonly StringName GetConnectionMethod = "get_connection_method";
        /// <summary>
        /// Cached name for the 'get_connection_flags' method.
        /// </summary>
        public static readonly StringName GetConnectionFlags = "get_connection_flags";
        /// <summary>
        /// Cached name for the 'get_connection_binds' method.
        /// </summary>
        public static readonly StringName GetConnectionBinds = "get_connection_binds";
        /// <summary>
        /// Cached name for the 'get_connection_unbinds' method.
        /// </summary>
        public static readonly StringName GetConnectionUnbinds = "get_connection_unbinds";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : RefCounted.SignalName
    {
    }
}
