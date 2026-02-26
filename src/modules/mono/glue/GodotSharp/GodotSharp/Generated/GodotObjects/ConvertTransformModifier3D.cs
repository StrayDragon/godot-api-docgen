namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Apply the copied transform of the bone set by <see cref="Godot.BoneConstraint3D.SetReferenceBone(int, int)"/> to the bone set by <see cref="Godot.BoneConstraint3D.SetApplyBone(int, int)"/> about the specific axis with remapping it with some options.</para>
/// <para>There are 4 ways to apply the transform, depending on the combination of <see cref="Godot.ConvertTransformModifier3D.SetRelative(int, bool)"/> and <see cref="Godot.ConvertTransformModifier3D.SetAdditive(int, bool)"/>.</para>
/// <para><b>Relative + Additive:</b></para>
/// <para>- Extract reference pose relative to the rest and add it to the apply bone's pose.</para>
/// <para><b>Relative + Not Additive:</b></para>
/// <para>- Extract reference pose relative to the rest and add it to the apply bone's rest.</para>
/// <para><b>Not Relative + Additive:</b></para>
/// <para>- Extract reference pose absolutely and add it to the apply bone's pose.</para>
/// <para><b>Not Relative + Not Additive:</b></para>
/// <para>- Extract reference pose absolutely and the apply bone's pose is replaced with it.</para>
/// <para><b>Note:</b> Relative option is available only in the case <see cref="Godot.BoneConstraint3D.GetReferenceType(int)"/> is <see cref="Godot.BoneConstraint3D.ReferenceType.Bone"/>. See also <see cref="Godot.BoneConstraint3D.ReferenceType"/>.</para>
/// <para><b>Note:</b> If there is a rotation greater than <c>180</c> degrees with constrained axes, flipping may occur.</para>
/// </summary>
public partial class ConvertTransformModifier3D : BoneConstraint3D
{
    public enum TransformMode : long
    {
        /// <summary>
        /// <para>Convert with position. Transfer the difference.</para>
        /// </summary>
        Position = 0,
        /// <summary>
        /// <para>Convert with rotation. The angle is the roll for the specified axis.</para>
        /// </summary>
        Rotation = 1,
        /// <summary>
        /// <para>Convert with scale. Transfers the ratio, not the difference.</para>
        /// </summary>
        Scale = 2
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

    private static readonly System.Type CachedType = typeof(ConvertTransformModifier3D);

    private static readonly StringName NativeName = "ConvertTransformModifier3D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public ConvertTransformModifier3D() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal ConvertTransformModifier3D(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal ConvertTransformModifier3D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetApplyTransformMode, 1386463405ul);

    /// <summary>
    /// <para>Sets the operation of the remapping destination transform.</para>
    /// </summary>
    public void SetApplyTransformMode(int index, ConvertTransformModifier3D.TransformMode transformMode)
    {
        NativeCalls.godot_icall_2_59(MethodBind0, GodotObject.GetPtr(this), index, (int)transformMode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetApplyTransformMode, 3234663511ul);

    /// <summary>
    /// <para>Returns the operation of the remapping destination transform.</para>
    /// </summary>
    public ConvertTransformModifier3D.TransformMode GetApplyTransformMode(int index)
    {
        return (ConvertTransformModifier3D.TransformMode)NativeCalls.godot_icall_1_60(MethodBind1, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetApplyAxis, 776736805ul);

    /// <summary>
    /// <para>Sets the axis of the remapping destination transform.</para>
    /// </summary>
    public void SetApplyAxis(int index, Vector3.Axis axis)
    {
        NativeCalls.godot_icall_2_59(MethodBind2, GodotObject.GetPtr(this), index, (int)axis);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetApplyAxis, 4131134770ul);

    /// <summary>
    /// <para>Returns the axis of the remapping destination transform.</para>
    /// </summary>
    public Vector3.Axis GetApplyAxis(int index)
    {
        return (Vector3.Axis)NativeCalls.godot_icall_1_60(MethodBind3, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetApplyRangeMin, 1602489585ul);

    /// <summary>
    /// <para>Sets the minimum value of the remapping destination range.</para>
    /// </summary>
    public void SetApplyRangeMin(int index, float rangeMin)
    {
        NativeCalls.godot_icall_2_69(MethodBind4, GodotObject.GetPtr(this), index, rangeMin);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetApplyRangeMin, 2339986948ul);

    /// <summary>
    /// <para>Returns the minimum value of the remapping destination range.</para>
    /// </summary>
    public float GetApplyRangeMin(int index)
    {
        return NativeCalls.godot_icall_1_72(MethodBind5, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetApplyRangeMax, 1602489585ul);

    /// <summary>
    /// <para>Sets the maximum value of the remapping destination range.</para>
    /// </summary>
    public void SetApplyRangeMax(int index, float rangeMax)
    {
        NativeCalls.godot_icall_2_69(MethodBind6, GodotObject.GetPtr(this), index, rangeMax);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetApplyRangeMax, 2339986948ul);

    /// <summary>
    /// <para>Returns the maximum value of the remapping destination range.</para>
    /// </summary>
    public float GetApplyRangeMax(int index)
    {
        return NativeCalls.godot_icall_1_72(MethodBind7, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetReferenceTransformMode, 1386463405ul);

    /// <summary>
    /// <para>Sets the operation of the remapping source transform.</para>
    /// </summary>
    public void SetReferenceTransformMode(int index, ConvertTransformModifier3D.TransformMode transformMode)
    {
        NativeCalls.godot_icall_2_59(MethodBind8, GodotObject.GetPtr(this), index, (int)transformMode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetReferenceTransformMode, 3234663511ul);

    /// <summary>
    /// <para>Returns the operation of the remapping source transform.</para>
    /// </summary>
    public ConvertTransformModifier3D.TransformMode GetReferenceTransformMode(int index)
    {
        return (ConvertTransformModifier3D.TransformMode)NativeCalls.godot_icall_1_60(MethodBind9, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetReferenceAxis, 776736805ul);

    /// <summary>
    /// <para>Sets the axis of the remapping source transform.</para>
    /// </summary>
    public void SetReferenceAxis(int index, Vector3.Axis axis)
    {
        NativeCalls.godot_icall_2_59(MethodBind10, GodotObject.GetPtr(this), index, (int)axis);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetReferenceAxis, 4131134770ul);

    /// <summary>
    /// <para>Returns the axis of the remapping source transform.</para>
    /// </summary>
    public Vector3.Axis GetReferenceAxis(int index)
    {
        return (Vector3.Axis)NativeCalls.godot_icall_1_60(MethodBind11, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetReferenceRangeMin, 1602489585ul);

    /// <summary>
    /// <para>Sets the minimum value of the remapping source range.</para>
    /// </summary>
    public void SetReferenceRangeMin(int index, float rangeMin)
    {
        NativeCalls.godot_icall_2_69(MethodBind12, GodotObject.GetPtr(this), index, rangeMin);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetReferenceRangeMin, 2339986948ul);

    /// <summary>
    /// <para>Returns the minimum value of the remapping source range.</para>
    /// </summary>
    public float GetReferenceRangeMin(int index)
    {
        return NativeCalls.godot_icall_1_72(MethodBind13, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetReferenceRangeMax, 1602489585ul);

    /// <summary>
    /// <para>Sets the maximum value of the remapping source range.</para>
    /// </summary>
    public void SetReferenceRangeMax(int index, float rangeMax)
    {
        NativeCalls.godot_icall_2_69(MethodBind14, GodotObject.GetPtr(this), index, rangeMax);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetReferenceRangeMax, 2339986948ul);

    /// <summary>
    /// <para>Returns the maximum value of the remapping source range.</para>
    /// </summary>
    public float GetReferenceRangeMax(int index)
    {
        return NativeCalls.godot_icall_1_72(MethodBind15, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRelative, 300928843ul);

    /// <summary>
    /// <para>Sets relative option in the setting at <paramref name="index"/> to <paramref name="enabled"/>.</para>
    /// <para>If sets <paramref name="enabled"/> to <see langword="true"/>, the extracted and applying transform is relative to the rest.</para>
    /// <para>If sets <paramref name="enabled"/> to <see langword="false"/>, the extracted transform is absolute.</para>
    /// </summary>
    public void SetRelative(int index, bool enabled)
    {
        NativeCalls.godot_icall_2_61(MethodBind16, GodotObject.GetPtr(this), index, enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsRelative, 1116898809ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the relative option is enabled in the setting at <paramref name="index"/>.</para>
    /// </summary>
    public bool IsRelative(int index)
    {
        return NativeCalls.godot_icall_1_62(MethodBind17, GodotObject.GetPtr(this), index).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAdditive, 300928843ul);

    /// <summary>
    /// <para>Sets additive option in the setting at <paramref name="index"/> to <paramref name="enabled"/>. This mainly affects the process of applying transform to the <see cref="Godot.BoneConstraint3D.SetApplyBone(int, int)"/>.</para>
    /// <para>If sets <paramref name="enabled"/> to <see langword="true"/>, the processed transform is added to the pose of the current apply bone.</para>
    /// <para>If sets <paramref name="enabled"/> to <see langword="false"/>, the pose of the current apply bone is replaced with the processed transform. However, if set <see cref="Godot.ConvertTransformModifier3D.SetRelative(int, bool)"/> to <see langword="true"/>, the transform is relative to rest.</para>
    /// </summary>
    public void SetAdditive(int index, bool enabled)
    {
        NativeCalls.godot_icall_2_61(MethodBind18, GodotObject.GetPtr(this), index, enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsAdditive, 1116898809ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the additive option is enabled in the setting at <paramref name="index"/>.</para>
    /// </summary>
    public bool IsAdditive(int index)
    {
        return NativeCalls.godot_icall_1_62(MethodBind19, GodotObject.GetPtr(this), index).ToBool();
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
        /// Cached name for the 'set_apply_transform_mode' method.
        /// </summary>
        public static readonly StringName SetApplyTransformMode = "set_apply_transform_mode";
        /// <summary>
        /// Cached name for the 'get_apply_transform_mode' method.
        /// </summary>
        public static readonly StringName GetApplyTransformMode = "get_apply_transform_mode";
        /// <summary>
        /// Cached name for the 'set_apply_axis' method.
        /// </summary>
        public static readonly StringName SetApplyAxis = "set_apply_axis";
        /// <summary>
        /// Cached name for the 'get_apply_axis' method.
        /// </summary>
        public static readonly StringName GetApplyAxis = "get_apply_axis";
        /// <summary>
        /// Cached name for the 'set_apply_range_min' method.
        /// </summary>
        public static readonly StringName SetApplyRangeMin = "set_apply_range_min";
        /// <summary>
        /// Cached name for the 'get_apply_range_min' method.
        /// </summary>
        public static readonly StringName GetApplyRangeMin = "get_apply_range_min";
        /// <summary>
        /// Cached name for the 'set_apply_range_max' method.
        /// </summary>
        public static readonly StringName SetApplyRangeMax = "set_apply_range_max";
        /// <summary>
        /// Cached name for the 'get_apply_range_max' method.
        /// </summary>
        public static readonly StringName GetApplyRangeMax = "get_apply_range_max";
        /// <summary>
        /// Cached name for the 'set_reference_transform_mode' method.
        /// </summary>
        public static readonly StringName SetReferenceTransformMode = "set_reference_transform_mode";
        /// <summary>
        /// Cached name for the 'get_reference_transform_mode' method.
        /// </summary>
        public static readonly StringName GetReferenceTransformMode = "get_reference_transform_mode";
        /// <summary>
        /// Cached name for the 'set_reference_axis' method.
        /// </summary>
        public static readonly StringName SetReferenceAxis = "set_reference_axis";
        /// <summary>
        /// Cached name for the 'get_reference_axis' method.
        /// </summary>
        public static readonly StringName GetReferenceAxis = "get_reference_axis";
        /// <summary>
        /// Cached name for the 'set_reference_range_min' method.
        /// </summary>
        public static readonly StringName SetReferenceRangeMin = "set_reference_range_min";
        /// <summary>
        /// Cached name for the 'get_reference_range_min' method.
        /// </summary>
        public static readonly StringName GetReferenceRangeMin = "get_reference_range_min";
        /// <summary>
        /// Cached name for the 'set_reference_range_max' method.
        /// </summary>
        public static readonly StringName SetReferenceRangeMax = "set_reference_range_max";
        /// <summary>
        /// Cached name for the 'get_reference_range_max' method.
        /// </summary>
        public static readonly StringName GetReferenceRangeMax = "get_reference_range_max";
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
