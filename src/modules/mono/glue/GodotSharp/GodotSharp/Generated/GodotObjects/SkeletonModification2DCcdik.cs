namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This <see cref="Godot.SkeletonModification2D"/> uses an algorithm called Cyclic Coordinate Descent Inverse Kinematics, or CCDIK, to manipulate a chain of bones in a <see cref="Godot.Skeleton2D"/> so it reaches a defined target.</para>
/// <para>CCDIK works by rotating a set of bones, typically called a "bone chain", on a single axis. Each bone is rotated to face the target from the tip (by default), which over a chain of bones allow it to rotate properly to reach the target. Because the bones only rotate on a single axis, CCDIK <i>can</i> look more robotic than other IK solvers.</para>
/// <para><b>Note:</b> The CCDIK modifier has <c>ccdik_joints</c>, which are the data objects that hold the data for each joint in the CCDIK chain. This is different from a bone! CCDIK joints hold the data needed for each bone in the bone chain used by CCDIK.</para>
/// <para>CCDIK also fully supports angle constraints, allowing for more control over how a solution is met.</para>
/// </summary>
[GodotClassName("SkeletonModification2DCCDIK")]
public partial class SkeletonModification2DCcdik : SkeletonModification2D
{
    /// <summary>
    /// <para>The NodePath to the node that is the target for the CCDIK modification. This node is what the CCDIK chain will attempt to rotate the bone chain to.</para>
    /// </summary>
    public NodePath TargetNodePath
    {
        get
        {
            return GetTargetNode();
        }
        set
        {
            SetTargetNode(value);
        }
    }

    /// <summary>
    /// <para>The end position of the CCDIK chain. Typically, this should be a child of a <see cref="Godot.Bone2D"/> node attached to the final <see cref="Godot.Bone2D"/> in the CCDIK chain.</para>
    /// </summary>
    public NodePath TipNodePath
    {
        get
        {
            return GetTipNode();
        }
        set
        {
            SetTipNode(value);
        }
    }

    /// <summary>
    /// <para>The number of CCDIK joints in the CCDIK modification.</para>
    /// </summary>
    public int CcdikDataChainLength
    {
        get
        {
            return GetCcdikDataChainLength();
        }
        set
        {
            SetCcdikDataChainLength(value);
        }
    }

    private static readonly System.Type CachedType = typeof(SkeletonModification2DCcdik);

    private static readonly StringName NativeName = "SkeletonModification2DCCDIK";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public SkeletonModification2DCcdik() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal SkeletonModification2DCcdik(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal SkeletonModification2DCcdik(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTargetNode, 1348162250ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTargetNode(NodePath targetNodePath)
    {
        NativeCalls.godot_icall_1_123(MethodBind0, GodotObject.GetPtr(this), (godot_node_path)(targetNodePath?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTargetNode, 4075236667ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public NodePath GetTargetNode()
    {
        return NativeCalls.godot_icall_0_124(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTipNode, 1348162250ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTipNode(NodePath tipNodePath)
    {
        NativeCalls.godot_icall_1_123(MethodBind2, GodotObject.GetPtr(this), (godot_node_path)(tipNodePath?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTipNode, 4075236667ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public NodePath GetTipNode()
    {
        return NativeCalls.godot_icall_0_124(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCcdikDataChainLength, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCcdikDataChainLength(int length)
    {
        NativeCalls.godot_icall_1_38(MethodBind4, GodotObject.GetPtr(this), length);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCcdikDataChainLength, 2455072627ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetCcdikDataChainLength()
    {
        return NativeCalls.godot_icall_0_39(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCcdikJointBone2DNode, 2761262315ul);

    /// <summary>
    /// <para>Sets the <see cref="Godot.Bone2D"/> node assigned to the CCDIK joint at <paramref name="jointIdx"/>.</para>
    /// </summary>
    public void SetCcdikJointBone2DNode(int jointIdx, NodePath bone2DNodePath)
    {
        NativeCalls.godot_icall_2_75(MethodBind6, GodotObject.GetPtr(this), jointIdx, (godot_node_path)(bone2DNodePath?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCcdikJointBone2DNode, 408788394ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.Bone2D"/> node assigned to the CCDIK joint at <paramref name="jointIdx"/>.</para>
    /// </summary>
    public NodePath GetCcdikJointBone2DNode(int jointIdx)
    {
        return NativeCalls.godot_icall_1_74(MethodBind7, GodotObject.GetPtr(this), jointIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCcdikJointBoneIndex, 3937882851ul);

    /// <summary>
    /// <para>Sets the bone index, <paramref name="boneIdx"/>, of the CCDIK joint at <paramref name="jointIdx"/>. When possible, this will also update the <c>bone2d_node</c> of the CCDIK joint based on data provided by the linked skeleton.</para>
    /// </summary>
    public void SetCcdikJointBoneIndex(int jointIdx, int boneIdx)
    {
        NativeCalls.godot_icall_2_59(MethodBind8, GodotObject.GetPtr(this), jointIdx, boneIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCcdikJointBoneIndex, 923996154ul);

    /// <summary>
    /// <para>Returns the index of the <see cref="Godot.Bone2D"/> node assigned to the CCDIK joint at <paramref name="jointIdx"/>.</para>
    /// </summary>
    public int GetCcdikJointBoneIndex(int jointIdx)
    {
        return NativeCalls.godot_icall_1_60(MethodBind9, GodotObject.GetPtr(this), jointIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCcdikJointRotateFromJoint, 300928843ul);

    /// <summary>
    /// <para>Sets whether the joint at <paramref name="jointIdx"/> is set to rotate from the joint, <see langword="true"/>, or to rotate from the tip, <see langword="false"/>.</para>
    /// </summary>
    public void SetCcdikJointRotateFromJoint(int jointIdx, bool rotateFromJoint)
    {
        NativeCalls.godot_icall_2_61(MethodBind10, GodotObject.GetPtr(this), jointIdx, rotateFromJoint.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCcdikJointRotateFromJoint, 1116898809ul);

    /// <summary>
    /// <para>Returns whether the joint at <paramref name="jointIdx"/> is set to rotate from the joint, <see langword="true"/>, or to rotate from the tip, <see langword="false"/>. The default is to rotate from the tip.</para>
    /// </summary>
    public bool GetCcdikJointRotateFromJoint(int jointIdx)
    {
        return NativeCalls.godot_icall_1_62(MethodBind11, GodotObject.GetPtr(this), jointIdx).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCcdikJointEnableConstraint, 300928843ul);

    /// <summary>
    /// <para>Determines whether angle constraints on the CCDIK joint at <paramref name="jointIdx"/> are enabled. When <see langword="true"/>, constraints will be enabled and taken into account when solving.</para>
    /// </summary>
    public void SetCcdikJointEnableConstraint(int jointIdx, bool enableConstraint)
    {
        NativeCalls.godot_icall_2_61(MethodBind12, GodotObject.GetPtr(this), jointIdx, enableConstraint.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCcdikJointEnableConstraint, 1116898809ul);

    /// <summary>
    /// <para>Returns whether angle constraints on the CCDIK joint at <paramref name="jointIdx"/> are enabled.</para>
    /// </summary>
    public bool GetCcdikJointEnableConstraint(int jointIdx)
    {
        return NativeCalls.godot_icall_1_62(MethodBind13, GodotObject.GetPtr(this), jointIdx).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCcdikJointConstraintAngleMin, 1602489585ul);

    /// <summary>
    /// <para>Sets the minimum angle constraint for the joint at <paramref name="jointIdx"/>.</para>
    /// </summary>
    public void SetCcdikJointConstraintAngleMin(int jointIdx, float angleMin)
    {
        NativeCalls.godot_icall_2_69(MethodBind14, GodotObject.GetPtr(this), jointIdx, angleMin);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCcdikJointConstraintAngleMin, 2339986948ul);

    /// <summary>
    /// <para>Returns the minimum angle constraint for the joint at <paramref name="jointIdx"/>.</para>
    /// </summary>
    public float GetCcdikJointConstraintAngleMin(int jointIdx)
    {
        return NativeCalls.godot_icall_1_72(MethodBind15, GodotObject.GetPtr(this), jointIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCcdikJointConstraintAngleMax, 1602489585ul);

    /// <summary>
    /// <para>Sets the maximum angle constraint for the joint at <paramref name="jointIdx"/>.</para>
    /// </summary>
    public void SetCcdikJointConstraintAngleMax(int jointIdx, float angleMax)
    {
        NativeCalls.godot_icall_2_69(MethodBind16, GodotObject.GetPtr(this), jointIdx, angleMax);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCcdikJointConstraintAngleMax, 2339986948ul);

    /// <summary>
    /// <para>Returns the maximum angle constraint for the joint at <paramref name="jointIdx"/>.</para>
    /// </summary>
    public float GetCcdikJointConstraintAngleMax(int jointIdx)
    {
        return NativeCalls.godot_icall_1_72(MethodBind17, GodotObject.GetPtr(this), jointIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCcdikJointConstraintAngleInvert, 300928843ul);

    /// <summary>
    /// <para>Sets whether the CCDIK joint at <paramref name="jointIdx"/> uses an inverted joint constraint.</para>
    /// <para>An inverted joint constraint only constraints the CCDIK joint to the angles <i>outside of</i> the inputted minimum and maximum angles. For this reason, it is referred to as an inverted joint constraint, as it constraints the joint to the outside of the inputted values.</para>
    /// </summary>
    public void SetCcdikJointConstraintAngleInvert(int jointIdx, bool invert)
    {
        NativeCalls.godot_icall_2_61(MethodBind18, GodotObject.GetPtr(this), jointIdx, invert.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCcdikJointConstraintAngleInvert, 1116898809ul);

    /// <summary>
    /// <para>Returns whether the CCDIK joint at <paramref name="jointIdx"/> uses an inverted joint constraint. See <see cref="Godot.SkeletonModification2DCcdik.SetCcdikJointConstraintAngleInvert(int, bool)"/> for details.</para>
    /// </summary>
    public bool GetCcdikJointConstraintAngleInvert(int jointIdx)
    {
        return NativeCalls.godot_icall_1_62(MethodBind19, GodotObject.GetPtr(this), jointIdx).ToBool();
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
    public new class PropertyName : SkeletonModification2D.PropertyName
    {
        /// <summary>
        /// Cached name for the 'target_nodepath' property.
        /// </summary>
        public static readonly StringName TargetNodePath = "target_nodepath";
        /// <summary>
        /// Cached name for the 'tip_nodepath' property.
        /// </summary>
        public static readonly StringName TipNodePath = "tip_nodepath";
        /// <summary>
        /// Cached name for the 'ccdik_data_chain_length' property.
        /// </summary>
        public static readonly StringName CcdikDataChainLength = "ccdik_data_chain_length";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : SkeletonModification2D.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_target_node' method.
        /// </summary>
        public static readonly StringName SetTargetNode = "set_target_node";
        /// <summary>
        /// Cached name for the 'get_target_node' method.
        /// </summary>
        public static readonly StringName GetTargetNode = "get_target_node";
        /// <summary>
        /// Cached name for the 'set_tip_node' method.
        /// </summary>
        public static readonly StringName SetTipNode = "set_tip_node";
        /// <summary>
        /// Cached name for the 'get_tip_node' method.
        /// </summary>
        public static readonly StringName GetTipNode = "get_tip_node";
        /// <summary>
        /// Cached name for the 'set_ccdik_data_chain_length' method.
        /// </summary>
        public static readonly StringName SetCcdikDataChainLength = "set_ccdik_data_chain_length";
        /// <summary>
        /// Cached name for the 'get_ccdik_data_chain_length' method.
        /// </summary>
        public static readonly StringName GetCcdikDataChainLength = "get_ccdik_data_chain_length";
        /// <summary>
        /// Cached name for the 'set_ccdik_joint_bone2d_node' method.
        /// </summary>
        public static readonly StringName SetCcdikJointBone2DNode = "set_ccdik_joint_bone2d_node";
        /// <summary>
        /// Cached name for the 'get_ccdik_joint_bone2d_node' method.
        /// </summary>
        public static readonly StringName GetCcdikJointBone2DNode = "get_ccdik_joint_bone2d_node";
        /// <summary>
        /// Cached name for the 'set_ccdik_joint_bone_index' method.
        /// </summary>
        public static readonly StringName SetCcdikJointBoneIndex = "set_ccdik_joint_bone_index";
        /// <summary>
        /// Cached name for the 'get_ccdik_joint_bone_index' method.
        /// </summary>
        public static readonly StringName GetCcdikJointBoneIndex = "get_ccdik_joint_bone_index";
        /// <summary>
        /// Cached name for the 'set_ccdik_joint_rotate_from_joint' method.
        /// </summary>
        public static readonly StringName SetCcdikJointRotateFromJoint = "set_ccdik_joint_rotate_from_joint";
        /// <summary>
        /// Cached name for the 'get_ccdik_joint_rotate_from_joint' method.
        /// </summary>
        public static readonly StringName GetCcdikJointRotateFromJoint = "get_ccdik_joint_rotate_from_joint";
        /// <summary>
        /// Cached name for the 'set_ccdik_joint_enable_constraint' method.
        /// </summary>
        public static readonly StringName SetCcdikJointEnableConstraint = "set_ccdik_joint_enable_constraint";
        /// <summary>
        /// Cached name for the 'get_ccdik_joint_enable_constraint' method.
        /// </summary>
        public static readonly StringName GetCcdikJointEnableConstraint = "get_ccdik_joint_enable_constraint";
        /// <summary>
        /// Cached name for the 'set_ccdik_joint_constraint_angle_min' method.
        /// </summary>
        public static readonly StringName SetCcdikJointConstraintAngleMin = "set_ccdik_joint_constraint_angle_min";
        /// <summary>
        /// Cached name for the 'get_ccdik_joint_constraint_angle_min' method.
        /// </summary>
        public static readonly StringName GetCcdikJointConstraintAngleMin = "get_ccdik_joint_constraint_angle_min";
        /// <summary>
        /// Cached name for the 'set_ccdik_joint_constraint_angle_max' method.
        /// </summary>
        public static readonly StringName SetCcdikJointConstraintAngleMax = "set_ccdik_joint_constraint_angle_max";
        /// <summary>
        /// Cached name for the 'get_ccdik_joint_constraint_angle_max' method.
        /// </summary>
        public static readonly StringName GetCcdikJointConstraintAngleMax = "get_ccdik_joint_constraint_angle_max";
        /// <summary>
        /// Cached name for the 'set_ccdik_joint_constraint_angle_invert' method.
        /// </summary>
        public static readonly StringName SetCcdikJointConstraintAngleInvert = "set_ccdik_joint_constraint_angle_invert";
        /// <summary>
        /// Cached name for the 'get_ccdik_joint_constraint_angle_invert' method.
        /// </summary>
        public static readonly StringName GetCcdikJointConstraintAngleInvert = "get_ccdik_joint_constraint_angle_invert";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : SkeletonModification2D.SignalName
    {
    }
}
