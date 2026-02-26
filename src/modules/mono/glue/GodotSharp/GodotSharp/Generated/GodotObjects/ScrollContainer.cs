namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A container used to provide a child control with scrollbars when needed. Scrollbars will automatically be drawn at the right (for vertical) or bottom (for horizontal) and will enable dragging to move the viewable Control (and its children) within the ScrollContainer. Scrollbars will also automatically resize the grabber based on the <see cref="Godot.Control.CustomMinimumSize"/> of the Control relative to the ScrollContainer.</para>
/// </summary>
public partial class ScrollContainer : Container
{
    public enum ScrollMode : long
    {
        /// <summary>
        /// <para>Scrolling disabled, scrollbar will be invisible.</para>
        /// </summary>
        Disabled = 0,
        /// <summary>
        /// <para>Scrolling enabled, scrollbar will be visible only if necessary, i.e. container's content is bigger than the container.</para>
        /// </summary>
        Auto = 1,
        /// <summary>
        /// <para>Scrolling enabled, scrollbar will be always visible.</para>
        /// </summary>
        ShowAlways = 2,
        /// <summary>
        /// <para>Scrolling enabled, scrollbar will be hidden.</para>
        /// </summary>
        ShowNever = 3,
        /// <summary>
        /// <para>Combines <see cref="Godot.ScrollContainer.ScrollMode.Auto"/> and <see cref="Godot.ScrollContainer.ScrollMode.ShowAlways"/>. The scrollbar is only visible if necessary, but the content size is adjusted as if it was always visible. It's useful for ensuring that content size stays the same regardless if the scrollbar is visible.</para>
        /// </summary>
        Reserve = 4
    }

    public enum ScrollHintModeEnum : long
    {
        /// <summary>
        /// <para>Scroll hints will never be shown.</para>
        /// </summary>
        Disabled = 0,
        /// <summary>
        /// <para>Scroll hints will be shown at the top and bottom (if vertical), or left and right (if horizontal).</para>
        /// </summary>
        All = 1,
        /// <summary>
        /// <para>Scroll hints will be shown at the top (if vertical), or the left (if horizontal).</para>
        /// </summary>
        TopAndLeft = 2,
        /// <summary>
        /// <para>Scroll hints will be shown at the bottom (if horizontal), or the right (if horizontal).</para>
        /// </summary>
        BottomAndRight = 3
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the ScrollContainer will automatically scroll to focused children (including indirect children) to make sure they are fully visible.</para>
    /// </summary>
    public bool FollowFocus
    {
        get
        {
            return IsFollowingFocus();
        }
        set
        {
            SetFollowFocus(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, <c>focus</c> is drawn when the ScrollContainer or one of its descendant nodes is focused.</para>
    /// </summary>
    public bool DrawFocusBorder
    {
        get
        {
            return GetDrawFocusBorder();
        }
        set
        {
            SetDrawFocusBorder(value);
        }
    }

    /// <summary>
    /// <para>The current horizontal scroll value.</para>
    /// <para><b>Note:</b> If you are setting this value in the <see cref="Godot.Node._Ready()"/> function or earlier, it needs to be wrapped with <see cref="Godot.GodotObject.SetDeferred(StringName, Variant)"/>, since scroll bar's <see cref="Godot.Range.MaxValue"/> is not initialized yet.</para>
    /// <para><code>
    /// func _ready():
    /// 	set_deferred("scroll_horizontal", 600)
    /// </code></para>
    /// </summary>
    public int ScrollHorizontal
    {
        get
        {
            return GetHScroll();
        }
        set
        {
            SetHScroll(value);
        }
    }

    /// <summary>
    /// <para>The current vertical scroll value.</para>
    /// <para><b>Note:</b> Setting it early needs to be deferred, just like in <see cref="Godot.ScrollContainer.ScrollHorizontal"/>.</para>
    /// <para><code>
    /// func _ready():
    /// 	set_deferred("scroll_vertical", 600)
    /// </code></para>
    /// </summary>
    public int ScrollVertical
    {
        get
        {
            return GetVScroll();
        }
        set
        {
            SetVScroll(value);
        }
    }

    /// <summary>
    /// <para>Overrides the <see cref="Godot.ScrollBar.CustomStep"/> used when clicking the internal scroll bar's horizontal increment and decrement buttons or when using arrow keys when the <see cref="Godot.ScrollBar"/> is focused.</para>
    /// </summary>
    public float ScrollHorizontalCustomStep
    {
        get
        {
            return GetHorizontalCustomStep();
        }
        set
        {
            SetHorizontalCustomStep(value);
        }
    }

    /// <summary>
    /// <para>Overrides the <see cref="Godot.ScrollBar.CustomStep"/> used when clicking the internal scroll bar's vertical increment and decrement buttons or when using arrow keys when the <see cref="Godot.ScrollBar"/> is focused.</para>
    /// </summary>
    public float ScrollVerticalCustomStep
    {
        get
        {
            return GetVerticalCustomStep();
        }
        set
        {
            SetVerticalCustomStep(value);
        }
    }

    /// <summary>
    /// <para>Controls whether horizontal scrollbar can be used and when it should be visible.</para>
    /// </summary>
    public ScrollContainer.ScrollMode HorizontalScrollMode
    {
        get
        {
            return GetHorizontalScrollMode();
        }
        set
        {
            SetHorizontalScrollMode(value);
        }
    }

    /// <summary>
    /// <para>Controls whether vertical scrollbar can be used and when it should be visible.</para>
    /// </summary>
    public ScrollContainer.ScrollMode VerticalScrollMode
    {
        get
        {
            return GetVerticalScrollMode();
        }
        set
        {
            SetVerticalScrollMode(value);
        }
    }

    /// <summary>
    /// <para>Deadzone for touch scrolling. Lower deadzone makes the scrolling more sensitive.</para>
    /// </summary>
    public int ScrollDeadzone
    {
        get
        {
            return GetDeadzone();
        }
        set
        {
            SetDeadzone(value);
        }
    }

    /// <summary>
    /// <para>The way which scroll hints (indicators that show that the content can still be scrolled in a certain direction) will be shown.</para>
    /// <para><b>Note:</b> Hints won't be shown if the content can be scrolled both vertically and horizontally.</para>
    /// </summary>
    public ScrollContainer.ScrollHintModeEnum ScrollHintMode
    {
        get
        {
            return GetScrollHintMode();
        }
        set
        {
            SetScrollHintMode(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the scroll hint texture will be tiled instead of stretched. See <see cref="Godot.ScrollContainer.ScrollHintMode"/>.</para>
    /// </summary>
    public bool TileScrollHint
    {
        get
        {
            return IsScrollHintTiled();
        }
        set
        {
            SetTileScrollHint(value);
        }
    }

    private static readonly System.Type CachedType = typeof(ScrollContainer);

    private static readonly StringName NativeName = "ScrollContainer";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public ScrollContainer() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal ScrollContainer(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal ScrollContainer(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetHScroll, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetHScroll(int value)
    {
        NativeCalls.godot_icall_1_38(MethodBind0, GodotObject.GetPtr(this), value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetHScroll, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetHScroll()
    {
        return NativeCalls.godot_icall_0_39(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVScroll, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetVScroll(int value)
    {
        NativeCalls.godot_icall_1_38(MethodBind2, GodotObject.GetPtr(this), value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVScroll, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetVScroll()
    {
        return NativeCalls.godot_icall_0_39(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetHorizontalCustomStep, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetHorizontalCustomStep(float value)
    {
        NativeCalls.godot_icall_1_67(MethodBind4, GodotObject.GetPtr(this), value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetHorizontalCustomStep, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetHorizontalCustomStep()
    {
        return NativeCalls.godot_icall_0_68(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVerticalCustomStep, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetVerticalCustomStep(float value)
    {
        NativeCalls.godot_icall_1_67(MethodBind6, GodotObject.GetPtr(this), value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVerticalCustomStep, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetVerticalCustomStep()
    {
        return NativeCalls.godot_icall_0_68(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetHorizontalScrollMode, 2750506364ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetHorizontalScrollMode(ScrollContainer.ScrollMode enable)
    {
        NativeCalls.godot_icall_1_38(MethodBind8, GodotObject.GetPtr(this), (int)enable);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetHorizontalScrollMode, 3987985145ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public ScrollContainer.ScrollMode GetHorizontalScrollMode()
    {
        return (ScrollContainer.ScrollMode)NativeCalls.godot_icall_0_39(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVerticalScrollMode, 2750506364ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetVerticalScrollMode(ScrollContainer.ScrollMode enable)
    {
        NativeCalls.godot_icall_1_38(MethodBind10, GodotObject.GetPtr(this), (int)enable);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVerticalScrollMode, 3987985145ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public ScrollContainer.ScrollMode GetVerticalScrollMode()
    {
        return (ScrollContainer.ScrollMode)NativeCalls.godot_icall_0_39(MethodBind11, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDeadzone, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDeadzone(int deadzone)
    {
        NativeCalls.godot_icall_1_38(MethodBind12, GodotObject.GetPtr(this), deadzone);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDeadzone, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetDeadzone()
    {
        return NativeCalls.godot_icall_0_39(MethodBind13, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetScrollHintMode, 578158943ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetScrollHintMode(ScrollContainer.ScrollHintModeEnum scrollHintMode)
    {
        NativeCalls.godot_icall_1_38(MethodBind14, GodotObject.GetPtr(this), (int)scrollHintMode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetScrollHintMode, 246835423ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public ScrollContainer.ScrollHintModeEnum GetScrollHintMode()
    {
        return (ScrollContainer.ScrollHintModeEnum)NativeCalls.godot_icall_0_39(MethodBind15, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTileScrollHint, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTileScrollHint(bool tileScrollHint)
    {
        NativeCalls.godot_icall_1_14(MethodBind16, GodotObject.GetPtr(this), tileScrollHint.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsScrollHintTiled, 2240911060ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsScrollHintTiled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind17, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFollowFocus, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFollowFocus(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind18, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsFollowingFocus, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsFollowingFocus()
    {
        return NativeCalls.godot_icall_0_15(MethodBind19, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetHScrollBar, 4004517983ul);

    /// <summary>
    /// <para>Returns the horizontal scrollbar <see cref="Godot.HScrollBar"/> of this <see cref="Godot.ScrollContainer"/>.</para>
    /// <para><b>Warning:</b> This is a required internal node, removing and freeing it may cause a crash. If you wish to disable or hide a scrollbar, you can use <see cref="Godot.ScrollContainer.HorizontalScrollMode"/>.</para>
    /// </summary>
    public HScrollBar GetHScrollBar()
    {
        return (HScrollBar)NativeCalls.godot_icall_0_53(MethodBind20, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVScrollBar, 2630340773ul);

    /// <summary>
    /// <para>Returns the vertical scrollbar <see cref="Godot.VScrollBar"/> of this <see cref="Godot.ScrollContainer"/>.</para>
    /// <para><b>Warning:</b> This is a required internal node, removing and freeing it may cause a crash. If you wish to disable or hide a scrollbar, you can use <see cref="Godot.ScrollContainer.VerticalScrollMode"/>.</para>
    /// </summary>
    public VScrollBar GetVScrollBar()
    {
        return (VScrollBar)NativeCalls.godot_icall_0_53(MethodBind21, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.EnsureControlVisible, 1496901182ul);

    /// <summary>
    /// <para>Ensures the given <paramref name="control"/> is visible (must be a direct or indirect child of the ScrollContainer). Used by <see cref="Godot.ScrollContainer.FollowFocus"/>.</para>
    /// <para><b>Note:</b> This will not work on a node that was just added during the same frame. If you want to scroll to a newly added child, you must wait until the next frame using <see cref="Godot.SceneTree.ProcessFrame"/>:</para>
    /// <para><code>
    /// add_child(child_node)
    /// await get_tree().process_frame
    /// ensure_control_visible(child_node)
    /// </code></para>
    /// </summary>
    public void EnsureControlVisible(Control control)
    {
        NativeCalls.godot_icall_1_56(MethodBind22, GodotObject.GetPtr(this), GodotObject.GetPtr(control));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDrawFocusBorder, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDrawFocusBorder(bool draw)
    {
        NativeCalls.godot_icall_1_14(MethodBind23, GodotObject.GetPtr(this), draw.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDrawFocusBorder, 2240911060ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetDrawFocusBorder()
    {
        return NativeCalls.godot_icall_0_15(MethodBind24, GodotObject.GetPtr(this)).ToBool();
    }

    /// <summary>
    /// <para>Emitted when scrolling starts when dragging the scrollable area w<i>ith a touch event</i>. This signal is <i>not</i> emitted when scrolling by dragging the scrollbar, scrolling with the mouse wheel or scrolling with keyboard/gamepad events.</para>
    /// <para><b>Note:</b> This signal is only emitted on Android or iOS, or on desktop/web platforms when <c>ProjectSettings.input_devices/pointing/emulate_touch_from_mouse</c> is enabled.</para>
    /// </summary>
    public event Action ScrollStarted
    {
        add => Connect(SignalName.ScrollStarted, Callable.From(value));
        remove => Disconnect(SignalName.ScrollStarted, Callable.From(value));
    }

    protected void EmitSignalScrollStarted()
    {
        EmitSignal(SignalName.ScrollStarted);
    }

    /// <summary>
    /// <para>Emitted when scrolling stops when dragging the scrollable area <i>with a touch event</i>. This signal is <i>not</i> emitted when scrolling by dragging the scrollbar, scrolling with the mouse wheel or scrolling with keyboard/gamepad events.</para>
    /// <para><b>Note:</b> This signal is only emitted on Android or iOS, or on desktop/web platforms when <c>ProjectSettings.input_devices/pointing/emulate_touch_from_mouse</c> is enabled.</para>
    /// </summary>
    public event Action ScrollEnded
    {
        add => Connect(SignalName.ScrollEnded, Callable.From(value));
        remove => Disconnect(SignalName.ScrollEnded, Callable.From(value));
    }

    protected void EmitSignalScrollEnded()
    {
        EmitSignal(SignalName.ScrollEnded);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_scroll_started = "ScrollStarted";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_scroll_ended = "ScrollEnded";

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
        if (signal == SignalName.ScrollStarted)
        {
            if (HasGodotClassSignal(SignalProxyName_scroll_started.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.ScrollEnded)
        {
            if (HasGodotClassSignal(SignalProxyName_scroll_ended.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        return base.HasGodotClassSignal(signal);
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : Container.PropertyName
    {
        /// <summary>
        /// Cached name for the 'follow_focus' property.
        /// </summary>
        public static readonly StringName FollowFocus = "follow_focus";
        /// <summary>
        /// Cached name for the 'draw_focus_border' property.
        /// </summary>
        public static readonly StringName DrawFocusBorder = "draw_focus_border";
        /// <summary>
        /// Cached name for the 'scroll_horizontal' property.
        /// </summary>
        public static readonly StringName ScrollHorizontal = "scroll_horizontal";
        /// <summary>
        /// Cached name for the 'scroll_vertical' property.
        /// </summary>
        public static readonly StringName ScrollVertical = "scroll_vertical";
        /// <summary>
        /// Cached name for the 'scroll_horizontal_custom_step' property.
        /// </summary>
        public static readonly StringName ScrollHorizontalCustomStep = "scroll_horizontal_custom_step";
        /// <summary>
        /// Cached name for the 'scroll_vertical_custom_step' property.
        /// </summary>
        public static readonly StringName ScrollVerticalCustomStep = "scroll_vertical_custom_step";
        /// <summary>
        /// Cached name for the 'horizontal_scroll_mode' property.
        /// </summary>
        public static readonly StringName HorizontalScrollMode = "horizontal_scroll_mode";
        /// <summary>
        /// Cached name for the 'vertical_scroll_mode' property.
        /// </summary>
        public static readonly StringName VerticalScrollMode = "vertical_scroll_mode";
        /// <summary>
        /// Cached name for the 'scroll_deadzone' property.
        /// </summary>
        public static readonly StringName ScrollDeadzone = "scroll_deadzone";
        /// <summary>
        /// Cached name for the 'scroll_hint_mode' property.
        /// </summary>
        public static readonly StringName ScrollHintMode = "scroll_hint_mode";
        /// <summary>
        /// Cached name for the 'tile_scroll_hint' property.
        /// </summary>
        public static readonly StringName TileScrollHint = "tile_scroll_hint";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Container.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_h_scroll' method.
        /// </summary>
        public static readonly StringName SetHScroll = "set_h_scroll";
        /// <summary>
        /// Cached name for the 'get_h_scroll' method.
        /// </summary>
        public static readonly StringName GetHScroll = "get_h_scroll";
        /// <summary>
        /// Cached name for the 'set_v_scroll' method.
        /// </summary>
        public static readonly StringName SetVScroll = "set_v_scroll";
        /// <summary>
        /// Cached name for the 'get_v_scroll' method.
        /// </summary>
        public static readonly StringName GetVScroll = "get_v_scroll";
        /// <summary>
        /// Cached name for the 'set_horizontal_custom_step' method.
        /// </summary>
        public static readonly StringName SetHorizontalCustomStep = "set_horizontal_custom_step";
        /// <summary>
        /// Cached name for the 'get_horizontal_custom_step' method.
        /// </summary>
        public static readonly StringName GetHorizontalCustomStep = "get_horizontal_custom_step";
        /// <summary>
        /// Cached name for the 'set_vertical_custom_step' method.
        /// </summary>
        public static readonly StringName SetVerticalCustomStep = "set_vertical_custom_step";
        /// <summary>
        /// Cached name for the 'get_vertical_custom_step' method.
        /// </summary>
        public static readonly StringName GetVerticalCustomStep = "get_vertical_custom_step";
        /// <summary>
        /// Cached name for the 'set_horizontal_scroll_mode' method.
        /// </summary>
        public static readonly StringName SetHorizontalScrollMode = "set_horizontal_scroll_mode";
        /// <summary>
        /// Cached name for the 'get_horizontal_scroll_mode' method.
        /// </summary>
        public static readonly StringName GetHorizontalScrollMode = "get_horizontal_scroll_mode";
        /// <summary>
        /// Cached name for the 'set_vertical_scroll_mode' method.
        /// </summary>
        public static readonly StringName SetVerticalScrollMode = "set_vertical_scroll_mode";
        /// <summary>
        /// Cached name for the 'get_vertical_scroll_mode' method.
        /// </summary>
        public static readonly StringName GetVerticalScrollMode = "get_vertical_scroll_mode";
        /// <summary>
        /// Cached name for the 'set_deadzone' method.
        /// </summary>
        public static readonly StringName SetDeadzone = "set_deadzone";
        /// <summary>
        /// Cached name for the 'get_deadzone' method.
        /// </summary>
        public static readonly StringName GetDeadzone = "get_deadzone";
        /// <summary>
        /// Cached name for the 'set_scroll_hint_mode' method.
        /// </summary>
        public static readonly StringName SetScrollHintMode = "set_scroll_hint_mode";
        /// <summary>
        /// Cached name for the 'get_scroll_hint_mode' method.
        /// </summary>
        public static readonly StringName GetScrollHintMode = "get_scroll_hint_mode";
        /// <summary>
        /// Cached name for the 'set_tile_scroll_hint' method.
        /// </summary>
        public static readonly StringName SetTileScrollHint = "set_tile_scroll_hint";
        /// <summary>
        /// Cached name for the 'is_scroll_hint_tiled' method.
        /// </summary>
        public static readonly StringName IsScrollHintTiled = "is_scroll_hint_tiled";
        /// <summary>
        /// Cached name for the 'set_follow_focus' method.
        /// </summary>
        public static readonly StringName SetFollowFocus = "set_follow_focus";
        /// <summary>
        /// Cached name for the 'is_following_focus' method.
        /// </summary>
        public static readonly StringName IsFollowingFocus = "is_following_focus";
        /// <summary>
        /// Cached name for the 'get_h_scroll_bar' method.
        /// </summary>
        public static readonly StringName GetHScrollBar = "get_h_scroll_bar";
        /// <summary>
        /// Cached name for the 'get_v_scroll_bar' method.
        /// </summary>
        public static readonly StringName GetVScrollBar = "get_v_scroll_bar";
        /// <summary>
        /// Cached name for the 'ensure_control_visible' method.
        /// </summary>
        public static readonly StringName EnsureControlVisible = "ensure_control_visible";
        /// <summary>
        /// Cached name for the 'set_draw_focus_border' method.
        /// </summary>
        public static readonly StringName SetDrawFocusBorder = "set_draw_focus_border";
        /// <summary>
        /// Cached name for the 'get_draw_focus_border' method.
        /// </summary>
        public static readonly StringName GetDrawFocusBorder = "get_draw_focus_border";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Container.SignalName
    {
        /// <summary>
        /// Cached name for the 'scroll_started' signal.
        /// </summary>
        public static readonly StringName ScrollStarted = "scroll_started";
        /// <summary>
        /// Cached name for the 'scroll_ended' signal.
        /// </summary>
        public static readonly StringName ScrollEnded = "scroll_ended";
    }
}
