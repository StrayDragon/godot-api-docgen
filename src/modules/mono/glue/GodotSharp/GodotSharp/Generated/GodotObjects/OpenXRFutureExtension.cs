namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This is a support extension in OpenXR that allows other OpenXR extensions to start asynchronous functions and get a callback after this function finishes. It is not intended for consumption within GDScript but can be accessed from GDExtension.</para>
/// </summary>
public partial class OpenXRFutureExtension : OpenXRExtensionWrapper
{
    private static readonly System.Type CachedType = typeof(OpenXRFutureExtension);

    private static readonly StringName NativeName = "OpenXRFutureExtension";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public OpenXRFutureExtension() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal OpenXRFutureExtension(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal OpenXRFutureExtension(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsActive, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if futures are available in the OpenXR runtime used. This function will only return a usable result after OpenXR has been initialized.</para>
    /// </summary>
    public bool IsActive()
    {
        return NativeCalls.godot_icall_0_15(MethodBind0, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RegisterFuture, 1038012256ul);

    /// <summary>
    /// <para>Register an OpenXR Future object so we monitor for completion. <paramref name="future"/> must be an <c>XrFutureEXT</c> value previously returned by an API that started an asynchronous function.</para>
    /// <para>You can optionally specify <paramref name="onSuccess"/>, it will be invoked on successful completion of the future.</para>
    /// <para>Or you can use the returned <see cref="Godot.OpenXRFutureResult"/> object to <c>await</c> its <see cref="Godot.OpenXRFutureResult.Completed"/> signal.</para>
    /// <para><code>
    /// var future_result = OpenXRFutureExtension.register_future(future)
    /// await future_result.completed
    /// if future_result.get_status() == OpenXRFutureResult.RESULT_FINISHED:
    /// 	# Handle your success
    /// 	pass
    /// </code></para>
    /// </summary>
    public OpenXRFutureResult RegisterFuture(ulong future, Callable onSuccess = default)
    {
        return (OpenXRFutureResult)NativeCalls.godot_icall_2_935(MethodBind1, GodotObject.GetPtr(this), future, onSuccess);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CancelFuture, 1286410249ul);

    /// <summary>
    /// <para>Cancels an in-progress future. <paramref name="future"/> must be an <c>XrFutureEXT</c> value previously returned by an API that started an asynchronous function.</para>
    /// </summary>
    public void CancelFuture(ulong future)
    {
        NativeCalls.godot_icall_1_544(MethodBind2, GodotObject.GetPtr(this), future);
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
    public new class PropertyName : OpenXRExtensionWrapper.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : OpenXRExtensionWrapper.MethodName
    {
        /// <summary>
        /// Cached name for the 'is_active' method.
        /// </summary>
        public static readonly StringName IsActive = "is_active";
        /// <summary>
        /// Cached name for the 'register_future' method.
        /// </summary>
        public static readonly StringName RegisterFuture = "register_future";
        /// <summary>
        /// Cached name for the 'cancel_future' method.
        /// </summary>
        public static readonly StringName CancelFuture = "cancel_future";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : OpenXRExtensionWrapper.SignalName
    {
    }
}
