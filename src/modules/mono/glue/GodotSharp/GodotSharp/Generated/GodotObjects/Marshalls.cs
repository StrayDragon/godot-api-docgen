namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Provides data transformation and encoding utility functions.</para>
/// </summary>
public static partial class Marshalls
{
    private static readonly StringName NativeName = "Marshalls";

    private static MarshallsInstance singleton;

    public static MarshallsInstance Singleton =>
        singleton ??= (MarshallsInstance)InteropUtils.EngineGetSingleton("Marshalls");

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.VariantToBase64, 3876248563ul);

    /// <summary>
    /// <para>Returns a Base64-encoded string of the <see cref="Godot.Variant"/> <paramref name="variant"/>. If <paramref name="fullObjects"/> is <see langword="true"/>, encoding objects is allowed (and can potentially include code).</para>
    /// <para>Internally, this uses the same encoding mechanism as the <c>@GlobalScope.var_to_bytes</c> method.</para>
    /// </summary>
    public static string VariantToBase64(Variant variant, bool fullObjects = false)
    {
        return NativeCalls.godot_icall_2_787(MethodBind0, GodotObject.GetPtr(Singleton), variant, fullObjects.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.Base64ToVariant, 218087648ul);

    /// <summary>
    /// <para>Returns a decoded <see cref="Godot.Variant"/> corresponding to the Base64-encoded string <paramref name="base64Str"/>. If <paramref name="allowObjects"/> is <see langword="true"/>, decoding objects is allowed.</para>
    /// <para>Internally, this uses the same decoding mechanism as the <c>@GlobalScope.bytes_to_var</c> method.</para>
    /// <para><b>Warning:</b> Deserialized objects can contain code which gets executed. Do not use this option if the serialized object comes from untrusted sources to avoid potential security threats such as remote code execution.</para>
    /// </summary>
    public static Variant Base64ToVariant(string base64Str, bool allowObjects = false)
    {
        return NativeCalls.godot_icall_2_780(MethodBind1, GodotObject.GetPtr(Singleton), base64Str, allowObjects.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.RawToBase64, 3999417757ul);

    /// <summary>
    /// <para>Returns a Base64-encoded string of a given <see cref="byte"/>[].</para>
    /// </summary>
    public static string RawToBase64(byte[] array)
    {
        return NativeCalls.godot_icall_1_788(MethodBind2, GodotObject.GetPtr(Singleton), array);
    }

    /// <summary>
    /// <para>Returns a Base64-encoded string of a given <see cref="byte"/>[].</para>
    /// </summary>
    public static string RawToBase64(ReadOnlySpan<byte> array)
    {
        return NativeCalls.godot_icall_1_788(MethodBind2, GodotObject.GetPtr(Singleton), array);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.Base64ToRaw, 659035735ul);

    /// <summary>
    /// <para>Returns a decoded <see cref="byte"/>[] corresponding to the Base64-encoded string <paramref name="base64Str"/>.</para>
    /// </summary>
    public static byte[] Base64ToRaw(string base64Str)
    {
        return NativeCalls.godot_icall_1_789(MethodBind3, GodotObject.GetPtr(Singleton), base64Str);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.Utf8ToBase64, 1703090593ul);

    /// <summary>
    /// <para>Returns a Base64-encoded string of the UTF-8 string <paramref name="utf8Str"/>.</para>
    /// </summary>
    public static string Utf8ToBase64(string utf8Str)
    {
        return NativeCalls.godot_icall_1_304(MethodBind4, GodotObject.GetPtr(Singleton), utf8Str);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.Base64ToUtf8, 1703090593ul);

    /// <summary>
    /// <para>Returns a decoded string corresponding to the Base64-encoded string <paramref name="base64Str"/>.</para>
    /// </summary>
    public static string Base64ToUtf8(string base64Str)
    {
        return NativeCalls.godot_icall_1_304(MethodBind5, GodotObject.GetPtr(Singleton), base64Str);
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public class PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public class MethodName
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
    public class SignalName
    {
    }
}
