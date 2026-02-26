namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>The OpenXR interface allows Godot to interact with OpenXR runtimes and make it possible to create XR experiences and games.</para>
/// <para>Due to the needs of OpenXR this interface works slightly different than other plugin based XR interfaces. It needs to be initialized when Godot starts. You need to enable OpenXR, settings for this can be found in your games project settings under the XR heading. You do need to mark a viewport for use with XR in order for Godot to know which render result should be output to the headset.</para>
/// </summary>
public partial class OpenXRInterface : XRInterface
{
    public enum SessionState : long
    {
        /// <summary>
        /// <para>The state of the session is unknown, we haven't tried setting up OpenXR yet.</para>
        /// </summary>
        Unknown = 0,
        /// <summary>
        /// <para>The initial state after the OpenXR session is created or after the session is destroyed.</para>
        /// </summary>
        Idle = 1,
        /// <summary>
        /// <para>OpenXR is ready to begin our session. <see cref="Godot.OpenXRInterface.SessionBegun"/> is emitted when we change to this state.</para>
        /// </summary>
        Ready = 2,
        /// <summary>
        /// <para>The application has synched its frame loop with the runtime but we're not rendering anything. <see cref="Godot.OpenXRInterface.SessionSynchronized"/> is emitted when we change to this state.</para>
        /// </summary>
        Synchronized = 3,
        /// <summary>
        /// <para>The application has synched its frame loop with the runtime and we're rendering output to the user, however we receive no user input. <see cref="Godot.OpenXRInterface.SessionVisible"/> is emitted when we change to this state.</para>
        /// <para><b>Note:</b> This is the current state just before we get the focused state, whenever the user opens a system menu, switches to another application, or takes off their headset.</para>
        /// </summary>
        Visible = 4,
        /// <summary>
        /// <para>The application has synched its frame loop with the runtime, we're rendering output to the user and we're receiving XR input. <see cref="Godot.OpenXRInterface.SessionFocussed"/> is emitted when we change to this state.</para>
        /// <para><b>Note:</b> This is the state OpenXR will be in when the user can fully interact with your game.</para>
        /// </summary>
        Focused = 5,
        /// <summary>
        /// <para>Our session is being stopped. <see cref="Godot.OpenXRInterface.SessionStopping"/> is emitted when we change to this state.</para>
        /// </summary>
        Stopping = 6,
        /// <summary>
        /// <para>The session is about to be lost. <see cref="Godot.OpenXRInterface.SessionLossPending"/> is emitted when we change to this state.</para>
        /// </summary>
        LossPending = 7,
        /// <summary>
        /// <para>The OpenXR instance is about to be destroyed and we're exiting. <see cref="Godot.OpenXRInterface.InstanceExiting"/> is emitted when we change to this state.</para>
        /// </summary>
        Exiting = 8
    }

    public enum Hand : long
    {
        /// <summary>
        /// <para>Left hand.</para>
        /// </summary>
        Left = 0,
        /// <summary>
        /// <para>Right hand.</para>
        /// </summary>
        Right = 1,
        /// <summary>
        /// <para>Maximum value for the hand enum.</para>
        /// </summary>
        Max = 2
    }

    public enum HandMotionRange : long
    {
        /// <summary>
        /// <para>Full hand range, if user closes their hands, we make a full fist.</para>
        /// </summary>
        Unobstructed = 0,
        /// <summary>
        /// <para>Conform to controller, if user closes their hands, the tracked data conforms to the shape of the controller.</para>
        /// </summary>
        ConformToController = 1,
        /// <summary>
        /// <para>Maximum value for the motion range enum.</para>
        /// </summary>
        Max = 2
    }

    public enum HandTrackedSource : long
    {
        /// <summary>
        /// <para>The source of hand tracking data is unknown (the extension is likely unsupported).</para>
        /// </summary>
        Unknown = 0,
        /// <summary>
        /// <para>The source of hand tracking is unobstructed, this means that an accurate method of hand tracking is used, e.g. optical hand tracking, data gloves, etc.</para>
        /// </summary>
        Unobstructed = 1,
        /// <summary>
        /// <para>The source of hand tracking is a controller, bone positions are inferred from controller inputs.</para>
        /// </summary>
        Controller = 2,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.OpenXRInterface.HandTrackedSource"/> enum.</para>
        /// </summary>
        Max = 3
    }

    public enum HandJoints : long
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
        /// <para>Thumb proximal joint.</para>
        /// </summary>
        ThumbProximal = 3,
        /// <summary>
        /// <para>Thumb distal joint.</para>
        /// </summary>
        ThumbDistal = 4,
        /// <summary>
        /// <para>Thumb tip joint.</para>
        /// </summary>
        ThumbTip = 5,
        /// <summary>
        /// <para>Index finger metacarpal joint.</para>
        /// </summary>
        IndexMetacarpal = 6,
        /// <summary>
        /// <para>Index finger phalanx proximal joint.</para>
        /// </summary>
        IndexProximal = 7,
        /// <summary>
        /// <para>Index finger phalanx intermediate joint.</para>
        /// </summary>
        IndexIntermediate = 8,
        /// <summary>
        /// <para>Index finger phalanx distal joint.</para>
        /// </summary>
        IndexDistal = 9,
        /// <summary>
        /// <para>Index finger tip joint.</para>
        /// </summary>
        IndexTip = 10,
        /// <summary>
        /// <para>Middle finger metacarpal joint.</para>
        /// </summary>
        MiddleMetacarpal = 11,
        /// <summary>
        /// <para>Middle finger phalanx proximal joint.</para>
        /// </summary>
        MiddleProximal = 12,
        /// <summary>
        /// <para>Middle finger phalanx intermediate joint.</para>
        /// </summary>
        MiddleIntermediate = 13,
        /// <summary>
        /// <para>Middle finger phalanx distal joint.</para>
        /// </summary>
        MiddleDistal = 14,
        /// <summary>
        /// <para>Middle finger tip joint.</para>
        /// </summary>
        MiddleTip = 15,
        /// <summary>
        /// <para>Ring finger metacarpal joint.</para>
        /// </summary>
        RingMetacarpal = 16,
        /// <summary>
        /// <para>Ring finger phalanx proximal joint.</para>
        /// </summary>
        RingProximal = 17,
        /// <summary>
        /// <para>Ring finger phalanx intermediate joint.</para>
        /// </summary>
        RingIntermediate = 18,
        /// <summary>
        /// <para>Ring finger phalanx distal joint.</para>
        /// </summary>
        RingDistal = 19,
        /// <summary>
        /// <para>Ring finger tip joint.</para>
        /// </summary>
        RingTip = 20,
        /// <summary>
        /// <para>Pinky finger metacarpal joint.</para>
        /// </summary>
        LittleMetacarpal = 21,
        /// <summary>
        /// <para>Pinky finger phalanx proximal joint.</para>
        /// </summary>
        LittleProximal = 22,
        /// <summary>
        /// <para>Pinky finger phalanx intermediate joint.</para>
        /// </summary>
        LittleIntermediate = 23,
        /// <summary>
        /// <para>Pinky finger phalanx distal joint.</para>
        /// </summary>
        LittleDistal = 24,
        /// <summary>
        /// <para>Pinky finger tip joint.</para>
        /// </summary>
        LittleTip = 25,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.OpenXRInterface.HandJoints"/> enum.</para>
        /// </summary>
        Max = 26
    }

    public enum PerfSettingsLevel : long
    {
        /// <summary>
        /// <para>The application has entered a non-XR section (head-locked / static screen), during which power savings are to be prioritized.</para>
        /// </summary>
        PowerSavings = 0,
        /// <summary>
        /// <para>The application has entered a low and stable complexity section, during which reducing power is more important than occasional late rendering frames.</para>
        /// </summary>
        SustainedLow = 1,
        /// <summary>
        /// <para>The application has entered a high or dynamic complexity section, during which the XR Runtime strives for consistent XR compositing and frame rendering within a thermally sustainable range.</para>
        /// </summary>
        SustainedHigh = 2,
        /// <summary>
        /// <para>The application has entered a section with very high complexity, during which the XR Runtime is allowed to step up beyond the thermally sustainable range.</para>
        /// </summary>
        Boost = 3
    }

    public enum PerfSettingsSubDomain : long
    {
        /// <summary>
        /// <para>The compositing performance within the runtime has reached a new level.</para>
        /// </summary>
        Compositing = 0,
        /// <summary>
        /// <para>The application rendering performance has reached a new level.</para>
        /// </summary>
        Rendering = 1,
        /// <summary>
        /// <para>The temperature of the device has reached a new level.</para>
        /// </summary>
        Thermal = 2
    }

    public enum PerfSettingsNotificationLevel : long
    {
        /// <summary>
        /// <para>The sub-domain has reached a level where no further actions other than currently applied are necessary.</para>
        /// </summary>
        Normal = 0,
        /// <summary>
        /// <para>The sub-domain has reached an early warning level where the application should start proactive mitigation actions.</para>
        /// </summary>
        Warning = 1,
        /// <summary>
        /// <para>The sub-domain has reached a critical level where the application should start drastic mitigation actions.</para>
        /// </summary>
        Impaired = 2
    }

    [System.Flags]
    public enum HandJointFlags : long
    {
        /// <summary>
        /// <para>No flags are set.</para>
        /// </summary>
        None = 0,
        /// <summary>
        /// <para>If set, the orientation data is valid, otherwise, the orientation data is unreliable and should not be used.</para>
        /// </summary>
        OrientationValid = 1,
        /// <summary>
        /// <para>If set, the orientation data comes from tracking data, otherwise, the orientation data contains predicted data.</para>
        /// </summary>
        OrientationTracked = 2,
        /// <summary>
        /// <para>If set, the positional data is valid, otherwise, the positional data is unreliable and should not be used.</para>
        /// </summary>
        PositionValid = 4,
        /// <summary>
        /// <para>If set, the positional data comes from tracking data, otherwise, the positional data contains predicted data.</para>
        /// </summary>
        PositionTracked = 8,
        /// <summary>
        /// <para>If set, our linear velocity data is valid, otherwise, the linear velocity data is unreliable and should not be used.</para>
        /// </summary>
        LinearVelocityValid = 16,
        /// <summary>
        /// <para>If set, our angular velocity data is valid, otherwise, the angular velocity data is unreliable and should not be used.</para>
        /// </summary>
        AngularVelocityValid = 32
    }

    /// <summary>
    /// <para>The display refresh rate for the current HMD. Only functional if this feature is supported by the OpenXR runtime and after the interface has been initialized.</para>
    /// </summary>
    public float DisplayRefreshRate
    {
        get
        {
            return GetDisplayRefreshRate();
        }
        set
        {
            SetDisplayRefreshRate(value);
        }
    }

    /// <summary>
    /// <para>The render size multiplier for the current HMD. Must be set before the interface has been initialized.</para>
    /// </summary>
    public double RenderTargetSizeMultiplier
    {
        get
        {
            return GetRenderTargetSizeMultiplier();
        }
        set
        {
            SetRenderTargetSizeMultiplier(value);
        }
    }

    /// <summary>
    /// <para>The foveation level, from <c>0</c> (off) to <c>3</c> (high). The interface must be initialized before this is accessible.</para>
    /// <para><b>Note:</b> Only works on the Compatibility renderer.</para>
    /// </summary>
    public int FoveationLevel
    {
        get
        {
            return GetFoveationLevel();
        }
        set
        {
            SetFoveationLevel(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, enables dynamic foveation adjustment. The interface must be initialized before this is accessible. If enabled, foveation will automatically be adjusted between low and <see cref="Godot.OpenXRInterface.FoveationLevel"/>.</para>
    /// <para><b>Note:</b> Only works on the Compatibility renderer.</para>
    /// </summary>
    public bool FoveationDynamic
    {
        get
        {
            return GetFoveationDynamic();
        }
        set
        {
            SetFoveationDynamic(value);
        }
    }

    /// <summary>
    /// <para>The minimum radius around the focal point where full quality is guaranteed if VRS is used as a percentage of screen size.</para>
    /// <para><b>Note:</b> Mobile and Forward+ renderers only. Requires <see cref="Godot.Viewport.VrsMode"/> to be set to <see cref="Godot.Viewport.VrsModeEnum.XR"/>.</para>
    /// </summary>
    public float VrsMinRadius
    {
        get
        {
            return GetVrsMinRadius();
        }
        set
        {
            SetVrsMinRadius(value);
        }
    }

    /// <summary>
    /// <para>The strength used to calculate the VRS density map. The greater this value, the more noticeable VRS is. This improves performance at the cost of quality.</para>
    /// <para><b>Note:</b> Mobile and Forward+ renderers only. Requires <see cref="Godot.Viewport.VrsMode"/> to be set to <see cref="Godot.Viewport.VrsModeEnum.XR"/>.</para>
    /// </summary>
    public float VrsStrength
    {
        get
        {
            return GetVrsStrength();
        }
        set
        {
            SetVrsStrength(value);
        }
    }

    private static readonly System.Type CachedType = typeof(OpenXRInterface);

    private static readonly StringName NativeName = "OpenXRInterface";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public OpenXRInterface() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal OpenXRInterface(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal OpenXRInterface(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSessionState, 896364779ul);

    /// <summary>
    /// <para>Returns the current state of our OpenXR session.</para>
    /// </summary>
    public OpenXRInterface.SessionState GetSessionState()
    {
        return (OpenXRInterface.SessionState)NativeCalls.godot_icall_0_39(MethodBind0, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDisplayRefreshRate, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetDisplayRefreshRate()
    {
        return NativeCalls.godot_icall_0_68(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDisplayRefreshRate, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDisplayRefreshRate(float refreshRate)
    {
        NativeCalls.godot_icall_1_67(MethodBind2, GodotObject.GetPtr(this), refreshRate);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRenderTargetSizeMultiplier, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public double GetRenderTargetSizeMultiplier()
    {
        return NativeCalls.godot_icall_0_144(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRenderTargetSizeMultiplier, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetRenderTargetSizeMultiplier(double multiplier)
    {
        NativeCalls.godot_icall_1_127(MethodBind4, GodotObject.GetPtr(this), multiplier);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsFoveationSupported, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if OpenXR's foveation extension is supported. The interface must be initialized before this returns a valid value.</para>
    /// <para><b>Note:</b> When using the Vulkan rendering driver, <see cref="Godot.Viewport.VrsMode"/> must be set to <see cref="Godot.Viewport.VrsModeEnum.XR"/> to support foveation.</para>
    /// </summary>
    public bool IsFoveationSupported()
    {
        return NativeCalls.godot_icall_0_15(MethodBind5, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFoveationLevel, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetFoveationLevel()
    {
        return NativeCalls.godot_icall_0_39(MethodBind6, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFoveationLevel, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFoveationLevel(int foveationLevel)
    {
        NativeCalls.godot_icall_1_38(MethodBind7, GodotObject.GetPtr(this), foveationLevel);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFoveationDynamic, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetFoveationDynamic()
    {
        return NativeCalls.godot_icall_0_15(MethodBind8, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFoveationDynamic, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFoveationDynamic(bool foveationDynamic)
    {
        NativeCalls.godot_icall_1_14(MethodBind9, GodotObject.GetPtr(this), foveationDynamic.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsActionSetActive, 3927539163ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the given action set is active.</para>
    /// </summary>
    public bool IsActionSetActive(string name)
    {
        return NativeCalls.godot_icall_1_131(MethodBind10, GodotObject.GetPtr(this), name).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetActionSetActive, 2678287736ul);

    /// <summary>
    /// <para>Sets the given action set as active or inactive.</para>
    /// </summary>
    public void SetActionSetActive(string name, bool active)
    {
        NativeCalls.godot_icall_2_497(MethodBind11, GodotObject.GetPtr(this), name, active.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetActionSets, 3995934104ul);

    /// <summary>
    /// <para>Returns a list of action sets registered with Godot (loaded from the action map at runtime).</para>
    /// </summary>
    public Godot.Collections.Array GetActionSets()
    {
        return NativeCalls.godot_icall_0_120(MethodBind12, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAvailableDisplayRefreshRates, 3995934104ul);

    /// <summary>
    /// <para>Returns a list of display refresh rates supported by the current HMD. Only returned if this feature is supported by the OpenXR runtime and after the interface has been initialized.</para>
    /// </summary>
    public Godot.Collections.Array GetAvailableDisplayRefreshRates()
    {
        return NativeCalls.godot_icall_0_120(MethodBind13, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMotionRange, 855158159ul);

    /// <summary>
    /// <para>If handtracking is enabled and motion range is supported, sets the currently configured motion range for <paramref name="hand"/> to <paramref name="motionRange"/>.</para>
    /// </summary>
    public void SetMotionRange(OpenXRInterface.Hand hand, OpenXRInterface.HandMotionRange motionRange)
    {
        NativeCalls.godot_icall_2_59(MethodBind14, GodotObject.GetPtr(this), (int)hand, (int)motionRange);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMotionRange, 3955838114ul);

    /// <summary>
    /// <para>If handtracking is enabled and motion range is supported, gets the currently configured motion range for <paramref name="hand"/>.</para>
    /// </summary>
    public OpenXRInterface.HandMotionRange GetMotionRange(OpenXRInterface.Hand hand)
    {
        return (OpenXRInterface.HandMotionRange)NativeCalls.godot_icall_1_60(MethodBind15, GodotObject.GetPtr(this), (int)hand);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetHandTrackingSource, 4092421202ul);

    /// <summary>
    /// <para>If handtracking is enabled and hand tracking source is supported, gets the source of the hand tracking data for <paramref name="hand"/>.</para>
    /// </summary>
    [Obsolete("Use 'Godot.XRHandTracker.HandTrackingSource' obtained from 'Godot.XRServer.GetTracker(StringName)' instead.")]
    public OpenXRInterface.HandTrackedSource GetHandTrackingSource(OpenXRInterface.Hand hand)
    {
        return (OpenXRInterface.HandTrackedSource)NativeCalls.godot_icall_1_60(MethodBind16, GodotObject.GetPtr(this), (int)hand);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetHandJointFlags, 720567706ul);

    /// <summary>
    /// <para>If handtracking is enabled, returns flags that inform us of the validity of the tracking data.</para>
    /// </summary>
    [Obsolete("Use 'Godot.XRHandTracker.GetHandJointFlags(XRHandTracker.HandJoint)' obtained from 'Godot.XRServer.GetTracker(StringName)' instead.")]
    public OpenXRInterface.HandJointFlags GetHandJointFlags(OpenXRInterface.Hand hand, OpenXRInterface.HandJoints joint)
    {
        return (OpenXRInterface.HandJointFlags)NativeCalls.godot_icall_2_73(MethodBind17, GodotObject.GetPtr(this), (int)hand, (int)joint);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetHandJointRotation, 1974618321ul);

    /// <summary>
    /// <para>If handtracking is enabled, returns the rotation of a joint (<paramref name="joint"/>) of a hand (<paramref name="hand"/>) as provided by OpenXR.</para>
    /// </summary>
    [Obsolete("Use 'Godot.XRHandTracker.GetHandJointTransform(XRHandTracker.HandJoint)' obtained from 'Godot.XRServer.GetTracker(StringName)' instead.")]
    public Quaternion GetHandJointRotation(OpenXRInterface.Hand hand, OpenXRInterface.HandJoints joint)
    {
        return NativeCalls.godot_icall_2_769(MethodBind18, GodotObject.GetPtr(this), (int)hand, (int)joint);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetHandJointPosition, 3529194242ul);

    /// <summary>
    /// <para>If handtracking is enabled, returns the position of a joint (<paramref name="joint"/>) of a hand (<paramref name="hand"/>) as provided by OpenXR. This is relative to <see cref="Godot.XROrigin3D"/> without worldscale applied!</para>
    /// </summary>
    [Obsolete("Use 'Godot.XRHandTracker.GetHandJointTransform(XRHandTracker.HandJoint)' obtained from 'Godot.XRServer.GetTracker(StringName)' instead.")]
    public Vector3 GetHandJointPosition(OpenXRInterface.Hand hand, OpenXRInterface.HandJoints joint)
    {
        return NativeCalls.godot_icall_2_767(MethodBind19, GodotObject.GetPtr(this), (int)hand, (int)joint);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetHandJointRadius, 901522724ul);

    /// <summary>
    /// <para>If handtracking is enabled, returns the radius of a joint (<paramref name="joint"/>) of a hand (<paramref name="hand"/>) as provided by OpenXR. This is without worldscale applied!</para>
    /// </summary>
    [Obsolete("Use 'Godot.XRHandTracker.GetHandJointRadius(XRHandTracker.HandJoint)' obtained from 'Godot.XRServer.GetTracker(StringName)' instead.")]
    public float GetHandJointRadius(OpenXRInterface.Hand hand, OpenXRInterface.HandJoints joint)
    {
        return NativeCalls.godot_icall_2_88(MethodBind20, GodotObject.GetPtr(this), (int)hand, (int)joint);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetHandJointLinearVelocity, 3529194242ul);

    /// <summary>
    /// <para>If handtracking is enabled, returns the linear velocity of a joint (<paramref name="joint"/>) of a hand (<paramref name="hand"/>) as provided by OpenXR. This is relative to <see cref="Godot.XROrigin3D"/> without worldscale applied!</para>
    /// </summary>
    [Obsolete("Use 'Godot.XRHandTracker.GetHandJointLinearVelocity(XRHandTracker.HandJoint)' obtained from 'Godot.XRServer.GetTracker(StringName)' instead.")]
    public Vector3 GetHandJointLinearVelocity(OpenXRInterface.Hand hand, OpenXRInterface.HandJoints joint)
    {
        return NativeCalls.godot_icall_2_767(MethodBind21, GodotObject.GetPtr(this), (int)hand, (int)joint);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetHandJointAngularVelocity, 3529194242ul);

    /// <summary>
    /// <para>If handtracking is enabled, returns the angular velocity of a joint (<paramref name="joint"/>) of a hand (<paramref name="hand"/>) as provided by OpenXR. This is relative to <see cref="Godot.XROrigin3D"/>!</para>
    /// </summary>
    [Obsolete("Use 'Godot.XRHandTracker.GetHandJointAngularVelocity(XRHandTracker.HandJoint)' obtained from 'Godot.XRServer.GetTracker(StringName)' instead.")]
    public Vector3 GetHandJointAngularVelocity(OpenXRInterface.Hand hand, OpenXRInterface.HandJoints joint)
    {
        return NativeCalls.godot_icall_2_767(MethodBind22, GodotObject.GetPtr(this), (int)hand, (int)joint);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsHandTrackingSupported, 2240911060ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if OpenXR's hand tracking is supported and enabled.</para>
    /// <para><b>Note:</b> This only returns a valid value after OpenXR has been initialized.</para>
    /// </summary>
    public bool IsHandTrackingSupported()
    {
        return NativeCalls.godot_icall_0_15(MethodBind23, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsHandInteractionSupported, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if OpenXR's hand interaction profile is supported and enabled.</para>
    /// <para><b>Note:</b> This only returns a valid value after OpenXR has been initialized.</para>
    /// </summary>
    public bool IsHandInteractionSupported()
    {
        return NativeCalls.godot_icall_0_15(MethodBind24, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsEyeGazeInteractionSupported, 2240911060ul);

    /// <summary>
    /// <para>Returns the capabilities of the eye gaze interaction extension.</para>
    /// <para><b>Note:</b> This only returns a valid value after OpenXR has been initialized.</para>
    /// </summary>
    public bool IsEyeGazeInteractionSupported()
    {
        return NativeCalls.godot_icall_0_15(MethodBind25, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVrsMinRadius, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetVrsMinRadius()
    {
        return NativeCalls.godot_icall_0_68(MethodBind26, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVrsMinRadius, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetVrsMinRadius(float radius)
    {
        NativeCalls.godot_icall_1_67(MethodBind27, GodotObject.GetPtr(this), radius);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVrsStrength, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetVrsStrength()
    {
        return NativeCalls.godot_icall_0_68(MethodBind28, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVrsStrength, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetVrsStrength(float strength)
    {
        NativeCalls.godot_icall_1_67(MethodBind29, GodotObject.GetPtr(this), strength);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCpuLevel, 2940842095ul);

    /// <summary>
    /// <para>Sets the CPU performance level of the OpenXR device.</para>
    /// </summary>
    public void SetCpuLevel(OpenXRInterface.PerfSettingsLevel level)
    {
        NativeCalls.godot_icall_1_38(MethodBind30, GodotObject.GetPtr(this), (int)level);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetGpuLevel, 2940842095ul);

    /// <summary>
    /// <para>Sets the GPU performance level of the OpenXR device.</para>
    /// </summary>
    public void SetGpuLevel(OpenXRInterface.PerfSettingsLevel level)
    {
        NativeCalls.godot_icall_1_38(MethodBind31, GodotObject.GetPtr(this), (int)level);
    }

    /// <summary>
    /// <para>Informs our OpenXR session has been started.</para>
    /// </summary>
    public event Action SessionBegun
    {
        add => Connect(SignalName.SessionBegun, Callable.From(value));
        remove => Disconnect(SignalName.SessionBegun, Callable.From(value));
    }

    protected void EmitSignalSessionBegun()
    {
        EmitSignal(SignalName.SessionBegun);
    }

    /// <summary>
    /// <para>Informs our OpenXR session is stopping.</para>
    /// </summary>
    public event Action SessionStopping
    {
        add => Connect(SignalName.SessionStopping, Callable.From(value));
        remove => Disconnect(SignalName.SessionStopping, Callable.From(value));
    }

    protected void EmitSignalSessionStopping()
    {
        EmitSignal(SignalName.SessionStopping);
    }

    /// <summary>
    /// <para>Informs our OpenXR session has been synchronized.</para>
    /// </summary>
    public event Action SessionSynchronized
    {
        add => Connect(SignalName.SessionSynchronized, Callable.From(value));
        remove => Disconnect(SignalName.SessionSynchronized, Callable.From(value));
    }

    protected void EmitSignalSessionSynchronized()
    {
        EmitSignal(SignalName.SessionSynchronized);
    }

    /// <summary>
    /// <para>Informs our OpenXR session now has focus, for example output is sent to the HMD and we're receiving XR input.</para>
    /// </summary>
    public event Action SessionFocussed
    {
        add => Connect(SignalName.SessionFocussed, Callable.From(value));
        remove => Disconnect(SignalName.SessionFocussed, Callable.From(value));
    }

    protected void EmitSignalSessionFocussed()
    {
        EmitSignal(SignalName.SessionFocussed);
    }

    /// <summary>
    /// <para>Informs our OpenXR session is now visible, for example output is sent to the HMD but we don't receive XR input.</para>
    /// </summary>
    public event Action SessionVisible
    {
        add => Connect(SignalName.SessionVisible, Callable.From(value));
        remove => Disconnect(SignalName.SessionVisible, Callable.From(value));
    }

    protected void EmitSignalSessionVisible()
    {
        EmitSignal(SignalName.SessionVisible);
    }

    /// <summary>
    /// <para>Informs our OpenXR session is in the process of being lost.</para>
    /// </summary>
    public event Action SessionLossPending
    {
        add => Connect(SignalName.SessionLossPending, Callable.From(value));
        remove => Disconnect(SignalName.SessionLossPending, Callable.From(value));
    }

    protected void EmitSignalSessionLossPending()
    {
        EmitSignal(SignalName.SessionLossPending);
    }

    /// <summary>
    /// <para>Informs our OpenXR instance is exiting.</para>
    /// </summary>
    public event Action InstanceExiting
    {
        add => Connect(SignalName.InstanceExiting, Callable.From(value));
        remove => Disconnect(SignalName.InstanceExiting, Callable.From(value));
    }

    protected void EmitSignalInstanceExiting()
    {
        EmitSignal(SignalName.InstanceExiting);
    }

    /// <summary>
    /// <para>Informs the user queued a recenter of the player position.</para>
    /// </summary>
    public event Action PoseRecentered
    {
        add => Connect(SignalName.PoseRecentered, Callable.From(value));
        remove => Disconnect(SignalName.PoseRecentered, Callable.From(value));
    }

    protected void EmitSignalPoseRecentered()
    {
        EmitSignal(SignalName.PoseRecentered);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.OpenXRInterface.RefreshRateChanged"/> event of a <see cref="Godot.OpenXRInterface"/> class.
    /// </summary>
    public delegate void RefreshRateChangedEventHandler(double refreshRate);

    private static void RefreshRateChangedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((RefreshRateChangedEventHandler)delegateObj)(VariantUtils.ConvertTo<double>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Informs the user the HMD refresh rate has changed.</para>
    /// <para><b>Note:</b> Only emitted if XR runtime supports the refresh rate extension.</para>
    /// </summary>
    public unsafe event RefreshRateChangedEventHandler RefreshRateChanged
    {
        add => Connect(SignalName.RefreshRateChanged, Callable.CreateWithUnsafeTrampoline(value, &RefreshRateChangedTrampoline));
        remove => Disconnect(SignalName.RefreshRateChanged, Callable.CreateWithUnsafeTrampoline(value, &RefreshRateChangedTrampoline));
    }

    protected void EmitSignalRefreshRateChanged(double refreshRate)
    {
        EmitSignal(SignalName.RefreshRateChanged, refreshRate);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.OpenXRInterface.CpuLevelChanged"/> event of a <see cref="Godot.OpenXRInterface"/> class.
    /// </summary>
    public delegate void CpuLevelChangedEventHandler(long subDomain, long fromLevel, long toLevel);

    private static void CpuLevelChangedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 3);
        ((CpuLevelChangedEventHandler)delegateObj)(VariantUtils.ConvertTo<long>(args[0]), VariantUtils.ConvertTo<long>(args[1]), VariantUtils.ConvertTo<long>(args[2]));
        ret = default;
    }

    /// <summary>
    /// <para>Informs the device CPU performance level has changed in the specified subdomain.</para>
    /// </summary>
    public unsafe event CpuLevelChangedEventHandler CpuLevelChanged
    {
        add => Connect(SignalName.CpuLevelChanged, Callable.CreateWithUnsafeTrampoline(value, &CpuLevelChangedTrampoline));
        remove => Disconnect(SignalName.CpuLevelChanged, Callable.CreateWithUnsafeTrampoline(value, &CpuLevelChangedTrampoline));
    }

    protected void EmitSignalCpuLevelChanged(long subDomain, long fromLevel, long toLevel)
    {
        EmitSignal(SignalName.CpuLevelChanged, subDomain, fromLevel, toLevel);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.OpenXRInterface.GpuLevelChanged"/> event of a <see cref="Godot.OpenXRInterface"/> class.
    /// </summary>
    public delegate void GpuLevelChangedEventHandler(long subDomain, long fromLevel, long toLevel);

    private static void GpuLevelChangedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 3);
        ((GpuLevelChangedEventHandler)delegateObj)(VariantUtils.ConvertTo<long>(args[0]), VariantUtils.ConvertTo<long>(args[1]), VariantUtils.ConvertTo<long>(args[2]));
        ret = default;
    }

    /// <summary>
    /// <para>Informs the device GPU performance level has changed in the specified subdomain.</para>
    /// </summary>
    public unsafe event GpuLevelChangedEventHandler GpuLevelChanged
    {
        add => Connect(SignalName.GpuLevelChanged, Callable.CreateWithUnsafeTrampoline(value, &GpuLevelChangedTrampoline));
        remove => Disconnect(SignalName.GpuLevelChanged, Callable.CreateWithUnsafeTrampoline(value, &GpuLevelChangedTrampoline));
    }

    protected void EmitSignalGpuLevelChanged(long subDomain, long fromLevel, long toLevel)
    {
        EmitSignal(SignalName.GpuLevelChanged, subDomain, fromLevel, toLevel);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_session_begun = "SessionBegun";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_session_stopping = "SessionStopping";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_session_synchronized = "SessionSynchronized";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_session_focussed = "SessionFocussed";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_session_visible = "SessionVisible";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_session_loss_pending = "SessionLossPending";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_instance_exiting = "InstanceExiting";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_pose_recentered = "PoseRecentered";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_refresh_rate_changed = "RefreshRateChanged";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_cpu_level_changed = "CpuLevelChanged";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_gpu_level_changed = "GpuLevelChanged";

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
        if (signal == SignalName.SessionBegun)
        {
            if (HasGodotClassSignal(SignalProxyName_session_begun.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.SessionStopping)
        {
            if (HasGodotClassSignal(SignalProxyName_session_stopping.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.SessionSynchronized)
        {
            if (HasGodotClassSignal(SignalProxyName_session_synchronized.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.SessionFocussed)
        {
            if (HasGodotClassSignal(SignalProxyName_session_focussed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.SessionVisible)
        {
            if (HasGodotClassSignal(SignalProxyName_session_visible.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.SessionLossPending)
        {
            if (HasGodotClassSignal(SignalProxyName_session_loss_pending.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.InstanceExiting)
        {
            if (HasGodotClassSignal(SignalProxyName_instance_exiting.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.PoseRecentered)
        {
            if (HasGodotClassSignal(SignalProxyName_pose_recentered.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.RefreshRateChanged)
        {
            if (HasGodotClassSignal(SignalProxyName_refresh_rate_changed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.CpuLevelChanged)
        {
            if (HasGodotClassSignal(SignalProxyName_cpu_level_changed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.GpuLevelChanged)
        {
            if (HasGodotClassSignal(SignalProxyName_gpu_level_changed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        return base.HasGodotClassSignal(signal);
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : XRInterface.PropertyName
    {
        /// <summary>
        /// Cached name for the 'display_refresh_rate' property.
        /// </summary>
        public static readonly StringName DisplayRefreshRate = "display_refresh_rate";
        /// <summary>
        /// Cached name for the 'render_target_size_multiplier' property.
        /// </summary>
        public static readonly StringName RenderTargetSizeMultiplier = "render_target_size_multiplier";
        /// <summary>
        /// Cached name for the 'foveation_level' property.
        /// </summary>
        public static readonly StringName FoveationLevel = "foveation_level";
        /// <summary>
        /// Cached name for the 'foveation_dynamic' property.
        /// </summary>
        public static readonly StringName FoveationDynamic = "foveation_dynamic";
        /// <summary>
        /// Cached name for the 'vrs_min_radius' property.
        /// </summary>
        public static readonly StringName VrsMinRadius = "vrs_min_radius";
        /// <summary>
        /// Cached name for the 'vrs_strength' property.
        /// </summary>
        public static readonly StringName VrsStrength = "vrs_strength";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : XRInterface.MethodName
    {
        /// <summary>
        /// Cached name for the 'get_session_state' method.
        /// </summary>
        public static readonly StringName GetSessionState = "get_session_state";
        /// <summary>
        /// Cached name for the 'get_display_refresh_rate' method.
        /// </summary>
        public static readonly StringName GetDisplayRefreshRate = "get_display_refresh_rate";
        /// <summary>
        /// Cached name for the 'set_display_refresh_rate' method.
        /// </summary>
        public static readonly StringName SetDisplayRefreshRate = "set_display_refresh_rate";
        /// <summary>
        /// Cached name for the 'get_render_target_size_multiplier' method.
        /// </summary>
        public static readonly StringName GetRenderTargetSizeMultiplier = "get_render_target_size_multiplier";
        /// <summary>
        /// Cached name for the 'set_render_target_size_multiplier' method.
        /// </summary>
        public static readonly StringName SetRenderTargetSizeMultiplier = "set_render_target_size_multiplier";
        /// <summary>
        /// Cached name for the 'is_foveation_supported' method.
        /// </summary>
        public static readonly StringName IsFoveationSupported = "is_foveation_supported";
        /// <summary>
        /// Cached name for the 'get_foveation_level' method.
        /// </summary>
        public static readonly StringName GetFoveationLevel = "get_foveation_level";
        /// <summary>
        /// Cached name for the 'set_foveation_level' method.
        /// </summary>
        public static readonly StringName SetFoveationLevel = "set_foveation_level";
        /// <summary>
        /// Cached name for the 'get_foveation_dynamic' method.
        /// </summary>
        public static readonly StringName GetFoveationDynamic = "get_foveation_dynamic";
        /// <summary>
        /// Cached name for the 'set_foveation_dynamic' method.
        /// </summary>
        public static readonly StringName SetFoveationDynamic = "set_foveation_dynamic";
        /// <summary>
        /// Cached name for the 'is_action_set_active' method.
        /// </summary>
        public static readonly StringName IsActionSetActive = "is_action_set_active";
        /// <summary>
        /// Cached name for the 'set_action_set_active' method.
        /// </summary>
        public static readonly StringName SetActionSetActive = "set_action_set_active";
        /// <summary>
        /// Cached name for the 'get_action_sets' method.
        /// </summary>
        public static readonly StringName GetActionSets = "get_action_sets";
        /// <summary>
        /// Cached name for the 'get_available_display_refresh_rates' method.
        /// </summary>
        public static readonly StringName GetAvailableDisplayRefreshRates = "get_available_display_refresh_rates";
        /// <summary>
        /// Cached name for the 'set_motion_range' method.
        /// </summary>
        public static readonly StringName SetMotionRange = "set_motion_range";
        /// <summary>
        /// Cached name for the 'get_motion_range' method.
        /// </summary>
        public static readonly StringName GetMotionRange = "get_motion_range";
        /// <summary>
        /// Cached name for the 'get_hand_tracking_source' method.
        /// </summary>
        public static readonly StringName GetHandTrackingSource = "get_hand_tracking_source";
        /// <summary>
        /// Cached name for the 'get_hand_joint_flags' method.
        /// </summary>
        public static readonly StringName GetHandJointFlags = "get_hand_joint_flags";
        /// <summary>
        /// Cached name for the 'get_hand_joint_rotation' method.
        /// </summary>
        public static readonly StringName GetHandJointRotation = "get_hand_joint_rotation";
        /// <summary>
        /// Cached name for the 'get_hand_joint_position' method.
        /// </summary>
        public static readonly StringName GetHandJointPosition = "get_hand_joint_position";
        /// <summary>
        /// Cached name for the 'get_hand_joint_radius' method.
        /// </summary>
        public static readonly StringName GetHandJointRadius = "get_hand_joint_radius";
        /// <summary>
        /// Cached name for the 'get_hand_joint_linear_velocity' method.
        /// </summary>
        public static readonly StringName GetHandJointLinearVelocity = "get_hand_joint_linear_velocity";
        /// <summary>
        /// Cached name for the 'get_hand_joint_angular_velocity' method.
        /// </summary>
        public static readonly StringName GetHandJointAngularVelocity = "get_hand_joint_angular_velocity";
        /// <summary>
        /// Cached name for the 'is_hand_tracking_supported' method.
        /// </summary>
        public static readonly StringName IsHandTrackingSupported = "is_hand_tracking_supported";
        /// <summary>
        /// Cached name for the 'is_hand_interaction_supported' method.
        /// </summary>
        public static readonly StringName IsHandInteractionSupported = "is_hand_interaction_supported";
        /// <summary>
        /// Cached name for the 'is_eye_gaze_interaction_supported' method.
        /// </summary>
        public static readonly StringName IsEyeGazeInteractionSupported = "is_eye_gaze_interaction_supported";
        /// <summary>
        /// Cached name for the 'get_vrs_min_radius' method.
        /// </summary>
        public static readonly StringName GetVrsMinRadius = "get_vrs_min_radius";
        /// <summary>
        /// Cached name for the 'set_vrs_min_radius' method.
        /// </summary>
        public static readonly StringName SetVrsMinRadius = "set_vrs_min_radius";
        /// <summary>
        /// Cached name for the 'get_vrs_strength' method.
        /// </summary>
        public static readonly StringName GetVrsStrength = "get_vrs_strength";
        /// <summary>
        /// Cached name for the 'set_vrs_strength' method.
        /// </summary>
        public static readonly StringName SetVrsStrength = "set_vrs_strength";
        /// <summary>
        /// Cached name for the 'set_cpu_level' method.
        /// </summary>
        public static readonly StringName SetCpuLevel = "set_cpu_level";
        /// <summary>
        /// Cached name for the 'set_gpu_level' method.
        /// </summary>
        public static readonly StringName SetGpuLevel = "set_gpu_level";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : XRInterface.SignalName
    {
        /// <summary>
        /// Cached name for the 'session_begun' signal.
        /// </summary>
        public static readonly StringName SessionBegun = "session_begun";
        /// <summary>
        /// Cached name for the 'session_stopping' signal.
        /// </summary>
        public static readonly StringName SessionStopping = "session_stopping";
        /// <summary>
        /// Cached name for the 'session_synchronized' signal.
        /// </summary>
        public static readonly StringName SessionSynchronized = "session_synchronized";
        /// <summary>
        /// Cached name for the 'session_focussed' signal.
        /// </summary>
        public static readonly StringName SessionFocussed = "session_focussed";
        /// <summary>
        /// Cached name for the 'session_visible' signal.
        /// </summary>
        public static readonly StringName SessionVisible = "session_visible";
        /// <summary>
        /// Cached name for the 'session_loss_pending' signal.
        /// </summary>
        public static readonly StringName SessionLossPending = "session_loss_pending";
        /// <summary>
        /// Cached name for the 'instance_exiting' signal.
        /// </summary>
        public static readonly StringName InstanceExiting = "instance_exiting";
        /// <summary>
        /// Cached name for the 'pose_recentered' signal.
        /// </summary>
        public static readonly StringName PoseRecentered = "pose_recentered";
        /// <summary>
        /// Cached name for the 'refresh_rate_changed' signal.
        /// </summary>
        public static readonly StringName RefreshRateChanged = "refresh_rate_changed";
        /// <summary>
        /// Cached name for the 'cpu_level_changed' signal.
        /// </summary>
        public static readonly StringName CpuLevelChanged = "cpu_level_changed";
        /// <summary>
        /// Cached name for the 'gpu_level_changed' signal.
        /// </summary>
        public static readonly StringName GpuLevelChanged = "gpu_level_changed";
    }
}
