namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Allows control of <see cref="Godot.AnimationTree"/> state machines created with <see cref="Godot.AnimationNodeStateMachine"/>. Retrieve with <c>$AnimationTree.get("parameters/playback")</c>.</para>
/// <para><code>
/// var stateMachine = GetNode&lt;AnimationTree&gt;("AnimationTree").Get("parameters/playback").As&lt;AnimationNodeStateMachinePlayback&gt;();
/// stateMachine.Travel("some_state");
/// </code></para>
/// </summary>
public partial class AnimationNodeStateMachinePlayback : Resource
{
    private static readonly System.Type CachedType = typeof(AnimationNodeStateMachinePlayback);

    private static readonly StringName NativeName = "AnimationNodeStateMachinePlayback";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public AnimationNodeStateMachinePlayback() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal AnimationNodeStateMachinePlayback(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal AnimationNodeStateMachinePlayback(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Travel, 3823612587ul);

    /// <summary>
    /// <para>Transitions from the current state to another one, following the shortest path.</para>
    /// <para>If the path does not connect from the current state, the animation will play after the state teleports.</para>
    /// <para>If <paramref name="resetOnTeleport"/> is <see langword="true"/>, the animation is played from the beginning when the travel cause a teleportation.</para>
    /// </summary>
    public void Travel(StringName toNode, bool resetOnTeleport = true)
    {
        NativeCalls.godot_icall_2_163(MethodBind0, GodotObject.GetPtr(this), (godot_string_name)(toNode?.NativeValue ?? default), resetOnTeleport.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Start, 3823612587ul);

    /// <summary>
    /// <para>Starts playing the given animation.</para>
    /// <para>If <paramref name="reset"/> is <see langword="true"/>, the animation is played from the beginning.</para>
    /// </summary>
    public void Start(StringName node, bool reset = true)
    {
        NativeCalls.godot_icall_2_163(MethodBind1, GodotObject.GetPtr(this), (godot_string_name)(node?.NativeValue ?? default), reset.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Next, 3218959716ul);

    /// <summary>
    /// <para>If there is a next path by travel or auto advance, immediately transitions from the current state to the next state.</para>
    /// </summary>
    public void Next()
    {
        NativeCalls.godot_icall_0_3(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Stop, 3218959716ul);

    /// <summary>
    /// <para>Stops the currently playing animation.</para>
    /// </summary>
    public void Stop()
    {
        NativeCalls.godot_icall_0_3(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsPlaying, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if an animation is playing.</para>
    /// </summary>
    public bool IsPlaying()
    {
        return NativeCalls.godot_icall_0_15(MethodBind4, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCurrentNode, 2002593661ul);

    /// <summary>
    /// <para>Returns the currently playing animation state.</para>
    /// <para><b>Note:</b> When using a cross-fade, the current state changes to the next state immediately after the cross-fade begins.</para>
    /// </summary>
    public StringName GetCurrentNode()
    {
        return NativeCalls.godot_icall_0_65(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCurrentPlayPosition, 1740695150ul);

    /// <summary>
    /// <para>Returns the playback position within the current animation state.</para>
    /// </summary>
    public float GetCurrentPlayPosition()
    {
        return NativeCalls.godot_icall_0_68(MethodBind6, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCurrentLength, 1740695150ul);

    /// <summary>
    /// <para>Returns the current state length.</para>
    /// <para><b>Note:</b> It is possible that any <see cref="Godot.AnimationRootNode"/> can be nodes as well as animations. This means that there can be multiple animations within a single state. Which animation length has priority depends on the nodes connected inside it. Also, if a transition does not reset, the remaining length at that point will be returned.</para>
    /// </summary>
    public float GetCurrentLength()
    {
        return NativeCalls.godot_icall_0_68(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFadingFromNode, 2002593661ul);

    /// <summary>
    /// <para>Returns the starting state of currently fading animation.</para>
    /// </summary>
    public StringName GetFadingFromNode()
    {
        return NativeCalls.godot_icall_0_65(MethodBind8, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFadingFromPlayPosition, 1740695150ul);

    /// <summary>
    /// <para>Returns the playback position of the node from <see cref="Godot.AnimationNodeStateMachinePlayback.GetFadingFromNode()"/>. Returns <c>0</c> if no animation fade is occurring.</para>
    /// </summary>
    public float GetFadingFromPlayPosition()
    {
        return NativeCalls.godot_icall_0_68(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFadingFromLength, 1740695150ul);

    /// <summary>
    /// <para>Returns the playback state length of the node from <see cref="Godot.AnimationNodeStateMachinePlayback.GetFadingFromNode()"/>. Returns <c>0</c> if no animation fade is occurring.</para>
    /// </summary>
    public float GetFadingFromLength()
    {
        return NativeCalls.godot_icall_0_68(MethodBind10, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFadingPosition, 1740695150ul);

    /// <summary>
    /// <para>Returns the playback position of the current fade animation. Returns <c>0</c> if no animation fade is occurring.</para>
    /// </summary>
    public float GetFadingPosition()
    {
        return NativeCalls.godot_icall_0_68(MethodBind11, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFadingLength, 1740695150ul);

    /// <summary>
    /// <para>Returns the length of the current fade animation. Returns <c>0</c> if no animation fade is occurring.</para>
    /// </summary>
    public float GetFadingLength()
    {
        return NativeCalls.godot_icall_0_68(MethodBind12, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTravelPath, 3995934104ul);

    /// <summary>
    /// <para>Returns the current travel path as computed internally by the A* algorithm.</para>
    /// </summary>
    public Godot.Collections.Array<StringName> GetTravelPath()
    {
        return new Godot.Collections.Array<StringName>(NativeCalls.godot_icall_0_120(MethodBind13, GodotObject.GetPtr(this)));
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.AnimationNodeStateMachinePlayback.StateStarted"/> event of a <see cref="Godot.AnimationNodeStateMachinePlayback"/> class.
    /// </summary>
    public delegate void StateStartedEventHandler(StringName state);

    private static void StateStartedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((StateStartedEventHandler)delegateObj)(VariantUtils.ConvertTo<StringName>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when the <c>state</c> starts playback. If <c>state</c> is a state machine set to grouped mode, its signals are passed through with its name prefixed.</para>
    /// </summary>
    public unsafe event StateStartedEventHandler StateStarted
    {
        add => Connect(SignalName.StateStarted, Callable.CreateWithUnsafeTrampoline(value, &StateStartedTrampoline));
        remove => Disconnect(SignalName.StateStarted, Callable.CreateWithUnsafeTrampoline(value, &StateStartedTrampoline));
    }

    protected void EmitSignalStateStarted(StringName state)
    {
        EmitSignal(SignalName.StateStarted, state);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.AnimationNodeStateMachinePlayback.StateFinished"/> event of a <see cref="Godot.AnimationNodeStateMachinePlayback"/> class.
    /// </summary>
    public delegate void StateFinishedEventHandler(StringName state);

    private static void StateFinishedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((StateFinishedEventHandler)delegateObj)(VariantUtils.ConvertTo<StringName>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when the <c>state</c> finishes playback. If <c>state</c> is a state machine set to grouped mode, its signals are passed through with its name prefixed.</para>
    /// <para>If there is a crossfade, this will be fired when the influence of the <see cref="Godot.AnimationNodeStateMachinePlayback.GetFadingFromNode()"/> animation is no longer present.</para>
    /// </summary>
    public unsafe event StateFinishedEventHandler StateFinished
    {
        add => Connect(SignalName.StateFinished, Callable.CreateWithUnsafeTrampoline(value, &StateFinishedTrampoline));
        remove => Disconnect(SignalName.StateFinished, Callable.CreateWithUnsafeTrampoline(value, &StateFinishedTrampoline));
    }

    protected void EmitSignalStateFinished(StringName state)
    {
        EmitSignal(SignalName.StateFinished, state);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_state_started = "StateStarted";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_state_finished = "StateFinished";

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
        if (signal == SignalName.StateStarted)
        {
            if (HasGodotClassSignal(SignalProxyName_state_started.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.StateFinished)
        {
            if (HasGodotClassSignal(SignalProxyName_state_finished.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
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
        /// Cached name for the 'travel' method.
        /// </summary>
        public static readonly StringName Travel = "travel";
        /// <summary>
        /// Cached name for the 'start' method.
        /// </summary>
        public static readonly StringName Start = "start";
        /// <summary>
        /// Cached name for the 'next' method.
        /// </summary>
        public static readonly StringName Next = "next";
        /// <summary>
        /// Cached name for the 'stop' method.
        /// </summary>
        public static readonly StringName Stop = "stop";
        /// <summary>
        /// Cached name for the 'is_playing' method.
        /// </summary>
        public static readonly StringName IsPlaying = "is_playing";
        /// <summary>
        /// Cached name for the 'get_current_node' method.
        /// </summary>
        public static readonly StringName GetCurrentNode = "get_current_node";
        /// <summary>
        /// Cached name for the 'get_current_play_position' method.
        /// </summary>
        public static readonly StringName GetCurrentPlayPosition = "get_current_play_position";
        /// <summary>
        /// Cached name for the 'get_current_length' method.
        /// </summary>
        public static readonly StringName GetCurrentLength = "get_current_length";
        /// <summary>
        /// Cached name for the 'get_fading_from_node' method.
        /// </summary>
        public static readonly StringName GetFadingFromNode = "get_fading_from_node";
        /// <summary>
        /// Cached name for the 'get_fading_from_play_position' method.
        /// </summary>
        public static readonly StringName GetFadingFromPlayPosition = "get_fading_from_play_position";
        /// <summary>
        /// Cached name for the 'get_fading_from_length' method.
        /// </summary>
        public static readonly StringName GetFadingFromLength = "get_fading_from_length";
        /// <summary>
        /// Cached name for the 'get_fading_position' method.
        /// </summary>
        public static readonly StringName GetFadingPosition = "get_fading_position";
        /// <summary>
        /// Cached name for the 'get_fading_length' method.
        /// </summary>
        public static readonly StringName GetFadingLength = "get_fading_length";
        /// <summary>
        /// Cached name for the 'get_travel_path' method.
        /// </summary>
        public static readonly StringName GetTravelPath = "get_travel_path";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Resource.SignalName
    {
        /// <summary>
        /// Cached name for the 'state_started' signal.
        /// </summary>
        public static readonly StringName StateStarted = "state_started";
        /// <summary>
        /// Cached name for the 'state_finished' signal.
        /// </summary>
        public static readonly StringName StateFinished = "state_finished";
    }
}
