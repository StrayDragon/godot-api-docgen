namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Base class for WebSocket server and client, allowing them to be used as multiplayer peer for the <see cref="Godot.MultiplayerApi"/>.</para>
/// <para><b>Note:</b> When exporting to Android, make sure to enable the <c>INTERNET</c> permission in the Android export preset before exporting the project or using one-click deploy. Otherwise, network communication of any kind will be blocked by Android.</para>
/// </summary>
public partial class WebSocketMultiplayerPeer : MultiplayerPeer
{
    /// <summary>
    /// <para>The supported WebSocket sub-protocols. See <see cref="Godot.WebSocketPeer.SupportedProtocols"/> for more details.</para>
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
    /// <para>The extra headers to use during handshake. See <see cref="Godot.WebSocketPeer.HandshakeHeaders"/> for more details.</para>
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
    /// <para>The inbound buffer size for connected peers. See <see cref="Godot.WebSocketPeer.InboundBufferSize"/> for more details.</para>
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
    /// <para>The outbound buffer size for connected peers. See <see cref="Godot.WebSocketPeer.OutboundBufferSize"/> for more details.</para>
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
    /// <para>The maximum time each peer can stay in a connecting state before being dropped.</para>
    /// </summary>
    public float HandshakeTimeout
    {
        get
        {
            return GetHandshakeTimeout();
        }
        set
        {
            SetHandshakeTimeout(value);
        }
    }

    /// <summary>
    /// <para>The maximum number of queued packets for connected peers. See <see cref="Godot.WebSocketPeer.MaxQueuedPackets"/> for more details.</para>
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

    private static readonly System.Type CachedType = typeof(WebSocketMultiplayerPeer);

    private static readonly StringName NativeName = "WebSocketMultiplayerPeer";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public WebSocketMultiplayerPeer() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal WebSocketMultiplayerPeer(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal WebSocketMultiplayerPeer(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CreateClient, 1966198364ul);

    /// <summary>
    /// <para>Starts a new multiplayer client connecting to the given <paramref name="url"/>. TLS certificates will be verified against the hostname when connecting using the <c>wss://</c> protocol. You can pass the optional <paramref name="tlsClientOptions"/> parameter to customize the trusted certification authorities, or disable the common name verification. See <see cref="Godot.TlsOptions.Client(X509Certificate, string)"/> and <see cref="Godot.TlsOptions.ClientUnsafe(X509Certificate)"/>.</para>
    /// <para><b>Note:</b> It is recommended to specify the scheme part of the URL, i.e. the <paramref name="url"/> should start with either <c>ws://</c> or <c>wss://</c>.</para>
    /// </summary>
    public Error CreateClient(string url, TlsOptions tlsClientOptions = null)
    {
        return (Error)NativeCalls.godot_icall_2_459(MethodBind0, GodotObject.GetPtr(this), url, GodotObject.GetPtr(tlsClientOptions));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CreateServer, 2400822951ul);

    /// <summary>
    /// <para>Starts a new multiplayer server listening on the given <paramref name="port"/>. You can optionally specify a <paramref name="bindAddress"/>, and provide valid <paramref name="tlsServerOptions"/> to use TLS. See <see cref="Godot.TlsOptions.Server(CryptoKey, X509Certificate)"/>.</para>
    /// </summary>
    public Error CreateServer(int port, string bindAddress = "*", TlsOptions tlsServerOptions = null)
    {
        return (Error)NativeCalls.godot_icall_3_1503(MethodBind1, GodotObject.GetPtr(this), port, bindAddress, GodotObject.GetPtr(tlsServerOptions));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPeer, 1381378851ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.WebSocketPeer"/> associated to the given <paramref name="peerId"/>.</para>
    /// </summary>
    public WebSocketPeer GetPeer(int peerId)
    {
        return (WebSocketPeer)NativeCalls.godot_icall_1_71(MethodBind2, GodotObject.GetPtr(this), peerId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPeerAddress, 844755477ul);

    /// <summary>
    /// <para>Returns the IP address of the given peer.</para>
    /// </summary>
    public string GetPeerAddress(int id)
    {
        return NativeCalls.godot_icall_1_133(MethodBind3, GodotObject.GetPtr(this), id);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPeerPort, 923996154ul);

    /// <summary>
    /// <para>Returns the remote port of the given peer.</para>
    /// </summary>
    public int GetPeerPort(int id)
    {
        return NativeCalls.godot_icall_1_60(MethodBind4, GodotObject.GetPtr(this), id);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSupportedProtocols, 1139954409ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string[] GetSupportedProtocols()
    {
        return NativeCalls.godot_icall_0_108(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSupportedProtocols, 4015028928ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSupportedProtocols(string[] protocols)
    {
        NativeCalls.godot_icall_1_185(MethodBind6, GodotObject.GetPtr(this), protocols);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSupportedProtocols(ReadOnlySpan<string> protocols)
    {
        NativeCalls.godot_icall_1_185(MethodBind6, GodotObject.GetPtr(this), protocols);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetHandshakeHeaders, 1139954409ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string[] GetHandshakeHeaders()
    {
        return NativeCalls.godot_icall_0_108(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetHandshakeHeaders, 4015028928ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetHandshakeHeaders(string[] protocols)
    {
        NativeCalls.godot_icall_1_185(MethodBind8, GodotObject.GetPtr(this), protocols);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetHandshakeHeaders(ReadOnlySpan<string> protocols)
    {
        NativeCalls.godot_icall_1_185(MethodBind8, GodotObject.GetPtr(this), protocols);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetInboundBufferSize, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetInboundBufferSize()
    {
        return NativeCalls.godot_icall_0_39(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetInboundBufferSize, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetInboundBufferSize(int bufferSize)
    {
        NativeCalls.godot_icall_1_38(MethodBind10, GodotObject.GetPtr(this), bufferSize);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOutboundBufferSize, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetOutboundBufferSize()
    {
        return NativeCalls.godot_icall_0_39(MethodBind11, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetOutboundBufferSize, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetOutboundBufferSize(int bufferSize)
    {
        NativeCalls.godot_icall_1_38(MethodBind12, GodotObject.GetPtr(this), bufferSize);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetHandshakeTimeout, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetHandshakeTimeout()
    {
        return NativeCalls.godot_icall_0_68(MethodBind13, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetHandshakeTimeout, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetHandshakeTimeout(float timeout)
    {
        NativeCalls.godot_icall_1_67(MethodBind14, GodotObject.GetPtr(this), timeout);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMaxQueuedPackets, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMaxQueuedPackets(int maxQueuedPackets)
    {
        NativeCalls.godot_icall_1_38(MethodBind15, GodotObject.GetPtr(this), maxQueuedPackets);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMaxQueuedPackets, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetMaxQueuedPackets()
    {
        return NativeCalls.godot_icall_0_39(MethodBind16, GodotObject.GetPtr(this));
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
    public new class PropertyName : MultiplayerPeer.PropertyName
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
        /// Cached name for the 'handshake_timeout' property.
        /// </summary>
        public static readonly StringName HandshakeTimeout = "handshake_timeout";
        /// <summary>
        /// Cached name for the 'max_queued_packets' property.
        /// </summary>
        public static readonly StringName MaxQueuedPackets = "max_queued_packets";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : MultiplayerPeer.MethodName
    {
        /// <summary>
        /// Cached name for the 'create_client' method.
        /// </summary>
        public static readonly StringName CreateClient = "create_client";
        /// <summary>
        /// Cached name for the 'create_server' method.
        /// </summary>
        public static readonly StringName CreateServer = "create_server";
        /// <summary>
        /// Cached name for the 'get_peer' method.
        /// </summary>
        public static readonly StringName GetPeer = "get_peer";
        /// <summary>
        /// Cached name for the 'get_peer_address' method.
        /// </summary>
        public static readonly StringName GetPeerAddress = "get_peer_address";
        /// <summary>
        /// Cached name for the 'get_peer_port' method.
        /// </summary>
        public static readonly StringName GetPeerPort = "get_peer_port";
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
        /// Cached name for the 'get_handshake_timeout' method.
        /// </summary>
        public static readonly StringName GetHandshakeTimeout = "get_handshake_timeout";
        /// <summary>
        /// Cached name for the 'set_handshake_timeout' method.
        /// </summary>
        public static readonly StringName SetHandshakeTimeout = "set_handshake_timeout";
        /// <summary>
        /// Cached name for the 'set_max_queued_packets' method.
        /// </summary>
        public static readonly StringName SetMaxQueuedPackets = "set_max_queued_packets";
        /// <summary>
        /// Cached name for the 'get_max_queued_packets' method.
        /// </summary>
        public static readonly StringName GetMaxQueuedPackets = "get_max_queued_packets";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : MultiplayerPeer.SignalName
    {
    }
}
