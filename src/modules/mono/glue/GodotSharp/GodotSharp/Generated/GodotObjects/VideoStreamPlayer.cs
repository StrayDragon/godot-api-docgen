namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A control used for playback of <see cref="Godot.VideoStream"/> resources.</para>
/// <para>Supported video formats are <a href="https://www.theora.org/">Ogg Theora</a> (<c>.ogv</c>, <see cref="Godot.VideoStreamTheora"/>) and any format exposed via a GDExtension plugin.</para>
/// <para><b>Warning:</b> On Web, video playback <i>will</i> perform poorly due to missing architecture-specific assembly optimizations.</para>
/// </summary>
public partial class VideoStreamPlayer : Control
{
    /// <summary>
    /// <para>The embedded audio track to play.</para>
    /// </summary>
    public int AudioTrack
    {
        get
        {
            return GetAudioTrack();
        }
        set
        {
            SetAudioTrack(value);
        }
    }

    /// <summary>
    /// <para>The assigned video stream. See description for supported formats.</para>
    /// </summary>
    public VideoStream Stream
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
    /// <para>Audio volume in dB.</para>
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
    /// <para>Audio volume as a linear value.</para>
    /// </summary>
    public float Volume
    {
        get
        {
            return GetVolume();
        }
        set
        {
            SetVolume(value);
        }
    }

    /// <summary>
    /// <para>The stream's current speed scale. <c>1.0</c> is the normal speed, while <c>2.0</c> is double speed and <c>0.5</c> is half speed. A speed scale of <c>0.0</c> pauses the video, similar to setting <see cref="Godot.VideoStreamPlayer.Paused"/> to <see langword="true"/>.</para>
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
    /// <para>If <see langword="true"/>, playback starts when the scene loads.</para>
    /// </summary>
    public bool Autoplay
    {
        get
        {
            return HasAutoplay();
        }
        set
        {
            SetAutoplay(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the video is paused.</para>
    /// </summary>
    public bool Paused
    {
        get
        {
            return IsPaused();
        }
        set
        {
            SetPaused(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the video scales to the control size. Otherwise, the control minimum size will be automatically adjusted to match the video stream's dimensions.</para>
    /// </summary>
    public bool Expand
    {
        get
        {
            return HasExpand();
        }
        set
        {
            SetExpand(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the video restarts when it reaches its end.</para>
    /// </summary>
    public bool Loop
    {
        get
        {
            return HasLoop();
        }
        set
        {
            SetLoop(value);
        }
    }

    /// <summary>
    /// <para>Amount of time in milliseconds to store in buffer while playing.</para>
    /// </summary>
    public int BufferingMsec
    {
        get
        {
            return GetBufferingMsec();
        }
        set
        {
            SetBufferingMsec(value);
        }
    }

    /// <summary>
    /// <para>The current position of the stream, in seconds.</para>
    /// </summary>
    public double StreamPosition
    {
        get
        {
            return GetStreamPosition();
        }
        set
        {
            SetStreamPosition(value);
        }
    }

    /// <summary>
    /// <para>Audio bus to use for sound playback.</para>
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

    private static readonly System.Type CachedType = typeof(VideoStreamPlayer);

    private static readonly StringName NativeName = "VideoStreamPlayer";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public VideoStreamPlayer() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal VideoStreamPlayer(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal VideoStreamPlayer(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetStream, 2317102564ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetStream(VideoStream stream)
    {
        NativeCalls.godot_icall_1_56(MethodBind0, GodotObject.GetPtr(this), GodotObject.GetPtr(stream));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetStream, 438621487ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public VideoStream GetStream()
    {
        return (VideoStream)NativeCalls.godot_icall_0_63(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Play, 3218959716ul);

    /// <summary>
    /// <para>Starts the video playback from the beginning. If the video is paused, this will not unpause the video.</para>
    /// </summary>
    public void Play()
    {
        NativeCalls.godot_icall_0_3(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Stop, 3218959716ul);

    /// <summary>
    /// <para>Stops the video playback and sets the stream position to 0.</para>
    /// <para><b>Note:</b> Although the stream position will be set to 0, the first frame of the video stream won't become the current frame.</para>
    /// </summary>
    public void Stop()
    {
        NativeCalls.godot_icall_0_3(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsPlaying, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the video is playing.</para>
    /// <para><b>Note:</b> The video is still considered playing if paused during playback.</para>
    /// </summary>
    public bool IsPlaying()
    {
        return NativeCalls.godot_icall_0_15(MethodBind4, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPaused, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPaused(bool paused)
    {
        NativeCalls.godot_icall_1_14(MethodBind5, GodotObject.GetPtr(this), paused.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsPaused, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsPaused()
    {
        return NativeCalls.godot_icall_0_15(MethodBind6, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLoop, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetLoop(bool loop)
    {
        NativeCalls.godot_icall_1_14(MethodBind7, GodotObject.GetPtr(this), loop.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasLoop, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool HasLoop()
    {
        return NativeCalls.godot_icall_0_15(MethodBind8, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVolume, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetVolume(float volume)
    {
        NativeCalls.godot_icall_1_67(MethodBind9, GodotObject.GetPtr(this), volume);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVolume, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetVolume()
    {
        return NativeCalls.godot_icall_0_68(MethodBind10, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVolumeDb, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetVolumeDb(float db)
    {
        NativeCalls.godot_icall_1_67(MethodBind11, GodotObject.GetPtr(this), db);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVolumeDb, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetVolumeDb()
    {
        return NativeCalls.godot_icall_0_68(MethodBind12, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSpeedScale, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSpeedScale(float speedScale)
    {
        NativeCalls.godot_icall_1_67(MethodBind13, GodotObject.GetPtr(this), speedScale);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSpeedScale, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetSpeedScale()
    {
        return NativeCalls.godot_icall_0_68(MethodBind14, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAudioTrack, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAudioTrack(int track)
    {
        NativeCalls.godot_icall_1_38(MethodBind15, GodotObject.GetPtr(this), track);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAudioTrack, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetAudioTrack()
    {
        return NativeCalls.godot_icall_0_39(MethodBind16, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetStreamName, 201670096ul);

    /// <summary>
    /// <para>Returns the video stream's name, or <c>"&lt;No Stream&gt;"</c> if no video stream is assigned.</para>
    /// </summary>
    public string GetStreamName()
    {
        return NativeCalls.godot_icall_0_58(MethodBind17, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetStreamLength, 1740695150ul);

    /// <summary>
    /// <para>The length of the current stream, in seconds.</para>
    /// </summary>
    public double GetStreamLength()
    {
        return NativeCalls.godot_icall_0_144(MethodBind18, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetStreamPosition, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetStreamPosition(double position)
    {
        NativeCalls.godot_icall_1_127(MethodBind19, GodotObject.GetPtr(this), position);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetStreamPosition, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public double GetStreamPosition()
    {
        return NativeCalls.godot_icall_0_144(MethodBind20, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAutoplay, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAutoplay(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind21, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasAutoplay, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool HasAutoplay()
    {
        return NativeCalls.godot_icall_0_15(MethodBind22, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetExpand, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetExpand(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind23, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasExpand, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool HasExpand()
    {
        return NativeCalls.godot_icall_0_15(MethodBind24, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBufferingMsec, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetBufferingMsec(int msec)
    {
        NativeCalls.godot_icall_1_38(MethodBind25, GodotObject.GetPtr(this), msec);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBufferingMsec, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetBufferingMsec()
    {
        return NativeCalls.godot_icall_0_39(MethodBind26, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBus, 3304788590ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetBus(StringName bus)
    {
        NativeCalls.godot_icall_1_64(MethodBind27, GodotObject.GetPtr(this), (godot_string_name)(bus?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBus, 2002593661ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public StringName GetBus()
    {
        return NativeCalls.godot_icall_0_65(MethodBind28, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVideoTexture, 3635182373ul);

    /// <summary>
    /// <para>Returns the current frame as a <see cref="Godot.Texture2D"/>.</para>
    /// </summary>
    public Texture2D GetVideoTexture()
    {
        return (Texture2D)NativeCalls.godot_icall_0_63(MethodBind29, GodotObject.GetPtr(this));
    }

    /// <summary>
    /// <para>Emitted when playback is finished.</para>
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
    public new class PropertyName : Control.PropertyName
    {
        /// <summary>
        /// Cached name for the 'audio_track' property.
        /// </summary>
        public static readonly StringName AudioTrack = "audio_track";
        /// <summary>
        /// Cached name for the 'stream' property.
        /// </summary>
        public static readonly StringName Stream = "stream";
        /// <summary>
        /// Cached name for the 'volume_db' property.
        /// </summary>
        public static readonly StringName VolumeDb = "volume_db";
        /// <summary>
        /// Cached name for the 'volume' property.
        /// </summary>
        public static readonly StringName Volume = "volume";
        /// <summary>
        /// Cached name for the 'speed_scale' property.
        /// </summary>
        public static readonly StringName SpeedScale = "speed_scale";
        /// <summary>
        /// Cached name for the 'autoplay' property.
        /// </summary>
        public static readonly StringName Autoplay = "autoplay";
        /// <summary>
        /// Cached name for the 'paused' property.
        /// </summary>
        public static readonly StringName Paused = "paused";
        /// <summary>
        /// Cached name for the 'expand' property.
        /// </summary>
        public static readonly StringName Expand = "expand";
        /// <summary>
        /// Cached name for the 'loop' property.
        /// </summary>
        public static readonly StringName Loop = "loop";
        /// <summary>
        /// Cached name for the 'buffering_msec' property.
        /// </summary>
        public static readonly StringName BufferingMsec = "buffering_msec";
        /// <summary>
        /// Cached name for the 'stream_position' property.
        /// </summary>
        public static readonly StringName StreamPosition = "stream_position";
        /// <summary>
        /// Cached name for the 'bus' property.
        /// </summary>
        public static readonly StringName Bus = "bus";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Control.MethodName
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
        /// Cached name for the 'play' method.
        /// </summary>
        public static readonly StringName Play = "play";
        /// <summary>
        /// Cached name for the 'stop' method.
        /// </summary>
        public static readonly StringName Stop = "stop";
        /// <summary>
        /// Cached name for the 'is_playing' method.
        /// </summary>
        public static readonly StringName IsPlaying = "is_playing";
        /// <summary>
        /// Cached name for the 'set_paused' method.
        /// </summary>
        public static readonly StringName SetPaused = "set_paused";
        /// <summary>
        /// Cached name for the 'is_paused' method.
        /// </summary>
        public static readonly StringName IsPaused = "is_paused";
        /// <summary>
        /// Cached name for the 'set_loop' method.
        /// </summary>
        public static readonly StringName SetLoop = "set_loop";
        /// <summary>
        /// Cached name for the 'has_loop' method.
        /// </summary>
        public static readonly StringName HasLoop = "has_loop";
        /// <summary>
        /// Cached name for the 'set_volume' method.
        /// </summary>
        public static readonly StringName SetVolume = "set_volume";
        /// <summary>
        /// Cached name for the 'get_volume' method.
        /// </summary>
        public static readonly StringName GetVolume = "get_volume";
        /// <summary>
        /// Cached name for the 'set_volume_db' method.
        /// </summary>
        public static readonly StringName SetVolumeDb = "set_volume_db";
        /// <summary>
        /// Cached name for the 'get_volume_db' method.
        /// </summary>
        public static readonly StringName GetVolumeDb = "get_volume_db";
        /// <summary>
        /// Cached name for the 'set_speed_scale' method.
        /// </summary>
        public static readonly StringName SetSpeedScale = "set_speed_scale";
        /// <summary>
        /// Cached name for the 'get_speed_scale' method.
        /// </summary>
        public static readonly StringName GetSpeedScale = "get_speed_scale";
        /// <summary>
        /// Cached name for the 'set_audio_track' method.
        /// </summary>
        public static readonly StringName SetAudioTrack = "set_audio_track";
        /// <summary>
        /// Cached name for the 'get_audio_track' method.
        /// </summary>
        public static readonly StringName GetAudioTrack = "get_audio_track";
        /// <summary>
        /// Cached name for the 'get_stream_name' method.
        /// </summary>
        public static readonly StringName GetStreamName = "get_stream_name";
        /// <summary>
        /// Cached name for the 'get_stream_length' method.
        /// </summary>
        public static readonly StringName GetStreamLength = "get_stream_length";
        /// <summary>
        /// Cached name for the 'set_stream_position' method.
        /// </summary>
        public static readonly StringName SetStreamPosition = "set_stream_position";
        /// <summary>
        /// Cached name for the 'get_stream_position' method.
        /// </summary>
        public static readonly StringName GetStreamPosition = "get_stream_position";
        /// <summary>
        /// Cached name for the 'set_autoplay' method.
        /// </summary>
        public static readonly StringName SetAutoplay = "set_autoplay";
        /// <summary>
        /// Cached name for the 'has_autoplay' method.
        /// </summary>
        public static readonly StringName HasAutoplay = "has_autoplay";
        /// <summary>
        /// Cached name for the 'set_expand' method.
        /// </summary>
        public static readonly StringName SetExpand = "set_expand";
        /// <summary>
        /// Cached name for the 'has_expand' method.
        /// </summary>
        public static readonly StringName HasExpand = "has_expand";
        /// <summary>
        /// Cached name for the 'set_buffering_msec' method.
        /// </summary>
        public static readonly StringName SetBufferingMsec = "set_buffering_msec";
        /// <summary>
        /// Cached name for the 'get_buffering_msec' method.
        /// </summary>
        public static readonly StringName GetBufferingMsec = "get_buffering_msec";
        /// <summary>
        /// Cached name for the 'set_bus' method.
        /// </summary>
        public static readonly StringName SetBus = "set_bus";
        /// <summary>
        /// Cached name for the 'get_bus' method.
        /// </summary>
        public static readonly StringName GetBus = "get_bus";
        /// <summary>
        /// Cached name for the 'get_video_texture' method.
        /// </summary>
        public static readonly StringName GetVideoTexture = "get_video_texture";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Control.SignalName
    {
        /// <summary>
        /// Cached name for the 'finished' signal.
        /// </summary>
        public static readonly StringName Finished = "finished";
    }
}
