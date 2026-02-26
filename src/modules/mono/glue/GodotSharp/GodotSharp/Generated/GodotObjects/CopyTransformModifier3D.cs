namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Apply the copied transform of the bone set by <see cref="Godot.BoneConstraint3D.SetReferenceBone(int, int)"/> to the bone set by <see cref="Godot.BoneConstraint3D.SetApplyBone(int, int)"/> with processing it with some masks and options.</para>
/// <para>There are 4 ways to apply the transform, depending on the combination of <see cref="Godot.CopyTransformModifier3D.SetRelative(int, bool)"/> and <see cref="Godot.CopyTransformModifier3D.SetAdditive(int, bool)"/>.</para>
/// <para><b>Relative + Additive:</b></para>
/// <para>- Extract reference pose relative to the rest and add it to the apply bone's pose.</para>
/// <para><b>Relative + Not Additive:</b></para>
/// <para>- Extract reference pose relative to the rest and add it to the apply bone's rest.</para>
/// <para><b>Not Relative + Additive:</b></para>
/// <para>- Extract reference pose absolutely and add it to the apply bone's pose.</para>
/// <para><b>Not Relative + Not Additive:</b></para>
/// <para>- Extract reference pose absolutely and the apply bone's pose is replaced with it.</para>
/// <para><b>Note:</b> Relative option is available only in the case <see cref="Godot.BoneConstraint3D.GetReferenceType(int)"/> is <see cref="Godot.BoneConstraint3D.ReferenceType.Bone"/>. See also <see cref="Godot.BoneConstraint3D.ReferenceType"/>.</para>
/// </summary>
public partial class CopyTransformModifier3D : BoneConstraint3D
{
    [System.Flags]
    public enum TransformFlag : long
    {
        /// <summary>
        /// <para>If set, allows to copy the position.</para>
        /// </summary>
        Position = 1,
        /// <summary>
        /// <para>If set, allows to copy the rotation.</para>
        /// </summary>
        Rotation = 2,
        /// <summary>
        /// <para>If set, allows to copy the scale.</para>
        /// </summary>
        Scale = 4,
        /// <summary>
        /// <para>If set, allows to copy the position/rotation/scale.</para>
        /// </summary>
        All = 7
    }

    [System.Flags]
    public enum AxisFlag : long
    {
        /// <summary>
        /// <para>If set, allows to process the X-axis.</para>
        /// </summary>
        X = 1,
        /// <summary>
        /// <para>If set, allows to process the Y-axis.</para>
        /// </summary>
        Y = 2,
        /// <summary>
        /// <para>If set, allows to process the Z-axis.</para>
        /// </summary>
        Z = 4,
        /// <summary>
        /// <para>If set, allows to process the all axes.</para>
        /// </summary>
        All = 7
    }

    /// <summary>
    /// <para>The number of settings in the modifier.</para>
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

    private static readonly System.Type CachedType = typeof(CopyTransformModifier3D);

    private static readonly StringName NativeName = "CopyTransformModifier3D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public CopyTransformModifier3D() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal CopyTransformModifier3D(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal CopyTransformModifier3D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCopyFlags, 2252507859ul);

    /// <summary>
    /// <para>Sets the flags to process the transform operations. If the flag is valid, the transform operation is processed.</para>
    /// <para><b>Note:</b> If the rotation is valid for only one axis, it respects the roll of the valid axis. If the rotation is valid for two axes, it discards the roll of the invalid axis.</para>
    /// </summary>
    public void SetCopyFlags(int index, CopyTransformModifier3D.TransformFlag copyFlags)
    {
        NativeCalls.godot_icall_2_59(MethodBind0, GodotObject.GetPtr(this), index, (int)copyFlags);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCopyFlags, 1685185931ul);

    /// <summary>
    /// <para>Returns the copy flags of the setting at <paramref name="index"/>.</para>
    /// </summary>
    public CopyTransformModifier3D.TransformFlag GetCopyFlags(int index)
    {
        return (CopyTransformModifier3D.TransformFlag)NativeCalls.godot_icall_1_60(MethodBind1, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAxisFlags, 2044211897ul);

    /// <summary>
    /// <para>Sets the flags to copy axes. If the flag is valid, the axis is copied.</para>
    /// </summary>
    public void SetAxisFlags(int index, CopyTransformModifier3D.AxisFlag axisFlags)
    {
        NativeCalls.godot_icall_2_59(MethodBind2, GodotObject.GetPtr(this), index, (int)axisFlags);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAxisFlags, 992162046ul);

    /// <summary>
    /// <para>Returns the axis flags of the setting at <paramref name="index"/>.</para>
    /// </summary>
    public CopyTransformModifier3D.AxisFlag GetAxisFlags(int index)
    {
        return (CopyTransformModifier3D.AxisFlag)NativeCalls.godot_icall_1_60(MethodBind3, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetInvertFlags, 2044211897ul);

    /// <summary>
    /// <para>Sets the flags to inverte axes. If the flag is valid, the axis is copied.</para>
    /// <para><b>Note:</b> An inverted scale means an inverse number, not a negative scale. For example, inverting <c>2.0</c> means <c>0.5</c>.</para>
    /// <para><b>Note:</b> An inverted rotation flips the elements of the quaternion. For example, a two-axis inversion will flip the roll of each axis, and a three-axis inversion will flip the final orientation. However, be aware that flipping only one axis may cause unintended rotation by the unflipped axes, due to the characteristics of the quaternion.</para>
    /// </summary>
    public void SetInvertFlags(int index, CopyTransformModifier3D.AxisFlag axisFlags)
    {
        NativeCalls.godot_icall_2_59(MethodBind4, GodotObject.GetPtr(this), index, (int)axisFlags);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetInvertFlags, 992162046ul);

    /// <summary>
    /// <para>Returns the invert flags of the setting at <paramref name="index"/>.</para>
    /// </summary>
    public CopyTransformModifier3D.AxisFlag GetInvertFlags(int index)
    {
        return (CopyTransformModifier3D.AxisFlag)NativeCalls.godot_icall_1_60(MethodBind5, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCopyPosition, 300928843ul);

    /// <summary>
    /// <para>If sets <paramref name="enabled"/> to <see langword="true"/>, the position will be copied.</para>
    /// </summary>
    public void SetCopyPosition(int index, bool enabled)
    {
        NativeCalls.godot_icall_2_61(MethodBind6, GodotObject.GetPtr(this), index, enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsPositionCopying, 1116898809ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the copy flags has the flag for the position in the setting at <paramref name="index"/>. See also <see cref="Godot.CopyTransformModifier3D.SetCopyFlags(int, CopyTransformModifier3D.TransformFlag)"/>.</para>
    /// </summary>
    public bool IsPositionCopying(int index)
    {
        return NativeCalls.godot_icall_1_62(MethodBind7, GodotObject.GetPtr(this), index).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCopyRotation, 300928843ul);

    /// <summary>
    /// <para>If sets <paramref name="enabled"/> to <see langword="true"/>, the rotation will be copied.</para>
    /// </summary>
    public void SetCopyRotation(int index, bool enabled)
    {
        NativeCalls.godot_icall_2_61(MethodBind8, GodotObject.GetPtr(this), index, enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsRotationCopying, 1116898809ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the copy flags has the flag for the rotation in the setting at <paramref name="index"/>. See also <see cref="Godot.CopyTransformModifier3D.SetCopyFlags(int, CopyTransformModifier3D.TransformFlag)"/>.</para>
    /// </summary>
    public bool IsRotationCopying(int index)
    {
        return NativeCalls.godot_icall_1_62(MethodBind9, GodotObject.GetPtr(this), index).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCopyScale, 300928843ul);

    /// <summary>
    /// <para>If sets <paramref name="enabled"/> to <see langword="true"/>, the scale will be copied.</para>
    /// </summary>
    public void SetCopyScale(int index, bool enabled)
    {
        NativeCalls.godot_icall_2_61(MethodBind10, GodotObject.GetPtr(this), index, enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsScaleCopying, 1116898809ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the copy flags has the flag for the scale in the setting at <paramref name="index"/>. See also <see cref="Godot.CopyTransformModifier3D.SetCopyFlags(int, CopyTransformModifier3D.TransformFlag)"/>.</para>
    /// </summary>
    public bool IsScaleCopying(int index)
    {
        return NativeCalls.godot_icall_1_62(MethodBind11, GodotObject.GetPtr(this), index).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAxisXEnabled, 300928843ul);

    /// <summary>
    /// <para>If sets <paramref name="enabled"/> to <see langword="true"/>, the X-axis will be copied.</para>
    /// </summary>
    public void SetAxisXEnabled(int index, bool enabled)
    {
        NativeCalls.godot_icall_2_61(MethodBind12, GodotObject.GetPtr(this), index, enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsAxisXEnabled, 1116898809ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the enable flags has the flag for the X-axis in the setting at <paramref name="index"/>. See also <see cref="Godot.CopyTransformModifier3D.SetAxisFlags(int, CopyTransformModifier3D.AxisFlag)"/>.</para>
    /// </summary>
    public bool IsAxisXEnabled(int index)
    {
        return NativeCalls.godot_icall_1_62(MethodBind13, GodotObject.GetPtr(this), index).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAxisYEnabled, 300928843ul);

    /// <summary>
    /// <para>If sets <paramref name="enabled"/> to <see langword="true"/>, the Y-axis will be copied.</para>
    /// </summary>
    public void SetAxisYEnabled(int index, bool enabled)
    {
        NativeCalls.godot_icall_2_61(MethodBind14, GodotObject.GetPtr(this), index, enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsAxisYEnabled, 1116898809ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the enable flags has the flag for the Y-axis in the setting at <paramref name="index"/>. See also <see cref="Godot.CopyTransformModifier3D.SetAxisFlags(int, CopyTransformModifier3D.AxisFlag)"/>.</para>
    /// </summary>
    public bool IsAxisYEnabled(int index)
    {
        return NativeCalls.godot_icall_1_62(MethodBind15, GodotObject.GetPtr(this), index).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAxisZEnabled, 300928843ul);

    /// <summary>
    /// <para>If sets <paramref name="enabled"/> to <see langword="true"/>, the Z-axis will be copied.</para>
    /// </summary>
    public void SetAxisZEnabled(int index, bool enabled)
    {
        NativeCalls.godot_icall_2_61(MethodBind16, GodotObject.GetPtr(this), index, enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsAxisZEnabled, 1116898809ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the enable flags has the flag for the Z-axis in the setting at <paramref name="index"/>. See also <see cref="Godot.CopyTransformModifier3D.SetAxisFlags(int, CopyTransformModifier3D.AxisFlag)"/>.</para>
    /// </summary>
    public bool IsAxisZEnabled(int index)
    {
        return NativeCalls.godot_icall_1_62(MethodBind17, GodotObject.GetPtr(this), index).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAxisXInverted, 300928843ul);

    /// <summary>
    /// <para>If sets <paramref name="enabled"/> to <see langword="true"/>, the X-axis will be inverted.</para>
    /// </summary>
    public void SetAxisXInverted(int index, bool enabled)
    {
        NativeCalls.godot_icall_2_61(MethodBind18, GodotObject.GetPtr(this), index, enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsAxisXInverted, 1116898809ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the invert flags has the flag for the X-axis in the setting at <paramref name="index"/>. See also <see cref="Godot.CopyTransformModifier3D.SetInvertFlags(int, CopyTransformModifier3D.AxisFlag)"/>.</para>
    /// </summary>
    public bool IsAxisXInverted(int index)
    {
        return NativeCalls.godot_icall_1_62(MethodBind19, GodotObject.GetPtr(this), index).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAxisYInverted, 300928843ul);

    /// <summary>
    /// <para>If sets <paramref name="enabled"/> to <see langword="true"/>, the Y-axis will be inverted.</para>
    /// </summary>
    public void SetAxisYInverted(int index, bool enabled)
    {
        NativeCalls.godot_icall_2_61(MethodBind20, GodotObject.GetPtr(this), index, enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsAxisYInverted, 1116898809ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the invert flags has the flag for the Y-axis in the setting at <paramref name="index"/>. See also <see cref="Godot.CopyTransformModifier3D.SetInvertFlags(int, CopyTransformModifier3D.AxisFlag)"/>.</para>
    /// </summary>
    public bool IsAxisYInverted(int index)
    {
        return NativeCalls.godot_icall_1_62(MethodBind21, GodotObject.GetPtr(this), index).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAxisZInverted, 300928843ul);

    /// <summary>
    /// <para>If sets <paramref name="enabled"/> to <see langword="true"/>, the Z-axis will be inverted.</para>
    /// </summary>
    public void SetAxisZInverted(int index, bool enabled)
    {
        NativeCalls.godot_icall_2_61(MethodBind22, GodotObject.GetPtr(this), index, enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsAxisZInverted, 1116898809ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the invert flags has the flag for the Z-axis in the setting at <paramref name="index"/>. See also <see cref="Godot.CopyTransformModifier3D.SetInvertFlags(int, CopyTransformModifier3D.AxisFlag)"/>.</para>
    /// </summary>
    public bool IsAxisZInverted(int index)
    {
        return NativeCalls.godot_icall_1_62(MethodBind23, GodotObject.GetPtr(this), index).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRelative, 300928843ul);

    /// <summary>
    /// <para>Sets relative option in the setting at <paramref name="index"/> to <paramref name="enabled"/>.</para>
    /// <para>If sets <paramref name="enabled"/> to <see langword="true"/>, the extracted and applying transform is relative to the rest.</para>
    /// <para>If sets <paramref name="enabled"/> to <see langword="false"/>, the extracted transform is absolute.</para>
    /// </summary>
    public void SetRelative(int index, bool enabled)
    {
        NativeCalls.godot_icall_2_61(MethodBind24, GodotObject.GetPtr(this), index, enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsRelative, 1116898809ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the relative option is enabled in the setting at <paramref name="index"/>.</para>
    /// </summary>
    public bool IsRelative(int index)
    {
        return NativeCalls.godot_icall_1_62(MethodBind25, GodotObject.GetPtr(this), index).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAdditive, 300928843ul);

    /// <summary>
    /// <para>Sets additive option in the setting at <paramref name="index"/> to <paramref name="enabled"/>. This mainly affects the process of applying transform to the <see cref="Godot.BoneConstraint3D.SetApplyBone(int, int)"/>.</para>
    /// <para>If sets <paramref name="enabled"/> to <see langword="true"/>, the processed transform is added to the pose of the current apply bone.</para>
    /// <para>If sets <paramref name="enabled"/> to <see langword="false"/>, the pose of the current apply bone is replaced with the processed transform. However, if set <see cref="Godot.CopyTransformModifier3D.SetRelative(int, bool)"/> to <see langword="true"/>, the transform is relative to rest.</para>
    /// </summary>
    public void SetAdditive(int index, bool enabled)
    {
        NativeCalls.godot_icall_2_61(MethodBind26, GodotObject.GetPtr(this), index, enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsAdditive, 1116898809ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the additive option is enabled in the setting at <paramref name="index"/>.</para>
    /// </summary>
    public bool IsAdditive(int index)
    {
        return NativeCalls.godot_icall_1_62(MethodBind27, GodotObject.GetPtr(this), index).ToBool();
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
    public new class PropertyName : BoneConstraint3D.PropertyName
    {
        /// <summary>
        /// Cached name for the 'setting_count' property.
        /// </summary>
        public static readonly StringName SettingCount = "setting_count";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : BoneConstraint3D.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_copy_flags' method.
        /// </summary>
        public static readonly StringName SetCopyFlags = "set_copy_flags";
        /// <summary>
        /// Cached name for the 'get_copy_flags' method.
        /// </summary>
        public static readonly StringName GetCopyFlags = "get_copy_flags";
        /// <summary>
        /// Cached name for the 'set_axis_flags' method.
        /// </summary>
        public static readonly StringName SetAxisFlags = "set_axis_flags";
        /// <summary>
        /// Cached name for the 'get_axis_flags' method.
        /// </summary>
        public static readonly StringName GetAxisFlags = "get_axis_flags";
        /// <summary>
        /// Cached name for the 'set_invert_flags' method.
        /// </summary>
        public static readonly StringName SetInvertFlags = "set_invert_flags";
        /// <summary>
        /// Cached name for the 'get_invert_flags' method.
        /// </summary>
        public static readonly StringName GetInvertFlags = "get_invert_flags";
        /// <summary>
        /// Cached name for the 'set_copy_position' method.
        /// </summary>
        public static readonly StringName SetCopyPosition = "set_copy_position";
        /// <summary>
        /// Cached name for the 'is_position_copying' method.
        /// </summary>
        public static readonly StringName IsPositionCopying = "is_position_copying";
        /// <summary>
        /// Cached name for the 'set_copy_rotation' method.
        /// </summary>
        public static readonly StringName SetCopyRotation = "set_copy_rotation";
        /// <summary>
        /// Cached name for the 'is_rotation_copying' method.
        /// </summary>
        public static readonly StringName IsRotationCopying = "is_rotation_copying";
        /// <summary>
        /// Cached name for the 'set_copy_scale' method.
        /// </summary>
        public static readonly StringName SetCopyScale = "set_copy_scale";
        /// <summary>
        /// Cached name for the 'is_scale_copying' method.
        /// </summary>
        public static readonly StringName IsScaleCopying = "is_scale_copying";
        /// <summary>
        /// Cached name for the 'set_axis_x_enabled' method.
        /// </summary>
        public static readonly StringName SetAxisXEnabled = "set_axis_x_enabled";
        /// <summary>
        /// Cached name for the 'is_axis_x_enabled' method.
        /// </summary>
        public static readonly StringName IsAxisXEnabled = "is_axis_x_enabled";
        /// <summary>
        /// Cached name for the 'set_axis_y_enabled' method.
        /// </summary>
        public static readonly StringName SetAxisYEnabled = "set_axis_y_enabled";
        /// <summary>
        /// Cached name for the 'is_axis_y_enabled' method.
        /// </summary>
        public static readonly StringName IsAxisYEnabled = "is_axis_y_enabled";
        /// <summary>
        /// Cached name for the 'set_axis_z_enabled' method.
        /// </summary>
        public static readonly StringName SetAxisZEnabled = "set_axis_z_enabled";
        /// <summary>
        /// Cached name for the 'is_axis_z_enabled' method.
        /// </summary>
        public static readonly StringName IsAxisZEnabled = "is_axis_z_enabled";
        /// <summary>
        /// Cached name for the 'set_axis_x_inverted' method.
        /// </summary>
        public static readonly StringName SetAxisXInverted = "set_axis_x_inverted";
        /// <summary>
        /// Cached name for the 'is_axis_x_inverted' method.
        /// </summary>
        public static readonly StringName IsAxisXInverted = "is_axis_x_inverted";
        /// <summary>
        /// Cached name for the 'set_axis_y_inverted' method.
        /// </summary>
        public static readonly StringName SetAxisYInverted = "set_axis_y_inverted";
        /// <summary>
        /// Cached name for the 'is_axis_y_inverted' method.
        /// </summary>
        public static readonly StringName IsAxisYInverted = "is_axis_y_inverted";
        /// <summary>
        /// Cached name for the 'set_axis_z_inverted' method.
        /// </summary>
        public static readonly StringName SetAxisZInverted = "set_axis_z_inverted";
        /// <summary>
        /// Cached name for the 'is_axis_z_inverted' method.
        /// </summary>
        public static readonly StringName IsAxisZInverted = "is_axis_z_inverted";
        /// <summary>
        /// Cached name for the 'set_relative' method.
        /// </summary>
        public static readonly StringName SetRelative = "set_relative";
        /// <summary>
        /// Cached name for the 'is_relative' method.
        /// </summary>
        public static readonly StringName IsRelative = "is_relative";
        /// <summary>
        /// Cached name for the 'set_additive' method.
        /// </summary>
        public static readonly StringName SetAdditive = "set_additive";
        /// <summary>
        /// Cached name for the 'is_additive' method.
        /// </summary>
        public static readonly StringName IsAdditive = "is_additive";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : BoneConstraint3D.SignalName
    {
    }
}
