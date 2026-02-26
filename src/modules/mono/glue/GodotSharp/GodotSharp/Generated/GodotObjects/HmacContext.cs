namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>The HMACContext class is useful for advanced HMAC use cases, such as streaming the message as it supports creating the message over time rather than providing it all at once.</para>
/// <para><code>
/// using Godot;
/// using System.Diagnostics;
/// 
/// public partial class MyNode : Node
/// {
/// 	private HmacContext _ctx = new HmacContext();
/// 
/// 	public override void _Ready()
/// 	{
/// 		byte[] key = "supersecret".ToUtf8Buffer();
/// 		Error err = _ctx.Start(HashingContext.HashType.Sha256, key);
/// 		Debug.Assert(err == Error.Ok);
/// 		byte[] msg1 = "this is ".ToUtf8Buffer();
/// 		byte[] msg2 = "super duper secret".ToUtf8Buffer();
/// 		err = _ctx.Update(msg1);
/// 		Debug.Assert(err == Error.Ok);
/// 		err = _ctx.Update(msg2);
/// 		Debug.Assert(err == Error.Ok);
/// 		byte[] hmac = _ctx.Finish();
/// 		GD.Print(hmac.HexEncode());
/// 	}
/// }
/// </code></para>
/// </summary>
[GodotClassName("HMACContext")]
public partial class HmacContext : RefCounted
{
    private static readonly System.Type CachedType = typeof(HmacContext);

    private static readonly StringName NativeName = "HMACContext";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public HmacContext() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal HmacContext(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal HmacContext(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Start, 3537364598ul);

    /// <summary>
    /// <para>Initializes the HMACContext. This method cannot be called again on the same HMACContext until <see cref="Godot.HmacContext.Finish()"/> has been called.</para>
    /// </summary>
    public Error Start(HashingContext.HashType hashType, byte[] key)
    {
        return (Error)NativeCalls.godot_icall_2_712(MethodBind0, GodotObject.GetPtr(this), (int)hashType, key);
    }

    /// <summary>
    /// <para>Initializes the HMACContext. This method cannot be called again on the same HMACContext until <see cref="Godot.HmacContext.Finish()"/> has been called.</para>
    /// </summary>
    public Error Start(HashingContext.HashType hashType, ReadOnlySpan<byte> key)
    {
        return (Error)NativeCalls.godot_icall_2_712(MethodBind0, GodotObject.GetPtr(this), (int)hashType, key);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Update, 680677267ul);

    /// <summary>
    /// <para>Updates the message to be HMACed. This can be called multiple times before <see cref="Godot.HmacContext.Finish()"/> is called to append <paramref name="data"/> to the message, but cannot be called until <see cref="Godot.HmacContext.Start(HashingContext.HashType, byte[])"/> has been called.</para>
    /// </summary>
    public Error Update(byte[] data)
    {
        return (Error)NativeCalls.godot_icall_1_713(MethodBind1, GodotObject.GetPtr(this), data);
    }

    /// <summary>
    /// <para>Updates the message to be HMACed. This can be called multiple times before <see cref="Godot.HmacContext.Finish()"/> is called to append <paramref name="data"/> to the message, but cannot be called until <see cref="Godot.HmacContext.Start(HashingContext.HashType, byte[])"/> has been called.</para>
    /// </summary>
    public Error Update(ReadOnlySpan<byte> data)
    {
        return (Error)NativeCalls.godot_icall_1_713(MethodBind1, GodotObject.GetPtr(this), data);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Finish, 2115431945ul);

    /// <summary>
    /// <para>Returns the resulting HMAC. If the HMAC failed, an empty <see cref="byte"/>[] is returned.</para>
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
