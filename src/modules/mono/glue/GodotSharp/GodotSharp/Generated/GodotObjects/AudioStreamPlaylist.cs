namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
public partial class AudioStreamPlaylist : AudioStream
{
    /// <summary>
    /// <para>Maximum amount of streams supported in the playlist.</para>
    /// </summary>
    public const long MaxStreams = 64;

    /// <summary>
    /// <para>If <see langword="true"/>, the playlist will shuffle each time playback starts and each time it loops.</para>
    /// </summary>
    public bool Shuffle
    {
        get
        {
            return GetShuffle();
        }
        set
        {
            SetShuffle(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the playlist will loop, otherwise the playlist will end when the last stream is finished.</para>
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
    /// <para>Fade time used when a stream ends, when going to the next one. Streams are expected to have an extra bit of audio after the end to help with fading.</para>
    /// </summary>
    public float FadeTime
    {
        get
        {
            return GetFadeTime();
        }
        set
        {
            SetFadeTime(value);
        }
    }

    /// <summary>
    /// <para>Amount of streams in the playlist.</para>
    /// </summary>
    public int StreamCount
    {
        get
        {
            return GetStreamCount();
        }
        set
        {
            SetStreamCount(value);
        }
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public AudioStream Stream0
    {
        get
        {
            return GetListStream(0);
        }
        set
        {
            SetListStream(0, value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public AudioStream Stream1
    {
        get
        {
            return GetListStream(1);
        }
        set
        {
            SetListStream(1, value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public AudioStream Stream2
    {
        get
        {
            return GetListStream(2);
        }
        set
        {
            SetListStream(2, value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public AudioStream Stream3
    {
        get
        {
            return GetListStream(3);
        }
        set
        {
            SetListStream(3, value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public AudioStream Stream4
    {
        get
        {
            return GetListStream(4);
        }
        set
        {
            SetListStream(4, value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public AudioStream Stream5
    {
        get
        {
            return GetListStream(5);
        }
        set
        {
            SetListStream(5, value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public AudioStream Stream6
    {
        get
        {
            return GetListStream(6);
        }
        set
        {
            SetListStream(6, value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public AudioStream Stream7
    {
        get
        {
            return GetListStream(7);
        }
        set
        {
            SetListStream(7, value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public AudioStream Stream8
    {
        get
        {
            return GetListStream(8);
        }
        set
        {
            SetListStream(8, value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public AudioStream Stream9
    {
        get
        {
            return GetListStream(9);
        }
        set
        {
            SetListStream(9, value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public AudioStream Stream10
    {
        get
        {
            return GetListStream(10);
        }
        set
        {
            SetListStream(10, value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public AudioStream Stream11
    {
        get
        {
            return GetListStream(11);
        }
        set
        {
            SetListStream(11, value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public AudioStream Stream12
    {
        get
        {
            return GetListStream(12);
        }
        set
        {
            SetListStream(12, value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public AudioStream Stream13
    {
        get
        {
            return GetListStream(13);
        }
        set
        {
            SetListStream(13, value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public AudioStream Stream14
    {
        get
        {
            return GetListStream(14);
        }
        set
        {
            SetListStream(14, value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public AudioStream Stream15
    {
        get
        {
            return GetListStream(15);
        }
        set
        {
            SetListStream(15, value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public AudioStream Stream16
    {
        get
        {
            return GetListStream(16);
        }
        set
        {
            SetListStream(16, value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public AudioStream Stream17
    {
        get
        {
            return GetListStream(17);
        }
        set
        {
            SetListStream(17, value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public AudioStream Stream18
    {
        get
        {
            return GetListStream(18);
        }
        set
        {
            SetListStream(18, value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public AudioStream Stream19
    {
        get
        {
            return GetListStream(19);
        }
        set
        {
            SetListStream(19, value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public AudioStream Stream20
    {
        get
        {
            return GetListStream(20);
        }
        set
        {
            SetListStream(20, value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public AudioStream Stream21
    {
        get
        {
            return GetListStream(21);
        }
        set
        {
            SetListStream(21, value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public AudioStream Stream22
    {
        get
        {
            return GetListStream(22);
        }
        set
        {
            SetListStream(22, value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public AudioStream Stream23
    {
        get
        {
            return GetListStream(23);
        }
        set
        {
            SetListStream(23, value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public AudioStream Stream24
    {
        get
        {
            return GetListStream(24);
        }
        set
        {
            SetListStream(24, value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public AudioStream Stream25
    {
        get
        {
            return GetListStream(25);
        }
        set
        {
            SetListStream(25, value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public AudioStream Stream26
    {
        get
        {
            return GetListStream(26);
        }
        set
        {
            SetListStream(26, value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public AudioStream Stream27
    {
        get
        {
            return GetListStream(27);
        }
        set
        {
            SetListStream(27, value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public AudioStream Stream28
    {
        get
        {
            return GetListStream(28);
        }
        set
        {
            SetListStream(28, value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public AudioStream Stream29
    {
        get
        {
            return GetListStream(29);
        }
        set
        {
            SetListStream(29, value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public AudioStream Stream30
    {
        get
        {
            return GetListStream(30);
        }
        set
        {
            SetListStream(30, value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public AudioStream Stream31
    {
        get
        {
            return GetListStream(31);
        }
        set
        {
            SetListStream(31, value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public AudioStream Stream32
    {
        get
        {
            return GetListStream(32);
        }
        set
        {
            SetListStream(32, value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public AudioStream Stream33
    {
        get
        {
            return GetListStream(33);
        }
        set
        {
            SetListStream(33, value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public AudioStream Stream34
    {
        get
        {
            return GetListStream(34);
        }
        set
        {
            SetListStream(34, value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public AudioStream Stream35
    {
        get
        {
            return GetListStream(35);
        }
        set
        {
            SetListStream(35, value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public AudioStream Stream36
    {
        get
        {
            return GetListStream(36);
        }
        set
        {
            SetListStream(36, value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public AudioStream Stream37
    {
        get
        {
            return GetListStream(37);
        }
        set
        {
            SetListStream(37, value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public AudioStream Stream38
    {
        get
        {
            return GetListStream(38);
        }
        set
        {
            SetListStream(38, value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public AudioStream Stream39
    {
        get
        {
            return GetListStream(39);
        }
        set
        {
            SetListStream(39, value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public AudioStream Stream40
    {
        get
        {
            return GetListStream(40);
        }
        set
        {
            SetListStream(40, value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public AudioStream Stream41
    {
        get
        {
            return GetListStream(41);
        }
        set
        {
            SetListStream(41, value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public AudioStream Stream42
    {
        get
        {
            return GetListStream(42);
        }
        set
        {
            SetListStream(42, value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public AudioStream Stream43
    {
        get
        {
            return GetListStream(43);
        }
        set
        {
            SetListStream(43, value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public AudioStream Stream44
    {
        get
        {
            return GetListStream(44);
        }
        set
        {
            SetListStream(44, value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public AudioStream Stream45
    {
        get
        {
            return GetListStream(45);
        }
        set
        {
            SetListStream(45, value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public AudioStream Stream46
    {
        get
        {
            return GetListStream(46);
        }
        set
        {
            SetListStream(46, value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public AudioStream Stream47
    {
        get
        {
            return GetListStream(47);
        }
        set
        {
            SetListStream(47, value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public AudioStream Stream48
    {
        get
        {
            return GetListStream(48);
        }
        set
        {
            SetListStream(48, value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public AudioStream Stream49
    {
        get
        {
            return GetListStream(49);
        }
        set
        {
            SetListStream(49, value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public AudioStream Stream50
    {
        get
        {
            return GetListStream(50);
        }
        set
        {
            SetListStream(50, value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public AudioStream Stream51
    {
        get
        {
            return GetListStream(51);
        }
        set
        {
            SetListStream(51, value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public AudioStream Stream52
    {
        get
        {
            return GetListStream(52);
        }
        set
        {
            SetListStream(52, value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public AudioStream Stream53
    {
        get
        {
            return GetListStream(53);
        }
        set
        {
            SetListStream(53, value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public AudioStream Stream54
    {
        get
        {
            return GetListStream(54);
        }
        set
        {
            SetListStream(54, value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public AudioStream Stream55
    {
        get
        {
            return GetListStream(55);
        }
        set
        {
            SetListStream(55, value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public AudioStream Stream56
    {
        get
        {
            return GetListStream(56);
        }
        set
        {
            SetListStream(56, value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public AudioStream Stream57
    {
        get
        {
            return GetListStream(57);
        }
        set
        {
            SetListStream(57, value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public AudioStream Stream58
    {
        get
        {
            return GetListStream(58);
        }
        set
        {
            SetListStream(58, value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public AudioStream Stream59
    {
        get
        {
            return GetListStream(59);
        }
        set
        {
            SetListStream(59, value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public AudioStream Stream60
    {
        get
        {
            return GetListStream(60);
        }
        set
        {
            SetListStream(60, value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public AudioStream Stream61
    {
        get
        {
            return GetListStream(61);
        }
        set
        {
            SetListStream(61, value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public AudioStream Stream62
    {
        get
        {
            return GetListStream(62);
        }
        set
        {
            SetListStream(62, value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public AudioStream Stream63
    {
        get
        {
            return GetListStream(63);
        }
        set
        {
            SetListStream(63, value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    private static readonly System.Type CachedType = typeof(AudioStreamPlaylist);

    private static readonly StringName NativeName = "AudioStreamPlaylist";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public AudioStreamPlaylist() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal AudioStreamPlaylist(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal AudioStreamPlaylist(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetStreamCount, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetStreamCount(int streamCount)
    {
        NativeCalls.godot_icall_1_38(MethodBind0, GodotObject.GetPtr(this), streamCount);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetStreamCount, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetStreamCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBpm, 1740695150ul);

    /// <summary>
    /// <para>Returns the BPM of the playlist, which can vary depending on the clip being played.</para>
    /// </summary>
    public double GetBpm()
    {
        return NativeCalls.godot_icall_0_144(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetListStream, 111075094ul);

    /// <summary>
    /// <para>Sets the stream at playback position index.</para>
    /// </summary>
    public void SetListStream(int streamIndex, AudioStream audioStream)
    {
        NativeCalls.godot_icall_2_70(MethodBind3, GodotObject.GetPtr(this), streamIndex, GodotObject.GetPtr(audioStream));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetListStream, 2739380747ul);

    /// <summary>
    /// <para>Returns the stream at playback position index.</para>
    /// </summary>
    public AudioStream GetListStream(int streamIndex)
    {
        return (AudioStream)NativeCalls.godot_icall_1_71(MethodBind4, GodotObject.GetPtr(this), streamIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetShuffle, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetShuffle(bool shuffle)
    {
        NativeCalls.godot_icall_1_14(MethodBind5, GodotObject.GetPtr(this), shuffle.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetShuffle, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetShuffle()
    {
        return NativeCalls.godot_icall_0_15(MethodBind6, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFadeTime, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFadeTime(float dec)
    {
        NativeCalls.godot_icall_1_67(MethodBind7, GodotObject.GetPtr(this), dec);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFadeTime, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetFadeTime()
    {
        return NativeCalls.godot_icall_0_68(MethodBind8, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLoop, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetLoop(bool loop)
    {
        NativeCalls.godot_icall_1_14(MethodBind9, GodotObject.GetPtr(this), loop.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasLoop, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool HasLoop()
    {
        return NativeCalls.godot_icall_0_15(MethodBind10, GodotObject.GetPtr(this)).ToBool();
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
        /// Cached name for the 'shuffle' property.
        /// </summary>
        public static readonly StringName Shuffle = "shuffle";
        /// <summary>
        /// Cached name for the 'loop' property.
        /// </summary>
        public static readonly StringName Loop = "loop";
        /// <summary>
        /// Cached name for the 'fade_time' property.
        /// </summary>
        public static readonly StringName FadeTime = "fade_time";
        /// <summary>
        /// Cached name for the 'stream_count' property.
        /// </summary>
        public static readonly StringName StreamCount = "stream_count";
        /// <summary>
        /// Cached name for the 'stream_0' property.
        /// </summary>
        public static readonly StringName Stream0 = "stream_0";
        /// <summary>
        /// Cached name for the 'stream_1' property.
        /// </summary>
        public static readonly StringName Stream1 = "stream_1";
        /// <summary>
        /// Cached name for the 'stream_2' property.
        /// </summary>
        public static readonly StringName Stream2 = "stream_2";
        /// <summary>
        /// Cached name for the 'stream_3' property.
        /// </summary>
        public static readonly StringName Stream3 = "stream_3";
        /// <summary>
        /// Cached name for the 'stream_4' property.
        /// </summary>
        public static readonly StringName Stream4 = "stream_4";
        /// <summary>
        /// Cached name for the 'stream_5' property.
        /// </summary>
        public static readonly StringName Stream5 = "stream_5";
        /// <summary>
        /// Cached name for the 'stream_6' property.
        /// </summary>
        public static readonly StringName Stream6 = "stream_6";
        /// <summary>
        /// Cached name for the 'stream_7' property.
        /// </summary>
        public static readonly StringName Stream7 = "stream_7";
        /// <summary>
        /// Cached name for the 'stream_8' property.
        /// </summary>
        public static readonly StringName Stream8 = "stream_8";
        /// <summary>
        /// Cached name for the 'stream_9' property.
        /// </summary>
        public static readonly StringName Stream9 = "stream_9";
        /// <summary>
        /// Cached name for the 'stream_10' property.
        /// </summary>
        public static readonly StringName Stream10 = "stream_10";
        /// <summary>
        /// Cached name for the 'stream_11' property.
        /// </summary>
        public static readonly StringName Stream11 = "stream_11";
        /// <summary>
        /// Cached name for the 'stream_12' property.
        /// </summary>
        public static readonly StringName Stream12 = "stream_12";
        /// <summary>
        /// Cached name for the 'stream_13' property.
        /// </summary>
        public static readonly StringName Stream13 = "stream_13";
        /// <summary>
        /// Cached name for the 'stream_14' property.
        /// </summary>
        public static readonly StringName Stream14 = "stream_14";
        /// <summary>
        /// Cached name for the 'stream_15' property.
        /// </summary>
        public static readonly StringName Stream15 = "stream_15";
        /// <summary>
        /// Cached name for the 'stream_16' property.
        /// </summary>
        public static readonly StringName Stream16 = "stream_16";
        /// <summary>
        /// Cached name for the 'stream_17' property.
        /// </summary>
        public static readonly StringName Stream17 = "stream_17";
        /// <summary>
        /// Cached name for the 'stream_18' property.
        /// </summary>
        public static readonly StringName Stream18 = "stream_18";
        /// <summary>
        /// Cached name for the 'stream_19' property.
        /// </summary>
        public static readonly StringName Stream19 = "stream_19";
        /// <summary>
        /// Cached name for the 'stream_20' property.
        /// </summary>
        public static readonly StringName Stream20 = "stream_20";
        /// <summary>
        /// Cached name for the 'stream_21' property.
        /// </summary>
        public static readonly StringName Stream21 = "stream_21";
        /// <summary>
        /// Cached name for the 'stream_22' property.
        /// </summary>
        public static readonly StringName Stream22 = "stream_22";
        /// <summary>
        /// Cached name for the 'stream_23' property.
        /// </summary>
        public static readonly StringName Stream23 = "stream_23";
        /// <summary>
        /// Cached name for the 'stream_24' property.
        /// </summary>
        public static readonly StringName Stream24 = "stream_24";
        /// <summary>
        /// Cached name for the 'stream_25' property.
        /// </summary>
        public static readonly StringName Stream25 = "stream_25";
        /// <summary>
        /// Cached name for the 'stream_26' property.
        /// </summary>
        public static readonly StringName Stream26 = "stream_26";
        /// <summary>
        /// Cached name for the 'stream_27' property.
        /// </summary>
        public static readonly StringName Stream27 = "stream_27";
        /// <summary>
        /// Cached name for the 'stream_28' property.
        /// </summary>
        public static readonly StringName Stream28 = "stream_28";
        /// <summary>
        /// Cached name for the 'stream_29' property.
        /// </summary>
        public static readonly StringName Stream29 = "stream_29";
        /// <summary>
        /// Cached name for the 'stream_30' property.
        /// </summary>
        public static readonly StringName Stream30 = "stream_30";
        /// <summary>
        /// Cached name for the 'stream_31' property.
        /// </summary>
        public static readonly StringName Stream31 = "stream_31";
        /// <summary>
        /// Cached name for the 'stream_32' property.
        /// </summary>
        public static readonly StringName Stream32 = "stream_32";
        /// <summary>
        /// Cached name for the 'stream_33' property.
        /// </summary>
        public static readonly StringName Stream33 = "stream_33";
        /// <summary>
        /// Cached name for the 'stream_34' property.
        /// </summary>
        public static readonly StringName Stream34 = "stream_34";
        /// <summary>
        /// Cached name for the 'stream_35' property.
        /// </summary>
        public static readonly StringName Stream35 = "stream_35";
        /// <summary>
        /// Cached name for the 'stream_36' property.
        /// </summary>
        public static readonly StringName Stream36 = "stream_36";
        /// <summary>
        /// Cached name for the 'stream_37' property.
        /// </summary>
        public static readonly StringName Stream37 = "stream_37";
        /// <summary>
        /// Cached name for the 'stream_38' property.
        /// </summary>
        public static readonly StringName Stream38 = "stream_38";
        /// <summary>
        /// Cached name for the 'stream_39' property.
        /// </summary>
        public static readonly StringName Stream39 = "stream_39";
        /// <summary>
        /// Cached name for the 'stream_40' property.
        /// </summary>
        public static readonly StringName Stream40 = "stream_40";
        /// <summary>
        /// Cached name for the 'stream_41' property.
        /// </summary>
        public static readonly StringName Stream41 = "stream_41";
        /// <summary>
        /// Cached name for the 'stream_42' property.
        /// </summary>
        public static readonly StringName Stream42 = "stream_42";
        /// <summary>
        /// Cached name for the 'stream_43' property.
        /// </summary>
        public static readonly StringName Stream43 = "stream_43";
        /// <summary>
        /// Cached name for the 'stream_44' property.
        /// </summary>
        public static readonly StringName Stream44 = "stream_44";
        /// <summary>
        /// Cached name for the 'stream_45' property.
        /// </summary>
        public static readonly StringName Stream45 = "stream_45";
        /// <summary>
        /// Cached name for the 'stream_46' property.
        /// </summary>
        public static readonly StringName Stream46 = "stream_46";
        /// <summary>
        /// Cached name for the 'stream_47' property.
        /// </summary>
        public static readonly StringName Stream47 = "stream_47";
        /// <summary>
        /// Cached name for the 'stream_48' property.
        /// </summary>
        public static readonly StringName Stream48 = "stream_48";
        /// <summary>
        /// Cached name for the 'stream_49' property.
        /// </summary>
        public static readonly StringName Stream49 = "stream_49";
        /// <summary>
        /// Cached name for the 'stream_50' property.
        /// </summary>
        public static readonly StringName Stream50 = "stream_50";
        /// <summary>
        /// Cached name for the 'stream_51' property.
        /// </summary>
        public static readonly StringName Stream51 = "stream_51";
        /// <summary>
        /// Cached name for the 'stream_52' property.
        /// </summary>
        public static readonly StringName Stream52 = "stream_52";
        /// <summary>
        /// Cached name for the 'stream_53' property.
        /// </summary>
        public static readonly StringName Stream53 = "stream_53";
        /// <summary>
        /// Cached name for the 'stream_54' property.
        /// </summary>
        public static readonly StringName Stream54 = "stream_54";
        /// <summary>
        /// Cached name for the 'stream_55' property.
        /// </summary>
        public static readonly StringName Stream55 = "stream_55";
        /// <summary>
        /// Cached name for the 'stream_56' property.
        /// </summary>
        public static readonly StringName Stream56 = "stream_56";
        /// <summary>
        /// Cached name for the 'stream_57' property.
        /// </summary>
        public static readonly StringName Stream57 = "stream_57";
        /// <summary>
        /// Cached name for the 'stream_58' property.
        /// </summary>
        public static readonly StringName Stream58 = "stream_58";
        /// <summary>
        /// Cached name for the 'stream_59' property.
        /// </summary>
        public static readonly StringName Stream59 = "stream_59";
        /// <summary>
        /// Cached name for the 'stream_60' property.
        /// </summary>
        public static readonly StringName Stream60 = "stream_60";
        /// <summary>
        /// Cached name for the 'stream_61' property.
        /// </summary>
        public static readonly StringName Stream61 = "stream_61";
        /// <summary>
        /// Cached name for the 'stream_62' property.
        /// </summary>
        public static readonly StringName Stream62 = "stream_62";
        /// <summary>
        /// Cached name for the 'stream_63' property.
        /// </summary>
        public static readonly StringName Stream63 = "stream_63";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : AudioStream.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_stream_count' method.
        /// </summary>
        public static readonly StringName SetStreamCount = "set_stream_count";
        /// <summary>
        /// Cached name for the 'get_stream_count' method.
        /// </summary>
        public static readonly StringName GetStreamCount = "get_stream_count";
        /// <summary>
        /// Cached name for the 'get_bpm' method.
        /// </summary>
        public static readonly StringName GetBpm = "get_bpm";
        /// <summary>
        /// Cached name for the 'set_list_stream' method.
        /// </summary>
        public static readonly StringName SetListStream = "set_list_stream";
        /// <summary>
        /// Cached name for the 'get_list_stream' method.
        /// </summary>
        public static readonly StringName GetListStream = "get_list_stream";
        /// <summary>
        /// Cached name for the 'set_shuffle' method.
        /// </summary>
        public static readonly StringName SetShuffle = "set_shuffle";
        /// <summary>
        /// Cached name for the 'get_shuffle' method.
        /// </summary>
        public static readonly StringName GetShuffle = "get_shuffle";
        /// <summary>
        /// Cached name for the 'set_fade_time' method.
        /// </summary>
        public static readonly StringName SetFadeTime = "set_fade_time";
        /// <summary>
        /// Cached name for the 'get_fade_time' method.
        /// </summary>
        public static readonly StringName GetFadeTime = "get_fade_time";
        /// <summary>
        /// Cached name for the 'set_loop' method.
        /// </summary>
        public static readonly StringName SetLoop = "set_loop";
        /// <summary>
        /// Cached name for the 'has_loop' method.
        /// </summary>
        public static readonly StringName HasLoop = "has_loop";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : AudioStream.SignalName
    {
    }
}
