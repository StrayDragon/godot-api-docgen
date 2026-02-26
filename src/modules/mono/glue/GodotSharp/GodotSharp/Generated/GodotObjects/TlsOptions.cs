namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>TLSOptions abstracts the configuration options for the <see cref="Godot.StreamPeerTls"/> and <see cref="Godot.PacketPeerDtls"/> classes.</para>
/// <para>Objects of this class cannot be instantiated directly, and one of the static methods <see cref="Godot.TlsOptions.Client(X509Certificate, string)"/>, <see cref="Godot.TlsOptions.ClientUnsafe(X509Certificate)"/>, or <see cref="Godot.TlsOptions.Server(CryptoKey, X509Certificate)"/> should be used instead.</para>
/// <para></para>
/// </summary>
[GodotClassName("TLSOptions")]
public partial class TlsOptions : RefCounted
{
    private static readonly System.Type CachedType = typeof(TlsOptions);

    private static readonly StringName NativeName = "TLSOptions";

    internal TlsOptions() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal TlsOptions(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal TlsOptions(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Client, 3565000357ul);

    /// <summary>
    /// <para>Creates a TLS client configuration which validates certificates and their common names (fully qualified domain names).</para>
    /// <para>You can specify a custom <paramref name="trustedChain"/> of certification authorities (the default CA list will be used if <see langword="null"/>), and optionally provide a <paramref name="commonNameOverride"/> if you expect the certificate to have a common name other than the server FQDN.</para>
    /// <para><b>Note:</b> On the Web platform, TLS verification is always enforced against the CA list of the web browser. This is considered a security feature.</para>
    /// </summary>
    public static TlsOptions Client(X509Certificate trustedChain = null, string commonNameOverride = "")
    {
        return (TlsOptions)NativeCalls.godot_icall_2_643(MethodBind0, GodotObject.GetPtr(trustedChain), commonNameOverride);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ClientUnsafe, 2090251749ul);

    /// <summary>
    /// <para>Creates an <b>unsafe</b> TLS client configuration where certificate validation is optional. You can optionally provide a valid <paramref name="trustedChain"/>, but the common name of the certificates will never be checked. Using this configuration for purposes other than testing <b>is not recommended</b>.</para>
    /// <para><b>Note:</b> On the Web platform, TLS verification is always enforced against the CA list of the web browser. This is considered a security feature.</para>
    /// </summary>
    public static TlsOptions ClientUnsafe(X509Certificate trustedChain = null)
    {
        return (TlsOptions)NativeCalls.godot_icall_1_637(MethodBind1, GodotObject.GetPtr(trustedChain));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Server, 36969539ul);

    /// <summary>
    /// <para>Creates a TLS server configuration using the provided <paramref name="key"/> and <paramref name="certificate"/>.</para>
    /// <para><b>Note:</b> The <paramref name="certificate"/> should include the full certificate chain up to the signing CA (certificates file can be concatenated using a general purpose text editor).</para>
    /// </summary>
    public static TlsOptions Server(CryptoKey key, X509Certificate certificate)
    {
        return (TlsOptions)NativeCalls.godot_icall_2_1298(MethodBind2, GodotObject.GetPtr(key), GodotObject.GetPtr(certificate));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsServer, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if created with <see cref="Godot.TlsOptions.Server(CryptoKey, X509Certificate)"/>, <see langword="false"/> otherwise.</para>
    /// </summary>
    public bool IsServer()
    {
        return NativeCalls.godot_icall_0_15(MethodBind3, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsUnsafeClient, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if created with <see cref="Godot.TlsOptions.ClientUnsafe(X509Certificate)"/>, <see langword="false"/> otherwise.</para>
    /// </summary>
    public bool IsUnsafeClient()
    {
        return NativeCalls.godot_icall_0_15(MethodBind4, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCommonNameOverride, 201670096ul);

    /// <summary>
    /// <para>Returns the common name (domain name) override specified when creating with <see cref="Godot.TlsOptions.Client(X509Certificate, string)"/>.</para>
    /// </summary>
    public string GetCommonNameOverride()
    {
        return NativeCalls.godot_icall_0_58(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTrustedCaChain, 1120709175ul);

    /// <summary>
    /// <para>Returns the CA <see cref="Godot.X509Certificate"/> chain specified when creating with <see cref="Godot.TlsOptions.Client(X509Certificate, string)"/> or <see cref="Godot.TlsOptions.ClientUnsafe(X509Certificate)"/>.</para>
    /// </summary>
    public X509Certificate GetTrustedCaChain()
    {
        return (X509Certificate)NativeCalls.godot_icall_0_63(MethodBind6, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPrivateKey, 2119971811ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.CryptoKey"/> specified when creating with <see cref="Godot.TlsOptions.Server(CryptoKey, X509Certificate)"/>.</para>
    /// </summary>
    public CryptoKey GetPrivateKey()
    {
        return (CryptoKey)NativeCalls.godot_icall_0_63(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOwnCertificate, 1120709175ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.X509Certificate"/> specified when creating with <see cref="Godot.TlsOptions.Server(CryptoKey, X509Certificate)"/>.</para>
    /// </summary>
    public X509Certificate GetOwnCertificate()
    {
        return (X509Certificate)NativeCalls.godot_icall_0_63(MethodBind8, GodotObject.GetPtr(this));
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
        /// Cached name for the 'client' method.
        /// </summary>
        public static readonly StringName Client = "client";
        /// <summary>
        /// Cached name for the 'client_unsafe' method.
        /// </summary>
        public static readonly StringName ClientUnsafe = "client_unsafe";
        /// <summary>
        /// Cached name for the 'server' method.
        /// </summary>
        public static readonly StringName Server = "server";
        /// <summary>
        /// Cached name for the 'is_server' method.
        /// </summary>
        public static readonly StringName IsServer = "is_server";
        /// <summary>
        /// Cached name for the 'is_unsafe_client' method.
        /// </summary>
        public static readonly StringName IsUnsafeClient = "is_unsafe_client";
        /// <summary>
        /// Cached name for the 'get_common_name_override' method.
        /// </summary>
        public static readonly StringName GetCommonNameOverride = "get_common_name_override";
        /// <summary>
        /// Cached name for the 'get_trusted_ca_chain' method.
        /// </summary>
        public static readonly StringName GetTrustedCaChain = "get_trusted_ca_chain";
        /// <summary>
        /// Cached name for the 'get_private_key' method.
        /// </summary>
        public static readonly StringName GetPrivateKey = "get_private_key";
        /// <summary>
        /// Cached name for the 'get_own_certificate' method.
        /// </summary>
        public static readonly StringName GetOwnCertificate = "get_own_certificate";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : RefCounted.SignalName
    {
    }
}
