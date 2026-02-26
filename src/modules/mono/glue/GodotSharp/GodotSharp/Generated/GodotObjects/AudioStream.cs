namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Base class for audio streams. Audio streams are used for sound effects and music playback, and support WAV (via <see cref="Godot.AudioStreamWav"/>) and Ogg (via <see cref="Godot.AudioStreamOggVorbis"/>) file formats.</para>
/// </summary>
public partial class AudioStream : Resource
{
    private static readonly System.Type CachedType = typeof(AudioStream);

    private static readonly StringName NativeName = "AudioStream";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public AudioStream() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal AudioStream(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal AudioStream(bool memoryOwn) : base(memoryOwn) { }

    /// <summary>
    /// <para>Override this method to return the bar beats of this stream.</para>
    /// </summary>
    public virtual int _GetBarBeats()
    {
        return default;
    }

    /// <summary>
    /// <para>Overridable method. Should return the total number of beats of this audio stream. Used by the engine to determine the position of every beat.</para>
    /// <para>Ideally, the returned value should be based off the stream's sample rate (<see cref="Godot.AudioStreamWav.MixRate"/>, for example).</para>
    /// </summary>
    public virtual int _GetBeatCount()
    {
        return default;
    }

    /// <summary>
    /// <para>Overridable method. Should return the tempo of this audio stream, in beats per minute (BPM). Used by the engine to determine the position of every beat.</para>
    /// <para>Ideally, the returned value should be based off the stream's sample rate (<see cref="Godot.AudioStreamWav.MixRate"/>, for example).</para>
    /// </summary>
    public virtual double _GetBpm()
    {
        return default;
    }

    /// <summary>
    /// <para>Override this method to customize the returned value of <see cref="Godot.AudioStream.GetLength()"/>. Should return the length of this audio stream, in seconds.</para>
    /// </summary>
    public virtual double _GetLength()
    {
        return default;
    }

    /// <summary>
    /// <para>Return the controllable parameters of this stream. This array contains dictionaries with a property info description format (see <see cref="Godot.GodotObject.GetPropertyList()"/>). Additionally, the default value for this parameter must be added tho each dictionary in "default_value" field.</para>
    /// </summary>
    public virtual Godot.Collections.Array<Godot.Collections.Dictionary> _GetParameterList()
    {
        return default;
    }

    /// <summary>
    /// <para>Override this method to customize the name assigned to this audio stream. Unused by the engine.</para>
    /// </summary>
    public virtual string _GetStreamName()
    {
        return default;
    }

    /// <summary>
    /// <para>Override this method to customize the tags for this audio stream. Should return a <see cref="Godot.Collections.Dictionary"/> of strings with the tag as the key and its content as the value.</para>
    /// <para>Commonly used tags include <c>title</c>, <c>artist</c>, <c>album</c>, <c>tracknumber</c>, and <c>date</c>.</para>
    /// </summary>
    public virtual Godot.Collections.Dictionary _GetTags()
    {
        return default;
    }

    /// <summary>
    /// <para>Override this method to return <see langword="true"/> if this stream has a loop.</para>
    /// </summary>
    public virtual bool _HasLoop()
    {
        return default;
    }

    /// <summary>
    /// <para>Override this method to customize the returned value of <see cref="Godot.AudioStream.InstantiatePlayback()"/>. Should return a new <see cref="Godot.AudioStreamPlayback"/> created when the stream is played (such as by an <see cref="Godot.AudioStreamPlayer"/>).</para>
    /// </summary>
    public virtual AudioStreamPlayback _InstantiatePlayback()
    {
        return default;
    }

    /// <summary>
    /// <para>Override this method to customize the returned value of <see cref="Godot.AudioStream.IsMonophonic()"/>. Should return <see langword="true"/> if this audio stream only supports one channel.</para>
    /// </summary>
    public virtual bool _IsMonophonic()
    {
        return default;
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLength, 1740695150ul);

    /// <summary>
    /// <para>Returns the length of the audio stream in seconds. If this stream is an <see cref="Godot.AudioStreamRandomizer"/>, returns the length of the last played stream. If this stream has an indefinite length (such as for <see cref="Godot.AudioStreamGenerator"/> and <see cref="Godot.AudioStreamMicrophone"/>), returns <c>0.0</c>.</para>
    /// </summary>
    public double GetLength()
    {
        return NativeCalls.godot_icall_0_144(MethodBind0, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsMonophonic, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if this audio stream only supports one channel (<i>monophony</i>), or <see langword="false"/> if the audio stream supports two or more channels (<i>polyphony</i>).</para>
    /// </summary>
    public bool IsMonophonic()
    {
        return NativeCalls.godot_icall_0_15(MethodBind1, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.InstantiatePlayback, 210135309ul);

    /// <summary>
    /// <para>Returns a newly created <see cref="Godot.AudioStreamPlayback"/> intended to play this audio stream. Useful for when you want to extend <see cref="Godot.AudioStream._InstantiatePlayback()"/> but call <see cref="Godot.AudioStream.InstantiatePlayback()"/> from an internally held AudioStream subresource. An example of this can be found in the source code for <c>AudioStreamRandomPitch::instantiate_playback</c>.</para>
    /// </summary>
    public AudioStreamPlayback InstantiatePlayback()
    {
        return (AudioStreamPlayback)NativeCalls.godot_icall_0_63(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanBeSampled, 36873697ul);

    /// <summary>
    /// <para>Returns if the current <see cref="Godot.AudioStream"/> can be used as a sample. Only static streams can be sampled.</para>
    /// </summary>
    public bool CanBeSampled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind3, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GenerateSample, 2646048999ul);

    /// <summary>
    /// <para>Generates an <see cref="Godot.AudioSample"/> based on the current stream.</para>
    /// </summary>
    public AudioSample GenerateSample()
    {
        return (AudioSample)NativeCalls.godot_icall_0_63(MethodBind4, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsMetaStream, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the stream is a collection of other streams, <see langword="false"/> otherwise.</para>
    /// </summary>
    public bool IsMetaStream()
    {
        return NativeCalls.godot_icall_0_15(MethodBind5, GodotObject.GetPtr(this)).ToBool();
    }

    /// <summary>
    /// <para>Signal to be emitted to notify when the parameter list changed.</para>
    /// </summary>
    public event Action ParameterListChanged
    {
        add => Connect(SignalName.ParameterListChanged, Callable.From(value));
        remove => Disconnect(SignalName.ParameterListChanged, Callable.From(value));
    }

    protected void EmitSignalParameterListChanged()
    {
        EmitSignal(SignalName.ParameterListChanged);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_bar_beats = "_GetBarBeats";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_beat_count = "_GetBeatCount";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_bpm = "_GetBpm";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_length = "_GetLength";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_parameter_list = "_GetParameterList";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_stream_name = "_GetStreamName";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_tags = "_GetTags";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__has_loop = "_HasLoop";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__instantiate_playback = "_InstantiatePlayback";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__is_monophonic = "_IsMonophonic";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_parameter_list_changed = "ParameterListChanged";

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
        if ((method == MethodProxyName__get_bar_beats || method == MethodName._GetBarBeats) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_bar_beats.NativeValue))
        {
            var callRet = _GetBarBeats();
            ret = VariantUtils.CreateFrom<int>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_beat_count || method == MethodName._GetBeatCount) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_beat_count.NativeValue))
        {
            var callRet = _GetBeatCount();
            ret = VariantUtils.CreateFrom<int>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_bpm || method == MethodName._GetBpm) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_bpm.NativeValue))
        {
            var callRet = _GetBpm();
            ret = VariantUtils.CreateFrom<double>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_length || method == MethodName._GetLength) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_length.NativeValue))
        {
            var callRet = _GetLength();
            ret = VariantUtils.CreateFrom<double>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_parameter_list || method == MethodName._GetParameterList) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_parameter_list.NativeValue))
        {
            var callRet = _GetParameterList();
            ret = VariantUtils.CreateFromArray(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_stream_name || method == MethodName._GetStreamName) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_stream_name.NativeValue))
        {
            var callRet = _GetStreamName();
            ret = VariantUtils.CreateFrom<string>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_tags || method == MethodName._GetTags) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_tags.NativeValue))
        {
            var callRet = _GetTags();
            ret = VariantUtils.CreateFrom<Godot.Collections.Dictionary>(callRet);
            return true;
        }
        if ((method == MethodProxyName__has_loop || method == MethodName._HasLoop) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__has_loop.NativeValue))
        {
            var callRet = _HasLoop();
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__instantiate_playback || method == MethodName._InstantiatePlayback) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__instantiate_playback.NativeValue))
        {
            var callRet = _InstantiatePlayback();
            ret = VariantUtils.CreateFrom<AudioStreamPlayback>(callRet);
            return true;
        }
        if ((method == MethodProxyName__is_monophonic || method == MethodName._IsMonophonic) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__is_monophonic.NativeValue))
        {
            var callRet = _IsMonophonic();
            ret = VariantUtils.CreateFrom<bool>(callRet);
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
        if (method == MethodName._GetBarBeats)
        {
            if (HasGodotClassMethod(MethodProxyName__get_bar_beats.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetBeatCount)
        {
            if (HasGodotClassMethod(MethodProxyName__get_beat_count.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetBpm)
        {
            if (HasGodotClassMethod(MethodProxyName__get_bpm.NativeValue.DangerousSelfRef))
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
        if (method == MethodName._GetParameterList)
        {
            if (HasGodotClassMethod(MethodProxyName__get_parameter_list.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetStreamName)
        {
            if (HasGodotClassMethod(MethodProxyName__get_stream_name.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetTags)
        {
            if (HasGodotClassMethod(MethodProxyName__get_tags.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._HasLoop)
        {
            if (HasGodotClassMethod(MethodProxyName__has_loop.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._InstantiatePlayback)
        {
            if (HasGodotClassMethod(MethodProxyName__instantiate_playback.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._IsMonophonic)
        {
            if (HasGodotClassMethod(MethodProxyName__is_monophonic.NativeValue.DangerousSelfRef))
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
        if (signal == SignalName.ParameterListChanged)
        {
            if (HasGodotClassSignal(SignalProxyName_parameter_list_changed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
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
        /// Cached name for the '_get_bar_beats' method.
        /// </summary>
        public static readonly StringName _GetBarBeats = "_get_bar_beats";
        /// <summary>
        /// Cached name for the '_get_beat_count' method.
        /// </summary>
        public static readonly StringName _GetBeatCount = "_get_beat_count";
        /// <summary>
        /// Cached name for the '_get_bpm' method.
        /// </summary>
        public static readonly StringName _GetBpm = "_get_bpm";
        /// <summary>
        /// Cached name for the '_get_length' method.
        /// </summary>
        public static readonly StringName _GetLength = "_get_length";
        /// <summary>
        /// Cached name for the '_get_parameter_list' method.
        /// </summary>
        public static readonly StringName _GetParameterList = "_get_parameter_list";
        /// <summary>
        /// Cached name for the '_get_stream_name' method.
        /// </summary>
        public static readonly StringName _GetStreamName = "_get_stream_name";
        /// <summary>
        /// Cached name for the '_get_tags' method.
        /// </summary>
        public static readonly StringName _GetTags = "_get_tags";
        /// <summary>
        /// Cached name for the '_has_loop' method.
        /// </summary>
        public static readonly StringName _HasLoop = "_has_loop";
        /// <summary>
        /// Cached name for the '_instantiate_playback' method.
        /// </summary>
        public static readonly StringName _InstantiatePlayback = "_instantiate_playback";
        /// <summary>
        /// Cached name for the '_is_monophonic' method.
        /// </summary>
        public static readonly StringName _IsMonophonic = "_is_monophonic";
        /// <summary>
        /// Cached name for the 'get_length' method.
        /// </summary>
        public static readonly StringName GetLength = "get_length";
        /// <summary>
        /// Cached name for the 'is_monophonic' method.
        /// </summary>
        public static readonly StringName IsMonophonic = "is_monophonic";
        /// <summary>
        /// Cached name for the 'instantiate_playback' method.
        /// </summary>
        public static readonly StringName InstantiatePlayback = "instantiate_playback";
        /// <summary>
        /// Cached name for the 'can_be_sampled' method.
        /// </summary>
        public static readonly StringName CanBeSampled = "can_be_sampled";
        /// <summary>
        /// Cached name for the 'generate_sample' method.
        /// </summary>
        public static readonly StringName GenerateSample = "generate_sample";
        /// <summary>
        /// Cached name for the 'is_meta_stream' method.
        /// </summary>
        public static readonly StringName IsMetaStream = "is_meta_stream";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Resource.SignalName
    {
        /// <summary>
        /// Cached name for the 'parameter_list_changed' signal.
        /// </summary>
        public static readonly StringName ParameterListChanged = "parameter_list_changed";
    }
}
