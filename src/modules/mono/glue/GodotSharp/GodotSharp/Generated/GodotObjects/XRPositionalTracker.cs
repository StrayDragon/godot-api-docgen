namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>An instance of this object represents a device that is tracked, such as a controller or anchor point. HMDs aren't represented here as they are handled internally.</para>
/// <para>As controllers are turned on and the <see cref="Godot.XRInterface"/> detects them, instances of this object are automatically added to this list of active tracking objects accessible through the <see cref="Godot.XRServer"/>.</para>
/// <para>The <see cref="Godot.XRNode3D"/> and <see cref="Godot.XRAnchor3D"/> both consume objects of this type and should be used in your project. The positional trackers are just under-the-hood objects that make this all work. These are mostly exposed so that GDExtension-based interfaces can interact with them.</para>
/// </summary>
public partial class XRPositionalTracker : XRTracker
{
    public enum TrackerHand : long
    {
        /// <summary>
        /// <para>The hand this tracker is held in is unknown or not applicable.</para>
        /// </summary>
        Unknown = 0,
        /// <summary>
        /// <para>This tracker is the left hand controller.</para>
        /// </summary>
        Left = 1,
        /// <summary>
        /// <para>This tracker is the right hand controller.</para>
        /// </summary>
        Right = 2,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.XRPositionalTracker.TrackerHand"/> enum.</para>
        /// </summary>
        Max = 3
    }

    /// <summary>
    /// <para>The profile associated with this tracker, interface dependent but will indicate the type of controller being tracked.</para>
    /// </summary>
    public string Profile
    {
        get
        {
            return GetTrackerProfile();
        }
        set
        {
            SetTrackerProfile(value);
        }
    }

    /// <summary>
    /// <para>Defines which hand this tracker relates to.</para>
    /// </summary>
    public XRPositionalTracker.TrackerHand Hand
    {
        get
        {
            return GetTrackerHand();
        }
        set
        {
            SetTrackerHand(value);
        }
    }

    private static readonly System.Type CachedType = typeof(XRPositionalTracker);

    private static readonly StringName NativeName = "XRPositionalTracker";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public XRPositionalTracker() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal XRPositionalTracker(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal XRPositionalTracker(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTrackerProfile, 201670096ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetTrackerProfile()
    {
        return NativeCalls.godot_icall_0_58(MethodBind0, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTrackerProfile, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTrackerProfile(string profile)
    {
        NativeCalls.godot_icall_1_57(MethodBind1, GodotObject.GetPtr(this), profile);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTrackerHand, 4181770860ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public XRPositionalTracker.TrackerHand GetTrackerHand()
    {
        return (XRPositionalTracker.TrackerHand)NativeCalls.godot_icall_0_39(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTrackerHand, 3904108980ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTrackerHand(XRPositionalTracker.TrackerHand hand)
    {
        NativeCalls.godot_icall_1_38(MethodBind3, GodotObject.GetPtr(this), (int)hand);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasPose, 2619796661ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the tracker is available and is currently tracking the bound <paramref name="name"/> pose.</para>
    /// </summary>
    public bool HasPose(StringName name)
    {
        return NativeCalls.godot_icall_1_105(MethodBind4, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPose, 4099720006ul);

    /// <summary>
    /// <para>Returns the current <see cref="Godot.XRPose"/> state object for the bound <paramref name="name"/> pose.</para>
    /// </summary>
    public XRPose GetPose(StringName name)
    {
        return (XRPose)NativeCalls.godot_icall_1_119(MethodBind5, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.InvalidatePose, 3304788590ul);

    /// <summary>
    /// <para>Marks this pose as invalid, we don't clear the last reported state but it allows users to decide if trackers need to be hidden if we lose tracking or just remain at their last known position.</para>
    /// </summary>
    public void InvalidatePose(StringName name)
    {
        NativeCalls.godot_icall_1_64(MethodBind6, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPose, 3451230163ul);

    /// <summary>
    /// <para>Sets the transform, linear velocity, angular velocity and tracking confidence for the given pose. This method is called by an <see cref="Godot.XRInterface"/> implementation and should not be used directly.</para>
    /// </summary>
    public unsafe void SetPose(StringName name, Transform3D transform, Vector3 linearVelocity, Vector3 angularVelocity, XRPose.TrackingConfidenceEnum trackingConfidence)
    {
        NativeCalls.godot_icall_5_1515(MethodBind7, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default), &transform, &linearVelocity, &angularVelocity, (int)trackingConfidence);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetInput, 2760726917ul);

    /// <summary>
    /// <para>Returns an input for this tracker. It can return a boolean, float or <see cref="Godot.Vector2"/> value depending on whether the input is a button, trigger or thumbstick/thumbpad.</para>
    /// </summary>
    [Obsolete("Use through 'XRControllerTracker'.")]
    public Variant GetInput(StringName name)
    {
        return NativeCalls.godot_icall_1_143(MethodBind8, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetInput, 3776071444ul);

    /// <summary>
    /// <para>Changes the value for the given input. This method is called by an <see cref="Godot.XRInterface"/> implementation and should not be used directly.</para>
    /// </summary>
    [Obsolete("Use through 'XRControllerTracker'.")]
    public void SetInput(StringName name, Variant value)
    {
        NativeCalls.godot_icall_2_142(MethodBind9, GodotObject.GetPtr(this), (godot_string_name)(name?.NativeValue ?? default), value);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.XRPositionalTracker.PoseChanged"/> event of a <see cref="Godot.XRPositionalTracker"/> class.
    /// </summary>
    public delegate void PoseChangedEventHandler(XRPose pose);

    private static void PoseChangedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((PoseChangedEventHandler)delegateObj)(VariantUtils.ConvertTo<XRPose>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when the state of a pose tracked by this tracker changes.</para>
    /// </summary>
    public unsafe event PoseChangedEventHandler PoseChanged
    {
        add => Connect(SignalName.PoseChanged, Callable.CreateWithUnsafeTrampoline(value, &PoseChangedTrampoline));
        remove => Disconnect(SignalName.PoseChanged, Callable.CreateWithUnsafeTrampoline(value, &PoseChangedTrampoline));
    }

    protected void EmitSignalPoseChanged(XRPose pose)
    {
        EmitSignal(SignalName.PoseChanged, pose);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.XRPositionalTracker.PoseLostTracking"/> event of a <see cref="Godot.XRPositionalTracker"/> class.
    /// </summary>
    public delegate void PoseLostTrackingEventHandler(XRPose pose);

    private static void PoseLostTrackingTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((PoseLostTrackingEventHandler)delegateObj)(VariantUtils.ConvertTo<XRPose>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when a pose tracked by this tracker stops getting updated tracking data.</para>
    /// </summary>
    public unsafe event PoseLostTrackingEventHandler PoseLostTracking
    {
        add => Connect(SignalName.PoseLostTracking, Callable.CreateWithUnsafeTrampoline(value, &PoseLostTrackingTrampoline));
        remove => Disconnect(SignalName.PoseLostTracking, Callable.CreateWithUnsafeTrampoline(value, &PoseLostTrackingTrampoline));
    }

    protected void EmitSignalPoseLostTracking(XRPose pose)
    {
        EmitSignal(SignalName.PoseLostTracking, pose);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.XRPositionalTracker.ButtonPressed"/> event of a <see cref="Godot.XRPositionalTracker"/> class.
    /// </summary>
    public delegate void ButtonPressedEventHandler(string name);

    private static void ButtonPressedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((ButtonPressedEventHandler)delegateObj)(VariantUtils.ConvertTo<string>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when a button on this tracker is pressed. Note that many XR runtimes allow other inputs to be mapped to buttons.</para>
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
    /// Represents the method that handles the <see cref="Godot.XRPositionalTracker.ButtonReleased"/> event of a <see cref="Godot.XRPositionalTracker"/> class.
    /// </summary>
    public delegate void ButtonReleasedEventHandler(string name);

    private static void ButtonReleasedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((ButtonReleasedEventHandler)delegateObj)(VariantUtils.ConvertTo<string>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when a button on this tracker is released.</para>
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
    /// Represents the method that handles the <see cref="Godot.XRPositionalTracker.InputFloatChanged"/> event of a <see cref="Godot.XRPositionalTracker"/> class.
    /// </summary>
    public delegate void InputFloatChangedEventHandler(string name, double value);

    private static void InputFloatChangedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 2);
        ((InputFloatChangedEventHandler)delegateObj)(VariantUtils.ConvertTo<string>(args[0]), VariantUtils.ConvertTo<double>(args[1]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when a trigger or similar input on this tracker changes value.</para>
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
    /// Represents the method that handles the <see cref="Godot.XRPositionalTracker.InputVector2Changed"/> event of a <see cref="Godot.XRPositionalTracker"/> class.
    /// </summary>
    public delegate void InputVector2ChangedEventHandler(string name, Vector2 vector);

    private static void InputVector2ChangedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 2);
        ((InputVector2ChangedEventHandler)delegateObj)(VariantUtils.ConvertTo<string>(args[0]), VariantUtils.ConvertTo<Vector2>(args[1]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when a thumbstick or thumbpad on this tracker moves.</para>
    /// </summary>
    public unsafe event InputVector2ChangedEventHandler InputVector2Changed
    {
        add => Connect(SignalName.InputVector2Changed, Callable.CreateWithUnsafeTrampoline(value, &InputVector2ChangedTrampoline));
        remove => Disconnect(SignalName.InputVector2Changed, Callable.CreateWithUnsafeTrampoline(value, &InputVector2ChangedTrampoline));
    }

    protected void EmitSignalInputVector2Changed(string name, Vector2 vector)
    {
        EmitSignal(SignalName.InputVector2Changed, name, vector);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.XRPositionalTracker.ProfileChanged"/> event of a <see cref="Godot.XRPositionalTracker"/> class.
    /// </summary>
    public delegate void ProfileChangedEventHandler(string role);

    private static void ProfileChangedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((ProfileChangedEventHandler)delegateObj)(VariantUtils.ConvertTo<string>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when the profile of our tracker changes.</para>
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
    private static readonly StringName SignalProxyName_pose_changed = "PoseChanged";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_pose_lost_tracking = "PoseLostTracking";

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
        if (signal == SignalName.PoseChanged)
        {
            if (HasGodotClassSignal(SignalProxyName_pose_changed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.PoseLostTracking)
        {
            if (HasGodotClassSignal(SignalProxyName_pose_lost_tracking.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
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
    public new class PropertyName : XRTracker.PropertyName
    {
        /// <summary>
        /// Cached name for the 'profile' property.
        /// </summary>
        public static readonly StringName Profile = "profile";
        /// <summary>
        /// Cached name for the 'hand' property.
        /// </summary>
        public static readonly StringName Hand = "hand";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : XRTracker.MethodName
    {
        /// <summary>
        /// Cached name for the 'get_tracker_profile' method.
        /// </summary>
        public static readonly StringName GetTrackerProfile = "get_tracker_profile";
        /// <summary>
        /// Cached name for the 'set_tracker_profile' method.
        /// </summary>
        public static readonly StringName SetTrackerProfile = "set_tracker_profile";
        /// <summary>
        /// Cached name for the 'get_tracker_hand' method.
        /// </summary>
        public static readonly StringName GetTrackerHand = "get_tracker_hand";
        /// <summary>
        /// Cached name for the 'set_tracker_hand' method.
        /// </summary>
        public static readonly StringName SetTrackerHand = "set_tracker_hand";
        /// <summary>
        /// Cached name for the 'has_pose' method.
        /// </summary>
        public static readonly StringName HasPose = "has_pose";
        /// <summary>
        /// Cached name for the 'get_pose' method.
        /// </summary>
        public static readonly StringName GetPose = "get_pose";
        /// <summary>
        /// Cached name for the 'invalidate_pose' method.
        /// </summary>
        public static readonly StringName InvalidatePose = "invalidate_pose";
        /// <summary>
        /// Cached name for the 'set_pose' method.
        /// </summary>
        public static readonly StringName SetPose = "set_pose";
        /// <summary>
        /// Cached name for the 'get_input' method.
        /// </summary>
        public static readonly StringName GetInput = "get_input";
        /// <summary>
        /// Cached name for the 'set_input' method.
        /// </summary>
        public static readonly StringName SetInput = "set_input";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : XRTracker.SignalName
    {
        /// <summary>
        /// Cached name for the 'pose_changed' signal.
        /// </summary>
        public static readonly StringName PoseChanged = "pose_changed";
        /// <summary>
        /// Cached name for the 'pose_lost_tracking' signal.
        /// </summary>
        public static readonly StringName PoseLostTracking = "pose_lost_tracking";
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
