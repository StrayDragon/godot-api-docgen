namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Retrieves the pose (or global pose) relative to the parent Skeleton's rest in model space and transfers it to the child Skeleton.</para>
/// <para>This modifier rewrites the pose of the child skeleton directly in the parent skeleton's update process. This means that it overwrites the mapped bone pose set in the normal process on the target skeleton. If you want to set the target skeleton bone pose after retargeting, you will need to add a <see cref="Godot.SkeletonModifier3D"/> child to the target skeleton and thereby modify the pose.</para>
/// <para><b>Note:</b> When the <see cref="Godot.RetargetModifier3D.UseGlobalPose"/> is enabled, even if it is an unmapped bone, it can cause visual problems because the global pose is applied ignoring the parent bone's pose <b>if it has mapped bone children</b>. See also <see cref="Godot.RetargetModifier3D.UseGlobalPose"/>.</para>
/// </summary>
public partial class RetargetModifier3D : SkeletonModifier3D
{
    [System.Flags]
    public enum TransformFlag : long
    {
        /// <summary>
        /// <para>If set, allows to retarget the position.</para>
        /// </summary>
        Position = 1,
        /// <summary>
        /// <para>If set, allows to retarget the rotation.</para>
        /// </summary>
        Rotation = 2,
        /// <summary>
        /// <para>If set, allows to retarget the scale.</para>
        /// </summary>
        Scale = 4,
        /// <summary>
        /// <para>If set, allows to retarget the position/rotation/scale.</para>
        /// </summary>
        All = 7
    }

    /// <summary>
    /// <para><see cref="Godot.SkeletonProfile"/> for retargeting bones with names matching the bone list.</para>
    /// </summary>
    public SkeletonProfile Profile
    {
        get
        {
            return GetProfile();
        }
        set
        {
            SetProfile(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="false"/>, in case the target skeleton has fewer bones than the source skeleton, the source bone parent's transform will be ignored.</para>
    /// <para>Instead, it is possible to retarget between models with different body shapes, and position, rotation, and scale can be retargeted separately.</para>
    /// <para>If <see langword="true"/>, retargeting is performed taking into account global pose.</para>
    /// <para>In case the target skeleton has fewer bones than the source skeleton, the source bone parent's transform is taken into account. However, bone length between skeletons must match exactly, if not, the bones will be forced to expand or shrink.</para>
    /// <para>This is useful for using dummy bone with length <c>0</c> to match postures when retargeting between models with different number of bones.</para>
    /// </summary>
    public bool UseGlobalPose
    {
        get
        {
            return IsUsingGlobalPose();
        }
        set
        {
            SetUseGlobalPose(value);
        }
    }

    /// <summary>
    /// <para>Flags to control the process of the transform elements individually when <see cref="Godot.RetargetModifier3D.UseGlobalPose"/> is disabled.</para>
    /// </summary>
    public RetargetModifier3D.TransformFlag Enable
    {
        get
        {
            return GetEnableFlags();
        }
        set
        {
            SetEnableFlags(value);
        }
    }

    private static readonly System.Type CachedType = typeof(RetargetModifier3D);

    private static readonly StringName NativeName = "RetargetModifier3D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public RetargetModifier3D() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal RetargetModifier3D(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal RetargetModifier3D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetProfile, 3870374136ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetProfile(SkeletonProfile profile)
    {
        NativeCalls.godot_icall_1_56(MethodBind0, GodotObject.GetPtr(this), GodotObject.GetPtr(profile));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetProfile, 4291782652ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public SkeletonProfile GetProfile()
    {
        return (SkeletonProfile)NativeCalls.godot_icall_0_63(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetUseGlobalPose, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetUseGlobalPose(bool useGlobalPose)
    {
        NativeCalls.godot_icall_1_14(MethodBind2, GodotObject.GetPtr(this), useGlobalPose.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsUsingGlobalPose, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsUsingGlobalPose()
    {
        return NativeCalls.godot_icall_0_15(MethodBind3, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEnableFlags, 2687954213ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEnableFlags(RetargetModifier3D.TransformFlag enableFlags)
    {
        NativeCalls.godot_icall_1_38(MethodBind4, GodotObject.GetPtr(this), (int)enableFlags);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEnableFlags, 358995420ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public RetargetModifier3D.TransformFlag GetEnableFlags()
    {
        return (RetargetModifier3D.TransformFlag)NativeCalls.godot_icall_0_39(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPositionEnabled, 2586408642ul);

    /// <summary>
    /// <para>Sets <see cref="Godot.RetargetModifier3D.TransformFlag.Position"/> into <see cref="Godot.RetargetModifier3D.Enable"/>.</para>
    /// </summary>
    public void SetPositionEnabled(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind6, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsPositionEnabled, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if <see cref="Godot.RetargetModifier3D.Enable"/> has <see cref="Godot.RetargetModifier3D.TransformFlag.Position"/>.</para>
    /// </summary>
    public bool IsPositionEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind7, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRotationEnabled, 2586408642ul);

    /// <summary>
    /// <para>Sets <see cref="Godot.RetargetModifier3D.TransformFlag.Rotation"/> into <see cref="Godot.RetargetModifier3D.Enable"/>.</para>
    /// </summary>
    public void SetRotationEnabled(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind8, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsRotationEnabled, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if <see cref="Godot.RetargetModifier3D.Enable"/> has <see cref="Godot.RetargetModifier3D.TransformFlag.Rotation"/>.</para>
    /// </summary>
    public bool IsRotationEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind9, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetScaleEnabled, 2586408642ul);

    /// <summary>
    /// <para>Sets <see cref="Godot.RetargetModifier3D.TransformFlag.Scale"/> into <see cref="Godot.RetargetModifier3D.Enable"/>.</para>
    /// </summary>
    public void SetScaleEnabled(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind10, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsScaleEnabled, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if <see cref="Godot.RetargetModifier3D.Enable"/> has <see cref="Godot.RetargetModifier3D.TransformFlag.Scale"/>.</para>
    /// </summary>
    public bool IsScaleEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind11, GodotObject.GetPtr(this)).ToBool();
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
        /// Cached name for the 'profile' property.
        /// </summary>
        public static readonly StringName Profile = "profile";
        /// <summary>
        /// Cached name for the 'use_global_pose' property.
        /// </summary>
        public static readonly StringName UseGlobalPose = "use_global_pose";
        /// <summary>
        /// Cached name for the 'enable' property.
        /// </summary>
        public static readonly StringName Enable = "enable";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : SkeletonModifier3D.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_profile' method.
        /// </summary>
        public static readonly StringName SetProfile = "set_profile";
        /// <summary>
        /// Cached name for the 'get_profile' method.
        /// </summary>
        public static readonly StringName GetProfile = "get_profile";
        /// <summary>
        /// Cached name for the 'set_use_global_pose' method.
        /// </summary>
        public static readonly StringName SetUseGlobalPose = "set_use_global_pose";
        /// <summary>
        /// Cached name for the 'is_using_global_pose' method.
        /// </summary>
        public static readonly StringName IsUsingGlobalPose = "is_using_global_pose";
        /// <summary>
        /// Cached name for the 'set_enable_flags' method.
        /// </summary>
        public static readonly StringName SetEnableFlags = "set_enable_flags";
        /// <summary>
        /// Cached name for the 'get_enable_flags' method.
        /// </summary>
        public static readonly StringName GetEnableFlags = "get_enable_flags";
        /// <summary>
        /// Cached name for the 'set_position_enabled' method.
        /// </summary>
        public static readonly StringName SetPositionEnabled = "set_position_enabled";
        /// <summary>
        /// Cached name for the 'is_position_enabled' method.
        /// </summary>
        public static readonly StringName IsPositionEnabled = "is_position_enabled";
        /// <summary>
        /// Cached name for the 'set_rotation_enabled' method.
        /// </summary>
        public static readonly StringName SetRotationEnabled = "set_rotation_enabled";
        /// <summary>
        /// Cached name for the 'is_rotation_enabled' method.
        /// </summary>
        public static readonly StringName IsRotationEnabled = "is_rotation_enabled";
        /// <summary>
        /// Cached name for the 'set_scale_enabled' method.
        /// </summary>
        public static readonly StringName SetScaleEnabled = "set_scale_enabled";
        /// <summary>
        /// Cached name for the 'is_scale_enabled' method.
        /// </summary>
        public static readonly StringName IsScaleEnabled = "is_scale_enabled";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : SkeletonModifier3D.SignalName
    {
    }
}
