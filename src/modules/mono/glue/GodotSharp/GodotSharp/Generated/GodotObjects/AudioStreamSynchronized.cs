namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This is a stream that can be fitted with sub-streams, which will be played in-sync. The streams begin at exactly the same time when play is pressed, and will end when the last of them ends. If one of the sub-streams loops, then playback will continue.</para>
/// </summary>
public partial class AudioStreamSynchronized : AudioStream
{
    /// <summary>
    /// <para>Maximum amount of streams that can be synchronized.</para>
    /// </summary>
    public const long MaxStreams = 32;

    /// <summary>
    /// <para>Set the total amount of streams that will be played back synchronized.</para>
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

    private static readonly System.Type CachedType = typeof(AudioStreamSynchronized);

    private static readonly StringName NativeName = "AudioStreamSynchronized";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public AudioStreamSynchronized() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal AudioStreamSynchronized(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal AudioStreamSynchronized(bool memoryOwn) : base(memoryOwn) { }

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
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSyncStream, 111075094ul);

    /// <summary>
    /// <para>Set one of the synchronized streams, by index.</para>
    /// </summary>
    public void SetSyncStream(int streamIndex, AudioStream audioStream)
    {
        NativeCalls.godot_icall_2_70(MethodBind2, GodotObject.GetPtr(this), streamIndex, GodotObject.GetPtr(audioStream));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSyncStream, 2739380747ul);

    /// <summary>
    /// <para>Get one of the synchronized streams, by index.</para>
    /// </summary>
    public AudioStream GetSyncStream(int streamIndex)
    {
        return (AudioStream)NativeCalls.godot_icall_1_71(MethodBind3, GodotObject.GetPtr(this), streamIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSyncStreamVolume, 1602489585ul);

    /// <summary>
    /// <para>Set the volume of one of the synchronized streams, by index.</para>
    /// </summary>
    public void SetSyncStreamVolume(int streamIndex, float volumeDb)
    {
        NativeCalls.godot_icall_2_69(MethodBind4, GodotObject.GetPtr(this), streamIndex, volumeDb);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSyncStreamVolume, 2339986948ul);

    /// <summary>
    /// <para>Get the volume of one of the synchronized streams, by index.</para>
    /// </summary>
    public float GetSyncStreamVolume(int streamIndex)
    {
        return NativeCalls.godot_icall_1_72(MethodBind5, GodotObject.GetPtr(this), streamIndex);
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
        /// Cached name for the 'stream_count' property.
        /// </summary>
        public static readonly StringName StreamCount = "stream_count";
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
        /// Cached name for the 'set_sync_stream' method.
        /// </summary>
        public static readonly StringName SetSyncStream = "set_sync_stream";
        /// <summary>
        /// Cached name for the 'get_sync_stream' method.
        /// </summary>
        public static readonly StringName GetSyncStream = "get_sync_stream";
        /// <summary>
        /// Cached name for the 'set_sync_stream_volume' method.
        /// </summary>
        public static readonly StringName SetSyncStreamVolume = "set_sync_stream_volume";
        /// <summary>
        /// Cached name for the 'get_sync_stream_volume' method.
        /// </summary>
        public static readonly StringName GetSyncStreamVolume = "get_sync_stream_volume";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : AudioStream.SignalName
    {
    }
}
