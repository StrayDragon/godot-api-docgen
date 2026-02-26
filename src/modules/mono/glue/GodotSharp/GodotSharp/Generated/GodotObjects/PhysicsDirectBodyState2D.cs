namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Provides direct access to a physics body in the <see cref="Godot.PhysicsServer2D"/>, allowing safe changes to physics properties. This object is passed via the direct state callback of <see cref="Godot.RigidBody2D"/>, and is intended for changing the direct state of that body. See <see cref="Godot.RigidBody2D._IntegrateForces(PhysicsDirectBodyState2D)"/>.</para>
/// </summary>
public partial class PhysicsDirectBodyState2D : GodotObject
{
    /// <summary>
    /// <para>The timestep (delta) used for the simulation.</para>
    /// </summary>
    public float Step
    {
        get
        {
            return GetStep();
        }
    }

    /// <summary>
    /// <para>The inverse of the mass of the body.</para>
    /// </summary>
    public float InverseMass
    {
        get
        {
            return GetInverseMass();
        }
    }

    /// <summary>
    /// <para>The inverse of the inertia of the body.</para>
    /// </summary>
    public float InverseInertia
    {
        get
        {
            return GetInverseInertia();
        }
    }

    /// <summary>
    /// <para>The rate at which the body stops rotating, if there are not any other forces moving it.</para>
    /// </summary>
    public float TotalAngularDamp
    {
        get
        {
            return GetTotalAngularDamp();
        }
    }

    /// <summary>
    /// <para>The rate at which the body stops moving, if there are not any other forces moving it.</para>
    /// </summary>
    public float TotalLinearDamp
    {
        get
        {
            return GetTotalLinearDamp();
        }
    }

    /// <summary>
    /// <para>The total gravity vector being currently applied to this body.</para>
    /// </summary>
    public Vector2 TotalGravity
    {
        get
        {
            return GetTotalGravity();
        }
    }

    /// <summary>
    /// <para>The body's center of mass position relative to the body's center in the global coordinate system.</para>
    /// </summary>
    public Vector2 CenterOfMass
    {
        get
        {
            return GetCenterOfMass();
        }
    }

    /// <summary>
    /// <para>The body's center of mass position in the body's local coordinate system.</para>
    /// </summary>
    public Vector2 CenterOfMassLocal
    {
        get
        {
            return GetCenterOfMassLocal();
        }
    }

    /// <summary>
    /// <para>The body's rotational velocity in <i>radians</i> per second.</para>
    /// </summary>
    public float AngularVelocity
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
    /// <para>The body's linear velocity in pixels per second.</para>
    /// </summary>
    public Vector2 LinearVelocity
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
    /// <para>If <see langword="true"/>, this body is currently sleeping (not active).</para>
    /// </summary>
    public bool Sleeping
    {
        get
        {
            return IsSleeping();
        }
        set
        {
            SetSleepState(value);
        }
    }

    /// <summary>
    /// <para>The body's collision layer.</para>
    /// </summary>
    public uint CollisionLayer
    {
        get
        {
            return GetCollisionLayer();
        }
        set
        {
            SetCollisionLayer(value);
        }
    }

    /// <summary>
    /// <para>The body's collision mask.</para>
    /// </summary>
    public uint CollisionMask
    {
        get
        {
            return GetCollisionMask();
        }
        set
        {
            SetCollisionMask(value);
        }
    }

    /// <summary>
    /// <para>The body's transformation matrix.</para>
    /// </summary>
    public Transform2D Transform
    {
        get
        {
            return GetTransform();
        }
        set
        {
            SetTransform(value);
        }
    }

    private static readonly System.Type CachedType = typeof(PhysicsDirectBodyState2D);

    private static readonly StringName NativeName = "PhysicsDirectBodyState2D";

    internal PhysicsDirectBodyState2D() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal PhysicsDirectBodyState2D(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal PhysicsDirectBodyState2D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTotalGravity, 3341600327ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2 GetTotalGravity()
    {
        return NativeCalls.godot_icall_0_37(MethodBind0, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTotalLinearDamp, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetTotalLinearDamp()
    {
        return NativeCalls.godot_icall_0_68(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTotalAngularDamp, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetTotalAngularDamp()
    {
        return NativeCalls.godot_icall_0_68(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCenterOfMass, 3341600327ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2 GetCenterOfMass()
    {
        return NativeCalls.godot_icall_0_37(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCenterOfMassLocal, 3341600327ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2 GetCenterOfMassLocal()
    {
        return NativeCalls.godot_icall_0_37(MethodBind4, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetInverseMass, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetInverseMass()
    {
        return NativeCalls.godot_icall_0_68(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetInverseInertia, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetInverseInertia()
    {
        return NativeCalls.godot_icall_0_68(MethodBind6, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLinearVelocity, 743155724ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetLinearVelocity(Vector2 velocity)
    {
        NativeCalls.godot_icall_1_36(MethodBind7, GodotObject.GetPtr(this), &velocity);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLinearVelocity, 3341600327ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2 GetLinearVelocity()
    {
        return NativeCalls.godot_icall_0_37(MethodBind8, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAngularVelocity, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAngularVelocity(float velocity)
    {
        NativeCalls.godot_icall_1_67(MethodBind9, GodotObject.GetPtr(this), velocity);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAngularVelocity, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetAngularVelocity()
    {
        return NativeCalls.godot_icall_0_68(MethodBind10, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTransform, 2761652528ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetTransform(Transform2D transform)
    {
        NativeCalls.godot_icall_1_218(MethodBind11, GodotObject.GetPtr(this), &transform);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTransform, 3814499831ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Transform2D GetTransform()
    {
        return NativeCalls.godot_icall_0_219(MethodBind12, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVelocityAtLocalPosition, 2656412154ul);

    /// <summary>
    /// <para>Returns the body's velocity at the given relative position, including both translation and rotation.</para>
    /// </summary>
    public unsafe Vector2 GetVelocityAtLocalPosition(Vector2 localPosition)
    {
        return NativeCalls.godot_icall_1_20(MethodBind13, GodotObject.GetPtr(this), &localPosition);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ApplyCentralImpulse, 743155724ul);

    /// <summary>
    /// <para>Applies a directional impulse without affecting rotation.</para>
    /// <para>An impulse is time-independent! Applying an impulse every frame would result in a framerate-dependent force. For this reason, it should only be used when simulating one-time impacts (use the "_force" functions otherwise).</para>
    /// <para>This is equivalent to using <see cref="Godot.PhysicsDirectBodyState2D.ApplyImpulse(Vector2, Nullable{Vector2})"/> at the body's center of mass.</para>
    /// </summary>
    public unsafe void ApplyCentralImpulse(Vector2 impulse)
    {
        NativeCalls.godot_icall_1_36(MethodBind14, GodotObject.GetPtr(this), &impulse);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ApplyTorqueImpulse, 373806689ul);

    /// <summary>
    /// <para>Applies a rotational impulse to the body without affecting the position.</para>
    /// <para>An impulse is time-independent! Applying an impulse every frame would result in a framerate-dependent force. For this reason, it should only be used when simulating one-time impacts (use the "_force" functions otherwise).</para>
    /// <para><b>Note:</b> <see cref="Godot.PhysicsDirectBodyState2D.InverseInertia"/> is required for this to work. To have <see cref="Godot.PhysicsDirectBodyState2D.InverseInertia"/>, an active <see cref="Godot.CollisionShape2D"/> must be a child of the node, or you can manually set <see cref="Godot.PhysicsDirectBodyState2D.InverseInertia"/>.</para>
    /// </summary>
    public void ApplyTorqueImpulse(float impulse)
    {
        NativeCalls.godot_icall_1_67(MethodBind15, GodotObject.GetPtr(this), impulse);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ApplyImpulse, 4288681949ul);

    /// <summary>
    /// <para>Applies a positioned impulse to the body.</para>
    /// <para>An impulse is time-independent! Applying an impulse every frame would result in a framerate-dependent force. For this reason, it should only be used when simulating one-time impacts (use the "_force" functions otherwise).</para>
    /// <para><paramref name="position"/> is the offset from the body origin in global coordinates.</para>
    /// </summary>
    /// <param name="position">If the parameter is null, then the default value is <c>new Vector2(0.0f, 0.0f)</c>.</param>
    public unsafe void ApplyImpulse(Vector2 impulse, Nullable<Vector2> position = null)
    {
        Vector2 positionOrDefVal = position.HasValue ? position.Value : new Vector2(0.0f, 0.0f);
        NativeCalls.godot_icall_2_982(MethodBind16, GodotObject.GetPtr(this), &impulse, &positionOrDefVal);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ApplyCentralForce, 3862383994ul);

    /// <summary>
    /// <para>Applies a directional force without affecting rotation. A force is time dependent and meant to be applied every physics update.</para>
    /// <para>This is equivalent to using <see cref="Godot.PhysicsDirectBodyState2D.ApplyForce(Vector2, Nullable{Vector2})"/> at the body's center of mass.</para>
    /// </summary>
    /// <param name="force">If the parameter is null, then the default value is <c>new Vector2(0.0f, 0.0f)</c>.</param>
    public unsafe void ApplyCentralForce(Nullable<Vector2> force = null)
    {
        Vector2 forceOrDefVal = force.HasValue ? force.Value : new Vector2(0.0f, 0.0f);
        NativeCalls.godot_icall_1_36(MethodBind17, GodotObject.GetPtr(this), &forceOrDefVal);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ApplyForce, 4288681949ul);

    /// <summary>
    /// <para>Applies a positioned force to the body. A force is time dependent and meant to be applied every physics update.</para>
    /// <para><paramref name="position"/> is the offset from the body origin in global coordinates.</para>
    /// </summary>
    /// <param name="position">If the parameter is null, then the default value is <c>new Vector2(0.0f, 0.0f)</c>.</param>
    public unsafe void ApplyForce(Vector2 force, Nullable<Vector2> position = null)
    {
        Vector2 positionOrDefVal = position.HasValue ? position.Value : new Vector2(0.0f, 0.0f);
        NativeCalls.godot_icall_2_982(MethodBind18, GodotObject.GetPtr(this), &force, &positionOrDefVal);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ApplyTorque, 373806689ul);

    /// <summary>
    /// <para>Applies a rotational force without affecting position. A force is time dependent and meant to be applied every physics update.</para>
    /// <para><b>Note:</b> <see cref="Godot.PhysicsDirectBodyState2D.InverseInertia"/> is required for this to work. To have <see cref="Godot.PhysicsDirectBodyState2D.InverseInertia"/>, an active <see cref="Godot.CollisionShape2D"/> must be a child of the node, or you can manually set <see cref="Godot.PhysicsDirectBodyState2D.InverseInertia"/>.</para>
    /// </summary>
    public void ApplyTorque(float torque)
    {
        NativeCalls.godot_icall_1_67(MethodBind19, GodotObject.GetPtr(this), torque);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddConstantCentralForce, 3862383994ul);

    /// <summary>
    /// <para>Adds a constant directional force without affecting rotation that keeps being applied over time until cleared with <c>constant_force = Vector2(0, 0)</c>.</para>
    /// <para>This is equivalent to using <see cref="Godot.PhysicsDirectBodyState2D.AddConstantForce(Vector2, Nullable{Vector2})"/> at the body's center of mass.</para>
    /// </summary>
    /// <param name="force">If the parameter is null, then the default value is <c>new Vector2(0.0f, 0.0f)</c>.</param>
    public unsafe void AddConstantCentralForce(Nullable<Vector2> force = null)
    {
        Vector2 forceOrDefVal = force.HasValue ? force.Value : new Vector2(0.0f, 0.0f);
        NativeCalls.godot_icall_1_36(MethodBind20, GodotObject.GetPtr(this), &forceOrDefVal);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddConstantForce, 4288681949ul);

    /// <summary>
    /// <para>Adds a constant positioned force to the body that keeps being applied over time until cleared with <c>constant_force = Vector2(0, 0)</c>.</para>
    /// <para><paramref name="position"/> is the offset from the body origin in global coordinates.</para>
    /// </summary>
    /// <param name="position">If the parameter is null, then the default value is <c>new Vector2(0.0f, 0.0f)</c>.</param>
    public unsafe void AddConstantForce(Vector2 force, Nullable<Vector2> position = null)
    {
        Vector2 positionOrDefVal = position.HasValue ? position.Value : new Vector2(0.0f, 0.0f);
        NativeCalls.godot_icall_2_982(MethodBind21, GodotObject.GetPtr(this), &force, &positionOrDefVal);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddConstantTorque, 373806689ul);

    /// <summary>
    /// <para>Adds a constant rotational force without affecting position that keeps being applied over time until cleared with <c>constant_torque = 0</c>.</para>
    /// </summary>
    public void AddConstantTorque(float torque)
    {
        NativeCalls.godot_icall_1_67(MethodBind22, GodotObject.GetPtr(this), torque);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetConstantForce, 743155724ul);

    /// <summary>
    /// <para>Sets the body's total constant positional forces applied during each physics update.</para>
    /// <para>See <see cref="Godot.PhysicsDirectBodyState2D.AddConstantForce(Vector2, Nullable{Vector2})"/> and <see cref="Godot.PhysicsDirectBodyState2D.AddConstantCentralForce(Nullable{Vector2})"/>.</para>
    /// </summary>
    public unsafe void SetConstantForce(Vector2 force)
    {
        NativeCalls.godot_icall_1_36(MethodBind23, GodotObject.GetPtr(this), &force);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetConstantForce, 3341600327ul);

    /// <summary>
    /// <para>Returns the body's total constant positional forces applied during each physics update.</para>
    /// <para>See <see cref="Godot.PhysicsDirectBodyState2D.AddConstantForce(Vector2, Nullable{Vector2})"/> and <see cref="Godot.PhysicsDirectBodyState2D.AddConstantCentralForce(Nullable{Vector2})"/>.</para>
    /// </summary>
    public Vector2 GetConstantForce()
    {
        return NativeCalls.godot_icall_0_37(MethodBind24, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetConstantTorque, 373806689ul);

    /// <summary>
    /// <para>Sets the body's total constant rotational forces applied during each physics update.</para>
    /// <para>See <see cref="Godot.PhysicsDirectBodyState2D.AddConstantTorque(float)"/>.</para>
    /// </summary>
    public void SetConstantTorque(float torque)
    {
        NativeCalls.godot_icall_1_67(MethodBind25, GodotObject.GetPtr(this), torque);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetConstantTorque, 1740695150ul);

    /// <summary>
    /// <para>Returns the body's total constant rotational forces applied during each physics update.</para>
    /// <para>See <see cref="Godot.PhysicsDirectBodyState2D.AddConstantTorque(float)"/>.</para>
    /// </summary>
    public float GetConstantTorque()
    {
        return NativeCalls.godot_icall_0_68(MethodBind26, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSleepState, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSleepState(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind27, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsSleeping, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsSleeping()
    {
        return NativeCalls.godot_icall_0_15(MethodBind28, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCollisionLayer, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCollisionLayer(uint layer)
    {
        NativeCalls.godot_icall_1_208(MethodBind29, GodotObject.GetPtr(this), layer);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCollisionLayer, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public uint GetCollisionLayer()
    {
        return NativeCalls.godot_icall_0_209(MethodBind30, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCollisionMask, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCollisionMask(uint mask)
    {
        NativeCalls.godot_icall_1_208(MethodBind31, GodotObject.GetPtr(this), mask);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind32 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCollisionMask, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public uint GetCollisionMask()
    {
        return NativeCalls.godot_icall_0_209(MethodBind32, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind33 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetContactCount, 3905245786ul);

    /// <summary>
    /// <para>Returns the number of contacts this body has with other bodies.</para>
    /// <para><b>Note:</b> By default, this returns 0 unless bodies are configured to monitor contacts. See <see cref="Godot.RigidBody2D.ContactMonitor"/>.</para>
    /// </summary>
    public int GetContactCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind33, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind34 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetContactLocalPosition, 2299179447ul);

    /// <summary>
    /// <para>Returns the position of the contact point on the body in the global coordinate system.</para>
    /// </summary>
    public Vector2 GetContactLocalPosition(int contactIdx)
    {
        return NativeCalls.godot_icall_1_148(MethodBind34, GodotObject.GetPtr(this), contactIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind35 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetContactLocalNormal, 2299179447ul);

    /// <summary>
    /// <para>Returns the local normal at the contact point.</para>
    /// </summary>
    public Vector2 GetContactLocalNormal(int contactIdx)
    {
        return NativeCalls.godot_icall_1_148(MethodBind35, GodotObject.GetPtr(this), contactIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind36 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetContactLocalShape, 923996154ul);

    /// <summary>
    /// <para>Returns the local shape index of the collision.</para>
    /// </summary>
    public int GetContactLocalShape(int contactIdx)
    {
        return NativeCalls.godot_icall_1_60(MethodBind36, GodotObject.GetPtr(this), contactIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind37 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetContactLocalVelocityAtPosition, 2299179447ul);

    /// <summary>
    /// <para>Returns the velocity vector at the body's contact point.</para>
    /// </summary>
    public Vector2 GetContactLocalVelocityAtPosition(int contactIdx)
    {
        return NativeCalls.godot_icall_1_148(MethodBind37, GodotObject.GetPtr(this), contactIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind38 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetContactCollider, 495598643ul);

    /// <summary>
    /// <para>Returns the collider's <see cref="Godot.Rid"/>.</para>
    /// </summary>
    public Rid GetContactCollider(int contactIdx)
    {
        return NativeCalls.godot_icall_1_425(MethodBind38, GodotObject.GetPtr(this), contactIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind39 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetContactColliderPosition, 2299179447ul);

    /// <summary>
    /// <para>Returns the position of the contact point on the collider in the global coordinate system.</para>
    /// </summary>
    public Vector2 GetContactColliderPosition(int contactIdx)
    {
        return NativeCalls.godot_icall_1_148(MethodBind39, GodotObject.GetPtr(this), contactIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind40 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetContactColliderId, 923996154ul);

    /// <summary>
    /// <para>Returns the collider's object id.</para>
    /// </summary>
    public ulong GetContactColliderId(int contactIdx)
    {
        return NativeCalls.godot_icall_1_240(MethodBind40, GodotObject.GetPtr(this), contactIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind41 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetContactColliderObject, 3332903315ul);

    /// <summary>
    /// <para>Returns the collider object. This depends on how it was created (will return a scene node if such was used to create it).</para>
    /// </summary>
    public GodotObject GetContactColliderObject(int contactIdx)
    {
        return (GodotObject)NativeCalls.godot_icall_1_335(MethodBind41, GodotObject.GetPtr(this), contactIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind42 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetContactColliderShape, 923996154ul);

    /// <summary>
    /// <para>Returns the collider's shape index.</para>
    /// </summary>
    public int GetContactColliderShape(int contactIdx)
    {
        return NativeCalls.godot_icall_1_60(MethodBind42, GodotObject.GetPtr(this), contactIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind43 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetContactColliderVelocityAtPosition, 2299179447ul);

    /// <summary>
    /// <para>Returns the velocity vector at the collider's contact point.</para>
    /// </summary>
    public Vector2 GetContactColliderVelocityAtPosition(int contactIdx)
    {
        return NativeCalls.godot_icall_1_148(MethodBind43, GodotObject.GetPtr(this), contactIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind44 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetContactImpulse, 2299179447ul);

    /// <summary>
    /// <para>Returns the impulse created by the contact.</para>
    /// </summary>
    public Vector2 GetContactImpulse(int contactIdx)
    {
        return NativeCalls.godot_icall_1_148(MethodBind44, GodotObject.GetPtr(this), contactIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind45 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetStep, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetStep()
    {
        return NativeCalls.godot_icall_0_68(MethodBind45, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind46 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IntegrateForces, 3218959716ul);

    /// <summary>
    /// <para>Updates the body's linear and angular velocity by applying gravity and damping for the equivalent of one physics tick.</para>
    /// </summary>
    public void IntegrateForces()
    {
        NativeCalls.godot_icall_0_3(MethodBind46, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind47 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSpaceState, 2506717822ul);

    /// <summary>
    /// <para>Returns the current state of the space, useful for queries.</para>
    /// </summary>
    public PhysicsDirectSpaceState2D GetSpaceState()
    {
        return (PhysicsDirectSpaceState2D)NativeCalls.godot_icall_0_53(MethodBind47, GodotObject.GetPtr(this));
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
    public new class PropertyName : GodotObject.PropertyName
    {
        /// <summary>
        /// Cached name for the 'step' property.
        /// </summary>
        public static readonly StringName Step = "step";
        /// <summary>
        /// Cached name for the 'inverse_mass' property.
        /// </summary>
        public static readonly StringName InverseMass = "inverse_mass";
        /// <summary>
        /// Cached name for the 'inverse_inertia' property.
        /// </summary>
        public static readonly StringName InverseInertia = "inverse_inertia";
        /// <summary>
        /// Cached name for the 'total_angular_damp' property.
        /// </summary>
        public static readonly StringName TotalAngularDamp = "total_angular_damp";
        /// <summary>
        /// Cached name for the 'total_linear_damp' property.
        /// </summary>
        public static readonly StringName TotalLinearDamp = "total_linear_damp";
        /// <summary>
        /// Cached name for the 'total_gravity' property.
        /// </summary>
        public static readonly StringName TotalGravity = "total_gravity";
        /// <summary>
        /// Cached name for the 'center_of_mass' property.
        /// </summary>
        public static readonly StringName CenterOfMass = "center_of_mass";
        /// <summary>
        /// Cached name for the 'center_of_mass_local' property.
        /// </summary>
        public static readonly StringName CenterOfMassLocal = "center_of_mass_local";
        /// <summary>
        /// Cached name for the 'angular_velocity' property.
        /// </summary>
        public static readonly StringName AngularVelocity = "angular_velocity";
        /// <summary>
        /// Cached name for the 'linear_velocity' property.
        /// </summary>
        public static readonly StringName LinearVelocity = "linear_velocity";
        /// <summary>
        /// Cached name for the 'sleeping' property.
        /// </summary>
        public static readonly StringName Sleeping = "sleeping";
        /// <summary>
        /// Cached name for the 'collision_layer' property.
        /// </summary>
        public static readonly StringName CollisionLayer = "collision_layer";
        /// <summary>
        /// Cached name for the 'collision_mask' property.
        /// </summary>
        public static readonly StringName CollisionMask = "collision_mask";
        /// <summary>
        /// Cached name for the 'transform' property.
        /// </summary>
        public static readonly StringName Transform = "transform";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : GodotObject.MethodName
    {
        /// <summary>
        /// Cached name for the 'get_total_gravity' method.
        /// </summary>
        public static readonly StringName GetTotalGravity = "get_total_gravity";
        /// <summary>
        /// Cached name for the 'get_total_linear_damp' method.
        /// </summary>
        public static readonly StringName GetTotalLinearDamp = "get_total_linear_damp";
        /// <summary>
        /// Cached name for the 'get_total_angular_damp' method.
        /// </summary>
        public static readonly StringName GetTotalAngularDamp = "get_total_angular_damp";
        /// <summary>
        /// Cached name for the 'get_center_of_mass' method.
        /// </summary>
        public static readonly StringName GetCenterOfMass = "get_center_of_mass";
        /// <summary>
        /// Cached name for the 'get_center_of_mass_local' method.
        /// </summary>
        public static readonly StringName GetCenterOfMassLocal = "get_center_of_mass_local";
        /// <summary>
        /// Cached name for the 'get_inverse_mass' method.
        /// </summary>
        public static readonly StringName GetInverseMass = "get_inverse_mass";
        /// <summary>
        /// Cached name for the 'get_inverse_inertia' method.
        /// </summary>
        public static readonly StringName GetInverseInertia = "get_inverse_inertia";
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
        /// Cached name for the 'set_transform' method.
        /// </summary>
        public static readonly StringName SetTransform = "set_transform";
        /// <summary>
        /// Cached name for the 'get_transform' method.
        /// </summary>
        public static readonly StringName GetTransform = "get_transform";
        /// <summary>
        /// Cached name for the 'get_velocity_at_local_position' method.
        /// </summary>
        public static readonly StringName GetVelocityAtLocalPosition = "get_velocity_at_local_position";
        /// <summary>
        /// Cached name for the 'apply_central_impulse' method.
        /// </summary>
        public static readonly StringName ApplyCentralImpulse = "apply_central_impulse";
        /// <summary>
        /// Cached name for the 'apply_torque_impulse' method.
        /// </summary>
        public static readonly StringName ApplyTorqueImpulse = "apply_torque_impulse";
        /// <summary>
        /// Cached name for the 'apply_impulse' method.
        /// </summary>
        public static readonly StringName ApplyImpulse = "apply_impulse";
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
        /// Cached name for the 'set_sleep_state' method.
        /// </summary>
        public static readonly StringName SetSleepState = "set_sleep_state";
        /// <summary>
        /// Cached name for the 'is_sleeping' method.
        /// </summary>
        public static readonly StringName IsSleeping = "is_sleeping";
        /// <summary>
        /// Cached name for the 'set_collision_layer' method.
        /// </summary>
        public static readonly StringName SetCollisionLayer = "set_collision_layer";
        /// <summary>
        /// Cached name for the 'get_collision_layer' method.
        /// </summary>
        public static readonly StringName GetCollisionLayer = "get_collision_layer";
        /// <summary>
        /// Cached name for the 'set_collision_mask' method.
        /// </summary>
        public static readonly StringName SetCollisionMask = "set_collision_mask";
        /// <summary>
        /// Cached name for the 'get_collision_mask' method.
        /// </summary>
        public static readonly StringName GetCollisionMask = "get_collision_mask";
        /// <summary>
        /// Cached name for the 'get_contact_count' method.
        /// </summary>
        public static readonly StringName GetContactCount = "get_contact_count";
        /// <summary>
        /// Cached name for the 'get_contact_local_position' method.
        /// </summary>
        public static readonly StringName GetContactLocalPosition = "get_contact_local_position";
        /// <summary>
        /// Cached name for the 'get_contact_local_normal' method.
        /// </summary>
        public static readonly StringName GetContactLocalNormal = "get_contact_local_normal";
        /// <summary>
        /// Cached name for the 'get_contact_local_shape' method.
        /// </summary>
        public static readonly StringName GetContactLocalShape = "get_contact_local_shape";
        /// <summary>
        /// Cached name for the 'get_contact_local_velocity_at_position' method.
        /// </summary>
        public static readonly StringName GetContactLocalVelocityAtPosition = "get_contact_local_velocity_at_position";
        /// <summary>
        /// Cached name for the 'get_contact_collider' method.
        /// </summary>
        public static readonly StringName GetContactCollider = "get_contact_collider";
        /// <summary>
        /// Cached name for the 'get_contact_collider_position' method.
        /// </summary>
        public static readonly StringName GetContactColliderPosition = "get_contact_collider_position";
        /// <summary>
        /// Cached name for the 'get_contact_collider_id' method.
        /// </summary>
        public static readonly StringName GetContactColliderId = "get_contact_collider_id";
        /// <summary>
        /// Cached name for the 'get_contact_collider_object' method.
        /// </summary>
        public static readonly StringName GetContactColliderObject = "get_contact_collider_object";
        /// <summary>
        /// Cached name for the 'get_contact_collider_shape' method.
        /// </summary>
        public static readonly StringName GetContactColliderShape = "get_contact_collider_shape";
        /// <summary>
        /// Cached name for the 'get_contact_collider_velocity_at_position' method.
        /// </summary>
        public static readonly StringName GetContactColliderVelocityAtPosition = "get_contact_collider_velocity_at_position";
        /// <summary>
        /// Cached name for the 'get_contact_impulse' method.
        /// </summary>
        public static readonly StringName GetContactImpulse = "get_contact_impulse";
        /// <summary>
        /// Cached name for the 'get_step' method.
        /// </summary>
        public static readonly StringName GetStep = "get_step";
        /// <summary>
        /// Cached name for the 'integrate_forces' method.
        /// </summary>
        public static readonly StringName IntegrateForces = "integrate_forces";
        /// <summary>
        /// Cached name for the 'get_space_state' method.
        /// </summary>
        public static readonly StringName GetSpaceState = "get_space_state";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : GodotObject.SignalName
    {
    }
}
