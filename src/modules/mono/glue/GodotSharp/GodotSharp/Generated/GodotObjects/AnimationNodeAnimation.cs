namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A resource to add to an <see cref="Godot.AnimationNodeBlendTree"/>. Only has one output port using the <see cref="Godot.AnimationNodeAnimation.Animation"/> property. Used as an input for <see cref="Godot.AnimationNode"/>s that blend animations together.</para>
/// </summary>
public partial class AnimationNodeAnimation : AnimationRootNode
{
    public enum PlayModeEnum : long
    {
        /// <summary>
        /// <para>Plays animation in forward direction.</para>
        /// </summary>
        Forward = 0,
        /// <summary>
        /// <para>Plays animation in backward direction.</para>
        /// </summary>
        Backward = 1
    }

    /// <summary>
    /// <para>Animation to use as an output. It is one of the animations provided by <see cref="Godot.AnimationTree.AnimPlayer"/>.</para>
    /// </summary>
    public StringName Animation
    {
        get
        {
            return GetAnimation();
        }
        set
        {
            SetAnimation(value);
        }
    }

    /// <summary>
    /// <para>Determines the playback direction of the animation.</para>
    /// </summary>
    public AnimationNodeAnimation.PlayModeEnum PlayMode
    {
        get
        {
            return GetPlayMode();
        }
        set
        {
            SetPlayMode(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, on receiving a request to play an animation from the start, the first frame is not drawn, but only processed, and playback starts from the next frame.</para>
    /// <para>See also the notes of <see cref="Godot.AnimationPlayer.Play(StringName, double, float, bool)"/>.</para>
    /// </summary>
    public bool AdvanceOnStart
    {
        get
        {
            return IsAdvanceOnStart();
        }
        set
        {
            SetAdvanceOnStart(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, <see cref="Godot.AnimationNode"/> provides an animation based on the <see cref="Godot.Animation"/> resource with some parameters adjusted.</para>
    /// </summary>
    public bool UseCustomTimeline
    {
        get
        {
            return IsUsingCustomTimeline();
        }
        set
        {
            SetUseCustomTimeline(value);
        }
    }

    /// <summary>
    /// <para>The length of the custom timeline.</para>
    /// <para>If <see cref="Godot.AnimationNodeAnimation.StretchTimeScale"/> is <see langword="true"/>, scales the animation to this length.</para>
    /// </summary>
    public double TimelineLength
    {
        get
        {
            return GetTimelineLength();
        }
        set
        {
            SetTimelineLength(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, scales the time so that the length specified in <see cref="Godot.AnimationNodeAnimation.TimelineLength"/> is one cycle.</para>
    /// <para>This is useful for matching the periods of walking and running animations.</para>
    /// <para>If <see langword="false"/>, the original animation length is respected. If you set the loop to <see cref="Godot.AnimationNodeAnimation.LoopMode"/>, the animation will loop in <see cref="Godot.AnimationNodeAnimation.TimelineLength"/>.</para>
    /// </summary>
    public bool StretchTimeScale
    {
        get
        {
            return IsStretchingTimeScale();
        }
        set
        {
            SetStretchTimeScale(value);
        }
    }

    /// <summary>
    /// <para>If <see cref="Godot.AnimationNodeAnimation.UseCustomTimeline"/> is <see langword="true"/>, offset the start position of the animation.</para>
    /// <para>This is useful for adjusting which foot steps first in 3D walking animations.</para>
    /// </summary>
    public double StartOffset
    {
        get
        {
            return GetStartOffset();
        }
        set
        {
            SetStartOffset(value);
        }
    }

    /// <summary>
    /// <para>If <see cref="Godot.AnimationNodeAnimation.UseCustomTimeline"/> is <see langword="true"/>, override the loop settings of the original <see cref="Godot.Animation"/> resource with the value.</para>
    /// <para><b>Note:</b> If the <see cref="Godot.Animation.LoopMode"/> isn't set to looping, the <see cref="Godot.Animation.TrackSetInterpolationLoopWrap(int, bool)"/> option will not be respected. If you cannot get the expected behavior, consider duplicating the <see cref="Godot.Animation"/> resource and changing the loop settings.</para>
    /// </summary>
    public Animation.LoopModeEnum LoopMode
    {
        get
        {
            return GetLoopMode();
        }
        set
        {
            SetLoopMode(value);
        }
    }

    private static readonly System.Type CachedType = typeof(AnimationNodeAnimation);

    private static readonly StringName NativeName = "AnimationNodeAnimation";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public AnimationNodeAnimation() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal AnimationNodeAnimation(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal AnimationNodeAnimation(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAnimation, 3304788590ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAnimation(StringName name)
    {
        NativeCalls.godot_icall_1_64(MethodBind0, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAnimation, 2002593661ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public StringName GetAnimation()
    {
        return NativeCalls.godot_icall_0_65(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPlayMode, 3347718873ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPlayMode(AnimationNodeAnimation.PlayModeEnum mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind2, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPlayMode, 2061244637ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public AnimationNodeAnimation.PlayModeEnum GetPlayMode()
    {
        return (AnimationNodeAnimation.PlayModeEnum)NativeCalls.godot_icall_0_39(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAdvanceOnStart, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAdvanceOnStart(bool advanceOnStart)
    {
        NativeCalls.godot_icall_1_14(MethodBind4, GodotObject.GetPtr(this), advanceOnStart.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsAdvanceOnStart, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsAdvanceOnStart()
    {
        return NativeCalls.godot_icall_0_15(MethodBind5, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetUseCustomTimeline, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetUseCustomTimeline(bool useCustomTimeline)
    {
        NativeCalls.godot_icall_1_14(MethodBind6, GodotObject.GetPtr(this), useCustomTimeline.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsUsingCustomTimeline, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsUsingCustomTimeline()
    {
        return NativeCalls.godot_icall_0_15(MethodBind7, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTimelineLength, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTimelineLength(double timelineLength)
    {
        NativeCalls.godot_icall_1_127(MethodBind8, GodotObject.GetPtr(this), timelineLength);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTimelineLength, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public double GetTimelineLength()
    {
        return NativeCalls.godot_icall_0_144(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetStretchTimeScale, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetStretchTimeScale(bool stretchTimeScale)
    {
        NativeCalls.godot_icall_1_14(MethodBind10, GodotObject.GetPtr(this), stretchTimeScale.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsStretchingTimeScale, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsStretchingTimeScale()
    {
        return NativeCalls.godot_icall_0_15(MethodBind11, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetStartOffset, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetStartOffset(double startOffset)
    {
        NativeCalls.godot_icall_1_127(MethodBind12, GodotObject.GetPtr(this), startOffset);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetStartOffset, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public double GetStartOffset()
    {
        return NativeCalls.godot_icall_0_144(MethodBind13, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLoopMode, 3155355575ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetLoopMode(Animation.LoopModeEnum loopMode)
    {
        NativeCalls.godot_icall_1_38(MethodBind14, GodotObject.GetPtr(this), (int)loopMode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLoopMode, 1988889481ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Animation.LoopModeEnum GetLoopMode()
    {
        return (Animation.LoopModeEnum)NativeCalls.godot_icall_0_39(MethodBind15, GodotObject.GetPtr(this));
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
        /// Cached name for the 'animation' property.
        /// </summary>
        public static readonly StringName Animation = "animation";
        /// <summary>
        /// Cached name for the 'play_mode' property.
        /// </summary>
        public static readonly StringName PlayMode = "play_mode";
        /// <summary>
        /// Cached name for the 'advance_on_start' property.
        /// </summary>
        public static readonly StringName AdvanceOnStart = "advance_on_start";
        /// <summary>
        /// Cached name for the 'use_custom_timeline' property.
        /// </summary>
        public static readonly StringName UseCustomTimeline = "use_custom_timeline";
        /// <summary>
        /// Cached name for the 'timeline_length' property.
        /// </summary>
        public static readonly StringName TimelineLength = "timeline_length";
        /// <summary>
        /// Cached name for the 'stretch_time_scale' property.
        /// </summary>
        public static readonly StringName StretchTimeScale = "stretch_time_scale";
        /// <summary>
        /// Cached name for the 'start_offset' property.
        /// </summary>
        public static readonly StringName StartOffset = "start_offset";
        /// <summary>
        /// Cached name for the 'loop_mode' property.
        /// </summary>
        public static readonly StringName LoopMode = "loop_mode";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : AnimationRootNode.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_animation' method.
        /// </summary>
        public static readonly StringName SetAnimation = "set_animation";
        /// <summary>
        /// Cached name for the 'get_animation' method.
        /// </summary>
        public static readonly StringName GetAnimation = "get_animation";
        /// <summary>
        /// Cached name for the 'set_play_mode' method.
        /// </summary>
        public static readonly StringName SetPlayMode = "set_play_mode";
        /// <summary>
        /// Cached name for the 'get_play_mode' method.
        /// </summary>
        public static readonly StringName GetPlayMode = "get_play_mode";
        /// <summary>
        /// Cached name for the 'set_advance_on_start' method.
        /// </summary>
        public static readonly StringName SetAdvanceOnStart = "set_advance_on_start";
        /// <summary>
        /// Cached name for the 'is_advance_on_start' method.
        /// </summary>
        public static readonly StringName IsAdvanceOnStart = "is_advance_on_start";
        /// <summary>
        /// Cached name for the 'set_use_custom_timeline' method.
        /// </summary>
        public static readonly StringName SetUseCustomTimeline = "set_use_custom_timeline";
        /// <summary>
        /// Cached name for the 'is_using_custom_timeline' method.
        /// </summary>
        public static readonly StringName IsUsingCustomTimeline = "is_using_custom_timeline";
        /// <summary>
        /// Cached name for the 'set_timeline_length' method.
        /// </summary>
        public static readonly StringName SetTimelineLength = "set_timeline_length";
        /// <summary>
        /// Cached name for the 'get_timeline_length' method.
        /// </summary>
        public static readonly StringName GetTimelineLength = "get_timeline_length";
        /// <summary>
        /// Cached name for the 'set_stretch_time_scale' method.
        /// </summary>
        public static readonly StringName SetStretchTimeScale = "set_stretch_time_scale";
        /// <summary>
        /// Cached name for the 'is_stretching_time_scale' method.
        /// </summary>
        public static readonly StringName IsStretchingTimeScale = "is_stretching_time_scale";
        /// <summary>
        /// Cached name for the 'set_start_offset' method.
        /// </summary>
        public static readonly StringName SetStartOffset = "set_start_offset";
        /// <summary>
        /// Cached name for the 'get_start_offset' method.
        /// </summary>
        public static readonly StringName GetStartOffset = "get_start_offset";
        /// <summary>
        /// Cached name for the 'set_loop_mode' method.
        /// </summary>
        public static readonly StringName SetLoopMode = "set_loop_mode";
        /// <summary>
        /// Cached name for the 'get_loop_mode' method.
        /// </summary>
        public static readonly StringName GetLoopMode = "get_loop_mode";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : AnimationRootNode.SignalName
    {
    }
}
