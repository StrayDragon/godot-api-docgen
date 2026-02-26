namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para><see cref="Godot.RigidBody3D"/> implements full 3D physics. It cannot be controlled directly, instead, you must apply forces to it (gravity, impulses, etc.), and the physics simulation will calculate the resulting movement, rotation, react to collisions, and affect other physics bodies in its path.</para>
/// <para>The body's behavior can be adjusted via <see cref="Godot.RigidBody3D.LockRotation"/>, <see cref="Godot.RigidBody3D.Freeze"/>, and <see cref="Godot.RigidBody3D.FreezeMode"/>. By changing various properties of the object, such as <see cref="Godot.RigidBody3D.Mass"/>, you can control how the physics simulation acts on it.</para>
/// <para>A rigid body will always maintain its shape and size, even when forces are applied to it. It is useful for objects that can be interacted with in an environment, such as a tree that can be knocked over or a stack of crates that can be pushed around.</para>
/// <para>If you need to directly affect the body, prefer <see cref="Godot.RigidBody3D._IntegrateForces(PhysicsDirectBodyState3D)"/> as it allows you to directly access the physics state.</para>
/// <para>If you need to override the default physics behavior, you can write a custom force integration function. See <see cref="Godot.RigidBody3D.CustomIntegrator"/>.</para>
/// <para><b>Note:</b> Changing the 3D transform or <see cref="Godot.RigidBody3D.LinearVelocity"/> of a <see cref="Godot.RigidBody3D"/> very often may lead to some unpredictable behaviors. This also happens when a <see cref="Godot.RigidBody3D"/> is the descendant of a constantly moving node, like another <see cref="Godot.RigidBody3D"/>, as that will cause its global transform to be set whenever its ancestor moves.</para>
/// </summary>
public partial class RigidBody3D : PhysicsBody3D
{
    public enum FreezeModeEnum : long
    {
        /// <summary>
        /// <para>Static body freeze mode (default). The body is not affected by gravity and forces. It can be only moved by user code and doesn't collide with other bodies along its path.</para>
        /// </summary>
        Static = 0,
        /// <summary>
        /// <para>Kinematic body freeze mode. Similar to <see cref="Godot.RigidBody3D.FreezeModeEnum.Static"/>, but collides with other bodies along its path when moved. Useful for a frozen body that needs to be animated.</para>
        /// </summary>
        Kinematic = 1
    }

    public enum CenterOfMassModeEnum : long
    {
        /// <summary>
        /// <para>In this mode, the body's center of mass is calculated automatically based on its shapes. This assumes that the shapes' origins are also their center of mass.</para>
        /// </summary>
        Auto = 0,
        /// <summary>
        /// <para>In this mode, the body's center of mass is set through <see cref="Godot.RigidBody3D.CenterOfMass"/>. Defaults to the body's origin position.</para>
        /// </summary>
        Custom = 1
    }

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
    /// <para>The physics material override for the body.</para>
    /// <para>If a material is assigned to this property, it will be used instead of any other physics material, such as an inherited one.</para>
    /// </summary>
    public PhysicsMaterial PhysicsMaterialOverride
    {
        get
        {
            return GetPhysicsMaterialOverride();
        }
        set
        {
            SetPhysicsMaterialOverride(value);
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
    /// <para>Defines the way the body's center of mass is set.</para>
    /// </summary>
    public RigidBody3D.CenterOfMassModeEnum CenterOfMassMode
    {
        get
        {
            return GetCenterOfMassMode();
        }
        set
        {
            SetCenterOfMassMode(value);
        }
    }

    /// <summary>
    /// <para>The body's custom center of mass, relative to the body's origin position, when <see cref="Godot.RigidBody3D.CenterOfMassMode"/> is set to <see cref="Godot.RigidBody3D.CenterOfMassModeEnum.Custom"/>. This is the balanced point of the body, where applied forces only cause linear acceleration. Applying forces outside of the center of mass causes angular acceleration.</para>
    /// <para>When <see cref="Godot.RigidBody3D.CenterOfMassMode"/> is set to <see cref="Godot.RigidBody3D.CenterOfMassModeEnum.Auto"/> (default value), the center of mass is automatically determined, but this does not update the value of <see cref="Godot.RigidBody3D.CenterOfMass"/>.</para>
    /// </summary>
    public Vector3 CenterOfMass
    {
        get
        {
            return GetCenterOfMass();
        }
        set
        {
            SetCenterOfMass(value);
        }
    }

    /// <summary>
    /// <para>The body's moment of inertia. This is like mass, but for rotation: it determines how much torque it takes to rotate the body on each axis. The moment of inertia is usually computed automatically from the mass and the shapes, but this property allows you to set a custom value.</para>
    /// <para>If set to <c>Vector3.ZERO</c>, inertia is automatically computed (default value).</para>
    /// <para><b>Note:</b> This value does not change when inertia is automatically computed. Use <see cref="Godot.PhysicsServer3D"/> to get the computed inertia.</para>
    /// <para><code>
    /// private RigidBody3D _ball;
    /// 
    /// public override void _Ready()
    /// {
    /// 	_ball = GetNode&lt;RigidBody3D&gt;("Ball");
    /// }
    /// 
    /// private Vector3 GetBallInertia()
    /// {
    /// 	return PhysicsServer3D.BodyGetDirectState(_ball.GetRid()).InverseInertia.Inverse();
    /// }
    /// </code></para>
    /// </summary>
    public Vector3 Inertia
    {
        get
        {
            return GetInertia();
        }
        set
        {
            SetInertia(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the body will not move and will not calculate forces until woken up by another body through, for example, a collision, or by using the <see cref="Godot.RigidBody3D.ApplyImpulse(Vector3, Nullable{Vector3})"/> or <see cref="Godot.RigidBody3D.ApplyForce(Vector3, Nullable{Vector3})"/> methods.</para>
    /// </summary>
    public bool Sleeping
    {
        get
        {
            return IsSleeping();
        }
        set
        {
            SetSleeping(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the body can enter sleep mode when there is no movement. See <see cref="Godot.RigidBody3D.Sleeping"/>.</para>
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

    /// <summary>
    /// <para>If <see langword="true"/>, the body cannot rotate. Gravity and forces only apply linear movement.</para>
    /// </summary>
    public bool LockRotation
    {
        get
        {
            return IsLockRotationEnabled();
        }
        set
        {
            SetLockRotationEnabled(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the body is frozen. Gravity and forces are not applied anymore.</para>
    /// <para>See <see cref="Godot.RigidBody3D.FreezeMode"/> to set the body's behavior when frozen.</para>
    /// <para><b>Note:</b> For a body that is always frozen, use <see cref="Godot.StaticBody3D"/> or <see cref="Godot.AnimatableBody3D"/> instead.</para>
    /// </summary>
    public bool Freeze
    {
        get
        {
            return IsFreezeEnabled();
        }
        set
        {
            SetFreezeEnabled(value);
        }
    }

    /// <summary>
    /// <para>The body's freeze mode. Determines the body's behavior when <see cref="Godot.RigidBody3D.Freeze"/> is <see langword="true"/>.</para>
    /// <para><b>Note:</b> For a body that is always frozen, use <see cref="Godot.StaticBody3D"/> or <see cref="Godot.AnimatableBody3D"/> instead.</para>
    /// </summary>
    public RigidBody3D.FreezeModeEnum FreezeMode
    {
        get
        {
            return GetFreezeMode();
        }
        set
        {
            SetFreezeMode(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the standard force integration (like gravity or damping) will be disabled for this body. Other than collision response, the body will only move as determined by the <see cref="Godot.RigidBody3D._IntegrateForces(PhysicsDirectBodyState3D)"/> method, if that virtual method is overridden.</para>
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
    /// <para>If <see langword="true"/>, continuous collision detection is used.</para>
    /// <para>Continuous collision detection tries to predict where a moving body will collide, instead of moving it and correcting its movement if it collided. Continuous collision detection is more precise, and misses fewer impacts by small, fast-moving objects. Not using continuous collision detection is faster to compute, but can miss small, fast-moving objects.</para>
    /// </summary>
    public bool ContinuousCd
    {
        get
        {
            return IsUsingContinuousCollisionDetection();
        }
        set
        {
            SetUseContinuousCollisionDetection(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the RigidBody3D will emit signals when it collides with another body.</para>
    /// <para><b>Note:</b> By default the maximum contacts reported is set to 0, meaning nothing will be recorded, see <see cref="Godot.RigidBody3D.MaxContactsReported"/>.</para>
    /// </summary>
    public bool ContactMonitor
    {
        get
        {
            return IsContactMonitorEnabled();
        }
        set
        {
            SetContactMonitor(value);
        }
    }

    /// <summary>
    /// <para>The maximum number of contacts that will be recorded. Requires a value greater than 0 and <see cref="Godot.RigidBody3D.ContactMonitor"/> to be set to <see langword="true"/> to start to register contacts. Use <see cref="Godot.RigidBody3D.GetContactCount()"/> to retrieve the count or <see cref="Godot.RigidBody3D.GetCollidingBodies()"/> to retrieve bodies that have been collided with.</para>
    /// <para><b>Note:</b> The number of contacts is different from the number of collisions. Collisions between parallel edges will result in two contacts (one at each end), and collisions between parallel faces will result in four contacts (one at each corner).</para>
    /// </summary>
    public int MaxContactsReported
    {
        get
        {
            return GetMaxContactsReported();
        }
        set
        {
            SetMaxContactsReported(value);
        }
    }

    /// <summary>
    /// <para>The body's linear velocity in units per second. Can be used sporadically, but <b>don't set this every frame</b>, because physics may run in another thread and runs at a different granularity. Use <see cref="Godot.RigidBody3D._IntegrateForces(PhysicsDirectBodyState3D)"/> as your process loop for precise control of the body state.</para>
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
    /// <para>Defines how <see cref="Godot.RigidBody3D.LinearDamp"/> is applied.</para>
    /// </summary>
    public RigidBody3D.DampMode LinearDampMode
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
    /// <para>Damps the body's movement. By default, the body will use the <c>ProjectSettings.physics/3d/default_linear_damp</c> project setting or any value override set by an <see cref="Godot.Area3D"/> the body is in. Depending on <see cref="Godot.RigidBody3D.LinearDampMode"/>, you can set <see cref="Godot.RigidBody3D.LinearDamp"/> to be added to or to replace the body's damping value.</para>
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
    /// <para>The RigidBody3D's rotational velocity in <i>radians</i> per second.</para>
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
    /// <para>Defines how <see cref="Godot.RigidBody3D.AngularDamp"/> is applied.</para>
    /// </summary>
    public RigidBody3D.DampMode AngularDampMode
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
    /// <para>Damps the body's rotation. By default, the body will use the <c>ProjectSettings.physics/3d/default_angular_damp</c> project setting or any value override set by an <see cref="Godot.Area3D"/> the body is in. Depending on <see cref="Godot.RigidBody3D.AngularDampMode"/>, you can set <see cref="Godot.RigidBody3D.AngularDamp"/> to be added to or to replace the body's damping value.</para>
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
    /// <para>The body's total constant positional forces applied during each physics update.</para>
    /// <para>See <see cref="Godot.RigidBody3D.AddConstantForce(Vector3, Nullable{Vector3})"/> and <see cref="Godot.RigidBody3D.AddConstantCentralForce(Vector3)"/>.</para>
    /// </summary>
    public Vector3 ConstantForce
    {
        get
        {
            return GetConstantForce();
        }
        set
        {
            SetConstantForce(value);
        }
    }

    /// <summary>
    /// <para>The body's total constant rotational forces applied during each physics update.</para>
    /// <para>See <see cref="Godot.RigidBody3D.AddConstantTorque(Vector3)"/>.</para>
    /// </summary>
    public Vector3 ConstantTorque
    {
        get
        {
            return GetConstantTorque();
        }
        set
        {
            SetConstantTorque(value);
        }
    }

    private static readonly System.Type CachedType = typeof(RigidBody3D);

    private static readonly StringName NativeName = "RigidBody3D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public RigidBody3D() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal RigidBody3D(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal RigidBody3D(bool memoryOwn) : base(memoryOwn) { }

    /// <summary>
    /// <para>Called during physics processing, allowing you to read and safely modify the simulation state for the object. By default, it is called before the standard force integration, but the <see cref="Godot.RigidBody3D.CustomIntegrator"/> property allows you to disable the standard force integration and do fully custom force integration for a body.</para>
    /// </summary>
    public virtual void _IntegrateForces(PhysicsDirectBodyState3D state)
    {
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMass, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMass(float mass)
    {
        NativeCalls.godot_icall_1_67(MethodBind0, GodotObject.GetPtr(this), mass);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMass, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetMass()
    {
        return NativeCalls.godot_icall_0_68(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetInertia, 3460891852ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetInertia(Vector3 inertia)
    {
        NativeCalls.godot_icall_1_177(MethodBind2, GodotObject.GetPtr(this), &inertia);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetInertia, 3360562783ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector3 GetInertia()
    {
        return NativeCalls.godot_icall_0_125(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCenterOfMassMode, 3625866032ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCenterOfMassMode(RigidBody3D.CenterOfMassModeEnum mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind4, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCenterOfMassMode, 237405040ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public RigidBody3D.CenterOfMassModeEnum GetCenterOfMassMode()
    {
        return (RigidBody3D.CenterOfMassModeEnum)NativeCalls.godot_icall_0_39(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCenterOfMass, 3460891852ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetCenterOfMass(Vector3 centerOfMass)
    {
        NativeCalls.godot_icall_1_177(MethodBind6, GodotObject.GetPtr(this), &centerOfMass);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCenterOfMass, 3360562783ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector3 GetCenterOfMass()
    {
        return NativeCalls.godot_icall_0_125(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPhysicsMaterialOverride, 1784508650ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPhysicsMaterialOverride(PhysicsMaterial physicsMaterialOverride)
    {
        NativeCalls.godot_icall_1_56(MethodBind8, GodotObject.GetPtr(this), GodotObject.GetPtr(physicsMaterialOverride));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPhysicsMaterialOverride, 2521850424ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public PhysicsMaterial GetPhysicsMaterialOverride()
    {
        return (PhysicsMaterial)NativeCalls.godot_icall_0_63(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLinearVelocity, 3460891852ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetLinearVelocity(Vector3 linearVelocity)
    {
        NativeCalls.godot_icall_1_177(MethodBind10, GodotObject.GetPtr(this), &linearVelocity);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLinearVelocity, 3360562783ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector3 GetLinearVelocity()
    {
        return NativeCalls.godot_icall_0_125(MethodBind11, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAngularVelocity, 3460891852ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetAngularVelocity(Vector3 angularVelocity)
    {
        NativeCalls.godot_icall_1_177(MethodBind12, GodotObject.GetPtr(this), &angularVelocity);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAngularVelocity, 3360562783ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector3 GetAngularVelocity()
    {
        return NativeCalls.godot_icall_0_125(MethodBind13, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetInverseInertiaTensor, 2716978435ul);

    /// <summary>
    /// <para>Returns the inverse inertia tensor basis. This is used to calculate the angular acceleration resulting from a torque applied to the <see cref="Godot.RigidBody3D"/>.</para>
    /// </summary>
    public Basis GetInverseInertiaTensor()
    {
        return NativeCalls.godot_icall_0_652(MethodBind14, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetGravityScale, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetGravityScale(float gravityScale)
    {
        NativeCalls.godot_icall_1_67(MethodBind15, GodotObject.GetPtr(this), gravityScale);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetGravityScale, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetGravityScale()
    {
        return NativeCalls.godot_icall_0_68(MethodBind16, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLinearDampMode, 1802035050ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetLinearDampMode(RigidBody3D.DampMode linearDampMode)
    {
        NativeCalls.godot_icall_1_38(MethodBind17, GodotObject.GetPtr(this), (int)linearDampMode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLinearDampMode, 1366206940ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public RigidBody3D.DampMode GetLinearDampMode()
    {
        return (RigidBody3D.DampMode)NativeCalls.godot_icall_0_39(MethodBind18, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAngularDampMode, 1802035050ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAngularDampMode(RigidBody3D.DampMode angularDampMode)
    {
        NativeCalls.godot_icall_1_38(MethodBind19, GodotObject.GetPtr(this), (int)angularDampMode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAngularDampMode, 1366206940ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public RigidBody3D.DampMode GetAngularDampMode()
    {
        return (RigidBody3D.DampMode)NativeCalls.godot_icall_0_39(MethodBind20, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLinearDamp, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetLinearDamp(float linearDamp)
    {
        NativeCalls.godot_icall_1_67(MethodBind21, GodotObject.GetPtr(this), linearDamp);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLinearDamp, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetLinearDamp()
    {
        return NativeCalls.godot_icall_0_68(MethodBind22, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAngularDamp, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAngularDamp(float angularDamp)
    {
        NativeCalls.godot_icall_1_67(MethodBind23, GodotObject.GetPtr(this), angularDamp);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAngularDamp, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetAngularDamp()
    {
        return NativeCalls.godot_icall_0_68(MethodBind24, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMaxContactsReported, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMaxContactsReported(int amount)
    {
        NativeCalls.godot_icall_1_38(MethodBind25, GodotObject.GetPtr(this), amount);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMaxContactsReported, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetMaxContactsReported()
    {
        return NativeCalls.godot_icall_0_39(MethodBind26, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetContactCount, 3905245786ul);

    /// <summary>
    /// <para>Returns the number of contacts this body has with other bodies. By default, this returns 0 unless bodies are configured to monitor contacts (see <see cref="Godot.RigidBody3D.ContactMonitor"/>).</para>
    /// <para><b>Note:</b> To retrieve the colliding bodies, use <see cref="Godot.RigidBody3D.GetCollidingBodies()"/>.</para>
    /// </summary>
    public int GetContactCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind27, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetUseCustomIntegrator, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetUseCustomIntegrator(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind28, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsUsingCustomIntegrator, 2240911060ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsUsingCustomIntegrator()
    {
        return NativeCalls.godot_icall_0_15(MethodBind29, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetContactMonitor, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetContactMonitor(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind30, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsContactMonitorEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsContactMonitorEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind31, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind32 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetUseContinuousCollisionDetection, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetUseContinuousCollisionDetection(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind32, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind33 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsUsingContinuousCollisionDetection, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsUsingContinuousCollisionDetection()
    {
        return NativeCalls.godot_icall_0_15(MethodBind33, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind34 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAxisVelocity, 3460891852ul);

    /// <summary>
    /// <para>Sets an axis velocity. The velocity in the given vector axis will be set as the given vector length. This is useful for jumping behavior.</para>
    /// </summary>
    public unsafe void SetAxisVelocity(Vector3 axisVelocity)
    {
        NativeCalls.godot_icall_1_177(MethodBind34, GodotObject.GetPtr(this), &axisVelocity);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind35 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ApplyCentralImpulse, 3460891852ul);

    /// <summary>
    /// <para>Applies a directional impulse without affecting rotation.</para>
    /// <para>An impulse is time-independent! Applying an impulse every frame would result in a framerate-dependent force. For this reason, it should only be used when simulating one-time impacts (use the "_force" functions otherwise).</para>
    /// <para>This is equivalent to using <see cref="Godot.RigidBody3D.ApplyImpulse(Vector3, Nullable{Vector3})"/> at the body's center of mass.</para>
    /// </summary>
    public unsafe void ApplyCentralImpulse(Vector3 impulse)
    {
        NativeCalls.godot_icall_1_177(MethodBind35, GodotObject.GetPtr(this), &impulse);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind36 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ApplyImpulse, 2754756483ul);

    /// <summary>
    /// <para>Applies a positioned impulse to the body.</para>
    /// <para>An impulse is time-independent! Applying an impulse every frame would result in a framerate-dependent force. For this reason, it should only be used when simulating one-time impacts (use the "_force" functions otherwise).</para>
    /// <para><paramref name="position"/> is the offset from the body origin in global coordinates.</para>
    /// </summary>
    /// <param name="position">If the parameter is null, then the default value is <c>new Vector3(0.0f, 0.0f, 0.0f)</c>.</param>
    public unsafe void ApplyImpulse(Vector3 impulse, Nullable<Vector3> position = null)
    {
        Vector3 positionOrDefVal = position.HasValue ? position.Value : new Vector3(0.0f, 0.0f, 0.0f);
        NativeCalls.godot_icall_2_977(MethodBind36, GodotObject.GetPtr(this), &impulse, &positionOrDefVal);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind37 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ApplyTorqueImpulse, 3460891852ul);

    /// <summary>
    /// <para>Applies a rotational impulse to the body without affecting the position.</para>
    /// <para>An impulse is time-independent! Applying an impulse every frame would result in a framerate-dependent force. For this reason, it should only be used when simulating one-time impacts (use the "_force" functions otherwise).</para>
    /// <para><b>Note:</b> <see cref="Godot.RigidBody3D.Inertia"/> is required for this to work. To have <see cref="Godot.RigidBody3D.Inertia"/>, an active <see cref="Godot.CollisionShape3D"/> must be a child of the node, or you can manually set <see cref="Godot.RigidBody3D.Inertia"/>.</para>
    /// </summary>
    public unsafe void ApplyTorqueImpulse(Vector3 impulse)
    {
        NativeCalls.godot_icall_1_177(MethodBind37, GodotObject.GetPtr(this), &impulse);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind38 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ApplyCentralForce, 3460891852ul);

    /// <summary>
    /// <para>Applies a directional force without affecting rotation. A force is time dependent and meant to be applied every physics update.</para>
    /// <para>This is equivalent to using <see cref="Godot.RigidBody3D.ApplyForce(Vector3, Nullable{Vector3})"/> at the body's center of mass.</para>
    /// </summary>
    public unsafe void ApplyCentralForce(Vector3 force)
    {
        NativeCalls.godot_icall_1_177(MethodBind38, GodotObject.GetPtr(this), &force);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind39 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ApplyForce, 2754756483ul);

    /// <summary>
    /// <para>Applies a positioned force to the body. A force is time dependent and meant to be applied every physics update.</para>
    /// <para><paramref name="position"/> is the offset from the body origin in global coordinates.</para>
    /// </summary>
    /// <param name="position">If the parameter is null, then the default value is <c>new Vector3(0.0f, 0.0f, 0.0f)</c>.</param>
    public unsafe void ApplyForce(Vector3 force, Nullable<Vector3> position = null)
    {
        Vector3 positionOrDefVal = position.HasValue ? position.Value : new Vector3(0.0f, 0.0f, 0.0f);
        NativeCalls.godot_icall_2_977(MethodBind39, GodotObject.GetPtr(this), &force, &positionOrDefVal);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind40 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ApplyTorque, 3460891852ul);

    /// <summary>
    /// <para>Applies a rotational force without affecting position. A force is time dependent and meant to be applied every physics update.</para>
    /// <para><b>Note:</b> <see cref="Godot.RigidBody3D.Inertia"/> is required for this to work. To have <see cref="Godot.RigidBody3D.Inertia"/>, an active <see cref="Godot.CollisionShape3D"/> must be a child of the node, or you can manually set <see cref="Godot.RigidBody3D.Inertia"/>.</para>
    /// </summary>
    public unsafe void ApplyTorque(Vector3 torque)
    {
        NativeCalls.godot_icall_1_177(MethodBind40, GodotObject.GetPtr(this), &torque);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind41 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddConstantCentralForce, 3460891852ul);

    /// <summary>
    /// <para>Adds a constant directional force without affecting rotation that keeps being applied over time until cleared with <c>constant_force = Vector3(0, 0, 0)</c>.</para>
    /// <para>This is equivalent to using <see cref="Godot.RigidBody3D.AddConstantForce(Vector3, Nullable{Vector3})"/> at the body's center of mass.</para>
    /// </summary>
    public unsafe void AddConstantCentralForce(Vector3 force)
    {
        NativeCalls.godot_icall_1_177(MethodBind41, GodotObject.GetPtr(this), &force);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind42 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddConstantForce, 2754756483ul);

    /// <summary>
    /// <para>Adds a constant positioned force to the body that keeps being applied over time until cleared with <c>constant_force = Vector3(0, 0, 0)</c>.</para>
    /// <para><paramref name="position"/> is the offset from the body origin in global coordinates.</para>
    /// </summary>
    /// <param name="position">If the parameter is null, then the default value is <c>new Vector3(0.0f, 0.0f, 0.0f)</c>.</param>
    public unsafe void AddConstantForce(Vector3 force, Nullable<Vector3> position = null)
    {
        Vector3 positionOrDefVal = position.HasValue ? position.Value : new Vector3(0.0f, 0.0f, 0.0f);
        NativeCalls.godot_icall_2_977(MethodBind42, GodotObject.GetPtr(this), &force, &positionOrDefVal);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind43 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddConstantTorque, 3460891852ul);

    /// <summary>
    /// <para>Adds a constant rotational force without affecting position that keeps being applied over time until cleared with <c>constant_torque = Vector3(0, 0, 0)</c>.</para>
    /// </summary>
    public unsafe void AddConstantTorque(Vector3 torque)
    {
        NativeCalls.godot_icall_1_177(MethodBind43, GodotObject.GetPtr(this), &torque);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind44 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetConstantForce, 3460891852ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetConstantForce(Vector3 force)
    {
        NativeCalls.godot_icall_1_177(MethodBind44, GodotObject.GetPtr(this), &force);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind45 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetConstantForce, 3360562783ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector3 GetConstantForce()
    {
        return NativeCalls.godot_icall_0_125(MethodBind45, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind46 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetConstantTorque, 3460891852ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetConstantTorque(Vector3 torque)
    {
        NativeCalls.godot_icall_1_177(MethodBind46, GodotObject.GetPtr(this), &torque);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind47 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetConstantTorque, 3360562783ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector3 GetConstantTorque()
    {
        return NativeCalls.godot_icall_0_125(MethodBind47, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind48 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSleeping, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSleeping(bool sleeping)
    {
        NativeCalls.godot_icall_1_14(MethodBind48, GodotObject.GetPtr(this), sleeping.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind49 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsSleeping, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsSleeping()
    {
        return NativeCalls.godot_icall_0_15(MethodBind49, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind50 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCanSleep, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCanSleep(bool ableToSleep)
    {
        NativeCalls.godot_icall_1_14(MethodBind50, GodotObject.GetPtr(this), ableToSleep.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind51 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsAbleToSleep, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsAbleToSleep()
    {
        return NativeCalls.godot_icall_0_15(MethodBind51, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind52 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLockRotationEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetLockRotationEnabled(bool lockRotation)
    {
        NativeCalls.godot_icall_1_14(MethodBind52, GodotObject.GetPtr(this), lockRotation.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind53 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsLockRotationEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsLockRotationEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind53, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind54 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFreezeEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFreezeEnabled(bool freezeMode)
    {
        NativeCalls.godot_icall_1_14(MethodBind54, GodotObject.GetPtr(this), freezeMode.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind55 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsFreezeEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsFreezeEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind55, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind56 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFreezeMode, 1319914653ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFreezeMode(RigidBody3D.FreezeModeEnum freezeMode)
    {
        NativeCalls.godot_icall_1_38(MethodBind56, GodotObject.GetPtr(this), (int)freezeMode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind57 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFreezeMode, 2008423905ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public RigidBody3D.FreezeModeEnum GetFreezeMode()
    {
        return (RigidBody3D.FreezeModeEnum)NativeCalls.godot_icall_0_39(MethodBind57, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind58 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCollidingBodies, 3995934104ul);

    /// <summary>
    /// <para>Returns a list of the bodies colliding with this one. Requires <see cref="Godot.RigidBody3D.ContactMonitor"/> to be set to <see langword="true"/> and <see cref="Godot.RigidBody3D.MaxContactsReported"/> to be set high enough to detect all the collisions.</para>
    /// <para><b>Note:</b> The result of this test is not immediate after moving objects. For performance, list of collisions is updated once per frame and before the physics step. Consider using signals instead.</para>
    /// </summary>
    public Godot.Collections.Array<Node3D> GetCollidingBodies()
    {
        return new Godot.Collections.Array<Node3D>(NativeCalls.godot_icall_0_120(MethodBind58, GodotObject.GetPtr(this)));
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.RigidBody3D.BodyShapeEntered"/> event of a <see cref="Godot.RigidBody3D"/> class.
    /// </summary>
    public delegate void BodyShapeEnteredEventHandler(Rid bodyRid, Node body, long bodyShapeIndex, long localShapeIndex);

    private static void BodyShapeEnteredTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 4);
        ((BodyShapeEnteredEventHandler)delegateObj)(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<Node>(args[1]), VariantUtils.ConvertTo<long>(args[2]), VariantUtils.ConvertTo<long>(args[3]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when one of this RigidBody3D's <see cref="Godot.Shape3D"/>s collides with another <see cref="Godot.PhysicsBody3D"/> or <see cref="Godot.GridMap"/>'s <see cref="Godot.Shape3D"/>s. Requires <see cref="Godot.RigidBody3D.ContactMonitor"/> to be set to <see langword="true"/> and <see cref="Godot.RigidBody3D.MaxContactsReported"/> to be set high enough to detect all the collisions. <see cref="Godot.GridMap"/>s are detected if the <see cref="Godot.MeshLibrary"/> has Collision <see cref="Godot.Shape3D"/>s.</para>
    /// <para><c>bodyRid</c> the <see cref="Godot.Rid"/> of the other <see cref="Godot.PhysicsBody3D"/> or <see cref="Godot.MeshLibrary"/>'s <see cref="Godot.CollisionObject3D"/> used by the <see cref="Godot.PhysicsServer3D"/>.</para>
    /// <para><c>body</c> the <see cref="Godot.Node"/>, if it exists in the tree, of the other <see cref="Godot.PhysicsBody3D"/> or <see cref="Godot.GridMap"/>.</para>
    /// <para><c>bodyShapeIndex</c> the index of the <see cref="Godot.Shape3D"/> of the other <see cref="Godot.PhysicsBody3D"/> or <see cref="Godot.GridMap"/> used by the <see cref="Godot.PhysicsServer3D"/>. Get the <see cref="Godot.CollisionShape3D"/> node with <c>body.shape_owner_get_owner(body.shape_find_owner(body_shape_index))</c>.</para>
    /// <para><c>localShapeIndex</c> the index of the <see cref="Godot.Shape3D"/> of this RigidBody3D used by the <see cref="Godot.PhysicsServer3D"/>. Get the <see cref="Godot.CollisionShape3D"/> node with <c>self.shape_owner_get_owner(self.shape_find_owner(local_shape_index))</c>.</para>
    /// </summary>
    public unsafe event BodyShapeEnteredEventHandler BodyShapeEntered
    {
        add => Connect(SignalName.BodyShapeEntered, Callable.CreateWithUnsafeTrampoline(value, &BodyShapeEnteredTrampoline));
        remove => Disconnect(SignalName.BodyShapeEntered, Callable.CreateWithUnsafeTrampoline(value, &BodyShapeEnteredTrampoline));
    }

    protected void EmitSignalBodyShapeEntered(Rid bodyRid, Node body, long bodyShapeIndex, long localShapeIndex)
    {
        EmitSignal(SignalName.BodyShapeEntered, bodyRid, body, bodyShapeIndex, localShapeIndex);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.RigidBody3D.BodyShapeExited"/> event of a <see cref="Godot.RigidBody3D"/> class.
    /// </summary>
    public delegate void BodyShapeExitedEventHandler(Rid bodyRid, Node body, long bodyShapeIndex, long localShapeIndex);

    private static void BodyShapeExitedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 4);
        ((BodyShapeExitedEventHandler)delegateObj)(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<Node>(args[1]), VariantUtils.ConvertTo<long>(args[2]), VariantUtils.ConvertTo<long>(args[3]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when the collision between one of this RigidBody3D's <see cref="Godot.Shape3D"/>s and another <see cref="Godot.PhysicsBody3D"/> or <see cref="Godot.GridMap"/>'s <see cref="Godot.Shape3D"/>s ends. Requires <see cref="Godot.RigidBody3D.ContactMonitor"/> to be set to <see langword="true"/> and <see cref="Godot.RigidBody3D.MaxContactsReported"/> to be set high enough to detect all the collisions. <see cref="Godot.GridMap"/>s are detected if the <see cref="Godot.MeshLibrary"/> has Collision <see cref="Godot.Shape3D"/>s.</para>
    /// <para><c>bodyRid</c> the <see cref="Godot.Rid"/> of the other <see cref="Godot.PhysicsBody3D"/> or <see cref="Godot.MeshLibrary"/>'s <see cref="Godot.CollisionObject3D"/> used by the <see cref="Godot.PhysicsServer3D"/>. <see cref="Godot.GridMap"/>s are detected if the Meshes have <see cref="Godot.Shape3D"/>s.</para>
    /// <para><c>body</c> the <see cref="Godot.Node"/>, if it exists in the tree, of the other <see cref="Godot.PhysicsBody3D"/> or <see cref="Godot.GridMap"/>.</para>
    /// <para><c>bodyShapeIndex</c> the index of the <see cref="Godot.Shape3D"/> of the other <see cref="Godot.PhysicsBody3D"/> or <see cref="Godot.GridMap"/> used by the <see cref="Godot.PhysicsServer3D"/>. Get the <see cref="Godot.CollisionShape3D"/> node with <c>body.shape_owner_get_owner(body.shape_find_owner(body_shape_index))</c>.</para>
    /// <para><c>localShapeIndex</c> the index of the <see cref="Godot.Shape3D"/> of this RigidBody3D used by the <see cref="Godot.PhysicsServer3D"/>. Get the <see cref="Godot.CollisionShape3D"/> node with <c>self.shape_owner_get_owner(self.shape_find_owner(local_shape_index))</c>.</para>
    /// </summary>
    public unsafe event BodyShapeExitedEventHandler BodyShapeExited
    {
        add => Connect(SignalName.BodyShapeExited, Callable.CreateWithUnsafeTrampoline(value, &BodyShapeExitedTrampoline));
        remove => Disconnect(SignalName.BodyShapeExited, Callable.CreateWithUnsafeTrampoline(value, &BodyShapeExitedTrampoline));
    }

    protected void EmitSignalBodyShapeExited(Rid bodyRid, Node body, long bodyShapeIndex, long localShapeIndex)
    {
        EmitSignal(SignalName.BodyShapeExited, bodyRid, body, bodyShapeIndex, localShapeIndex);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.RigidBody3D.BodyEntered"/> event of a <see cref="Godot.RigidBody3D"/> class.
    /// </summary>
    public delegate void BodyEnteredEventHandler(Node body);

    private static void BodyEnteredTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((BodyEnteredEventHandler)delegateObj)(VariantUtils.ConvertTo<Node>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when a collision with another <see cref="Godot.PhysicsBody3D"/> or <see cref="Godot.GridMap"/> occurs. Requires <see cref="Godot.RigidBody3D.ContactMonitor"/> to be set to <see langword="true"/> and <see cref="Godot.RigidBody3D.MaxContactsReported"/> to be set high enough to detect all the collisions. <see cref="Godot.GridMap"/>s are detected if the <see cref="Godot.MeshLibrary"/> has Collision <see cref="Godot.Shape3D"/>s.</para>
    /// <para><c>body</c> the <see cref="Godot.Node"/>, if it exists in the tree, of the other <see cref="Godot.PhysicsBody3D"/> or <see cref="Godot.GridMap"/>.</para>
    /// </summary>
    public unsafe event BodyEnteredEventHandler BodyEntered
    {
        add => Connect(SignalName.BodyEntered, Callable.CreateWithUnsafeTrampoline(value, &BodyEnteredTrampoline));
        remove => Disconnect(SignalName.BodyEntered, Callable.CreateWithUnsafeTrampoline(value, &BodyEnteredTrampoline));
    }

    protected void EmitSignalBodyEntered(Node body)
    {
        EmitSignal(SignalName.BodyEntered, body);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.RigidBody3D.BodyExited"/> event of a <see cref="Godot.RigidBody3D"/> class.
    /// </summary>
    public delegate void BodyExitedEventHandler(Node body);

    private static void BodyExitedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((BodyExitedEventHandler)delegateObj)(VariantUtils.ConvertTo<Node>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when the collision with another <see cref="Godot.PhysicsBody3D"/> or <see cref="Godot.GridMap"/> ends. Requires <see cref="Godot.RigidBody3D.ContactMonitor"/> to be set to <see langword="true"/> and <see cref="Godot.RigidBody3D.MaxContactsReported"/> to be set high enough to detect all the collisions. <see cref="Godot.GridMap"/>s are detected if the <see cref="Godot.MeshLibrary"/> has Collision <see cref="Godot.Shape3D"/>s.</para>
    /// <para><c>body</c> the <see cref="Godot.Node"/>, if it exists in the tree, of the other <see cref="Godot.PhysicsBody3D"/> or <see cref="Godot.GridMap"/>.</para>
    /// </summary>
    public unsafe event BodyExitedEventHandler BodyExited
    {
        add => Connect(SignalName.BodyExited, Callable.CreateWithUnsafeTrampoline(value, &BodyExitedTrampoline));
        remove => Disconnect(SignalName.BodyExited, Callable.CreateWithUnsafeTrampoline(value, &BodyExitedTrampoline));
    }

    protected void EmitSignalBodyExited(Node body)
    {
        EmitSignal(SignalName.BodyExited, body);
    }

    /// <summary>
    /// <para>Emitted when the physics engine changes the body's sleeping state.</para>
    /// <para><b>Note:</b> Changing the value <see cref="Godot.RigidBody3D.Sleeping"/> will not trigger this signal. It is only emitted if the sleeping state is changed by the physics engine or <c>emit_signal("sleeping_state_changed")</c> is used.</para>
    /// </summary>
    public event Action SleepingStateChanged
    {
        add => Connect(SignalName.SleepingStateChanged, Callable.From(value));
        remove => Disconnect(SignalName.SleepingStateChanged, Callable.From(value));
    }

    protected void EmitSignalSleepingStateChanged()
    {
        EmitSignal(SignalName.SleepingStateChanged);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__integrate_forces = "_IntegrateForces";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_body_shape_entered = "BodyShapeEntered";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_body_shape_exited = "BodyShapeExited";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_body_entered = "BodyEntered";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_body_exited = "BodyExited";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_sleeping_state_changed = "SleepingStateChanged";

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
        if (signal == SignalName.BodyShapeEntered)
        {
            if (HasGodotClassSignal(SignalProxyName_body_shape_entered.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.BodyShapeExited)
        {
            if (HasGodotClassSignal(SignalProxyName_body_shape_exited.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.BodyEntered)
        {
            if (HasGodotClassSignal(SignalProxyName_body_entered.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.BodyExited)
        {
            if (HasGodotClassSignal(SignalProxyName_body_exited.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.SleepingStateChanged)
        {
            if (HasGodotClassSignal(SignalProxyName_sleeping_state_changed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        return base.HasGodotClassSignal(signal);
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : PhysicsBody3D.PropertyName
    {
        /// <summary>
        /// Cached name for the 'mass' property.
        /// </summary>
        public static readonly StringName Mass = "mass";
        /// <summary>
        /// Cached name for the 'physics_material_override' property.
        /// </summary>
        public static readonly StringName PhysicsMaterialOverride = "physics_material_override";
        /// <summary>
        /// Cached name for the 'gravity_scale' property.
        /// </summary>
        public static readonly StringName GravityScale = "gravity_scale";
        /// <summary>
        /// Cached name for the 'center_of_mass_mode' property.
        /// </summary>
        public static readonly StringName CenterOfMassMode = "center_of_mass_mode";
        /// <summary>
        /// Cached name for the 'center_of_mass' property.
        /// </summary>
        public static readonly StringName CenterOfMass = "center_of_mass";
        /// <summary>
        /// Cached name for the 'inertia' property.
        /// </summary>
        public static readonly StringName Inertia = "inertia";
        /// <summary>
        /// Cached name for the 'sleeping' property.
        /// </summary>
        public static readonly StringName Sleeping = "sleeping";
        /// <summary>
        /// Cached name for the 'can_sleep' property.
        /// </summary>
        public static readonly StringName CanSleep = "can_sleep";
        /// <summary>
        /// Cached name for the 'lock_rotation' property.
        /// </summary>
        public static readonly StringName LockRotation = "lock_rotation";
        /// <summary>
        /// Cached name for the 'freeze' property.
        /// </summary>
        public static readonly StringName Freeze = "freeze";
        /// <summary>
        /// Cached name for the 'freeze_mode' property.
        /// </summary>
        public static readonly StringName FreezeMode = "freeze_mode";
        /// <summary>
        /// Cached name for the 'custom_integrator' property.
        /// </summary>
        public static readonly StringName CustomIntegrator = "custom_integrator";
        /// <summary>
        /// Cached name for the 'continuous_cd' property.
        /// </summary>
        public static readonly StringName ContinuousCd = "continuous_cd";
        /// <summary>
        /// Cached name for the 'contact_monitor' property.
        /// </summary>
        public static readonly StringName ContactMonitor = "contact_monitor";
        /// <summary>
        /// Cached name for the 'max_contacts_reported' property.
        /// </summary>
        public static readonly StringName MaxContactsReported = "max_contacts_reported";
        /// <summary>
        /// Cached name for the 'linear_velocity' property.
        /// </summary>
        public static readonly StringName LinearVelocity = "linear_velocity";
        /// <summary>
        /// Cached name for the 'linear_damp_mode' property.
        /// </summary>
        public static readonly StringName LinearDampMode = "linear_damp_mode";
        /// <summary>
        /// Cached name for the 'linear_damp' property.
        /// </summary>
        public static readonly StringName LinearDamp = "linear_damp";
        /// <summary>
        /// Cached name for the 'angular_velocity' property.
        /// </summary>
        public static readonly StringName AngularVelocity = "angular_velocity";
        /// <summary>
        /// Cached name for the 'angular_damp_mode' property.
        /// </summary>
        public static readonly StringName AngularDampMode = "angular_damp_mode";
        /// <summary>
        /// Cached name for the 'angular_damp' property.
        /// </summary>
        public static readonly StringName AngularDamp = "angular_damp";
        /// <summary>
        /// Cached name for the 'constant_force' property.
        /// </summary>
        public static readonly StringName ConstantForce = "constant_force";
        /// <summary>
        /// Cached name for the 'constant_torque' property.
        /// </summary>
        public static readonly StringName ConstantTorque = "constant_torque";
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
        /// Cached name for the 'set_mass' method.
        /// </summary>
        public static readonly StringName SetMass = "set_mass";
        /// <summary>
        /// Cached name for the 'get_mass' method.
        /// </summary>
        public static readonly StringName GetMass = "get_mass";
        /// <summary>
        /// Cached name for the 'set_inertia' method.
        /// </summary>
        public static readonly StringName SetInertia = "set_inertia";
        /// <summary>
        /// Cached name for the 'get_inertia' method.
        /// </summary>
        public static readonly StringName GetInertia = "get_inertia";
        /// <summary>
        /// Cached name for the 'set_center_of_mass_mode' method.
        /// </summary>
        public static readonly StringName SetCenterOfMassMode = "set_center_of_mass_mode";
        /// <summary>
        /// Cached name for the 'get_center_of_mass_mode' method.
        /// </summary>
        public static readonly StringName GetCenterOfMassMode = "get_center_of_mass_mode";
        /// <summary>
        /// Cached name for the 'set_center_of_mass' method.
        /// </summary>
        public static readonly StringName SetCenterOfMass = "set_center_of_mass";
        /// <summary>
        /// Cached name for the 'get_center_of_mass' method.
        /// </summary>
        public static readonly StringName GetCenterOfMass = "get_center_of_mass";
        /// <summary>
        /// Cached name for the 'set_physics_material_override' method.
        /// </summary>
        public static readonly StringName SetPhysicsMaterialOverride = "set_physics_material_override";
        /// <summary>
        /// Cached name for the 'get_physics_material_override' method.
        /// </summary>
        public static readonly StringName GetPhysicsMaterialOverride = "get_physics_material_override";
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
        /// Cached name for the 'get_inverse_inertia_tensor' method.
        /// </summary>
        public static readonly StringName GetInverseInertiaTensor = "get_inverse_inertia_tensor";
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
        /// Cached name for the 'set_max_contacts_reported' method.
        /// </summary>
        public static readonly StringName SetMaxContactsReported = "set_max_contacts_reported";
        /// <summary>
        /// Cached name for the 'get_max_contacts_reported' method.
        /// </summary>
        public static readonly StringName GetMaxContactsReported = "get_max_contacts_reported";
        /// <summary>
        /// Cached name for the 'get_contact_count' method.
        /// </summary>
        public static readonly StringName GetContactCount = "get_contact_count";
        /// <summary>
        /// Cached name for the 'set_use_custom_integrator' method.
        /// </summary>
        public static readonly StringName SetUseCustomIntegrator = "set_use_custom_integrator";
        /// <summary>
        /// Cached name for the 'is_using_custom_integrator' method.
        /// </summary>
        public static readonly StringName IsUsingCustomIntegrator = "is_using_custom_integrator";
        /// <summary>
        /// Cached name for the 'set_contact_monitor' method.
        /// </summary>
        public static readonly StringName SetContactMonitor = "set_contact_monitor";
        /// <summary>
        /// Cached name for the 'is_contact_monitor_enabled' method.
        /// </summary>
        public static readonly StringName IsContactMonitorEnabled = "is_contact_monitor_enabled";
        /// <summary>
        /// Cached name for the 'set_use_continuous_collision_detection' method.
        /// </summary>
        public static readonly StringName SetUseContinuousCollisionDetection = "set_use_continuous_collision_detection";
        /// <summary>
        /// Cached name for the 'is_using_continuous_collision_detection' method.
        /// </summary>
        public static readonly StringName IsUsingContinuousCollisionDetection = "is_using_continuous_collision_detection";
        /// <summary>
        /// Cached name for the 'set_axis_velocity' method.
        /// </summary>
        public static readonly StringName SetAxisVelocity = "set_axis_velocity";
        /// <summary>
        /// Cached name for the 'apply_central_impulse' method.
        /// </summary>
        public static readonly StringName ApplyCentralImpulse = "apply_central_impulse";
        /// <summary>
        /// Cached name for the 'apply_impulse' method.
        /// </summary>
        public static readonly StringName ApplyImpulse = "apply_impulse";
        /// <summary>
        /// Cached name for the 'apply_torque_impulse' method.
        /// </summary>
        public static readonly StringName ApplyTorqueImpulse = "apply_torque_impulse";
        /// <summary>
        /// Cached name for the 'apply_central_force' method.
        /// </summary>
        public static readonly StringName ApplyCentralForce = "apply_central_force";
        /// <summary>
        /// Cached name for the 'apply_force' method.
        /// </summary>
        public static readonly StringName ApplyForce = "apply_force";
        /// <summary>
        /// Cached name for the 'apply_torque' method.
        /// </summary>
        public static readonly StringName ApplyTorque = "apply_torque";
        /// <summary>
        /// Cached name for the 'add_constant_central_force' method.
        /// </summary>
        public static readonly StringName AddConstantCentralForce = "add_constant_central_force";
        /// <summary>
        /// Cached name for the 'add_constant_force' method.
        /// </summary>
        public static readonly StringName AddConstantForce = "add_constant_force";
        /// <summary>
        /// Cached name for the 'add_constant_torque' method.
        /// </summary>
        public static readonly StringName AddConstantTorque = "add_constant_torque";
        /// <summary>
        /// Cached name for the 'set_constant_force' method.
        /// </summary>
        public static readonly StringName SetConstantForce = "set_constant_force";
        /// <summary>
        /// Cached name for the 'get_constant_force' method.
        /// </summary>
        public static readonly StringName GetConstantForce = "get_constant_force";
        /// <summary>
        /// Cached name for the 'set_constant_torque' method.
        /// </summary>
        public static readonly StringName SetConstantTorque = "set_constant_torque";
        /// <summary>
        /// Cached name for the 'get_constant_torque' method.
        /// </summary>
        public static readonly StringName GetConstantTorque = "get_constant_torque";
        /// <summary>
        /// Cached name for the 'set_sleeping' method.
        /// </summary>
        public static readonly StringName SetSleeping = "set_sleeping";
        /// <summary>
        /// Cached name for the 'is_sleeping' method.
        /// </summary>
        public static readonly StringName IsSleeping = "is_sleeping";
        /// <summary>
        /// Cached name for the 'set_can_sleep' method.
        /// </summary>
        public static readonly StringName SetCanSleep = "set_can_sleep";
        /// <summary>
        /// Cached name for the 'is_able_to_sleep' method.
        /// </summary>
        public static readonly StringName IsAbleToSleep = "is_able_to_sleep";
        /// <summary>
        /// Cached name for the 'set_lock_rotation_enabled' method.
        /// </summary>
        public static readonly StringName SetLockRotationEnabled = "set_lock_rotation_enabled";
        /// <summary>
        /// Cached name for the 'is_lock_rotation_enabled' method.
        /// </summary>
        public static readonly StringName IsLockRotationEnabled = "is_lock_rotation_enabled";
        /// <summary>
        /// Cached name for the 'set_freeze_enabled' method.
        /// </summary>
        public static readonly StringName SetFreezeEnabled = "set_freeze_enabled";
        /// <summary>
        /// Cached name for the 'is_freeze_enabled' method.
        /// </summary>
        public static readonly StringName IsFreezeEnabled = "is_freeze_enabled";
        /// <summary>
        /// Cached name for the 'set_freeze_mode' method.
        /// </summary>
        public static readonly StringName SetFreezeMode = "set_freeze_mode";
        /// <summary>
        /// Cached name for the 'get_freeze_mode' method.
        /// </summary>
        public static readonly StringName GetFreezeMode = "get_freeze_mode";
        /// <summary>
        /// Cached name for the 'get_colliding_bodies' method.
        /// </summary>
        public static readonly StringName GetCollidingBodies = "get_colliding_bodies";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : PhysicsBody3D.SignalName
    {
        /// <summary>
        /// Cached name for the 'body_shape_entered' signal.
        /// </summary>
        public static readonly StringName BodyShapeEntered = "body_shape_entered";
        /// <summary>
        /// Cached name for the 'body_shape_exited' signal.
        /// </summary>
        public static readonly StringName BodyShapeExited = "body_shape_exited";
        /// <summary>
        /// Cached name for the 'body_entered' signal.
        /// </summary>
        public static readonly StringName BodyEntered = "body_entered";
        /// <summary>
        /// Cached name for the 'body_exited' signal.
        /// </summary>
        public static readonly StringName BodyExited = "body_exited";
        /// <summary>
        /// Cached name for the 'sleeping_state_changed' signal.
        /// </summary>
        public static readonly StringName SleepingStateChanged = "sleeping_state_changed";
    }
}
