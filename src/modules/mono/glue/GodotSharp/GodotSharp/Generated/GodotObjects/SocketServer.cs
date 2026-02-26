namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A socket server.</para>
/// </summary>
public partial class SocketServer : RefCounted
{
    private static readonly System.Type CachedType = typeof(SocketServer);

    private static readonly StringName NativeName = "SocketServer";

    internal SocketServer() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal SocketServer(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal SocketServer(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsConnectionAvailable, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if a connection is available for taking.</para>
    /// </summary>
    public bool IsConnectionAvailable()
    {
        return NativeCalls.godot_icall_0_15(MethodBind0, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsListening, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the server is currently listening for connections.</para>
    /// </summary>
    public bool IsListening()
    {
        return NativeCalls.godot_icall_0_15(MethodBind1, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Stop, 3218959716ul);

    /// <summary>
    /// <para>Stops listening.</para>
    /// </summary>
    public void Stop()
    {
        NativeCalls.godot_icall_0_3(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.TakeSocketConnection, 1883962599ul);

    /// <summary>
    /// <para>If a connection is available, returns a StreamPeerSocket with the connection.</para>
    /// </summary>
    public StreamPeerSocket TakeSocketConnection()
    {
        return (StreamPeerSocket)NativeCalls.godot_icall_0_63(MethodBind3, GodotObject.GetPtr(this));
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
    public new class PropertyName : RefCounted.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : RefCounted.MethodName
    {
        /// <summary>
        /// Cached name for the 'is_connection_available' method.
        /// </summary>
        public static readonly StringName IsConnectionAvailable = "is_connection_available";
        /// <summary>
        /// Cached name for the 'is_listening' method.
        /// </summary>
        public static readonly StringName IsListening = "is_listening";
        /// <summary>
        /// Cached name for the 'stop' method.
        /// </summary>
        public static readonly StringName Stop = "stop";
        /// <summary>
        /// Cached name for the 'take_socket_connection' method.
        /// </summary>
        public static readonly StringName TakeSocketConnection = "take_socket_connection";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : RefCounted.SignalName
    {
    }
}
