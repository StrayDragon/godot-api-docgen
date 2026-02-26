namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This animation node may contain a sub-tree of any other type animation nodes, such as <see cref="Godot.AnimationNodeTransition"/>, <see cref="Godot.AnimationNodeBlend2"/>, <see cref="Godot.AnimationNodeBlend3"/>, <see cref="Godot.AnimationNodeOneShot"/>, etc. This is one of the most commonly used animation node roots.</para>
/// <para>An <see cref="Godot.AnimationNodeOutput"/> node named <c>output</c> is created by default.</para>
/// </summary>
public partial class AnimationNodeBlendTree : AnimationRootNode
{
    /// <summary>
    /// <para>The connection was successful.</para>
    /// </summary>
    public const long ConnectionOk = 0;
    /// <summary>
    /// <para>The input node is <see langword="null"/>.</para>
    /// </summary>
    public const long ConnectionErrorNoInput = 1;
    /// <summary>
    /// <para>The specified input port is out of range.</para>
    /// </summary>
    public const long ConnectionErrorNoInputIndex = 2;
    /// <summary>
    /// <para>The output node is <see langword="null"/>.</para>
    /// </summary>
    public const long ConnectionErrorNoOutput = 3;
    /// <summary>
    /// <para>Input and output nodes are the same.</para>
    /// </summary>
    public const long ConnectionErrorSameNode = 4;
    /// <summary>
    /// <para>The specified connection already exists.</para>
    /// </summary>
    public const long ConnectionErrorConnectionExists = 5;

    /// <summary>
    /// <para>The global offset of all sub animation nodes.</para>
    /// </summary>
    public Vector2 GraphOffset
    {
        get
        {
            return GetGraphOffset();
        }
        set
        {
            SetGraphOffset(value);
        }
    }

    private static readonly System.Type CachedType = typeof(AnimationNodeBlendTree);

    private static readonly StringName NativeName = "AnimationNodeBlendTree";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public AnimationNodeBlendTree() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal AnimationNodeBlendTree(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal AnimationNodeBlendTree(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddNode, 1980270704ul);

    /// <summary>
    /// <para>Adds an <see cref="Godot.AnimationNode"/> at the given <paramref name="position"/>. The <paramref name="name"/> is used to identify the created sub animation node later.</para>
    /// </summary>
    /// <param name="position">If the parameter is null, then the default value is <c>new Vector2(0.0f, 0.0f)</c>.</param>
    public unsafe void AddNode(StringName name, AnimationNode node, Nullable<Vector2> position = null)
    {
        Vector2 positionOrDefVal = position.HasValue ? position.Value : new Vector2(0.0f, 0.0f);
        NativeCalls.godot_icall_3_152(MethodBind0, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default), GodotObject.GetPtr(node), &positionOrDefVal);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNode, 625644256ul);

    /// <summary>
    /// <para>Returns the sub animation node with the specified <paramref name="name"/>.</para>
    /// </summary>
    public AnimationNode GetNode(StringName name)
    {
        return (AnimationNode)NativeCalls.godot_icall_1_119(MethodBind1, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveNode, 3304788590ul);

    /// <summary>
    /// <para>Removes a sub animation node.</para>
    /// </summary>
    public void RemoveNode(StringName name)
    {
        NativeCalls.godot_icall_1_64(MethodBind2, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RenameNode, 3740211285ul);

    /// <summary>
    /// <para>Changes the name of a sub animation node.</para>
    /// </summary>
    public void RenameNode(StringName name, StringName newName)
    {
        NativeCalls.godot_icall_2_118(MethodBind3, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default), (godot_string_name)(newName?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasNode, 2619796661ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if a sub animation node with specified <paramref name="name"/> exists.</para>
    /// </summary>
    public bool HasNode(StringName name)
    {
        return NativeCalls.godot_icall_1_105(MethodBind4, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ConnectNode, 2168001410ul);

    /// <summary>
    /// <para>Connects the output of an <see cref="Godot.AnimationNode"/> as input for another <see cref="Godot.AnimationNode"/>, at the input port specified by <paramref name="inputIndex"/>.</para>
    /// </summary>
    public void ConnectNode(StringName inputNode, int inputIndex, StringName outputNode)
    {
        NativeCalls.godot_icall_3_153(MethodBind5, GodotObject.GetPtr(this), (godot_string_name)(inputNode?.NativeValue ?? default), inputIndex, (godot_string_name)(outputNode?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DisconnectNode, 2415702435ul);

    /// <summary>
    /// <para>Disconnects the animation node connected to the specified input.</para>
    /// </summary>
    public void DisconnectNode(StringName inputNode, int inputIndex)
    {
        NativeCalls.godot_icall_2_154(MethodBind6, GodotObject.GetPtr(this), (godot_string_name)(inputNode?.NativeValue ?? default), inputIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNodeList, 3995934104ul);

    /// <summary>
    /// <para>Returns a list containing the names of all sub animation nodes in this blend tree.</para>
    /// </summary>
    public Godot.Collections.Array<StringName> GetNodeList()
    {
        return new Godot.Collections.Array<StringName>(NativeCalls.godot_icall_0_120(MethodBind7, GodotObject.GetPtr(this)));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetNodePosition, 1999414630ul);

    /// <summary>
    /// <para>Modifies the position of a sub animation node.</para>
    /// </summary>
    public unsafe void SetNodePosition(StringName name, Vector2 position)
    {
        NativeCalls.godot_icall_2_155(MethodBind8, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default), &position);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNodePosition, 3100822709ul);

    /// <summary>
    /// <para>Returns the position of the sub animation node with the specified <paramref name="name"/>.</para>
    /// </summary>
    public Vector2 GetNodePosition(StringName name)
    {
        return NativeCalls.godot_icall_1_156(MethodBind9, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetGraphOffset, 743155724ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetGraphOffset(Vector2 offset)
    {
        NativeCalls.godot_icall_1_36(MethodBind10, GodotObject.GetPtr(this), &offset);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetGraphOffset, 3341600327ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2 GetGraphOffset()
    {
        return NativeCalls.godot_icall_0_37(MethodBind11, GodotObject.GetPtr(this));
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.AnimationNodeBlendTree.NodeChanged"/> event of a <see cref="Godot.AnimationNodeBlendTree"/> class.
    /// </summary>
    public delegate void NodeChangedEventHandler(StringName nodeName);

    private static void NodeChangedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((NodeChangedEventHandler)delegateObj)(VariantUtils.ConvertTo<StringName>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when the input port information is changed.</para>
    /// </summary>
    public unsafe event NodeChangedEventHandler NodeChanged
    {
        add => Connect(SignalName.NodeChanged, Callable.CreateWithUnsafeTrampoline(value, &NodeChangedTrampoline));
        remove => Disconnect(SignalName.NodeChanged, Callable.CreateWithUnsafeTrampoline(value, &NodeChangedTrampoline));
    }

    protected void EmitSignalNodeChanged(StringName nodeName)
    {
        EmitSignal(SignalName.NodeChanged, nodeName);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_node_changed = "NodeChanged";

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
        if (signal == SignalName.NodeChanged)
        {
            if (HasGodotClassSignal(SignalProxyName_node_changed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        return base.HasGodotClassSignal(signal);
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : AnimationRootNode.PropertyName
    {
        /// <summary>
        /// Cached name for the 'graph_offset' property.
        /// </summary>
        public static readonly StringName GraphOffset = "graph_offset";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : AnimationRootNode.MethodName
    {
        /// <summary>
        /// Cached name for the 'add_node' method.
        /// </summary>
        public static readonly StringName AddNode = "add_node";
        /// <summary>
        /// Cached name for the 'get_node' method.
        /// </summary>
        public static readonly StringName GetNode = "get_node";
        /// <summary>
        /// Cached name for the 'remove_node' method.
        /// </summary>
        public static readonly StringName RemoveNode = "remove_node";
        /// <summary>
        /// Cached name for the 'rename_node' method.
        /// </summary>
        public static readonly StringName RenameNode = "rename_node";
        /// <summary>
        /// Cached name for the 'has_node' method.
        /// </summary>
        public static readonly StringName HasNode = "has_node";
        /// <summary>
        /// Cached name for the 'connect_node' method.
        /// </summary>
        public static readonly StringName ConnectNode = "connect_node";
        /// <summary>
        /// Cached name for the 'disconnect_node' method.
        /// </summary>
        public static readonly StringName DisconnectNode = "disconnect_node";
        /// <summary>
        /// Cached name for the 'get_node_list' method.
        /// </summary>
        public static readonly StringName GetNodeList = "get_node_list";
        /// <summary>
        /// Cached name for the 'set_node_position' method.
        /// </summary>
        public static readonly StringName SetNodePosition = "set_node_position";
        /// <summary>
        /// Cached name for the 'get_node_position' method.
        /// </summary>
        public static readonly StringName GetNodePosition = "get_node_position";
        /// <summary>
        /// Cached name for the 'set_graph_offset' method.
        /// </summary>
        public static readonly StringName SetGraphOffset = "set_graph_offset";
        /// <summary>
        /// Cached name for the 'get_graph_offset' method.
        /// </summary>
        public static readonly StringName GetGraphOffset = "get_graph_offset";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : AnimationRootNode.SignalName
    {
        /// <summary>
        /// Cached name for the 'node_changed' signal.
        /// </summary>
        public static readonly StringName NodeChanged = "node_changed";
    }
}
