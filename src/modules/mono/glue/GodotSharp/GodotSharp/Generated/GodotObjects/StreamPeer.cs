namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>StreamPeer is an abstract base class mostly used for stream-based protocols (such as TCP). It provides an API for sending and receiving data through streams as raw data or strings.</para>
/// <para><b>Note:</b> When exporting to Android, make sure to enable the <c>INTERNET</c> permission in the Android export preset before exporting the project or using one-click deploy. Otherwise, network communication of any kind will be blocked by Android.</para>
/// </summary>
public partial class StreamPeer : RefCounted
{
    /// <summary>
    /// <para>If <see langword="true"/>, this <see cref="Godot.StreamPeer"/> will using big-endian format for encoding and decoding.</para>
    /// </summary>
    public bool BigEndian
    {
        get
        {
            return IsBigEndianEnabled();
        }
        set
        {
            SetBigEndian(value);
        }
    }

    private static readonly System.Type CachedType = typeof(StreamPeer);

    private static readonly StringName NativeName = "StreamPeer";

    internal StreamPeer() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal StreamPeer(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal StreamPeer(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PutData, 680677267ul);

    /// <summary>
    /// <para>Sends a chunk of data through the connection, blocking if necessary until the data is done sending. This function returns an <see cref="Godot.Error"/> code.</para>
    /// </summary>
    public Error PutData(byte[] data)
    {
        return (Error)NativeCalls.godot_icall_1_713(MethodBind0, GodotObject.GetPtr(this), data);
    }

    /// <summary>
    /// <para>Sends a chunk of data through the connection, blocking if necessary until the data is done sending. This function returns an <see cref="Godot.Error"/> code.</para>
    /// </summary>
    public Error PutData(ReadOnlySpan<byte> data)
    {
        return (Error)NativeCalls.godot_icall_1_713(MethodBind0, GodotObject.GetPtr(this), data);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PutPartialData, 2934048347ul);

    /// <summary>
    /// <para>Sends a chunk of data through the connection. If all the data could not be sent at once, only part of it will. This function returns two values, an <see cref="Godot.Error"/> code and an integer, describing how much data was actually sent.</para>
    /// </summary>
    public Godot.Collections.Array PutPartialData(byte[] data)
    {
        return NativeCalls.godot_icall_1_1282(MethodBind1, GodotObject.GetPtr(this), data);
    }

    /// <summary>
    /// <para>Sends a chunk of data through the connection. If all the data could not be sent at once, only part of it will. This function returns two values, an <see cref="Godot.Error"/> code and an integer, describing how much data was actually sent.</para>
    /// </summary>
    public Godot.Collections.Array PutPartialData(ReadOnlySpan<byte> data)
    {
        return NativeCalls.godot_icall_1_1282(MethodBind1, GodotObject.GetPtr(this), data);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetData, 1171824711ul);

    /// <summary>
    /// <para>Returns a chunk data with the received bytes, as an <see cref="Godot.Collections.Array"/> containing two elements: an <see cref="Godot.Error"/> constant and a <see cref="byte"/>[]. <paramref name="bytes"/> is the number of bytes to be received. If not enough bytes are available, the function will block until the desired amount is received.</para>
    /// </summary>
    public Godot.Collections.Array GetData(int bytes)
    {
        return NativeCalls.godot_icall_1_457(MethodBind2, GodotObject.GetPtr(this), bytes);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPartialData, 1171824711ul);

    /// <summary>
    /// <para>Returns a chunk data with the received bytes, as an <see cref="Godot.Collections.Array"/> containing two elements: an <see cref="Godot.Error"/> constant and a <see cref="byte"/>[]. <paramref name="bytes"/> is the number of bytes to be received. If not enough bytes are available, the function will return how many were actually received.</para>
    /// </summary>
    public Godot.Collections.Array GetPartialData(int bytes)
    {
        return NativeCalls.godot_icall_1_457(MethodBind3, GodotObject.GetPtr(this), bytes);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAvailableBytes, 3905245786ul);

    /// <summary>
    /// <para>Returns the number of bytes this <see cref="Godot.StreamPeer"/> has available.</para>
    /// </summary>
    public int GetAvailableBytes()
    {
        return NativeCalls.godot_icall_0_39(MethodBind4, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBigEndian, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetBigEndian(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind5, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsBigEndianEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsBigEndianEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind6, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Put8, 1286410249ul);

    /// <summary>
    /// <para>Puts a signed byte into the stream.</para>
    /// </summary>
    public void Put8(sbyte value)
    {
        NativeCalls.godot_icall_1_1283(MethodBind7, GodotObject.GetPtr(this), value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PutU8, 1286410249ul);

    /// <summary>
    /// <para>Puts an unsigned byte into the stream.</para>
    /// </summary>
    public void PutU8(byte value)
    {
        NativeCalls.godot_icall_1_283(MethodBind8, GodotObject.GetPtr(this), value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Put16, 1286410249ul);

    /// <summary>
    /// <para>Puts a signed 16-bit value into the stream.</para>
    /// </summary>
    public void Put16(short value)
    {
        NativeCalls.godot_icall_1_1284(MethodBind9, GodotObject.GetPtr(this), value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PutU16, 1286410249ul);

    /// <summary>
    /// <para>Puts an unsigned 16-bit value into the stream.</para>
    /// </summary>
    public void PutU16(ushort value)
    {
        NativeCalls.godot_icall_1_285(MethodBind10, GodotObject.GetPtr(this), value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Put32, 1286410249ul);

    /// <summary>
    /// <para>Puts a signed 32-bit value into the stream.</para>
    /// </summary>
    public void Put32(int value)
    {
        NativeCalls.godot_icall_1_38(MethodBind11, GodotObject.GetPtr(this), value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PutU32, 1286410249ul);

    /// <summary>
    /// <para>Puts an unsigned 32-bit value into the stream.</para>
    /// </summary>
    public void PutU32(uint value)
    {
        NativeCalls.godot_icall_1_208(MethodBind12, GodotObject.GetPtr(this), value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Put64, 1286410249ul);

    /// <summary>
    /// <para>Puts a signed 64-bit value into the stream.</para>
    /// </summary>
    public void Put64(long value)
    {
        NativeCalls.godot_icall_1_10(MethodBind13, GodotObject.GetPtr(this), value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PutU64, 1286410249ul);

    /// <summary>
    /// <para>Puts an unsigned 64-bit value into the stream.</para>
    /// </summary>
    public void PutU64(ulong value)
    {
        NativeCalls.godot_icall_1_544(MethodBind14, GodotObject.GetPtr(this), value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PutHalf, 373806689ul);

    /// <summary>
    /// <para>Puts a half-precision float into the stream.</para>
    /// </summary>
    public void PutHalf(float value)
    {
        NativeCalls.godot_icall_1_67(MethodBind15, GodotObject.GetPtr(this), value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PutFloat, 373806689ul);

    /// <summary>
    /// <para>Puts a single-precision float into the stream.</para>
    /// </summary>
    public void PutFloat(float value)
    {
        NativeCalls.godot_icall_1_67(MethodBind16, GodotObject.GetPtr(this), value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PutDouble, 373806689ul);

    /// <summary>
    /// <para>Puts a double-precision float into the stream.</para>
    /// </summary>
    public void PutDouble(double value)
    {
        NativeCalls.godot_icall_1_127(MethodBind17, GodotObject.GetPtr(this), value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PutString, 83702148ul);

    /// <summary>
    /// <para>Puts a zero-terminated ASCII string into the stream prepended by a 32-bit unsigned integer representing its size.</para>
    /// <para><b>Note:</b> To put an ASCII string without prepending its size, you can use <see cref="Godot.StreamPeer.PutData(byte[])"/>:</para>
    /// <para><code>
    /// PutData("Hello World".ToAsciiBuffer());
    /// </code></para>
    /// </summary>
    public void PutString(string value)
    {
        NativeCalls.godot_icall_1_57(MethodBind18, GodotObject.GetPtr(this), value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PutUtf8String, 83702148ul);

    /// <summary>
    /// <para>Puts a zero-terminated UTF-8 string into the stream prepended by a 32 bits unsigned integer representing its size.</para>
    /// <para><b>Note:</b> To put a UTF-8 string without prepending its size, you can use <see cref="Godot.StreamPeer.PutData(byte[])"/>:</para>
    /// <para><code>
    /// PutData("Hello World".ToUtf8Buffer());
    /// </code></para>
    /// </summary>
    public void PutUtf8String(string value)
    {
        NativeCalls.godot_icall_1_57(MethodBind19, GodotObject.GetPtr(this), value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PutVar, 738511890ul);

    /// <summary>
    /// <para>Puts a Variant into the stream. If <paramref name="fullObjects"/> is <see langword="true"/> encoding objects is allowed (and can potentially include code).</para>
    /// <para>Internally, this uses the same encoding mechanism as the <c>@GlobalScope.var_to_bytes</c> method.</para>
    /// </summary>
    public void PutVar(Variant value, bool fullObjects = false)
    {
        NativeCalls.godot_icall_2_1285(MethodBind20, GodotObject.GetPtr(this), value, fullObjects.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Get8, 2455072627ul);

    /// <summary>
    /// <para>Gets a signed byte from the stream.</para>
    /// </summary>
    public sbyte Get8()
    {
        return NativeCalls.godot_icall_0_1286(MethodBind21, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetU8, 2455072627ul);

    /// <summary>
    /// <para>Gets an unsigned byte from the stream.</para>
    /// </summary>
    public byte GetU8()
    {
        return NativeCalls.godot_icall_0_282(MethodBind22, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Get16, 2455072627ul);

    /// <summary>
    /// <para>Gets a signed 16-bit value from the stream.</para>
    /// </summary>
    public short Get16()
    {
        return NativeCalls.godot_icall_0_1287(MethodBind23, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetU16, 2455072627ul);

    /// <summary>
    /// <para>Gets an unsigned 16-bit value from the stream.</para>
    /// </summary>
    public ushort GetU16()
    {
        return NativeCalls.godot_icall_0_284(MethodBind24, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Get32, 2455072627ul);

    /// <summary>
    /// <para>Gets a signed 32-bit value from the stream.</para>
    /// </summary>
    public int Get32()
    {
        return NativeCalls.godot_icall_0_39(MethodBind25, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetU32, 2455072627ul);

    /// <summary>
    /// <para>Gets an unsigned 32-bit value from the stream.</para>
    /// </summary>
    public uint GetU32()
    {
        return NativeCalls.godot_icall_0_209(MethodBind26, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Get64, 2455072627ul);

    /// <summary>
    /// <para>Gets a signed 64-bit value from the stream.</para>
    /// </summary>
    public long Get64()
    {
        return NativeCalls.godot_icall_0_4(MethodBind27, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetU64, 2455072627ul);

    /// <summary>
    /// <para>Gets an unsigned 64-bit value from the stream.</para>
    /// </summary>
    public ulong GetU64()
    {
        return NativeCalls.godot_icall_0_137(MethodBind28, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetHalf, 191475506ul);

    /// <summary>
    /// <para>Gets a half-precision float from the stream.</para>
    /// </summary>
    public float GetHalf()
    {
        return NativeCalls.godot_icall_0_68(MethodBind29, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFloat, 191475506ul);

    /// <summary>
    /// <para>Gets a single-precision float from the stream.</para>
    /// </summary>
    public float GetFloat()
    {
        return NativeCalls.godot_icall_0_68(MethodBind30, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDouble, 191475506ul);

    /// <summary>
    /// <para>Gets a double-precision float from the stream.</para>
    /// </summary>
    public double GetDouble()
    {
        return NativeCalls.godot_icall_0_144(MethodBind31, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind32 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetString, 2309358862ul);

    /// <summary>
    /// <para>Gets an ASCII string with byte-length <paramref name="bytes"/> from the stream. If <paramref name="bytes"/> is negative (default) the length will be read from the stream using the reverse process of <see cref="Godot.StreamPeer.PutString(string)"/>.</para>
    /// </summary>
    public string GetString(int bytes = -1)
    {
        return NativeCalls.godot_icall_1_133(MethodBind32, GodotObject.GetPtr(this), bytes);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind33 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetUtf8String, 2309358862ul);

    /// <summary>
    /// <para>Gets a UTF-8 string with byte-length <paramref name="bytes"/> from the stream (this decodes the string sent as UTF-8). If <paramref name="bytes"/> is negative (default) the length will be read from the stream using the reverse process of <see cref="Godot.StreamPeer.PutUtf8String(string)"/>.</para>
    /// </summary>
    public string GetUtf8String(int bytes = -1)
    {
        return NativeCalls.godot_icall_1_133(MethodBind33, GodotObject.GetPtr(this), bytes);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind34 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVar, 3442865206ul);

    /// <summary>
    /// <para>Gets a Variant from the stream. If <paramref name="allowObjects"/> is <see langword="true"/>, decoding objects is allowed.</para>
    /// <para>Internally, this uses the same decoding mechanism as the <c>@GlobalScope.bytes_to_var</c> method.</para>
    /// <para><b>Warning:</b> Deserialized objects can contain code which gets executed. Do not use this option if the serialized object comes from untrusted sources to avoid potential security threats such as remote code execution.</para>
    /// </summary>
    public Variant GetVar(bool allowObjects = false)
    {
        return NativeCalls.godot_icall_1_564(MethodBind34, GodotObject.GetPtr(this), allowObjects.ToGodotBool());
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
        /// <summary>
        /// Cached name for the 'big_endian' property.
        /// </summary>
        public static readonly StringName BigEndian = "big_endian";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : RefCounted.MethodName
    {
        /// <summary>
        /// Cached name for the 'put_data' method.
        /// </summary>
        public static readonly StringName PutData = "put_data";
        /// <summary>
        /// Cached name for the 'put_partial_data' method.
        /// </summary>
        public static readonly StringName PutPartialData = "put_partial_data";
        /// <summary>
        /// Cached name for the 'get_data' method.
        /// </summary>
        public static readonly StringName GetData = "get_data";
        /// <summary>
        /// Cached name for the 'get_partial_data' method.
        /// </summary>
        public static readonly StringName GetPartialData = "get_partial_data";
        /// <summary>
        /// Cached name for the 'get_available_bytes' method.
        /// </summary>
        public static readonly StringName GetAvailableBytes = "get_available_bytes";
        /// <summary>
        /// Cached name for the 'set_big_endian' method.
        /// </summary>
        public static readonly StringName SetBigEndian = "set_big_endian";
        /// <summary>
        /// Cached name for the 'is_big_endian_enabled' method.
        /// </summary>
        public static readonly StringName IsBigEndianEnabled = "is_big_endian_enabled";
        /// <summary>
        /// Cached name for the 'put_8' method.
        /// </summary>
        public static readonly StringName Put8 = "put_8";
        /// <summary>
        /// Cached name for the 'put_u8' method.
        /// </summary>
        public static readonly StringName PutU8 = "put_u8";
        /// <summary>
        /// Cached name for the 'put_16' method.
        /// </summary>
        public static readonly StringName Put16 = "put_16";
        /// <summary>
        /// Cached name for the 'put_u16' method.
        /// </summary>
        public static readonly StringName PutU16 = "put_u16";
        /// <summary>
        /// Cached name for the 'put_32' method.
        /// </summary>
        public static readonly StringName Put32 = "put_32";
        /// <summary>
        /// Cached name for the 'put_u32' method.
        /// </summary>
        public static readonly StringName PutU32 = "put_u32";
        /// <summary>
        /// Cached name for the 'put_64' method.
        /// </summary>
        public static readonly StringName Put64 = "put_64";
        /// <summary>
        /// Cached name for the 'put_u64' method.
        /// </summary>
        public static readonly StringName PutU64 = "put_u64";
        /// <summary>
        /// Cached name for the 'put_half' method.
        /// </summary>
        public static readonly StringName PutHalf = "put_half";
        /// <summary>
        /// Cached name for the 'put_float' method.
        /// </summary>
        public static readonly StringName PutFloat = "put_float";
        /// <summary>
        /// Cached name for the 'put_double' method.
        /// </summary>
        public static readonly StringName PutDouble = "put_double";
        /// <summary>
        /// Cached name for the 'put_string' method.
        /// </summary>
        public static readonly StringName PutString = "put_string";
        /// <summary>
        /// Cached name for the 'put_utf8_string' method.
        /// </summary>
        public static readonly StringName PutUtf8String = "put_utf8_string";
        /// <summary>
        /// Cached name for the 'put_var' method.
        /// </summary>
        public static readonly StringName PutVar = "put_var";
        /// <summary>
        /// Cached name for the 'get_8' method.
        /// </summary>
        public static readonly StringName Get8 = "get_8";
        /// <summary>
        /// Cached name for the 'get_u8' method.
        /// </summary>
        public static readonly StringName GetU8 = "get_u8";
        /// <summary>
        /// Cached name for the 'get_16' method.
        /// </summary>
        public static readonly StringName Get16 = "get_16";
        /// <summary>
        /// Cached name for the 'get_u16' method.
        /// </summary>
        public static readonly StringName GetU16 = "get_u16";
        /// <summary>
        /// Cached name for the 'get_32' method.
        /// </summary>
        public static readonly StringName Get32 = "get_32";
        /// <summary>
        /// Cached name for the 'get_u32' method.
        /// </summary>
        public static readonly StringName GetU32 = "get_u32";
        /// <summary>
        /// Cached name for the 'get_64' method.
        /// </summary>
        public static readonly StringName Get64 = "get_64";
        /// <summary>
        /// Cached name for the 'get_u64' method.
        /// </summary>
        public static readonly StringName GetU64 = "get_u64";
        /// <summary>
        /// Cached name for the 'get_half' method.
        /// </summary>
        public static readonly StringName GetHalf = "get_half";
        /// <summary>
        /// Cached name for the 'get_float' method.
        /// </summary>
        public static readonly StringName GetFloat = "get_float";
        /// <summary>
        /// Cached name for the 'get_double' method.
        /// </summary>
        public static readonly StringName GetDouble = "get_double";
        /// <summary>
        /// Cached name for the 'get_string' method.
        /// </summary>
        public static readonly StringName GetString = "get_string";
        /// <summary>
        /// Cached name for the 'get_utf8_string' method.
        /// </summary>
        public static readonly StringName GetUtf8String = "get_utf8_string";
        /// <summary>
        /// Cached name for the 'get_var' method.
        /// </summary>
        public static readonly StringName GetVar = "get_var";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : RefCounted.SignalName
    {
    }
}
