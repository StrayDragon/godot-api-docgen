namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A Unix Domain Socket (UDS) server. Listens to connections on a socket path and returns a <see cref="Godot.StreamPeerUds"/> when it gets an incoming connection. Unix Domain Sockets provide inter-process communication on the same machine using the filesystem namespace.</para>
/// <para><b>Note:</b> Unix Domain Sockets are only available on Unix-like systems (Linux, macOS, etc.) and are not supported on Windows.</para>
/// </summary>
[GodotClassName("UDSServer")]
public partial class UdsServer : SocketServer
{
    private static readonly System.Type CachedType = typeof(UdsServer);

    private static readonly StringName NativeName = "UDSServer";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public UdsServer() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal UdsServer(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal UdsServer(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Listen, 166001499ul);

    /// <summary>
    /// <para>Listens on the socket at <paramref name="path"/>. The socket file will be created at the specified path.</para>
    /// <para><b>Note:</b> The socket file must not already exist at the specified path. You may need to remove any existing socket file before calling this method.</para>
    /// </summary>
    public Error Listen(string path)
    {
        return (Error)NativeCalls.godot_icall_1_134(MethodBind0, GodotObject.GetPtr(this), path);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.TakeConnection, 1623851112ul);

    /// <summary>
    /// <para>If a connection is available, returns a StreamPeerUDS with the connection.</para>
    /// </summary>
    public StreamPeerUds TakeConnection()
    {
        return (StreamPeerUds)NativeCalls.godot_icall_0_63(MethodBind1, GodotObject.GetPtr(this));
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
