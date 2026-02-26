namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This class is designed to be inherited from a GDExtension plugin to implement custom networking layers for the multiplayer API (such as WebRTC). All the methods below <b>must</b> be implemented to have a working custom multiplayer implementation. See also <see cref="Godot.MultiplayerApi"/>.</para>
/// </summary>
public partial class MultiplayerPeerExtension : MultiplayerPeer
{
    private static readonly System.Type CachedType = typeof(MultiplayerPeerExtension);

    private static readonly StringName NativeName = "MultiplayerPeerExtension";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public MultiplayerPeerExtension() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal MultiplayerPeerExtension(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal MultiplayerPeerExtension(bool memoryOwn) : base(memoryOwn) { }

    /// <summary>
    /// <para>Called when the multiplayer peer should be immediately closed (see <see cref="Godot.MultiplayerPeer.Close()"/>).</para>
    /// </summary>
    public virtual void _Close()
    {
    }

    /// <summary>
    /// <para>Called when the connected <paramref name="pPeer"/> should be forcibly disconnected (see <see cref="Godot.MultiplayerPeer.DisconnectPeer(int, bool)"/>).</para>
    /// </summary>
    public virtual void _DisconnectPeer(int pPeer, bool pForce)
    {
    }

    /// <summary>
    /// <para>Called when the available packet count is internally requested by the <see cref="Godot.MultiplayerApi"/>.</para>
    /// </summary>
    public virtual int _GetAvailablePacketCount()
    {
        return default;
    }

    /// <summary>
    /// <para>Called when the connection status is requested on the <see cref="Godot.MultiplayerPeer"/> (see <see cref="Godot.MultiplayerPeer.GetConnectionStatus()"/>).</para>
    /// </summary>
    public virtual MultiplayerPeer.ConnectionStatus _GetConnectionStatus()
    {
        return default;
    }

    /// <summary>
    /// <para>Called when the maximum allowed packet size (in bytes) is requested by the <see cref="Godot.MultiplayerApi"/>.</para>
    /// </summary>
    public virtual int _GetMaxPacketSize()
    {
        return default;
    }

    /// <summary>
    /// <para>Called to get the channel over which the next available packet was received. See <see cref="Godot.MultiplayerPeer.GetPacketChannel()"/>.</para>
    /// </summary>
    public virtual int _GetPacketChannel()
    {
        return default;
    }

    /// <summary>
    /// <para>Called to get the transfer mode the remote peer used to send the next available packet. See <see cref="Godot.MultiplayerPeer.GetPacketMode()"/>.</para>
    /// </summary>
    public virtual MultiplayerPeer.TransferModeEnum _GetPacketMode()
    {
        return default;
    }

    /// <summary>
    /// <para>Called when the ID of the <see cref="Godot.MultiplayerPeer"/> who sent the most recent packet is requested (see <see cref="Godot.MultiplayerPeer.GetPacketPeer()"/>).</para>
    /// </summary>
    public virtual int _GetPacketPeer()
    {
        return default;
    }

    /// <summary>
    /// <para>Called when a packet needs to be received by the <see cref="Godot.MultiplayerApi"/>, if <c>_get_packet</c> isn't implemented. Use this when extending this class via GDScript.</para>
    /// </summary>
    public virtual byte[] _GetPacketScript()
    {
        return default;
    }

    /// <summary>
    /// <para>Called when the transfer channel to use is read on this <see cref="Godot.MultiplayerPeer"/> (see <see cref="Godot.MultiplayerPeer.TransferChannel"/>).</para>
    /// </summary>
    public virtual int _GetTransferChannel()
    {
        return default;
    }

    /// <summary>
    /// <para>Called when the transfer mode to use is read on this <see cref="Godot.MultiplayerPeer"/> (see <see cref="Godot.MultiplayerPeer.TransferMode"/>).</para>
    /// </summary>
    public virtual MultiplayerPeer.TransferModeEnum _GetTransferMode()
    {
        return default;
    }

    /// <summary>
    /// <para>Called when the unique ID of this <see cref="Godot.MultiplayerPeer"/> is requested (see <see cref="Godot.MultiplayerPeer.GetUniqueId()"/>). The value must be between <c>1</c> and <c>2147483647</c>.</para>
    /// </summary>
    public virtual int _GetUniqueId()
    {
        return default;
    }

    /// <summary>
    /// <para>Called when the "refuse new connections" status is requested on this <see cref="Godot.MultiplayerPeer"/> (see <see cref="Godot.MultiplayerPeer.RefuseNewConnections"/>).</para>
    /// </summary>
    public virtual bool _IsRefusingNewConnections()
    {
        return default;
    }

    /// <summary>
    /// <para>Called when the "is server" status is requested on the <see cref="Godot.MultiplayerApi"/>. See <see cref="Godot.MultiplayerApi.IsServer()"/>.</para>
    /// </summary>
    public virtual bool _IsServer()
    {
        return default;
    }

    /// <summary>
    /// <para>Called to check if the server can act as a relay in the current configuration. See <see cref="Godot.MultiplayerPeer.IsServerRelaySupported()"/>.</para>
    /// </summary>
    public virtual bool _IsServerRelaySupported()
    {
        return default;
    }

    /// <summary>
    /// <para>Called when the <see cref="Godot.MultiplayerApi"/> is polled. See <see cref="Godot.MultiplayerApi.Poll()"/>.</para>
    /// </summary>
    public virtual void _Poll()
    {
    }

    /// <summary>
    /// <para>Called when a packet needs to be sent by the <see cref="Godot.MultiplayerApi"/>, if <c>_put_packet</c> isn't implemented. Use this when extending this class via GDScript.</para>
    /// </summary>
    public virtual Error _PutPacketScript(byte[] pBuffer)
    {
        return default;
    }

    /// <summary>
    /// <para>Called when the "refuse new connections" status is set on this <see cref="Godot.MultiplayerPeer"/> (see <see cref="Godot.MultiplayerPeer.RefuseNewConnections"/>).</para>
    /// </summary>
    public virtual void _SetRefuseNewConnections(bool pEnable)
    {
    }

    /// <summary>
    /// <para>Called when the target peer to use is set for this <see cref="Godot.MultiplayerPeer"/> (see <see cref="Godot.MultiplayerPeer.SetTargetPeer(int)"/>).</para>
    /// </summary>
    public virtual void _SetTargetPeer(int pPeer)
    {
    }

    /// <summary>
    /// <para>Called when the channel to use is set for this <see cref="Godot.MultiplayerPeer"/> (see <see cref="Godot.MultiplayerPeer.TransferChannel"/>).</para>
    /// </summary>
    public virtual void _SetTransferChannel(int pChannel)
    {
    }

    /// <summary>
    /// <para>Called when the transfer mode is set on this <see cref="Godot.MultiplayerPeer"/> (see <see cref="Godot.MultiplayerPeer.TransferMode"/>).</para>
    /// </summary>
    public virtual void _SetTransferMode(MultiplayerPeer.TransferModeEnum pMode)
    {
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__close = "_Close";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__disconnect_peer = "_DisconnectPeer";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_available_packet_count = "_GetAvailablePacketCount";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_connection_status = "_GetConnectionStatus";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_max_packet_size = "_GetMaxPacketSize";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_packet_channel = "_GetPacketChannel";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_packet_mode = "_GetPacketMode";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_packet_peer = "_GetPacketPeer";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_packet_script = "_GetPacketScript";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_transfer_channel = "_GetTransferChannel";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_transfer_mode = "_GetTransferMode";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_unique_id = "_GetUniqueId";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__is_refusing_new_connections = "_IsRefusingNewConnections";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__is_server = "_IsServer";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__is_server_relay_supported = "_IsServerRelaySupported";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__poll = "_Poll";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__put_packet_script = "_PutPacketScript";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__set_refuse_new_connections = "_SetRefuseNewConnections";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__set_target_peer = "_SetTargetPeer";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__set_transfer_channel = "_SetTransferChannel";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__set_transfer_mode = "_SetTransferMode";

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
        if ((method == MethodProxyName__close || method == MethodName._Close) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__close.NativeValue))
        {
            _Close();
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__disconnect_peer || method == MethodName._DisconnectPeer) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__disconnect_peer.NativeValue))
        {
            _DisconnectPeer(VariantUtils.ConvertTo<int>(args[0]), VariantUtils.ConvertTo<bool>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__get_available_packet_count || method == MethodName._GetAvailablePacketCount) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_available_packet_count.NativeValue))
        {
            var callRet = _GetAvailablePacketCount();
            ret = VariantUtils.CreateFrom<int>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_connection_status || method == MethodName._GetConnectionStatus) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_connection_status.NativeValue))
        {
            var callRet = _GetConnectionStatus();
            ret = VariantUtils.CreateFrom<MultiplayerPeer.ConnectionStatus>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_max_packet_size || method == MethodName._GetMaxPacketSize) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_max_packet_size.NativeValue))
        {
            var callRet = _GetMaxPacketSize();
            ret = VariantUtils.CreateFrom<int>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_packet_channel || method == MethodName._GetPacketChannel) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_packet_channel.NativeValue))
        {
            var callRet = _GetPacketChannel();
            ret = VariantUtils.CreateFrom<int>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_packet_mode || method == MethodName._GetPacketMode) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_packet_mode.NativeValue))
        {
            var callRet = _GetPacketMode();
            ret = VariantUtils.CreateFrom<MultiplayerPeer.TransferModeEnum>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_packet_peer || method == MethodName._GetPacketPeer) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_packet_peer.NativeValue))
        {
            var callRet = _GetPacketPeer();
            ret = VariantUtils.CreateFrom<int>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_packet_script || method == MethodName._GetPacketScript) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_packet_script.NativeValue))
        {
            var callRet = _GetPacketScript();
            ret = VariantUtils.CreateFrom<byte[]>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_transfer_channel || method == MethodName._GetTransferChannel) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_transfer_channel.NativeValue))
        {
            var callRet = _GetTransferChannel();
            ret = VariantUtils.CreateFrom<int>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_transfer_mode || method == MethodName._GetTransferMode) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_transfer_mode.NativeValue))
        {
            var callRet = _GetTransferMode();
            ret = VariantUtils.CreateFrom<MultiplayerPeer.TransferModeEnum>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_unique_id || method == MethodName._GetUniqueId) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_unique_id.NativeValue))
        {
            var callRet = _GetUniqueId();
            ret = VariantUtils.CreateFrom<int>(callRet);
            return true;
        }
        if ((method == MethodProxyName__is_refusing_new_connections || method == MethodName._IsRefusingNewConnections) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__is_refusing_new_connections.NativeValue))
        {
            var callRet = _IsRefusingNewConnections();
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__is_server || method == MethodName._IsServer) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__is_server.NativeValue))
        {
            var callRet = _IsServer();
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__is_server_relay_supported || method == MethodName._IsServerRelaySupported) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__is_server_relay_supported.NativeValue))
        {
            var callRet = _IsServerRelaySupported();
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__poll || method == MethodName._Poll) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__poll.NativeValue))
        {
            _Poll();
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__put_packet_script || method == MethodName._PutPacketScript) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__put_packet_script.NativeValue))
        {
            var callRet = _PutPacketScript(VariantUtils.ConvertTo<byte[]>(args[0]));
            ret = VariantUtils.CreateFrom<Error>(callRet);
            return true;
        }
        if ((method == MethodProxyName__set_refuse_new_connections || method == MethodName._SetRefuseNewConnections) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__set_refuse_new_connections.NativeValue))
        {
            _SetRefuseNewConnections(VariantUtils.ConvertTo<bool>(args[0]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__set_target_peer || method == MethodName._SetTargetPeer) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__set_target_peer.NativeValue))
        {
            _SetTargetPeer(VariantUtils.ConvertTo<int>(args[0]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__set_transfer_channel || method == MethodName._SetTransferChannel) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__set_transfer_channel.NativeValue))
        {
            _SetTransferChannel(VariantUtils.ConvertTo<int>(args[0]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__set_transfer_mode || method == MethodName._SetTransferMode) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__set_transfer_mode.NativeValue))
        {
            _SetTransferMode(VariantUtils.ConvertTo<MultiplayerPeer.TransferModeEnum>(args[0]));
            ret = default;
            return true;
        }
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
        if (method == MethodName._Close)
        {
            if (HasGodotClassMethod(MethodProxyName__close.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._DisconnectPeer)
        {
            if (HasGodotClassMethod(MethodProxyName__disconnect_peer.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetAvailablePacketCount)
        {
            if (HasGodotClassMethod(MethodProxyName__get_available_packet_count.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetConnectionStatus)
        {
            if (HasGodotClassMethod(MethodProxyName__get_connection_status.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetMaxPacketSize)
        {
            if (HasGodotClassMethod(MethodProxyName__get_max_packet_size.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetPacketChannel)
        {
            if (HasGodotClassMethod(MethodProxyName__get_packet_channel.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetPacketMode)
        {
            if (HasGodotClassMethod(MethodProxyName__get_packet_mode.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetPacketPeer)
        {
            if (HasGodotClassMethod(MethodProxyName__get_packet_peer.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetPacketScript)
        {
            if (HasGodotClassMethod(MethodProxyName__get_packet_script.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetTransferChannel)
        {
            if (HasGodotClassMethod(MethodProxyName__get_transfer_channel.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetTransferMode)
        {
            if (HasGodotClassMethod(MethodProxyName__get_transfer_mode.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetUniqueId)
        {
            if (HasGodotClassMethod(MethodProxyName__get_unique_id.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._IsRefusingNewConnections)
        {
            if (HasGodotClassMethod(MethodProxyName__is_refusing_new_connections.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._IsServer)
        {
            if (HasGodotClassMethod(MethodProxyName__is_server.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._IsServerRelaySupported)
        {
            if (HasGodotClassMethod(MethodProxyName__is_server_relay_supported.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._Poll)
        {
            if (HasGodotClassMethod(MethodProxyName__poll.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._PutPacketScript)
        {
            if (HasGodotClassMethod(MethodProxyName__put_packet_script.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._SetRefuseNewConnections)
        {
            if (HasGodotClassMethod(MethodProxyName__set_refuse_new_connections.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._SetTargetPeer)
        {
            if (HasGodotClassMethod(MethodProxyName__set_target_peer.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._SetTransferChannel)
        {
            if (HasGodotClassMethod(MethodProxyName__set_transfer_channel.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._SetTransferMode)
        {
            if (HasGodotClassMethod(MethodProxyName__set_transfer_mode.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
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
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : MultiplayerPeer.MethodName
    {
        /// <summary>
        /// Cached name for the '_close' method.
        /// </summary>
        public static readonly StringName _Close = "_close";
        /// <summary>
        /// Cached name for the '_disconnect_peer' method.
        /// </summary>
        public static readonly StringName _DisconnectPeer = "_disconnect_peer";
        /// <summary>
        /// Cached name for the '_get_available_packet_count' method.
        /// </summary>
        public static readonly StringName _GetAvailablePacketCount = "_get_available_packet_count";
        /// <summary>
        /// Cached name for the '_get_connection_status' method.
        /// </summary>
        public static readonly StringName _GetConnectionStatus = "_get_connection_status";
        /// <summary>
        /// Cached name for the '_get_max_packet_size' method.
        /// </summary>
        public static readonly StringName _GetMaxPacketSize = "_get_max_packet_size";
        /// <summary>
        /// Cached name for the '_get_packet_channel' method.
        /// </summary>
        public static readonly StringName _GetPacketChannel = "_get_packet_channel";
        /// <summary>
        /// Cached name for the '_get_packet_mode' method.
        /// </summary>
        public static readonly StringName _GetPacketMode = "_get_packet_mode";
        /// <summary>
        /// Cached name for the '_get_packet_peer' method.
        /// </summary>
        public static readonly StringName _GetPacketPeer = "_get_packet_peer";
        /// <summary>
        /// Cached name for the '_get_packet_script' method.
        /// </summary>
        public static readonly StringName _GetPacketScript = "_get_packet_script";
        /// <summary>
        /// Cached name for the '_get_transfer_channel' method.
        /// </summary>
        public static readonly StringName _GetTransferChannel = "_get_transfer_channel";
        /// <summary>
        /// Cached name for the '_get_transfer_mode' method.
        /// </summary>
        public static readonly StringName _GetTransferMode = "_get_transfer_mode";
        /// <summary>
        /// Cached name for the '_get_unique_id' method.
        /// </summary>
        public static readonly StringName _GetUniqueId = "_get_unique_id";
        /// <summary>
        /// Cached name for the '_is_refusing_new_connections' method.
        /// </summary>
        public static readonly StringName _IsRefusingNewConnections = "_is_refusing_new_connections";
        /// <summary>
        /// Cached name for the '_is_server' method.
        /// </summary>
        public static readonly StringName _IsServer = "_is_server";
        /// <summary>
        /// Cached name for the '_is_server_relay_supported' method.
        /// </summary>
        public static readonly StringName _IsServerRelaySupported = "_is_server_relay_supported";
        /// <summary>
        /// Cached name for the '_poll' method.
        /// </summary>
        public static readonly StringName _Poll = "_poll";
        /// <summary>
        /// Cached name for the '_put_packet_script' method.
        /// </summary>
        public static readonly StringName _PutPacketScript = "_put_packet_script";
        /// <summary>
        /// Cached name for the '_set_refuse_new_connections' method.
        /// </summary>
        public static readonly StringName _SetRefuseNewConnections = "_set_refuse_new_connections";
        /// <summary>
        /// Cached name for the '_set_target_peer' method.
        /// </summary>
        public static readonly StringName _SetTargetPeer = "_set_target_peer";
        /// <summary>
        /// Cached name for the '_set_transfer_channel' method.
        /// </summary>
        public static readonly StringName _SetTransferChannel = "_set_transfer_channel";
        /// <summary>
        /// Cached name for the '_set_transfer_mode' method.
        /// </summary>
        public static readonly StringName _SetTransferMode = "_set_transfer_mode";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : MultiplayerPeer.SignalName
    {
    }
}
