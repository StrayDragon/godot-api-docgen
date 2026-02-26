namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
public partial class PacketPeerExtension : PacketPeer
{
    private static readonly System.Type CachedType = typeof(PacketPeerExtension);

    private static readonly StringName NativeName = "PacketPeerExtension";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public PacketPeerExtension() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal PacketPeerExtension(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal PacketPeerExtension(bool memoryOwn) : base(memoryOwn) { }

    public virtual int _GetAvailablePacketCount()
    {
        return default;
    }

    public virtual int _GetMaxPacketSize()
    {
        return default;
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_available_packet_count = "_GetAvailablePacketCount";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_max_packet_size = "_GetMaxPacketSize";

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
        if ((method == MethodProxyName__get_available_packet_count || method == MethodName._GetAvailablePacketCount) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_available_packet_count.NativeValue))
        {
            var callRet = _GetAvailablePacketCount();
            ret = VariantUtils.CreateFrom<int>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_max_packet_size || method == MethodName._GetMaxPacketSize) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_max_packet_size.NativeValue))
        {
            var callRet = _GetMaxPacketSize();
            ret = VariantUtils.CreateFrom<int>(callRet);
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
        if (method == MethodName._GetAvailablePacketCount)
        {
            if (HasGodotClassMethod(MethodProxyName__get_available_packet_count.NativeValue.DangerousSelfRef))
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
        /// Cached name for the '_get_available_packet_count' method.
        /// </summary>
        public static readonly StringName _GetAvailablePacketCount = "_get_available_packet_count";
        /// <summary>
        /// Cached name for the '_get_max_packet_size' method.
        /// </summary>
        public static readonly StringName _GetMaxPacketSize = "_get_max_packet_size";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : PacketPeer.SignalName
    {
    }
}
