namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Controls camera-specific attributes such as depth of field and exposure override.</para>
/// <para>When used in a <see cref="Godot.WorldEnvironment"/> it provides default settings for exposure, auto-exposure, and depth of field that will be used by all cameras without their own <see cref="Godot.CameraAttributes"/>, including the editor camera. When used in a <see cref="Godot.Camera3D"/> it will override any <see cref="Godot.CameraAttributes"/> set in the <see cref="Godot.WorldEnvironment"/>. When used in <see cref="Godot.VoxelGI"/> or <see cref="Godot.LightmapGI"/>, only the exposure settings will be used.</para>
/// <para>See also <see cref="Godot.Environment"/> for general 3D environment settings.</para>
/// <para>This is a pure virtual class that is inherited by <see cref="Godot.CameraAttributesPhysical"/> and <see cref="Godot.CameraAttributesPractical"/>.</para>
/// </summary>
public partial class CameraAttributes : Resource
{
    /// <summary>
    /// <para>Sensitivity of camera sensors, measured in ISO. A higher sensitivity results in a brighter image.</para>
    /// <para>If <see cref="Godot.CameraAttributes.AutoExposureEnabled"/> is <see langword="true"/>, this can be used as a method of exposure compensation, doubling the value will increase the exposure value (measured in EV100) by 1 stop.</para>
    /// <para><b>Note:</b> Only available when <c>ProjectSettings.rendering/lights_and_shadows/use_physical_light_units</c> is enabled.</para>
    /// </summary>
    public float ExposureSensitivity
    {
        get
        {
            return GetExposureSensitivity();
        }
        set
        {
            SetExposureSensitivity(value);
        }
    }

    /// <summary>
    /// <para>Multiplier for the exposure amount. A higher value results in a brighter image.</para>
    /// </summary>
    public float ExposureMultiplier
    {
        get
        {
            return GetExposureMultiplier();
        }
        set
        {
            SetExposureMultiplier(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, enables the tonemapping auto exposure mode of the scene renderer. If <see langword="true"/>, the renderer will automatically determine the exposure setting to adapt to the scene's illumination and the observed light.</para>
    /// </summary>
    public bool AutoExposureEnabled
    {
        get
        {
            return IsAutoExposureEnabled();
        }
        set
        {
            SetAutoExposureEnabled(value);
        }
    }

    /// <summary>
    /// <para>The scale of the auto exposure effect. Affects the intensity of auto exposure.</para>
    /// </summary>
    public float AutoExposureScale
    {
        get
        {
            return GetAutoExposureScale();
        }
        set
        {
            SetAutoExposureScale(value);
        }
    }

    /// <summary>
    /// <para>The speed of the auto exposure effect. Affects the time needed for the camera to perform auto exposure.</para>
    /// </summary>
    public float AutoExposureSpeed
    {
        get
        {
            return GetAutoExposureSpeed();
        }
        set
        {
            SetAutoExposureSpeed(value);
        }
    }

    private static readonly System.Type CachedType = typeof(CameraAttributes);

    private static readonly StringName NativeName = "CameraAttributes";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public CameraAttributes() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal CameraAttributes(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal CameraAttributes(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetExposureMultiplier, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetExposureMultiplier(float multiplier)
    {
        NativeCalls.godot_icall_1_67(MethodBind0, GodotObject.GetPtr(this), multiplier);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetExposureMultiplier, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetExposureMultiplier()
    {
        return NativeCalls.godot_icall_0_68(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetExposureSensitivity, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetExposureSensitivity(float sensitivity)
    {
        NativeCalls.godot_icall_1_67(MethodBind2, GodotObject.GetPtr(this), sensitivity);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetExposureSensitivity, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetExposureSensitivity()
    {
        return NativeCalls.godot_icall_0_68(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAutoExposureEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAutoExposureEnabled(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind4, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsAutoExposureEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsAutoExposureEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind5, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAutoExposureSpeed, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAutoExposureSpeed(float exposureSpeed)
    {
        NativeCalls.godot_icall_1_67(MethodBind6, GodotObject.GetPtr(this), exposureSpeed);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAutoExposureSpeed, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetAutoExposureSpeed()
    {
        return NativeCalls.godot_icall_0_68(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAutoExposureScale, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAutoExposureScale(float exposureGrey)
    {
        NativeCalls.godot_icall_1_67(MethodBind8, GodotObject.GetPtr(this), exposureGrey);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAutoExposureScale, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetAutoExposureScale()
    {
        return NativeCalls.godot_icall_0_68(MethodBind9, GodotObject.GetPtr(this));
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
    public new class PropertyName : Resource.PropertyName
    {
        /// <summary>
        /// Cached name for the 'exposure_sensitivity' property.
        /// </summary>
        public static readonly StringName ExposureSensitivity = "exposure_sensitivity";
        /// <summary>
        /// Cached name for the 'exposure_multiplier' property.
        /// </summary>
        public static readonly StringName ExposureMultiplier = "exposure_multiplier";
        /// <summary>
        /// Cached name for the 'auto_exposure_enabled' property.
        /// </summary>
        public static readonly StringName AutoExposureEnabled = "auto_exposure_enabled";
        /// <summary>
        /// Cached name for the 'auto_exposure_scale' property.
        /// </summary>
        public static readonly StringName AutoExposureScale = "auto_exposure_scale";
        /// <summary>
        /// Cached name for the 'auto_exposure_speed' property.
        /// </summary>
        public static readonly StringName AutoExposureSpeed = "auto_exposure_speed";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Resource.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_exposure_multiplier' method.
        /// </summary>
        public static readonly StringName SetExposureMultiplier = "set_exposure_multiplier";
        /// <summary>
        /// Cached name for the 'get_exposure_multiplier' method.
        /// </summary>
        public static readonly StringName GetExposureMultiplier = "get_exposure_multiplier";
        /// <summary>
        /// Cached name for the 'set_exposure_sensitivity' method.
        /// </summary>
        public static readonly StringName SetExposureSensitivity = "set_exposure_sensitivity";
        /// <summary>
        /// Cached name for the 'get_exposure_sensitivity' method.
        /// </summary>
        public static readonly StringName GetExposureSensitivity = "get_exposure_sensitivity";
        /// <summary>
        /// Cached name for the 'set_auto_exposure_enabled' method.
        /// </summary>
        public static readonly StringName SetAutoExposureEnabled = "set_auto_exposure_enabled";
        /// <summary>
        /// Cached name for the 'is_auto_exposure_enabled' method.
        /// </summary>
        public static readonly StringName IsAutoExposureEnabled = "is_auto_exposure_enabled";
        /// <summary>
        /// Cached name for the 'set_auto_exposure_speed' method.
        /// </summary>
        public static readonly StringName SetAutoExposureSpeed = "set_auto_exposure_speed";
        /// <summary>
        /// Cached name for the 'get_auto_exposure_speed' method.
        /// </summary>
        public static readonly StringName GetAutoExposureSpeed = "get_auto_exposure_speed";
        /// <summary>
        /// Cached name for the 'set_auto_exposure_scale' method.
        /// </summary>
        public static readonly StringName SetAutoExposureScale = "set_auto_exposure_scale";
        /// <summary>
        /// Cached name for the 'get_auto_exposure_scale' method.
        /// </summary>
        public static readonly StringName GetAutoExposureScale = "get_auto_exposure_scale";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Resource.SignalName
    {
    }
}
