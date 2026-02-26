namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This node enables OpenXR's hand tracking functionality. The node should be a child node of an <see cref="Godot.XROrigin3D"/> node, tracking will update its position to the player's tracked hand Palm joint location (the center of the middle finger's metacarpal bone). This node also updates the skeleton of a properly skinned hand or avatar model.</para>
/// <para>If the skeleton is a hand (one of the hand bones is the root node of the skeleton), then the skeleton will be placed relative to the hand palm location and the hand mesh and skeleton should be children of the OpenXRHand node.</para>
/// <para>If the hand bones are part of a full skeleton, then the root of the hand will keep its location with the assumption that IK is used to position the hand and arm.</para>
/// <para>By default the skeleton hand bones are repositioned to match the size of the tracked hand. To preserve the modeled bone sizes change <see cref="Godot.OpenXRHand.BoneUpdate"/> to apply rotation only.</para>
/// </summary>
[Obsolete("Use 'XRHandModifier3D' instead.")]
public partial class OpenXRHand : Node3D
{
    public enum Hands : long
    {
        /// <summary>
        /// <para>Tracking the player's left hand.</para>
        /// </summary>
        Left = 0,
        /// <summary>
        /// <para>Tracking the player's right hand.</para>
        /// </summary>
        Right = 1,
        /// <summary>
        /// <para>Maximum supported hands.</para>
        /// </summary>
        Max = 2
    }

    public enum MotionRangeEnum : long
    {
        /// <summary>
        /// <para>When player grips, hand skeleton will form a full fist.</para>
        /// </summary>
        Unobstructed = 0,
        /// <summary>
        /// <para>When player grips, hand skeleton conforms to the controller the player is holding.</para>
        /// </summary>
        ConformToController = 1,
        /// <summary>
        /// <para>Maximum supported motion ranges.</para>
        /// </summary>
        Max = 2
    }

    public enum SkeletonRigEnum : long
    {
        /// <summary>
        /// <para>An OpenXR compliant skeleton.</para>
        /// </summary>
        Openxr = 0,
        /// <summary>
        /// <para>A <see cref="Godot.SkeletonProfileHumanoid"/> compliant skeleton.</para>
        /// </summary>
        Humanoid = 1,
        /// <summary>
        /// <para>Maximum supported hands.</para>
        /// </summary>
        Max = 2
    }

    public enum BoneUpdateEnum : long
    {
        /// <summary>
        /// <para>The skeletons bones are fully updated (both position and rotation) to match the tracked bones.</para>
        /// </summary>
        Full = 0,
        /// <summary>
        /// <para>The skeletons bones are only rotated to align with the tracked bones, preserving bone length.</para>
        /// </summary>
        RotationOnly = 1,
        /// <summary>
        /// <para>Maximum supported bone update mode.</para>
        /// </summary>
        Max = 2
    }

    /// <summary>
    /// <para>Specifies whether this node tracks the left or right hand of the player.</para>
    /// </summary>
    public OpenXRHand.Hands Hand
    {
        get
        {
            return GetHand();
        }
        set
        {
            SetHand(value);
        }
    }

    /// <summary>
    /// <para>Set the motion range (if supported) limiting the hand motion.</para>
    /// </summary>
    public OpenXRHand.MotionRangeEnum MotionRange
    {
        get
        {
            return GetMotionRange();
        }
        set
        {
            SetMotionRange(value);
        }
    }

    /// <summary>
    /// <para>Set a <see cref="Godot.Skeleton3D"/> node for which the pose positions will be updated.</para>
    /// </summary>
    public NodePath HandSkeleton
    {
        get
        {
            return GetHandSkeleton();
        }
        set
        {
            SetHandSkeleton(value);
        }
    }

    /// <summary>
    /// <para>Set the type of skeleton rig the <see cref="Godot.OpenXRHand.HandSkeleton"/> is compliant with.</para>
    /// </summary>
    public OpenXRHand.SkeletonRigEnum SkeletonRig
    {
        get
        {
            return GetSkeletonRig();
        }
        set
        {
            SetSkeletonRig(value);
        }
    }

    /// <summary>
    /// <para>Specify the type of updates to perform on the bone.</para>
    /// </summary>
    public OpenXRHand.BoneUpdateEnum BoneUpdate
    {
        get
        {
            return GetBoneUpdate();
        }
        set
        {
            SetBoneUpdate(value);
        }
    }

    private static readonly System.Type CachedType = typeof(OpenXRHand);

    private static readonly StringName NativeName = "OpenXRHand";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public OpenXRHand() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal OpenXRHand(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal OpenXRHand(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetHand, 1849328560ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetHand(OpenXRHand.Hands hand)
    {
        NativeCalls.godot_icall_1_38(MethodBind0, GodotObject.GetPtr(this), (int)hand);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetHand, 2850644561ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public OpenXRHand.Hands GetHand()
    {
        return (OpenXRHand.Hands)NativeCalls.godot_icall_0_39(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetHandSkeleton, 1348162250ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetHandSkeleton(NodePath handSkeleton)
    {
        NativeCalls.godot_icall_1_123(MethodBind2, GodotObject.GetPtr(this), (godot_node_path)(handSkeleton?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetHandSkeleton, 4075236667ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public NodePath GetHandSkeleton()
    {
        return NativeCalls.godot_icall_0_124(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMotionRange, 3326516003ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMotionRange(OpenXRHand.MotionRangeEnum motionRange)
    {
        NativeCalls.godot_icall_1_38(MethodBind4, GodotObject.GetPtr(this), (int)motionRange);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMotionRange, 2191822314ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public OpenXRHand.MotionRangeEnum GetMotionRange()
    {
        return (OpenXRHand.MotionRangeEnum)NativeCalls.godot_icall_0_39(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSkeletonRig, 1528072213ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSkeletonRig(OpenXRHand.SkeletonRigEnum skeletonRig)
    {
        NativeCalls.godot_icall_1_38(MethodBind6, GodotObject.GetPtr(this), (int)skeletonRig);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSkeletonRig, 968409338ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public OpenXRHand.SkeletonRigEnum GetSkeletonRig()
    {
        return (OpenXRHand.SkeletonRigEnum)NativeCalls.godot_icall_0_39(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBoneUpdate, 3144625444ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetBoneUpdate(OpenXRHand.BoneUpdateEnum boneUpdate)
    {
        NativeCalls.godot_icall_1_38(MethodBind8, GodotObject.GetPtr(this), (int)boneUpdate);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBoneUpdate, 1310695248ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public OpenXRHand.BoneUpdateEnum GetBoneUpdate()
    {
        return (OpenXRHand.BoneUpdateEnum)NativeCalls.godot_icall_0_39(MethodBind9, GodotObject.GetPtr(this));
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
    public new class PropertyName : Node3D.PropertyName
    {
        /// <summary>
        /// Cached name for the 'hand' property.
        /// </summary>
        public static readonly StringName Hand = "hand";
        /// <summary>
        /// Cached name for the 'motion_range' property.
        /// </summary>
        public static readonly StringName MotionRange = "motion_range";
        /// <summary>
        /// Cached name for the 'hand_skeleton' property.
        /// </summary>
        public static readonly StringName HandSkeleton = "hand_skeleton";
        /// <summary>
        /// Cached name for the 'skeleton_rig' property.
        /// </summary>
        public static readonly StringName SkeletonRig = "skeleton_rig";
        /// <summary>
        /// Cached name for the 'bone_update' property.
        /// </summary>
        public static readonly StringName BoneUpdate = "bone_update";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Node3D.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_hand' method.
        /// </summary>
        public static readonly StringName SetHand = "set_hand";
        /// <summary>
        /// Cached name for the 'get_hand' method.
        /// </summary>
        public static readonly StringName GetHand = "get_hand";
        /// <summary>
        /// Cached name for the 'set_hand_skeleton' method.
        /// </summary>
        public static readonly StringName SetHandSkeleton = "set_hand_skeleton";
        /// <summary>
        /// Cached name for the 'get_hand_skeleton' method.
        /// </summary>
        public static readonly StringName GetHandSkeleton = "get_hand_skeleton";
        /// <summary>
        /// Cached name for the 'set_motion_range' method.
        /// </summary>
        public static readonly StringName SetMotionRange = "set_motion_range";
        /// <summary>
        /// Cached name for the 'get_motion_range' method.
        /// </summary>
        public static readonly StringName GetMotionRange = "get_motion_range";
        /// <summary>
        /// Cached name for the 'set_skeleton_rig' method.
        /// </summary>
        public static readonly StringName SetSkeletonRig = "set_skeleton_rig";
        /// <summary>
        /// Cached name for the 'get_skeleton_rig' method.
        /// </summary>
        public static readonly StringName GetSkeletonRig = "get_skeleton_rig";
        /// <summary>
        /// Cached name for the 'set_bone_update' method.
        /// </summary>
        public static readonly StringName SetBoneUpdate = "set_bone_update";
        /// <summary>
        /// Cached name for the 'get_bone_update' method.
        /// </summary>
        public static readonly StringName GetBoneUpdate = "get_bone_update";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Node3D.SignalName
    {
    }
}
