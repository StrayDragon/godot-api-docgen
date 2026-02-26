namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para><see cref="Godot.AnimatedSprite2D"/> is similar to the <see cref="Godot.Sprite2D"/> node, except it carries multiple textures as animation frames. Animations are created using a <see cref="Godot.SpriteFrames"/> resource, which allows you to import image files (or a folder containing said files) to provide the animation frames for the sprite. The <see cref="Godot.SpriteFrames"/> resource can be configured in the editor via the SpriteFrames bottom panel.</para>
/// </summary>
public partial class AnimatedSprite2D : Node2D
{
    /// <summary>
    /// <para>The <see cref="Godot.SpriteFrames"/> resource containing the animation(s). Allows you the option to load, edit, clear, make unique and save the states of the <see cref="Godot.SpriteFrames"/> resource.</para>
    /// </summary>
    public SpriteFrames SpriteFrames
    {
        get
        {
            return GetSpriteFrames();
        }
        set
        {
            SetSpriteFrames(value);
        }
    }

    /// <summary>
    /// <para>The current animation from the <see cref="Godot.AnimatedSprite2D.SpriteFrames"/> resource. If this value is changed, the <see cref="Godot.AnimatedSprite2D.Frame"/> counter and the <see cref="Godot.AnimatedSprite2D.FrameProgress"/> are reset.</para>
    /// </summary>
    public StringName Animation
    {
        get
        {
            return GetAnimation();
        }
        set
        {
            SetAnimation(value);
        }
    }

    /// <summary>
    /// <para>The key of the animation to play when the scene loads.</para>
    /// </summary>
    public string Autoplay
    {
        get
        {
            return GetAutoplay();
        }
        set
        {
            SetAutoplay(value);
        }
    }

    /// <summary>
    /// <para>The displayed animation frame's index. Setting this property also resets <see cref="Godot.AnimatedSprite2D.FrameProgress"/>. If this is not desired, use <see cref="Godot.AnimatedSprite2D.SetFrameAndProgress(int, float)"/>.</para>
    /// </summary>
    public int Frame
    {
        get
        {
            return GetFrame();
        }
        set
        {
            SetFrame(value);
        }
    }

    /// <summary>
    /// <para>The progress value between <c>0.0</c> and <c>1.0</c> until the current frame transitions to the next frame. If the animation is playing backwards, the value transitions from <c>1.0</c> to <c>0.0</c>.</para>
    /// </summary>
    public float FrameProgress
    {
        get
        {
            return GetFrameProgress();
        }
        set
        {
            SetFrameProgress(value);
        }
    }

    /// <summary>
    /// <para>The speed scaling ratio. For example, if this value is <c>1</c>, then the animation plays at normal speed. If it's <c>0.5</c>, then it plays at half speed. If it's <c>2</c>, then it plays at double speed.</para>
    /// <para>If set to a negative value, the animation is played in reverse. If set to <c>0</c>, the animation will not advance.</para>
    /// </summary>
    public float SpeedScale
    {
        get
        {
            return GetSpeedScale();
        }
        set
        {
            SetSpeedScale(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, texture will be centered.</para>
    /// <para><b>Note:</b> For games with a pixel art aesthetic, textures may appear deformed when centered. This is caused by their position being between pixels. To prevent this, set this property to <see langword="false"/>, or consider enabling <c>ProjectSettings.rendering/2d/snap/snap_2d_vertices_to_pixel</c> and <c>ProjectSettings.rendering/2d/snap/snap_2d_transforms_to_pixel</c>.</para>
    /// </summary>
    public bool Centered
    {
        get
        {
            return IsCentered();
        }
        set
        {
            SetCentered(value);
        }
    }

    /// <summary>
    /// <para>The texture's drawing offset.</para>
    /// </summary>
    public Vector2 Offset
    {
        get
        {
            return GetOffset();
        }
        set
        {
            SetOffset(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, texture is flipped horizontally.</para>
    /// </summary>
    public bool FlipH
    {
        get
        {
            return IsFlippedH();
        }
        set
        {
            SetFlipH(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, texture is flipped vertically.</para>
    /// </summary>
    public bool FlipV
    {
        get
        {
            return IsFlippedV();
        }
        set
        {
            SetFlipV(value);
        }
    }

    private static readonly System.Type CachedType = typeof(AnimatedSprite2D);

    private static readonly StringName NativeName = "AnimatedSprite2D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public AnimatedSprite2D() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal AnimatedSprite2D(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal AnimatedSprite2D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSpriteFrames, 905781144ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSpriteFrames(SpriteFrames spriteFrames)
    {
        NativeCalls.godot_icall_1_56(MethodBind0, GodotObject.GetPtr(this), GodotObject.GetPtr(spriteFrames));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSpriteFrames, 3804851214ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public SpriteFrames GetSpriteFrames()
    {
        return (SpriteFrames)NativeCalls.godot_icall_0_63(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAnimation, 3304788590ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAnimation(StringName name)
    {
        NativeCalls.godot_icall_1_64(MethodBind2, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAnimation, 2002593661ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public StringName GetAnimation()
    {
        return NativeCalls.godot_icall_0_65(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAutoplay, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAutoplay(string name)
    {
        NativeCalls.godot_icall_1_57(MethodBind4, GodotObject.GetPtr(this), name);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAutoplay, 201670096ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetAutoplay()
    {
        return NativeCalls.godot_icall_0_58(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsPlaying, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if an animation is currently playing (even if <see cref="Godot.AnimatedSprite2D.SpeedScale"/> and/or <c>custom_speed</c> are <c>0</c>).</para>
    /// </summary>
    public bool IsPlaying()
    {
        return NativeCalls.godot_icall_0_15(MethodBind6, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Play, 3269405555ul);

    /// <summary>
    /// <para>Plays the animation with key <paramref name="name"/>. If <paramref name="customSpeed"/> is negative and <paramref name="fromEnd"/> is <see langword="true"/>, the animation will play backwards (which is equivalent to calling <see cref="Godot.AnimatedSprite2D.PlayBackwards(StringName)"/>).</para>
    /// <para>If this method is called with that same animation <paramref name="name"/>, or with no <paramref name="name"/> parameter, the assigned animation will resume playing if it was paused.</para>
    /// </summary>
    public void Play(StringName name = null, float customSpeed = 1.0f, bool fromEnd = false)
    {
        NativeCalls.godot_icall_3_66(MethodBind7, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default), customSpeed, fromEnd.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PlayBackwards, 3323268493ul);

    /// <summary>
    /// <para>Plays the animation with key <paramref name="name"/> in reverse.</para>
    /// <para>This method is a shorthand for <see cref="Godot.AnimatedSprite2D.Play(StringName, float, bool)"/> with <c>custom_speed = -1.0</c> and <c>from_end = true</c>, so see its description for more information.</para>
    /// </summary>
    public void PlayBackwards(StringName name = null)
    {
        NativeCalls.godot_icall_1_64(MethodBind8, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Pause, 3218959716ul);

    /// <summary>
    /// <para>Pauses the currently playing animation. The <see cref="Godot.AnimatedSprite2D.Frame"/> and <see cref="Godot.AnimatedSprite2D.FrameProgress"/> will be kept and calling <see cref="Godot.AnimatedSprite2D.Play(StringName, float, bool)"/> or <see cref="Godot.AnimatedSprite2D.PlayBackwards(StringName)"/> without arguments will resume the animation from the current playback position.</para>
    /// <para>See also <see cref="Godot.AnimatedSprite2D.Stop()"/>.</para>
    /// </summary>
    public void Pause()
    {
        NativeCalls.godot_icall_0_3(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Stop, 3218959716ul);

    /// <summary>
    /// <para>Stops the currently playing animation. The animation position is reset to <c>0</c> and the <c>custom_speed</c> is reset to <c>1.0</c>. See also <see cref="Godot.AnimatedSprite2D.Pause()"/>.</para>
    /// </summary>
    public void Stop()
    {
        NativeCalls.godot_icall_0_3(MethodBind10, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCentered, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCentered(bool centered)
    {
        NativeCalls.godot_icall_1_14(MethodBind11, GodotObject.GetPtr(this), centered.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsCentered, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsCentered()
    {
        return NativeCalls.godot_icall_0_15(MethodBind12, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetOffset, 743155724ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetOffset(Vector2 offset)
    {
        NativeCalls.godot_icall_1_36(MethodBind13, GodotObject.GetPtr(this), &offset);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOffset, 3341600327ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2 GetOffset()
    {
        return NativeCalls.godot_icall_0_37(MethodBind14, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFlipH, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFlipH(bool flipH)
    {
        NativeCalls.godot_icall_1_14(MethodBind15, GodotObject.GetPtr(this), flipH.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsFlippedH, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsFlippedH()
    {
        return NativeCalls.godot_icall_0_15(MethodBind16, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFlipV, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFlipV(bool flipV)
    {
        NativeCalls.godot_icall_1_14(MethodBind17, GodotObject.GetPtr(this), flipV.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsFlippedV, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsFlippedV()
    {
        return NativeCalls.godot_icall_0_15(MethodBind18, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFrame, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFrame(int frame)
    {
        NativeCalls.godot_icall_1_38(MethodBind19, GodotObject.GetPtr(this), frame);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFrame, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetFrame()
    {
        return NativeCalls.godot_icall_0_39(MethodBind20, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFrameProgress, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFrameProgress(float progress)
    {
        NativeCalls.godot_icall_1_67(MethodBind21, GodotObject.GetPtr(this), progress);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFrameProgress, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetFrameProgress()
    {
        return NativeCalls.godot_icall_0_68(MethodBind22, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFrameAndProgress, 1602489585ul);

    /// <summary>
    /// <para>Sets <see cref="Godot.AnimatedSprite2D.Frame"/> and <see cref="Godot.AnimatedSprite2D.FrameProgress"/> to the given values. Unlike setting <see cref="Godot.AnimatedSprite2D.Frame"/>, this method does not reset the <see cref="Godot.AnimatedSprite2D.FrameProgress"/> to <c>0.0</c> implicitly.</para>
    /// <para><b>Example:</b> Change the animation while keeping the same <see cref="Godot.AnimatedSprite2D.Frame"/> and <see cref="Godot.AnimatedSprite2D.FrameProgress"/>:</para>
    /// <para></para>
    /// </summary>
    public void SetFrameAndProgress(int frame, float progress)
    {
        NativeCalls.godot_icall_2_69(MethodBind23, GodotObject.GetPtr(this), frame, progress);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSpeedScale, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSpeedScale(float speedScale)
    {
        NativeCalls.godot_icall_1_67(MethodBind24, GodotObject.GetPtr(this), speedScale);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSpeedScale, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetSpeedScale()
    {
        return NativeCalls.godot_icall_0_68(MethodBind25, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPlayingSpeed, 1740695150ul);

    /// <summary>
    /// <para>Returns the actual playing speed of current animation or <c>0</c> if not playing. This speed is the <see cref="Godot.AnimatedSprite2D.SpeedScale"/> property multiplied by <c>custom_speed</c> argument specified when calling the <see cref="Godot.AnimatedSprite2D.Play(StringName, float, bool)"/> method.</para>
    /// <para>Returns a negative value if the current animation is playing backwards.</para>
    /// </summary>
    public float GetPlayingSpeed()
    {
        return NativeCalls.godot_icall_0_68(MethodBind26, GodotObject.GetPtr(this));
    }

    /// <summary>
    /// <para>Emitted when <see cref="Godot.AnimatedSprite2D.SpriteFrames"/> changes.</para>
    /// </summary>
    public event Action SpriteFramesChanged
    {
        add => Connect(SignalName.SpriteFramesChanged, Callable.From(value));
        remove => Disconnect(SignalName.SpriteFramesChanged, Callable.From(value));
    }

    protected void EmitSignalSpriteFramesChanged()
    {
        EmitSignal(SignalName.SpriteFramesChanged);
    }

    /// <summary>
    /// <para>Emitted when <see cref="Godot.AnimatedSprite2D.Animation"/> changes.</para>
    /// </summary>
    public event Action AnimationChanged
    {
        add => Connect(SignalName.AnimationChanged, Callable.From(value));
        remove => Disconnect(SignalName.AnimationChanged, Callable.From(value));
    }

    protected void EmitSignalAnimationChanged()
    {
        EmitSignal(SignalName.AnimationChanged);
    }

    /// <summary>
    /// <para>Emitted when <see cref="Godot.AnimatedSprite2D.Frame"/> changes.</para>
    /// </summary>
    public event Action FrameChanged
    {
        add => Connect(SignalName.FrameChanged, Callable.From(value));
        remove => Disconnect(SignalName.FrameChanged, Callable.From(value));
    }

    protected void EmitSignalFrameChanged()
    {
        EmitSignal(SignalName.FrameChanged);
    }

    /// <summary>
    /// <para>Emitted when the animation loops.</para>
    /// </summary>
    public event Action AnimationLooped
    {
        add => Connect(SignalName.AnimationLooped, Callable.From(value));
        remove => Disconnect(SignalName.AnimationLooped, Callable.From(value));
    }

    protected void EmitSignalAnimationLooped()
    {
        EmitSignal(SignalName.AnimationLooped);
    }

    /// <summary>
    /// <para>Emitted when the animation reaches the end, or the start if it is played in reverse. When the animation finishes, it pauses the playback.</para>
    /// <para><b>Note:</b> This signal is not emitted if an animation is looping.</para>
    /// </summary>
    public event Action AnimationFinished
    {
        add => Connect(SignalName.AnimationFinished, Callable.From(value));
        remove => Disconnect(SignalName.AnimationFinished, Callable.From(value));
    }

    protected void EmitSignalAnimationFinished()
    {
        EmitSignal(SignalName.AnimationFinished);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_sprite_frames_changed = "SpriteFramesChanged";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_animation_changed = "AnimationChanged";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_frame_changed = "FrameChanged";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_animation_looped = "AnimationLooped";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_animation_finished = "AnimationFinished";

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
        if (signal == SignalName.SpriteFramesChanged)
        {
            if (HasGodotClassSignal(SignalProxyName_sprite_frames_changed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.AnimationChanged)
        {
            if (HasGodotClassSignal(SignalProxyName_animation_changed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.FrameChanged)
        {
            if (HasGodotClassSignal(SignalProxyName_frame_changed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.AnimationLooped)
        {
            if (HasGodotClassSignal(SignalProxyName_animation_looped.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.AnimationFinished)
        {
            if (HasGodotClassSignal(SignalProxyName_animation_finished.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        return base.HasGodotClassSignal(signal);
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : Node2D.PropertyName
    {
        /// <summary>
        /// Cached name for the 'sprite_frames' property.
        /// </summary>
        public static readonly StringName SpriteFrames = "sprite_frames";
        /// <summary>
        /// Cached name for the 'animation' property.
        /// </summary>
        public static readonly StringName Animation = "animation";
        /// <summary>
        /// Cached name for the 'autoplay' property.
        /// </summary>
        public static readonly StringName Autoplay = "autoplay";
        /// <summary>
        /// Cached name for the 'frame' property.
        /// </summary>
        public static readonly StringName Frame = "frame";
        /// <summary>
        /// Cached name for the 'frame_progress' property.
        /// </summary>
        public static readonly StringName FrameProgress = "frame_progress";
        /// <summary>
        /// Cached name for the 'speed_scale' property.
        /// </summary>
        public static readonly StringName SpeedScale = "speed_scale";
        /// <summary>
        /// Cached name for the 'centered' property.
        /// </summary>
        public static readonly StringName Centered = "centered";
        /// <summary>
        /// Cached name for the 'offset' property.
        /// </summary>
        public static readonly StringName Offset = "offset";
        /// <summary>
        /// Cached name for the 'flip_h' property.
        /// </summary>
        public static readonly StringName FlipH = "flip_h";
        /// <summary>
        /// Cached name for the 'flip_v' property.
        /// </summary>
        public static readonly StringName FlipV = "flip_v";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Node2D.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_sprite_frames' method.
        /// </summary>
        public static readonly StringName SetSpriteFrames = "set_sprite_frames";
        /// <summary>
        /// Cached name for the 'get_sprite_frames' method.
        /// </summary>
        public static readonly StringName GetSpriteFrames = "get_sprite_frames";
        /// <summary>
        /// Cached name for the 'set_animation' method.
        /// </summary>
        public static readonly StringName SetAnimation = "set_animation";
        /// <summary>
        /// Cached name for the 'get_animation' method.
        /// </summary>
        public static readonly StringName GetAnimation = "get_animation";
        /// <summary>
        /// Cached name for the 'set_autoplay' method.
        /// </summary>
        public static readonly StringName SetAutoplay = "set_autoplay";
        /// <summary>
        /// Cached name for the 'get_autoplay' method.
        /// </summary>
        public static readonly StringName GetAutoplay = "get_autoplay";
        /// <summary>
        /// Cached name for the 'is_playing' method.
        /// </summary>
        public static readonly StringName IsPlaying = "is_playing";
        /// <summary>
        /// Cached name for the 'play' method.
        /// </summary>
        public static readonly StringName Play = "play";
        /// <summary>
        /// Cached name for the 'play_backwards' method.
        /// </summary>
        public static readonly StringName PlayBackwards = "play_backwards";
        /// <summary>
        /// Cached name for the 'pause' method.
        /// </summary>
        public static readonly StringName Pause = "pause";
        /// <summary>
        /// Cached name for the 'stop' method.
        /// </summary>
        public static readonly StringName Stop = "stop";
        /// <summary>
        /// Cached name for the 'set_centered' method.
        /// </summary>
        public static readonly StringName SetCentered = "set_centered";
        /// <summary>
        /// Cached name for the 'is_centered' method.
        /// </summary>
        public static readonly StringName IsCentered = "is_centered";
        /// <summary>
        /// Cached name for the 'set_offset' method.
        /// </summary>
        public static readonly StringName SetOffset = "set_offset";
        /// <summary>
        /// Cached name for the 'get_offset' method.
        /// </summary>
        public static readonly StringName GetOffset = "get_offset";
        /// <summary>
        /// Cached name for the 'set_flip_h' method.
        /// </summary>
        public static readonly StringName SetFlipH = "set_flip_h";
        /// <summary>
        /// Cached name for the 'is_flipped_h' method.
        /// </summary>
        public static readonly StringName IsFlippedH = "is_flipped_h";
        /// <summary>
        /// Cached name for the 'set_flip_v' method.
        /// </summary>
        public static readonly StringName SetFlipV = "set_flip_v";
        /// <summary>
        /// Cached name for the 'is_flipped_v' method.
        /// </summary>
        public static readonly StringName IsFlippedV = "is_flipped_v";
        /// <summary>
        /// Cached name for the 'set_frame' method.
        /// </summary>
        public static readonly StringName SetFrame = "set_frame";
        /// <summary>
        /// Cached name for the 'get_frame' method.
        /// </summary>
        public static readonly StringName GetFrame = "get_frame";
        /// <summary>
        /// Cached name for the 'set_frame_progress' method.
        /// </summary>
        public static readonly StringName SetFrameProgress = "set_frame_progress";
        /// <summary>
        /// Cached name for the 'get_frame_progress' method.
        /// </summary>
        public static readonly StringName GetFrameProgress = "get_frame_progress";
        /// <summary>
        /// Cached name for the 'set_frame_and_progress' method.
        /// </summary>
        public static readonly StringName SetFrameAndProgress = "set_frame_and_progress";
        /// <summary>
        /// Cached name for the 'set_speed_scale' method.
        /// </summary>
        public static readonly StringName SetSpeedScale = "set_speed_scale";
        /// <summary>
        /// Cached name for the 'get_speed_scale' method.
        /// </summary>
        public static readonly StringName GetSpeedScale = "get_speed_scale";
        /// <summary>
        /// Cached name for the 'get_playing_speed' method.
        /// </summary>
        public static readonly StringName GetPlayingSpeed = "get_playing_speed";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Node2D.SignalName
    {
        /// <summary>
        /// Cached name for the 'sprite_frames_changed' signal.
        /// </summary>
        public static readonly StringName SpriteFramesChanged = "sprite_frames_changed";
        /// <summary>
        /// Cached name for the 'animation_changed' signal.
        /// </summary>
        public static readonly StringName AnimationChanged = "animation_changed";
        /// <summary>
        /// Cached name for the 'frame_changed' signal.
        /// </summary>
        public static readonly StringName FrameChanged = "frame_changed";
        /// <summary>
        /// Cached name for the 'animation_looped' signal.
        /// </summary>
        public static readonly StringName AnimationLooped = "animation_looped";
        /// <summary>
        /// Cached name for the 'animation_finished' signal.
        /// </summary>
        public static readonly StringName AnimationFinished = "animation_finished";
    }
}
