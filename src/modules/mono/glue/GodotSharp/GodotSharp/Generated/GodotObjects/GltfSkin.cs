namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
[GodotClassName("GLTFSkin")]
public partial class GltfSkin : Resource
{
    public int SkinRoot
    {
        get
        {
            return GetSkinRoot();
        }
        set
        {
            SetSkinRoot(value);
        }
    }

    public int[] JointsOriginal
    {
        get
        {
            return GetJointsOriginal();
        }
        set
        {
            SetJointsOriginal(value);
        }
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public Godot.Collections.Array<Transform3D> InverseBinds
    {
        get
        {
            return GetInverseBinds();
        }
        set
        {
            SetInverseBinds(value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    public int[] Joints
    {
        get
        {
            return GetJoints();
        }
        set
        {
            SetJoints(value);
        }
    }

    public int[] NonJoints
    {
        get
        {
            return GetNonJoints();
        }
        set
        {
            SetNonJoints(value);
        }
    }

    public int[] Roots
    {
        get
        {
            return GetRoots();
        }
        set
        {
            SetRoots(value);
        }
    }

    public int Skeleton
    {
        get
        {
            return GetSkeleton();
        }
        set
        {
            SetSkeleton(value);
        }
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public Godot.Collections.Dictionary JointIToBoneI
    {
        get
        {
            return GetJointIToBoneI();
        }
        set
        {
            SetJointIToBoneI(value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public Godot.Collections.Dictionary JointIToName
    {
        get
        {
            return GetJointIToName();
        }
        set
        {
            SetJointIToName(value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    public Skin GodotSkin
    {
        get
        {
            return GetGodotSkin();
        }
        set
        {
            SetGodotSkin(value);
        }
    }

    private static readonly System.Type CachedType = typeof(GltfSkin);

    private static readonly StringName NativeName = "GLTFSkin";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public GltfSkin() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal GltfSkin(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal GltfSkin(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSkinRoot, 2455072627ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetSkinRoot()
    {
        return NativeCalls.godot_icall_0_39(MethodBind0, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSkinRoot, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSkinRoot(int skinRoot)
    {
        NativeCalls.godot_icall_1_38(MethodBind1, GodotObject.GetPtr(this), skinRoot);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetJointsOriginal, 969006518ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int[] GetJointsOriginal()
    {
        return NativeCalls.godot_icall_0_151(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetJointsOriginal, 3614634198ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetJointsOriginal(int[] jointsOriginal)
    {
        NativeCalls.godot_icall_1_150(MethodBind3, GodotObject.GetPtr(this), jointsOriginal);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetJointsOriginal(ReadOnlySpan<int> jointsOriginal)
    {
        NativeCalls.godot_icall_1_150(MethodBind3, GodotObject.GetPtr(this), jointsOriginal);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetInverseBinds, 2915620761ul);

    public Godot.Collections.Array<Transform3D> GetInverseBinds()
    {
        return new Godot.Collections.Array<Transform3D>(NativeCalls.godot_icall_0_120(MethodBind4, GodotObject.GetPtr(this)));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetInverseBinds, 381264803ul);

    public void SetInverseBinds(Godot.Collections.Array<Transform3D> inverseBinds)
    {
        NativeCalls.godot_icall_1_138(MethodBind5, GodotObject.GetPtr(this), (godot_array)(inverseBinds ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetJoints, 969006518ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int[] GetJoints()
    {
        return NativeCalls.godot_icall_0_151(MethodBind6, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetJoints, 3614634198ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetJoints(int[] joints)
    {
        NativeCalls.godot_icall_1_150(MethodBind7, GodotObject.GetPtr(this), joints);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetJoints(ReadOnlySpan<int> joints)
    {
        NativeCalls.godot_icall_1_150(MethodBind7, GodotObject.GetPtr(this), joints);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNonJoints, 969006518ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int[] GetNonJoints()
    {
        return NativeCalls.godot_icall_0_151(MethodBind8, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetNonJoints, 3614634198ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetNonJoints(int[] nonJoints)
    {
        NativeCalls.godot_icall_1_150(MethodBind9, GodotObject.GetPtr(this), nonJoints);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetNonJoints(ReadOnlySpan<int> nonJoints)
    {
        NativeCalls.godot_icall_1_150(MethodBind9, GodotObject.GetPtr(this), nonJoints);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRoots, 969006518ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int[] GetRoots()
    {
        return NativeCalls.godot_icall_0_151(MethodBind10, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRoots, 3614634198ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetRoots(int[] roots)
    {
        NativeCalls.godot_icall_1_150(MethodBind11, GodotObject.GetPtr(this), roots);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetRoots(ReadOnlySpan<int> roots)
    {
        NativeCalls.godot_icall_1_150(MethodBind11, GodotObject.GetPtr(this), roots);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSkeleton, 2455072627ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetSkeleton()
    {
        return NativeCalls.godot_icall_0_39(MethodBind12, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSkeleton, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSkeleton(int skeleton)
    {
        NativeCalls.godot_icall_1_38(MethodBind13, GodotObject.GetPtr(this), skeleton);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetJointIToBoneI, 2382534195ul);

    public Godot.Collections.Dictionary GetJointIToBoneI()
    {
        return NativeCalls.godot_icall_0_122(MethodBind14, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetJointIToBoneI, 4155329257ul);

    public void SetJointIToBoneI(Godot.Collections.Dictionary jointIToBoneI)
    {
        NativeCalls.godot_icall_1_121(MethodBind15, GodotObject.GetPtr(this), (godot_dictionary)(jointIToBoneI ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetJointIToName, 2382534195ul);

    public Godot.Collections.Dictionary GetJointIToName()
    {
        return NativeCalls.godot_icall_0_122(MethodBind16, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetJointIToName, 4155329257ul);

    public void SetJointIToName(Godot.Collections.Dictionary jointIToName)
    {
        NativeCalls.godot_icall_1_121(MethodBind17, GodotObject.GetPtr(this), (godot_dictionary)(jointIToName ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetGodotSkin, 1032037385ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Skin GetGodotSkin()
    {
        return (Skin)NativeCalls.godot_icall_0_63(MethodBind18, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetGodotSkin, 3971435618ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetGodotSkin(Skin godotSkin)
    {
        NativeCalls.godot_icall_1_56(MethodBind19, GodotObject.GetPtr(this), GodotObject.GetPtr(godotSkin));
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
    public new class PropertyName : Resource.PropertyName
    {
        /// <summary>
        /// Cached name for the 'skin_root' property.
        /// </summary>
        public static readonly StringName SkinRoot = "skin_root";
        /// <summary>
        /// Cached name for the 'joints_original' property.
        /// </summary>
        public static readonly StringName JointsOriginal = "joints_original";
        /// <summary>
        /// Cached name for the 'inverse_binds' property.
        /// </summary>
        public static readonly StringName InverseBinds = "inverse_binds";
        /// <summary>
        /// Cached name for the 'joints' property.
        /// </summary>
        public static readonly StringName Joints = "joints";
        /// <summary>
        /// Cached name for the 'non_joints' property.
        /// </summary>
        public static readonly StringName NonJoints = "non_joints";
        /// <summary>
        /// Cached name for the 'roots' property.
        /// </summary>
        public static readonly StringName Roots = "roots";
        /// <summary>
        /// Cached name for the 'skeleton' property.
        /// </summary>
        public static readonly StringName Skeleton = "skeleton";
        /// <summary>
        /// Cached name for the 'joint_i_to_bone_i' property.
        /// </summary>
        public static readonly StringName JointIToBoneI = "joint_i_to_bone_i";
        /// <summary>
        /// Cached name for the 'joint_i_to_name' property.
        /// </summary>
        public static readonly StringName JointIToName = "joint_i_to_name";
        /// <summary>
        /// Cached name for the 'godot_skin' property.
        /// </summary>
        public static readonly StringName GodotSkin = "godot_skin";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Resource.MethodName
    {
        /// <summary>
        /// Cached name for the 'get_skin_root' method.
        /// </summary>
        public static readonly StringName GetSkinRoot = "get_skin_root";
        /// <summary>
        /// Cached name for the 'set_skin_root' method.
        /// </summary>
        public static readonly StringName SetSkinRoot = "set_skin_root";
        /// <summary>
        /// Cached name for the 'get_joints_original' method.
        /// </summary>
        public static readonly StringName GetJointsOriginal = "get_joints_original";
        /// <summary>
        /// Cached name for the 'set_joints_original' method.
        /// </summary>
        public static readonly StringName SetJointsOriginal = "set_joints_original";
        /// <summary>
        /// Cached name for the 'get_inverse_binds' method.
        /// </summary>
        public static readonly StringName GetInverseBinds = "get_inverse_binds";
        /// <summary>
        /// Cached name for the 'set_inverse_binds' method.
        /// </summary>
        public static readonly StringName SetInverseBinds = "set_inverse_binds";
        /// <summary>
        /// Cached name for the 'get_joints' method.
        /// </summary>
        public static readonly StringName GetJoints = "get_joints";
        /// <summary>
        /// Cached name for the 'set_joints' method.
        /// </summary>
        public static readonly StringName SetJoints = "set_joints";
        /// <summary>
        /// Cached name for the 'get_non_joints' method.
        /// </summary>
        public static readonly StringName GetNonJoints = "get_non_joints";
        /// <summary>
        /// Cached name for the 'set_non_joints' method.
        /// </summary>
        public static readonly StringName SetNonJoints = "set_non_joints";
        /// <summary>
        /// Cached name for the 'get_roots' method.
        /// </summary>
        public static readonly StringName GetRoots = "get_roots";
        /// <summary>
        /// Cached name for the 'set_roots' method.
        /// </summary>
        public static readonly StringName SetRoots = "set_roots";
        /// <summary>
        /// Cached name for the 'get_skeleton' method.
        /// </summary>
        public static readonly StringName GetSkeleton = "get_skeleton";
        /// <summary>
        /// Cached name for the 'set_skeleton' method.
        /// </summary>
        public static readonly StringName SetSkeleton = "set_skeleton";
        /// <summary>
        /// Cached name for the 'get_joint_i_to_bone_i' method.
        /// </summary>
        public static readonly StringName GetJointIToBoneI = "get_joint_i_to_bone_i";
        /// <summary>
        /// Cached name for the 'set_joint_i_to_bone_i' method.
        /// </summary>
        public static readonly StringName SetJointIToBoneI = "set_joint_i_to_bone_i";
        /// <summary>
        /// Cached name for the 'get_joint_i_to_name' method.
        /// </summary>
        public static readonly StringName GetJointIToName = "get_joint_i_to_name";
        /// <summary>
        /// Cached name for the 'set_joint_i_to_name' method.
        /// </summary>
        public static readonly StringName SetJointIToName = "set_joint_i_to_name";
        /// <summary>
        /// Cached name for the 'get_godot_skin' method.
        /// </summary>
        public static readonly StringName GetGodotSkin = "get_godot_skin";
        /// <summary>
        /// Cached name for the 'set_godot_skin' method.
        /// </summary>
        public static readonly StringName SetGodotSkin = "set_godot_skin";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Resource.SignalName
    {
    }
}
