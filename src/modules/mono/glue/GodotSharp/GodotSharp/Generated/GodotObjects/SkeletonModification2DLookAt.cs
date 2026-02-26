namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This <see cref="Godot.SkeletonModification2D"/> rotates a bone to look a target. This is extremely helpful for moving character's head to look at the player, rotating a turret to look at a target, or any other case where you want to make a bone rotate towards something quickly and easily.</para>
/// </summary>
public partial class SkeletonModification2DLookAt : SkeletonModification2D
{
    /// <summary>
    /// <para>The index of the <see cref="Godot.Bone2D"/> node that the modification will operate on.</para>
    /// </summary>
    public int BoneIndex
    {
        get
        {
            return GetBoneIndex();
        }
        set
        {
            SetBoneIndex(value);
        }
    }

    /// <summary>
    /// <para>The <see cref="Godot.Bone2D"/> node that the modification will operate on.</para>
    /// </summary>
    public NodePath Bone2DNode
    {
        get
        {
            return GetBone2DNode();
        }
        set
        {
            SetBone2DNode(value);
        }
    }

    /// <summary>
    /// <para>The NodePath to the node that is the target for the LookAt modification. This node is what the modification will rotate the <see cref="Godot.Bone2D"/> to.</para>
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

    private static readonly System.Type CachedType = typeof(SkeletonModification2DLookAt);

    private static readonly StringName NativeName = "SkeletonModification2DLookAt";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public SkeletonModification2DLookAt() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal SkeletonModification2DLookAt(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal SkeletonModification2DLookAt(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBone2DNode, 1348162250ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetBone2DNode(NodePath bone2DNodePath)
    {
        NativeCalls.godot_icall_1_123(MethodBind0, GodotObject.GetPtr(this), (godot_node_path)(bone2DNodePath?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBone2DNode, 4075236667ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public NodePath GetBone2DNode()
    {
        return NativeCalls.godot_icall_0_124(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBoneIndex, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetBoneIndex(int boneIdx)
    {
        NativeCalls.godot_icall_1_38(MethodBind2, GodotObject.GetPtr(this), boneIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBoneIndex, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetBoneIndex()
    {
        return NativeCalls.godot_icall_0_39(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTargetNode, 1348162250ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTargetNode(NodePath targetNodePath)
    {
        NativeCalls.godot_icall_1_123(MethodBind4, GodotObject.GetPtr(this), (godot_node_path)(targetNodePath?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTargetNode, 4075236667ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public NodePath GetTargetNode()
    {
        return NativeCalls.godot_icall_0_124(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAdditionalRotation, 373806689ul);

    /// <summary>
    /// <para>Sets the amount of additional rotation that is to be applied after executing the modification. This allows for offsetting the results by the inputted rotation amount.</para>
    /// </summary>
    public void SetAdditionalRotation(float rotation)
    {
        NativeCalls.godot_icall_1_67(MethodBind6, GodotObject.GetPtr(this), rotation);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAdditionalRotation, 1740695150ul);

    /// <summary>
    /// <para>Returns the amount of additional rotation that is applied after the LookAt modification executes.</para>
    /// </summary>
    public float GetAdditionalRotation()
    {
        return NativeCalls.godot_icall_0_68(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEnableConstraint, 2586408642ul);

    /// <summary>
    /// <para>Sets whether this modification will use constraints or not. When <see langword="true"/>, constraints will be applied when solving the LookAt modification.</para>
    /// </summary>
    public void SetEnableConstraint(bool enableConstraint)
    {
        NativeCalls.godot_icall_1_14(MethodBind8, GodotObject.GetPtr(this), enableConstraint.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEnableConstraint, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the LookAt modification is using constraints.</para>
    /// </summary>
    public bool GetEnableConstraint()
    {
        return NativeCalls.godot_icall_0_15(MethodBind9, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetConstraintAngleMin, 373806689ul);

    /// <summary>
    /// <para>Sets the constraint's minimum allowed angle.</para>
    /// </summary>
    public void SetConstraintAngleMin(float angleMin)
    {
        NativeCalls.godot_icall_1_67(MethodBind10, GodotObject.GetPtr(this), angleMin);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetConstraintAngleMin, 1740695150ul);

    /// <summary>
    /// <para>Returns the constraint's minimum allowed angle.</para>
    /// </summary>
    public float GetConstraintAngleMin()
    {
        return NativeCalls.godot_icall_0_68(MethodBind11, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetConstraintAngleMax, 373806689ul);

    /// <summary>
    /// <para>Sets the constraint's maximum allowed angle.</para>
    /// </summary>
    public void SetConstraintAngleMax(float angleMax)
    {
        NativeCalls.godot_icall_1_67(MethodBind12, GodotObject.GetPtr(this), angleMax);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetConstraintAngleMax, 1740695150ul);

    /// <summary>
    /// <para>Returns the constraint's maximum allowed angle.</para>
    /// </summary>
    public float GetConstraintAngleMax()
    {
        return NativeCalls.godot_icall_0_68(MethodBind13, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetConstraintAngleInvert, 2586408642ul);

    /// <summary>
    /// <para>When <see langword="true"/>, the modification will use an inverted joint constraint.</para>
    /// <para>An inverted joint constraint only constraints the <see cref="Godot.Bone2D"/> to the angles <i>outside of</i> the inputted minimum and maximum angles. For this reason, it is referred to as an inverted joint constraint, as it constraints the joint to the outside of the inputted values.</para>
    /// </summary>
    public void SetConstraintAngleInvert(bool invert)
    {
        NativeCalls.godot_icall_1_14(MethodBind14, GodotObject.GetPtr(this), invert.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetConstraintAngleInvert, 36873697ul);

    /// <summary>
    /// <para>Returns whether the constraints to this modification are inverted or not.</para>
    /// </summary>
    public bool GetConstraintAngleInvert()
    {
        return NativeCalls.godot_icall_0_15(MethodBind15, GodotObject.GetPtr(this)).ToBool();
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
        /// Cached name for the 'bone_index' property.
        /// </summary>
        public static readonly StringName BoneIndex = "bone_index";
        /// <summary>
        /// Cached name for the 'bone2d_node' property.
        /// </summary>
        public static readonly StringName Bone2DNode = "bone2d_node";
        /// <summary>
        /// Cached name for the 'target_nodepath' property.
        /// </summary>
        public static readonly StringName TargetNodePath = "target_nodepath";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : SkeletonModification2D.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_bone2d_node' method.
        /// </summary>
        public static readonly StringName SetBone2DNode = "set_bone2d_node";
        /// <summary>
        /// Cached name for the 'get_bone2d_node' method.
        /// </summary>
        public static readonly StringName GetBone2DNode = "get_bone2d_node";
        /// <summary>
        /// Cached name for the 'set_bone_index' method.
        /// </summary>
        public static readonly StringName SetBoneIndex = "set_bone_index";
        /// <summary>
        /// Cached name for the 'get_bone_index' method.
        /// </summary>
        public static readonly StringName GetBoneIndex = "get_bone_index";
        /// <summary>
        /// Cached name for the 'set_target_node' method.
        /// </summary>
        public static readonly StringName SetTargetNode = "set_target_node";
        /// <summary>
        /// Cached name for the 'get_target_node' method.
        /// </summary>
        public static readonly StringName GetTargetNode = "get_target_node";
        /// <summary>
        /// Cached name for the 'set_additional_rotation' method.
        /// </summary>
        public static readonly StringName SetAdditionalRotation = "set_additional_rotation";
        /// <summary>
        /// Cached name for the 'get_additional_rotation' method.
        /// </summary>
        public static readonly StringName GetAdditionalRotation = "get_additional_rotation";
        /// <summary>
        /// Cached name for the 'set_enable_constraint' method.
        /// </summary>
        public static readonly StringName SetEnableConstraint = "set_enable_constraint";
        /// <summary>
        /// Cached name for the 'get_enable_constraint' method.
        /// </summary>
        public static readonly StringName GetEnableConstraint = "get_enable_constraint";
        /// <summary>
        /// Cached name for the 'set_constraint_angle_min' method.
        /// </summary>
        public static readonly StringName SetConstraintAngleMin = "set_constraint_angle_min";
        /// <summary>
        /// Cached name for the 'get_constraint_angle_min' method.
        /// </summary>
        public static readonly StringName GetConstraintAngleMin = "get_constraint_angle_min";
        /// <summary>
        /// Cached name for the 'set_constraint_angle_max' method.
        /// </summary>
        public static readonly StringName SetConstraintAngleMax = "set_constraint_angle_max";
        /// <summary>
        /// Cached name for the 'get_constraint_angle_max' method.
        /// </summary>
        public static readonly StringName GetConstraintAngleMax = "get_constraint_angle_max";
        /// <summary>
        /// Cached name for the 'set_constraint_angle_invert' method.
        /// </summary>
        public static readonly StringName SetConstraintAngleInvert = "set_constraint_angle_invert";
        /// <summary>
        /// Cached name for the 'get_constraint_angle_invert' method.
        /// </summary>
        public static readonly StringName GetConstraintAngleInvert = "get_constraint_angle_invert";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : SkeletonModification2D.SignalName
    {
    }
}
