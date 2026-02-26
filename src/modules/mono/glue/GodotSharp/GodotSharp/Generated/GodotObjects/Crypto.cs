namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>The Crypto class provides access to advanced cryptographic functionalities.</para>
/// <para>Currently, this includes asymmetric key encryption/decryption, signing/verification, and generating cryptographically secure random bytes, RSA keys, HMAC digests, and self-signed <see cref="Godot.X509Certificate"/>s.</para>
/// <para><code>
/// using Godot;
/// using System.Diagnostics;
/// 
/// Crypto crypto = new Crypto();
/// 
/// // Generate new RSA key.
/// CryptoKey key = crypto.GenerateRsa(4096);
/// 
/// // Generate new self-signed certificate with the given key.
/// X509Certificate cert = crypto.GenerateSelfSignedCertificate(key, "CN=mydomain.com,O=My Game Company,C=IT");
/// 
/// // Save key and certificate in the user folder.
/// key.Save("user://generated.key");
/// cert.Save("user://generated.crt");
/// 
/// // Encryption
/// string data = "Some data";
/// byte[] encrypted = crypto.Encrypt(key, data.ToUtf8Buffer());
/// 
/// // Decryption
/// byte[] decrypted = crypto.Decrypt(key, encrypted);
/// 
/// // Signing
/// byte[] signature = crypto.Sign(HashingContext.HashType.Sha256, Data.Sha256Buffer(), key);
/// 
/// // Verifying
/// bool verified = crypto.Verify(HashingContext.HashType.Sha256, Data.Sha256Buffer(), signature, key);
/// 
/// // Checks
/// Debug.Assert(verified);
/// Debug.Assert(data.ToUtf8Buffer() == decrypted);
/// </code></para>
/// </summary>
public partial class Crypto : RefCounted
{
    private static readonly System.Type CachedType = typeof(Crypto);

    private static readonly StringName NativeName = "Crypto";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public Crypto() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal Crypto(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal Crypto(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GenerateRandomBytes, 47165747ul);

    /// <summary>
    /// <para>Generates a <see cref="byte"/>[] of cryptographically secure random bytes with given <paramref name="size"/>.</para>
    /// </summary>
    public byte[] GenerateRandomBytes(int size)
    {
        return NativeCalls.godot_icall_1_343(MethodBind0, GodotObject.GetPtr(this), size);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GenerateRsa, 1237515462ul);

    /// <summary>
    /// <para>Generates an RSA <see cref="Godot.CryptoKey"/> that can be used for creating self-signed certificates and passed to <see cref="Godot.StreamPeerTls.AcceptStream(StreamPeer, TlsOptions)"/>.</para>
    /// </summary>
    public CryptoKey GenerateRsa(int size)
    {
        return (CryptoKey)NativeCalls.godot_icall_1_71(MethodBind1, GodotObject.GetPtr(this), size);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GenerateSelfSignedCertificate, 492266173ul);

    /// <summary>
    /// <para>Generates a self-signed <see cref="Godot.X509Certificate"/> from the given <see cref="Godot.CryptoKey"/> and <paramref name="issuerName"/>. The certificate validity will be defined by <paramref name="notBefore"/> and <paramref name="notAfter"/> (first valid date and last valid date). The <paramref name="issuerName"/> must contain at least "CN=" (common name, i.e. the domain name), "O=" (organization, i.e. your company name), "C=" (country, i.e. 2 lettered ISO-3166 code of the country the organization is based in).</para>
    /// <para>A small example to generate an RSA key and an X509 self-signed certificate.</para>
    /// <para><code>
    /// var crypto = new Crypto();
    /// // Generate 4096 bits RSA key.
    /// CryptoKey key = crypto.GenerateRsa(4096);
    /// // Generate self-signed certificate using the given key.
    /// X509Certificate cert = crypto.GenerateSelfSignedCertificate(key, "CN=mydomain.com,O=My Game Company,C=IT");
    /// </code></para>
    /// </summary>
    public X509Certificate GenerateSelfSignedCertificate(CryptoKey key, string issuerName = "CN=myserver,O=myorganisation,C=IT", string notBefore = "20140101000000", string notAfter = "20340101000000")
    {
        return (X509Certificate)NativeCalls.godot_icall_4_344(MethodBind2, GodotObject.GetPtr(this), GodotObject.GetPtr(key), issuerName, notBefore, notAfter);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Sign, 1673662703ul);

    /// <summary>
    /// <para>Sign a given <paramref name="hash"/> of type <paramref name="hashType"/> with the provided private <paramref name="key"/>.</para>
    /// </summary>
    public byte[] Sign(HashingContext.HashType hashType, byte[] hash, CryptoKey key)
    {
        return NativeCalls.godot_icall_3_345(MethodBind3, GodotObject.GetPtr(this), (int)hashType, hash, GodotObject.GetPtr(key));
    }

    /// <summary>
    /// <para>Sign a given <paramref name="hash"/> of type <paramref name="hashType"/> with the provided private <paramref name="key"/>.</para>
    /// </summary>
    public byte[] Sign(HashingContext.HashType hashType, ReadOnlySpan<byte> hash, CryptoKey key)
    {
        return NativeCalls.godot_icall_3_345(MethodBind3, GodotObject.GetPtr(this), (int)hashType, hash, GodotObject.GetPtr(key));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Verify, 2805902225ul);

    /// <summary>
    /// <para>Verify that a given <paramref name="signature"/> for <paramref name="hash"/> of type <paramref name="hashType"/> against the provided public <paramref name="key"/>.</para>
    /// </summary>
    public bool Verify(HashingContext.HashType hashType, byte[] hash, byte[] signature, CryptoKey key)
    {
        return NativeCalls.godot_icall_4_346(MethodBind4, GodotObject.GetPtr(this), (int)hashType, hash, signature, GodotObject.GetPtr(key)).ToBool();
    }

    /// <summary>
    /// <para>Verify that a given <paramref name="signature"/> for <paramref name="hash"/> of type <paramref name="hashType"/> against the provided public <paramref name="key"/>.</para>
    /// </summary>
    public bool Verify(HashingContext.HashType hashType, ReadOnlySpan<byte> hash, ReadOnlySpan<byte> signature, CryptoKey key)
    {
        return NativeCalls.godot_icall_4_346(MethodBind4, GodotObject.GetPtr(this), (int)hashType, hash, signature, GodotObject.GetPtr(key)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Encrypt, 2361793670ul);

    /// <summary>
    /// <para>Encrypt the given <paramref name="plaintext"/> with the provided public <paramref name="key"/>.</para>
    /// <para><b>Note:</b> The maximum size of accepted plaintext is limited by the key size.</para>
    /// </summary>
    public byte[] Encrypt(CryptoKey key, byte[] plaintext)
    {
        return NativeCalls.godot_icall_2_347(MethodBind5, GodotObject.GetPtr(this), GodotObject.GetPtr(key), plaintext);
    }

    /// <summary>
    /// <para>Encrypt the given <paramref name="plaintext"/> with the provided public <paramref name="key"/>.</para>
    /// <para><b>Note:</b> The maximum size of accepted plaintext is limited by the key size.</para>
    /// </summary>
    public byte[] Encrypt(CryptoKey key, ReadOnlySpan<byte> plaintext)
    {
        return NativeCalls.godot_icall_2_347(MethodBind5, GodotObject.GetPtr(this), GodotObject.GetPtr(key), plaintext);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Decrypt, 2361793670ul);

    /// <summary>
    /// <para>Decrypt the given <paramref name="ciphertext"/> with the provided private <paramref name="key"/>.</para>
    /// <para><b>Note:</b> The maximum size of accepted ciphertext is limited by the key size.</para>
    /// </summary>
    public byte[] Decrypt(CryptoKey key, byte[] ciphertext)
    {
        return NativeCalls.godot_icall_2_347(MethodBind6, GodotObject.GetPtr(this), GodotObject.GetPtr(key), ciphertext);
    }

    /// <summary>
    /// <para>Decrypt the given <paramref name="ciphertext"/> with the provided private <paramref name="key"/>.</para>
    /// <para><b>Note:</b> The maximum size of accepted ciphertext is limited by the key size.</para>
    /// </summary>
    public byte[] Decrypt(CryptoKey key, ReadOnlySpan<byte> ciphertext)
    {
        return NativeCalls.godot_icall_2_347(MethodBind6, GodotObject.GetPtr(this), GodotObject.GetPtr(key), ciphertext);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HmacDigest, 2368951203ul);

    /// <summary>
    /// <para>Generates an <a href="https://en.wikipedia.org/wiki/HMAC">HMAC</a> digest of <paramref name="msg"/> using <paramref name="key"/>. The <paramref name="hashType"/> parameter is the hashing algorithm that is used for the inner and outer hashes.</para>
    /// <para>Currently, only <see cref="Godot.HashingContext.HashType.Sha256"/> and <see cref="Godot.HashingContext.HashType.Sha1"/> are supported.</para>
    /// </summary>
    public byte[] HmacDigest(HashingContext.HashType hashType, byte[] key, byte[] msg)
    {
        return NativeCalls.godot_icall_3_348(MethodBind7, GodotObject.GetPtr(this), (int)hashType, key, msg);
    }

    /// <summary>
    /// <para>Generates an <a href="https://en.wikipedia.org/wiki/HMAC">HMAC</a> digest of <paramref name="msg"/> using <paramref name="key"/>. The <paramref name="hashType"/> parameter is the hashing algorithm that is used for the inner and outer hashes.</para>
    /// <para>Currently, only <see cref="Godot.HashingContext.HashType.Sha256"/> and <see cref="Godot.HashingContext.HashType.Sha1"/> are supported.</para>
    /// </summary>
    public byte[] HmacDigest(HashingContext.HashType hashType, ReadOnlySpan<byte> key, ReadOnlySpan<byte> msg)
    {
        return NativeCalls.godot_icall_3_348(MethodBind7, GodotObject.GetPtr(this), (int)hashType, key, msg);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ConstantTimeCompare, 1024142237ul);

    /// <summary>
    /// <para>Compares two <see cref="byte"/>[]s for equality without leaking timing information in order to prevent timing attacks.</para>
    /// <para>See <a href="https://paragonie.com/blog/2015/11/preventing-timing-attacks-on-string-comparison-with-double-hmac-strategy">this blog post</a> for more information.</para>
    /// </summary>
    public bool ConstantTimeCompare(byte[] trusted, byte[] received)
    {
        return NativeCalls.godot_icall_2_349(MethodBind8, GodotObject.GetPtr(this), trusted, received).ToBool();
    }

    /// <summary>
    /// <para>Compares two <see cref="byte"/>[]s for equality without leaking timing information in order to prevent timing attacks.</para>
    /// <para>See <a href="https://paragonie.com/blog/2015/11/preventing-timing-attacks-on-string-comparison-with-double-hmac-strategy">this blog post</a> for more information.</para>
    /// </summary>
    public bool ConstantTimeCompare(ReadOnlySpan<byte> trusted, ReadOnlySpan<byte> received)
    {
        return NativeCalls.godot_icall_2_349(MethodBind8, GodotObject.GetPtr(this), trusted, received).ToBool();
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
        /// Cached name for the 'generate_random_bytes' method.
        /// </summary>
        public static readonly StringName GenerateRandomBytes = "generate_random_bytes";
        /// <summary>
        /// Cached name for the 'generate_rsa' method.
        /// </summary>
        public static readonly StringName GenerateRsa = "generate_rsa";
        /// <summary>
        /// Cached name for the 'generate_self_signed_certificate' method.
        /// </summary>
        public static readonly StringName GenerateSelfSignedCertificate = "generate_self_signed_certificate";
        /// <summary>
        /// Cached name for the 'sign' method.
        /// </summary>
        public static readonly StringName Sign = "sign";
        /// <summary>
        /// Cached name for the 'verify' method.
        /// </summary>
        public static readonly StringName Verify = "verify";
        /// <summary>
        /// Cached name for the 'encrypt' method.
        /// </summary>
        public static readonly StringName Encrypt = "encrypt";
        /// <summary>
        /// Cached name for the 'decrypt' method.
        /// </summary>
        public static readonly StringName Decrypt = "decrypt";
        /// <summary>
        /// Cached name for the 'hmac_digest' method.
        /// </summary>
        public static readonly StringName HmacDigest = "hmac_digest";
        /// <summary>
        /// Cached name for the 'constant_time_compare' method.
        /// </summary>
        public static readonly StringName ConstantTimeCompare = "constant_time_compare";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : RefCounted.SignalName
    {
    }
}
