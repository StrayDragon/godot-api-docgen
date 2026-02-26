namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Base class of <see cref="Godot.SkeletonModifier3D"/> that automatically generates a joint list from the bones between the root bone and the end bone.</para>
/// </summary>
public partial class ChainIK3D : IKModifier3D
{
    private static readonly System.Type CachedType = typeof(ChainIK3D);

    private static readonly StringName NativeName = "ChainIK3D";

    internal ChainIK3D() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal ChainIK3D(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal ChainIK3D(bool memoryOwn) : base(memoryOwn) { }

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
    /// <para><b>Note:</b> The end bone must be the root bone or a child of the root bone. If they are the same, the tail must be extended by <see cref="Godot.ChainIK3D.SetExtendEndBone(int, bool)"/> to modify the bone.</para>
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
    /// <para>Sets the end bone tail direction of the bone chain when <see cref="Godot.ChainIK3D.IsEndBoneExtended(int)"/> is <see langword="true"/>.</para>
    /// </summary>
    public void SetEndBoneDirection(int index, SkeletonModifier3D.BoneDirection boneDirection)
    {
        NativeCalls.godot_icall_2_59(MethodBind10, GodotObject.GetPtr(this), index, (int)boneDirection);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEndBoneDirection, 1843036459ul);

    /// <summary>
    /// <para>Returns the tail direction of the end bone of the bone chain when <see cref="Godot.ChainIK3D.IsEndBoneExtended(int)"/> is <see langword="true"/>.</para>
    /// </summary>
    public SkeletonModifier3D.BoneDirection GetEndBoneDirection(int index)
    {
        return (SkeletonModifier3D.BoneDirection)NativeCalls.godot_icall_1_60(MethodBind11, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEndBoneLength, 1602489585ul);

    /// <summary>
    /// <para>Sets the end bone tail length of the bone chain when <see cref="Godot.ChainIK3D.IsEndBoneExtended(int)"/> is <see langword="true"/>.</para>
    /// </summary>
    public void SetEndBoneLength(int index, float length)
    {
        NativeCalls.godot_icall_2_69(MethodBind12, GodotObject.GetPtr(this), index, length);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEndBoneLength, 2339986948ul);

    /// <summary>
    /// <para>Returns the end bone tail length of the bone chain when <see cref="Godot.ChainIK3D.IsEndBoneExtended(int)"/> is <see langword="true"/>.</para>
    /// </summary>
    public float GetEndBoneLength(int index)
    {
        return NativeCalls.godot_icall_1_72(MethodBind13, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetJointBoneName, 1391810591ul);

    /// <summary>
    /// <para>Returns the bone name at <paramref name="joint"/> in the bone chain's joint list.</para>
    /// </summary>
    public string GetJointBoneName(int index, int joint)
    {
        return NativeCalls.godot_icall_2_222(MethodBind14, GodotObject.GetPtr(this), index, joint);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetJointBone, 3175239445ul);

    /// <summary>
    /// <para>Returns the bone index at <paramref name="joint"/> in the bone chain's joint list.</para>
    /// </summary>
    public int GetJointBone(int index, int joint)
    {
        return NativeCalls.godot_icall_2_73(MethodBind15, GodotObject.GetPtr(this), index, joint);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetJointCount, 923996154ul);

    /// <summary>
    /// <para>Returns the joint count of the bone chain's joint list.</para>
    /// </summary>
    public int GetJointCount(int index)
    {
        return NativeCalls.godot_icall_1_60(MethodBind16, GodotObject.GetPtr(this), index);
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
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : IKModifier3D.MethodName
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
        /// Cached name for the 'get_joint_bone_name' method.
        /// </summary>
        public static readonly StringName GetJointBoneName = "get_joint_bone_name";
        /// <summary>
        /// Cached name for the 'get_joint_bone' method.
        /// </summary>
        public static readonly StringName GetJointBone = "get_joint_bone";
        /// <summary>
        /// Cached name for the 'get_joint_count' method.
        /// </summary>
        public static readonly StringName GetJointCount = "get_joint_count";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : IKModifier3D.SignalName
    {
    }
}
