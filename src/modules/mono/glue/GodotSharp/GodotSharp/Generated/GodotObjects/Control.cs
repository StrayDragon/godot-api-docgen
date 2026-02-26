namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Base class for all UI-related nodes. <see cref="Godot.Control"/> features a bounding rectangle that defines its extents, an anchor position relative to its parent control or the current viewport, and offsets relative to the anchor. The offsets update automatically when the node, any of its parents, or the screen size change.</para>
/// <para>For more information on Godot's UI system, anchors, offsets, and containers, see the related tutorials in the manual. To build flexible UIs, you'll need a mix of UI elements that inherit from <see cref="Godot.Control"/> and <see cref="Godot.Container"/> nodes.</para>
/// <para><b>Note:</b> Since both <see cref="Godot.Node2D"/> and <see cref="Godot.Control"/> inherit from <see cref="Godot.CanvasItem"/>, they share several concepts from the class such as the <see cref="Godot.CanvasItem.ZIndex"/> and <see cref="Godot.CanvasItem.Visible"/> properties.</para>
/// <para><b>User Interface nodes and input</b></para>
/// <para>Godot propagates input events via viewports. Each <see cref="Godot.Viewport"/> is responsible for propagating <see cref="Godot.InputEvent"/>s to their child nodes. As the <see cref="Godot.SceneTree.Root"/> is a <see cref="Godot.Window"/>, this already happens automatically for all UI elements in your game.</para>
/// <para>Input events are propagated through the <see cref="Godot.SceneTree"/> from the root node to all child nodes by calling <see cref="Godot.Node._Input(InputEvent)"/>. For UI elements specifically, it makes more sense to override the virtual method <see cref="Godot.Control._GuiInput(InputEvent)"/>, which filters out unrelated input events, such as by checking z-order, <see cref="Godot.Control.MouseFilter"/>, focus, or if the event was inside of the control's bounding box.</para>
/// <para>Call <see cref="Godot.Control.AcceptEvent()"/> so no other node receives the event. Once you accept an input, it becomes handled so <see cref="Godot.Node._UnhandledInput(InputEvent)"/> will not process it.</para>
/// <para>Only one <see cref="Godot.Control"/> node can be in focus. Only the node in focus will receive events. To get the focus, call <see cref="Godot.Control.GrabFocus(bool)"/>. <see cref="Godot.Control"/> nodes lose focus when another node grabs it, or if you hide the node in focus. Focus will not be represented visually if gained via mouse/touch input, only appearing with keyboard/gamepad input (for accessibility), or via <see cref="Godot.Control.GrabFocus(bool)"/>.</para>
/// <para>Set <see cref="Godot.Control.MouseFilter"/> to <see cref="Godot.Control.MouseFilterEnum.Ignore"/> to tell a <see cref="Godot.Control"/> node to ignore mouse or touch events. You'll need it if you place an icon on top of a button.</para>
/// <para><see cref="Godot.Theme"/> resources change the control's appearance. The <see cref="Godot.Control.Theme"/> of a <see cref="Godot.Control"/> node affects all of its direct and indirect children (as long as a chain of controls is uninterrupted). To override some of the theme items, call one of the <c>add_theme_*_override</c> methods, like <see cref="Godot.Control.AddThemeFontOverride(StringName, Font)"/>. You can also override theme items in the Inspector.</para>
/// <para><b>Note:</b> Theme items are <i>not</i> <see cref="Godot.GodotObject"/> properties. This means you can't access their values using <see cref="Godot.GodotObject.Get(StringName)"/> and <see cref="Godot.GodotObject.Set(StringName, Variant)"/>. Instead, use the <c>get_theme_*</c> and <c>add_theme_*_override</c> methods provided by this class.</para>
/// </summary>
public partial class Control : CanvasItem
{
    /// <summary>
    /// <para>Sent when the node changes size. Use <see cref="Godot.Control.Size"/> to get the new size.</para>
    /// </summary>
    public const long NotificationResized = 40;
    /// <summary>
    /// <para>Sent when the mouse cursor enters the control's (or any child control's) visible area, that is not occluded behind other Controls or Windows, provided its <see cref="Godot.Control.MouseFilter"/> lets the event reach it and regardless if it's currently focused or not.</para>
    /// <para><b>Note:</b> <see cref="Godot.CanvasItem.ZIndex"/> doesn't affect which Control receives the notification.</para>
    /// <para>See also <see cref="Godot.Control.NotificationMouseEnterSelf"/>.</para>
    /// </summary>
    public const long NotificationMouseEnter = 41;
    /// <summary>
    /// <para>Sent when the mouse cursor leaves the control's (and all child control's) visible area, that is not occluded behind other Controls or Windows, provided its <see cref="Godot.Control.MouseFilter"/> lets the event reach it and regardless if it's currently focused or not.</para>
    /// <para><b>Note:</b> <see cref="Godot.CanvasItem.ZIndex"/> doesn't affect which Control receives the notification.</para>
    /// <para>See also <see cref="Godot.Control.NotificationMouseExitSelf"/>.</para>
    /// </summary>
    public const long NotificationMouseExit = 42;
    /// <summary>
    /// <para>Sent when the mouse cursor enters the control's visible area, that is not occluded behind other Controls or Windows, provided its <see cref="Godot.Control.MouseFilter"/> lets the event reach it and regardless if it's currently focused or not.</para>
    /// <para><b>Note:</b> <see cref="Godot.CanvasItem.ZIndex"/> doesn't affect which Control receives the notification.</para>
    /// <para>See also <see cref="Godot.Control.NotificationMouseEnter"/>.</para>
    /// </summary>
    public const long NotificationMouseEnterSelf = 60;
    /// <summary>
    /// <para>Sent when the mouse cursor leaves the control's visible area, that is not occluded behind other Controls or Windows, provided its <see cref="Godot.Control.MouseFilter"/> lets the event reach it and regardless if it's currently focused or not.</para>
    /// <para><b>Note:</b> <see cref="Godot.CanvasItem.ZIndex"/> doesn't affect which Control receives the notification.</para>
    /// <para>See also <see cref="Godot.Control.NotificationMouseExit"/>.</para>
    /// </summary>
    public const long NotificationMouseExitSelf = 61;
    /// <summary>
    /// <para>Sent when the node grabs focus.</para>
    /// </summary>
    public const long NotificationFocusEnter = 43;
    /// <summary>
    /// <para>Sent when the node loses focus.</para>
    /// <para>This notification is sent in reversed order.</para>
    /// </summary>
    public const long NotificationFocusExit = 44;
    /// <summary>
    /// <para>Sent when the node needs to refresh its theme items. This happens in one of the following cases:</para>
    /// <para>- The <see cref="Godot.Control.Theme"/> property is changed on this node or any of its ancestors.</para>
    /// <para>- The <see cref="Godot.Control.ThemeTypeVariation"/> property is changed on this node.</para>
    /// <para>- One of the node's theme property overrides is changed.</para>
    /// <para>- The node enters the scene tree.</para>
    /// <para><b>Note:</b> As an optimization, this notification won't be sent from changes that occur while this node is outside of the scene tree. Instead, all of the theme item updates can be applied at once when the node enters the scene tree.</para>
    /// <para><b>Note:</b> This notification is received alongside <see cref="Godot.Node.NotificationEnterTree"/>, so if you are instantiating a scene, the child nodes will not be initialized yet. You can use it to setup theming for this node, child nodes created from script, or if you want to access child nodes added in the editor, make sure the node is ready using <see cref="Godot.Node.IsNodeReady()"/>.</para>
    /// <para><code>
    /// func _notification(what):
    /// 	if what == NOTIFICATION_THEME_CHANGED:
    /// 		if not is_node_ready():
    /// 			await ready # Wait until ready signal.
    /// 		$Label.add_theme_color_override("font_color", Color.YELLOW)
    /// </code></para>
    /// </summary>
    public const long NotificationThemeChanged = 45;
    /// <summary>
    /// <para>Sent when this node is inside a <see cref="Godot.ScrollContainer"/> which has begun being scrolled when dragging the scrollable area <i>with a touch event</i>. This notification is <i>not</i> sent when scrolling by dragging the scrollbar, scrolling with the mouse wheel or scrolling with keyboard/gamepad events.</para>
    /// <para><b>Note:</b> This signal is only emitted on Android or iOS, or on desktop/web platforms when <c>ProjectSettings.input_devices/pointing/emulate_touch_from_mouse</c> is enabled.</para>
    /// </summary>
    public const long NotificationScrollBegin = 47;
    /// <summary>
    /// <para>Sent when this node is inside a <see cref="Godot.ScrollContainer"/> which has stopped being scrolled when dragging the scrollable area <i>with a touch event</i>. This notification is <i>not</i> sent when scrolling by dragging the scrollbar, scrolling with the mouse wheel or scrolling with keyboard/gamepad events.</para>
    /// <para><b>Note:</b> This signal is only emitted on Android or iOS, or on desktop/web platforms when <c>ProjectSettings.input_devices/pointing/emulate_touch_from_mouse</c> is enabled.</para>
    /// </summary>
    public const long NotificationScrollEnd = 48;
    /// <summary>
    /// <para>Sent when the control layout direction is changed from LTR or RTL or vice versa. This notification is propagated to child Control nodes as result of a change to <see cref="Godot.Control.LayoutDirection"/>.</para>
    /// </summary>
    public const long NotificationLayoutDirectionChanged = 49;

    public enum FocusModeEnum : long
    {
        /// <summary>
        /// <para>The node cannot grab focus. Use with <see cref="Godot.Control.FocusMode"/>.</para>
        /// </summary>
        None = 0,
        /// <summary>
        /// <para>The node can only grab focus on mouse clicks. Use with <see cref="Godot.Control.FocusMode"/>.</para>
        /// </summary>
        Click = 1,
        /// <summary>
        /// <para>The node can grab focus on mouse click, using the arrows and the Tab keys on the keyboard, or using the D-pad buttons on a gamepad. Use with <see cref="Godot.Control.FocusMode"/>.</para>
        /// </summary>
        All = 2,
        /// <summary>
        /// <para>The node can grab focus only when screen reader is active. Use with <see cref="Godot.Control.FocusMode"/>.</para>
        /// </summary>
        Accessibility = 3
    }

    public enum FocusBehaviorRecursiveEnum : long
    {
        /// <summary>
        /// <para>Inherits the <see cref="Godot.Control.FocusBehaviorRecursive"/> from the parent control. If there is no parent control, this is the same as <see cref="Godot.Control.FocusBehaviorRecursiveEnum.Enabled"/>.</para>
        /// </summary>
        Inherited = 0,
        /// <summary>
        /// <para>Prevents the control from getting focused. <see cref="Godot.Control.GetFocusModeWithOverride()"/> will return <see cref="Godot.Control.FocusModeEnum.None"/>.</para>
        /// </summary>
        Disabled = 1,
        /// <summary>
        /// <para>Allows the control to be focused, depending on the <see cref="Godot.Control.FocusMode"/>. This can be used to ignore the parent's <see cref="Godot.Control.FocusBehaviorRecursive"/>. <see cref="Godot.Control.GetFocusModeWithOverride()"/> will return the <see cref="Godot.Control.FocusMode"/>.</para>
        /// </summary>
        Enabled = 2
    }

    public enum MouseBehaviorRecursiveEnum : long
    {
        /// <summary>
        /// <para>Inherits the <see cref="Godot.Control.MouseBehaviorRecursive"/> from the parent control. If there is no parent control, this is the same as <see cref="Godot.Control.MouseBehaviorRecursiveEnum.Enabled"/>.</para>
        /// </summary>
        Inherited = 0,
        /// <summary>
        /// <para>Prevents the control from receiving mouse input. <see cref="Godot.Control.GetMouseFilterWithOverride()"/> will return <see cref="Godot.Control.MouseFilterEnum.Ignore"/>.</para>
        /// </summary>
        Disabled = 1,
        /// <summary>
        /// <para>Allows the control to receive mouse input, depending on the <see cref="Godot.Control.MouseFilter"/>. This can be used to ignore the parent's <see cref="Godot.Control.MouseBehaviorRecursive"/>. <see cref="Godot.Control.GetMouseFilterWithOverride()"/> will return the <see cref="Godot.Control.MouseFilter"/>.</para>
        /// </summary>
        Enabled = 2
    }

    public enum CursorShape : long
    {
        /// <summary>
        /// <para>Show the system's arrow mouse cursor when the user hovers the node. Use with <see cref="Godot.Control.MouseDefaultCursorShape"/>.</para>
        /// </summary>
        Arrow = 0,
        /// <summary>
        /// <para>Show the system's I-beam mouse cursor when the user hovers the node. The I-beam pointer has a shape similar to "I". It tells the user they can highlight or insert text.</para>
        /// </summary>
        Ibeam = 1,
        /// <summary>
        /// <para>Show the system's pointing hand mouse cursor when the user hovers the node.</para>
        /// </summary>
        PointingHand = 2,
        /// <summary>
        /// <para>Show the system's cross mouse cursor when the user hovers the node.</para>
        /// </summary>
        Cross = 3,
        /// <summary>
        /// <para>Show the system's wait mouse cursor when the user hovers the node. Often an hourglass.</para>
        /// </summary>
        Wait = 4,
        /// <summary>
        /// <para>Show the system's busy mouse cursor when the user hovers the node. Often an arrow with a small hourglass.</para>
        /// </summary>
        Busy = 5,
        /// <summary>
        /// <para>Show the system's drag mouse cursor, often a closed fist or a cross symbol, when the user hovers the node. It tells the user they're currently dragging an item, like a node in the Scene dock.</para>
        /// </summary>
        Drag = 6,
        /// <summary>
        /// <para>Show the system's drop mouse cursor when the user hovers the node. It can be an open hand. It tells the user they can drop an item they're currently grabbing, like a node in the Scene dock.</para>
        /// </summary>
        CanDrop = 7,
        /// <summary>
        /// <para>Show the system's forbidden mouse cursor when the user hovers the node. Often a crossed circle.</para>
        /// </summary>
        Forbidden = 8,
        /// <summary>
        /// <para>Show the system's vertical resize mouse cursor when the user hovers the node. A double-headed vertical arrow. It tells the user they can resize the window or the panel vertically.</para>
        /// </summary>
        Vsize = 9,
        /// <summary>
        /// <para>Show the system's horizontal resize mouse cursor when the user hovers the node. A double-headed horizontal arrow. It tells the user they can resize the window or the panel horizontally.</para>
        /// </summary>
        Hsize = 10,
        /// <summary>
        /// <para>Show the system's window resize mouse cursor when the user hovers the node. The cursor is a double-headed arrow that goes from the bottom left to the top right. It tells the user they can resize the window or the panel both horizontally and vertically.</para>
        /// </summary>
        Bdiagsize = 11,
        /// <summary>
        /// <para>Show the system's window resize mouse cursor when the user hovers the node. The cursor is a double-headed arrow that goes from the top left to the bottom right, the opposite of <see cref="Godot.Control.CursorShape.Bdiagsize"/>. It tells the user they can resize the window or the panel both horizontally and vertically.</para>
        /// </summary>
        Fdiagsize = 12,
        /// <summary>
        /// <para>Show the system's move mouse cursor when the user hovers the node. It shows 2 double-headed arrows at a 90 degree angle. It tells the user they can move a UI element freely.</para>
        /// </summary>
        Move = 13,
        /// <summary>
        /// <para>Show the system's vertical split mouse cursor when the user hovers the node. On Windows, it's the same as <see cref="Godot.Control.CursorShape.Vsize"/>.</para>
        /// </summary>
        Vsplit = 14,
        /// <summary>
        /// <para>Show the system's horizontal split mouse cursor when the user hovers the node. On Windows, it's the same as <see cref="Godot.Control.CursorShape.Hsize"/>.</para>
        /// </summary>
        Hsplit = 15,
        /// <summary>
        /// <para>Show the system's help mouse cursor when the user hovers the node, a question mark.</para>
        /// </summary>
        Help = 16
    }

    public enum LayoutPreset : long
    {
        /// <summary>
        /// <para>Snap all 4 anchors to the top-left of the parent control's bounds. Use with <see cref="Godot.Control.SetAnchorsPreset(Control.LayoutPreset, bool)"/>.</para>
        /// </summary>
        TopLeft = 0,
        /// <summary>
        /// <para>Snap all 4 anchors to the top-right of the parent control's bounds. Use with <see cref="Godot.Control.SetAnchorsPreset(Control.LayoutPreset, bool)"/>.</para>
        /// </summary>
        TopRight = 1,
        /// <summary>
        /// <para>Snap all 4 anchors to the bottom-left of the parent control's bounds. Use with <see cref="Godot.Control.SetAnchorsPreset(Control.LayoutPreset, bool)"/>.</para>
        /// </summary>
        BottomLeft = 2,
        /// <summary>
        /// <para>Snap all 4 anchors to the bottom-right of the parent control's bounds. Use with <see cref="Godot.Control.SetAnchorsPreset(Control.LayoutPreset, bool)"/>.</para>
        /// </summary>
        BottomRight = 3,
        /// <summary>
        /// <para>Snap all 4 anchors to the center of the left edge of the parent control's bounds. Use with <see cref="Godot.Control.SetAnchorsPreset(Control.LayoutPreset, bool)"/>.</para>
        /// </summary>
        CenterLeft = 4,
        /// <summary>
        /// <para>Snap all 4 anchors to the center of the top edge of the parent control's bounds. Use with <see cref="Godot.Control.SetAnchorsPreset(Control.LayoutPreset, bool)"/>.</para>
        /// </summary>
        CenterTop = 5,
        /// <summary>
        /// <para>Snap all 4 anchors to the center of the right edge of the parent control's bounds. Use with <see cref="Godot.Control.SetAnchorsPreset(Control.LayoutPreset, bool)"/>.</para>
        /// </summary>
        CenterRight = 6,
        /// <summary>
        /// <para>Snap all 4 anchors to the center of the bottom edge of the parent control's bounds. Use with <see cref="Godot.Control.SetAnchorsPreset(Control.LayoutPreset, bool)"/>.</para>
        /// </summary>
        CenterBottom = 7,
        /// <summary>
        /// <para>Snap all 4 anchors to the center of the parent control's bounds. Use with <see cref="Godot.Control.SetAnchorsPreset(Control.LayoutPreset, bool)"/>.</para>
        /// </summary>
        Center = 8,
        /// <summary>
        /// <para>Snap all 4 anchors to the left edge of the parent control. The left offset becomes relative to the left edge and the top offset relative to the top left corner of the node's parent. Use with <see cref="Godot.Control.SetAnchorsPreset(Control.LayoutPreset, bool)"/>.</para>
        /// </summary>
        LeftWide = 9,
        /// <summary>
        /// <para>Snap all 4 anchors to the top edge of the parent control. The left offset becomes relative to the top left corner, the top offset relative to the top edge, and the right offset relative to the top right corner of the node's parent. Use with <see cref="Godot.Control.SetAnchorsPreset(Control.LayoutPreset, bool)"/>.</para>
        /// </summary>
        TopWide = 10,
        /// <summary>
        /// <para>Snap all 4 anchors to the right edge of the parent control. The right offset becomes relative to the right edge and the top offset relative to the top right corner of the node's parent. Use with <see cref="Godot.Control.SetAnchorsPreset(Control.LayoutPreset, bool)"/>.</para>
        /// </summary>
        RightWide = 11,
        /// <summary>
        /// <para>Snap all 4 anchors to the bottom edge of the parent control. The left offset becomes relative to the bottom left corner, the bottom offset relative to the bottom edge, and the right offset relative to the bottom right corner of the node's parent. Use with <see cref="Godot.Control.SetAnchorsPreset(Control.LayoutPreset, bool)"/>.</para>
        /// </summary>
        BottomWide = 12,
        /// <summary>
        /// <para>Snap all 4 anchors to a vertical line that cuts the parent control in half. Use with <see cref="Godot.Control.SetAnchorsPreset(Control.LayoutPreset, bool)"/>.</para>
        /// </summary>
        VcenterWide = 13,
        /// <summary>
        /// <para>Snap all 4 anchors to a horizontal line that cuts the parent control in half. Use with <see cref="Godot.Control.SetAnchorsPreset(Control.LayoutPreset, bool)"/>.</para>
        /// </summary>
        HcenterWide = 14,
        /// <summary>
        /// <para>Snap all 4 anchors to the respective corners of the parent control. Set all 4 offsets to 0 after you applied this preset and the <see cref="Godot.Control"/> will fit its parent control. Use with <see cref="Godot.Control.SetAnchorsPreset(Control.LayoutPreset, bool)"/>.</para>
        /// </summary>
        FullRect = 15
    }

    public enum LayoutPresetMode : long
    {
        /// <summary>
        /// <para>The control will be resized to its minimum size.</para>
        /// </summary>
        Minsize = 0,
        /// <summary>
        /// <para>The control's width will not change.</para>
        /// </summary>
        KeepWidth = 1,
        /// <summary>
        /// <para>The control's height will not change.</para>
        /// </summary>
        KeepHeight = 2,
        /// <summary>
        /// <para>The control's size will not change.</para>
        /// </summary>
        KeepSize = 3
    }

    [System.Flags]
    public enum SizeFlags : long
    {
        /// <summary>
        /// <para>Tells the parent <see cref="Godot.Container"/> to align the node with its start, either the top or the left edge. It is mutually exclusive with <see cref="Godot.Control.SizeFlags.Fill"/> and other shrink size flags, but can be used with <see cref="Godot.Control.SizeFlags.Expand"/> in some containers. Use with <see cref="Godot.Control.SizeFlagsHorizontal"/> and <see cref="Godot.Control.SizeFlagsVertical"/>.</para>
        /// <para><b>Note:</b> Setting this flag is equal to not having any size flags.</para>
        /// </summary>
        ShrinkBegin = 0,
        /// <summary>
        /// <para>Tells the parent <see cref="Godot.Container"/> to expand the bounds of this node to fill all the available space without pushing any other node. It is mutually exclusive with shrink size flags. Use with <see cref="Godot.Control.SizeFlagsHorizontal"/> and <see cref="Godot.Control.SizeFlagsVertical"/>.</para>
        /// </summary>
        Fill = 1,
        /// <summary>
        /// <para>Tells the parent <see cref="Godot.Container"/> to let this node take all the available space on the axis you flag. If multiple neighboring nodes are set to expand, they'll share the space based on their stretch ratio. See <see cref="Godot.Control.SizeFlagsStretchRatio"/>. Use with <see cref="Godot.Control.SizeFlagsHorizontal"/> and <see cref="Godot.Control.SizeFlagsVertical"/>.</para>
        /// </summary>
        Expand = 2,
        /// <summary>
        /// <para>Sets the node's size flags to both fill and expand. See <see cref="Godot.Control.SizeFlags.Fill"/> and <see cref="Godot.Control.SizeFlags.Expand"/> for more information.</para>
        /// </summary>
        ExpandFill = 3,
        /// <summary>
        /// <para>Tells the parent <see cref="Godot.Container"/> to center the node in the available space. It is mutually exclusive with <see cref="Godot.Control.SizeFlags.Fill"/> and other shrink size flags, but can be used with <see cref="Godot.Control.SizeFlags.Expand"/> in some containers. Use with <see cref="Godot.Control.SizeFlagsHorizontal"/> and <see cref="Godot.Control.SizeFlagsVertical"/>.</para>
        /// </summary>
        ShrinkCenter = 4,
        /// <summary>
        /// <para>Tells the parent <see cref="Godot.Container"/> to align the node with its end, either the bottom or the right edge. It is mutually exclusive with <see cref="Godot.Control.SizeFlags.Fill"/> and other shrink size flags, but can be used with <see cref="Godot.Control.SizeFlags.Expand"/> in some containers. Use with <see cref="Godot.Control.SizeFlagsHorizontal"/> and <see cref="Godot.Control.SizeFlagsVertical"/>.</para>
        /// </summary>
        ShrinkEnd = 8
    }

    public enum MouseFilterEnum : long
    {
        /// <summary>
        /// <para>The control will receive mouse movement input events and mouse button input events if clicked on through <see cref="Godot.Control._GuiInput(InputEvent)"/>. The control will also receive the <see cref="Godot.Control.MouseEntered"/> and <see cref="Godot.Control.MouseExited"/> signals. These events are automatically marked as handled, and they will not propagate further to other controls. This also results in blocking signals in other controls.</para>
        /// </summary>
        Stop = 0,
        /// <summary>
        /// <para>The control will receive mouse movement input events and mouse button input events if clicked on through <see cref="Godot.Control._GuiInput(InputEvent)"/>. The control will also receive the <see cref="Godot.Control.MouseEntered"/> and <see cref="Godot.Control.MouseExited"/> signals.</para>
        /// <para>If this control does not handle the event, the event will propagate up to its parent control if it has one. The event is bubbled up the node hierarchy until it reaches a non-<see cref="Godot.CanvasItem"/>, a control with <see cref="Godot.Control.MouseFilterEnum.Stop"/>, or a <see cref="Godot.CanvasItem"/> with <see cref="Godot.CanvasItem.TopLevel"/> enabled. This will allow signals to fire in all controls it reaches. If no control handled it, the event will be passed to <see cref="Godot.Node._ShortcutInput(InputEvent)"/> for further processing.</para>
        /// </summary>
        Pass = 1,
        /// <summary>
        /// <para>The control will not receive any mouse movement input events nor mouse button input events through <see cref="Godot.Control._GuiInput(InputEvent)"/>. The control will also not receive the <see cref="Godot.Control.MouseEntered"/> nor <see cref="Godot.Control.MouseExited"/> signals. This will not block other controls from receiving these events or firing the signals. Ignored events will not be handled automatically. If a child has <see cref="Godot.Control.MouseFilterEnum.Pass"/> and an event was passed to this control, the event will further propagate up to the control's parent.</para>
        /// <para><b>Note:</b> If the control has received <see cref="Godot.Control.MouseEntered"/> but not <see cref="Godot.Control.MouseExited"/>, changing the <see cref="Godot.Control.MouseFilter"/> to <see cref="Godot.Control.MouseFilterEnum.Ignore"/> will cause <see cref="Godot.Control.MouseExited"/> to be emitted.</para>
        /// </summary>
        Ignore = 2
    }

    public enum GrowDirection : long
    {
        /// <summary>
        /// <para>The control will grow to the left or top to make up if its minimum size is changed to be greater than its current size on the respective axis.</para>
        /// </summary>
        Begin = 0,
        /// <summary>
        /// <para>The control will grow to the right or bottom to make up if its minimum size is changed to be greater than its current size on the respective axis.</para>
        /// </summary>
        End = 1,
        /// <summary>
        /// <para>The control will grow in both directions equally to make up if its minimum size is changed to be greater than its current size.</para>
        /// </summary>
        Both = 2
    }

    public enum Anchor : long
    {
        /// <summary>
        /// <para>Snaps one of the 4 anchor's sides to the origin of the node's <c>Rect</c>, in the top left. Use it with one of the <c>anchor_*</c> member variables, like <see cref="Godot.Control.AnchorLeft"/>. To change all 4 anchors at once, use <see cref="Godot.Control.SetAnchorsPreset(Control.LayoutPreset, bool)"/>.</para>
        /// </summary>
        Begin = 0,
        /// <summary>
        /// <para>Snaps one of the 4 anchor's sides to the end of the node's <c>Rect</c>, in the bottom right. Use it with one of the <c>anchor_*</c> member variables, like <see cref="Godot.Control.AnchorLeft"/>. To change all 4 anchors at once, use <see cref="Godot.Control.SetAnchorsPreset(Control.LayoutPreset, bool)"/>.</para>
        /// </summary>
        End = 1
    }

    public enum LayoutDirectionEnum : long
    {
        /// <summary>
        /// <para>Automatic layout direction, determined from the parent control layout direction.</para>
        /// </summary>
        Inherited = 0,
        /// <summary>
        /// <para>Automatic layout direction, determined from the current locale. Right-to-left layout direction is automatically used for languages that require it such as Arabic and Hebrew, but only if a valid translation file is loaded for the given language (unless said language is configured as a fallback in <c>ProjectSettings.internationalization/locale/fallback</c>). For all other languages (or if no valid translation file is found by Godot), left-to-right layout direction is used. If using [TextServerFallback] (<c>ProjectSettings.internationalization/rendering/text_driver</c>), left-to-right layout direction is always used regardless of the language. Right-to-left layout direction can also be forced using <c>ProjectSettings.internationalization/rendering/force_right_to_left_layout_direction</c>.</para>
        /// </summary>
        ApplicationLocale = 1,
        /// <summary>
        /// <para>Left-to-right layout direction.</para>
        /// </summary>
        Ltr = 2,
        /// <summary>
        /// <para>Right-to-left layout direction.</para>
        /// </summary>
        Rtl = 3,
        /// <summary>
        /// <para>Automatic layout direction, determined from the system locale. Right-to-left layout direction is automatically used for languages that require it such as Arabic and Hebrew, but only if a valid translation file is loaded for the given language. For all other languages (or if no valid translation file is found by Godot), left-to-right layout direction is used. If using [TextServerFallback] (<c>ProjectSettings.internationalization/rendering/text_driver</c>), left-to-right layout direction is always used regardless of the language.</para>
        /// </summary>
        SystemLocale = 4,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.Control.LayoutDirectionEnum"/> enum.</para>
        /// </summary>
        Max = 5,
        [Obsolete("Use 'Godot.Control.LayoutDirectionEnum.ApplicationLocale' instead.")]
        Locale = 1
    }

    public enum TextDirection : long
    {
        /// <summary>
        /// <para>Text writing direction is the same as layout direction.</para>
        /// </summary>
        Inherited = 3,
        /// <summary>
        /// <para>Automatic text writing direction, determined from the current locale and text content.</para>
        /// </summary>
        Auto = 0,
        /// <summary>
        /// <para>Left-to-right text writing direction.</para>
        /// </summary>
        Ltr = 1,
        /// <summary>
        /// <para>Right-to-left text writing direction.</para>
        /// </summary>
        Rtl = 2
    }

    /// <summary>
    /// <para>Enables whether rendering of <see cref="Godot.CanvasItem"/> based children should be clipped to this control's rectangle. If <see langword="true"/>, parts of a child which would be visibly outside of this control's rectangle will not be rendered and won't receive input.</para>
    /// </summary>
    public bool ClipContents
    {
        get
        {
            return IsClippingContents();
        }
        set
        {
            SetClipContents(value);
        }
    }

    /// <summary>
    /// <para>The minimum size of the node's bounding rectangle. If you set it to a value greater than <c>(0, 0)</c>, the node's bounding rectangle will always have at least this size. Note that <see cref="Godot.Control"/> nodes have their internal minimum size returned by <see cref="Godot.Control.GetMinimumSize()"/>. It depends on the control's contents, like text, textures, or style boxes. The actual minimum size is the maximum value of this property and the internal minimum size (see <see cref="Godot.Control.GetCombinedMinimumSize()"/>).</para>
    /// </summary>
    public Vector2 CustomMinimumSize
    {
        get
        {
            return GetCustomMinimumSize();
        }
        set
        {
            SetCustomMinimumSize(value);
        }
    }

    /// <summary>
    /// <para>Controls layout direction and text writing direction. Right-to-left layouts are necessary for certain languages (e.g. Arabic and Hebrew). See also <see cref="Godot.Control.IsLayoutRtl()"/>.</para>
    /// </summary>
    public Control.LayoutDirectionEnum LayoutDirection
    {
        get
        {
            return GetLayoutDirection();
        }
        set
        {
            SetLayoutDirection(value);
        }
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public int LayoutMode
    {
        get
        {
            return _GetLayoutMode();
        }
        set
        {
            _SetLayoutMode(value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public int AnchorsPreset
    {
        get
        {
            return _GetAnchorsLayoutPreset();
        }
        set
        {
            _SetAnchorsLayoutPreset(value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    /// <summary>
    /// <para>Anchors the left edge of the node to the origin, the center or the end of its parent control. It changes how the left offset updates when the node moves or changes size. You can use one of the <see cref="Godot.Control.Anchor"/> constants for convenience.</para>
    /// </summary>
    public float AnchorLeft
    {
        get
        {
            return GetAnchor((Side)(0));
        }
        set
        {
            _SetAnchor((Side)(0), value);
        }
    }

    /// <summary>
    /// <para>Anchors the top edge of the node to the origin, the center or the end of its parent control. It changes how the top offset updates when the node moves or changes size. You can use one of the <see cref="Godot.Control.Anchor"/> constants for convenience.</para>
    /// </summary>
    public float AnchorTop
    {
        get
        {
            return GetAnchor((Side)(1));
        }
        set
        {
            _SetAnchor((Side)(1), value);
        }
    }

    /// <summary>
    /// <para>Anchors the right edge of the node to the origin, the center or the end of its parent control. It changes how the right offset updates when the node moves or changes size. You can use one of the <see cref="Godot.Control.Anchor"/> constants for convenience.</para>
    /// </summary>
    public float AnchorRight
    {
        get
        {
            return GetAnchor((Side)(2));
        }
        set
        {
            _SetAnchor((Side)(2), value);
        }
    }

    /// <summary>
    /// <para>Anchors the bottom edge of the node to the origin, the center, or the end of its parent control. It changes how the bottom offset updates when the node moves or changes size. You can use one of the <see cref="Godot.Control.Anchor"/> constants for convenience.</para>
    /// </summary>
    public float AnchorBottom
    {
        get
        {
            return GetAnchor((Side)(3));
        }
        set
        {
            _SetAnchor((Side)(3), value);
        }
    }

    /// <summary>
    /// <para>Distance between the node's left edge and its parent control, based on <see cref="Godot.Control.AnchorLeft"/>.</para>
    /// <para>Offsets are often controlled by one or multiple parent <see cref="Godot.Container"/> nodes, so you should not modify them manually if your node is a direct child of a <see cref="Godot.Container"/>. Offsets update automatically when you move or resize the node.</para>
    /// </summary>
    public float OffsetLeft
    {
        get
        {
            return GetOffset((Side)(0));
        }
        set
        {
            SetOffset((Side)(0), value);
        }
    }

    /// <summary>
    /// <para>Distance between the node's top edge and its parent control, based on <see cref="Godot.Control.AnchorTop"/>.</para>
    /// <para>Offsets are often controlled by one or multiple parent <see cref="Godot.Container"/> nodes, so you should not modify them manually if your node is a direct child of a <see cref="Godot.Container"/>. Offsets update automatically when you move or resize the node.</para>
    /// </summary>
    public float OffsetTop
    {
        get
        {
            return GetOffset((Side)(1));
        }
        set
        {
            SetOffset((Side)(1), value);
        }
    }

    /// <summary>
    /// <para>Distance between the node's right edge and its parent control, based on <see cref="Godot.Control.AnchorRight"/>.</para>
    /// <para>Offsets are often controlled by one or multiple parent <see cref="Godot.Container"/> nodes, so you should not modify them manually if your node is a direct child of a <see cref="Godot.Container"/>. Offsets update automatically when you move or resize the node.</para>
    /// </summary>
    public float OffsetRight
    {
        get
        {
            return GetOffset((Side)(2));
        }
        set
        {
            SetOffset((Side)(2), value);
        }
    }

    /// <summary>
    /// <para>Distance between the node's bottom edge and its parent control, based on <see cref="Godot.Control.AnchorBottom"/>.</para>
    /// <para>Offsets are often controlled by one or multiple parent <see cref="Godot.Container"/> nodes, so you should not modify them manually if your node is a direct child of a <see cref="Godot.Container"/>. Offsets update automatically when you move or resize the node.</para>
    /// </summary>
    public float OffsetBottom
    {
        get
        {
            return GetOffset((Side)(3));
        }
        set
        {
            SetOffset((Side)(3), value);
        }
    }

    /// <summary>
    /// <para>Controls the direction on the horizontal axis in which the control should grow if its horizontal minimum size is changed to be greater than its current size, as the control always has to be at least the minimum size.</para>
    /// </summary>
    public Control.GrowDirection GrowHorizontal
    {
        get
        {
            return GetHGrowDirection();
        }
        set
        {
            SetHGrowDirection(value);
        }
    }

    /// <summary>
    /// <para>Controls the direction on the vertical axis in which the control should grow if its vertical minimum size is changed to be greater than its current size, as the control always has to be at least the minimum size.</para>
    /// </summary>
    public Control.GrowDirection GrowVertical
    {
        get
        {
            return GetVGrowDirection();
        }
        set
        {
            SetVGrowDirection(value);
        }
    }

    /// <summary>
    /// <para>The size of the node's bounding rectangle, in the node's coordinate system. <see cref="Godot.Container"/> nodes update this property automatically.</para>
    /// </summary>
    public Vector2 Size
    {
        get
        {
            return GetSize();
        }
        set
        {
            _SetSize(value);
        }
    }

    /// <summary>
    /// <para>The node's position, relative to its containing node. It corresponds to the rectangle's top-left corner. The property is not affected by <see cref="Godot.Control.PivotOffset"/>.</para>
    /// </summary>
    public Vector2 Position
    {
        get
        {
            return GetPosition();
        }
        set
        {
            _SetPosition(value);
        }
    }

    /// <summary>
    /// <para>The node's global position, relative to the world (usually to the <see cref="Godot.CanvasLayer"/>).</para>
    /// </summary>
    public Vector2 GlobalPosition
    {
        get
        {
            return GetGlobalPosition();
        }
        set
        {
            _SetGlobalPosition(value);
        }
    }

    /// <summary>
    /// <para>The node's rotation around its pivot, in radians. See <see cref="Godot.Control.PivotOffset"/> to change the pivot's position.</para>
    /// <para><b>Note:</b> This property is edited in the inspector in degrees. If you want to use degrees in a script, use <see cref="Godot.Control.RotationDegrees"/>.</para>
    /// </summary>
    public float Rotation
    {
        get
        {
            return GetRotation();
        }
        set
        {
            SetRotation(value);
        }
    }

    /// <summary>
    /// <para>Helper property to access <see cref="Godot.Control.Rotation"/> in degrees instead of radians.</para>
    /// </summary>
    public float RotationDegrees
    {
        get
        {
            return GetRotationDegrees();
        }
        set
        {
            SetRotationDegrees(value);
        }
    }

    /// <summary>
    /// <para>The node's scale, relative to its <see cref="Godot.Control.Size"/>. Change this property to scale the node around its <see cref="Godot.Control.PivotOffset"/>. The Control's tooltip will also scale according to this value.</para>
    /// <para><b>Note:</b> This property is mainly intended to be used for animation purposes. To support multiple resolutions in your project, use an appropriate viewport stretch mode as described in the <a href="$DOCS_URL/tutorials/rendering/multiple_resolutions.html">documentation</a> instead of scaling Controls individually.</para>
    /// <para><b>Note:</b> <see cref="Godot.FontFile.Oversampling"/> does <i>not</i> take <see cref="Godot.Control"/> <see cref="Godot.Control.Scale"/> into account. This means that scaling up/down will cause bitmap fonts and rasterized (non-MSDF) dynamic fonts to appear blurry or pixelated. To ensure text remains crisp regardless of scale, you can enable MSDF font rendering by enabling <c>ProjectSettings.gui/theme/default_font_multichannel_signed_distance_field</c> (applies to the default project font only), or enabling <b>Multichannel Signed Distance Field</b> in the import options of a DynamicFont for custom fonts. On system fonts, <see cref="Godot.SystemFont.MultichannelSignedDistanceField"/> can be enabled in the inspector.</para>
    /// <para><b>Note:</b> If the Control node is a child of a <see cref="Godot.Container"/> node, the scale will be reset to <c>Vector2(1, 1)</c> when the scene is instantiated. To set the Control's scale when it's instantiated, wait for one frame using <c>await get_tree().process_frame</c> then set its <see cref="Godot.Control.Scale"/> property.</para>
    /// </summary>
    public Vector2 Scale
    {
        get
        {
            return GetScale();
        }
        set
        {
            SetScale(value);
        }
    }

    /// <summary>
    /// <para>By default, the node's pivot is its top-left corner. When you change its <see cref="Godot.Control.Rotation"/> or <see cref="Godot.Control.Scale"/>, it will rotate or scale around this pivot.</para>
    /// <para>The actual offset is the combined value of this property and <see cref="Godot.Control.PivotOffsetRatio"/>.</para>
    /// </summary>
    public Vector2 PivotOffset
    {
        get
        {
            return GetPivotOffset();
        }
        set
        {
            SetPivotOffset(value);
        }
    }

    /// <summary>
    /// <para>Same as <see cref="Godot.Control.PivotOffset"/>, but expressed as uniform vector, where <c>Vector2(0, 0)</c> is the top-left corner of this control, and <c>Vector2(1, 1)</c> is its bottom-right corner. Set this property to <c>Vector2(0.5, 0.5)</c> to pivot around this control's center.</para>
    /// <para>The actual offset is the combined value of this property and <see cref="Godot.Control.PivotOffset"/>.</para>
    /// </summary>
    public Vector2 PivotOffsetRatio
    {
        get
        {
            return GetPivotOffsetRatio();
        }
        set
        {
            SetPivotOffsetRatio(value);
        }
    }

    /// <summary>
    /// <para>Tells the parent <see cref="Godot.Container"/> nodes how they should resize and place the node on the X axis. Use a combination of the <see cref="Godot.Control.SizeFlags"/> constants to change the flags. See the constants to learn what each does.</para>
    /// </summary>
    public Control.SizeFlags SizeFlagsHorizontal
    {
        get
        {
            return GetHSizeFlags();
        }
        set
        {
            SetHSizeFlags(value);
        }
    }

    /// <summary>
    /// <para>Tells the parent <see cref="Godot.Container"/> nodes how they should resize and place the node on the Y axis. Use a combination of the <see cref="Godot.Control.SizeFlags"/> constants to change the flags. See the constants to learn what each does.</para>
    /// </summary>
    public Control.SizeFlags SizeFlagsVertical
    {
        get
        {
            return GetVSizeFlags();
        }
        set
        {
            SetVSizeFlags(value);
        }
    }

    /// <summary>
    /// <para>If the node and at least one of its neighbors uses the <see cref="Godot.Control.SizeFlags.Expand"/> size flag, the parent <see cref="Godot.Container"/> will let it take more or less space depending on this property. If this node has a stretch ratio of 2 and its neighbor a ratio of 1, this node will take two thirds of the available space.</para>
    /// </summary>
    public float SizeFlagsStretchRatio
    {
        get
        {
            return GetStretchRatio();
        }
        set
        {
            SetStretchRatio(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, automatically converts code line numbers, list indices, <see cref="Godot.SpinBox"/> and <see cref="Godot.ProgressBar"/> values from the Western Arabic (0..9) to the numeral systems used in current locale.</para>
    /// <para><b>Note:</b> Numbers within the text are not automatically converted, it can be done manually, using <see cref="Godot.TextServer.FormatNumber(string, string)"/>.</para>
    /// </summary>
    public bool LocalizeNumeralSystem
    {
        get
        {
            return IsLocalizingNumeralSystem();
        }
        set
        {
            SetLocalizeNumeralSystem(value);
        }
    }

    /// <summary>
    /// <para>Toggles if any text should automatically change to its translated version depending on the current locale.</para>
    /// </summary>
    [Obsolete("Use 'Godot.Node.AutoTranslateMode' and 'Godot.Node.CanAutoTranslate()' instead.")]
    public bool AutoTranslate
    {
        get
        {
            return IsAutoTranslating();
        }
        set
        {
            SetAutoTranslate(value);
        }
    }

    /// <summary>
    /// <para>The default tooltip text. The tooltip appears when the user's mouse cursor stays idle over this control for a few moments, provided that the <see cref="Godot.Control.MouseFilter"/> property is not <see cref="Godot.Control.MouseFilterEnum.Ignore"/>. The time required for the tooltip to appear can be changed with the <c>ProjectSettings.gui/timers/tooltip_delay_sec</c> setting.</para>
    /// <para>This string is the default return value of <see cref="Godot.Control.GetTooltip(Nullable{Vector2})"/>. Override <see cref="Godot.Control._GetTooltip(Vector2)"/> to generate tooltip text dynamically. Override <see cref="Godot.Control._MakeCustomTooltip(string)"/> to customize the tooltip interface and behavior.</para>
    /// <para>The tooltip popup will use either a default implementation, or a custom one that you can provide by overriding <see cref="Godot.Control._MakeCustomTooltip(string)"/>. The default tooltip includes a <see cref="Godot.PopupPanel"/> and <see cref="Godot.Label"/> whose theme properties can be customized using <see cref="Godot.Theme"/> methods with the <c>"TooltipPanel"</c> and <c>"TooltipLabel"</c> respectively. For example:</para>
    /// <para><code>
    /// var styleBox = new StyleBoxFlat();
    /// styleBox.SetBgColor(new Color(1, 1, 0));
    /// styleBox.SetBorderWidthAll(2);
    /// // We assume here that the `Theme` property has been assigned a custom Theme beforehand.
    /// Theme.SetStyleBox("panel", "TooltipPanel", styleBox);
    /// Theme.SetColor("font_color", "TooltipLabel", new Color(0, 1, 1));
    /// </code></para>
    /// </summary>
    public string TooltipText
    {
        get
        {
            return GetTooltipText();
        }
        set
        {
            SetTooltipText(value);
        }
    }

    /// <summary>
    /// <para>Defines if tooltip text should automatically change to its translated version depending on the current locale. Uses the same auto translate mode as this control when set to <see cref="Godot.Node.AutoTranslateModeEnum.Inherit"/>.</para>
    /// <para><b>Note:</b> Tooltips customized using <see cref="Godot.Control._MakeCustomTooltip(string)"/> do not use this auto translate mode automatically.</para>
    /// </summary>
    public Node.AutoTranslateModeEnum TooltipAutoTranslateMode
    {
        get
        {
            return GetTooltipAutoTranslateMode();
        }
        set
        {
            SetTooltipAutoTranslateMode(value);
        }
    }

    /// <summary>
    /// <para>Tells Godot which node it should give focus to if the user presses the left arrow on the keyboard or left on a gamepad by default. You can change the key by editing the <c>ProjectSettings.input/ui_left</c> input action. The node must be a <see cref="Godot.Control"/>. If this property is not set, Godot will give focus to the closest <see cref="Godot.Control"/> to the left of this one.</para>
    /// </summary>
    public NodePath FocusNeighborLeft
    {
        get
        {
            return GetFocusNeighbor((Side)(0));
        }
        set
        {
            SetFocusNeighbor((Side)(0), value);
        }
    }

    /// <summary>
    /// <para>Tells Godot which node it should give focus to if the user presses the top arrow on the keyboard or top on a gamepad by default. You can change the key by editing the <c>ProjectSettings.input/ui_up</c> input action. The node must be a <see cref="Godot.Control"/>. If this property is not set, Godot will give focus to the closest <see cref="Godot.Control"/> to the top of this one.</para>
    /// </summary>
    public NodePath FocusNeighborTop
    {
        get
        {
            return GetFocusNeighbor((Side)(1));
        }
        set
        {
            SetFocusNeighbor((Side)(1), value);
        }
    }

    /// <summary>
    /// <para>Tells Godot which node it should give focus to if the user presses the right arrow on the keyboard or right on a gamepad by default. You can change the key by editing the <c>ProjectSettings.input/ui_right</c> input action. The node must be a <see cref="Godot.Control"/>. If this property is not set, Godot will give focus to the closest <see cref="Godot.Control"/> to the right of this one.</para>
    /// </summary>
    public NodePath FocusNeighborRight
    {
        get
        {
            return GetFocusNeighbor((Side)(2));
        }
        set
        {
            SetFocusNeighbor((Side)(2), value);
        }
    }

    /// <summary>
    /// <para>Tells Godot which node it should give focus to if the user presses the down arrow on the keyboard or down on a gamepad by default. You can change the key by editing the <c>ProjectSettings.input/ui_down</c> input action. The node must be a <see cref="Godot.Control"/>. If this property is not set, Godot will give focus to the closest <see cref="Godot.Control"/> to the bottom of this one.</para>
    /// </summary>
    public NodePath FocusNeighborBottom
    {
        get
        {
            return GetFocusNeighbor((Side)(3));
        }
        set
        {
            SetFocusNeighbor((Side)(3), value);
        }
    }

    /// <summary>
    /// <para>Tells Godot which node it should give focus to if the user presses Tab on a keyboard by default. You can change the key by editing the <c>ProjectSettings.input/ui_focus_next</c> input action.</para>
    /// <para>If this property is not set, Godot will select a "best guess" based on surrounding nodes in the scene tree.</para>
    /// </summary>
    public NodePath FocusNext
    {
        get
        {
            return GetFocusNext();
        }
        set
        {
            SetFocusNext(value);
        }
    }

    /// <summary>
    /// <para>Tells Godot which node it should give focus to if the user presses Shift + Tab on a keyboard by default. You can change the key by editing the <c>ProjectSettings.input/ui_focus_prev</c> input action.</para>
    /// <para>If this property is not set, Godot will select a "best guess" based on surrounding nodes in the scene tree.</para>
    /// </summary>
    public NodePath FocusPrevious
    {
        get
        {
            return GetFocusPrevious();
        }
        set
        {
            SetFocusPrevious(value);
        }
    }

    /// <summary>
    /// <para>Determines which controls can be focused. Only one control can be focused at a time, and the focused control will receive keyboard, gamepad, and mouse events in <see cref="Godot.Control._GuiInput(InputEvent)"/>. Use <see cref="Godot.Control.GetFocusModeWithOverride()"/> to determine if a control can grab focus, since <see cref="Godot.Control.FocusBehaviorRecursive"/> also affects it. See also <see cref="Godot.Control.GrabFocus(bool)"/>.</para>
    /// </summary>
    public Control.FocusModeEnum FocusMode
    {
        get
        {
            return GetFocusMode();
        }
        set
        {
            SetFocusMode(value);
        }
    }

    /// <summary>
    /// <para>Determines which controls can be focused together with <see cref="Godot.Control.FocusMode"/>. See <see cref="Godot.Control.GetFocusModeWithOverride()"/>. Since the default behavior is <see cref="Godot.Control.FocusBehaviorRecursiveEnum.Inherited"/>, this can be used to prevent all children controls from getting focused.</para>
    /// </summary>
    public Control.FocusBehaviorRecursiveEnum FocusBehaviorRecursive
    {
        get
        {
            return GetFocusBehaviorRecursive();
        }
        set
        {
            SetFocusBehaviorRecursive(value);
        }
    }

    /// <summary>
    /// <para>Determines which controls will be able to receive mouse button input events through <see cref="Godot.Control._GuiInput(InputEvent)"/> and the <see cref="Godot.Control.MouseEntered"/>, and <see cref="Godot.Control.MouseExited"/> signals. Also determines how these events should be propagated. See the constants to learn what each does. Use <see cref="Godot.Control.GetMouseFilterWithOverride()"/> to determine if a control can receive mouse input, since <see cref="Godot.Control.MouseBehaviorRecursive"/> also affects it.</para>
    /// </summary>
    public Control.MouseFilterEnum MouseFilter
    {
        get
        {
            return GetMouseFilter();
        }
        set
        {
            SetMouseFilter(value);
        }
    }

    /// <summary>
    /// <para>Determines which controls can receive mouse input together with <see cref="Godot.Control.MouseFilter"/>. See <see cref="Godot.Control.GetMouseFilterWithOverride()"/>. Since the default behavior is <see cref="Godot.Control.MouseBehaviorRecursiveEnum.Inherited"/>, this can be used to prevent all children controls from receiving mouse input.</para>
    /// </summary>
    public Control.MouseBehaviorRecursiveEnum MouseBehaviorRecursive
    {
        get
        {
            return GetMouseBehaviorRecursive();
        }
        set
        {
            SetMouseBehaviorRecursive(value);
        }
    }

    /// <summary>
    /// <para>When enabled, scroll wheel events processed by <see cref="Godot.Control._GuiInput(InputEvent)"/> will be passed to the parent control even if <see cref="Godot.Control.MouseFilter"/> is set to <see cref="Godot.Control.MouseFilterEnum.Stop"/>.</para>
    /// <para>You should disable it on the root of your UI if you do not want scroll events to go to the <see cref="Godot.Node._UnhandledInput(InputEvent)"/> processing.</para>
    /// <para><b>Note:</b> Because this property defaults to <see langword="true"/>, this allows nested scrollable containers to work out of the box.</para>
    /// </summary>
    public bool MouseForcePassScrollEvents
    {
        get
        {
            return IsForcePassScrollEvents();
        }
        set
        {
            SetForcePassScrollEvents(value);
        }
    }

    /// <summary>
    /// <para>The default cursor shape for this control. Useful for Godot plugins and applications or games that use the system's mouse cursors.</para>
    /// <para><b>Note:</b> On Linux, shapes may vary depending on the cursor theme of the system.</para>
    /// </summary>
    public Control.CursorShape MouseDefaultCursorShape
    {
        get
        {
            return GetDefaultCursorShape();
        }
        set
        {
            SetDefaultCursorShape(value);
        }
    }

    /// <summary>
    /// <para>The <see cref="Godot.Node"/> which must be a parent of the focused <see cref="Godot.Control"/> for the shortcut to be activated. If <see langword="null"/>, the shortcut can be activated when any control is focused (a global shortcut). This allows shortcuts to be accepted only when the user has a certain area of the GUI focused.</para>
    /// </summary>
    public Node ShortcutContext
    {
        get
        {
            return GetShortcutContext();
        }
        set
        {
            SetShortcutContext(value);
        }
    }

    /// <summary>
    /// <para>The human-readable node name that is reported to assistive apps.</para>
    /// </summary>
    public string AccessibilityName
    {
        get
        {
            return GetAccessibilityName();
        }
        set
        {
            SetAccessibilityName(value);
        }
    }

    /// <summary>
    /// <para>The human-readable node description that is reported to assistive apps.</para>
    /// </summary>
    public string AccessibilityDescription
    {
        get
        {
            return GetAccessibilityDescription();
        }
        set
        {
            SetAccessibilityDescription(value);
        }
    }

    /// <summary>
    /// <para>The mode with which a live region updates. A live region is a <see cref="Godot.Node"/> that is updated as a result of an external event when the user's focus may be elsewhere.</para>
    /// </summary>
    public DisplayServer.AccessibilityLiveMode AccessibilityLive
    {
        get
        {
            return GetAccessibilityLive();
        }
        set
        {
            SetAccessibilityLive(value);
        }
    }

    /// <summary>
    /// <para>The paths to the nodes which are controlled by this node.</para>
    /// </summary>
    public Godot.Collections.Array<NodePath> AccessibilityControlsNodes
    {
        get
        {
            return GetAccessibilityControlsNodes();
        }
        set
        {
            SetAccessibilityControlsNodes(value);
        }
    }

    /// <summary>
    /// <para>The paths to the nodes which are describing this node.</para>
    /// </summary>
    public Godot.Collections.Array<NodePath> AccessibilityDescribedByNodes
    {
        get
        {
            return GetAccessibilityDescribedByNodes();
        }
        set
        {
            SetAccessibilityDescribedByNodes(value);
        }
    }

    /// <summary>
    /// <para>The paths to the nodes which label this node.</para>
    /// </summary>
    public Godot.Collections.Array<NodePath> AccessibilityLabeledByNodes
    {
        get
        {
            return GetAccessibilityLabeledByNodes();
        }
        set
        {
            SetAccessibilityLabeledByNodes(value);
        }
    }

    /// <summary>
    /// <para>The paths to the nodes which this node flows into.</para>
    /// </summary>
    public Godot.Collections.Array<NodePath> AccessibilityFlowToNodes
    {
        get
        {
            return GetAccessibilityFlowToNodes();
        }
        set
        {
            SetAccessibilityFlowToNodes(value);
        }
    }

    /// <summary>
    /// <para>The <see cref="Godot.Theme"/> resource this node and all its <see cref="Godot.Control"/> and <see cref="Godot.Window"/> children use. If a child node has its own <see cref="Godot.Theme"/> resource set, theme items are merged with child's definitions having higher priority.</para>
    /// <para><b>Note:</b> <see cref="Godot.Window"/> styles will have no effect unless the window is embedded.</para>
    /// </summary>
    public Theme Theme
    {
        get
        {
            return GetTheme();
        }
        set
        {
            SetTheme(value);
        }
    }

    /// <summary>
    /// <para>The name of a theme type variation used by this <see cref="Godot.Control"/> to look up its own theme items. When empty, the class name of the node is used (e.g. <c>Button</c> for the <see cref="Godot.Button"/> control), as well as the class names of all parent classes (in order of inheritance).</para>
    /// <para>When set, this property gives the highest priority to the type of the specified name. This type can in turn extend another type, forming a dependency chain. See <see cref="Godot.Theme.SetTypeVariation(StringName, StringName)"/>. If the theme item cannot be found using this type or its base types, lookup falls back on the class names.</para>
    /// <para><b>Note:</b> To look up <see cref="Godot.Control"/>'s own items use various <c>get_theme_*</c> methods without specifying <c>theme_type</c>.</para>
    /// <para><b>Note:</b> Theme items are looked for in the tree order, from branch to root, where each <see cref="Godot.Control"/> node is checked for its <see cref="Godot.Control.Theme"/> property. The earliest match against any type/class name is returned. The project-level Theme and the default Theme are checked last.</para>
    /// </summary>
    public StringName ThemeTypeVariation
    {
        get
        {
            return GetThemeTypeVariation();
        }
        set
        {
            SetThemeTypeVariation(value);
        }
    }

    private static readonly System.Type CachedType = typeof(Control);

    private static readonly StringName NativeName = "Control";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public Control() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal Control(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal Control(bool memoryOwn) : base(memoryOwn) { }

    /// <summary>
    /// <para>Return the description of the keyboard shortcuts and other contextual help for this control.</para>
    /// </summary>
    public virtual string _AccessibilityGetContextualInfo()
    {
        return default;
    }

    /// <summary>
    /// <para>Godot calls this method to test if <paramref name="data"/> from a control's <see cref="Godot.Control._GetDragData(Vector2)"/> can be dropped at <paramref name="atPosition"/>. <paramref name="atPosition"/> is local to this control.</para>
    /// <para>This method should only be used to test the data. Process the data in <see cref="Godot.Control._DropData(Vector2, Variant)"/>.</para>
    /// <para><b>Note:</b> If the drag was initiated by a keyboard shortcut or <see cref="Godot.Control.AccessibilityDrag()"/>, <paramref name="atPosition"/> is set to <c>Vector2.INF</c>, and the currently selected item/text position should be used as the drop position.</para>
    /// <para><code>
    /// public override bool _CanDropData(Vector2 atPosition, Variant data)
    /// {
    /// 	// Check position if it is relevant to you
    /// 	// Otherwise, just check data
    /// 	return data.VariantType == Variant.Type.Dictionary &amp;&amp; data.AsGodotDictionary().ContainsKey("expected");
    /// }
    /// </code></para>
    /// </summary>
    public virtual unsafe bool _CanDropData(Vector2 atPosition, Variant data)
    {
        return default;
    }

    /// <summary>
    /// <para>Godot calls this method to pass you the <paramref name="data"/> from a control's <see cref="Godot.Control._GetDragData(Vector2)"/> result. Godot first calls <see cref="Godot.Control._CanDropData(Vector2, Variant)"/> to test if <paramref name="data"/> is allowed to drop at <paramref name="atPosition"/> where <paramref name="atPosition"/> is local to this control.</para>
    /// <para><b>Note:</b> If the drag was initiated by a keyboard shortcut or <see cref="Godot.Control.AccessibilityDrag()"/>, <paramref name="atPosition"/> is set to <c>Vector2.INF</c>, and the currently selected item/text position should be used as the drop position.</para>
    /// <para><code>
    /// public override bool _CanDropData(Vector2 atPosition, Variant data)
    /// {
    /// 	return data.VariantType == Variant.Type.Dictionary &amp;&amp; data.AsGodotDictionary().ContainsKey("color");
    /// }
    /// 
    /// public override void _DropData(Vector2 atPosition, Variant data)
    /// {
    /// 	Color color = data.AsGodotDictionary()["color"].AsColor();
    /// }
    /// </code></para>
    /// </summary>
    public virtual unsafe void _DropData(Vector2 atPosition, Variant data)
    {
    }

    /// <summary>
    /// <para>Override this method to return a human-readable description of the position of the child <paramref name="node"/> in the custom container, added to the <see cref="Godot.Control.AccessibilityName"/>.</para>
    /// </summary>
    public virtual string _GetAccessibilityContainerName(Node node)
    {
        return default;
    }

    /// <summary>
    /// <para>Godot calls this method to get data that can be dragged and dropped onto controls that expect drop data. Returns <see langword="null"/> if there is no data to drag. Controls that want to receive drop data should implement <see cref="Godot.Control._CanDropData(Vector2, Variant)"/> and <see cref="Godot.Control._DropData(Vector2, Variant)"/>. <paramref name="atPosition"/> is local to this control. Drag may be forced with <see cref="Godot.Control.ForceDrag(Variant, Control)"/>.</para>
    /// <para>A preview that will follow the mouse that should represent the data can be set with <see cref="Godot.Control.SetDragPreview(Control)"/>. A good time to set the preview is in this method.</para>
    /// <para><b>Note:</b> If the drag was initiated by a keyboard shortcut or <see cref="Godot.Control.AccessibilityDrag()"/>, <paramref name="atPosition"/> is set to <c>Vector2.INF</c>, and the currently selected item/text position should be used as the drag position.</para>
    /// <para><code>
    /// public override Variant _GetDragData(Vector2 atPosition)
    /// {
    /// 	var myData = MakeData(); // This is your custom method generating the drag data.
    /// 	SetDragPreview(MakePreview(myData)); // This is your custom method generating the preview of the drag data.
    /// 	return myData;
    /// }
    /// </code></para>
    /// </summary>
    public virtual unsafe Variant _GetDragData(Vector2 atPosition)
    {
        return default;
    }

    /// <summary>
    /// <para>Virtual method to be implemented by the user. Returns the minimum size for this control. Alternative to <see cref="Godot.Control.CustomMinimumSize"/> for controlling minimum size via code. The actual minimum size will be the max value of these two (in each axis separately).</para>
    /// <para>If not overridden, defaults to <c>Vector2.ZERO</c>.</para>
    /// <para><b>Note:</b> This method will not be called when the script is attached to a <see cref="Godot.Control"/> node that already overrides its minimum size (e.g. <see cref="Godot.Label"/>, <see cref="Godot.Button"/>, <see cref="Godot.PanelContainer"/> etc.). It can only be used with most basic GUI nodes, like <see cref="Godot.Control"/>, <see cref="Godot.Container"/>, <see cref="Godot.Panel"/> etc.</para>
    /// </summary>
    public virtual Vector2 _GetMinimumSize()
    {
        return default;
    }

    /// <summary>
    /// <para>Virtual method to be implemented by the user. Returns the tooltip text for the position <paramref name="atPosition"/> in control's local coordinates, which will typically appear when the cursor is resting over this control. See <see cref="Godot.Control.GetTooltip(Nullable{Vector2})"/>.</para>
    /// <para><b>Note:</b> If this method returns an empty <see cref="string"/> and <see cref="Godot.Control._MakeCustomTooltip(string)"/> is not overridden, no tooltip is displayed.</para>
    /// </summary>
    public virtual unsafe string _GetTooltip(Vector2 atPosition)
    {
        return default;
    }

    /// <summary>
    /// <para>Virtual method to be implemented by the user. Override this method to handle and accept inputs on UI elements. See also <see cref="Godot.Control.AcceptEvent()"/>.</para>
    /// <para><b>Example:</b> Click on the control to print a message:</para>
    /// <para><code>
    /// public override void _GuiInput(InputEvent @event)
    /// {
    /// 	if (@event is InputEventMouseButton mb)
    /// 	{
    /// 		if (mb.ButtonIndex == MouseButton.Left &amp;&amp; mb.Pressed)
    /// 		{
    /// 			GD.Print("I've been clicked D:");
    /// 		}
    /// 	}
    /// }
    /// </code></para>
    /// <para>If the <paramref name="event"/> inherits <see cref="Godot.InputEventMouse"/>, this method will <b>not</b> be called when:</para>
    /// <para>- the control's <see cref="Godot.Control.MouseFilter"/> is set to <see cref="Godot.Control.MouseFilterEnum.Ignore"/>;</para>
    /// <para>- the control is obstructed by another control on top, that doesn't have <see cref="Godot.Control.MouseFilter"/> set to <see cref="Godot.Control.MouseFilterEnum.Ignore"/>;</para>
    /// <para>- the control's parent has <see cref="Godot.Control.MouseFilter"/> set to <see cref="Godot.Control.MouseFilterEnum.Stop"/> or has accepted the event;</para>
    /// <para>- the control's parent has <see cref="Godot.Control.ClipContents"/> enabled and the <paramref name="event"/>'s position is outside the parent's rectangle;</para>
    /// <para>- the <paramref name="event"/>'s position is outside the control (see <see cref="Godot.Control._HasPoint(Vector2)"/>).</para>
    /// <para><b>Note:</b> The <paramref name="event"/>'s position is relative to this control's origin.</para>
    /// </summary>
    public virtual void _GuiInput(InputEvent @event)
    {
    }

    /// <summary>
    /// <para>Virtual method to be implemented by the user. Returns whether the given <paramref name="point"/> is inside this control.</para>
    /// <para>If not overridden, default behavior is checking if the point is within control's Rect.</para>
    /// <para><b>Note:</b> If you want to check if a point is inside the control, you can use <c>Rect2(Vector2.ZERO, size).has_point(point)</c>.</para>
    /// </summary>
    public virtual unsafe bool _HasPoint(Vector2 point)
    {
        return default;
    }

    /// <summary>
    /// <para>Virtual method to be implemented by the user. Returns a <see cref="Godot.Control"/> node that should be used as a tooltip instead of the default one. <paramref name="forText"/> is the return value of <see cref="Godot.Control.GetTooltip(Nullable{Vector2})"/>.</para>
    /// <para>The returned node must be of type <see cref="Godot.Control"/> or Control-derived. It can have child nodes of any type. It is freed when the tooltip disappears, so make sure you always provide a new instance (if you want to use a pre-existing node from your scene tree, you can duplicate it and pass the duplicated instance). When <see langword="null"/> or a non-Control node is returned, the default tooltip will be used instead.</para>
    /// <para>The returned node will be added as child to a <see cref="Godot.PopupPanel"/>, so you should only provide the contents of that panel. That <see cref="Godot.PopupPanel"/> can be themed using <see cref="Godot.Theme.SetStylebox(StringName, StringName, StyleBox)"/> for the type <c>"TooltipPanel"</c> (see <see cref="Godot.Control.TooltipText"/> for an example).</para>
    /// <para><b>Note:</b> The tooltip is shrunk to minimal size. If you want to ensure it's fully visible, you might want to set its <see cref="Godot.Control.CustomMinimumSize"/> to some non-zero value.</para>
    /// <para><b>Note:</b> The node (and any relevant children) should have their <see cref="Godot.CanvasItem.Visible"/> set to <see langword="true"/> when returned, otherwise, the viewport that instantiates it will not be able to calculate its minimum size reliably.</para>
    /// <para><b>Note:</b> If overridden, this method is called even if <see cref="Godot.Control.GetTooltip(Nullable{Vector2})"/> returns an empty string. When this happens with the default tooltip, it is not displayed. To copy this behavior, return <see langword="null"/> in this method when <paramref name="forText"/> is empty.</para>
    /// <para><b>Example:</b> Use a constructed node as a tooltip:</para>
    /// <para><code>
    /// public override Control _MakeCustomTooltip(string forText)
    /// {
    /// 	var label = new Label();
    /// 	label.Text = forText;
    /// 	return label;
    /// }
    /// </code></para>
    /// <para><b>Example:</b> Use a scene instance as a tooltip:</para>
    /// <para><code>
    /// public override Control _MakeCustomTooltip(string forText)
    /// {
    /// 	Node tooltip = ResourceLoader.Load&lt;PackedScene&gt;("res://some_tooltip_scene.tscn").Instantiate();
    /// 	tooltip.GetNode&lt;Label&gt;("Label").Text = forText;
    /// 	return tooltip;
    /// }
    /// </code></para>
    /// </summary>
    public virtual GodotObject _MakeCustomTooltip(string forText)
    {
        return default;
    }

    /// <summary>
    /// <para>User defined BiDi algorithm override function.</para>
    /// <para>Returns an <see cref="Godot.Collections.Array"/> of <see cref="Godot.Vector3I"/> text ranges and text base directions, in the left-to-right order. Ranges should cover full source <paramref name="text"/> without overlaps. BiDi algorithm will be used on each range separately.</para>
    /// </summary>
    public virtual Godot.Collections.Array<Vector3I> _StructuredTextParser(Godot.Collections.Array args, string text)
    {
        return default;
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AcceptEvent, 3218959716ul);

    /// <summary>
    /// <para>Marks an input event as handled. Once you accept an input event, it stops propagating, even to nodes listening to <see cref="Godot.Node._UnhandledInput(InputEvent)"/> or <see cref="Godot.Node._UnhandledKeyInput(InputEvent)"/>.</para>
    /// <para><b>Note:</b> This does not affect the methods in <see cref="Godot.Input"/>, only the way events are propagated.</para>
    /// </summary>
    public void AcceptEvent()
    {
        NativeCalls.godot_icall_0_3(MethodBind0, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMinimumSize, 3341600327ul);

    /// <summary>
    /// <para>Returns the minimum size for this control. See <see cref="Godot.Control.CustomMinimumSize"/>.</para>
    /// </summary>
    public Vector2 GetMinimumSize()
    {
        return NativeCalls.godot_icall_0_37(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCombinedMinimumSize, 3341600327ul);

    /// <summary>
    /// <para>Returns combined minimum size from <see cref="Godot.Control.CustomMinimumSize"/> and <see cref="Godot.Control.GetMinimumSize()"/>.</para>
    /// </summary>
    public Vector2 GetCombinedMinimumSize()
    {
        return NativeCalls.godot_icall_0_37(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName._SetLayoutMode, 1473772542ul);

    internal void _SetLayoutMode(int mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind3, GodotObject.GetPtr(this), mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName._GetLayoutMode, 2491572583ul);

    internal int _GetLayoutMode()
    {
        return NativeCalls.godot_icall_0_39(MethodBind4, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName._SetAnchorsLayoutPreset, 1286410249ul);

    internal void _SetAnchorsLayoutPreset(int preset)
    {
        NativeCalls.godot_icall_1_38(MethodBind5, GodotObject.GetPtr(this), preset);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName._GetAnchorsLayoutPreset, 3905245786ul);

    internal int _GetAnchorsLayoutPreset()
    {
        return NativeCalls.godot_icall_0_39(MethodBind6, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAnchorsPreset, 509135270ul);

    /// <summary>
    /// <para>Sets the anchors to a <paramref name="preset"/> from <see cref="Godot.Control.LayoutPreset"/> enum. This is the code equivalent to using the Layout menu in the 2D editor.</para>
    /// <para>If <paramref name="keepOffsets"/> is <see langword="true"/>, control's position will also be updated.</para>
    /// </summary>
    public void SetAnchorsPreset(Control.LayoutPreset preset, bool keepOffsets = false)
    {
        NativeCalls.godot_icall_2_61(MethodBind7, GodotObject.GetPtr(this), (int)preset, keepOffsets.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetOffsetsPreset, 3724524307ul);

    /// <summary>
    /// <para>Sets the offsets to a <paramref name="preset"/> from <see cref="Godot.Control.LayoutPreset"/> enum. This is the code equivalent to using the Layout menu in the 2D editor.</para>
    /// <para>Use parameter <paramref name="resizeMode"/> with constants from <see cref="Godot.Control.LayoutPresetMode"/> to better determine the resulting size of the <see cref="Godot.Control"/>. Constant size will be ignored if used with presets that change size, e.g. <see cref="Godot.Control.LayoutPreset.LeftWide"/>.</para>
    /// <para>Use parameter <paramref name="margin"/> to determine the gap between the <see cref="Godot.Control"/> and the edges.</para>
    /// </summary>
    public void SetOffsetsPreset(Control.LayoutPreset preset, Control.LayoutPresetMode resizeMode = (Control.LayoutPresetMode)(0), int margin = 0)
    {
        NativeCalls.godot_icall_3_196(MethodBind8, GodotObject.GetPtr(this), (int)preset, (int)resizeMode, margin);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAnchorsAndOffsetsPreset, 3724524307ul);

    /// <summary>
    /// <para>Sets both anchor preset and offset preset. See <see cref="Godot.Control.SetAnchorsPreset(Control.LayoutPreset, bool)"/> and <see cref="Godot.Control.SetOffsetsPreset(Control.LayoutPreset, Control.LayoutPresetMode, int)"/>.</para>
    /// </summary>
    public void SetAnchorsAndOffsetsPreset(Control.LayoutPreset preset, Control.LayoutPresetMode resizeMode = (Control.LayoutPresetMode)(0), int margin = 0)
    {
        NativeCalls.godot_icall_3_196(MethodBind9, GodotObject.GetPtr(this), (int)preset, (int)resizeMode, margin);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName._SetAnchor, 4290182280ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    internal void _SetAnchor(Side side, float anchor)
    {
        NativeCalls.godot_icall_2_69(MethodBind10, GodotObject.GetPtr(this), (int)side, anchor);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAnchor, 2302782885ul);

    /// <summary>
    /// <para>Sets the anchor for the specified <see cref="Godot.Side"/> to <paramref name="anchor"/>. A setter method for <see cref="Godot.Control.AnchorBottom"/>, <see cref="Godot.Control.AnchorLeft"/>, <see cref="Godot.Control.AnchorRight"/> and <see cref="Godot.Control.AnchorTop"/>.</para>
    /// <para>If <paramref name="keepOffset"/> is <see langword="true"/>, offsets aren't updated after this operation.</para>
    /// <para>If <paramref name="pushOppositeAnchor"/> is <see langword="true"/> and the opposite anchor overlaps this anchor, the opposite one will have its value overridden. For example, when setting left anchor to 1 and the right anchor has value of 0.5, the right anchor will also get value of 1. If <paramref name="pushOppositeAnchor"/> was <see langword="false"/>, the left anchor would get value 0.5.</para>
    /// </summary>
    public void SetAnchor(Side side, float anchor, bool keepOffset = false, bool pushOppositeAnchor = true)
    {
        NativeCalls.godot_icall_4_331(MethodBind11, GodotObject.GetPtr(this), (int)side, anchor, keepOffset.ToGodotBool(), pushOppositeAnchor.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAnchor, 2869120046ul);

    /// <summary>
    /// <para>Returns the anchor for the specified <see cref="Godot.Side"/>. A getter method for <see cref="Godot.Control.AnchorBottom"/>, <see cref="Godot.Control.AnchorLeft"/>, <see cref="Godot.Control.AnchorRight"/> and <see cref="Godot.Control.AnchorTop"/>.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetAnchor(Side side)
    {
        return NativeCalls.godot_icall_1_72(MethodBind12, GodotObject.GetPtr(this), (int)side);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetOffset, 4290182280ul);

    /// <summary>
    /// <para>Sets the offset for the specified <see cref="Godot.Side"/> to <paramref name="offset"/>. A setter method for <see cref="Godot.Control.OffsetBottom"/>, <see cref="Godot.Control.OffsetLeft"/>, <see cref="Godot.Control.OffsetRight"/> and <see cref="Godot.Control.OffsetTop"/>.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetOffset(Side side, float offset)
    {
        NativeCalls.godot_icall_2_69(MethodBind13, GodotObject.GetPtr(this), (int)side, offset);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOffset, 2869120046ul);

    /// <summary>
    /// <para>Returns the offset for the specified <see cref="Godot.Side"/>. A getter method for <see cref="Godot.Control.OffsetBottom"/>, <see cref="Godot.Control.OffsetLeft"/>, <see cref="Godot.Control.OffsetRight"/> and <see cref="Godot.Control.OffsetTop"/>.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetOffset(Side offset)
    {
        return NativeCalls.godot_icall_1_72(MethodBind14, GodotObject.GetPtr(this), (int)offset);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAnchorAndOffset, 4031722181ul);

    /// <summary>
    /// <para>Works the same as <see cref="Godot.Control.SetAnchor(Side, float, bool, bool)"/>, but instead of <c>keep_offset</c> argument and automatic update of offset, it allows to set the offset yourself (see <see cref="Godot.Control.SetOffset(Side, float)"/>).</para>
    /// </summary>
    public void SetAnchorAndOffset(Side side, float anchor, float offset, bool pushOppositeAnchor = false)
    {
        NativeCalls.godot_icall_4_332(MethodBind15, GodotObject.GetPtr(this), (int)side, anchor, offset, pushOppositeAnchor.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBegin, 743155724ul);

    /// <summary>
    /// <para>Sets <see cref="Godot.Control.OffsetLeft"/> and <see cref="Godot.Control.OffsetTop"/> at the same time. Equivalent of changing <see cref="Godot.Control.Position"/>.</para>
    /// </summary>
    public unsafe void SetBegin(Vector2 position)
    {
        NativeCalls.godot_icall_1_36(MethodBind16, GodotObject.GetPtr(this), &position);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEnd, 743155724ul);

    /// <summary>
    /// <para>Sets <see cref="Godot.Control.OffsetRight"/> and <see cref="Godot.Control.OffsetBottom"/> at the same time.</para>
    /// </summary>
    public unsafe void SetEnd(Vector2 position)
    {
        NativeCalls.godot_icall_1_36(MethodBind17, GodotObject.GetPtr(this), &position);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPosition, 2436320129ul);

    /// <summary>
    /// <para>Sets the <see cref="Godot.Control.Position"/> to given <paramref name="position"/>.</para>
    /// <para>If <paramref name="keepOffsets"/> is <see langword="true"/>, control's anchors will be updated instead of offsets.</para>
    /// </summary>
    public unsafe void SetPosition(Vector2 position, bool keepOffsets = false)
    {
        NativeCalls.godot_icall_2_333(MethodBind18, GodotObject.GetPtr(this), &position, keepOffsets.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName._SetPosition, 743155724ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    internal unsafe void _SetPosition(Vector2 position)
    {
        NativeCalls.godot_icall_1_36(MethodBind19, GodotObject.GetPtr(this), &position);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSize, 2436320129ul);

    /// <summary>
    /// <para>Sets the size (see <see cref="Godot.Control.Size"/>).</para>
    /// <para>If <paramref name="keepOffsets"/> is <see langword="true"/>, control's anchors will be updated instead of offsets.</para>
    /// </summary>
    public unsafe void SetSize(Vector2 size, bool keepOffsets = false)
    {
        NativeCalls.godot_icall_2_333(MethodBind20, GodotObject.GetPtr(this), &size, keepOffsets.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ResetSize, 3218959716ul);

    /// <summary>
    /// <para>Resets the size to <see cref="Godot.Control.GetCombinedMinimumSize()"/>. This is equivalent to calling <c>set_size(Vector2())</c> (or any size below the minimum).</para>
    /// </summary>
    public void ResetSize()
    {
        NativeCalls.godot_icall_0_3(MethodBind21, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName._SetSize, 743155724ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    internal unsafe void _SetSize(Vector2 size)
    {
        NativeCalls.godot_icall_1_36(MethodBind22, GodotObject.GetPtr(this), &size);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCustomMinimumSize, 743155724ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetCustomMinimumSize(Vector2 size)
    {
        NativeCalls.godot_icall_1_36(MethodBind23, GodotObject.GetPtr(this), &size);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetGlobalPosition, 2436320129ul);

    /// <summary>
    /// <para>Sets the <see cref="Godot.Control.GlobalPosition"/> to given <paramref name="position"/>.</para>
    /// <para>If <paramref name="keepOffsets"/> is <see langword="true"/>, control's anchors will be updated instead of offsets.</para>
    /// </summary>
    public unsafe void SetGlobalPosition(Vector2 position, bool keepOffsets = false)
    {
        NativeCalls.godot_icall_2_333(MethodBind24, GodotObject.GetPtr(this), &position, keepOffsets.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName._SetGlobalPosition, 743155724ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    internal unsafe void _SetGlobalPosition(Vector2 position)
    {
        NativeCalls.godot_icall_1_36(MethodBind25, GodotObject.GetPtr(this), &position);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRotation, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetRotation(float radians)
    {
        NativeCalls.godot_icall_1_67(MethodBind26, GodotObject.GetPtr(this), radians);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRotationDegrees, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetRotationDegrees(float degrees)
    {
        NativeCalls.godot_icall_1_67(MethodBind27, GodotObject.GetPtr(this), degrees);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetScale, 743155724ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetScale(Vector2 scale)
    {
        NativeCalls.godot_icall_1_36(MethodBind28, GodotObject.GetPtr(this), &scale);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPivotOffset, 743155724ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetPivotOffset(Vector2 pivotOffset)
    {
        NativeCalls.godot_icall_1_36(MethodBind29, GodotObject.GetPtr(this), &pivotOffset);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPivotOffsetRatio, 743155724ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetPivotOffsetRatio(Vector2 ratio)
    {
        NativeCalls.godot_icall_1_36(MethodBind30, GodotObject.GetPtr(this), &ratio);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBegin, 3341600327ul);

    /// <summary>
    /// <para>Returns <see cref="Godot.Control.OffsetLeft"/> and <see cref="Godot.Control.OffsetTop"/>. See also <see cref="Godot.Control.Position"/>.</para>
    /// </summary>
    public Vector2 GetBegin()
    {
        return NativeCalls.godot_icall_0_37(MethodBind31, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind32 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEnd, 3341600327ul);

    /// <summary>
    /// <para>Returns <see cref="Godot.Control.OffsetRight"/> and <see cref="Godot.Control.OffsetBottom"/>.</para>
    /// </summary>
    public Vector2 GetEnd()
    {
        return NativeCalls.godot_icall_0_37(MethodBind32, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind33 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPosition, 3341600327ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2 GetPosition()
    {
        return NativeCalls.godot_icall_0_37(MethodBind33, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind34 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSize, 3341600327ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2 GetSize()
    {
        return NativeCalls.godot_icall_0_37(MethodBind34, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind35 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRotation, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetRotation()
    {
        return NativeCalls.godot_icall_0_68(MethodBind35, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind36 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRotationDegrees, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetRotationDegrees()
    {
        return NativeCalls.godot_icall_0_68(MethodBind36, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind37 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetScale, 3341600327ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2 GetScale()
    {
        return NativeCalls.godot_icall_0_37(MethodBind37, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind38 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPivotOffset, 3341600327ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2 GetPivotOffset()
    {
        return NativeCalls.godot_icall_0_37(MethodBind38, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind39 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPivotOffsetRatio, 3341600327ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2 GetPivotOffsetRatio()
    {
        return NativeCalls.godot_icall_0_37(MethodBind39, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind40 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCombinedPivotOffset, 3341600327ul);

    /// <summary>
    /// <para>Returns the combined value of <see cref="Godot.Control.PivotOffset"/> and <see cref="Godot.Control.PivotOffsetRatio"/>, in pixels. The ratio is multiplied by the control's size.</para>
    /// </summary>
    public Vector2 GetCombinedPivotOffset()
    {
        return NativeCalls.godot_icall_0_37(MethodBind40, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind41 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCustomMinimumSize, 3341600327ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2 GetCustomMinimumSize()
    {
        return NativeCalls.godot_icall_0_37(MethodBind41, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind42 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetParentAreaSize, 3341600327ul);

    /// <summary>
    /// <para>Returns the width/height occupied in the parent control.</para>
    /// </summary>
    public Vector2 GetParentAreaSize()
    {
        return NativeCalls.godot_icall_0_37(MethodBind42, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind43 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetGlobalPosition, 3341600327ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2 GetGlobalPosition()
    {
        return NativeCalls.godot_icall_0_37(MethodBind43, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind44 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetScreenPosition, 3341600327ul);

    /// <summary>
    /// <para>Returns the position of this <see cref="Godot.Control"/> in global screen coordinates (i.e. taking window position into account). Mostly useful for editor plugins.</para>
    /// <para>Equivalent to <c>get_screen_transform().origin</c> (see <see cref="Godot.CanvasItem.GetScreenTransform()"/>).</para>
    /// <para><b>Example:</b> Show a popup at the mouse position:</para>
    /// <para><code>
    /// popup_menu.position = get_screen_position() + get_screen_transform().basis_xform(get_local_mouse_position())
    /// 
    /// # The above code is equivalent to:
    /// popup_menu.position = get_screen_transform() * get_local_mouse_position()
    /// 
    /// popup_menu.reset_size()
    /// popup_menu.popup()
    /// </code></para>
    /// </summary>
    public Vector2 GetScreenPosition()
    {
        return NativeCalls.godot_icall_0_37(MethodBind44, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind45 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRect, 1639390495ul);

    /// <summary>
    /// <para>Returns the position and size of the control in the coordinate system of the containing node. See <see cref="Godot.Control.Position"/>, <see cref="Godot.Control.Scale"/> and <see cref="Godot.Control.Size"/>.</para>
    /// <para><b>Note:</b> If <see cref="Godot.Control.Rotation"/> is not the default rotation, the resulting size is not meaningful.</para>
    /// <para><b>Note:</b> Setting <see cref="Godot.Viewport.GuiSnapControlsToPixels"/> to <see langword="true"/> can lead to rounding inaccuracies between the displayed control and the returned <see cref="Godot.Rect2"/>.</para>
    /// </summary>
    public Rect2 GetRect()
    {
        return NativeCalls.godot_icall_0_189(MethodBind45, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind46 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetGlobalRect, 1639390495ul);

    /// <summary>
    /// <para>Returns the position and size of the control relative to the containing canvas. See <see cref="Godot.Control.GlobalPosition"/> and <see cref="Godot.Control.Size"/>.</para>
    /// <para><b>Note:</b> If the node itself or any parent <see cref="Godot.CanvasItem"/> between the node and the canvas have a non default rotation or skew, the resulting size is likely not meaningful.</para>
    /// <para><b>Note:</b> Setting <see cref="Godot.Viewport.GuiSnapControlsToPixels"/> to <see langword="true"/> can lead to rounding inaccuracies between the displayed control and the returned <see cref="Godot.Rect2"/>.</para>
    /// </summary>
    public Rect2 GetGlobalRect()
    {
        return NativeCalls.godot_icall_0_189(MethodBind46, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind47 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFocusMode, 3232914922ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFocusMode(Control.FocusModeEnum mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind47, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind48 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFocusMode, 2132829277ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Control.FocusModeEnum GetFocusMode()
    {
        return (Control.FocusModeEnum)NativeCalls.godot_icall_0_39(MethodBind48, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind49 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFocusModeWithOverride, 2132829277ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.Control.FocusMode"/>, but takes the <see cref="Godot.Control.FocusBehaviorRecursive"/> into account. If <see cref="Godot.Control.FocusBehaviorRecursive"/> is set to <see cref="Godot.Control.FocusBehaviorRecursiveEnum.Disabled"/>, or it is set to <see cref="Godot.Control.FocusBehaviorRecursiveEnum.Inherited"/> and its ancestor is set to <see cref="Godot.Control.FocusBehaviorRecursiveEnum.Disabled"/>, then this returns <see cref="Godot.Control.FocusModeEnum.None"/>.</para>
    /// </summary>
    public Control.FocusModeEnum GetFocusModeWithOverride()
    {
        return (Control.FocusModeEnum)NativeCalls.godot_icall_0_39(MethodBind49, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind50 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFocusBehaviorRecursive, 4256832521ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFocusBehaviorRecursive(Control.FocusBehaviorRecursiveEnum focusBehaviorRecursive)
    {
        NativeCalls.godot_icall_1_38(MethodBind50, GodotObject.GetPtr(this), (int)focusBehaviorRecursive);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind51 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFocusBehaviorRecursive, 2435707181ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Control.FocusBehaviorRecursiveEnum GetFocusBehaviorRecursive()
    {
        return (Control.FocusBehaviorRecursiveEnum)NativeCalls.godot_icall_0_39(MethodBind51, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind52 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasFocus, 3302206351ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if this is the current focused control. See <see cref="Godot.Control.FocusMode"/>.</para>
    /// <para>If <paramref name="ignoreHiddenFocus"/> is <see langword="true"/>, controls that have their focus hidden will always return <see langword="false"/>. Hidden focus happens automatically when controls gain focus via mouse input, or manually using <see cref="Godot.Control.GrabFocus(bool)"/> with <c>hide_focus</c> set to <see langword="true"/>.</para>
    /// </summary>
    public bool HasFocus(bool ignoreHiddenFocus = false)
    {
        return NativeCalls.godot_icall_1_334(MethodBind52, GodotObject.GetPtr(this), ignoreHiddenFocus.ToGodotBool()).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind53 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GrabFocus, 107499316ul);

    /// <summary>
    /// <para>Steal the focus from another control and become the focused control (see <see cref="Godot.Control.FocusMode"/>).</para>
    /// <para>If <paramref name="hideFocus"/> is <see langword="true"/>, the control will not visually show its focused state. Has no effect for <see cref="Godot.LineEdit"/> and <see cref="Godot.TextEdit"/> when <c>ProjectSettings.gui/common/show_focus_state_on_pointer_event</c> is set to <c>Control Supports Keyboard Input</c>, or for any control when it is set to <c>Always</c>.</para>
    /// <para><b>Note:</b> Using this method together with <c>Callable.call_deferred</c> makes it more reliable, especially when called inside <see cref="Godot.Node._Ready()"/>.</para>
    /// </summary>
    public void GrabFocus(bool hideFocus = false)
    {
        NativeCalls.godot_icall_1_14(MethodBind53, GodotObject.GetPtr(this), hideFocus.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind54 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ReleaseFocus, 3218959716ul);

    /// <summary>
    /// <para>Give up the focus. No other control will be able to receive input.</para>
    /// </summary>
    public void ReleaseFocus()
    {
        NativeCalls.godot_icall_0_3(MethodBind54, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind55 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FindPrevValidFocus, 2783021301ul);

    /// <summary>
    /// <para>Finds the previous (above in the tree) <see cref="Godot.Control"/> that can receive the focus.</para>
    /// </summary>
    public Control FindPrevValidFocus()
    {
        return (Control)NativeCalls.godot_icall_0_53(MethodBind55, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind56 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FindNextValidFocus, 2783021301ul);

    /// <summary>
    /// <para>Finds the next (below in the tree) <see cref="Godot.Control"/> that can receive the focus.</para>
    /// </summary>
    public Control FindNextValidFocus()
    {
        return (Control)NativeCalls.godot_icall_0_53(MethodBind56, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind57 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FindValidFocusNeighbor, 1543910170ul);

    /// <summary>
    /// <para>Finds the next <see cref="Godot.Control"/> that can receive the focus on the specified <see cref="Godot.Side"/>.</para>
    /// <para><b>Note:</b> This is different from <see cref="Godot.Control.GetFocusNeighbor(Side)"/>, which returns the path of a specified focus neighbor.</para>
    /// </summary>
    public Control FindValidFocusNeighbor(Side side)
    {
        return (Control)NativeCalls.godot_icall_1_335(MethodBind57, GodotObject.GetPtr(this), (int)side);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind58 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetHSizeFlags, 394851643ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetHSizeFlags(Control.SizeFlags flags)
    {
        NativeCalls.godot_icall_1_38(MethodBind58, GodotObject.GetPtr(this), (int)flags);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind59 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetHSizeFlags, 3781367401ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Control.SizeFlags GetHSizeFlags()
    {
        return (Control.SizeFlags)NativeCalls.godot_icall_0_39(MethodBind59, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind60 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetStretchRatio, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetStretchRatio(float ratio)
    {
        NativeCalls.godot_icall_1_67(MethodBind60, GodotObject.GetPtr(this), ratio);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind61 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetStretchRatio, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetStretchRatio()
    {
        return NativeCalls.godot_icall_0_68(MethodBind61, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind62 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVSizeFlags, 394851643ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetVSizeFlags(Control.SizeFlags flags)
    {
        NativeCalls.godot_icall_1_38(MethodBind62, GodotObject.GetPtr(this), (int)flags);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind63 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVSizeFlags, 3781367401ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Control.SizeFlags GetVSizeFlags()
    {
        return (Control.SizeFlags)NativeCalls.godot_icall_0_39(MethodBind63, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind64 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTheme, 2326690814ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTheme(Theme theme)
    {
        NativeCalls.godot_icall_1_56(MethodBind64, GodotObject.GetPtr(this), GodotObject.GetPtr(theme));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind65 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTheme, 3846893731ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Theme GetTheme()
    {
        return (Theme)NativeCalls.godot_icall_0_63(MethodBind65, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind66 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetThemeTypeVariation, 3304788590ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetThemeTypeVariation(StringName themeType)
    {
        NativeCalls.godot_icall_1_64(MethodBind66, GodotObject.GetPtr(this), (godot_string_name)(themeType?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind67 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetThemeTypeVariation, 2002593661ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public StringName GetThemeTypeVariation()
    {
        return NativeCalls.godot_icall_0_65(MethodBind67, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind68 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BeginBulkThemeOverride, 3218959716ul);

    /// <summary>
    /// <para>Prevents <c>*_theme_*_override</c> methods from emitting <see cref="Godot.Control.NotificationThemeChanged"/> until <see cref="Godot.Control.EndBulkThemeOverride()"/> is called.</para>
    /// </summary>
    public void BeginBulkThemeOverride()
    {
        NativeCalls.godot_icall_0_3(MethodBind68, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind69 = ClassDB_get_method_with_compatibility(NativeName, MethodName.EndBulkThemeOverride, 3218959716ul);

    /// <summary>
    /// <para>Ends a bulk theme override update. See <see cref="Godot.Control.BeginBulkThemeOverride()"/>.</para>
    /// </summary>
    public void EndBulkThemeOverride()
    {
        NativeCalls.godot_icall_0_3(MethodBind69, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind70 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddThemeIconOverride, 1373065600ul);

    /// <summary>
    /// <para>Creates a local override for a theme icon with the specified <paramref name="name"/>. Local overrides always take precedence when fetching theme items for the control. An override can be removed with <see cref="Godot.Control.RemoveThemeIconOverride(StringName)"/>.</para>
    /// <para>See also <see cref="Godot.Control.GetThemeIcon(StringName, StringName)"/>.</para>
    /// </summary>
    public void AddThemeIconOverride(StringName name, Texture2D texture)
    {
        NativeCalls.godot_icall_2_159(MethodBind70, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default), GodotObject.GetPtr(texture));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind71 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddThemeStyleboxOverride, 4188838905ul);

    /// <summary>
    /// <para>Creates a local override for a theme <see cref="Godot.StyleBox"/> with the specified <paramref name="name"/>. Local overrides always take precedence when fetching theme items for the control. An override can be removed with <see cref="Godot.Control.RemoveThemeStyleboxOverride(StringName)"/>.</para>
    /// <para>See also <see cref="Godot.Control.GetThemeStylebox(StringName, StringName)"/>.</para>
    /// <para><b>Example:</b> Modify a property in a <see cref="Godot.StyleBox"/> by duplicating it:</para>
    /// <para><code>
    /// // The snippet below assumes the child node "MyButton" has a StyleBoxFlat assigned.
    /// // Resources are shared across instances, so we need to duplicate it
    /// // to avoid modifying the appearance of all other buttons.
    /// StyleBoxFlat newStyleboxNormal = GetNode&lt;Button&gt;("MyButton").GetThemeStylebox("normal").Duplicate() as StyleBoxFlat;
    /// newStyleboxNormal.BorderWidthTop = 3;
    /// newStyleboxNormal.BorderColor = new Color(0, 1, 0.5f);
    /// GetNode&lt;Button&gt;("MyButton").AddThemeStyleboxOverride("normal", newStyleboxNormal);
    /// // Remove the stylebox override.
    /// GetNode&lt;Button&gt;("MyButton").RemoveThemeStyleboxOverride("normal");
    /// </code></para>
    /// </summary>
    public void AddThemeStyleboxOverride(StringName name, StyleBox stylebox)
    {
        NativeCalls.godot_icall_2_159(MethodBind71, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default), GodotObject.GetPtr(stylebox));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind72 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddThemeFontOverride, 3518018674ul);

    /// <summary>
    /// <para>Creates a local override for a theme <see cref="Godot.Font"/> with the specified <paramref name="name"/>. Local overrides always take precedence when fetching theme items for the control. An override can be removed with <see cref="Godot.Control.RemoveThemeFontOverride(StringName)"/>.</para>
    /// <para>See also <see cref="Godot.Control.GetThemeFont(StringName, StringName)"/>.</para>
    /// </summary>
    public void AddThemeFontOverride(StringName name, Font font)
    {
        NativeCalls.godot_icall_2_159(MethodBind72, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default), GodotObject.GetPtr(font));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind73 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddThemeFontSizeOverride, 2415702435ul);

    /// <summary>
    /// <para>Creates a local override for a theme font size with the specified <paramref name="name"/>. Local overrides always take precedence when fetching theme items for the control. An override can be removed with <see cref="Godot.Control.RemoveThemeFontSizeOverride(StringName)"/>.</para>
    /// <para>See also <see cref="Godot.Control.GetThemeFontSize(StringName, StringName)"/>.</para>
    /// </summary>
    public void AddThemeFontSizeOverride(StringName name, int fontSize)
    {
        NativeCalls.godot_icall_2_154(MethodBind73, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default), fontSize);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind74 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddThemeColorOverride, 4260178595ul);

    /// <summary>
    /// <para>Creates a local override for a theme <see cref="Godot.Color"/> with the specified <paramref name="name"/>. Local overrides always take precedence when fetching theme items for the control. An override can be removed with <see cref="Godot.Control.RemoveThemeColorOverride(StringName)"/>.</para>
    /// <para>See also <see cref="Godot.Control.GetThemeColor(StringName, StringName)"/>.</para>
    /// <para><b>Example:</b> Override a <see cref="Godot.Label"/>'s color and reset it later:</para>
    /// <para><code>
    /// // Given the child Label node "MyLabel", override its font color with a custom value.
    /// GetNode&lt;Label&gt;("MyLabel").AddThemeColorOverride("font_color", new Color(1, 0.5f, 0));
    /// // Reset the font color of the child label.
    /// GetNode&lt;Label&gt;("MyLabel").RemoveThemeColorOverride("font_color");
    /// // Alternatively it can be overridden with the default value from the Label type.
    /// GetNode&lt;Label&gt;("MyLabel").AddThemeColorOverride("font_color", GetThemeColor("font_color", "Label"));
    /// </code></para>
    /// </summary>
    public unsafe void AddThemeColorOverride(StringName name, Color color)
    {
        NativeCalls.godot_icall_2_110(MethodBind74, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default), &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind75 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddThemeConstantOverride, 2415702435ul);

    /// <summary>
    /// <para>Creates a local override for a theme constant with the specified <paramref name="name"/>. Local overrides always take precedence when fetching theme items for the control. An override can be removed with <see cref="Godot.Control.RemoveThemeConstantOverride(StringName)"/>.</para>
    /// <para>See also <see cref="Godot.Control.GetThemeConstant(StringName, StringName)"/>.</para>
    /// </summary>
    public void AddThemeConstantOverride(StringName name, int constant)
    {
        NativeCalls.godot_icall_2_154(MethodBind75, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default), constant);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind76 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveThemeIconOverride, 3304788590ul);

    /// <summary>
    /// <para>Removes a local override for a theme icon with the specified <paramref name="name"/> previously added by <see cref="Godot.Control.AddThemeIconOverride(StringName, Texture2D)"/> or via the Inspector dock.</para>
    /// </summary>
    public void RemoveThemeIconOverride(StringName name)
    {
        NativeCalls.godot_icall_1_64(MethodBind76, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind77 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveThemeStyleboxOverride, 3304788590ul);

    /// <summary>
    /// <para>Removes a local override for a theme <see cref="Godot.StyleBox"/> with the specified <paramref name="name"/> previously added by <see cref="Godot.Control.AddThemeStyleboxOverride(StringName, StyleBox)"/> or via the Inspector dock.</para>
    /// </summary>
    public void RemoveThemeStyleboxOverride(StringName name)
    {
        NativeCalls.godot_icall_1_64(MethodBind77, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind78 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveThemeFontOverride, 3304788590ul);

    /// <summary>
    /// <para>Removes a local override for a theme <see cref="Godot.Font"/> with the specified <paramref name="name"/> previously added by <see cref="Godot.Control.AddThemeFontOverride(StringName, Font)"/> or via the Inspector dock.</para>
    /// </summary>
    public void RemoveThemeFontOverride(StringName name)
    {
        NativeCalls.godot_icall_1_64(MethodBind78, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind79 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveThemeFontSizeOverride, 3304788590ul);

    /// <summary>
    /// <para>Removes a local override for a theme font size with the specified <paramref name="name"/> previously added by <see cref="Godot.Control.AddThemeFontSizeOverride(StringName, int)"/> or via the Inspector dock.</para>
    /// </summary>
    public void RemoveThemeFontSizeOverride(StringName name)
    {
        NativeCalls.godot_icall_1_64(MethodBind79, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind80 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveThemeColorOverride, 3304788590ul);

    /// <summary>
    /// <para>Removes a local override for a theme <see cref="Godot.Color"/> with the specified <paramref name="name"/> previously added by <see cref="Godot.Control.AddThemeColorOverride(StringName, Color)"/> or via the Inspector dock.</para>
    /// </summary>
    public void RemoveThemeColorOverride(StringName name)
    {
        NativeCalls.godot_icall_1_64(MethodBind80, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind81 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveThemeConstantOverride, 3304788590ul);

    /// <summary>
    /// <para>Removes a local override for a theme constant with the specified <paramref name="name"/> previously added by <see cref="Godot.Control.AddThemeConstantOverride(StringName, int)"/> or via the Inspector dock.</para>
    /// </summary>
    public void RemoveThemeConstantOverride(StringName name)
    {
        NativeCalls.godot_icall_1_64(MethodBind81, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind82 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetThemeIcon, 3163973443ul);

    /// <summary>
    /// <para>Returns an icon from the first matching <see cref="Godot.Theme"/> in the tree if that <see cref="Godot.Theme"/> has an icon item with the specified <paramref name="name"/> and <paramref name="themeType"/>.</para>
    /// <para>See <see cref="Godot.Control.GetThemeColor(StringName, StringName)"/> for details.</para>
    /// </summary>
    public Texture2D GetThemeIcon(StringName name, StringName themeType = null)
    {
        return (Texture2D)NativeCalls.godot_icall_2_336(MethodBind82, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default), (godot_string_name)(themeType?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind83 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetThemeStylebox, 604739069ul);

    /// <summary>
    /// <para>Returns a <see cref="Godot.StyleBox"/> from the first matching <see cref="Godot.Theme"/> in the tree if that <see cref="Godot.Theme"/> has a stylebox item with the specified <paramref name="name"/> and <paramref name="themeType"/>.</para>
    /// <para>See <see cref="Godot.Control.GetThemeColor(StringName, StringName)"/> for details.</para>
    /// </summary>
    public StyleBox GetThemeStylebox(StringName name, StringName themeType = null)
    {
        return (StyleBox)NativeCalls.godot_icall_2_336(MethodBind83, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default), (godot_string_name)(themeType?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind84 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetThemeFont, 2826986490ul);

    /// <summary>
    /// <para>Returns a <see cref="Godot.Font"/> from the first matching <see cref="Godot.Theme"/> in the tree if that <see cref="Godot.Theme"/> has a font item with the specified <paramref name="name"/> and <paramref name="themeType"/>.</para>
    /// <para>See <see cref="Godot.Control.GetThemeColor(StringName, StringName)"/> for details.</para>
    /// </summary>
    public Font GetThemeFont(StringName name, StringName themeType = null)
    {
        return (Font)NativeCalls.godot_icall_2_336(MethodBind84, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default), (godot_string_name)(themeType?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind85 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetThemeFontSize, 1327056374ul);

    /// <summary>
    /// <para>Returns a font size from the first matching <see cref="Godot.Theme"/> in the tree if that <see cref="Godot.Theme"/> has a font size item with the specified <paramref name="name"/> and <paramref name="themeType"/>.</para>
    /// <para>See <see cref="Godot.Control.GetThemeColor(StringName, StringName)"/> for details.</para>
    /// </summary>
    public int GetThemeFontSize(StringName name, StringName themeType = null)
    {
        return NativeCalls.godot_icall_2_337(MethodBind85, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default), (godot_string_name)(themeType?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind86 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetThemeColor, 2798751242ul);

    /// <summary>
    /// <para>Returns a <see cref="Godot.Color"/> from the first matching <see cref="Godot.Theme"/> in the tree if that <see cref="Godot.Theme"/> has a color item with the specified <paramref name="name"/> and <paramref name="themeType"/>. If <paramref name="themeType"/> is omitted the class name of the current control is used as the type, or <see cref="Godot.Control.ThemeTypeVariation"/> if it is defined. If the type is a class name its parent classes are also checked, in order of inheritance. If the type is a variation its base types are checked, in order of dependency, then the control's class name and its parent classes are checked.</para>
    /// <para>For the current control its local overrides are considered first (see <see cref="Godot.Control.AddThemeColorOverride(StringName, Color)"/>), then its assigned <see cref="Godot.Control.Theme"/>. After the current control, each parent control and its assigned <see cref="Godot.Control.Theme"/> are considered; controls without a <see cref="Godot.Control.Theme"/> assigned are skipped. If no matching <see cref="Godot.Theme"/> is found in the tree, the custom project <see cref="Godot.Theme"/> (see <c>ProjectSettings.gui/theme/custom</c>) and the default <see cref="Godot.Theme"/> are used (see <see cref="Godot.ThemeDB"/>).</para>
    /// <para><code>
    /// public override void _Ready()
    /// {
    /// 	// Get the font color defined for the current Control's class, if it exists.
    /// 	Modulate = GetThemeColor("font_color");
    /// 	// Get the font color defined for the Button class.
    /// 	Modulate = GetThemeColor("font_color", "Button");
    /// }
    /// </code></para>
    /// </summary>
    public Color GetThemeColor(StringName name, StringName themeType = null)
    {
        return NativeCalls.godot_icall_2_338(MethodBind86, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default), (godot_string_name)(themeType?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind87 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetThemeConstant, 1327056374ul);

    /// <summary>
    /// <para>Returns a constant from the first matching <see cref="Godot.Theme"/> in the tree if that <see cref="Godot.Theme"/> has a constant item with the specified <paramref name="name"/> and <paramref name="themeType"/>.</para>
    /// <para>See <see cref="Godot.Control.GetThemeColor(StringName, StringName)"/> for details.</para>
    /// </summary>
    public int GetThemeConstant(StringName name, StringName themeType = null)
    {
        return NativeCalls.godot_icall_2_337(MethodBind87, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default), (godot_string_name)(themeType?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind88 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasThemeIconOverride, 2619796661ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if there is a local override for a theme icon with the specified <paramref name="name"/> in this <see cref="Godot.Control"/> node.</para>
    /// <para>See <see cref="Godot.Control.AddThemeIconOverride(StringName, Texture2D)"/>.</para>
    /// </summary>
    public bool HasThemeIconOverride(StringName name)
    {
        return NativeCalls.godot_icall_1_105(MethodBind88, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind89 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasThemeStyleboxOverride, 2619796661ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if there is a local override for a theme <see cref="Godot.StyleBox"/> with the specified <paramref name="name"/> in this <see cref="Godot.Control"/> node.</para>
    /// <para>See <see cref="Godot.Control.AddThemeStyleboxOverride(StringName, StyleBox)"/>.</para>
    /// </summary>
    public bool HasThemeStyleboxOverride(StringName name)
    {
        return NativeCalls.godot_icall_1_105(MethodBind89, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind90 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasThemeFontOverride, 2619796661ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if there is a local override for a theme <see cref="Godot.Font"/> with the specified <paramref name="name"/> in this <see cref="Godot.Control"/> node.</para>
    /// <para>See <see cref="Godot.Control.AddThemeFontOverride(StringName, Font)"/>.</para>
    /// </summary>
    public bool HasThemeFontOverride(StringName name)
    {
        return NativeCalls.godot_icall_1_105(MethodBind90, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind91 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasThemeFontSizeOverride, 2619796661ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if there is a local override for a theme font size with the specified <paramref name="name"/> in this <see cref="Godot.Control"/> node.</para>
    /// <para>See <see cref="Godot.Control.AddThemeFontSizeOverride(StringName, int)"/>.</para>
    /// </summary>
    public bool HasThemeFontSizeOverride(StringName name)
    {
        return NativeCalls.godot_icall_1_105(MethodBind91, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind92 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasThemeColorOverride, 2619796661ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if there is a local override for a theme <see cref="Godot.Color"/> with the specified <paramref name="name"/> in this <see cref="Godot.Control"/> node.</para>
    /// <para>See <see cref="Godot.Control.AddThemeColorOverride(StringName, Color)"/>.</para>
    /// </summary>
    public bool HasThemeColorOverride(StringName name)
    {
        return NativeCalls.godot_icall_1_105(MethodBind92, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind93 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasThemeConstantOverride, 2619796661ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if there is a local override for a theme constant with the specified <paramref name="name"/> in this <see cref="Godot.Control"/> node.</para>
    /// <para>See <see cref="Godot.Control.AddThemeConstantOverride(StringName, int)"/>.</para>
    /// </summary>
    public bool HasThemeConstantOverride(StringName name)
    {
        return NativeCalls.godot_icall_1_105(MethodBind93, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind94 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasThemeIcon, 866386512ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if there is a matching <see cref="Godot.Theme"/> in the tree that has an icon item with the specified <paramref name="name"/> and <paramref name="themeType"/>.</para>
    /// <para>See <see cref="Godot.Control.GetThemeColor(StringName, StringName)"/> for details.</para>
    /// </summary>
    public bool HasThemeIcon(StringName name, StringName themeType = null)
    {
        return NativeCalls.godot_icall_2_160(MethodBind94, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default), (godot_string_name)(themeType?.NativeValue ?? default)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind95 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasThemeStylebox, 866386512ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if there is a matching <see cref="Godot.Theme"/> in the tree that has a stylebox item with the specified <paramref name="name"/> and <paramref name="themeType"/>.</para>
    /// <para>See <see cref="Godot.Control.GetThemeColor(StringName, StringName)"/> for details.</para>
    /// </summary>
    public bool HasThemeStylebox(StringName name, StringName themeType = null)
    {
        return NativeCalls.godot_icall_2_160(MethodBind95, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default), (godot_string_name)(themeType?.NativeValue ?? default)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind96 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasThemeFont, 866386512ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if there is a matching <see cref="Godot.Theme"/> in the tree that has a font item with the specified <paramref name="name"/> and <paramref name="themeType"/>.</para>
    /// <para>See <see cref="Godot.Control.GetThemeColor(StringName, StringName)"/> for details.</para>
    /// </summary>
    public bool HasThemeFont(StringName name, StringName themeType = null)
    {
        return NativeCalls.godot_icall_2_160(MethodBind96, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default), (godot_string_name)(themeType?.NativeValue ?? default)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind97 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasThemeFontSize, 866386512ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if there is a matching <see cref="Godot.Theme"/> in the tree that has a font size item with the specified <paramref name="name"/> and <paramref name="themeType"/>.</para>
    /// <para>See <see cref="Godot.Control.GetThemeColor(StringName, StringName)"/> for details.</para>
    /// </summary>
    public bool HasThemeFontSize(StringName name, StringName themeType = null)
    {
        return NativeCalls.godot_icall_2_160(MethodBind97, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default), (godot_string_name)(themeType?.NativeValue ?? default)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind98 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasThemeColor, 866386512ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if there is a matching <see cref="Godot.Theme"/> in the tree that has a color item with the specified <paramref name="name"/> and <paramref name="themeType"/>.</para>
    /// <para>See <see cref="Godot.Control.GetThemeColor(StringName, StringName)"/> for details.</para>
    /// </summary>
    public bool HasThemeColor(StringName name, StringName themeType = null)
    {
        return NativeCalls.godot_icall_2_160(MethodBind98, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default), (godot_string_name)(themeType?.NativeValue ?? default)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind99 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasThemeConstant, 866386512ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if there is a matching <see cref="Godot.Theme"/> in the tree that has a constant item with the specified <paramref name="name"/> and <paramref name="themeType"/>.</para>
    /// <para>See <see cref="Godot.Control.GetThemeColor(StringName, StringName)"/> for details.</para>
    /// </summary>
    public bool HasThemeConstant(StringName name, StringName themeType = null)
    {
        return NativeCalls.godot_icall_2_160(MethodBind99, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default), (godot_string_name)(themeType?.NativeValue ?? default)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind100 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetThemeDefaultBaseScale, 1740695150ul);

    /// <summary>
    /// <para>Returns the default base scale value from the first matching <see cref="Godot.Theme"/> in the tree if that <see cref="Godot.Theme"/> has a valid <see cref="Godot.Theme.DefaultBaseScale"/> value.</para>
    /// <para>See <see cref="Godot.Control.GetThemeColor(StringName, StringName)"/> for details.</para>
    /// </summary>
    public float GetThemeDefaultBaseScale()
    {
        return NativeCalls.godot_icall_0_68(MethodBind100, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind101 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetThemeDefaultFont, 3229501585ul);

    /// <summary>
    /// <para>Returns the default font from the first matching <see cref="Godot.Theme"/> in the tree if that <see cref="Godot.Theme"/> has a valid <see cref="Godot.Theme.DefaultFont"/> value.</para>
    /// <para>See <see cref="Godot.Control.GetThemeColor(StringName, StringName)"/> for details.</para>
    /// </summary>
    public Font GetThemeDefaultFont()
    {
        return (Font)NativeCalls.godot_icall_0_63(MethodBind101, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind102 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetThemeDefaultFontSize, 3905245786ul);

    /// <summary>
    /// <para>Returns the default font size value from the first matching <see cref="Godot.Theme"/> in the tree if that <see cref="Godot.Theme"/> has a valid <see cref="Godot.Theme.DefaultFontSize"/> value.</para>
    /// <para>See <see cref="Godot.Control.GetThemeColor(StringName, StringName)"/> for details.</para>
    /// </summary>
    public int GetThemeDefaultFontSize()
    {
        return NativeCalls.godot_icall_0_39(MethodBind102, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind103 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetParentControl, 2783021301ul);

    /// <summary>
    /// <para>Returns the parent control node.</para>
    /// </summary>
    public Control GetParentControl()
    {
        return (Control)NativeCalls.godot_icall_0_53(MethodBind103, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind104 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetHGrowDirection, 2022385301ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetHGrowDirection(Control.GrowDirection direction)
    {
        NativeCalls.godot_icall_1_38(MethodBind104, GodotObject.GetPtr(this), (int)direction);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind105 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetHGrowDirection, 3635610155ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Control.GrowDirection GetHGrowDirection()
    {
        return (Control.GrowDirection)NativeCalls.godot_icall_0_39(MethodBind105, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind106 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVGrowDirection, 2022385301ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetVGrowDirection(Control.GrowDirection direction)
    {
        NativeCalls.godot_icall_1_38(MethodBind106, GodotObject.GetPtr(this), (int)direction);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind107 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVGrowDirection, 3635610155ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Control.GrowDirection GetVGrowDirection()
    {
        return (Control.GrowDirection)NativeCalls.godot_icall_0_39(MethodBind107, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind108 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTooltipAutoTranslateMode, 776149714ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTooltipAutoTranslateMode(Node.AutoTranslateModeEnum mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind108, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind109 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTooltipAutoTranslateMode, 2498906432ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Node.AutoTranslateModeEnum GetTooltipAutoTranslateMode()
    {
        return (Node.AutoTranslateModeEnum)NativeCalls.godot_icall_0_39(MethodBind109, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind110 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTooltipText, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTooltipText(string hint)
    {
        NativeCalls.godot_icall_1_57(MethodBind110, GodotObject.GetPtr(this), hint);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind111 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTooltipText, 201670096ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetTooltipText()
    {
        return NativeCalls.godot_icall_0_58(MethodBind111, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind112 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTooltip, 2895288280ul);

    /// <summary>
    /// <para>Returns the tooltip text for the position <paramref name="atPosition"/> in control's local coordinates, which will typically appear when the cursor is resting over this control. By default, it returns <see cref="Godot.Control.TooltipText"/>.</para>
    /// <para>This method can be overridden to customize its behavior. See <see cref="Godot.Control._GetTooltip(Vector2)"/>.</para>
    /// <para><b>Note:</b> If this method returns an empty <see cref="string"/> and <see cref="Godot.Control._MakeCustomTooltip(string)"/> is not overridden, no tooltip is displayed.</para>
    /// </summary>
    /// <param name="atPosition">If the parameter is null, then the default value is <c>new Vector2(0.0f, 0.0f)</c>.</param>
    public unsafe string GetTooltip(Nullable<Vector2> atPosition = null)
    {
        Vector2 atPositionOrDefVal = atPosition.HasValue ? atPosition.Value : new Vector2(0.0f, 0.0f);
        return NativeCalls.godot_icall_1_339(MethodBind112, GodotObject.GetPtr(this), &atPositionOrDefVal);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind113 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDefaultCursorShape, 217062046ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDefaultCursorShape(Control.CursorShape shape)
    {
        NativeCalls.godot_icall_1_38(MethodBind113, GodotObject.GetPtr(this), (int)shape);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind114 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDefaultCursorShape, 2359535750ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Control.CursorShape GetDefaultCursorShape()
    {
        return (Control.CursorShape)NativeCalls.godot_icall_0_39(MethodBind114, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind115 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCursorShape, 1395773853ul);

    /// <summary>
    /// <para>Returns the mouse cursor shape for this control when hovered over <paramref name="position"/> in local coordinates. For most controls, this is the same as <see cref="Godot.Control.MouseDefaultCursorShape"/>, but some built-in controls implement more complex logic.</para>
    /// </summary>
    /// <param name="position">If the parameter is null, then the default value is <c>new Vector2(0.0f, 0.0f)</c>.</param>
    public unsafe Control.CursorShape GetCursorShape(Nullable<Vector2> position = null)
    {
        Vector2 positionOrDefVal = position.HasValue ? position.Value : new Vector2(0.0f, 0.0f);
        return (Control.CursorShape)NativeCalls.godot_icall_1_340(MethodBind115, GodotObject.GetPtr(this), &positionOrDefVal);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind116 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFocusNeighbor, 2024461774ul);

    /// <summary>
    /// <para>Sets the focus neighbor for the specified <see cref="Godot.Side"/> to the <see cref="Godot.Control"/> at <paramref name="neighbor"/> node path. A setter method for <see cref="Godot.Control.FocusNeighborBottom"/>, <see cref="Godot.Control.FocusNeighborLeft"/>, <see cref="Godot.Control.FocusNeighborRight"/> and <see cref="Godot.Control.FocusNeighborTop"/>.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFocusNeighbor(Side side, NodePath neighbor)
    {
        NativeCalls.godot_icall_2_75(MethodBind116, GodotObject.GetPtr(this), (int)side, (godot_node_path)(neighbor?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind117 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFocusNeighbor, 2757935761ul);

    /// <summary>
    /// <para>Returns the focus neighbor for the specified <see cref="Godot.Side"/>. A getter method for <see cref="Godot.Control.FocusNeighborBottom"/>, <see cref="Godot.Control.FocusNeighborLeft"/>, <see cref="Godot.Control.FocusNeighborRight"/> and <see cref="Godot.Control.FocusNeighborTop"/>.</para>
    /// <para><b>Note:</b> To find the next <see cref="Godot.Control"/> on the specific <see cref="Godot.Side"/>, even if a neighbor is not assigned, use <see cref="Godot.Control.FindValidFocusNeighbor(Side)"/>.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public NodePath GetFocusNeighbor(Side side)
    {
        return NativeCalls.godot_icall_1_74(MethodBind117, GodotObject.GetPtr(this), (int)side);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind118 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFocusNext, 1348162250ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFocusNext(NodePath next)
    {
        NativeCalls.godot_icall_1_123(MethodBind118, GodotObject.GetPtr(this), (godot_node_path)(next?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind119 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFocusNext, 4075236667ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public NodePath GetFocusNext()
    {
        return NativeCalls.godot_icall_0_124(MethodBind119, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind120 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFocusPrevious, 1348162250ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFocusPrevious(NodePath previous)
    {
        NativeCalls.godot_icall_1_123(MethodBind120, GodotObject.GetPtr(this), (godot_node_path)(previous?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind121 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFocusPrevious, 4075236667ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public NodePath GetFocusPrevious()
    {
        return NativeCalls.godot_icall_0_124(MethodBind121, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind122 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ForceDrag, 3191844692ul);

    /// <summary>
    /// <para>Forces drag and bypasses <see cref="Godot.Control._GetDragData(Vector2)"/> and <see cref="Godot.Control.SetDragPreview(Control)"/> by passing <paramref name="data"/> and <paramref name="preview"/>. Drag will start even if the mouse is neither over nor pressed on this control.</para>
    /// <para>The methods <see cref="Godot.Control._CanDropData(Vector2, Variant)"/> and <see cref="Godot.Control._DropData(Vector2, Variant)"/> must be implemented on controls that want to receive drop data.</para>
    /// </summary>
    public void ForceDrag(Variant data, Control preview)
    {
        NativeCalls.godot_icall_2_341(MethodBind122, GodotObject.GetPtr(this), data, GodotObject.GetPtr(preview));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind123 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AccessibilityDrag, 3218959716ul);

    /// <summary>
    /// <para>Starts drag-and-drop operation without using a mouse.</para>
    /// </summary>
    public void AccessibilityDrag()
    {
        NativeCalls.godot_icall_0_3(MethodBind123, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind124 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AccessibilityDrop, 3218959716ul);

    /// <summary>
    /// <para>Ends drag-and-drop operation without using a mouse.</para>
    /// </summary>
    public void AccessibilityDrop()
    {
        NativeCalls.godot_icall_0_3(MethodBind124, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind125 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAccessibilityName, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAccessibilityName(string name)
    {
        NativeCalls.godot_icall_1_57(MethodBind125, GodotObject.GetPtr(this), name);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind126 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAccessibilityName, 201670096ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetAccessibilityName()
    {
        return NativeCalls.godot_icall_0_58(MethodBind126, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind127 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAccessibilityDescription, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAccessibilityDescription(string description)
    {
        NativeCalls.godot_icall_1_57(MethodBind127, GodotObject.GetPtr(this), description);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind128 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAccessibilityDescription, 201670096ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetAccessibilityDescription()
    {
        return NativeCalls.godot_icall_0_58(MethodBind128, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind129 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAccessibilityLive, 1720261470ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAccessibilityLive(DisplayServer.AccessibilityLiveMode mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind129, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind130 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAccessibilityLive, 3311037003ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public DisplayServer.AccessibilityLiveMode GetAccessibilityLive()
    {
        return (DisplayServer.AccessibilityLiveMode)NativeCalls.godot_icall_0_39(MethodBind130, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind131 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAccessibilityControlsNodes, 381264803ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAccessibilityControlsNodes(Godot.Collections.Array<NodePath> nodePath)
    {
        NativeCalls.godot_icall_1_138(MethodBind131, GodotObject.GetPtr(this), (godot_array)(nodePath ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind132 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAccessibilityControlsNodes, 3995934104ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Godot.Collections.Array<NodePath> GetAccessibilityControlsNodes()
    {
        return new Godot.Collections.Array<NodePath>(NativeCalls.godot_icall_0_120(MethodBind132, GodotObject.GetPtr(this)));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind133 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAccessibilityDescribedByNodes, 381264803ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAccessibilityDescribedByNodes(Godot.Collections.Array<NodePath> nodePath)
    {
        NativeCalls.godot_icall_1_138(MethodBind133, GodotObject.GetPtr(this), (godot_array)(nodePath ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind134 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAccessibilityDescribedByNodes, 3995934104ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Godot.Collections.Array<NodePath> GetAccessibilityDescribedByNodes()
    {
        return new Godot.Collections.Array<NodePath>(NativeCalls.godot_icall_0_120(MethodBind134, GodotObject.GetPtr(this)));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind135 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAccessibilityLabeledByNodes, 381264803ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAccessibilityLabeledByNodes(Godot.Collections.Array<NodePath> nodePath)
    {
        NativeCalls.godot_icall_1_138(MethodBind135, GodotObject.GetPtr(this), (godot_array)(nodePath ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind136 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAccessibilityLabeledByNodes, 3995934104ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Godot.Collections.Array<NodePath> GetAccessibilityLabeledByNodes()
    {
        return new Godot.Collections.Array<NodePath>(NativeCalls.godot_icall_0_120(MethodBind136, GodotObject.GetPtr(this)));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind137 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAccessibilityFlowToNodes, 381264803ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAccessibilityFlowToNodes(Godot.Collections.Array<NodePath> nodePath)
    {
        NativeCalls.godot_icall_1_138(MethodBind137, GodotObject.GetPtr(this), (godot_array)(nodePath ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind138 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAccessibilityFlowToNodes, 3995934104ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Godot.Collections.Array<NodePath> GetAccessibilityFlowToNodes()
    {
        return new Godot.Collections.Array<NodePath>(NativeCalls.godot_icall_0_120(MethodBind138, GodotObject.GetPtr(this)));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind139 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMouseFilter, 3891156122ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMouseFilter(Control.MouseFilterEnum filter)
    {
        NativeCalls.godot_icall_1_38(MethodBind139, GodotObject.GetPtr(this), (int)filter);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind140 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMouseFilter, 1572545674ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Control.MouseFilterEnum GetMouseFilter()
    {
        return (Control.MouseFilterEnum)NativeCalls.godot_icall_0_39(MethodBind140, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind141 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMouseFilterWithOverride, 1572545674ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.Control.MouseFilter"/>, but takes the <see cref="Godot.Control.MouseBehaviorRecursive"/> into account. If <see cref="Godot.Control.MouseBehaviorRecursive"/> is set to <see cref="Godot.Control.MouseBehaviorRecursiveEnum.Disabled"/>, or it is set to <see cref="Godot.Control.MouseBehaviorRecursiveEnum.Inherited"/> and its ancestor is set to <see cref="Godot.Control.MouseBehaviorRecursiveEnum.Disabled"/>, then this returns <see cref="Godot.Control.MouseFilterEnum.Ignore"/>.</para>
    /// </summary>
    public Control.MouseFilterEnum GetMouseFilterWithOverride()
    {
        return (Control.MouseFilterEnum)NativeCalls.godot_icall_0_39(MethodBind141, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind142 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMouseBehaviorRecursive, 849284636ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMouseBehaviorRecursive(Control.MouseBehaviorRecursiveEnum mouseBehaviorRecursive)
    {
        NativeCalls.godot_icall_1_38(MethodBind142, GodotObject.GetPtr(this), (int)mouseBehaviorRecursive);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind143 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMouseBehaviorRecursive, 3779367402ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Control.MouseBehaviorRecursiveEnum GetMouseBehaviorRecursive()
    {
        return (Control.MouseBehaviorRecursiveEnum)NativeCalls.godot_icall_0_39(MethodBind143, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind144 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetForcePassScrollEvents, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetForcePassScrollEvents(bool forcePassScrollEvents)
    {
        NativeCalls.godot_icall_1_14(MethodBind144, GodotObject.GetPtr(this), forcePassScrollEvents.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind145 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsForcePassScrollEvents, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsForcePassScrollEvents()
    {
        return NativeCalls.godot_icall_0_15(MethodBind145, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind146 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetClipContents, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetClipContents(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind146, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind147 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsClippingContents, 2240911060ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsClippingContents()
    {
        return NativeCalls.godot_icall_0_15(MethodBind147, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind148 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GrabClickFocus, 3218959716ul);

    /// <summary>
    /// <para>Creates an <see cref="Godot.InputEventMouseButton"/> that attempts to click the control. If the event is received, the control gains focus.</para>
    /// <para><code>
    /// public override void _Process(double delta)
    /// {
    /// 	GrabClickFocus(); // When clicking another Control node, this node will be clicked instead.
    /// }
    /// </code></para>
    /// </summary>
    public void GrabClickFocus()
    {
        NativeCalls.godot_icall_0_3(MethodBind148, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind149 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDragForwarding, 1076571380ul);

    /// <summary>
    /// <para>Sets the given callables to be used instead of the control's own drag-and-drop virtual methods. If a callable is empty, its respective virtual method is used as normal.</para>
    /// <para>The arguments for each callable should be exactly the same as their respective virtual methods, which would be:</para>
    /// <para>- <paramref name="dragFunc"/> corresponds to <see cref="Godot.Control._GetDragData(Vector2)"/> and requires a <see cref="Godot.Vector2"/>;</para>
    /// <para>- <paramref name="canDropFunc"/> corresponds to <see cref="Godot.Control._CanDropData(Vector2, Variant)"/> and requires both a <see cref="Godot.Vector2"/> and a <see cref="Godot.Variant"/>;</para>
    /// <para>- <paramref name="dropFunc"/> corresponds to <see cref="Godot.Control._DropData(Vector2, Variant)"/> and requires both a <see cref="Godot.Vector2"/> and a <see cref="Godot.Variant"/>.</para>
    /// </summary>
    public void SetDragForwarding(Callable dragFunc, Callable canDropFunc, Callable dropFunc)
    {
        NativeCalls.godot_icall_3_342(MethodBind149, GodotObject.GetPtr(this), dragFunc, canDropFunc, dropFunc);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind150 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDragPreview, 1496901182ul);

    /// <summary>
    /// <para>Shows the given control at the mouse pointer. A good time to call this method is in <see cref="Godot.Control._GetDragData(Vector2)"/>. The control must not be in the scene tree. You should not free the control, and you should not keep a reference to the control beyond the duration of the drag. It will be deleted automatically after the drag has ended.</para>
    /// <para><code>
    /// [Export]
    /// private Color _color = new Color(1, 0, 0, 1);
    /// 
    /// public override Variant _GetDragData(Vector2 atPosition)
    /// {
    /// 	// Use a control that is not in the tree
    /// 	var cpb = new ColorPickerButton();
    /// 	cpb.Color = _color;
    /// 	cpb.Size = new Vector2(50, 50);
    /// 	SetDragPreview(cpb);
    /// 	return _color;
    /// }
    /// </code></para>
    /// </summary>
    public void SetDragPreview(Control control)
    {
        NativeCalls.godot_icall_1_56(MethodBind150, GodotObject.GetPtr(this), GodotObject.GetPtr(control));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind151 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsDragSuccessful, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if a drag operation is successful. Alternative to <see cref="Godot.Viewport.GuiIsDragSuccessful()"/>.</para>
    /// <para>Best used with <see cref="Godot.Node.NotificationDragEnd"/>.</para>
    /// </summary>
    public bool IsDragSuccessful()
    {
        return NativeCalls.godot_icall_0_15(MethodBind151, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind152 = ClassDB_get_method_with_compatibility(NativeName, MethodName.WarpMouse, 743155724ul);

    /// <summary>
    /// <para>Moves the mouse cursor to <paramref name="position"/>, relative to <see cref="Godot.Control.Position"/> of this <see cref="Godot.Control"/>.</para>
    /// <para><b>Note:</b> <see cref="Godot.Control.WarpMouse(Vector2)"/> is only supported on Windows, macOS and Linux. It has no effect on Android, iOS and Web.</para>
    /// </summary>
    public unsafe void WarpMouse(Vector2 position)
    {
        NativeCalls.godot_icall_1_36(MethodBind152, GodotObject.GetPtr(this), &position);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind153 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetShortcutContext, 1078189570ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetShortcutContext(Node node)
    {
        NativeCalls.godot_icall_1_56(MethodBind153, GodotObject.GetPtr(this), GodotObject.GetPtr(node));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind154 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetShortcutContext, 3160264692ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Node GetShortcutContext()
    {
        return (Node)NativeCalls.godot_icall_0_53(MethodBind154, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind155 = ClassDB_get_method_with_compatibility(NativeName, MethodName.UpdateMinimumSize, 3218959716ul);

    /// <summary>
    /// <para>Invalidates the size cache in this node and in parent nodes up to top level. Intended to be used with <see cref="Godot.Control.GetMinimumSize()"/> when the return value is changed. Setting <see cref="Godot.Control.CustomMinimumSize"/> directly calls this method automatically.</para>
    /// </summary>
    public void UpdateMinimumSize()
    {
        NativeCalls.godot_icall_0_3(MethodBind155, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind156 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLayoutDirection, 3310692370ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetLayoutDirection(Control.LayoutDirectionEnum direction)
    {
        NativeCalls.godot_icall_1_38(MethodBind156, GodotObject.GetPtr(this), (int)direction);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind157 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLayoutDirection, 1546772008ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Control.LayoutDirectionEnum GetLayoutDirection()
    {
        return (Control.LayoutDirectionEnum)NativeCalls.godot_icall_0_39(MethodBind157, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind158 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsLayoutRtl, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the layout is right-to-left. See also <see cref="Godot.Control.LayoutDirection"/>.</para>
    /// </summary>
    public bool IsLayoutRtl()
    {
        return NativeCalls.godot_icall_0_15(MethodBind158, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind159 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAutoTranslate, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAutoTranslate(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind159, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind160 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsAutoTranslating, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsAutoTranslating()
    {
        return NativeCalls.godot_icall_0_15(MethodBind160, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind161 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLocalizeNumeralSystem, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetLocalizeNumeralSystem(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind161, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind162 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsLocalizingNumeralSystem, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsLocalizingNumeralSystem()
    {
        return NativeCalls.godot_icall_0_15(MethodBind162, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind163 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GrabFocus, 3218959716ul);

    /// <summary>
    /// <para>Steal the focus from another control and become the focused control (see <see cref="Godot.Control.FocusMode"/>).</para>
    /// <para>If <paramref name="hideFocus"/> is <see langword="true"/>, the control will not visually show its focused state. Has no effect for <see cref="Godot.LineEdit"/> and <see cref="Godot.TextEdit"/> when <c>ProjectSettings.gui/common/show_focus_state_on_pointer_event</c> is set to <c>Control Supports Keyboard Input</c>, or for any control when it is set to <c>Always</c>.</para>
    /// <para><b>Note:</b> Using this method together with <c>Callable.call_deferred</c> makes it more reliable, especially when called inside <see cref="Godot.Node._Ready()"/>.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void GrabFocus()
    {
        NativeCalls.godot_icall_0_3(MethodBind163, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind164 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasFocus, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if this is the current focused control. See <see cref="Godot.Control.FocusMode"/>.</para>
    /// <para>If <paramref name="ignoreHiddenFocus"/> is <see langword="true"/>, controls that have their focus hidden will always return <see langword="false"/>. Hidden focus happens automatically when controls gain focus via mouse input, or manually using <see cref="Godot.Control.GrabFocus(bool)"/> with <c>hide_focus</c> set to <see langword="true"/>.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool HasFocus()
    {
        return NativeCalls.godot_icall_0_15(MethodBind164, GodotObject.GetPtr(this)).ToBool();
    }

    /// <summary>
    /// <para>Emitted when the control changes size.</para>
    /// </summary>
    public event Action Resized
    {
        add => Connect(SignalName.Resized, Callable.From(value));
        remove => Disconnect(SignalName.Resized, Callable.From(value));
    }

    protected void EmitSignalResized()
    {
        EmitSignal(SignalName.Resized);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.Control.GuiInput"/> event of a <see cref="Godot.Control"/> class.
    /// </summary>
    public delegate void GuiInputEventHandler(InputEvent @event);

    private static void GuiInputTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((GuiInputEventHandler)delegateObj)(VariantUtils.ConvertTo<InputEvent>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when the node receives an <see cref="Godot.InputEvent"/>.</para>
    /// </summary>
    public unsafe event GuiInputEventHandler GuiInput
    {
        add => Connect(SignalName.GuiInput, Callable.CreateWithUnsafeTrampoline(value, &GuiInputTrampoline));
        remove => Disconnect(SignalName.GuiInput, Callable.CreateWithUnsafeTrampoline(value, &GuiInputTrampoline));
    }

    protected void EmitSignalGuiInput(InputEvent @event)
    {
        EmitSignal(SignalName.GuiInput, @event);
    }

    /// <summary>
    /// <para>Emitted when the mouse cursor enters the control's (or any child control's) visible area, that is not occluded behind other Controls or Windows, provided its <see cref="Godot.Control.MouseFilter"/> lets the event reach it and regardless if it's currently focused or not.</para>
    /// <para><b>Note:</b> <see cref="Godot.CanvasItem.ZIndex"/> doesn't affect, which Control receives the signal.</para>
    /// </summary>
    public event Action MouseEntered
    {
        add => Connect(SignalName.MouseEntered, Callable.From(value));
        remove => Disconnect(SignalName.MouseEntered, Callable.From(value));
    }

    protected void EmitSignalMouseEntered()
    {
        EmitSignal(SignalName.MouseEntered);
    }

    /// <summary>
    /// <para>Emitted when the mouse cursor leaves the control's (and all child control's) visible area, that is not occluded behind other Controls or Windows, provided its <see cref="Godot.Control.MouseFilter"/> lets the event reach it and regardless if it's currently focused or not.</para>
    /// <para><b>Note:</b> <see cref="Godot.CanvasItem.ZIndex"/> doesn't affect, which Control receives the signal.</para>
    /// <para><b>Note:</b> If you want to check whether the mouse truly left the area, ignoring any top nodes, you can use code like this:</para>
    /// <para><code>
    /// func _on_mouse_exited():
    /// 	if not Rect2(Vector2(), size).has_point(get_local_mouse_position()):
    /// 		# Not hovering over area.
    /// </code></para>
    /// </summary>
    public event Action MouseExited
    {
        add => Connect(SignalName.MouseExited, Callable.From(value));
        remove => Disconnect(SignalName.MouseExited, Callable.From(value));
    }

    protected void EmitSignalMouseExited()
    {
        EmitSignal(SignalName.MouseExited);
    }

    /// <summary>
    /// <para>Emitted when the node gains focus.</para>
    /// </summary>
    public event Action FocusEntered
    {
        add => Connect(SignalName.FocusEntered, Callable.From(value));
        remove => Disconnect(SignalName.FocusEntered, Callable.From(value));
    }

    protected void EmitSignalFocusEntered()
    {
        EmitSignal(SignalName.FocusEntered);
    }

    /// <summary>
    /// <para>Emitted when the node loses focus.</para>
    /// </summary>
    public event Action FocusExited
    {
        add => Connect(SignalName.FocusExited, Callable.From(value));
        remove => Disconnect(SignalName.FocusExited, Callable.From(value));
    }

    protected void EmitSignalFocusExited()
    {
        EmitSignal(SignalName.FocusExited);
    }

    /// <summary>
    /// <para>Emitted when one of the size flags changes. See <see cref="Godot.Control.SizeFlagsHorizontal"/> and <see cref="Godot.Control.SizeFlagsVertical"/>.</para>
    /// </summary>
    public event Action SizeFlagsChanged
    {
        add => Connect(SignalName.SizeFlagsChanged, Callable.From(value));
        remove => Disconnect(SignalName.SizeFlagsChanged, Callable.From(value));
    }

    protected void EmitSignalSizeFlagsChanged()
    {
        EmitSignal(SignalName.SizeFlagsChanged);
    }

    /// <summary>
    /// <para>Emitted when the node's minimum size changes.</para>
    /// </summary>
    public event Action MinimumSizeChanged
    {
        add => Connect(SignalName.MinimumSizeChanged, Callable.From(value));
        remove => Disconnect(SignalName.MinimumSizeChanged, Callable.From(value));
    }

    protected void EmitSignalMinimumSizeChanged()
    {
        EmitSignal(SignalName.MinimumSizeChanged);
    }

    /// <summary>
    /// <para>Emitted when the <see cref="Godot.Control.NotificationThemeChanged"/> notification is sent.</para>
    /// </summary>
    public event Action ThemeChanged
    {
        add => Connect(SignalName.ThemeChanged, Callable.From(value));
        remove => Disconnect(SignalName.ThemeChanged, Callable.From(value));
    }

    protected void EmitSignalThemeChanged()
    {
        EmitSignal(SignalName.ThemeChanged);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__accessibility_get_contextual_info = "_AccessibilityGetContextualInfo";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__can_drop_data = "_CanDropData";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__drop_data = "_DropData";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_accessibility_container_name = "_GetAccessibilityContainerName";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_drag_data = "_GetDragData";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_minimum_size = "_GetMinimumSize";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_tooltip = "_GetTooltip";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__gui_input = "_GuiInput";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__has_point = "_HasPoint";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__make_custom_tooltip = "_MakeCustomTooltip";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__structured_text_parser = "_StructuredTextParser";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_resized = "Resized";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_gui_input = "GuiInput";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_mouse_entered = "MouseEntered";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_mouse_exited = "MouseExited";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_focus_entered = "FocusEntered";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_focus_exited = "FocusExited";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_size_flags_changed = "SizeFlagsChanged";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_minimum_size_changed = "MinimumSizeChanged";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_theme_changed = "ThemeChanged";

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
        if ((method == MethodProxyName__accessibility_get_contextual_info || method == MethodName._AccessibilityGetContextualInfo) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__accessibility_get_contextual_info.NativeValue))
        {
            var callRet = _AccessibilityGetContextualInfo();
            ret = VariantUtils.CreateFrom<string>(callRet);
            return true;
        }
        if ((method == MethodProxyName__can_drop_data || method == MethodName._CanDropData) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__can_drop_data.NativeValue))
        {
            var callRet = _CanDropData(VariantUtils.ConvertTo<Vector2>(args[0]), VariantUtils.ConvertTo<Variant>(args[1]));
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__drop_data || method == MethodName._DropData) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__drop_data.NativeValue))
        {
            _DropData(VariantUtils.ConvertTo<Vector2>(args[0]), VariantUtils.ConvertTo<Variant>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__get_accessibility_container_name || method == MethodName._GetAccessibilityContainerName) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_accessibility_container_name.NativeValue))
        {
            var callRet = _GetAccessibilityContainerName(VariantUtils.ConvertTo<Node>(args[0]));
            ret = VariantUtils.CreateFrom<string>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_drag_data || method == MethodName._GetDragData) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_drag_data.NativeValue))
        {
            var callRet = _GetDragData(VariantUtils.ConvertTo<Vector2>(args[0]));
            ret = VariantUtils.CreateFrom<Variant>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_minimum_size || method == MethodName._GetMinimumSize) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_minimum_size.NativeValue))
        {
            var callRet = _GetMinimumSize();
            ret = VariantUtils.CreateFrom<Vector2>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_tooltip || method == MethodName._GetTooltip) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_tooltip.NativeValue))
        {
            var callRet = _GetTooltip(VariantUtils.ConvertTo<Vector2>(args[0]));
            ret = VariantUtils.CreateFrom<string>(callRet);
            return true;
        }
        if ((method == MethodProxyName__gui_input || method == MethodName._GuiInput) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__gui_input.NativeValue))
        {
            _GuiInput(VariantUtils.ConvertTo<InputEvent>(args[0]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__has_point || method == MethodName._HasPoint) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__has_point.NativeValue))
        {
            var callRet = _HasPoint(VariantUtils.ConvertTo<Vector2>(args[0]));
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__make_custom_tooltip || method == MethodName._MakeCustomTooltip) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__make_custom_tooltip.NativeValue))
        {
            var callRet = _MakeCustomTooltip(VariantUtils.ConvertTo<string>(args[0]));
            ret = VariantUtils.CreateFrom<GodotObject>(callRet);
            return true;
        }
        if ((method == MethodProxyName__structured_text_parser || method == MethodName._StructuredTextParser) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__structured_text_parser.NativeValue))
        {
            var callRet = _StructuredTextParser(VariantUtils.ConvertTo<Godot.Collections.Array>(args[0]), VariantUtils.ConvertTo<string>(args[1]));
            ret = VariantUtils.CreateFromArray(callRet);
            return true;
        }
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
        if (method == MethodName._AccessibilityGetContextualInfo)
        {
            if (HasGodotClassMethod(MethodProxyName__accessibility_get_contextual_info.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._CanDropData)
        {
            if (HasGodotClassMethod(MethodProxyName__can_drop_data.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._DropData)
        {
            if (HasGodotClassMethod(MethodProxyName__drop_data.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetAccessibilityContainerName)
        {
            if (HasGodotClassMethod(MethodProxyName__get_accessibility_container_name.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetDragData)
        {
            if (HasGodotClassMethod(MethodProxyName__get_drag_data.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetMinimumSize)
        {
            if (HasGodotClassMethod(MethodProxyName__get_minimum_size.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetTooltip)
        {
            if (HasGodotClassMethod(MethodProxyName__get_tooltip.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GuiInput)
        {
            if (HasGodotClassMethod(MethodProxyName__gui_input.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._HasPoint)
        {
            if (HasGodotClassMethod(MethodProxyName__has_point.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._MakeCustomTooltip)
        {
            if (HasGodotClassMethod(MethodProxyName__make_custom_tooltip.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._StructuredTextParser)
        {
            if (HasGodotClassMethod(MethodProxyName__structured_text_parser.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
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
        if (signal == SignalName.Resized)
        {
            if (HasGodotClassSignal(SignalProxyName_resized.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.GuiInput)
        {
            if (HasGodotClassSignal(SignalProxyName_gui_input.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.MouseEntered)
        {
            if (HasGodotClassSignal(SignalProxyName_mouse_entered.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.MouseExited)
        {
            if (HasGodotClassSignal(SignalProxyName_mouse_exited.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.FocusEntered)
        {
            if (HasGodotClassSignal(SignalProxyName_focus_entered.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.FocusExited)
        {
            if (HasGodotClassSignal(SignalProxyName_focus_exited.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.SizeFlagsChanged)
        {
            if (HasGodotClassSignal(SignalProxyName_size_flags_changed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.MinimumSizeChanged)
        {
            if (HasGodotClassSignal(SignalProxyName_minimum_size_changed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.ThemeChanged)
        {
            if (HasGodotClassSignal(SignalProxyName_theme_changed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        return base.HasGodotClassSignal(signal);
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : CanvasItem.PropertyName
    {
        /// <summary>
        /// Cached name for the 'clip_contents' property.
        /// </summary>
        public static readonly StringName ClipContents = "clip_contents";
        /// <summary>
        /// Cached name for the 'custom_minimum_size' property.
        /// </summary>
        public static readonly StringName CustomMinimumSize = "custom_minimum_size";
        /// <summary>
        /// Cached name for the 'layout_direction' property.
        /// </summary>
        public static readonly StringName LayoutDirection = "layout_direction";
        /// <summary>
        /// Cached name for the 'layout_mode' property.
        /// </summary>
        public static readonly StringName LayoutMode = "layout_mode";
        /// <summary>
        /// Cached name for the 'anchors_preset' property.
        /// </summary>
        public static readonly StringName AnchorsPreset = "anchors_preset";
        /// <summary>
        /// Cached name for the 'anchor_left' property.
        /// </summary>
        public static readonly StringName AnchorLeft = "anchor_left";
        /// <summary>
        /// Cached name for the 'anchor_top' property.
        /// </summary>
        public static readonly StringName AnchorTop = "anchor_top";
        /// <summary>
        /// Cached name for the 'anchor_right' property.
        /// </summary>
        public static readonly StringName AnchorRight = "anchor_right";
        /// <summary>
        /// Cached name for the 'anchor_bottom' property.
        /// </summary>
        public static readonly StringName AnchorBottom = "anchor_bottom";
        /// <summary>
        /// Cached name for the 'offset_left' property.
        /// </summary>
        public static readonly StringName OffsetLeft = "offset_left";
        /// <summary>
        /// Cached name for the 'offset_top' property.
        /// </summary>
        public static readonly StringName OffsetTop = "offset_top";
        /// <summary>
        /// Cached name for the 'offset_right' property.
        /// </summary>
        public static readonly StringName OffsetRight = "offset_right";
        /// <summary>
        /// Cached name for the 'offset_bottom' property.
        /// </summary>
        public static readonly StringName OffsetBottom = "offset_bottom";
        /// <summary>
        /// Cached name for the 'grow_horizontal' property.
        /// </summary>
        public static readonly StringName GrowHorizontal = "grow_horizontal";
        /// <summary>
        /// Cached name for the 'grow_vertical' property.
        /// </summary>
        public static readonly StringName GrowVertical = "grow_vertical";
        /// <summary>
        /// Cached name for the 'size' property.
        /// </summary>
        public static readonly StringName Size = "size";
        /// <summary>
        /// Cached name for the 'position' property.
        /// </summary>
        public static readonly StringName Position = "position";
        /// <summary>
        /// Cached name for the 'global_position' property.
        /// </summary>
        public static readonly StringName GlobalPosition = "global_position";
        /// <summary>
        /// Cached name for the 'rotation' property.
        /// </summary>
        public static readonly StringName Rotation = "rotation";
        /// <summary>
        /// Cached name for the 'rotation_degrees' property.
        /// </summary>
        public static readonly StringName RotationDegrees = "rotation_degrees";
        /// <summary>
        /// Cached name for the 'scale' property.
        /// </summary>
        public static readonly StringName Scale = "scale";
        /// <summary>
        /// Cached name for the 'pivot_offset' property.
        /// </summary>
        public static readonly StringName PivotOffset = "pivot_offset";
        /// <summary>
        /// Cached name for the 'pivot_offset_ratio' property.
        /// </summary>
        public static readonly StringName PivotOffsetRatio = "pivot_offset_ratio";
        /// <summary>
        /// Cached name for the 'size_flags_horizontal' property.
        /// </summary>
        public static readonly StringName SizeFlagsHorizontal = "size_flags_horizontal";
        /// <summary>
        /// Cached name for the 'size_flags_vertical' property.
        /// </summary>
        public static readonly StringName SizeFlagsVertical = "size_flags_vertical";
        /// <summary>
        /// Cached name for the 'size_flags_stretch_ratio' property.
        /// </summary>
        public static readonly StringName SizeFlagsStretchRatio = "size_flags_stretch_ratio";
        /// <summary>
        /// Cached name for the 'localize_numeral_system' property.
        /// </summary>
        public static readonly StringName LocalizeNumeralSystem = "localize_numeral_system";
        /// <summary>
        /// Cached name for the 'auto_translate' property.
        /// </summary>
        public static readonly StringName AutoTranslate = "auto_translate";
        /// <summary>
        /// Cached name for the 'tooltip_text' property.
        /// </summary>
        public static readonly StringName TooltipText = "tooltip_text";
        /// <summary>
        /// Cached name for the 'tooltip_auto_translate_mode' property.
        /// </summary>
        public static readonly StringName TooltipAutoTranslateMode = "tooltip_auto_translate_mode";
        /// <summary>
        /// Cached name for the 'focus_neighbor_left' property.
        /// </summary>
        public static readonly StringName FocusNeighborLeft = "focus_neighbor_left";
        /// <summary>
        /// Cached name for the 'focus_neighbor_top' property.
        /// </summary>
        public static readonly StringName FocusNeighborTop = "focus_neighbor_top";
        /// <summary>
        /// Cached name for the 'focus_neighbor_right' property.
        /// </summary>
        public static readonly StringName FocusNeighborRight = "focus_neighbor_right";
        /// <summary>
        /// Cached name for the 'focus_neighbor_bottom' property.
        /// </summary>
        public static readonly StringName FocusNeighborBottom = "focus_neighbor_bottom";
        /// <summary>
        /// Cached name for the 'focus_next' property.
        /// </summary>
        public static readonly StringName FocusNext = "focus_next";
        /// <summary>
        /// Cached name for the 'focus_previous' property.
        /// </summary>
        public static readonly StringName FocusPrevious = "focus_previous";
        /// <summary>
        /// Cached name for the 'focus_mode' property.
        /// </summary>
        public static readonly StringName FocusMode = "focus_mode";
        /// <summary>
        /// Cached name for the 'focus_behavior_recursive' property.
        /// </summary>
        public static readonly StringName FocusBehaviorRecursive = "focus_behavior_recursive";
        /// <summary>
        /// Cached name for the 'mouse_filter' property.
        /// </summary>
        public static readonly StringName MouseFilter = "mouse_filter";
        /// <summary>
        /// Cached name for the 'mouse_behavior_recursive' property.
        /// </summary>
        public static readonly StringName MouseBehaviorRecursive = "mouse_behavior_recursive";
        /// <summary>
        /// Cached name for the 'mouse_force_pass_scroll_events' property.
        /// </summary>
        public static readonly StringName MouseForcePassScrollEvents = "mouse_force_pass_scroll_events";
        /// <summary>
        /// Cached name for the 'mouse_default_cursor_shape' property.
        /// </summary>
        public static readonly StringName MouseDefaultCursorShape = "mouse_default_cursor_shape";
        /// <summary>
        /// Cached name for the 'shortcut_context' property.
        /// </summary>
        public static readonly StringName ShortcutContext = "shortcut_context";
        /// <summary>
        /// Cached name for the 'accessibility_name' property.
        /// </summary>
        public static readonly StringName AccessibilityName = "accessibility_name";
        /// <summary>
        /// Cached name for the 'accessibility_description' property.
        /// </summary>
        public static readonly StringName AccessibilityDescription = "accessibility_description";
        /// <summary>
        /// Cached name for the 'accessibility_live' property.
        /// </summary>
        public static readonly StringName AccessibilityLive = "accessibility_live";
        /// <summary>
        /// Cached name for the 'accessibility_controls_nodes' property.
        /// </summary>
        public static readonly StringName AccessibilityControlsNodes = "accessibility_controls_nodes";
        /// <summary>
        /// Cached name for the 'accessibility_described_by_nodes' property.
        /// </summary>
        public static readonly StringName AccessibilityDescribedByNodes = "accessibility_described_by_nodes";
        /// <summary>
        /// Cached name for the 'accessibility_labeled_by_nodes' property.
        /// </summary>
        public static readonly StringName AccessibilityLabeledByNodes = "accessibility_labeled_by_nodes";
        /// <summary>
        /// Cached name for the 'accessibility_flow_to_nodes' property.
        /// </summary>
        public static readonly StringName AccessibilityFlowToNodes = "accessibility_flow_to_nodes";
        /// <summary>
        /// Cached name for the 'theme' property.
        /// </summary>
        public static readonly StringName Theme = "theme";
        /// <summary>
        /// Cached name for the 'theme_type_variation' property.
        /// </summary>
        public static readonly StringName ThemeTypeVariation = "theme_type_variation";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : CanvasItem.MethodName
    {
        /// <summary>
        /// Cached name for the '_accessibility_get_contextual_info' method.
        /// </summary>
        public static readonly StringName _AccessibilityGetContextualInfo = "_accessibility_get_contextual_info";
        /// <summary>
        /// Cached name for the '_can_drop_data' method.
        /// </summary>
        public static readonly StringName _CanDropData = "_can_drop_data";
        /// <summary>
        /// Cached name for the '_drop_data' method.
        /// </summary>
        public static readonly StringName _DropData = "_drop_data";
        /// <summary>
        /// Cached name for the '_get_accessibility_container_name' method.
        /// </summary>
        public static readonly StringName _GetAccessibilityContainerName = "_get_accessibility_container_name";
        /// <summary>
        /// Cached name for the '_get_drag_data' method.
        /// </summary>
        public static readonly StringName _GetDragData = "_get_drag_data";
        /// <summary>
        /// Cached name for the '_get_minimum_size' method.
        /// </summary>
        public static readonly StringName _GetMinimumSize = "_get_minimum_size";
        /// <summary>
        /// Cached name for the '_get_tooltip' method.
        /// </summary>
        public static readonly StringName _GetTooltip = "_get_tooltip";
        /// <summary>
        /// Cached name for the '_gui_input' method.
        /// </summary>
        public static readonly StringName _GuiInput = "_gui_input";
        /// <summary>
        /// Cached name for the '_has_point' method.
        /// </summary>
        public static readonly StringName _HasPoint = "_has_point";
        /// <summary>
        /// Cached name for the '_make_custom_tooltip' method.
        /// </summary>
        public static readonly StringName _MakeCustomTooltip = "_make_custom_tooltip";
        /// <summary>
        /// Cached name for the '_structured_text_parser' method.
        /// </summary>
        public static readonly StringName _StructuredTextParser = "_structured_text_parser";
        /// <summary>
        /// Cached name for the 'accept_event' method.
        /// </summary>
        public static readonly StringName AcceptEvent = "accept_event";
        /// <summary>
        /// Cached name for the 'get_minimum_size' method.
        /// </summary>
        public static readonly StringName GetMinimumSize = "get_minimum_size";
        /// <summary>
        /// Cached name for the 'get_combined_minimum_size' method.
        /// </summary>
        public static readonly StringName GetCombinedMinimumSize = "get_combined_minimum_size";
        /// <summary>
        /// Cached name for the '_set_layout_mode' method.
        /// </summary>
        public static readonly StringName _SetLayoutMode = "_set_layout_mode";
        /// <summary>
        /// Cached name for the '_get_layout_mode' method.
        /// </summary>
        public static readonly StringName _GetLayoutMode = "_get_layout_mode";
        /// <summary>
        /// Cached name for the '_set_anchors_layout_preset' method.
        /// </summary>
        public static readonly StringName _SetAnchorsLayoutPreset = "_set_anchors_layout_preset";
        /// <summary>
        /// Cached name for the '_get_anchors_layout_preset' method.
        /// </summary>
        public static readonly StringName _GetAnchorsLayoutPreset = "_get_anchors_layout_preset";
        /// <summary>
        /// Cached name for the 'set_anchors_preset' method.
        /// </summary>
        public static readonly StringName SetAnchorsPreset = "set_anchors_preset";
        /// <summary>
        /// Cached name for the 'set_offsets_preset' method.
        /// </summary>
        public static readonly StringName SetOffsetsPreset = "set_offsets_preset";
        /// <summary>
        /// Cached name for the 'set_anchors_and_offsets_preset' method.
        /// </summary>
        public static readonly StringName SetAnchorsAndOffsetsPreset = "set_anchors_and_offsets_preset";
        /// <summary>
        /// Cached name for the '_set_anchor' method.
        /// </summary>
        public static readonly StringName _SetAnchor = "_set_anchor";
        /// <summary>
        /// Cached name for the 'set_anchor' method.
        /// </summary>
        public static readonly StringName SetAnchor = "set_anchor";
        /// <summary>
        /// Cached name for the 'get_anchor' method.
        /// </summary>
        public static readonly StringName GetAnchor = "get_anchor";
        /// <summary>
        /// Cached name for the 'set_offset' method.
        /// </summary>
        public static readonly StringName SetOffset = "set_offset";
        /// <summary>
        /// Cached name for the 'get_offset' method.
        /// </summary>
        public static readonly StringName GetOffset = "get_offset";
        /// <summary>
        /// Cached name for the 'set_anchor_and_offset' method.
        /// </summary>
        public static readonly StringName SetAnchorAndOffset = "set_anchor_and_offset";
        /// <summary>
        /// Cached name for the 'set_begin' method.
        /// </summary>
        public static readonly StringName SetBegin = "set_begin";
        /// <summary>
        /// Cached name for the 'set_end' method.
        /// </summary>
        public static readonly StringName SetEnd = "set_end";
        /// <summary>
        /// Cached name for the 'set_position' method.
        /// </summary>
        public static readonly StringName SetPosition = "set_position";
        /// <summary>
        /// Cached name for the '_set_position' method.
        /// </summary>
        public static readonly StringName _SetPosition = "_set_position";
        /// <summary>
        /// Cached name for the 'set_size' method.
        /// </summary>
        public static readonly StringName SetSize = "set_size";
        /// <summary>
        /// Cached name for the 'reset_size' method.
        /// </summary>
        public static readonly StringName ResetSize = "reset_size";
        /// <summary>
        /// Cached name for the '_set_size' method.
        /// </summary>
        public static readonly StringName _SetSize = "_set_size";
        /// <summary>
        /// Cached name for the 'set_custom_minimum_size' method.
        /// </summary>
        public static readonly StringName SetCustomMinimumSize = "set_custom_minimum_size";
        /// <summary>
        /// Cached name for the 'set_global_position' method.
        /// </summary>
        public static readonly StringName SetGlobalPosition = "set_global_position";
        /// <summary>
        /// Cached name for the '_set_global_position' method.
        /// </summary>
        public static readonly StringName _SetGlobalPosition = "_set_global_position";
        /// <summary>
        /// Cached name for the 'set_rotation' method.
        /// </summary>
        public static readonly StringName SetRotation = "set_rotation";
        /// <summary>
        /// Cached name for the 'set_rotation_degrees' method.
        /// </summary>
        public static readonly StringName SetRotationDegrees = "set_rotation_degrees";
        /// <summary>
        /// Cached name for the 'set_scale' method.
        /// </summary>
        public static readonly StringName SetScale = "set_scale";
        /// <summary>
        /// Cached name for the 'set_pivot_offset' method.
        /// </summary>
        public static readonly StringName SetPivotOffset = "set_pivot_offset";
        /// <summary>
        /// Cached name for the 'set_pivot_offset_ratio' method.
        /// </summary>
        public static readonly StringName SetPivotOffsetRatio = "set_pivot_offset_ratio";
        /// <summary>
        /// Cached name for the 'get_begin' method.
        /// </summary>
        public static readonly StringName GetBegin = "get_begin";
        /// <summary>
        /// Cached name for the 'get_end' method.
        /// </summary>
        public static readonly StringName GetEnd = "get_end";
        /// <summary>
        /// Cached name for the 'get_position' method.
        /// </summary>
        public static readonly StringName GetPosition = "get_position";
        /// <summary>
        /// Cached name for the 'get_size' method.
        /// </summary>
        public static readonly StringName GetSize = "get_size";
        /// <summary>
        /// Cached name for the 'get_rotation' method.
        /// </summary>
        public static readonly StringName GetRotation = "get_rotation";
        /// <summary>
        /// Cached name for the 'get_rotation_degrees' method.
        /// </summary>
        public static readonly StringName GetRotationDegrees = "get_rotation_degrees";
        /// <summary>
        /// Cached name for the 'get_scale' method.
        /// </summary>
        public static readonly StringName GetScale = "get_scale";
        /// <summary>
        /// Cached name for the 'get_pivot_offset' method.
        /// </summary>
        public static readonly StringName GetPivotOffset = "get_pivot_offset";
        /// <summary>
        /// Cached name for the 'get_pivot_offset_ratio' method.
        /// </summary>
        public static readonly StringName GetPivotOffsetRatio = "get_pivot_offset_ratio";
        /// <summary>
        /// Cached name for the 'get_combined_pivot_offset' method.
        /// </summary>
        public static readonly StringName GetCombinedPivotOffset = "get_combined_pivot_offset";
        /// <summary>
        /// Cached name for the 'get_custom_minimum_size' method.
        /// </summary>
        public static readonly StringName GetCustomMinimumSize = "get_custom_minimum_size";
        /// <summary>
        /// Cached name for the 'get_parent_area_size' method.
        /// </summary>
        public static readonly StringName GetParentAreaSize = "get_parent_area_size";
        /// <summary>
        /// Cached name for the 'get_global_position' method.
        /// </summary>
        public static readonly StringName GetGlobalPosition = "get_global_position";
        /// <summary>
        /// Cached name for the 'get_screen_position' method.
        /// </summary>
        public static readonly StringName GetScreenPosition = "get_screen_position";
        /// <summary>
        /// Cached name for the 'get_rect' method.
        /// </summary>
        public static readonly StringName GetRect = "get_rect";
        /// <summary>
        /// Cached name for the 'get_global_rect' method.
        /// </summary>
        public static readonly StringName GetGlobalRect = "get_global_rect";
        /// <summary>
        /// Cached name for the 'set_focus_mode' method.
        /// </summary>
        public static readonly StringName SetFocusMode = "set_focus_mode";
        /// <summary>
        /// Cached name for the 'get_focus_mode' method.
        /// </summary>
        public static readonly StringName GetFocusMode = "get_focus_mode";
        /// <summary>
        /// Cached name for the 'get_focus_mode_with_override' method.
        /// </summary>
        public static readonly StringName GetFocusModeWithOverride = "get_focus_mode_with_override";
        /// <summary>
        /// Cached name for the 'set_focus_behavior_recursive' method.
        /// </summary>
        public static readonly StringName SetFocusBehaviorRecursive = "set_focus_behavior_recursive";
        /// <summary>
        /// Cached name for the 'get_focus_behavior_recursive' method.
        /// </summary>
        public static readonly StringName GetFocusBehaviorRecursive = "get_focus_behavior_recursive";
        /// <summary>
        /// Cached name for the 'has_focus' method.
        /// </summary>
        public static readonly StringName HasFocus = "has_focus";
        /// <summary>
        /// Cached name for the 'grab_focus' method.
        /// </summary>
        public static readonly StringName GrabFocus = "grab_focus";
        /// <summary>
        /// Cached name for the 'release_focus' method.
        /// </summary>
        public static readonly StringName ReleaseFocus = "release_focus";
        /// <summary>
        /// Cached name for the 'find_prev_valid_focus' method.
        /// </summary>
        public static readonly StringName FindPrevValidFocus = "find_prev_valid_focus";
        /// <summary>
        /// Cached name for the 'find_next_valid_focus' method.
        /// </summary>
        public static readonly StringName FindNextValidFocus = "find_next_valid_focus";
        /// <summary>
        /// Cached name for the 'find_valid_focus_neighbor' method.
        /// </summary>
        public static readonly StringName FindValidFocusNeighbor = "find_valid_focus_neighbor";
        /// <summary>
        /// Cached name for the 'set_h_size_flags' method.
        /// </summary>
        public static readonly StringName SetHSizeFlags = "set_h_size_flags";
        /// <summary>
        /// Cached name for the 'get_h_size_flags' method.
        /// </summary>
        public static readonly StringName GetHSizeFlags = "get_h_size_flags";
        /// <summary>
        /// Cached name for the 'set_stretch_ratio' method.
        /// </summary>
        public static readonly StringName SetStretchRatio = "set_stretch_ratio";
        /// <summary>
        /// Cached name for the 'get_stretch_ratio' method.
        /// </summary>
        public static readonly StringName GetStretchRatio = "get_stretch_ratio";
        /// <summary>
        /// Cached name for the 'set_v_size_flags' method.
        /// </summary>
        public static readonly StringName SetVSizeFlags = "set_v_size_flags";
        /// <summary>
        /// Cached name for the 'get_v_size_flags' method.
        /// </summary>
        public static readonly StringName GetVSizeFlags = "get_v_size_flags";
        /// <summary>
        /// Cached name for the 'set_theme' method.
        /// </summary>
        public static readonly StringName SetTheme = "set_theme";
        /// <summary>
        /// Cached name for the 'get_theme' method.
        /// </summary>
        public static readonly StringName GetTheme = "get_theme";
        /// <summary>
        /// Cached name for the 'set_theme_type_variation' method.
        /// </summary>
        public static readonly StringName SetThemeTypeVariation = "set_theme_type_variation";
        /// <summary>
        /// Cached name for the 'get_theme_type_variation' method.
        /// </summary>
        public static readonly StringName GetThemeTypeVariation = "get_theme_type_variation";
        /// <summary>
        /// Cached name for the 'begin_bulk_theme_override' method.
        /// </summary>
        public static readonly StringName BeginBulkThemeOverride = "begin_bulk_theme_override";
        /// <summary>
        /// Cached name for the 'end_bulk_theme_override' method.
        /// </summary>
        public static readonly StringName EndBulkThemeOverride = "end_bulk_theme_override";
        /// <summary>
        /// Cached name for the 'add_theme_icon_override' method.
        /// </summary>
        public static readonly StringName AddThemeIconOverride = "add_theme_icon_override";
        /// <summary>
        /// Cached name for the 'add_theme_stylebox_override' method.
        /// </summary>
        public static readonly StringName AddThemeStyleboxOverride = "add_theme_stylebox_override";
        /// <summary>
        /// Cached name for the 'add_theme_font_override' method.
        /// </summary>
        public static readonly StringName AddThemeFontOverride = "add_theme_font_override";
        /// <summary>
        /// Cached name for the 'add_theme_font_size_override' method.
        /// </summary>
        public static readonly StringName AddThemeFontSizeOverride = "add_theme_font_size_override";
        /// <summary>
        /// Cached name for the 'add_theme_color_override' method.
        /// </summary>
        public static readonly StringName AddThemeColorOverride = "add_theme_color_override";
        /// <summary>
        /// Cached name for the 'add_theme_constant_override' method.
        /// </summary>
        public static readonly StringName AddThemeConstantOverride = "add_theme_constant_override";
        /// <summary>
        /// Cached name for the 'remove_theme_icon_override' method.
        /// </summary>
        public static readonly StringName RemoveThemeIconOverride = "remove_theme_icon_override";
        /// <summary>
        /// Cached name for the 'remove_theme_stylebox_override' method.
        /// </summary>
        public static readonly StringName RemoveThemeStyleboxOverride = "remove_theme_stylebox_override";
        /// <summary>
        /// Cached name for the 'remove_theme_font_override' method.
        /// </summary>
        public static readonly StringName RemoveThemeFontOverride = "remove_theme_font_override";
        /// <summary>
        /// Cached name for the 'remove_theme_font_size_override' method.
        /// </summary>
        public static readonly StringName RemoveThemeFontSizeOverride = "remove_theme_font_size_override";
        /// <summary>
        /// Cached name for the 'remove_theme_color_override' method.
        /// </summary>
        public static readonly StringName RemoveThemeColorOverride = "remove_theme_color_override";
        /// <summary>
        /// Cached name for the 'remove_theme_constant_override' method.
        /// </summary>
        public static readonly StringName RemoveThemeConstantOverride = "remove_theme_constant_override";
        /// <summary>
        /// Cached name for the 'get_theme_icon' method.
        /// </summary>
        public static readonly StringName GetThemeIcon = "get_theme_icon";
        /// <summary>
        /// Cached name for the 'get_theme_stylebox' method.
        /// </summary>
        public static readonly StringName GetThemeStylebox = "get_theme_stylebox";
        /// <summary>
        /// Cached name for the 'get_theme_font' method.
        /// </summary>
        public static readonly StringName GetThemeFont = "get_theme_font";
        /// <summary>
        /// Cached name for the 'get_theme_font_size' method.
        /// </summary>
        public static readonly StringName GetThemeFontSize = "get_theme_font_size";
        /// <summary>
        /// Cached name for the 'get_theme_color' method.
        /// </summary>
        public static readonly StringName GetThemeColor = "get_theme_color";
        /// <summary>
        /// Cached name for the 'get_theme_constant' method.
        /// </summary>
        public static readonly StringName GetThemeConstant = "get_theme_constant";
        /// <summary>
        /// Cached name for the 'has_theme_icon_override' method.
        /// </summary>
        public static readonly StringName HasThemeIconOverride = "has_theme_icon_override";
        /// <summary>
        /// Cached name for the 'has_theme_stylebox_override' method.
        /// </summary>
        public static readonly StringName HasThemeStyleboxOverride = "has_theme_stylebox_override";
        /// <summary>
        /// Cached name for the 'has_theme_font_override' method.
        /// </summary>
        public static readonly StringName HasThemeFontOverride = "has_theme_font_override";
        /// <summary>
        /// Cached name for the 'has_theme_font_size_override' method.
        /// </summary>
        public static readonly StringName HasThemeFontSizeOverride = "has_theme_font_size_override";
        /// <summary>
        /// Cached name for the 'has_theme_color_override' method.
        /// </summary>
        public static readonly StringName HasThemeColorOverride = "has_theme_color_override";
        /// <summary>
        /// Cached name for the 'has_theme_constant_override' method.
        /// </summary>
        public static readonly StringName HasThemeConstantOverride = "has_theme_constant_override";
        /// <summary>
        /// Cached name for the 'has_theme_icon' method.
        /// </summary>
        public static readonly StringName HasThemeIcon = "has_theme_icon";
        /// <summary>
        /// Cached name for the 'has_theme_stylebox' method.
        /// </summary>
        public static readonly StringName HasThemeStylebox = "has_theme_stylebox";
        /// <summary>
        /// Cached name for the 'has_theme_font' method.
        /// </summary>
        public static readonly StringName HasThemeFont = "has_theme_font";
        /// <summary>
        /// Cached name for the 'has_theme_font_size' method.
        /// </summary>
        public static readonly StringName HasThemeFontSize = "has_theme_font_size";
        /// <summary>
        /// Cached name for the 'has_theme_color' method.
        /// </summary>
        public static readonly StringName HasThemeColor = "has_theme_color";
        /// <summary>
        /// Cached name for the 'has_theme_constant' method.
        /// </summary>
        public static readonly StringName HasThemeConstant = "has_theme_constant";
        /// <summary>
        /// Cached name for the 'get_theme_default_base_scale' method.
        /// </summary>
        public static readonly StringName GetThemeDefaultBaseScale = "get_theme_default_base_scale";
        /// <summary>
        /// Cached name for the 'get_theme_default_font' method.
        /// </summary>
        public static readonly StringName GetThemeDefaultFont = "get_theme_default_font";
        /// <summary>
        /// Cached name for the 'get_theme_default_font_size' method.
        /// </summary>
        public static readonly StringName GetThemeDefaultFontSize = "get_theme_default_font_size";
        /// <summary>
        /// Cached name for the 'get_parent_control' method.
        /// </summary>
        public static readonly StringName GetParentControl = "get_parent_control";
        /// <summary>
        /// Cached name for the 'set_h_grow_direction' method.
        /// </summary>
        public static readonly StringName SetHGrowDirection = "set_h_grow_direction";
        /// <summary>
        /// Cached name for the 'get_h_grow_direction' method.
        /// </summary>
        public static readonly StringName GetHGrowDirection = "get_h_grow_direction";
        /// <summary>
        /// Cached name for the 'set_v_grow_direction' method.
        /// </summary>
        public static readonly StringName SetVGrowDirection = "set_v_grow_direction";
        /// <summary>
        /// Cached name for the 'get_v_grow_direction' method.
        /// </summary>
        public static readonly StringName GetVGrowDirection = "get_v_grow_direction";
        /// <summary>
        /// Cached name for the 'set_tooltip_auto_translate_mode' method.
        /// </summary>
        public static readonly StringName SetTooltipAutoTranslateMode = "set_tooltip_auto_translate_mode";
        /// <summary>
        /// Cached name for the 'get_tooltip_auto_translate_mode' method.
        /// </summary>
        public static readonly StringName GetTooltipAutoTranslateMode = "get_tooltip_auto_translate_mode";
        /// <summary>
        /// Cached name for the 'set_tooltip_text' method.
        /// </summary>
        public static readonly StringName SetTooltipText = "set_tooltip_text";
        /// <summary>
        /// Cached name for the 'get_tooltip_text' method.
        /// </summary>
        public static readonly StringName GetTooltipText = "get_tooltip_text";
        /// <summary>
        /// Cached name for the 'get_tooltip' method.
        /// </summary>
        public static readonly StringName GetTooltip = "get_tooltip";
        /// <summary>
        /// Cached name for the 'set_default_cursor_shape' method.
        /// </summary>
        public static readonly StringName SetDefaultCursorShape = "set_default_cursor_shape";
        /// <summary>
        /// Cached name for the 'get_default_cursor_shape' method.
        /// </summary>
        public static readonly StringName GetDefaultCursorShape = "get_default_cursor_shape";
        /// <summary>
        /// Cached name for the 'get_cursor_shape' method.
        /// </summary>
        public static readonly StringName GetCursorShape = "get_cursor_shape";
        /// <summary>
        /// Cached name for the 'set_focus_neighbor' method.
        /// </summary>
        public static readonly StringName SetFocusNeighbor = "set_focus_neighbor";
        /// <summary>
        /// Cached name for the 'get_focus_neighbor' method.
        /// </summary>
        public static readonly StringName GetFocusNeighbor = "get_focus_neighbor";
        /// <summary>
        /// Cached name for the 'set_focus_next' method.
        /// </summary>
        public static readonly StringName SetFocusNext = "set_focus_next";
        /// <summary>
        /// Cached name for the 'get_focus_next' method.
        /// </summary>
        public static readonly StringName GetFocusNext = "get_focus_next";
        /// <summary>
        /// Cached name for the 'set_focus_previous' method.
        /// </summary>
        public static readonly StringName SetFocusPrevious = "set_focus_previous";
        /// <summary>
        /// Cached name for the 'get_focus_previous' method.
        /// </summary>
        public static readonly StringName GetFocusPrevious = "get_focus_previous";
        /// <summary>
        /// Cached name for the 'force_drag' method.
        /// </summary>
        public static readonly StringName ForceDrag = "force_drag";
        /// <summary>
        /// Cached name for the 'accessibility_drag' method.
        /// </summary>
        public static readonly StringName AccessibilityDrag = "accessibility_drag";
        /// <summary>
        /// Cached name for the 'accessibility_drop' method.
        /// </summary>
        public static readonly StringName AccessibilityDrop = "accessibility_drop";
        /// <summary>
        /// Cached name for the 'set_accessibility_name' method.
        /// </summary>
        public static readonly StringName SetAccessibilityName = "set_accessibility_name";
        /// <summary>
        /// Cached name for the 'get_accessibility_name' method.
        /// </summary>
        public static readonly StringName GetAccessibilityName = "get_accessibility_name";
        /// <summary>
        /// Cached name for the 'set_accessibility_description' method.
        /// </summary>
        public static readonly StringName SetAccessibilityDescription = "set_accessibility_description";
        /// <summary>
        /// Cached name for the 'get_accessibility_description' method.
        /// </summary>
        public static readonly StringName GetAccessibilityDescription = "get_accessibility_description";
        /// <summary>
        /// Cached name for the 'set_accessibility_live' method.
        /// </summary>
        public static readonly StringName SetAccessibilityLive = "set_accessibility_live";
        /// <summary>
        /// Cached name for the 'get_accessibility_live' method.
        /// </summary>
        public static readonly StringName GetAccessibilityLive = "get_accessibility_live";
        /// <summary>
        /// Cached name for the 'set_accessibility_controls_nodes' method.
        /// </summary>
        public static readonly StringName SetAccessibilityControlsNodes = "set_accessibility_controls_nodes";
        /// <summary>
        /// Cached name for the 'get_accessibility_controls_nodes' method.
        /// </summary>
        public static readonly StringName GetAccessibilityControlsNodes = "get_accessibility_controls_nodes";
        /// <summary>
        /// Cached name for the 'set_accessibility_described_by_nodes' method.
        /// </summary>
        public static readonly StringName SetAccessibilityDescribedByNodes = "set_accessibility_described_by_nodes";
        /// <summary>
        /// Cached name for the 'get_accessibility_described_by_nodes' method.
        /// </summary>
        public static readonly StringName GetAccessibilityDescribedByNodes = "get_accessibility_described_by_nodes";
        /// <summary>
        /// Cached name for the 'set_accessibility_labeled_by_nodes' method.
        /// </summary>
        public static readonly StringName SetAccessibilityLabeledByNodes = "set_accessibility_labeled_by_nodes";
        /// <summary>
        /// Cached name for the 'get_accessibility_labeled_by_nodes' method.
        /// </summary>
        public static readonly StringName GetAccessibilityLabeledByNodes = "get_accessibility_labeled_by_nodes";
        /// <summary>
        /// Cached name for the 'set_accessibility_flow_to_nodes' method.
        /// </summary>
        public static readonly StringName SetAccessibilityFlowToNodes = "set_accessibility_flow_to_nodes";
        /// <summary>
        /// Cached name for the 'get_accessibility_flow_to_nodes' method.
        /// </summary>
        public static readonly StringName GetAccessibilityFlowToNodes = "get_accessibility_flow_to_nodes";
        /// <summary>
        /// Cached name for the 'set_mouse_filter' method.
        /// </summary>
        public static readonly StringName SetMouseFilter = "set_mouse_filter";
        /// <summary>
        /// Cached name for the 'get_mouse_filter' method.
        /// </summary>
        public static readonly StringName GetMouseFilter = "get_mouse_filter";
        /// <summary>
        /// Cached name for the 'get_mouse_filter_with_override' method.
        /// </summary>
        public static readonly StringName GetMouseFilterWithOverride = "get_mouse_filter_with_override";
        /// <summary>
        /// Cached name for the 'set_mouse_behavior_recursive' method.
        /// </summary>
        public static readonly StringName SetMouseBehaviorRecursive = "set_mouse_behavior_recursive";
        /// <summary>
        /// Cached name for the 'get_mouse_behavior_recursive' method.
        /// </summary>
        public static readonly StringName GetMouseBehaviorRecursive = "get_mouse_behavior_recursive";
        /// <summary>
        /// Cached name for the 'set_force_pass_scroll_events' method.
        /// </summary>
        public static readonly StringName SetForcePassScrollEvents = "set_force_pass_scroll_events";
        /// <summary>
        /// Cached name for the 'is_force_pass_scroll_events' method.
        /// </summary>
        public static readonly StringName IsForcePassScrollEvents = "is_force_pass_scroll_events";
        /// <summary>
        /// Cached name for the 'set_clip_contents' method.
        /// </summary>
        public static readonly StringName SetClipContents = "set_clip_contents";
        /// <summary>
        /// Cached name for the 'is_clipping_contents' method.
        /// </summary>
        public static readonly StringName IsClippingContents = "is_clipping_contents";
        /// <summary>
        /// Cached name for the 'grab_click_focus' method.
        /// </summary>
        public static readonly StringName GrabClickFocus = "grab_click_focus";
        /// <summary>
        /// Cached name for the 'set_drag_forwarding' method.
        /// </summary>
        public static readonly StringName SetDragForwarding = "set_drag_forwarding";
        /// <summary>
        /// Cached name for the 'set_drag_preview' method.
        /// </summary>
        public static readonly StringName SetDragPreview = "set_drag_preview";
        /// <summary>
        /// Cached name for the 'is_drag_successful' method.
        /// </summary>
        public static readonly StringName IsDragSuccessful = "is_drag_successful";
        /// <summary>
        /// Cached name for the 'warp_mouse' method.
        /// </summary>
        public static readonly StringName WarpMouse = "warp_mouse";
        /// <summary>
        /// Cached name for the 'set_shortcut_context' method.
        /// </summary>
        public static readonly StringName SetShortcutContext = "set_shortcut_context";
        /// <summary>
        /// Cached name for the 'get_shortcut_context' method.
        /// </summary>
        public static readonly StringName GetShortcutContext = "get_shortcut_context";
        /// <summary>
        /// Cached name for the 'update_minimum_size' method.
        /// </summary>
        public static readonly StringName UpdateMinimumSize = "update_minimum_size";
        /// <summary>
        /// Cached name for the 'set_layout_direction' method.
        /// </summary>
        public static readonly StringName SetLayoutDirection = "set_layout_direction";
        /// <summary>
        /// Cached name for the 'get_layout_direction' method.
        /// </summary>
        public static readonly StringName GetLayoutDirection = "get_layout_direction";
        /// <summary>
        /// Cached name for the 'is_layout_rtl' method.
        /// </summary>
        public static readonly StringName IsLayoutRtl = "is_layout_rtl";
        /// <summary>
        /// Cached name for the 'set_auto_translate' method.
        /// </summary>
        public static readonly StringName SetAutoTranslate = "set_auto_translate";
        /// <summary>
        /// Cached name for the 'is_auto_translating' method.
        /// </summary>
        public static readonly StringName IsAutoTranslating = "is_auto_translating";
        /// <summary>
        /// Cached name for the 'set_localize_numeral_system' method.
        /// </summary>
        public static readonly StringName SetLocalizeNumeralSystem = "set_localize_numeral_system";
        /// <summary>
        /// Cached name for the 'is_localizing_numeral_system' method.
        /// </summary>
        public static readonly StringName IsLocalizingNumeralSystem = "is_localizing_numeral_system";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : CanvasItem.SignalName
    {
        /// <summary>
        /// Cached name for the 'resized' signal.
        /// </summary>
        public static readonly StringName Resized = "resized";
        /// <summary>
        /// Cached name for the 'gui_input' signal.
        /// </summary>
        public static readonly StringName GuiInput = "gui_input";
        /// <summary>
        /// Cached name for the 'mouse_entered' signal.
        /// </summary>
        public static readonly StringName MouseEntered = "mouse_entered";
        /// <summary>
        /// Cached name for the 'mouse_exited' signal.
        /// </summary>
        public static readonly StringName MouseExited = "mouse_exited";
        /// <summary>
        /// Cached name for the 'focus_entered' signal.
        /// </summary>
        public static readonly StringName FocusEntered = "focus_entered";
        /// <summary>
        /// Cached name for the 'focus_exited' signal.
        /// </summary>
        public static readonly StringName FocusExited = "focus_exited";
        /// <summary>
        /// Cached name for the 'size_flags_changed' signal.
        /// </summary>
        public static readonly StringName SizeFlagsChanged = "size_flags_changed";
        /// <summary>
        /// Cached name for the 'minimum_size_changed' signal.
        /// </summary>
        public static readonly StringName MinimumSizeChanged = "minimum_size_changed";
        /// <summary>
        /// Cached name for the 'theme_changed' signal.
        /// </summary>
        public static readonly StringName ThemeChanged = "theme_changed";
    }
}
