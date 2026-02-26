namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>WebXR is an open standard that allows creating VR and AR applications that run in the web browser.</para>
/// <para>As such, this interface is only available when running in Web exports.</para>
/// <para>WebXR supports a wide range of devices, from the very capable (like Valve Index, HTC Vive, Oculus Rift and Quest) down to the much less capable (like Google Cardboard, Oculus Go, GearVR, or plain smartphones).</para>
/// <para>Since WebXR is based on JavaScript, it makes extensive use of callbacks, which means that <see cref="Godot.WebXRInterface"/> is forced to use signals, where other XR interfaces would instead use functions that return a result immediately. This makes <see cref="Godot.WebXRInterface"/> quite a bit more complicated to initialize than other XR interfaces.</para>
/// <para>Here's the minimum code required to start an immersive VR session:</para>
/// <para><code>
/// extends Node3D
/// 
/// var webxr_interface
/// var vr_supported = false
/// 
/// func _ready():
/// 	# We assume this node has a button as a child.
/// 	# This button is for the user to consent to entering immersive VR mode.
/// 	$Button.pressed.connect(self._on_button_pressed)
/// 
/// 	webxr_interface = XRServer.find_interface("WebXR")
/// 	if webxr_interface:
/// 		# WebXR uses a lot of asynchronous callbacks, so we connect to various
/// 		# signals in order to receive them.
/// 		webxr_interface.session_supported.connect(self._webxr_session_supported)
/// 		webxr_interface.session_started.connect(self._webxr_session_started)
/// 		webxr_interface.session_ended.connect(self._webxr_session_ended)
/// 		webxr_interface.session_failed.connect(self._webxr_session_failed)
/// 
/// 		# This returns immediately - our _webxr_session_supported() method
/// 		# (which we connected to the "session_supported" signal above) will
/// 		# be called sometime later to let us know if it's supported or not.
/// 		webxr_interface.is_session_supported("immersive-vr")
/// 
/// func _webxr_session_supported(session_mode, supported):
/// 	if session_mode == 'immersive-vr':
/// 		vr_supported = supported
/// 
/// func _on_button_pressed():
/// 	if not vr_supported:
/// 		OS.alert("Your browser doesn't support VR")
/// 		return
/// 
/// 	# We want an immersive VR session, as opposed to AR ('immersive-ar') or a
/// 	# simple 3DoF viewer ('viewer').
/// 	webxr_interface.session_mode = 'immersive-vr'
/// 	# 'bounded-floor' is room scale, 'local-floor' is a standing or sitting
/// 	# experience (it puts you 1.6m above the ground if you have 3DoF headset),
/// 	# whereas as 'local' puts you down at the XROrigin.
/// 	# This list means it'll first try to request 'bounded-floor', then
/// 	# fallback on 'local-floor' and ultimately 'local', if nothing else is
/// 	# supported.
/// 	webxr_interface.requested_reference_space_types = 'bounded-floor, local-floor, local'
/// 	# In order to use 'local-floor' or 'bounded-floor' we must also
/// 	# mark the features as required or optional. By including 'hand-tracking'
/// 	# as an optional feature, it will be enabled if supported.
/// 	webxr_interface.required_features = 'local-floor'
/// 	webxr_interface.optional_features = 'bounded-floor, hand-tracking'
/// 
/// 	# This will return false if we're unable to even request the session,
/// 	# however, it can still fail asynchronously later in the process, so we
/// 	# only know if it's really succeeded or failed when our
/// 	# _webxr_session_started() or _webxr_session_failed() methods are called.
/// 	if not webxr_interface.initialize():
/// 		OS.alert("Failed to initialize")
/// 		return
/// 
/// func _webxr_session_started():
/// 	$Button.visible = false
/// 	# This tells Godot to start rendering to the headset.
/// 	get_viewport().use_xr = true
/// 	# This will be the reference space type you ultimately got, out of the
/// 	# types that you requested above. This is useful if you want the game to
/// 	# work a little differently in 'bounded-floor' versus 'local-floor'.
/// 	print("Reference space type: ", webxr_interface.reference_space_type)
/// 	# This will be the list of features that were successfully enabled
/// 	# (except on browsers that don't support this property).
/// 	print("Enabled features: ", webxr_interface.enabled_features)
/// 
/// func _webxr_session_ended():
/// 	$Button.visible = true
/// 	# If the user exits immersive mode, then we tell Godot to render to the web
/// 	# page again.
/// 	get_viewport().use_xr = false
/// 
/// func _webxr_session_failed(message):
/// 	OS.alert("Failed to initialize: " + message)
/// </code></para>
/// <para>There are a couple ways to handle "controller" input:</para>
/// <para>- Using <see cref="Godot.XRController3D"/> nodes and their <see cref="Godot.XRController3D.ButtonPressed"/> and <see cref="Godot.XRController3D.ButtonReleased"/> signals. This is how controllers are typically handled in XR apps in Godot, however, this will only work with advanced VR controllers like the Oculus Touch or Index controllers, for example.</para>
/// <para>- Using the <see cref="Godot.WebXRInterface.Select"/>, <see cref="Godot.WebXRInterface.Squeeze"/> and related signals. This method will work for both advanced VR controllers, and non-traditional input sources like a tap on the screen, a spoken voice command or a button press on the device itself.</para>
/// <para>You can use both methods to allow your game or app to support a wider or narrower set of devices and input methods, or to allow more advanced interactions with more advanced devices.</para>
/// </summary>
public partial class WebXRInterface : XRInterface
{
    public enum TargetRayMode : long
    {
        /// <summary>
        /// <para>We don't know the target ray mode.</para>
        /// </summary>
        Unknown = 0,
        /// <summary>
        /// <para>Target ray originates at the viewer's eyes and points in the direction they are looking.</para>
        /// </summary>
        Gaze = 1,
        /// <summary>
        /// <para>Target ray from a handheld pointer, most likely a VR touch controller.</para>
        /// </summary>
        TrackedPointer = 2,
        /// <summary>
        /// <para>Target ray from touch screen, mouse or other tactile input device.</para>
        /// </summary>
        Screen = 3
    }

    /// <summary>
    /// <para>The session mode used by <see cref="Godot.XRInterface.Initialize()"/> when setting up the WebXR session.</para>
    /// <para>This doesn't have any effect on the interface when already initialized.</para>
    /// <para>Possible values come from <a href="https://developer.mozilla.org/en-US/docs/Web/API/XRSessionMode">WebXR's XRSessionMode</a>, including: <c>"immersive-vr"</c>, <c>"immersive-ar"</c>, and <c>"inline"</c>.</para>
    /// </summary>
    public string SessionMode
    {
        get
        {
            return GetSessionMode();
        }
        set
        {
            SetSessionMode(value);
        }
    }

    /// <summary>
    /// <para>A comma-seperated list of required features used by <see cref="Godot.XRInterface.Initialize()"/> when setting up the WebXR session.</para>
    /// <para>If a user's browser or device doesn't support one of the given features, initialization will fail and <see cref="Godot.WebXRInterface.SessionFailed"/> will be emitted.</para>
    /// <para>This doesn't have any effect on the interface when already initialized.</para>
    /// <para>See the MDN documentation on <a href="https://developer.mozilla.org/en-US/docs/Web/API/XRSystem/requestSession#session_features">WebXR's session features</a> for a list of possible values.</para>
    /// </summary>
    public string RequiredFeatures
    {
        get
        {
            return GetRequiredFeatures();
        }
        set
        {
            SetRequiredFeatures(value);
        }
    }

    /// <summary>
    /// <para>A comma-seperated list of optional features used by <see cref="Godot.XRInterface.Initialize()"/> when setting up the WebXR session.</para>
    /// <para>If a user's browser or device doesn't support one of the given features, initialization will continue, but you won't be able to use the requested feature.</para>
    /// <para>This doesn't have any effect on the interface when already initialized.</para>
    /// <para>See the MDN documentation on <a href="https://developer.mozilla.org/en-US/docs/Web/API/XRSystem/requestSession#session_features">WebXR's session features</a> for a list of possible values.</para>
    /// </summary>
    public string OptionalFeatures
    {
        get
        {
            return GetOptionalFeatures();
        }
        set
        {
            SetOptionalFeatures(value);
        }
    }

    /// <summary>
    /// <para>A comma-seperated list of reference space types used by <see cref="Godot.XRInterface.Initialize()"/> when setting up the WebXR session.</para>
    /// <para>The reference space types are requested in order, and the first one supported by the user's device or browser will be used. The <see cref="Godot.WebXRInterface.ReferenceSpaceType"/> property contains the reference space type that was ultimately selected.</para>
    /// <para>This doesn't have any effect on the interface when already initialized.</para>
    /// <para>Possible values come from <a href="https://developer.mozilla.org/en-US/docs/Web/API/XRReferenceSpaceType">WebXR's XRReferenceSpaceType</a>. If you want to use a particular reference space type, it must be listed in either <see cref="Godot.WebXRInterface.RequiredFeatures"/> or <see cref="Godot.WebXRInterface.OptionalFeatures"/>.</para>
    /// </summary>
    public string RequestedReferenceSpaceTypes
    {
        get
        {
            return GetRequestedReferenceSpaceTypes();
        }
        set
        {
            SetRequestedReferenceSpaceTypes(value);
        }
    }

    /// <summary>
    /// <para>The reference space type (from the list of requested types set in the <see cref="Godot.WebXRInterface.RequestedReferenceSpaceTypes"/> property), that was ultimately used by <see cref="Godot.XRInterface.Initialize()"/> when setting up the WebXR session.</para>
    /// <para>Possible values come from <a href="https://developer.mozilla.org/en-US/docs/Web/API/XRReferenceSpaceType">WebXR's XRReferenceSpaceType</a>. If you want to use a particular reference space type, it must be listed in either <see cref="Godot.WebXRInterface.RequiredFeatures"/> or <see cref="Godot.WebXRInterface.OptionalFeatures"/>.</para>
    /// </summary>
    public string ReferenceSpaceType
    {
        get
        {
            return GetReferenceSpaceType();
        }
    }

    /// <summary>
    /// <para>A comma-separated list of features that were successfully enabled by <see cref="Godot.XRInterface.Initialize()"/> when setting up the WebXR session.</para>
    /// <para>This may include features requested by setting <see cref="Godot.WebXRInterface.RequiredFeatures"/> and <see cref="Godot.WebXRInterface.OptionalFeatures"/>, and will only be available after <see cref="Godot.WebXRInterface.SessionStarted"/> has been emitted.</para>
    /// <para><b>Note:</b> This may not be support by all web browsers, in which case it will be an empty string.</para>
    /// </summary>
    public string EnabledFeatures
    {
        get
        {
            return GetEnabledFeatures();
        }
    }

    /// <summary>
    /// <para>Indicates if the WebXR session's imagery is visible to the user.</para>
    /// <para>Possible values come from <a href="https://developer.mozilla.org/en-US/docs/Web/API/XRVisibilityState">WebXR's XRVisibilityState</a>, including <c>"hidden"</c>, <c>"visible"</c>, and <c>"visible-blurred"</c>.</para>
    /// </summary>
    public string VisibilityState
    {
        get
        {
            return GetVisibilityState();
        }
    }

    private static readonly System.Type CachedType = typeof(WebXRInterface);

    private static readonly StringName NativeName = "WebXRInterface";

    internal WebXRInterface() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal WebXRInterface(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal WebXRInterface(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsSessionSupported, 83702148ul);

    /// <summary>
    /// <para>Checks if the given <paramref name="sessionMode"/> is supported by the user's browser.</para>
    /// <para>Possible values come from <a href="https://developer.mozilla.org/en-US/docs/Web/API/XRSessionMode">WebXR's XRSessionMode</a>, including: <c>"immersive-vr"</c>, <c>"immersive-ar"</c>, and <c>"inline"</c>.</para>
    /// <para>This method returns nothing, instead it emits the <see cref="Godot.WebXRInterface.SessionSupported"/> signal with the result.</para>
    /// </summary>
    public void IsSessionSupported(string sessionMode)
    {
        NativeCalls.godot_icall_1_57(MethodBind0, GodotObject.GetPtr(this), sessionMode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSessionMode, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSessionMode(string sessionMode)
    {
        NativeCalls.godot_icall_1_57(MethodBind1, GodotObject.GetPtr(this), sessionMode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSessionMode, 201670096ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetSessionMode()
    {
        return NativeCalls.godot_icall_0_58(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRequiredFeatures, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetRequiredFeatures(string requiredFeatures)
    {
        NativeCalls.godot_icall_1_57(MethodBind3, GodotObject.GetPtr(this), requiredFeatures);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRequiredFeatures, 201670096ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetRequiredFeatures()
    {
        return NativeCalls.godot_icall_0_58(MethodBind4, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetOptionalFeatures, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetOptionalFeatures(string optionalFeatures)
    {
        NativeCalls.godot_icall_1_57(MethodBind5, GodotObject.GetPtr(this), optionalFeatures);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOptionalFeatures, 201670096ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetOptionalFeatures()
    {
        return NativeCalls.godot_icall_0_58(MethodBind6, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetReferenceSpaceType, 201670096ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetReferenceSpaceType()
    {
        return NativeCalls.godot_icall_0_58(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEnabledFeatures, 201670096ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetEnabledFeatures()
    {
        return NativeCalls.godot_icall_0_58(MethodBind8, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRequestedReferenceSpaceTypes, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetRequestedReferenceSpaceTypes(string requestedReferenceSpaceTypes)
    {
        NativeCalls.godot_icall_1_57(MethodBind9, GodotObject.GetPtr(this), requestedReferenceSpaceTypes);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRequestedReferenceSpaceTypes, 201670096ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetRequestedReferenceSpaceTypes()
    {
        return NativeCalls.godot_icall_0_58(MethodBind10, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsInputSourceActive, 1116898809ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if there is an active input source with the given <paramref name="inputSourceId"/>.</para>
    /// </summary>
    public bool IsInputSourceActive(int inputSourceId)
    {
        return NativeCalls.godot_icall_1_62(MethodBind11, GodotObject.GetPtr(this), inputSourceId).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetInputSourceTracker, 399776966ul);

    /// <summary>
    /// <para>Gets an <see cref="Godot.XRControllerTracker"/> for the given <paramref name="inputSourceId"/>.</para>
    /// <para>In the context of WebXR, an input source can be an advanced VR controller like the Oculus Touch or Index controllers, or even a tap on the screen, a spoken voice command or a button press on the device itself. When a non-traditional input source is used, interpret the position and orientation of the <see cref="Godot.XRPositionalTracker"/> as a ray pointing at the object the user wishes to interact with.</para>
    /// <para>Use this method to get information about the input source that triggered one of these signals:</para>
    /// <para>- <see cref="Godot.WebXRInterface.Selectstart"/></para>
    /// <para>- <see cref="Godot.WebXRInterface.Select"/></para>
    /// <para>- <see cref="Godot.WebXRInterface.Selectend"/></para>
    /// <para>- <see cref="Godot.WebXRInterface.Squeezestart"/></para>
    /// <para>- <see cref="Godot.WebXRInterface.Squeeze"/></para>
    /// <para>- <see cref="Godot.WebXRInterface.Squeezestart"/></para>
    /// </summary>
    public XRControllerTracker GetInputSourceTracker(int inputSourceId)
    {
        return (XRControllerTracker)NativeCalls.godot_icall_1_71(MethodBind12, GodotObject.GetPtr(this), inputSourceId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetInputSourceTargetRayMode, 2852387453ul);

    /// <summary>
    /// <para>Returns the target ray mode for the given <paramref name="inputSourceId"/>.</para>
    /// <para>This can help interpret the input coming from that input source. See <a href="https://developer.mozilla.org/en-US/docs/Web/API/XRInputSource/targetRayMode">XRInputSource.targetRayMode</a> for more information.</para>
    /// </summary>
    public WebXRInterface.TargetRayMode GetInputSourceTargetRayMode(int inputSourceId)
    {
        return (WebXRInterface.TargetRayMode)NativeCalls.godot_icall_1_60(MethodBind13, GodotObject.GetPtr(this), inputSourceId);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVisibilityState, 201670096ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetVisibilityState()
    {
        return NativeCalls.godot_icall_0_58(MethodBind14, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDisplayRefreshRate, 1740695150ul);

    /// <summary>
    /// <para>Returns the display refresh rate for the current HMD. Not supported on all HMDs and browsers. It may not report an accurate value until after using <see cref="Godot.WebXRInterface.SetDisplayRefreshRate(float)"/>.</para>
    /// </summary>
    public float GetDisplayRefreshRate()
    {
        return NativeCalls.godot_icall_0_68(MethodBind15, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDisplayRefreshRate, 373806689ul);

    /// <summary>
    /// <para>Sets the display refresh rate for the current HMD. Not supported on all HMDs and browsers. It won't take effect right away until after <see cref="Godot.WebXRInterface.DisplayRefreshRateChanged"/> is emitted.</para>
    /// </summary>
    public void SetDisplayRefreshRate(float refreshRate)
    {
        NativeCalls.godot_icall_1_67(MethodBind16, GodotObject.GetPtr(this), refreshRate);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAvailableDisplayRefreshRates, 3995934104ul);

    /// <summary>
    /// <para>Returns display refresh rates supported by the current HMD. Only returned if this feature is supported by the web browser and after the interface has been initialized.</para>
    /// </summary>
    public Godot.Collections.Array GetAvailableDisplayRefreshRates()
    {
        return NativeCalls.godot_icall_0_120(MethodBind17, GodotObject.GetPtr(this));
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.WebXRInterface.SessionSupported"/> event of a <see cref="Godot.WebXRInterface"/> class.
    /// </summary>
    public delegate void SessionSupportedEventHandler(string sessionMode, bool supported);

    private static void SessionSupportedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 2);
        ((SessionSupportedEventHandler)delegateObj)(VariantUtils.ConvertTo<string>(args[0]), VariantUtils.ConvertTo<bool>(args[1]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted by <see cref="Godot.WebXRInterface.IsSessionSupported(string)"/> to indicate if the given <c>sessionMode</c> is supported or not.</para>
    /// </summary>
    public unsafe event SessionSupportedEventHandler SessionSupported
    {
        add => Connect(SignalName.SessionSupported, Callable.CreateWithUnsafeTrampoline(value, &SessionSupportedTrampoline));
        remove => Disconnect(SignalName.SessionSupported, Callable.CreateWithUnsafeTrampoline(value, &SessionSupportedTrampoline));
    }

    protected void EmitSignalSessionSupported(string sessionMode, bool supported)
    {
        EmitSignal(SignalName.SessionSupported, sessionMode, supported);
    }

    /// <summary>
    /// <para>Emitted by <see cref="Godot.XRInterface.Initialize()"/> if the session is successfully started.</para>
    /// <para>At this point, it's safe to do <c>get_viewport().use_xr = true</c> to instruct Godot to start rendering to the XR device.</para>
    /// </summary>
    public event Action SessionStarted
    {
        add => Connect(SignalName.SessionStarted, Callable.From(value));
        remove => Disconnect(SignalName.SessionStarted, Callable.From(value));
    }

    protected void EmitSignalSessionStarted()
    {
        EmitSignal(SignalName.SessionStarted);
    }

    /// <summary>
    /// <para>Emitted when the user ends the WebXR session (which can be done using UI from the browser or device).</para>
    /// <para>At this point, you should do <c>get_viewport().use_xr = false</c> to instruct Godot to resume rendering to the screen.</para>
    /// </summary>
    public event Action SessionEnded
    {
        add => Connect(SignalName.SessionEnded, Callable.From(value));
        remove => Disconnect(SignalName.SessionEnded, Callable.From(value));
    }

    protected void EmitSignalSessionEnded()
    {
        EmitSignal(SignalName.SessionEnded);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.WebXRInterface.SessionFailed"/> event of a <see cref="Godot.WebXRInterface"/> class.
    /// </summary>
    public delegate void SessionFailedEventHandler(string message);

    private static void SessionFailedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((SessionFailedEventHandler)delegateObj)(VariantUtils.ConvertTo<string>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted by <see cref="Godot.XRInterface.Initialize()"/> if the session fails to start.</para>
    /// <para><c>message</c> may optionally contain an error message from WebXR, or an empty string if no message is available.</para>
    /// </summary>
    public unsafe event SessionFailedEventHandler SessionFailed
    {
        add => Connect(SignalName.SessionFailed, Callable.CreateWithUnsafeTrampoline(value, &SessionFailedTrampoline));
        remove => Disconnect(SignalName.SessionFailed, Callable.CreateWithUnsafeTrampoline(value, &SessionFailedTrampoline));
    }

    protected void EmitSignalSessionFailed(string message)
    {
        EmitSignal(SignalName.SessionFailed, message);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.WebXRInterface.Selectstart"/> event of a <see cref="Godot.WebXRInterface"/> class.
    /// </summary>
    public delegate void SelectstartEventHandler(long inputSourceId);

    private static void SelectstartTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((SelectstartEventHandler)delegateObj)(VariantUtils.ConvertTo<long>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when one of the input source has started its "primary action".</para>
    /// <para>Use <see cref="Godot.WebXRInterface.GetInputSourceTracker(int)"/> and <see cref="Godot.WebXRInterface.GetInputSourceTargetRayMode(int)"/> to get more information about the input source.</para>
    /// </summary>
    public unsafe event SelectstartEventHandler Selectstart
    {
        add => Connect(SignalName.Selectstart, Callable.CreateWithUnsafeTrampoline(value, &SelectstartTrampoline));
        remove => Disconnect(SignalName.Selectstart, Callable.CreateWithUnsafeTrampoline(value, &SelectstartTrampoline));
    }

    protected void EmitSignalSelectstart(long inputSourceId)
    {
        EmitSignal(SignalName.Selectstart, inputSourceId);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.WebXRInterface.Select"/> event of a <see cref="Godot.WebXRInterface"/> class.
    /// </summary>
    public delegate void SelectEventHandler(long inputSourceId);

    private static void SelectTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((SelectEventHandler)delegateObj)(VariantUtils.ConvertTo<long>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted after one of the input sources has finished its "primary action".</para>
    /// <para>Use <see cref="Godot.WebXRInterface.GetInputSourceTracker(int)"/> and <see cref="Godot.WebXRInterface.GetInputSourceTargetRayMode(int)"/> to get more information about the input source.</para>
    /// </summary>
    public unsafe event SelectEventHandler Select
    {
        add => Connect(SignalName.Select, Callable.CreateWithUnsafeTrampoline(value, &SelectTrampoline));
        remove => Disconnect(SignalName.Select, Callable.CreateWithUnsafeTrampoline(value, &SelectTrampoline));
    }

    protected void EmitSignalSelect(long inputSourceId)
    {
        EmitSignal(SignalName.Select, inputSourceId);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.WebXRInterface.Selectend"/> event of a <see cref="Godot.WebXRInterface"/> class.
    /// </summary>
    public delegate void SelectendEventHandler(long inputSourceId);

    private static void SelectendTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((SelectendEventHandler)delegateObj)(VariantUtils.ConvertTo<long>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when one of the input sources has finished its "primary action".</para>
    /// <para>Use <see cref="Godot.WebXRInterface.GetInputSourceTracker(int)"/> and <see cref="Godot.WebXRInterface.GetInputSourceTargetRayMode(int)"/> to get more information about the input source.</para>
    /// </summary>
    public unsafe event SelectendEventHandler Selectend
    {
        add => Connect(SignalName.Selectend, Callable.CreateWithUnsafeTrampoline(value, &SelectendTrampoline));
        remove => Disconnect(SignalName.Selectend, Callable.CreateWithUnsafeTrampoline(value, &SelectendTrampoline));
    }

    protected void EmitSignalSelectend(long inputSourceId)
    {
        EmitSignal(SignalName.Selectend, inputSourceId);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.WebXRInterface.Squeezestart"/> event of a <see cref="Godot.WebXRInterface"/> class.
    /// </summary>
    public delegate void SqueezestartEventHandler(long inputSourceId);

    private static void SqueezestartTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((SqueezestartEventHandler)delegateObj)(VariantUtils.ConvertTo<long>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when one of the input sources has started its "primary squeeze action".</para>
    /// <para>Use <see cref="Godot.WebXRInterface.GetInputSourceTracker(int)"/> and <see cref="Godot.WebXRInterface.GetInputSourceTargetRayMode(int)"/> to get more information about the input source.</para>
    /// </summary>
    public unsafe event SqueezestartEventHandler Squeezestart
    {
        add => Connect(SignalName.Squeezestart, Callable.CreateWithUnsafeTrampoline(value, &SqueezestartTrampoline));
        remove => Disconnect(SignalName.Squeezestart, Callable.CreateWithUnsafeTrampoline(value, &SqueezestartTrampoline));
    }

    protected void EmitSignalSqueezestart(long inputSourceId)
    {
        EmitSignal(SignalName.Squeezestart, inputSourceId);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.WebXRInterface.Squeeze"/> event of a <see cref="Godot.WebXRInterface"/> class.
    /// </summary>
    public delegate void SqueezeEventHandler(long inputSourceId);

    private static void SqueezeTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((SqueezeEventHandler)delegateObj)(VariantUtils.ConvertTo<long>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted after one of the input sources has finished its "primary squeeze action".</para>
    /// <para>Use <see cref="Godot.WebXRInterface.GetInputSourceTracker(int)"/> and <see cref="Godot.WebXRInterface.GetInputSourceTargetRayMode(int)"/> to get more information about the input source.</para>
    /// </summary>
    public unsafe event SqueezeEventHandler Squeeze
    {
        add => Connect(SignalName.Squeeze, Callable.CreateWithUnsafeTrampoline(value, &SqueezeTrampoline));
        remove => Disconnect(SignalName.Squeeze, Callable.CreateWithUnsafeTrampoline(value, &SqueezeTrampoline));
    }

    protected void EmitSignalSqueeze(long inputSourceId)
    {
        EmitSignal(SignalName.Squeeze, inputSourceId);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.WebXRInterface.Squeezeend"/> event of a <see cref="Godot.WebXRInterface"/> class.
    /// </summary>
    public delegate void SqueezeendEventHandler(long inputSourceId);

    private static void SqueezeendTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((SqueezeendEventHandler)delegateObj)(VariantUtils.ConvertTo<long>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when one of the input sources has finished its "primary squeeze action".</para>
    /// <para>Use <see cref="Godot.WebXRInterface.GetInputSourceTracker(int)"/> and <see cref="Godot.WebXRInterface.GetInputSourceTargetRayMode(int)"/> to get more information about the input source.</para>
    /// </summary>
    public unsafe event SqueezeendEventHandler Squeezeend
    {
        add => Connect(SignalName.Squeezeend, Callable.CreateWithUnsafeTrampoline(value, &SqueezeendTrampoline));
        remove => Disconnect(SignalName.Squeezeend, Callable.CreateWithUnsafeTrampoline(value, &SqueezeendTrampoline));
    }

    protected void EmitSignalSqueezeend(long inputSourceId)
    {
        EmitSignal(SignalName.Squeezeend, inputSourceId);
    }

    /// <summary>
    /// <para>Emitted when <see cref="Godot.WebXRInterface.VisibilityState"/> has changed.</para>
    /// </summary>
    public event Action VisibilityStateChanged
    {
        add => Connect(SignalName.VisibilityStateChanged, Callable.From(value));
        remove => Disconnect(SignalName.VisibilityStateChanged, Callable.From(value));
    }

    protected void EmitSignalVisibilityStateChanged()
    {
        EmitSignal(SignalName.VisibilityStateChanged);
    }

    /// <summary>
    /// <para>Emitted to indicate that the reference space has been reset or reconfigured.</para>
    /// <para>When (or whether) this is emitted depends on the user's browser or device, but may include when the user has changed the dimensions of their play space (which you may be able to access via <see cref="Godot.XRInterface.GetPlayArea()"/>) or pressed/held a button to recenter their position.</para>
    /// <para>See <a href="https://developer.mozilla.org/en-US/docs/Web/API/XRReferenceSpace/reset_event">WebXR's XRReferenceSpace reset event</a> for more information.</para>
    /// </summary>
    public event Action ReferenceSpaceReset
    {
        add => Connect(SignalName.ReferenceSpaceReset, Callable.From(value));
        remove => Disconnect(SignalName.ReferenceSpaceReset, Callable.From(value));
    }

    protected void EmitSignalReferenceSpaceReset()
    {
        EmitSignal(SignalName.ReferenceSpaceReset);
    }

    /// <summary>
    /// <para>Emitted after the display's refresh rate has changed.</para>
    /// </summary>
    public event Action DisplayRefreshRateChanged
    {
        add => Connect(SignalName.DisplayRefreshRateChanged, Callable.From(value));
        remove => Disconnect(SignalName.DisplayRefreshRateChanged, Callable.From(value));
    }

    protected void EmitSignalDisplayRefreshRateChanged()
    {
        EmitSignal(SignalName.DisplayRefreshRateChanged);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_session_supported = "SessionSupported";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_session_started = "SessionStarted";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_session_ended = "SessionEnded";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_session_failed = "SessionFailed";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_selectstart = "Selectstart";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_select = "Select";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_selectend = "Selectend";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_squeezestart = "Squeezestart";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_squeeze = "Squeeze";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_squeezeend = "Squeezeend";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_visibility_state_changed = "VisibilityStateChanged";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_reference_space_reset = "ReferenceSpaceReset";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_display_refresh_rate_changed = "DisplayRefreshRateChanged";

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
        if (signal == SignalName.SessionSupported)
        {
            if (HasGodotClassSignal(SignalProxyName_session_supported.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.SessionStarted)
        {
            if (HasGodotClassSignal(SignalProxyName_session_started.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.SessionEnded)
        {
            if (HasGodotClassSignal(SignalProxyName_session_ended.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.SessionFailed)
        {
            if (HasGodotClassSignal(SignalProxyName_session_failed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.Selectstart)
        {
            if (HasGodotClassSignal(SignalProxyName_selectstart.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.Select)
        {
            if (HasGodotClassSignal(SignalProxyName_select.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.Selectend)
        {
            if (HasGodotClassSignal(SignalProxyName_selectend.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.Squeezestart)
        {
            if (HasGodotClassSignal(SignalProxyName_squeezestart.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.Squeeze)
        {
            if (HasGodotClassSignal(SignalProxyName_squeeze.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.Squeezeend)
        {
            if (HasGodotClassSignal(SignalProxyName_squeezeend.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.VisibilityStateChanged)
        {
            if (HasGodotClassSignal(SignalProxyName_visibility_state_changed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.ReferenceSpaceReset)
        {
            if (HasGodotClassSignal(SignalProxyName_reference_space_reset.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.DisplayRefreshRateChanged)
        {
            if (HasGodotClassSignal(SignalProxyName_display_refresh_rate_changed.NativeValue.DangerousSelfRef))
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
        /// Cached name for the 'session_mode' property.
        /// </summary>
        public static readonly StringName SessionMode = "session_mode";
        /// <summary>
        /// Cached name for the 'required_features' property.
        /// </summary>
        public static readonly StringName RequiredFeatures = "required_features";
        /// <summary>
        /// Cached name for the 'optional_features' property.
        /// </summary>
        public static readonly StringName OptionalFeatures = "optional_features";
        /// <summary>
        /// Cached name for the 'requested_reference_space_types' property.
        /// </summary>
        public static readonly StringName RequestedReferenceSpaceTypes = "requested_reference_space_types";
        /// <summary>
        /// Cached name for the 'reference_space_type' property.
        /// </summary>
        public static readonly StringName ReferenceSpaceType = "reference_space_type";
        /// <summary>
        /// Cached name for the 'enabled_features' property.
        /// </summary>
        public static readonly StringName EnabledFeatures = "enabled_features";
        /// <summary>
        /// Cached name for the 'visibility_state' property.
        /// </summary>
        public static readonly StringName VisibilityState = "visibility_state";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : XRInterface.MethodName
    {
        /// <summary>
        /// Cached name for the 'is_session_supported' method.
        /// </summary>
        public static readonly StringName IsSessionSupported = "is_session_supported";
        /// <summary>
        /// Cached name for the 'set_session_mode' method.
        /// </summary>
        public static readonly StringName SetSessionMode = "set_session_mode";
        /// <summary>
        /// Cached name for the 'get_session_mode' method.
        /// </summary>
        public static readonly StringName GetSessionMode = "get_session_mode";
        /// <summary>
        /// Cached name for the 'set_required_features' method.
        /// </summary>
        public static readonly StringName SetRequiredFeatures = "set_required_features";
        /// <summary>
        /// Cached name for the 'get_required_features' method.
        /// </summary>
        public static readonly StringName GetRequiredFeatures = "get_required_features";
        /// <summary>
        /// Cached name for the 'set_optional_features' method.
        /// </summary>
        public static readonly StringName SetOptionalFeatures = "set_optional_features";
        /// <summary>
        /// Cached name for the 'get_optional_features' method.
        /// </summary>
        public static readonly StringName GetOptionalFeatures = "get_optional_features";
        /// <summary>
        /// Cached name for the 'get_reference_space_type' method.
        /// </summary>
        public static readonly StringName GetReferenceSpaceType = "get_reference_space_type";
        /// <summary>
        /// Cached name for the 'get_enabled_features' method.
        /// </summary>
        public static readonly StringName GetEnabledFeatures = "get_enabled_features";
        /// <summary>
        /// Cached name for the 'set_requested_reference_space_types' method.
        /// </summary>
        public static readonly StringName SetRequestedReferenceSpaceTypes = "set_requested_reference_space_types";
        /// <summary>
        /// Cached name for the 'get_requested_reference_space_types' method.
        /// </summary>
        public static readonly StringName GetRequestedReferenceSpaceTypes = "get_requested_reference_space_types";
        /// <summary>
        /// Cached name for the 'is_input_source_active' method.
        /// </summary>
        public static readonly StringName IsInputSourceActive = "is_input_source_active";
        /// <summary>
        /// Cached name for the 'get_input_source_tracker' method.
        /// </summary>
        public static readonly StringName GetInputSourceTracker = "get_input_source_tracker";
        /// <summary>
        /// Cached name for the 'get_input_source_target_ray_mode' method.
        /// </summary>
        public static readonly StringName GetInputSourceTargetRayMode = "get_input_source_target_ray_mode";
        /// <summary>
        /// Cached name for the 'get_visibility_state' method.
        /// </summary>
        public static readonly StringName GetVisibilityState = "get_visibility_state";
        /// <summary>
        /// Cached name for the 'get_display_refresh_rate' method.
        /// </summary>
        public static readonly StringName GetDisplayRefreshRate = "get_display_refresh_rate";
        /// <summary>
        /// Cached name for the 'set_display_refresh_rate' method.
        /// </summary>
        public static readonly StringName SetDisplayRefreshRate = "set_display_refresh_rate";
        /// <summary>
        /// Cached name for the 'get_available_display_refresh_rates' method.
        /// </summary>
        public static readonly StringName GetAvailableDisplayRefreshRates = "get_available_display_refresh_rates";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : XRInterface.SignalName
    {
        /// <summary>
        /// Cached name for the 'session_supported' signal.
        /// </summary>
        public static readonly StringName SessionSupported = "session_supported";
        /// <summary>
        /// Cached name for the 'session_started' signal.
        /// </summary>
        public static readonly StringName SessionStarted = "session_started";
        /// <summary>
        /// Cached name for the 'session_ended' signal.
        /// </summary>
        public static readonly StringName SessionEnded = "session_ended";
        /// <summary>
        /// Cached name for the 'session_failed' signal.
        /// </summary>
        public static readonly StringName SessionFailed = "session_failed";
        /// <summary>
        /// Cached name for the 'selectstart' signal.
        /// </summary>
        public static readonly StringName Selectstart = "selectstart";
        /// <summary>
        /// Cached name for the 'select' signal.
        /// </summary>
        public static readonly StringName Select = "select";
        /// <summary>
        /// Cached name for the 'selectend' signal.
        /// </summary>
        public static readonly StringName Selectend = "selectend";
        /// <summary>
        /// Cached name for the 'squeezestart' signal.
        /// </summary>
        public static readonly StringName Squeezestart = "squeezestart";
        /// <summary>
        /// Cached name for the 'squeeze' signal.
        /// </summary>
        public static readonly StringName Squeeze = "squeeze";
        /// <summary>
        /// Cached name for the 'squeezeend' signal.
        /// </summary>
        public static readonly StringName Squeezeend = "squeezeend";
        /// <summary>
        /// Cached name for the 'visibility_state_changed' signal.
        /// </summary>
        public static readonly StringName VisibilityStateChanged = "visibility_state_changed";
        /// <summary>
        /// Cached name for the 'reference_space_reset' signal.
        /// </summary>
        public static readonly StringName ReferenceSpaceReset = "reference_space_reset";
        /// <summary>
        /// Cached name for the 'display_refresh_rate_changed' signal.
        /// </summary>
        public static readonly StringName DisplayRefreshRateChanged = "display_refresh_rate_changed";
    }
}
