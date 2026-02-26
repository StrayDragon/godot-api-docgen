namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para><see cref="Godot.AnimationRootNode"/> is a base class for <see cref="Godot.AnimationNode"/>s that hold a complete animation. A complete animation refers to the output of an <see cref="Godot.AnimationNodeOutput"/> in an <see cref="Godot.AnimationNodeBlendTree"/> or the output of another <see cref="Godot.AnimationRootNode"/>. Used for <see cref="Godot.AnimationTree.TreeRoot"/> or in other <see cref="Godot.AnimationRootNode"/>s.</para>
/// <para>Examples of built-in root nodes include <see cref="Godot.AnimationNodeBlendTree"/> (allows blending nodes between each other using various modes), <see cref="Godot.AnimationNodeStateMachine"/> (allows to configure blending and transitions between nodes using a state machine pattern), <see cref="Godot.AnimationNodeBlendSpace2D"/> (allows linear blending between <b>three</b> <see cref="Godot.AnimationNode"/>s), <see cref="Godot.AnimationNodeBlendSpace1D"/> (allows linear blending only between <b>two</b> <see cref="Godot.AnimationNode"/>s).</para>
/// </summary>
public partial class AnimationRootNode : AnimationNode
{
    private static readonly System.Type CachedType = typeof(AnimationRootNode);

    private static readonly StringName NativeName = "AnimationRootNode";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public AnimationRootNode() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal AnimationRootNode(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal AnimationRootNode(bool memoryOwn) : base(memoryOwn) { }

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
    public new class PropertyName : AnimationNode.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : AnimationNode.MethodName
    {
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : AnimationNode.SignalName
    {
    }
}
