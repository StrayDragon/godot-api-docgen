namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para><see cref="Godot.CameraAttributesPhysical"/> is used to set rendering settings based on a physically-based camera's settings. It is responsible for exposure, auto-exposure, and depth of field.</para>
/// <para>When used in a <see cref="Godot.WorldEnvironment"/> it provides default settings for exposure, auto-exposure, and depth of field that will be used by all cameras without their own <see cref="Godot.CameraAttributes"/>, including the editor camera. When used in a <see cref="Godot.Camera3D"/> it will override any <see cref="Godot.CameraAttributes"/> set in the <see cref="Godot.WorldEnvironment"/> and will override the <see cref="Godot.Camera3D"/>s <see cref="Godot.Camera3D.Far"/>, <see cref="Godot.Camera3D.Near"/>, <see cref="Godot.Camera3D.Fov"/>, and <see cref="Godot.Camera3D.KeepAspect"/> properties. When used in <see cref="Godot.VoxelGI"/> or <see cref="Godot.LightmapGI"/>, only the exposure settings will be used.</para>
/// <para>The default settings are intended for use in an outdoor environment, tips for settings for use in an indoor environment can be found in each setting's documentation.</para>
/// <para><b>Note:</b> Depth of field blur is only supported in the Forward+ and Mobile rendering methods, not Compatibility.</para>
/// </summary>
public partial class CameraAttributesPhysical : CameraAttributes
{
    /// <summary>
    /// <para>Distance from camera of object that will be in focus, measured in meters. Internally this will be clamped to be at least 1 millimeter larger than <see cref="Godot.CameraAttributesPhysical.FrustumFocalLength"/>.</para>
    /// </summary>
    public float FrustumFocusDistance
    {
        get
        {
            return GetFocusDistance();
        }
        set
        {
            SetFocusDistance(value);
        }
    }

    /// <summary>
    /// <para>Distance between camera lens and camera aperture, measured in millimeters. Controls field of view and depth of field. A larger focal length will result in a smaller field of view and a narrower depth of field meaning fewer objects will be in focus. A smaller focal length will result in a wider field of view and a larger depth of field meaning more objects will be in focus. When attached to a <see cref="Godot.Camera3D"/> as its <see cref="Godot.Camera3D.Attributes"/>, it will override the <see cref="Godot.Camera3D.Fov"/> property and the <see cref="Godot.Camera3D.KeepAspect"/> property.</para>
    /// </summary>
    public float FrustumFocalLength
    {
        get
        {
            return GetFocalLength();
        }
        set
        {
            SetFocalLength(value);
        }
    }

    /// <summary>
    /// <para>Override value for <see cref="Godot.Camera3D.Near"/>. Used internally when calculating depth of field. When attached to a <see cref="Godot.Camera3D"/> as its <see cref="Godot.Camera3D.Attributes"/>, it will override the <see cref="Godot.Camera3D.Near"/> property.</para>
    /// </summary>
    public float FrustumNear
    {
        get
        {
            return GetNear();
        }
        set
        {
            SetNear(value);
        }
    }

    /// <summary>
    /// <para>Override value for <see cref="Godot.Camera3D.Far"/>. Used internally when calculating depth of field. When attached to a <see cref="Godot.Camera3D"/> as its <see cref="Godot.Camera3D.Attributes"/>, it will override the <see cref="Godot.Camera3D.Far"/> property.</para>
    /// </summary>
    public float FrustumFar
    {
        get
        {
            return GetFar();
        }
        set
        {
            SetFar(value);
        }
    }

    /// <summary>
    /// <para>Size of the aperture of the camera, measured in f-stops. An f-stop is a unitless ratio between the focal length of the camera and the diameter of the aperture. A high aperture setting will result in a smaller aperture which leads to a dimmer image and sharper focus. A low aperture results in a wide aperture which lets in more light resulting in a brighter, less-focused image. Default is appropriate for outdoors at daytime (i.e. for use with a default <see cref="Godot.DirectionalLight3D"/>), for indoor lighting, a value between 2 and 4 is more appropriate.</para>
    /// <para>Only available when <c>ProjectSettings.rendering/lights_and_shadows/use_physical_light_units</c> is enabled.</para>
    /// </summary>
    public float ExposureAperture
    {
        get
        {
            return GetAperture();
        }
        set
        {
            SetAperture(value);
        }
    }

    /// <summary>
    /// <para>Time for shutter to open and close, evaluated as <c>1 / shutter_speed</c> seconds. A higher value will allow less light (leading to a darker image), while a lower value will allow more light (leading to a brighter image).</para>
    /// <para>Only available when <c>ProjectSettings.rendering/lights_and_shadows/use_physical_light_units</c> is enabled.</para>
    /// </summary>
    public float ExposureShutterSpeed
    {
        get
        {
            return GetShutterSpeed();
        }
        set
        {
            SetShutterSpeed(value);
        }
    }

    /// <summary>
    /// <para>The minimum luminance (in EV100) used when calculating auto exposure. When calculating scene average luminance, color values will be clamped to at least this value. This limits the auto-exposure from exposing above a certain brightness, resulting in a cut off point where the scene will remain dark.</para>
    /// </summary>
    public float AutoExposureMinExposureValue
    {
        get
        {
            return GetAutoExposureMinExposureValue();
        }
        set
        {
            SetAutoExposureMinExposureValue(value);
        }
    }

    /// <summary>
    /// <para>The maximum luminance (in EV100) used when calculating auto exposure. When calculating scene average luminance, color values will be clamped to at least this value. This limits the auto-exposure from exposing below a certain brightness, resulting in a cut off point where the scene will remain bright.</para>
    /// </summary>
    public float AutoExposureMaxExposureValue
    {
        get
        {
            return GetAutoExposureMaxExposureValue();
        }
        set
        {
            SetAutoExposureMaxExposureValue(value);
        }
    }

    private static readonly System.Type CachedType = typeof(CameraAttributesPhysical);

    private static readonly StringName NativeName = "CameraAttributesPhysical";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public CameraAttributesPhysical() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal CameraAttributesPhysical(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal CameraAttributesPhysical(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAperture, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAperture(float aperture)
    {
        NativeCalls.godot_icall_1_67(MethodBind0, GodotObject.GetPtr(this), aperture);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAperture, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetAperture()
    {
        return NativeCalls.godot_icall_0_68(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetShutterSpeed, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetShutterSpeed(float shutterSpeed)
    {
        NativeCalls.godot_icall_1_67(MethodBind2, GodotObject.GetPtr(this), shutterSpeed);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetShutterSpeed, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetShutterSpeed()
    {
        return NativeCalls.godot_icall_0_68(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFocalLength, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFocalLength(float focalLength)
    {
        NativeCalls.godot_icall_1_67(MethodBind4, GodotObject.GetPtr(this), focalLength);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFocalLength, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetFocalLength()
    {
        return NativeCalls.godot_icall_0_68(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFocusDistance, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFocusDistance(float focusDistance)
    {
        NativeCalls.godot_icall_1_67(MethodBind6, GodotObject.GetPtr(this), focusDistance);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFocusDistance, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetFocusDistance()
    {
        return NativeCalls.godot_icall_0_68(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetNear, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetNear(float near)
    {
        NativeCalls.godot_icall_1_67(MethodBind8, GodotObject.GetPtr(this), near);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNear, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetNear()
    {
        return NativeCalls.godot_icall_0_68(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFar, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFar(float far)
    {
        NativeCalls.godot_icall_1_67(MethodBind10, GodotObject.GetPtr(this), far);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFar, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetFar()
    {
        return NativeCalls.godot_icall_0_68(MethodBind11, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFov, 1740695150ul);

    /// <summary>
    /// <para>Returns the vertical field of view that corresponds to the <see cref="Godot.CameraAttributesPhysical.FrustumFocalLength"/>. This value is calculated internally whenever <see cref="Godot.CameraAttributesPhysical.FrustumFocalLength"/> is changed.</para>
    /// </summary>
    public float GetFov()
    {
        return NativeCalls.godot_icall_0_68(MethodBind12, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAutoExposureMaxExposureValue, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAutoExposureMaxExposureValue(float exposureValueMax)
    {
        NativeCalls.godot_icall_1_67(MethodBind13, GodotObject.GetPtr(this), exposureValueMax);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAutoExposureMaxExposureValue, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetAutoExposureMaxExposureValue()
    {
        return NativeCalls.godot_icall_0_68(MethodBind14, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAutoExposureMinExposureValue, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAutoExposureMinExposureValue(float exposureValueMin)
    {
        NativeCalls.godot_icall_1_67(MethodBind15, GodotObject.GetPtr(this), exposureValueMin);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAutoExposureMinExposureValue, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetAutoExposureMinExposureValue()
    {
        return NativeCalls.godot_icall_0_68(MethodBind16, GodotObject.GetPtr(this));
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
    public new class PropertyName : CameraAttributes.PropertyName
    {
        /// <summary>
        /// Cached name for the 'frustum_focus_distance' property.
        /// </summary>
        public static readonly StringName FrustumFocusDistance = "frustum_focus_distance";
        /// <summary>
        /// Cached name for the 'frustum_focal_length' property.
        /// </summary>
        public static readonly StringName FrustumFocalLength = "frustum_focal_length";
        /// <summary>
        /// Cached name for the 'frustum_near' property.
        /// </summary>
        public static readonly StringName FrustumNear = "frustum_near";
        /// <summary>
        /// Cached name for the 'frustum_far' property.
        /// </summary>
        public static readonly StringName FrustumFar = "frustum_far";
        /// <summary>
        /// Cached name for the 'exposure_aperture' property.
        /// </summary>
        public static readonly StringName ExposureAperture = "exposure_aperture";
        /// <summary>
        /// Cached name for the 'exposure_shutter_speed' property.
        /// </summary>
        public static readonly StringName ExposureShutterSpeed = "exposure_shutter_speed";
        /// <summary>
        /// Cached name for the 'auto_exposure_min_exposure_value' property.
        /// </summary>
        public static readonly StringName AutoExposureMinExposureValue = "auto_exposure_min_exposure_value";
        /// <summary>
        /// Cached name for the 'auto_exposure_max_exposure_value' property.
        /// </summary>
        public static readonly StringName AutoExposureMaxExposureValue = "auto_exposure_max_exposure_value";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : CameraAttributes.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_aperture' method.
        /// </summary>
        public static readonly StringName SetAperture = "set_aperture";
        /// <summary>
        /// Cached name for the 'get_aperture' method.
        /// </summary>
        public static readonly StringName GetAperture = "get_aperture";
        /// <summary>
        /// Cached name for the 'set_shutter_speed' method.
        /// </summary>
        public static readonly StringName SetShutterSpeed = "set_shutter_speed";
        /// <summary>
        /// Cached name for the 'get_shutter_speed' method.
        /// </summary>
        public static readonly StringName GetShutterSpeed = "get_shutter_speed";
        /// <summary>
        /// Cached name for the 'set_focal_length' method.
        /// </summary>
        public static readonly StringName SetFocalLength = "set_focal_length";
        /// <summary>
        /// Cached name for the 'get_focal_length' method.
        /// </summary>
        public static readonly StringName GetFocalLength = "get_focal_length";
        /// <summary>
        /// Cached name for the 'set_focus_distance' method.
        /// </summary>
        public static readonly StringName SetFocusDistance = "set_focus_distance";
        /// <summary>
        /// Cached name for the 'get_focus_distance' method.
        /// </summary>
        public static readonly StringName GetFocusDistance = "get_focus_distance";
        /// <summary>
        /// Cached name for the 'set_near' method.
        /// </summary>
        public static readonly StringName SetNear = "set_near";
        /// <summary>
        /// Cached name for the 'get_near' method.
        /// </summary>
        public static readonly StringName GetNear = "get_near";
        /// <summary>
        /// Cached name for the 'set_far' method.
        /// </summary>
        public static readonly StringName SetFar = "set_far";
        /// <summary>
        /// Cached name for the 'get_far' method.
        /// </summary>
        public static readonly StringName GetFar = "get_far";
        /// <summary>
        /// Cached name for the 'get_fov' method.
        /// </summary>
        public static readonly StringName GetFov = "get_fov";
        /// <summary>
        /// Cached name for the 'set_auto_exposure_max_exposure_value' method.
        /// </summary>
        public static readonly StringName SetAutoExposureMaxExposureValue = "set_auto_exposure_max_exposure_value";
        /// <summary>
        /// Cached name for the 'get_auto_exposure_max_exposure_value' method.
        /// </summary>
        public static readonly StringName GetAutoExposureMaxExposureValue = "get_auto_exposure_max_exposure_value";
        /// <summary>
        /// Cached name for the 'set_auto_exposure_min_exposure_value' method.
        /// </summary>
        public static readonly StringName SetAutoExposureMinExposureValue = "set_auto_exposure_min_exposure_value";
        /// <summary>
        /// Cached name for the 'get_auto_exposure_min_exposure_value' method.
        /// </summary>
        public static readonly StringName GetAutoExposureMinExposureValue = "get_auto_exposure_min_exposure_value";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : CameraAttributes.SignalName
    {
    }
}
