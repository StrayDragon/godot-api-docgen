namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para><see cref="Godot.AnimationNodeExtension"/> exposes the APIs of <see cref="Godot.AnimationRootNode"/> to allow users to extend it from GDScript, C#, or C++. This class is not meant to be used directly, but to be extended by other classes. It is used to create custom nodes for the <see cref="Godot.AnimationTree"/> system.</para>
/// </summary>
public partial class AnimationNodeExtension : AnimationNode
{
    private static readonly System.Type CachedType = typeof(AnimationNodeExtension);

    private static readonly StringName NativeName = "AnimationNodeExtension";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public AnimationNodeExtension() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal AnimationNodeExtension(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal AnimationNodeExtension(bool memoryOwn) : base(memoryOwn) { }

    /// <summary>
    /// <para>A version of the <see cref="Godot.AnimationNode._Process(double, bool, bool, bool)"/> method that is meant to be overridden by custom nodes. It returns a <see cref="float"/>[] with the processed animation data.</para>
    /// <para>The <see cref="double"/>[] parameter contains the playback information, containing the following values encoded as floating point numbers (in order): playback time and delta, start and end times, whether a seek was requested (encoded as a float greater than <c>0</c>), whether the seek request was externally requested (encoded as a float greater than <c>0</c>), the current <see cref="Godot.Animation.LoopedFlag"/> (encoded as a float), and the current blend weight.</para>
    /// <para>The function must return a <see cref="float"/>[] of the node's time info, containing the following values (in order): animation length, time position, delta, <see cref="Godot.Animation.LoopModeEnum"/> (encoded as a float), whether the animation is about to end (encoded as a float greater than <c>0</c>) and whether the animation is infinite (encoded as a float greater than <c>0</c>). All values must be included in the returned array.</para>
    /// </summary>
    public virtual float[] _ProcessAnimationNode(double[] playbackInfo, bool testOnly)
    {
        return default;
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsLooping, 2035584311ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the animation for the given <paramref name="nodeInfo"/> is looping.</para>
    /// </summary>
    public static bool IsLooping(float[] nodeInfo)
    {
        return NativeCalls.godot_icall_1_157(MethodBind0, nodeInfo).ToBool();
    }

    /// <summary>
    /// <para>Returns <see langword="true"/> if the animation for the given <paramref name="nodeInfo"/> is looping.</para>
    /// </summary>
    public static bool IsLooping(ReadOnlySpan<float> nodeInfo)
    {
        return NativeCalls.godot_icall_1_157(MethodBind0, nodeInfo).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRemainingTime, 2851904656ul);

    /// <summary>
    /// <para>Returns the animation's remaining time for the given node info. For looping animations, it will only return the remaining time if <paramref name="breakLoop"/> is <see langword="true"/>, a large integer value will be returned otherwise.</para>
    /// </summary>
    public static double GetRemainingTime(float[] nodeInfo, bool breakLoop)
    {
        return NativeCalls.godot_icall_2_158(MethodBind1, nodeInfo, breakLoop.ToGodotBool());
    }

    /// <summary>
    /// <para>Returns the animation's remaining time for the given node info. For looping animations, it will only return the remaining time if <paramref name="breakLoop"/> is <see langword="true"/>, a large integer value will be returned otherwise.</para>
    /// </summary>
    public static double GetRemainingTime(ReadOnlySpan<float> nodeInfo, bool breakLoop)
    {
        return NativeCalls.godot_icall_2_158(MethodBind1, nodeInfo, breakLoop.ToGodotBool());
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__process_animation_node = "_ProcessAnimationNode";

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
        if ((method == MethodProxyName__process_animation_node || method == MethodName._ProcessAnimationNode) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__process_animation_node.NativeValue))
        {
            var callRet = _ProcessAnimationNode(VariantUtils.ConvertTo<double[]>(args[0]), VariantUtils.ConvertTo<bool>(args[1]));
            ret = VariantUtils.CreateFrom<float[]>(callRet);
            return true;
        }
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
        if (method == MethodName._ProcessAnimationNode)
        {
            if (HasGodotClassMethod(MethodProxyName__process_animation_node.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
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
        /// <summary>
        /// Cached name for the '_process_animation_node' method.
        /// </summary>
        public static readonly StringName _ProcessAnimationNode = "_process_animation_node";
        /// <summary>
        /// Cached name for the 'is_looping' method.
        /// </summary>
        public static readonly StringName IsLooping = "is_looping";
        /// <summary>
        /// Cached name for the 'get_remaining_time' method.
        /// </summary>
        public static readonly StringName GetRemainingTime = "get_remaining_time";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : AnimationNode.SignalName
    {
    }
}
