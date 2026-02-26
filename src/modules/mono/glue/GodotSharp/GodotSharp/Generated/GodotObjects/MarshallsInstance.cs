namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Provides data transformation and encoding utility functions.</para>
/// </summary>
[GodotClassName("Marshalls")]
public partial class MarshallsInstance : GodotObject
{
    private static readonly System.Type CachedType = typeof(MarshallsInstance);

    private static readonly StringName NativeName = "Marshalls";

    internal MarshallsInstance() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal MarshallsInstance(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal MarshallsInstance(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.VariantToBase64, 3876248563ul);

    /// <summary>
    /// <para>Returns a Base64-encoded string of the <see cref="Godot.Variant"/> <paramref name="variant"/>. If <paramref name="fullObjects"/> is <see langword="true"/>, encoding objects is allowed (and can potentially include code).</para>
    /// <para>Internally, this uses the same encoding mechanism as the <c>@GlobalScope.var_to_bytes</c> method.</para>
    /// </summary>
    public string VariantToBase64(Variant variant, bool fullObjects = false)
    {
        return NativeCalls.godot_icall_2_787(MethodBind0, GodotObject.GetPtr(this), variant, fullObjects.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Base64ToVariant, 218087648ul);

    /// <summary>
    /// <para>Returns a decoded <see cref="Godot.Variant"/> corresponding to the Base64-encoded string <paramref name="base64Str"/>. If <paramref name="allowObjects"/> is <see langword="true"/>, decoding objects is allowed.</para>
    /// <para>Internally, this uses the same decoding mechanism as the <c>@GlobalScope.bytes_to_var</c> method.</para>
    /// <para><b>Warning:</b> Deserialized objects can contain code which gets executed. Do not use this option if the serialized object comes from untrusted sources to avoid potential security threats such as remote code execution.</para>
    /// </summary>
    public Variant Base64ToVariant(string base64Str, bool allowObjects = false)
    {
        return NativeCalls.godot_icall_2_780(MethodBind1, GodotObject.GetPtr(this), base64Str, allowObjects.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RawToBase64, 3999417757ul);

    /// <summary>
    /// <para>Returns a Base64-encoded string of a given <see cref="byte"/>[].</para>
    /// </summary>
    public string RawToBase64(byte[] array)
    {
        return NativeCalls.godot_icall_1_788(MethodBind2, GodotObject.GetPtr(this), array);
    }

    /// <summary>
    /// <para>Returns a Base64-encoded string of a given <see cref="byte"/>[].</para>
    /// </summary>
    public string RawToBase64(ReadOnlySpan<byte> array)
    {
        return NativeCalls.godot_icall_1_788(MethodBind2, GodotObject.GetPtr(this), array);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Base64ToRaw, 659035735ul);

    /// <summary>
    /// <para>Returns a decoded <see cref="byte"/>[] corresponding to the Base64-encoded string <paramref name="base64Str"/>.</para>
    /// </summary>
    public byte[] Base64ToRaw(string base64Str)
    {
        return NativeCalls.godot_icall_1_789(MethodBind3, GodotObject.GetPtr(this), base64Str);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Utf8ToBase64, 1703090593ul);

    /// <summary>
    /// <para>Returns a Base64-encoded string of the UTF-8 string <paramref name="utf8Str"/>.</para>
    /// </summary>
    public string Utf8ToBase64(string utf8Str)
    {
        return NativeCalls.godot_icall_1_304(MethodBind4, GodotObject.GetPtr(this), utf8Str);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Base64ToUtf8, 1703090593ul);

    /// <summary>
    /// <para>Returns a decoded string corresponding to the Base64-encoded string <paramref name="base64Str"/>.</para>
    /// </summary>
    public string Base64ToUtf8(string base64Str)
    {
        return NativeCalls.godot_icall_1_304(MethodBind5, GodotObject.GetPtr(this), base64Str);
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
    public new class PropertyName : GodotObject.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : GodotObject.MethodName
    {
        /// <summary>
        /// Cached name for the 'variant_to_base64' method.
        /// </summary>
        public static readonly StringName VariantToBase64 = "variant_to_base64";
        /// <summary>
        /// Cached name for the 'base64_to_variant' method.
        /// </summary>
        public static readonly StringName Base64ToVariant = "base64_to_variant";
        /// <summary>
        /// Cached name for the 'raw_to_base64' method.
        /// </summary>
        public static readonly StringName RawToBase64 = "raw_to_base64";
        /// <summary>
        /// Cached name for the 'base64_to_raw' method.
        /// </summary>
        public static readonly StringName Base64ToRaw = "base64_to_raw";
        /// <summary>
        /// Cached name for the 'utf8_to_base64' method.
        /// </summary>
        public static readonly StringName Utf8ToBase64 = "utf8_to_base64";
        /// <summary>
        /// Cached name for the 'base64_to_utf8' method.
        /// </summary>
        public static readonly StringName Base64ToUtf8 = "base64_to_utf8";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : GodotObject.SignalName
    {
    }
}
