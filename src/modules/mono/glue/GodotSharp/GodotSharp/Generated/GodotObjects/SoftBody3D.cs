namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A deformable 3D physics mesh. Used to create elastic or deformable objects such as cloth, rubber, or other flexible materials.</para>
/// <para>Additionally, <see cref="Godot.SoftBody3D"/> is subject to wind forces defined in <see cref="Godot.Area3D"/> (see <see cref="Godot.Area3D.WindSourcePath"/>, <see cref="Godot.Area3D.WindForceMagnitude"/>, and <see cref="Godot.Area3D.WindAttenuationFactor"/>).</para>
/// <para><b>Note:</b> It's recommended to use Jolt Physics when using <see cref="Godot.SoftBody3D"/> instead of the default GodotPhysics3D, as Jolt Physics' soft body implementation is faster and more reliable. You can switch the physics engine using the <c>ProjectSettings.physics/3d/physics_engine</c> project setting.</para>
/// </summary>
public partial class SoftBody3D : MeshInstance3D
{
    public enum DisableModeEnum : long
    {
        /// <summary>
        /// <para>When <see cref="Godot.Node.ProcessMode"/> is set to <see cref="Godot.Node.ProcessModeEnum.Disabled"/>, remove from the physics simulation to stop all physics interactions with this <see cref="Godot.SoftBody3D"/>.</para>
        /// <para>Automatically re-added to the physics simulation when the <see cref="Godot.Node"/> is processed again.</para>
        /// </summary>
        Remove = 0,
        /// <summary>
        /// <para>When <see cref="Godot.Node.ProcessMode"/> is set to <see cref="Godot.Node.ProcessModeEnum.Disabled"/>, do not affect the physics simulation.</para>
        /// </summary>
        KeepActive = 1
    }

    /// <summary>
    /// <para>The physics layers this SoftBody3D <b>is in</b>. Collision objects can exist in one or more of 32 different layers. See also <see cref="Godot.SoftBody3D.CollisionMask"/>.</para>
    /// <para><b>Note:</b> Object A can detect a contact with object B only if object B is in any of the layers that object A scans. See <a href="$DOCS_URL/tutorials/physics/physics_introduction.html#collision-layers-and-masks">Collision layers and masks</a> in the documentation for more information.</para>
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
    /// <para>The physics layers this SoftBody3D <b>scans</b>. Collision objects can scan one or more of 32 different layers. See also <see cref="Godot.SoftBody3D.CollisionLayer"/>.</para>
    /// <para><b>Note:</b> Object A can detect a contact with object B only if object B is in any of the layers that object A scans. See <a href="$DOCS_URL/tutorials/physics/physics_introduction.html#collision-layers-and-masks">Collision layers and masks</a> in the documentation for more information.</para>
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
    /// <para><see cref="Godot.NodePath"/> to a <see cref="Godot.CollisionObject3D"/> this SoftBody3D should avoid clipping.</para>
    /// </summary>
    public NodePath ParentCollisionIgnore
    {
        get
        {
            return GetParentCollisionIgnore();
        }
        set
        {
            SetParentCollisionIgnore(value);
        }
    }

    /// <summary>
    /// <para>Increasing this value will improve the resulting simulation, but can affect performance. Use with care.</para>
    /// </summary>
    public int SimulationPrecision
    {
        get
        {
            return GetSimulationPrecision();
        }
        set
        {
            SetSimulationPrecision(value);
        }
    }

    /// <summary>
    /// <para>The SoftBody3D's mass.</para>
    /// <para><b>Note:</b> When using Jolt Physics, the default value of this property will instead be <c>0.0</c>, which will cause the body to automatically calculate the mass to 1 kg per point. This is a bug, which will be fixed in Godot 4.7.</para>
    /// </summary>
    public float TotalMass
    {
        get
        {
            return GetTotalMass();
        }
        set
        {
            SetTotalMass(value);
        }
    }

    /// <summary>
    /// <para>Higher values will result in a stiffer body, while lower values will increase the body's ability to bend. The value can be between <c>0.0</c> and <c>1.0</c> (inclusive).</para>
    /// </summary>
    public float LinearStiffness
    {
        get
        {
            return GetLinearStiffness();
        }
        set
        {
            SetLinearStiffness(value);
        }
    }

    /// <summary>
    /// <para>Scales the rest lengths of <see cref="Godot.SoftBody3D"/>'s edge constraints. Positive values shrink the mesh, while negative values expand it. For example, a value of <c>0.1</c> shortens the edges of the mesh by 10%, while <c>-0.1</c> expands the edges by 10%.</para>
    /// <para><b>Note:</b> <see cref="Godot.SoftBody3D.ShrinkingFactor"/> is best used on surface meshes with pinned points.</para>
    /// </summary>
    public float ShrinkingFactor
    {
        get
        {
            return GetShrinkingFactor();
        }
        set
        {
            SetShrinkingFactor(value);
        }
    }

    /// <summary>
    /// <para>The pressure coefficient of this soft body. Simulate pressure build-up from inside this body. Higher values increase the strength of this effect.</para>
    /// </summary>
    public float PressureCoefficient
    {
        get
        {
            return GetPressureCoefficient();
        }
        set
        {
            SetPressureCoefficient(value);
        }
    }

    /// <summary>
    /// <para>The body's damping coefficient. Higher values will slow down the body more noticeably when forces are applied.</para>
    /// </summary>
    public float DampingCoefficient
    {
        get
        {
            return GetDampingCoefficient();
        }
        set
        {
            SetDampingCoefficient(value);
        }
    }

    /// <summary>
    /// <para>The body's drag coefficient. Higher values increase this body's air resistance.</para>
    /// <para><b>Note:</b> This value is currently unused by Godot's default physics implementation.</para>
    /// </summary>
    public float DragCoefficient
    {
        get
        {
            return GetDragCoefficient();
        }
        set
        {
            SetDragCoefficient(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the <see cref="Godot.SoftBody3D"/> will respond to <see cref="Godot.RayCast3D"/>s.</para>
    /// </summary>
    public bool RayPickable
    {
        get
        {
            return IsRayPickable();
        }
        set
        {
            SetRayPickable(value);
        }
    }

    /// <summary>
    /// <para>Defines the behavior in physics when <see cref="Godot.Node.ProcessMode"/> is set to <see cref="Godot.Node.ProcessModeEnum.Disabled"/>.</para>
    /// </summary>
    public SoftBody3D.DisableModeEnum DisableMode
    {
        get
        {
            return GetDisableMode();
        }
        set
        {
            SetDisableMode(value);
        }
    }

    private static readonly System.Type CachedType = typeof(SoftBody3D);

    private static readonly StringName NativeName = "SoftBody3D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public SoftBody3D() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal SoftBody3D(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal SoftBody3D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPhysicsRid, 2944877500ul);

    /// <summary>
    /// <para>Returns the internal <see cref="Godot.Rid"/> used by the <see cref="Godot.PhysicsServer3D"/> for this body.</para>
    /// </summary>
    public Rid GetPhysicsRid()
    {
        return NativeCalls.godot_icall_0_238(MethodBind0, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCollisionMask, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCollisionMask(uint collisionMask)
    {
        NativeCalls.godot_icall_1_208(MethodBind1, GodotObject.GetPtr(this), collisionMask);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCollisionMask, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public uint GetCollisionMask()
    {
        return NativeCalls.godot_icall_0_209(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCollisionLayer, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCollisionLayer(uint collisionLayer)
    {
        NativeCalls.godot_icall_1_208(MethodBind3, GodotObject.GetPtr(this), collisionLayer);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCollisionLayer, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public uint GetCollisionLayer()
    {
        return NativeCalls.godot_icall_0_209(MethodBind4, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCollisionMaskValue, 300928843ul);

    /// <summary>
    /// <para>Based on <paramref name="value"/>, enables or disables the specified layer in the <see cref="Godot.SoftBody3D.CollisionMask"/>, given a <paramref name="layerNumber"/> between 1 and 32.</para>
    /// </summary>
    public void SetCollisionMaskValue(int layerNumber, bool value)
    {
        NativeCalls.godot_icall_2_61(MethodBind5, GodotObject.GetPtr(this), layerNumber, value.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCollisionMaskValue, 1116898809ul);

    /// <summary>
    /// <para>Returns whether or not the specified layer of the <see cref="Godot.SoftBody3D.CollisionMask"/> is enabled, given a <paramref name="layerNumber"/> between 1 and 32.</para>
    /// </summary>
    public bool GetCollisionMaskValue(int layerNumber)
    {
        return NativeCalls.godot_icall_1_62(MethodBind6, GodotObject.GetPtr(this), layerNumber).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCollisionLayerValue, 300928843ul);

    /// <summary>
    /// <para>Based on <paramref name="value"/>, enables or disables the specified layer in the <see cref="Godot.SoftBody3D.CollisionLayer"/>, given a <paramref name="layerNumber"/> between 1 and 32.</para>
    /// </summary>
    public void SetCollisionLayerValue(int layerNumber, bool value)
    {
        NativeCalls.godot_icall_2_61(MethodBind7, GodotObject.GetPtr(this), layerNumber, value.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCollisionLayerValue, 1116898809ul);

    /// <summary>
    /// <para>Returns whether or not the specified layer of the <see cref="Godot.SoftBody3D.CollisionLayer"/> is enabled, given a <paramref name="layerNumber"/> between 1 and 32.</para>
    /// </summary>
    public bool GetCollisionLayerValue(int layerNumber)
    {
        return NativeCalls.godot_icall_1_62(MethodBind8, GodotObject.GetPtr(this), layerNumber).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetParentCollisionIgnore, 1348162250ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetParentCollisionIgnore(NodePath parentCollisionIgnore)
    {
        NativeCalls.godot_icall_1_123(MethodBind9, GodotObject.GetPtr(this), (godot_node_path)(parentCollisionIgnore?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetParentCollisionIgnore, 4075236667ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public NodePath GetParentCollisionIgnore()
    {
        return NativeCalls.godot_icall_0_124(MethodBind10, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDisableMode, 1104158384ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDisableMode(SoftBody3D.DisableModeEnum mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind11, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDisableMode, 4135042476ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public SoftBody3D.DisableModeEnum GetDisableMode()
    {
        return (SoftBody3D.DisableModeEnum)NativeCalls.godot_icall_0_39(MethodBind12, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCollisionExceptions, 2915620761ul);

    /// <summary>
    /// <para>Returns an array of nodes that were added as collision exceptions for this body.</para>
    /// </summary>
    public Godot.Collections.Array<PhysicsBody3D> GetCollisionExceptions()
    {
        return new Godot.Collections.Array<PhysicsBody3D>(NativeCalls.godot_icall_0_120(MethodBind13, GodotObject.GetPtr(this)));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddCollisionExceptionWith, 1078189570ul);

    /// <summary>
    /// <para>Adds a body to the list of bodies that this body can't collide with.</para>
    /// </summary>
    public void AddCollisionExceptionWith(Node body)
    {
        NativeCalls.godot_icall_1_56(MethodBind14, GodotObject.GetPtr(this), GodotObject.GetPtr(body));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveCollisionExceptionWith, 1078189570ul);

    /// <summary>
    /// <para>Removes a body from the list of bodies that this body can't collide with.</para>
    /// </summary>
    public void RemoveCollisionExceptionWith(Node body)
    {
        NativeCalls.godot_icall_1_56(MethodBind15, GodotObject.GetPtr(this), GodotObject.GetPtr(body));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSimulationPrecision, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSimulationPrecision(int simulationPrecision)
    {
        NativeCalls.godot_icall_1_38(MethodBind16, GodotObject.GetPtr(this), simulationPrecision);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSimulationPrecision, 2455072627ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetSimulationPrecision()
    {
        return NativeCalls.godot_icall_0_39(MethodBind17, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTotalMass, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTotalMass(float mass)
    {
        NativeCalls.godot_icall_1_67(MethodBind18, GodotObject.GetPtr(this), mass);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTotalMass, 191475506ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetTotalMass()
    {
        return NativeCalls.godot_icall_0_68(MethodBind19, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLinearStiffness, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetLinearStiffness(float linearStiffness)
    {
        NativeCalls.godot_icall_1_67(MethodBind20, GodotObject.GetPtr(this), linearStiffness);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLinearStiffness, 191475506ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetLinearStiffness()
    {
        return NativeCalls.godot_icall_0_68(MethodBind21, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetShrinkingFactor, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetShrinkingFactor(float shrinkingFactor)
    {
        NativeCalls.godot_icall_1_67(MethodBind22, GodotObject.GetPtr(this), shrinkingFactor);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetShrinkingFactor, 191475506ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetShrinkingFactor()
    {
        return NativeCalls.godot_icall_0_68(MethodBind23, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPressureCoefficient, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPressureCoefficient(float pressureCoefficient)
    {
        NativeCalls.godot_icall_1_67(MethodBind24, GodotObject.GetPtr(this), pressureCoefficient);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPressureCoefficient, 191475506ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetPressureCoefficient()
    {
        return NativeCalls.godot_icall_0_68(MethodBind25, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDampingCoefficient, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDampingCoefficient(float dampingCoefficient)
    {
        NativeCalls.godot_icall_1_67(MethodBind26, GodotObject.GetPtr(this), dampingCoefficient);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDampingCoefficient, 191475506ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetDampingCoefficient()
    {
        return NativeCalls.godot_icall_0_68(MethodBind27, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDragCoefficient, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDragCoefficient(float dragCoefficient)
    {
        NativeCalls.godot_icall_1_67(MethodBind28, GodotObject.GetPtr(this), dragCoefficient);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDragCoefficient, 191475506ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetDragCoefficient()
    {
        return NativeCalls.godot_icall_0_68(MethodBind29, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPointTransform, 871989493ul);

    /// <summary>
    /// <para>Returns local translation of a vertex in the surface array.</para>
    /// </summary>
    public Vector3 GetPointTransform(int pointIndex)
    {
        return NativeCalls.godot_icall_1_363(MethodBind30, GodotObject.GetPtr(this), pointIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ApplyImpulse, 1530502735ul);

    /// <summary>
    /// <para>Applies an impulse to a point.</para>
    /// <para>An impulse is time-independent! Applying an impulse every frame would result in a framerate-dependent force. For this reason, it should only be used when simulating one-time impacts (use the "_force" functions otherwise).</para>
    /// </summary>
    public unsafe void ApplyImpulse(int pointIndex, Vector3 impulse)
    {
        NativeCalls.godot_icall_2_362(MethodBind31, GodotObject.GetPtr(this), pointIndex, &impulse);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind32 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ApplyForce, 1530502735ul);

    /// <summary>
    /// <para>Applies a force to a point. A force is time dependent and meant to be applied every physics update.</para>
    /// </summary>
    public unsafe void ApplyForce(int pointIndex, Vector3 force)
    {
        NativeCalls.godot_icall_2_362(MethodBind32, GodotObject.GetPtr(this), pointIndex, &force);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind33 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ApplyCentralImpulse, 3460891852ul);

    /// <summary>
    /// <para>Distributes and applies an impulse to all points.</para>
    /// <para>An impulse is time-independent! Applying an impulse every frame would result in a framerate-dependent force. For this reason, it should only be used when simulating one-time impacts (use the "_force" functions otherwise).</para>
    /// </summary>
    public unsafe void ApplyCentralImpulse(Vector3 impulse)
    {
        NativeCalls.godot_icall_1_177(MethodBind33, GodotObject.GetPtr(this), &impulse);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind34 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ApplyCentralForce, 3460891852ul);

    /// <summary>
    /// <para>Distributes and applies a force to all points. A force is time dependent and meant to be applied every physics update.</para>
    /// </summary>
    public unsafe void ApplyCentralForce(Vector3 force)
    {
        NativeCalls.godot_icall_1_177(MethodBind34, GodotObject.GetPtr(this), &force);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind35 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPointPinned, 528784402ul);

    /// <summary>
    /// <para>Sets the pinned state of a surface vertex. When set to <see langword="true"/>, the optional <paramref name="attachmentPath"/> can define a <see cref="Godot.Node3D"/> the pinned vertex will be attached to.</para>
    /// </summary>
    public void SetPointPinned(int pointIndex, bool pinned, NodePath attachmentPath = null, int insertAt = -1)
    {
        NativeCalls.godot_icall_4_1275(MethodBind35, GodotObject.GetPtr(this), pointIndex, pinned.ToGodotBool(), (godot_node_path)(attachmentPath?.NativeValue ?? default), insertAt);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind36 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsPointPinned, 1116898809ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if vertex is set to pinned.</para>
    /// </summary>
    public bool IsPointPinned(int pointIndex)
    {
        return NativeCalls.godot_icall_1_62(MethodBind36, GodotObject.GetPtr(this), pointIndex).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind37 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRayPickable, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetRayPickable(bool rayPickable)
    {
        NativeCalls.godot_icall_1_14(MethodBind37, GodotObject.GetPtr(this), rayPickable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind38 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsRayPickable, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsRayPickable()
    {
        return NativeCalls.godot_icall_0_15(MethodBind38, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind39 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPointPinned, 3814935226ul);

    /// <summary>
    /// <para>Sets the pinned state of a surface vertex. When set to <see langword="true"/>, the optional <paramref name="attachmentPath"/> can define a <see cref="Godot.Node3D"/> the pinned vertex will be attached to.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPointPinned(int pointIndex, bool pinned, NodePath attachmentPath)
    {
        NativeCalls.godot_icall_3_1276(MethodBind39, GodotObject.GetPtr(this), pointIndex, pinned.ToGodotBool(), (godot_node_path)(attachmentPath?.NativeValue ?? default));
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
    public new class PropertyName : MeshInstance3D.PropertyName
    {
        /// <summary>
        /// Cached name for the 'collision_layer' property.
        /// </summary>
        public static readonly StringName CollisionLayer = "collision_layer";
        /// <summary>
        /// Cached name for the 'collision_mask' property.
        /// </summary>
        public static readonly StringName CollisionMask = "collision_mask";
        /// <summary>
        /// Cached name for the 'parent_collision_ignore' property.
        /// </summary>
        public static readonly StringName ParentCollisionIgnore = "parent_collision_ignore";
        /// <summary>
        /// Cached name for the 'simulation_precision' property.
        /// </summary>
        public static readonly StringName SimulationPrecision = "simulation_precision";
        /// <summary>
        /// Cached name for the 'total_mass' property.
        /// </summary>
        public static readonly StringName TotalMass = "total_mass";
        /// <summary>
        /// Cached name for the 'linear_stiffness' property.
        /// </summary>
        public static readonly StringName LinearStiffness = "linear_stiffness";
        /// <summary>
        /// Cached name for the 'shrinking_factor' property.
        /// </summary>
        public static readonly StringName ShrinkingFactor = "shrinking_factor";
        /// <summary>
        /// Cached name for the 'pressure_coefficient' property.
        /// </summary>
        public static readonly StringName PressureCoefficient = "pressure_coefficient";
        /// <summary>
        /// Cached name for the 'damping_coefficient' property.
        /// </summary>
        public static readonly StringName DampingCoefficient = "damping_coefficient";
        /// <summary>
        /// Cached name for the 'drag_coefficient' property.
        /// </summary>
        public static readonly StringName DragCoefficient = "drag_coefficient";
        /// <summary>
        /// Cached name for the 'ray_pickable' property.
        /// </summary>
        public static readonly StringName RayPickable = "ray_pickable";
        /// <summary>
        /// Cached name for the 'disable_mode' property.
        /// </summary>
        public static readonly StringName DisableMode = "disable_mode";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : MeshInstance3D.MethodName
    {
        /// <summary>
        /// Cached name for the 'get_physics_rid' method.
        /// </summary>
        public static readonly StringName GetPhysicsRid = "get_physics_rid";
        /// <summary>
        /// Cached name for the 'set_collision_mask' method.
        /// </summary>
        public static readonly StringName SetCollisionMask = "set_collision_mask";
        /// <summary>
        /// Cached name for the 'get_collision_mask' method.
        /// </summary>
        public static readonly StringName GetCollisionMask = "get_collision_mask";
        /// <summary>
        /// Cached name for the 'set_collision_layer' method.
        /// </summary>
        public static readonly StringName SetCollisionLayer = "set_collision_layer";
        /// <summary>
        /// Cached name for the 'get_collision_layer' method.
        /// </summary>
        public static readonly StringName GetCollisionLayer = "get_collision_layer";
        /// <summary>
        /// Cached name for the 'set_collision_mask_value' method.
        /// </summary>
        public static readonly StringName SetCollisionMaskValue = "set_collision_mask_value";
        /// <summary>
        /// Cached name for the 'get_collision_mask_value' method.
        /// </summary>
        public static readonly StringName GetCollisionMaskValue = "get_collision_mask_value";
        /// <summary>
        /// Cached name for the 'set_collision_layer_value' method.
        /// </summary>
        public static readonly StringName SetCollisionLayerValue = "set_collision_layer_value";
        /// <summary>
        /// Cached name for the 'get_collision_layer_value' method.
        /// </summary>
        public static readonly StringName GetCollisionLayerValue = "get_collision_layer_value";
        /// <summary>
        /// Cached name for the 'set_parent_collision_ignore' method.
        /// </summary>
        public static readonly StringName SetParentCollisionIgnore = "set_parent_collision_ignore";
        /// <summary>
        /// Cached name for the 'get_parent_collision_ignore' method.
        /// </summary>
        public static readonly StringName GetParentCollisionIgnore = "get_parent_collision_ignore";
        /// <summary>
        /// Cached name for the 'set_disable_mode' method.
        /// </summary>
        public static readonly StringName SetDisableMode = "set_disable_mode";
        /// <summary>
        /// Cached name for the 'get_disable_mode' method.
        /// </summary>
        public static readonly StringName GetDisableMode = "get_disable_mode";
        /// <summary>
        /// Cached name for the 'get_collision_exceptions' method.
        /// </summary>
        public static readonly StringName GetCollisionExceptions = "get_collision_exceptions";
        /// <summary>
        /// Cached name for the 'add_collision_exception_with' method.
        /// </summary>
        public static readonly StringName AddCollisionExceptionWith = "add_collision_exception_with";
        /// <summary>
        /// Cached name for the 'remove_collision_exception_with' method.
        /// </summary>
        public static readonly StringName RemoveCollisionExceptionWith = "remove_collision_exception_with";
        /// <summary>
        /// Cached name for the 'set_simulation_precision' method.
        /// </summary>
        public static readonly StringName SetSimulationPrecision = "set_simulation_precision";
        /// <summary>
        /// Cached name for the 'get_simulation_precision' method.
        /// </summary>
        public static readonly StringName GetSimulationPrecision = "get_simulation_precision";
        /// <summary>
        /// Cached name for the 'set_total_mass' method.
        /// </summary>
        public static readonly StringName SetTotalMass = "set_total_mass";
        /// <summary>
        /// Cached name for the 'get_total_mass' method.
        /// </summary>
        public static readonly StringName GetTotalMass = "get_total_mass";
        /// <summary>
        /// Cached name for the 'set_linear_stiffness' method.
        /// </summary>
        public static readonly StringName SetLinearStiffness = "set_linear_stiffness";
        /// <summary>
        /// Cached name for the 'get_linear_stiffness' method.
        /// </summary>
        public static readonly StringName GetLinearStiffness = "get_linear_stiffness";
        /// <summary>
        /// Cached name for the 'set_shrinking_factor' method.
        /// </summary>
        public static readonly StringName SetShrinkingFactor = "set_shrinking_factor";
        /// <summary>
        /// Cached name for the 'get_shrinking_factor' method.
        /// </summary>
        public static readonly StringName GetShrinkingFactor = "get_shrinking_factor";
        /// <summary>
        /// Cached name for the 'set_pressure_coefficient' method.
        /// </summary>
        public static readonly StringName SetPressureCoefficient = "set_pressure_coefficient";
        /// <summary>
        /// Cached name for the 'get_pressure_coefficient' method.
        /// </summary>
        public static readonly StringName GetPressureCoefficient = "get_pressure_coefficient";
        /// <summary>
        /// Cached name for the 'set_damping_coefficient' method.
        /// </summary>
        public static readonly StringName SetDampingCoefficient = "set_damping_coefficient";
        /// <summary>
        /// Cached name for the 'get_damping_coefficient' method.
        /// </summary>
        public static readonly StringName GetDampingCoefficient = "get_damping_coefficient";
        /// <summary>
        /// Cached name for the 'set_drag_coefficient' method.
        /// </summary>
        public static readonly StringName SetDragCoefficient = "set_drag_coefficient";
        /// <summary>
        /// Cached name for the 'get_drag_coefficient' method.
        /// </summary>
        public static readonly StringName GetDragCoefficient = "get_drag_coefficient";
        /// <summary>
        /// Cached name for the 'get_point_transform' method.
        /// </summary>
        public static readonly StringName GetPointTransform = "get_point_transform";
        /// <summary>
        /// Cached name for the 'apply_impulse' method.
        /// </summary>
        public static readonly StringName ApplyImpulse = "apply_impulse";
        /// <summary>
        /// Cached name for the 'apply_force' method.
        /// </summary>
        public static readonly StringName ApplyForce = "apply_force";
        /// <summary>
        /// Cached name for the 'apply_central_impulse' method.
        /// </summary>
        public static readonly StringName ApplyCentralImpulse = "apply_central_impulse";
        /// <summary>
        /// Cached name for the 'apply_central_force' method.
        /// </summary>
        public static readonly StringName ApplyCentralForce = "apply_central_force";
        /// <summary>
        /// Cached name for the 'set_point_pinned' method.
        /// </summary>
        public static readonly StringName SetPointPinned = "set_point_pinned";
        /// <summary>
        /// Cached name for the 'is_point_pinned' method.
        /// </summary>
        public static readonly StringName IsPointPinned = "is_point_pinned";
        /// <summary>
        /// Cached name for the 'set_ray_pickable' method.
        /// </summary>
        public static readonly StringName SetRayPickable = "set_ray_pickable";
        /// <summary>
        /// Cached name for the 'is_ray_pickable' method.
        /// </summary>
        public static readonly StringName IsRayPickable = "is_ray_pickable";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : MeshInstance3D.SignalName
    {
    }
}
