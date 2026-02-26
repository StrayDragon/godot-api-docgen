namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This <see cref="Godot.BoneTwistDisperser3D"/> allows for smooth twist interpolation between multiple bones by dispersing the end bone's twist to the parents. This only changes the twist without changing the global position of each joint.</para>
/// <para>This is useful for smoothly twisting bones in combination with <see cref="Godot.CopyTransformModifier3D"/> and IK.</para>
/// <para><b>Note:</b> If an extracted twist is greater than 180 degrees, flipping occurs. This is similar to <see cref="Godot.ConvertTransformModifier3D"/>.</para>
/// </summary>
public partial class BoneTwistDisperser3D : SkeletonModifier3D
{
    public enum DisperseMode : long
    {
        /// <summary>
        /// <para>Assign amounts so that they monotonically increase from <c>0.0</c> to <c>1.0</c>, ensuring all weights are equal. For example, with five joints, the amounts would be <c>0.2</c>, <c>0.4</c>, <c>0.6</c>, <c>0.8</c>, and <c>1.0</c> starting from the root bone.</para>
        /// </summary>
        Even = 0,
        /// <summary>
        /// <para>Assign amounts so that they monotonically increase from <c>0.0</c> to <c>1.0</c>, based on the length of the bones between joint segments. See also <see cref="Godot.BoneTwistDisperser3D.SetWeightPosition(int, float)"/>.</para>
        /// </summary>
        Weighted = 1,
        /// <summary>
        /// <para>You can assign arbitrary amounts to the joint list. See also <see cref="Godot.BoneTwistDisperser3D.SetJointTwistAmount(int, int, float)"/>.</para>
        /// <para>When <see cref="Godot.BoneTwistDisperser3D.IsEndBoneExtended(int)"/> is <see langword="false"/>, a child of the reference bone exists solely to determine the twist axis, so its custom amount has absolutely no effect at all.</para>
        /// </summary>
        Custom = 2
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the solver retrieves the bone axis from the bone pose every frame.</para>
    /// <para>If <see langword="false"/>, the solver retrieves the bone axis from the bone rest and caches it.</para>
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

    private static readonly System.Type CachedType = typeof(BoneTwistDisperser3D);

    private static readonly StringName NativeName = "BoneTwistDisperser3D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public BoneTwistDisperser3D() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal BoneTwistDisperser3D(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal BoneTwistDisperser3D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSettingCount, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSettingCount(int count)
    {
        NativeCalls.godot_icall_1_38(MethodBind0, GodotObject.GetPtr(this), count);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSettingCount, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetSettingCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ClearSettings, 3218959716ul);

    /// <summary>
    /// <para>Clears all settings.</para>
    /// </summary>
    public void ClearSettings()
    {
        NativeCalls.godot_icall_0_3(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMutableBoneAxes, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMutableBoneAxes(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind3, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AreBoneAxesMutable, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool AreBoneAxesMutable()
    {
        return NativeCalls.godot_icall_0_15(MethodBind4, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRootBoneName, 501894301ul);

    /// <summary>
    /// <para>Sets the root bone name of the bone chain.</para>
    /// </summary>
    public void SetRootBoneName(int index, string boneName)
    {
        NativeCalls.godot_icall_2_181(MethodBind5, GodotObject.GetPtr(this), index, boneName);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRootBoneName, 844755477ul);

    /// <summary>
    /// <para>Returns the root bone name of the bone chain.</para>
    /// </summary>
    public string GetRootBoneName(int index)
    {
        return NativeCalls.godot_icall_1_133(MethodBind6, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRootBone, 3937882851ul);

    /// <summary>
    /// <para>Sets the root bone index of the bone chain.</para>
    /// </summary>
    public void SetRootBone(int index, int bone)
    {
        NativeCalls.godot_icall_2_59(MethodBind7, GodotObject.GetPtr(this), index, bone);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRootBone, 923996154ul);

    /// <summary>
    /// <para>Returns the root bone index of the bone chain.</para>
    /// </summary>
    public int GetRootBone(int index)
    {
        return NativeCalls.godot_icall_1_60(MethodBind8, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEndBoneName, 501894301ul);

    /// <summary>
    /// <para>Sets the end bone name of the bone chain.</para>
    /// <para><b>Note:</b> The end bone must be a child of the root bone.</para>
    /// </summary>
    public void SetEndBoneName(int index, string boneName)
    {
        NativeCalls.godot_icall_2_181(MethodBind9, GodotObject.GetPtr(this), index, boneName);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEndBoneName, 844755477ul);

    /// <summary>
    /// <para>Returns the end bone name of the bone chain.</para>
    /// </summary>
    public string GetEndBoneName(int index)
    {
        return NativeCalls.godot_icall_1_133(MethodBind10, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEndBone, 3937882851ul);

    /// <summary>
    /// <para>Sets the end bone index of the bone chain.</para>
    /// </summary>
    public void SetEndBone(int index, int bone)
    {
        NativeCalls.godot_icall_2_59(MethodBind11, GodotObject.GetPtr(this), index, bone);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEndBone, 923996154ul);

    /// <summary>
    /// <para>Returns the end bone index of the bone chain.</para>
    /// </summary>
    public int GetEndBone(int index)
    {
        return NativeCalls.godot_icall_1_60(MethodBind12, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetReferenceBoneName, 844755477ul);

    /// <summary>
    /// <para>Returns the reference bone name to extract twist of the setting at <paramref name="index"/>.</para>
    /// <para>This bone is either the end of the chain or its parent, depending on <see cref="Godot.BoneTwistDisperser3D.IsEndBoneExtended(int)"/>.</para>
    /// </summary>
    public string GetReferenceBoneName(int index)
    {
        return NativeCalls.godot_icall_1_133(MethodBind13, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetReferenceBone, 923996154ul);

    /// <summary>
    /// <para>Returns the reference bone to extract twist of the setting at <paramref name="index"/>.</para>
    /// <para>This bone is either the end of the chain or its parent, depending on <see cref="Godot.BoneTwistDisperser3D.IsEndBoneExtended(int)"/>.</para>
    /// </summary>
    public int GetReferenceBone(int index)
    {
        return NativeCalls.godot_icall_1_60(MethodBind14, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetExtendEndBone, 300928843ul);

    /// <summary>
    /// <para>If <paramref name="enabled"/> is <see langword="true"/>, the end bone is extended to have a tail.</para>
    /// <para>If <paramref name="enabled"/> is <see langword="false"/>, <see cref="Godot.BoneTwistDisperser3D.GetReferenceBone(int)"/> becomes a parent of the end bone and it uses the vector to the end bone as a twist axis.</para>
    /// </summary>
    public void SetExtendEndBone(int index, bool enabled)
    {
        NativeCalls.godot_icall_2_61(MethodBind15, GodotObject.GetPtr(this), index, enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsEndBoneExtended, 1116898809ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the end bone is extended to have a tail.</para>
    /// </summary>
    public bool IsEndBoneExtended(int index)
    {
        return NativeCalls.godot_icall_1_62(MethodBind16, GodotObject.GetPtr(this), index).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEndBoneDirection, 2838484201ul);

    /// <summary>
    /// <para>Sets the end bone tail direction of the bone chain when <see cref="Godot.BoneTwistDisperser3D.IsEndBoneExtended(int)"/> is <see langword="true"/>.</para>
    /// </summary>
    public void SetEndBoneDirection(int index, SkeletonModifier3D.BoneDirection boneDirection)
    {
        NativeCalls.godot_icall_2_59(MethodBind17, GodotObject.GetPtr(this), index, (int)boneDirection);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEndBoneDirection, 1843036459ul);

    /// <summary>
    /// <para>Returns the tail direction of the end bone of the bone chain when <see cref="Godot.BoneTwistDisperser3D.IsEndBoneExtended(int)"/> is <see langword="true"/>.</para>
    /// </summary>
    public SkeletonModifier3D.BoneDirection GetEndBoneDirection(int index)
    {
        return (SkeletonModifier3D.BoneDirection)NativeCalls.godot_icall_1_60(MethodBind18, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTwistFromRest, 300928843ul);

    /// <summary>
    /// <para>If <paramref name="enabled"/> is <see langword="true"/>, it extracts the twist amount from the difference between the bone rest and the current bone pose.</para>
    /// <para>If <paramref name="enabled"/> is <see langword="false"/>, it extracts the twist amount from the difference between <see cref="Godot.BoneTwistDisperser3D.GetTwistFrom(int)"/> and the current bone pose. See also <see cref="Godot.BoneTwistDisperser3D.SetTwistFrom(int, Quaternion)"/>.</para>
    /// </summary>
    public void SetTwistFromRest(int index, bool enabled)
    {
        NativeCalls.godot_icall_2_61(MethodBind19, GodotObject.GetPtr(this), index, enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsTwistFromRest, 1116898809ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if extracting the twist amount from the difference between the bone rest and the current bone pose.</para>
    /// </summary>
    public bool IsTwistFromRest(int index)
    {
        return NativeCalls.godot_icall_1_62(MethodBind20, GodotObject.GetPtr(this), index).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTwistFrom, 2823819782ul);

    /// <summary>
    /// <para>Sets the rotation to an arbitrary state before twisting for the current bone pose to extract the twist when <see cref="Godot.BoneTwistDisperser3D.IsTwistFromRest(int)"/> is <see langword="false"/>.</para>
    /// <para>In other words, by calling <see cref="Godot.BoneTwistDisperser3D.SetTwistFrom(int, Quaternion)"/> by <see cref="Godot.SkeletonModifier3D.ModificationProcessed"/> of a specific <see cref="Godot.SkeletonModifier3D"/>, you can extract only the twists generated by modifiers processed after that but before this <see cref="Godot.BoneTwistDisperser3D"/>.</para>
    /// </summary>
    public unsafe void SetTwistFrom(int index, Quaternion from)
    {
        NativeCalls.godot_icall_2_220(MethodBind21, GodotObject.GetPtr(this), index, &from);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTwistFrom, 476865136ul);

    /// <summary>
    /// <para>Returns the rotation to an arbitrary state before twisting for the current bone pose to extract the twist when <see cref="Godot.BoneTwistDisperser3D.IsTwistFromRest(int)"/> is <see langword="false"/>.</para>
    /// </summary>
    public Quaternion GetTwistFrom(int index)
    {
        return NativeCalls.godot_icall_1_221(MethodBind22, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDisperseMode, 2954194337ul);

    /// <summary>
    /// <para>Sets whether to use automatic amount assignment or to allow manual assignment.</para>
    /// </summary>
    public void SetDisperseMode(int index, BoneTwistDisperser3D.DisperseMode disperseMode)
    {
        NativeCalls.godot_icall_2_59(MethodBind23, GodotObject.GetPtr(this), index, (int)disperseMode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDisperseMode, 1326397005ul);

    /// <summary>
    /// <para>Returns whether to use automatic amount assignment or to allow manual assignment.</para>
    /// </summary>
    public BoneTwistDisperser3D.DisperseMode GetDisperseMode(int index)
    {
        return (BoneTwistDisperser3D.DisperseMode)NativeCalls.godot_icall_1_60(MethodBind24, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetWeightPosition, 1602489585ul);

    /// <summary>
    /// <para>Sets the position at which to divide the segment between joints for weight assignment when <see cref="Godot.BoneTwistDisperser3D.GetDisperseMode(int)"/> is <see cref="Godot.BoneTwistDisperser3D.DisperseMode.Weighted"/>.</para>
    /// <para>For example, when <paramref name="weightPosition"/> is <c>0.5</c>, if two bone segments with a length of <c>1.0</c> exist between three joints, weights are assigned to each joint from root to end at ratios of <c>0.5</c>, <c>1.0</c>, and <c>0.5</c>. Then amounts become <c>0.25</c>, <c>0.75</c>, and <c>1.0</c> respectively.</para>
    /// </summary>
    public void SetWeightPosition(int index, float weightPosition)
    {
        NativeCalls.godot_icall_2_69(MethodBind25, GodotObject.GetPtr(this), index, weightPosition);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetWeightPosition, 2339986948ul);

    /// <summary>
    /// <para>Returns the position at which to divide the segment between joints for weight assignment when <see cref="Godot.BoneTwistDisperser3D.GetDisperseMode(int)"/> is <see cref="Godot.BoneTwistDisperser3D.DisperseMode.Weighted"/>.</para>
    /// </summary>
    public float GetWeightPosition(int index)
    {
        return NativeCalls.godot_icall_1_72(MethodBind26, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDampingCurve, 1447180063ul);

    /// <summary>
    /// <para>Sets the damping curve when <see cref="Godot.BoneTwistDisperser3D.GetDisperseMode(int)"/> is <see cref="Godot.BoneTwistDisperser3D.DisperseMode.Custom"/>.</para>
    /// </summary>
    public void SetDampingCurve(int index, Curve curve)
    {
        NativeCalls.godot_icall_2_70(MethodBind27, GodotObject.GetPtr(this), index, GodotObject.GetPtr(curve));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDampingCurve, 747537754ul);

    /// <summary>
    /// <para>Returns the damping curve when <see cref="Godot.BoneTwistDisperser3D.GetDisperseMode(int)"/> is <see cref="Godot.BoneTwistDisperser3D.DisperseMode.Custom"/>.</para>
    /// </summary>
    public Curve GetDampingCurve(int index)
    {
        return (Curve)NativeCalls.godot_icall_1_71(MethodBind28, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetJointBoneName, 1391810591ul);

    /// <summary>
    /// <para>Returns the bone name at <paramref name="joint"/> in the bone chain's joint list.</para>
    /// </summary>
    public string GetJointBoneName(int index, int joint)
    {
        return NativeCalls.godot_icall_2_222(MethodBind29, GodotObject.GetPtr(this), index, joint);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetJointBone, 3175239445ul);

    /// <summary>
    /// <para>Returns the bone index at <paramref name="joint"/> in the bone chain's joint list.</para>
    /// </summary>
    public int GetJointBone(int index, int joint)
    {
        return NativeCalls.godot_icall_2_73(MethodBind30, GodotObject.GetPtr(this), index, joint);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetJointTwistAmount, 3085491603ul);

    /// <summary>
    /// <para>Returns the twist amount at <paramref name="joint"/> in the bone chain's joint list when <see cref="Godot.BoneTwistDisperser3D.GetDisperseMode(int)"/> is <see cref="Godot.BoneTwistDisperser3D.DisperseMode.Custom"/>.</para>
    /// </summary>
    public float GetJointTwistAmount(int index, int joint)
    {
        return NativeCalls.godot_icall_2_88(MethodBind31, GodotObject.GetPtr(this), index, joint);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind32 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetJointTwistAmount, 3506521499ul);

    /// <summary>
    /// <para>Sets the twist amount at <paramref name="joint"/> in the bone chain's joint list when <see cref="Godot.BoneTwistDisperser3D.GetDisperseMode(int)"/> is <see cref="Godot.BoneTwistDisperser3D.DisperseMode.Custom"/>.</para>
    /// </summary>
    public void SetJointTwistAmount(int index, int joint, float twistAmount)
    {
        NativeCalls.godot_icall_3_86(MethodBind32, GodotObject.GetPtr(this), index, joint, twistAmount);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind33 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetJointCount, 923996154ul);

    /// <summary>
    /// <para>Returns the joint count of the bone chain's joint list.</para>
    /// </summary>
    public int GetJointCount(int index)
    {
        return NativeCalls.godot_icall_1_60(MethodBind33, GodotObject.GetPtr(this), index);
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
        /// Cached name for the 'set_mutable_bone_axes' method.
        /// </summary>
        public static readonly StringName SetMutableBoneAxes = "set_mutable_bone_axes";
        /// <summary>
        /// Cached name for the 'are_bone_axes_mutable' method.
        /// </summary>
        public static readonly StringName AreBoneAxesMutable = "are_bone_axes_mutable";
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
        /// Cached name for the 'get_reference_bone_name' method.
        /// </summary>
        public static readonly StringName GetReferenceBoneName = "get_reference_bone_name";
        /// <summary>
        /// Cached name for the 'get_reference_bone' method.
        /// </summary>
        public static readonly StringName GetReferenceBone = "get_reference_bone";
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
        /// Cached name for the 'set_twist_from_rest' method.
        /// </summary>
        public static readonly StringName SetTwistFromRest = "set_twist_from_rest";
        /// <summary>
        /// Cached name for the 'is_twist_from_rest' method.
        /// </summary>
        public static readonly StringName IsTwistFromRest = "is_twist_from_rest";
        /// <summary>
        /// Cached name for the 'set_twist_from' method.
        /// </summary>
        public static readonly StringName SetTwistFrom = "set_twist_from";
        /// <summary>
        /// Cached name for the 'get_twist_from' method.
        /// </summary>
        public static readonly StringName GetTwistFrom = "get_twist_from";
        /// <summary>
        /// Cached name for the 'set_disperse_mode' method.
        /// </summary>
        public static readonly StringName SetDisperseMode = "set_disperse_mode";
        /// <summary>
        /// Cached name for the 'get_disperse_mode' method.
        /// </summary>
        public static readonly StringName GetDisperseMode = "get_disperse_mode";
        /// <summary>
        /// Cached name for the 'set_weight_position' method.
        /// </summary>
        public static readonly StringName SetWeightPosition = "set_weight_position";
        /// <summary>
        /// Cached name for the 'get_weight_position' method.
        /// </summary>
        public static readonly StringName GetWeightPosition = "get_weight_position";
        /// <summary>
        /// Cached name for the 'set_damping_curve' method.
        /// </summary>
        public static readonly StringName SetDampingCurve = "set_damping_curve";
        /// <summary>
        /// Cached name for the 'get_damping_curve' method.
        /// </summary>
        public static readonly StringName GetDampingCurve = "get_damping_curve";
        /// <summary>
        /// Cached name for the 'get_joint_bone_name' method.
        /// </summary>
        public static readonly StringName GetJointBoneName = "get_joint_bone_name";
        /// <summary>
        /// Cached name for the 'get_joint_bone' method.
        /// </summary>
        public static readonly StringName GetJointBone = "get_joint_bone";
        /// <summary>
        /// Cached name for the 'get_joint_twist_amount' method.
        /// </summary>
        public static readonly StringName GetJointTwistAmount = "get_joint_twist_amount";
        /// <summary>
        /// Cached name for the 'set_joint_twist_amount' method.
        /// </summary>
        public static readonly StringName SetJointTwistAmount = "set_joint_twist_amount";
        /// <summary>
        /// Cached name for the 'get_joint_count' method.
        /// </summary>
        public static readonly StringName GetJointCount = "get_joint_count";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : SkeletonModifier3D.SignalName
    {
    }
}
