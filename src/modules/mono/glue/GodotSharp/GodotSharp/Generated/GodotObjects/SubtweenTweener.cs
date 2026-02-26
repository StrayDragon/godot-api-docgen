namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para><see cref="Godot.SubtweenTweener"/> is used to execute a <see cref="Godot.Tween"/> as one step in a sequence defined by another <see cref="Godot.Tween"/>. See <see cref="Godot.Tween.TweenSubtween(Tween)"/> for more usage information.</para>
/// <para><b>Note:</b> <see cref="Godot.Tween.TweenSubtween(Tween)"/> is the only correct way to create <see cref="Godot.SubtweenTweener"/>. Any <see cref="Godot.SubtweenTweener"/> created manually will not function correctly.</para>
/// </summary>
public partial class SubtweenTweener : Tweener
{
    private static readonly System.Type CachedType = typeof(SubtweenTweener);

    private static readonly StringName NativeName = "SubtweenTweener";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public SubtweenTweener() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal SubtweenTweener(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal SubtweenTweener(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDelay, 449181780ul);

    /// <summary>
    /// <para>Sets the time in seconds after which the <see cref="Godot.SubtweenTweener"/> will start running the subtween. By default there's no delay.</para>
    /// </summary>
    public SubtweenTweener SetDelay(double delay)
    {
        return (SubtweenTweener)NativeCalls.godot_icall_1_230(MethodBind0, GodotObject.GetPtr(this), delay);
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
