namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A <see cref="Godot.Parallax2D"/> is used to create a parallax effect. It can move at a different speed relative to the camera movement using <see cref="Godot.Parallax2D.ScrollScale"/>. This creates an illusion of depth in a 2D game. If manual scrolling is desired, the <see cref="Godot.Camera2D"/> position can be ignored with <see cref="Godot.Parallax2D.IgnoreCameraScroll"/>.</para>
/// <para><b>Note:</b> Any changes to this node's position made after it enters the scene tree will be overridden if <see cref="Godot.Parallax2D.IgnoreCameraScroll"/> is <see langword="false"/> or <see cref="Godot.Parallax2D.ScreenOffset"/> is modified.</para>
/// </summary>
public partial class Parallax2D : Node2D
{
    /// <summary>
    /// <para>Multiplier to the final <see cref="Godot.Parallax2D"/>'s offset. Can be used to simulate distance from the camera.</para>
    /// <para>For example, a value of <c>1</c> scrolls at the same speed as the camera. A value greater than <c>1</c> scrolls faster, making objects appear closer. Less than <c>1</c> scrolls slower, making objects appear further, and a value of <c>0</c> stops the objects completely.</para>
    /// </summary>
    public Vector2 ScrollScale
    {
        get
        {
            return GetScrollScale();
        }
        set
        {
            SetScrollScale(value);
        }
    }

    /// <summary>
    /// <para>The <see cref="Godot.Parallax2D"/>'s offset. Similar to <see cref="Godot.Parallax2D.ScreenOffset"/> and <see cref="Godot.Node2D.Position"/>, but will not be overridden.</para>
    /// <para><b>Note:</b> Values will loop if <see cref="Godot.Parallax2D.RepeatSize"/> is set higher than <c>0</c>.</para>
    /// </summary>
    public Vector2 ScrollOffset
    {
        get
        {
            return GetScrollOffset();
        }
        set
        {
            SetScrollOffset(value);
        }
    }

    /// <summary>
    /// <para>Repeats the <see cref="Godot.Texture2D"/> of each of this node's children and offsets them by this value. When scrolling, the node's position loops, giving the illusion of an infinite scrolling background if the values are larger than the screen size. If an axis is set to <c>0</c>, the <see cref="Godot.Texture2D"/> will not be repeated.</para>
    /// </summary>
    public Vector2 RepeatSize
    {
        get
        {
            return GetRepeatSize();
        }
        set
        {
            SetRepeatSize(value);
        }
    }

    /// <summary>
    /// <para>Velocity at which the offset scrolls automatically, in pixels per second.</para>
    /// </summary>
    public Vector2 Autoscroll
    {
        get
        {
            return GetAutoscroll();
        }
        set
        {
            SetAutoscroll(value);
        }
    }

    /// <summary>
    /// <para>Overrides the amount of times the texture repeats. Each texture copy spreads evenly from the original by <see cref="Godot.Parallax2D.RepeatSize"/>. Useful for when zooming out with a camera.</para>
    /// </summary>
    public int RepeatTimes
    {
        get
        {
            return GetRepeatTimes();
        }
        set
        {
            SetRepeatTimes(value);
        }
    }

    /// <summary>
    /// <para>Top-left limits for scrolling to begin. If the camera is outside of this limit, the <see cref="Godot.Parallax2D"/> stops scrolling. Must be lower than <see cref="Godot.Parallax2D.LimitEnd"/> minus the viewport size to work.</para>
    /// </summary>
    public Vector2 LimitBegin
    {
        get
        {
            return GetLimitBegin();
        }
        set
        {
            SetLimitBegin(value);
        }
    }

    /// <summary>
    /// <para>Bottom-right limits for scrolling to end. If the camera is outside of this limit, the <see cref="Godot.Parallax2D"/> will stop scrolling. Must be higher than <see cref="Godot.Parallax2D.LimitBegin"/> and the viewport size combined to work.</para>
    /// </summary>
    public Vector2 LimitEnd
    {
        get
        {
            return GetLimitEnd();
        }
        set
        {
            SetLimitEnd(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, this <see cref="Godot.Parallax2D"/> is offset by the current camera's position. If the <see cref="Godot.Parallax2D"/> is in a <see cref="Godot.CanvasLayer"/> separate from the current camera, it may be desired to match the value with <see cref="Godot.CanvasLayer.FollowViewportEnabled"/>.</para>
    /// </summary>
    public bool FollowViewport
    {
        get
        {
            return GetFollowViewport();
        }
        set
        {
            SetFollowViewport(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, <see cref="Godot.Parallax2D"/>'s position is not affected by the position of the camera.</para>
    /// </summary>
    public bool IgnoreCameraScroll
    {
        get
        {
            return IsIgnoreCameraScroll();
        }
        set
        {
            SetIgnoreCameraScroll(value);
        }
    }

    /// <summary>
    /// <para>Offset used to scroll this <see cref="Godot.Parallax2D"/>. This value is updated automatically unless <see cref="Godot.Parallax2D.IgnoreCameraScroll"/> is <see langword="true"/>.</para>
    /// </summary>
    public Vector2 ScreenOffset
    {
        get
        {
            return GetScreenOffset();
        }
        set
        {
            SetScreenOffset(value);
        }
    }

    private static readonly System.Type CachedType = typeof(Parallax2D);

    private static readonly StringName NativeName = "Parallax2D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public Parallax2D() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal Parallax2D(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal Parallax2D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetScrollScale, 743155724ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetScrollScale(Vector2 scale)
    {
        NativeCalls.godot_icall_1_36(MethodBind0, GodotObject.GetPtr(this), &scale);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetScrollScale, 3341600327ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2 GetScrollScale()
    {
        return NativeCalls.godot_icall_0_37(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRepeatSize, 743155724ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetRepeatSize(Vector2 repeatSize)
    {
        NativeCalls.godot_icall_1_36(MethodBind2, GodotObject.GetPtr(this), &repeatSize);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRepeatSize, 3341600327ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2 GetRepeatSize()
    {
        return NativeCalls.godot_icall_0_37(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRepeatTimes, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetRepeatTimes(int repeatTimes)
    {
        NativeCalls.godot_icall_1_38(MethodBind4, GodotObject.GetPtr(this), repeatTimes);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRepeatTimes, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetRepeatTimes()
    {
        return NativeCalls.godot_icall_0_39(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAutoscroll, 743155724ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetAutoscroll(Vector2 autoscroll)
    {
        NativeCalls.godot_icall_1_36(MethodBind6, GodotObject.GetPtr(this), &autoscroll);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAutoscroll, 3341600327ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2 GetAutoscroll()
    {
        return NativeCalls.godot_icall_0_37(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetScrollOffset, 743155724ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetScrollOffset(Vector2 offset)
    {
        NativeCalls.godot_icall_1_36(MethodBind8, GodotObject.GetPtr(this), &offset);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetScrollOffset, 3341600327ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2 GetScrollOffset()
    {
        return NativeCalls.godot_icall_0_37(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetScreenOffset, 743155724ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetScreenOffset(Vector2 offset)
    {
        NativeCalls.godot_icall_1_36(MethodBind10, GodotObject.GetPtr(this), &offset);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetScreenOffset, 3341600327ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2 GetScreenOffset()
    {
        return NativeCalls.godot_icall_0_37(MethodBind11, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLimitBegin, 743155724ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetLimitBegin(Vector2 offset)
    {
        NativeCalls.godot_icall_1_36(MethodBind12, GodotObject.GetPtr(this), &offset);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLimitBegin, 3341600327ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2 GetLimitBegin()
    {
        return NativeCalls.godot_icall_0_37(MethodBind13, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLimitEnd, 743155724ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetLimitEnd(Vector2 offset)
    {
        NativeCalls.godot_icall_1_36(MethodBind14, GodotObject.GetPtr(this), &offset);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLimitEnd, 3341600327ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2 GetLimitEnd()
    {
        return NativeCalls.godot_icall_0_37(MethodBind15, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFollowViewport, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFollowViewport(bool follow)
    {
        NativeCalls.godot_icall_1_14(MethodBind16, GodotObject.GetPtr(this), follow.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFollowViewport, 2240911060ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetFollowViewport()
    {
        return NativeCalls.godot_icall_0_15(MethodBind17, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetIgnoreCameraScroll, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetIgnoreCameraScroll(bool ignore)
    {
        NativeCalls.godot_icall_1_14(MethodBind18, GodotObject.GetPtr(this), ignore.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsIgnoreCameraScroll, 2240911060ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsIgnoreCameraScroll()
    {
        return NativeCalls.godot_icall_0_15(MethodBind19, GodotObject.GetPtr(this)).ToBool();
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
    public new class PropertyName : Node2D.PropertyName
    {
        /// <summary>
        /// Cached name for the 'scroll_scale' property.
        /// </summary>
        public static readonly StringName ScrollScale = "scroll_scale";
        /// <summary>
        /// Cached name for the 'scroll_offset' property.
        /// </summary>
        public static readonly StringName ScrollOffset = "scroll_offset";
        /// <summary>
        /// Cached name for the 'repeat_size' property.
        /// </summary>
        public static readonly StringName RepeatSize = "repeat_size";
        /// <summary>
        /// Cached name for the 'autoscroll' property.
        /// </summary>
        public static readonly StringName Autoscroll = "autoscroll";
        /// <summary>
        /// Cached name for the 'repeat_times' property.
        /// </summary>
        public static readonly StringName RepeatTimes = "repeat_times";
        /// <summary>
        /// Cached name for the 'limit_begin' property.
        /// </summary>
        public static readonly StringName LimitBegin = "limit_begin";
        /// <summary>
        /// Cached name for the 'limit_end' property.
        /// </summary>
        public static readonly StringName LimitEnd = "limit_end";
        /// <summary>
        /// Cached name for the 'follow_viewport' property.
        /// </summary>
        public static readonly StringName FollowViewport = "follow_viewport";
        /// <summary>
        /// Cached name for the 'ignore_camera_scroll' property.
        /// </summary>
        public static readonly StringName IgnoreCameraScroll = "ignore_camera_scroll";
        /// <summary>
        /// Cached name for the 'screen_offset' property.
        /// </summary>
        public static readonly StringName ScreenOffset = "screen_offset";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Node2D.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_scroll_scale' method.
        /// </summary>
        public static readonly StringName SetScrollScale = "set_scroll_scale";
        /// <summary>
        /// Cached name for the 'get_scroll_scale' method.
        /// </summary>
        public static readonly StringName GetScrollScale = "get_scroll_scale";
        /// <summary>
        /// Cached name for the 'set_repeat_size' method.
        /// </summary>
        public static readonly StringName SetRepeatSize = "set_repeat_size";
        /// <summary>
        /// Cached name for the 'get_repeat_size' method.
        /// </summary>
        public static readonly StringName GetRepeatSize = "get_repeat_size";
        /// <summary>
        /// Cached name for the 'set_repeat_times' method.
        /// </summary>
        public static readonly StringName SetRepeatTimes = "set_repeat_times";
        /// <summary>
        /// Cached name for the 'get_repeat_times' method.
        /// </summary>
        public static readonly StringName GetRepeatTimes = "get_repeat_times";
        /// <summary>
        /// Cached name for the 'set_autoscroll' method.
        /// </summary>
        public static readonly StringName SetAutoscroll = "set_autoscroll";
        /// <summary>
        /// Cached name for the 'get_autoscroll' method.
        /// </summary>
        public static readonly StringName GetAutoscroll = "get_autoscroll";
        /// <summary>
        /// Cached name for the 'set_scroll_offset' method.
        /// </summary>
        public static readonly StringName SetScrollOffset = "set_scroll_offset";
        /// <summary>
        /// Cached name for the 'get_scroll_offset' method.
        /// </summary>
        public static readonly StringName GetScrollOffset = "get_scroll_offset";
        /// <summary>
        /// Cached name for the 'set_screen_offset' method.
        /// </summary>
        public static readonly StringName SetScreenOffset = "set_screen_offset";
        /// <summary>
        /// Cached name for the 'get_screen_offset' method.
        /// </summary>
        public static readonly StringName GetScreenOffset = "get_screen_offset";
        /// <summary>
        /// Cached name for the 'set_limit_begin' method.
        /// </summary>
        public static readonly StringName SetLimitBegin = "set_limit_begin";
        /// <summary>
        /// Cached name for the 'get_limit_begin' method.
        /// </summary>
        public static readonly StringName GetLimitBegin = "get_limit_begin";
        /// <summary>
        /// Cached name for the 'set_limit_end' method.
        /// </summary>
        public static readonly StringName SetLimitEnd = "set_limit_end";
        /// <summary>
        /// Cached name for the 'get_limit_end' method.
        /// </summary>
        public static readonly StringName GetLimitEnd = "get_limit_end";
        /// <summary>
        /// Cached name for the 'set_follow_viewport' method.
        /// </summary>
        public static readonly StringName SetFollowViewport = "set_follow_viewport";
        /// <summary>
        /// Cached name for the 'get_follow_viewport' method.
        /// </summary>
        public static readonly StringName GetFollowViewport = "get_follow_viewport";
        /// <summary>
        /// Cached name for the 'set_ignore_camera_scroll' method.
        /// </summary>
        public static readonly StringName SetIgnoreCameraScroll = "set_ignore_camera_scroll";
        /// <summary>
        /// Cached name for the 'is_ignore_camera_scroll' method.
        /// </summary>
        public static readonly StringName IsIgnoreCameraScroll = "is_ignore_camera_scroll";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Node2D.SignalName
    {
    }
}
