namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>The <see cref="Godot.Input"/> singleton handles key presses, mouse buttons and movement, gamepads, and input actions. Actions and their events can be set in the <b>Input Map</b> tab in <b>Project &gt; Project Settings</b>, or with the <see cref="Godot.InputMap"/> class.</para>
/// <para><b>Note:</b> <see cref="Godot.Input"/>'s methods reflect the global input state and are not affected by <see cref="Godot.Control.AcceptEvent()"/> or <see cref="Godot.Viewport.SetInputAsHandled()"/>, as those methods only deal with the way input is propagated in the <see cref="Godot.SceneTree"/>.</para>
/// </summary>
public static partial class Input
{
    public enum MouseModeEnum : long
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
        /// <para>Max value of the <see cref="Godot.Input.MouseModeEnum"/>.</para>
        /// </summary>
        Max = 5
    }

    public enum CursorShape : long
    {
        /// <summary>
        /// <para>Arrow cursor. Standard, default pointing cursor.</para>
        /// </summary>
        Arrow = 0,
        /// <summary>
        /// <para>I-beam cursor. Usually used to show where the text cursor will appear when the mouse is clicked.</para>
        /// </summary>
        Ibeam = 1,
        /// <summary>
        /// <para>Pointing hand cursor. Usually used to indicate the pointer is over a link or other interactable item.</para>
        /// </summary>
        PointingHand = 2,
        /// <summary>
        /// <para>Cross cursor. Typically appears over regions in which a drawing operation can be performed or for selections.</para>
        /// </summary>
        Cross = 3,
        /// <summary>
        /// <para>Wait cursor. Indicates that the application is busy performing an operation, and that it cannot be used during the operation (e.g. something is blocking its main thread).</para>
        /// </summary>
        Wait = 4,
        /// <summary>
        /// <para>Busy cursor. Indicates that the application is busy performing an operation, and that it is still usable during the operation.</para>
        /// </summary>
        Busy = 5,
        /// <summary>
        /// <para>Drag cursor. Usually displayed when dragging something.</para>
        /// <para><b>Note:</b> Windows lacks a dragging cursor, so <see cref="Godot.Input.CursorShape.Drag"/> is the same as <see cref="Godot.Input.CursorShape.Move"/> for this platform.</para>
        /// </summary>
        Drag = 6,
        /// <summary>
        /// <para>Can drop cursor. Usually displayed when dragging something to indicate that it can be dropped at the current position.</para>
        /// </summary>
        CanDrop = 7,
        /// <summary>
        /// <para>Forbidden cursor. Indicates that the current action is forbidden (for example, when dragging something) or that the control at a position is disabled.</para>
        /// </summary>
        Forbidden = 8,
        /// <summary>
        /// <para>Vertical resize mouse cursor. A double-headed vertical arrow. It tells the user they can resize the window or the panel vertically.</para>
        /// </summary>
        Vsize = 9,
        /// <summary>
        /// <para>Horizontal resize mouse cursor. A double-headed horizontal arrow. It tells the user they can resize the window or the panel horizontally.</para>
        /// </summary>
        Hsize = 10,
        /// <summary>
        /// <para>Window resize mouse cursor. The cursor is a double-headed arrow that goes from the bottom left to the top right. It tells the user they can resize the window or the panel both horizontally and vertically.</para>
        /// </summary>
        Bdiagsize = 11,
        /// <summary>
        /// <para>Window resize mouse cursor. The cursor is a double-headed arrow that goes from the top left to the bottom right, the opposite of <see cref="Godot.Input.CursorShape.Bdiagsize"/>. It tells the user they can resize the window or the panel both horizontally and vertically.</para>
        /// </summary>
        Fdiagsize = 12,
        /// <summary>
        /// <para>Move cursor. Indicates that something can be moved.</para>
        /// </summary>
        Move = 13,
        /// <summary>
        /// <para>Vertical split mouse cursor. On Windows, it's the same as <see cref="Godot.Input.CursorShape.Vsize"/>.</para>
        /// </summary>
        Vsplit = 14,
        /// <summary>
        /// <para>Horizontal split mouse cursor. On Windows, it's the same as <see cref="Godot.Input.CursorShape.Hsize"/>.</para>
        /// </summary>
        Hsplit = 15,
        /// <summary>
        /// <para>Help cursor. Usually a question mark.</para>
        /// </summary>
        Help = 16
    }

    /// <summary>
    /// <para>Controls the mouse mode.</para>
    /// </summary>
    public static Input.MouseModeEnum MouseMode
    {
        get
        {
            return GetMouseMode();
        }
        set
        {
            SetMouseMode(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, similar input events sent by the operating system are accumulated. When input accumulation is enabled, all input events generated during a frame will be merged and emitted when the frame is done rendering. Therefore, this limits the number of input method calls per second to the rendering FPS.</para>
    /// <para>Input accumulation can be disabled to get slightly more precise/reactive input at the cost of increased CPU usage. In applications where drawing freehand lines is required, input accumulation should generally be disabled while the user is drawing the line to get results that closely follow the actual input.</para>
    /// <para><b>Note:</b> Input accumulation is <i>enabled</i> by default.</para>
    /// </summary>
    public static bool UseAccumulatedInput
    {
        get
        {
            return IsUsingAccumulatedInput();
        }
        set
        {
            SetUseAccumulatedInput(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, sends mouse input events when tapping or swiping on the touchscreen. See also <c>ProjectSettings.input_devices/pointing/emulate_mouse_from_touch</c>.</para>
    /// </summary>
    public static bool EmulateMouseFromTouch
    {
        get
        {
            return IsEmulatingMouseFromTouch();
        }
        set
        {
            SetEmulateMouseFromTouch(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, sends touch input events when clicking or dragging the mouse. See also <c>ProjectSettings.input_devices/pointing/emulate_touch_from_mouse</c>.</para>
    /// </summary>
    public static bool EmulateTouchFromMouse
    {
        get
        {
            return IsEmulatingTouchFromMouse();
        }
        set
        {
            SetEmulateTouchFromMouse(value);
        }
    }

    private static readonly StringName NativeName = "Input";

    private static InputInstance singleton;

    public static InputInstance Singleton =>
        singleton ??= (InputInstance)InteropUtils.EngineGetSingleton("Input");

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.IsAnythingPressed, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if any action, key, joypad button, or mouse button is being pressed. This will also return <see langword="true"/> if any action is simulated via code by calling <see cref="Godot.Input.ActionPress(StringName, float)"/>.</para>
    /// </summary>
    public static bool IsAnythingPressed()
    {
        return NativeCalls.godot_icall_0_15(MethodBind0, GodotObject.GetPtr(Singleton)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.IsKeyPressed, 1938909964ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if you are pressing the Latin key in the current keyboard layout. You can pass a <see cref="Godot.Key"/> constant.</para>
    /// <para><see cref="Godot.Input.IsKeyPressed(Key)"/> is only recommended over <see cref="Godot.Input.IsPhysicalKeyPressed(Key)"/> in non-game applications. This ensures that shortcut keys behave as expected depending on the user's keyboard layout, as keyboard shortcuts are generally dependent on the keyboard layout in non-game applications. If in doubt, use <see cref="Godot.Input.IsPhysicalKeyPressed(Key)"/>.</para>
    /// <para><b>Note:</b> Due to keyboard ghosting, <see cref="Godot.Input.IsKeyPressed(Key)"/> may return <see langword="false"/> even if one of the action's keys is pressed. See <a href="$DOCS_URL/tutorials/inputs/input_examples.html#keyboard-events">Input examples</a> in the documentation for more information.</para>
    /// </summary>
    public static bool IsKeyPressed(Key keycode)
    {
        return NativeCalls.godot_icall_1_62(MethodBind1, GodotObject.GetPtr(Singleton), (int)keycode).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.IsPhysicalKeyPressed, 1938909964ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if you are pressing the key in the physical location on the 101/102-key US QWERTY keyboard. You can pass a <see cref="Godot.Key"/> constant.</para>
    /// <para><see cref="Godot.Input.IsPhysicalKeyPressed(Key)"/> is recommended over <see cref="Godot.Input.IsKeyPressed(Key)"/> for in-game actions, as it will make W/A/S/D layouts work regardless of the user's keyboard layout. <see cref="Godot.Input.IsPhysicalKeyPressed(Key)"/> will also ensure that the top row number keys work on any keyboard layout. If in doubt, use <see cref="Godot.Input.IsPhysicalKeyPressed(Key)"/>.</para>
    /// <para><b>Note:</b> Due to keyboard ghosting, <see cref="Godot.Input.IsPhysicalKeyPressed(Key)"/> may return <see langword="false"/> even if one of the action's keys is pressed. See <a href="$DOCS_URL/tutorials/inputs/input_examples.html#keyboard-events">Input examples</a> in the documentation for more information.</para>
    /// </summary>
    public static bool IsPhysicalKeyPressed(Key keycode)
    {
        return NativeCalls.godot_icall_1_62(MethodBind2, GodotObject.GetPtr(Singleton), (int)keycode).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.IsKeyLabelPressed, 1938909964ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if you are pressing the key with the <paramref name="keycode"/> printed on it. You can pass a <see cref="Godot.Key"/> constant or any Unicode character code.</para>
    /// </summary>
    public static bool IsKeyLabelPressed(Key keycode)
    {
        return NativeCalls.godot_icall_1_62(MethodBind3, GodotObject.GetPtr(Singleton), (int)keycode).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.IsMouseButtonPressed, 1821097125ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if you are pressing the mouse button specified with <see cref="Godot.MouseButton"/>.</para>
    /// </summary>
    public static bool IsMouseButtonPressed(MouseButton button)
    {
        return NativeCalls.godot_icall_1_62(MethodBind4, GodotObject.GetPtr(Singleton), (int)button).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.IsJoyButtonPressed, 787208542ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if you are pressing the joypad button at index <paramref name="button"/>.</para>
    /// </summary>
    public static bool IsJoyButtonPressed(int device, JoyButton button)
    {
        return NativeCalls.godot_icall_2_40(MethodBind5, GodotObject.GetPtr(Singleton), device, (int)button).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.IsActionPressed, 1558498928ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if you are pressing the action event.</para>
    /// <para>If <paramref name="exactMatch"/> is <see langword="false"/>, it ignores additional input modifiers for <see cref="Godot.InputEventKey"/> and <see cref="Godot.InputEventMouseButton"/> events, and the direction for <see cref="Godot.InputEventJoypadMotion"/> events.</para>
    /// <para><b>Note:</b> Due to keyboard ghosting, <see cref="Godot.Input.IsActionPressed(StringName, bool)"/> may return <see langword="false"/> even if one of the action's keys is pressed. See <a href="$DOCS_URL/tutorials/inputs/input_examples.html#keyboard-events">Input examples</a> in the documentation for more information.</para>
    /// </summary>
    public static bool IsActionPressed(StringName action, bool exactMatch = false)
    {
        return NativeCalls.godot_icall_2_745(MethodBind6, GodotObject.GetPtr(Singleton), (godot_string_name)(action?.NativeValue ?? default), exactMatch.ToGodotBool()).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.IsActionJustPressed, 1558498928ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> when the user has <i>started</i> pressing the action event in the current frame or physics tick. It will only return <see langword="true"/> on the frame or tick that the user pressed down the button.</para>
    /// <para>This is useful for code that needs to run only once when an action is pressed, instead of every frame while it's pressed.</para>
    /// <para>If <paramref name="exactMatch"/> is <see langword="false"/>, it ignores additional input modifiers for <see cref="Godot.InputEventKey"/> and <see cref="Godot.InputEventMouseButton"/> events, and the direction for <see cref="Godot.InputEventJoypadMotion"/> events.</para>
    /// <para><b>Note:</b> Returning <see langword="true"/> does not imply that the action is <i>still</i> pressed. An action can be pressed and released again rapidly, and <see langword="true"/> will still be returned so as not to miss input.</para>
    /// <para><b>Note:</b> Due to keyboard ghosting, <see cref="Godot.Input.IsActionJustPressed(StringName, bool)"/> may return <see langword="false"/> even if one of the action's keys is pressed. See <a href="$DOCS_URL/tutorials/inputs/input_examples.html#keyboard-events">Input examples</a> in the documentation for more information.</para>
    /// <para><b>Note:</b> During input handling (e.g. <see cref="Godot.Node._Input(InputEvent)"/>), use <see cref="Godot.InputEvent.IsActionPressed(StringName, bool, bool)"/> instead to query the action state of the current event. See also <see cref="Godot.Input.IsActionJustPressedByEvent(StringName, InputEvent, bool)"/>.</para>
    /// </summary>
    public static bool IsActionJustPressed(StringName action, bool exactMatch = false)
    {
        return NativeCalls.godot_icall_2_745(MethodBind7, GodotObject.GetPtr(Singleton), (godot_string_name)(action?.NativeValue ?? default), exactMatch.ToGodotBool()).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.IsActionJustReleased, 1558498928ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> when the user <i>stops</i> pressing the action event in the current frame or physics tick. It will only return <see langword="true"/> on the frame or tick that the user releases the button.</para>
    /// <para><b>Note:</b> Returning <see langword="true"/> does not imply that the action is <i>still</i> not pressed. An action can be released and pressed again rapidly, and <see langword="true"/> will still be returned so as not to miss input.</para>
    /// <para>If <paramref name="exactMatch"/> is <see langword="false"/>, it ignores additional input modifiers for <see cref="Godot.InputEventKey"/> and <see cref="Godot.InputEventMouseButton"/> events, and the direction for <see cref="Godot.InputEventJoypadMotion"/> events.</para>
    /// <para><b>Note:</b> During input handling (e.g. <see cref="Godot.Node._Input(InputEvent)"/>), use <see cref="Godot.InputEvent.IsActionReleased(StringName, bool)"/> instead to query the action state of the current event. See also <see cref="Godot.Input.IsActionJustReleasedByEvent(StringName, InputEvent, bool)"/>.</para>
    /// </summary>
    public static bool IsActionJustReleased(StringName action, bool exactMatch = false)
    {
        return NativeCalls.godot_icall_2_745(MethodBind8, GodotObject.GetPtr(Singleton), (godot_string_name)(action?.NativeValue ?? default), exactMatch.ToGodotBool()).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.IsActionJustPressedByEvent, 551972873ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> when the user has <i>started</i> pressing the action event in the current frame or physics tick, and the first event that triggered action press in the current frame/physics tick was <paramref name="event"/>. It will only return <see langword="true"/> on the frame or tick that the user pressed down the button.</para>
    /// <para>This is useful for code that needs to run only once when an action is pressed, and the action is processed during input handling (e.g. <see cref="Godot.Node._Input(InputEvent)"/>).</para>
    /// <para>If <paramref name="exactMatch"/> is <see langword="false"/>, it ignores additional input modifiers for <see cref="Godot.InputEventKey"/> and <see cref="Godot.InputEventMouseButton"/> events, and the direction for <see cref="Godot.InputEventJoypadMotion"/> events.</para>
    /// <para><b>Note:</b> Returning <see langword="true"/> does not imply that the action is <i>still</i> pressed. An action can be pressed and released again rapidly, and <see langword="true"/> will still be returned so as not to miss input.</para>
    /// <para><b>Note:</b> Due to keyboard ghosting, <see cref="Godot.Input.IsActionJustPressed(StringName, bool)"/> may return <see langword="false"/> even if one of the action's keys is pressed. See <a href="$DOCS_URL/tutorials/inputs/input_examples.html#keyboard-events">Input examples</a> in the documentation for more information.</para>
    /// </summary>
    public static bool IsActionJustPressedByEvent(StringName action, InputEvent @event, bool exactMatch = false)
    {
        return NativeCalls.godot_icall_3_746(MethodBind9, GodotObject.GetPtr(Singleton), (godot_string_name)(action?.NativeValue ?? default), GodotObject.GetPtr(@event), exactMatch.ToGodotBool()).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.IsActionJustReleasedByEvent, 551972873ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> when the user <i>stops</i> pressing the action event in the current frame or physics tick, and the first event that triggered action release in the current frame/physics tick was <paramref name="event"/>. It will only return <see langword="true"/> on the frame or tick that the user releases the button.</para>
    /// <para>This is useful when an action is processed during input handling (e.g. <see cref="Godot.Node._Input(InputEvent)"/>).</para>
    /// <para><b>Note:</b> Returning <see langword="true"/> does not imply that the action is <i>still</i> not pressed. An action can be released and pressed again rapidly, and <see langword="true"/> will still be returned so as not to miss input.</para>
    /// <para>If <paramref name="exactMatch"/> is <see langword="false"/>, it ignores additional input modifiers for <see cref="Godot.InputEventKey"/> and <see cref="Godot.InputEventMouseButton"/> events, and the direction for <see cref="Godot.InputEventJoypadMotion"/> events.</para>
    /// </summary>
    public static bool IsActionJustReleasedByEvent(StringName action, InputEvent @event, bool exactMatch = false)
    {
        return NativeCalls.godot_icall_3_746(MethodBind10, GodotObject.GetPtr(Singleton), (godot_string_name)(action?.NativeValue ?? default), GodotObject.GetPtr(@event), exactMatch.ToGodotBool()).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetActionStrength, 801543509ul);

    /// <summary>
    /// <para>Returns a value between 0 and 1 representing the intensity of the given action. In a joypad, for example, the further away the axis (analog sticks or L2, R2 triggers) is from the dead zone, the closer the value will be to 1. If the action is mapped to a control that has no axis such as the keyboard, the value returned will be 0 or 1.</para>
    /// <para>If <paramref name="exactMatch"/> is <see langword="false"/>, it ignores additional input modifiers for <see cref="Godot.InputEventKey"/> and <see cref="Godot.InputEventMouseButton"/> events, and the direction for <see cref="Godot.InputEventJoypadMotion"/> events.</para>
    /// </summary>
    public static float GetActionStrength(StringName action, bool exactMatch = false)
    {
        return NativeCalls.godot_icall_2_747(MethodBind11, GodotObject.GetPtr(Singleton), (godot_string_name)(action?.NativeValue ?? default), exactMatch.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetActionRawStrength, 801543509ul);

    /// <summary>
    /// <para>Returns a value between 0 and 1 representing the raw intensity of the given action, ignoring the action's deadzone. In most cases, you should use <see cref="Godot.Input.GetActionStrength(StringName, bool)"/> instead.</para>
    /// <para>If <paramref name="exactMatch"/> is <see langword="false"/>, it ignores additional input modifiers for <see cref="Godot.InputEventKey"/> and <see cref="Godot.InputEventMouseButton"/> events, and the direction for <see cref="Godot.InputEventJoypadMotion"/> events.</para>
    /// </summary>
    public static float GetActionRawStrength(StringName action, bool exactMatch = false)
    {
        return NativeCalls.godot_icall_2_747(MethodBind12, GodotObject.GetPtr(Singleton), (godot_string_name)(action?.NativeValue ?? default), exactMatch.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAxis, 1958752504ul);

    /// <summary>
    /// <para>Get axis input by specifying two actions, one negative and one positive.</para>
    /// <para>This is a shorthand for writing <c>Input.get_action_strength("positive_action") - Input.get_action_strength("negative_action")</c>.</para>
    /// </summary>
    public static float GetAxis(StringName negativeAction, StringName positiveAction)
    {
        return NativeCalls.godot_icall_2_748(MethodBind13, GodotObject.GetPtr(Singleton), (godot_string_name)(negativeAction?.NativeValue ?? default), (godot_string_name)(positiveAction?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVector, 2479607902ul);

    /// <summary>
    /// <para>Gets an input vector by specifying four actions for the positive and negative X and Y axes.</para>
    /// <para>This method is useful when getting vector input, such as from a joystick, directional pad, arrows, or WASD. The vector has its length limited to 1 and has a circular deadzone, which is useful for using vector input as movement.</para>
    /// <para>By default, the deadzone is automatically calculated from the average of the action deadzones. However, you can override the deadzone to be whatever you want (on the range of 0 to 1).</para>
    /// </summary>
    public static Vector2 GetVector(StringName negativeX, StringName positiveX, StringName negativeY, StringName positiveY, float deadzone = -1.0f)
    {
        return NativeCalls.godot_icall_5_749(MethodBind14, GodotObject.GetPtr(Singleton), (godot_string_name)(negativeX?.NativeValue ?? default), (godot_string_name)(positiveX?.NativeValue ?? default), (godot_string_name)(negativeY?.NativeValue ?? default), (godot_string_name)(positiveY?.NativeValue ?? default), deadzone);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AddJoyMapping, 1168363258ul);

    /// <summary>
    /// <para>Adds a new mapping entry (in SDL2 format) to the mapping database. Optionally update already connected devices.</para>
    /// </summary>
    public static void AddJoyMapping(string mapping, bool updateExisting = false)
    {
        NativeCalls.godot_icall_2_497(MethodBind15, GodotObject.GetPtr(Singleton), mapping, updateExisting.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveJoyMapping, 83702148ul);

    /// <summary>
    /// <para>Removes all mappings from the internal database that match the given GUID. All currently connected joypads that use this GUID will become unmapped.</para>
    /// <para>On Android, Godot will map to an internal fallback mapping.</para>
    /// </summary>
    public static void RemoveJoyMapping(string guid)
    {
        NativeCalls.godot_icall_1_57(MethodBind16, GodotObject.GetPtr(Singleton), guid);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.IsJoyKnown, 3067735520ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the system knows the specified device. This means that it sets all button and axis indices. Unknown joypads are not expected to match these constants, but you can still retrieve events from them.</para>
    /// </summary>
    public static bool IsJoyKnown(int device)
    {
        return NativeCalls.godot_icall_1_62(MethodBind17, GodotObject.GetPtr(Singleton), device).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetJoyAxis, 4063175957ul);

    /// <summary>
    /// <para>Returns the current value of the joypad axis at index <paramref name="axis"/>.</para>
    /// </summary>
    public static float GetJoyAxis(int device, JoyAxis axis)
    {
        return NativeCalls.godot_icall_2_88(MethodBind18, GodotObject.GetPtr(Singleton), device, (int)axis);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetJoyName, 990163283ul);

    /// <summary>
    /// <para>Returns the name of the joypad at the specified device index, e.g. <c>PS4 Controller</c>. Godot uses the <a href="https://github.com/gabomdq/SDL_GameControllerDB">SDL2 game controller database</a> to determine gamepad names.</para>
    /// </summary>
    public static string GetJoyName(int device)
    {
        return NativeCalls.godot_icall_1_133(MethodBind19, GodotObject.GetPtr(Singleton), device);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetJoyGuid, 844755477ul);

    /// <summary>
    /// <para>Returns an SDL2-compatible device GUID on platforms that use gamepad remapping, e.g. <c>030000004c050000c405000000010000</c>. Returns an empty string if it cannot be found. Godot uses the <a href="https://github.com/gabomdq/SDL_GameControllerDB">SDL2 game controller database</a> to determine gamepad names and mappings based on this GUID.</para>
    /// <para>On Windows, all XInput joypad GUIDs will be overridden by Godot to <c>__XINPUT_DEVICE__</c>, because their mappings are the same.</para>
    /// </summary>
    public static string GetJoyGuid(int device)
    {
        return NativeCalls.godot_icall_1_133(MethodBind20, GodotObject.GetPtr(Singleton), device);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetJoyInfo, 3485342025ul);

    /// <summary>
    /// <para>Returns a dictionary with extra platform-specific information about the device, e.g. the raw gamepad name from the OS or the Steam Input index.</para>
    /// <para>On Windows, Linux, and macOS, the dictionary contains the following fields:</para>
    /// <para><c>raw_name</c>: The name of the controller as it came from the OS, before getting renamed by the controller database.</para>
    /// <para><c>vendor_id</c>: The USB vendor ID of the device.</para>
    /// <para><c>product_id</c>: The USB product ID of the device.</para>
    /// <para><c>steam_input_index</c>: The Steam Input gamepad index, if the device is not a Steam Input device this key won't be present.</para>
    /// <para>On Windows, the dictionary can have an additional field:</para>
    /// <para><c>xinput_index</c>: The index of the controller in the XInput system. This key won't be present for devices not handled by XInput.</para>
    /// <para><b>Note:</b> The returned dictionary is always empty on Android, iOS, visionOS, and Web.</para>
    /// </summary>
    public static Godot.Collections.Dictionary GetJoyInfo(int device)
    {
        return NativeCalls.godot_icall_1_307(MethodBind21, GodotObject.GetPtr(Singleton), device);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ShouldIgnoreDevice, 2522259332ul);

    /// <summary>
    /// <para>Queries whether an input device should be ignored or not. Devices can be ignored by setting the environment variable <c>SDL_GAMECONTROLLER_IGNORE_DEVICES</c>. Read the <a href="https://wiki.libsdl.org/SDL2">SDL documentation</a> for more information.</para>
    /// <para><b>Note:</b> Some 3rd party tools can contribute to the list of ignored devices. For example, <i>SteamInput</i> creates virtual devices from physical devices for remapping purposes. To avoid handling the same input device twice, the original device is added to the ignore list.</para>
    /// </summary>
    public static bool ShouldIgnoreDevice(int vendorId, int productId)
    {
        return NativeCalls.godot_icall_2_40(MethodBind22, GodotObject.GetPtr(Singleton), vendorId, productId).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetConnectedJoypads, 2915620761ul);

    /// <summary>
    /// <para>Returns an <see cref="Godot.Collections.Array"/> containing the device IDs of all currently connected joypads.</para>
    /// </summary>
    public static Godot.Collections.Array<int> GetConnectedJoypads()
    {
        return new Godot.Collections.Array<int>(NativeCalls.godot_icall_0_120(MethodBind23, GodotObject.GetPtr(Singleton)));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetJoyVibrationStrength, 3114997196ul);

    /// <summary>
    /// <para>Returns the strength of the joypad vibration: x is the strength of the weak motor, and y is the strength of the strong motor.</para>
    /// </summary>
    public static Vector2 GetJoyVibrationStrength(int device)
    {
        return NativeCalls.godot_icall_1_148(MethodBind24, GodotObject.GetPtr(Singleton), device);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetJoyVibrationDuration, 4025615559ul);

    /// <summary>
    /// <para>Returns the duration of the current vibration effect in seconds.</para>
    /// </summary>
    public static float GetJoyVibrationDuration(int device)
    {
        return NativeCalls.godot_icall_1_72(MethodBind25, GodotObject.GetPtr(Singleton), device);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.StartJoyVibration, 2576575033ul);

    /// <summary>
    /// <para>Starts to vibrate the joypad. Joypads usually come with two rumble motors, a strong and a weak one. <paramref name="weakMagnitude"/> is the strength of the weak motor (between 0 and 1) and <paramref name="strongMagnitude"/> is the strength of the strong motor (between 0 and 1). <paramref name="duration"/> is the duration of the effect in seconds (a duration of 0 will try to play the vibration indefinitely). The vibration can be stopped early by calling <see cref="Godot.Input.StopJoyVibration(int)"/>.</para>
    /// <para><b>Note:</b> Not every hardware is compatible with long effect durations; it is recommended to restart an effect if it has to be played for more than a few seconds.</para>
    /// <para><b>Note:</b> For macOS, vibration is only supported in macOS 11 and later.</para>
    /// </summary>
    public static void StartJoyVibration(int device, float weakMagnitude, float strongMagnitude, float duration = (float)(0))
    {
        NativeCalls.godot_icall_4_750(MethodBind26, GodotObject.GetPtr(Singleton), device, weakMagnitude, strongMagnitude, duration);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.StopJoyVibration, 1286410249ul);

    /// <summary>
    /// <para>Stops the vibration of the joypad started with <see cref="Godot.Input.StartJoyVibration(int, float, float, float)"/>.</para>
    /// </summary>
    public static void StopJoyVibration(int device)
    {
        NativeCalls.godot_icall_1_38(MethodBind27, GodotObject.GetPtr(Singleton), device);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.VibrateHandheld, 544894297ul);

    /// <summary>
    /// <para>Vibrate the handheld device for the specified duration in milliseconds.</para>
    /// <para><paramref name="amplitude"/> is the strength of the vibration, as a value between <c>0.0</c> and <c>1.0</c>. If set to <c>-1.0</c>, the default vibration strength of the device is used.</para>
    /// <para><b>Note:</b> This method is implemented on Android, iOS, and Web. It has no effect on other platforms.</para>
    /// <para><b>Note:</b> For Android, <see cref="Godot.Input.VibrateHandheld(int, float)"/> requires enabling the <c>VIBRATE</c> permission in the export preset. Otherwise, <see cref="Godot.Input.VibrateHandheld(int, float)"/> will have no effect.</para>
    /// <para><b>Note:</b> For iOS, specifying the duration is only supported in iOS 13 and later.</para>
    /// <para><b>Note:</b> For Web, the amplitude cannot be changed.</para>
    /// <para><b>Note:</b> Some web browsers such as Safari and Firefox for Android do not support <see cref="Godot.Input.VibrateHandheld(int, float)"/>.</para>
    /// </summary>
    public static void VibrateHandheld(int durationMs = 500, float amplitude = -1.0f)
    {
        NativeCalls.godot_icall_2_69(MethodBind28, GodotObject.GetPtr(Singleton), durationMs, amplitude);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetGravity, 3360562783ul);

    /// <summary>
    /// <para>Returns the gravity in m/s² of the device's accelerometer sensor, if the device has one. Otherwise, the method returns <c>Vector3.ZERO</c>.</para>
    /// <para><b>Note:</b> This method only works on Android and iOS. On other platforms, it always returns <c>Vector3.ZERO</c>.</para>
    /// <para><b>Note:</b> For Android, <c>ProjectSettings.input_devices/sensors/enable_gravity</c> must be enabled.</para>
    /// </summary>
    public static Vector3 GetGravity()
    {
        return NativeCalls.godot_icall_0_125(MethodBind29, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAccelerometer, 3360562783ul);

    /// <summary>
    /// <para>Returns the acceleration in m/s² of the device's accelerometer sensor, if the device has one. Otherwise, the method returns <c>Vector3.ZERO</c>.</para>
    /// <para>Note this method returns an empty <see cref="Godot.Vector3"/> when running from the editor even when your device has an accelerometer. You must export your project to a supported device to read values from the accelerometer.</para>
    /// <para><b>Note:</b> This method only works on Android and iOS. On other platforms, it always returns <c>Vector3.ZERO</c>.</para>
    /// <para><b>Note:</b> For Android, <c>ProjectSettings.input_devices/sensors/enable_accelerometer</c> must be enabled.</para>
    /// </summary>
    public static Vector3 GetAccelerometer()
    {
        return NativeCalls.godot_icall_0_125(MethodBind30, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMagnetometer, 3360562783ul);

    /// <summary>
    /// <para>Returns the magnetic field strength in micro-Tesla for all axes of the device's magnetometer sensor, if the device has one. Otherwise, the method returns <c>Vector3.ZERO</c>.</para>
    /// <para><b>Note:</b> This method only works on Android and iOS. On other platforms, it always returns <c>Vector3.ZERO</c>.</para>
    /// <para><b>Note:</b> For Android, <c>ProjectSettings.input_devices/sensors/enable_magnetometer</c> must be enabled.</para>
    /// </summary>
    public static Vector3 GetMagnetometer()
    {
        return NativeCalls.godot_icall_0_125(MethodBind31, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind32 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetGyroscope, 3360562783ul);

    /// <summary>
    /// <para>Returns the rotation rate in rad/s around a device's X, Y, and Z axes of the gyroscope sensor, if the device has one. Otherwise, the method returns <c>Vector3.ZERO</c>.</para>
    /// <para><b>Note:</b> This method only works on Android and iOS. On other platforms, it always returns <c>Vector3.ZERO</c>.</para>
    /// <para><b>Note:</b> For Android, <c>ProjectSettings.input_devices/sensors/enable_gyroscope</c> must be enabled.</para>
    /// </summary>
    public static Vector3 GetGyroscope()
    {
        return NativeCalls.godot_icall_0_125(MethodBind32, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind33 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SetGravity, 3460891852ul);

    /// <summary>
    /// <para>Sets the gravity value of the accelerometer sensor. Can be used for debugging on devices without a hardware sensor, for example in an editor on a PC.</para>
    /// <para><b>Note:</b> This value can be immediately overwritten by the hardware sensor value on Android and iOS.</para>
    /// </summary>
    public static unsafe void SetGravity(Vector3 value)
    {
        NativeCalls.godot_icall_1_177(MethodBind33, GodotObject.GetPtr(Singleton), &value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind34 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAccelerometer, 3460891852ul);

    /// <summary>
    /// <para>Sets the acceleration value of the accelerometer sensor. Can be used for debugging on devices without a hardware sensor, for example in an editor on a PC.</para>
    /// <para><b>Note:</b> This value can be immediately overwritten by the hardware sensor value on Android and iOS.</para>
    /// </summary>
    public static unsafe void SetAccelerometer(Vector3 value)
    {
        NativeCalls.godot_icall_1_177(MethodBind34, GodotObject.GetPtr(Singleton), &value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind35 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMagnetometer, 3460891852ul);

    /// <summary>
    /// <para>Sets the value of the magnetic field of the magnetometer sensor. Can be used for debugging on devices without a hardware sensor, for example in an editor on a PC.</para>
    /// <para><b>Note:</b> This value can be immediately overwritten by the hardware sensor value on Android and iOS.</para>
    /// </summary>
    public static unsafe void SetMagnetometer(Vector3 value)
    {
        NativeCalls.godot_icall_1_177(MethodBind35, GodotObject.GetPtr(Singleton), &value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind36 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SetGyroscope, 3460891852ul);

    /// <summary>
    /// <para>Sets the value of the rotation rate of the gyroscope sensor. Can be used for debugging on devices without a hardware sensor, for example in an editor on a PC.</para>
    /// <para><b>Note:</b> This value can be immediately overwritten by the hardware sensor value on Android and iOS.</para>
    /// </summary>
    public static unsafe void SetGyroscope(Vector3 value)
    {
        NativeCalls.godot_icall_1_177(MethodBind36, GodotObject.GetPtr(Singleton), &value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind37 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SetJoyLight, 2878471219ul);

    /// <summary>
    /// <para>Sets the joypad's LED light, if available, to the specified color. See also <see cref="Godot.Input.HasJoyLight(int)"/>.</para>
    /// <para><b>Note:</b> There is no way to get the color of the light from a joypad. If you need to know the assigned color, store it separately.</para>
    /// <para><b>Note:</b> This feature is only supported on Windows, Linux, and macOS.</para>
    /// </summary>
    public static unsafe void SetJoyLight(int device, Color color)
    {
        NativeCalls.godot_icall_2_687(MethodBind37, GodotObject.GetPtr(Singleton), device, &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind38 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.HasJoyLight, 1116898809ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the joypad has an LED light that can change colors and/or brightness. See also <see cref="Godot.Input.SetJoyLight(int, Color)"/>.</para>
    /// <para><b>Note:</b> This feature is only supported on Windows, Linux, and macOS.</para>
    /// </summary>
    public static bool HasJoyLight(int device)
    {
        return NativeCalls.godot_icall_1_62(MethodBind38, GodotObject.GetPtr(Singleton), device).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind39 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLastMouseVelocity, 1497962370ul);

    /// <summary>
    /// <para>Returns the last mouse velocity. To provide a precise and jitter-free velocity, mouse velocity is only calculated every 0.1s. Therefore, mouse velocity will lag mouse movements.</para>
    /// </summary>
    public static Vector2 GetLastMouseVelocity()
    {
        return NativeCalls.godot_icall_0_37(MethodBind39, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind40 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLastMouseScreenVelocity, 1497962370ul);

    /// <summary>
    /// <para>Returns the last mouse velocity in screen coordinates. To provide a precise and jitter-free velocity, mouse velocity is only calculated every 0.1s. Therefore, mouse velocity will lag mouse movements.</para>
    /// </summary>
    public static Vector2 GetLastMouseScreenVelocity()
    {
        return NativeCalls.godot_icall_0_37(MethodBind40, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind41 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMouseButtonMask, 2512161324ul);

    /// <summary>
    /// <para>Returns mouse buttons as a bitmask. If multiple mouse buttons are pressed at the same time, the bits are added together. Equivalent to <see cref="Godot.DisplayServer.MouseGetButtonState()"/>.</para>
    /// </summary>
    public static MouseButtonMask GetMouseButtonMask()
    {
        return (MouseButtonMask)NativeCalls.godot_icall_0_39(MethodBind41, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind42 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMouseMode, 2228490894ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static void SetMouseMode(Input.MouseModeEnum mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind42, GodotObject.GetPtr(Singleton), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind43 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMouseMode, 965286182ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static Input.MouseModeEnum GetMouseMode()
    {
        return (Input.MouseModeEnum)NativeCalls.godot_icall_0_39(MethodBind43, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind44 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.WarpMouse, 743155724ul);

    /// <summary>
    /// <para>Sets the mouse position to the specified vector, provided in pixels and relative to an origin at the upper left corner of the currently focused Window Manager game window.</para>
    /// <para>Mouse position is clipped to the limits of the screen resolution, or to the limits of the game window if <see cref="Godot.Input.MouseModeEnum"/> is set to <see cref="Godot.Input.MouseModeEnum.Confined"/> or <see cref="Godot.Input.MouseModeEnum.ConfinedHidden"/>.</para>
    /// <para><b>Note:</b> <see cref="Godot.Input.WarpMouse(Vector2)"/> is only supported on Windows, macOS and Linux. It has no effect on Android, iOS and Web.</para>
    /// </summary>
    public static unsafe void WarpMouse(Vector2 position)
    {
        NativeCalls.godot_icall_1_36(MethodBind44, GodotObject.GetPtr(Singleton), &position);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind45 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ActionPress, 1713091165ul);

    /// <summary>
    /// <para>This will simulate pressing the specified action.</para>
    /// <para>The strength can be used for non-boolean actions, it's ranged between 0 and 1 representing the intensity of the given action.</para>
    /// <para><b>Note:</b> This method will not cause any <see cref="Godot.Node._Input(InputEvent)"/> calls. It is intended to be used with <see cref="Godot.Input.IsActionPressed(StringName, bool)"/> and <see cref="Godot.Input.IsActionJustPressed(StringName, bool)"/>. If you want to simulate <c>_input</c>, use <see cref="Godot.Input.ParseInputEvent(InputEvent)"/> instead.</para>
    /// </summary>
    public static void ActionPress(StringName action, float strength = 1.0f)
    {
        NativeCalls.godot_icall_2_751(MethodBind45, GodotObject.GetPtr(Singleton), (godot_string_name)(action?.NativeValue ?? default), strength);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind46 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ActionRelease, 3304788590ul);

    /// <summary>
    /// <para>If the specified action is already pressed, this will release it.</para>
    /// </summary>
    public static void ActionRelease(StringName action)
    {
        NativeCalls.godot_icall_1_64(MethodBind46, GodotObject.GetPtr(Singleton), (godot_string_name)(action?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind47 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDefaultCursorShape, 2124816902ul);

    /// <summary>
    /// <para>Sets the default cursor shape to be used in the viewport instead of <see cref="Godot.Input.CursorShape.Arrow"/>.</para>
    /// <para><b>Note:</b> If you want to change the default cursor shape for <see cref="Godot.Control"/>'s nodes, use <see cref="Godot.Control.MouseDefaultCursorShape"/> instead.</para>
    /// <para><b>Note:</b> This method generates an <see cref="Godot.InputEventMouseMotion"/> to update cursor immediately.</para>
    /// </summary>
    public static void SetDefaultCursorShape(Input.CursorShape shape = (Input.CursorShape)(0))
    {
        NativeCalls.godot_icall_1_38(MethodBind47, GodotObject.GetPtr(Singleton), (int)shape);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind48 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCurrentCursorShape, 3455658929ul);

    /// <summary>
    /// <para>Returns the currently assigned cursor shape.</para>
    /// </summary>
    public static Input.CursorShape GetCurrentCursorShape()
    {
        return (Input.CursorShape)NativeCalls.godot_icall_0_39(MethodBind48, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind49 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCustomMouseCursor, 703945977ul);

    /// <summary>
    /// <para>Sets a custom mouse cursor image, which is only visible inside the game window, for the given mouse <paramref name="shape"/>. The hotspot can also be specified. Passing <see langword="null"/> to the image parameter resets to the system cursor.</para>
    /// <para><paramref name="image"/> can be either <see cref="Godot.Texture2D"/> or <see cref="Godot.Image"/> and its size must be lower than or equal to 256×256. To avoid rendering issues, sizes lower than or equal to 128×128 are recommended.</para>
    /// <para><paramref name="hotspot"/> must be within <paramref name="image"/>'s size.</para>
    /// <para><b>Note:</b> <see cref="Godot.AnimatedTexture"/>s aren't supported as custom mouse cursors. If using an <see cref="Godot.AnimatedTexture"/>, only the first frame will be displayed.</para>
    /// <para><b>Note:</b> The <b>Lossless</b>, <b>Lossy</b> or <b>Uncompressed</b> compression modes are recommended. The <b>Video RAM</b> compression mode can be used, but it will be decompressed on the CPU, which means loading times are slowed down and no memory is saved compared to lossless modes.</para>
    /// <para><b>Note:</b> On the web platform, the maximum allowed cursor image size is 128×128. Cursor images larger than 32×32 will also only be displayed if the mouse cursor image is entirely located within the page for <a href="https://chromestatus.com/feature/5825971391299584">security reasons</a>.</para>
    /// </summary>
    /// <param name="hotspot">If the parameter is null, then the default value is <c>new Vector2(0.0f, 0.0f)</c>.</param>
    public static unsafe void SetCustomMouseCursor(Resource image, Input.CursorShape shape = (Input.CursorShape)(0), Nullable<Vector2> hotspot = null)
    {
        Vector2 hotspotOrDefVal = hotspot.HasValue ? hotspot.Value : new Vector2(0.0f, 0.0f);
        NativeCalls.godot_icall_3_442(MethodBind49, GodotObject.GetPtr(Singleton), GodotObject.GetPtr(image), (int)shape, &hotspotOrDefVal);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind50 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ParseInputEvent, 3754044979ul);

    /// <summary>
    /// <para>Feeds an <see cref="Godot.InputEvent"/> to the game. Can be used to artificially trigger input events from code. Also generates <see cref="Godot.Node._Input(InputEvent)"/> calls.</para>
    /// <para><code>
    /// var cancelEvent = new InputEventAction();
    /// cancelEvent.Action = "ui_cancel";
    /// cancelEvent.Pressed = true;
    /// Input.ParseInputEvent(cancelEvent);
    /// </code></para>
    /// <para><b>Note:</b> Calling this function has no influence on the operating system. So for example sending an <see cref="Godot.InputEventMouseMotion"/> will not move the OS mouse cursor to the specified position (use <see cref="Godot.Input.WarpMouse(Vector2)"/> instead) and sending Alt/Cmd + Tab as <see cref="Godot.InputEventKey"/> won't toggle between active windows.</para>
    /// </summary>
    public static void ParseInputEvent(InputEvent @event)
    {
        NativeCalls.godot_icall_1_56(MethodBind50, GodotObject.GetPtr(Singleton), GodotObject.GetPtr(@event));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind51 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SetUseAccumulatedInput, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static void SetUseAccumulatedInput(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind51, GodotObject.GetPtr(Singleton), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind52 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.IsUsingAccumulatedInput, 2240911060ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static bool IsUsingAccumulatedInput()
    {
        return NativeCalls.godot_icall_0_15(MethodBind52, GodotObject.GetPtr(Singleton)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind53 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.FlushBufferedEvents, 3218959716ul);

    /// <summary>
    /// <para>Sends all input events which are in the current buffer to the game loop. These events may have been buffered as a result of accumulated input (<see cref="Godot.Input.UseAccumulatedInput"/>) or agile input flushing (<c>ProjectSettings.input_devices/buffering/agile_event_flushing</c>).</para>
    /// <para>The engine will already do this itself at key execution points (at least once per frame). However, this can be useful in advanced cases where you want precise control over the timing of event handling.</para>
    /// </summary>
    public static void FlushBufferedEvents()
    {
        NativeCalls.godot_icall_0_3(MethodBind53, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind54 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEmulateMouseFromTouch, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static void SetEmulateMouseFromTouch(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind54, GodotObject.GetPtr(Singleton), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind55 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.IsEmulatingMouseFromTouch, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static bool IsEmulatingMouseFromTouch()
    {
        return NativeCalls.godot_icall_0_15(MethodBind55, GodotObject.GetPtr(Singleton)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind56 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEmulateTouchFromMouse, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static void SetEmulateTouchFromMouse(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind56, GodotObject.GetPtr(Singleton), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind57 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.IsEmulatingTouchFromMouse, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static bool IsEmulatingTouchFromMouse()
    {
        return NativeCalls.godot_icall_0_15(MethodBind57, GodotObject.GetPtr(Singleton)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind58 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.VibrateHandheld, 955504365ul);

    /// <summary>
    /// <para>Vibrate the handheld device for the specified duration in milliseconds.</para>
    /// <para><paramref name="amplitude"/> is the strength of the vibration, as a value between <c>0.0</c> and <c>1.0</c>. If set to <c>-1.0</c>, the default vibration strength of the device is used.</para>
    /// <para><b>Note:</b> This method is implemented on Android, iOS, and Web. It has no effect on other platforms.</para>
    /// <para><b>Note:</b> For Android, <see cref="Godot.Input.VibrateHandheld(int, float)"/> requires enabling the <c>VIBRATE</c> permission in the export preset. Otherwise, <see cref="Godot.Input.VibrateHandheld(int, float)"/> will have no effect.</para>
    /// <para><b>Note:</b> For iOS, specifying the duration is only supported in iOS 13 and later.</para>
    /// <para><b>Note:</b> For Web, the amplitude cannot be changed.</para>
    /// <para><b>Note:</b> Some web browsers such as Safari and Firefox for Android do not support <see cref="Godot.Input.VibrateHandheld(int, float)"/>.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static void VibrateHandheld(int durationMs)
    {
        NativeCalls.godot_icall_1_38(MethodBind58, GodotObject.GetPtr(Singleton), durationMs);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.Input.JoyConnectionChanged"/> event of a <see cref="Godot.Input"/> class.
    /// </summary>
    public delegate void JoyConnectionChangedEventHandler(long device, bool connected);

    private static void JoyConnectionChangedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 2);
        ((JoyConnectionChangedEventHandler)delegateObj)(VariantUtils.ConvertTo<long>(args[0]), VariantUtils.ConvertTo<bool>(args[1]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when a joypad device has been connected or disconnected.</para>
    /// </summary>
    public static unsafe event JoyConnectionChangedEventHandler JoyConnectionChanged
    {
        add => Singleton.Connect(SignalName.JoyConnectionChanged, Callable.CreateWithUnsafeTrampoline(value, &JoyConnectionChangedTrampoline));
        remove => Singleton.Disconnect(SignalName.JoyConnectionChanged, Callable.CreateWithUnsafeTrampoline(value, &JoyConnectionChangedTrampoline));
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public class PropertyName
    {
        /// <summary>
        /// Cached name for the 'mouse_mode' property.
        /// </summary>
        public static readonly StringName MouseMode = "mouse_mode";
        /// <summary>
        /// Cached name for the 'use_accumulated_input' property.
        /// </summary>
        public static readonly StringName UseAccumulatedInput = "use_accumulated_input";
        /// <summary>
        /// Cached name for the 'emulate_mouse_from_touch' property.
        /// </summary>
        public static readonly StringName EmulateMouseFromTouch = "emulate_mouse_from_touch";
        /// <summary>
        /// Cached name for the 'emulate_touch_from_mouse' property.
        /// </summary>
        public static readonly StringName EmulateTouchFromMouse = "emulate_touch_from_mouse";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public class MethodName
    {
        /// <summary>
        /// Cached name for the 'is_anything_pressed' method.
        /// </summary>
        public static readonly StringName IsAnythingPressed = "is_anything_pressed";
        /// <summary>
        /// Cached name for the 'is_key_pressed' method.
        /// </summary>
        public static readonly StringName IsKeyPressed = "is_key_pressed";
        /// <summary>
        /// Cached name for the 'is_physical_key_pressed' method.
        /// </summary>
        public static readonly StringName IsPhysicalKeyPressed = "is_physical_key_pressed";
        /// <summary>
        /// Cached name for the 'is_key_label_pressed' method.
        /// </summary>
        public static readonly StringName IsKeyLabelPressed = "is_key_label_pressed";
        /// <summary>
        /// Cached name for the 'is_mouse_button_pressed' method.
        /// </summary>
        public static readonly StringName IsMouseButtonPressed = "is_mouse_button_pressed";
        /// <summary>
        /// Cached name for the 'is_joy_button_pressed' method.
        /// </summary>
        public static readonly StringName IsJoyButtonPressed = "is_joy_button_pressed";
        /// <summary>
        /// Cached name for the 'is_action_pressed' method.
        /// </summary>
        public static readonly StringName IsActionPressed = "is_action_pressed";
        /// <summary>
        /// Cached name for the 'is_action_just_pressed' method.
        /// </summary>
        public static readonly StringName IsActionJustPressed = "is_action_just_pressed";
        /// <summary>
        /// Cached name for the 'is_action_just_released' method.
        /// </summary>
        public static readonly StringName IsActionJustReleased = "is_action_just_released";
        /// <summary>
        /// Cached name for the 'is_action_just_pressed_by_event' method.
        /// </summary>
        public static readonly StringName IsActionJustPressedByEvent = "is_action_just_pressed_by_event";
        /// <summary>
        /// Cached name for the 'is_action_just_released_by_event' method.
        /// </summary>
        public static readonly StringName IsActionJustReleasedByEvent = "is_action_just_released_by_event";
        /// <summary>
        /// Cached name for the 'get_action_strength' method.
        /// </summary>
        public static readonly StringName GetActionStrength = "get_action_strength";
        /// <summary>
        /// Cached name for the 'get_action_raw_strength' method.
        /// </summary>
        public static readonly StringName GetActionRawStrength = "get_action_raw_strength";
        /// <summary>
        /// Cached name for the 'get_axis' method.
        /// </summary>
        public static readonly StringName GetAxis = "get_axis";
        /// <summary>
        /// Cached name for the 'get_vector' method.
        /// </summary>
        public static readonly StringName GetVector = "get_vector";
        /// <summary>
        /// Cached name for the 'add_joy_mapping' method.
        /// </summary>
        public static readonly StringName AddJoyMapping = "add_joy_mapping";
        /// <summary>
        /// Cached name for the 'remove_joy_mapping' method.
        /// </summary>
        public static readonly StringName RemoveJoyMapping = "remove_joy_mapping";
        /// <summary>
        /// Cached name for the 'is_joy_known' method.
        /// </summary>
        public static readonly StringName IsJoyKnown = "is_joy_known";
        /// <summary>
        /// Cached name for the 'get_joy_axis' method.
        /// </summary>
        public static readonly StringName GetJoyAxis = "get_joy_axis";
        /// <summary>
        /// Cached name for the 'get_joy_name' method.
        /// </summary>
        public static readonly StringName GetJoyName = "get_joy_name";
        /// <summary>
        /// Cached name for the 'get_joy_guid' method.
        /// </summary>
        public static readonly StringName GetJoyGuid = "get_joy_guid";
        /// <summary>
        /// Cached name for the 'get_joy_info' method.
        /// </summary>
        public static readonly StringName GetJoyInfo = "get_joy_info";
        /// <summary>
        /// Cached name for the 'should_ignore_device' method.
        /// </summary>
        public static readonly StringName ShouldIgnoreDevice = "should_ignore_device";
        /// <summary>
        /// Cached name for the 'get_connected_joypads' method.
        /// </summary>
        public static readonly StringName GetConnectedJoypads = "get_connected_joypads";
        /// <summary>
        /// Cached name for the 'get_joy_vibration_strength' method.
        /// </summary>
        public static readonly StringName GetJoyVibrationStrength = "get_joy_vibration_strength";
        /// <summary>
        /// Cached name for the 'get_joy_vibration_duration' method.
        /// </summary>
        public static readonly StringName GetJoyVibrationDuration = "get_joy_vibration_duration";
        /// <summary>
        /// Cached name for the 'start_joy_vibration' method.
        /// </summary>
        public static readonly StringName StartJoyVibration = "start_joy_vibration";
        /// <summary>
        /// Cached name for the 'stop_joy_vibration' method.
        /// </summary>
        public static readonly StringName StopJoyVibration = "stop_joy_vibration";
        /// <summary>
        /// Cached name for the 'vibrate_handheld' method.
        /// </summary>
        public static readonly StringName VibrateHandheld = "vibrate_handheld";
        /// <summary>
        /// Cached name for the 'get_gravity' method.
        /// </summary>
        public static readonly StringName GetGravity = "get_gravity";
        /// <summary>
        /// Cached name for the 'get_accelerometer' method.
        /// </summary>
        public static readonly StringName GetAccelerometer = "get_accelerometer";
        /// <summary>
        /// Cached name for the 'get_magnetometer' method.
        /// </summary>
        public static readonly StringName GetMagnetometer = "get_magnetometer";
        /// <summary>
        /// Cached name for the 'get_gyroscope' method.
        /// </summary>
        public static readonly StringName GetGyroscope = "get_gyroscope";
        /// <summary>
        /// Cached name for the 'set_gravity' method.
        /// </summary>
        public static readonly StringName SetGravity = "set_gravity";
        /// <summary>
        /// Cached name for the 'set_accelerometer' method.
        /// </summary>
        public static readonly StringName SetAccelerometer = "set_accelerometer";
        /// <summary>
        /// Cached name for the 'set_magnetometer' method.
        /// </summary>
        public static readonly StringName SetMagnetometer = "set_magnetometer";
        /// <summary>
        /// Cached name for the 'set_gyroscope' method.
        /// </summary>
        public static readonly StringName SetGyroscope = "set_gyroscope";
        /// <summary>
        /// Cached name for the 'set_joy_light' method.
        /// </summary>
        public static readonly StringName SetJoyLight = "set_joy_light";
        /// <summary>
        /// Cached name for the 'has_joy_light' method.
        /// </summary>
        public static readonly StringName HasJoyLight = "has_joy_light";
        /// <summary>
        /// Cached name for the 'get_last_mouse_velocity' method.
        /// </summary>
        public static readonly StringName GetLastMouseVelocity = "get_last_mouse_velocity";
        /// <summary>
        /// Cached name for the 'get_last_mouse_screen_velocity' method.
        /// </summary>
        public static readonly StringName GetLastMouseScreenVelocity = "get_last_mouse_screen_velocity";
        /// <summary>
        /// Cached name for the 'get_mouse_button_mask' method.
        /// </summary>
        public static readonly StringName GetMouseButtonMask = "get_mouse_button_mask";
        /// <summary>
        /// Cached name for the 'set_mouse_mode' method.
        /// </summary>
        public static readonly StringName SetMouseMode = "set_mouse_mode";
        /// <summary>
        /// Cached name for the 'get_mouse_mode' method.
        /// </summary>
        public static readonly StringName GetMouseMode = "get_mouse_mode";
        /// <summary>
        /// Cached name for the 'warp_mouse' method.
        /// </summary>
        public static readonly StringName WarpMouse = "warp_mouse";
        /// <summary>
        /// Cached name for the 'action_press' method.
        /// </summary>
        public static readonly StringName ActionPress = "action_press";
        /// <summary>
        /// Cached name for the 'action_release' method.
        /// </summary>
        public static readonly StringName ActionRelease = "action_release";
        /// <summary>
        /// Cached name for the 'set_default_cursor_shape' method.
        /// </summary>
        public static readonly StringName SetDefaultCursorShape = "set_default_cursor_shape";
        /// <summary>
        /// Cached name for the 'get_current_cursor_shape' method.
        /// </summary>
        public static readonly StringName GetCurrentCursorShape = "get_current_cursor_shape";
        /// <summary>
        /// Cached name for the 'set_custom_mouse_cursor' method.
        /// </summary>
        public static readonly StringName SetCustomMouseCursor = "set_custom_mouse_cursor";
        /// <summary>
        /// Cached name for the 'parse_input_event' method.
        /// </summary>
        public static readonly StringName ParseInputEvent = "parse_input_event";
        /// <summary>
        /// Cached name for the 'set_use_accumulated_input' method.
        /// </summary>
        public static readonly StringName SetUseAccumulatedInput = "set_use_accumulated_input";
        /// <summary>
        /// Cached name for the 'is_using_accumulated_input' method.
        /// </summary>
        public static readonly StringName IsUsingAccumulatedInput = "is_using_accumulated_input";
        /// <summary>
        /// Cached name for the 'flush_buffered_events' method.
        /// </summary>
        public static readonly StringName FlushBufferedEvents = "flush_buffered_events";
        /// <summary>
        /// Cached name for the 'set_emulate_mouse_from_touch' method.
        /// </summary>
        public static readonly StringName SetEmulateMouseFromTouch = "set_emulate_mouse_from_touch";
        /// <summary>
        /// Cached name for the 'is_emulating_mouse_from_touch' method.
        /// </summary>
        public static readonly StringName IsEmulatingMouseFromTouch = "is_emulating_mouse_from_touch";
        /// <summary>
        /// Cached name for the 'set_emulate_touch_from_mouse' method.
        /// </summary>
        public static readonly StringName SetEmulateTouchFromMouse = "set_emulate_touch_from_mouse";
        /// <summary>
        /// Cached name for the 'is_emulating_touch_from_mouse' method.
        /// </summary>
        public static readonly StringName IsEmulatingTouchFromMouse = "is_emulating_touch_from_mouse";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public class SignalName
    {
        /// <summary>
        /// Cached name for the 'joy_connection_changed' signal.
        /// </summary>
        public static readonly StringName JoyConnectionChanged = "joy_connection_changed";
    }
}
