namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Tweens are mostly useful for animations requiring a numerical property to be interpolated over a range of values. The name <i>tween</i> comes from <i>in-betweening</i>, an animation technique where you specify <i>keyframes</i> and the computer interpolates the frames that appear between them. Animating something with a <see cref="Godot.Tween"/> is called tweening.</para>
/// <para><see cref="Godot.Tween"/> is more suited than <see cref="Godot.AnimationPlayer"/> for animations where you don't know the final values in advance. For example, interpolating a dynamically-chosen camera zoom value is best done with a <see cref="Godot.Tween"/>; it would be difficult to do the same thing with an <see cref="Godot.AnimationPlayer"/> node. Tweens are also more light-weight than <see cref="Godot.AnimationPlayer"/>, so they are very much suited for simple animations or general tasks that don't require visual tweaking provided by the editor. They can be used in a "fire-and-forget" manner for some logic that normally would be done by code. You can e.g. make something shoot periodically by using a looped <see cref="Godot.CallbackTweener"/> with a delay.</para>
/// <para>A <see cref="Godot.Tween"/> can be created by using either <see cref="Godot.SceneTree.CreateTween()"/> or <see cref="Godot.Node.CreateTween()"/>. <see cref="Godot.Tween"/>s created manually (i.e. by using <c>Tween.new()</c>) are invalid and can't be used for tweening values.</para>
/// <para>A tween animation is created by adding <see cref="Godot.Tweener"/>s to the <see cref="Godot.Tween"/> object, using <see cref="Godot.Tween.TweenProperty(GodotObject, NodePath, Variant, double)"/>, <see cref="Godot.Tween.TweenInterval(double)"/>, <see cref="Godot.Tween.TweenCallback(Callable)"/> or <see cref="Godot.Tween.TweenMethod(Callable, Variant, Variant, double)"/>:</para>
/// <para><code>
/// Tween tween = GetTree().CreateTween();
/// tween.TweenProperty(GetNode("Sprite"), "modulate", Colors.Red, 1.0f);
/// tween.TweenProperty(GetNode("Sprite"), "scale", Vector2.Zero, 1.0f);
/// tween.TweenCallback(Callable.From(GetNode("Sprite").QueueFree));
/// </code></para>
/// <para>This sequence will make the <c>$Sprite</c> node turn red, then shrink, before finally calling <see cref="Godot.Node.QueueFree()"/> to free the sprite. <see cref="Godot.Tweener"/>s are executed one after another by default. This behavior can be changed using <see cref="Godot.Tween.Parallel()"/> and <see cref="Godot.Tween.SetParallel(bool)"/>.</para>
/// <para>When a <see cref="Godot.Tweener"/> is created with one of the <c>tween_*</c> methods, a chained method call can be used to tweak the properties of this <see cref="Godot.Tweener"/>. For example, if you want to set a different transition type in the above example, you can use <see cref="Godot.Tween.SetTrans(Tween.TransitionType)"/>:</para>
/// <para><code>
/// Tween tween = GetTree().CreateTween();
/// tween.TweenProperty(GetNode("Sprite"), "modulate", Colors.Red, 1.0f).SetTrans(Tween.TransitionType.Sine);
/// tween.TweenProperty(GetNode("Sprite"), "scale", Vector2.Zero, 1.0f).SetTrans(Tween.TransitionType.Bounce);
/// tween.TweenCallback(Callable.From(GetNode("Sprite").QueueFree));
/// </code></para>
/// <para>Most of the <see cref="Godot.Tween"/> methods can be chained this way too. In the following example the <see cref="Godot.Tween"/> is bound to the running script's node and a default transition is set for its <see cref="Godot.Tweener"/>s:</para>
/// <para><code>
/// var tween = GetTree().CreateTween().BindNode(this).SetTrans(Tween.TransitionType.Elastic);
/// tween.TweenProperty(GetNode("Sprite"), "modulate", Colors.Red, 1.0f);
/// tween.TweenProperty(GetNode("Sprite"), "scale", Vector2.Zero, 1.0f);
/// tween.TweenCallback(Callable.From(GetNode("Sprite").QueueFree));
/// </code></para>
/// <para>Another interesting use for <see cref="Godot.Tween"/>s is animating arbitrary sets of objects:</para>
/// <para><code>
/// Tween tween = CreateTween();
/// foreach (Node sprite in GetChildren())
/// 	tween.TweenProperty(sprite, "position", Vector2.Zero, 1.0f);
/// </code></para>
/// <para>In the example above, all children of a node are moved one after another to position <c>(0, 0)</c>.</para>
/// <para>You should avoid using more than one <see cref="Godot.Tween"/> per object's property. If two or more tweens animate one property at the same time, the last one created will take priority and assign the final value. If you want to interrupt and restart an animation, consider assigning the <see cref="Godot.Tween"/> to a variable:</para>
/// <para><code>
/// private Tween _tween;
/// 
/// public void Animate()
/// {
/// 	if (_tween != null)
/// 		_tween.Kill(); // Abort the previous animation
/// 	_tween = CreateTween();
/// }
/// </code></para>
/// <para>Some <see cref="Godot.Tweener"/>s use transitions and eases. The first accepts a <see cref="Godot.Tween.TransitionType"/> constant, and refers to the way the timing of the animation is handled (see <a href="https://easings.net/">easings.net</a> for some examples). The second accepts an <see cref="Godot.Tween.EaseType"/> constant, and controls where the <c>trans_type</c> is applied to the interpolation (in the beginning, the end, or both). If you don't know which transition and easing to pick, you can try different <see cref="Godot.Tween.TransitionType"/> constants with <see cref="Godot.Tween.EaseType.InOut"/>, and use the one that looks best.</para>
/// <para><a href="https://raw.githubusercontent.com/godotengine/godot-docs/master/img/tween_cheatsheet.webp">Tween easing and transition types cheatsheet</a></para>
/// <para><b>Note:</b> Tweens are not designed to be reused and trying to do so results in an undefined behavior. Create a new Tween for each animation and every time you replay an animation from start. Keep in mind that Tweens start immediately, so only create a Tween when you want to start animating.</para>
/// <para><b>Note:</b> The tween is processed after all of the nodes in the current frame, i.e. node's <see cref="Godot.Node._Process(double)"/> method would be called before the tween (or <see cref="Godot.Node._PhysicsProcess(double)"/> depending on the value passed to <see cref="Godot.Tween.SetProcessMode(Tween.TweenProcessMode)"/>).</para>
/// </summary>
public partial class Tween : RefCounted
{
    public enum TweenProcessMode : long
    {
        /// <summary>
        /// <para>The <see cref="Godot.Tween"/> updates after each physics frame (see <see cref="Godot.Node._PhysicsProcess(double)"/>).</para>
        /// </summary>
        Physics = 0,
        /// <summary>
        /// <para>The <see cref="Godot.Tween"/> updates after each process frame (see <see cref="Godot.Node._Process(double)"/>).</para>
        /// </summary>
        Idle = 1
    }

    public enum TweenPauseMode : long
    {
        /// <summary>
        /// <para>If the <see cref="Godot.Tween"/> has a bound node, it will process when that node can process (see <see cref="Godot.Node.ProcessMode"/>). Otherwise it's the same as <see cref="Godot.Tween.TweenPauseMode.Stop"/>.</para>
        /// </summary>
        Bound = 0,
        /// <summary>
        /// <para>If <see cref="Godot.SceneTree"/> is paused, the <see cref="Godot.Tween"/> will also pause.</para>
        /// </summary>
        Stop = 1,
        /// <summary>
        /// <para>The <see cref="Godot.Tween"/> will process regardless of whether <see cref="Godot.SceneTree"/> is paused.</para>
        /// </summary>
        Process = 2
    }

    public enum TransitionType : long
    {
        /// <summary>
        /// <para>The animation is interpolated linearly.</para>
        /// </summary>
        Linear = 0,
        /// <summary>
        /// <para>The animation is interpolated using a sine function.</para>
        /// </summary>
        Sine = 1,
        /// <summary>
        /// <para>The animation is interpolated with a quintic (to the power of 5) function.</para>
        /// </summary>
        Quint = 2,
        /// <summary>
        /// <para>The animation is interpolated with a quartic (to the power of 4) function.</para>
        /// </summary>
        Quart = 3,
        /// <summary>
        /// <para>The animation is interpolated with a quadratic (to the power of 2) function.</para>
        /// </summary>
        Quad = 4,
        /// <summary>
        /// <para>The animation is interpolated with an exponential (to the power of x) function.</para>
        /// </summary>
        Expo = 5,
        /// <summary>
        /// <para>The animation is interpolated with elasticity, wiggling around the edges.</para>
        /// </summary>
        Elastic = 6,
        /// <summary>
        /// <para>The animation is interpolated with a cubic (to the power of 3) function.</para>
        /// </summary>
        Cubic = 7,
        /// <summary>
        /// <para>The animation is interpolated with a function using square roots.</para>
        /// </summary>
        Circ = 8,
        /// <summary>
        /// <para>The animation is interpolated by bouncing at the end.</para>
        /// </summary>
        Bounce = 9,
        /// <summary>
        /// <para>The animation is interpolated backing out at ends.</para>
        /// </summary>
        Back = 10,
        /// <summary>
        /// <para>The animation is interpolated like a spring towards the end.</para>
        /// </summary>
        Spring = 11
    }

    public enum EaseType : long
    {
        /// <summary>
        /// <para>The interpolation starts slowly and speeds up towards the end.</para>
        /// </summary>
        In = 0,
        /// <summary>
        /// <para>The interpolation starts quickly and slows down towards the end.</para>
        /// </summary>
        Out = 1,
        /// <summary>
        /// <para>A combination of <see cref="Godot.Tween.EaseType.In"/> and <see cref="Godot.Tween.EaseType.Out"/>. The interpolation is slowest at both ends.</para>
        /// </summary>
        InOut = 2,
        /// <summary>
        /// <para>A combination of <see cref="Godot.Tween.EaseType.In"/> and <see cref="Godot.Tween.EaseType.Out"/>. The interpolation is fastest at both ends.</para>
        /// </summary>
        OutIn = 3
    }

    private static readonly System.Type CachedType = typeof(Tween);

    private static readonly StringName NativeName = "Tween";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public Tween() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal Tween(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal Tween(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.TweenProperty, 4049770449ul);

    /// <summary>
    /// <para>Creates and appends a <see cref="Godot.PropertyTweener"/>. This method tweens a <paramref name="property"/> of an <paramref name="object"/> between an initial value and <paramref name="finalVal"/> in a span of time equal to <paramref name="duration"/>, in seconds. The initial value by default is the property's value at the time the tweening of the <see cref="Godot.PropertyTweener"/> starts.</para>
    /// <para><code>
    /// Tween tween = CreateTween();
    /// tween.TweenProperty(GetNode("Sprite"), "position", new Vector2(100.0f, 200.0f), 1.0f);
    /// tween.TweenProperty(GetNode("Sprite"), "position", new Vector2(200.0f, 300.0f), 1.0f);
    /// </code></para>
    /// <para>will move the sprite to position (100, 200) and then to (200, 300). If you use <see cref="Godot.PropertyTweener.From(Variant)"/> or <see cref="Godot.PropertyTweener.FromCurrent()"/>, the starting position will be overwritten by the given value instead. See other methods in <see cref="Godot.PropertyTweener"/> to see how the tweening can be tweaked further.</para>
    /// <para><b>Note:</b> You can find the correct property name by hovering over the property in the Inspector. You can also provide the components of a property directly by using <c>"property:component"</c> (eg. <c>position:x</c>), where it would only apply to that particular component.</para>
    /// <para><b>Example:</b> Moving an object twice from the same position, with different transition types:</para>
    /// <para><code>
    /// Tween tween = CreateTween();
    /// tween.TweenProperty(GetNode("Sprite"), "position", Vector2.Right * 300.0f, 1.0f).AsRelative().SetTrans(Tween.TransitionType.Sine);
    /// tween.TweenProperty(GetNode("Sprite"), "position", Vector2.Right * 300.0f, 1.0f).AsRelative().FromCurrent().SetTrans(Tween.TransitionType.Expo);
    /// </code></para>
    /// </summary>
    public PropertyTweener TweenProperty(GodotObject @object, NodePath property, Variant finalVal, double duration)
    {
        return (PropertyTweener)NativeCalls.godot_icall_4_1484(MethodBind0, GodotObject.GetPtr(this), GodotObject.GetPtr(@object), (godot_node_path)(property?.NativeValue ?? default), finalVal, duration);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.TweenInterval, 413360199ul);

    /// <summary>
    /// <para>Creates and appends an <see cref="Godot.IntervalTweener"/>. This method can be used to create delays in the tween animation, as an alternative to using the delay in other <see cref="Godot.Tweener"/>s, or when there's no animation (in which case the <see cref="Godot.Tween"/> acts as a timer). <paramref name="time"/> is the length of the interval, in seconds.</para>
    /// <para><b>Example:</b> Creating an interval in code execution:</para>
    /// <para><code>
    /// // ... some code
    /// await ToSignal(CreateTween().TweenInterval(2.0f), Tween.SignalName.Finished);
    /// // ... more code
    /// </code></para>
    /// <para><b>Example:</b> Creating an object that moves back and forth and jumps every few seconds:</para>
    /// <para><code>
    /// Tween tween = CreateTween().SetLoops();
    /// tween.TweenProperty(GetNode("Sprite"), "position:x", 200.0f, 1.0f).AsRelative();
    /// tween.TweenCallback(Callable.From(Jump));
    /// tween.TweenInterval(2.0f);
    /// tween.TweenProperty(GetNode("Sprite"), "position:x", -200.0f, 1.0f).AsRelative();
    /// tween.TweenCallback(Callable.From(Jump));
    /// tween.TweenInterval(2.0f);
    /// </code></para>
    /// </summary>
    public IntervalTweener TweenInterval(double time)
    {
        return (IntervalTweener)NativeCalls.godot_icall_1_230(MethodBind1, GodotObject.GetPtr(this), time);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.TweenCallback, 1540176488ul);

    /// <summary>
    /// <para>Creates and appends a <see cref="Godot.CallbackTweener"/>. This method can be used to call an arbitrary method in any object. Use <c>Callable.bind</c> to bind additional arguments for the call.</para>
    /// <para><b>Example:</b> Object that keeps shooting every 1 second:</para>
    /// <para><code>
    /// Tween tween = GetTree().CreateTween().SetLoops();
    /// tween.TweenCallback(Callable.From(Shoot)).SetDelay(1.0f);
    /// </code></para>
    /// <para><b>Example:</b> Turning a sprite red and then blue, with 2 second delay:</para>
    /// <para><code>
    /// Tween tween = GetTree().CreateTween();
    /// Sprite2D sprite = GetNode&lt;Sprite2D&gt;("Sprite");
    /// tween.TweenCallback(Callable.From(() =&gt; sprite.Modulate = Colors.Red)).SetDelay(2.0f);
    /// tween.TweenCallback(Callable.From(() =&gt; sprite.Modulate = Colors.Blue)).SetDelay(2.0f);
    /// </code></para>
    /// </summary>
    public CallbackTweener TweenCallback(Callable callback)
    {
        return (CallbackTweener)NativeCalls.godot_icall_1_781(MethodBind2, GodotObject.GetPtr(this), callback);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.TweenMethod, 2337877153ul);

    /// <summary>
    /// <para>Creates and appends a <see cref="Godot.MethodTweener"/>. This method is similar to a combination of <see cref="Godot.Tween.TweenCallback(Callable)"/> and <see cref="Godot.Tween.TweenProperty(GodotObject, NodePath, Variant, double)"/>. It calls a method over time with a tweened value provided as an argument. The value is tweened between <paramref name="from"/> and <paramref name="to"/> over the time specified by <paramref name="duration"/>, in seconds. Use <c>Callable.bind</c> to bind additional arguments for the call. You can use <see cref="Godot.MethodTweener.SetEase(Tween.EaseType)"/> and <see cref="Godot.MethodTweener.SetTrans(Tween.TransitionType)"/> to tweak the easing and transition of the value or <see cref="Godot.MethodTweener.SetDelay(double)"/> to delay the tweening.</para>
    /// <para><b>Example:</b> Making a 3D object look from one point to another point:</para>
    /// <para><code>
    /// Tween tween = CreateTween();
    /// tween.TweenMethod(Callable.From((Vector3 target) =&gt; LookAt(target, Vector3.Up)), new Vector3(-1.0f, 0.0f, -1.0f), new Vector3(1.0f, 0.0f, -1.0f), 1.0f); // Use lambdas to bind additional arguments for the call.
    /// </code></para>
    /// <para><b>Example:</b> Setting the text of a <see cref="Godot.Label"/>, using an intermediate method and after a delay:</para>
    /// <para><code>
    /// public override void _Ready()
    /// {
    /// 	base._Ready();
    /// 
    /// 	Tween tween = CreateTween();
    /// 	tween.TweenMethod(Callable.From&lt;int&gt;(SetLabelText), 0.0f, 10.0f, 1.0f).SetDelay(1.0f);
    /// }
    /// 
    /// private void SetLabelText(int value)
    /// {
    /// 	GetNode&lt;Label&gt;("Label").Text = $"Counting {value}";
    /// }
    /// </code></para>
    /// </summary>
    public MethodTweener TweenMethod(Callable method, Variant from, Variant to, double duration)
    {
        return (MethodTweener)NativeCalls.godot_icall_4_1485(MethodBind3, GodotObject.GetPtr(this), method, from, to, duration);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.TweenSubtween, 1567358477ul);

    /// <summary>
    /// <para>Creates and appends a <see cref="Godot.SubtweenTweener"/>. This method can be used to nest <paramref name="subtween"/> within this <see cref="Godot.Tween"/>, allowing for the creation of more complex and composable sequences.</para>
    /// <para><code>
    /// # Subtween will rotate the object.
    /// var subtween = create_tween()
    /// subtween.tween_property(self, "rotation_degrees", 45.0, 1.0)
    /// subtween.tween_property(self, "rotation_degrees", 0.0, 1.0)
    /// 
    /// # Parent tween will execute the subtween as one of its steps.
    /// var tween = create_tween()
    /// tween.tween_property(self, "position:x", 500, 3.0)
    /// tween.tween_subtween(subtween)
    /// tween.tween_property(self, "position:x", 300, 2.0)
    /// </code></para>
    /// <para><b>Note:</b> The methods <see cref="Godot.Tween.Pause()"/>, <see cref="Godot.Tween.Stop()"/>, and <see cref="Godot.Tween.SetLoops(int)"/> can cause the parent <see cref="Godot.Tween"/> to get stuck on the subtween step; see the documentation for those methods for more information.</para>
    /// <para><b>Note:</b> The pause and process modes set by <see cref="Godot.Tween.SetPauseMode(Tween.TweenPauseMode)"/> and <see cref="Godot.Tween.SetProcessMode(Tween.TweenProcessMode)"/> on <paramref name="subtween"/> will be overridden by the parent <see cref="Godot.Tween"/>'s settings.</para>
    /// </summary>
    public SubtweenTweener TweenSubtween(Tween subtween)
    {
        return (SubtweenTweener)NativeCalls.godot_icall_1_268(MethodBind4, GodotObject.GetPtr(this), GodotObject.GetPtr(subtween));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CustomStep, 330693286ul);

    /// <summary>
    /// <para>Processes the <see cref="Godot.Tween"/> by the given <paramref name="delta"/> value, in seconds. This is mostly useful for manual control when the <see cref="Godot.Tween"/> is paused. It can also be used to end the <see cref="Godot.Tween"/> animation immediately, by setting <paramref name="delta"/> longer than the whole duration of the <see cref="Godot.Tween"/> animation.</para>
    /// <para>Returns <see langword="true"/> if the <see cref="Godot.Tween"/> still has <see cref="Godot.Tweener"/>s that haven't finished.</para>
    /// </summary>
    public bool CustomStep(double delta)
    {
        return NativeCalls.godot_icall_1_569(MethodBind5, GodotObject.GetPtr(this), delta).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Stop, 3218959716ul);

    /// <summary>
    /// <para>Stops the tweening and resets the <see cref="Godot.Tween"/> to its initial state. This will not remove any appended <see cref="Godot.Tweener"/>s.</para>
    /// <para><b>Note:</b> This does <i>not</i> reset targets of <see cref="Godot.PropertyTweener"/>s to their values when the <see cref="Godot.Tween"/> first started.</para>
    /// <para><code>
    /// var tween = create_tween()
    /// 
    /// # Will move from 0 to 500 over 1 second.
    /// position.x = 0.0
    /// tween.tween_property(self, "position:x", 500, 1.0)
    /// 
    /// # Will be at (about) 250 when the timer finishes.
    /// await get_tree().create_timer(0.5).timeout
    /// 
    /// # Will now move from (about) 250 to 500 over 1 second,
    /// # thus at half the speed as before.
    /// tween.stop()
    /// tween.play()
    /// </code></para>
    /// <para><b>Note:</b> If a Tween is stopped and not bound to any node, it will exist indefinitely until manually started or invalidated. If you lose a reference to such Tween, you can retrieve it using <see cref="Godot.SceneTree.GetProcessedTweens()"/>.</para>
    /// </summary>
    public void Stop()
    {
        NativeCalls.godot_icall_0_3(MethodBind6, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Pause, 3218959716ul);

    /// <summary>
    /// <para>Pauses the tweening. The animation can be resumed by using <see cref="Godot.Tween.Play()"/>.</para>
    /// <para><b>Note:</b> If a Tween is paused and not bound to any node, it will exist indefinitely until manually started or invalidated. If you lose a reference to such Tween, you can retrieve it using <see cref="Godot.SceneTree.GetProcessedTweens()"/>.</para>
    /// </summary>
    public void Pause()
    {
        NativeCalls.godot_icall_0_3(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Play, 3218959716ul);

    /// <summary>
    /// <para>Resumes a paused or stopped <see cref="Godot.Tween"/>.</para>
    /// </summary>
    public void Play()
    {
        NativeCalls.godot_icall_0_3(MethodBind8, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Kill, 3218959716ul);

    /// <summary>
    /// <para>Aborts all tweening operations and invalidates the <see cref="Godot.Tween"/>.</para>
    /// </summary>
    public void Kill()
    {
        NativeCalls.godot_icall_0_3(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTotalElapsedTime, 1740695150ul);

    /// <summary>
    /// <para>Returns the total time in seconds the <see cref="Godot.Tween"/> has been animating (i.e. the time since it started, not counting pauses etc.). The time is affected by <see cref="Godot.Tween.SetSpeedScale(float)"/>, and <see cref="Godot.Tween.Stop()"/> will reset it to <c>0</c>.</para>
    /// <para><b>Note:</b> As it results from accumulating frame deltas, the time returned after the <see cref="Godot.Tween"/> has finished animating will be slightly greater than the actual <see cref="Godot.Tween"/> duration.</para>
    /// </summary>
    public double GetTotalElapsedTime()
    {
        return NativeCalls.godot_icall_0_144(MethodBind10, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsRunning, 2240911060ul);

    /// <summary>
    /// <para>Returns whether the <see cref="Godot.Tween"/> is currently running, i.e. it wasn't paused and it's not finished.</para>
    /// </summary>
    public bool IsRunning()
    {
        return NativeCalls.godot_icall_0_15(MethodBind11, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsValid, 2240911060ul);

    /// <summary>
    /// <para>Returns whether the <see cref="Godot.Tween"/> is valid. A valid <see cref="Godot.Tween"/> is a <see cref="Godot.Tween"/> contained by the scene tree (i.e. the array from <see cref="Godot.SceneTree.GetProcessedTweens()"/> will contain this <see cref="Godot.Tween"/>). A <see cref="Godot.Tween"/> might become invalid when it has finished tweening, is killed, or when created with <c>Tween.new()</c>. Invalid <see cref="Godot.Tween"/>s can't have <see cref="Godot.Tweener"/>s appended.</para>
    /// </summary>
    public bool IsValid()
    {
        return NativeCalls.godot_icall_0_15(MethodBind12, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BindNode, 2946786331ul);

    /// <summary>
    /// <para>Binds this <see cref="Godot.Tween"/> with the given <paramref name="node"/>. <see cref="Godot.Tween"/>s are processed directly by the <see cref="Godot.SceneTree"/>, so they run independently of the animated nodes. When you bind a <see cref="Godot.Node"/> with the <see cref="Godot.Tween"/>, the <see cref="Godot.Tween"/> will halt the animation when the object is not inside tree and the <see cref="Godot.Tween"/> will be automatically killed when the bound object is freed. Also <see cref="Godot.Tween.TweenPauseMode.Bound"/> will make the pausing behavior dependent on the bound node.</para>
    /// <para>For a shorter way to create and bind a <see cref="Godot.Tween"/>, you can use <see cref="Godot.Node.CreateTween()"/>.</para>
    /// </summary>
    public Tween BindNode(Node node)
    {
        return (Tween)NativeCalls.godot_icall_1_268(MethodBind13, GodotObject.GetPtr(this), GodotObject.GetPtr(node));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetProcessMode, 855258840ul);

    /// <summary>
    /// <para>Determines whether the <see cref="Godot.Tween"/> should run after process frames (see <see cref="Godot.Node._Process(double)"/>) or physics frames (see <see cref="Godot.Node._PhysicsProcess(double)"/>).</para>
    /// <para>Default value is <see cref="Godot.Tween.TweenProcessMode.Idle"/>.</para>
    /// </summary>
    public Tween SetProcessMode(Tween.TweenProcessMode mode)
    {
        return (Tween)NativeCalls.godot_icall_1_71(MethodBind14, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPauseMode, 3363368837ul);

    /// <summary>
    /// <para>Determines the behavior of the <see cref="Godot.Tween"/> when the <see cref="Godot.SceneTree"/> is paused.</para>
    /// <para>Default value is <see cref="Godot.Tween.TweenPauseMode.Bound"/>.</para>
    /// </summary>
    public Tween SetPauseMode(Tween.TweenPauseMode mode)
    {
        return (Tween)NativeCalls.godot_icall_1_71(MethodBind15, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetIgnoreTimeScale, 1942052223ul);

    /// <summary>
    /// <para>If <paramref name="ignore"/> is <see langword="true"/>, the tween will ignore <see cref="Godot.Engine.TimeScale"/> and update with the real, elapsed time. This affects all <see cref="Godot.Tweener"/>s and their delays. Default value is <see langword="false"/>.</para>
    /// </summary>
    public Tween SetIgnoreTimeScale(bool ignore = true)
    {
        return (Tween)NativeCalls.godot_icall_1_654(MethodBind16, GodotObject.GetPtr(this), ignore.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetParallel, 1942052223ul);

    /// <summary>
    /// <para>If <paramref name="parallel"/> is <see langword="true"/>, the <see cref="Godot.Tweener"/>s appended after this method will by default run simultaneously, as opposed to sequentially.</para>
    /// <para><b>Note:</b> Just like with <see cref="Godot.Tween.Parallel()"/>, the tweener added right before this method will also be part of the parallel step.</para>
    /// <para><code>
    /// tween.tween_property(self, "position", Vector2(300, 0), 0.5)
    /// tween.set_parallel()
    /// tween.tween_property(self, "modulate", Color.GREEN, 0.5) # Runs together with the position tweener.
    /// </code></para>
    /// </summary>
    public Tween SetParallel(bool parallel = true)
    {
        return (Tween)NativeCalls.godot_icall_1_654(MethodBind17, GodotObject.GetPtr(this), parallel.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLoops, 2670836414ul);

    /// <summary>
    /// <para>Sets the number of times the tweening sequence will be repeated, i.e. <c>set_loops(2)</c> will run the animation twice.</para>
    /// <para>Calling this method without arguments will make the <see cref="Godot.Tween"/> run infinitely, until either it is killed with <see cref="Godot.Tween.Kill()"/>, the <see cref="Godot.Tween"/>'s bound node is freed, or all the animated objects have been freed (which makes further animation impossible).</para>
    /// <para><b>Warning:</b> Make sure to always add some duration/delay when using infinite loops. To prevent the game freezing, 0-duration looped animations (e.g. a single <see cref="Godot.CallbackTweener"/> with no delay) are stopped after a small number of loops, which may produce unexpected results. If a <see cref="Godot.Tween"/>'s lifetime depends on some node, always use <see cref="Godot.Tween.BindNode(Node)"/>.</para>
    /// </summary>
    public Tween SetLoops(int loops = 0)
    {
        return (Tween)NativeCalls.godot_icall_1_71(MethodBind18, GodotObject.GetPtr(this), loops);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLoopsLeft, 3905245786ul);

    /// <summary>
    /// <para>Returns the number of remaining loops for this <see cref="Godot.Tween"/> (see <see cref="Godot.Tween.SetLoops(int)"/>). A return value of <c>-1</c> indicates an infinitely looping <see cref="Godot.Tween"/>, and a return value of <c>0</c> indicates that the <see cref="Godot.Tween"/> has already finished.</para>
    /// </summary>
    public int GetLoopsLeft()
    {
        return NativeCalls.godot_icall_0_39(MethodBind19, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSpeedScale, 3961971106ul);

    /// <summary>
    /// <para>Scales the speed of tweening. This affects all <see cref="Godot.Tweener"/>s and their delays.</para>
    /// </summary>
    public Tween SetSpeedScale(float speed)
    {
        return (Tween)NativeCalls.godot_icall_1_791(MethodBind20, GodotObject.GetPtr(this), speed);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTrans, 3965963875ul);

    /// <summary>
    /// <para>Sets the default transition type for <see cref="Godot.PropertyTweener"/>s and <see cref="Godot.MethodTweener"/>s appended after this method.</para>
    /// <para>Before this method is called, the default transition type is <see cref="Godot.Tween.TransitionType.Linear"/>.</para>
    /// <para><code>
    /// var tween = create_tween()
    /// tween.tween_property(self, "position", Vector2(300, 0), 0.5) # Uses TRANS_LINEAR.
    /// tween.set_trans(Tween.TRANS_SINE)
    /// tween.tween_property(self, "rotation_degrees", 45.0, 0.5) # Uses TRANS_SINE.
    /// </code></para>
    /// </summary>
    public Tween SetTrans(Tween.TransitionType trans)
    {
        return (Tween)NativeCalls.godot_icall_1_71(MethodBind21, GodotObject.GetPtr(this), (int)trans);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEase, 1208117252ul);

    /// <summary>
    /// <para>Sets the default ease type for <see cref="Godot.PropertyTweener"/>s and <see cref="Godot.MethodTweener"/>s appended after this method.</para>
    /// <para>Before this method is called, the default ease type is <see cref="Godot.Tween.EaseType.InOut"/>.</para>
    /// <para><code>
    /// var tween = create_tween()
    /// tween.tween_property(self, "position", Vector2(300, 0), 0.5) # Uses EASE_IN_OUT.
    /// tween.set_ease(Tween.EASE_IN)
    /// tween.tween_property(self, "rotation_degrees", 45.0, 0.5) # Uses EASE_IN.
    /// </code></para>
    /// </summary>
    public Tween SetEase(Tween.EaseType ease)
    {
        return (Tween)NativeCalls.godot_icall_1_71(MethodBind22, GodotObject.GetPtr(this), (int)ease);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Parallel, 3426978995ul);

    /// <summary>
    /// <para>Makes the next <see cref="Godot.Tweener"/> run parallelly to the previous one.</para>
    /// <para><code>
    /// Tween tween = CreateTween();
    /// tween.TweenProperty(...);
    /// tween.Parallel().TweenProperty(...);
    /// tween.Parallel().TweenProperty(...);
    /// </code></para>
    /// <para>All <see cref="Godot.Tweener"/>s in the example will run at the same time.</para>
    /// <para>You can make the <see cref="Godot.Tween"/> parallel by default by using <see cref="Godot.Tween.SetParallel(bool)"/>.</para>
    /// </summary>
    public Tween Parallel()
    {
        return (Tween)NativeCalls.godot_icall_0_63(MethodBind23, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Chain, 3426978995ul);

    /// <summary>
    /// <para>Used to chain two <see cref="Godot.Tweener"/>s after <see cref="Godot.Tween.SetParallel(bool)"/> is called with <see langword="true"/>.</para>
    /// <para><code>
    /// Tween tween = CreateTween().SetParallel(true);
    /// tween.TweenProperty(...);
    /// tween.TweenProperty(...); // Will run parallelly with above.
    /// tween.Chain().TweenProperty(...); // Will run after two above are finished.
    /// </code></para>
    /// </summary>
    public Tween Chain()
    {
        return (Tween)NativeCalls.godot_icall_0_63(MethodBind24, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.InterpolateValue, 3452526450ul);

    /// <summary>
    /// <para>This method can be used for manual interpolation of a value, when you don't want <see cref="Godot.Tween"/> to do animating for you. It's similar to <c>@GlobalScope.lerp</c>, but with support for custom transition and easing.</para>
    /// <para><paramref name="initialValue"/> is the starting value of the interpolation.</para>
    /// <para><paramref name="deltaValue"/> is the change of the value in the interpolation, i.e. it's equal to <c>final_value - initial_value</c>.</para>
    /// <para><paramref name="elapsedTime"/> is the time in seconds that passed after the interpolation started and it's used to control the position of the interpolation. E.g. when it's equal to half of the <paramref name="duration"/>, the interpolated value will be halfway between initial and final values. This value can also be greater than <paramref name="duration"/> or lower than 0, which will extrapolate the value.</para>
    /// <para><paramref name="duration"/> is the total time of the interpolation.</para>
    /// <para><b>Note:</b> If <paramref name="duration"/> is equal to <c>0</c>, the method will always return the final value, regardless of <paramref name="elapsedTime"/> provided.</para>
    /// </summary>
    public static Variant InterpolateValue(Variant initialValue, Variant deltaValue, double elapsedTime, double duration, Tween.TransitionType transType, Tween.EaseType easeType)
    {
        return NativeCalls.godot_icall_6_1486(MethodBind25, initialValue, deltaValue, elapsedTime, duration, (int)transType, (int)easeType);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.Tween.StepFinished"/> event of a <see cref="Godot.Tween"/> class.
    /// </summary>
    public delegate void StepFinishedEventHandler(long idx);

    private static void StepFinishedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((StepFinishedEventHandler)delegateObj)(VariantUtils.ConvertTo<long>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when one step of the <see cref="Godot.Tween"/> is complete, providing the step index. One step is either a single <see cref="Godot.Tweener"/> or a group of <see cref="Godot.Tweener"/>s running in parallel.</para>
    /// </summary>
    public unsafe event StepFinishedEventHandler StepFinished
    {
        add => Connect(SignalName.StepFinished, Callable.CreateWithUnsafeTrampoline(value, &StepFinishedTrampoline));
        remove => Disconnect(SignalName.StepFinished, Callable.CreateWithUnsafeTrampoline(value, &StepFinishedTrampoline));
    }

    protected void EmitSignalStepFinished(long idx)
    {
        EmitSignal(SignalName.StepFinished, idx);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.Tween.LoopFinished"/> event of a <see cref="Godot.Tween"/> class.
    /// </summary>
    public delegate void LoopFinishedEventHandler(long loopCount);

    private static void LoopFinishedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((LoopFinishedEventHandler)delegateObj)(VariantUtils.ConvertTo<long>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when a full loop is complete (see <see cref="Godot.Tween.SetLoops(int)"/>), providing the loop index. This signal is not emitted after the final loop, use <see cref="Godot.Tween.Finished"/> instead for this case.</para>
    /// </summary>
    public unsafe event LoopFinishedEventHandler LoopFinished
    {
        add => Connect(SignalName.LoopFinished, Callable.CreateWithUnsafeTrampoline(value, &LoopFinishedTrampoline));
        remove => Disconnect(SignalName.LoopFinished, Callable.CreateWithUnsafeTrampoline(value, &LoopFinishedTrampoline));
    }

    protected void EmitSignalLoopFinished(long loopCount)
    {
        EmitSignal(SignalName.LoopFinished, loopCount);
    }

    /// <summary>
    /// <para>Emitted when the <see cref="Godot.Tween"/> has finished all tweening. Never emitted when the <see cref="Godot.Tween"/> is set to infinite looping (see <see cref="Godot.Tween.SetLoops(int)"/>).</para>
    /// </summary>
    public event Action Finished
    {
        add => Connect(SignalName.Finished, Callable.From(value));
        remove => Disconnect(SignalName.Finished, Callable.From(value));
    }

    protected void EmitSignalFinished()
    {
        EmitSignal(SignalName.Finished);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_step_finished = "StepFinished";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_loop_finished = "LoopFinished";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_finished = "Finished";

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
        if (signal == SignalName.StepFinished)
        {
            if (HasGodotClassSignal(SignalProxyName_step_finished.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.LoopFinished)
        {
            if (HasGodotClassSignal(SignalProxyName_loop_finished.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.Finished)
        {
            if (HasGodotClassSignal(SignalProxyName_finished.NativeValue.DangerousSelfRef))
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
        /// Cached name for the 'tween_property' method.
        /// </summary>
        public static readonly StringName TweenProperty = "tween_property";
        /// <summary>
        /// Cached name for the 'tween_interval' method.
        /// </summary>
        public static readonly StringName TweenInterval = "tween_interval";
        /// <summary>
        /// Cached name for the 'tween_callback' method.
        /// </summary>
        public static readonly StringName TweenCallback = "tween_callback";
        /// <summary>
        /// Cached name for the 'tween_method' method.
        /// </summary>
        public static readonly StringName TweenMethod = "tween_method";
        /// <summary>
        /// Cached name for the 'tween_subtween' method.
        /// </summary>
        public static readonly StringName TweenSubtween = "tween_subtween";
        /// <summary>
        /// Cached name for the 'custom_step' method.
        /// </summary>
        public static readonly StringName CustomStep = "custom_step";
        /// <summary>
        /// Cached name for the 'stop' method.
        /// </summary>
        public static readonly StringName Stop = "stop";
        /// <summary>
        /// Cached name for the 'pause' method.
        /// </summary>
        public static readonly StringName Pause = "pause";
        /// <summary>
        /// Cached name for the 'play' method.
        /// </summary>
        public static readonly StringName Play = "play";
        /// <summary>
        /// Cached name for the 'kill' method.
        /// </summary>
        public static readonly StringName Kill = "kill";
        /// <summary>
        /// Cached name for the 'get_total_elapsed_time' method.
        /// </summary>
        public static readonly StringName GetTotalElapsedTime = "get_total_elapsed_time";
        /// <summary>
        /// Cached name for the 'is_running' method.
        /// </summary>
        public static readonly StringName IsRunning = "is_running";
        /// <summary>
        /// Cached name for the 'is_valid' method.
        /// </summary>
        public static readonly StringName IsValid = "is_valid";
        /// <summary>
        /// Cached name for the 'bind_node' method.
        /// </summary>
        public static readonly StringName BindNode = "bind_node";
        /// <summary>
        /// Cached name for the 'set_process_mode' method.
        /// </summary>
        public static readonly StringName SetProcessMode = "set_process_mode";
        /// <summary>
        /// Cached name for the 'set_pause_mode' method.
        /// </summary>
        public static readonly StringName SetPauseMode = "set_pause_mode";
        /// <summary>
        /// Cached name for the 'set_ignore_time_scale' method.
        /// </summary>
        public static readonly StringName SetIgnoreTimeScale = "set_ignore_time_scale";
        /// <summary>
        /// Cached name for the 'set_parallel' method.
        /// </summary>
        public static readonly StringName SetParallel = "set_parallel";
        /// <summary>
        /// Cached name for the 'set_loops' method.
        /// </summary>
        public static readonly StringName SetLoops = "set_loops";
        /// <summary>
        /// Cached name for the 'get_loops_left' method.
        /// </summary>
        public static readonly StringName GetLoopsLeft = "get_loops_left";
        /// <summary>
        /// Cached name for the 'set_speed_scale' method.
        /// </summary>
        public static readonly StringName SetSpeedScale = "set_speed_scale";
        /// <summary>
        /// Cached name for the 'set_trans' method.
        /// </summary>
        public static readonly StringName SetTrans = "set_trans";
        /// <summary>
        /// Cached name for the 'set_ease' method.
        /// </summary>
        public static readonly StringName SetEase = "set_ease";
        /// <summary>
        /// Cached name for the 'parallel' method.
        /// </summary>
        public static readonly StringName Parallel = "parallel";
        /// <summary>
        /// Cached name for the 'chain' method.
        /// </summary>
        public static readonly StringName Chain = "chain";
        /// <summary>
        /// Cached name for the 'interpolate_value' method.
        /// </summary>
        public static readonly StringName InterpolateValue = "interpolate_value";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : RefCounted.SignalName
    {
        /// <summary>
        /// Cached name for the 'step_finished' signal.
        /// </summary>
        public static readonly StringName StepFinished = "step_finished";
        /// <summary>
        /// Cached name for the 'loop_finished' signal.
        /// </summary>
        public static readonly StringName LoopFinished = "loop_finished";
        /// <summary>
        /// Cached name for the 'finished' signal.
        /// </summary>
        public static readonly StringName Finished = "finished";
    }
}
