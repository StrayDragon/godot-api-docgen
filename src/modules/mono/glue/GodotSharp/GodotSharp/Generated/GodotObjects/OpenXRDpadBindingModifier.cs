namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>The DPad binding modifier converts an axis input to a dpad output, emulating a DPad. New input paths for each dpad direction will be added to the interaction profile. When bound to actions the DPad emulation will be activated. You should <b>not</b> combine dpad inputs with normal inputs in the same action set for the same control, this will result in an error being returned when suggested bindings are submitted to OpenXR.</para>
/// <para>See <a href="https://registry.khronos.org/OpenXR/specs/1.1/html/xrspec.html#XR_EXT_dpad_binding">XR_EXT_dpad_binding</a> for in-depth details.</para>
/// <para><b>Note:</b> If the DPad binding modifier extension is enabled, all dpad binding paths will be available in the action map. Adding the modifier to an interaction profile allows you to further customize the behavior.</para>
/// </summary>
public partial class OpenXRDpadBindingModifier : OpenXripBindingModifier
{
    /// <summary>
    /// <para>Action set for which this dpad binding modifier is active.</para>
    /// </summary>
    public OpenXRActionSet ActionSet
    {
        get
        {
            return GetActionSet();
        }
        set
        {
            SetActionSet(value);
        }
    }

    /// <summary>
    /// <para>Input path for this dpad binding modifier.</para>
    /// </summary>
    public string InputPath
    {
        get
        {
            return GetInputPath();
        }
        set
        {
            SetInputPath(value);
        }
    }

    /// <summary>
    /// <para>When our input value is equal or larger than this value, our dpad in that direction becomes <see langword="true"/>. It stays <see langword="true"/> until it falls under the <see cref="Godot.OpenXRDpadBindingModifier.ThresholdReleased"/> value.</para>
    /// </summary>
    public float Threshold
    {
        get
        {
            return GetThreshold();
        }
        set
        {
            SetThreshold(value);
        }
    }

    /// <summary>
    /// <para>When our input value falls below this, our output becomes <see langword="false"/>.</para>
    /// </summary>
    public float ThresholdReleased
    {
        get
        {
            return GetThresholdReleased();
        }
        set
        {
            SetThresholdReleased(value);
        }
    }

    /// <summary>
    /// <para>Center region in which our center position of our dpad return <see langword="true"/>.</para>
    /// </summary>
    public float CenterRegion
    {
        get
        {
            return GetCenterRegion();
        }
        set
        {
            SetCenterRegion(value);
        }
    }

    /// <summary>
    /// <para>The angle of each wedge that identifies the 4 directions of the emulated dpad.</para>
    /// </summary>
    public float WedgeAngle
    {
        get
        {
            return GetWedgeAngle();
        }
        set
        {
            SetWedgeAngle(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="false"/>, when the joystick enters a new dpad zone this becomes <see langword="true"/>.</para>
    /// <para>If <see langword="true"/>, when the joystick remains in active dpad zone, this remains <see langword="true"/> even if we overlap with another zone.</para>
    /// </summary>
    public bool IsSticky
    {
        get
        {
            return GetIsSticky();
        }
        set
        {
            SetIsSticky(value);
        }
    }

    /// <summary>
    /// <para>Haptic pulse to emit when the user presses the input.</para>
    /// </summary>
    public OpenXRHapticBase OnHaptic
    {
        get
        {
            return GetOnHaptic();
        }
        set
        {
            SetOnHaptic(value);
        }
    }

    /// <summary>
    /// <para>Haptic pulse to emit when the user releases the input.</para>
    /// </summary>
    public OpenXRHapticBase OffHaptic
    {
        get
        {
            return GetOffHaptic();
        }
        set
        {
            SetOffHaptic(value);
        }
    }

    private static readonly System.Type CachedType = typeof(OpenXRDpadBindingModifier);

    private static readonly StringName NativeName = "OpenXRDpadBindingModifier";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public OpenXRDpadBindingModifier() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal OpenXRDpadBindingModifier(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal OpenXRDpadBindingModifier(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetActionSet, 2093310581ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetActionSet(OpenXRActionSet actionSet)
    {
        NativeCalls.godot_icall_1_56(MethodBind0, GodotObject.GetPtr(this), GodotObject.GetPtr(actionSet));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetActionSet, 619941079ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public OpenXRActionSet GetActionSet()
    {
        return (OpenXRActionSet)NativeCalls.godot_icall_0_63(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetInputPath, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetInputPath(string inputPath)
    {
        NativeCalls.godot_icall_1_57(MethodBind2, GodotObject.GetPtr(this), inputPath);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetInputPath, 201670096ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetInputPath()
    {
        return NativeCalls.godot_icall_0_58(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetThreshold, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetThreshold(float threshold)
    {
        NativeCalls.godot_icall_1_67(MethodBind4, GodotObject.GetPtr(this), threshold);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetThreshold, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetThreshold()
    {
        return NativeCalls.godot_icall_0_68(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetThresholdReleased, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetThresholdReleased(float thresholdReleased)
    {
        NativeCalls.godot_icall_1_67(MethodBind6, GodotObject.GetPtr(this), thresholdReleased);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetThresholdReleased, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetThresholdReleased()
    {
        return NativeCalls.godot_icall_0_68(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCenterRegion, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCenterRegion(float centerRegion)
    {
        NativeCalls.godot_icall_1_67(MethodBind8, GodotObject.GetPtr(this), centerRegion);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCenterRegion, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetCenterRegion()
    {
        return NativeCalls.godot_icall_0_68(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetWedgeAngle, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetWedgeAngle(float wedgeAngle)
    {
        NativeCalls.godot_icall_1_67(MethodBind10, GodotObject.GetPtr(this), wedgeAngle);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetWedgeAngle, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetWedgeAngle()
    {
        return NativeCalls.godot_icall_0_68(MethodBind11, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetIsSticky, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetIsSticky(bool isSticky)
    {
        NativeCalls.godot_icall_1_14(MethodBind12, GodotObject.GetPtr(this), isSticky.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetIsSticky, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetIsSticky()
    {
        return NativeCalls.godot_icall_0_15(MethodBind13, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetOnHaptic, 2998020150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetOnHaptic(OpenXRHapticBase haptic)
    {
        NativeCalls.godot_icall_1_56(MethodBind14, GodotObject.GetPtr(this), GodotObject.GetPtr(haptic));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOnHaptic, 922310751ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public OpenXRHapticBase GetOnHaptic()
    {
        return (OpenXRHapticBase)NativeCalls.godot_icall_0_63(MethodBind15, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetOffHaptic, 2998020150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetOffHaptic(OpenXRHapticBase haptic)
    {
        NativeCalls.godot_icall_1_56(MethodBind16, GodotObject.GetPtr(this), GodotObject.GetPtr(haptic));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOffHaptic, 922310751ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public OpenXRHapticBase GetOffHaptic()
    {
        return (OpenXRHapticBase)NativeCalls.godot_icall_0_63(MethodBind17, GodotObject.GetPtr(this));
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
    public new class PropertyName : OpenXripBindingModifier.PropertyName
    {
        /// <summary>
        /// Cached name for the 'action_set' property.
        /// </summary>
        public static readonly StringName ActionSet = "action_set";
        /// <summary>
        /// Cached name for the 'input_path' property.
        /// </summary>
        public static readonly StringName InputPath = "input_path";
        /// <summary>
        /// Cached name for the 'threshold' property.
        /// </summary>
        public static readonly StringName Threshold = "threshold";
        /// <summary>
        /// Cached name for the 'threshold_released' property.
        /// </summary>
        public static readonly StringName ThresholdReleased = "threshold_released";
        /// <summary>
        /// Cached name for the 'center_region' property.
        /// </summary>
        public static readonly StringName CenterRegion = "center_region";
        /// <summary>
        /// Cached name for the 'wedge_angle' property.
        /// </summary>
        public static readonly StringName WedgeAngle = "wedge_angle";
        /// <summary>
        /// Cached name for the 'is_sticky' property.
        /// </summary>
        public static readonly StringName IsSticky = "is_sticky";
        /// <summary>
        /// Cached name for the 'on_haptic' property.
        /// </summary>
        public static readonly StringName OnHaptic = "on_haptic";
        /// <summary>
        /// Cached name for the 'off_haptic' property.
        /// </summary>
        public static readonly StringName OffHaptic = "off_haptic";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : OpenXripBindingModifier.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_action_set' method.
        /// </summary>
        public static readonly StringName SetActionSet = "set_action_set";
        /// <summary>
        /// Cached name for the 'get_action_set' method.
        /// </summary>
        public static readonly StringName GetActionSet = "get_action_set";
        /// <summary>
        /// Cached name for the 'set_input_path' method.
        /// </summary>
        public static readonly StringName SetInputPath = "set_input_path";
        /// <summary>
        /// Cached name for the 'get_input_path' method.
        /// </summary>
        public static readonly StringName GetInputPath = "get_input_path";
        /// <summary>
        /// Cached name for the 'set_threshold' method.
        /// </summary>
        public static readonly StringName SetThreshold = "set_threshold";
        /// <summary>
        /// Cached name for the 'get_threshold' method.
        /// </summary>
        public static readonly StringName GetThreshold = "get_threshold";
        /// <summary>
        /// Cached name for the 'set_threshold_released' method.
        /// </summary>
        public static readonly StringName SetThresholdReleased = "set_threshold_released";
        /// <summary>
        /// Cached name for the 'get_threshold_released' method.
        /// </summary>
        public static readonly StringName GetThresholdReleased = "get_threshold_released";
        /// <summary>
        /// Cached name for the 'set_center_region' method.
        /// </summary>
        public static readonly StringName SetCenterRegion = "set_center_region";
        /// <summary>
        /// Cached name for the 'get_center_region' method.
        /// </summary>
        public static readonly StringName GetCenterRegion = "get_center_region";
        /// <summary>
        /// Cached name for the 'set_wedge_angle' method.
        /// </summary>
        public static readonly StringName SetWedgeAngle = "set_wedge_angle";
        /// <summary>
        /// Cached name for the 'get_wedge_angle' method.
        /// </summary>
        public static readonly StringName GetWedgeAngle = "get_wedge_angle";
        /// <summary>
        /// Cached name for the 'set_is_sticky' method.
        /// </summary>
        public static readonly StringName SetIsSticky = "set_is_sticky";
        /// <summary>
        /// Cached name for the 'get_is_sticky' method.
        /// </summary>
        public static readonly StringName GetIsSticky = "get_is_sticky";
        /// <summary>
        /// Cached name for the 'set_on_haptic' method.
        /// </summary>
        public static readonly StringName SetOnHaptic = "set_on_haptic";
        /// <summary>
        /// Cached name for the 'get_on_haptic' method.
        /// </summary>
        public static readonly StringName GetOnHaptic = "get_on_haptic";
        /// <summary>
        /// Cached name for the 'set_off_haptic' method.
        /// </summary>
        public static readonly StringName SetOffHaptic = "set_off_haptic";
        /// <summary>
        /// Cached name for the 'get_off_haptic' method.
        /// </summary>
        public static readonly StringName GetOffHaptic = "get_off_haptic";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : OpenXripBindingModifier.SignalName
    {
    }
}
