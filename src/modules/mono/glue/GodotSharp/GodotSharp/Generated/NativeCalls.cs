namespace Godot;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using Godot.NativeInterop;

[SuppressMessage("ReSharper", "InconsistentNaming")]
[SuppressMessage("ReSharper", "RedundantUnsafeContext")]
[SuppressMessage("ReSharper", "RedundantNameQualifier")]
[System.Runtime.CompilerServices.SkipLocalsInit]
internal static class NativeCalls
{
    internal static ulong godot_api_hash = 3470380980;

    private const int VarArgsSpanThreshold = 10;

    internal static unsafe int godot_icall_3_0(IntPtr method, IntPtr ptr, int arg1, ReadOnlySpan<byte> arg2, ReadOnlySpan<byte> arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        long arg1_in = arg1;
        using godot_packed_byte_array arg2_in = Marshaling.ConvertSystemArrayToNativePackedByteArray(arg2);
        using godot_packed_byte_array arg3_in = Marshaling.ConvertSystemArrayToNativePackedByteArray(arg3);
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2_in, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe byte[] godot_icall_1_1(IntPtr method, IntPtr ptr, ReadOnlySpan<byte> arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_byte_array ret = default;
        using godot_packed_byte_array arg1_in = Marshaling.ConvertSystemArrayToNativePackedByteArray(arg1);
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertNativePackedByteArrayToSystemArray(ret);
    }

    internal static unsafe byte[] godot_icall_0_2(IntPtr method, IntPtr ptr)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_byte_array ret = default;
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, null, &ret);
        return Marshaling.ConvertNativePackedByteArrayToSystemArray(ret);
    }

    internal static unsafe void godot_icall_0_3(IntPtr method, IntPtr ptr)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, null, null);
    }

    internal static unsafe long godot_icall_0_4(IntPtr method, IntPtr ptr)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, null, &ret);
        return ret;
    }

    internal static unsafe void godot_icall_3_5(IntPtr method, IntPtr ptr, long arg1, Vector2* arg2, float arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double arg3_in = arg3;
        void** call_args = stackalloc void*[3] { &arg1, arg2, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe Vector2 godot_icall_1_6(IntPtr method, IntPtr ptr, long arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Vector2 ret;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe void godot_icall_2_7(IntPtr method, IntPtr ptr, long arg1, Vector2* arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[2] { &arg1, arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe float godot_icall_1_8(IntPtr method, IntPtr ptr, long arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double ret;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (float)ret;
    }

    internal static unsafe void godot_icall_2_9(IntPtr method, IntPtr ptr, long arg1, float arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_1_10(IntPtr method, IntPtr ptr, long arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe godot_bool godot_icall_1_11(IntPtr method, IntPtr ptr, long arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_bool ret;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe long[] godot_icall_1_12(IntPtr method, IntPtr ptr, long arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_int64_array ret = default;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertNativePackedInt64ArrayToSystemArray(ret);
    }

    internal static unsafe long[] godot_icall_0_13(IntPtr method, IntPtr ptr)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_int64_array ret = default;
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, null, &ret);
        return Marshaling.ConvertNativePackedInt64ArrayToSystemArray(ret);
    }

    internal static unsafe void godot_icall_1_14(IntPtr method, IntPtr ptr, godot_bool arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe godot_bool godot_icall_0_15(IntPtr method, IntPtr ptr)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_bool ret;
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, null, &ret);
        return ret;
    }

    internal static unsafe void godot_icall_2_16(IntPtr method, IntPtr ptr, long arg1, godot_bool arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[2] { &arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_3_17(IntPtr method, IntPtr ptr, long arg1, long arg2, godot_bool arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[3] { &arg1, &arg2, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe godot_bool godot_icall_3_18(IntPtr method, IntPtr ptr, long arg1, long arg2, godot_bool arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_bool ret;
        void** call_args = stackalloc void*[3] { &arg1, &arg2, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe long godot_icall_2_19(IntPtr method, IntPtr ptr, Vector2* arg1, godot_bool arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        void** call_args = stackalloc void*[2] { arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Vector2 godot_icall_1_20(IntPtr method, IntPtr ptr, Vector2* arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Vector2 ret;
        void** call_args = stackalloc void*[1] { arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Vector2[] godot_icall_3_21(IntPtr method, IntPtr ptr, long arg1, long arg2, godot_bool arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_vector2_array ret = default;
        void** call_args = stackalloc void*[3] { &arg1, &arg2, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertNativePackedVector2ArrayToSystemArray(ret);
    }

    internal static unsafe long[] godot_icall_3_22(IntPtr method, IntPtr ptr, long arg1, long arg2, godot_bool arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_int64_array ret = default;
        void** call_args = stackalloc void*[3] { &arg1, &arg2, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertNativePackedInt64ArrayToSystemArray(ret);
    }

    internal static unsafe Vector2[] godot_icall_2_23(IntPtr method, IntPtr ptr, long arg1, long arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_vector2_array ret = default;
        void** call_args = stackalloc void*[2] { &arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertNativePackedVector2ArrayToSystemArray(ret);
    }

    internal static unsafe long[] godot_icall_2_24(IntPtr method, IntPtr ptr, long arg1, long arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_int64_array ret = default;
        void** call_args = stackalloc void*[2] { &arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertNativePackedInt64ArrayToSystemArray(ret);
    }

    internal static unsafe void godot_icall_3_25(IntPtr method, IntPtr ptr, long arg1, Vector3* arg2, float arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double arg3_in = arg3;
        void** call_args = stackalloc void*[3] { &arg1, arg2, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe Vector3 godot_icall_1_26(IntPtr method, IntPtr ptr, long arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Vector3 ret;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe void godot_icall_2_27(IntPtr method, IntPtr ptr, long arg1, Vector3* arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[2] { &arg1, arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe long godot_icall_2_28(IntPtr method, IntPtr ptr, Vector3* arg1, godot_bool arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        void** call_args = stackalloc void*[2] { arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Vector3 godot_icall_1_29(IntPtr method, IntPtr ptr, Vector3* arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Vector3 ret;
        void** call_args = stackalloc void*[1] { arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Vector3[] godot_icall_3_30(IntPtr method, IntPtr ptr, long arg1, long arg2, godot_bool arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_vector3_array ret = default;
        void** call_args = stackalloc void*[3] { &arg1, &arg2, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertNativePackedVector3ArrayToSystemArray(ret);
    }

    internal static unsafe Vector3[] godot_icall_2_31(IntPtr method, IntPtr ptr, long arg1, long arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_vector3_array ret = default;
        void** call_args = stackalloc void*[2] { &arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertNativePackedVector3ArrayToSystemArray(ret);
    }

    internal static unsafe void godot_icall_1_32(IntPtr method, IntPtr ptr, Rect2I* arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[1] { arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe Rect2I godot_icall_0_33(IntPtr method, IntPtr ptr)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Rect2I ret;
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, null, &ret);
        return ret;
    }

    internal static unsafe void godot_icall_1_34(IntPtr method, IntPtr ptr, Vector2I* arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[1] { arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe Vector2I godot_icall_0_35(IntPtr method, IntPtr ptr)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Vector2I ret;
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, null, &ret);
        return ret;
    }

    internal static unsafe void godot_icall_1_36(IntPtr method, IntPtr ptr, Vector2* arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[1] { arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe Vector2 godot_icall_0_37(IntPtr method, IntPtr ptr)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Vector2 ret;
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, null, &ret);
        return ret;
    }

    internal static unsafe void godot_icall_1_38(IntPtr method, IntPtr ptr, int arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe int godot_icall_0_39(IntPtr method, IntPtr ptr)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, null, &ret);
        return (int)(ret);
    }

    internal static unsafe godot_bool godot_icall_2_40(IntPtr method, IntPtr ptr, int arg1, int arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_bool ret;
        long arg1_in = arg1;
        long arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe godot_bool godot_icall_1_41(IntPtr method, IntPtr ptr, Vector2I* arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_bool ret;
        void** call_args = stackalloc void*[1] { arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe void godot_icall_2_42(IntPtr method, IntPtr ptr, Vector2I* arg1, godot_bool arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[2] { arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_2_43(IntPtr method, IntPtr ptr, Vector2I* arg1, float arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double arg2_in = arg2;
        void** call_args = stackalloc void*[2] { arg1, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe float godot_icall_1_44(IntPtr method, IntPtr ptr, Vector2I* arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double ret;
        void** call_args = stackalloc void*[1] { arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (float)ret;
    }

    internal static unsafe void godot_icall_2_45(IntPtr method, IntPtr ptr, Rect2I* arg1, godot_bool arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[2] { arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_2_46(IntPtr method, IntPtr ptr, Rect2I* arg1, float arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double arg2_in = arg2;
        void** call_args = stackalloc void*[2] { arg1, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe Vector2 godot_icall_1_47(IntPtr method, IntPtr ptr, Vector2I* arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Vector2 ret;
        void** call_args = stackalloc void*[1] { arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Godot.Collections.Array godot_icall_1_48(IntPtr method, IntPtr ptr, Rect2I* arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_array ret = default;
        void** call_args = stackalloc void*[1] { arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Godot.Collections.Array.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe Vector2[] godot_icall_3_49(IntPtr method, IntPtr ptr, Vector2I* arg1, Vector2I* arg2, godot_bool arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_vector2_array ret = default;
        void** call_args = stackalloc void*[3] { arg1, arg2, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertNativePackedVector2ArrayToSystemArray(ret);
    }

    internal static unsafe Godot.Collections.Array godot_icall_3_50(IntPtr method, IntPtr ptr, Vector2I* arg1, Vector2I* arg2, godot_bool arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_array ret = default;
        void** call_args = stackalloc void*[3] { arg1, arg2, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Godot.Collections.Array.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe Vector2[] godot_icall_2_51(IntPtr method, IntPtr ptr, Vector2I* arg1, Vector2I* arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_vector2_array ret = default;
        void** call_args = stackalloc void*[2] { arg1, arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertNativePackedVector2ArrayToSystemArray(ret);
    }

    internal static unsafe Godot.Collections.Array godot_icall_2_52(IntPtr method, IntPtr ptr, Vector2I* arg1, Vector2I* arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_array ret = default;
        void** call_args = stackalloc void*[2] { arg1, arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Godot.Collections.Array.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe GodotObject godot_icall_0_53(IntPtr method, IntPtr ptr)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        IntPtr ret = default;
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, null, &ret);
        return InteropUtils.UnmanagedGetManaged(ret);
    }

    internal static unsafe GodotObject godot_icall_3_54(IntPtr method, IntPtr ptr, string arg1, godot_bool arg2, string arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        IntPtr ret = default;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        using godot_string arg3_in = Marshaling.ConvertStringToNative(arg3);
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return InteropUtils.UnmanagedGetManaged(ret);
    }

    internal static unsafe GodotObject godot_icall_1_55(IntPtr method, IntPtr ptr, string arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        IntPtr ret = default;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return InteropUtils.UnmanagedGetManaged(ret);
    }

    internal static unsafe void godot_icall_1_56(IntPtr method, IntPtr ptr, IntPtr arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_1_57(IntPtr method, IntPtr ptr, string arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe string godot_icall_0_58(IntPtr method, IntPtr ptr)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string ret = default;
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, null, &ret);
        return Marshaling.ConvertStringToManaged(ret);
    }

    internal static unsafe void godot_icall_2_59(IntPtr method, IntPtr ptr, int arg1, int arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        long arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe int godot_icall_1_60(IntPtr method, IntPtr ptr, int arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        long arg1_in = arg1;
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe void godot_icall_2_61(IntPtr method, IntPtr ptr, int arg1, godot_bool arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe godot_bool godot_icall_1_62(IntPtr method, IntPtr ptr, int arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_bool ret;
        long arg1_in = arg1;
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe GodotObject godot_icall_0_63(IntPtr method, IntPtr ptr)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_ref ret = default;
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, null, &ret);
        return InteropUtils.UnmanagedGetManaged(ret.Reference);
    }

    internal static unsafe void godot_icall_1_64(IntPtr method, IntPtr ptr, godot_string_name arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe StringName godot_icall_0_65(IntPtr method, IntPtr ptr)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_string_name ret = default;
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, null, &ret);
        return StringName.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe void godot_icall_3_66(IntPtr method, IntPtr ptr, godot_string_name arg1, float arg2, godot_bool arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double arg2_in = arg2;
        void** call_args = stackalloc void*[3] { &arg1, &arg2_in, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_1_67(IntPtr method, IntPtr ptr, float arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double arg1_in = arg1;
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe float godot_icall_0_68(IntPtr method, IntPtr ptr)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double ret;
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, null, &ret);
        return (float)ret;
    }

    internal static unsafe void godot_icall_2_69(IntPtr method, IntPtr ptr, int arg1, float arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        double arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_2_70(IntPtr method, IntPtr ptr, int arg1, IntPtr arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe GodotObject godot_icall_1_71(IntPtr method, IntPtr ptr, int arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_ref ret = default;
        long arg1_in = arg1;
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return InteropUtils.UnmanagedGetManaged(ret.Reference);
    }

    internal static unsafe float godot_icall_1_72(IntPtr method, IntPtr ptr, int arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double ret;
        long arg1_in = arg1;
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (float)ret;
    }

    internal static unsafe int godot_icall_2_73(IntPtr method, IntPtr ptr, int arg1, int arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        long arg1_in = arg1;
        long arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe NodePath godot_icall_1_74(IntPtr method, IntPtr ptr, int arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_node_path ret = default;
        long arg1_in = arg1;
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return NodePath.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe void godot_icall_2_75(IntPtr method, IntPtr ptr, int arg1, godot_node_path arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe int godot_icall_2_76(IntPtr method, IntPtr ptr, godot_node_path arg1, int arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        long arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe int godot_icall_3_77(IntPtr method, IntPtr ptr, int arg1, double arg2, Vector3* arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        long arg1_in = arg1;
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2, arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe int godot_icall_3_78(IntPtr method, IntPtr ptr, int arg1, double arg2, Quaternion* arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        long arg1_in = arg1;
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2, arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe int godot_icall_3_79(IntPtr method, IntPtr ptr, int arg1, double arg2, float arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        long arg1_in = arg1;
        double arg3_in = arg3;
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe Vector3 godot_icall_3_80(IntPtr method, IntPtr ptr, int arg1, double arg2, godot_bool arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Vector3 ret;
        long arg1_in = arg1;
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Quaternion godot_icall_3_81(IntPtr method, IntPtr ptr, int arg1, double arg2, godot_bool arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Quaternion ret;
        long arg1_in = arg1;
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe float godot_icall_3_82(IntPtr method, IntPtr ptr, int arg1, double arg2, godot_bool arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double ret;
        long arg1_in = arg1;
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (float)ret;
    }

    internal static unsafe int godot_icall_4_83(IntPtr method, IntPtr ptr, int arg1, double arg2, Variant arg3, float arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        long arg1_in = arg1;
        godot_variant arg3_in = (godot_variant)arg3.NativeVar;
        double arg4_in = arg4;
        void** call_args = stackalloc void*[4] { &arg1_in, &arg2, &arg3_in, &arg4_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe void godot_icall_2_84(IntPtr method, IntPtr ptr, int arg1, double arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_3_85(IntPtr method, IntPtr ptr, int arg1, int arg2, Variant arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        long arg2_in = arg2;
        godot_variant arg3_in = (godot_variant)arg3.NativeVar;
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2_in, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_3_86(IntPtr method, IntPtr ptr, int arg1, int arg2, float arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        long arg2_in = arg2;
        double arg3_in = arg3;
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2_in, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_3_87(IntPtr method, IntPtr ptr, int arg1, int arg2, double arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        long arg2_in = arg2;
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2_in, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe float godot_icall_2_88(IntPtr method, IntPtr ptr, int arg1, int arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double ret;
        long arg1_in = arg1;
        long arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (float)ret;
    }

    internal static unsafe Variant godot_icall_2_89(IntPtr method, IntPtr ptr, int arg1, int arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_variant ret = default;
        long arg1_in = arg1;
        long arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Variant.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe double godot_icall_2_90(IntPtr method, IntPtr ptr, int arg1, int arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double ret;
        long arg1_in = arg1;
        long arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe int godot_icall_5_91(IntPtr method, IntPtr ptr, int arg1, double arg2, int arg3, godot_bool arg4, godot_bool arg5)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        long arg1_in = arg1;
        long arg3_in = arg3;
        void** call_args = stackalloc void*[5] { &arg1_in, &arg2, &arg3_in, &arg4, &arg5 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe Variant godot_icall_3_92(IntPtr method, IntPtr ptr, int arg1, double arg2, godot_bool arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_variant ret = default;
        long arg1_in = arg1;
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Variant.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe StringName godot_icall_2_93(IntPtr method, IntPtr ptr, int arg1, int arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_string_name ret = default;
        long arg1_in = arg1;
        long arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return StringName.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe Godot.Collections.Array godot_icall_2_94(IntPtr method, IntPtr ptr, int arg1, int arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_array ret = default;
        long arg1_in = arg1;
        long arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Godot.Collections.Array.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe int godot_icall_5_95(IntPtr method, IntPtr ptr, int arg1, double arg2, float arg3, Vector2* arg4, Vector2* arg5)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        long arg1_in = arg1;
        double arg3_in = arg3;
        void** call_args = stackalloc void*[5] { &arg1_in, &arg2, &arg3_in, arg4, arg5 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe void godot_icall_4_96(IntPtr method, IntPtr ptr, int arg1, int arg2, Vector2* arg3, float arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        long arg2_in = arg2;
        double arg4_in = arg4;
        void** call_args = stackalloc void*[4] { &arg1_in, &arg2_in, arg3, &arg4_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe Vector2 godot_icall_2_97(IntPtr method, IntPtr ptr, int arg1, int arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Vector2 ret;
        long arg1_in = arg1;
        long arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe float godot_icall_2_98(IntPtr method, IntPtr ptr, int arg1, double arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double ret;
        long arg1_in = arg1;
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (float)ret;
    }

    internal static unsafe int godot_icall_5_99(IntPtr method, IntPtr ptr, int arg1, double arg2, IntPtr arg3, float arg4, float arg5)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        long arg1_in = arg1;
        double arg4_in = arg4;
        double arg5_in = arg5;
        void** call_args = stackalloc void*[5] { &arg1_in, &arg2, &arg3, &arg4_in, &arg5_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe void godot_icall_3_100(IntPtr method, IntPtr ptr, int arg1, int arg2, IntPtr arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        long arg2_in = arg2;
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2_in, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe GodotObject godot_icall_2_101(IntPtr method, IntPtr ptr, int arg1, int arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_ref ret = default;
        long arg1_in = arg1;
        long arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return InteropUtils.UnmanagedGetManaged(ret.Reference);
    }

    internal static unsafe int godot_icall_3_102(IntPtr method, IntPtr ptr, int arg1, double arg2, godot_string_name arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        long arg1_in = arg1;
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe void godot_icall_3_103(IntPtr method, IntPtr ptr, int arg1, int arg2, godot_string_name arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        long arg2_in = arg2;
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2_in, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_2_104(IntPtr method, IntPtr ptr, godot_string_name arg1, double arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[2] { &arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe godot_bool godot_icall_1_105(IntPtr method, IntPtr ptr, godot_string_name arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_bool ret;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe StringName godot_icall_1_106(IntPtr method, IntPtr ptr, double arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_string_name ret = default;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return StringName.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe double godot_icall_1_107(IntPtr method, IntPtr ptr, godot_string_name arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double ret;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe string[] godot_icall_0_108(IntPtr method, IntPtr ptr)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_string_array ret = default;
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, null, &ret);
        return Marshaling.ConvertNativePackedStringArrayToSystemArray(ret);
    }

    internal static unsafe Color godot_icall_1_109(IntPtr method, IntPtr ptr, godot_string_name arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Color ret;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe void godot_icall_2_110(IntPtr method, IntPtr ptr, godot_string_name arg1, Color* arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[2] { &arg1, arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_3_111(IntPtr method, IntPtr ptr, float arg1, float arg2, int arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double arg1_in = arg1;
        double arg2_in = arg2;
        long arg3_in = arg3;
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2_in, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_3_112(IntPtr method, IntPtr ptr, uint arg1, uint arg2, float arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        long arg2_in = arg2;
        double arg3_in = arg3;
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2_in, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe int godot_icall_3_113(IntPtr method, IntPtr ptr, int arg1, double arg2, int arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        long arg1_in = arg1;
        long arg3_in = arg3;
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe Variant godot_icall_2_114(IntPtr method, IntPtr ptr, int arg1, double arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_variant ret = default;
        long arg1_in = arg1;
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Variant.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe Vector3 godot_icall_2_115(IntPtr method, IntPtr ptr, int arg1, double arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Vector3 ret;
        long arg1_in = arg1;
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Quaternion godot_icall_2_116(IntPtr method, IntPtr ptr, int arg1, double arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Quaternion ret;
        long arg1_in = arg1;
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe int godot_icall_2_117(IntPtr method, IntPtr ptr, godot_string_name arg1, IntPtr arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        void** call_args = stackalloc void*[2] { &arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe void godot_icall_2_118(IntPtr method, IntPtr ptr, godot_string_name arg1, godot_string_name arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[2] { &arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe GodotObject godot_icall_1_119(IntPtr method, IntPtr ptr, godot_string_name arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_ref ret = default;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return InteropUtils.UnmanagedGetManaged(ret.Reference);
    }

    internal static unsafe Godot.Collections.Array godot_icall_0_120(IntPtr method, IntPtr ptr)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_array ret = default;
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, null, &ret);
        return Godot.Collections.Array.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe void godot_icall_1_121(IntPtr method, IntPtr ptr, godot_dictionary arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe Godot.Collections.Dictionary godot_icall_0_122(IntPtr method, IntPtr ptr)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_dictionary ret = default;
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, null, &ret);
        return Godot.Collections.Dictionary.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe void godot_icall_1_123(IntPtr method, IntPtr ptr, godot_node_path arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe NodePath godot_icall_0_124(IntPtr method, IntPtr ptr)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_node_path ret = default;
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, null, &ret);
        return NodePath.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe Vector3 godot_icall_0_125(IntPtr method, IntPtr ptr)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Vector3 ret;
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, null, &ret);
        return ret;
    }

    internal static unsafe Quaternion godot_icall_0_126(IntPtr method, IntPtr ptr)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Quaternion ret;
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, null, &ret);
        return ret;
    }

    internal static unsafe void godot_icall_1_127(IntPtr method, IntPtr ptr, double arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_4_128(IntPtr method, IntPtr ptr, godot_string_name arg1, double arg2, int arg3, int arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg3_in = arg3;
        long arg4_in = arg4;
        void** call_args = stackalloc void*[4] { &arg1, &arg2, &arg3_in, &arg4_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe StringName godot_icall_1_129(IntPtr method, IntPtr ptr, IntPtr arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_string_name ret = default;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return StringName.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe Variant godot_icall_5_130(IntPtr method, IntPtr ptr, IntPtr arg1, int arg2, Variant arg3, IntPtr arg4, int arg5)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_variant ret = default;
        long arg2_in = arg2;
        godot_variant arg3_in = (godot_variant)arg3.NativeVar;
        long arg5_in = arg5;
        void** call_args = stackalloc void*[5] { &arg1, &arg2_in, &arg3_in, &arg4, &arg5_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Variant.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe godot_bool godot_icall_1_131(IntPtr method, IntPtr ptr, string arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_bool ret;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe godot_bool godot_icall_2_132(IntPtr method, IntPtr ptr, int arg1, string arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_bool ret;
        long arg1_in = arg1;
        using godot_string arg2_in = Marshaling.ConvertStringToNative(arg2);
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe string godot_icall_1_133(IntPtr method, IntPtr ptr, int arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string ret = default;
        long arg1_in = arg1;
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertStringToManaged(ret);
    }

    internal static unsafe int godot_icall_1_134(IntPtr method, IntPtr ptr, string arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe void godot_icall_2_135(IntPtr method, IntPtr ptr, godot_node_path arg1, godot_bool arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[2] { &arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe godot_bool godot_icall_1_136(IntPtr method, IntPtr ptr, godot_node_path arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_bool ret;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe ulong godot_icall_0_137(IntPtr method, IntPtr ptr)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        ulong ret;
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, null, &ret);
        return ret;
    }

    internal static unsafe void godot_icall_1_138(IntPtr method, IntPtr ptr, godot_array arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_7_139(IntPtr method, IntPtr ptr, godot_string_name arg1, double arg2, double arg3, godot_bool arg4, godot_bool arg5, float arg6, int arg7)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double arg6_in = arg6;
        long arg7_in = arg7;
        void** call_args = stackalloc void*[7] { &arg1, &arg2, &arg3, &arg4, &arg5, &arg6_in, &arg7_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe double godot_icall_9_140(IntPtr method, IntPtr ptr, godot_string_name arg1, IntPtr arg2, double arg3, godot_bool arg4, godot_bool arg5, float arg6, int arg7, godot_bool arg8, godot_bool arg9)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double ret;
        double arg6_in = arg6;
        long arg7_in = arg7;
        void** call_args = stackalloc void*[9] { &arg1, &arg2, &arg3, &arg4, &arg5, &arg6_in, &arg7_in, &arg8, &arg9 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe double godot_icall_8_141(IntPtr method, IntPtr ptr, int arg1, double arg2, godot_bool arg3, godot_bool arg4, float arg5, int arg6, godot_bool arg7, godot_bool arg8)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double ret;
        long arg1_in = arg1;
        double arg5_in = arg5;
        long arg6_in = arg6;
        void** call_args = stackalloc void*[8] { &arg1_in, &arg2, &arg3, &arg4, &arg5_in, &arg6_in, &arg7, &arg8 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe void godot_icall_2_142(IntPtr method, IntPtr ptr, godot_string_name arg1, Variant arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_variant arg2_in = (godot_variant)arg2.NativeVar;
        void** call_args = stackalloc void*[2] { &arg1, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe Variant godot_icall_1_143(IntPtr method, IntPtr ptr, godot_string_name arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_variant ret = default;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Variant.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe double godot_icall_0_144(IntPtr method, IntPtr ptr)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double ret;
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, null, &ret);
        return ret;
    }

    internal static unsafe void godot_icall_3_145(IntPtr method, IntPtr ptr, IntPtr arg1, float arg2, int arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double arg2_in = arg2;
        long arg3_in = arg3;
        void** call_args = stackalloc void*[3] { &arg1, &arg2_in, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_3_146(IntPtr method, IntPtr ptr, IntPtr arg1, Vector2* arg2, int arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg3_in = arg3;
        void** call_args = stackalloc void*[3] { &arg1, arg2, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_2_147(IntPtr method, IntPtr ptr, int arg1, Vector2* arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        void** call_args = stackalloc void*[2] { &arg1_in, arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe Vector2 godot_icall_1_148(IntPtr method, IntPtr ptr, int arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Vector2 ret;
        long arg1_in = arg1;
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe void godot_icall_4_149(IntPtr method, IntPtr ptr, int arg1, int arg2, int arg3, int arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        long arg2_in = arg2;
        long arg3_in = arg3;
        long arg4_in = arg4;
        void** call_args = stackalloc void*[4] { &arg1_in, &arg2_in, &arg3_in, &arg4_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_1_150(IntPtr method, IntPtr ptr, ReadOnlySpan<int> arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_int32_array arg1_in = Marshaling.ConvertSystemArrayToNativePackedInt32Array(arg1);
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe int[] godot_icall_0_151(IntPtr method, IntPtr ptr)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_int32_array ret = default;
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, null, &ret);
        return Marshaling.ConvertNativePackedInt32ArrayToSystemArray(ret);
    }

    internal static unsafe void godot_icall_3_152(IntPtr method, IntPtr ptr, godot_string_name arg1, IntPtr arg2, Vector2* arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[3] { &arg1, &arg2, arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_3_153(IntPtr method, IntPtr ptr, godot_string_name arg1, int arg2, godot_string_name arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg2_in = arg2;
        void** call_args = stackalloc void*[3] { &arg1, &arg2_in, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_2_154(IntPtr method, IntPtr ptr, godot_string_name arg1, int arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_2_155(IntPtr method, IntPtr ptr, godot_string_name arg1, Vector2* arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[2] { &arg1, arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe Vector2 godot_icall_1_156(IntPtr method, IntPtr ptr, godot_string_name arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Vector2 ret;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe godot_bool godot_icall_1_157(IntPtr method, ReadOnlySpan<float> arg1)
    {
        godot_bool ret;
        using godot_packed_float32_array arg1_in = Marshaling.ConvertSystemArrayToNativePackedFloat32Array(arg1);
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, IntPtr.Zero, call_args, &ret);
        return ret;
    }

    internal static unsafe double godot_icall_2_158(IntPtr method, ReadOnlySpan<float> arg1, godot_bool arg2)
    {
        double ret;
        using godot_packed_float32_array arg1_in = Marshaling.ConvertSystemArrayToNativePackedFloat32Array(arg1);
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, IntPtr.Zero, call_args, &ret);
        return ret;
    }

    internal static unsafe void godot_icall_2_159(IntPtr method, IntPtr ptr, godot_string_name arg1, IntPtr arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[2] { &arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe godot_bool godot_icall_2_160(IntPtr method, IntPtr ptr, godot_string_name arg1, godot_string_name arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_bool ret;
        void** call_args = stackalloc void*[2] { &arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe void godot_icall_3_161(IntPtr method, IntPtr ptr, godot_string_name arg1, godot_string_name arg2, IntPtr arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[3] { &arg1, &arg2, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe StringName godot_icall_1_162(IntPtr method, IntPtr ptr, int arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_string_name ret = default;
        long arg1_in = arg1;
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return StringName.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe void godot_icall_2_163(IntPtr method, IntPtr ptr, godot_string_name arg1, godot_bool arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[2] { &arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe StringName godot_icall_1_164(IntPtr method, IntPtr ptr, godot_string_name arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_string_name ret = default;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return StringName.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe void godot_icall_3_165(IntPtr method, IntPtr ptr, godot_string_name arg1, godot_string_name arg2, double arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[3] { &arg1, &arg2, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe double godot_icall_2_166(IntPtr method, IntPtr ptr, godot_string_name arg1, godot_string_name arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double ret;
        void** call_args = stackalloc void*[2] { &arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe void godot_icall_4_167(IntPtr method, IntPtr ptr, godot_string_name arg1, double arg2, float arg3, godot_bool arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double arg3_in = arg3;
        void** call_args = stackalloc void*[4] { &arg1, &arg2, &arg3_in, &arg4 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_6_168(IntPtr method, IntPtr ptr, godot_string_name arg1, godot_string_name arg2, godot_string_name arg3, double arg4, float arg5, godot_bool arg6)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double arg5_in = arg5;
        void** call_args = stackalloc void*[6] { &arg1, &arg2, &arg3, &arg4, &arg5_in, &arg6 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_6_169(IntPtr method, IntPtr ptr, godot_string_name arg1, double arg2, double arg3, double arg4, float arg5, godot_bool arg6)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double arg5_in = arg5;
        void** call_args = stackalloc void*[6] { &arg1, &arg2, &arg3, &arg4, &arg5_in, &arg6 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_4_170(IntPtr method, IntPtr ptr, godot_string_name arg1, godot_string_name arg2, godot_string_name arg3, double arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[4] { &arg1, &arg2, &arg3, &arg4 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_4_171(IntPtr method, IntPtr ptr, godot_string_name arg1, double arg2, double arg3, double arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[4] { &arg1, &arg2, &arg3, &arg4 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_7_172(IntPtr method, IntPtr ptr, godot_string_name arg1, double arg2, double arg3, float arg4, godot_bool arg5, int arg6, int arg7)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double arg4_in = arg4;
        long arg6_in = arg6;
        long arg7_in = arg7;
        void** call_args = stackalloc void*[7] { &arg1, &arg2, &arg3, &arg4_in, &arg5, &arg6_in, &arg7_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_2_173(IntPtr method, IntPtr ptr, double arg1, double arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[2] { &arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_3_174(IntPtr method, IntPtr ptr, double arg1, godot_bool arg2, godot_bool arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[3] { &arg1, &arg2, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_2_175(IntPtr method, IntPtr ptr, double arg1, godot_bool arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[2] { &arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe godot_bool godot_icall_1_176(IntPtr method, IntPtr ptr, IntPtr arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_bool ret;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe void godot_icall_1_177(IntPtr method, IntPtr ptr, Vector3* arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[1] { arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_2_178(IntPtr method, IntPtr ptr, int arg1, godot_string_name arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_5_179(IntPtr method, IntPtr ptr, int arg1, godot_array arg2, godot_array arg3, godot_dictionary arg4, int arg5)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        long arg5_in = arg5;
        void** call_args = stackalloc void*[5] { &arg1_in, &arg2, &arg3, &arg4, &arg5_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_3_180(IntPtr method, IntPtr ptr, int arg1, int arg2, ReadOnlySpan<byte> arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        long arg2_in = arg2;
        using godot_packed_byte_array arg3_in = Marshaling.ConvertSystemArrayToNativePackedByteArray(arg3);
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2_in, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_2_181(IntPtr method, IntPtr ptr, int arg1, string arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        using godot_string arg2_in = Marshaling.ConvertStringToNative(arg2);
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe int godot_icall_2_182(IntPtr method, IntPtr ptr, Transform3D* arg1, float arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        double arg2_in = arg2;
        void** call_args = stackalloc void*[2] { arg1, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe void godot_icall_1_183(IntPtr method, IntPtr ptr, Aabb* arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[1] { arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe Aabb godot_icall_0_184(IntPtr method, IntPtr ptr)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Aabb ret;
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, null, &ret);
        return ret;
    }

    internal static unsafe void godot_icall_1_185(IntPtr method, IntPtr ptr, ReadOnlySpan<string> arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_string_array arg1_in = Marshaling.ConvertSystemArrayToNativePackedStringArray(arg1);
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_2_186(IntPtr method, IntPtr ptr, ReadOnlySpan<Vector3> arg1, ReadOnlySpan<int> arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_vector3_array arg1_in = Marshaling.ConvertSystemArrayToNativePackedVector3Array(arg1);
        using godot_packed_int32_array arg2_in = Marshaling.ConvertSystemArrayToNativePackedInt32Array(arg2);
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_1_187(IntPtr method, IntPtr ptr, ReadOnlySpan<Vector3> arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_vector3_array arg1_in = Marshaling.ConvertSystemArrayToNativePackedVector3Array(arg1);
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_1_188(IntPtr method, IntPtr ptr, Rect2* arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[1] { arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe Rect2 godot_icall_0_189(IntPtr method, IntPtr ptr)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Rect2 ret;
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, null, &ret);
        return ret;
    }

    internal static unsafe Vector2[] godot_icall_1_190(IntPtr method, IntPtr ptr, int arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_vector2_array ret = default;
        long arg1_in = arg1;
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertNativePackedVector2ArrayToSystemArray(ret);
    }

    internal static unsafe Vector2 godot_icall_3_191(IntPtr method, IntPtr ptr, float arg1, float arg2, int arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Vector2 ret;
        double arg1_in = arg1;
        double arg2_in = arg2;
        long arg3_in = arg3;
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2_in, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Transform3D godot_icall_0_192(IntPtr method, IntPtr ptr)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Transform3D ret;
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, null, &ret);
        return ret;
    }

    internal static unsafe int godot_icall_1_193(IntPtr method, IntPtr ptr, godot_string_name arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe void godot_icall_3_194(IntPtr method, IntPtr ptr, int arg1, IntPtr arg2, int arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        long arg3_in = arg3;
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe GodotObject godot_icall_3_195(IntPtr method, IntPtr ptr, int arg1, int arg2, int arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_ref ret = default;
        long arg1_in = arg1;
        long arg2_in = arg2;
        long arg3_in = arg3;
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2_in, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return InteropUtils.UnmanagedGetManaged(ret.Reference);
    }

    internal static unsafe void godot_icall_3_196(IntPtr method, IntPtr ptr, int arg1, int arg2, int arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        long arg2_in = arg2;
        long arg3_in = arg3;
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2_in, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_3_197(IntPtr method, IntPtr ptr, int arg1, int arg2, godot_bool arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        long arg2_in = arg2;
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2_in, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe int godot_icall_1_198(IntPtr method, IntPtr ptr, godot_bool arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe godot_bool godot_icall_1_199(IntPtr method, IntPtr ptr, Vector2* arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_bool ret;
        void** call_args = stackalloc void*[1] { arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe godot_bool godot_icall_1_200(IntPtr method, IntPtr ptr, ReadOnlySpan<Vector2> arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_bool ret;
        using godot_packed_vector2_array arg1_in = Marshaling.ConvertSystemArrayToNativePackedVector2Array(arg1);
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe void godot_icall_9_201(IntPtr method, IntPtr ptr, int arg1, int arg2, int arg3, int arg4, int arg5, float arg6, godot_bool arg7, int arg8, godot_bool arg9)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        long arg2_in = arg2;
        long arg3_in = arg3;
        long arg4_in = arg4;
        long arg5_in = arg5;
        double arg6_in = arg6;
        long arg8_in = arg8;
        void** call_args = stackalloc void*[9] { &arg1_in, &arg2_in, &arg3_in, &arg4_in, &arg5_in, &arg6_in, &arg7, &arg8_in, &arg9 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe GodotObject godot_icall_1_202(IntPtr method, ReadOnlySpan<byte> arg1)
    {
        using godot_ref ret = default;
        using godot_packed_byte_array arg1_in = Marshaling.ConvertSystemArrayToNativePackedByteArray(arg1);
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, IntPtr.Zero, call_args, &ret);
        return InteropUtils.UnmanagedGetManaged(ret.Reference);
    }

    internal static unsafe GodotObject godot_icall_1_203(IntPtr method, string arg1)
    {
        using godot_ref ret = default;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, IntPtr.Zero, call_args, &ret);
        return InteropUtils.UnmanagedGetManaged(ret.Reference);
    }

    internal static unsafe void godot_icall_1_204(IntPtr method, IntPtr ptr, ReadOnlySpan<byte> arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_byte_array arg1_in = Marshaling.ConvertSystemArrayToNativePackedByteArray(arg1);
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe Vector2[] godot_icall_2_205(IntPtr method, IntPtr ptr, float arg1, int arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_vector2_array ret = default;
        double arg1_in = arg1;
        long arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertNativePackedVector2ArrayToSystemArray(ret);
    }

    internal static unsafe long godot_icall_6_206(IntPtr method, IntPtr ptr, IntPtr arg1, float arg2, float arg3, float arg4, int arg5, godot_string_name arg6)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        double arg2_in = arg2;
        double arg3_in = arg3;
        double arg4_in = arg4;
        long arg5_in = arg5;
        void** call_args = stackalloc void*[6] { &arg1, &arg2_in, &arg3_in, &arg4_in, &arg5_in, &arg6 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe long godot_icall_4_207(IntPtr method, IntPtr ptr, IntPtr arg1, float arg2, float arg3, float arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        double arg2_in = arg2;
        double arg3_in = arg3;
        double arg4_in = arg4;
        void** call_args = stackalloc void*[4] { &arg1, &arg2_in, &arg3_in, &arg4_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe void godot_icall_1_208(IntPtr method, IntPtr ptr, uint arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe uint godot_icall_0_209(IntPtr method, IntPtr ptr)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, null, &ret);
        return (uint)(ret);
    }

    internal static unsafe void godot_icall_3_210(IntPtr method, IntPtr ptr, int arg1, IntPtr arg2, float arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        double arg3_in = arg3;
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe GodotObject godot_icall_2_211(IntPtr method, ReadOnlySpan<byte> arg1, godot_dictionary arg2)
    {
        using godot_ref ret = default;
        using godot_packed_byte_array arg1_in = Marshaling.ConvertSystemArrayToNativePackedByteArray(arg1);
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, IntPtr.Zero, call_args, &ret);
        return InteropUtils.UnmanagedGetManaged(ret.Reference);
    }

    internal static unsafe GodotObject godot_icall_2_212(IntPtr method, string arg1, godot_dictionary arg2)
    {
        using godot_ref ret = default;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, IntPtr.Zero, call_args, &ret);
        return InteropUtils.UnmanagedGetManaged(ret.Reference);
    }

    internal static unsafe void godot_icall_1_213(IntPtr method, IntPtr ptr, Color* arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[1] { arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe Color godot_icall_0_214(IntPtr method, IntPtr ptr)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Color ret;
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, null, &ret);
        return ret;
    }

    internal static unsafe void godot_icall_2_215(IntPtr method, IntPtr ptr, IntPtr arg1, float arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_2_216(IntPtr method, IntPtr ptr, int arg1, Rect2I* arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        void** call_args = stackalloc void*[2] { &arg1_in, arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe Godot.Collections.Array godot_icall_2_217(IntPtr method, IntPtr ptr, Rect2I* arg1, float arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_array ret = default;
        double arg2_in = arg2;
        void** call_args = stackalloc void*[2] { arg1, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Godot.Collections.Array.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe void godot_icall_1_218(IntPtr method, IntPtr ptr, Transform2D* arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[1] { arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe Transform2D godot_icall_0_219(IntPtr method, IntPtr ptr)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Transform2D ret;
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, null, &ret);
        return ret;
    }

    internal static unsafe void godot_icall_2_220(IntPtr method, IntPtr ptr, int arg1, Quaternion* arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        void** call_args = stackalloc void*[2] { &arg1_in, arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe Quaternion godot_icall_1_221(IntPtr method, IntPtr ptr, int arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Quaternion ret;
        long arg1_in = arg1;
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe string godot_icall_2_222(IntPtr method, IntPtr ptr, int arg1, int arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string ret = default;
        long arg1_in = arg1;
        long arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertStringToManaged(ret);
    }

    internal static unsafe GodotObject godot_icall_1_223(IntPtr method, IntPtr ptr, godot_bool arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        IntPtr ret = default;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return InteropUtils.UnmanagedGetManaged(ret);
    }

    internal static unsafe void godot_icall_1_224(IntPtr method, IntPtr ptr, ReadOnlySpan<Vector2> arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_vector2_array arg1_in = Marshaling.ConvertSystemArrayToNativePackedVector2Array(arg1);
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe Vector2[] godot_icall_0_225(IntPtr method, IntPtr ptr)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_vector2_array ret = default;
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, null, &ret);
        return Marshaling.ConvertNativePackedVector2ArrayToSystemArray(ret);
    }

    internal static unsafe void godot_icall_1_226(IntPtr method, IntPtr ptr, ReadOnlySpan<Color> arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_color_array arg1_in = Marshaling.ConvertSystemArrayToNativePackedColorArray(arg1);
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe Color[] godot_icall_0_227(IntPtr method, IntPtr ptr)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_color_array ret = default;
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, null, &ret);
        return Marshaling.ConvertNativePackedColorArrayToSystemArray(ret);
    }

    internal static unsafe Vector3[] godot_icall_0_228(IntPtr method, IntPtr ptr)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_vector3_array ret = default;
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, null, &ret);
        return Marshaling.ConvertNativePackedVector3ArrayToSystemArray(ret);
    }

    internal static unsafe Variant godot_icall_1_229(IntPtr method, IntPtr ptr, ReadOnlySpan<Variant> arg1, godot_string_name caller)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        int vararg_length = arg1.Length;
        int total_length = 0 + vararg_length;
        Span<godot_variant.movable> varargs_span = vararg_length <= VarArgsSpanThreshold ?
            stackalloc godot_variant.movable[VarArgsSpanThreshold] :
            new godot_variant.movable[vararg_length];
        Span<IntPtr> call_args_span = total_length <= VarArgsSpanThreshold ?
            stackalloc IntPtr[VarArgsSpanThreshold] :
            new IntPtr[total_length];
        fixed (godot_variant.movable* varargs = &MemoryMarshal.GetReference(varargs_span))
        fixed (IntPtr* call_args = &MemoryMarshal.GetReference(call_args_span))
        {
            for (int i = 0; i < vararg_length; i++)
            {
                varargs[i] = arg1[i].NativeVar;
                call_args[0 + i] = new IntPtr(&varargs[i]);
            }
            godot_variant ret = NativeFuncs.godotsharp_method_bind_call(method, ptr, (godot_variant**)call_args, total_length, out godot_variant_call_error vcall_error);
            ExceptionUtils.DebugCheckCallError(caller, ptr, (godot_variant**)call_args, total_length, vcall_error);
            return Variant.CreateTakingOwnershipOfDisposableValue(ret);
        }
    }

    internal static unsafe GodotObject godot_icall_1_230(IntPtr method, IntPtr ptr, double arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_ref ret = default;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return InteropUtils.UnmanagedGetManaged(ret.Reference);
    }

    internal static unsafe Vector3 godot_icall_1_231(IntPtr method, IntPtr ptr, Vector2* arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Vector3 ret;
        void** call_args = stackalloc void*[1] { arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Vector2 godot_icall_1_232(IntPtr method, IntPtr ptr, Vector3* arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Vector2 ret;
        void** call_args = stackalloc void*[1] { arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe godot_bool godot_icall_1_233(IntPtr method, IntPtr ptr, Vector3* arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_bool ret;
        void** call_args = stackalloc void*[1] { arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Vector3 godot_icall_2_234(IntPtr method, IntPtr ptr, Vector2* arg1, float arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Vector3 ret;
        double arg2_in = arg2;
        void** call_args = stackalloc void*[2] { arg1, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe void godot_icall_3_235(IntPtr method, IntPtr ptr, float arg1, float arg2, float arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double arg1_in = arg1;
        double arg2_in = arg2;
        double arg3_in = arg3;
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2_in, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_4_236(IntPtr method, IntPtr ptr, float arg1, Vector2* arg2, float arg3, float arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double arg1_in = arg1;
        double arg3_in = arg3;
        double arg4_in = arg4;
        void** call_args = stackalloc void*[4] { &arg1_in, arg2, &arg3_in, &arg4_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe Projection godot_icall_0_237(IntPtr method, IntPtr ptr)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Projection ret;
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, null, &ret);
        return ret;
    }

    internal static unsafe Rid godot_icall_0_238(IntPtr method, IntPtr ptr)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Rid ret;
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, null, &ret);
        return ret;
    }

    internal static unsafe void godot_icall_2_239(IntPtr method, IntPtr ptr, IntPtr arg1, IntPtr arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[2] { &arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe ulong godot_icall_1_240(IntPtr method, IntPtr ptr, int arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        ulong ret;
        long arg1_in = arg1;
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe godot_bool godot_icall_2_241(IntPtr method, IntPtr ptr, int arg1, godot_dictionary arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_bool ret;
        long arg1_in = arg1;
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe void godot_icall_5_242(IntPtr method, IntPtr ptr, Vector2* arg1, Vector2* arg2, Color* arg3, float arg4, godot_bool arg5)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double arg4_in = arg4;
        void** call_args = stackalloc void*[5] { arg1, arg2, arg3, &arg4_in, &arg5 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_7_243(IntPtr method, IntPtr ptr, Vector2* arg1, Vector2* arg2, Color* arg3, float arg4, float arg5, godot_bool arg6, godot_bool arg7)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double arg4_in = arg4;
        double arg5_in = arg5;
        void** call_args = stackalloc void*[7] { arg1, arg2, arg3, &arg4_in, &arg5_in, &arg6, &arg7 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_4_244(IntPtr method, IntPtr ptr, ReadOnlySpan<Vector2> arg1, Color* arg2, float arg3, godot_bool arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_vector2_array arg1_in = Marshaling.ConvertSystemArrayToNativePackedVector2Array(arg1);
        double arg3_in = arg3;
        void** call_args = stackalloc void*[4] { &arg1_in, arg2, &arg3_in, &arg4 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_4_245(IntPtr method, IntPtr ptr, ReadOnlySpan<Vector2> arg1, ReadOnlySpan<Color> arg2, float arg3, godot_bool arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_vector2_array arg1_in = Marshaling.ConvertSystemArrayToNativePackedVector2Array(arg1);
        using godot_packed_color_array arg2_in = Marshaling.ConvertSystemArrayToNativePackedColorArray(arg2);
        double arg3_in = arg3;
        void** call_args = stackalloc void*[4] { &arg1_in, &arg2_in, &arg3_in, &arg4 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_9_246(IntPtr method, IntPtr ptr, Vector2* arg1, float arg2, float arg3, float arg4, float arg5, int arg6, Color* arg7, float arg8, godot_bool arg9)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double arg2_in = arg2;
        double arg3_in = arg3;
        double arg4_in = arg4;
        double arg5_in = arg5;
        long arg6_in = arg6;
        double arg8_in = arg8;
        void** call_args = stackalloc void*[9] { arg1, &arg2_in, &arg3_in, &arg4_in, &arg5_in, &arg6_in, arg7, &arg8_in, &arg9 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_8_247(IntPtr method, IntPtr ptr, Vector2* arg1, float arg2, float arg3, float arg4, int arg5, Color* arg6, float arg7, godot_bool arg8)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double arg2_in = arg2;
        double arg3_in = arg3;
        double arg4_in = arg4;
        long arg5_in = arg5;
        double arg7_in = arg7;
        void** call_args = stackalloc void*[8] { arg1, &arg2_in, &arg3_in, &arg4_in, &arg5_in, arg6, &arg7_in, &arg8 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_5_248(IntPtr method, IntPtr ptr, Rect2* arg1, Color* arg2, godot_bool arg3, float arg4, godot_bool arg5)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double arg4_in = arg4;
        void** call_args = stackalloc void*[5] { arg1, arg2, &arg3, &arg4_in, &arg5 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_6_249(IntPtr method, IntPtr ptr, Vector2* arg1, float arg2, Color* arg3, godot_bool arg4, float arg5, godot_bool arg6)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double arg2_in = arg2;
        double arg5_in = arg5;
        void** call_args = stackalloc void*[6] { arg1, &arg2_in, arg3, &arg4, &arg5_in, &arg6 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_7_250(IntPtr method, IntPtr ptr, Vector2* arg1, float arg2, float arg3, Color* arg4, godot_bool arg5, float arg6, godot_bool arg7)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double arg2_in = arg2;
        double arg3_in = arg3;
        double arg6_in = arg6;
        void** call_args = stackalloc void*[7] { arg1, &arg2_in, &arg3_in, arg4, &arg5, &arg6_in, &arg7 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_3_251(IntPtr method, IntPtr ptr, IntPtr arg1, Vector2* arg2, Color* arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[3] { &arg1, arg2, arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_5_252(IntPtr method, IntPtr ptr, IntPtr arg1, Rect2* arg2, godot_bool arg3, Color* arg4, godot_bool arg5)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[5] { &arg1, arg2, &arg3, arg4, &arg5 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_6_253(IntPtr method, IntPtr ptr, IntPtr arg1, Rect2* arg2, Rect2* arg3, Color* arg4, godot_bool arg5, godot_bool arg6)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[6] { &arg1, arg2, arg3, arg4, &arg5, &arg6 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_7_254(IntPtr method, IntPtr ptr, IntPtr arg1, Rect2* arg2, Rect2* arg3, Color* arg4, double arg5, double arg6, double arg7)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[7] { &arg1, arg2, arg3, arg4, &arg5, &arg6, &arg7 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_4_255(IntPtr method, IntPtr ptr, IntPtr arg1, Rect2* arg2, Rect2* arg3, Color* arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[4] { &arg1, arg2, arg3, arg4 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_2_256(IntPtr method, IntPtr ptr, IntPtr arg1, Rect2* arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[2] { &arg1, arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_4_257(IntPtr method, IntPtr ptr, ReadOnlySpan<Vector2> arg1, ReadOnlySpan<Color> arg2, ReadOnlySpan<Vector2> arg3, IntPtr arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_vector2_array arg1_in = Marshaling.ConvertSystemArrayToNativePackedVector2Array(arg1);
        using godot_packed_color_array arg2_in = Marshaling.ConvertSystemArrayToNativePackedColorArray(arg2);
        using godot_packed_vector2_array arg3_in = Marshaling.ConvertSystemArrayToNativePackedVector2Array(arg3);
        void** call_args = stackalloc void*[4] { &arg1_in, &arg2_in, &arg3_in, &arg4 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_4_258(IntPtr method, IntPtr ptr, ReadOnlySpan<Vector2> arg1, Color* arg2, ReadOnlySpan<Vector2> arg3, IntPtr arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_vector2_array arg1_in = Marshaling.ConvertSystemArrayToNativePackedVector2Array(arg1);
        using godot_packed_vector2_array arg3_in = Marshaling.ConvertSystemArrayToNativePackedVector2Array(arg3);
        void** call_args = stackalloc void*[4] { &arg1_in, arg2, &arg3_in, &arg4 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_11_259(IntPtr method, IntPtr ptr, IntPtr arg1, Vector2* arg2, string arg3, int arg4, float arg5, int arg6, Color* arg7, int arg8, int arg9, int arg10, float arg11)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string arg3_in = Marshaling.ConvertStringToNative(arg3);
        long arg4_in = arg4;
        double arg5_in = arg5;
        long arg6_in = arg6;
        long arg8_in = arg8;
        long arg9_in = arg9;
        long arg10_in = arg10;
        double arg11_in = arg11;
        void** call_args = stackalloc void*[11] { &arg1, arg2, &arg3_in, &arg4_in, &arg5_in, &arg6_in, arg7, &arg8_in, &arg9_in, &arg10_in, &arg11_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_13_260(IntPtr method, IntPtr ptr, IntPtr arg1, Vector2* arg2, string arg3, int arg4, float arg5, int arg6, int arg7, Color* arg8, int arg9, int arg10, int arg11, int arg12, float arg13)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string arg3_in = Marshaling.ConvertStringToNative(arg3);
        long arg4_in = arg4;
        double arg5_in = arg5;
        long arg6_in = arg6;
        long arg7_in = arg7;
        long arg9_in = arg9;
        long arg10_in = arg10;
        long arg11_in = arg11;
        long arg12_in = arg12;
        double arg13_in = arg13;
        void** call_args = stackalloc void*[13] { &arg1, arg2, &arg3_in, &arg4_in, &arg5_in, &arg6_in, &arg7_in, arg8, &arg9_in, &arg10_in, &arg11_in, &arg12_in, &arg13_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_12_261(IntPtr method, IntPtr ptr, IntPtr arg1, Vector2* arg2, string arg3, int arg4, float arg5, int arg6, int arg7, Color* arg8, int arg9, int arg10, int arg11, float arg12)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string arg3_in = Marshaling.ConvertStringToNative(arg3);
        long arg4_in = arg4;
        double arg5_in = arg5;
        long arg6_in = arg6;
        long arg7_in = arg7;
        long arg9_in = arg9;
        long arg10_in = arg10;
        long arg11_in = arg11;
        double arg12_in = arg12;
        void** call_args = stackalloc void*[12] { &arg1, arg2, &arg3_in, &arg4_in, &arg5_in, &arg6_in, &arg7_in, arg8, &arg9_in, &arg10_in, &arg11_in, &arg12_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_14_262(IntPtr method, IntPtr ptr, IntPtr arg1, Vector2* arg2, string arg3, int arg4, float arg5, int arg6, int arg7, int arg8, Color* arg9, int arg10, int arg11, int arg12, int arg13, float arg14)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string arg3_in = Marshaling.ConvertStringToNative(arg3);
        long arg4_in = arg4;
        double arg5_in = arg5;
        long arg6_in = arg6;
        long arg7_in = arg7;
        long arg8_in = arg8;
        long arg10_in = arg10;
        long arg11_in = arg11;
        long arg12_in = arg12;
        long arg13_in = arg13;
        double arg14_in = arg14;
        void** call_args = stackalloc void*[14] { &arg1, arg2, &arg3_in, &arg4_in, &arg5_in, &arg6_in, &arg7_in, &arg8_in, arg9, &arg10_in, &arg11_in, &arg12_in, &arg13_in, &arg14_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_6_263(IntPtr method, IntPtr ptr, IntPtr arg1, Vector2* arg2, string arg3, int arg4, Color* arg5, float arg6)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string arg3_in = Marshaling.ConvertStringToNative(arg3);
        long arg4_in = arg4;
        double arg6_in = arg6;
        void** call_args = stackalloc void*[6] { &arg1, arg2, &arg3_in, &arg4_in, arg5, &arg6_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_7_264(IntPtr method, IntPtr ptr, IntPtr arg1, Vector2* arg2, string arg3, int arg4, int arg5, Color* arg6, float arg7)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string arg3_in = Marshaling.ConvertStringToNative(arg3);
        long arg4_in = arg4;
        long arg5_in = arg5;
        double arg7_in = arg7;
        void** call_args = stackalloc void*[7] { &arg1, arg2, &arg3_in, &arg4_in, &arg5_in, arg6, &arg7_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_4_265(IntPtr method, IntPtr ptr, IntPtr arg1, IntPtr arg2, Transform2D* arg3, Color* arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[4] { &arg1, &arg2, arg3, arg4 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_3_266(IntPtr method, IntPtr ptr, Vector2* arg1, float arg2, Vector2* arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double arg2_in = arg2;
        void** call_args = stackalloc void*[3] { arg1, &arg2_in, arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_4_267(IntPtr method, IntPtr ptr, double arg1, double arg2, double arg3, double arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[4] { &arg1, &arg2, &arg3, &arg4 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe GodotObject godot_icall_1_268(IntPtr method, IntPtr ptr, IntPtr arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_ref ret = default;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return InteropUtils.UnmanagedGetManaged(ret.Reference);
    }

    internal static unsafe void godot_icall_2_269(IntPtr method, IntPtr ptr, uint arg1, godot_bool arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe godot_bool godot_icall_1_270(IntPtr method, IntPtr ptr, uint arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_bool ret;
        long arg1_in = arg1;
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe void godot_icall_3_271(IntPtr method, IntPtr ptr, ReadOnlySpan<Vector2> arg1, ReadOnlySpan<Color> arg2, float arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_vector2_array arg1_in = Marshaling.ConvertSystemArrayToNativePackedVector2Array(arg1);
        using godot_packed_color_array arg2_in = Marshaling.ConvertSystemArrayToNativePackedColorArray(arg2);
        double arg3_in = arg3;
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2_in, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_3_272(IntPtr method, IntPtr ptr, ReadOnlySpan<Vector2> arg1, Color* arg2, float arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_vector2_array arg1_in = Marshaling.ConvertSystemArrayToNativePackedVector2Array(arg1);
        double arg3_in = arg3;
        void** call_args = stackalloc void*[3] { &arg1_in, arg2, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_6_273(IntPtr method, IntPtr ptr, Vector2* arg1, Vector2* arg2, Color* arg3, float arg4, float arg5, godot_bool arg6)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double arg4_in = arg4;
        double arg5_in = arg5;
        void** call_args = stackalloc void*[6] { arg1, arg2, arg3, &arg4_in, &arg5_in, &arg6 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_4_274(IntPtr method, IntPtr ptr, Rect2* arg1, Color* arg2, godot_bool arg3, float arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double arg4_in = arg4;
        void** call_args = stackalloc void*[4] { arg1, arg2, &arg3, &arg4_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_3_275(IntPtr method, IntPtr ptr, Vector2* arg1, float arg2, Color* arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double arg2_in = arg2;
        void** call_args = stackalloc void*[3] { arg1, &arg2_in, arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_6_276(IntPtr method, IntPtr ptr, IntPtr arg1, Vector2* arg2, string arg3, int arg4, int arg5, Color* arg6)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string arg3_in = Marshaling.ConvertStringToNative(arg3);
        long arg4_in = arg4;
        long arg5_in = arg5;
        void** call_args = stackalloc void*[6] { &arg1, arg2, &arg3_in, &arg4_in, &arg5_in, arg6 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_5_277(IntPtr method, IntPtr ptr, IntPtr arg1, Vector2* arg2, string arg3, int arg4, Color* arg5)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string arg3_in = Marshaling.ConvertStringToNative(arg3);
        long arg4_in = arg4;
        void** call_args = stackalloc void*[5] { &arg1, arg2, &arg3_in, &arg4_in, arg5 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_13_278(IntPtr method, IntPtr ptr, IntPtr arg1, Vector2* arg2, string arg3, int arg4, float arg5, int arg6, int arg7, int arg8, Color* arg9, int arg10, int arg11, int arg12, int arg13)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string arg3_in = Marshaling.ConvertStringToNative(arg3);
        long arg4_in = arg4;
        double arg5_in = arg5;
        long arg6_in = arg6;
        long arg7_in = arg7;
        long arg8_in = arg8;
        long arg10_in = arg10;
        long arg11_in = arg11;
        long arg12_in = arg12;
        long arg13_in = arg13;
        void** call_args = stackalloc void*[13] { &arg1, arg2, &arg3_in, &arg4_in, &arg5_in, &arg6_in, &arg7_in, &arg8_in, arg9, &arg10_in, &arg11_in, &arg12_in, &arg13_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_11_279(IntPtr method, IntPtr ptr, IntPtr arg1, Vector2* arg2, string arg3, int arg4, float arg5, int arg6, int arg7, Color* arg8, int arg9, int arg10, int arg11)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string arg3_in = Marshaling.ConvertStringToNative(arg3);
        long arg4_in = arg4;
        double arg5_in = arg5;
        long arg6_in = arg6;
        long arg7_in = arg7;
        long arg9_in = arg9;
        long arg10_in = arg10;
        long arg11_in = arg11;
        void** call_args = stackalloc void*[11] { &arg1, arg2, &arg3_in, &arg4_in, &arg5_in, &arg6_in, &arg7_in, arg8, &arg9_in, &arg10_in, &arg11_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_12_280(IntPtr method, IntPtr ptr, IntPtr arg1, Vector2* arg2, string arg3, int arg4, float arg5, int arg6, int arg7, Color* arg8, int arg9, int arg10, int arg11, int arg12)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string arg3_in = Marshaling.ConvertStringToNative(arg3);
        long arg4_in = arg4;
        double arg5_in = arg5;
        long arg6_in = arg6;
        long arg7_in = arg7;
        long arg9_in = arg9;
        long arg10_in = arg10;
        long arg11_in = arg11;
        long arg12_in = arg12;
        void** call_args = stackalloc void*[12] { &arg1, arg2, &arg3_in, &arg4_in, &arg5_in, &arg6_in, &arg7_in, arg8, &arg9_in, &arg10_in, &arg11_in, &arg12_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_10_281(IntPtr method, IntPtr ptr, IntPtr arg1, Vector2* arg2, string arg3, int arg4, float arg5, int arg6, Color* arg7, int arg8, int arg9, int arg10)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string arg3_in = Marshaling.ConvertStringToNative(arg3);
        long arg4_in = arg4;
        double arg5_in = arg5;
        long arg6_in = arg6;
        long arg8_in = arg8;
        long arg9_in = arg9;
        long arg10_in = arg10;
        void** call_args = stackalloc void*[10] { &arg1, arg2, &arg3_in, &arg4_in, &arg5_in, &arg6_in, arg7, &arg8_in, &arg9_in, &arg10_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe byte godot_icall_0_282(IntPtr method, IntPtr ptr)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, null, &ret);
        return (byte)(ret);
    }

    internal static unsafe void godot_icall_1_283(IntPtr method, IntPtr ptr, byte arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe ushort godot_icall_0_284(IntPtr method, IntPtr ptr)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, null, &ret);
        return (ushort)(ret);
    }

    internal static unsafe void godot_icall_1_285(IntPtr method, IntPtr ptr, ushort arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_1_286(IntPtr method, IntPtr ptr, Rid arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe float godot_icall_1_287(IntPtr method, IntPtr ptr, Vector2* arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double ret;
        void** call_args = stackalloc void*[1] { arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (float)ret;
    }

    internal static unsafe float godot_icall_1_288(IntPtr method, IntPtr ptr, Vector3* arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double ret;
        void** call_args = stackalloc void*[1] { arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (float)ret;
    }

    internal static unsafe string[] godot_icall_1_289(IntPtr method, IntPtr ptr, godot_string_name arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_string_array ret = default;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertNativePackedStringArrayToSystemArray(ret);
    }

    internal static unsafe Godot.Collections.Dictionary godot_icall_2_290(IntPtr method, IntPtr ptr, godot_string_name arg1, godot_string_name arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_dictionary ret = default;
        void** call_args = stackalloc void*[2] { &arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Godot.Collections.Dictionary.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe Godot.Collections.Array godot_icall_2_291(IntPtr method, IntPtr ptr, godot_string_name arg1, godot_bool arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_array ret = default;
        void** call_args = stackalloc void*[2] { &arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Godot.Collections.Array.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe StringName godot_icall_2_292(IntPtr method, IntPtr ptr, godot_string_name arg1, godot_string_name arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_string_name ret = default;
        void** call_args = stackalloc void*[2] { &arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return StringName.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe Variant godot_icall_2_293(IntPtr method, IntPtr ptr, IntPtr arg1, godot_string_name arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_variant ret = default;
        void** call_args = stackalloc void*[2] { &arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Variant.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe int godot_icall_3_294(IntPtr method, IntPtr ptr, IntPtr arg1, godot_string_name arg2, Variant arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        godot_variant arg3_in = (godot_variant)arg3.NativeVar;
        void** call_args = stackalloc void*[3] { &arg1, &arg2, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe Variant godot_icall_2_295(IntPtr method, IntPtr ptr, godot_string_name arg1, godot_string_name arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_variant ret = default;
        void** call_args = stackalloc void*[2] { &arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Variant.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe godot_bool godot_icall_3_296(IntPtr method, IntPtr ptr, godot_string_name arg1, godot_string_name arg2, godot_bool arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_bool ret;
        void** call_args = stackalloc void*[3] { &arg1, &arg2, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe int godot_icall_3_297(IntPtr method, IntPtr ptr, godot_string_name arg1, godot_string_name arg2, godot_bool arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        void** call_args = stackalloc void*[3] { &arg1, &arg2, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe Variant godot_icall_3_298(IntPtr method, IntPtr ptr, godot_string_name arg1, godot_string_name arg2, ReadOnlySpan<Variant> arg3, godot_string_name caller)
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
            using godot_variant arg1_in = VariantUtils.CreateFromStringName(arg1);
            call_args[0] = new IntPtr(&arg1_in);
            using godot_variant arg2_in = VariantUtils.CreateFromStringName(arg2);
            call_args[1] = new IntPtr(&arg2_in);
            for (int i = 0; i < vararg_length; i++)
            {
                varargs[i] = arg3[i].NativeVar;
                call_args[2 + i] = new IntPtr(&varargs[i]);
            }
            godot_variant ret = NativeFuncs.godotsharp_method_bind_call(method, ptr, (godot_variant**)call_args, total_length, out godot_variant_call_error vcall_error);
            ExceptionUtils.DebugCheckCallError(caller, ptr, (godot_variant**)call_args, total_length, vcall_error);
            return Variant.CreateTakingOwnershipOfDisposableValue(ret);
        }
    }

    internal static unsafe string[] godot_icall_2_299(IntPtr method, IntPtr ptr, godot_string_name arg1, godot_bool arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_string_array ret = default;
        void** call_args = stackalloc void*[2] { &arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertNativePackedStringArrayToSystemArray(ret);
    }

    internal static unsafe long godot_icall_2_300(IntPtr method, IntPtr ptr, godot_string_name arg1, godot_string_name arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        void** call_args = stackalloc void*[2] { &arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe string[] godot_icall_3_301(IntPtr method, IntPtr ptr, godot_string_name arg1, godot_string_name arg2, godot_bool arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_string_array ret = default;
        void** call_args = stackalloc void*[3] { &arg1, &arg2, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertNativePackedStringArrayToSystemArray(ret);
    }

    internal static unsafe StringName godot_icall_3_302(IntPtr method, IntPtr ptr, godot_string_name arg1, godot_string_name arg2, godot_bool arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_string_name ret = default;
        void** call_args = stackalloc void*[3] { &arg1, &arg2, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return StringName.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe void godot_icall_2_303(IntPtr method, IntPtr ptr, string arg1, string arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        using godot_string arg2_in = Marshaling.ConvertStringToNative(arg2);
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe string godot_icall_1_304(IntPtr method, IntPtr ptr, string arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string ret = default;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertStringToManaged(ret);
    }

    internal static unsafe void godot_icall_3_305(IntPtr method, IntPtr ptr, string arg1, string arg2, godot_bool arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        using godot_string arg2_in = Marshaling.ConvertStringToNative(arg2);
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2_in, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_7_306(IntPtr method, IntPtr ptr, int arg1, string arg2, string arg3, Color* arg4, IntPtr arg5, Variant arg6, int arg7)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        using godot_string arg2_in = Marshaling.ConvertStringToNative(arg2);
        using godot_string arg3_in = Marshaling.ConvertStringToNative(arg3);
        godot_variant arg6_in = (godot_variant)arg6.NativeVar;
        long arg7_in = arg7;
        void** call_args = stackalloc void*[7] { &arg1_in, &arg2_in, &arg3_in, arg4, &arg5, &arg6_in, &arg7_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe Godot.Collections.Dictionary godot_icall_1_307(IntPtr method, IntPtr ptr, int arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_dictionary ret = default;
        long arg1_in = arg1;
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Godot.Collections.Dictionary.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe void godot_icall_2_308(IntPtr method, IntPtr ptr, string arg1, Color* arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        void** call_args = stackalloc void*[2] { &arg1_in, arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe Color godot_icall_1_309(IntPtr method, IntPtr ptr, string arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Color ret;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe void godot_icall_4_310(IntPtr method, IntPtr ptr, string arg1, string arg2, Color* arg3, godot_bool arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        using godot_string arg2_in = Marshaling.ConvertStringToNative(arg2);
        void** call_args = stackalloc void*[4] { &arg1_in, &arg2_in, arg3, &arg4 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe uint godot_icall_1_311(IntPtr method, IntPtr ptr, IntPtr arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (uint)(ret);
    }

    internal static unsafe void godot_icall_2_312(IntPtr method, IntPtr ptr, uint arg1, Transform2D* arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        void** call_args = stackalloc void*[2] { &arg1_in, arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe Transform2D godot_icall_1_313(IntPtr method, IntPtr ptr, uint arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Transform2D ret;
        long arg1_in = arg1;
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe GodotObject godot_icall_1_314(IntPtr method, IntPtr ptr, uint arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        IntPtr ret = default;
        long arg1_in = arg1;
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return InteropUtils.UnmanagedGetManaged(ret);
    }

    internal static unsafe void godot_icall_2_315(IntPtr method, IntPtr ptr, uint arg1, float arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        double arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe float godot_icall_1_316(IntPtr method, IntPtr ptr, uint arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double ret;
        long arg1_in = arg1;
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (float)ret;
    }

    internal static unsafe void godot_icall_2_317(IntPtr method, IntPtr ptr, uint arg1, IntPtr arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe int godot_icall_1_318(IntPtr method, IntPtr ptr, uint arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        long arg1_in = arg1;
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe GodotObject godot_icall_2_319(IntPtr method, IntPtr ptr, uint arg1, int arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_ref ret = default;
        long arg1_in = arg1;
        long arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return InteropUtils.UnmanagedGetManaged(ret.Reference);
    }

    internal static unsafe int godot_icall_2_320(IntPtr method, IntPtr ptr, uint arg1, int arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        long arg1_in = arg1;
        long arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe void godot_icall_2_321(IntPtr method, IntPtr ptr, uint arg1, int arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        long arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe uint godot_icall_1_322(IntPtr method, IntPtr ptr, int arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        long arg1_in = arg1;
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (uint)(ret);
    }

    internal static unsafe void godot_icall_2_323(IntPtr method, IntPtr ptr, uint arg1, Transform3D* arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        void** call_args = stackalloc void*[2] { &arg1_in, arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe Transform3D godot_icall_1_324(IntPtr method, IntPtr ptr, uint arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Transform3D ret;
        long arg1_in = arg1;
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe void godot_icall_3_325(IntPtr method, IntPtr ptr, string arg1, string arg2, Variant arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        using godot_string arg2_in = Marshaling.ConvertStringToNative(arg2);
        godot_variant arg3_in = (godot_variant)arg3.NativeVar;
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2_in, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe Variant godot_icall_3_326(IntPtr method, IntPtr ptr, string arg1, string arg2, Variant arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_variant ret = default;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        using godot_string arg2_in = Marshaling.ConvertStringToNative(arg2);
        godot_variant arg3_in = (godot_variant)arg3.NativeVar;
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2_in, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Variant.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe godot_bool godot_icall_2_327(IntPtr method, IntPtr ptr, string arg1, string arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_bool ret;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        using godot_string arg2_in = Marshaling.ConvertStringToNative(arg2);
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe string[] godot_icall_1_328(IntPtr method, IntPtr ptr, string arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_string_array ret = default;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertNativePackedStringArrayToSystemArray(ret);
    }

    internal static unsafe int godot_icall_2_329(IntPtr method, IntPtr ptr, string arg1, ReadOnlySpan<byte> arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        using godot_packed_byte_array arg2_in = Marshaling.ConvertSystemArrayToNativePackedByteArray(arg2);
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe int godot_icall_2_330(IntPtr method, IntPtr ptr, string arg1, string arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        using godot_string arg2_in = Marshaling.ConvertStringToNative(arg2);
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe void godot_icall_4_331(IntPtr method, IntPtr ptr, int arg1, float arg2, godot_bool arg3, godot_bool arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        double arg2_in = arg2;
        void** call_args = stackalloc void*[4] { &arg1_in, &arg2_in, &arg3, &arg4 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_4_332(IntPtr method, IntPtr ptr, int arg1, float arg2, float arg3, godot_bool arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        double arg2_in = arg2;
        double arg3_in = arg3;
        void** call_args = stackalloc void*[4] { &arg1_in, &arg2_in, &arg3_in, &arg4 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_2_333(IntPtr method, IntPtr ptr, Vector2* arg1, godot_bool arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[2] { arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe godot_bool godot_icall_1_334(IntPtr method, IntPtr ptr, godot_bool arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_bool ret;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe GodotObject godot_icall_1_335(IntPtr method, IntPtr ptr, int arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        IntPtr ret = default;
        long arg1_in = arg1;
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return InteropUtils.UnmanagedGetManaged(ret);
    }

    internal static unsafe GodotObject godot_icall_2_336(IntPtr method, IntPtr ptr, godot_string_name arg1, godot_string_name arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_ref ret = default;
        void** call_args = stackalloc void*[2] { &arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return InteropUtils.UnmanagedGetManaged(ret.Reference);
    }

    internal static unsafe int godot_icall_2_337(IntPtr method, IntPtr ptr, godot_string_name arg1, godot_string_name arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        void** call_args = stackalloc void*[2] { &arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe Color godot_icall_2_338(IntPtr method, IntPtr ptr, godot_string_name arg1, godot_string_name arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Color ret;
        void** call_args = stackalloc void*[2] { &arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe string godot_icall_1_339(IntPtr method, IntPtr ptr, Vector2* arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string ret = default;
        void** call_args = stackalloc void*[1] { arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertStringToManaged(ret);
    }

    internal static unsafe int godot_icall_1_340(IntPtr method, IntPtr ptr, Vector2* arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        void** call_args = stackalloc void*[1] { arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe void godot_icall_2_341(IntPtr method, IntPtr ptr, Variant arg1, IntPtr arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_variant arg1_in = (godot_variant)arg1.NativeVar;
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_3_342(IntPtr method, IntPtr ptr, in Callable arg1, in Callable arg2, in Callable arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_callable arg1_in = Marshaling.ConvertCallableToNative(in arg1);
        using godot_callable arg2_in = Marshaling.ConvertCallableToNative(in arg2);
        using godot_callable arg3_in = Marshaling.ConvertCallableToNative(in arg3);
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2_in, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe byte[] godot_icall_1_343(IntPtr method, IntPtr ptr, int arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_byte_array ret = default;
        long arg1_in = arg1;
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertNativePackedByteArrayToSystemArray(ret);
    }

    internal static unsafe GodotObject godot_icall_4_344(IntPtr method, IntPtr ptr, IntPtr arg1, string arg2, string arg3, string arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_ref ret = default;
        using godot_string arg2_in = Marshaling.ConvertStringToNative(arg2);
        using godot_string arg3_in = Marshaling.ConvertStringToNative(arg3);
        using godot_string arg4_in = Marshaling.ConvertStringToNative(arg4);
        void** call_args = stackalloc void*[4] { &arg1, &arg2_in, &arg3_in, &arg4_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return InteropUtils.UnmanagedGetManaged(ret.Reference);
    }

    internal static unsafe byte[] godot_icall_3_345(IntPtr method, IntPtr ptr, int arg1, ReadOnlySpan<byte> arg2, IntPtr arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_byte_array ret = default;
        long arg1_in = arg1;
        using godot_packed_byte_array arg2_in = Marshaling.ConvertSystemArrayToNativePackedByteArray(arg2);
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2_in, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertNativePackedByteArrayToSystemArray(ret);
    }

    internal static unsafe godot_bool godot_icall_4_346(IntPtr method, IntPtr ptr, int arg1, ReadOnlySpan<byte> arg2, ReadOnlySpan<byte> arg3, IntPtr arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_bool ret;
        long arg1_in = arg1;
        using godot_packed_byte_array arg2_in = Marshaling.ConvertSystemArrayToNativePackedByteArray(arg2);
        using godot_packed_byte_array arg3_in = Marshaling.ConvertSystemArrayToNativePackedByteArray(arg3);
        void** call_args = stackalloc void*[4] { &arg1_in, &arg2_in, &arg3_in, &arg4 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe byte[] godot_icall_2_347(IntPtr method, IntPtr ptr, IntPtr arg1, ReadOnlySpan<byte> arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_byte_array ret = default;
        using godot_packed_byte_array arg2_in = Marshaling.ConvertSystemArrayToNativePackedByteArray(arg2);
        void** call_args = stackalloc void*[2] { &arg1, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertNativePackedByteArrayToSystemArray(ret);
    }

    internal static unsafe byte[] godot_icall_3_348(IntPtr method, IntPtr ptr, int arg1, ReadOnlySpan<byte> arg2, ReadOnlySpan<byte> arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_byte_array ret = default;
        long arg1_in = arg1;
        using godot_packed_byte_array arg2_in = Marshaling.ConvertSystemArrayToNativePackedByteArray(arg2);
        using godot_packed_byte_array arg3_in = Marshaling.ConvertSystemArrayToNativePackedByteArray(arg3);
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2_in, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertNativePackedByteArrayToSystemArray(ret);
    }

    internal static unsafe godot_bool godot_icall_2_349(IntPtr method, IntPtr ptr, ReadOnlySpan<byte> arg1, ReadOnlySpan<byte> arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_bool ret;
        using godot_packed_byte_array arg1_in = Marshaling.ConvertSystemArrayToNativePackedByteArray(arg1);
        using godot_packed_byte_array arg2_in = Marshaling.ConvertSystemArrayToNativePackedByteArray(arg2);
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe int godot_icall_2_350(IntPtr method, IntPtr ptr, string arg1, godot_bool arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe string godot_icall_1_351(IntPtr method, IntPtr ptr, godot_bool arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string ret = default;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertStringToManaged(ret);
    }

    internal static unsafe int godot_icall_5_352(IntPtr method, IntPtr ptr, Vector2* arg1, float arg2, float arg3, int arg4, int arg5)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        double arg2_in = arg2;
        double arg3_in = arg3;
        long arg4_in = arg4;
        long arg5_in = arg5;
        void** call_args = stackalloc void*[5] { arg1, &arg2_in, &arg3_in, &arg4_in, &arg5_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe int godot_icall_2_353(IntPtr method, IntPtr ptr, int arg1, float arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        long arg1_in = arg1;
        double arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe float godot_icall_1_354(IntPtr method, IntPtr ptr, float arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double ret;
        double arg1_in = arg1;
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (float)ret;
    }

    internal static unsafe void godot_icall_4_355(IntPtr method, IntPtr ptr, Vector2* arg1, Vector2* arg2, Vector2* arg3, int arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg4_in = arg4;
        void** call_args = stackalloc void*[4] { arg1, arg2, arg3, &arg4_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe Vector2 godot_icall_2_356(IntPtr method, IntPtr ptr, int arg1, float arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Vector2 ret;
        long arg1_in = arg1;
        double arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Vector2 godot_icall_1_357(IntPtr method, IntPtr ptr, float arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Vector2 ret;
        double arg1_in = arg1;
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Vector2 godot_icall_2_358(IntPtr method, IntPtr ptr, float arg1, godot_bool arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Vector2 ret;
        double arg1_in = arg1;
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Transform2D godot_icall_2_359(IntPtr method, IntPtr ptr, float arg1, godot_bool arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Transform2D ret;
        double arg1_in = arg1;
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Vector2[] godot_icall_2_360(IntPtr method, IntPtr ptr, int arg1, float arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_vector2_array ret = default;
        long arg1_in = arg1;
        double arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertNativePackedVector2ArrayToSystemArray(ret);
    }

    internal static unsafe void godot_icall_4_361(IntPtr method, IntPtr ptr, Vector3* arg1, Vector3* arg2, Vector3* arg3, int arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg4_in = arg4;
        void** call_args = stackalloc void*[4] { arg1, arg2, arg3, &arg4_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_2_362(IntPtr method, IntPtr ptr, int arg1, Vector3* arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        void** call_args = stackalloc void*[2] { &arg1_in, arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe Vector3 godot_icall_1_363(IntPtr method, IntPtr ptr, int arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Vector3 ret;
        long arg1_in = arg1;
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Vector3 godot_icall_2_364(IntPtr method, IntPtr ptr, int arg1, float arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Vector3 ret;
        long arg1_in = arg1;
        double arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Vector3 godot_icall_1_365(IntPtr method, IntPtr ptr, float arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Vector3 ret;
        double arg1_in = arg1;
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Vector3 godot_icall_2_366(IntPtr method, IntPtr ptr, float arg1, godot_bool arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Vector3 ret;
        double arg1_in = arg1;
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Transform3D godot_icall_3_367(IntPtr method, IntPtr ptr, float arg1, godot_bool arg2, godot_bool arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Transform3D ret;
        double arg1_in = arg1;
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe float[] godot_icall_0_368(IntPtr method, IntPtr ptr)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_float32_array ret = default;
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, null, &ret);
        return Marshaling.ConvertNativePackedFloat32ArrayToSystemArray(ret);
    }

    internal static unsafe Vector3[] godot_icall_2_369(IntPtr method, IntPtr ptr, int arg1, float arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_vector3_array ret = default;
        long arg1_in = arg1;
        double arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertNativePackedVector3ArrayToSystemArray(ret);
    }

    internal static unsafe GodotObject godot_icall_4_370(IntPtr method, string arg1, float arg2, float arg3, godot_dictionary arg4)
    {
        using godot_ref ret = default;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        double arg2_in = arg2;
        double arg3_in = arg3;
        void** call_args = stackalloc void*[4] { &arg1_in, &arg2_in, &arg3_in, &arg4 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, IntPtr.Zero, call_args, &ret);
        return InteropUtils.UnmanagedGetManaged(ret.Reference);
    }

    internal static unsafe int godot_icall_1_371(IntPtr method, IntPtr ptr, IntPtr arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe int godot_icall_0_372(IntPtr method)
    {
        long ret;
        NativeFuncs.godotsharp_method_bind_ptrcall(method, IntPtr.Zero, null, &ret);
        return (int)(ret);
    }

    internal static unsafe GodotObject godot_icall_2_373(IntPtr method, string arg1, godot_bool arg2)
    {
        using godot_ref ret = default;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, IntPtr.Zero, call_args, &ret);
        return InteropUtils.UnmanagedGetManaged(ret.Reference);
    }

    internal static unsafe string[] godot_icall_1_374(IntPtr method, string arg1)
    {
        using godot_packed_string_array ret = default;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, IntPtr.Zero, call_args, &ret);
        return Marshaling.ConvertNativePackedStringArrayToSystemArray(ret);
    }

    internal static unsafe string godot_icall_1_375(IntPtr method, int arg1)
    {
        using godot_string ret = default;
        long arg1_in = arg1;
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, IntPtr.Zero, call_args, &ret);
        return Marshaling.ConvertStringToManaged(ret);
    }

    internal static unsafe int godot_icall_1_376(IntPtr method, string arg1)
    {
        long ret;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, IntPtr.Zero, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe godot_bool godot_icall_1_377(IntPtr method, string arg1)
    {
        godot_bool ret;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, IntPtr.Zero, call_args, &ret);
        return ret;
    }

    internal static unsafe int godot_icall_3_378(IntPtr method, IntPtr ptr, string arg1, string arg2, int arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        using godot_string arg2_in = Marshaling.ConvertStringToNative(arg2);
        long arg3_in = arg3;
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2_in, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe int godot_icall_3_379(IntPtr method, string arg1, string arg2, int arg3)
    {
        long ret;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        using godot_string arg2_in = Marshaling.ConvertStringToNative(arg2);
        long arg3_in = arg3;
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2_in, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, IntPtr.Zero, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe int godot_icall_2_380(IntPtr method, string arg1, string arg2)
    {
        long ret;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        using godot_string arg2_in = Marshaling.ConvertStringToNative(arg2);
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, IntPtr.Zero, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe void godot_icall_2_381(IntPtr method, IntPtr ptr, in Callable arg1, in Callable arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_callable arg1_in = Marshaling.ConvertCallableToNative(in arg1);
        using godot_callable arg2_in = Marshaling.ConvertCallableToNative(in arg2);
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_3_382(IntPtr method, IntPtr ptr, string arg1, in Callable arg2, in Callable arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        using godot_callable arg2_in = Marshaling.ConvertCallableToNative(in arg2);
        using godot_callable arg3_in = Marshaling.ConvertCallableToNative(in arg3);
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2_in, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe int godot_icall_4_383(IntPtr method, IntPtr ptr, string arg1, string arg2, string arg3, int arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        using godot_string arg2_in = Marshaling.ConvertStringToNative(arg2);
        using godot_string arg3_in = Marshaling.ConvertStringToNative(arg3);
        long arg4_in = arg4;
        void** call_args = stackalloc void*[4] { &arg1_in, &arg2_in, &arg3_in, &arg4_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe int godot_icall_7_384(IntPtr method, IntPtr ptr, string arg1, string arg2, in Callable arg3, in Callable arg4, Variant arg5, int arg6, int arg7)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        using godot_string arg2_in = Marshaling.ConvertStringToNative(arg2);
        using godot_callable arg3_in = Marshaling.ConvertCallableToNative(in arg3);
        using godot_callable arg4_in = Marshaling.ConvertCallableToNative(in arg4);
        godot_variant arg5_in = (godot_variant)arg5.NativeVar;
        long arg6_in = arg6;
        long arg7_in = arg7;
        void** call_args = stackalloc void*[7] { &arg1_in, &arg2_in, &arg3_in, &arg4_in, &arg5_in, &arg6_in, &arg7_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe int godot_icall_8_385(IntPtr method, IntPtr ptr, string arg1, IntPtr arg2, string arg3, in Callable arg4, in Callable arg5, Variant arg6, int arg7, int arg8)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        using godot_string arg3_in = Marshaling.ConvertStringToNative(arg3);
        using godot_callable arg4_in = Marshaling.ConvertCallableToNative(in arg4);
        using godot_callable arg5_in = Marshaling.ConvertCallableToNative(in arg5);
        godot_variant arg6_in = (godot_variant)arg6.NativeVar;
        long arg7_in = arg7;
        long arg8_in = arg8;
        void** call_args = stackalloc void*[8] { &arg1_in, &arg2, &arg3_in, &arg4_in, &arg5_in, &arg6_in, &arg7_in, &arg8_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe int godot_icall_9_386(IntPtr method, IntPtr ptr, string arg1, string arg2, int arg3, int arg4, in Callable arg5, in Callable arg6, Variant arg7, int arg8, int arg9)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        using godot_string arg2_in = Marshaling.ConvertStringToNative(arg2);
        long arg3_in = arg3;
        long arg4_in = arg4;
        using godot_callable arg5_in = Marshaling.ConvertCallableToNative(in arg5);
        using godot_callable arg6_in = Marshaling.ConvertCallableToNative(in arg6);
        godot_variant arg7_in = (godot_variant)arg7.NativeVar;
        long arg8_in = arg8;
        long arg9_in = arg9;
        void** call_args = stackalloc void*[9] { &arg1_in, &arg2_in, &arg3_in, &arg4_in, &arg5_in, &arg6_in, &arg7_in, &arg8_in, &arg9_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe int godot_icall_2_387(IntPtr method, IntPtr ptr, string arg1, int arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        long arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe int godot_icall_2_388(IntPtr method, IntPtr ptr, string arg1, Variant arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        godot_variant arg2_in = (godot_variant)arg2.NativeVar;
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe godot_bool godot_icall_2_389(IntPtr method, IntPtr ptr, string arg1, int arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_bool ret;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        long arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Callable godot_icall_2_390(IntPtr method, IntPtr ptr, string arg1, int arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_callable ret = default;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        long arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertCallableToManaged(in ret);
    }

    internal static unsafe Variant godot_icall_2_391(IntPtr method, IntPtr ptr, string arg1, int arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_variant ret = default;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        long arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Variant.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe string godot_icall_2_392(IntPtr method, IntPtr ptr, string arg1, int arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string ret = default;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        long arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertStringToManaged(ret);
    }

    internal static unsafe GodotObject godot_icall_2_393(IntPtr method, IntPtr ptr, string arg1, int arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_ref ret = default;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        long arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return InteropUtils.UnmanagedGetManaged(ret.Reference);
    }

    internal static unsafe void godot_icall_3_394(IntPtr method, IntPtr ptr, string arg1, int arg2, godot_bool arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        long arg2_in = arg2;
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2_in, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_3_395(IntPtr method, IntPtr ptr, string arg1, int arg2, in Callable arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        long arg2_in = arg2;
        using godot_callable arg3_in = Marshaling.ConvertCallableToNative(in arg3);
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2_in, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_3_396(IntPtr method, IntPtr ptr, string arg1, int arg2, Variant arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        long arg2_in = arg2;
        godot_variant arg3_in = (godot_variant)arg3.NativeVar;
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2_in, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_3_397(IntPtr method, IntPtr ptr, string arg1, int arg2, string arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        long arg2_in = arg2;
        using godot_string arg3_in = Marshaling.ConvertStringToNative(arg3);
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2_in, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_3_398(IntPtr method, IntPtr ptr, string arg1, int arg2, int arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        long arg2_in = arg2;
        long arg3_in = arg3;
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2_in, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_3_399(IntPtr method, IntPtr ptr, string arg1, int arg2, IntPtr arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        long arg2_in = arg2;
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2_in, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_2_400(IntPtr method, IntPtr ptr, string arg1, int arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        long arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_7_401(IntPtr method, IntPtr ptr, string arg1, string arg2, int arg3, float arg4, float arg5, long arg6, godot_bool arg7)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        using godot_string arg2_in = Marshaling.ConvertStringToNative(arg2);
        long arg3_in = arg3;
        double arg4_in = arg4;
        double arg5_in = arg5;
        void** call_args = stackalloc void*[7] { &arg1_in, &arg2_in, &arg3_in, &arg4_in, &arg5_in, &arg6, &arg7 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_2_402(IntPtr method, IntPtr ptr, int arg1, in Callable arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        using godot_callable arg2_in = Marshaling.ConvertCallableToNative(in arg2);
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_1_403(IntPtr method, IntPtr ptr, in Callable arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_callable arg1_in = Marshaling.ConvertCallableToNative(in arg1);
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe int godot_icall_1_404(IntPtr method, IntPtr ptr, Rect2* arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        void** call_args = stackalloc void*[1] { arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe Vector2I godot_icall_1_405(IntPtr method, IntPtr ptr, int arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Vector2I ret;
        long arg1_in = arg1;
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Rect2I godot_icall_1_406(IntPtr method, IntPtr ptr, int arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Rect2I ret;
        long arg1_in = arg1;
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Color godot_icall_1_407(IntPtr method, IntPtr ptr, Vector2I* arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Color ret;
        void** call_args = stackalloc void*[1] { arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe GodotObject godot_icall_1_408(IntPtr method, IntPtr ptr, Rect2I* arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_ref ret = default;
        void** call_args = stackalloc void*[1] { arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return InteropUtils.UnmanagedGetManaged(ret.Reference);
    }

    internal static unsafe int godot_icall_1_409(IntPtr method, IntPtr ptr, Vector2I* arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        void** call_args = stackalloc void*[1] { arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe long godot_icall_2_410(IntPtr method, IntPtr ptr, int arg1, int arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        long arg1_in = arg1;
        long arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Vector2I godot_icall_2_411(IntPtr method, IntPtr ptr, string arg1, int arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Vector2I ret;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        long arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe void godot_icall_2_412(IntPtr method, IntPtr ptr, ReadOnlySpan<Vector2> arg1, int arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_vector2_array arg1_in = Marshaling.ConvertSystemArrayToNativePackedVector2Array(arg1);
        long arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_2_413(IntPtr method, IntPtr ptr, Vector2I* arg1, int arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg2_in = arg2;
        void** call_args = stackalloc void*[2] { arg1, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_2_414(IntPtr method, IntPtr ptr, in Callable arg1, int arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_callable arg1_in = Marshaling.ConvertCallableToNative(in arg1);
        long arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_3_415(IntPtr method, IntPtr ptr, int arg1, godot_bool arg2, int arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        long arg3_in = arg3;
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe Vector3I godot_icall_1_416(IntPtr method, IntPtr ptr, int arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Vector3I ret;
        long arg1_in = arg1;
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe void godot_icall_2_417(IntPtr method, IntPtr ptr, godot_bool arg1, int arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe Rid godot_icall_2_418(IntPtr method, IntPtr ptr, int arg1, int arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Rid ret;
        long arg1_in = arg1;
        long arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Rid godot_icall_3_419(IntPtr method, IntPtr ptr, Rid arg1, int arg2, int arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Rid ret;
        long arg2_in = arg2;
        long arg3_in = arg3;
        void** call_args = stackalloc void*[3] { &arg1, &arg2_in, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Rid godot_icall_5_420(IntPtr method, IntPtr ptr, Rid arg1, Rid arg2, float arg3, int arg4, godot_bool arg5)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Rid ret;
        double arg3_in = arg3;
        long arg4_in = arg4;
        void** call_args = stackalloc void*[5] { &arg1, &arg2, &arg3_in, &arg4_in, &arg5 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe godot_bool godot_icall_1_421(IntPtr method, IntPtr ptr, Rid arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_bool ret;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe void godot_icall_2_422(IntPtr method, IntPtr ptr, Rid arg1, Variant arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_variant arg2_in = (godot_variant)arg2.NativeVar;
        void** call_args = stackalloc void*[2] { &arg1, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe Variant godot_icall_1_423(IntPtr method, IntPtr ptr, Rid arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_variant ret = default;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Variant.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe void godot_icall_3_424(IntPtr method, IntPtr ptr, int arg1, Rect2* arg2, Rect2* arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        void** call_args = stackalloc void*[3] { &arg1_in, arg2, arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe Rid godot_icall_1_425(IntPtr method, IntPtr ptr, int arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Rid ret;
        long arg1_in = arg1;
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe void godot_icall_2_426(IntPtr method, IntPtr ptr, Rid arg1, int arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_2_427(IntPtr method, IntPtr ptr, Rid arg1, string arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string arg2_in = Marshaling.ConvertStringToNative(arg2);
        void** call_args = stackalloc void*[2] { &arg1, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_2_428(IntPtr method, IntPtr ptr, Rid arg1, Rect2* arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[2] { &arg1, arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_2_429(IntPtr method, IntPtr ptr, Rid arg1, Transform2D* arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[2] { &arg1, arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_2_430(IntPtr method, IntPtr ptr, Rid arg1, Rid arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[2] { &arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_3_431(IntPtr method, IntPtr ptr, Rid arg1, int arg2, in Callable arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg2_in = arg2;
        using godot_callable arg3_in = Marshaling.ConvertCallableToNative(in arg3);
        void** call_args = stackalloc void*[3] { &arg1, &arg2_in, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_3_432(IntPtr method, IntPtr ptr, Rid arg1, int arg2, string arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg2_in = arg2;
        using godot_string arg3_in = Marshaling.ConvertStringToNative(arg3);
        void** call_args = stackalloc void*[3] { &arg1, &arg2_in, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_3_433(IntPtr method, IntPtr ptr, Rid arg1, int arg2, int arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg2_in = arg2;
        long arg3_in = arg3;
        void** call_args = stackalloc void*[3] { &arg1, &arg2_in, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_2_434(IntPtr method, IntPtr ptr, Rid arg1, godot_bool arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[2] { &arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_2_435(IntPtr method, IntPtr ptr, Rid arg1, double arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[2] { &arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_3_436(IntPtr method, IntPtr ptr, Rid arg1, double arg2, double arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[3] { &arg1, &arg2, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_4_437(IntPtr method, IntPtr ptr, Rid arg1, godot_bool arg2, godot_bool arg3, godot_bool arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[4] { &arg1, &arg2, &arg3, &arg4 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_5_438(IntPtr method, IntPtr ptr, Rid arg1, Rid arg2, int arg3, Rid arg4, int arg5)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg3_in = arg3;
        long arg5_in = arg5;
        void** call_args = stackalloc void*[5] { &arg1, &arg2, &arg3_in, &arg4, &arg5_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_3_439(IntPtr method, IntPtr ptr, Rid arg1, int arg2, godot_bool arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg2_in = arg2;
        void** call_args = stackalloc void*[3] { &arg1, &arg2_in, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_2_440(IntPtr method, IntPtr ptr, Rid arg1, Color* arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[2] { &arg1, arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_6_441(IntPtr method, IntPtr ptr, string arg1, Rect2* arg2, int arg3, int arg4, int arg5, int arg6)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        long arg3_in = arg3;
        long arg4_in = arg4;
        long arg5_in = arg5;
        long arg6_in = arg6;
        void** call_args = stackalloc void*[6] { &arg1_in, arg2, &arg3_in, &arg4_in, &arg5_in, &arg6_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_3_442(IntPtr method, IntPtr ptr, IntPtr arg1, int arg2, Vector2* arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg2_in = arg2;
        void** call_args = stackalloc void*[3] { &arg1, &arg2_in, arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe int godot_icall_4_443(IntPtr method, IntPtr ptr, string arg1, string arg2, ReadOnlySpan<string> arg3, in Callable arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        using godot_string arg2_in = Marshaling.ConvertStringToNative(arg2);
        using godot_packed_string_array arg3_in = Marshaling.ConvertSystemArrayToNativePackedStringArray(arg3);
        using godot_callable arg4_in = Marshaling.ConvertCallableToNative(in arg4);
        void** call_args = stackalloc void*[4] { &arg1_in, &arg2_in, &arg3_in, &arg4_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe int godot_icall_4_444(IntPtr method, IntPtr ptr, string arg1, string arg2, string arg3, in Callable arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        using godot_string arg2_in = Marshaling.ConvertStringToNative(arg2);
        using godot_string arg3_in = Marshaling.ConvertStringToNative(arg3);
        using godot_callable arg4_in = Marshaling.ConvertCallableToNative(in arg4);
        void** call_args = stackalloc void*[4] { &arg1_in, &arg2_in, &arg3_in, &arg4_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe int godot_icall_8_445(IntPtr method, IntPtr ptr, string arg1, string arg2, string arg3, godot_bool arg4, int arg5, ReadOnlySpan<string> arg6, in Callable arg7, int arg8)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        using godot_string arg2_in = Marshaling.ConvertStringToNative(arg2);
        using godot_string arg3_in = Marshaling.ConvertStringToNative(arg3);
        long arg5_in = arg5;
        using godot_packed_string_array arg6_in = Marshaling.ConvertSystemArrayToNativePackedStringArray(arg6);
        using godot_callable arg7_in = Marshaling.ConvertCallableToNative(in arg7);
        long arg8_in = arg8;
        void** call_args = stackalloc void*[8] { &arg1_in, &arg2_in, &arg3_in, &arg4, &arg5_in, &arg6_in, &arg7_in, &arg8_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe int godot_icall_10_446(IntPtr method, IntPtr ptr, string arg1, string arg2, string arg3, string arg4, godot_bool arg5, int arg6, ReadOnlySpan<string> arg7, godot_array arg8, in Callable arg9, int arg10)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        using godot_string arg2_in = Marshaling.ConvertStringToNative(arg2);
        using godot_string arg3_in = Marshaling.ConvertStringToNative(arg3);
        using godot_string arg4_in = Marshaling.ConvertStringToNative(arg4);
        long arg6_in = arg6;
        using godot_packed_string_array arg7_in = Marshaling.ConvertSystemArrayToNativePackedStringArray(arg7);
        using godot_callable arg9_in = Marshaling.ConvertCallableToNative(in arg9);
        long arg10_in = arg10;
        void** call_args = stackalloc void*[10] { &arg1_in, &arg2_in, &arg3_in, &arg4_in, &arg5, &arg6_in, &arg7_in, &arg8, &arg9_in, &arg10_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe godot_bool godot_icall_1_447(IntPtr method, IntPtr ptr, in Callable arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_bool ret;
        using godot_callable arg1_in = Marshaling.ConvertCallableToNative(in arg1);
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe int godot_icall_3_448(IntPtr method, IntPtr ptr, IntPtr arg1, string arg2, in Callable arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        using godot_string arg2_in = Marshaling.ConvertStringToNative(arg2);
        using godot_callable arg3_in = Marshaling.ConvertCallableToNative(in arg3);
        void** call_args = stackalloc void*[3] { &arg1, &arg2_in, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe void godot_icall_2_449(IntPtr method, IntPtr ptr, int arg1, Rid arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe Rect2 godot_icall_1_450(IntPtr method, IntPtr ptr, int arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Rect2 ret;
        long arg1_in = arg1;
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Rid godot_icall_4_451(IntPtr method, IntPtr ptr, Rid arg1, Rid arg2, float arg3, int arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Rid ret;
        double arg3_in = arg3;
        long arg4_in = arg4;
        void** call_args = stackalloc void*[4] { &arg1, &arg2, &arg3_in, &arg4_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe int godot_icall_9_452(IntPtr method, IntPtr ptr, string arg1, string arg2, string arg3, string arg4, godot_bool arg5, int arg6, ReadOnlySpan<string> arg7, godot_array arg8, in Callable arg9)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        using godot_string arg2_in = Marshaling.ConvertStringToNative(arg2);
        using godot_string arg3_in = Marshaling.ConvertStringToNative(arg3);
        using godot_string arg4_in = Marshaling.ConvertStringToNative(arg4);
        long arg6_in = arg6;
        using godot_packed_string_array arg7_in = Marshaling.ConvertSystemArrayToNativePackedStringArray(arg7);
        using godot_callable arg9_in = Marshaling.ConvertCallableToNative(in arg9);
        void** call_args = stackalloc void*[9] { &arg1_in, &arg2_in, &arg3_in, &arg4_in, &arg5, &arg6_in, &arg7_in, &arg8, &arg9_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe int godot_icall_7_453(IntPtr method, IntPtr ptr, string arg1, string arg2, string arg3, godot_bool arg4, int arg5, ReadOnlySpan<string> arg6, in Callable arg7)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        using godot_string arg2_in = Marshaling.ConvertStringToNative(arg2);
        using godot_string arg3_in = Marshaling.ConvertStringToNative(arg3);
        long arg5_in = arg5;
        using godot_packed_string_array arg6_in = Marshaling.ConvertSystemArrayToNativePackedStringArray(arg6);
        using godot_callable arg7_in = Marshaling.ConvertCallableToNative(in arg7);
        void** call_args = stackalloc void*[7] { &arg1_in, &arg2_in, &arg3_in, &arg4, &arg5_in, &arg6_in, &arg7_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe int godot_icall_6_454(IntPtr method, IntPtr ptr, string arg1, int arg2, int arg3, int arg4, int arg5, int arg6)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        long arg2_in = arg2;
        long arg3_in = arg3;
        long arg4_in = arg4;
        long arg5_in = arg5;
        long arg6_in = arg6;
        void** call_args = stackalloc void*[6] { &arg1_in, &arg2_in, &arg3_in, &arg4_in, &arg5_in, &arg6_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe int godot_icall_4_455(IntPtr method, IntPtr ptr, int arg1, int arg2, int arg3, int arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        long arg1_in = arg1;
        long arg2_in = arg2;
        long arg3_in = arg3;
        long arg4_in = arg4;
        void** call_args = stackalloc void*[4] { &arg1_in, &arg2_in, &arg3_in, &arg4_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe GodotObject godot_icall_4_456(IntPtr method, IntPtr ptr, string arg1, int arg2, int arg3, int arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_ref ret = default;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        long arg2_in = arg2;
        long arg3_in = arg3;
        long arg4_in = arg4;
        void** call_args = stackalloc void*[4] { &arg1_in, &arg2_in, &arg3_in, &arg4_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return InteropUtils.UnmanagedGetManaged(ret.Reference);
    }

    internal static unsafe Godot.Collections.Array godot_icall_1_457(IntPtr method, IntPtr ptr, int arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_array ret = default;
        long arg1_in = arg1;
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Godot.Collections.Array.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe void godot_icall_3_458(IntPtr method, IntPtr ptr, int arg1, ReadOnlySpan<byte> arg2, int arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        using godot_packed_byte_array arg2_in = Marshaling.ConvertSystemArrayToNativePackedByteArray(arg2);
        long arg3_in = arg3;
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2_in, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe int godot_icall_2_459(IntPtr method, IntPtr ptr, string arg1, IntPtr arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe double godot_icall_1_460(IntPtr method, IntPtr ptr, int arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double ret;
        long arg1_in = arg1;
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe void godot_icall_3_461(IntPtr method, IntPtr ptr, string arg1, int arg2, ReadOnlySpan<byte> arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        long arg2_in = arg2;
        using godot_packed_byte_array arg3_in = Marshaling.ConvertSystemArrayToNativePackedByteArray(arg3);
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2_in, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe int godot_icall_5_462(IntPtr method, IntPtr ptr, int arg1, int arg2, int arg3, int arg4, int arg5)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        long arg1_in = arg1;
        long arg2_in = arg2;
        long arg3_in = arg3;
        long arg4_in = arg4;
        long arg5_in = arg5;
        void** call_args = stackalloc void*[5] { &arg1_in, &arg2_in, &arg3_in, &arg4_in, &arg5_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe int godot_icall_2_463(IntPtr method, IntPtr ptr, int arg1, IntPtr arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        long arg1_in = arg1;
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe int godot_icall_3_464(IntPtr method, IntPtr ptr, int arg1, ReadOnlySpan<byte> arg2, int arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        long arg1_in = arg1;
        using godot_packed_byte_array arg2_in = Marshaling.ConvertSystemArrayToNativePackedByteArray(arg2);
        long arg3_in = arg3;
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2_in, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe void godot_icall_2_469(IntPtr method, IntPtr ptr, string arg1, godot_array arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe string[] godot_icall_1_474(IntPtr method, IntPtr ptr, int arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_string_array ret = default;
        long arg1_in = arg1;
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertNativePackedStringArrayToSystemArray(ret);
    }

    internal static unsafe Godot.Collections.Dictionary godot_icall_2_482(IntPtr method, IntPtr ptr, IntPtr arg1, godot_bool arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_dictionary ret = default;
        void** call_args = stackalloc void*[2] { &arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Godot.Collections.Dictionary.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe string[] godot_icall_0_484(IntPtr method)
    {
        using godot_packed_string_array ret = default;
        NativeFuncs.godotsharp_method_bind_ptrcall(method, IntPtr.Zero, null, &ret);
        return Marshaling.ConvertNativePackedStringArrayToSystemArray(ret);
    }

    internal static unsafe void godot_icall_2_497(IntPtr method, IntPtr ptr, string arg1, godot_bool arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_2_498(IntPtr method, IntPtr ptr, IntPtr arg1, Rect2I* arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[2] { &arg1, arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_2_499(IntPtr method, IntPtr ptr, IntPtr arg1, Vector2I* arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[2] { &arg1, arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_3_500(IntPtr method, IntPtr ptr, IntPtr arg1, Vector2I* arg2, float arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double arg3_in = arg3;
        void** call_args = stackalloc void*[3] { &arg1, arg2, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_2_508(IntPtr method, IntPtr ptr, IntPtr arg1, godot_bool arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[2] { &arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_2_517(IntPtr method, IntPtr ptr, string arg1, IntPtr arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_2_519(IntPtr method, IntPtr ptr, string arg1, in Callable arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        using godot_callable arg2_in = Marshaling.ConvertCallableToNative(in arg2);
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_2_524(IntPtr method, IntPtr ptr, IntPtr arg1, godot_string_name arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[2] { &arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_2_528(IntPtr method, IntPtr ptr, string arg1, Variant arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        godot_variant arg2_in = (godot_variant)arg2.NativeVar;
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe Variant godot_icall_1_530(IntPtr method, IntPtr ptr, string arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_variant ret = default;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Variant.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe GodotObject godot_icall_1_533(IntPtr method, IntPtr ptr, string arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_ref ret = default;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return InteropUtils.UnmanagedGetManaged(ret.Reference);
    }

    internal static unsafe void godot_icall_3_536(IntPtr method, IntPtr ptr, IntPtr arg1, godot_string_name arg2, Variant arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_variant arg3_in = (godot_variant)arg3.NativeVar;
        void** call_args = stackalloc void*[3] { &arg1, &arg2, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_1_544(IntPtr method, IntPtr ptr, ulong arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe GodotObject godot_icall_1_545(IntPtr method, IntPtr ptr, godot_string_name arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        IntPtr ret = default;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return InteropUtils.UnmanagedGetManaged(ret);
    }

    internal static unsafe Godot.Collections.Array godot_icall_1_546(IntPtr method, IntPtr ptr, godot_bool arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_array ret = default;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Godot.Collections.Array.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe void godot_icall_2_547(IntPtr method, IntPtr ptr, godot_string_name arg1, godot_array arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[2] { &arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_3_548(IntPtr method, IntPtr ptr, godot_string_name arg1, godot_bool arg2, godot_array arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[3] { &arg1, &arg2, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_2_549(IntPtr method, IntPtr ptr, godot_string_name arg1, in Callable arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_callable arg2_in = Marshaling.ConvertCallableToNative(in arg2);
        void** call_args = stackalloc void*[2] { &arg1, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_2_550(IntPtr method, IntPtr ptr, godot_bool arg1, godot_bool arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[2] { &arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_3_551(IntPtr method, IntPtr ptr, IntPtr arg1, godot_bool arg2, godot_bool arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[3] { &arg1, &arg2, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe godot_bool godot_icall_2_552(IntPtr method, IntPtr ptr, int arg1, godot_string_name arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_bool ret;
        long arg1_in = arg1;
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe int godot_icall_2_553(IntPtr method, IntPtr ptr, string arg1, ReadOnlySpan<string> arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        using godot_packed_string_array arg2_in = Marshaling.ConvertSystemArrayToNativePackedStringArray(arg2);
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe Variant godot_icall_4_554(IntPtr method, IntPtr ptr, godot_array arg1, IntPtr arg2, godot_bool arg3, godot_bool arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_variant ret = default;
        void** call_args = stackalloc void*[4] { &arg1, &arg2, &arg3, &arg4 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Variant.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe GodotObject godot_icall_2_555(IntPtr method, string arg1, int arg2)
    {
        using godot_ref ret = default;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        long arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, IntPtr.Zero, call_args, &ret);
        return InteropUtils.UnmanagedGetManaged(ret.Reference);
    }

    internal static unsafe GodotObject godot_icall_4_556(IntPtr method, string arg1, int arg2, ReadOnlySpan<byte> arg3, ReadOnlySpan<byte> arg4)
    {
        using godot_ref ret = default;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        long arg2_in = arg2;
        using godot_packed_byte_array arg3_in = Marshaling.ConvertSystemArrayToNativePackedByteArray(arg3);
        using godot_packed_byte_array arg4_in = Marshaling.ConvertSystemArrayToNativePackedByteArray(arg4);
        void** call_args = stackalloc void*[4] { &arg1_in, &arg2_in, &arg3_in, &arg4_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, IntPtr.Zero, call_args, &ret);
        return InteropUtils.UnmanagedGetManaged(ret.Reference);
    }

    internal static unsafe GodotObject godot_icall_3_557(IntPtr method, string arg1, int arg2, string arg3)
    {
        using godot_ref ret = default;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        long arg2_in = arg2;
        using godot_string arg3_in = Marshaling.ConvertStringToNative(arg3);
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2_in, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, IntPtr.Zero, call_args, &ret);
        return InteropUtils.UnmanagedGetManaged(ret.Reference);
    }

    internal static unsafe GodotObject godot_icall_3_558(IntPtr method, string arg1, int arg2, int arg3)
    {
        using godot_ref ret = default;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        long arg2_in = arg2;
        long arg3_in = arg3;
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2_in, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, IntPtr.Zero, call_args, &ret);
        return InteropUtils.UnmanagedGetManaged(ret.Reference);
    }

    internal static unsafe GodotObject godot_icall_4_559(IntPtr method, int arg1, string arg2, string arg3, godot_bool arg4)
    {
        using godot_ref ret = default;
        long arg1_in = arg1;
        using godot_string arg2_in = Marshaling.ConvertStringToNative(arg2);
        using godot_string arg3_in = Marshaling.ConvertStringToNative(arg3);
        void** call_args = stackalloc void*[4] { &arg1_in, &arg2_in, &arg3_in, &arg4 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, IntPtr.Zero, call_args, &ret);
        return InteropUtils.UnmanagedGetManaged(ret.Reference);
    }

    internal static unsafe byte[] godot_icall_1_560(IntPtr method, string arg1)
    {
        using godot_packed_byte_array ret = default;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, IntPtr.Zero, call_args, &ret);
        return Marshaling.ConvertNativePackedByteArrayToSystemArray(ret);
    }

    internal static unsafe string godot_icall_1_561(IntPtr method, string arg1)
    {
        using godot_string ret = default;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, IntPtr.Zero, call_args, &ret);
        return Marshaling.ConvertStringToManaged(ret);
    }

    internal static unsafe int godot_icall_1_562(IntPtr method, IntPtr ptr, long arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe byte[] godot_icall_1_563(IntPtr method, IntPtr ptr, long arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_byte_array ret = default;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertNativePackedByteArrayToSystemArray(ret);
    }

    internal static unsafe Variant godot_icall_1_564(IntPtr method, IntPtr ptr, godot_bool arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_variant ret = default;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Variant.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe godot_bool godot_icall_1_565(IntPtr method, IntPtr ptr, byte arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_bool ret;
        long arg1_in = arg1;
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe godot_bool godot_icall_1_566(IntPtr method, IntPtr ptr, ushort arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_bool ret;
        long arg1_in = arg1;
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe godot_bool godot_icall_1_567(IntPtr method, IntPtr ptr, ulong arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_bool ret;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe godot_bool godot_icall_1_568(IntPtr method, IntPtr ptr, float arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_bool ret;
        double arg1_in = arg1;
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe godot_bool godot_icall_1_569(IntPtr method, IntPtr ptr, double arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_bool ret;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe godot_bool godot_icall_1_570(IntPtr method, IntPtr ptr, ReadOnlySpan<byte> arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_bool ret;
        using godot_packed_byte_array arg1_in = Marshaling.ConvertSystemArrayToNativePackedByteArray(arg1);
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe godot_bool godot_icall_2_571(IntPtr method, IntPtr ptr, ReadOnlySpan<string> arg1, string arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_bool ret;
        using godot_packed_string_array arg1_in = Marshaling.ConvertSystemArrayToNativePackedStringArray(arg1);
        using godot_string arg2_in = Marshaling.ConvertStringToNative(arg2);
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe godot_bool godot_icall_2_572(IntPtr method, IntPtr ptr, Variant arg1, godot_bool arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_bool ret;
        godot_variant arg1_in = (godot_variant)arg1.NativeVar;
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe ulong godot_icall_1_573(IntPtr method, string arg1)
    {
        ulong ret;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, IntPtr.Zero, call_args, &ret);
        return ret;
    }

    internal static unsafe long godot_icall_1_574(IntPtr method, string arg1)
    {
        long ret;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, IntPtr.Zero, call_args, &ret);
        return ret;
    }

    internal static unsafe int godot_icall_2_575(IntPtr method, string arg1, int arg2)
    {
        long ret;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        long arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, IntPtr.Zero, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe int godot_icall_2_576(IntPtr method, string arg1, godot_bool arg2)
    {
        long ret;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, IntPtr.Zero, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe byte[] godot_icall_2_577(IntPtr method, string arg1, string arg2)
    {
        using godot_packed_byte_array ret = default;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        using godot_string arg2_in = Marshaling.ConvertStringToNative(arg2);
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, IntPtr.Zero, call_args, &ret);
        return Marshaling.ConvertNativePackedByteArrayToSystemArray(ret);
    }

    internal static unsafe string godot_icall_2_578(IntPtr method, string arg1, string arg2)
    {
        using godot_string ret = default;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        using godot_string arg2_in = Marshaling.ConvertStringToNative(arg2);
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, IntPtr.Zero, call_args, &ret);
        return Marshaling.ConvertStringToManaged(ret);
    }

    internal static unsafe int godot_icall_3_579(IntPtr method, string arg1, string arg2, ReadOnlySpan<byte> arg3)
    {
        long ret;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        using godot_string arg2_in = Marshaling.ConvertStringToNative(arg2);
        using godot_packed_byte_array arg3_in = Marshaling.ConvertSystemArrayToNativePackedByteArray(arg3);
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2_in, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, IntPtr.Zero, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe int godot_icall_3_580(IntPtr method, string arg1, string arg2, string arg3)
    {
        long ret;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        using godot_string arg2_in = Marshaling.ConvertStringToNative(arg2);
        using godot_string arg3_in = Marshaling.ConvertStringToNative(arg3);
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2_in, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, IntPtr.Zero, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe GodotObject godot_icall_3_581(IntPtr method, string arg1, int arg2, ReadOnlySpan<byte> arg3)
    {
        using godot_ref ret = default;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        long arg2_in = arg2;
        using godot_packed_byte_array arg3_in = Marshaling.ConvertSystemArrayToNativePackedByteArray(arg3);
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2_in, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, IntPtr.Zero, call_args, &ret);
        return InteropUtils.UnmanagedGetManaged(ret.Reference);
    }

    internal static unsafe void godot_icall_3_582(IntPtr method, IntPtr ptr, string arg1, string arg2, string arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        using godot_string arg2_in = Marshaling.ConvertStringToNative(arg2);
        using godot_string arg3_in = Marshaling.ConvertStringToNative(arg3);
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2_in, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_2_583(IntPtr method, IntPtr ptr, int arg1, ReadOnlySpan<string> arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        using godot_packed_string_array arg2_in = Marshaling.ConvertSystemArrayToNativePackedStringArray(arg2);
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_3_584(IntPtr method, IntPtr ptr, string arg1, ReadOnlySpan<string> arg2, int arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        using godot_packed_string_array arg2_in = Marshaling.ConvertSystemArrayToNativePackedStringArray(arg2);
        long arg3_in = arg3;
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2_in, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_1_585(IntPtr method, ReadOnlySpan<string> arg1)
    {
        using godot_packed_string_array arg1_in = Marshaling.ConvertSystemArrayToNativePackedStringArray(arg1);
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, IntPtr.Zero, call_args, null);
    }

    internal static unsafe void godot_icall_1_586(IntPtr method, in Callable arg1)
    {
        using godot_callable arg1_in = Marshaling.ConvertCallableToNative(in arg1);
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, IntPtr.Zero, call_args, null);
    }

    internal static unsafe Rid godot_icall_9_587(IntPtr method, IntPtr ptr, godot_dictionary arg1, int arg2, float arg3, Transform2D* arg4, int arg5, int arg6, int arg7, int arg8, float arg9)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Rid ret;
        long arg2_in = arg2;
        double arg3_in = arg3;
        long arg5_in = arg5;
        long arg6_in = arg6;
        long arg7_in = arg7;
        long arg8_in = arg8;
        double arg9_in = arg9;
        void** call_args = stackalloc void*[9] { &arg1, &arg2_in, &arg3_in, arg4, &arg5_in, &arg6_in, &arg7_in, &arg8_in, &arg9_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Vector2 godot_icall_7_588(IntPtr method, IntPtr ptr, string arg1, int arg2, float arg3, int arg4, int arg5, int arg6, int arg7)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Vector2 ret;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        long arg2_in = arg2;
        double arg3_in = arg3;
        long arg4_in = arg4;
        long arg5_in = arg5;
        long arg6_in = arg6;
        long arg7_in = arg7;
        void** call_args = stackalloc void*[7] { &arg1_in, &arg2_in, &arg3_in, &arg4_in, &arg5_in, &arg6_in, &arg7_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Vector2 godot_icall_9_589(IntPtr method, IntPtr ptr, string arg1, int arg2, float arg3, int arg4, int arg5, int arg6, int arg7, int arg8, int arg9)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Vector2 ret;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        long arg2_in = arg2;
        double arg3_in = arg3;
        long arg4_in = arg4;
        long arg5_in = arg5;
        long arg6_in = arg6;
        long arg7_in = arg7;
        long arg8_in = arg8;
        long arg9_in = arg9;
        void** call_args = stackalloc void*[9] { &arg1_in, &arg2_in, &arg3_in, &arg4_in, &arg5_in, &arg6_in, &arg7_in, &arg8_in, &arg9_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe void godot_icall_11_590(IntPtr method, IntPtr ptr, Rid arg1, Vector2* arg2, string arg3, int arg4, float arg5, int arg6, Color* arg7, int arg8, int arg9, int arg10, float arg11)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string arg3_in = Marshaling.ConvertStringToNative(arg3);
        long arg4_in = arg4;
        double arg5_in = arg5;
        long arg6_in = arg6;
        long arg8_in = arg8;
        long arg9_in = arg9;
        long arg10_in = arg10;
        double arg11_in = arg11;
        void** call_args = stackalloc void*[11] { &arg1, arg2, &arg3_in, &arg4_in, &arg5_in, &arg6_in, arg7, &arg8_in, &arg9_in, &arg10_in, &arg11_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_13_591(IntPtr method, IntPtr ptr, Rid arg1, Vector2* arg2, string arg3, int arg4, float arg5, int arg6, int arg7, Color* arg8, int arg9, int arg10, int arg11, int arg12, float arg13)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string arg3_in = Marshaling.ConvertStringToNative(arg3);
        long arg4_in = arg4;
        double arg5_in = arg5;
        long arg6_in = arg6;
        long arg7_in = arg7;
        long arg9_in = arg9;
        long arg10_in = arg10;
        long arg11_in = arg11;
        long arg12_in = arg12;
        double arg13_in = arg13;
        void** call_args = stackalloc void*[13] { &arg1, arg2, &arg3_in, &arg4_in, &arg5_in, &arg6_in, &arg7_in, arg8, &arg9_in, &arg10_in, &arg11_in, &arg12_in, &arg13_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_12_592(IntPtr method, IntPtr ptr, Rid arg1, Vector2* arg2, string arg3, int arg4, float arg5, int arg6, int arg7, Color* arg8, int arg9, int arg10, int arg11, float arg12)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string arg3_in = Marshaling.ConvertStringToNative(arg3);
        long arg4_in = arg4;
        double arg5_in = arg5;
        long arg6_in = arg6;
        long arg7_in = arg7;
        long arg9_in = arg9;
        long arg10_in = arg10;
        long arg11_in = arg11;
        double arg12_in = arg12;
        void** call_args = stackalloc void*[12] { &arg1, arg2, &arg3_in, &arg4_in, &arg5_in, &arg6_in, &arg7_in, arg8, &arg9_in, &arg10_in, &arg11_in, &arg12_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_14_593(IntPtr method, IntPtr ptr, Rid arg1, Vector2* arg2, string arg3, int arg4, float arg5, int arg6, int arg7, int arg8, Color* arg9, int arg10, int arg11, int arg12, int arg13, float arg14)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string arg3_in = Marshaling.ConvertStringToNative(arg3);
        long arg4_in = arg4;
        double arg5_in = arg5;
        long arg6_in = arg6;
        long arg7_in = arg7;
        long arg8_in = arg8;
        long arg10_in = arg10;
        long arg11_in = arg11;
        long arg12_in = arg12;
        long arg13_in = arg13;
        double arg14_in = arg14;
        void** call_args = stackalloc void*[14] { &arg1, arg2, &arg3_in, &arg4_in, &arg5_in, &arg6_in, &arg7_in, &arg8_in, arg9, &arg10_in, &arg11_in, &arg12_in, &arg13_in, &arg14_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe Vector2 godot_icall_2_594(IntPtr method, IntPtr ptr, long arg1, int arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Vector2 ret;
        long arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe float godot_icall_6_595(IntPtr method, IntPtr ptr, Rid arg1, Vector2* arg2, long arg3, int arg4, Color* arg5, float arg6)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double ret;
        long arg4_in = arg4;
        double arg6_in = arg6;
        void** call_args = stackalloc void*[6] { &arg1, arg2, &arg3, &arg4_in, arg5, &arg6_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (float)ret;
    }

    internal static unsafe float godot_icall_7_596(IntPtr method, IntPtr ptr, Rid arg1, Vector2* arg2, long arg3, int arg4, int arg5, Color* arg6, float arg7)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double ret;
        long arg4_in = arg4;
        long arg5_in = arg5;
        double arg7_in = arg7;
        void** call_args = stackalloc void*[7] { &arg1, arg2, &arg3, &arg4_in, &arg5_in, arg6, &arg7_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (float)ret;
    }

    internal static unsafe Rid godot_icall_8_597(IntPtr method, IntPtr ptr, godot_dictionary arg1, int arg2, float arg3, Transform2D* arg4, int arg5, int arg6, int arg7, int arg8)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Rid ret;
        long arg2_in = arg2;
        double arg3_in = arg3;
        long arg5_in = arg5;
        long arg6_in = arg6;
        long arg7_in = arg7;
        long arg8_in = arg8;
        void** call_args = stackalloc void*[8] { &arg1, &arg2_in, &arg3_in, arg4, &arg5_in, &arg6_in, &arg7_in, &arg8_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Rid godot_icall_4_598(IntPtr method, IntPtr ptr, godot_dictionary arg1, int arg2, float arg3, Transform2D* arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Rid ret;
        long arg2_in = arg2;
        double arg3_in = arg3;
        void** call_args = stackalloc void*[4] { &arg1, &arg2_in, &arg3_in, arg4 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe float godot_icall_6_599(IntPtr method, IntPtr ptr, Rid arg1, Vector2* arg2, long arg3, int arg4, int arg5, Color* arg6)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double ret;
        long arg4_in = arg4;
        long arg5_in = arg5;
        void** call_args = stackalloc void*[6] { &arg1, arg2, &arg3, &arg4_in, &arg5_in, arg6 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (float)ret;
    }

    internal static unsafe float godot_icall_5_600(IntPtr method, IntPtr ptr, Rid arg1, Vector2* arg2, long arg3, int arg4, Color* arg5)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double ret;
        long arg4_in = arg4;
        void** call_args = stackalloc void*[5] { &arg1, arg2, &arg3, &arg4_in, arg5 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (float)ret;
    }

    internal static unsafe void godot_icall_13_601(IntPtr method, IntPtr ptr, Rid arg1, Vector2* arg2, string arg3, int arg4, float arg5, int arg6, int arg7, int arg8, Color* arg9, int arg10, int arg11, int arg12, int arg13)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string arg3_in = Marshaling.ConvertStringToNative(arg3);
        long arg4_in = arg4;
        double arg5_in = arg5;
        long arg6_in = arg6;
        long arg7_in = arg7;
        long arg8_in = arg8;
        long arg10_in = arg10;
        long arg11_in = arg11;
        long arg12_in = arg12;
        long arg13_in = arg13;
        void** call_args = stackalloc void*[13] { &arg1, arg2, &arg3_in, &arg4_in, &arg5_in, &arg6_in, &arg7_in, &arg8_in, arg9, &arg10_in, &arg11_in, &arg12_in, &arg13_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_11_602(IntPtr method, IntPtr ptr, Rid arg1, Vector2* arg2, string arg3, int arg4, float arg5, int arg6, int arg7, Color* arg8, int arg9, int arg10, int arg11)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string arg3_in = Marshaling.ConvertStringToNative(arg3);
        long arg4_in = arg4;
        double arg5_in = arg5;
        long arg6_in = arg6;
        long arg7_in = arg7;
        long arg9_in = arg9;
        long arg10_in = arg10;
        long arg11_in = arg11;
        void** call_args = stackalloc void*[11] { &arg1, arg2, &arg3_in, &arg4_in, &arg5_in, &arg6_in, &arg7_in, arg8, &arg9_in, &arg10_in, &arg11_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_12_603(IntPtr method, IntPtr ptr, Rid arg1, Vector2* arg2, string arg3, int arg4, float arg5, int arg6, int arg7, Color* arg8, int arg9, int arg10, int arg11, int arg12)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string arg3_in = Marshaling.ConvertStringToNative(arg3);
        long arg4_in = arg4;
        double arg5_in = arg5;
        long arg6_in = arg6;
        long arg7_in = arg7;
        long arg9_in = arg9;
        long arg10_in = arg10;
        long arg11_in = arg11;
        long arg12_in = arg12;
        void** call_args = stackalloc void*[12] { &arg1, arg2, &arg3_in, &arg4_in, &arg5_in, &arg6_in, &arg7_in, arg8, &arg9_in, &arg10_in, &arg11_in, &arg12_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_10_604(IntPtr method, IntPtr ptr, Rid arg1, Vector2* arg2, string arg3, int arg4, float arg5, int arg6, Color* arg7, int arg8, int arg9, int arg10)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string arg3_in = Marshaling.ConvertStringToNative(arg3);
        long arg4_in = arg4;
        double arg5_in = arg5;
        long arg6_in = arg6;
        long arg8_in = arg8;
        long arg9_in = arg9;
        long arg10_in = arg10;
        void** call_args = stackalloc void*[10] { &arg1, arg2, &arg3_in, &arg4_in, &arg5_in, &arg6_in, arg7, &arg8_in, &arg9_in, &arg10_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_2_605(IntPtr method, IntPtr ptr, int arg1, Vector2I* arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        void** call_args = stackalloc void*[2] { &arg1_in, arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_2_606(IntPtr method, IntPtr ptr, int arg1, godot_dictionary arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_2_607(IntPtr method, IntPtr ptr, int arg1, Transform2D* arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        void** call_args = stackalloc void*[2] { &arg1_in, arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe Transform2D godot_icall_1_608(IntPtr method, IntPtr ptr, int arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Transform2D ret;
        long arg1_in = arg1;
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe void godot_icall_3_609(IntPtr method, IntPtr ptr, int arg1, int arg2, long arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        long arg2_in = arg2;
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2_in, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_2_610(IntPtr method, IntPtr ptr, int arg1, long arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe long godot_icall_1_611(IntPtr method, IntPtr ptr, int arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        long arg1_in = arg1;
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe int godot_icall_2_612(IntPtr method, IntPtr ptr, int arg1, Vector2I* arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        long arg1_in = arg1;
        void** call_args = stackalloc void*[2] { &arg1_in, arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe void godot_icall_3_613(IntPtr method, IntPtr ptr, int arg1, Vector2I* arg2, int arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        long arg3_in = arg3;
        void** call_args = stackalloc void*[3] { &arg1_in, arg2, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_4_614(IntPtr method, IntPtr ptr, int arg1, Vector2I* arg2, int arg3, IntPtr arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        long arg3_in = arg3;
        void** call_args = stackalloc void*[4] { &arg1_in, arg2, &arg3_in, &arg4 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe GodotObject godot_icall_3_615(IntPtr method, IntPtr ptr, int arg1, Vector2I* arg2, int arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_ref ret = default;
        long arg1_in = arg1;
        long arg3_in = arg3;
        void** call_args = stackalloc void*[3] { &arg1_in, arg2, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return InteropUtils.UnmanagedGetManaged(ret.Reference);
    }

    internal static unsafe void godot_icall_4_616(IntPtr method, IntPtr ptr, int arg1, Vector2I* arg2, int arg3, ReadOnlySpan<int> arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        long arg3_in = arg3;
        using godot_packed_int32_array arg4_in = Marshaling.ConvertSystemArrayToNativePackedInt32Array(arg4);
        void** call_args = stackalloc void*[4] { &arg1_in, arg2, &arg3_in, &arg4_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe int[] godot_icall_3_617(IntPtr method, IntPtr ptr, int arg1, Vector2I* arg2, int arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_int32_array ret = default;
        long arg1_in = arg1;
        long arg3_in = arg3;
        void** call_args = stackalloc void*[3] { &arg1_in, arg2, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertNativePackedInt32ArrayToSystemArray(ret);
    }

    internal static unsafe int[] godot_icall_2_618(IntPtr method, IntPtr ptr, int arg1, Vector2I* arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_int32_array ret = default;
        long arg1_in = arg1;
        void** call_args = stackalloc void*[2] { &arg1_in, arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertNativePackedInt32ArrayToSystemArray(ret);
    }

    internal static unsafe void godot_icall_4_619(IntPtr method, IntPtr ptr, int arg1, int arg2, int arg3, Vector2* arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        long arg2_in = arg2;
        long arg3_in = arg3;
        void** call_args = stackalloc void*[4] { &arg1_in, &arg2_in, &arg3_in, arg4 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe Vector2 godot_icall_3_620(IntPtr method, IntPtr ptr, int arg1, int arg2, int arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Vector2 ret;
        long arg1_in = arg1;
        long arg2_in = arg2;
        long arg3_in = arg3;
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2_in, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe void godot_icall_4_621(IntPtr method, IntPtr ptr, int arg1, Vector2I* arg2, int arg3, Vector2* arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        long arg3_in = arg3;
        void** call_args = stackalloc void*[4] { &arg1_in, arg2, &arg3_in, arg4 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe Vector2 godot_icall_3_622(IntPtr method, IntPtr ptr, int arg1, Vector2I* arg2, int arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Vector2 ret;
        long arg1_in = arg1;
        long arg3_in = arg3;
        void** call_args = stackalloc void*[3] { &arg1_in, arg2, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe void godot_icall_4_623(IntPtr method, IntPtr ptr, int arg1, Vector2I* arg2, int arg3, Rect2* arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        long arg3_in = arg3;
        void** call_args = stackalloc void*[4] { &arg1_in, arg2, &arg3_in, arg4 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe Rect2 godot_icall_3_624(IntPtr method, IntPtr ptr, int arg1, Vector2I* arg2, int arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Rect2 ret;
        long arg1_in = arg1;
        long arg3_in = arg3;
        void** call_args = stackalloc void*[3] { &arg1_in, arg2, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe void godot_icall_4_625(IntPtr method, IntPtr ptr, int arg1, Vector2I* arg2, int arg3, int arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        long arg3_in = arg3;
        long arg4_in = arg4;
        void** call_args = stackalloc void*[4] { &arg1_in, arg2, &arg3_in, &arg4_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe int godot_icall_3_626(IntPtr method, IntPtr ptr, int arg1, Vector2I* arg2, int arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        long arg1_in = arg1;
        long arg3_in = arg3;
        void** call_args = stackalloc void*[3] { &arg1_in, arg2, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe void godot_icall_3_627(IntPtr method, IntPtr ptr, int arg1, int arg2, Vector2I* arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        long arg2_in = arg2;
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2_in, arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_4_628(IntPtr method, IntPtr ptr, int arg1, int arg2, Vector2I* arg3, Vector2* arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        long arg2_in = arg2;
        void** call_args = stackalloc void*[4] { &arg1_in, &arg2_in, arg3, arg4 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe Vector2 godot_icall_3_629(IntPtr method, IntPtr ptr, int arg1, int arg2, Vector2I* arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Vector2 ret;
        long arg1_in = arg1;
        long arg2_in = arg2;
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2_in, arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe void godot_icall_4_630(IntPtr method, IntPtr ptr, int arg1, Vector2I* arg2, long arg3, long arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        void** call_args = stackalloc void*[4] { &arg1_in, arg2, &arg3, &arg4 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe int godot_icall_3_631(IntPtr method, IntPtr ptr, int arg1, long arg2, long arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        long arg1_in = arg1;
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe Rid godot_icall_3_632(IntPtr method, godot_array arg1, godot_array arg2, uint arg3)
    {
        Rid ret;
        long arg3_in = arg3;
        void** call_args = stackalloc void*[3] { &arg1, &arg2, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, IntPtr.Zero, call_args, &ret);
        return ret;
    }

    internal static unsafe GodotObject godot_icall_1_633(IntPtr method, godot_dictionary arg1)
    {
        using godot_ref ret = default;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, IntPtr.Zero, call_args, &ret);
        return InteropUtils.UnmanagedGetManaged(ret.Reference);
    }

    internal static unsafe double[] godot_icall_0_634(IntPtr method, IntPtr ptr)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_float64_array ret = default;
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, null, &ret);
        return Marshaling.ConvertNativePackedFloat64ArrayToSystemArray(ret);
    }

    internal static unsafe void godot_icall_1_635(IntPtr method, IntPtr ptr, ReadOnlySpan<double> arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_float64_array arg1_in = Marshaling.ConvertSystemArrayToNativePackedFloat64Array(arg1);
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe byte[] godot_icall_1_636(IntPtr method, IntPtr ptr, IntPtr arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_byte_array ret = default;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertNativePackedByteArrayToSystemArray(ret);
    }

    internal static unsafe GodotObject godot_icall_1_637(IntPtr method, IntPtr arg1)
    {
        using godot_ref ret = default;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, IntPtr.Zero, call_args, &ret);
        return InteropUtils.UnmanagedGetManaged(ret.Reference);
    }

    internal static unsafe int godot_icall_4_638(IntPtr method, IntPtr ptr, string arg1, IntPtr arg2, uint arg3, string arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        long arg3_in = arg3;
        using godot_string arg4_in = Marshaling.ConvertStringToNative(arg4);
        void** call_args = stackalloc void*[4] { &arg1_in, &arg2, &arg3_in, &arg4_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe int godot_icall_4_639(IntPtr method, IntPtr ptr, ReadOnlySpan<byte> arg1, string arg2, IntPtr arg3, uint arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        using godot_packed_byte_array arg1_in = Marshaling.ConvertSystemArrayToNativePackedByteArray(arg1);
        using godot_string arg2_in = Marshaling.ConvertStringToNative(arg2);
        long arg4_in = arg4;
        void** call_args = stackalloc void*[4] { &arg1_in, &arg2_in, &arg3, &arg4_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe int godot_icall_3_640(IntPtr method, IntPtr ptr, IntPtr arg1, IntPtr arg2, uint arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        long arg3_in = arg3;
        void** call_args = stackalloc void*[3] { &arg1, &arg2, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe GodotObject godot_icall_4_641(IntPtr method, IntPtr ptr, IntPtr arg1, float arg2, godot_bool arg3, godot_bool arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        IntPtr ret = default;
        double arg2_in = arg2;
        void** call_args = stackalloc void*[4] { &arg1, &arg2_in, &arg3, &arg4 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return InteropUtils.UnmanagedGetManaged(ret);
    }

    internal static unsafe int godot_icall_2_642(IntPtr method, IntPtr ptr, IntPtr arg1, string arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        using godot_string arg2_in = Marshaling.ConvertStringToNative(arg2);
        void** call_args = stackalloc void*[2] { &arg1, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe GodotObject godot_icall_2_643(IntPtr method, IntPtr arg1, string arg2)
    {
        using godot_ref ret = default;
        using godot_string arg2_in = Marshaling.ConvertStringToNative(arg2);
        void** call_args = stackalloc void*[2] { &arg1, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, IntPtr.Zero, call_args, &ret);
        return InteropUtils.UnmanagedGetManaged(ret.Reference);
    }

    internal static unsafe GodotObject godot_icall_4_644(IntPtr method, IntPtr arg1, godot_node_path arg2, IntPtr arg3, int arg4)
    {
        using godot_ref ret = default;
        long arg4_in = arg4;
        void** call_args = stackalloc void*[4] { &arg1, &arg2, &arg3, &arg4_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, IntPtr.Zero, call_args, &ret);
        return InteropUtils.UnmanagedGetManaged(ret.Reference);
    }

    internal static unsafe void godot_icall_2_645(IntPtr method, IntPtr arg1, godot_bool arg2)
    {
        void** call_args = stackalloc void*[2] { &arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, IntPtr.Zero, call_args, null);
    }

    internal static unsafe void godot_icall_1_646(IntPtr method, IntPtr arg1)
    {
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, IntPtr.Zero, call_args, null);
    }

    internal static unsafe void godot_icall_1_647(IntPtr method, IntPtr ptr, ReadOnlySpan<float> arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_float32_array arg1_in = Marshaling.ConvertSystemArrayToNativePackedFloat32Array(arg1);
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_1_648(IntPtr method, IntPtr ptr, Transform3D* arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[1] { arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_1_649(IntPtr method, IntPtr ptr, Quaternion* arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[1] { arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe NodePath godot_icall_2_650(IntPtr method, IntPtr ptr, IntPtr arg1, godot_bool arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_node_path ret = default;
        void** call_args = stackalloc void*[2] { &arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return NodePath.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe void godot_icall_2_651(IntPtr method, IntPtr ptr, godot_node_path arg1, godot_string_name arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[2] { &arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe Basis godot_icall_0_652(IntPtr method, IntPtr ptr)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Basis ret;
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, null, &ret);
        return ret;
    }

    internal static unsafe void godot_icall_1_653(IntPtr method, IntPtr ptr, Basis* arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[1] { arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe GodotObject godot_icall_1_654(IntPtr method, IntPtr ptr, godot_bool arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_ref ret = default;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return InteropUtils.UnmanagedGetManaged(ret.Reference);
    }

    internal static unsafe int godot_icall_2_655(IntPtr method, IntPtr ptr, ReadOnlySpan<byte> arg1, godot_bool arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        using godot_packed_byte_array arg1_in = Marshaling.ConvertSystemArrayToNativePackedByteArray(arg1);
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe int godot_icall_3_656(IntPtr method, IntPtr ptr, IntPtr arg1, IntPtr arg2, int arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        long arg3_in = arg3;
        void** call_args = stackalloc void*[3] { &arg1, &arg2, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe void godot_icall_5_657(IntPtr method, IntPtr ptr, Transform2D* arg1, Vector2* arg2, Color* arg3, Color* arg4, uint arg5)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg5_in = arg5;
        void** call_args = stackalloc void*[5] { arg1, arg2, arg3, arg4, &arg5_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_5_658(IntPtr method, IntPtr ptr, Transform3D* arg1, Vector3* arg2, Color* arg3, Color* arg4, uint arg5)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg5_in = arg5;
        void** call_args = stackalloc void*[5] { arg1, arg2, arg3, arg4, &arg5_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe godot_bool godot_icall_3_659(IntPtr method, IntPtr ptr, Vector2* arg1, Vector2* arg2, float arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_bool ret;
        double arg3_in = arg3;
        void** call_args = stackalloc void*[3] { arg1, arg2, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe float godot_icall_4_660(IntPtr method, IntPtr ptr, Vector2* arg1, Vector2* arg2, Vector2* arg3, float arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double ret;
        double arg4_in = arg4;
        void** call_args = stackalloc void*[4] { arg1, arg2, arg3, &arg4_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (float)ret;
    }

    internal static unsafe Variant godot_icall_4_661(IntPtr method, IntPtr ptr, Vector2* arg1, Vector2* arg2, Vector2* arg3, Vector2* arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_variant ret = default;
        void** call_args = stackalloc void*[4] { arg1, arg2, arg3, arg4 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Variant.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe Vector2[] godot_icall_4_662(IntPtr method, IntPtr ptr, Vector2* arg1, Vector2* arg2, Vector2* arg3, Vector2* arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_vector2_array ret = default;
        void** call_args = stackalloc void*[4] { arg1, arg2, arg3, arg4 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertNativePackedVector2ArrayToSystemArray(ret);
    }

    internal static unsafe Vector2 godot_icall_3_663(IntPtr method, IntPtr ptr, Vector2* arg1, Vector2* arg2, Vector2* arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Vector2 ret;
        void** call_args = stackalloc void*[3] { arg1, arg2, arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe godot_bool godot_icall_4_664(IntPtr method, IntPtr ptr, Vector2* arg1, Vector2* arg2, Vector2* arg3, Vector2* arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_bool ret;
        void** call_args = stackalloc void*[4] { arg1, arg2, arg3, arg4 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe godot_bool godot_icall_2_665(IntPtr method, IntPtr ptr, Vector2* arg1, ReadOnlySpan<Vector2> arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_bool ret;
        using godot_packed_vector2_array arg2_in = Marshaling.ConvertSystemArrayToNativePackedVector2Array(arg2);
        void** call_args = stackalloc void*[2] { arg1, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe int[] godot_icall_1_666(IntPtr method, IntPtr ptr, ReadOnlySpan<Vector2> arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_int32_array ret = default;
        using godot_packed_vector2_array arg1_in = Marshaling.ConvertSystemArrayToNativePackedVector2Array(arg1);
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertNativePackedInt32ArrayToSystemArray(ret);
    }

    internal static unsafe Vector2[] godot_icall_1_667(IntPtr method, IntPtr ptr, ReadOnlySpan<Vector2> arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_vector2_array ret = default;
        using godot_packed_vector2_array arg1_in = Marshaling.ConvertSystemArrayToNativePackedVector2Array(arg1);
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertNativePackedVector2ArrayToSystemArray(ret);
    }

    internal static unsafe Godot.Collections.Array godot_icall_1_668(IntPtr method, IntPtr ptr, ReadOnlySpan<Vector2> arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_array ret = default;
        using godot_packed_vector2_array arg1_in = Marshaling.ConvertSystemArrayToNativePackedVector2Array(arg1);
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Godot.Collections.Array.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe Godot.Collections.Array godot_icall_2_669(IntPtr method, IntPtr ptr, ReadOnlySpan<Vector2> arg1, ReadOnlySpan<Vector2> arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_array ret = default;
        using godot_packed_vector2_array arg1_in = Marshaling.ConvertSystemArrayToNativePackedVector2Array(arg1);
        using godot_packed_vector2_array arg2_in = Marshaling.ConvertSystemArrayToNativePackedVector2Array(arg2);
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Godot.Collections.Array.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe Godot.Collections.Array godot_icall_3_670(IntPtr method, IntPtr ptr, ReadOnlySpan<Vector2> arg1, float arg2, int arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_array ret = default;
        using godot_packed_vector2_array arg1_in = Marshaling.ConvertSystemArrayToNativePackedVector2Array(arg1);
        double arg2_in = arg2;
        long arg3_in = arg3;
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2_in, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Godot.Collections.Array.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe Godot.Collections.Array godot_icall_4_671(IntPtr method, IntPtr ptr, ReadOnlySpan<Vector2> arg1, float arg2, int arg3, int arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_array ret = default;
        using godot_packed_vector2_array arg1_in = Marshaling.ConvertSystemArrayToNativePackedVector2Array(arg1);
        double arg2_in = arg2;
        long arg3_in = arg3;
        long arg4_in = arg4;
        void** call_args = stackalloc void*[4] { &arg1_in, &arg2_in, &arg3_in, &arg4_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Godot.Collections.Array.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe Godot.Collections.Dictionary godot_icall_1_672(IntPtr method, IntPtr ptr, ReadOnlySpan<Vector2> arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_dictionary ret = default;
        using godot_packed_vector2_array arg1_in = Marshaling.ConvertSystemArrayToNativePackedVector2Array(arg1);
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Godot.Collections.Dictionary.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe Vector3[] godot_icall_1_673(IntPtr method, IntPtr ptr, godot_array arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_vector3_array ret = default;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertNativePackedVector3ArrayToSystemArray(ret);
    }

    internal static unsafe Godot.Collections.Array godot_icall_1_674(IntPtr method, IntPtr ptr, Vector3* arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_array ret = default;
        void** call_args = stackalloc void*[1] { arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Godot.Collections.Array.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe Godot.Collections.Array godot_icall_4_675(IntPtr method, IntPtr ptr, float arg1, float arg2, int arg3, int arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_array ret = default;
        double arg1_in = arg1;
        double arg2_in = arg2;
        long arg3_in = arg3;
        long arg4_in = arg4;
        void** call_args = stackalloc void*[4] { &arg1_in, &arg2_in, &arg3_in, &arg4_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Godot.Collections.Array.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe Godot.Collections.Array godot_icall_5_676(IntPtr method, IntPtr ptr, float arg1, float arg2, int arg3, int arg4, int arg5)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_array ret = default;
        double arg1_in = arg1;
        double arg2_in = arg2;
        long arg3_in = arg3;
        long arg4_in = arg4;
        long arg5_in = arg5;
        void** call_args = stackalloc void*[5] { &arg1_in, &arg2_in, &arg3_in, &arg4_in, &arg5_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Godot.Collections.Array.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe Vector3[] godot_icall_4_677(IntPtr method, IntPtr ptr, Vector3* arg1, Vector3* arg2, Vector3* arg3, Vector3* arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_vector3_array ret = default;
        void** call_args = stackalloc void*[4] { arg1, arg2, arg3, arg4 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertNativePackedVector3ArrayToSystemArray(ret);
    }

    internal static unsafe Vector3 godot_icall_3_678(IntPtr method, IntPtr ptr, Vector3* arg1, Vector3* arg2, Vector3* arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Vector3 ret;
        void** call_args = stackalloc void*[3] { arg1, arg2, arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Vector3 godot_icall_4_679(IntPtr method, IntPtr ptr, Vector3* arg1, Vector3* arg2, Vector3* arg3, Vector3* arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Vector3 ret;
        void** call_args = stackalloc void*[4] { arg1, arg2, arg3, arg4 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Variant godot_icall_5_680(IntPtr method, IntPtr ptr, Vector3* arg1, Vector3* arg2, Vector3* arg3, Vector3* arg4, Vector3* arg5)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_variant ret = default;
        void** call_args = stackalloc void*[5] { arg1, arg2, arg3, arg4, arg5 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Variant.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe Vector3[] godot_icall_4_681(IntPtr method, IntPtr ptr, Vector3* arg1, Vector3* arg2, Vector3* arg3, float arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_vector3_array ret = default;
        double arg4_in = arg4;
        void** call_args = stackalloc void*[4] { arg1, arg2, arg3, &arg4_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertNativePackedVector3ArrayToSystemArray(ret);
    }

    internal static unsafe Vector3[] godot_icall_4_682(IntPtr method, IntPtr ptr, Vector3* arg1, Vector3* arg2, float arg3, float arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_vector3_array ret = default;
        double arg3_in = arg3;
        double arg4_in = arg4;
        void** call_args = stackalloc void*[4] { arg1, arg2, &arg3_in, &arg4_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertNativePackedVector3ArrayToSystemArray(ret);
    }

    internal static unsafe Vector3[] godot_icall_3_683(IntPtr method, IntPtr ptr, Vector3* arg1, Vector3* arg2, godot_array arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_vector3_array ret = default;
        void** call_args = stackalloc void*[3] { arg1, arg2, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertNativePackedVector3ArrayToSystemArray(ret);
    }

    internal static unsafe Vector3[] godot_icall_2_684(IntPtr method, IntPtr ptr, ReadOnlySpan<Vector3> arg1, Plane* arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_vector3_array ret = default;
        using godot_packed_vector3_array arg1_in = Marshaling.ConvertSystemArrayToNativePackedVector3Array(arg1);
        void** call_args = stackalloc void*[2] { &arg1_in, arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertNativePackedVector3ArrayToSystemArray(ret);
    }

    internal static unsafe int[] godot_icall_1_685(IntPtr method, IntPtr ptr, ReadOnlySpan<Vector3> arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_int32_array ret = default;
        using godot_packed_vector3_array arg1_in = Marshaling.ConvertSystemArrayToNativePackedVector3Array(arg1);
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertNativePackedInt32ArrayToSystemArray(ret);
    }

    internal static unsafe void godot_icall_2_686(IntPtr method, IntPtr ptr, float arg1, Color* arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double arg1_in = arg1;
        void** call_args = stackalloc void*[2] { &arg1_in, arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_2_687(IntPtr method, IntPtr ptr, int arg1, Color* arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        void** call_args = stackalloc void*[2] { &arg1_in, arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe Color godot_icall_1_688(IntPtr method, IntPtr ptr, int arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Color ret;
        long arg1_in = arg1;
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Color godot_icall_1_689(IntPtr method, IntPtr ptr, float arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Color ret;
        double arg1_in = arg1;
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe int godot_icall_5_690(IntPtr method, IntPtr ptr, godot_string_name arg1, int arg2, godot_string_name arg3, int arg4, godot_bool arg5)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        long arg2_in = arg2;
        long arg4_in = arg4;
        void** call_args = stackalloc void*[5] { &arg1, &arg2_in, &arg3, &arg4_in, &arg5 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe godot_bool godot_icall_4_691(IntPtr method, IntPtr ptr, godot_string_name arg1, int arg2, godot_string_name arg3, int arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_bool ret;
        long arg2_in = arg2;
        long arg4_in = arg4;
        void** call_args = stackalloc void*[4] { &arg1, &arg2_in, &arg3, &arg4_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe void godot_icall_4_692(IntPtr method, IntPtr ptr, godot_string_name arg1, int arg2, godot_string_name arg3, int arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg2_in = arg2;
        long arg4_in = arg4;
        void** call_args = stackalloc void*[4] { &arg1, &arg2_in, &arg3, &arg4_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_5_693(IntPtr method, IntPtr ptr, godot_string_name arg1, int arg2, godot_string_name arg3, int arg4, float arg5)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg2_in = arg2;
        long arg4_in = arg4;
        double arg5_in = arg5;
        void** call_args = stackalloc void*[5] { &arg1, &arg2_in, &arg3, &arg4_in, &arg5_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe int godot_icall_2_694(IntPtr method, IntPtr ptr, godot_string_name arg1, int arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        long arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe Godot.Collections.Dictionary godot_icall_2_695(IntPtr method, IntPtr ptr, Vector2* arg1, float arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_dictionary ret = default;
        double arg2_in = arg2;
        void** call_args = stackalloc void*[2] { arg1, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Godot.Collections.Dictionary.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe Godot.Collections.Array godot_icall_1_696(IntPtr method, IntPtr ptr, godot_string_name arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_array ret = default;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Godot.Collections.Array.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe Godot.Collections.Array godot_icall_1_697(IntPtr method, IntPtr ptr, Rect2* arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_array ret = default;
        void** call_args = stackalloc void*[1] { arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Godot.Collections.Array.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe Vector2[] godot_icall_2_698(IntPtr method, IntPtr ptr, Vector2* arg1, Vector2* arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_vector2_array ret = default;
        void** call_args = stackalloc void*[2] { arg1, arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertNativePackedVector2ArrayToSystemArray(ret);
    }

    internal static unsafe int godot_icall_4_699(IntPtr method, IntPtr ptr, godot_string_name arg1, int arg2, godot_string_name arg3, int arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        long arg2_in = arg2;
        long arg4_in = arg4;
        void** call_args = stackalloc void*[4] { &arg1, &arg2_in, &arg3, &arg4_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe void godot_icall_10_700(IntPtr method, IntPtr ptr, int arg1, godot_bool arg2, int arg3, Color* arg4, godot_bool arg5, int arg6, Color* arg7, IntPtr arg8, IntPtr arg9, godot_bool arg10)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        long arg3_in = arg3;
        long arg6_in = arg6;
        void** call_args = stackalloc void*[10] { &arg1_in, &arg2, &arg3_in, arg4, &arg5, &arg6_in, arg7, &arg8, &arg9, &arg10 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_2_701(IntPtr method, IntPtr ptr, int arg1, Variant arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        godot_variant arg2_in = (godot_variant)arg2.NativeVar;
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe Variant godot_icall_1_702(IntPtr method, IntPtr ptr, int arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_variant ret = default;
        long arg1_in = arg1;
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Variant.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe void godot_icall_3_703(IntPtr method, IntPtr ptr, Vector3I* arg1, int arg2, int arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg2_in = arg2;
        long arg3_in = arg3;
        void** call_args = stackalloc void*[3] { arg1, &arg2_in, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe int godot_icall_1_704(IntPtr method, IntPtr ptr, Vector3I* arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        void** call_args = stackalloc void*[1] { arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe Basis godot_icall_1_705(IntPtr method, IntPtr ptr, Vector3I* arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Basis ret;
        void** call_args = stackalloc void*[1] { arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Basis godot_icall_1_706(IntPtr method, IntPtr ptr, int arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Basis ret;
        long arg1_in = arg1;
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe int godot_icall_1_707(IntPtr method, IntPtr ptr, Basis* arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        void** call_args = stackalloc void*[1] { arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe Vector3I godot_icall_1_708(IntPtr method, IntPtr ptr, Vector3* arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Vector3I ret;
        void** call_args = stackalloc void*[1] { arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Vector3 godot_icall_1_709(IntPtr method, IntPtr ptr, Vector3I* arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Vector3 ret;
        void** call_args = stackalloc void*[1] { arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe void godot_icall_2_710(IntPtr method, IntPtr ptr, godot_bool arg1, float arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe int godot_icall_2_712(IntPtr method, IntPtr ptr, int arg1, ReadOnlySpan<byte> arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        long arg1_in = arg1;
        using godot_packed_byte_array arg2_in = Marshaling.ConvertSystemArrayToNativePackedByteArray(arg2);
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe int godot_icall_1_713(IntPtr method, IntPtr ptr, ReadOnlySpan<byte> arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        using godot_packed_byte_array arg1_in = Marshaling.ConvertSystemArrayToNativePackedByteArray(arg1);
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe int godot_icall_3_714(IntPtr method, IntPtr ptr, string arg1, int arg2, IntPtr arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        long arg2_in = arg2;
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2_in, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe int godot_icall_4_715(IntPtr method, IntPtr ptr, int arg1, string arg2, ReadOnlySpan<string> arg3, ReadOnlySpan<byte> arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        long arg1_in = arg1;
        using godot_string arg2_in = Marshaling.ConvertStringToNative(arg2);
        using godot_packed_string_array arg3_in = Marshaling.ConvertSystemArrayToNativePackedStringArray(arg3);
        using godot_packed_byte_array arg4_in = Marshaling.ConvertSystemArrayToNativePackedByteArray(arg4);
        void** call_args = stackalloc void*[4] { &arg1_in, &arg2_in, &arg3_in, &arg4_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe int godot_icall_4_716(IntPtr method, IntPtr ptr, int arg1, string arg2, ReadOnlySpan<string> arg3, string arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        long arg1_in = arg1;
        using godot_string arg2_in = Marshaling.ConvertStringToNative(arg2);
        using godot_packed_string_array arg3_in = Marshaling.ConvertSystemArrayToNativePackedStringArray(arg3);
        using godot_string arg4_in = Marshaling.ConvertStringToNative(arg4);
        void** call_args = stackalloc void*[4] { &arg1_in, &arg2_in, &arg3_in, &arg4_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe string godot_icall_1_717(IntPtr method, IntPtr ptr, godot_dictionary arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string ret = default;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertStringToManaged(ret);
    }

    internal static unsafe int godot_icall_4_718(IntPtr method, IntPtr ptr, string arg1, ReadOnlySpan<string> arg2, int arg3, string arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        using godot_packed_string_array arg2_in = Marshaling.ConvertSystemArrayToNativePackedStringArray(arg2);
        long arg3_in = arg3;
        using godot_string arg4_in = Marshaling.ConvertStringToNative(arg4);
        void** call_args = stackalloc void*[4] { &arg1_in, &arg2_in, &arg3_in, &arg4_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe int godot_icall_4_719(IntPtr method, IntPtr ptr, string arg1, ReadOnlySpan<string> arg2, int arg3, ReadOnlySpan<byte> arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        using godot_packed_string_array arg2_in = Marshaling.ConvertSystemArrayToNativePackedStringArray(arg2);
        long arg3_in = arg3;
        using godot_packed_byte_array arg4_in = Marshaling.ConvertSystemArrayToNativePackedByteArray(arg4);
        void** call_args = stackalloc void*[4] { &arg1_in, &arg2_in, &arg3_in, &arg4_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe void godot_icall_3_720(IntPtr method, IntPtr ptr, IntPtr arg1, float arg2, float arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double arg2_in = arg2;
        double arg3_in = arg3;
        void** call_args = stackalloc void*[3] { &arg1, &arg2_in, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe string[] godot_icall_2_721(IntPtr method, IntPtr ptr, string arg1, int arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_string_array ret = default;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        long arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertNativePackedStringArrayToSystemArray(ret);
    }

    internal static unsafe GodotObject godot_icall_4_722(IntPtr method, int arg1, int arg2, godot_bool arg3, int arg4)
    {
        using godot_ref ret = default;
        long arg1_in = arg1;
        long arg2_in = arg2;
        long arg4_in = arg4;
        void** call_args = stackalloc void*[4] { &arg1_in, &arg2_in, &arg3, &arg4_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, IntPtr.Zero, call_args, &ret);
        return InteropUtils.UnmanagedGetManaged(ret.Reference);
    }

    internal static unsafe GodotObject godot_icall_5_723(IntPtr method, int arg1, int arg2, godot_bool arg3, int arg4, ReadOnlySpan<byte> arg5)
    {
        using godot_ref ret = default;
        long arg1_in = arg1;
        long arg2_in = arg2;
        long arg4_in = arg4;
        using godot_packed_byte_array arg5_in = Marshaling.ConvertSystemArrayToNativePackedByteArray(arg5);
        void** call_args = stackalloc void*[5] { &arg1_in, &arg2_in, &arg3, &arg4_in, &arg5_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, IntPtr.Zero, call_args, &ret);
        return InteropUtils.UnmanagedGetManaged(ret.Reference);
    }

    internal static unsafe void godot_icall_5_724(IntPtr method, IntPtr ptr, int arg1, int arg2, godot_bool arg3, int arg4, ReadOnlySpan<byte> arg5)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        long arg2_in = arg2;
        long arg4_in = arg4;
        using godot_packed_byte_array arg5_in = Marshaling.ConvertSystemArrayToNativePackedByteArray(arg5);
        void** call_args = stackalloc void*[5] { &arg1_in, &arg2_in, &arg3, &arg4_in, &arg5_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe int godot_icall_2_725(IntPtr method, IntPtr ptr, string arg1, float arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        double arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe byte[] godot_icall_1_726(IntPtr method, IntPtr ptr, float arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_byte_array ret = default;
        double arg1_in = arg1;
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertNativePackedByteArrayToSystemArray(ret);
    }

    internal static unsafe byte[] godot_icall_1_727(IntPtr method, IntPtr ptr, godot_bool arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_byte_array ret = default;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertNativePackedByteArrayToSystemArray(ret);
    }

    internal static unsafe int godot_icall_3_728(IntPtr method, IntPtr ptr, string arg1, godot_bool arg2, float arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        double arg3_in = arg3;
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe byte[] godot_icall_2_729(IntPtr method, IntPtr ptr, godot_bool arg1, float arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_byte_array ret = default;
        double arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertNativePackedByteArrayToSystemArray(ret);
    }

    internal static unsafe int godot_icall_3_730(IntPtr method, IntPtr ptr, int arg1, int arg2, int arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        long arg1_in = arg1;
        long arg2_in = arg2;
        long arg3_in = arg3;
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2_in, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe void godot_icall_3_731(IntPtr method, IntPtr ptr, IntPtr arg1, Rect2I* arg2, Vector2I* arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[3] { &arg1, arg2, arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_4_732(IntPtr method, IntPtr ptr, IntPtr arg1, IntPtr arg2, Rect2I* arg3, Vector2I* arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[4] { &arg1, &arg2, arg3, arg4 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_2_733(IntPtr method, IntPtr ptr, Rect2I* arg1, Color* arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[2] { arg1, arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe Color godot_icall_2_734(IntPtr method, IntPtr ptr, int arg1, int arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Color ret;
        long arg1_in = arg1;
        long arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe void godot_icall_2_735(IntPtr method, IntPtr ptr, Vector2I* arg1, Color* arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[2] { arg1, arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_3_736(IntPtr method, IntPtr ptr, int arg1, int arg2, Color* arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        long arg2_in = arg2;
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2_in, arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe int godot_icall_2_737(IntPtr method, IntPtr ptr, ReadOnlySpan<byte> arg1, float arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        using godot_packed_byte_array arg1_in = Marshaling.ConvertSystemArrayToNativePackedByteArray(arg1);
        double arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe int godot_icall_6_738(IntPtr method, IntPtr ptr, int arg1, int arg2, int arg3, int arg4, godot_bool arg5, godot_array arg6)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        long arg1_in = arg1;
        long arg2_in = arg2;
        long arg3_in = arg3;
        long arg4_in = arg4;
        void** call_args = stackalloc void*[6] { &arg1_in, &arg2_in, &arg3_in, &arg4_in, &arg5, &arg6 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe int godot_icall_1_739(IntPtr method, IntPtr ptr, godot_array arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe void godot_icall_2_740(IntPtr method, IntPtr ptr, IntPtr arg1, int arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_1_741(IntPtr method, IntPtr ptr, Plane* arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[1] { arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_7_742(IntPtr method, IntPtr ptr, int arg1, godot_array arg2, godot_array arg3, godot_dictionary arg4, IntPtr arg5, string arg6, ulong arg7)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        using godot_string arg6_in = Marshaling.ConvertStringToNative(arg6);
        void** call_args = stackalloc void*[7] { &arg1_in, &arg2, &arg3, &arg4, &arg5, &arg6_in, &arg7 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe int[] godot_icall_2_743(IntPtr method, IntPtr ptr, int arg1, int arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_int32_array ret = default;
        long arg1_in = arg1;
        long arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertNativePackedInt32ArrayToSystemArray(ret);
    }

    internal static unsafe void godot_icall_3_744(IntPtr method, IntPtr ptr, float arg1, float arg2, godot_array arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double arg1_in = arg1;
        double arg2_in = arg2;
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2_in, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe godot_bool godot_icall_2_745(IntPtr method, IntPtr ptr, godot_string_name arg1, godot_bool arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_bool ret;
        void** call_args = stackalloc void*[2] { &arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe godot_bool godot_icall_3_746(IntPtr method, IntPtr ptr, godot_string_name arg1, IntPtr arg2, godot_bool arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_bool ret;
        void** call_args = stackalloc void*[3] { &arg1, &arg2, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe float godot_icall_2_747(IntPtr method, IntPtr ptr, godot_string_name arg1, godot_bool arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double ret;
        void** call_args = stackalloc void*[2] { &arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (float)ret;
    }

    internal static unsafe float godot_icall_2_748(IntPtr method, IntPtr ptr, godot_string_name arg1, godot_string_name arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double ret;
        void** call_args = stackalloc void*[2] { &arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (float)ret;
    }

    internal static unsafe Vector2 godot_icall_5_749(IntPtr method, IntPtr ptr, godot_string_name arg1, godot_string_name arg2, godot_string_name arg3, godot_string_name arg4, float arg5)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Vector2 ret;
        double arg5_in = arg5;
        void** call_args = stackalloc void*[5] { &arg1, &arg2, &arg3, &arg4, &arg5_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe void godot_icall_4_750(IntPtr method, IntPtr ptr, int arg1, float arg2, float arg3, float arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        double arg2_in = arg2;
        double arg3_in = arg3;
        double arg4_in = arg4;
        void** call_args = stackalloc void*[4] { &arg1_in, &arg2_in, &arg3_in, &arg4_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_2_751(IntPtr method, IntPtr ptr, godot_string_name arg1, float arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe godot_bool godot_icall_3_752(IntPtr method, IntPtr ptr, godot_string_name arg1, godot_bool arg2, godot_bool arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_bool ret;
        void** call_args = stackalloc void*[3] { &arg1, &arg2, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe godot_bool godot_icall_2_753(IntPtr method, IntPtr ptr, IntPtr arg1, godot_bool arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_bool ret;
        void** call_args = stackalloc void*[2] { &arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe GodotObject godot_icall_2_754(IntPtr method, IntPtr ptr, Transform2D* arg1, Vector2* arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_ref ret = default;
        void** call_args = stackalloc void*[2] { arg1, arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return InteropUtils.UnmanagedGetManaged(ret.Reference);
    }

    internal static unsafe string godot_icall_1_755(IntPtr method, IntPtr ptr, godot_string_name arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string ret = default;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertStringToManaged(ret);
    }

    internal static unsafe float godot_icall_1_756(IntPtr method, IntPtr ptr, godot_string_name arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double ret;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (float)ret;
    }

    internal static unsafe godot_bool godot_icall_2_757(IntPtr method, IntPtr ptr, godot_string_name arg1, IntPtr arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_bool ret;
        void** call_args = stackalloc void*[2] { &arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe godot_bool godot_icall_3_758(IntPtr method, IntPtr ptr, IntPtr arg1, godot_string_name arg2, godot_bool arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_bool ret;
        void** call_args = stackalloc void*[3] { &arg1, &arg2, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Godot.Collections.Dictionary godot_icall_1_759(IntPtr method, IntPtr ptr, godot_bool arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_dictionary ret = default;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Godot.Collections.Dictionary.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe GodotObject godot_icall_2_760(IntPtr method, IntPtr ptr, godot_bool arg1, IntPtr arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        IntPtr ret = default;
        void** call_args = stackalloc void*[2] { &arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return InteropUtils.UnmanagedGetManaged(ret);
    }

    internal static unsafe int godot_icall_3_761(IntPtr method, IntPtr ptr, string arg1, IntPtr arg2, godot_bool arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe int godot_icall_2_762(IntPtr method, IntPtr ptr, IntPtr arg1, godot_bool arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        void** call_args = stackalloc void*[2] { &arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe void godot_icall_2_763(IntPtr method, IntPtr ptr, int arg1, Rect2* arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        void** call_args = stackalloc void*[2] { &arg1_in, arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe Rect2 godot_icall_2_764(IntPtr method, IntPtr ptr, int arg1, godot_bool arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Rect2 ret;
        long arg1_in = arg1;
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe int godot_icall_2_765(IntPtr method, IntPtr ptr, Vector2* arg1, godot_bool arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        void** call_args = stackalloc void*[2] { arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe void godot_icall_3_766(IntPtr method, IntPtr ptr, int arg1, int arg2, Vector3* arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        long arg2_in = arg2;
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2_in, arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe Vector3 godot_icall_2_767(IntPtr method, IntPtr ptr, int arg1, int arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Vector3 ret;
        long arg1_in = arg1;
        long arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe void godot_icall_3_768(IntPtr method, IntPtr ptr, int arg1, int arg2, Quaternion* arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        long arg2_in = arg2;
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2_in, arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe Quaternion godot_icall_2_769(IntPtr method, IntPtr ptr, int arg1, int arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Quaternion ret;
        long arg1_in = arg1;
        long arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe string godot_icall_4_770(IntPtr method, Variant arg1, string arg2, godot_bool arg3, godot_bool arg4)
    {
        using godot_string ret = default;
        godot_variant arg1_in = (godot_variant)arg1.NativeVar;
        using godot_string arg2_in = Marshaling.ConvertStringToNative(arg2);
        void** call_args = stackalloc void*[4] { &arg1_in, &arg2_in, &arg3, &arg4 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, IntPtr.Zero, call_args, &ret);
        return Marshaling.ConvertStringToManaged(ret);
    }

    internal static unsafe Variant godot_icall_1_771(IntPtr method, string arg1)
    {
        godot_variant ret = default;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, IntPtr.Zero, call_args, &ret);
        return Variant.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe Variant godot_icall_0_772(IntPtr method, IntPtr ptr)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_variant ret = default;
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, null, &ret);
        return Variant.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe void godot_icall_1_773(IntPtr method, IntPtr ptr, Variant arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_variant arg1_in = (godot_variant)arg1.NativeVar;
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe Variant godot_icall_2_774(IntPtr method, Variant arg1, godot_bool arg2)
    {
        godot_variant ret = default;
        godot_variant arg1_in = (godot_variant)arg1.NativeVar;
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, IntPtr.Zero, call_args, &ret);
        return Variant.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe Variant godot_icall_2_775(IntPtr method, IntPtr ptr, Variant arg1, godot_bool arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_variant ret = default;
        godot_variant arg1_in = (godot_variant)arg1.NativeVar;
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Variant.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe Godot.Collections.Dictionary godot_icall_3_776(IntPtr method, IntPtr ptr, string arg1, Variant arg2, Variant arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_dictionary ret = default;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        godot_variant arg2_in = (godot_variant)arg2.NativeVar;
        godot_variant arg3_in = (godot_variant)arg3.NativeVar;
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2_in, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Godot.Collections.Dictionary.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe Godot.Collections.Dictionary godot_icall_2_777(IntPtr method, IntPtr ptr, Variant arg1, Variant arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_dictionary ret = default;
        godot_variant arg1_in = (godot_variant)arg1.NativeVar;
        godot_variant arg2_in = (godot_variant)arg2.NativeVar;
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Godot.Collections.Dictionary.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe Godot.Collections.Dictionary godot_icall_2_778(IntPtr method, IntPtr ptr, string arg1, Variant arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_dictionary ret = default;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        godot_variant arg2_in = (godot_variant)arg2.NativeVar;
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Godot.Collections.Dictionary.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe Godot.Collections.Dictionary godot_icall_3_779(IntPtr method, IntPtr ptr, int arg1, string arg2, Variant arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_dictionary ret = default;
        long arg1_in = arg1;
        using godot_string arg2_in = Marshaling.ConvertStringToNative(arg2);
        godot_variant arg3_in = (godot_variant)arg3.NativeVar;
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2_in, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Godot.Collections.Dictionary.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe Variant godot_icall_2_780(IntPtr method, IntPtr ptr, string arg1, godot_bool arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_variant ret = default;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Variant.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe GodotObject godot_icall_1_781(IntPtr method, IntPtr ptr, in Callable arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_ref ret = default;
        using godot_callable arg1_in = Marshaling.ConvertCallableToNative(in arg1);
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return InteropUtils.UnmanagedGetManaged(ret.Reference);
    }

    internal static unsafe Variant godot_icall_2_782(IntPtr method, IntPtr ptr, string arg1, ReadOnlySpan<Variant> arg2, godot_string_name caller)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        int vararg_length = arg2.Length;
        int total_length = 1 + vararg_length;
        Span<godot_variant.movable> varargs_span = vararg_length <= VarArgsSpanThreshold ?
            stackalloc godot_variant.movable[VarArgsSpanThreshold] :
            new godot_variant.movable[vararg_length];
        Span<IntPtr> call_args_span = total_length <= VarArgsSpanThreshold ?
            stackalloc IntPtr[VarArgsSpanThreshold] :
            new IntPtr[total_length];
        fixed (godot_variant.movable* varargs = &MemoryMarshal.GetReference(varargs_span))
        fixed (IntPtr* call_args = &MemoryMarshal.GetReference(call_args_span))
        {
            using godot_variant arg1_in = VariantUtils.CreateFromString(arg1);
            call_args[0] = new IntPtr(&arg1_in);
            for (int i = 0; i < vararg_length; i++)
            {
                varargs[i] = arg2[i].NativeVar;
                call_args[1 + i] = new IntPtr(&varargs[i]);
            }
            godot_variant ret = NativeFuncs.godotsharp_method_bind_call(method, ptr, (godot_variant**)call_args, total_length, out godot_variant_call_error vcall_error);
            ExceptionUtils.DebugCheckCallError(caller, ptr, (godot_variant**)call_args, total_length, vcall_error);
            return Variant.CreateTakingOwnershipOfDisposableValue(ret);
        }
    }

    internal static unsafe void godot_icall_3_783(IntPtr method, IntPtr ptr, ReadOnlySpan<byte> arg1, string arg2, string arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_byte_array arg1_in = Marshaling.ConvertSystemArrayToNativePackedByteArray(arg1);
        using godot_string arg2_in = Marshaling.ConvertStringToNative(arg2);
        using godot_string arg3_in = Marshaling.ConvertStringToNative(arg3);
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2_in, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe float godot_icall_2_784(IntPtr method, IntPtr ptr, int arg1, Vector3* arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double ret;
        long arg1_in = arg1;
        void** call_args = stackalloc void*[2] { &arg1_in, arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (float)ret;
    }

    internal static unsafe void godot_icall_4_785(IntPtr method, IntPtr ptr, godot_node_path arg1, Rect2* arg2, int arg3, int arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg3_in = arg3;
        long arg4_in = arg4;
        void** call_args = stackalloc void*[4] { &arg1, arg2, &arg3_in, &arg4_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_2_786(IntPtr method, IntPtr ptr, Vector2* arg1, int arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg2_in = arg2;
        void** call_args = stackalloc void*[2] { arg1, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe string godot_icall_2_787(IntPtr method, IntPtr ptr, Variant arg1, godot_bool arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string ret = default;
        godot_variant arg1_in = (godot_variant)arg1.NativeVar;
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertStringToManaged(ret);
    }

    internal static unsafe string godot_icall_1_788(IntPtr method, IntPtr ptr, ReadOnlySpan<byte> arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string ret = default;
        using godot_packed_byte_array arg1_in = Marshaling.ConvertSystemArrayToNativePackedByteArray(arg1);
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertStringToManaged(ret);
    }

    internal static unsafe byte[] godot_icall_1_789(IntPtr method, IntPtr ptr, string arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_byte_array ret = default;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertNativePackedByteArrayToSystemArray(ret);
    }

    internal static unsafe GodotObject godot_icall_2_790(IntPtr method, IntPtr ptr, godot_bool arg1, godot_bool arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_ref ret = default;
        void** call_args = stackalloc void*[2] { &arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return InteropUtils.UnmanagedGetManaged(ret.Reference);
    }

    internal static unsafe GodotObject godot_icall_1_791(IntPtr method, IntPtr ptr, float arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_ref ret = default;
        double arg1_in = arg1;
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return InteropUtils.UnmanagedGetManaged(ret.Reference);
    }

    internal static unsafe int godot_icall_2_792(IntPtr method, IntPtr ptr, IntPtr arg1, int arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        long arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe int godot_icall_2_793(IntPtr method, IntPtr ptr, IntPtr arg1, ulong arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        void** call_args = stackalloc void*[2] { &arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe void godot_icall_2_794(IntPtr method, IntPtr ptr, int arg1, Plane* arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        void** call_args = stackalloc void*[2] { &arg1_in, arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe Plane godot_icall_1_795(IntPtr method, IntPtr ptr, int arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Plane ret;
        long arg1_in = arg1;
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe void godot_icall_2_796(IntPtr method, IntPtr ptr, int arg1, ReadOnlySpan<int> arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        using godot_packed_int32_array arg2_in = Marshaling.ConvertSystemArrayToNativePackedInt32Array(arg2);
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe int[] godot_icall_1_797(IntPtr method, IntPtr ptr, int arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_int32_array ret = default;
        long arg1_in = arg1;
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertNativePackedInt32ArrayToSystemArray(ret);
    }

    internal static unsafe void godot_icall_2_798(IntPtr method, IntPtr ptr, int arg1, ReadOnlySpan<float> arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        using godot_packed_float32_array arg2_in = Marshaling.ConvertSystemArrayToNativePackedFloat32Array(arg2);
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe float[] godot_icall_1_799(IntPtr method, IntPtr ptr, int arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_float32_array ret = default;
        long arg1_in = arg1;
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertNativePackedFloat32ArrayToSystemArray(ret);
    }

    internal static unsafe void godot_icall_2_800(IntPtr method, IntPtr ptr, int arg1, Transform3D* arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        void** call_args = stackalloc void*[2] { &arg1_in, arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_2_801(IntPtr method, IntPtr ptr, int arg1, uint arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        long arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_2_802(IntPtr method, IntPtr ptr, int arg1, godot_array arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe Transform3D godot_icall_1_803(IntPtr method, IntPtr ptr, int arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Transform3D ret;
        long arg1_in = arg1;
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe void godot_icall_2_804(IntPtr method, IntPtr ptr, ReadOnlySpan<float> arg1, ReadOnlySpan<float> arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_float32_array arg1_in = Marshaling.ConvertSystemArrayToNativePackedFloat32Array(arg1);
        using godot_packed_float32_array arg2_in = Marshaling.ConvertSystemArrayToNativePackedFloat32Array(arg2);
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe int godot_icall_4_805(IntPtr method, IntPtr ptr, int arg1, IntPtr arg2, godot_string_name arg3, godot_array arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        long arg1_in = arg1;
        void** call_args = stackalloc void*[4] { &arg1_in, &arg2, &arg3, &arg4 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe int godot_icall_2_806(IntPtr method, IntPtr ptr, IntPtr arg1, Variant arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        godot_variant arg2_in = (godot_variant)arg2.NativeVar;
        void** call_args = stackalloc void*[2] { &arg1, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe void godot_icall_1_807(IntPtr method, godot_string_name arg1)
    {
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, IntPtr.Zero, call_args, null);
    }

    internal static unsafe StringName godot_icall_0_808(IntPtr method)
    {
        godot_string_name ret = default;
        NativeFuncs.godotsharp_method_bind_ptrcall(method, IntPtr.Zero, null, &ret);
        return StringName.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe GodotObject godot_icall_0_809(IntPtr method)
    {
        using godot_ref ret = default;
        NativeFuncs.godotsharp_method_bind_ptrcall(method, IntPtr.Zero, null, &ret);
        return InteropUtils.UnmanagedGetManaged(ret.Reference);
    }

    internal static unsafe GodotObject godot_icall_1_810(IntPtr method, IntPtr ptr, Variant arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        IntPtr ret = default;
        godot_variant arg1_in = (godot_variant)arg1.NativeVar;
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return InteropUtils.UnmanagedGetManaged(ret);
    }

    internal static unsafe Callable godot_icall_0_811(IntPtr method, IntPtr ptr)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_callable ret = default;
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, null, &ret);
        return Marshaling.ConvertCallableToManaged(in ret);
    }

    internal static unsafe Vector2 godot_icall_1_812(IntPtr method, IntPtr ptr, Rid arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Vector2 ret;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe void godot_icall_2_813(IntPtr method, IntPtr ptr, Rid arg1, Vector2I* arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[2] { &arg1, arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_2_814(IntPtr method, IntPtr ptr, Rid arg1, in Callable arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_callable arg2_in = Marshaling.ConvertCallableToNative(in arg2);
        void** call_args = stackalloc void*[2] { &arg1, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe Callable godot_icall_1_815(IntPtr method, IntPtr ptr, Rid arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_callable ret = default;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertCallableToManaged(in ret);
    }

    internal static unsafe void godot_icall_2_816(IntPtr method, IntPtr ptr, Rid arg1, float arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe float godot_icall_1_817(IntPtr method, IntPtr ptr, Rid arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double ret;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (float)ret;
    }

    internal static unsafe int godot_icall_5_818(IntPtr method, IntPtr ptr, Rid arg1, string arg2, Rid arg3, Variant arg4, int arg5)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        using godot_string arg2_in = Marshaling.ConvertStringToNative(arg2);
        godot_variant arg4_in = (godot_variant)arg4.NativeVar;
        long arg5_in = arg5;
        void** call_args = stackalloc void*[5] { &arg1, &arg2_in, &arg3, &arg4_in, &arg5_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe int godot_icall_7_819(IntPtr method, IntPtr ptr, Rid arg1, string arg2, in Callable arg3, in Callable arg4, Variant arg5, int arg6, int arg7)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        using godot_string arg2_in = Marshaling.ConvertStringToNative(arg2);
        using godot_callable arg3_in = Marshaling.ConvertCallableToNative(in arg3);
        using godot_callable arg4_in = Marshaling.ConvertCallableToNative(in arg4);
        godot_variant arg5_in = (godot_variant)arg5.NativeVar;
        long arg6_in = arg6;
        long arg7_in = arg7;
        void** call_args = stackalloc void*[7] { &arg1, &arg2_in, &arg3_in, &arg4_in, &arg5_in, &arg6_in, &arg7_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe int godot_icall_8_820(IntPtr method, IntPtr ptr, Rid arg1, IntPtr arg2, string arg3, in Callable arg4, in Callable arg5, Variant arg6, int arg7, int arg8)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        using godot_string arg3_in = Marshaling.ConvertStringToNative(arg3);
        using godot_callable arg4_in = Marshaling.ConvertCallableToNative(in arg4);
        using godot_callable arg5_in = Marshaling.ConvertCallableToNative(in arg5);
        godot_variant arg6_in = (godot_variant)arg6.NativeVar;
        long arg7_in = arg7;
        long arg8_in = arg8;
        void** call_args = stackalloc void*[8] { &arg1, &arg2, &arg3_in, &arg4_in, &arg5_in, &arg6_in, &arg7_in, &arg8_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe int godot_icall_9_821(IntPtr method, IntPtr ptr, Rid arg1, string arg2, int arg3, int arg4, in Callable arg5, in Callable arg6, Variant arg7, int arg8, int arg9)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        using godot_string arg2_in = Marshaling.ConvertStringToNative(arg2);
        long arg3_in = arg3;
        long arg4_in = arg4;
        using godot_callable arg5_in = Marshaling.ConvertCallableToNative(in arg5);
        using godot_callable arg6_in = Marshaling.ConvertCallableToNative(in arg6);
        godot_variant arg7_in = (godot_variant)arg7.NativeVar;
        long arg8_in = arg8;
        long arg9_in = arg9;
        void** call_args = stackalloc void*[9] { &arg1, &arg2_in, &arg3_in, &arg4_in, &arg5_in, &arg6_in, &arg7_in, &arg8_in, &arg9_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe int godot_icall_2_822(IntPtr method, IntPtr ptr, Rid arg1, int arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        long arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe int godot_icall_2_823(IntPtr method, IntPtr ptr, Rid arg1, string arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        using godot_string arg2_in = Marshaling.ConvertStringToNative(arg2);
        void** call_args = stackalloc void*[2] { &arg1, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe int godot_icall_2_824(IntPtr method, IntPtr ptr, Rid arg1, Variant arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        godot_variant arg2_in = (godot_variant)arg2.NativeVar;
        void** call_args = stackalloc void*[2] { &arg1, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe int godot_icall_2_825(IntPtr method, IntPtr ptr, Rid arg1, Rid arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        void** call_args = stackalloc void*[2] { &arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe godot_bool godot_icall_2_826(IntPtr method, IntPtr ptr, Rid arg1, int arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_bool ret;
        long arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Callable godot_icall_2_827(IntPtr method, IntPtr ptr, Rid arg1, int arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_callable ret = default;
        long arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertCallableToManaged(in ret);
    }

    internal static unsafe Variant godot_icall_2_828(IntPtr method, IntPtr ptr, Rid arg1, int arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_variant ret = default;
        long arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Variant.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe string godot_icall_2_829(IntPtr method, IntPtr ptr, Rid arg1, int arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string ret = default;
        long arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertStringToManaged(ret);
    }

    internal static unsafe Rid godot_icall_2_830(IntPtr method, IntPtr ptr, Rid arg1, int arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Rid ret;
        long arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe GodotObject godot_icall_2_831(IntPtr method, IntPtr ptr, Rid arg1, int arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_ref ret = default;
        long arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return InteropUtils.UnmanagedGetManaged(ret.Reference);
    }

    internal static unsafe void godot_icall_3_832(IntPtr method, IntPtr ptr, Rid arg1, int arg2, Variant arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg2_in = arg2;
        godot_variant arg3_in = (godot_variant)arg3.NativeVar;
        void** call_args = stackalloc void*[3] { &arg1, &arg2_in, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_3_833(IntPtr method, IntPtr ptr, Rid arg1, int arg2, Rid arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg2_in = arg2;
        void** call_args = stackalloc void*[3] { &arg1, &arg2_in, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_3_834(IntPtr method, IntPtr ptr, Rid arg1, int arg2, IntPtr arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg2_in = arg2;
        void** call_args = stackalloc void*[3] { &arg1, &arg2_in, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe int godot_icall_1_835(IntPtr method, IntPtr ptr, Rid arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe void godot_icall_4_836(IntPtr method, IntPtr ptr, IntPtr arg1, IntPtr arg2, IntPtr arg3, in Callable arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_callable arg4_in = Marshaling.ConvertCallableToNative(in arg4);
        void** call_args = stackalloc void*[4] { &arg1, &arg2, &arg3, &arg4_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_3_837(IntPtr method, IntPtr ptr, IntPtr arg1, IntPtr arg2, in Callable arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_callable arg3_in = Marshaling.ConvertCallableToNative(in arg3);
        void** call_args = stackalloc void*[3] { &arg1, &arg2, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_2_838(IntPtr method, IntPtr ptr, ReadOnlySpan<Vector2> arg1, godot_bool arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_vector2_array arg1_in = Marshaling.ConvertSystemArrayToNativePackedVector2Array(arg1);
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_2_839(IntPtr method, IntPtr ptr, ReadOnlySpan<float> arg1, ReadOnlySpan<int> arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_float32_array arg1_in = Marshaling.ConvertSystemArrayToNativePackedFloat32Array(arg1);
        using godot_packed_int32_array arg2_in = Marshaling.ConvertSystemArrayToNativePackedInt32Array(arg2);
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_2_840(IntPtr method, IntPtr ptr, IntPtr arg1, Transform3D* arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[2] { &arg1, arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_2_841(IntPtr method, IntPtr ptr, godot_array arg1, Transform3D* arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[2] { &arg1, arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_2_842(IntPtr method, IntPtr ptr, ReadOnlySpan<Vector3> arg1, Transform3D* arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_vector3_array arg1_in = Marshaling.ConvertSystemArrayToNativePackedVector3Array(arg1);
        void** call_args = stackalloc void*[2] { &arg1_in, arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_4_843(IntPtr method, IntPtr ptr, ReadOnlySpan<Vector3> arg1, float arg2, float arg3, godot_bool arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_vector3_array arg1_in = Marshaling.ConvertSystemArrayToNativePackedVector3Array(arg1);
        double arg2_in = arg2;
        double arg3_in = arg3;
        void** call_args = stackalloc void*[4] { &arg1_in, &arg2_in, &arg3_in, &arg4 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_1_844(IntPtr method, IntPtr ptr, ReadOnlySpan<long> arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_int64_array arg1_in = Marshaling.ConvertSystemArrayToNativePackedInt64Array(arg1);
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_2_845(IntPtr method, IntPtr ptr, int arg1, ReadOnlySpan<Vector2> arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        using godot_packed_vector2_array arg2_in = Marshaling.ConvertSystemArrayToNativePackedVector2Array(arg2);
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe Vector2[] godot_icall_5_846(IntPtr method, IntPtr ptr, Rid arg1, Vector2* arg2, Vector2* arg3, godot_bool arg4, uint arg5)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_vector2_array ret = default;
        long arg5_in = arg5;
        void** call_args = stackalloc void*[5] { &arg1, arg2, arg3, &arg4, &arg5_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertNativePackedVector2ArrayToSystemArray(ret);
    }

    internal static unsafe Vector2 godot_icall_2_847(IntPtr method, IntPtr ptr, Rid arg1, Vector2* arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Vector2 ret;
        void** call_args = stackalloc void*[2] { &arg1, arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Rid godot_icall_2_848(IntPtr method, IntPtr ptr, Rid arg1, Vector2* arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Rid ret;
        void** call_args = stackalloc void*[2] { &arg1, arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Godot.Collections.Array godot_icall_1_849(IntPtr method, IntPtr ptr, Rid arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_array ret = default;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Godot.Collections.Array.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe uint godot_icall_1_850(IntPtr method, IntPtr ptr, Rid arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (uint)(ret);
    }

    internal static unsafe Vector2 godot_icall_3_851(IntPtr method, IntPtr ptr, Rid arg1, uint arg2, godot_bool arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Vector2 ret;
        long arg2_in = arg2;
        void** call_args = stackalloc void*[3] { &arg1, &arg2_in, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe void godot_icall_2_852(IntPtr method, IntPtr ptr, Rid arg1, ulong arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[2] { &arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe ulong godot_icall_1_853(IntPtr method, IntPtr ptr, Rid arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        ulong ret;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe godot_bool godot_icall_2_854(IntPtr method, IntPtr ptr, Rid arg1, Vector2* arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_bool ret;
        void** call_args = stackalloc void*[2] { &arg1, arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Rid godot_icall_1_855(IntPtr method, IntPtr ptr, Rid arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Rid ret;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe void godot_icall_2_856(IntPtr method, IntPtr ptr, Rid arg1, uint arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe Transform2D godot_icall_1_857(IntPtr method, IntPtr ptr, Rid arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Transform2D ret;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe void godot_icall_2_858(IntPtr method, IntPtr ptr, Rid arg1, IntPtr arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[2] { &arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe Vector2 godot_icall_2_859(IntPtr method, IntPtr ptr, Rid arg1, int arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Vector2 ret;
        long arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Rect2 godot_icall_1_860(IntPtr method, IntPtr ptr, Rid arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Rect2 ret;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe void godot_icall_2_861(IntPtr method, IntPtr ptr, Rid arg1, Vector2* arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[2] { &arg1, arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_2_862(IntPtr method, IntPtr ptr, Rid arg1, ReadOnlySpan<Vector2> arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_vector2_array arg2_in = Marshaling.ConvertSystemArrayToNativePackedVector2Array(arg2);
        void** call_args = stackalloc void*[2] { &arg1, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe Vector2[] godot_icall_1_863(IntPtr method, IntPtr ptr, Rid arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_vector2_array ret = default;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertNativePackedVector2ArrayToSystemArray(ret);
    }

    internal static unsafe Vector2[] godot_icall_2_864(IntPtr method, IntPtr ptr, ReadOnlySpan<Vector2> arg1, float arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_vector2_array ret = default;
        using godot_packed_vector2_array arg1_in = Marshaling.ConvertSystemArrayToNativePackedVector2Array(arg1);
        double arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertNativePackedVector2ArrayToSystemArray(ret);
    }

    internal static unsafe void godot_icall_2_865(IntPtr method, IntPtr ptr, Rid arg1, Vector3* arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[2] { &arg1, arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe Vector3 godot_icall_1_866(IntPtr method, IntPtr ptr, Rid arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Vector3 ret;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Vector3[] godot_icall_5_867(IntPtr method, IntPtr ptr, Rid arg1, Vector3* arg2, Vector3* arg3, godot_bool arg4, uint arg5)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_vector3_array ret = default;
        long arg5_in = arg5;
        void** call_args = stackalloc void*[5] { &arg1, arg2, arg3, &arg4, &arg5_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertNativePackedVector3ArrayToSystemArray(ret);
    }

    internal static unsafe Vector3 godot_icall_4_868(IntPtr method, IntPtr ptr, Rid arg1, Vector3* arg2, Vector3* arg3, godot_bool arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Vector3 ret;
        void** call_args = stackalloc void*[4] { &arg1, arg2, arg3, &arg4 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Vector3 godot_icall_2_869(IntPtr method, IntPtr ptr, Rid arg1, Vector3* arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Vector3 ret;
        void** call_args = stackalloc void*[2] { &arg1, arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Rid godot_icall_2_870(IntPtr method, IntPtr ptr, Rid arg1, Vector3* arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Rid ret;
        void** call_args = stackalloc void*[2] { &arg1, arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Vector3 godot_icall_3_871(IntPtr method, IntPtr ptr, Rid arg1, uint arg2, godot_bool arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Vector3 ret;
        long arg2_in = arg2;
        void** call_args = stackalloc void*[3] { &arg1, &arg2_in, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe godot_bool godot_icall_2_872(IntPtr method, IntPtr ptr, Rid arg1, Vector3* arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_bool ret;
        void** call_args = stackalloc void*[2] { &arg1, arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe void godot_icall_2_873(IntPtr method, IntPtr ptr, Rid arg1, Transform3D* arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[2] { &arg1, arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe Transform3D godot_icall_1_874(IntPtr method, IntPtr ptr, Rid arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Transform3D ret;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Vector3 godot_icall_2_875(IntPtr method, IntPtr ptr, Rid arg1, int arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Vector3 ret;
        long arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Aabb godot_icall_1_876(IntPtr method, IntPtr ptr, Rid arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Aabb ret;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe void godot_icall_2_877(IntPtr method, IntPtr ptr, Rid arg1, ReadOnlySpan<Vector3> arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_vector3_array arg2_in = Marshaling.ConvertSystemArrayToNativePackedVector3Array(arg2);
        void** call_args = stackalloc void*[2] { &arg1, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe Vector3[] godot_icall_1_878(IntPtr method, IntPtr ptr, Rid arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_vector3_array ret = default;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertNativePackedVector3ArrayToSystemArray(ret);
    }

    internal static unsafe Vector3[] godot_icall_2_879(IntPtr method, IntPtr ptr, ReadOnlySpan<Vector3> arg1, float arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_vector3_array ret = default;
        using godot_packed_vector3_array arg1_in = Marshaling.ConvertSystemArrayToNativePackedVector3Array(arg1);
        double arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertNativePackedVector3ArrayToSystemArray(ret);
    }

    internal static unsafe void godot_icall_0_880(IntPtr method)
    {
        NativeFuncs.godotsharp_method_bind_ptrcall(method, IntPtr.Zero, null, null);
    }

    internal static unsafe Godot.Collections.Array godot_icall_0_881(IntPtr method)
    {
        godot_array ret = default;
        NativeFuncs.godotsharp_method_bind_ptrcall(method, IntPtr.Zero, null, &ret);
        return Godot.Collections.Array.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe void godot_icall_3_882(IntPtr method, IntPtr ptr, IntPtr arg1, godot_bool arg2, int arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg3_in = arg3;
        void** call_args = stackalloc void*[3] { &arg1, &arg2, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe GodotObject godot_icall_2_883(IntPtr method, IntPtr ptr, int arg1, godot_bool arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        IntPtr ret = default;
        long arg1_in = arg1;
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return InteropUtils.UnmanagedGetManaged(ret);
    }

    internal static unsafe GodotObject godot_icall_1_884(IntPtr method, IntPtr ptr, godot_node_path arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        IntPtr ret = default;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return InteropUtils.UnmanagedGetManaged(ret);
    }

    internal static unsafe GodotObject godot_icall_3_885(IntPtr method, IntPtr ptr, string arg1, godot_bool arg2, godot_bool arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        IntPtr ret = default;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return InteropUtils.UnmanagedGetManaged(ret);
    }

    internal static unsafe Godot.Collections.Array godot_icall_4_886(IntPtr method, IntPtr ptr, string arg1, string arg2, godot_bool arg3, godot_bool arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_array ret = default;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        using godot_string arg2_in = Marshaling.ConvertStringToNative(arg2);
        void** call_args = stackalloc void*[4] { &arg1_in, &arg2_in, &arg3, &arg4 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Godot.Collections.Array.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe Godot.Collections.Array godot_icall_1_887(IntPtr method, IntPtr ptr, godot_node_path arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_array ret = default;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Godot.Collections.Array.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe void godot_icall_3_888(IntPtr method, IntPtr ptr, godot_string_name arg1, godot_array arg2, godot_bool arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[3] { &arg1, &arg2, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe string godot_icall_2_889(IntPtr method, IntPtr ptr, string arg1, godot_string_name arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string ret = default;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertStringToManaged(ret);
    }

    internal static unsafe string godot_icall_4_890(IntPtr method, IntPtr ptr, string arg1, godot_string_name arg2, int arg3, godot_string_name arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string ret = default;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        long arg3_in = arg3;
        void** call_args = stackalloc void*[4] { &arg1_in, &arg2, &arg3_in, &arg4 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertStringToManaged(ret);
    }

    internal static unsafe int godot_icall_2_891(IntPtr method, IntPtr ptr, godot_string_name arg1, ReadOnlySpan<Variant> arg2, godot_string_name caller)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        int vararg_length = arg2.Length;
        int total_length = 1 + vararg_length;
        Span<godot_variant.movable> varargs_span = vararg_length <= VarArgsSpanThreshold ?
            stackalloc godot_variant.movable[VarArgsSpanThreshold] :
            new godot_variant.movable[vararg_length];
        Span<IntPtr> call_args_span = total_length <= VarArgsSpanThreshold ?
            stackalloc IntPtr[VarArgsSpanThreshold] :
            new IntPtr[total_length];
        fixed (godot_variant.movable* varargs = &MemoryMarshal.GetReference(varargs_span))
        fixed (IntPtr* call_args = &MemoryMarshal.GetReference(call_args_span))
        {
            using godot_variant arg1_in = VariantUtils.CreateFromStringName(arg1);
            call_args[0] = new IntPtr(&arg1_in);
            for (int i = 0; i < vararg_length; i++)
            {
                varargs[i] = arg2[i].NativeVar;
                call_args[1 + i] = new IntPtr(&varargs[i]);
            }
            using godot_variant vararg_ret = NativeFuncs.godotsharp_method_bind_call(method, ptr, (godot_variant**)call_args, total_length, out godot_variant_call_error vcall_error);
            ExceptionUtils.DebugCheckCallError(caller, ptr, (godot_variant**)call_args, total_length, vcall_error);
            ret = VariantUtils.ConvertToInt64(vararg_ret);
            return (int)(ret);
        }
    }

    internal static unsafe int godot_icall_3_892(IntPtr method, IntPtr ptr, long arg1, godot_string_name arg2, ReadOnlySpan<Variant> arg3, godot_string_name caller)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
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
            using godot_variant arg1_in = VariantUtils.CreateFromInt(arg1);
            call_args[0] = new IntPtr(&arg1_in);
            using godot_variant arg2_in = VariantUtils.CreateFromStringName(arg2);
            call_args[1] = new IntPtr(&arg2_in);
            for (int i = 0; i < vararg_length; i++)
            {
                varargs[i] = arg3[i].NativeVar;
                call_args[2 + i] = new IntPtr(&varargs[i]);
            }
            using godot_variant vararg_ret = NativeFuncs.godotsharp_method_bind_call(method, ptr, (godot_variant**)call_args, total_length, out godot_variant_call_error vcall_error);
            ExceptionUtils.DebugCheckCallError(caller, ptr, (godot_variant**)call_args, total_length, vcall_error);
            ret = VariantUtils.ConvertToInt64(vararg_ret);
            return (int)(ret);
        }
    }

    internal static unsafe Variant godot_icall_2_893(IntPtr method, IntPtr ptr, godot_string_name arg1, ReadOnlySpan<Variant> arg2, godot_string_name caller)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        int vararg_length = arg2.Length;
        int total_length = 1 + vararg_length;
        Span<godot_variant.movable> varargs_span = vararg_length <= VarArgsSpanThreshold ?
            stackalloc godot_variant.movable[VarArgsSpanThreshold] :
            new godot_variant.movable[vararg_length];
        Span<IntPtr> call_args_span = total_length <= VarArgsSpanThreshold ?
            stackalloc IntPtr[VarArgsSpanThreshold] :
            new IntPtr[total_length];
        fixed (godot_variant.movable* varargs = &MemoryMarshal.GetReference(varargs_span))
        fixed (IntPtr* call_args = &MemoryMarshal.GetReference(call_args_span))
        {
            using godot_variant arg1_in = VariantUtils.CreateFromStringName(arg1);
            call_args[0] = new IntPtr(&arg1_in);
            for (int i = 0; i < vararg_length; i++)
            {
                varargs[i] = arg2[i].NativeVar;
                call_args[1 + i] = new IntPtr(&varargs[i]);
            }
            godot_variant ret = NativeFuncs.godotsharp_method_bind_call(method, ptr, (godot_variant**)call_args, total_length, out godot_variant_call_error vcall_error);
            ExceptionUtils.DebugCheckCallError(caller, ptr, (godot_variant**)call_args, total_length, vcall_error);
            return Variant.CreateTakingOwnershipOfDisposableValue(ret);
        }
    }

    internal static unsafe void godot_icall_2_894(IntPtr method, IntPtr ptr, float arg1, godot_bool arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double arg1_in = arg1;
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe Transform2D godot_icall_1_895(IntPtr method, IntPtr ptr, IntPtr arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Transform2D ret;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe void godot_icall_3_896(IntPtr method, IntPtr ptr, IntPtr arg1, int arg2, Transform3D* arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg2_in = arg2;
        void** call_args = stackalloc void*[3] { &arg1, &arg2_in, arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_2_897(IntPtr method, IntPtr ptr, Vector3* arg1, float arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double arg2_in = arg2;
        void** call_args = stackalloc void*[2] { arg1, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_3_898(IntPtr method, IntPtr ptr, Vector3* arg1, Vector3* arg2, godot_bool arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[3] { arg1, arg2, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_4_899(IntPtr method, IntPtr ptr, Vector3* arg1, Vector3* arg2, Vector3* arg3, godot_bool arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[4] { arg1, arg2, arg3, &arg4 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe float godot_icall_2_900(IntPtr method, IntPtr ptr, float arg1, float arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double ret;
        double arg1_in = arg1;
        double arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (float)ret;
    }

    internal static unsafe float godot_icall_3_901(IntPtr method, IntPtr ptr, float arg1, float arg2, float arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double ret;
        double arg1_in = arg1;
        double arg2_in = arg2;
        double arg3_in = arg3;
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2_in, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (float)ret;
    }

    internal static unsafe GodotObject godot_icall_5_902(IntPtr method, IntPtr ptr, int arg1, int arg2, godot_bool arg3, godot_bool arg4, godot_bool arg5)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_ref ret = default;
        long arg1_in = arg1;
        long arg2_in = arg2;
        void** call_args = stackalloc void*[5] { &arg1_in, &arg2_in, &arg3, &arg4, &arg5 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return InteropUtils.UnmanagedGetManaged(ret.Reference);
    }

    internal static unsafe GodotObject godot_icall_6_903(IntPtr method, IntPtr ptr, int arg1, int arg2, godot_bool arg3, godot_bool arg4, float arg5, godot_bool arg6)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_ref ret = default;
        long arg1_in = arg1;
        long arg2_in = arg2;
        double arg5_in = arg5;
        void** call_args = stackalloc void*[6] { &arg1_in, &arg2_in, &arg3, &arg4, &arg5_in, &arg6 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return InteropUtils.UnmanagedGetManaged(ret.Reference);
    }

    internal static unsafe Godot.Collections.Array godot_icall_5_904(IntPtr method, IntPtr ptr, int arg1, int arg2, int arg3, godot_bool arg4, godot_bool arg5)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_array ret = default;
        long arg1_in = arg1;
        long arg2_in = arg2;
        long arg3_in = arg3;
        void** call_args = stackalloc void*[5] { &arg1_in, &arg2_in, &arg3_in, &arg4, &arg5 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Godot.Collections.Array.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe Godot.Collections.Array godot_icall_6_905(IntPtr method, IntPtr ptr, int arg1, int arg2, int arg3, godot_bool arg4, float arg5, godot_bool arg6)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_array ret = default;
        long arg1_in = arg1;
        long arg2_in = arg2;
        long arg3_in = arg3;
        double arg5_in = arg5;
        void** call_args = stackalloc void*[6] { &arg1_in, &arg2_in, &arg3_in, &arg4, &arg5_in, &arg6 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Godot.Collections.Array.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe string godot_icall_4_906(IntPtr method, IntPtr ptr, string arg1, int arg2, int arg3, godot_bool arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string ret = default;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        long arg2_in = arg2;
        long arg3_in = arg3;
        void** call_args = stackalloc void*[4] { &arg1_in, &arg2_in, &arg3_in, &arg4 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertStringToManaged(ret);
    }

    internal static unsafe string[] godot_icall_7_907(IntPtr method, IntPtr ptr, string arg1, string arg2, string arg3, string arg4, int arg5, int arg6, godot_bool arg7)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_string_array ret = default;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        using godot_string arg2_in = Marshaling.ConvertStringToNative(arg2);
        using godot_string arg3_in = Marshaling.ConvertStringToNative(arg3);
        using godot_string arg4_in = Marshaling.ConvertStringToNative(arg4);
        long arg5_in = arg5;
        long arg6_in = arg6;
        void** call_args = stackalloc void*[7] { &arg1_in, &arg2_in, &arg3_in, &arg4_in, &arg5_in, &arg6_in, &arg7 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertNativePackedStringArrayToSystemArray(ret);
    }

    internal static unsafe string godot_icall_1_908(IntPtr method, IntPtr ptr, long arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string ret = default;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertStringToManaged(ret);
    }

    internal static unsafe int godot_icall_5_909(IntPtr method, IntPtr ptr, string arg1, ReadOnlySpan<string> arg2, godot_array arg3, godot_bool arg4, godot_bool arg5)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        using godot_packed_string_array arg2_in = Marshaling.ConvertSystemArrayToNativePackedStringArray(arg2);
        void** call_args = stackalloc void*[5] { &arg1_in, &arg2_in, &arg3, &arg4, &arg5 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe Godot.Collections.Dictionary godot_icall_3_910(IntPtr method, IntPtr ptr, string arg1, ReadOnlySpan<string> arg2, godot_bool arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_dictionary ret = default;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        using godot_packed_string_array arg2_in = Marshaling.ConvertSystemArrayToNativePackedStringArray(arg2);
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2_in, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Godot.Collections.Dictionary.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe int godot_icall_3_911(IntPtr method, IntPtr ptr, string arg1, ReadOnlySpan<string> arg2, godot_bool arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        using godot_packed_string_array arg2_in = Marshaling.ConvertSystemArrayToNativePackedStringArray(arg2);
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2_in, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe int godot_icall_1_912(IntPtr method, IntPtr ptr, ReadOnlySpan<string> arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        using godot_packed_string_array arg1_in = Marshaling.ConvertSystemArrayToNativePackedStringArray(arg1);
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe void godot_icall_2_913(IntPtr method, IntPtr ptr, godot_bool arg1, ReadOnlySpan<string> arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_string_array arg2_in = Marshaling.ConvertSystemArrayToNativePackedStringArray(arg2);
        void** call_args = stackalloc void*[2] { &arg1, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe string godot_icall_2_914(IntPtr method, IntPtr ptr, int arg1, godot_bool arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string ret = default;
        long arg1_in = arg1;
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertStringToManaged(ret);
    }

    internal static unsafe Godot.Collections.Dictionary godot_icall_2_915(IntPtr method, IntPtr ptr, string arg1, ReadOnlySpan<string> arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_dictionary ret = default;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        using godot_packed_string_array arg2_in = Marshaling.ConvertSystemArrayToNativePackedStringArray(arg2);
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Godot.Collections.Dictionary.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe void godot_icall_2_916(IntPtr method, IntPtr ptr, godot_node_path arg1, Variant arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_variant arg2_in = (godot_variant)arg2.NativeVar;
        void** call_args = stackalloc void*[2] { &arg1, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe Variant godot_icall_1_917(IntPtr method, IntPtr ptr, godot_node_path arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_variant ret = default;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Variant.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe Variant godot_icall_2_918(IntPtr method, IntPtr ptr, godot_string_name arg1, Variant arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_variant ret = default;
        godot_variant arg2_in = (godot_variant)arg2.NativeVar;
        void** call_args = stackalloc void*[2] { &arg1, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Variant.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe Variant godot_icall_2_919(IntPtr method, IntPtr ptr, godot_string_name arg1, godot_array arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_variant ret = default;
        void** call_args = stackalloc void*[2] { &arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Variant.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe int godot_icall_3_920(IntPtr method, IntPtr ptr, godot_string_name arg1, in Callable arg2, uint arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        using godot_callable arg2_in = Marshaling.ConvertCallableToNative(in arg2);
        long arg3_in = arg3;
        void** call_args = stackalloc void*[3] { &arg1, &arg2_in, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe godot_bool godot_icall_2_921(IntPtr method, IntPtr ptr, godot_string_name arg1, in Callable arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_bool ret;
        using godot_callable arg2_in = Marshaling.ConvertCallableToNative(in arg2);
        void** call_args = stackalloc void*[2] { &arg1, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe string godot_icall_2_922(IntPtr method, IntPtr ptr, godot_string_name arg1, godot_string_name arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string ret = default;
        void** call_args = stackalloc void*[2] { &arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertStringToManaged(ret);
    }

    internal static unsafe string godot_icall_4_923(IntPtr method, IntPtr ptr, godot_string_name arg1, godot_string_name arg2, int arg3, godot_string_name arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string ret = default;
        long arg3_in = arg3;
        void** call_args = stackalloc void*[4] { &arg1, &arg2, &arg3_in, &arg4 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertStringToManaged(ret);
    }

    internal static unsafe godot_bool godot_icall_3_924(IntPtr method, IntPtr ptr, ulong arg1, string arg2, godot_array arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_bool ret;
        using godot_string arg2_in = Marshaling.ConvertStringToNative(arg2);
        void** call_args = stackalloc void*[3] { &arg1, &arg2_in, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe godot_bool godot_icall_1_925(IntPtr method, godot_bool arg1)
    {
        godot_bool ret;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, IntPtr.Zero, call_args, &ret);
        return ret;
    }

    internal static unsafe ulong godot_icall_1_926(IntPtr method, IntPtr ptr, string arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        ulong ret;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe string godot_icall_1_927(IntPtr method, IntPtr ptr, ulong arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string ret = default;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertStringToManaged(ret);
    }

    internal static unsafe void godot_icall_3_928(IntPtr method, IntPtr ptr, long arg1, ulong arg2, string arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string arg3_in = Marshaling.ConvertStringToNative(arg3);
        void** call_args = stackalloc void*[3] { &arg1, &arg2, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe Rid godot_icall_2_929(IntPtr method, IntPtr ptr, string arg1, Rid arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Rid ret;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe ulong godot_icall_7_930(IntPtr method, IntPtr ptr, ulong arg1, ulong arg2, long arg3, uint arg4, uint arg5, uint arg6, uint arg7)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        ulong ret;
        long arg4_in = arg4;
        long arg5_in = arg5;
        long arg6_in = arg6;
        long arg7_in = arg7;
        void** call_args = stackalloc void*[7] { &arg1, &arg2, &arg3, &arg4_in, &arg5_in, &arg6_in, &arg7_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe ulong godot_icall_1_931(IntPtr method, IntPtr ptr, ulong arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        ulong ret;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Rid godot_icall_1_932(IntPtr method, IntPtr ptr, ulong arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Rid ret;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe godot_bool godot_icall_2_933(IntPtr method, IntPtr ptr, int arg1, uint arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_bool ret;
        long arg1_in = arg1;
        long arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Vector2 godot_icall_2_934(IntPtr method, IntPtr ptr, Vector3* arg1, Vector3* arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Vector2 ret;
        void** call_args = stackalloc void*[2] { arg1, arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe GodotObject godot_icall_2_935(IntPtr method, IntPtr ptr, ulong arg1, in Callable arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_ref ret = default;
        using godot_callable arg2_in = Marshaling.ConvertCallableToNative(in arg2);
        void** call_args = stackalloc void*[2] { &arg1, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return InteropUtils.UnmanagedGetManaged(ret.Reference);
    }

    internal static unsafe void godot_icall_6_936(IntPtr method, IntPtr ptr, string arg1, string arg2, string arg3, string arg4, string arg5, int arg6)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        using godot_string arg2_in = Marshaling.ConvertStringToNative(arg2);
        using godot_string arg3_in = Marshaling.ConvertStringToNative(arg3);
        using godot_string arg4_in = Marshaling.ConvertStringToNative(arg4);
        using godot_string arg5_in = Marshaling.ConvertStringToNative(arg5);
        long arg6_in = arg6;
        void** call_args = stackalloc void*[6] { &arg1_in, &arg2_in, &arg3_in, &arg4_in, &arg5_in, &arg6_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_3_937(IntPtr method, IntPtr ptr, Transform3D* arg1, ReadOnlySpan<Vector2> arg2, ReadOnlySpan<int> arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_vector2_array arg2_in = Marshaling.ConvertSystemArrayToNativePackedVector2Array(arg2);
        using godot_packed_int32_array arg3_in = Marshaling.ConvertSystemArrayToNativePackedInt32Array(arg3);
        void** call_args = stackalloc void*[3] { arg1, &arg2_in, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe GodotObject godot_icall_1_938(IntPtr method, IntPtr ptr, Rid arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        IntPtr ret = default;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return InteropUtils.UnmanagedGetManaged(ret);
    }

    internal static unsafe string[] godot_icall_1_939(IntPtr method, IntPtr ptr, Rid arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_string_array ret = default;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertNativePackedStringArrayToSystemArray(ret);
    }

    internal static unsafe string godot_icall_1_940(IntPtr method, IntPtr ptr, Rid arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string ret = default;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertStringToManaged(ret);
    }

    internal static unsafe string godot_icall_2_941(IntPtr method, IntPtr ptr, Rid arg1, uint arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string ret = default;
        long arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertStringToManaged(ret);
    }

    internal static unsafe godot_bool godot_icall_2_942(IntPtr method, IntPtr ptr, Rid arg1, uint arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_bool ret;
        long arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Transform3D godot_icall_2_943(IntPtr method, IntPtr ptr, Rid arg1, uint arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Transform3D ret;
        long arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe GodotObject godot_icall_2_944(IntPtr method, IntPtr ptr, int arg1, in Callable arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_ref ret = default;
        long arg1_in = arg1;
        using godot_callable arg2_in = Marshaling.ConvertCallableToNative(in arg2);
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return InteropUtils.UnmanagedGetManaged(ret.Reference);
    }

    internal static unsafe GodotObject godot_icall_2_945(IntPtr method, IntPtr ptr, Transform3D* arg1, Rid arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_ref ret = default;
        void** call_args = stackalloc void*[2] { arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return InteropUtils.UnmanagedGetManaged(ret.Reference);
    }

    internal static unsafe GodotObject godot_icall_3_946(IntPtr method, IntPtr ptr, IntPtr arg1, Rid arg2, in Callable arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_ref ret = default;
        using godot_callable arg3_in = Marshaling.ConvertCallableToNative(in arg3);
        void** call_args = stackalloc void*[3] { &arg1, &arg2, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return InteropUtils.UnmanagedGetManaged(ret.Reference);
    }

    internal static unsafe Transform3D godot_icall_1_947(IntPtr method, IntPtr ptr, long arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Transform3D ret;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe uint godot_icall_1_948(IntPtr method, IntPtr ptr, long arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (uint)(ret);
    }

    internal static unsafe Variant godot_icall_2_949(IntPtr method, IntPtr ptr, Rid arg1, long arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_variant ret = default;
        void** call_args = stackalloc void*[2] { &arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Variant.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe Vector2[] godot_icall_2_950(IntPtr method, IntPtr ptr, Rid arg1, long arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_vector2_array ret = default;
        void** call_args = stackalloc void*[2] { &arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertNativePackedVector2ArrayToSystemArray(ret);
    }

    internal static unsafe int[] godot_icall_2_951(IntPtr method, IntPtr ptr, Rid arg1, long arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_int32_array ret = default;
        void** call_args = stackalloc void*[2] { &arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertNativePackedInt32ArrayToSystemArray(ret);
    }

    internal static unsafe GodotObject godot_icall_1_952(IntPtr method, IntPtr ptr, long arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_ref ret = default;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return InteropUtils.UnmanagedGetManaged(ret.Reference);
    }

    internal static unsafe Rid godot_icall_1_953(IntPtr method, IntPtr ptr, long arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Rid ret;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe ulong godot_icall_1_954(IntPtr method, IntPtr ptr, long arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        ulong ret;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe GodotObject godot_icall_3_955(IntPtr method, IntPtr ptr, godot_array arg1, IntPtr arg2, in Callable arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_ref ret = default;
        using godot_callable arg3_in = Marshaling.ConvertCallableToNative(in arg3);
        void** call_args = stackalloc void*[3] { &arg1, &arg2, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return InteropUtils.UnmanagedGetManaged(ret.Reference);
    }

    internal static unsafe GodotObject godot_icall_4_956(IntPtr method, IntPtr ptr, Rid arg1, ReadOnlySpan<long> arg2, IntPtr arg3, in Callable arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_ref ret = default;
        using godot_packed_int64_array arg2_in = Marshaling.ConvertSystemArrayToNativePackedInt64Array(arg2);
        using godot_callable arg4_in = Marshaling.ConvertCallableToNative(in arg4);
        void** call_args = stackalloc void*[4] { &arg1, &arg2_in, &arg3, &arg4_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return InteropUtils.UnmanagedGetManaged(ret.Reference);
    }

    internal static unsafe Rid godot_icall_4_957(IntPtr method, IntPtr ptr, Rid arg1, godot_array arg2, ReadOnlySpan<long> arg3, IntPtr arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Rid ret;
        using godot_packed_int64_array arg3_in = Marshaling.ConvertSystemArrayToNativePackedInt64Array(arg3);
        void** call_args = stackalloc void*[4] { &arg1, &arg2, &arg3_in, &arg4 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe godot_bool godot_icall_3_958(IntPtr method, IntPtr ptr, Rid arg1, godot_array arg2, IntPtr arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_bool ret;
        void** call_args = stackalloc void*[3] { &arg1, &arg2, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe string godot_icall_2_959(IntPtr method, IntPtr ptr, Rid arg1, ulong arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string ret = default;
        void** call_args = stackalloc void*[2] { &arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertStringToManaged(ret);
    }

    internal static unsafe byte[] godot_icall_2_960(IntPtr method, IntPtr ptr, Rid arg1, ulong arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_byte_array ret = default;
        void** call_args = stackalloc void*[2] { &arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertNativePackedByteArrayToSystemArray(ret);
    }

    internal static unsafe int[] godot_icall_2_961(IntPtr method, IntPtr ptr, Rid arg1, ulong arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_int32_array ret = default;
        void** call_args = stackalloc void*[2] { &arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertNativePackedInt32ArrayToSystemArray(ret);
    }

    internal static unsafe float[] godot_icall_2_962(IntPtr method, IntPtr ptr, Rid arg1, ulong arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_float32_array ret = default;
        void** call_args = stackalloc void*[2] { &arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertNativePackedFloat32ArrayToSystemArray(ret);
    }

    internal static unsafe Vector2[] godot_icall_2_963(IntPtr method, IntPtr ptr, Rid arg1, ulong arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_vector2_array ret = default;
        void** call_args = stackalloc void*[2] { &arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertNativePackedVector2ArrayToSystemArray(ret);
    }

    internal static unsafe Vector3[] godot_icall_2_964(IntPtr method, IntPtr ptr, Rid arg1, ulong arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_vector3_array ret = default;
        void** call_args = stackalloc void*[2] { &arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertNativePackedVector3ArrayToSystemArray(ret);
    }

    internal static unsafe Rid godot_icall_3_965(IntPtr method, IntPtr ptr, Rid arg1, ulong arg2, ulong arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Rid ret;
        void** call_args = stackalloc void*[3] { &arg1, &arg2, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Rid godot_icall_2_966(IntPtr method, IntPtr ptr, Rid arg1, ulong arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Rid ret;
        void** call_args = stackalloc void*[2] { &arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe void godot_icall_3_967(IntPtr method, IntPtr ptr, IntPtr arg1, string arg2, int arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string arg2_in = Marshaling.ConvertStringToNative(arg2);
        long arg3_in = arg3;
        void** call_args = stackalloc void*[3] { &arg1, &arg2_in, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe int godot_icall_4_968(IntPtr method, IntPtr ptr, string arg1, int arg2, string arg3, godot_bool arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        long arg2_in = arg2;
        using godot_string arg3_in = Marshaling.ConvertStringToNative(arg3);
        void** call_args = stackalloc void*[4] { &arg1_in, &arg2_in, &arg3_in, &arg4 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe int godot_icall_3_969(IntPtr method, IntPtr ptr, string arg1, string arg2, godot_bool arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        using godot_string arg2_in = Marshaling.ConvertStringToNative(arg2);
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2_in, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe int godot_icall_1_970(IntPtr method, IntPtr ptr, Variant arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        godot_variant arg1_in = (godot_variant)arg1.NativeVar;
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe int godot_icall_2_971(IntPtr method, IntPtr ptr, Variant arg1, godot_bool arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        godot_variant arg1_in = (godot_variant)arg1.NativeVar;
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe int godot_icall_3_972(IntPtr method, IntPtr ptr, IntPtr arg1, string arg2, IntPtr arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        using godot_string arg2_in = Marshaling.ConvertStringToNative(arg2);
        void** call_args = stackalloc void*[3] { &arg1, &arg2_in, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe int godot_icall_3_973(IntPtr method, IntPtr ptr, int arg1, string arg2, int arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        long arg1_in = arg1;
        using godot_string arg2_in = Marshaling.ConvertStringToNative(arg2);
        long arg3_in = arg3;
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2_in, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe Transform3D godot_icall_2_974(IntPtr method, Transform3D* arg1, int arg2)
    {
        Transform3D ret;
        long arg2_in = arg2;
        void** call_args = stackalloc void*[2] { arg1, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, IntPtr.Zero, call_args, &ret);
        return ret;
    }

    internal static unsafe void godot_icall_4_975(IntPtr method, IntPtr ptr, godot_string_name arg1, in Callable arg2, godot_array arg3, int arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_callable arg2_in = Marshaling.ConvertCallableToNative(in arg2);
        long arg4_in = arg4;
        void** call_args = stackalloc void*[4] { &arg1, &arg2_in, &arg3, &arg4_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_3_976(IntPtr method, IntPtr ptr, godot_string_name arg1, in Callable arg2, godot_array arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_callable arg2_in = Marshaling.ConvertCallableToNative(in arg2);
        void** call_args = stackalloc void*[3] { &arg1, &arg2_in, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_2_977(IntPtr method, IntPtr ptr, Vector3* arg1, Vector3* arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[2] { arg1, arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe GodotObject godot_icall_4_978(IntPtr method, IntPtr ptr, Vector2* arg1, godot_bool arg2, float arg3, godot_bool arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_ref ret = default;
        double arg3_in = arg3;
        void** call_args = stackalloc void*[4] { arg1, &arg2, &arg3_in, &arg4 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return InteropUtils.UnmanagedGetManaged(ret.Reference);
    }

    internal static unsafe godot_bool godot_icall_5_979(IntPtr method, IntPtr ptr, Transform2D* arg1, Vector2* arg2, IntPtr arg3, float arg4, godot_bool arg5)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_bool ret;
        double arg4_in = arg4;
        void** call_args = stackalloc void*[5] { arg1, arg2, &arg3, &arg4_in, &arg5 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe GodotObject godot_icall_5_980(IntPtr method, IntPtr ptr, Vector3* arg1, godot_bool arg2, float arg3, godot_bool arg4, int arg5)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_ref ret = default;
        double arg3_in = arg3;
        long arg5_in = arg5;
        void** call_args = stackalloc void*[5] { arg1, &arg2, &arg3_in, &arg4, &arg5_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return InteropUtils.UnmanagedGetManaged(ret.Reference);
    }

    internal static unsafe godot_bool godot_icall_6_981(IntPtr method, IntPtr ptr, Transform3D* arg1, Vector3* arg2, IntPtr arg3, float arg4, godot_bool arg5, int arg6)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_bool ret;
        double arg4_in = arg4;
        long arg6_in = arg6;
        void** call_args = stackalloc void*[6] { arg1, arg2, &arg3, &arg4_in, &arg5, &arg6_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe void godot_icall_2_982(IntPtr method, IntPtr ptr, Vector2* arg1, Vector2* arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[2] { arg1, arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe Godot.Collections.Array godot_icall_2_983(IntPtr method, IntPtr ptr, IntPtr arg1, int arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_array ret = default;
        long arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Godot.Collections.Array.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe Godot.Collections.Dictionary godot_icall_1_984(IntPtr method, IntPtr ptr, IntPtr arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_dictionary ret = default;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Godot.Collections.Dictionary.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe float[] godot_icall_1_985(IntPtr method, IntPtr ptr, IntPtr arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_float32_array ret = default;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertNativePackedFloat32ArrayToSystemArray(ret);
    }

    internal static unsafe GodotObject godot_icall_4_986(IntPtr method, Vector2* arg1, Vector2* arg2, uint arg3, godot_array arg4)
    {
        using godot_ref ret = default;
        long arg3_in = arg3;
        void** call_args = stackalloc void*[4] { arg1, arg2, &arg3_in, &arg4 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, IntPtr.Zero, call_args, &ret);
        return InteropUtils.UnmanagedGetManaged(ret.Reference);
    }

    internal static unsafe GodotObject godot_icall_4_987(IntPtr method, Vector3* arg1, Vector3* arg2, uint arg3, godot_array arg4)
    {
        using godot_ref ret = default;
        long arg3_in = arg3;
        void** call_args = stackalloc void*[4] { arg1, arg2, &arg3_in, &arg4 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, IntPtr.Zero, call_args, &ret);
        return InteropUtils.UnmanagedGetManaged(ret.Reference);
    }

    internal static unsafe void godot_icall_3_988(IntPtr method, IntPtr ptr, Rid arg1, int arg2, float arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg2_in = arg2;
        double arg3_in = arg3;
        void** call_args = stackalloc void*[3] { &arg1, &arg2_in, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe float godot_icall_2_989(IntPtr method, IntPtr ptr, Rid arg1, int arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double ret;
        long arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (float)ret;
    }

    internal static unsafe void godot_icall_4_990(IntPtr method, IntPtr ptr, Rid arg1, Rid arg2, Transform2D* arg3, godot_bool arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[4] { &arg1, &arg2, arg3, &arg4 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_3_991(IntPtr method, IntPtr ptr, Rid arg1, int arg2, Transform2D* arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg2_in = arg2;
        void** call_args = stackalloc void*[3] { &arg1, &arg2_in, arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe Transform2D godot_icall_2_992(IntPtr method, IntPtr ptr, Rid arg1, int arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Transform2D ret;
        long arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe void godot_icall_4_993(IntPtr method, IntPtr ptr, Rid arg1, int arg2, godot_bool arg3, float arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg2_in = arg2;
        double arg4_in = arg4;
        void** call_args = stackalloc void*[4] { &arg1, &arg2_in, &arg3, &arg4_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_3_994(IntPtr method, IntPtr ptr, Rid arg1, Vector2* arg2, Vector2* arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[3] { &arg1, arg2, arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_3_995(IntPtr method, IntPtr ptr, Rid arg1, in Callable arg2, Variant arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_callable arg2_in = Marshaling.ConvertCallableToNative(in arg2);
        godot_variant arg3_in = (godot_variant)arg3.NativeVar;
        void** call_args = stackalloc void*[3] { &arg1, &arg2_in, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe godot_bool godot_icall_3_996(IntPtr method, IntPtr ptr, Rid arg1, IntPtr arg2, IntPtr arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_bool ret;
        void** call_args = stackalloc void*[3] { &arg1, &arg2, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe void godot_icall_4_997(IntPtr method, IntPtr ptr, Rid arg1, Vector2* arg2, Rid arg3, Rid arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[4] { &arg1, arg2, &arg3, &arg4 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_6_998(IntPtr method, IntPtr ptr, Rid arg1, Vector2* arg2, Vector2* arg3, Vector2* arg4, Rid arg5, Rid arg6)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[6] { &arg1, arg2, arg3, arg4, &arg5, &arg6 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_5_999(IntPtr method, IntPtr ptr, Rid arg1, Vector2* arg2, Vector2* arg3, Rid arg4, Rid arg5)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[5] { &arg1, arg2, arg3, &arg4, &arg5 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_4_1000(IntPtr method, IntPtr ptr, Rid arg1, Rid arg2, Transform3D* arg3, godot_bool arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[4] { &arg1, &arg2, arg3, &arg4 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_3_1001(IntPtr method, IntPtr ptr, Rid arg1, int arg2, Transform3D* arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg2_in = arg2;
        void** call_args = stackalloc void*[3] { &arg1, &arg2_in, arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe Transform3D godot_icall_2_1002(IntPtr method, IntPtr ptr, Rid arg1, int arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Transform3D ret;
        long arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe void godot_icall_3_1003(IntPtr method, IntPtr ptr, Rid arg1, Vector3* arg2, Vector3* arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[3] { &arg1, arg2, arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_3_1004(IntPtr method, IntPtr ptr, Rid arg1, int arg2, Vector3* arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg2_in = arg2;
        void** call_args = stackalloc void*[3] { &arg1, &arg2_in, arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_5_1005(IntPtr method, IntPtr ptr, Rid arg1, Rid arg2, Vector3* arg3, Rid arg4, Vector3* arg5)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[5] { &arg1, &arg2, arg3, &arg4, arg5 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_5_1006(IntPtr method, IntPtr ptr, Rid arg1, Rid arg2, Transform3D* arg3, Rid arg4, Transform3D* arg5)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[5] { &arg1, &arg2, arg3, &arg4, arg5 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_4_1007(IntPtr method, IntPtr ptr, Rid arg1, int arg2, int arg3, float arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg2_in = arg2;
        long arg3_in = arg3;
        double arg4_in = arg4;
        void** call_args = stackalloc void*[4] { &arg1, &arg2_in, &arg3_in, &arg4_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe float godot_icall_3_1008(IntPtr method, IntPtr ptr, Rid arg1, int arg2, int arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double ret;
        long arg2_in = arg2;
        long arg3_in = arg3;
        void** call_args = stackalloc void*[3] { &arg1, &arg2_in, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (float)ret;
    }

    internal static unsafe void godot_icall_4_1009(IntPtr method, IntPtr ptr, Rid arg1, int arg2, int arg3, godot_bool arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg2_in = arg2;
        long arg3_in = arg3;
        void** call_args = stackalloc void*[4] { &arg1, &arg2_in, &arg3_in, &arg4 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe godot_bool godot_icall_3_1010(IntPtr method, IntPtr ptr, Rid arg1, int arg2, int arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_bool ret;
        long arg2_in = arg2;
        long arg3_in = arg3;
        void** call_args = stackalloc void*[3] { &arg1, &arg2_in, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe void godot_icall_1_1011(IntPtr method, IntPtr ptr, Vector3I* arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[1] { arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe Vector3I godot_icall_0_1012(IntPtr method, IntPtr ptr)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Vector3I ret;
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, null, &ret);
        return ret;
    }

    internal static unsafe void godot_icall_2_1013(IntPtr method, IntPtr ptr, godot_node_path arg1, ReadOnlySpan<float> arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_float32_array arg2_in = Marshaling.ConvertSystemArrayToNativePackedFloat32Array(arg2);
        void** call_args = stackalloc void*[2] { &arg1, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_2_1014(IntPtr method, IntPtr ptr, ReadOnlySpan<Vector2> arg1, ReadOnlySpan<int> arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_vector2_array arg1_in = Marshaling.ConvertSystemArrayToNativePackedVector2Array(arg1);
        using godot_packed_int32_array arg2_in = Marshaling.ConvertSystemArrayToNativePackedInt32Array(arg2);
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_4_1015(IntPtr method, IntPtr ptr, IntPtr arg1, string arg2, int arg3, int arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string arg2_in = Marshaling.ConvertStringToNative(arg2);
        long arg3_in = arg3;
        long arg4_in = arg4;
        void** call_args = stackalloc void*[4] { &arg1, &arg2_in, &arg3_in, &arg4_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_5_1016(IntPtr method, IntPtr ptr, string arg1, int arg2, int arg3, int arg4, int arg5)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        long arg2_in = arg2;
        long arg3_in = arg3;
        long arg4_in = arg4;
        long arg5_in = arg5;
        void** call_args = stackalloc void*[5] { &arg1_in, &arg2_in, &arg3_in, &arg4_in, &arg5_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_4_1017(IntPtr method, IntPtr ptr, IntPtr arg1, int arg2, godot_bool arg3, godot_bool arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg2_in = arg2;
        void** call_args = stackalloc void*[4] { &arg1, &arg2_in, &arg3, &arg4 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_5_1018(IntPtr method, IntPtr ptr, IntPtr arg1, IntPtr arg2, int arg3, godot_bool arg4, godot_bool arg5)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg3_in = arg3;
        void** call_args = stackalloc void*[5] { &arg1, &arg2, &arg3_in, &arg4, &arg5 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_3_1019(IntPtr method, IntPtr ptr, IntPtr arg1, int arg2, godot_bool arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg2_in = arg2;
        void** call_args = stackalloc void*[3] { &arg1, &arg2_in, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_4_1020(IntPtr method, IntPtr ptr, IntPtr arg1, IntPtr arg2, int arg3, godot_bool arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg3_in = arg3;
        void** call_args = stackalloc void*[4] { &arg1, &arg2, &arg3_in, &arg4 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_3_1021(IntPtr method, IntPtr ptr, string arg1, string arg2, int arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        using godot_string arg2_in = Marshaling.ConvertStringToNative(arg2);
        long arg3_in = arg3;
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2_in, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_3_1022(IntPtr method, IntPtr ptr, string arg1, IntPtr arg2, int arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        long arg3_in = arg3;
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_3_1023(IntPtr method, IntPtr ptr, int arg1, IntPtr arg2, godot_bool arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_4_1024(IntPtr method, IntPtr ptr, IntPtr arg1, int arg2, godot_bool arg3, float arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg2_in = arg2;
        double arg4_in = arg4;
        void** call_args = stackalloc void*[4] { &arg1, &arg2_in, &arg3, &arg4_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_1_1025(IntPtr method, godot_bool arg1)
    {
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, IntPtr.Zero, call_args, null);
    }

    internal static unsafe godot_bool godot_icall_0_1026(IntPtr method)
    {
        godot_bool ret;
        NativeFuncs.godotsharp_method_bind_ptrcall(method, IntPtr.Zero, null, &ret);
        return ret;
    }

    internal static unsafe Variant godot_icall_2_1027(IntPtr method, IntPtr ptr, string arg1, Variant arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_variant ret = default;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        godot_variant arg2_in = (godot_variant)arg2.NativeVar;
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Variant.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe Variant godot_icall_2_1028(IntPtr method, IntPtr ptr, godot_string_name arg1, ReadOnlySpan<string> arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_variant ret = default;
        using godot_packed_string_array arg2_in = Marshaling.ConvertSystemArrayToNativePackedStringArray(arg2);
        void** call_args = stackalloc void*[2] { &arg1, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Variant.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe godot_bool godot_icall_3_1029(IntPtr method, IntPtr ptr, string arg1, godot_bool arg2, int arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_bool ret;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        long arg3_in = arg3;
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe GodotObject godot_icall_1_1030(IntPtr method, IntPtr ptr, Variant arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_ref ret = default;
        godot_variant arg1_in = (godot_variant)arg1.NativeVar;
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return InteropUtils.UnmanagedGetManaged(ret.Reference);
    }

    internal static unsafe void godot_icall_2_1031(IntPtr method, IntPtr ptr, int arg1, ReadOnlySpan<byte> arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        using godot_packed_byte_array arg2_in = Marshaling.ConvertSystemArrayToNativePackedByteArray(arg2);
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe long godot_icall_1_1032(IntPtr method, IntPtr ptr, ReadOnlySpan<float> arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        using godot_packed_float32_array arg1_in = Marshaling.ConvertSystemArrayToNativePackedFloat32Array(arg1);
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe GodotObject godot_icall_3_1033(IntPtr method, IntPtr ptr, string arg1, int arg2, int arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_ref ret = default;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        long arg2_in = arg2;
        long arg3_in = arg3;
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2_in, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return InteropUtils.UnmanagedGetManaged(ret.Reference);
    }

    internal static unsafe Godot.Collections.Array godot_icall_3_1034(IntPtr method, IntPtr ptr, string arg1, int arg2, int arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_array ret = default;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        long arg2_in = arg2;
        long arg3_in = arg3;
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2_in, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Godot.Collections.Array.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe string godot_icall_5_1035(IntPtr method, IntPtr ptr, string arg1, string arg2, godot_bool arg3, int arg4, int arg5)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string ret = default;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        using godot_string arg2_in = Marshaling.ConvertStringToNative(arg2);
        long arg4_in = arg4;
        long arg5_in = arg5;
        void** call_args = stackalloc void*[5] { &arg1_in, &arg2_in, &arg3, &arg4_in, &arg5_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertStringToManaged(ret);
    }

    internal static unsafe string godot_icall_1_1036(IntPtr method, IntPtr ptr, Variant arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string ret = default;
        godot_variant arg1_in = (godot_variant)arg1.NativeVar;
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertStringToManaged(ret);
    }

    internal static unsafe Rid godot_icall_10_1037(IntPtr method, IntPtr ptr, godot_string_name arg1, godot_string_name arg2, int arg3, uint arg4, int arg5, Vector2I* arg6, uint arg7, uint arg8, godot_bool arg9, godot_bool arg10)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Rid ret;
        long arg3_in = arg3;
        long arg4_in = arg4;
        long arg5_in = arg5;
        long arg7_in = arg7;
        long arg8_in = arg8;
        void** call_args = stackalloc void*[10] { &arg1, &arg2, &arg3_in, &arg4_in, &arg5_in, arg6, &arg7_in, &arg8_in, &arg9, &arg10 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Rid godot_icall_5_1038(IntPtr method, IntPtr ptr, godot_string_name arg1, godot_string_name arg2, IntPtr arg3, IntPtr arg4, godot_bool arg5)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Rid ret;
        void** call_args = stackalloc void*[5] { &arg1, &arg2, &arg3, &arg4, &arg5 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Rid godot_icall_4_1039(IntPtr method, IntPtr ptr, godot_string_name arg1, godot_string_name arg2, godot_string_name arg3, IntPtr arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Rid ret;
        void** call_args = stackalloc void*[4] { &arg1, &arg2, &arg3, &arg4 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Rid godot_icall_2_1040(IntPtr method, IntPtr ptr, godot_string_name arg1, godot_string_name arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Rid ret;
        void** call_args = stackalloc void*[2] { &arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Rid godot_icall_6_1041(IntPtr method, IntPtr ptr, godot_string_name arg1, godot_string_name arg2, uint arg3, uint arg4, uint arg5, uint arg6)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Rid ret;
        long arg3_in = arg3;
        long arg4_in = arg4;
        long arg5_in = arg5;
        long arg6_in = arg6;
        void** call_args = stackalloc void*[6] { &arg1, &arg2, &arg3_in, &arg4_in, &arg5_in, &arg6_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Rid godot_icall_7_1042(IntPtr method, IntPtr ptr, godot_string_name arg1, godot_string_name arg2, uint arg3, uint arg4, uint arg5, uint arg6, IntPtr arg7)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Rid ret;
        long arg3_in = arg3;
        long arg4_in = arg4;
        long arg5_in = arg5;
        long arg6_in = arg6;
        void** call_args = stackalloc void*[7] { &arg1, &arg2, &arg3_in, &arg4_in, &arg5_in, &arg6_in, &arg7 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Vector2I godot_icall_3_1043(IntPtr method, IntPtr ptr, godot_string_name arg1, godot_string_name arg2, uint arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Vector2I ret;
        long arg3_in = arg3;
        void** call_args = stackalloc void*[3] { &arg1, &arg2, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Rid godot_icall_1_1044(IntPtr method, IntPtr ptr, godot_bool arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Rid ret;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Rid godot_icall_2_1045(IntPtr method, IntPtr ptr, uint arg1, godot_bool arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Rid ret;
        long arg1_in = arg1;
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Rid godot_icall_9_1046(IntPtr method, IntPtr ptr, godot_string_name arg1, godot_string_name arg2, int arg3, uint arg4, int arg5, Vector2I* arg6, uint arg7, uint arg8, godot_bool arg9)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Rid ret;
        long arg3_in = arg3;
        long arg4_in = arg4;
        long arg5_in = arg5;
        long arg7_in = arg7;
        long arg8_in = arg8;
        void** call_args = stackalloc void*[9] { &arg1, &arg2, &arg3_in, &arg4_in, &arg5_in, arg6, &arg7_in, &arg8_in, &arg9 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Rid godot_icall_1_1047(IntPtr method, IntPtr ptr, uint arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Rid ret;
        long arg1_in = arg1;
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Vector3 godot_icall_1_1048(IntPtr method, IntPtr ptr, uint arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Vector3 ret;
        long arg1_in = arg1;
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Projection godot_icall_1_1049(IntPtr method, IntPtr ptr, uint arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Projection ret;
        long arg1_in = arg1;
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Rid godot_icall_3_1050(IntPtr method, IntPtr ptr, IntPtr arg1, IntPtr arg2, godot_array arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Rid ret;
        void** call_args = stackalloc void*[3] { &arg1, &arg2, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Rid godot_icall_2_1051(IntPtr method, IntPtr ptr, IntPtr arg1, Rid arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Rid ret;
        void** call_args = stackalloc void*[2] { &arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Rid godot_icall_6_1052(IntPtr method, IntPtr ptr, IntPtr arg1, Rid arg2, uint arg3, uint arg4, uint arg5, int arg6)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Rid ret;
        long arg3_in = arg3;
        long arg4_in = arg4;
        long arg5_in = arg5;
        long arg6_in = arg6;
        void** call_args = stackalloc void*[6] { &arg1, &arg2, &arg3_in, &arg4_in, &arg5_in, &arg6_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Rid godot_icall_10_1053(IntPtr method, IntPtr ptr, int arg1, int arg2, int arg3, int arg4, ulong arg5, ulong arg6, ulong arg7, ulong arg8, ulong arg9, ulong arg10)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Rid ret;
        long arg1_in = arg1;
        long arg2_in = arg2;
        long arg3_in = arg3;
        long arg4_in = arg4;
        void** call_args = stackalloc void*[10] { &arg1_in, &arg2_in, &arg3_in, &arg4_in, &arg5, &arg6, &arg7, &arg8, &arg9, &arg10 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe int godot_icall_3_1054(IntPtr method, IntPtr ptr, Rid arg1, uint arg2, ReadOnlySpan<byte> arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        long arg2_in = arg2;
        using godot_packed_byte_array arg3_in = Marshaling.ConvertSystemArrayToNativePackedByteArray(arg3);
        void** call_args = stackalloc void*[3] { &arg1, &arg2_in, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe byte[] godot_icall_2_1055(IntPtr method, IntPtr ptr, Rid arg1, uint arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_byte_array ret = default;
        long arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertNativePackedByteArrayToSystemArray(ret);
    }

    internal static unsafe int godot_icall_3_1056(IntPtr method, IntPtr ptr, Rid arg1, uint arg2, in Callable arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        long arg2_in = arg2;
        using godot_callable arg3_in = Marshaling.ConvertCallableToNative(in arg3);
        void** call_args = stackalloc void*[3] { &arg1, &arg2_in, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe int godot_icall_9_1057(IntPtr method, IntPtr ptr, Rid arg1, Rid arg2, Vector3* arg3, Vector3* arg4, Vector3* arg5, uint arg6, uint arg7, uint arg8, uint arg9)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        long arg6_in = arg6;
        long arg7_in = arg7;
        long arg8_in = arg8;
        long arg9_in = arg9;
        void** call_args = stackalloc void*[9] { &arg1, &arg2, arg3, arg4, arg5, &arg6_in, &arg7_in, &arg8_in, &arg9_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe int godot_icall_6_1058(IntPtr method, IntPtr ptr, Rid arg1, Color* arg2, uint arg3, uint arg4, uint arg5, uint arg6)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        long arg3_in = arg3;
        long arg4_in = arg4;
        long arg5_in = arg5;
        long arg6_in = arg6;
        void** call_args = stackalloc void*[6] { &arg1, arg2, &arg3_in, &arg4_in, &arg5_in, &arg6_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe GodotObject godot_icall_1_1059(IntPtr method, IntPtr ptr, Rid arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_ref ret = default;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return InteropUtils.UnmanagedGetManaged(ret.Reference);
    }

    internal static unsafe long godot_icall_2_1060(IntPtr method, IntPtr ptr, godot_array arg1, uint arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        long arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe long godot_icall_3_1061(IntPtr method, IntPtr ptr, godot_array arg1, godot_array arg2, uint arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        long arg3_in = arg3;
        void** call_args = stackalloc void*[3] { &arg1, &arg2, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe int godot_icall_2_1062(IntPtr method, IntPtr ptr, long arg1, uint arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        long arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe Rid godot_icall_3_1063(IntPtr method, IntPtr ptr, godot_array arg1, long arg2, uint arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Rid ret;
        long arg3_in = arg3;
        void** call_args = stackalloc void*[3] { &arg1, &arg2, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Rid godot_icall_4_1064(IntPtr method, IntPtr ptr, godot_array arg1, godot_array arg2, long arg3, uint arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Rid ret;
        long arg4_in = arg4;
        void** call_args = stackalloc void*[4] { &arg1, &arg2, &arg3, &arg4_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Rid godot_icall_3_1065(IntPtr method, IntPtr ptr, Vector2I* arg1, int arg2, long arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Rid ret;
        long arg2_in = arg2;
        void** call_args = stackalloc void*[3] { arg1, &arg2_in, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe long godot_icall_1_1066(IntPtr method, IntPtr ptr, Rid arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Rid godot_icall_1_1067(IntPtr method, IntPtr ptr, IntPtr arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Rid ret;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Rid godot_icall_3_1068(IntPtr method, IntPtr ptr, uint arg1, ReadOnlySpan<byte> arg2, int arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Rid ret;
        long arg1_in = arg1;
        using godot_packed_byte_array arg2_in = Marshaling.ConvertSystemArrayToNativePackedByteArray(arg2);
        long arg3_in = arg3;
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2_in, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe long godot_icall_1_1069(IntPtr method, IntPtr ptr, godot_array arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Rid godot_icall_4_1070(IntPtr method, IntPtr ptr, uint arg1, long arg2, godot_array arg3, ReadOnlySpan<long> arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Rid ret;
        long arg1_in = arg1;
        using godot_packed_int64_array arg4_in = Marshaling.ConvertSystemArrayToNativePackedInt64Array(arg4);
        void** call_args = stackalloc void*[4] { &arg1_in, &arg2, &arg3, &arg4_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Rid godot_icall_5_1071(IntPtr method, IntPtr ptr, uint arg1, int arg2, ReadOnlySpan<byte> arg3, godot_bool arg4, int arg5)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Rid ret;
        long arg1_in = arg1;
        long arg2_in = arg2;
        using godot_packed_byte_array arg3_in = Marshaling.ConvertSystemArrayToNativePackedByteArray(arg3);
        long arg5_in = arg5;
        void** call_args = stackalloc void*[5] { &arg1_in, &arg2_in, &arg3_in, &arg4, &arg5_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Rid godot_icall_3_1072(IntPtr method, IntPtr ptr, Rid arg1, uint arg2, uint arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Rid ret;
        long arg2_in = arg2;
        long arg3_in = arg3;
        void** call_args = stackalloc void*[3] { &arg1, &arg2_in, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe GodotObject godot_icall_2_1073(IntPtr method, IntPtr ptr, IntPtr arg1, godot_bool arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_ref ret = default;
        void** call_args = stackalloc void*[2] { &arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return InteropUtils.UnmanagedGetManaged(ret.Reference);
    }

    internal static unsafe byte[] godot_icall_2_1074(IntPtr method, IntPtr ptr, IntPtr arg1, string arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_byte_array ret = default;
        using godot_string arg2_in = Marshaling.ConvertStringToNative(arg2);
        void** call_args = stackalloc void*[2] { &arg1, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertNativePackedByteArrayToSystemArray(ret);
    }

    internal static unsafe Rid godot_icall_2_1075(IntPtr method, IntPtr ptr, IntPtr arg1, string arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Rid ret;
        using godot_string arg2_in = Marshaling.ConvertStringToNative(arg2);
        void** call_args = stackalloc void*[2] { &arg1, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Rid godot_icall_2_1076(IntPtr method, IntPtr ptr, ReadOnlySpan<byte> arg1, Rid arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Rid ret;
        using godot_packed_byte_array arg1_in = Marshaling.ConvertSystemArrayToNativePackedByteArray(arg1);
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Rid godot_icall_4_1077(IntPtr method, IntPtr ptr, uint arg1, ReadOnlySpan<byte> arg2, int arg3, int arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Rid ret;
        long arg1_in = arg1;
        using godot_packed_byte_array arg2_in = Marshaling.ConvertSystemArrayToNativePackedByteArray(arg2);
        long arg3_in = arg3;
        long arg4_in = arg4;
        void** call_args = stackalloc void*[4] { &arg1_in, &arg2_in, &arg3_in, &arg4_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Rid godot_icall_3_1078(IntPtr method, IntPtr ptr, uint arg1, int arg2, ReadOnlySpan<byte> arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Rid ret;
        long arg1_in = arg1;
        long arg2_in = arg2;
        using godot_packed_byte_array arg3_in = Marshaling.ConvertSystemArrayToNativePackedByteArray(arg3);
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2_in, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Rid godot_icall_3_1079(IntPtr method, IntPtr ptr, godot_array arg1, Rid arg2, uint arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Rid ret;
        long arg3_in = arg3;
        void** call_args = stackalloc void*[3] { &arg1, &arg2, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe int godot_icall_5_1080(IntPtr method, IntPtr ptr, Rid arg1, Rid arg2, uint arg3, uint arg4, uint arg5)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        long arg3_in = arg3;
        long arg4_in = arg4;
        long arg5_in = arg5;
        void** call_args = stackalloc void*[5] { &arg1, &arg2, &arg3_in, &arg4_in, &arg5_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe int godot_icall_4_1081(IntPtr method, IntPtr ptr, Rid arg1, uint arg2, uint arg3, ReadOnlySpan<byte> arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        long arg2_in = arg2;
        long arg3_in = arg3;
        using godot_packed_byte_array arg4_in = Marshaling.ConvertSystemArrayToNativePackedByteArray(arg4);
        void** call_args = stackalloc void*[4] { &arg1, &arg2_in, &arg3_in, &arg4_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe int godot_icall_3_1082(IntPtr method, IntPtr ptr, Rid arg1, uint arg2, uint arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        long arg2_in = arg2;
        long arg3_in = arg3;
        void** call_args = stackalloc void*[3] { &arg1, &arg2_in, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe byte[] godot_icall_3_1083(IntPtr method, IntPtr ptr, Rid arg1, uint arg2, uint arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_byte_array ret = default;
        long arg2_in = arg2;
        long arg3_in = arg3;
        void** call_args = stackalloc void*[3] { &arg1, &arg2_in, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertNativePackedByteArrayToSystemArray(ret);
    }

    internal static unsafe int godot_icall_4_1084(IntPtr method, IntPtr ptr, Rid arg1, in Callable arg2, uint arg3, uint arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        using godot_callable arg2_in = Marshaling.ConvertCallableToNative(in arg2);
        long arg3_in = arg3;
        long arg4_in = arg4;
        void** call_args = stackalloc void*[4] { &arg1, &arg2_in, &arg3_in, &arg4_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe Rid godot_icall_11_1085(IntPtr method, IntPtr ptr, Rid arg1, long arg2, long arg3, int arg4, IntPtr arg5, IntPtr arg6, IntPtr arg7, IntPtr arg8, int arg9, uint arg10, godot_array arg11)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Rid ret;
        long arg4_in = arg4;
        long arg9_in = arg9;
        long arg10_in = arg10;
        void** call_args = stackalloc void*[11] { &arg1, &arg2, &arg3, &arg4_in, &arg5, &arg6, &arg7, &arg8, &arg9_in, &arg10_in, &arg11 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Rid godot_icall_2_1086(IntPtr method, IntPtr ptr, Rid arg1, godot_array arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Rid ret;
        void** call_args = stackalloc void*[2] { &arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe long godot_icall_2_1087(IntPtr method, IntPtr ptr, int arg1, Color* arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        long arg1_in = arg1;
        void** call_args = stackalloc void*[2] { &arg1_in, arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe long godot_icall_7_1088(IntPtr method, IntPtr ptr, Rid arg1, int arg2, ReadOnlySpan<Color> arg3, float arg4, uint arg5, Rect2* arg6, uint arg7)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        long arg2_in = arg2;
        using godot_packed_color_array arg3_in = Marshaling.ConvertSystemArrayToNativePackedColorArray(arg3);
        double arg4_in = arg4;
        long arg5_in = arg5;
        long arg7_in = arg7;
        void** call_args = stackalloc void*[7] { &arg1, &arg2_in, &arg3_in, &arg4_in, &arg5_in, arg6, &arg7_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe long[] godot_icall_11_1089(IntPtr method, IntPtr ptr, Rid arg1, uint arg2, int arg3, int arg4, int arg5, int arg6, ReadOnlySpan<Color> arg7, float arg8, uint arg9, Rect2* arg10, godot_array arg11)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_int64_array ret = default;
        long arg2_in = arg2;
        long arg3_in = arg3;
        long arg4_in = arg4;
        long arg5_in = arg5;
        long arg6_in = arg6;
        using godot_packed_color_array arg7_in = Marshaling.ConvertSystemArrayToNativePackedColorArray(arg7);
        double arg8_in = arg8;
        long arg9_in = arg9;
        void** call_args = stackalloc void*[11] { &arg1, &arg2_in, &arg3_in, &arg4_in, &arg5_in, &arg6_in, &arg7_in, &arg8_in, &arg9_in, arg10, &arg11 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertNativePackedInt64ArrayToSystemArray(ret);
    }

    internal static unsafe void godot_icall_2_1090(IntPtr method, IntPtr ptr, long arg1, Color* arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[2] { &arg1, arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_2_1091(IntPtr method, IntPtr ptr, long arg1, Rid arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[2] { &arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_3_1092(IntPtr method, IntPtr ptr, long arg1, Rid arg2, uint arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg3_in = arg3;
        void** call_args = stackalloc void*[3] { &arg1, &arg2, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_5_1093(IntPtr method, IntPtr ptr, long arg1, long arg2, uint arg3, godot_array arg4, ReadOnlySpan<long> arg5)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg3_in = arg3;
        using godot_packed_int64_array arg5_in = Marshaling.ConvertSystemArrayToNativePackedInt64Array(arg5);
        void** call_args = stackalloc void*[5] { &arg1, &arg2, &arg3_in, &arg4, &arg5_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_3_1094(IntPtr method, IntPtr ptr, long arg1, ReadOnlySpan<byte> arg2, uint arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_byte_array arg2_in = Marshaling.ConvertSystemArrayToNativePackedByteArray(arg2);
        long arg3_in = arg3;
        void** call_args = stackalloc void*[3] { &arg1, &arg2_in, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_4_1095(IntPtr method, IntPtr ptr, long arg1, godot_bool arg2, uint arg3, uint arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg3_in = arg3;
        long arg4_in = arg4;
        void** call_args = stackalloc void*[4] { &arg1, &arg2, &arg3_in, &arg4_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_6_1096(IntPtr method, IntPtr ptr, long arg1, godot_bool arg2, Rid arg3, uint arg4, uint arg5, uint arg6)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg4_in = arg4;
        long arg5_in = arg5;
        long arg6_in = arg6;
        void** call_args = stackalloc void*[6] { &arg1, &arg2, &arg3, &arg4_in, &arg5_in, &arg6_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_2_1097(IntPtr method, IntPtr ptr, long arg1, Rect2* arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[2] { &arg1, arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe long[] godot_icall_1_1098(IntPtr method, IntPtr ptr, uint arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_int64_array ret = default;
        long arg1_in = arg1;
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertNativePackedInt64ArrayToSystemArray(ret);
    }

    internal static unsafe void godot_icall_4_1099(IntPtr method, IntPtr ptr, long arg1, uint arg2, uint arg3, uint arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg2_in = arg2;
        long arg3_in = arg3;
        long arg4_in = arg4;
        void** call_args = stackalloc void*[4] { &arg1, &arg2_in, &arg3_in, &arg4_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe ulong godot_icall_1_1100(IntPtr method, IntPtr ptr, uint arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        ulong ret;
        long arg1_in = arg1;
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe string godot_icall_1_1101(IntPtr method, IntPtr ptr, uint arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string ret = default;
        long arg1_in = arg1;
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertStringToManaged(ret);
    }

    internal static unsafe ulong godot_icall_3_1102(IntPtr method, IntPtr ptr, int arg1, Rid arg2, ulong arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        ulong ret;
        long arg1_in = arg1;
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Rid godot_icall_9_1103(IntPtr method, IntPtr ptr, int arg1, int arg2, int arg3, int arg4, ulong arg5, ulong arg6, ulong arg7, ulong arg8, ulong arg9)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Rid ret;
        long arg1_in = arg1;
        long arg2_in = arg2;
        long arg3_in = arg3;
        long arg4_in = arg4;
        void** call_args = stackalloc void*[9] { &arg1_in, &arg2_in, &arg3_in, &arg4_in, &arg5, &arg6, &arg7, &arg8, &arg9 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Rid godot_icall_4_1104(IntPtr method, IntPtr ptr, uint arg1, int arg2, ReadOnlySpan<byte> arg3, godot_bool arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Rid ret;
        long arg1_in = arg1;
        long arg2_in = arg2;
        using godot_packed_byte_array arg3_in = Marshaling.ConvertSystemArrayToNativePackedByteArray(arg3);
        void** call_args = stackalloc void*[4] { &arg1_in, &arg2_in, &arg3_in, &arg4 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Rid godot_icall_3_1105(IntPtr method, IntPtr ptr, uint arg1, ReadOnlySpan<byte> arg2, godot_bool arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Rid ret;
        long arg1_in = arg1;
        using godot_packed_byte_array arg2_in = Marshaling.ConvertSystemArrayToNativePackedByteArray(arg2);
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2_in, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Rid godot_icall_2_1106(IntPtr method, IntPtr ptr, uint arg1, ReadOnlySpan<byte> arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Rid ret;
        long arg1_in = arg1;
        using godot_packed_byte_array arg2_in = Marshaling.ConvertSystemArrayToNativePackedByteArray(arg2);
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe long godot_icall_10_1107(IntPtr method, IntPtr ptr, Rid arg1, int arg2, int arg3, int arg4, int arg5, ReadOnlySpan<Color> arg6, float arg7, uint arg8, Rect2* arg9, uint arg10)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        long arg2_in = arg2;
        long arg3_in = arg3;
        long arg4_in = arg4;
        long arg5_in = arg5;
        using godot_packed_color_array arg6_in = Marshaling.ConvertSystemArrayToNativePackedColorArray(arg6);
        double arg7_in = arg7;
        long arg8_in = arg8;
        long arg10_in = arg10;
        void** call_args = stackalloc void*[10] { &arg1, &arg2_in, &arg3_in, &arg4_in, &arg5_in, &arg6_in, &arg7_in, &arg8_in, arg9, &arg10_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe long godot_icall_9_1108(IntPtr method, IntPtr ptr, Rid arg1, int arg2, int arg3, int arg4, int arg5, ReadOnlySpan<Color> arg6, float arg7, uint arg8, Rect2* arg9)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        long arg2_in = arg2;
        long arg3_in = arg3;
        long arg4_in = arg4;
        long arg5_in = arg5;
        using godot_packed_color_array arg6_in = Marshaling.ConvertSystemArrayToNativePackedColorArray(arg6);
        double arg7_in = arg7;
        long arg8_in = arg8;
        void** call_args = stackalloc void*[9] { &arg1, &arg2_in, &arg3_in, &arg4_in, &arg5_in, &arg6_in, &arg7_in, &arg8_in, arg9 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe int godot_icall_3_1109(IntPtr method, IntPtr ptr, Rid arg1, Rid arg2, int arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        long arg3_in = arg3;
        void** call_args = stackalloc void*[3] { &arg1, &arg2, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe int godot_icall_7_1110(IntPtr method, IntPtr ptr, Rid arg1, Color* arg2, uint arg3, uint arg4, uint arg5, uint arg6, int arg7)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        long arg3_in = arg3;
        long arg4_in = arg4;
        long arg5_in = arg5;
        long arg6_in = arg6;
        long arg7_in = arg7;
        void** call_args = stackalloc void*[7] { &arg1, arg2, &arg3_in, &arg4_in, &arg5_in, &arg6_in, &arg7_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe int godot_icall_10_1111(IntPtr method, IntPtr ptr, Rid arg1, Rid arg2, Vector3* arg3, Vector3* arg4, Vector3* arg5, uint arg6, uint arg7, uint arg8, uint arg9, int arg10)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        long arg6_in = arg6;
        long arg7_in = arg7;
        long arg8_in = arg8;
        long arg9_in = arg9;
        long arg10_in = arg10;
        void** call_args = stackalloc void*[10] { &arg1, &arg2, arg3, arg4, arg5, &arg6_in, &arg7_in, &arg8_in, &arg9_in, &arg10_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe int godot_icall_4_1112(IntPtr method, IntPtr ptr, Rid arg1, uint arg2, ReadOnlySpan<byte> arg3, int arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        long arg2_in = arg2;
        using godot_packed_byte_array arg3_in = Marshaling.ConvertSystemArrayToNativePackedByteArray(arg3);
        long arg4_in = arg4;
        void** call_args = stackalloc void*[4] { &arg1, &arg2_in, &arg3_in, &arg4_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe int godot_icall_4_1113(IntPtr method, IntPtr ptr, Rid arg1, uint arg2, uint arg3, int arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        long arg2_in = arg2;
        long arg3_in = arg3;
        long arg4_in = arg4;
        void** call_args = stackalloc void*[4] { &arg1, &arg2_in, &arg3_in, &arg4_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe int godot_icall_5_1114(IntPtr method, IntPtr ptr, Rid arg1, uint arg2, uint arg3, ReadOnlySpan<byte> arg4, int arg5)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        long arg2_in = arg2;
        long arg3_in = arg3;
        using godot_packed_byte_array arg4_in = Marshaling.ConvertSystemArrayToNativePackedByteArray(arg4);
        long arg5_in = arg5;
        void** call_args = stackalloc void*[5] { &arg1, &arg2_in, &arg3_in, &arg4_in, &arg5_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe long godot_icall_1_1115(IntPtr method, IntPtr ptr, godot_bool arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe long godot_icall_10_1116(IntPtr method, IntPtr ptr, Rid arg1, int arg2, int arg3, int arg4, int arg5, ReadOnlySpan<Color> arg6, float arg7, uint arg8, Rect2* arg9, godot_array arg10)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        long arg2_in = arg2;
        long arg3_in = arg3;
        long arg4_in = arg4;
        long arg5_in = arg5;
        using godot_packed_color_array arg6_in = Marshaling.ConvertSystemArrayToNativePackedColorArray(arg6);
        double arg7_in = arg7;
        long arg8_in = arg8;
        void** call_args = stackalloc void*[10] { &arg1, &arg2_in, &arg3_in, &arg4_in, &arg5_in, &arg6_in, &arg7_in, &arg8_in, arg9, &arg10 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Rid godot_icall_1_1117(IntPtr method, IntPtr ptr, ReadOnlySpan<byte> arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Rid ret;
        using godot_packed_byte_array arg1_in = Marshaling.ConvertSystemArrayToNativePackedByteArray(arg1);
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Rid godot_icall_2_1118(IntPtr method, IntPtr ptr, godot_array arg1, int arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Rid ret;
        long arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Rid godot_icall_6_1119(IntPtr method, IntPtr ptr, int arg1, int arg2, int arg3, int arg4, godot_bool arg5, godot_array arg6)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Rid ret;
        long arg1_in = arg1;
        long arg2_in = arg2;
        long arg3_in = arg3;
        long arg4_in = arg4;
        void** call_args = stackalloc void*[6] { &arg1_in, &arg2_in, &arg3_in, &arg4_in, &arg5, &arg6 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Rid godot_icall_8_1120(IntPtr method, IntPtr ptr, int arg1, int arg2, ulong arg3, int arg4, int arg5, int arg6, int arg7, int arg8)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Rid ret;
        long arg1_in = arg1;
        long arg2_in = arg2;
        long arg4_in = arg4;
        long arg5_in = arg5;
        long arg6_in = arg6;
        long arg7_in = arg7;
        long arg8_in = arg8;
        void** call_args = stackalloc void*[8] { &arg1_in, &arg2_in, &arg3, &arg4_in, &arg5_in, &arg6_in, &arg7_in, &arg8_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe void godot_icall_3_1121(IntPtr method, IntPtr ptr, Rid arg1, IntPtr arg2, int arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg3_in = arg3;
        void** call_args = stackalloc void*[3] { &arg1, &arg2, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_2_1122(IntPtr method, IntPtr ptr, Rid arg1, godot_array arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[2] { &arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe Rid godot_icall_2_1123(IntPtr method, IntPtr ptr, Rid arg1, godot_bool arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Rid ret;
        void** call_args = stackalloc void*[2] { &arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe ulong godot_icall_2_1124(IntPtr method, IntPtr ptr, Rid arg1, godot_bool arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        ulong ret;
        void** call_args = stackalloc void*[2] { &arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Variant godot_icall_2_1125(IntPtr method, IntPtr ptr, Rid arg1, godot_string_name arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_variant ret = default;
        void** call_args = stackalloc void*[2] { &arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Variant.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe void godot_icall_4_1126(IntPtr method, IntPtr ptr, Rid arg1, godot_string_name arg2, Rid arg3, int arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg4_in = arg4;
        void** call_args = stackalloc void*[4] { &arg1, &arg2, &arg3, &arg4_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe Rid godot_icall_3_1127(IntPtr method, IntPtr ptr, Rid arg1, godot_string_name arg2, int arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Rid ret;
        long arg3_in = arg3;
        void** call_args = stackalloc void*[3] { &arg1, &arg2, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe void godot_icall_3_1128(IntPtr method, IntPtr ptr, Rid arg1, godot_string_name arg2, Variant arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_variant arg3_in = (godot_variant)arg3.NativeVar;
        void** call_args = stackalloc void*[3] { &arg1, &arg2, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe uint godot_icall_3_1129(IntPtr method, IntPtr ptr, int arg1, int arg2, int arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        long arg1_in = arg1;
        long arg2_in = arg2;
        long arg3_in = arg3;
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2_in, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (uint)(ret);
    }

    internal static unsafe uint godot_icall_2_1130(IntPtr method, IntPtr ptr, int arg1, int arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        long arg1_in = arg1;
        long arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (uint)(ret);
    }

    internal static unsafe void godot_icall_2_1131(IntPtr method, IntPtr ptr, Rid arg1, godot_dictionary arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[2] { &arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_6_1132(IntPtr method, IntPtr ptr, Rid arg1, int arg2, godot_array arg3, godot_array arg4, godot_dictionary arg5, int arg6)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg2_in = arg2;
        long arg6_in = arg6;
        void** call_args = stackalloc void*[6] { &arg1, &arg2_in, &arg3, &arg4, &arg5, &arg6_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe Godot.Collections.Dictionary godot_icall_2_1133(IntPtr method, IntPtr ptr, Rid arg1, int arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_dictionary ret = default;
        long arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Godot.Collections.Dictionary.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe Godot.Collections.Array godot_icall_2_1134(IntPtr method, IntPtr ptr, Rid arg1, int arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_array ret = default;
        long arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Godot.Collections.Array.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe void godot_icall_2_1135(IntPtr method, IntPtr ptr, Rid arg1, Aabb* arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[2] { &arg1, arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_4_1136(IntPtr method, IntPtr ptr, Rid arg1, int arg2, int arg3, ReadOnlySpan<byte> arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg2_in = arg2;
        long arg3_in = arg3;
        using godot_packed_byte_array arg4_in = Marshaling.ConvertSystemArrayToNativePackedByteArray(arg4);
        void** call_args = stackalloc void*[4] { &arg1, &arg2_in, &arg3_in, &arg4_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_6_1137(IntPtr method, IntPtr ptr, Rid arg1, int arg2, int arg3, godot_bool arg4, godot_bool arg5, godot_bool arg6)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg2_in = arg2;
        long arg3_in = arg3;
        void** call_args = stackalloc void*[6] { &arg1, &arg2_in, &arg3_in, &arg4, &arg5, &arg6 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_3_1138(IntPtr method, IntPtr ptr, Rid arg1, int arg2, Color* arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg2_in = arg2;
        void** call_args = stackalloc void*[3] { &arg1, &arg2_in, arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe Color godot_icall_2_1139(IntPtr method, IntPtr ptr, Rid arg1, int arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Color ret;
        long arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe void godot_icall_2_1140(IntPtr method, IntPtr ptr, Rid arg1, ReadOnlySpan<float> arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_float32_array arg2_in = Marshaling.ConvertSystemArrayToNativePackedFloat32Array(arg2);
        void** call_args = stackalloc void*[2] { &arg1, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe float[] godot_icall_1_1141(IntPtr method, IntPtr ptr, Rid arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_float32_array ret = default;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertNativePackedFloat32ArrayToSystemArray(ret);
    }

    internal static unsafe void godot_icall_3_1142(IntPtr method, IntPtr ptr, Rid arg1, ReadOnlySpan<float> arg2, ReadOnlySpan<float> arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_float32_array arg2_in = Marshaling.ConvertSystemArrayToNativePackedFloat32Array(arg2);
        using godot_packed_float32_array arg3_in = Marshaling.ConvertSystemArrayToNativePackedFloat32Array(arg3);
        void** call_args = stackalloc void*[3] { &arg1, &arg2_in, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_5_1143(IntPtr method, IntPtr ptr, Rid arg1, godot_bool arg2, float arg3, float arg4, float arg5)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double arg3_in = arg3;
        double arg4_in = arg4;
        double arg5_in = arg5;
        void** call_args = stackalloc void*[5] { &arg1, &arg2, &arg3_in, &arg4_in, &arg5_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_4_1144(IntPtr method, IntPtr ptr, Rid arg1, godot_bool arg2, float arg3, float arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double arg3_in = arg3;
        double arg4_in = arg4;
        void** call_args = stackalloc void*[4] { &arg1, &arg2, &arg3_in, &arg4_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_3_1145(IntPtr method, IntPtr ptr, Rid arg1, float arg2, float arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double arg2_in = arg2;
        double arg3_in = arg3;
        void** call_args = stackalloc void*[3] { &arg1, &arg2_in, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_8_1146(IntPtr method, IntPtr ptr, Rid arg1, Transform3D* arg2, Aabb* arg3, Vector3I* arg4, ReadOnlySpan<byte> arg5, ReadOnlySpan<byte> arg6, ReadOnlySpan<byte> arg7, ReadOnlySpan<int> arg8)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_byte_array arg5_in = Marshaling.ConvertSystemArrayToNativePackedByteArray(arg5);
        using godot_packed_byte_array arg6_in = Marshaling.ConvertSystemArrayToNativePackedByteArray(arg6);
        using godot_packed_byte_array arg7_in = Marshaling.ConvertSystemArrayToNativePackedByteArray(arg7);
        using godot_packed_int32_array arg8_in = Marshaling.ConvertSystemArrayToNativePackedInt32Array(arg8);
        void** call_args = stackalloc void*[8] { &arg1, arg2, arg3, arg4, &arg5_in, &arg6_in, &arg7_in, &arg8_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe Vector3I godot_icall_1_1147(IntPtr method, IntPtr ptr, Rid arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Vector3I ret;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe byte[] godot_icall_1_1148(IntPtr method, IntPtr ptr, Rid arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_byte_array ret = default;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertNativePackedByteArrayToSystemArray(ret);
    }

    internal static unsafe int[] godot_icall_1_1149(IntPtr method, IntPtr ptr, Rid arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_int32_array ret = default;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertNativePackedInt32ArrayToSystemArray(ret);
    }

    internal static unsafe void godot_icall_3_1150(IntPtr method, IntPtr ptr, Rid arg1, Rid arg2, godot_bool arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[3] { &arg1, &arg2, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_5_1151(IntPtr method, IntPtr ptr, Rid arg1, ReadOnlySpan<Vector3> arg2, ReadOnlySpan<Color> arg3, ReadOnlySpan<int> arg4, ReadOnlySpan<int> arg5)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_vector3_array arg2_in = Marshaling.ConvertSystemArrayToNativePackedVector3Array(arg2);
        using godot_packed_color_array arg3_in = Marshaling.ConvertSystemArrayToNativePackedColorArray(arg3);
        using godot_packed_int32_array arg4_in = Marshaling.ConvertSystemArrayToNativePackedInt32Array(arg4);
        using godot_packed_int32_array arg5_in = Marshaling.ConvertSystemArrayToNativePackedInt32Array(arg5);
        void** call_args = stackalloc void*[5] { &arg1, &arg2_in, &arg3_in, &arg4_in, &arg5_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe Color[] godot_icall_1_1152(IntPtr method, IntPtr ptr, Rid arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_color_array ret = default;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertNativePackedColorArrayToSystemArray(ret);
    }

    internal static unsafe void godot_icall_3_1153(IntPtr method, IntPtr ptr, Rid arg1, godot_bool arg2, float arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double arg3_in = arg3;
        void** call_args = stackalloc void*[3] { &arg1, &arg2, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_6_1154(IntPtr method, IntPtr ptr, Rid arg1, Transform3D* arg2, Vector3* arg3, Color* arg4, Color* arg5, uint arg6)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg6_in = arg6;
        void** call_args = stackalloc void*[6] { &arg1, arg2, arg3, arg4, arg5, &arg6_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_3_1155(IntPtr method, IntPtr ptr, Rid arg1, in Callable arg2, in Callable arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_callable arg2_in = Marshaling.ConvertCallableToNative(in arg2);
        using godot_callable arg3_in = Marshaling.ConvertCallableToNative(in arg3);
        void** call_args = stackalloc void*[3] { &arg1, &arg2_in, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_3_1156(IntPtr method, IntPtr ptr, Rid arg1, ReadOnlySpan<Vector3> arg2, ReadOnlySpan<int> arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_vector3_array arg2_in = Marshaling.ConvertSystemArrayToNativePackedVector3Array(arg2);
        using godot_packed_int32_array arg3_in = Marshaling.ConvertSystemArrayToNativePackedInt32Array(arg3);
        void** call_args = stackalloc void*[3] { &arg1, &arg2_in, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_4_1157(IntPtr method, IntPtr ptr, Rid arg1, float arg2, float arg3, float arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double arg2_in = arg2;
        double arg3_in = arg3;
        double arg4_in = arg4;
        void** call_args = stackalloc void*[4] { &arg1, &arg2_in, &arg3_in, &arg4_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_5_1158(IntPtr method, IntPtr ptr, Rid arg1, float arg2, Vector2* arg3, float arg4, float arg5)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double arg2_in = arg2;
        double arg4_in = arg4;
        double arg5_in = arg5;
        void** call_args = stackalloc void*[5] { &arg1, &arg2_in, arg3, &arg4_in, &arg5_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_3_1159(IntPtr method, IntPtr ptr, Rid arg1, Rect2* arg2, int arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg3_in = arg3;
        void** call_args = stackalloc void*[3] { &arg1, arg2, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_3_1160(IntPtr method, IntPtr ptr, Rid arg1, Rid arg2, Transform2D* arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[3] { &arg1, &arg2, arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_4_1161(IntPtr method, IntPtr ptr, Rid arg1, Rid arg2, int arg3, int arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg3_in = arg3;
        long arg4_in = arg4;
        void** call_args = stackalloc void*[4] { &arg1, &arg2, &arg3_in, &arg4_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe int godot_icall_3_1162(IntPtr method, IntPtr ptr, Rid arg1, int arg2, int arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        long arg2_in = arg2;
        long arg3_in = arg3;
        void** call_args = stackalloc void*[3] { &arg1, &arg2_in, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe double godot_icall_1_1163(IntPtr method, IntPtr ptr, Rid arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double ret;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe GodotObject godot_icall_4_1164(IntPtr method, IntPtr ptr, Rid arg1, float arg2, godot_bool arg3, Vector2I* arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_ref ret = default;
        double arg2_in = arg2;
        void** call_args = stackalloc void*[4] { &arg1, &arg2_in, &arg3, arg4 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return InteropUtils.UnmanagedGetManaged(ret.Reference);
    }

    internal static unsafe void godot_icall_2_1165(IntPtr method, IntPtr ptr, Rid arg1, Basis* arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[2] { &arg1, arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_6_1166(IntPtr method, IntPtr ptr, Rid arg1, Color* arg2, int arg3, float arg4, float arg5, int arg6)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg3_in = arg3;
        double arg4_in = arg4;
        double arg5_in = arg5;
        long arg6_in = arg6;
        void** call_args = stackalloc void*[6] { &arg1, arg2, &arg3_in, &arg4_in, &arg5_in, &arg6_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_13_1167(IntPtr method, IntPtr ptr, Rid arg1, godot_bool arg2, ReadOnlySpan<float> arg3, float arg4, float arg5, float arg6, float arg7, int arg8, float arg9, float arg10, float arg11, float arg12, Rid arg13)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_float32_array arg3_in = Marshaling.ConvertSystemArrayToNativePackedFloat32Array(arg3);
        double arg4_in = arg4;
        double arg5_in = arg5;
        double arg6_in = arg6;
        double arg7_in = arg7;
        long arg8_in = arg8;
        double arg9_in = arg9;
        double arg10_in = arg10;
        double arg11_in = arg11;
        double arg12_in = arg12;
        void** call_args = stackalloc void*[13] { &arg1, &arg2, &arg3_in, &arg4_in, &arg5_in, &arg6_in, &arg7_in, &arg8_in, &arg9_in, &arg10_in, &arg11_in, &arg12_in, &arg13 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_4_1168(IntPtr method, IntPtr ptr, Rid arg1, int arg2, float arg3, float arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg2_in = arg2;
        double arg3_in = arg3;
        double arg4_in = arg4;
        void** call_args = stackalloc void*[4] { &arg1, &arg2_in, &arg3_in, &arg4_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_7_1169(IntPtr method, IntPtr ptr, Rid arg1, godot_bool arg2, float arg3, float arg4, float arg5, godot_bool arg6, Rid arg7)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double arg3_in = arg3;
        double arg4_in = arg4;
        double arg5_in = arg5;
        void** call_args = stackalloc void*[7] { &arg1, &arg2, &arg3_in, &arg4_in, &arg5_in, &arg6, &arg7 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_6_1170(IntPtr method, IntPtr ptr, Rid arg1, godot_bool arg2, int arg3, float arg4, float arg5, float arg6)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg3_in = arg3;
        double arg4_in = arg4;
        double arg5_in = arg5;
        double arg6_in = arg6;
        void** call_args = stackalloc void*[6] { &arg1, &arg2, &arg3_in, &arg4_in, &arg5_in, &arg6_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_10_1171(IntPtr method, IntPtr ptr, Rid arg1, godot_bool arg2, float arg3, float arg4, float arg5, float arg6, float arg7, float arg8, float arg9, float arg10)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double arg3_in = arg3;
        double arg4_in = arg4;
        double arg5_in = arg5;
        double arg6_in = arg6;
        double arg7_in = arg7;
        double arg8_in = arg8;
        double arg9_in = arg9;
        double arg10_in = arg10;
        void** call_args = stackalloc void*[10] { &arg1, &arg2, &arg3_in, &arg4_in, &arg5_in, &arg6_in, &arg7_in, &arg8_in, &arg9_in, &arg10_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_11_1172(IntPtr method, IntPtr ptr, Rid arg1, godot_bool arg2, Color* arg3, float arg4, float arg5, float arg6, float arg7, float arg8, float arg9, float arg10, int arg11)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double arg4_in = arg4;
        double arg5_in = arg5;
        double arg6_in = arg6;
        double arg7_in = arg7;
        double arg8_in = arg8;
        double arg9_in = arg9;
        double arg10_in = arg10;
        long arg11_in = arg11;
        void** call_args = stackalloc void*[11] { &arg1, &arg2, arg3, &arg4_in, &arg5_in, &arg6_in, &arg7_in, &arg8_in, &arg9_in, &arg10_in, &arg11_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_11_1173(IntPtr method, IntPtr ptr, Rid arg1, godot_bool arg2, int arg3, float arg4, int arg5, godot_bool arg6, float arg7, godot_bool arg8, float arg9, float arg10, float arg11)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg3_in = arg3;
        double arg4_in = arg4;
        long arg5_in = arg5;
        double arg7_in = arg7;
        double arg9_in = arg9;
        double arg10_in = arg10;
        double arg11_in = arg11;
        void** call_args = stackalloc void*[11] { &arg1, &arg2, &arg3_in, &arg4_in, &arg5_in, &arg6, &arg7_in, &arg8, &arg9_in, &arg10_in, &arg11_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_14_1174(IntPtr method, IntPtr ptr, Rid arg1, godot_bool arg2, float arg3, Color* arg4, Color* arg5, float arg6, float arg7, float arg8, float arg9, float arg10, godot_bool arg11, float arg12, float arg13, float arg14)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double arg3_in = arg3;
        double arg6_in = arg6;
        double arg7_in = arg7;
        double arg8_in = arg8;
        double arg9_in = arg9;
        double arg10_in = arg10;
        double arg12_in = arg12;
        double arg13_in = arg13;
        double arg14_in = arg14;
        void** call_args = stackalloc void*[14] { &arg1, &arg2, &arg3_in, arg4, arg5, &arg6_in, &arg7_in, &arg8_in, &arg9_in, &arg10_in, &arg11, &arg12_in, &arg13_in, &arg14_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_6_1175(IntPtr method, IntPtr ptr, int arg1, godot_bool arg2, float arg3, int arg4, float arg5, float arg6)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        double arg3_in = arg3;
        long arg4_in = arg4;
        double arg5_in = arg5;
        double arg6_in = arg6;
        void** call_args = stackalloc void*[6] { &arg1_in, &arg2, &arg3_in, &arg4_in, &arg5_in, &arg6_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe GodotObject godot_icall_3_1176(IntPtr method, IntPtr ptr, Rid arg1, godot_bool arg2, Vector2I* arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_ref ret = default;
        void** call_args = stackalloc void*[3] { &arg1, &arg2, arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return InteropUtils.UnmanagedGetManaged(ret.Reference);
    }

    internal static unsafe void godot_icall_3_1177(IntPtr method, IntPtr ptr, godot_bool arg1, float arg2, float arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double arg2_in = arg2;
        double arg3_in = arg3;
        void** call_args = stackalloc void*[3] { &arg1, &arg2_in, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_2_1178(IntPtr method, IntPtr ptr, float arg1, float arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double arg1_in = arg1;
        double arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_8_1179(IntPtr method, IntPtr ptr, Rid arg1, godot_bool arg2, float arg3, float arg4, godot_bool arg5, float arg6, float arg7, float arg8)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double arg3_in = arg3;
        double arg4_in = arg4;
        double arg6_in = arg6;
        double arg7_in = arg7;
        double arg8_in = arg8;
        void** call_args = stackalloc void*[8] { &arg1, &arg2, &arg3_in, &arg4_in, &arg5, &arg6_in, &arg7_in, &arg8_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_6_1180(IntPtr method, IntPtr ptr, Rid arg1, godot_bool arg2, float arg3, float arg4, float arg5, float arg6)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double arg3_in = arg3;
        double arg4_in = arg4;
        double arg5_in = arg5;
        double arg6_in = arg6;
        void** call_args = stackalloc void*[6] { &arg1, &arg2, &arg3_in, &arg4_in, &arg5_in, &arg6_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe Rid godot_icall_2_1181(IntPtr method, IntPtr ptr, Rid arg1, Rid arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Rid ret;
        void** call_args = stackalloc void*[2] { &arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe void godot_icall_3_1182(IntPtr method, IntPtr ptr, Rid arg1, float arg2, godot_bool arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double arg2_in = arg2;
        void** call_args = stackalloc void*[3] { &arg1, &arg2_in, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_6_1183(IntPtr method, IntPtr ptr, Rid arg1, float arg2, float arg3, float arg4, float arg5, int arg6)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double arg2_in = arg2;
        double arg3_in = arg3;
        double arg4_in = arg4;
        double arg5_in = arg5;
        long arg6_in = arg6;
        void** call_args = stackalloc void*[6] { &arg1, &arg2_in, &arg3_in, &arg4_in, &arg5_in, &arg6_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_4_1184(IntPtr method, IntPtr ptr, Rid arg1, Rid arg2, Rect2* arg3, int arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg4_in = arg4;
        void** call_args = stackalloc void*[4] { &arg1, &arg2, arg3, &arg4_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe long[] godot_icall_2_1185(IntPtr method, IntPtr ptr, Aabb* arg1, Rid arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_int64_array ret = default;
        void** call_args = stackalloc void*[2] { arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertNativePackedInt64ArrayToSystemArray(ret);
    }

    internal static unsafe long[] godot_icall_3_1186(IntPtr method, IntPtr ptr, Vector3* arg1, Vector3* arg2, Rid arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_int64_array ret = default;
        void** call_args = stackalloc void*[3] { arg1, arg2, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertNativePackedInt64ArrayToSystemArray(ret);
    }

    internal static unsafe long[] godot_icall_2_1187(IntPtr method, IntPtr ptr, godot_array arg1, Rid arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_int64_array ret = default;
        void** call_args = stackalloc void*[2] { &arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertNativePackedInt64ArrayToSystemArray(ret);
    }

    internal static unsafe Godot.Collections.Array godot_icall_3_1188(IntPtr method, IntPtr ptr, Rid arg1, godot_array arg2, Vector2I* arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_array ret = default;
        void** call_args = stackalloc void*[3] { &arg1, &arg2, arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Godot.Collections.Array.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe void godot_icall_3_1189(IntPtr method, IntPtr ptr, Rid arg1, Rid arg2, Vector2* arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[3] { &arg1, &arg2, arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_3_1190(IntPtr method, IntPtr ptr, Rid arg1, Vector2* arg2, int arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg3_in = arg3;
        void** call_args = stackalloc void*[3] { &arg1, arg2, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_3_1191(IntPtr method, IntPtr ptr, Rid arg1, Color* arg2, float arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double arg3_in = arg3;
        void** call_args = stackalloc void*[3] { &arg1, arg2, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_3_1192(IntPtr method, IntPtr ptr, Rid arg1, godot_bool arg2, Rect2* arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[3] { &arg1, &arg2, arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_6_1193(IntPtr method, IntPtr ptr, Rid arg1, Vector2* arg2, Vector2* arg3, Color* arg4, float arg5, godot_bool arg6)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double arg5_in = arg5;
        void** call_args = stackalloc void*[6] { &arg1, arg2, arg3, arg4, &arg5_in, &arg6 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_5_1194(IntPtr method, IntPtr ptr, Rid arg1, ReadOnlySpan<Vector2> arg2, ReadOnlySpan<Color> arg3, float arg4, godot_bool arg5)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_vector2_array arg2_in = Marshaling.ConvertSystemArrayToNativePackedVector2Array(arg2);
        using godot_packed_color_array arg3_in = Marshaling.ConvertSystemArrayToNativePackedColorArray(arg3);
        double arg4_in = arg4;
        void** call_args = stackalloc void*[5] { &arg1, &arg2_in, &arg3_in, &arg4_in, &arg5 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_4_1195(IntPtr method, IntPtr ptr, Rid arg1, Rect2* arg2, Color* arg3, godot_bool arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[4] { &arg1, arg2, arg3, &arg4 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_5_1196(IntPtr method, IntPtr ptr, Rid arg1, Vector2* arg2, float arg3, Color* arg4, godot_bool arg5)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double arg3_in = arg3;
        void** call_args = stackalloc void*[5] { &arg1, arg2, &arg3_in, arg4, &arg5 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_6_1197(IntPtr method, IntPtr ptr, Rid arg1, Vector2* arg2, float arg3, float arg4, Color* arg5, godot_bool arg6)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double arg3_in = arg3;
        double arg4_in = arg4;
        void** call_args = stackalloc void*[6] { &arg1, arg2, &arg3_in, &arg4_in, arg5, &arg6 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_6_1198(IntPtr method, IntPtr ptr, Rid arg1, Rect2* arg2, Rid arg3, godot_bool arg4, Color* arg5, godot_bool arg6)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[6] { &arg1, arg2, &arg3, &arg4, arg5, &arg6 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_8_1199(IntPtr method, IntPtr ptr, Rid arg1, Rect2* arg2, Rid arg3, Rect2* arg4, Color* arg5, int arg6, float arg7, float arg8)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg6_in = arg6;
        double arg7_in = arg7;
        double arg8_in = arg8;
        void** call_args = stackalloc void*[8] { &arg1, arg2, &arg3, arg4, arg5, &arg6_in, &arg7_in, &arg8_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_5_1200(IntPtr method, IntPtr ptr, Rid arg1, Rect2* arg2, Rid arg3, Rect2* arg4, Color* arg5)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[5] { &arg1, arg2, &arg3, arg4, arg5 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_7_1201(IntPtr method, IntPtr ptr, Rid arg1, Rect2* arg2, Rid arg3, Rect2* arg4, Color* arg5, godot_bool arg6, godot_bool arg7)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[7] { &arg1, arg2, &arg3, arg4, arg5, &arg6, &arg7 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_10_1202(IntPtr method, IntPtr ptr, Rid arg1, Rect2* arg2, Rect2* arg3, Rid arg4, Vector2* arg5, Vector2* arg6, int arg7, int arg8, godot_bool arg9, Color* arg10)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg7_in = arg7;
        long arg8_in = arg8;
        void** call_args = stackalloc void*[10] { &arg1, arg2, arg3, &arg4, arg5, arg6, &arg7_in, &arg8_in, &arg9, arg10 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_5_1203(IntPtr method, IntPtr ptr, Rid arg1, ReadOnlySpan<Vector2> arg2, ReadOnlySpan<Color> arg3, ReadOnlySpan<Vector2> arg4, Rid arg5)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_vector2_array arg2_in = Marshaling.ConvertSystemArrayToNativePackedVector2Array(arg2);
        using godot_packed_color_array arg3_in = Marshaling.ConvertSystemArrayToNativePackedColorArray(arg3);
        using godot_packed_vector2_array arg4_in = Marshaling.ConvertSystemArrayToNativePackedVector2Array(arg4);
        void** call_args = stackalloc void*[5] { &arg1, &arg2_in, &arg3_in, &arg4_in, &arg5 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_9_1204(IntPtr method, IntPtr ptr, Rid arg1, ReadOnlySpan<int> arg2, ReadOnlySpan<Vector2> arg3, ReadOnlySpan<Color> arg4, ReadOnlySpan<Vector2> arg5, ReadOnlySpan<int> arg6, ReadOnlySpan<float> arg7, Rid arg8, int arg9)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_int32_array arg2_in = Marshaling.ConvertSystemArrayToNativePackedInt32Array(arg2);
        using godot_packed_vector2_array arg3_in = Marshaling.ConvertSystemArrayToNativePackedVector2Array(arg3);
        using godot_packed_color_array arg4_in = Marshaling.ConvertSystemArrayToNativePackedColorArray(arg4);
        using godot_packed_vector2_array arg5_in = Marshaling.ConvertSystemArrayToNativePackedVector2Array(arg5);
        using godot_packed_int32_array arg6_in = Marshaling.ConvertSystemArrayToNativePackedInt32Array(arg6);
        using godot_packed_float32_array arg7_in = Marshaling.ConvertSystemArrayToNativePackedFloat32Array(arg7);
        long arg9_in = arg9;
        void** call_args = stackalloc void*[9] { &arg1, &arg2_in, &arg3_in, &arg4_in, &arg5_in, &arg6_in, &arg7_in, &arg8, &arg9_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_5_1205(IntPtr method, IntPtr ptr, Rid arg1, Rid arg2, Transform2D* arg3, Color* arg4, Rid arg5)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[5] { &arg1, &arg2, arg3, arg4, &arg5 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_3_1206(IntPtr method, IntPtr ptr, Rid arg1, Rid arg2, Rid arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[3] { &arg1, &arg2, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_5_1207(IntPtr method, IntPtr ptr, Rid arg1, double arg2, double arg3, double arg4, double arg5)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[5] { &arg1, &arg2, &arg3, &arg4, &arg5 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_5_1208(IntPtr method, IntPtr ptr, Rid arg1, godot_bool arg2, Rect2* arg3, in Callable arg4, in Callable arg5)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_callable arg4_in = Marshaling.ConvertCallableToNative(in arg4);
        using godot_callable arg5_in = Marshaling.ConvertCallableToNative(in arg5);
        void** call_args = stackalloc void*[5] { &arg1, &arg2, arg3, &arg4_in, &arg5_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_6_1209(IntPtr method, IntPtr ptr, Rid arg1, int arg2, float arg3, godot_bool arg4, float arg5, godot_bool arg6)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg2_in = arg2;
        double arg3_in = arg3;
        double arg5_in = arg5;
        void** call_args = stackalloc void*[6] { &arg1, &arg2_in, &arg3_in, &arg4, &arg5_in, &arg6 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_3_1210(IntPtr method, IntPtr ptr, Rid arg1, ReadOnlySpan<Vector2> arg2, godot_bool arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_vector2_array arg2_in = Marshaling.ConvertSystemArrayToNativePackedVector2Array(arg2);
        void** call_args = stackalloc void*[3] { &arg1, &arg2_in, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_3_1211(IntPtr method, IntPtr ptr, godot_string_name arg1, int arg2, Variant arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg2_in = arg2;
        godot_variant arg3_in = (godot_variant)arg3.NativeVar;
        void** call_args = stackalloc void*[3] { &arg1, &arg2_in, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe Rid godot_icall_3_1212(IntPtr method, IntPtr ptr, int arg1, int arg2, float arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Rid ret;
        long arg1_in = arg1;
        long arg2_in = arg2;
        double arg3_in = arg3;
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2_in, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe void godot_icall_4_1213(IntPtr method, IntPtr ptr, IntPtr arg1, Color* arg2, int arg3, godot_bool arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg3_in = arg3;
        void** call_args = stackalloc void*[4] { &arg1, arg2, &arg3_in, &arg4 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_4_1214(IntPtr method, IntPtr ptr, IntPtr arg1, Color* arg2, godot_bool arg3, godot_bool arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[4] { &arg1, arg2, &arg3, &arg4 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_2_1215(IntPtr method, IntPtr ptr, godot_bool arg1, double arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[2] { &arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_4_1216(IntPtr method, IntPtr ptr, Rid arg1, Vector2* arg2, float arg3, Color* arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double arg3_in = arg3;
        void** call_args = stackalloc void*[4] { &arg1, arg2, &arg3_in, arg4 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_3_1217(IntPtr method, IntPtr ptr, Rid arg1, Rect2* arg2, Color* arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[3] { &arg1, arg2, arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_4_1218(IntPtr method, IntPtr ptr, Rid arg1, ReadOnlySpan<Vector2> arg2, ReadOnlySpan<Color> arg3, float arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_vector2_array arg2_in = Marshaling.ConvertSystemArrayToNativePackedVector2Array(arg2);
        using godot_packed_color_array arg3_in = Marshaling.ConvertSystemArrayToNativePackedColorArray(arg3);
        double arg4_in = arg4;
        void** call_args = stackalloc void*[4] { &arg1, &arg2_in, &arg3_in, &arg4_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_10_1219(IntPtr method, IntPtr ptr, Rid arg1, godot_bool arg2, Color* arg3, float arg4, float arg5, float arg6, float arg7, float arg8, float arg9, float arg10)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double arg4_in = arg4;
        double arg5_in = arg5;
        double arg6_in = arg6;
        double arg7_in = arg7;
        double arg8_in = arg8;
        double arg9_in = arg9;
        double arg10_in = arg10;
        void** call_args = stackalloc void*[10] { &arg1, &arg2, arg3, &arg4_in, &arg5_in, &arg6_in, &arg7_in, &arg8_in, &arg9_in, &arg10_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_5_1220(IntPtr method, IntPtr ptr, Rid arg1, int arg2, int arg3, godot_bool arg4, godot_bool arg5)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg2_in = arg2;
        long arg3_in = arg3;
        void** call_args = stackalloc void*[5] { &arg1, &arg2_in, &arg3_in, &arg4, &arg5 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe string godot_icall_0_1221(IntPtr method)
    {
        using godot_string ret = default;
        NativeFuncs.godotsharp_method_bind_ptrcall(method, IntPtr.Zero, null, &ret);
        return Marshaling.ConvertStringToManaged(ret);
    }

    internal static unsafe int godot_icall_4_1222(IntPtr method, IntPtr ptr, string arg1, string arg2, godot_bool arg3, int arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        using godot_string arg2_in = Marshaling.ConvertStringToNative(arg2);
        long arg4_in = arg4;
        void** call_args = stackalloc void*[4] { &arg1_in, &arg2_in, &arg3, &arg4_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe int godot_icall_2_1223(IntPtr method, IntPtr ptr, string arg1, godot_array arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe GodotObject godot_icall_3_1224(IntPtr method, IntPtr ptr, string arg1, string arg2, int arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_ref ret = default;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        using godot_string arg2_in = Marshaling.ConvertStringToNative(arg2);
        long arg3_in = arg3;
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2_in, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return InteropUtils.UnmanagedGetManaged(ret.Reference);
    }

    internal static unsafe long godot_icall_1_1225(IntPtr method, IntPtr ptr, string arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe int godot_icall_3_1226(IntPtr method, IntPtr ptr, IntPtr arg1, string arg2, int arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        using godot_string arg2_in = Marshaling.ConvertStringToNative(arg2);
        long arg3_in = arg3;
        void** call_args = stackalloc void*[3] { &arg1, &arg2_in, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe int godot_icall_2_1227(IntPtr method, IntPtr ptr, string arg1, long arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe string[] godot_icall_1_1228(IntPtr method, IntPtr ptr, IntPtr arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_string_array ret = default;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertNativePackedStringArrayToSystemArray(ret);
    }

    internal static unsafe long godot_icall_2_1229(IntPtr method, IntPtr ptr, string arg1, godot_bool arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe void godot_icall_2_1230(IntPtr method, IntPtr ptr, long arg1, string arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string arg2_in = Marshaling.ConvertStringToNative(arg2);
        void** call_args = stackalloc void*[2] { &arg1, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_6_1231(IntPtr method, IntPtr ptr, int arg1, int arg2, Color* arg3, int arg4, godot_bool arg5, godot_bool arg6)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        long arg2_in = arg2;
        long arg4_in = arg4;
        void** call_args = stackalloc void*[6] { &arg1_in, &arg2_in, arg3, &arg4_in, &arg5, &arg6 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_12_1232(IntPtr method, IntPtr ptr, IntPtr arg1, int arg2, int arg3, Color* arg4, int arg5, Rect2* arg6, Variant arg7, godot_bool arg8, string arg9, godot_bool arg10, godot_bool arg11, string arg12)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg2_in = arg2;
        long arg3_in = arg3;
        long arg5_in = arg5;
        godot_variant arg7_in = (godot_variant)arg7.NativeVar;
        using godot_string arg9_in = Marshaling.ConvertStringToNative(arg9);
        using godot_string arg12_in = Marshaling.ConvertStringToNative(arg12);
        void** call_args = stackalloc void*[12] { &arg1, &arg2_in, &arg3_in, arg4, &arg5_in, arg6, &arg7_in, &arg8, &arg9_in, &arg10, &arg11, &arg12_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_12_1233(IntPtr method, IntPtr ptr, Variant arg1, int arg2, IntPtr arg3, int arg4, int arg5, Color* arg6, int arg7, Rect2* arg8, godot_bool arg9, string arg10, godot_bool arg11, godot_bool arg12)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_variant arg1_in = (godot_variant)arg1.NativeVar;
        long arg2_in = arg2;
        long arg4_in = arg4;
        long arg5_in = arg5;
        long arg7_in = arg7;
        using godot_string arg10_in = Marshaling.ConvertStringToNative(arg10);
        void** call_args = stackalloc void*[12] { &arg1_in, &arg2_in, &arg3, &arg4_in, &arg5_in, arg6, &arg7_in, arg8, &arg9, &arg10_in, &arg11, &arg12 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe godot_bool godot_icall_2_1234(IntPtr method, IntPtr ptr, int arg1, godot_bool arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_bool ret;
        long arg1_in = arg1;
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe void godot_icall_6_1235(IntPtr method, IntPtr ptr, int arg1, int arg2, string arg3, int arg4, int arg5, ReadOnlySpan<float> arg6)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        long arg2_in = arg2;
        using godot_string arg3_in = Marshaling.ConvertStringToNative(arg3);
        long arg4_in = arg4;
        long arg5_in = arg5;
        using godot_packed_float32_array arg6_in = Marshaling.ConvertSystemArrayToNativePackedFloat32Array(arg6);
        void** call_args = stackalloc void*[6] { &arg1_in, &arg2_in, &arg3_in, &arg4_in, &arg5_in, &arg6_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_4_1236(IntPtr method, IntPtr ptr, int arg1, int arg2, godot_bool arg3, string arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        long arg2_in = arg2;
        using godot_string arg4_in = Marshaling.ConvertStringToNative(arg4);
        void** call_args = stackalloc void*[4] { &arg1_in, &arg2_in, &arg3, &arg4_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_3_1237(IntPtr method, IntPtr ptr, Variant arg1, int arg2, string arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_variant arg1_in = (godot_variant)arg1.NativeVar;
        long arg2_in = arg2;
        using godot_string arg3_in = Marshaling.ConvertStringToNative(arg3);
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2_in, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_4_1238(IntPtr method, IntPtr ptr, int arg1, int arg2, int arg3, string arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        long arg2_in = arg2;
        long arg3_in = arg3;
        using godot_string arg4_in = Marshaling.ConvertStringToNative(arg4);
        void** call_args = stackalloc void*[4] { &arg1_in, &arg2_in, &arg3_in, &arg4_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_7_1239(IntPtr method, IntPtr ptr, string arg1, IntPtr arg2, int arg3, Rect2* arg4, Color* arg5, int arg6, Color* arg7)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        long arg3_in = arg3;
        long arg6_in = arg6;
        void** call_args = stackalloc void*[7] { &arg1_in, &arg2, &arg3_in, arg4, arg5, &arg6_in, arg7 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_4_1240(IntPtr method, IntPtr ptr, int arg1, godot_bool arg2, int arg3, godot_bool arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        long arg3_in = arg3;
        void** call_args = stackalloc void*[4] { &arg1_in, &arg2, &arg3_in, &arg4 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_2_1241(IntPtr method, IntPtr ptr, Color* arg1, Color* arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[2] { arg1, arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_2_1242(IntPtr method, IntPtr ptr, IntPtr arg1, godot_dictionary arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[2] { &arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe Godot.Collections.Dictionary godot_icall_1_1243(IntPtr method, IntPtr ptr, ReadOnlySpan<string> arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_dictionary ret = default;
        using godot_packed_string_array arg1_in = Marshaling.ConvertSystemArrayToNativePackedStringArray(arg1);
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Godot.Collections.Dictionary.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe void godot_icall_11_1244(IntPtr method, IntPtr ptr, Variant arg1, int arg2, IntPtr arg3, int arg4, int arg5, Color* arg6, int arg7, Rect2* arg8, godot_bool arg9, string arg10, godot_bool arg11)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_variant arg1_in = (godot_variant)arg1.NativeVar;
        long arg2_in = arg2;
        long arg4_in = arg4;
        long arg5_in = arg5;
        long arg7_in = arg7;
        using godot_string arg10_in = Marshaling.ConvertStringToNative(arg10);
        void** call_args = stackalloc void*[11] { &arg1_in, &arg2_in, &arg3, &arg4_in, &arg5_in, arg6, &arg7_in, arg8, &arg9, &arg10_in, &arg11 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_11_1245(IntPtr method, IntPtr ptr, IntPtr arg1, int arg2, int arg3, Color* arg4, int arg5, Rect2* arg6, Variant arg7, godot_bool arg8, string arg9, godot_bool arg10, string arg11)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg2_in = arg2;
        long arg3_in = arg3;
        long arg5_in = arg5;
        godot_variant arg7_in = (godot_variant)arg7.NativeVar;
        using godot_string arg9_in = Marshaling.ConvertStringToNative(arg9);
        using godot_string arg11_in = Marshaling.ConvertStringToNative(arg11);
        void** call_args = stackalloc void*[11] { &arg1, &arg2_in, &arg3_in, arg4, &arg5_in, arg6, &arg7_in, &arg8, &arg9_in, &arg10, &arg11_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_10_1246(IntPtr method, IntPtr ptr, IntPtr arg1, int arg2, int arg3, Color* arg4, int arg5, Rect2* arg6, Variant arg7, godot_bool arg8, string arg9, godot_bool arg10)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg2_in = arg2;
        long arg3_in = arg3;
        long arg5_in = arg5;
        godot_variant arg7_in = (godot_variant)arg7.NativeVar;
        using godot_string arg9_in = Marshaling.ConvertStringToNative(arg9);
        void** call_args = stackalloc void*[10] { &arg1, &arg2_in, &arg3_in, arg4, &arg5_in, arg6, &arg7_in, &arg8, &arg9_in, &arg10 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_6_1247(IntPtr method, IntPtr ptr, IntPtr arg1, int arg2, int arg3, Color* arg4, int arg5, Rect2* arg6)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg2_in = arg2;
        long arg3_in = arg3;
        long arg5_in = arg5;
        void** call_args = stackalloc void*[6] { &arg1, &arg2_in, &arg3_in, arg4, &arg5_in, arg6 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_2_1248(IntPtr method, IntPtr ptr, Variant arg1, int arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_variant arg1_in = (godot_variant)arg1.NativeVar;
        long arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe int godot_icall_4_1249(IntPtr method, IntPtr ptr, ReadOnlySpan<byte> arg1, int arg2, int arg3, int arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        using godot_packed_byte_array arg1_in = Marshaling.ConvertSystemArrayToNativePackedByteArray(arg1);
        long arg2_in = arg2;
        long arg3_in = arg3;
        long arg4_in = arg4;
        void** call_args = stackalloc void*[4] { &arg1_in, &arg2_in, &arg3_in, &arg4_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe void godot_icall_2_1250(IntPtr method, IntPtr ptr, godot_node_path arg1, int arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe int godot_icall_1_1251(IntPtr method, IntPtr ptr, godot_node_path arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe NodePath godot_icall_2_1252(IntPtr method, IntPtr ptr, int arg1, godot_bool arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_node_path ret = default;
        long arg1_in = arg1;
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return NodePath.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe GodotObject godot_icall_4_1253(IntPtr method, IntPtr ptr, double arg1, godot_bool arg2, godot_bool arg3, godot_bool arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_ref ret = default;
        void** call_args = stackalloc void*[4] { &arg1, &arg2, &arg3, &arg4 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return InteropUtils.UnmanagedGetManaged(ret.Reference);
    }

    internal static unsafe void godot_icall_4_1254(IntPtr method, IntPtr ptr, long arg1, godot_string_name arg2, godot_string_name arg3, ReadOnlySpan<Variant> arg4, godot_string_name caller)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        int vararg_length = arg4.Length;
        int total_length = 3 + vararg_length;
        Span<godot_variant.movable> varargs_span = vararg_length <= VarArgsSpanThreshold ?
            stackalloc godot_variant.movable[VarArgsSpanThreshold] :
            new godot_variant.movable[vararg_length];
        Span<IntPtr> call_args_span = total_length <= VarArgsSpanThreshold ?
            stackalloc IntPtr[VarArgsSpanThreshold] :
            new IntPtr[total_length];
        fixed (godot_variant.movable* varargs = &MemoryMarshal.GetReference(varargs_span))
        fixed (IntPtr* call_args = &MemoryMarshal.GetReference(call_args_span))
        {
            using godot_variant arg1_in = VariantUtils.CreateFromInt(arg1);
            call_args[0] = new IntPtr(&arg1_in);
            using godot_variant arg2_in = VariantUtils.CreateFromStringName(arg2);
            call_args[1] = new IntPtr(&arg2_in);
            using godot_variant arg3_in = VariantUtils.CreateFromStringName(arg3);
            call_args[2] = new IntPtr(&arg3_in);
            for (int i = 0; i < vararg_length; i++)
            {
                varargs[i] = arg4[i].NativeVar;
                call_args[3 + i] = new IntPtr(&varargs[i]);
            }
            NativeFuncs.godotsharp_method_bind_call(method, ptr, (godot_variant**)call_args, total_length, out godot_variant_call_error vcall_error);
            ExceptionUtils.DebugCheckCallError(caller, ptr, (godot_variant**)call_args, total_length, vcall_error);
        }
    }

    internal static unsafe void godot_icall_3_1255(IntPtr method, IntPtr ptr, uint arg1, godot_string_name arg2, int arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        long arg3_in = arg3;
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_4_1256(IntPtr method, IntPtr ptr, uint arg1, godot_string_name arg2, string arg3, Variant arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        using godot_string arg3_in = Marshaling.ConvertStringToNative(arg3);
        godot_variant arg4_in = (godot_variant)arg4.NativeVar;
        void** call_args = stackalloc void*[4] { &arg1_in, &arg2, &arg3_in, &arg4_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_3_1257(IntPtr method, IntPtr ptr, godot_string_name arg1, godot_string_name arg2, ReadOnlySpan<Variant> arg3, godot_string_name caller)
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
            using godot_variant arg1_in = VariantUtils.CreateFromStringName(arg1);
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

    internal static unsafe void godot_icall_3_1258(IntPtr method, IntPtr ptr, godot_string_name arg1, string arg2, Variant arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string arg2_in = Marshaling.ConvertStringToNative(arg2);
        godot_variant arg3_in = (godot_variant)arg3.NativeVar;
        void** call_args = stackalloc void*[3] { &arg1, &arg2_in, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_2_1259(IntPtr method, IntPtr ptr, IntPtr arg1, godot_node_path arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[2] { &arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe GodotObject godot_icall_1_1260(IntPtr method, IntPtr ptr, godot_node_path arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_ref ret = default;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return InteropUtils.UnmanagedGetManaged(ret.Reference);
    }

    internal static unsafe void godot_icall_3_1262(IntPtr method, IntPtr ptr, godot_string_name arg1, IntPtr arg2, int arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg3_in = arg3;
        void** call_args = stackalloc void*[3] { &arg1, &arg2, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe GodotObject godot_icall_2_1263(IntPtr method, IntPtr ptr, godot_string_name arg1, int arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_ref ret = default;
        long arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return InteropUtils.UnmanagedGetManaged(ret.Reference);
    }

    internal static unsafe godot_bool godot_icall_3_1264(IntPtr method, IntPtr ptr, Transform2D* arg1, IntPtr arg2, Transform2D* arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_bool ret;
        void** call_args = stackalloc void*[3] { arg1, &arg2, arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe godot_bool godot_icall_5_1265(IntPtr method, IntPtr ptr, Transform2D* arg1, Vector2* arg2, IntPtr arg3, Transform2D* arg4, Vector2* arg5)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_bool ret;
        void** call_args = stackalloc void*[5] { arg1, arg2, &arg3, arg4, arg5 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Vector2[] godot_icall_3_1266(IntPtr method, IntPtr ptr, Transform2D* arg1, IntPtr arg2, Transform2D* arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_vector2_array ret = default;
        void** call_args = stackalloc void*[3] { arg1, &arg2, arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertNativePackedVector2ArrayToSystemArray(ret);
    }

    internal static unsafe Vector2[] godot_icall_5_1267(IntPtr method, IntPtr ptr, Transform2D* arg1, Vector2* arg2, IntPtr arg3, Transform2D* arg4, Vector2* arg5)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_vector2_array ret = default;
        void** call_args = stackalloc void*[5] { arg1, arg2, &arg3, arg4, arg5 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertNativePackedVector2ArrayToSystemArray(ret);
    }

    internal static unsafe void godot_icall_2_1268(IntPtr method, IntPtr ptr, float arg1, int arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double arg1_in = arg1;
        long arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_4_1269(IntPtr method, IntPtr ptr, int arg1, Transform2D* arg2, float arg3, godot_bool arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        double arg3_in = arg3;
        void** call_args = stackalloc void*[4] { &arg1_in, arg2, &arg3_in, &arg4 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe Variant godot_icall_2_1270(IntPtr method, IntPtr ptr, int arg1, godot_string_name arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_variant ret = default;
        long arg1_in = arg1;
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Variant.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe void godot_icall_3_1271(IntPtr method, IntPtr ptr, int arg1, godot_string_name arg2, Variant arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        godot_variant arg3_in = (godot_variant)arg3.NativeVar;
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_4_1272(IntPtr method, IntPtr ptr, int arg1, Transform3D* arg2, float arg3, godot_bool arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        double arg3_in = arg3;
        void** call_args = stackalloc void*[4] { &arg1_in, arg2, &arg3_in, &arg4 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe float godot_icall_4_1273(IntPtr method, IntPtr ptr, float arg1, float arg2, float arg3, godot_bool arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double ret;
        double arg1_in = arg1;
        double arg2_in = arg2;
        double arg3_in = arg3;
        void** call_args = stackalloc void*[4] { &arg1_in, &arg2_in, &arg3_in, &arg4 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (float)ret;
    }

    internal static unsafe void godot_icall_2_1274(IntPtr method, IntPtr ptr, string arg1, Transform3D* arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        void** call_args = stackalloc void*[2] { &arg1_in, arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_4_1275(IntPtr method, IntPtr ptr, int arg1, godot_bool arg2, godot_node_path arg3, int arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        long arg4_in = arg4;
        void** call_args = stackalloc void*[4] { &arg1_in, &arg2, &arg3, &arg4_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_3_1276(IntPtr method, IntPtr ptr, int arg1, godot_bool arg2, godot_node_path arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_3_1277(IntPtr method, IntPtr ptr, int arg1, int arg2, godot_node_path arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        long arg2_in = arg2;
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2_in, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe NodePath godot_icall_2_1278(IntPtr method, IntPtr ptr, int arg1, int arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_node_path ret = default;
        long arg1_in = arg1;
        long arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return NodePath.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe void godot_icall_4_1279(IntPtr method, IntPtr ptr, godot_string_name arg1, IntPtr arg2, float arg3, int arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double arg3_in = arg3;
        long arg4_in = arg4;
        void** call_args = stackalloc void*[4] { &arg1, &arg2, &arg3_in, &arg4_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_4_1280(IntPtr method, IntPtr ptr, godot_string_name arg1, int arg2, IntPtr arg3, float arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg2_in = arg2;
        double arg4_in = arg4;
        void** call_args = stackalloc void*[4] { &arg1, &arg2_in, &arg3, &arg4_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe float godot_icall_2_1281(IntPtr method, IntPtr ptr, godot_string_name arg1, int arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double ret;
        long arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (float)ret;
    }

    internal static unsafe Godot.Collections.Array godot_icall_1_1282(IntPtr method, IntPtr ptr, ReadOnlySpan<byte> arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_array ret = default;
        using godot_packed_byte_array arg1_in = Marshaling.ConvertSystemArrayToNativePackedByteArray(arg1);
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Godot.Collections.Array.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe void godot_icall_1_1283(IntPtr method, IntPtr ptr, sbyte arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_1_1284(IntPtr method, IntPtr ptr, short arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_2_1285(IntPtr method, IntPtr ptr, Variant arg1, godot_bool arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_variant arg1_in = (godot_variant)arg1.NativeVar;
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe sbyte godot_icall_0_1286(IntPtr method, IntPtr ptr)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, null, &ret);
        return (sbyte)(ret);
    }

    internal static unsafe short godot_icall_0_1287(IntPtr method, IntPtr ptr)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, null, &ret);
        return (short)(ret);
    }

    internal static unsafe int godot_icall_2_1288(IntPtr method, IntPtr ptr, godot_bool arg1, int arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        long arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe int godot_icall_2_1289(IntPtr method, IntPtr ptr, int arg1, string arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        long arg1_in = arg1;
        using godot_string arg2_in = Marshaling.ConvertStringToNative(arg2);
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe int godot_icall_2_1290(IntPtr method, IntPtr ptr, IntPtr arg1, IntPtr arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        void** call_args = stackalloc void*[2] { &arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe godot_bool godot_icall_2_1291(IntPtr method, IntPtr ptr, Vector2* arg1, Rect2* arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_bool ret;
        void** call_args = stackalloc void*[2] { arg1, arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe void godot_icall_6_1292(IntPtr method, IntPtr ptr, ReadOnlySpan<Vector3> arg1, ReadOnlySpan<Vector2> arg2, ReadOnlySpan<Color> arg3, ReadOnlySpan<Vector2> arg4, ReadOnlySpan<Vector3> arg5, godot_array arg6)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_vector3_array arg1_in = Marshaling.ConvertSystemArrayToNativePackedVector3Array(arg1);
        using godot_packed_vector2_array arg2_in = Marshaling.ConvertSystemArrayToNativePackedVector2Array(arg2);
        using godot_packed_color_array arg3_in = Marshaling.ConvertSystemArrayToNativePackedColorArray(arg3);
        using godot_packed_vector2_array arg4_in = Marshaling.ConvertSystemArrayToNativePackedVector2Array(arg4);
        using godot_packed_vector3_array arg5_in = Marshaling.ConvertSystemArrayToNativePackedVector3Array(arg5);
        void** call_args = stackalloc void*[6] { &arg1_in, &arg2_in, &arg3_in, &arg4_in, &arg5_in, &arg6 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe int[] godot_icall_2_1293(IntPtr method, IntPtr ptr, float arg1, int arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_int32_array ret = default;
        double arg1_in = arg1;
        long arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertNativePackedInt32ArrayToSystemArray(ret);
    }

    internal static unsafe void godot_icall_2_1294(IntPtr method, IntPtr ptr, godot_array arg1, int arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_3_1295(IntPtr method, IntPtr ptr, IntPtr arg1, int arg2, string arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg2_in = arg2;
        using godot_string arg3_in = Marshaling.ConvertStringToNative(arg3);
        void** call_args = stackalloc void*[3] { &arg1, &arg2_in, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe GodotObject godot_icall_2_1296(IntPtr method, IntPtr ptr, IntPtr arg1, ulong arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_ref ret = default;
        void** call_args = stackalloc void*[2] { &arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return InteropUtils.UnmanagedGetManaged(ret.Reference);
    }

    internal static unsafe int godot_icall_2_1297(IntPtr method, IntPtr ptr, ushort arg1, string arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        long arg1_in = arg1;
        using godot_string arg2_in = Marshaling.ConvertStringToNative(arg2);
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe GodotObject godot_icall_2_1298(IntPtr method, IntPtr arg1, IntPtr arg2)
    {
        using godot_ref ret = default;
        void** call_args = stackalloc void*[2] { &arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, IntPtr.Zero, call_args, &ret);
        return InteropUtils.UnmanagedGetManaged(ret.Reference);
    }

    internal static unsafe void godot_icall_5_1299(IntPtr method, IntPtr ptr, string arg1, int arg2, int arg3, godot_bool arg4, godot_bool arg5)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        long arg2_in = arg2;
        long arg3_in = arg3;
        void** call_args = stackalloc void*[5] { &arg1_in, &arg2_in, &arg3_in, &arg4, &arg5 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe Vector2I godot_icall_3_1300(IntPtr method, IntPtr ptr, int arg1, int arg2, int arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Vector2I ret;
        long arg1_in = arg1;
        long arg2_in = arg2;
        long arg3_in = arg3;
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2_in, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Vector2I godot_icall_4_1301(IntPtr method, IntPtr ptr, string arg1, uint arg2, int arg3, int arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Vector2I ret;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        long arg2_in = arg2;
        long arg3_in = arg3;
        long arg4_in = arg4;
        void** call_args = stackalloc void*[4] { &arg1_in, &arg2_in, &arg3_in, &arg4_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Vector2I godot_icall_3_1302(IntPtr method, IntPtr ptr, Vector2I* arg1, godot_bool arg2, godot_bool arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Vector2I ret;
        void** call_args = stackalloc void*[3] { arg1, &arg2, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Vector2I godot_icall_2_1303(IntPtr method, IntPtr ptr, int arg1, int arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Vector2I ret;
        long arg1_in = arg1;
        long arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Rect2I godot_icall_2_1304(IntPtr method, IntPtr ptr, int arg1, int arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Rect2I ret;
        long arg1_in = arg1;
        long arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe godot_bool godot_icall_2_1305(IntPtr method, IntPtr ptr, godot_bool arg1, int arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_bool ret;
        long arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe int[] godot_icall_1_1306(IntPtr method, IntPtr ptr, godot_bool arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_int32_array ret = default;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertNativePackedInt32ArrayToSystemArray(ret);
    }

    internal static unsafe void godot_icall_5_1307(IntPtr method, IntPtr ptr, int arg1, int arg2, int arg3, int arg4, godot_bool arg5)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        long arg2_in = arg2;
        long arg3_in = arg3;
        long arg4_in = arg4;
        void** call_args = stackalloc void*[5] { &arg1_in, &arg2_in, &arg3_in, &arg4_in, &arg5 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_5_1308(IntPtr method, IntPtr ptr, int arg1, godot_bool arg2, godot_bool arg3, int arg4, int arg5)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        long arg4_in = arg4;
        long arg5_in = arg5;
        void** call_args = stackalloc void*[5] { &arg1_in, &arg2, &arg3, &arg4_in, &arg5_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_5_1309(IntPtr method, IntPtr ptr, int arg1, int arg2, int arg3, int arg4, int arg5)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        long arg2_in = arg2;
        long arg3_in = arg3;
        long arg4_in = arg4;
        long arg5_in = arg5;
        void** call_args = stackalloc void*[5] { &arg1_in, &arg2_in, &arg3_in, &arg4_in, &arg5_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe int godot_icall_4_1310(IntPtr method, IntPtr ptr, int arg1, int arg2, godot_bool arg3, godot_bool arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        long arg1_in = arg1;
        long arg2_in = arg2;
        void** call_args = stackalloc void*[4] { &arg1_in, &arg2_in, &arg3, &arg4 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe Godot.Collections.Array godot_icall_2_1311(IntPtr method, IntPtr ptr, godot_bool arg1, godot_bool arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_array ret = default;
        void** call_args = stackalloc void*[2] { &arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Godot.Collections.Array.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe void godot_icall_4_1312(IntPtr method, IntPtr ptr, int arg1, godot_bool arg2, int arg3, int arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        long arg3_in = arg3;
        long arg4_in = arg4;
        void** call_args = stackalloc void*[4] { &arg1_in, &arg2, &arg3_in, &arg4_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_3_1313(IntPtr method, IntPtr ptr, int arg1, int arg2, string arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        long arg2_in = arg2;
        using godot_string arg3_in = Marshaling.ConvertStringToNative(arg3);
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2_in, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe Vector2I godot_icall_2_1314(IntPtr method, IntPtr ptr, Vector2I* arg1, godot_bool arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Vector2I ret;
        void** call_args = stackalloc void*[2] { arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe godot_bool godot_icall_5_1315(IntPtr method, IntPtr ptr, string arg1, IntPtr arg2, int arg3, string arg4, Variant arg5)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_bool ret;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        long arg3_in = arg3;
        using godot_string arg4_in = Marshaling.ConvertStringToNative(arg4);
        godot_variant arg5_in = (godot_variant)arg5.NativeVar;
        void** call_args = stackalloc void*[5] { &arg1_in, &arg2, &arg3_in, &arg4_in, &arg5_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe godot_bool godot_icall_5_1316(IntPtr method, IntPtr ptr, Variant arg1, Vector2* arg2, int arg3, int arg4, float arg5)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_bool ret;
        godot_variant arg1_in = (godot_variant)arg1.NativeVar;
        long arg3_in = arg3;
        long arg4_in = arg4;
        double arg5_in = arg5;
        void** call_args = stackalloc void*[5] { &arg1_in, arg2, &arg3_in, &arg4_in, &arg5_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe godot_bool godot_icall_4_1317(IntPtr method, IntPtr ptr, Variant arg1, Vector2* arg2, int arg3, float arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_bool ret;
        godot_variant arg1_in = (godot_variant)arg1.NativeVar;
        long arg3_in = arg3;
        double arg4_in = arg4;
        void** call_args = stackalloc void*[4] { &arg1_in, arg2, &arg3_in, &arg4_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe godot_bool godot_icall_1_1318(IntPtr method, IntPtr ptr, Variant arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_bool ret;
        godot_variant arg1_in = (godot_variant)arg1.NativeVar;
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Rect2 godot_icall_1_1319(IntPtr method, IntPtr ptr, Variant arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Rect2 ret;
        godot_variant arg1_in = (godot_variant)arg1.NativeVar;
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe void godot_icall_4_1320(IntPtr method, IntPtr ptr, Rid arg1, Vector2* arg2, Color* arg3, float arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double arg4_in = arg4;
        void** call_args = stackalloc void*[4] { &arg1, arg2, arg3, &arg4_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_5_1321(IntPtr method, IntPtr ptr, Rid arg1, Vector2* arg2, int arg3, Color* arg4, float arg5)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg3_in = arg3;
        double arg5_in = arg5;
        void** call_args = stackalloc void*[5] { &arg1, arg2, &arg3_in, arg4, &arg5_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe int godot_icall_1_1322(IntPtr method, IntPtr ptr, float arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        double arg1_in = arg1;
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe void godot_icall_4_1323(IntPtr method, IntPtr ptr, Rid arg1, Vector2* arg2, int arg3, Color* arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg3_in = arg3;
        void** call_args = stackalloc void*[4] { &arg1, arg2, &arg3_in, arg4 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_3_1324(IntPtr method, IntPtr ptr, Rid arg1, Vector2* arg2, Color* arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[3] { &arg1, arg2, arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe godot_bool godot_icall_5_1325(IntPtr method, IntPtr ptr, string arg1, IntPtr arg2, int arg3, Rect2* arg4, string arg5)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_bool ret;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        long arg3_in = arg3;
        using godot_string arg5_in = Marshaling.ConvertStringToNative(arg5);
        void** call_args = stackalloc void*[5] { &arg1_in, &arg2, &arg3_in, arg4, &arg5_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Rect2 godot_icall_2_1326(IntPtr method, IntPtr ptr, int arg1, Variant arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Rect2 ret;
        long arg1_in = arg1;
        godot_variant arg2_in = (godot_variant)arg2.NativeVar;
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe void godot_icall_5_1327(IntPtr method, IntPtr ptr, Rid arg1, Vector2* arg2, Color* arg3, Color* arg4, float arg5)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double arg5_in = arg5;
        void** call_args = stackalloc void*[5] { &arg1, arg2, arg3, arg4, &arg5_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_6_1328(IntPtr method, IntPtr ptr, Rid arg1, Vector2* arg2, int arg3, Color* arg4, Color* arg5, float arg6)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg3_in = arg3;
        double arg6_in = arg6;
        void** call_args = stackalloc void*[6] { &arg1, arg2, &arg3_in, arg4, arg5, &arg6_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_6_1329(IntPtr method, IntPtr ptr, Rid arg1, Vector2* arg2, int arg3, int arg4, Color* arg5, float arg6)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg3_in = arg3;
        long arg4_in = arg4;
        double arg6_in = arg6;
        void** call_args = stackalloc void*[6] { &arg1, arg2, &arg3_in, &arg4_in, arg5, &arg6_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_5_1330(IntPtr method, IntPtr ptr, Rid arg1, Vector2* arg2, int arg3, int arg4, Color* arg5)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg3_in = arg3;
        long arg4_in = arg4;
        void** call_args = stackalloc void*[5] { &arg1, arg2, &arg3_in, &arg4_in, arg5 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_5_1331(IntPtr method, IntPtr ptr, Rid arg1, Vector2* arg2, int arg3, Color* arg4, Color* arg5)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg3_in = arg3;
        void** call_args = stackalloc void*[5] { &arg1, arg2, &arg3_in, arg4, arg5 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_4_1332(IntPtr method, IntPtr ptr, Rid arg1, Vector2* arg2, Color* arg3, Color* arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[4] { &arg1, arg2, arg3, arg4 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_2_1333(IntPtr method, IntPtr ptr, Rid arg1, ReadOnlySpan<byte> arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_byte_array arg2_in = Marshaling.ConvertSystemArrayToNativePackedByteArray(arg2);
        void** call_args = stackalloc void*[2] { &arg1, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_2_1334(IntPtr method, IntPtr ptr, Rid arg1, long arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[2] { &arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe Godot.Collections.Dictionary godot_icall_1_1335(IntPtr method, IntPtr ptr, Rid arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_dictionary ret = default;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Godot.Collections.Dictionary.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe void godot_icall_3_1336(IntPtr method, IntPtr ptr, Rid arg1, int arg2, long arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg2_in = arg2;
        void** call_args = stackalloc void*[3] { &arg1, &arg2_in, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe long godot_icall_2_1337(IntPtr method, IntPtr ptr, Rid arg1, int arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        long arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe void godot_icall_3_1338(IntPtr method, IntPtr ptr, Rid arg1, long arg2, double arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[3] { &arg1, &arg2, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe double godot_icall_2_1339(IntPtr method, IntPtr ptr, Rid arg1, long arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double ret;
        void** call_args = stackalloc void*[2] { &arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe long godot_icall_2_1340(IntPtr method, IntPtr ptr, Rid arg1, Vector2I* arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        void** call_args = stackalloc void*[2] { &arg1, arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe void godot_icall_3_1341(IntPtr method, IntPtr ptr, Rid arg1, Vector2I* arg2, long arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[3] { &arg1, arg2, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_4_1342(IntPtr method, IntPtr ptr, Rid arg1, Vector2I* arg2, long arg3, IntPtr arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[4] { &arg1, arg2, &arg3, &arg4 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe GodotObject godot_icall_3_1343(IntPtr method, IntPtr ptr, Rid arg1, Vector2I* arg2, long arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_ref ret = default;
        void** call_args = stackalloc void*[3] { &arg1, arg2, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return InteropUtils.UnmanagedGetManaged(ret.Reference);
    }

    internal static unsafe void godot_icall_4_1344(IntPtr method, IntPtr ptr, Rid arg1, Vector2I* arg2, long arg3, ReadOnlySpan<int> arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_int32_array arg4_in = Marshaling.ConvertSystemArrayToNativePackedInt32Array(arg4);
        void** call_args = stackalloc void*[4] { &arg1, arg2, &arg3, &arg4_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe int[] godot_icall_3_1345(IntPtr method, IntPtr ptr, Rid arg1, Vector2I* arg2, long arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_int32_array ret = default;
        void** call_args = stackalloc void*[3] { &arg1, arg2, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertNativePackedInt32ArrayToSystemArray(ret);
    }

    internal static unsafe int[] godot_icall_2_1346(IntPtr method, IntPtr ptr, Rid arg1, Vector2I* arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_int32_array ret = default;
        void** call_args = stackalloc void*[2] { &arg1, arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertNativePackedInt32ArrayToSystemArray(ret);
    }

    internal static unsafe Vector2 godot_icall_3_1347(IntPtr method, IntPtr ptr, Rid arg1, long arg2, long arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Vector2 ret;
        void** call_args = stackalloc void*[3] { &arg1, &arg2, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe void godot_icall_4_1348(IntPtr method, IntPtr ptr, Rid arg1, long arg2, long arg3, Vector2* arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[4] { &arg1, &arg2, &arg3, arg4 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe Vector2 godot_icall_3_1349(IntPtr method, IntPtr ptr, Rid arg1, Vector2I* arg2, long arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Vector2 ret;
        void** call_args = stackalloc void*[3] { &arg1, arg2, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe void godot_icall_4_1350(IntPtr method, IntPtr ptr, Rid arg1, Vector2I* arg2, long arg3, Vector2* arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[4] { &arg1, arg2, &arg3, arg4 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe Rect2 godot_icall_3_1351(IntPtr method, IntPtr ptr, Rid arg1, Vector2I* arg2, long arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Rect2 ret;
        void** call_args = stackalloc void*[3] { &arg1, arg2, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe void godot_icall_4_1352(IntPtr method, IntPtr ptr, Rid arg1, Vector2I* arg2, long arg3, Rect2* arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[4] { &arg1, arg2, &arg3, arg4 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe long godot_icall_3_1353(IntPtr method, IntPtr ptr, Rid arg1, Vector2I* arg2, long arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        void** call_args = stackalloc void*[3] { &arg1, arg2, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe void godot_icall_4_1354(IntPtr method, IntPtr ptr, Rid arg1, Vector2I* arg2, long arg3, long arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[4] { &arg1, arg2, &arg3, &arg4 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe Rid godot_icall_3_1355(IntPtr method, IntPtr ptr, Rid arg1, Vector2I* arg2, long arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Rid ret;
        void** call_args = stackalloc void*[3] { &arg1, arg2, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Godot.Collections.Dictionary godot_icall_3_1356(IntPtr method, IntPtr ptr, Rid arg1, long arg2, long arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_dictionary ret = default;
        void** call_args = stackalloc void*[3] { &arg1, &arg2, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Godot.Collections.Dictionary.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe Godot.Collections.Array godot_icall_2_1357(IntPtr method, IntPtr ptr, Rid arg1, long arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_array ret = default;
        void** call_args = stackalloc void*[2] { &arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Godot.Collections.Array.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe void godot_icall_3_1358(IntPtr method, IntPtr ptr, Rid arg1, long arg2, Vector2I* arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[3] { &arg1, &arg2, arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_4_1359(IntPtr method, IntPtr ptr, Rid arg1, long arg2, Vector2I* arg3, Vector2* arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[4] { &arg1, &arg2, arg3, arg4 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe Vector2 godot_icall_3_1360(IntPtr method, IntPtr ptr, Rid arg1, long arg2, Vector2I* arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Vector2 ret;
        void** call_args = stackalloc void*[3] { &arg1, &arg2, arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe long godot_icall_4_1361(IntPtr method, IntPtr ptr, Rid arg1, long arg2, long arg3, long arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        void** call_args = stackalloc void*[4] { &arg1, &arg2, &arg3, &arg4 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe long godot_icall_3_1362(IntPtr method, IntPtr ptr, Rid arg1, long arg2, long arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        void** call_args = stackalloc void*[3] { &arg1, &arg2, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe godot_bool godot_icall_2_1363(IntPtr method, IntPtr ptr, Rid arg1, long arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_bool ret;
        void** call_args = stackalloc void*[2] { &arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe void godot_icall_7_1364(IntPtr method, IntPtr ptr, Rid arg1, Rid arg2, long arg3, Vector2* arg4, long arg5, Color* arg6, float arg7)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double arg7_in = arg7;
        void** call_args = stackalloc void*[7] { &arg1, &arg2, &arg3, arg4, &arg5, arg6, &arg7_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_8_1365(IntPtr method, IntPtr ptr, Rid arg1, Rid arg2, long arg3, long arg4, Vector2* arg5, long arg6, Color* arg7, float arg8)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double arg8_in = arg8;
        void** call_args = stackalloc void*[8] { &arg1, &arg2, &arg3, &arg4, arg5, &arg6, arg7, &arg8_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe godot_bool godot_icall_2_1366(IntPtr method, IntPtr ptr, Rid arg1, string arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_bool ret;
        using godot_string arg2_in = Marshaling.ConvertStringToNative(arg2);
        void** call_args = stackalloc void*[2] { &arg1, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe void godot_icall_3_1367(IntPtr method, IntPtr ptr, Rid arg1, string arg2, godot_bool arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string arg2_in = Marshaling.ConvertStringToNative(arg2);
        void** call_args = stackalloc void*[3] { &arg1, &arg2_in, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe Vector2 godot_icall_2_1368(IntPtr method, IntPtr ptr, long arg1, long arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Vector2 ret;
        void** call_args = stackalloc void*[2] { &arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe void godot_icall_5_1369(IntPtr method, IntPtr ptr, Rid arg1, long arg2, Vector2* arg3, long arg4, Color* arg5)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[5] { &arg1, &arg2, arg3, &arg4, arg5 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe godot_bool godot_icall_7_1370(IntPtr method, IntPtr ptr, Rid arg1, string arg2, godot_array arg3, long arg4, godot_dictionary arg5, string arg6, Variant arg7)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_bool ret;
        using godot_string arg2_in = Marshaling.ConvertStringToNative(arg2);
        using godot_string arg6_in = Marshaling.ConvertStringToNative(arg6);
        godot_variant arg7_in = (godot_variant)arg7.NativeVar;
        void** call_args = stackalloc void*[7] { &arg1, &arg2_in, &arg3, &arg4, &arg5, &arg6_in, &arg7_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe godot_bool godot_icall_6_1371(IntPtr method, IntPtr ptr, Rid arg1, Variant arg2, Vector2* arg3, int arg4, long arg5, double arg6)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_bool ret;
        godot_variant arg2_in = (godot_variant)arg2.NativeVar;
        long arg4_in = arg4;
        void** call_args = stackalloc void*[6] { &arg1, &arg2_in, arg3, &arg4_in, &arg5, &arg6 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe godot_bool godot_icall_5_1372(IntPtr method, IntPtr ptr, Rid arg1, Variant arg2, Vector2* arg3, int arg4, double arg5)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_bool ret;
        godot_variant arg2_in = (godot_variant)arg2.NativeVar;
        long arg4_in = arg4;
        void** call_args = stackalloc void*[5] { &arg1, &arg2_in, arg3, &arg4_in, &arg5 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe godot_bool godot_icall_2_1373(IntPtr method, IntPtr ptr, Rid arg1, Variant arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_bool ret;
        godot_variant arg2_in = (godot_variant)arg2.NativeVar;
        void** call_args = stackalloc void*[2] { &arg1, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe string godot_icall_2_1374(IntPtr method, IntPtr ptr, Rid arg1, long arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string ret = default;
        void** call_args = stackalloc void*[2] { &arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertStringToManaged(ret);
    }

    internal static unsafe void godot_icall_5_1375(IntPtr method, IntPtr ptr, Rid arg1, long arg2, godot_array arg3, long arg4, godot_dictionary arg5)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[5] { &arg1, &arg2, &arg3, &arg4, &arg5 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe Vector2I godot_icall_2_1376(IntPtr method, IntPtr ptr, Rid arg1, long arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Vector2I ret;
        void** call_args = stackalloc void*[2] { &arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Rid godot_icall_2_1377(IntPtr method, IntPtr ptr, Rid arg1, long arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Rid ret;
        void** call_args = stackalloc void*[2] { &arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe int godot_icall_2_1378(IntPtr method, IntPtr ptr, Rid arg1, long arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        void** call_args = stackalloc void*[2] { &arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe Rid godot_icall_3_1379(IntPtr method, IntPtr ptr, Rid arg1, long arg2, long arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Rid ret;
        void** call_args = stackalloc void*[3] { &arg1, &arg2, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe double godot_icall_3_1380(IntPtr method, IntPtr ptr, Rid arg1, double arg2, int arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double ret;
        long arg3_in = arg3;
        void** call_args = stackalloc void*[3] { &arg1, &arg2, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe double godot_icall_2_1381(IntPtr method, IntPtr ptr, Rid arg1, ReadOnlySpan<float> arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double ret;
        using godot_packed_float32_array arg2_in = Marshaling.ConvertSystemArrayToNativePackedFloat32Array(arg2);
        void** call_args = stackalloc void*[2] { &arg1, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Vector2I godot_icall_1_1382(IntPtr method, IntPtr ptr, Rid arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Vector2I ret;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe int[] godot_icall_5_1383(IntPtr method, IntPtr ptr, Rid arg1, ReadOnlySpan<float> arg2, long arg3, godot_bool arg4, int arg5)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_int32_array ret = default;
        using godot_packed_float32_array arg2_in = Marshaling.ConvertSystemArrayToNativePackedFloat32Array(arg2);
        long arg5_in = arg5;
        void** call_args = stackalloc void*[5] { &arg1, &arg2_in, &arg3, &arg4, &arg5_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertNativePackedInt32ArrayToSystemArray(ret);
    }

    internal static unsafe int[] godot_icall_4_1384(IntPtr method, IntPtr ptr, Rid arg1, double arg2, long arg3, int arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_int32_array ret = default;
        long arg4_in = arg4;
        void** call_args = stackalloc void*[4] { &arg1, &arg2, &arg3, &arg4_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertNativePackedInt32ArrayToSystemArray(ret);
    }

    internal static unsafe int[] godot_icall_3_1385(IntPtr method, IntPtr ptr, Rid arg1, int arg2, int arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_int32_array ret = default;
        long arg2_in = arg2;
        long arg3_in = arg3;
        void** call_args = stackalloc void*[3] { &arg1, &arg2_in, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertNativePackedInt32ArrayToSystemArray(ret);
    }

    internal static unsafe void godot_icall_3_1386(IntPtr method, IntPtr ptr, Rid arg1, double arg2, int arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg3_in = arg3;
        void** call_args = stackalloc void*[3] { &arg1, &arg2, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe Rect2 godot_icall_2_1387(IntPtr method, IntPtr ptr, Rid arg1, Variant arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Rect2 ret;
        godot_variant arg2_in = (godot_variant)arg2.NativeVar;
        void** call_args = stackalloc void*[2] { &arg1, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Vector2I godot_icall_2_1388(IntPtr method, IntPtr ptr, Rid arg1, Variant arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Vector2I ret;
        godot_variant arg2_in = (godot_variant)arg2.NativeVar;
        void** call_args = stackalloc void*[2] { &arg1, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe long godot_icall_2_1389(IntPtr method, IntPtr ptr, Rid arg1, Variant arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        godot_variant arg2_in = (godot_variant)arg2.NativeVar;
        void** call_args = stackalloc void*[2] { &arg1, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Godot.Collections.Dictionary godot_icall_2_1390(IntPtr method, IntPtr ptr, Rid arg1, long arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_dictionary ret = default;
        void** call_args = stackalloc void*[2] { &arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Godot.Collections.Dictionary.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe Vector2[] godot_icall_3_1391(IntPtr method, IntPtr ptr, Rid arg1, long arg2, long arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_vector2_array ret = default;
        void** call_args = stackalloc void*[3] { &arg1, &arg2, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertNativePackedVector2ArrayToSystemArray(ret);
    }

    internal static unsafe long godot_icall_2_1392(IntPtr method, IntPtr ptr, Rid arg1, double arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        void** call_args = stackalloc void*[2] { &arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Vector2 godot_icall_2_1393(IntPtr method, IntPtr ptr, Rid arg1, long arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Vector2 ret;
        void** call_args = stackalloc void*[2] { &arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe long godot_icall_2_1394(IntPtr method, IntPtr ptr, Rid arg1, long arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        void** call_args = stackalloc void*[2] { &arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe void godot_icall_7_1395(IntPtr method, IntPtr ptr, Rid arg1, Rid arg2, Vector2* arg3, double arg4, double arg5, Color* arg6, float arg7)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double arg7_in = arg7;
        void** call_args = stackalloc void*[7] { &arg1, &arg2, arg3, &arg4, &arg5, arg6, &arg7_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_8_1396(IntPtr method, IntPtr ptr, Rid arg1, Rid arg2, Vector2* arg3, double arg4, double arg5, long arg6, Color* arg7, float arg8)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double arg8_in = arg8;
        void** call_args = stackalloc void*[8] { &arg1, &arg2, arg3, &arg4, &arg5, &arg6, arg7, &arg8_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe int godot_icall_3_1397(IntPtr method, IntPtr ptr, Rid arg1, long arg2, long arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        void** call_args = stackalloc void*[3] { &arg1, &arg2, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe string godot_icall_2_1398(IntPtr method, IntPtr ptr, string arg1, string arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string ret = default;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        using godot_string arg2_in = Marshaling.ConvertStringToNative(arg2);
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertStringToManaged(ret);
    }

    internal static unsafe int[] godot_icall_3_1399(IntPtr method, IntPtr ptr, string arg1, string arg2, long arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_int32_array ret = default;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        using godot_string arg2_in = Marshaling.ConvertStringToNative(arg2);
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2_in, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertNativePackedInt32ArrayToSystemArray(ret);
    }

    internal static unsafe int[] godot_icall_2_1400(IntPtr method, IntPtr ptr, string arg1, string arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_int32_array ret = default;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        using godot_string arg2_in = Marshaling.ConvertStringToNative(arg2);
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertNativePackedInt32ArrayToSystemArray(ret);
    }

    internal static unsafe long godot_icall_2_1401(IntPtr method, IntPtr ptr, string arg1, ReadOnlySpan<string> arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        using godot_packed_string_array arg2_in = Marshaling.ConvertSystemArrayToNativePackedStringArray(arg2);
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Godot.Collections.Array godot_icall_3_1402(IntPtr method, IntPtr ptr, int arg1, godot_array arg2, string arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_array ret = default;
        long arg1_in = arg1;
        using godot_string arg3_in = Marshaling.ConvertStringToNative(arg3);
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Godot.Collections.Array.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe int[] godot_icall_2_1403(IntPtr method, IntPtr ptr, Rid arg1, int arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_int32_array ret = default;
        long arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertNativePackedInt32ArrayToSystemArray(ret);
    }

    internal static unsafe void godot_icall_7_1404(IntPtr method, IntPtr ptr, Rid arg1, Rid arg2, Vector2* arg3, double arg4, double arg5, long arg6, Color* arg7)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[7] { &arg1, &arg2, arg3, &arg4, &arg5, &arg6, arg7 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_6_1405(IntPtr method, IntPtr ptr, Rid arg1, Rid arg2, Vector2* arg3, double arg4, double arg5, Color* arg6)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[6] { &arg1, &arg2, arg3, &arg4, &arg5, arg6 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_7_1406(IntPtr method, IntPtr ptr, Rid arg1, Rid arg2, long arg3, long arg4, Vector2* arg5, long arg6, Color* arg7)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[7] { &arg1, &arg2, &arg3, &arg4, arg5, &arg6, arg7 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_6_1407(IntPtr method, IntPtr ptr, Rid arg1, Rid arg2, long arg3, Vector2* arg4, long arg5, Color* arg6)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[6] { &arg1, &arg2, &arg3, arg4, &arg5, arg6 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_4_1408(IntPtr method, IntPtr ptr, Rid arg1, Vector2* arg2, Color* arg3, godot_bool arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[4] { &arg1, arg2, arg3, &arg4 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_5_1409(IntPtr method, IntPtr ptr, Rid arg1, Rect2* arg2, godot_bool arg3, Color* arg4, godot_bool arg5)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[5] { &arg1, arg2, &arg3, arg4, &arg5 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_6_1410(IntPtr method, IntPtr ptr, Rid arg1, Rect2* arg2, Rect2* arg3, Color* arg4, godot_bool arg5, godot_bool arg6)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[6] { &arg1, arg2, arg3, arg4, &arg5, &arg6 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_3_1411(IntPtr method, IntPtr ptr, godot_string_name arg1, godot_string_name arg2, godot_string_name arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[3] { &arg1, &arg2, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_3_1412(IntPtr method, IntPtr ptr, godot_string_name arg1, godot_string_name arg2, int arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg3_in = arg3;
        void** call_args = stackalloc void*[3] { &arg1, &arg2, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_3_1413(IntPtr method, IntPtr ptr, godot_string_name arg1, godot_string_name arg2, Color* arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[3] { &arg1, &arg2, arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_4_1414(IntPtr method, IntPtr ptr, int arg1, godot_string_name arg2, godot_string_name arg3, Variant arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        godot_variant arg4_in = (godot_variant)arg4.NativeVar;
        void** call_args = stackalloc void*[4] { &arg1_in, &arg2, &arg3, &arg4_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe Variant godot_icall_3_1415(IntPtr method, IntPtr ptr, int arg1, godot_string_name arg2, godot_string_name arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_variant ret = default;
        long arg1_in = arg1;
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Variant.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe godot_bool godot_icall_3_1416(IntPtr method, IntPtr ptr, int arg1, godot_string_name arg2, godot_string_name arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_bool ret;
        long arg1_in = arg1;
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe void godot_icall_4_1417(IntPtr method, IntPtr ptr, int arg1, godot_string_name arg2, godot_string_name arg3, godot_string_name arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        void** call_args = stackalloc void*[4] { &arg1_in, &arg2, &arg3, &arg4 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_3_1418(IntPtr method, IntPtr ptr, int arg1, godot_string_name arg2, godot_string_name arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe string[] godot_icall_2_1419(IntPtr method, IntPtr ptr, int arg1, string arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_string_array ret = default;
        long arg1_in = arg1;
        using godot_string arg2_in = Marshaling.ConvertStringToNative(arg2);
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertNativePackedStringArrayToSystemArray(ret);
    }

    internal static unsafe int godot_icall_2_1420(IntPtr method, IntPtr ptr, in Callable arg1, int arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        using godot_callable arg1_in = Marshaling.ConvertCallableToNative(in arg1);
        long arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe GodotObject godot_icall_4_1421(IntPtr method, IntPtr ptr, int arg1, godot_bool arg2, godot_bool arg3, godot_bool arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_ref ret = default;
        long arg1_in = arg1;
        void** call_args = stackalloc void*[4] { &arg1_in, &arg2, &arg3, &arg4 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return InteropUtils.UnmanagedGetManaged(ret.Reference);
    }

    internal static unsafe void godot_icall_3_1422(IntPtr method, IntPtr ptr, int arg1, int arg2, ReadOnlySpan<Vector2> arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        long arg2_in = arg2;
        using godot_packed_vector2_array arg3_in = Marshaling.ConvertSystemArrayToNativePackedVector2Array(arg3);
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2_in, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe Vector2[] godot_icall_2_1423(IntPtr method, IntPtr ptr, int arg1, int arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_vector2_array ret = default;
        long arg1_in = arg1;
        long arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertNativePackedVector2ArrayToSystemArray(ret);
    }

    internal static unsafe void godot_icall_5_1424(IntPtr method, IntPtr ptr, int arg1, Vector2I* arg2, int arg3, Vector2I* arg4, int arg5)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        long arg3_in = arg3;
        long arg5_in = arg5;
        void** call_args = stackalloc void*[5] { &arg1_in, arg2, &arg3_in, arg4, &arg5_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe int godot_icall_3_1425(IntPtr method, IntPtr ptr, int arg1, Vector2I* arg2, godot_bool arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        long arg1_in = arg1;
        void** call_args = stackalloc void*[3] { &arg1_in, arg2, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe Vector2I godot_icall_3_1426(IntPtr method, IntPtr ptr, int arg1, Vector2I* arg2, godot_bool arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Vector2I ret;
        long arg1_in = arg1;
        void** call_args = stackalloc void*[3] { &arg1_in, arg2, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe GodotObject godot_icall_3_1427(IntPtr method, IntPtr ptr, int arg1, Vector2I* arg2, godot_bool arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        IntPtr ret = default;
        long arg1_in = arg1;
        void** call_args = stackalloc void*[3] { &arg1_in, arg2, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return InteropUtils.UnmanagedGetManaged(ret);
    }

    internal static unsafe godot_bool godot_icall_3_1428(IntPtr method, IntPtr ptr, int arg1, Vector2I* arg2, godot_bool arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_bool ret;
        long arg1_in = arg1;
        void** call_args = stackalloc void*[3] { &arg1_in, arg2, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe GodotObject godot_icall_2_1429(IntPtr method, IntPtr ptr, int arg1, godot_array arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_ref ret = default;
        long arg1_in = arg1;
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return InteropUtils.UnmanagedGetManaged(ret.Reference);
    }

    internal static unsafe Vector2I godot_icall_3_1430(IntPtr method, IntPtr ptr, Vector2I* arg1, Vector2I* arg2, IntPtr arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Vector2I ret;
        void** call_args = stackalloc void*[3] { arg1, arg2, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe void godot_icall_3_1431(IntPtr method, IntPtr ptr, int arg1, Vector2I* arg2, IntPtr arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        void** call_args = stackalloc void*[3] { &arg1_in, arg2, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_5_1432(IntPtr method, IntPtr ptr, int arg1, godot_array arg2, int arg3, int arg4, godot_bool arg5)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        long arg3_in = arg3;
        long arg4_in = arg4;
        void** call_args = stackalloc void*[5] { &arg1_in, &arg2, &arg3_in, &arg4_in, &arg5 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe Godot.Collections.Array godot_icall_1_1433(IntPtr method, IntPtr ptr, Vector2I* arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_array ret = default;
        void** call_args = stackalloc void*[1] { arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Godot.Collections.Array.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe Godot.Collections.Array godot_icall_4_1434(IntPtr method, IntPtr ptr, int arg1, int arg2, Vector2I* arg3, int arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_array ret = default;
        long arg1_in = arg1;
        long arg2_in = arg2;
        long arg4_in = arg4;
        void** call_args = stackalloc void*[4] { &arg1_in, &arg2_in, arg3, &arg4_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Godot.Collections.Array.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe Vector2I godot_icall_1_1435(IntPtr method, IntPtr ptr, Vector2* arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Vector2I ret;
        void** call_args = stackalloc void*[1] { arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Vector2I godot_icall_2_1436(IntPtr method, IntPtr ptr, Vector2I* arg1, int arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Vector2I ret;
        long arg2_in = arg2;
        void** call_args = stackalloc void*[2] { arg1, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe void godot_icall_4_1437(IntPtr method, IntPtr ptr, Vector2I* arg1, int arg2, Vector2I* arg3, int arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg2_in = arg2;
        long arg4_in = arg4;
        void** call_args = stackalloc void*[4] { arg1, &arg2_in, arg3, &arg4_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe Vector2I godot_icall_1_1438(IntPtr method, IntPtr ptr, Vector2I* arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Vector2I ret;
        void** call_args = stackalloc void*[1] { arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe GodotObject godot_icall_1_1439(IntPtr method, IntPtr ptr, Vector2I* arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        IntPtr ret = default;
        void** call_args = stackalloc void*[1] { arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return InteropUtils.UnmanagedGetManaged(ret);
    }

    internal static unsafe Godot.Collections.Array godot_icall_3_1440(IntPtr method, IntPtr ptr, int arg1, Vector2I* arg2, int arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_array ret = default;
        long arg1_in = arg1;
        long arg3_in = arg3;
        void** call_args = stackalloc void*[3] { &arg1_in, arg2, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Godot.Collections.Array.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe GodotObject godot_icall_1_1441(IntPtr method, IntPtr ptr, godot_array arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_ref ret = default;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return InteropUtils.UnmanagedGetManaged(ret.Reference);
    }

    internal static unsafe void godot_icall_2_1442(IntPtr method, IntPtr ptr, Vector2I* arg1, IntPtr arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[2] { arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_4_1443(IntPtr method, IntPtr ptr, godot_array arg1, int arg2, int arg3, godot_bool arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg2_in = arg2;
        long arg3_in = arg3;
        void** call_args = stackalloc void*[4] { &arg1, &arg2_in, &arg3_in, &arg4 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_4_1444(IntPtr method, IntPtr ptr, int arg1, Vector2I* arg2, int arg3, Vector2I* arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        long arg3_in = arg3;
        void** call_args = stackalloc void*[4] { &arg1_in, arg2, &arg3_in, arg4 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe Godot.Collections.Array godot_icall_2_1445(IntPtr method, IntPtr ptr, int arg1, Vector2I* arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_array ret = default;
        long arg1_in = arg1;
        void** call_args = stackalloc void*[2] { &arg1_in, arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Godot.Collections.Array.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe godot_bool godot_icall_2_1446(IntPtr method, IntPtr ptr, int arg1, Vector2I* arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_bool ret;
        long arg1_in = arg1;
        void** call_args = stackalloc void*[2] { &arg1_in, arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe void godot_icall_6_1447(IntPtr method, IntPtr ptr, int arg1, Vector2I* arg2, int arg3, int arg4, Vector2I* arg5, int arg6)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        long arg3_in = arg3;
        long arg4_in = arg4;
        long arg6_in = arg6;
        void** call_args = stackalloc void*[6] { &arg1_in, arg2, &arg3_in, &arg4_in, arg5, &arg6_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe godot_bool godot_icall_3_1448(IntPtr method, IntPtr ptr, int arg1, Vector2I* arg2, int arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_bool ret;
        long arg1_in = arg1;
        long arg3_in = arg3;
        void** call_args = stackalloc void*[3] { &arg1_in, arg2, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe void godot_icall_2_1449(IntPtr method, IntPtr ptr, Vector2I* arg1, Vector2I* arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[2] { arg1, arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_3_1450(IntPtr method, IntPtr ptr, Vector2I* arg1, Vector2I* arg2, Vector2I* arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[3] { arg1, arg2, arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe godot_bool godot_icall_6_1451(IntPtr method, IntPtr ptr, Vector2I* arg1, Vector2I* arg2, int arg3, Vector2I* arg4, int arg5, Vector2I* arg6)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_bool ret;
        long arg3_in = arg3;
        long arg5_in = arg5;
        void** call_args = stackalloc void*[6] { arg1, arg2, &arg3_in, arg4, &arg5_in, arg6 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Vector2[] godot_icall_4_1452(IntPtr method, IntPtr ptr, IntPtr arg1, Vector2I* arg2, Vector2I* arg3, Vector2I* arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_vector2_array ret = default;
        void** call_args = stackalloc void*[4] { &arg1, arg2, arg3, arg4 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertNativePackedVector2ArrayToSystemArray(ret);
    }

    internal static unsafe void godot_icall_3_1453(IntPtr method, IntPtr ptr, Vector2I* arg1, int arg2, float arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg2_in = arg2;
        double arg3_in = arg3;
        void** call_args = stackalloc void*[3] { arg1, &arg2_in, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe float godot_icall_2_1454(IntPtr method, IntPtr ptr, Vector2I* arg1, int arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        double ret;
        long arg2_in = arg2;
        void** call_args = stackalloc void*[2] { arg1, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (float)ret;
    }

    internal static unsafe int godot_icall_2_1455(IntPtr method, IntPtr ptr, Vector2I* arg1, int arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        long arg2_in = arg2;
        void** call_args = stackalloc void*[2] { arg1, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe void godot_icall_3_1456(IntPtr method, IntPtr ptr, Vector2I* arg1, int arg2, int arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg2_in = arg2;
        long arg3_in = arg3;
        void** call_args = stackalloc void*[3] { arg1, &arg2_in, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe GodotObject godot_icall_2_1457(IntPtr method, IntPtr ptr, Vector2I* arg1, int arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        IntPtr ret = default;
        long arg2_in = arg2;
        void** call_args = stackalloc void*[2] { arg1, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return InteropUtils.UnmanagedGetManaged(ret);
    }

    internal static unsafe Rect2I godot_icall_2_1458(IntPtr method, IntPtr ptr, Vector2I* arg1, int arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Rect2I ret;
        long arg2_in = arg2;
        void** call_args = stackalloc void*[2] { arg1, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe godot_bool godot_icall_2_1459(IntPtr method, IntPtr ptr, Vector2I* arg1, int arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_bool ret;
        long arg2_in = arg2;
        void** call_args = stackalloc void*[2] { arg1, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Godot.Collections.Dictionary godot_icall_1_1460(IntPtr method, IntPtr ptr, long arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_dictionary ret = default;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Godot.Collections.Dictionary.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe string godot_icall_2_1461(IntPtr method, IntPtr ptr, long arg1, godot_bool arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string ret = default;
        void** call_args = stackalloc void*[2] { &arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertStringToManaged(ret);
    }

    internal static unsafe Godot.Collections.Dictionary godot_icall_2_1462(IntPtr method, IntPtr ptr, string arg1, godot_bool arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_dictionary ret = default;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Godot.Collections.Dictionary.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe string godot_icall_2_1463(IntPtr method, IntPtr ptr, godot_dictionary arg1, godot_bool arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string ret = default;
        void** call_args = stackalloc void*[2] { &arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertStringToManaged(ret);
    }

    internal static unsafe long godot_icall_1_1464(IntPtr method, IntPtr ptr, godot_dictionary arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe string godot_icall_2_1465(IntPtr method, IntPtr ptr, godot_bool arg1, godot_bool arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string ret = default;
        void** call_args = stackalloc void*[2] { &arg1, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertStringToManaged(ret);
    }

    internal static unsafe void godot_icall_3_1466(IntPtr method, IntPtr ptr, godot_string_name arg1, ReadOnlySpan<string> arg2, godot_string_name arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_string_array arg2_in = Marshaling.ConvertSystemArrayToNativePackedStringArray(arg2);
        void** call_args = stackalloc void*[3] { &arg1, &arg2_in, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe StringName godot_icall_4_1467(IntPtr method, IntPtr ptr, godot_string_name arg1, godot_string_name arg2, int arg3, godot_string_name arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_string_name ret = default;
        long arg3_in = arg3;
        void** call_args = stackalloc void*[4] { &arg1, &arg2, &arg3_in, &arg4 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return StringName.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe godot_bool godot_icall_2_1468(IntPtr method, IntPtr ptr, string arg1, godot_bool arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_bool ret;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Godot.Collections.Array godot_icall_2_1469(IntPtr method, IntPtr ptr, string arg1, godot_bool arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_array ret = default;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Godot.Collections.Array.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe string godot_icall_2_1470(IntPtr method, IntPtr ptr, string arg1, godot_bool arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string ret = default;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertStringToManaged(ret);
    }

    internal static unsafe GodotObject godot_icall_2_1471(IntPtr method, IntPtr ptr, IntPtr arg1, int arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        IntPtr ret = default;
        long arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return InteropUtils.UnmanagedGetManaged(ret);
    }

    internal static unsafe GodotObject godot_icall_1_1472(IntPtr method, IntPtr ptr, IntPtr arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        IntPtr ret = default;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return InteropUtils.UnmanagedGetManaged(ret);
    }

    internal static unsafe Rect2 godot_icall_3_1473(IntPtr method, IntPtr ptr, IntPtr arg1, int arg2, int arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Rect2 ret;
        long arg2_in = arg2;
        long arg3_in = arg3;
        void** call_args = stackalloc void*[3] { &arg1, &arg2_in, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe GodotObject godot_icall_1_1474(IntPtr method, IntPtr ptr, Vector2* arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        IntPtr ret = default;
        void** call_args = stackalloc void*[1] { arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return InteropUtils.UnmanagedGetManaged(ret);
    }

    internal static unsafe void godot_icall_5_1475(IntPtr method, IntPtr ptr, int arg1, double arg2, double arg3, double arg4, godot_bool arg5)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        void** call_args = stackalloc void*[5] { &arg1_in, &arg2, &arg3, &arg4, &arg5 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_3_1476(IntPtr method, IntPtr ptr, int arg1, IntPtr arg2, godot_string_name arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe Callable godot_icall_1_1477(IntPtr method, IntPtr ptr, int arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_callable ret = default;
        long arg1_in = arg1;
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertCallableToManaged(in ret);
    }

    internal static unsafe void godot_icall_3_1478(IntPtr method, IntPtr ptr, int arg1, Color* arg2, godot_bool arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        void** call_args = stackalloc void*[3] { &arg1_in, arg2, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_6_1479(IntPtr method, IntPtr ptr, int arg1, IntPtr arg2, int arg3, godot_bool arg4, string arg5, string arg6)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        long arg3_in = arg3;
        using godot_string arg5_in = Marshaling.ConvertStringToNative(arg5);
        using godot_string arg6_in = Marshaling.ConvertStringToNative(arg6);
        void** call_args = stackalloc void*[6] { &arg1_in, &arg2, &arg3_in, &arg4, &arg5_in, &arg6_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_2_1480(IntPtr method, IntPtr ptr, godot_string_name arg1, ReadOnlySpan<Variant> arg2, godot_string_name caller)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        int vararg_length = arg2.Length;
        int total_length = 1 + vararg_length;
        Span<godot_variant.movable> varargs_span = vararg_length <= VarArgsSpanThreshold ?
            stackalloc godot_variant.movable[VarArgsSpanThreshold] :
            new godot_variant.movable[vararg_length];
        Span<IntPtr> call_args_span = total_length <= VarArgsSpanThreshold ?
            stackalloc IntPtr[VarArgsSpanThreshold] :
            new IntPtr[total_length];
        fixed (godot_variant.movable* varargs = &MemoryMarshal.GetReference(varargs_span))
        fixed (IntPtr* call_args = &MemoryMarshal.GetReference(call_args_span))
        {
            using godot_variant arg1_in = VariantUtils.CreateFromStringName(arg1);
            call_args[0] = new IntPtr(&arg1_in);
            for (int i = 0; i < vararg_length; i++)
            {
                varargs[i] = arg2[i].NativeVar;
                call_args[1 + i] = new IntPtr(&varargs[i]);
            }
            NativeFuncs.godotsharp_method_bind_call(method, ptr, (godot_variant**)call_args, total_length, out godot_variant_call_error vcall_error);
            ExceptionUtils.DebugCheckCallError(caller, ptr, (godot_variant**)call_args, total_length, vcall_error);
        }
    }

    internal static unsafe void godot_icall_5_1481(IntPtr method, IntPtr ptr, int arg1, IntPtr arg2, int arg3, godot_bool arg4, string arg5)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        long arg3_in = arg3;
        using godot_string arg5_in = Marshaling.ConvertStringToNative(arg5);
        void** call_args = stackalloc void*[5] { &arg1_in, &arg2, &arg3_in, &arg4, &arg5_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe godot_bool godot_icall_1_1482(IntPtr method, IntPtr ptr, ReadOnlySpan<Vector3> arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_bool ret;
        using godot_packed_vector3_array arg1_in = Marshaling.ConvertSystemArrayToNativePackedVector3Array(arg1);
        void** call_args = stackalloc void*[1] { &arg1_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Godot.Collections.Dictionary godot_icall_2_1483(IntPtr method, IntPtr ptr, Vector3* arg1, Vector3* arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_dictionary ret = default;
        void** call_args = stackalloc void*[2] { arg1, arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Godot.Collections.Dictionary.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe GodotObject godot_icall_4_1484(IntPtr method, IntPtr ptr, IntPtr arg1, godot_node_path arg2, Variant arg3, double arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_ref ret = default;
        godot_variant arg3_in = (godot_variant)arg3.NativeVar;
        void** call_args = stackalloc void*[4] { &arg1, &arg2, &arg3_in, &arg4 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return InteropUtils.UnmanagedGetManaged(ret.Reference);
    }

    internal static unsafe GodotObject godot_icall_4_1485(IntPtr method, IntPtr ptr, in Callable arg1, Variant arg2, Variant arg3, double arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_ref ret = default;
        using godot_callable arg1_in = Marshaling.ConvertCallableToNative(in arg1);
        godot_variant arg2_in = (godot_variant)arg2.NativeVar;
        godot_variant arg3_in = (godot_variant)arg3.NativeVar;
        void** call_args = stackalloc void*[4] { &arg1_in, &arg2_in, &arg3_in, &arg4 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return InteropUtils.UnmanagedGetManaged(ret.Reference);
    }

    internal static unsafe Variant godot_icall_6_1486(IntPtr method, Variant arg1, Variant arg2, double arg3, double arg4, int arg5, int arg6)
    {
        godot_variant ret = default;
        godot_variant arg1_in = (godot_variant)arg1.NativeVar;
        godot_variant arg2_in = (godot_variant)arg2.NativeVar;
        long arg5_in = arg5;
        long arg6_in = arg6;
        void** call_args = stackalloc void*[6] { &arg1_in, &arg2_in, &arg3, &arg4, &arg5_in, &arg6_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, IntPtr.Zero, call_args, &ret);
        return Variant.CreateTakingOwnershipOfDisposableValue(ret);
    }

    internal static unsafe int godot_icall_3_1487(IntPtr method, IntPtr ptr, int arg1, int arg2, string arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        long arg1_in = arg1;
        long arg2_in = arg2;
        using godot_string arg3_in = Marshaling.ConvertStringToNative(arg3);
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2_in, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe int godot_icall_5_1488(IntPtr method, IntPtr ptr, int arg1, int arg2, string arg3, string arg4, int arg5)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        long arg1_in = arg1;
        long arg2_in = arg2;
        using godot_string arg3_in = Marshaling.ConvertStringToNative(arg3);
        using godot_string arg4_in = Marshaling.ConvertStringToNative(arg4);
        long arg5_in = arg5;
        void** call_args = stackalloc void*[5] { &arg1_in, &arg2_in, &arg3_in, &arg4_in, &arg5_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe Rid godot_icall_3_1489(IntPtr method, Rid arg1, uint arg2, godot_array arg3)
    {
        Rid ret;
        long arg2_in = arg2;
        void** call_args = stackalloc void*[3] { &arg1, &arg2_in, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, IntPtr.Zero, call_args, &ret);
        return ret;
    }

    internal static unsafe int godot_icall_3_1490(IntPtr method, IntPtr ptr, int arg1, ReadOnlySpan<float> arg2, int arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        long arg1_in = arg1;
        using godot_packed_float32_array arg2_in = Marshaling.ConvertSystemArrayToNativePackedFloat32Array(arg2);
        long arg3_in = arg3;
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2_in, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe void godot_icall_4_1491(IntPtr method, IntPtr ptr, int arg1, IntPtr arg2, Vector2* arg3, int arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        long arg4_in = arg4;
        void** call_args = stackalloc void*[4] { &arg1_in, &arg2, arg3, &arg4_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_3_1492(IntPtr method, IntPtr ptr, int arg1, int arg2, Vector2* arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        long arg2_in = arg2;
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2_in, arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe godot_bool godot_icall_5_1493(IntPtr method, IntPtr ptr, int arg1, int arg2, int arg3, int arg4, int arg5)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        godot_bool ret;
        long arg1_in = arg1;
        long arg2_in = arg2;
        long arg3_in = arg3;
        long arg4_in = arg4;
        long arg5_in = arg5;
        void** call_args = stackalloc void*[5] { &arg1_in, &arg2_in, &arg3_in, &arg4_in, &arg5_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe void godot_icall_3_1494(IntPtr method, IntPtr ptr, int arg1, Variant arg2, Variant arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg1_in = arg1;
        godot_variant arg2_in = (godot_variant)arg2.NativeVar;
        godot_variant arg3_in = (godot_variant)arg3.NativeVar;
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2_in, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_1_1495(IntPtr method, IntPtr ptr, Vector4* arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        void** call_args = stackalloc void*[1] { arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe Vector4 godot_icall_0_1496(IntPtr method, IntPtr ptr)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Vector4 ret;
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, null, &ret);
        return ret;
    }

    internal static unsafe void godot_icall_7_1497(IntPtr method, IntPtr ptr, Transform3D* arg1, Aabb* arg2, Vector3* arg3, ReadOnlySpan<byte> arg4, ReadOnlySpan<byte> arg5, ReadOnlySpan<byte> arg6, ReadOnlySpan<int> arg7)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_byte_array arg4_in = Marshaling.ConvertSystemArrayToNativePackedByteArray(arg4);
        using godot_packed_byte_array arg5_in = Marshaling.ConvertSystemArrayToNativePackedByteArray(arg5);
        using godot_packed_byte_array arg6_in = Marshaling.ConvertSystemArrayToNativePackedByteArray(arg6);
        using godot_packed_int32_array arg7_in = Marshaling.ConvertSystemArrayToNativePackedInt32Array(arg7);
        void** call_args = stackalloc void*[7] { arg1, arg2, arg3, &arg4_in, &arg5_in, &arg6_in, &arg7_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe int godot_icall_2_1498(IntPtr method, IntPtr ptr, int arg1, godot_array arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        long arg1_in = arg1;
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe int godot_icall_3_1499(IntPtr method, IntPtr ptr, IntPtr arg1, int arg2, int arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        long arg2_in = arg2;
        long arg3_in = arg3;
        void** call_args = stackalloc void*[3] { &arg1, &arg2_in, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe int godot_icall_1_1500(IntPtr method, IntPtr ptr, godot_dictionary arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe GodotObject godot_icall_2_1501(IntPtr method, IntPtr ptr, string arg1, godot_dictionary arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_ref ret = default;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return InteropUtils.UnmanagedGetManaged(ret.Reference);
    }

    internal static unsafe int godot_icall_3_1502(IntPtr method, IntPtr ptr, string arg1, int arg2, string arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        long arg2_in = arg2;
        using godot_string arg3_in = Marshaling.ConvertStringToNative(arg3);
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2_in, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe int godot_icall_3_1503(IntPtr method, IntPtr ptr, int arg1, string arg2, IntPtr arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        long arg1_in = arg1;
        using godot_string arg2_in = Marshaling.ConvertStringToNative(arg2);
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2_in, &arg3 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe int godot_icall_2_1504(IntPtr method, IntPtr ptr, ReadOnlySpan<byte> arg1, int arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        using godot_packed_byte_array arg1_in = Marshaling.ConvertSystemArrayToNativePackedByteArray(arg1);
        long arg2_in = arg2;
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe GodotObject godot_icall_0_1505(IntPtr method)
    {
        IntPtr ret = default;
        NativeFuncs.godotsharp_method_bind_ptrcall(method, IntPtr.Zero, null, &ret);
        return InteropUtils.UnmanagedGetManaged(ret);
    }

    internal static unsafe long godot_icall_3_1506(IntPtr method, IntPtr ptr, in Callable arg1, godot_bool arg2, string arg3)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        using godot_callable arg1_in = Marshaling.ConvertCallableToNative(in arg1);
        using godot_string arg3_in = Marshaling.ConvertStringToNative(arg3);
        void** call_args = stackalloc void*[3] { &arg1_in, &arg2, &arg3_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe long godot_icall_5_1507(IntPtr method, IntPtr ptr, in Callable arg1, int arg2, int arg3, godot_bool arg4, string arg5)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        using godot_callable arg1_in = Marshaling.ConvertCallableToNative(in arg1);
        long arg2_in = arg2;
        long arg3_in = arg3;
        using godot_string arg5_in = Marshaling.ConvertStringToNative(arg5);
        void** call_args = stackalloc void*[5] { &arg1_in, &arg2_in, &arg3_in, &arg4, &arg5_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Plane godot_icall_0_1508(IntPtr method, IntPtr ptr)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Plane ret;
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, null, &ret);
        return ret;
    }

    internal static unsafe int godot_icall_1_1509(IntPtr method, IntPtr ptr, ulong arg1)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long ret;
        void** call_args = stackalloc void*[1] { &arg1 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return (int)(ret);
    }

    internal static unsafe void godot_icall_6_1510(IntPtr method, IntPtr ptr, string arg1, godot_string_name arg2, double arg3, double arg4, double arg5, double arg6)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        void** call_args = stackalloc void*[6] { &arg1_in, &arg2, &arg3, &arg4, &arg5, &arg6 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe Transform3D godot_icall_2_1511(IntPtr method, IntPtr ptr, uint arg1, Transform3D* arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Transform3D ret;
        long arg1_in = arg1;
        void** call_args = stackalloc void*[2] { &arg1_in, arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe Projection godot_icall_4_1512(IntPtr method, IntPtr ptr, uint arg1, double arg2, double arg3, double arg4)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Projection ret;
        long arg1_in = arg1;
        void** call_args = stackalloc void*[4] { &arg1_in, &arg2, &arg3, &arg4 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe void godot_icall_11_1513(IntPtr method, IntPtr ptr, Rid arg1, Rect2* arg2, Rect2I* arg3, godot_bool arg4, uint arg5, godot_bool arg6, Vector2* arg7, double arg8, double arg9, double arg10, double arg11)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg5_in = arg5;
        void** call_args = stackalloc void*[11] { &arg1, arg2, arg3, &arg4, &arg5_in, &arg6, arg7, &arg8, &arg9, &arg10, &arg11 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_5_1514(IntPtr method, IntPtr ptr, string arg1, double arg2, double arg3, double arg4, double arg5)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        void** call_args = stackalloc void*[5] { &arg1_in, &arg2, &arg3, &arg4, &arg5 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe void godot_icall_5_1515(IntPtr method, IntPtr ptr, godot_string_name arg1, Transform3D* arg2, Vector3* arg3, Vector3* arg4, int arg5)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        long arg5_in = arg5;
        void** call_args = stackalloc void*[5] { &arg1, arg2, arg3, arg4, &arg5_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, null);
    }

    internal static unsafe Rid godot_icall_2_1516(IntPtr method, IntPtr ptr, Vector2* arg1, ReadOnlySpan<Vector2> arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        Rid ret;
        using godot_packed_vector2_array arg2_in = Marshaling.ConvertSystemArrayToNativePackedVector2Array(arg2);
        void** call_args = stackalloc void*[2] { arg1, &arg2_in };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return ret;
    }

    internal static unsafe byte[] godot_icall_2_1517(IntPtr method, IntPtr ptr, string arg1, godot_bool arg2)
    {
        ExceptionUtils.ThrowIfNullPtr(ptr);
        using godot_packed_byte_array ret = default;
        using godot_string arg1_in = Marshaling.ConvertStringToNative(arg1);
        void** call_args = stackalloc void*[2] { &arg1_in, &arg2 };
        NativeFuncs.godotsharp_method_bind_ptrcall(method, ptr, call_args, &ret);
        return Marshaling.ConvertNativePackedByteArrayToSystemArray(ret);
    }
}
