namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A data buffer stream peer that uses a byte array as the stream. This object can be used to handle binary data from network sessions. To handle binary data stored in files, <see cref="Godot.FileAccess"/> can be used directly.</para>
/// <para>A <see cref="Godot.StreamPeerBuffer"/> object keeps an internal cursor which is the offset in bytes to the start of the buffer. Get and put operations are performed at the cursor position and will move the cursor accordingly.</para>
/// </summary>
public partial class StreamPeerBuffer : StreamPeer
{
    /// <summary>
    /// <para>The underlying data buffer. Setting this value resets the cursor.</para>
    /// </summary>
    public byte[] DataArray
    {
        get
        {
            return GetDataArray();
        }
        set
        {
            SetDataArray(value);
        }
    }

    private static readonly System.Type CachedType = typeof(StreamPeerBuffer);

    private static readonly StringName NativeName = "StreamPeerBuffer";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public StreamPeerBuffer() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal StreamPeerBuffer(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal StreamPeerBuffer(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Seek, 1286410249ul);

    /// <summary>
    /// <para>Moves the cursor to the specified position. <paramref name="position"/> must be a valid index of <see cref="Godot.StreamPeerBuffer.DataArray"/>.</para>
    /// </summary>
    public void Seek(int position)
    {
        NativeCalls.godot_icall_1_38(MethodBind0, GodotObject.GetPtr(this), position);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSize, 3905245786ul);

    /// <summary>
    /// <para>Returns the size of <see cref="Godot.StreamPeerBuffer.DataArray"/>.</para>
    /// </summary>
    public int GetSize()
    {
        return NativeCalls.godot_icall_0_39(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPosition, 3905245786ul);

    /// <summary>
    /// <para>Returns the current cursor position.</para>
    /// </summary>
    public int GetPosition()
    {
        return NativeCalls.godot_icall_0_39(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Resize, 1286410249ul);

    /// <summary>
    /// <para>Resizes the <see cref="Godot.StreamPeerBuffer.DataArray"/>. This <i>doesn't</i> update the cursor.</para>
    /// </summary>
    public void Resize(int size)
    {
        NativeCalls.godot_icall_1_38(MethodBind3, GodotObject.GetPtr(this), size);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDataArray, 2971499966ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDataArray(byte[] data)
    {
        NativeCalls.godot_icall_1_204(MethodBind4, GodotObject.GetPtr(this), data);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDataArray(ReadOnlySpan<byte> data)
    {
        NativeCalls.godot_icall_1_204(MethodBind4, GodotObject.GetPtr(this), data);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDataArray, 2362200018ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public byte[] GetDataArray()
    {
        return NativeCalls.godot_icall_0_2(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Clear, 3218959716ul);

    /// <summary>
    /// <para>Clears the <see cref="Godot.StreamPeerBuffer.DataArray"/> and resets the cursor.</para>
    /// </summary>
    public void Clear()
    {
        NativeCalls.godot_icall_0_3(MethodBind6, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Duplicate, 2474064677ul);

    /// <summary>
    /// <para>Returns a new <see cref="Godot.StreamPeerBuffer"/> with the same <see cref="Godot.StreamPeerBuffer.DataArray"/> content.</para>
    /// </summary>
    public StreamPeerBuffer Duplicate()
    {
        return (StreamPeerBuffer)NativeCalls.godot_icall_0_63(MethodBind7, GodotObject.GetPtr(this));
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
    public new class PropertyName : StreamPeer.PropertyName
    {
        /// <summary>
        /// Cached name for the 'data_array' property.
        /// </summary>
        public static readonly StringName DataArray = "data_array";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : StreamPeer.MethodName
    {
        /// <summary>
        /// Cached name for the 'seek' method.
        /// </summary>
        public static readonly StringName Seek = "seek";
        /// <summary>
        /// Cached name for the 'get_size' method.
        /// </summary>
        public static readonly StringName GetSize = "get_size";
        /// <summary>
        /// Cached name for the 'get_position' method.
        /// </summary>
        public static readonly StringName GetPosition = "get_position";
        /// <summary>
        /// Cached name for the 'resize' method.
        /// </summary>
        public static readonly StringName Resize = "resize";
        /// <summary>
        /// Cached name for the 'set_data_array' method.
        /// </summary>
        public static readonly StringName SetDataArray = "set_data_array";
        /// <summary>
        /// Cached name for the 'get_data_array' method.
        /// </summary>
        public static readonly StringName GetDataArray = "get_data_array";
        /// <summary>
        /// Cached name for the 'clear' method.
        /// </summary>
        public static readonly StringName Clear = "clear";
        /// <summary>
        /// Cached name for the 'duplicate' method.
        /// </summary>
        public static readonly StringName Duplicate = "duplicate";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : StreamPeer.SignalName
    {
    }
}
