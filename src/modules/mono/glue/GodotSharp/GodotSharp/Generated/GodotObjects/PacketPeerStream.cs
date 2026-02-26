namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>PacketStreamPeer provides a wrapper for working using packets over a stream. This allows for using packet based code with StreamPeers. PacketPeerStream implements a custom protocol over the StreamPeer, so the user should not read or write to the wrapped StreamPeer directly.</para>
/// <para><b>Note:</b> When exporting to Android, make sure to enable the <c>INTERNET</c> permission in the Android export preset before exporting the project or using one-click deploy. Otherwise, network communication of any kind will be blocked by Android.</para>
/// </summary>
public partial class PacketPeerStream : PacketPeer
{
    public int InputBufferMaxSize
    {
        get
        {
            return GetInputBufferMaxSize();
        }
        set
        {
            SetInputBufferMaxSize(value);
        }
    }

    public int OutputBufferMaxSize
    {
        get
        {
            return GetOutputBufferMaxSize();
        }
        set
        {
            SetOutputBufferMaxSize(value);
        }
    }

    /// <summary>
    /// <para>The wrapped <see cref="Godot.StreamPeer"/> object.</para>
    /// </summary>
    public StreamPeer StreamPeer
    {
        get
        {
            return GetStreamPeer();
        }
        set
        {
            SetStreamPeer(value);
        }
    }

    private static readonly System.Type CachedType = typeof(PacketPeerStream);

    private static readonly StringName NativeName = "PacketPeerStream";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public PacketPeerStream() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal PacketPeerStream(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal PacketPeerStream(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetStreamPeer, 3281897016ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetStreamPeer(StreamPeer peer)
    {
        NativeCalls.godot_icall_1_56(MethodBind0, GodotObject.GetPtr(this), GodotObject.GetPtr(peer));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetStreamPeer, 2741655269ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public StreamPeer GetStreamPeer()
    {
        return (StreamPeer)NativeCalls.godot_icall_0_63(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetInputBufferMaxSize, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetInputBufferMaxSize(int maxSizeBytes)
    {
        NativeCalls.godot_icall_1_38(MethodBind2, GodotObject.GetPtr(this), maxSizeBytes);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetOutputBufferMaxSize, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetOutputBufferMaxSize(int maxSizeBytes)
    {
        NativeCalls.godot_icall_1_38(MethodBind3, GodotObject.GetPtr(this), maxSizeBytes);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetInputBufferMaxSize, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetInputBufferMaxSize()
    {
        return NativeCalls.godot_icall_0_39(MethodBind4, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOutputBufferMaxSize, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetOutputBufferMaxSize()
    {
        return NativeCalls.godot_icall_0_39(MethodBind5, GodotObject.GetPtr(this));
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
    public new class PropertyName : PacketPeer.PropertyName
    {
        /// <summary>
        /// Cached name for the 'input_buffer_max_size' property.
        /// </summary>
        public static readonly StringName InputBufferMaxSize = "input_buffer_max_size";
        /// <summary>
        /// Cached name for the 'output_buffer_max_size' property.
        /// </summary>
        public static readonly StringName OutputBufferMaxSize = "output_buffer_max_size";
        /// <summary>
        /// Cached name for the 'stream_peer' property.
        /// </summary>
        public static readonly StringName StreamPeer = "stream_peer";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : PacketPeer.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_stream_peer' method.
        /// </summary>
        public static readonly StringName SetStreamPeer = "set_stream_peer";
        /// <summary>
        /// Cached name for the 'get_stream_peer' method.
        /// </summary>
        public static readonly StringName GetStreamPeer = "get_stream_peer";
        /// <summary>
        /// Cached name for the 'set_input_buffer_max_size' method.
        /// </summary>
        public static readonly StringName SetInputBufferMaxSize = "set_input_buffer_max_size";
        /// <summary>
        /// Cached name for the 'set_output_buffer_max_size' method.
        /// </summary>
        public static readonly StringName SetOutputBufferMaxSize = "set_output_buffer_max_size";
        /// <summary>
        /// Cached name for the 'get_input_buffer_max_size' method.
        /// </summary>
        public static readonly StringName GetInputBufferMaxSize = "get_input_buffer_max_size";
        /// <summary>
        /// Cached name for the 'get_output_buffer_max_size' method.
        /// </summary>
        public static readonly StringName GetOutputBufferMaxSize = "get_output_buffer_max_size";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : PacketPeer.SignalName
    {
    }
}
