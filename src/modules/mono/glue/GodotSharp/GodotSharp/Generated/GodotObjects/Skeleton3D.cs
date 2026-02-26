namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para><see cref="Godot.Skeleton3D"/> provides an interface for managing a hierarchy of bones, including pose, rest and animation (see <see cref="Godot.Animation"/>). It can also use ragdoll physics.</para>
/// <para>The overall transform of a bone with respect to the skeleton is determined by bone pose. Bone rest defines the initial transform of the bone pose.</para>
/// <para>Note that "global pose" below refers to the overall transform of the bone with respect to skeleton, so it is not the actual global/world transform of the bone.</para>
/// </summary>
public partial class Skeleton3D : Node3D
{
    /// <summary>
    /// <para>Notification received when this skeleton's pose needs to be updated. In that case, this is called only once per frame in a deferred process.</para>
    /// </summary>
    public const long NotificationUpdateSkeleton = 50;

    public enum ModifierCallbackModeProcessEnum : long
    {
        /// <summary>
        /// <para>Set a flag to process modification during physics frames (see <see cref="Godot.Node.NotificationInternalPhysicsProcess"/>).</para>
        /// </summary>
        Physics = 0,
        /// <summary>
        /// <para>Set a flag to process modification during process frames (see <see cref="Godot.Node.NotificationInternalProcess"/>).</para>
        /// </summary>
        Idle = 1,
        /// <summary>
        /// <para>Do not process modification. Use <see cref="Godot.Skeleton3D.Advance(double)"/> to process the modification manually.</para>
        /// </summary>
        Manual = 2
    }

    /// <summary>
    /// <para>Multiplies the 3D position track animation.</para>
    /// <para><b>Note:</b> Unless this value is <c>1.0</c>, the key value in animation will not match the actual position value.</para>
    /// </summary>
    public float MotionScale
    {
        get
        {
            return GetMotionScale();
        }
        set
        {
            SetMotionScale(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, forces the bones in their default rest pose, regardless of their values. In the editor, this also prevents the bones from being edited.</para>
    /// </summary>
    public bool ShowRestOnly
    {
        get
        {
            return IsShowRestOnly();
        }
        set
        {
            SetShowRestOnly(value);
        }
    }

    /// <summary>
    /// <para>Sets the processing timing for the Modifier.</para>
    /// </summary>
    public Skeleton3D.ModifierCallbackModeProcessEnum ModifierCallbackModeProcess
    {
        get
        {
            return GetModifierCallbackModeProcess();
        }
        set
        {
            SetModifierCallbackModeProcess(value);
        }
    }

    /// <summary>
    /// <para>If you follow the recommended workflow and explicitly have <see cref="Godot.PhysicalBoneSimulator3D"/> as a child of <see cref="Godot.Skeleton3D"/>, you can control whether it is affected by raycasting without running <see cref="Godot.Skeleton3D.PhysicalBonesStartSimulation(Godot.Collections.Array{StringName})"/>, by its <see cref="Godot.SkeletonModifier3D.Active"/>.</para>
    /// <para>However, for old (deprecated) configurations, <see cref="Godot.Skeleton3D"/> has an internal virtual <see cref="Godot.PhysicalBoneSimulator3D"/> for compatibility. This property controls the internal virtual <see cref="Godot.PhysicalBoneSimulator3D"/>'s <see cref="Godot.SkeletonModifier3D.Active"/>.</para>
    /// </summary>
    [Obsolete("This property is deprecated.")]
    public bool AnimatePhysicalBones
    {
        get
        {
            return GetAnimatePhysicalBones();
        }
        set
        {
            SetAnimatePhysicalBones(value);
        }
    }

    private static readonly System.Type CachedType = typeof(Skeleton3D);

    private static readonly StringName NativeName = "Skeleton3D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public Skeleton3D() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal Skeleton3D(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal Skeleton3D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddBone, 1597066294ul);

    /// <summary>
    /// <para>Adds a new bone with the given name. Returns the new bone's index, or <c>-1</c> if this method fails.</para>
    /// <para><b>Note:</b> Bone names should be unique, non empty, and cannot include the <c>:</c> and <c>/</c> characters.</para>
    /// </summary>
    public int AddBone(string name)
    {
        return NativeCalls.godot_icall_1_134(MethodBind0, GodotObject.GetPtr(this), name);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FindBone, 1321353865ul);

    /// <summary>
    /// <para>Returns the bone index that matches <paramref name="name"/> as its name. Returns <c>-1</c> if no bone with this name exists.</para>
    /// </summary>
    public int FindBone(string name)
    {
        return NativeCalls.godot_icall_1_134(MethodBind1, GodotObject.GetPtr(this), name);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBoneName, 844755477ul);

    /// <summary>
    /// <para>Returns the name of the bone at index <paramref name="boneIdx"/>.</para>
    /// </summary>
    public string GetBoneName(int boneIdx)
    {
        return NativeCalls.godot_icall_1_133(MethodBind2, GodotObject.GetPtr(this), boneIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBoneName, 501894301ul);

    /// <summary>
    /// <para>Sets the bone name, <paramref name="name"/>, for the bone at <paramref name="boneIdx"/>.</para>
    /// </summary>
    public void SetBoneName(int boneIdx, string name)
    {
        NativeCalls.godot_icall_2_181(MethodBind3, GodotObject.GetPtr(this), boneIdx, name);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBoneMeta, 203112058ul);

    /// <summary>
    /// <para>Returns the metadata with the given <paramref name="key"/> for the bone at index <paramref name="boneIdx"/>.</para>
    /// </summary>
    public Variant GetBoneMeta(int boneIdx, StringName key)
    {
        return NativeCalls.godot_icall_2_1270(MethodBind4, GodotObject.GetPtr(this), boneIdx, (godot_string_name)(key?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBoneMetaList, 663333327ul);

    /// <summary>
    /// <para>Returns the list of all metadata keys for the bone at index <paramref name="boneIdx"/>.</para>
    /// </summary>
    public Godot.Collections.Array<StringName> GetBoneMetaList(int boneIdx)
    {
        return new Godot.Collections.Array<StringName>(NativeCalls.godot_icall_1_457(MethodBind5, GodotObject.GetPtr(this), boneIdx));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasBoneMeta, 921227809ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the bone at index <paramref name="boneIdx"/> has metadata with the given <paramref name="key"/>.</para>
    /// </summary>
    public bool HasBoneMeta(int boneIdx, StringName key)
    {
        return NativeCalls.godot_icall_2_552(MethodBind6, GodotObject.GetPtr(this), boneIdx, (godot_string_name)(key?.NativeValue ?? default)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBoneMeta, 702482756ul);

    /// <summary>
    /// <para>Sets the metadata with the given <paramref name="key"/> to <paramref name="value"/> for the bone at index <paramref name="boneIdx"/>.</para>
    /// </summary>
    public void SetBoneMeta(int boneIdx, StringName key, Variant value)
    {
        NativeCalls.godot_icall_3_1271(MethodBind7, GodotObject.GetPtr(this), boneIdx, (godot_string_name)(key?.NativeValue ?? default), value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetConcatenatedBoneNames, 2002593661ul);

    /// <summary>
    /// <para>Returns all bone names concatenated with commas (<c>,</c>) as a single <see cref="Godot.StringName"/>.</para>
    /// <para>It is useful to set it as a hint for the enum property.</para>
    /// </summary>
    public StringName GetConcatenatedBoneNames()
    {
        return NativeCalls.godot_icall_0_65(MethodBind8, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBoneParent, 923996154ul);

    /// <summary>
    /// <para>Returns the bone index which is the parent of the bone at <paramref name="boneIdx"/>. If -1, then bone has no parent.</para>
    /// <para><b>Note:</b> The parent bone returned will always be less than <paramref name="boneIdx"/>.</para>
    /// </summary>
    public int GetBoneParent(int boneIdx)
    {
        return NativeCalls.godot_icall_1_60(MethodBind9, GodotObject.GetPtr(this), boneIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBoneParent, 3937882851ul);

    /// <summary>
    /// <para>Sets the bone index <paramref name="parentIdx"/> as the parent of the bone at <paramref name="boneIdx"/>. If -1, then bone has no parent.</para>
    /// <para><b>Note:</b> <paramref name="parentIdx"/> must be less than <paramref name="boneIdx"/>.</para>
    /// </summary>
    public void SetBoneParent(int boneIdx, int parentIdx)
    {
        NativeCalls.godot_icall_2_59(MethodBind10, GodotObject.GetPtr(this), boneIdx, parentIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBoneCount, 3905245786ul);

    /// <summary>
    /// <para>Returns the number of bones in the skeleton.</para>
    /// </summary>
    public int GetBoneCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind11, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVersion, 3905245786ul);

    /// <summary>
    /// <para>Returns the number of times the bone hierarchy has changed within this skeleton, including renames.</para>
    /// <para>The Skeleton version is not serialized: only use within a single instance of Skeleton3D.</para>
    /// <para>Use for invalidating caches in IK solvers and other nodes which process bones.</para>
    /// </summary>
    public ulong GetVersion()
    {
        return NativeCalls.godot_icall_0_137(MethodBind12, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.UnparentBoneAndRest, 1286410249ul);

    /// <summary>
    /// <para>Unparents the bone at <paramref name="boneIdx"/> and sets its rest position to that of its parent prior to being reset.</para>
    /// </summary>
    public void UnparentBoneAndRest(int boneIdx)
    {
        NativeCalls.godot_icall_1_38(MethodBind13, GodotObject.GetPtr(this), boneIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBoneChildren, 1706082319ul);

    /// <summary>
    /// <para>Returns an array containing the bone indexes of all the child node of the passed in bone, <paramref name="boneIdx"/>.</para>
    /// </summary>
    public int[] GetBoneChildren(int boneIdx)
    {
        return NativeCalls.godot_icall_1_797(MethodBind14, GodotObject.GetPtr(this), boneIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetParentlessBones, 1930428628ul);

    /// <summary>
    /// <para>Returns an array with all of the bones that are parentless. Another way to look at this is that it returns the indexes of all the bones that are not dependent or modified by other bones in the Skeleton.</para>
    /// </summary>
    public int[] GetParentlessBones()
    {
        return NativeCalls.godot_icall_0_151(MethodBind15, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBoneRest, 1965739696ul);

    /// <summary>
    /// <para>Returns the rest transform for a bone <paramref name="boneIdx"/>.</para>
    /// </summary>
    public Transform3D GetBoneRest(int boneIdx)
    {
        return NativeCalls.godot_icall_1_803(MethodBind16, GodotObject.GetPtr(this), boneIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBoneRest, 3616898986ul);

    /// <summary>
    /// <para>Sets the rest transform for bone <paramref name="boneIdx"/>.</para>
    /// </summary>
    public unsafe void SetBoneRest(int boneIdx, Transform3D rest)
    {
        NativeCalls.godot_icall_2_800(MethodBind17, GodotObject.GetPtr(this), boneIdx, &rest);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBoneGlobalRest, 1965739696ul);

    /// <summary>
    /// <para>Returns the global rest transform for <paramref name="boneIdx"/>.</para>
    /// </summary>
    public Transform3D GetBoneGlobalRest(int boneIdx)
    {
        return NativeCalls.godot_icall_1_803(MethodBind18, GodotObject.GetPtr(this), boneIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CreateSkinFromRestTransforms, 1032037385ul);

    public Skin CreateSkinFromRestTransforms()
    {
        return (Skin)NativeCalls.godot_icall_0_63(MethodBind19, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RegisterSkin, 3405789568ul);

    /// <summary>
    /// <para>Binds the given Skin to the Skeleton.</para>
    /// </summary>
    public SkinReference RegisterSkin(Skin skin)
    {
        return (SkinReference)NativeCalls.godot_icall_1_268(MethodBind20, GodotObject.GetPtr(this), GodotObject.GetPtr(skin));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.LocalizeRests, 3218959716ul);

    /// <summary>
    /// <para>Returns all bones in the skeleton to their rest poses.</para>
    /// </summary>
    public void LocalizeRests()
    {
        NativeCalls.godot_icall_0_3(MethodBind21, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ClearBones, 3218959716ul);

    /// <summary>
    /// <para>Clear all the bones in this skeleton.</para>
    /// </summary>
    public void ClearBones()
    {
        NativeCalls.godot_icall_0_3(MethodBind22, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBonePose, 1965739696ul);

    /// <summary>
    /// <para>Returns the pose transform of the specified bone.</para>
    /// <para><b>Note:</b> This is the pose you set to the skeleton in the process, the final pose can get overridden by modifiers in the deferred process, if you want to access the final pose, use <see cref="Godot.SkeletonModifier3D.ModificationProcessed"/>.</para>
    /// </summary>
    public Transform3D GetBonePose(int boneIdx)
    {
        return NativeCalls.godot_icall_1_803(MethodBind23, GodotObject.GetPtr(this), boneIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBonePose, 3616898986ul);

    /// <summary>
    /// <para>Sets the pose transform, <paramref name="pose"/>, for the bone at <paramref name="boneIdx"/>.</para>
    /// </summary>
    public unsafe void SetBonePose(int boneIdx, Transform3D pose)
    {
        NativeCalls.godot_icall_2_800(MethodBind24, GodotObject.GetPtr(this), boneIdx, &pose);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBonePosePosition, 1530502735ul);

    /// <summary>
    /// <para>Sets the pose position of the bone at <paramref name="boneIdx"/> to <paramref name="position"/>. <paramref name="position"/> is a <see cref="Godot.Vector3"/> describing a position local to the <see cref="Godot.Skeleton3D"/> node.</para>
    /// </summary>
    public unsafe void SetBonePosePosition(int boneIdx, Vector3 position)
    {
        NativeCalls.godot_icall_2_362(MethodBind25, GodotObject.GetPtr(this), boneIdx, &position);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBonePoseRotation, 2823819782ul);

    /// <summary>
    /// <para>Sets the pose rotation of the bone at <paramref name="boneIdx"/> to <paramref name="rotation"/>. <paramref name="rotation"/> is a <see cref="Godot.Quaternion"/> describing a rotation in the bone's local coordinate space with respect to the rotation of any parent bones.</para>
    /// </summary>
    public unsafe void SetBonePoseRotation(int boneIdx, Quaternion rotation)
    {
        NativeCalls.godot_icall_2_220(MethodBind26, GodotObject.GetPtr(this), boneIdx, &rotation);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBonePoseScale, 1530502735ul);

    /// <summary>
    /// <para>Sets the pose scale of the bone at <paramref name="boneIdx"/> to <paramref name="scale"/>.</para>
    /// </summary>
    public unsafe void SetBonePoseScale(int boneIdx, Vector3 scale)
    {
        NativeCalls.godot_icall_2_362(MethodBind27, GodotObject.GetPtr(this), boneIdx, &scale);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBonePosePosition, 711720468ul);

    /// <summary>
    /// <para>Returns the pose position of the bone at <paramref name="boneIdx"/>. The returned <see cref="Godot.Vector3"/> is in the local coordinate space of the <see cref="Godot.Skeleton3D"/> node.</para>
    /// </summary>
    public Vector3 GetBonePosePosition(int boneIdx)
    {
        return NativeCalls.godot_icall_1_363(MethodBind28, GodotObject.GetPtr(this), boneIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBonePoseRotation, 476865136ul);

    /// <summary>
    /// <para>Returns the pose rotation of the bone at <paramref name="boneIdx"/>. The returned <see cref="Godot.Quaternion"/> is local to the bone with respect to the rotation of any parent bones.</para>
    /// </summary>
    public Quaternion GetBonePoseRotation(int boneIdx)
    {
        return NativeCalls.godot_icall_1_221(MethodBind29, GodotObject.GetPtr(this), boneIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBonePoseScale, 711720468ul);

    /// <summary>
    /// <para>Returns the pose scale of the bone at <paramref name="boneIdx"/>.</para>
    /// </summary>
    public Vector3 GetBonePoseScale(int boneIdx)
    {
        return NativeCalls.godot_icall_1_363(MethodBind30, GodotObject.GetPtr(this), boneIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ResetBonePose, 1286410249ul);

    /// <summary>
    /// <para>Sets the bone pose to rest for <paramref name="boneIdx"/>.</para>
    /// </summary>
    public void ResetBonePose(int boneIdx)
    {
        NativeCalls.godot_icall_1_38(MethodBind31, GodotObject.GetPtr(this), boneIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind32 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ResetBonePoses, 3218959716ul);

    /// <summary>
    /// <para>Sets all bone poses to rests.</para>
    /// </summary>
    public void ResetBonePoses()
    {
        NativeCalls.godot_icall_0_3(MethodBind32, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind33 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsBoneEnabled, 1116898809ul);

    /// <summary>
    /// <para>Returns whether the bone pose for the bone at <paramref name="boneIdx"/> is enabled.</para>
    /// </summary>
    public bool IsBoneEnabled(int boneIdx)
    {
        return NativeCalls.godot_icall_1_62(MethodBind33, GodotObject.GetPtr(this), boneIdx).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind34 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBoneEnabled, 972357352ul);

    /// <summary>
    /// <para>Disables the pose for the bone at <paramref name="boneIdx"/> if <see langword="false"/>, enables the bone pose if <see langword="true"/>.</para>
    /// </summary>
    public void SetBoneEnabled(int boneIdx, bool enabled = true)
    {
        NativeCalls.godot_icall_2_61(MethodBind34, GodotObject.GetPtr(this), boneIdx, enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind35 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBoneGlobalPose, 1965739696ul);

    /// <summary>
    /// <para>Returns the overall transform of the specified bone, with respect to the skeleton. Being relative to the skeleton frame, this is not the actual "global" transform of the bone.</para>
    /// <para><b>Note:</b> This is the global pose you set to the skeleton in the process, the final global pose can get overridden by modifiers in the deferred process, if you want to access the final global pose, use <see cref="Godot.SkeletonModifier3D.ModificationProcessed"/>.</para>
    /// </summary>
    public Transform3D GetBoneGlobalPose(int boneIdx)
    {
        return NativeCalls.godot_icall_1_803(MethodBind35, GodotObject.GetPtr(this), boneIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind36 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBoneGlobalPose, 3616898986ul);

    /// <summary>
    /// <para>Sets the global pose transform, <paramref name="pose"/>, for the bone at <paramref name="boneIdx"/>.</para>
    /// <para><b>Note:</b> If other bone poses have been changed, this method executes a dirty poses recalculation and will cause performance to deteriorate. If you know that multiple global poses will be applied, consider using <see cref="Godot.Skeleton3D.SetBonePose(int, Transform3D)"/> with precalculation.</para>
    /// </summary>
    public unsafe void SetBoneGlobalPose(int boneIdx, Transform3D pose)
    {
        NativeCalls.godot_icall_2_800(MethodBind36, GodotObject.GetPtr(this), boneIdx, &pose);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind37 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ForceUpdateAllBoneTransforms, 3218959716ul);

    /// <summary>
    /// <para>Force updates the bone transforms/poses for all bones in the skeleton.</para>
    /// </summary>
    [Obsolete("This method should only be called internally.")]
    public void ForceUpdateAllBoneTransforms()
    {
        NativeCalls.godot_icall_0_3(MethodBind37, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind38 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ForceUpdateBoneChildTransform, 1286410249ul);

    /// <summary>
    /// <para>Force updates the bone transform for the bone at <paramref name="boneIdx"/> and all of its children.</para>
    /// </summary>
    public void ForceUpdateBoneChildTransform(int boneIdx)
    {
        NativeCalls.godot_icall_1_38(MethodBind38, GodotObject.GetPtr(this), boneIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind39 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMotionScale, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMotionScale(float motionScale)
    {
        NativeCalls.godot_icall_1_67(MethodBind39, GodotObject.GetPtr(this), motionScale);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind40 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMotionScale, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetMotionScale()
    {
        return NativeCalls.godot_icall_0_68(MethodBind40, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind41 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetShowRestOnly, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetShowRestOnly(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind41, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind42 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsShowRestOnly, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsShowRestOnly()
    {
        return NativeCalls.godot_icall_0_15(MethodBind42, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind43 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetModifierCallbackModeProcess, 3916362634ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetModifierCallbackModeProcess(Skeleton3D.ModifierCallbackModeProcessEnum mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind43, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind44 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetModifierCallbackModeProcess, 997182536ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Skeleton3D.ModifierCallbackModeProcessEnum GetModifierCallbackModeProcess()
    {
        return (Skeleton3D.ModifierCallbackModeProcessEnum)NativeCalls.godot_icall_0_39(MethodBind44, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind45 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Advance, 373806689ul);

    /// <summary>
    /// <para>Manually advance the child <see cref="Godot.SkeletonModifier3D"/>s by the specified time (in seconds).</para>
    /// <para><b>Note:</b> The <paramref name="delta"/> is temporarily accumulated in the <see cref="Godot.Skeleton3D"/>, and the deferred process uses the accumulated value to process the modification.</para>
    /// </summary>
    public void Advance(double delta)
    {
        NativeCalls.godot_icall_1_127(MethodBind45, GodotObject.GetPtr(this), delta);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind46 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ClearBonesGlobalPoseOverride, 3218959716ul);

    /// <summary>
    /// <para>Removes the global pose override on all bones in the skeleton.</para>
    /// </summary>
    [Obsolete("This method is deprecated.")]
    public void ClearBonesGlobalPoseOverride()
    {
        NativeCalls.godot_icall_0_3(MethodBind46, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind47 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBoneGlobalPoseOverride, 3483398371ul);

    /// <summary>
    /// <para>Sets the global pose transform, <paramref name="pose"/>, for the bone at <paramref name="boneIdx"/>.</para>
    /// <para><paramref name="amount"/> is the interpolation strength that will be used when applying the pose, and <paramref name="persistent"/> determines if the applied pose will remain.</para>
    /// <para><b>Note:</b> The pose transform needs to be a global pose! To convert a world transform from a <see cref="Godot.Node3D"/> to a global bone pose, multiply the <c>Transform3D.affine_inverse</c> of the node's <see cref="Godot.Node3D.GlobalTransform"/> by the desired world transform.</para>
    /// </summary>
    [Obsolete("This method is deprecated.")]
    public unsafe void SetBoneGlobalPoseOverride(int boneIdx, Transform3D pose, float amount, bool persistent = false)
    {
        NativeCalls.godot_icall_4_1272(MethodBind47, GodotObject.GetPtr(this), boneIdx, &pose, amount, persistent.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind48 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBoneGlobalPoseOverride, 1965739696ul);

    /// <summary>
    /// <para>Returns the global pose override transform for <paramref name="boneIdx"/>.</para>
    /// </summary>
    [Obsolete("This method is deprecated.")]
    public Transform3D GetBoneGlobalPoseOverride(int boneIdx)
    {
        return NativeCalls.godot_icall_1_803(MethodBind48, GodotObject.GetPtr(this), boneIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind49 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBoneGlobalPoseNoOverride, 1965739696ul);

    /// <summary>
    /// <para>Returns the overall transform of the specified bone, with respect to the skeleton, but without any global pose overrides. Being relative to the skeleton frame, this is not the actual "global" transform of the bone.</para>
    /// </summary>
    [Obsolete("This method is deprecated.")]
    public Transform3D GetBoneGlobalPoseNoOverride(int boneIdx)
    {
        return NativeCalls.godot_icall_1_803(MethodBind49, GodotObject.GetPtr(this), boneIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind50 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAnimatePhysicalBones, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAnimatePhysicalBones(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind50, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind51 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAnimatePhysicalBones, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetAnimatePhysicalBones()
    {
        return NativeCalls.godot_icall_0_15(MethodBind51, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind52 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PhysicalBonesStopSimulation, 3218959716ul);

    /// <summary>
    /// <para>Tells the <see cref="Godot.PhysicalBone3D"/> nodes in the Skeleton to stop simulating.</para>
    /// </summary>
    [Obsolete("This method is deprecated.")]
    public void PhysicalBonesStopSimulation()
    {
        NativeCalls.godot_icall_0_3(MethodBind52, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind53 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PhysicalBonesStartSimulation, 2787316981ul);

    /// <summary>
    /// <para>Tells the <see cref="Godot.PhysicalBone3D"/> nodes in the Skeleton to start simulating and reacting to the physics world.</para>
    /// <para>Optionally, a list of bone names can be passed-in, allowing only the passed-in bones to be simulated.</para>
    /// </summary>
    [Obsolete("This method is deprecated.")]
    public void PhysicalBonesStartSimulation(Godot.Collections.Array<StringName> bones = null)
    {
        NativeCalls.godot_icall_1_138(MethodBind53, GodotObject.GetPtr(this), (godot_array)(bones ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind54 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PhysicalBonesAddCollisionException, 2722037293ul);

    /// <summary>
    /// <para>Adds a collision exception to the physical bone.</para>
    /// <para>Works just like the <see cref="Godot.RigidBody3D"/> node.</para>
    /// </summary>
    [Obsolete("This method is deprecated.")]
    public void PhysicalBonesAddCollisionException(Rid exception)
    {
        NativeCalls.godot_icall_1_286(MethodBind54, GodotObject.GetPtr(this), exception);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind55 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PhysicalBonesRemoveCollisionException, 2722037293ul);

    /// <summary>
    /// <para>Removes a collision exception to the physical bone.</para>
    /// <para>Works just like the <see cref="Godot.RigidBody3D"/> node.</para>
    /// </summary>
    [Obsolete("This method is deprecated.")]
    public void PhysicalBonesRemoveCollisionException(Rid exception)
    {
        NativeCalls.godot_icall_1_286(MethodBind55, GodotObject.GetPtr(this), exception);
    }

    /// <summary>
    /// <para>Emitted when the rest is updated.</para>
    /// </summary>
    public event Action RestUpdated
    {
        add => Connect(SignalName.RestUpdated, Callable.From(value));
        remove => Disconnect(SignalName.RestUpdated, Callable.From(value));
    }

    protected void EmitSignalRestUpdated()
    {
        EmitSignal(SignalName.RestUpdated);
    }

    /// <summary>
    /// <para>Emitted when the pose is updated.</para>
    /// <para><b>Note:</b> During the update process, this signal is not fired, so modification by <see cref="Godot.SkeletonModifier3D"/> is not detected.</para>
    /// </summary>
    public event Action PoseUpdated
    {
        add => Connect(SignalName.PoseUpdated, Callable.From(value));
        remove => Disconnect(SignalName.PoseUpdated, Callable.From(value));
    }

    protected void EmitSignalPoseUpdated()
    {
        EmitSignal(SignalName.PoseUpdated);
    }

    /// <summary>
    /// <para>Emitted when the final pose has been calculated will be applied to the skin in the update process.</para>
    /// <para>This means that all <see cref="Godot.SkeletonModifier3D"/> processing is complete. In order to detect the completion of the processing of each <see cref="Godot.SkeletonModifier3D"/>, use <see cref="Godot.SkeletonModifier3D.ModificationProcessed"/>.</para>
    /// </summary>
    public event Action SkeletonUpdated
    {
        add => Connect(SignalName.SkeletonUpdated, Callable.From(value));
        remove => Disconnect(SignalName.SkeletonUpdated, Callable.From(value));
    }

    protected void EmitSignalSkeletonUpdated()
    {
        EmitSignal(SignalName.SkeletonUpdated);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.Skeleton3D.BoneEnabledChanged"/> event of a <see cref="Godot.Skeleton3D"/> class.
    /// </summary>
    public delegate void BoneEnabledChangedEventHandler(long boneIdx);

    private static void BoneEnabledChangedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((BoneEnabledChangedEventHandler)delegateObj)(VariantUtils.ConvertTo<long>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when the bone at <c>boneIdx</c> is toggled with <see cref="Godot.Skeleton3D.SetBoneEnabled(int, bool)"/>. Use <see cref="Godot.Skeleton3D.IsBoneEnabled(int)"/> to check the new value.</para>
    /// </summary>
    public unsafe event BoneEnabledChangedEventHandler BoneEnabledChanged
    {
        add => Connect(SignalName.BoneEnabledChanged, Callable.CreateWithUnsafeTrampoline(value, &BoneEnabledChangedTrampoline));
        remove => Disconnect(SignalName.BoneEnabledChanged, Callable.CreateWithUnsafeTrampoline(value, &BoneEnabledChangedTrampoline));
    }

    protected void EmitSignalBoneEnabledChanged(long boneIdx)
    {
        EmitSignal(SignalName.BoneEnabledChanged, boneIdx);
    }

    /// <summary>
    /// <para>Emitted when the list of bones changes, such as when calling <see cref="Godot.Skeleton3D.AddBone(string)"/>, <see cref="Godot.Skeleton3D.SetBoneParent(int, int)"/>, <see cref="Godot.Skeleton3D.UnparentBoneAndRest(int)"/>, or <see cref="Godot.Skeleton3D.ClearBones()"/>.</para>
    /// </summary>
    public event Action BoneListChanged
    {
        add => Connect(SignalName.BoneListChanged, Callable.From(value));
        remove => Disconnect(SignalName.BoneListChanged, Callable.From(value));
    }

    protected void EmitSignalBoneListChanged()
    {
        EmitSignal(SignalName.BoneListChanged);
    }

    /// <summary>
    /// <para>Emitted when the value of <see cref="Godot.Skeleton3D.ShowRestOnly"/> changes.</para>
    /// </summary>
    public event Action ShowRestOnlyChanged
    {
        add => Connect(SignalName.ShowRestOnlyChanged, Callable.From(value));
        remove => Disconnect(SignalName.ShowRestOnlyChanged, Callable.From(value));
    }

    protected void EmitSignalShowRestOnlyChanged()
    {
        EmitSignal(SignalName.ShowRestOnlyChanged);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_rest_updated = "RestUpdated";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_pose_updated = "PoseUpdated";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_skeleton_updated = "SkeletonUpdated";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_bone_enabled_changed = "BoneEnabledChanged";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_bone_list_changed = "BoneListChanged";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_show_rest_only_changed = "ShowRestOnlyChanged";

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
        if (signal == SignalName.RestUpdated)
        {
            if (HasGodotClassSignal(SignalProxyName_rest_updated.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.PoseUpdated)
        {
            if (HasGodotClassSignal(SignalProxyName_pose_updated.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.SkeletonUpdated)
        {
            if (HasGodotClassSignal(SignalProxyName_skeleton_updated.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.BoneEnabledChanged)
        {
            if (HasGodotClassSignal(SignalProxyName_bone_enabled_changed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.BoneListChanged)
        {
            if (HasGodotClassSignal(SignalProxyName_bone_list_changed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.ShowRestOnlyChanged)
        {
            if (HasGodotClassSignal(SignalProxyName_show_rest_only_changed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        return base.HasGodotClassSignal(signal);
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : Node3D.PropertyName
    {
        /// <summary>
        /// Cached name for the 'motion_scale' property.
        /// </summary>
        public static readonly StringName MotionScale = "motion_scale";
        /// <summary>
        /// Cached name for the 'show_rest_only' property.
        /// </summary>
        public static readonly StringName ShowRestOnly = "show_rest_only";
        /// <summary>
        /// Cached name for the 'modifier_callback_mode_process' property.
        /// </summary>
        public static readonly StringName ModifierCallbackModeProcess = "modifier_callback_mode_process";
        /// <summary>
        /// Cached name for the 'animate_physical_bones' property.
        /// </summary>
        public static readonly StringName AnimatePhysicalBones = "animate_physical_bones";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Node3D.MethodName
    {
        /// <summary>
        /// Cached name for the 'add_bone' method.
        /// </summary>
        public static readonly StringName AddBone = "add_bone";
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
        /// Cached name for the 'get_bone_meta' method.
        /// </summary>
        public static readonly StringName GetBoneMeta = "get_bone_meta";
        /// <summary>
        /// Cached name for the 'get_bone_meta_list' method.
        /// </summary>
        public static readonly StringName GetBoneMetaList = "get_bone_meta_list";
        /// <summary>
        /// Cached name for the 'has_bone_meta' method.
        /// </summary>
        public static readonly StringName HasBoneMeta = "has_bone_meta";
        /// <summary>
        /// Cached name for the 'set_bone_meta' method.
        /// </summary>
        public static readonly StringName SetBoneMeta = "set_bone_meta";
        /// <summary>
        /// Cached name for the 'get_concatenated_bone_names' method.
        /// </summary>
        public static readonly StringName GetConcatenatedBoneNames = "get_concatenated_bone_names";
        /// <summary>
        /// Cached name for the 'get_bone_parent' method.
        /// </summary>
        public static readonly StringName GetBoneParent = "get_bone_parent";
        /// <summary>
        /// Cached name for the 'set_bone_parent' method.
        /// </summary>
        public static readonly StringName SetBoneParent = "set_bone_parent";
        /// <summary>
        /// Cached name for the 'get_bone_count' method.
        /// </summary>
        public static readonly StringName GetBoneCount = "get_bone_count";
        /// <summary>
        /// Cached name for the 'get_version' method.
        /// </summary>
        public static readonly StringName GetVersion = "get_version";
        /// <summary>
        /// Cached name for the 'unparent_bone_and_rest' method.
        /// </summary>
        public static readonly StringName UnparentBoneAndRest = "unparent_bone_and_rest";
        /// <summary>
        /// Cached name for the 'get_bone_children' method.
        /// </summary>
        public static readonly StringName GetBoneChildren = "get_bone_children";
        /// <summary>
        /// Cached name for the 'get_parentless_bones' method.
        /// </summary>
        public static readonly StringName GetParentlessBones = "get_parentless_bones";
        /// <summary>
        /// Cached name for the 'get_bone_rest' method.
        /// </summary>
        public static readonly StringName GetBoneRest = "get_bone_rest";
        /// <summary>
        /// Cached name for the 'set_bone_rest' method.
        /// </summary>
        public static readonly StringName SetBoneRest = "set_bone_rest";
        /// <summary>
        /// Cached name for the 'get_bone_global_rest' method.
        /// </summary>
        public static readonly StringName GetBoneGlobalRest = "get_bone_global_rest";
        /// <summary>
        /// Cached name for the 'create_skin_from_rest_transforms' method.
        /// </summary>
        public static readonly StringName CreateSkinFromRestTransforms = "create_skin_from_rest_transforms";
        /// <summary>
        /// Cached name for the 'register_skin' method.
        /// </summary>
        public static readonly StringName RegisterSkin = "register_skin";
        /// <summary>
        /// Cached name for the 'localize_rests' method.
        /// </summary>
        public static readonly StringName LocalizeRests = "localize_rests";
        /// <summary>
        /// Cached name for the 'clear_bones' method.
        /// </summary>
        public static readonly StringName ClearBones = "clear_bones";
        /// <summary>
        /// Cached name for the 'get_bone_pose' method.
        /// </summary>
        public static readonly StringName GetBonePose = "get_bone_pose";
        /// <summary>
        /// Cached name for the 'set_bone_pose' method.
        /// </summary>
        public static readonly StringName SetBonePose = "set_bone_pose";
        /// <summary>
        /// Cached name for the 'set_bone_pose_position' method.
        /// </summary>
        public static readonly StringName SetBonePosePosition = "set_bone_pose_position";
        /// <summary>
        /// Cached name for the 'set_bone_pose_rotation' method.
        /// </summary>
        public static readonly StringName SetBonePoseRotation = "set_bone_pose_rotation";
        /// <summary>
        /// Cached name for the 'set_bone_pose_scale' method.
        /// </summary>
        public static readonly StringName SetBonePoseScale = "set_bone_pose_scale";
        /// <summary>
        /// Cached name for the 'get_bone_pose_position' method.
        /// </summary>
        public static readonly StringName GetBonePosePosition = "get_bone_pose_position";
        /// <summary>
        /// Cached name for the 'get_bone_pose_rotation' method.
        /// </summary>
        public static readonly StringName GetBonePoseRotation = "get_bone_pose_rotation";
        /// <summary>
        /// Cached name for the 'get_bone_pose_scale' method.
        /// </summary>
        public static readonly StringName GetBonePoseScale = "get_bone_pose_scale";
        /// <summary>
        /// Cached name for the 'reset_bone_pose' method.
        /// </summary>
        public static readonly StringName ResetBonePose = "reset_bone_pose";
        /// <summary>
        /// Cached name for the 'reset_bone_poses' method.
        /// </summary>
        public static readonly StringName ResetBonePoses = "reset_bone_poses";
        /// <summary>
        /// Cached name for the 'is_bone_enabled' method.
        /// </summary>
        public static readonly StringName IsBoneEnabled = "is_bone_enabled";
        /// <summary>
        /// Cached name for the 'set_bone_enabled' method.
        /// </summary>
        public static readonly StringName SetBoneEnabled = "set_bone_enabled";
        /// <summary>
        /// Cached name for the 'get_bone_global_pose' method.
        /// </summary>
        public static readonly StringName GetBoneGlobalPose = "get_bone_global_pose";
        /// <summary>
        /// Cached name for the 'set_bone_global_pose' method.
        /// </summary>
        public static readonly StringName SetBoneGlobalPose = "set_bone_global_pose";
        /// <summary>
        /// Cached name for the 'force_update_all_bone_transforms' method.
        /// </summary>
        public static readonly StringName ForceUpdateAllBoneTransforms = "force_update_all_bone_transforms";
        /// <summary>
        /// Cached name for the 'force_update_bone_child_transform' method.
        /// </summary>
        public static readonly StringName ForceUpdateBoneChildTransform = "force_update_bone_child_transform";
        /// <summary>
        /// Cached name for the 'set_motion_scale' method.
        /// </summary>
        public static readonly StringName SetMotionScale = "set_motion_scale";
        /// <summary>
        /// Cached name for the 'get_motion_scale' method.
        /// </summary>
        public static readonly StringName GetMotionScale = "get_motion_scale";
        /// <summary>
        /// Cached name for the 'set_show_rest_only' method.
        /// </summary>
        public static readonly StringName SetShowRestOnly = "set_show_rest_only";
        /// <summary>
        /// Cached name for the 'is_show_rest_only' method.
        /// </summary>
        public static readonly StringName IsShowRestOnly = "is_show_rest_only";
        /// <summary>
        /// Cached name for the 'set_modifier_callback_mode_process' method.
        /// </summary>
        public static readonly StringName SetModifierCallbackModeProcess = "set_modifier_callback_mode_process";
        /// <summary>
        /// Cached name for the 'get_modifier_callback_mode_process' method.
        /// </summary>
        public static readonly StringName GetModifierCallbackModeProcess = "get_modifier_callback_mode_process";
        /// <summary>
        /// Cached name for the 'advance' method.
        /// </summary>
        public static readonly StringName Advance = "advance";
        /// <summary>
        /// Cached name for the 'clear_bones_global_pose_override' method.
        /// </summary>
        public static readonly StringName ClearBonesGlobalPoseOverride = "clear_bones_global_pose_override";
        /// <summary>
        /// Cached name for the 'set_bone_global_pose_override' method.
        /// </summary>
        public static readonly StringName SetBoneGlobalPoseOverride = "set_bone_global_pose_override";
        /// <summary>
        /// Cached name for the 'get_bone_global_pose_override' method.
        /// </summary>
        public static readonly StringName GetBoneGlobalPoseOverride = "get_bone_global_pose_override";
        /// <summary>
        /// Cached name for the 'get_bone_global_pose_no_override' method.
        /// </summary>
        public static readonly StringName GetBoneGlobalPoseNoOverride = "get_bone_global_pose_no_override";
        /// <summary>
        /// Cached name for the 'set_animate_physical_bones' method.
        /// </summary>
        public static readonly StringName SetAnimatePhysicalBones = "set_animate_physical_bones";
        /// <summary>
        /// Cached name for the 'get_animate_physical_bones' method.
        /// </summary>
        public static readonly StringName GetAnimatePhysicalBones = "get_animate_physical_bones";
        /// <summary>
        /// Cached name for the 'physical_bones_stop_simulation' method.
        /// </summary>
        public static readonly StringName PhysicalBonesStopSimulation = "physical_bones_stop_simulation";
        /// <summary>
        /// Cached name for the 'physical_bones_start_simulation' method.
        /// </summary>
        public static readonly StringName PhysicalBonesStartSimulation = "physical_bones_start_simulation";
        /// <summary>
        /// Cached name for the 'physical_bones_add_collision_exception' method.
        /// </summary>
        public static readonly StringName PhysicalBonesAddCollisionException = "physical_bones_add_collision_exception";
        /// <summary>
        /// Cached name for the 'physical_bones_remove_collision_exception' method.
        /// </summary>
        public static readonly StringName PhysicalBonesRemoveCollisionException = "physical_bones_remove_collision_exception";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Node3D.SignalName
    {
        /// <summary>
        /// Cached name for the 'rest_updated' signal.
        /// </summary>
        public static readonly StringName RestUpdated = "rest_updated";
        /// <summary>
        /// Cached name for the 'pose_updated' signal.
        /// </summary>
        public static readonly StringName PoseUpdated = "pose_updated";
        /// <summary>
        /// Cached name for the 'skeleton_updated' signal.
        /// </summary>
        public static readonly StringName SkeletonUpdated = "skeleton_updated";
        /// <summary>
        /// Cached name for the 'bone_enabled_changed' signal.
        /// </summary>
        public static readonly StringName BoneEnabledChanged = "bone_enabled_changed";
        /// <summary>
        /// Cached name for the 'bone_list_changed' signal.
        /// </summary>
        public static readonly StringName BoneListChanged = "bone_list_changed";
        /// <summary>
        /// Cached name for the 'show_rest_only_changed' signal.
        /// </summary>
        public static readonly StringName ShowRestOnlyChanged = "show_rest_only_changed";
    }
}
