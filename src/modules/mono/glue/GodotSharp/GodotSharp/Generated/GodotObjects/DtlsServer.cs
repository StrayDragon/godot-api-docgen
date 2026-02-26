namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This class is used to store the state of a DTLS server. Upon <see cref="Godot.DtlsServer.Setup(TlsOptions)"/> it converts connected <see cref="Godot.PacketPeerUdp"/> to <see cref="Godot.PacketPeerDtls"/> accepting them via <see cref="Godot.DtlsServer.TakeConnection(PacketPeerUdp)"/> as DTLS clients. Under the hood, this class is used to store the DTLS state and cookies of the server. The reason of why the state and cookies are needed is outside of the scope of this documentation.</para>
/// <para>Below a small example of how to use it:</para>
/// <para><code>
/// // ServerNode.cs
/// using Godot;
/// 
/// public partial class ServerNode : Node
/// {
/// 	private DtlsServer _dtls = new DtlsServer();
/// 	private UdpServer _server = new UdpServer();
/// 	private Godot.Collections.Array&lt;PacketPeerDtls&gt; _peers = [];
/// 
/// 	public override void _Ready()
/// 	{
/// 		_server.Listen(4242);
/// 		var key = GD.Load&lt;CryptoKey&gt;("key.key"); // Your private key.
/// 		var cert = GD.Load&lt;X509Certificate&gt;("cert.crt"); // Your X509 certificate.
/// 		_dtls.Setup(TlsOptions.Server(key, cert));
/// 	}
/// 
/// 	public override void _Process(double delta)
/// 	{
/// 		while (_server.IsConnectionAvailable())
/// 		{
/// 			PacketPeerUdp peer = _server.TakeConnection();
/// 			PacketPeerDtls dtlsPeer = _dtls.TakeConnection(peer);
/// 			if (dtlsPeer.GetStatus() != PacketPeerDtls.Status.Handshaking)
/// 			{
/// 				continue; // It is normal that 50% of the connections fails due to cookie exchange.
/// 			}
/// 			GD.Print("Peer connected!");
/// 			_peers.Add(dtlsPeer);
/// 		}
/// 
/// 		foreach (var p in _peers)
/// 		{
/// 			p.Poll(); // Must poll to update the state.
/// 			if (p.GetStatus() == PacketPeerDtls.Status.Connected)
/// 			{
/// 				while (p.GetAvailablePacketCount() &gt; 0)
/// 				{
/// 					GD.Print($"Received Message From Client: {p.GetPacket().GetStringFromUtf8()}");
/// 					p.PutPacket("Hello DTLS Client".ToUtf8Buffer());
/// 				}
/// 			}
/// 		}
/// 	}
/// }
/// </code></para>
/// <para><code>
/// // ClientNode.cs
/// using Godot;
/// using System.Text;
/// 
/// public partial class ClientNode : Node
/// {
/// 	private PacketPeerDtls _dtls = new PacketPeerDtls();
/// 	private PacketPeerUdp _udp = new PacketPeerUdp();
/// 	private bool _connected = false;
/// 
/// 	public override void _Ready()
/// 	{
/// 		_udp.ConnectToHost("127.0.0.1", 4242);
/// 		_dtls.ConnectToPeer(_udp, validateCerts: false); // Use true in production for certificate validation!
/// 	}
/// 
/// 	public override void _Process(double delta)
/// 	{
/// 		_dtls.Poll();
/// 		if (_dtls.GetStatus() == PacketPeerDtls.Status.Connected)
/// 		{
/// 			if (!_connected)
/// 			{
/// 				// Try to contact server
/// 				_dtls.PutPacket("The Answer Is..42!".ToUtf8Buffer());
/// 			}
/// 			while (_dtls.GetAvailablePacketCount() &gt; 0)
/// 			{
/// 				GD.Print($"Connected: {_dtls.GetPacket().GetStringFromUtf8()}");
/// 				_connected = true;
/// 			}
/// 		}
/// 	}
/// }
/// </code></para>
/// </summary>
[GodotClassName("DTLSServer")]
public partial class DtlsServer : RefCounted
{
    private static readonly System.Type CachedType = typeof(DtlsServer);

    private static readonly StringName NativeName = "DTLSServer";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public DtlsServer() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal DtlsServer(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal DtlsServer(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Setup, 1262296096ul);

    /// <summary>
    /// <para>Setup the DTLS server to use the given <paramref name="serverOptions"/>. See <see cref="Godot.TlsOptions.Server(CryptoKey, X509Certificate)"/>.</para>
    /// </summary>
    public Error Setup(TlsOptions serverOptions)
    {
        return (Error)NativeCalls.godot_icall_1_371(MethodBind0, GodotObject.GetPtr(this), GodotObject.GetPtr(serverOptions));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.TakeConnection, 3946580474ul);

    /// <summary>
    /// <para>Try to initiate the DTLS handshake with the given <paramref name="udpPeer"/> which must be already connected (see <see cref="Godot.PacketPeerUdp.ConnectToHost(string, int)"/>).</para>
    /// <para><b>Note:</b> You must check that the state of the return PacketPeerUDP is <see cref="Godot.PacketPeerDtls.Status.Handshaking"/>, as it is normal that 50% of the new connections will be invalid due to cookie exchange.</para>
    /// </summary>
    public PacketPeerDtls TakeConnection(PacketPeerUdp udpPeer)
    {
        return (PacketPeerDtls)NativeCalls.godot_icall_1_268(MethodBind1, GodotObject.GetPtr(this), GodotObject.GetPtr(udpPeer));
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
        /// Cached name for the 'setup' method.
        /// </summary>
        public static readonly StringName Setup = "setup";
        /// <summary>
        /// Cached name for the 'take_connection' method.
        /// </summary>
        public static readonly StringName TakeConnection = "take_connection";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : RefCounted.SignalName
    {
    }
}
