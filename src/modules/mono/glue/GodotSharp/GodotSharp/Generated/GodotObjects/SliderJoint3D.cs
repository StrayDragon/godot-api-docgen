namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A physics joint that restricts the movement of a 3D physics body along an axis relative to another physics body. For example, Body A could be a <see cref="Godot.StaticBody3D"/> representing a piston base, while Body B could be a <see cref="Godot.RigidBody3D"/> representing the piston head, moving up and down.</para>
/// </summary>
public partial class SliderJoint3D : Joint3D
{
    public enum Param : long
    {
        /// <summary>
        /// <para>Constant for accessing <c>linear_limit/upper_distance</c>. The maximum difference between the pivot points on their X axis before damping happens.</para>
        /// </summary>
        LinearLimitUpper = 0,
        /// <summary>
        /// <para>Constant for accessing <c>linear_limit/lower_distance</c>. The minimum difference between the pivot points on their X axis before damping happens.</para>
        /// </summary>
        LinearLimitLower = 1,
        /// <summary>
        /// <para>Constant for accessing <c>linear_limit/softness</c>. A factor applied to the movement across the slider axis once the limits get surpassed. The lower, the slower the movement.</para>
        /// </summary>
        LinearLimitSoftness = 2,
        /// <summary>
        /// <para>Constant for accessing <c>linear_limit/restitution</c>. The amount of restitution once the limits are surpassed. The lower, the more velocity-energy gets lost.</para>
        /// </summary>
        LinearLimitRestitution = 3,
        /// <summary>
        /// <para>Constant for accessing <c>linear_limit/damping</c>. The amount of damping once the slider limits are surpassed.</para>
        /// </summary>
        LinearLimitDamping = 4,
        /// <summary>
        /// <para>Constant for accessing <c>linear_motion/softness</c>. A factor applied to the movement across the slider axis as long as the slider is in the limits. The lower, the slower the movement.</para>
        /// </summary>
        LinearMotionSoftness = 5,
        /// <summary>
        /// <para>Constant for accessing <c>linear_motion/restitution</c>. The amount of restitution inside the slider limits.</para>
        /// </summary>
        LinearMotionRestitution = 6,
        /// <summary>
        /// <para>Constant for accessing <c>linear_motion/damping</c>. The amount of damping inside the slider limits.</para>
        /// </summary>
        LinearMotionDamping = 7,
        /// <summary>
        /// <para>Constant for accessing <c>linear_ortho/softness</c>. A factor applied to the movement across axes orthogonal to the slider.</para>
        /// </summary>
        LinearOrthogonalSoftness = 8,
        /// <summary>
        /// <para>Constant for accessing <c>linear_motion/restitution</c>. The amount of restitution when movement is across axes orthogonal to the slider.</para>
        /// </summary>
        LinearOrthogonalRestitution = 9,
        /// <summary>
        /// <para>Constant for accessing <c>linear_motion/damping</c>. The amount of damping when movement is across axes orthogonal to the slider.</para>
        /// </summary>
        LinearOrthogonalDamping = 10,
        /// <summary>
        /// <para>Constant for accessing <c>angular_limit/upper_angle</c>. The upper limit of rotation in the slider.</para>
        /// </summary>
        AngularLimitUpper = 11,
        /// <summary>
        /// <para>Constant for accessing <c>angular_limit/lower_angle</c>. The lower limit of rotation in the slider.</para>
        /// </summary>
        AngularLimitLower = 12,
        /// <summary>
        /// <para>Constant for accessing <c>angular_limit/softness</c>. A factor applied to the all rotation once the limit is surpassed.</para>
        /// </summary>
        AngularLimitSoftness = 13,
        /// <summary>
        /// <para>Constant for accessing <c>angular_limit/restitution</c>. The amount of restitution of the rotation when the limit is surpassed.</para>
        /// </summary>
        AngularLimitRestitution = 14,
        /// <summary>
        /// <para>Constant for accessing <c>angular_limit/damping</c>. The amount of damping of the rotation when the limit is surpassed.</para>
        /// </summary>
        AngularLimitDamping = 15,
        /// <summary>
        /// <para>Constant for accessing <c>angular_motion/softness</c>. A factor applied to the all rotation in the limits.</para>
        /// </summary>
        AngularMotionSoftness = 16,
        /// <summary>
        /// <para>Constant for accessing <c>angular_motion/restitution</c>. The amount of restitution of the rotation in the limits.</para>
        /// </summary>
        AngularMotionRestitution = 17,
        /// <summary>
        /// <para>Constant for accessing <c>angular_motion/damping</c>. The amount of damping of the rotation in the limits.</para>
        /// </summary>
        AngularMotionDamping = 18,
        /// <summary>
        /// <para>Constant for accessing <c>angular_ortho/softness</c>. A factor applied to the all rotation across axes orthogonal to the slider.</para>
        /// </summary>
        AngularOrthogonalSoftness = 19,
        /// <summary>
        /// <para>Constant for accessing <c>angular_ortho/restitution</c>. The amount of restitution of the rotation across axes orthogonal to the slider.</para>
        /// </summary>
        AngularOrthogonalRestitution = 20,
        /// <summary>
        /// <para>Constant for accessing <c>angular_ortho/damping</c>. The amount of damping of the rotation across axes orthogonal to the slider.</para>
        /// </summary>
        AngularOrthogonalDamping = 21,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.SliderJoint3D.Param"/> enum.</para>
        /// </summary>
        Max = 22
    }

    private static readonly System.Type CachedType = typeof(SliderJoint3D);

    private static readonly StringName NativeName = "SliderJoint3D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public SliderJoint3D() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal SliderJoint3D(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal SliderJoint3D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetParam, 918243683ul);

    /// <summary>
    /// <para>Assigns <paramref name="value"/> to the given parameter.</para>
    /// </summary>
    public void SetParam(SliderJoint3D.Param param, float value)
    {
        NativeCalls.godot_icall_2_69(MethodBind0, GodotObject.GetPtr(this), (int)param, value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetParam, 959925627ul);

    /// <summary>
    /// <para>Returns the value of the given parameter.</para>
    /// </summary>
    public float GetParam(SliderJoint3D.Param param)
    {
        return NativeCalls.godot_icall_1_72(MethodBind1, GodotObject.GetPtr(this), (int)param);
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
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Joint3D.SignalName
    {
    }
}
