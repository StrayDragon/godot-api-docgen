namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para><see cref="Godot.CallbackTweener"/> is used to call a method in a tweening sequence. See <see cref="Godot.Tween.TweenCallback(Callable)"/> for more usage information.</para>
/// <para>The tweener will finish automatically if the callback's target object is freed.</para>
/// <para><b>Note:</b> <see cref="Godot.Tween.TweenCallback(Callable)"/> is the only correct way to create <see cref="Godot.CallbackTweener"/>. Any <see cref="Godot.CallbackTweener"/> created manually will not function correctly.</para>
/// </summary>
public partial class CallbackTweener : Tweener
{
    private static readonly System.Type CachedType = typeof(CallbackTweener);

    private static readonly StringName NativeName = "CallbackTweener";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public CallbackTweener() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal CallbackTweener(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal CallbackTweener(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDelay, 3008182292ul);

    /// <summary>
    /// <para>Makes the callback call delayed by given time in seconds.</para>
    /// <para><b>Example:</b> Call <see cref="Godot.Node.QueueFree()"/> after 2 seconds:</para>
    /// <para><code>
    /// var tween = get_tree().create_tween()
    /// tween.tween_callback(queue_free).set_delay(2)
    /// </code></para>
    /// </summary>
    public CallbackTweener SetDelay(double delay)
    {
        return (CallbackTweener)NativeCalls.godot_icall_1_230(MethodBind0, GodotObject.GetPtr(this), delay);
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
    public new class PropertyName : Tweener.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Tweener.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_delay' method.
        /// </summary>
        public static readonly StringName SetDelay = "set_delay";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Tweener.SignalName
    {
    }
}
