namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This <see cref="Godot.IKModifier3D"/> requires a pole target. It provides deterministic results by constructing a plane from each joint and pole target and finding the intersection of two circles (disks in 3D).</para>
/// <para>This IK can handle twist by setting the pole direction. If there are more than one bone between each set bone, their rotations are ignored, and the straight line connecting the root-middle and middle-end joints are treated as virtual bones.</para>
/// </summary>
public partial class TwoBoneIK3D : IKModifier3D
{
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

    private static readonly System.Type CachedType = typeof(TwoBoneIK3D);

    private static readonly StringName NativeName = "TwoBoneIK3D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public TwoBoneIK3D() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal TwoBoneIK3D(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal TwoBoneIK3D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTargetNode, 2761262315ul);

    /// <summary>
    /// <para>Sets the target node that the end bone is trying to reach.</para>
    /// </summary>
    public void SetTargetNode(int index, NodePath targetNode)
    {
        NativeCalls.godot_icall_2_75(MethodBind0, GodotObject.GetPtr(this), index, (godot_node_path)(targetNode?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTargetNode, 408788394ul);

    /// <summary>
    /// <para>Returns the target node that the end bone is trying to reach.</para>
    /// </summary>
    public NodePath GetTargetNode(int index)
    {
        return NativeCalls.godot_icall_1_74(MethodBind1, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPoleNode, 2761262315ul);

    /// <summary>
    /// <para>Sets the pole target node that constructs a plane which the joints are all on and the pole is trying to direct.</para>
    /// </summary>
    public void SetPoleNode(int index, NodePath poleNode)
    {
        NativeCalls.godot_icall_2_75(MethodBind2, GodotObject.GetPtr(this), index, (godot_node_path)(poleNode?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPoleNode, 408788394ul);

    /// <summary>
    /// <para>Returns the pole target node that constructs a plane which the joints are all on and the pole is trying to direct.</para>
    /// </summary>
    public NodePath GetPoleNode(int index)
    {
        return NativeCalls.godot_icall_1_74(MethodBind3, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRootBoneName, 501894301ul);

    /// <summary>
    /// <para>Sets the root bone name.</para>
    /// </summary>
    public void SetRootBoneName(int index, string boneName)
    {
        NativeCalls.godot_icall_2_181(MethodBind4, GodotObject.GetPtr(this), index, boneName);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRootBoneName, 844755477ul);

    /// <summary>
    /// <para>Returns the root bone name.</para>
    /// </summary>
    public string GetRootBoneName(int index)
    {
        return NativeCalls.godot_icall_1_133(MethodBind5, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRootBone, 3937882851ul);

    /// <summary>
    /// <para>Sets the root bone index.</para>
    /// </summary>
    public void SetRootBone(int index, int bone)
    {
        NativeCalls.godot_icall_2_59(MethodBind6, GodotObject.GetPtr(this), index, bone);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRootBone, 923996154ul);

    /// <summary>
    /// <para>Returns the root bone index.</para>
    /// </summary>
    public int GetRootBone(int index)
    {
        return NativeCalls.godot_icall_1_60(MethodBind7, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMiddleBoneName, 501894301ul);

    /// <summary>
    /// <para>Sets the middle bone name.</para>
    /// <para><b>Note:</b> The middle bone must be a child of the root bone.</para>
    /// </summary>
    public void SetMiddleBoneName(int index, string boneName)
    {
        NativeCalls.godot_icall_2_181(MethodBind8, GodotObject.GetPtr(this), index, boneName);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMiddleBoneName, 844755477ul);

    /// <summary>
    /// <para>Returns the middle bone name.</para>
    /// </summary>
    public string GetMiddleBoneName(int index)
    {
        return NativeCalls.godot_icall_1_133(MethodBind9, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMiddleBone, 3937882851ul);

    /// <summary>
    /// <para>Sets the middle bone index.</para>
    /// </summary>
    public void SetMiddleBone(int index, int bone)
    {
        NativeCalls.godot_icall_2_59(MethodBind10, GodotObject.GetPtr(this), index, bone);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMiddleBone, 923996154ul);

    /// <summary>
    /// <para>Returns the middle bone index.</para>
    /// </summary>
    public int GetMiddleBone(int index)
    {
        return NativeCalls.godot_icall_1_60(MethodBind11, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPoleDirection, 258741388ul);

    /// <summary>
    /// <para>Sets the pole direction.</para>
    /// <para>The pole is on the middle bone and will direct to the pole target.</para>
    /// <para>The rotation axis is a vector that is orthogonal to this and the forward vector.</para>
    /// <para><b>Note:</b> The pole direction and the forward vector shouldn't be colinear to avoid unintended rotation.</para>
    /// </summary>
    public void SetPoleDirection(int index, SkeletonModifier3D.SecondaryDirection direction)
    {
        NativeCalls.godot_icall_2_59(MethodBind12, GodotObject.GetPtr(this), index, (int)direction);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPoleDirection, 377522128ul);

    /// <summary>
    /// <para>Returns the pole direction.</para>
    /// </summary>
    public SkeletonModifier3D.SecondaryDirection GetPoleDirection(int index)
    {
        return (SkeletonModifier3D.SecondaryDirection)NativeCalls.godot_icall_1_60(MethodBind13, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPoleDirectionVector, 1530502735ul);

    /// <summary>
    /// <para>Sets the pole direction vector.</para>
    /// <para>This vector is normalized by an internal process.</para>
    /// <para>If the vector length is <c>0</c>, it is considered synonymous with <see cref="Godot.SkeletonModifier3D.SecondaryDirection.None"/>.</para>
    /// </summary>
    public unsafe void SetPoleDirectionVector(int index, Vector3 vector)
    {
        NativeCalls.godot_icall_2_362(MethodBind14, GodotObject.GetPtr(this), index, &vector);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPoleDirectionVector, 711720468ul);

    /// <summary>
    /// <para>Returns the pole direction vector.</para>
    /// <para>If <see cref="Godot.TwoBoneIK3D.GetPoleDirection(int)"/> is <see cref="Godot.SkeletonModifier3D.SecondaryDirection.None"/>, this method returns <c>Vector3(0, 0, 0)</c>.</para>
    /// </summary>
    public Vector3 GetPoleDirectionVector(int index)
    {
        return NativeCalls.godot_icall_1_363(MethodBind15, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEndBoneName, 501894301ul);

    /// <summary>
    /// <para>Sets the end bone name.</para>
    /// <para><b>Note:</b> The end bone must be a child of the middle bone.</para>
    /// </summary>
    public void SetEndBoneName(int index, string boneName)
    {
        NativeCalls.godot_icall_2_181(MethodBind16, GodotObject.GetPtr(this), index, boneName);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEndBoneName, 844755477ul);

    /// <summary>
    /// <para>Returns the end bone name.</para>
    /// </summary>
    public string GetEndBoneName(int index)
    {
        return NativeCalls.godot_icall_1_133(MethodBind17, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEndBone, 3937882851ul);

    /// <summary>
    /// <para>Sets the end bone index.</para>
    /// </summary>
    public void SetEndBone(int index, int bone)
    {
        NativeCalls.godot_icall_2_59(MethodBind18, GodotObject.GetPtr(this), index, bone);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEndBone, 923996154ul);

    /// <summary>
    /// <para>Returns the end bone index.</para>
    /// </summary>
    public int GetEndBone(int index)
    {
        return NativeCalls.godot_icall_1_60(MethodBind19, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetUseVirtualEnd, 300928843ul);

    /// <summary>
    /// <para>If <paramref name="enabled"/> is <see langword="true"/>, the end bone is extended from the middle bone as a virtual bone.</para>
    /// </summary>
    public void SetUseVirtualEnd(int index, bool enabled)
    {
        NativeCalls.godot_icall_2_61(MethodBind20, GodotObject.GetPtr(this), index, enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsUsingVirtualEnd, 1116898809ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the end bone is extended from the middle bone as a virtual bone.</para>
    /// </summary>
    public bool IsUsingVirtualEnd(int index)
    {
        return NativeCalls.godot_icall_1_62(MethodBind21, GodotObject.GetPtr(this), index).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetExtendEndBone, 300928843ul);

    /// <summary>
    /// <para>If <paramref name="enabled"/> is <see langword="true"/>, the end bone is extended to have a tail.</para>
    /// </summary>
    public void SetExtendEndBone(int index, bool enabled)
    {
        NativeCalls.godot_icall_2_61(MethodBind22, GodotObject.GetPtr(this), index, enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsEndBoneExtended, 1116898809ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the end bone is extended to have a tail.</para>
    /// </summary>
    public bool IsEndBoneExtended(int index)
    {
        return NativeCalls.godot_icall_1_62(MethodBind23, GodotObject.GetPtr(this), index).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEndBoneDirection, 2838484201ul);

    /// <summary>
    /// <para>Sets the end bone tail direction when <see cref="Godot.TwoBoneIK3D.IsEndBoneExtended(int)"/> is <see langword="true"/>.</para>
    /// </summary>
    public void SetEndBoneDirection(int index, SkeletonModifier3D.BoneDirection boneDirection)
    {
        NativeCalls.godot_icall_2_59(MethodBind24, GodotObject.GetPtr(this), index, (int)boneDirection);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEndBoneDirection, 1843036459ul);

    /// <summary>
    /// <para>Returns the end bone's tail direction when <see cref="Godot.TwoBoneIK3D.IsEndBoneExtended(int)"/> is <see langword="true"/>.</para>
    /// </summary>
    public SkeletonModifier3D.BoneDirection GetEndBoneDirection(int index)
    {
        return (SkeletonModifier3D.BoneDirection)NativeCalls.godot_icall_1_60(MethodBind25, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEndBoneLength, 1602489585ul);

    /// <summary>
    /// <para>Sets the end bone tail length when <see cref="Godot.TwoBoneIK3D.IsEndBoneExtended(int)"/> is <see langword="true"/>.</para>
    /// </summary>
    public void SetEndBoneLength(int index, float length)
    {
        NativeCalls.godot_icall_2_69(MethodBind26, GodotObject.GetPtr(this), index, length);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEndBoneLength, 2339986948ul);

    /// <summary>
    /// <para>Returns the end bone tail length of the bone chain when <see cref="Godot.TwoBoneIK3D.IsEndBoneExtended(int)"/> is <see langword="true"/>.</para>
    /// </summary>
    public float GetEndBoneLength(int index)
    {
        return NativeCalls.godot_icall_1_72(MethodBind27, GodotObject.GetPtr(this), index);
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
    public new class PropertyName : IKModifier3D.PropertyName
    {
        /// <summary>
        /// Cached name for the 'setting_count' property.
        /// </summary>
        public static readonly StringName SettingCount = "setting_count";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : IKModifier3D.MethodName
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
        /// Cached name for the 'set_pole_node' method.
        /// </summary>
        public static readonly StringName SetPoleNode = "set_pole_node";
        /// <summary>
        /// Cached name for the 'get_pole_node' method.
        /// </summary>
        public static readonly StringName GetPoleNode = "get_pole_node";
        /// <summary>
        /// Cached name for the 'set_root_bone_name' method.
        /// </summary>
        public static readonly StringName SetRootBoneName = "set_root_bone_name";
        /// <summary>
        /// Cached name for the 'get_root_bone_name' method.
        /// </summary>
        public static readonly StringName GetRootBoneName = "get_root_bone_name";
        /// <summary>
        /// Cached name for the 'set_root_bone' method.
        /// </summary>
        public static readonly StringName SetRootBone = "set_root_bone";
        /// <summary>
        /// Cached name for the 'get_root_bone' method.
        /// </summary>
        public static readonly StringName GetRootBone = "get_root_bone";
        /// <summary>
        /// Cached name for the 'set_middle_bone_name' method.
        /// </summary>
        public static readonly StringName SetMiddleBoneName = "set_middle_bone_name";
        /// <summary>
        /// Cached name for the 'get_middle_bone_name' method.
        /// </summary>
        public static readonly StringName GetMiddleBoneName = "get_middle_bone_name";
        /// <summary>
        /// Cached name for the 'set_middle_bone' method.
        /// </summary>
        public static readonly StringName SetMiddleBone = "set_middle_bone";
        /// <summary>
        /// Cached name for the 'get_middle_bone' method.
        /// </summary>
        public static readonly StringName GetMiddleBone = "get_middle_bone";
        /// <summary>
        /// Cached name for the 'set_pole_direction' method.
        /// </summary>
        public static readonly StringName SetPoleDirection = "set_pole_direction";
        /// <summary>
        /// Cached name for the 'get_pole_direction' method.
        /// </summary>
        public static readonly StringName GetPoleDirection = "get_pole_direction";
        /// <summary>
        /// Cached name for the 'set_pole_direction_vector' method.
        /// </summary>
        public static readonly StringName SetPoleDirectionVector = "set_pole_direction_vector";
        /// <summary>
        /// Cached name for the 'get_pole_direction_vector' method.
        /// </summary>
        public static readonly StringName GetPoleDirectionVector = "get_pole_direction_vector";
        /// <summary>
        /// Cached name for the 'set_end_bone_name' method.
        /// </summary>
        public static readonly StringName SetEndBoneName = "set_end_bone_name";
        /// <summary>
        /// Cached name for the 'get_end_bone_name' method.
        /// </summary>
        public static readonly StringName GetEndBoneName = "get_end_bone_name";
        /// <summary>
        /// Cached name for the 'set_end_bone' method.
        /// </summary>
        public static readonly StringName SetEndBone = "set_end_bone";
        /// <summary>
        /// Cached name for the 'get_end_bone' method.
        /// </summary>
        public static readonly StringName GetEndBone = "get_end_bone";
        /// <summary>
        /// Cached name for the 'set_use_virtual_end' method.
        /// </summary>
        public static readonly StringName SetUseVirtualEnd = "set_use_virtual_end";
        /// <summary>
        /// Cached name for the 'is_using_virtual_end' method.
        /// </summary>
        public static readonly StringName IsUsingVirtualEnd = "is_using_virtual_end";
        /// <summary>
        /// Cached name for the 'set_extend_end_bone' method.
        /// </summary>
        public static readonly StringName SetExtendEndBone = "set_extend_end_bone";
        /// <summary>
        /// Cached name for the 'is_end_bone_extended' method.
        /// </summary>
        public static readonly StringName IsEndBoneExtended = "is_end_bone_extended";
        /// <summary>
        /// Cached name for the 'set_end_bone_direction' method.
        /// </summary>
        public static readonly StringName SetEndBoneDirection = "set_end_bone_direction";
        /// <summary>
        /// Cached name for the 'get_end_bone_direction' method.
        /// </summary>
        public static readonly StringName GetEndBoneDirection = "get_end_bone_direction";
        /// <summary>
        /// Cached name for the 'set_end_bone_length' method.
        /// </summary>
        public static readonly StringName SetEndBoneLength = "set_end_bone_length";
        /// <summary>
        /// Cached name for the 'get_end_bone_length' method.
        /// </summary>
        public static readonly StringName GetEndBoneLength = "get_end_bone_length";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : IKModifier3D.SignalName
    {
    }
}
