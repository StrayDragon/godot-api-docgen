namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This resource is used in <c>EditorScenePostImport</c>. Some parameters are referring to bones in <see cref="Godot.Skeleton3D"/>, <see cref="Godot.Skin"/>, <see cref="Godot.Animation"/>, and some other nodes are rewritten based on the parameters of <see cref="Godot.SkeletonProfile"/>.</para>
/// <para><b>Note:</b> These parameters need to be set only when creating a custom profile. In <see cref="Godot.SkeletonProfileHumanoid"/>, they are defined internally as read-only values.</para>
/// </summary>
public partial class SkeletonProfile : Resource
{
    public enum TailDirection : long
    {
        /// <summary>
        /// <para>Direction to the average coordinates of bone children.</para>
        /// </summary>
        AverageChildren = 0,
        /// <summary>
        /// <para>Direction to the coordinates of specified bone child.</para>
        /// </summary>
        SpecificChild = 1,
        /// <summary>
        /// <para>Direction is not calculated.</para>
        /// </summary>
        End = 2
    }

    /// <summary>
    /// <para>A bone name that will be used as the root bone in <see cref="Godot.AnimationTree"/>. This should be the bone of the parent of hips that exists at the world origin.</para>
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
    /// <para>A bone name which will use model's height as the coefficient for normalization. For example, <see cref="Godot.SkeletonProfileHumanoid"/> defines it as <c>Hips</c>.</para>
    /// </summary>
    public StringName ScaleBaseBone
    {
        get
        {
            return GetScaleBaseBone();
        }
        set
        {
            SetScaleBaseBone(value);
        }
    }

    /// <summary>
    /// <para>The amount of groups of bones in retargeting section's <see cref="Godot.BoneMap"/> editor. For example, <see cref="Godot.SkeletonProfileHumanoid"/> has 4 groups.</para>
    /// <para>This property exists to separate the bone list into several sections in the editor.</para>
    /// </summary>
    public int GroupSize
    {
        get
        {
            return GetGroupSize();
        }
        set
        {
            SetGroupSize(value);
        }
    }

    /// <summary>
    /// <para>The amount of bones in retargeting section's <see cref="Godot.BoneMap"/> editor. For example, <see cref="Godot.SkeletonProfileHumanoid"/> has 56 bones.</para>
    /// <para>The size of elements in <see cref="Godot.BoneMap"/> updates when changing this property in it's assigned <see cref="Godot.SkeletonProfile"/>.</para>
    /// </summary>
    public int BoneSize
    {
        get
        {
            return GetBoneSize();
        }
        set
        {
            SetBoneSize(value);
        }
    }

    private static readonly System.Type CachedType = typeof(SkeletonProfile);

    private static readonly StringName NativeName = "SkeletonProfile";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public SkeletonProfile() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal SkeletonProfile(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal SkeletonProfile(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRootBone, 3304788590ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetRootBone(StringName boneName)
    {
        NativeCalls.godot_icall_1_64(MethodBind0, GodotObject.GetPtr(this), (godot_string_name)(boneName?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRootBone, 2737447660ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public StringName GetRootBone()
    {
        return NativeCalls.godot_icall_0_65(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetScaleBaseBone, 3304788590ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetScaleBaseBone(StringName boneName)
    {
        NativeCalls.godot_icall_1_64(MethodBind2, GodotObject.GetPtr(this), (godot_string_name)(boneName?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetScaleBaseBone, 2737447660ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public StringName GetScaleBaseBone()
    {
        return NativeCalls.godot_icall_0_65(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetGroupSize, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetGroupSize(int size)
    {
        NativeCalls.godot_icall_1_38(MethodBind4, GodotObject.GetPtr(this), size);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetGroupSize, 2455072627ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetGroupSize()
    {
        return NativeCalls.godot_icall_0_39(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetGroupName, 659327637ul);

    /// <summary>
    /// <para>Returns the name of the group at <paramref name="groupIdx"/> that will be the drawing group in the <see cref="Godot.BoneMap"/> editor.</para>
    /// </summary>
    public StringName GetGroupName(int groupIdx)
    {
        return NativeCalls.godot_icall_1_162(MethodBind6, GodotObject.GetPtr(this), groupIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetGroupName, 3780747571ul);

    /// <summary>
    /// <para>Sets the name of the group at <paramref name="groupIdx"/> that will be the drawing group in the <see cref="Godot.BoneMap"/> editor.</para>
    /// </summary>
    public void SetGroupName(int groupIdx, StringName groupName)
    {
        NativeCalls.godot_icall_2_178(MethodBind7, GodotObject.GetPtr(this), groupIdx, (godot_string_name)(groupName?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTexture, 3536238170ul);

    /// <summary>
    /// <para>Returns the texture of the group at <paramref name="groupIdx"/> that will be the drawing group background image in the <see cref="Godot.BoneMap"/> editor.</para>
    /// </summary>
    public Texture2D GetTexture(int groupIdx)
    {
        return (Texture2D)NativeCalls.godot_icall_1_71(MethodBind8, GodotObject.GetPtr(this), groupIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTexture, 666127730ul);

    /// <summary>
    /// <para>Sets the texture of the group at <paramref name="groupIdx"/> that will be the drawing group background image in the <see cref="Godot.BoneMap"/> editor.</para>
    /// </summary>
    public void SetTexture(int groupIdx, Texture2D texture)
    {
        NativeCalls.godot_icall_2_70(MethodBind9, GodotObject.GetPtr(this), groupIdx, GodotObject.GetPtr(texture));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBoneSize, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetBoneSize(int size)
    {
        NativeCalls.godot_icall_1_38(MethodBind10, GodotObject.GetPtr(this), size);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBoneSize, 2455072627ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetBoneSize()
    {
        return NativeCalls.godot_icall_0_39(MethodBind11, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FindBone, 2458036349ul);

    /// <summary>
    /// <para>Returns the bone index that matches <paramref name="boneName"/> as its name.</para>
    /// </summary>
    public int FindBone(StringName boneName)
    {
        return NativeCalls.godot_icall_1_193(MethodBind12, GodotObject.GetPtr(this), (godot_string_name)(boneName?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBoneName, 659327637ul);

    /// <summary>
    /// <para>Returns the name of the bone at <paramref name="boneIdx"/> that will be the key name in the <see cref="Godot.BoneMap"/>.</para>
    /// <para>In the retargeting process, the returned bone name is the bone name of the target skeleton.</para>
    /// </summary>
    public StringName GetBoneName(int boneIdx)
    {
        return NativeCalls.godot_icall_1_162(MethodBind13, GodotObject.GetPtr(this), boneIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBoneName, 3780747571ul);

    /// <summary>
    /// <para>Sets the name of the bone at <paramref name="boneIdx"/> that will be the key name in the <see cref="Godot.BoneMap"/>.</para>
    /// <para>In the retargeting process, the setting bone name is the bone name of the target skeleton.</para>
    /// </summary>
    public void SetBoneName(int boneIdx, StringName boneName)
    {
        NativeCalls.godot_icall_2_178(MethodBind14, GodotObject.GetPtr(this), boneIdx, (godot_string_name)(boneName?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBoneParent, 659327637ul);

    /// <summary>
    /// <para>Returns the name of the bone which is the parent to the bone at <paramref name="boneIdx"/>. The result is empty if the bone has no parent.</para>
    /// </summary>
    public StringName GetBoneParent(int boneIdx)
    {
        return NativeCalls.godot_icall_1_162(MethodBind15, GodotObject.GetPtr(this), boneIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBoneParent, 3780747571ul);

    /// <summary>
    /// <para>Sets the bone with name <paramref name="boneParent"/> as the parent of the bone at <paramref name="boneIdx"/>. If an empty string is passed, then the bone has no parent.</para>
    /// </summary>
    public void SetBoneParent(int boneIdx, StringName boneParent)
    {
        NativeCalls.godot_icall_2_178(MethodBind16, GodotObject.GetPtr(this), boneIdx, (godot_string_name)(boneParent?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTailDirection, 2675997574ul);

    /// <summary>
    /// <para>Returns the tail direction of the bone at <paramref name="boneIdx"/>.</para>
    /// </summary>
    public SkeletonProfile.TailDirection GetTailDirection(int boneIdx)
    {
        return (SkeletonProfile.TailDirection)NativeCalls.godot_icall_1_60(MethodBind17, GodotObject.GetPtr(this), boneIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTailDirection, 1231951015ul);

    /// <summary>
    /// <para>Sets the tail direction of the bone at <paramref name="boneIdx"/>.</para>
    /// <para><b>Note:</b> This only specifies the method of calculation. The actual coordinates required should be stored in an external skeleton, so the calculation itself needs to be done externally.</para>
    /// </summary>
    public void SetTailDirection(int boneIdx, SkeletonProfile.TailDirection tailDirection)
    {
        NativeCalls.godot_icall_2_59(MethodBind18, GodotObject.GetPtr(this), boneIdx, (int)tailDirection);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBoneTail, 659327637ul);

    /// <summary>
    /// <para>Returns the name of the bone which is the tail of the bone at <paramref name="boneIdx"/>.</para>
    /// </summary>
    public StringName GetBoneTail(int boneIdx)
    {
        return NativeCalls.godot_icall_1_162(MethodBind19, GodotObject.GetPtr(this), boneIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBoneTail, 3780747571ul);

    /// <summary>
    /// <para>Sets the bone with name <paramref name="boneTail"/> as the tail of the bone at <paramref name="boneIdx"/>.</para>
    /// </summary>
    public void SetBoneTail(int boneIdx, StringName boneTail)
    {
        NativeCalls.godot_icall_2_178(MethodBind20, GodotObject.GetPtr(this), boneIdx, (godot_string_name)(boneTail?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetReferencePose, 1965739696ul);

    /// <summary>
    /// <para>Returns the reference pose transform for bone <paramref name="boneIdx"/>.</para>
    /// </summary>
    public Transform3D GetReferencePose(int boneIdx)
    {
        return NativeCalls.godot_icall_1_803(MethodBind21, GodotObject.GetPtr(this), boneIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetReferencePose, 3616898986ul);

    /// <summary>
    /// <para>Sets the reference pose transform for bone <paramref name="boneIdx"/>.</para>
    /// </summary>
    public unsafe void SetReferencePose(int boneIdx, Transform3D boneName)
    {
        NativeCalls.godot_icall_2_800(MethodBind22, GodotObject.GetPtr(this), boneIdx, &boneName);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetHandleOffset, 2299179447ul);

    /// <summary>
    /// <para>Returns the offset of the bone at <paramref name="boneIdx"/> that will be the button position in the <see cref="Godot.BoneMap"/> editor.</para>
    /// <para>This is the offset with origin at the top left corner of the square.</para>
    /// </summary>
    public Vector2 GetHandleOffset(int boneIdx)
    {
        return NativeCalls.godot_icall_1_148(MethodBind23, GodotObject.GetPtr(this), boneIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetHandleOffset, 163021252ul);

    /// <summary>
    /// <para>Sets the offset of the bone at <paramref name="boneIdx"/> that will be the button position in the <see cref="Godot.BoneMap"/> editor.</para>
    /// <para>This is the offset with origin at the top left corner of the square.</para>
    /// </summary>
    public unsafe void SetHandleOffset(int boneIdx, Vector2 handleOffset)
    {
        NativeCalls.godot_icall_2_147(MethodBind24, GodotObject.GetPtr(this), boneIdx, &handleOffset);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetGroup, 659327637ul);

    /// <summary>
    /// <para>Returns the group of the bone at <paramref name="boneIdx"/>.</para>
    /// </summary>
    public StringName GetGroup(int boneIdx)
    {
        return NativeCalls.godot_icall_1_162(MethodBind25, GodotObject.GetPtr(this), boneIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetGroup, 3780747571ul);

    /// <summary>
    /// <para>Sets the group of the bone at <paramref name="boneIdx"/>.</para>
    /// </summary>
    public void SetGroup(int boneIdx, StringName group)
    {
        NativeCalls.godot_icall_2_178(MethodBind26, GodotObject.GetPtr(this), boneIdx, (godot_string_name)(group?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsRequired, 1116898809ul);

    /// <summary>
    /// <para>Returns whether the bone at <paramref name="boneIdx"/> is required for retargeting.</para>
    /// <para>This value is used by the bone map editor. If this method returns <see langword="true"/>, and no bone is assigned, the handle color will be red on the bone map editor.</para>
    /// </summary>
    public bool IsRequired(int boneIdx)
    {
        return NativeCalls.godot_icall_1_62(MethodBind27, GodotObject.GetPtr(this), boneIdx).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRequired, 300928843ul);

    /// <summary>
    /// <para>Sets the required status for bone <paramref name="boneIdx"/> to <paramref name="required"/>.</para>
    /// </summary>
    public void SetRequired(int boneIdx, bool required)
    {
        NativeCalls.godot_icall_2_61(MethodBind28, GodotObject.GetPtr(this), boneIdx, required.ToGodotBool());
    }

    /// <summary>
    /// <para>This signal is emitted when change the value in profile. This is used to update key name in the <see cref="Godot.BoneMap"/> and to redraw the <see cref="Godot.BoneMap"/> editor.</para>
    /// <para><b>Note:</b> This signal is not connected directly to editor to simplify the reference, instead it is passed on to editor through the <see cref="Godot.BoneMap"/>.</para>
    /// </summary>
    public event Action ProfileUpdated
    {
        add => Connect(SignalName.ProfileUpdated, Callable.From(value));
        remove => Disconnect(SignalName.ProfileUpdated, Callable.From(value));
    }

    protected void EmitSignalProfileUpdated()
    {
        EmitSignal(SignalName.ProfileUpdated);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_profile_updated = "ProfileUpdated";

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
        if (signal == SignalName.ProfileUpdated)
        {
            if (HasGodotClassSignal(SignalProxyName_profile_updated.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        return base.HasGodotClassSignal(signal);
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : Resource.PropertyName
    {
        /// <summary>
        /// Cached name for the 'root_bone' property.
        /// </summary>
        public static readonly StringName RootBone = "root_bone";
        /// <summary>
        /// Cached name for the 'scale_base_bone' property.
        /// </summary>
        public static readonly StringName ScaleBaseBone = "scale_base_bone";
        /// <summary>
        /// Cached name for the 'group_size' property.
        /// </summary>
        public static readonly StringName GroupSize = "group_size";
        /// <summary>
        /// Cached name for the 'bone_size' property.
        /// </summary>
        public static readonly StringName BoneSize = "bone_size";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Resource.MethodName
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
        /// Cached name for the 'set_scale_base_bone' method.
        /// </summary>
        public static readonly StringName SetScaleBaseBone = "set_scale_base_bone";
        /// <summary>
        /// Cached name for the 'get_scale_base_bone' method.
        /// </summary>
        public static readonly StringName GetScaleBaseBone = "get_scale_base_bone";
        /// <summary>
        /// Cached name for the 'set_group_size' method.
        /// </summary>
        public static readonly StringName SetGroupSize = "set_group_size";
        /// <summary>
        /// Cached name for the 'get_group_size' method.
        /// </summary>
        public static readonly StringName GetGroupSize = "get_group_size";
        /// <summary>
        /// Cached name for the 'get_group_name' method.
        /// </summary>
        public static readonly StringName GetGroupName = "get_group_name";
        /// <summary>
        /// Cached name for the 'set_group_name' method.
        /// </summary>
        public static readonly StringName SetGroupName = "set_group_name";
        /// <summary>
        /// Cached name for the 'get_texture' method.
        /// </summary>
        public static readonly StringName GetTexture = "get_texture";
        /// <summary>
        /// Cached name for the 'set_texture' method.
        /// </summary>
        public static readonly StringName SetTexture = "set_texture";
        /// <summary>
        /// Cached name for the 'set_bone_size' method.
        /// </summary>
        public static readonly StringName SetBoneSize = "set_bone_size";
        /// <summary>
        /// Cached name for the 'get_bone_size' method.
        /// </summary>
        public static readonly StringName GetBoneSize = "get_bone_size";
        /// <summary>
        /// Cached name for the 'find_bone' method.
        /// </summary>
        public static readonly StringName FindBone = "find_bone";
        /// <summary>
        /// Cached name for the 'get_bone_name' method.
        /// </summary>
        public static readonly StringName GetBoneName = "get_bone_name";
        /// <summary>
        /// Cached name for the 'set_bone_name' method.
        /// </summary>
        public static readonly StringName SetBoneName = "set_bone_name";
        /// <summary>
        /// Cached name for the 'get_bone_parent' method.
        /// </summary>
        public static readonly StringName GetBoneParent = "get_bone_parent";
        /// <summary>
        /// Cached name for the 'set_bone_parent' method.
        /// </summary>
        public static readonly StringName SetBoneParent = "set_bone_parent";
        /// <summary>
        /// Cached name for the 'get_tail_direction' method.
        /// </summary>
        public static readonly StringName GetTailDirection = "get_tail_direction";
        /// <summary>
        /// Cached name for the 'set_tail_direction' method.
        /// </summary>
        public static readonly StringName SetTailDirection = "set_tail_direction";
        /// <summary>
        /// Cached name for the 'get_bone_tail' method.
        /// </summary>
        public static readonly StringName GetBoneTail = "get_bone_tail";
        /// <summary>
        /// Cached name for the 'set_bone_tail' method.
        /// </summary>
        public static readonly StringName SetBoneTail = "set_bone_tail";
        /// <summary>
        /// Cached name for the 'get_reference_pose' method.
        /// </summary>
        public static readonly StringName GetReferencePose = "get_reference_pose";
        /// <summary>
        /// Cached name for the 'set_reference_pose' method.
        /// </summary>
        public static readonly StringName SetReferencePose = "set_reference_pose";
        /// <summary>
        /// Cached name for the 'get_handle_offset' method.
        /// </summary>
        public static readonly StringName GetHandleOffset = "get_handle_offset";
        /// <summary>
        /// Cached name for the 'set_handle_offset' method.
        /// </summary>
        public static readonly StringName SetHandleOffset = "set_handle_offset";
        /// <summary>
        /// Cached name for the 'get_group' method.
        /// </summary>
        public static readonly StringName GetGroup = "get_group";
        /// <summary>
        /// Cached name for the 'set_group' method.
        /// </summary>
        public static readonly StringName SetGroup = "set_group";
        /// <summary>
        /// Cached name for the 'is_required' method.
        /// </summary>
        public static readonly StringName IsRequired = "is_required";
        /// <summary>
        /// Cached name for the 'set_required' method.
        /// </summary>
        public static readonly StringName SetRequired = "set_required";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Resource.SignalName
    {
        /// <summary>
        /// Cached name for the 'profile_updated' signal.
        /// </summary>
        public static readonly StringName ProfileUpdated = "profile_updated";
    }
}
