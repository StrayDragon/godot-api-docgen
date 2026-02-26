namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>AudioStreamWAV stores sound samples loaded from WAV files. To play the stored sound, use an <see cref="Godot.AudioStreamPlayer"/> (for non-positional audio) or <see cref="Godot.AudioStreamPlayer2D"/>/<see cref="Godot.AudioStreamPlayer3D"/> (for positional audio). The sound can be looped.</para>
/// <para>This class can also be used to store dynamically-generated PCM audio data. See also <see cref="Godot.AudioStreamGenerator"/> for procedural audio generation.</para>
/// </summary>
[GodotClassName("AudioStreamWAV")]
public partial class AudioStreamWav : AudioStream
{
    public enum FormatEnum : long
    {
        /// <summary>
        /// <para>8-bit PCM audio codec.</para>
        /// </summary>
        Format8Bits = 0,
        /// <summary>
        /// <para>16-bit PCM audio codec.</para>
        /// </summary>
        Format16Bits = 1,
        /// <summary>
        /// <para>Audio is lossily compressed as IMA ADPCM.</para>
        /// </summary>
        ImaAdpcm = 2,
        /// <summary>
        /// <para>Audio is lossily compressed as <a href="https://qoaformat.org/">Quite OK Audio</a>.</para>
        /// </summary>
        Qoa = 3
    }

    public enum LoopModeEnum : long
    {
        /// <summary>
        /// <para>Audio does not loop.</para>
        /// </summary>
        Disabled = 0,
        /// <summary>
        /// <para>Audio loops the data between <see cref="Godot.AudioStreamWav.LoopBegin"/> and <see cref="Godot.AudioStreamWav.LoopEnd"/>, playing forward only.</para>
        /// </summary>
        Forward = 1,
        /// <summary>
        /// <para>Audio loops the data between <see cref="Godot.AudioStreamWav.LoopBegin"/> and <see cref="Godot.AudioStreamWav.LoopEnd"/>, playing back and forth.</para>
        /// </summary>
        Pingpong = 2,
        /// <summary>
        /// <para>Audio loops the data between <see cref="Godot.AudioStreamWav.LoopBegin"/> and <see cref="Godot.AudioStreamWav.LoopEnd"/>, playing backward only.</para>
        /// </summary>
        Backward = 3
    }

    /// <summary>
    /// <para>Contains the audio data in bytes.</para>
    /// <para><b>Note:</b> If <see cref="Godot.AudioStreamWav.Format"/> is set to <see cref="Godot.AudioStreamWav.FormatEnum.Format8Bits"/>, this property expects signed 8-bit PCM data. To convert from unsigned 8-bit PCM, subtract 128 from each byte.</para>
    /// <para><b>Note:</b> If <see cref="Godot.AudioStreamWav.Format"/> is set to <see cref="Godot.AudioStreamWav.FormatEnum.Qoa"/>, this property expects data from a full QOA file.</para>
    /// </summary>
    public byte[] Data
    {
        get
        {
            return GetData();
        }
        set
        {
            SetData(value);
        }
    }

    /// <summary>
    /// <para>Audio format.</para>
    /// </summary>
    public AudioStreamWav.FormatEnum Format
    {
        get
        {
            return GetFormat();
        }
        set
        {
            SetFormat(value);
        }
    }

    /// <summary>
    /// <para>The loop mode.</para>
    /// </summary>
    public AudioStreamWav.LoopModeEnum LoopMode
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
    /// <para>The loop start point (in number of samples, relative to the beginning of the stream).</para>
    /// </summary>
    public int LoopBegin
    {
        get
        {
            return GetLoopBegin();
        }
        set
        {
            SetLoopBegin(value);
        }
    }

    /// <summary>
    /// <para>The loop end point (in number of samples, relative to the beginning of the stream).</para>
    /// </summary>
    public int LoopEnd
    {
        get
        {
            return GetLoopEnd();
        }
        set
        {
            SetLoopEnd(value);
        }
    }

    /// <summary>
    /// <para>The sample rate for mixing this audio. Higher values require more storage space, but result in better quality.</para>
    /// <para>In games, common sample rates in use are <c>11025</c>, <c>16000</c>, <c>22050</c>, <c>32000</c>, <c>44100</c>, and <c>48000</c>.</para>
    /// <para>According to the <a href="https://en.wikipedia.org/wiki/Nyquist%E2%80%93Shannon_sampling_theorem">Nyquist-Shannon sampling theorem</a>, there is no quality difference to human hearing when going past 40,000 Hz (since most humans can only hear up to ~20,000 Hz, often less). If you are using lower-pitched sounds such as voices, lower sample rates such as <c>32000</c> or <c>22050</c> may be usable with no loss in quality.</para>
    /// </summary>
    public int MixRate
    {
        get
        {
            return GetMixRate();
        }
        set
        {
            SetMixRate(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, audio is stereo.</para>
    /// </summary>
    public bool Stereo
    {
        get
        {
            return IsStereo();
        }
        set
        {
            SetStereo(value);
        }
    }

    /// <summary>
    /// <para>Contains user-defined tags if found in the WAV data.</para>
    /// <para>Commonly used tags include <c>title</c>, <c>artist</c>, <c>album</c>, <c>tracknumber</c>, and <c>date</c> (<c>date</c> does not have a standard date format).</para>
    /// <para><b>Note:</b> No tag is <i>guaranteed</i> to be present in every file, so make sure to account for the keys not always existing.</para>
    /// <para><b>Note:</b> Only WAV files using a <c>LIST</c> chunk with an identifier of <c>INFO</c> to encode the tags are currently supported.</para>
    /// </summary>
    public Godot.Collections.Dictionary Tags
    {
        get
        {
            return GetTags();
        }
        set
        {
            SetTags(value);
        }
    }

    private static readonly System.Type CachedType = typeof(AudioStreamWav);

    private static readonly StringName NativeName = "AudioStreamWAV";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public AudioStreamWav() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal AudioStreamWav(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal AudioStreamWav(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.LoadFromBuffer, 4266838938ul);

    /// <summary>
    /// <para>Creates a new <see cref="Godot.AudioStreamWav"/> instance from the given buffer. The buffer must contain WAV data.</para>
    /// <para>The keys and values of <paramref name="options"/> match the properties of <c>ResourceImporterWav</c>. The usage of <paramref name="options"/> is identical to <see cref="Godot.AudioStreamWav.LoadFromFile(string, Godot.Collections.Dictionary)"/>.</para>
    /// </summary>
    public static AudioStreamWav LoadFromBuffer(byte[] streamData, Godot.Collections.Dictionary options = null)
    {
        return (AudioStreamWav)NativeCalls.godot_icall_2_211(MethodBind0, streamData, (godot_dictionary)(options ?? new()).NativeValue);
    }

    /// <summary>
    /// <para>Creates a new <see cref="Godot.AudioStreamWav"/> instance from the given buffer. The buffer must contain WAV data.</para>
    /// <para>The keys and values of <paramref name="options"/> match the properties of <c>ResourceImporterWav</c>. The usage of <paramref name="options"/> is identical to <see cref="Godot.AudioStreamWav.LoadFromFile(string, Godot.Collections.Dictionary)"/>.</para>
    /// </summary>
    public static AudioStreamWav LoadFromBuffer(ReadOnlySpan<byte> streamData, Godot.Collections.Dictionary options)
    {
        return (AudioStreamWav)NativeCalls.godot_icall_2_211(MethodBind0, streamData, (godot_dictionary)(options ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.LoadFromFile, 4015802384ul);

    /// <summary>
    /// <para>Creates a new <see cref="Godot.AudioStreamWav"/> instance from the given file path. The file must be in WAV format.</para>
    /// <para>The keys and values of <paramref name="options"/> match the properties of <c>ResourceImporterWav</c>.</para>
    /// <para><b>Example:</b> Load the first file dropped as a WAV and play it:</para>
    /// <para><code>
    /// @onready var audio_player = $AudioStreamPlayer
    /// 
    /// func _ready():
    /// 	get_window().files_dropped.connect(_on_files_dropped)
    /// 
    /// func _on_files_dropped(files):
    /// 	if files[0].get_extension() == "wav":
    /// 		audio_player.stream = AudioStreamWAV.load_from_file(files[0], {
    /// 				"force/max_rate": true,
    /// 				"force/max_rate_hz": 11025
    /// 			})
    /// 		audio_player.play()
    /// </code></para>
    /// </summary>
    public static AudioStreamWav LoadFromFile(string path, Godot.Collections.Dictionary options = null)
    {
        return (AudioStreamWav)NativeCalls.godot_icall_2_212(MethodBind1, path, (godot_dictionary)(options ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetData, 2971499966ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetData(byte[] data)
    {
        NativeCalls.godot_icall_1_204(MethodBind2, GodotObject.GetPtr(this), data);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetData(ReadOnlySpan<byte> data)
    {
        NativeCalls.godot_icall_1_204(MethodBind2, GodotObject.GetPtr(this), data);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetData, 2362200018ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public byte[] GetData()
    {
        return NativeCalls.godot_icall_0_2(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFormat, 60648488ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFormat(AudioStreamWav.FormatEnum format)
    {
        NativeCalls.godot_icall_1_38(MethodBind4, GodotObject.GetPtr(this), (int)format);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFormat, 3151724922ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public AudioStreamWav.FormatEnum GetFormat()
    {
        return (AudioStreamWav.FormatEnum)NativeCalls.godot_icall_0_39(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLoopMode, 2444882972ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetLoopMode(AudioStreamWav.LoopModeEnum loopMode)
    {
        NativeCalls.godot_icall_1_38(MethodBind6, GodotObject.GetPtr(this), (int)loopMode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLoopMode, 393560655ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public AudioStreamWav.LoopModeEnum GetLoopMode()
    {
        return (AudioStreamWav.LoopModeEnum)NativeCalls.godot_icall_0_39(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLoopBegin, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetLoopBegin(int loopBegin)
    {
        NativeCalls.godot_icall_1_38(MethodBind8, GodotObject.GetPtr(this), loopBegin);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLoopBegin, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetLoopBegin()
    {
        return NativeCalls.godot_icall_0_39(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLoopEnd, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetLoopEnd(int loopEnd)
    {
        NativeCalls.godot_icall_1_38(MethodBind10, GodotObject.GetPtr(this), loopEnd);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLoopEnd, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetLoopEnd()
    {
        return NativeCalls.godot_icall_0_39(MethodBind11, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMixRate, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMixRate(int mixRate)
    {
        NativeCalls.godot_icall_1_38(MethodBind12, GodotObject.GetPtr(this), mixRate);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMixRate, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetMixRate()
    {
        return NativeCalls.godot_icall_0_39(MethodBind13, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetStereo, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetStereo(bool stereo)
    {
        NativeCalls.godot_icall_1_14(MethodBind14, GodotObject.GetPtr(this), stereo.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsStereo, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsStereo()
    {
        return NativeCalls.godot_icall_0_15(MethodBind15, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTags, 4155329257ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTags(Godot.Collections.Dictionary tags)
    {
        NativeCalls.godot_icall_1_121(MethodBind16, GodotObject.GetPtr(this), (godot_dictionary)(tags ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTags, 3102165223ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Godot.Collections.Dictionary GetTags()
    {
        return NativeCalls.godot_icall_0_122(MethodBind17, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SaveToWav, 166001499ul);

    /// <summary>
    /// <para>Saves the AudioStreamWAV as a WAV file to <paramref name="path"/>. Samples with IMA ADPCM or Quite OK Audio formats can't be saved.</para>
    /// <para><b>Note:</b> A <c>.wav</c> extension is automatically appended to <paramref name="path"/> if it is missing.</para>
    /// </summary>
    public Error SaveToWav(string path)
    {
        return (Error)NativeCalls.godot_icall_1_134(MethodBind18, GodotObject.GetPtr(this), path);
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
        /// Cached name for the 'data' property.
        /// </summary>
        public static readonly StringName Data = "data";
        /// <summary>
        /// Cached name for the 'format' property.
        /// </summary>
        public static readonly StringName Format = "format";
        /// <summary>
        /// Cached name for the 'loop_mode' property.
        /// </summary>
        public static readonly StringName LoopMode = "loop_mode";
        /// <summary>
        /// Cached name for the 'loop_begin' property.
        /// </summary>
        public static readonly StringName LoopBegin = "loop_begin";
        /// <summary>
        /// Cached name for the 'loop_end' property.
        /// </summary>
        public static readonly StringName LoopEnd = "loop_end";
        /// <summary>
        /// Cached name for the 'mix_rate' property.
        /// </summary>
        public static readonly StringName MixRate = "mix_rate";
        /// <summary>
        /// Cached name for the 'stereo' property.
        /// </summary>
        public static readonly StringName Stereo = "stereo";
        /// <summary>
        /// Cached name for the 'tags' property.
        /// </summary>
        public static readonly StringName Tags = "tags";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : AudioStream.MethodName
    {
        /// <summary>
        /// Cached name for the 'load_from_buffer' method.
        /// </summary>
        public static readonly StringName LoadFromBuffer = "load_from_buffer";
        /// <summary>
        /// Cached name for the 'load_from_file' method.
        /// </summary>
        public static readonly StringName LoadFromFile = "load_from_file";
        /// <summary>
        /// Cached name for the 'set_data' method.
        /// </summary>
        public static readonly StringName SetData = "set_data";
        /// <summary>
        /// Cached name for the 'get_data' method.
        /// </summary>
        public static readonly StringName GetData = "get_data";
        /// <summary>
        /// Cached name for the 'set_format' method.
        /// </summary>
        public static readonly StringName SetFormat = "set_format";
        /// <summary>
        /// Cached name for the 'get_format' method.
        /// </summary>
        public static readonly StringName GetFormat = "get_format";
        /// <summary>
        /// Cached name for the 'set_loop_mode' method.
        /// </summary>
        public static readonly StringName SetLoopMode = "set_loop_mode";
        /// <summary>
        /// Cached name for the 'get_loop_mode' method.
        /// </summary>
        public static readonly StringName GetLoopMode = "get_loop_mode";
        /// <summary>
        /// Cached name for the 'set_loop_begin' method.
        /// </summary>
        public static readonly StringName SetLoopBegin = "set_loop_begin";
        /// <summary>
        /// Cached name for the 'get_loop_begin' method.
        /// </summary>
        public static readonly StringName GetLoopBegin = "get_loop_begin";
        /// <summary>
        /// Cached name for the 'set_loop_end' method.
        /// </summary>
        public static readonly StringName SetLoopEnd = "set_loop_end";
        /// <summary>
        /// Cached name for the 'get_loop_end' method.
        /// </summary>
        public static readonly StringName GetLoopEnd = "get_loop_end";
        /// <summary>
        /// Cached name for the 'set_mix_rate' method.
        /// </summary>
        public static readonly StringName SetMixRate = "set_mix_rate";
        /// <summary>
        /// Cached name for the 'get_mix_rate' method.
        /// </summary>
        public static readonly StringName GetMixRate = "get_mix_rate";
        /// <summary>
        /// Cached name for the 'set_stereo' method.
        /// </summary>
        public static readonly StringName SetStereo = "set_stereo";
        /// <summary>
        /// Cached name for the 'is_stereo' method.
        /// </summary>
        public static readonly StringName IsStereo = "is_stereo";
        /// <summary>
        /// Cached name for the 'set_tags' method.
        /// </summary>
        public static readonly StringName SetTags = "set_tags";
        /// <summary>
        /// Cached name for the 'get_tags' method.
        /// </summary>
        public static readonly StringName GetTags = "get_tags";
        /// <summary>
        /// Cached name for the 'save_to_wav' method.
        /// </summary>
        public static readonly StringName SaveToWav = "save_to_wav";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : AudioStream.SignalName
    {
    }
}
