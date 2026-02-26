namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A node that creates a window. The window can either be a native system window or embedded inside another <see cref="Godot.Window"/> (see <see cref="Godot.Viewport.GuiEmbedSubwindows"/>).</para>
/// <para>At runtime, <see cref="Godot.Window"/>s will not close automatically when requested. You need to handle it manually using the <see cref="Godot.Window.CloseRequested"/> signal (this applies both to pressing the close button and clicking outside of a popup).</para>
/// </summary>
public partial class Window : Viewport
{
    /// <summary>
    /// <para>Emitted when <see cref="Godot.Window"/>'s visibility changes, right before <see cref="Godot.Window.VisibilityChanged"/>.</para>
    /// </summary>
    public const long NotificationVisibilityChanged = 30;
    /// <summary>
    /// <para>Sent when the node needs to refresh its theme items. This happens in one of the following cases:</para>
    /// <para>- The <see cref="Godot.Window.Theme"/> property is changed on this node or any of its ancestors.</para>
    /// <para>- The <see cref="Godot.Window.ThemeTypeVariation"/> property is changed on this node.</para>
    /// <para>- The node enters the scene tree.</para>
    /// <para><b>Note:</b> As an optimization, this notification won't be sent from changes that occur while this node is outside of the scene tree. Instead, all of the theme item updates can be applied at once when the node enters the scene tree.</para>
    /// </summary>
    public const long NotificationThemeChanged = 32;

    public enum ModeEnum : long
    {
        /// <summary>
        /// <para>Windowed mode, i.e. <see cref="Godot.Window"/> doesn't occupy the whole screen (unless set to the size of the screen).</para>
        /// </summary>
        Windowed = 0,
        /// <summary>
        /// <para>Minimized window mode, i.e. <see cref="Godot.Window"/> is not visible and available on window manager's window list. Normally happens when the minimize button is pressed.</para>
        /// </summary>
        Minimized = 1,
        /// <summary>
        /// <para>Maximized window mode, i.e. <see cref="Godot.Window"/> will occupy whole screen area except task bar and still display its borders. Normally happens when the maximize button is pressed.</para>
        /// </summary>
        Maximized = 2,
        /// <summary>
        /// <para>Full screen mode with full multi-window support.</para>
        /// <para>Full screen window covers the entire display area of a screen and has no decorations. The display's video mode is not changed.</para>
        /// <para><b>On Android:</b> This enables immersive mode.</para>
        /// <para><b>On macOS:</b> A new desktop is used to display the running project.</para>
        /// <para><b>Note:</b> Regardless of the platform, enabling full screen will change the window size to match the monitor's size. Therefore, make sure your project supports <a href="$DOCS_URL/tutorials/rendering/multiple_resolutions.html">multiple resolutions</a> when enabling full screen mode.</para>
        /// </summary>
        Fullscreen = 3,
        /// <summary>
        /// <para>A single window full screen mode. This mode has less overhead, but only one window can be open on a given screen at a time (opening a child window or application switching will trigger a full screen transition).</para>
        /// <para>Full screen window covers the entire display area of a screen and has no border or decorations. The display's video mode is not changed.</para>
        /// <para><b>Note:</b> This mode might not work with screen recording software.</para>
        /// <para><b>On Android:</b> This enables immersive mode.</para>
        /// <para><b>On Windows:</b> Depending on video driver, full screen transition might cause screens to go black for a moment.</para>
        /// <para><b>On macOS:</b> A new desktop is used to display the running project. Exclusive full screen mode prevents Dock and Menu from showing up when the mouse pointer is hovering the edge of the screen.</para>
        /// <para><b>On Linux (X11):</b> Exclusive full screen mode bypasses compositor.</para>
        /// <para><b>On Linux (Wayland):</b> Equivalent to <see cref="Godot.Window.ModeEnum.Fullscreen"/>.</para>
        /// <para><b>Note:</b> Regardless of the platform, enabling full screen will change the window size to match the monitor's size. Therefore, make sure your project supports <a href="$DOCS_URL/tutorials/rendering/multiple_resolutions.html">multiple resolutions</a> when enabling full screen mode.</para>
        /// </summary>
        ExclusiveFullscreen = 4
    }

    public enum Flags : long
    {
        /// <summary>
        /// <para>The window can't be resized by dragging its resize grip. It's still possible to resize the window using <see cref="Godot.Window.Size"/>. This flag is ignored for full screen windows. Set with <see cref="Godot.Window.Unresizable"/>.</para>
        /// </summary>
        ResizeDisabled = 0,
        /// <summary>
        /// <para>The window do not have native title bar and other decorations. This flag is ignored for full-screen windows. Set with <see cref="Godot.Window.Borderless"/>.</para>
        /// </summary>
        Borderless = 1,
        /// <summary>
        /// <para>The window is floating on top of all other windows. This flag is ignored for full-screen windows. Set with <see cref="Godot.Window.AlwaysOnTop"/>.</para>
        /// </summary>
        AlwaysOnTop = 2,
        /// <summary>
        /// <para>The window background can be transparent. Set with <see cref="Godot.Window.Transparent"/>.</para>
        /// <para><b>Note:</b> This flag has no effect if either <c>ProjectSettings.display/window/per_pixel_transparency/allowed</c>, or the window's <see cref="Godot.Viewport.TransparentBg"/> is set to <see langword="false"/>.</para>
        /// </summary>
        Transparent = 3,
        /// <summary>
        /// <para>The window can't be focused. No-focus window will ignore all input, except mouse clicks. Set with <see cref="Godot.Window.Unfocusable"/>.</para>
        /// </summary>
        NoFocus = 4,
        /// <summary>
        /// <para>Window is part of menu or <see cref="Godot.OptionButton"/> dropdown. This flag can't be changed when the window is visible. An active popup window will exclusively receive all input, without stealing focus from its parent. Popup windows are automatically closed when uses click outside it, or when an application is switched. Popup window must have transient parent set (see <see cref="Godot.Window.Transient"/>).</para>
        /// <para><b>Note:</b> This flag has no effect in embedded windows (unless said window is a <see cref="Godot.Popup"/>).</para>
        /// </summary>
        Popup = 5,
        /// <summary>
        /// <para>Window content is expanded to the full size of the window. Unlike borderless window, the frame is left intact and can be used to resize the window, title bar is transparent, but have minimize/maximize/close buttons. Set with <see cref="Godot.Window.ExtendToTitle"/>.</para>
        /// <para><b>Note:</b> This flag is implemented only on macOS.</para>
        /// <para><b>Note:</b> This flag has no effect in embedded windows.</para>
        /// </summary>
        ExtendToTitle = 6,
        /// <summary>
        /// <para>All mouse events are passed to the underlying window of the same application.</para>
        /// <para><b>Note:</b> This flag has no effect in embedded windows.</para>
        /// </summary>
        MousePassthrough = 7,
        /// <summary>
        /// <para>Window style is overridden, forcing sharp corners.</para>
        /// <para><b>Note:</b> This flag has no effect in embedded windows.</para>
        /// <para><b>Note:</b> This flag is implemented only on Windows (11).</para>
        /// </summary>
        SharpCorners = 8,
        /// <summary>
        /// <para>Windows is excluded from screenshots taken by <see cref="Godot.DisplayServer.ScreenGetImage(int)"/>, <see cref="Godot.DisplayServer.ScreenGetImageRect(Rect2I)"/>, and <see cref="Godot.DisplayServer.ScreenGetPixel(Vector2I)"/>.</para>
        /// <para><b>Note:</b> This flag has no effect in embedded windows.</para>
        /// <para><b>Note:</b> This flag is implemented on macOS and Windows (10, 20H1).</para>
        /// <para><b>Note:</b> Setting this flag will prevent standard screenshot methods from capturing a window image, but does <b>NOT</b> guarantee that other apps won't be able to capture an image. It should not be used as a DRM or security measure.</para>
        /// </summary>
        ExcludeFromCapture = 9,
        /// <summary>
        /// <para>Signals the window manager that this window is supposed to be an implementation-defined "popup" (usually a floating, borderless, untileable and immovable child window).</para>
        /// </summary>
        PopupWMHint = 10,
        /// <summary>
        /// <para>Window minimize button is disabled.</para>
        /// <para><b>Note:</b> This flag is implemented on macOS and Windows.</para>
        /// </summary>
        MinimizeDisabled = 11,
        /// <summary>
        /// <para>Window maximize button is disabled.</para>
        /// <para><b>Note:</b> This flag is implemented on macOS and Windows.</para>
        /// </summary>
        MaximizeDisabled = 12,
        /// <summary>
        /// <para>Max value of the <see cref="Godot.Window.Flags"/>.</para>
        /// </summary>
        Max = 13
    }

    public enum ContentScaleModeEnum : long
    {
        /// <summary>
        /// <para>The content will not be scaled to match the <see cref="Godot.Window"/>'s size (<see cref="Godot.Window.ContentScaleSize"/> is ignored).</para>
        /// </summary>
        Disabled = 0,
        /// <summary>
        /// <para>The content will be rendered at the target size. This is more performance-expensive than <see cref="Godot.Window.ContentScaleModeEnum.Viewport"/>, but provides better results.</para>
        /// </summary>
        CanvasItems = 1,
        /// <summary>
        /// <para>The content will be rendered at the base size and then scaled to the target size. More performant than <see cref="Godot.Window.ContentScaleModeEnum.CanvasItems"/>, but results in pixelated image.</para>
        /// </summary>
        Viewport = 2
    }

    public enum ContentScaleAspectEnum : long
    {
        /// <summary>
        /// <para>The aspect will be ignored. Scaling will simply stretch the content to fit the target size.</para>
        /// </summary>
        Ignore = 0,
        /// <summary>
        /// <para>The content's aspect will be preserved. If the target size has different aspect from the base one, the image will be centered and black bars will appear on left and right sides.</para>
        /// </summary>
        Keep = 1,
        /// <summary>
        /// <para>The content can be expanded vertically. Scaling horizontally will result in keeping the width ratio and then black bars on left and right sides.</para>
        /// </summary>
        KeepWidth = 2,
        /// <summary>
        /// <para>The content can be expanded horizontally. Scaling vertically will result in keeping the height ratio and then black bars on top and bottom sides.</para>
        /// </summary>
        KeepHeight = 3,
        /// <summary>
        /// <para>The content's aspect will be preserved. If the target size has different aspect from the base one, the content will stay in the top-left corner and add an extra visible area in the stretched space.</para>
        /// </summary>
        Expand = 4
    }

    public enum ContentScaleStretchEnum : long
    {
        /// <summary>
        /// <para>The content will be stretched according to a fractional factor. This fills all the space available in the window, but allows "pixel wobble" to occur due to uneven pixel scaling.</para>
        /// </summary>
        Fractional = 0,
        /// <summary>
        /// <para>The content will be stretched only according to an integer factor, preserving sharp pixels. This may leave a black background visible on the window's edges depending on the window size.</para>
        /// </summary>
        Integer = 1
    }

    public enum LayoutDirection : long
    {
        /// <summary>
        /// <para>Automatic layout direction, determined from the parent window layout direction.</para>
        /// </summary>
        Inherited = 0,
        /// <summary>
        /// <para>Automatic layout direction, determined from the current locale.</para>
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
        /// <para>Automatic layout direction, determined from the system locale.</para>
        /// </summary>
        SystemLocale = 4,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.Window.LayoutDirection"/> enum.</para>
        /// </summary>
        Max = 5,
        [Obsolete("Use 'Godot.Window.LayoutDirection.ApplicationLocale' instead.")]
        Locale = 1
    }

    public enum WindowInitialPosition : long
    {
        /// <summary>
        /// <para>Initial window position is determined by <see cref="Godot.Window.Position"/>.</para>
        /// </summary>
        Absolute = 0,
        /// <summary>
        /// <para>Initial window position is the center of the primary screen.</para>
        /// </summary>
        CenterPrimaryScreen = 1,
        /// <summary>
        /// <para>Initial window position is the center of the main window screen.</para>
        /// </summary>
        CenterMainWindowScreen = 2,
        /// <summary>
        /// <para>Initial window position is the center of <see cref="Godot.Window.CurrentScreen"/> screen.</para>
        /// </summary>
        CenterOtherScreen = 3,
        /// <summary>
        /// <para>Initial window position is the center of the screen containing the mouse pointer.</para>
        /// </summary>
        CenterScreenWithMouseFocus = 4,
        /// <summary>
        /// <para>Initial window position is the center of the screen containing the window with the keyboard focus.</para>
        /// </summary>
        CenterScreenWithKeyboardFocus = 5
    }

    /// <summary>
    /// <para>Set's the window's current mode.</para>
    /// <para><b>Note:</b> Fullscreen mode is not exclusive full screen on Windows and Linux.</para>
    /// <para><b>Note:</b> This method only works with native windows, i.e. the main window and <see cref="Godot.Window"/>-derived nodes when <see cref="Godot.Viewport.GuiEmbedSubwindows"/> is disabled in the main viewport.</para>
    /// </summary>
    public Window.ModeEnum Mode
    {
        get
        {
            return GetMode();
        }
        set
        {
            SetMode(value);
        }
    }

    /// <summary>
    /// <para>The window's title. If the <see cref="Godot.Window"/> is native, title styles set in <see cref="Godot.Theme"/> will have no effect.</para>
    /// </summary>
    public string Title
    {
        get
        {
            return GetTitle();
        }
        set
        {
            SetTitle(value);
        }
    }

    /// <summary>
    /// <para>Specifies the initial type of position for the <see cref="Godot.Window"/>.</para>
    /// </summary>
    public Window.WindowInitialPosition InitialPosition
    {
        get
        {
            return GetInitialPosition();
        }
        set
        {
            SetInitialPosition(value);
        }
    }

    /// <summary>
    /// <para>The window's position in pixels.</para>
    /// <para>If <c>ProjectSettings.display/window/subwindows/embed_subwindows</c> is <see langword="false"/>, the position is in absolute screen coordinates. This typically applies to editor plugins. If the setting is <see langword="true"/>, the window's position is in the coordinates of its parent <see cref="Godot.Viewport"/>.</para>
    /// <para><b>Note:</b> This property only works if <see cref="Godot.Window.InitialPosition"/> is set to <see cref="Godot.Window.WindowInitialPosition.Absolute"/>.</para>
    /// </summary>
    public Vector2I Position
    {
        get
        {
            return GetPosition();
        }
        set
        {
            SetPosition(value);
        }
    }

    /// <summary>
    /// <para>The window's size in pixels. See also <see cref="Godot.Window.ContentScaleSize"/>, which doesn't set the window's physical size but affects how scaling works relative to the current <see cref="Godot.Window.ContentScaleMode"/>.</para>
    /// </summary>
    public Vector2I Size
    {
        get
        {
            return GetSize();
        }
        set
        {
            SetSize(value);
        }
    }

    /// <summary>
    /// <para>The screen the window is currently on.</para>
    /// </summary>
    public int CurrentScreen
    {
        get
        {
            return GetCurrentScreen();
        }
        set
        {
            SetCurrentScreen(value);
        }
    }

    /// <summary>
    /// <para>If set, defines the window's custom decoration area which will receive mouse input, even if normal input to the window is blocked (such as when it has an exclusive child opened). See also <see cref="Godot.Window.NonclientWindowInput"/>.</para>
    /// </summary>
    public Rect2I NonclientArea
    {
        get
        {
            return GetNonclientArea();
        }
        set
        {
            SetNonclientArea(value);
        }
    }

    /// <summary>
    /// <para>Sets a polygonal region of the window which accepts mouse events. Mouse events outside the region will be passed through.</para>
    /// <para>Passing an empty array will disable passthrough support (all mouse events will be intercepted by the window, which is the default behavior).</para>
    /// <para><code>
    /// // Set region, using Path2D node.
    /// GetNode&lt;Window&gt;("Window").MousePassthroughPolygon = GetNode&lt;Path2D&gt;("Path2D").Curve.GetBakedPoints();
    /// 
    /// // Set region, using Polygon2D node.
    /// GetNode&lt;Window&gt;("Window").MousePassthroughPolygon = GetNode&lt;Polygon2D&gt;("Polygon2D").Polygon;
    /// 
    /// // Reset region to default.
    /// GetNode&lt;Window&gt;("Window").MousePassthroughPolygon = [];
    /// </code></para>
    /// <para><b>Note:</b> This property is ignored if <see cref="Godot.Window.MousePassthrough"/> is set to <see langword="true"/>.</para>
    /// <para><b>Note:</b> On Windows, the portion of a window that lies outside the region is not drawn, while on Linux (X11) and macOS it is.</para>
    /// <para><b>Note:</b> This property is implemented on Linux (X11), macOS and Windows.</para>
    /// </summary>
    public Vector2[] MousePassthroughPolygon
    {
        get
        {
            return GetMousePassthroughPolygon();
        }
        set
        {
            SetMousePassthroughPolygon(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the window is visible.</para>
    /// </summary>
    public bool Visible
    {
        get
        {
            return IsVisible();
        }
        set
        {
            SetVisible(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the window's size will automatically update when a child node is added or removed, ignoring <see cref="Godot.Window.MinSize"/> if the new size is bigger.</para>
    /// <para>If <see langword="false"/>, you need to call <see cref="Godot.Window.ChildControlsChanged()"/> manually.</para>
    /// </summary>
    public bool WrapControls
    {
        get
        {
            return IsWrappingControls();
        }
        set
        {
            SetWrapControls(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the <see cref="Godot.Window"/> is transient, i.e. it's considered a child of another <see cref="Godot.Window"/>. The transient window will be destroyed with its transient parent and will return focus to their parent when closed. The transient window is displayed on top of a non-exclusive full-screen parent window. Transient windows can't enter full-screen mode.</para>
    /// <para>Note that behavior might be different depending on the platform.</para>
    /// </summary>
    public bool Transient
    {
        get
        {
            return IsTransient();
        }
        set
        {
            SetTransient(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, and the <see cref="Godot.Window"/> is <see cref="Godot.Window.Transient"/>, this window will (at the time of becoming visible) become transient to the currently focused window instead of the immediate parent window in the hierarchy. Note that the transient parent is assigned at the time this window becomes visible, so changing it afterwards has no effect until re-shown.</para>
    /// </summary>
    public bool TransientToFocused
    {
        get
        {
            return IsTransientToFocused();
        }
        set
        {
            SetTransientToFocused(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the <see cref="Godot.Window"/> will be in exclusive mode. Exclusive windows are always on top of their parent and will block all input going to the parent <see cref="Godot.Window"/>.</para>
    /// <para>Needs <see cref="Godot.Window.Transient"/> enabled to work.</para>
    /// </summary>
    public bool Exclusive
    {
        get
        {
            return IsExclusive();
        }
        set
        {
            SetExclusive(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the window can't be resized.</para>
    /// </summary>
    public bool Unresizable
    {
        get
        {
            return GetFlag((Window.Flags)(0));
        }
        set
        {
            SetFlag((Window.Flags)(0), value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the window will have no borders.</para>
    /// </summary>
    public bool Borderless
    {
        get
        {
            return GetFlag((Window.Flags)(1));
        }
        set
        {
            SetFlag((Window.Flags)(1), value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the window will be on top of all other windows. Does not work if <see cref="Godot.Window.Transient"/> is enabled.</para>
    /// </summary>
    public bool AlwaysOnTop
    {
        get
        {
            return GetFlag((Window.Flags)(2));
        }
        set
        {
            SetFlag((Window.Flags)(2), value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the <see cref="Godot.Window"/>'s background can be transparent. This is best used with embedded windows.</para>
    /// <para><b>Note:</b> Transparency support is implemented on Linux, macOS and Windows, but availability might vary depending on GPU driver, display manager, and compositor capabilities.</para>
    /// <para><b>Note:</b> This property has no effect if <c>ProjectSettings.display/window/per_pixel_transparency/allowed</c> is set to <see langword="false"/>.</para>
    /// </summary>
    public bool Transparent
    {
        get
        {
            return GetFlag((Window.Flags)(3));
        }
        set
        {
            SetFlag((Window.Flags)(3), value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the <see cref="Godot.Window"/> can't be focused nor interacted with. It can still be visible.</para>
    /// </summary>
    public bool Unfocusable
    {
        get
        {
            return GetFlag((Window.Flags)(4));
        }
        set
        {
            SetFlag((Window.Flags)(4), value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the <see cref="Godot.Window"/> will be considered a popup. Popups are sub-windows that don't show as separate windows in system's window manager's window list and will send close request when anything is clicked outside of them (unless <see cref="Godot.Window.Exclusive"/> is enabled).</para>
    /// </summary>
    public bool PopupWindow
    {
        get
        {
            return GetFlag((Window.Flags)(5));
        }
        set
        {
            SetFlag((Window.Flags)(5), value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the <see cref="Godot.Window"/> contents is expanded to the full size of the window, window title bar is transparent.</para>
    /// <para><b>Note:</b> This property is implemented only on macOS.</para>
    /// <para><b>Note:</b> This property only works with native windows.</para>
    /// </summary>
    public bool ExtendToTitle
    {
        get
        {
            return GetFlag((Window.Flags)(6));
        }
        set
        {
            SetFlag((Window.Flags)(6), value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, all mouse events will be passed to the underlying window of the same application. See also <see cref="Godot.Window.MousePassthroughPolygon"/>.</para>
    /// <para><b>Note:</b> This property is implemented on Linux (X11), macOS and Windows.</para>
    /// <para><b>Note:</b> This property only works with native windows.</para>
    /// </summary>
    public bool MousePassthrough
    {
        get
        {
            return GetFlag((Window.Flags)(7));
        }
        set
        {
            SetFlag((Window.Flags)(7), value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the <see cref="Godot.Window"/> will override the OS window style to display sharp corners.</para>
    /// <para><b>Note:</b> This property is implemented only on Windows (11).</para>
    /// <para><b>Note:</b> This property only works with native windows.</para>
    /// </summary>
    public bool SharpCorners
    {
        get
        {
            return GetFlag((Window.Flags)(8));
        }
        set
        {
            SetFlag((Window.Flags)(8), value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the <see cref="Godot.Window"/> is excluded from screenshots taken by <see cref="Godot.DisplayServer.ScreenGetImage(int)"/>, <see cref="Godot.DisplayServer.ScreenGetImageRect(Rect2I)"/>, and <see cref="Godot.DisplayServer.ScreenGetPixel(Vector2I)"/>.</para>
    /// <para><b>Note:</b> This property is implemented on macOS and Windows.</para>
    /// <para><b>Note:</b> Enabling this setting will prevent standard screenshot methods from capturing a window image, but does <b>NOT</b> guarantee that other apps won't be able to capture an image. It should not be used as a DRM or security measure.</para>
    /// </summary>
    public bool ExcludeFromCapture
    {
        get
        {
            return GetFlag((Window.Flags)(9));
        }
        set
        {
            SetFlag((Window.Flags)(9), value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the <see cref="Godot.Window"/> will signal to the window manager that it is supposed to be an implementation-defined "popup" (usually a floating, borderless, untileable and immovable child window).</para>
    /// </summary>
    public bool PopupWMHint
    {
        get
        {
            return GetFlag((Window.Flags)(10));
        }
        set
        {
            SetFlag((Window.Flags)(10), value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the <see cref="Godot.Window"/>'s minimize button is disabled.</para>
    /// <para><b>Note:</b> If both minimize and maximize buttons are disabled, buttons are fully hidden, and only close button is visible.</para>
    /// <para><b>Note:</b> This property is implemented only on macOS and Windows.</para>
    /// </summary>
    public bool MinimizeDisabled
    {
        get
        {
            return GetFlag((Window.Flags)(11));
        }
        set
        {
            SetFlag((Window.Flags)(11), value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the <see cref="Godot.Window"/>'s maximize button is disabled.</para>
    /// <para><b>Note:</b> If both minimize and maximize buttons are disabled, buttons are fully hidden, and only close button is visible.</para>
    /// <para><b>Note:</b> This property is implemented only on macOS and Windows.</para>
    /// </summary>
    public bool MaximizeDisabled
    {
        get
        {
            return GetFlag((Window.Flags)(12));
        }
        set
        {
            SetFlag((Window.Flags)(12), value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, native window will be used regardless of parent viewport and project settings.</para>
    /// </summary>
    public bool ForceNative
    {
        get
        {
            return GetForceNative();
        }
        set
        {
            SetForceNative(value);
        }
    }

    /// <summary>
    /// <para>If non-zero, the <see cref="Godot.Window"/> can't be resized to be smaller than this size.</para>
    /// <para><b>Note:</b> This property will be ignored in favor of <see cref="Godot.Window.GetContentsMinimumSize()"/> if <see cref="Godot.Window.WrapControls"/> is enabled and if its size is bigger.</para>
    /// </summary>
    public Vector2I MinSize
    {
        get
        {
            return GetMinSize();
        }
        set
        {
            SetMinSize(value);
        }
    }

    /// <summary>
    /// <para>If non-zero, the <see cref="Godot.Window"/> can't be resized to be bigger than this size.</para>
    /// <para><b>Note:</b> This property will be ignored if the value is lower than <see cref="Godot.Window.MinSize"/>.</para>
    /// </summary>
    public Vector2I MaxSize
    {
        get
        {
            return GetMaxSize();
        }
        set
        {
            SetMaxSize(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the <see cref="Godot.Window"/> width is expanded to keep the title bar text fully visible.</para>
    /// </summary>
    public bool KeepTitleVisible
    {
        get
        {
            return GetKeepTitleVisible();
        }
        set
        {
            SetKeepTitleVisible(value);
        }
    }

    /// <summary>
    /// <para>The content's base size in "virtual" pixels. Not to be confused with <see cref="Godot.Window.Size"/>, which sets the actual window's physical size in pixels. If set to a value greater than <c>0</c> and <see cref="Godot.Window.ContentScaleMode"/> is set to a value other than <see cref="Godot.Window.ContentScaleModeEnum.Disabled"/>, the <see cref="Godot.Window"/>'s content will be scaled when the window is resized to a different size. Higher values will make the content appear <i>smaller</i>, as it will be able to fit more of the project in view. On the root <see cref="Godot.Window"/>, this is set to match <c>ProjectSettings.display/window/size/viewport_width</c> and <c>ProjectSettings.display/window/size/viewport_height</c> by default.</para>
    /// <para>For example, when using <see cref="Godot.Window.ContentScaleModeEnum.CanvasItems"/> and <see cref="Godot.Window.ContentScaleSize"/> set to <c>Vector2i(1280, 720)</c>, using a window size of <c>2560×1440</c> will make 2D elements appear at double their original size, as the content is scaled by a factor of <c>2.0</c> (<c>2560.0 / 1280.0 = 2.0</c>, <c>1440.0 / 720.0 = 2.0</c>).</para>
    /// <para>See <a href="$DOCS_URL/tutorials/rendering/multiple_resolutions.html#base-size">the Base size section of the Multiple resolutions documentation</a> for details.</para>
    /// </summary>
    public Vector2I ContentScaleSize
    {
        get
        {
            return GetContentScaleSize();
        }
        set
        {
            SetContentScaleSize(value);
        }
    }

    /// <summary>
    /// <para>Specifies how the content is scaled when the <see cref="Godot.Window"/> is resized.</para>
    /// </summary>
    public Window.ContentScaleModeEnum ContentScaleMode
    {
        get
        {
            return GetContentScaleMode();
        }
        set
        {
            SetContentScaleMode(value);
        }
    }

    /// <summary>
    /// <para>Specifies how the content's aspect behaves when the <see cref="Godot.Window"/> is resized. The base aspect is determined by <see cref="Godot.Window.ContentScaleSize"/>.</para>
    /// </summary>
    public Window.ContentScaleAspectEnum ContentScaleAspect
    {
        get
        {
            return GetContentScaleAspect();
        }
        set
        {
            SetContentScaleAspect(value);
        }
    }

    /// <summary>
    /// <para>The policy to use to determine the final scale factor for 2D elements. This affects how <see cref="Godot.Window.ContentScaleFactor"/> is applied, in addition to the automatic scale factor determined by <see cref="Godot.Window.ContentScaleSize"/>.</para>
    /// </summary>
    public Window.ContentScaleStretchEnum ContentScaleStretch
    {
        get
        {
            return GetContentScaleStretch();
        }
        set
        {
            SetContentScaleStretch(value);
        }
    }

    /// <summary>
    /// <para>Specifies the base scale of <see cref="Godot.Window"/>'s content when its <see cref="Godot.Window.Size"/> is equal to <see cref="Godot.Window.ContentScaleSize"/>. See also <see cref="Godot.Viewport.GetStretchTransform()"/>.</para>
    /// </summary>
    public float ContentScaleFactor
    {
        get
        {
            return GetContentScaleFactor();
        }
        set
        {
            SetContentScaleFactor(value);
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
    /// <para>The name of a theme type variation used by this <see cref="Godot.Window"/> to look up its own theme items. See <see cref="Godot.Control.ThemeTypeVariation"/> for more details.</para>
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

    private static readonly System.Type CachedType = typeof(Window);

    private static readonly StringName NativeName = "Window";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public Window() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal Window(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal Window(bool memoryOwn) : base(memoryOwn) { }

    /// <summary>
    /// <para>Virtual method to be implemented by the user. Overrides the value returned by <see cref="Godot.Window.GetContentsMinimumSize()"/>.</para>
    /// </summary>
    public virtual Vector2 _GetContentsMinimumSize()
    {
        return default;
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTitle, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTitle(string title)
    {
        NativeCalls.godot_icall_1_57(MethodBind0, GodotObject.GetPtr(this), title);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTitle, 201670096ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetTitle()
    {
        return NativeCalls.godot_icall_0_58(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetInitialPosition, 4084468099ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetInitialPosition(Window.WindowInitialPosition initialPosition)
    {
        NativeCalls.godot_icall_1_38(MethodBind2, GodotObject.GetPtr(this), (int)initialPosition);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetInitialPosition, 4294066647ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Window.WindowInitialPosition GetInitialPosition()
    {
        return (Window.WindowInitialPosition)NativeCalls.godot_icall_0_39(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCurrentScreen, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCurrentScreen(int index)
    {
        NativeCalls.godot_icall_1_38(MethodBind4, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCurrentScreen, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetCurrentScreen()
    {
        return NativeCalls.godot_icall_0_39(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPosition, 1130785943ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetPosition(Vector2I position)
    {
        NativeCalls.godot_icall_1_34(MethodBind6, GodotObject.GetPtr(this), &position);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPosition, 3690982128ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2I GetPosition()
    {
        return NativeCalls.godot_icall_0_35(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MoveToCenter, 3218959716ul);

    /// <summary>
    /// <para>Centers the window in the current screen. If the window is embedded, it is centered in the embedder <see cref="Godot.Viewport"/> instead.</para>
    /// </summary>
    public void MoveToCenter()
    {
        NativeCalls.godot_icall_0_3(MethodBind8, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSize, 1130785943ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetSize(Vector2I size)
    {
        NativeCalls.godot_icall_1_34(MethodBind9, GodotObject.GetPtr(this), &size);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSize, 3690982128ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2I GetSize()
    {
        return NativeCalls.godot_icall_0_35(MethodBind10, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ResetSize, 3218959716ul);

    /// <summary>
    /// <para>Resets the size to the minimum size, which is the max of <see cref="Godot.Window.MinSize"/> and (if <see cref="Godot.Window.WrapControls"/> is enabled) <see cref="Godot.Window.GetContentsMinimumSize()"/>. This is equivalent to calling <c>set_size(Vector2i())</c> (or any size below the minimum).</para>
    /// </summary>
    public void ResetSize()
    {
        NativeCalls.godot_icall_0_3(MethodBind11, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPositionWithDecorations, 3690982128ul);

    /// <summary>
    /// <para>Returns the window's position including its border.</para>
    /// <para><b>Note:</b> If <see cref="Godot.Window.Visible"/> is <see langword="false"/>, this method returns the same value as <see cref="Godot.Window.Position"/>.</para>
    /// </summary>
    public Vector2I GetPositionWithDecorations()
    {
        return NativeCalls.godot_icall_0_35(MethodBind12, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSizeWithDecorations, 3690982128ul);

    /// <summary>
    /// <para>Returns the window's size including its border.</para>
    /// <para><b>Note:</b> If <see cref="Godot.Window.Visible"/> is <see langword="false"/>, this method returns the same value as <see cref="Godot.Window.Size"/>.</para>
    /// </summary>
    public Vector2I GetSizeWithDecorations()
    {
        return NativeCalls.godot_icall_0_35(MethodBind13, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMaxSize, 1130785943ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetMaxSize(Vector2I maxSize)
    {
        NativeCalls.godot_icall_1_34(MethodBind14, GodotObject.GetPtr(this), &maxSize);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMaxSize, 3690982128ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2I GetMaxSize()
    {
        return NativeCalls.godot_icall_0_35(MethodBind15, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMinSize, 1130785943ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetMinSize(Vector2I minSize)
    {
        NativeCalls.godot_icall_1_34(MethodBind16, GodotObject.GetPtr(this), &minSize);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMinSize, 3690982128ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2I GetMinSize()
    {
        return NativeCalls.godot_icall_0_35(MethodBind17, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMode, 3095236531ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMode(Window.ModeEnum mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind18, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMode, 2566346114ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Window.ModeEnum GetMode()
    {
        return (Window.ModeEnum)NativeCalls.godot_icall_0_39(MethodBind19, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFlag, 3426449779ul);

    /// <summary>
    /// <para>Sets a specified window flag.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFlag(Window.Flags flag, bool enabled)
    {
        NativeCalls.godot_icall_2_61(MethodBind20, GodotObject.GetPtr(this), (int)flag, enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFlag, 3062752289ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the <paramref name="flag"/> is set.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetFlag(Window.Flags flag)
    {
        return NativeCalls.godot_icall_1_62(MethodBind21, GodotObject.GetPtr(this), (int)flag).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsMaximizeAllowed, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the window can be maximized (the maximize button is enabled).</para>
    /// </summary>
    public bool IsMaximizeAllowed()
    {
        return NativeCalls.godot_icall_0_15(MethodBind22, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RequestAttention, 3218959716ul);

    /// <summary>
    /// <para>Tells the OS that the <see cref="Godot.Window"/> needs an attention. This makes the window stand out in some way depending on the system, e.g. it might blink on the task bar.</para>
    /// </summary>
    public void RequestAttention()
    {
        NativeCalls.godot_icall_0_3(MethodBind23, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.MoveToForeground, 3218959716ul);

    /// <summary>
    /// <para>Causes the window to grab focus, allowing it to receive user input.</para>
    /// </summary>
    [Obsolete("Use 'Godot.Window.GrabFocus()' instead.")]
    public void MoveToForeground()
    {
        NativeCalls.godot_icall_0_3(MethodBind24, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVisible, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetVisible(bool visible)
    {
        NativeCalls.godot_icall_1_14(MethodBind25, GodotObject.GetPtr(this), visible.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsVisible, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsVisible()
    {
        return NativeCalls.godot_icall_0_15(MethodBind26, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Hide, 3218959716ul);

    /// <summary>
    /// <para>Hides the window. This is not the same as minimized state. Hidden window can't be interacted with and needs to be made visible with <see cref="Godot.Window.Show()"/>.</para>
    /// </summary>
    public void Hide()
    {
        NativeCalls.godot_icall_0_3(MethodBind27, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Show, 3218959716ul);

    /// <summary>
    /// <para>Makes the <see cref="Godot.Window"/> appear. This enables interactions with the <see cref="Godot.Window"/> and doesn't change any of its property other than visibility (unlike e.g. <see cref="Godot.Window.Popup(Nullable{Rect2I})"/>).</para>
    /// </summary>
    public void Show()
    {
        NativeCalls.godot_icall_0_3(MethodBind28, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTransient, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTransient(bool transient)
    {
        NativeCalls.godot_icall_1_14(MethodBind29, GodotObject.GetPtr(this), transient.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsTransient, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsTransient()
    {
        return NativeCalls.godot_icall_0_15(MethodBind30, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTransientToFocused, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTransientToFocused(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind31, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind32 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsTransientToFocused, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsTransientToFocused()
    {
        return NativeCalls.godot_icall_0_15(MethodBind32, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind33 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetExclusive, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetExclusive(bool exclusive)
    {
        NativeCalls.godot_icall_1_14(MethodBind33, GodotObject.GetPtr(this), exclusive.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind34 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsExclusive, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsExclusive()
    {
        return NativeCalls.godot_icall_0_15(MethodBind34, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind35 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetUnparentWhenInvisible, 2586408642ul);

    /// <summary>
    /// <para>If <paramref name="unparent"/> is <see langword="true"/>, the window is automatically unparented when going invisible.</para>
    /// <para><b>Note:</b> Make sure to keep a reference to the node, otherwise it will be orphaned. You also need to manually call <see cref="Godot.Node.QueueFree()"/> to free the window if it's not parented.</para>
    /// </summary>
    public void SetUnparentWhenInvisible(bool unparent)
    {
        NativeCalls.godot_icall_1_14(MethodBind35, GodotObject.GetPtr(this), unparent.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind36 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanDraw, 36873697ul);

    /// <summary>
    /// <para>Returns whether the window is being drawn to the screen.</para>
    /// </summary>
    public bool CanDraw()
    {
        return NativeCalls.godot_icall_0_15(MethodBind36, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind37 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasFocus, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the window is focused.</para>
    /// </summary>
    public bool HasFocus()
    {
        return NativeCalls.godot_icall_0_15(MethodBind37, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind38 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GrabFocus, 3218959716ul);

    /// <summary>
    /// <para>Causes the window to grab focus, allowing it to receive user input.</para>
    /// </summary>
    public void GrabFocus()
    {
        NativeCalls.godot_icall_0_3(MethodBind38, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind39 = ClassDB_get_method_with_compatibility(NativeName, MethodName.StartDrag, 3218959716ul);

    /// <summary>
    /// <para>Starts an interactive drag operation on the window, using the current mouse position. Call this method when handling a mouse button being pressed to simulate a pressed event on the window's title bar. Using this method allows the window to participate in space switching, tiling, and other system features.</para>
    /// </summary>
    public void StartDrag()
    {
        NativeCalls.godot_icall_0_3(MethodBind39, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind40 = ClassDB_get_method_with_compatibility(NativeName, MethodName.StartResize, 122288853ul);

    /// <summary>
    /// <para>Starts an interactive resize operation on the window, using the current mouse position. Call this method when handling a mouse button being pressed to simulate a pressed event on the window's edge.</para>
    /// </summary>
    public void StartResize(DisplayServer.WindowResizeEdge edge)
    {
        NativeCalls.godot_icall_1_38(MethodBind40, GodotObject.GetPtr(this), (int)edge);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind41 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetImeActive, 2586408642ul);

    /// <summary>
    /// <para>If <paramref name="active"/> is <see langword="true"/>, enables system's native IME (Input Method Editor).</para>
    /// </summary>
    public void SetImeActive(bool active)
    {
        NativeCalls.godot_icall_1_14(MethodBind41, GodotObject.GetPtr(this), active.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind42 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetImePosition, 1130785943ul);

    /// <summary>
    /// <para>Moves IME to the given position.</para>
    /// </summary>
    public unsafe void SetImePosition(Vector2I position)
    {
        NativeCalls.godot_icall_1_34(MethodBind42, GodotObject.GetPtr(this), &position);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind43 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsEmbedded, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the window is currently embedded in another window.</para>
    /// </summary>
    public bool IsEmbedded()
    {
        return NativeCalls.godot_icall_0_15(MethodBind43, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind44 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetContentsMinimumSize, 3341600327ul);

    /// <summary>
    /// <para>Returns the combined minimum size from the child <see cref="Godot.Control"/> nodes of the window. Use <see cref="Godot.Window.ChildControlsChanged()"/> to update it when child nodes have changed.</para>
    /// <para>The value returned by this method can be overridden with <see cref="Godot.Window._GetContentsMinimumSize()"/>.</para>
    /// </summary>
    public Vector2 GetContentsMinimumSize()
    {
        return NativeCalls.godot_icall_0_37(MethodBind44, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind45 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetForceNative, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetForceNative(bool forceNative)
    {
        NativeCalls.godot_icall_1_14(MethodBind45, GodotObject.GetPtr(this), forceNative.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind46 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetForceNative, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetForceNative()
    {
        return NativeCalls.godot_icall_0_15(MethodBind46, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind47 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetContentScaleSize, 1130785943ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetContentScaleSize(Vector2I size)
    {
        NativeCalls.godot_icall_1_34(MethodBind47, GodotObject.GetPtr(this), &size);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind48 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetContentScaleSize, 3690982128ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2I GetContentScaleSize()
    {
        return NativeCalls.godot_icall_0_35(MethodBind48, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind49 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetContentScaleMode, 2937716473ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetContentScaleMode(Window.ContentScaleModeEnum mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind49, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind50 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetContentScaleMode, 161585230ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Window.ContentScaleModeEnum GetContentScaleMode()
    {
        return (Window.ContentScaleModeEnum)NativeCalls.godot_icall_0_39(MethodBind50, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind51 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetContentScaleAspect, 2370399418ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetContentScaleAspect(Window.ContentScaleAspectEnum aspect)
    {
        NativeCalls.godot_icall_1_38(MethodBind51, GodotObject.GetPtr(this), (int)aspect);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind52 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetContentScaleAspect, 4158790715ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Window.ContentScaleAspectEnum GetContentScaleAspect()
    {
        return (Window.ContentScaleAspectEnum)NativeCalls.godot_icall_0_39(MethodBind52, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind53 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetContentScaleStretch, 349355940ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetContentScaleStretch(Window.ContentScaleStretchEnum stretch)
    {
        NativeCalls.godot_icall_1_38(MethodBind53, GodotObject.GetPtr(this), (int)stretch);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind54 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetContentScaleStretch, 536857316ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Window.ContentScaleStretchEnum GetContentScaleStretch()
    {
        return (Window.ContentScaleStretchEnum)NativeCalls.godot_icall_0_39(MethodBind54, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind55 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetNonclientArea, 1763793166ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetNonclientArea(Rect2I area)
    {
        NativeCalls.godot_icall_1_32(MethodBind55, GodotObject.GetPtr(this), &area);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind56 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNonclientArea, 410525958ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Rect2I GetNonclientArea()
    {
        return NativeCalls.godot_icall_0_33(MethodBind56, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind57 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetKeepTitleVisible, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetKeepTitleVisible(bool titleVisible)
    {
        NativeCalls.godot_icall_1_14(MethodBind57, GodotObject.GetPtr(this), titleVisible.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind58 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetKeepTitleVisible, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetKeepTitleVisible()
    {
        return NativeCalls.godot_icall_0_15(MethodBind58, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind59 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetContentScaleFactor, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetContentScaleFactor(float factor)
    {
        NativeCalls.godot_icall_1_67(MethodBind59, GodotObject.GetPtr(this), factor);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind60 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetContentScaleFactor, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetContentScaleFactor()
    {
        return NativeCalls.godot_icall_0_68(MethodBind60, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind61 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMousePassthroughPolygon, 1509147220ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMousePassthroughPolygon(Vector2[] polygon)
    {
        NativeCalls.godot_icall_1_224(MethodBind61, GodotObject.GetPtr(this), polygon);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMousePassthroughPolygon(ReadOnlySpan<Vector2> polygon)
    {
        NativeCalls.godot_icall_1_224(MethodBind61, GodotObject.GetPtr(this), polygon);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind62 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMousePassthroughPolygon, 2961356807ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2[] GetMousePassthroughPolygon()
    {
        return NativeCalls.godot_icall_0_225(MethodBind62, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind63 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetWrapControls, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetWrapControls(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind63, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind64 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsWrappingControls, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsWrappingControls()
    {
        return NativeCalls.godot_icall_0_15(MethodBind64, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind65 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ChildControlsChanged, 3218959716ul);

    /// <summary>
    /// <para>Requests an update of the <see cref="Godot.Window"/> size to fit underlying <see cref="Godot.Control"/> nodes.</para>
    /// </summary>
    public void ChildControlsChanged()
    {
        NativeCalls.godot_icall_0_3(MethodBind65, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind66 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTheme, 2326690814ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTheme(Theme theme)
    {
        NativeCalls.godot_icall_1_56(MethodBind66, GodotObject.GetPtr(this), GodotObject.GetPtr(theme));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind67 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTheme, 3846893731ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Theme GetTheme()
    {
        return (Theme)NativeCalls.godot_icall_0_63(MethodBind67, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind68 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetThemeTypeVariation, 3304788590ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetThemeTypeVariation(StringName themeType)
    {
        NativeCalls.godot_icall_1_64(MethodBind68, GodotObject.GetPtr(this), (godot_string_name)(themeType?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind69 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetThemeTypeVariation, 2002593661ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public StringName GetThemeTypeVariation()
    {
        return NativeCalls.godot_icall_0_65(MethodBind69, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind70 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BeginBulkThemeOverride, 3218959716ul);

    /// <summary>
    /// <para>Prevents <c>*_theme_*_override</c> methods from emitting <see cref="Godot.Window.NotificationThemeChanged"/> until <see cref="Godot.Window.EndBulkThemeOverride()"/> is called.</para>
    /// </summary>
    public void BeginBulkThemeOverride()
    {
        NativeCalls.godot_icall_0_3(MethodBind70, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind71 = ClassDB_get_method_with_compatibility(NativeName, MethodName.EndBulkThemeOverride, 3218959716ul);

    /// <summary>
    /// <para>Ends a bulk theme override update. See <see cref="Godot.Window.BeginBulkThemeOverride()"/>.</para>
    /// </summary>
    public void EndBulkThemeOverride()
    {
        NativeCalls.godot_icall_0_3(MethodBind71, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind72 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddThemeIconOverride, 1373065600ul);

    /// <summary>
    /// <para>Creates a local override for a theme icon with the specified <paramref name="name"/>. Local overrides always take precedence when fetching theme items for the control. An override can be removed with <see cref="Godot.Window.RemoveThemeIconOverride(StringName)"/>.</para>
    /// <para>See also <see cref="Godot.Window.GetThemeIcon(StringName, StringName)"/>.</para>
    /// </summary>
    public void AddThemeIconOverride(StringName name, Texture2D texture)
    {
        NativeCalls.godot_icall_2_159(MethodBind72, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default), GodotObject.GetPtr(texture));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind73 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddThemeStyleboxOverride, 4188838905ul);

    /// <summary>
    /// <para>Creates a local override for a theme <see cref="Godot.StyleBox"/> with the specified <paramref name="name"/>. Local overrides always take precedence when fetching theme items for the control. An override can be removed with <see cref="Godot.Window.RemoveThemeStyleboxOverride(StringName)"/>.</para>
    /// <para>See also <see cref="Godot.Window.GetThemeStylebox(StringName, StringName)"/> and <see cref="Godot.Control.AddThemeStyleboxOverride(StringName, StyleBox)"/> for more details.</para>
    /// </summary>
    public void AddThemeStyleboxOverride(StringName name, StyleBox stylebox)
    {
        NativeCalls.godot_icall_2_159(MethodBind73, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default), GodotObject.GetPtr(stylebox));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind74 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddThemeFontOverride, 3518018674ul);

    /// <summary>
    /// <para>Creates a local override for a theme <see cref="Godot.Font"/> with the specified <paramref name="name"/>. Local overrides always take precedence when fetching theme items for the control. An override can be removed with <see cref="Godot.Window.RemoveThemeFontOverride(StringName)"/>.</para>
    /// <para>See also <see cref="Godot.Window.GetThemeFont(StringName, StringName)"/>.</para>
    /// </summary>
    public void AddThemeFontOverride(StringName name, Font font)
    {
        NativeCalls.godot_icall_2_159(MethodBind74, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default), GodotObject.GetPtr(font));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind75 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddThemeFontSizeOverride, 2415702435ul);

    /// <summary>
    /// <para>Creates a local override for a theme font size with the specified <paramref name="name"/>. Local overrides always take precedence when fetching theme items for the control. An override can be removed with <see cref="Godot.Window.RemoveThemeFontSizeOverride(StringName)"/>.</para>
    /// <para>See also <see cref="Godot.Window.GetThemeFontSize(StringName, StringName)"/>.</para>
    /// </summary>
    public void AddThemeFontSizeOverride(StringName name, int fontSize)
    {
        NativeCalls.godot_icall_2_154(MethodBind75, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default), fontSize);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind76 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddThemeColorOverride, 4260178595ul);

    /// <summary>
    /// <para>Creates a local override for a theme <see cref="Godot.Color"/> with the specified <paramref name="name"/>. Local overrides always take precedence when fetching theme items for the control. An override can be removed with <see cref="Godot.Window.RemoveThemeColorOverride(StringName)"/>.</para>
    /// <para>See also <see cref="Godot.Window.GetThemeColor(StringName, StringName)"/> and <see cref="Godot.Control.AddThemeColorOverride(StringName, Color)"/> for more details.</para>
    /// </summary>
    public unsafe void AddThemeColorOverride(StringName name, Color color)
    {
        NativeCalls.godot_icall_2_110(MethodBind76, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default), &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind77 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddThemeConstantOverride, 2415702435ul);

    /// <summary>
    /// <para>Creates a local override for a theme constant with the specified <paramref name="name"/>. Local overrides always take precedence when fetching theme items for the control. An override can be removed with <see cref="Godot.Window.RemoveThemeConstantOverride(StringName)"/>.</para>
    /// <para>See also <see cref="Godot.Window.GetThemeConstant(StringName, StringName)"/>.</para>
    /// </summary>
    public void AddThemeConstantOverride(StringName name, int constant)
    {
        NativeCalls.godot_icall_2_154(MethodBind77, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default), constant);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind78 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveThemeIconOverride, 3304788590ul);

    /// <summary>
    /// <para>Removes a local override for a theme icon with the specified <paramref name="name"/> previously added by <see cref="Godot.Window.AddThemeIconOverride(StringName, Texture2D)"/> or via the Inspector dock.</para>
    /// </summary>
    public void RemoveThemeIconOverride(StringName name)
    {
        NativeCalls.godot_icall_1_64(MethodBind78, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind79 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveThemeStyleboxOverride, 3304788590ul);

    /// <summary>
    /// <para>Removes a local override for a theme <see cref="Godot.StyleBox"/> with the specified <paramref name="name"/> previously added by <see cref="Godot.Window.AddThemeStyleboxOverride(StringName, StyleBox)"/> or via the Inspector dock.</para>
    /// </summary>
    public void RemoveThemeStyleboxOverride(StringName name)
    {
        NativeCalls.godot_icall_1_64(MethodBind79, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind80 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveThemeFontOverride, 3304788590ul);

    /// <summary>
    /// <para>Removes a local override for a theme <see cref="Godot.Font"/> with the specified <paramref name="name"/> previously added by <see cref="Godot.Window.AddThemeFontOverride(StringName, Font)"/> or via the Inspector dock.</para>
    /// </summary>
    public void RemoveThemeFontOverride(StringName name)
    {
        NativeCalls.godot_icall_1_64(MethodBind80, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind81 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveThemeFontSizeOverride, 3304788590ul);

    /// <summary>
    /// <para>Removes a local override for a theme font size with the specified <paramref name="name"/> previously added by <see cref="Godot.Window.AddThemeFontSizeOverride(StringName, int)"/> or via the Inspector dock.</para>
    /// </summary>
    public void RemoveThemeFontSizeOverride(StringName name)
    {
        NativeCalls.godot_icall_1_64(MethodBind81, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind82 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveThemeColorOverride, 3304788590ul);

    /// <summary>
    /// <para>Removes a local override for a theme <see cref="Godot.Color"/> with the specified <paramref name="name"/> previously added by <see cref="Godot.Window.AddThemeColorOverride(StringName, Color)"/> or via the Inspector dock.</para>
    /// </summary>
    public void RemoveThemeColorOverride(StringName name)
    {
        NativeCalls.godot_icall_1_64(MethodBind82, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind83 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveThemeConstantOverride, 3304788590ul);

    /// <summary>
    /// <para>Removes a local override for a theme constant with the specified <paramref name="name"/> previously added by <see cref="Godot.Window.AddThemeConstantOverride(StringName, int)"/> or via the Inspector dock.</para>
    /// </summary>
    public void RemoveThemeConstantOverride(StringName name)
    {
        NativeCalls.godot_icall_1_64(MethodBind83, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind84 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetThemeIcon, 3163973443ul);

    /// <summary>
    /// <para>Returns an icon from the first matching <see cref="Godot.Theme"/> in the tree if that <see cref="Godot.Theme"/> has an icon item with the specified <paramref name="name"/> and <paramref name="themeType"/>.</para>
    /// <para>See <see cref="Godot.Control.GetThemeColor(StringName, StringName)"/> for details.</para>
    /// </summary>
    public Texture2D GetThemeIcon(StringName name, StringName themeType = null)
    {
        return (Texture2D)NativeCalls.godot_icall_2_336(MethodBind84, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default), (godot_string_name)(themeType?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind85 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetThemeStylebox, 604739069ul);

    /// <summary>
    /// <para>Returns a <see cref="Godot.StyleBox"/> from the first matching <see cref="Godot.Theme"/> in the tree if that <see cref="Godot.Theme"/> has a stylebox item with the specified <paramref name="name"/> and <paramref name="themeType"/>.</para>
    /// <para>See <see cref="Godot.Control.GetThemeColor(StringName, StringName)"/> for details.</para>
    /// </summary>
    public StyleBox GetThemeStylebox(StringName name, StringName themeType = null)
    {
        return (StyleBox)NativeCalls.godot_icall_2_336(MethodBind85, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default), (godot_string_name)(themeType?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind86 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetThemeFont, 2826986490ul);

    /// <summary>
    /// <para>Returns a <see cref="Godot.Font"/> from the first matching <see cref="Godot.Theme"/> in the tree if that <see cref="Godot.Theme"/> has a font item with the specified <paramref name="name"/> and <paramref name="themeType"/>.</para>
    /// <para>See <see cref="Godot.Control.GetThemeColor(StringName, StringName)"/> for details.</para>
    /// </summary>
    public Font GetThemeFont(StringName name, StringName themeType = null)
    {
        return (Font)NativeCalls.godot_icall_2_336(MethodBind86, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default), (godot_string_name)(themeType?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind87 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetThemeFontSize, 1327056374ul);

    /// <summary>
    /// <para>Returns a font size from the first matching <see cref="Godot.Theme"/> in the tree if that <see cref="Godot.Theme"/> has a font size item with the specified <paramref name="name"/> and <paramref name="themeType"/>.</para>
    /// <para>See <see cref="Godot.Control.GetThemeColor(StringName, StringName)"/> for details.</para>
    /// </summary>
    public int GetThemeFontSize(StringName name, StringName themeType = null)
    {
        return NativeCalls.godot_icall_2_337(MethodBind87, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default), (godot_string_name)(themeType?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind88 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetThemeColor, 2798751242ul);

    /// <summary>
    /// <para>Returns a <see cref="Godot.Color"/> from the first matching <see cref="Godot.Theme"/> in the tree if that <see cref="Godot.Theme"/> has a color item with the specified <paramref name="name"/> and <paramref name="themeType"/>.</para>
    /// <para>See <see cref="Godot.Control.GetThemeColor(StringName, StringName)"/> for more details.</para>
    /// </summary>
    public Color GetThemeColor(StringName name, StringName themeType = null)
    {
        return NativeCalls.godot_icall_2_338(MethodBind88, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default), (godot_string_name)(themeType?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind89 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetThemeConstant, 1327056374ul);

    /// <summary>
    /// <para>Returns a constant from the first matching <see cref="Godot.Theme"/> in the tree if that <see cref="Godot.Theme"/> has a constant item with the specified <paramref name="name"/> and <paramref name="themeType"/>.</para>
    /// <para>See <see cref="Godot.Control.GetThemeColor(StringName, StringName)"/> for more details.</para>
    /// </summary>
    public int GetThemeConstant(StringName name, StringName themeType = null)
    {
        return NativeCalls.godot_icall_2_337(MethodBind89, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default), (godot_string_name)(themeType?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind90 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasThemeIconOverride, 2619796661ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if there is a local override for a theme icon with the specified <paramref name="name"/> in this <see cref="Godot.Control"/> node.</para>
    /// <para>See <see cref="Godot.Window.AddThemeIconOverride(StringName, Texture2D)"/>.</para>
    /// </summary>
    public bool HasThemeIconOverride(StringName name)
    {
        return NativeCalls.godot_icall_1_105(MethodBind90, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind91 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasThemeStyleboxOverride, 2619796661ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if there is a local override for a theme <see cref="Godot.StyleBox"/> with the specified <paramref name="name"/> in this <see cref="Godot.Control"/> node.</para>
    /// <para>See <see cref="Godot.Window.AddThemeStyleboxOverride(StringName, StyleBox)"/>.</para>
    /// </summary>
    public bool HasThemeStyleboxOverride(StringName name)
    {
        return NativeCalls.godot_icall_1_105(MethodBind91, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind92 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasThemeFontOverride, 2619796661ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if there is a local override for a theme <see cref="Godot.Font"/> with the specified <paramref name="name"/> in this <see cref="Godot.Control"/> node.</para>
    /// <para>See <see cref="Godot.Window.AddThemeFontOverride(StringName, Font)"/>.</para>
    /// </summary>
    public bool HasThemeFontOverride(StringName name)
    {
        return NativeCalls.godot_icall_1_105(MethodBind92, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind93 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasThemeFontSizeOverride, 2619796661ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if there is a local override for a theme font size with the specified <paramref name="name"/> in this <see cref="Godot.Control"/> node.</para>
    /// <para>See <see cref="Godot.Window.AddThemeFontSizeOverride(StringName, int)"/>.</para>
    /// </summary>
    public bool HasThemeFontSizeOverride(StringName name)
    {
        return NativeCalls.godot_icall_1_105(MethodBind93, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind94 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasThemeColorOverride, 2619796661ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if there is a local override for a theme <see cref="Godot.Color"/> with the specified <paramref name="name"/> in this <see cref="Godot.Control"/> node.</para>
    /// <para>See <see cref="Godot.Window.AddThemeColorOverride(StringName, Color)"/>.</para>
    /// </summary>
    public bool HasThemeColorOverride(StringName name)
    {
        return NativeCalls.godot_icall_1_105(MethodBind94, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind95 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasThemeConstantOverride, 2619796661ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if there is a local override for a theme constant with the specified <paramref name="name"/> in this <see cref="Godot.Control"/> node.</para>
    /// <para>See <see cref="Godot.Window.AddThemeConstantOverride(StringName, int)"/>.</para>
    /// </summary>
    public bool HasThemeConstantOverride(StringName name)
    {
        return NativeCalls.godot_icall_1_105(MethodBind95, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind96 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasThemeIcon, 866386512ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if there is a matching <see cref="Godot.Theme"/> in the tree that has an icon item with the specified <paramref name="name"/> and <paramref name="themeType"/>.</para>
    /// <para>See <see cref="Godot.Control.GetThemeColor(StringName, StringName)"/> for details.</para>
    /// </summary>
    public bool HasThemeIcon(StringName name, StringName themeType = null)
    {
        return NativeCalls.godot_icall_2_160(MethodBind96, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default), (godot_string_name)(themeType?.NativeValue ?? default)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind97 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasThemeStylebox, 866386512ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if there is a matching <see cref="Godot.Theme"/> in the tree that has a stylebox item with the specified <paramref name="name"/> and <paramref name="themeType"/>.</para>
    /// <para>See <see cref="Godot.Control.GetThemeColor(StringName, StringName)"/> for details.</para>
    /// </summary>
    public bool HasThemeStylebox(StringName name, StringName themeType = null)
    {
        return NativeCalls.godot_icall_2_160(MethodBind97, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default), (godot_string_name)(themeType?.NativeValue ?? default)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind98 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasThemeFont, 866386512ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if there is a matching <see cref="Godot.Theme"/> in the tree that has a font item with the specified <paramref name="name"/> and <paramref name="themeType"/>.</para>
    /// <para>See <see cref="Godot.Control.GetThemeColor(StringName, StringName)"/> for details.</para>
    /// </summary>
    public bool HasThemeFont(StringName name, StringName themeType = null)
    {
        return NativeCalls.godot_icall_2_160(MethodBind98, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default), (godot_string_name)(themeType?.NativeValue ?? default)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind99 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasThemeFontSize, 866386512ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if there is a matching <see cref="Godot.Theme"/> in the tree that has a font size item with the specified <paramref name="name"/> and <paramref name="themeType"/>.</para>
    /// <para>See <see cref="Godot.Control.GetThemeColor(StringName, StringName)"/> for details.</para>
    /// </summary>
    public bool HasThemeFontSize(StringName name, StringName themeType = null)
    {
        return NativeCalls.godot_icall_2_160(MethodBind99, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default), (godot_string_name)(themeType?.NativeValue ?? default)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind100 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasThemeColor, 866386512ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if there is a matching <see cref="Godot.Theme"/> in the tree that has a color item with the specified <paramref name="name"/> and <paramref name="themeType"/>.</para>
    /// <para>See <see cref="Godot.Control.GetThemeColor(StringName, StringName)"/> for details.</para>
    /// </summary>
    public bool HasThemeColor(StringName name, StringName themeType = null)
    {
        return NativeCalls.godot_icall_2_160(MethodBind100, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default), (godot_string_name)(themeType?.NativeValue ?? default)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind101 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasThemeConstant, 866386512ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if there is a matching <see cref="Godot.Theme"/> in the tree that has a constant item with the specified <paramref name="name"/> and <paramref name="themeType"/>.</para>
    /// <para>See <see cref="Godot.Control.GetThemeColor(StringName, StringName)"/> for details.</para>
    /// </summary>
    public bool HasThemeConstant(StringName name, StringName themeType = null)
    {
        return NativeCalls.godot_icall_2_160(MethodBind101, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default), (godot_string_name)(themeType?.NativeValue ?? default)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind102 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetThemeDefaultBaseScale, 1740695150ul);

    /// <summary>
    /// <para>Returns the default base scale value from the first matching <see cref="Godot.Theme"/> in the tree if that <see cref="Godot.Theme"/> has a valid <see cref="Godot.Theme.DefaultBaseScale"/> value.</para>
    /// <para>See <see cref="Godot.Control.GetThemeColor(StringName, StringName)"/> for details.</para>
    /// </summary>
    public float GetThemeDefaultBaseScale()
    {
        return NativeCalls.godot_icall_0_68(MethodBind102, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind103 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetThemeDefaultFont, 3229501585ul);

    /// <summary>
    /// <para>Returns the default font from the first matching <see cref="Godot.Theme"/> in the tree if that <see cref="Godot.Theme"/> has a valid <see cref="Godot.Theme.DefaultFont"/> value.</para>
    /// <para>See <see cref="Godot.Control.GetThemeColor(StringName, StringName)"/> for details.</para>
    /// </summary>
    public Font GetThemeDefaultFont()
    {
        return (Font)NativeCalls.godot_icall_0_63(MethodBind103, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind104 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetThemeDefaultFontSize, 3905245786ul);

    /// <summary>
    /// <para>Returns the default font size value from the first matching <see cref="Godot.Theme"/> in the tree if that <see cref="Godot.Theme"/> has a valid <see cref="Godot.Theme.DefaultFontSize"/> value.</para>
    /// <para>See <see cref="Godot.Control.GetThemeColor(StringName, StringName)"/> for details.</para>
    /// </summary>
    public int GetThemeDefaultFontSize()
    {
        return NativeCalls.godot_icall_0_39(MethodBind104, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind105 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetWindowId, 3905245786ul);

    /// <summary>
    /// <para>Returns the ID of the window.</para>
    /// </summary>
    public int GetWindowId()
    {
        return NativeCalls.godot_icall_0_39(MethodBind105, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind106 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAccessibilityName, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAccessibilityName(string name)
    {
        NativeCalls.godot_icall_1_57(MethodBind106, GodotObject.GetPtr(this), name);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind107 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAccessibilityName, 201670096ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetAccessibilityName()
    {
        return NativeCalls.godot_icall_0_58(MethodBind107, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind108 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAccessibilityDescription, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAccessibilityDescription(string description)
    {
        NativeCalls.godot_icall_1_57(MethodBind108, GodotObject.GetPtr(this), description);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind109 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAccessibilityDescription, 201670096ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetAccessibilityDescription()
    {
        return NativeCalls.godot_icall_0_58(MethodBind109, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind110 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFocusedWindow, 1835468782ul);

    /// <summary>
    /// <para>Returns the focused window.</para>
    /// </summary>
    public static Window GetFocusedWindow()
    {
        return (Window)NativeCalls.godot_icall_0_1505(MethodBind110);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind111 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLayoutDirection, 3094704184ul);

    /// <summary>
    /// <para>Sets layout direction and text writing direction. Right-to-left layouts are necessary for certain languages (e.g. Arabic and Hebrew).</para>
    /// </summary>
    public void SetLayoutDirection(Window.LayoutDirection direction)
    {
        NativeCalls.godot_icall_1_38(MethodBind111, GodotObject.GetPtr(this), (int)direction);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind112 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLayoutDirection, 3909617982ul);

    /// <summary>
    /// <para>Returns layout direction and text writing direction.</para>
    /// </summary>
    public Window.LayoutDirection GetLayoutDirection()
    {
        return (Window.LayoutDirection)NativeCalls.godot_icall_0_39(MethodBind112, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind113 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsLayoutRtl, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the layout is right-to-left.</para>
    /// </summary>
    public bool IsLayoutRtl()
    {
        return NativeCalls.godot_icall_0_15(MethodBind113, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind114 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAutoTranslate, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAutoTranslate(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind114, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind115 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsAutoTranslating, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsAutoTranslating()
    {
        return NativeCalls.godot_icall_0_15(MethodBind115, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind116 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetUseFontOversampling, 2586408642ul);

    /// <summary>
    /// <para>Enables font oversampling. This makes fonts look better when they are scaled up.</para>
    /// </summary>
    public void SetUseFontOversampling(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind116, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind117 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsUsingFontOversampling, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if font oversampling is enabled. See <see cref="Godot.Window.SetUseFontOversampling(bool)"/>.</para>
    /// </summary>
    public bool IsUsingFontOversampling()
    {
        return NativeCalls.godot_icall_0_15(MethodBind117, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind118 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Popup, 1680304321ul);

    /// <summary>
    /// <para>Shows the <see cref="Godot.Window"/> and makes it transient (see <see cref="Godot.Window.Transient"/>). If <paramref name="rect"/> is provided, it will be set as the <see cref="Godot.Window"/>'s size. Fails if called on the main window.</para>
    /// <para>If <c>ProjectSettings.display/window/subwindows/embed_subwindows</c> is <see langword="true"/> (single-window mode), <paramref name="rect"/>'s coordinates are global and relative to the main window's top-left corner (excluding window decorations). If <paramref name="rect"/>'s position coordinates are negative, the window will be located outside the main window and may not be visible as a result.</para>
    /// <para>If <c>ProjectSettings.display/window/subwindows/embed_subwindows</c> is <see langword="false"/> (multi-window mode), <paramref name="rect"/>'s coordinates are global and relative to the top-left corner of the leftmost screen. If <paramref name="rect"/>'s position coordinates are negative, the window will be placed at the top-left corner of the screen.</para>
    /// <para><b>Note:</b> <paramref name="rect"/> must be in global coordinates if specified.</para>
    /// </summary>
    /// <param name="rect">If the parameter is null, then the default value is <c>new Rect2I(new Vector2I(0, 0), new Vector2I(0, 0))</c>.</param>
    public unsafe void Popup(Nullable<Rect2I> rect = null)
    {
        Rect2I rectOrDefVal = rect.HasValue ? rect.Value : new Rect2I(new Vector2I(0, 0), new Vector2I(0, 0));
        NativeCalls.godot_icall_1_32(MethodBind118, GodotObject.GetPtr(this), &rectOrDefVal);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind119 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PopupOnParent, 1763793166ul);

    /// <summary>
    /// <para>Popups the <see cref="Godot.Window"/> with a position shifted by parent <see cref="Godot.Window"/>'s position. If the <see cref="Godot.Window"/> is embedded, has the same effect as <see cref="Godot.Window.Popup(Nullable{Rect2I})"/>.</para>
    /// </summary>
    public unsafe void PopupOnParent(Rect2I parentRect)
    {
        NativeCalls.godot_icall_1_32(MethodBind119, GodotObject.GetPtr(this), &parentRect);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind120 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PopupCentered, 3447975422ul);

    /// <summary>
    /// <para>Popups the <see cref="Godot.Window"/> at the center of the current screen, with optionally given minimum size. If the <see cref="Godot.Window"/> is embedded, it will be centered in the parent <see cref="Godot.Viewport"/> instead.</para>
    /// <para><b>Note:</b> Calling it with the default value of <paramref name="minsize"/> is equivalent to calling it with <see cref="Godot.Window.Size"/>.</para>
    /// </summary>
    /// <param name="minsize">If the parameter is null, then the default value is <c>new Vector2I(0, 0)</c>.</param>
    public unsafe void PopupCentered(Nullable<Vector2I> minsize = null)
    {
        Vector2I minsizeOrDefVal = minsize.HasValue ? minsize.Value : new Vector2I(0, 0);
        NativeCalls.godot_icall_1_34(MethodBind120, GodotObject.GetPtr(this), &minsizeOrDefVal);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind121 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PopupCenteredRatio, 1014814997ul);

    /// <summary>
    /// <para>If <see cref="Godot.Window"/> is embedded, popups the <see cref="Godot.Window"/> centered inside its embedder and sets its size as a <paramref name="ratio"/> of embedder's size.</para>
    /// <para>If <see cref="Godot.Window"/> is a native window, popups the <see cref="Godot.Window"/> centered inside the screen of its parent <see cref="Godot.Window"/> and sets its size as a <paramref name="ratio"/> of the screen size.</para>
    /// </summary>
    public void PopupCenteredRatio(float ratio = 0.8f)
    {
        NativeCalls.godot_icall_1_67(MethodBind121, GodotObject.GetPtr(this), ratio);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind122 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PopupCenteredClamped, 2613752477ul);

    /// <summary>
    /// <para>Popups the <see cref="Godot.Window"/> centered inside its parent <see cref="Godot.Window"/>. <paramref name="fallbackRatio"/> determines the maximum size of the <see cref="Godot.Window"/>, in relation to its parent.</para>
    /// <para><b>Note:</b> Calling it with the default value of <paramref name="minsize"/> is equivalent to calling it with <see cref="Godot.Window.Size"/>.</para>
    /// </summary>
    /// <param name="minsize">If the parameter is null, then the default value is <c>new Vector2I(0, 0)</c>.</param>
    public unsafe void PopupCenteredClamped(Nullable<Vector2I> minsize = null, float fallbackRatio = 0.75f)
    {
        Vector2I minsizeOrDefVal = minsize.HasValue ? minsize.Value : new Vector2I(0, 0);
        NativeCalls.godot_icall_2_43(MethodBind122, GodotObject.GetPtr(this), &minsizeOrDefVal, fallbackRatio);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind123 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PopupExclusive, 2134721627ul);

    /// <summary>
    /// <para>Attempts to parent this dialog to the last exclusive window relative to <paramref name="fromNode"/>, and then calls <see cref="Godot.Window.Popup(Nullable{Rect2I})"/> on it. The dialog must have no current parent, otherwise the method fails.</para>
    /// <para>See also <see cref="Godot.Window.SetUnparentWhenInvisible(bool)"/> and <see cref="Godot.Node.GetLastExclusiveWindow()"/>.</para>
    /// </summary>
    /// <param name="rect">If the parameter is null, then the default value is <c>new Rect2I(new Vector2I(0, 0), new Vector2I(0, 0))</c>.</param>
    public unsafe void PopupExclusive(Node fromNode, Nullable<Rect2I> rect = null)
    {
        Rect2I rectOrDefVal = rect.HasValue ? rect.Value : new Rect2I(new Vector2I(0, 0), new Vector2I(0, 0));
        NativeCalls.godot_icall_2_498(MethodBind123, GodotObject.GetPtr(this), GodotObject.GetPtr(fromNode), &rectOrDefVal);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind124 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PopupExclusiveOnParent, 2344671043ul);

    /// <summary>
    /// <para>Attempts to parent this dialog to the last exclusive window relative to <paramref name="fromNode"/>, and then calls <see cref="Godot.Window.PopupOnParent(Rect2I)"/> on it. The dialog must have no current parent, otherwise the method fails.</para>
    /// <para>See also <see cref="Godot.Window.SetUnparentWhenInvisible(bool)"/> and <see cref="Godot.Node.GetLastExclusiveWindow()"/>.</para>
    /// </summary>
    public unsafe void PopupExclusiveOnParent(Node fromNode, Rect2I parentRect)
    {
        NativeCalls.godot_icall_2_498(MethodBind124, GodotObject.GetPtr(this), GodotObject.GetPtr(fromNode), &parentRect);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind125 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PopupExclusiveCentered, 3357594017ul);

    /// <summary>
    /// <para>Attempts to parent this dialog to the last exclusive window relative to <paramref name="fromNode"/>, and then calls <see cref="Godot.Window.PopupCentered(Nullable{Vector2I})"/> on it. The dialog must have no current parent, otherwise the method fails.</para>
    /// <para>See also <see cref="Godot.Window.SetUnparentWhenInvisible(bool)"/> and <see cref="Godot.Node.GetLastExclusiveWindow()"/>.</para>
    /// </summary>
    /// <param name="minsize">If the parameter is null, then the default value is <c>new Vector2I(0, 0)</c>.</param>
    public unsafe void PopupExclusiveCentered(Node fromNode, Nullable<Vector2I> minsize = null)
    {
        Vector2I minsizeOrDefVal = minsize.HasValue ? minsize.Value : new Vector2I(0, 0);
        NativeCalls.godot_icall_2_499(MethodBind125, GodotObject.GetPtr(this), GodotObject.GetPtr(fromNode), &minsizeOrDefVal);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind126 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PopupExclusiveCenteredRatio, 2284776287ul);

    /// <summary>
    /// <para>Attempts to parent this dialog to the last exclusive window relative to <paramref name="fromNode"/>, and then calls <see cref="Godot.Window.PopupCenteredRatio(float)"/> on it. The dialog must have no current parent, otherwise the method fails.</para>
    /// <para>See also <see cref="Godot.Window.SetUnparentWhenInvisible(bool)"/> and <see cref="Godot.Node.GetLastExclusiveWindow()"/>.</para>
    /// </summary>
    public void PopupExclusiveCenteredRatio(Node fromNode, float ratio = 0.8f)
    {
        NativeCalls.godot_icall_2_215(MethodBind126, GodotObject.GetPtr(this), GodotObject.GetPtr(fromNode), ratio);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind127 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PopupExclusiveCenteredClamped, 2612708785ul);

    /// <summary>
    /// <para>Attempts to parent this dialog to the last exclusive window relative to <paramref name="fromNode"/>, and then calls <see cref="Godot.Window.PopupCenteredClamped(Nullable{Vector2I}, float)"/> on it. The dialog must have no current parent, otherwise the method fails.</para>
    /// <para>See also <see cref="Godot.Window.SetUnparentWhenInvisible(bool)"/> and <see cref="Godot.Node.GetLastExclusiveWindow()"/>.</para>
    /// </summary>
    /// <param name="minsize">If the parameter is null, then the default value is <c>new Vector2I(0, 0)</c>.</param>
    public unsafe void PopupExclusiveCenteredClamped(Node fromNode, Nullable<Vector2I> minsize = null, float fallbackRatio = 0.75f)
    {
        Vector2I minsizeOrDefVal = minsize.HasValue ? minsize.Value : new Vector2I(0, 0);
        NativeCalls.godot_icall_3_500(MethodBind127, GodotObject.GetPtr(this), GodotObject.GetPtr(fromNode), &minsizeOrDefVal, fallbackRatio);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.Window.WindowInput"/> event of a <see cref="Godot.Window"/> class.
    /// </summary>
    public delegate void WindowInputEventHandler(InputEvent @event);

    private static void WindowInputTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((WindowInputEventHandler)delegateObj)(VariantUtils.ConvertTo<InputEvent>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when the <see cref="Godot.Window"/> is currently focused and receives any input, passing the received event as an argument. The event's position, if present, is in the embedder's coordinate system.</para>
    /// </summary>
    public unsafe event WindowInputEventHandler WindowInput
    {
        add => Connect(SignalName.WindowInput, Callable.CreateWithUnsafeTrampoline(value, &WindowInputTrampoline));
        remove => Disconnect(SignalName.WindowInput, Callable.CreateWithUnsafeTrampoline(value, &WindowInputTrampoline));
    }

    protected void EmitSignalWindowInput(InputEvent @event)
    {
        EmitSignal(SignalName.WindowInput, @event);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.Window.NonclientWindowInput"/> event of a <see cref="Godot.Window"/> class.
    /// </summary>
    public delegate void NonclientWindowInputEventHandler(InputEvent @event);

    private static void NonclientWindowInputTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((NonclientWindowInputEventHandler)delegateObj)(VariantUtils.ConvertTo<InputEvent>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when the mouse event is received by the custom decoration area defined by <see cref="Godot.Window.NonclientArea"/>, and normal input to the window is blocked (such as when it has an exclusive child opened). <c>event</c>'s position is in the embedder's coordinate system.</para>
    /// </summary>
    public unsafe event NonclientWindowInputEventHandler NonclientWindowInput
    {
        add => Connect(SignalName.NonclientWindowInput, Callable.CreateWithUnsafeTrampoline(value, &NonclientWindowInputTrampoline));
        remove => Disconnect(SignalName.NonclientWindowInput, Callable.CreateWithUnsafeTrampoline(value, &NonclientWindowInputTrampoline));
    }

    protected void EmitSignalNonclientWindowInput(InputEvent @event)
    {
        EmitSignal(SignalName.NonclientWindowInput, @event);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.Window.FilesDropped"/> event of a <see cref="Godot.Window"/> class.
    /// </summary>
    public delegate void FilesDroppedEventHandler(string[] files);

    private static void FilesDroppedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((FilesDroppedEventHandler)delegateObj)(VariantUtils.ConvertTo<string[]>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when files are dragged from the OS file manager and dropped in the game window. The argument is a list of file paths.</para>
    /// <para><code>
    /// func _ready():
    /// 	get_window().files_dropped.connect(on_files_dropped)
    /// 
    /// func on_files_dropped(files):
    /// 	print(files)
    /// </code></para>
    /// <para><b>Note:</b> This signal only works with native windows, i.e. the main window and <see cref="Godot.Window"/>-derived nodes when <see cref="Godot.Viewport.GuiEmbedSubwindows"/> is disabled in the main viewport.</para>
    /// </summary>
    public unsafe event FilesDroppedEventHandler FilesDropped
    {
        add => Connect(SignalName.FilesDropped, Callable.CreateWithUnsafeTrampoline(value, &FilesDroppedTrampoline));
        remove => Disconnect(SignalName.FilesDropped, Callable.CreateWithUnsafeTrampoline(value, &FilesDroppedTrampoline));
    }

    protected void EmitSignalFilesDropped(string[] files)
    {
        EmitSignal(SignalName.FilesDropped, files);
    }

    /// <summary>
    /// <para>Emitted when the mouse cursor enters the <see cref="Godot.Window"/>'s visible area, that is not occluded behind other <see cref="Godot.Control"/>s or windows, provided its <see cref="Godot.Viewport.GuiDisableInput"/> is <see langword="false"/> and regardless if it's currently focused or not.</para>
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
    /// <para>Emitted when the mouse cursor leaves the <see cref="Godot.Window"/>'s visible area, that is not occluded behind other <see cref="Godot.Control"/>s or windows, provided its <see cref="Godot.Viewport.GuiDisableInput"/> is <see langword="false"/> and regardless if it's currently focused or not.</para>
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
    /// <para>Emitted when the <see cref="Godot.Window"/> gains focus.</para>
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
    /// <para>Emitted when the <see cref="Godot.Window"/> loses its focus.</para>
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
    /// <para>Emitted when the <see cref="Godot.Window"/>'s close button is pressed or when <see cref="Godot.Window.PopupWindow"/> is enabled and user clicks outside the window.</para>
    /// <para>This signal can be used to handle window closing, e.g. by connecting it to <see cref="Godot.Window.Hide()"/>.</para>
    /// </summary>
    public event Action CloseRequested
    {
        add => Connect(SignalName.CloseRequested, Callable.From(value));
        remove => Disconnect(SignalName.CloseRequested, Callable.From(value));
    }

    protected void EmitSignalCloseRequested()
    {
        EmitSignal(SignalName.CloseRequested);
    }

    /// <summary>
    /// <para>Emitted when a go back request is sent (e.g. pressing the "Back" button on Android), right after <see cref="Godot.Node.NotificationWMGoBackRequest"/>.</para>
    /// </summary>
    public event Action GoBackRequested
    {
        add => Connect(SignalName.GoBackRequested, Callable.From(value));
        remove => Disconnect(SignalName.GoBackRequested, Callable.From(value));
    }

    protected void EmitSignalGoBackRequested()
    {
        EmitSignal(SignalName.GoBackRequested);
    }

    /// <summary>
    /// <para>Emitted when <see cref="Godot.Window"/> is made visible or disappears.</para>
    /// </summary>
    public event Action VisibilityChanged
    {
        add => Connect(SignalName.VisibilityChanged, Callable.From(value));
        remove => Disconnect(SignalName.VisibilityChanged, Callable.From(value));
    }

    protected void EmitSignalVisibilityChanged()
    {
        EmitSignal(SignalName.VisibilityChanged);
    }

    /// <summary>
    /// <para>Emitted right after <see cref="Godot.Window.Popup(Nullable{Rect2I})"/> call, before the <see cref="Godot.Window"/> appears or does anything.</para>
    /// </summary>
    public event Action AboutToPopup
    {
        add => Connect(SignalName.AboutToPopup, Callable.From(value));
        remove => Disconnect(SignalName.AboutToPopup, Callable.From(value));
    }

    protected void EmitSignalAboutToPopup()
    {
        EmitSignal(SignalName.AboutToPopup);
    }

    /// <summary>
    /// <para>Emitted when the <see cref="Godot.Window.NotificationThemeChanged"/> notification is sent.</para>
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

    /// <summary>
    /// <para>Emitted when the <see cref="Godot.Window"/>'s DPI changes as a result of OS-level changes (e.g. moving the window from a Retina display to a lower resolution one).</para>
    /// <para><b>Note:</b> Only implemented on macOS and Linux (Wayland).</para>
    /// </summary>
    public event Action DpiChanged
    {
        add => Connect(SignalName.DpiChanged, Callable.From(value));
        remove => Disconnect(SignalName.DpiChanged, Callable.From(value));
    }

    protected void EmitSignalDpiChanged()
    {
        EmitSignal(SignalName.DpiChanged);
    }

    /// <summary>
    /// <para>Emitted when window title bar decorations are changed, e.g. macOS window enter/exit full screen mode, or extend-to-title flag is changed.</para>
    /// </summary>
    public event Action TitlebarChanged
    {
        add => Connect(SignalName.TitlebarChanged, Callable.From(value));
        remove => Disconnect(SignalName.TitlebarChanged, Callable.From(value));
    }

    protected void EmitSignalTitlebarChanged()
    {
        EmitSignal(SignalName.TitlebarChanged);
    }

    /// <summary>
    /// <para>Emitted when window title bar text is changed.</para>
    /// </summary>
    public event Action TitleChanged
    {
        add => Connect(SignalName.TitleChanged, Callable.From(value));
        remove => Disconnect(SignalName.TitleChanged, Callable.From(value));
    }

    protected void EmitSignalTitleChanged()
    {
        EmitSignal(SignalName.TitleChanged);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_contents_minimum_size = "_GetContentsMinimumSize";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_window_input = "WindowInput";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_nonclient_window_input = "NonclientWindowInput";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_files_dropped = "FilesDropped";

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
    private static readonly StringName SignalProxyName_close_requested = "CloseRequested";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_go_back_requested = "GoBackRequested";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_visibility_changed = "VisibilityChanged";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_about_to_popup = "AboutToPopup";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_theme_changed = "ThemeChanged";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_dpi_changed = "DpiChanged";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_titlebar_changed = "TitlebarChanged";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_title_changed = "TitleChanged";

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
        if ((method == MethodProxyName__get_contents_minimum_size || method == MethodName._GetContentsMinimumSize) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_contents_minimum_size.NativeValue))
        {
            var callRet = _GetContentsMinimumSize();
            ret = VariantUtils.CreateFrom<Vector2>(callRet);
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
        if (method == MethodName._GetContentsMinimumSize)
        {
            if (HasGodotClassMethod(MethodProxyName__get_contents_minimum_size.NativeValue.DangerousSelfRef))
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
        if (signal == SignalName.WindowInput)
        {
            if (HasGodotClassSignal(SignalProxyName_window_input.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.NonclientWindowInput)
        {
            if (HasGodotClassSignal(SignalProxyName_nonclient_window_input.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.FilesDropped)
        {
            if (HasGodotClassSignal(SignalProxyName_files_dropped.NativeValue.DangerousSelfRef))
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
        if (signal == SignalName.CloseRequested)
        {
            if (HasGodotClassSignal(SignalProxyName_close_requested.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.GoBackRequested)
        {
            if (HasGodotClassSignal(SignalProxyName_go_back_requested.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.VisibilityChanged)
        {
            if (HasGodotClassSignal(SignalProxyName_visibility_changed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.AboutToPopup)
        {
            if (HasGodotClassSignal(SignalProxyName_about_to_popup.NativeValue.DangerousSelfRef))
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
        if (signal == SignalName.DpiChanged)
        {
            if (HasGodotClassSignal(SignalProxyName_dpi_changed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.TitlebarChanged)
        {
            if (HasGodotClassSignal(SignalProxyName_titlebar_changed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.TitleChanged)
        {
            if (HasGodotClassSignal(SignalProxyName_title_changed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        return base.HasGodotClassSignal(signal);
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : Viewport.PropertyName
    {
        /// <summary>
        /// Cached name for the 'mode' property.
        /// </summary>
        public static readonly StringName Mode = "mode";
        /// <summary>
        /// Cached name for the 'title' property.
        /// </summary>
        public static readonly StringName Title = "title";
        /// <summary>
        /// Cached name for the 'initial_position' property.
        /// </summary>
        public static readonly StringName InitialPosition = "initial_position";
        /// <summary>
        /// Cached name for the 'position' property.
        /// </summary>
        public static readonly StringName Position = "position";
        /// <summary>
        /// Cached name for the 'size' property.
        /// </summary>
        public static readonly StringName Size = "size";
        /// <summary>
        /// Cached name for the 'current_screen' property.
        /// </summary>
        public static readonly StringName CurrentScreen = "current_screen";
        /// <summary>
        /// Cached name for the 'nonclient_area' property.
        /// </summary>
        public static readonly StringName NonclientArea = "nonclient_area";
        /// <summary>
        /// Cached name for the 'mouse_passthrough_polygon' property.
        /// </summary>
        public static readonly StringName MousePassthroughPolygon = "mouse_passthrough_polygon";
        /// <summary>
        /// Cached name for the 'visible' property.
        /// </summary>
        public static readonly StringName Visible = "visible";
        /// <summary>
        /// Cached name for the 'wrap_controls' property.
        /// </summary>
        public static readonly StringName WrapControls = "wrap_controls";
        /// <summary>
        /// Cached name for the 'transient' property.
        /// </summary>
        public static readonly StringName Transient = "transient";
        /// <summary>
        /// Cached name for the 'transient_to_focused' property.
        /// </summary>
        public static readonly StringName TransientToFocused = "transient_to_focused";
        /// <summary>
        /// Cached name for the 'exclusive' property.
        /// </summary>
        public static readonly StringName Exclusive = "exclusive";
        /// <summary>
        /// Cached name for the 'unresizable' property.
        /// </summary>
        public static readonly StringName Unresizable = "unresizable";
        /// <summary>
        /// Cached name for the 'borderless' property.
        /// </summary>
        public static readonly StringName Borderless = "borderless";
        /// <summary>
        /// Cached name for the 'always_on_top' property.
        /// </summary>
        public static readonly StringName AlwaysOnTop = "always_on_top";
        /// <summary>
        /// Cached name for the 'transparent' property.
        /// </summary>
        public static readonly StringName Transparent = "transparent";
        /// <summary>
        /// Cached name for the 'unfocusable' property.
        /// </summary>
        public static readonly StringName Unfocusable = "unfocusable";
        /// <summary>
        /// Cached name for the 'popup_window' property.
        /// </summary>
        public static readonly StringName PopupWindow = "popup_window";
        /// <summary>
        /// Cached name for the 'extend_to_title' property.
        /// </summary>
        public static readonly StringName ExtendToTitle = "extend_to_title";
        /// <summary>
        /// Cached name for the 'mouse_passthrough' property.
        /// </summary>
        public static readonly StringName MousePassthrough = "mouse_passthrough";
        /// <summary>
        /// Cached name for the 'sharp_corners' property.
        /// </summary>
        public static readonly StringName SharpCorners = "sharp_corners";
        /// <summary>
        /// Cached name for the 'exclude_from_capture' property.
        /// </summary>
        public static readonly StringName ExcludeFromCapture = "exclude_from_capture";
        /// <summary>
        /// Cached name for the 'popup_wm_hint' property.
        /// </summary>
        public static readonly StringName PopupWMHint = "popup_wm_hint";
        /// <summary>
        /// Cached name for the 'minimize_disabled' property.
        /// </summary>
        public static readonly StringName MinimizeDisabled = "minimize_disabled";
        /// <summary>
        /// Cached name for the 'maximize_disabled' property.
        /// </summary>
        public static readonly StringName MaximizeDisabled = "maximize_disabled";
        /// <summary>
        /// Cached name for the 'force_native' property.
        /// </summary>
        public static readonly StringName ForceNative = "force_native";
        /// <summary>
        /// Cached name for the 'min_size' property.
        /// </summary>
        public static readonly StringName MinSize = "min_size";
        /// <summary>
        /// Cached name for the 'max_size' property.
        /// </summary>
        public static readonly StringName MaxSize = "max_size";
        /// <summary>
        /// Cached name for the 'keep_title_visible' property.
        /// </summary>
        public static readonly StringName KeepTitleVisible = "keep_title_visible";
        /// <summary>
        /// Cached name for the 'content_scale_size' property.
        /// </summary>
        public static readonly StringName ContentScaleSize = "content_scale_size";
        /// <summary>
        /// Cached name for the 'content_scale_mode' property.
        /// </summary>
        public static readonly StringName ContentScaleMode = "content_scale_mode";
        /// <summary>
        /// Cached name for the 'content_scale_aspect' property.
        /// </summary>
        public static readonly StringName ContentScaleAspect = "content_scale_aspect";
        /// <summary>
        /// Cached name for the 'content_scale_stretch' property.
        /// </summary>
        public static readonly StringName ContentScaleStretch = "content_scale_stretch";
        /// <summary>
        /// Cached name for the 'content_scale_factor' property.
        /// </summary>
        public static readonly StringName ContentScaleFactor = "content_scale_factor";
        /// <summary>
        /// Cached name for the 'auto_translate' property.
        /// </summary>
        public static readonly StringName AutoTranslate = "auto_translate";
        /// <summary>
        /// Cached name for the 'accessibility_name' property.
        /// </summary>
        public static readonly StringName AccessibilityName = "accessibility_name";
        /// <summary>
        /// Cached name for the 'accessibility_description' property.
        /// </summary>
        public static readonly StringName AccessibilityDescription = "accessibility_description";
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
    public new class MethodName : Viewport.MethodName
    {
        /// <summary>
        /// Cached name for the '_get_contents_minimum_size' method.
        /// </summary>
        public static readonly StringName _GetContentsMinimumSize = "_get_contents_minimum_size";
        /// <summary>
        /// Cached name for the 'set_title' method.
        /// </summary>
        public static readonly StringName SetTitle = "set_title";
        /// <summary>
        /// Cached name for the 'get_title' method.
        /// </summary>
        public static readonly StringName GetTitle = "get_title";
        /// <summary>
        /// Cached name for the 'set_initial_position' method.
        /// </summary>
        public static readonly StringName SetInitialPosition = "set_initial_position";
        /// <summary>
        /// Cached name for the 'get_initial_position' method.
        /// </summary>
        public static readonly StringName GetInitialPosition = "get_initial_position";
        /// <summary>
        /// Cached name for the 'set_current_screen' method.
        /// </summary>
        public static readonly StringName SetCurrentScreen = "set_current_screen";
        /// <summary>
        /// Cached name for the 'get_current_screen' method.
        /// </summary>
        public static readonly StringName GetCurrentScreen = "get_current_screen";
        /// <summary>
        /// Cached name for the 'set_position' method.
        /// </summary>
        public static readonly StringName SetPosition = "set_position";
        /// <summary>
        /// Cached name for the 'get_position' method.
        /// </summary>
        public static readonly StringName GetPosition = "get_position";
        /// <summary>
        /// Cached name for the 'move_to_center' method.
        /// </summary>
        public static readonly StringName MoveToCenter = "move_to_center";
        /// <summary>
        /// Cached name for the 'set_size' method.
        /// </summary>
        public static readonly StringName SetSize = "set_size";
        /// <summary>
        /// Cached name for the 'get_size' method.
        /// </summary>
        public static readonly StringName GetSize = "get_size";
        /// <summary>
        /// Cached name for the 'reset_size' method.
        /// </summary>
        public static readonly StringName ResetSize = "reset_size";
        /// <summary>
        /// Cached name for the 'get_position_with_decorations' method.
        /// </summary>
        public static readonly StringName GetPositionWithDecorations = "get_position_with_decorations";
        /// <summary>
        /// Cached name for the 'get_size_with_decorations' method.
        /// </summary>
        public static readonly StringName GetSizeWithDecorations = "get_size_with_decorations";
        /// <summary>
        /// Cached name for the 'set_max_size' method.
        /// </summary>
        public static readonly StringName SetMaxSize = "set_max_size";
        /// <summary>
        /// Cached name for the 'get_max_size' method.
        /// </summary>
        public static readonly StringName GetMaxSize = "get_max_size";
        /// <summary>
        /// Cached name for the 'set_min_size' method.
        /// </summary>
        public static readonly StringName SetMinSize = "set_min_size";
        /// <summary>
        /// Cached name for the 'get_min_size' method.
        /// </summary>
        public static readonly StringName GetMinSize = "get_min_size";
        /// <summary>
        /// Cached name for the 'set_mode' method.
        /// </summary>
        public static readonly StringName SetMode = "set_mode";
        /// <summary>
        /// Cached name for the 'get_mode' method.
        /// </summary>
        public static readonly StringName GetMode = "get_mode";
        /// <summary>
        /// Cached name for the 'set_flag' method.
        /// </summary>
        public static readonly StringName SetFlag = "set_flag";
        /// <summary>
        /// Cached name for the 'get_flag' method.
        /// </summary>
        public static readonly StringName GetFlag = "get_flag";
        /// <summary>
        /// Cached name for the 'is_maximize_allowed' method.
        /// </summary>
        public static readonly StringName IsMaximizeAllowed = "is_maximize_allowed";
        /// <summary>
        /// Cached name for the 'request_attention' method.
        /// </summary>
        public static readonly StringName RequestAttention = "request_attention";
        /// <summary>
        /// Cached name for the 'move_to_foreground' method.
        /// </summary>
        public static readonly StringName MoveToForeground = "move_to_foreground";
        /// <summary>
        /// Cached name for the 'set_visible' method.
        /// </summary>
        public static readonly StringName SetVisible = "set_visible";
        /// <summary>
        /// Cached name for the 'is_visible' method.
        /// </summary>
        public static readonly StringName IsVisible = "is_visible";
        /// <summary>
        /// Cached name for the 'hide' method.
        /// </summary>
        public static readonly StringName Hide = "hide";
        /// <summary>
        /// Cached name for the 'show' method.
        /// </summary>
        public static readonly StringName Show = "show";
        /// <summary>
        /// Cached name for the 'set_transient' method.
        /// </summary>
        public static readonly StringName SetTransient = "set_transient";
        /// <summary>
        /// Cached name for the 'is_transient' method.
        /// </summary>
        public static readonly StringName IsTransient = "is_transient";
        /// <summary>
        /// Cached name for the 'set_transient_to_focused' method.
        /// </summary>
        public static readonly StringName SetTransientToFocused = "set_transient_to_focused";
        /// <summary>
        /// Cached name for the 'is_transient_to_focused' method.
        /// </summary>
        public static readonly StringName IsTransientToFocused = "is_transient_to_focused";
        /// <summary>
        /// Cached name for the 'set_exclusive' method.
        /// </summary>
        public static readonly StringName SetExclusive = "set_exclusive";
        /// <summary>
        /// Cached name for the 'is_exclusive' method.
        /// </summary>
        public static readonly StringName IsExclusive = "is_exclusive";
        /// <summary>
        /// Cached name for the 'set_unparent_when_invisible' method.
        /// </summary>
        public static readonly StringName SetUnparentWhenInvisible = "set_unparent_when_invisible";
        /// <summary>
        /// Cached name for the 'can_draw' method.
        /// </summary>
        public static readonly StringName CanDraw = "can_draw";
        /// <summary>
        /// Cached name for the 'has_focus' method.
        /// </summary>
        public static readonly StringName HasFocus = "has_focus";
        /// <summary>
        /// Cached name for the 'grab_focus' method.
        /// </summary>
        public static readonly StringName GrabFocus = "grab_focus";
        /// <summary>
        /// Cached name for the 'start_drag' method.
        /// </summary>
        public static readonly StringName StartDrag = "start_drag";
        /// <summary>
        /// Cached name for the 'start_resize' method.
        /// </summary>
        public static readonly StringName StartResize = "start_resize";
        /// <summary>
        /// Cached name for the 'set_ime_active' method.
        /// </summary>
        public static readonly StringName SetImeActive = "set_ime_active";
        /// <summary>
        /// Cached name for the 'set_ime_position' method.
        /// </summary>
        public static readonly StringName SetImePosition = "set_ime_position";
        /// <summary>
        /// Cached name for the 'is_embedded' method.
        /// </summary>
        public static readonly StringName IsEmbedded = "is_embedded";
        /// <summary>
        /// Cached name for the 'get_contents_minimum_size' method.
        /// </summary>
        public static readonly StringName GetContentsMinimumSize = "get_contents_minimum_size";
        /// <summary>
        /// Cached name for the 'set_force_native' method.
        /// </summary>
        public static readonly StringName SetForceNative = "set_force_native";
        /// <summary>
        /// Cached name for the 'get_force_native' method.
        /// </summary>
        public static readonly StringName GetForceNative = "get_force_native";
        /// <summary>
        /// Cached name for the 'set_content_scale_size' method.
        /// </summary>
        public static readonly StringName SetContentScaleSize = "set_content_scale_size";
        /// <summary>
        /// Cached name for the 'get_content_scale_size' method.
        /// </summary>
        public static readonly StringName GetContentScaleSize = "get_content_scale_size";
        /// <summary>
        /// Cached name for the 'set_content_scale_mode' method.
        /// </summary>
        public static readonly StringName SetContentScaleMode = "set_content_scale_mode";
        /// <summary>
        /// Cached name for the 'get_content_scale_mode' method.
        /// </summary>
        public static readonly StringName GetContentScaleMode = "get_content_scale_mode";
        /// <summary>
        /// Cached name for the 'set_content_scale_aspect' method.
        /// </summary>
        public static readonly StringName SetContentScaleAspect = "set_content_scale_aspect";
        /// <summary>
        /// Cached name for the 'get_content_scale_aspect' method.
        /// </summary>
        public static readonly StringName GetContentScaleAspect = "get_content_scale_aspect";
        /// <summary>
        /// Cached name for the 'set_content_scale_stretch' method.
        /// </summary>
        public static readonly StringName SetContentScaleStretch = "set_content_scale_stretch";
        /// <summary>
        /// Cached name for the 'get_content_scale_stretch' method.
        /// </summary>
        public static readonly StringName GetContentScaleStretch = "get_content_scale_stretch";
        /// <summary>
        /// Cached name for the 'set_nonclient_area' method.
        /// </summary>
        public static readonly StringName SetNonclientArea = "set_nonclient_area";
        /// <summary>
        /// Cached name for the 'get_nonclient_area' method.
        /// </summary>
        public static readonly StringName GetNonclientArea = "get_nonclient_area";
        /// <summary>
        /// Cached name for the 'set_keep_title_visible' method.
        /// </summary>
        public static readonly StringName SetKeepTitleVisible = "set_keep_title_visible";
        /// <summary>
        /// Cached name for the 'get_keep_title_visible' method.
        /// </summary>
        public static readonly StringName GetKeepTitleVisible = "get_keep_title_visible";
        /// <summary>
        /// Cached name for the 'set_content_scale_factor' method.
        /// </summary>
        public static readonly StringName SetContentScaleFactor = "set_content_scale_factor";
        /// <summary>
        /// Cached name for the 'get_content_scale_factor' method.
        /// </summary>
        public static readonly StringName GetContentScaleFactor = "get_content_scale_factor";
        /// <summary>
        /// Cached name for the 'set_mouse_passthrough_polygon' method.
        /// </summary>
        public static readonly StringName SetMousePassthroughPolygon = "set_mouse_passthrough_polygon";
        /// <summary>
        /// Cached name for the 'get_mouse_passthrough_polygon' method.
        /// </summary>
        public static readonly StringName GetMousePassthroughPolygon = "get_mouse_passthrough_polygon";
        /// <summary>
        /// Cached name for the 'set_wrap_controls' method.
        /// </summary>
        public static readonly StringName SetWrapControls = "set_wrap_controls";
        /// <summary>
        /// Cached name for the 'is_wrapping_controls' method.
        /// </summary>
        public static readonly StringName IsWrappingControls = "is_wrapping_controls";
        /// <summary>
        /// Cached name for the 'child_controls_changed' method.
        /// </summary>
        public static readonly StringName ChildControlsChanged = "child_controls_changed";
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
        /// Cached name for the 'get_window_id' method.
        /// </summary>
        public static readonly StringName GetWindowId = "get_window_id";
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
        /// Cached name for the 'get_focused_window' method.
        /// </summary>
        public static readonly StringName GetFocusedWindow = "get_focused_window";
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
        /// Cached name for the 'set_use_font_oversampling' method.
        /// </summary>
        public static readonly StringName SetUseFontOversampling = "set_use_font_oversampling";
        /// <summary>
        /// Cached name for the 'is_using_font_oversampling' method.
        /// </summary>
        public static readonly StringName IsUsingFontOversampling = "is_using_font_oversampling";
        /// <summary>
        /// Cached name for the 'popup' method.
        /// </summary>
        public static readonly StringName Popup = "popup";
        /// <summary>
        /// Cached name for the 'popup_on_parent' method.
        /// </summary>
        public static readonly StringName PopupOnParent = "popup_on_parent";
        /// <summary>
        /// Cached name for the 'popup_centered' method.
        /// </summary>
        public static readonly StringName PopupCentered = "popup_centered";
        /// <summary>
        /// Cached name for the 'popup_centered_ratio' method.
        /// </summary>
        public static readonly StringName PopupCenteredRatio = "popup_centered_ratio";
        /// <summary>
        /// Cached name for the 'popup_centered_clamped' method.
        /// </summary>
        public static readonly StringName PopupCenteredClamped = "popup_centered_clamped";
        /// <summary>
        /// Cached name for the 'popup_exclusive' method.
        /// </summary>
        public static readonly StringName PopupExclusive = "popup_exclusive";
        /// <summary>
        /// Cached name for the 'popup_exclusive_on_parent' method.
        /// </summary>
        public static readonly StringName PopupExclusiveOnParent = "popup_exclusive_on_parent";
        /// <summary>
        /// Cached name for the 'popup_exclusive_centered' method.
        /// </summary>
        public static readonly StringName PopupExclusiveCentered = "popup_exclusive_centered";
        /// <summary>
        /// Cached name for the 'popup_exclusive_centered_ratio' method.
        /// </summary>
        public static readonly StringName PopupExclusiveCenteredRatio = "popup_exclusive_centered_ratio";
        /// <summary>
        /// Cached name for the 'popup_exclusive_centered_clamped' method.
        /// </summary>
        public static readonly StringName PopupExclusiveCenteredClamped = "popup_exclusive_centered_clamped";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Viewport.SignalName
    {
        /// <summary>
        /// Cached name for the 'window_input' signal.
        /// </summary>
        public static readonly StringName WindowInput = "window_input";
        /// <summary>
        /// Cached name for the 'nonclient_window_input' signal.
        /// </summary>
        public static readonly StringName NonclientWindowInput = "nonclient_window_input";
        /// <summary>
        /// Cached name for the 'files_dropped' signal.
        /// </summary>
        public static readonly StringName FilesDropped = "files_dropped";
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
        /// Cached name for the 'close_requested' signal.
        /// </summary>
        public static readonly StringName CloseRequested = "close_requested";
        /// <summary>
        /// Cached name for the 'go_back_requested' signal.
        /// </summary>
        public static readonly StringName GoBackRequested = "go_back_requested";
        /// <summary>
        /// Cached name for the 'visibility_changed' signal.
        /// </summary>
        public static readonly StringName VisibilityChanged = "visibility_changed";
        /// <summary>
        /// Cached name for the 'about_to_popup' signal.
        /// </summary>
        public static readonly StringName AboutToPopup = "about_to_popup";
        /// <summary>
        /// Cached name for the 'theme_changed' signal.
        /// </summary>
        public static readonly StringName ThemeChanged = "theme_changed";
        /// <summary>
        /// Cached name for the 'dpi_changed' signal.
        /// </summary>
        public static readonly StringName DpiChanged = "dpi_changed";
        /// <summary>
        /// Cached name for the 'titlebar_changed' signal.
        /// </summary>
        public static readonly StringName TitlebarChanged = "titlebar_changed";
        /// <summary>
        /// Cached name for the 'title_changed' signal.
        /// </summary>
        public static readonly StringName TitleChanged = "title_changed";
    }
}
