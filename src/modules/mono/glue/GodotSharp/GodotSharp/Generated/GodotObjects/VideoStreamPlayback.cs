namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This class is intended to be overridden by video decoder extensions with custom implementations of <see cref="Godot.VideoStream"/>.</para>
/// </summary>
public partial class VideoStreamPlayback : Resource
{
    private static readonly System.Type CachedType = typeof(VideoStreamPlayback);

    private static readonly StringName NativeName = "VideoStreamPlayback";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public VideoStreamPlayback() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal VideoStreamPlayback(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal VideoStreamPlayback(bool memoryOwn) : base(memoryOwn) { }

    /// <summary>
    /// <para>Returns the number of audio channels.</para>
    /// </summary>
    public virtual int _GetChannels()
    {
        return default;
    }

    /// <summary>
    /// <para>Returns the video duration in seconds, if known, or 0 if unknown.</para>
    /// </summary>
    public virtual double _GetLength()
    {
        return default;
    }

    /// <summary>
    /// <para>Returns the audio sample rate used for mixing.</para>
    /// </summary>
    public virtual int _GetMixRate()
    {
        return default;
    }

    /// <summary>
    /// <para>Return the current playback timestamp. Called in response to the <see cref="Godot.VideoStreamPlayer.StreamPosition"/> getter.</para>
    /// </summary>
    public virtual double _GetPlaybackPosition()
    {
        return default;
    }

    /// <summary>
    /// <para>Allocates a <see cref="Godot.Texture2D"/> in which decoded video frames will be drawn.</para>
    /// </summary>
    public virtual Texture2D _GetTexture()
    {
        return default;
    }

    /// <summary>
    /// <para>Returns the paused status, as set by <see cref="Godot.VideoStreamPlayback._SetPaused(bool)"/>.</para>
    /// </summary>
    public virtual bool _IsPaused()
    {
        return default;
    }

    /// <summary>
    /// <para>Returns the playback state, as determined by calls to <see cref="Godot.VideoStreamPlayback._Play()"/> and <see cref="Godot.VideoStreamPlayback._Stop()"/>.</para>
    /// </summary>
    public virtual bool _IsPlaying()
    {
        return default;
    }

    /// <summary>
    /// <para>Called in response to <see cref="Godot.VideoStreamPlayer.Autoplay"/> or <see cref="Godot.VideoStreamPlayer.Play()"/>. Note that manual playback may also invoke <see cref="Godot.VideoStreamPlayback._Stop()"/> multiple times before this method is called. <see cref="Godot.VideoStreamPlayback._IsPlaying()"/> should return <see langword="true"/> once playing.</para>
    /// </summary>
    public virtual void _Play()
    {
    }

    /// <summary>
    /// <para>Seeks to <paramref name="time"/> seconds. Called in response to the <see cref="Godot.VideoStreamPlayer.StreamPosition"/> setter.</para>
    /// </summary>
    public virtual void _Seek(double time)
    {
    }

    /// <summary>
    /// <para>Select the audio track <paramref name="idx"/>. Called when playback starts, and in response to the <see cref="Godot.VideoStreamPlayer.AudioTrack"/> setter.</para>
    /// </summary>
    public virtual void _SetAudioTrack(int idx)
    {
    }

    /// <summary>
    /// <para>Set the paused status of video playback. <see cref="Godot.VideoStreamPlayback._IsPaused()"/> must return <paramref name="paused"/>. Called in response to the <see cref="Godot.VideoStreamPlayer.Paused"/> setter.</para>
    /// </summary>
    public virtual void _SetPaused(bool paused)
    {
    }

    /// <summary>
    /// <para>Stops playback. May be called multiple times before <see cref="Godot.VideoStreamPlayback._Play()"/>, or in response to <see cref="Godot.VideoStreamPlayer.Stop()"/>. <see cref="Godot.VideoStreamPlayback._IsPlaying()"/> should return <see langword="false"/> once stopped.</para>
    /// </summary>
    public virtual void _Stop()
    {
    }

    /// <summary>
    /// <para>Ticks video playback for <paramref name="delta"/> seconds. Called every frame as long as both <see cref="Godot.VideoStreamPlayback._IsPaused()"/> and <see cref="Godot.VideoStreamPlayback._IsPlaying()"/> return <see langword="true"/>.</para>
    /// </summary>
    public virtual void _Update(double delta)
    {
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MixAudio, 93876830ul);

    /// <summary>
    /// <para>Render <paramref name="numFrames"/> audio frames (of <see cref="Godot.VideoStreamPlayback._GetChannels()"/> floats each) from <paramref name="buffer"/>, starting from index <paramref name="offset"/> in the array. Returns the number of audio frames rendered, or -1 on error.</para>
    /// </summary>
    /// <param name="buffer">If the parameter is null, then the default value is <c>Array.Empty&lt;float&gt;()</c>.</param>
    public int MixAudio(int numFrames, float[] buffer = null, int offset = 0)
    {
        float[] bufferOrDefVal = buffer != null ? buffer : Array.Empty<float>();
        return NativeCalls.godot_icall_3_1490(MethodBind0, GodotObject.GetPtr(this), numFrames, bufferOrDefVal, offset);
    }

    /// <summary>
    /// <para>Render <paramref name="numFrames"/> audio frames (of <see cref="Godot.VideoStreamPlayback._GetChannels()"/> floats each) from <paramref name="buffer"/>, starting from index <paramref name="offset"/> in the array. Returns the number of audio frames rendered, or -1 on error.</para>
    /// </summary>
    public int MixAudio(int numFrames, ReadOnlySpan<float> buffer, int offset)
    {
        return NativeCalls.godot_icall_3_1490(MethodBind0, GodotObject.GetPtr(this), numFrames, buffer, offset);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_channels = "_GetChannels";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_length = "_GetLength";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_mix_rate = "_GetMixRate";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_playback_position = "_GetPlaybackPosition";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_texture = "_GetTexture";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__is_paused = "_IsPaused";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__is_playing = "_IsPlaying";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__play = "_Play";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__seek = "_Seek";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__set_audio_track = "_SetAudioTrack";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__set_paused = "_SetPaused";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__stop = "_Stop";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__update = "_Update";

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
        if ((method == MethodProxyName__get_channels || method == MethodName._GetChannels) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_channels.NativeValue))
        {
            var callRet = _GetChannels();
            ret = VariantUtils.CreateFrom<int>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_length || method == MethodName._GetLength) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_length.NativeValue))
        {
            var callRet = _GetLength();
            ret = VariantUtils.CreateFrom<double>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_mix_rate || method == MethodName._GetMixRate) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_mix_rate.NativeValue))
        {
            var callRet = _GetMixRate();
            ret = VariantUtils.CreateFrom<int>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_playback_position || method == MethodName._GetPlaybackPosition) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_playback_position.NativeValue))
        {
            var callRet = _GetPlaybackPosition();
            ret = VariantUtils.CreateFrom<double>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_texture || method == MethodName._GetTexture) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_texture.NativeValue))
        {
            var callRet = _GetTexture();
            ret = VariantUtils.CreateFrom<Texture2D>(callRet);
            return true;
        }
        if ((method == MethodProxyName__is_paused || method == MethodName._IsPaused) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__is_paused.NativeValue))
        {
            var callRet = _IsPaused();
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__is_playing || method == MethodName._IsPlaying) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__is_playing.NativeValue))
        {
            var callRet = _IsPlaying();
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__play || method == MethodName._Play) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__play.NativeValue))
        {
            _Play();
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__seek || method == MethodName._Seek) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__seek.NativeValue))
        {
            _Seek(VariantUtils.ConvertTo<double>(args[0]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__set_audio_track || method == MethodName._SetAudioTrack) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__set_audio_track.NativeValue))
        {
            _SetAudioTrack(VariantUtils.ConvertTo<int>(args[0]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__set_paused || method == MethodName._SetPaused) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__set_paused.NativeValue))
        {
            _SetPaused(VariantUtils.ConvertTo<bool>(args[0]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__stop || method == MethodName._Stop) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__stop.NativeValue))
        {
            _Stop();
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__update || method == MethodName._Update) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__update.NativeValue))
        {
            _Update(VariantUtils.ConvertTo<double>(args[0]));
            ret = default;
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
        if (method == MethodName._GetChannels)
        {
            if (HasGodotClassMethod(MethodProxyName__get_channels.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetLength)
        {
            if (HasGodotClassMethod(MethodProxyName__get_length.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetMixRate)
        {
            if (HasGodotClassMethod(MethodProxyName__get_mix_rate.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetPlaybackPosition)
        {
            if (HasGodotClassMethod(MethodProxyName__get_playback_position.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetTexture)
        {
            if (HasGodotClassMethod(MethodProxyName__get_texture.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._IsPaused)
        {
            if (HasGodotClassMethod(MethodProxyName__is_paused.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._IsPlaying)
        {
            if (HasGodotClassMethod(MethodProxyName__is_playing.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._Play)
        {
            if (HasGodotClassMethod(MethodProxyName__play.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._Seek)
        {
            if (HasGodotClassMethod(MethodProxyName__seek.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._SetAudioTrack)
        {
            if (HasGodotClassMethod(MethodProxyName__set_audio_track.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._SetPaused)
        {
            if (HasGodotClassMethod(MethodProxyName__set_paused.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._Stop)
        {
            if (HasGodotClassMethod(MethodProxyName__stop.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._Update)
        {
            if (HasGodotClassMethod(MethodProxyName__update.NativeValue.DangerousSelfRef))
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
    public new class PropertyName : Resource.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Resource.MethodName
    {
        /// <summary>
        /// Cached name for the '_get_channels' method.
        /// </summary>
        public static readonly StringName _GetChannels = "_get_channels";
        /// <summary>
        /// Cached name for the '_get_length' method.
        /// </summary>
        public static readonly StringName _GetLength = "_get_length";
        /// <summary>
        /// Cached name for the '_get_mix_rate' method.
        /// </summary>
        public static readonly StringName _GetMixRate = "_get_mix_rate";
        /// <summary>
        /// Cached name for the '_get_playback_position' method.
        /// </summary>
        public static readonly StringName _GetPlaybackPosition = "_get_playback_position";
        /// <summary>
        /// Cached name for the '_get_texture' method.
        /// </summary>
        public static readonly StringName _GetTexture = "_get_texture";
        /// <summary>
        /// Cached name for the '_is_paused' method.
        /// </summary>
        public static readonly StringName _IsPaused = "_is_paused";
        /// <summary>
        /// Cached name for the '_is_playing' method.
        /// </summary>
        public static readonly StringName _IsPlaying = "_is_playing";
        /// <summary>
        /// Cached name for the '_play' method.
        /// </summary>
        public static readonly StringName _Play = "_play";
        /// <summary>
        /// Cached name for the '_seek' method.
        /// </summary>
        public static readonly StringName _Seek = "_seek";
        /// <summary>
        /// Cached name for the '_set_audio_track' method.
        /// </summary>
        public static readonly StringName _SetAudioTrack = "_set_audio_track";
        /// <summary>
        /// Cached name for the '_set_paused' method.
        /// </summary>
        public static readonly StringName _SetPaused = "_set_paused";
        /// <summary>
        /// Cached name for the '_stop' method.
        /// </summary>
        public static readonly StringName _Stop = "_stop";
        /// <summary>
        /// Cached name for the '_update' method.
        /// </summary>
        public static readonly StringName _Update = "_update";
        /// <summary>
        /// Cached name for the 'mix_audio' method.
        /// </summary>
        public static readonly StringName MixAudio = "mix_audio";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Resource.SignalName
    {
    }
}
