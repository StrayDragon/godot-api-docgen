namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para><see cref="Godot.AnimatedTexture"/> is a resource format for frame-based animations, where multiple textures can be chained automatically with a predefined delay for each frame. Unlike <see cref="Godot.AnimationPlayer"/> or <see cref="Godot.AnimatedSprite2D"/>, it isn't a <see cref="Godot.Node"/>, but has the advantage of being usable anywhere a <see cref="Godot.Texture2D"/> resource can be used, e.g. in a <see cref="Godot.TileSet"/>.</para>
/// <para>The playback of the animation is controlled by the <see cref="Godot.AnimatedTexture.SpeedScale"/> property, as well as each frame's duration (see <see cref="Godot.AnimatedTexture.SetFrameDuration(int, float)"/>). The animation loops, i.e. it will restart at frame 0 automatically after playing the last frame.</para>
/// <para><see cref="Godot.AnimatedTexture"/> currently requires all frame textures to have the same size, otherwise the bigger ones will be cropped to match the smallest one.</para>
/// <para><b>Note:</b> AnimatedTexture doesn't support using <see cref="Godot.AtlasTexture"/>s. Each frame needs to be a separate <see cref="Godot.Texture2D"/>.</para>
/// <para><b>Warning:</b> The current implementation is not efficient for the modern renderers.</para>
/// </summary>
[Obsolete("This class does not work properly in current versions and may be removed in the future. There is currently no equivalent workaround.")]
public partial class AnimatedTexture : Texture2D
{
    /// <summary>
    /// <para>The maximum number of frames supported by <see cref="Godot.AnimatedTexture"/>. If you need more frames in your animation, use <see cref="Godot.AnimationPlayer"/> or <see cref="Godot.AnimatedSprite2D"/>.</para>
    /// </summary>
    public const long MaxFrames = 256;

    /// <summary>
    /// <para>Number of frames to use in the animation. While you can create the frames independently with <see cref="Godot.AnimatedTexture.SetFrameTexture(int, Texture2D)"/>, you need to set this value for the animation to take new frames into account. The maximum number of frames is <see cref="Godot.AnimatedTexture.MaxFrames"/>.</para>
    /// </summary>
    public int Frames
    {
        get
        {
            return GetFrames();
        }
        set
        {
            SetFrames(value);
        }
    }

    /// <summary>
    /// <para>Sets the currently visible frame of the texture. Setting this frame while playing resets the current frame time, so the newly selected frame plays for its whole configured frame duration.</para>
    /// </summary>
    public int CurrentFrame
    {
        get
        {
            return GetCurrentFrame();
        }
        set
        {
            SetCurrentFrame(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the animation will pause where it currently is (i.e. at <see cref="Godot.AnimatedTexture.CurrentFrame"/>). The animation will continue from where it was paused when changing this property to <see langword="false"/>.</para>
    /// </summary>
    public bool Pause
    {
        get
        {
            return GetPause();
        }
        set
        {
            SetPause(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the animation will only play once and will not loop back to the first frame after reaching the end. Note that reaching the end will not set <see cref="Godot.AnimatedTexture.Pause"/> to <see langword="true"/>.</para>
    /// </summary>
    public bool OneShot
    {
        get
        {
            return GetOneShot();
        }
        set
        {
            SetOneShot(value);
        }
    }

    /// <summary>
    /// <para>The animation speed is multiplied by this value. If set to a negative value, the animation is played in reverse.</para>
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

    private static readonly System.Type CachedType = typeof(AnimatedTexture);

    private static readonly StringName NativeName = "AnimatedTexture";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public AnimatedTexture() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal AnimatedTexture(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal AnimatedTexture(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFrames, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFrames(int frames)
    {
        NativeCalls.godot_icall_1_38(MethodBind0, GodotObject.GetPtr(this), frames);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFrames, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetFrames()
    {
        return NativeCalls.godot_icall_0_39(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCurrentFrame, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCurrentFrame(int frame)
    {
        NativeCalls.godot_icall_1_38(MethodBind2, GodotObject.GetPtr(this), frame);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCurrentFrame, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetCurrentFrame()
    {
        return NativeCalls.godot_icall_0_39(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPause, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPause(bool pause)
    {
        NativeCalls.godot_icall_1_14(MethodBind4, GodotObject.GetPtr(this), pause.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPause, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetPause()
    {
        return NativeCalls.godot_icall_0_15(MethodBind5, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetOneShot, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetOneShot(bool oneShot)
    {
        NativeCalls.godot_icall_1_14(MethodBind6, GodotObject.GetPtr(this), oneShot.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOneShot, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetOneShot()
    {
        return NativeCalls.godot_icall_0_15(MethodBind7, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSpeedScale, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSpeedScale(float scale)
    {
        NativeCalls.godot_icall_1_67(MethodBind8, GodotObject.GetPtr(this), scale);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSpeedScale, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetSpeedScale()
    {
        return NativeCalls.godot_icall_0_68(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFrameTexture, 666127730ul);

    /// <summary>
    /// <para>Assigns a <see cref="Godot.Texture2D"/> to the given frame. Frame IDs start at 0, so the first frame has ID 0, and the last frame of the animation has ID <see cref="Godot.AnimatedTexture.Frames"/> - 1.</para>
    /// <para>You can define any number of textures up to <see cref="Godot.AnimatedTexture.MaxFrames"/>, but keep in mind that only frames from 0 to <see cref="Godot.AnimatedTexture.Frames"/> - 1 will be part of the animation.</para>
    /// </summary>
    public void SetFrameTexture(int frame, Texture2D texture)
    {
        NativeCalls.godot_icall_2_70(MethodBind10, GodotObject.GetPtr(this), frame, GodotObject.GetPtr(texture));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFrameTexture, 3536238170ul);

    /// <summary>
    /// <para>Returns the given frame's <see cref="Godot.Texture2D"/>.</para>
    /// </summary>
    public Texture2D GetFrameTexture(int frame)
    {
        return (Texture2D)NativeCalls.godot_icall_1_71(MethodBind11, GodotObject.GetPtr(this), frame);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFrameDuration, 1602489585ul);

    /// <summary>
    /// <para>Sets the duration of any given <paramref name="frame"/>. The final duration is affected by the <see cref="Godot.AnimatedTexture.SpeedScale"/>. If set to <c>0</c>, the frame is skipped during playback.</para>
    /// </summary>
    public void SetFrameDuration(int frame, float duration)
    {
        NativeCalls.godot_icall_2_69(MethodBind12, GodotObject.GetPtr(this), frame, duration);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFrameDuration, 2339986948ul);

    /// <summary>
    /// <para>Returns the given <paramref name="frame"/>'s duration, in seconds.</para>
    /// </summary>
    public float GetFrameDuration(int frame)
    {
        return NativeCalls.godot_icall_1_72(MethodBind13, GodotObject.GetPtr(this), frame);
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
    public new class PropertyName : Texture2D.PropertyName
    {
        /// <summary>
        /// Cached name for the 'frames' property.
        /// </summary>
        public static readonly StringName Frames = "frames";
        /// <summary>
        /// Cached name for the 'current_frame' property.
        /// </summary>
        public static readonly StringName CurrentFrame = "current_frame";
        /// <summary>
        /// Cached name for the 'pause' property.
        /// </summary>
        public static readonly StringName Pause = "pause";
        /// <summary>
        /// Cached name for the 'one_shot' property.
        /// </summary>
        public static readonly StringName OneShot = "one_shot";
        /// <summary>
        /// Cached name for the 'speed_scale' property.
        /// </summary>
        public static readonly StringName SpeedScale = "speed_scale";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Texture2D.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_frames' method.
        /// </summary>
        public static readonly StringName SetFrames = "set_frames";
        /// <summary>
        /// Cached name for the 'get_frames' method.
        /// </summary>
        public static readonly StringName GetFrames = "get_frames";
        /// <summary>
        /// Cached name for the 'set_current_frame' method.
        /// </summary>
        public static readonly StringName SetCurrentFrame = "set_current_frame";
        /// <summary>
        /// Cached name for the 'get_current_frame' method.
        /// </summary>
        public static readonly StringName GetCurrentFrame = "get_current_frame";
        /// <summary>
        /// Cached name for the 'set_pause' method.
        /// </summary>
        public static readonly StringName SetPause = "set_pause";
        /// <summary>
        /// Cached name for the 'get_pause' method.
        /// </summary>
        public static readonly StringName GetPause = "get_pause";
        /// <summary>
        /// Cached name for the 'set_one_shot' method.
        /// </summary>
        public static readonly StringName SetOneShot = "set_one_shot";
        /// <summary>
        /// Cached name for the 'get_one_shot' method.
        /// </summary>
        public static readonly StringName GetOneShot = "get_one_shot";
        /// <summary>
        /// Cached name for the 'set_speed_scale' method.
        /// </summary>
        public static readonly StringName SetSpeedScale = "set_speed_scale";
        /// <summary>
        /// Cached name for the 'get_speed_scale' method.
        /// </summary>
        public static readonly StringName GetSpeedScale = "get_speed_scale";
        /// <summary>
        /// Cached name for the 'set_frame_texture' method.
        /// </summary>
        public static readonly StringName SetFrameTexture = "set_frame_texture";
        /// <summary>
        /// Cached name for the 'get_frame_texture' method.
        /// </summary>
        public static readonly StringName GetFrameTexture = "get_frame_texture";
        /// <summary>
        /// Cached name for the 'set_frame_duration' method.
        /// </summary>
        public static readonly StringName SetFrameDuration = "set_frame_duration";
        /// <summary>
        /// Cached name for the 'get_frame_duration' method.
        /// </summary>
        public static readonly StringName GetFrameDuration = "get_frame_duration";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Texture2D.SignalName
    {
    }
}
