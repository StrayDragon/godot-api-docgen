namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>The HashingContext class provides an interface for computing cryptographic hashes over multiple iterations. Useful for computing hashes of big files (so you don't have to load them all in memory), network streams, and data streams in general (so you don't have to hold buffers).</para>
/// <para>The <see cref="Godot.HashingContext.HashType"/> enum shows the supported hashing algorithms.</para>
/// <para><code>
/// public const int ChunkSize = 1024;
/// 
/// public void HashFile(string path)
/// {
/// 	// Check that file exists.
/// 	if (!FileAccess.FileExists(path))
/// 	{
/// 		return;
/// 	}
/// 	// Start an SHA-256 context.
/// 	var ctx = new HashingContext();
/// 	ctx.Start(HashingContext.HashType.Sha256);
/// 	// Open the file to hash.
/// 	using var file = FileAccess.Open(path, FileAccess.ModeFlags.Read);
/// 	// Update the context after reading each chunk.
/// 	while (file.GetPosition() &lt; file.GetLength())
/// 	{
/// 		int remaining = (int)(file.GetLength() - file.GetPosition());
/// 		ctx.Update(file.GetBuffer(Mathf.Min(remaining, ChunkSize)));
/// 	}
/// 	// Get the computed hash.
/// 	byte[] res = ctx.Finish();
/// 	// Print the result as hex string and array.
/// 	GD.PrintT(res.HexEncode(), (Variant)res);
/// }
/// </code></para>
/// </summary>
public partial class HashingContext : RefCounted
{
    public enum HashType : long
    {
        /// <summary>
        /// <para>Hashing algorithm: MD5.</para>
        /// </summary>
        Md5 = 0,
        /// <summary>
        /// <para>Hashing algorithm: SHA-1.</para>
        /// </summary>
        Sha1 = 1,
        /// <summary>
        /// <para>Hashing algorithm: SHA-256.</para>
        /// </summary>
        Sha256 = 2
    }

    private static readonly System.Type CachedType = typeof(HashingContext);

    private static readonly StringName NativeName = "HashingContext";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public HashingContext() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal HashingContext(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal HashingContext(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Start, 3940338335ul);

    /// <summary>
    /// <para>Starts a new hash computation of the given <paramref name="type"/> (e.g. <see cref="Godot.HashingContext.HashType.Sha256"/> to start computation of an SHA-256).</para>
    /// </summary>
    public Error Start(HashingContext.HashType type)
    {
        return (Error)NativeCalls.godot_icall_1_60(MethodBind0, GodotObject.GetPtr(this), (int)type);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Update, 680677267ul);

    /// <summary>
    /// <para>Updates the computation with the given <paramref name="chunk"/> of data.</para>
    /// </summary>
    public Error Update(byte[] chunk)
    {
        return (Error)NativeCalls.godot_icall_1_713(MethodBind1, GodotObject.GetPtr(this), chunk);
    }

    /// <summary>
    /// <para>Updates the computation with the given <paramref name="chunk"/> of data.</para>
    /// </summary>
    public Error Update(ReadOnlySpan<byte> chunk)
    {
        return (Error)NativeCalls.godot_icall_1_713(MethodBind1, GodotObject.GetPtr(this), chunk);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Finish, 2115431945ul);

    /// <summary>
    /// <para>Closes the current context, and return the computed hash.</para>
    /// </summary>
    public byte[] Finish()
    {
        return NativeCalls.godot_icall_0_2(MethodBind2, GodotObject.GetPtr(this));
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
        /// Cached name for the 'start' method.
        /// </summary>
        public static readonly StringName Start = "start";
        /// <summary>
        /// Cached name for the 'update' method.
        /// </summary>
        public static readonly StringName Update = "update";
        /// <summary>
        /// Cached name for the 'finish' method.
        /// </summary>
        public static readonly StringName Finish = "finish";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : RefCounted.SignalName
    {
    }
}
