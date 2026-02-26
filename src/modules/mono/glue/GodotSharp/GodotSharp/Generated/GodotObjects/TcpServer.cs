namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A TCP server. Listens to connections on a port and returns a <see cref="Godot.StreamPeerTcp"/> when it gets an incoming connection.</para>
/// <para><b>Note:</b> When exporting to Android, make sure to enable the <c>INTERNET</c> permission in the Android export preset before exporting the project or using one-click deploy. Otherwise, network communication of any kind will be blocked by Android.</para>
/// </summary>
[GodotClassName("TCPServer")]
public partial class TcpServer : SocketServer
{
    private static readonly System.Type CachedType = typeof(TcpServer);

    private static readonly StringName NativeName = "TCPServer";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public TcpServer() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal TcpServer(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal TcpServer(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Listen, 3167955072ul);

    /// <summary>
    /// <para>Listen on the <paramref name="port"/> binding to <paramref name="bindAddress"/>.</para>
    /// <para>If <paramref name="bindAddress"/> is set as <c>"*"</c> (default), the server will listen on all available addresses (both IPv4 and IPv6).</para>
    /// <para>If <paramref name="bindAddress"/> is set as <c>"0.0.0.0"</c> (for IPv4) or <c>"::"</c> (for IPv6), the server will listen on all available addresses matching that IP type.</para>
    /// <para>If <paramref name="bindAddress"/> is set to any valid address (e.g. <c>"192.168.1.101"</c>, <c>"::1"</c>, etc.), the server will only listen on the interface with that address (or fail if no interface with the given address exists).</para>
    /// </summary>
    public Error Listen(ushort port, string bindAddress = "*")
    {
        return (Error)NativeCalls.godot_icall_2_1297(MethodBind0, GodotObject.GetPtr(this), port, bindAddress);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLocalPort, 3905245786ul);

    /// <summary>
    /// <para>Returns the local port this server is listening to.</para>
    /// </summary>
    public int GetLocalPort()
    {
        return NativeCalls.godot_icall_0_39(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.TakeConnection, 30545006ul);

    /// <summary>
    /// <para>If a connection is available, returns a StreamPeerTCP with the connection.</para>
    /// </summary>
    public StreamPeerTcp TakeConnection()
    {
        return (StreamPeerTcp)NativeCalls.godot_icall_0_63(MethodBind2, GodotObject.GetPtr(this));
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
    public new class PropertyName : SocketServer.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : SocketServer.MethodName
    {
        /// <summary>
        /// Cached name for the 'listen' method.
        /// </summary>
        public static readonly StringName Listen = "listen";
        /// <summary>
        /// Cached name for the 'get_local_port' method.
        /// </summary>
        public static readonly StringName GetLocalPort = "get_local_port";
        /// <summary>
        /// Cached name for the 'take_connection' method.
        /// </summary>
        public static readonly StringName TakeConnection = "take_connection";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : SocketServer.SignalName
    {
    }
}
