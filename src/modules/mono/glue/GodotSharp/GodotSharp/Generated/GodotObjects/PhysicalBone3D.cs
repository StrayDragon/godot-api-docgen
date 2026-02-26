namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>The <see cref="Godot.PhysicalBone3D"/> node is a physics body that can be used to make bones in a <see cref="Godot.Skeleton3D"/> react to physics.</para>
/// <para><b>Note:</b> In order to detect physical bones with raycasts, the <see cref="Godot.SkeletonModifier3D.Active"/> property of the parent <see cref="Godot.PhysicalBoneSimulator3D"/> must be <see langword="true"/> and the <see cref="Godot.Skeleton3D"/>'s bone must be assigned to <see cref="Godot.PhysicalBone3D"/> correctly; it means that <see cref="Godot.PhysicalBone3D.GetBoneId()"/> should return a valid id (<c>&gt;= 0</c>).</para>
/// </summary>
public partial class PhysicalBone3D : PhysicsBody3D
{
    public enum DampMode : long
    {
        /// <summary>
        /// <para>In this mode, the body's damping value is added to any value set in areas or the default value.</para>
        /// </summary>
        Combine = 0,
        /// <summary>
        /// <para>In this mode, the body's damping value replaces any value set in areas or the default value.</para>
        /// </summary>
        Replace = 1
    }

    public enum JointTypeEnum : long
    {
        /// <summary>
        /// <para>No joint is applied to the PhysicsBone3D.</para>
        /// </summary>
        None = 0,
        /// <summary>
        /// <para>A pin joint is applied to the PhysicsBone3D.</para>
        /// </summary>
        Pin = 1,
        /// <summary>
        /// <para>A cone joint is applied to the PhysicsBone3D.</para>
        /// </summary>
        Cone = 2,
        /// <summary>
        /// <para>A hinge joint is applied to the PhysicsBone3D.</para>
        /// </summary>
        Hinge = 3,
        /// <summary>
        /// <para>A slider joint is applied to the PhysicsBone3D.</para>
        /// </summary>
        Slider = 4,
        /// <summary>
        /// <para>A 6 degrees of freedom joint is applied to the PhysicsBone3D.</para>
        /// </summary>
        Type6Dof = 5
    }

    /// <summary>
    /// <para>Sets the joint type.</para>
    /// </summary>
    public PhysicalBone3D.JointTypeEnum JointType
    {
        get
        {
            return GetJointType();
        }
        set
        {
            SetJointType(value);
        }
    }

    /// <summary>
    /// <para>Sets the joint's transform.</para>
    /// </summary>
    public Transform3D JointOffset
    {
        get
        {
            return GetJointOffset();
        }
        set
        {
            SetJointOffset(value);
        }
    }

    /// <summary>
    /// <para>Sets the joint's rotation in radians.</para>
    /// </summary>
    public Vector3 JointRotation
    {
        get
        {
            return GetJointRotation();
        }
        set
        {
            SetJointRotation(value);
        }
    }

    /// <summary>
    /// <para>Sets the body's transform.</para>
    /// </summary>
    public Transform3D BodyOffset
    {
        get
        {
            return GetBodyOffset();
        }
        set
        {
            SetBodyOffset(value);
        }
    }

    /// <summary>
    /// <para>The body's mass.</para>
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
    /// <para>The body's friction, from <c>0</c> (frictionless) to <c>1</c> (max friction).</para>
    /// </summary>
    public float Friction
    {
        get
        {
            return GetFriction();
        }
        set
        {
            SetFriction(value);
        }
    }

    /// <summary>
    /// <para>The body's bounciness. Values range from <c>0</c> (no bounce) to <c>1</c> (full bounciness).</para>
    /// <para><b>Note:</b> Even with <see cref="Godot.PhysicalBone3D.Bounce"/> set to <c>1.0</c>, some energy will be lost over time due to linear and angular damping. To have a <see cref="Godot.PhysicalBone3D"/> that preserves all its energy over time, set <see cref="Godot.PhysicalBone3D.Bounce"/> to <c>1.0</c>, <see cref="Godot.PhysicalBone3D.LinearDampMode"/> to <see cref="Godot.PhysicalBone3D.DampMode.Replace"/>, <see cref="Godot.PhysicalBone3D.LinearDamp"/> to <c>0.0</c>, <see cref="Godot.PhysicalBone3D.AngularDampMode"/> to <see cref="Godot.PhysicalBone3D.DampMode.Replace"/>, and <see cref="Godot.PhysicalBone3D.AngularDamp"/> to <c>0.0</c>.</para>
    /// </summary>
    public float Bounce
    {
        get
        {
            return GetBounce();
        }
        set
        {
            SetBounce(value);
        }
    }

    /// <summary>
    /// <para>This is multiplied by <c>ProjectSettings.physics/3d/default_gravity</c> to produce this body's gravity. For example, a value of <c>1.0</c> will apply normal gravity, <c>2.0</c> will apply double the gravity, and <c>0.5</c> will apply half the gravity to this body.</para>
    /// </summary>
    public float GravityScale
    {
        get
        {
            return GetGravityScale();
        }
        set
        {
            SetGravityScale(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the standard force integration (like gravity or damping) will be disabled for this body. Other than collision response, the body will only move as determined by the <see cref="Godot.PhysicalBone3D._IntegrateForces(PhysicsDirectBodyState3D)"/> method, if that virtual method is overridden.</para>
    /// <para>Setting this property will call the method <see cref="Godot.PhysicsServer3D.BodySetOmitForceIntegration(Rid, bool)"/> internally.</para>
    /// </summary>
    public bool CustomIntegrator
    {
        get
        {
            return IsUsingCustomIntegrator();
        }
        set
        {
            SetUseCustomIntegrator(value);
        }
    }

    /// <summary>
    /// <para>Defines how <see cref="Godot.PhysicalBone3D.LinearDamp"/> is applied.</para>
    /// </summary>
    public PhysicalBone3D.DampMode LinearDampMode
    {
        get
        {
            return GetLinearDampMode();
        }
        set
        {
            SetLinearDampMode(value);
        }
    }

    /// <summary>
    /// <para>Damps the body's movement. By default, the body will use <c>ProjectSettings.physics/3d/default_linear_damp</c> or any value override set by an <see cref="Godot.Area3D"/> the body is in. Depending on <see cref="Godot.PhysicalBone3D.LinearDampMode"/>, <see cref="Godot.PhysicalBone3D.LinearDamp"/> may be added to or replace the body's damping value.</para>
    /// <para>See <c>ProjectSettings.physics/3d/default_linear_damp</c> for more details about damping.</para>
    /// </summary>
    public float LinearDamp
    {
        get
        {
            return GetLinearDamp();
        }
        set
        {
            SetLinearDamp(value);
        }
    }

    /// <summary>
    /// <para>Defines how <see cref="Godot.PhysicalBone3D.AngularDamp"/> is applied.</para>
    /// </summary>
    public PhysicalBone3D.DampMode AngularDampMode
    {
        get
        {
            return GetAngularDampMode();
        }
        set
        {
            SetAngularDampMode(value);
        }
    }

    /// <summary>
    /// <para>Damps the body's rotation. By default, the body will use the <c>ProjectSettings.physics/3d/default_angular_damp</c> project setting or any value override set by an <see cref="Godot.Area3D"/> the body is in. Depending on <see cref="Godot.PhysicalBone3D.AngularDampMode"/>, you can set <see cref="Godot.PhysicalBone3D.AngularDamp"/> to be added to or to replace the body's damping value.</para>
    /// <para>See <c>ProjectSettings.physics/3d/default_angular_damp</c> for more details about damping.</para>
    /// </summary>
    public float AngularDamp
    {
        get
        {
            return GetAngularDamp();
        }
        set
        {
            SetAngularDamp(value);
        }
    }

    /// <summary>
    /// <para>The body's linear velocity in units per second. Can be used sporadically, but <b>don't set this every frame</b>, because physics may run in another thread and runs at a different granularity. Use <see cref="Godot.PhysicalBone3D._IntegrateForces(PhysicsDirectBodyState3D)"/> as your process loop for precise control of the body state.</para>
    /// </summary>
    public Vector3 LinearVelocity
    {
        get
        {
            return GetLinearVelocity();
        }
        set
        {
            SetLinearVelocity(value);
        }
    }

    /// <summary>
    /// <para>The PhysicalBone3D's rotational velocity in <i>radians</i> per second.</para>
    /// </summary>
    public Vector3 AngularVelocity
    {
        get
        {
            return GetAngularVelocity();
        }
        set
        {
            SetAngularVelocity(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the body is deactivated when there is no movement, so it will not take part in the simulation until it is awakened by an external force.</para>
    /// </summary>
    public bool CanSleep
    {
        get
        {
            return IsAbleToSleep();
        }
        set
        {
            SetCanSleep(value);
        }
    }

    private static readonly System.Type CachedType = typeof(PhysicalBone3D);

    private static readonly StringName NativeName = "PhysicalBone3D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public PhysicalBone3D() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal PhysicalBone3D(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal PhysicalBone3D(bool memoryOwn) : base(memoryOwn) { }

    /// <summary>
    /// <para>Called during physics processing, allowing you to read and safely modify the simulation state for the object. By default, it is called before the standard force integration, but the <see cref="Godot.PhysicalBone3D.CustomIntegrator"/> property allows you to disable the standard force integration and do fully custom force integration for a body.</para>
    /// </summary>
    public virtual void _IntegrateForces(PhysicsDirectBodyState3D state)
    {
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ApplyCentralImpulse, 3460891852ul);

    /// <summary>
    /// <para>Applies a directional impulse without affecting rotation.</para>
    /// <para>An impulse is time-independent! Applying an impulse every frame would result in a framerate-dependent force. For this reason, it should only be used when simulating one-time impacts (use the "_integrate_forces" functions otherwise).</para>
    /// <para>This is equivalent to using <see cref="Godot.PhysicalBone3D.ApplyImpulse(Vector3, Nullable{Vector3})"/> at the body's center of mass.</para>
    /// </summary>
    public unsafe void ApplyCentralImpulse(Vector3 impulse)
    {
        NativeCalls.godot_icall_1_177(MethodBind0, GodotObject.GetPtr(this), &impulse);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ApplyImpulse, 2754756483ul);

    /// <summary>
    /// <para>Applies a positioned impulse to the PhysicsBone3D.</para>
    /// <para>An impulse is time-independent! Applying an impulse every frame would result in a framerate-dependent force. For this reason, it should only be used when simulating one-time impacts (use the "_integrate_forces" functions otherwise).</para>
    /// <para><paramref name="position"/> is the offset from the PhysicsBone3D origin in global coordinates.</para>
    /// </summary>
    /// <param name="position">If the parameter is null, then the default value is <c>new Vector3(0.0f, 0.0f, 0.0f)</c>.</param>
    public unsafe void ApplyImpulse(Vector3 impulse, Nullable<Vector3> position = null)
    {
        Vector3 positionOrDefVal = position.HasValue ? position.Value : new Vector3(0.0f, 0.0f, 0.0f);
        NativeCalls.godot_icall_2_977(MethodBind1, GodotObject.GetPtr(this), &impulse, &positionOrDefVal);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetJointType, 2289552604ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetJointType(PhysicalBone3D.JointTypeEnum jointType)
    {
        NativeCalls.godot_icall_1_38(MethodBind2, GodotObject.GetPtr(this), (int)jointType);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetJointType, 931347320ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public PhysicalBone3D.JointTypeEnum GetJointType()
    {
        return (PhysicalBone3D.JointTypeEnum)NativeCalls.godot_icall_0_39(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetJointOffset, 2952846383ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetJointOffset(Transform3D offset)
    {
        NativeCalls.godot_icall_1_648(MethodBind4, GodotObject.GetPtr(this), &offset);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetJointOffset, 3229777777ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Transform3D GetJointOffset()
    {
        return NativeCalls.godot_icall_0_192(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetJointRotation, 3460891852ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetJointRotation(Vector3 euler)
    {
        NativeCalls.godot_icall_1_177(MethodBind6, GodotObject.GetPtr(this), &euler);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetJointRotation, 3360562783ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector3 GetJointRotation()
    {
        return NativeCalls.godot_icall_0_125(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBodyOffset, 2952846383ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetBodyOffset(Transform3D offset)
    {
        NativeCalls.godot_icall_1_648(MethodBind8, GodotObject.GetPtr(this), &offset);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBodyOffset, 3229777777ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Transform3D GetBodyOffset()
    {
        return NativeCalls.godot_icall_0_192(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSimulatePhysics, 2240911060ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the PhysicsBone3D is allowed to simulate physics.</para>
    /// </summary>
    public bool GetSimulatePhysics()
    {
        return NativeCalls.godot_icall_0_15(MethodBind10, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsSimulatingPhysics, 2240911060ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the PhysicsBone3D is currently simulating physics.</para>
    /// </summary>
    public bool IsSimulatingPhysics()
    {
        return NativeCalls.godot_icall_0_15(MethodBind11, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBoneId, 3905245786ul);

    /// <summary>
    /// <para>Returns the unique identifier of the PhysicsBone3D.</para>
    /// </summary>
    public int GetBoneId()
    {
        return NativeCalls.godot_icall_0_39(MethodBind12, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMass, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMass(float mass)
    {
        NativeCalls.godot_icall_1_67(MethodBind13, GodotObject.GetPtr(this), mass);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMass, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetMass()
    {
        return NativeCalls.godot_icall_0_68(MethodBind14, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFriction, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFriction(float friction)
    {
        NativeCalls.godot_icall_1_67(MethodBind15, GodotObject.GetPtr(this), friction);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFriction, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetFriction()
    {
        return NativeCalls.godot_icall_0_68(MethodBind16, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBounce, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetBounce(float bounce)
    {
        NativeCalls.godot_icall_1_67(MethodBind17, GodotObject.GetPtr(this), bounce);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBounce, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetBounce()
    {
        return NativeCalls.godot_icall_0_68(MethodBind18, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetGravityScale, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetGravityScale(float gravityScale)
    {
        NativeCalls.godot_icall_1_67(MethodBind19, GodotObject.GetPtr(this), gravityScale);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetGravityScale, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetGravityScale()
    {
        return NativeCalls.godot_icall_0_68(MethodBind20, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLinearDampMode, 1244972221ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetLinearDampMode(PhysicalBone3D.DampMode linearDampMode)
    {
        NativeCalls.godot_icall_1_38(MethodBind21, GodotObject.GetPtr(this), (int)linearDampMode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLinearDampMode, 205884699ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public PhysicalBone3D.DampMode GetLinearDampMode()
    {
        return (PhysicalBone3D.DampMode)NativeCalls.godot_icall_0_39(MethodBind22, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAngularDampMode, 1244972221ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAngularDampMode(PhysicalBone3D.DampMode angularDampMode)
    {
        NativeCalls.godot_icall_1_38(MethodBind23, GodotObject.GetPtr(this), (int)angularDampMode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAngularDampMode, 205884699ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public PhysicalBone3D.DampMode GetAngularDampMode()
    {
        return (PhysicalBone3D.DampMode)NativeCalls.godot_icall_0_39(MethodBind24, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLinearDamp, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetLinearDamp(float linearDamp)
    {
        NativeCalls.godot_icall_1_67(MethodBind25, GodotObject.GetPtr(this), linearDamp);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLinearDamp, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetLinearDamp()
    {
        return NativeCalls.godot_icall_0_68(MethodBind26, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAngularDamp, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAngularDamp(float angularDamp)
    {
        NativeCalls.godot_icall_1_67(MethodBind27, GodotObject.GetPtr(this), angularDamp);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAngularDamp, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetAngularDamp()
    {
        return NativeCalls.godot_icall_0_68(MethodBind28, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLinearVelocity, 3460891852ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetLinearVelocity(Vector3 linearVelocity)
    {
        NativeCalls.godot_icall_1_177(MethodBind29, GodotObject.GetPtr(this), &linearVelocity);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLinearVelocity, 3360562783ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector3 GetLinearVelocity()
    {
        return NativeCalls.godot_icall_0_125(MethodBind30, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAngularVelocity, 3460891852ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetAngularVelocity(Vector3 angularVelocity)
    {
        NativeCalls.godot_icall_1_177(MethodBind31, GodotObject.GetPtr(this), &angularVelocity);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind32 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAngularVelocity, 3360562783ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector3 GetAngularVelocity()
    {
        return NativeCalls.godot_icall_0_125(MethodBind32, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind33 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetUseCustomIntegrator, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetUseCustomIntegrator(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind33, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind34 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsUsingCustomIntegrator, 2240911060ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsUsingCustomIntegrator()
    {
        return NativeCalls.godot_icall_0_15(MethodBind34, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind35 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCanSleep, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCanSleep(bool ableToSleep)
    {
        NativeCalls.godot_icall_1_14(MethodBind35, GodotObject.GetPtr(this), ableToSleep.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind36 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsAbleToSleep, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsAbleToSleep()
    {
        return NativeCalls.godot_icall_0_15(MethodBind36, GodotObject.GetPtr(this)).ToBool();
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__integrate_forces = "_IntegrateForces";

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
        if ((method == MethodProxyName__integrate_forces || method == MethodName._IntegrateForces) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__integrate_forces.NativeValue))
        {
            _IntegrateForces(VariantUtils.ConvertTo<PhysicsDirectBodyState3D>(args[0]));
            ret = default;
            return true;
        }
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
        if (method == MethodName._IntegrateForces)
        {
            if (HasGodotClassMethod(MethodProxyName__integrate_forces.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
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
    public new class PropertyName : PhysicsBody3D.PropertyName
    {
        /// <summary>
        /// Cached name for the 'joint_type' property.
        /// </summary>
        public static readonly StringName JointType = "joint_type";
        /// <summary>
        /// Cached name for the 'joint_offset' property.
        /// </summary>
        public static readonly StringName JointOffset = "joint_offset";
        /// <summary>
        /// Cached name for the 'joint_rotation' property.
        /// </summary>
        public static readonly StringName JointRotation = "joint_rotation";
        /// <summary>
        /// Cached name for the 'body_offset' property.
        /// </summary>
        public static readonly StringName BodyOffset = "body_offset";
        /// <summary>
        /// Cached name for the 'mass' property.
        /// </summary>
        public static readonly StringName Mass = "mass";
        /// <summary>
        /// Cached name for the 'friction' property.
        /// </summary>
        public static readonly StringName Friction = "friction";
        /// <summary>
        /// Cached name for the 'bounce' property.
        /// </summary>
        public static readonly StringName Bounce = "bounce";
        /// <summary>
        /// Cached name for the 'gravity_scale' property.
        /// </summary>
        public static readonly StringName GravityScale = "gravity_scale";
        /// <summary>
        /// Cached name for the 'custom_integrator' property.
        /// </summary>
        public static readonly StringName CustomIntegrator = "custom_integrator";
        /// <summary>
        /// Cached name for the 'linear_damp_mode' property.
        /// </summary>
        public static readonly StringName LinearDampMode = "linear_damp_mode";
        /// <summary>
        /// Cached name for the 'linear_damp' property.
        /// </summary>
        public static readonly StringName LinearDamp = "linear_damp";
        /// <summary>
        /// Cached name for the 'angular_damp_mode' property.
        /// </summary>
        public static readonly StringName AngularDampMode = "angular_damp_mode";
        /// <summary>
        /// Cached name for the 'angular_damp' property.
        /// </summary>
        public static readonly StringName AngularDamp = "angular_damp";
        /// <summary>
        /// Cached name for the 'linear_velocity' property.
        /// </summary>
        public static readonly StringName LinearVelocity = "linear_velocity";
        /// <summary>
        /// Cached name for the 'angular_velocity' property.
        /// </summary>
        public static readonly StringName AngularVelocity = "angular_velocity";
        /// <summary>
        /// Cached name for the 'can_sleep' property.
        /// </summary>
        public static readonly StringName CanSleep = "can_sleep";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : PhysicsBody3D.MethodName
    {
        /// <summary>
        /// Cached name for the '_integrate_forces' method.
        /// </summary>
        public static readonly StringName _IntegrateForces = "_integrate_forces";
        /// <summary>
        /// Cached name for the 'apply_central_impulse' method.
        /// </summary>
        public static readonly StringName ApplyCentralImpulse = "apply_central_impulse";
        /// <summary>
        /// Cached name for the 'apply_impulse' method.
        /// </summary>
        public static readonly StringName ApplyImpulse = "apply_impulse";
        /// <summary>
        /// Cached name for the 'set_joint_type' method.
        /// </summary>
        public static readonly StringName SetJointType = "set_joint_type";
        /// <summary>
        /// Cached name for the 'get_joint_type' method.
        /// </summary>
        public static readonly StringName GetJointType = "get_joint_type";
        /// <summary>
        /// Cached name for the 'set_joint_offset' method.
        /// </summary>
        public static readonly StringName SetJointOffset = "set_joint_offset";
        /// <summary>
        /// Cached name for the 'get_joint_offset' method.
        /// </summary>
        public static readonly StringName GetJointOffset = "get_joint_offset";
        /// <summary>
        /// Cached name for the 'set_joint_rotation' method.
        /// </summary>
        public static readonly StringName SetJointRotation = "set_joint_rotation";
        /// <summary>
        /// Cached name for the 'get_joint_rotation' method.
        /// </summary>
        public static readonly StringName GetJointRotation = "get_joint_rotation";
        /// <summary>
        /// Cached name for the 'set_body_offset' method.
        /// </summary>
        public static readonly StringName SetBodyOffset = "set_body_offset";
        /// <summary>
        /// Cached name for the 'get_body_offset' method.
        /// </summary>
        public static readonly StringName GetBodyOffset = "get_body_offset";
        /// <summary>
        /// Cached name for the 'get_simulate_physics' method.
        /// </summary>
        public static readonly StringName GetSimulatePhysics = "get_simulate_physics";
        /// <summary>
        /// Cached name for the 'is_simulating_physics' method.
        /// </summary>
        public static readonly StringName IsSimulatingPhysics = "is_simulating_physics";
        /// <summary>
        /// Cached name for the 'get_bone_id' method.
        /// </summary>
        public static readonly StringName GetBoneId = "get_bone_id";
        /// <summary>
        /// Cached name for the 'set_mass' method.
        /// </summary>
        public static readonly StringName SetMass = "set_mass";
        /// <summary>
        /// Cached name for the 'get_mass' method.
        /// </summary>
        public static readonly StringName GetMass = "get_mass";
        /// <summary>
        /// Cached name for the 'set_friction' method.
        /// </summary>
        public static readonly StringName SetFriction = "set_friction";
        /// <summary>
        /// Cached name for the 'get_friction' method.
        /// </summary>
        public static readonly StringName GetFriction = "get_friction";
        /// <summary>
        /// Cached name for the 'set_bounce' method.
        /// </summary>
        public static readonly StringName SetBounce = "set_bounce";
        /// <summary>
        /// Cached name for the 'get_bounce' method.
        /// </summary>
        public static readonly StringName GetBounce = "get_bounce";
        /// <summary>
        /// Cached name for the 'set_gravity_scale' method.
        /// </summary>
        public static readonly StringName SetGravityScale = "set_gravity_scale";
        /// <summary>
        /// Cached name for the 'get_gravity_scale' method.
        /// </summary>
        public static readonly StringName GetGravityScale = "get_gravity_scale";
        /// <summary>
        /// Cached name for the 'set_linear_damp_mode' method.
        /// </summary>
        public static readonly StringName SetLinearDampMode = "set_linear_damp_mode";
        /// <summary>
        /// Cached name for the 'get_linear_damp_mode' method.
        /// </summary>
        public static readonly StringName GetLinearDampMode = "get_linear_damp_mode";
        /// <summary>
        /// Cached name for the 'set_angular_damp_mode' method.
        /// </summary>
        public static readonly StringName SetAngularDampMode = "set_angular_damp_mode";
        /// <summary>
        /// Cached name for the 'get_angular_damp_mode' method.
        /// </summary>
        public static readonly StringName GetAngularDampMode = "get_angular_damp_mode";
        /// <summary>
        /// Cached name for the 'set_linear_damp' method.
        /// </summary>
        public static readonly StringName SetLinearDamp = "set_linear_damp";
        /// <summary>
        /// Cached name for the 'get_linear_damp' method.
        /// </summary>
        public static readonly StringName GetLinearDamp = "get_linear_damp";
        /// <summary>
        /// Cached name for the 'set_angular_damp' method.
        /// </summary>
        public static readonly StringName SetAngularDamp = "set_angular_damp";
        /// <summary>
        /// Cached name for the 'get_angular_damp' method.
        /// </summary>
        public static readonly StringName GetAngularDamp = "get_angular_damp";
        /// <summary>
        /// Cached name for the 'set_linear_velocity' method.
        /// </summary>
        public static readonly StringName SetLinearVelocity = "set_linear_velocity";
        /// <summary>
        /// Cached name for the 'get_linear_velocity' method.
        /// </summary>
        public static readonly StringName GetLinearVelocity = "get_linear_velocity";
        /// <summary>
        /// Cached name for the 'set_angular_velocity' method.
        /// </summary>
        public static readonly StringName SetAngularVelocity = "set_angular_velocity";
        /// <summary>
        /// Cached name for the 'get_angular_velocity' method.
        /// </summary>
        public static readonly StringName GetAngularVelocity = "get_angular_velocity";
        /// <summary>
        /// Cached name for the 'set_use_custom_integrator' method.
        /// </summary>
        public static readonly StringName SetUseCustomIntegrator = "set_use_custom_integrator";
        /// <summary>
        /// Cached name for the 'is_using_custom_integrator' method.
        /// </summary>
        public static readonly StringName IsUsingCustomIntegrator = "is_using_custom_integrator";
        /// <summary>
        /// Cached name for the 'set_can_sleep' method.
        /// </summary>
        public static readonly StringName SetCanSleep = "set_can_sleep";
        /// <summary>
        /// Cached name for the 'is_able_to_sleep' method.
        /// </summary>
        public static readonly StringName IsAbleToSleep = "is_able_to_sleep";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : PhysicsBody3D.SignalName
    {
    }
}
