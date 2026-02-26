namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>The <see cref="Godot.Generic6DofJoint3D"/> (6 Degrees Of Freedom) joint allows for implementing custom types of joints by locking the rotation and translation of certain axes.</para>
/// <para>The first 3 DOF represent the linear motion of the physics bodies and the last 3 DOF represent the angular motion of the physics bodies. Each axis can be either locked, or limited.</para>
/// </summary>
[GodotClassName("Generic6DOFJoint3D")]
public partial class Generic6DofJoint3D : Joint3D
{
    public enum Param : long
    {
        /// <summary>
        /// <para>The minimum difference between the pivot points' axes.</para>
        /// </summary>
        LinearLowerLimit = 0,
        /// <summary>
        /// <para>The maximum difference between the pivot points' axes.</para>
        /// </summary>
        LinearUpperLimit = 1,
        /// <summary>
        /// <para>A factor applied to the movement across the axes. The lower, the slower the movement.</para>
        /// </summary>
        LinearLimitSoftness = 2,
        /// <summary>
        /// <para>The amount of restitution on the axes' movement. The lower, the more momentum gets lost.</para>
        /// </summary>
        LinearRestitution = 3,
        /// <summary>
        /// <para>The amount of damping that happens at the linear motion across the axes.</para>
        /// </summary>
        LinearDamping = 4,
        /// <summary>
        /// <para>The velocity the linear motor will try to reach.</para>
        /// </summary>
        LinearMotorTargetVelocity = 5,
        /// <summary>
        /// <para>The maximum force the linear motor will apply while trying to reach the velocity target.</para>
        /// </summary>
        LinearMotorForceLimit = 6,
        LinearSpringStiffness = 7,
        LinearSpringDamping = 8,
        LinearSpringEquilibriumPoint = 9,
        /// <summary>
        /// <para>The minimum rotation in negative direction to break loose and rotate around the axes.</para>
        /// </summary>
        AngularLowerLimit = 10,
        /// <summary>
        /// <para>The minimum rotation in positive direction to break loose and rotate around the axes.</para>
        /// </summary>
        AngularUpperLimit = 11,
        /// <summary>
        /// <para>The speed of all rotations across the axes.</para>
        /// </summary>
        AngularLimitSoftness = 12,
        /// <summary>
        /// <para>The amount of rotational damping across the axes. The lower, the more damping occurs.</para>
        /// </summary>
        AngularDamping = 13,
        /// <summary>
        /// <para>The amount of rotational restitution across the axes. The lower, the more restitution occurs.</para>
        /// </summary>
        AngularRestitution = 14,
        /// <summary>
        /// <para>The maximum amount of force that can occur, when rotating around the axes.</para>
        /// </summary>
        AngularForceLimit = 15,
        /// <summary>
        /// <para>When rotating across the axes, this error tolerance factor defines how much the correction gets slowed down. The lower, the slower.</para>
        /// </summary>
        AngularErp = 16,
        /// <summary>
        /// <para>Target speed for the motor at the axes.</para>
        /// </summary>
        AngularMotorTargetVelocity = 17,
        /// <summary>
        /// <para>Maximum acceleration for the motor at the axes.</para>
        /// </summary>
        AngularMotorForceLimit = 18,
        AngularSpringStiffness = 19,
        AngularSpringDamping = 20,
        AngularSpringEquilibriumPoint = 21,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.Generic6DofJoint3D.Param"/> enum.</para>
        /// </summary>
        Max = 22
    }

    public enum Flag : long
    {
        /// <summary>
        /// <para>If enabled, linear motion is possible within the given limits.</para>
        /// </summary>
        EnableLinearLimit = 0,
        /// <summary>
        /// <para>If enabled, rotational motion is possible within the given limits.</para>
        /// </summary>
        EnableAngularLimit = 1,
        EnableLinearSpring = 3,
        EnableAngularSpring = 2,
        /// <summary>
        /// <para>If enabled, there is a rotational motor across these axes.</para>
        /// </summary>
        EnableMotor = 4,
        /// <summary>
        /// <para>If enabled, there is a linear motor across these axes.</para>
        /// </summary>
        EnableLinearMotor = 5,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.Generic6DofJoint3D.Flag"/> enum.</para>
        /// </summary>
        Max = 6
    }

    private static readonly System.Type CachedType = typeof(Generic6DofJoint3D);

    private static readonly StringName NativeName = "Generic6DOFJoint3D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public Generic6DofJoint3D() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal Generic6DofJoint3D(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal Generic6DofJoint3D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetParamX, 2018184242ul);

    public void SetParamX(Generic6DofJoint3D.Param param, float value)
    {
        NativeCalls.godot_icall_2_69(MethodBind0, GodotObject.GetPtr(this), (int)param, value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetParamX, 2599835054ul);

    public float GetParamX(Generic6DofJoint3D.Param param)
    {
        return NativeCalls.godot_icall_1_72(MethodBind1, GodotObject.GetPtr(this), (int)param);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetParamY, 2018184242ul);

    public void SetParamY(Generic6DofJoint3D.Param param, float value)
    {
        NativeCalls.godot_icall_2_69(MethodBind2, GodotObject.GetPtr(this), (int)param, value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetParamY, 2599835054ul);

    public float GetParamY(Generic6DofJoint3D.Param param)
    {
        return NativeCalls.godot_icall_1_72(MethodBind3, GodotObject.GetPtr(this), (int)param);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetParamZ, 2018184242ul);

    public void SetParamZ(Generic6DofJoint3D.Param param, float value)
    {
        NativeCalls.godot_icall_2_69(MethodBind4, GodotObject.GetPtr(this), (int)param, value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetParamZ, 2599835054ul);

    public float GetParamZ(Generic6DofJoint3D.Param param)
    {
        return NativeCalls.godot_icall_1_72(MethodBind5, GodotObject.GetPtr(this), (int)param);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFlagX, 2451594564ul);

    public void SetFlagX(Generic6DofJoint3D.Flag flag, bool value)
    {
        NativeCalls.godot_icall_2_61(MethodBind6, GodotObject.GetPtr(this), (int)flag, value.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFlagX, 2122427807ul);

    public bool GetFlagX(Generic6DofJoint3D.Flag flag)
    {
        return NativeCalls.godot_icall_1_62(MethodBind7, GodotObject.GetPtr(this), (int)flag).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFlagY, 2451594564ul);

    public void SetFlagY(Generic6DofJoint3D.Flag flag, bool value)
    {
        NativeCalls.godot_icall_2_61(MethodBind8, GodotObject.GetPtr(this), (int)flag, value.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFlagY, 2122427807ul);

    public bool GetFlagY(Generic6DofJoint3D.Flag flag)
    {
        return NativeCalls.godot_icall_1_62(MethodBind9, GodotObject.GetPtr(this), (int)flag).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFlagZ, 2451594564ul);

    public void SetFlagZ(Generic6DofJoint3D.Flag flag, bool value)
    {
        NativeCalls.godot_icall_2_61(MethodBind10, GodotObject.GetPtr(this), (int)flag, value.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFlagZ, 2122427807ul);

    public bool GetFlagZ(Generic6DofJoint3D.Flag flag)
    {
        return NativeCalls.godot_icall_1_62(MethodBind11, GodotObject.GetPtr(this), (int)flag).ToBool();
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
    public new class PropertyName : Joint3D.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Joint3D.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_param_x' method.
        /// </summary>
        public static readonly StringName SetParamX = "set_param_x";
        /// <summary>
        /// Cached name for the 'get_param_x' method.
        /// </summary>
        public static readonly StringName GetParamX = "get_param_x";
        /// <summary>
        /// Cached name for the 'set_param_y' method.
        /// </summary>
        public static readonly StringName SetParamY = "set_param_y";
        /// <summary>
        /// Cached name for the 'get_param_y' method.
        /// </summary>
        public static readonly StringName GetParamY = "get_param_y";
        /// <summary>
        /// Cached name for the 'set_param_z' method.
        /// </summary>
        public static readonly StringName SetParamZ = "set_param_z";
        /// <summary>
        /// Cached name for the 'get_param_z' method.
        /// </summary>
        public static readonly StringName GetParamZ = "get_param_z";
        /// <summary>
        /// Cached name for the 'set_flag_x' method.
        /// </summary>
        public static readonly StringName SetFlagX = "set_flag_x";
        /// <summary>
        /// Cached name for the 'get_flag_x' method.
        /// </summary>
        public static readonly StringName GetFlagX = "get_flag_x";
        /// <summary>
        /// Cached name for the 'set_flag_y' method.
        /// </summary>
        public static readonly StringName SetFlagY = "set_flag_y";
        /// <summary>
        /// Cached name for the 'get_flag_y' method.
        /// </summary>
        public static readonly StringName GetFlagY = "get_flag_y";
        /// <summary>
        /// Cached name for the 'set_flag_z' method.
        /// </summary>
        public static readonly StringName SetFlagZ = "set_flag_z";
        /// <summary>
        /// Cached name for the 'get_flag_z' method.
        /// </summary>
        public static readonly StringName GetFlagZ = "get_flag_z";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Joint3D.SignalName
    {
    }
}
