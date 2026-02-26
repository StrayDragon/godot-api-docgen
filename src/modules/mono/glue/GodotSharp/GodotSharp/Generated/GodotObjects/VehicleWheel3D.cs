namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A node used as a child of a <see cref="Godot.VehicleBody3D"/> parent to simulate the behavior of one of its wheels. This node also acts as a collider to detect if the wheel is touching a surface.</para>
/// <para><b>Note:</b> This class has known issues and isn't designed to provide realistic 3D vehicle physics. If you want advanced vehicle physics, you may need to write your own physics integration using another <see cref="Godot.PhysicsBody3D"/> class.</para>
/// </summary>
public partial class VehicleWheel3D : Node3D
{
    /// <summary>
    /// <para>Accelerates the wheel by applying an engine force. The wheel is only sped up if it is in contact with a surface. The <see cref="Godot.RigidBody3D.Mass"/> of the vehicle has an effect on the acceleration of the vehicle. For a vehicle with a mass set to 1000, try a value in the 25 - 50 range for acceleration.</para>
    /// <para><b>Note:</b> The simulation does not take the effect of gears into account, you will need to add logic for this if you wish to simulate gears.</para>
    /// <para>A negative value will result in the wheel reversing.</para>
    /// </summary>
    public float EngineForce
    {
        get
        {
            return GetEngineForce();
        }
        set
        {
            SetEngineForce(value);
        }
    }

    /// <summary>
    /// <para>Slows down the wheel by applying a braking force. The wheel is only slowed down if it is in contact with a surface. The force you need to apply to adequately slow down your vehicle depends on the <see cref="Godot.RigidBody3D.Mass"/> of the vehicle. For a vehicle with a mass set to 1000, try a value in the 25 - 30 range for hard braking.</para>
    /// </summary>
    public float Brake
    {
        get
        {
            return GetBrake();
        }
        set
        {
            SetBrake(value);
        }
    }

    /// <summary>
    /// <para>The steering angle for the wheel, in radians. Setting this to a non-zero value will result in the vehicle turning when it's moving.</para>
    /// </summary>
    public float Steering
    {
        get
        {
            return GetSteering();
        }
        set
        {
            SetSteering(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, this wheel transfers engine force to the ground to propel the vehicle forward. This value is used in conjunction with <see cref="Godot.VehicleBody3D.EngineForce"/> and ignored if you are using the per-wheel <see cref="Godot.VehicleWheel3D.EngineForce"/> value instead.</para>
    /// </summary>
    public bool UseAsTraction
    {
        get
        {
            return IsUsedAsTraction();
        }
        set
        {
            SetUseAsTraction(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, this wheel will be turned when the car steers. This value is used in conjunction with <see cref="Godot.VehicleBody3D.Steering"/> and ignored if you are using the per-wheel <see cref="Godot.VehicleWheel3D.Steering"/> value instead.</para>
    /// </summary>
    public bool UseAsSteering
    {
        get
        {
            return IsUsedAsSteering();
        }
        set
        {
            SetUseAsSteering(value);
        }
    }

    /// <summary>
    /// <para>This value affects the roll of your vehicle. If set to 1.0 for all wheels, your vehicle will resist body roll, while a value of 0.0 will be prone to rolling over.</para>
    /// </summary>
    public float WheelRollInfluence
    {
        get
        {
            return GetRollInfluence();
        }
        set
        {
            SetRollInfluence(value);
        }
    }

    /// <summary>
    /// <para>The radius of the wheel in meters.</para>
    /// </summary>
    public float WheelRadius
    {
        get
        {
            return GetRadius();
        }
        set
        {
            SetRadius(value);
        }
    }

    /// <summary>
    /// <para>This is the distance in meters the wheel is lowered from its origin point. Don't set this to 0.0 and move the wheel into position, instead move the origin point of your wheel (the gizmo in Godot) to the position the wheel will take when bottoming out, then use the rest length to move the wheel down to the position it should be in when the car is in rest.</para>
    /// </summary>
    public float WheelRestLength
    {
        get
        {
            return GetSuspensionRestLength();
        }
        set
        {
            SetSuspensionRestLength(value);
        }
    }

    /// <summary>
    /// <para>This determines how much grip this wheel has. It is combined with the friction setting of the surface the wheel is in contact with. 0.0 means no grip, 1.0 is normal grip. For a drift car setup, try setting the grip of the rear wheels slightly lower than the front wheels, or use a lower value to simulate tire wear.</para>
    /// <para>It's best to set this to 1.0 when starting out.</para>
    /// </summary>
    public float WheelFrictionSlip
    {
        get
        {
            return GetFrictionSlip();
        }
        set
        {
            SetFrictionSlip(value);
        }
    }

    /// <summary>
    /// <para>This is the distance the suspension can travel. As Godot units are equivalent to meters, keep this setting relatively low. Try a value between 0.1 and 0.3 depending on the type of car.</para>
    /// </summary>
    public float SuspensionTravel
    {
        get
        {
            return GetSuspensionTravel();
        }
        set
        {
            SetSuspensionTravel(value);
        }
    }

    /// <summary>
    /// <para>The stiffness of the suspension, measured in Newtons per millimeter (N/mm), or megagrams per second squared (Mg/s²). Use a value lower than 50 for an off-road car, a value between 50 and 100 for a race car and try something around 200 for something like a Formula 1 car.</para>
    /// </summary>
    public float SuspensionStiffness
    {
        get
        {
            return GetSuspensionStiffness();
        }
        set
        {
            SetSuspensionStiffness(value);
        }
    }

    /// <summary>
    /// <para>The maximum force the spring can resist. This value should be higher than a quarter of the <see cref="Godot.RigidBody3D.Mass"/> of the <see cref="Godot.VehicleBody3D"/> or the spring will not carry the weight of the vehicle. Good results are often obtained by a value that is about 3× to 4× this number.</para>
    /// </summary>
    public float SuspensionMaxForce
    {
        get
        {
            return GetSuspensionMaxForce();
        }
        set
        {
            SetSuspensionMaxForce(value);
        }
    }

    /// <summary>
    /// <para>The damping applied to the suspension spring when being compressed, meaning when the wheel is moving up relative to the vehicle. It is measured in Newton-seconds per millimeter (N⋅s/mm), or megagrams per second (Mg/s). This value should be between 0.0 (no damping) and 1.0, but may be more. A value of 0.0 means the car will keep bouncing as the spring keeps its energy. A good value for this is around 0.3 for a normal car, 0.5 for a race car.</para>
    /// </summary>
    public float DampingCompression
    {
        get
        {
            return GetDampingCompression();
        }
        set
        {
            SetDampingCompression(value);
        }
    }

    /// <summary>
    /// <para>The damping applied to the suspension spring when rebounding or extending, meaning when the wheel is moving down relative to the vehicle. It is measured in Newton-seconds per millimeter (N⋅s/mm), or megagrams per second (Mg/s). This value should be between 0.0 (no damping) and 1.0, but may be more. This value should always be slightly higher than the <see cref="Godot.VehicleWheel3D.DampingCompression"/> property. For a <see cref="Godot.VehicleWheel3D.DampingCompression"/> value of 0.3, try a relaxation value of 0.5.</para>
    /// </summary>
    public float DampingRelaxation
    {
        get
        {
            return GetDampingRelaxation();
        }
        set
        {
            SetDampingRelaxation(value);
        }
    }

    private static readonly System.Type CachedType = typeof(VehicleWheel3D);

    private static readonly StringName NativeName = "VehicleWheel3D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public VehicleWheel3D() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal VehicleWheel3D(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal VehicleWheel3D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRadius, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetRadius(float length)
    {
        NativeCalls.godot_icall_1_67(MethodBind0, GodotObject.GetPtr(this), length);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRadius, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetRadius()
    {
        return NativeCalls.godot_icall_0_68(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSuspensionRestLength, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSuspensionRestLength(float length)
    {
        NativeCalls.godot_icall_1_67(MethodBind2, GodotObject.GetPtr(this), length);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSuspensionRestLength, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetSuspensionRestLength()
    {
        return NativeCalls.godot_icall_0_68(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSuspensionTravel, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSuspensionTravel(float length)
    {
        NativeCalls.godot_icall_1_67(MethodBind4, GodotObject.GetPtr(this), length);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSuspensionTravel, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetSuspensionTravel()
    {
        return NativeCalls.godot_icall_0_68(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSuspensionStiffness, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSuspensionStiffness(float length)
    {
        NativeCalls.godot_icall_1_67(MethodBind6, GodotObject.GetPtr(this), length);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSuspensionStiffness, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetSuspensionStiffness()
    {
        return NativeCalls.godot_icall_0_68(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSuspensionMaxForce, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSuspensionMaxForce(float length)
    {
        NativeCalls.godot_icall_1_67(MethodBind8, GodotObject.GetPtr(this), length);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSuspensionMaxForce, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetSuspensionMaxForce()
    {
        return NativeCalls.godot_icall_0_68(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDampingCompression, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDampingCompression(float length)
    {
        NativeCalls.godot_icall_1_67(MethodBind10, GodotObject.GetPtr(this), length);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDampingCompression, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetDampingCompression()
    {
        return NativeCalls.godot_icall_0_68(MethodBind11, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDampingRelaxation, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDampingRelaxation(float length)
    {
        NativeCalls.godot_icall_1_67(MethodBind12, GodotObject.GetPtr(this), length);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDampingRelaxation, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetDampingRelaxation()
    {
        return NativeCalls.godot_icall_0_68(MethodBind13, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetUseAsTraction, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetUseAsTraction(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind14, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsUsedAsTraction, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsUsedAsTraction()
    {
        return NativeCalls.godot_icall_0_15(MethodBind15, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetUseAsSteering, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetUseAsSteering(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind16, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsUsedAsSteering, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsUsedAsSteering()
    {
        return NativeCalls.godot_icall_0_15(MethodBind17, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFrictionSlip, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFrictionSlip(float length)
    {
        NativeCalls.godot_icall_1_67(MethodBind18, GodotObject.GetPtr(this), length);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFrictionSlip, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetFrictionSlip()
    {
        return NativeCalls.godot_icall_0_68(MethodBind19, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsInContact, 36873697ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if this wheel is in contact with a surface.</para>
    /// </summary>
    public bool IsInContact()
    {
        return NativeCalls.godot_icall_0_15(MethodBind20, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetContactBody, 151077316ul);

    /// <summary>
    /// <para>Returns the contacting body node if valid in the tree, as <see cref="Godot.Node3D"/>. At the moment, <see cref="Godot.GridMap"/> is not supported so the node will be always of type <see cref="Godot.PhysicsBody3D"/>.</para>
    /// <para>Returns <see langword="null"/> if the wheel is not in contact with a surface, or the contact body is not a <see cref="Godot.PhysicsBody3D"/>.</para>
    /// </summary>
    public Node3D GetContactBody()
    {
        return (Node3D)NativeCalls.godot_icall_0_53(MethodBind21, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetContactPoint, 3360562783ul);

    /// <summary>
    /// <para>Returns the point of the suspension's collision in world space if the wheel is in contact. If the wheel isn't in contact with anything, returns the maximum point of the wheel's ray cast in world space, which is defined by <c>wheel_rest_length + wheel_radius</c>.</para>
    /// </summary>
    public Vector3 GetContactPoint()
    {
        return NativeCalls.godot_icall_0_125(MethodBind22, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetContactNormal, 3360562783ul);

    /// <summary>
    /// <para>Returns the normal of the suspension's collision in world space if the wheel is in contact. If the wheel isn't in contact with anything, returns a vector pointing directly along the suspension axis toward the vehicle in world space.</para>
    /// </summary>
    public Vector3 GetContactNormal()
    {
        return NativeCalls.godot_icall_0_125(MethodBind23, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRollInfluence, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetRollInfluence(float rollInfluence)
    {
        NativeCalls.godot_icall_1_67(MethodBind24, GodotObject.GetPtr(this), rollInfluence);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRollInfluence, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetRollInfluence()
    {
        return NativeCalls.godot_icall_0_68(MethodBind25, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSkidinfo, 1740695150ul);

    /// <summary>
    /// <para>Returns a value between 0.0 and 1.0 that indicates whether this wheel is skidding. 0.0 is skidding (the wheel has lost grip, e.g. icy terrain), 1.0 means not skidding (the wheel has full grip, e.g. dry asphalt road).</para>
    /// </summary>
    public float GetSkidinfo()
    {
        return NativeCalls.godot_icall_0_68(MethodBind26, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRpm, 1740695150ul);

    /// <summary>
    /// <para>Returns the rotational speed of the wheel in revolutions per minute.</para>
    /// </summary>
    public float GetRpm()
    {
        return NativeCalls.godot_icall_0_68(MethodBind27, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEngineForce, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEngineForce(float engineForce)
    {
        NativeCalls.godot_icall_1_67(MethodBind28, GodotObject.GetPtr(this), engineForce);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEngineForce, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetEngineForce()
    {
        return NativeCalls.godot_icall_0_68(MethodBind29, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBrake, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetBrake(float brake)
    {
        NativeCalls.godot_icall_1_67(MethodBind30, GodotObject.GetPtr(this), brake);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBrake, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetBrake()
    {
        return NativeCalls.godot_icall_0_68(MethodBind31, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind32 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSteering, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSteering(float steering)
    {
        NativeCalls.godot_icall_1_67(MethodBind32, GodotObject.GetPtr(this), steering);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind33 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSteering, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetSteering()
    {
        return NativeCalls.godot_icall_0_68(MethodBind33, GodotObject.GetPtr(this));
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
    public new class PropertyName : Node3D.PropertyName
    {
        /// <summary>
        /// Cached name for the 'engine_force' property.
        /// </summary>
        public static readonly StringName EngineForce = "engine_force";
        /// <summary>
        /// Cached name for the 'brake' property.
        /// </summary>
        public static readonly StringName Brake = "brake";
        /// <summary>
        /// Cached name for the 'steering' property.
        /// </summary>
        public static readonly StringName Steering = "steering";
        /// <summary>
        /// Cached name for the 'use_as_traction' property.
        /// </summary>
        public static readonly StringName UseAsTraction = "use_as_traction";
        /// <summary>
        /// Cached name for the 'use_as_steering' property.
        /// </summary>
        public static readonly StringName UseAsSteering = "use_as_steering";
        /// <summary>
        /// Cached name for the 'wheel_roll_influence' property.
        /// </summary>
        public static readonly StringName WheelRollInfluence = "wheel_roll_influence";
        /// <summary>
        /// Cached name for the 'wheel_radius' property.
        /// </summary>
        public static readonly StringName WheelRadius = "wheel_radius";
        /// <summary>
        /// Cached name for the 'wheel_rest_length' property.
        /// </summary>
        public static readonly StringName WheelRestLength = "wheel_rest_length";
        /// <summary>
        /// Cached name for the 'wheel_friction_slip' property.
        /// </summary>
        public static readonly StringName WheelFrictionSlip = "wheel_friction_slip";
        /// <summary>
        /// Cached name for the 'suspension_travel' property.
        /// </summary>
        public static readonly StringName SuspensionTravel = "suspension_travel";
        /// <summary>
        /// Cached name for the 'suspension_stiffness' property.
        /// </summary>
        public static readonly StringName SuspensionStiffness = "suspension_stiffness";
        /// <summary>
        /// Cached name for the 'suspension_max_force' property.
        /// </summary>
        public static readonly StringName SuspensionMaxForce = "suspension_max_force";
        /// <summary>
        /// Cached name for the 'damping_compression' property.
        /// </summary>
        public static readonly StringName DampingCompression = "damping_compression";
        /// <summary>
        /// Cached name for the 'damping_relaxation' property.
        /// </summary>
        public static readonly StringName DampingRelaxation = "damping_relaxation";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Node3D.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_radius' method.
        /// </summary>
        public static readonly StringName SetRadius = "set_radius";
        /// <summary>
        /// Cached name for the 'get_radius' method.
        /// </summary>
        public static readonly StringName GetRadius = "get_radius";
        /// <summary>
        /// Cached name for the 'set_suspension_rest_length' method.
        /// </summary>
        public static readonly StringName SetSuspensionRestLength = "set_suspension_rest_length";
        /// <summary>
        /// Cached name for the 'get_suspension_rest_length' method.
        /// </summary>
        public static readonly StringName GetSuspensionRestLength = "get_suspension_rest_length";
        /// <summary>
        /// Cached name for the 'set_suspension_travel' method.
        /// </summary>
        public static readonly StringName SetSuspensionTravel = "set_suspension_travel";
        /// <summary>
        /// Cached name for the 'get_suspension_travel' method.
        /// </summary>
        public static readonly StringName GetSuspensionTravel = "get_suspension_travel";
        /// <summary>
        /// Cached name for the 'set_suspension_stiffness' method.
        /// </summary>
        public static readonly StringName SetSuspensionStiffness = "set_suspension_stiffness";
        /// <summary>
        /// Cached name for the 'get_suspension_stiffness' method.
        /// </summary>
        public static readonly StringName GetSuspensionStiffness = "get_suspension_stiffness";
        /// <summary>
        /// Cached name for the 'set_suspension_max_force' method.
        /// </summary>
        public static readonly StringName SetSuspensionMaxForce = "set_suspension_max_force";
        /// <summary>
        /// Cached name for the 'get_suspension_max_force' method.
        /// </summary>
        public static readonly StringName GetSuspensionMaxForce = "get_suspension_max_force";
        /// <summary>
        /// Cached name for the 'set_damping_compression' method.
        /// </summary>
        public static readonly StringName SetDampingCompression = "set_damping_compression";
        /// <summary>
        /// Cached name for the 'get_damping_compression' method.
        /// </summary>
        public static readonly StringName GetDampingCompression = "get_damping_compression";
        /// <summary>
        /// Cached name for the 'set_damping_relaxation' method.
        /// </summary>
        public static readonly StringName SetDampingRelaxation = "set_damping_relaxation";
        /// <summary>
        /// Cached name for the 'get_damping_relaxation' method.
        /// </summary>
        public static readonly StringName GetDampingRelaxation = "get_damping_relaxation";
        /// <summary>
        /// Cached name for the 'set_use_as_traction' method.
        /// </summary>
        public static readonly StringName SetUseAsTraction = "set_use_as_traction";
        /// <summary>
        /// Cached name for the 'is_used_as_traction' method.
        /// </summary>
        public static readonly StringName IsUsedAsTraction = "is_used_as_traction";
        /// <summary>
        /// Cached name for the 'set_use_as_steering' method.
        /// </summary>
        public static readonly StringName SetUseAsSteering = "set_use_as_steering";
        /// <summary>
        /// Cached name for the 'is_used_as_steering' method.
        /// </summary>
        public static readonly StringName IsUsedAsSteering = "is_used_as_steering";
        /// <summary>
        /// Cached name for the 'set_friction_slip' method.
        /// </summary>
        public static readonly StringName SetFrictionSlip = "set_friction_slip";
        /// <summary>
        /// Cached name for the 'get_friction_slip' method.
        /// </summary>
        public static readonly StringName GetFrictionSlip = "get_friction_slip";
        /// <summary>
        /// Cached name for the 'is_in_contact' method.
        /// </summary>
        public static readonly StringName IsInContact = "is_in_contact";
        /// <summary>
        /// Cached name for the 'get_contact_body' method.
        /// </summary>
        public static readonly StringName GetContactBody = "get_contact_body";
        /// <summary>
        /// Cached name for the 'get_contact_point' method.
        /// </summary>
        public static readonly StringName GetContactPoint = "get_contact_point";
        /// <summary>
        /// Cached name for the 'get_contact_normal' method.
        /// </summary>
        public static readonly StringName GetContactNormal = "get_contact_normal";
        /// <summary>
        /// Cached name for the 'set_roll_influence' method.
        /// </summary>
        public static readonly StringName SetRollInfluence = "set_roll_influence";
        /// <summary>
        /// Cached name for the 'get_roll_influence' method.
        /// </summary>
        public static readonly StringName GetRollInfluence = "get_roll_influence";
        /// <summary>
        /// Cached name for the 'get_skidinfo' method.
        /// </summary>
        public static readonly StringName GetSkidinfo = "get_skidinfo";
        /// <summary>
        /// Cached name for the 'get_rpm' method.
        /// </summary>
        public static readonly StringName GetRpm = "get_rpm";
        /// <summary>
        /// Cached name for the 'set_engine_force' method.
        /// </summary>
        public static readonly StringName SetEngineForce = "set_engine_force";
        /// <summary>
        /// Cached name for the 'get_engine_force' method.
        /// </summary>
        public static readonly StringName GetEngineForce = "get_engine_force";
        /// <summary>
        /// Cached name for the 'set_brake' method.
        /// </summary>
        public static readonly StringName SetBrake = "set_brake";
        /// <summary>
        /// Cached name for the 'get_brake' method.
        /// </summary>
        public static readonly StringName GetBrake = "get_brake";
        /// <summary>
        /// Cached name for the 'set_steering' method.
        /// </summary>
        public static readonly StringName SetSteering = "set_steering";
        /// <summary>
        /// Cached name for the 'get_steering' method.
        /// </summary>
        public static readonly StringName GetSteering = "get_steering";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Node3D.SignalName
    {
    }
}
