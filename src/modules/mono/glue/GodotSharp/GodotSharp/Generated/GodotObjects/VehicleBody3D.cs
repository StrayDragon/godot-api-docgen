namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This physics body implements all the physics logic needed to simulate a car. It is based on the raycast vehicle system commonly found in physics engines. Aside from a <see cref="Godot.CollisionShape3D"/> for the main body of the vehicle, you must also add a <see cref="Godot.VehicleWheel3D"/> node for each wheel. You should also add a <see cref="Godot.MeshInstance3D"/> to this node for the 3D model of the vehicle, but this model should generally not include meshes for the wheels. You can control the vehicle by using the <see cref="Godot.VehicleBody3D.Brake"/>, <see cref="Godot.VehicleBody3D.EngineForce"/>, and <see cref="Godot.VehicleBody3D.Steering"/> properties. The position or orientation of this node shouldn't be changed directly.</para>
/// <para><b>Note:</b> The local forward for this node is <c>Vector3.MODEL_FRONT</c>.</para>
/// <para><b>Note:</b> The origin point of your VehicleBody3D will determine the center of gravity of your vehicle. To make the vehicle more grounded, the origin point is usually kept low, moving the <see cref="Godot.CollisionShape3D"/> and <see cref="Godot.MeshInstance3D"/> upwards.</para>
/// <para><b>Note:</b> This class has known issues and isn't designed to provide realistic 3D vehicle physics. If you want advanced vehicle physics, you may have to write your own physics integration using <see cref="Godot.CharacterBody3D"/> or <see cref="Godot.RigidBody3D"/>.</para>
/// </summary>
public partial class VehicleBody3D : RigidBody3D
{
    /// <summary>
    /// <para>Accelerates the vehicle by applying an engine force. The vehicle is only sped up if the wheels that have <see cref="Godot.VehicleWheel3D.UseAsTraction"/> set to <see langword="true"/> and are in contact with a surface. The <see cref="Godot.RigidBody3D.Mass"/> of the vehicle has an effect on the acceleration of the vehicle. For a vehicle with a mass set to 1000, try a value in the 25 - 50 range for acceleration.</para>
    /// <para><b>Note:</b> The simulation does not take the effect of gears into account, you will need to add logic for this if you wish to simulate gears.</para>
    /// <para>A negative value will result in the vehicle reversing.</para>
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
    /// <para>Slows down the vehicle by applying a braking force. The vehicle is only slowed down if the wheels are in contact with a surface. The force you need to apply to adequately slow down your vehicle depends on the <see cref="Godot.RigidBody3D.Mass"/> of the vehicle. For a vehicle with a mass set to 1000, try a value in the 25 - 30 range for hard braking.</para>
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
    /// <para>The steering angle for the vehicle. Setting this to a non-zero value will result in the vehicle turning when it's moving. Wheels that have <see cref="Godot.VehicleWheel3D.UseAsSteering"/> set to <see langword="true"/> will automatically be rotated.</para>
    /// <para><b>Note:</b> This property is edited in the inspector in degrees. In code the property is set in radians.</para>
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

    private static readonly System.Type CachedType = typeof(VehicleBody3D);

    private static readonly StringName NativeName = "VehicleBody3D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public VehicleBody3D() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal VehicleBody3D(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal VehicleBody3D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEngineForce, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEngineForce(float engineForce)
    {
        NativeCalls.godot_icall_1_67(MethodBind0, GodotObject.GetPtr(this), engineForce);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEngineForce, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetEngineForce()
    {
        return NativeCalls.godot_icall_0_68(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBrake, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetBrake(float brake)
    {
        NativeCalls.godot_icall_1_67(MethodBind2, GodotObject.GetPtr(this), brake);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBrake, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetBrake()
    {
        return NativeCalls.godot_icall_0_68(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSteering, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSteering(float steering)
    {
        NativeCalls.godot_icall_1_67(MethodBind4, GodotObject.GetPtr(this), steering);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSteering, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetSteering()
    {
        return NativeCalls.godot_icall_0_68(MethodBind5, GodotObject.GetPtr(this));
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
    public new class PropertyName : RigidBody3D.PropertyName
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
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : RigidBody3D.MethodName
    {
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
    public new class SignalName : RigidBody3D.SignalName
    {
    }
}
