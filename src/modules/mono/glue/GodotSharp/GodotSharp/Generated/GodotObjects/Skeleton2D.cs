namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para><see cref="Godot.Skeleton2D"/> parents a hierarchy of <see cref="Godot.Bone2D"/> nodes. It holds a reference to each <see cref="Godot.Bone2D"/>'s rest pose and acts as a single point of access to its bones.</para>
/// <para>To set up different types of inverse kinematics for the given Skeleton2D, a <see cref="Godot.SkeletonModificationStack2D"/> should be created. The inverse kinematics be applied by increasing <see cref="Godot.SkeletonModificationStack2D.ModificationCount"/> and creating the desired number of modifications.</para>
/// </summary>
public partial class Skeleton2D : Node2D
{
    private static readonly System.Type CachedType = typeof(Skeleton2D);

    private static readonly StringName NativeName = "Skeleton2D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public Skeleton2D() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal Skeleton2D(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal Skeleton2D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBoneCount, 3905245786ul);

    /// <summary>
    /// <para>Returns the number of <see cref="Godot.Bone2D"/> nodes in the node hierarchy parented by Skeleton2D.</para>
    /// </summary>
    public int GetBoneCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind0, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBone, 2556267111ul);

    /// <summary>
    /// <para>Returns a <see cref="Godot.Bone2D"/> from the node hierarchy parented by Skeleton2D. The object to return is identified by the parameter <paramref name="idx"/>. Bones are indexed by descending the node hierarchy from top to bottom, adding the children of each branch before moving to the next sibling.</para>
    /// </summary>
    public Bone2D GetBone(int idx)
    {
        return (Bone2D)NativeCalls.godot_icall_1_335(MethodBind1, GodotObject.GetPtr(this), idx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSkeleton, 2944877500ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.Rid"/> of a Skeleton2D instance.</para>
    /// </summary>
    public Rid GetSkeleton()
    {
        return NativeCalls.godot_icall_0_238(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetModificationStack, 3907307132ul);

    /// <summary>
    /// <para>Sets the <see cref="Godot.SkeletonModificationStack2D"/> attached to this skeleton.</para>
    /// </summary>
    public void SetModificationStack(SkeletonModificationStack2D modificationStack)
    {
        NativeCalls.godot_icall_1_56(MethodBind3, GodotObject.GetPtr(this), GodotObject.GetPtr(modificationStack));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetModificationStack, 2107508396ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.SkeletonModificationStack2D"/> attached to this skeleton, if one exists.</para>
    /// </summary>
    public SkeletonModificationStack2D GetModificationStack()
    {
        return (SkeletonModificationStack2D)NativeCalls.godot_icall_0_63(MethodBind4, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ExecuteModifications, 1005356550ul);

    /// <summary>
    /// <para>Executes all the modifications on the <see cref="Godot.SkeletonModificationStack2D"/>, if the Skeleton2D has one assigned.</para>
    /// </summary>
    public void ExecuteModifications(float delta, int executionMode)
    {
        NativeCalls.godot_icall_2_1268(MethodBind5, GodotObject.GetPtr(this), delta, executionMode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBoneLocalPoseOverride, 555457532ul);

    /// <summary>
    /// <para>Sets the local pose transform, <paramref name="overridePose"/>, for the bone at <paramref name="boneIdx"/>.</para>
    /// <para><paramref name="strength"/> is the interpolation strength that will be used when applying the pose, and <paramref name="persistent"/> determines if the applied pose will remain.</para>
    /// <para><b>Note:</b> The pose transform needs to be a local transform relative to the <see cref="Godot.Bone2D"/> node at <paramref name="boneIdx"/>!</para>
    /// </summary>
    public unsafe void SetBoneLocalPoseOverride(int boneIdx, Transform2D overridePose, float strength, bool persistent)
    {
        NativeCalls.godot_icall_4_1269(MethodBind6, GodotObject.GetPtr(this), boneIdx, &overridePose, strength, persistent.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBoneLocalPoseOverride, 2995540667ul);

    /// <summary>
    /// <para>Returns the local pose override transform for <paramref name="boneIdx"/>.</para>
    /// </summary>
    public Transform2D GetBoneLocalPoseOverride(int boneIdx)
    {
        return NativeCalls.godot_icall_1_608(MethodBind7, GodotObject.GetPtr(this), boneIdx);
    }

    /// <summary>
    /// <para>Emitted when the <see cref="Godot.Bone2D"/> setup attached to this skeletons changes. This is primarily used internally within the skeleton.</para>
    /// </summary>
    public event Action BoneSetupChanged
    {
        add => Connect(SignalName.BoneSetupChanged, Callable.From(value));
        remove => Disconnect(SignalName.BoneSetupChanged, Callable.From(value));
    }

    protected void EmitSignalBoneSetupChanged()
    {
        EmitSignal(SignalName.BoneSetupChanged);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_bone_setup_changed = "BoneSetupChanged";

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
        if (signal == SignalName.BoneSetupChanged)
        {
            if (HasGodotClassSignal(SignalProxyName_bone_setup_changed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        return base.HasGodotClassSignal(signal);
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : Node2D.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Node2D.MethodName
    {
        /// <summary>
        /// Cached name for the 'get_bone_count' method.
        /// </summary>
        public static readonly StringName GetBoneCount = "get_bone_count";
        /// <summary>
        /// Cached name for the 'get_bone' method.
        /// </summary>
        public static readonly StringName GetBone = "get_bone";
        /// <summary>
        /// Cached name for the 'get_skeleton' method.
        /// </summary>
        public static readonly StringName GetSkeleton = "get_skeleton";
        /// <summary>
        /// Cached name for the 'set_modification_stack' method.
        /// </summary>
        public static readonly StringName SetModificationStack = "set_modification_stack";
        /// <summary>
        /// Cached name for the 'get_modification_stack' method.
        /// </summary>
        public static readonly StringName GetModificationStack = "get_modification_stack";
        /// <summary>
        /// Cached name for the 'execute_modifications' method.
        /// </summary>
        public static readonly StringName ExecuteModifications = "execute_modifications";
        /// <summary>
        /// Cached name for the 'set_bone_local_pose_override' method.
        /// </summary>
        public static readonly StringName SetBoneLocalPoseOverride = "set_bone_local_pose_override";
        /// <summary>
        /// Cached name for the 'get_bone_local_pose_override' method.
        /// </summary>
        public static readonly StringName GetBoneLocalPoseOverride = "get_bone_local_pose_override";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Node2D.SignalName
    {
        /// <summary>
        /// Cached name for the 'bone_setup_changed' signal.
        /// </summary>
        public static readonly StringName BoneSetupChanged = "bone_setup_changed";
    }
}
