namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Sprite frame library for an <see cref="Godot.AnimatedSprite2D"/> or <see cref="Godot.AnimatedSprite3D"/> node. Contains frames and animation data for playback.</para>
/// </summary>
public partial class SpriteFrames : Resource
{
    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public Godot.Collections.Array Animations
    {
        get
        {
            return _GetAnimations();
        }
        set
        {
            _SetAnimations(value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    private static readonly System.Type CachedType = typeof(SpriteFrames);

    private static readonly StringName NativeName = "SpriteFrames";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public SpriteFrames() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal SpriteFrames(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal SpriteFrames(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddAnimation, 3304788590ul);

    /// <summary>
    /// <para>Adds a new <paramref name="anim"/> animation to the library.</para>
    /// </summary>
    public void AddAnimation(StringName anim)
    {
        NativeCalls.godot_icall_1_64(MethodBind0, GodotObject.GetPtr(this), (godot_string_name)(anim?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasAnimation, 2619796661ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the <paramref name="anim"/> animation exists.</para>
    /// </summary>
    public bool HasAnimation(StringName anim)
    {
        return NativeCalls.godot_icall_1_105(MethodBind1, GodotObject.GetPtr(this), (godot_string_name)(anim?.NativeValue ?? default)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DuplicateAnimation, 3740211285ul);

    /// <summary>
    /// <para>Duplicates the animation <paramref name="animFrom"/> to a new animation named <paramref name="animTo"/>. Fails if <paramref name="animTo"/> already exists, or if <paramref name="animFrom"/> does not exist.</para>
    /// </summary>
    public void DuplicateAnimation(StringName animFrom, StringName animTo)
    {
        NativeCalls.godot_icall_2_118(MethodBind2, GodotObject.GetPtr(this), (godot_string_name)(animFrom?.NativeValue ?? default), (godot_string_name)(animTo?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveAnimation, 3304788590ul);

    /// <summary>
    /// <para>Removes the <paramref name="anim"/> animation.</para>
    /// </summary>
    public void RemoveAnimation(StringName anim)
    {
        NativeCalls.godot_icall_1_64(MethodBind3, GodotObject.GetPtr(this), (godot_string_name)(anim?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RenameAnimation, 3740211285ul);

    /// <summary>
    /// <para>Changes the <paramref name="anim"/> animation's name to <paramref name="newname"/>.</para>
    /// </summary>
    public void RenameAnimation(StringName anim, StringName newname)
    {
        NativeCalls.godot_icall_2_118(MethodBind4, GodotObject.GetPtr(this), (godot_string_name)(anim?.NativeValue ?? default), (godot_string_name)(newname?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAnimationNames, 1139954409ul);

    /// <summary>
    /// <para>Returns an array containing the names associated to each animation. Values are placed in alphabetical order.</para>
    /// </summary>
    public string[] GetAnimationNames()
    {
        return NativeCalls.godot_icall_0_108(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAnimationSpeed, 4135858297ul);

    /// <summary>
    /// <para>Sets the speed for the <paramref name="anim"/> animation in frames per second.</para>
    /// </summary>
    public void SetAnimationSpeed(StringName anim, double fps)
    {
        NativeCalls.godot_icall_2_104(MethodBind6, GodotObject.GetPtr(this), (godot_string_name)(anim?.NativeValue ?? default), fps);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAnimationSpeed, 2349060816ul);

    /// <summary>
    /// <para>Returns the speed in frames per second for the <paramref name="anim"/> animation.</para>
    /// </summary>
    public double GetAnimationSpeed(StringName anim)
    {
        return NativeCalls.godot_icall_1_107(MethodBind7, GodotObject.GetPtr(this), (godot_string_name)(anim?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAnimationLoop, 2524380260ul);

    /// <summary>
    /// <para>If <paramref name="loop"/> is <see langword="true"/>, the <paramref name="anim"/> animation will loop when it reaches the end, or the start if it is played in reverse.</para>
    /// </summary>
    public void SetAnimationLoop(StringName anim, bool loop)
    {
        NativeCalls.godot_icall_2_163(MethodBind8, GodotObject.GetPtr(this), (godot_string_name)(anim?.NativeValue ?? default), loop.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAnimationLoop, 2619796661ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the given animation is configured to loop when it finishes playing. Otherwise, returns <see langword="false"/>.</para>
    /// </summary>
    public bool GetAnimationLoop(StringName anim)
    {
        return NativeCalls.godot_icall_1_105(MethodBind9, GodotObject.GetPtr(this), (godot_string_name)(anim?.NativeValue ?? default)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddFrame, 1351332740ul);

    /// <summary>
    /// <para>Adds a frame to the <paramref name="anim"/> animation. If <paramref name="atPosition"/> is <c>-1</c>, the frame will be added to the end of the animation. <paramref name="duration"/> specifies the relative duration, see <see cref="Godot.SpriteFrames.GetFrameDuration(StringName, int)"/> for details.</para>
    /// </summary>
    public void AddFrame(StringName anim, Texture2D texture, float duration = 1.0f, int atPosition = -1)
    {
        NativeCalls.godot_icall_4_1279(MethodBind10, GodotObject.GetPtr(this), (godot_string_name)(anim?.NativeValue ?? default), GodotObject.GetPtr(texture), duration, atPosition);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFrame, 56804795ul);

    /// <summary>
    /// <para>Sets the <paramref name="texture"/> and the <paramref name="duration"/> of the frame <paramref name="idx"/> in the <paramref name="anim"/> animation. <paramref name="duration"/> specifies the relative duration, see <see cref="Godot.SpriteFrames.GetFrameDuration(StringName, int)"/> for details.</para>
    /// </summary>
    public void SetFrame(StringName anim, int idx, Texture2D texture, float duration = 1.0f)
    {
        NativeCalls.godot_icall_4_1280(MethodBind11, GodotObject.GetPtr(this), (godot_string_name)(anim?.NativeValue ?? default), idx, GodotObject.GetPtr(texture), duration);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveFrame, 2415702435ul);

    /// <summary>
    /// <para>Removes the <paramref name="anim"/> animation's frame <paramref name="idx"/>.</para>
    /// </summary>
    public void RemoveFrame(StringName anim, int idx)
    {
        NativeCalls.godot_icall_2_154(MethodBind12, GodotObject.GetPtr(this), (godot_string_name)(anim?.NativeValue ?? default), idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFrameCount, 2458036349ul);

    /// <summary>
    /// <para>Returns the number of frames for the <paramref name="anim"/> animation.</para>
    /// </summary>
    public int GetFrameCount(StringName anim)
    {
        return NativeCalls.godot_icall_1_193(MethodBind13, GodotObject.GetPtr(this), (godot_string_name)(anim?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFrameTexture, 2900517879ul);

    /// <summary>
    /// <para>Returns the texture of the frame <paramref name="idx"/> in the <paramref name="anim"/> animation.</para>
    /// </summary>
    public Texture2D GetFrameTexture(StringName anim, int idx)
    {
        return (Texture2D)NativeCalls.godot_icall_2_1263(MethodBind14, GodotObject.GetPtr(this), (godot_string_name)(anim?.NativeValue ?? default), idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFrameDuration, 1129309260ul);

    /// <summary>
    /// <para>Returns a relative duration of the frame <paramref name="idx"/> in the <paramref name="anim"/> animation (defaults to <c>1.0</c>). For example, a frame with a duration of <c>2.0</c> is displayed twice as long as a frame with a duration of <c>1.0</c>. You can calculate the absolute duration (in seconds) of a frame using the following formula:</para>
    /// <para><code>
    /// absolute_duration = relative_duration / (animation_fps * abs(playing_speed))
    /// </code></para>
    /// <para>In this example, <c>playing_speed</c> refers to either <see cref="Godot.AnimatedSprite2D.GetPlayingSpeed()"/> or <see cref="Godot.AnimatedSprite3D.GetPlayingSpeed()"/>.</para>
    /// </summary>
    public float GetFrameDuration(StringName anim, int idx)
    {
        return NativeCalls.godot_icall_2_1281(MethodBind15, GodotObject.GetPtr(this), (godot_string_name)(anim?.NativeValue ?? default), idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Clear, 3304788590ul);

    /// <summary>
    /// <para>Removes all frames from the <paramref name="anim"/> animation.</para>
    /// </summary>
    public void Clear(StringName anim)
    {
        NativeCalls.godot_icall_1_64(MethodBind16, GodotObject.GetPtr(this), (godot_string_name)(anim?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ClearAll, 3218959716ul);

    /// <summary>
    /// <para>Removes all animations. An empty <c>default</c> animation will be created.</para>
    /// </summary>
    public void ClearAll()
    {
        NativeCalls.godot_icall_0_3(MethodBind17, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName._SetAnimations, 381264803ul);

    internal void _SetAnimations(Godot.Collections.Array animations)
    {
        NativeCalls.godot_icall_1_138(MethodBind18, GodotObject.GetPtr(this), (godot_array)(animations ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName._GetAnimations, 3995934104ul);

    internal Godot.Collections.Array _GetAnimations()
    {
        return NativeCalls.godot_icall_0_120(MethodBind19, GodotObject.GetPtr(this));
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
    public new class PropertyName : Resource.PropertyName
    {
        /// <summary>
        /// Cached name for the 'animations' property.
        /// </summary>
        public static readonly StringName Animations = "animations";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Resource.MethodName
    {
        /// <summary>
        /// Cached name for the 'add_animation' method.
        /// </summary>
        public static readonly StringName AddAnimation = "add_animation";
        /// <summary>
        /// Cached name for the 'has_animation' method.
        /// </summary>
        public static readonly StringName HasAnimation = "has_animation";
        /// <summary>
        /// Cached name for the 'duplicate_animation' method.
        /// </summary>
        public static readonly StringName DuplicateAnimation = "duplicate_animation";
        /// <summary>
        /// Cached name for the 'remove_animation' method.
        /// </summary>
        public static readonly StringName RemoveAnimation = "remove_animation";
        /// <summary>
        /// Cached name for the 'rename_animation' method.
        /// </summary>
        public static readonly StringName RenameAnimation = "rename_animation";
        /// <summary>
        /// Cached name for the 'get_animation_names' method.
        /// </summary>
        public static readonly StringName GetAnimationNames = "get_animation_names";
        /// <summary>
        /// Cached name for the 'set_animation_speed' method.
        /// </summary>
        public static readonly StringName SetAnimationSpeed = "set_animation_speed";
        /// <summary>
        /// Cached name for the 'get_animation_speed' method.
        /// </summary>
        public static readonly StringName GetAnimationSpeed = "get_animation_speed";
        /// <summary>
        /// Cached name for the 'set_animation_loop' method.
        /// </summary>
        public static readonly StringName SetAnimationLoop = "set_animation_loop";
        /// <summary>
        /// Cached name for the 'get_animation_loop' method.
        /// </summary>
        public static readonly StringName GetAnimationLoop = "get_animation_loop";
        /// <summary>
        /// Cached name for the 'add_frame' method.
        /// </summary>
        public static readonly StringName AddFrame = "add_frame";
        /// <summary>
        /// Cached name for the 'set_frame' method.
        /// </summary>
        public static readonly StringName SetFrame = "set_frame";
        /// <summary>
        /// Cached name for the 'remove_frame' method.
        /// </summary>
        public static readonly StringName RemoveFrame = "remove_frame";
        /// <summary>
        /// Cached name for the 'get_frame_count' method.
        /// </summary>
        public static readonly StringName GetFrameCount = "get_frame_count";
        /// <summary>
        /// Cached name for the 'get_frame_texture' method.
        /// </summary>
        public static readonly StringName GetFrameTexture = "get_frame_texture";
        /// <summary>
        /// Cached name for the 'get_frame_duration' method.
        /// </summary>
        public static readonly StringName GetFrameDuration = "get_frame_duration";
        /// <summary>
        /// Cached name for the 'clear' method.
        /// </summary>
        public static readonly StringName Clear = "clear";
        /// <summary>
        /// Cached name for the 'clear_all' method.
        /// </summary>
        public static readonly StringName ClearAll = "clear_all";
        /// <summary>
        /// Cached name for the '_set_animations' method.
        /// </summary>
        public static readonly StringName _SetAnimations = "_set_animations";
        /// <summary>
        /// Cached name for the '_get_animations' method.
        /// </summary>
        public static readonly StringName _GetAnimations = "_get_animations";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Resource.SignalName
    {
    }
}
