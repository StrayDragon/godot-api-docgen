namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Result object tracking the asynchronous result of an OpenXR Future object, you can use this object to track the result status.</para>
/// </summary>
public partial class OpenXRFutureResult : RefCounted
{
    public enum ResultStatus : long
    {
        /// <summary>
        /// <para>The asynchronous function is running.</para>
        /// </summary>
        Running = 0,
        /// <summary>
        /// <para>The asynchronous function has finished.</para>
        /// </summary>
        Finished = 1,
        /// <summary>
        /// <para>The asynchronous function has been cancelled.</para>
        /// </summary>
        Cancelled = 2
    }

    private static readonly System.Type CachedType = typeof(OpenXRFutureResult);

    private static readonly StringName NativeName = "OpenXRFutureResult";

    internal OpenXRFutureResult() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal OpenXRFutureResult(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal OpenXRFutureResult(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetStatus, 2023607463ul);

    /// <summary>
    /// <para>Returns the status of this result.</para>
    /// </summary>
    public OpenXRFutureResult.ResultStatus GetStatus()
    {
        return (OpenXRFutureResult.ResultStatus)NativeCalls.godot_icall_0_39(MethodBind0, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFuture, 3905245786ul);

    /// <summary>
    /// <para>Return the <c>XrFutureEXT</c> value this result relates to.</para>
    /// </summary>
    public ulong GetFuture()
    {
        return NativeCalls.godot_icall_0_137(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CancelFuture, 3218959716ul);

    /// <summary>
    /// <para>Cancel this future, this will interrupt and stop the asynchronous function.</para>
    /// </summary>
    public void CancelFuture()
    {
        NativeCalls.godot_icall_0_3(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetResultValue, 1114965689ul);

    /// <summary>
    /// <para>Stores the result value we expose to the user.</para>
    /// <para><b>Note:</b> This method should only be called by an OpenXR extension that implements an asynchronous function.</para>
    /// </summary>
    public void SetResultValue(Variant resultValue)
    {
        NativeCalls.godot_icall_1_773(MethodBind3, GodotObject.GetPtr(this), resultValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetResultValue, 1214101251ul);

    /// <summary>
    /// <para>Returns the result value of our asynchronous function (if set by the extension). The type of this result value depends on the function being called. Consult the documentation of the relevant function.</para>
    /// </summary>
    public Variant GetResultValue()
    {
        return NativeCalls.godot_icall_0_772(MethodBind4, GodotObject.GetPtr(this));
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.OpenXRFutureResult.Completed"/> event of a <see cref="Godot.OpenXRFutureResult"/> class.
    /// </summary>
    public delegate void CompletedEventHandler(OpenXRFutureResult result);

    private static void CompletedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((CompletedEventHandler)delegateObj)(VariantUtils.ConvertTo<OpenXRFutureResult>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when the asynchronous function is finished or has been cancelled.</para>
    /// </summary>
    public unsafe event CompletedEventHandler Completed
    {
        add => Connect(SignalName.Completed, Callable.CreateWithUnsafeTrampoline(value, &CompletedTrampoline));
        remove => Disconnect(SignalName.Completed, Callable.CreateWithUnsafeTrampoline(value, &CompletedTrampoline));
    }

    protected void EmitSignalCompleted(OpenXRFutureResult result)
    {
        EmitSignal(SignalName.Completed, result);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_completed = "Completed";

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
        if (signal == SignalName.Completed)
        {
            if (HasGodotClassSignal(SignalProxyName_completed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
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
        /// Cached name for the 'get_status' method.
        /// </summary>
        public static readonly StringName GetStatus = "get_status";
        /// <summary>
        /// Cached name for the 'get_future' method.
        /// </summary>
        public static readonly StringName GetFuture = "get_future";
        /// <summary>
        /// Cached name for the 'cancel_future' method.
        /// </summary>
        public static readonly StringName CancelFuture = "cancel_future";
        /// <summary>
        /// Cached name for the 'set_result_value' method.
        /// </summary>
        public static readonly StringName SetResultValue = "set_result_value";
        /// <summary>
        /// Cached name for the 'get_result_value' method.
        /// </summary>
        public static readonly StringName GetResultValue = "get_result_value";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : RefCounted.SignalName
    {
        /// <summary>
        /// Cached name for the 'completed' signal.
        /// </summary>
        public static readonly StringName Completed = "completed";
    }
}
