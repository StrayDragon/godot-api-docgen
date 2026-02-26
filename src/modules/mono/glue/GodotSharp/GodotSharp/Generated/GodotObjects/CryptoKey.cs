namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>The CryptoKey class represents a cryptographic key. Keys can be loaded and saved like any other <see cref="Godot.Resource"/>.</para>
/// <para>They can be used to generate a self-signed <see cref="Godot.X509Certificate"/> via <see cref="Godot.Crypto.GenerateSelfSignedCertificate(CryptoKey, string, string, string)"/> and as private key in <see cref="Godot.StreamPeerTls.AcceptStream(StreamPeer, TlsOptions)"/> along with the appropriate certificate.</para>
/// </summary>
public partial class CryptoKey : Resource
{
    private static readonly System.Type CachedType = typeof(CryptoKey);

    private static readonly StringName NativeName = "CryptoKey";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public CryptoKey() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal CryptoKey(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal CryptoKey(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Save, 885841341ul);

    /// <summary>
    /// <para>Saves a key to the given <paramref name="path"/>. If <paramref name="publicOnly"/> is <see langword="true"/>, only the public key will be saved.</para>
    /// <para><b>Note:</b> <paramref name="path"/> should be a "*.pub" file if <paramref name="publicOnly"/> is <see langword="true"/>, a "*.key" file otherwise.</para>
    /// </summary>
    public Error Save(string path, bool publicOnly = false)
    {
        return (Error)NativeCalls.godot_icall_2_350(MethodBind0, GodotObject.GetPtr(this), path, publicOnly.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Load, 885841341ul);

    /// <summary>
    /// <para>Loads a key from <paramref name="path"/>. If <paramref name="publicOnly"/> is <see langword="true"/>, only the public key will be loaded.</para>
    /// <para><b>Note:</b> <paramref name="path"/> should be a "*.pub" file if <paramref name="publicOnly"/> is <see langword="true"/>, a "*.key" file otherwise.</para>
    /// </summary>
    public Error Load(string path, bool publicOnly = false)
    {
        return (Error)NativeCalls.godot_icall_2_350(MethodBind1, GodotObject.GetPtr(this), path, publicOnly.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsPublicOnly, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if this CryptoKey only has the public part, and not the private one.</para>
    /// </summary>
    public bool IsPublicOnly()
    {
        return NativeCalls.godot_icall_0_15(MethodBind2, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SaveToString, 32795936ul);

    /// <summary>
    /// <para>Returns a string containing the key in PEM format. If <paramref name="publicOnly"/> is <see langword="true"/>, only the public key will be included.</para>
    /// </summary>
    public string SaveToString(bool publicOnly = false)
    {
        return NativeCalls.godot_icall_1_351(MethodBind3, GodotObject.GetPtr(this), publicOnly.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.LoadFromString, 885841341ul);

    /// <summary>
    /// <para>Loads a key from the given <paramref name="stringKey"/>. If <paramref name="publicOnly"/> is <see langword="true"/>, only the public key will be loaded.</para>
    /// </summary>
    public Error LoadFromString(string stringKey, bool publicOnly = false)
    {
        return (Error)NativeCalls.godot_icall_2_350(MethodBind4, GodotObject.GetPtr(this), stringKey, publicOnly.ToGodotBool());
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
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Resource.MethodName
    {
        /// <summary>
        /// Cached name for the 'save' method.
        /// </summary>
        public static readonly StringName Save = "save";
        /// <summary>
        /// Cached name for the 'load' method.
        /// </summary>
        public static readonly StringName Load = "load";
        /// <summary>
        /// Cached name for the 'is_public_only' method.
        /// </summary>
        public static readonly StringName IsPublicOnly = "is_public_only";
        /// <summary>
        /// Cached name for the 'save_to_string' method.
        /// </summary>
        public static readonly StringName SaveToString = "save_to_string";
        /// <summary>
        /// Cached name for the 'load_from_string' method.
        /// </summary>
        public static readonly StringName LoadFromString = "load_from_string";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Resource.SignalName
    {
    }
}
