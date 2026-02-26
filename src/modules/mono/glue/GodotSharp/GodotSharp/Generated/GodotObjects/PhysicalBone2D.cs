namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>The <see cref="Godot.PhysicalBone2D"/> node is a <see cref="Godot.RigidBody2D"/>-based node that can be used to make <see cref="Godot.Bone2D"/>s in a <see cref="Godot.Skeleton2D"/> react to physics.</para>
/// <para><b>Note:</b> To make the <see cref="Godot.Bone2D"/>s visually follow the <see cref="Godot.PhysicalBone2D"/> node, use a <see cref="Godot.SkeletonModification2DPhysicalBones"/> modification on the <see cref="Godot.Skeleton2D"/> parent.</para>
/// <para><b>Note:</b> The <see cref="Godot.PhysicalBone2D"/> node does not automatically create a <see cref="Godot.Joint2D"/> node to keep <see cref="Godot.PhysicalBone2D"/> nodes together. They must be created manually. For most cases, you want to use a <see cref="Godot.PinJoint2D"/> node. The <see cref="Godot.PhysicalBone2D"/> node will automatically configure the <see cref="Godot.Joint2D"/> node once it's been added as a child node.</para>
/// </summary>
public partial class PhysicalBone2D : RigidBody2D
{
    /// <summary>
    /// <para>The <see cref="Godot.NodePath"/> to the <see cref="Godot.Bone2D"/> that this <see cref="Godot.PhysicalBone2D"/> should simulate.</para>
    /// </summary>
    public NodePath Bone2DNodePath
    {
        get
        {
            return GetBone2DNodePath();
        }
        set
        {
            SetBone2DNodePath(value);
        }
    }

    /// <summary>
    /// <para>The index of the <see cref="Godot.Bone2D"/> that this <see cref="Godot.PhysicalBone2D"/> should simulate.</para>
    /// </summary>
    public int Bone2DIndex
    {
        get
        {
            return GetBone2DIndex();
        }
        set
        {
            SetBone2DIndex(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the <see cref="Godot.PhysicalBone2D"/> will automatically configure the first <see cref="Godot.Joint2D"/> child node. The automatic configuration is limited to setting up the node properties and positioning the <see cref="Godot.Joint2D"/>.</para>
    /// </summary>
    public bool AutoConfigureJoint
    {
        get
        {
            return GetAutoConfigureJoint();
        }
        set
        {
            SetAutoConfigureJoint(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the <see cref="Godot.PhysicalBone2D"/> will start simulating using physics. If <see langword="false"/>, the <see cref="Godot.PhysicalBone2D"/> will follow the transform of the <see cref="Godot.Bone2D"/> node.</para>
    /// <para><b>Note:</b> To have the <see cref="Godot.Bone2D"/>s visually follow the <see cref="Godot.PhysicalBone2D"/>, use a <see cref="Godot.SkeletonModification2DPhysicalBones"/> modification on the <see cref="Godot.Skeleton2D"/> node with the <see cref="Godot.Bone2D"/> nodes.</para>
    /// </summary>
    public bool SimulatePhysics
    {
        get
        {
            return GetSimulatePhysics();
        }
        set
        {
            SetSimulatePhysics(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the <see cref="Godot.PhysicalBone2D"/> will keep the transform of the bone it is bound to when simulating physics.</para>
    /// </summary>
    public bool FollowBoneWhenSimulating
    {
        get
        {
            return GetFollowBoneWhenSimulating();
        }
        set
        {
            SetFollowBoneWhenSimulating(value);
        }
    }

    private static readonly System.Type CachedType = typeof(PhysicalBone2D);

    private static readonly StringName NativeName = "PhysicalBone2D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public PhysicalBone2D() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal PhysicalBone2D(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal PhysicalBone2D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetJoint, 3582132112ul);

    /// <summary>
    /// <para>Returns the first <see cref="Godot.Joint2D"/> child node, if one exists. This is mainly a helper function to make it easier to get the <see cref="Godot.Joint2D"/> that the <see cref="Godot.PhysicalBone2D"/> is autoconfiguring.</para>
    /// </summary>
    public Joint2D GetJoint()
    {
        return (Joint2D)NativeCalls.godot_icall_0_53(MethodBind0, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAutoConfigureJoint, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetAutoConfigureJoint()
    {
        return NativeCalls.godot_icall_0_15(MethodBind1, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAutoConfigureJoint, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAutoConfigureJoint(bool autoConfigureJoint)
    {
        NativeCalls.godot_icall_1_14(MethodBind2, GodotObject.GetPtr(this), autoConfigureJoint.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSimulatePhysics, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSimulatePhysics(bool simulatePhysics)
    {
        NativeCalls.godot_icall_1_14(MethodBind3, GodotObject.GetPtr(this), simulatePhysics.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSimulatePhysics, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetSimulatePhysics()
    {
        return NativeCalls.godot_icall_0_15(MethodBind4, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsSimulatingPhysics, 36873697ul);

    /// <summary>
    /// <para>Returns a boolean that indicates whether the <see cref="Godot.PhysicalBone2D"/> is running and simulating using the Godot 2D physics engine. When <see langword="true"/>, the PhysicalBone2D node is using physics.</para>
    /// </summary>
    public bool IsSimulatingPhysics()
    {
        return NativeCalls.godot_icall_0_15(MethodBind5, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBone2DNodePath, 1348162250ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetBone2DNodePath(NodePath nodePath)
    {
        NativeCalls.godot_icall_1_123(MethodBind6, GodotObject.GetPtr(this), (godot_node_path)(nodePath?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBone2DNodePath, 4075236667ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public NodePath GetBone2DNodePath()
    {
        return NativeCalls.godot_icall_0_124(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBone2DIndex, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetBone2DIndex(int boneIndex)
    {
        NativeCalls.godot_icall_1_38(MethodBind8, GodotObject.GetPtr(this), boneIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBone2DIndex, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetBone2DIndex()
    {
        return NativeCalls.godot_icall_0_39(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFollowBoneWhenSimulating, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFollowBoneWhenSimulating(bool followBone)
    {
        NativeCalls.godot_icall_1_14(MethodBind10, GodotObject.GetPtr(this), followBone.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFollowBoneWhenSimulating, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetFollowBoneWhenSimulating()
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
    public new class PropertyName : RigidBody2D.PropertyName
    {
        /// <summary>
        /// Cached name for the 'bone2d_nodepath' property.
        /// </summary>
        public static readonly StringName Bone2DNodePath = "bone2d_nodepath";
        /// <summary>
        /// Cached name for the 'bone2d_index' property.
        /// </summary>
        public static readonly StringName Bone2DIndex = "bone2d_index";
        /// <summary>
        /// Cached name for the 'auto_configure_joint' property.
        /// </summary>
        public static readonly StringName AutoConfigureJoint = "auto_configure_joint";
        /// <summary>
        /// Cached name for the 'simulate_physics' property.
        /// </summary>
        public static readonly StringName SimulatePhysics = "simulate_physics";
        /// <summary>
        /// Cached name for the 'follow_bone_when_simulating' property.
        /// </summary>
        public static readonly StringName FollowBoneWhenSimulating = "follow_bone_when_simulating";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : RigidBody2D.MethodName
    {
        /// <summary>
        /// Cached name for the 'get_joint' method.
        /// </summary>
        public static readonly StringName GetJoint = "get_joint";
        /// <summary>
        /// Cached name for the 'get_auto_configure_joint' method.
        /// </summary>
        public static readonly StringName GetAutoConfigureJoint = "get_auto_configure_joint";
        /// <summary>
        /// Cached name for the 'set_auto_configure_joint' method.
        /// </summary>
        public static readonly StringName SetAutoConfigureJoint = "set_auto_configure_joint";
        /// <summary>
        /// Cached name for the 'set_simulate_physics' method.
        /// </summary>
        public static readonly StringName SetSimulatePhysics = "set_simulate_physics";
        /// <summary>
        /// Cached name for the 'get_simulate_physics' method.
        /// </summary>
        public static readonly StringName GetSimulatePhysics = "get_simulate_physics";
        /// <summary>
        /// Cached name for the 'is_simulating_physics' method.
        /// </summary>
        public static readonly StringName IsSimulatingPhysics = "is_simulating_physics";
        /// <summary>
        /// Cached name for the 'set_bone2d_nodepath' method.
        /// </summary>
        public static readonly StringName SetBone2DNodePath = "set_bone2d_nodepath";
        /// <summary>
        /// Cached name for the 'get_bone2d_nodepath' method.
        /// </summary>
        public static readonly StringName GetBone2DNodePath = "get_bone2d_nodepath";
        /// <summary>
        /// Cached name for the 'set_bone2d_index' method.
        /// </summary>
        public static readonly StringName SetBone2DIndex = "set_bone2d_index";
        /// <summary>
        /// Cached name for the 'get_bone2d_index' method.
        /// </summary>
        public static readonly StringName GetBone2DIndex = "get_bone2d_index";
        /// <summary>
        /// Cached name for the 'set_follow_bone_when_simulating' method.
        /// </summary>
        public static readonly StringName SetFollowBoneWhenSimulating = "set_follow_bone_when_simulating";
        /// <summary>
        /// Cached name for the 'get_follow_bone_when_simulating' method.
        /// </summary>
        public static readonly StringName GetFollowBoneWhenSimulating = "get_follow_bone_when_simulating";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : RigidBody2D.SignalName
    {
    }
}
