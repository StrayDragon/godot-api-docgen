namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A hand tracking system will create an instance of this object and add it to the <see cref="Godot.XRServer"/>. This tracking system will then obtain skeleton data, convert it to the Godot Humanoid hand skeleton and store this data on the <see cref="Godot.XRHandTracker"/> object.</para>
/// <para>Use <see cref="Godot.XRHandModifier3D"/> to animate a hand mesh using hand tracking data.</para>
/// </summary>
public partial class XRHandTracker : XRPositionalTracker
{
    public enum HandTrackingSourceEnum : long
    {
        /// <summary>
        /// <para>The source of hand tracking data is unknown.</para>
        /// </summary>
        Unknown = 0,
        /// <summary>
        /// <para>The source of hand tracking data is unobstructed, meaning that an accurate method of hand tracking is used. These include optical hand tracking, data gloves, etc.</para>
        /// </summary>
        Unobstructed = 1,
        /// <summary>
        /// <para>The source of hand tracking data is a controller, meaning that joint positions are inferred from controller inputs.</para>
        /// </summary>
        Controller = 2,
        /// <summary>
        /// <para>No hand tracking data is tracked, this either means the hand is obscured, the controller is turned off, or tracking is not supported for the current input type.</para>
        /// </summary>
        NotTracked = 3,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.XRHandTracker.HandTrackingSourceEnum"/> enum.</para>
        /// </summary>
        Max = 4
    }

    public enum HandJoint : long
    {
        /// <summary>
        /// <para>Palm joint.</para>
        /// </summary>
        Palm = 0,
        /// <summary>
        /// <para>Wrist joint.</para>
        /// </summary>
        Wrist = 1,
        /// <summary>
        /// <para>Thumb metacarpal joint.</para>
        /// </summary>
        ThumbMetacarpal = 2,
        /// <summary>
        /// <para>Thumb phalanx proximal joint.</para>
        /// </summary>
        ThumbPhalanxProximal = 3,
        /// <summary>
        /// <para>Thumb phalanx distal joint.</para>
        /// </summary>
        ThumbPhalanxDistal = 4,
        /// <summary>
        /// <para>Thumb tip joint.</para>
        /// </summary>
        ThumbTip = 5,
        /// <summary>
        /// <para>Index finger metacarpal joint.</para>
        /// </summary>
        IndexFingerMetacarpal = 6,
        /// <summary>
        /// <para>Index finger phalanx proximal joint.</para>
        /// </summary>
        IndexFingerPhalanxProximal = 7,
        /// <summary>
        /// <para>Index finger phalanx intermediate joint.</para>
        /// </summary>
        IndexFingerPhalanxIntermediate = 8,
        /// <summary>
        /// <para>Index finger phalanx distal joint.</para>
        /// </summary>
        IndexFingerPhalanxDistal = 9,
        /// <summary>
        /// <para>Index finger tip joint.</para>
        /// </summary>
        IndexFingerTip = 10,
        /// <summary>
        /// <para>Middle finger metacarpal joint.</para>
        /// </summary>
        MiddleFingerMetacarpal = 11,
        /// <summary>
        /// <para>Middle finger phalanx proximal joint.</para>
        /// </summary>
        MiddleFingerPhalanxProximal = 12,
        /// <summary>
        /// <para>Middle finger phalanx intermediate joint.</para>
        /// </summary>
        MiddleFingerPhalanxIntermediate = 13,
        /// <summary>
        /// <para>Middle finger phalanx distal joint.</para>
        /// </summary>
        MiddleFingerPhalanxDistal = 14,
        /// <summary>
        /// <para>Middle finger tip joint.</para>
        /// </summary>
        MiddleFingerTip = 15,
        /// <summary>
        /// <para>Ring finger metacarpal joint.</para>
        /// </summary>
        RingFingerMetacarpal = 16,
        /// <summary>
        /// <para>Ring finger phalanx proximal joint.</para>
        /// </summary>
        RingFingerPhalanxProximal = 17,
        /// <summary>
        /// <para>Ring finger phalanx intermediate joint.</para>
        /// </summary>
        RingFingerPhalanxIntermediate = 18,
        /// <summary>
        /// <para>Ring finger phalanx distal joint.</para>
        /// </summary>
        RingFingerPhalanxDistal = 19,
        /// <summary>
        /// <para>Ring finger tip joint.</para>
        /// </summary>
        RingFingerTip = 20,
        /// <summary>
        /// <para>Pinky finger metacarpal joint.</para>
        /// </summary>
        PinkyFingerMetacarpal = 21,
        /// <summary>
        /// <para>Pinky finger phalanx proximal joint.</para>
        /// </summary>
        PinkyFingerPhalanxProximal = 22,
        /// <summary>
        /// <para>Pinky finger phalanx intermediate joint.</para>
        /// </summary>
        PinkyFingerPhalanxIntermediate = 23,
        /// <summary>
        /// <para>Pinky finger phalanx distal joint.</para>
        /// </summary>
        PinkyFingerPhalanxDistal = 24,
        /// <summary>
        /// <para>Pinky finger tip joint.</para>
        /// </summary>
        PinkyFingerTip = 25,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.XRHandTracker.HandJoint"/> enum.</para>
        /// </summary>
        Max = 26
    }

    [System.Flags]
    public enum HandJointFlags : long
    {
        /// <summary>
        /// <para>The hand joint's orientation data is valid.</para>
        /// </summary>
        OrientationValid = 1,
        /// <summary>
        /// <para>The hand joint's orientation is actively tracked. May not be set if tracking has been temporarily lost.</para>
        /// </summary>
        OrientationTracked = 2,
        /// <summary>
        /// <para>The hand joint's position data is valid.</para>
        /// </summary>
        PositionValid = 4,
        /// <summary>
        /// <para>The hand joint's position is actively tracked. May not be set if tracking has been temporarily lost.</para>
        /// </summary>
        PositionTracked = 8,
        /// <summary>
        /// <para>The hand joint's linear velocity data is valid.</para>
        /// </summary>
        LinearVelocityValid = 16,
        /// <summary>
        /// <para>The hand joint's angular velocity data is valid.</para>
        /// </summary>
        AngularVelocityValid = 32
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the hand tracking data is valid.</para>
    /// </summary>
    public bool HasTrackingData
    {
        get
        {
            return GetHasTrackingData();
        }
        set
        {
            SetHasTrackingData(value);
        }
    }

    /// <summary>
    /// <para>The source of the hand tracking data.</para>
    /// </summary>
    public XRHandTracker.HandTrackingSourceEnum HandTrackingSource
    {
        get
        {
            return GetHandTrackingSource();
        }
        set
        {
            SetHandTrackingSource(value);
        }
    }

    private static readonly System.Type CachedType = typeof(XRHandTracker);

    private static readonly StringName NativeName = "XRHandTracker";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public XRHandTracker() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal XRHandTracker(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal XRHandTracker(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetHasTrackingData, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetHasTrackingData(bool hasData)
    {
        NativeCalls.godot_icall_1_14(MethodBind0, GodotObject.GetPtr(this), hasData.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetHasTrackingData, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetHasTrackingData()
    {
        return NativeCalls.godot_icall_0_15(MethodBind1, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetHandTrackingSource, 2958308861ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetHandTrackingSource(XRHandTracker.HandTrackingSourceEnum source)
    {
        NativeCalls.godot_icall_1_38(MethodBind2, GodotObject.GetPtr(this), (int)source);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetHandTrackingSource, 2475045250ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public XRHandTracker.HandTrackingSourceEnum GetHandTrackingSource()
    {
        return (XRHandTracker.HandTrackingSourceEnum)NativeCalls.godot_icall_0_39(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetHandJointFlags, 3028437365ul);

    /// <summary>
    /// <para>Sets flags about the validity of the tracking data for the given hand joint.</para>
    /// </summary>
    public void SetHandJointFlags(XRHandTracker.HandJoint joint, XRHandTracker.HandJointFlags flags)
    {
        NativeCalls.godot_icall_2_59(MethodBind4, GodotObject.GetPtr(this), (int)joint, (int)flags);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetHandJointFlags, 1730972401ul);

    /// <summary>
    /// <para>Returns flags about the validity of the tracking data for the given hand joint.</para>
    /// </summary>
    public XRHandTracker.HandJointFlags GetHandJointFlags(XRHandTracker.HandJoint joint)
    {
        return (XRHandTracker.HandJointFlags)NativeCalls.godot_icall_1_60(MethodBind5, GodotObject.GetPtr(this), (int)joint);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetHandJointTransform, 2529959613ul);

    /// <summary>
    /// <para>Sets the transform for the given hand joint.</para>
    /// </summary>
    public unsafe void SetHandJointTransform(XRHandTracker.HandJoint joint, Transform3D transform)
    {
        NativeCalls.godot_icall_2_800(MethodBind6, GodotObject.GetPtr(this), (int)joint, &transform);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetHandJointTransform, 1090840196ul);

    /// <summary>
    /// <para>Returns the transform for the given hand joint.</para>
    /// </summary>
    public Transform3D GetHandJointTransform(XRHandTracker.HandJoint joint)
    {
        return NativeCalls.godot_icall_1_803(MethodBind7, GodotObject.GetPtr(this), (int)joint);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetHandJointRadius, 2723659615ul);

    /// <summary>
    /// <para>Sets the radius of the given hand joint.</para>
    /// </summary>
    public void SetHandJointRadius(XRHandTracker.HandJoint joint, float radius)
    {
        NativeCalls.godot_icall_2_69(MethodBind8, GodotObject.GetPtr(this), (int)joint, radius);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetHandJointRadius, 3400025734ul);

    /// <summary>
    /// <para>Returns the radius of the given hand joint.</para>
    /// </summary>
    public float GetHandJointRadius(XRHandTracker.HandJoint joint)
    {
        return NativeCalls.godot_icall_1_72(MethodBind9, GodotObject.GetPtr(this), (int)joint);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetHandJointLinearVelocity, 1978646737ul);

    /// <summary>
    /// <para>Sets the linear velocity for the given hand joint.</para>
    /// </summary>
    public unsafe void SetHandJointLinearVelocity(XRHandTracker.HandJoint joint, Vector3 linearVelocity)
    {
        NativeCalls.godot_icall_2_362(MethodBind10, GodotObject.GetPtr(this), (int)joint, &linearVelocity);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetHandJointLinearVelocity, 547240792ul);

    /// <summary>
    /// <para>Returns the linear velocity for the given hand joint.</para>
    /// </summary>
    public Vector3 GetHandJointLinearVelocity(XRHandTracker.HandJoint joint)
    {
        return NativeCalls.godot_icall_1_363(MethodBind11, GodotObject.GetPtr(this), (int)joint);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetHandJointAngularVelocity, 1978646737ul);

    /// <summary>
    /// <para>Sets the angular velocity for the given hand joint.</para>
    /// </summary>
    public unsafe void SetHandJointAngularVelocity(XRHandTracker.HandJoint joint, Vector3 angularVelocity)
    {
        NativeCalls.godot_icall_2_362(MethodBind12, GodotObject.GetPtr(this), (int)joint, &angularVelocity);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetHandJointAngularVelocity, 547240792ul);

    /// <summary>
    /// <para>Returns the angular velocity for the given hand joint.</para>
    /// </summary>
    public Vector3 GetHandJointAngularVelocity(XRHandTracker.HandJoint joint)
    {
        return NativeCalls.godot_icall_1_363(MethodBind13, GodotObject.GetPtr(this), (int)joint);
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
    public new class PropertyName : XRPositionalTracker.PropertyName
    {
        /// <summary>
        /// Cached name for the 'has_tracking_data' property.
        /// </summary>
        public static readonly StringName HasTrackingData = "has_tracking_data";
        /// <summary>
        /// Cached name for the 'hand_tracking_source' property.
        /// </summary>
        public static readonly StringName HandTrackingSource = "hand_tracking_source";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : XRPositionalTracker.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_has_tracking_data' method.
        /// </summary>
        public static readonly StringName SetHasTrackingData = "set_has_tracking_data";
        /// <summary>
        /// Cached name for the 'get_has_tracking_data' method.
        /// </summary>
        public static readonly StringName GetHasTrackingData = "get_has_tracking_data";
        /// <summary>
        /// Cached name for the 'set_hand_tracking_source' method.
        /// </summary>
        public static readonly StringName SetHandTrackingSource = "set_hand_tracking_source";
        /// <summary>
        /// Cached name for the 'get_hand_tracking_source' method.
        /// </summary>
        public static readonly StringName GetHandTrackingSource = "get_hand_tracking_source";
        /// <summary>
        /// Cached name for the 'set_hand_joint_flags' method.
        /// </summary>
        public static readonly StringName SetHandJointFlags = "set_hand_joint_flags";
        /// <summary>
        /// Cached name for the 'get_hand_joint_flags' method.
        /// </summary>
        public static readonly StringName GetHandJointFlags = "get_hand_joint_flags";
        /// <summary>
        /// Cached name for the 'set_hand_joint_transform' method.
        /// </summary>
        public static readonly StringName SetHandJointTransform = "set_hand_joint_transform";
        /// <summary>
        /// Cached name for the 'get_hand_joint_transform' method.
        /// </summary>
        public static readonly StringName GetHandJointTransform = "get_hand_joint_transform";
        /// <summary>
        /// Cached name for the 'set_hand_joint_radius' method.
        /// </summary>
        public static readonly StringName SetHandJointRadius = "set_hand_joint_radius";
        /// <summary>
        /// Cached name for the 'get_hand_joint_radius' method.
        /// </summary>
        public static readonly StringName GetHandJointRadius = "get_hand_joint_radius";
        /// <summary>
        /// Cached name for the 'set_hand_joint_linear_velocity' method.
        /// </summary>
        public static readonly StringName SetHandJointLinearVelocity = "set_hand_joint_linear_velocity";
        /// <summary>
        /// Cached name for the 'get_hand_joint_linear_velocity' method.
        /// </summary>
        public static readonly StringName GetHandJointLinearVelocity = "get_hand_joint_linear_velocity";
        /// <summary>
        /// Cached name for the 'set_hand_joint_angular_velocity' method.
        /// </summary>
        public static readonly StringName SetHandJointAngularVelocity = "set_hand_joint_angular_velocity";
        /// <summary>
        /// Cached name for the 'get_hand_joint_angular_velocity' method.
        /// </summary>
        public static readonly StringName GetHandJointAngularVelocity = "get_hand_joint_angular_velocity";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : XRPositionalTracker.SignalName
    {
    }
}
