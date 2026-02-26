namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Base class of <see cref="Godot.SkeletonModifier3D"/>s that has some joint lists and applies inverse kinematics. This class has some structs, enums, and helper methods which are useful to solve inverse kinematics.</para>
/// </summary>
public partial class IKModifier3D : SkeletonModifier3D
{
    /// <summary>
    /// <para>If <see langword="true"/>, the solver retrieves the bone axis from the bone pose every frame.</para>
    /// <para>If <see langword="false"/>, the solver retrieves the bone axis from the bone rest and caches it, which increases performance slightly, but position changes in the bone pose made before processing this <see cref="Godot.IKModifier3D"/> are ignored.</para>
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

    private static readonly System.Type CachedType = typeof(IKModifier3D);

    private static readonly StringName NativeName = "IKModifier3D";

    internal IKModifier3D() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal IKModifier3D(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal IKModifier3D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSettingCount, 1286410249ul);

    /// <summary>
    /// <para>Sets the number of settings.</para>
    /// </summary>
    public void SetSettingCount(int count)
    {
        NativeCalls.godot_icall_1_38(MethodBind0, GodotObject.GetPtr(this), count);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSettingCount, 3905245786ul);

    /// <summary>
    /// <para>Returns the number of settings.</para>
    /// </summary>
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
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Reset, 3218959716ul);

    /// <summary>
    /// <para>Resets a state with respect to the current bone pose.</para>
    /// </summary>
    public void Reset()
    {
        NativeCalls.godot_icall_0_3(MethodBind5, GodotObject.GetPtr(this));
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
        /// Cached name for the 'reset' method.
        /// </summary>
        public static readonly StringName Reset = "reset";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : SkeletonModifier3D.SignalName
    {
    }
}
