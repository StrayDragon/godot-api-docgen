namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>The <see cref="Godot.AudioStreamPlayer"/> node plays an audio stream non-positionally. It is ideal for user interfaces, menus, or background music.</para>
/// <para>To use this node, <see cref="Godot.AudioStreamPlayer.Stream"/> needs to be set to a valid <see cref="Godot.AudioStream"/> resource. Playing more than one sound at the same time is also supported, see <see cref="Godot.AudioStreamPlayer.MaxPolyphony"/>.</para>
/// <para>If you need to play audio at a specific position, use <see cref="Godot.AudioStreamPlayer2D"/> or <see cref="Godot.AudioStreamPlayer3D"/> instead.</para>
/// </summary>
public partial class AudioStreamPlayer : Node
{
    public enum MixTargetEnum : long
    {
        /// <summary>
        /// <para>The audio will be played only on the first channel. This is the default.</para>
        /// </summary>
        Stereo = 0,
        /// <summary>
        /// <para>The audio will be played on all surround channels.</para>
        /// </summary>
        Surround = 1,
        /// <summary>
        /// <para>The audio will be played on the second channel, which is usually the center.</para>
        /// </summary>
        Center = 2
    }

    /// <summary>
    /// <para>The <see cref="Godot.AudioStream"/> resource to be played. Setting this property stops all currently playing sounds. If left empty, the <see cref="Godot.AudioStreamPlayer"/> does not work.</para>
    /// </summary>
    public AudioStream Stream
    {
        get
        {
            return GetStream();
        }
        set
        {
            SetStream(value);
        }
    }

    /// <summary>
    /// <para>Volume of sound, in decibels. This is an offset of the <see cref="Godot.AudioStreamPlayer.Stream"/>'s volume.</para>
    /// <para><b>Note:</b> To convert between decibel and linear energy (like most volume sliders do), use <see cref="Godot.AudioStreamPlayer.VolumeLinear"/>, or <c>@GlobalScope.db_to_linear</c> and <c>@GlobalScope.linear_to_db</c>.</para>
    /// </summary>
    public float VolumeDb
    {
        get
        {
            return GetVolumeDb();
        }
        set
        {
            SetVolumeDb(value);
        }
    }

    /// <summary>
    /// <para>Volume of sound, as a linear value.</para>
    /// <para><b>Note:</b> This member modifies <see cref="Godot.AudioStreamPlayer.VolumeDb"/> for convenience. The returned value is equivalent to the result of <c>@GlobalScope.db_to_linear</c> on <see cref="Godot.AudioStreamPlayer.VolumeDb"/>. Setting this member is equivalent to setting <see cref="Godot.AudioStreamPlayer.VolumeDb"/> to the result of <c>@GlobalScope.linear_to_db</c> on a value.</para>
    /// </summary>
    public float VolumeLinear
    {
        get
        {
            return GetVolumeLinear();
        }
        set
        {
            SetVolumeLinear(value);
        }
    }

    /// <summary>
    /// <para>The audio's pitch and tempo, as a multiplier of the <see cref="Godot.AudioStreamPlayer.Stream"/>'s sample rate. A value of <c>2.0</c> doubles the audio's pitch, while a value of <c>0.5</c> halves the pitch.</para>
    /// </summary>
    public float PitchScale
    {
        get
        {
            return GetPitchScale();
        }
        set
        {
            SetPitchScale(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, this node is playing sounds. Setting this property has the same effect as <see cref="Godot.AudioStreamPlayer.Play(float)"/> and <see cref="Godot.AudioStreamPlayer.Stop()"/>.</para>
    /// </summary>
    public bool Playing
    {
        get
        {
            return IsPlaying();
        }
        set
        {
            SetPlaying(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, this node calls <see cref="Godot.AudioStreamPlayer.Play(float)"/> when entering the tree.</para>
    /// </summary>
    public bool Autoplay
    {
        get
        {
            return IsAutoplayEnabled();
        }
        set
        {
            SetAutoplay(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the sounds are paused. Setting <see cref="Godot.AudioStreamPlayer.StreamPaused"/> to <see langword="false"/> resumes all sounds.</para>
    /// <para><b>Note:</b> This property is automatically changed when exiting or entering the tree, or this node is paused (see <see cref="Godot.Node.ProcessMode"/>).</para>
    /// </summary>
    public bool StreamPaused
    {
        get
        {
            return GetStreamPaused();
        }
        set
        {
            SetStreamPaused(value);
        }
    }

    /// <summary>
    /// <para>The mix target channels. Has no effect when two speakers or less are detected (see <see cref="Godot.AudioServer.SpeakerMode"/>).</para>
    /// </summary>
    public AudioStreamPlayer.MixTargetEnum MixTarget
    {
        get
        {
            return GetMixTarget();
        }
        set
        {
            SetMixTarget(value);
        }
    }

    /// <summary>
    /// <para>The maximum number of sounds this node can play at the same time. Calling <see cref="Godot.AudioStreamPlayer.Play(float)"/> after this value is reached will cut off the oldest sounds.</para>
    /// </summary>
    public int MaxPolyphony
    {
        get
        {
            return GetMaxPolyphony();
        }
        set
        {
            SetMaxPolyphony(value);
        }
    }

    /// <summary>
    /// <para>The target bus name. All sounds from this node will be playing on this bus.</para>
    /// <para><b>Note:</b> At runtime, if no bus with the given name exists, all sounds will fall back on <c>"Master"</c>. See also <see cref="Godot.AudioServer.GetBusName(int)"/>.</para>
    /// </summary>
    public StringName Bus
    {
        get
        {
            return GetBus();
        }
        set
        {
            SetBus(value);
        }
    }

    /// <summary>
    /// <para>The playback type of the stream player. If set other than to the default value, it will force that playback type.</para>
    /// </summary>
    public AudioServer.PlaybackType PlaybackType
    {
        get
        {
            return GetPlaybackType();
        }
        set
        {
            SetPlaybackType(value);
        }
    }

    private static readonly System.Type CachedType = typeof(AudioStreamPlayer);

    private static readonly StringName NativeName = "AudioStreamPlayer";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public AudioStreamPlayer() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal AudioStreamPlayer(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal AudioStreamPlayer(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetStream, 2210767741ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetStream(AudioStream stream)
    {
        NativeCalls.godot_icall_1_56(MethodBind0, GodotObject.GetPtr(this), GodotObject.GetPtr(stream));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetStream, 160907539ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public AudioStream GetStream()
    {
        return (AudioStream)NativeCalls.godot_icall_0_63(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVolumeDb, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetVolumeDb(float volumeDb)
    {
        NativeCalls.godot_icall_1_67(MethodBind2, GodotObject.GetPtr(this), volumeDb);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVolumeDb, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetVolumeDb()
    {
        return NativeCalls.godot_icall_0_68(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVolumeLinear, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetVolumeLinear(float volumeLinear)
    {
        NativeCalls.godot_icall_1_67(MethodBind4, GodotObject.GetPtr(this), volumeLinear);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVolumeLinear, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetVolumeLinear()
    {
        return NativeCalls.godot_icall_0_68(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPitchScale, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPitchScale(float pitchScale)
    {
        NativeCalls.godot_icall_1_67(MethodBind6, GodotObject.GetPtr(this), pitchScale);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPitchScale, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetPitchScale()
    {
        return NativeCalls.godot_icall_0_68(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Play, 1958160172ul);

    /// <summary>
    /// <para>Plays a sound from the beginning, or the given <paramref name="fromPosition"/> in seconds.</para>
    /// </summary>
    public void Play(float fromPosition = 0.0f)
    {
        NativeCalls.godot_icall_1_67(MethodBind8, GodotObject.GetPtr(this), fromPosition);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Seek, 373806689ul);

    /// <summary>
    /// <para>Restarts all sounds to be played from the given <paramref name="toPosition"/>, in seconds. Does nothing if no sounds are playing.</para>
    /// </summary>
    public void Seek(float toPosition)
    {
        NativeCalls.godot_icall_1_67(MethodBind9, GodotObject.GetPtr(this), toPosition);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Stop, 3218959716ul);

    /// <summary>
    /// <para>Stops all sounds from this node.</para>
    /// </summary>
    public void Stop()
    {
        NativeCalls.godot_icall_0_3(MethodBind10, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsPlaying, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsPlaying()
    {
        return NativeCalls.godot_icall_0_15(MethodBind11, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPlaybackPosition, 191475506ul);

    /// <summary>
    /// <para>Returns the position in the <see cref="Godot.AudioStream"/> of the latest sound, in seconds. Returns <c>0.0</c> if no sounds are playing.</para>
    /// <para><b>Note:</b> The position is not always accurate, as the <see cref="Godot.AudioServer"/> does not mix audio every processed frame. To get more accurate results, add <see cref="Godot.AudioServer.GetTimeSinceLastMix()"/> to the returned position.</para>
    /// <para><b>Note:</b> This method always returns <c>0.0</c> if the <see cref="Godot.AudioStreamPlayer.Stream"/> is an <see cref="Godot.AudioStreamInteractive"/>, since it can have multiple clips playing at once.</para>
    /// </summary>
    public float GetPlaybackPosition()
    {
        return NativeCalls.godot_icall_0_68(MethodBind12, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBus, 3304788590ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetBus(StringName bus)
    {
        NativeCalls.godot_icall_1_64(MethodBind13, GodotObject.GetPtr(this), (godot_string_name)(bus?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBus, 2002593661ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public StringName GetBus()
    {
        return NativeCalls.godot_icall_0_65(MethodBind14, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAutoplay, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAutoplay(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind15, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsAutoplayEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsAutoplayEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind16, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMixTarget, 2300306138ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMixTarget(AudioStreamPlayer.MixTargetEnum mixTarget)
    {
        NativeCalls.godot_icall_1_38(MethodBind17, GodotObject.GetPtr(this), (int)mixTarget);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMixTarget, 172807476ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public AudioStreamPlayer.MixTargetEnum GetMixTarget()
    {
        return (AudioStreamPlayer.MixTargetEnum)NativeCalls.godot_icall_0_39(MethodBind18, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPlaying, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPlaying(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind19, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetStreamPaused, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetStreamPaused(bool pause)
    {
        NativeCalls.godot_icall_1_14(MethodBind20, GodotObject.GetPtr(this), pause.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetStreamPaused, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetStreamPaused()
    {
        return NativeCalls.godot_icall_0_15(MethodBind21, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMaxPolyphony, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMaxPolyphony(int maxPolyphony)
    {
        NativeCalls.godot_icall_1_38(MethodBind22, GodotObject.GetPtr(this), maxPolyphony);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMaxPolyphony, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetMaxPolyphony()
    {
        return NativeCalls.godot_icall_0_39(MethodBind23, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasStreamPlayback, 2240911060ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if any sound is active, even if <see cref="Godot.AudioStreamPlayer.StreamPaused"/> is set to <see langword="true"/>. See also <see cref="Godot.AudioStreamPlayer.Playing"/> and <see cref="Godot.AudioStreamPlayer.GetStreamPlayback()"/>.</para>
    /// </summary>
    public bool HasStreamPlayback()
    {
        return NativeCalls.godot_icall_0_15(MethodBind24, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetStreamPlayback, 210135309ul);

    /// <summary>
    /// <para>Returns the latest <see cref="Godot.AudioStreamPlayback"/> of this node, usually the most recently created by <see cref="Godot.AudioStreamPlayer.Play(float)"/>. If no sounds are playing, this method fails and returns an empty playback.</para>
    /// </summary>
    public AudioStreamPlayback GetStreamPlayback()
    {
        return (AudioStreamPlayback)NativeCalls.godot_icall_0_63(MethodBind25, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPlaybackType, 725473817ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPlaybackType(AudioServer.PlaybackType playbackType)
    {
        NativeCalls.godot_icall_1_38(MethodBind26, GodotObject.GetPtr(this), (int)playbackType);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPlaybackType, 4011264623ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public AudioServer.PlaybackType GetPlaybackType()
    {
        return (AudioServer.PlaybackType)NativeCalls.godot_icall_0_39(MethodBind27, GodotObject.GetPtr(this));
    }

    /// <summary>
    /// <para>Emitted when a sound finishes playing without interruptions. This signal is <i>not</i> emitted when calling <see cref="Godot.AudioStreamPlayer.Stop()"/>, or when exiting the tree while sounds are playing.</para>
    /// </summary>
    public event Action Finished
    {
        add => Connect(SignalName.Finished, Callable.From(value));
        remove => Disconnect(SignalName.Finished, Callable.From(value));
    }

    protected void EmitSignalFinished()
    {
        EmitSignal(SignalName.Finished);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_finished = "Finished";

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
        if (signal == SignalName.Finished)
        {
            if (HasGodotClassSignal(SignalProxyName_finished.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        return base.HasGodotClassSignal(signal);
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : Node.PropertyName
    {
        /// <summary>
        /// Cached name for the 'stream' property.
        /// </summary>
        public static readonly StringName Stream = "stream";
        /// <summary>
        /// Cached name for the 'volume_db' property.
        /// </summary>
        public static readonly StringName VolumeDb = "volume_db";
        /// <summary>
        /// Cached name for the 'volume_linear' property.
        /// </summary>
        public static readonly StringName VolumeLinear = "volume_linear";
        /// <summary>
        /// Cached name for the 'pitch_scale' property.
        /// </summary>
        public static readonly StringName PitchScale = "pitch_scale";
        /// <summary>
        /// Cached name for the 'playing' property.
        /// </summary>
        public static readonly StringName Playing = "playing";
        /// <summary>
        /// Cached name for the 'autoplay' property.
        /// </summary>
        public static readonly StringName Autoplay = "autoplay";
        /// <summary>
        /// Cached name for the 'stream_paused' property.
        /// </summary>
        public static readonly StringName StreamPaused = "stream_paused";
        /// <summary>
        /// Cached name for the 'mix_target' property.
        /// </summary>
        public static readonly StringName MixTarget = "mix_target";
        /// <summary>
        /// Cached name for the 'max_polyphony' property.
        /// </summary>
        public static readonly StringName MaxPolyphony = "max_polyphony";
        /// <summary>
        /// Cached name for the 'bus' property.
        /// </summary>
        public static readonly StringName Bus = "bus";
        /// <summary>
        /// Cached name for the 'playback_type' property.
        /// </summary>
        public static readonly StringName PlaybackType = "playback_type";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Node.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_stream' method.
        /// </summary>
        public static readonly StringName SetStream = "set_stream";
        /// <summary>
        /// Cached name for the 'get_stream' method.
        /// </summary>
        public static readonly StringName GetStream = "get_stream";
        /// <summary>
        /// Cached name for the 'set_volume_db' method.
        /// </summary>
        public static readonly StringName SetVolumeDb = "set_volume_db";
        /// <summary>
        /// Cached name for the 'get_volume_db' method.
        /// </summary>
        public static readonly StringName GetVolumeDb = "get_volume_db";
        /// <summary>
        /// Cached name for the 'set_volume_linear' method.
        /// </summary>
        public static readonly StringName SetVolumeLinear = "set_volume_linear";
        /// <summary>
        /// Cached name for the 'get_volume_linear' method.
        /// </summary>
        public static readonly StringName GetVolumeLinear = "get_volume_linear";
        /// <summary>
        /// Cached name for the 'set_pitch_scale' method.
        /// </summary>
        public static readonly StringName SetPitchScale = "set_pitch_scale";
        /// <summary>
        /// Cached name for the 'get_pitch_scale' method.
        /// </summary>
        public static readonly StringName GetPitchScale = "get_pitch_scale";
        /// <summary>
        /// Cached name for the 'play' method.
        /// </summary>
        public static readonly StringName Play = "play";
        /// <summary>
        /// Cached name for the 'seek' method.
        /// </summary>
        public static readonly StringName Seek = "seek";
        /// <summary>
        /// Cached name for the 'stop' method.
        /// </summary>
        public static readonly StringName Stop = "stop";
        /// <summary>
        /// Cached name for the 'is_playing' method.
        /// </summary>
        public static readonly StringName IsPlaying = "is_playing";
        /// <summary>
        /// Cached name for the 'get_playback_position' method.
        /// </summary>
        public static readonly StringName GetPlaybackPosition = "get_playback_position";
        /// <summary>
        /// Cached name for the 'set_bus' method.
        /// </summary>
        public static readonly StringName SetBus = "set_bus";
        /// <summary>
        /// Cached name for the 'get_bus' method.
        /// </summary>
        public static readonly StringName GetBus = "get_bus";
        /// <summary>
        /// Cached name for the 'set_autoplay' method.
        /// </summary>
        public static readonly StringName SetAutoplay = "set_autoplay";
        /// <summary>
        /// Cached name for the 'is_autoplay_enabled' method.
        /// </summary>
        public static readonly StringName IsAutoplayEnabled = "is_autoplay_enabled";
        /// <summary>
        /// Cached name for the 'set_mix_target' method.
        /// </summary>
        public static readonly StringName SetMixTarget = "set_mix_target";
        /// <summary>
        /// Cached name for the 'get_mix_target' method.
        /// </summary>
        public static readonly StringName GetMixTarget = "get_mix_target";
        /// <summary>
        /// Cached name for the 'set_playing' method.
        /// </summary>
        public static readonly StringName SetPlaying = "set_playing";
        /// <summary>
        /// Cached name for the 'set_stream_paused' method.
        /// </summary>
        public static readonly StringName SetStreamPaused = "set_stream_paused";
        /// <summary>
        /// Cached name for the 'get_stream_paused' method.
        /// </summary>
        public static readonly StringName GetStreamPaused = "get_stream_paused";
        /// <summary>
        /// Cached name for the 'set_max_polyphony' method.
        /// </summary>
        public static readonly StringName SetMaxPolyphony = "set_max_polyphony";
        /// <summary>
        /// Cached name for the 'get_max_polyphony' method.
        /// </summary>
        public static readonly StringName GetMaxPolyphony = "get_max_polyphony";
        /// <summary>
        /// Cached name for the 'has_stream_playback' method.
        /// </summary>
        public static readonly StringName HasStreamPlayback = "has_stream_playback";
        /// <summary>
        /// Cached name for the 'get_stream_playback' method.
        /// </summary>
        public static readonly StringName GetStreamPlayback = "get_stream_playback";
        /// <summary>
        /// Cached name for the 'set_playback_type' method.
        /// </summary>
        public static readonly StringName SetPlaybackType = "set_playback_type";
        /// <summary>
        /// Cached name for the 'get_playback_type' method.
        /// </summary>
        public static readonly StringName GetPlaybackType = "get_playback_type";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Node.SignalName
    {
        /// <summary>
        /// Cached name for the 'finished' signal.
        /// </summary>
        public static readonly StringName Finished = "finished";
    }
}
