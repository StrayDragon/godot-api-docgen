namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Picks a random AudioStream from the pool, depending on the playback mode, and applies random pitch shifting and volume shifting during playback.</para>
/// </summary>
public partial class AudioStreamRandomizer : AudioStream
{
    public enum PlaybackModeEnum : long
    {
        /// <summary>
        /// <para>Pick a stream at random according to the probability weights chosen for each stream, but avoid playing the same stream twice in a row whenever possible. If only 1 sound is present in the pool, the same sound will always play, effectively allowing repeats to occur.</para>
        /// </summary>
        RandomNoRepeats = 0,
        /// <summary>
        /// <para>Pick a stream at random according to the probability weights chosen for each stream. If only 1 sound is present in the pool, the same sound will always play.</para>
        /// </summary>
        Random = 1,
        /// <summary>
        /// <para>Play streams in the order they appear in the stream pool. If only 1 sound is present in the pool, the same sound will always play.</para>
        /// </summary>
        Sequential = 2
    }

    /// <summary>
    /// <para>Controls how this AudioStreamRandomizer picks which AudioStream to play next.</para>
    /// </summary>
    public AudioStreamRandomizer.PlaybackModeEnum PlaybackMode
    {
        get
        {
            return GetPlaybackMode();
        }
        set
        {
            SetPlaybackMode(value);
        }
    }

    /// <summary>
    /// <para>The largest possible frequency multiplier of the random pitch variation. Pitch will be randomly chosen within a range of <c>1.0 / random_pitch</c> and <c>random_pitch</c>. A value of <c>1.0</c> means no variation. A value of <c>2.0</c> means pitch will be randomized between double and half.</para>
    /// <para><b>Note:</b> Setting this property also sets <see cref="Godot.AudioStreamRandomizer.RandomPitchSemitones"/>.</para>
    /// </summary>
    public float RandomPitch
    {
        get
        {
            return GetRandomPitch();
        }
        set
        {
            SetRandomPitch(value);
        }
    }

    /// <summary>
    /// <para>The largest possible distance, in semitones, of the random pitch variation. A value of <c>0.0</c> means no variation.</para>
    /// <para><b>Note:</b> Setting this property also sets <see cref="Godot.AudioStreamRandomizer.RandomPitch"/>.</para>
    /// </summary>
    public float RandomPitchSemitones
    {
        get
        {
            return GetRandomPitchSemitones();
        }
        set
        {
            SetRandomPitchSemitones(value);
        }
    }

    /// <summary>
    /// <para>The intensity of random volume variation. Volume will be increased or decreased by a random value up to <c>random_volume_offset_db</c>. A value of <c>0.0</c> means no variation. A value of <c>3.0</c> means volume will be randomized between <c>-3.0 dB</c> and <c>+3.0 dB</c>.</para>
    /// </summary>
    public float RandomVolumeOffsetDb
    {
        get
        {
            return GetRandomVolumeOffsetDb();
        }
        set
        {
            SetRandomVolumeOffsetDb(value);
        }
    }

    /// <summary>
    /// <para>The number of streams in the stream pool.</para>
    /// </summary>
    public int StreamsCount
    {
        get
        {
            return GetStreamsCount();
        }
        set
        {
            SetStreamsCount(value);
        }
    }

    private static readonly System.Type CachedType = typeof(AudioStreamRandomizer);

    private static readonly StringName NativeName = "AudioStreamRandomizer";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public AudioStreamRandomizer() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal AudioStreamRandomizer(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal AudioStreamRandomizer(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddStream, 1892018854ul);

    /// <summary>
    /// <para>Insert a stream at the specified index. If the index is less than zero, the insertion occurs at the end of the underlying pool.</para>
    /// </summary>
    public void AddStream(int index, AudioStream stream, float weight = 1.0f)
    {
        NativeCalls.godot_icall_3_210(MethodBind0, GodotObject.GetPtr(this), index, GodotObject.GetPtr(stream), weight);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MoveStream, 3937882851ul);

    /// <summary>
    /// <para>Move a stream from one index to another.</para>
    /// </summary>
    public void MoveStream(int indexFrom, int indexTo)
    {
        NativeCalls.godot_icall_2_59(MethodBind1, GodotObject.GetPtr(this), indexFrom, indexTo);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveStream, 1286410249ul);

    /// <summary>
    /// <para>Remove the stream at the specified index.</para>
    /// </summary>
    public void RemoveStream(int index)
    {
        NativeCalls.godot_icall_1_38(MethodBind2, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetStream, 111075094ul);

    /// <summary>
    /// <para>Set the AudioStream at the specified index.</para>
    /// </summary>
    public void SetStream(int index, AudioStream stream)
    {
        NativeCalls.godot_icall_2_70(MethodBind3, GodotObject.GetPtr(this), index, GodotObject.GetPtr(stream));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetStream, 2739380747ul);

    /// <summary>
    /// <para>Returns the stream at the specified index.</para>
    /// </summary>
    public AudioStream GetStream(int index)
    {
        return (AudioStream)NativeCalls.godot_icall_1_71(MethodBind4, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetStreamProbabilityWeight, 1602489585ul);

    /// <summary>
    /// <para>Set the probability weight of the stream at the specified index. The higher this value, the more likely that the randomizer will choose this stream during random playback modes.</para>
    /// </summary>
    public void SetStreamProbabilityWeight(int index, float weight)
    {
        NativeCalls.godot_icall_2_69(MethodBind5, GodotObject.GetPtr(this), index, weight);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetStreamProbabilityWeight, 2339986948ul);

    /// <summary>
    /// <para>Returns the probability weight associated with the stream at the given index.</para>
    /// </summary>
    public float GetStreamProbabilityWeight(int index)
    {
        return NativeCalls.godot_icall_1_72(MethodBind6, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetStreamsCount, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetStreamsCount(int count)
    {
        NativeCalls.godot_icall_1_38(MethodBind7, GodotObject.GetPtr(this), count);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetStreamsCount, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetStreamsCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind8, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRandomPitch, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetRandomPitch(float scale)
    {
        NativeCalls.godot_icall_1_67(MethodBind9, GodotObject.GetPtr(this), scale);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRandomPitch, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetRandomPitch()
    {
        return NativeCalls.godot_icall_0_68(MethodBind10, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRandomPitchSemitones, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetRandomPitchSemitones(float semitones)
    {
        NativeCalls.godot_icall_1_67(MethodBind11, GodotObject.GetPtr(this), semitones);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRandomPitchSemitones, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetRandomPitchSemitones()
    {
        return NativeCalls.godot_icall_0_68(MethodBind12, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRandomVolumeOffsetDb, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetRandomVolumeOffsetDb(float dbOffset)
    {
        NativeCalls.godot_icall_1_67(MethodBind13, GodotObject.GetPtr(this), dbOffset);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRandomVolumeOffsetDb, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetRandomVolumeOffsetDb()
    {
        return NativeCalls.godot_icall_0_68(MethodBind14, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPlaybackMode, 3950967023ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPlaybackMode(AudioStreamRandomizer.PlaybackModeEnum mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind15, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPlaybackMode, 3943055077ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public AudioStreamRandomizer.PlaybackModeEnum GetPlaybackMode()
    {
        return (AudioStreamRandomizer.PlaybackModeEnum)NativeCalls.godot_icall_0_39(MethodBind16, GodotObject.GetPtr(this));
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
    public new class PropertyName : AudioStream.PropertyName
    {
        /// <summary>
        /// Cached name for the 'playback_mode' property.
        /// </summary>
        public static readonly StringName PlaybackMode = "playback_mode";
        /// <summary>
        /// Cached name for the 'random_pitch' property.
        /// </summary>
        public static readonly StringName RandomPitch = "random_pitch";
        /// <summary>
        /// Cached name for the 'random_pitch_semitones' property.
        /// </summary>
        public static readonly StringName RandomPitchSemitones = "random_pitch_semitones";
        /// <summary>
        /// Cached name for the 'random_volume_offset_db' property.
        /// </summary>
        public static readonly StringName RandomVolumeOffsetDb = "random_volume_offset_db";
        /// <summary>
        /// Cached name for the 'streams_count' property.
        /// </summary>
        public static readonly StringName StreamsCount = "streams_count";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : AudioStream.MethodName
    {
        /// <summary>
        /// Cached name for the 'add_stream' method.
        /// </summary>
        public static readonly StringName AddStream = "add_stream";
        /// <summary>
        /// Cached name for the 'move_stream' method.
        /// </summary>
        public static readonly StringName MoveStream = "move_stream";
        /// <summary>
        /// Cached name for the 'remove_stream' method.
        /// </summary>
        public static readonly StringName RemoveStream = "remove_stream";
        /// <summary>
        /// Cached name for the 'set_stream' method.
        /// </summary>
        public static readonly StringName SetStream = "set_stream";
        /// <summary>
        /// Cached name for the 'get_stream' method.
        /// </summary>
        public static readonly StringName GetStream = "get_stream";
        /// <summary>
        /// Cached name for the 'set_stream_probability_weight' method.
        /// </summary>
        public static readonly StringName SetStreamProbabilityWeight = "set_stream_probability_weight";
        /// <summary>
        /// Cached name for the 'get_stream_probability_weight' method.
        /// </summary>
        public static readonly StringName GetStreamProbabilityWeight = "get_stream_probability_weight";
        /// <summary>
        /// Cached name for the 'set_streams_count' method.
        /// </summary>
        public static readonly StringName SetStreamsCount = "set_streams_count";
        /// <summary>
        /// Cached name for the 'get_streams_count' method.
        /// </summary>
        public static readonly StringName GetStreamsCount = "get_streams_count";
        /// <summary>
        /// Cached name for the 'set_random_pitch' method.
        /// </summary>
        public static readonly StringName SetRandomPitch = "set_random_pitch";
        /// <summary>
        /// Cached name for the 'get_random_pitch' method.
        /// </summary>
        public static readonly StringName GetRandomPitch = "get_random_pitch";
        /// <summary>
        /// Cached name for the 'set_random_pitch_semitones' method.
        /// </summary>
        public static readonly StringName SetRandomPitchSemitones = "set_random_pitch_semitones";
        /// <summary>
        /// Cached name for the 'get_random_pitch_semitones' method.
        /// </summary>
        public static readonly StringName GetRandomPitchSemitones = "get_random_pitch_semitones";
        /// <summary>
        /// Cached name for the 'set_random_volume_offset_db' method.
        /// </summary>
        public static readonly StringName SetRandomVolumeOffsetDb = "set_random_volume_offset_db";
        /// <summary>
        /// Cached name for the 'get_random_volume_offset_db' method.
        /// </summary>
        public static readonly StringName GetRandomVolumeOffsetDb = "get_random_volume_offset_db";
        /// <summary>
        /// Cached name for the 'set_playback_mode' method.
        /// </summary>
        public static readonly StringName SetPlaybackMode = "set_playback_mode";
        /// <summary>
        /// Cached name for the 'get_playback_mode' method.
        /// </summary>
        public static readonly StringName GetPlaybackMode = "get_playback_mode";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : AudioStream.SignalName
    {
    }
}
