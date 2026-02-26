namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Godot can record videos with non-real-time simulation. Like the <c>--fixed-fps</c> <a href="$DOCS_URL/tutorials/editor/command_line_tutorial.html">command line argument</a>, this forces the reported <c>delta</c> in <see cref="Godot.Node._Process(double)"/> functions to be identical across frames, regardless of how long it actually took to render the frame. This can be used to record high-quality videos with perfect frame pacing regardless of your hardware's capabilities.</para>
/// <para>Godot has 3 built-in <see cref="Godot.MovieWriter"/>s:</para>
/// <para>- OGV container with Theora for video and Vorbis for audio (<c>.ogv</c> file extension). Lossy compression, medium file sizes, fast encoding. The lossy compression quality can be adjusted by changing <c>ProjectSettings.editor/movie_writer/video_quality</c> and <c>ProjectSettings.editor/movie_writer/ogv/audio_quality</c>. The resulting file can be viewed in Godot with <see cref="Godot.VideoStreamPlayer"/> and most video players, but not web browsers as they don't support Theora.</para>
/// <para>- AVI container with MJPEG for video and uncompressed audio (<c>.avi</c> file extension). Lossy compression, medium file sizes, fast encoding. The lossy compression quality can be adjusted by changing <c>ProjectSettings.editor/movie_writer/video_quality</c>. The resulting file can be viewed in most video players, but it must be converted to another format for viewing on the web or by Godot with <see cref="Godot.VideoStreamPlayer"/>. MJPEG does not support transparency. AVI output is currently limited to a file of 4 GB in size at most.</para>
/// <para>- PNG image sequence for video and WAV for audio (<c>.png</c> file extension). Lossless compression, large file sizes, slow encoding. Designed to be encoded to a video file with another tool such as <a href="https://ffmpeg.org/">FFmpeg</a> after recording. Transparency is currently not supported, even if the root viewport is set to be transparent.</para>
/// <para>If you need to encode to a different format or pipe a stream through third-party software, you can extend the <see cref="Godot.MovieWriter"/> class to create your own movie writers. This should typically be done using GDExtension for performance reasons.</para>
/// <para><b>Editor usage:</b> A default movie file path can be specified in <c>ProjectSettings.editor/movie_writer/movie_file</c>. Alternatively, for running single scenes, a <c>movie_file</c> metadata can be added to the root node, specifying the path to a movie file that will be used when recording that scene. Once a path is set, click the video reel icon in the top-right corner of the editor to enable Movie Maker mode, then run any scene as usual. The engine will start recording as soon as the splash screen is finished, and it will only stop recording when the engine quits. Click the video reel icon again to disable Movie Maker mode. Note that toggling Movie Maker mode does not affect project instances that are already running.</para>
/// <para><b>Note:</b> MovieWriter is available for use in both the editor and exported projects, but it is <i>not</i> designed for use by end users to record videos while playing. Players wishing to record gameplay videos should install tools such as <a href="https://obsproject.com/">OBS Studio</a> or <a href="https://www.maartenbaert.be/simplescreenrecorder/">SimpleScreenRecorder</a> instead.</para>
/// <para><b>Note:</b> MJPEG support (<c>.avi</c> file extension) depends on the <c>jpg</c> module being enabled at compile time (default behavior).</para>
/// <para><b>Note:</b> OGV support (<c>.ogv</c> file extension) depends on the <c>theora</c> module being enabled at compile time (default behavior). Theora compression is only available in editor binaries.</para>
/// </summary>
public partial class MovieWriter : GodotObject
{
    private static readonly System.Type CachedType = typeof(MovieWriter);

    private static readonly StringName NativeName = "MovieWriter";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public MovieWriter() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal MovieWriter(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal MovieWriter(bool memoryOwn) : base(memoryOwn) { }

    /// <summary>
    /// <para>Called when the audio sample rate used for recording the audio is requested by the engine. The value returned must be specified in Hz. Defaults to 48000 Hz if <see cref="Godot.MovieWriter._GetAudioMixRate()"/> is not overridden.</para>
    /// </summary>
    public virtual uint _GetAudioMixRate()
    {
        return default;
    }

    /// <summary>
    /// <para>Called when the audio speaker mode used for recording the audio is requested by the engine. This can affect the number of output channels in the resulting audio file/stream. Defaults to <see cref="Godot.AudioServer.SpeakerMode.ModeStereo"/> if <see cref="Godot.MovieWriter._GetAudioSpeakerMode()"/> is not overridden.</para>
    /// </summary>
    public virtual AudioServer.SpeakerMode _GetAudioSpeakerMode()
    {
        return default;
    }

    /// <summary>
    /// <para>Called when the engine determines whether this <see cref="Godot.MovieWriter"/> is able to handle the file at <paramref name="path"/>. Must return <see langword="true"/> if this <see cref="Godot.MovieWriter"/> is able to handle the given file path, <see langword="false"/> otherwise. Typically, <see cref="Godot.MovieWriter._HandlesFile(string)"/> is overridden as follows to allow the user to record a file at any path with a given file extension:</para>
    /// <para><code>
    /// func _handles_file(path):
    /// 	# Allows specifying an output file with a `.mkv` file extension (case-insensitive),
    /// 	# either in the Project Settings or with the `--write-movie &lt;path&gt;` command line argument.
    /// 	return path.get_extension().to_lower() == "mkv"
    /// </code></para>
    /// </summary>
    public virtual bool _HandlesFile(string path)
    {
        return default;
    }

    /// <summary>
    /// <para>Called once before the engine starts writing video and audio data. <paramref name="movieSize"/> is the width and height of the video to save. <paramref name="fps"/> is the number of frames per second specified in the project settings or using the <c>--fixed-fps &lt;fps&gt;</c> <a href="$DOCS_URL/tutorials/editor/command_line_tutorial.html">command line argument</a>.</para>
    /// </summary>
    public virtual unsafe Error _WriteBegin(Vector2I movieSize, uint fps, string basePath)
    {
        return default;
    }

    /// <summary>
    /// <para>Called when the engine finishes writing. This occurs when the engine quits by pressing the window manager's close button, or when <see cref="Godot.SceneTree.Quit(int)"/> is called.</para>
    /// <para><b>Note:</b> Pressing Ctrl + C on the terminal running the editor/project does <i>not</i> result in <see cref="Godot.MovieWriter._WriteEnd()"/> being called.</para>
    /// </summary>
    public virtual void _WriteEnd()
    {
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddWriter, 4023702871ul);

    /// <summary>
    /// <para>Adds a writer to be usable by the engine. The supported file extensions can be set by overriding <see cref="Godot.MovieWriter._HandlesFile(string)"/>.</para>
    /// <para><b>Note:</b> <see cref="Godot.MovieWriter.AddWriter(MovieWriter)"/> must be called early enough in the engine initialization to work, as movie writing is designed to start at the same time as the rest of the engine.</para>
    /// </summary>
    public static void AddWriter(MovieWriter writer)
    {
        NativeCalls.godot_icall_1_646(MethodBind0, GodotObject.GetPtr(writer));
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_audio_mix_rate = "_GetAudioMixRate";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_audio_speaker_mode = "_GetAudioSpeakerMode";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__handles_file = "_HandlesFile";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__write_begin = "_WriteBegin";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__write_end = "_WriteEnd";

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
        if ((method == MethodProxyName__get_audio_mix_rate || method == MethodName._GetAudioMixRate) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_audio_mix_rate.NativeValue))
        {
            var callRet = _GetAudioMixRate();
            ret = VariantUtils.CreateFrom<uint>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_audio_speaker_mode || method == MethodName._GetAudioSpeakerMode) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_audio_speaker_mode.NativeValue))
        {
            var callRet = _GetAudioSpeakerMode();
            ret = VariantUtils.CreateFrom<AudioServer.SpeakerMode>(callRet);
            return true;
        }
        if ((method == MethodProxyName__handles_file || method == MethodName._HandlesFile) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__handles_file.NativeValue))
        {
            var callRet = _HandlesFile(VariantUtils.ConvertTo<string>(args[0]));
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__write_begin || method == MethodName._WriteBegin) && args.Count == 3 && HasGodotClassMethod((godot_string_name)MethodProxyName__write_begin.NativeValue))
        {
            var callRet = _WriteBegin(VariantUtils.ConvertTo<Vector2I>(args[0]), VariantUtils.ConvertTo<uint>(args[1]), VariantUtils.ConvertTo<string>(args[2]));
            ret = VariantUtils.CreateFrom<Error>(callRet);
            return true;
        }
        if ((method == MethodProxyName__write_end || method == MethodName._WriteEnd) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__write_end.NativeValue))
        {
            _WriteEnd();
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
        if (method == MethodName._GetAudioMixRate)
        {
            if (HasGodotClassMethod(MethodProxyName__get_audio_mix_rate.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetAudioSpeakerMode)
        {
            if (HasGodotClassMethod(MethodProxyName__get_audio_speaker_mode.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._HandlesFile)
        {
            if (HasGodotClassMethod(MethodProxyName__handles_file.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._WriteBegin)
        {
            if (HasGodotClassMethod(MethodProxyName__write_begin.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._WriteEnd)
        {
            if (HasGodotClassMethod(MethodProxyName__write_end.NativeValue.DangerousSelfRef))
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
    public new class PropertyName : GodotObject.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : GodotObject.MethodName
    {
        /// <summary>
        /// Cached name for the '_get_audio_mix_rate' method.
        /// </summary>
        public static readonly StringName _GetAudioMixRate = "_get_audio_mix_rate";
        /// <summary>
        /// Cached name for the '_get_audio_speaker_mode' method.
        /// </summary>
        public static readonly StringName _GetAudioSpeakerMode = "_get_audio_speaker_mode";
        /// <summary>
        /// Cached name for the '_handles_file' method.
        /// </summary>
        public static readonly StringName _HandlesFile = "_handles_file";
        /// <summary>
        /// Cached name for the '_write_begin' method.
        /// </summary>
        public static readonly StringName _WriteBegin = "_write_begin";
        /// <summary>
        /// Cached name for the '_write_end' method.
        /// </summary>
        public static readonly StringName _WriteEnd = "_write_end";
        /// <summary>
        /// Cached name for the 'add_writer' method.
        /// </summary>
        public static readonly StringName AddWriter = "add_writer";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : GodotObject.SignalName
    {
    }
}
