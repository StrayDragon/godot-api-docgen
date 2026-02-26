namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A physics joint that attaches two 2D physics bodies at a single point, allowing them to freely rotate. For example, a <see cref="Godot.RigidBody2D"/> can be attached to a <see cref="Godot.StaticBody2D"/> to create a pendulum or a seesaw.</para>
/// </summary>
public partial class PinJoint2D : Joint2D
{
    /// <summary>
    /// <para>The higher this value, the more the bond to the pinned partner can flex.</para>
    /// </summary>
    public float Softness
    {
        get
        {
            return GetSoftness();
        }
        set
        {
            SetSoftness(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the pin maximum and minimum rotation, defined by <see cref="Godot.PinJoint2D.AngularLimitLower"/> and <see cref="Godot.PinJoint2D.AngularLimitUpper"/> are applied.</para>
    /// </summary>
    public bool AngularLimitEnabled
    {
        get
        {
            return IsAngularLimitEnabled();
        }
        set
        {
            SetAngularLimitEnabled(value);
        }
    }

    /// <summary>
    /// <para>The minimum rotation. Only active if <see cref="Godot.PinJoint2D.AngularLimitEnabled"/> is <see langword="true"/>.</para>
    /// </summary>
    public float AngularLimitLower
    {
        get
        {
            return GetAngularLimitLower();
        }
        set
        {
            SetAngularLimitLower(value);
        }
    }

    /// <summary>
    /// <para>The maximum rotation. Only active if <see cref="Godot.PinJoint2D.AngularLimitEnabled"/> is <see langword="true"/>.</para>
    /// </summary>
    public float AngularLimitUpper
    {
        get
        {
            return GetAngularLimitUpper();
        }
        set
        {
            SetAngularLimitUpper(value);
        }
    }

    /// <summary>
    /// <para>When activated, a motor turns the pin.</para>
    /// </summary>
    public bool MotorEnabled
    {
        get
        {
            return IsMotorEnabled();
        }
        set
        {
            SetMotorEnabled(value);
        }
    }

    /// <summary>
    /// <para>Target speed for the motor. In radians per second.</para>
    /// </summary>
    public float MotorTargetVelocity
    {
        get
        {
            return GetMotorTargetVelocity();
        }
        set
        {
            SetMotorTargetVelocity(value);
        }
    }

    private static readonly System.Type CachedType = typeof(PinJoint2D);

    private static readonly StringName NativeName = "PinJoint2D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public PinJoint2D() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal PinJoint2D(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal PinJoint2D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSoftness, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSoftness(float softness)
    {
        NativeCalls.godot_icall_1_67(MethodBind0, GodotObject.GetPtr(this), softness);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSoftness, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetSoftness()
    {
        return NativeCalls.godot_icall_0_68(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAngularLimitLower, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAngularLimitLower(float angularLimitLower)
    {
        NativeCalls.godot_icall_1_67(MethodBind2, GodotObject.GetPtr(this), angularLimitLower);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAngularLimitLower, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetAngularLimitLower()
    {
        return NativeCalls.godot_icall_0_68(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAngularLimitUpper, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAngularLimitUpper(float angularLimitUpper)
    {
        NativeCalls.godot_icall_1_67(MethodBind4, GodotObject.GetPtr(this), angularLimitUpper);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAngularLimitUpper, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetAngularLimitUpper()
    {
        return NativeCalls.godot_icall_0_68(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMotorTargetVelocity, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMotorTargetVelocity(float motorTargetVelocity)
    {
        NativeCalls.godot_icall_1_67(MethodBind6, GodotObject.GetPtr(this), motorTargetVelocity);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMotorTargetVelocity, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetMotorTargetVelocity()
    {
        return NativeCalls.godot_icall_0_68(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMotorEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMotorEnabled(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind8, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsMotorEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsMotorEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind9, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAngularLimitEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAngularLimitEnabled(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind10, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsAngularLimitEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsAngularLimitEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind11, GodotObject.GetPtr(this)).ToBool();
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
    public new class PropertyName : Joint2D.PropertyName
    {
        /// <summary>
        /// Cached name for the 'softness' property.
        /// </summary>
        public static readonly StringName Softness = "softness";
        /// <summary>
        /// Cached name for the 'angular_limit_enabled' property.
        /// </summary>
        public static readonly StringName AngularLimitEnabled = "angular_limit_enabled";
        /// <summary>
        /// Cached name for the 'angular_limit_lower' property.
        /// </summary>
        public static readonly StringName AngularLimitLower = "angular_limit_lower";
        /// <summary>
        /// Cached name for the 'angular_limit_upper' property.
        /// </summary>
        public static readonly StringName AngularLimitUpper = "angular_limit_upper";
        /// <summary>
        /// Cached name for the 'motor_enabled' property.
        /// </summary>
        public static readonly StringName MotorEnabled = "motor_enabled";
        /// <summary>
        /// Cached name for the 'motor_target_velocity' property.
        /// </summary>
        public static readonly StringName MotorTargetVelocity = "motor_target_velocity";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Joint2D.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_softness' method.
        /// </summary>
        public static readonly StringName SetSoftness = "set_softness";
        /// <summary>
        /// Cached name for the 'get_softness' method.
        /// </summary>
        public static readonly StringName GetSoftness = "get_softness";
        /// <summary>
        /// Cached name for the 'set_angular_limit_lower' method.
        /// </summary>
        public static readonly StringName SetAngularLimitLower = "set_angular_limit_lower";
        /// <summary>
        /// Cached name for the 'get_angular_limit_lower' method.
        /// </summary>
        public static readonly StringName GetAngularLimitLower = "get_angular_limit_lower";
        /// <summary>
        /// Cached name for the 'set_angular_limit_upper' method.
        /// </summary>
        public static readonly StringName SetAngularLimitUpper = "set_angular_limit_upper";
        /// <summary>
        /// Cached name for the 'get_angular_limit_upper' method.
        /// </summary>
        public static readonly StringName GetAngularLimitUpper = "get_angular_limit_upper";
        /// <summary>
        /// Cached name for the 'set_motor_target_velocity' method.
        /// </summary>
        public static readonly StringName SetMotorTargetVelocity = "set_motor_target_velocity";
        /// <summary>
        /// Cached name for the 'get_motor_target_velocity' method.
        /// </summary>
        public static readonly StringName GetMotorTargetVelocity = "get_motor_target_velocity";
        /// <summary>
        /// Cached name for the 'set_motor_enabled' method.
        /// </summary>
        public static readonly StringName SetMotorEnabled = "set_motor_enabled";
        /// <summary>
        /// Cached name for the 'is_motor_enabled' method.
        /// </summary>
        public static readonly StringName IsMotorEnabled = "is_motor_enabled";
        /// <summary>
        /// Cached name for the 'set_angular_limit_enabled' method.
        /// </summary>
        public static readonly StringName SetAngularLimitEnabled = "set_angular_limit_enabled";
        /// <summary>
        /// Cached name for the 'is_angular_limit_enabled' method.
        /// </summary>
        public static readonly StringName IsAngularLimitEnabled = "is_angular_limit_enabled";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Joint2D.SignalName
    {
    }
}
