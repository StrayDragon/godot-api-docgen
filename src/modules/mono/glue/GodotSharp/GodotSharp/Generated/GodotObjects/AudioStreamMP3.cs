namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>MP3 audio stream driver. See <see cref="Godot.AudioStreamMP3.Data"/> if you want to load an MP3 file at run-time.</para>
/// <para><b>Note:</b> This class can optionally support legacy MP1 and MP2 formats, provided that the engine is compiled with the <c>minimp3_extra_formats=yes</c> SCons option. These extra formats are not enabled by default.</para>
/// </summary>
public partial class AudioStreamMP3 : AudioStream
{
    /// <summary>
    /// <para>Contains the audio data in bytes.</para>
    /// <para>You can load a file without having to import it beforehand using the code snippet below. Keep in mind that this snippet loads the whole file into memory and may not be ideal for huge files (hundreds of megabytes or more).</para>
    /// <para><code>
    /// public AudioStreamMP3 LoadMP3(string path)
    /// {
    /// 	using var file = FileAccess.Open(path, FileAccess.ModeFlags.Read);
    /// 	var sound = new AudioStreamMP3();
    /// 	sound.Data = file.GetBuffer(file.GetLength());
    /// 	return sound;
    /// }
    /// </code></para>
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

    public double Bpm
    {
        get
        {
            return GetBpm();
        }
        set
        {
            SetBpm(value);
        }
    }

    public int BeatCount
    {
        get
        {
            return GetBeatCount();
        }
        set
        {
            SetBeatCount(value);
        }
    }

    public int BarBeats
    {
        get
        {
            return GetBarBeats();
        }
        set
        {
            SetBarBeats(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the stream will automatically loop when it reaches the end.</para>
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
    /// <para>Time in seconds at which the stream starts after being looped.</para>
    /// </summary>
    public double LoopOffset
    {
        get
        {
            return GetLoopOffset();
        }
        set
        {
            SetLoopOffset(value);
        }
    }

    private static readonly System.Type CachedType = typeof(AudioStreamMP3);

    private static readonly StringName NativeName = "AudioStreamMP3";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public AudioStreamMP3() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal AudioStreamMP3(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal AudioStreamMP3(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.LoadFromBuffer, 1674970313ul);

    /// <summary>
    /// <para>Creates a new <see cref="Godot.AudioStreamMP3"/> instance from the given buffer. The buffer must contain MP3 data.</para>
    /// </summary>
    public static AudioStreamMP3 LoadFromBuffer(byte[] streamData)
    {
        return (AudioStreamMP3)NativeCalls.godot_icall_1_202(MethodBind0, streamData);
    }

    /// <summary>
    /// <para>Creates a new <see cref="Godot.AudioStreamMP3"/> instance from the given buffer. The buffer must contain MP3 data.</para>
    /// </summary>
    public static AudioStreamMP3 LoadFromBuffer(ReadOnlySpan<byte> streamData)
    {
        return (AudioStreamMP3)NativeCalls.godot_icall_1_202(MethodBind0, streamData);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.LoadFromFile, 4238362998ul);

    /// <summary>
    /// <para>Creates a new <see cref="Godot.AudioStreamMP3"/> instance from the given file path. The file must be in MP3 format.</para>
    /// </summary>
    public static AudioStreamMP3 LoadFromFile(string path)
    {
        return (AudioStreamMP3)NativeCalls.godot_icall_1_203(MethodBind1, path);
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
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLoop, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetLoop(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind4, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasLoop, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool HasLoop()
    {
        return NativeCalls.godot_icall_0_15(MethodBind5, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLoopOffset, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetLoopOffset(double seconds)
    {
        NativeCalls.godot_icall_1_127(MethodBind6, GodotObject.GetPtr(this), seconds);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLoopOffset, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public double GetLoopOffset()
    {
        return NativeCalls.godot_icall_0_144(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBpm, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetBpm(double bpm)
    {
        NativeCalls.godot_icall_1_127(MethodBind8, GodotObject.GetPtr(this), bpm);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBpm, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public double GetBpm()
    {
        return NativeCalls.godot_icall_0_144(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBeatCount, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetBeatCount(int count)
    {
        NativeCalls.godot_icall_1_38(MethodBind10, GodotObject.GetPtr(this), count);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBeatCount, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetBeatCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind11, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBarBeats, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetBarBeats(int count)
    {
        NativeCalls.godot_icall_1_38(MethodBind12, GodotObject.GetPtr(this), count);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBarBeats, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetBarBeats()
    {
        return NativeCalls.godot_icall_0_39(MethodBind13, GodotObject.GetPtr(this));
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
        /// Cached name for the 'bpm' property.
        /// </summary>
        public static readonly StringName Bpm = "bpm";
        /// <summary>
        /// Cached name for the 'beat_count' property.
        /// </summary>
        public static readonly StringName BeatCount = "beat_count";
        /// <summary>
        /// Cached name for the 'bar_beats' property.
        /// </summary>
        public static readonly StringName BarBeats = "bar_beats";
        /// <summary>
        /// Cached name for the 'loop' property.
        /// </summary>
        public static readonly StringName Loop = "loop";
        /// <summary>
        /// Cached name for the 'loop_offset' property.
        /// </summary>
        public static readonly StringName LoopOffset = "loop_offset";
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
        /// Cached name for the 'set_loop' method.
        /// </summary>
        public static readonly StringName SetLoop = "set_loop";
        /// <summary>
        /// Cached name for the 'has_loop' method.
        /// </summary>
        public static readonly StringName HasLoop = "has_loop";
        /// <summary>
        /// Cached name for the 'set_loop_offset' method.
        /// </summary>
        public static readonly StringName SetLoopOffset = "set_loop_offset";
        /// <summary>
        /// Cached name for the 'get_loop_offset' method.
        /// </summary>
        public static readonly StringName GetLoopOffset = "get_loop_offset";
        /// <summary>
        /// Cached name for the 'set_bpm' method.
        /// </summary>
        public static readonly StringName SetBpm = "set_bpm";
        /// <summary>
        /// Cached name for the 'get_bpm' method.
        /// </summary>
        public static readonly StringName GetBpm = "get_bpm";
        /// <summary>
        /// Cached name for the 'set_beat_count' method.
        /// </summary>
        public static readonly StringName SetBeatCount = "set_beat_count";
        /// <summary>
        /// Cached name for the 'get_beat_count' method.
        /// </summary>
        public static readonly StringName GetBeatCount = "get_beat_count";
        /// <summary>
        /// Cached name for the 'set_bar_beats' method.
        /// </summary>
        public static readonly StringName SetBarBeats = "set_bar_beats";
        /// <summary>
        /// Cached name for the 'get_bar_beats' method.
        /// </summary>
        public static readonly StringName GetBarBeats = "get_bar_beats";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : AudioStream.SignalName
    {
    }
}
