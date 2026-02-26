namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Playback instance for <see cref="Godot.AudioStreamPolyphonic"/>. After setting the <c>stream</c> property of <see cref="Godot.AudioStreamPlayer"/>, <see cref="Godot.AudioStreamPlayer2D"/>, or <see cref="Godot.AudioStreamPlayer3D"/>, the playback instance can be obtained by calling <see cref="Godot.AudioStreamPlayer.GetStreamPlayback()"/>, <see cref="Godot.AudioStreamPlayer2D.GetStreamPlayback()"/> or <see cref="Godot.AudioStreamPlayer3D.GetStreamPlayback()"/> methods.</para>
/// </summary>
public partial class AudioStreamPlaybackPolyphonic : AudioStreamPlayback
{
    /// <summary>
    /// <para>Returned by <see cref="Godot.AudioStreamPlaybackPolyphonic.PlayStream(AudioStream, float, float, float, AudioServer.PlaybackType, StringName)"/> in case it could not allocate a stream for playback.</para>
    /// </summary>
    public const long InvalidId = -1;

    private static readonly System.Type CachedType = typeof(AudioStreamPlaybackPolyphonic);

    private static readonly StringName NativeName = "AudioStreamPlaybackPolyphonic";

    internal AudioStreamPlaybackPolyphonic() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal AudioStreamPlaybackPolyphonic(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal AudioStreamPlaybackPolyphonic(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PlayStream, 1846744803ul);

    /// <summary>
    /// <para>Play an <see cref="Godot.AudioStream"/> at a given offset, volume, pitch scale, playback type, and bus. Playback starts immediately.</para>
    /// <para>The return value is a unique integer ID that is associated to this playback stream and which can be used to control it.</para>
    /// <para>This ID becomes invalid when the stream ends (if it does not loop), when the <see cref="Godot.AudioStreamPlaybackPolyphonic"/> is stopped, or when <see cref="Godot.AudioStreamPlaybackPolyphonic.StopStream(long)"/> is called.</para>
    /// <para>This function returns <see cref="Godot.AudioStreamPlaybackPolyphonic.InvalidId"/> if the amount of streams currently playing equals <see cref="Godot.AudioStreamPolyphonic.Polyphony"/>. If you need a higher amount of maximum polyphony, raise this value.</para>
    /// </summary>
    public long PlayStream(AudioStream stream, float fromOffset = (float)(0), float volumeDb = (float)(0), float pitchScale = 1.0f, AudioServer.PlaybackType playbackType = (AudioServer.PlaybackType)(0), StringName bus = null)
    {
        return NativeCalls.godot_icall_6_206(MethodBind0, GodotObject.GetPtr(this), GodotObject.GetPtr(stream), fromOffset, volumeDb, pitchScale, (int)playbackType, (godot_string_name)(bus?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetStreamVolume, 1602489585ul);

    /// <summary>
    /// <para>Change the stream volume (in db). The <paramref name="stream"/> argument is an integer ID returned by <see cref="Godot.AudioStreamPlaybackPolyphonic.PlayStream(AudioStream, float, float, float, AudioServer.PlaybackType, StringName)"/>.</para>
    /// </summary>
    public void SetStreamVolume(long stream, float volumeDb)
    {
        NativeCalls.godot_icall_2_9(MethodBind1, GodotObject.GetPtr(this), stream, volumeDb);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetStreamPitchScale, 1602489585ul);

    /// <summary>
    /// <para>Change the stream pitch scale. The <paramref name="stream"/> argument is an integer ID returned by <see cref="Godot.AudioStreamPlaybackPolyphonic.PlayStream(AudioStream, float, float, float, AudioServer.PlaybackType, StringName)"/>.</para>
    /// </summary>
    public void SetStreamPitchScale(long stream, float pitchScale)
    {
        NativeCalls.godot_icall_2_9(MethodBind2, GodotObject.GetPtr(this), stream, pitchScale);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsStreamPlaying, 1116898809ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the stream associated with the given integer ID is still playing. Check <see cref="Godot.AudioStreamPlaybackPolyphonic.PlayStream(AudioStream, float, float, float, AudioServer.PlaybackType, StringName)"/> for information on when this ID becomes invalid.</para>
    /// </summary>
    public bool IsStreamPlaying(long stream)
    {
        return NativeCalls.godot_icall_1_11(MethodBind3, GodotObject.GetPtr(this), stream).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.StopStream, 1286410249ul);

    /// <summary>
    /// <para>Stop a stream. The <paramref name="stream"/> argument is an integer ID returned by <see cref="Godot.AudioStreamPlaybackPolyphonic.PlayStream(AudioStream, float, float, float, AudioServer.PlaybackType, StringName)"/>, which becomes invalid after calling this function.</para>
    /// </summary>
    public void StopStream(long stream)
    {
        NativeCalls.godot_icall_1_10(MethodBind4, GodotObject.GetPtr(this), stream);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PlayStream, 604492179ul);

    /// <summary>
    /// <para>Play an <see cref="Godot.AudioStream"/> at a given offset, volume, pitch scale, playback type, and bus. Playback starts immediately.</para>
    /// <para>The return value is a unique integer ID that is associated to this playback stream and which can be used to control it.</para>
    /// <para>This ID becomes invalid when the stream ends (if it does not loop), when the <see cref="Godot.AudioStreamPlaybackPolyphonic"/> is stopped, or when <see cref="Godot.AudioStreamPlaybackPolyphonic.StopStream(long)"/> is called.</para>
    /// <para>This function returns <see cref="Godot.AudioStreamPlaybackPolyphonic.InvalidId"/> if the amount of streams currently playing equals <see cref="Godot.AudioStreamPolyphonic.Polyphony"/>. If you need a higher amount of maximum polyphony, raise this value.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public long PlayStream(AudioStream stream, float fromOffset, float volumeDb, float pitchScale)
    {
        return NativeCalls.godot_icall_4_207(MethodBind5, GodotObject.GetPtr(this), GodotObject.GetPtr(stream), fromOffset, volumeDb, pitchScale);
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
    public new class PropertyName : AudioStreamPlayback.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : AudioStreamPlayback.MethodName
    {
        /// <summary>
        /// Cached name for the 'play_stream' method.
        /// </summary>
        public static readonly StringName PlayStream = "play_stream";
        /// <summary>
        /// Cached name for the 'set_stream_volume' method.
        /// </summary>
        public static readonly StringName SetStreamVolume = "set_stream_volume";
        /// <summary>
        /// Cached name for the 'set_stream_pitch_scale' method.
        /// </summary>
        public static readonly StringName SetStreamPitchScale = "set_stream_pitch_scale";
        /// <summary>
        /// Cached name for the 'is_stream_playing' method.
        /// </summary>
        public static readonly StringName IsStreamPlaying = "is_stream_playing";
        /// <summary>
        /// Cached name for the 'stop_stream' method.
        /// </summary>
        public static readonly StringName StopStream = "stop_stream";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : AudioStreamPlayback.SignalName
    {
    }
}
