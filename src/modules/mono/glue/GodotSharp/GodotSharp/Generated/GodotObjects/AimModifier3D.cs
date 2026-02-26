namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This is a simple version of <see cref="Godot.LookAtModifier3D"/> that only allows bone to the reference without advanced options such as angle limitation or time-based interpolation.</para>
/// <para>The feature is simplified, but instead it is implemented with smooth tracking without euler, see <see cref="Godot.AimModifier3D.SetUseEuler(int, bool)"/>.</para>
/// </summary>
public partial class AimModifier3D : BoneConstraint3D
{
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

    private static readonly System.Type CachedType = typeof(AimModifier3D);

    private static readonly StringName NativeName = "AimModifier3D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public AimModifier3D() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal AimModifier3D(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal AimModifier3D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetForwardAxis, 2496831085ul);

    /// <summary>
    /// <para>Sets the forward axis of the bone.</para>
    /// </summary>
    public void SetForwardAxis(int index, SkeletonModifier3D.BoneAxis axis)
    {
        NativeCalls.godot_icall_2_59(MethodBind0, GodotObject.GetPtr(this), index, (int)axis);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetForwardAxis, 3949866735ul);

    /// <summary>
    /// <para>Returns the forward axis of the bone.</para>
    /// </summary>
    public SkeletonModifier3D.BoneAxis GetForwardAxis(int index)
    {
        return (SkeletonModifier3D.BoneAxis)NativeCalls.godot_icall_1_60(MethodBind1, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetUseEuler, 300928843ul);

    /// <summary>
    /// <para>If sets <paramref name="enabled"/> to <see langword="true"/>, it provides rotation with using euler.</para>
    /// <para>If sets <paramref name="enabled"/> to <see langword="false"/>, it provides rotation with using rotation by arc generated from the forward axis vector and the vector toward the reference.</para>
    /// </summary>
    public void SetUseEuler(int index, bool enabled)
    {
        NativeCalls.godot_icall_2_61(MethodBind2, GodotObject.GetPtr(this), index, enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsUsingEuler, 1116898809ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if it provides rotation with using euler.</para>
    /// </summary>
    public bool IsUsingEuler(int index)
    {
        return NativeCalls.godot_icall_1_62(MethodBind3, GodotObject.GetPtr(this), index).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPrimaryRotationAxis, 776736805ul);

    /// <summary>
    /// <para>Sets the axis of the first rotation. It is enabled only if <see cref="Godot.AimModifier3D.IsUsingEuler(int)"/> is <see langword="true"/>.</para>
    /// </summary>
    public void SetPrimaryRotationAxis(int index, Vector3.Axis axis)
    {
        NativeCalls.godot_icall_2_59(MethodBind4, GodotObject.GetPtr(this), index, (int)axis);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPrimaryRotationAxis, 4131134770ul);

    /// <summary>
    /// <para>Returns the axis of the first rotation. It is enabled only if <see cref="Godot.AimModifier3D.IsUsingEuler(int)"/> is <see langword="true"/>.</para>
    /// </summary>
    public Vector3.Axis GetPrimaryRotationAxis(int index)
    {
        return (Vector3.Axis)NativeCalls.godot_icall_1_60(MethodBind5, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetUseSecondaryRotation, 300928843ul);

    /// <summary>
    /// <para>If sets <paramref name="enabled"/> to <see langword="true"/>, it provides rotation by two axes. It is enabled only if <see cref="Godot.AimModifier3D.IsUsingEuler(int)"/> is <see langword="true"/>.</para>
    /// </summary>
    public void SetUseSecondaryRotation(int index, bool enabled)
    {
        NativeCalls.godot_icall_2_61(MethodBind6, GodotObject.GetPtr(this), index, enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsUsingSecondaryRotation, 1116898809ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if it provides rotation by two axes. It is enabled only if <see cref="Godot.AimModifier3D.IsUsingEuler(int)"/> is <see langword="true"/>.</para>
    /// </summary>
    public bool IsUsingSecondaryRotation(int index)
    {
        return NativeCalls.godot_icall_1_62(MethodBind7, GodotObject.GetPtr(this), index).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRelative, 300928843ul);

    /// <summary>
    /// <para>Sets relative option in the setting at <paramref name="index"/> to <paramref name="enabled"/>.</para>
    /// <para>If sets <paramref name="enabled"/> to <see langword="true"/>, the rotation is applied relative to the pose.</para>
    /// <para>If sets <paramref name="enabled"/> to <see langword="false"/>, the rotation is applied relative to the rest. It means to replace the current pose with the <see cref="Godot.AimModifier3D"/>'s result.</para>
    /// </summary>
    public void SetRelative(int index, bool enabled)
    {
        NativeCalls.godot_icall_2_61(MethodBind8, GodotObject.GetPtr(this), index, enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsRelative, 1116898809ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the relative option is enabled in the setting at <paramref name="index"/>.</para>
    /// </summary>
    public bool IsRelative(int index)
    {
        return NativeCalls.godot_icall_1_62(MethodBind9, GodotObject.GetPtr(this), index).ToBool();
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
        /// Cached name for the 'set_forward_axis' method.
        /// </summary>
        public static readonly StringName SetForwardAxis = "set_forward_axis";
        /// <summary>
        /// Cached name for the 'get_forward_axis' method.
        /// </summary>
        public static readonly StringName GetForwardAxis = "get_forward_axis";
        /// <summary>
        /// Cached name for the 'set_use_euler' method.
        /// </summary>
        public static readonly StringName SetUseEuler = "set_use_euler";
        /// <summary>
        /// Cached name for the 'is_using_euler' method.
        /// </summary>
        public static readonly StringName IsUsingEuler = "is_using_euler";
        /// <summary>
        /// Cached name for the 'set_primary_rotation_axis' method.
        /// </summary>
        public static readonly StringName SetPrimaryRotationAxis = "set_primary_rotation_axis";
        /// <summary>
        /// Cached name for the 'get_primary_rotation_axis' method.
        /// </summary>
        public static readonly StringName GetPrimaryRotationAxis = "get_primary_rotation_axis";
        /// <summary>
        /// Cached name for the 'set_use_secondary_rotation' method.
        /// </summary>
        public static readonly StringName SetUseSecondaryRotation = "set_use_secondary_rotation";
        /// <summary>
        /// Cached name for the 'is_using_secondary_rotation' method.
        /// </summary>
        public static readonly StringName IsUsingSecondaryRotation = "is_using_secondary_rotation";
        /// <summary>
        /// Cached name for the 'set_relative' method.
        /// </summary>
        public static readonly StringName SetRelative = "set_relative";
        /// <summary>
        /// Cached name for the 'is_relative' method.
        /// </summary>
        public static readonly StringName IsRelative = "is_relative";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : BoneConstraint3D.SignalName
    {
    }
}
