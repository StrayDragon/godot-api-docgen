namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>External XR interface plugins should inherit from this class.</para>
/// </summary>
public partial class XRInterfaceExtension : XRInterface
{
    private static readonly System.Type CachedType = typeof(XRInterfaceExtension);

    private static readonly StringName NativeName = "XRInterfaceExtension";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public XRInterfaceExtension() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal XRInterfaceExtension(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal XRInterfaceExtension(bool memoryOwn) : base(memoryOwn) { }

    /// <summary>
    /// <para>Called if interface is active and queues have been submitted.</para>
    /// </summary>
    public virtual void _EndFrame()
    {
    }

    /// <summary>
    /// <para>Return <see langword="true"/> if anchor detection is enabled for this interface.</para>
    /// </summary>
    public virtual bool _GetAnchorDetectionIsEnabled()
    {
        return default;
    }

    /// <summary>
    /// <para>Returns the camera feed ID for the <see cref="Godot.CameraFeed"/> registered with the <see cref="Godot.CameraServer"/> that should be presented as the background on an AR capable device (if applicable).</para>
    /// </summary>
    public virtual int _GetCameraFeedId()
    {
        return default;
    }

    /// <summary>
    /// <para>Returns the <see cref="Godot.Transform3D"/> that positions the <see cref="Godot.XRCamera3D"/> in the world.</para>
    /// </summary>
    public virtual Transform3D _GetCameraTransform()
    {
        return default;
    }

    /// <summary>
    /// <para>Returns the capabilities of this interface.</para>
    /// </summary>
    public virtual uint _GetCapabilities()
    {
        return default;
    }

    /// <summary>
    /// <para>Return color texture into which to render (if applicable).</para>
    /// </summary>
    public virtual Rid _GetColorTexture()
    {
        return default;
    }

    /// <summary>
    /// <para>Return depth texture into which to render (if applicable).</para>
    /// </summary>
    public virtual Rid _GetDepthTexture()
    {
        return default;
    }

    /// <summary>
    /// <para>Returns the name of this interface.</para>
    /// </summary>
    public virtual StringName _GetName()
    {
        return default;
    }

    /// <summary>
    /// <para>Returns a <see cref="Godot.Vector3"/>[] that represents the play areas boundaries (if applicable).</para>
    /// </summary>
    public virtual Vector3[] _GetPlayArea()
    {
        return default;
    }

    /// <summary>
    /// <para>Returns the play area mode that sets up our play area.</para>
    /// </summary>
    public virtual XRInterface.PlayAreaMode _GetPlayAreaMode()
    {
        return default;
    }

    /// <summary>
    /// <para>Returns the projection matrix for the given view as a <see cref="double"/>[].</para>
    /// </summary>
    public virtual double[] _GetProjectionForView(uint view, double aspect, double zNear, double zFar)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns the size of our render target for this interface, this overrides the size of the <see cref="Godot.Viewport"/> marked as the xr viewport.</para>
    /// </summary>
    public virtual Vector2 _GetRenderTargetSize()
    {
        return default;
    }

    /// <summary>
    /// <para>Returns a <see cref="string"/>[] with pose names configured by this interface. Note that user configuration can override this list.</para>
    /// </summary>
    public virtual string[] _GetSuggestedPoseNames(StringName trackerName)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns a <see cref="string"/>[] with tracker names configured by this interface. Note that user configuration can override this list.</para>
    /// </summary>
    public virtual string[] _GetSuggestedTrackerNames()
    {
        return default;
    }

    /// <summary>
    /// <para>Returns a <see cref="Godot.Collections.Dictionary"/> with system information related to this interface.</para>
    /// </summary>
    public virtual Godot.Collections.Dictionary _GetSystemInfo()
    {
        return default;
    }

    /// <summary>
    /// <para>Returns the current status of our tracking.</para>
    /// </summary>
    public virtual XRInterface.TrackingStatus _GetTrackingStatus()
    {
        return default;
    }

    /// <summary>
    /// <para>Returns a <see cref="Godot.Transform3D"/> for a given view.</para>
    /// </summary>
    public virtual unsafe Transform3D _GetTransformForView(uint view, Transform3D camTransform)
    {
        return default;
    }

    /// <summary>
    /// <para>Return velocity texture into which to render (if applicable).</para>
    /// </summary>
    public virtual Rid _GetVelocityTexture()
    {
        return default;
    }

    /// <summary>
    /// <para>Returns the number of views this interface requires, 1 for mono, 2 for stereoscopic.</para>
    /// </summary>
    public virtual uint _GetViewCount()
    {
        return default;
    }

    public virtual Rid _GetVrsTexture()
    {
        return default;
    }

    /// <summary>
    /// <para>Returns the format of the texture returned by <see cref="Godot.XRInterfaceExtension._GetVrsTexture()"/>.</para>
    /// </summary>
    public virtual XRInterface.VrsTextureFormat _GetVrsTextureFormat()
    {
        return default;
    }

    /// <summary>
    /// <para>Initializes the interface, returns <see langword="true"/> on success.</para>
    /// </summary>
    public virtual bool _Initialize()
    {
        return default;
    }

    /// <summary>
    /// <para>Returns <see langword="true"/> if this interface has been initialized.</para>
    /// </summary>
    public virtual bool _IsInitialized()
    {
        return default;
    }

    /// <summary>
    /// <para>Called after the XR <see cref="Godot.Viewport"/> draw logic has completed.</para>
    /// </summary>
    public virtual unsafe void _PostDrawViewport(Rid renderTarget, Rect2 screenRect)
    {
    }

    /// <summary>
    /// <para>Called if this is our primary <see cref="Godot.XRInterfaceExtension"/> before we start processing a <see cref="Godot.Viewport"/> for every active XR <see cref="Godot.Viewport"/>, returns <see langword="true"/> if that viewport should be rendered. An XR interface may return <see langword="false"/> if the user has taken off their headset and we can pause rendering.</para>
    /// </summary>
    public virtual bool _PreDrawViewport(Rid renderTarget)
    {
        return default;
    }

    /// <summary>
    /// <para>Called if this <see cref="Godot.XRInterfaceExtension"/> is active before rendering starts. Most XR interfaces will sync tracking at this point in time.</para>
    /// </summary>
    public virtual void _PreRender()
    {
    }

    /// <summary>
    /// <para>Called if this <see cref="Godot.XRInterfaceExtension"/> is active before our physics and game process is called. Most XR interfaces will update its <see cref="Godot.XRPositionalTracker"/>s at this point in time.</para>
    /// </summary>
    public virtual void _Process()
    {
    }

    /// <summary>
    /// <para>Enables anchor detection on this interface if supported.</para>
    /// </summary>
    public virtual void _SetAnchorDetectionIsEnabled(bool enabled)
    {
    }

    /// <summary>
    /// <para>Set the play area mode for this interface.</para>
    /// </summary>
    public virtual bool _SetPlayAreaMode(XRInterface.PlayAreaMode mode)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns <see langword="true"/> if this interface supports this play area mode.</para>
    /// </summary>
    public virtual bool _SupportsPlayAreaMode(XRInterface.PlayAreaMode mode)
    {
        return default;
    }

    /// <summary>
    /// <para>Triggers a haptic pulse to be emitted on the specified tracker.</para>
    /// </summary>
    public virtual void _TriggerHapticPulse(string actionName, StringName trackerName, double frequency, double amplitude, double durationSec, double delaySec)
    {
    }

    /// <summary>
    /// <para>Uninitialize the interface.</para>
    /// </summary>
    public virtual void _Uninitialize()
    {
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetColorTexture, 529393457ul);

    public Rid GetColorTexture()
    {
        return NativeCalls.godot_icall_0_238(MethodBind0, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDepthTexture, 529393457ul);

    public Rid GetDepthTexture()
    {
        return NativeCalls.godot_icall_0_238(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVelocityTexture, 529393457ul);

    public Rid GetVelocityTexture()
    {
        return NativeCalls.godot_icall_0_238(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddBlit, 258596971ul);

    /// <summary>
    /// <para>Blits our render results to screen optionally applying lens distortion. This can only be called while processing <c>_commit_views</c>.</para>
    /// </summary>
    public unsafe void AddBlit(Rid renderTarget, Rect2 srcRect, Rect2I dstRect, bool useLayer, uint layer, bool applyLensDistortion, Vector2 eyeCenter, double k1, double k2, double upscale, double aspectRatio)
    {
        NativeCalls.godot_icall_11_1513(MethodBind3, GodotObject.GetPtr(this), renderTarget, &srcRect, &dstRect, useLayer.ToGodotBool(), layer, applyLensDistortion.ToGodotBool(), &eyeCenter, k1, k2, upscale, aspectRatio);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRenderTargetTexture, 41030802ul);

    /// <summary>
    /// <para>Returns a valid <see cref="Godot.Rid"/> for a texture to which we should render the current frame if supported by the interface.</para>
    /// </summary>
    public Rid GetRenderTargetTexture(Rid renderTarget)
    {
        return NativeCalls.godot_icall_1_855(MethodBind4, GodotObject.GetPtr(this), renderTarget);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__end_frame = "_EndFrame";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_anchor_detection_is_enabled = "_GetAnchorDetectionIsEnabled";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_camera_feed_id = "_GetCameraFeedId";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_camera_transform = "_GetCameraTransform";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_capabilities = "_GetCapabilities";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_color_texture = "_GetColorTexture";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_depth_texture = "_GetDepthTexture";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_name = "_GetName";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_play_area = "_GetPlayArea";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_play_area_mode = "_GetPlayAreaMode";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_projection_for_view = "_GetProjectionForView";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_render_target_size = "_GetRenderTargetSize";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_suggested_pose_names = "_GetSuggestedPoseNames";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_suggested_tracker_names = "_GetSuggestedTrackerNames";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_system_info = "_GetSystemInfo";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_tracking_status = "_GetTrackingStatus";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_transform_for_view = "_GetTransformForView";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_velocity_texture = "_GetVelocityTexture";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_view_count = "_GetViewCount";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_vrs_texture = "_GetVrsTexture";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_vrs_texture_format = "_GetVrsTextureFormat";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__initialize = "_Initialize";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__is_initialized = "_IsInitialized";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__post_draw_viewport = "_PostDrawViewport";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__pre_draw_viewport = "_PreDrawViewport";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__pre_render = "_PreRender";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__process = "_Process";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__set_anchor_detection_is_enabled = "_SetAnchorDetectionIsEnabled";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__set_play_area_mode = "_SetPlayAreaMode";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__supports_play_area_mode = "_SupportsPlayAreaMode";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__trigger_haptic_pulse = "_TriggerHapticPulse";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__uninitialize = "_Uninitialize";

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
        if ((method == MethodProxyName__end_frame || method == MethodName._EndFrame) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__end_frame.NativeValue))
        {
            _EndFrame();
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__get_anchor_detection_is_enabled || method == MethodName._GetAnchorDetectionIsEnabled) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_anchor_detection_is_enabled.NativeValue))
        {
            var callRet = _GetAnchorDetectionIsEnabled();
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_camera_feed_id || method == MethodName._GetCameraFeedId) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_camera_feed_id.NativeValue))
        {
            var callRet = _GetCameraFeedId();
            ret = VariantUtils.CreateFrom<int>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_camera_transform || method == MethodName._GetCameraTransform) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_camera_transform.NativeValue))
        {
            var callRet = _GetCameraTransform();
            ret = VariantUtils.CreateFrom<Transform3D>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_capabilities || method == MethodName._GetCapabilities) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_capabilities.NativeValue))
        {
            var callRet = _GetCapabilities();
            ret = VariantUtils.CreateFrom<uint>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_color_texture || method == MethodName._GetColorTexture) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_color_texture.NativeValue))
        {
            var callRet = _GetColorTexture();
            ret = VariantUtils.CreateFrom<Rid>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_depth_texture || method == MethodName._GetDepthTexture) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_depth_texture.NativeValue))
        {
            var callRet = _GetDepthTexture();
            ret = VariantUtils.CreateFrom<Rid>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_name || method == MethodName._GetName) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_name.NativeValue))
        {
            var callRet = _GetName();
            ret = VariantUtils.CreateFrom<StringName>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_play_area || method == MethodName._GetPlayArea) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_play_area.NativeValue))
        {
            var callRet = _GetPlayArea();
            ret = VariantUtils.CreateFrom<Vector3[]>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_play_area_mode || method == MethodName._GetPlayAreaMode) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_play_area_mode.NativeValue))
        {
            var callRet = _GetPlayAreaMode();
            ret = VariantUtils.CreateFrom<XRInterface.PlayAreaMode>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_projection_for_view || method == MethodName._GetProjectionForView) && args.Count == 4 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_projection_for_view.NativeValue))
        {
            var callRet = _GetProjectionForView(VariantUtils.ConvertTo<uint>(args[0]), VariantUtils.ConvertTo<double>(args[1]), VariantUtils.ConvertTo<double>(args[2]), VariantUtils.ConvertTo<double>(args[3]));
            ret = VariantUtils.CreateFrom<double[]>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_render_target_size || method == MethodName._GetRenderTargetSize) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_render_target_size.NativeValue))
        {
            var callRet = _GetRenderTargetSize();
            ret = VariantUtils.CreateFrom<Vector2>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_suggested_pose_names || method == MethodName._GetSuggestedPoseNames) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_suggested_pose_names.NativeValue))
        {
            var callRet = _GetSuggestedPoseNames(VariantUtils.ConvertTo<StringName>(args[0]));
            ret = VariantUtils.CreateFrom<string[]>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_suggested_tracker_names || method == MethodName._GetSuggestedTrackerNames) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_suggested_tracker_names.NativeValue))
        {
            var callRet = _GetSuggestedTrackerNames();
            ret = VariantUtils.CreateFrom<string[]>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_system_info || method == MethodName._GetSystemInfo) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_system_info.NativeValue))
        {
            var callRet = _GetSystemInfo();
            ret = VariantUtils.CreateFrom<Godot.Collections.Dictionary>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_tracking_status || method == MethodName._GetTrackingStatus) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_tracking_status.NativeValue))
        {
            var callRet = _GetTrackingStatus();
            ret = VariantUtils.CreateFrom<XRInterface.TrackingStatus>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_transform_for_view || method == MethodName._GetTransformForView) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_transform_for_view.NativeValue))
        {
            var callRet = _GetTransformForView(VariantUtils.ConvertTo<uint>(args[0]), VariantUtils.ConvertTo<Transform3D>(args[1]));
            ret = VariantUtils.CreateFrom<Transform3D>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_velocity_texture || method == MethodName._GetVelocityTexture) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_velocity_texture.NativeValue))
        {
            var callRet = _GetVelocityTexture();
            ret = VariantUtils.CreateFrom<Rid>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_view_count || method == MethodName._GetViewCount) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_view_count.NativeValue))
        {
            var callRet = _GetViewCount();
            ret = VariantUtils.CreateFrom<uint>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_vrs_texture || method == MethodName._GetVrsTexture) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_vrs_texture.NativeValue))
        {
            var callRet = _GetVrsTexture();
            ret = VariantUtils.CreateFrom<Rid>(callRet);
            return true;
        }
        if ((method == MethodProxyName__get_vrs_texture_format || method == MethodName._GetVrsTextureFormat) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_vrs_texture_format.NativeValue))
        {
            var callRet = _GetVrsTextureFormat();
            ret = VariantUtils.CreateFrom<XRInterface.VrsTextureFormat>(callRet);
            return true;
        }
        if ((method == MethodProxyName__initialize || method == MethodName._Initialize) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__initialize.NativeValue))
        {
            var callRet = _Initialize();
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__is_initialized || method == MethodName._IsInitialized) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__is_initialized.NativeValue))
        {
            var callRet = _IsInitialized();
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__post_draw_viewport || method == MethodName._PostDrawViewport) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__post_draw_viewport.NativeValue))
        {
            _PostDrawViewport(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<Rect2>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__pre_draw_viewport || method == MethodName._PreDrawViewport) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__pre_draw_viewport.NativeValue))
        {
            var callRet = _PreDrawViewport(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__pre_render || method == MethodName._PreRender) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__pre_render.NativeValue))
        {
            _PreRender();
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__process || method == MethodName._Process) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__process.NativeValue))
        {
            _Process();
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__set_anchor_detection_is_enabled || method == MethodName._SetAnchorDetectionIsEnabled) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__set_anchor_detection_is_enabled.NativeValue))
        {
            _SetAnchorDetectionIsEnabled(VariantUtils.ConvertTo<bool>(args[0]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__set_play_area_mode || method == MethodName._SetPlayAreaMode) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__set_play_area_mode.NativeValue))
        {
            var callRet = _SetPlayAreaMode(VariantUtils.ConvertTo<XRInterface.PlayAreaMode>(args[0]));
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__supports_play_area_mode || method == MethodName._SupportsPlayAreaMode) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__supports_play_area_mode.NativeValue))
        {
            var callRet = _SupportsPlayAreaMode(VariantUtils.ConvertTo<XRInterface.PlayAreaMode>(args[0]));
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__trigger_haptic_pulse || method == MethodName._TriggerHapticPulse) && args.Count == 6 && HasGodotClassMethod((godot_string_name)MethodProxyName__trigger_haptic_pulse.NativeValue))
        {
            _TriggerHapticPulse(VariantUtils.ConvertTo<string>(args[0]), VariantUtils.ConvertTo<StringName>(args[1]), VariantUtils.ConvertTo<double>(args[2]), VariantUtils.ConvertTo<double>(args[3]), VariantUtils.ConvertTo<double>(args[4]), VariantUtils.ConvertTo<double>(args[5]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__uninitialize || method == MethodName._Uninitialize) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__uninitialize.NativeValue))
        {
            _Uninitialize();
            ret = default;
            return true;
        }
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
        if (method == MethodName._EndFrame)
        {
            if (HasGodotClassMethod(MethodProxyName__end_frame.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetAnchorDetectionIsEnabled)
        {
            if (HasGodotClassMethod(MethodProxyName__get_anchor_detection_is_enabled.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetCameraFeedId)
        {
            if (HasGodotClassMethod(MethodProxyName__get_camera_feed_id.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetCameraTransform)
        {
            if (HasGodotClassMethod(MethodProxyName__get_camera_transform.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetCapabilities)
        {
            if (HasGodotClassMethod(MethodProxyName__get_capabilities.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetColorTexture)
        {
            if (HasGodotClassMethod(MethodProxyName__get_color_texture.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetDepthTexture)
        {
            if (HasGodotClassMethod(MethodProxyName__get_depth_texture.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetName)
        {
            if (HasGodotClassMethod(MethodProxyName__get_name.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetPlayArea)
        {
            if (HasGodotClassMethod(MethodProxyName__get_play_area.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetPlayAreaMode)
        {
            if (HasGodotClassMethod(MethodProxyName__get_play_area_mode.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetProjectionForView)
        {
            if (HasGodotClassMethod(MethodProxyName__get_projection_for_view.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetRenderTargetSize)
        {
            if (HasGodotClassMethod(MethodProxyName__get_render_target_size.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetSuggestedPoseNames)
        {
            if (HasGodotClassMethod(MethodProxyName__get_suggested_pose_names.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetSuggestedTrackerNames)
        {
            if (HasGodotClassMethod(MethodProxyName__get_suggested_tracker_names.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetSystemInfo)
        {
            if (HasGodotClassMethod(MethodProxyName__get_system_info.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetTrackingStatus)
        {
            if (HasGodotClassMethod(MethodProxyName__get_tracking_status.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetTransformForView)
        {
            if (HasGodotClassMethod(MethodProxyName__get_transform_for_view.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetVelocityTexture)
        {
            if (HasGodotClassMethod(MethodProxyName__get_velocity_texture.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetViewCount)
        {
            if (HasGodotClassMethod(MethodProxyName__get_view_count.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetVrsTexture)
        {
            if (HasGodotClassMethod(MethodProxyName__get_vrs_texture.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetVrsTextureFormat)
        {
            if (HasGodotClassMethod(MethodProxyName__get_vrs_texture_format.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._Initialize)
        {
            if (HasGodotClassMethod(MethodProxyName__initialize.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._IsInitialized)
        {
            if (HasGodotClassMethod(MethodProxyName__is_initialized.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._PostDrawViewport)
        {
            if (HasGodotClassMethod(MethodProxyName__post_draw_viewport.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._PreDrawViewport)
        {
            if (HasGodotClassMethod(MethodProxyName__pre_draw_viewport.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._PreRender)
        {
            if (HasGodotClassMethod(MethodProxyName__pre_render.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._Process)
        {
            if (HasGodotClassMethod(MethodProxyName__process.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._SetAnchorDetectionIsEnabled)
        {
            if (HasGodotClassMethod(MethodProxyName__set_anchor_detection_is_enabled.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._SetPlayAreaMode)
        {
            if (HasGodotClassMethod(MethodProxyName__set_play_area_mode.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._SupportsPlayAreaMode)
        {
            if (HasGodotClassMethod(MethodProxyName__supports_play_area_mode.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._TriggerHapticPulse)
        {
            if (HasGodotClassMethod(MethodProxyName__trigger_haptic_pulse.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._Uninitialize)
        {
            if (HasGodotClassMethod(MethodProxyName__uninitialize.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
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
    public new class PropertyName : XRInterface.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : XRInterface.MethodName
    {
        /// <summary>
        /// Cached name for the '_end_frame' method.
        /// </summary>
        public static readonly StringName _EndFrame = "_end_frame";
        /// <summary>
        /// Cached name for the '_get_anchor_detection_is_enabled' method.
        /// </summary>
        public static readonly StringName _GetAnchorDetectionIsEnabled = "_get_anchor_detection_is_enabled";
        /// <summary>
        /// Cached name for the '_get_camera_feed_id' method.
        /// </summary>
        public static readonly StringName _GetCameraFeedId = "_get_camera_feed_id";
        /// <summary>
        /// Cached name for the '_get_camera_transform' method.
        /// </summary>
        public static readonly StringName _GetCameraTransform = "_get_camera_transform";
        /// <summary>
        /// Cached name for the '_get_capabilities' method.
        /// </summary>
        public static readonly StringName _GetCapabilities = "_get_capabilities";
        /// <summary>
        /// Cached name for the '_get_color_texture' method.
        /// </summary>
        public static readonly StringName _GetColorTexture = "_get_color_texture";
        /// <summary>
        /// Cached name for the '_get_depth_texture' method.
        /// </summary>
        public static readonly StringName _GetDepthTexture = "_get_depth_texture";
        /// <summary>
        /// Cached name for the '_get_name' method.
        /// </summary>
        public static readonly StringName _GetName = "_get_name";
        /// <summary>
        /// Cached name for the '_get_play_area' method.
        /// </summary>
        public static readonly StringName _GetPlayArea = "_get_play_area";
        /// <summary>
        /// Cached name for the '_get_play_area_mode' method.
        /// </summary>
        public static readonly StringName _GetPlayAreaMode = "_get_play_area_mode";
        /// <summary>
        /// Cached name for the '_get_projection_for_view' method.
        /// </summary>
        public static readonly StringName _GetProjectionForView = "_get_projection_for_view";
        /// <summary>
        /// Cached name for the '_get_render_target_size' method.
        /// </summary>
        public static readonly StringName _GetRenderTargetSize = "_get_render_target_size";
        /// <summary>
        /// Cached name for the '_get_suggested_pose_names' method.
        /// </summary>
        public static readonly StringName _GetSuggestedPoseNames = "_get_suggested_pose_names";
        /// <summary>
        /// Cached name for the '_get_suggested_tracker_names' method.
        /// </summary>
        public static readonly StringName _GetSuggestedTrackerNames = "_get_suggested_tracker_names";
        /// <summary>
        /// Cached name for the '_get_system_info' method.
        /// </summary>
        public static readonly StringName _GetSystemInfo = "_get_system_info";
        /// <summary>
        /// Cached name for the '_get_tracking_status' method.
        /// </summary>
        public static readonly StringName _GetTrackingStatus = "_get_tracking_status";
        /// <summary>
        /// Cached name for the '_get_transform_for_view' method.
        /// </summary>
        public static readonly StringName _GetTransformForView = "_get_transform_for_view";
        /// <summary>
        /// Cached name for the '_get_velocity_texture' method.
        /// </summary>
        public static readonly StringName _GetVelocityTexture = "_get_velocity_texture";
        /// <summary>
        /// Cached name for the '_get_view_count' method.
        /// </summary>
        public static readonly StringName _GetViewCount = "_get_view_count";
        /// <summary>
        /// Cached name for the '_get_vrs_texture' method.
        /// </summary>
        public static readonly StringName _GetVrsTexture = "_get_vrs_texture";
        /// <summary>
        /// Cached name for the '_get_vrs_texture_format' method.
        /// </summary>
        public static readonly StringName _GetVrsTextureFormat = "_get_vrs_texture_format";
        /// <summary>
        /// Cached name for the '_initialize' method.
        /// </summary>
        public static readonly StringName _Initialize = "_initialize";
        /// <summary>
        /// Cached name for the '_is_initialized' method.
        /// </summary>
        public static readonly StringName _IsInitialized = "_is_initialized";
        /// <summary>
        /// Cached name for the '_post_draw_viewport' method.
        /// </summary>
        public static readonly StringName _PostDrawViewport = "_post_draw_viewport";
        /// <summary>
        /// Cached name for the '_pre_draw_viewport' method.
        /// </summary>
        public static readonly StringName _PreDrawViewport = "_pre_draw_viewport";
        /// <summary>
        /// Cached name for the '_pre_render' method.
        /// </summary>
        public static readonly StringName _PreRender = "_pre_render";
        /// <summary>
        /// Cached name for the '_process' method.
        /// </summary>
        public static readonly StringName _Process = "_process";
        /// <summary>
        /// Cached name for the '_set_anchor_detection_is_enabled' method.
        /// </summary>
        public static readonly StringName _SetAnchorDetectionIsEnabled = "_set_anchor_detection_is_enabled";
        /// <summary>
        /// Cached name for the '_set_play_area_mode' method.
        /// </summary>
        public static readonly StringName _SetPlayAreaMode = "_set_play_area_mode";
        /// <summary>
        /// Cached name for the '_supports_play_area_mode' method.
        /// </summary>
        public static readonly StringName _SupportsPlayAreaMode = "_supports_play_area_mode";
        /// <summary>
        /// Cached name for the '_trigger_haptic_pulse' method.
        /// </summary>
        public static readonly StringName _TriggerHapticPulse = "_trigger_haptic_pulse";
        /// <summary>
        /// Cached name for the '_uninitialize' method.
        /// </summary>
        public static readonly StringName _Uninitialize = "_uninitialize";
        /// <summary>
        /// Cached name for the 'get_color_texture' method.
        /// </summary>
        public static readonly StringName GetColorTexture = "get_color_texture";
        /// <summary>
        /// Cached name for the 'get_depth_texture' method.
        /// </summary>
        public static readonly StringName GetDepthTexture = "get_depth_texture";
        /// <summary>
        /// Cached name for the 'get_velocity_texture' method.
        /// </summary>
        public static readonly StringName GetVelocityTexture = "get_velocity_texture";
        /// <summary>
        /// Cached name for the 'add_blit' method.
        /// </summary>
        public static readonly StringName AddBlit = "add_blit";
        /// <summary>
        /// Cached name for the 'get_render_target_texture' method.
        /// </summary>
        public static readonly StringName GetRenderTargetTexture = "get_render_target_texture";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : XRInterface.SignalName
    {
    }
}
