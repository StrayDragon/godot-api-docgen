namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Camera node for 2D scenes. It forces the screen (current layer) to scroll following this node. This makes it easier (and faster) to program scrollable scenes than manually changing the position of <see cref="Godot.CanvasItem"/>-based nodes.</para>
/// <para>Cameras register themselves in the nearest <see cref="Godot.Viewport"/> node (when ascending the tree). Only one camera can be active per viewport. If no viewport is available ascending the tree, the camera will register in the global viewport.</para>
/// <para>This node is intended to be a simple helper to get things going quickly, but more functionality may be desired to change how the camera works. To make your own custom camera node, inherit it from <see cref="Godot.Node2D"/> and change the transform of the canvas by setting <see cref="Godot.Viewport.CanvasTransform"/> in <see cref="Godot.Viewport"/> (you can obtain the current <see cref="Godot.Viewport"/> by using <see cref="Godot.Node.GetViewport()"/>).</para>
/// <para>Note that the <see cref="Godot.Camera2D"/> node's <see cref="Godot.Node2D.GlobalPosition"/> doesn't represent the actual position of the screen, which may differ due to applied smoothing or limits. You can use <see cref="Godot.Camera2D.GetScreenCenterPosition()"/> to get the real position. Same for the node's <see cref="Godot.Node2D.GlobalRotation"/> which may be different due to applied rotation smoothing. You can use <see cref="Godot.Camera2D.GetScreenRotation()"/> to get the current rotation of the screen.</para>
/// </summary>
public partial class Camera2D : Node2D
{
    public enum AnchorModeEnum : long
    {
        /// <summary>
        /// <para>The camera's position is fixed so that the top-left corner is always at the origin.</para>
        /// </summary>
        FixedTopLeft = 0,
        /// <summary>
        /// <para>The camera's position takes into account vertical/horizontal offsets and the screen size.</para>
        /// </summary>
        DragCenter = 1
    }

    public enum Camera2DProcessCallback : long
    {
        /// <summary>
        /// <para>The camera updates during physics frames (see <see cref="Godot.Node.NotificationInternalPhysicsProcess"/>).</para>
        /// </summary>
        Physics = 0,
        /// <summary>
        /// <para>The camera updates during process frames (see <see cref="Godot.Node.NotificationInternalProcess"/>).</para>
        /// </summary>
        Idle = 1
    }

    /// <summary>
    /// <para>The camera's relative offset. Useful for looking around or camera shake animations. The offsetted camera can go past the limits defined in <see cref="Godot.Camera2D.LimitTop"/>, <see cref="Godot.Camera2D.LimitBottom"/>, <see cref="Godot.Camera2D.LimitLeft"/> and <see cref="Godot.Camera2D.LimitRight"/>.</para>
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
    /// <para>The Camera2D's anchor point.</para>
    /// </summary>
    public Camera2D.AnchorModeEnum AnchorMode
    {
        get
        {
            return GetAnchorMode();
        }
        set
        {
            SetAnchorMode(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the camera's rendered view is not affected by its <see cref="Godot.Node2D.Rotation"/> and <see cref="Godot.Node2D.GlobalRotation"/>.</para>
    /// </summary>
    public bool IgnoreRotation
    {
        get
        {
            return IsIgnoringRotation();
        }
        set
        {
            SetIgnoreRotation(value);
        }
    }

    /// <summary>
    /// <para>Controls whether the camera can be active or not. If <see langword="true"/>, the <see cref="Godot.Camera2D"/> will become the main camera when it enters the scene tree and there is no active camera currently (see <see cref="Godot.Viewport.GetCamera2D()"/>).</para>
    /// <para>When the camera is currently active and <see cref="Godot.Camera2D.Enabled"/> is set to <see langword="false"/>, the next enabled <see cref="Godot.Camera2D"/> in the scene tree will become active.</para>
    /// </summary>
    public bool Enabled
    {
        get
        {
            return IsEnabled();
        }
        set
        {
            SetEnabled(value);
        }
    }

    /// <summary>
    /// <para>The camera's zoom. Higher values are more zoomed in. For example, a zoom of <c>Vector2(2.0, 2.0)</c> will be twice as zoomed in on each axis (the view covers an area four times smaller). In contrast, a zoom of <c>Vector2(0.5, 0.5)</c> will be twice as zoomed out on each axis (the view covers an area four times larger). The X and Y components should generally always be set to the same value, unless you wish to stretch the camera view.</para>
    /// <para><b>Note:</b> <see cref="Godot.FontFile.Oversampling"/> does <i>not</i> take <see cref="Godot.Camera2D"/> zoom into account. This means that zooming in/out will cause bitmap fonts and rasterized (non-MSDF) dynamic fonts to appear blurry or pixelated unless the font is part of a <see cref="Godot.CanvasLayer"/> that makes it ignore camera zoom. To ensure text remains crisp regardless of zoom, you can enable MSDF font rendering by enabling <c>ProjectSettings.gui/theme/default_font_multichannel_signed_distance_field</c> (applies to the default project font only), or enabling <b>Multichannel Signed Distance Field</b> in the import options of a DynamicFont for custom fonts. On system fonts, <see cref="Godot.SystemFont.MultichannelSignedDistanceField"/> can be enabled in the inspector.</para>
    /// </summary>
    public Vector2 Zoom
    {
        get
        {
            return GetZoom();
        }
        set
        {
            SetZoom(value);
        }
    }

    /// <summary>
    /// <para>The custom <see cref="Godot.Viewport"/> node attached to the <see cref="Godot.Camera2D"/>. If <see langword="null"/> or not a <see cref="Godot.Viewport"/>, uses the default viewport instead.</para>
    /// </summary>
    public Node CustomViewport
    {
        get
        {
            return GetCustomViewport();
        }
        set
        {
            SetCustomViewport(value);
        }
    }

    /// <summary>
    /// <para>The camera's process callback.</para>
    /// </summary>
    public Camera2D.Camera2DProcessCallback ProcessCallback
    {
        get
        {
            return GetProcessCallback();
        }
        set
        {
            SetProcessCallback(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the limits will be enabled. Disabling this will allow the camera to focus anywhere, when the four <c>limit_*</c> properties will not work.</para>
    /// </summary>
    public bool LimitEnabled
    {
        get
        {
            return IsLimitEnabled();
        }
        set
        {
            SetLimitEnabled(value);
        }
    }

    /// <summary>
    /// <para>Left scroll limit in pixels. The camera stops moving when reaching this value, but <see cref="Godot.Camera2D.Offset"/> can push the view past the limit.</para>
    /// </summary>
    public int LimitLeft
    {
        get
        {
            return GetLimit((Side)(0));
        }
        set
        {
            SetLimit((Side)(0), value);
        }
    }

    /// <summary>
    /// <para>Top scroll limit in pixels. The camera stops moving when reaching this value, but <see cref="Godot.Camera2D.Offset"/> can push the view past the limit.</para>
    /// </summary>
    public int LimitTop
    {
        get
        {
            return GetLimit((Side)(1));
        }
        set
        {
            SetLimit((Side)(1), value);
        }
    }

    /// <summary>
    /// <para>Right scroll limit in pixels. The camera stops moving when reaching this value, but <see cref="Godot.Camera2D.Offset"/> can push the view past the limit.</para>
    /// </summary>
    public int LimitRight
    {
        get
        {
            return GetLimit((Side)(2));
        }
        set
        {
            SetLimit((Side)(2), value);
        }
    }

    /// <summary>
    /// <para>Bottom scroll limit in pixels. The camera stops moving when reaching this value, but <see cref="Godot.Camera2D.Offset"/> can push the view past the limit.</para>
    /// </summary>
    public int LimitBottom
    {
        get
        {
            return GetLimit((Side)(3));
        }
        set
        {
            SetLimit((Side)(3), value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the camera smoothly stops when reaches its limits.</para>
    /// <para>This property has no effect if <see cref="Godot.Camera2D.PositionSmoothingEnabled"/> is <see langword="false"/>.</para>
    /// <para><b>Note:</b> To immediately update the camera's position to be within limits without smoothing, even with this setting enabled, invoke <see cref="Godot.Camera2D.ResetSmoothing()"/>.</para>
    /// </summary>
    public bool LimitSmoothed
    {
        get
        {
            return IsLimitSmoothingEnabled();
        }
        set
        {
            SetLimitSmoothingEnabled(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the camera's view smoothly moves towards its target position at <see cref="Godot.Camera2D.PositionSmoothingSpeed"/>.</para>
    /// </summary>
    public bool PositionSmoothingEnabled
    {
        get
        {
            return IsPositionSmoothingEnabled();
        }
        set
        {
            SetPositionSmoothingEnabled(value);
        }
    }

    /// <summary>
    /// <para>Speed in pixels per second of the camera's smoothing effect when <see cref="Godot.Camera2D.PositionSmoothingEnabled"/> is <see langword="true"/>.</para>
    /// </summary>
    public float PositionSmoothingSpeed
    {
        get
        {
            return GetPositionSmoothingSpeed();
        }
        set
        {
            SetPositionSmoothingSpeed(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the camera's view smoothly rotates, via asymptotic smoothing, to align with its target rotation at <see cref="Godot.Camera2D.RotationSmoothingSpeed"/>.</para>
    /// <para><b>Note:</b> This property has no effect if <see cref="Godot.Camera2D.IgnoreRotation"/> is <see langword="true"/>.</para>
    /// </summary>
    public bool RotationSmoothingEnabled
    {
        get
        {
            return IsRotationSmoothingEnabled();
        }
        set
        {
            SetRotationSmoothingEnabled(value);
        }
    }

    /// <summary>
    /// <para>The angular, asymptotic speed of the camera's rotation smoothing effect when <see cref="Godot.Camera2D.RotationSmoothingEnabled"/> is <see langword="true"/>.</para>
    /// </summary>
    public float RotationSmoothingSpeed
    {
        get
        {
            return GetRotationSmoothingSpeed();
        }
        set
        {
            SetRotationSmoothingSpeed(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the camera only moves when reaching the horizontal (left and right) drag margins. If <see langword="false"/>, the camera moves horizontally regardless of margins.</para>
    /// </summary>
    public bool DragHorizontalEnabled
    {
        get
        {
            return IsDragHorizontalEnabled();
        }
        set
        {
            SetDragHorizontalEnabled(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the camera only moves when reaching the vertical (top and bottom) drag margins. If <see langword="false"/>, the camera moves vertically regardless of the drag margins.</para>
    /// </summary>
    public bool DragVerticalEnabled
    {
        get
        {
            return IsDragVerticalEnabled();
        }
        set
        {
            SetDragVerticalEnabled(value);
        }
    }

    /// <summary>
    /// <para>The relative horizontal drag offset of the camera between the right (<c>-1</c>) and left (<c>1</c>) drag margins.</para>
    /// <para><b>Note:</b> Used to set the initial horizontal drag offset; determine the current offset; or force the current offset. It's not automatically updated when <see cref="Godot.Camera2D.DragHorizontalEnabled"/> is <see langword="true"/> or the drag margins are changed.</para>
    /// </summary>
    public float DragHorizontalOffset
    {
        get
        {
            return GetDragHorizontalOffset();
        }
        set
        {
            SetDragHorizontalOffset(value);
        }
    }

    /// <summary>
    /// <para>The relative vertical drag offset of the camera between the bottom (<c>-1</c>) and top (<c>1</c>) drag margins.</para>
    /// <para><b>Note:</b> Used to set the initial vertical drag offset; determine the current offset; or force the current offset. It's not automatically updated when <see cref="Godot.Camera2D.DragVerticalEnabled"/> is <see langword="true"/> or the drag margins are changed.</para>
    /// </summary>
    public float DragVerticalOffset
    {
        get
        {
            return GetDragVerticalOffset();
        }
        set
        {
            SetDragVerticalOffset(value);
        }
    }

    /// <summary>
    /// <para>Left margin needed to drag the camera. A value of <c>1</c> makes the camera move only when reaching the left edge of the screen.</para>
    /// </summary>
    public float DragLeftMargin
    {
        get
        {
            return GetDragMargin((Side)(0));
        }
        set
        {
            SetDragMargin((Side)(0), value);
        }
    }

    /// <summary>
    /// <para>Top margin needed to drag the camera. A value of <c>1</c> makes the camera move only when reaching the top edge of the screen.</para>
    /// </summary>
    public float DragTopMargin
    {
        get
        {
            return GetDragMargin((Side)(1));
        }
        set
        {
            SetDragMargin((Side)(1), value);
        }
    }

    /// <summary>
    /// <para>Right margin needed to drag the camera. A value of <c>1</c> makes the camera move only when reaching the right edge of the screen.</para>
    /// </summary>
    public float DragRightMargin
    {
        get
        {
            return GetDragMargin((Side)(2));
        }
        set
        {
            SetDragMargin((Side)(2), value);
        }
    }

    /// <summary>
    /// <para>Bottom margin needed to drag the camera. A value of <c>1</c> makes the camera move only when reaching the bottom edge of the screen.</para>
    /// </summary>
    public float DragBottomMargin
    {
        get
        {
            return GetDragMargin((Side)(3));
        }
        set
        {
            SetDragMargin((Side)(3), value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, draws the camera's screen rectangle in the editor.</para>
    /// </summary>
    public bool EditorDrawScreen
    {
        get
        {
            return IsScreenDrawingEnabled();
        }
        set
        {
            SetScreenDrawingEnabled(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, draws the camera's limits rectangle in the editor.</para>
    /// </summary>
    public bool EditorDrawLimits
    {
        get
        {
            return IsLimitDrawingEnabled();
        }
        set
        {
            SetLimitDrawingEnabled(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, draws the camera's drag margin rectangle in the editor.</para>
    /// </summary>
    public bool EditorDrawDragMargin
    {
        get
        {
            return IsMarginDrawingEnabled();
        }
        set
        {
            SetMarginDrawingEnabled(value);
        }
    }

    private static readonly System.Type CachedType = typeof(Camera2D);

    private static readonly StringName NativeName = "Camera2D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public Camera2D() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal Camera2D(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal Camera2D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetOffset, 743155724ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetOffset(Vector2 offset)
    {
        NativeCalls.godot_icall_1_36(MethodBind0, GodotObject.GetPtr(this), &offset);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOffset, 3341600327ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2 GetOffset()
    {
        return NativeCalls.godot_icall_0_37(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAnchorMode, 2050398218ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAnchorMode(Camera2D.AnchorModeEnum anchorMode)
    {
        NativeCalls.godot_icall_1_38(MethodBind2, GodotObject.GetPtr(this), (int)anchorMode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAnchorMode, 155978067ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Camera2D.AnchorModeEnum GetAnchorMode()
    {
        return (Camera2D.AnchorModeEnum)NativeCalls.godot_icall_0_39(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetIgnoreRotation, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetIgnoreRotation(bool ignore)
    {
        NativeCalls.godot_icall_1_14(MethodBind4, GodotObject.GetPtr(this), ignore.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsIgnoringRotation, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsIgnoringRotation()
    {
        return NativeCalls.godot_icall_0_15(MethodBind5, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetProcessCallback, 4201947462ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetProcessCallback(Camera2D.Camera2DProcessCallback mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind6, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetProcessCallback, 2325344499ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Camera2D.Camera2DProcessCallback GetProcessCallback()
    {
        return (Camera2D.Camera2DProcessCallback)NativeCalls.godot_icall_0_39(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEnabled(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind8, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind9, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MakeCurrent, 3218959716ul);

    /// <summary>
    /// <para>Forces this <see cref="Godot.Camera2D"/> to become the current active one. <see cref="Godot.Camera2D.Enabled"/> must be <see langword="true"/>.</para>
    /// </summary>
    public void MakeCurrent()
    {
        NativeCalls.godot_icall_0_3(MethodBind10, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsCurrent, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if this <see cref="Godot.Camera2D"/> is the active camera (see <see cref="Godot.Viewport.GetCamera2D()"/>).</para>
    /// </summary>
    public bool IsCurrent()
    {
        return NativeCalls.godot_icall_0_15(MethodBind11, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLimitEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetLimitEnabled(bool limitEnabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind12, GodotObject.GetPtr(this), limitEnabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsLimitEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsLimitEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind13, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLimit, 437707142ul);

    /// <summary>
    /// <para>Sets the camera limit for the specified <see cref="Godot.Side"/>. See also <see cref="Godot.Camera2D.LimitBottom"/>, <see cref="Godot.Camera2D.LimitTop"/>, <see cref="Godot.Camera2D.LimitLeft"/>, and <see cref="Godot.Camera2D.LimitRight"/>.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetLimit(Side margin, int limit)
    {
        NativeCalls.godot_icall_2_59(MethodBind14, GodotObject.GetPtr(this), (int)margin, limit);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLimit, 1983885014ul);

    /// <summary>
    /// <para>Returns the camera limit for the specified <see cref="Godot.Side"/>. See also <see cref="Godot.Camera2D.LimitBottom"/>, <see cref="Godot.Camera2D.LimitTop"/>, <see cref="Godot.Camera2D.LimitLeft"/>, and <see cref="Godot.Camera2D.LimitRight"/>.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetLimit(Side margin)
    {
        return NativeCalls.godot_icall_1_60(MethodBind15, GodotObject.GetPtr(this), (int)margin);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLimitSmoothingEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetLimitSmoothingEnabled(bool limitSmoothingEnabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind16, GodotObject.GetPtr(this), limitSmoothingEnabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsLimitSmoothingEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsLimitSmoothingEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind17, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDragVerticalEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDragVerticalEnabled(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind18, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsDragVerticalEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsDragVerticalEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind19, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDragHorizontalEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDragHorizontalEnabled(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind20, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsDragHorizontalEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsDragHorizontalEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind21, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDragVerticalOffset, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDragVerticalOffset(float offset)
    {
        NativeCalls.godot_icall_1_67(MethodBind22, GodotObject.GetPtr(this), offset);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDragVerticalOffset, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetDragVerticalOffset()
    {
        return NativeCalls.godot_icall_0_68(MethodBind23, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDragHorizontalOffset, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDragHorizontalOffset(float offset)
    {
        NativeCalls.godot_icall_1_67(MethodBind24, GodotObject.GetPtr(this), offset);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDragHorizontalOffset, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetDragHorizontalOffset()
    {
        return NativeCalls.godot_icall_0_68(MethodBind25, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDragMargin, 4290182280ul);

    /// <summary>
    /// <para>Sets the specified <see cref="Godot.Side"/>'s margin. See also <see cref="Godot.Camera2D.DragBottomMargin"/>, <see cref="Godot.Camera2D.DragTopMargin"/>, <see cref="Godot.Camera2D.DragLeftMargin"/>, and <see cref="Godot.Camera2D.DragRightMargin"/>.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDragMargin(Side margin, float dragMargin)
    {
        NativeCalls.godot_icall_2_69(MethodBind26, GodotObject.GetPtr(this), (int)margin, dragMargin);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDragMargin, 2869120046ul);

    /// <summary>
    /// <para>Returns the specified <see cref="Godot.Side"/>'s margin. See also <see cref="Godot.Camera2D.DragBottomMargin"/>, <see cref="Godot.Camera2D.DragTopMargin"/>, <see cref="Godot.Camera2D.DragLeftMargin"/>, and <see cref="Godot.Camera2D.DragRightMargin"/>.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetDragMargin(Side margin)
    {
        return NativeCalls.godot_icall_1_72(MethodBind27, GodotObject.GetPtr(this), (int)margin);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTargetPosition, 3341600327ul);

    /// <summary>
    /// <para>Returns this camera's target position, in global coordinates.</para>
    /// <para><b>Note:</b> The returned value is not the same as <see cref="Godot.Node2D.GlobalPosition"/>, as it is affected by the drag properties. It is also not the same as the current position if <see cref="Godot.Camera2D.PositionSmoothingEnabled"/> is <see langword="true"/> (see <see cref="Godot.Camera2D.GetScreenCenterPosition()"/>).</para>
    /// </summary>
    public Vector2 GetTargetPosition()
    {
        return NativeCalls.godot_icall_0_37(MethodBind28, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetScreenCenterPosition, 3341600327ul);

    /// <summary>
    /// <para>Returns the center of the screen from this camera's point of view, in global coordinates.</para>
    /// <para><b>Note:</b> The exact targeted position of the camera may be different. See <see cref="Godot.Camera2D.GetTargetPosition()"/>.</para>
    /// </summary>
    public Vector2 GetScreenCenterPosition()
    {
        return NativeCalls.godot_icall_0_37(MethodBind29, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetScreenRotation, 1740695150ul);

    /// <summary>
    /// <para>Returns the current screen rotation from this camera's point of view.</para>
    /// <para><b>Note:</b> The screen rotation can be different from <see cref="Godot.Node2D.GlobalRotation"/> if the camera is rotating smoothly due to <see cref="Godot.Camera2D.RotationSmoothingEnabled"/>.</para>
    /// </summary>
    public float GetScreenRotation()
    {
        return NativeCalls.godot_icall_0_68(MethodBind30, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetZoom, 743155724ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetZoom(Vector2 zoom)
    {
        NativeCalls.godot_icall_1_36(MethodBind31, GodotObject.GetPtr(this), &zoom);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind32 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetZoom, 3341600327ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2 GetZoom()
    {
        return NativeCalls.godot_icall_0_37(MethodBind32, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind33 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCustomViewport, 1078189570ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCustomViewport(Node viewport)
    {
        NativeCalls.godot_icall_1_56(MethodBind33, GodotObject.GetPtr(this), GodotObject.GetPtr(viewport));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind34 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCustomViewport, 3160264692ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Node GetCustomViewport()
    {
        return (Node)NativeCalls.godot_icall_0_53(MethodBind34, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind35 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPositionSmoothingSpeed, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPositionSmoothingSpeed(float positionSmoothingSpeed)
    {
        NativeCalls.godot_icall_1_67(MethodBind35, GodotObject.GetPtr(this), positionSmoothingSpeed);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind36 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPositionSmoothingSpeed, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetPositionSmoothingSpeed()
    {
        return NativeCalls.godot_icall_0_68(MethodBind36, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind37 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPositionSmoothingEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPositionSmoothingEnabled(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind37, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind38 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsPositionSmoothingEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsPositionSmoothingEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind38, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind39 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRotationSmoothingEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetRotationSmoothingEnabled(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind39, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind40 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsRotationSmoothingEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsRotationSmoothingEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind40, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind41 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRotationSmoothingSpeed, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetRotationSmoothingSpeed(float speed)
    {
        NativeCalls.godot_icall_1_67(MethodBind41, GodotObject.GetPtr(this), speed);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind42 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRotationSmoothingSpeed, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetRotationSmoothingSpeed()
    {
        return NativeCalls.godot_icall_0_68(MethodBind42, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind43 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ForceUpdateScroll, 3218959716ul);

    /// <summary>
    /// <para>Forces the camera to update scroll immediately.</para>
    /// </summary>
    public void ForceUpdateScroll()
    {
        NativeCalls.godot_icall_0_3(MethodBind43, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind44 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ResetSmoothing, 3218959716ul);

    /// <summary>
    /// <para>Sets the camera's position immediately to its current smoothing destination.</para>
    /// <para>This method has no effect if <see cref="Godot.Camera2D.PositionSmoothingEnabled"/> is <see langword="false"/>.</para>
    /// </summary>
    public void ResetSmoothing()
    {
        NativeCalls.godot_icall_0_3(MethodBind44, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind45 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Align, 3218959716ul);

    /// <summary>
    /// <para>Aligns the camera to the tracked node.</para>
    /// <para><b>Note:</b> Calling <see cref="Godot.Camera2D.ForceUpdateScroll()"/> after this method is not required.</para>
    /// </summary>
    public void Align()
    {
        NativeCalls.godot_icall_0_3(MethodBind45, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind46 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetScreenDrawingEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetScreenDrawingEnabled(bool screenDrawingEnabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind46, GodotObject.GetPtr(this), screenDrawingEnabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind47 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsScreenDrawingEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsScreenDrawingEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind47, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind48 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLimitDrawingEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetLimitDrawingEnabled(bool limitDrawingEnabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind48, GodotObject.GetPtr(this), limitDrawingEnabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind49 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsLimitDrawingEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsLimitDrawingEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind49, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind50 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMarginDrawingEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMarginDrawingEnabled(bool marginDrawingEnabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind50, GodotObject.GetPtr(this), marginDrawingEnabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind51 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsMarginDrawingEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsMarginDrawingEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind51, GodotObject.GetPtr(this)).ToBool();
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
        /// Cached name for the 'offset' property.
        /// </summary>
        public static readonly StringName Offset = "offset";
        /// <summary>
        /// Cached name for the 'anchor_mode' property.
        /// </summary>
        public static readonly StringName AnchorMode = "anchor_mode";
        /// <summary>
        /// Cached name for the 'ignore_rotation' property.
        /// </summary>
        public static readonly StringName IgnoreRotation = "ignore_rotation";
        /// <summary>
        /// Cached name for the 'enabled' property.
        /// </summary>
        public static readonly StringName Enabled = "enabled";
        /// <summary>
        /// Cached name for the 'zoom' property.
        /// </summary>
        public static readonly StringName Zoom = "zoom";
        /// <summary>
        /// Cached name for the 'custom_viewport' property.
        /// </summary>
        public static readonly StringName CustomViewport = "custom_viewport";
        /// <summary>
        /// Cached name for the 'process_callback' property.
        /// </summary>
        public static readonly StringName ProcessCallback = "process_callback";
        /// <summary>
        /// Cached name for the 'limit_enabled' property.
        /// </summary>
        public static readonly StringName LimitEnabled = "limit_enabled";
        /// <summary>
        /// Cached name for the 'limit_left' property.
        /// </summary>
        public static readonly StringName LimitLeft = "limit_left";
        /// <summary>
        /// Cached name for the 'limit_top' property.
        /// </summary>
        public static readonly StringName LimitTop = "limit_top";
        /// <summary>
        /// Cached name for the 'limit_right' property.
        /// </summary>
        public static readonly StringName LimitRight = "limit_right";
        /// <summary>
        /// Cached name for the 'limit_bottom' property.
        /// </summary>
        public static readonly StringName LimitBottom = "limit_bottom";
        /// <summary>
        /// Cached name for the 'limit_smoothed' property.
        /// </summary>
        public static readonly StringName LimitSmoothed = "limit_smoothed";
        /// <summary>
        /// Cached name for the 'position_smoothing_enabled' property.
        /// </summary>
        public static readonly StringName PositionSmoothingEnabled = "position_smoothing_enabled";
        /// <summary>
        /// Cached name for the 'position_smoothing_speed' property.
        /// </summary>
        public static readonly StringName PositionSmoothingSpeed = "position_smoothing_speed";
        /// <summary>
        /// Cached name for the 'rotation_smoothing_enabled' property.
        /// </summary>
        public static readonly StringName RotationSmoothingEnabled = "rotation_smoothing_enabled";
        /// <summary>
        /// Cached name for the 'rotation_smoothing_speed' property.
        /// </summary>
        public static readonly StringName RotationSmoothingSpeed = "rotation_smoothing_speed";
        /// <summary>
        /// Cached name for the 'drag_horizontal_enabled' property.
        /// </summary>
        public static readonly StringName DragHorizontalEnabled = "drag_horizontal_enabled";
        /// <summary>
        /// Cached name for the 'drag_vertical_enabled' property.
        /// </summary>
        public static readonly StringName DragVerticalEnabled = "drag_vertical_enabled";
        /// <summary>
        /// Cached name for the 'drag_horizontal_offset' property.
        /// </summary>
        public static readonly StringName DragHorizontalOffset = "drag_horizontal_offset";
        /// <summary>
        /// Cached name for the 'drag_vertical_offset' property.
        /// </summary>
        public static readonly StringName DragVerticalOffset = "drag_vertical_offset";
        /// <summary>
        /// Cached name for the 'drag_left_margin' property.
        /// </summary>
        public static readonly StringName DragLeftMargin = "drag_left_margin";
        /// <summary>
        /// Cached name for the 'drag_top_margin' property.
        /// </summary>
        public static readonly StringName DragTopMargin = "drag_top_margin";
        /// <summary>
        /// Cached name for the 'drag_right_margin' property.
        /// </summary>
        public static readonly StringName DragRightMargin = "drag_right_margin";
        /// <summary>
        /// Cached name for the 'drag_bottom_margin' property.
        /// </summary>
        public static readonly StringName DragBottomMargin = "drag_bottom_margin";
        /// <summary>
        /// Cached name for the 'editor_draw_screen' property.
        /// </summary>
        public static readonly StringName EditorDrawScreen = "editor_draw_screen";
        /// <summary>
        /// Cached name for the 'editor_draw_limits' property.
        /// </summary>
        public static readonly StringName EditorDrawLimits = "editor_draw_limits";
        /// <summary>
        /// Cached name for the 'editor_draw_drag_margin' property.
        /// </summary>
        public static readonly StringName EditorDrawDragMargin = "editor_draw_drag_margin";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Node2D.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_offset' method.
        /// </summary>
        public static readonly StringName SetOffset = "set_offset";
        /// <summary>
        /// Cached name for the 'get_offset' method.
        /// </summary>
        public static readonly StringName GetOffset = "get_offset";
        /// <summary>
        /// Cached name for the 'set_anchor_mode' method.
        /// </summary>
        public static readonly StringName SetAnchorMode = "set_anchor_mode";
        /// <summary>
        /// Cached name for the 'get_anchor_mode' method.
        /// </summary>
        public static readonly StringName GetAnchorMode = "get_anchor_mode";
        /// <summary>
        /// Cached name for the 'set_ignore_rotation' method.
        /// </summary>
        public static readonly StringName SetIgnoreRotation = "set_ignore_rotation";
        /// <summary>
        /// Cached name for the 'is_ignoring_rotation' method.
        /// </summary>
        public static readonly StringName IsIgnoringRotation = "is_ignoring_rotation";
        /// <summary>
        /// Cached name for the 'set_process_callback' method.
        /// </summary>
        public static readonly StringName SetProcessCallback = "set_process_callback";
        /// <summary>
        /// Cached name for the 'get_process_callback' method.
        /// </summary>
        public static readonly StringName GetProcessCallback = "get_process_callback";
        /// <summary>
        /// Cached name for the 'set_enabled' method.
        /// </summary>
        public static readonly StringName SetEnabled = "set_enabled";
        /// <summary>
        /// Cached name for the 'is_enabled' method.
        /// </summary>
        public static readonly StringName IsEnabled = "is_enabled";
        /// <summary>
        /// Cached name for the 'make_current' method.
        /// </summary>
        public static readonly StringName MakeCurrent = "make_current";
        /// <summary>
        /// Cached name for the 'is_current' method.
        /// </summary>
        public static readonly StringName IsCurrent = "is_current";
        /// <summary>
        /// Cached name for the 'set_limit_enabled' method.
        /// </summary>
        public static readonly StringName SetLimitEnabled = "set_limit_enabled";
        /// <summary>
        /// Cached name for the 'is_limit_enabled' method.
        /// </summary>
        public static readonly StringName IsLimitEnabled = "is_limit_enabled";
        /// <summary>
        /// Cached name for the 'set_limit' method.
        /// </summary>
        public static readonly StringName SetLimit = "set_limit";
        /// <summary>
        /// Cached name for the 'get_limit' method.
        /// </summary>
        public static readonly StringName GetLimit = "get_limit";
        /// <summary>
        /// Cached name for the 'set_limit_smoothing_enabled' method.
        /// </summary>
        public static readonly StringName SetLimitSmoothingEnabled = "set_limit_smoothing_enabled";
        /// <summary>
        /// Cached name for the 'is_limit_smoothing_enabled' method.
        /// </summary>
        public static readonly StringName IsLimitSmoothingEnabled = "is_limit_smoothing_enabled";
        /// <summary>
        /// Cached name for the 'set_drag_vertical_enabled' method.
        /// </summary>
        public static readonly StringName SetDragVerticalEnabled = "set_drag_vertical_enabled";
        /// <summary>
        /// Cached name for the 'is_drag_vertical_enabled' method.
        /// </summary>
        public static readonly StringName IsDragVerticalEnabled = "is_drag_vertical_enabled";
        /// <summary>
        /// Cached name for the 'set_drag_horizontal_enabled' method.
        /// </summary>
        public static readonly StringName SetDragHorizontalEnabled = "set_drag_horizontal_enabled";
        /// <summary>
        /// Cached name for the 'is_drag_horizontal_enabled' method.
        /// </summary>
        public static readonly StringName IsDragHorizontalEnabled = "is_drag_horizontal_enabled";
        /// <summary>
        /// Cached name for the 'set_drag_vertical_offset' method.
        /// </summary>
        public static readonly StringName SetDragVerticalOffset = "set_drag_vertical_offset";
        /// <summary>
        /// Cached name for the 'get_drag_vertical_offset' method.
        /// </summary>
        public static readonly StringName GetDragVerticalOffset = "get_drag_vertical_offset";
        /// <summary>
        /// Cached name for the 'set_drag_horizontal_offset' method.
        /// </summary>
        public static readonly StringName SetDragHorizontalOffset = "set_drag_horizontal_offset";
        /// <summary>
        /// Cached name for the 'get_drag_horizontal_offset' method.
        /// </summary>
        public static readonly StringName GetDragHorizontalOffset = "get_drag_horizontal_offset";
        /// <summary>
        /// Cached name for the 'set_drag_margin' method.
        /// </summary>
        public static readonly StringName SetDragMargin = "set_drag_margin";
        /// <summary>
        /// Cached name for the 'get_drag_margin' method.
        /// </summary>
        public static readonly StringName GetDragMargin = "get_drag_margin";
        /// <summary>
        /// Cached name for the 'get_target_position' method.
        /// </summary>
        public static readonly StringName GetTargetPosition = "get_target_position";
        /// <summary>
        /// Cached name for the 'get_screen_center_position' method.
        /// </summary>
        public static readonly StringName GetScreenCenterPosition = "get_screen_center_position";
        /// <summary>
        /// Cached name for the 'get_screen_rotation' method.
        /// </summary>
        public static readonly StringName GetScreenRotation = "get_screen_rotation";
        /// <summary>
        /// Cached name for the 'set_zoom' method.
        /// </summary>
        public static readonly StringName SetZoom = "set_zoom";
        /// <summary>
        /// Cached name for the 'get_zoom' method.
        /// </summary>
        public static readonly StringName GetZoom = "get_zoom";
        /// <summary>
        /// Cached name for the 'set_custom_viewport' method.
        /// </summary>
        public static readonly StringName SetCustomViewport = "set_custom_viewport";
        /// <summary>
        /// Cached name for the 'get_custom_viewport' method.
        /// </summary>
        public static readonly StringName GetCustomViewport = "get_custom_viewport";
        /// <summary>
        /// Cached name for the 'set_position_smoothing_speed' method.
        /// </summary>
        public static readonly StringName SetPositionSmoothingSpeed = "set_position_smoothing_speed";
        /// <summary>
        /// Cached name for the 'get_position_smoothing_speed' method.
        /// </summary>
        public static readonly StringName GetPositionSmoothingSpeed = "get_position_smoothing_speed";
        /// <summary>
        /// Cached name for the 'set_position_smoothing_enabled' method.
        /// </summary>
        public static readonly StringName SetPositionSmoothingEnabled = "set_position_smoothing_enabled";
        /// <summary>
        /// Cached name for the 'is_position_smoothing_enabled' method.
        /// </summary>
        public static readonly StringName IsPositionSmoothingEnabled = "is_position_smoothing_enabled";
        /// <summary>
        /// Cached name for the 'set_rotation_smoothing_enabled' method.
        /// </summary>
        public static readonly StringName SetRotationSmoothingEnabled = "set_rotation_smoothing_enabled";
        /// <summary>
        /// Cached name for the 'is_rotation_smoothing_enabled' method.
        /// </summary>
        public static readonly StringName IsRotationSmoothingEnabled = "is_rotation_smoothing_enabled";
        /// <summary>
        /// Cached name for the 'set_rotation_smoothing_speed' method.
        /// </summary>
        public static readonly StringName SetRotationSmoothingSpeed = "set_rotation_smoothing_speed";
        /// <summary>
        /// Cached name for the 'get_rotation_smoothing_speed' method.
        /// </summary>
        public static readonly StringName GetRotationSmoothingSpeed = "get_rotation_smoothing_speed";
        /// <summary>
        /// Cached name for the 'force_update_scroll' method.
        /// </summary>
        public static readonly StringName ForceUpdateScroll = "force_update_scroll";
        /// <summary>
        /// Cached name for the 'reset_smoothing' method.
        /// </summary>
        public static readonly StringName ResetSmoothing = "reset_smoothing";
        /// <summary>
        /// Cached name for the 'align' method.
        /// </summary>
        public static readonly StringName Align = "align";
        /// <summary>
        /// Cached name for the 'set_screen_drawing_enabled' method.
        /// </summary>
        public static readonly StringName SetScreenDrawingEnabled = "set_screen_drawing_enabled";
        /// <summary>
        /// Cached name for the 'is_screen_drawing_enabled' method.
        /// </summary>
        public static readonly StringName IsScreenDrawingEnabled = "is_screen_drawing_enabled";
        /// <summary>
        /// Cached name for the 'set_limit_drawing_enabled' method.
        /// </summary>
        public static readonly StringName SetLimitDrawingEnabled = "set_limit_drawing_enabled";
        /// <summary>
        /// Cached name for the 'is_limit_drawing_enabled' method.
        /// </summary>
        public static readonly StringName IsLimitDrawingEnabled = "is_limit_drawing_enabled";
        /// <summary>
        /// Cached name for the 'set_margin_drawing_enabled' method.
        /// </summary>
        public static readonly StringName SetMarginDrawingEnabled = "set_margin_drawing_enabled";
        /// <summary>
        /// Cached name for the 'is_margin_drawing_enabled' method.
        /// </summary>
        public static readonly StringName IsMarginDrawingEnabled = "is_margin_drawing_enabled";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Node2D.SignalName
    {
    }
}
