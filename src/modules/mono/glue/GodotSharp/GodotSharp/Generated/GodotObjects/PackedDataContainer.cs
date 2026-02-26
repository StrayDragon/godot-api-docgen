namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para><see cref="Godot.PackedDataContainer"/> can be used to efficiently store data from untyped containers. The data is packed into raw bytes and can be saved to file. Only <see cref="Godot.Collections.Array"/> and <see cref="Godot.Collections.Dictionary"/> can be stored this way.</para>
/// <para>You can retrieve the data by iterating on the container, which will work as if iterating on the packed data itself. If the packed container is a <see cref="Godot.Collections.Dictionary"/>, the data can be retrieved by key names (<see cref="string"/>/<see cref="Godot.StringName"/> only).</para>
/// <para><code>
/// var data = { "key": "value", "another_key": 123, "lock": Vector2() }
/// var packed = PackedDataContainer.new()
/// packed.pack(data)
/// ResourceSaver.save(packed, "packed_data.res")
/// </code></para>
/// <para><code>
/// var container = load("packed_data.res")
/// for key in container:
/// 	prints(key, container[key])
/// </code></para>
/// <para>Prints:</para>
/// <para><code>
/// key value
/// lock (0, 0)
/// another_key 123
/// </code></para>
/// <para>Nested containers will be packed recursively. While iterating, they will be returned as <see cref="Godot.PackedDataContainerRef"/>.</para>
/// </summary>
[Obsolete("Use '@GlobalScope.var_to_bytes' or 'Godot.FileAccess.StoreVar(Variant, bool)' instead. To enable data compression, use 'PackedByteArray.compress' or 'Godot.FileAccess.OpenCompressed(string, FileAccess.ModeFlags, FileAccess.CompressionMode)'.")]
public partial class PackedDataContainer : Resource
{
    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public byte[] __Data___
    {
        get
        {
            return _GetData();
        }
        set
        {
            _SetData(value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    private static readonly System.Type CachedType = typeof(PackedDataContainer);

    private static readonly StringName NativeName = "PackedDataContainer";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public PackedDataContainer() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal PackedDataContainer(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal PackedDataContainer(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName._SetData, 2971499966ul);

    internal void _SetData(byte[] data)
    {
        NativeCalls.godot_icall_1_204(MethodBind0, GodotObject.GetPtr(this), data);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName._GetData, 2362200018ul);

    internal byte[] _GetData()
    {
        return NativeCalls.godot_icall_0_2(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Pack, 966674026ul);

    /// <summary>
    /// <para>Packs the given container into a binary representation. The <paramref name="value"/> must be either <see cref="Godot.Collections.Array"/> or <see cref="Godot.Collections.Dictionary"/>, any other type will result in invalid data error.</para>
    /// <para><b>Note:</b> Subsequent calls to this method will overwrite the existing data.</para>
    /// </summary>
    public Error Pack(Variant value)
    {
        return (Error)NativeCalls.godot_icall_1_970(MethodBind2, GodotObject.GetPtr(this), value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Size, 3905245786ul);

    /// <summary>
    /// <para>Returns the size of the packed container (see <c>Array.size</c> and <c>Dictionary.size</c>).</para>
    /// </summary>
    public int Size()
    {
        return NativeCalls.godot_icall_0_39(MethodBind3, GodotObject.GetPtr(this));
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
        /// Cached name for the '__data__' property.
        /// </summary>
        public static readonly StringName __Data___ = "__data__";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Resource.MethodName
    {
        /// <summary>
        /// Cached name for the '_set_data' method.
        /// </summary>
        public static readonly StringName _SetData = "_set_data";
        /// <summary>
        /// Cached name for the '_get_data' method.
        /// </summary>
        public static readonly StringName _GetData = "_get_data";
        /// <summary>
        /// Cached name for the 'pack' method.
        /// </summary>
        public static readonly StringName Pack = "pack";
        /// <summary>
        /// Cached name for the 'size' method.
        /// </summary>
        public static readonly StringName Size = "size";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Resource.SignalName
    {
    }
}
