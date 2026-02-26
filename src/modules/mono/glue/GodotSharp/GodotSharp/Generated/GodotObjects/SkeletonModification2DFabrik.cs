namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This <see cref="Godot.SkeletonModification2D"/> uses an algorithm called Forward And Backward Reaching Inverse Kinematics, or FABRIK, to rotate a bone chain so that it reaches a target.</para>
/// <para>FABRIK works by knowing the positions and lengths of a series of bones, typically called a "bone chain". It first starts by running a forward pass, which places the final bone at the target's position. Then all other bones are moved towards the tip bone, so they stay at the defined bone length away. Then a backwards pass is performed, where the root/first bone in the FABRIK chain is placed back at the origin. Then all other bones are moved so they stay at the defined bone length away. This positions the bone chain so that it reaches the target when possible, but all of the bones stay the correct length away from each other.</para>
/// <para>Because of how FABRIK works, it often gives more natural results than those seen in <see cref="Godot.SkeletonModification2DCcdik"/>.</para>
/// <para><b>Note:</b> The FABRIK modifier has <c>fabrik_joints</c>, which are the data objects that hold the data for each joint in the FABRIK chain. This is different from <see cref="Godot.Bone2D"/> nodes! FABRIK joints hold the data needed for each <see cref="Godot.Bone2D"/> in the bone chain used by FABRIK.</para>
/// <para>To help control how the FABRIK joints move, a magnet vector can be passed, which can nudge the bones in a certain direction prior to solving, giving a level of control over the final result.</para>
/// </summary>
[GodotClassName("SkeletonModification2DFABRIK")]
public partial class SkeletonModification2DFabrik : SkeletonModification2D
{
    /// <summary>
    /// <para>The NodePath to the node that is the target for the FABRIK modification. This node is what the FABRIK chain will attempt to rotate the bone chain to.</para>
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
    /// <para>The number of FABRIK joints in the FABRIK modification.</para>
    /// </summary>
    public int FabrikDataChainLength
    {
        get
        {
            return GetFabrikDataChainLength();
        }
        set
        {
            SetFabrikDataChainLength(value);
        }
    }

    private static readonly System.Type CachedType = typeof(SkeletonModification2DFabrik);

    private static readonly StringName NativeName = "SkeletonModification2DFABRIK";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public SkeletonModification2DFabrik() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal SkeletonModification2DFabrik(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal SkeletonModification2DFabrik(bool memoryOwn) : base(memoryOwn) { }

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
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFabrikDataChainLength, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFabrikDataChainLength(int length)
    {
        NativeCalls.godot_icall_1_38(MethodBind2, GodotObject.GetPtr(this), length);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFabrikDataChainLength, 2455072627ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetFabrikDataChainLength()
    {
        return NativeCalls.godot_icall_0_39(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFabrikJointBone2DNode, 2761262315ul);

    /// <summary>
    /// <para>Sets the <see cref="Godot.Bone2D"/> node assigned to the FABRIK joint at <paramref name="jointIdx"/>.</para>
    /// </summary>
    public void SetFabrikJointBone2DNode(int jointIdx, NodePath bone2DNodePath)
    {
        NativeCalls.godot_icall_2_75(MethodBind4, GodotObject.GetPtr(this), jointIdx, (godot_node_path)(bone2DNodePath?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFabrikJointBone2DNode, 408788394ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.Bone2D"/> node assigned to the FABRIK joint at <paramref name="jointIdx"/>.</para>
    /// </summary>
    public NodePath GetFabrikJointBone2DNode(int jointIdx)
    {
        return NativeCalls.godot_icall_1_74(MethodBind5, GodotObject.GetPtr(this), jointIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFabrikJointBoneIndex, 3937882851ul);

    /// <summary>
    /// <para>Sets the bone index, <paramref name="boneIdx"/>, of the FABRIK joint at <paramref name="jointIdx"/>. When possible, this will also update the <c>bone2d_node</c> of the FABRIK joint based on data provided by the linked skeleton.</para>
    /// </summary>
    public void SetFabrikJointBoneIndex(int jointIdx, int boneIdx)
    {
        NativeCalls.godot_icall_2_59(MethodBind6, GodotObject.GetPtr(this), jointIdx, boneIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFabrikJointBoneIndex, 923996154ul);

    /// <summary>
    /// <para>Returns the index of the <see cref="Godot.Bone2D"/> node assigned to the FABRIK joint at <paramref name="jointIdx"/>.</para>
    /// </summary>
    public int GetFabrikJointBoneIndex(int jointIdx)
    {
        return NativeCalls.godot_icall_1_60(MethodBind7, GodotObject.GetPtr(this), jointIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFabrikJointMagnetPosition, 163021252ul);

    /// <summary>
    /// <para>Sets the magnet position vector for the joint at <paramref name="jointIdx"/>.</para>
    /// </summary>
    public unsafe void SetFabrikJointMagnetPosition(int jointIdx, Vector2 magnetPosition)
    {
        NativeCalls.godot_icall_2_147(MethodBind8, GodotObject.GetPtr(this), jointIdx, &magnetPosition);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFabrikJointMagnetPosition, 2299179447ul);

    /// <summary>
    /// <para>Returns the magnet position vector for the joint at <paramref name="jointIdx"/>.</para>
    /// </summary>
    public Vector2 GetFabrikJointMagnetPosition(int jointIdx)
    {
        return NativeCalls.godot_icall_1_148(MethodBind9, GodotObject.GetPtr(this), jointIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFabrikJointUseTargetRotation, 300928843ul);

    /// <summary>
    /// <para>Sets whether the joint at <paramref name="jointIdx"/> will use the target node's rotation rather than letting FABRIK rotate the node.</para>
    /// <para><b>Note:</b> This option only works for the tip/final joint in the chain. For all other nodes, this option will be ignored.</para>
    /// </summary>
    public void SetFabrikJointUseTargetRotation(int jointIdx, bool useTargetRotation)
    {
        NativeCalls.godot_icall_2_61(MethodBind10, GodotObject.GetPtr(this), jointIdx, useTargetRotation.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFabrikJointUseTargetRotation, 1116898809ul);

    /// <summary>
    /// <para>Returns whether the joint is using the target's rotation rather than allowing FABRIK to rotate the joint. This option only applies to the tip/final joint in the chain.</para>
    /// </summary>
    public bool GetFabrikJointUseTargetRotation(int jointIdx)
    {
        return NativeCalls.godot_icall_1_62(MethodBind11, GodotObject.GetPtr(this), jointIdx).ToBool();
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
        /// Cached name for the 'fabrik_data_chain_length' property.
        /// </summary>
        public static readonly StringName FabrikDataChainLength = "fabrik_data_chain_length";
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
        /// Cached name for the 'set_fabrik_data_chain_length' method.
        /// </summary>
        public static readonly StringName SetFabrikDataChainLength = "set_fabrik_data_chain_length";
        /// <summary>
        /// Cached name for the 'get_fabrik_data_chain_length' method.
        /// </summary>
        public static readonly StringName GetFabrikDataChainLength = "get_fabrik_data_chain_length";
        /// <summary>
        /// Cached name for the 'set_fabrik_joint_bone2d_node' method.
        /// </summary>
        public static readonly StringName SetFabrikJointBone2DNode = "set_fabrik_joint_bone2d_node";
        /// <summary>
        /// Cached name for the 'get_fabrik_joint_bone2d_node' method.
        /// </summary>
        public static readonly StringName GetFabrikJointBone2DNode = "get_fabrik_joint_bone2d_node";
        /// <summary>
        /// Cached name for the 'set_fabrik_joint_bone_index' method.
        /// </summary>
        public static readonly StringName SetFabrikJointBoneIndex = "set_fabrik_joint_bone_index";
        /// <summary>
        /// Cached name for the 'get_fabrik_joint_bone_index' method.
        /// </summary>
        public static readonly StringName GetFabrikJointBoneIndex = "get_fabrik_joint_bone_index";
        /// <summary>
        /// Cached name for the 'set_fabrik_joint_magnet_position' method.
        /// </summary>
        public static readonly StringName SetFabrikJointMagnetPosition = "set_fabrik_joint_magnet_position";
        /// <summary>
        /// Cached name for the 'get_fabrik_joint_magnet_position' method.
        /// </summary>
        public static readonly StringName GetFabrikJointMagnetPosition = "get_fabrik_joint_magnet_position";
        /// <summary>
        /// Cached name for the 'set_fabrik_joint_use_target_rotation' method.
        /// </summary>
        public static readonly StringName SetFabrikJointUseTargetRotation = "set_fabrik_joint_use_target_rotation";
        /// <summary>
        /// Cached name for the 'get_fabrik_joint_use_target_rotation' method.
        /// </summary>
        public static readonly StringName GetFabrikJointUseTargetRotation = "get_fabrik_joint_use_target_rotation";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : SkeletonModification2D.SignalName
    {
    }
}
