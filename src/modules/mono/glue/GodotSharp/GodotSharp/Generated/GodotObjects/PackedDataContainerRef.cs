namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>When packing nested containers using <see cref="Godot.PackedDataContainer"/>, they are recursively packed into <see cref="Godot.PackedDataContainerRef"/> (only applies to <see cref="Godot.Collections.Array"/> and <see cref="Godot.Collections.Dictionary"/>). Their data can be retrieved the same way as from <see cref="Godot.PackedDataContainer"/>.</para>
/// <para><code>
/// var packed = PackedDataContainer.new()
/// packed.pack([1, 2, 3, ["nested1", "nested2"], 4, 5, 6])
/// 
/// for element in packed:
/// 	if element is PackedDataContainerRef:
/// 		for subelement in element:
/// 			print("::", subelement)
/// 	else:
/// 		print(element)
/// </code></para>
/// <para>Prints:</para>
/// <para><code>
/// 1
/// 2
/// 3
/// ::nested1
/// ::nested2
/// 4
/// 5
/// 6
/// </code></para>
/// </summary>
[Obsolete("Use '@GlobalScope.var_to_bytes' or 'Godot.FileAccess.StoreVar(Variant, bool)' instead. To enable data compression, use 'PackedByteArray.compress' or 'Godot.FileAccess.OpenCompressed(string, FileAccess.ModeFlags, FileAccess.CompressionMode)'.")]
public partial class PackedDataContainerRef : RefCounted
{
    private static readonly System.Type CachedType = typeof(PackedDataContainerRef);

    private static readonly StringName NativeName = "PackedDataContainerRef";

    internal PackedDataContainerRef() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal PackedDataContainerRef(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal PackedDataContainerRef(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Size, 3905245786ul);

    /// <summary>
    /// <para>Returns the size of the packed container (see <c>Array.size</c> and <c>Dictionary.size</c>).</para>
    /// </summary>
    public int Size()
    {
        return NativeCalls.godot_icall_0_39(MethodBind0, GodotObject.GetPtr(this));
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
        /// Cached name for the 'size' method.
        /// </summary>
        public static readonly StringName Size = "size";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : RefCounted.SignalName
    {
    }
}
