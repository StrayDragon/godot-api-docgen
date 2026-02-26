namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A sequence of Ogg packets.</para>
/// </summary>
public partial class OggPacketSequence : Resource
{
    /// <summary>
    /// <para>Contains the raw packets that make up this OggPacketSequence.</para>
    /// </summary>
    public Godot.Collections.Array<Godot.Collections.Array> PacketData
    {
        get
        {
            return GetPacketData();
        }
        set
        {
            SetPacketData(value);
        }
    }

    /// <summary>
    /// <para>Contains the granule positions for each page in this packet sequence.</para>
    /// </summary>
    public long[] GranulePositions
    {
        get
        {
            return GetPacketGranulePositions();
        }
        set
        {
            SetPacketGranulePositions(value);
        }
    }

    /// <summary>
    /// <para>Holds sample rate information about this sequence. Must be set by another class that actually understands the codec.</para>
    /// </summary>
    public float SamplingRate
    {
        get
        {
            return GetSamplingRate();
        }
        set
        {
            SetSamplingRate(value);
        }
    }

    private static readonly System.Type CachedType = typeof(OggPacketSequence);

    private static readonly StringName NativeName = "OggPacketSequence";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public OggPacketSequence() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal OggPacketSequence(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal OggPacketSequence(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPacketData, 381264803ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPacketData(Godot.Collections.Array<Godot.Collections.Array> packetData)
    {
        NativeCalls.godot_icall_1_138(MethodBind0, GodotObject.GetPtr(this), (godot_array)(packetData ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPacketData, 3995934104ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Godot.Collections.Array<Godot.Collections.Array> GetPacketData()
    {
        return new Godot.Collections.Array<Godot.Collections.Array>(NativeCalls.godot_icall_0_120(MethodBind1, GodotObject.GetPtr(this)));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPacketGranulePositions, 3709968205ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPacketGranulePositions(long[] granulePositions)
    {
        NativeCalls.godot_icall_1_844(MethodBind2, GodotObject.GetPtr(this), granulePositions);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPacketGranulePositions(ReadOnlySpan<long> granulePositions)
    {
        NativeCalls.godot_icall_1_844(MethodBind2, GodotObject.GetPtr(this), granulePositions);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPacketGranulePositions, 235988956ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public long[] GetPacketGranulePositions()
    {
        return NativeCalls.godot_icall_0_13(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSamplingRate, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSamplingRate(float samplingRate)
    {
        NativeCalls.godot_icall_1_67(MethodBind4, GodotObject.GetPtr(this), samplingRate);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSamplingRate, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetSamplingRate()
    {
        return NativeCalls.godot_icall_0_68(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLength, 1740695150ul);

    /// <summary>
    /// <para>The length of this stream, in seconds.</para>
    /// </summary>
    public float GetLength()
    {
        return NativeCalls.godot_icall_0_68(MethodBind6, GodotObject.GetPtr(this));
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
    public new class PropertyName : Resource.PropertyName
    {
        /// <summary>
        /// Cached name for the 'packet_data' property.
        /// </summary>
        public static readonly StringName PacketData = "packet_data";
        /// <summary>
        /// Cached name for the 'granule_positions' property.
        /// </summary>
        public static readonly StringName GranulePositions = "granule_positions";
        /// <summary>
        /// Cached name for the 'sampling_rate' property.
        /// </summary>
        public static readonly StringName SamplingRate = "sampling_rate";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Resource.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_packet_data' method.
        /// </summary>
        public static readonly StringName SetPacketData = "set_packet_data";
        /// <summary>
        /// Cached name for the 'get_packet_data' method.
        /// </summary>
        public static readonly StringName GetPacketData = "get_packet_data";
        /// <summary>
        /// Cached name for the 'set_packet_granule_positions' method.
        /// </summary>
        public static readonly StringName SetPacketGranulePositions = "set_packet_granule_positions";
        /// <summary>
        /// Cached name for the 'get_packet_granule_positions' method.
        /// </summary>
        public static readonly StringName GetPacketGranulePositions = "get_packet_granule_positions";
        /// <summary>
        /// Cached name for the 'set_sampling_rate' method.
        /// </summary>
        public static readonly StringName SetSamplingRate = "set_sampling_rate";
        /// <summary>
        /// Cached name for the 'get_sampling_rate' method.
        /// </summary>
        public static readonly StringName GetSamplingRate = "get_sampling_rate";
        /// <summary>
        /// Cached name for the 'get_length' method.
        /// </summary>
        public static readonly StringName GetLength = "get_length";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Resource.SignalName
    {
    }
}
