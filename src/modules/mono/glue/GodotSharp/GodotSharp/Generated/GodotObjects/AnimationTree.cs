namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A node used for advanced animation transitions in an <see cref="Godot.AnimationPlayer"/>.</para>
/// <para><b>Note:</b> When linked with an <see cref="Godot.AnimationPlayer"/>, several properties and methods of the corresponding <see cref="Godot.AnimationPlayer"/> will not function as expected. Playback and transitions should be handled using only the <see cref="Godot.AnimationTree"/> and its constituent <see cref="Godot.AnimationNode"/>(s). The <see cref="Godot.AnimationPlayer"/> node should be used solely for adding, deleting, and editing animations.</para>
/// </summary>
public partial class AnimationTree : AnimationMixer
{
    public enum AnimationProcessCallback : long
    {
        [Obsolete("See 'Godot.AnimationMixer.AnimationCallbackModeProcess.Physics'.")]
        Physics = 0,
        [Obsolete("See 'Godot.AnimationMixer.AnimationCallbackModeProcess.Idle'.")]
        Idle = 1,
        [Obsolete("See 'Godot.AnimationMixer.AnimationCallbackModeProcess.Manual'.")]
        Manual = 2
    }

    /// <summary>
    /// <para>The root animation node of this <see cref="Godot.AnimationTree"/>. See <see cref="Godot.AnimationRootNode"/>.</para>
    /// </summary>
    public AnimationRootNode TreeRoot
    {
        get
        {
            return GetTreeRoot();
        }
        set
        {
            SetTreeRoot(value);
        }
    }

    /// <summary>
    /// <para>The path to the <see cref="Godot.Node"/> used to evaluate the <see cref="Godot.AnimationNode"/> <see cref="Godot.Expression"/> if one is not explicitly specified internally.</para>
    /// </summary>
    public NodePath AdvanceExpressionBaseNode
    {
        get
        {
            return GetAdvanceExpressionBaseNode();
        }
        set
        {
            SetAdvanceExpressionBaseNode(value);
        }
    }

    /// <summary>
    /// <para>The path to the <see cref="Godot.AnimationPlayer"/> used for animating.</para>
    /// </summary>
    public NodePath AnimPlayer
    {
        get
        {
            return GetAnimationPlayer();
        }
        set
        {
            SetAnimationPlayer(value);
        }
    }

    private static readonly System.Type CachedType = typeof(AnimationTree);

    private static readonly StringName NativeName = "AnimationTree";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public AnimationTree() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal AnimationTree(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal AnimationTree(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTreeRoot, 2581683800ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTreeRoot(AnimationRootNode animationNode)
    {
        NativeCalls.godot_icall_1_56(MethodBind0, GodotObject.GetPtr(this), GodotObject.GetPtr(animationNode));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTreeRoot, 4110384712ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public AnimationRootNode GetTreeRoot()
    {
        return (AnimationRootNode)NativeCalls.godot_icall_0_63(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAdvanceExpressionBaseNode, 1348162250ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAdvanceExpressionBaseNode(NodePath path)
    {
        NativeCalls.godot_icall_1_123(MethodBind2, GodotObject.GetPtr(this), (godot_node_path)(path?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAdvanceExpressionBaseNode, 4075236667ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public NodePath GetAdvanceExpressionBaseNode()
    {
        return NativeCalls.godot_icall_0_124(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAnimationPlayer, 1348162250ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAnimationPlayer(NodePath path)
    {
        NativeCalls.godot_icall_1_123(MethodBind4, GodotObject.GetPtr(this), (godot_node_path)(path?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAnimationPlayer, 4075236667ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public NodePath GetAnimationPlayer()
    {
        return NativeCalls.godot_icall_0_124(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetProcessCallback, 1723352826ul);

    /// <summary>
    /// <para>Sets the process notification in which to update animations.</para>
    /// </summary>
    [Obsolete("Use 'Godot.AnimationMixer.CallbackModeProcess' instead.")]
    public void SetProcessCallback(AnimationTree.AnimationProcessCallback mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind6, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetProcessCallback, 891317132ul);

    /// <summary>
    /// <para>Returns the process notification in which to update animations.</para>
    /// </summary>
    [Obsolete("Use 'Godot.AnimationMixer.CallbackModeProcess' instead.")]
    public AnimationTree.AnimationProcessCallback GetProcessCallback()
    {
        return (AnimationTree.AnimationProcessCallback)NativeCalls.godot_icall_0_39(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTreeRoot, 712869711ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTreeRoot(AnimationNode root)
    {
        NativeCalls.godot_icall_1_56(MethodBind8, GodotObject.GetPtr(this), GodotObject.GetPtr(root));
    }

    /// <summary>
    /// <para>Emitted when the <see cref="Godot.AnimationTree.AnimPlayer"/> is changed.</para>
    /// </summary>
    public event Action AnimationPlayerChanged
    {
        add => Connect(SignalName.AnimationPlayerChanged, Callable.From(value));
        remove => Disconnect(SignalName.AnimationPlayerChanged, Callable.From(value));
    }

    protected void EmitSignalAnimationPlayerChanged()
    {
        EmitSignal(SignalName.AnimationPlayerChanged);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_animation_player_changed = "AnimationPlayerChanged";

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
        if (signal == SignalName.AnimationPlayerChanged)
        {
            if (HasGodotClassSignal(SignalProxyName_animation_player_changed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        return base.HasGodotClassSignal(signal);
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : AnimationMixer.PropertyName
    {
        /// <summary>
        /// Cached name for the 'tree_root' property.
        /// </summary>
        public static readonly StringName TreeRoot = "tree_root";
        /// <summary>
        /// Cached name for the 'advance_expression_base_node' property.
        /// </summary>
        public static readonly StringName AdvanceExpressionBaseNode = "advance_expression_base_node";
        /// <summary>
        /// Cached name for the 'anim_player' property.
        /// </summary>
        public static readonly StringName AnimPlayer = "anim_player";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : AnimationMixer.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_tree_root' method.
        /// </summary>
        public static readonly StringName SetTreeRoot = "set_tree_root";
        /// <summary>
        /// Cached name for the 'get_tree_root' method.
        /// </summary>
        public static readonly StringName GetTreeRoot = "get_tree_root";
        /// <summary>
        /// Cached name for the 'set_advance_expression_base_node' method.
        /// </summary>
        public static readonly StringName SetAdvanceExpressionBaseNode = "set_advance_expression_base_node";
        /// <summary>
        /// Cached name for the 'get_advance_expression_base_node' method.
        /// </summary>
        public static readonly StringName GetAdvanceExpressionBaseNode = "get_advance_expression_base_node";
        /// <summary>
        /// Cached name for the 'set_animation_player' method.
        /// </summary>
        public static readonly StringName SetAnimationPlayer = "set_animation_player";
        /// <summary>
        /// Cached name for the 'get_animation_player' method.
        /// </summary>
        public static readonly StringName GetAnimationPlayer = "get_animation_player";
        /// <summary>
        /// Cached name for the 'set_process_callback' method.
        /// </summary>
        public static readonly StringName SetProcessCallback = "set_process_callback";
        /// <summary>
        /// Cached name for the 'get_process_callback' method.
        /// </summary>
        public static readonly StringName GetProcessCallback = "get_process_callback";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : AnimationMixer.SignalName
    {
        /// <summary>
        /// Cached name for the 'animation_player_changed' signal.
        /// </summary>
        public static readonly StringName AnimationPlayerChanged = "animation_player_changed";
    }
}
