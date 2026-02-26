namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Contains multiple <see cref="Godot.AnimationRootNode"/>s representing animation states, connected in a graph. State transitions can be configured to happen automatically or via code, using a shortest-path algorithm. Retrieve the <see cref="Godot.AnimationNodeStateMachinePlayback"/> object from the <see cref="Godot.AnimationTree"/> node to control it programmatically.</para>
/// <para><code>
/// var stateMachine = GetNode&lt;AnimationTree&gt;("AnimationTree").Get("parameters/playback") as AnimationNodeStateMachinePlayback;
/// stateMachine.Travel("some_state");
/// </code></para>
/// </summary>
public partial class AnimationNodeStateMachine : AnimationRootNode
{
    public enum StateMachineTypeEnum : long
    {
        /// <summary>
        /// <para>Seeking to the beginning is treated as playing from the start state. Transition to the end state is treated as exiting the state machine.</para>
        /// </summary>
        Root = 0,
        /// <summary>
        /// <para>Seeking to the beginning is treated as seeking to the beginning of the animation in the current state. Transition to the end state, or the absence of transitions in each state, is treated as exiting the state machine.</para>
        /// </summary>
        Nested = 1,
        /// <summary>
        /// <para>This is a grouped state machine that can be controlled from a parent state machine. It does not work independently. There must be a state machine with <see cref="Godot.AnimationNodeStateMachine.StateMachineType"/> of <see cref="Godot.AnimationNodeStateMachine.StateMachineTypeEnum.Root"/> or <see cref="Godot.AnimationNodeStateMachine.StateMachineTypeEnum.Nested"/> in the parent or ancestor.</para>
        /// </summary>
        Grouped = 2
    }

    /// <summary>
    /// <para>This property can define the process of transitions for different use cases. See also <see cref="Godot.AnimationNodeStateMachine.StateMachineTypeEnum"/>.</para>
    /// </summary>
    public AnimationNodeStateMachine.StateMachineTypeEnum StateMachineType
    {
        get
        {
            return GetStateMachineType();
        }
        set
        {
            SetStateMachineType(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, allows teleport to the self state with <see cref="Godot.AnimationNodeStateMachinePlayback.Travel(StringName, bool)"/>. When the reset option is enabled in <see cref="Godot.AnimationNodeStateMachinePlayback.Travel(StringName, bool)"/>, the animation is restarted. If <see langword="false"/>, nothing happens on the teleportation to the self state.</para>
    /// </summary>
    public bool AllowTransitionToSelf
    {
        get
        {
            return IsAllowTransitionToSelf();
        }
        set
        {
            SetAllowTransitionToSelf(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, treat the cross-fade to the start and end nodes as a blend with the RESET animation.</para>
    /// <para>In most cases, when additional cross-fades are performed in the parent <see cref="Godot.AnimationNode"/> of the state machine, setting this property to <see langword="false"/> and matching the cross-fade time of the parent <see cref="Godot.AnimationNode"/> and the state machine's start node and end node gives good results.</para>
    /// </summary>
    public bool ResetEnds
    {
        get
        {
            return AreEndsReset();
        }
        set
        {
            SetResetEnds(value);
        }
    }

    private static readonly System.Type CachedType = typeof(AnimationNodeStateMachine);

    private static readonly StringName NativeName = "AnimationNodeStateMachine";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public AnimationNodeStateMachine() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal AnimationNodeStateMachine(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal AnimationNodeStateMachine(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddNode, 1980270704ul);

    /// <summary>
    /// <para>Adds a new animation node to the graph. The <paramref name="position"/> is used for display in the editor.</para>
    /// </summary>
    /// <param name="position">If the parameter is null, then the default value is <c>new Vector2(0.0f, 0.0f)</c>.</param>
    public unsafe void AddNode(StringName name, AnimationNode node, Nullable<Vector2> position = null)
    {
        Vector2 positionOrDefVal = position.HasValue ? position.Value : new Vector2(0.0f, 0.0f);
        NativeCalls.godot_icall_3_152(MethodBind0, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default), GodotObject.GetPtr(node), &positionOrDefVal);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ReplaceNode, 2559412862ul);

    /// <summary>
    /// <para>Replaces the given animation node with a new animation node.</para>
    /// </summary>
    public void ReplaceNode(StringName name, AnimationNode node)
    {
        NativeCalls.godot_icall_2_159(MethodBind1, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default), GodotObject.GetPtr(node));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNode, 625644256ul);

    /// <summary>
    /// <para>Returns the animation node with the given name.</para>
    /// </summary>
    public AnimationNode GetNode(StringName name)
    {
        return (AnimationNode)NativeCalls.godot_icall_1_119(MethodBind2, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveNode, 3304788590ul);

    /// <summary>
    /// <para>Deletes the given animation node from the graph.</para>
    /// </summary>
    public void RemoveNode(StringName name)
    {
        NativeCalls.godot_icall_1_64(MethodBind3, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RenameNode, 3740211285ul);

    /// <summary>
    /// <para>Renames the given animation node.</para>
    /// </summary>
    public void RenameNode(StringName name, StringName newName)
    {
        NativeCalls.godot_icall_2_118(MethodBind4, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default), (godot_string_name)(newName?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasNode, 2619796661ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the graph contains the given animation node.</para>
    /// </summary>
    public bool HasNode(StringName name)
    {
        return NativeCalls.godot_icall_1_105(MethodBind5, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNodeName, 739213945ul);

    /// <summary>
    /// <para>Returns the given animation node's name.</para>
    /// </summary>
    public StringName GetNodeName(AnimationNode node)
    {
        return NativeCalls.godot_icall_1_129(MethodBind6, GodotObject.GetPtr(this), GodotObject.GetPtr(node));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNodeList, 3995934104ul);

    /// <summary>
    /// <para>Returns a list containing the names of all animation nodes in this state machine.</para>
    /// </summary>
    public Godot.Collections.Array<StringName> GetNodeList()
    {
        return new Godot.Collections.Array<StringName>(NativeCalls.godot_icall_0_120(MethodBind7, GodotObject.GetPtr(this)));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetNodePosition, 1999414630ul);

    /// <summary>
    /// <para>Sets the animation node's coordinates. Used for display in the editor.</para>
    /// </summary>
    public unsafe void SetNodePosition(StringName name, Vector2 position)
    {
        NativeCalls.godot_icall_2_155(MethodBind8, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default), &position);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNodePosition, 3100822709ul);

    /// <summary>
    /// <para>Returns the given animation node's coordinates. Used for display in the editor.</para>
    /// </summary>
    public Vector2 GetNodePosition(StringName name)
    {
        return NativeCalls.godot_icall_1_156(MethodBind9, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasTransition, 471820014ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if there is a transition between the given animation nodes.</para>
    /// </summary>
    public bool HasTransition(StringName from, StringName to)
    {
        return NativeCalls.godot_icall_2_160(MethodBind10, GodotObject.GetPtr(this), (godot_string_name)(from?.NativeValue ?? default), (godot_string_name)(to?.NativeValue ?? default)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddTransition, 795486887ul);

    /// <summary>
    /// <para>Adds a transition between the given animation nodes.</para>
    /// </summary>
    public void AddTransition(StringName from, StringName to, AnimationNodeStateMachineTransition transition)
    {
        NativeCalls.godot_icall_3_161(MethodBind11, GodotObject.GetPtr(this), (godot_string_name)(from?.NativeValue ?? default), (godot_string_name)(to?.NativeValue ?? default), GodotObject.GetPtr(transition));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTransition, 4192381260ul);

    /// <summary>
    /// <para>Returns the given transition.</para>
    /// </summary>
    public AnimationNodeStateMachineTransition GetTransition(int idx)
    {
        return (AnimationNodeStateMachineTransition)NativeCalls.godot_icall_1_71(MethodBind12, GodotObject.GetPtr(this), idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTransitionFrom, 659327637ul);

    /// <summary>
    /// <para>Returns the given transition's start node.</para>
    /// </summary>
    public StringName GetTransitionFrom(int idx)
    {
        return NativeCalls.godot_icall_1_162(MethodBind13, GodotObject.GetPtr(this), idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTransitionTo, 659327637ul);

    /// <summary>
    /// <para>Returns the given transition's end node.</para>
    /// </summary>
    public StringName GetTransitionTo(int idx)
    {
        return NativeCalls.godot_icall_1_162(MethodBind14, GodotObject.GetPtr(this), idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTransitionCount, 3905245786ul);

    /// <summary>
    /// <para>Returns the number of connections in the graph.</para>
    /// </summary>
    public int GetTransitionCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind15, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveTransitionByIndex, 1286410249ul);

    /// <summary>
    /// <para>Deletes the given transition by index.</para>
    /// </summary>
    public void RemoveTransitionByIndex(int idx)
    {
        NativeCalls.godot_icall_1_38(MethodBind16, GodotObject.GetPtr(this), idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveTransition, 3740211285ul);

    /// <summary>
    /// <para>Deletes the transition between the two specified animation nodes.</para>
    /// </summary>
    public void RemoveTransition(StringName from, StringName to)
    {
        NativeCalls.godot_icall_2_118(MethodBind17, GodotObject.GetPtr(this), (godot_string_name)(from?.NativeValue ?? default), (godot_string_name)(to?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetGraphOffset, 743155724ul);

    /// <summary>
    /// <para>Sets the draw offset of the graph. Used for display in the editor.</para>
    /// </summary>
    public unsafe void SetGraphOffset(Vector2 offset)
    {
        NativeCalls.godot_icall_1_36(MethodBind18, GodotObject.GetPtr(this), &offset);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetGraphOffset, 3341600327ul);

    /// <summary>
    /// <para>Returns the draw offset of the graph. Used for display in the editor.</para>
    /// </summary>
    public Vector2 GetGraphOffset()
    {
        return NativeCalls.godot_icall_0_37(MethodBind19, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetStateMachineType, 2584759088ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetStateMachineType(AnimationNodeStateMachine.StateMachineTypeEnum stateMachineType)
    {
        NativeCalls.godot_icall_1_38(MethodBind20, GodotObject.GetPtr(this), (int)stateMachineType);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetStateMachineType, 1140726469ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public AnimationNodeStateMachine.StateMachineTypeEnum GetStateMachineType()
    {
        return (AnimationNodeStateMachine.StateMachineTypeEnum)NativeCalls.godot_icall_0_39(MethodBind21, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAllowTransitionToSelf, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAllowTransitionToSelf(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind22, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsAllowTransitionToSelf, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsAllowTransitionToSelf()
    {
        return NativeCalls.godot_icall_0_15(MethodBind23, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetResetEnds, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetResetEnds(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind24, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AreEndsReset, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool AreEndsReset()
    {
        return NativeCalls.godot_icall_0_15(MethodBind25, GodotObject.GetPtr(this)).ToBool();
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
    public new class PropertyName : AnimationRootNode.PropertyName
    {
        /// <summary>
        /// Cached name for the 'state_machine_type' property.
        /// </summary>
        public static readonly StringName StateMachineType = "state_machine_type";
        /// <summary>
        /// Cached name for the 'allow_transition_to_self' property.
        /// </summary>
        public static readonly StringName AllowTransitionToSelf = "allow_transition_to_self";
        /// <summary>
        /// Cached name for the 'reset_ends' property.
        /// </summary>
        public static readonly StringName ResetEnds = "reset_ends";
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
        /// Cached name for the 'replace_node' method.
        /// </summary>
        public static readonly StringName ReplaceNode = "replace_node";
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
        /// Cached name for the 'get_node_name' method.
        /// </summary>
        public static readonly StringName GetNodeName = "get_node_name";
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
        /// Cached name for the 'has_transition' method.
        /// </summary>
        public static readonly StringName HasTransition = "has_transition";
        /// <summary>
        /// Cached name for the 'add_transition' method.
        /// </summary>
        public static readonly StringName AddTransition = "add_transition";
        /// <summary>
        /// Cached name for the 'get_transition' method.
        /// </summary>
        public static readonly StringName GetTransition = "get_transition";
        /// <summary>
        /// Cached name for the 'get_transition_from' method.
        /// </summary>
        public static readonly StringName GetTransitionFrom = "get_transition_from";
        /// <summary>
        /// Cached name for the 'get_transition_to' method.
        /// </summary>
        public static readonly StringName GetTransitionTo = "get_transition_to";
        /// <summary>
        /// Cached name for the 'get_transition_count' method.
        /// </summary>
        public static readonly StringName GetTransitionCount = "get_transition_count";
        /// <summary>
        /// Cached name for the 'remove_transition_by_index' method.
        /// </summary>
        public static readonly StringName RemoveTransitionByIndex = "remove_transition_by_index";
        /// <summary>
        /// Cached name for the 'remove_transition' method.
        /// </summary>
        public static readonly StringName RemoveTransition = "remove_transition";
        /// <summary>
        /// Cached name for the 'set_graph_offset' method.
        /// </summary>
        public static readonly StringName SetGraphOffset = "set_graph_offset";
        /// <summary>
        /// Cached name for the 'get_graph_offset' method.
        /// </summary>
        public static readonly StringName GetGraphOffset = "get_graph_offset";
        /// <summary>
        /// Cached name for the 'set_state_machine_type' method.
        /// </summary>
        public static readonly StringName SetStateMachineType = "set_state_machine_type";
        /// <summary>
        /// Cached name for the 'get_state_machine_type' method.
        /// </summary>
        public static readonly StringName GetStateMachineType = "get_state_machine_type";
        /// <summary>
        /// Cached name for the 'set_allow_transition_to_self' method.
        /// </summary>
        public static readonly StringName SetAllowTransitionToSelf = "set_allow_transition_to_self";
        /// <summary>
        /// Cached name for the 'is_allow_transition_to_self' method.
        /// </summary>
        public static readonly StringName IsAllowTransitionToSelf = "is_allow_transition_to_self";
        /// <summary>
        /// Cached name for the 'set_reset_ends' method.
        /// </summary>
        public static readonly StringName SetResetEnds = "set_reset_ends";
        /// <summary>
        /// Cached name for the 'are_ends_reset' method.
        /// </summary>
        public static readonly StringName AreEndsReset = "are_ends_reset";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : AnimationRootNode.SignalName
    {
    }
}
