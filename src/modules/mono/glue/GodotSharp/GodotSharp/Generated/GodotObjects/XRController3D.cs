namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This is a helper 3D node that is linked to the tracking of controllers. It also offers several handy passthroughs to the state of buttons and such on the controllers.</para>
/// <para>Controllers are linked by their ID. You can create controller nodes before the controllers are available. If your game always uses two controllers (one for each hand), you can predefine the controllers with ID 1 and 2; they will become active as soon as the controllers are identified. If you expect additional controllers to be used, you should react to the signals and add XRController3D nodes to your scene.</para>
/// <para>The position of the controller node is automatically updated by the <see cref="Godot.XRServer"/>. This makes this node ideal to add child nodes to visualize the controller.</para>
/// <para>The current <see cref="Godot.XRInterface"/> defines the names of inputs. In the case of OpenXR, these are the names of actions in the current action set from the OpenXR action map.</para>
/// </summary>
public partial class XRController3D : XRNode3D
{
    private static readonly System.Type CachedType = typeof(XRController3D);

    private static readonly StringName NativeName = "XRController3D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public XRController3D() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal XRController3D(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal XRController3D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsButtonPressed, 2619796661ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the button with the given <paramref name="name"/> is pressed.</para>
    /// <para><b>Note:</b> The current <see cref="Godot.XRInterface"/> defines the <paramref name="name"/> for each input. In the case of OpenXR, these are the names of actions in the current action set.</para>
    /// </summary>
    public bool IsButtonPressed(StringName name)
    {
        return NativeCalls.godot_icall_1_105(MethodBind0, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetInput, 2760726917ul);

    /// <summary>
    /// <para>Returns a <see cref="Godot.Variant"/> for the input with the given <paramref name="name"/>. This works for any input type, the variant will be typed according to the actions configuration.</para>
    /// <para><b>Note:</b> The current <see cref="Godot.XRInterface"/> defines the <paramref name="name"/> for each input. In the case of OpenXR, these are the names of actions in the current action set.</para>
    /// </summary>
    public Variant GetInput(StringName name)
    {
        return NativeCalls.godot_icall_1_143(MethodBind1, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFloat, 2349060816ul);

    /// <summary>
    /// <para>Returns a numeric value for the input with the given <paramref name="name"/>. This is used for triggers and grip sensors.</para>
    /// <para><b>Note:</b> The current <see cref="Godot.XRInterface"/> defines the <paramref name="name"/> for each input. In the case of OpenXR, these are the names of actions in the current action set.</para>
    /// </summary>
    public float GetFloat(StringName name)
    {
        return NativeCalls.godot_icall_1_756(MethodBind2, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVector2, 3100822709ul);

    /// <summary>
    /// <para>Returns a <see cref="Godot.Vector2"/> for the input with the given <paramref name="name"/>. This is used for thumbsticks and thumbpads found on many controllers.</para>
    /// <para><b>Note:</b> The current <see cref="Godot.XRInterface"/> defines the <paramref name="name"/> for each input. In the case of OpenXR, these are the names of actions in the current action set.</para>
    /// </summary>
    public Vector2 GetVector2(StringName name)
    {
        return NativeCalls.godot_icall_1_156(MethodBind3, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTrackerHand, 4181770860ul);

    /// <summary>
    /// <para>Returns the hand holding this controller, if known.</para>
    /// </summary>
    public XRPositionalTracker.TrackerHand GetTrackerHand()
    {
        return (XRPositionalTracker.TrackerHand)NativeCalls.godot_icall_0_39(MethodBind4, GodotObject.GetPtr(this));
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.XRController3D.ButtonPressed"/> event of a <see cref="Godot.XRController3D"/> class.
    /// </summary>
    public delegate void ButtonPressedEventHandler(string name);

    private static void ButtonPressedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((ButtonPressedEventHandler)delegateObj)(VariantUtils.ConvertTo<string>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when a button on this controller is pressed.</para>
    /// </summary>
    public unsafe event ButtonPressedEventHandler ButtonPressed
    {
        add => Connect(SignalName.ButtonPressed, Callable.CreateWithUnsafeTrampoline(value, &ButtonPressedTrampoline));
        remove => Disconnect(SignalName.ButtonPressed, Callable.CreateWithUnsafeTrampoline(value, &ButtonPressedTrampoline));
    }

    protected void EmitSignalButtonPressed(string name)
    {
        EmitSignal(SignalName.ButtonPressed, name);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.XRController3D.ButtonReleased"/> event of a <see cref="Godot.XRController3D"/> class.
    /// </summary>
    public delegate void ButtonReleasedEventHandler(string name);

    private static void ButtonReleasedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((ButtonReleasedEventHandler)delegateObj)(VariantUtils.ConvertTo<string>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when a button on this controller is released.</para>
    /// </summary>
    public unsafe event ButtonReleasedEventHandler ButtonReleased
    {
        add => Connect(SignalName.ButtonReleased, Callable.CreateWithUnsafeTrampoline(value, &ButtonReleasedTrampoline));
        remove => Disconnect(SignalName.ButtonReleased, Callable.CreateWithUnsafeTrampoline(value, &ButtonReleasedTrampoline));
    }

    protected void EmitSignalButtonReleased(string name)
    {
        EmitSignal(SignalName.ButtonReleased, name);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.XRController3D.InputFloatChanged"/> event of a <see cref="Godot.XRController3D"/> class.
    /// </summary>
    public delegate void InputFloatChangedEventHandler(string name, double value);

    private static void InputFloatChangedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 2);
        ((InputFloatChangedEventHandler)delegateObj)(VariantUtils.ConvertTo<string>(args[0]), VariantUtils.ConvertTo<double>(args[1]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when a trigger or similar input on this controller changes value.</para>
    /// </summary>
    public unsafe event InputFloatChangedEventHandler InputFloatChanged
    {
        add => Connect(SignalName.InputFloatChanged, Callable.CreateWithUnsafeTrampoline(value, &InputFloatChangedTrampoline));
        remove => Disconnect(SignalName.InputFloatChanged, Callable.CreateWithUnsafeTrampoline(value, &InputFloatChangedTrampoline));
    }

    protected void EmitSignalInputFloatChanged(string name, double value)
    {
        EmitSignal(SignalName.InputFloatChanged, name, value);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.XRController3D.InputVector2Changed"/> event of a <see cref="Godot.XRController3D"/> class.
    /// </summary>
    public delegate void InputVector2ChangedEventHandler(string name, Vector2 value);

    private static void InputVector2ChangedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 2);
        ((InputVector2ChangedEventHandler)delegateObj)(VariantUtils.ConvertTo<string>(args[0]), VariantUtils.ConvertTo<Vector2>(args[1]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when a thumbstick or thumbpad on this controller is moved.</para>
    /// </summary>
    public unsafe event InputVector2ChangedEventHandler InputVector2Changed
    {
        add => Connect(SignalName.InputVector2Changed, Callable.CreateWithUnsafeTrampoline(value, &InputVector2ChangedTrampoline));
        remove => Disconnect(SignalName.InputVector2Changed, Callable.CreateWithUnsafeTrampoline(value, &InputVector2ChangedTrampoline));
    }

    protected void EmitSignalInputVector2Changed(string name, Vector2 value)
    {
        EmitSignal(SignalName.InputVector2Changed, name, value);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.XRController3D.ProfileChanged"/> event of a <see cref="Godot.XRController3D"/> class.
    /// </summary>
    public delegate void ProfileChangedEventHandler(string role);

    private static void ProfileChangedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((ProfileChangedEventHandler)delegateObj)(VariantUtils.ConvertTo<string>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when the interaction profile on this controller is changed.</para>
    /// </summary>
    public unsafe event ProfileChangedEventHandler ProfileChanged
    {
        add => Connect(SignalName.ProfileChanged, Callable.CreateWithUnsafeTrampoline(value, &ProfileChangedTrampoline));
        remove => Disconnect(SignalName.ProfileChanged, Callable.CreateWithUnsafeTrampoline(value, &ProfileChangedTrampoline));
    }

    protected void EmitSignalProfileChanged(string role)
    {
        EmitSignal(SignalName.ProfileChanged, role);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_button_pressed = "ButtonPressed";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_button_released = "ButtonReleased";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_input_float_changed = "InputFloatChanged";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_input_vector2_changed = "InputVector2Changed";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_profile_changed = "ProfileChanged";

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
        if (signal == SignalName.ButtonPressed)
        {
            if (HasGodotClassSignal(SignalProxyName_button_pressed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.ButtonReleased)
        {
            if (HasGodotClassSignal(SignalProxyName_button_released.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.InputFloatChanged)
        {
            if (HasGodotClassSignal(SignalProxyName_input_float_changed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.InputVector2Changed)
        {
            if (HasGodotClassSignal(SignalProxyName_input_vector2_changed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.ProfileChanged)
        {
            if (HasGodotClassSignal(SignalProxyName_profile_changed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        return base.HasGodotClassSignal(signal);
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : XRNode3D.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : XRNode3D.MethodName
    {
        /// <summary>
        /// Cached name for the 'is_button_pressed' method.
        /// </summary>
        public static readonly StringName IsButtonPressed = "is_button_pressed";
        /// <summary>
        /// Cached name for the 'get_input' method.
        /// </summary>
        public static readonly StringName GetInput = "get_input";
        /// <summary>
        /// Cached name for the 'get_float' method.
        /// </summary>
        public static readonly StringName GetFloat = "get_float";
        /// <summary>
        /// Cached name for the 'get_vector2' method.
        /// </summary>
        public static readonly StringName GetVector2 = "get_vector2";
        /// <summary>
        /// Cached name for the 'get_tracker_hand' method.
        /// </summary>
        public static readonly StringName GetTrackerHand = "get_tracker_hand";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : XRNode3D.SignalName
    {
        /// <summary>
        /// Cached name for the 'button_pressed' signal.
        /// </summary>
        public static readonly StringName ButtonPressed = "button_pressed";
        /// <summary>
        /// Cached name for the 'button_released' signal.
        /// </summary>
        public static readonly StringName ButtonReleased = "button_released";
        /// <summary>
        /// Cached name for the 'input_float_changed' signal.
        /// </summary>
        public static readonly StringName InputFloatChanged = "input_float_changed";
        /// <summary>
        /// Cached name for the 'input_vector2_changed' signal.
        /// </summary>
        public static readonly StringName InputVector2Changed = "input_vector2_changed";
        /// <summary>
        /// Cached name for the 'profile_changed' signal.
        /// </summary>
        public static readonly StringName ProfileChanged = "profile_changed";
    }
}
