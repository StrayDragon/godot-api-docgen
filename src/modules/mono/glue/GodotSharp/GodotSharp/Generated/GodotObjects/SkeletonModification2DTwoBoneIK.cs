namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This <see cref="Godot.SkeletonModification2D"/> uses an algorithm typically called TwoBoneIK. This algorithm works by leveraging the law of cosines and the lengths of the bones to figure out what rotation the bones currently have, and what rotation they need to make a complete triangle, where the first bone, the second bone, and the target form the three vertices of the triangle. Because the algorithm works by making a triangle, it can only operate on two bones.</para>
/// <para>TwoBoneIK is great for arms, legs, and really any joints that can be represented by just two bones that bend to reach a target. This solver is more lightweight than <see cref="Godot.SkeletonModification2DFabrik"/>, but gives similar, natural looking results.</para>
/// </summary>
public partial class SkeletonModification2DTwoBoneIK : SkeletonModification2D
{
    /// <summary>
    /// <para>The NodePath to the node that is the target for the TwoBoneIK modification. This node is what the modification will use when bending the <see cref="Godot.Bone2D"/> nodes.</para>
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
    /// <para>The minimum distance the target can be at. If the target is closer than this distance, the modification will solve as if it's at this minimum distance. When set to <c>0</c>, the modification will solve without distance constraints.</para>
    /// </summary>
    public float TargetMinimumDistance
    {
        get
        {
            return GetTargetMinimumDistance();
        }
        set
        {
            SetTargetMinimumDistance(value);
        }
    }

    /// <summary>
    /// <para>The maximum distance the target can be at. If the target is farther than this distance, the modification will solve as if it's at this maximum distance. When set to <c>0</c>, the modification will solve without distance constraints.</para>
    /// </summary>
    public float TargetMaximumDistance
    {
        get
        {
            return GetTargetMaximumDistance();
        }
        set
        {
            SetTargetMaximumDistance(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the bones in the modification will bend outward as opposed to inwards when contracting. If <see langword="false"/>, the bones will bend inwards when contracting.</para>
    /// </summary>
    public bool FlipBendDirection
    {
        get
        {
            return GetFlipBendDirection();
        }
        set
        {
            SetFlipBendDirection(value);
        }
    }

    private static readonly System.Type CachedType = typeof(SkeletonModification2DTwoBoneIK);

    private static readonly StringName NativeName = "SkeletonModification2DTwoBoneIK";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public SkeletonModification2DTwoBoneIK() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal SkeletonModification2DTwoBoneIK(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal SkeletonModification2DTwoBoneIK(bool memoryOwn) : base(memoryOwn) { }

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
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTargetMinimumDistance, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTargetMinimumDistance(float minimumDistance)
    {
        NativeCalls.godot_icall_1_67(MethodBind2, GodotObject.GetPtr(this), minimumDistance);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTargetMinimumDistance, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetTargetMinimumDistance()
    {
        return NativeCalls.godot_icall_0_68(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTargetMaximumDistance, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTargetMaximumDistance(float maximumDistance)
    {
        NativeCalls.godot_icall_1_67(MethodBind4, GodotObject.GetPtr(this), maximumDistance);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTargetMaximumDistance, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetTargetMaximumDistance()
    {
        return NativeCalls.godot_icall_0_68(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFlipBendDirection, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFlipBendDirection(bool flipDirection)
    {
        NativeCalls.godot_icall_1_14(MethodBind6, GodotObject.GetPtr(this), flipDirection.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFlipBendDirection, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetFlipBendDirection()
    {
        return NativeCalls.godot_icall_0_15(MethodBind7, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetJointOneBone2DNode, 1348162250ul);

    /// <summary>
    /// <para>Sets the <see cref="Godot.Bone2D"/> node that is being used as the first bone in the TwoBoneIK modification.</para>
    /// </summary>
    public void SetJointOneBone2DNode(NodePath bone2DNode)
    {
        NativeCalls.godot_icall_1_123(MethodBind8, GodotObject.GetPtr(this), (godot_node_path)(bone2DNode?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetJointOneBone2DNode, 4075236667ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.Bone2D"/> node that is being used as the first bone in the TwoBoneIK modification.</para>
    /// </summary>
    public NodePath GetJointOneBone2DNode()
    {
        return NativeCalls.godot_icall_0_124(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetJointOneBoneIdx, 1286410249ul);

    /// <summary>
    /// <para>Sets the index of the <see cref="Godot.Bone2D"/> node that is being used as the first bone in the TwoBoneIK modification.</para>
    /// </summary>
    public void SetJointOneBoneIdx(int boneIdx)
    {
        NativeCalls.godot_icall_1_38(MethodBind10, GodotObject.GetPtr(this), boneIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetJointOneBoneIdx, 3905245786ul);

    /// <summary>
    /// <para>Returns the index of the <see cref="Godot.Bone2D"/> node that is being used as the first bone in the TwoBoneIK modification.</para>
    /// </summary>
    public int GetJointOneBoneIdx()
    {
        return NativeCalls.godot_icall_0_39(MethodBind11, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetJointTwoBone2DNode, 1348162250ul);

    /// <summary>
    /// <para>Sets the <see cref="Godot.Bone2D"/> node that is being used as the second bone in the TwoBoneIK modification.</para>
    /// </summary>
    public void SetJointTwoBone2DNode(NodePath bone2DNode)
    {
        NativeCalls.godot_icall_1_123(MethodBind12, GodotObject.GetPtr(this), (godot_node_path)(bone2DNode?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetJointTwoBone2DNode, 4075236667ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.Bone2D"/> node that is being used as the second bone in the TwoBoneIK modification.</para>
    /// </summary>
    public NodePath GetJointTwoBone2DNode()
    {
        return NativeCalls.godot_icall_0_124(MethodBind13, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetJointTwoBoneIdx, 1286410249ul);

    /// <summary>
    /// <para>Sets the index of the <see cref="Godot.Bone2D"/> node that is being used as the second bone in the TwoBoneIK modification.</para>
    /// </summary>
    public void SetJointTwoBoneIdx(int boneIdx)
    {
        NativeCalls.godot_icall_1_38(MethodBind14, GodotObject.GetPtr(this), boneIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetJointTwoBoneIdx, 3905245786ul);

    /// <summary>
    /// <para>Returns the index of the <see cref="Godot.Bone2D"/> node that is being used as the second bone in the TwoBoneIK modification.</para>
    /// </summary>
    public int GetJointTwoBoneIdx()
    {
        return NativeCalls.godot_icall_0_39(MethodBind15, GodotObject.GetPtr(this));
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
        /// Cached name for the 'target_minimum_distance' property.
        /// </summary>
        public static readonly StringName TargetMinimumDistance = "target_minimum_distance";
        /// <summary>
        /// Cached name for the 'target_maximum_distance' property.
        /// </summary>
        public static readonly StringName TargetMaximumDistance = "target_maximum_distance";
        /// <summary>
        /// Cached name for the 'flip_bend_direction' property.
        /// </summary>
        public static readonly StringName FlipBendDirection = "flip_bend_direction";
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
        /// Cached name for the 'set_target_minimum_distance' method.
        /// </summary>
        public static readonly StringName SetTargetMinimumDistance = "set_target_minimum_distance";
        /// <summary>
        /// Cached name for the 'get_target_minimum_distance' method.
        /// </summary>
        public static readonly StringName GetTargetMinimumDistance = "get_target_minimum_distance";
        /// <summary>
        /// Cached name for the 'set_target_maximum_distance' method.
        /// </summary>
        public static readonly StringName SetTargetMaximumDistance = "set_target_maximum_distance";
        /// <summary>
        /// Cached name for the 'get_target_maximum_distance' method.
        /// </summary>
        public static readonly StringName GetTargetMaximumDistance = "get_target_maximum_distance";
        /// <summary>
        /// Cached name for the 'set_flip_bend_direction' method.
        /// </summary>
        public static readonly StringName SetFlipBendDirection = "set_flip_bend_direction";
        /// <summary>
        /// Cached name for the 'get_flip_bend_direction' method.
        /// </summary>
        public static readonly StringName GetFlipBendDirection = "get_flip_bend_direction";
        /// <summary>
        /// Cached name for the 'set_joint_one_bone2d_node' method.
        /// </summary>
        public static readonly StringName SetJointOneBone2DNode = "set_joint_one_bone2d_node";
        /// <summary>
        /// Cached name for the 'get_joint_one_bone2d_node' method.
        /// </summary>
        public static readonly StringName GetJointOneBone2DNode = "get_joint_one_bone2d_node";
        /// <summary>
        /// Cached name for the 'set_joint_one_bone_idx' method.
        /// </summary>
        public static readonly StringName SetJointOneBoneIdx = "set_joint_one_bone_idx";
        /// <summary>
        /// Cached name for the 'get_joint_one_bone_idx' method.
        /// </summary>
        public static readonly StringName GetJointOneBoneIdx = "get_joint_one_bone_idx";
        /// <summary>
        /// Cached name for the 'set_joint_two_bone2d_node' method.
        /// </summary>
        public static readonly StringName SetJointTwoBone2DNode = "set_joint_two_bone2d_node";
        /// <summary>
        /// Cached name for the 'get_joint_two_bone2d_node' method.
        /// </summary>
        public static readonly StringName GetJointTwoBone2DNode = "get_joint_two_bone2d_node";
        /// <summary>
        /// Cached name for the 'set_joint_two_bone_idx' method.
        /// </summary>
        public static readonly StringName SetJointTwoBoneIdx = "set_joint_two_bone_idx";
        /// <summary>
        /// Cached name for the 'get_joint_two_bone_idx' method.
        /// </summary>
        public static readonly StringName GetJointTwoBoneIdx = "get_joint_two_bone_idx";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : SkeletonModification2D.SignalName
    {
    }
}
