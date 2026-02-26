namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A physics joint that restricts the rotation of a 3D physics body around an axis relative to another physics body. For example, Body A can be a <see cref="Godot.StaticBody3D"/> representing a door hinge that a <see cref="Godot.RigidBody3D"/> rotates around.</para>
/// </summary>
public partial class HingeJoint3D : Joint3D
{
    public enum Param : long
    {
        /// <summary>
        /// <para>The speed with which the two bodies get pulled together when they move in different directions.</para>
        /// </summary>
        Bias = 0,
        /// <summary>
        /// <para>The maximum rotation. Only active if <c>angular_limit/enable</c> is <see langword="true"/>.</para>
        /// </summary>
        LimitUpper = 1,
        /// <summary>
        /// <para>The minimum rotation. Only active if <c>angular_limit/enable</c> is <see langword="true"/>.</para>
        /// </summary>
        LimitLower = 2,
        /// <summary>
        /// <para>The speed with which the rotation across the axis perpendicular to the hinge gets corrected.</para>
        /// </summary>
        LimitBias = 3,
        [Obsolete("This property is never used by the engine and is kept for compatibility purpose.")]
        LimitSoftness = 4,
        /// <summary>
        /// <para>The lower this value, the more the rotation gets slowed down.</para>
        /// </summary>
        LimitRelaxation = 5,
        /// <summary>
        /// <para>Target speed for the motor.</para>
        /// </summary>
        MotorTargetVelocity = 6,
        /// <summary>
        /// <para>Maximum acceleration for the motor.</para>
        /// </summary>
        MotorMaxImpulse = 7,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.HingeJoint3D.Param"/> enum.</para>
        /// </summary>
        Max = 8
    }

    public enum Flag : long
    {
        /// <summary>
        /// <para>If <see langword="true"/>, the hinges maximum and minimum rotation, defined by <c>angular_limit/lower</c> and <c>angular_limit/upper</c> has effects.</para>
        /// </summary>
        UseLimit = 0,
        /// <summary>
        /// <para>When activated, a motor turns the hinge.</para>
        /// </summary>
        EnableMotor = 1,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.HingeJoint3D.Flag"/> enum.</para>
        /// </summary>
        Max = 2
    }

    private static readonly System.Type CachedType = typeof(HingeJoint3D);

    private static readonly StringName NativeName = "HingeJoint3D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public HingeJoint3D() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal HingeJoint3D(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal HingeJoint3D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetParam, 3082977519ul);

    /// <summary>
    /// <para>Sets the value of the specified parameter.</para>
    /// </summary>
    public void SetParam(HingeJoint3D.Param param, float value)
    {
        NativeCalls.godot_icall_2_69(MethodBind0, GodotObject.GetPtr(this), (int)param, value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetParam, 4066002676ul);

    /// <summary>
    /// <para>Returns the value of the specified parameter.</para>
    /// </summary>
    public float GetParam(HingeJoint3D.Param param)
    {
        return NativeCalls.godot_icall_1_72(MethodBind1, GodotObject.GetPtr(this), (int)param);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFlag, 1083494620ul);

    /// <summary>
    /// <para>If <see langword="true"/>, enables the specified flag.</para>
    /// </summary>
    public void SetFlag(HingeJoint3D.Flag flag, bool enabled)
    {
        NativeCalls.godot_icall_2_61(MethodBind2, GodotObject.GetPtr(this), (int)flag, enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFlag, 2841369610ul);

    /// <summary>
    /// <para>Returns the value of the specified flag.</para>
    /// </summary>
    public bool GetFlag(HingeJoint3D.Flag flag)
    {
        return NativeCalls.godot_icall_1_62(MethodBind3, GodotObject.GetPtr(this), (int)flag).ToBool();
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
        /// Cached name for the 'set_param' method.
        /// </summary>
        public static readonly StringName SetParam = "set_param";
        /// <summary>
        /// Cached name for the 'get_param' method.
        /// </summary>
        public static readonly StringName GetParam = "get_param";
        /// <summary>
        /// Cached name for the 'set_flag' method.
        /// </summary>
        public static readonly StringName SetFlag = "set_flag";
        /// <summary>
        /// Cached name for the 'get_flag' method.
        /// </summary>
        public static readonly StringName GetFlag = "get_flag";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Joint3D.SignalName
    {
    }
}
