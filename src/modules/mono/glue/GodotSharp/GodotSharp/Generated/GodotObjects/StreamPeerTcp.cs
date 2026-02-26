namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A stream peer that handles TCP connections. This object can be used to connect to TCP servers, or also is returned by a TCP server.</para>
/// <para><b>Note:</b> When exporting to Android, make sure to enable the <c>INTERNET</c> permission in the Android export preset before exporting the project or using one-click deploy. Otherwise, network communication of any kind will be blocked by Android.</para>
/// </summary>
[GodotClassName("StreamPeerTCP")]
public partial class StreamPeerTcp : StreamPeerSocket
{
    private static readonly System.Type CachedType = typeof(StreamPeerTcp);

    private static readonly StringName NativeName = "StreamPeerTCP";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public StreamPeerTcp() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal StreamPeerTcp(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal StreamPeerTcp(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Bind, 3167955072ul);

    /// <summary>
    /// <para>Opens the TCP socket, and binds it to the specified local address.</para>
    /// <para>This method is generally not needed, and only used to force the subsequent call to <see cref="Godot.StreamPeerTcp.ConnectToHost(string, int)"/> to use the specified <paramref name="host"/> and <paramref name="port"/> as source address. This can be desired in some NAT punchthrough techniques, or when forcing the source network interface.</para>
    /// </summary>
    public Error Bind(int port, string host = "*")
    {
        return (Error)NativeCalls.godot_icall_2_1289(MethodBind0, GodotObject.GetPtr(this), port, host);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ConnectToHost, 993915709ul);

    /// <summary>
    /// <para>Connects to the specified <c>host:port</c> pair. A hostname will be resolved if valid. Returns <see cref="Godot.Error.Ok"/> on success.</para>
    /// </summary>
    public Error ConnectToHost(string host, int port)
    {
        return (Error)NativeCalls.godot_icall_2_387(MethodBind1, GodotObject.GetPtr(this), host, port);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetConnectedHost, 201670096ul);

    /// <summary>
    /// <para>Returns the IP of this peer.</para>
    /// </summary>
    public string GetConnectedHost()
    {
        return NativeCalls.godot_icall_0_58(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetConnectedPort, 3905245786ul);

    /// <summary>
    /// <para>Returns the port of this peer.</para>
    /// </summary>
    public int GetConnectedPort()
    {
        return NativeCalls.godot_icall_0_39(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLocalPort, 3905245786ul);

    /// <summary>
    /// <para>Returns the local port to which this peer is bound.</para>
    /// </summary>
    public int GetLocalPort()
    {
        return NativeCalls.godot_icall_0_39(MethodBind4, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetNoDelay, 2586408642ul);

    /// <summary>
    /// <para>If <paramref name="enabled"/> is <see langword="true"/>, packets will be sent immediately. If <paramref name="enabled"/> is <see langword="false"/> (the default), packet transfers will be delayed and combined using <a href="https://en.wikipedia.org/wiki/Nagle%27s_algorithm">Nagle's algorithm</a>.</para>
    /// <para><b>Note:</b> It's recommended to leave this disabled for applications that send large packets or need to transfer a lot of data, as enabling this can decrease the total available bandwidth.</para>
    /// </summary>
    public void SetNoDelay(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind5, GodotObject.GetPtr(this), enabled.ToGodotBool());
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
        /// Cached name for the 'get_connected_host' method.
        /// </summary>
        public static readonly StringName GetConnectedHost = "get_connected_host";
        /// <summary>
        /// Cached name for the 'get_connected_port' method.
        /// </summary>
        public static readonly StringName GetConnectedPort = "get_connected_port";
        /// <summary>
        /// Cached name for the 'get_local_port' method.
        /// </summary>
        public static readonly StringName GetLocalPort = "get_local_port";
        /// <summary>
        /// Cached name for the 'set_no_delay' method.
        /// </summary>
        public static readonly StringName SetNoDelay = "set_no_delay";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : StreamPeerSocket.SignalName
    {
    }
}
