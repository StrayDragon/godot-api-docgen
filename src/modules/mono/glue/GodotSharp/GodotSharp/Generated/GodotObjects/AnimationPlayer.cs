namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>An animation player is used for general-purpose playback of animations. It contains a dictionary of <see cref="Godot.AnimationLibrary"/> resources and custom blend times between animation transitions.</para>
/// <para>Some methods and properties use a single key to reference an animation directly. These keys are formatted as the key for the library, followed by a forward slash, then the key for the animation within the library, for example <c>"movement/run"</c>. If the library's key is an empty string (known as the default library), the forward slash is omitted, being the same key used by the library.</para>
/// <para><see cref="Godot.AnimationPlayer"/> is better-suited than <see cref="Godot.Tween"/> for more complex animations, for example ones with non-trivial timings. It can also be used over <see cref="Godot.Tween"/> if the animation track editor is more convenient than doing it in code.</para>
/// <para>Updating the target properties of animations occurs at the process frame.</para>
/// </summary>
public partial class AnimationPlayer : AnimationMixer
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

    public enum AnimationMethodCallMode : long
    {
        [Obsolete("See 'Godot.AnimationMixer.AnimationCallbackModeMethod.Deferred'.")]
        Deferred = 0,
        [Obsolete("See 'Godot.AnimationMixer.AnimationCallbackModeMethod.Immediate'.")]
        Immediate = 1
    }

    /// <summary>
    /// <para>The key of the currently playing animation. If no animation is playing, the property's value is an empty string. Changing this value does not restart the animation. See <see cref="Godot.AnimationPlayer.Play(StringName, double, float, bool)"/> for more information on playing animations.</para>
    /// <para><b>Note:</b> While this property appears in the Inspector, it's not meant to be edited, and it's not saved in the scene. This property is mainly used to get the currently playing animation, and internally for animation playback tracks. For more information, see <see cref="Godot.Animation"/>.</para>
    /// </summary>
    public StringName CurrentAnimation
    {
        get
        {
            return GetCurrentAnimation();
        }
        set
        {
            SetCurrentAnimation(value);
        }
    }

    /// <summary>
    /// <para>If playing, the current animation's key, otherwise, the animation last played. When set, this changes the animation, but will not play it unless already playing. See also <see cref="Godot.AnimationPlayer.CurrentAnimation"/>.</para>
    /// </summary>
    public StringName AssignedAnimation
    {
        get
        {
            return GetAssignedAnimation();
        }
        set
        {
            SetAssignedAnimation(value);
        }
    }

    /// <summary>
    /// <para>The key of the animation to play when the scene loads.</para>
    /// </summary>
    public StringName Autoplay
    {
        get
        {
            return GetAutoplay();
        }
        set
        {
            SetAutoplay(value);
        }
    }

    /// <summary>
    /// <para>The length (in seconds) of the currently playing animation.</para>
    /// </summary>
    public double CurrentAnimationLength
    {
        get
        {
            return GetCurrentAnimationLength();
        }
    }

    /// <summary>
    /// <para>The position (in seconds) of the currently playing animation.</para>
    /// </summary>
    public double CurrentAnimationPosition
    {
        get
        {
            return GetCurrentAnimationPosition();
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, performs <see cref="Godot.AnimationMixer.Capture(StringName, double, Tween.TransitionType, Tween.EaseType)"/> before playback automatically. This means just <see cref="Godot.AnimationPlayer.PlayWithCapture(StringName, double, double, float, bool, Tween.TransitionType, Tween.EaseType)"/> is executed with default arguments instead of <see cref="Godot.AnimationPlayer.Play(StringName, double, float, bool)"/>.</para>
    /// <para><b>Note:</b> Capture interpolation is only performed if the animation contains a capture track. See also <see cref="Godot.Animation.UpdateMode.Capture"/>.</para>
    /// </summary>
    public bool PlaybackAutoCapture
    {
        get
        {
            return IsAutoCapture();
        }
        set
        {
            SetAutoCapture(value);
        }
    }

    /// <summary>
    /// <para>See also <see cref="Godot.AnimationPlayer.PlayWithCapture(StringName, double, double, float, bool, Tween.TransitionType, Tween.EaseType)"/> and <see cref="Godot.AnimationMixer.Capture(StringName, double, Tween.TransitionType, Tween.EaseType)"/>.</para>
    /// <para>If <see cref="Godot.AnimationPlayer.PlaybackAutoCaptureDuration"/> is negative value, the duration is set to the interval between the current position and the first key.</para>
    /// </summary>
    public double PlaybackAutoCaptureDuration
    {
        get
        {
            return GetAutoCaptureDuration();
        }
        set
        {
            SetAutoCaptureDuration(value);
        }
    }

    /// <summary>
    /// <para>The transition type of the capture interpolation. See also <see cref="Godot.Tween.TransitionType"/>.</para>
    /// </summary>
    public Tween.TransitionType PlaybackAutoCaptureTransitionType
    {
        get
        {
            return GetAutoCaptureTransitionType();
        }
        set
        {
            SetAutoCaptureTransitionType(value);
        }
    }

    /// <summary>
    /// <para>The ease type of the capture interpolation. See also <see cref="Godot.Tween.EaseType"/>.</para>
    /// </summary>
    public Tween.EaseType PlaybackAutoCaptureEaseType
    {
        get
        {
            return GetAutoCaptureEaseType();
        }
        set
        {
            SetAutoCaptureEaseType(value);
        }
    }

    /// <summary>
    /// <para>The default time in which to blend animations. Ranges from 0 to 4096 with 0.01 precision.</para>
    /// </summary>
    public double PlaybackDefaultBlendTime
    {
        get
        {
            return GetDefaultBlendTime();
        }
        set
        {
            SetDefaultBlendTime(value);
        }
    }

    /// <summary>
    /// <para>The speed scaling ratio. For example, if this value is <c>1</c>, then the animation plays at normal speed. If it's <c>0.5</c>, then it plays at half speed. If it's <c>2</c>, then it plays at double speed.</para>
    /// <para>If set to a negative value, the animation is played in reverse. If set to <c>0</c>, the animation will not advance.</para>
    /// </summary>
    public float SpeedScale
    {
        get
        {
            return GetSpeedScale();
        }
        set
        {
            SetSpeedScale(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/> and the engine is running in Movie Maker mode (see <see cref="Godot.MovieWriter"/>), exits the engine with <see cref="Godot.SceneTree.Quit(int)"/> as soon as an animation is done playing in this <see cref="Godot.AnimationPlayer"/>. A message is printed when the engine quits for this reason.</para>
    /// <para><b>Note:</b> This obeys the same logic as the <see cref="Godot.AnimationMixer.AnimationFinished"/> signal, so it will not quit the engine if the animation is set to be looping.</para>
    /// </summary>
    public bool MovieQuitOnFinish
    {
        get
        {
            return IsMovieQuitOnFinishEnabled();
        }
        set
        {
            SetMovieQuitOnFinishEnabled(value);
        }
    }

    private static readonly System.Type CachedType = typeof(AnimationPlayer);

    private static readonly StringName NativeName = "AnimationPlayer";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public AnimationPlayer() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal AnimationPlayer(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal AnimationPlayer(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AnimationSetNext, 3740211285ul);

    /// <summary>
    /// <para>Triggers the <paramref name="animationTo"/> animation when the <paramref name="animationFrom"/> animation completes.</para>
    /// </summary>
    public void AnimationSetNext(StringName animationFrom, StringName animationTo)
    {
        NativeCalls.godot_icall_2_118(MethodBind0, GodotObject.GetPtr(this), (godot_string_name)(animationFrom?.NativeValue ?? default), (godot_string_name)(animationTo?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AnimationGetNext, 1965194235ul);

    /// <summary>
    /// <para>Returns the key of the animation which is queued to play after the <paramref name="animationFrom"/> animation.</para>
    /// </summary>
    public StringName AnimationGetNext(StringName animationFrom)
    {
        return NativeCalls.godot_icall_1_164(MethodBind1, GodotObject.GetPtr(this), (godot_string_name)(animationFrom?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBlendTime, 3231131886ul);

    /// <summary>
    /// <para>Specifies a blend time (in seconds) between two animations, referenced by their keys.</para>
    /// </summary>
    public void SetBlendTime(StringName animationFrom, StringName animationTo, double sec)
    {
        NativeCalls.godot_icall_3_165(MethodBind2, GodotObject.GetPtr(this), (godot_string_name)(animationFrom?.NativeValue ?? default), (godot_string_name)(animationTo?.NativeValue ?? default), sec);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBlendTime, 1958752504ul);

    /// <summary>
    /// <para>Returns the blend time (in seconds) between two animations, referenced by their keys.</para>
    /// </summary>
    public double GetBlendTime(StringName animationFrom, StringName animationTo)
    {
        return NativeCalls.godot_icall_2_166(MethodBind3, GodotObject.GetPtr(this), (godot_string_name)(animationFrom?.NativeValue ?? default), (godot_string_name)(animationTo?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDefaultBlendTime, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDefaultBlendTime(double sec)
    {
        NativeCalls.godot_icall_1_127(MethodBind4, GodotObject.GetPtr(this), sec);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDefaultBlendTime, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public double GetDefaultBlendTime()
    {
        return NativeCalls.godot_icall_0_144(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAutoCapture, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAutoCapture(bool autoCapture)
    {
        NativeCalls.godot_icall_1_14(MethodBind6, GodotObject.GetPtr(this), autoCapture.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsAutoCapture, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsAutoCapture()
    {
        return NativeCalls.godot_icall_0_15(MethodBind7, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAutoCaptureDuration, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAutoCaptureDuration(double autoCaptureDuration)
    {
        NativeCalls.godot_icall_1_127(MethodBind8, GodotObject.GetPtr(this), autoCaptureDuration);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAutoCaptureDuration, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public double GetAutoCaptureDuration()
    {
        return NativeCalls.godot_icall_0_144(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAutoCaptureTransitionType, 1058637742ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAutoCaptureTransitionType(Tween.TransitionType autoCaptureTransitionType)
    {
        NativeCalls.godot_icall_1_38(MethodBind10, GodotObject.GetPtr(this), (int)autoCaptureTransitionType);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAutoCaptureTransitionType, 3842314528ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Tween.TransitionType GetAutoCaptureTransitionType()
    {
        return (Tween.TransitionType)NativeCalls.godot_icall_0_39(MethodBind11, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAutoCaptureEaseType, 1208105857ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAutoCaptureEaseType(Tween.EaseType autoCaptureEaseType)
    {
        NativeCalls.godot_icall_1_38(MethodBind12, GodotObject.GetPtr(this), (int)autoCaptureEaseType);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAutoCaptureEaseType, 631880200ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Tween.EaseType GetAutoCaptureEaseType()
    {
        return (Tween.EaseType)NativeCalls.godot_icall_0_39(MethodBind13, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Play, 3118260607ul);

    /// <summary>
    /// <para>Plays the animation with key <paramref name="name"/>. Custom blend times and speed can be set.</para>
    /// <para>The <paramref name="fromEnd"/> option only affects when switching to a new animation track, or if the same track but at the start or end. It does not affect resuming playback that was paused in the middle of an animation. If <paramref name="customSpeed"/> is negative and <paramref name="fromEnd"/> is <see langword="true"/>, the animation will play backwards (which is equivalent to calling <see cref="Godot.AnimationPlayer.PlayBackwards(StringName, double)"/>).</para>
    /// <para>The <see cref="Godot.AnimationPlayer"/> keeps track of its current or last played animation with <see cref="Godot.AnimationPlayer.AssignedAnimation"/>. If this method is called with that same animation <paramref name="name"/>, or with no <paramref name="name"/> parameter, the assigned animation will resume playing if it was paused.</para>
    /// <para><b>Note:</b> The animation will be updated the next time the <see cref="Godot.AnimationPlayer"/> is processed. If other variables are updated at the same time this is called, they may be updated too early. To perform the update immediately, call <c>advance(0)</c>.</para>
    /// </summary>
    public void Play(StringName name = null, double customBlend = (double)(-1), float customSpeed = 1.0f, bool fromEnd = false)
    {
        NativeCalls.godot_icall_4_167(MethodBind14, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default), customBlend, customSpeed, fromEnd.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PlaySectionWithMarkers, 1421431412ul);

    /// <summary>
    /// <para>Plays the animation with key <paramref name="name"/> and the section starting from <paramref name="startMarker"/> and ending on <paramref name="endMarker"/>.</para>
    /// <para>If the start marker is empty, the section starts from the beginning of the animation. If the end marker is empty, the section ends on the end of the animation. See also <see cref="Godot.AnimationPlayer.Play(StringName, double, float, bool)"/>.</para>
    /// </summary>
    public void PlaySectionWithMarkers(StringName name = null, StringName startMarker = null, StringName endMarker = null, double customBlend = (double)(-1), float customSpeed = 1.0f, bool fromEnd = false)
    {
        NativeCalls.godot_icall_6_168(MethodBind15, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default), (godot_string_name)(startMarker?.NativeValue ?? default), (godot_string_name)(endMarker?.NativeValue ?? default), customBlend, customSpeed, fromEnd.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PlaySection, 284774635ul);

    /// <summary>
    /// <para>Plays the animation with key <paramref name="name"/> and the section starting from <paramref name="startTime"/> and ending on <paramref name="endTime"/>. See also <see cref="Godot.AnimationPlayer.Play(StringName, double, float, bool)"/>.</para>
    /// <para>Setting <paramref name="startTime"/> to a value outside the range of the animation means the start of the animation will be used instead, and setting <paramref name="endTime"/> to a value outside the range of the animation means the end of the animation will be used instead. <paramref name="startTime"/> cannot be equal to <paramref name="endTime"/>.</para>
    /// </summary>
    public void PlaySection(StringName name = null, double startTime = (double)(-1), double endTime = (double)(-1), double customBlend = (double)(-1), float customSpeed = 1.0f, bool fromEnd = false)
    {
        NativeCalls.godot_icall_6_169(MethodBind16, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default), startTime, endTime, customBlend, customSpeed, fromEnd.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PlayBackwards, 2787282401ul);

    /// <summary>
    /// <para>Plays the animation with key <paramref name="name"/> in reverse.</para>
    /// <para>This method is a shorthand for <see cref="Godot.AnimationPlayer.Play(StringName, double, float, bool)"/> with <c>custom_speed = -1.0</c> and <c>from_end = true</c>, so see its description for more information.</para>
    /// </summary>
    public void PlayBackwards(StringName name = null, double customBlend = (double)(-1))
    {
        NativeCalls.godot_icall_2_104(MethodBind17, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default), customBlend);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PlaySectionWithMarkersBackwards, 910195100ul);

    /// <summary>
    /// <para>Plays the animation with key <paramref name="name"/> and the section starting from <paramref name="startMarker"/> and ending on <paramref name="endMarker"/> in reverse.</para>
    /// <para>This method is a shorthand for <see cref="Godot.AnimationPlayer.PlaySectionWithMarkers(StringName, StringName, StringName, double, float, bool)"/> with <c>custom_speed = -1.0</c> and <c>from_end = true</c>, see its description for more information.</para>
    /// </summary>
    public void PlaySectionWithMarkersBackwards(StringName name = null, StringName startMarker = null, StringName endMarker = null, double customBlend = (double)(-1))
    {
        NativeCalls.godot_icall_4_170(MethodBind18, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default), (godot_string_name)(startMarker?.NativeValue ?? default), (godot_string_name)(endMarker?.NativeValue ?? default), customBlend);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PlaySectionBackwards, 831955981ul);

    /// <summary>
    /// <para>Plays the animation with key <paramref name="name"/> and the section starting from <paramref name="startTime"/> and ending on <paramref name="endTime"/> in reverse.</para>
    /// <para>This method is a shorthand for <see cref="Godot.AnimationPlayer.PlaySection(StringName, double, double, double, float, bool)"/> with <c>custom_speed = -1.0</c> and <c>from_end = true</c>, see its description for more information.</para>
    /// </summary>
    public void PlaySectionBackwards(StringName name = null, double startTime = (double)(-1), double endTime = (double)(-1), double customBlend = (double)(-1))
    {
        NativeCalls.godot_icall_4_171(MethodBind19, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default), startTime, endTime, customBlend);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PlayWithCapture, 1572969103ul);

    /// <summary>
    /// <para>See also <see cref="Godot.AnimationMixer.Capture(StringName, double, Tween.TransitionType, Tween.EaseType)"/>.</para>
    /// <para>You can use this method to use more detailed options for capture than those performed by <see cref="Godot.AnimationPlayer.PlaybackAutoCapture"/>. When <see cref="Godot.AnimationPlayer.PlaybackAutoCapture"/> is <see langword="false"/>, this method is almost the same as the following:</para>
    /// <para><code>
    /// capture(name, duration, trans_type, ease_type)
    /// play(name, custom_blend, custom_speed, from_end)
    /// </code></para>
    /// <para>If <paramref name="name"/> is blank, it specifies <see cref="Godot.AnimationPlayer.AssignedAnimation"/>.</para>
    /// <para>If <paramref name="duration"/> is a negative value, the duration is set to the interval between the current position and the first key, when <paramref name="fromEnd"/> is <see langword="true"/>, uses the interval between the current position and the last key instead.</para>
    /// <para><b>Note:</b> The <paramref name="duration"/> takes <see cref="Godot.AnimationPlayer.SpeedScale"/> into account, but <paramref name="customSpeed"/> does not, because the capture cache is interpolated with the blend result and the result may contain multiple animations.</para>
    /// </summary>
    public void PlayWithCapture(StringName name = null, double duration = -1.0, double customBlend = (double)(-1), float customSpeed = 1.0f, bool fromEnd = false, Tween.TransitionType transType = (Tween.TransitionType)(0), Tween.EaseType easeType = (Tween.EaseType)(0))
    {
        NativeCalls.godot_icall_7_172(MethodBind20, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default), duration, customBlend, customSpeed, fromEnd.ToGodotBool(), (int)transType, (int)easeType);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Pause, 3218959716ul);

    /// <summary>
    /// <para>Pauses the currently playing animation. The <see cref="Godot.AnimationPlayer.CurrentAnimationPosition"/> will be kept and calling <see cref="Godot.AnimationPlayer.Play(StringName, double, float, bool)"/> or <see cref="Godot.AnimationPlayer.PlayBackwards(StringName, double)"/> without arguments or with the same animation name as <see cref="Godot.AnimationPlayer.AssignedAnimation"/> will resume the animation.</para>
    /// <para>See also <see cref="Godot.AnimationPlayer.Stop(bool)"/>.</para>
    /// </summary>
    public void Pause()
    {
        NativeCalls.godot_icall_0_3(MethodBind21, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Stop, 107499316ul);

    /// <summary>
    /// <para>Stops the currently playing animation. The animation position is reset to <c>0</c> and the <c>custom_speed</c> is reset to <c>1.0</c>. See also <see cref="Godot.AnimationPlayer.Pause()"/>.</para>
    /// <para>If <paramref name="keepState"/> is <see langword="true"/>, the animation state is not updated visually.</para>
    /// <para><b>Note:</b> The method / audio / animation playback tracks will not be processed by this method.</para>
    /// </summary>
    public void Stop(bool keepState = false)
    {
        NativeCalls.godot_icall_1_14(MethodBind22, GodotObject.GetPtr(this), keepState.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsPlaying, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if an animation is currently playing (even if <see cref="Godot.AnimationPlayer.SpeedScale"/> and/or <c>custom_speed</c> are <c>0</c>).</para>
    /// </summary>
    public bool IsPlaying()
    {
        return NativeCalls.godot_icall_0_15(MethodBind23, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsAnimationActive, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the an animation is currently active. An animation is active if it was played by calling <see cref="Godot.AnimationPlayer.Play(StringName, double, float, bool)"/> and was not finished yet, or was stopped by calling <see cref="Godot.AnimationPlayer.Stop(bool)"/>.</para>
    /// <para>This can be used to check whether an animation is currently paused or stopped.</para>
    /// <para><code>
    /// var is_paused = not is_playing() and is_animation_active()
    /// var is_stopped = not is_playing() and not is_animation_active()
    /// </code></para>
    /// </summary>
    public bool IsAnimationActive()
    {
        return NativeCalls.godot_icall_0_15(MethodBind24, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCurrentAnimation, 3304788590ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCurrentAnimation(StringName animation)
    {
        NativeCalls.godot_icall_1_64(MethodBind25, GodotObject.GetPtr(this), (godot_string_name)(animation?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCurrentAnimation, 2002593661ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public StringName GetCurrentAnimation()
    {
        return NativeCalls.godot_icall_0_65(MethodBind26, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAssignedAnimation, 3304788590ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAssignedAnimation(StringName animation)
    {
        NativeCalls.godot_icall_1_64(MethodBind27, GodotObject.GetPtr(this), (godot_string_name)(animation?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAssignedAnimation, 2002593661ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public StringName GetAssignedAnimation()
    {
        return NativeCalls.godot_icall_0_65(MethodBind28, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Queue, 3304788590ul);

    /// <summary>
    /// <para>Queues an animation for playback once the current animation and all previously queued animations are done.</para>
    /// <para><b>Note:</b> If a looped animation is currently playing, the queued animation will never play unless the looped animation is stopped somehow.</para>
    /// </summary>
    public void Queue(StringName name)
    {
        NativeCalls.godot_icall_1_64(MethodBind29, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetQueue, 2915620761ul);

    /// <summary>
    /// <para>Returns a list of the animation keys that are currently queued to play.</para>
    /// </summary>
    public Godot.Collections.Array<StringName> GetQueue()
    {
        return new Godot.Collections.Array<StringName>(NativeCalls.godot_icall_0_120(MethodBind30, GodotObject.GetPtr(this)));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ClearQueue, 3218959716ul);

    /// <summary>
    /// <para>Clears all queued, unplayed animations.</para>
    /// </summary>
    public void ClearQueue()
    {
        NativeCalls.godot_icall_0_3(MethodBind31, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind32 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSpeedScale, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSpeedScale(float speed)
    {
        NativeCalls.godot_icall_1_67(MethodBind32, GodotObject.GetPtr(this), speed);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind33 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSpeedScale, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetSpeedScale()
    {
        return NativeCalls.godot_icall_0_68(MethodBind33, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind34 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPlayingSpeed, 1740695150ul);

    /// <summary>
    /// <para>Returns the actual playing speed of current animation or <c>0</c> if not playing. This speed is the <see cref="Godot.AnimationPlayer.SpeedScale"/> property multiplied by <c>custom_speed</c> argument specified when calling the <see cref="Godot.AnimationPlayer.Play(StringName, double, float, bool)"/> method.</para>
    /// <para>Returns a negative value if the current animation is playing backwards.</para>
    /// </summary>
    public float GetPlayingSpeed()
    {
        return NativeCalls.godot_icall_0_68(MethodBind34, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind35 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAutoplay, 3304788590ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAutoplay(StringName name)
    {
        NativeCalls.godot_icall_1_64(MethodBind35, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind36 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAutoplay, 2002593661ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public StringName GetAutoplay()
    {
        return NativeCalls.godot_icall_0_65(MethodBind36, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind37 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMovieQuitOnFinishEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMovieQuitOnFinishEnabled(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind37, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind38 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsMovieQuitOnFinishEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsMovieQuitOnFinishEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind38, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind39 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCurrentAnimationPosition, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public double GetCurrentAnimationPosition()
    {
        return NativeCalls.godot_icall_0_144(MethodBind39, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind40 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCurrentAnimationLength, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public double GetCurrentAnimationLength()
    {
        return NativeCalls.godot_icall_0_144(MethodBind40, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind41 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSectionWithMarkers, 794792241ul);

    /// <summary>
    /// <para>Changes the start and end markers of the section being played. The current playback position will be clamped within the new section. See also <see cref="Godot.AnimationPlayer.PlaySectionWithMarkers(StringName, StringName, StringName, double, float, bool)"/>.</para>
    /// <para>If the argument is empty, the section uses the beginning or end of the animation. If both are empty, it means that the section is not set.</para>
    /// </summary>
    public void SetSectionWithMarkers(StringName startMarker = null, StringName endMarker = null)
    {
        NativeCalls.godot_icall_2_118(MethodBind41, GodotObject.GetPtr(this), (godot_string_name)(startMarker?.NativeValue ?? default), (godot_string_name)(endMarker?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind42 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSection, 3749779719ul);

    /// <summary>
    /// <para>Changes the start and end times of the section being played. The current playback position will be clamped within the new section. See also <see cref="Godot.AnimationPlayer.PlaySection(StringName, double, double, double, float, bool)"/>.</para>
    /// </summary>
    public void SetSection(double startTime = (double)(-1), double endTime = (double)(-1))
    {
        NativeCalls.godot_icall_2_173(MethodBind42, GodotObject.GetPtr(this), startTime, endTime);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind43 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ResetSection, 3218959716ul);

    /// <summary>
    /// <para>Resets the current section. Does nothing if a section has not been set.</para>
    /// </summary>
    public void ResetSection()
    {
        NativeCalls.godot_icall_0_3(MethodBind43, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind44 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSectionStartTime, 1740695150ul);

    /// <summary>
    /// <para>Returns the start time of the section currently being played.</para>
    /// </summary>
    public double GetSectionStartTime()
    {
        return NativeCalls.godot_icall_0_144(MethodBind44, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind45 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSectionEndTime, 1740695150ul);

    /// <summary>
    /// <para>Returns the end time of the section currently being played.</para>
    /// </summary>
    public double GetSectionEndTime()
    {
        return NativeCalls.godot_icall_0_144(MethodBind45, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind46 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasSection, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if an animation is currently playing with a section.</para>
    /// </summary>
    public bool HasSection()
    {
        return NativeCalls.godot_icall_0_15(MethodBind46, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind47 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Seek, 1807872683ul);

    /// <summary>
    /// <para>Seeks the animation to the <paramref name="seconds"/> point in time (in seconds). If <paramref name="update"/> is <see langword="true"/>, the animation updates too, otherwise it updates at process time. Events between the current frame and <paramref name="seconds"/> are skipped.</para>
    /// <para>If <paramref name="updateOnly"/> is <see langword="true"/>, the method / audio / animation playback tracks will not be processed.</para>
    /// <para><b>Note:</b> Seeking to the end of the animation doesn't emit <see cref="Godot.AnimationMixer.AnimationFinished"/>. If you want to skip animation and emit the signal, use <see cref="Godot.AnimationMixer.Advance(double)"/>.</para>
    /// </summary>
    public void Seek(double seconds, bool update = false, bool updateOnly = false)
    {
        NativeCalls.godot_icall_3_174(MethodBind47, GodotObject.GetPtr(this), seconds, update.ToGodotBool(), updateOnly.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind48 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetProcessCallback, 1663839457ul);

    /// <summary>
    /// <para>Sets the process notification in which to update animations.</para>
    /// </summary>
    [Obsolete("Use 'Godot.AnimationMixer.CallbackModeProcess' instead.")]
    public void SetProcessCallback(AnimationPlayer.AnimationProcessCallback mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind48, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind49 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetProcessCallback, 4207496604ul);

    /// <summary>
    /// <para>Returns the process notification in which to update animations.</para>
    /// </summary>
    [Obsolete("Use 'Godot.AnimationMixer.CallbackModeProcess' instead.")]
    public AnimationPlayer.AnimationProcessCallback GetProcessCallback()
    {
        return (AnimationPlayer.AnimationProcessCallback)NativeCalls.godot_icall_0_39(MethodBind49, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind50 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMethodCallMode, 3413514846ul);

    /// <summary>
    /// <para>Sets the call mode used for "Call Method" tracks.</para>
    /// </summary>
    [Obsolete("Use 'Godot.AnimationMixer.CallbackModeMethod' instead.")]
    public void SetMethodCallMode(AnimationPlayer.AnimationMethodCallMode mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind50, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind51 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMethodCallMode, 3583380054ul);

    /// <summary>
    /// <para>Returns the call mode used for "Call Method" tracks.</para>
    /// </summary>
    [Obsolete("Use 'Godot.AnimationMixer.CallbackModeMethod' instead.")]
    public AnimationPlayer.AnimationMethodCallMode GetMethodCallMode()
    {
        return (AnimationPlayer.AnimationMethodCallMode)NativeCalls.godot_icall_0_39(MethodBind51, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind52 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRoot, 1348162250ul);

    /// <summary>
    /// <para>Sets the node which node path references will travel from.</para>
    /// </summary>
    [Obsolete("Use 'Godot.AnimationMixer.RootNode' instead.")]
    public void SetRoot(NodePath path)
    {
        NativeCalls.godot_icall_1_123(MethodBind52, GodotObject.GetPtr(this), (godot_node_path)(path?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind53 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRoot, 4075236667ul);

    /// <summary>
    /// <para>Returns the node which node path references will travel from.</para>
    /// </summary>
    [Obsolete("Use 'Godot.AnimationMixer.RootNode' instead.")]
    public NodePath GetRoot()
    {
        return NativeCalls.godot_icall_0_124(MethodBind53, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind54 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Seek, 2087892650ul);

    /// <summary>
    /// <para>Seeks the animation to the <paramref name="seconds"/> point in time (in seconds). If <paramref name="update"/> is <see langword="true"/>, the animation updates too, otherwise it updates at process time. Events between the current frame and <paramref name="seconds"/> are skipped.</para>
    /// <para>If <paramref name="updateOnly"/> is <see langword="true"/>, the method / audio / animation playback tracks will not be processed.</para>
    /// <para><b>Note:</b> Seeking to the end of the animation doesn't emit <see cref="Godot.AnimationMixer.AnimationFinished"/>. If you want to skip animation and emit the signal, use <see cref="Godot.AnimationMixer.Advance(double)"/>.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void Seek(double seconds, bool update)
    {
        NativeCalls.godot_icall_2_175(MethodBind54, GodotObject.GetPtr(this), seconds, update.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind55 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAutoplay, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAutoplay(string name)
    {
        NativeCalls.godot_icall_1_57(MethodBind55, GodotObject.GetPtr(this), name);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind56 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAssignedAnimation, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAssignedAnimation(string animation)
    {
        NativeCalls.godot_icall_1_57(MethodBind56, GodotObject.GetPtr(this), animation);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind57 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCurrentAnimation, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCurrentAnimation(string animation)
    {
        NativeCalls.godot_icall_1_57(MethodBind57, GodotObject.GetPtr(this), animation);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.AnimationPlayer.CurrentAnimationChanged"/> event of a <see cref="Godot.AnimationPlayer"/> class.
    /// </summary>
    public delegate void CurrentAnimationChangedEventHandler(StringName name);

    private static void CurrentAnimationChangedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((CurrentAnimationChangedEventHandler)delegateObj)(VariantUtils.ConvertTo<StringName>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when <see cref="Godot.AnimationPlayer.CurrentAnimation"/> changes.</para>
    /// </summary>
    public unsafe event CurrentAnimationChangedEventHandler CurrentAnimationChanged
    {
        add => Connect(SignalName.CurrentAnimationChanged, Callable.CreateWithUnsafeTrampoline(value, &CurrentAnimationChangedTrampoline));
        remove => Disconnect(SignalName.CurrentAnimationChanged, Callable.CreateWithUnsafeTrampoline(value, &CurrentAnimationChangedTrampoline));
    }

    protected void EmitSignalCurrentAnimationChanged(StringName name)
    {
        EmitSignal(SignalName.CurrentAnimationChanged, name);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.AnimationPlayer.AnimationChanged"/> event of a <see cref="Godot.AnimationPlayer"/> class.
    /// </summary>
    public delegate void AnimationChangedEventHandler(StringName oldName, StringName newName);

    private static void AnimationChangedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 2);
        ((AnimationChangedEventHandler)delegateObj)(VariantUtils.ConvertTo<StringName>(args[0]), VariantUtils.ConvertTo<StringName>(args[1]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when a queued animation plays after the previous animation finished. See also <see cref="Godot.AnimationPlayer.Queue(StringName)"/>.</para>
    /// <para><b>Note:</b> The signal is not emitted when the animation is changed via <see cref="Godot.AnimationPlayer.Play(StringName, double, float, bool)"/> or by an <see cref="Godot.AnimationTree"/>.</para>
    /// </summary>
    public unsafe event AnimationChangedEventHandler AnimationChanged
    {
        add => Connect(SignalName.AnimationChanged, Callable.CreateWithUnsafeTrampoline(value, &AnimationChangedTrampoline));
        remove => Disconnect(SignalName.AnimationChanged, Callable.CreateWithUnsafeTrampoline(value, &AnimationChangedTrampoline));
    }

    protected void EmitSignalAnimationChanged(StringName oldName, StringName newName)
    {
        EmitSignal(SignalName.AnimationChanged, oldName, newName);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_current_animation_changed = "CurrentAnimationChanged";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_animation_changed = "AnimationChanged";

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
        if (signal == SignalName.CurrentAnimationChanged)
        {
            if (HasGodotClassSignal(SignalProxyName_current_animation_changed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.AnimationChanged)
        {
            if (HasGodotClassSignal(SignalProxyName_animation_changed.NativeValue.DangerousSelfRef))
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
        /// Cached name for the 'current_animation' property.
        /// </summary>
        public static readonly StringName CurrentAnimation = "current_animation";
        /// <summary>
        /// Cached name for the 'assigned_animation' property.
        /// </summary>
        public static readonly StringName AssignedAnimation = "assigned_animation";
        /// <summary>
        /// Cached name for the 'autoplay' property.
        /// </summary>
        public static readonly StringName Autoplay = "autoplay";
        /// <summary>
        /// Cached name for the 'current_animation_length' property.
        /// </summary>
        public static readonly StringName CurrentAnimationLength = "current_animation_length";
        /// <summary>
        /// Cached name for the 'current_animation_position' property.
        /// </summary>
        public static readonly StringName CurrentAnimationPosition = "current_animation_position";
        /// <summary>
        /// Cached name for the 'playback_auto_capture' property.
        /// </summary>
        public static readonly StringName PlaybackAutoCapture = "playback_auto_capture";
        /// <summary>
        /// Cached name for the 'playback_auto_capture_duration' property.
        /// </summary>
        public static readonly StringName PlaybackAutoCaptureDuration = "playback_auto_capture_duration";
        /// <summary>
        /// Cached name for the 'playback_auto_capture_transition_type' property.
        /// </summary>
        public static readonly StringName PlaybackAutoCaptureTransitionType = "playback_auto_capture_transition_type";
        /// <summary>
        /// Cached name for the 'playback_auto_capture_ease_type' property.
        /// </summary>
        public static readonly StringName PlaybackAutoCaptureEaseType = "playback_auto_capture_ease_type";
        /// <summary>
        /// Cached name for the 'playback_default_blend_time' property.
        /// </summary>
        public static readonly StringName PlaybackDefaultBlendTime = "playback_default_blend_time";
        /// <summary>
        /// Cached name for the 'speed_scale' property.
        /// </summary>
        public static readonly StringName SpeedScale = "speed_scale";
        /// <summary>
        /// Cached name for the 'movie_quit_on_finish' property.
        /// </summary>
        public static readonly StringName MovieQuitOnFinish = "movie_quit_on_finish";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : AnimationMixer.MethodName
    {
        /// <summary>
        /// Cached name for the 'animation_set_next' method.
        /// </summary>
        public static readonly StringName AnimationSetNext = "animation_set_next";
        /// <summary>
        /// Cached name for the 'animation_get_next' method.
        /// </summary>
        public static readonly StringName AnimationGetNext = "animation_get_next";
        /// <summary>
        /// Cached name for the 'set_blend_time' method.
        /// </summary>
        public static readonly StringName SetBlendTime = "set_blend_time";
        /// <summary>
        /// Cached name for the 'get_blend_time' method.
        /// </summary>
        public static readonly StringName GetBlendTime = "get_blend_time";
        /// <summary>
        /// Cached name for the 'set_default_blend_time' method.
        /// </summary>
        public static readonly StringName SetDefaultBlendTime = "set_default_blend_time";
        /// <summary>
        /// Cached name for the 'get_default_blend_time' method.
        /// </summary>
        public static readonly StringName GetDefaultBlendTime = "get_default_blend_time";
        /// <summary>
        /// Cached name for the 'set_auto_capture' method.
        /// </summary>
        public static readonly StringName SetAutoCapture = "set_auto_capture";
        /// <summary>
        /// Cached name for the 'is_auto_capture' method.
        /// </summary>
        public static readonly StringName IsAutoCapture = "is_auto_capture";
        /// <summary>
        /// Cached name for the 'set_auto_capture_duration' method.
        /// </summary>
        public static readonly StringName SetAutoCaptureDuration = "set_auto_capture_duration";
        /// <summary>
        /// Cached name for the 'get_auto_capture_duration' method.
        /// </summary>
        public static readonly StringName GetAutoCaptureDuration = "get_auto_capture_duration";
        /// <summary>
        /// Cached name for the 'set_auto_capture_transition_type' method.
        /// </summary>
        public static readonly StringName SetAutoCaptureTransitionType = "set_auto_capture_transition_type";
        /// <summary>
        /// Cached name for the 'get_auto_capture_transition_type' method.
        /// </summary>
        public static readonly StringName GetAutoCaptureTransitionType = "get_auto_capture_transition_type";
        /// <summary>
        /// Cached name for the 'set_auto_capture_ease_type' method.
        /// </summary>
        public static readonly StringName SetAutoCaptureEaseType = "set_auto_capture_ease_type";
        /// <summary>
        /// Cached name for the 'get_auto_capture_ease_type' method.
        /// </summary>
        public static readonly StringName GetAutoCaptureEaseType = "get_auto_capture_ease_type";
        /// <summary>
        /// Cached name for the 'play' method.
        /// </summary>
        public static readonly StringName Play = "play";
        /// <summary>
        /// Cached name for the 'play_section_with_markers' method.
        /// </summary>
        public static readonly StringName PlaySectionWithMarkers = "play_section_with_markers";
        /// <summary>
        /// Cached name for the 'play_section' method.
        /// </summary>
        public static readonly StringName PlaySection = "play_section";
        /// <summary>
        /// Cached name for the 'play_backwards' method.
        /// </summary>
        public static readonly StringName PlayBackwards = "play_backwards";
        /// <summary>
        /// Cached name for the 'play_section_with_markers_backwards' method.
        /// </summary>
        public static readonly StringName PlaySectionWithMarkersBackwards = "play_section_with_markers_backwards";
        /// <summary>
        /// Cached name for the 'play_section_backwards' method.
        /// </summary>
        public static readonly StringName PlaySectionBackwards = "play_section_backwards";
        /// <summary>
        /// Cached name for the 'play_with_capture' method.
        /// </summary>
        public static readonly StringName PlayWithCapture = "play_with_capture";
        /// <summary>
        /// Cached name for the 'pause' method.
        /// </summary>
        public static readonly StringName Pause = "pause";
        /// <summary>
        /// Cached name for the 'stop' method.
        /// </summary>
        public static readonly StringName Stop = "stop";
        /// <summary>
        /// Cached name for the 'is_playing' method.
        /// </summary>
        public static readonly StringName IsPlaying = "is_playing";
        /// <summary>
        /// Cached name for the 'is_animation_active' method.
        /// </summary>
        public static readonly StringName IsAnimationActive = "is_animation_active";
        /// <summary>
        /// Cached name for the 'set_current_animation' method.
        /// </summary>
        public static readonly StringName SetCurrentAnimation = "set_current_animation";
        /// <summary>
        /// Cached name for the 'get_current_animation' method.
        /// </summary>
        public static readonly StringName GetCurrentAnimation = "get_current_animation";
        /// <summary>
        /// Cached name for the 'set_assigned_animation' method.
        /// </summary>
        public static readonly StringName SetAssignedAnimation = "set_assigned_animation";
        /// <summary>
        /// Cached name for the 'get_assigned_animation' method.
        /// </summary>
        public static readonly StringName GetAssignedAnimation = "get_assigned_animation";
        /// <summary>
        /// Cached name for the 'queue' method.
        /// </summary>
        public static readonly StringName Queue = "queue";
        /// <summary>
        /// Cached name for the 'get_queue' method.
        /// </summary>
        public static readonly StringName GetQueue = "get_queue";
        /// <summary>
        /// Cached name for the 'clear_queue' method.
        /// </summary>
        public static readonly StringName ClearQueue = "clear_queue";
        /// <summary>
        /// Cached name for the 'set_speed_scale' method.
        /// </summary>
        public static readonly StringName SetSpeedScale = "set_speed_scale";
        /// <summary>
        /// Cached name for the 'get_speed_scale' method.
        /// </summary>
        public static readonly StringName GetSpeedScale = "get_speed_scale";
        /// <summary>
        /// Cached name for the 'get_playing_speed' method.
        /// </summary>
        public static readonly StringName GetPlayingSpeed = "get_playing_speed";
        /// <summary>
        /// Cached name for the 'set_autoplay' method.
        /// </summary>
        public static readonly StringName SetAutoplay = "set_autoplay";
        /// <summary>
        /// Cached name for the 'get_autoplay' method.
        /// </summary>
        public static readonly StringName GetAutoplay = "get_autoplay";
        /// <summary>
        /// Cached name for the 'set_movie_quit_on_finish_enabled' method.
        /// </summary>
        public static readonly StringName SetMovieQuitOnFinishEnabled = "set_movie_quit_on_finish_enabled";
        /// <summary>
        /// Cached name for the 'is_movie_quit_on_finish_enabled' method.
        /// </summary>
        public static readonly StringName IsMovieQuitOnFinishEnabled = "is_movie_quit_on_finish_enabled";
        /// <summary>
        /// Cached name for the 'get_current_animation_position' method.
        /// </summary>
        public static readonly StringName GetCurrentAnimationPosition = "get_current_animation_position";
        /// <summary>
        /// Cached name for the 'get_current_animation_length' method.
        /// </summary>
        public static readonly StringName GetCurrentAnimationLength = "get_current_animation_length";
        /// <summary>
        /// Cached name for the 'set_section_with_markers' method.
        /// </summary>
        public static readonly StringName SetSectionWithMarkers = "set_section_with_markers";
        /// <summary>
        /// Cached name for the 'set_section' method.
        /// </summary>
        public static readonly StringName SetSection = "set_section";
        /// <summary>
        /// Cached name for the 'reset_section' method.
        /// </summary>
        public static readonly StringName ResetSection = "reset_section";
        /// <summary>
        /// Cached name for the 'get_section_start_time' method.
        /// </summary>
        public static readonly StringName GetSectionStartTime = "get_section_start_time";
        /// <summary>
        /// Cached name for the 'get_section_end_time' method.
        /// </summary>
        public static readonly StringName GetSectionEndTime = "get_section_end_time";
        /// <summary>
        /// Cached name for the 'has_section' method.
        /// </summary>
        public static readonly StringName HasSection = "has_section";
        /// <summary>
        /// Cached name for the 'seek' method.
        /// </summary>
        public static readonly StringName Seek = "seek";
        /// <summary>
        /// Cached name for the 'set_process_callback' method.
        /// </summary>
        public static readonly StringName SetProcessCallback = "set_process_callback";
        /// <summary>
        /// Cached name for the 'get_process_callback' method.
        /// </summary>
        public static readonly StringName GetProcessCallback = "get_process_callback";
        /// <summary>
        /// Cached name for the 'set_method_call_mode' method.
        /// </summary>
        public static readonly StringName SetMethodCallMode = "set_method_call_mode";
        /// <summary>
        /// Cached name for the 'get_method_call_mode' method.
        /// </summary>
        public static readonly StringName GetMethodCallMode = "get_method_call_mode";
        /// <summary>
        /// Cached name for the 'set_root' method.
        /// </summary>
        public static readonly StringName SetRoot = "set_root";
        /// <summary>
        /// Cached name for the 'get_root' method.
        /// </summary>
        public static readonly StringName GetRoot = "get_root";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : AnimationMixer.SignalName
    {
        /// <summary>
        /// Cached name for the 'current_animation_changed' signal.
        /// </summary>
        public static readonly StringName CurrentAnimationChanged = "current_animation_changed";
        /// <summary>
        /// Cached name for the 'animation_changed' signal.
        /// </summary>
        public static readonly StringName AnimationChanged = "animation_changed";
    }
}
