namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This class extends <see cref="Godot.PhysicsServer3D"/> by providing additional virtual methods that can be overridden. When these methods are overridden, they will be called instead of the internal methods of the physics server.</para>
/// <para>Intended for use with GDExtension to create custom implementations of <see cref="Godot.PhysicsServer3D"/>.</para>
/// </summary>
public partial class PhysicsServer3DExtension : PhysicsServer3DInstance
{
    private static readonly System.Type CachedType = typeof(PhysicsServer3DExtension);

    private static readonly StringName NativeName = "PhysicsServer3DExtension";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public PhysicsServer3DExtension() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal PhysicsServer3DExtension(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal PhysicsServer3DExtension(bool memoryOwn) : base(memoryOwn) { }

    public virtual unsafe void _AreaAddShape(Rid area, Rid shape, Transform3D transform, bool disabled)
    {
    }

    public virtual void _AreaAttachObjectInstanceId(Rid area, ulong id)
    {
    }

    public virtual void _AreaClearShapes(Rid area)
    {
    }

    public virtual Rid _AreaCreate()
    {
        return default;
    }

    public virtual uint _AreaGetCollisionLayer(Rid area)
    {
        return default;
    }

    public virtual uint _AreaGetCollisionMask(Rid area)
    {
        return default;
    }

    public virtual ulong _AreaGetObjectInstanceId(Rid area)
    {
        return default;
    }

    public virtual Variant _AreaGetParam(Rid area, PhysicsServer3D.AreaParameter param)
    {
        return default;
    }

    public virtual Rid _AreaGetShape(Rid area, int shapeIdx)
    {
        return default;
    }

    public virtual int _AreaGetShapeCount(Rid area)
    {
        return default;
    }

    public virtual Transform3D _AreaGetShapeTransform(Rid area, int shapeIdx)
    {
        return default;
    }

    public virtual Rid _AreaGetSpace(Rid area)
    {
        return default;
    }

    public virtual Transform3D _AreaGetTransform(Rid area)
    {
        return default;
    }

    public virtual void _AreaRemoveShape(Rid area, int shapeIdx)
    {
    }

    public virtual void _AreaSetAreaMonitorCallback(Rid area, Callable callback)
    {
    }

    public virtual void _AreaSetCollisionLayer(Rid area, uint layer)
    {
    }

    public virtual void _AreaSetCollisionMask(Rid area, uint mask)
    {
    }

    public virtual void _AreaSetMonitorCallback(Rid area, Callable callback)
    {
    }

    public virtual void _AreaSetMonitorable(Rid area, bool monitorable)
    {
    }

    public virtual void _AreaSetParam(Rid area, PhysicsServer3D.AreaParameter param, Variant value)
    {
    }

    public virtual void _AreaSetRayPickable(Rid area, bool enable)
    {
    }

    public virtual void _AreaSetShape(Rid area, int shapeIdx, Rid shape)
    {
    }

    public virtual void _AreaSetShapeDisabled(Rid area, int shapeIdx, bool disabled)
    {
    }

    public virtual unsafe void _AreaSetShapeTransform(Rid area, int shapeIdx, Transform3D transform)
    {
    }

    public virtual void _AreaSetSpace(Rid area, Rid space)
    {
    }

    public virtual unsafe void _AreaSetTransform(Rid area, Transform3D transform)
    {
    }

    public virtual void _BodyAddCollisionException(Rid body, Rid exceptedBody)
    {
    }

    public virtual unsafe void _BodyAddConstantCentralForce(Rid body, Vector3 force)
    {
    }

    public virtual unsafe void _BodyAddConstantForce(Rid body, Vector3 force, Vector3 position)
    {
    }

    public virtual unsafe void _BodyAddConstantTorque(Rid body, Vector3 torque)
    {
    }

    public virtual unsafe void _BodyAddShape(Rid body, Rid shape, Transform3D transform, bool disabled)
    {
    }

    public virtual unsafe void _BodyApplyCentralForce(Rid body, Vector3 force)
    {
    }

    public virtual unsafe void _BodyApplyCentralImpulse(Rid body, Vector3 impulse)
    {
    }

    public virtual unsafe void _BodyApplyForce(Rid body, Vector3 force, Vector3 position)
    {
    }

    public virtual unsafe void _BodyApplyImpulse(Rid body, Vector3 impulse, Vector3 position)
    {
    }

    public virtual unsafe void _BodyApplyTorque(Rid body, Vector3 torque)
    {
    }

    public virtual unsafe void _BodyApplyTorqueImpulse(Rid body, Vector3 impulse)
    {
    }

    public virtual void _BodyAttachObjectInstanceId(Rid body, ulong id)
    {
    }

    public virtual void _BodyClearShapes(Rid body)
    {
    }

    public virtual Rid _BodyCreate()
    {
        return default;
    }

    public virtual Godot.Collections.Array<Rid> _BodyGetCollisionExceptions(Rid body)
    {
        return default;
    }

    public virtual uint _BodyGetCollisionLayer(Rid body)
    {
        return default;
    }

    public virtual uint _BodyGetCollisionMask(Rid body)
    {
        return default;
    }

    public virtual float _BodyGetCollisionPriority(Rid body)
    {
        return default;
    }

    public virtual Vector3 _BodyGetConstantForce(Rid body)
    {
        return default;
    }

    public virtual Vector3 _BodyGetConstantTorque(Rid body)
    {
        return default;
    }

    public virtual float _BodyGetContactsReportedDepthThreshold(Rid body)
    {
        return default;
    }

    public virtual PhysicsDirectBodyState3D _BodyGetDirectState(Rid body)
    {
        return default;
    }

    public virtual int _BodyGetMaxContactsReported(Rid body)
    {
        return default;
    }

    public virtual PhysicsServer3D.BodyMode _BodyGetMode(Rid body)
    {
        return default;
    }

    public virtual ulong _BodyGetObjectInstanceId(Rid body)
    {
        return default;
    }

    public virtual Variant _BodyGetParam(Rid body, PhysicsServer3D.BodyParameter param)
    {
        return default;
    }

    public virtual Rid _BodyGetShape(Rid body, int shapeIdx)
    {
        return default;
    }

    public virtual int _BodyGetShapeCount(Rid body)
    {
        return default;
    }

    public virtual Transform3D _BodyGetShapeTransform(Rid body, int shapeIdx)
    {
        return default;
    }

    public virtual Rid _BodyGetSpace(Rid body)
    {
        return default;
    }

    public virtual Variant _BodyGetState(Rid body, PhysicsServer3D.BodyState state)
    {
        return default;
    }

    public virtual uint _BodyGetUserFlags(Rid body)
    {
        return default;
    }

    public virtual bool _BodyIsAxisLocked(Rid body, PhysicsServer3D.BodyAxis axis)
    {
        return default;
    }

    public virtual bool _BodyIsContinuousCollisionDetectionEnabled(Rid body)
    {
        return default;
    }

    public virtual bool _BodyIsOmittingForceIntegration(Rid body)
    {
        return default;
    }

    public virtual void _BodyRemoveCollisionException(Rid body, Rid exceptedBody)
    {
    }

    public virtual void _BodyRemoveShape(Rid body, int shapeIdx)
    {
    }

    public virtual void _BodyResetMassProperties(Rid body)
    {
    }

    public virtual void _BodySetAxisLock(Rid body, PhysicsServer3D.BodyAxis axis, bool @lock)
    {
    }

    public virtual unsafe void _BodySetAxisVelocity(Rid body, Vector3 axisVelocity)
    {
    }

    public virtual void _BodySetCollisionLayer(Rid body, uint layer)
    {
    }

    public virtual void _BodySetCollisionMask(Rid body, uint mask)
    {
    }

    public virtual void _BodySetCollisionPriority(Rid body, float priority)
    {
    }

    public virtual unsafe void _BodySetConstantForce(Rid body, Vector3 force)
    {
    }

    public virtual unsafe void _BodySetConstantTorque(Rid body, Vector3 torque)
    {
    }

    public virtual void _BodySetContactsReportedDepthThreshold(Rid body, float threshold)
    {
    }

    public virtual void _BodySetEnableContinuousCollisionDetection(Rid body, bool enable)
    {
    }

    public virtual void _BodySetForceIntegrationCallback(Rid body, Callable callable, Variant userdata)
    {
    }

    public virtual void _BodySetMaxContactsReported(Rid body, int amount)
    {
    }

    public virtual void _BodySetMode(Rid body, PhysicsServer3D.BodyMode mode)
    {
    }

    public virtual void _BodySetOmitForceIntegration(Rid body, bool enable)
    {
    }

    public virtual void _BodySetParam(Rid body, PhysicsServer3D.BodyParameter param, Variant value)
    {
    }

    public virtual void _BodySetRayPickable(Rid body, bool enable)
    {
    }

    public virtual void _BodySetShape(Rid body, int shapeIdx, Rid shape)
    {
    }

    public virtual void _BodySetShapeDisabled(Rid body, int shapeIdx, bool disabled)
    {
    }

    public virtual unsafe void _BodySetShapeTransform(Rid body, int shapeIdx, Transform3D transform)
    {
    }

    public virtual void _BodySetSpace(Rid body, Rid space)
    {
    }

    public virtual void _BodySetState(Rid body, PhysicsServer3D.BodyState state, Variant value)
    {
    }

    public virtual void _BodySetStateSyncCallback(Rid body, Callable callable)
    {
    }

    public virtual void _BodySetUserFlags(Rid body, uint flags)
    {
    }

    public virtual Rid _BoxShapeCreate()
    {
        return default;
    }

    public virtual Rid _CapsuleShapeCreate()
    {
        return default;
    }

    public virtual Rid _ConcavePolygonShapeCreate()
    {
        return default;
    }

    public virtual float _ConeTwistJointGetParam(Rid joint, PhysicsServer3D.ConeTwistJointParam param)
    {
        return default;
    }

    public virtual void _ConeTwistJointSetParam(Rid joint, PhysicsServer3D.ConeTwistJointParam param, float value)
    {
    }

    public virtual Rid _ConvexPolygonShapeCreate()
    {
        return default;
    }

    public virtual Rid _CustomShapeCreate()
    {
        return default;
    }

    public virtual Rid _CylinderShapeCreate()
    {
        return default;
    }

    public virtual void _EndSync()
    {
    }

    public virtual void _Finish()
    {
    }

    public virtual void _FlushQueries()
    {
    }

    public virtual void _FreeRid(Rid rid)
    {
    }

    public virtual bool _Generic6DofJointGetFlag(Rid joint, Vector3.Axis axis, PhysicsServer3D.G6DofJointAxisFlag flag)
    {
        return default;
    }

    public virtual float _Generic6DofJointGetParam(Rid joint, Vector3.Axis axis, PhysicsServer3D.G6DofJointAxisParam param)
    {
        return default;
    }

    public virtual void _Generic6DofJointSetFlag(Rid joint, Vector3.Axis axis, PhysicsServer3D.G6DofJointAxisFlag flag, bool enable)
    {
    }

    public virtual void _Generic6DofJointSetParam(Rid joint, Vector3.Axis axis, PhysicsServer3D.G6DofJointAxisParam param, float value)
    {
    }

    public virtual int _GetProcessInfo(PhysicsServer3D.ProcessInfo processInfo)
    {
        return default;
    }

    public virtual Rid _HeightmapShapeCreate()
    {
        return default;
    }

    public virtual bool _HingeJointGetFlag(Rid joint, PhysicsServer3D.HingeJointFlag flag)
    {
        return default;
    }

    public virtual float _HingeJointGetParam(Rid joint, PhysicsServer3D.HingeJointParam param)
    {
        return default;
    }

    public virtual void _HingeJointSetFlag(Rid joint, PhysicsServer3D.HingeJointFlag flag, bool enabled)
    {
    }

    public virtual void _HingeJointSetParam(Rid joint, PhysicsServer3D.HingeJointParam param, float value)
    {
    }

    public virtual void _Init()
    {
    }

    public virtual bool _IsFlushingQueries()
    {
        return default;
    }

    public virtual void _JointClear(Rid joint)
    {
    }

    public virtual Rid _JointCreate()
    {
        return default;
    }

    public virtual void _JointDisableCollisionsBetweenBodies(Rid joint, bool disable)
    {
    }

    public virtual int _JointGetSolverPriority(Rid joint)
    {
        return default;
    }

    public virtual PhysicsServer3D.JointType _JointGetType(Rid joint)
    {
        return default;
    }

    public virtual bool _JointIsDisabledCollisionsBetweenBodies(Rid joint)
    {
        return default;
    }

    public virtual unsafe void _JointMakeConeTwist(Rid joint, Rid bodyA, Transform3D localRefA, Rid bodyB, Transform3D localRefB)
    {
    }

    public virtual unsafe void _JointMakeGeneric6Dof(Rid joint, Rid bodyA, Transform3D localRefA, Rid bodyB, Transform3D localRefB)
    {
    }

    public virtual unsafe void _JointMakeHinge(Rid joint, Rid bodyA, Transform3D hingeA, Rid bodyB, Transform3D hingeB)
    {
    }

    public virtual unsafe void _JointMakeHingeSimple(Rid joint, Rid bodyA, Vector3 pivotA, Vector3 axisA, Rid bodyB, Vector3 pivotB, Vector3 axisB)
    {
    }

    public virtual unsafe void _JointMakePin(Rid joint, Rid bodyA, Vector3 localA, Rid bodyB, Vector3 localB)
    {
    }

    public virtual unsafe void _JointMakeSlider(Rid joint, Rid bodyA, Transform3D localRefA, Rid bodyB, Transform3D localRefB)
    {
    }

    public virtual void _JointSetSolverPriority(Rid joint, int priority)
    {
    }

    public virtual Vector3 _PinJointGetLocalA(Rid joint)
    {
        return default;
    }

    public virtual Vector3 _PinJointGetLocalB(Rid joint)
    {
        return default;
    }

    public virtual float _PinJointGetParam(Rid joint, PhysicsServer3D.PinJointParam param)
    {
        return default;
    }

    public virtual unsafe void _PinJointSetLocalA(Rid joint, Vector3 localA)
    {
    }

    public virtual unsafe void _PinJointSetLocalB(Rid joint, Vector3 localB)
    {
    }

    public virtual void _PinJointSetParam(Rid joint, PhysicsServer3D.PinJointParam param, float value)
    {
    }

    public virtual Rid _SeparationRayShapeCreate()
    {
        return default;
    }

    public virtual void _SetActive(bool active)
    {
    }

    public virtual float _ShapeGetCustomSolverBias(Rid shape)
    {
        return default;
    }

    public virtual Variant _ShapeGetData(Rid shape)
    {
        return default;
    }

    public virtual float _ShapeGetMargin(Rid shape)
    {
        return default;
    }

    public virtual PhysicsServer3D.ShapeType _ShapeGetType(Rid shape)
    {
        return default;
    }

    public virtual void _ShapeSetCustomSolverBias(Rid shape, float bias)
    {
    }

    public virtual void _ShapeSetData(Rid shape, Variant data)
    {
    }

    public virtual void _ShapeSetMargin(Rid shape, float margin)
    {
    }

    public virtual float _SliderJointGetParam(Rid joint, PhysicsServer3D.SliderJointParam param)
    {
        return default;
    }

    public virtual void _SliderJointSetParam(Rid joint, PhysicsServer3D.SliderJointParam param, float value)
    {
    }

    public virtual void _SoftBodyAddCollisionException(Rid body, Rid bodyB)
    {
    }

    public virtual unsafe void _SoftBodyApplyCentralForce(Rid body, Vector3 force)
    {
    }

    public virtual unsafe void _SoftBodyApplyCentralImpulse(Rid body, Vector3 impulse)
    {
    }

    public virtual unsafe void _SoftBodyApplyPointForce(Rid body, int pointIndex, Vector3 force)
    {
    }

    public virtual unsafe void _SoftBodyApplyPointImpulse(Rid body, int pointIndex, Vector3 impulse)
    {
    }

    public virtual Rid _SoftBodyCreate()
    {
        return default;
    }

    public virtual Aabb _SoftBodyGetBounds(Rid body)
    {
        return default;
    }

    public virtual Godot.Collections.Array<Rid> _SoftBodyGetCollisionExceptions(Rid body)
    {
        return default;
    }

    public virtual uint _SoftBodyGetCollisionLayer(Rid body)
    {
        return default;
    }

    public virtual uint _SoftBodyGetCollisionMask(Rid body)
    {
        return default;
    }

    public virtual float _SoftBodyGetDampingCoefficient(Rid body)
    {
        return default;
    }

    public virtual float _SoftBodyGetDragCoefficient(Rid body)
    {
        return default;
    }

    public virtual float _SoftBodyGetLinearStiffness(Rid body)
    {
        return default;
    }

    public virtual Vector3 _SoftBodyGetPointGlobalPosition(Rid body, int pointIndex)
    {
        return default;
    }

    public virtual float _SoftBodyGetPressureCoefficient(Rid body)
    {
        return default;
    }

    public virtual float _SoftBodyGetShrinkingFactor(Rid body)
    {
        return default;
    }

    public virtual int _SoftBodyGetSimulationPrecision(Rid body)
    {
        return default;
    }

    public virtual Rid _SoftBodyGetSpace(Rid body)
    {
        return default;
    }

    public virtual Variant _SoftBodyGetState(Rid body, PhysicsServer3D.BodyState state)
    {
        return default;
    }

    public virtual float _SoftBodyGetTotalMass(Rid body)
    {
        return default;
    }

    public virtual bool _SoftBodyIsPointPinned(Rid body, int pointIndex)
    {
        return default;
    }

    public virtual unsafe void _SoftBodyMovePoint(Rid body, int pointIndex, Vector3 globalPosition)
    {
    }

    public virtual void _SoftBodyPinPoint(Rid body, int pointIndex, bool pin)
    {
    }

    public virtual void _SoftBodyRemoveAllPinnedPoints(Rid body)
    {
    }

    public virtual void _SoftBodyRemoveCollisionException(Rid body, Rid bodyB)
    {
    }

    public virtual void _SoftBodySetCollisionLayer(Rid body, uint layer)
    {
    }

    public virtual void _SoftBodySetCollisionMask(Rid body, uint mask)
    {
    }

    public virtual void _SoftBodySetDampingCoefficient(Rid body, float dampingCoefficient)
    {
    }

    public virtual void _SoftBodySetDragCoefficient(Rid body, float dragCoefficient)
    {
    }

    public virtual void _SoftBodySetLinearStiffness(Rid body, float linearStiffness)
    {
    }

    public virtual void _SoftBodySetMesh(Rid body, Rid mesh)
    {
    }

    public virtual void _SoftBodySetPressureCoefficient(Rid body, float pressureCoefficient)
    {
    }

    public virtual void _SoftBodySetRayPickable(Rid body, bool enable)
    {
    }

    public virtual void _SoftBodySetShrinkingFactor(Rid body, float shrinkingFactor)
    {
    }

    public virtual void _SoftBodySetSimulationPrecision(Rid body, int simulationPrecision)
    {
    }

    public virtual void _SoftBodySetSpace(Rid body, Rid space)
    {
    }

    public virtual void _SoftBodySetState(Rid body, PhysicsServer3D.BodyState state, Variant variant)
    {
    }

    public virtual void _SoftBodySetTotalMass(Rid body, float totalMass)
    {
    }

    public virtual unsafe void _SoftBodySetTransform(Rid body, Transform3D transform)
    {
    }

    public virtual void _SoftBodyUpdateRenderingServer(Rid body, PhysicsServer3DRenderingServerHandler renderingServerHandler)
    {
    }

    public virtual Rid _SpaceCreate()
    {
        return default;
    }

    public virtual int _SpaceGetContactCount(Rid space)
    {
        return default;
    }

    public virtual Vector3[] _SpaceGetContacts(Rid space)
    {
        return default;
    }

    public virtual PhysicsDirectSpaceState3D _SpaceGetDirectState(Rid space)
    {
        return default;
    }

    public virtual float _SpaceGetParam(Rid space, PhysicsServer3D.SpaceParameter param)
    {
        return default;
    }

    public virtual bool _SpaceIsActive(Rid space)
    {
        return default;
    }

    public virtual void _SpaceSetActive(Rid space, bool active)
    {
    }

    public virtual void _SpaceSetDebugContacts(Rid space, int maxContacts)
    {
    }

    public virtual void _SpaceSetParam(Rid space, PhysicsServer3D.SpaceParameter param, float value)
    {
    }

    public virtual Rid _SphereShapeCreate()
    {
        return default;
    }

    public virtual void _Step(float step)
    {
    }

    public virtual void _Sync()
    {
    }

    public virtual Rid _WorldBoundaryShapeCreate()
    {
        return default;
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyTestMotionIsExcludingBody, 4155700596ul);

    public bool BodyTestMotionIsExcludingBody(Rid body)
    {
        return NativeCalls.godot_icall_1_421(MethodBind0, GodotObject.GetPtr(this), body).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyTestMotionIsExcludingObject, 1116898809ul);

    public bool BodyTestMotionIsExcludingObject(ulong @object)
    {
        return NativeCalls.godot_icall_1_567(MethodBind1, GodotObject.GetPtr(this), @object).ToBool();
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__area_add_shape = "_AreaAddShape";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__area_attach_object_instance_id = "_AreaAttachObjectInstanceId";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__area_clear_shapes = "_AreaClearShapes";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__area_create = "_AreaCreate";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__area_get_collision_layer = "_AreaGetCollisionLayer";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__area_get_collision_mask = "_AreaGetCollisionMask";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__area_get_object_instance_id = "_AreaGetObjectInstanceId";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__area_get_param = "_AreaGetParam";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__area_get_shape = "_AreaGetShape";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__area_get_shape_count = "_AreaGetShapeCount";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__area_get_shape_transform = "_AreaGetShapeTransform";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__area_get_space = "_AreaGetSpace";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__area_get_transform = "_AreaGetTransform";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__area_remove_shape = "_AreaRemoveShape";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__area_set_area_monitor_callback = "_AreaSetAreaMonitorCallback";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__area_set_collision_layer = "_AreaSetCollisionLayer";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__area_set_collision_mask = "_AreaSetCollisionMask";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__area_set_monitor_callback = "_AreaSetMonitorCallback";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__area_set_monitorable = "_AreaSetMonitorable";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__area_set_param = "_AreaSetParam";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__area_set_ray_pickable = "_AreaSetRayPickable";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__area_set_shape = "_AreaSetShape";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__area_set_shape_disabled = "_AreaSetShapeDisabled";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__area_set_shape_transform = "_AreaSetShapeTransform";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__area_set_space = "_AreaSetSpace";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__area_set_transform = "_AreaSetTransform";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__body_add_collision_exception = "_BodyAddCollisionException";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__body_add_constant_central_force = "_BodyAddConstantCentralForce";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__body_add_constant_force = "_BodyAddConstantForce";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__body_add_constant_torque = "_BodyAddConstantTorque";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__body_add_shape = "_BodyAddShape";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__body_apply_central_force = "_BodyApplyCentralForce";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__body_apply_central_impulse = "_BodyApplyCentralImpulse";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__body_apply_force = "_BodyApplyForce";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__body_apply_impulse = "_BodyApplyImpulse";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__body_apply_torque = "_BodyApplyTorque";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__body_apply_torque_impulse = "_BodyApplyTorqueImpulse";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__body_attach_object_instance_id = "_BodyAttachObjectInstanceId";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__body_clear_shapes = "_BodyClearShapes";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__body_create = "_BodyCreate";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__body_get_collision_exceptions = "_BodyGetCollisionExceptions";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__body_get_collision_layer = "_BodyGetCollisionLayer";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__body_get_collision_mask = "_BodyGetCollisionMask";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__body_get_collision_priority = "_BodyGetCollisionPriority";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__body_get_constant_force = "_BodyGetConstantForce";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__body_get_constant_torque = "_BodyGetConstantTorque";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__body_get_contacts_reported_depth_threshold = "_BodyGetContactsReportedDepthThreshold";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__body_get_direct_state = "_BodyGetDirectState";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__body_get_max_contacts_reported = "_BodyGetMaxContactsReported";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__body_get_mode = "_BodyGetMode";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__body_get_object_instance_id = "_BodyGetObjectInstanceId";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__body_get_param = "_BodyGetParam";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__body_get_shape = "_BodyGetShape";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__body_get_shape_count = "_BodyGetShapeCount";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__body_get_shape_transform = "_BodyGetShapeTransform";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__body_get_space = "_BodyGetSpace";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__body_get_state = "_BodyGetState";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__body_get_user_flags = "_BodyGetUserFlags";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__body_is_axis_locked = "_BodyIsAxisLocked";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__body_is_continuous_collision_detection_enabled = "_BodyIsContinuousCollisionDetectionEnabled";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__body_is_omitting_force_integration = "_BodyIsOmittingForceIntegration";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__body_remove_collision_exception = "_BodyRemoveCollisionException";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__body_remove_shape = "_BodyRemoveShape";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__body_reset_mass_properties = "_BodyResetMassProperties";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__body_set_axis_lock = "_BodySetAxisLock";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__body_set_axis_velocity = "_BodySetAxisVelocity";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__body_set_collision_layer = "_BodySetCollisionLayer";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__body_set_collision_mask = "_BodySetCollisionMask";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__body_set_collision_priority = "_BodySetCollisionPriority";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__body_set_constant_force = "_BodySetConstantForce";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__body_set_constant_torque = "_BodySetConstantTorque";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__body_set_contacts_reported_depth_threshold = "_BodySetContactsReportedDepthThreshold";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__body_set_enable_continuous_collision_detection = "_BodySetEnableContinuousCollisionDetection";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__body_set_force_integration_callback = "_BodySetForceIntegrationCallback";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__body_set_max_contacts_reported = "_BodySetMaxContactsReported";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__body_set_mode = "_BodySetMode";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__body_set_omit_force_integration = "_BodySetOmitForceIntegration";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__body_set_param = "_BodySetParam";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__body_set_ray_pickable = "_BodySetRayPickable";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__body_set_shape = "_BodySetShape";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__body_set_shape_disabled = "_BodySetShapeDisabled";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__body_set_shape_transform = "_BodySetShapeTransform";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__body_set_space = "_BodySetSpace";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__body_set_state = "_BodySetState";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__body_set_state_sync_callback = "_BodySetStateSyncCallback";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__body_set_user_flags = "_BodySetUserFlags";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__box_shape_create = "_BoxShapeCreate";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__capsule_shape_create = "_CapsuleShapeCreate";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__concave_polygon_shape_create = "_ConcavePolygonShapeCreate";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__cone_twist_joint_get_param = "_ConeTwistJointGetParam";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__cone_twist_joint_set_param = "_ConeTwistJointSetParam";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__convex_polygon_shape_create = "_ConvexPolygonShapeCreate";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__custom_shape_create = "_CustomShapeCreate";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__cylinder_shape_create = "_CylinderShapeCreate";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__end_sync = "_EndSync";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__finish = "_Finish";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__flush_queries = "_FlushQueries";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__free_rid = "_FreeRid";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__generic_6dof_joint_get_flag = "_Generic6DofJointGetFlag";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__generic_6dof_joint_get_param = "_Generic6DofJointGetParam";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__generic_6dof_joint_set_flag = "_Generic6DofJointSetFlag";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__generic_6dof_joint_set_param = "_Generic6DofJointSetParam";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_process_info = "_GetProcessInfo";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__heightmap_shape_create = "_HeightmapShapeCreate";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__hinge_joint_get_flag = "_HingeJointGetFlag";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__hinge_joint_get_param = "_HingeJointGetParam";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__hinge_joint_set_flag = "_HingeJointSetFlag";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__hinge_joint_set_param = "_HingeJointSetParam";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__init = "_Init";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__is_flushing_queries = "_IsFlushingQueries";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__joint_clear = "_JointClear";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__joint_create = "_JointCreate";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__joint_disable_collisions_between_bodies = "_JointDisableCollisionsBetweenBodies";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__joint_get_solver_priority = "_JointGetSolverPriority";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__joint_get_type = "_JointGetType";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__joint_is_disabled_collisions_between_bodies = "_JointIsDisabledCollisionsBetweenBodies";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__joint_make_cone_twist = "_JointMakeConeTwist";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__joint_make_generic_6dof = "_JointMakeGeneric6Dof";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__joint_make_hinge = "_JointMakeHinge";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__joint_make_hinge_simple = "_JointMakeHingeSimple";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__joint_make_pin = "_JointMakePin";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__joint_make_slider = "_JointMakeSlider";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__joint_set_solver_priority = "_JointSetSolverPriority";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__pin_joint_get_local_a = "_PinJointGetLocalA";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__pin_joint_get_local_b = "_PinJointGetLocalB";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__pin_joint_get_param = "_PinJointGetParam";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__pin_joint_set_local_a = "_PinJointSetLocalA";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__pin_joint_set_local_b = "_PinJointSetLocalB";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__pin_joint_set_param = "_PinJointSetParam";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__separation_ray_shape_create = "_SeparationRayShapeCreate";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__set_active = "_SetActive";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__shape_get_custom_solver_bias = "_ShapeGetCustomSolverBias";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__shape_get_data = "_ShapeGetData";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__shape_get_margin = "_ShapeGetMargin";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__shape_get_type = "_ShapeGetType";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__shape_set_custom_solver_bias = "_ShapeSetCustomSolverBias";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__shape_set_data = "_ShapeSetData";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__shape_set_margin = "_ShapeSetMargin";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__slider_joint_get_param = "_SliderJointGetParam";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__slider_joint_set_param = "_SliderJointSetParam";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__soft_body_add_collision_exception = "_SoftBodyAddCollisionException";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__soft_body_apply_central_force = "_SoftBodyApplyCentralForce";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__soft_body_apply_central_impulse = "_SoftBodyApplyCentralImpulse";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__soft_body_apply_point_force = "_SoftBodyApplyPointForce";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__soft_body_apply_point_impulse = "_SoftBodyApplyPointImpulse";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__soft_body_create = "_SoftBodyCreate";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__soft_body_get_bounds = "_SoftBodyGetBounds";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__soft_body_get_collision_exceptions = "_SoftBodyGetCollisionExceptions";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__soft_body_get_collision_layer = "_SoftBodyGetCollisionLayer";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__soft_body_get_collision_mask = "_SoftBodyGetCollisionMask";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__soft_body_get_damping_coefficient = "_SoftBodyGetDampingCoefficient";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__soft_body_get_drag_coefficient = "_SoftBodyGetDragCoefficient";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__soft_body_get_linear_stiffness = "_SoftBodyGetLinearStiffness";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__soft_body_get_point_global_position = "_SoftBodyGetPointGlobalPosition";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__soft_body_get_pressure_coefficient = "_SoftBodyGetPressureCoefficient";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__soft_body_get_shrinking_factor = "_SoftBodyGetShrinkingFactor";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__soft_body_get_simulation_precision = "_SoftBodyGetSimulationPrecision";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__soft_body_get_space = "_SoftBodyGetSpace";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__soft_body_get_state = "_SoftBodyGetState";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__soft_body_get_total_mass = "_SoftBodyGetTotalMass";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__soft_body_is_point_pinned = "_SoftBodyIsPointPinned";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__soft_body_move_point = "_SoftBodyMovePoint";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__soft_body_pin_point = "_SoftBodyPinPoint";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__soft_body_remove_all_pinned_points = "_SoftBodyRemoveAllPinnedPoints";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__soft_body_remove_collision_exception = "_SoftBodyRemoveCollisionException";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__soft_body_set_collision_layer = "_SoftBodySetCollisionLayer";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__soft_body_set_collision_mask = "_SoftBodySetCollisionMask";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__soft_body_set_damping_coefficient = "_SoftBodySetDampingCoefficient";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__soft_body_set_drag_coefficient = "_SoftBodySetDragCoefficient";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__soft_body_set_linear_stiffness = "_SoftBodySetLinearStiffness";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__soft_body_set_mesh = "_SoftBodySetMesh";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__soft_body_set_pressure_coefficient = "_SoftBodySetPressureCoefficient";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__soft_body_set_ray_pickable = "_SoftBodySetRayPickable";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__soft_body_set_shrinking_factor = "_SoftBodySetShrinkingFactor";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__soft_body_set_simulation_precision = "_SoftBodySetSimulationPrecision";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__soft_body_set_space = "_SoftBodySetSpace";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__soft_body_set_state = "_SoftBodySetState";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__soft_body_set_total_mass = "_SoftBodySetTotalMass";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__soft_body_set_transform = "_SoftBodySetTransform";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__soft_body_update_rendering_server = "_SoftBodyUpdateRenderingServer";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__space_create = "_SpaceCreate";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__space_get_contact_count = "_SpaceGetContactCount";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__space_get_contacts = "_SpaceGetContacts";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__space_get_direct_state = "_SpaceGetDirectState";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__space_get_param = "_SpaceGetParam";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__space_is_active = "_SpaceIsActive";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__space_set_active = "_SpaceSetActive";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__space_set_debug_contacts = "_SpaceSetDebugContacts";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__space_set_param = "_SpaceSetParam";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__sphere_shape_create = "_SphereShapeCreate";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__step = "_Step";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__sync = "_Sync";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__world_boundary_shape_create = "_WorldBoundaryShapeCreate";

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
        if ((method == MethodProxyName__area_add_shape || method == MethodName._AreaAddShape) && args.Count == 4 && HasGodotClassMethod((godot_string_name)MethodProxyName__area_add_shape.NativeValue))
        {
            _AreaAddShape(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<Rid>(args[1]), VariantUtils.ConvertTo<Transform3D>(args[2]), VariantUtils.ConvertTo<bool>(args[3]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__area_attach_object_instance_id || method == MethodName._AreaAttachObjectInstanceId) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__area_attach_object_instance_id.NativeValue))
        {
            _AreaAttachObjectInstanceId(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<ulong>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__area_clear_shapes || method == MethodName._AreaClearShapes) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__area_clear_shapes.NativeValue))
        {
            _AreaClearShapes(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__area_create || method == MethodName._AreaCreate) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__area_create.NativeValue))
        {
            var callRet = _AreaCreate();
            ret = VariantUtils.CreateFrom<Rid>(callRet);
            return true;
        }
        if ((method == MethodProxyName__area_get_collision_layer || method == MethodName._AreaGetCollisionLayer) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__area_get_collision_layer.NativeValue))
        {
            var callRet = _AreaGetCollisionLayer(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<uint>(callRet);
            return true;
        }
        if ((method == MethodProxyName__area_get_collision_mask || method == MethodName._AreaGetCollisionMask) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__area_get_collision_mask.NativeValue))
        {
            var callRet = _AreaGetCollisionMask(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<uint>(callRet);
            return true;
        }
        if ((method == MethodProxyName__area_get_object_instance_id || method == MethodName._AreaGetObjectInstanceId) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__area_get_object_instance_id.NativeValue))
        {
            var callRet = _AreaGetObjectInstanceId(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<ulong>(callRet);
            return true;
        }
        if ((method == MethodProxyName__area_get_param || method == MethodName._AreaGetParam) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__area_get_param.NativeValue))
        {
            var callRet = _AreaGetParam(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<PhysicsServer3D.AreaParameter>(args[1]));
            ret = VariantUtils.CreateFrom<Variant>(callRet);
            return true;
        }
        if ((method == MethodProxyName__area_get_shape || method == MethodName._AreaGetShape) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__area_get_shape.NativeValue))
        {
            var callRet = _AreaGetShape(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<int>(args[1]));
            ret = VariantUtils.CreateFrom<Rid>(callRet);
            return true;
        }
        if ((method == MethodProxyName__area_get_shape_count || method == MethodName._AreaGetShapeCount) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__area_get_shape_count.NativeValue))
        {
            var callRet = _AreaGetShapeCount(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<int>(callRet);
            return true;
        }
        if ((method == MethodProxyName__area_get_shape_transform || method == MethodName._AreaGetShapeTransform) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__area_get_shape_transform.NativeValue))
        {
            var callRet = _AreaGetShapeTransform(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<int>(args[1]));
            ret = VariantUtils.CreateFrom<Transform3D>(callRet);
            return true;
        }
        if ((method == MethodProxyName__area_get_space || method == MethodName._AreaGetSpace) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__area_get_space.NativeValue))
        {
            var callRet = _AreaGetSpace(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<Rid>(callRet);
            return true;
        }
        if ((method == MethodProxyName__area_get_transform || method == MethodName._AreaGetTransform) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__area_get_transform.NativeValue))
        {
            var callRet = _AreaGetTransform(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<Transform3D>(callRet);
            return true;
        }
        if ((method == MethodProxyName__area_remove_shape || method == MethodName._AreaRemoveShape) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__area_remove_shape.NativeValue))
        {
            _AreaRemoveShape(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<int>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__area_set_area_monitor_callback || method == MethodName._AreaSetAreaMonitorCallback) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__area_set_area_monitor_callback.NativeValue))
        {
            _AreaSetAreaMonitorCallback(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<Callable>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__area_set_collision_layer || method == MethodName._AreaSetCollisionLayer) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__area_set_collision_layer.NativeValue))
        {
            _AreaSetCollisionLayer(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<uint>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__area_set_collision_mask || method == MethodName._AreaSetCollisionMask) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__area_set_collision_mask.NativeValue))
        {
            _AreaSetCollisionMask(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<uint>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__area_set_monitor_callback || method == MethodName._AreaSetMonitorCallback) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__area_set_monitor_callback.NativeValue))
        {
            _AreaSetMonitorCallback(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<Callable>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__area_set_monitorable || method == MethodName._AreaSetMonitorable) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__area_set_monitorable.NativeValue))
        {
            _AreaSetMonitorable(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<bool>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__area_set_param || method == MethodName._AreaSetParam) && args.Count == 3 && HasGodotClassMethod((godot_string_name)MethodProxyName__area_set_param.NativeValue))
        {
            _AreaSetParam(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<PhysicsServer3D.AreaParameter>(args[1]), VariantUtils.ConvertTo<Variant>(args[2]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__area_set_ray_pickable || method == MethodName._AreaSetRayPickable) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__area_set_ray_pickable.NativeValue))
        {
            _AreaSetRayPickable(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<bool>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__area_set_shape || method == MethodName._AreaSetShape) && args.Count == 3 && HasGodotClassMethod((godot_string_name)MethodProxyName__area_set_shape.NativeValue))
        {
            _AreaSetShape(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<int>(args[1]), VariantUtils.ConvertTo<Rid>(args[2]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__area_set_shape_disabled || method == MethodName._AreaSetShapeDisabled) && args.Count == 3 && HasGodotClassMethod((godot_string_name)MethodProxyName__area_set_shape_disabled.NativeValue))
        {
            _AreaSetShapeDisabled(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<int>(args[1]), VariantUtils.ConvertTo<bool>(args[2]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__area_set_shape_transform || method == MethodName._AreaSetShapeTransform) && args.Count == 3 && HasGodotClassMethod((godot_string_name)MethodProxyName__area_set_shape_transform.NativeValue))
        {
            _AreaSetShapeTransform(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<int>(args[1]), VariantUtils.ConvertTo<Transform3D>(args[2]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__area_set_space || method == MethodName._AreaSetSpace) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__area_set_space.NativeValue))
        {
            _AreaSetSpace(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<Rid>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__area_set_transform || method == MethodName._AreaSetTransform) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__area_set_transform.NativeValue))
        {
            _AreaSetTransform(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<Transform3D>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__body_add_collision_exception || method == MethodName._BodyAddCollisionException) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__body_add_collision_exception.NativeValue))
        {
            _BodyAddCollisionException(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<Rid>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__body_add_constant_central_force || method == MethodName._BodyAddConstantCentralForce) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__body_add_constant_central_force.NativeValue))
        {
            _BodyAddConstantCentralForce(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<Vector3>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__body_add_constant_force || method == MethodName._BodyAddConstantForce) && args.Count == 3 && HasGodotClassMethod((godot_string_name)MethodProxyName__body_add_constant_force.NativeValue))
        {
            _BodyAddConstantForce(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<Vector3>(args[1]), VariantUtils.ConvertTo<Vector3>(args[2]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__body_add_constant_torque || method == MethodName._BodyAddConstantTorque) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__body_add_constant_torque.NativeValue))
        {
            _BodyAddConstantTorque(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<Vector3>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__body_add_shape || method == MethodName._BodyAddShape) && args.Count == 4 && HasGodotClassMethod((godot_string_name)MethodProxyName__body_add_shape.NativeValue))
        {
            _BodyAddShape(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<Rid>(args[1]), VariantUtils.ConvertTo<Transform3D>(args[2]), VariantUtils.ConvertTo<bool>(args[3]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__body_apply_central_force || method == MethodName._BodyApplyCentralForce) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__body_apply_central_force.NativeValue))
        {
            _BodyApplyCentralForce(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<Vector3>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__body_apply_central_impulse || method == MethodName._BodyApplyCentralImpulse) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__body_apply_central_impulse.NativeValue))
        {
            _BodyApplyCentralImpulse(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<Vector3>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__body_apply_force || method == MethodName._BodyApplyForce) && args.Count == 3 && HasGodotClassMethod((godot_string_name)MethodProxyName__body_apply_force.NativeValue))
        {
            _BodyApplyForce(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<Vector3>(args[1]), VariantUtils.ConvertTo<Vector3>(args[2]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__body_apply_impulse || method == MethodName._BodyApplyImpulse) && args.Count == 3 && HasGodotClassMethod((godot_string_name)MethodProxyName__body_apply_impulse.NativeValue))
        {
            _BodyApplyImpulse(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<Vector3>(args[1]), VariantUtils.ConvertTo<Vector3>(args[2]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__body_apply_torque || method == MethodName._BodyApplyTorque) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__body_apply_torque.NativeValue))
        {
            _BodyApplyTorque(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<Vector3>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__body_apply_torque_impulse || method == MethodName._BodyApplyTorqueImpulse) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__body_apply_torque_impulse.NativeValue))
        {
            _BodyApplyTorqueImpulse(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<Vector3>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__body_attach_object_instance_id || method == MethodName._BodyAttachObjectInstanceId) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__body_attach_object_instance_id.NativeValue))
        {
            _BodyAttachObjectInstanceId(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<ulong>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__body_clear_shapes || method == MethodName._BodyClearShapes) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__body_clear_shapes.NativeValue))
        {
            _BodyClearShapes(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__body_create || method == MethodName._BodyCreate) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__body_create.NativeValue))
        {
            var callRet = _BodyCreate();
            ret = VariantUtils.CreateFrom<Rid>(callRet);
            return true;
        }
        if ((method == MethodProxyName__body_get_collision_exceptions || method == MethodName._BodyGetCollisionExceptions) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__body_get_collision_exceptions.NativeValue))
        {
            var callRet = _BodyGetCollisionExceptions(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFromArray(callRet);
            return true;
        }
        if ((method == MethodProxyName__body_get_collision_layer || method == MethodName._BodyGetCollisionLayer) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__body_get_collision_layer.NativeValue))
        {
            var callRet = _BodyGetCollisionLayer(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<uint>(callRet);
            return true;
        }
        if ((method == MethodProxyName__body_get_collision_mask || method == MethodName._BodyGetCollisionMask) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__body_get_collision_mask.NativeValue))
        {
            var callRet = _BodyGetCollisionMask(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<uint>(callRet);
            return true;
        }
        if ((method == MethodProxyName__body_get_collision_priority || method == MethodName._BodyGetCollisionPriority) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__body_get_collision_priority.NativeValue))
        {
            var callRet = _BodyGetCollisionPriority(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<float>(callRet);
            return true;
        }
        if ((method == MethodProxyName__body_get_constant_force || method == MethodName._BodyGetConstantForce) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__body_get_constant_force.NativeValue))
        {
            var callRet = _BodyGetConstantForce(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<Vector3>(callRet);
            return true;
        }
        if ((method == MethodProxyName__body_get_constant_torque || method == MethodName._BodyGetConstantTorque) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__body_get_constant_torque.NativeValue))
        {
            var callRet = _BodyGetConstantTorque(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<Vector3>(callRet);
            return true;
        }
        if ((method == MethodProxyName__body_get_contacts_reported_depth_threshold || method == MethodName._BodyGetContactsReportedDepthThreshold) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__body_get_contacts_reported_depth_threshold.NativeValue))
        {
            var callRet = _BodyGetContactsReportedDepthThreshold(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<float>(callRet);
            return true;
        }
        if ((method == MethodProxyName__body_get_direct_state || method == MethodName._BodyGetDirectState) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__body_get_direct_state.NativeValue))
        {
            var callRet = _BodyGetDirectState(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<PhysicsDirectBodyState3D>(callRet);
            return true;
        }
        if ((method == MethodProxyName__body_get_max_contacts_reported || method == MethodName._BodyGetMaxContactsReported) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__body_get_max_contacts_reported.NativeValue))
        {
            var callRet = _BodyGetMaxContactsReported(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<int>(callRet);
            return true;
        }
        if ((method == MethodProxyName__body_get_mode || method == MethodName._BodyGetMode) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__body_get_mode.NativeValue))
        {
            var callRet = _BodyGetMode(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<PhysicsServer3D.BodyMode>(callRet);
            return true;
        }
        if ((method == MethodProxyName__body_get_object_instance_id || method == MethodName._BodyGetObjectInstanceId) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__body_get_object_instance_id.NativeValue))
        {
            var callRet = _BodyGetObjectInstanceId(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<ulong>(callRet);
            return true;
        }
        if ((method == MethodProxyName__body_get_param || method == MethodName._BodyGetParam) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__body_get_param.NativeValue))
        {
            var callRet = _BodyGetParam(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<PhysicsServer3D.BodyParameter>(args[1]));
            ret = VariantUtils.CreateFrom<Variant>(callRet);
            return true;
        }
        if ((method == MethodProxyName__body_get_shape || method == MethodName._BodyGetShape) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__body_get_shape.NativeValue))
        {
            var callRet = _BodyGetShape(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<int>(args[1]));
            ret = VariantUtils.CreateFrom<Rid>(callRet);
            return true;
        }
        if ((method == MethodProxyName__body_get_shape_count || method == MethodName._BodyGetShapeCount) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__body_get_shape_count.NativeValue))
        {
            var callRet = _BodyGetShapeCount(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<int>(callRet);
            return true;
        }
        if ((method == MethodProxyName__body_get_shape_transform || method == MethodName._BodyGetShapeTransform) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__body_get_shape_transform.NativeValue))
        {
            var callRet = _BodyGetShapeTransform(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<int>(args[1]));
            ret = VariantUtils.CreateFrom<Transform3D>(callRet);
            return true;
        }
        if ((method == MethodProxyName__body_get_space || method == MethodName._BodyGetSpace) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__body_get_space.NativeValue))
        {
            var callRet = _BodyGetSpace(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<Rid>(callRet);
            return true;
        }
        if ((method == MethodProxyName__body_get_state || method == MethodName._BodyGetState) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__body_get_state.NativeValue))
        {
            var callRet = _BodyGetState(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<PhysicsServer3D.BodyState>(args[1]));
            ret = VariantUtils.CreateFrom<Variant>(callRet);
            return true;
        }
        if ((method == MethodProxyName__body_get_user_flags || method == MethodName._BodyGetUserFlags) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__body_get_user_flags.NativeValue))
        {
            var callRet = _BodyGetUserFlags(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<uint>(callRet);
            return true;
        }
        if ((method == MethodProxyName__body_is_axis_locked || method == MethodName._BodyIsAxisLocked) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__body_is_axis_locked.NativeValue))
        {
            var callRet = _BodyIsAxisLocked(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<PhysicsServer3D.BodyAxis>(args[1]));
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__body_is_continuous_collision_detection_enabled || method == MethodName._BodyIsContinuousCollisionDetectionEnabled) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__body_is_continuous_collision_detection_enabled.NativeValue))
        {
            var callRet = _BodyIsContinuousCollisionDetectionEnabled(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__body_is_omitting_force_integration || method == MethodName._BodyIsOmittingForceIntegration) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__body_is_omitting_force_integration.NativeValue))
        {
            var callRet = _BodyIsOmittingForceIntegration(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__body_remove_collision_exception || method == MethodName._BodyRemoveCollisionException) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__body_remove_collision_exception.NativeValue))
        {
            _BodyRemoveCollisionException(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<Rid>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__body_remove_shape || method == MethodName._BodyRemoveShape) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__body_remove_shape.NativeValue))
        {
            _BodyRemoveShape(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<int>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__body_reset_mass_properties || method == MethodName._BodyResetMassProperties) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__body_reset_mass_properties.NativeValue))
        {
            _BodyResetMassProperties(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__body_set_axis_lock || method == MethodName._BodySetAxisLock) && args.Count == 3 && HasGodotClassMethod((godot_string_name)MethodProxyName__body_set_axis_lock.NativeValue))
        {
            _BodySetAxisLock(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<PhysicsServer3D.BodyAxis>(args[1]), VariantUtils.ConvertTo<bool>(args[2]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__body_set_axis_velocity || method == MethodName._BodySetAxisVelocity) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__body_set_axis_velocity.NativeValue))
        {
            _BodySetAxisVelocity(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<Vector3>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__body_set_collision_layer || method == MethodName._BodySetCollisionLayer) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__body_set_collision_layer.NativeValue))
        {
            _BodySetCollisionLayer(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<uint>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__body_set_collision_mask || method == MethodName._BodySetCollisionMask) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__body_set_collision_mask.NativeValue))
        {
            _BodySetCollisionMask(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<uint>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__body_set_collision_priority || method == MethodName._BodySetCollisionPriority) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__body_set_collision_priority.NativeValue))
        {
            _BodySetCollisionPriority(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<float>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__body_set_constant_force || method == MethodName._BodySetConstantForce) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__body_set_constant_force.NativeValue))
        {
            _BodySetConstantForce(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<Vector3>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__body_set_constant_torque || method == MethodName._BodySetConstantTorque) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__body_set_constant_torque.NativeValue))
        {
            _BodySetConstantTorque(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<Vector3>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__body_set_contacts_reported_depth_threshold || method == MethodName._BodySetContactsReportedDepthThreshold) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__body_set_contacts_reported_depth_threshold.NativeValue))
        {
            _BodySetContactsReportedDepthThreshold(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<float>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__body_set_enable_continuous_collision_detection || method == MethodName._BodySetEnableContinuousCollisionDetection) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__body_set_enable_continuous_collision_detection.NativeValue))
        {
            _BodySetEnableContinuousCollisionDetection(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<bool>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__body_set_force_integration_callback || method == MethodName._BodySetForceIntegrationCallback) && args.Count == 3 && HasGodotClassMethod((godot_string_name)MethodProxyName__body_set_force_integration_callback.NativeValue))
        {
            _BodySetForceIntegrationCallback(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<Callable>(args[1]), VariantUtils.ConvertTo<Variant>(args[2]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__body_set_max_contacts_reported || method == MethodName._BodySetMaxContactsReported) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__body_set_max_contacts_reported.NativeValue))
        {
            _BodySetMaxContactsReported(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<int>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__body_set_mode || method == MethodName._BodySetMode) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__body_set_mode.NativeValue))
        {
            _BodySetMode(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<PhysicsServer3D.BodyMode>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__body_set_omit_force_integration || method == MethodName._BodySetOmitForceIntegration) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__body_set_omit_force_integration.NativeValue))
        {
            _BodySetOmitForceIntegration(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<bool>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__body_set_param || method == MethodName._BodySetParam) && args.Count == 3 && HasGodotClassMethod((godot_string_name)MethodProxyName__body_set_param.NativeValue))
        {
            _BodySetParam(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<PhysicsServer3D.BodyParameter>(args[1]), VariantUtils.ConvertTo<Variant>(args[2]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__body_set_ray_pickable || method == MethodName._BodySetRayPickable) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__body_set_ray_pickable.NativeValue))
        {
            _BodySetRayPickable(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<bool>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__body_set_shape || method == MethodName._BodySetShape) && args.Count == 3 && HasGodotClassMethod((godot_string_name)MethodProxyName__body_set_shape.NativeValue))
        {
            _BodySetShape(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<int>(args[1]), VariantUtils.ConvertTo<Rid>(args[2]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__body_set_shape_disabled || method == MethodName._BodySetShapeDisabled) && args.Count == 3 && HasGodotClassMethod((godot_string_name)MethodProxyName__body_set_shape_disabled.NativeValue))
        {
            _BodySetShapeDisabled(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<int>(args[1]), VariantUtils.ConvertTo<bool>(args[2]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__body_set_shape_transform || method == MethodName._BodySetShapeTransform) && args.Count == 3 && HasGodotClassMethod((godot_string_name)MethodProxyName__body_set_shape_transform.NativeValue))
        {
            _BodySetShapeTransform(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<int>(args[1]), VariantUtils.ConvertTo<Transform3D>(args[2]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__body_set_space || method == MethodName._BodySetSpace) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__body_set_space.NativeValue))
        {
            _BodySetSpace(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<Rid>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__body_set_state || method == MethodName._BodySetState) && args.Count == 3 && HasGodotClassMethod((godot_string_name)MethodProxyName__body_set_state.NativeValue))
        {
            _BodySetState(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<PhysicsServer3D.BodyState>(args[1]), VariantUtils.ConvertTo<Variant>(args[2]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__body_set_state_sync_callback || method == MethodName._BodySetStateSyncCallback) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__body_set_state_sync_callback.NativeValue))
        {
            _BodySetStateSyncCallback(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<Callable>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__body_set_user_flags || method == MethodName._BodySetUserFlags) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__body_set_user_flags.NativeValue))
        {
            _BodySetUserFlags(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<uint>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__box_shape_create || method == MethodName._BoxShapeCreate) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__box_shape_create.NativeValue))
        {
            var callRet = _BoxShapeCreate();
            ret = VariantUtils.CreateFrom<Rid>(callRet);
            return true;
        }
        if ((method == MethodProxyName__capsule_shape_create || method == MethodName._CapsuleShapeCreate) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__capsule_shape_create.NativeValue))
        {
            var callRet = _CapsuleShapeCreate();
            ret = VariantUtils.CreateFrom<Rid>(callRet);
            return true;
        }
        if ((method == MethodProxyName__concave_polygon_shape_create || method == MethodName._ConcavePolygonShapeCreate) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__concave_polygon_shape_create.NativeValue))
        {
            var callRet = _ConcavePolygonShapeCreate();
            ret = VariantUtils.CreateFrom<Rid>(callRet);
            return true;
        }
        if ((method == MethodProxyName__cone_twist_joint_get_param || method == MethodName._ConeTwistJointGetParam) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__cone_twist_joint_get_param.NativeValue))
        {
            var callRet = _ConeTwistJointGetParam(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<PhysicsServer3D.ConeTwistJointParam>(args[1]));
            ret = VariantUtils.CreateFrom<float>(callRet);
            return true;
        }
        if ((method == MethodProxyName__cone_twist_joint_set_param || method == MethodName._ConeTwistJointSetParam) && args.Count == 3 && HasGodotClassMethod((godot_string_name)MethodProxyName__cone_twist_joint_set_param.NativeValue))
        {
            _ConeTwistJointSetParam(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<PhysicsServer3D.ConeTwistJointParam>(args[1]), VariantUtils.ConvertTo<float>(args[2]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__convex_polygon_shape_create || method == MethodName._ConvexPolygonShapeCreate) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__convex_polygon_shape_create.NativeValue))
        {
            var callRet = _ConvexPolygonShapeCreate();
            ret = VariantUtils.CreateFrom<Rid>(callRet);
            return true;
        }
        if ((method == MethodProxyName__custom_shape_create || method == MethodName._CustomShapeCreate) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__custom_shape_create.NativeValue))
        {
            var callRet = _CustomShapeCreate();
            ret = VariantUtils.CreateFrom<Rid>(callRet);
            return true;
        }
        if ((method == MethodProxyName__cylinder_shape_create || method == MethodName._CylinderShapeCreate) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__cylinder_shape_create.NativeValue))
        {
            var callRet = _CylinderShapeCreate();
            ret = VariantUtils.CreateFrom<Rid>(callRet);
            return true;
        }
        if ((method == MethodProxyName__end_sync || method == MethodName._EndSync) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__end_sync.NativeValue))
        {
            _EndSync();
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__finish || method == MethodName._Finish) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__finish.NativeValue))
        {
            _Finish();
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__flush_queries || method == MethodName._FlushQueries) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__flush_queries.NativeValue))
        {
            _FlushQueries();
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__free_rid || method == MethodName._FreeRid) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__free_rid.NativeValue))
        {
            _FreeRid(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__generic_6dof_joint_get_flag || method == MethodName._Generic6DofJointGetFlag) && args.Count == 3 && HasGodotClassMethod((godot_string_name)MethodProxyName__generic_6dof_joint_get_flag.NativeValue))
        {
            var callRet = _Generic6DofJointGetFlag(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<Vector3.Axis>(args[1]), VariantUtils.ConvertTo<PhysicsServer3D.G6DofJointAxisFlag>(args[2]));
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__generic_6dof_joint_get_param || method == MethodName._Generic6DofJointGetParam) && args.Count == 3 && HasGodotClassMethod((godot_string_name)MethodProxyName__generic_6dof_joint_get_param.NativeValue))
        {
            var callRet = _Generic6DofJointGetParam(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<Vector3.Axis>(args[1]), VariantUtils.ConvertTo<PhysicsServer3D.G6DofJointAxisParam>(args[2]));
            ret = VariantUtils.CreateFrom<float>(callRet);
            return true;
        }
        if ((method == MethodProxyName__generic_6dof_joint_set_flag || method == MethodName._Generic6DofJointSetFlag) && args.Count == 4 && HasGodotClassMethod((godot_string_name)MethodProxyName__generic_6dof_joint_set_flag.NativeValue))
        {
            _Generic6DofJointSetFlag(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<Vector3.Axis>(args[1]), VariantUtils.ConvertTo<PhysicsServer3D.G6DofJointAxisFlag>(args[2]), VariantUtils.ConvertTo<bool>(args[3]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__generic_6dof_joint_set_param || method == MethodName._Generic6DofJointSetParam) && args.Count == 4 && HasGodotClassMethod((godot_string_name)MethodProxyName__generic_6dof_joint_set_param.NativeValue))
        {
            _Generic6DofJointSetParam(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<Vector3.Axis>(args[1]), VariantUtils.ConvertTo<PhysicsServer3D.G6DofJointAxisParam>(args[2]), VariantUtils.ConvertTo<float>(args[3]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__get_process_info || method == MethodName._GetProcessInfo) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_process_info.NativeValue))
        {
            var callRet = _GetProcessInfo(VariantUtils.ConvertTo<PhysicsServer3D.ProcessInfo>(args[0]));
            ret = VariantUtils.CreateFrom<int>(callRet);
            return true;
        }
        if ((method == MethodProxyName__heightmap_shape_create || method == MethodName._HeightmapShapeCreate) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__heightmap_shape_create.NativeValue))
        {
            var callRet = _HeightmapShapeCreate();
            ret = VariantUtils.CreateFrom<Rid>(callRet);
            return true;
        }
        if ((method == MethodProxyName__hinge_joint_get_flag || method == MethodName._HingeJointGetFlag) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__hinge_joint_get_flag.NativeValue))
        {
            var callRet = _HingeJointGetFlag(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<PhysicsServer3D.HingeJointFlag>(args[1]));
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__hinge_joint_get_param || method == MethodName._HingeJointGetParam) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__hinge_joint_get_param.NativeValue))
        {
            var callRet = _HingeJointGetParam(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<PhysicsServer3D.HingeJointParam>(args[1]));
            ret = VariantUtils.CreateFrom<float>(callRet);
            return true;
        }
        if ((method == MethodProxyName__hinge_joint_set_flag || method == MethodName._HingeJointSetFlag) && args.Count == 3 && HasGodotClassMethod((godot_string_name)MethodProxyName__hinge_joint_set_flag.NativeValue))
        {
            _HingeJointSetFlag(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<PhysicsServer3D.HingeJointFlag>(args[1]), VariantUtils.ConvertTo<bool>(args[2]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__hinge_joint_set_param || method == MethodName._HingeJointSetParam) && args.Count == 3 && HasGodotClassMethod((godot_string_name)MethodProxyName__hinge_joint_set_param.NativeValue))
        {
            _HingeJointSetParam(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<PhysicsServer3D.HingeJointParam>(args[1]), VariantUtils.ConvertTo<float>(args[2]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__init || method == MethodName._Init) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__init.NativeValue))
        {
            _Init();
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__is_flushing_queries || method == MethodName._IsFlushingQueries) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__is_flushing_queries.NativeValue))
        {
            var callRet = _IsFlushingQueries();
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__joint_clear || method == MethodName._JointClear) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__joint_clear.NativeValue))
        {
            _JointClear(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__joint_create || method == MethodName._JointCreate) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__joint_create.NativeValue))
        {
            var callRet = _JointCreate();
            ret = VariantUtils.CreateFrom<Rid>(callRet);
            return true;
        }
        if ((method == MethodProxyName__joint_disable_collisions_between_bodies || method == MethodName._JointDisableCollisionsBetweenBodies) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__joint_disable_collisions_between_bodies.NativeValue))
        {
            _JointDisableCollisionsBetweenBodies(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<bool>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__joint_get_solver_priority || method == MethodName._JointGetSolverPriority) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__joint_get_solver_priority.NativeValue))
        {
            var callRet = _JointGetSolverPriority(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<int>(callRet);
            return true;
        }
        if ((method == MethodProxyName__joint_get_type || method == MethodName._JointGetType) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__joint_get_type.NativeValue))
        {
            var callRet = _JointGetType(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<PhysicsServer3D.JointType>(callRet);
            return true;
        }
        if ((method == MethodProxyName__joint_is_disabled_collisions_between_bodies || method == MethodName._JointIsDisabledCollisionsBetweenBodies) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__joint_is_disabled_collisions_between_bodies.NativeValue))
        {
            var callRet = _JointIsDisabledCollisionsBetweenBodies(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__joint_make_cone_twist || method == MethodName._JointMakeConeTwist) && args.Count == 5 && HasGodotClassMethod((godot_string_name)MethodProxyName__joint_make_cone_twist.NativeValue))
        {
            _JointMakeConeTwist(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<Rid>(args[1]), VariantUtils.ConvertTo<Transform3D>(args[2]), VariantUtils.ConvertTo<Rid>(args[3]), VariantUtils.ConvertTo<Transform3D>(args[4]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__joint_make_generic_6dof || method == MethodName._JointMakeGeneric6Dof) && args.Count == 5 && HasGodotClassMethod((godot_string_name)MethodProxyName__joint_make_generic_6dof.NativeValue))
        {
            _JointMakeGeneric6Dof(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<Rid>(args[1]), VariantUtils.ConvertTo<Transform3D>(args[2]), VariantUtils.ConvertTo<Rid>(args[3]), VariantUtils.ConvertTo<Transform3D>(args[4]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__joint_make_hinge || method == MethodName._JointMakeHinge) && args.Count == 5 && HasGodotClassMethod((godot_string_name)MethodProxyName__joint_make_hinge.NativeValue))
        {
            _JointMakeHinge(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<Rid>(args[1]), VariantUtils.ConvertTo<Transform3D>(args[2]), VariantUtils.ConvertTo<Rid>(args[3]), VariantUtils.ConvertTo<Transform3D>(args[4]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__joint_make_hinge_simple || method == MethodName._JointMakeHingeSimple) && args.Count == 7 && HasGodotClassMethod((godot_string_name)MethodProxyName__joint_make_hinge_simple.NativeValue))
        {
            _JointMakeHingeSimple(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<Rid>(args[1]), VariantUtils.ConvertTo<Vector3>(args[2]), VariantUtils.ConvertTo<Vector3>(args[3]), VariantUtils.ConvertTo<Rid>(args[4]), VariantUtils.ConvertTo<Vector3>(args[5]), VariantUtils.ConvertTo<Vector3>(args[6]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__joint_make_pin || method == MethodName._JointMakePin) && args.Count == 5 && HasGodotClassMethod((godot_string_name)MethodProxyName__joint_make_pin.NativeValue))
        {
            _JointMakePin(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<Rid>(args[1]), VariantUtils.ConvertTo<Vector3>(args[2]), VariantUtils.ConvertTo<Rid>(args[3]), VariantUtils.ConvertTo<Vector3>(args[4]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__joint_make_slider || method == MethodName._JointMakeSlider) && args.Count == 5 && HasGodotClassMethod((godot_string_name)MethodProxyName__joint_make_slider.NativeValue))
        {
            _JointMakeSlider(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<Rid>(args[1]), VariantUtils.ConvertTo<Transform3D>(args[2]), VariantUtils.ConvertTo<Rid>(args[3]), VariantUtils.ConvertTo<Transform3D>(args[4]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__joint_set_solver_priority || method == MethodName._JointSetSolverPriority) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__joint_set_solver_priority.NativeValue))
        {
            _JointSetSolverPriority(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<int>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__pin_joint_get_local_a || method == MethodName._PinJointGetLocalA) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__pin_joint_get_local_a.NativeValue))
        {
            var callRet = _PinJointGetLocalA(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<Vector3>(callRet);
            return true;
        }
        if ((method == MethodProxyName__pin_joint_get_local_b || method == MethodName._PinJointGetLocalB) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__pin_joint_get_local_b.NativeValue))
        {
            var callRet = _PinJointGetLocalB(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<Vector3>(callRet);
            return true;
        }
        if ((method == MethodProxyName__pin_joint_get_param || method == MethodName._PinJointGetParam) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__pin_joint_get_param.NativeValue))
        {
            var callRet = _PinJointGetParam(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<PhysicsServer3D.PinJointParam>(args[1]));
            ret = VariantUtils.CreateFrom<float>(callRet);
            return true;
        }
        if ((method == MethodProxyName__pin_joint_set_local_a || method == MethodName._PinJointSetLocalA) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__pin_joint_set_local_a.NativeValue))
        {
            _PinJointSetLocalA(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<Vector3>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__pin_joint_set_local_b || method == MethodName._PinJointSetLocalB) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__pin_joint_set_local_b.NativeValue))
        {
            _PinJointSetLocalB(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<Vector3>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__pin_joint_set_param || method == MethodName._PinJointSetParam) && args.Count == 3 && HasGodotClassMethod((godot_string_name)MethodProxyName__pin_joint_set_param.NativeValue))
        {
            _PinJointSetParam(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<PhysicsServer3D.PinJointParam>(args[1]), VariantUtils.ConvertTo<float>(args[2]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__separation_ray_shape_create || method == MethodName._SeparationRayShapeCreate) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__separation_ray_shape_create.NativeValue))
        {
            var callRet = _SeparationRayShapeCreate();
            ret = VariantUtils.CreateFrom<Rid>(callRet);
            return true;
        }
        if ((method == MethodProxyName__set_active || method == MethodName._SetActive) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__set_active.NativeValue))
        {
            _SetActive(VariantUtils.ConvertTo<bool>(args[0]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__shape_get_custom_solver_bias || method == MethodName._ShapeGetCustomSolverBias) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__shape_get_custom_solver_bias.NativeValue))
        {
            var callRet = _ShapeGetCustomSolverBias(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<float>(callRet);
            return true;
        }
        if ((method == MethodProxyName__shape_get_data || method == MethodName._ShapeGetData) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__shape_get_data.NativeValue))
        {
            var callRet = _ShapeGetData(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<Variant>(callRet);
            return true;
        }
        if ((method == MethodProxyName__shape_get_margin || method == MethodName._ShapeGetMargin) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__shape_get_margin.NativeValue))
        {
            var callRet = _ShapeGetMargin(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<float>(callRet);
            return true;
        }
        if ((method == MethodProxyName__shape_get_type || method == MethodName._ShapeGetType) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__shape_get_type.NativeValue))
        {
            var callRet = _ShapeGetType(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<PhysicsServer3D.ShapeType>(callRet);
            return true;
        }
        if ((method == MethodProxyName__shape_set_custom_solver_bias || method == MethodName._ShapeSetCustomSolverBias) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__shape_set_custom_solver_bias.NativeValue))
        {
            _ShapeSetCustomSolverBias(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<float>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__shape_set_data || method == MethodName._ShapeSetData) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__shape_set_data.NativeValue))
        {
            _ShapeSetData(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<Variant>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__shape_set_margin || method == MethodName._ShapeSetMargin) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__shape_set_margin.NativeValue))
        {
            _ShapeSetMargin(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<float>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__slider_joint_get_param || method == MethodName._SliderJointGetParam) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__slider_joint_get_param.NativeValue))
        {
            var callRet = _SliderJointGetParam(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<PhysicsServer3D.SliderJointParam>(args[1]));
            ret = VariantUtils.CreateFrom<float>(callRet);
            return true;
        }
        if ((method == MethodProxyName__slider_joint_set_param || method == MethodName._SliderJointSetParam) && args.Count == 3 && HasGodotClassMethod((godot_string_name)MethodProxyName__slider_joint_set_param.NativeValue))
        {
            _SliderJointSetParam(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<PhysicsServer3D.SliderJointParam>(args[1]), VariantUtils.ConvertTo<float>(args[2]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__soft_body_add_collision_exception || method == MethodName._SoftBodyAddCollisionException) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__soft_body_add_collision_exception.NativeValue))
        {
            _SoftBodyAddCollisionException(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<Rid>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__soft_body_apply_central_force || method == MethodName._SoftBodyApplyCentralForce) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__soft_body_apply_central_force.NativeValue))
        {
            _SoftBodyApplyCentralForce(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<Vector3>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__soft_body_apply_central_impulse || method == MethodName._SoftBodyApplyCentralImpulse) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__soft_body_apply_central_impulse.NativeValue))
        {
            _SoftBodyApplyCentralImpulse(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<Vector3>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__soft_body_apply_point_force || method == MethodName._SoftBodyApplyPointForce) && args.Count == 3 && HasGodotClassMethod((godot_string_name)MethodProxyName__soft_body_apply_point_force.NativeValue))
        {
            _SoftBodyApplyPointForce(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<int>(args[1]), VariantUtils.ConvertTo<Vector3>(args[2]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__soft_body_apply_point_impulse || method == MethodName._SoftBodyApplyPointImpulse) && args.Count == 3 && HasGodotClassMethod((godot_string_name)MethodProxyName__soft_body_apply_point_impulse.NativeValue))
        {
            _SoftBodyApplyPointImpulse(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<int>(args[1]), VariantUtils.ConvertTo<Vector3>(args[2]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__soft_body_create || method == MethodName._SoftBodyCreate) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__soft_body_create.NativeValue))
        {
            var callRet = _SoftBodyCreate();
            ret = VariantUtils.CreateFrom<Rid>(callRet);
            return true;
        }
        if ((method == MethodProxyName__soft_body_get_bounds || method == MethodName._SoftBodyGetBounds) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__soft_body_get_bounds.NativeValue))
        {
            var callRet = _SoftBodyGetBounds(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<Aabb>(callRet);
            return true;
        }
        if ((method == MethodProxyName__soft_body_get_collision_exceptions || method == MethodName._SoftBodyGetCollisionExceptions) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__soft_body_get_collision_exceptions.NativeValue))
        {
            var callRet = _SoftBodyGetCollisionExceptions(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFromArray(callRet);
            return true;
        }
        if ((method == MethodProxyName__soft_body_get_collision_layer || method == MethodName._SoftBodyGetCollisionLayer) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__soft_body_get_collision_layer.NativeValue))
        {
            var callRet = _SoftBodyGetCollisionLayer(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<uint>(callRet);
            return true;
        }
        if ((method == MethodProxyName__soft_body_get_collision_mask || method == MethodName._SoftBodyGetCollisionMask) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__soft_body_get_collision_mask.NativeValue))
        {
            var callRet = _SoftBodyGetCollisionMask(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<uint>(callRet);
            return true;
        }
        if ((method == MethodProxyName__soft_body_get_damping_coefficient || method == MethodName._SoftBodyGetDampingCoefficient) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__soft_body_get_damping_coefficient.NativeValue))
        {
            var callRet = _SoftBodyGetDampingCoefficient(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<float>(callRet);
            return true;
        }
        if ((method == MethodProxyName__soft_body_get_drag_coefficient || method == MethodName._SoftBodyGetDragCoefficient) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__soft_body_get_drag_coefficient.NativeValue))
        {
            var callRet = _SoftBodyGetDragCoefficient(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<float>(callRet);
            return true;
        }
        if ((method == MethodProxyName__soft_body_get_linear_stiffness || method == MethodName._SoftBodyGetLinearStiffness) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__soft_body_get_linear_stiffness.NativeValue))
        {
            var callRet = _SoftBodyGetLinearStiffness(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<float>(callRet);
            return true;
        }
        if ((method == MethodProxyName__soft_body_get_point_global_position || method == MethodName._SoftBodyGetPointGlobalPosition) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__soft_body_get_point_global_position.NativeValue))
        {
            var callRet = _SoftBodyGetPointGlobalPosition(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<int>(args[1]));
            ret = VariantUtils.CreateFrom<Vector3>(callRet);
            return true;
        }
        if ((method == MethodProxyName__soft_body_get_pressure_coefficient || method == MethodName._SoftBodyGetPressureCoefficient) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__soft_body_get_pressure_coefficient.NativeValue))
        {
            var callRet = _SoftBodyGetPressureCoefficient(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<float>(callRet);
            return true;
        }
        if ((method == MethodProxyName__soft_body_get_shrinking_factor || method == MethodName._SoftBodyGetShrinkingFactor) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__soft_body_get_shrinking_factor.NativeValue))
        {
            var callRet = _SoftBodyGetShrinkingFactor(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<float>(callRet);
            return true;
        }
        if ((method == MethodProxyName__soft_body_get_simulation_precision || method == MethodName._SoftBodyGetSimulationPrecision) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__soft_body_get_simulation_precision.NativeValue))
        {
            var callRet = _SoftBodyGetSimulationPrecision(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<int>(callRet);
            return true;
        }
        if ((method == MethodProxyName__soft_body_get_space || method == MethodName._SoftBodyGetSpace) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__soft_body_get_space.NativeValue))
        {
            var callRet = _SoftBodyGetSpace(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<Rid>(callRet);
            return true;
        }
        if ((method == MethodProxyName__soft_body_get_state || method == MethodName._SoftBodyGetState) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__soft_body_get_state.NativeValue))
        {
            var callRet = _SoftBodyGetState(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<PhysicsServer3D.BodyState>(args[1]));
            ret = VariantUtils.CreateFrom<Variant>(callRet);
            return true;
        }
        if ((method == MethodProxyName__soft_body_get_total_mass || method == MethodName._SoftBodyGetTotalMass) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__soft_body_get_total_mass.NativeValue))
        {
            var callRet = _SoftBodyGetTotalMass(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<float>(callRet);
            return true;
        }
        if ((method == MethodProxyName__soft_body_is_point_pinned || method == MethodName._SoftBodyIsPointPinned) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__soft_body_is_point_pinned.NativeValue))
        {
            var callRet = _SoftBodyIsPointPinned(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<int>(args[1]));
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__soft_body_move_point || method == MethodName._SoftBodyMovePoint) && args.Count == 3 && HasGodotClassMethod((godot_string_name)MethodProxyName__soft_body_move_point.NativeValue))
        {
            _SoftBodyMovePoint(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<int>(args[1]), VariantUtils.ConvertTo<Vector3>(args[2]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__soft_body_pin_point || method == MethodName._SoftBodyPinPoint) && args.Count == 3 && HasGodotClassMethod((godot_string_name)MethodProxyName__soft_body_pin_point.NativeValue))
        {
            _SoftBodyPinPoint(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<int>(args[1]), VariantUtils.ConvertTo<bool>(args[2]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__soft_body_remove_all_pinned_points || method == MethodName._SoftBodyRemoveAllPinnedPoints) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__soft_body_remove_all_pinned_points.NativeValue))
        {
            _SoftBodyRemoveAllPinnedPoints(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__soft_body_remove_collision_exception || method == MethodName._SoftBodyRemoveCollisionException) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__soft_body_remove_collision_exception.NativeValue))
        {
            _SoftBodyRemoveCollisionException(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<Rid>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__soft_body_set_collision_layer || method == MethodName._SoftBodySetCollisionLayer) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__soft_body_set_collision_layer.NativeValue))
        {
            _SoftBodySetCollisionLayer(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<uint>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__soft_body_set_collision_mask || method == MethodName._SoftBodySetCollisionMask) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__soft_body_set_collision_mask.NativeValue))
        {
            _SoftBodySetCollisionMask(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<uint>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__soft_body_set_damping_coefficient || method == MethodName._SoftBodySetDampingCoefficient) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__soft_body_set_damping_coefficient.NativeValue))
        {
            _SoftBodySetDampingCoefficient(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<float>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__soft_body_set_drag_coefficient || method == MethodName._SoftBodySetDragCoefficient) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__soft_body_set_drag_coefficient.NativeValue))
        {
            _SoftBodySetDragCoefficient(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<float>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__soft_body_set_linear_stiffness || method == MethodName._SoftBodySetLinearStiffness) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__soft_body_set_linear_stiffness.NativeValue))
        {
            _SoftBodySetLinearStiffness(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<float>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__soft_body_set_mesh || method == MethodName._SoftBodySetMesh) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__soft_body_set_mesh.NativeValue))
        {
            _SoftBodySetMesh(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<Rid>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__soft_body_set_pressure_coefficient || method == MethodName._SoftBodySetPressureCoefficient) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__soft_body_set_pressure_coefficient.NativeValue))
        {
            _SoftBodySetPressureCoefficient(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<float>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__soft_body_set_ray_pickable || method == MethodName._SoftBodySetRayPickable) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__soft_body_set_ray_pickable.NativeValue))
        {
            _SoftBodySetRayPickable(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<bool>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__soft_body_set_shrinking_factor || method == MethodName._SoftBodySetShrinkingFactor) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__soft_body_set_shrinking_factor.NativeValue))
        {
            _SoftBodySetShrinkingFactor(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<float>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__soft_body_set_simulation_precision || method == MethodName._SoftBodySetSimulationPrecision) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__soft_body_set_simulation_precision.NativeValue))
        {
            _SoftBodySetSimulationPrecision(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<int>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__soft_body_set_space || method == MethodName._SoftBodySetSpace) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__soft_body_set_space.NativeValue))
        {
            _SoftBodySetSpace(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<Rid>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__soft_body_set_state || method == MethodName._SoftBodySetState) && args.Count == 3 && HasGodotClassMethod((godot_string_name)MethodProxyName__soft_body_set_state.NativeValue))
        {
            _SoftBodySetState(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<PhysicsServer3D.BodyState>(args[1]), VariantUtils.ConvertTo<Variant>(args[2]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__soft_body_set_total_mass || method == MethodName._SoftBodySetTotalMass) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__soft_body_set_total_mass.NativeValue))
        {
            _SoftBodySetTotalMass(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<float>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__soft_body_set_transform || method == MethodName._SoftBodySetTransform) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__soft_body_set_transform.NativeValue))
        {
            _SoftBodySetTransform(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<Transform3D>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__soft_body_update_rendering_server || method == MethodName._SoftBodyUpdateRenderingServer) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__soft_body_update_rendering_server.NativeValue))
        {
            _SoftBodyUpdateRenderingServer(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<PhysicsServer3DRenderingServerHandler>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__space_create || method == MethodName._SpaceCreate) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__space_create.NativeValue))
        {
            var callRet = _SpaceCreate();
            ret = VariantUtils.CreateFrom<Rid>(callRet);
            return true;
        }
        if ((method == MethodProxyName__space_get_contact_count || method == MethodName._SpaceGetContactCount) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__space_get_contact_count.NativeValue))
        {
            var callRet = _SpaceGetContactCount(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<int>(callRet);
            return true;
        }
        if ((method == MethodProxyName__space_get_contacts || method == MethodName._SpaceGetContacts) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__space_get_contacts.NativeValue))
        {
            var callRet = _SpaceGetContacts(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<Vector3[]>(callRet);
            return true;
        }
        if ((method == MethodProxyName__space_get_direct_state || method == MethodName._SpaceGetDirectState) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__space_get_direct_state.NativeValue))
        {
            var callRet = _SpaceGetDirectState(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<PhysicsDirectSpaceState3D>(callRet);
            return true;
        }
        if ((method == MethodProxyName__space_get_param || method == MethodName._SpaceGetParam) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__space_get_param.NativeValue))
        {
            var callRet = _SpaceGetParam(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<PhysicsServer3D.SpaceParameter>(args[1]));
            ret = VariantUtils.CreateFrom<float>(callRet);
            return true;
        }
        if ((method == MethodProxyName__space_is_active || method == MethodName._SpaceIsActive) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__space_is_active.NativeValue))
        {
            var callRet = _SpaceIsActive(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__space_set_active || method == MethodName._SpaceSetActive) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__space_set_active.NativeValue))
        {
            _SpaceSetActive(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<bool>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__space_set_debug_contacts || method == MethodName._SpaceSetDebugContacts) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__space_set_debug_contacts.NativeValue))
        {
            _SpaceSetDebugContacts(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<int>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__space_set_param || method == MethodName._SpaceSetParam) && args.Count == 3 && HasGodotClassMethod((godot_string_name)MethodProxyName__space_set_param.NativeValue))
        {
            _SpaceSetParam(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<PhysicsServer3D.SpaceParameter>(args[1]), VariantUtils.ConvertTo<float>(args[2]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__sphere_shape_create || method == MethodName._SphereShapeCreate) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__sphere_shape_create.NativeValue))
        {
            var callRet = _SphereShapeCreate();
            ret = VariantUtils.CreateFrom<Rid>(callRet);
            return true;
        }
        if ((method == MethodProxyName__step || method == MethodName._Step) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__step.NativeValue))
        {
            _Step(VariantUtils.ConvertTo<float>(args[0]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__sync || method == MethodName._Sync) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__sync.NativeValue))
        {
            _Sync();
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__world_boundary_shape_create || method == MethodName._WorldBoundaryShapeCreate) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__world_boundary_shape_create.NativeValue))
        {
            var callRet = _WorldBoundaryShapeCreate();
            ret = VariantUtils.CreateFrom<Rid>(callRet);
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
        if (method == MethodName._AreaAddShape)
        {
            if (HasGodotClassMethod(MethodProxyName__area_add_shape.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._AreaAttachObjectInstanceId)
        {
            if (HasGodotClassMethod(MethodProxyName__area_attach_object_instance_id.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._AreaClearShapes)
        {
            if (HasGodotClassMethod(MethodProxyName__area_clear_shapes.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._AreaCreate)
        {
            if (HasGodotClassMethod(MethodProxyName__area_create.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._AreaGetCollisionLayer)
        {
            if (HasGodotClassMethod(MethodProxyName__area_get_collision_layer.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._AreaGetCollisionMask)
        {
            if (HasGodotClassMethod(MethodProxyName__area_get_collision_mask.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._AreaGetObjectInstanceId)
        {
            if (HasGodotClassMethod(MethodProxyName__area_get_object_instance_id.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._AreaGetParam)
        {
            if (HasGodotClassMethod(MethodProxyName__area_get_param.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._AreaGetShape)
        {
            if (HasGodotClassMethod(MethodProxyName__area_get_shape.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._AreaGetShapeCount)
        {
            if (HasGodotClassMethod(MethodProxyName__area_get_shape_count.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._AreaGetShapeTransform)
        {
            if (HasGodotClassMethod(MethodProxyName__area_get_shape_transform.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._AreaGetSpace)
        {
            if (HasGodotClassMethod(MethodProxyName__area_get_space.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._AreaGetTransform)
        {
            if (HasGodotClassMethod(MethodProxyName__area_get_transform.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._AreaRemoveShape)
        {
            if (HasGodotClassMethod(MethodProxyName__area_remove_shape.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._AreaSetAreaMonitorCallback)
        {
            if (HasGodotClassMethod(MethodProxyName__area_set_area_monitor_callback.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._AreaSetCollisionLayer)
        {
            if (HasGodotClassMethod(MethodProxyName__area_set_collision_layer.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._AreaSetCollisionMask)
        {
            if (HasGodotClassMethod(MethodProxyName__area_set_collision_mask.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._AreaSetMonitorCallback)
        {
            if (HasGodotClassMethod(MethodProxyName__area_set_monitor_callback.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._AreaSetMonitorable)
        {
            if (HasGodotClassMethod(MethodProxyName__area_set_monitorable.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._AreaSetParam)
        {
            if (HasGodotClassMethod(MethodProxyName__area_set_param.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._AreaSetRayPickable)
        {
            if (HasGodotClassMethod(MethodProxyName__area_set_ray_pickable.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._AreaSetShape)
        {
            if (HasGodotClassMethod(MethodProxyName__area_set_shape.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._AreaSetShapeDisabled)
        {
            if (HasGodotClassMethod(MethodProxyName__area_set_shape_disabled.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._AreaSetShapeTransform)
        {
            if (HasGodotClassMethod(MethodProxyName__area_set_shape_transform.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._AreaSetSpace)
        {
            if (HasGodotClassMethod(MethodProxyName__area_set_space.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._AreaSetTransform)
        {
            if (HasGodotClassMethod(MethodProxyName__area_set_transform.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._BodyAddCollisionException)
        {
            if (HasGodotClassMethod(MethodProxyName__body_add_collision_exception.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._BodyAddConstantCentralForce)
        {
            if (HasGodotClassMethod(MethodProxyName__body_add_constant_central_force.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._BodyAddConstantForce)
        {
            if (HasGodotClassMethod(MethodProxyName__body_add_constant_force.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._BodyAddConstantTorque)
        {
            if (HasGodotClassMethod(MethodProxyName__body_add_constant_torque.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._BodyAddShape)
        {
            if (HasGodotClassMethod(MethodProxyName__body_add_shape.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._BodyApplyCentralForce)
        {
            if (HasGodotClassMethod(MethodProxyName__body_apply_central_force.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._BodyApplyCentralImpulse)
        {
            if (HasGodotClassMethod(MethodProxyName__body_apply_central_impulse.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._BodyApplyForce)
        {
            if (HasGodotClassMethod(MethodProxyName__body_apply_force.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._BodyApplyImpulse)
        {
            if (HasGodotClassMethod(MethodProxyName__body_apply_impulse.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._BodyApplyTorque)
        {
            if (HasGodotClassMethod(MethodProxyName__body_apply_torque.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._BodyApplyTorqueImpulse)
        {
            if (HasGodotClassMethod(MethodProxyName__body_apply_torque_impulse.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._BodyAttachObjectInstanceId)
        {
            if (HasGodotClassMethod(MethodProxyName__body_attach_object_instance_id.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._BodyClearShapes)
        {
            if (HasGodotClassMethod(MethodProxyName__body_clear_shapes.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._BodyCreate)
        {
            if (HasGodotClassMethod(MethodProxyName__body_create.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._BodyGetCollisionExceptions)
        {
            if (HasGodotClassMethod(MethodProxyName__body_get_collision_exceptions.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._BodyGetCollisionLayer)
        {
            if (HasGodotClassMethod(MethodProxyName__body_get_collision_layer.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._BodyGetCollisionMask)
        {
            if (HasGodotClassMethod(MethodProxyName__body_get_collision_mask.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._BodyGetCollisionPriority)
        {
            if (HasGodotClassMethod(MethodProxyName__body_get_collision_priority.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._BodyGetConstantForce)
        {
            if (HasGodotClassMethod(MethodProxyName__body_get_constant_force.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._BodyGetConstantTorque)
        {
            if (HasGodotClassMethod(MethodProxyName__body_get_constant_torque.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._BodyGetContactsReportedDepthThreshold)
        {
            if (HasGodotClassMethod(MethodProxyName__body_get_contacts_reported_depth_threshold.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._BodyGetDirectState)
        {
            if (HasGodotClassMethod(MethodProxyName__body_get_direct_state.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._BodyGetMaxContactsReported)
        {
            if (HasGodotClassMethod(MethodProxyName__body_get_max_contacts_reported.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._BodyGetMode)
        {
            if (HasGodotClassMethod(MethodProxyName__body_get_mode.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._BodyGetObjectInstanceId)
        {
            if (HasGodotClassMethod(MethodProxyName__body_get_object_instance_id.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._BodyGetParam)
        {
            if (HasGodotClassMethod(MethodProxyName__body_get_param.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._BodyGetShape)
        {
            if (HasGodotClassMethod(MethodProxyName__body_get_shape.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._BodyGetShapeCount)
        {
            if (HasGodotClassMethod(MethodProxyName__body_get_shape_count.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._BodyGetShapeTransform)
        {
            if (HasGodotClassMethod(MethodProxyName__body_get_shape_transform.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._BodyGetSpace)
        {
            if (HasGodotClassMethod(MethodProxyName__body_get_space.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._BodyGetState)
        {
            if (HasGodotClassMethod(MethodProxyName__body_get_state.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._BodyGetUserFlags)
        {
            if (HasGodotClassMethod(MethodProxyName__body_get_user_flags.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._BodyIsAxisLocked)
        {
            if (HasGodotClassMethod(MethodProxyName__body_is_axis_locked.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._BodyIsContinuousCollisionDetectionEnabled)
        {
            if (HasGodotClassMethod(MethodProxyName__body_is_continuous_collision_detection_enabled.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._BodyIsOmittingForceIntegration)
        {
            if (HasGodotClassMethod(MethodProxyName__body_is_omitting_force_integration.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._BodyRemoveCollisionException)
        {
            if (HasGodotClassMethod(MethodProxyName__body_remove_collision_exception.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._BodyRemoveShape)
        {
            if (HasGodotClassMethod(MethodProxyName__body_remove_shape.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._BodyResetMassProperties)
        {
            if (HasGodotClassMethod(MethodProxyName__body_reset_mass_properties.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._BodySetAxisLock)
        {
            if (HasGodotClassMethod(MethodProxyName__body_set_axis_lock.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._BodySetAxisVelocity)
        {
            if (HasGodotClassMethod(MethodProxyName__body_set_axis_velocity.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._BodySetCollisionLayer)
        {
            if (HasGodotClassMethod(MethodProxyName__body_set_collision_layer.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._BodySetCollisionMask)
        {
            if (HasGodotClassMethod(MethodProxyName__body_set_collision_mask.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._BodySetCollisionPriority)
        {
            if (HasGodotClassMethod(MethodProxyName__body_set_collision_priority.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._BodySetConstantForce)
        {
            if (HasGodotClassMethod(MethodProxyName__body_set_constant_force.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._BodySetConstantTorque)
        {
            if (HasGodotClassMethod(MethodProxyName__body_set_constant_torque.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._BodySetContactsReportedDepthThreshold)
        {
            if (HasGodotClassMethod(MethodProxyName__body_set_contacts_reported_depth_threshold.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._BodySetEnableContinuousCollisionDetection)
        {
            if (HasGodotClassMethod(MethodProxyName__body_set_enable_continuous_collision_detection.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._BodySetForceIntegrationCallback)
        {
            if (HasGodotClassMethod(MethodProxyName__body_set_force_integration_callback.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._BodySetMaxContactsReported)
        {
            if (HasGodotClassMethod(MethodProxyName__body_set_max_contacts_reported.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._BodySetMode)
        {
            if (HasGodotClassMethod(MethodProxyName__body_set_mode.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._BodySetOmitForceIntegration)
        {
            if (HasGodotClassMethod(MethodProxyName__body_set_omit_force_integration.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._BodySetParam)
        {
            if (HasGodotClassMethod(MethodProxyName__body_set_param.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._BodySetRayPickable)
        {
            if (HasGodotClassMethod(MethodProxyName__body_set_ray_pickable.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._BodySetShape)
        {
            if (HasGodotClassMethod(MethodProxyName__body_set_shape.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._BodySetShapeDisabled)
        {
            if (HasGodotClassMethod(MethodProxyName__body_set_shape_disabled.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._BodySetShapeTransform)
        {
            if (HasGodotClassMethod(MethodProxyName__body_set_shape_transform.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._BodySetSpace)
        {
            if (HasGodotClassMethod(MethodProxyName__body_set_space.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._BodySetState)
        {
            if (HasGodotClassMethod(MethodProxyName__body_set_state.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._BodySetStateSyncCallback)
        {
            if (HasGodotClassMethod(MethodProxyName__body_set_state_sync_callback.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._BodySetUserFlags)
        {
            if (HasGodotClassMethod(MethodProxyName__body_set_user_flags.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._BoxShapeCreate)
        {
            if (HasGodotClassMethod(MethodProxyName__box_shape_create.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._CapsuleShapeCreate)
        {
            if (HasGodotClassMethod(MethodProxyName__capsule_shape_create.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ConcavePolygonShapeCreate)
        {
            if (HasGodotClassMethod(MethodProxyName__concave_polygon_shape_create.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ConeTwistJointGetParam)
        {
            if (HasGodotClassMethod(MethodProxyName__cone_twist_joint_get_param.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ConeTwistJointSetParam)
        {
            if (HasGodotClassMethod(MethodProxyName__cone_twist_joint_set_param.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ConvexPolygonShapeCreate)
        {
            if (HasGodotClassMethod(MethodProxyName__convex_polygon_shape_create.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._CustomShapeCreate)
        {
            if (HasGodotClassMethod(MethodProxyName__custom_shape_create.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._CylinderShapeCreate)
        {
            if (HasGodotClassMethod(MethodProxyName__cylinder_shape_create.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._EndSync)
        {
            if (HasGodotClassMethod(MethodProxyName__end_sync.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._Finish)
        {
            if (HasGodotClassMethod(MethodProxyName__finish.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FlushQueries)
        {
            if (HasGodotClassMethod(MethodProxyName__flush_queries.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._FreeRid)
        {
            if (HasGodotClassMethod(MethodProxyName__free_rid.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._Generic6DofJointGetFlag)
        {
            if (HasGodotClassMethod(MethodProxyName__generic_6dof_joint_get_flag.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._Generic6DofJointGetParam)
        {
            if (HasGodotClassMethod(MethodProxyName__generic_6dof_joint_get_param.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._Generic6DofJointSetFlag)
        {
            if (HasGodotClassMethod(MethodProxyName__generic_6dof_joint_set_flag.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._Generic6DofJointSetParam)
        {
            if (HasGodotClassMethod(MethodProxyName__generic_6dof_joint_set_param.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._GetProcessInfo)
        {
            if (HasGodotClassMethod(MethodProxyName__get_process_info.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._HeightmapShapeCreate)
        {
            if (HasGodotClassMethod(MethodProxyName__heightmap_shape_create.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._HingeJointGetFlag)
        {
            if (HasGodotClassMethod(MethodProxyName__hinge_joint_get_flag.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._HingeJointGetParam)
        {
            if (HasGodotClassMethod(MethodProxyName__hinge_joint_get_param.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._HingeJointSetFlag)
        {
            if (HasGodotClassMethod(MethodProxyName__hinge_joint_set_flag.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._HingeJointSetParam)
        {
            if (HasGodotClassMethod(MethodProxyName__hinge_joint_set_param.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._Init)
        {
            if (HasGodotClassMethod(MethodProxyName__init.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._IsFlushingQueries)
        {
            if (HasGodotClassMethod(MethodProxyName__is_flushing_queries.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._JointClear)
        {
            if (HasGodotClassMethod(MethodProxyName__joint_clear.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._JointCreate)
        {
            if (HasGodotClassMethod(MethodProxyName__joint_create.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._JointDisableCollisionsBetweenBodies)
        {
            if (HasGodotClassMethod(MethodProxyName__joint_disable_collisions_between_bodies.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._JointGetSolverPriority)
        {
            if (HasGodotClassMethod(MethodProxyName__joint_get_solver_priority.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._JointGetType)
        {
            if (HasGodotClassMethod(MethodProxyName__joint_get_type.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._JointIsDisabledCollisionsBetweenBodies)
        {
            if (HasGodotClassMethod(MethodProxyName__joint_is_disabled_collisions_between_bodies.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._JointMakeConeTwist)
        {
            if (HasGodotClassMethod(MethodProxyName__joint_make_cone_twist.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._JointMakeGeneric6Dof)
        {
            if (HasGodotClassMethod(MethodProxyName__joint_make_generic_6dof.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._JointMakeHinge)
        {
            if (HasGodotClassMethod(MethodProxyName__joint_make_hinge.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._JointMakeHingeSimple)
        {
            if (HasGodotClassMethod(MethodProxyName__joint_make_hinge_simple.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._JointMakePin)
        {
            if (HasGodotClassMethod(MethodProxyName__joint_make_pin.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._JointMakeSlider)
        {
            if (HasGodotClassMethod(MethodProxyName__joint_make_slider.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._JointSetSolverPriority)
        {
            if (HasGodotClassMethod(MethodProxyName__joint_set_solver_priority.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._PinJointGetLocalA)
        {
            if (HasGodotClassMethod(MethodProxyName__pin_joint_get_local_a.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._PinJointGetLocalB)
        {
            if (HasGodotClassMethod(MethodProxyName__pin_joint_get_local_b.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._PinJointGetParam)
        {
            if (HasGodotClassMethod(MethodProxyName__pin_joint_get_param.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._PinJointSetLocalA)
        {
            if (HasGodotClassMethod(MethodProxyName__pin_joint_set_local_a.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._PinJointSetLocalB)
        {
            if (HasGodotClassMethod(MethodProxyName__pin_joint_set_local_b.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._PinJointSetParam)
        {
            if (HasGodotClassMethod(MethodProxyName__pin_joint_set_param.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._SeparationRayShapeCreate)
        {
            if (HasGodotClassMethod(MethodProxyName__separation_ray_shape_create.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._SetActive)
        {
            if (HasGodotClassMethod(MethodProxyName__set_active.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ShapeGetCustomSolverBias)
        {
            if (HasGodotClassMethod(MethodProxyName__shape_get_custom_solver_bias.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ShapeGetData)
        {
            if (HasGodotClassMethod(MethodProxyName__shape_get_data.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ShapeGetMargin)
        {
            if (HasGodotClassMethod(MethodProxyName__shape_get_margin.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ShapeGetType)
        {
            if (HasGodotClassMethod(MethodProxyName__shape_get_type.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ShapeSetCustomSolverBias)
        {
            if (HasGodotClassMethod(MethodProxyName__shape_set_custom_solver_bias.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ShapeSetData)
        {
            if (HasGodotClassMethod(MethodProxyName__shape_set_data.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._ShapeSetMargin)
        {
            if (HasGodotClassMethod(MethodProxyName__shape_set_margin.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._SliderJointGetParam)
        {
            if (HasGodotClassMethod(MethodProxyName__slider_joint_get_param.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._SliderJointSetParam)
        {
            if (HasGodotClassMethod(MethodProxyName__slider_joint_set_param.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._SoftBodyAddCollisionException)
        {
            if (HasGodotClassMethod(MethodProxyName__soft_body_add_collision_exception.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._SoftBodyApplyCentralForce)
        {
            if (HasGodotClassMethod(MethodProxyName__soft_body_apply_central_force.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._SoftBodyApplyCentralImpulse)
        {
            if (HasGodotClassMethod(MethodProxyName__soft_body_apply_central_impulse.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._SoftBodyApplyPointForce)
        {
            if (HasGodotClassMethod(MethodProxyName__soft_body_apply_point_force.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._SoftBodyApplyPointImpulse)
        {
            if (HasGodotClassMethod(MethodProxyName__soft_body_apply_point_impulse.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._SoftBodyCreate)
        {
            if (HasGodotClassMethod(MethodProxyName__soft_body_create.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._SoftBodyGetBounds)
        {
            if (HasGodotClassMethod(MethodProxyName__soft_body_get_bounds.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._SoftBodyGetCollisionExceptions)
        {
            if (HasGodotClassMethod(MethodProxyName__soft_body_get_collision_exceptions.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._SoftBodyGetCollisionLayer)
        {
            if (HasGodotClassMethod(MethodProxyName__soft_body_get_collision_layer.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._SoftBodyGetCollisionMask)
        {
            if (HasGodotClassMethod(MethodProxyName__soft_body_get_collision_mask.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._SoftBodyGetDampingCoefficient)
        {
            if (HasGodotClassMethod(MethodProxyName__soft_body_get_damping_coefficient.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._SoftBodyGetDragCoefficient)
        {
            if (HasGodotClassMethod(MethodProxyName__soft_body_get_drag_coefficient.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._SoftBodyGetLinearStiffness)
        {
            if (HasGodotClassMethod(MethodProxyName__soft_body_get_linear_stiffness.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._SoftBodyGetPointGlobalPosition)
        {
            if (HasGodotClassMethod(MethodProxyName__soft_body_get_point_global_position.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._SoftBodyGetPressureCoefficient)
        {
            if (HasGodotClassMethod(MethodProxyName__soft_body_get_pressure_coefficient.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._SoftBodyGetShrinkingFactor)
        {
            if (HasGodotClassMethod(MethodProxyName__soft_body_get_shrinking_factor.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._SoftBodyGetSimulationPrecision)
        {
            if (HasGodotClassMethod(MethodProxyName__soft_body_get_simulation_precision.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._SoftBodyGetSpace)
        {
            if (HasGodotClassMethod(MethodProxyName__soft_body_get_space.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._SoftBodyGetState)
        {
            if (HasGodotClassMethod(MethodProxyName__soft_body_get_state.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._SoftBodyGetTotalMass)
        {
            if (HasGodotClassMethod(MethodProxyName__soft_body_get_total_mass.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._SoftBodyIsPointPinned)
        {
            if (HasGodotClassMethod(MethodProxyName__soft_body_is_point_pinned.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._SoftBodyMovePoint)
        {
            if (HasGodotClassMethod(MethodProxyName__soft_body_move_point.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._SoftBodyPinPoint)
        {
            if (HasGodotClassMethod(MethodProxyName__soft_body_pin_point.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._SoftBodyRemoveAllPinnedPoints)
        {
            if (HasGodotClassMethod(MethodProxyName__soft_body_remove_all_pinned_points.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._SoftBodyRemoveCollisionException)
        {
            if (HasGodotClassMethod(MethodProxyName__soft_body_remove_collision_exception.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._SoftBodySetCollisionLayer)
        {
            if (HasGodotClassMethod(MethodProxyName__soft_body_set_collision_layer.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._SoftBodySetCollisionMask)
        {
            if (HasGodotClassMethod(MethodProxyName__soft_body_set_collision_mask.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._SoftBodySetDampingCoefficient)
        {
            if (HasGodotClassMethod(MethodProxyName__soft_body_set_damping_coefficient.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._SoftBodySetDragCoefficient)
        {
            if (HasGodotClassMethod(MethodProxyName__soft_body_set_drag_coefficient.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._SoftBodySetLinearStiffness)
        {
            if (HasGodotClassMethod(MethodProxyName__soft_body_set_linear_stiffness.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._SoftBodySetMesh)
        {
            if (HasGodotClassMethod(MethodProxyName__soft_body_set_mesh.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._SoftBodySetPressureCoefficient)
        {
            if (HasGodotClassMethod(MethodProxyName__soft_body_set_pressure_coefficient.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._SoftBodySetRayPickable)
        {
            if (HasGodotClassMethod(MethodProxyName__soft_body_set_ray_pickable.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._SoftBodySetShrinkingFactor)
        {
            if (HasGodotClassMethod(MethodProxyName__soft_body_set_shrinking_factor.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._SoftBodySetSimulationPrecision)
        {
            if (HasGodotClassMethod(MethodProxyName__soft_body_set_simulation_precision.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._SoftBodySetSpace)
        {
            if (HasGodotClassMethod(MethodProxyName__soft_body_set_space.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._SoftBodySetState)
        {
            if (HasGodotClassMethod(MethodProxyName__soft_body_set_state.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._SoftBodySetTotalMass)
        {
            if (HasGodotClassMethod(MethodProxyName__soft_body_set_total_mass.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._SoftBodySetTransform)
        {
            if (HasGodotClassMethod(MethodProxyName__soft_body_set_transform.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._SoftBodyUpdateRenderingServer)
        {
            if (HasGodotClassMethod(MethodProxyName__soft_body_update_rendering_server.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._SpaceCreate)
        {
            if (HasGodotClassMethod(MethodProxyName__space_create.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._SpaceGetContactCount)
        {
            if (HasGodotClassMethod(MethodProxyName__space_get_contact_count.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._SpaceGetContacts)
        {
            if (HasGodotClassMethod(MethodProxyName__space_get_contacts.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._SpaceGetDirectState)
        {
            if (HasGodotClassMethod(MethodProxyName__space_get_direct_state.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._SpaceGetParam)
        {
            if (HasGodotClassMethod(MethodProxyName__space_get_param.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._SpaceIsActive)
        {
            if (HasGodotClassMethod(MethodProxyName__space_is_active.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._SpaceSetActive)
        {
            if (HasGodotClassMethod(MethodProxyName__space_set_active.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._SpaceSetDebugContacts)
        {
            if (HasGodotClassMethod(MethodProxyName__space_set_debug_contacts.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._SpaceSetParam)
        {
            if (HasGodotClassMethod(MethodProxyName__space_set_param.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._SphereShapeCreate)
        {
            if (HasGodotClassMethod(MethodProxyName__sphere_shape_create.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._Step)
        {
            if (HasGodotClassMethod(MethodProxyName__step.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._Sync)
        {
            if (HasGodotClassMethod(MethodProxyName__sync.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._WorldBoundaryShapeCreate)
        {
            if (HasGodotClassMethod(MethodProxyName__world_boundary_shape_create.NativeValue.DangerousSelfRef))
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
    public new class PropertyName : PhysicsServer3D.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : PhysicsServer3D.MethodName
    {
        /// <summary>
        /// Cached name for the '_area_add_shape' method.
        /// </summary>
        public static readonly StringName _AreaAddShape = "_area_add_shape";
        /// <summary>
        /// Cached name for the '_area_attach_object_instance_id' method.
        /// </summary>
        public static readonly StringName _AreaAttachObjectInstanceId = "_area_attach_object_instance_id";
        /// <summary>
        /// Cached name for the '_area_clear_shapes' method.
        /// </summary>
        public static readonly StringName _AreaClearShapes = "_area_clear_shapes";
        /// <summary>
        /// Cached name for the '_area_create' method.
        /// </summary>
        public static readonly StringName _AreaCreate = "_area_create";
        /// <summary>
        /// Cached name for the '_area_get_collision_layer' method.
        /// </summary>
        public static readonly StringName _AreaGetCollisionLayer = "_area_get_collision_layer";
        /// <summary>
        /// Cached name for the '_area_get_collision_mask' method.
        /// </summary>
        public static readonly StringName _AreaGetCollisionMask = "_area_get_collision_mask";
        /// <summary>
        /// Cached name for the '_area_get_object_instance_id' method.
        /// </summary>
        public static readonly StringName _AreaGetObjectInstanceId = "_area_get_object_instance_id";
        /// <summary>
        /// Cached name for the '_area_get_param' method.
        /// </summary>
        public static readonly StringName _AreaGetParam = "_area_get_param";
        /// <summary>
        /// Cached name for the '_area_get_shape' method.
        /// </summary>
        public static readonly StringName _AreaGetShape = "_area_get_shape";
        /// <summary>
        /// Cached name for the '_area_get_shape_count' method.
        /// </summary>
        public static readonly StringName _AreaGetShapeCount = "_area_get_shape_count";
        /// <summary>
        /// Cached name for the '_area_get_shape_transform' method.
        /// </summary>
        public static readonly StringName _AreaGetShapeTransform = "_area_get_shape_transform";
        /// <summary>
        /// Cached name for the '_area_get_space' method.
        /// </summary>
        public static readonly StringName _AreaGetSpace = "_area_get_space";
        /// <summary>
        /// Cached name for the '_area_get_transform' method.
        /// </summary>
        public static readonly StringName _AreaGetTransform = "_area_get_transform";
        /// <summary>
        /// Cached name for the '_area_remove_shape' method.
        /// </summary>
        public static readonly StringName _AreaRemoveShape = "_area_remove_shape";
        /// <summary>
        /// Cached name for the '_area_set_area_monitor_callback' method.
        /// </summary>
        public static readonly StringName _AreaSetAreaMonitorCallback = "_area_set_area_monitor_callback";
        /// <summary>
        /// Cached name for the '_area_set_collision_layer' method.
        /// </summary>
        public static readonly StringName _AreaSetCollisionLayer = "_area_set_collision_layer";
        /// <summary>
        /// Cached name for the '_area_set_collision_mask' method.
        /// </summary>
        public static readonly StringName _AreaSetCollisionMask = "_area_set_collision_mask";
        /// <summary>
        /// Cached name for the '_area_set_monitor_callback' method.
        /// </summary>
        public static readonly StringName _AreaSetMonitorCallback = "_area_set_monitor_callback";
        /// <summary>
        /// Cached name for the '_area_set_monitorable' method.
        /// </summary>
        public static readonly StringName _AreaSetMonitorable = "_area_set_monitorable";
        /// <summary>
        /// Cached name for the '_area_set_param' method.
        /// </summary>
        public static readonly StringName _AreaSetParam = "_area_set_param";
        /// <summary>
        /// Cached name for the '_area_set_ray_pickable' method.
        /// </summary>
        public static readonly StringName _AreaSetRayPickable = "_area_set_ray_pickable";
        /// <summary>
        /// Cached name for the '_area_set_shape' method.
        /// </summary>
        public static readonly StringName _AreaSetShape = "_area_set_shape";
        /// <summary>
        /// Cached name for the '_area_set_shape_disabled' method.
        /// </summary>
        public static readonly StringName _AreaSetShapeDisabled = "_area_set_shape_disabled";
        /// <summary>
        /// Cached name for the '_area_set_shape_transform' method.
        /// </summary>
        public static readonly StringName _AreaSetShapeTransform = "_area_set_shape_transform";
        /// <summary>
        /// Cached name for the '_area_set_space' method.
        /// </summary>
        public static readonly StringName _AreaSetSpace = "_area_set_space";
        /// <summary>
        /// Cached name for the '_area_set_transform' method.
        /// </summary>
        public static readonly StringName _AreaSetTransform = "_area_set_transform";
        /// <summary>
        /// Cached name for the '_body_add_collision_exception' method.
        /// </summary>
        public static readonly StringName _BodyAddCollisionException = "_body_add_collision_exception";
        /// <summary>
        /// Cached name for the '_body_add_constant_central_force' method.
        /// </summary>
        public static readonly StringName _BodyAddConstantCentralForce = "_body_add_constant_central_force";
        /// <summary>
        /// Cached name for the '_body_add_constant_force' method.
        /// </summary>
        public static readonly StringName _BodyAddConstantForce = "_body_add_constant_force";
        /// <summary>
        /// Cached name for the '_body_add_constant_torque' method.
        /// </summary>
        public static readonly StringName _BodyAddConstantTorque = "_body_add_constant_torque";
        /// <summary>
        /// Cached name for the '_body_add_shape' method.
        /// </summary>
        public static readonly StringName _BodyAddShape = "_body_add_shape";
        /// <summary>
        /// Cached name for the '_body_apply_central_force' method.
        /// </summary>
        public static readonly StringName _BodyApplyCentralForce = "_body_apply_central_force";
        /// <summary>
        /// Cached name for the '_body_apply_central_impulse' method.
        /// </summary>
        public static readonly StringName _BodyApplyCentralImpulse = "_body_apply_central_impulse";
        /// <summary>
        /// Cached name for the '_body_apply_force' method.
        /// </summary>
        public static readonly StringName _BodyApplyForce = "_body_apply_force";
        /// <summary>
        /// Cached name for the '_body_apply_impulse' method.
        /// </summary>
        public static readonly StringName _BodyApplyImpulse = "_body_apply_impulse";
        /// <summary>
        /// Cached name for the '_body_apply_torque' method.
        /// </summary>
        public static readonly StringName _BodyApplyTorque = "_body_apply_torque";
        /// <summary>
        /// Cached name for the '_body_apply_torque_impulse' method.
        /// </summary>
        public static readonly StringName _BodyApplyTorqueImpulse = "_body_apply_torque_impulse";
        /// <summary>
        /// Cached name for the '_body_attach_object_instance_id' method.
        /// </summary>
        public static readonly StringName _BodyAttachObjectInstanceId = "_body_attach_object_instance_id";
        /// <summary>
        /// Cached name for the '_body_clear_shapes' method.
        /// </summary>
        public static readonly StringName _BodyClearShapes = "_body_clear_shapes";
        /// <summary>
        /// Cached name for the '_body_create' method.
        /// </summary>
        public static readonly StringName _BodyCreate = "_body_create";
        /// <summary>
        /// Cached name for the '_body_get_collision_exceptions' method.
        /// </summary>
        public static readonly StringName _BodyGetCollisionExceptions = "_body_get_collision_exceptions";
        /// <summary>
        /// Cached name for the '_body_get_collision_layer' method.
        /// </summary>
        public static readonly StringName _BodyGetCollisionLayer = "_body_get_collision_layer";
        /// <summary>
        /// Cached name for the '_body_get_collision_mask' method.
        /// </summary>
        public static readonly StringName _BodyGetCollisionMask = "_body_get_collision_mask";
        /// <summary>
        /// Cached name for the '_body_get_collision_priority' method.
        /// </summary>
        public static readonly StringName _BodyGetCollisionPriority = "_body_get_collision_priority";
        /// <summary>
        /// Cached name for the '_body_get_constant_force' method.
        /// </summary>
        public static readonly StringName _BodyGetConstantForce = "_body_get_constant_force";
        /// <summary>
        /// Cached name for the '_body_get_constant_torque' method.
        /// </summary>
        public static readonly StringName _BodyGetConstantTorque = "_body_get_constant_torque";
        /// <summary>
        /// Cached name for the '_body_get_contacts_reported_depth_threshold' method.
        /// </summary>
        public static readonly StringName _BodyGetContactsReportedDepthThreshold = "_body_get_contacts_reported_depth_threshold";
        /// <summary>
        /// Cached name for the '_body_get_direct_state' method.
        /// </summary>
        public static readonly StringName _BodyGetDirectState = "_body_get_direct_state";
        /// <summary>
        /// Cached name for the '_body_get_max_contacts_reported' method.
        /// </summary>
        public static readonly StringName _BodyGetMaxContactsReported = "_body_get_max_contacts_reported";
        /// <summary>
        /// Cached name for the '_body_get_mode' method.
        /// </summary>
        public static readonly StringName _BodyGetMode = "_body_get_mode";
        /// <summary>
        /// Cached name for the '_body_get_object_instance_id' method.
        /// </summary>
        public static readonly StringName _BodyGetObjectInstanceId = "_body_get_object_instance_id";
        /// <summary>
        /// Cached name for the '_body_get_param' method.
        /// </summary>
        public static readonly StringName _BodyGetParam = "_body_get_param";
        /// <summary>
        /// Cached name for the '_body_get_shape' method.
        /// </summary>
        public static readonly StringName _BodyGetShape = "_body_get_shape";
        /// <summary>
        /// Cached name for the '_body_get_shape_count' method.
        /// </summary>
        public static readonly StringName _BodyGetShapeCount = "_body_get_shape_count";
        /// <summary>
        /// Cached name for the '_body_get_shape_transform' method.
        /// </summary>
        public static readonly StringName _BodyGetShapeTransform = "_body_get_shape_transform";
        /// <summary>
        /// Cached name for the '_body_get_space' method.
        /// </summary>
        public static readonly StringName _BodyGetSpace = "_body_get_space";
        /// <summary>
        /// Cached name for the '_body_get_state' method.
        /// </summary>
        public static readonly StringName _BodyGetState = "_body_get_state";
        /// <summary>
        /// Cached name for the '_body_get_user_flags' method.
        /// </summary>
        public static readonly StringName _BodyGetUserFlags = "_body_get_user_flags";
        /// <summary>
        /// Cached name for the '_body_is_axis_locked' method.
        /// </summary>
        public static readonly StringName _BodyIsAxisLocked = "_body_is_axis_locked";
        /// <summary>
        /// Cached name for the '_body_is_continuous_collision_detection_enabled' method.
        /// </summary>
        public static readonly StringName _BodyIsContinuousCollisionDetectionEnabled = "_body_is_continuous_collision_detection_enabled";
        /// <summary>
        /// Cached name for the '_body_is_omitting_force_integration' method.
        /// </summary>
        public static readonly StringName _BodyIsOmittingForceIntegration = "_body_is_omitting_force_integration";
        /// <summary>
        /// Cached name for the '_body_remove_collision_exception' method.
        /// </summary>
        public static readonly StringName _BodyRemoveCollisionException = "_body_remove_collision_exception";
        /// <summary>
        /// Cached name for the '_body_remove_shape' method.
        /// </summary>
        public static readonly StringName _BodyRemoveShape = "_body_remove_shape";
        /// <summary>
        /// Cached name for the '_body_reset_mass_properties' method.
        /// </summary>
        public static readonly StringName _BodyResetMassProperties = "_body_reset_mass_properties";
        /// <summary>
        /// Cached name for the '_body_set_axis_lock' method.
        /// </summary>
        public static readonly StringName _BodySetAxisLock = "_body_set_axis_lock";
        /// <summary>
        /// Cached name for the '_body_set_axis_velocity' method.
        /// </summary>
        public static readonly StringName _BodySetAxisVelocity = "_body_set_axis_velocity";
        /// <summary>
        /// Cached name for the '_body_set_collision_layer' method.
        /// </summary>
        public static readonly StringName _BodySetCollisionLayer = "_body_set_collision_layer";
        /// <summary>
        /// Cached name for the '_body_set_collision_mask' method.
        /// </summary>
        public static readonly StringName _BodySetCollisionMask = "_body_set_collision_mask";
        /// <summary>
        /// Cached name for the '_body_set_collision_priority' method.
        /// </summary>
        public static readonly StringName _BodySetCollisionPriority = "_body_set_collision_priority";
        /// <summary>
        /// Cached name for the '_body_set_constant_force' method.
        /// </summary>
        public static readonly StringName _BodySetConstantForce = "_body_set_constant_force";
        /// <summary>
        /// Cached name for the '_body_set_constant_torque' method.
        /// </summary>
        public static readonly StringName _BodySetConstantTorque = "_body_set_constant_torque";
        /// <summary>
        /// Cached name for the '_body_set_contacts_reported_depth_threshold' method.
        /// </summary>
        public static readonly StringName _BodySetContactsReportedDepthThreshold = "_body_set_contacts_reported_depth_threshold";
        /// <summary>
        /// Cached name for the '_body_set_enable_continuous_collision_detection' method.
        /// </summary>
        public static readonly StringName _BodySetEnableContinuousCollisionDetection = "_body_set_enable_continuous_collision_detection";
        /// <summary>
        /// Cached name for the '_body_set_force_integration_callback' method.
        /// </summary>
        public static readonly StringName _BodySetForceIntegrationCallback = "_body_set_force_integration_callback";
        /// <summary>
        /// Cached name for the '_body_set_max_contacts_reported' method.
        /// </summary>
        public static readonly StringName _BodySetMaxContactsReported = "_body_set_max_contacts_reported";
        /// <summary>
        /// Cached name for the '_body_set_mode' method.
        /// </summary>
        public static readonly StringName _BodySetMode = "_body_set_mode";
        /// <summary>
        /// Cached name for the '_body_set_omit_force_integration' method.
        /// </summary>
        public static readonly StringName _BodySetOmitForceIntegration = "_body_set_omit_force_integration";
        /// <summary>
        /// Cached name for the '_body_set_param' method.
        /// </summary>
        public static readonly StringName _BodySetParam = "_body_set_param";
        /// <summary>
        /// Cached name for the '_body_set_ray_pickable' method.
        /// </summary>
        public static readonly StringName _BodySetRayPickable = "_body_set_ray_pickable";
        /// <summary>
        /// Cached name for the '_body_set_shape' method.
        /// </summary>
        public static readonly StringName _BodySetShape = "_body_set_shape";
        /// <summary>
        /// Cached name for the '_body_set_shape_disabled' method.
        /// </summary>
        public static readonly StringName _BodySetShapeDisabled = "_body_set_shape_disabled";
        /// <summary>
        /// Cached name for the '_body_set_shape_transform' method.
        /// </summary>
        public static readonly StringName _BodySetShapeTransform = "_body_set_shape_transform";
        /// <summary>
        /// Cached name for the '_body_set_space' method.
        /// </summary>
        public static readonly StringName _BodySetSpace = "_body_set_space";
        /// <summary>
        /// Cached name for the '_body_set_state' method.
        /// </summary>
        public static readonly StringName _BodySetState = "_body_set_state";
        /// <summary>
        /// Cached name for the '_body_set_state_sync_callback' method.
        /// </summary>
        public static readonly StringName _BodySetStateSyncCallback = "_body_set_state_sync_callback";
        /// <summary>
        /// Cached name for the '_body_set_user_flags' method.
        /// </summary>
        public static readonly StringName _BodySetUserFlags = "_body_set_user_flags";
        /// <summary>
        /// Cached name for the '_box_shape_create' method.
        /// </summary>
        public static readonly StringName _BoxShapeCreate = "_box_shape_create";
        /// <summary>
        /// Cached name for the '_capsule_shape_create' method.
        /// </summary>
        public static readonly StringName _CapsuleShapeCreate = "_capsule_shape_create";
        /// <summary>
        /// Cached name for the '_concave_polygon_shape_create' method.
        /// </summary>
        public static readonly StringName _ConcavePolygonShapeCreate = "_concave_polygon_shape_create";
        /// <summary>
        /// Cached name for the '_cone_twist_joint_get_param' method.
        /// </summary>
        public static readonly StringName _ConeTwistJointGetParam = "_cone_twist_joint_get_param";
        /// <summary>
        /// Cached name for the '_cone_twist_joint_set_param' method.
        /// </summary>
        public static readonly StringName _ConeTwistJointSetParam = "_cone_twist_joint_set_param";
        /// <summary>
        /// Cached name for the '_convex_polygon_shape_create' method.
        /// </summary>
        public static readonly StringName _ConvexPolygonShapeCreate = "_convex_polygon_shape_create";
        /// <summary>
        /// Cached name for the '_custom_shape_create' method.
        /// </summary>
        public static readonly StringName _CustomShapeCreate = "_custom_shape_create";
        /// <summary>
        /// Cached name for the '_cylinder_shape_create' method.
        /// </summary>
        public static readonly StringName _CylinderShapeCreate = "_cylinder_shape_create";
        /// <summary>
        /// Cached name for the '_end_sync' method.
        /// </summary>
        public static readonly StringName _EndSync = "_end_sync";
        /// <summary>
        /// Cached name for the '_finish' method.
        /// </summary>
        public static readonly StringName _Finish = "_finish";
        /// <summary>
        /// Cached name for the '_flush_queries' method.
        /// </summary>
        public static readonly StringName _FlushQueries = "_flush_queries";
        /// <summary>
        /// Cached name for the '_free_rid' method.
        /// </summary>
        public static readonly StringName _FreeRid = "_free_rid";
        /// <summary>
        /// Cached name for the '_generic_6dof_joint_get_flag' method.
        /// </summary>
        public static readonly StringName _Generic6DofJointGetFlag = "_generic_6dof_joint_get_flag";
        /// <summary>
        /// Cached name for the '_generic_6dof_joint_get_param' method.
        /// </summary>
        public static readonly StringName _Generic6DofJointGetParam = "_generic_6dof_joint_get_param";
        /// <summary>
        /// Cached name for the '_generic_6dof_joint_set_flag' method.
        /// </summary>
        public static readonly StringName _Generic6DofJointSetFlag = "_generic_6dof_joint_set_flag";
        /// <summary>
        /// Cached name for the '_generic_6dof_joint_set_param' method.
        /// </summary>
        public static readonly StringName _Generic6DofJointSetParam = "_generic_6dof_joint_set_param";
        /// <summary>
        /// Cached name for the '_get_process_info' method.
        /// </summary>
        public static readonly StringName _GetProcessInfo = "_get_process_info";
        /// <summary>
        /// Cached name for the '_heightmap_shape_create' method.
        /// </summary>
        public static readonly StringName _HeightmapShapeCreate = "_heightmap_shape_create";
        /// <summary>
        /// Cached name for the '_hinge_joint_get_flag' method.
        /// </summary>
        public static readonly StringName _HingeJointGetFlag = "_hinge_joint_get_flag";
        /// <summary>
        /// Cached name for the '_hinge_joint_get_param' method.
        /// </summary>
        public static readonly StringName _HingeJointGetParam = "_hinge_joint_get_param";
        /// <summary>
        /// Cached name for the '_hinge_joint_set_flag' method.
        /// </summary>
        public static readonly StringName _HingeJointSetFlag = "_hinge_joint_set_flag";
        /// <summary>
        /// Cached name for the '_hinge_joint_set_param' method.
        /// </summary>
        public static readonly StringName _HingeJointSetParam = "_hinge_joint_set_param";
        /// <summary>
        /// Cached name for the '_init' method.
        /// </summary>
        public static readonly StringName _Init = "_init";
        /// <summary>
        /// Cached name for the '_is_flushing_queries' method.
        /// </summary>
        public static readonly StringName _IsFlushingQueries = "_is_flushing_queries";
        /// <summary>
        /// Cached name for the '_joint_clear' method.
        /// </summary>
        public static readonly StringName _JointClear = "_joint_clear";
        /// <summary>
        /// Cached name for the '_joint_create' method.
        /// </summary>
        public static readonly StringName _JointCreate = "_joint_create";
        /// <summary>
        /// Cached name for the '_joint_disable_collisions_between_bodies' method.
        /// </summary>
        public static readonly StringName _JointDisableCollisionsBetweenBodies = "_joint_disable_collisions_between_bodies";
        /// <summary>
        /// Cached name for the '_joint_get_solver_priority' method.
        /// </summary>
        public static readonly StringName _JointGetSolverPriority = "_joint_get_solver_priority";
        /// <summary>
        /// Cached name for the '_joint_get_type' method.
        /// </summary>
        public static readonly StringName _JointGetType = "_joint_get_type";
        /// <summary>
        /// Cached name for the '_joint_is_disabled_collisions_between_bodies' method.
        /// </summary>
        public static readonly StringName _JointIsDisabledCollisionsBetweenBodies = "_joint_is_disabled_collisions_between_bodies";
        /// <summary>
        /// Cached name for the '_joint_make_cone_twist' method.
        /// </summary>
        public static readonly StringName _JointMakeConeTwist = "_joint_make_cone_twist";
        /// <summary>
        /// Cached name for the '_joint_make_generic_6dof' method.
        /// </summary>
        public static readonly StringName _JointMakeGeneric6Dof = "_joint_make_generic_6dof";
        /// <summary>
        /// Cached name for the '_joint_make_hinge' method.
        /// </summary>
        public static readonly StringName _JointMakeHinge = "_joint_make_hinge";
        /// <summary>
        /// Cached name for the '_joint_make_hinge_simple' method.
        /// </summary>
        public static readonly StringName _JointMakeHingeSimple = "_joint_make_hinge_simple";
        /// <summary>
        /// Cached name for the '_joint_make_pin' method.
        /// </summary>
        public static readonly StringName _JointMakePin = "_joint_make_pin";
        /// <summary>
        /// Cached name for the '_joint_make_slider' method.
        /// </summary>
        public static readonly StringName _JointMakeSlider = "_joint_make_slider";
        /// <summary>
        /// Cached name for the '_joint_set_solver_priority' method.
        /// </summary>
        public static readonly StringName _JointSetSolverPriority = "_joint_set_solver_priority";
        /// <summary>
        /// Cached name for the '_pin_joint_get_local_a' method.
        /// </summary>
        public static readonly StringName _PinJointGetLocalA = "_pin_joint_get_local_a";
        /// <summary>
        /// Cached name for the '_pin_joint_get_local_b' method.
        /// </summary>
        public static readonly StringName _PinJointGetLocalB = "_pin_joint_get_local_b";
        /// <summary>
        /// Cached name for the '_pin_joint_get_param' method.
        /// </summary>
        public static readonly StringName _PinJointGetParam = "_pin_joint_get_param";
        /// <summary>
        /// Cached name for the '_pin_joint_set_local_a' method.
        /// </summary>
        public static readonly StringName _PinJointSetLocalA = "_pin_joint_set_local_a";
        /// <summary>
        /// Cached name for the '_pin_joint_set_local_b' method.
        /// </summary>
        public static readonly StringName _PinJointSetLocalB = "_pin_joint_set_local_b";
        /// <summary>
        /// Cached name for the '_pin_joint_set_param' method.
        /// </summary>
        public static readonly StringName _PinJointSetParam = "_pin_joint_set_param";
        /// <summary>
        /// Cached name for the '_separation_ray_shape_create' method.
        /// </summary>
        public static readonly StringName _SeparationRayShapeCreate = "_separation_ray_shape_create";
        /// <summary>
        /// Cached name for the '_set_active' method.
        /// </summary>
        public static readonly StringName _SetActive = "_set_active";
        /// <summary>
        /// Cached name for the '_shape_get_custom_solver_bias' method.
        /// </summary>
        public static readonly StringName _ShapeGetCustomSolverBias = "_shape_get_custom_solver_bias";
        /// <summary>
        /// Cached name for the '_shape_get_data' method.
        /// </summary>
        public static readonly StringName _ShapeGetData = "_shape_get_data";
        /// <summary>
        /// Cached name for the '_shape_get_margin' method.
        /// </summary>
        public static readonly StringName _ShapeGetMargin = "_shape_get_margin";
        /// <summary>
        /// Cached name for the '_shape_get_type' method.
        /// </summary>
        public static readonly StringName _ShapeGetType = "_shape_get_type";
        /// <summary>
        /// Cached name for the '_shape_set_custom_solver_bias' method.
        /// </summary>
        public static readonly StringName _ShapeSetCustomSolverBias = "_shape_set_custom_solver_bias";
        /// <summary>
        /// Cached name for the '_shape_set_data' method.
        /// </summary>
        public static readonly StringName _ShapeSetData = "_shape_set_data";
        /// <summary>
        /// Cached name for the '_shape_set_margin' method.
        /// </summary>
        public static readonly StringName _ShapeSetMargin = "_shape_set_margin";
        /// <summary>
        /// Cached name for the '_slider_joint_get_param' method.
        /// </summary>
        public static readonly StringName _SliderJointGetParam = "_slider_joint_get_param";
        /// <summary>
        /// Cached name for the '_slider_joint_set_param' method.
        /// </summary>
        public static readonly StringName _SliderJointSetParam = "_slider_joint_set_param";
        /// <summary>
        /// Cached name for the '_soft_body_add_collision_exception' method.
        /// </summary>
        public static readonly StringName _SoftBodyAddCollisionException = "_soft_body_add_collision_exception";
        /// <summary>
        /// Cached name for the '_soft_body_apply_central_force' method.
        /// </summary>
        public static readonly StringName _SoftBodyApplyCentralForce = "_soft_body_apply_central_force";
        /// <summary>
        /// Cached name for the '_soft_body_apply_central_impulse' method.
        /// </summary>
        public static readonly StringName _SoftBodyApplyCentralImpulse = "_soft_body_apply_central_impulse";
        /// <summary>
        /// Cached name for the '_soft_body_apply_point_force' method.
        /// </summary>
        public static readonly StringName _SoftBodyApplyPointForce = "_soft_body_apply_point_force";
        /// <summary>
        /// Cached name for the '_soft_body_apply_point_impulse' method.
        /// </summary>
        public static readonly StringName _SoftBodyApplyPointImpulse = "_soft_body_apply_point_impulse";
        /// <summary>
        /// Cached name for the '_soft_body_create' method.
        /// </summary>
        public static readonly StringName _SoftBodyCreate = "_soft_body_create";
        /// <summary>
        /// Cached name for the '_soft_body_get_bounds' method.
        /// </summary>
        public static readonly StringName _SoftBodyGetBounds = "_soft_body_get_bounds";
        /// <summary>
        /// Cached name for the '_soft_body_get_collision_exceptions' method.
        /// </summary>
        public static readonly StringName _SoftBodyGetCollisionExceptions = "_soft_body_get_collision_exceptions";
        /// <summary>
        /// Cached name for the '_soft_body_get_collision_layer' method.
        /// </summary>
        public static readonly StringName _SoftBodyGetCollisionLayer = "_soft_body_get_collision_layer";
        /// <summary>
        /// Cached name for the '_soft_body_get_collision_mask' method.
        /// </summary>
        public static readonly StringName _SoftBodyGetCollisionMask = "_soft_body_get_collision_mask";
        /// <summary>
        /// Cached name for the '_soft_body_get_damping_coefficient' method.
        /// </summary>
        public static readonly StringName _SoftBodyGetDampingCoefficient = "_soft_body_get_damping_coefficient";
        /// <summary>
        /// Cached name for the '_soft_body_get_drag_coefficient' method.
        /// </summary>
        public static readonly StringName _SoftBodyGetDragCoefficient = "_soft_body_get_drag_coefficient";
        /// <summary>
        /// Cached name for the '_soft_body_get_linear_stiffness' method.
        /// </summary>
        public static readonly StringName _SoftBodyGetLinearStiffness = "_soft_body_get_linear_stiffness";
        /// <summary>
        /// Cached name for the '_soft_body_get_point_global_position' method.
        /// </summary>
        public static readonly StringName _SoftBodyGetPointGlobalPosition = "_soft_body_get_point_global_position";
        /// <summary>
        /// Cached name for the '_soft_body_get_pressure_coefficient' method.
        /// </summary>
        public static readonly StringName _SoftBodyGetPressureCoefficient = "_soft_body_get_pressure_coefficient";
        /// <summary>
        /// Cached name for the '_soft_body_get_shrinking_factor' method.
        /// </summary>
        public static readonly StringName _SoftBodyGetShrinkingFactor = "_soft_body_get_shrinking_factor";
        /// <summary>
        /// Cached name for the '_soft_body_get_simulation_precision' method.
        /// </summary>
        public static readonly StringName _SoftBodyGetSimulationPrecision = "_soft_body_get_simulation_precision";
        /// <summary>
        /// Cached name for the '_soft_body_get_space' method.
        /// </summary>
        public static readonly StringName _SoftBodyGetSpace = "_soft_body_get_space";
        /// <summary>
        /// Cached name for the '_soft_body_get_state' method.
        /// </summary>
        public static readonly StringName _SoftBodyGetState = "_soft_body_get_state";
        /// <summary>
        /// Cached name for the '_soft_body_get_total_mass' method.
        /// </summary>
        public static readonly StringName _SoftBodyGetTotalMass = "_soft_body_get_total_mass";
        /// <summary>
        /// Cached name for the '_soft_body_is_point_pinned' method.
        /// </summary>
        public static readonly StringName _SoftBodyIsPointPinned = "_soft_body_is_point_pinned";
        /// <summary>
        /// Cached name for the '_soft_body_move_point' method.
        /// </summary>
        public static readonly StringName _SoftBodyMovePoint = "_soft_body_move_point";
        /// <summary>
        /// Cached name for the '_soft_body_pin_point' method.
        /// </summary>
        public static readonly StringName _SoftBodyPinPoint = "_soft_body_pin_point";
        /// <summary>
        /// Cached name for the '_soft_body_remove_all_pinned_points' method.
        /// </summary>
        public static readonly StringName _SoftBodyRemoveAllPinnedPoints = "_soft_body_remove_all_pinned_points";
        /// <summary>
        /// Cached name for the '_soft_body_remove_collision_exception' method.
        /// </summary>
        public static readonly StringName _SoftBodyRemoveCollisionException = "_soft_body_remove_collision_exception";
        /// <summary>
        /// Cached name for the '_soft_body_set_collision_layer' method.
        /// </summary>
        public static readonly StringName _SoftBodySetCollisionLayer = "_soft_body_set_collision_layer";
        /// <summary>
        /// Cached name for the '_soft_body_set_collision_mask' method.
        /// </summary>
        public static readonly StringName _SoftBodySetCollisionMask = "_soft_body_set_collision_mask";
        /// <summary>
        /// Cached name for the '_soft_body_set_damping_coefficient' method.
        /// </summary>
        public static readonly StringName _SoftBodySetDampingCoefficient = "_soft_body_set_damping_coefficient";
        /// <summary>
        /// Cached name for the '_soft_body_set_drag_coefficient' method.
        /// </summary>
        public static readonly StringName _SoftBodySetDragCoefficient = "_soft_body_set_drag_coefficient";
        /// <summary>
        /// Cached name for the '_soft_body_set_linear_stiffness' method.
        /// </summary>
        public static readonly StringName _SoftBodySetLinearStiffness = "_soft_body_set_linear_stiffness";
        /// <summary>
        /// Cached name for the '_soft_body_set_mesh' method.
        /// </summary>
        public static readonly StringName _SoftBodySetMesh = "_soft_body_set_mesh";
        /// <summary>
        /// Cached name for the '_soft_body_set_pressure_coefficient' method.
        /// </summary>
        public static readonly StringName _SoftBodySetPressureCoefficient = "_soft_body_set_pressure_coefficient";
        /// <summary>
        /// Cached name for the '_soft_body_set_ray_pickable' method.
        /// </summary>
        public static readonly StringName _SoftBodySetRayPickable = "_soft_body_set_ray_pickable";
        /// <summary>
        /// Cached name for the '_soft_body_set_shrinking_factor' method.
        /// </summary>
        public static readonly StringName _SoftBodySetShrinkingFactor = "_soft_body_set_shrinking_factor";
        /// <summary>
        /// Cached name for the '_soft_body_set_simulation_precision' method.
        /// </summary>
        public static readonly StringName _SoftBodySetSimulationPrecision = "_soft_body_set_simulation_precision";
        /// <summary>
        /// Cached name for the '_soft_body_set_space' method.
        /// </summary>
        public static readonly StringName _SoftBodySetSpace = "_soft_body_set_space";
        /// <summary>
        /// Cached name for the '_soft_body_set_state' method.
        /// </summary>
        public static readonly StringName _SoftBodySetState = "_soft_body_set_state";
        /// <summary>
        /// Cached name for the '_soft_body_set_total_mass' method.
        /// </summary>
        public static readonly StringName _SoftBodySetTotalMass = "_soft_body_set_total_mass";
        /// <summary>
        /// Cached name for the '_soft_body_set_transform' method.
        /// </summary>
        public static readonly StringName _SoftBodySetTransform = "_soft_body_set_transform";
        /// <summary>
        /// Cached name for the '_soft_body_update_rendering_server' method.
        /// </summary>
        public static readonly StringName _SoftBodyUpdateRenderingServer = "_soft_body_update_rendering_server";
        /// <summary>
        /// Cached name for the '_space_create' method.
        /// </summary>
        public static readonly StringName _SpaceCreate = "_space_create";
        /// <summary>
        /// Cached name for the '_space_get_contact_count' method.
        /// </summary>
        public static readonly StringName _SpaceGetContactCount = "_space_get_contact_count";
        /// <summary>
        /// Cached name for the '_space_get_contacts' method.
        /// </summary>
        public static readonly StringName _SpaceGetContacts = "_space_get_contacts";
        /// <summary>
        /// Cached name for the '_space_get_direct_state' method.
        /// </summary>
        public static readonly StringName _SpaceGetDirectState = "_space_get_direct_state";
        /// <summary>
        /// Cached name for the '_space_get_param' method.
        /// </summary>
        public static readonly StringName _SpaceGetParam = "_space_get_param";
        /// <summary>
        /// Cached name for the '_space_is_active' method.
        /// </summary>
        public static readonly StringName _SpaceIsActive = "_space_is_active";
        /// <summary>
        /// Cached name for the '_space_set_active' method.
        /// </summary>
        public static readonly StringName _SpaceSetActive = "_space_set_active";
        /// <summary>
        /// Cached name for the '_space_set_debug_contacts' method.
        /// </summary>
        public static readonly StringName _SpaceSetDebugContacts = "_space_set_debug_contacts";
        /// <summary>
        /// Cached name for the '_space_set_param' method.
        /// </summary>
        public static readonly StringName _SpaceSetParam = "_space_set_param";
        /// <summary>
        /// Cached name for the '_sphere_shape_create' method.
        /// </summary>
        public static readonly StringName _SphereShapeCreate = "_sphere_shape_create";
        /// <summary>
        /// Cached name for the '_step' method.
        /// </summary>
        public static readonly StringName _Step = "_step";
        /// <summary>
        /// Cached name for the '_sync' method.
        /// </summary>
        public static readonly StringName _Sync = "_sync";
        /// <summary>
        /// Cached name for the '_world_boundary_shape_create' method.
        /// </summary>
        public static readonly StringName _WorldBoundaryShapeCreate = "_world_boundary_shape_create";
        /// <summary>
        /// Cached name for the 'body_test_motion_is_excluding_body' method.
        /// </summary>
        public static readonly StringName BodyTestMotionIsExcludingBody = "body_test_motion_is_excluding_body";
        /// <summary>
        /// Cached name for the 'body_test_motion_is_excluding_object' method.
        /// </summary>
        public static readonly StringName BodyTestMotionIsExcludingObject = "body_test_motion_is_excluding_object";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : PhysicsServer3D.SignalName
    {
    }
}
