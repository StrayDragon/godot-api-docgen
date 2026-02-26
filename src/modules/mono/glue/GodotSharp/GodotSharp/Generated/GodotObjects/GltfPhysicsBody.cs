namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Represents a physics body as an intermediary between the <c>OMI_physics_body</c> glTF data and Godot's nodes, and it's abstracted in a way that allows adding support for different glTF physics extensions in the future.</para>
/// </summary>
[GodotClassName("GLTFPhysicsBody")]
public partial class GltfPhysicsBody : Resource
{
    /// <summary>
    /// <para>The type of the body.</para>
    /// <para>When importing, this controls what type of <see cref="Godot.CollisionObject3D"/> node Godot should generate. Valid values are <c>"static"</c>, <c>"animatable"</c>, <c>"character"</c>, <c>"rigid"</c>, <c>"vehicle"</c>, and <c>"trigger"</c>.</para>
    /// <para>When exporting, this will be squashed down to one of <c>"static"</c>, <c>"kinematic"</c>, or <c>"dynamic"</c> motion types, or the <c>"trigger"</c> property.</para>
    /// </summary>
    public string BodyType
    {
        get
        {
            return GetBodyType();
        }
        set
        {
            SetBodyType(value);
        }
    }

    /// <summary>
    /// <para>The mass of the physics body, in kilograms. This is only used when the body type is "rigid" or "vehicle".</para>
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
    /// <para>The linear velocity of the physics body, in meters per second. This is only used when the body type is "rigid" or "vehicle".</para>
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
    /// <para>The angular velocity of the physics body, in radians per second. This is only used when the body type is "rigid" or "vehicle".</para>
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
    /// <para>The center of mass of the body, in meters. This is in local space relative to the body. By default, the center of the mass is the body's origin.</para>
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
    /// <para>The inertia strength of the physics body, in kilogram meter squared (kg⋅m²). This represents the inertia around the principle axes, the diagonal of the inertia tensor matrix. This is only used when the body type is "rigid" or "vehicle".</para>
    /// <para>When converted to a Godot <see cref="Godot.RigidBody3D"/> node, if this value is zero, then the inertia will be calculated automatically.</para>
    /// </summary>
    public Vector3 InertiaDiagonal
    {
        get
        {
            return GetInertiaDiagonal();
        }
        set
        {
            SetInertiaDiagonal(value);
        }
    }

    /// <summary>
    /// <para>The inertia orientation of the physics body. This defines the rotation of the inertia's principle axes relative to the object's local axes. This is only used when the body type is "rigid" or "vehicle" and <see cref="Godot.GltfPhysicsBody.InertiaDiagonal"/> is set to a non-zero value.</para>
    /// </summary>
    public Quaternion InertiaOrientation
    {
        get
        {
            return GetInertiaOrientation();
        }
        set
        {
            SetInertiaOrientation(value);
        }
    }

    /// <summary>
    /// <para>The inertia tensor of the physics body, in kilogram meter squared (kg⋅m²). This is only used when the body type is "rigid" or "vehicle".</para>
    /// <para>When converted to a Godot <see cref="Godot.RigidBody3D"/> node, if this value is zero, then the inertia will be calculated automatically.</para>
    /// </summary>
    [Obsolete("This property is deprecated.")]
    public Basis InertiaTensor
    {
        get
        {
            return GetInertiaTensor();
        }
        set
        {
            SetInertiaTensor(value);
        }
    }

    private static readonly System.Type CachedType = typeof(GltfPhysicsBody);

    private static readonly StringName NativeName = "GLTFPhysicsBody";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public GltfPhysicsBody() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal GltfPhysicsBody(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal GltfPhysicsBody(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FromNode, 420544174ul);

    /// <summary>
    /// <para>Creates a new GLTFPhysicsBody instance from the given Godot <see cref="Godot.CollisionObject3D"/> node.</para>
    /// </summary>
    public static GltfPhysicsBody FromNode(CollisionObject3D bodyNode)
    {
        return (GltfPhysicsBody)NativeCalls.godot_icall_1_637(MethodBind0, GodotObject.GetPtr(bodyNode));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ToNode, 3224013656ul);

    /// <summary>
    /// <para>Converts this GLTFPhysicsBody instance into a Godot <see cref="Godot.CollisionObject3D"/> node.</para>
    /// </summary>
    public CollisionObject3D ToNode()
    {
        return (CollisionObject3D)NativeCalls.godot_icall_0_53(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FromDictionary, 1177544336ul);

    /// <summary>
    /// <para>Creates a new GLTFPhysicsBody instance by parsing the given <see cref="Godot.Collections.Dictionary"/> in the <c>OMI_physics_body</c> glTF extension format.</para>
    /// </summary>
    public static GltfPhysicsBody FromDictionary(Godot.Collections.Dictionary dictionary)
    {
        return (GltfPhysicsBody)NativeCalls.godot_icall_1_633(MethodBind2, (godot_dictionary)(dictionary ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ToDictionary, 3102165223ul);

    /// <summary>
    /// <para>Serializes this GLTFPhysicsBody instance into a <see cref="Godot.Collections.Dictionary"/>. It will be in the format expected by the <c>OMI_physics_body</c> glTF extension.</para>
    /// </summary>
    public Godot.Collections.Dictionary ToDictionary()
    {
        return NativeCalls.godot_icall_0_122(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBodyType, 201670096ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string GetBodyType()
    {
        return NativeCalls.godot_icall_0_58(MethodBind4, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBodyType, 83702148ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetBodyType(string bodyType)
    {
        NativeCalls.godot_icall_1_57(MethodBind5, GodotObject.GetPtr(this), bodyType);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMass, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetMass()
    {
        return NativeCalls.godot_icall_0_68(MethodBind6, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMass, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMass(float mass)
    {
        NativeCalls.godot_icall_1_67(MethodBind7, GodotObject.GetPtr(this), mass);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLinearVelocity, 3360562783ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector3 GetLinearVelocity()
    {
        return NativeCalls.godot_icall_0_125(MethodBind8, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLinearVelocity, 3460891852ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetLinearVelocity(Vector3 linearVelocity)
    {
        NativeCalls.godot_icall_1_177(MethodBind9, GodotObject.GetPtr(this), &linearVelocity);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAngularVelocity, 3360562783ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector3 GetAngularVelocity()
    {
        return NativeCalls.godot_icall_0_125(MethodBind10, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAngularVelocity, 3460891852ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetAngularVelocity(Vector3 angularVelocity)
    {
        NativeCalls.godot_icall_1_177(MethodBind11, GodotObject.GetPtr(this), &angularVelocity);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCenterOfMass, 3360562783ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector3 GetCenterOfMass()
    {
        return NativeCalls.godot_icall_0_125(MethodBind12, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCenterOfMass, 3460891852ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetCenterOfMass(Vector3 centerOfMass)
    {
        NativeCalls.godot_icall_1_177(MethodBind13, GodotObject.GetPtr(this), &centerOfMass);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetInertiaDiagonal, 3360562783ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector3 GetInertiaDiagonal()
    {
        return NativeCalls.godot_icall_0_125(MethodBind14, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetInertiaDiagonal, 3460891852ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetInertiaDiagonal(Vector3 inertiaDiagonal)
    {
        NativeCalls.godot_icall_1_177(MethodBind15, GodotObject.GetPtr(this), &inertiaDiagonal);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetInertiaOrientation, 1222331677ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Quaternion GetInertiaOrientation()
    {
        return NativeCalls.godot_icall_0_126(MethodBind16, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetInertiaOrientation, 1727505552ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetInertiaOrientation(Quaternion inertiaOrientation)
    {
        NativeCalls.godot_icall_1_649(MethodBind17, GodotObject.GetPtr(this), &inertiaOrientation);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetInertiaTensor, 2716978435ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Basis GetInertiaTensor()
    {
        return NativeCalls.godot_icall_0_652(MethodBind18, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetInertiaTensor, 1055510324ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetInertiaTensor(Basis inertiaTensor)
    {
        NativeCalls.godot_icall_1_653(MethodBind19, GodotObject.GetPtr(this), &inertiaTensor);
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
        /// Cached name for the 'body_type' property.
        /// </summary>
        public static readonly StringName BodyType = "body_type";
        /// <summary>
        /// Cached name for the 'mass' property.
        /// </summary>
        public static readonly StringName Mass = "mass";
        /// <summary>
        /// Cached name for the 'linear_velocity' property.
        /// </summary>
        public static readonly StringName LinearVelocity = "linear_velocity";
        /// <summary>
        /// Cached name for the 'angular_velocity' property.
        /// </summary>
        public static readonly StringName AngularVelocity = "angular_velocity";
        /// <summary>
        /// Cached name for the 'center_of_mass' property.
        /// </summary>
        public static readonly StringName CenterOfMass = "center_of_mass";
        /// <summary>
        /// Cached name for the 'inertia_diagonal' property.
        /// </summary>
        public static readonly StringName InertiaDiagonal = "inertia_diagonal";
        /// <summary>
        /// Cached name for the 'inertia_orientation' property.
        /// </summary>
        public static readonly StringName InertiaOrientation = "inertia_orientation";
        /// <summary>
        /// Cached name for the 'inertia_tensor' property.
        /// </summary>
        public static readonly StringName InertiaTensor = "inertia_tensor";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Resource.MethodName
    {
        /// <summary>
        /// Cached name for the 'from_node' method.
        /// </summary>
        public static readonly StringName FromNode = "from_node";
        /// <summary>
        /// Cached name for the 'to_node' method.
        /// </summary>
        public static readonly StringName ToNode = "to_node";
        /// <summary>
        /// Cached name for the 'from_dictionary' method.
        /// </summary>
        public static readonly StringName FromDictionary = "from_dictionary";
        /// <summary>
        /// Cached name for the 'to_dictionary' method.
        /// </summary>
        public static readonly StringName ToDictionary = "to_dictionary";
        /// <summary>
        /// Cached name for the 'get_body_type' method.
        /// </summary>
        public static readonly StringName GetBodyType = "get_body_type";
        /// <summary>
        /// Cached name for the 'set_body_type' method.
        /// </summary>
        public static readonly StringName SetBodyType = "set_body_type";
        /// <summary>
        /// Cached name for the 'get_mass' method.
        /// </summary>
        public static readonly StringName GetMass = "get_mass";
        /// <summary>
        /// Cached name for the 'set_mass' method.
        /// </summary>
        public static readonly StringName SetMass = "set_mass";
        /// <summary>
        /// Cached name for the 'get_linear_velocity' method.
        /// </summary>
        public static readonly StringName GetLinearVelocity = "get_linear_velocity";
        /// <summary>
        /// Cached name for the 'set_linear_velocity' method.
        /// </summary>
        public static readonly StringName SetLinearVelocity = "set_linear_velocity";
        /// <summary>
        /// Cached name for the 'get_angular_velocity' method.
        /// </summary>
        public static readonly StringName GetAngularVelocity = "get_angular_velocity";
        /// <summary>
        /// Cached name for the 'set_angular_velocity' method.
        /// </summary>
        public static readonly StringName SetAngularVelocity = "set_angular_velocity";
        /// <summary>
        /// Cached name for the 'get_center_of_mass' method.
        /// </summary>
        public static readonly StringName GetCenterOfMass = "get_center_of_mass";
        /// <summary>
        /// Cached name for the 'set_center_of_mass' method.
        /// </summary>
        public static readonly StringName SetCenterOfMass = "set_center_of_mass";
        /// <summary>
        /// Cached name for the 'get_inertia_diagonal' method.
        /// </summary>
        public static readonly StringName GetInertiaDiagonal = "get_inertia_diagonal";
        /// <summary>
        /// Cached name for the 'set_inertia_diagonal' method.
        /// </summary>
        public static readonly StringName SetInertiaDiagonal = "set_inertia_diagonal";
        /// <summary>
        /// Cached name for the 'get_inertia_orientation' method.
        /// </summary>
        public static readonly StringName GetInertiaOrientation = "get_inertia_orientation";
        /// <summary>
        /// Cached name for the 'set_inertia_orientation' method.
        /// </summary>
        public static readonly StringName SetInertiaOrientation = "set_inertia_orientation";
        /// <summary>
        /// Cached name for the 'get_inertia_tensor' method.
        /// </summary>
        public static readonly StringName GetInertiaTensor = "get_inertia_tensor";
        /// <summary>
        /// Cached name for the 'set_inertia_tensor' method.
        /// </summary>
        public static readonly StringName SetInertiaTensor = "set_inertia_tensor";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Resource.SignalName
    {
    }
}
