namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A stream peer that handles UNIX Domain Socket (UDS) connections. This object can be used to connect to UDS servers, or also is returned by a UDS server. Unix Domain Sockets provide inter-process communication on the same machine using the filesystem namespace.</para>
/// <para><b>Note:</b> UNIX Domain Sockets are only available on UNIX-like systems (Linux, macOS, etc.) and are not supported on Windows.</para>
/// </summary>
[GodotClassName("StreamPeerUDS")]
public partial class StreamPeerUds : StreamPeerSocket
{
    private static readonly System.Type CachedType = typeof(StreamPeerUds);

    private static readonly StringName NativeName = "StreamPeerUDS";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public StreamPeerUds() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal StreamPeerUds(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal StreamPeerUds(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Bind, 166001499ul);

    /// <summary>
    /// <para>Opens the UDS socket, and binds it to the specified socket path.</para>
    /// <para>This method is generally not needed, and only used to force the subsequent call to <see cref="Godot.StreamPeerUds.ConnectToHost(string)"/> to use the specified <paramref name="path"/> as the source address.</para>
    /// </summary>
    public Error Bind(string path)
    {
        return (Error)NativeCalls.godot_icall_1_134(MethodBind0, GodotObject.GetPtr(this), path);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ConnectToHost, 166001499ul);

    /// <summary>
    /// <para>Connects to the specified UNIX Domain Socket path. Returns <see cref="Godot.Error.Ok"/> on success.</para>
    /// </summary>
    public Error ConnectToHost(string path)
    {
        return (Error)NativeCalls.godot_icall_1_134(MethodBind1, GodotObject.GetPtr(this), path);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetConnectedPath, 201670096ul);

    /// <summary>
    /// <para>Returns the socket path of this peer.</para>
    /// </summary>
    public string GetConnectedPath()
    {
        return NativeCalls.godot_icall_0_58(MethodBind2, GodotObject.GetPtr(this));
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
    public new class PropertyName : StreamPeerSocket.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : StreamPeerSocket.MethodName
    {
        /// <summary>
        /// Cached name for the 'bind' method.
        /// </summary>
        public static readonly StringName Bind = "bind";
        /// <summary>
        /// Cached name for the 'connect_to_host' method.
        /// </summary>
        public static readonly StringName ConnectToHost = "connect_to_host";
        /// <summary>
        /// Cached name for the 'get_connected_path' method.
        /// </summary>
        public static readonly StringName GetConnectedPath = "get_connected_path";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : StreamPeerSocket.SignalName
    {
    }
}
