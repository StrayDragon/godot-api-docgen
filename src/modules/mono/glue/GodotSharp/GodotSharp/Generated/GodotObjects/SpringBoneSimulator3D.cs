namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This <see cref="Godot.SkeletonModifier3D"/> can be used to wiggle hair, cloth, and tails. This modifier behaves differently from <see cref="Godot.PhysicalBoneSimulator3D"/> as it attempts to return the original pose after modification.</para>
/// <para>If you setup <see cref="Godot.SpringBoneSimulator3D.SetRootBone(int, int)"/> and <see cref="Godot.SpringBoneSimulator3D.SetEndBone(int, int)"/>, it is treated as one bone chain. Note that it does not support a branched chain like Y-shaped chains.</para>
/// <para>When a bone chain is created, an array is generated from the bones that exist in between and listed in the joint list.</para>
/// <para>Several properties can be applied to each joint, such as <see cref="Godot.SpringBoneSimulator3D.SetJointStiffness(int, int, float)"/>, <see cref="Godot.SpringBoneSimulator3D.SetJointDrag(int, int, float)"/>, and <see cref="Godot.SpringBoneSimulator3D.SetJointGravity(int, int, float)"/>.</para>
/// <para>For simplicity, you can set values to all joints at the same time by using a <see cref="Godot.Curve"/>. If you want to specify detailed values individually, set <see cref="Godot.SpringBoneSimulator3D.SetIndividualConfig(int, bool)"/> to <see langword="true"/>.</para>
/// <para>For physical simulation, <see cref="Godot.SpringBoneSimulator3D"/> can have children as self-standing collisions that are not related to <see cref="Godot.PhysicsServer3D"/>, see also <see cref="Godot.SpringBoneCollision3D"/>.</para>
/// <para><b>Warning:</b> A scaled <see cref="Godot.SpringBoneSimulator3D"/> will likely not behave as expected. Make sure that the parent <see cref="Godot.Skeleton3D"/> and its bones are not scaled.</para>
/// </summary>
public partial class SpringBoneSimulator3D : SkeletonModifier3D
{
    public enum CenterFrom : long
    {
        /// <summary>
        /// <para>The world origin is defined as center.</para>
        /// </summary>
        WorldOrigin = 0,
        /// <summary>
        /// <para>The <see cref="Godot.Node3D"/> specified by <see cref="Godot.SpringBoneSimulator3D.SetCenterNode(int, NodePath)"/> is defined as center.</para>
        /// <para>If <see cref="Godot.Node3D"/> is not found, the parent <see cref="Godot.Skeleton3D"/> is treated as center.</para>
        /// </summary>
        Node = 1,
        /// <summary>
        /// <para>The bone pose origin of the parent <see cref="Godot.Skeleton3D"/> specified by <see cref="Godot.SpringBoneSimulator3D.SetCenterBone(int, int)"/> is defined as center.</para>
        /// <para>If <see cref="Godot.Node3D"/> is not found, the parent <see cref="Godot.Skeleton3D"/> is treated as center.</para>
        /// </summary>
        Bone = 2
    }

    /// <summary>
    /// <para>The constant force that always affected bones. It is equal to the result when the parent <see cref="Godot.Skeleton3D"/> moves at this speed in the opposite direction.</para>
    /// <para>This is useful for effects such as wind and anti-gravity.</para>
    /// </summary>
    public Vector3 ExternalForce
    {
        get
        {
            return GetExternalForce();
        }
        set
        {
            SetExternalForce(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the solver retrieves the bone axis from the bone pose every frame.</para>
    /// <para>If <see langword="false"/>, the solver retrieves the bone axis from the bone rest and caches it, which increases performance slightly, but position changes in the bone pose made before processing this <see cref="Godot.SpringBoneSimulator3D"/> are ignored.</para>
    /// </summary>
    public bool MutableBoneAxes
    {
        get
        {
            return AreBoneAxesMutable();
        }
        set
        {
            SetMutableBoneAxes(value);
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

    private static readonly System.Type CachedType = typeof(SpringBoneSimulator3D);

    private static readonly StringName NativeName = "SpringBoneSimulator3D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public SpringBoneSimulator3D() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal SpringBoneSimulator3D(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal SpringBoneSimulator3D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRootBoneName, 501894301ul);

    /// <summary>
    /// <para>Sets the root bone name of the bone chain.</para>
    /// </summary>
    public void SetRootBoneName(int index, string boneName)
    {
        NativeCalls.godot_icall_2_181(MethodBind0, GodotObject.GetPtr(this), index, boneName);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRootBoneName, 844755477ul);

    /// <summary>
    /// <para>Returns the root bone name of the bone chain.</para>
    /// </summary>
    public string GetRootBoneName(int index)
    {
        return NativeCalls.godot_icall_1_133(MethodBind1, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRootBone, 3937882851ul);

    /// <summary>
    /// <para>Sets the root bone index of the bone chain.</para>
    /// </summary>
    public void SetRootBone(int index, int bone)
    {
        NativeCalls.godot_icall_2_59(MethodBind2, GodotObject.GetPtr(this), index, bone);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRootBone, 923996154ul);

    /// <summary>
    /// <para>Returns the root bone index of the bone chain.</para>
    /// </summary>
    public int GetRootBone(int index)
    {
        return NativeCalls.godot_icall_1_60(MethodBind3, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEndBoneName, 501894301ul);

    /// <summary>
    /// <para>Sets the end bone name of the bone chain.</para>
    /// <para><b>Note:</b> End bone must be the root bone or a child of the root bone. If they are the same, the tail must be extended by <see cref="Godot.SpringBoneSimulator3D.SetExtendEndBone(int, bool)"/> to jiggle the bone.</para>
    /// </summary>
    public void SetEndBoneName(int index, string boneName)
    {
        NativeCalls.godot_icall_2_181(MethodBind4, GodotObject.GetPtr(this), index, boneName);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEndBoneName, 844755477ul);

    /// <summary>
    /// <para>Returns the end bone name of the bone chain.</para>
    /// </summary>
    public string GetEndBoneName(int index)
    {
        return NativeCalls.godot_icall_1_133(MethodBind5, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEndBone, 3937882851ul);

    /// <summary>
    /// <para>Sets the end bone index of the bone chain.</para>
    /// </summary>
    public void SetEndBone(int index, int bone)
    {
        NativeCalls.godot_icall_2_59(MethodBind6, GodotObject.GetPtr(this), index, bone);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEndBone, 923996154ul);

    /// <summary>
    /// <para>Returns the end bone index of the bone chain.</para>
    /// </summary>
    public int GetEndBone(int index)
    {
        return NativeCalls.godot_icall_1_60(MethodBind7, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetExtendEndBone, 300928843ul);

    /// <summary>
    /// <para>If <paramref name="enabled"/> is <see langword="true"/>, the end bone is extended to have a tail.</para>
    /// <para>The extended tail config is allocated to the last element in the joint list. In other words, if you set <paramref name="enabled"/> to <see langword="false"/>, the config of the last element in the joint list has no effect in the simulated result.</para>
    /// </summary>
    public void SetExtendEndBone(int index, bool enabled)
    {
        NativeCalls.godot_icall_2_61(MethodBind8, GodotObject.GetPtr(this), index, enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsEndBoneExtended, 1116898809ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the end bone is extended to have a tail.</para>
    /// </summary>
    public bool IsEndBoneExtended(int index)
    {
        return NativeCalls.godot_icall_1_62(MethodBind9, GodotObject.GetPtr(this), index).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEndBoneDirection, 2838484201ul);

    /// <summary>
    /// <para>Sets the end bone tail direction of the bone chain when <see cref="Godot.SpringBoneSimulator3D.IsEndBoneExtended(int)"/> is <see langword="true"/>.</para>
    /// </summary>
    public void SetEndBoneDirection(int index, SkeletonModifier3D.BoneDirection boneDirection)
    {
        NativeCalls.godot_icall_2_59(MethodBind10, GodotObject.GetPtr(this), index, (int)boneDirection);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEndBoneDirection, 1843036459ul);

    /// <summary>
    /// <para>Returns the tail direction of the end bone of the bone chain when <see cref="Godot.SpringBoneSimulator3D.IsEndBoneExtended(int)"/> is <see langword="true"/>.</para>
    /// </summary>
    public SkeletonModifier3D.BoneDirection GetEndBoneDirection(int index)
    {
        return (SkeletonModifier3D.BoneDirection)NativeCalls.godot_icall_1_60(MethodBind11, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEndBoneLength, 1602489585ul);

    /// <summary>
    /// <para>Sets the end bone tail length of the bone chain when <see cref="Godot.SpringBoneSimulator3D.IsEndBoneExtended(int)"/> is <see langword="true"/>.</para>
    /// </summary>
    public void SetEndBoneLength(int index, float length)
    {
        NativeCalls.godot_icall_2_69(MethodBind12, GodotObject.GetPtr(this), index, length);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEndBoneLength, 2339986948ul);

    /// <summary>
    /// <para>Returns the end bone tail length of the bone chain when <see cref="Godot.SpringBoneSimulator3D.IsEndBoneExtended(int)"/> is <see langword="true"/>.</para>
    /// </summary>
    public float GetEndBoneLength(int index)
    {
        return NativeCalls.godot_icall_1_72(MethodBind13, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCenterFrom, 2551505749ul);

    /// <summary>
    /// <para>Sets what the center originates from in the bone chain.</para>
    /// <para>Bone movement is calculated based on the difference in relative distance between center and bone in the previous and next frames.</para>
    /// <para>For example, if the parent <see cref="Godot.Skeleton3D"/> is used as the center, the bones are considered to have not moved if the <see cref="Godot.Skeleton3D"/> moves in the world.</para>
    /// <para>In this case, only a change in the bone pose is considered to be a bone movement.</para>
    /// </summary>
    public void SetCenterFrom(int index, SpringBoneSimulator3D.CenterFrom centerFrom)
    {
        NativeCalls.godot_icall_2_59(MethodBind14, GodotObject.GetPtr(this), index, (int)centerFrom);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCenterFrom, 2721930813ul);

    /// <summary>
    /// <para>Returns what the center originates from in the bone chain.</para>
    /// </summary>
    public SpringBoneSimulator3D.CenterFrom GetCenterFrom(int index)
    {
        return (SpringBoneSimulator3D.CenterFrom)NativeCalls.godot_icall_1_60(MethodBind15, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCenterNode, 2761262315ul);

    /// <summary>
    /// <para>Sets the center node path of the bone chain.</para>
    /// </summary>
    public void SetCenterNode(int index, NodePath nodePath)
    {
        NativeCalls.godot_icall_2_75(MethodBind16, GodotObject.GetPtr(this), index, (godot_node_path)(nodePath?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCenterNode, 408788394ul);

    /// <summary>
    /// <para>Returns the center node path of the bone chain.</para>
    /// </summary>
    public NodePath GetCenterNode(int index)
    {
        return NativeCalls.godot_icall_1_74(MethodBind17, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCenterBoneName, 501894301ul);

    /// <summary>
    /// <para>Sets the center bone name of the bone chain.</para>
    /// </summary>
    public void SetCenterBoneName(int index, string boneName)
    {
        NativeCalls.godot_icall_2_181(MethodBind18, GodotObject.GetPtr(this), index, boneName);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCenterBoneName, 844755477ul);

    /// <summary>
    /// <para>Returns the center bone name of the bone chain.</para>
    /// </summary>
    public string GetCenterBoneName(int index)
    {
        return NativeCalls.godot_icall_1_133(MethodBind19, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCenterBone, 3937882851ul);

    /// <summary>
    /// <para>Sets the center bone index of the bone chain.</para>
    /// </summary>
    public void SetCenterBone(int index, int bone)
    {
        NativeCalls.godot_icall_2_59(MethodBind20, GodotObject.GetPtr(this), index, bone);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCenterBone, 923996154ul);

    /// <summary>
    /// <para>Returns the center bone index of the bone chain.</para>
    /// </summary>
    public int GetCenterBone(int index)
    {
        return NativeCalls.godot_icall_1_60(MethodBind21, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRadius, 1602489585ul);

    /// <summary>
    /// <para>Sets the joint radius of the bone chain. It is used to move and slide with the <see cref="Godot.SpringBoneCollision3D"/> in the collision list.</para>
    /// <para>The value is scaled by <see cref="Godot.SpringBoneSimulator3D.SetRadiusDampingCurve(int, Curve)"/> and cached in each joint setting in the joint list.</para>
    /// </summary>
    public void SetRadius(int index, float radius)
    {
        NativeCalls.godot_icall_2_69(MethodBind22, GodotObject.GetPtr(this), index, radius);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRadius, 2339986948ul);

    /// <summary>
    /// <para>Returns the joint radius of the bone chain.</para>
    /// </summary>
    public float GetRadius(int index)
    {
        return NativeCalls.godot_icall_1_72(MethodBind23, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRotationAxis, 1539703856ul);

    /// <summary>
    /// <para>Sets the rotation axis of the bone chain. If set to a specific axis, it acts like a hinge joint. The value is cached in each joint setting in the joint list.</para>
    /// <para>The axes are based on the <see cref="Godot.Skeleton3D.GetBoneRest(int)"/>'s space, if <paramref name="axis"/> is <see cref="Godot.SkeletonModifier3D.RotationAxis.Custom"/>, you can specify any axis.</para>
    /// <para><b>Note:</b> The rotation axis vector and the forward vector shouldn't be colinear to avoid unintended rotation since <see cref="Godot.SpringBoneSimulator3D"/> does not factor in twisting forces.</para>
    /// </summary>
    public void SetRotationAxis(int index, SkeletonModifier3D.RotationAxis axis)
    {
        NativeCalls.godot_icall_2_59(MethodBind24, GodotObject.GetPtr(this), index, (int)axis);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRotationAxis, 2844851118ul);

    /// <summary>
    /// <para>Returns the rotation axis of the bone chain.</para>
    /// </summary>
    public SkeletonModifier3D.RotationAxis GetRotationAxis(int index)
    {
        return (SkeletonModifier3D.RotationAxis)NativeCalls.godot_icall_1_60(MethodBind25, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRotationAxisVector, 1530502735ul);

    /// <summary>
    /// <para>Sets the rotation axis vector of the bone chain. The value is cached in each joint setting in the joint list.</para>
    /// <para>This vector is normalized by an internal process and represents the axis around which the bone chain can rotate.</para>
    /// <para>If the vector length is <c>0</c>, it is considered synonymous with <see cref="Godot.SkeletonModifier3D.RotationAxis.All"/>.</para>
    /// </summary>
    public unsafe void SetRotationAxisVector(int index, Vector3 vector)
    {
        NativeCalls.godot_icall_2_362(MethodBind26, GodotObject.GetPtr(this), index, &vector);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRotationAxisVector, 711720468ul);

    /// <summary>
    /// <para>Returns the rotation axis vector of the bone chain. This vector represents the axis around which the bone chain can rotate. It is determined based on the rotation axis set for the bone chain.</para>
    /// <para>If <see cref="Godot.SpringBoneSimulator3D.GetRotationAxis(int)"/> is <see cref="Godot.SkeletonModifier3D.RotationAxis.All"/>, this method returns <c>Vector3(0, 0, 0)</c>.</para>
    /// </summary>
    public Vector3 GetRotationAxisVector(int index)
    {
        return NativeCalls.godot_icall_1_363(MethodBind27, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRadiusDampingCurve, 1447180063ul);

    /// <summary>
    /// <para>Sets the joint radius damping curve of the bone chain.</para>
    /// </summary>
    public void SetRadiusDampingCurve(int index, Curve curve)
    {
        NativeCalls.godot_icall_2_70(MethodBind28, GodotObject.GetPtr(this), index, GodotObject.GetPtr(curve));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRadiusDampingCurve, 747537754ul);

    /// <summary>
    /// <para>Returns the joint radius damping curve of the bone chain.</para>
    /// </summary>
    public Curve GetRadiusDampingCurve(int index)
    {
        return (Curve)NativeCalls.godot_icall_1_71(MethodBind29, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetStiffness, 1602489585ul);

    /// <summary>
    /// <para>Sets the stiffness force of the bone chain. The greater the value, the faster it recovers to its initial pose.</para>
    /// <para>If <paramref name="stiffness"/> is <c>0</c>, the modified pose will not return to the original pose.</para>
    /// <para>The value is scaled by <see cref="Godot.SpringBoneSimulator3D.SetStiffnessDampingCurve(int, Curve)"/> and cached in each joint setting in the joint list.</para>
    /// </summary>
    public void SetStiffness(int index, float stiffness)
    {
        NativeCalls.godot_icall_2_69(MethodBind30, GodotObject.GetPtr(this), index, stiffness);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetStiffness, 2339986948ul);

    /// <summary>
    /// <para>Returns the stiffness force of the bone chain.</para>
    /// </summary>
    public float GetStiffness(int index)
    {
        return NativeCalls.godot_icall_1_72(MethodBind31, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind32 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetStiffnessDampingCurve, 1447180063ul);

    /// <summary>
    /// <para>Sets the stiffness force damping curve of the bone chain.</para>
    /// </summary>
    public void SetStiffnessDampingCurve(int index, Curve curve)
    {
        NativeCalls.godot_icall_2_70(MethodBind32, GodotObject.GetPtr(this), index, GodotObject.GetPtr(curve));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind33 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetStiffnessDampingCurve, 747537754ul);

    /// <summary>
    /// <para>Returns the stiffness force damping curve of the bone chain.</para>
    /// </summary>
    public Curve GetStiffnessDampingCurve(int index)
    {
        return (Curve)NativeCalls.godot_icall_1_71(MethodBind33, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind34 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDrag, 1602489585ul);

    /// <summary>
    /// <para>Sets the drag force of the bone chain. The greater the value, the more suppressed the wiggling.</para>
    /// <para>The value is scaled by <see cref="Godot.SpringBoneSimulator3D.SetDragDampingCurve(int, Curve)"/> and cached in each joint setting in the joint list.</para>
    /// </summary>
    public void SetDrag(int index, float drag)
    {
        NativeCalls.godot_icall_2_69(MethodBind34, GodotObject.GetPtr(this), index, drag);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind35 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDrag, 2339986948ul);

    /// <summary>
    /// <para>Returns the drag force damping curve of the bone chain.</para>
    /// </summary>
    public float GetDrag(int index)
    {
        return NativeCalls.godot_icall_1_72(MethodBind35, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind36 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDragDampingCurve, 1447180063ul);

    /// <summary>
    /// <para>Sets the drag force damping curve of the bone chain.</para>
    /// </summary>
    public void SetDragDampingCurve(int index, Curve curve)
    {
        NativeCalls.godot_icall_2_70(MethodBind36, GodotObject.GetPtr(this), index, GodotObject.GetPtr(curve));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind37 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDragDampingCurve, 747537754ul);

    /// <summary>
    /// <para>Returns the drag force damping curve of the bone chain.</para>
    /// </summary>
    public Curve GetDragDampingCurve(int index)
    {
        return (Curve)NativeCalls.godot_icall_1_71(MethodBind37, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind38 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetGravity, 1602489585ul);

    /// <summary>
    /// <para>Sets the gravity amount of the bone chain. This value is not an acceleration, but a constant velocity of movement in <see cref="Godot.SpringBoneSimulator3D.SetGravityDirection(int, Vector3)"/>.</para>
    /// <para>If <paramref name="gravity"/> is not <c>0</c>, the modified pose will not return to the original pose since it is always affected by gravity.</para>
    /// <para>The value is scaled by <see cref="Godot.SpringBoneSimulator3D.SetGravityDampingCurve(int, Curve)"/> and cached in each joint setting in the joint list.</para>
    /// </summary>
    public void SetGravity(int index, float gravity)
    {
        NativeCalls.godot_icall_2_69(MethodBind38, GodotObject.GetPtr(this), index, gravity);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind39 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetGravity, 2339986948ul);

    /// <summary>
    /// <para>Returns the gravity amount of the bone chain.</para>
    /// </summary>
    public float GetGravity(int index)
    {
        return NativeCalls.godot_icall_1_72(MethodBind39, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind40 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetGravityDampingCurve, 1447180063ul);

    /// <summary>
    /// <para>Sets the gravity amount damping curve of the bone chain.</para>
    /// </summary>
    public void SetGravityDampingCurve(int index, Curve curve)
    {
        NativeCalls.godot_icall_2_70(MethodBind40, GodotObject.GetPtr(this), index, GodotObject.GetPtr(curve));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind41 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetGravityDampingCurve, 747537754ul);

    /// <summary>
    /// <para>Returns the gravity amount damping curve of the bone chain.</para>
    /// </summary>
    public Curve GetGravityDampingCurve(int index)
    {
        return (Curve)NativeCalls.godot_icall_1_71(MethodBind41, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind42 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetGravityDirection, 1530502735ul);

    /// <summary>
    /// <para>Sets the gravity direction of the bone chain. This value is internally normalized and then multiplied by <see cref="Godot.SpringBoneSimulator3D.SetGravity(int, float)"/>.</para>
    /// <para>The value is cached in each joint setting in the joint list.</para>
    /// </summary>
    public unsafe void SetGravityDirection(int index, Vector3 gravityDirection)
    {
        NativeCalls.godot_icall_2_362(MethodBind42, GodotObject.GetPtr(this), index, &gravityDirection);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind43 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetGravityDirection, 711720468ul);

    /// <summary>
    /// <para>Returns the gravity direction of the bone chain.</para>
    /// </summary>
    public Vector3 GetGravityDirection(int index)
    {
        return NativeCalls.godot_icall_1_363(MethodBind43, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind44 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSettingCount, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSettingCount(int count)
    {
        NativeCalls.godot_icall_1_38(MethodBind44, GodotObject.GetPtr(this), count);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind45 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSettingCount, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetSettingCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind45, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind46 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ClearSettings, 3218959716ul);

    /// <summary>
    /// <para>Clears all settings.</para>
    /// </summary>
    public void ClearSettings()
    {
        NativeCalls.godot_icall_0_3(MethodBind46, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind47 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetIndividualConfig, 300928843ul);

    /// <summary>
    /// <para>If <paramref name="enabled"/> is <see langword="true"/>, the config can be edited individually for each joint.</para>
    /// </summary>
    public void SetIndividualConfig(int index, bool enabled)
    {
        NativeCalls.godot_icall_2_61(MethodBind47, GodotObject.GetPtr(this), index, enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind48 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsConfigIndividual, 1116898809ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the config can be edited individually for each joint.</para>
    /// </summary>
    public bool IsConfigIndividual(int index)
    {
        return NativeCalls.godot_icall_1_62(MethodBind48, GodotObject.GetPtr(this), index).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind49 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetJointBoneName, 1391810591ul);

    /// <summary>
    /// <para>Returns the bone name at <paramref name="joint"/> in the bone chain's joint list.</para>
    /// </summary>
    public string GetJointBoneName(int index, int joint)
    {
        return NativeCalls.godot_icall_2_222(MethodBind49, GodotObject.GetPtr(this), index, joint);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind50 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetJointBone, 3175239445ul);

    /// <summary>
    /// <para>Returns the bone index at <paramref name="joint"/> in the bone chain's joint list.</para>
    /// </summary>
    public int GetJointBone(int index, int joint)
    {
        return NativeCalls.godot_icall_2_73(MethodBind50, GodotObject.GetPtr(this), index, joint);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind51 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetJointRotationAxis, 1391134969ul);

    /// <summary>
    /// <para>Sets the rotation axis at <paramref name="joint"/> in the bone chain's joint list when <see cref="Godot.SpringBoneSimulator3D.IsConfigIndividual(int)"/> is <see langword="true"/>.</para>
    /// <para>The axes are based on the <see cref="Godot.Skeleton3D.GetBoneRest(int)"/>'s space, if <paramref name="axis"/> is <see cref="Godot.SkeletonModifier3D.RotationAxis.Custom"/>, you can specify any axis.</para>
    /// <para><b>Note:</b> The rotation axis and the forward vector shouldn't be colinear to avoid unintended rotation since <see cref="Godot.SpringBoneSimulator3D"/> does not factor in twisting forces.</para>
    /// </summary>
    public void SetJointRotationAxis(int index, int joint, SkeletonModifier3D.RotationAxis axis)
    {
        NativeCalls.godot_icall_3_196(MethodBind51, GodotObject.GetPtr(this), index, joint, (int)axis);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind52 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetJointRotationAxis, 3312594080ul);

    /// <summary>
    /// <para>Returns the rotation axis at <paramref name="joint"/> in the bone chain's joint list.</para>
    /// </summary>
    public SkeletonModifier3D.RotationAxis GetJointRotationAxis(int index, int joint)
    {
        return (SkeletonModifier3D.RotationAxis)NativeCalls.godot_icall_2_73(MethodBind52, GodotObject.GetPtr(this), index, joint);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind53 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetJointRotationAxisVector, 2866752138ul);

    /// <summary>
    /// <para>Sets the rotation axis vector for the specified joint in the bone chain.</para>
    /// <para>This vector is normalized by an internal process and represents the axis around which the bone chain can rotate.</para>
    /// <para>If the vector length is <c>0</c>, it is considered synonymous with <see cref="Godot.SkeletonModifier3D.RotationAxis.All"/>.</para>
    /// </summary>
    public unsafe void SetJointRotationAxisVector(int index, int joint, Vector3 vector)
    {
        NativeCalls.godot_icall_3_766(MethodBind53, GodotObject.GetPtr(this), index, joint, &vector);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind54 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetJointRotationAxisVector, 1592972041ul);

    /// <summary>
    /// <para>Returns the rotation axis vector for the specified joint in the bone chain. This vector represents the axis around which the joint can rotate. It is determined based on the rotation axis set for the joint.</para>
    /// <para>If <see cref="Godot.SpringBoneSimulator3D.GetJointRotationAxis(int, int)"/> is <see cref="Godot.SkeletonModifier3D.RotationAxis.All"/>, this method returns <c>Vector3(0, 0, 0)</c>.</para>
    /// </summary>
    public Vector3 GetJointRotationAxisVector(int index, int joint)
    {
        return NativeCalls.godot_icall_2_767(MethodBind54, GodotObject.GetPtr(this), index, joint);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind55 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetJointRadius, 3506521499ul);

    /// <summary>
    /// <para>Sets the joint radius at <paramref name="joint"/> in the bone chain's joint list when <see cref="Godot.SpringBoneSimulator3D.IsConfigIndividual(int)"/> is <see langword="true"/>.</para>
    /// </summary>
    public void SetJointRadius(int index, int joint, float radius)
    {
        NativeCalls.godot_icall_3_86(MethodBind55, GodotObject.GetPtr(this), index, joint, radius);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind56 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetJointRadius, 3085491603ul);

    /// <summary>
    /// <para>Returns the radius at <paramref name="joint"/> in the bone chain's joint list.</para>
    /// </summary>
    public float GetJointRadius(int index, int joint)
    {
        return NativeCalls.godot_icall_2_88(MethodBind56, GodotObject.GetPtr(this), index, joint);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind57 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetJointStiffness, 3506521499ul);

    /// <summary>
    /// <para>Sets the stiffness force at <paramref name="joint"/> in the bone chain's joint list when <see cref="Godot.SpringBoneSimulator3D.IsConfigIndividual(int)"/> is <see langword="true"/>.</para>
    /// </summary>
    public void SetJointStiffness(int index, int joint, float stiffness)
    {
        NativeCalls.godot_icall_3_86(MethodBind57, GodotObject.GetPtr(this), index, joint, stiffness);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind58 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetJointStiffness, 3085491603ul);

    /// <summary>
    /// <para>Returns the stiffness force at <paramref name="joint"/> in the bone chain's joint list.</para>
    /// </summary>
    public float GetJointStiffness(int index, int joint)
    {
        return NativeCalls.godot_icall_2_88(MethodBind58, GodotObject.GetPtr(this), index, joint);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind59 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetJointDrag, 3506521499ul);

    /// <summary>
    /// <para>Sets the drag force at <paramref name="joint"/> in the bone chain's joint list when <see cref="Godot.SpringBoneSimulator3D.IsConfigIndividual(int)"/> is <see langword="true"/>.</para>
    /// </summary>
    public void SetJointDrag(int index, int joint, float drag)
    {
        NativeCalls.godot_icall_3_86(MethodBind59, GodotObject.GetPtr(this), index, joint, drag);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind60 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetJointDrag, 3085491603ul);

    /// <summary>
    /// <para>Returns the drag force at <paramref name="joint"/> in the bone chain's joint list.</para>
    /// </summary>
    public float GetJointDrag(int index, int joint)
    {
        return NativeCalls.godot_icall_2_88(MethodBind60, GodotObject.GetPtr(this), index, joint);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind61 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetJointGravity, 3506521499ul);

    /// <summary>
    /// <para>Sets the gravity amount at <paramref name="joint"/> in the bone chain's joint list when <see cref="Godot.SpringBoneSimulator3D.IsConfigIndividual(int)"/> is <see langword="true"/>.</para>
    /// </summary>
    public void SetJointGravity(int index, int joint, float gravity)
    {
        NativeCalls.godot_icall_3_86(MethodBind61, GodotObject.GetPtr(this), index, joint, gravity);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind62 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetJointGravity, 3085491603ul);

    /// <summary>
    /// <para>Returns the gravity amount at <paramref name="joint"/> in the bone chain's joint list.</para>
    /// </summary>
    public float GetJointGravity(int index, int joint)
    {
        return NativeCalls.godot_icall_2_88(MethodBind62, GodotObject.GetPtr(this), index, joint);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind63 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetJointGravityDirection, 2866752138ul);

    /// <summary>
    /// <para>Sets the gravity direction at <paramref name="joint"/> in the bone chain's joint list when <see cref="Godot.SpringBoneSimulator3D.IsConfigIndividual(int)"/> is <see langword="true"/>.</para>
    /// </summary>
    public unsafe void SetJointGravityDirection(int index, int joint, Vector3 gravityDirection)
    {
        NativeCalls.godot_icall_3_766(MethodBind63, GodotObject.GetPtr(this), index, joint, &gravityDirection);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind64 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetJointGravityDirection, 1592972041ul);

    /// <summary>
    /// <para>Returns the gravity direction at <paramref name="joint"/> in the bone chain's joint list.</para>
    /// </summary>
    public Vector3 GetJointGravityDirection(int index, int joint)
    {
        return NativeCalls.godot_icall_2_767(MethodBind64, GodotObject.GetPtr(this), index, joint);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind65 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetJointCount, 923996154ul);

    /// <summary>
    /// <para>Returns the joint count of the bone chain's joint list.</para>
    /// </summary>
    public int GetJointCount(int index)
    {
        return NativeCalls.godot_icall_1_60(MethodBind65, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind66 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEnableAllChildCollisions, 300928843ul);

    /// <summary>
    /// <para>If <paramref name="enabled"/> is <see langword="true"/>, all child <see cref="Godot.SpringBoneCollision3D"/>s are colliding and <see cref="Godot.SpringBoneSimulator3D.SetExcludeCollisionPath(int, int, NodePath)"/> is enabled as an exclusion list at <paramref name="index"/> in the settings.</para>
    /// <para>If <paramref name="enabled"/> is <see langword="false"/>, you need to manually register all valid collisions with <see cref="Godot.SpringBoneSimulator3D.SetCollisionPath(int, int, NodePath)"/>.</para>
    /// </summary>
    public void SetEnableAllChildCollisions(int index, bool enabled)
    {
        NativeCalls.godot_icall_2_61(MethodBind66, GodotObject.GetPtr(this), index, enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind67 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AreAllChildCollisionsEnabled, 1116898809ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if all child <see cref="Godot.SpringBoneCollision3D"/>s are contained in the collision list at <paramref name="index"/> in the settings.</para>
    /// </summary>
    public bool AreAllChildCollisionsEnabled(int index)
    {
        return NativeCalls.godot_icall_1_62(MethodBind67, GodotObject.GetPtr(this), index).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind68 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetExcludeCollisionPath, 132481804ul);

    /// <summary>
    /// <para>Sets the node path of the <see cref="Godot.SpringBoneCollision3D"/> at <paramref name="collision"/> in the bone chain's exclude collision list when <see cref="Godot.SpringBoneSimulator3D.AreAllChildCollisionsEnabled(int)"/> is <see langword="true"/>.</para>
    /// </summary>
    public void SetExcludeCollisionPath(int index, int collision, NodePath nodePath)
    {
        NativeCalls.godot_icall_3_1277(MethodBind68, GodotObject.GetPtr(this), index, collision, (godot_node_path)(nodePath?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind69 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetExcludeCollisionPath, 464924783ul);

    /// <summary>
    /// <para>Returns the node path of the <see cref="Godot.SpringBoneCollision3D"/> at <paramref name="collision"/> in the bone chain's exclude collision list when <see cref="Godot.SpringBoneSimulator3D.AreAllChildCollisionsEnabled(int)"/> is <see langword="true"/>.</para>
    /// </summary>
    public NodePath GetExcludeCollisionPath(int index, int collision)
    {
        return NativeCalls.godot_icall_2_1278(MethodBind69, GodotObject.GetPtr(this), index, collision);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind70 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetExcludeCollisionCount, 3937882851ul);

    /// <summary>
    /// <para>Sets the number of exclude collisions in the exclude collision list at <paramref name="index"/> in the settings when <see cref="Godot.SpringBoneSimulator3D.AreAllChildCollisionsEnabled(int)"/> is <see langword="true"/>.</para>
    /// </summary>
    public void SetExcludeCollisionCount(int index, int count)
    {
        NativeCalls.godot_icall_2_59(MethodBind70, GodotObject.GetPtr(this), index, count);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind71 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetExcludeCollisionCount, 923996154ul);

    /// <summary>
    /// <para>Returns the exclude collision count of the bone chain's exclude collision list when <see cref="Godot.SpringBoneSimulator3D.AreAllChildCollisionsEnabled(int)"/> is <see langword="true"/>.</para>
    /// </summary>
    public int GetExcludeCollisionCount(int index)
    {
        return NativeCalls.godot_icall_1_60(MethodBind71, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind72 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ClearExcludeCollisions, 1286410249ul);

    /// <summary>
    /// <para>Clears all exclude collisions from the collision list at <paramref name="index"/> in the settings when <see cref="Godot.SpringBoneSimulator3D.AreAllChildCollisionsEnabled(int)"/> is <see langword="true"/>.</para>
    /// </summary>
    public void ClearExcludeCollisions(int index)
    {
        NativeCalls.godot_icall_1_38(MethodBind72, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind73 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCollisionPath, 132481804ul);

    /// <summary>
    /// <para>Sets the node path of the <see cref="Godot.SpringBoneCollision3D"/> at <paramref name="collision"/> in the bone chain's collision list when <see cref="Godot.SpringBoneSimulator3D.AreAllChildCollisionsEnabled(int)"/> is <see langword="false"/>.</para>
    /// </summary>
    public void SetCollisionPath(int index, int collision, NodePath nodePath)
    {
        NativeCalls.godot_icall_3_1277(MethodBind73, GodotObject.GetPtr(this), index, collision, (godot_node_path)(nodePath?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind74 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCollisionPath, 464924783ul);

    /// <summary>
    /// <para>Returns the node path of the <see cref="Godot.SpringBoneCollision3D"/> at <paramref name="collision"/> in the bone chain's collision list when <see cref="Godot.SpringBoneSimulator3D.AreAllChildCollisionsEnabled(int)"/> is <see langword="false"/>.</para>
    /// </summary>
    public NodePath GetCollisionPath(int index, int collision)
    {
        return NativeCalls.godot_icall_2_1278(MethodBind74, GodotObject.GetPtr(this), index, collision);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind75 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCollisionCount, 3937882851ul);

    /// <summary>
    /// <para>Sets the number of collisions in the collision list at <paramref name="index"/> in the settings when <see cref="Godot.SpringBoneSimulator3D.AreAllChildCollisionsEnabled(int)"/> is <see langword="false"/>.</para>
    /// </summary>
    public void SetCollisionCount(int index, int count)
    {
        NativeCalls.godot_icall_2_59(MethodBind75, GodotObject.GetPtr(this), index, count);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind76 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCollisionCount, 923996154ul);

    /// <summary>
    /// <para>Returns the collision count of the bone chain's collision list when <see cref="Godot.SpringBoneSimulator3D.AreAllChildCollisionsEnabled(int)"/> is <see langword="false"/>.</para>
    /// </summary>
    public int GetCollisionCount(int index)
    {
        return NativeCalls.godot_icall_1_60(MethodBind76, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind77 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ClearCollisions, 1286410249ul);

    /// <summary>
    /// <para>Clears all collisions from the collision list at <paramref name="index"/> in the settings when <see cref="Godot.SpringBoneSimulator3D.AreAllChildCollisionsEnabled(int)"/> is <see langword="false"/>.</para>
    /// </summary>
    public void ClearCollisions(int index)
    {
        NativeCalls.godot_icall_1_38(MethodBind77, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind78 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetExternalForce, 3460891852ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetExternalForce(Vector3 force)
    {
        NativeCalls.godot_icall_1_177(MethodBind78, GodotObject.GetPtr(this), &force);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind79 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetExternalForce, 3360562783ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector3 GetExternalForce()
    {
        return NativeCalls.godot_icall_0_125(MethodBind79, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind80 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMutableBoneAxes, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMutableBoneAxes(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind80, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind81 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AreBoneAxesMutable, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool AreBoneAxesMutable()
    {
        return NativeCalls.godot_icall_0_15(MethodBind81, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind82 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Reset, 3218959716ul);

    /// <summary>
    /// <para>Resets a simulating state with respect to the current bone pose.</para>
    /// <para>It is useful to prevent the simulation result getting violent. For example, calling this immediately after a call to <see cref="Godot.AnimationPlayer.Play(StringName, double, float, bool)"/> without a fading, or within the previous <see cref="Godot.SkeletonModifier3D.ModificationProcessed"/> signal if it's condition changes significantly.</para>
    /// </summary>
    public void Reset()
    {
        NativeCalls.godot_icall_0_3(MethodBind82, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind83 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetJointRotationAxis, 4224018032ul);

    /// <summary>
    /// <para>Sets the rotation axis at <paramref name="joint"/> in the bone chain's joint list when <see cref="Godot.SpringBoneSimulator3D.IsConfigIndividual(int)"/> is <see langword="true"/>.</para>
    /// <para>The axes are based on the <see cref="Godot.Skeleton3D.GetBoneRest(int)"/>'s space, if <paramref name="axis"/> is <see cref="Godot.SkeletonModifier3D.RotationAxis.Custom"/>, you can specify any axis.</para>
    /// <para><b>Note:</b> The rotation axis and the forward vector shouldn't be colinear to avoid unintended rotation since <see cref="Godot.SpringBoneSimulator3D"/> does not factor in twisting forces.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetJointRotationAxis(int index, int joint, int axis)
    {
        NativeCalls.godot_icall_3_196(MethodBind83, GodotObject.GetPtr(this), index, joint, axis);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind84 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRotationAxis, 3534169209ul);

    /// <summary>
    /// <para>Sets the rotation axis of the bone chain. If set to a specific axis, it acts like a hinge joint. The value is cached in each joint setting in the joint list.</para>
    /// <para>The axes are based on the <see cref="Godot.Skeleton3D.GetBoneRest(int)"/>'s space, if <paramref name="axis"/> is <see cref="Godot.SkeletonModifier3D.RotationAxis.Custom"/>, you can specify any axis.</para>
    /// <para><b>Note:</b> The rotation axis vector and the forward vector shouldn't be colinear to avoid unintended rotation since <see cref="Godot.SpringBoneSimulator3D"/> does not factor in twisting forces.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetRotationAxis(int index, int axis)
    {
        NativeCalls.godot_icall_2_59(MethodBind84, GodotObject.GetPtr(this), index, axis);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind85 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEndBoneDirection, 204796492ul);

    /// <summary>
    /// <para>Sets the end bone tail direction of the bone chain when <see cref="Godot.SpringBoneSimulator3D.IsEndBoneExtended(int)"/> is <see langword="true"/>.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEndBoneDirection(int index, int boneDirection)
    {
        NativeCalls.godot_icall_2_59(MethodBind85, GodotObject.GetPtr(this), index, boneDirection);
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
    public new class PropertyName : SkeletonModifier3D.PropertyName
    {
        /// <summary>
        /// Cached name for the 'external_force' property.
        /// </summary>
        public static readonly StringName ExternalForce = "external_force";
        /// <summary>
        /// Cached name for the 'mutable_bone_axes' property.
        /// </summary>
        public static readonly StringName MutableBoneAxes = "mutable_bone_axes";
        /// <summary>
        /// Cached name for the 'setting_count' property.
        /// </summary>
        public static readonly StringName SettingCount = "setting_count";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : SkeletonModifier3D.MethodName
    {
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
        /// <summary>
        /// Cached name for the 'set_center_from' method.
        /// </summary>
        public static readonly StringName SetCenterFrom = "set_center_from";
        /// <summary>
        /// Cached name for the 'get_center_from' method.
        /// </summary>
        public static readonly StringName GetCenterFrom = "get_center_from";
        /// <summary>
        /// Cached name for the 'set_center_node' method.
        /// </summary>
        public static readonly StringName SetCenterNode = "set_center_node";
        /// <summary>
        /// Cached name for the 'get_center_node' method.
        /// </summary>
        public static readonly StringName GetCenterNode = "get_center_node";
        /// <summary>
        /// Cached name for the 'set_center_bone_name' method.
        /// </summary>
        public static readonly StringName SetCenterBoneName = "set_center_bone_name";
        /// <summary>
        /// Cached name for the 'get_center_bone_name' method.
        /// </summary>
        public static readonly StringName GetCenterBoneName = "get_center_bone_name";
        /// <summary>
        /// Cached name for the 'set_center_bone' method.
        /// </summary>
        public static readonly StringName SetCenterBone = "set_center_bone";
        /// <summary>
        /// Cached name for the 'get_center_bone' method.
        /// </summary>
        public static readonly StringName GetCenterBone = "get_center_bone";
        /// <summary>
        /// Cached name for the 'set_radius' method.
        /// </summary>
        public static readonly StringName SetRadius = "set_radius";
        /// <summary>
        /// Cached name for the 'get_radius' method.
        /// </summary>
        public static readonly StringName GetRadius = "get_radius";
        /// <summary>
        /// Cached name for the 'set_rotation_axis' method.
        /// </summary>
        public static readonly StringName SetRotationAxis = "set_rotation_axis";
        /// <summary>
        /// Cached name for the 'get_rotation_axis' method.
        /// </summary>
        public static readonly StringName GetRotationAxis = "get_rotation_axis";
        /// <summary>
        /// Cached name for the 'set_rotation_axis_vector' method.
        /// </summary>
        public static readonly StringName SetRotationAxisVector = "set_rotation_axis_vector";
        /// <summary>
        /// Cached name for the 'get_rotation_axis_vector' method.
        /// </summary>
        public static readonly StringName GetRotationAxisVector = "get_rotation_axis_vector";
        /// <summary>
        /// Cached name for the 'set_radius_damping_curve' method.
        /// </summary>
        public static readonly StringName SetRadiusDampingCurve = "set_radius_damping_curve";
        /// <summary>
        /// Cached name for the 'get_radius_damping_curve' method.
        /// </summary>
        public static readonly StringName GetRadiusDampingCurve = "get_radius_damping_curve";
        /// <summary>
        /// Cached name for the 'set_stiffness' method.
        /// </summary>
        public static readonly StringName SetStiffness = "set_stiffness";
        /// <summary>
        /// Cached name for the 'get_stiffness' method.
        /// </summary>
        public static readonly StringName GetStiffness = "get_stiffness";
        /// <summary>
        /// Cached name for the 'set_stiffness_damping_curve' method.
        /// </summary>
        public static readonly StringName SetStiffnessDampingCurve = "set_stiffness_damping_curve";
        /// <summary>
        /// Cached name for the 'get_stiffness_damping_curve' method.
        /// </summary>
        public static readonly StringName GetStiffnessDampingCurve = "get_stiffness_damping_curve";
        /// <summary>
        /// Cached name for the 'set_drag' method.
        /// </summary>
        public static readonly StringName SetDrag = "set_drag";
        /// <summary>
        /// Cached name for the 'get_drag' method.
        /// </summary>
        public static readonly StringName GetDrag = "get_drag";
        /// <summary>
        /// Cached name for the 'set_drag_damping_curve' method.
        /// </summary>
        public static readonly StringName SetDragDampingCurve = "set_drag_damping_curve";
        /// <summary>
        /// Cached name for the 'get_drag_damping_curve' method.
        /// </summary>
        public static readonly StringName GetDragDampingCurve = "get_drag_damping_curve";
        /// <summary>
        /// Cached name for the 'set_gravity' method.
        /// </summary>
        public static readonly StringName SetGravity = "set_gravity";
        /// <summary>
        /// Cached name for the 'get_gravity' method.
        /// </summary>
        public static readonly StringName GetGravity = "get_gravity";
        /// <summary>
        /// Cached name for the 'set_gravity_damping_curve' method.
        /// </summary>
        public static readonly StringName SetGravityDampingCurve = "set_gravity_damping_curve";
        /// <summary>
        /// Cached name for the 'get_gravity_damping_curve' method.
        /// </summary>
        public static readonly StringName GetGravityDampingCurve = "get_gravity_damping_curve";
        /// <summary>
        /// Cached name for the 'set_gravity_direction' method.
        /// </summary>
        public static readonly StringName SetGravityDirection = "set_gravity_direction";
        /// <summary>
        /// Cached name for the 'get_gravity_direction' method.
        /// </summary>
        public static readonly StringName GetGravityDirection = "get_gravity_direction";
        /// <summary>
        /// Cached name for the 'set_setting_count' method.
        /// </summary>
        public static readonly StringName SetSettingCount = "set_setting_count";
        /// <summary>
        /// Cached name for the 'get_setting_count' method.
        /// </summary>
        public static readonly StringName GetSettingCount = "get_setting_count";
        /// <summary>
        /// Cached name for the 'clear_settings' method.
        /// </summary>
        public static readonly StringName ClearSettings = "clear_settings";
        /// <summary>
        /// Cached name for the 'set_individual_config' method.
        /// </summary>
        public static readonly StringName SetIndividualConfig = "set_individual_config";
        /// <summary>
        /// Cached name for the 'is_config_individual' method.
        /// </summary>
        public static readonly StringName IsConfigIndividual = "is_config_individual";
        /// <summary>
        /// Cached name for the 'get_joint_bone_name' method.
        /// </summary>
        public static readonly StringName GetJointBoneName = "get_joint_bone_name";
        /// <summary>
        /// Cached name for the 'get_joint_bone' method.
        /// </summary>
        public static readonly StringName GetJointBone = "get_joint_bone";
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
        /// Cached name for the 'set_joint_radius' method.
        /// </summary>
        public static readonly StringName SetJointRadius = "set_joint_radius";
        /// <summary>
        /// Cached name for the 'get_joint_radius' method.
        /// </summary>
        public static readonly StringName GetJointRadius = "get_joint_radius";
        /// <summary>
        /// Cached name for the 'set_joint_stiffness' method.
        /// </summary>
        public static readonly StringName SetJointStiffness = "set_joint_stiffness";
        /// <summary>
        /// Cached name for the 'get_joint_stiffness' method.
        /// </summary>
        public static readonly StringName GetJointStiffness = "get_joint_stiffness";
        /// <summary>
        /// Cached name for the 'set_joint_drag' method.
        /// </summary>
        public static readonly StringName SetJointDrag = "set_joint_drag";
        /// <summary>
        /// Cached name for the 'get_joint_drag' method.
        /// </summary>
        public static readonly StringName GetJointDrag = "get_joint_drag";
        /// <summary>
        /// Cached name for the 'set_joint_gravity' method.
        /// </summary>
        public static readonly StringName SetJointGravity = "set_joint_gravity";
        /// <summary>
        /// Cached name for the 'get_joint_gravity' method.
        /// </summary>
        public static readonly StringName GetJointGravity = "get_joint_gravity";
        /// <summary>
        /// Cached name for the 'set_joint_gravity_direction' method.
        /// </summary>
        public static readonly StringName SetJointGravityDirection = "set_joint_gravity_direction";
        /// <summary>
        /// Cached name for the 'get_joint_gravity_direction' method.
        /// </summary>
        public static readonly StringName GetJointGravityDirection = "get_joint_gravity_direction";
        /// <summary>
        /// Cached name for the 'get_joint_count' method.
        /// </summary>
        public static readonly StringName GetJointCount = "get_joint_count";
        /// <summary>
        /// Cached name for the 'set_enable_all_child_collisions' method.
        /// </summary>
        public static readonly StringName SetEnableAllChildCollisions = "set_enable_all_child_collisions";
        /// <summary>
        /// Cached name for the 'are_all_child_collisions_enabled' method.
        /// </summary>
        public static readonly StringName AreAllChildCollisionsEnabled = "are_all_child_collisions_enabled";
        /// <summary>
        /// Cached name for the 'set_exclude_collision_path' method.
        /// </summary>
        public static readonly StringName SetExcludeCollisionPath = "set_exclude_collision_path";
        /// <summary>
        /// Cached name for the 'get_exclude_collision_path' method.
        /// </summary>
        public static readonly StringName GetExcludeCollisionPath = "get_exclude_collision_path";
        /// <summary>
        /// Cached name for the 'set_exclude_collision_count' method.
        /// </summary>
        public static readonly StringName SetExcludeCollisionCount = "set_exclude_collision_count";
        /// <summary>
        /// Cached name for the 'get_exclude_collision_count' method.
        /// </summary>
        public static readonly StringName GetExcludeCollisionCount = "get_exclude_collision_count";
        /// <summary>
        /// Cached name for the 'clear_exclude_collisions' method.
        /// </summary>
        public static readonly StringName ClearExcludeCollisions = "clear_exclude_collisions";
        /// <summary>
        /// Cached name for the 'set_collision_path' method.
        /// </summary>
        public static readonly StringName SetCollisionPath = "set_collision_path";
        /// <summary>
        /// Cached name for the 'get_collision_path' method.
        /// </summary>
        public static readonly StringName GetCollisionPath = "get_collision_path";
        /// <summary>
        /// Cached name for the 'set_collision_count' method.
        /// </summary>
        public static readonly StringName SetCollisionCount = "set_collision_count";
        /// <summary>
        /// Cached name for the 'get_collision_count' method.
        /// </summary>
        public static readonly StringName GetCollisionCount = "get_collision_count";
        /// <summary>
        /// Cached name for the 'clear_collisions' method.
        /// </summary>
        public static readonly StringName ClearCollisions = "clear_collisions";
        /// <summary>
        /// Cached name for the 'set_external_force' method.
        /// </summary>
        public static readonly StringName SetExternalForce = "set_external_force";
        /// <summary>
        /// Cached name for the 'get_external_force' method.
        /// </summary>
        public static readonly StringName GetExternalForce = "get_external_force";
        /// <summary>
        /// Cached name for the 'set_mutable_bone_axes' method.
        /// </summary>
        public static readonly StringName SetMutableBoneAxes = "set_mutable_bone_axes";
        /// <summary>
        /// Cached name for the 'are_bone_axes_mutable' method.
        /// </summary>
        public static readonly StringName AreBoneAxesMutable = "are_bone_axes_mutable";
        /// <summary>
        /// Cached name for the 'reset' method.
        /// </summary>
        public static readonly StringName Reset = "reset";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : SkeletonModifier3D.SignalName
    {
    }
}
