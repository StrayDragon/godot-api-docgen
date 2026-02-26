namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This class needs to be implemented to make an AR or VR platform available to Godot and these should be implemented as C++ modules or GDExtension modules. Part of the interface is exposed to GDScript so you can detect, enable and configure an AR or VR platform.</para>
/// <para>Interfaces should be written in such a way that simply enabling them will give us a working setup. You can query the available interfaces through <see cref="Godot.XRServer"/>.</para>
/// </summary>
public partial class XRInterface : RefCounted
{
    public enum Capabilities : long
    {
        /// <summary>
        /// <para>No XR capabilities.</para>
        /// </summary>
        None = 0,
        /// <summary>
        /// <para>This interface can work with normal rendering output (non-HMD based AR).</para>
        /// </summary>
        Mono = 1,
        /// <summary>
        /// <para>This interface supports stereoscopic rendering.</para>
        /// </summary>
        Stereo = 2,
        /// <summary>
        /// <para>This interface supports quad rendering (not yet supported by Godot).</para>
        /// </summary>
        Quad = 4,
        /// <summary>
        /// <para>This interface supports VR.</para>
        /// </summary>
        Vr = 8,
        /// <summary>
        /// <para>This interface supports AR (video background and real world tracking).</para>
        /// </summary>
        Ar = 16,
        /// <summary>
        /// <para>This interface outputs to an external device. If the main viewport is used, the on screen output is an unmodified buffer of either the left or right eye (stretched if the viewport size is not changed to the same aspect ratio of <see cref="Godot.XRInterface.GetRenderTargetSize()"/>). Using a separate viewport node frees up the main viewport for other purposes.</para>
        /// </summary>
        External = 32
    }

    public enum TrackingStatus : long
    {
        /// <summary>
        /// <para>Tracking is behaving as expected.</para>
        /// </summary>
        NormalTracking = 0,
        /// <summary>
        /// <para>Tracking is hindered by excessive motion (the player is moving faster than tracking can keep up).</para>
        /// </summary>
        ExcessiveMotion = 1,
        /// <summary>
        /// <para>Tracking is hindered by insufficient features, it's too dark (for camera-based tracking), player is blocked, etc.</para>
        /// </summary>
        InsufficientFeatures = 2,
        /// <summary>
        /// <para>We don't know the status of the tracking or this interface does not provide feedback.</para>
        /// </summary>
        UnknownTracking = 3,
        /// <summary>
        /// <para>Tracking is not functional (camera not plugged in or obscured, lighthouses turned off, etc.).</para>
        /// </summary>
        NotTracking = 4
    }

    public enum PlayAreaMode : long
    {
        /// <summary>
        /// <para>Play area mode not set or not available.</para>
        /// </summary>
        Unknown = 0,
        /// <summary>
        /// <para>Play area only supports orientation tracking, no positional tracking, area will center around player.</para>
        /// </summary>
        Area3Dof = 1,
        /// <summary>
        /// <para>Player is in seated position, limited positional tracking, fixed guardian around player.</para>
        /// </summary>
        Sitting = 2,
        /// <summary>
        /// <para>Player is free to move around, full positional tracking.</para>
        /// </summary>
        Roomscale = 3,
        /// <summary>
        /// <para>Same as <see cref="Godot.XRInterface.PlayAreaMode.Roomscale"/> but origin point is fixed to the center of the physical space. In this mode, system-level recentering may be disabled, requiring the use of <see cref="Godot.XRServer.CenterOnHmd(XRServer.RotationMode, bool)"/>.</para>
        /// </summary>
        Stage = 4,
        /// <summary>
        /// <para>Custom play area set by a GDExtension.</para>
        /// </summary>
        Custom = 2147483647
    }

    public enum EnvironmentBlendModeEnum : long
    {
        /// <summary>
        /// <para>Opaque blend mode. This is typically used for VR devices.</para>
        /// </summary>
        Opaque = 0,
        /// <summary>
        /// <para>Additive blend mode. This is typically used for AR devices or VR devices with passthrough.</para>
        /// </summary>
        Additive = 1,
        /// <summary>
        /// <para>Alpha blend mode. This is typically used for AR or VR devices with passthrough capabilities. The alpha channel controls how much of the passthrough is visible. Alpha of 0.0 means the passthrough is visible and this pixel works in ADDITIVE mode. Alpha of 1.0 means that the passthrough is not visible and this pixel works in OPAQUE mode.</para>
        /// </summary>
        AlphaBlend = 2
    }

    public enum VrsTextureFormat : long
    {
        /// <summary>
        /// <para>The texture format is the same as returned by <see cref="Godot.Xrvrs.MakeVrsTexture(Vector2, Vector2[])"/>.</para>
        /// </summary>
        Unified = 0,
        /// <summary>
        /// <para>The texture format is the same as expected by the Vulkan <c>VK_KHR_fragment_shading_rate</c> extension.</para>
        /// </summary>
        FragmentShadingRate = 1,
        /// <summary>
        /// <para>The texture format is the same as expected by the Vulkan <c>VK_EXT_fragment_density_map</c> extension.</para>
        /// </summary>
        FragmentDensityMap = 2
    }

    /// <summary>
    /// <para><see langword="true"/> if this is the primary interface.</para>
    /// </summary>
    public bool InterfaceIsPrimary
    {
        get
        {
            return IsPrimary();
        }
        set
        {
            SetPrimary(value);
        }
    }

    /// <summary>
    /// <para>The play area mode for this interface.</para>
    /// </summary>
    public XRInterface.PlayAreaMode XRPlayAreaMode
    {
        get
        {
            return GetPlayAreaMode();
        }
        set
        {
            SetPlayAreaMode(value);
        }
    }

    /// <summary>
    /// <para>Specify how XR should blend in the environment. This is specific to certain AR and passthrough devices where camera images are blended in by the XR compositor.</para>
    /// </summary>
    public XRInterface.EnvironmentBlendModeEnum EnvironmentBlendMode
    {
        get
        {
            return GetEnvironmentBlendMode();
        }
        set
        {
            SetEnvironmentBlendMode(value);
        }
    }

    /// <summary>
    /// <para>On an AR interface, <see langword="true"/> if anchor detection is enabled.</para>
    /// </summary>
    public bool ArIsAnchorDetectionEnabled
    {
        get
        {
            return GetAnchorDetectionIsEnabled();
        }
        set
        {
            SetAnchorDetectionIsEnabled(value);
        }
    }

    private static readonly System.Type CachedType = typeof(XRInterface);

    private static readonly StringName NativeName = "XRInterface";

    internal XRInterface() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal XRInterface(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal XRInterface(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetName, 2002593661ul);

    /// <summary>
    /// <para>Returns the name of this interface (<c>"OpenXR"</c>, <c>"OpenVR"</c>, <c>"OpenHMD"</c>, <c>"ARKit"</c>, etc.).</para>
    /// </summary>
    public StringName GetName()
    {
        return NativeCalls.godot_icall_0_65(MethodBind0, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCapabilities, 3905245786ul);

    /// <summary>
    /// <para>Returns a combination of <see cref="Godot.XRInterface.Capabilities"/> flags providing information about the capabilities of this interface.</para>
    /// </summary>
    public uint GetCapabilities()
    {
        return NativeCalls.godot_icall_0_209(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsPrimary, 2240911060ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsPrimary()
    {
        return NativeCalls.godot_icall_0_15(MethodBind2, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPrimary, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPrimary(bool primary)
    {
        NativeCalls.godot_icall_1_14(MethodBind3, GodotObject.GetPtr(this), primary.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsInitialized, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if this interface has been initialized.</para>
    /// </summary>
    public bool IsInitialized()
    {
        return NativeCalls.godot_icall_0_15(MethodBind4, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Initialize, 2240911060ul);

    /// <summary>
    /// <para>Call this to initialize this interface. The first interface that is initialized is identified as the primary interface and it will be used for rendering output.</para>
    /// <para>After initializing the interface you want to use you then need to enable the AR/VR mode of a viewport and rendering should commence.</para>
    /// <para><b>Note:</b> You must enable the XR mode on the main viewport for any device that uses the main output of Godot, such as for mobile VR.</para>
    /// <para>If you do this for a platform that handles its own output (such as OpenVR) Godot will show just one eye without distortion on screen. Alternatively, you can add a separate viewport node to your scene and enable AR/VR on that viewport. It will be used to output to the HMD, leaving you free to do anything you like in the main window, such as using a separate camera as a spectator camera or rendering something completely different.</para>
    /// <para>While currently not used, you can activate additional interfaces. You may wish to do this if you want to track controllers from other platforms. However, at this point in time only one interface can render to an HMD.</para>
    /// </summary>
    public bool Initialize()
    {
        return NativeCalls.godot_icall_0_15(MethodBind5, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Uninitialize, 3218959716ul);

    /// <summary>
    /// <para>Turns the interface off.</para>
    /// </summary>
    public void Uninitialize()
    {
        NativeCalls.godot_icall_0_3(MethodBind6, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSystemInfo, 2382534195ul);

    /// <summary>
    /// <para>Returns a <see cref="Godot.Collections.Dictionary"/> with extra system info. Interfaces are expected to return <c>XRRuntimeName</c> and <c>XRRuntimeVersion</c> providing info about the used XR runtime. Additional entries may be provided specific to an interface.</para>
    /// <para><b>Note:</b>This information may only be available after <see cref="Godot.XRInterface.Initialize()"/> was successfully called.</para>
    /// </summary>
    public Godot.Collections.Dictionary GetSystemInfo()
    {
        return NativeCalls.godot_icall_0_122(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTrackingStatus, 167423259ul);

    /// <summary>
    /// <para>If supported, returns the status of our tracking. This will allow you to provide feedback to the user whether there are issues with positional tracking.</para>
    /// </summary>
    public XRInterface.TrackingStatus GetTrackingStatus()
    {
        return (XRInterface.TrackingStatus)NativeCalls.godot_icall_0_39(MethodBind8, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRenderTargetSize, 1497962370ul);

    /// <summary>
    /// <para>Returns the resolution at which we should render our intermediate results before things like lens distortion are applied by the VR platform.</para>
    /// </summary>
    public Vector2 GetRenderTargetSize()
    {
        return NativeCalls.godot_icall_0_37(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetViewCount, 2455072627ul);

    /// <summary>
    /// <para>Returns the number of views that need to be rendered for this device. 1 for Monoscopic, 2 for Stereoscopic.</para>
    /// </summary>
    public uint GetViewCount()
    {
        return NativeCalls.godot_icall_0_209(MethodBind10, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.TriggerHapticPulse, 3752640163ul);

    /// <summary>
    /// <para>Triggers a haptic pulse on a device associated with this interface.</para>
    /// <para><paramref name="actionName"/> is the name of the action for this pulse.</para>
    /// <para><paramref name="trackerName"/> is optional and can be used to direct the pulse to a specific device provided that device is bound to this haptic.</para>
    /// <para><paramref name="frequency"/> is the frequency of the pulse, set to <c>0.0</c> to have the system use a default frequency.</para>
    /// <para><paramref name="amplitude"/> is the amplitude of the pulse between <c>0.0</c> and <c>1.0</c>.</para>
    /// <para><paramref name="durationSec"/> is the duration of the pulse in seconds.</para>
    /// <para><paramref name="delaySec"/> is a delay in seconds before the pulse is given.</para>
    /// </summary>
    public void TriggerHapticPulse(string actionName, StringName trackerName, double frequency, double amplitude, double durationSec, double delaySec)
    {
        NativeCalls.godot_icall_6_1510(MethodBind11, GodotObject.GetPtr(this), actionName, (godot_string_name)(trackerName?.NativeValue ?? default), frequency, amplitude, durationSec, delaySec);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SupportsPlayAreaMode, 3429955281ul);

    /// <summary>
    /// <para>Call this to find out if a given play area mode is supported by this interface.</para>
    /// </summary>
    public bool SupportsPlayAreaMode(XRInterface.PlayAreaMode mode)
    {
        return NativeCalls.godot_icall_1_62(MethodBind12, GodotObject.GetPtr(this), (int)mode).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPlayAreaMode, 1615132885ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public XRInterface.PlayAreaMode GetPlayAreaMode()
    {
        return (XRInterface.PlayAreaMode)NativeCalls.godot_icall_0_39(MethodBind13, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPlayAreaMode, 3429955281ul);

    /// <summary>
    /// <para>Sets the active play area mode, will return <see langword="false"/> if the mode can't be used with this interface.</para>
    /// <para><b>Note:</b> Changing this after the interface has already been initialized can be jarring for the player, so it's recommended to recenter on the HMD with <see cref="Godot.XRServer.CenterOnHmd(XRServer.RotationMode, bool)"/> (if switching to <see cref="Godot.XRInterface.PlayAreaMode.Stage"/>) or make the switch during a scene change.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool SetPlayAreaMode(XRInterface.PlayAreaMode mode)
    {
        return NativeCalls.godot_icall_1_62(MethodBind14, GodotObject.GetPtr(this), (int)mode).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPlayArea, 497664490ul);

    /// <summary>
    /// <para>Returns an array of vectors that represent the physical play area mapped to the virtual space around the <see cref="Godot.XROrigin3D"/> point. The points form a convex polygon that can be used to react to or visualize the play area. This returns an empty array if this feature is not supported or if the information is not yet available.</para>
    /// </summary>
    public Vector3[] GetPlayArea()
    {
        return NativeCalls.godot_icall_0_228(MethodBind15, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAnchorDetectionIsEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetAnchorDetectionIsEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind16, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAnchorDetectionIsEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAnchorDetectionIsEnabled(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind17, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCameraFeedId, 2455072627ul);

    /// <summary>
    /// <para>If this is an AR interface that requires displaying a camera feed as the background, this method returns the feed ID in the <see cref="Godot.CameraServer"/> for this interface.</para>
    /// </summary>
    public int GetCameraFeedId()
    {
        return NativeCalls.godot_icall_0_39(MethodBind18, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsPassthroughSupported, 2240911060ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if this interface supports passthrough.</para>
    /// </summary>
    [Obsolete("Check that 'Godot.XRInterface.EnvironmentBlendModeEnum.AlphaBlend' is supported using 'Godot.XRInterface.GetSupportedEnvironmentBlendModes()', instead.")]
    public bool IsPassthroughSupported()
    {
        return NativeCalls.godot_icall_0_15(MethodBind19, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsPassthroughEnabled, 2240911060ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if passthrough is enabled.</para>
    /// </summary>
    [Obsolete("Check if 'Godot.XRInterface.EnvironmentBlendMode' is 'Godot.XRInterface.EnvironmentBlendModeEnum.AlphaBlend', instead.")]
    public bool IsPassthroughEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind20, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.StartPassthrough, 2240911060ul);

    /// <summary>
    /// <para>Starts passthrough, will return <see langword="false"/> if passthrough couldn't be started.</para>
    /// <para><b>Note:</b> The viewport used for XR must have a transparent background, otherwise passthrough may not properly render.</para>
    /// </summary>
    [Obsolete("Set the 'Godot.XRInterface.EnvironmentBlendMode' to 'Godot.XRInterface.EnvironmentBlendModeEnum.AlphaBlend', instead.")]
    public bool StartPassthrough()
    {
        return NativeCalls.godot_icall_0_15(MethodBind21, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.StopPassthrough, 3218959716ul);

    /// <summary>
    /// <para>Stops passthrough.</para>
    /// </summary>
    [Obsolete("Set the 'Godot.XRInterface.EnvironmentBlendMode' to 'Godot.XRInterface.EnvironmentBlendModeEnum.Opaque', instead.")]
    public void StopPassthrough()
    {
        NativeCalls.godot_icall_0_3(MethodBind22, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTransformForView, 518934792ul);

    /// <summary>
    /// <para>Returns the transform for a view/eye.</para>
    /// <para><paramref name="view"/> is the view/eye index.</para>
    /// <para><paramref name="camTransform"/> is the transform that maps device coordinates to scene coordinates, typically the <see cref="Godot.Node3D.GlobalTransform"/> of the current XROrigin3D.</para>
    /// </summary>
    public unsafe Transform3D GetTransformForView(uint view, Transform3D camTransform)
    {
        return NativeCalls.godot_icall_2_1511(MethodBind23, GodotObject.GetPtr(this), view, &camTransform);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetProjectionForView, 3766090294ul);

    /// <summary>
    /// <para>Returns the projection matrix for a view/eye.</para>
    /// </summary>
    public Projection GetProjectionForView(uint view, double aspect, double near, double far)
    {
        return NativeCalls.godot_icall_4_1512(MethodBind24, GodotObject.GetPtr(this), view, aspect, near, far);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSupportedEnvironmentBlendModes, 2915620761ul);

    /// <summary>
    /// <para>Returns the an array of supported environment blend modes, see <see cref="Godot.XRInterface.EnvironmentBlendModeEnum"/>.</para>
    /// </summary>
    public Godot.Collections.Array GetSupportedEnvironmentBlendModes()
    {
        return NativeCalls.godot_icall_0_120(MethodBind25, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEnvironmentBlendMode, 551152418ul);

    /// <summary>
    /// <para>Sets the active environment blend mode.</para>
    /// <para><paramref name="mode"/> is the environment blend mode starting with the next frame.</para>
    /// <para><b>Note:</b> Not all runtimes support all environment blend modes, so it is important to check this at startup. For example:</para>
    /// <para><code>
    /// func _ready():
    /// 	var xr_interface = XRServer.find_interface("OpenXR")
    /// 	if xr_interface and xr_interface.is_initialized():
    /// 		var vp = get_viewport()
    /// 		vp.use_xr = true
    /// 		var acceptable_modes = [XRInterface.XR_ENV_BLEND_MODE_OPAQUE, XRInterface.XR_ENV_BLEND_MODE_ADDITIVE]
    /// 		var modes = xr_interface.get_supported_environment_blend_modes()
    /// 		for mode in acceptable_modes:
    /// 			if mode in modes:
    /// 				xr_interface.set_environment_blend_mode(mode)
    /// 				break
    /// </code></para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool SetEnvironmentBlendMode(XRInterface.EnvironmentBlendModeEnum mode)
    {
        return NativeCalls.godot_icall_1_62(MethodBind26, GodotObject.GetPtr(this), (int)mode).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEnvironmentBlendMode, 1984334071ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public XRInterface.EnvironmentBlendModeEnum GetEnvironmentBlendMode()
    {
        return (XRInterface.EnvironmentBlendModeEnum)NativeCalls.godot_icall_0_39(MethodBind27, GodotObject.GetPtr(this));
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.XRInterface.PlayAreaChanged"/> event of a <see cref="Godot.XRInterface"/> class.
    /// </summary>
    public delegate void PlayAreaChangedEventHandler(long mode);

    private static void PlayAreaChangedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((PlayAreaChangedEventHandler)delegateObj)(VariantUtils.ConvertTo<long>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when the play area is changed. This can be a result of the player resetting the boundary or entering a new play area, the player changing the play area mode, the world scale changing or the player resetting their headset orientation.</para>
    /// </summary>
    public unsafe event PlayAreaChangedEventHandler PlayAreaChanged
    {
        add => Connect(SignalName.PlayAreaChanged, Callable.CreateWithUnsafeTrampoline(value, &PlayAreaChangedTrampoline));
        remove => Disconnect(SignalName.PlayAreaChanged, Callable.CreateWithUnsafeTrampoline(value, &PlayAreaChangedTrampoline));
    }

    protected void EmitSignalPlayAreaChanged(long mode)
    {
        EmitSignal(SignalName.PlayAreaChanged, mode);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_play_area_changed = "PlayAreaChanged";

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
        if (signal == SignalName.PlayAreaChanged)
        {
            if (HasGodotClassSignal(SignalProxyName_play_area_changed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        return base.HasGodotClassSignal(signal);
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : RefCounted.PropertyName
    {
        /// <summary>
        /// Cached name for the 'interface_is_primary' property.
        /// </summary>
        public static readonly StringName InterfaceIsPrimary = "interface_is_primary";
        /// <summary>
        /// Cached name for the 'xr_play_area_mode' property.
        /// </summary>
        public static readonly StringName XRPlayAreaMode = "xr_play_area_mode";
        /// <summary>
        /// Cached name for the 'environment_blend_mode' property.
        /// </summary>
        public static readonly StringName EnvironmentBlendMode = "environment_blend_mode";
        /// <summary>
        /// Cached name for the 'ar_is_anchor_detection_enabled' property.
        /// </summary>
        public static readonly StringName ArIsAnchorDetectionEnabled = "ar_is_anchor_detection_enabled";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : RefCounted.MethodName
    {
        /// <summary>
        /// Cached name for the 'get_name' method.
        /// </summary>
        public static readonly StringName GetName = "get_name";
        /// <summary>
        /// Cached name for the 'get_capabilities' method.
        /// </summary>
        public static readonly StringName GetCapabilities = "get_capabilities";
        /// <summary>
        /// Cached name for the 'is_primary' method.
        /// </summary>
        public static readonly StringName IsPrimary = "is_primary";
        /// <summary>
        /// Cached name for the 'set_primary' method.
        /// </summary>
        public static readonly StringName SetPrimary = "set_primary";
        /// <summary>
        /// Cached name for the 'is_initialized' method.
        /// </summary>
        public static readonly StringName IsInitialized = "is_initialized";
        /// <summary>
        /// Cached name for the 'initialize' method.
        /// </summary>
        public static readonly StringName Initialize = "initialize";
        /// <summary>
        /// Cached name for the 'uninitialize' method.
        /// </summary>
        public static readonly StringName Uninitialize = "uninitialize";
        /// <summary>
        /// Cached name for the 'get_system_info' method.
        /// </summary>
        public static readonly StringName GetSystemInfo = "get_system_info";
        /// <summary>
        /// Cached name for the 'get_tracking_status' method.
        /// </summary>
        public static readonly StringName GetTrackingStatus = "get_tracking_status";
        /// <summary>
        /// Cached name for the 'get_render_target_size' method.
        /// </summary>
        public static readonly StringName GetRenderTargetSize = "get_render_target_size";
        /// <summary>
        /// Cached name for the 'get_view_count' method.
        /// </summary>
        public static readonly StringName GetViewCount = "get_view_count";
        /// <summary>
        /// Cached name for the 'trigger_haptic_pulse' method.
        /// </summary>
        public static readonly StringName TriggerHapticPulse = "trigger_haptic_pulse";
        /// <summary>
        /// Cached name for the 'supports_play_area_mode' method.
        /// </summary>
        public static readonly StringName SupportsPlayAreaMode = "supports_play_area_mode";
        /// <summary>
        /// Cached name for the 'get_play_area_mode' method.
        /// </summary>
        public static readonly StringName GetPlayAreaMode = "get_play_area_mode";
        /// <summary>
        /// Cached name for the 'set_play_area_mode' method.
        /// </summary>
        public static readonly StringName SetPlayAreaMode = "set_play_area_mode";
        /// <summary>
        /// Cached name for the 'get_play_area' method.
        /// </summary>
        public static readonly StringName GetPlayArea = "get_play_area";
        /// <summary>
        /// Cached name for the 'get_anchor_detection_is_enabled' method.
        /// </summary>
        public static readonly StringName GetAnchorDetectionIsEnabled = "get_anchor_detection_is_enabled";
        /// <summary>
        /// Cached name for the 'set_anchor_detection_is_enabled' method.
        /// </summary>
        public static readonly StringName SetAnchorDetectionIsEnabled = "set_anchor_detection_is_enabled";
        /// <summary>
        /// Cached name for the 'get_camera_feed_id' method.
        /// </summary>
        public static readonly StringName GetCameraFeedId = "get_camera_feed_id";
        /// <summary>
        /// Cached name for the 'is_passthrough_supported' method.
        /// </summary>
        public static readonly StringName IsPassthroughSupported = "is_passthrough_supported";
        /// <summary>
        /// Cached name for the 'is_passthrough_enabled' method.
        /// </summary>
        public static readonly StringName IsPassthroughEnabled = "is_passthrough_enabled";
        /// <summary>
        /// Cached name for the 'start_passthrough' method.
        /// </summary>
        public static readonly StringName StartPassthrough = "start_passthrough";
        /// <summary>
        /// Cached name for the 'stop_passthrough' method.
        /// </summary>
        public static readonly StringName StopPassthrough = "stop_passthrough";
        /// <summary>
        /// Cached name for the 'get_transform_for_view' method.
        /// </summary>
        public static readonly StringName GetTransformForView = "get_transform_for_view";
        /// <summary>
        /// Cached name for the 'get_projection_for_view' method.
        /// </summary>
        public static readonly StringName GetProjectionForView = "get_projection_for_view";
        /// <summary>
        /// Cached name for the 'get_supported_environment_blend_modes' method.
        /// </summary>
        public static readonly StringName GetSupportedEnvironmentBlendModes = "get_supported_environment_blend_modes";
        /// <summary>
        /// Cached name for the 'set_environment_blend_mode' method.
        /// </summary>
        public static readonly StringName SetEnvironmentBlendMode = "set_environment_blend_mode";
        /// <summary>
        /// Cached name for the 'get_environment_blend_mode' method.
        /// </summary>
        public static readonly StringName GetEnvironmentBlendMode = "get_environment_blend_mode";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : RefCounted.SignalName
    {
        /// <summary>
        /// Cached name for the 'play_area_changed' signal.
        /// </summary>
        public static readonly StringName PlayAreaChanged = "play_area_changed";
    }
}
