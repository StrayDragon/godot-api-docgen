namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para><see cref="Godot.DisplayServer"/> handles everything related to window management. It is separated from <see cref="Godot.OS"/> as a single operating system may support multiple display servers.</para>
/// <para><b>Headless mode:</b> Starting the engine with the <c>--headless</c> <a href="$DOCS_URL/tutorials/editor/command_line_tutorial.html">command line argument</a> disables all rendering and window management functions. Most functions from <see cref="Godot.DisplayServer"/> will return dummy values in this case.</para>
/// </summary>
public static partial class DisplayServer
{
    /// <summary>
    /// <para>The ID that refers to a screen that does not exist. This is returned by some <see cref="Godot.DisplayServer"/> methods if no screen matches the requested result.</para>
    /// </summary>
    public const long InvalidScreen = -1;
    /// <summary>
    /// <para>Represents the screen containing the mouse pointer.</para>
    /// <para><b>Note:</b> On Android, iOS, Web, and Linux (Wayland), this constant always represents the screen at index <c>0</c>.</para>
    /// </summary>
    public const long ScreenWithMouseFocus = -4;
    /// <summary>
    /// <para>Represents the screen containing the window with the keyboard focus.</para>
    /// <para><b>Note:</b> On Android, iOS, Web, and Linux (Wayland), this constant always represents the screen at index <c>0</c>.</para>
    /// </summary>
    public const long ScreenWithKeyboardFocus = -3;
    /// <summary>
    /// <para>Represents the primary screen.</para>
    /// <para><b>Note:</b> On Android, iOS, Web, and Linux (Wayland), this constant always represents the screen at index <c>0</c>.</para>
    /// </summary>
    public const long ScreenPrimary = -2;
    /// <summary>
    /// <para>Represents the screen where the main window is located. This is usually the default value in functions that allow specifying one of several screens.</para>
    /// <para><b>Note:</b> On Android, iOS, Web, and Linux (Wayland), this constant always represents the screen at index <c>0</c>.</para>
    /// </summary>
    public const long ScreenOfMainWindow = -1;
    /// <summary>
    /// <para>The ID of the main window spawned by the engine, which can be passed to methods expecting a <c>window_id</c>.</para>
    /// </summary>
    public const long MainWindowId = 0;
    /// <summary>
    /// <para>The ID that refers to a nonexistent window. This is returned by some <see cref="Godot.DisplayServer"/> methods if no window matches the requested result.</para>
    /// </summary>
    public const long InvalidWindowId = -1;
    /// <summary>
    /// <para>The ID that refers to a nonexistent application status indicator.</para>
    /// </summary>
    public const long InvalidIndicatorId = -1;

    public enum Feature : long
    {
        /// <summary>
        /// <para>Display server supports global menu. This allows the application to display its menu items in the operating system's top bar. <b>macOS</b></para>
        /// </summary>
        [Obsolete("Use 'NativeMenu' or 'PopupMenu' instead.")]
        GlobalMenu = 0,
        /// <summary>
        /// <para>Display server supports multiple windows that can be moved outside of the main window. <b>Windows, macOS, Linux (X11)</b></para>
        /// </summary>
        Subwindows = 1,
        /// <summary>
        /// <para>Display server supports touchscreen input. <b>Windows, Linux (X11), Android, iOS, Web</b></para>
        /// </summary>
        Touchscreen = 2,
        /// <summary>
        /// <para>Display server supports mouse input. <b>Windows, macOS, Linux (X11/Wayland), Android, Web</b></para>
        /// </summary>
        Mouse = 3,
        /// <summary>
        /// <para>Display server supports warping mouse coordinates to keep the mouse cursor constrained within an area, but looping when one of the edges is reached. <b>Windows, macOS, Linux (X11/Wayland)</b></para>
        /// </summary>
        MouseWarp = 4,
        /// <summary>
        /// <para>Display server supports setting and getting clipboard data. See also <see cref="Godot.DisplayServer.Feature.ClipboardPrimary"/>. <b>Windows, macOS, Linux (X11/Wayland), Android, iOS, Web</b></para>
        /// </summary>
        Clipboard = 5,
        /// <summary>
        /// <para>Display server supports popping up a virtual keyboard when requested to input text without a physical keyboard. <b>Android, iOS, Web</b></para>
        /// </summary>
        VirtualKeyboard = 6,
        /// <summary>
        /// <para>Display server supports setting the mouse cursor shape to be different from the default. <b>Windows, macOS, Linux (X11/Wayland), Android, Web</b></para>
        /// </summary>
        CursorShape = 7,
        /// <summary>
        /// <para>Display server supports setting the mouse cursor shape to a custom image. <b>Windows, macOS, Linux (X11/Wayland), Web</b></para>
        /// </summary>
        CustomCursorShape = 8,
        /// <summary>
        /// <para>Display server supports spawning text dialogs using the operating system's native look-and-feel. See <see cref="Godot.DisplayServer.DialogShow(string, string, string[], Callable)"/>. <b>Windows, macOS</b></para>
        /// </summary>
        NativeDialog = 9,
        /// <summary>
        /// <para>Display server supports <a href="https://en.wikipedia.org/wiki/Input_method">Input Method Editor</a>, which is commonly used for inputting Chinese/Japanese/Korean text. This is handled by the operating system, rather than by Godot. <b>Windows, macOS, Linux (X11)</b></para>
        /// </summary>
        Ime = 10,
        /// <summary>
        /// <para>Display server supports windows can use per-pixel transparency to make windows behind them partially or fully visible. <b>Windows, macOS, Linux (X11/Wayland), Android</b></para>
        /// </summary>
        WindowTransparency = 11,
        /// <summary>
        /// <para>Display server supports querying the operating system's display scale factor. This allows automatically detecting the hiDPI display <i>reliably</i>, instead of guessing based on the screen resolution and the display's reported DPI (which might be unreliable due to broken monitor EDID). <b>Windows, Linux (Wayland), macOS</b></para>
        /// </summary>
        Hidpi = 12,
        /// <summary>
        /// <para>Display server supports changing the window icon (usually displayed in the top-left corner). <b>Windows, macOS, Linux (X11/Wayland)</b></para>
        /// <para><b>Note:</b> Use on Wayland requires the compositor to implement the <a href="https://wayland.app/protocols/xdg-toplevel-icon-v1#xdg_toplevel_icon_v1">xdg_toplevel_icon_v1</a> protocol, which not all compositors do. See <a href="https://wayland.app/protocols/xdg-toplevel-icon-v1#compositor-support">xdg_toplevel_icon_v1#compositor-support</a> for more information on individual compositor support.</para>
        /// </summary>
        Icon = 13,
        /// <summary>
        /// <para>Display server supports changing the window icon (usually displayed in the top-left corner). <b>Windows, macOS</b></para>
        /// </summary>
        NativeIcon = 14,
        /// <summary>
        /// <para>Display server supports changing the screen orientation. <b>Android, iOS</b></para>
        /// </summary>
        Orientation = 15,
        /// <summary>
        /// <para>Display server supports V-Sync status can be changed from the default (which is forced to be enabled platforms not supporting this feature). <b>Windows, macOS, Linux (X11/Wayland)</b></para>
        /// </summary>
        SwapBuffers = 16,
        /// <summary>
        /// <para>Display server supports Primary clipboard can be used. This is a different clipboard from <see cref="Godot.DisplayServer.Feature.Clipboard"/>. <b>Linux (X11/Wayland)</b></para>
        /// </summary>
        ClipboardPrimary = 18,
        /// <summary>
        /// <para>Display server supports text-to-speech. See <c>tts_*</c> methods. <b>Windows, macOS, Linux (X11/Wayland), Android, iOS, Web</b></para>
        /// </summary>
        TextToSpeech = 19,
        /// <summary>
        /// <para>Display server supports expanding window content to the title. See <see cref="Godot.DisplayServer.WindowFlags.ExtendToTitle"/>. <b>macOS</b></para>
        /// </summary>
        ExtendToTitle = 20,
        /// <summary>
        /// <para>Display server supports reading screen pixels. See <see cref="Godot.DisplayServer.ScreenGetPixel(Vector2I)"/>.</para>
        /// </summary>
        ScreenCapture = 21,
        /// <summary>
        /// <para>Display server supports application status indicators.</para>
        /// </summary>
        StatusIndicator = 22,
        /// <summary>
        /// <para>Display server supports native help system search callbacks. See <see cref="Godot.DisplayServer.HelpSetSearchCallbacks(Callable, Callable)"/>.</para>
        /// </summary>
        NativeHelp = 23,
        /// <summary>
        /// <para>Display server supports spawning text input dialogs using the operating system's native look-and-feel. See <see cref="Godot.DisplayServer.DialogInputText(string, string, string, Callable)"/>. <b>Windows, macOS</b></para>
        /// </summary>
        NativeDialogInput = 24,
        /// <summary>
        /// <para>Display server supports spawning dialogs for selecting files or directories using the operating system's native look-and-feel. See <see cref="Godot.DisplayServer.FileDialogShow(string, string, string, bool, DisplayServer.FileDialogMode, string[], Callable, int)"/>. <b>Windows, macOS, Linux (X11/Wayland), Android</b></para>
        /// </summary>
        NativeDialogFile = 25,
        /// <summary>
        /// <para>The display server supports all features of <see cref="Godot.DisplayServer.Feature.NativeDialogFile"/>, with the added functionality of Options and native dialog file access to <c>res://</c> and <c>user://</c> paths. See <see cref="Godot.DisplayServer.FileDialogShow(string, string, string, bool, DisplayServer.FileDialogMode, string[], Callable, int)"/> and <see cref="Godot.DisplayServer.FileDialogWithOptionsShow(string, string, string, string, bool, DisplayServer.FileDialogMode, string[], Godot.Collections.Array{Godot.Collections.Dictionary}, Callable, int)"/>. <b>Windows, macOS, Linux (X11/Wayland)</b></para>
        /// </summary>
        NativeDialogFileExtra = 26,
        /// <summary>
        /// <para>The display server supports initiating window drag and resize operations on demand. See <see cref="Godot.DisplayServer.WindowStartDrag(int)"/> and <see cref="Godot.DisplayServer.WindowStartResize(DisplayServer.WindowResizeEdge, int)"/>.</para>
        /// </summary>
        WindowDrag = 27,
        /// <summary>
        /// <para>Display server supports <see cref="Godot.DisplayServer.WindowFlags.ExcludeFromCapture"/> window flag. <b>Windows, macOS</b></para>
        /// </summary>
        ScreenExcludeFromCapture = 28,
        /// <summary>
        /// <para>Display server supports embedding a window from another process. <b>Windows, Linux (X11), macOS</b></para>
        /// </summary>
        WindowEmbedding = 29,
        /// <summary>
        /// <para>Native file selection dialog supports MIME types as filters.</para>
        /// </summary>
        NativeDialogFileMime = 30,
        /// <summary>
        /// <para>Display server supports system emoji and symbol picker. <b>Windows, macOS</b></para>
        /// </summary>
        EmojiAndSymbolPicker = 31,
        /// <summary>
        /// <para>Display server supports native color picker. <b>Linux (X11/Wayland)</b></para>
        /// </summary>
        NativeColorPicker = 32,
        /// <summary>
        /// <para>Display server automatically fits popups according to the screen boundaries. Window nodes should not attempt to do that themselves.</para>
        /// </summary>
        SelfFittingWindows = 33,
        /// <summary>
        /// <para>Display server supports interaction with screen reader or Braille display. <b>Linux (X11/Wayland), macOS, Windows</b></para>
        /// </summary>
        AccessibilityScreenReader = 34
    }

    public enum AccessibilityRole : long
    {
        /// <summary>
        /// <para>Unknown or custom role.</para>
        /// </summary>
        Unknown = 0,
        /// <summary>
        /// <para>Default dialog button element.</para>
        /// </summary>
        DefaultButton = 1,
        /// <summary>
        /// <para>Audio player element.</para>
        /// </summary>
        Audio = 2,
        /// <summary>
        /// <para>Video player element.</para>
        /// </summary>
        Video = 3,
        /// <summary>
        /// <para>Non-editable text label.</para>
        /// </summary>
        StaticText = 4,
        /// <summary>
        /// <para>Container element. Elements with this role are used for internal structure and ignored by screen readers.</para>
        /// </summary>
        Container = 5,
        /// <summary>
        /// <para>Panel container element.</para>
        /// </summary>
        Panel = 6,
        /// <summary>
        /// <para>Button element.</para>
        /// </summary>
        Button = 7,
        /// <summary>
        /// <para>Link element.</para>
        /// </summary>
        Link = 8,
        /// <summary>
        /// <para>Check box element.</para>
        /// </summary>
        CheckBox = 9,
        /// <summary>
        /// <para>Radio button element.</para>
        /// </summary>
        RadioButton = 10,
        /// <summary>
        /// <para>Check button element.</para>
        /// </summary>
        CheckButton = 11,
        /// <summary>
        /// <para>Scroll bar element.</para>
        /// </summary>
        ScrollBar = 12,
        /// <summary>
        /// <para>Scroll container element.</para>
        /// </summary>
        ScrollView = 13,
        /// <summary>
        /// <para>Container splitter handle element.</para>
        /// </summary>
        Splitter = 14,
        /// <summary>
        /// <para>Slider element.</para>
        /// </summary>
        Slider = 15,
        /// <summary>
        /// <para>Spin box element.</para>
        /// </summary>
        SpinButton = 16,
        /// <summary>
        /// <para>Progress indicator element.</para>
        /// </summary>
        ProgressIndicator = 17,
        /// <summary>
        /// <para>Editable text field element.</para>
        /// </summary>
        TextField = 18,
        /// <summary>
        /// <para>Multiline editable text field element.</para>
        /// </summary>
        MultilineTextField = 19,
        /// <summary>
        /// <para>Color picker element.</para>
        /// </summary>
        ColorPicker = 20,
        /// <summary>
        /// <para>Table element.</para>
        /// </summary>
        Table = 21,
        /// <summary>
        /// <para>Table/tree cell element.</para>
        /// </summary>
        Cell = 22,
        /// <summary>
        /// <para>Table/tree row element.</para>
        /// </summary>
        Row = 23,
        /// <summary>
        /// <para>Table/tree row group element.</para>
        /// </summary>
        RowGroup = 24,
        /// <summary>
        /// <para>Table/tree row header element.</para>
        /// </summary>
        RowHeader = 25,
        /// <summary>
        /// <para>Table/tree column header element.</para>
        /// </summary>
        ColumnHeader = 26,
        /// <summary>
        /// <para>Tree view element.</para>
        /// </summary>
        Tree = 27,
        /// <summary>
        /// <para>Tree view item element.</para>
        /// </summary>
        TreeItem = 28,
        /// <summary>
        /// <para>List element.</para>
        /// </summary>
        List = 29,
        /// <summary>
        /// <para>List item element.</para>
        /// </summary>
        ListItem = 30,
        /// <summary>
        /// <para>List view element.</para>
        /// </summary>
        ListBox = 31,
        /// <summary>
        /// <para>List view item element.</para>
        /// </summary>
        ListBoxOption = 32,
        /// <summary>
        /// <para>Tab bar element.</para>
        /// </summary>
        TabBar = 33,
        /// <summary>
        /// <para>Tab bar item element.</para>
        /// </summary>
        Tab = 34,
        /// <summary>
        /// <para>Tab panel element.</para>
        /// </summary>
        TabPanel = 35,
        /// <summary>
        /// <para>Menu bar element.</para>
        /// </summary>
        MenuBar = 36,
        /// <summary>
        /// <para>Popup menu element.</para>
        /// </summary>
        Menu = 37,
        /// <summary>
        /// <para>Popup menu item element.</para>
        /// </summary>
        MenuItem = 38,
        /// <summary>
        /// <para>Popup menu check button item element.</para>
        /// </summary>
        MenuItemCheckBox = 39,
        /// <summary>
        /// <para>Popup menu radio button item element.</para>
        /// </summary>
        MenuItemRadio = 40,
        /// <summary>
        /// <para>Image element.</para>
        /// </summary>
        Image = 41,
        /// <summary>
        /// <para>Window element.</para>
        /// </summary>
        Window = 42,
        /// <summary>
        /// <para>Embedded window title bar element.</para>
        /// </summary>
        TitleBar = 43,
        /// <summary>
        /// <para>Dialog window element.</para>
        /// </summary>
        Dialog = 44,
        /// <summary>
        /// <para>Tooltip element.</para>
        /// </summary>
        Tooltip = 45
    }

    public enum AccessibilityPopupType : long
    {
        /// <summary>
        /// <para>Popup menu.</para>
        /// </summary>
        Menu = 0,
        /// <summary>
        /// <para>Popup list.</para>
        /// </summary>
        List = 1,
        /// <summary>
        /// <para>Popup tree view.</para>
        /// </summary>
        Tree = 2,
        /// <summary>
        /// <para>Popup dialog.</para>
        /// </summary>
        Dialog = 3
    }

    public enum AccessibilityFlags : long
    {
        /// <summary>
        /// <para>Element is hidden for accessibility tools.</para>
        /// </summary>
        Hidden = 0,
        /// <summary>
        /// <para>Element supports multiple item selection.</para>
        /// </summary>
        Multiselectable = 1,
        /// <summary>
        /// <para>Element require user input.</para>
        /// </summary>
        Required = 2,
        /// <summary>
        /// <para>Element is a visited link.</para>
        /// </summary>
        Visited = 3,
        /// <summary>
        /// <para>Element content is not ready (e.g. loading).</para>
        /// </summary>
        Busy = 4,
        /// <summary>
        /// <para>Element is modal window.</para>
        /// </summary>
        Modal = 5,
        /// <summary>
        /// <para>Element allows touches to be passed through when a screen reader is in touch exploration mode.</para>
        /// </summary>
        TouchPassthrough = 6,
        /// <summary>
        /// <para>Element is text field with selectable but read-only text.</para>
        /// </summary>
        Readonly = 7,
        /// <summary>
        /// <para>Element is disabled.</para>
        /// </summary>
        Disabled = 8,
        /// <summary>
        /// <para>Element clips children.</para>
        /// </summary>
        ClipsChildren = 9
    }

    public enum AccessibilityAction : long
    {
        /// <summary>
        /// <para>Single click action, callback argument is not set.</para>
        /// </summary>
        Click = 0,
        /// <summary>
        /// <para>Focus action, callback argument is not set.</para>
        /// </summary>
        Focus = 1,
        /// <summary>
        /// <para>Blur action, callback argument is not set.</para>
        /// </summary>
        Blur = 2,
        /// <summary>
        /// <para>Collapse action, callback argument is not set.</para>
        /// </summary>
        Collapse = 3,
        /// <summary>
        /// <para>Expand action, callback argument is not set.</para>
        /// </summary>
        Expand = 4,
        /// <summary>
        /// <para>Decrement action, callback argument is not set.</para>
        /// </summary>
        Decrement = 5,
        /// <summary>
        /// <para>Increment action, callback argument is not set.</para>
        /// </summary>
        Increment = 6,
        /// <summary>
        /// <para>Hide tooltip action, callback argument is not set.</para>
        /// </summary>
        HideTooltip = 7,
        /// <summary>
        /// <para>Show tooltip action, callback argument is not set.</para>
        /// </summary>
        ShowTooltip = 8,
        /// <summary>
        /// <para>Set text selection action, callback argument is set to <see cref="Godot.Collections.Dictionary"/> with the following keys:</para>
        /// <para>- <c>"start_element"</c> accessibility element of the selection start.</para>
        /// <para>- <c>"start_char"</c> character offset relative to the accessibility element of the selection start.</para>
        /// <para>- <c>"end_element"</c> accessibility element of the selection end.</para>
        /// <para>- <c>"end_char"</c> character offset relative to the accessibility element of the selection end.</para>
        /// </summary>
        SetTextSelection = 9,
        /// <summary>
        /// <para>Replace text action, callback argument is set to <see cref="string"/> with the replacement text.</para>
        /// </summary>
        ReplaceSelectedText = 10,
        /// <summary>
        /// <para>Scroll backward action, callback argument is not set.</para>
        /// </summary>
        ScrollBackward = 11,
        /// <summary>
        /// <para>Scroll down action, callback argument is set to <see cref="Godot.DisplayServer.AccessibilityScrollUnit"/>.</para>
        /// </summary>
        ScrollDown = 12,
        /// <summary>
        /// <para>Scroll forward action, callback argument is not set.</para>
        /// </summary>
        ScrollForward = 13,
        /// <summary>
        /// <para>Scroll left action, callback argument is set to <see cref="Godot.DisplayServer.AccessibilityScrollUnit"/>.</para>
        /// </summary>
        ScrollLeft = 14,
        /// <summary>
        /// <para>Scroll right action, callback argument is set to <see cref="Godot.DisplayServer.AccessibilityScrollUnit"/>.</para>
        /// </summary>
        ScrollRight = 15,
        /// <summary>
        /// <para>Scroll up action, callback argument is set to <see cref="Godot.DisplayServer.AccessibilityScrollUnit"/>.</para>
        /// </summary>
        ScrollUp = 16,
        /// <summary>
        /// <para>Scroll into view action, callback argument is set to <see cref="Godot.DisplayServer.AccessibilityScrollHint"/>.</para>
        /// </summary>
        ScrollIntoView = 17,
        /// <summary>
        /// <para>Scroll to point action, callback argument is set to <see cref="Godot.Vector2"/> with the relative point coordinates.</para>
        /// </summary>
        ScrollToPoint = 18,
        /// <summary>
        /// <para>Set scroll offset action, callback argument is set to <see cref="Godot.Vector2"/> with the scroll offset.</para>
        /// </summary>
        SetScrollOffset = 19,
        /// <summary>
        /// <para>Set value action, callback argument is set to <see cref="string"/> or number with the new value.</para>
        /// </summary>
        SetValue = 20,
        /// <summary>
        /// <para>Show context menu action, callback argument is not set.</para>
        /// </summary>
        ShowContextMenu = 21,
        /// <summary>
        /// <para>Custom action, callback argument is set to the integer action ID.</para>
        /// </summary>
        Custom = 22
    }

    public enum AccessibilityLiveMode : long
    {
        /// <summary>
        /// <para>Indicates that updates to the live region should not be presented.</para>
        /// </summary>
        Off = 0,
        /// <summary>
        /// <para>Indicates that updates to the live region should be presented at the next opportunity (for example at the end of speaking the current sentence).</para>
        /// </summary>
        Polite = 1,
        /// <summary>
        /// <para>Indicates that updates to the live region have the highest priority and should be presented immediately.</para>
        /// </summary>
        Assertive = 2
    }

    public enum AccessibilityScrollUnit : long
    {
        /// <summary>
        /// <para>The amount by which to scroll. A single item of a list, line of text.</para>
        /// </summary>
        Item = 0,
        /// <summary>
        /// <para>The amount by which to scroll. A single page.</para>
        /// </summary>
        Page = 1
    }

    public enum AccessibilityScrollHint : long
    {
        /// <summary>
        /// <para>A preferred position for the node scrolled into view. Top-left edge of the scroll container.</para>
        /// </summary>
        TopLeft = 0,
        /// <summary>
        /// <para>A preferred position for the node scrolled into view. Bottom-right edge of the scroll container.</para>
        /// </summary>
        BottomRight = 1,
        /// <summary>
        /// <para>A preferred position for the node scrolled into view. Top edge of the scroll container.</para>
        /// </summary>
        TopEdge = 2,
        /// <summary>
        /// <para>A preferred position for the node scrolled into view. Bottom edge of the scroll container.</para>
        /// </summary>
        BottomEdge = 3,
        /// <summary>
        /// <para>A preferred position for the node scrolled into view. Left edge of the scroll container.</para>
        /// </summary>
        LeftEdge = 4,
        /// <summary>
        /// <para>A preferred position for the node scrolled into view. Right edge of the scroll container.</para>
        /// </summary>
        RightEdge = 5
    }

    public enum MouseMode : long
    {
        /// <summary>
        /// <para>Makes the mouse cursor visible if it is hidden.</para>
        /// </summary>
        Visible = 0,
        /// <summary>
        /// <para>Makes the mouse cursor hidden if it is visible.</para>
        /// </summary>
        Hidden = 1,
        /// <summary>
        /// <para>Captures the mouse. The mouse will be hidden and its position locked at the center of the window manager's window.</para>
        /// <para><b>Note:</b> If you want to process the mouse's movement in this mode, you need to use <see cref="Godot.InputEventMouseMotion.Relative"/>.</para>
        /// </summary>
        Captured = 2,
        /// <summary>
        /// <para>Confines the mouse cursor to the game window, and make it visible.</para>
        /// </summary>
        Confined = 3,
        /// <summary>
        /// <para>Confines the mouse cursor to the game window, and make it hidden.</para>
        /// </summary>
        ConfinedHidden = 4,
        /// <summary>
        /// <para>Max value of the <see cref="Godot.DisplayServer.MouseMode"/>.</para>
        /// </summary>
        Max = 5
    }

    public enum ScreenOrientation : long
    {
        /// <summary>
        /// <para>Default landscape orientation.</para>
        /// </summary>
        Landscape = 0,
        /// <summary>
        /// <para>Default portrait orientation.</para>
        /// </summary>
        Portrait = 1,
        /// <summary>
        /// <para>Reverse landscape orientation (upside down).</para>
        /// </summary>
        ReverseLandscape = 2,
        /// <summary>
        /// <para>Reverse portrait orientation (upside down).</para>
        /// </summary>
        ReversePortrait = 3,
        /// <summary>
        /// <para>Automatic landscape orientation (default or reverse depending on sensor).</para>
        /// </summary>
        SensorLandscape = 4,
        /// <summary>
        /// <para>Automatic portrait orientation (default or reverse depending on sensor).</para>
        /// </summary>
        SensorPortrait = 5,
        /// <summary>
        /// <para>Automatic landscape or portrait orientation (default or reverse depending on sensor).</para>
        /// </summary>
        Sensor = 6
    }

    public enum VirtualKeyboardType : long
    {
        /// <summary>
        /// <para>Default text virtual keyboard.</para>
        /// </summary>
        Default = 0,
        /// <summary>
        /// <para>Multiline virtual keyboard.</para>
        /// </summary>
        Multiline = 1,
        /// <summary>
        /// <para>Virtual number keypad, useful for PIN entry.</para>
        /// </summary>
        Number = 2,
        /// <summary>
        /// <para>Virtual number keypad, useful for entering fractional numbers.</para>
        /// </summary>
        NumberDecimal = 3,
        /// <summary>
        /// <para>Virtual phone number keypad.</para>
        /// </summary>
        Phone = 4,
        /// <summary>
        /// <para>Virtual keyboard with additional keys to assist with typing email addresses.</para>
        /// </summary>
        EmailAddress = 5,
        /// <summary>
        /// <para>Virtual keyboard for entering a password. On most platforms, this should disable autocomplete and autocapitalization.</para>
        /// <para><b>Note:</b> This is not supported on Web. Instead, this behaves identically to <see cref="Godot.DisplayServer.VirtualKeyboardType.Default"/>.</para>
        /// </summary>
        Password = 6,
        /// <summary>
        /// <para>Virtual keyboard with additional keys to assist with typing URLs.</para>
        /// </summary>
        Url = 7
    }

    public enum CursorShape : long
    {
        /// <summary>
        /// <para>Arrow cursor shape. This is the default when not pointing anything that overrides the mouse cursor, such as a <see cref="Godot.LineEdit"/> or <see cref="Godot.TextEdit"/>.</para>
        /// </summary>
        Arrow = 0,
        /// <summary>
        /// <para>I-beam cursor shape. This is used by default when hovering a control that accepts text input, such as <see cref="Godot.LineEdit"/> or <see cref="Godot.TextEdit"/>.</para>
        /// </summary>
        Ibeam = 1,
        /// <summary>
        /// <para>Pointing hand cursor shape. This is used by default when hovering a <see cref="Godot.LinkButton"/> or a URL tag in a <see cref="Godot.RichTextLabel"/>.</para>
        /// </summary>
        PointingHand = 2,
        /// <summary>
        /// <para>Crosshair cursor. This is intended to be displayed when the user needs precise aim over an element, such as a rectangle selection tool or a color picker.</para>
        /// </summary>
        Cross = 3,
        /// <summary>
        /// <para>Wait cursor. On most cursor themes, this displays a spinning icon <i>besides</i> the arrow. Intended to be used for non-blocking operations (when the user can do something else at the moment). See also <see cref="Godot.DisplayServer.CursorShape.Busy"/>.</para>
        /// </summary>
        Wait = 4,
        /// <summary>
        /// <para>Wait cursor. On most cursor themes, this <i>replaces</i> the arrow with a spinning icon. Intended to be used for blocking operations (when the user can't do anything else at the moment). See also <see cref="Godot.DisplayServer.CursorShape.Wait"/>.</para>
        /// </summary>
        Busy = 5,
        /// <summary>
        /// <para>Dragging hand cursor. This is displayed during drag-and-drop operations. See also <see cref="Godot.DisplayServer.CursorShape.CanDrop"/>.</para>
        /// </summary>
        Drag = 6,
        /// <summary>
        /// <para>"Can drop" cursor. This is displayed during drag-and-drop operations if hovering over a <see cref="Godot.Control"/> that can accept the drag-and-drop event. On most cursor themes, this displays a dragging hand with an arrow symbol besides it. See also <see cref="Godot.DisplayServer.CursorShape.Drag"/>.</para>
        /// </summary>
        CanDrop = 7,
        /// <summary>
        /// <para>Forbidden cursor. This is displayed during drag-and-drop operations if the hovered <see cref="Godot.Control"/> can't accept the drag-and-drop event.</para>
        /// </summary>
        Forbidden = 8,
        /// <summary>
        /// <para>Vertical resize cursor. Intended to be displayed when the hovered <see cref="Godot.Control"/> can be vertically resized using the mouse. See also <see cref="Godot.DisplayServer.CursorShape.Vsplit"/>.</para>
        /// </summary>
        Vsize = 9,
        /// <summary>
        /// <para>Horizontal resize cursor. Intended to be displayed when the hovered <see cref="Godot.Control"/> can be horizontally resized using the mouse. See also <see cref="Godot.DisplayServer.CursorShape.Hsplit"/>.</para>
        /// </summary>
        Hsize = 10,
        /// <summary>
        /// <para>Secondary diagonal resize cursor (top-right/bottom-left). Intended to be displayed when the hovered <see cref="Godot.Control"/> can be resized on both axes at once using the mouse.</para>
        /// </summary>
        Bdiagsize = 11,
        /// <summary>
        /// <para>Main diagonal resize cursor (top-left/bottom-right). Intended to be displayed when the hovered <see cref="Godot.Control"/> can be resized on both axes at once using the mouse.</para>
        /// </summary>
        Fdiagsize = 12,
        /// <summary>
        /// <para>Move cursor. Intended to be displayed when the hovered <see cref="Godot.Control"/> can be moved using the mouse.</para>
        /// </summary>
        Move = 13,
        /// <summary>
        /// <para>Vertical split cursor. This is displayed when hovering a <see cref="Godot.Control"/> with splits that can be vertically resized using the mouse, such as <see cref="Godot.VSplitContainer"/>. On some cursor themes, this cursor may have the same appearance as <see cref="Godot.DisplayServer.CursorShape.Vsize"/>.</para>
        /// </summary>
        Vsplit = 14,
        /// <summary>
        /// <para>Horizontal split cursor. This is displayed when hovering a <see cref="Godot.Control"/> with splits that can be horizontally resized using the mouse, such as <see cref="Godot.HSplitContainer"/>. On some cursor themes, this cursor may have the same appearance as <see cref="Godot.DisplayServer.CursorShape.Hsize"/>.</para>
        /// </summary>
        Hsplit = 15,
        /// <summary>
        /// <para>Help cursor. On most cursor themes, this displays a question mark icon instead of the mouse cursor. Intended to be used when the user has requested help on the next element that will be clicked.</para>
        /// </summary>
        Help = 16,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.DisplayServer.CursorShape"/> enum.</para>
        /// </summary>
        Max = 17
    }

    public enum FileDialogMode : long
    {
        /// <summary>
        /// <para>The native file dialog allows selecting one, and only one file.</para>
        /// </summary>
        OpenFile = 0,
        /// <summary>
        /// <para>The native file dialog allows selecting multiple files.</para>
        /// </summary>
        OpenFiles = 1,
        /// <summary>
        /// <para>The native file dialog only allows selecting a directory, disallowing the selection of any file.</para>
        /// </summary>
        OpenDir = 2,
        /// <summary>
        /// <para>The native file dialog allows selecting one file or directory.</para>
        /// </summary>
        OpenAny = 3,
        /// <summary>
        /// <para>The native file dialog will warn when a file exists.</para>
        /// </summary>
        SaveFile = 4
    }

    public enum WindowMode : long
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
        /// <para><b>On Linux (Wayland):</b> Equivalent to <see cref="Godot.DisplayServer.WindowMode.Fullscreen"/>.</para>
        /// <para><b>Note:</b> Regardless of the platform, enabling full screen will change the window size to match the monitor's size. Therefore, make sure your project supports <a href="$DOCS_URL/tutorials/rendering/multiple_resolutions.html">multiple resolutions</a> when enabling full screen mode.</para>
        /// </summary>
        ExclusiveFullscreen = 4
    }

    public enum WindowFlags : long
    {
        /// <summary>
        /// <para>The window can't be resized by dragging its resize grip. It's still possible to resize the window using <see cref="Godot.DisplayServer.WindowSetSize(Vector2I, int)"/>. This flag is ignored for full screen windows.</para>
        /// </summary>
        ResizeDisabled = 0,
        /// <summary>
        /// <para>The window do not have native title bar and other decorations. This flag is ignored for full-screen windows.</para>
        /// </summary>
        Borderless = 1,
        /// <summary>
        /// <para>The window is floating on top of all other windows. This flag is ignored for full-screen windows.</para>
        /// </summary>
        AlwaysOnTop = 2,
        /// <summary>
        /// <para>The window background can be transparent.</para>
        /// <para><b>Note:</b> This flag has no effect if <see cref="Godot.DisplayServer.IsWindowTransparencyAvailable()"/> returns <see langword="false"/>.</para>
        /// <para><b>Note:</b> Transparency support is implemented on Linux (X11/Wayland), macOS, and Windows, but availability might vary depending on GPU driver, display manager, and compositor capabilities.</para>
        /// <para><b>Note:</b> Transparency support is implemented on Android, but can only be enabled via <c>ProjectSettings.display/window/per_pixel_transparency/allowed</c>. This flag has no effect on Android.</para>
        /// </summary>
        Transparent = 3,
        /// <summary>
        /// <para>The window can't be focused. No-focus window will ignore all input, except mouse clicks.</para>
        /// </summary>
        NoFocus = 4,
        /// <summary>
        /// <para>Window is part of menu or <see cref="Godot.OptionButton"/> dropdown. This flag can't be changed when the window is visible. An active popup window will exclusively receive all input, without stealing focus from its parent. Popup windows are automatically closed when uses click outside it, or when an application is switched. Popup window must have transient parent set (see <see cref="Godot.DisplayServer.WindowSetTransient(int, int)"/>).</para>
        /// </summary>
        Popup = 5,
        /// <summary>
        /// <para>Window content is expanded to the full size of the window. Unlike borderless window, the frame is left intact and can be used to resize the window, title bar is transparent, but have minimize/maximize/close buttons.</para>
        /// <para>Use <see cref="Godot.DisplayServer.WindowSetWindowButtonsOffset(Vector2I, int)"/> to adjust minimize/maximize/close buttons offset.</para>
        /// <para>Use <see cref="Godot.DisplayServer.WindowGetSafeTitleMargins(int)"/> to determine area under the title bar that is not covered by decorations.</para>
        /// <para><b>Note:</b> This flag is implemented only on macOS.</para>
        /// </summary>
        ExtendToTitle = 6,
        /// <summary>
        /// <para>All mouse events are passed to the underlying window of the same application.</para>
        /// </summary>
        MousePassthrough = 7,
        /// <summary>
        /// <para>Window style is overridden, forcing sharp corners.</para>
        /// <para><b>Note:</b> This flag is implemented only on Windows (11).</para>
        /// </summary>
        SharpCorners = 8,
        /// <summary>
        /// <para>Window is excluded from screenshots taken by <see cref="Godot.DisplayServer.ScreenGetImage(int)"/>, <see cref="Godot.DisplayServer.ScreenGetImageRect(Rect2I)"/>, and <see cref="Godot.DisplayServer.ScreenGetPixel(Vector2I)"/>.</para>
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
        /// <para>Represents the size of the <see cref="Godot.DisplayServer.WindowFlags"/> enum.</para>
        /// </summary>
        Max = 13
    }

    public enum WindowEvent : long
    {
        /// <summary>
        /// <para>Sent when the mouse pointer enters the window.</para>
        /// </summary>
        MouseEnter = 0,
        /// <summary>
        /// <para>Sent when the mouse pointer exits the window.</para>
        /// </summary>
        MouseExit = 1,
        /// <summary>
        /// <para>Sent when the window grabs focus.</para>
        /// </summary>
        FocusIn = 2,
        /// <summary>
        /// <para>Sent when the window loses focus.</para>
        /// </summary>
        FocusOut = 3,
        /// <summary>
        /// <para>Sent when the user has attempted to close the window (e.g. close button is pressed).</para>
        /// </summary>
        CloseRequest = 4,
        /// <summary>
        /// <para>Sent when the device "Back" button is pressed.</para>
        /// <para><b>Note:</b> This event is implemented only on Android.</para>
        /// </summary>
        GoBackRequest = 5,
        /// <summary>
        /// <para>Sent when the window is moved to the display with different DPI, or display DPI is changed.</para>
        /// <para><b>Note:</b> This flag is implemented only on macOS and Linux (Wayland).</para>
        /// </summary>
        DpiChange = 6,
        /// <summary>
        /// <para>Sent when the window title bar decoration is changed (e.g. <see cref="Godot.DisplayServer.WindowFlags.ExtendToTitle"/> is set or window entered/exited full screen mode).</para>
        /// <para><b>Note:</b> This flag is implemented only on macOS.</para>
        /// </summary>
        TitlebarChange = 7,
        /// <summary>
        /// <para>Sent when the window has been forcibly closed by the display server. The window will immediately hide and clean any internal rendering references.</para>
        /// <para><b>Note:</b> This flag is implemented only on Linux (Wayland).</para>
        /// </summary>
        ForceClose = 8
    }

    public enum WindowResizeEdge : long
    {
        /// <summary>
        /// <para>Top-left edge of a window.</para>
        /// </summary>
        TopLeft = 0,
        /// <summary>
        /// <para>Top edge of a window.</para>
        /// </summary>
        Top = 1,
        /// <summary>
        /// <para>Top-right edge of a window.</para>
        /// </summary>
        TopRight = 2,
        /// <summary>
        /// <para>Left edge of a window.</para>
        /// </summary>
        Left = 3,
        /// <summary>
        /// <para>Right edge of a window.</para>
        /// </summary>
        Right = 4,
        /// <summary>
        /// <para>Bottom-left edge of a window.</para>
        /// </summary>
        BottomLeft = 5,
        /// <summary>
        /// <para>Bottom edge of a window.</para>
        /// </summary>
        Bottom = 6,
        /// <summary>
        /// <para>Bottom-right edge of a window.</para>
        /// </summary>
        BottomRight = 7,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.DisplayServer.WindowResizeEdge"/> enum.</para>
        /// </summary>
        Max = 8
    }

    public enum VSyncMode : long
    {
        /// <summary>
        /// <para>No vertical synchronization, which means the engine will display frames as fast as possible (tearing may be visible). Framerate is unlimited (regardless of <see cref="Godot.Engine.MaxFps"/>).</para>
        /// </summary>
        Disabled = 0,
        /// <summary>
        /// <para>Default vertical synchronization mode, the image is displayed only on vertical blanking intervals (no tearing is visible). Framerate is limited by the monitor refresh rate (regardless of <see cref="Godot.Engine.MaxFps"/>).</para>
        /// </summary>
        Enabled = 1,
        /// <summary>
        /// <para>Behaves like <see cref="Godot.DisplayServer.VSyncMode.Disabled"/> when the framerate drops below the screen's refresh rate to reduce stuttering (tearing may be visible). Otherwise, vertical synchronization is enabled to avoid tearing. Framerate is limited by the monitor refresh rate (regardless of <see cref="Godot.Engine.MaxFps"/>). Behaves like <see cref="Godot.DisplayServer.VSyncMode.Enabled"/> when using the Compatibility rendering method.</para>
        /// </summary>
        Adaptive = 2,
        /// <summary>
        /// <para>Displays the most recent image in the queue on vertical blanking intervals, while rendering to the other images (no tearing is visible). Framerate is unlimited (regardless of <see cref="Godot.Engine.MaxFps"/>).</para>
        /// <para>Although not guaranteed, the images can be rendered as fast as possible, which may reduce input lag (also called "Fast" V-Sync mode). <see cref="Godot.DisplayServer.VSyncMode.Mailbox"/> works best when at least twice as many frames as the display refresh rate are rendered. Behaves like <see cref="Godot.DisplayServer.VSyncMode.Enabled"/> when using the Compatibility rendering method.</para>
        /// </summary>
        Mailbox = 3
    }

    public enum HandleType : long
    {
        /// <summary>
        /// <para>Display handle:</para>
        /// <para>- Linux (X11): <c>X11::Display*</c> for the display.</para>
        /// <para>- Linux (Wayland): <c>wl_display</c> for the display.</para>
        /// <para>- Android: <c>EGLDisplay</c> for the display.</para>
        /// </summary>
        DisplayHandle = 0,
        /// <summary>
        /// <para>Window handle:</para>
        /// <para>- Windows: <c>HWND</c> for the window.</para>
        /// <para>- Linux (X11): <c>X11::Window*</c> for the window.</para>
        /// <para>- Linux (Wayland): <c>wl_surface</c> for the window.</para>
        /// <para>- macOS: <c>NSWindow*</c> for the window.</para>
        /// <para>- iOS: <c>UIViewController*</c> for the view controller.</para>
        /// <para>- Android: <c>jObject</c> for the activity.</para>
        /// </summary>
        WindowHandle = 1,
        /// <summary>
        /// <para>Window view:</para>
        /// <para>- Windows: <c>HDC</c> for the window (only with the Compatibility renderer).</para>
        /// <para>- macOS: <c>NSView*</c> for the window main view.</para>
        /// <para>- iOS: <c>UIView*</c> for the window main view.</para>
        /// </summary>
        WindowView = 2,
        /// <summary>
        /// <para>OpenGL context (only with the Compatibility renderer):</para>
        /// <para>- Windows: <c>HGLRC</c> for the window (native GL), or <c>EGLContext</c> for the window (ANGLE).</para>
        /// <para>- Linux (X11): <c>GLXContext*</c> for the window.</para>
        /// <para>- Linux (Wayland): <c>EGLContext</c> for the window.</para>
        /// <para>- macOS: <c>NSOpenGLContext*</c> for the window (native GL), or <c>EGLContext</c> for the window (ANGLE).</para>
        /// <para>- Android: <c>EGLContext</c> for the window.</para>
        /// </summary>
        OpenglContext = 3,
        /// <summary>
        /// <para>- Windows: <c>EGLDisplay</c> for the window (ANGLE).</para>
        /// <para>- macOS: <c>EGLDisplay</c> for the window (ANGLE).</para>
        /// <para>- Linux (Wayland): <c>EGLDisplay</c> for the window.</para>
        /// </summary>
        EglDisplay = 4,
        /// <summary>
        /// <para>- Windows: <c>EGLConfig</c> for the window (ANGLE).</para>
        /// <para>- macOS: <c>EGLConfig</c> for the window (ANGLE).</para>
        /// <para>- Linux (Wayland): <c>EGLConfig</c> for the window.</para>
        /// </summary>
        EglConfig = 5
    }

    public enum TtsUtteranceEvent : long
    {
        /// <summary>
        /// <para>Utterance has begun to be spoken.</para>
        /// </summary>
        Started = 0,
        /// <summary>
        /// <para>Utterance was successfully finished.</para>
        /// </summary>
        Ended = 1,
        /// <summary>
        /// <para>Utterance was canceled, or TTS service was unable to process it.</para>
        /// </summary>
        Canceled = 2,
        /// <summary>
        /// <para>Utterance reached a word or sentence boundary.</para>
        /// </summary>
        Boundary = 3
    }

    private static readonly StringName NativeName = "DisplayServer";

    private static DisplayServerInstance singleton;

    public static DisplayServerInstance Singleton =>
        singleton ??= (DisplayServerInstance)InteropUtils.EngineGetSingleton("DisplayServer");

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.HasFeature, 334065950ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the specified <paramref name="feature"/> is supported by the current <see cref="Godot.DisplayServer"/>, <see langword="false"/> otherwise.</para>
    /// </summary>
    public static bool HasFeature(DisplayServer.Feature feature)
    {
        return NativeCalls.godot_icall_1_62(MethodBind0, GodotObject.GetPtr(Singleton), (int)feature).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetName, 201670096ul);

    /// <summary>
    /// <para>Returns the name of the <see cref="Godot.DisplayServer"/> currently in use. Most operating systems only have a single <see cref="Godot.DisplayServer"/>, but Linux has access to more than one <see cref="Godot.DisplayServer"/> (currently X11 and Wayland).</para>
    /// <para>The names of built-in display servers are <c>Windows</c>, <c>macOS</c>, <c>X11</c> (Linux), <c>Wayland</c> (Linux), <c>Android</c>, <c>iOS</c>, <c>web</c> (HTML5), and <c>headless</c> (when started with the <c>--headless</c> <a href="$DOCS_URL/tutorials/editor/command_line_tutorial.html">command line argument</a>).</para>
    /// </summary>
    public static string GetName()
    {
        return NativeCalls.godot_icall_0_58(MethodBind1, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.HelpSetSearchCallbacks, 1687350599ul);

    /// <summary>
    /// <para>Sets native help system search callbacks.</para>
    /// <para><paramref name="searchCallback"/> has the following arguments: <c>String search_string, int result_limit</c> and return a <see cref="Godot.Collections.Dictionary"/> with "key, display name" pairs for the search results. Called when the user enters search terms in the <c>Help</c> menu.</para>
    /// <para><paramref name="actionCallback"/> has the following arguments: <c>String key</c>. Called when the user selects a search result in the <c>Help</c> menu.</para>
    /// <para><b>Note:</b> This method is implemented only on macOS.</para>
    /// </summary>
    public static void HelpSetSearchCallbacks(Callable searchCallback, Callable actionCallback)
    {
        NativeCalls.godot_icall_2_381(MethodBind2, GodotObject.GetPtr(Singleton), searchCallback, actionCallback);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GlobalMenuSetPopupCallbacks, 3893727526ul);

    /// <summary>
    /// <para>Registers callables to emit when the menu is respectively about to show or closed. Callback methods should have zero arguments.</para>
    /// </summary>
    [Obsolete("Use 'NativeMenu' or 'PopupMenu' instead.")]
    public static void GlobalMenuSetPopupCallbacks(string menuRoot, Callable openCallback, Callable closeCallback)
    {
        NativeCalls.godot_icall_3_382(MethodBind3, GodotObject.GetPtr(Singleton), menuRoot, openCallback, closeCallback);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GlobalMenuAddSubmenuItem, 2828985934ul);

    /// <summary>
    /// <para>Adds an item that will act as a submenu of the global menu <paramref name="menuRoot"/>. The <paramref name="submenu"/> argument is the ID of the global menu root that will be shown when the item is clicked.</para>
    /// <para>Returns index of the inserted item, it's not guaranteed to be the same as <paramref name="index"/> value.</para>
    /// <para><b>Note:</b> This method is implemented only on macOS.</para>
    /// <para><b>Supported system menu IDs:</b></para>
    /// <para><code>
    /// "_main" - Main menu (macOS).
    /// "_dock" - Dock popup menu (macOS).
    /// "_apple" - Apple menu (macOS, custom items added before "Services").
    /// "_window" - Window menu (macOS, custom items added after "Bring All to Front").
    /// "_help" - Help menu (macOS).
    /// </code></para>
    /// </summary>
    [Obsolete("Use 'NativeMenu' or 'PopupMenu' instead.")]
    public static int GlobalMenuAddSubmenuItem(string menuRoot, string label, string submenu, int index = -1)
    {
        return NativeCalls.godot_icall_4_383(MethodBind4, GodotObject.GetPtr(Singleton), menuRoot, label, submenu, index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GlobalMenuAddItem, 3616842746ul);

    /// <summary>
    /// <para>Adds a new item with text <paramref name="label"/> to the global menu with ID <paramref name="menuRoot"/>.</para>
    /// <para>Returns index of the inserted item, it's not guaranteed to be the same as <paramref name="index"/> value.</para>
    /// <para>An <paramref name="accelerator"/> can optionally be defined, which is a keyboard shortcut that can be pressed to trigger the menu button even if it's not currently open. The <paramref name="accelerator"/> is generally a combination of <see cref="Godot.KeyModifierMask"/>s and <see cref="Godot.Key"/>s using bitwise OR such as <c>KEY_MASK_CTRL | KEY_A</c> (Ctrl + A).</para>
    /// <para><b>Note:</b> The <paramref name="callback"/> and <paramref name="keyCallback"/> Callables need to accept exactly one Variant parameter, the parameter passed to the Callables will be the value passed to <paramref name="tag"/>.</para>
    /// <para><b>Note:</b> This method is implemented only on macOS.</para>
    /// <para><b>Supported system menu IDs:</b></para>
    /// <para><code>
    /// "_main" - Main menu (macOS).
    /// "_dock" - Dock popup menu (macOS).
    /// "_apple" - Apple menu (macOS, custom items added before "Services").
    /// "_window" - Window menu (macOS, custom items added after "Bring All to Front").
    /// "_help" - Help menu (macOS).
    /// </code></para>
    /// </summary>
    [Obsolete("Use 'NativeMenu' or 'PopupMenu' instead.")]
    public static int GlobalMenuAddItem(string menuRoot, string label, Callable callback = default, Callable keyCallback = default, Variant tag = default, Key accelerator = (Key)(0), int index = -1)
    {
        return NativeCalls.godot_icall_7_384(MethodBind5, GodotObject.GetPtr(Singleton), menuRoot, label, callback, keyCallback, tag, (int)accelerator, index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GlobalMenuAddCheckItem, 3616842746ul);

    /// <summary>
    /// <para>Adds a new checkable item with text <paramref name="label"/> to the global menu with ID <paramref name="menuRoot"/>.</para>
    /// <para>Returns index of the inserted item, it's not guaranteed to be the same as <paramref name="index"/> value.</para>
    /// <para>An <paramref name="accelerator"/> can optionally be defined, which is a keyboard shortcut that can be pressed to trigger the menu button even if it's not currently open. The <paramref name="accelerator"/> is generally a combination of <see cref="Godot.KeyModifierMask"/>s and <see cref="Godot.Key"/>s using bitwise OR such as <c>KEY_MASK_CTRL | KEY_A</c> (Ctrl + A).</para>
    /// <para><b>Note:</b> The <paramref name="callback"/> and <paramref name="keyCallback"/> Callables need to accept exactly one Variant parameter, the parameter passed to the Callables will be the value passed to <paramref name="tag"/>.</para>
    /// <para><b>Note:</b> This method is implemented only on macOS.</para>
    /// <para><b>Supported system menu IDs:</b></para>
    /// <para><code>
    /// "_main" - Main menu (macOS).
    /// "_dock" - Dock popup menu (macOS).
    /// "_apple" - Apple menu (macOS, custom items added before "Services").
    /// "_window" - Window menu (macOS, custom items added after "Bring All to Front").
    /// "_help" - Help menu (macOS).
    /// </code></para>
    /// </summary>
    [Obsolete("Use 'NativeMenu' or 'PopupMenu' instead.")]
    public static int GlobalMenuAddCheckItem(string menuRoot, string label, Callable callback = default, Callable keyCallback = default, Variant tag = default, Key accelerator = (Key)(0), int index = -1)
    {
        return NativeCalls.godot_icall_7_384(MethodBind6, GodotObject.GetPtr(Singleton), menuRoot, label, callback, keyCallback, tag, (int)accelerator, index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GlobalMenuAddIconItem, 3867083847ul);

    /// <summary>
    /// <para>Adds a new item with text <paramref name="label"/> and icon <paramref name="icon"/> to the global menu with ID <paramref name="menuRoot"/>.</para>
    /// <para>Returns index of the inserted item, it's not guaranteed to be the same as <paramref name="index"/> value.</para>
    /// <para>An <paramref name="accelerator"/> can optionally be defined, which is a keyboard shortcut that can be pressed to trigger the menu button even if it's not currently open. The <paramref name="accelerator"/> is generally a combination of <see cref="Godot.KeyModifierMask"/>s and <see cref="Godot.Key"/>s using bitwise OR such as <c>KEY_MASK_CTRL | KEY_A</c> (Ctrl + A).</para>
    /// <para><b>Note:</b> The <paramref name="callback"/> and <paramref name="keyCallback"/> Callables need to accept exactly one Variant parameter, the parameter passed to the Callables will be the value passed to <paramref name="tag"/>.</para>
    /// <para><b>Note:</b> This method is implemented only on macOS.</para>
    /// <para><b>Supported system menu IDs:</b></para>
    /// <para><code>
    /// "_main" - Main menu (macOS).
    /// "_dock" - Dock popup menu (macOS).
    /// "_apple" - Apple menu (macOS, custom items added before "Services").
    /// "_window" - Window menu (macOS, custom items added after "Bring All to Front").
    /// "_help" - Help menu (macOS).
    /// </code></para>
    /// </summary>
    [Obsolete("Use 'NativeMenu' or 'PopupMenu' instead.")]
    public static int GlobalMenuAddIconItem(string menuRoot, Texture2D icon, string label, Callable callback = default, Callable keyCallback = default, Variant tag = default, Key accelerator = (Key)(0), int index = -1)
    {
        return NativeCalls.godot_icall_8_385(MethodBind7, GodotObject.GetPtr(Singleton), menuRoot, GodotObject.GetPtr(icon), label, callback, keyCallback, tag, (int)accelerator, index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GlobalMenuAddIconCheckItem, 3867083847ul);

    /// <summary>
    /// <para>Adds a new checkable item with text <paramref name="label"/> and icon <paramref name="icon"/> to the global menu with ID <paramref name="menuRoot"/>.</para>
    /// <para>Returns index of the inserted item, it's not guaranteed to be the same as <paramref name="index"/> value.</para>
    /// <para>An <paramref name="accelerator"/> can optionally be defined, which is a keyboard shortcut that can be pressed to trigger the menu button even if it's not currently open. The <paramref name="accelerator"/> is generally a combination of <see cref="Godot.KeyModifierMask"/>s and <see cref="Godot.Key"/>s using bitwise OR such as <c>KEY_MASK_CTRL | KEY_A</c> (Ctrl + A).</para>
    /// <para><b>Note:</b> The <paramref name="callback"/> and <paramref name="keyCallback"/> Callables need to accept exactly one Variant parameter, the parameter passed to the Callables will be the value passed to <paramref name="tag"/>.</para>
    /// <para><b>Note:</b> This method is implemented only on macOS.</para>
    /// <para><b>Supported system menu IDs:</b></para>
    /// <para><code>
    /// "_main" - Main menu (macOS).
    /// "_dock" - Dock popup menu (macOS).
    /// "_apple" - Apple menu (macOS, custom items added before "Services").
    /// "_window" - Window menu (macOS, custom items added after "Bring All to Front").
    /// "_help" - Help menu (macOS).
    /// </code></para>
    /// </summary>
    [Obsolete("Use 'NativeMenu' or 'PopupMenu' instead.")]
    public static int GlobalMenuAddIconCheckItem(string menuRoot, Texture2D icon, string label, Callable callback = default, Callable keyCallback = default, Variant tag = default, Key accelerator = (Key)(0), int index = -1)
    {
        return NativeCalls.godot_icall_8_385(MethodBind8, GodotObject.GetPtr(Singleton), menuRoot, GodotObject.GetPtr(icon), label, callback, keyCallback, tag, (int)accelerator, index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GlobalMenuAddRadioCheckItem, 3616842746ul);

    /// <summary>
    /// <para>Adds a new radio-checkable item with text <paramref name="label"/> to the global menu with ID <paramref name="menuRoot"/>.</para>
    /// <para>Returns index of the inserted item, it's not guaranteed to be the same as <paramref name="index"/> value.</para>
    /// <para>An <paramref name="accelerator"/> can optionally be defined, which is a keyboard shortcut that can be pressed to trigger the menu button even if it's not currently open. The <paramref name="accelerator"/> is generally a combination of <see cref="Godot.KeyModifierMask"/>s and <see cref="Godot.Key"/>s using bitwise OR such as <c>KEY_MASK_CTRL | KEY_A</c> (Ctrl + A).</para>
    /// <para><b>Note:</b> Radio-checkable items just display a checkmark, but don't have any built-in checking behavior and must be checked/unchecked manually. See <see cref="Godot.DisplayServer.GlobalMenuSetItemChecked(string, int, bool)"/> for more info on how to control it.</para>
    /// <para><b>Note:</b> The <paramref name="callback"/> and <paramref name="keyCallback"/> Callables need to accept exactly one Variant parameter, the parameter passed to the Callables will be the value passed to <paramref name="tag"/>.</para>
    /// <para><b>Note:</b> This method is implemented only on macOS.</para>
    /// <para><b>Supported system menu IDs:</b></para>
    /// <para><code>
    /// "_main" - Main menu (macOS).
    /// "_dock" - Dock popup menu (macOS).
    /// "_apple" - Apple menu (macOS, custom items added before "Services").
    /// "_window" - Window menu (macOS, custom items added after "Bring All to Front").
    /// "_help" - Help menu (macOS).
    /// </code></para>
    /// </summary>
    [Obsolete("Use 'NativeMenu' or 'PopupMenu' instead.")]
    public static int GlobalMenuAddRadioCheckItem(string menuRoot, string label, Callable callback = default, Callable keyCallback = default, Variant tag = default, Key accelerator = (Key)(0), int index = -1)
    {
        return NativeCalls.godot_icall_7_384(MethodBind9, GodotObject.GetPtr(Singleton), menuRoot, label, callback, keyCallback, tag, (int)accelerator, index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GlobalMenuAddIconRadioCheckItem, 3867083847ul);

    /// <summary>
    /// <para>Adds a new radio-checkable item with text <paramref name="label"/> and icon <paramref name="icon"/> to the global menu with ID <paramref name="menuRoot"/>.</para>
    /// <para>Returns index of the inserted item, it's not guaranteed to be the same as <paramref name="index"/> value.</para>
    /// <para>An <paramref name="accelerator"/> can optionally be defined, which is a keyboard shortcut that can be pressed to trigger the menu button even if it's not currently open. The <paramref name="accelerator"/> is generally a combination of <see cref="Godot.KeyModifierMask"/>s and <see cref="Godot.Key"/>s using bitwise OR such as <c>KEY_MASK_CTRL | KEY_A</c> (Ctrl + A).</para>
    /// <para><b>Note:</b> Radio-checkable items just display a checkmark, but don't have any built-in checking behavior and must be checked/unchecked manually. See <see cref="Godot.DisplayServer.GlobalMenuSetItemChecked(string, int, bool)"/> for more info on how to control it.</para>
    /// <para><b>Note:</b> The <paramref name="callback"/> and <paramref name="keyCallback"/> Callables need to accept exactly one Variant parameter, the parameter passed to the Callables will be the value passed to <paramref name="tag"/>.</para>
    /// <para><b>Note:</b> This method is implemented only on macOS.</para>
    /// <para><b>Supported system menu IDs:</b></para>
    /// <para><code>
    /// "_main" - Main menu (macOS).
    /// "_dock" - Dock popup menu (macOS).
    /// "_apple" - Apple menu (macOS, custom items added before "Services").
    /// "_window" - Window menu (macOS, custom items added after "Bring All to Front").
    /// "_help" - Help menu (macOS).
    /// </code></para>
    /// </summary>
    [Obsolete("Use 'NativeMenu' or 'PopupMenu' instead.")]
    public static int GlobalMenuAddIconRadioCheckItem(string menuRoot, Texture2D icon, string label, Callable callback = default, Callable keyCallback = default, Variant tag = default, Key accelerator = (Key)(0), int index = -1)
    {
        return NativeCalls.godot_icall_8_385(MethodBind10, GodotObject.GetPtr(Singleton), menuRoot, GodotObject.GetPtr(icon), label, callback, keyCallback, tag, (int)accelerator, index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GlobalMenuAddMultistateItem, 3297554655ul);

    /// <summary>
    /// <para>Adds a new item with text <paramref name="label"/> to the global menu with ID <paramref name="menuRoot"/>.</para>
    /// <para>Contrarily to normal binary items, multistate items can have more than two states, as defined by <paramref name="maxStates"/>. Each press or activate of the item will increase the state by one. The default value is defined by <paramref name="defaultState"/>.</para>
    /// <para>Returns index of the inserted item, it's not guaranteed to be the same as <paramref name="index"/> value.</para>
    /// <para>An <paramref name="accelerator"/> can optionally be defined, which is a keyboard shortcut that can be pressed to trigger the menu button even if it's not currently open. The <paramref name="accelerator"/> is generally a combination of <see cref="Godot.KeyModifierMask"/>s and <see cref="Godot.Key"/>s using bitwise OR such as <c>KEY_MASK_CTRL | KEY_A</c> (Ctrl + A).</para>
    /// <para><b>Note:</b> By default, there's no indication of the current item state, it should be changed manually.</para>
    /// <para><b>Note:</b> The <paramref name="callback"/> and <paramref name="keyCallback"/> Callables need to accept exactly one Variant parameter, the parameter passed to the Callables will be the value passed to <paramref name="tag"/>.</para>
    /// <para><b>Note:</b> This method is implemented only on macOS.</para>
    /// <para><b>Supported system menu IDs:</b></para>
    /// <para><code>
    /// "_main" - Main menu (macOS).
    /// "_dock" - Dock popup menu (macOS).
    /// "_apple" - Apple menu (macOS, custom items added before "Services").
    /// "_window" - Window menu (macOS, custom items added after "Bring All to Front").
    /// "_help" - Help menu (macOS).
    /// </code></para>
    /// </summary>
    [Obsolete("Use 'NativeMenu' or 'PopupMenu' instead.")]
    public static int GlobalMenuAddMultistateItem(string menuRoot, string label, int maxStates, int defaultState, Callable callback = default, Callable keyCallback = default, Variant tag = default, Key accelerator = (Key)(0), int index = -1)
    {
        return NativeCalls.godot_icall_9_386(MethodBind11, GodotObject.GetPtr(Singleton), menuRoot, label, maxStates, defaultState, callback, keyCallback, tag, (int)accelerator, index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GlobalMenuAddSeparator, 3214812433ul);

    /// <summary>
    /// <para>Adds a separator between items to the global menu with ID <paramref name="menuRoot"/>. Separators also occupy an index.</para>
    /// <para>Returns index of the inserted item, it's not guaranteed to be the same as <paramref name="index"/> value.</para>
    /// <para><b>Note:</b> This method is implemented only on macOS.</para>
    /// <para><b>Supported system menu IDs:</b></para>
    /// <para><code>
    /// "_main" - Main menu (macOS).
    /// "_dock" - Dock popup menu (macOS).
    /// "_apple" - Apple menu (macOS, custom items added before "Services").
    /// "_window" - Window menu (macOS, custom items added after "Bring All to Front").
    /// "_help" - Help menu (macOS).
    /// </code></para>
    /// </summary>
    [Obsolete("Use 'NativeMenu' or 'PopupMenu' instead.")]
    public static int GlobalMenuAddSeparator(string menuRoot, int index = -1)
    {
        return NativeCalls.godot_icall_2_387(MethodBind12, GodotObject.GetPtr(Singleton), menuRoot, index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GlobalMenuGetItemIndexFromText, 2878152881ul);

    /// <summary>
    /// <para>Returns the index of the item with the specified <paramref name="text"/>. Indices are automatically assigned to each item by the engine, and cannot be set manually.</para>
    /// <para><b>Note:</b> This method is implemented only on macOS.</para>
    /// </summary>
    [Obsolete("Use 'NativeMenu' or 'PopupMenu' instead.")]
    public static int GlobalMenuGetItemIndexFromText(string menuRoot, string text)
    {
        return NativeCalls.godot_icall_2_330(MethodBind13, GodotObject.GetPtr(Singleton), menuRoot, text);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GlobalMenuGetItemIndexFromTag, 2941063483ul);

    /// <summary>
    /// <para>Returns the index of the item with the specified <paramref name="tag"/>. Indices are automatically assigned to each item by the engine, and cannot be set manually.</para>
    /// <para><b>Note:</b> This method is implemented only on macOS.</para>
    /// </summary>
    [Obsolete("Use 'NativeMenu' or 'PopupMenu' instead.")]
    public static int GlobalMenuGetItemIndexFromTag(string menuRoot, Variant tag)
    {
        return NativeCalls.godot_icall_2_388(MethodBind14, GodotObject.GetPtr(Singleton), menuRoot, tag);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GlobalMenuIsItemChecked, 3511468594ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the item at index <paramref name="idx"/> is checked.</para>
    /// <para><b>Note:</b> This method is implemented only on macOS.</para>
    /// </summary>
    [Obsolete("Use 'NativeMenu' or 'PopupMenu' instead.")]
    public static bool GlobalMenuIsItemChecked(string menuRoot, int idx)
    {
        return NativeCalls.godot_icall_2_389(MethodBind15, GodotObject.GetPtr(Singleton), menuRoot, idx).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GlobalMenuIsItemCheckable, 3511468594ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the item at index <paramref name="idx"/> is checkable in some way, i.e. if it has a checkbox or radio button.</para>
    /// <para><b>Note:</b> This method is implemented only on macOS.</para>
    /// </summary>
    [Obsolete("Use 'NativeMenu' or 'PopupMenu' instead.")]
    public static bool GlobalMenuIsItemCheckable(string menuRoot, int idx)
    {
        return NativeCalls.godot_icall_2_389(MethodBind16, GodotObject.GetPtr(Singleton), menuRoot, idx).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GlobalMenuIsItemRadioCheckable, 3511468594ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the item at index <paramref name="idx"/> has radio button-style checkability.</para>
    /// <para><b>Note:</b> This is purely cosmetic; you must add the logic for checking/unchecking items in radio groups.</para>
    /// <para><b>Note:</b> This method is implemented only on macOS.</para>
    /// </summary>
    [Obsolete("Use 'NativeMenu' or 'PopupMenu' instead.")]
    public static bool GlobalMenuIsItemRadioCheckable(string menuRoot, int idx)
    {
        return NativeCalls.godot_icall_2_389(MethodBind17, GodotObject.GetPtr(Singleton), menuRoot, idx).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GlobalMenuGetItemCallback, 748666903ul);

    /// <summary>
    /// <para>Returns the callback of the item at index <paramref name="idx"/>.</para>
    /// <para><b>Note:</b> This method is implemented only on macOS.</para>
    /// </summary>
    [Obsolete("Use 'NativeMenu' or 'PopupMenu' instead.")]
    public static Callable GlobalMenuGetItemCallback(string menuRoot, int idx)
    {
        return NativeCalls.godot_icall_2_390(MethodBind18, GodotObject.GetPtr(Singleton), menuRoot, idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GlobalMenuGetItemKeyCallback, 748666903ul);

    /// <summary>
    /// <para>Returns the callback of the item accelerator at index <paramref name="idx"/>.</para>
    /// <para><b>Note:</b> This method is implemented only on macOS.</para>
    /// </summary>
    [Obsolete("Use 'NativeMenu' or 'PopupMenu' instead.")]
    public static Callable GlobalMenuGetItemKeyCallback(string menuRoot, int idx)
    {
        return NativeCalls.godot_icall_2_390(MethodBind19, GodotObject.GetPtr(Singleton), menuRoot, idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GlobalMenuGetItemTag, 330672633ul);

    /// <summary>
    /// <para>Returns the metadata of the specified item, which might be of any type. You can set it with <see cref="Godot.DisplayServer.GlobalMenuSetItemTag(string, int, Variant)"/>, which provides a simple way of assigning context data to items.</para>
    /// <para><b>Note:</b> This method is implemented only on macOS.</para>
    /// </summary>
    [Obsolete("Use 'NativeMenu' or 'PopupMenu' instead.")]
    public static Variant GlobalMenuGetItemTag(string menuRoot, int idx)
    {
        return NativeCalls.godot_icall_2_391(MethodBind20, GodotObject.GetPtr(Singleton), menuRoot, idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GlobalMenuGetItemText, 591067909ul);

    /// <summary>
    /// <para>Returns the text of the item at index <paramref name="idx"/>.</para>
    /// <para><b>Note:</b> This method is implemented only on macOS.</para>
    /// </summary>
    [Obsolete("Use 'NativeMenu' or 'PopupMenu' instead.")]
    public static string GlobalMenuGetItemText(string menuRoot, int idx)
    {
        return NativeCalls.godot_icall_2_392(MethodBind21, GodotObject.GetPtr(Singleton), menuRoot, idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GlobalMenuGetItemSubmenu, 591067909ul);

    /// <summary>
    /// <para>Returns the submenu ID of the item at index <paramref name="idx"/>. See <see cref="Godot.DisplayServer.GlobalMenuAddSubmenuItem(string, string, string, int)"/> for more info on how to add a submenu.</para>
    /// <para><b>Note:</b> This method is implemented only on macOS.</para>
    /// </summary>
    [Obsolete("Use 'NativeMenu' or 'PopupMenu' instead.")]
    public static string GlobalMenuGetItemSubmenu(string menuRoot, int idx)
    {
        return NativeCalls.godot_icall_2_392(MethodBind22, GodotObject.GetPtr(Singleton), menuRoot, idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GlobalMenuGetItemAccelerator, 936065394ul);

    /// <summary>
    /// <para>Returns the accelerator of the item at index <paramref name="idx"/>. Accelerators are special combinations of keys that activate the item, no matter which control is focused.</para>
    /// <para><b>Note:</b> This method is implemented only on macOS.</para>
    /// </summary>
    [Obsolete("Use 'NativeMenu' or 'PopupMenu' instead.")]
    public static Key GlobalMenuGetItemAccelerator(string menuRoot, int idx)
    {
        return (Key)NativeCalls.godot_icall_2_387(MethodBind23, GodotObject.GetPtr(Singleton), menuRoot, idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GlobalMenuIsItemDisabled, 3511468594ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the item at index <paramref name="idx"/> is disabled. When it is disabled it can't be selected, or its action invoked.</para>
    /// <para>See <see cref="Godot.DisplayServer.GlobalMenuSetItemDisabled(string, int, bool)"/> for more info on how to disable an item.</para>
    /// <para><b>Note:</b> This method is implemented only on macOS.</para>
    /// </summary>
    [Obsolete("Use 'NativeMenu' or 'PopupMenu' instead.")]
    public static bool GlobalMenuIsItemDisabled(string menuRoot, int idx)
    {
        return NativeCalls.godot_icall_2_389(MethodBind24, GodotObject.GetPtr(Singleton), menuRoot, idx).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GlobalMenuIsItemHidden, 3511468594ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the item at index <paramref name="idx"/> is hidden.</para>
    /// <para>See <see cref="Godot.DisplayServer.GlobalMenuSetItemHidden(string, int, bool)"/> for more info on how to hide an item.</para>
    /// <para><b>Note:</b> This method is implemented only on macOS.</para>
    /// </summary>
    [Obsolete("Use 'NativeMenu' or 'PopupMenu' instead.")]
    public static bool GlobalMenuIsItemHidden(string menuRoot, int idx)
    {
        return NativeCalls.godot_icall_2_389(MethodBind25, GodotObject.GetPtr(Singleton), menuRoot, idx).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GlobalMenuGetItemTooltip, 591067909ul);

    /// <summary>
    /// <para>Returns the tooltip associated with the specified index <paramref name="idx"/>.</para>
    /// <para><b>Note:</b> This method is implemented only on macOS.</para>
    /// </summary>
    [Obsolete("Use 'NativeMenu' or 'PopupMenu' instead.")]
    public static string GlobalMenuGetItemTooltip(string menuRoot, int idx)
    {
        return NativeCalls.godot_icall_2_392(MethodBind26, GodotObject.GetPtr(Singleton), menuRoot, idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GlobalMenuGetItemState, 3422818498ul);

    /// <summary>
    /// <para>Returns the state of a multistate item. See <see cref="Godot.DisplayServer.GlobalMenuAddMultistateItem(string, string, int, int, Callable, Callable, Variant, Key, int)"/> for details.</para>
    /// <para><b>Note:</b> This method is implemented only on macOS.</para>
    /// </summary>
    [Obsolete("Use 'NativeMenu' or 'PopupMenu' instead.")]
    public static int GlobalMenuGetItemState(string menuRoot, int idx)
    {
        return NativeCalls.godot_icall_2_387(MethodBind27, GodotObject.GetPtr(Singleton), menuRoot, idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GlobalMenuGetItemMaxStates, 3422818498ul);

    /// <summary>
    /// <para>Returns number of states of a multistate item. See <see cref="Godot.DisplayServer.GlobalMenuAddMultistateItem(string, string, int, int, Callable, Callable, Variant, Key, int)"/> for details.</para>
    /// <para><b>Note:</b> This method is implemented only on macOS.</para>
    /// </summary>
    [Obsolete("Use 'NativeMenu' or 'PopupMenu' instead.")]
    public static int GlobalMenuGetItemMaxStates(string menuRoot, int idx)
    {
        return NativeCalls.godot_icall_2_387(MethodBind28, GodotObject.GetPtr(Singleton), menuRoot, idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GlobalMenuGetItemIcon, 3591713183ul);

    /// <summary>
    /// <para>Returns the icon of the item at index <paramref name="idx"/>.</para>
    /// <para><b>Note:</b> This method is implemented only on macOS.</para>
    /// </summary>
    [Obsolete("Use 'NativeMenu' or 'PopupMenu' instead.")]
    public static Texture2D GlobalMenuGetItemIcon(string menuRoot, int idx)
    {
        return (Texture2D)NativeCalls.godot_icall_2_393(MethodBind29, GodotObject.GetPtr(Singleton), menuRoot, idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GlobalMenuGetItemIndentationLevel, 3422818498ul);

    /// <summary>
    /// <para>Returns the horizontal offset of the item at the given <paramref name="idx"/>.</para>
    /// <para><b>Note:</b> This method is implemented only on macOS.</para>
    /// </summary>
    [Obsolete("Use 'NativeMenu' or 'PopupMenu' instead.")]
    public static int GlobalMenuGetItemIndentationLevel(string menuRoot, int idx)
    {
        return NativeCalls.godot_icall_2_387(MethodBind30, GodotObject.GetPtr(Singleton), menuRoot, idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GlobalMenuSetItemChecked, 4108344793ul);

    /// <summary>
    /// <para>Sets the checkstate status of the item at index <paramref name="idx"/>.</para>
    /// <para><b>Note:</b> This method is implemented only on macOS.</para>
    /// </summary>
    [Obsolete("Use 'NativeMenu' or 'PopupMenu' instead.")]
    public static void GlobalMenuSetItemChecked(string menuRoot, int idx, bool @checked)
    {
        NativeCalls.godot_icall_3_394(MethodBind31, GodotObject.GetPtr(Singleton), menuRoot, idx, @checked.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind32 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GlobalMenuSetItemCheckable, 4108344793ul);

    /// <summary>
    /// <para>Sets whether the item at index <paramref name="idx"/> has a checkbox. If <see langword="false"/>, sets the type of the item to plain text.</para>
    /// <para><b>Note:</b> This method is implemented only on macOS.</para>
    /// </summary>
    [Obsolete("Use 'NativeMenu' or 'PopupMenu' instead.")]
    public static void GlobalMenuSetItemCheckable(string menuRoot, int idx, bool checkable)
    {
        NativeCalls.godot_icall_3_394(MethodBind32, GodotObject.GetPtr(Singleton), menuRoot, idx, checkable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind33 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GlobalMenuSetItemRadioCheckable, 4108344793ul);

    /// <summary>
    /// <para>Sets the type of the item at the specified index <paramref name="idx"/> to radio button. If <see langword="false"/>, sets the type of the item to plain text.</para>
    /// <para><b>Note:</b> This is purely cosmetic; you must add the logic for checking/unchecking items in radio groups.</para>
    /// <para><b>Note:</b> This method is implemented only on macOS.</para>
    /// </summary>
    [Obsolete("Use 'NativeMenu' or 'PopupMenu' instead.")]
    public static void GlobalMenuSetItemRadioCheckable(string menuRoot, int idx, bool checkable)
    {
        NativeCalls.godot_icall_3_394(MethodBind33, GodotObject.GetPtr(Singleton), menuRoot, idx, checkable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind34 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GlobalMenuSetItemCallback, 3809915389ul);

    /// <summary>
    /// <para>Sets the callback of the item at index <paramref name="idx"/>. Callback is emitted when an item is pressed.</para>
    /// <para><b>Note:</b> The <paramref name="callback"/> Callable needs to accept exactly one Variant parameter, the parameter passed to the Callable will be the value passed to the <c>tag</c> parameter when the menu item was created.</para>
    /// <para><b>Note:</b> This method is implemented only on macOS.</para>
    /// </summary>
    [Obsolete("Use 'NativeMenu' or 'PopupMenu' instead.")]
    public static void GlobalMenuSetItemCallback(string menuRoot, int idx, Callable callback)
    {
        NativeCalls.godot_icall_3_395(MethodBind34, GodotObject.GetPtr(Singleton), menuRoot, idx, callback);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind35 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GlobalMenuSetItemHoverCallbacks, 3809915389ul);

    /// <summary>
    /// <para>Sets the callback of the item at index <paramref name="idx"/>. The callback is emitted when an item is hovered.</para>
    /// <para><b>Note:</b> The <paramref name="callback"/> Callable needs to accept exactly one Variant parameter, the parameter passed to the Callable will be the value passed to the <c>tag</c> parameter when the menu item was created.</para>
    /// <para><b>Note:</b> This method is implemented only on macOS.</para>
    /// </summary>
    [Obsolete("Use 'NativeMenu' or 'PopupMenu' instead.")]
    public static void GlobalMenuSetItemHoverCallbacks(string menuRoot, int idx, Callable callback)
    {
        NativeCalls.godot_icall_3_395(MethodBind35, GodotObject.GetPtr(Singleton), menuRoot, idx, callback);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind36 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GlobalMenuSetItemKeyCallback, 3809915389ul);

    /// <summary>
    /// <para>Sets the callback of the item at index <paramref name="idx"/>. Callback is emitted when its accelerator is activated.</para>
    /// <para><b>Note:</b> The <paramref name="keyCallback"/> Callable needs to accept exactly one Variant parameter, the parameter passed to the Callable will be the value passed to the <c>tag</c> parameter when the menu item was created.</para>
    /// <para><b>Note:</b> This method is implemented only on macOS.</para>
    /// </summary>
    [Obsolete("Use 'NativeMenu' or 'PopupMenu' instead.")]
    public static void GlobalMenuSetItemKeyCallback(string menuRoot, int idx, Callable keyCallback)
    {
        NativeCalls.godot_icall_3_395(MethodBind36, GodotObject.GetPtr(Singleton), menuRoot, idx, keyCallback);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind37 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GlobalMenuSetItemTag, 453659863ul);

    /// <summary>
    /// <para>Sets the metadata of an item, which may be of any type. You can later get it with <see cref="Godot.DisplayServer.GlobalMenuGetItemTag(string, int)"/>, which provides a simple way of assigning context data to items.</para>
    /// <para><b>Note:</b> This method is implemented only on macOS.</para>
    /// </summary>
    [Obsolete("Use 'NativeMenu' or 'PopupMenu' instead.")]
    public static void GlobalMenuSetItemTag(string menuRoot, int idx, Variant tag)
    {
        NativeCalls.godot_icall_3_396(MethodBind37, GodotObject.GetPtr(Singleton), menuRoot, idx, tag);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind38 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GlobalMenuSetItemText, 965966136ul);

    /// <summary>
    /// <para>Sets the text of the item at index <paramref name="idx"/>.</para>
    /// <para><b>Note:</b> This method is implemented only on macOS.</para>
    /// </summary>
    [Obsolete("Use 'NativeMenu' or 'PopupMenu' instead.")]
    public static void GlobalMenuSetItemText(string menuRoot, int idx, string text)
    {
        NativeCalls.godot_icall_3_397(MethodBind38, GodotObject.GetPtr(Singleton), menuRoot, idx, text);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind39 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GlobalMenuSetItemSubmenu, 965966136ul);

    /// <summary>
    /// <para>Sets the submenu of the item at index <paramref name="idx"/>. The submenu is the ID of a global menu root that would be shown when the item is clicked.</para>
    /// <para><b>Note:</b> This method is implemented only on macOS.</para>
    /// </summary>
    [Obsolete("Use 'NativeMenu' or 'PopupMenu' instead.")]
    public static void GlobalMenuSetItemSubmenu(string menuRoot, int idx, string submenu)
    {
        NativeCalls.godot_icall_3_397(MethodBind39, GodotObject.GetPtr(Singleton), menuRoot, idx, submenu);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind40 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GlobalMenuSetItemAccelerator, 566943293ul);

    /// <summary>
    /// <para>Sets the accelerator of the item at index <paramref name="idx"/>. <paramref name="keycode"/> can be a single <see cref="Godot.Key"/>, or a combination of <see cref="Godot.KeyModifierMask"/>s and <see cref="Godot.Key"/>s using bitwise OR such as <c>KEY_MASK_CTRL | KEY_A</c> (Ctrl + A).</para>
    /// <para><b>Note:</b> This method is implemented only on macOS.</para>
    /// </summary>
    [Obsolete("Use 'NativeMenu' or 'PopupMenu' instead.")]
    public static void GlobalMenuSetItemAccelerator(string menuRoot, int idx, Key keycode)
    {
        NativeCalls.godot_icall_3_398(MethodBind40, GodotObject.GetPtr(Singleton), menuRoot, idx, (int)keycode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind41 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GlobalMenuSetItemDisabled, 4108344793ul);

    /// <summary>
    /// <para>Enables/disables the item at index <paramref name="idx"/>. When it is disabled, it can't be selected and its action can't be invoked.</para>
    /// <para><b>Note:</b> This method is implemented only on macOS.</para>
    /// </summary>
    [Obsolete("Use 'NativeMenu' or 'PopupMenu' instead.")]
    public static void GlobalMenuSetItemDisabled(string menuRoot, int idx, bool disabled)
    {
        NativeCalls.godot_icall_3_394(MethodBind41, GodotObject.GetPtr(Singleton), menuRoot, idx, disabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind42 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GlobalMenuSetItemHidden, 4108344793ul);

    /// <summary>
    /// <para>Hides/shows the item at index <paramref name="idx"/>. When it is hidden, an item does not appear in a menu and its action cannot be invoked.</para>
    /// <para><b>Note:</b> This method is implemented only on macOS.</para>
    /// </summary>
    [Obsolete("Use 'NativeMenu' or 'PopupMenu' instead.")]
    public static void GlobalMenuSetItemHidden(string menuRoot, int idx, bool hidden)
    {
        NativeCalls.godot_icall_3_394(MethodBind42, GodotObject.GetPtr(Singleton), menuRoot, idx, hidden.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind43 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GlobalMenuSetItemTooltip, 965966136ul);

    /// <summary>
    /// <para>Sets the <see cref="string"/> tooltip of the item at the specified index <paramref name="idx"/>.</para>
    /// <para><b>Note:</b> This method is implemented only on macOS.</para>
    /// </summary>
    [Obsolete("Use 'NativeMenu' or 'PopupMenu' instead.")]
    public static void GlobalMenuSetItemTooltip(string menuRoot, int idx, string tooltip)
    {
        NativeCalls.godot_icall_3_397(MethodBind43, GodotObject.GetPtr(Singleton), menuRoot, idx, tooltip);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind44 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GlobalMenuSetItemState, 3474840532ul);

    /// <summary>
    /// <para>Sets the state of a multistate item. See <see cref="Godot.DisplayServer.GlobalMenuAddMultistateItem(string, string, int, int, Callable, Callable, Variant, Key, int)"/> for details.</para>
    /// <para><b>Note:</b> This method is implemented only on macOS.</para>
    /// </summary>
    [Obsolete("Use 'NativeMenu' or 'PopupMenu' instead.")]
    public static void GlobalMenuSetItemState(string menuRoot, int idx, int state)
    {
        NativeCalls.godot_icall_3_398(MethodBind44, GodotObject.GetPtr(Singleton), menuRoot, idx, state);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind45 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GlobalMenuSetItemMaxStates, 3474840532ul);

    /// <summary>
    /// <para>Sets number of state of a multistate item. See <see cref="Godot.DisplayServer.GlobalMenuAddMultistateItem(string, string, int, int, Callable, Callable, Variant, Key, int)"/> for details.</para>
    /// <para><b>Note:</b> This method is implemented only on macOS.</para>
    /// </summary>
    [Obsolete("Use 'NativeMenu' or 'PopupMenu' instead.")]
    public static void GlobalMenuSetItemMaxStates(string menuRoot, int idx, int maxStates)
    {
        NativeCalls.godot_icall_3_398(MethodBind45, GodotObject.GetPtr(Singleton), menuRoot, idx, maxStates);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind46 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GlobalMenuSetItemIcon, 3201338066ul);

    /// <summary>
    /// <para>Replaces the <see cref="Godot.Texture2D"/> icon of the specified <paramref name="idx"/>.</para>
    /// <para><b>Note:</b> This method is implemented only on macOS.</para>
    /// <para><b>Note:</b> This method is not supported by macOS "_dock" menu items.</para>
    /// </summary>
    [Obsolete("Use 'NativeMenu' or 'PopupMenu' instead.")]
    public static void GlobalMenuSetItemIcon(string menuRoot, int idx, Texture2D icon)
    {
        NativeCalls.godot_icall_3_399(MethodBind46, GodotObject.GetPtr(Singleton), menuRoot, idx, GodotObject.GetPtr(icon));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind47 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GlobalMenuSetItemIndentationLevel, 3474840532ul);

    /// <summary>
    /// <para>Sets the horizontal offset of the item at the given <paramref name="idx"/>.</para>
    /// <para><b>Note:</b> This method is implemented only on macOS.</para>
    /// </summary>
    [Obsolete("Use 'NativeMenu' or 'PopupMenu' instead.")]
    public static void GlobalMenuSetItemIndentationLevel(string menuRoot, int idx, int level)
    {
        NativeCalls.godot_icall_3_398(MethodBind47, GodotObject.GetPtr(Singleton), menuRoot, idx, level);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind48 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GlobalMenuGetItemCount, 1321353865ul);

    /// <summary>
    /// <para>Returns number of items in the global menu with ID <paramref name="menuRoot"/>.</para>
    /// <para><b>Note:</b> This method is implemented only on macOS.</para>
    /// </summary>
    [Obsolete("Use 'NativeMenu' or 'PopupMenu' instead.")]
    public static int GlobalMenuGetItemCount(string menuRoot)
    {
        return NativeCalls.godot_icall_1_134(MethodBind48, GodotObject.GetPtr(Singleton), menuRoot);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind49 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GlobalMenuRemoveItem, 2956805083ul);

    /// <summary>
    /// <para>Removes the item at index <paramref name="idx"/> from the global menu <paramref name="menuRoot"/>.</para>
    /// <para><b>Note:</b> The indices of items after the removed item will be shifted by one.</para>
    /// <para><b>Note:</b> This method is implemented only on macOS.</para>
    /// </summary>
    [Obsolete("Use 'NativeMenu' or 'PopupMenu' instead.")]
    public static void GlobalMenuRemoveItem(string menuRoot, int idx)
    {
        NativeCalls.godot_icall_2_400(MethodBind49, GodotObject.GetPtr(Singleton), menuRoot, idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind50 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GlobalMenuClear, 83702148ul);

    /// <summary>
    /// <para>Removes all items from the global menu with ID <paramref name="menuRoot"/>.</para>
    /// <para><b>Note:</b> This method is implemented only on macOS.</para>
    /// <para><b>Supported system menu IDs:</b></para>
    /// <para><code>
    /// "_main" - Main menu (macOS).
    /// "_dock" - Dock popup menu (macOS).
    /// "_apple" - Apple menu (macOS, custom items added before "Services").
    /// "_window" - Window menu (macOS, custom items added after "Bring All to Front").
    /// "_help" - Help menu (macOS).
    /// </code></para>
    /// </summary>
    [Obsolete("Use 'NativeMenu' or 'PopupMenu' instead.")]
    public static void GlobalMenuClear(string menuRoot)
    {
        NativeCalls.godot_icall_1_57(MethodBind50, GodotObject.GetPtr(Singleton), menuRoot);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind51 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GlobalMenuGetSystemMenuRoots, 3102165223ul);

    /// <summary>
    /// <para>Returns Dictionary of supported system menu IDs and names.</para>
    /// <para><b>Note:</b> This method is implemented only on macOS.</para>
    /// </summary>
    [Obsolete("Use 'NativeMenu' or 'PopupMenu' instead.")]
    public static Godot.Collections.Dictionary GlobalMenuGetSystemMenuRoots()
    {
        return NativeCalls.godot_icall_0_122(MethodBind51, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind52 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.TtsIsSpeaking, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the synthesizer is generating speech, or have utterance waiting in the queue.</para>
    /// <para><b>Note:</b> This method is implemented on Android, iOS, Web, Linux (X11/Wayland), macOS, and Windows.</para>
    /// </summary>
    public static bool TtsIsSpeaking()
    {
        return NativeCalls.godot_icall_0_15(MethodBind52, GodotObject.GetPtr(Singleton)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind53 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.TtsIsPaused, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the synthesizer is in a paused state.</para>
    /// <para><b>Note:</b> This method is implemented on Android, iOS, Web, Linux (X11/Wayland), macOS, and Windows.</para>
    /// </summary>
    public static bool TtsIsPaused()
    {
        return NativeCalls.godot_icall_0_15(MethodBind53, GodotObject.GetPtr(Singleton)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind54 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.TtsGetVoices, 3995934104ul);

    /// <summary>
    /// <para>Returns an <see cref="Godot.Collections.Array"/> of voice information dictionaries.</para>
    /// <para>Each <see cref="Godot.Collections.Dictionary"/> contains two <see cref="string"/> entries:</para>
    /// <para>- <c>name</c> is voice name.</para>
    /// <para>- <c>id</c> is voice identifier.</para>
    /// <para>- <c>language</c> is language code in <c>lang_Variant</c> format. The <c>lang</c> part is a 2 or 3-letter code based on the ISO-639 standard, in lowercase. The <c>Variant</c> part is an engine-dependent string describing country, region or/and dialect.</para>
    /// <para>Note that Godot depends on system libraries for text-to-speech functionality. These libraries are installed by default on Windows and macOS, but not on all Linux distributions. If they are not present, this method will return an empty list. This applies to both Godot users on Linux, as well as end-users on Linux running Godot games that use text-to-speech.</para>
    /// <para><b>Note:</b> This method is implemented on Android, iOS, Web, Linux (X11/Wayland), macOS, and Windows.</para>
    /// </summary>
    public static Godot.Collections.Array<Godot.Collections.Dictionary> TtsGetVoices()
    {
        return new Godot.Collections.Array<Godot.Collections.Dictionary>(NativeCalls.godot_icall_0_120(MethodBind54, GodotObject.GetPtr(Singleton)));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind55 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.TtsGetVoicesForLanguage, 4291131558ul);

    /// <summary>
    /// <para>Returns a <see cref="string"/>[] of voice identifiers for the <paramref name="language"/>.</para>
    /// <para><b>Note:</b> This method is implemented on Android, iOS, Web, Linux (X11/Wayland), macOS, and Windows.</para>
    /// </summary>
    public static string[] TtsGetVoicesForLanguage(string language)
    {
        return NativeCalls.godot_icall_1_328(MethodBind55, GodotObject.GetPtr(Singleton), language);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind56 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.TtsSpeak, 903992738ul);

    /// <summary>
    /// <para>Adds an utterance to the queue. If <paramref name="interrupt"/> is <see langword="true"/>, the queue is cleared first.</para>
    /// <para>- <paramref name="voice"/> identifier is one of the <c>"id"</c> values returned by <see cref="Godot.DisplayServer.TtsGetVoices()"/> or one of the values returned by <see cref="Godot.DisplayServer.TtsGetVoicesForLanguage(string)"/>.</para>
    /// <para>- <paramref name="volume"/> ranges from <c>0</c> (lowest) to <c>100</c> (highest).</para>
    /// <para>- <paramref name="pitch"/> ranges from <c>0.0</c> (lowest) to <c>2.0</c> (highest), <c>1.0</c> is default pitch for the current voice.</para>
    /// <para>- <paramref name="rate"/> ranges from <c>0.1</c> (lowest) to <c>10.0</c> (highest), <c>1.0</c> is a normal speaking rate. Other values act as a percentage relative.</para>
    /// <para>- <paramref name="utteranceId"/> is passed as a parameter to the callback functions.</para>
    /// <para><b>Note:</b> On Windows and Linux (X11/Wayland), utterance <paramref name="text"/> can use SSML markup. SSML support is engine and voice dependent. If the engine does not support SSML, you should strip out all XML markup before calling <see cref="Godot.DisplayServer.TtsSpeak(string, string, int, float, float, long, bool)"/>.</para>
    /// <para><b>Note:</b> The granularity of pitch, rate, and volume is engine and voice dependent. Values may be truncated.</para>
    /// <para><b>Note:</b> This method is implemented on Android, iOS, Web, Linux (X11/Wayland), macOS, and Windows.</para>
    /// </summary>
    public static void TtsSpeak(string text, string voice, int volume = 50, float pitch = 1.0f, float rate = 1.0f, long utteranceId = (long)(0), bool interrupt = false)
    {
        NativeCalls.godot_icall_7_401(MethodBind56, GodotObject.GetPtr(Singleton), text, voice, volume, pitch, rate, utteranceId, interrupt.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind57 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.TtsPause, 3218959716ul);

    /// <summary>
    /// <para>Puts the synthesizer into a paused state.</para>
    /// <para><b>Note:</b> This method is implemented on Android, iOS, Web, Linux (X11/Wayland), macOS, and Windows.</para>
    /// </summary>
    public static void TtsPause()
    {
        NativeCalls.godot_icall_0_3(MethodBind57, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind58 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.TtsResume, 3218959716ul);

    /// <summary>
    /// <para>Resumes the synthesizer if it was paused.</para>
    /// <para><b>Note:</b> This method is implemented on Android, iOS, Web, Linux (X11/Wayland), macOS, and Windows.</para>
    /// </summary>
    public static void TtsResume()
    {
        NativeCalls.godot_icall_0_3(MethodBind58, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind59 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.TtsStop, 3218959716ul);

    /// <summary>
    /// <para>Stops synthesis in progress and removes all utterances from the queue.</para>
    /// <para><b>Note:</b> This method is implemented on Android, iOS, Web, Linux (X11/Wayland), macOS, and Windows.</para>
    /// </summary>
    public static void TtsStop()
    {
        NativeCalls.godot_icall_0_3(MethodBind59, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind60 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.TtsSetUtteranceCallback, 109679083ul);

    /// <summary>
    /// <para>Adds a callback, which is called when the utterance has started, finished, canceled or reached a text boundary.</para>
    /// <para>- <see cref="Godot.DisplayServer.TtsUtteranceEvent.Started"/>, <see cref="Godot.DisplayServer.TtsUtteranceEvent.Ended"/>, and <see cref="Godot.DisplayServer.TtsUtteranceEvent.Canceled"/> callable's method should take one <see cref="int"/> parameter, the utterance ID.</para>
    /// <para>- <see cref="Godot.DisplayServer.TtsUtteranceEvent.Boundary"/> callable's method should take two <see cref="int"/> parameters, the index of the character and the utterance ID.</para>
    /// <para><b>Note:</b> The granularity of the boundary callbacks is engine dependent.</para>
    /// <para><b>Note:</b> This method is implemented on Android, iOS, Web, Linux (X11/Wayland), macOS, and Windows.</para>
    /// </summary>
    public static void TtsSetUtteranceCallback(DisplayServer.TtsUtteranceEvent @event, Callable callable)
    {
        NativeCalls.godot_icall_2_402(MethodBind60, GodotObject.GetPtr(Singleton), (int)@event, callable);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind61 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.IsDarkModeSupported, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if OS supports dark mode.</para>
    /// <para><b>Note:</b> This method is implemented on Android, iOS, macOS, Windows, and Linux (X11/Wayland).</para>
    /// </summary>
    public static bool IsDarkModeSupported()
    {
        return NativeCalls.godot_icall_0_15(MethodBind61, GodotObject.GetPtr(Singleton)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind62 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.IsDarkMode, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if OS is using dark mode.</para>
    /// <para><b>Note:</b> This method is implemented on Android, iOS, macOS, Windows, and Linux (X11/Wayland).</para>
    /// </summary>
    public static bool IsDarkMode()
    {
        return NativeCalls.godot_icall_0_15(MethodBind62, GodotObject.GetPtr(Singleton)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind63 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAccentColor, 3444240500ul);

    /// <summary>
    /// <para>Returns OS theme accent color. Returns <c>Color(0, 0, 0, 0)</c>, if accent color is unknown.</para>
    /// <para><b>Note:</b> This method is implemented on macOS, Windows, Android, and Linux (X11/Wayland).</para>
    /// </summary>
    public static Color GetAccentColor()
    {
        return NativeCalls.godot_icall_0_214(MethodBind63, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind64 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBaseColor, 3444240500ul);

    /// <summary>
    /// <para>Returns the OS theme base color (default control background). Returns <c>Color(0, 0, 0, 0)</c> if the base color is unknown.</para>
    /// <para><b>Note:</b> This method is implemented on macOS, Windows, and Android.</para>
    /// </summary>
    public static Color GetBaseColor()
    {
        return NativeCalls.godot_icall_0_214(MethodBind64, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind65 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSystemThemeChangeCallback, 1611583062ul);

    /// <summary>
    /// <para>Sets the callback that should be called when the system's theme settings are changed. <paramref name="callable"/> should accept zero arguments.</para>
    /// <para><b>Note:</b> This method is implemented on Android, iOS, macOS, Windows, and Linux (X11/Wayland).</para>
    /// </summary>
    public static void SetSystemThemeChangeCallback(Callable callable)
    {
        NativeCalls.godot_icall_1_403(MethodBind65, GodotObject.GetPtr(Singleton), callable);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind66 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.MouseSetMode, 348288463ul);

    /// <summary>
    /// <para>Sets the current mouse mode. See also <see cref="Godot.DisplayServer.MouseGetMode()"/>.</para>
    /// </summary>
    public static void MouseSetMode(DisplayServer.MouseMode mouseMode)
    {
        NativeCalls.godot_icall_1_38(MethodBind66, GodotObject.GetPtr(Singleton), (int)mouseMode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind67 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.MouseGetMode, 1353961651ul);

    /// <summary>
    /// <para>Returns the current mouse mode. See also <see cref="Godot.DisplayServer.MouseSetMode(DisplayServer.MouseMode)"/>.</para>
    /// </summary>
    public static DisplayServer.MouseMode MouseGetMode()
    {
        return (DisplayServer.MouseMode)NativeCalls.godot_icall_0_39(MethodBind67, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind68 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.WarpMouse, 1130785943ul);

    /// <summary>
    /// <para>Sets the mouse cursor position to the given <paramref name="position"/> relative to an origin at the upper left corner of the currently focused game Window Manager window.</para>
    /// <para><b>Note:</b> <see cref="Godot.DisplayServer.WarpMouse(Vector2I)"/> is only supported on Windows, macOS, and Linux (X11/Wayland). It has no effect on Android, iOS, and Web.</para>
    /// </summary>
    public static unsafe void WarpMouse(Vector2I position)
    {
        NativeCalls.godot_icall_1_34(MethodBind68, GodotObject.GetPtr(Singleton), &position);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind69 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.MouseGetPosition, 3690982128ul);

    /// <summary>
    /// <para>Returns the mouse cursor's current position in screen coordinates.</para>
    /// </summary>
    public static Vector2I MouseGetPosition()
    {
        return NativeCalls.godot_icall_0_35(MethodBind69, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind70 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.MouseGetButtonState, 2512161324ul);

    /// <summary>
    /// <para>Returns the current state of mouse buttons (whether each button is pressed) as a bitmask. If multiple mouse buttons are pressed at the same time, the bits are added together. Equivalent to <see cref="Godot.Input.GetMouseButtonMask()"/>.</para>
    /// </summary>
    public static MouseButtonMask MouseGetButtonState()
    {
        return (MouseButtonMask)NativeCalls.godot_icall_0_39(MethodBind70, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind71 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ClipboardSet, 83702148ul);

    /// <summary>
    /// <para>Sets the user's clipboard content to the given string.</para>
    /// </summary>
    public static void ClipboardSet(string clipboard)
    {
        NativeCalls.godot_icall_1_57(MethodBind71, GodotObject.GetPtr(Singleton), clipboard);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind72 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ClipboardGet, 201670096ul);

    /// <summary>
    /// <para>Returns the user's clipboard as a string if possible.</para>
    /// </summary>
    public static string ClipboardGet()
    {
        return NativeCalls.godot_icall_0_58(MethodBind72, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind73 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ClipboardGetImage, 4190603485ul);

    /// <summary>
    /// <para>Returns the user's clipboard as an image if possible.</para>
    /// <para><b>Note:</b> This method uses the copied pixel data, e.g. from an image editing software or a web browser, not an image file copied from file explorer.</para>
    /// </summary>
    public static Image ClipboardGetImage()
    {
        return (Image)NativeCalls.godot_icall_0_63(MethodBind73, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind74 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ClipboardHas, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if there is a text content on the user's clipboard.</para>
    /// </summary>
    public static bool ClipboardHas()
    {
        return NativeCalls.godot_icall_0_15(MethodBind74, GodotObject.GetPtr(Singleton)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind75 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ClipboardHasImage, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if there is an image content on the user's clipboard.</para>
    /// </summary>
    public static bool ClipboardHasImage()
    {
        return NativeCalls.godot_icall_0_15(MethodBind75, GodotObject.GetPtr(Singleton)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind76 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ClipboardSetPrimary, 83702148ul);

    /// <summary>
    /// <para>Sets the user's <a href="https://unix.stackexchange.com/questions/139191/whats-the-difference-between-primary-selection-and-clipboard-buffer">primary</a> clipboard content to the given string. This is the clipboard that is set when the user selects text in any application, rather than when pressing Ctrl + C. The clipboard data can then be pasted by clicking the middle mouse button in any application that supports the primary clipboard mechanism.</para>
    /// <para><b>Note:</b> This method is only implemented on Linux (X11/Wayland).</para>
    /// </summary>
    public static void ClipboardSetPrimary(string clipboardPrimary)
    {
        NativeCalls.godot_icall_1_57(MethodBind76, GodotObject.GetPtr(Singleton), clipboardPrimary);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind77 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ClipboardGetPrimary, 201670096ul);

    /// <summary>
    /// <para>Returns the user's <a href="https://unix.stackexchange.com/questions/139191/whats-the-difference-between-primary-selection-and-clipboard-buffer">primary</a> clipboard as a string if possible. This is the clipboard that is set when the user selects text in any application, rather than when pressing Ctrl + C. The clipboard data can then be pasted by clicking the middle mouse button in any application that supports the primary clipboard mechanism.</para>
    /// <para><b>Note:</b> This method is only implemented on Linux (X11/Wayland).</para>
    /// </summary>
    public static string ClipboardGetPrimary()
    {
        return NativeCalls.godot_icall_0_58(MethodBind77, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind78 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDisplayCutouts, 3995934104ul);

    /// <summary>
    /// <para>Returns an <see cref="Godot.Collections.Array"/> of <see cref="Godot.Rect2"/>, each of which is the bounding rectangle for a display cutout or notch. These are non-functional areas on edge-to-edge screens used by cameras and sensors. Returns an empty array if the device does not have cutouts. See also <see cref="Godot.DisplayServer.GetDisplaySafeArea()"/>.</para>
    /// <para><b>Note:</b> Currently only implemented on Android. Other platforms will return an empty array even if they do have display cutouts or notches.</para>
    /// </summary>
    public static Godot.Collections.Array<Rect2> GetDisplayCutouts()
    {
        return new Godot.Collections.Array<Rect2>(NativeCalls.godot_icall_0_120(MethodBind78, GodotObject.GetPtr(Singleton)));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind79 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDisplaySafeArea, 410525958ul);

    /// <summary>
    /// <para>Returns the unobscured area of the display where interactive controls should be rendered. See also <see cref="Godot.DisplayServer.GetDisplayCutouts()"/>.</para>
    /// <para><b>Note:</b> Currently only implemented on Android and iOS. On other platforms, <c>screen_get_usable_rect(SCREEN_OF_MAIN_WINDOW)</c> will be returned as a fallback. See also <see cref="Godot.DisplayServer.ScreenGetUsableRect(int)"/>.</para>
    /// </summary>
    public static Rect2I GetDisplaySafeArea()
    {
        return NativeCalls.godot_icall_0_33(MethodBind79, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind80 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetScreenCount, 3905245786ul);

    /// <summary>
    /// <para>Returns the number of displays available.</para>
    /// <para><b>Note:</b> This method is implemented on Linux (X11 and Wayland), macOS, and Windows. On other platforms, this method always returns <c>1</c>.</para>
    /// </summary>
    public static int GetScreenCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind80, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind81 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPrimaryScreen, 3905245786ul);

    /// <summary>
    /// <para>Returns the index of the primary screen.</para>
    /// <para><b>Note:</b> This method is implemented on Linux/X11, macOS, and Windows. On other platforms, this method always returns <c>0</c>.</para>
    /// </summary>
    public static int GetPrimaryScreen()
    {
        return NativeCalls.godot_icall_0_39(MethodBind81, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind82 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetKeyboardFocusScreen, 3905245786ul);

    /// <summary>
    /// <para>Returns the index of the screen containing the window with the keyboard focus, or the primary screen if there's no focused window.</para>
    /// <para><b>Note:</b> This method is implemented on Linux/X11, macOS, and Windows. On other platforms, this method always returns the primary screen.</para>
    /// </summary>
    public static int GetKeyboardFocusScreen()
    {
        return NativeCalls.godot_icall_0_39(MethodBind82, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind83 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetScreenFromRect, 741354659ul);

    /// <summary>
    /// <para>Returns the index of the screen that overlaps the most with the given rectangle. Returns <see cref="Godot.DisplayServer.InvalidScreen"/> if the rectangle doesn't overlap with any screen or has no area.</para>
    /// </summary>
    public static unsafe int GetScreenFromRect(Rect2 rect)
    {
        return NativeCalls.godot_icall_1_404(MethodBind83, GodotObject.GetPtr(Singleton), &rect);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind84 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ScreenGetPosition, 1725937825ul);

    /// <summary>
    /// <para>Returns the screen's top-left corner position in pixels. Returns <c>Vector2i.ZERO</c> if <paramref name="screen"/> is invalid. On multi-monitor setups, the screen position is relative to the virtual desktop area. On multi-monitor setups with different screen resolutions or orientations, the origin might be located outside any display like this:</para>
    /// <para><code>
    /// * (0, 0)        +-------+
    ///                 |       |
    /// +-------------+ |       |
    /// |             | |       |
    /// |             | |       |
    /// +-------------+ +-------+
    /// </code></para>
    /// <para>See also <see cref="Godot.DisplayServer.ScreenGetSize(int)"/>.</para>
    /// <para><b>Note:</b> One of the following constants can be used as <paramref name="screen"/>: <see cref="Godot.DisplayServer.ScreenOfMainWindow"/>, <see cref="Godot.DisplayServer.ScreenPrimary"/>, <see cref="Godot.DisplayServer.ScreenWithMouseFocus"/>, or <see cref="Godot.DisplayServer.ScreenWithKeyboardFocus"/>.</para>
    /// </summary>
    public static Vector2I ScreenGetPosition(int screen = -1)
    {
        return NativeCalls.godot_icall_1_405(MethodBind84, GodotObject.GetPtr(Singleton), screen);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind85 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ScreenGetSize, 1725937825ul);

    /// <summary>
    /// <para>Returns the screen's size in pixels. See also <see cref="Godot.DisplayServer.ScreenGetPosition(int)"/> and <see cref="Godot.DisplayServer.ScreenGetUsableRect(int)"/>. Returns <c>Vector2i.ZERO</c> if <paramref name="screen"/> is invalid.</para>
    /// <para><b>Note:</b> One of the following constants can be used as <paramref name="screen"/>: <see cref="Godot.DisplayServer.ScreenOfMainWindow"/>, <see cref="Godot.DisplayServer.ScreenPrimary"/>, <see cref="Godot.DisplayServer.ScreenWithMouseFocus"/>, or <see cref="Godot.DisplayServer.ScreenWithKeyboardFocus"/>.</para>
    /// </summary>
    public static Vector2I ScreenGetSize(int screen = -1)
    {
        return NativeCalls.godot_icall_1_405(MethodBind85, GodotObject.GetPtr(Singleton), screen);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind86 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ScreenGetUsableRect, 2439012528ul);

    /// <summary>
    /// <para>Returns the portion of the screen that is not obstructed by a status bar in pixels. See also <see cref="Godot.DisplayServer.ScreenGetSize(int)"/>.</para>
    /// <para><b>Note:</b> One of the following constants can be used as <paramref name="screen"/>: <see cref="Godot.DisplayServer.ScreenOfMainWindow"/>, <see cref="Godot.DisplayServer.ScreenPrimary"/>, <see cref="Godot.DisplayServer.ScreenWithMouseFocus"/>, or <see cref="Godot.DisplayServer.ScreenWithKeyboardFocus"/>.</para>
    /// <para><b>Note:</b> This method is implemented on Linux/X11, macOS, and Windows. On other platforms, this method always returns <c>Rect2i(screen_get_position(screen), screen_get_size(screen))</c>.</para>
    /// </summary>
    public static Rect2I ScreenGetUsableRect(int screen = -1)
    {
        return NativeCalls.godot_icall_1_406(MethodBind86, GodotObject.GetPtr(Singleton), screen);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind87 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ScreenGetDpi, 181039630ul);

    /// <summary>
    /// <para>Returns the dots per inch density of the specified screen. Returns platform specific default value if <paramref name="screen"/> is invalid.</para>
    /// <para><b>Note:</b> One of the following constants can be used as <paramref name="screen"/>: <see cref="Godot.DisplayServer.ScreenOfMainWindow"/>, <see cref="Godot.DisplayServer.ScreenPrimary"/>, <see cref="Godot.DisplayServer.ScreenWithMouseFocus"/>, or <see cref="Godot.DisplayServer.ScreenWithKeyboardFocus"/>.</para>
    /// <para><b>Note:</b> On macOS, returned value is inaccurate if fractional display scaling mode is used.</para>
    /// <para><b>Note:</b> On Android devices, the actual screen densities are grouped into six generalized densities:</para>
    /// <para><code>
    ///    ldpi - 120 dpi
    ///    mdpi - 160 dpi
    ///    hdpi - 240 dpi
    ///   xhdpi - 320 dpi
    ///  xxhdpi - 480 dpi
    /// xxxhdpi - 640 dpi
    /// </code></para>
    /// <para><b>Note:</b> This method is implemented on Android, iOS, Linux (X11/Wayland), macOS, Web, and Windows. On other platforms, this method always returns <c>72</c>.</para>
    /// </summary>
    public static int ScreenGetDpi(int screen = -1)
    {
        return NativeCalls.godot_icall_1_60(MethodBind87, GodotObject.GetPtr(Singleton), screen);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind88 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ScreenGetScale, 909105437ul);

    /// <summary>
    /// <para>Returns the scale factor of the specified screen by index. Returns <c>1.0</c> if <paramref name="screen"/> is invalid.</para>
    /// <para><b>Note:</b> One of the following constants can be used as <paramref name="screen"/>: <see cref="Godot.DisplayServer.ScreenOfMainWindow"/>, <see cref="Godot.DisplayServer.ScreenPrimary"/>, <see cref="Godot.DisplayServer.ScreenWithMouseFocus"/>, or <see cref="Godot.DisplayServer.ScreenWithKeyboardFocus"/>.</para>
    /// <para><b>Note:</b> On macOS, the returned value is <c>2.0</c> for hiDPI (Retina) screens, and <c>1.0</c> for all other cases.</para>
    /// <para><b>Note:</b> On Linux (Wayland), the returned value is accurate only when <paramref name="screen"/> is <see cref="Godot.DisplayServer.ScreenOfMainWindow"/>. Due to API limitations, passing a direct index will return a rounded-up integer, if the screen has a fractional scale (e.g. <c>1.25</c> would get rounded up to <c>2.0</c>).</para>
    /// <para><b>Note:</b> This method is implemented on Android, iOS, Web, macOS, and Linux (Wayland). On other platforms, this method always returns <c>1.0</c>.</para>
    /// </summary>
    public static float ScreenGetScale(int screen = -1)
    {
        return NativeCalls.godot_icall_1_72(MethodBind88, GodotObject.GetPtr(Singleton), screen);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind89 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.IsTouchscreenAvailable, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if touch events are available (Android or iOS), the capability is detected on the Web platform or if <c>ProjectSettings.input_devices/pointing/emulate_touch_from_mouse</c> is <see langword="true"/>.</para>
    /// </summary>
    public static bool IsTouchscreenAvailable()
    {
        return NativeCalls.godot_icall_0_15(MethodBind89, GodotObject.GetPtr(Singleton)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind90 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ScreenGetMaxScale, 1740695150ul);

    /// <summary>
    /// <para>Returns the greatest scale factor of all screens.</para>
    /// <para><b>Note:</b> On macOS returned value is <c>2.0</c> if there is at least one hiDPI (Retina) screen in the system, and <c>1.0</c> in all other cases.</para>
    /// <para><b>Note:</b> This method is implemented only on macOS.</para>
    /// </summary>
    public static float ScreenGetMaxScale()
    {
        return NativeCalls.godot_icall_0_68(MethodBind90, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind91 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ScreenGetRefreshRate, 909105437ul);

    /// <summary>
    /// <para>Returns the current refresh rate of the specified screen. When V-Sync is enabled, this returns the maximum framerate the project can effectively reach. Returns <c>-1.0</c> if <paramref name="screen"/> is invalid or the <see cref="Godot.DisplayServer"/> fails to find the refresh rate for the specified screen.</para>
    /// <para>To fallback to a default refresh rate if the method fails, try:</para>
    /// <para><code>
    /// var refresh_rate = DisplayServer.screen_get_refresh_rate()
    /// if refresh_rate &lt; 0:
    /// 	refresh_rate = 60.0
    /// </code></para>
    /// <para><b>Note:</b> One of the following constants can be used as <paramref name="screen"/>: <see cref="Godot.DisplayServer.ScreenOfMainWindow"/>, <see cref="Godot.DisplayServer.ScreenPrimary"/>, <see cref="Godot.DisplayServer.ScreenWithMouseFocus"/>, or <see cref="Godot.DisplayServer.ScreenWithKeyboardFocus"/>.</para>
    /// <para><b>Note:</b> This method is implemented on Android, iOS, macOS, Linux (X11 and Wayland), and Windows. On other platforms, this method always returns <c>-1.0</c>.</para>
    /// </summary>
    public static float ScreenGetRefreshRate(int screen = -1)
    {
        return NativeCalls.godot_icall_1_72(MethodBind91, GodotObject.GetPtr(Singleton), screen);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind92 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ScreenGetPixel, 1532707496ul);

    /// <summary>
    /// <para>Returns the color of the pixel at the given screen <paramref name="position"/>. On multi-monitor setups, the screen position is relative to the virtual desktop area.</para>
    /// <para><b>Note:</b> This method is implemented on Linux (X11, excluding XWayland), macOS, and Windows. On other platforms, this method always returns <c>Color(0, 0, 0, 1)</c>.</para>
    /// <para><b>Note:</b> On macOS, this method requires the "Screen Recording" permission. If permission is not granted, this method returns a color from a screenshot that will not include other application windows or OS elements not related to the application.</para>
    /// </summary>
    public static unsafe Color ScreenGetPixel(Vector2I position)
    {
        return NativeCalls.godot_icall_1_407(MethodBind92, GodotObject.GetPtr(Singleton), &position);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind93 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ScreenGetImage, 3813388802ul);

    /// <summary>
    /// <para>Returns a screenshot of the <paramref name="screen"/>. Returns <see langword="null"/> if <paramref name="screen"/> is invalid or the <see cref="Godot.DisplayServer"/> fails to capture screenshot.</para>
    /// <para><b>Note:</b> One of the following constants can be used as <paramref name="screen"/>: <see cref="Godot.DisplayServer.ScreenOfMainWindow"/>, <see cref="Godot.DisplayServer.ScreenPrimary"/>, <see cref="Godot.DisplayServer.ScreenWithMouseFocus"/>, or <see cref="Godot.DisplayServer.ScreenWithKeyboardFocus"/>.</para>
    /// <para><b>Note:</b> This method is implemented on Linux (X11, excluding XWayland), macOS, and Windows. On other platforms, this method always returns <see langword="null"/>.</para>
    /// <para><b>Note:</b> On macOS, this method requires the "Screen Recording" permission. If permission is not granted, this method returns a screenshot that will not include other application windows or OS elements not related to the application.</para>
    /// </summary>
    public static Image ScreenGetImage(int screen = -1)
    {
        return (Image)NativeCalls.godot_icall_1_71(MethodBind93, GodotObject.GetPtr(Singleton), screen);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind94 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ScreenGetImageRect, 2601441065ul);

    /// <summary>
    /// <para>Returns a screenshot of the screen region defined by <paramref name="rect"/>. Returns <see langword="null"/> if <paramref name="rect"/> is outside screen bounds or the <see cref="Godot.DisplayServer"/> fails to capture screenshot.</para>
    /// <para><b>Note:</b> This method is implemented on macOS and Windows. On other platforms, this method always returns <see langword="null"/>.</para>
    /// <para><b>Note:</b> On macOS, this method requires the "Screen Recording" permission. If permission is not granted, this method returns a screenshot that will not include other application windows or OS elements not related to the application.</para>
    /// </summary>
    public static unsafe Image ScreenGetImageRect(Rect2I rect)
    {
        return (Image)NativeCalls.godot_icall_1_408(MethodBind94, GodotObject.GetPtr(Singleton), &rect);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind95 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ScreenSetOrientation, 2211511631ul);

    /// <summary>
    /// <para>Sets the <paramref name="screen"/>'s <paramref name="orientation"/>. See also <see cref="Godot.DisplayServer.ScreenGetOrientation(int)"/>.</para>
    /// <para><b>Note:</b> One of the following constants can be used as <paramref name="screen"/>: <see cref="Godot.DisplayServer.ScreenOfMainWindow"/>, <see cref="Godot.DisplayServer.ScreenPrimary"/>, <see cref="Godot.DisplayServer.ScreenWithMouseFocus"/>, or <see cref="Godot.DisplayServer.ScreenWithKeyboardFocus"/>.</para>
    /// <para><b>Note:</b> This method is implemented on Android and iOS.</para>
    /// <para><b>Note:</b> On iOS, this method has no effect if <c>ProjectSettings.display/window/handheld/orientation</c> is not set to <see cref="Godot.DisplayServer.ScreenOrientation.Sensor"/>.</para>
    /// </summary>
    public static void ScreenSetOrientation(DisplayServer.ScreenOrientation orientation, int screen = -1)
    {
        NativeCalls.godot_icall_2_59(MethodBind95, GodotObject.GetPtr(Singleton), (int)orientation, screen);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind96 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ScreenGetOrientation, 133818562ul);

    /// <summary>
    /// <para>Returns the <paramref name="screen"/>'s current orientation. See also <see cref="Godot.DisplayServer.ScreenSetOrientation(DisplayServer.ScreenOrientation, int)"/>. Returns <see cref="Godot.DisplayServer.ScreenOrientation.Landscape"/> if <paramref name="screen"/> is invalid.</para>
    /// <para><b>Note:</b> One of the following constants can be used as <paramref name="screen"/>: <see cref="Godot.DisplayServer.ScreenOfMainWindow"/>, <see cref="Godot.DisplayServer.ScreenPrimary"/>, <see cref="Godot.DisplayServer.ScreenWithMouseFocus"/>, or <see cref="Godot.DisplayServer.ScreenWithKeyboardFocus"/>.</para>
    /// <para><b>Note:</b> This method is implemented on Android and iOS. On other platforms, this method always returns <see cref="Godot.DisplayServer.ScreenOrientation.Landscape"/>.</para>
    /// </summary>
    public static DisplayServer.ScreenOrientation ScreenGetOrientation(int screen = -1)
    {
        return (DisplayServer.ScreenOrientation)NativeCalls.godot_icall_1_60(MethodBind96, GodotObject.GetPtr(Singleton), screen);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind97 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ScreenSetKeepOn, 2586408642ul);

    /// <summary>
    /// <para>Sets whether the screen should never be turned off by the operating system's power-saving measures. See also <see cref="Godot.DisplayServer.ScreenIsKeptOn()"/>.</para>
    /// </summary>
    public static void ScreenSetKeepOn(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind97, GodotObject.GetPtr(Singleton), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind98 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ScreenIsKeptOn, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the screen should never be turned off by the operating system's power-saving measures. See also <see cref="Godot.DisplayServer.ScreenSetKeepOn(bool)"/>.</para>
    /// </summary>
    public static bool ScreenIsKeptOn()
    {
        return NativeCalls.godot_icall_0_15(MethodBind98, GodotObject.GetPtr(Singleton)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind99 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetWindowList, 1930428628ul);

    /// <summary>
    /// <para>Returns the list of Godot window IDs belonging to this process.</para>
    /// <para><b>Note:</b> Native dialogs are not included in this list.</para>
    /// </summary>
    public static int[] GetWindowList()
    {
        return NativeCalls.godot_icall_0_151(MethodBind99, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind100 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetWindowAtScreenPosition, 2485466453ul);

    /// <summary>
    /// <para>Returns the ID of the window at the specified screen <paramref name="position"/> (in pixels). On multi-monitor setups, the screen position is relative to the virtual desktop area. On multi-monitor setups with different screen resolutions or orientations, the origin may be located outside any display like this:</para>
    /// <para><code>
    /// * (0, 0)        +-------+
    ///                 |       |
    /// +-------------+ |       |
    /// |             | |       |
    /// |             | |       |
    /// +-------------+ +-------+
    /// </code></para>
    /// </summary>
    public static unsafe int GetWindowAtScreenPosition(Vector2I position)
    {
        return NativeCalls.godot_icall_1_409(MethodBind100, GodotObject.GetPtr(Singleton), &position);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind101 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.WindowGetNativeHandle, 1096425680ul);

    /// <summary>
    /// <para>Returns internal structure pointers for use in plugins.</para>
    /// <para><b>Note:</b> This method is implemented on Android, Linux (X11/Wayland), macOS, and Windows.</para>
    /// </summary>
    public static long WindowGetNativeHandle(DisplayServer.HandleType handleType, int windowId = 0)
    {
        return NativeCalls.godot_icall_2_410(MethodBind101, GodotObject.GetPtr(Singleton), (int)handleType, windowId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind102 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.WindowGetActivePopup, 3905245786ul);

    /// <summary>
    /// <para>Returns ID of the active popup window, or <see cref="Godot.DisplayServer.InvalidWindowId"/> if there is none.</para>
    /// </summary>
    public static int WindowGetActivePopup()
    {
        return NativeCalls.godot_icall_0_39(MethodBind102, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind103 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.WindowSetPopupSafeRect, 3317281434ul);

    /// <summary>
    /// <para>Sets the bounding box of control, or menu item that was used to open the popup window, in the screen coordinate system. Clicking this area will not auto-close this popup.</para>
    /// </summary>
    public static unsafe void WindowSetPopupSafeRect(int window, Rect2I rect)
    {
        NativeCalls.godot_icall_2_216(MethodBind103, GodotObject.GetPtr(Singleton), window, &rect);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind104 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.WindowGetPopupSafeRect, 2161169500ul);

    /// <summary>
    /// <para>Returns the bounding box of control, or menu item that was used to open the popup window, in the screen coordinate system.</para>
    /// </summary>
    public static Rect2I WindowGetPopupSafeRect(int window)
    {
        return NativeCalls.godot_icall_1_406(MethodBind104, GodotObject.GetPtr(Singleton), window);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind105 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.WindowSetTitle, 441246282ul);

    /// <summary>
    /// <para>Sets the title of the given window to <paramref name="title"/>.</para>
    /// <para><b>Note:</b> It's recommended to change this value using <see cref="Godot.Window.Title"/> instead.</para>
    /// <para><b>Note:</b> Avoid changing the window title every frame, as this can cause performance issues on certain window managers. Try to change the window title only a few times per second at most.</para>
    /// </summary>
    public static void WindowSetTitle(string title, int windowId = 0)
    {
        NativeCalls.godot_icall_2_400(MethodBind105, GodotObject.GetPtr(Singleton), title, windowId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind106 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.WindowGetTitleSize, 2925301799ul);

    /// <summary>
    /// <para>Returns the estimated window title bar size (including text and window buttons) for the window specified by <paramref name="windowId"/> (in pixels). This method does not change the window title.</para>
    /// <para><b>Note:</b> This method is implemented on macOS and Windows.</para>
    /// </summary>
    public static Vector2I WindowGetTitleSize(string title, int windowId = 0)
    {
        return NativeCalls.godot_icall_2_411(MethodBind106, GodotObject.GetPtr(Singleton), title, windowId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind107 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.WindowSetMousePassthrough, 1993637420ul);

    /// <summary>
    /// <para>Sets a polygonal region of the window which accepts mouse events. Mouse events outside the region will be passed through.</para>
    /// <para>Passing an empty array will disable passthrough support (all mouse events will be intercepted by the window, which is the default behavior).</para>
    /// <para><code>
    /// // Set region, using Path2D node.
    /// DisplayServer.WindowSetMousePassthrough(GetNode&lt;Path2D&gt;("Path2D").Curve.GetBakedPoints());
    /// 
    /// // Set region, using Polygon2D node.
    /// DisplayServer.WindowSetMousePassthrough(GetNode&lt;Polygon2D&gt;("Polygon2D").Polygon);
    /// 
    /// // Reset region to default.
    /// DisplayServer.WindowSetMousePassthrough([]);
    /// </code></para>
    /// <para><b>Note:</b> On Windows, the portion of a window that lies outside the region is not drawn, while on Linux (X11) and macOS it is.</para>
    /// <para><b>Note:</b> This method is implemented on Linux (X11), macOS and Windows.</para>
    /// </summary>
    public static void WindowSetMousePassthrough(Vector2[] region, int windowId = 0)
    {
        NativeCalls.godot_icall_2_412(MethodBind107, GodotObject.GetPtr(Singleton), region, windowId);
    }

    /// <summary>
    /// <para>Sets a polygonal region of the window which accepts mouse events. Mouse events outside the region will be passed through.</para>
    /// <para>Passing an empty array will disable passthrough support (all mouse events will be intercepted by the window, which is the default behavior).</para>
    /// <para><code>
    /// // Set region, using Path2D node.
    /// DisplayServer.WindowSetMousePassthrough(GetNode&lt;Path2D&gt;("Path2D").Curve.GetBakedPoints());
    /// 
    /// // Set region, using Polygon2D node.
    /// DisplayServer.WindowSetMousePassthrough(GetNode&lt;Polygon2D&gt;("Polygon2D").Polygon);
    /// 
    /// // Reset region to default.
    /// DisplayServer.WindowSetMousePassthrough([]);
    /// </code></para>
    /// <para><b>Note:</b> On Windows, the portion of a window that lies outside the region is not drawn, while on Linux (X11) and macOS it is.</para>
    /// <para><b>Note:</b> This method is implemented on Linux (X11), macOS and Windows.</para>
    /// </summary>
    public static void WindowSetMousePassthrough(ReadOnlySpan<Vector2> region, int windowId)
    {
        NativeCalls.godot_icall_2_412(MethodBind107, GodotObject.GetPtr(Singleton), region, windowId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind108 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.WindowGetCurrentScreen, 1591665591ul);

    /// <summary>
    /// <para>Returns the screen the window specified by <paramref name="windowId"/> is currently positioned on. If the screen overlaps multiple displays, the screen where the window's center is located is returned. See also <see cref="Godot.DisplayServer.WindowSetCurrentScreen(int, int)"/>. Returns <see cref="Godot.DisplayServer.InvalidScreen"/> if <paramref name="windowId"/> is invalid.</para>
    /// <para><b>Note:</b> This method is implemented on Linux/X11, macOS, and Windows. On other platforms, this method always returns <c>0</c>.</para>
    /// </summary>
    public static int WindowGetCurrentScreen(int windowId = 0)
    {
        return NativeCalls.godot_icall_1_60(MethodBind108, GodotObject.GetPtr(Singleton), windowId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind109 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.WindowSetCurrentScreen, 2230941749ul);

    /// <summary>
    /// <para>Moves the window specified by <paramref name="windowId"/> to the specified <paramref name="screen"/>. See also <see cref="Godot.DisplayServer.WindowGetCurrentScreen(int)"/>.</para>
    /// <para><b>Note:</b> One of the following constants can be used as <paramref name="screen"/>: <see cref="Godot.DisplayServer.ScreenOfMainWindow"/>, <see cref="Godot.DisplayServer.ScreenPrimary"/>, <see cref="Godot.DisplayServer.ScreenWithMouseFocus"/>, or <see cref="Godot.DisplayServer.ScreenWithKeyboardFocus"/>.</para>
    /// <para><b>Note:</b> This method is implemented on Linux/X11, macOS, and Windows.</para>
    /// </summary>
    public static void WindowSetCurrentScreen(int screen, int windowId = 0)
    {
        NativeCalls.godot_icall_2_59(MethodBind109, GodotObject.GetPtr(Singleton), screen, windowId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind110 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.WindowGetPosition, 763922886ul);

    /// <summary>
    /// <para>Returns the position of the client area of the given window on the screen.</para>
    /// </summary>
    public static Vector2I WindowGetPosition(int windowId = 0)
    {
        return NativeCalls.godot_icall_1_405(MethodBind110, GodotObject.GetPtr(Singleton), windowId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind111 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.WindowGetPositionWithDecorations, 763922886ul);

    /// <summary>
    /// <para>Returns the position of the given window on the screen including the borders drawn by the operating system. See also <see cref="Godot.DisplayServer.WindowGetPosition(int)"/>.</para>
    /// </summary>
    public static Vector2I WindowGetPositionWithDecorations(int windowId = 0)
    {
        return NativeCalls.godot_icall_1_405(MethodBind111, GodotObject.GetPtr(Singleton), windowId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind112 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.WindowSetPosition, 2019273902ul);

    /// <summary>
    /// <para>Sets the position of the given window to <paramref name="position"/>. On multi-monitor setups, the screen position is relative to the virtual desktop area. On multi-monitor setups with different screen resolutions or orientations, the origin may be located outside any display like this:</para>
    /// <para><code>
    /// * (0, 0)        +-------+
    ///                 |       |
    /// +-------------+ |       |
    /// |             | |       |
    /// |             | |       |
    /// +-------------+ +-------+
    /// </code></para>
    /// <para>See also <see cref="Godot.DisplayServer.WindowGetPosition(int)"/> and <see cref="Godot.DisplayServer.WindowSetSize(Vector2I, int)"/>.</para>
    /// <para><b>Note:</b> It's recommended to change this value using <see cref="Godot.Window.Position"/> instead.</para>
    /// <para><b>Note:</b> On Linux (Wayland): this method is a no-op.</para>
    /// </summary>
    public static unsafe void WindowSetPosition(Vector2I position, int windowId = 0)
    {
        NativeCalls.godot_icall_2_413(MethodBind112, GodotObject.GetPtr(Singleton), &position, windowId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind113 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.WindowGetSize, 763922886ul);

    /// <summary>
    /// <para>Returns the size of the window specified by <paramref name="windowId"/> (in pixels), excluding the borders drawn by the operating system. This is also called the "client area". See also <see cref="Godot.DisplayServer.WindowGetSizeWithDecorations(int)"/>, <see cref="Godot.DisplayServer.WindowSetSize(Vector2I, int)"/> and <see cref="Godot.DisplayServer.WindowGetPosition(int)"/>.</para>
    /// </summary>
    public static Vector2I WindowGetSize(int windowId = 0)
    {
        return NativeCalls.godot_icall_1_405(MethodBind113, GodotObject.GetPtr(Singleton), windowId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind114 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.WindowSetSize, 2019273902ul);

    /// <summary>
    /// <para>Sets the size of the given window to <paramref name="size"/> (in pixels). See also <see cref="Godot.DisplayServer.WindowGetSize(int)"/> and <see cref="Godot.DisplayServer.WindowGetPosition(int)"/>.</para>
    /// <para><b>Note:</b> It's recommended to change this value using <see cref="Godot.Window.Size"/> instead.</para>
    /// </summary>
    public static unsafe void WindowSetSize(Vector2I size, int windowId = 0)
    {
        NativeCalls.godot_icall_2_413(MethodBind114, GodotObject.GetPtr(Singleton), &size, windowId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind115 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.WindowSetRectChangedCallback, 1091192925ul);

    /// <summary>
    /// <para>Sets the <paramref name="callback"/> that will be called when the window specified by <paramref name="windowId"/> is moved or resized.</para>
    /// <para><b>Warning:</b> Advanced users only! Adding such a callback to a <see cref="Godot.Window"/> node will override its default implementation, which can introduce bugs.</para>
    /// </summary>
    public static void WindowSetRectChangedCallback(Callable callback, int windowId = 0)
    {
        NativeCalls.godot_icall_2_414(MethodBind115, GodotObject.GetPtr(Singleton), callback, windowId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind116 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.WindowSetWindowEventCallback, 1091192925ul);

    /// <summary>
    /// <para>Sets the <paramref name="callback"/> that will be called when an event occurs in the window specified by <paramref name="windowId"/>.</para>
    /// <para><b>Warning:</b> Advanced users only! Adding such a callback to a <see cref="Godot.Window"/> node will override its default implementation, which can introduce bugs.</para>
    /// </summary>
    public static void WindowSetWindowEventCallback(Callable callback, int windowId = 0)
    {
        NativeCalls.godot_icall_2_414(MethodBind116, GodotObject.GetPtr(Singleton), callback, windowId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind117 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.WindowSetInputEventCallback, 1091192925ul);

    /// <summary>
    /// <para>Sets the <paramref name="callback"/> that should be called when any <see cref="Godot.InputEvent"/> is sent to the window specified by <paramref name="windowId"/>.</para>
    /// <para><b>Warning:</b> Advanced users only! Adding such a callback to a <see cref="Godot.Window"/> node will override its default implementation, which can introduce bugs.</para>
    /// </summary>
    public static void WindowSetInputEventCallback(Callable callback, int windowId = 0)
    {
        NativeCalls.godot_icall_2_414(MethodBind117, GodotObject.GetPtr(Singleton), callback, windowId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind118 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.WindowSetInputTextCallback, 1091192925ul);

    /// <summary>
    /// <para>Sets the <paramref name="callback"/> that should be called when text is entered using the virtual keyboard to the window specified by <paramref name="windowId"/>.</para>
    /// <para><b>Warning:</b> Advanced users only! Adding such a callback to a <see cref="Godot.Window"/> node will override its default implementation, which can introduce bugs.</para>
    /// </summary>
    public static void WindowSetInputTextCallback(Callable callback, int windowId = 0)
    {
        NativeCalls.godot_icall_2_414(MethodBind118, GodotObject.GetPtr(Singleton), callback, windowId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind119 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.WindowSetDropFilesCallback, 1091192925ul);

    /// <summary>
    /// <para>Sets the <paramref name="callback"/> that should be called when files are dropped from the operating system's file manager to the window specified by <paramref name="windowId"/>. <paramref name="callback"/> should take one <see cref="string"/>[] argument, which is the list of dropped files.</para>
    /// <para><b>Warning:</b> Advanced users only! Adding such a callback to a <see cref="Godot.Window"/> node will override its default implementation, which can introduce bugs.</para>
    /// <para><b>Note:</b> This method is implemented on Windows, macOS, Linux (X11/Wayland), and Web.</para>
    /// </summary>
    public static void WindowSetDropFilesCallback(Callable callback, int windowId = 0)
    {
        NativeCalls.godot_icall_2_414(MethodBind119, GodotObject.GetPtr(Singleton), callback, windowId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind120 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.WindowGetAttachedInstanceId, 1591665591ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.GodotObject.GetInstanceId()"/> of the <see cref="Godot.Window"/> the <paramref name="windowId"/> is attached to.</para>
    /// </summary>
    public static ulong WindowGetAttachedInstanceId(int windowId = 0)
    {
        return NativeCalls.godot_icall_1_240(MethodBind120, GodotObject.GetPtr(Singleton), windowId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind121 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.WindowGetMaxSize, 763922886ul);

    /// <summary>
    /// <para>Returns the window's maximum size (in pixels). See also <see cref="Godot.DisplayServer.WindowSetMaxSize(Vector2I, int)"/>.</para>
    /// </summary>
    public static Vector2I WindowGetMaxSize(int windowId = 0)
    {
        return NativeCalls.godot_icall_1_405(MethodBind121, GodotObject.GetPtr(Singleton), windowId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind122 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.WindowSetMaxSize, 2019273902ul);

    /// <summary>
    /// <para>Sets the maximum size of the window specified by <paramref name="windowId"/> in pixels. Normally, the user will not be able to drag the window to make it larger than the specified size. See also <see cref="Godot.DisplayServer.WindowGetMaxSize(int)"/>.</para>
    /// <para><b>Note:</b> It's recommended to change this value using <see cref="Godot.Window.MaxSize"/> instead.</para>
    /// <para><b>Note:</b> Using third-party tools, it is possible for users to disable window geometry restrictions and therefore bypass this limit.</para>
    /// </summary>
    public static unsafe void WindowSetMaxSize(Vector2I maxSize, int windowId = 0)
    {
        NativeCalls.godot_icall_2_413(MethodBind122, GodotObject.GetPtr(Singleton), &maxSize, windowId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind123 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.WindowGetMinSize, 763922886ul);

    /// <summary>
    /// <para>Returns the window's minimum size (in pixels). See also <see cref="Godot.DisplayServer.WindowSetMinSize(Vector2I, int)"/>.</para>
    /// </summary>
    public static Vector2I WindowGetMinSize(int windowId = 0)
    {
        return NativeCalls.godot_icall_1_405(MethodBind123, GodotObject.GetPtr(Singleton), windowId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind124 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.WindowSetMinSize, 2019273902ul);

    /// <summary>
    /// <para>Sets the minimum size for the given window to <paramref name="minSize"/> in pixels. Normally, the user will not be able to drag the window to make it smaller than the specified size. See also <see cref="Godot.DisplayServer.WindowGetMinSize(int)"/>.</para>
    /// <para><b>Note:</b> It's recommended to change this value using <see cref="Godot.Window.MinSize"/> instead.</para>
    /// <para><b>Note:</b> By default, the main window has a minimum size of <c>Vector2i(64, 64)</c>. This prevents issues that can arise when the window is resized to a near-zero size.</para>
    /// <para><b>Note:</b> Using third-party tools, it is possible for users to disable window geometry restrictions and therefore bypass this limit.</para>
    /// </summary>
    public static unsafe void WindowSetMinSize(Vector2I minSize, int windowId = 0)
    {
        NativeCalls.godot_icall_2_413(MethodBind124, GodotObject.GetPtr(Singleton), &minSize, windowId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind125 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.WindowGetSizeWithDecorations, 763922886ul);

    /// <summary>
    /// <para>Returns the size of the window specified by <paramref name="windowId"/> (in pixels), including the borders drawn by the operating system. See also <see cref="Godot.DisplayServer.WindowGetSize(int)"/>.</para>
    /// </summary>
    public static Vector2I WindowGetSizeWithDecorations(int windowId = 0)
    {
        return NativeCalls.godot_icall_1_405(MethodBind125, GodotObject.GetPtr(Singleton), windowId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind126 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.WindowGetMode, 2185728461ul);

    /// <summary>
    /// <para>Returns the mode of the given window.</para>
    /// </summary>
    public static DisplayServer.WindowMode WindowGetMode(int windowId = 0)
    {
        return (DisplayServer.WindowMode)NativeCalls.godot_icall_1_60(MethodBind126, GodotObject.GetPtr(Singleton), windowId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind127 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.WindowSetMode, 1319965401ul);

    /// <summary>
    /// <para>Sets window mode for the given window to <paramref name="mode"/>.</para>
    /// <para><b>Note:</b> On Android, setting it to <see cref="Godot.DisplayServer.WindowMode.Fullscreen"/> or <see cref="Godot.DisplayServer.WindowMode.ExclusiveFullscreen"/> will enable immersive mode.</para>
    /// <para><b>Note:</b> Setting the window to full screen forcibly sets the borderless flag to <see langword="true"/>, so make sure to set it back to <see langword="false"/> when not wanted.</para>
    /// </summary>
    public static void WindowSetMode(DisplayServer.WindowMode mode, int windowId = 0)
    {
        NativeCalls.godot_icall_2_59(MethodBind127, GodotObject.GetPtr(Singleton), (int)mode, windowId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind128 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.WindowSetFlag, 254894155ul);

    /// <summary>
    /// <para>Enables or disables the given window's given <paramref name="flag"/>.</para>
    /// </summary>
    public static void WindowSetFlag(DisplayServer.WindowFlags flag, bool enabled, int windowId = 0)
    {
        NativeCalls.godot_icall_3_415(MethodBind128, GodotObject.GetPtr(Singleton), (int)flag, enabled.ToGodotBool(), windowId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind129 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.WindowGetFlag, 802816991ul);

    /// <summary>
    /// <para>Returns the current value of the given window's <paramref name="flag"/>.</para>
    /// </summary>
    public static bool WindowGetFlag(DisplayServer.WindowFlags flag, int windowId = 0)
    {
        return NativeCalls.godot_icall_2_40(MethodBind129, GodotObject.GetPtr(Singleton), (int)flag, windowId).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind130 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.WindowSetWindowButtonsOffset, 2019273902ul);

    /// <summary>
    /// <para>When <see cref="Godot.DisplayServer.WindowFlags.ExtendToTitle"/> flag is set, set offset to the center of the first titlebar button.</para>
    /// <para><b>Note:</b> This flag is implemented only on macOS.</para>
    /// </summary>
    public static unsafe void WindowSetWindowButtonsOffset(Vector2I offset, int windowId = 0)
    {
        NativeCalls.godot_icall_2_413(MethodBind130, GodotObject.GetPtr(Singleton), &offset, windowId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind131 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.WindowGetSafeTitleMargins, 2295066620ul);

    /// <summary>
    /// <para>Returns left margins (<c>x</c>), right margins (<c>y</c>) and height (<c>z</c>) of the title that are safe to use (contains no buttons or other elements) when <see cref="Godot.DisplayServer.WindowFlags.ExtendToTitle"/> flag is set.</para>
    /// </summary>
    public static Vector3I WindowGetSafeTitleMargins(int windowId = 0)
    {
        return NativeCalls.godot_icall_1_416(MethodBind131, GodotObject.GetPtr(Singleton), windowId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind132 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.WindowRequestAttention, 1995695955ul);

    /// <summary>
    /// <para>Makes the window specified by <paramref name="windowId"/> request attention, which is materialized by the window title and taskbar entry blinking until the window is focused. This usually has no visible effect if the window is currently focused. The exact behavior varies depending on the operating system.</para>
    /// </summary>
    public static void WindowRequestAttention(int windowId = 0)
    {
        NativeCalls.godot_icall_1_38(MethodBind132, GodotObject.GetPtr(Singleton), windowId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind133 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.WindowMoveToForeground, 1995695955ul);

    /// <summary>
    /// <para>Moves the window specified by <paramref name="windowId"/> to the foreground, so that it is visible over other windows.</para>
    /// </summary>
    public static void WindowMoveToForeground(int windowId = 0)
    {
        NativeCalls.godot_icall_1_38(MethodBind133, GodotObject.GetPtr(Singleton), windowId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind134 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.WindowIsFocused, 1051549951ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the window specified by <paramref name="windowId"/> is focused.</para>
    /// </summary>
    public static bool WindowIsFocused(int windowId = 0)
    {
        return NativeCalls.godot_icall_1_62(MethodBind134, GodotObject.GetPtr(Singleton), windowId).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind135 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.WindowCanDraw, 1051549951ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if anything can be drawn in the window specified by <paramref name="windowId"/>, <see langword="false"/> otherwise. Using the <c>--disable-render-loop</c> command line argument or a headless build will return <see langword="false"/>.</para>
    /// </summary>
    public static bool WindowCanDraw(int windowId = 0)
    {
        return NativeCalls.godot_icall_1_62(MethodBind135, GodotObject.GetPtr(Singleton), windowId).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind136 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.WindowSetTransient, 3937882851ul);

    /// <summary>
    /// <para>Sets window transient parent. Transient window will be destroyed with its transient parent and will return focus to their parent when closed. The transient window is displayed on top of a non-exclusive full-screen parent window. Transient windows can't enter full-screen mode.</para>
    /// <para><b>Note:</b> It's recommended to change this value using <see cref="Godot.Window.Transient"/> instead.</para>
    /// <para><b>Note:</b> The behavior might be different depending on the platform.</para>
    /// </summary>
    public static void WindowSetTransient(int windowId, int parentWindowId)
    {
        NativeCalls.godot_icall_2_59(MethodBind136, GodotObject.GetPtr(Singleton), windowId, parentWindowId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind137 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.WindowSetExclusive, 300928843ul);

    /// <summary>
    /// <para>If set to <see langword="true"/>, this window will always stay on top of its parent window, parent window will ignore input while this window is opened.</para>
    /// <para><b>Note:</b> On macOS, exclusive windows are confined to the same space (virtual desktop or screen) as the parent window.</para>
    /// <para><b>Note:</b> This method is implemented on macOS and Windows.</para>
    /// </summary>
    public static void WindowSetExclusive(int windowId, bool exclusive)
    {
        NativeCalls.godot_icall_2_61(MethodBind137, GodotObject.GetPtr(Singleton), windowId, exclusive.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind138 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.WindowSetImeActive, 1661950165ul);

    /// <summary>
    /// <para>Sets whether <a href="https://en.wikipedia.org/wiki/Input_method">Input Method Editor</a> should be enabled for the window specified by <paramref name="windowId"/>. See also <see cref="Godot.DisplayServer.WindowSetImePosition(Vector2I, int)"/>.</para>
    /// </summary>
    public static void WindowSetImeActive(bool active, int windowId = 0)
    {
        NativeCalls.godot_icall_2_417(MethodBind138, GodotObject.GetPtr(Singleton), active.ToGodotBool(), windowId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind139 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.WindowSetImePosition, 2019273902ul);

    /// <summary>
    /// <para>Sets the position of the <a href="https://en.wikipedia.org/wiki/Input_method">Input Method Editor</a> popup for the specified <paramref name="windowId"/>. Only effective if <see cref="Godot.DisplayServer.WindowSetImeActive(bool, int)"/> was set to <see langword="true"/> for the specified <paramref name="windowId"/>.</para>
    /// </summary>
    public static unsafe void WindowSetImePosition(Vector2I position, int windowId = 0)
    {
        NativeCalls.godot_icall_2_413(MethodBind139, GodotObject.GetPtr(Singleton), &position, windowId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind140 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.WindowSetVsyncMode, 2179333492ul);

    /// <summary>
    /// <para>Sets the V-Sync mode of the given window. See also <c>ProjectSettings.display/window/vsync/vsync_mode</c>.</para>
    /// <para>Depending on the platform and used renderer, the engine will fall back to <see cref="Godot.DisplayServer.VSyncMode.Enabled"/> if the desired mode is not supported.</para>
    /// <para><b>Note:</b> V-Sync modes other than <see cref="Godot.DisplayServer.VSyncMode.Enabled"/> are only supported in the Forward+ and Mobile rendering methods, not Compatibility.</para>
    /// </summary>
    public static void WindowSetVsyncMode(DisplayServer.VSyncMode vsyncMode, int windowId = 0)
    {
        NativeCalls.godot_icall_2_59(MethodBind140, GodotObject.GetPtr(Singleton), (int)vsyncMode, windowId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind141 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.WindowGetVsyncMode, 578873795ul);

    /// <summary>
    /// <para>Returns the V-Sync mode of the given window.</para>
    /// </summary>
    public static DisplayServer.VSyncMode WindowGetVsyncMode(int windowId = 0)
    {
        return (DisplayServer.VSyncMode)NativeCalls.godot_icall_1_60(MethodBind141, GodotObject.GetPtr(Singleton), windowId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind142 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.WindowIsMaximizeAllowed, 1051549951ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the given window can be maximized (the maximize button is enabled).</para>
    /// </summary>
    public static bool WindowIsMaximizeAllowed(int windowId = 0)
    {
        return NativeCalls.godot_icall_1_62(MethodBind142, GodotObject.GetPtr(Singleton), windowId).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind143 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.WindowMaximizeOnTitleDblClick, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if double-clicking on a window's title should maximize it.</para>
    /// <para><b>Note:</b> This method is implemented only on macOS.</para>
    /// </summary>
    public static bool WindowMaximizeOnTitleDblClick()
    {
        return NativeCalls.godot_icall_0_15(MethodBind143, GodotObject.GetPtr(Singleton)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind144 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.WindowMinimizeOnTitleDblClick, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if double-clicking on a window's title should minimize it.</para>
    /// <para><b>Note:</b> This method is implemented only on macOS.</para>
    /// </summary>
    public static bool WindowMinimizeOnTitleDblClick()
    {
        return NativeCalls.godot_icall_0_15(MethodBind144, GodotObject.GetPtr(Singleton)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind145 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.WindowStartDrag, 1995695955ul);

    /// <summary>
    /// <para>Starts an interactive drag operation on the window with the given <paramref name="windowId"/>, using the current mouse position. Call this method when handling a mouse button being pressed to simulate a pressed event on the window's title bar. Using this method allows the window to participate in space switching, tiling, and other system features.</para>
    /// <para><b>Note:</b> This method is implemented on Linux (X11/Wayland), macOS, and Windows.</para>
    /// </summary>
    public static void WindowStartDrag(int windowId = 0)
    {
        NativeCalls.godot_icall_1_38(MethodBind145, GodotObject.GetPtr(Singleton), windowId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind146 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.WindowStartResize, 4009722312ul);

    /// <summary>
    /// <para>Starts an interactive resize operation on the window with the given <paramref name="windowId"/>, using the current mouse position. Call this method when handling a mouse button being pressed to simulate a pressed event on the window's edge.</para>
    /// <para><b>Note:</b> This method is implemented on Linux (X11/Wayland), macOS, and Windows.</para>
    /// </summary>
    public static void WindowStartResize(DisplayServer.WindowResizeEdge edge, int windowId = 0)
    {
        NativeCalls.godot_icall_2_59(MethodBind146, GodotObject.GetPtr(Singleton), (int)edge, windowId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind147 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.WindowSetColor, 2920490490ul);

    /// <summary>
    /// <para>Sets the background color of the root window.</para>
    /// <para><b>Note:</b> This method is implemented only on Android.</para>
    /// </summary>
    public static unsafe void WindowSetColor(Color color)
    {
        NativeCalls.godot_icall_1_213(MethodBind147, GodotObject.GetPtr(Singleton), &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind148 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AccessibilityShouldIncreaseContrast, 3905245786ul);

    /// <summary>
    /// <para>Returns <c>1</c> if a high-contrast user interface theme should be used, <c>0</c> otherwise. Returns <c>-1</c> if status is unknown.</para>
    /// <para><b>Note:</b> This method is implemented on Linux (X11/Wayland, GNOME), macOS, and Windows.</para>
    /// </summary>
    public static int AccessibilityShouldIncreaseContrast()
    {
        return NativeCalls.godot_icall_0_39(MethodBind148, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind149 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AccessibilityShouldReduceAnimation, 3905245786ul);

    /// <summary>
    /// <para>Returns <c>1</c> if flashing, blinking, and other moving content that can cause seizures in users with photosensitive epilepsy should be disabled, <c>0</c> otherwise. Returns <c>-1</c> if status is unknown.</para>
    /// <para><b>Note:</b> This method is implemented on macOS and Windows.</para>
    /// </summary>
    public static int AccessibilityShouldReduceAnimation()
    {
        return NativeCalls.godot_icall_0_39(MethodBind149, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind150 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AccessibilityShouldReduceTransparency, 3905245786ul);

    /// <summary>
    /// <para>Returns <c>1</c> if background images, transparency, and other features that can reduce the contrast between the foreground and background should be disabled, <c>0</c> otherwise. Returns <c>-1</c> if status is unknown.</para>
    /// <para><b>Note:</b> This method is implemented on macOS and Windows.</para>
    /// </summary>
    public static int AccessibilityShouldReduceTransparency()
    {
        return NativeCalls.godot_icall_0_39(MethodBind150, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind151 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AccessibilityScreenReaderActive, 3905245786ul);

    /// <summary>
    /// <para>Returns <c>1</c> if a screen reader, Braille display or other assistive app is active, <c>0</c> otherwise. Returns <c>-1</c> if status is unknown.</para>
    /// <para><b>Note:</b> This method is implemented on Linux, macOS, and Windows.</para>
    /// <para><b>Note:</b> Accessibility debugging tools, such as Accessibility Insights for Windows, Accessibility Inspector (macOS), or AT-SPI Browser (Linux/BSD), do not count as assistive apps and will not affect this value. To test your project with these tools, set <c>ProjectSettings.accessibility/general/accessibility_support</c> to <c>1</c>.</para>
    /// </summary>
    public static int AccessibilityScreenReaderActive()
    {
        return NativeCalls.godot_icall_0_39(MethodBind151, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind152 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AccessibilityCreateElement, 2968347744ul);

    /// <summary>
    /// <para>Creates a new, empty accessibility element resource.</para>
    /// <para><b>Note:</b> An accessibility element is created and freed automatically for each <see cref="Godot.Node"/>. In general, this function should not be called manually.</para>
    /// </summary>
    public static Rid AccessibilityCreateElement(int windowId, DisplayServer.AccessibilityRole role)
    {
        return NativeCalls.godot_icall_2_418(MethodBind152, GodotObject.GetPtr(Singleton), windowId, (int)role);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind153 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AccessibilityCreateSubElement, 1949948826ul);

    /// <summary>
    /// <para>Creates a new, empty accessibility sub-element resource. Sub-elements can be used to provide accessibility information for objects which are not <see cref="Godot.Node"/>s, such as list items, table cells, or menu items. Sub-elements are freed automatically when the parent element is freed, or can be freed early using the <see cref="Godot.DisplayServer.AccessibilityFreeElement(Rid)"/> method.</para>
    /// </summary>
    public static Rid AccessibilityCreateSubElement(Rid parentRid, DisplayServer.AccessibilityRole role, int insertPos = -1)
    {
        return NativeCalls.godot_icall_3_419(MethodBind153, GodotObject.GetPtr(Singleton), parentRid, (int)role, insertPos);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind154 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AccessibilityCreateSubTextEditElements, 2702009895ul);

    /// <summary>
    /// <para>Creates a new, empty accessibility sub-element from the shaped text buffer. Sub-elements are freed automatically when the parent element is freed, or can be freed early using the <see cref="Godot.DisplayServer.AccessibilityFreeElement(Rid)"/> method.</para>
    /// <para>If <paramref name="isLastLine"/> is <see langword="true"/>, no trailing newline is appended to the text content. Set to <see langword="true"/> for the last line in multi-line text fields and for single-line text fields.</para>
    /// </summary>
    public static Rid AccessibilityCreateSubTextEditElements(Rid parentRid, Rid shapedText, float minHeight, int insertPos = -1, bool isLastLine = false)
    {
        return NativeCalls.godot_icall_5_420(MethodBind154, GodotObject.GetPtr(Singleton), parentRid, shapedText, minHeight, insertPos, isLastLine.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind155 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AccessibilityHasElement, 4155700596ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if <paramref name="id"/> is a valid accessibility element.</para>
    /// </summary>
    public static bool AccessibilityHasElement(Rid id)
    {
        return NativeCalls.godot_icall_1_421(MethodBind155, GodotObject.GetPtr(Singleton), id).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind156 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AccessibilityFreeElement, 2722037293ul);

    /// <summary>
    /// <para>Frees the accessibility element <paramref name="id"/> created by <see cref="Godot.DisplayServer.AccessibilityCreateElement(int, DisplayServer.AccessibilityRole)"/>, <see cref="Godot.DisplayServer.AccessibilityCreateSubElement(Rid, DisplayServer.AccessibilityRole, int)"/>, or <see cref="Godot.DisplayServer.AccessibilityCreateSubTextEditElements(Rid, Rid, float, int, bool)"/>.</para>
    /// </summary>
    public static void AccessibilityFreeElement(Rid id)
    {
        NativeCalls.godot_icall_1_286(MethodBind156, GodotObject.GetPtr(Singleton), id);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind157 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AccessibilityElementSetMeta, 3175752987ul);

    /// <summary>
    /// <para>Sets the metadata of the accessibility element <paramref name="id"/> to <paramref name="meta"/>.</para>
    /// </summary>
    public static void AccessibilityElementSetMeta(Rid id, Variant meta)
    {
        NativeCalls.godot_icall_2_422(MethodBind157, GodotObject.GetPtr(Singleton), id, meta);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind158 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AccessibilityElementGetMeta, 4171304767ul);

    /// <summary>
    /// <para>Returns the metadata of the accessibility element <paramref name="id"/>.</para>
    /// </summary>
    public static Variant AccessibilityElementGetMeta(Rid id)
    {
        return NativeCalls.godot_icall_1_423(MethodBind158, GodotObject.GetPtr(Singleton), id);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind159 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AccessibilitySetWindowRect, 2386961724ul);

    /// <summary>
    /// <para>Sets window outer (with decorations) and inner (without decorations) bounds for assistive apps.</para>
    /// <para><b>Note:</b> This method is implemented on Linux, macOS, and Windows.</para>
    /// <para><b>Note:</b> Advanced users only! <see cref="Godot.Window"/> objects call this method automatically.</para>
    /// </summary>
    public static unsafe void AccessibilitySetWindowRect(int windowId, Rect2 rectOut, Rect2 rectIn)
    {
        NativeCalls.godot_icall_3_424(MethodBind159, GodotObject.GetPtr(Singleton), windowId, &rectOut, &rectIn);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind160 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AccessibilitySetWindowFocused, 300928843ul);

    /// <summary>
    /// <para>Sets the window focused state for assistive apps.</para>
    /// <para><b>Note:</b> This method is implemented on Linux, macOS, and Windows.</para>
    /// <para><b>Note:</b> Advanced users only! <see cref="Godot.Window"/> objects call this method automatically.</para>
    /// </summary>
    public static void AccessibilitySetWindowFocused(int windowId, bool focused)
    {
        NativeCalls.godot_icall_2_61(MethodBind160, GodotObject.GetPtr(Singleton), windowId, focused.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind161 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AccessibilityUpdateSetFocus, 2722037293ul);

    /// <summary>
    /// <para>Sets currently focused element.</para>
    /// </summary>
    public static void AccessibilityUpdateSetFocus(Rid id)
    {
        NativeCalls.godot_icall_1_286(MethodBind161, GodotObject.GetPtr(Singleton), id);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind162 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AccessibilityGetWindowRoot, 495598643ul);

    /// <summary>
    /// <para>Returns the main accessibility element of the OS native window.</para>
    /// </summary>
    public static Rid AccessibilityGetWindowRoot(int windowId)
    {
        return NativeCalls.godot_icall_1_425(MethodBind162, GodotObject.GetPtr(Singleton), windowId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind163 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AccessibilityUpdateSetRole, 3352768215ul);

    /// <summary>
    /// <para>Sets element accessibility role.</para>
    /// </summary>
    public static void AccessibilityUpdateSetRole(Rid id, DisplayServer.AccessibilityRole role)
    {
        NativeCalls.godot_icall_2_426(MethodBind163, GodotObject.GetPtr(Singleton), id, (int)role);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind164 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AccessibilityUpdateSetName, 2726140452ul);

    /// <summary>
    /// <para>Sets element accessibility name.</para>
    /// </summary>
    public static void AccessibilityUpdateSetName(Rid id, string name)
    {
        NativeCalls.godot_icall_2_427(MethodBind164, GodotObject.GetPtr(Singleton), id, name);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind165 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AccessibilityUpdateSetExtraInfo, 2726140452ul);

    /// <summary>
    /// <para>Sets element accessibility extra information added to the element name.</para>
    /// </summary>
    public static void AccessibilityUpdateSetExtraInfo(Rid id, string name)
    {
        NativeCalls.godot_icall_2_427(MethodBind165, GodotObject.GetPtr(Singleton), id, name);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind166 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AccessibilityUpdateSetDescription, 2726140452ul);

    /// <summary>
    /// <para>Sets element accessibility description.</para>
    /// </summary>
    public static void AccessibilityUpdateSetDescription(Rid id, string description)
    {
        NativeCalls.godot_icall_2_427(MethodBind166, GodotObject.GetPtr(Singleton), id, description);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind167 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AccessibilityUpdateSetValue, 2726140452ul);

    /// <summary>
    /// <para>Sets element text value.</para>
    /// </summary>
    public static void AccessibilityUpdateSetValue(Rid id, string value)
    {
        NativeCalls.godot_icall_2_427(MethodBind167, GodotObject.GetPtr(Singleton), id, value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind168 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AccessibilityUpdateSetTooltip, 2726140452ul);

    /// <summary>
    /// <para>Sets tooltip text.</para>
    /// </summary>
    public static void AccessibilityUpdateSetTooltip(Rid id, string tooltip)
    {
        NativeCalls.godot_icall_2_427(MethodBind168, GodotObject.GetPtr(Singleton), id, tooltip);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind169 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AccessibilityUpdateSetBounds, 1378122625ul);

    /// <summary>
    /// <para>Sets element bounding box, relative to the node position.</para>
    /// </summary>
    public static unsafe void AccessibilityUpdateSetBounds(Rid id, Rect2 pRect)
    {
        NativeCalls.godot_icall_2_428(MethodBind169, GodotObject.GetPtr(Singleton), id, &pRect);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind170 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AccessibilityUpdateSetTransform, 1246044741ul);

    /// <summary>
    /// <para>Sets element 2D transform.</para>
    /// </summary>
    public static unsafe void AccessibilityUpdateSetTransform(Rid id, Transform2D transform)
    {
        NativeCalls.godot_icall_2_429(MethodBind170, GodotObject.GetPtr(Singleton), id, &transform);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind171 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AccessibilityUpdateAddChild, 395945892ul);

    /// <summary>
    /// <para>Adds a child accessibility element.</para>
    /// <para><b>Note:</b> <see cref="Godot.Node"/> children and sub-elements are added to the child list automatically.</para>
    /// </summary>
    public static void AccessibilityUpdateAddChild(Rid id, Rid childId)
    {
        NativeCalls.godot_icall_2_430(MethodBind171, GodotObject.GetPtr(Singleton), id, childId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind172 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AccessibilityUpdateAddRelatedControls, 395945892ul);

    /// <summary>
    /// <para>Adds an element that is controlled by this element.</para>
    /// </summary>
    public static void AccessibilityUpdateAddRelatedControls(Rid id, Rid relatedId)
    {
        NativeCalls.godot_icall_2_430(MethodBind172, GodotObject.GetPtr(Singleton), id, relatedId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind173 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AccessibilityUpdateAddRelatedDetails, 395945892ul);

    /// <summary>
    /// <para>Adds an element that details this element.</para>
    /// </summary>
    public static void AccessibilityUpdateAddRelatedDetails(Rid id, Rid relatedId)
    {
        NativeCalls.godot_icall_2_430(MethodBind173, GodotObject.GetPtr(Singleton), id, relatedId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind174 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AccessibilityUpdateAddRelatedDescribedBy, 395945892ul);

    /// <summary>
    /// <para>Adds an element that describes this element.</para>
    /// </summary>
    public static void AccessibilityUpdateAddRelatedDescribedBy(Rid id, Rid relatedId)
    {
        NativeCalls.godot_icall_2_430(MethodBind174, GodotObject.GetPtr(Singleton), id, relatedId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind175 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AccessibilityUpdateAddRelatedFlowTo, 395945892ul);

    /// <summary>
    /// <para>Adds an element that this element flow into.</para>
    /// </summary>
    public static void AccessibilityUpdateAddRelatedFlowTo(Rid id, Rid relatedId)
    {
        NativeCalls.godot_icall_2_430(MethodBind175, GodotObject.GetPtr(Singleton), id, relatedId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind176 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AccessibilityUpdateAddRelatedLabeledBy, 395945892ul);

    /// <summary>
    /// <para>Adds an element that labels this element.</para>
    /// </summary>
    public static void AccessibilityUpdateAddRelatedLabeledBy(Rid id, Rid relatedId)
    {
        NativeCalls.godot_icall_2_430(MethodBind176, GodotObject.GetPtr(Singleton), id, relatedId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind177 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AccessibilityUpdateAddRelatedRadioGroup, 395945892ul);

    /// <summary>
    /// <para>Adds an element that is part of the same radio group.</para>
    /// <para><b>Note:</b> This method should be called on each element of the group, using all other elements as <paramref name="relatedId"/>.</para>
    /// </summary>
    public static void AccessibilityUpdateAddRelatedRadioGroup(Rid id, Rid relatedId)
    {
        NativeCalls.godot_icall_2_430(MethodBind177, GodotObject.GetPtr(Singleton), id, relatedId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind178 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AccessibilityUpdateSetActiveDescendant, 395945892ul);

    /// <summary>
    /// <para>Adds an element that is an active descendant of this element.</para>
    /// </summary>
    public static void AccessibilityUpdateSetActiveDescendant(Rid id, Rid otherId)
    {
        NativeCalls.godot_icall_2_430(MethodBind178, GodotObject.GetPtr(Singleton), id, otherId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind179 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AccessibilityUpdateSetNextOnLine, 395945892ul);

    /// <summary>
    /// <para>Sets next element on the line.</para>
    /// </summary>
    public static void AccessibilityUpdateSetNextOnLine(Rid id, Rid otherId)
    {
        NativeCalls.godot_icall_2_430(MethodBind179, GodotObject.GetPtr(Singleton), id, otherId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind180 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AccessibilityUpdateSetPreviousOnLine, 395945892ul);

    /// <summary>
    /// <para>Sets previous element on the line.</para>
    /// </summary>
    public static void AccessibilityUpdateSetPreviousOnLine(Rid id, Rid otherId)
    {
        NativeCalls.godot_icall_2_430(MethodBind180, GodotObject.GetPtr(Singleton), id, otherId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind181 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AccessibilityUpdateSetMemberOf, 395945892ul);

    /// <summary>
    /// <para>Sets the element to be a member of the group.</para>
    /// </summary>
    public static void AccessibilityUpdateSetMemberOf(Rid id, Rid groupId)
    {
        NativeCalls.godot_icall_2_430(MethodBind181, GodotObject.GetPtr(Singleton), id, groupId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind182 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AccessibilityUpdateSetInPageLinkTarget, 395945892ul);

    /// <summary>
    /// <para>Sets target element for the link.</para>
    /// </summary>
    public static void AccessibilityUpdateSetInPageLinkTarget(Rid id, Rid otherId)
    {
        NativeCalls.godot_icall_2_430(MethodBind182, GodotObject.GetPtr(Singleton), id, otherId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind183 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AccessibilityUpdateSetErrorMessage, 395945892ul);

    /// <summary>
    /// <para>Sets an element which contains an error message for this element.</para>
    /// </summary>
    public static void AccessibilityUpdateSetErrorMessage(Rid id, Rid otherId)
    {
        NativeCalls.godot_icall_2_430(MethodBind183, GodotObject.GetPtr(Singleton), id, otherId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind184 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AccessibilityUpdateSetLive, 2683302212ul);

    /// <summary>
    /// <para>Sets the priority of the live region updates.</para>
    /// </summary>
    public static void AccessibilityUpdateSetLive(Rid id, DisplayServer.AccessibilityLiveMode live)
    {
        NativeCalls.godot_icall_2_426(MethodBind184, GodotObject.GetPtr(Singleton), id, (int)live);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind185 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AccessibilityUpdateAddAction, 2898696987ul);

    /// <summary>
    /// <para>Adds a callback for the accessibility action (action which can be performed by using a special screen reader command or buttons on the Braille display), and marks this action as supported. The action callback receives one <see cref="Godot.Variant"/> argument, which value depends on action type.</para>
    /// </summary>
    public static void AccessibilityUpdateAddAction(Rid id, DisplayServer.AccessibilityAction action, Callable callable)
    {
        NativeCalls.godot_icall_3_431(MethodBind185, GodotObject.GetPtr(Singleton), id, (int)action, callable);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind186 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AccessibilityUpdateAddCustomAction, 4153150897ul);

    /// <summary>
    /// <para>Adds support for a custom accessibility action. <paramref name="actionId"/> is passed as an argument to the callback of <see cref="Godot.DisplayServer.AccessibilityAction.Custom"/> action.</para>
    /// </summary>
    public static void AccessibilityUpdateAddCustomAction(Rid id, int actionId, string actionDescription)
    {
        NativeCalls.godot_icall_3_432(MethodBind186, GodotObject.GetPtr(Singleton), id, actionId, actionDescription);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind187 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AccessibilityUpdateSetTableRowCount, 3411492887ul);

    /// <summary>
    /// <para>Sets number of rows in the table.</para>
    /// </summary>
    public static void AccessibilityUpdateSetTableRowCount(Rid id, int count)
    {
        NativeCalls.godot_icall_2_426(MethodBind187, GodotObject.GetPtr(Singleton), id, count);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind188 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AccessibilityUpdateSetTableColumnCount, 3411492887ul);

    /// <summary>
    /// <para>Sets number of columns in the table.</para>
    /// </summary>
    public static void AccessibilityUpdateSetTableColumnCount(Rid id, int count)
    {
        NativeCalls.godot_icall_2_426(MethodBind188, GodotObject.GetPtr(Singleton), id, count);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind189 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AccessibilityUpdateSetTableRowIndex, 3411492887ul);

    /// <summary>
    /// <para>Sets position of the row in the table.</para>
    /// </summary>
    public static void AccessibilityUpdateSetTableRowIndex(Rid id, int index)
    {
        NativeCalls.godot_icall_2_426(MethodBind189, GodotObject.GetPtr(Singleton), id, index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind190 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AccessibilityUpdateSetTableColumnIndex, 3411492887ul);

    /// <summary>
    /// <para>Sets position of the column.</para>
    /// </summary>
    public static void AccessibilityUpdateSetTableColumnIndex(Rid id, int index)
    {
        NativeCalls.godot_icall_2_426(MethodBind190, GodotObject.GetPtr(Singleton), id, index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind191 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AccessibilityUpdateSetTableCellPosition, 4288446313ul);

    /// <summary>
    /// <para>Sets cell position in the table.</para>
    /// </summary>
    public static void AccessibilityUpdateSetTableCellPosition(Rid id, int rowIndex, int columnIndex)
    {
        NativeCalls.godot_icall_3_433(MethodBind191, GodotObject.GetPtr(Singleton), id, rowIndex, columnIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind192 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AccessibilityUpdateSetTableCellSpan, 4288446313ul);

    /// <summary>
    /// <para>Sets cell row/column span.</para>
    /// </summary>
    public static void AccessibilityUpdateSetTableCellSpan(Rid id, int rowSpan, int columnSpan)
    {
        NativeCalls.godot_icall_3_433(MethodBind192, GodotObject.GetPtr(Singleton), id, rowSpan, columnSpan);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind193 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AccessibilityUpdateSetListItemCount, 3411492887ul);

    /// <summary>
    /// <para>Sets number of items in the list.</para>
    /// </summary>
    public static void AccessibilityUpdateSetListItemCount(Rid id, int size)
    {
        NativeCalls.godot_icall_2_426(MethodBind193, GodotObject.GetPtr(Singleton), id, size);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind194 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AccessibilityUpdateSetListItemIndex, 3411492887ul);

    /// <summary>
    /// <para>Sets the position of the element in the list.</para>
    /// </summary>
    public static void AccessibilityUpdateSetListItemIndex(Rid id, int index)
    {
        NativeCalls.godot_icall_2_426(MethodBind194, GodotObject.GetPtr(Singleton), id, index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind195 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AccessibilityUpdateSetListItemLevel, 3411492887ul);

    /// <summary>
    /// <para>Sets the hierarchical level of the element in the list.</para>
    /// </summary>
    public static void AccessibilityUpdateSetListItemLevel(Rid id, int level)
    {
        NativeCalls.godot_icall_2_426(MethodBind195, GodotObject.GetPtr(Singleton), id, level);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind196 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AccessibilityUpdateSetListItemSelected, 1265174801ul);

    /// <summary>
    /// <para>Sets list/tree item selected status.</para>
    /// </summary>
    public static void AccessibilityUpdateSetListItemSelected(Rid id, bool selected)
    {
        NativeCalls.godot_icall_2_434(MethodBind196, GodotObject.GetPtr(Singleton), id, selected.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind197 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AccessibilityUpdateSetListItemExpanded, 1265174801ul);

    /// <summary>
    /// <para>Sets list/tree item expanded status.</para>
    /// </summary>
    public static void AccessibilityUpdateSetListItemExpanded(Rid id, bool expanded)
    {
        NativeCalls.godot_icall_2_434(MethodBind197, GodotObject.GetPtr(Singleton), id, expanded.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind198 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AccessibilityUpdateSetPopupType, 2040885448ul);

    /// <summary>
    /// <para>Sets popup type for popup buttons.</para>
    /// </summary>
    public static void AccessibilityUpdateSetPopupType(Rid id, DisplayServer.AccessibilityPopupType popup)
    {
        NativeCalls.godot_icall_2_426(MethodBind198, GodotObject.GetPtr(Singleton), id, (int)popup);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind199 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AccessibilityUpdateSetChecked, 1265174801ul);

    /// <summary>
    /// <para>Sets element checked state.</para>
    /// </summary>
    public static void AccessibilityUpdateSetChecked(Rid id, bool checekd)
    {
        NativeCalls.godot_icall_2_434(MethodBind199, GodotObject.GetPtr(Singleton), id, checekd.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind200 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AccessibilityUpdateSetNumValue, 1794382983ul);

    /// <summary>
    /// <para>Sets numeric value.</para>
    /// </summary>
    public static void AccessibilityUpdateSetNumValue(Rid id, double position)
    {
        NativeCalls.godot_icall_2_435(MethodBind200, GodotObject.GetPtr(Singleton), id, position);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind201 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AccessibilityUpdateSetNumRange, 2513314492ul);

    /// <summary>
    /// <para>Sets numeric value range.</para>
    /// </summary>
    public static void AccessibilityUpdateSetNumRange(Rid id, double min, double max)
    {
        NativeCalls.godot_icall_3_436(MethodBind201, GodotObject.GetPtr(Singleton), id, min, max);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind202 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AccessibilityUpdateSetNumStep, 1794382983ul);

    /// <summary>
    /// <para>Sets numeric value step.</para>
    /// </summary>
    public static void AccessibilityUpdateSetNumStep(Rid id, double step)
    {
        NativeCalls.godot_icall_2_435(MethodBind202, GodotObject.GetPtr(Singleton), id, step);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind203 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AccessibilityUpdateSetNumJump, 1794382983ul);

    /// <summary>
    /// <para>Sets numeric value jump.</para>
    /// </summary>
    public static void AccessibilityUpdateSetNumJump(Rid id, double jump)
    {
        NativeCalls.godot_icall_2_435(MethodBind203, GodotObject.GetPtr(Singleton), id, jump);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind204 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AccessibilityUpdateSetScrollX, 1794382983ul);

    /// <summary>
    /// <para>Sets scroll bar x position.</para>
    /// </summary>
    public static void AccessibilityUpdateSetScrollX(Rid id, double position)
    {
        NativeCalls.godot_icall_2_435(MethodBind204, GodotObject.GetPtr(Singleton), id, position);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind205 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AccessibilityUpdateSetScrollXRange, 2513314492ul);

    /// <summary>
    /// <para>Sets scroll bar x range.</para>
    /// </summary>
    public static void AccessibilityUpdateSetScrollXRange(Rid id, double min, double max)
    {
        NativeCalls.godot_icall_3_436(MethodBind205, GodotObject.GetPtr(Singleton), id, min, max);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind206 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AccessibilityUpdateSetScrollY, 1794382983ul);

    /// <summary>
    /// <para>Sets scroll bar y position.</para>
    /// </summary>
    public static void AccessibilityUpdateSetScrollY(Rid id, double position)
    {
        NativeCalls.godot_icall_2_435(MethodBind206, GodotObject.GetPtr(Singleton), id, position);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind207 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AccessibilityUpdateSetScrollYRange, 2513314492ul);

    /// <summary>
    /// <para>Sets scroll bar y range.</para>
    /// </summary>
    public static void AccessibilityUpdateSetScrollYRange(Rid id, double min, double max)
    {
        NativeCalls.godot_icall_3_436(MethodBind207, GodotObject.GetPtr(Singleton), id, min, max);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind208 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AccessibilityUpdateSetTextDecorations, 1672422386ul);

    /// <summary>
    /// <para>Sets text underline/overline/strikethrough.</para>
    /// </summary>
    public static void AccessibilityUpdateSetTextDecorations(Rid id, bool underline, bool strikethrough, bool overline)
    {
        NativeCalls.godot_icall_4_437(MethodBind208, GodotObject.GetPtr(Singleton), id, underline.ToGodotBool(), strikethrough.ToGodotBool(), overline.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind209 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AccessibilityUpdateSetTextAlign, 3725995085ul);

    /// <summary>
    /// <para>Sets element text alignment.</para>
    /// </summary>
    public static void AccessibilityUpdateSetTextAlign(Rid id, HorizontalAlignment align)
    {
        NativeCalls.godot_icall_2_426(MethodBind209, GodotObject.GetPtr(Singleton), id, (int)align);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind210 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AccessibilityUpdateSetTextSelection, 3119144029ul);

    /// <summary>
    /// <para>Sets text selection to the text field. <paramref name="textStartId"/> and <paramref name="textEndId"/> should be elements created by <see cref="Godot.DisplayServer.AccessibilityCreateSubTextEditElements(Rid, Rid, float, int, bool)"/>. Character offsets are relative to the corresponding element.</para>
    /// </summary>
    public static void AccessibilityUpdateSetTextSelection(Rid id, Rid textStartId, int startChar, Rid textEndId, int endChar)
    {
        NativeCalls.godot_icall_5_438(MethodBind210, GodotObject.GetPtr(Singleton), id, textStartId, startChar, textEndId, endChar);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind211 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AccessibilityUpdateSetFlag, 3758675396ul);

    /// <summary>
    /// <para>Sets element flag.</para>
    /// </summary>
    public static void AccessibilityUpdateSetFlag(Rid id, DisplayServer.AccessibilityFlags flag, bool value)
    {
        NativeCalls.godot_icall_3_439(MethodBind211, GodotObject.GetPtr(Singleton), id, (int)flag, value.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind212 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AccessibilityUpdateSetClassname, 2726140452ul);

    /// <summary>
    /// <para>Sets element class name.</para>
    /// </summary>
    public static void AccessibilityUpdateSetClassname(Rid id, string classname)
    {
        NativeCalls.godot_icall_2_427(MethodBind212, GodotObject.GetPtr(Singleton), id, classname);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind213 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AccessibilityUpdateSetPlaceholder, 2726140452ul);

    /// <summary>
    /// <para>Sets placeholder text.</para>
    /// </summary>
    public static void AccessibilityUpdateSetPlaceholder(Rid id, string placeholder)
    {
        NativeCalls.godot_icall_2_427(MethodBind213, GodotObject.GetPtr(Singleton), id, placeholder);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind214 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AccessibilityUpdateSetLanguage, 2726140452ul);

    /// <summary>
    /// <para>Sets element text language.</para>
    /// </summary>
    public static void AccessibilityUpdateSetLanguage(Rid id, string language)
    {
        NativeCalls.godot_icall_2_427(MethodBind214, GodotObject.GetPtr(Singleton), id, language);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind215 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AccessibilityUpdateSetTextOrientation, 1265174801ul);

    /// <summary>
    /// <para>Sets text orientation.</para>
    /// </summary>
    public static void AccessibilityUpdateSetTextOrientation(Rid id, bool vertical)
    {
        NativeCalls.godot_icall_2_434(MethodBind215, GodotObject.GetPtr(Singleton), id, vertical.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind216 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AccessibilityUpdateSetListOrientation, 1265174801ul);

    /// <summary>
    /// <para>Sets the orientation of the list elements.</para>
    /// </summary>
    public static void AccessibilityUpdateSetListOrientation(Rid id, bool vertical)
    {
        NativeCalls.godot_icall_2_434(MethodBind216, GodotObject.GetPtr(Singleton), id, vertical.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind217 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AccessibilityUpdateSetShortcut, 2726140452ul);

    /// <summary>
    /// <para>Sets the list of keyboard shortcuts used by element.</para>
    /// </summary>
    public static void AccessibilityUpdateSetShortcut(Rid id, string shortcut)
    {
        NativeCalls.godot_icall_2_427(MethodBind217, GodotObject.GetPtr(Singleton), id, shortcut);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind218 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AccessibilityUpdateSetUrl, 2726140452ul);

    /// <summary>
    /// <para>Sets link URL.</para>
    /// </summary>
    public static void AccessibilityUpdateSetUrl(Rid id, string url)
    {
        NativeCalls.godot_icall_2_427(MethodBind218, GodotObject.GetPtr(Singleton), id, url);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind219 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AccessibilityUpdateSetRoleDescription, 2726140452ul);

    /// <summary>
    /// <para>Sets element accessibility role description text.</para>
    /// </summary>
    public static void AccessibilityUpdateSetRoleDescription(Rid id, string description)
    {
        NativeCalls.godot_icall_2_427(MethodBind219, GodotObject.GetPtr(Singleton), id, description);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind220 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AccessibilityUpdateSetStateDescription, 2726140452ul);

    /// <summary>
    /// <para>Sets human-readable description of the current checked state.</para>
    /// </summary>
    public static void AccessibilityUpdateSetStateDescription(Rid id, string description)
    {
        NativeCalls.godot_icall_2_427(MethodBind220, GodotObject.GetPtr(Singleton), id, description);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind221 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AccessibilityUpdateSetColorValue, 2948539648ul);

    /// <summary>
    /// <para>Sets element color value.</para>
    /// </summary>
    public static unsafe void AccessibilityUpdateSetColorValue(Rid id, Color color)
    {
        NativeCalls.godot_icall_2_440(MethodBind221, GodotObject.GetPtr(Singleton), id, &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind222 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AccessibilityUpdateSetBackgroundColor, 2948539648ul);

    /// <summary>
    /// <para>Sets element background color.</para>
    /// </summary>
    public static unsafe void AccessibilityUpdateSetBackgroundColor(Rid id, Color color)
    {
        NativeCalls.godot_icall_2_440(MethodBind222, GodotObject.GetPtr(Singleton), id, &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind223 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AccessibilityUpdateSetForegroundColor, 2948539648ul);

    /// <summary>
    /// <para>Sets element foreground color.</para>
    /// </summary>
    public static unsafe void AccessibilityUpdateSetForegroundColor(Rid id, Color color)
    {
        NativeCalls.godot_icall_2_440(MethodBind223, GodotObject.GetPtr(Singleton), id, &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind224 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ImeGetSelection, 3690982128ul);

    /// <summary>
    /// <para>Returns the text selection in the <a href="https://en.wikipedia.org/wiki/Input_method">Input Method Editor</a> composition string, with the <see cref="Godot.Vector2I"/>'s <c>x</c> component being the caret position and <c>y</c> being the length of the selection.</para>
    /// <para><b>Note:</b> This method is implemented only on macOS.</para>
    /// </summary>
    public static Vector2I ImeGetSelection()
    {
        return NativeCalls.godot_icall_0_35(MethodBind224, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind225 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ImeGetText, 201670096ul);

    /// <summary>
    /// <para>Returns the composition string contained within the <a href="https://en.wikipedia.org/wiki/Input_method">Input Method Editor</a> window.</para>
    /// <para><b>Note:</b> This method is implemented only on macOS.</para>
    /// </summary>
    public static string ImeGetText()
    {
        return NativeCalls.godot_icall_0_58(MethodBind225, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind226 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.VirtualKeyboardShow, 3042891259ul);

    /// <summary>
    /// <para>Shows the virtual keyboard if the platform has one.</para>
    /// <para><paramref name="existingText"/> parameter is useful for implementing your own <see cref="Godot.LineEdit"/> or <see cref="Godot.TextEdit"/>, as it tells the virtual keyboard what text has already been typed (the virtual keyboard uses it for auto-correct and predictions).</para>
    /// <para><paramref name="position"/> parameter is the screen space <see cref="Godot.Rect2"/> of the edited text.</para>
    /// <para><paramref name="type"/> parameter allows configuring which type of virtual keyboard to show.</para>
    /// <para><paramref name="maxLength"/> limits the number of characters that can be entered if different from <c>-1</c>.</para>
    /// <para><paramref name="cursorStart"/> can optionally define the current text cursor position if <paramref name="cursorEnd"/> is not set.</para>
    /// <para><paramref name="cursorStart"/> and <paramref name="cursorEnd"/> can optionally define the current text selection.</para>
    /// <para><b>Note:</b> This method is implemented on Android, iOS and Web.</para>
    /// </summary>
    /// <param name="position">If the parameter is null, then the default value is <c>new Rect2(new Vector2(0.0f, 0.0f), new Vector2(0.0f, 0.0f))</c>.</param>
    public static unsafe void VirtualKeyboardShow(string existingText, Nullable<Rect2> position = null, DisplayServer.VirtualKeyboardType type = (DisplayServer.VirtualKeyboardType)(0), int maxLength = -1, int cursorStart = -1, int cursorEnd = -1)
    {
        Rect2 positionOrDefVal = position.HasValue ? position.Value : new Rect2(new Vector2(0.0f, 0.0f), new Vector2(0.0f, 0.0f));
        NativeCalls.godot_icall_6_441(MethodBind226, GodotObject.GetPtr(Singleton), existingText, &positionOrDefVal, (int)type, maxLength, cursorStart, cursorEnd);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind227 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.VirtualKeyboardHide, 3218959716ul);

    /// <summary>
    /// <para>Hides the virtual keyboard if it is shown, does nothing otherwise.</para>
    /// </summary>
    public static void VirtualKeyboardHide()
    {
        NativeCalls.godot_icall_0_3(MethodBind227, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind228 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.VirtualKeyboardGetHeight, 3905245786ul);

    /// <summary>
    /// <para>Returns the on-screen keyboard's height in pixels. Returns <c>0</c> if there is no keyboard or if it is currently hidden.</para>
    /// <para><b>Note:</b> On Android 7 and 8, the keyboard height may return <c>0</c> the first time the keyboard is opened in non-immersive mode. This behavior does not occur in immersive mode.</para>
    /// </summary>
    public static int VirtualKeyboardGetHeight()
    {
        return NativeCalls.godot_icall_0_39(MethodBind228, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind229 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.HasHardwareKeyboard, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if a hardware keyboard is connected.</para>
    /// <para><b>Note:</b> This method is implemented on Android and iOS. On other platforms, this method always returns <see langword="true"/>.</para>
    /// </summary>
    public static bool HasHardwareKeyboard()
    {
        return NativeCalls.godot_icall_0_15(MethodBind229, GodotObject.GetPtr(Singleton)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind230 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SetHardwareKeyboardConnectionChangeCallback, 1611583062ul);

    /// <summary>
    /// <para>Sets the callback that should be called when a hardware keyboard is connected or disconnected. <paramref name="callable"/> should accept a single <see cref="bool"/> argument indicating whether the keyboard has been connected (<see langword="true"/>) or disconnected (<see langword="false"/>).</para>
    /// <para><b>Note:</b> This method is only implemented on Android.</para>
    /// </summary>
    public static void SetHardwareKeyboardConnectionChangeCallback(Callable callable)
    {
        NativeCalls.godot_icall_1_403(MethodBind230, GodotObject.GetPtr(Singleton), callable);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind231 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CursorSetShape, 2026291549ul);

    /// <summary>
    /// <para>Sets the default mouse cursor shape. The cursor's appearance will vary depending on the user's operating system and mouse cursor theme. See also <see cref="Godot.DisplayServer.CursorGetShape()"/> and <see cref="Godot.DisplayServer.CursorSetCustomImage(Resource, DisplayServer.CursorShape, Nullable{Vector2})"/>.</para>
    /// </summary>
    public static void CursorSetShape(DisplayServer.CursorShape shape)
    {
        NativeCalls.godot_icall_1_38(MethodBind231, GodotObject.GetPtr(Singleton), (int)shape);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind232 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CursorGetShape, 1087724927ul);

    /// <summary>
    /// <para>Returns the default mouse cursor shape set by <see cref="Godot.DisplayServer.CursorSetShape(DisplayServer.CursorShape)"/>.</para>
    /// </summary>
    public static DisplayServer.CursorShape CursorGetShape()
    {
        return (DisplayServer.CursorShape)NativeCalls.godot_icall_0_39(MethodBind232, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind233 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CursorSetCustomImage, 1816663697ul);

    /// <summary>
    /// <para>Sets a custom mouse cursor image for the given <paramref name="shape"/>. This means the user's operating system and mouse cursor theme will no longer influence the mouse cursor's appearance.</para>
    /// <para><paramref name="cursor"/> can be either a <see cref="Godot.Texture2D"/> or an <see cref="Godot.Image"/>, and it should not be larger than 256×256 to display correctly. Optionally, <paramref name="hotspot"/> can be set to offset the image's position relative to the click point. By default, <paramref name="hotspot"/> is set to the top-left corner of the image. See also <see cref="Godot.DisplayServer.CursorSetShape(DisplayServer.CursorShape)"/>.</para>
    /// <para><b>Note:</b> On Web, calling this method every frame can cause the cursor to flicker.</para>
    /// </summary>
    /// <param name="hotspot">If the parameter is null, then the default value is <c>new Vector2(0.0f, 0.0f)</c>.</param>
    public static unsafe void CursorSetCustomImage(Resource cursor, DisplayServer.CursorShape shape = (DisplayServer.CursorShape)(0), Nullable<Vector2> hotspot = null)
    {
        Vector2 hotspotOrDefVal = hotspot.HasValue ? hotspot.Value : new Vector2(0.0f, 0.0f);
        NativeCalls.godot_icall_3_442(MethodBind233, GodotObject.GetPtr(Singleton), GodotObject.GetPtr(cursor), (int)shape, &hotspotOrDefVal);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind234 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSwapCancelOk, 2240911060ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if positions of <b>OK</b> and <b>Cancel</b> buttons are swapped in dialogs. This is enabled by default on Windows to follow interface conventions, and be toggled by changing <c>ProjectSettings.gui/common/swap_cancel_ok</c>.</para>
    /// <para><b>Note:</b> This doesn't affect native dialogs such as the ones spawned by <see cref="Godot.DisplayServer.DialogShow(string, string, string[], Callable)"/>.</para>
    /// </summary>
    public static bool GetSwapCancelOk()
    {
        return NativeCalls.godot_icall_0_15(MethodBind234, GodotObject.GetPtr(Singleton)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind235 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.EnableForStealingFocus, 1286410249ul);

    /// <summary>
    /// <para>Allows the <paramref name="processId"/> PID to steal focus from this window. In other words, this disables the operating system's focus stealing protection for the specified PID.</para>
    /// <para><b>Note:</b> This method is implemented only on Windows.</para>
    /// </summary>
    public static void EnableForStealingFocus(long processId)
    {
        NativeCalls.godot_icall_1_10(MethodBind235, GodotObject.GetPtr(Singleton), processId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind236 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.DialogShow, 4115553226ul);

    /// <summary>
    /// <para>Shows a text dialog which uses the operating system's native look-and-feel. <paramref name="callback"/> should accept a single <see cref="int"/> parameter which corresponds to the index of the pressed button.</para>
    /// <para><b>Note:</b> This method is implemented if the display server has the <see cref="Godot.DisplayServer.Feature.NativeDialog"/> feature. Supported platforms include macOS, Windows, and Android.</para>
    /// </summary>
    public static Error DialogShow(string title, string description, string[] buttons, Callable callback)
    {
        return (Error)NativeCalls.godot_icall_4_443(MethodBind236, GodotObject.GetPtr(Singleton), title, description, buttons, callback);
    }

    /// <summary>
    /// <para>Shows a text dialog which uses the operating system's native look-and-feel. <paramref name="callback"/> should accept a single <see cref="int"/> parameter which corresponds to the index of the pressed button.</para>
    /// <para><b>Note:</b> This method is implemented if the display server has the <see cref="Godot.DisplayServer.Feature.NativeDialog"/> feature. Supported platforms include macOS, Windows, and Android.</para>
    /// </summary>
    public static Error DialogShow(string title, string description, ReadOnlySpan<string> buttons, Callable callback)
    {
        return (Error)NativeCalls.godot_icall_4_443(MethodBind236, GodotObject.GetPtr(Singleton), title, description, buttons, callback);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind237 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.DialogInputText, 3088703427ul);

    /// <summary>
    /// <para>Shows a text input dialog which uses the operating system's native look-and-feel. <paramref name="callback"/> should accept a single <see cref="string"/> parameter which contains the text field's contents.</para>
    /// <para><b>Note:</b> This method is implemented if the display server has the <see cref="Godot.DisplayServer.Feature.NativeDialogInput"/> feature. Supported platforms include macOS, Windows, and Android.</para>
    /// </summary>
    public static Error DialogInputText(string title, string description, string existingText, Callable callback)
    {
        return (Error)NativeCalls.godot_icall_4_444(MethodBind237, GodotObject.GetPtr(Singleton), title, description, existingText, callback);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind238 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.FileDialogShow, 1386825884ul);

    /// <summary>
    /// <para>Displays OS native dialog for selecting files or directories in the file system.</para>
    /// <para>Each filter string in the <paramref name="filters"/> array should be formatted like this: <c>*.png,*.jpg,*.jpeg;Image Files;image/png,image/jpeg</c>. The description text of the filter is optional and can be omitted. It is recommended to set both file extension and MIME type. See also <see cref="Godot.FileDialog.Filters"/>.</para>
    /// <para>Callbacks have the following arguments: <c>status: bool, selected_paths: PackedStringArray, selected_filter_index: int</c>. <b>On Android,</b> the third callback argument (<c>selected_filter_index</c>) is always <c>0</c>.</para>
    /// <para><b>Note:</b> This method is implemented if the display server has the <see cref="Godot.DisplayServer.Feature.NativeDialogFile"/> feature. Supported platforms include Linux (X11/Wayland), Windows, macOS, and Android (API level 29+).</para>
    /// <para><b>Note:</b> <paramref name="currentDirectory"/> might be ignored.</para>
    /// <para><b>Note:</b> Embedded file dialogs and Windows file dialogs support only file extensions, while Android, Linux, and macOS file dialogs also support MIME types.</para>
    /// <para><b>Note:</b> On Android and Linux, <paramref name="showHidden"/> is ignored.</para>
    /// <para><b>Note:</b> On Android and macOS, native file dialogs have no title.</para>
    /// <para><b>Note:</b> On macOS, sandboxed apps will save security-scoped bookmarks to retain access to the opened folders across multiple sessions. Use <see cref="Godot.OS.GetGrantedPermissions()"/> to get a list of saved bookmarks.</para>
    /// <para><b>Note:</b> On Android, this method uses the Android Storage Access Framework (SAF).</para>
    /// <para>The file picker returns a URI instead of a filesystem path. This URI can be passed directly to <see cref="Godot.FileAccess"/> to perform read/write operations.</para>
    /// <para>When using <see cref="Godot.DisplayServer.FileDialogMode.OpenDir"/>, it returns a tree URI that grants full access to the selected directory. File operations inside this directory can be performed by passing a path on the form <c>treeUri#relative/path/to/file</c> to <see cref="Godot.FileAccess"/>.</para>
    /// <para>To avoid opening the file picker again after each app restart, you can take persistable URI permission as follows:</para>
    /// <para></para>
    /// <para>The persistable URI permission remains valid across app restarts as long as the directory is not moved, renamed, or deleted.</para>
    /// </summary>
    public static Error FileDialogShow(string title, string currentDirectory, string fileName, bool showHidden, DisplayServer.FileDialogMode mode, string[] filters, Callable callback, int parentWindowId = 0)
    {
        return (Error)NativeCalls.godot_icall_8_445(MethodBind238, GodotObject.GetPtr(Singleton), title, currentDirectory, fileName, showHidden.ToGodotBool(), (int)mode, filters, callback, parentWindowId);
    }

    /// <summary>
    /// <para>Displays OS native dialog for selecting files or directories in the file system.</para>
    /// <para>Each filter string in the <paramref name="filters"/> array should be formatted like this: <c>*.png,*.jpg,*.jpeg;Image Files;image/png,image/jpeg</c>. The description text of the filter is optional and can be omitted. It is recommended to set both file extension and MIME type. See also <see cref="Godot.FileDialog.Filters"/>.</para>
    /// <para>Callbacks have the following arguments: <c>status: bool, selected_paths: PackedStringArray, selected_filter_index: int</c>. <b>On Android,</b> the third callback argument (<c>selected_filter_index</c>) is always <c>0</c>.</para>
    /// <para><b>Note:</b> This method is implemented if the display server has the <see cref="Godot.DisplayServer.Feature.NativeDialogFile"/> feature. Supported platforms include Linux (X11/Wayland), Windows, macOS, and Android (API level 29+).</para>
    /// <para><b>Note:</b> <paramref name="currentDirectory"/> might be ignored.</para>
    /// <para><b>Note:</b> Embedded file dialogs and Windows file dialogs support only file extensions, while Android, Linux, and macOS file dialogs also support MIME types.</para>
    /// <para><b>Note:</b> On Android and Linux, <paramref name="showHidden"/> is ignored.</para>
    /// <para><b>Note:</b> On Android and macOS, native file dialogs have no title.</para>
    /// <para><b>Note:</b> On macOS, sandboxed apps will save security-scoped bookmarks to retain access to the opened folders across multiple sessions. Use <see cref="Godot.OS.GetGrantedPermissions()"/> to get a list of saved bookmarks.</para>
    /// <para><b>Note:</b> On Android, this method uses the Android Storage Access Framework (SAF).</para>
    /// <para>The file picker returns a URI instead of a filesystem path. This URI can be passed directly to <see cref="Godot.FileAccess"/> to perform read/write operations.</para>
    /// <para>When using <see cref="Godot.DisplayServer.FileDialogMode.OpenDir"/>, it returns a tree URI that grants full access to the selected directory. File operations inside this directory can be performed by passing a path on the form <c>treeUri#relative/path/to/file</c> to <see cref="Godot.FileAccess"/>.</para>
    /// <para>To avoid opening the file picker again after each app restart, you can take persistable URI permission as follows:</para>
    /// <para></para>
    /// <para>The persistable URI permission remains valid across app restarts as long as the directory is not moved, renamed, or deleted.</para>
    /// </summary>
    public static Error FileDialogShow(string title, string currentDirectory, string fileName, bool showHidden, DisplayServer.FileDialogMode mode, ReadOnlySpan<string> filters, Callable callback, int parentWindowId)
    {
        return (Error)NativeCalls.godot_icall_8_445(MethodBind238, GodotObject.GetPtr(Singleton), title, currentDirectory, fileName, showHidden.ToGodotBool(), (int)mode, filters, callback, parentWindowId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind239 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.FileDialogWithOptionsShow, 1448789813ul);

    /// <summary>
    /// <para>Displays OS native dialog for selecting files or directories in the file system with additional user selectable options.</para>
    /// <para>Each filter string in the <paramref name="filters"/> array should be formatted like this: <c>*.png,*.jpg,*.jpeg;Image Files;image/png,image/jpeg</c>. The description text of the filter is optional and can be omitted. It is recommended to set both file extension and MIME type. See also <see cref="Godot.FileDialog.Filters"/>.</para>
    /// <para><paramref name="options"/> is array of <see cref="Godot.Collections.Dictionary"/>s with the following keys:</para>
    /// <para>- <c>"name"</c> - option's name <see cref="string"/>.</para>
    /// <para>- <c>"values"</c> - <see cref="string"/>[] of values. If empty, boolean option (check box) is used.</para>
    /// <para>- <c>"default"</c> - default selected option index (<see cref="int"/>) or default boolean value (<see cref="bool"/>).</para>
    /// <para>Callbacks have the following arguments: <c>status: bool, selected_paths: PackedStringArray, selected_filter_index: int, selected_option: Dictionary</c>.</para>
    /// <para><b>Note:</b> This method is implemented if the display server has the <see cref="Godot.DisplayServer.Feature.NativeDialogFileExtra"/> feature. Supported platforms include Linux (X11/Wayland), Windows, and macOS.</para>
    /// <para><b>Note:</b> <paramref name="currentDirectory"/> might be ignored.</para>
    /// <para><b>Note:</b> Embedded file dialogs and Windows file dialogs support only file extensions, while Android, Linux, and macOS file dialogs also support MIME types.</para>
    /// <para><b>Note:</b> On Linux (X11), <paramref name="showHidden"/> is ignored.</para>
    /// <para><b>Note:</b> On macOS, native file dialogs have no title.</para>
    /// <para><b>Note:</b> On macOS, sandboxed apps will save security-scoped bookmarks to retain access to the opened folders across multiple sessions. Use <see cref="Godot.OS.GetGrantedPermissions()"/> to get a list of saved bookmarks.</para>
    /// </summary>
    public static Error FileDialogWithOptionsShow(string title, string currentDirectory, string root, string fileName, bool showHidden, DisplayServer.FileDialogMode mode, string[] filters, Godot.Collections.Array<Godot.Collections.Dictionary> options, Callable callback, int parentWindowId = 0)
    {
        return (Error)NativeCalls.godot_icall_10_446(MethodBind239, GodotObject.GetPtr(Singleton), title, currentDirectory, root, fileName, showHidden.ToGodotBool(), (int)mode, filters, (godot_array)(options ?? new()).NativeValue, callback, parentWindowId);
    }

    /// <summary>
    /// <para>Displays OS native dialog for selecting files or directories in the file system with additional user selectable options.</para>
    /// <para>Each filter string in the <paramref name="filters"/> array should be formatted like this: <c>*.png,*.jpg,*.jpeg;Image Files;image/png,image/jpeg</c>. The description text of the filter is optional and can be omitted. It is recommended to set both file extension and MIME type. See also <see cref="Godot.FileDialog.Filters"/>.</para>
    /// <para><paramref name="options"/> is array of <see cref="Godot.Collections.Dictionary"/>s with the following keys:</para>
    /// <para>- <c>"name"</c> - option's name <see cref="string"/>.</para>
    /// <para>- <c>"values"</c> - <see cref="string"/>[] of values. If empty, boolean option (check box) is used.</para>
    /// <para>- <c>"default"</c> - default selected option index (<see cref="int"/>) or default boolean value (<see cref="bool"/>).</para>
    /// <para>Callbacks have the following arguments: <c>status: bool, selected_paths: PackedStringArray, selected_filter_index: int, selected_option: Dictionary</c>.</para>
    /// <para><b>Note:</b> This method is implemented if the display server has the <see cref="Godot.DisplayServer.Feature.NativeDialogFileExtra"/> feature. Supported platforms include Linux (X11/Wayland), Windows, and macOS.</para>
    /// <para><b>Note:</b> <paramref name="currentDirectory"/> might be ignored.</para>
    /// <para><b>Note:</b> Embedded file dialogs and Windows file dialogs support only file extensions, while Android, Linux, and macOS file dialogs also support MIME types.</para>
    /// <para><b>Note:</b> On Linux (X11), <paramref name="showHidden"/> is ignored.</para>
    /// <para><b>Note:</b> On macOS, native file dialogs have no title.</para>
    /// <para><b>Note:</b> On macOS, sandboxed apps will save security-scoped bookmarks to retain access to the opened folders across multiple sessions. Use <see cref="Godot.OS.GetGrantedPermissions()"/> to get a list of saved bookmarks.</para>
    /// </summary>
    public static Error FileDialogWithOptionsShow(string title, string currentDirectory, string root, string fileName, bool showHidden, DisplayServer.FileDialogMode mode, ReadOnlySpan<string> filters, Godot.Collections.Array<Godot.Collections.Dictionary> options, Callable callback, int parentWindowId)
    {
        return (Error)NativeCalls.godot_icall_10_446(MethodBind239, GodotObject.GetPtr(Singleton), title, currentDirectory, root, fileName, showHidden.ToGodotBool(), (int)mode, filters, (godot_array)(options ?? new()).NativeValue, callback, parentWindowId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind240 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.Beep, 4051624405ul);

    /// <summary>
    /// <para>Plays the beep sound from the operative system, if possible. Because it comes from the OS, the beep sound will be audible even if the application is muted. It may also be disabled for the entire OS by the user.</para>
    /// <para><b>Note:</b> This method is implemented on macOS, Linux (X11/Wayland), and Windows.</para>
    /// </summary>
    public static void Beep()
    {
        NativeCalls.godot_icall_0_3(MethodBind240, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind241 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.KeyboardGetLayoutCount, 3905245786ul);

    /// <summary>
    /// <para>Returns the number of keyboard layouts.</para>
    /// <para><b>Note:</b> This method is implemented on Linux (X11/Wayland), macOS and Windows.</para>
    /// </summary>
    public static int KeyboardGetLayoutCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind241, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind242 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.KeyboardGetCurrentLayout, 3905245786ul);

    /// <summary>
    /// <para>Returns active keyboard layout index.</para>
    /// <para><b>Note:</b> This method is implemented on Linux (X11/Wayland), macOS, and Windows.</para>
    /// </summary>
    public static int KeyboardGetCurrentLayout()
    {
        return NativeCalls.godot_icall_0_39(MethodBind242, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind243 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.KeyboardSetCurrentLayout, 1286410249ul);

    /// <summary>
    /// <para>Sets the active keyboard layout.</para>
    /// <para><b>Note:</b> This method is implemented on Linux (X11/Wayland), macOS and Windows.</para>
    /// </summary>
    public static void KeyboardSetCurrentLayout(int index)
    {
        NativeCalls.godot_icall_1_38(MethodBind243, GodotObject.GetPtr(Singleton), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind244 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.KeyboardGetLayoutLanguage, 844755477ul);

    /// <summary>
    /// <para>Returns the ISO-639/BCP-47 language code of the keyboard layout at position <paramref name="index"/>.</para>
    /// <para><b>Note:</b> This method is implemented on Linux (X11/Wayland), macOS and Windows.</para>
    /// </summary>
    public static string KeyboardGetLayoutLanguage(int index)
    {
        return NativeCalls.godot_icall_1_133(MethodBind244, GodotObject.GetPtr(Singleton), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind245 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.KeyboardGetLayoutName, 844755477ul);

    /// <summary>
    /// <para>Returns the localized name of the keyboard layout at position <paramref name="index"/>.</para>
    /// <para><b>Note:</b> This method is implemented on Linux (X11/Wayland), macOS and Windows.</para>
    /// </summary>
    public static string KeyboardGetLayoutName(int index)
    {
        return NativeCalls.godot_icall_1_133(MethodBind245, GodotObject.GetPtr(Singleton), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind246 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.KeyboardGetKeycodeFromPhysical, 3447613187ul);

    /// <summary>
    /// <para>Converts a physical (US QWERTY) <paramref name="keycode"/> to one in the active keyboard layout.</para>
    /// <para><b>Note:</b> This method is implemented on Linux (X11/Wayland), macOS and Windows.</para>
    /// </summary>
    public static Key KeyboardGetKeycodeFromPhysical(Key keycode)
    {
        return (Key)NativeCalls.godot_icall_1_60(MethodBind246, GodotObject.GetPtr(Singleton), (int)keycode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind247 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.KeyboardGetLabelFromPhysical, 3447613187ul);

    /// <summary>
    /// <para>Converts a physical (US QWERTY) <paramref name="keycode"/> to localized label printed on the key in the active keyboard layout.</para>
    /// <para><b>Note:</b> This method is implemented on Linux (X11/Wayland), macOS and Windows.</para>
    /// </summary>
    public static Key KeyboardGetLabelFromPhysical(Key keycode)
    {
        return (Key)NativeCalls.godot_icall_1_60(MethodBind247, GodotObject.GetPtr(Singleton), (int)keycode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind248 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ShowEmojiAndSymbolPicker, 4051624405ul);

    /// <summary>
    /// <para>Opens system emoji and symbol picker.</para>
    /// <para><b>Note:</b> This method is implemented on macOS and Windows.</para>
    /// </summary>
    public static void ShowEmojiAndSymbolPicker()
    {
        NativeCalls.godot_icall_0_3(MethodBind248, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind249 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ColorPicker, 151643214ul);

    /// <summary>
    /// <para>Displays OS native color picker.</para>
    /// <para>Callbacks have the following arguments: <c>status: bool, color: Color</c>.</para>
    /// <para><b>Note:</b> This method is implemented if the display server has the <see cref="Godot.DisplayServer.Feature.NativeColorPicker"/> feature.</para>
    /// <para><b>Note:</b> This method is only implemented on Linux (X11/Wayland).</para>
    /// </summary>
    public static bool ColorPicker(Callable callback)
    {
        return NativeCalls.godot_icall_1_447(MethodBind249, GodotObject.GetPtr(Singleton), callback).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind250 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ProcessEvents, 3218959716ul);

    /// <summary>
    /// <para>Perform window manager processing, including input flushing. See also <see cref="Godot.DisplayServer.ForceProcessAndDropEvents()"/>, <see cref="Godot.Input.FlushBufferedEvents()"/> and <see cref="Godot.Input.UseAccumulatedInput"/>.</para>
    /// </summary>
    public static void ProcessEvents()
    {
        NativeCalls.godot_icall_0_3(MethodBind250, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind251 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ForceProcessAndDropEvents, 3218959716ul);

    /// <summary>
    /// <para>Forces window manager processing while ignoring all <see cref="Godot.InputEvent"/>s. See also <see cref="Godot.DisplayServer.ProcessEvents()"/>.</para>
    /// <para><b>Note:</b> This method is implemented on Windows and macOS.</para>
    /// </summary>
    public static void ForceProcessAndDropEvents()
    {
        NativeCalls.godot_icall_0_3(MethodBind251, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind252 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SetNativeIcon, 83702148ul);

    /// <summary>
    /// <para>Sets the window icon (usually displayed in the top-left corner) in the operating system's <i>native</i> format. The file at <paramref name="fileName"/> must be in <c>.ico</c> format on Windows or <c>.icns</c> on macOS. By using specially crafted <c>.ico</c> or <c>.icns</c> icons, <see cref="Godot.DisplayServer.SetNativeIcon(string)"/> allows specifying different icons depending on the size the icon is displayed at. This size is determined by the operating system and user preferences (including the display scale factor). To use icons in other formats, use <see cref="Godot.DisplayServer.SetIcon(Image)"/> instead.</para>
    /// <para><b>Note:</b> Requires support for <see cref="Godot.DisplayServer.Feature.NativeIcon"/>.</para>
    /// </summary>
    public static void SetNativeIcon(string fileName)
    {
        NativeCalls.godot_icall_1_57(MethodBind252, GodotObject.GetPtr(Singleton), fileName);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind253 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SetIcon, 532598488ul);

    /// <summary>
    /// <para>Sets the window icon (usually displayed in the top-left corner) with an <see cref="Godot.Image"/>. To use icons in the operating system's native format, use <see cref="Godot.DisplayServer.SetNativeIcon(string)"/> instead.</para>
    /// <para><b>Note:</b> Requires support for <see cref="Godot.DisplayServer.Feature.Icon"/>.</para>
    /// </summary>
    public static void SetIcon(Image image)
    {
        NativeCalls.godot_icall_1_56(MethodBind253, GodotObject.GetPtr(Singleton), GodotObject.GetPtr(image));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind254 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.CreateStatusIndicator, 1904285171ul);

    /// <summary>
    /// <para>Creates a new application status indicator with the specified icon, tooltip, and activation callback.</para>
    /// <para><paramref name="callback"/> should take two arguments: the pressed mouse button (one of the <see cref="Godot.MouseButton"/> constants) and the click position in screen coordinates (a <see cref="Godot.Vector2I"/>).</para>
    /// </summary>
    public static int CreateStatusIndicator(Texture2D icon, string tooltip, Callable callback)
    {
        return NativeCalls.godot_icall_3_448(MethodBind254, GodotObject.GetPtr(Singleton), GodotObject.GetPtr(icon), tooltip, callback);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind255 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.StatusIndicatorSetIcon, 666127730ul);

    /// <summary>
    /// <para>Sets the application status indicator icon.</para>
    /// <para><b>Note:</b> This method is implemented on macOS and Windows.</para>
    /// </summary>
    public static void StatusIndicatorSetIcon(int id, Texture2D icon)
    {
        NativeCalls.godot_icall_2_70(MethodBind255, GodotObject.GetPtr(Singleton), id, GodotObject.GetPtr(icon));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind256 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.StatusIndicatorSetTooltip, 501894301ul);

    /// <summary>
    /// <para>Sets the application status indicator tooltip.</para>
    /// <para><b>Note:</b> This method is implemented on macOS and Windows.</para>
    /// </summary>
    public static void StatusIndicatorSetTooltip(int id, string tooltip)
    {
        NativeCalls.godot_icall_2_181(MethodBind256, GodotObject.GetPtr(Singleton), id, tooltip);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind257 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.StatusIndicatorSetMenu, 4040184819ul);

    /// <summary>
    /// <para>Sets the application status indicator native popup menu.</para>
    /// <para><b>Note:</b> On macOS, the menu is activated by any mouse button. Its activation callback is <i>not</i> triggered.</para>
    /// <para><b>Note:</b> On Windows, the menu is activated by the right mouse button, selecting the status icon and pressing Shift + F10, or the applications key. The menu's activation callback for the other mouse buttons is still triggered.</para>
    /// <para><b>Note:</b> Native popup is only supported if <see cref="Godot.NativeMenu"/> supports the <see cref="Godot.NativeMenu.Feature.PopupMenu"/> feature.</para>
    /// </summary>
    public static void StatusIndicatorSetMenu(int id, Rid menuRid)
    {
        NativeCalls.godot_icall_2_449(MethodBind257, GodotObject.GetPtr(Singleton), id, menuRid);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind258 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.StatusIndicatorSetCallback, 957362965ul);

    /// <summary>
    /// <para>Sets the application status indicator activation callback. <paramref name="callback"/> should take two arguments: <see cref="int"/> mouse button index (one of <see cref="Godot.MouseButton"/> values) and <see cref="Godot.Vector2I"/> click position in screen coordinates.</para>
    /// <para><b>Note:</b> This method is implemented on macOS and Windows.</para>
    /// </summary>
    public static void StatusIndicatorSetCallback(int id, Callable callback)
    {
        NativeCalls.godot_icall_2_402(MethodBind258, GodotObject.GetPtr(Singleton), id, callback);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind259 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.StatusIndicatorGetRect, 3327874267ul);

    /// <summary>
    /// <para>Returns the rectangle for the given status indicator <paramref name="id"/> in screen coordinates. If the status indicator is not visible, returns an empty <see cref="Godot.Rect2"/>.</para>
    /// <para><b>Note:</b> This method is implemented on macOS and Windows.</para>
    /// </summary>
    public static Rect2 StatusIndicatorGetRect(int id)
    {
        return NativeCalls.godot_icall_1_450(MethodBind259, GodotObject.GetPtr(Singleton), id);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind260 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.DeleteStatusIndicator, 1286410249ul);

    /// <summary>
    /// <para>Removes the application status indicator.</para>
    /// </summary>
    public static void DeleteStatusIndicator(int id)
    {
        NativeCalls.godot_icall_1_38(MethodBind260, GodotObject.GetPtr(Singleton), id);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind261 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.TabletGetDriverCount, 3905245786ul);

    /// <summary>
    /// <para>Returns the total number of available tablet drivers.</para>
    /// <para><b>Note:</b> This method is implemented only on Windows.</para>
    /// </summary>
    public static int TabletGetDriverCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind261, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind262 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.TabletGetDriverName, 844755477ul);

    /// <summary>
    /// <para>Returns the tablet driver name for the given index.</para>
    /// <para><b>Note:</b> This method is implemented only on Windows.</para>
    /// </summary>
    public static string TabletGetDriverName(int idx)
    {
        return NativeCalls.godot_icall_1_133(MethodBind262, GodotObject.GetPtr(Singleton), idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind263 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.TabletGetCurrentDriver, 201670096ul);

    /// <summary>
    /// <para>Returns current active tablet driver name.</para>
    /// <para><b>Note:</b> This method is implemented only on Windows.</para>
    /// </summary>
    public static string TabletGetCurrentDriver()
    {
        return NativeCalls.godot_icall_0_58(MethodBind263, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind264 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.TabletSetCurrentDriver, 83702148ul);

    /// <summary>
    /// <para>Set active tablet driver name.</para>
    /// <para>Supported drivers:</para>
    /// <para>- <c>winink</c>: Windows Ink API, default.</para>
    /// <para>- <c>wintab</c>: Wacom Wintab API (compatible device driver required).</para>
    /// <para>- <c>dummy</c>: Dummy driver, tablet input is disabled.</para>
    /// <para><b>Note:</b> This method is implemented only on Windows.</para>
    /// </summary>
    public static void TabletSetCurrentDriver(string name)
    {
        NativeCalls.godot_icall_1_57(MethodBind264, GodotObject.GetPtr(Singleton), name);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind265 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.IsWindowTransparencyAvailable, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the window background can be made transparent. This method returns <see langword="false"/> if <c>ProjectSettings.display/window/per_pixel_transparency/allowed</c> is set to <see langword="false"/>, or if transparency is not supported by the renderer or OS compositor.</para>
    /// </summary>
    public static bool IsWindowTransparencyAvailable()
    {
        return NativeCalls.godot_icall_0_15(MethodBind265, GodotObject.GetPtr(Singleton)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind266 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.RegisterAdditionalOutput, 3975164845ul);

    /// <summary>
    /// <para>Registers an <see cref="Godot.GodotObject"/> which represents an additional output that will be rendered too, beyond normal windows. The <see cref="Godot.GodotObject"/> is only used as an identifier, which can be later passed to <see cref="Godot.DisplayServer.UnregisterAdditionalOutput(GodotObject)"/>.</para>
    /// <para>This can be used to prevent Godot from skipping rendering when no normal windows are visible.</para>
    /// </summary>
    public static void RegisterAdditionalOutput(GodotObject @object)
    {
        NativeCalls.godot_icall_1_56(MethodBind266, GodotObject.GetPtr(Singleton), GodotObject.GetPtr(@object));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind267 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.UnregisterAdditionalOutput, 3975164845ul);

    /// <summary>
    /// <para>Unregisters an <see cref="Godot.GodotObject"/> representing an additional output, that was registered via <see cref="Godot.DisplayServer.RegisterAdditionalOutput(GodotObject)"/>.</para>
    /// </summary>
    public static void UnregisterAdditionalOutput(GodotObject @object)
    {
        NativeCalls.godot_icall_1_56(MethodBind267, GodotObject.GetPtr(Singleton), GodotObject.GetPtr(@object));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind268 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.HasAdditionalOutputs, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if any additional outputs have been registered via <see cref="Godot.DisplayServer.RegisterAdditionalOutput(GodotObject)"/>.</para>
    /// </summary>
    public static bool HasAdditionalOutputs()
    {
        return NativeCalls.godot_icall_0_15(MethodBind268, GodotObject.GetPtr(Singleton)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind269 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AccessibilityCreateSubTextEditElements, 3328635351ul);

    /// <summary>
    /// <para>Creates a new, empty accessibility sub-element from the shaped text buffer. Sub-elements are freed automatically when the parent element is freed, or can be freed early using the <see cref="Godot.DisplayServer.AccessibilityFreeElement(Rid)"/> method.</para>
    /// <para>If <paramref name="isLastLine"/> is <see langword="true"/>, no trailing newline is appended to the text content. Set to <see langword="true"/> for the last line in multi-line text fields and for single-line text fields.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static Rid AccessibilityCreateSubTextEditElements(Rid parentRid, Rid shapedText, float minHeight, int insertPos)
    {
        return NativeCalls.godot_icall_4_451(MethodBind269, GodotObject.GetPtr(Singleton), parentRid, shapedText, minHeight, insertPos);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind270 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.FileDialogWithOptionsShow, 1305318754ul);

    /// <summary>
    /// <para>Displays OS native dialog for selecting files or directories in the file system with additional user selectable options.</para>
    /// <para>Each filter string in the <paramref name="filters"/> array should be formatted like this: <c>*.png,*.jpg,*.jpeg;Image Files;image/png,image/jpeg</c>. The description text of the filter is optional and can be omitted. It is recommended to set both file extension and MIME type. See also <see cref="Godot.FileDialog.Filters"/>.</para>
    /// <para><paramref name="options"/> is array of <see cref="Godot.Collections.Dictionary"/>s with the following keys:</para>
    /// <para>- <c>"name"</c> - option's name <see cref="string"/>.</para>
    /// <para>- <c>"values"</c> - <see cref="string"/>[] of values. If empty, boolean option (check box) is used.</para>
    /// <para>- <c>"default"</c> - default selected option index (<see cref="int"/>) or default boolean value (<see cref="bool"/>).</para>
    /// <para>Callbacks have the following arguments: <c>status: bool, selected_paths: PackedStringArray, selected_filter_index: int, selected_option: Dictionary</c>.</para>
    /// <para><b>Note:</b> This method is implemented if the display server has the <see cref="Godot.DisplayServer.Feature.NativeDialogFileExtra"/> feature. Supported platforms include Linux (X11/Wayland), Windows, and macOS.</para>
    /// <para><b>Note:</b> <paramref name="currentDirectory"/> might be ignored.</para>
    /// <para><b>Note:</b> Embedded file dialogs and Windows file dialogs support only file extensions, while Android, Linux, and macOS file dialogs also support MIME types.</para>
    /// <para><b>Note:</b> On Linux (X11), <paramref name="showHidden"/> is ignored.</para>
    /// <para><b>Note:</b> On macOS, native file dialogs have no title.</para>
    /// <para><b>Note:</b> On macOS, sandboxed apps will save security-scoped bookmarks to retain access to the opened folders across multiple sessions. Use <see cref="Godot.OS.GetGrantedPermissions()"/> to get a list of saved bookmarks.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static Error FileDialogWithOptionsShow(string title, string currentDirectory, string root, string fileName, bool showHidden, DisplayServer.FileDialogMode mode, string[] filters, Godot.Collections.Array<Godot.Collections.Dictionary> options, Callable callback)
    {
        return (Error)NativeCalls.godot_icall_9_452(MethodBind270, GodotObject.GetPtr(Singleton), title, currentDirectory, root, fileName, showHidden.ToGodotBool(), (int)mode, filters, (godot_array)(options ?? new()).NativeValue, callback);
    }

    /// <summary>
    /// <para>Displays OS native dialog for selecting files or directories in the file system with additional user selectable options.</para>
    /// <para>Each filter string in the <paramref name="filters"/> array should be formatted like this: <c>*.png,*.jpg,*.jpeg;Image Files;image/png,image/jpeg</c>. The description text of the filter is optional and can be omitted. It is recommended to set both file extension and MIME type. See also <see cref="Godot.FileDialog.Filters"/>.</para>
    /// <para><paramref name="options"/> is array of <see cref="Godot.Collections.Dictionary"/>s with the following keys:</para>
    /// <para>- <c>"name"</c> - option's name <see cref="string"/>.</para>
    /// <para>- <c>"values"</c> - <see cref="string"/>[] of values. If empty, boolean option (check box) is used.</para>
    /// <para>- <c>"default"</c> - default selected option index (<see cref="int"/>) or default boolean value (<see cref="bool"/>).</para>
    /// <para>Callbacks have the following arguments: <c>status: bool, selected_paths: PackedStringArray, selected_filter_index: int, selected_option: Dictionary</c>.</para>
    /// <para><b>Note:</b> This method is implemented if the display server has the <see cref="Godot.DisplayServer.Feature.NativeDialogFileExtra"/> feature. Supported platforms include Linux (X11/Wayland), Windows, and macOS.</para>
    /// <para><b>Note:</b> <paramref name="currentDirectory"/> might be ignored.</para>
    /// <para><b>Note:</b> Embedded file dialogs and Windows file dialogs support only file extensions, while Android, Linux, and macOS file dialogs also support MIME types.</para>
    /// <para><b>Note:</b> On Linux (X11), <paramref name="showHidden"/> is ignored.</para>
    /// <para><b>Note:</b> On macOS, native file dialogs have no title.</para>
    /// <para><b>Note:</b> On macOS, sandboxed apps will save security-scoped bookmarks to retain access to the opened folders across multiple sessions. Use <see cref="Godot.OS.GetGrantedPermissions()"/> to get a list of saved bookmarks.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static Error FileDialogWithOptionsShow(string title, string currentDirectory, string root, string fileName, bool showHidden, DisplayServer.FileDialogMode mode, ReadOnlySpan<string> filters, Godot.Collections.Array<Godot.Collections.Dictionary> options, Callable callback)
    {
        return (Error)NativeCalls.godot_icall_9_452(MethodBind270, GodotObject.GetPtr(Singleton), title, currentDirectory, root, fileName, showHidden.ToGodotBool(), (int)mode, filters, (godot_array)(options ?? new()).NativeValue, callback);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind271 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.FileDialogShow, 1531299078ul);

    /// <summary>
    /// <para>Displays OS native dialog for selecting files or directories in the file system.</para>
    /// <para>Each filter string in the <paramref name="filters"/> array should be formatted like this: <c>*.png,*.jpg,*.jpeg;Image Files;image/png,image/jpeg</c>. The description text of the filter is optional and can be omitted. It is recommended to set both file extension and MIME type. See also <see cref="Godot.FileDialog.Filters"/>.</para>
    /// <para>Callbacks have the following arguments: <c>status: bool, selected_paths: PackedStringArray, selected_filter_index: int</c>. <b>On Android,</b> the third callback argument (<c>selected_filter_index</c>) is always <c>0</c>.</para>
    /// <para><b>Note:</b> This method is implemented if the display server has the <see cref="Godot.DisplayServer.Feature.NativeDialogFile"/> feature. Supported platforms include Linux (X11/Wayland), Windows, macOS, and Android (API level 29+).</para>
    /// <para><b>Note:</b> <paramref name="currentDirectory"/> might be ignored.</para>
    /// <para><b>Note:</b> Embedded file dialogs and Windows file dialogs support only file extensions, while Android, Linux, and macOS file dialogs also support MIME types.</para>
    /// <para><b>Note:</b> On Android and Linux, <paramref name="showHidden"/> is ignored.</para>
    /// <para><b>Note:</b> On Android and macOS, native file dialogs have no title.</para>
    /// <para><b>Note:</b> On macOS, sandboxed apps will save security-scoped bookmarks to retain access to the opened folders across multiple sessions. Use <see cref="Godot.OS.GetGrantedPermissions()"/> to get a list of saved bookmarks.</para>
    /// <para><b>Note:</b> On Android, this method uses the Android Storage Access Framework (SAF).</para>
    /// <para>The file picker returns a URI instead of a filesystem path. This URI can be passed directly to <see cref="Godot.FileAccess"/> to perform read/write operations.</para>
    /// <para>When using <see cref="Godot.DisplayServer.FileDialogMode.OpenDir"/>, it returns a tree URI that grants full access to the selected directory. File operations inside this directory can be performed by passing a path on the form <c>treeUri#relative/path/to/file</c> to <see cref="Godot.FileAccess"/>.</para>
    /// <para>To avoid opening the file picker again after each app restart, you can take persistable URI permission as follows:</para>
    /// <para></para>
    /// <para>The persistable URI permission remains valid across app restarts as long as the directory is not moved, renamed, or deleted.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static Error FileDialogShow(string title, string currentDirectory, string fileName, bool showHidden, DisplayServer.FileDialogMode mode, string[] filters, Callable callback)
    {
        return (Error)NativeCalls.godot_icall_7_453(MethodBind271, GodotObject.GetPtr(Singleton), title, currentDirectory, fileName, showHidden.ToGodotBool(), (int)mode, filters, callback);
    }

    /// <summary>
    /// <para>Displays OS native dialog for selecting files or directories in the file system.</para>
    /// <para>Each filter string in the <paramref name="filters"/> array should be formatted like this: <c>*.png,*.jpg,*.jpeg;Image Files;image/png,image/jpeg</c>. The description text of the filter is optional and can be omitted. It is recommended to set both file extension and MIME type. See also <see cref="Godot.FileDialog.Filters"/>.</para>
    /// <para>Callbacks have the following arguments: <c>status: bool, selected_paths: PackedStringArray, selected_filter_index: int</c>. <b>On Android,</b> the third callback argument (<c>selected_filter_index</c>) is always <c>0</c>.</para>
    /// <para><b>Note:</b> This method is implemented if the display server has the <see cref="Godot.DisplayServer.Feature.NativeDialogFile"/> feature. Supported platforms include Linux (X11/Wayland), Windows, macOS, and Android (API level 29+).</para>
    /// <para><b>Note:</b> <paramref name="currentDirectory"/> might be ignored.</para>
    /// <para><b>Note:</b> Embedded file dialogs and Windows file dialogs support only file extensions, while Android, Linux, and macOS file dialogs also support MIME types.</para>
    /// <para><b>Note:</b> On Android and Linux, <paramref name="showHidden"/> is ignored.</para>
    /// <para><b>Note:</b> On Android and macOS, native file dialogs have no title.</para>
    /// <para><b>Note:</b> On macOS, sandboxed apps will save security-scoped bookmarks to retain access to the opened folders across multiple sessions. Use <see cref="Godot.OS.GetGrantedPermissions()"/> to get a list of saved bookmarks.</para>
    /// <para><b>Note:</b> On Android, this method uses the Android Storage Access Framework (SAF).</para>
    /// <para>The file picker returns a URI instead of a filesystem path. This URI can be passed directly to <see cref="Godot.FileAccess"/> to perform read/write operations.</para>
    /// <para>When using <see cref="Godot.DisplayServer.FileDialogMode.OpenDir"/>, it returns a tree URI that grants full access to the selected directory. File operations inside this directory can be performed by passing a path on the form <c>treeUri#relative/path/to/file</c> to <see cref="Godot.FileAccess"/>.</para>
    /// <para>To avoid opening the file picker again after each app restart, you can take persistable URI permission as follows:</para>
    /// <para></para>
    /// <para>The persistable URI permission remains valid across app restarts as long as the directory is not moved, renamed, or deleted.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static Error FileDialogShow(string title, string currentDirectory, string fileName, bool showHidden, DisplayServer.FileDialogMode mode, ReadOnlySpan<string> filters, Callable callback)
    {
        return (Error)NativeCalls.godot_icall_7_453(MethodBind271, GodotObject.GetPtr(Singleton), title, currentDirectory, fileName, showHidden.ToGodotBool(), (int)mode, filters, callback);
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public class PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public class MethodName
    {
        /// <summary>
        /// Cached name for the 'has_feature' method.
        /// </summary>
        public static readonly StringName HasFeature = "has_feature";
        /// <summary>
        /// Cached name for the 'get_name' method.
        /// </summary>
        public static readonly StringName GetName = "get_name";
        /// <summary>
        /// Cached name for the 'help_set_search_callbacks' method.
        /// </summary>
        public static readonly StringName HelpSetSearchCallbacks = "help_set_search_callbacks";
        /// <summary>
        /// Cached name for the 'global_menu_set_popup_callbacks' method.
        /// </summary>
        public static readonly StringName GlobalMenuSetPopupCallbacks = "global_menu_set_popup_callbacks";
        /// <summary>
        /// Cached name for the 'global_menu_add_submenu_item' method.
        /// </summary>
        public static readonly StringName GlobalMenuAddSubmenuItem = "global_menu_add_submenu_item";
        /// <summary>
        /// Cached name for the 'global_menu_add_item' method.
        /// </summary>
        public static readonly StringName GlobalMenuAddItem = "global_menu_add_item";
        /// <summary>
        /// Cached name for the 'global_menu_add_check_item' method.
        /// </summary>
        public static readonly StringName GlobalMenuAddCheckItem = "global_menu_add_check_item";
        /// <summary>
        /// Cached name for the 'global_menu_add_icon_item' method.
        /// </summary>
        public static readonly StringName GlobalMenuAddIconItem = "global_menu_add_icon_item";
        /// <summary>
        /// Cached name for the 'global_menu_add_icon_check_item' method.
        /// </summary>
        public static readonly StringName GlobalMenuAddIconCheckItem = "global_menu_add_icon_check_item";
        /// <summary>
        /// Cached name for the 'global_menu_add_radio_check_item' method.
        /// </summary>
        public static readonly StringName GlobalMenuAddRadioCheckItem = "global_menu_add_radio_check_item";
        /// <summary>
        /// Cached name for the 'global_menu_add_icon_radio_check_item' method.
        /// </summary>
        public static readonly StringName GlobalMenuAddIconRadioCheckItem = "global_menu_add_icon_radio_check_item";
        /// <summary>
        /// Cached name for the 'global_menu_add_multistate_item' method.
        /// </summary>
        public static readonly StringName GlobalMenuAddMultistateItem = "global_menu_add_multistate_item";
        /// <summary>
        /// Cached name for the 'global_menu_add_separator' method.
        /// </summary>
        public static readonly StringName GlobalMenuAddSeparator = "global_menu_add_separator";
        /// <summary>
        /// Cached name for the 'global_menu_get_item_index_from_text' method.
        /// </summary>
        public static readonly StringName GlobalMenuGetItemIndexFromText = "global_menu_get_item_index_from_text";
        /// <summary>
        /// Cached name for the 'global_menu_get_item_index_from_tag' method.
        /// </summary>
        public static readonly StringName GlobalMenuGetItemIndexFromTag = "global_menu_get_item_index_from_tag";
        /// <summary>
        /// Cached name for the 'global_menu_is_item_checked' method.
        /// </summary>
        public static readonly StringName GlobalMenuIsItemChecked = "global_menu_is_item_checked";
        /// <summary>
        /// Cached name for the 'global_menu_is_item_checkable' method.
        /// </summary>
        public static readonly StringName GlobalMenuIsItemCheckable = "global_menu_is_item_checkable";
        /// <summary>
        /// Cached name for the 'global_menu_is_item_radio_checkable' method.
        /// </summary>
        public static readonly StringName GlobalMenuIsItemRadioCheckable = "global_menu_is_item_radio_checkable";
        /// <summary>
        /// Cached name for the 'global_menu_get_item_callback' method.
        /// </summary>
        public static readonly StringName GlobalMenuGetItemCallback = "global_menu_get_item_callback";
        /// <summary>
        /// Cached name for the 'global_menu_get_item_key_callback' method.
        /// </summary>
        public static readonly StringName GlobalMenuGetItemKeyCallback = "global_menu_get_item_key_callback";
        /// <summary>
        /// Cached name for the 'global_menu_get_item_tag' method.
        /// </summary>
        public static readonly StringName GlobalMenuGetItemTag = "global_menu_get_item_tag";
        /// <summary>
        /// Cached name for the 'global_menu_get_item_text' method.
        /// </summary>
        public static readonly StringName GlobalMenuGetItemText = "global_menu_get_item_text";
        /// <summary>
        /// Cached name for the 'global_menu_get_item_submenu' method.
        /// </summary>
        public static readonly StringName GlobalMenuGetItemSubmenu = "global_menu_get_item_submenu";
        /// <summary>
        /// Cached name for the 'global_menu_get_item_accelerator' method.
        /// </summary>
        public static readonly StringName GlobalMenuGetItemAccelerator = "global_menu_get_item_accelerator";
        /// <summary>
        /// Cached name for the 'global_menu_is_item_disabled' method.
        /// </summary>
        public static readonly StringName GlobalMenuIsItemDisabled = "global_menu_is_item_disabled";
        /// <summary>
        /// Cached name for the 'global_menu_is_item_hidden' method.
        /// </summary>
        public static readonly StringName GlobalMenuIsItemHidden = "global_menu_is_item_hidden";
        /// <summary>
        /// Cached name for the 'global_menu_get_item_tooltip' method.
        /// </summary>
        public static readonly StringName GlobalMenuGetItemTooltip = "global_menu_get_item_tooltip";
        /// <summary>
        /// Cached name for the 'global_menu_get_item_state' method.
        /// </summary>
        public static readonly StringName GlobalMenuGetItemState = "global_menu_get_item_state";
        /// <summary>
        /// Cached name for the 'global_menu_get_item_max_states' method.
        /// </summary>
        public static readonly StringName GlobalMenuGetItemMaxStates = "global_menu_get_item_max_states";
        /// <summary>
        /// Cached name for the 'global_menu_get_item_icon' method.
        /// </summary>
        public static readonly StringName GlobalMenuGetItemIcon = "global_menu_get_item_icon";
        /// <summary>
        /// Cached name for the 'global_menu_get_item_indentation_level' method.
        /// </summary>
        public static readonly StringName GlobalMenuGetItemIndentationLevel = "global_menu_get_item_indentation_level";
        /// <summary>
        /// Cached name for the 'global_menu_set_item_checked' method.
        /// </summary>
        public static readonly StringName GlobalMenuSetItemChecked = "global_menu_set_item_checked";
        /// <summary>
        /// Cached name for the 'global_menu_set_item_checkable' method.
        /// </summary>
        public static readonly StringName GlobalMenuSetItemCheckable = "global_menu_set_item_checkable";
        /// <summary>
        /// Cached name for the 'global_menu_set_item_radio_checkable' method.
        /// </summary>
        public static readonly StringName GlobalMenuSetItemRadioCheckable = "global_menu_set_item_radio_checkable";
        /// <summary>
        /// Cached name for the 'global_menu_set_item_callback' method.
        /// </summary>
        public static readonly StringName GlobalMenuSetItemCallback = "global_menu_set_item_callback";
        /// <summary>
        /// Cached name for the 'global_menu_set_item_hover_callbacks' method.
        /// </summary>
        public static readonly StringName GlobalMenuSetItemHoverCallbacks = "global_menu_set_item_hover_callbacks";
        /// <summary>
        /// Cached name for the 'global_menu_set_item_key_callback' method.
        /// </summary>
        public static readonly StringName GlobalMenuSetItemKeyCallback = "global_menu_set_item_key_callback";
        /// <summary>
        /// Cached name for the 'global_menu_set_item_tag' method.
        /// </summary>
        public static readonly StringName GlobalMenuSetItemTag = "global_menu_set_item_tag";
        /// <summary>
        /// Cached name for the 'global_menu_set_item_text' method.
        /// </summary>
        public static readonly StringName GlobalMenuSetItemText = "global_menu_set_item_text";
        /// <summary>
        /// Cached name for the 'global_menu_set_item_submenu' method.
        /// </summary>
        public static readonly StringName GlobalMenuSetItemSubmenu = "global_menu_set_item_submenu";
        /// <summary>
        /// Cached name for the 'global_menu_set_item_accelerator' method.
        /// </summary>
        public static readonly StringName GlobalMenuSetItemAccelerator = "global_menu_set_item_accelerator";
        /// <summary>
        /// Cached name for the 'global_menu_set_item_disabled' method.
        /// </summary>
        public static readonly StringName GlobalMenuSetItemDisabled = "global_menu_set_item_disabled";
        /// <summary>
        /// Cached name for the 'global_menu_set_item_hidden' method.
        /// </summary>
        public static readonly StringName GlobalMenuSetItemHidden = "global_menu_set_item_hidden";
        /// <summary>
        /// Cached name for the 'global_menu_set_item_tooltip' method.
        /// </summary>
        public static readonly StringName GlobalMenuSetItemTooltip = "global_menu_set_item_tooltip";
        /// <summary>
        /// Cached name for the 'global_menu_set_item_state' method.
        /// </summary>
        public static readonly StringName GlobalMenuSetItemState = "global_menu_set_item_state";
        /// <summary>
        /// Cached name for the 'global_menu_set_item_max_states' method.
        /// </summary>
        public static readonly StringName GlobalMenuSetItemMaxStates = "global_menu_set_item_max_states";
        /// <summary>
        /// Cached name for the 'global_menu_set_item_icon' method.
        /// </summary>
        public static readonly StringName GlobalMenuSetItemIcon = "global_menu_set_item_icon";
        /// <summary>
        /// Cached name for the 'global_menu_set_item_indentation_level' method.
        /// </summary>
        public static readonly StringName GlobalMenuSetItemIndentationLevel = "global_menu_set_item_indentation_level";
        /// <summary>
        /// Cached name for the 'global_menu_get_item_count' method.
        /// </summary>
        public static readonly StringName GlobalMenuGetItemCount = "global_menu_get_item_count";
        /// <summary>
        /// Cached name for the 'global_menu_remove_item' method.
        /// </summary>
        public static readonly StringName GlobalMenuRemoveItem = "global_menu_remove_item";
        /// <summary>
        /// Cached name for the 'global_menu_clear' method.
        /// </summary>
        public static readonly StringName GlobalMenuClear = "global_menu_clear";
        /// <summary>
        /// Cached name for the 'global_menu_get_system_menu_roots' method.
        /// </summary>
        public static readonly StringName GlobalMenuGetSystemMenuRoots = "global_menu_get_system_menu_roots";
        /// <summary>
        /// Cached name for the 'tts_is_speaking' method.
        /// </summary>
        public static readonly StringName TtsIsSpeaking = "tts_is_speaking";
        /// <summary>
        /// Cached name for the 'tts_is_paused' method.
        /// </summary>
        public static readonly StringName TtsIsPaused = "tts_is_paused";
        /// <summary>
        /// Cached name for the 'tts_get_voices' method.
        /// </summary>
        public static readonly StringName TtsGetVoices = "tts_get_voices";
        /// <summary>
        /// Cached name for the 'tts_get_voices_for_language' method.
        /// </summary>
        public static readonly StringName TtsGetVoicesForLanguage = "tts_get_voices_for_language";
        /// <summary>
        /// Cached name for the 'tts_speak' method.
        /// </summary>
        public static readonly StringName TtsSpeak = "tts_speak";
        /// <summary>
        /// Cached name for the 'tts_pause' method.
        /// </summary>
        public static readonly StringName TtsPause = "tts_pause";
        /// <summary>
        /// Cached name for the 'tts_resume' method.
        /// </summary>
        public static readonly StringName TtsResume = "tts_resume";
        /// <summary>
        /// Cached name for the 'tts_stop' method.
        /// </summary>
        public static readonly StringName TtsStop = "tts_stop";
        /// <summary>
        /// Cached name for the 'tts_set_utterance_callback' method.
        /// </summary>
        public static readonly StringName TtsSetUtteranceCallback = "tts_set_utterance_callback";
        /// <summary>
        /// Cached name for the 'is_dark_mode_supported' method.
        /// </summary>
        public static readonly StringName IsDarkModeSupported = "is_dark_mode_supported";
        /// <summary>
        /// Cached name for the 'is_dark_mode' method.
        /// </summary>
        public static readonly StringName IsDarkMode = "is_dark_mode";
        /// <summary>
        /// Cached name for the 'get_accent_color' method.
        /// </summary>
        public static readonly StringName GetAccentColor = "get_accent_color";
        /// <summary>
        /// Cached name for the 'get_base_color' method.
        /// </summary>
        public static readonly StringName GetBaseColor = "get_base_color";
        /// <summary>
        /// Cached name for the 'set_system_theme_change_callback' method.
        /// </summary>
        public static readonly StringName SetSystemThemeChangeCallback = "set_system_theme_change_callback";
        /// <summary>
        /// Cached name for the 'mouse_set_mode' method.
        /// </summary>
        public static readonly StringName MouseSetMode = "mouse_set_mode";
        /// <summary>
        /// Cached name for the 'mouse_get_mode' method.
        /// </summary>
        public static readonly StringName MouseGetMode = "mouse_get_mode";
        /// <summary>
        /// Cached name for the 'warp_mouse' method.
        /// </summary>
        public static readonly StringName WarpMouse = "warp_mouse";
        /// <summary>
        /// Cached name for the 'mouse_get_position' method.
        /// </summary>
        public static readonly StringName MouseGetPosition = "mouse_get_position";
        /// <summary>
        /// Cached name for the 'mouse_get_button_state' method.
        /// </summary>
        public static readonly StringName MouseGetButtonState = "mouse_get_button_state";
        /// <summary>
        /// Cached name for the 'clipboard_set' method.
        /// </summary>
        public static readonly StringName ClipboardSet = "clipboard_set";
        /// <summary>
        /// Cached name for the 'clipboard_get' method.
        /// </summary>
        public static readonly StringName ClipboardGet = "clipboard_get";
        /// <summary>
        /// Cached name for the 'clipboard_get_image' method.
        /// </summary>
        public static readonly StringName ClipboardGetImage = "clipboard_get_image";
        /// <summary>
        /// Cached name for the 'clipboard_has' method.
        /// </summary>
        public static readonly StringName ClipboardHas = "clipboard_has";
        /// <summary>
        /// Cached name for the 'clipboard_has_image' method.
        /// </summary>
        public static readonly StringName ClipboardHasImage = "clipboard_has_image";
        /// <summary>
        /// Cached name for the 'clipboard_set_primary' method.
        /// </summary>
        public static readonly StringName ClipboardSetPrimary = "clipboard_set_primary";
        /// <summary>
        /// Cached name for the 'clipboard_get_primary' method.
        /// </summary>
        public static readonly StringName ClipboardGetPrimary = "clipboard_get_primary";
        /// <summary>
        /// Cached name for the 'get_display_cutouts' method.
        /// </summary>
        public static readonly StringName GetDisplayCutouts = "get_display_cutouts";
        /// <summary>
        /// Cached name for the 'get_display_safe_area' method.
        /// </summary>
        public static readonly StringName GetDisplaySafeArea = "get_display_safe_area";
        /// <summary>
        /// Cached name for the 'get_screen_count' method.
        /// </summary>
        public static readonly StringName GetScreenCount = "get_screen_count";
        /// <summary>
        /// Cached name for the 'get_primary_screen' method.
        /// </summary>
        public static readonly StringName GetPrimaryScreen = "get_primary_screen";
        /// <summary>
        /// Cached name for the 'get_keyboard_focus_screen' method.
        /// </summary>
        public static readonly StringName GetKeyboardFocusScreen = "get_keyboard_focus_screen";
        /// <summary>
        /// Cached name for the 'get_screen_from_rect' method.
        /// </summary>
        public static readonly StringName GetScreenFromRect = "get_screen_from_rect";
        /// <summary>
        /// Cached name for the 'screen_get_position' method.
        /// </summary>
        public static readonly StringName ScreenGetPosition = "screen_get_position";
        /// <summary>
        /// Cached name for the 'screen_get_size' method.
        /// </summary>
        public static readonly StringName ScreenGetSize = "screen_get_size";
        /// <summary>
        /// Cached name for the 'screen_get_usable_rect' method.
        /// </summary>
        public static readonly StringName ScreenGetUsableRect = "screen_get_usable_rect";
        /// <summary>
        /// Cached name for the 'screen_get_dpi' method.
        /// </summary>
        public static readonly StringName ScreenGetDpi = "screen_get_dpi";
        /// <summary>
        /// Cached name for the 'screen_get_scale' method.
        /// </summary>
        public static readonly StringName ScreenGetScale = "screen_get_scale";
        /// <summary>
        /// Cached name for the 'is_touchscreen_available' method.
        /// </summary>
        public static readonly StringName IsTouchscreenAvailable = "is_touchscreen_available";
        /// <summary>
        /// Cached name for the 'screen_get_max_scale' method.
        /// </summary>
        public static readonly StringName ScreenGetMaxScale = "screen_get_max_scale";
        /// <summary>
        /// Cached name for the 'screen_get_refresh_rate' method.
        /// </summary>
        public static readonly StringName ScreenGetRefreshRate = "screen_get_refresh_rate";
        /// <summary>
        /// Cached name for the 'screen_get_pixel' method.
        /// </summary>
        public static readonly StringName ScreenGetPixel = "screen_get_pixel";
        /// <summary>
        /// Cached name for the 'screen_get_image' method.
        /// </summary>
        public static readonly StringName ScreenGetImage = "screen_get_image";
        /// <summary>
        /// Cached name for the 'screen_get_image_rect' method.
        /// </summary>
        public static readonly StringName ScreenGetImageRect = "screen_get_image_rect";
        /// <summary>
        /// Cached name for the 'screen_set_orientation' method.
        /// </summary>
        public static readonly StringName ScreenSetOrientation = "screen_set_orientation";
        /// <summary>
        /// Cached name for the 'screen_get_orientation' method.
        /// </summary>
        public static readonly StringName ScreenGetOrientation = "screen_get_orientation";
        /// <summary>
        /// Cached name for the 'screen_set_keep_on' method.
        /// </summary>
        public static readonly StringName ScreenSetKeepOn = "screen_set_keep_on";
        /// <summary>
        /// Cached name for the 'screen_is_kept_on' method.
        /// </summary>
        public static readonly StringName ScreenIsKeptOn = "screen_is_kept_on";
        /// <summary>
        /// Cached name for the 'get_window_list' method.
        /// </summary>
        public static readonly StringName GetWindowList = "get_window_list";
        /// <summary>
        /// Cached name for the 'get_window_at_screen_position' method.
        /// </summary>
        public static readonly StringName GetWindowAtScreenPosition = "get_window_at_screen_position";
        /// <summary>
        /// Cached name for the 'window_get_native_handle' method.
        /// </summary>
        public static readonly StringName WindowGetNativeHandle = "window_get_native_handle";
        /// <summary>
        /// Cached name for the 'window_get_active_popup' method.
        /// </summary>
        public static readonly StringName WindowGetActivePopup = "window_get_active_popup";
        /// <summary>
        /// Cached name for the 'window_set_popup_safe_rect' method.
        /// </summary>
        public static readonly StringName WindowSetPopupSafeRect = "window_set_popup_safe_rect";
        /// <summary>
        /// Cached name for the 'window_get_popup_safe_rect' method.
        /// </summary>
        public static readonly StringName WindowGetPopupSafeRect = "window_get_popup_safe_rect";
        /// <summary>
        /// Cached name for the 'window_set_title' method.
        /// </summary>
        public static readonly StringName WindowSetTitle = "window_set_title";
        /// <summary>
        /// Cached name for the 'window_get_title_size' method.
        /// </summary>
        public static readonly StringName WindowGetTitleSize = "window_get_title_size";
        /// <summary>
        /// Cached name for the 'window_set_mouse_passthrough' method.
        /// </summary>
        public static readonly StringName WindowSetMousePassthrough = "window_set_mouse_passthrough";
        /// <summary>
        /// Cached name for the 'window_get_current_screen' method.
        /// </summary>
        public static readonly StringName WindowGetCurrentScreen = "window_get_current_screen";
        /// <summary>
        /// Cached name for the 'window_set_current_screen' method.
        /// </summary>
        public static readonly StringName WindowSetCurrentScreen = "window_set_current_screen";
        /// <summary>
        /// Cached name for the 'window_get_position' method.
        /// </summary>
        public static readonly StringName WindowGetPosition = "window_get_position";
        /// <summary>
        /// Cached name for the 'window_get_position_with_decorations' method.
        /// </summary>
        public static readonly StringName WindowGetPositionWithDecorations = "window_get_position_with_decorations";
        /// <summary>
        /// Cached name for the 'window_set_position' method.
        /// </summary>
        public static readonly StringName WindowSetPosition = "window_set_position";
        /// <summary>
        /// Cached name for the 'window_get_size' method.
        /// </summary>
        public static readonly StringName WindowGetSize = "window_get_size";
        /// <summary>
        /// Cached name for the 'window_set_size' method.
        /// </summary>
        public static readonly StringName WindowSetSize = "window_set_size";
        /// <summary>
        /// Cached name for the 'window_set_rect_changed_callback' method.
        /// </summary>
        public static readonly StringName WindowSetRectChangedCallback = "window_set_rect_changed_callback";
        /// <summary>
        /// Cached name for the 'window_set_window_event_callback' method.
        /// </summary>
        public static readonly StringName WindowSetWindowEventCallback = "window_set_window_event_callback";
        /// <summary>
        /// Cached name for the 'window_set_input_event_callback' method.
        /// </summary>
        public static readonly StringName WindowSetInputEventCallback = "window_set_input_event_callback";
        /// <summary>
        /// Cached name for the 'window_set_input_text_callback' method.
        /// </summary>
        public static readonly StringName WindowSetInputTextCallback = "window_set_input_text_callback";
        /// <summary>
        /// Cached name for the 'window_set_drop_files_callback' method.
        /// </summary>
        public static readonly StringName WindowSetDropFilesCallback = "window_set_drop_files_callback";
        /// <summary>
        /// Cached name for the 'window_get_attached_instance_id' method.
        /// </summary>
        public static readonly StringName WindowGetAttachedInstanceId = "window_get_attached_instance_id";
        /// <summary>
        /// Cached name for the 'window_get_max_size' method.
        /// </summary>
        public static readonly StringName WindowGetMaxSize = "window_get_max_size";
        /// <summary>
        /// Cached name for the 'window_set_max_size' method.
        /// </summary>
        public static readonly StringName WindowSetMaxSize = "window_set_max_size";
        /// <summary>
        /// Cached name for the 'window_get_min_size' method.
        /// </summary>
        public static readonly StringName WindowGetMinSize = "window_get_min_size";
        /// <summary>
        /// Cached name for the 'window_set_min_size' method.
        /// </summary>
        public static readonly StringName WindowSetMinSize = "window_set_min_size";
        /// <summary>
        /// Cached name for the 'window_get_size_with_decorations' method.
        /// </summary>
        public static readonly StringName WindowGetSizeWithDecorations = "window_get_size_with_decorations";
        /// <summary>
        /// Cached name for the 'window_get_mode' method.
        /// </summary>
        public static readonly StringName WindowGetMode = "window_get_mode";
        /// <summary>
        /// Cached name for the 'window_set_mode' method.
        /// </summary>
        public static readonly StringName WindowSetMode = "window_set_mode";
        /// <summary>
        /// Cached name for the 'window_set_flag' method.
        /// </summary>
        public static readonly StringName WindowSetFlag = "window_set_flag";
        /// <summary>
        /// Cached name for the 'window_get_flag' method.
        /// </summary>
        public static readonly StringName WindowGetFlag = "window_get_flag";
        /// <summary>
        /// Cached name for the 'window_set_window_buttons_offset' method.
        /// </summary>
        public static readonly StringName WindowSetWindowButtonsOffset = "window_set_window_buttons_offset";
        /// <summary>
        /// Cached name for the 'window_get_safe_title_margins' method.
        /// </summary>
        public static readonly StringName WindowGetSafeTitleMargins = "window_get_safe_title_margins";
        /// <summary>
        /// Cached name for the 'window_request_attention' method.
        /// </summary>
        public static readonly StringName WindowRequestAttention = "window_request_attention";
        /// <summary>
        /// Cached name for the 'window_move_to_foreground' method.
        /// </summary>
        public static readonly StringName WindowMoveToForeground = "window_move_to_foreground";
        /// <summary>
        /// Cached name for the 'window_is_focused' method.
        /// </summary>
        public static readonly StringName WindowIsFocused = "window_is_focused";
        /// <summary>
        /// Cached name for the 'window_can_draw' method.
        /// </summary>
        public static readonly StringName WindowCanDraw = "window_can_draw";
        /// <summary>
        /// Cached name for the 'window_set_transient' method.
        /// </summary>
        public static readonly StringName WindowSetTransient = "window_set_transient";
        /// <summary>
        /// Cached name for the 'window_set_exclusive' method.
        /// </summary>
        public static readonly StringName WindowSetExclusive = "window_set_exclusive";
        /// <summary>
        /// Cached name for the 'window_set_ime_active' method.
        /// </summary>
        public static readonly StringName WindowSetImeActive = "window_set_ime_active";
        /// <summary>
        /// Cached name for the 'window_set_ime_position' method.
        /// </summary>
        public static readonly StringName WindowSetImePosition = "window_set_ime_position";
        /// <summary>
        /// Cached name for the 'window_set_vsync_mode' method.
        /// </summary>
        public static readonly StringName WindowSetVsyncMode = "window_set_vsync_mode";
        /// <summary>
        /// Cached name for the 'window_get_vsync_mode' method.
        /// </summary>
        public static readonly StringName WindowGetVsyncMode = "window_get_vsync_mode";
        /// <summary>
        /// Cached name for the 'window_is_maximize_allowed' method.
        /// </summary>
        public static readonly StringName WindowIsMaximizeAllowed = "window_is_maximize_allowed";
        /// <summary>
        /// Cached name for the 'window_maximize_on_title_dbl_click' method.
        /// </summary>
        public static readonly StringName WindowMaximizeOnTitleDblClick = "window_maximize_on_title_dbl_click";
        /// <summary>
        /// Cached name for the 'window_minimize_on_title_dbl_click' method.
        /// </summary>
        public static readonly StringName WindowMinimizeOnTitleDblClick = "window_minimize_on_title_dbl_click";
        /// <summary>
        /// Cached name for the 'window_start_drag' method.
        /// </summary>
        public static readonly StringName WindowStartDrag = "window_start_drag";
        /// <summary>
        /// Cached name for the 'window_start_resize' method.
        /// </summary>
        public static readonly StringName WindowStartResize = "window_start_resize";
        /// <summary>
        /// Cached name for the 'window_set_color' method.
        /// </summary>
        public static readonly StringName WindowSetColor = "window_set_color";
        /// <summary>
        /// Cached name for the 'accessibility_should_increase_contrast' method.
        /// </summary>
        public static readonly StringName AccessibilityShouldIncreaseContrast = "accessibility_should_increase_contrast";
        /// <summary>
        /// Cached name for the 'accessibility_should_reduce_animation' method.
        /// </summary>
        public static readonly StringName AccessibilityShouldReduceAnimation = "accessibility_should_reduce_animation";
        /// <summary>
        /// Cached name for the 'accessibility_should_reduce_transparency' method.
        /// </summary>
        public static readonly StringName AccessibilityShouldReduceTransparency = "accessibility_should_reduce_transparency";
        /// <summary>
        /// Cached name for the 'accessibility_screen_reader_active' method.
        /// </summary>
        public static readonly StringName AccessibilityScreenReaderActive = "accessibility_screen_reader_active";
        /// <summary>
        /// Cached name for the 'accessibility_create_element' method.
        /// </summary>
        public static readonly StringName AccessibilityCreateElement = "accessibility_create_element";
        /// <summary>
        /// Cached name for the 'accessibility_create_sub_element' method.
        /// </summary>
        public static readonly StringName AccessibilityCreateSubElement = "accessibility_create_sub_element";
        /// <summary>
        /// Cached name for the 'accessibility_create_sub_text_edit_elements' method.
        /// </summary>
        public static readonly StringName AccessibilityCreateSubTextEditElements = "accessibility_create_sub_text_edit_elements";
        /// <summary>
        /// Cached name for the 'accessibility_has_element' method.
        /// </summary>
        public static readonly StringName AccessibilityHasElement = "accessibility_has_element";
        /// <summary>
        /// Cached name for the 'accessibility_free_element' method.
        /// </summary>
        public static readonly StringName AccessibilityFreeElement = "accessibility_free_element";
        /// <summary>
        /// Cached name for the 'accessibility_element_set_meta' method.
        /// </summary>
        public static readonly StringName AccessibilityElementSetMeta = "accessibility_element_set_meta";
        /// <summary>
        /// Cached name for the 'accessibility_element_get_meta' method.
        /// </summary>
        public static readonly StringName AccessibilityElementGetMeta = "accessibility_element_get_meta";
        /// <summary>
        /// Cached name for the 'accessibility_set_window_rect' method.
        /// </summary>
        public static readonly StringName AccessibilitySetWindowRect = "accessibility_set_window_rect";
        /// <summary>
        /// Cached name for the 'accessibility_set_window_focused' method.
        /// </summary>
        public static readonly StringName AccessibilitySetWindowFocused = "accessibility_set_window_focused";
        /// <summary>
        /// Cached name for the 'accessibility_update_set_focus' method.
        /// </summary>
        public static readonly StringName AccessibilityUpdateSetFocus = "accessibility_update_set_focus";
        /// <summary>
        /// Cached name for the 'accessibility_get_window_root' method.
        /// </summary>
        public static readonly StringName AccessibilityGetWindowRoot = "accessibility_get_window_root";
        /// <summary>
        /// Cached name for the 'accessibility_update_set_role' method.
        /// </summary>
        public static readonly StringName AccessibilityUpdateSetRole = "accessibility_update_set_role";
        /// <summary>
        /// Cached name for the 'accessibility_update_set_name' method.
        /// </summary>
        public static readonly StringName AccessibilityUpdateSetName = "accessibility_update_set_name";
        /// <summary>
        /// Cached name for the 'accessibility_update_set_extra_info' method.
        /// </summary>
        public static readonly StringName AccessibilityUpdateSetExtraInfo = "accessibility_update_set_extra_info";
        /// <summary>
        /// Cached name for the 'accessibility_update_set_description' method.
        /// </summary>
        public static readonly StringName AccessibilityUpdateSetDescription = "accessibility_update_set_description";
        /// <summary>
        /// Cached name for the 'accessibility_update_set_value' method.
        /// </summary>
        public static readonly StringName AccessibilityUpdateSetValue = "accessibility_update_set_value";
        /// <summary>
        /// Cached name for the 'accessibility_update_set_tooltip' method.
        /// </summary>
        public static readonly StringName AccessibilityUpdateSetTooltip = "accessibility_update_set_tooltip";
        /// <summary>
        /// Cached name for the 'accessibility_update_set_bounds' method.
        /// </summary>
        public static readonly StringName AccessibilityUpdateSetBounds = "accessibility_update_set_bounds";
        /// <summary>
        /// Cached name for the 'accessibility_update_set_transform' method.
        /// </summary>
        public static readonly StringName AccessibilityUpdateSetTransform = "accessibility_update_set_transform";
        /// <summary>
        /// Cached name for the 'accessibility_update_add_child' method.
        /// </summary>
        public static readonly StringName AccessibilityUpdateAddChild = "accessibility_update_add_child";
        /// <summary>
        /// Cached name for the 'accessibility_update_add_related_controls' method.
        /// </summary>
        public static readonly StringName AccessibilityUpdateAddRelatedControls = "accessibility_update_add_related_controls";
        /// <summary>
        /// Cached name for the 'accessibility_update_add_related_details' method.
        /// </summary>
        public static readonly StringName AccessibilityUpdateAddRelatedDetails = "accessibility_update_add_related_details";
        /// <summary>
        /// Cached name for the 'accessibility_update_add_related_described_by' method.
        /// </summary>
        public static readonly StringName AccessibilityUpdateAddRelatedDescribedBy = "accessibility_update_add_related_described_by";
        /// <summary>
        /// Cached name for the 'accessibility_update_add_related_flow_to' method.
        /// </summary>
        public static readonly StringName AccessibilityUpdateAddRelatedFlowTo = "accessibility_update_add_related_flow_to";
        /// <summary>
        /// Cached name for the 'accessibility_update_add_related_labeled_by' method.
        /// </summary>
        public static readonly StringName AccessibilityUpdateAddRelatedLabeledBy = "accessibility_update_add_related_labeled_by";
        /// <summary>
        /// Cached name for the 'accessibility_update_add_related_radio_group' method.
        /// </summary>
        public static readonly StringName AccessibilityUpdateAddRelatedRadioGroup = "accessibility_update_add_related_radio_group";
        /// <summary>
        /// Cached name for the 'accessibility_update_set_active_descendant' method.
        /// </summary>
        public static readonly StringName AccessibilityUpdateSetActiveDescendant = "accessibility_update_set_active_descendant";
        /// <summary>
        /// Cached name for the 'accessibility_update_set_next_on_line' method.
        /// </summary>
        public static readonly StringName AccessibilityUpdateSetNextOnLine = "accessibility_update_set_next_on_line";
        /// <summary>
        /// Cached name for the 'accessibility_update_set_previous_on_line' method.
        /// </summary>
        public static readonly StringName AccessibilityUpdateSetPreviousOnLine = "accessibility_update_set_previous_on_line";
        /// <summary>
        /// Cached name for the 'accessibility_update_set_member_of' method.
        /// </summary>
        public static readonly StringName AccessibilityUpdateSetMemberOf = "accessibility_update_set_member_of";
        /// <summary>
        /// Cached name for the 'accessibility_update_set_in_page_link_target' method.
        /// </summary>
        public static readonly StringName AccessibilityUpdateSetInPageLinkTarget = "accessibility_update_set_in_page_link_target";
        /// <summary>
        /// Cached name for the 'accessibility_update_set_error_message' method.
        /// </summary>
        public static readonly StringName AccessibilityUpdateSetErrorMessage = "accessibility_update_set_error_message";
        /// <summary>
        /// Cached name for the 'accessibility_update_set_live' method.
        /// </summary>
        public static readonly StringName AccessibilityUpdateSetLive = "accessibility_update_set_live";
        /// <summary>
        /// Cached name for the 'accessibility_update_add_action' method.
        /// </summary>
        public static readonly StringName AccessibilityUpdateAddAction = "accessibility_update_add_action";
        /// <summary>
        /// Cached name for the 'accessibility_update_add_custom_action' method.
        /// </summary>
        public static readonly StringName AccessibilityUpdateAddCustomAction = "accessibility_update_add_custom_action";
        /// <summary>
        /// Cached name for the 'accessibility_update_set_table_row_count' method.
        /// </summary>
        public static readonly StringName AccessibilityUpdateSetTableRowCount = "accessibility_update_set_table_row_count";
        /// <summary>
        /// Cached name for the 'accessibility_update_set_table_column_count' method.
        /// </summary>
        public static readonly StringName AccessibilityUpdateSetTableColumnCount = "accessibility_update_set_table_column_count";
        /// <summary>
        /// Cached name for the 'accessibility_update_set_table_row_index' method.
        /// </summary>
        public static readonly StringName AccessibilityUpdateSetTableRowIndex = "accessibility_update_set_table_row_index";
        /// <summary>
        /// Cached name for the 'accessibility_update_set_table_column_index' method.
        /// </summary>
        public static readonly StringName AccessibilityUpdateSetTableColumnIndex = "accessibility_update_set_table_column_index";
        /// <summary>
        /// Cached name for the 'accessibility_update_set_table_cell_position' method.
        /// </summary>
        public static readonly StringName AccessibilityUpdateSetTableCellPosition = "accessibility_update_set_table_cell_position";
        /// <summary>
        /// Cached name for the 'accessibility_update_set_table_cell_span' method.
        /// </summary>
        public static readonly StringName AccessibilityUpdateSetTableCellSpan = "accessibility_update_set_table_cell_span";
        /// <summary>
        /// Cached name for the 'accessibility_update_set_list_item_count' method.
        /// </summary>
        public static readonly StringName AccessibilityUpdateSetListItemCount = "accessibility_update_set_list_item_count";
        /// <summary>
        /// Cached name for the 'accessibility_update_set_list_item_index' method.
        /// </summary>
        public static readonly StringName AccessibilityUpdateSetListItemIndex = "accessibility_update_set_list_item_index";
        /// <summary>
        /// Cached name for the 'accessibility_update_set_list_item_level' method.
        /// </summary>
        public static readonly StringName AccessibilityUpdateSetListItemLevel = "accessibility_update_set_list_item_level";
        /// <summary>
        /// Cached name for the 'accessibility_update_set_list_item_selected' method.
        /// </summary>
        public static readonly StringName AccessibilityUpdateSetListItemSelected = "accessibility_update_set_list_item_selected";
        /// <summary>
        /// Cached name for the 'accessibility_update_set_list_item_expanded' method.
        /// </summary>
        public static readonly StringName AccessibilityUpdateSetListItemExpanded = "accessibility_update_set_list_item_expanded";
        /// <summary>
        /// Cached name for the 'accessibility_update_set_popup_type' method.
        /// </summary>
        public static readonly StringName AccessibilityUpdateSetPopupType = "accessibility_update_set_popup_type";
        /// <summary>
        /// Cached name for the 'accessibility_update_set_checked' method.
        /// </summary>
        public static readonly StringName AccessibilityUpdateSetChecked = "accessibility_update_set_checked";
        /// <summary>
        /// Cached name for the 'accessibility_update_set_num_value' method.
        /// </summary>
        public static readonly StringName AccessibilityUpdateSetNumValue = "accessibility_update_set_num_value";
        /// <summary>
        /// Cached name for the 'accessibility_update_set_num_range' method.
        /// </summary>
        public static readonly StringName AccessibilityUpdateSetNumRange = "accessibility_update_set_num_range";
        /// <summary>
        /// Cached name for the 'accessibility_update_set_num_step' method.
        /// </summary>
        public static readonly StringName AccessibilityUpdateSetNumStep = "accessibility_update_set_num_step";
        /// <summary>
        /// Cached name for the 'accessibility_update_set_num_jump' method.
        /// </summary>
        public static readonly StringName AccessibilityUpdateSetNumJump = "accessibility_update_set_num_jump";
        /// <summary>
        /// Cached name for the 'accessibility_update_set_scroll_x' method.
        /// </summary>
        public static readonly StringName AccessibilityUpdateSetScrollX = "accessibility_update_set_scroll_x";
        /// <summary>
        /// Cached name for the 'accessibility_update_set_scroll_x_range' method.
        /// </summary>
        public static readonly StringName AccessibilityUpdateSetScrollXRange = "accessibility_update_set_scroll_x_range";
        /// <summary>
        /// Cached name for the 'accessibility_update_set_scroll_y' method.
        /// </summary>
        public static readonly StringName AccessibilityUpdateSetScrollY = "accessibility_update_set_scroll_y";
        /// <summary>
        /// Cached name for the 'accessibility_update_set_scroll_y_range' method.
        /// </summary>
        public static readonly StringName AccessibilityUpdateSetScrollYRange = "accessibility_update_set_scroll_y_range";
        /// <summary>
        /// Cached name for the 'accessibility_update_set_text_decorations' method.
        /// </summary>
        public static readonly StringName AccessibilityUpdateSetTextDecorations = "accessibility_update_set_text_decorations";
        /// <summary>
        /// Cached name for the 'accessibility_update_set_text_align' method.
        /// </summary>
        public static readonly StringName AccessibilityUpdateSetTextAlign = "accessibility_update_set_text_align";
        /// <summary>
        /// Cached name for the 'accessibility_update_set_text_selection' method.
        /// </summary>
        public static readonly StringName AccessibilityUpdateSetTextSelection = "accessibility_update_set_text_selection";
        /// <summary>
        /// Cached name for the 'accessibility_update_set_flag' method.
        /// </summary>
        public static readonly StringName AccessibilityUpdateSetFlag = "accessibility_update_set_flag";
        /// <summary>
        /// Cached name for the 'accessibility_update_set_classname' method.
        /// </summary>
        public static readonly StringName AccessibilityUpdateSetClassname = "accessibility_update_set_classname";
        /// <summary>
        /// Cached name for the 'accessibility_update_set_placeholder' method.
        /// </summary>
        public static readonly StringName AccessibilityUpdateSetPlaceholder = "accessibility_update_set_placeholder";
        /// <summary>
        /// Cached name for the 'accessibility_update_set_language' method.
        /// </summary>
        public static readonly StringName AccessibilityUpdateSetLanguage = "accessibility_update_set_language";
        /// <summary>
        /// Cached name for the 'accessibility_update_set_text_orientation' method.
        /// </summary>
        public static readonly StringName AccessibilityUpdateSetTextOrientation = "accessibility_update_set_text_orientation";
        /// <summary>
        /// Cached name for the 'accessibility_update_set_list_orientation' method.
        /// </summary>
        public static readonly StringName AccessibilityUpdateSetListOrientation = "accessibility_update_set_list_orientation";
        /// <summary>
        /// Cached name for the 'accessibility_update_set_shortcut' method.
        /// </summary>
        public static readonly StringName AccessibilityUpdateSetShortcut = "accessibility_update_set_shortcut";
        /// <summary>
        /// Cached name for the 'accessibility_update_set_url' method.
        /// </summary>
        public static readonly StringName AccessibilityUpdateSetUrl = "accessibility_update_set_url";
        /// <summary>
        /// Cached name for the 'accessibility_update_set_role_description' method.
        /// </summary>
        public static readonly StringName AccessibilityUpdateSetRoleDescription = "accessibility_update_set_role_description";
        /// <summary>
        /// Cached name for the 'accessibility_update_set_state_description' method.
        /// </summary>
        public static readonly StringName AccessibilityUpdateSetStateDescription = "accessibility_update_set_state_description";
        /// <summary>
        /// Cached name for the 'accessibility_update_set_color_value' method.
        /// </summary>
        public static readonly StringName AccessibilityUpdateSetColorValue = "accessibility_update_set_color_value";
        /// <summary>
        /// Cached name for the 'accessibility_update_set_background_color' method.
        /// </summary>
        public static readonly StringName AccessibilityUpdateSetBackgroundColor = "accessibility_update_set_background_color";
        /// <summary>
        /// Cached name for the 'accessibility_update_set_foreground_color' method.
        /// </summary>
        public static readonly StringName AccessibilityUpdateSetForegroundColor = "accessibility_update_set_foreground_color";
        /// <summary>
        /// Cached name for the 'ime_get_selection' method.
        /// </summary>
        public static readonly StringName ImeGetSelection = "ime_get_selection";
        /// <summary>
        /// Cached name for the 'ime_get_text' method.
        /// </summary>
        public static readonly StringName ImeGetText = "ime_get_text";
        /// <summary>
        /// Cached name for the 'virtual_keyboard_show' method.
        /// </summary>
        public static readonly StringName VirtualKeyboardShow = "virtual_keyboard_show";
        /// <summary>
        /// Cached name for the 'virtual_keyboard_hide' method.
        /// </summary>
        public static readonly StringName VirtualKeyboardHide = "virtual_keyboard_hide";
        /// <summary>
        /// Cached name for the 'virtual_keyboard_get_height' method.
        /// </summary>
        public static readonly StringName VirtualKeyboardGetHeight = "virtual_keyboard_get_height";
        /// <summary>
        /// Cached name for the 'has_hardware_keyboard' method.
        /// </summary>
        public static readonly StringName HasHardwareKeyboard = "has_hardware_keyboard";
        /// <summary>
        /// Cached name for the 'set_hardware_keyboard_connection_change_callback' method.
        /// </summary>
        public static readonly StringName SetHardwareKeyboardConnectionChangeCallback = "set_hardware_keyboard_connection_change_callback";
        /// <summary>
        /// Cached name for the 'cursor_set_shape' method.
        /// </summary>
        public static readonly StringName CursorSetShape = "cursor_set_shape";
        /// <summary>
        /// Cached name for the 'cursor_get_shape' method.
        /// </summary>
        public static readonly StringName CursorGetShape = "cursor_get_shape";
        /// <summary>
        /// Cached name for the 'cursor_set_custom_image' method.
        /// </summary>
        public static readonly StringName CursorSetCustomImage = "cursor_set_custom_image";
        /// <summary>
        /// Cached name for the 'get_swap_cancel_ok' method.
        /// </summary>
        public static readonly StringName GetSwapCancelOk = "get_swap_cancel_ok";
        /// <summary>
        /// Cached name for the 'enable_for_stealing_focus' method.
        /// </summary>
        public static readonly StringName EnableForStealingFocus = "enable_for_stealing_focus";
        /// <summary>
        /// Cached name for the 'dialog_show' method.
        /// </summary>
        public static readonly StringName DialogShow = "dialog_show";
        /// <summary>
        /// Cached name for the 'dialog_input_text' method.
        /// </summary>
        public static readonly StringName DialogInputText = "dialog_input_text";
        /// <summary>
        /// Cached name for the 'file_dialog_show' method.
        /// </summary>
        public static readonly StringName FileDialogShow = "file_dialog_show";
        /// <summary>
        /// Cached name for the 'file_dialog_with_options_show' method.
        /// </summary>
        public static readonly StringName FileDialogWithOptionsShow = "file_dialog_with_options_show";
        /// <summary>
        /// Cached name for the 'beep' method.
        /// </summary>
        public static readonly StringName Beep = "beep";
        /// <summary>
        /// Cached name for the 'keyboard_get_layout_count' method.
        /// </summary>
        public static readonly StringName KeyboardGetLayoutCount = "keyboard_get_layout_count";
        /// <summary>
        /// Cached name for the 'keyboard_get_current_layout' method.
        /// </summary>
        public static readonly StringName KeyboardGetCurrentLayout = "keyboard_get_current_layout";
        /// <summary>
        /// Cached name for the 'keyboard_set_current_layout' method.
        /// </summary>
        public static readonly StringName KeyboardSetCurrentLayout = "keyboard_set_current_layout";
        /// <summary>
        /// Cached name for the 'keyboard_get_layout_language' method.
        /// </summary>
        public static readonly StringName KeyboardGetLayoutLanguage = "keyboard_get_layout_language";
        /// <summary>
        /// Cached name for the 'keyboard_get_layout_name' method.
        /// </summary>
        public static readonly StringName KeyboardGetLayoutName = "keyboard_get_layout_name";
        /// <summary>
        /// Cached name for the 'keyboard_get_keycode_from_physical' method.
        /// </summary>
        public static readonly StringName KeyboardGetKeycodeFromPhysical = "keyboard_get_keycode_from_physical";
        /// <summary>
        /// Cached name for the 'keyboard_get_label_from_physical' method.
        /// </summary>
        public static readonly StringName KeyboardGetLabelFromPhysical = "keyboard_get_label_from_physical";
        /// <summary>
        /// Cached name for the 'show_emoji_and_symbol_picker' method.
        /// </summary>
        public static readonly StringName ShowEmojiAndSymbolPicker = "show_emoji_and_symbol_picker";
        /// <summary>
        /// Cached name for the 'color_picker' method.
        /// </summary>
        public static readonly StringName ColorPicker = "color_picker";
        /// <summary>
        /// Cached name for the 'process_events' method.
        /// </summary>
        public static readonly StringName ProcessEvents = "process_events";
        /// <summary>
        /// Cached name for the 'force_process_and_drop_events' method.
        /// </summary>
        public static readonly StringName ForceProcessAndDropEvents = "force_process_and_drop_events";
        /// <summary>
        /// Cached name for the 'set_native_icon' method.
        /// </summary>
        public static readonly StringName SetNativeIcon = "set_native_icon";
        /// <summary>
        /// Cached name for the 'set_icon' method.
        /// </summary>
        public static readonly StringName SetIcon = "set_icon";
        /// <summary>
        /// Cached name for the 'create_status_indicator' method.
        /// </summary>
        public static readonly StringName CreateStatusIndicator = "create_status_indicator";
        /// <summary>
        /// Cached name for the 'status_indicator_set_icon' method.
        /// </summary>
        public static readonly StringName StatusIndicatorSetIcon = "status_indicator_set_icon";
        /// <summary>
        /// Cached name for the 'status_indicator_set_tooltip' method.
        /// </summary>
        public static readonly StringName StatusIndicatorSetTooltip = "status_indicator_set_tooltip";
        /// <summary>
        /// Cached name for the 'status_indicator_set_menu' method.
        /// </summary>
        public static readonly StringName StatusIndicatorSetMenu = "status_indicator_set_menu";
        /// <summary>
        /// Cached name for the 'status_indicator_set_callback' method.
        /// </summary>
        public static readonly StringName StatusIndicatorSetCallback = "status_indicator_set_callback";
        /// <summary>
        /// Cached name for the 'status_indicator_get_rect' method.
        /// </summary>
        public static readonly StringName StatusIndicatorGetRect = "status_indicator_get_rect";
        /// <summary>
        /// Cached name for the 'delete_status_indicator' method.
        /// </summary>
        public static readonly StringName DeleteStatusIndicator = "delete_status_indicator";
        /// <summary>
        /// Cached name for the 'tablet_get_driver_count' method.
        /// </summary>
        public static readonly StringName TabletGetDriverCount = "tablet_get_driver_count";
        /// <summary>
        /// Cached name for the 'tablet_get_driver_name' method.
        /// </summary>
        public static readonly StringName TabletGetDriverName = "tablet_get_driver_name";
        /// <summary>
        /// Cached name for the 'tablet_get_current_driver' method.
        /// </summary>
        public static readonly StringName TabletGetCurrentDriver = "tablet_get_current_driver";
        /// <summary>
        /// Cached name for the 'tablet_set_current_driver' method.
        /// </summary>
        public static readonly StringName TabletSetCurrentDriver = "tablet_set_current_driver";
        /// <summary>
        /// Cached name for the 'is_window_transparency_available' method.
        /// </summary>
        public static readonly StringName IsWindowTransparencyAvailable = "is_window_transparency_available";
        /// <summary>
        /// Cached name for the 'register_additional_output' method.
        /// </summary>
        public static readonly StringName RegisterAdditionalOutput = "register_additional_output";
        /// <summary>
        /// Cached name for the 'unregister_additional_output' method.
        /// </summary>
        public static readonly StringName UnregisterAdditionalOutput = "unregister_additional_output";
        /// <summary>
        /// Cached name for the 'has_additional_outputs' method.
        /// </summary>
        public static readonly StringName HasAdditionalOutputs = "has_additional_outputs";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public class SignalName
    {
    }
}
