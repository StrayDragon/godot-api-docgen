namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This modifier limits bone rotation angular velocity by comparing poses between previous and current frame.</para>
/// <para>You can add bone chains by specifying their root and end bones, then add the bones between them to a list. Modifier processes either that list or the bones excluding those in the list depending on the option <see cref="Godot.LimitAngularVelocityModifier3D.Exclude"/>.</para>
/// </summary>
public partial class LimitAngularVelocityModifier3D : SkeletonModifier3D
{
    /// <summary>
    /// <para>The maximum angular velocity per second.</para>
    /// </summary>
    public double MaxAngularVelocity
    {
        get
        {
            return GetMaxAngularVelocity();
        }
        set
        {
            SetMaxAngularVelocity(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the modifier processes bones not included in the bone list.</para>
    /// <para>If <see langword="false"/>, the bones processed by the modifier are equal to the bone list.</para>
    /// </summary>
    public bool Exclude
    {
        get
        {
            return IsExclude();
        }
        set
        {
            SetExclude(value);
        }
    }

    /// <summary>
    /// <para>The number of chains.</para>
    /// </summary>
    public int ChainCount
    {
        get
        {
            return GetChainCount();
        }
        set
        {
            SetChainCount(value);
        }
    }

    /// <summary>
    /// <para>The number of joints in the list which created by chains dynamically.</para>
    /// </summary>
    public int JointCount
    {
        get
        {
            return _GetJointCount();
        }
    }

    private static readonly System.Type CachedType = typeof(LimitAngularVelocityModifier3D);

    private static readonly StringName NativeName = "LimitAngularVelocityModifier3D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public LimitAngularVelocityModifier3D() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal LimitAngularVelocityModifier3D(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal LimitAngularVelocityModifier3D(bool memoryOwn) : base(memoryOwn) { }

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
    /// <para><b>Note:</b> End bone must be the root bone or a child of the root bone.</para>
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
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetChainCount, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetChainCount(int count)
    {
        NativeCalls.godot_icall_1_38(MethodBind8, GodotObject.GetPtr(this), count);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetChainCount, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetChainCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ClearChains, 3218959716ul);

    /// <summary>
    /// <para>Clear all chains.</para>
    /// </summary>
    public void ClearChains()
    {
        NativeCalls.godot_icall_0_3(MethodBind10, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMaxAngularVelocity, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMaxAngularVelocity(double angularVelocity)
    {
        NativeCalls.godot_icall_1_127(MethodBind11, GodotObject.GetPtr(this), angularVelocity);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMaxAngularVelocity, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public double GetMaxAngularVelocity()
    {
        return NativeCalls.godot_icall_0_144(MethodBind12, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetExclude, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetExclude(bool exclude)
    {
        NativeCalls.godot_icall_1_14(MethodBind13, GodotObject.GetPtr(this), exclude.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsExclude, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsExclude()
    {
        return NativeCalls.godot_icall_0_15(MethodBind14, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Reset, 3218959716ul);

    /// <summary>
    /// <para>Sets the reference pose for angle comparison to the current pose with the influence of constraints removed. This function is automatically triggered when joints change or upon activation.</para>
    /// </summary>
    public void Reset()
    {
        NativeCalls.godot_icall_0_3(MethodBind15, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName._GetJointCount, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    internal int _GetJointCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind16, GodotObject.GetPtr(this));
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
        /// Cached name for the 'max_angular_velocity' property.
        /// </summary>
        public static readonly StringName MaxAngularVelocity = "max_angular_velocity";
        /// <summary>
        /// Cached name for the 'exclude' property.
        /// </summary>
        public static readonly StringName Exclude = "exclude";
        /// <summary>
        /// Cached name for the 'chain_count' property.
        /// </summary>
        public static readonly StringName ChainCount = "chain_count";
        /// <summary>
        /// Cached name for the 'joint_count' property.
        /// </summary>
        public static readonly StringName JointCount = "joint_count";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : SkeletonModifier3D.MethodName
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
        /// Cached name for the 'set_chain_count' method.
        /// </summary>
        public static readonly StringName SetChainCount = "set_chain_count";
        /// <summary>
        /// Cached name for the 'get_chain_count' method.
        /// </summary>
        public static readonly StringName GetChainCount = "get_chain_count";
        /// <summary>
        /// Cached name for the 'clear_chains' method.
        /// </summary>
        public static readonly StringName ClearChains = "clear_chains";
        /// <summary>
        /// Cached name for the 'set_max_angular_velocity' method.
        /// </summary>
        public static readonly StringName SetMaxAngularVelocity = "set_max_angular_velocity";
        /// <summary>
        /// Cached name for the 'get_max_angular_velocity' method.
        /// </summary>
        public static readonly StringName GetMaxAngularVelocity = "get_max_angular_velocity";
        /// <summary>
        /// Cached name for the 'set_exclude' method.
        /// </summary>
        public static readonly StringName SetExclude = "set_exclude";
        /// <summary>
        /// Cached name for the 'is_exclude' method.
        /// </summary>
        public static readonly StringName IsExclude = "is_exclude";
        /// <summary>
        /// Cached name for the 'reset' method.
        /// </summary>
        public static readonly StringName Reset = "reset";
        /// <summary>
        /// Cached name for the '_get_joint_count' method.
        /// </summary>
        public static readonly StringName _GetJointCount = "_get_joint_count";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : SkeletonModifier3D.SignalName
    {
    }
}
