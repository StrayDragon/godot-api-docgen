namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This class holds the context information required for encryption and decryption operations with AES (Advanced Encryption Standard). Both AES-ECB and AES-CBC modes are supported.</para>
/// <para><code>
/// using Godot;
/// using System.Diagnostics;
/// 
/// public partial class MyNode : Node
/// {
/// 	private AesContext _aes = new AesContext();
/// 
/// 	public override void _Ready()
/// 	{
/// 		string key = "My secret key!!!"; // Key must be either 16 or 32 bytes.
/// 		string data = "My secret text!!"; // Data size must be multiple of 16 bytes, apply padding if needed.
/// 		// Encrypt ECB
/// 		_aes.Start(AesContext.Mode.EcbEncrypt, key.ToUtf8Buffer());
/// 		byte[] encrypted = _aes.Update(data.ToUtf8Buffer());
/// 		_aes.Finish();
/// 		// Decrypt ECB
/// 		_aes.Start(AesContext.Mode.EcbDecrypt, key.ToUtf8Buffer());
/// 		byte[] decrypted = _aes.Update(encrypted);
/// 		_aes.Finish();
/// 		// Check ECB
/// 		Debug.Assert(decrypted == data.ToUtf8Buffer());
/// 
/// 		string iv = "My secret iv!!!!"; // IV must be of exactly 16 bytes.
/// 		// Encrypt CBC
/// 		_aes.Start(AesContext.Mode.EcbEncrypt, key.ToUtf8Buffer(), iv.ToUtf8Buffer());
/// 		encrypted = _aes.Update(data.ToUtf8Buffer());
/// 		_aes.Finish();
/// 		// Decrypt CBC
/// 		_aes.Start(AesContext.Mode.EcbDecrypt, key.ToUtf8Buffer(), iv.ToUtf8Buffer());
/// 		decrypted = _aes.Update(encrypted);
/// 		_aes.Finish();
/// 		// Check CBC
/// 		Debug.Assert(decrypted == data.ToUtf8Buffer());
/// 	}
/// }
/// </code></para>
/// </summary>
[GodotClassName("AESContext")]
public partial class AesContext : RefCounted
{
    public enum Mode : long
    {
        /// <summary>
        /// <para>AES electronic codebook encryption mode.</para>
        /// </summary>
        EcbEncrypt = 0,
        /// <summary>
        /// <para>AES electronic codebook decryption mode.</para>
        /// </summary>
        EcbDecrypt = 1,
        /// <summary>
        /// <para>AES cipher block chaining encryption mode.</para>
        /// </summary>
        CbcEncrypt = 2,
        /// <summary>
        /// <para>AES cipher block chaining decryption mode.</para>
        /// </summary>
        CbcDecrypt = 3,
        /// <summary>
        /// <para>Maximum value for the mode enum.</para>
        /// </summary>
        Max = 4
    }

    private static readonly System.Type CachedType = typeof(AesContext);

    private static readonly StringName NativeName = "AESContext";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public AesContext() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal AesContext(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal AesContext(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Start, 3122411423ul);

    /// <summary>
    /// <para>Start the AES context in the given <paramref name="mode"/>. A <paramref name="key"/> of either 16 or 32 bytes must always be provided, while an <paramref name="iV"/> (initialization vector) of exactly 16 bytes, is only needed when <paramref name="mode"/> is either <see cref="Godot.AesContext.Mode.CbcEncrypt"/> or <see cref="Godot.AesContext.Mode.CbcDecrypt"/>.</para>
    /// </summary>
    /// <param name="iV">If the parameter is null, then the default value is <c>Array.Empty&lt;byte&gt;()</c>.</param>
    public Error Start(AesContext.Mode mode, byte[] key, byte[] iV = null)
    {
        byte[] iVOrDefVal = iV != null ? iV : Array.Empty<byte>();
        return (Error)NativeCalls.godot_icall_3_0(MethodBind0, GodotObject.GetPtr(this), (int)mode, key, iVOrDefVal);
    }

    /// <summary>
    /// <para>Start the AES context in the given <paramref name="mode"/>. A <paramref name="key"/> of either 16 or 32 bytes must always be provided, while an <paramref name="iV"/> (initialization vector) of exactly 16 bytes, is only needed when <paramref name="mode"/> is either <see cref="Godot.AesContext.Mode.CbcEncrypt"/> or <see cref="Godot.AesContext.Mode.CbcDecrypt"/>.</para>
    /// </summary>
    public Error Start(AesContext.Mode mode, ReadOnlySpan<byte> key, ReadOnlySpan<byte> iV)
    {
        return (Error)NativeCalls.godot_icall_3_0(MethodBind0, GodotObject.GetPtr(this), (int)mode, key, iV);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Update, 527836100ul);

    /// <summary>
    /// <para>Run the desired operation for this AES context. Will return a <see cref="byte"/>[] containing the result of encrypting (or decrypting) the given <paramref name="src"/>. See <see cref="Godot.AesContext.Start(AesContext.Mode, byte[], byte[])"/> for mode of operation.</para>
    /// <para><b>Note:</b> The size of <paramref name="src"/> must be a multiple of 16. Apply some padding if needed.</para>
    /// </summary>
    public byte[] Update(byte[] src)
    {
        return NativeCalls.godot_icall_1_1(MethodBind1, GodotObject.GetPtr(this), src);
    }

    /// <summary>
    /// <para>Run the desired operation for this AES context. Will return a <see cref="byte"/>[] containing the result of encrypting (or decrypting) the given <paramref name="src"/>. See <see cref="Godot.AesContext.Start(AesContext.Mode, byte[], byte[])"/> for mode of operation.</para>
    /// <para><b>Note:</b> The size of <paramref name="src"/> must be a multiple of 16. Apply some padding if needed.</para>
    /// </summary>
    public byte[] Update(ReadOnlySpan<byte> src)
    {
        return NativeCalls.godot_icall_1_1(MethodBind1, GodotObject.GetPtr(this), src);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetIVState, 2115431945ul);

    /// <summary>
    /// <para>Get the current IV state for this context (IV gets updated when calling <see cref="Godot.AesContext.Update(byte[])"/>). You normally don't need this function.</para>
    /// <para><b>Note:</b> This function only makes sense when the context is started with <see cref="Godot.AesContext.Mode.CbcEncrypt"/> or <see cref="Godot.AesContext.Mode.CbcDecrypt"/>.</para>
    /// </summary>
    public byte[] GetIVState()
    {
        return NativeCalls.godot_icall_0_2(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Finish, 3218959716ul);

    /// <summary>
    /// <para>Close this AES context so it can be started again. See <see cref="Godot.AesContext.Start(AesContext.Mode, byte[], byte[])"/>.</para>
    /// </summary>
    public void Finish()
    {
        NativeCalls.godot_icall_0_3(MethodBind3, GodotObject.GetPtr(this));
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
        /// Cached name for the 'get_iv_state' method.
        /// </summary>
        public static readonly StringName GetIVState = "get_iv_state";
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
