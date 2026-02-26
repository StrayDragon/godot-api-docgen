namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This class allows to compress or decompress data using GZIP/deflate in a streaming fashion. This is particularly useful when compressing or decompressing files that have to be sent through the network without needing to allocate them all in memory.</para>
/// <para>After starting the stream via <see cref="Godot.StreamPeerGZip.StartCompression(bool, int)"/> (or <see cref="Godot.StreamPeerGZip.StartDecompression(bool, int)"/>), calling <see cref="Godot.StreamPeer.PutPartialData(byte[])"/> on this stream will compress (or decompress) the data, writing it to the internal buffer. Calling <see cref="Godot.StreamPeer.GetAvailableBytes()"/> will return the pending bytes in the internal buffer, and <see cref="Godot.StreamPeer.GetPartialData(int)"/> will retrieve the compressed (or decompressed) bytes from it. When the stream is over, you must call <see cref="Godot.StreamPeerGZip.Finish()"/> to ensure the internal buffer is properly flushed (make sure to call <see cref="Godot.StreamPeer.GetAvailableBytes()"/> on last time to check if more data needs to be read after that).</para>
/// </summary>
[GodotClassName("StreamPeerGZIP")]
public partial class StreamPeerGZip : StreamPeer
{
    private static readonly System.Type CachedType = typeof(StreamPeerGZip);

    private static readonly StringName NativeName = "StreamPeerGZIP";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public StreamPeerGZip() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal StreamPeerGZip(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal StreamPeerGZip(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.StartCompression, 781582770ul);

    /// <summary>
    /// <para>Start the stream in compression mode with the given <paramref name="bufferSize"/>, if <paramref name="useDeflate"/> is <see langword="true"/> uses deflate instead of GZIP.</para>
    /// </summary>
    public Error StartCompression(bool useDeflate = false, int bufferSize = 65535)
    {
        return (Error)NativeCalls.godot_icall_2_1288(MethodBind0, GodotObject.GetPtr(this), useDeflate.ToGodotBool(), bufferSize);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.StartDecompression, 781582770ul);

    /// <summary>
    /// <para>Start the stream in decompression mode with the given <paramref name="bufferSize"/>, if <paramref name="useDeflate"/> is <see langword="true"/> uses deflate instead of GZIP.</para>
    /// </summary>
    public Error StartDecompression(bool useDeflate = false, int bufferSize = 65535)
    {
        return (Error)NativeCalls.godot_icall_2_1288(MethodBind1, GodotObject.GetPtr(this), useDeflate.ToGodotBool(), bufferSize);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Finish, 166280745ul);

    /// <summary>
    /// <para>Finalizes the stream, compressing any buffered chunk left.</para>
    /// <para>You must call it only when you are compressing.</para>
    /// </summary>
    public Error Finish()
    {
        return (Error)NativeCalls.godot_icall_0_39(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Clear, 3218959716ul);

    /// <summary>
    /// <para>Clears this stream, resetting the internal state.</para>
    /// </summary>
    public void Clear()
    {
        NativeCalls.godot_icall_0_3(MethodBind3, GodotObject.GetPtr(this));
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
    public new class PropertyName : StreamPeer.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : StreamPeer.MethodName
    {
        /// <summary>
        /// Cached name for the 'start_compression' method.
        /// </summary>
        public static readonly StringName StartCompression = "start_compression";
        /// <summary>
        /// Cached name for the 'start_decompression' method.
        /// </summary>
        public static readonly StringName StartDecompression = "start_decompression";
        /// <summary>
        /// Cached name for the 'finish' method.
        /// </summary>
        public static readonly StringName Finish = "finish";
        /// <summary>
        /// Cached name for the 'clear' method.
        /// </summary>
        public static readonly StringName Clear = "clear";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : StreamPeer.SignalName
    {
    }
}
