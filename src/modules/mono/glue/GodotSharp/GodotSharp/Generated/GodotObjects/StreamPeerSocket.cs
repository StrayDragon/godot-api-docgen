namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>StreamPeerSocket is an abstract base class that defines common behavior for socket-based streams.</para>
/// </summary>
public partial class StreamPeerSocket : StreamPeer
{
    public enum Status : long
    {
        /// <summary>
        /// <para>The initial status of the <see cref="Godot.StreamPeerSocket"/>. This is also the status after disconnecting.</para>
        /// </summary>
        None = 0,
        /// <summary>
        /// <para>A status representing a <see cref="Godot.StreamPeerSocket"/> that is connecting to a host.</para>
        /// </summary>
        Connecting = 1,
        /// <summary>
        /// <para>A status representing a <see cref="Godot.StreamPeerSocket"/> that is connected to a host.</para>
        /// </summary>
        Connected = 2,
        /// <summary>
        /// <para>A status representing a <see cref="Godot.StreamPeerSocket"/> in error state.</para>
        /// </summary>
        Error = 3
    }

    private static readonly System.Type CachedType = typeof(StreamPeerSocket);

    private static readonly StringName NativeName = "StreamPeerSocket";

    internal StreamPeerSocket() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal StreamPeerSocket(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal StreamPeerSocket(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Poll, 166280745ul);

    /// <summary>
    /// <para>Polls the socket, updating its state. See <see cref="Godot.StreamPeerSocket.GetStatus()"/>.</para>
    /// </summary>
    public Error Poll()
    {
        return (Error)NativeCalls.godot_icall_0_39(MethodBind0, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetStatus, 1156122502ul);

    /// <summary>
    /// <para>Returns the status of the connection.</para>
    /// </summary>
    public StreamPeerSocket.Status GetStatus()
    {
        return (StreamPeerSocket.Status)NativeCalls.godot_icall_0_39(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DisconnectFromHost, 3218959716ul);

    /// <summary>
    /// <para>Disconnects from host.</para>
    /// </summary>
    public void DisconnectFromHost()
    {
        NativeCalls.godot_icall_0_3(MethodBind2, GodotObject.GetPtr(this));
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
        /// Cached name for the 'poll' method.
        /// </summary>
        public static readonly StringName Poll = "poll";
        /// <summary>
        /// Cached name for the 'get_status' method.
        /// </summary>
        public static readonly StringName GetStatus = "get_status";
        /// <summary>
        /// Cached name for the 'disconnect_from_host' method.
        /// </summary>
        public static readonly StringName DisconnectFromHost = "disconnect_from_host";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : StreamPeer.SignalName
    {
    }
}
