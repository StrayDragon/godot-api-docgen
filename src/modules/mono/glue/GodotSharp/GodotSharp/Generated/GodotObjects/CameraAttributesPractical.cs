namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Controls camera-specific attributes such as auto-exposure, depth of field, and exposure override.</para>
/// <para>When used in a <see cref="Godot.WorldEnvironment"/> it provides default settings for exposure, auto-exposure, and depth of field that will be used by all cameras without their own <see cref="Godot.CameraAttributes"/>, including the editor camera. When used in a <see cref="Godot.Camera3D"/> it will override any <see cref="Godot.CameraAttributes"/> set in the <see cref="Godot.WorldEnvironment"/>. When used in <see cref="Godot.VoxelGI"/> or <see cref="Godot.LightmapGI"/>, only the exposure settings will be used.</para>
/// </summary>
public partial class CameraAttributesPractical : CameraAttributes
{
    /// <summary>
    /// <para>Enables depth of field blur for objects further than <see cref="Godot.CameraAttributesPractical.DofBlurFarDistance"/>. Strength of blur is controlled by <see cref="Godot.CameraAttributesPractical.DofBlurAmount"/> and modulated by <see cref="Godot.CameraAttributesPractical.DofBlurFarTransition"/>.</para>
    /// <para><b>Note:</b> Depth of field blur is only supported in the Forward+ and Mobile rendering methods, not Compatibility.</para>
    /// <para><b>Note:</b> Depth of field blur is not supported on viewports that have a transparent background (where <see cref="Godot.Viewport.TransparentBg"/> is <see langword="true"/>).</para>
    /// </summary>
    public bool DofBlurFarEnabled
    {
        get
        {
            return IsDofBlurFarEnabled();
        }
        set
        {
            SetDofBlurFarEnabled(value);
        }
    }

    /// <summary>
    /// <para>Objects further from the <see cref="Godot.Camera3D"/> by this amount will be blurred by the depth of field effect. Measured in meters.</para>
    /// </summary>
    public float DofBlurFarDistance
    {
        get
        {
            return GetDofBlurFarDistance();
        }
        set
        {
            SetDofBlurFarDistance(value);
        }
    }

    /// <summary>
    /// <para>When positive, distance over which (starting from <see cref="Godot.CameraAttributesPractical.DofBlurFarDistance"/>) blur effect will scale from 0 to <see cref="Godot.CameraAttributesPractical.DofBlurAmount"/>. When negative, uses physically-based scaling so depth of field effect will scale from 0 at <see cref="Godot.CameraAttributesPractical.DofBlurFarDistance"/> and will increase in a physically accurate way as objects get further from the <see cref="Godot.Camera3D"/>.</para>
    /// </summary>
    public float DofBlurFarTransition
    {
        get
        {
            return GetDofBlurFarTransition();
        }
        set
        {
            SetDofBlurFarTransition(value);
        }
    }

    /// <summary>
    /// <para>Enables depth of field blur for objects closer than <see cref="Godot.CameraAttributesPractical.DofBlurNearDistance"/>. Strength of blur is controlled by <see cref="Godot.CameraAttributesPractical.DofBlurAmount"/> and modulated by <see cref="Godot.CameraAttributesPractical.DofBlurNearTransition"/>.</para>
    /// <para><b>Note:</b> Depth of field blur is only supported in the Forward+ and Mobile rendering methods, not Compatibility.</para>
    /// <para><b>Note:</b> Depth of field blur is not supported on viewports that have a transparent background (where <see cref="Godot.Viewport.TransparentBg"/> is <see langword="true"/>).</para>
    /// </summary>
    public bool DofBlurNearEnabled
    {
        get
        {
            return IsDofBlurNearEnabled();
        }
        set
        {
            SetDofBlurNearEnabled(value);
        }
    }

    /// <summary>
    /// <para>Objects closer from the <see cref="Godot.Camera3D"/> by this amount will be blurred by the depth of field effect. Measured in meters.</para>
    /// </summary>
    public float DofBlurNearDistance
    {
        get
        {
            return GetDofBlurNearDistance();
        }
        set
        {
            SetDofBlurNearDistance(value);
        }
    }

    /// <summary>
    /// <para>When positive, distance over which blur effect will scale from 0 to <see cref="Godot.CameraAttributesPractical.DofBlurAmount"/>, ending at <see cref="Godot.CameraAttributesPractical.DofBlurNearDistance"/>. When negative, uses physically-based scaling so depth of field effect will scale from 0 at <see cref="Godot.CameraAttributesPractical.DofBlurNearDistance"/> and will increase in a physically accurate way as objects get closer to the <see cref="Godot.Camera3D"/>.</para>
    /// </summary>
    public float DofBlurNearTransition
    {
        get
        {
            return GetDofBlurNearTransition();
        }
        set
        {
            SetDofBlurNearTransition(value);
        }
    }

    /// <summary>
    /// <para>Sets the maximum amount of blur. When using physically-based blur amounts, will instead act as a multiplier. High values lead to an increased amount of blurriness, but can be much more expensive to calculate. It is best to keep this as low as possible for a given art style.</para>
    /// </summary>
    public float DofBlurAmount
    {
        get
        {
            return GetDofBlurAmount();
        }
        set
        {
            SetDofBlurAmount(value);
        }
    }

    /// <summary>
    /// <para>The minimum sensitivity (in ISO) used when calculating auto exposure. When calculating scene average luminance, color values will be clamped to at least this value. This limits the auto-exposure from exposing above a certain brightness, resulting in a cut off point where the scene will remain dark.</para>
    /// </summary>
    public float AutoExposureMinSensitivity
    {
        get
        {
            return GetAutoExposureMinSensitivity();
        }
        set
        {
            SetAutoExposureMinSensitivity(value);
        }
    }

    /// <summary>
    /// <para>The maximum sensitivity (in ISO) used when calculating auto exposure. When calculating scene average luminance, color values will be clamped to at least this value. This limits the auto-exposure from exposing below a certain brightness, resulting in a cut off point where the scene will remain bright.</para>
    /// </summary>
    public float AutoExposureMaxSensitivity
    {
        get
        {
            return GetAutoExposureMaxSensitivity();
        }
        set
        {
            SetAutoExposureMaxSensitivity(value);
        }
    }

    private static readonly System.Type CachedType = typeof(CameraAttributesPractical);

    private static readonly StringName NativeName = "CameraAttributesPractical";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public CameraAttributesPractical() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal CameraAttributesPractical(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal CameraAttributesPractical(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDofBlurFarEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDofBlurFarEnabled(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind0, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsDofBlurFarEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsDofBlurFarEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind1, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDofBlurFarDistance, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDofBlurFarDistance(float distance)
    {
        NativeCalls.godot_icall_1_67(MethodBind2, GodotObject.GetPtr(this), distance);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDofBlurFarDistance, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetDofBlurFarDistance()
    {
        return NativeCalls.godot_icall_0_68(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDofBlurFarTransition, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDofBlurFarTransition(float distance)
    {
        NativeCalls.godot_icall_1_67(MethodBind4, GodotObject.GetPtr(this), distance);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDofBlurFarTransition, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetDofBlurFarTransition()
    {
        return NativeCalls.godot_icall_0_68(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDofBlurNearEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDofBlurNearEnabled(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind6, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsDofBlurNearEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsDofBlurNearEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind7, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDofBlurNearDistance, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDofBlurNearDistance(float distance)
    {
        NativeCalls.godot_icall_1_67(MethodBind8, GodotObject.GetPtr(this), distance);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDofBlurNearDistance, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetDofBlurNearDistance()
    {
        return NativeCalls.godot_icall_0_68(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDofBlurNearTransition, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDofBlurNearTransition(float distance)
    {
        NativeCalls.godot_icall_1_67(MethodBind10, GodotObject.GetPtr(this), distance);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDofBlurNearTransition, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetDofBlurNearTransition()
    {
        return NativeCalls.godot_icall_0_68(MethodBind11, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDofBlurAmount, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDofBlurAmount(float amount)
    {
        NativeCalls.godot_icall_1_67(MethodBind12, GodotObject.GetPtr(this), amount);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDofBlurAmount, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetDofBlurAmount()
    {
        return NativeCalls.godot_icall_0_68(MethodBind13, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAutoExposureMaxSensitivity, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAutoExposureMaxSensitivity(float maxSensitivity)
    {
        NativeCalls.godot_icall_1_67(MethodBind14, GodotObject.GetPtr(this), maxSensitivity);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAutoExposureMaxSensitivity, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetAutoExposureMaxSensitivity()
    {
        return NativeCalls.godot_icall_0_68(MethodBind15, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAutoExposureMinSensitivity, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAutoExposureMinSensitivity(float minSensitivity)
    {
        NativeCalls.godot_icall_1_67(MethodBind16, GodotObject.GetPtr(this), minSensitivity);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAutoExposureMinSensitivity, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetAutoExposureMinSensitivity()
    {
        return NativeCalls.godot_icall_0_68(MethodBind17, GodotObject.GetPtr(this));
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
        /// Cached name for the 'dof_blur_far_enabled' property.
        /// </summary>
        public static readonly StringName DofBlurFarEnabled = "dof_blur_far_enabled";
        /// <summary>
        /// Cached name for the 'dof_blur_far_distance' property.
        /// </summary>
        public static readonly StringName DofBlurFarDistance = "dof_blur_far_distance";
        /// <summary>
        /// Cached name for the 'dof_blur_far_transition' property.
        /// </summary>
        public static readonly StringName DofBlurFarTransition = "dof_blur_far_transition";
        /// <summary>
        /// Cached name for the 'dof_blur_near_enabled' property.
        /// </summary>
        public static readonly StringName DofBlurNearEnabled = "dof_blur_near_enabled";
        /// <summary>
        /// Cached name for the 'dof_blur_near_distance' property.
        /// </summary>
        public static readonly StringName DofBlurNearDistance = "dof_blur_near_distance";
        /// <summary>
        /// Cached name for the 'dof_blur_near_transition' property.
        /// </summary>
        public static readonly StringName DofBlurNearTransition = "dof_blur_near_transition";
        /// <summary>
        /// Cached name for the 'dof_blur_amount' property.
        /// </summary>
        public static readonly StringName DofBlurAmount = "dof_blur_amount";
        /// <summary>
        /// Cached name for the 'auto_exposure_min_sensitivity' property.
        /// </summary>
        public static readonly StringName AutoExposureMinSensitivity = "auto_exposure_min_sensitivity";
        /// <summary>
        /// Cached name for the 'auto_exposure_max_sensitivity' property.
        /// </summary>
        public static readonly StringName AutoExposureMaxSensitivity = "auto_exposure_max_sensitivity";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : CameraAttributes.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_dof_blur_far_enabled' method.
        /// </summary>
        public static readonly StringName SetDofBlurFarEnabled = "set_dof_blur_far_enabled";
        /// <summary>
        /// Cached name for the 'is_dof_blur_far_enabled' method.
        /// </summary>
        public static readonly StringName IsDofBlurFarEnabled = "is_dof_blur_far_enabled";
        /// <summary>
        /// Cached name for the 'set_dof_blur_far_distance' method.
        /// </summary>
        public static readonly StringName SetDofBlurFarDistance = "set_dof_blur_far_distance";
        /// <summary>
        /// Cached name for the 'get_dof_blur_far_distance' method.
        /// </summary>
        public static readonly StringName GetDofBlurFarDistance = "get_dof_blur_far_distance";
        /// <summary>
        /// Cached name for the 'set_dof_blur_far_transition' method.
        /// </summary>
        public static readonly StringName SetDofBlurFarTransition = "set_dof_blur_far_transition";
        /// <summary>
        /// Cached name for the 'get_dof_blur_far_transition' method.
        /// </summary>
        public static readonly StringName GetDofBlurFarTransition = "get_dof_blur_far_transition";
        /// <summary>
        /// Cached name for the 'set_dof_blur_near_enabled' method.
        /// </summary>
        public static readonly StringName SetDofBlurNearEnabled = "set_dof_blur_near_enabled";
        /// <summary>
        /// Cached name for the 'is_dof_blur_near_enabled' method.
        /// </summary>
        public static readonly StringName IsDofBlurNearEnabled = "is_dof_blur_near_enabled";
        /// <summary>
        /// Cached name for the 'set_dof_blur_near_distance' method.
        /// </summary>
        public static readonly StringName SetDofBlurNearDistance = "set_dof_blur_near_distance";
        /// <summary>
        /// Cached name for the 'get_dof_blur_near_distance' method.
        /// </summary>
        public static readonly StringName GetDofBlurNearDistance = "get_dof_blur_near_distance";
        /// <summary>
        /// Cached name for the 'set_dof_blur_near_transition' method.
        /// </summary>
        public static readonly StringName SetDofBlurNearTransition = "set_dof_blur_near_transition";
        /// <summary>
        /// Cached name for the 'get_dof_blur_near_transition' method.
        /// </summary>
        public static readonly StringName GetDofBlurNearTransition = "get_dof_blur_near_transition";
        /// <summary>
        /// Cached name for the 'set_dof_blur_amount' method.
        /// </summary>
        public static readonly StringName SetDofBlurAmount = "set_dof_blur_amount";
        /// <summary>
        /// Cached name for the 'get_dof_blur_amount' method.
        /// </summary>
        public static readonly StringName GetDofBlurAmount = "get_dof_blur_amount";
        /// <summary>
        /// Cached name for the 'set_auto_exposure_max_sensitivity' method.
        /// </summary>
        public static readonly StringName SetAutoExposureMaxSensitivity = "set_auto_exposure_max_sensitivity";
        /// <summary>
        /// Cached name for the 'get_auto_exposure_max_sensitivity' method.
        /// </summary>
        public static readonly StringName GetAutoExposureMaxSensitivity = "get_auto_exposure_max_sensitivity";
        /// <summary>
        /// Cached name for the 'set_auto_exposure_min_sensitivity' method.
        /// </summary>
        public static readonly StringName SetAutoExposureMinSensitivity = "set_auto_exposure_min_sensitivity";
        /// <summary>
        /// Cached name for the 'get_auto_exposure_min_sensitivity' method.
        /// </summary>
        public static readonly StringName GetAutoExposureMinSensitivity = "get_auto_exposure_min_sensitivity";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : CameraAttributes.SignalName
    {
    }
}
