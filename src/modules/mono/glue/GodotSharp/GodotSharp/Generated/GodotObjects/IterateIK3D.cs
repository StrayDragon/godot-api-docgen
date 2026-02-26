namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Base class of <see cref="Godot.SkeletonModifier3D"/> to approach the goal by repeating small rotations.</para>
/// <para>Each bone chain (setting) has one effector, which is processed in order of the setting list. You can set some limitations for each joint.</para>
/// </summary>
public partial class IterateIK3D : ChainIK3D
{
    /// <summary>
    /// <para>The number of iteration loops used by the IK solver to produce more accurate results.</para>
    /// </summary>
    public int MaxIterations
    {
        get
        {
            return GetMaxIterations();
        }
        set
        {
            SetMaxIterations(value);
        }
    }

    /// <summary>
    /// <para>The minimum distance between the end bone and the target. If the distance is below this value, the IK solver stops any further iterations.</para>
    /// </summary>
    public double MinDistance
    {
        get
        {
            return GetMinDistance();
        }
        set
        {
            SetMinDistance(value);
        }
    }

    /// <summary>
    /// <para>The maximum amount each bone can rotate in a single iteration.</para>
    /// <para><b>Note:</b> This limitation is applied during each iteration. For example, if <see cref="Godot.IterateIK3D.MaxIterations"/> is <c>4</c> and <see cref="Godot.IterateIK3D.AngularDeltaLimit"/> is <c>5</c> degrees, the maximum rotation possible in a single frame is <c>20</c> degrees.</para>
    /// </summary>
    public double AngularDeltaLimit
    {
        get
        {
            return GetAngularDeltaLimit();
        }
        set
        {
            SetAngularDeltaLimit(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="false"/>, the result is calculated from the previous frame's <see cref="Godot.IterateIK3D"/> result as the initial state.</para>
    /// <para>If <see langword="true"/>, the previous frame's <see cref="Godot.IterateIK3D"/> result is discarded. At this point, the new result is calculated from the bone pose excluding the <see cref="Godot.IterateIK3D"/> as the initial state. This means the result will be always equal as long as the target position and the previous bone pose are the same. However, if <see cref="Godot.IterateIK3D.AngularDeltaLimit"/> and <see cref="Godot.IterateIK3D.MaxIterations"/> are set too small, the end bone of the chain will never reach the target.</para>
    /// </summary>
    public bool Deterministic
    {
        get
        {
            return IsDeterministic();
        }
        set
        {
            SetDeterministic(value);
        }
    }

    /// <summary>
    /// <para>The number of settings.</para>
    /// </summary>
    public int SettingCount
    {
        get
        {
            return GetSettingCount();
        }
        set
        {
            SetSettingCount(value);
        }
    }

    private static readonly System.Type CachedType = typeof(IterateIK3D);

    private static readonly StringName NativeName = "IterateIK3D";

    internal IterateIK3D() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal IterateIK3D(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal IterateIK3D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMaxIterations, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMaxIterations(int maxIterations)
    {
        NativeCalls.godot_icall_1_38(MethodBind0, GodotObject.GetPtr(this), maxIterations);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMaxIterations, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetMaxIterations()
    {
        return NativeCalls.godot_icall_0_39(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMinDistance, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMinDistance(double minDistance)
    {
        NativeCalls.godot_icall_1_127(MethodBind2, GodotObject.GetPtr(this), minDistance);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMinDistance, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public double GetMinDistance()
    {
        return NativeCalls.godot_icall_0_144(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAngularDeltaLimit, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAngularDeltaLimit(double angularDeltaLimit)
    {
        NativeCalls.godot_icall_1_127(MethodBind4, GodotObject.GetPtr(this), angularDeltaLimit);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAngularDeltaLimit, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public double GetAngularDeltaLimit()
    {
        return NativeCalls.godot_icall_0_144(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDeterministic, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDeterministic(bool deterministic)
    {
        NativeCalls.godot_icall_1_14(MethodBind6, GodotObject.GetPtr(this), deterministic.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsDeterministic, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsDeterministic()
    {
        return NativeCalls.godot_icall_0_15(MethodBind7, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTargetNode, 2761262315ul);

    /// <summary>
    /// <para>Sets the target node that the end bone is trying to reach.</para>
    /// </summary>
    public void SetTargetNode(int index, NodePath targetNode)
    {
        NativeCalls.godot_icall_2_75(MethodBind8, GodotObject.GetPtr(this), index, (godot_node_path)(targetNode?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTargetNode, 408788394ul);

    /// <summary>
    /// <para>Returns the target node that the end bone is trying to reach.</para>
    /// </summary>
    public NodePath GetTargetNode(int index)
    {
        return NativeCalls.godot_icall_1_74(MethodBind9, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetJointRotationAxis, 1391134969ul);

    /// <summary>
    /// <para>Sets the rotation axis at <paramref name="joint"/> in the bone chain's joint list.</para>
    /// <para>The axes are based on the <see cref="Godot.Skeleton3D.GetBoneRest(int)"/>'s space, if <paramref name="axis"/> is <see cref="Godot.SkeletonModifier3D.RotationAxis.Custom"/>, you can specify any axis.</para>
    /// <para><b>Note:</b> The rotation axis and the forward vector shouldn't be colinear to avoid unintended rotation since <see cref="Godot.ChainIK3D"/> does not factor in twisting forces.</para>
    /// </summary>
    public void SetJointRotationAxis(int index, int joint, SkeletonModifier3D.RotationAxis axis)
    {
        NativeCalls.godot_icall_3_196(MethodBind10, GodotObject.GetPtr(this), index, joint, (int)axis);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetJointRotationAxis, 3312594080ul);

    /// <summary>
    /// <para>Returns the rotation axis at <paramref name="joint"/> in the bone chain's joint list.</para>
    /// </summary>
    public SkeletonModifier3D.RotationAxis GetJointRotationAxis(int index, int joint)
    {
        return (SkeletonModifier3D.RotationAxis)NativeCalls.godot_icall_2_73(MethodBind11, GodotObject.GetPtr(this), index, joint);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetJointRotationAxisVector, 2866752138ul);

    /// <summary>
    /// <para>Sets the rotation axis vector for the specified joint in the bone chain.</para>
    /// <para>This vector is normalized by an internal process and represents the axis around which the bone chain can rotate.</para>
    /// <para>If the vector length is <c>0</c>, it is considered synonymous with <see cref="Godot.SkeletonModifier3D.RotationAxis.All"/>.</para>
    /// </summary>
    public unsafe void SetJointRotationAxisVector(int index, int joint, Vector3 axisVector)
    {
        NativeCalls.godot_icall_3_766(MethodBind12, GodotObject.GetPtr(this), index, joint, &axisVector);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetJointRotationAxisVector, 1592972041ul);

    /// <summary>
    /// <para>Returns the rotation axis vector for the specified joint in the bone chain. This vector represents the axis around which the joint can rotate. It is determined based on the rotation axis set for the joint.</para>
    /// <para>If <see cref="Godot.IterateIK3D.GetJointRotationAxis(int, int)"/> is <see cref="Godot.SkeletonModifier3D.RotationAxis.All"/>, this method returns <c>Vector3(0, 0, 0)</c>.</para>
    /// </summary>
    public Vector3 GetJointRotationAxisVector(int index, int joint)
    {
        return NativeCalls.godot_icall_2_767(MethodBind13, GodotObject.GetPtr(this), index, joint);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetJointLimitation, 1194636955ul);

    /// <summary>
    /// <para>Sets the joint limitation at <paramref name="joint"/> in the bone chain's joint list.</para>
    /// </summary>
    public void SetJointLimitation(int index, int joint, JointLimitation3D limitation)
    {
        NativeCalls.godot_icall_3_100(MethodBind14, GodotObject.GetPtr(this), index, joint, GodotObject.GetPtr(limitation));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetJointLimitation, 91665146ul);

    /// <summary>
    /// <para>Returns the joint limitation at <paramref name="joint"/> in the bone chain's joint list.</para>
    /// </summary>
    public JointLimitation3D GetJointLimitation(int index, int joint)
    {
        return (JointLimitation3D)NativeCalls.godot_icall_2_101(MethodBind15, GodotObject.GetPtr(this), index, joint);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetJointLimitationRightAxis, 3838967147ul);

    /// <summary>
    /// <para>Sets the joint limitation right axis at <paramref name="joint"/> in the bone chain's joint list.</para>
    /// </summary>
    public void SetJointLimitationRightAxis(int index, int joint, SkeletonModifier3D.SecondaryDirection direction)
    {
        NativeCalls.godot_icall_3_196(MethodBind16, GodotObject.GetPtr(this), index, joint, (int)direction);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetJointLimitationRightAxis, 623936134ul);

    /// <summary>
    /// <para>Returns the joint limitation right axis at <paramref name="joint"/> in the bone chain's joint list.</para>
    /// </summary>
    public SkeletonModifier3D.SecondaryDirection GetJointLimitationRightAxis(int index, int joint)
    {
        return (SkeletonModifier3D.SecondaryDirection)NativeCalls.godot_icall_2_73(MethodBind17, GodotObject.GetPtr(this), index, joint);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetJointLimitationRightAxisVector, 2866752138ul);

    /// <summary>
    /// <para>Sets the optional joint limitation right axis vector at <paramref name="joint"/> in the bone chain's joint list.</para>
    /// </summary>
    public unsafe void SetJointLimitationRightAxisVector(int index, int joint, Vector3 vector)
    {
        NativeCalls.godot_icall_3_766(MethodBind18, GodotObject.GetPtr(this), index, joint, &vector);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetJointLimitationRightAxisVector, 1592972041ul);

    /// <summary>
    /// <para>Returns the joint limitation right axis vector at <paramref name="joint"/> in the bone chain's joint list.</para>
    /// <para>If <see cref="Godot.IterateIK3D.GetJointLimitationRightAxis(int, int)"/> is <see cref="Godot.SkeletonModifier3D.SecondaryDirection.None"/>, this method returns <c>Vector3(0, 0, 0)</c>.</para>
    /// </summary>
    public Vector3 GetJointLimitationRightAxisVector(int index, int joint)
    {
        return NativeCalls.godot_icall_2_767(MethodBind19, GodotObject.GetPtr(this), index, joint);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetJointLimitationRotationOffset, 4188936002ul);

    /// <summary>
    /// <para>Sets the joint limitation rotation offset at <paramref name="joint"/> in the bone chain's joint list.</para>
    /// <para>Rotation is done in the local space which is constructed by the bone direction (in general parent to child) as the +Y axis and <see cref="Godot.IterateIK3D.GetJointLimitationRightAxisVector(int, int)"/> as the +X axis.</para>
    /// <para>If the +X and +Y axes are not orthogonal, the +X axis is implicitly modified to make it orthogonal.</para>
    /// <para>Also, if the length of <see cref="Godot.IterateIK3D.GetJointLimitationRightAxisVector(int, int)"/> is zero, the space is created by rotating the bone rest using the shortest arc that rotates the +Y axis of the bone rest to match the bone direction.</para>
    /// </summary>
    public unsafe void SetJointLimitationRotationOffset(int index, int joint, Quaternion offset)
    {
        NativeCalls.godot_icall_3_768(MethodBind20, GodotObject.GetPtr(this), index, joint, &offset);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetJointLimitationRotationOffset, 2722473700ul);

    /// <summary>
    /// <para>Returns the joint limitation rotation offset at <paramref name="joint"/> in the bone chain's joint list.</para>
    /// <para>Rotation is done in the local space which is constructed by the bone direction (in general parent to child) as the +Y axis and <see cref="Godot.IterateIK3D.GetJointLimitationRightAxisVector(int, int)"/> as the +X axis.</para>
    /// <para>If the +X and +Y axes are not orthogonal, the +X axis is implicitly modified to make it orthogonal.</para>
    /// <para>Also, if the length of <see cref="Godot.IterateIK3D.GetJointLimitationRightAxisVector(int, int)"/> is zero, the space is created by rotating the bone rest using the shortest arc that rotates the +Y axis of the bone rest to match the bone direction.</para>
    /// </summary>
    public Quaternion GetJointLimitationRotationOffset(int index, int joint)
    {
        return NativeCalls.godot_icall_2_769(MethodBind21, GodotObject.GetPtr(this), index, joint);
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
    public new class PropertyName : ChainIK3D.PropertyName
    {
        /// <summary>
        /// Cached name for the 'max_iterations' property.
        /// </summary>
        public static readonly StringName MaxIterations = "max_iterations";
        /// <summary>
        /// Cached name for the 'min_distance' property.
        /// </summary>
        public static readonly StringName MinDistance = "min_distance";
        /// <summary>
        /// Cached name for the 'angular_delta_limit' property.
        /// </summary>
        public static readonly StringName AngularDeltaLimit = "angular_delta_limit";
        /// <summary>
        /// Cached name for the 'deterministic' property.
        /// </summary>
        public static readonly StringName Deterministic = "deterministic";
        /// <summary>
        /// Cached name for the 'setting_count' property.
        /// </summary>
        public static readonly StringName SettingCount = "setting_count";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : ChainIK3D.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_max_iterations' method.
        /// </summary>
        public static readonly StringName SetMaxIterations = "set_max_iterations";
        /// <summary>
        /// Cached name for the 'get_max_iterations' method.
        /// </summary>
        public static readonly StringName GetMaxIterations = "get_max_iterations";
        /// <summary>
        /// Cached name for the 'set_min_distance' method.
        /// </summary>
        public static readonly StringName SetMinDistance = "set_min_distance";
        /// <summary>
        /// Cached name for the 'get_min_distance' method.
        /// </summary>
        public static readonly StringName GetMinDistance = "get_min_distance";
        /// <summary>
        /// Cached name for the 'set_angular_delta_limit' method.
        /// </summary>
        public static readonly StringName SetAngularDeltaLimit = "set_angular_delta_limit";
        /// <summary>
        /// Cached name for the 'get_angular_delta_limit' method.
        /// </summary>
        public static readonly StringName GetAngularDeltaLimit = "get_angular_delta_limit";
        /// <summary>
        /// Cached name for the 'set_deterministic' method.
        /// </summary>
        public static readonly StringName SetDeterministic = "set_deterministic";
        /// <summary>
        /// Cached name for the 'is_deterministic' method.
        /// </summary>
        public static readonly StringName IsDeterministic = "is_deterministic";
        /// <summary>
        /// Cached name for the 'set_target_node' method.
        /// </summary>
        public static readonly StringName SetTargetNode = "set_target_node";
        /// <summary>
        /// Cached name for the 'get_target_node' method.
        /// </summary>
        public static readonly StringName GetTargetNode = "get_target_node";
        /// <summary>
        /// Cached name for the 'set_joint_rotation_axis' method.
        /// </summary>
        public static readonly StringName SetJointRotationAxis = "set_joint_rotation_axis";
        /// <summary>
        /// Cached name for the 'get_joint_rotation_axis' method.
        /// </summary>
        public static readonly StringName GetJointRotationAxis = "get_joint_rotation_axis";
        /// <summary>
        /// Cached name for the 'set_joint_rotation_axis_vector' method.
        /// </summary>
        public static readonly StringName SetJointRotationAxisVector = "set_joint_rotation_axis_vector";
        /// <summary>
        /// Cached name for the 'get_joint_rotation_axis_vector' method.
        /// </summary>
        public static readonly StringName GetJointRotationAxisVector = "get_joint_rotation_axis_vector";
        /// <summary>
        /// Cached name for the 'set_joint_limitation' method.
        /// </summary>
        public static readonly StringName SetJointLimitation = "set_joint_limitation";
        /// <summary>
        /// Cached name for the 'get_joint_limitation' method.
        /// </summary>
        public static readonly StringName GetJointLimitation = "get_joint_limitation";
        /// <summary>
        /// Cached name for the 'set_joint_limitation_right_axis' method.
        /// </summary>
        public static readonly StringName SetJointLimitationRightAxis = "set_joint_limitation_right_axis";
        /// <summary>
        /// Cached name for the 'get_joint_limitation_right_axis' method.
        /// </summary>
        public static readonly StringName GetJointLimitationRightAxis = "get_joint_limitation_right_axis";
        /// <summary>
        /// Cached name for the 'set_joint_limitation_right_axis_vector' method.
        /// </summary>
        public static readonly StringName SetJointLimitationRightAxisVector = "set_joint_limitation_right_axis_vector";
        /// <summary>
        /// Cached name for the 'get_joint_limitation_right_axis_vector' method.
        /// </summary>
        public static readonly StringName GetJointLimitationRightAxisVector = "get_joint_limitation_right_axis_vector";
        /// <summary>
        /// Cached name for the 'set_joint_limitation_rotation_offset' method.
        /// </summary>
        public static readonly StringName SetJointLimitationRotationOffset = "set_joint_limitation_rotation_offset";
        /// <summary>
        /// Cached name for the 'get_joint_limitation_rotation_offset' method.
        /// </summary>
        public static readonly StringName GetJointLimitationRotationOffset = "get_joint_limitation_rotation_offset";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : ChainIK3D.SignalName
    {
    }
}
