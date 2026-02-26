namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A body tracking system will create an instance of this object and add it to the <see cref="Godot.XRServer"/>. This tracking system will then obtain skeleton data, convert it to the Godot Humanoid skeleton and store this data on the <see cref="Godot.XRBodyTracker"/> object.</para>
/// <para>Use <see cref="Godot.XRBodyModifier3D"/> to animate a body mesh using body tracking data.</para>
/// </summary>
public partial class XRBodyTracker : XRPositionalTracker
{
    [System.Flags]
    public enum BodyFlagsEnum : long
    {
        /// <summary>
        /// <para>Upper body tracking supported.</para>
        /// </summary>
        UpperBodySupported = 1,
        /// <summary>
        /// <para>Lower body tracking supported.</para>
        /// </summary>
        LowerBodySupported = 2,
        /// <summary>
        /// <para>Hand tracking supported.</para>
        /// </summary>
        HandsSupported = 4
    }

    public enum Joint : long
    {
        /// <summary>
        /// <para>Root joint.</para>
        /// </summary>
        Root = 0,
        /// <summary>
        /// <para>Hips joint.</para>
        /// </summary>
        Hips = 1,
        /// <summary>
        /// <para>Spine joint.</para>
        /// </summary>
        Spine = 2,
        /// <summary>
        /// <para>Chest joint.</para>
        /// </summary>
        Chest = 3,
        /// <summary>
        /// <para>Upper chest joint.</para>
        /// </summary>
        UpperChest = 4,
        /// <summary>
        /// <para>Neck joint.</para>
        /// </summary>
        Neck = 5,
        /// <summary>
        /// <para>Head joint.</para>
        /// </summary>
        Head = 6,
        /// <summary>
        /// <para>Head tip joint.</para>
        /// </summary>
        HeadTip = 7,
        /// <summary>
        /// <para>Left shoulder joint.</para>
        /// </summary>
        LeftShoulder = 8,
        /// <summary>
        /// <para>Left upper arm joint.</para>
        /// </summary>
        LeftUpperArm = 9,
        /// <summary>
        /// <para>Left lower arm joint.</para>
        /// </summary>
        LeftLowerArm = 10,
        /// <summary>
        /// <para>Right shoulder joint.</para>
        /// </summary>
        RightShoulder = 11,
        /// <summary>
        /// <para>Right upper arm joint.</para>
        /// </summary>
        RightUpperArm = 12,
        /// <summary>
        /// <para>Right lower arm joint.</para>
        /// </summary>
        RightLowerArm = 13,
        /// <summary>
        /// <para>Left upper leg joint.</para>
        /// </summary>
        LeftUpperLeg = 14,
        /// <summary>
        /// <para>Left lower leg joint.</para>
        /// </summary>
        LeftLowerLeg = 15,
        /// <summary>
        /// <para>Left foot joint.</para>
        /// </summary>
        LeftFoot = 16,
        /// <summary>
        /// <para>Left toes joint.</para>
        /// </summary>
        LeftToes = 17,
        /// <summary>
        /// <para>Right upper leg joint.</para>
        /// </summary>
        RightUpperLeg = 18,
        /// <summary>
        /// <para>Right lower leg joint.</para>
        /// </summary>
        RightLowerLeg = 19,
        /// <summary>
        /// <para>Right foot joint.</para>
        /// </summary>
        RightFoot = 20,
        /// <summary>
        /// <para>Right toes joint.</para>
        /// </summary>
        RightToes = 21,
        /// <summary>
        /// <para>Left hand joint.</para>
        /// </summary>
        LeftHand = 22,
        /// <summary>
        /// <para>Left palm joint.</para>
        /// </summary>
        LeftPalm = 23,
        /// <summary>
        /// <para>Left wrist joint.</para>
        /// </summary>
        LeftWrist = 24,
        /// <summary>
        /// <para>Left thumb metacarpal joint.</para>
        /// </summary>
        LeftThumbMetacarpal = 25,
        /// <summary>
        /// <para>Left thumb phalanx proximal joint.</para>
        /// </summary>
        LeftThumbPhalanxProximal = 26,
        /// <summary>
        /// <para>Left thumb phalanx distal joint.</para>
        /// </summary>
        LeftThumbPhalanxDistal = 27,
        /// <summary>
        /// <para>Left thumb tip joint.</para>
        /// </summary>
        LeftThumbTip = 28,
        /// <summary>
        /// <para>Left index finger metacarpal joint.</para>
        /// </summary>
        LeftIndexFingerMetacarpal = 29,
        /// <summary>
        /// <para>Left index finger phalanx proximal joint.</para>
        /// </summary>
        LeftIndexFingerPhalanxProximal = 30,
        /// <summary>
        /// <para>Left index finger phalanx intermediate joint.</para>
        /// </summary>
        LeftIndexFingerPhalanxIntermediate = 31,
        /// <summary>
        /// <para>Left index finger phalanx distal joint.</para>
        /// </summary>
        LeftIndexFingerPhalanxDistal = 32,
        /// <summary>
        /// <para>Left index finger tip joint.</para>
        /// </summary>
        LeftIndexFingerTip = 33,
        /// <summary>
        /// <para>Left middle finger metacarpal joint.</para>
        /// </summary>
        LeftMiddleFingerMetacarpal = 34,
        /// <summary>
        /// <para>Left middle finger phalanx proximal joint.</para>
        /// </summary>
        LeftMiddleFingerPhalanxProximal = 35,
        /// <summary>
        /// <para>Left middle finger phalanx intermediate joint.</para>
        /// </summary>
        LeftMiddleFingerPhalanxIntermediate = 36,
        /// <summary>
        /// <para>Left middle finger phalanx distal joint.</para>
        /// </summary>
        LeftMiddleFingerPhalanxDistal = 37,
        /// <summary>
        /// <para>Left middle finger tip joint.</para>
        /// </summary>
        LeftMiddleFingerTip = 38,
        /// <summary>
        /// <para>Left ring finger metacarpal joint.</para>
        /// </summary>
        LeftRingFingerMetacarpal = 39,
        /// <summary>
        /// <para>Left ring finger phalanx proximal joint.</para>
        /// </summary>
        LeftRingFingerPhalanxProximal = 40,
        /// <summary>
        /// <para>Left ring finger phalanx intermediate joint.</para>
        /// </summary>
        LeftRingFingerPhalanxIntermediate = 41,
        /// <summary>
        /// <para>Left ring finger phalanx distal joint.</para>
        /// </summary>
        LeftRingFingerPhalanxDistal = 42,
        /// <summary>
        /// <para>Left ring finger tip joint.</para>
        /// </summary>
        LeftRingFingerTip = 43,
        /// <summary>
        /// <para>Left pinky finger metacarpal joint.</para>
        /// </summary>
        LeftPinkyFingerMetacarpal = 44,
        /// <summary>
        /// <para>Left pinky finger phalanx proximal joint.</para>
        /// </summary>
        LeftPinkyFingerPhalanxProximal = 45,
        /// <summary>
        /// <para>Left pinky finger phalanx intermediate joint.</para>
        /// </summary>
        LeftPinkyFingerPhalanxIntermediate = 46,
        /// <summary>
        /// <para>Left pinky finger phalanx distal joint.</para>
        /// </summary>
        LeftPinkyFingerPhalanxDistal = 47,
        /// <summary>
        /// <para>Left pinky finger tip joint.</para>
        /// </summary>
        LeftPinkyFingerTip = 48,
        /// <summary>
        /// <para>Right hand joint.</para>
        /// </summary>
        RightHand = 49,
        /// <summary>
        /// <para>Right palm joint.</para>
        /// </summary>
        RightPalm = 50,
        /// <summary>
        /// <para>Right wrist joint.</para>
        /// </summary>
        RightWrist = 51,
        /// <summary>
        /// <para>Right thumb metacarpal joint.</para>
        /// </summary>
        RightThumbMetacarpal = 52,
        /// <summary>
        /// <para>Right thumb phalanx proximal joint.</para>
        /// </summary>
        RightThumbPhalanxProximal = 53,
        /// <summary>
        /// <para>Right thumb phalanx distal joint.</para>
        /// </summary>
        RightThumbPhalanxDistal = 54,
        /// <summary>
        /// <para>Right thumb tip joint.</para>
        /// </summary>
        RightThumbTip = 55,
        /// <summary>
        /// <para>Right index finger metacarpal joint.</para>
        /// </summary>
        RightIndexFingerMetacarpal = 56,
        /// <summary>
        /// <para>Right index finger phalanx proximal joint.</para>
        /// </summary>
        RightIndexFingerPhalanxProximal = 57,
        /// <summary>
        /// <para>Right index finger phalanx intermediate joint.</para>
        /// </summary>
        RightIndexFingerPhalanxIntermediate = 58,
        /// <summary>
        /// <para>Right index finger phalanx distal joint.</para>
        /// </summary>
        RightIndexFingerPhalanxDistal = 59,
        /// <summary>
        /// <para>Right index finger tip joint.</para>
        /// </summary>
        RightIndexFingerTip = 60,
        /// <summary>
        /// <para>Right middle finger metacarpal joint.</para>
        /// </summary>
        RightMiddleFingerMetacarpal = 61,
        /// <summary>
        /// <para>Right middle finger phalanx proximal joint.</para>
        /// </summary>
        RightMiddleFingerPhalanxProximal = 62,
        /// <summary>
        /// <para>Right middle finger phalanx intermediate joint.</para>
        /// </summary>
        RightMiddleFingerPhalanxIntermediate = 63,
        /// <summary>
        /// <para>Right middle finger phalanx distal joint.</para>
        /// </summary>
        RightMiddleFingerPhalanxDistal = 64,
        /// <summary>
        /// <para>Right middle finger tip joint.</para>
        /// </summary>
        RightMiddleFingerTip = 65,
        /// <summary>
        /// <para>Right ring finger metacarpal joint.</para>
        /// </summary>
        RightRingFingerMetacarpal = 66,
        /// <summary>
        /// <para>Right ring finger phalanx proximal joint.</para>
        /// </summary>
        RightRingFingerPhalanxProximal = 67,
        /// <summary>
        /// <para>Right ring finger phalanx intermediate joint.</para>
        /// </summary>
        RightRingFingerPhalanxIntermediate = 68,
        /// <summary>
        /// <para>Right ring finger phalanx distal joint.</para>
        /// </summary>
        RightRingFingerPhalanxDistal = 69,
        /// <summary>
        /// <para>Right ring finger tip joint.</para>
        /// </summary>
        RightRingFingerTip = 70,
        /// <summary>
        /// <para>Right pinky finger metacarpal joint.</para>
        /// </summary>
        RightPinkyFingerMetacarpal = 71,
        /// <summary>
        /// <para>Right pinky finger phalanx proximal joint.</para>
        /// </summary>
        RightPinkyFingerPhalanxProximal = 72,
        /// <summary>
        /// <para>Right pinky finger phalanx intermediate joint.</para>
        /// </summary>
        RightPinkyFingerPhalanxIntermediate = 73,
        /// <summary>
        /// <para>Right pinky finger phalanx distal joint.</para>
        /// </summary>
        RightPinkyFingerPhalanxDistal = 74,
        /// <summary>
        /// <para>Right pinky finger tip joint.</para>
        /// </summary>
        RightPinkyFingerTip = 75,
        /// <summary>
        /// <para>Lower chest joint.</para>
        /// </summary>
        LowerChest = 76,
        /// <summary>
        /// <para>Left scapula joint.</para>
        /// </summary>
        LeftScapula = 77,
        /// <summary>
        /// <para>Left wrist twist joint.</para>
        /// </summary>
        LeftWristTwist = 78,
        /// <summary>
        /// <para>Right scapula joint.</para>
        /// </summary>
        RightScapula = 79,
        /// <summary>
        /// <para>Right wrist twist joint.</para>
        /// </summary>
        RightWristTwist = 80,
        /// <summary>
        /// <para>Left foot twist joint.</para>
        /// </summary>
        LeftFootTwist = 81,
        /// <summary>
        /// <para>Left heel joint.</para>
        /// </summary>
        LeftHeel = 82,
        /// <summary>
        /// <para>Left middle foot joint.</para>
        /// </summary>
        LeftMiddleFoot = 83,
        /// <summary>
        /// <para>Right foot twist joint.</para>
        /// </summary>
        RightFootTwist = 84,
        /// <summary>
        /// <para>Right heel joint.</para>
        /// </summary>
        RightHeel = 85,
        /// <summary>
        /// <para>Right middle foot joint.</para>
        /// </summary>
        RightMiddleFoot = 86,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.XRBodyTracker.Joint"/> enum.</para>
        /// </summary>
        Max = 87
    }

    [System.Flags]
    public enum JointFlags : long
    {
        /// <summary>
        /// <para>The joint's orientation data is valid.</para>
        /// </summary>
        OrientationValid = 1,
        /// <summary>
        /// <para>The joint's orientation is actively tracked. May not be set if tracking has been temporarily lost.</para>
        /// </summary>
        OrientationTracked = 2,
        /// <summary>
        /// <para>The joint's position data is valid.</para>
        /// </summary>
        PositionValid = 4,
        /// <summary>
        /// <para>The joint's position is actively tracked. May not be set if tracking has been temporarily lost.</para>
        /// </summary>
        PositionTracked = 8
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the body tracking data is valid.</para>
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
    /// <para>The type of body tracking data captured.</para>
    /// </summary>
    public XRBodyTracker.BodyFlagsEnum BodyFlags
    {
        get
        {
            return GetBodyFlags();
        }
        set
        {
            SetBodyFlags(value);
        }
    }

    private static readonly System.Type CachedType = typeof(XRBodyTracker);

    private static readonly StringName NativeName = "XRBodyTracker";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public XRBodyTracker() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal XRBodyTracker(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal XRBodyTracker(bool memoryOwn) : base(memoryOwn) { }

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
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBodyFlags, 2103235750ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetBodyFlags(XRBodyTracker.BodyFlagsEnum flags)
    {
        NativeCalls.godot_icall_1_38(MethodBind2, GodotObject.GetPtr(this), (int)flags);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBodyFlags, 3543166366ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public XRBodyTracker.BodyFlagsEnum GetBodyFlags()
    {
        return (XRBodyTracker.BodyFlagsEnum)NativeCalls.godot_icall_0_39(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetJointFlags, 592144999ul);

    /// <summary>
    /// <para>Sets flags about the validity of the tracking data for the given body joint.</para>
    /// </summary>
    public void SetJointFlags(XRBodyTracker.Joint joint, XRBodyTracker.JointFlags flags)
    {
        NativeCalls.godot_icall_2_59(MethodBind4, GodotObject.GetPtr(this), (int)joint, (int)flags);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetJointFlags, 1030162609ul);

    /// <summary>
    /// <para>Returns flags about the validity of the tracking data for the given body joint.</para>
    /// </summary>
    public XRBodyTracker.JointFlags GetJointFlags(XRBodyTracker.Joint joint)
    {
        return (XRBodyTracker.JointFlags)NativeCalls.godot_icall_1_60(MethodBind5, GodotObject.GetPtr(this), (int)joint);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetJointTransform, 2635424328ul);

    /// <summary>
    /// <para>Sets the transform for the given body joint.</para>
    /// </summary>
    public unsafe void SetJointTransform(XRBodyTracker.Joint joint, Transform3D transform)
    {
        NativeCalls.godot_icall_2_800(MethodBind6, GodotObject.GetPtr(this), (int)joint, &transform);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetJointTransform, 3474811534ul);

    /// <summary>
    /// <para>Returns the transform for the given body joint.</para>
    /// </summary>
    public Transform3D GetJointTransform(XRBodyTracker.Joint joint)
    {
        return NativeCalls.godot_icall_1_803(MethodBind7, GodotObject.GetPtr(this), (int)joint);
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
        /// Cached name for the 'body_flags' property.
        /// </summary>
        public static readonly StringName BodyFlags = "body_flags";
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
        /// Cached name for the 'set_body_flags' method.
        /// </summary>
        public static readonly StringName SetBodyFlags = "set_body_flags";
        /// <summary>
        /// Cached name for the 'get_body_flags' method.
        /// </summary>
        public static readonly StringName GetBodyFlags = "get_body_flags";
        /// <summary>
        /// Cached name for the 'set_joint_flags' method.
        /// </summary>
        public static readonly StringName SetJointFlags = "set_joint_flags";
        /// <summary>
        /// Cached name for the 'get_joint_flags' method.
        /// </summary>
        public static readonly StringName GetJointFlags = "get_joint_flags";
        /// <summary>
        /// Cached name for the 'set_joint_transform' method.
        /// </summary>
        public static readonly StringName SetJointTransform = "set_joint_transform";
        /// <summary>
        /// Cached name for the 'get_joint_transform' method.
        /// </summary>
        public static readonly StringName GetJointTransform = "get_joint_transform";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : XRPositionalTracker.SignalName
    {
    }
}
