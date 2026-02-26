namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para><see cref="Godot.MethodTweener"/> is similar to a combination of <see cref="Godot.CallbackTweener"/> and <see cref="Godot.PropertyTweener"/>. It calls a method providing an interpolated value as a parameter. See <see cref="Godot.Tween.TweenMethod(Callable, Variant, Variant, double)"/> for more usage information.</para>
/// <para>The tweener will finish automatically if the callback's target object is freed.</para>
/// <para><b>Note:</b> <see cref="Godot.Tween.TweenMethod(Callable, Variant, Variant, double)"/> is the only correct way to create <see cref="Godot.MethodTweener"/>. Any <see cref="Godot.MethodTweener"/> created manually will not function correctly.</para>
/// </summary>
public partial class MethodTweener : Tweener
{
    private static readonly System.Type CachedType = typeof(MethodTweener);

    private static readonly StringName NativeName = "MethodTweener";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public MethodTweener() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal MethodTweener(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal MethodTweener(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDelay, 266477812ul);

    /// <summary>
    /// <para>Sets the time in seconds after which the <see cref="Godot.MethodTweener"/> will start interpolating. By default there's no delay.</para>
    /// </summary>
    public MethodTweener SetDelay(double delay)
    {
        return (MethodTweener)NativeCalls.godot_icall_1_230(MethodBind0, GodotObject.GetPtr(this), delay);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTrans, 3740975367ul);

    /// <summary>
    /// <para>Sets the type of used transition from <see cref="Godot.Tween.TransitionType"/>. If not set, the default transition is used from the <see cref="Godot.Tween"/> that contains this Tweener.</para>
    /// </summary>
    public MethodTweener SetTrans(Tween.TransitionType trans)
    {
        return (MethodTweener)NativeCalls.godot_icall_1_71(MethodBind1, GodotObject.GetPtr(this), (int)trans);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEase, 315540545ul);

    /// <summary>
    /// <para>Sets the type of used easing from <see cref="Godot.Tween.EaseType"/>. If not set, the default easing is used from the <see cref="Godot.Tween"/> that contains this Tweener.</para>
    /// </summary>
    public MethodTweener SetEase(Tween.EaseType ease)
    {
        return (MethodTweener)NativeCalls.godot_icall_1_71(MethodBind2, GodotObject.GetPtr(this), (int)ease);
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
        /// <summary>
        /// Cached name for the 'set_trans' method.
        /// </summary>
        public static readonly StringName SetTrans = "set_trans";
        /// <summary>
        /// Cached name for the 'set_ease' method.
        /// </summary>
        public static readonly StringName SetEase = "set_ease";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Tweener.SignalName
    {
    }
}
