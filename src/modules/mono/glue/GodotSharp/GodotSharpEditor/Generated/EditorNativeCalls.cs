namespace Godot;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using Godot.NativeInterop;

[SuppressMessage("ReSharper", "InconsistentNaming")]
[SuppressMessage("ReSharper", "RedundantUnsafeContext")]
[SuppressMessage("ReSharper", "RedundantNameQualifier")]
[System.Runtime.CompilerServices.SkipLocalsInit]
internal static class EditorNativeCalls
{
    internal static ulong godot_api_hash = 1382129929;

    private const int VarArgsSpanThreshold = 10;


    internal static unsafe void godot_icall_4_465(IntPtr method, IntPtr ptr, string arg1, string arg2, in Callable arg3, string arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        using godot_string arg2_in = Marshaling.ConvertStringToNative(arg2);
        using godot_callable arg3_in = Marshaling.ConvertCallableToNative(in arg3);
        using godot_string arg4_in = Marshaling.ConvertStringToNative(arg4);
        void** call_args = stackalloc void*[4] { &arg1_in, &arg2_in, &arg3_in, &arg4_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_2_466(IntPtr method, IntPtr ptr, IntPtr arg1, in Callable arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_callable arg2_in = Marshaling.ConvertCallableToNative(in arg2);
        void** call_args = stackalloc void*[2] { &arg1, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_3_467(IntPtr method, IntPtr ptr, string arg1, in Callable arg2, IntPtr arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        using godot_callable arg2_in = Marshaling.ConvertCallableToNative(in arg2);
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2_in, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_3_468(IntPtr method, IntPtr ptr, string arg1, IntPtr arg2, IntPtr arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_3_470(IntPtr method, IntPtr ptr, string arg1, godot_bool arg2, godot_array arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe Godot.Collections.Dictionary godot_icall_1_471(IntPtr method, IntPtr ptr, string arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_dictionary ret = default;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Godot.Collections.Dictionary.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe Godot.Collections.Dictionary godot_icall_4_472(IntPtr method, IntPtr ptr, IntPtr arg1, godot_bool arg2, string arg3, godot_bool arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_dictionary ret = default;
        using godot_string arg3_in = Marshaling.ConvertStringToNative(arg3);
        void** call_args = stackalloc void*[4] { &arg1, &arg2, &arg3_in, &arg4 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Godot.Collections.Dictionary.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe Godot.Collections.Dictionary godot_icall_3_473(IntPtr method, IntPtr ptr, IntPtr arg1, godot_bool arg2, string arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_dictionary ret = default;
        using godot_string arg3_in = Marshaling.ConvertStringToNative(arg3);
        void** call_args = stackalloc void*[3] { &arg1, &arg2, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Godot.Collections.Dictionary.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe int godot_icall_4_475(IntPtr method, IntPtr ptr, IntPtr arg1, godot_bool arg2, in Callable arg3, in Callable arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        using godot_callable arg3_in = Marshaling.ConvertCallableToNative(in arg3);
        using godot_callable arg4_in = Marshaling.ConvertCallableToNative(in arg4);
        void** call_args = stackalloc void*[4] { &arg1, &arg2, &arg3_in, &arg4_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe int godot_icall_4_476(IntPtr method, IntPtr ptr, IntPtr arg1, godot_bool arg2, string arg3, int arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        using godot_string arg3_in = Marshaling.ConvertStringToNative(arg3);
        long arg4_in = arg4;
        void** call_args = stackalloc void*[4] { &arg1, &arg2, &arg3_in, &arg4_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe int godot_icall_5_477(IntPtr method, IntPtr ptr, IntPtr arg1, godot_bool arg2, string arg3, ReadOnlySpan<string> arg4, int arg5)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        using godot_string arg3_in = Marshaling.ConvertStringToNative(arg3);
        using godot_packed_string_array arg4_in = Marshaling.ConvertSystemArrayToNativePackedStringArray(arg4);
        long arg5_in = arg5;
        void** call_args = stackalloc void*[5] { &arg1, &arg2, &arg3_in, &arg4_in, &arg5_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe void godot_icall_3_478(IntPtr method, IntPtr ptr, int arg1, string arg2, string arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        using godot_string arg2_in = Marshaling.ConvertStringToNative(arg2);
        using godot_string arg3_in = Marshaling.ConvertStringToNative(arg3);
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2_in, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe int godot_icall_6_479(IntPtr method, IntPtr ptr, string arg1, string arg2, ReadOnlySpan<string> arg3, string arg4, godot_array arg5, int arg6)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        using godot_string arg2_in = Marshaling.ConvertStringToNative(arg2);
        using godot_packed_string_array arg3_in = Marshaling.ConvertSystemArrayToNativePackedStringArray(arg3);
        using godot_string arg4_in = Marshaling.ConvertStringToNative(arg4);
        long arg6_in = arg6;
        void** call_args = stackalloc void*[6] { &arg1_in, &arg2_in, &arg3_in, &arg4_in, &arg5, &arg6_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe long godot_icall_5_480(IntPtr method, IntPtr ptr, string arg1, string arg2, ReadOnlySpan<string> arg3, string arg4, int arg5)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        using godot_string arg2_in = Marshaling.ConvertStringToNative(arg2);
        using godot_packed_string_array arg3_in = Marshaling.ConvertSystemArrayToNativePackedStringArray(arg3);
        using godot_string arg4_in = Marshaling.ConvertStringToNative(arg4);
        long arg5_in = arg5;
        void** call_args = stackalloc void*[5] { &arg1_in, &arg2_in, &arg3_in, &arg4_in, &arg5_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe int godot_icall_5_481(IntPtr method, IntPtr ptr, string arg1, string arg2, ReadOnlySpan<string> arg3, string arg4, string arg5)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        using godot_string arg2_in = Marshaling.ConvertStringToNative(arg2);
        using godot_packed_string_array arg3_in = Marshaling.ConvertSystemArrayToNativePackedStringArray(arg3);
        using godot_string arg4_in = Marshaling.ConvertStringToNative(arg4);
        using godot_string arg5_in = Marshaling.ConvertStringToNative(arg5);
        void** call_args = stackalloc void*[5] { &arg1_in, &arg2_in, &arg3_in, &arg4_in, &arg5_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe string[] godot_icall_1_483(IntPtr method, IntPtr arg1)
    {
        using godot_packed_string_array ret = default;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, IntPtr.Zero, call_args, &ret);
        return Marshaling.ConvertNativePackedStringArrayToSystemArray(ret);
    }

    internal static unsafe void godot_icall_3_485(IntPtr method, IntPtr ptr, string arg1, ReadOnlySpan<string> arg2, string arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        using godot_packed_string_array arg2_in = Marshaling.ConvertSystemArrayToNativePackedStringArray(arg2);
        using godot_string arg3_in = Marshaling.ConvertStringToNative(arg3);
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2_in, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_3_486(IntPtr method, IntPtr ptr, string arg1, ReadOnlySpan<byte> arg2, godot_bool arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        using godot_packed_byte_array arg2_in = Marshaling.ConvertSystemArrayToNativePackedByteArray(arg2);
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2_in, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe Variant godot_icall_2_487(IntPtr method, IntPtr ptr, godot_string_name arg1, string arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_variant ret = default;
        using godot_string arg2_in = Marshaling.ConvertStringToNative(arg2);
        void** call_args = stackalloc void*[2] { &arg1, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Variant.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe string godot_icall_2_488(IntPtr method, IntPtr ptr, godot_string_name arg1, godot_bool arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string ret = default;
        void** call_args = stackalloc void*[2] { &arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertStringToManaged(ret);
    }

    internal static unsafe void godot_icall_3_489(IntPtr method, IntPtr ptr, godot_string_name arg1, godot_string_name arg2, godot_bool arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[3] { &arg1, &arg2, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_2_490(IntPtr method, IntPtr ptr, IntPtr arg1, string arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string arg2_in = Marshaling.ConvertStringToNative(arg2);
        void** call_args = stackalloc void*[2] { &arg1, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe int godot_icall_4_491(IntPtr method, IntPtr ptr, string arg1, godot_dictionary arg2, string arg3, Variant arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        using godot_string arg3_in = Marshaling.ConvertStringToNative(arg3);
        godot_variant arg4_in = (godot_variant)arg4.NativeVar;
        void** call_args = stackalloc void*[4] { &arg1_in, &arg2, &arg3_in, &arg4_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe GodotObject godot_icall_7_492(IntPtr method, IntPtr arg1, int arg2, string arg3, int arg4, string arg5, uint arg6, godot_bool arg7)
    {
        IntPtr ret = default;
        long arg2_in = arg2;
        using godot_string arg3_in = Marshaling.ConvertStringToNative(arg3);
        long arg4_in = arg4;
        using godot_string arg5_in = Marshaling.ConvertStringToNative(arg5);
        long arg6_in = arg6;
        void** call_args = stackalloc void*[7] { &arg1, &arg2_in, &arg3_in, &arg4_in, &arg5_in, &arg6_in, &arg7 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, IntPtr.Zero, call_args, &ret);
        return InteropUtils.UnmanagedGetManaged(ret);
    }

    internal static unsafe void godot_icall_4_493(IntPtr method, IntPtr ptr, string arg1, IntPtr arg2, godot_bool arg3, string arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        using godot_string arg4_in = Marshaling.ConvertStringToNative(arg4);
        void** call_args = stackalloc void*[4] { &arg1_in, &arg2, &arg3, &arg4_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_3_494(IntPtr method, IntPtr ptr, string arg1, ReadOnlySpan<string> arg2, IntPtr arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        using godot_packed_string_array arg2_in = Marshaling.ConvertSystemArrayToNativePackedStringArray(arg2);
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2_in, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_3_495(IntPtr method, IntPtr ptr, string arg1, IntPtr arg2, godot_bool arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe Godot.Collections.Array godot_icall_2_496(IntPtr method, IntPtr ptr, godot_array arg1, int arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_array ret = default;
        long arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Godot.Collections.Array.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe void godot_icall_3_501(IntPtr method, IntPtr ptr, in Callable arg1, godot_array arg2, IntPtr arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_callable arg1_in = Marshaling.ConvertCallableToNative(in arg1);
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_4_502(IntPtr method, IntPtr ptr, IntPtr arg1, in Callable arg2, ReadOnlySpan<int> arg3, string arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_callable arg2_in = Marshaling.ConvertCallableToNative(in arg2);
        using godot_packed_int32_array arg3_in = Marshaling.ConvertSystemArrayToNativePackedInt32Array(arg3);
        using godot_string arg4_in = Marshaling.ConvertStringToNative(arg4);
        void** call_args = stackalloc void*[4] { &arg1, &arg2_in, &arg3_in, &arg4_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_3_503(IntPtr method, IntPtr ptr, IntPtr arg1, in Callable arg2, string arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_callable arg2_in = Marshaling.ConvertCallableToNative(in arg2);
        using godot_string arg3_in = Marshaling.ConvertStringToNative(arg3);
        void** call_args = stackalloc void*[3] { &arg1, &arg2_in, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_2_504(IntPtr method, IntPtr ptr, in Callable arg1, godot_array arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_callable arg1_in = Marshaling.ConvertCallableToNative(in arg1);
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_5_505(IntPtr method, IntPtr ptr, in Callable arg1, godot_string_name arg2, string arg3, string arg4, godot_array arg5)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_callable arg1_in = Marshaling.ConvertCallableToNative(in arg1);
        using godot_string arg3_in = Marshaling.ConvertStringToNative(arg3);
        using godot_string arg4_in = Marshaling.ConvertStringToNative(arg4);
        void** call_args = stackalloc void*[5] { &arg1_in, &arg2, &arg3_in, &arg4_in, &arg5 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_3_506(IntPtr method, IntPtr ptr, IntPtr arg1, string arg2, godot_bool arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string arg2_in = Marshaling.ConvertStringToNative(arg2);
        void** call_args = stackalloc void*[3] { &arg1, &arg2_in, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_4_507(IntPtr method, IntPtr ptr, IntPtr arg1, int arg2, int arg3, godot_bool arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg2_in = arg2;
        long arg3_in = arg3;
        void** call_args = stackalloc void*[4] { &arg1, &arg2_in, &arg3_in, &arg4 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_3_509(IntPtr method, IntPtr ptr, IntPtr arg1, in Callable arg2, ReadOnlySpan<int> arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_callable arg2_in = Marshaling.ConvertCallableToNative(in arg2);
        using godot_packed_int32_array arg3_in = Marshaling.ConvertSystemArrayToNativePackedInt32Array(arg3);
        void** call_args = stackalloc void*[3] { &arg1, &arg2_in, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_4_510(IntPtr method, IntPtr ptr, ReadOnlySpan<Vector3> arg1, IntPtr arg2, godot_bool arg3, Color* arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_vector3_array arg1_in = Marshaling.ConvertSystemArrayToNativePackedVector3Array(arg1);
        void** call_args = stackalloc void*[4] { &arg1_in, &arg2, &arg3, arg4 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_4_511(IntPtr method, IntPtr ptr, IntPtr arg1, IntPtr arg2, Transform3D* arg3, IntPtr arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[4] { &arg1, &arg2, arg3, &arg4 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_3_512(IntPtr method, IntPtr ptr, IntPtr arg1, float arg2, Color* arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double arg2_in = arg2;
        void** call_args = stackalloc void*[3] { &arg1, &arg2_in, arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_5_513(IntPtr method, IntPtr ptr, ReadOnlySpan<Vector3> arg1, IntPtr arg2, ReadOnlySpan<int> arg3, godot_bool arg4, godot_bool arg5)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_vector3_array arg1_in = Marshaling.ConvertSystemArrayToNativePackedVector3Array(arg1);
        using godot_packed_int32_array arg3_in = Marshaling.ConvertSystemArrayToNativePackedInt32Array(arg3);
        void** call_args = stackalloc void*[5] { &arg1_in, &arg2, &arg3_in, &arg4, &arg5 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_5_514(IntPtr method, IntPtr ptr, string arg1, Color* arg2, godot_bool arg3, godot_bool arg4, godot_bool arg5)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        void** call_args = stackalloc void*[5] { &arg1_in, arg2, &arg3, &arg4, &arg5 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_4_515(IntPtr method, IntPtr ptr, string arg1, IntPtr arg2, godot_bool arg3, Color* arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        void** call_args = stackalloc void*[4] { &arg1_in, &arg2, &arg3, arg4 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_3_516(IntPtr method, IntPtr ptr, string arg1, godot_bool arg2, IntPtr arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe GodotObject godot_icall_2_518(IntPtr method, IntPtr ptr, string arg1, IntPtr arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_ref ret = default;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return InteropUtils.UnmanagedGetManaged(ret.Reference);
    }

    internal static unsafe void godot_icall_4_520(IntPtr method, IntPtr ptr, string arg1, string arg2, IntPtr arg3, IntPtr arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        using godot_string arg2_in = Marshaling.ConvertStringToNative(arg2);
        void** call_args = stackalloc void*[4] { &arg1_in, &arg2_in, &arg3, &arg4 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_3_521(IntPtr method, IntPtr ptr, int arg1, IntPtr arg2, IntPtr arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe GodotObject godot_icall_3_522(IntPtr method, IntPtr ptr, IntPtr arg1, string arg2, IntPtr arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        IntPtr ret = default;
        using godot_string arg2_in = Marshaling.ConvertStringToNative(arg2);
        void** call_args = stackalloc void*[3] { &arg1, &arg2_in, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return InteropUtils.UnmanagedGetManaged(ret);
    }

    internal static unsafe GodotObject godot_icall_2_523(IntPtr method, IntPtr ptr, IntPtr arg1, string arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        IntPtr ret = default;
        using godot_string arg2_in = Marshaling.ConvertStringToNative(arg2);
        void** call_args = stackalloc void*[2] { &arg1, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return InteropUtils.UnmanagedGetManaged(ret);
    }

    internal static unsafe void godot_icall_4_525(IntPtr method, IntPtr ptr, godot_string_name arg1, Variant arg2, godot_string_name arg3, godot_bool arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_variant arg2_in = (godot_variant)arg2.NativeVar;
        void** call_args = stackalloc void*[4] { &arg1, &arg2_in, &arg3, &arg4 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_4_526(IntPtr method, IntPtr ptr, string arg1, IntPtr arg2, godot_string_name arg3, Variant arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        godot_variant arg4_in = (godot_variant)arg4.NativeVar;
        void** call_args = stackalloc void*[4] { &arg1_in, &arg2, &arg3, &arg4_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_4_527(IntPtr method, IntPtr ptr, IntPtr arg1, IntPtr arg2, godot_string_name arg3, Variant arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_variant arg4_in = (godot_variant)arg4.NativeVar;
        void** call_args = stackalloc void*[4] { &arg1, &arg2, &arg3, &arg4_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_6_529(IntPtr method, IntPtr ptr, int arg1, string arg2, Variant arg3, int arg4, string arg5, int arg6)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        using godot_string arg2_in = Marshaling.ConvertStringToNative(arg2);
        godot_variant arg3_in = (godot_variant)arg3.NativeVar;
        long arg4_in = arg4;
        using godot_string arg5_in = Marshaling.ConvertStringToNative(arg5);
        long arg6_in = arg6;
        void** call_args = stackalloc void*[6] { &arg1_in, &arg2_in, &arg3_in, &arg4_in, &arg5_in, &arg6_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_3_531(IntPtr method, IntPtr ptr, godot_string_name arg1, Variant arg2, godot_bool arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_variant arg2_in = (godot_variant)arg2.NativeVar;
        void** call_args = stackalloc void*[3] { &arg1, &arg2_in, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe godot_bool godot_icall_2_532(IntPtr method, IntPtr ptr, string arg1, IntPtr arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_bool ret;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe void godot_icall_5_534(IntPtr method, IntPtr ptr, string arg1, int arg2, IntPtr arg3, godot_bool arg4, godot_bool arg5)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        long arg2_in = arg2;
        void** call_args = stackalloc void*[5] { &arg1_in, &arg2_in, &arg3, &arg4, &arg5 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_3_535(IntPtr method, IntPtr ptr, IntPtr arg1, godot_string_name arg2, ReadOnlySpan<Variant> arg3, godot_string_name caller)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        int vararg_length = arg3.Length;
        int total_length = 2 + vararg_length;
        Span<godot_variant.movable> varargs_span = vararg_length <= VarArgsSpanThreshold ?
            stackalloc godot_variant.movable[VarArgsSpanThreshold] :
            new godot_variant.movable[vararg_length];
        Span<IntPtr> call_args_span = total_length <= VarArgsSpanThreshold ?
            stackalloc IntPtr[VarArgsSpanThreshold] :
            new IntPtr[total_length];
        fixed (godot_variant.movable* varargs = &MemoryMarshal.GetReference(varargs_span))
        fixed (IntPtr* call_args = &MemoryMarshal.GetReference(call_args_span))
        {
            using godot_variant arg1_in = VariantUtils.CreateFromGodotObjectPtr(arg1);
            call_args[0] = new IntPtr(&arg1_in);
            using godot_variant arg2_in = VariantUtils.CreateFromStringName(arg2);
            call_args[1] = new IntPtr(&arg2_in);
            for (int i = 0; i < vararg_length; i++)
            {
                varargs[i] = arg3[i].NativeVar;
                call_args[2 + i] = new IntPtr(&varargs[i]);
            }
            NativeFuncs.godotsharp_method_bind_call(method, ptr, (godot_variant**)call_args, total_length, out godot_variant_call_error vcall_error);
            ExceptionUtils.DebugCheckCallError(caller, ptr, (godot_variant**)call_args, total_length, vcall_error);
        }
    }

    internal static unsafe void godot_icall_4_537(IntPtr method, IntPtr ptr, string arg1, int arg2, IntPtr arg3, godot_bool arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        long arg2_in = arg2;
        void** call_args = stackalloc void*[4] { &arg1_in, &arg2_in, &arg3, &arg4 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe Godot.Collections.Dictionary godot_icall_4_538(IntPtr method, IntPtr ptr, int arg1, int arg2, string arg3, string arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_dictionary ret = default;
        long arg1_in = arg1;
        long arg2_in = arg2;
        using godot_string arg3_in = Marshaling.ConvertStringToNative(arg3);
        using godot_string arg4_in = Marshaling.ConvertStringToNative(arg4);
        void** call_args = stackalloc void*[4] { &arg1_in, &arg2_in, &arg3_in, &arg4_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Godot.Collections.Dictionary.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe Godot.Collections.Dictionary godot_icall_4_539(IntPtr method, IntPtr ptr, int arg1, int arg2, int arg3, int arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_dictionary ret = default;
        long arg1_in = arg1;
        long arg2_in = arg2;
        long arg3_in = arg3;
        long arg4_in = arg4;
        void** call_args = stackalloc void*[4] { &arg1_in, &arg2_in, &arg3_in, &arg4_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Godot.Collections.Dictionary.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe Godot.Collections.Dictionary godot_icall_2_540(IntPtr method, IntPtr ptr, string arg1, string arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_dictionary ret = default;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        using godot_string arg2_in = Marshaling.ConvertStringToNative(arg2);
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Godot.Collections.Dictionary.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe Godot.Collections.Dictionary godot_icall_5_541(IntPtr method, IntPtr ptr, string arg1, string arg2, string arg3, long arg4, long arg5)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_dictionary ret = default;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        using godot_string arg2_in = Marshaling.ConvertStringToNative(arg2);
        using godot_string arg3_in = Marshaling.ConvertStringToNative(arg3);
        void** call_args = stackalloc void*[5] { &arg1_in, &arg2_in, &arg3_in, &arg4, &arg5 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Godot.Collections.Dictionary.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe Godot.Collections.Dictionary godot_icall_3_542(IntPtr method, IntPtr ptr, string arg1, int arg2, int arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_dictionary ret = default;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        long arg2_in = arg2;
        long arg3_in = arg3;
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2_in, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Godot.Collections.Dictionary.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe Godot.Collections.Dictionary godot_icall_2_543(IntPtr method, IntPtr ptr, godot_dictionary arg1, godot_array arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_dictionary ret = default;
        void** call_args = stackalloc void*[2] { &arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Godot.Collections.Dictionary.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe void godot_icall_2_711(IntPtr method, IntPtr ptr, Vector3I* arg1, Vector3I* arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[2] { arg1, arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_4_1261(IntPtr method, IntPtr ptr, string arg1, string arg2, godot_bool arg3, godot_bool arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        using godot_string arg2_in = Marshaling.ConvertStringToNative(arg2);
        void** call_args = stackalloc void*[4] { &arg1_in, &arg2_in, &arg3, &arg4 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }
}
