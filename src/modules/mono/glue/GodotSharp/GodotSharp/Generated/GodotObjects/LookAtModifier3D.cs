namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This <see cref="Godot.SkeletonModifier3D"/> rotates a bone to look at a target. This is helpful for moving a character's head to look at the player, rotating a turret to look at a target, or any other case where you want to make a bone rotate towards something quickly and easily.</para>
/// <para>When applying multiple <see cref="Godot.LookAtModifier3D"/>s, the <see cref="Godot.LookAtModifier3D"/> assigned to the parent bone must be put above the <see cref="Godot.LookAtModifier3D"/> assigned to the child bone in the list in order for the child bone results to be correct.</para>
/// </summary>
public partial class LookAtModifier3D : SkeletonModifier3D
{
    public enum OriginFromEnum : long
    {
        /// <summary>
        /// <para>The bone rest position of the bone specified in <see cref="Godot.LookAtModifier3D.Bone"/> is used as origin.</para>
        /// </summary>
        Self = 0,
        /// <summary>
        /// <para>The bone global pose position of the bone specified in <see cref="Godot.LookAtModifier3D.OriginBone"/> is used as origin.</para>
        /// <para><b>Note:</b> It is recommended that you select only the parent bone unless you are familiar with the bone processing process. The specified bone pose at the time the <see cref="Godot.LookAtModifier3D"/> is processed is used as a reference. In other words, if you specify a child bone and the <see cref="Godot.LookAtModifier3D"/> causes the child bone to move, the rendered result and direction will not match.</para>
        /// </summary>
        SpecificBone = 1,
        /// <summary>
        /// <para>The global position of the <see cref="Godot.Node3D"/> specified in <see cref="Godot.LookAtModifier3D.OriginExternalNode"/> is used as origin.</para>
        /// <para><b>Note:</b> Same as <see cref="Godot.LookAtModifier3D.OriginFromEnum.SpecificBone"/>, when specifying a <see cref="Godot.BoneAttachment3D"/> with a child bone assigned, the rendered result and direction will not match.</para>
        /// </summary>
        ExternalNode = 2
    }

    /// <summary>
    /// <para>The <see cref="Godot.NodePath"/> to the node that is the target for the look at modification. This node is what the modification will rotate the bone to.</para>
    /// </summary>
    public NodePath TargetNode
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
    /// <para>The bone name of the <see cref="Godot.Skeleton3D"/> that the modification will operate on.</para>
    /// </summary>
    public string BoneName
    {
        get
        {
            return GetBoneName();
        }
        set
        {
            SetBoneName(value);
        }
    }

    /// <summary>
    /// <para>Index of the <see cref="Godot.LookAtModifier3D.BoneName"/> in the parent <see cref="Godot.Skeleton3D"/>.</para>
    /// </summary>
    public int Bone
    {
        get
        {
            return GetBone();
        }
        set
        {
            SetBone(value);
        }
    }

    /// <summary>
    /// <para>The forward axis of the bone. This <see cref="Godot.SkeletonModifier3D"/> modifies the bone so that this axis points toward the <see cref="Godot.LookAtModifier3D.TargetNode"/>.</para>
    /// </summary>
    public SkeletonModifier3D.BoneAxis ForwardAxis
    {
        get
        {
            return GetForwardAxis();
        }
        set
        {
            SetForwardAxis(value);
        }
    }

    /// <summary>
    /// <para>The axis of the first rotation. This <see cref="Godot.SkeletonModifier3D"/> works by compositing the rotation by Euler angles to prevent to rotate the <see cref="Godot.LookAtModifier3D.ForwardAxis"/>.</para>
    /// </summary>
    public Vector3.Axis PrimaryRotationAxis
    {
        get
        {
            return GetPrimaryRotationAxis();
        }
        set
        {
            SetPrimaryRotationAxis(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, provides rotation by two axes.</para>
    /// </summary>
    public bool UseSecondaryRotation
    {
        get
        {
            return IsUsingSecondaryRotation();
        }
        set
        {
            SetUseSecondaryRotation(value);
        }
    }

    /// <summary>
    /// <para>The relative option. If <see langword="true"/>, the rotation is applied relative to the pose. If <see langword="false"/>, the rotation is applied relative to the rest. It means to replace the current pose with the <see cref="Godot.LookAtModifier3D"/>'s result.</para>
    /// <para><b>Note:</b> This option affects the base angle for <see cref="Godot.LookAtModifier3D.UseAngleLimitation"/> unlike <see cref="Godot.IterateIK3D"/>'s <see cref="Godot.JointLimitation3D"/>. Since the <see cref="Godot.LookAtModifier3D"/> relies strongly on Euler rotation, the axis that determines the limitation and the actual rotation are strongly tied together.</para>
    /// </summary>
    public bool Relative
    {
        get
        {
            return IsRelative();
        }
        set
        {
            SetRelative(value);
        }
    }

    /// <summary>
    /// <para>This value determines from what origin is retrieved for use in the calculation of the forward vector.</para>
    /// </summary>
    public LookAtModifier3D.OriginFromEnum OriginFrom
    {
        get
        {
            return GetOriginFrom();
        }
        set
        {
            SetOriginFrom(value);
        }
    }

    /// <summary>
    /// <para>If <see cref="Godot.LookAtModifier3D.OriginFrom"/> is <see cref="Godot.LookAtModifier3D.OriginFromEnum.SpecificBone"/>, the bone global pose position specified for this is used as origin.</para>
    /// </summary>
    public string OriginBoneName
    {
        get
        {
            return GetOriginBoneName();
        }
        set
        {
            SetOriginBoneName(value);
        }
    }

    /// <summary>
    /// <para>Index of the <see cref="Godot.LookAtModifier3D.OriginBoneName"/> in the parent <see cref="Godot.Skeleton3D"/>.</para>
    /// </summary>
    public int OriginBone
    {
        get
        {
            return GetOriginBone();
        }
        set
        {
            SetOriginBone(value);
        }
    }

    /// <summary>
    /// <para>If <see cref="Godot.LookAtModifier3D.OriginFrom"/> is <see cref="Godot.LookAtModifier3D.OriginFromEnum.ExternalNode"/>, the global position of the <see cref="Godot.Node3D"/> specified for this is used as origin.</para>
    /// </summary>
    public NodePath OriginExternalNode
    {
        get
        {
            return GetOriginExternalNode();
        }
        set
        {
            SetOriginExternalNode(value);
        }
    }

    /// <summary>
    /// <para>The offset of the bone pose origin. Matching the origins by offset is useful for cases where multiple bones must always face the same direction, such as the eyes.</para>
    /// <para><b>Note:</b> This value indicates the local position of the object set in <see cref="Godot.LookAtModifier3D.OriginFrom"/>.</para>
    /// </summary>
    public Vector3 OriginOffset
    {
        get
        {
            return GetOriginOffset();
        }
        set
        {
            SetOriginOffset(value);
        }
    }

    /// <summary>
    /// <para>If the target passes through too close to the origin than this value, time-based interpolation is used even if the target is within the angular limitations, to prevent the angular velocity from becoming too high.</para>
    /// </summary>
    public float OriginSafeMargin
    {
        get
        {
            return GetOriginSafeMargin();
        }
        set
        {
            SetOriginSafeMargin(value);
        }
    }

    /// <summary>
    /// <para>The duration of the time-based interpolation. Interpolation is triggered at the following cases:</para>
    /// <para>- When the target node is changed</para>
    /// <para>- When an axis is flipped due to angle limitation</para>
    /// <para><b>Note:</b> The flipping occurs when the target is outside the angle limitation and the internally computed secondary rotation axis of the forward vector is flipped. Visually, it occurs when the target is outside the angle limitation and crosses the plane of the <see cref="Godot.LookAtModifier3D.ForwardAxis"/> and <see cref="Godot.LookAtModifier3D.PrimaryRotationAxis"/>.</para>
    /// </summary>
    public float Duration
    {
        get
        {
            return GetDuration();
        }
        set
        {
            SetDuration(value);
        }
    }

    /// <summary>
    /// <para>The transition type of the time-based interpolation. See also <see cref="Godot.Tween.TransitionType"/>.</para>
    /// </summary>
    public Tween.TransitionType TransitionType
    {
        get
        {
            return GetTransitionType();
        }
        set
        {
            SetTransitionType(value);
        }
    }

    /// <summary>
    /// <para>The ease type of the time-based interpolation. See also <see cref="Godot.Tween.EaseType"/>.</para>
    /// </summary>
    public Tween.EaseType EaseType
    {
        get
        {
            return GetEaseType();
        }
        set
        {
            SetEaseType(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, limits the amount of rotation. For example, this helps to prevent a character's neck from rotating 360 degrees.</para>
    /// <para><b>Note:</b> As with <see cref="Godot.AnimationTree"/> blending, interpolation is provided that favors <see cref="Godot.Skeleton3D.GetBoneRest(int)"/> or <see cref="Godot.Skeleton3D.GetBonePose(int)"/> depends on the <see cref="Godot.LookAtModifier3D.Relative"/> option. This means that interpolation does not select the shortest path in some cases.</para>
    /// <para><b>Note:</b> Some values for <see cref="Godot.LookAtModifier3D.TransitionType"/> (such as <see cref="Godot.Tween.TransitionType.Back"/>, <see cref="Godot.Tween.TransitionType.Elastic"/>, and <see cref="Godot.Tween.TransitionType.Spring"/>) may exceed the limitations. If interpolation occurs while overshooting the limitations, the result might not respect the bone rest.</para>
    /// </summary>
    public bool UseAngleLimitation
    {
        get
        {
            return IsUsingAngleLimitation();
        }
        set
        {
            SetUseAngleLimitation(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the limitations are spread from the bone symmetrically.</para>
    /// <para>If <see langword="false"/>, the limitation can be specified separately for each side of the bone rest.</para>
    /// </summary>
    public bool SymmetryLimitation
    {
        get
        {
            return IsLimitationSymmetry();
        }
        set
        {
            SetSymmetryLimitation(value);
        }
    }

    /// <summary>
    /// <para>The limit angle of the primary rotation when <see cref="Godot.LookAtModifier3D.SymmetryLimitation"/> is <see langword="true"/>, in radians.</para>
    /// </summary>
    public float PrimaryLimitAngle
    {
        get
        {
            return GetPrimaryLimitAngle();
        }
        set
        {
            SetPrimaryLimitAngle(value);
        }
    }

    /// <summary>
    /// <para>The threshold to start damping for <see cref="Godot.LookAtModifier3D.PrimaryLimitAngle"/>. It provides non-linear (b-spline) interpolation, let it feel more resistance the more it rotate to the edge limit. This is useful for simulating the limits of human motion.</para>
    /// <para>If <c>1.0</c>, no damping is performed. If <c>0.0</c>, damping is always performed.</para>
    /// </summary>
    public float PrimaryDampThreshold
    {
        get
        {
            return GetPrimaryDampThreshold();
        }
        set
        {
            SetPrimaryDampThreshold(value);
        }
    }

    /// <summary>
    /// <para>The limit angle of positive side of the primary rotation when <see cref="Godot.LookAtModifier3D.SymmetryLimitation"/> is <see langword="false"/>, in radians.</para>
    /// </summary>
    public float PrimaryPositiveLimitAngle
    {
        get
        {
            return GetPrimaryPositiveLimitAngle();
        }
        set
        {
            SetPrimaryPositiveLimitAngle(value);
        }
    }

    /// <summary>
    /// <para>The threshold to start damping for <see cref="Godot.LookAtModifier3D.PrimaryPositiveLimitAngle"/>.</para>
    /// </summary>
    public float PrimaryPositiveDampThreshold
    {
        get
        {
            return GetPrimaryPositiveDampThreshold();
        }
        set
        {
            SetPrimaryPositiveDampThreshold(value);
        }
    }

    /// <summary>
    /// <para>The limit angle of negative side of the primary rotation when <see cref="Godot.LookAtModifier3D.SymmetryLimitation"/> is <see langword="false"/>, in radians.</para>
    /// </summary>
    public float PrimaryNegativeLimitAngle
    {
        get
        {
            return GetPrimaryNegativeLimitAngle();
        }
        set
        {
            SetPrimaryNegativeLimitAngle(value);
        }
    }

    /// <summary>
    /// <para>The threshold to start damping for <see cref="Godot.LookAtModifier3D.PrimaryNegativeLimitAngle"/>.</para>
    /// </summary>
    public float PrimaryNegativeDampThreshold
    {
        get
        {
            return GetPrimaryNegativeDampThreshold();
        }
        set
        {
            SetPrimaryNegativeDampThreshold(value);
        }
    }

    /// <summary>
    /// <para>The limit angle of the secondary rotation when <see cref="Godot.LookAtModifier3D.SymmetryLimitation"/> is <see langword="true"/>, in radians.</para>
    /// </summary>
    public float SecondaryLimitAngle
    {
        get
        {
            return GetSecondaryLimitAngle();
        }
        set
        {
            SetSecondaryLimitAngle(value);
        }
    }

    /// <summary>
    /// <para>The threshold to start damping for <see cref="Godot.LookAtModifier3D.SecondaryLimitAngle"/>.</para>
    /// </summary>
    public float SecondaryDampThreshold
    {
        get
        {
            return GetSecondaryDampThreshold();
        }
        set
        {
            SetSecondaryDampThreshold(value);
        }
    }

    /// <summary>
    /// <para>The limit angle of positive side of the secondary rotation when <see cref="Godot.LookAtModifier3D.SymmetryLimitation"/> is <see langword="false"/>, in radians.</para>
    /// </summary>
    public float SecondaryPositiveLimitAngle
    {
        get
        {
            return GetSecondaryPositiveLimitAngle();
        }
        set
        {
            SetSecondaryPositiveLimitAngle(value);
        }
    }

    /// <summary>
    /// <para>The threshold to start damping for <see cref="Godot.LookAtModifier3D.SecondaryPositiveLimitAngle"/>.</para>
    /// </summary>
    public float SecondaryPositiveDampThreshold
    {
        get
        {
            return GetSecondaryPositiveDampThreshold();
        }
        set
        {
            SetSecondaryPositiveDampThreshold(value);
        }
    }

    /// <summary>
    /// <para>The limit angle of negative side of the secondary rotation when <see cref="Godot.LookAtModifier3D.SymmetryLimitation"/> is <see langword="false"/>, in radians.</para>
    /// </summary>
    public float SecondaryNegativeLimitAngle
    {
        get
        {
            return GetSecondaryNegativeLimitAngle();
        }
        set
        {
            SetSecondaryNegativeLimitAngle(value);
        }
    }

    /// <summary>
    /// <para>The threshold to start damping for <see cref="Godot.LookAtModifier3D.SecondaryNegativeLimitAngle"/>.</para>
    /// </summary>
    public float SecondaryNegativeDampThreshold
    {
        get
        {
            return GetSecondaryNegativeDampThreshold();
        }
        set
        {
            SetSecondaryNegativeDampThreshold(value);
        }
    }

    private static readonly System.Type CachedType = typeof(LookAtModifier3D);

    private static readonly StringName NativeName = "LookAtModifier3D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public LookAtModifier3D() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal LookAtModifier3D(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal LookAtModifier3D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTargetNode, 1348162250ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTargetNode(NodePath targetNode)
    {
        NativeCalls.godot_icall_1_123(MethodBind0, GodotObject.GetPtr(this), (godot_node_path)(targetNode?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTargetNode, 4075236667ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public NodePath GetTargetNode()
    {
        return NativeCalls.godot_icall_0_124(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBoneName, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetBoneName(string boneName)
    {
        NativeCalls.godot_icall_1_57(MethodBind2, GodotObject.GetPtr(this), boneName);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBoneName, 201670096ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetBoneName()
    {
        return NativeCalls.godot_icall_0_58(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBone, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetBone(int bone)
    {
        NativeCalls.godot_icall_1_38(MethodBind4, GodotObject.GetPtr(this), bone);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBone, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetBone()
    {
        return NativeCalls.godot_icall_0_39(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetForwardAxis, 3199955933ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetForwardAxis(SkeletonModifier3D.BoneAxis forwardAxis)
    {
        NativeCalls.godot_icall_1_38(MethodBind6, GodotObject.GetPtr(this), (int)forwardAxis);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetForwardAxis, 4076020284ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public SkeletonModifier3D.BoneAxis GetForwardAxis()
    {
        return (SkeletonModifier3D.BoneAxis)NativeCalls.godot_icall_0_39(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPrimaryRotationAxis, 1144690656ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPrimaryRotationAxis(Vector3.Axis axis)
    {
        NativeCalls.godot_icall_1_38(MethodBind8, GodotObject.GetPtr(this), (int)axis);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPrimaryRotationAxis, 3050976882ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector3.Axis GetPrimaryRotationAxis()
    {
        return (Vector3.Axis)NativeCalls.godot_icall_0_39(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetUseSecondaryRotation, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetUseSecondaryRotation(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind10, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsUsingSecondaryRotation, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsUsingSecondaryRotation()
    {
        return NativeCalls.godot_icall_0_15(MethodBind11, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRelative, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetRelative(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind12, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsRelative, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsRelative()
    {
        return NativeCalls.godot_icall_0_15(MethodBind13, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetOriginSafeMargin, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetOriginSafeMargin(float margin)
    {
        NativeCalls.godot_icall_1_67(MethodBind14, GodotObject.GetPtr(this), margin);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOriginSafeMargin, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetOriginSafeMargin()
    {
        return NativeCalls.godot_icall_0_68(MethodBind15, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetOriginFrom, 4254695669ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetOriginFrom(LookAtModifier3D.OriginFromEnum originFrom)
    {
        NativeCalls.godot_icall_1_38(MethodBind16, GodotObject.GetPtr(this), (int)originFrom);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOriginFrom, 4057166297ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public LookAtModifier3D.OriginFromEnum GetOriginFrom()
    {
        return (LookAtModifier3D.OriginFromEnum)NativeCalls.godot_icall_0_39(MethodBind17, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetOriginBoneName, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetOriginBoneName(string boneName)
    {
        NativeCalls.godot_icall_1_57(MethodBind18, GodotObject.GetPtr(this), boneName);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOriginBoneName, 201670096ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetOriginBoneName()
    {
        return NativeCalls.godot_icall_0_58(MethodBind19, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetOriginBone, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetOriginBone(int bone)
    {
        NativeCalls.godot_icall_1_38(MethodBind20, GodotObject.GetPtr(this), bone);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOriginBone, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetOriginBone()
    {
        return NativeCalls.godot_icall_0_39(MethodBind21, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetOriginExternalNode, 1348162250ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetOriginExternalNode(NodePath externalNode)
    {
        NativeCalls.godot_icall_1_123(MethodBind22, GodotObject.GetPtr(this), (godot_node_path)(externalNode?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOriginExternalNode, 4075236667ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public NodePath GetOriginExternalNode()
    {
        return NativeCalls.godot_icall_0_124(MethodBind23, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetOriginOffset, 3460891852ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetOriginOffset(Vector3 offset)
    {
        NativeCalls.godot_icall_1_177(MethodBind24, GodotObject.GetPtr(this), &offset);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetOriginOffset, 3360562783ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector3 GetOriginOffset()
    {
        return NativeCalls.godot_icall_0_125(MethodBind25, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDuration, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDuration(float duration)
    {
        NativeCalls.godot_icall_1_67(MethodBind26, GodotObject.GetPtr(this), duration);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDuration, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetDuration()
    {
        return NativeCalls.godot_icall_0_68(MethodBind27, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTransitionType, 1058637742ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTransitionType(Tween.TransitionType transitionType)
    {
        NativeCalls.godot_icall_1_38(MethodBind28, GodotObject.GetPtr(this), (int)transitionType);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTransitionType, 3842314528ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Tween.TransitionType GetTransitionType()
    {
        return (Tween.TransitionType)NativeCalls.godot_icall_0_39(MethodBind29, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEaseType, 1208105857ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEaseType(Tween.EaseType easeType)
    {
        NativeCalls.godot_icall_1_38(MethodBind30, GodotObject.GetPtr(this), (int)easeType);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEaseType, 631880200ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Tween.EaseType GetEaseType()
    {
        return (Tween.EaseType)NativeCalls.godot_icall_0_39(MethodBind31, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind32 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetUseAngleLimitation, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetUseAngleLimitation(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind32, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind33 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsUsingAngleLimitation, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsUsingAngleLimitation()
    {
        return NativeCalls.godot_icall_0_15(MethodBind33, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind34 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSymmetryLimitation, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSymmetryLimitation(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind34, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind35 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsLimitationSymmetry, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsLimitationSymmetry()
    {
        return NativeCalls.godot_icall_0_15(MethodBind35, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind36 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPrimaryLimitAngle, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPrimaryLimitAngle(float angle)
    {
        NativeCalls.godot_icall_1_67(MethodBind36, GodotObject.GetPtr(this), angle);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind37 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPrimaryLimitAngle, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetPrimaryLimitAngle()
    {
        return NativeCalls.godot_icall_0_68(MethodBind37, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind38 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPrimaryDampThreshold, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPrimaryDampThreshold(float power)
    {
        NativeCalls.godot_icall_1_67(MethodBind38, GodotObject.GetPtr(this), power);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind39 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPrimaryDampThreshold, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetPrimaryDampThreshold()
    {
        return NativeCalls.godot_icall_0_68(MethodBind39, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind40 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPrimaryPositiveLimitAngle, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPrimaryPositiveLimitAngle(float angle)
    {
        NativeCalls.godot_icall_1_67(MethodBind40, GodotObject.GetPtr(this), angle);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind41 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPrimaryPositiveLimitAngle, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetPrimaryPositiveLimitAngle()
    {
        return NativeCalls.godot_icall_0_68(MethodBind41, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind42 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPrimaryPositiveDampThreshold, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPrimaryPositiveDampThreshold(float power)
    {
        NativeCalls.godot_icall_1_67(MethodBind42, GodotObject.GetPtr(this), power);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind43 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPrimaryPositiveDampThreshold, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetPrimaryPositiveDampThreshold()
    {
        return NativeCalls.godot_icall_0_68(MethodBind43, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind44 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPrimaryNegativeLimitAngle, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPrimaryNegativeLimitAngle(float angle)
    {
        NativeCalls.godot_icall_1_67(MethodBind44, GodotObject.GetPtr(this), angle);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind45 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPrimaryNegativeLimitAngle, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetPrimaryNegativeLimitAngle()
    {
        return NativeCalls.godot_icall_0_68(MethodBind45, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind46 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPrimaryNegativeDampThreshold, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPrimaryNegativeDampThreshold(float power)
    {
        NativeCalls.godot_icall_1_67(MethodBind46, GodotObject.GetPtr(this), power);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind47 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPrimaryNegativeDampThreshold, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetPrimaryNegativeDampThreshold()
    {
        return NativeCalls.godot_icall_0_68(MethodBind47, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind48 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSecondaryLimitAngle, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSecondaryLimitAngle(float angle)
    {
        NativeCalls.godot_icall_1_67(MethodBind48, GodotObject.GetPtr(this), angle);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind49 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSecondaryLimitAngle, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetSecondaryLimitAngle()
    {
        return NativeCalls.godot_icall_0_68(MethodBind49, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind50 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSecondaryDampThreshold, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSecondaryDampThreshold(float power)
    {
        NativeCalls.godot_icall_1_67(MethodBind50, GodotObject.GetPtr(this), power);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind51 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSecondaryDampThreshold, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetSecondaryDampThreshold()
    {
        return NativeCalls.godot_icall_0_68(MethodBind51, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind52 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSecondaryPositiveLimitAngle, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSecondaryPositiveLimitAngle(float angle)
    {
        NativeCalls.godot_icall_1_67(MethodBind52, GodotObject.GetPtr(this), angle);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind53 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSecondaryPositiveLimitAngle, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetSecondaryPositiveLimitAngle()
    {
        return NativeCalls.godot_icall_0_68(MethodBind53, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind54 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSecondaryPositiveDampThreshold, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSecondaryPositiveDampThreshold(float power)
    {
        NativeCalls.godot_icall_1_67(MethodBind54, GodotObject.GetPtr(this), power);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind55 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSecondaryPositiveDampThreshold, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetSecondaryPositiveDampThreshold()
    {
        return NativeCalls.godot_icall_0_68(MethodBind55, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind56 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSecondaryNegativeLimitAngle, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSecondaryNegativeLimitAngle(float angle)
    {
        NativeCalls.godot_icall_1_67(MethodBind56, GodotObject.GetPtr(this), angle);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind57 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSecondaryNegativeLimitAngle, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetSecondaryNegativeLimitAngle()
    {
        return NativeCalls.godot_icall_0_68(MethodBind57, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind58 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSecondaryNegativeDampThreshold, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSecondaryNegativeDampThreshold(float power)
    {
        NativeCalls.godot_icall_1_67(MethodBind58, GodotObject.GetPtr(this), power);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind59 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSecondaryNegativeDampThreshold, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetSecondaryNegativeDampThreshold()
    {
        return NativeCalls.godot_icall_0_68(MethodBind59, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind60 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetInterpolationRemaining, 1740695150ul);

    /// <summary>
    /// <para>Returns the remaining seconds of the time-based interpolation.</para>
    /// </summary>
    public float GetInterpolationRemaining()
    {
        return NativeCalls.godot_icall_0_68(MethodBind60, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind61 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsInterpolating, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if time-based interpolation is running. If <see langword="true"/>, it is equivalent to <see cref="Godot.LookAtModifier3D.GetInterpolationRemaining()"/> returning <c>0.0</c>.</para>
    /// <para>This is useful to determine whether a <see cref="Godot.LookAtModifier3D"/> can be removed safely.</para>
    /// </summary>
    public bool IsInterpolating()
    {
        return NativeCalls.godot_icall_0_15(MethodBind61, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind62 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsTargetWithinLimitation, 36873697ul);

    /// <summary>
    /// <para>Returns whether the target is within the angle limitations. It is useful for unsetting the <see cref="Godot.LookAtModifier3D.TargetNode"/> when the target is outside of the angle limitations.</para>
    /// <para><b>Note:</b> The value is updated after <see cref="Godot.SkeletonModifier3D._ProcessModification()"/>. To retrieve this value correctly, we recommend using the signal <see cref="Godot.SkeletonModifier3D.ModificationProcessed"/>.</para>
    /// </summary>
    public bool IsTargetWithinLimitation()
    {
        return NativeCalls.godot_icall_0_15(MethodBind62, GodotObject.GetPtr(this)).ToBool();
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
        /// Cached name for the 'target_node' property.
        /// </summary>
        public static readonly StringName TargetNode = "target_node";
        /// <summary>
        /// Cached name for the 'bone_name' property.
        /// </summary>
        public static readonly StringName BoneName = "bone_name";
        /// <summary>
        /// Cached name for the 'bone' property.
        /// </summary>
        public static readonly StringName Bone = "bone";
        /// <summary>
        /// Cached name for the 'forward_axis' property.
        /// </summary>
        public static readonly StringName ForwardAxis = "forward_axis";
        /// <summary>
        /// Cached name for the 'primary_rotation_axis' property.
        /// </summary>
        public static readonly StringName PrimaryRotationAxis = "primary_rotation_axis";
        /// <summary>
        /// Cached name for the 'use_secondary_rotation' property.
        /// </summary>
        public static readonly StringName UseSecondaryRotation = "use_secondary_rotation";
        /// <summary>
        /// Cached name for the 'relative' property.
        /// </summary>
        public static readonly StringName Relative = "relative";
        /// <summary>
        /// Cached name for the 'origin_from' property.
        /// </summary>
        public static readonly StringName OriginFrom = "origin_from";
        /// <summary>
        /// Cached name for the 'origin_bone_name' property.
        /// </summary>
        public static readonly StringName OriginBoneName = "origin_bone_name";
        /// <summary>
        /// Cached name for the 'origin_bone' property.
        /// </summary>
        public static readonly StringName OriginBone = "origin_bone";
        /// <summary>
        /// Cached name for the 'origin_external_node' property.
        /// </summary>
        public static readonly StringName OriginExternalNode = "origin_external_node";
        /// <summary>
        /// Cached name for the 'origin_offset' property.
        /// </summary>
        public static readonly StringName OriginOffset = "origin_offset";
        /// <summary>
        /// Cached name for the 'origin_safe_margin' property.
        /// </summary>
        public static readonly StringName OriginSafeMargin = "origin_safe_margin";
        /// <summary>
        /// Cached name for the 'duration' property.
        /// </summary>
        public static readonly StringName Duration = "duration";
        /// <summary>
        /// Cached name for the 'transition_type' property.
        /// </summary>
        public static readonly StringName TransitionType = "transition_type";
        /// <summary>
        /// Cached name for the 'ease_type' property.
        /// </summary>
        public static readonly StringName EaseType = "ease_type";
        /// <summary>
        /// Cached name for the 'use_angle_limitation' property.
        /// </summary>
        public static readonly StringName UseAngleLimitation = "use_angle_limitation";
        /// <summary>
        /// Cached name for the 'symmetry_limitation' property.
        /// </summary>
        public static readonly StringName SymmetryLimitation = "symmetry_limitation";
        /// <summary>
        /// Cached name for the 'primary_limit_angle' property.
        /// </summary>
        public static readonly StringName PrimaryLimitAngle = "primary_limit_angle";
        /// <summary>
        /// Cached name for the 'primary_damp_threshold' property.
        /// </summary>
        public static readonly StringName PrimaryDampThreshold = "primary_damp_threshold";
        /// <summary>
        /// Cached name for the 'primary_positive_limit_angle' property.
        /// </summary>
        public static readonly StringName PrimaryPositiveLimitAngle = "primary_positive_limit_angle";
        /// <summary>
        /// Cached name for the 'primary_positive_damp_threshold' property.
        /// </summary>
        public static readonly StringName PrimaryPositiveDampThreshold = "primary_positive_damp_threshold";
        /// <summary>
        /// Cached name for the 'primary_negative_limit_angle' property.
        /// </summary>
        public static readonly StringName PrimaryNegativeLimitAngle = "primary_negative_limit_angle";
        /// <summary>
        /// Cached name for the 'primary_negative_damp_threshold' property.
        /// </summary>
        public static readonly StringName PrimaryNegativeDampThreshold = "primary_negative_damp_threshold";
        /// <summary>
        /// Cached name for the 'secondary_limit_angle' property.
        /// </summary>
        public static readonly StringName SecondaryLimitAngle = "secondary_limit_angle";
        /// <summary>
        /// Cached name for the 'secondary_damp_threshold' property.
        /// </summary>
        public static readonly StringName SecondaryDampThreshold = "secondary_damp_threshold";
        /// <summary>
        /// Cached name for the 'secondary_positive_limit_angle' property.
        /// </summary>
        public static readonly StringName SecondaryPositiveLimitAngle = "secondary_positive_limit_angle";
        /// <summary>
        /// Cached name for the 'secondary_positive_damp_threshold' property.
        /// </summary>
        public static readonly StringName SecondaryPositiveDampThreshold = "secondary_positive_damp_threshold";
        /// <summary>
        /// Cached name for the 'secondary_negative_limit_angle' property.
        /// </summary>
        public static readonly StringName SecondaryNegativeLimitAngle = "secondary_negative_limit_angle";
        /// <summary>
        /// Cached name for the 'secondary_negative_damp_threshold' property.
        /// </summary>
        public static readonly StringName SecondaryNegativeDampThreshold = "secondary_negative_damp_threshold";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : SkeletonModifier3D.MethodName
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
        /// Cached name for the 'set_bone_name' method.
        /// </summary>
        public static readonly StringName SetBoneName = "set_bone_name";
        /// <summary>
        /// Cached name for the 'get_bone_name' method.
        /// </summary>
        public static readonly StringName GetBoneName = "get_bone_name";
        /// <summary>
        /// Cached name for the 'set_bone' method.
        /// </summary>
        public static readonly StringName SetBone = "set_bone";
        /// <summary>
        /// Cached name for the 'get_bone' method.
        /// </summary>
        public static readonly StringName GetBone = "get_bone";
        /// <summary>
        /// Cached name for the 'set_forward_axis' method.
        /// </summary>
        public static readonly StringName SetForwardAxis = "set_forward_axis";
        /// <summary>
        /// Cached name for the 'get_forward_axis' method.
        /// </summary>
        public static readonly StringName GetForwardAxis = "get_forward_axis";
        /// <summary>
        /// Cached name for the 'set_primary_rotation_axis' method.
        /// </summary>
        public static readonly StringName SetPrimaryRotationAxis = "set_primary_rotation_axis";
        /// <summary>
        /// Cached name for the 'get_primary_rotation_axis' method.
        /// </summary>
        public static readonly StringName GetPrimaryRotationAxis = "get_primary_rotation_axis";
        /// <summary>
        /// Cached name for the 'set_use_secondary_rotation' method.
        /// </summary>
        public static readonly StringName SetUseSecondaryRotation = "set_use_secondary_rotation";
        /// <summary>
        /// Cached name for the 'is_using_secondary_rotation' method.
        /// </summary>
        public static readonly StringName IsUsingSecondaryRotation = "is_using_secondary_rotation";
        /// <summary>
        /// Cached name for the 'set_relative' method.
        /// </summary>
        public static readonly StringName SetRelative = "set_relative";
        /// <summary>
        /// Cached name for the 'is_relative' method.
        /// </summary>
        public static readonly StringName IsRelative = "is_relative";
        /// <summary>
        /// Cached name for the 'set_origin_safe_margin' method.
        /// </summary>
        public static readonly StringName SetOriginSafeMargin = "set_origin_safe_margin";
        /// <summary>
        /// Cached name for the 'get_origin_safe_margin' method.
        /// </summary>
        public static readonly StringName GetOriginSafeMargin = "get_origin_safe_margin";
        /// <summary>
        /// Cached name for the 'set_origin_from' method.
        /// </summary>
        public static readonly StringName SetOriginFrom = "set_origin_from";
        /// <summary>
        /// Cached name for the 'get_origin_from' method.
        /// </summary>
        public static readonly StringName GetOriginFrom = "get_origin_from";
        /// <summary>
        /// Cached name for the 'set_origin_bone_name' method.
        /// </summary>
        public static readonly StringName SetOriginBoneName = "set_origin_bone_name";
        /// <summary>
        /// Cached name for the 'get_origin_bone_name' method.
        /// </summary>
        public static readonly StringName GetOriginBoneName = "get_origin_bone_name";
        /// <summary>
        /// Cached name for the 'set_origin_bone' method.
        /// </summary>
        public static readonly StringName SetOriginBone = "set_origin_bone";
        /// <summary>
        /// Cached name for the 'get_origin_bone' method.
        /// </summary>
        public static readonly StringName GetOriginBone = "get_origin_bone";
        /// <summary>
        /// Cached name for the 'set_origin_external_node' method.
        /// </summary>
        public static readonly StringName SetOriginExternalNode = "set_origin_external_node";
        /// <summary>
        /// Cached name for the 'get_origin_external_node' method.
        /// </summary>
        public static readonly StringName GetOriginExternalNode = "get_origin_external_node";
        /// <summary>
        /// Cached name for the 'set_origin_offset' method.
        /// </summary>
        public static readonly StringName SetOriginOffset = "set_origin_offset";
        /// <summary>
        /// Cached name for the 'get_origin_offset' method.
        /// </summary>
        public static readonly StringName GetOriginOffset = "get_origin_offset";
        /// <summary>
        /// Cached name for the 'set_duration' method.
        /// </summary>
        public static readonly StringName SetDuration = "set_duration";
        /// <summary>
        /// Cached name for the 'get_duration' method.
        /// </summary>
        public static readonly StringName GetDuration = "get_duration";
        /// <summary>
        /// Cached name for the 'set_transition_type' method.
        /// </summary>
        public static readonly StringName SetTransitionType = "set_transition_type";
        /// <summary>
        /// Cached name for the 'get_transition_type' method.
        /// </summary>
        public static readonly StringName GetTransitionType = "get_transition_type";
        /// <summary>
        /// Cached name for the 'set_ease_type' method.
        /// </summary>
        public static readonly StringName SetEaseType = "set_ease_type";
        /// <summary>
        /// Cached name for the 'get_ease_type' method.
        /// </summary>
        public static readonly StringName GetEaseType = "get_ease_type";
        /// <summary>
        /// Cached name for the 'set_use_angle_limitation' method.
        /// </summary>
        public static readonly StringName SetUseAngleLimitation = "set_use_angle_limitation";
        /// <summary>
        /// Cached name for the 'is_using_angle_limitation' method.
        /// </summary>
        public static readonly StringName IsUsingAngleLimitation = "is_using_angle_limitation";
        /// <summary>
        /// Cached name for the 'set_symmetry_limitation' method.
        /// </summary>
        public static readonly StringName SetSymmetryLimitation = "set_symmetry_limitation";
        /// <summary>
        /// Cached name for the 'is_limitation_symmetry' method.
        /// </summary>
        public static readonly StringName IsLimitationSymmetry = "is_limitation_symmetry";
        /// <summary>
        /// Cached name for the 'set_primary_limit_angle' method.
        /// </summary>
        public static readonly StringName SetPrimaryLimitAngle = "set_primary_limit_angle";
        /// <summary>
        /// Cached name for the 'get_primary_limit_angle' method.
        /// </summary>
        public static readonly StringName GetPrimaryLimitAngle = "get_primary_limit_angle";
        /// <summary>
        /// Cached name for the 'set_primary_damp_threshold' method.
        /// </summary>
        public static readonly StringName SetPrimaryDampThreshold = "set_primary_damp_threshold";
        /// <summary>
        /// Cached name for the 'get_primary_damp_threshold' method.
        /// </summary>
        public static readonly StringName GetPrimaryDampThreshold = "get_primary_damp_threshold";
        /// <summary>
        /// Cached name for the 'set_primary_positive_limit_angle' method.
        /// </summary>
        public static readonly StringName SetPrimaryPositiveLimitAngle = "set_primary_positive_limit_angle";
        /// <summary>
        /// Cached name for the 'get_primary_positive_limit_angle' method.
        /// </summary>
        public static readonly StringName GetPrimaryPositiveLimitAngle = "get_primary_positive_limit_angle";
        /// <summary>
        /// Cached name for the 'set_primary_positive_damp_threshold' method.
        /// </summary>
        public static readonly StringName SetPrimaryPositiveDampThreshold = "set_primary_positive_damp_threshold";
        /// <summary>
        /// Cached name for the 'get_primary_positive_damp_threshold' method.
        /// </summary>
        public static readonly StringName GetPrimaryPositiveDampThreshold = "get_primary_positive_damp_threshold";
        /// <summary>
        /// Cached name for the 'set_primary_negative_limit_angle' method.
        /// </summary>
        public static readonly StringName SetPrimaryNegativeLimitAngle = "set_primary_negative_limit_angle";
        /// <summary>
        /// Cached name for the 'get_primary_negative_limit_angle' method.
        /// </summary>
        public static readonly StringName GetPrimaryNegativeLimitAngle = "get_primary_negative_limit_angle";
        /// <summary>
        /// Cached name for the 'set_primary_negative_damp_threshold' method.
        /// </summary>
        public static readonly StringName SetPrimaryNegativeDampThreshold = "set_primary_negative_damp_threshold";
        /// <summary>
        /// Cached name for the 'get_primary_negative_damp_threshold' method.
        /// </summary>
        public static readonly StringName GetPrimaryNegativeDampThreshold = "get_primary_negative_damp_threshold";
        /// <summary>
        /// Cached name for the 'set_secondary_limit_angle' method.
        /// </summary>
        public static readonly StringName SetSecondaryLimitAngle = "set_secondary_limit_angle";
        /// <summary>
        /// Cached name for the 'get_secondary_limit_angle' method.
        /// </summary>
        public static readonly StringName GetSecondaryLimitAngle = "get_secondary_limit_angle";
        /// <summary>
        /// Cached name for the 'set_secondary_damp_threshold' method.
        /// </summary>
        public static readonly StringName SetSecondaryDampThreshold = "set_secondary_damp_threshold";
        /// <summary>
        /// Cached name for the 'get_secondary_damp_threshold' method.
        /// </summary>
        public static readonly StringName GetSecondaryDampThreshold = "get_secondary_damp_threshold";
        /// <summary>
        /// Cached name for the 'set_secondary_positive_limit_angle' method.
        /// </summary>
        public static readonly StringName SetSecondaryPositiveLimitAngle = "set_secondary_positive_limit_angle";
        /// <summary>
        /// Cached name for the 'get_secondary_positive_limit_angle' method.
        /// </summary>
        public static readonly StringName GetSecondaryPositiveLimitAngle = "get_secondary_positive_limit_angle";
        /// <summary>
        /// Cached name for the 'set_secondary_positive_damp_threshold' method.
        /// </summary>
        public static readonly StringName SetSecondaryPositiveDampThreshold = "set_secondary_positive_damp_threshold";
        /// <summary>
        /// Cached name for the 'get_secondary_positive_damp_threshold' method.
        /// </summary>
        public static readonly StringName GetSecondaryPositiveDampThreshold = "get_secondary_positive_damp_threshold";
        /// <summary>
        /// Cached name for the 'set_secondary_negative_limit_angle' method.
        /// </summary>
        public static readonly StringName SetSecondaryNegativeLimitAngle = "set_secondary_negative_limit_angle";
        /// <summary>
        /// Cached name for the 'get_secondary_negative_limit_angle' method.
        /// </summary>
        public static readonly StringName GetSecondaryNegativeLimitAngle = "get_secondary_negative_limit_angle";
        /// <summary>
        /// Cached name for the 'set_secondary_negative_damp_threshold' method.
        /// </summary>
        public static readonly StringName SetSecondaryNegativeDampThreshold = "set_secondary_negative_damp_threshold";
        /// <summary>
        /// Cached name for the 'get_secondary_negative_damp_threshold' method.
        /// </summary>
        public static readonly StringName GetSecondaryNegativeDampThreshold = "get_secondary_negative_damp_threshold";
        /// <summary>
        /// Cached name for the 'get_interpolation_remaining' method.
        /// </summary>
        public static readonly StringName GetInterpolationRemaining = "get_interpolation_remaining";
        /// <summary>
        /// Cached name for the 'is_interpolating' method.
        /// </summary>
        public static readonly StringName IsInterpolating = "is_interpolating";
        /// <summary>
        /// Cached name for the 'is_target_within_limitation' method.
        /// </summary>
        public static readonly StringName IsTargetWithinLimitation = "is_target_within_limitation";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : SkeletonModifier3D.SignalName
    {
    }
}
