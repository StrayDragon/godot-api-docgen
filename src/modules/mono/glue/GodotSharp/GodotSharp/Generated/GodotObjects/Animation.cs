namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This resource holds data that can be used to animate anything in the engine. Animations are divided into tracks and each track must be linked to a node. The state of that node can be changed through time, by adding timed keys (events) to the track.</para>
/// <para><code>
/// // This creates an animation that makes the node "Enemy" move to the right by
/// // 100 pixels in 2.0 seconds.
/// var animation = new Animation();
/// int trackIndex = animation.AddTrack(Animation.TrackType.Value);
/// animation.TrackSetPath(trackIndex, "Enemy:position:x");
/// animation.TrackInsertKey(trackIndex, 0.0f, 0);
/// animation.TrackInsertKey(trackIndex, 2.0f, 100);
/// animation.Length = 2.0f;
/// </code></para>
/// <para>Animations are just data containers, and must be added to nodes such as an <see cref="Godot.AnimationPlayer"/> to be played back. Animation tracks have different types, each with its own set of dedicated methods. Check <see cref="Godot.Animation.TrackType"/> to see available types.</para>
/// <para><b>Note:</b> For 3D position/rotation/scale, using the dedicated <see cref="Godot.Animation.TrackType.Position3D"/>, <see cref="Godot.Animation.TrackType.Rotation3D"/> and <see cref="Godot.Animation.TrackType.Scale3D"/> track types instead of <see cref="Godot.Animation.TrackType.Value"/> is recommended for performance reasons.</para>
/// </summary>
public partial class Animation : Resource
{
    public enum TrackType : long
    {
        /// <summary>
        /// <para>Value tracks set values in node properties, but only those which can be interpolated. For 3D position/rotation/scale, using the dedicated <see cref="Godot.Animation.TrackType.Position3D"/>, <see cref="Godot.Animation.TrackType.Rotation3D"/> and <see cref="Godot.Animation.TrackType.Scale3D"/> track types instead of <see cref="Godot.Animation.TrackType.Value"/> is recommended for performance reasons.</para>
        /// </summary>
        Value = 0,
        /// <summary>
        /// <para>3D position track (values are stored in <see cref="Godot.Vector3"/>s).</para>
        /// </summary>
        Position3D = 1,
        /// <summary>
        /// <para>3D rotation track (values are stored in <see cref="Godot.Quaternion"/>s).</para>
        /// </summary>
        Rotation3D = 2,
        /// <summary>
        /// <para>3D scale track (values are stored in <see cref="Godot.Vector3"/>s).</para>
        /// </summary>
        Scale3D = 3,
        /// <summary>
        /// <para>Blend shape track.</para>
        /// </summary>
        BlendShape = 4,
        /// <summary>
        /// <para>Method tracks call functions with given arguments per key.</para>
        /// </summary>
        Method = 5,
        /// <summary>
        /// <para>Bezier tracks are used to interpolate a value using custom curves. They can also be used to animate sub-properties of vectors and colors (e.g. alpha value of a <see cref="Godot.Color"/>).</para>
        /// </summary>
        Bezier = 6,
        /// <summary>
        /// <para>Audio tracks are used to play an audio stream with either type of <see cref="Godot.AudioStreamPlayer"/>. The stream can be trimmed and previewed in the animation.</para>
        /// </summary>
        Audio = 7,
        /// <summary>
        /// <para>Animation tracks play animations in other <see cref="Godot.AnimationPlayer"/> nodes.</para>
        /// </summary>
        Animation = 8
    }

    public enum InterpolationType : long
    {
        /// <summary>
        /// <para>No interpolation (nearest value).</para>
        /// </summary>
        Nearest = 0,
        /// <summary>
        /// <para>Linear interpolation.</para>
        /// </summary>
        Linear = 1,
        /// <summary>
        /// <para>Cubic interpolation. This looks smoother than linear interpolation, but is more expensive to interpolate. Stick to <see cref="Godot.Animation.InterpolationType.Linear"/> for complex 3D animations imported from external software, even if it requires using a higher animation framerate in return.</para>
        /// </summary>
        Cubic = 2,
        /// <summary>
        /// <para>Linear interpolation with shortest path rotation.</para>
        /// <para><b>Note:</b> The result value is always normalized and may not match the key value.</para>
        /// </summary>
        LinearAngle = 3,
        /// <summary>
        /// <para>Cubic interpolation with shortest path rotation.</para>
        /// <para><b>Note:</b> The result value is always normalized and may not match the key value.</para>
        /// </summary>
        CubicAngle = 4
    }

    public enum UpdateMode : long
    {
        /// <summary>
        /// <para>Update between keyframes and hold the value.</para>
        /// </summary>
        Continuous = 0,
        /// <summary>
        /// <para>Update at the keyframes.</para>
        /// </summary>
        Discrete = 1,
        /// <summary>
        /// <para>Same as <see cref="Godot.Animation.UpdateMode.Continuous"/> but works as a flag to capture the value of the current object and perform interpolation in some methods. See also <see cref="Godot.AnimationMixer.Capture(StringName, double, Tween.TransitionType, Tween.EaseType)"/>, <see cref="Godot.AnimationPlayer.PlaybackAutoCapture"/>, and <see cref="Godot.AnimationPlayer.PlayWithCapture(StringName, double, double, float, bool, Tween.TransitionType, Tween.EaseType)"/>.</para>
        /// </summary>
        Capture = 2
    }

    public enum LoopModeEnum : long
    {
        /// <summary>
        /// <para>At both ends of the animation, the animation will stop playing.</para>
        /// </summary>
        None = 0,
        /// <summary>
        /// <para>At both ends of the animation, the animation will be repeated without changing the playback direction.</para>
        /// </summary>
        Linear = 1,
        /// <summary>
        /// <para>Repeats playback and reverse playback at both ends of the animation.</para>
        /// </summary>
        Pingpong = 2
    }

    public enum LoopedFlag : long
    {
        /// <summary>
        /// <para>This flag indicates that the animation proceeds without any looping.</para>
        /// </summary>
        None = 0,
        /// <summary>
        /// <para>This flag indicates that the animation has reached the end of the animation and just after loop processed.</para>
        /// </summary>
        End = 1,
        /// <summary>
        /// <para>This flag indicates that the animation has reached the start of the animation and just after loop processed.</para>
        /// </summary>
        Start = 2
    }

    public enum FindMode : long
    {
        /// <summary>
        /// <para>Finds the nearest time key.</para>
        /// </summary>
        Nearest = 0,
        /// <summary>
        /// <para>Finds only the key with approximating the time.</para>
        /// </summary>
        Approx = 1,
        /// <summary>
        /// <para>Finds only the key with matching the time.</para>
        /// </summary>
        Exact = 2
    }

    /// <summary>
    /// <para>The total length of the animation (in seconds).</para>
    /// <para><b>Note:</b> Length is not delimited by the last key, as this one may be before or after the end to ensure correct interpolation and looping.</para>
    /// </summary>
    public float Length
    {
        get
        {
            return GetLength();
        }
        set
        {
            SetLength(value);
        }
    }

    /// <summary>
    /// <para>Determines the behavior of both ends of the animation timeline during animation playback. This indicates whether and how the animation should be restarted, and is also used to correctly interpolate animation cycles.</para>
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

    /// <summary>
    /// <para>The animation step value.</para>
    /// </summary>
    public float Step
    {
        get
        {
            return GetStep();
        }
        set
        {
            SetStep(value);
        }
    }

    /// <summary>
    /// <para>Returns <see langword="true"/> if the capture track is included. This is a cached readonly value for performance.</para>
    /// </summary>
    public bool CaptureIncluded
    {
        get
        {
            return IsCaptureIncluded();
        }
    }

    private static readonly System.Type CachedType = typeof(Animation);

    private static readonly StringName NativeName = "Animation";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public Animation() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal Animation(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal Animation(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddTrack, 3843682357ul);

    /// <summary>
    /// <para>Adds a track to the Animation.</para>
    /// </summary>
    public int AddTrack(Animation.TrackType type, int atPosition = -1)
    {
        return NativeCalls.godot_icall_2_73(MethodBind0, GodotObject.GetPtr(this), (int)type, atPosition);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveTrack, 1286410249ul);

    /// <summary>
    /// <para>Removes a track by specifying the track index.</para>
    /// </summary>
    public void RemoveTrack(int trackIdx)
    {
        NativeCalls.godot_icall_1_38(MethodBind1, GodotObject.GetPtr(this), trackIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTrackCount, 3905245786ul);

    /// <summary>
    /// <para>Returns the amount of tracks in the animation.</para>
    /// </summary>
    public int GetTrackCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.TrackGetType, 3445944217ul);

    /// <summary>
    /// <para>Gets the type of a track.</para>
    /// </summary>
    public Animation.TrackType TrackGetType(int trackIdx)
    {
        return (Animation.TrackType)NativeCalls.godot_icall_1_60(MethodBind3, GodotObject.GetPtr(this), trackIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.TrackGetPath, 408788394ul);

    /// <summary>
    /// <para>Gets the path of a track. For more information on the path format, see <see cref="Godot.Animation.TrackSetPath(int, NodePath)"/>.</para>
    /// </summary>
    public NodePath TrackGetPath(int trackIdx)
    {
        return NativeCalls.godot_icall_1_74(MethodBind4, GodotObject.GetPtr(this), trackIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.TrackSetPath, 2761262315ul);

    /// <summary>
    /// <para>Sets the path of a track. Paths must be valid scene-tree paths to a node and must be specified starting from the <see cref="Godot.AnimationMixer.RootNode"/> that will reproduce the animation. Tracks that control properties or bones must append their name after the path, separated by <c>":"</c>.</para>
    /// <para>For example, <c>"character/skeleton:ankle"</c> or <c>"character/mesh:transform/local"</c>.</para>
    /// </summary>
    public void TrackSetPath(int trackIdx, NodePath path)
    {
        NativeCalls.godot_icall_2_75(MethodBind5, GodotObject.GetPtr(this), trackIdx, (godot_node_path)(path?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FindTrack, 245376003ul);

    /// <summary>
    /// <para>Returns the index of the specified track. If the track is not found, return -1.</para>
    /// </summary>
    public int FindTrack(NodePath path, Animation.TrackType type)
    {
        return NativeCalls.godot_icall_2_76(MethodBind6, GodotObject.GetPtr(this), (godot_node_path)(path?.NativeValue ?? default), (int)type);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.TrackMoveUp, 1286410249ul);

    /// <summary>
    /// <para>Moves a track up.</para>
    /// </summary>
    public void TrackMoveUp(int trackIdx)
    {
        NativeCalls.godot_icall_1_38(MethodBind7, GodotObject.GetPtr(this), trackIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.TrackMoveDown, 1286410249ul);

    /// <summary>
    /// <para>Moves a track down.</para>
    /// </summary>
    public void TrackMoveDown(int trackIdx)
    {
        NativeCalls.godot_icall_1_38(MethodBind8, GodotObject.GetPtr(this), trackIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.TrackMoveTo, 3937882851ul);

    /// <summary>
    /// <para>Changes the index position of track <paramref name="trackIdx"/> to the one defined in <paramref name="toIdx"/>.</para>
    /// </summary>
    public void TrackMoveTo(int trackIdx, int toIdx)
    {
        NativeCalls.godot_icall_2_59(MethodBind9, GodotObject.GetPtr(this), trackIdx, toIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.TrackSwap, 3937882851ul);

    /// <summary>
    /// <para>Swaps the track <paramref name="trackIdx"/>'s index position with the track <paramref name="withIdx"/>.</para>
    /// </summary>
    public void TrackSwap(int trackIdx, int withIdx)
    {
        NativeCalls.godot_icall_2_59(MethodBind10, GodotObject.GetPtr(this), trackIdx, withIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.TrackSetImported, 300928843ul);

    /// <summary>
    /// <para>Sets the given track as imported or not.</para>
    /// </summary>
    public void TrackSetImported(int trackIdx, bool imported)
    {
        NativeCalls.godot_icall_2_61(MethodBind11, GodotObject.GetPtr(this), trackIdx, imported.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.TrackIsImported, 1116898809ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the given track is imported. Else, return <see langword="false"/>.</para>
    /// </summary>
    public bool TrackIsImported(int trackIdx)
    {
        return NativeCalls.godot_icall_1_62(MethodBind12, GodotObject.GetPtr(this), trackIdx).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.TrackSetEnabled, 300928843ul);

    /// <summary>
    /// <para>Enables/disables the given track. Tracks are enabled by default.</para>
    /// </summary>
    public void TrackSetEnabled(int trackIdx, bool enabled)
    {
        NativeCalls.godot_icall_2_61(MethodBind13, GodotObject.GetPtr(this), trackIdx, enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.TrackIsEnabled, 1116898809ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the track at index <paramref name="trackIdx"/> is enabled.</para>
    /// </summary>
    public bool TrackIsEnabled(int trackIdx)
    {
        return NativeCalls.godot_icall_1_62(MethodBind14, GodotObject.GetPtr(this), trackIdx).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PositionTrackInsertKey, 2540608232ul);

    /// <summary>
    /// <para>Inserts a key in a given 3D position track. Returns the key index.</para>
    /// </summary>
    public unsafe int PositionTrackInsertKey(int trackIdx, double time, Vector3 position)
    {
        return NativeCalls.godot_icall_3_77(MethodBind15, GodotObject.GetPtr(this), trackIdx, time, &position);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RotationTrackInsertKey, 4165004800ul);

    /// <summary>
    /// <para>Inserts a key in a given 3D rotation track. Returns the key index.</para>
    /// </summary>
    public unsafe int RotationTrackInsertKey(int trackIdx, double time, Quaternion rotation)
    {
        return NativeCalls.godot_icall_3_78(MethodBind16, GodotObject.GetPtr(this), trackIdx, time, &rotation);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ScaleTrackInsertKey, 2540608232ul);

    /// <summary>
    /// <para>Inserts a key in a given 3D scale track. Returns the key index.</para>
    /// </summary>
    public unsafe int ScaleTrackInsertKey(int trackIdx, double time, Vector3 scale)
    {
        return NativeCalls.godot_icall_3_77(MethodBind17, GodotObject.GetPtr(this), trackIdx, time, &scale);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BlendShapeTrackInsertKey, 1534913637ul);

    /// <summary>
    /// <para>Inserts a key in a given blend shape track. Returns the key index.</para>
    /// </summary>
    public int BlendShapeTrackInsertKey(int trackIdx, double time, float amount)
    {
        return NativeCalls.godot_icall_3_79(MethodBind18, GodotObject.GetPtr(this), trackIdx, time, amount);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PositionTrackInterpolate, 3530011197ul);

    /// <summary>
    /// <para>Returns the interpolated position value at the given time (in seconds). The <paramref name="trackIdx"/> must be the index of a 3D position track.</para>
    /// </summary>
    public Vector3 PositionTrackInterpolate(int trackIdx, double timeSec, bool backward = false)
    {
        return NativeCalls.godot_icall_3_80(MethodBind19, GodotObject.GetPtr(this), trackIdx, timeSec, backward.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RotationTrackInterpolate, 2915876792ul);

    /// <summary>
    /// <para>Returns the interpolated rotation value at the given time (in seconds). The <paramref name="trackIdx"/> must be the index of a 3D rotation track.</para>
    /// </summary>
    public Quaternion RotationTrackInterpolate(int trackIdx, double timeSec, bool backward = false)
    {
        return NativeCalls.godot_icall_3_81(MethodBind20, GodotObject.GetPtr(this), trackIdx, timeSec, backward.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ScaleTrackInterpolate, 3530011197ul);

    /// <summary>
    /// <para>Returns the interpolated scale value at the given time (in seconds). The <paramref name="trackIdx"/> must be the index of a 3D scale track.</para>
    /// </summary>
    public Vector3 ScaleTrackInterpolate(int trackIdx, double timeSec, bool backward = false)
    {
        return NativeCalls.godot_icall_3_80(MethodBind21, GodotObject.GetPtr(this), trackIdx, timeSec, backward.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BlendShapeTrackInterpolate, 2482365182ul);

    /// <summary>
    /// <para>Returns the interpolated blend shape value at the given time (in seconds). The <paramref name="trackIdx"/> must be the index of a blend shape track.</para>
    /// </summary>
    public float BlendShapeTrackInterpolate(int trackIdx, double timeSec, bool backward = false)
    {
        return NativeCalls.godot_icall_3_82(MethodBind22, GodotObject.GetPtr(this), trackIdx, timeSec, backward.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.TrackInsertKey, 808952278ul);

    /// <summary>
    /// <para>Inserts a generic key in a given track. Returns the key index.</para>
    /// </summary>
    public int TrackInsertKey(int trackIdx, double time, Variant key, float transition = (float)(1))
    {
        return NativeCalls.godot_icall_4_83(MethodBind23, GodotObject.GetPtr(this), trackIdx, time, key, transition);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.TrackRemoveKey, 3937882851ul);

    /// <summary>
    /// <para>Removes a key by index in a given track.</para>
    /// </summary>
    public void TrackRemoveKey(int trackIdx, int keyIdx)
    {
        NativeCalls.godot_icall_2_59(MethodBind24, GodotObject.GetPtr(this), trackIdx, keyIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.TrackRemoveKeyAtTime, 1602489585ul);

    /// <summary>
    /// <para>Removes a key at <paramref name="time"/> in a given track.</para>
    /// </summary>
    public void TrackRemoveKeyAtTime(int trackIdx, double time)
    {
        NativeCalls.godot_icall_2_84(MethodBind25, GodotObject.GetPtr(this), trackIdx, time);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.TrackSetKeyValue, 2060538656ul);

    /// <summary>
    /// <para>Sets the value of an existing key.</para>
    /// </summary>
    public void TrackSetKeyValue(int trackIdx, int key, Variant value)
    {
        NativeCalls.godot_icall_3_85(MethodBind26, GodotObject.GetPtr(this), trackIdx, key, value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.TrackSetKeyTransition, 3506521499ul);

    /// <summary>
    /// <para>Sets the transition curve (easing) for a specific key (see the built-in math function <c>@GlobalScope.ease</c>).</para>
    /// </summary>
    public void TrackSetKeyTransition(int trackIdx, int keyIdx, float transition)
    {
        NativeCalls.godot_icall_3_86(MethodBind27, GodotObject.GetPtr(this), trackIdx, keyIdx, transition);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName.TrackSetKeyTime, 3506521499ul);

    /// <summary>
    /// <para>Sets the time of an existing key.</para>
    /// </summary>
    public void TrackSetKeyTime(int trackIdx, int keyIdx, double time)
    {
        NativeCalls.godot_icall_3_87(MethodBind28, GodotObject.GetPtr(this), trackIdx, keyIdx, time);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = ClassDB_get_method_with_compatibility(NativeName, MethodName.TrackGetKeyTransition, 3085491603ul);

    /// <summary>
    /// <para>Returns the transition curve (easing) for a specific key (see the built-in math function <c>@GlobalScope.ease</c>).</para>
    /// </summary>
    public float TrackGetKeyTransition(int trackIdx, int keyIdx)
    {
        return NativeCalls.godot_icall_2_88(MethodBind29, GodotObject.GetPtr(this), trackIdx, keyIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = ClassDB_get_method_with_compatibility(NativeName, MethodName.TrackGetKeyCount, 923996154ul);

    /// <summary>
    /// <para>Returns the number of keys in a given track.</para>
    /// </summary>
    public int TrackGetKeyCount(int trackIdx)
    {
        return NativeCalls.godot_icall_1_60(MethodBind30, GodotObject.GetPtr(this), trackIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = ClassDB_get_method_with_compatibility(NativeName, MethodName.TrackGetKeyValue, 678354945ul);

    /// <summary>
    /// <para>Returns the value of a given key in a given track.</para>
    /// </summary>
    public Variant TrackGetKeyValue(int trackIdx, int keyIdx)
    {
        return NativeCalls.godot_icall_2_89(MethodBind31, GodotObject.GetPtr(this), trackIdx, keyIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind32 = ClassDB_get_method_with_compatibility(NativeName, MethodName.TrackGetKeyTime, 3085491603ul);

    /// <summary>
    /// <para>Returns the time at which the key is located.</para>
    /// </summary>
    public double TrackGetKeyTime(int trackIdx, int keyIdx)
    {
        return NativeCalls.godot_icall_2_90(MethodBind32, GodotObject.GetPtr(this), trackIdx, keyIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind33 = ClassDB_get_method_with_compatibility(NativeName, MethodName.TrackFindKey, 4230953007ul);

    /// <summary>
    /// <para>Finds the key index by time in a given track. Optionally, only find it if the approx/exact time is given.</para>
    /// <para>If <paramref name="limit"/> is <see langword="true"/>, it does not return keys outside the animation range.</para>
    /// <para>If <paramref name="backward"/> is <see langword="true"/>, the direction is reversed in methods that rely on one directional processing.</para>
    /// <para>For example, in case <paramref name="findMode"/> is <see cref="Godot.Animation.FindMode.Nearest"/>, if there is no key in the current position just after seeked, the first key found is retrieved by searching before the position, but if <paramref name="backward"/> is <see langword="true"/>, the first key found is retrieved after the position.</para>
    /// </summary>
    public int TrackFindKey(int trackIdx, double time, Animation.FindMode findMode = (Animation.FindMode)(0), bool limit = false, bool backward = false)
    {
        return NativeCalls.godot_icall_5_91(MethodBind33, GodotObject.GetPtr(this), trackIdx, time, (int)findMode, limit.ToGodotBool(), backward.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind34 = ClassDB_get_method_with_compatibility(NativeName, MethodName.TrackSetInterpolationType, 4112932513ul);

    /// <summary>
    /// <para>Sets the interpolation type of a given track.</para>
    /// </summary>
    public void TrackSetInterpolationType(int trackIdx, Animation.InterpolationType interpolation)
    {
        NativeCalls.godot_icall_2_59(MethodBind34, GodotObject.GetPtr(this), trackIdx, (int)interpolation);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind35 = ClassDB_get_method_with_compatibility(NativeName, MethodName.TrackGetInterpolationType, 1530756894ul);

    /// <summary>
    /// <para>Returns the interpolation type of a given track.</para>
    /// </summary>
    public Animation.InterpolationType TrackGetInterpolationType(int trackIdx)
    {
        return (Animation.InterpolationType)NativeCalls.godot_icall_1_60(MethodBind35, GodotObject.GetPtr(this), trackIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind36 = ClassDB_get_method_with_compatibility(NativeName, MethodName.TrackSetInterpolationLoopWrap, 300928843ul);

    /// <summary>
    /// <para>If <see langword="true"/>, the track at <paramref name="trackIdx"/> wraps the interpolation loop.</para>
    /// </summary>
    public void TrackSetInterpolationLoopWrap(int trackIdx, bool interpolation)
    {
        NativeCalls.godot_icall_2_61(MethodBind36, GodotObject.GetPtr(this), trackIdx, interpolation.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind37 = ClassDB_get_method_with_compatibility(NativeName, MethodName.TrackGetInterpolationLoopWrap, 1116898809ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the track at <paramref name="trackIdx"/> wraps the interpolation loop. New tracks wrap the interpolation loop by default.</para>
    /// </summary>
    public bool TrackGetInterpolationLoopWrap(int trackIdx)
    {
        return NativeCalls.godot_icall_1_62(MethodBind37, GodotObject.GetPtr(this), trackIdx).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind38 = ClassDB_get_method_with_compatibility(NativeName, MethodName.TrackIsCompressed, 1116898809ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the track is compressed, <see langword="false"/> otherwise. See also <see cref="Godot.Animation.Compress(uint, uint, float)"/>.</para>
    /// </summary>
    public bool TrackIsCompressed(int trackIdx)
    {
        return NativeCalls.godot_icall_1_62(MethodBind38, GodotObject.GetPtr(this), trackIdx).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind39 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ValueTrackSetUpdateMode, 2854058312ul);

    /// <summary>
    /// <para>Sets the update mode of a value track.</para>
    /// </summary>
    public void ValueTrackSetUpdateMode(int trackIdx, Animation.UpdateMode mode)
    {
        NativeCalls.godot_icall_2_59(MethodBind39, GodotObject.GetPtr(this), trackIdx, (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind40 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ValueTrackGetUpdateMode, 1440326473ul);

    /// <summary>
    /// <para>Returns the update mode of a value track.</para>
    /// </summary>
    public Animation.UpdateMode ValueTrackGetUpdateMode(int trackIdx)
    {
        return (Animation.UpdateMode)NativeCalls.godot_icall_1_60(MethodBind40, GodotObject.GetPtr(this), trackIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind41 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ValueTrackInterpolate, 747269075ul);

    /// <summary>
    /// <para>Returns the interpolated value at the given time (in seconds). The <paramref name="trackIdx"/> must be the index of a value track.</para>
    /// <para>A <paramref name="backward"/> mainly affects the direction of key retrieval of the track with <see cref="Godot.Animation.UpdateMode.Discrete"/> converted by <see cref="Godot.AnimationMixer.AnimationCallbackModeDiscrete.ForceContinuous"/> to match the result with <see cref="Godot.Animation.TrackFindKey(int, double, Animation.FindMode, bool, bool)"/>.</para>
    /// </summary>
    public Variant ValueTrackInterpolate(int trackIdx, double timeSec, bool backward = false)
    {
        return NativeCalls.godot_icall_3_92(MethodBind41, GodotObject.GetPtr(this), trackIdx, timeSec, backward.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind42 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MethodTrackGetName, 351665558ul);

    /// <summary>
    /// <para>Returns the method name of a method track.</para>
    /// </summary>
    public StringName MethodTrackGetName(int trackIdx, int keyIdx)
    {
        return NativeCalls.godot_icall_2_93(MethodBind42, GodotObject.GetPtr(this), trackIdx, keyIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind43 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MethodTrackGetParams, 2345056839ul);

    /// <summary>
    /// <para>Returns the arguments values to be called on a method track for a given key in a given track.</para>
    /// </summary>
    public Godot.Collections.Array MethodTrackGetParams(int trackIdx, int keyIdx)
    {
        return NativeCalls.godot_icall_2_94(MethodBind43, GodotObject.GetPtr(this), trackIdx, keyIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind44 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BezierTrackInsertKey, 3656773645ul);

    /// <summary>
    /// <para>Inserts a Bezier Track key at the given <paramref name="time"/> in seconds. The <paramref name="trackIdx"/> must be the index of a Bezier Track.</para>
    /// <para><paramref name="inHandle"/> is the left-side weight of the added Bezier curve point, <paramref name="outHandle"/> is the right-side one, while <paramref name="value"/> is the actual value at this point.</para>
    /// </summary>
    /// <param name="inHandle">If the parameter is null, then the default value is <c>new Vector2(0.0f, 0.0f)</c>.</param>
    /// <param name="outHandle">If the parameter is null, then the default value is <c>new Vector2(0.0f, 0.0f)</c>.</param>
    public unsafe int BezierTrackInsertKey(int trackIdx, double time, float value, Nullable<Vector2> inHandle = null, Nullable<Vector2> outHandle = null)
    {
        Vector2 inHandleOrDefVal = inHandle.HasValue ? inHandle.Value : new Vector2(0.0f, 0.0f);
        Vector2 outHandleOrDefVal = outHandle.HasValue ? outHandle.Value : new Vector2(0.0f, 0.0f);
        return NativeCalls.godot_icall_5_95(MethodBind44, GodotObject.GetPtr(this), trackIdx, time, value, &inHandleOrDefVal, &outHandleOrDefVal);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind45 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BezierTrackSetKeyValue, 3506521499ul);

    /// <summary>
    /// <para>Sets the value of the key identified by <paramref name="keyIdx"/> to the given value. The <paramref name="trackIdx"/> must be the index of a Bezier Track.</para>
    /// </summary>
    public void BezierTrackSetKeyValue(int trackIdx, int keyIdx, float value)
    {
        NativeCalls.godot_icall_3_86(MethodBind45, GodotObject.GetPtr(this), trackIdx, keyIdx, value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind46 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BezierTrackSetKeyInHandle, 1719223284ul);

    /// <summary>
    /// <para>Sets the in handle of the key identified by <paramref name="keyIdx"/> to value <paramref name="inHandle"/>. The <paramref name="trackIdx"/> must be the index of a Bezier Track.</para>
    /// </summary>
    public unsafe void BezierTrackSetKeyInHandle(int trackIdx, int keyIdx, Vector2 inHandle, float balancedValueTimeRatio = 1.0f)
    {
        NativeCalls.godot_icall_4_96(MethodBind46, GodotObject.GetPtr(this), trackIdx, keyIdx, &inHandle, balancedValueTimeRatio);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind47 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BezierTrackSetKeyOutHandle, 1719223284ul);

    /// <summary>
    /// <para>Sets the out handle of the key identified by <paramref name="keyIdx"/> to value <paramref name="outHandle"/>. The <paramref name="trackIdx"/> must be the index of a Bezier Track.</para>
    /// </summary>
    public unsafe void BezierTrackSetKeyOutHandle(int trackIdx, int keyIdx, Vector2 outHandle, float balancedValueTimeRatio = 1.0f)
    {
        NativeCalls.godot_icall_4_96(MethodBind47, GodotObject.GetPtr(this), trackIdx, keyIdx, &outHandle, balancedValueTimeRatio);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind48 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BezierTrackGetKeyValue, 3085491603ul);

    /// <summary>
    /// <para>Returns the value of the key identified by <paramref name="keyIdx"/>. The <paramref name="trackIdx"/> must be the index of a Bezier Track.</para>
    /// </summary>
    public float BezierTrackGetKeyValue(int trackIdx, int keyIdx)
    {
        return NativeCalls.godot_icall_2_88(MethodBind48, GodotObject.GetPtr(this), trackIdx, keyIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind49 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BezierTrackGetKeyInHandle, 3016396712ul);

    /// <summary>
    /// <para>Returns the in handle of the key identified by <paramref name="keyIdx"/>. The <paramref name="trackIdx"/> must be the index of a Bezier Track.</para>
    /// </summary>
    public Vector2 BezierTrackGetKeyInHandle(int trackIdx, int keyIdx)
    {
        return NativeCalls.godot_icall_2_97(MethodBind49, GodotObject.GetPtr(this), trackIdx, keyIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind50 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BezierTrackGetKeyOutHandle, 3016396712ul);

    /// <summary>
    /// <para>Returns the out handle of the key identified by <paramref name="keyIdx"/>. The <paramref name="trackIdx"/> must be the index of a Bezier Track.</para>
    /// </summary>
    public Vector2 BezierTrackGetKeyOutHandle(int trackIdx, int keyIdx)
    {
        return NativeCalls.godot_icall_2_97(MethodBind50, GodotObject.GetPtr(this), trackIdx, keyIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind51 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BezierTrackInterpolate, 1900462983ul);

    /// <summary>
    /// <para>Returns the interpolated value at the given <paramref name="time"/> (in seconds). The <paramref name="trackIdx"/> must be the index of a Bezier Track.</para>
    /// </summary>
    public float BezierTrackInterpolate(int trackIdx, double time)
    {
        return NativeCalls.godot_icall_2_98(MethodBind51, GodotObject.GetPtr(this), trackIdx, time);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind52 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AudioTrackInsertKey, 4021027286ul);

    /// <summary>
    /// <para>Inserts an Audio Track key at the given <paramref name="time"/> in seconds. The <paramref name="trackIdx"/> must be the index of an Audio Track.</para>
    /// <para><paramref name="stream"/> is the <see cref="Godot.AudioStream"/> resource to play. <paramref name="startOffset"/> is the number of seconds cut off at the beginning of the audio stream, while <paramref name="endOffset"/> is at the ending.</para>
    /// </summary>
    public int AudioTrackInsertKey(int trackIdx, double time, Resource stream, float startOffset = (float)(0), float endOffset = (float)(0))
    {
        return NativeCalls.godot_icall_5_99(MethodBind52, GodotObject.GetPtr(this), trackIdx, time, GodotObject.GetPtr(stream), startOffset, endOffset);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind53 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AudioTrackSetKeyStream, 3886397084ul);

    /// <summary>
    /// <para>Sets the stream of the key identified by <paramref name="keyIdx"/> to value <paramref name="stream"/>. The <paramref name="trackIdx"/> must be the index of an Audio Track.</para>
    /// </summary>
    public void AudioTrackSetKeyStream(int trackIdx, int keyIdx, Resource stream)
    {
        NativeCalls.godot_icall_3_100(MethodBind53, GodotObject.GetPtr(this), trackIdx, keyIdx, GodotObject.GetPtr(stream));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind54 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AudioTrackSetKeyStartOffset, 3506521499ul);

    /// <summary>
    /// <para>Sets the start offset of the key identified by <paramref name="keyIdx"/> to value <paramref name="offset"/>. The <paramref name="trackIdx"/> must be the index of an Audio Track.</para>
    /// </summary>
    public void AudioTrackSetKeyStartOffset(int trackIdx, int keyIdx, float offset)
    {
        NativeCalls.godot_icall_3_86(MethodBind54, GodotObject.GetPtr(this), trackIdx, keyIdx, offset);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind55 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AudioTrackSetKeyEndOffset, 3506521499ul);

    /// <summary>
    /// <para>Sets the end offset of the key identified by <paramref name="keyIdx"/> to value <paramref name="offset"/>. The <paramref name="trackIdx"/> must be the index of an Audio Track.</para>
    /// </summary>
    public void AudioTrackSetKeyEndOffset(int trackIdx, int keyIdx, float offset)
    {
        NativeCalls.godot_icall_3_86(MethodBind55, GodotObject.GetPtr(this), trackIdx, keyIdx, offset);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind56 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AudioTrackGetKeyStream, 635277205ul);

    /// <summary>
    /// <para>Returns the audio stream of the key identified by <paramref name="keyIdx"/>. The <paramref name="trackIdx"/> must be the index of an Audio Track.</para>
    /// </summary>
    public Resource AudioTrackGetKeyStream(int trackIdx, int keyIdx)
    {
        return (Resource)NativeCalls.godot_icall_2_101(MethodBind56, GodotObject.GetPtr(this), trackIdx, keyIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind57 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AudioTrackGetKeyStartOffset, 3085491603ul);

    /// <summary>
    /// <para>Returns the start offset of the key identified by <paramref name="keyIdx"/>. The <paramref name="trackIdx"/> must be the index of an Audio Track.</para>
    /// <para>Start offset is the number of seconds cut off at the beginning of the audio stream.</para>
    /// </summary>
    public float AudioTrackGetKeyStartOffset(int trackIdx, int keyIdx)
    {
        return NativeCalls.godot_icall_2_88(MethodBind57, GodotObject.GetPtr(this), trackIdx, keyIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind58 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AudioTrackGetKeyEndOffset, 3085491603ul);

    /// <summary>
    /// <para>Returns the end offset of the key identified by <paramref name="keyIdx"/>. The <paramref name="trackIdx"/> must be the index of an Audio Track.</para>
    /// <para>End offset is the number of seconds cut off at the ending of the audio stream.</para>
    /// </summary>
    public float AudioTrackGetKeyEndOffset(int trackIdx, int keyIdx)
    {
        return NativeCalls.godot_icall_2_88(MethodBind58, GodotObject.GetPtr(this), trackIdx, keyIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind59 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AudioTrackSetUseBlend, 300928843ul);

    /// <summary>
    /// <para>Sets whether the track will be blended with other animations. If <see langword="true"/>, the audio playback volume changes depending on the blend value.</para>
    /// </summary>
    public void AudioTrackSetUseBlend(int trackIdx, bool enable)
    {
        NativeCalls.godot_icall_2_61(MethodBind59, GodotObject.GetPtr(this), trackIdx, enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind60 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AudioTrackIsUseBlend, 1116898809ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the track at <paramref name="trackIdx"/> will be blended with other animations.</para>
    /// </summary>
    public bool AudioTrackIsUseBlend(int trackIdx)
    {
        return NativeCalls.godot_icall_1_62(MethodBind60, GodotObject.GetPtr(this), trackIdx).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind61 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AnimationTrackInsertKey, 158676774ul);

    /// <summary>
    /// <para>Inserts a key with value <paramref name="animation"/> at the given <paramref name="time"/> (in seconds). The <paramref name="trackIdx"/> must be the index of an Animation Track.</para>
    /// </summary>
    public int AnimationTrackInsertKey(int trackIdx, double time, StringName animation)
    {
        return NativeCalls.godot_icall_3_102(MethodBind61, GodotObject.GetPtr(this), trackIdx, time, (godot_string_name)(animation?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind62 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AnimationTrackSetKeyAnimation, 117615382ul);

    /// <summary>
    /// <para>Sets the key identified by <paramref name="keyIdx"/> to value <paramref name="animation"/>. The <paramref name="trackIdx"/> must be the index of an Animation Track.</para>
    /// </summary>
    public void AnimationTrackSetKeyAnimation(int trackIdx, int keyIdx, StringName animation)
    {
        NativeCalls.godot_icall_3_103(MethodBind62, GodotObject.GetPtr(this), trackIdx, keyIdx, (godot_string_name)(animation?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind63 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AnimationTrackGetKeyAnimation, 351665558ul);

    /// <summary>
    /// <para>Returns the animation name at the key identified by <paramref name="keyIdx"/>. The <paramref name="trackIdx"/> must be the index of an Animation Track.</para>
    /// </summary>
    public StringName AnimationTrackGetKeyAnimation(int trackIdx, int keyIdx)
    {
        return NativeCalls.godot_icall_2_93(MethodBind63, GodotObject.GetPtr(this), trackIdx, keyIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind64 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddMarker, 4135858297ul);

    /// <summary>
    /// <para>Adds a marker to this Animation.</para>
    /// </summary>
    public void AddMarker(StringName name, double time)
    {
        NativeCalls.godot_icall_2_104(MethodBind64, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default), time);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind65 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveMarker, 3304788590ul);

    /// <summary>
    /// <para>Removes the marker with the given name from this Animation.</para>
    /// </summary>
    public void RemoveMarker(StringName name)
    {
        NativeCalls.godot_icall_1_64(MethodBind65, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind66 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasMarker, 2619796661ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if this Animation contains a marker with the given name.</para>
    /// </summary>
    public bool HasMarker(StringName name)
    {
        return NativeCalls.godot_icall_1_105(MethodBind66, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind67 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMarkerAtTime, 4079494655ul);

    /// <summary>
    /// <para>Returns the name of the marker located at the given time.</para>
    /// </summary>
    public StringName GetMarkerAtTime(double time)
    {
        return NativeCalls.godot_icall_1_106(MethodBind67, GodotObject.GetPtr(this), time);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind68 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNextMarker, 4079494655ul);

    /// <summary>
    /// <para>Returns the closest marker that comes after the given time. If no such marker exists, an empty string is returned.</para>
    /// </summary>
    public StringName GetNextMarker(double time)
    {
        return NativeCalls.godot_icall_1_106(MethodBind68, GodotObject.GetPtr(this), time);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind69 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPrevMarker, 4079494655ul);

    /// <summary>
    /// <para>Returns the closest marker that comes before the given time. If no such marker exists, an empty string is returned.</para>
    /// </summary>
    public StringName GetPrevMarker(double time)
    {
        return NativeCalls.godot_icall_1_106(MethodBind69, GodotObject.GetPtr(this), time);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind70 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMarkerTime, 2349060816ul);

    /// <summary>
    /// <para>Returns the given marker's time.</para>
    /// </summary>
    public double GetMarkerTime(StringName name)
    {
        return NativeCalls.godot_icall_1_107(MethodBind70, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind71 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMarkerNames, 1139954409ul);

    /// <summary>
    /// <para>Returns every marker in this Animation, sorted ascending by time.</para>
    /// </summary>
    public string[] GetMarkerNames()
    {
        return NativeCalls.godot_icall_0_108(MethodBind71, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind72 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMarkerColor, 3742943038ul);

    /// <summary>
    /// <para>Returns the given marker's color.</para>
    /// </summary>
    public Color GetMarkerColor(StringName name)
    {
        return NativeCalls.godot_icall_1_109(MethodBind72, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind73 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMarkerColor, 4260178595ul);

    /// <summary>
    /// <para>Sets the given marker's color.</para>
    /// </summary>
    public unsafe void SetMarkerColor(StringName name, Color color)
    {
        NativeCalls.godot_icall_2_110(MethodBind73, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default), &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind74 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLength, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetLength(float timeSec)
    {
        NativeCalls.godot_icall_1_67(MethodBind74, GodotObject.GetPtr(this), timeSec);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind75 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLength, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetLength()
    {
        return NativeCalls.godot_icall_0_68(MethodBind75, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind76 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLoopMode, 3155355575ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetLoopMode(Animation.LoopModeEnum loopMode)
    {
        NativeCalls.godot_icall_1_38(MethodBind76, GodotObject.GetPtr(this), (int)loopMode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind77 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLoopMode, 1988889481ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Animation.LoopModeEnum GetLoopMode()
    {
        return (Animation.LoopModeEnum)NativeCalls.godot_icall_0_39(MethodBind77, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind78 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetStep, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetStep(float sizeSec)
    {
        NativeCalls.godot_icall_1_67(MethodBind78, GodotObject.GetPtr(this), sizeSec);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind79 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetStep, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetStep()
    {
        return NativeCalls.godot_icall_0_68(MethodBind79, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind80 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Clear, 3218959716ul);

    /// <summary>
    /// <para>Clear the animation (clear all tracks and reset all).</para>
    /// </summary>
    public void Clear()
    {
        NativeCalls.godot_icall_0_3(MethodBind80, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind81 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CopyTrack, 148001024ul);

    /// <summary>
    /// <para>Adds a new track to <paramref name="toAnimation"/> that is a copy of the given track from this animation.</para>
    /// </summary>
    public void CopyTrack(int trackIdx, Animation toAnimation)
    {
        NativeCalls.godot_icall_2_70(MethodBind81, GodotObject.GetPtr(this), trackIdx, GodotObject.GetPtr(toAnimation));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind82 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Optimize, 3303583852ul);

    /// <summary>
    /// <para>Optimize the animation and all its tracks in-place. This will preserve only as many keys as are necessary to keep the animation within the specified bounds.</para>
    /// </summary>
    public void Optimize(float allowedVelocityErr = 0.01f, float allowedAngularErr = 0.01f, int precision = 3)
    {
        NativeCalls.godot_icall_3_111(MethodBind82, GodotObject.GetPtr(this), allowedVelocityErr, allowedAngularErr, precision);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind83 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Compress, 3608408117ul);

    /// <summary>
    /// <para>Compress the animation and all its tracks in-place. This will make <see cref="Godot.Animation.TrackIsCompressed(int)"/> return <see langword="true"/> once called on this <see cref="Godot.Animation"/>. Compressed tracks require less memory to be played, and are designed to be used for complex 3D animations (such as cutscenes) imported from external 3D software. Compression is lossy, but the difference is usually not noticeable in real world conditions.</para>
    /// <para><b>Note:</b> Compressed tracks have various limitations (such as not being editable from the editor), so only use compressed animations if you actually need them.</para>
    /// </summary>
    public void Compress(uint pageSize = (uint)(8192), uint fps = (uint)(120), float splitTolerance = 4.0f)
    {
        NativeCalls.godot_icall_3_112(MethodBind83, GodotObject.GetPtr(this), pageSize, fps, splitTolerance);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind84 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsCaptureIncluded, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsCaptureIncluded()
    {
        return NativeCalls.godot_icall_0_15(MethodBind84, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind85 = ClassDB_get_method_with_compatibility(NativeName, MethodName.TrackFindKey, 3245197284ul);

    /// <summary>
    /// <para>Finds the key index by time in a given track. Optionally, only find it if the approx/exact time is given.</para>
    /// <para>If <paramref name="limit"/> is <see langword="true"/>, it does not return keys outside the animation range.</para>
    /// <para>If <paramref name="backward"/> is <see langword="true"/>, the direction is reversed in methods that rely on one directional processing.</para>
    /// <para>For example, in case <paramref name="findMode"/> is <see cref="Godot.Animation.FindMode.Nearest"/>, if there is no key in the current position just after seeked, the first key found is retrieved by searching before the position, but if <paramref name="backward"/> is <see langword="true"/>, the first key found is retrieved after the position.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int TrackFindKey(int trackIdx, double time, Animation.FindMode findMode)
    {
        return NativeCalls.godot_icall_3_113(MethodBind85, GodotObject.GetPtr(this), trackIdx, time, (int)findMode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind86 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ValueTrackInterpolate, 491147702ul);

    /// <summary>
    /// <para>Returns the interpolated value at the given time (in seconds). The <paramref name="trackIdx"/> must be the index of a value track.</para>
    /// <para>A <paramref name="backward"/> mainly affects the direction of key retrieval of the track with <see cref="Godot.Animation.UpdateMode.Discrete"/> converted by <see cref="Godot.AnimationMixer.AnimationCallbackModeDiscrete.ForceContinuous"/> to match the result with <see cref="Godot.Animation.TrackFindKey(int, double, Animation.FindMode, bool, bool)"/>.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public Variant ValueTrackInterpolate(int trackIdx, double timeSec)
    {
        return NativeCalls.godot_icall_2_114(MethodBind86, GodotObject.GetPtr(this), trackIdx, timeSec);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind87 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BlendShapeTrackInterpolate, 1900462983ul);

    /// <summary>
    /// <para>Returns the interpolated blend shape value at the given time (in seconds). The <paramref name="trackIdx"/> must be the index of a blend shape track.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public float BlendShapeTrackInterpolate(int trackIdx, double timeSec)
    {
        return NativeCalls.godot_icall_2_98(MethodBind87, GodotObject.GetPtr(this), trackIdx, timeSec);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind88 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ScaleTrackInterpolate, 3285246857ul);

    /// <summary>
    /// <para>Returns the interpolated scale value at the given time (in seconds). The <paramref name="trackIdx"/> must be the index of a 3D scale track.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector3 ScaleTrackInterpolate(int trackIdx, double timeSec)
    {
        return NativeCalls.godot_icall_2_115(MethodBind88, GodotObject.GetPtr(this), trackIdx, timeSec);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind89 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RotationTrackInterpolate, 1988711975ul);

    /// <summary>
    /// <para>Returns the interpolated rotation value at the given time (in seconds). The <paramref name="trackIdx"/> must be the index of a 3D rotation track.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public Quaternion RotationTrackInterpolate(int trackIdx, double timeSec)
    {
        return NativeCalls.godot_icall_2_116(MethodBind89, GodotObject.GetPtr(this), trackIdx, timeSec);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind90 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PositionTrackInterpolate, 3285246857ul);

    /// <summary>
    /// <para>Returns the interpolated position value at the given time (in seconds). The <paramref name="trackIdx"/> must be the index of a 3D position track.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector3 PositionTrackInterpolate(int trackIdx, double timeSec)
    {
        return NativeCalls.godot_icall_2_115(MethodBind90, GodotObject.GetPtr(this), trackIdx, timeSec);
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
        /// <summary>
        /// Cached name for the 'length' property.
        /// </summary>
        public static readonly StringName Length = "length";
        /// <summary>
        /// Cached name for the 'loop_mode' property.
        /// </summary>
        public static readonly StringName LoopMode = "loop_mode";
        /// <summary>
        /// Cached name for the 'step' property.
        /// </summary>
        public static readonly StringName Step = "step";
        /// <summary>
        /// Cached name for the 'capture_included' property.
        /// </summary>
        public static readonly StringName CaptureIncluded = "capture_included";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Resource.MethodName
    {
        /// <summary>
        /// Cached name for the 'add_track' method.
        /// </summary>
        public static readonly StringName AddTrack = "add_track";
        /// <summary>
        /// Cached name for the 'remove_track' method.
        /// </summary>
        public static readonly StringName RemoveTrack = "remove_track";
        /// <summary>
        /// Cached name for the 'get_track_count' method.
        /// </summary>
        public static readonly StringName GetTrackCount = "get_track_count";
        /// <summary>
        /// Cached name for the 'track_get_type' method.
        /// </summary>
        public static readonly StringName TrackGetType = "track_get_type";
        /// <summary>
        /// Cached name for the 'track_get_path' method.
        /// </summary>
        public static readonly StringName TrackGetPath = "track_get_path";
        /// <summary>
        /// Cached name for the 'track_set_path' method.
        /// </summary>
        public static readonly StringName TrackSetPath = "track_set_path";
        /// <summary>
        /// Cached name for the 'find_track' method.
        /// </summary>
        public static readonly StringName FindTrack = "find_track";
        /// <summary>
        /// Cached name for the 'track_move_up' method.
        /// </summary>
        public static readonly StringName TrackMoveUp = "track_move_up";
        /// <summary>
        /// Cached name for the 'track_move_down' method.
        /// </summary>
        public static readonly StringName TrackMoveDown = "track_move_down";
        /// <summary>
        /// Cached name for the 'track_move_to' method.
        /// </summary>
        public static readonly StringName TrackMoveTo = "track_move_to";
        /// <summary>
        /// Cached name for the 'track_swap' method.
        /// </summary>
        public static readonly StringName TrackSwap = "track_swap";
        /// <summary>
        /// Cached name for the 'track_set_imported' method.
        /// </summary>
        public static readonly StringName TrackSetImported = "track_set_imported";
        /// <summary>
        /// Cached name for the 'track_is_imported' method.
        /// </summary>
        public static readonly StringName TrackIsImported = "track_is_imported";
        /// <summary>
        /// Cached name for the 'track_set_enabled' method.
        /// </summary>
        public static readonly StringName TrackSetEnabled = "track_set_enabled";
        /// <summary>
        /// Cached name for the 'track_is_enabled' method.
        /// </summary>
        public static readonly StringName TrackIsEnabled = "track_is_enabled";
        /// <summary>
        /// Cached name for the 'position_track_insert_key' method.
        /// </summary>
        public static readonly StringName PositionTrackInsertKey = "position_track_insert_key";
        /// <summary>
        /// Cached name for the 'rotation_track_insert_key' method.
        /// </summary>
        public static readonly StringName RotationTrackInsertKey = "rotation_track_insert_key";
        /// <summary>
        /// Cached name for the 'scale_track_insert_key' method.
        /// </summary>
        public static readonly StringName ScaleTrackInsertKey = "scale_track_insert_key";
        /// <summary>
        /// Cached name for the 'blend_shape_track_insert_key' method.
        /// </summary>
        public static readonly StringName BlendShapeTrackInsertKey = "blend_shape_track_insert_key";
        /// <summary>
        /// Cached name for the 'position_track_interpolate' method.
        /// </summary>
        public static readonly StringName PositionTrackInterpolate = "position_track_interpolate";
        /// <summary>
        /// Cached name for the 'rotation_track_interpolate' method.
        /// </summary>
        public static readonly StringName RotationTrackInterpolate = "rotation_track_interpolate";
        /// <summary>
        /// Cached name for the 'scale_track_interpolate' method.
        /// </summary>
        public static readonly StringName ScaleTrackInterpolate = "scale_track_interpolate";
        /// <summary>
        /// Cached name for the 'blend_shape_track_interpolate' method.
        /// </summary>
        public static readonly StringName BlendShapeTrackInterpolate = "blend_shape_track_interpolate";
        /// <summary>
        /// Cached name for the 'track_insert_key' method.
        /// </summary>
        public static readonly StringName TrackInsertKey = "track_insert_key";
        /// <summary>
        /// Cached name for the 'track_remove_key' method.
        /// </summary>
        public static readonly StringName TrackRemoveKey = "track_remove_key";
        /// <summary>
        /// Cached name for the 'track_remove_key_at_time' method.
        /// </summary>
        public static readonly StringName TrackRemoveKeyAtTime = "track_remove_key_at_time";
        /// <summary>
        /// Cached name for the 'track_set_key_value' method.
        /// </summary>
        public static readonly StringName TrackSetKeyValue = "track_set_key_value";
        /// <summary>
        /// Cached name for the 'track_set_key_transition' method.
        /// </summary>
        public static readonly StringName TrackSetKeyTransition = "track_set_key_transition";
        /// <summary>
        /// Cached name for the 'track_set_key_time' method.
        /// </summary>
        public static readonly StringName TrackSetKeyTime = "track_set_key_time";
        /// <summary>
        /// Cached name for the 'track_get_key_transition' method.
        /// </summary>
        public static readonly StringName TrackGetKeyTransition = "track_get_key_transition";
        /// <summary>
        /// Cached name for the 'track_get_key_count' method.
        /// </summary>
        public static readonly StringName TrackGetKeyCount = "track_get_key_count";
        /// <summary>
        /// Cached name for the 'track_get_key_value' method.
        /// </summary>
        public static readonly StringName TrackGetKeyValue = "track_get_key_value";
        /// <summary>
        /// Cached name for the 'track_get_key_time' method.
        /// </summary>
        public static readonly StringName TrackGetKeyTime = "track_get_key_time";
        /// <summary>
        /// Cached name for the 'track_find_key' method.
        /// </summary>
        public static readonly StringName TrackFindKey = "track_find_key";
        /// <summary>
        /// Cached name for the 'track_set_interpolation_type' method.
        /// </summary>
        public static readonly StringName TrackSetInterpolationType = "track_set_interpolation_type";
        /// <summary>
        /// Cached name for the 'track_get_interpolation_type' method.
        /// </summary>
        public static readonly StringName TrackGetInterpolationType = "track_get_interpolation_type";
        /// <summary>
        /// Cached name for the 'track_set_interpolation_loop_wrap' method.
        /// </summary>
        public static readonly StringName TrackSetInterpolationLoopWrap = "track_set_interpolation_loop_wrap";
        /// <summary>
        /// Cached name for the 'track_get_interpolation_loop_wrap' method.
        /// </summary>
        public static readonly StringName TrackGetInterpolationLoopWrap = "track_get_interpolation_loop_wrap";
        /// <summary>
        /// Cached name for the 'track_is_compressed' method.
        /// </summary>
        public static readonly StringName TrackIsCompressed = "track_is_compressed";
        /// <summary>
        /// Cached name for the 'value_track_set_update_mode' method.
        /// </summary>
        public static readonly StringName ValueTrackSetUpdateMode = "value_track_set_update_mode";
        /// <summary>
        /// Cached name for the 'value_track_get_update_mode' method.
        /// </summary>
        public static readonly StringName ValueTrackGetUpdateMode = "value_track_get_update_mode";
        /// <summary>
        /// Cached name for the 'value_track_interpolate' method.
        /// </summary>
        public static readonly StringName ValueTrackInterpolate = "value_track_interpolate";
        /// <summary>
        /// Cached name for the 'method_track_get_name' method.
        /// </summary>
        public static readonly StringName MethodTrackGetName = "method_track_get_name";
        /// <summary>
        /// Cached name for the 'method_track_get_params' method.
        /// </summary>
        public static readonly StringName MethodTrackGetParams = "method_track_get_params";
        /// <summary>
        /// Cached name for the 'bezier_track_insert_key' method.
        /// </summary>
        public static readonly StringName BezierTrackInsertKey = "bezier_track_insert_key";
        /// <summary>
        /// Cached name for the 'bezier_track_set_key_value' method.
        /// </summary>
        public static readonly StringName BezierTrackSetKeyValue = "bezier_track_set_key_value";
        /// <summary>
        /// Cached name for the 'bezier_track_set_key_in_handle' method.
        /// </summary>
        public static readonly StringName BezierTrackSetKeyInHandle = "bezier_track_set_key_in_handle";
        /// <summary>
        /// Cached name for the 'bezier_track_set_key_out_handle' method.
        /// </summary>
        public static readonly StringName BezierTrackSetKeyOutHandle = "bezier_track_set_key_out_handle";
        /// <summary>
        /// Cached name for the 'bezier_track_get_key_value' method.
        /// </summary>
        public static readonly StringName BezierTrackGetKeyValue = "bezier_track_get_key_value";
        /// <summary>
        /// Cached name for the 'bezier_track_get_key_in_handle' method.
        /// </summary>
        public static readonly StringName BezierTrackGetKeyInHandle = "bezier_track_get_key_in_handle";
        /// <summary>
        /// Cached name for the 'bezier_track_get_key_out_handle' method.
        /// </summary>
        public static readonly StringName BezierTrackGetKeyOutHandle = "bezier_track_get_key_out_handle";
        /// <summary>
        /// Cached name for the 'bezier_track_interpolate' method.
        /// </summary>
        public static readonly StringName BezierTrackInterpolate = "bezier_track_interpolate";
        /// <summary>
        /// Cached name for the 'audio_track_insert_key' method.
        /// </summary>
        public static readonly StringName AudioTrackInsertKey = "audio_track_insert_key";
        /// <summary>
        /// Cached name for the 'audio_track_set_key_stream' method.
        /// </summary>
        public static readonly StringName AudioTrackSetKeyStream = "audio_track_set_key_stream";
        /// <summary>
        /// Cached name for the 'audio_track_set_key_start_offset' method.
        /// </summary>
        public static readonly StringName AudioTrackSetKeyStartOffset = "audio_track_set_key_start_offset";
        /// <summary>
        /// Cached name for the 'audio_track_set_key_end_offset' method.
        /// </summary>
        public static readonly StringName AudioTrackSetKeyEndOffset = "audio_track_set_key_end_offset";
        /// <summary>
        /// Cached name for the 'audio_track_get_key_stream' method.
        /// </summary>
        public static readonly StringName AudioTrackGetKeyStream = "audio_track_get_key_stream";
        /// <summary>
        /// Cached name for the 'audio_track_get_key_start_offset' method.
        /// </summary>
        public static readonly StringName AudioTrackGetKeyStartOffset = "audio_track_get_key_start_offset";
        /// <summary>
        /// Cached name for the 'audio_track_get_key_end_offset' method.
        /// </summary>
        public static readonly StringName AudioTrackGetKeyEndOffset = "audio_track_get_key_end_offset";
        /// <summary>
        /// Cached name for the 'audio_track_set_use_blend' method.
        /// </summary>
        public static readonly StringName AudioTrackSetUseBlend = "audio_track_set_use_blend";
        /// <summary>
        /// Cached name for the 'audio_track_is_use_blend' method.
        /// </summary>
        public static readonly StringName AudioTrackIsUseBlend = "audio_track_is_use_blend";
        /// <summary>
        /// Cached name for the 'animation_track_insert_key' method.
        /// </summary>
        public static readonly StringName AnimationTrackInsertKey = "animation_track_insert_key";
        /// <summary>
        /// Cached name for the 'animation_track_set_key_animation' method.
        /// </summary>
        public static readonly StringName AnimationTrackSetKeyAnimation = "animation_track_set_key_animation";
        /// <summary>
        /// Cached name for the 'animation_track_get_key_animation' method.
        /// </summary>
        public static readonly StringName AnimationTrackGetKeyAnimation = "animation_track_get_key_animation";
        /// <summary>
        /// Cached name for the 'add_marker' method.
        /// </summary>
        public static readonly StringName AddMarker = "add_marker";
        /// <summary>
        /// Cached name for the 'remove_marker' method.
        /// </summary>
        public static readonly StringName RemoveMarker = "remove_marker";
        /// <summary>
        /// Cached name for the 'has_marker' method.
        /// </summary>
        public static readonly StringName HasMarker = "has_marker";
        /// <summary>
        /// Cached name for the 'get_marker_at_time' method.
        /// </summary>
        public static readonly StringName GetMarkerAtTime = "get_marker_at_time";
        /// <summary>
        /// Cached name for the 'get_next_marker' method.
        /// </summary>
        public static readonly StringName GetNextMarker = "get_next_marker";
        /// <summary>
        /// Cached name for the 'get_prev_marker' method.
        /// </summary>
        public static readonly StringName GetPrevMarker = "get_prev_marker";
        /// <summary>
        /// Cached name for the 'get_marker_time' method.
        /// </summary>
        public static readonly StringName GetMarkerTime = "get_marker_time";
        /// <summary>
        /// Cached name for the 'get_marker_names' method.
        /// </summary>
        public static readonly StringName GetMarkerNames = "get_marker_names";
        /// <summary>
        /// Cached name for the 'get_marker_color' method.
        /// </summary>
        public static readonly StringName GetMarkerColor = "get_marker_color";
        /// <summary>
        /// Cached name for the 'set_marker_color' method.
        /// </summary>
        public static readonly StringName SetMarkerColor = "set_marker_color";
        /// <summary>
        /// Cached name for the 'set_length' method.
        /// </summary>
        public static readonly StringName SetLength = "set_length";
        /// <summary>
        /// Cached name for the 'get_length' method.
        /// </summary>
        public static readonly StringName GetLength = "get_length";
        /// <summary>
        /// Cached name for the 'set_loop_mode' method.
        /// </summary>
        public static readonly StringName SetLoopMode = "set_loop_mode";
        /// <summary>
        /// Cached name for the 'get_loop_mode' method.
        /// </summary>
        public static readonly StringName GetLoopMode = "get_loop_mode";
        /// <summary>
        /// Cached name for the 'set_step' method.
        /// </summary>
        public static readonly StringName SetStep = "set_step";
        /// <summary>
        /// Cached name for the 'get_step' method.
        /// </summary>
        public static readonly StringName GetStep = "get_step";
        /// <summary>
        /// Cached name for the 'clear' method.
        /// </summary>
        public static readonly StringName Clear = "clear";
        /// <summary>
        /// Cached name for the 'copy_track' method.
        /// </summary>
        public static readonly StringName CopyTrack = "copy_track";
        /// <summary>
        /// Cached name for the 'optimize' method.
        /// </summary>
        public static readonly StringName Optimize = "optimize";
        /// <summary>
        /// Cached name for the 'compress' method.
        /// </summary>
        public static readonly StringName Compress = "compress";
        /// <summary>
        /// Cached name for the 'is_capture_included' method.
        /// </summary>
        public static readonly StringName IsCaptureIncluded = "is_capture_included";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Resource.SignalName
    {
    }
}
