namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Abstract base class of all types of input events. See <see cref="Godot.Node._Input(InputEvent)"/>.</para>
/// </summary>
public partial class InputEvent : Resource
{
    /// <summary>
    /// <para>Device ID used for emulated mouse input from a touchscreen, or for emulated touch input from a mouse. This can be used to distinguish emulated mouse input from physical mouse input, or emulated touch input from physical touch input.</para>
    /// </summary>
    public const long DeviceIdEmulation = -1;

    /// <summary>
    /// <para>The event's device ID.</para>
    /// <para><b>Note:</b> <see cref="Godot.InputEvent.Device"/> can be negative for special use cases that don't refer to devices physically present on the system. See <see cref="Godot.InputEvent.DeviceIdEmulation"/>.</para>
    /// </summary>
    public int Device
    {
        get
        {
            return GetDevice();
        }
        set
        {
            SetDevice(value);
        }
    }

    private static readonly System.Type CachedType = typeof(InputEvent);

    private static readonly StringName NativeName = "InputEvent";

    internal InputEvent() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal InputEvent(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal InputEvent(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDevice, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDevice(int device)
    {
        NativeCalls.godot_icall_1_38(MethodBind0, GodotObject.GetPtr(this), device);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDevice, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetDevice()
    {
        return NativeCalls.godot_icall_0_39(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsAction, 1558498928ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if this input event matches a pre-defined action of any type.</para>
    /// <para>If <paramref name="exactMatch"/> is <see langword="false"/>, it ignores additional input modifiers for <see cref="Godot.InputEventKey"/> and <see cref="Godot.InputEventMouseButton"/> events, and the direction for <see cref="Godot.InputEventJoypadMotion"/> events.</para>
    /// </summary>
    public bool IsAction(StringName action, bool exactMatch = false)
    {
        return NativeCalls.godot_icall_2_745(MethodBind2, GodotObject.GetPtr(this), (godot_string_name)(action?.NativeValue ?? default), exactMatch.ToGodotBool()).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsActionPressed, 1631499404ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the given action matches this event and is being pressed (and is not an echo event for <see cref="Godot.InputEventKey"/> events, unless <paramref name="allowEcho"/> is <see langword="true"/>). Not relevant for events of type <see cref="Godot.InputEventMouseMotion"/> or <see cref="Godot.InputEventScreenDrag"/>.</para>
    /// <para>If <paramref name="exactMatch"/> is <see langword="false"/>, it ignores additional input modifiers for <see cref="Godot.InputEventKey"/> and <see cref="Godot.InputEventMouseButton"/> events, and the direction for <see cref="Godot.InputEventJoypadMotion"/> events.</para>
    /// <para><b>Note:</b> Due to keyboard ghosting, <see cref="Godot.InputEvent.IsActionPressed(StringName, bool, bool)"/> may return <see langword="false"/> even if one of the action's keys is pressed. See <a href="$DOCS_URL/tutorials/inputs/input_examples.html#keyboard-events">Input examples</a> in the documentation for more information.</para>
    /// </summary>
    public bool IsActionPressed(StringName action, bool allowEcho = false, bool exactMatch = false)
    {
        return NativeCalls.godot_icall_3_752(MethodBind3, GodotObject.GetPtr(this), (godot_string_name)(action?.NativeValue ?? default), allowEcho.ToGodotBool(), exactMatch.ToGodotBool()).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsActionReleased, 1558498928ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the given action matches this event and is released (i.e. not pressed). Not relevant for events of type <see cref="Godot.InputEventMouseMotion"/> or <see cref="Godot.InputEventScreenDrag"/>.</para>
    /// <para>If <paramref name="exactMatch"/> is <see langword="false"/>, it ignores additional input modifiers for <see cref="Godot.InputEventKey"/> and <see cref="Godot.InputEventMouseButton"/> events, and the direction for <see cref="Godot.InputEventJoypadMotion"/> events.</para>
    /// </summary>
    public bool IsActionReleased(StringName action, bool exactMatch = false)
    {
        return NativeCalls.godot_icall_2_745(MethodBind4, GodotObject.GetPtr(this), (godot_string_name)(action?.NativeValue ?? default), exactMatch.ToGodotBool()).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetActionStrength, 801543509ul);

    /// <summary>
    /// <para>Returns a value between 0.0 and 1.0 depending on the given actions' state. Useful for getting the value of events of type <see cref="Godot.InputEventJoypadMotion"/>.</para>
    /// <para>If <paramref name="exactMatch"/> is <see langword="false"/>, it ignores additional input modifiers for <see cref="Godot.InputEventKey"/> and <see cref="Godot.InputEventMouseButton"/> events, and the direction for <see cref="Godot.InputEventJoypadMotion"/> events.</para>
    /// </summary>
    public float GetActionStrength(StringName action, bool exactMatch = false)
    {
        return NativeCalls.godot_icall_2_747(MethodBind5, GodotObject.GetPtr(this), (godot_string_name)(action?.NativeValue ?? default), exactMatch.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsCanceled, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if this input event has been canceled.</para>
    /// </summary>
    public bool IsCanceled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind6, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsPressed, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if this input event is pressed. Not relevant for events of type <see cref="Godot.InputEventMouseMotion"/> or <see cref="Godot.InputEventScreenDrag"/>.</para>
    /// <para><b>Note:</b> Due to keyboard ghosting, <see cref="Godot.InputEvent.IsPressed()"/> may return <see langword="false"/> even if one of the action's keys is pressed. See <a href="$DOCS_URL/tutorials/inputs/input_examples.html#keyboard-events">Input examples</a> in the documentation for more information.</para>
    /// </summary>
    public bool IsPressed()
    {
        return NativeCalls.godot_icall_0_15(MethodBind7, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsReleased, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if this input event is released. Not relevant for events of type <see cref="Godot.InputEventMouseMotion"/> or <see cref="Godot.InputEventScreenDrag"/>.</para>
    /// </summary>
    public bool IsReleased()
    {
        return NativeCalls.godot_icall_0_15(MethodBind8, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsEcho, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if this input event is an echo event (only for events of type <see cref="Godot.InputEventKey"/>). An echo event is a repeated key event sent when the user is holding down the key. Any other event type returns <see langword="false"/>.</para>
    /// <para><b>Note:</b> The rate at which echo events are sent is typically around 20 events per second (after holding down the key for roughly half a second). However, the key repeat delay/speed can be changed by the user or disabled entirely in the operating system settings. To ensure your project works correctly on all configurations, do not assume the user has a specific key repeat configuration in your project's behavior.</para>
    /// </summary>
    public bool IsEcho()
    {
        return NativeCalls.godot_icall_0_15(MethodBind9, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AsText, 201670096ul);

    /// <summary>
    /// <para>Returns a <see cref="string"/> representation of the event.</para>
    /// </summary>
    public string AsText()
    {
        return NativeCalls.godot_icall_0_58(MethodBind10, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsMatch, 1754951977ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the specified <paramref name="event"/> matches this event. Only valid for action events, which include key (<see cref="Godot.InputEventKey"/>), button (<see cref="Godot.InputEventMouseButton"/> or <see cref="Godot.InputEventJoypadButton"/>), axis <see cref="Godot.InputEventJoypadMotion"/>, and action (<see cref="Godot.InputEventAction"/>) events.</para>
    /// <para>If <paramref name="exactMatch"/> is <see langword="false"/>, the check ignores additional input modifiers for <see cref="Godot.InputEventKey"/> and <see cref="Godot.InputEventMouseButton"/> events, and the direction for <see cref="Godot.InputEventJoypadMotion"/> events.</para>
    /// <para><b>Note:</b> This method only considers the event configuration (such as the keyboard key or the joypad axis), not state information like <see cref="Godot.InputEvent.IsPressed()"/>, <see cref="Godot.InputEvent.IsReleased()"/>, <see cref="Godot.InputEvent.IsEcho()"/>, or <see cref="Godot.InputEvent.IsCanceled()"/>.</para>
    /// </summary>
    public bool IsMatch(InputEvent @event, bool exactMatch = true)
    {
        return NativeCalls.godot_icall_2_753(MethodBind11, GodotObject.GetPtr(this), GodotObject.GetPtr(@event), exactMatch.ToGodotBool()).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsActionType, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if this input event's type is one that can be assigned to an input action: <see cref="Godot.InputEventKey"/>, <see cref="Godot.InputEventMouseButton"/>, <see cref="Godot.InputEventJoypadButton"/>, <see cref="Godot.InputEventJoypadMotion"/>, <see cref="Godot.InputEventAction"/>. Returns <see langword="false"/> for all other input event types.</para>
    /// </summary>
    public bool IsActionType()
    {
        return NativeCalls.godot_icall_0_15(MethodBind12, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Accumulate, 1062211774ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the given input event and this input event can be added together (only for events of type <see cref="Godot.InputEventMouseMotion"/>).</para>
    /// <para>The given input event's position, global position and speed will be copied. The resulting <c>relative</c> is a sum of both events. Both events' modifiers have to be identical.</para>
    /// </summary>
    public bool Accumulate(InputEvent withEvent)
    {
        return NativeCalls.godot_icall_1_176(MethodBind13, GodotObject.GetPtr(this), GodotObject.GetPtr(withEvent)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.XformedBy, 1282766827ul);

    /// <summary>
    /// <para>Returns a copy of the given input event which has been offset by <paramref name="localOfs"/> and transformed by <paramref name="xform"/>. Relevant for events of type <see cref="Godot.InputEventMouseButton"/>, <see cref="Godot.InputEventMouseMotion"/>, <see cref="Godot.InputEventScreenTouch"/>, <see cref="Godot.InputEventScreenDrag"/>, <see cref="Godot.InputEventMagnifyGesture"/> and <see cref="Godot.InputEventPanGesture"/>.</para>
    /// </summary>
    /// <param name="localOfs">If the parameter is null, then the default value is <c>new Vector2(0.0f, 0.0f)</c>.</param>
    public unsafe InputEvent XformedBy(Transform2D xform, Nullable<Vector2> localOfs = null)
    {
        Vector2 localOfsOrDefVal = localOfs.HasValue ? localOfs.Value : new Vector2(0.0f, 0.0f);
        return (InputEvent)NativeCalls.godot_icall_2_754(MethodBind14, GodotObject.GetPtr(this), &xform, &localOfsOrDefVal);
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
        /// Cached name for the 'device' property.
        /// </summary>
        public static readonly StringName Device = "device";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Resource.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_device' method.
        /// </summary>
        public static readonly StringName SetDevice = "set_device";
        /// <summary>
        /// Cached name for the 'get_device' method.
        /// </summary>
        public static readonly StringName GetDevice = "get_device";
        /// <summary>
        /// Cached name for the 'is_action' method.
        /// </summary>
        public static readonly StringName IsAction = "is_action";
        /// <summary>
        /// Cached name for the 'is_action_pressed' method.
        /// </summary>
        public static readonly StringName IsActionPressed = "is_action_pressed";
        /// <summary>
        /// Cached name for the 'is_action_released' method.
        /// </summary>
        public static readonly StringName IsActionReleased = "is_action_released";
        /// <summary>
        /// Cached name for the 'get_action_strength' method.
        /// </summary>
        public static readonly StringName GetActionStrength = "get_action_strength";
        /// <summary>
        /// Cached name for the 'is_canceled' method.
        /// </summary>
        public static readonly StringName IsCanceled = "is_canceled";
        /// <summary>
        /// Cached name for the 'is_pressed' method.
        /// </summary>
        public static readonly StringName IsPressed = "is_pressed";
        /// <summary>
        /// Cached name for the 'is_released' method.
        /// </summary>
        public static readonly StringName IsReleased = "is_released";
        /// <summary>
        /// Cached name for the 'is_echo' method.
        /// </summary>
        public static readonly StringName IsEcho = "is_echo";
        /// <summary>
        /// Cached name for the 'as_text' method.
        /// </summary>
        public static readonly StringName AsText = "as_text";
        /// <summary>
        /// Cached name for the 'is_match' method.
        /// </summary>
        public static readonly StringName IsMatch = "is_match";
        /// <summary>
        /// Cached name for the 'is_action_type' method.
        /// </summary>
        public static readonly StringName IsActionType = "is_action_type";
        /// <summary>
        /// Cached name for the 'accumulate' method.
        /// </summary>
        public static readonly StringName Accumulate = "accumulate";
        /// <summary>
        /// Cached name for the 'xformed_by' method.
        /// </summary>
        public static readonly StringName XformedBy = "xformed_by";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Resource.SignalName
    {
    }
}
