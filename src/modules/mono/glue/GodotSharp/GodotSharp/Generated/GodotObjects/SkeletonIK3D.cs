namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>SkeletonIK3D is used to rotate all bones of a <see cref="Godot.Skeleton3D"/> bone chain a way that places the end bone at a desired 3D position. A typical scenario for IK in games is to place a character's feet on the ground or a character's hands on a currently held object. SkeletonIK uses FabrikInverseKinematic internally to solve the bone chain and applies the results to the <see cref="Godot.Skeleton3D"/> <c>bones_global_pose_override</c> property for all affected bones in the chain. If fully applied, this overwrites any bone transform from <see cref="Godot.Animation"/>s or bone custom poses set by users. The applied amount can be controlled with the <see cref="Godot.SkeletonModifier3D.Influence"/> property.</para>
/// <para><code>
/// # Apply IK effect automatically on every new frame (not the current)
/// skeleton_ik_node.start()
/// 
/// # Apply IK effect only on the current frame
/// skeleton_ik_node.start(true)
/// 
/// # Stop IK effect and reset bones_global_pose_override on Skeleton
/// skeleton_ik_node.stop()
/// 
/// # Apply full IK effect
/// skeleton_ik_node.set_influence(1.0)
/// 
/// # Apply half IK effect
/// skeleton_ik_node.set_influence(0.5)
/// 
/// # Apply zero IK effect (a value at or below 0.01 also removes bones_global_pose_override on Skeleton)
/// skeleton_ik_node.set_influence(0.0)
/// </code></para>
/// </summary>
[Obsolete("This class is deprecated.")]
public partial class SkeletonIK3D : SkeletonModifier3D
{
    /// <summary>
    /// <para>The name of the current root bone, the first bone in the IK chain.</para>
    /// </summary>
    public StringName RootBone
    {
        get
        {
            return GetRootBone();
        }
        set
        {
            SetRootBone(value);
        }
    }

    /// <summary>
    /// <para>The name of the current tip bone, the last bone in the IK chain placed at the <see cref="Godot.SkeletonIK3D.Target"/> transform (or <see cref="Godot.SkeletonIK3D.TargetNode"/> if defined).</para>
    /// </summary>
    public StringName TipBone
    {
        get
        {
            return GetTipBone();
        }
        set
        {
            SetTipBone(value);
        }
    }

    /// <summary>
    /// <para>First target of the IK chain where the tip bone is placed and, if <see cref="Godot.SkeletonIK3D.OverrideTipBasis"/> is <see langword="true"/>, how the tip bone is rotated. If a <see cref="Godot.SkeletonIK3D.TargetNode"/> path is available the nodes transform is used instead and this property is ignored.</para>
    /// </summary>
    public Transform3D Target
    {
        get
        {
            return GetTargetTransform();
        }
        set
        {
            SetTargetTransform(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/> overwrites the rotation of the tip bone with the rotation of the <see cref="Godot.SkeletonIK3D.Target"/> (or <see cref="Godot.SkeletonIK3D.TargetNode"/> if defined).</para>
    /// </summary>
    public bool OverrideTipBasis
    {
        get
        {
            return IsOverrideTipBasis();
        }
        set
        {
            SetOverrideTipBasis(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, instructs the IK solver to consider the secondary magnet target (pole target) when calculating the bone chain. Use the magnet position (pole target) to control the bending of the IK chain.</para>
    /// </summary>
    public bool UseMagnet
    {
        get
        {
            return IsUsingMagnet();
        }
        set
        {
            SetUseMagnet(value);
        }
    }

    /// <summary>
    /// <para>Secondary target position (first is <see cref="Godot.SkeletonIK3D.Target"/> property or <see cref="Godot.SkeletonIK3D.TargetNode"/>) for the IK chain. Use magnet position (pole target) to control the bending of the IK chain. Only works if the bone chain has more than 2 bones. The middle chain bone position will be linearly interpolated with the magnet position.</para>
    /// </summary>
    public Vector3 Magnet
    {
        get
        {
            return GetMagnetPosition();
        }
        set
        {
            SetMagnetPosition(value);
        }
    }

    /// <summary>
    /// <para>Target node <see cref="Godot.NodePath"/> for the IK chain. If available, the node's current <see cref="Godot.Transform3D"/> is used instead of the <see cref="Godot.SkeletonIK3D.Target"/> property.</para>
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
    /// <para>The minimum distance between bone and goal target. If the distance is below this value, the IK solver stops further iterations.</para>
    /// </summary>
    public float MinDistance
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
    /// <para>Number of iteration loops used by the IK solver to produce more accurate (and elegant) bone chain results.</para>
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
    /// <para>Interpolation value for how much the IK results are applied to the current skeleton bone chain. A value of <c>1.0</c> will overwrite all skeleton bone transforms completely while a value of <c>0.0</c> will visually disable the SkeletonIK.</para>
    /// </summary>
    [Obsolete("Use 'Godot.SkeletonModifier3D.Influence' instead.")]
    public float Interpolation
    {
        get
        {
            return GetInterpolation();
        }
        set
        {
            SetInterpolation(value);
        }
    }

    private static readonly System.Type CachedType = typeof(SkeletonIK3D);

    private static readonly StringName NativeName = "SkeletonIK3D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public SkeletonIK3D() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal SkeletonIK3D(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal SkeletonIK3D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRootBone, 3304788590ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetRootBone(StringName rootBone)
    {
        NativeCalls.godot_icall_1_64(MethodBind0, GodotObject.GetPtr(this), (godot_string_name)(rootBone?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRootBone, 2002593661ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public StringName GetRootBone()
    {
        return NativeCalls.godot_icall_0_65(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTipBone, 3304788590ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTipBone(StringName tipBone)
    {
        NativeCalls.godot_icall_1_64(MethodBind2, GodotObject.GetPtr(this), (godot_string_name)(tipBone?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTipBone, 2002593661ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public StringName GetTipBone()
    {
        return NativeCalls.godot_icall_0_65(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTargetTransform, 2952846383ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetTargetTransform(Transform3D target)
    {
        NativeCalls.godot_icall_1_648(MethodBind4, GodotObject.GetPtr(this), &target);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTargetTransform, 3229777777ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Transform3D GetTargetTransform()
    {
        return NativeCalls.godot_icall_0_192(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTargetNode, 1348162250ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTargetNode(NodePath node)
    {
        NativeCalls.godot_icall_1_123(MethodBind6, GodotObject.GetPtr(this), (godot_node_path)(node?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTargetNode, 277076166ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public NodePath GetTargetNode()
    {
        return NativeCalls.godot_icall_0_124(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetOverrideTipBasis, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetOverrideTipBasis(bool @override)
    {
        NativeCalls.godot_icall_1_14(MethodBind8, GodotObject.GetPtr(this), @override.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsOverrideTipBasis, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsOverrideTipBasis()
    {
        return NativeCalls.godot_icall_0_15(MethodBind9, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetUseMagnet, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetUseMagnet(bool use)
    {
        NativeCalls.godot_icall_1_14(MethodBind10, GodotObject.GetPtr(this), use.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsUsingMagnet, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsUsingMagnet()
    {
        return NativeCalls.godot_icall_0_15(MethodBind11, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMagnetPosition, 3460891852ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetMagnetPosition(Vector3 localPosition)
    {
        NativeCalls.godot_icall_1_177(MethodBind12, GodotObject.GetPtr(this), &localPosition);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMagnetPosition, 3360562783ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector3 GetMagnetPosition()
    {
        return NativeCalls.godot_icall_0_125(MethodBind13, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetParentSkeleton, 1488626673ul);

    /// <summary>
    /// <para>Returns the parent <see cref="Godot.Skeleton3D"/> node that was present when SkeletonIK entered the scene tree. Returns <see langword="null"/> if the parent node was not a <see cref="Godot.Skeleton3D"/> node when SkeletonIK3D entered the scene tree.</para>
    /// </summary>
    public Skeleton3D GetParentSkeleton()
    {
        return (Skeleton3D)NativeCalls.godot_icall_0_53(MethodBind14, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsRunning, 2240911060ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if SkeletonIK is applying IK effects on continues frames to the <see cref="Godot.Skeleton3D"/> bones. Returns <see langword="false"/> if SkeletonIK is stopped or <see cref="Godot.SkeletonIK3D.Start(bool)"/> was used with the <c>one_time</c> parameter set to <see langword="true"/>.</para>
    /// </summary>
    public bool IsRunning()
    {
        return NativeCalls.godot_icall_0_15(MethodBind15, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMinDistance, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMinDistance(float minDistance)
    {
        NativeCalls.godot_icall_1_67(MethodBind16, GodotObject.GetPtr(this), minDistance);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMinDistance, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetMinDistance()
    {
        return NativeCalls.godot_icall_0_68(MethodBind17, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMaxIterations, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMaxIterations(int iterations)
    {
        NativeCalls.godot_icall_1_38(MethodBind18, GodotObject.GetPtr(this), iterations);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMaxIterations, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetMaxIterations()
    {
        return NativeCalls.godot_icall_0_39(MethodBind19, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Start, 107499316ul);

    /// <summary>
    /// <para>Starts applying IK effects on each frame to the <see cref="Godot.Skeleton3D"/> bones but will only take effect starting on the next frame. If <paramref name="oneTime"/> is <see langword="true"/>, this will take effect immediately but also reset on the next frame.</para>
    /// </summary>
    public void Start(bool oneTime = false)
    {
        NativeCalls.godot_icall_1_14(MethodBind20, GodotObject.GetPtr(this), oneTime.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Stop, 3218959716ul);

    /// <summary>
    /// <para>Stops applying IK effects on each frame to the <see cref="Godot.Skeleton3D"/> bones and also calls <see cref="Godot.Skeleton3D.ClearBonesGlobalPoseOverride()"/> to remove existing overrides on all bones.</para>
    /// </summary>
    public void Stop()
    {
        NativeCalls.godot_icall_0_3(MethodBind21, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetInterpolation, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetInterpolation(float interpolation)
    {
        NativeCalls.godot_icall_1_67(MethodBind22, GodotObject.GetPtr(this), interpolation);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetInterpolation, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetInterpolation()
    {
        return NativeCalls.godot_icall_0_68(MethodBind23, GodotObject.GetPtr(this));
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
        /// Cached name for the 'root_bone' property.
        /// </summary>
        public static readonly StringName RootBone = "root_bone";
        /// <summary>
        /// Cached name for the 'tip_bone' property.
        /// </summary>
        public static readonly StringName TipBone = "tip_bone";
        /// <summary>
        /// Cached name for the 'target' property.
        /// </summary>
        public static readonly StringName Target = "target";
        /// <summary>
        /// Cached name for the 'override_tip_basis' property.
        /// </summary>
        public static readonly StringName OverrideTipBasis = "override_tip_basis";
        /// <summary>
        /// Cached name for the 'use_magnet' property.
        /// </summary>
        public static readonly StringName UseMagnet = "use_magnet";
        /// <summary>
        /// Cached name for the 'magnet' property.
        /// </summary>
        public static readonly StringName Magnet = "magnet";
        /// <summary>
        /// Cached name for the 'target_node' property.
        /// </summary>
        public static readonly StringName TargetNode = "target_node";
        /// <summary>
        /// Cached name for the 'min_distance' property.
        /// </summary>
        public static readonly StringName MinDistance = "min_distance";
        /// <summary>
        /// Cached name for the 'max_iterations' property.
        /// </summary>
        public static readonly StringName MaxIterations = "max_iterations";
        /// <summary>
        /// Cached name for the 'interpolation' property.
        /// </summary>
        public static readonly StringName Interpolation = "interpolation";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : SkeletonModifier3D.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_root_bone' method.
        /// </summary>
        public static readonly StringName SetRootBone = "set_root_bone";
        /// <summary>
        /// Cached name for the 'get_root_bone' method.
        /// </summary>
        public static readonly StringName GetRootBone = "get_root_bone";
        /// <summary>
        /// Cached name for the 'set_tip_bone' method.
        /// </summary>
        public static readonly StringName SetTipBone = "set_tip_bone";
        /// <summary>
        /// Cached name for the 'get_tip_bone' method.
        /// </summary>
        public static readonly StringName GetTipBone = "get_tip_bone";
        /// <summary>
        /// Cached name for the 'set_target_transform' method.
        /// </summary>
        public static readonly StringName SetTargetTransform = "set_target_transform";
        /// <summary>
        /// Cached name for the 'get_target_transform' method.
        /// </summary>
        public static readonly StringName GetTargetTransform = "get_target_transform";
        /// <summary>
        /// Cached name for the 'set_target_node' method.
        /// </summary>
        public static readonly StringName SetTargetNode = "set_target_node";
        /// <summary>
        /// Cached name for the 'get_target_node' method.
        /// </summary>
        public static readonly StringName GetTargetNode = "get_target_node";
        /// <summary>
        /// Cached name for the 'set_override_tip_basis' method.
        /// </summary>
        public static readonly StringName SetOverrideTipBasis = "set_override_tip_basis";
        /// <summary>
        /// Cached name for the 'is_override_tip_basis' method.
        /// </summary>
        public static readonly StringName IsOverrideTipBasis = "is_override_tip_basis";
        /// <summary>
        /// Cached name for the 'set_use_magnet' method.
        /// </summary>
        public static readonly StringName SetUseMagnet = "set_use_magnet";
        /// <summary>
        /// Cached name for the 'is_using_magnet' method.
        /// </summary>
        public static readonly StringName IsUsingMagnet = "is_using_magnet";
        /// <summary>
        /// Cached name for the 'set_magnet_position' method.
        /// </summary>
        public static readonly StringName SetMagnetPosition = "set_magnet_position";
        /// <summary>
        /// Cached name for the 'get_magnet_position' method.
        /// </summary>
        public static readonly StringName GetMagnetPosition = "get_magnet_position";
        /// <summary>
        /// Cached name for the 'get_parent_skeleton' method.
        /// </summary>
        public static readonly StringName GetParentSkeleton = "get_parent_skeleton";
        /// <summary>
        /// Cached name for the 'is_running' method.
        /// </summary>
        public static readonly StringName IsRunning = "is_running";
        /// <summary>
        /// Cached name for the 'set_min_distance' method.
        /// </summary>
        public static readonly StringName SetMinDistance = "set_min_distance";
        /// <summary>
        /// Cached name for the 'get_min_distance' method.
        /// </summary>
        public static readonly StringName GetMinDistance = "get_min_distance";
        /// <summary>
        /// Cached name for the 'set_max_iterations' method.
        /// </summary>
        public static readonly StringName SetMaxIterations = "set_max_iterations";
        /// <summary>
        /// Cached name for the 'get_max_iterations' method.
        /// </summary>
        public static readonly StringName GetMaxIterations = "get_max_iterations";
        /// <summary>
        /// Cached name for the 'start' method.
        /// </summary>
        public static readonly StringName Start = "start";
        /// <summary>
        /// Cached name for the 'stop' method.
        /// </summary>
        public static readonly StringName Stop = "stop";
        /// <summary>
        /// Cached name for the 'set_interpolation' method.
        /// </summary>
        public static readonly StringName SetInterpolation = "set_interpolation";
        /// <summary>
        /// Cached name for the 'get_interpolation' method.
        /// </summary>
        public static readonly StringName GetInterpolation = "get_interpolation";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : SkeletonModifier3D.SignalName
    {
    }
}
