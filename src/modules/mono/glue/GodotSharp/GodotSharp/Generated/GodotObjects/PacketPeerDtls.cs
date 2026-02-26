namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This class represents a DTLS peer connection. It can be used to connect to a DTLS server, and is returned by <see cref="Godot.DtlsServer.TakeConnection(PacketPeerUdp)"/>.</para>
/// <para><b>Note:</b> When exporting to Android, make sure to enable the <c>INTERNET</c> permission in the Android export preset before exporting the project or using one-click deploy. Otherwise, network communication of any kind will be blocked by Android.</para>
/// <para><b>Warning:</b> TLS certificate revocation and certificate pinning are currently not supported. Revoked certificates are accepted as long as they are otherwise valid. If this is a concern, you may want to use automatically managed certificates with a short validity period.</para>
/// </summary>
[GodotClassName("PacketPeerDTLS")]
public partial class PacketPeerDtls : PacketPeer
{
    public enum Status : long
    {
        /// <summary>
        /// <para>A status representing a <see cref="Godot.PacketPeerDtls"/> that is disconnected.</para>
        /// </summary>
        Disconnected = 0,
        /// <summary>
        /// <para>A status representing a <see cref="Godot.PacketPeerDtls"/> that is currently performing the handshake with a remote peer.</para>
        /// </summary>
        Handshaking = 1,
        /// <summary>
        /// <para>A status representing a <see cref="Godot.PacketPeerDtls"/> that is connected to a remote peer.</para>
        /// </summary>
        Connected = 2,
        /// <summary>
        /// <para>A status representing a <see cref="Godot.PacketPeerDtls"/> in a generic error state.</para>
        /// </summary>
        Error = 3,
        /// <summary>
        /// <para>An error status that shows a mismatch in the DTLS certificate domain presented by the host and the domain requested for validation.</para>
        /// </summary>
        ErrorHostnameMismatch = 4
    }

    private static readonly System.Type CachedType = typeof(PacketPeerDtls);

    private static readonly StringName NativeName = "PacketPeerDTLS";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public PacketPeerDtls() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal PacketPeerDtls(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal PacketPeerDtls(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Poll, 3218959716ul);

    /// <summary>
    /// <para>Poll the connection to check for incoming packets. Call this frequently to update the status and keep the connection working.</para>
    /// </summary>
    public void Poll()
    {
        NativeCalls.godot_icall_0_3(MethodBind0, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ConnectToPeer, 2880188099ul);

    /// <summary>
    /// <para>Connects a <paramref name="packetPeer"/> beginning the DTLS handshake using the underlying <see cref="Godot.PacketPeerUdp"/> which must be connected (see <see cref="Godot.PacketPeerUdp.ConnectToHost(string, int)"/>). You can optionally specify the <paramref name="clientOptions"/> to be used while verifying the TLS connections. See <see cref="Godot.TlsOptions.Client(X509Certificate, string)"/> and <see cref="Godot.TlsOptions.ClientUnsafe(X509Certificate)"/>.</para>
    /// </summary>
    public Error ConnectToPeer(PacketPeerUdp packetPeer, string hostname, TlsOptions clientOptions = null)
    {
        return (Error)NativeCalls.godot_icall_3_972(MethodBind1, GodotObject.GetPtr(this), GodotObject.GetPtr(packetPeer), hostname, GodotObject.GetPtr(clientOptions));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetStatus, 3248654679ul);

    /// <summary>
    /// <para>Returns the status of the connection.</para>
    /// </summary>
    public PacketPeerDtls.Status GetStatus()
    {
        return (PacketPeerDtls.Status)NativeCalls.godot_icall_0_39(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DisconnectFromPeer, 3218959716ul);

    /// <summary>
    /// <para>Disconnects this peer, terminating the DTLS session.</para>
    /// </summary>
    public void DisconnectFromPeer()
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
    public new class PropertyName : PacketPeer.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : PacketPeer.MethodName
    {
        /// <summary>
        /// Cached name for the 'poll' method.
        /// </summary>
        public static readonly StringName Poll = "poll";
        /// <summary>
        /// Cached name for the 'connect_to_peer' method.
        /// </summary>
        public static readonly StringName ConnectToPeer = "connect_to_peer";
        /// <summary>
        /// Cached name for the 'get_status' method.
        /// </summary>
        public static readonly StringName GetStatus = "get_status";
        /// <summary>
        /// Cached name for the 'disconnect_from_peer' method.
        /// </summary>
        public static readonly StringName DisconnectFromPeer = "disconnect_from_peer";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : PacketPeer.SignalName
    {
    }
}
