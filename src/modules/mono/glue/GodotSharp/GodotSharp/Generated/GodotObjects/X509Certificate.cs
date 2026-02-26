namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>The X509Certificate class represents an X509 certificate. Certificates can be loaded and saved like any other <see cref="Godot.Resource"/>.</para>
/// <para>They can be used as the server certificate in <see cref="Godot.StreamPeerTls.AcceptStream(StreamPeer, TlsOptions)"/> (along with the proper <see cref="Godot.CryptoKey"/>), and to specify the only certificate that should be accepted when connecting to a TLS server via <see cref="Godot.StreamPeerTls.ConnectToStream(StreamPeer, string, TlsOptions)"/>.</para>
/// </summary>
public partial class X509Certificate : Resource
{
    private static readonly System.Type CachedType = typeof(X509Certificate);

    private static readonly StringName NativeName = "X509Certificate";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public X509Certificate() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal X509Certificate(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal X509Certificate(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Save, 166001499ul);

    /// <summary>
    /// <para>Saves a certificate to the given <paramref name="path"/> (should be a "*.crt" file).</para>
    /// </summary>
    public Error Save(string path)
    {
        return (Error)NativeCalls.godot_icall_1_134(MethodBind0, GodotObject.GetPtr(this), path);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Load, 166001499ul);

    /// <summary>
    /// <para>Loads a certificate from <paramref name="path"/> ("*.crt" file).</para>
    /// </summary>
    public Error Load(string path)
    {
        return (Error)NativeCalls.godot_icall_1_134(MethodBind1, GodotObject.GetPtr(this), path);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SaveToString, 2841200299ul);

    /// <summary>
    /// <para>Returns a string representation of the certificate, or an empty string if the certificate is invalid.</para>
    /// </summary>
    public string SaveToString()
    {
        return NativeCalls.godot_icall_0_58(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.LoadFromString, 166001499ul);

    /// <summary>
    /// <para>Loads a certificate from the given <paramref name="string"/>.</para>
    /// </summary>
    public Error LoadFromString(string @string)
    {
        return (Error)NativeCalls.godot_icall_1_134(MethodBind3, GodotObject.GetPtr(this), @string);
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
