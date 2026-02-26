namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>The analog threshold binding modifier can modify a float input to a boolean input with specified thresholds.</para>
/// <para>See <a href="https://registry.khronos.org/OpenXR/specs/1.1/html/xrspec.html#XR_VALVE_analog_threshold">XR_VALVE_analog_threshold</a> for in-depth details.</para>
/// </summary>
public partial class OpenXRAnalogThresholdModifier : OpenXRActionBindingModifier
{
    /// <summary>
    /// <para>When our input value is equal or larger than this value, our output becomes <see langword="true"/>. It stays <see langword="true"/> until it falls under the <see cref="Godot.OpenXRAnalogThresholdModifier.OffThreshold"/> value.</para>
    /// </summary>
    public float OnThreshold
    {
        get
        {
            return GetOnThreshold();
        }
        set
        {
            SetOnThreshold(value);
        }
    }

    /// <summary>
    /// <para>When our input value falls below this, our output becomes <see langword="false"/>.</para>
    /// </summary>
    public float OffThreshold
    {
        get
        {
            return GetOffThreshold();
        }
        set
        {
            SetOffThreshold(value);
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

    private static readonly System.Type CachedType = typeof(OpenXRAnalogThresholdModifier);

    private static readonly StringName NativeName = "OpenXRAnalogThresholdModifier";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public OpenXRAnalogThresholdModifier() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal OpenXRAnalogThresholdModifier(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal OpenXRAnalogThresholdModifier(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetOnThreshold, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetOnThreshold(float onThreshold)
    {
        NativeCalls.godot_icall_1_67(MethodBind0, GodotObject.GetPtr(this), onThreshold);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOnThreshold, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetOnThreshold()
    {
        return NativeCalls.godot_icall_0_68(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetOffThreshold, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetOffThreshold(float offThreshold)
    {
        NativeCalls.godot_icall_1_67(MethodBind2, GodotObject.GetPtr(this), offThreshold);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOffThreshold, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetOffThreshold()
    {
        return NativeCalls.godot_icall_0_68(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetOnHaptic, 2998020150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetOnHaptic(OpenXRHapticBase haptic)
    {
        NativeCalls.godot_icall_1_56(MethodBind4, GodotObject.GetPtr(this), GodotObject.GetPtr(haptic));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOnHaptic, 922310751ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public OpenXRHapticBase GetOnHaptic()
    {
        return (OpenXRHapticBase)NativeCalls.godot_icall_0_63(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetOffHaptic, 2998020150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetOffHaptic(OpenXRHapticBase haptic)
    {
        NativeCalls.godot_icall_1_56(MethodBind6, GodotObject.GetPtr(this), GodotObject.GetPtr(haptic));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOffHaptic, 922310751ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public OpenXRHapticBase GetOffHaptic()
    {
        return (OpenXRHapticBase)NativeCalls.godot_icall_0_63(MethodBind7, GodotObject.GetPtr(this));
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
    public new class PropertyName : OpenXRActionBindingModifier.PropertyName
    {
        /// <summary>
        /// Cached name for the 'on_threshold' property.
        /// </summary>
        public static readonly StringName OnThreshold = "on_threshold";
        /// <summary>
        /// Cached name for the 'off_threshold' property.
        /// </summary>
        public static readonly StringName OffThreshold = "off_threshold";
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
    public new class MethodName : OpenXRActionBindingModifier.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_on_threshold' method.
        /// </summary>
        public static readonly StringName SetOnThreshold = "set_on_threshold";
        /// <summary>
        /// Cached name for the 'get_on_threshold' method.
        /// </summary>
        public static readonly StringName GetOnThreshold = "get_on_threshold";
        /// <summary>
        /// Cached name for the 'set_off_threshold' method.
        /// </summary>
        public static readonly StringName SetOffThreshold = "set_off_threshold";
        /// <summary>
        /// Cached name for the 'get_off_threshold' method.
        /// </summary>
        public static readonly StringName GetOffThreshold = "get_off_threshold";
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
    public new class SignalName : OpenXRActionBindingModifier.SignalName
    {
    }
}
