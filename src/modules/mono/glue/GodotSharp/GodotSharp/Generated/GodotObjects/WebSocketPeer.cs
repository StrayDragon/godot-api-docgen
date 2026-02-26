namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This class represents WebSocket connection, and can be used as a WebSocket client (<a href="https://datatracker.ietf.org/doc/html/rfc6455">RFC 6455</a>-compliant) or as a remote peer of a WebSocket server.</para>
/// <para>You can send WebSocket binary frames using <see cref="Godot.PacketPeer.PutPacket(byte[])"/>, and WebSocket text frames using <see cref="Godot.WebSocketPeer.Send(byte[], WebSocketPeer.WriteMode)"/> (prefer text frames when interacting with text-based API). You can check the frame type of the last packet via <see cref="Godot.WebSocketPeer.WasStringPacket()"/>.</para>
/// <para>To start a WebSocket client, first call <see cref="Godot.WebSocketPeer.ConnectToUrl(string, TlsOptions)"/>, then regularly call <see cref="Godot.WebSocketPeer.Poll()"/> (e.g. during <see cref="Godot.Node"/> process). You can query the socket state via <see cref="Godot.WebSocketPeer.GetReadyState()"/>, get the number of pending packets using <see cref="Godot.PacketPeer.GetAvailablePacketCount()"/>, and retrieve them via <see cref="Godot.PacketPeer.GetPacket()"/>.</para>
/// <para></para>
/// <para>To use the peer as part of a WebSocket server refer to <see cref="Godot.WebSocketPeer.AcceptStream(StreamPeer)"/> and the online tutorial.</para>
/// </summary>
public partial class WebSocketPeer : PacketPeer
{
    public enum WriteMode : long
    {
        /// <summary>
        /// <para>Specifies that WebSockets messages should be transferred as text payload (only valid UTF-8 is allowed).</para>
        /// </summary>
        Text = 0,
        /// <summary>
        /// <para>Specifies that WebSockets messages should be transferred as binary payload (any byte combination is allowed).</para>
        /// </summary>
        Binary = 1
    }

    public enum State : long
    {
        /// <summary>
        /// <para>Socket has been created. The connection is not yet open.</para>
        /// </summary>
        Connecting = 0,
        /// <summary>
        /// <para>The connection is open and ready to communicate.</para>
        /// </summary>
        Open = 1,
        /// <summary>
        /// <para>The connection is in the process of closing. This means a close request has been sent to the remote peer but confirmation has not been received.</para>
        /// </summary>
        Closing = 2,
        /// <summary>
        /// <para>The connection is closed or couldn't be opened.</para>
        /// </summary>
        Closed = 3
    }

    /// <summary>
    /// <para>The WebSocket sub-protocols allowed during the WebSocket handshake.</para>
    /// </summary>
    public string[] SupportedProtocols
    {
        get
        {
            return GetSupportedProtocols();
        }
        set
        {
            SetSupportedProtocols(value);
        }
    }

    /// <summary>
    /// <para>The extra HTTP headers to be sent during the WebSocket handshake.</para>
    /// <para><b>Note:</b> Not supported in Web exports due to browsers' restrictions.</para>
    /// </summary>
    public string[] HandshakeHeaders
    {
        get
        {
            return GetHandshakeHeaders();
        }
        set
        {
            SetHandshakeHeaders(value);
        }
    }

    /// <summary>
    /// <para>The size of the input buffer in bytes (roughly the maximum amount of memory that will be allocated for the inbound packets).</para>
    /// </summary>
    public int InboundBufferSize
    {
        get
        {
            return GetInboundBufferSize();
        }
        set
        {
            SetInboundBufferSize(value);
        }
    }

    /// <summary>
    /// <para>The size of the input buffer in bytes (roughly the maximum amount of memory that will be allocated for the outbound packets).</para>
    /// </summary>
    public int OutboundBufferSize
    {
        get
        {
            return GetOutboundBufferSize();
        }
        set
        {
            SetOutboundBufferSize(value);
        }
    }

    /// <summary>
    /// <para>The maximum amount of packets that will be allowed in the queues (both inbound and outbound).</para>
    /// </summary>
    public int MaxQueuedPackets
    {
        get
        {
            return GetMaxQueuedPackets();
        }
        set
        {
            SetMaxQueuedPackets(value);
        }
    }

    /// <summary>
    /// <para>The interval (in seconds) at which the peer will automatically send WebSocket "ping" control frames. When set to <c>0</c>, no "ping" control frames will be sent.</para>
    /// <para><b>Note:</b> Has no effect in Web exports due to browser restrictions.</para>
    /// </summary>
    public double HeartbeatInterval
    {
        get
        {
            return GetHeartbeatInterval();
        }
        set
        {
            SetHeartbeatInterval(value);
        }
    }

    private static readonly System.Type CachedType = typeof(WebSocketPeer);

    private static readonly StringName NativeName = "WebSocketPeer";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public WebSocketPeer() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal WebSocketPeer(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal WebSocketPeer(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ConnectToUrl, 1966198364ul);

    /// <summary>
    /// <para>Connects to the given URL. TLS certificates will be verified against the hostname when connecting using the <c>wss://</c> protocol. You can pass the optional <paramref name="tlsClientOptions"/> parameter to customize the trusted certification authorities, or disable the common name verification. See <see cref="Godot.TlsOptions.Client(X509Certificate, string)"/> and <see cref="Godot.TlsOptions.ClientUnsafe(X509Certificate)"/>.</para>
    /// <para><b>Note:</b> This method is non-blocking, and will return <see cref="Godot.Error.Ok"/> before the connection is established as long as the provided parameters are valid and the peer is not in an invalid state (e.g. already connected). Regularly call <see cref="Godot.WebSocketPeer.Poll()"/> (e.g. during <see cref="Godot.Node"/> process) and check the result of <see cref="Godot.WebSocketPeer.GetReadyState()"/> to know whether the connection succeeds or fails.</para>
    /// <para><b>Note:</b> To avoid mixed content warnings or errors in Web, you may have to use a <paramref name="url"/> that starts with <c>wss://</c> (secure) instead of <c>ws://</c>. When doing so, make sure to use the fully qualified domain name that matches the one defined in the server's TLS certificate. Do not connect directly via the IP address for <c>wss://</c> connections, as it won't match with the TLS certificate.</para>
    /// </summary>
    public Error ConnectToUrl(string url, TlsOptions tlsClientOptions = null)
    {
        return (Error)NativeCalls.godot_icall_2_459(MethodBind0, GodotObject.GetPtr(this), url, GodotObject.GetPtr(tlsClientOptions));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AcceptStream, 255125695ul);

    /// <summary>
    /// <para>Accepts a peer connection performing the HTTP handshake as a WebSocket server. The <paramref name="stream"/> must be a valid TCP stream retrieved via <see cref="Godot.TcpServer.TakeConnection()"/>, or a TLS stream accepted via <see cref="Godot.StreamPeerTls.AcceptStream(StreamPeer, TlsOptions)"/>.</para>
    /// <para><b>Note:</b> Not supported in Web exports due to browsers' restrictions.</para>
    /// </summary>
    public Error AcceptStream(StreamPeer stream)
    {
        return (Error)NativeCalls.godot_icall_1_371(MethodBind1, GodotObject.GetPtr(this), GodotObject.GetPtr(stream));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Send, 2780360567ul);

    /// <summary>
    /// <para>Sends the given <paramref name="message"/> using the desired <paramref name="writeMode"/>. When sending a <see cref="string"/>, prefer using <see cref="Godot.WebSocketPeer.SendText(string)"/>.</para>
    /// </summary>
    public Error Send(byte[] message, WebSocketPeer.WriteMode writeMode = (WebSocketPeer.WriteMode)(1))
    {
        return (Error)NativeCalls.godot_icall_2_1504(MethodBind2, GodotObject.GetPtr(this), message, (int)writeMode);
    }

    /// <summary>
    /// <para>Sends the given <paramref name="message"/> using the desired <paramref name="writeMode"/>. When sending a <see cref="string"/>, prefer using <see cref="Godot.WebSocketPeer.SendText(string)"/>.</para>
    /// </summary>
    public Error Send(ReadOnlySpan<byte> message, WebSocketPeer.WriteMode writeMode)
    {
        return (Error)NativeCalls.godot_icall_2_1504(MethodBind2, GodotObject.GetPtr(this), message, (int)writeMode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SendText, 166001499ul);

    /// <summary>
    /// <para>Sends the given <paramref name="message"/> using WebSocket text mode. Prefer this method over <see cref="Godot.PacketPeer.PutPacket(byte[])"/> when interacting with third-party text-based API (e.g. when using <see cref="Godot.Json"/> formatted messages).</para>
    /// </summary>
    public Error SendText(string message)
    {
        return (Error)NativeCalls.godot_icall_1_134(MethodBind3, GodotObject.GetPtr(this), message);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.WasStringPacket, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the last received packet was sent as a text payload. See <see cref="Godot.WebSocketPeer.WriteMode"/>.</para>
    /// </summary>
    public bool WasStringPacket()
    {
        return NativeCalls.godot_icall_0_15(MethodBind4, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Poll, 3218959716ul);

    /// <summary>
    /// <para>Updates the connection state and receive incoming packets. Call this function regularly to keep it in a clean state.</para>
    /// </summary>
    public void Poll()
    {
        NativeCalls.godot_icall_0_3(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Close, 1047156615ul);

    /// <summary>
    /// <para>Closes this WebSocket connection.</para>
    /// <para><paramref name="code"/> is the status code for the closure (see <a href="https://datatracker.ietf.org/doc/html/rfc6455#section-7.4.1">RFC 6455 section 7.4</a> for a list of valid status codes). If <paramref name="code"/> is negative, the connection will be closed immediately without notifying the remote peer.</para>
    /// <para><paramref name="reason"/> is the human-readable reason for closing the connection. It can be any UTF-8 string that's smaller than 123 bytes.</para>
    /// <para><b>Note:</b> To achieve a clean closure, you will need to keep polling until <see cref="Godot.WebSocketPeer.State.Closed"/> is reached.</para>
    /// <para><b>Note:</b> The Web export might not support all status codes. Please refer to browser-specific documentation for more details.</para>
    /// </summary>
    public void Close(int code = 1000, string reason = "")
    {
        NativeCalls.godot_icall_2_181(MethodBind6, GodotObject.GetPtr(this), code, reason);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetConnectedHost, 201670096ul);

    /// <summary>
    /// <para>Returns the IP address of the connected peer.</para>
    /// <para><b>Note:</b> Not available in the Web export.</para>
    /// </summary>
    public string GetConnectedHost()
    {
        return NativeCalls.godot_icall_0_58(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetConnectedPort, 3905245786ul);

    /// <summary>
    /// <para>Returns the remote port of the connected peer.</para>
    /// <para><b>Note:</b> Not available in the Web export.</para>
    /// </summary>
    public ushort GetConnectedPort()
    {
        return NativeCalls.godot_icall_0_284(MethodBind8, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSelectedProtocol, 201670096ul);

    /// <summary>
    /// <para>Returns the selected WebSocket sub-protocol for this connection or an empty string if the sub-protocol has not been selected yet.</para>
    /// </summary>
    public string GetSelectedProtocol()
    {
        return NativeCalls.godot_icall_0_58(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRequestedUrl, 201670096ul);

    /// <summary>
    /// <para>Returns the URL requested by this peer. The URL is derived from the <c>url</c> passed to <see cref="Godot.WebSocketPeer.ConnectToUrl(string, TlsOptions)"/> or from the HTTP headers when acting as server (i.e. when using <see cref="Godot.WebSocketPeer.AcceptStream(StreamPeer)"/>).</para>
    /// </summary>
    public string GetRequestedUrl()
    {
        return NativeCalls.godot_icall_0_58(MethodBind10, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetNoDelay, 2586408642ul);

    /// <summary>
    /// <para>Disable Nagle's algorithm on the underlying TCP socket (default). See <see cref="Godot.StreamPeerTcp.SetNoDelay(bool)"/> for more information.</para>
    /// <para><b>Note:</b> Not available in the Web export.</para>
    /// </summary>
    public void SetNoDelay(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind11, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCurrentOutboundBufferedAmount, 3905245786ul);

    /// <summary>
    /// <para>Returns the current amount of data in the outbound websocket buffer. <b>Note:</b> Web exports use WebSocket.bufferedAmount, while other platforms use an internal buffer.</para>
    /// </summary>
    public int GetCurrentOutboundBufferedAmount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind12, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetReadyState, 346482985ul);

    /// <summary>
    /// <para>Returns the ready state of the connection.</para>
    /// </summary>
    public WebSocketPeer.State GetReadyState()
    {
        return (WebSocketPeer.State)NativeCalls.godot_icall_0_39(MethodBind13, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCloseCode, 3905245786ul);

    /// <summary>
    /// <para>Returns the received WebSocket close frame status code, or <c>-1</c> when the connection was not cleanly closed. Only call this method when <see cref="Godot.WebSocketPeer.GetReadyState()"/> returns <see cref="Godot.WebSocketPeer.State.Closed"/>.</para>
    /// </summary>
    public int GetCloseCode()
    {
        return NativeCalls.godot_icall_0_39(MethodBind14, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCloseReason, 201670096ul);

    /// <summary>
    /// <para>Returns the received WebSocket close frame status reason string. Only call this method when <see cref="Godot.WebSocketPeer.GetReadyState()"/> returns <see cref="Godot.WebSocketPeer.State.Closed"/>.</para>
    /// </summary>
    public string GetCloseReason()
    {
        return NativeCalls.godot_icall_0_58(MethodBind15, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSupportedProtocols, 1139954409ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string[] GetSupportedProtocols()
    {
        return NativeCalls.godot_icall_0_108(MethodBind16, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSupportedProtocols, 4015028928ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSupportedProtocols(string[] protocols)
    {
        NativeCalls.godot_icall_1_185(MethodBind17, GodotObject.GetPtr(this), protocols);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSupportedProtocols(ReadOnlySpan<string> protocols)
    {
        NativeCalls.godot_icall_1_185(MethodBind17, GodotObject.GetPtr(this), protocols);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetHandshakeHeaders, 1139954409ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string[] GetHandshakeHeaders()
    {
        return NativeCalls.godot_icall_0_108(MethodBind18, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetHandshakeHeaders, 4015028928ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetHandshakeHeaders(string[] protocols)
    {
        NativeCalls.godot_icall_1_185(MethodBind19, GodotObject.GetPtr(this), protocols);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetHandshakeHeaders(ReadOnlySpan<string> protocols)
    {
        NativeCalls.godot_icall_1_185(MethodBind19, GodotObject.GetPtr(this), protocols);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetInboundBufferSize, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetInboundBufferSize()
    {
        return NativeCalls.godot_icall_0_39(MethodBind20, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetInboundBufferSize, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetInboundBufferSize(int bufferSize)
    {
        NativeCalls.godot_icall_1_38(MethodBind21, GodotObject.GetPtr(this), bufferSize);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOutboundBufferSize, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetOutboundBufferSize()
    {
        return NativeCalls.godot_icall_0_39(MethodBind22, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetOutboundBufferSize, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetOutboundBufferSize(int bufferSize)
    {
        NativeCalls.godot_icall_1_38(MethodBind23, GodotObject.GetPtr(this), bufferSize);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMaxQueuedPackets, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMaxQueuedPackets(int bufferSize)
    {
        NativeCalls.godot_icall_1_38(MethodBind24, GodotObject.GetPtr(this), bufferSize);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMaxQueuedPackets, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetMaxQueuedPackets()
    {
        return NativeCalls.godot_icall_0_39(MethodBind25, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetHeartbeatInterval, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetHeartbeatInterval(double interval)
    {
        NativeCalls.godot_icall_1_127(MethodBind26, GodotObject.GetPtr(this), interval);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetHeartbeatInterval, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public double GetHeartbeatInterval()
    {
        return NativeCalls.godot_icall_0_144(MethodBind27, GodotObject.GetPtr(this));
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
        /// Cached name for the 'supported_protocols' property.
        /// </summary>
        public static readonly StringName SupportedProtocols = "supported_protocols";
        /// <summary>
        /// Cached name for the 'handshake_headers' property.
        /// </summary>
        public static readonly StringName HandshakeHeaders = "handshake_headers";
        /// <summary>
        /// Cached name for the 'inbound_buffer_size' property.
        /// </summary>
        public static readonly StringName InboundBufferSize = "inbound_buffer_size";
        /// <summary>
        /// Cached name for the 'outbound_buffer_size' property.
        /// </summary>
        public static readonly StringName OutboundBufferSize = "outbound_buffer_size";
        /// <summary>
        /// Cached name for the 'max_queued_packets' property.
        /// </summary>
        public static readonly StringName MaxQueuedPackets = "max_queued_packets";
        /// <summary>
        /// Cached name for the 'heartbeat_interval' property.
        /// </summary>
        public static readonly StringName HeartbeatInterval = "heartbeat_interval";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : PacketPeer.MethodName
    {
        /// <summary>
        /// Cached name for the 'connect_to_url' method.
        /// </summary>
        public static readonly StringName ConnectToUrl = "connect_to_url";
        /// <summary>
        /// Cached name for the 'accept_stream' method.
        /// </summary>
        public static readonly StringName AcceptStream = "accept_stream";
        /// <summary>
        /// Cached name for the 'send' method.
        /// </summary>
        public static readonly StringName Send = "send";
        /// <summary>
        /// Cached name for the 'send_text' method.
        /// </summary>
        public static readonly StringName SendText = "send_text";
        /// <summary>
        /// Cached name for the 'was_string_packet' method.
        /// </summary>
        public static readonly StringName WasStringPacket = "was_string_packet";
        /// <summary>
        /// Cached name for the 'poll' method.
        /// </summary>
        public static readonly StringName Poll = "poll";
        /// <summary>
        /// Cached name for the 'close' method.
        /// </summary>
        public static readonly StringName Close = "close";
        /// <summary>
        /// Cached name for the 'get_connected_host' method.
        /// </summary>
        public static readonly StringName GetConnectedHost = "get_connected_host";
        /// <summary>
        /// Cached name for the 'get_connected_port' method.
        /// </summary>
        public static readonly StringName GetConnectedPort = "get_connected_port";
        /// <summary>
        /// Cached name for the 'get_selected_protocol' method.
        /// </summary>
        public static readonly StringName GetSelectedProtocol = "get_selected_protocol";
        /// <summary>
        /// Cached name for the 'get_requested_url' method.
        /// </summary>
        public static readonly StringName GetRequestedUrl = "get_requested_url";
        /// <summary>
        /// Cached name for the 'set_no_delay' method.
        /// </summary>
        public static readonly StringName SetNoDelay = "set_no_delay";
        /// <summary>
        /// Cached name for the 'get_current_outbound_buffered_amount' method.
        /// </summary>
        public static readonly StringName GetCurrentOutboundBufferedAmount = "get_current_outbound_buffered_amount";
        /// <summary>
        /// Cached name for the 'get_ready_state' method.
        /// </summary>
        public static readonly StringName GetReadyState = "get_ready_state";
        /// <summary>
        /// Cached name for the 'get_close_code' method.
        /// </summary>
        public static readonly StringName GetCloseCode = "get_close_code";
        /// <summary>
        /// Cached name for the 'get_close_reason' method.
        /// </summary>
        public static readonly StringName GetCloseReason = "get_close_reason";
        /// <summary>
        /// Cached name for the 'get_supported_protocols' method.
        /// </summary>
        public static readonly StringName GetSupportedProtocols = "get_supported_protocols";
        /// <summary>
        /// Cached name for the 'set_supported_protocols' method.
        /// </summary>
        public static readonly StringName SetSupportedProtocols = "set_supported_protocols";
        /// <summary>
        /// Cached name for the 'get_handshake_headers' method.
        /// </summary>
        public static readonly StringName GetHandshakeHeaders = "get_handshake_headers";
        /// <summary>
        /// Cached name for the 'set_handshake_headers' method.
        /// </summary>
        public static readonly StringName SetHandshakeHeaders = "set_handshake_headers";
        /// <summary>
        /// Cached name for the 'get_inbound_buffer_size' method.
        /// </summary>
        public static readonly StringName GetInboundBufferSize = "get_inbound_buffer_size";
        /// <summary>
        /// Cached name for the 'set_inbound_buffer_size' method.
        /// </summary>
        public static readonly StringName SetInboundBufferSize = "set_inbound_buffer_size";
        /// <summary>
        /// Cached name for the 'get_outbound_buffer_size' method.
        /// </summary>
        public static readonly StringName GetOutboundBufferSize = "get_outbound_buffer_size";
        /// <summary>
        /// Cached name for the 'set_outbound_buffer_size' method.
        /// </summary>
        public static readonly StringName SetOutboundBufferSize = "set_outbound_buffer_size";
        /// <summary>
        /// Cached name for the 'set_max_queued_packets' method.
        /// </summary>
        public static readonly StringName SetMaxQueuedPackets = "set_max_queued_packets";
        /// <summary>
        /// Cached name for the 'get_max_queued_packets' method.
        /// </summary>
        public static readonly StringName GetMaxQueuedPackets = "get_max_queued_packets";
        /// <summary>
        /// Cached name for the 'set_heartbeat_interval' method.
        /// </summary>
        public static readonly StringName SetHeartbeatInterval = "set_heartbeat_interval";
        /// <summary>
        /// Cached name for the 'get_heartbeat_interval' method.
        /// </summary>
        public static readonly StringName GetHeartbeatInterval = "get_heartbeat_interval";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : PacketPeer.SignalName
    {
    }
}
