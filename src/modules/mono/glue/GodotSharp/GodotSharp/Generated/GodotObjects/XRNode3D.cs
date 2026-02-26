namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This node can be bound to a specific pose of an <see cref="Godot.XRPositionalTracker"/> and will automatically have its <see cref="Godot.Node3D.Transform"/> updated by the <see cref="Godot.XRServer"/>. Nodes of this type must be added as children of the <see cref="Godot.XROrigin3D"/> node.</para>
/// </summary>
public partial class XRNode3D : Node3D
{
    /// <summary>
    /// <para>The name of the tracker we're bound to. Which trackers are available is not known during design time.</para>
    /// <para>Godot defines a number of standard trackers such as <c>left_hand</c> and <c>right_hand</c> but others may be configured within a given <see cref="Godot.XRInterface"/>.</para>
    /// </summary>
    public StringName Tracker
    {
        get
        {
            return GetTracker();
        }
        set
        {
            SetTracker(value);
        }
    }

    /// <summary>
    /// <para>The name of the pose we're bound to. Which poses a tracker supports is not known during design time.</para>
    /// <para>Godot defines number of standard pose names such as <c>aim</c> and <c>grip</c> but other may be configured within a given <see cref="Godot.XRInterface"/>.</para>
    /// </summary>
    public StringName Pose
    {
        get
        {
            return GetPoseName();
        }
        set
        {
            SetPoseName(value);
        }
    }

    /// <summary>
    /// <para>Enables showing the node when tracking starts, and hiding the node when tracking is lost.</para>
    /// </summary>
    public bool ShowWhenTracked
    {
        get
        {
            return GetShowWhenTracked();
        }
        set
        {
            SetShowWhenTracked(value);
        }
    }

    private static readonly System.Type CachedType = typeof(XRNode3D);

    private static readonly StringName NativeName = "XRNode3D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public XRNode3D() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal XRNode3D(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal XRNode3D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTracker, 3304788590ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTracker(StringName trackerName)
    {
        NativeCalls.godot_icall_1_64(MethodBind0, GodotObject.GetPtr(this), (godot_string_name)(trackerName?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTracker, 2002593661ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public StringName GetTracker()
    {
        return NativeCalls.godot_icall_0_65(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPoseName, 3304788590ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPoseName(StringName pose)
    {
        NativeCalls.godot_icall_1_64(MethodBind2, GodotObject.GetPtr(this), (godot_string_name)(pose?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPoseName, 2002593661ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public StringName GetPoseName()
    {
        return NativeCalls.godot_icall_0_65(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetShowWhenTracked, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetShowWhenTracked(bool show)
    {
        NativeCalls.godot_icall_1_14(MethodBind4, GodotObject.GetPtr(this), show.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetShowWhenTracked, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetShowWhenTracked()
    {
        return NativeCalls.godot_icall_0_15(MethodBind5, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetIsActive, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the <see cref="Godot.XRNode3D.Tracker"/> has been registered and the <see cref="Godot.XRNode3D.Pose"/> is being tracked.</para>
    /// </summary>
    public bool GetIsActive()
    {
        return NativeCalls.godot_icall_0_15(MethodBind6, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetHasTrackingData, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the <see cref="Godot.XRNode3D.Tracker"/> has current tracking data for the <see cref="Godot.XRNode3D.Pose"/> being tracked.</para>
    /// </summary>
    public bool GetHasTrackingData()
    {
        return NativeCalls.godot_icall_0_15(MethodBind7, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPose, 2806551826ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.XRPose"/> containing the current state of the pose being tracked. This gives access to additional properties of this pose.</para>
    /// </summary>
    public XRPose GetPose()
    {
        return (XRPose)NativeCalls.godot_icall_0_63(MethodBind8, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.TriggerHapticPulse, 508576839ul);

    /// <summary>
    /// <para>Triggers a haptic pulse on a device associated with this interface.</para>
    /// <para><paramref name="actionName"/> is the name of the action for this pulse.</para>
    /// <para><paramref name="frequency"/> is the frequency of the pulse, set to <c>0.0</c> to have the system use a default frequency.</para>
    /// <para><paramref name="amplitude"/> is the amplitude of the pulse between <c>0.0</c> and <c>1.0</c>.</para>
    /// <para><paramref name="durationSec"/> is the duration of the pulse in seconds.</para>
    /// <para><paramref name="delaySec"/> is a delay in seconds before the pulse is given.</para>
    /// </summary>
    public void TriggerHapticPulse(string actionName, double frequency, double amplitude, double durationSec, double delaySec)
    {
        NativeCalls.godot_icall_5_1514(MethodBind9, GodotObject.GetPtr(this), actionName, frequency, amplitude, durationSec, delaySec);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.XRNode3D.TrackingChanged"/> event of a <see cref="Godot.XRNode3D"/> class.
    /// </summary>
    public delegate void TrackingChangedEventHandler(bool tracking);

    private static void TrackingChangedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((TrackingChangedEventHandler)delegateObj)(VariantUtils.ConvertTo<bool>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when the <see cref="Godot.XRNode3D.Tracker"/> starts or stops receiving updated tracking data for the <see cref="Godot.XRNode3D.Pose"/> being tracked. The <c>tracking</c> argument indicates whether the tracker is getting updated tracking data.</para>
    /// </summary>
    public unsafe event TrackingChangedEventHandler TrackingChanged
    {
        add => Connect(SignalName.TrackingChanged, Callable.CreateWithUnsafeTrampoline(value, &TrackingChangedTrampoline));
        remove => Disconnect(SignalName.TrackingChanged, Callable.CreateWithUnsafeTrampoline(value, &TrackingChangedTrampoline));
    }

    protected void EmitSignalTrackingChanged(bool tracking)
    {
        EmitSignal(SignalName.TrackingChanged, tracking);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_tracking_changed = "TrackingChanged";

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
        if (signal == SignalName.TrackingChanged)
        {
            if (HasGodotClassSignal(SignalProxyName_tracking_changed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        return base.HasGodotClassSignal(signal);
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : Node3D.PropertyName
    {
        /// <summary>
        /// Cached name for the 'tracker' property.
        /// </summary>
        public static readonly StringName Tracker = "tracker";
        /// <summary>
        /// Cached name for the 'pose' property.
        /// </summary>
        public static readonly StringName Pose = "pose";
        /// <summary>
        /// Cached name for the 'show_when_tracked' property.
        /// </summary>
        public static readonly StringName ShowWhenTracked = "show_when_tracked";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Node3D.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_tracker' method.
        /// </summary>
        public static readonly StringName SetTracker = "set_tracker";
        /// <summary>
        /// Cached name for the 'get_tracker' method.
        /// </summary>
        public static readonly StringName GetTracker = "get_tracker";
        /// <summary>
        /// Cached name for the 'set_pose_name' method.
        /// </summary>
        public static readonly StringName SetPoseName = "set_pose_name";
        /// <summary>
        /// Cached name for the 'get_pose_name' method.
        /// </summary>
        public static readonly StringName GetPoseName = "get_pose_name";
        /// <summary>
        /// Cached name for the 'set_show_when_tracked' method.
        /// </summary>
        public static readonly StringName SetShowWhenTracked = "set_show_when_tracked";
        /// <summary>
        /// Cached name for the 'get_show_when_tracked' method.
        /// </summary>
        public static readonly StringName GetShowWhenTracked = "get_show_when_tracked";
        /// <summary>
        /// Cached name for the 'get_is_active' method.
        /// </summary>
        public static readonly StringName GetIsActive = "get_is_active";
        /// <summary>
        /// Cached name for the 'get_has_tracking_data' method.
        /// </summary>
        public static readonly StringName GetHasTrackingData = "get_has_tracking_data";
        /// <summary>
        /// Cached name for the 'get_pose' method.
        /// </summary>
        public static readonly StringName GetPose = "get_pose";
        /// <summary>
        /// Cached name for the 'trigger_haptic_pulse' method.
        /// </summary>
        public static readonly StringName TriggerHapticPulse = "trigger_haptic_pulse";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Node3D.SignalName
    {
        /// <summary>
        /// Cached name for the 'tracking_changed' signal.
        /// </summary>
        public static readonly StringName TrackingChanged = "tracking_changed";
    }
}
