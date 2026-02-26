namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This modification moves a series of bones, typically called a bone chain, towards a target. What makes this modification special is that it calculates the velocity and acceleration for each bone in the bone chain, and runs a very light physics-like calculation using the inputted values. This allows the bones to overshoot the target and "jiggle" around. It can be configured to act more like a spring, or sway around like cloth might.</para>
/// <para>This modification is useful for adding additional motion to things like hair, the edges of clothing, and more. It has several settings to that allow control over how the joint moves when the target moves.</para>
/// <para><b>Note:</b> The Jiggle modifier has <c>jiggle_joints</c>, which are the data objects that hold the data for each joint in the Jiggle chain. This is different from than <see cref="Godot.Bone2D"/> nodes! Jiggle joints hold the data needed for each <see cref="Godot.Bone2D"/> in the bone chain used by the Jiggle modification.</para>
/// </summary>
public partial class SkeletonModification2DJiggle : SkeletonModification2D
{
    /// <summary>
    /// <para>The NodePath to the node that is the target for the Jiggle modification. This node is what the Jiggle chain will attempt to rotate the bone chain to.</para>
    /// </summary>
    public NodePath TargetNodePath
    {
        get
        {
            return GetTargetNode();
        }
        set
        {
            SetTargetNode(value);
        }
    }

    /// <summary>
    /// <para>The amount of Jiggle joints in the Jiggle modification.</para>
    /// </summary>
    public int JiggleDataChainLength
    {
        get
        {
            return GetJiggleDataChainLength();
        }
        set
        {
            SetJiggleDataChainLength(value);
        }
    }

    /// <summary>
    /// <para>The default amount of stiffness assigned to the Jiggle joints, if they are not overridden. Higher values act more like springs, quickly moving into the correct position.</para>
    /// </summary>
    public float Stiffness
    {
        get
        {
            return GetStiffness();
        }
        set
        {
            SetStiffness(value);
        }
    }

    /// <summary>
    /// <para>The default amount of mass assigned to the Jiggle joints, if they are not overridden. Higher values lead to faster movements and more overshooting.</para>
    /// </summary>
    public float Mass
    {
        get
        {
            return GetMass();
        }
        set
        {
            SetMass(value);
        }
    }

    /// <summary>
    /// <para>The default amount of damping applied to the Jiggle joints, if they are not overridden. Higher values lead to more of the calculated velocity being applied.</para>
    /// </summary>
    public float Damping
    {
        get
        {
            return GetDamping();
        }
        set
        {
            SetDamping(value);
        }
    }

    /// <summary>
    /// <para>Whether the gravity vector, <see cref="Godot.SkeletonModification2DJiggle.Gravity"/>, should be applied to the Jiggle joints, assuming they are not overriding the default settings.</para>
    /// </summary>
    public bool UseGravity
    {
        get
        {
            return GetUseGravity();
        }
        set
        {
            SetUseGravity(value);
        }
    }

    /// <summary>
    /// <para>The default amount of gravity applied to the Jiggle joints, if they are not overridden.</para>
    /// </summary>
    public Vector2 Gravity
    {
        get
        {
            return GetGravity();
        }
        set
        {
            SetGravity(value);
        }
    }

    private static readonly System.Type CachedType = typeof(SkeletonModification2DJiggle);

    private static readonly StringName NativeName = "SkeletonModification2DJiggle";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public SkeletonModification2DJiggle() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal SkeletonModification2DJiggle(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal SkeletonModification2DJiggle(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTargetNode, 1348162250ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTargetNode(NodePath targetNodePath)
    {
        NativeCalls.godot_icall_1_123(MethodBind0, GodotObject.GetPtr(this), (godot_node_path)(targetNodePath?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTargetNode, 4075236667ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public NodePath GetTargetNode()
    {
        return NativeCalls.godot_icall_0_124(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetJiggleDataChainLength, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetJiggleDataChainLength(int length)
    {
        NativeCalls.godot_icall_1_38(MethodBind2, GodotObject.GetPtr(this), length);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetJiggleDataChainLength, 2455072627ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetJiggleDataChainLength()
    {
        return NativeCalls.godot_icall_0_39(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetStiffness, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetStiffness(float stiffness)
    {
        NativeCalls.godot_icall_1_67(MethodBind4, GodotObject.GetPtr(this), stiffness);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetStiffness, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetStiffness()
    {
        return NativeCalls.godot_icall_0_68(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMass, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMass(float mass)
    {
        NativeCalls.godot_icall_1_67(MethodBind6, GodotObject.GetPtr(this), mass);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMass, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetMass()
    {
        return NativeCalls.godot_icall_0_68(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDamping, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDamping(float damping)
    {
        NativeCalls.godot_icall_1_67(MethodBind8, GodotObject.GetPtr(this), damping);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDamping, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetDamping()
    {
        return NativeCalls.godot_icall_0_68(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetUseGravity, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetUseGravity(bool useGravity)
    {
        NativeCalls.godot_icall_1_14(MethodBind10, GodotObject.GetPtr(this), useGravity.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetUseGravity, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetUseGravity()
    {
        return NativeCalls.godot_icall_0_15(MethodBind11, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetGravity, 743155724ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetGravity(Vector2 gravity)
    {
        NativeCalls.godot_icall_1_36(MethodBind12, GodotObject.GetPtr(this), &gravity);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetGravity, 3341600327ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2 GetGravity()
    {
        return NativeCalls.godot_icall_0_37(MethodBind13, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetUseColliders, 2586408642ul);

    /// <summary>
    /// <para>If <see langword="true"/>, the Jiggle modifier will take colliders into account, keeping them from entering into these collision objects.</para>
    /// </summary>
    public void SetUseColliders(bool useColliders)
    {
        NativeCalls.godot_icall_1_14(MethodBind14, GodotObject.GetPtr(this), useColliders.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetUseColliders, 36873697ul);

    /// <summary>
    /// <para>Returns whether the jiggle modifier is taking physics colliders into account when solving.</para>
    /// </summary>
    public bool GetUseColliders()
    {
        return NativeCalls.godot_icall_0_15(MethodBind15, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCollisionMask, 1286410249ul);

    /// <summary>
    /// <para>Sets the collision mask that the Jiggle modifier will use when reacting to colliders, if the Jiggle modifier is set to take colliders into account.</para>
    /// </summary>
    public void SetCollisionMask(int collisionMask)
    {
        NativeCalls.godot_icall_1_38(MethodBind16, GodotObject.GetPtr(this), collisionMask);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCollisionMask, 3905245786ul);

    /// <summary>
    /// <para>Returns the collision mask used by the Jiggle modifier when collisions are enabled.</para>
    /// </summary>
    public int GetCollisionMask()
    {
        return NativeCalls.godot_icall_0_39(MethodBind17, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetJiggleJointBone2DNode, 2761262315ul);

    /// <summary>
    /// <para>Sets the <see cref="Godot.Bone2D"/> node assigned to the Jiggle joint at <paramref name="jointIdx"/>.</para>
    /// </summary>
    public void SetJiggleJointBone2DNode(int jointIdx, NodePath bone2DNode)
    {
        NativeCalls.godot_icall_2_75(MethodBind18, GodotObject.GetPtr(this), jointIdx, (godot_node_path)(bone2DNode?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetJiggleJointBone2DNode, 408788394ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.Bone2D"/> node assigned to the Jiggle joint at <paramref name="jointIdx"/>.</para>
    /// </summary>
    public NodePath GetJiggleJointBone2DNode(int jointIdx)
    {
        return NativeCalls.godot_icall_1_74(MethodBind19, GodotObject.GetPtr(this), jointIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetJiggleJointBoneIndex, 3937882851ul);

    /// <summary>
    /// <para>Sets the bone index, <paramref name="boneIdx"/>, of the Jiggle joint at <paramref name="jointIdx"/>. When possible, this will also update the <c>bone2d_node</c> of the Jiggle joint based on data provided by the linked skeleton.</para>
    /// </summary>
    public void SetJiggleJointBoneIndex(int jointIdx, int boneIdx)
    {
        NativeCalls.godot_icall_2_59(MethodBind20, GodotObject.GetPtr(this), jointIdx, boneIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetJiggleJointBoneIndex, 923996154ul);

    /// <summary>
    /// <para>Returns the index of the <see cref="Godot.Bone2D"/> node assigned to the Jiggle joint at <paramref name="jointIdx"/>.</para>
    /// </summary>
    public int GetJiggleJointBoneIndex(int jointIdx)
    {
        return NativeCalls.godot_icall_1_60(MethodBind21, GodotObject.GetPtr(this), jointIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetJiggleJointOverride, 300928843ul);

    /// <summary>
    /// <para>Sets whether the Jiggle joint at <paramref name="jointIdx"/> should override the default Jiggle joint settings. Setting this to <see langword="true"/> will make the joint use its own settings rather than the default ones attached to the modification.</para>
    /// </summary>
    public void SetJiggleJointOverride(int jointIdx, bool @override)
    {
        NativeCalls.godot_icall_2_61(MethodBind22, GodotObject.GetPtr(this), jointIdx, @override.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetJiggleJointOverride, 1116898809ul);

    /// <summary>
    /// <para>Returns a boolean that indicates whether the joint at <paramref name="jointIdx"/> is overriding the default Jiggle joint data defined in the modification.</para>
    /// </summary>
    public bool GetJiggleJointOverride(int jointIdx)
    {
        return NativeCalls.godot_icall_1_62(MethodBind23, GodotObject.GetPtr(this), jointIdx).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetJiggleJointStiffness, 1602489585ul);

    /// <summary>
    /// <para>Sets the of stiffness of the Jiggle joint at <paramref name="jointIdx"/>.</para>
    /// </summary>
    public void SetJiggleJointStiffness(int jointIdx, float stiffness)
    {
        NativeCalls.godot_icall_2_69(MethodBind24, GodotObject.GetPtr(this), jointIdx, stiffness);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetJiggleJointStiffness, 2339986948ul);

    /// <summary>
    /// <para>Returns the stiffness of the Jiggle joint at <paramref name="jointIdx"/>.</para>
    /// </summary>
    public float GetJiggleJointStiffness(int jointIdx)
    {
        return NativeCalls.godot_icall_1_72(MethodBind25, GodotObject.GetPtr(this), jointIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetJiggleJointMass, 1602489585ul);

    /// <summary>
    /// <para>Sets the of mass of the Jiggle joint at <paramref name="jointIdx"/>.</para>
    /// </summary>
    public void SetJiggleJointMass(int jointIdx, float mass)
    {
        NativeCalls.godot_icall_2_69(MethodBind26, GodotObject.GetPtr(this), jointIdx, mass);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetJiggleJointMass, 2339986948ul);

    /// <summary>
    /// <para>Returns the amount of mass of the jiggle joint at <paramref name="jointIdx"/>.</para>
    /// </summary>
    public float GetJiggleJointMass(int jointIdx)
    {
        return NativeCalls.godot_icall_1_72(MethodBind27, GodotObject.GetPtr(this), jointIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetJiggleJointDamping, 1602489585ul);

    /// <summary>
    /// <para>Sets the amount of damping of the Jiggle joint at <paramref name="jointIdx"/>.</para>
    /// </summary>
    public void SetJiggleJointDamping(int jointIdx, float damping)
    {
        NativeCalls.godot_icall_2_69(MethodBind28, GodotObject.GetPtr(this), jointIdx, damping);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetJiggleJointDamping, 2339986948ul);

    /// <summary>
    /// <para>Returns the amount of damping of the Jiggle joint at <paramref name="jointIdx"/>.</para>
    /// </summary>
    public float GetJiggleJointDamping(int jointIdx)
    {
        return NativeCalls.godot_icall_1_72(MethodBind29, GodotObject.GetPtr(this), jointIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetJiggleJointUseGravity, 300928843ul);

    /// <summary>
    /// <para>Sets whether the Jiggle joint at <paramref name="jointIdx"/> should use gravity.</para>
    /// </summary>
    public void SetJiggleJointUseGravity(int jointIdx, bool useGravity)
    {
        NativeCalls.godot_icall_2_61(MethodBind30, GodotObject.GetPtr(this), jointIdx, useGravity.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetJiggleJointUseGravity, 1116898809ul);

    /// <summary>
    /// <para>Returns a boolean that indicates whether the joint at <paramref name="jointIdx"/> is using gravity or not.</para>
    /// </summary>
    public bool GetJiggleJointUseGravity(int jointIdx)
    {
        return NativeCalls.godot_icall_1_62(MethodBind31, GodotObject.GetPtr(this), jointIdx).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind32 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetJiggleJointGravity, 163021252ul);

    /// <summary>
    /// <para>Sets the gravity vector of the Jiggle joint at <paramref name="jointIdx"/>.</para>
    /// </summary>
    public unsafe void SetJiggleJointGravity(int jointIdx, Vector2 gravity)
    {
        NativeCalls.godot_icall_2_147(MethodBind32, GodotObject.GetPtr(this), jointIdx, &gravity);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind33 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetJiggleJointGravity, 2299179447ul);

    /// <summary>
    /// <para>Returns a <see cref="Godot.Vector2"/> representing the amount of gravity the Jiggle joint at <paramref name="jointIdx"/> is influenced by.</para>
    /// </summary>
    public Vector2 GetJiggleJointGravity(int jointIdx)
    {
        return NativeCalls.godot_icall_1_148(MethodBind33, GodotObject.GetPtr(this), jointIdx);
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
    public new class PropertyName : SkeletonModification2D.PropertyName
    {
        /// <summary>
        /// Cached name for the 'target_nodepath' property.
        /// </summary>
        public static readonly StringName TargetNodePath = "target_nodepath";
        /// <summary>
        /// Cached name for the 'jiggle_data_chain_length' property.
        /// </summary>
        public static readonly StringName JiggleDataChainLength = "jiggle_data_chain_length";
        /// <summary>
        /// Cached name for the 'stiffness' property.
        /// </summary>
        public static readonly StringName Stiffness = "stiffness";
        /// <summary>
        /// Cached name for the 'mass' property.
        /// </summary>
        public static readonly StringName Mass = "mass";
        /// <summary>
        /// Cached name for the 'damping' property.
        /// </summary>
        public static readonly StringName Damping = "damping";
        /// <summary>
        /// Cached name for the 'use_gravity' property.
        /// </summary>
        public static readonly StringName UseGravity = "use_gravity";
        /// <summary>
        /// Cached name for the 'gravity' property.
        /// </summary>
        public static readonly StringName Gravity = "gravity";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : SkeletonModification2D.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_target_node' method.
        /// </summary>
        public static readonly StringName SetTargetNode = "set_target_node";
        /// <summary>
        /// Cached name for the 'get_target_node' method.
        /// </summary>
        public static readonly StringName GetTargetNode = "get_target_node";
        /// <summary>
        /// Cached name for the 'set_jiggle_data_chain_length' method.
        /// </summary>
        public static readonly StringName SetJiggleDataChainLength = "set_jiggle_data_chain_length";
        /// <summary>
        /// Cached name for the 'get_jiggle_data_chain_length' method.
        /// </summary>
        public static readonly StringName GetJiggleDataChainLength = "get_jiggle_data_chain_length";
        /// <summary>
        /// Cached name for the 'set_stiffness' method.
        /// </summary>
        public static readonly StringName SetStiffness = "set_stiffness";
        /// <summary>
        /// Cached name for the 'get_stiffness' method.
        /// </summary>
        public static readonly StringName GetStiffness = "get_stiffness";
        /// <summary>
        /// Cached name for the 'set_mass' method.
        /// </summary>
        public static readonly StringName SetMass = "set_mass";
        /// <summary>
        /// Cached name for the 'get_mass' method.
        /// </summary>
        public static readonly StringName GetMass = "get_mass";
        /// <summary>
        /// Cached name for the 'set_damping' method.
        /// </summary>
        public static readonly StringName SetDamping = "set_damping";
        /// <summary>
        /// Cached name for the 'get_damping' method.
        /// </summary>
        public static readonly StringName GetDamping = "get_damping";
        /// <summary>
        /// Cached name for the 'set_use_gravity' method.
        /// </summary>
        public static readonly StringName SetUseGravity = "set_use_gravity";
        /// <summary>
        /// Cached name for the 'get_use_gravity' method.
        /// </summary>
        public static readonly StringName GetUseGravity = "get_use_gravity";
        /// <summary>
        /// Cached name for the 'set_gravity' method.
        /// </summary>
        public static readonly StringName SetGravity = "set_gravity";
        /// <summary>
        /// Cached name for the 'get_gravity' method.
        /// </summary>
        public static readonly StringName GetGravity = "get_gravity";
        /// <summary>
        /// Cached name for the 'set_use_colliders' method.
        /// </summary>
        public static readonly StringName SetUseColliders = "set_use_colliders";
        /// <summary>
        /// Cached name for the 'get_use_colliders' method.
        /// </summary>
        public static readonly StringName GetUseColliders = "get_use_colliders";
        /// <summary>
        /// Cached name for the 'set_collision_mask' method.
        /// </summary>
        public static readonly StringName SetCollisionMask = "set_collision_mask";
        /// <summary>
        /// Cached name for the 'get_collision_mask' method.
        /// </summary>
        public static readonly StringName GetCollisionMask = "get_collision_mask";
        /// <summary>
        /// Cached name for the 'set_jiggle_joint_bone2d_node' method.
        /// </summary>
        public static readonly StringName SetJiggleJointBone2DNode = "set_jiggle_joint_bone2d_node";
        /// <summary>
        /// Cached name for the 'get_jiggle_joint_bone2d_node' method.
        /// </summary>
        public static readonly StringName GetJiggleJointBone2DNode = "get_jiggle_joint_bone2d_node";
        /// <summary>
        /// Cached name for the 'set_jiggle_joint_bone_index' method.
        /// </summary>
        public static readonly StringName SetJiggleJointBoneIndex = "set_jiggle_joint_bone_index";
        /// <summary>
        /// Cached name for the 'get_jiggle_joint_bone_index' method.
        /// </summary>
        public static readonly StringName GetJiggleJointBoneIndex = "get_jiggle_joint_bone_index";
        /// <summary>
        /// Cached name for the 'set_jiggle_joint_override' method.
        /// </summary>
        public static readonly StringName SetJiggleJointOverride = "set_jiggle_joint_override";
        /// <summary>
        /// Cached name for the 'get_jiggle_joint_override' method.
        /// </summary>
        public static readonly StringName GetJiggleJointOverride = "get_jiggle_joint_override";
        /// <summary>
        /// Cached name for the 'set_jiggle_joint_stiffness' method.
        /// </summary>
        public static readonly StringName SetJiggleJointStiffness = "set_jiggle_joint_stiffness";
        /// <summary>
        /// Cached name for the 'get_jiggle_joint_stiffness' method.
        /// </summary>
        public static readonly StringName GetJiggleJointStiffness = "get_jiggle_joint_stiffness";
        /// <summary>
        /// Cached name for the 'set_jiggle_joint_mass' method.
        /// </summary>
        public static readonly StringName SetJiggleJointMass = "set_jiggle_joint_mass";
        /// <summary>
        /// Cached name for the 'get_jiggle_joint_mass' method.
        /// </summary>
        public static readonly StringName GetJiggleJointMass = "get_jiggle_joint_mass";
        /// <summary>
        /// Cached name for the 'set_jiggle_joint_damping' method.
        /// </summary>
        public static readonly StringName SetJiggleJointDamping = "set_jiggle_joint_damping";
        /// <summary>
        /// Cached name for the 'get_jiggle_joint_damping' method.
        /// </summary>
        public static readonly StringName GetJiggleJointDamping = "get_jiggle_joint_damping";
        /// <summary>
        /// Cached name for the 'set_jiggle_joint_use_gravity' method.
        /// </summary>
        public static readonly StringName SetJiggleJointUseGravity = "set_jiggle_joint_use_gravity";
        /// <summary>
        /// Cached name for the 'get_jiggle_joint_use_gravity' method.
        /// </summary>
        public static readonly StringName GetJiggleJointUseGravity = "get_jiggle_joint_use_gravity";
        /// <summary>
        /// Cached name for the 'set_jiggle_joint_gravity' method.
        /// </summary>
        public static readonly StringName SetJiggleJointGravity = "set_jiggle_joint_gravity";
        /// <summary>
        /// Cached name for the 'get_jiggle_joint_gravity' method.
        /// </summary>
        public static readonly StringName GetJiggleJointGravity = "get_jiggle_joint_gravity";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : SkeletonModification2D.SignalName
    {
    }
}
