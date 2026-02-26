namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Base class of <see cref="Godot.SkeletonModifier3D"/> that modifies the bone set in <see cref="Godot.BoneConstraint3D.SetApplyBone(int, int)"/> based on the transform of the bone retrieved by <see cref="Godot.BoneConstraint3D.GetReferenceBone(int)"/>.</para>
/// </summary>
public partial class BoneConstraint3D : SkeletonModifier3D
{
    public enum ReferenceType : long
    {
        /// <summary>
        /// <para>The reference target is a bone. In this case, the reference target spaces is local space.</para>
        /// </summary>
        Bone = 0,
        /// <summary>
        /// <para>The reference target is a <see cref="Godot.Node3D"/>. In this case, the reference target spaces is model space.</para>
        /// <para>In other words, the reference target's coordinates are treated as if it were placed directly under <see cref="Godot.Skeleton3D"/> which parent of the <see cref="Godot.BoneConstraint3D"/>.</para>
        /// </summary>
        Node = 1
    }

    private static readonly System.Type CachedType = typeof(BoneConstraint3D);

    private static readonly StringName NativeName = "BoneConstraint3D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public BoneConstraint3D() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal BoneConstraint3D(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal BoneConstraint3D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAmount, 1602489585ul);

    /// <summary>
    /// <para>Sets the apply amount of the setting at <paramref name="index"/> to <paramref name="amount"/>.</para>
    /// </summary>
    public void SetAmount(int index, float amount)
    {
        NativeCalls.godot_icall_2_69(MethodBind0, GodotObject.GetPtr(this), index, amount);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAmount, 2339986948ul);

    /// <summary>
    /// <para>Returns the apply amount of the setting at <paramref name="index"/>.</para>
    /// </summary>
    public float GetAmount(int index)
    {
        return NativeCalls.godot_icall_1_72(MethodBind1, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetApplyBoneName, 501894301ul);

    /// <summary>
    /// <para>Sets the apply bone of the setting at <paramref name="index"/> to <paramref name="boneName"/>. This bone will be modified.</para>
    /// </summary>
    public void SetApplyBoneName(int index, string boneName)
    {
        NativeCalls.godot_icall_2_181(MethodBind2, GodotObject.GetPtr(this), index, boneName);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetApplyBoneName, 844755477ul);

    /// <summary>
    /// <para>Returns the apply bone name of the setting at <paramref name="index"/>. This bone will be modified.</para>
    /// </summary>
    public string GetApplyBoneName(int index)
    {
        return NativeCalls.godot_icall_1_133(MethodBind3, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetApplyBone, 3937882851ul);

    /// <summary>
    /// <para>Sets the apply bone of the setting at <paramref name="index"/> to <paramref name="bone"/>. This bone will be modified.</para>
    /// </summary>
    public void SetApplyBone(int index, int bone)
    {
        NativeCalls.godot_icall_2_59(MethodBind4, GodotObject.GetPtr(this), index, bone);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetApplyBone, 923996154ul);

    /// <summary>
    /// <para>Returns the apply bone of the setting at <paramref name="index"/>. This bone will be modified.</para>
    /// </summary>
    public int GetApplyBone(int index)
    {
        return NativeCalls.godot_icall_1_60(MethodBind5, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetReferenceType, 1830520418ul);

    /// <summary>
    /// <para>Sets the reference target type of the setting at <paramref name="index"/> to <paramref name="type"/>. See also <see cref="Godot.BoneConstraint3D.ReferenceType"/>.</para>
    /// </summary>
    public void SetReferenceType(int index, BoneConstraint3D.ReferenceType type)
    {
        NativeCalls.godot_icall_2_59(MethodBind6, GodotObject.GetPtr(this), index, (int)type);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetReferenceType, 3456416152ul);

    /// <summary>
    /// <para>Returns the reference target type of the setting at <paramref name="index"/>. See also <see cref="Godot.BoneConstraint3D.ReferenceType"/>.</para>
    /// </summary>
    public BoneConstraint3D.ReferenceType GetReferenceType(int index)
    {
        return (BoneConstraint3D.ReferenceType)NativeCalls.godot_icall_1_60(MethodBind7, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetReferenceBoneName, 501894301ul);

    /// <summary>
    /// <para>Sets the reference bone of the setting at <paramref name="index"/> to <paramref name="boneName"/>.</para>
    /// <para>This bone will be only referenced and not modified by this modifier.</para>
    /// </summary>
    public void SetReferenceBoneName(int index, string boneName)
    {
        NativeCalls.godot_icall_2_181(MethodBind8, GodotObject.GetPtr(this), index, boneName);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetReferenceBoneName, 844755477ul);

    /// <summary>
    /// <para>Returns the reference bone name of the setting at <paramref name="index"/>.</para>
    /// <para>This bone will be only referenced and not modified by this modifier.</para>
    /// </summary>
    public string GetReferenceBoneName(int index)
    {
        return NativeCalls.godot_icall_1_133(MethodBind9, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetReferenceBone, 3937882851ul);

    /// <summary>
    /// <para>Sets the reference bone of the setting at <paramref name="index"/> to <paramref name="bone"/>.</para>
    /// <para>This bone will be only referenced and not modified by this modifier.</para>
    /// </summary>
    public void SetReferenceBone(int index, int bone)
    {
        NativeCalls.godot_icall_2_59(MethodBind10, GodotObject.GetPtr(this), index, bone);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetReferenceBone, 923996154ul);

    /// <summary>
    /// <para>Returns the reference bone of the setting at <paramref name="index"/>.</para>
    /// <para>This bone will be only referenced and not modified by this modifier.</para>
    /// </summary>
    public int GetReferenceBone(int index)
    {
        return NativeCalls.godot_icall_1_60(MethodBind11, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetReferenceNode, 2761262315ul);

    /// <summary>
    /// <para>Sets the reference node path of the setting at <paramref name="index"/> to <paramref name="node"/>.</para>
    /// <para>This node will be only referenced and not modified by this modifier.</para>
    /// </summary>
    public void SetReferenceNode(int index, NodePath node)
    {
        NativeCalls.godot_icall_2_75(MethodBind12, GodotObject.GetPtr(this), index, (godot_node_path)(node?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetReferenceNode, 408788394ul);

    /// <summary>
    /// <para>Returns the reference node path of the setting at <paramref name="index"/>.</para>
    /// <para>This node will be only referenced and not modified by this modifier.</para>
    /// </summary>
    public NodePath GetReferenceNode(int index)
    {
        return NativeCalls.godot_icall_1_74(MethodBind13, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSettingCount, 1286410249ul);

    /// <summary>
    /// <para>Sets the number of settings in the modifier.</para>
    /// </summary>
    public void SetSettingCount(int count)
    {
        NativeCalls.godot_icall_1_38(MethodBind14, GodotObject.GetPtr(this), count);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSettingCount, 3905245786ul);

    /// <summary>
    /// <para>Returns the number of settings in the modifier.</para>
    /// </summary>
    public int GetSettingCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind15, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ClearSetting, 3218959716ul);

    /// <summary>
    /// <para>Clear all settings.</para>
    /// </summary>
    public void ClearSetting()
    {
        NativeCalls.godot_icall_0_3(MethodBind16, GodotObject.GetPtr(this));
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
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : SkeletonModifier3D.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_amount' method.
        /// </summary>
        public static readonly StringName SetAmount = "set_amount";
        /// <summary>
        /// Cached name for the 'get_amount' method.
        /// </summary>
        public static readonly StringName GetAmount = "get_amount";
        /// <summary>
        /// Cached name for the 'set_apply_bone_name' method.
        /// </summary>
        public static readonly StringName SetApplyBoneName = "set_apply_bone_name";
        /// <summary>
        /// Cached name for the 'get_apply_bone_name' method.
        /// </summary>
        public static readonly StringName GetApplyBoneName = "get_apply_bone_name";
        /// <summary>
        /// Cached name for the 'set_apply_bone' method.
        /// </summary>
        public static readonly StringName SetApplyBone = "set_apply_bone";
        /// <summary>
        /// Cached name for the 'get_apply_bone' method.
        /// </summary>
        public static readonly StringName GetApplyBone = "get_apply_bone";
        /// <summary>
        /// Cached name for the 'set_reference_type' method.
        /// </summary>
        public static readonly StringName SetReferenceType = "set_reference_type";
        /// <summary>
        /// Cached name for the 'get_reference_type' method.
        /// </summary>
        public static readonly StringName GetReferenceType = "get_reference_type";
        /// <summary>
        /// Cached name for the 'set_reference_bone_name' method.
        /// </summary>
        public static readonly StringName SetReferenceBoneName = "set_reference_bone_name";
        /// <summary>
        /// Cached name for the 'get_reference_bone_name' method.
        /// </summary>
        public static readonly StringName GetReferenceBoneName = "get_reference_bone_name";
        /// <summary>
        /// Cached name for the 'set_reference_bone' method.
        /// </summary>
        public static readonly StringName SetReferenceBone = "set_reference_bone";
        /// <summary>
        /// Cached name for the 'get_reference_bone' method.
        /// </summary>
        public static readonly StringName GetReferenceBone = "get_reference_bone";
        /// <summary>
        /// Cached name for the 'set_reference_node' method.
        /// </summary>
        public static readonly StringName SetReferenceNode = "set_reference_node";
        /// <summary>
        /// Cached name for the 'get_reference_node' method.
        /// </summary>
        public static readonly StringName GetReferenceNode = "get_reference_node";
        /// <summary>
        /// Cached name for the 'set_setting_count' method.
        /// </summary>
        public static readonly StringName SetSettingCount = "set_setting_count";
        /// <summary>
        /// Cached name for the 'get_setting_count' method.
        /// </summary>
        public static readonly StringName GetSettingCount = "get_setting_count";
        /// <summary>
        /// Cached name for the 'clear_setting' method.
        /// </summary>
        public static readonly StringName ClearSetting = "clear_setting";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : SkeletonModifier3D.SignalName
    {
    }
}
