namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para><see cref="Godot.PropertyTweener"/> is used to interpolate a property in an object. See <see cref="Godot.Tween.TweenProperty(GodotObject, NodePath, Variant, double)"/> for more usage information.</para>
/// <para>The tweener will finish automatically if the target object is freed.</para>
/// <para><b>Note:</b> <see cref="Godot.Tween.TweenProperty(GodotObject, NodePath, Variant, double)"/> is the only correct way to create <see cref="Godot.PropertyTweener"/>. Any <see cref="Godot.PropertyTweener"/> created manually will not function correctly.</para>
/// </summary>
public partial class PropertyTweener : Tweener
{
    private static readonly System.Type CachedType = typeof(PropertyTweener);

    private static readonly StringName NativeName = "PropertyTweener";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public PropertyTweener() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal PropertyTweener(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal PropertyTweener(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.From, 4190193059ul);

    /// <summary>
    /// <para>Sets a custom initial value to the <see cref="Godot.PropertyTweener"/>.</para>
    /// <para><b>Example:</b> Move the node from position <c>(100, 100)</c> to <c>(200, 100)</c>.</para>
    /// <para><code>
    /// Tween tween = GetTree().CreateTween();
    /// tween.TweenProperty(this, "position", new Vector2(200.0f, 100.0f), 1.0f).From(new Vector2(100.0f, 100.0f));
    /// </code></para>
    /// </summary>
    public PropertyTweener From(Variant value)
    {
        return (PropertyTweener)NativeCalls.godot_icall_1_1030(MethodBind0, GodotObject.GetPtr(this), value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FromCurrent, 4279177709ul);

    /// <summary>
    /// <para>Makes the <see cref="Godot.PropertyTweener"/> use the current property value (i.e. at the time of creating this <see cref="Godot.PropertyTweener"/>) as a starting point. This is equivalent of using <see cref="Godot.PropertyTweener.From(Variant)"/> with the current value. These two calls will do the same:</para>
    /// <para><code>
    /// tween.TweenProperty(this, "position", new Vector2(200.0f, 100.0f), 1.0f).From(Position);
    /// tween.TweenProperty(this, "position", new Vector2(200.0f, 100.0f), 1.0f).FromCurrent();
    /// </code></para>
    /// </summary>
    public PropertyTweener FromCurrent()
    {
        return (PropertyTweener)NativeCalls.godot_icall_0_63(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AsRelative, 4279177709ul);

    /// <summary>
    /// <para>When called, the final value will be used as a relative value instead.</para>
    /// <para><b>Example:</b> Move the node by <c>100</c> pixels to the right.</para>
    /// <para><code>
    /// Tween tween = GetTree().CreateTween();
    /// tween.TweenProperty(this, "position", Vector2.Right * 100.0f, 1.0f).AsRelative();
    /// </code></para>
    /// </summary>
    public PropertyTweener AsRelative()
    {
        return (PropertyTweener)NativeCalls.godot_icall_0_63(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTrans, 1899107404ul);

    /// <summary>
    /// <para>Sets the type of used transition from <see cref="Godot.Tween.TransitionType"/>. If not set, the default transition is used from the <see cref="Godot.Tween"/> that contains this Tweener.</para>
    /// </summary>
    public PropertyTweener SetTrans(Tween.TransitionType trans)
    {
        return (PropertyTweener)NativeCalls.godot_icall_1_71(MethodBind3, GodotObject.GetPtr(this), (int)trans);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEase, 1080455622ul);

    /// <summary>
    /// <para>Sets the type of used easing from <see cref="Godot.Tween.EaseType"/>. If not set, the default easing is used from the <see cref="Godot.Tween"/> that contains this Tweener.</para>
    /// </summary>
    public PropertyTweener SetEase(Tween.EaseType ease)
    {
        return (PropertyTweener)NativeCalls.godot_icall_1_71(MethodBind4, GodotObject.GetPtr(this), (int)ease);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCustomInterpolator, 3174170268ul);

    /// <summary>
    /// <para>Allows interpolating the value with a custom easing function. The provided <paramref name="interpolatorMethod"/> will be called with a value ranging from <c>0.0</c> to <c>1.0</c> and is expected to return a value within the same range (values outside the range can be used for overshoot). The return value of the method is then used for interpolation between initial and final value. Note that the parameter passed to the method is still subject to the tweener's own easing.</para>
    /// <para><code>
    /// [Export]
    /// public Curve Curve { get; set; }
    /// 
    /// public override void _Ready()
    /// {
    /// 	Tween tween = CreateTween();
    /// 	// Interpolate the value using a custom curve.
    /// 	Callable tweenCurveCallable = Callable.From&lt;float, float&gt;(TweenCurve);
    /// 	tween.TweenProperty(this, "position:x", 300.0f, 1.0f).AsRelative().SetCustomInterpolator(tweenCurveCallable);
    /// }
    /// 
    /// private float TweenCurve(float value)
    /// {
    /// 	return Curve.SampleBaked(value);
    /// }
    /// </code></para>
    /// </summary>
    public PropertyTweener SetCustomInterpolator(Callable interpolatorMethod)
    {
        return (PropertyTweener)NativeCalls.godot_icall_1_781(MethodBind5, GodotObject.GetPtr(this), interpolatorMethod);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDelay, 2171559331ul);

    /// <summary>
    /// <para>Sets the time in seconds after which the <see cref="Godot.PropertyTweener"/> will start interpolating. By default there's no delay.</para>
    /// </summary>
    public PropertyTweener SetDelay(double delay)
    {
        return (PropertyTweener)NativeCalls.godot_icall_1_230(MethodBind6, GodotObject.GetPtr(this), delay);
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
        /// Cached name for the 'from' method.
        /// </summary>
        public static readonly StringName From = "from";
        /// <summary>
        /// Cached name for the 'from_current' method.
        /// </summary>
        public static readonly StringName FromCurrent = "from_current";
        /// <summary>
        /// Cached name for the 'as_relative' method.
        /// </summary>
        public static readonly StringName AsRelative = "as_relative";
        /// <summary>
        /// Cached name for the 'set_trans' method.
        /// </summary>
        public static readonly StringName SetTrans = "set_trans";
        /// <summary>
        /// Cached name for the 'set_ease' method.
        /// </summary>
        public static readonly StringName SetEase = "set_ease";
        /// <summary>
        /// Cached name for the 'set_custom_interpolator' method.
        /// </summary>
        public static readonly StringName SetCustomInterpolator = "set_custom_interpolator";
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
