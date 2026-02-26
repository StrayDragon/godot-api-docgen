namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This class extends <see cref="Godot.PhysicsServer2D"/> by providing additional virtual methods that can be overridden. When these methods are overridden, they will be called instead of the internal methods of the physics server.</para>
/// <para>Intended for use with GDExtension to create custom implementations of <see cref="Godot.PhysicsServer2D"/>.</para>
/// </summary>
public partial class PhysicsServer2DExtension : PhysicsServer2DInstance
{
    private static readonly System.Type CachedType = typeof(PhysicsServer2DExtension);

    private static readonly StringName NativeName = "PhysicsServer2DExtension";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public PhysicsServer2DExtension() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal PhysicsServer2DExtension(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal PhysicsServer2DExtension(bool memoryOwn) : base(memoryOwn) { }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.AreaAddShape(Rid, Rid, Nullable{Transform2D}, bool)"/>.</para>
    /// </summary>
    public virtual unsafe void _AreaAddShape(Rid area, Rid shape, Transform2D transform, bool disabled)
    {
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.AreaAttachCanvasInstanceId(Rid, ulong)"/>.</para>
    /// </summary>
    public virtual void _AreaAttachCanvasInstanceId(Rid area, ulong id)
    {
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.AreaAttachObjectInstanceId(Rid, ulong)"/>.</para>
    /// </summary>
    public virtual void _AreaAttachObjectInstanceId(Rid area, ulong id)
    {
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.AreaClearShapes(Rid)"/>.</para>
    /// </summary>
    public virtual void _AreaClearShapes(Rid area)
    {
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.AreaCreate()"/>.</para>
    /// </summary>
    public virtual Rid _AreaCreate()
    {
        return default;
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.AreaGetCanvasInstanceId(Rid)"/>.</para>
    /// </summary>
    public virtual ulong _AreaGetCanvasInstanceId(Rid area)
    {
        return default;
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.AreaGetCollisionLayer(Rid)"/>.</para>
    /// </summary>
    public virtual uint _AreaGetCollisionLayer(Rid area)
    {
        return default;
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.AreaGetCollisionMask(Rid)"/>.</para>
    /// </summary>
    public virtual uint _AreaGetCollisionMask(Rid area)
    {
        return default;
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.AreaGetObjectInstanceId(Rid)"/>.</para>
    /// </summary>
    public virtual ulong _AreaGetObjectInstanceId(Rid area)
    {
        return default;
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.AreaGetParam(Rid, PhysicsServer2D.AreaParameter)"/>.</para>
    /// </summary>
    public virtual Variant _AreaGetParam(Rid area, PhysicsServer2D.AreaParameter param)
    {
        return default;
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.AreaGetShape(Rid, int)"/>.</para>
    /// </summary>
    public virtual Rid _AreaGetShape(Rid area, int shapeIdx)
    {
        return default;
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.AreaGetShapeCount(Rid)"/>.</para>
    /// </summary>
    public virtual int _AreaGetShapeCount(Rid area)
    {
        return default;
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.AreaGetShapeTransform(Rid, int)"/>.</para>
    /// </summary>
    public virtual Transform2D _AreaGetShapeTransform(Rid area, int shapeIdx)
    {
        return default;
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.AreaGetSpace(Rid)"/>.</para>
    /// </summary>
    public virtual Rid _AreaGetSpace(Rid area)
    {
        return default;
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.AreaGetTransform(Rid)"/>.</para>
    /// </summary>
    public virtual Transform2D _AreaGetTransform(Rid area)
    {
        return default;
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.AreaRemoveShape(Rid, int)"/>.</para>
    /// </summary>
    public virtual void _AreaRemoveShape(Rid area, int shapeIdx)
    {
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.AreaSetAreaMonitorCallback(Rid, Callable)"/>.</para>
    /// </summary>
    public virtual void _AreaSetAreaMonitorCallback(Rid area, Callable callback)
    {
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.AreaSetCollisionLayer(Rid, uint)"/>.</para>
    /// </summary>
    public virtual void _AreaSetCollisionLayer(Rid area, uint layer)
    {
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.AreaSetCollisionMask(Rid, uint)"/>.</para>
    /// </summary>
    public virtual void _AreaSetCollisionMask(Rid area, uint mask)
    {
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.AreaSetMonitorCallback(Rid, Callable)"/>.</para>
    /// </summary>
    public virtual void _AreaSetMonitorCallback(Rid area, Callable callback)
    {
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.AreaSetMonitorable(Rid, bool)"/>.</para>
    /// </summary>
    public virtual void _AreaSetMonitorable(Rid area, bool monitorable)
    {
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.AreaSetParam(Rid, PhysicsServer2D.AreaParameter, Variant)"/>.</para>
    /// </summary>
    public virtual void _AreaSetParam(Rid area, PhysicsServer2D.AreaParameter param, Variant value)
    {
    }

    /// <summary>
    /// <para>If set to <see langword="true"/>, allows the area with the given <see cref="Godot.Rid"/> to detect mouse inputs when the mouse cursor is hovering on it.</para>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D"/>'s internal <c>area_set_pickable</c> method. Corresponds to <see cref="Godot.CollisionObject2D.InputPickable"/>.</para>
    /// </summary>
    public virtual void _AreaSetPickable(Rid area, bool pickable)
    {
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.AreaSetShape(Rid, int, Rid)"/>.</para>
    /// </summary>
    public virtual void _AreaSetShape(Rid area, int shapeIdx, Rid shape)
    {
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.AreaSetShapeDisabled(Rid, int, bool)"/>.</para>
    /// </summary>
    public virtual void _AreaSetShapeDisabled(Rid area, int shapeIdx, bool disabled)
    {
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.AreaSetShapeTransform(Rid, int, Transform2D)"/>.</para>
    /// </summary>
    public virtual unsafe void _AreaSetShapeTransform(Rid area, int shapeIdx, Transform2D transform)
    {
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.AreaSetSpace(Rid, Rid)"/>.</para>
    /// </summary>
    public virtual void _AreaSetSpace(Rid area, Rid space)
    {
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.AreaSetTransform(Rid, Transform2D)"/>.</para>
    /// </summary>
    public virtual unsafe void _AreaSetTransform(Rid area, Transform2D transform)
    {
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.BodyAddCollisionException(Rid, Rid)"/>.</para>
    /// </summary>
    public virtual void _BodyAddCollisionException(Rid body, Rid exceptedBody)
    {
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.BodyAddConstantCentralForce(Rid, Vector2)"/>.</para>
    /// </summary>
    public virtual unsafe void _BodyAddConstantCentralForce(Rid body, Vector2 force)
    {
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.BodyAddConstantForce(Rid, Vector2, Nullable{Vector2})"/>.</para>
    /// </summary>
    public virtual unsafe void _BodyAddConstantForce(Rid body, Vector2 force, Vector2 position)
    {
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.BodyAddConstantTorque(Rid, float)"/>.</para>
    /// </summary>
    public virtual void _BodyAddConstantTorque(Rid body, float torque)
    {
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.BodyAddShape(Rid, Rid, Nullable{Transform2D}, bool)"/>.</para>
    /// </summary>
    public virtual unsafe void _BodyAddShape(Rid body, Rid shape, Transform2D transform, bool disabled)
    {
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.BodyApplyCentralForce(Rid, Vector2)"/>.</para>
    /// </summary>
    public virtual unsafe void _BodyApplyCentralForce(Rid body, Vector2 force)
    {
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.BodyApplyCentralImpulse(Rid, Vector2)"/>.</para>
    /// </summary>
    public virtual unsafe void _BodyApplyCentralImpulse(Rid body, Vector2 impulse)
    {
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.BodyApplyForce(Rid, Vector2, Nullable{Vector2})"/>.</para>
    /// </summary>
    public virtual unsafe void _BodyApplyForce(Rid body, Vector2 force, Vector2 position)
    {
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.BodyApplyImpulse(Rid, Vector2, Nullable{Vector2})"/>.</para>
    /// </summary>
    public virtual unsafe void _BodyApplyImpulse(Rid body, Vector2 impulse, Vector2 position)
    {
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.BodyApplyTorque(Rid, float)"/>.</para>
    /// </summary>
    public virtual void _BodyApplyTorque(Rid body, float torque)
    {
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.BodyApplyTorqueImpulse(Rid, float)"/>.</para>
    /// </summary>
    public virtual void _BodyApplyTorqueImpulse(Rid body, float impulse)
    {
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.BodyAttachCanvasInstanceId(Rid, ulong)"/>.</para>
    /// </summary>
    public virtual void _BodyAttachCanvasInstanceId(Rid body, ulong id)
    {
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.BodyAttachObjectInstanceId(Rid, ulong)"/>.</para>
    /// </summary>
    public virtual void _BodyAttachObjectInstanceId(Rid body, ulong id)
    {
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.BodyClearShapes(Rid)"/>.</para>
    /// </summary>
    public virtual void _BodyClearShapes(Rid body)
    {
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.BodyCreate()"/>.</para>
    /// </summary>
    public virtual Rid _BodyCreate()
    {
        return default;
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.BodyGetCanvasInstanceId(Rid)"/>.</para>
    /// </summary>
    public virtual ulong _BodyGetCanvasInstanceId(Rid body)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns the <see cref="Godot.Rid"/>s of all bodies added as collision exceptions for the given <paramref name="body"/>. See also <see cref="Godot.PhysicsServer2DExtension._BodyAddCollisionException(Rid, Rid)"/> and <see cref="Godot.PhysicsServer2DExtension._BodyRemoveCollisionException(Rid, Rid)"/>.</para>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D"/>'s internal <c>body_get_collision_exceptions</c> method. Corresponds to <see cref="Godot.PhysicsBody2D.GetCollisionExceptions()"/>.</para>
    /// </summary>
    public virtual Godot.Collections.Array<Rid> _BodyGetCollisionExceptions(Rid body)
    {
        return default;
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.BodyGetCollisionLayer(Rid)"/>.</para>
    /// </summary>
    public virtual uint _BodyGetCollisionLayer(Rid body)
    {
        return default;
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.BodyGetCollisionMask(Rid)"/>.</para>
    /// </summary>
    public virtual uint _BodyGetCollisionMask(Rid body)
    {
        return default;
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.BodyGetCollisionPriority(Rid)"/>.</para>
    /// </summary>
    public virtual float _BodyGetCollisionPriority(Rid body)
    {
        return default;
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.BodyGetConstantForce(Rid)"/>.</para>
    /// </summary>
    public virtual Vector2 _BodyGetConstantForce(Rid body)
    {
        return default;
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.BodyGetConstantTorque(Rid)"/>.</para>
    /// </summary>
    public virtual float _BodyGetConstantTorque(Rid body)
    {
        return default;
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D"/>'s internal <c>body_get_contacts_reported_depth_threshold</c> method.</para>
    /// <para><b>Note:</b> This method is currently unused by Godot's default physics implementation.</para>
    /// </summary>
    public virtual float _BodyGetContactsReportedDepthThreshold(Rid body)
    {
        return default;
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.BodyGetContinuousCollisionDetectionMode(Rid)"/>.</para>
    /// </summary>
    public virtual PhysicsServer2D.CcdMode _BodyGetContinuousCollisionDetectionMode(Rid body)
    {
        return default;
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.BodyGetDirectState(Rid)"/>.</para>
    /// </summary>
    public virtual PhysicsDirectBodyState2D _BodyGetDirectState(Rid body)
    {
        return default;
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.BodyGetMaxContactsReported(Rid)"/>.</para>
    /// </summary>
    public virtual int _BodyGetMaxContactsReported(Rid body)
    {
        return default;
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.BodyGetMode(Rid)"/>.</para>
    /// </summary>
    public virtual PhysicsServer2D.BodyMode _BodyGetMode(Rid body)
    {
        return default;
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.BodyGetObjectInstanceId(Rid)"/>.</para>
    /// </summary>
    public virtual ulong _BodyGetObjectInstanceId(Rid body)
    {
        return default;
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.BodyGetParam(Rid, PhysicsServer2D.BodyParameter)"/>.</para>
    /// </summary>
    public virtual Variant _BodyGetParam(Rid body, PhysicsServer2D.BodyParameter param)
    {
        return default;
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.BodyGetShape(Rid, int)"/>.</para>
    /// </summary>
    public virtual Rid _BodyGetShape(Rid body, int shapeIdx)
    {
        return default;
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.BodyGetShapeCount(Rid)"/>.</para>
    /// </summary>
    public virtual int _BodyGetShapeCount(Rid body)
    {
        return default;
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.BodyGetShapeTransform(Rid, int)"/>.</para>
    /// </summary>
    public virtual Transform2D _BodyGetShapeTransform(Rid body, int shapeIdx)
    {
        return default;
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.BodyGetSpace(Rid)"/>.</para>
    /// </summary>
    public virtual Rid _BodyGetSpace(Rid body)
    {
        return default;
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.BodyGetState(Rid, PhysicsServer2D.BodyState)"/>.</para>
    /// </summary>
    public virtual Variant _BodyGetState(Rid body, PhysicsServer2D.BodyState state)
    {
        return default;
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.BodyIsOmittingForceIntegration(Rid)"/>.</para>
    /// </summary>
    public virtual bool _BodyIsOmittingForceIntegration(Rid body)
    {
        return default;
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.BodyRemoveCollisionException(Rid, Rid)"/>.</para>
    /// </summary>
    public virtual void _BodyRemoveCollisionException(Rid body, Rid exceptedBody)
    {
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.BodyRemoveShape(Rid, int)"/>.</para>
    /// </summary>
    public virtual void _BodyRemoveShape(Rid body, int shapeIdx)
    {
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.BodyResetMassProperties(Rid)"/>.</para>
    /// </summary>
    public virtual void _BodyResetMassProperties(Rid body)
    {
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.BodySetAxisVelocity(Rid, Vector2)"/>.</para>
    /// </summary>
    public virtual unsafe void _BodySetAxisVelocity(Rid body, Vector2 axisVelocity)
    {
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.BodySetCollisionLayer(Rid, uint)"/>.</para>
    /// </summary>
    public virtual void _BodySetCollisionLayer(Rid body, uint layer)
    {
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.BodySetCollisionMask(Rid, uint)"/>.</para>
    /// </summary>
    public virtual void _BodySetCollisionMask(Rid body, uint mask)
    {
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.BodySetCollisionPriority(Rid, float)"/>.</para>
    /// </summary>
    public virtual void _BodySetCollisionPriority(Rid body, float priority)
    {
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.BodySetConstantForce(Rid, Vector2)"/>.</para>
    /// </summary>
    public virtual unsafe void _BodySetConstantForce(Rid body, Vector2 force)
    {
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.BodySetConstantTorque(Rid, float)"/>.</para>
    /// </summary>
    public virtual void _BodySetConstantTorque(Rid body, float torque)
    {
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D"/>'s internal <c>body_set_contacts_reported_depth_threshold</c> method.</para>
    /// <para><b>Note:</b> This method is currently unused by Godot's default physics implementation.</para>
    /// </summary>
    public virtual void _BodySetContactsReportedDepthThreshold(Rid body, float threshold)
    {
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.BodySetContinuousCollisionDetectionMode(Rid, PhysicsServer2D.CcdMode)"/>.</para>
    /// </summary>
    public virtual void _BodySetContinuousCollisionDetectionMode(Rid body, PhysicsServer2D.CcdMode mode)
    {
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.BodySetForceIntegrationCallback(Rid, Callable, Variant)"/>.</para>
    /// </summary>
    public virtual void _BodySetForceIntegrationCallback(Rid body, Callable callable, Variant userdata)
    {
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.BodySetMaxContactsReported(Rid, int)"/>.</para>
    /// </summary>
    public virtual void _BodySetMaxContactsReported(Rid body, int amount)
    {
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.BodySetMode(Rid, PhysicsServer2D.BodyMode)"/>.</para>
    /// </summary>
    public virtual void _BodySetMode(Rid body, PhysicsServer2D.BodyMode mode)
    {
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.BodySetOmitForceIntegration(Rid, bool)"/>.</para>
    /// </summary>
    public virtual void _BodySetOmitForceIntegration(Rid body, bool enable)
    {
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.BodySetParam(Rid, PhysicsServer2D.BodyParameter, Variant)"/>.</para>
    /// </summary>
    public virtual void _BodySetParam(Rid body, PhysicsServer2D.BodyParameter param, Variant value)
    {
    }

    /// <summary>
    /// <para>If set to <see langword="true"/>, allows the body with the given <see cref="Godot.Rid"/> to detect mouse inputs when the mouse cursor is hovering on it.</para>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D"/>'s internal <c>body_set_pickable</c> method. Corresponds to <see cref="Godot.CollisionObject2D.InputPickable"/>.</para>
    /// </summary>
    public virtual void _BodySetPickable(Rid body, bool pickable)
    {
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.BodySetShape(Rid, int, Rid)"/>.</para>
    /// </summary>
    public virtual void _BodySetShape(Rid body, int shapeIdx, Rid shape)
    {
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.BodySetShapeAsOneWayCollision(Rid, int, bool, float)"/>.</para>
    /// </summary>
    public virtual void _BodySetShapeAsOneWayCollision(Rid body, int shapeIdx, bool enable, float margin)
    {
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.BodySetShapeDisabled(Rid, int, bool)"/>.</para>
    /// </summary>
    public virtual void _BodySetShapeDisabled(Rid body, int shapeIdx, bool disabled)
    {
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.BodySetShapeTransform(Rid, int, Transform2D)"/>.</para>
    /// </summary>
    public virtual unsafe void _BodySetShapeTransform(Rid body, int shapeIdx, Transform2D transform)
    {
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.BodySetSpace(Rid, Rid)"/>.</para>
    /// </summary>
    public virtual void _BodySetSpace(Rid body, Rid space)
    {
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.BodySetState(Rid, PhysicsServer2D.BodyState, Variant)"/>.</para>
    /// </summary>
    public virtual void _BodySetState(Rid body, PhysicsServer2D.BodyState state, Variant value)
    {
    }

    /// <summary>
    /// <para>Assigns the <paramref name="body"/> to call the given <paramref name="callable"/> during the synchronization phase of the loop, before <see cref="Godot.PhysicsServer2DExtension._Step(float)"/> is called. See also <see cref="Godot.PhysicsServer2DExtension._Sync()"/>.</para>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.BodySetStateSyncCallback(Rid, Callable)"/>.</para>
    /// </summary>
    public virtual void _BodySetStateSyncCallback(Rid body, Callable callable)
    {
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.CapsuleShapeCreate()"/>.</para>
    /// </summary>
    public virtual Rid _CapsuleShapeCreate()
    {
        return default;
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.CircleShapeCreate()"/>.</para>
    /// </summary>
    public virtual Rid _CircleShapeCreate()
    {
        return default;
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.ConcavePolygonShapeCreate()"/>.</para>
    /// </summary>
    public virtual Rid _ConcavePolygonShapeCreate()
    {
        return default;
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.ConvexPolygonShapeCreate()"/>.</para>
    /// </summary>
    public virtual Rid _ConvexPolygonShapeCreate()
    {
        return default;
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.DampedSpringJointGetParam(Rid, PhysicsServer2D.DampedSpringParam)"/>.</para>
    /// </summary>
    public virtual float _DampedSpringJointGetParam(Rid joint, PhysicsServer2D.DampedSpringParam param)
    {
        return default;
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.DampedSpringJointSetParam(Rid, PhysicsServer2D.DampedSpringParam, float)"/>.</para>
    /// </summary>
    public virtual void _DampedSpringJointSetParam(Rid joint, PhysicsServer2D.DampedSpringParam param, float value)
    {
    }

    /// <summary>
    /// <para>Called to indicate that the physics server has stopped synchronizing. It is in the loop's iteration/physics phase, and can access physics objects even if running on a separate thread. See also <see cref="Godot.PhysicsServer2DExtension._Sync()"/>.</para>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D"/>'s internal <c>end_sync</c> method.</para>
    /// </summary>
    public virtual void _EndSync()
    {
    }

    /// <summary>
    /// <para>Called when the main loop finalizes to shut down the physics server. See also <see cref="Godot.MainLoop._Finalize()"/> and <see cref="Godot.PhysicsServer2DExtension.PhysicsServer2DExtension()"/>.</para>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D"/>'s internal <c>finish</c> method.</para>
    /// </summary>
    public virtual void _Finish()
    {
    }

    /// <summary>
    /// <para>Called every physics step before <see cref="Godot.PhysicsServer2DExtension._Step(float)"/> to process all remaining queries.</para>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D"/>'s internal <c>flush_queries</c> method.</para>
    /// </summary>
    public virtual void _FlushQueries()
    {
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.FreeRid(Rid)"/>.</para>
    /// </summary>
    public virtual void _FreeRid(Rid rid)
    {
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.GetProcessInfo(PhysicsServer2D.ProcessInfo)"/>.</para>
    /// </summary>
    public virtual int _GetProcessInfo(PhysicsServer2D.ProcessInfo processInfo)
    {
        return default;
    }

    /// <summary>
    /// <para>Called when the main loop is initialized and creates a new instance of this physics server. See also <see cref="Godot.MainLoop._Initialize()"/> and <see cref="Godot.PhysicsServer2DExtension._Finish()"/>.</para>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D"/>'s internal <c>init</c> method.</para>
    /// </summary>
    public virtual void _Init()
    {
    }

    /// <summary>
    /// <para>Overridable method that should return <see langword="true"/> when the physics server is processing queries. See also <see cref="Godot.PhysicsServer2DExtension._FlushQueries()"/>.</para>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D"/>'s internal <c>is_flushing_queries</c> method.</para>
    /// </summary>
    public virtual bool _IsFlushingQueries()
    {
        return default;
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.JointClear(Rid)"/>.</para>
    /// </summary>
    public virtual void _JointClear(Rid joint)
    {
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.JointCreate()"/>.</para>
    /// </summary>
    public virtual Rid _JointCreate()
    {
        return default;
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.JointDisableCollisionsBetweenBodies(Rid, bool)"/>.</para>
    /// </summary>
    public virtual void _JointDisableCollisionsBetweenBodies(Rid joint, bool disable)
    {
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.JointGetParam(Rid, PhysicsServer2D.JointParam)"/>.</para>
    /// </summary>
    public virtual float _JointGetParam(Rid joint, PhysicsServer2D.JointParam param)
    {
        return default;
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.JointGetType(Rid)"/>.</para>
    /// </summary>
    public virtual PhysicsServer2D.JointType _JointGetType(Rid joint)
    {
        return default;
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.JointIsDisabledCollisionsBetweenBodies(Rid)"/>.</para>
    /// </summary>
    public virtual bool _JointIsDisabledCollisionsBetweenBodies(Rid joint)
    {
        return default;
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.JointMakeDampedSpring(Rid, Vector2, Vector2, Rid, Rid)"/>.</para>
    /// </summary>
    public virtual unsafe void _JointMakeDampedSpring(Rid joint, Vector2 anchorA, Vector2 anchorB, Rid bodyA, Rid bodyB)
    {
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.JointMakeGroove(Rid, Vector2, Vector2, Vector2, Rid, Rid)"/>.</para>
    /// </summary>
    public virtual unsafe void _JointMakeGroove(Rid joint, Vector2 aGroove1, Vector2 aGroove2, Vector2 bAnchor, Rid bodyA, Rid bodyB)
    {
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.JointMakePin(Rid, Vector2, Rid, Rid)"/>.</para>
    /// </summary>
    public virtual unsafe void _JointMakePin(Rid joint, Vector2 anchor, Rid bodyA, Rid bodyB)
    {
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.JointSetParam(Rid, PhysicsServer2D.JointParam, float)"/>.</para>
    /// </summary>
    public virtual void _JointSetParam(Rid joint, PhysicsServer2D.JointParam param, float value)
    {
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.PinJointGetFlag(Rid, PhysicsServer2D.PinJointFlag)"/>.</para>
    /// </summary>
    public virtual bool _PinJointGetFlag(Rid joint, PhysicsServer2D.PinJointFlag flag)
    {
        return default;
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.PinJointGetParam(Rid, PhysicsServer2D.PinJointParam)"/>.</para>
    /// </summary>
    public virtual float _PinJointGetParam(Rid joint, PhysicsServer2D.PinJointParam param)
    {
        return default;
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.PinJointSetFlag(Rid, PhysicsServer2D.PinJointFlag, bool)"/>.</para>
    /// </summary>
    public virtual void _PinJointSetFlag(Rid joint, PhysicsServer2D.PinJointFlag flag, bool enabled)
    {
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.PinJointSetParam(Rid, PhysicsServer2D.PinJointParam, float)"/>.</para>
    /// </summary>
    public virtual void _PinJointSetParam(Rid joint, PhysicsServer2D.PinJointParam param, float value)
    {
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.RectangleShapeCreate()"/>.</para>
    /// </summary>
    public virtual Rid _RectangleShapeCreate()
    {
        return default;
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.SegmentShapeCreate()"/>.</para>
    /// </summary>
    public virtual Rid _SegmentShapeCreate()
    {
        return default;
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.SeparationRayShapeCreate()"/>.</para>
    /// </summary>
    public virtual Rid _SeparationRayShapeCreate()
    {
        return default;
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.SetActive(bool)"/>.</para>
    /// </summary>
    public virtual void _SetActive(bool active)
    {
    }

    /// <summary>
    /// <para>Should return the custom solver bias of the given <paramref name="shape"/>, which defines how much bodies are forced to separate on contact when this shape is involved.</para>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D"/>'s internal <c>shape_get_custom_solver_bias</c> method. Corresponds to <see cref="Godot.Shape2D.CustomSolverBias"/>.</para>
    /// </summary>
    public virtual float _ShapeGetCustomSolverBias(Rid shape)
    {
        return default;
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.ShapeGetData(Rid)"/>.</para>
    /// </summary>
    public virtual Variant _ShapeGetData(Rid shape)
    {
        return default;
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.ShapeGetType(Rid)"/>.</para>
    /// </summary>
    public virtual PhysicsServer2D.ShapeType _ShapeGetType(Rid shape)
    {
        return default;
    }

    /// <summary>
    /// <para>Should set the custom solver bias for the given <paramref name="shape"/>. It defines how much bodies are forced to separate on contact.</para>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D"/>'s internal <c>shape_get_custom_solver_bias</c> method. Corresponds to <see cref="Godot.Shape2D.CustomSolverBias"/>.</para>
    /// </summary>
    public virtual void _ShapeSetCustomSolverBias(Rid shape, float bias)
    {
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.ShapeSetData(Rid, Variant)"/>.</para>
    /// </summary>
    public virtual void _ShapeSetData(Rid shape, Variant data)
    {
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.SpaceCreate()"/>.</para>
    /// </summary>
    public virtual Rid _SpaceCreate()
    {
        return default;
    }

    /// <summary>
    /// <para>Should return how many contacts have occurred during the last physics step in the given <paramref name="space"/>. See also <see cref="Godot.PhysicsServer2DExtension._SpaceGetContacts(Rid)"/> and <see cref="Godot.PhysicsServer2DExtension._SpaceSetDebugContacts(Rid, int)"/>.</para>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D"/>'s internal <c>space_get_contact_count</c> method.</para>
    /// </summary>
    public virtual int _SpaceGetContactCount(Rid space)
    {
        return default;
    }

    /// <summary>
    /// <para>Should return the positions of all contacts that have occurred during the last physics step in the given <paramref name="space"/>. See also <see cref="Godot.PhysicsServer2DExtension._SpaceGetContactCount(Rid)"/> and <see cref="Godot.PhysicsServer2DExtension._SpaceSetDebugContacts(Rid, int)"/>.</para>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D"/>'s internal <c>space_get_contacts</c> method.</para>
    /// </summary>
    public virtual Vector2[] _SpaceGetContacts(Rid space)
    {
        return default;
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.SpaceGetDirectState(Rid)"/>.</para>
    /// </summary>
    public virtual PhysicsDirectSpaceState2D _SpaceGetDirectState(Rid space)
    {
        return default;
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.SpaceGetParam(Rid, PhysicsServer2D.SpaceParameter)"/>.</para>
    /// </summary>
    public virtual float _SpaceGetParam(Rid space, PhysicsServer2D.SpaceParameter param)
    {
        return default;
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.SpaceIsActive(Rid)"/>.</para>
    /// </summary>
    public virtual bool _SpaceIsActive(Rid space)
    {
        return default;
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.SpaceSetActive(Rid, bool)"/>.</para>
    /// </summary>
    public virtual void _SpaceSetActive(Rid space, bool active)
    {
    }

    /// <summary>
    /// <para>Used internally to allow the given <paramref name="space"/> to store contact points, up to <paramref name="maxContacts"/>. This is automatically set for the main <see cref="Godot.World2D"/>'s space when <see cref="Godot.SceneTree.DebugCollisionsHint"/> is <see langword="true"/>, or by checking "Visible Collision Shapes" in the editor. Only works in debug builds.</para>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D"/>'s internal <c>space_set_debug_contacts</c> method.</para>
    /// </summary>
    public virtual void _SpaceSetDebugContacts(Rid space, int maxContacts)
    {
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.SpaceSetParam(Rid, PhysicsServer2D.SpaceParameter, float)"/>.</para>
    /// </summary>
    public virtual void _SpaceSetParam(Rid space, PhysicsServer2D.SpaceParameter param, float value)
    {
    }

    /// <summary>
    /// <para>Called every physics step to process the physics simulation. <paramref name="step"/> is the time elapsed since the last physics step, in seconds. It is usually the same as the value returned by <see cref="Godot.Node.GetPhysicsProcessDeltaTime()"/>.</para>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D"/>'s internal <c>step</c> method.</para>
    /// </summary>
    public virtual void _Step(float step)
    {
    }

    /// <summary>
    /// <para>Called to indicate that the physics server is synchronizing and cannot access physics states if running on a separate thread. See also <see cref="Godot.PhysicsServer2DExtension._EndSync()"/>.</para>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D"/>'s internal <c>sync</c> method.</para>
    /// </summary>
    public virtual void _Sync()
    {
    }

    /// <summary>
    /// <para>Overridable version of <see cref="Godot.PhysicsServer2D.WorldBoundaryShapeCreate()"/>.</para>
    /// </summary>
    public virtual Rid _WorldBoundaryShapeCreate()
    {
        return default;
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyTestMotionIsExcludingBody, 4155700596ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the body with the given <see cref="Godot.Rid"/> is being excluded from <c>_body_test_motion</c>. See also <see cref="Godot.GodotObject.GetInstanceId()"/>.</para>
    /// </summary>
    public bool BodyTestMotionIsExcludingBody(Rid body)
    {
        return NativeCalls.godot_icall_1_421(MethodBind0, GodotObject.GetPtr(this), body).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyTestMotionIsExcludingObject, 1116898809ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the object with the given instance ID is being excluded from <c>_body_test_motion</c>. See also <see cref="Godot.GodotObject.GetInstanceId()"/>.</para>
    /// </summary>
    public bool BodyTestMotionIsExcludingObject(ulong @object)
    {
        return NativeCalls.godot_icall_1_567(MethodBind1, GodotObject.GetPtr(this), @object).ToBool();
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__area_add_shape = "_AreaAddShape";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__area_attach_canvas_instance_id = "_AreaAttachCanvasInstanceId";

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
    private static readonly StringName MethodProxyName__area_get_canvas_instance_id = "_AreaGetCanvasInstanceId";

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
    private static readonly StringName MethodProxyName__area_set_pickable = "_AreaSetPickable";

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
    private static readonly StringName MethodProxyName__body_attach_canvas_instance_id = "_BodyAttachCanvasInstanceId";

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
    private static readonly StringName MethodProxyName__body_get_canvas_instance_id = "_BodyGetCanvasInstanceId";

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
    private static readonly StringName MethodProxyName__body_get_continuous_collision_detection_mode = "_BodyGetContinuousCollisionDetectionMode";

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
    private static readonly StringName MethodProxyName__body_set_continuous_collision_detection_mode = "_BodySetContinuousCollisionDetectionMode";

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
    private static readonly StringName MethodProxyName__body_set_pickable = "_BodySetPickable";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__body_set_shape = "_BodySetShape";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__body_set_shape_as_one_way_collision = "_BodySetShapeAsOneWayCollision";

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
    private static readonly StringName MethodProxyName__capsule_shape_create = "_CapsuleShapeCreate";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__circle_shape_create = "_CircleShapeCreate";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__concave_polygon_shape_create = "_ConcavePolygonShapeCreate";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__convex_polygon_shape_create = "_ConvexPolygonShapeCreate";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__damped_spring_joint_get_param = "_DampedSpringJointGetParam";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__damped_spring_joint_set_param = "_DampedSpringJointSetParam";

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
    private static readonly StringName MethodProxyName__get_process_info = "_GetProcessInfo";

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
    private static readonly StringName MethodProxyName__joint_get_param = "_JointGetParam";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__joint_get_type = "_JointGetType";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__joint_is_disabled_collisions_between_bodies = "_JointIsDisabledCollisionsBetweenBodies";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__joint_make_damped_spring = "_JointMakeDampedSpring";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__joint_make_groove = "_JointMakeGroove";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__joint_make_pin = "_JointMakePin";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__joint_set_param = "_JointSetParam";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__pin_joint_get_flag = "_PinJointGetFlag";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__pin_joint_get_param = "_PinJointGetParam";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__pin_joint_set_flag = "_PinJointSetFlag";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__pin_joint_set_param = "_PinJointSetParam";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__rectangle_shape_create = "_RectangleShapeCreate";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__segment_shape_create = "_SegmentShapeCreate";

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
    private static readonly StringName MethodProxyName__shape_get_type = "_ShapeGetType";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__shape_set_custom_solver_bias = "_ShapeSetCustomSolverBias";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__shape_set_data = "_ShapeSetData";

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
            _AreaAddShape(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<Rid>(args[1]), VariantUtils.ConvertTo<Transform2D>(args[2]), VariantUtils.ConvertTo<bool>(args[3]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__area_attach_canvas_instance_id || method == MethodName._AreaAttachCanvasInstanceId) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__area_attach_canvas_instance_id.NativeValue))
        {
            _AreaAttachCanvasInstanceId(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<ulong>(args[1]));
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
        if ((method == MethodProxyName__area_get_canvas_instance_id || method == MethodName._AreaGetCanvasInstanceId) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__area_get_canvas_instance_id.NativeValue))
        {
            var callRet = _AreaGetCanvasInstanceId(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<ulong>(callRet);
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
            var callRet = _AreaGetParam(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<PhysicsServer2D.AreaParameter>(args[1]));
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
            ret = VariantUtils.CreateFrom<Transform2D>(callRet);
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
            ret = VariantUtils.CreateFrom<Transform2D>(callRet);
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
            _AreaSetParam(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<PhysicsServer2D.AreaParameter>(args[1]), VariantUtils.ConvertTo<Variant>(args[2]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__area_set_pickable || method == MethodName._AreaSetPickable) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__area_set_pickable.NativeValue))
        {
            _AreaSetPickable(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<bool>(args[1]));
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
            _AreaSetShapeTransform(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<int>(args[1]), VariantUtils.ConvertTo<Transform2D>(args[2]));
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
            _AreaSetTransform(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<Transform2D>(args[1]));
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
            _BodyAddConstantCentralForce(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<Vector2>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__body_add_constant_force || method == MethodName._BodyAddConstantForce) && args.Count == 3 && HasGodotClassMethod((godot_string_name)MethodProxyName__body_add_constant_force.NativeValue))
        {
            _BodyAddConstantForce(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<Vector2>(args[1]), VariantUtils.ConvertTo<Vector2>(args[2]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__body_add_constant_torque || method == MethodName._BodyAddConstantTorque) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__body_add_constant_torque.NativeValue))
        {
            _BodyAddConstantTorque(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<float>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__body_add_shape || method == MethodName._BodyAddShape) && args.Count == 4 && HasGodotClassMethod((godot_string_name)MethodProxyName__body_add_shape.NativeValue))
        {
            _BodyAddShape(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<Rid>(args[1]), VariantUtils.ConvertTo<Transform2D>(args[2]), VariantUtils.ConvertTo<bool>(args[3]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__body_apply_central_force || method == MethodName._BodyApplyCentralForce) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__body_apply_central_force.NativeValue))
        {
            _BodyApplyCentralForce(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<Vector2>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__body_apply_central_impulse || method == MethodName._BodyApplyCentralImpulse) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__body_apply_central_impulse.NativeValue))
        {
            _BodyApplyCentralImpulse(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<Vector2>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__body_apply_force || method == MethodName._BodyApplyForce) && args.Count == 3 && HasGodotClassMethod((godot_string_name)MethodProxyName__body_apply_force.NativeValue))
        {
            _BodyApplyForce(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<Vector2>(args[1]), VariantUtils.ConvertTo<Vector2>(args[2]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__body_apply_impulse || method == MethodName._BodyApplyImpulse) && args.Count == 3 && HasGodotClassMethod((godot_string_name)MethodProxyName__body_apply_impulse.NativeValue))
        {
            _BodyApplyImpulse(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<Vector2>(args[1]), VariantUtils.ConvertTo<Vector2>(args[2]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__body_apply_torque || method == MethodName._BodyApplyTorque) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__body_apply_torque.NativeValue))
        {
            _BodyApplyTorque(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<float>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__body_apply_torque_impulse || method == MethodName._BodyApplyTorqueImpulse) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__body_apply_torque_impulse.NativeValue))
        {
            _BodyApplyTorqueImpulse(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<float>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__body_attach_canvas_instance_id || method == MethodName._BodyAttachCanvasInstanceId) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__body_attach_canvas_instance_id.NativeValue))
        {
            _BodyAttachCanvasInstanceId(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<ulong>(args[1]));
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
        if ((method == MethodProxyName__body_get_canvas_instance_id || method == MethodName._BodyGetCanvasInstanceId) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__body_get_canvas_instance_id.NativeValue))
        {
            var callRet = _BodyGetCanvasInstanceId(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<ulong>(callRet);
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
            ret = VariantUtils.CreateFrom<Vector2>(callRet);
            return true;
        }
        if ((method == MethodProxyName__body_get_constant_torque || method == MethodName._BodyGetConstantTorque) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__body_get_constant_torque.NativeValue))
        {
            var callRet = _BodyGetConstantTorque(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<float>(callRet);
            return true;
        }
        if ((method == MethodProxyName__body_get_contacts_reported_depth_threshold || method == MethodName._BodyGetContactsReportedDepthThreshold) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__body_get_contacts_reported_depth_threshold.NativeValue))
        {
            var callRet = _BodyGetContactsReportedDepthThreshold(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<float>(callRet);
            return true;
        }
        if ((method == MethodProxyName__body_get_continuous_collision_detection_mode || method == MethodName._BodyGetContinuousCollisionDetectionMode) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__body_get_continuous_collision_detection_mode.NativeValue))
        {
            var callRet = _BodyGetContinuousCollisionDetectionMode(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<PhysicsServer2D.CcdMode>(callRet);
            return true;
        }
        if ((method == MethodProxyName__body_get_direct_state || method == MethodName._BodyGetDirectState) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__body_get_direct_state.NativeValue))
        {
            var callRet = _BodyGetDirectState(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<PhysicsDirectBodyState2D>(callRet);
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
            ret = VariantUtils.CreateFrom<PhysicsServer2D.BodyMode>(callRet);
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
            var callRet = _BodyGetParam(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<PhysicsServer2D.BodyParameter>(args[1]));
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
            ret = VariantUtils.CreateFrom<Transform2D>(callRet);
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
            var callRet = _BodyGetState(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<PhysicsServer2D.BodyState>(args[1]));
            ret = VariantUtils.CreateFrom<Variant>(callRet);
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
        if ((method == MethodProxyName__body_set_axis_velocity || method == MethodName._BodySetAxisVelocity) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__body_set_axis_velocity.NativeValue))
        {
            _BodySetAxisVelocity(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<Vector2>(args[1]));
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
            _BodySetConstantForce(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<Vector2>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__body_set_constant_torque || method == MethodName._BodySetConstantTorque) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__body_set_constant_torque.NativeValue))
        {
            _BodySetConstantTorque(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<float>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__body_set_contacts_reported_depth_threshold || method == MethodName._BodySetContactsReportedDepthThreshold) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__body_set_contacts_reported_depth_threshold.NativeValue))
        {
            _BodySetContactsReportedDepthThreshold(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<float>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__body_set_continuous_collision_detection_mode || method == MethodName._BodySetContinuousCollisionDetectionMode) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__body_set_continuous_collision_detection_mode.NativeValue))
        {
            _BodySetContinuousCollisionDetectionMode(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<PhysicsServer2D.CcdMode>(args[1]));
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
            _BodySetMode(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<PhysicsServer2D.BodyMode>(args[1]));
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
            _BodySetParam(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<PhysicsServer2D.BodyParameter>(args[1]), VariantUtils.ConvertTo<Variant>(args[2]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__body_set_pickable || method == MethodName._BodySetPickable) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__body_set_pickable.NativeValue))
        {
            _BodySetPickable(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<bool>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__body_set_shape || method == MethodName._BodySetShape) && args.Count == 3 && HasGodotClassMethod((godot_string_name)MethodProxyName__body_set_shape.NativeValue))
        {
            _BodySetShape(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<int>(args[1]), VariantUtils.ConvertTo<Rid>(args[2]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__body_set_shape_as_one_way_collision || method == MethodName._BodySetShapeAsOneWayCollision) && args.Count == 4 && HasGodotClassMethod((godot_string_name)MethodProxyName__body_set_shape_as_one_way_collision.NativeValue))
        {
            _BodySetShapeAsOneWayCollision(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<int>(args[1]), VariantUtils.ConvertTo<bool>(args[2]), VariantUtils.ConvertTo<float>(args[3]));
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
            _BodySetShapeTransform(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<int>(args[1]), VariantUtils.ConvertTo<Transform2D>(args[2]));
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
            _BodySetState(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<PhysicsServer2D.BodyState>(args[1]), VariantUtils.ConvertTo<Variant>(args[2]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__body_set_state_sync_callback || method == MethodName._BodySetStateSyncCallback) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__body_set_state_sync_callback.NativeValue))
        {
            _BodySetStateSyncCallback(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<Callable>(args[1]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__capsule_shape_create || method == MethodName._CapsuleShapeCreate) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__capsule_shape_create.NativeValue))
        {
            var callRet = _CapsuleShapeCreate();
            ret = VariantUtils.CreateFrom<Rid>(callRet);
            return true;
        }
        if ((method == MethodProxyName__circle_shape_create || method == MethodName._CircleShapeCreate) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__circle_shape_create.NativeValue))
        {
            var callRet = _CircleShapeCreate();
            ret = VariantUtils.CreateFrom<Rid>(callRet);
            return true;
        }
        if ((method == MethodProxyName__concave_polygon_shape_create || method == MethodName._ConcavePolygonShapeCreate) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__concave_polygon_shape_create.NativeValue))
        {
            var callRet = _ConcavePolygonShapeCreate();
            ret = VariantUtils.CreateFrom<Rid>(callRet);
            return true;
        }
        if ((method == MethodProxyName__convex_polygon_shape_create || method == MethodName._ConvexPolygonShapeCreate) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__convex_polygon_shape_create.NativeValue))
        {
            var callRet = _ConvexPolygonShapeCreate();
            ret = VariantUtils.CreateFrom<Rid>(callRet);
            return true;
        }
        if ((method == MethodProxyName__damped_spring_joint_get_param || method == MethodName._DampedSpringJointGetParam) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__damped_spring_joint_get_param.NativeValue))
        {
            var callRet = _DampedSpringJointGetParam(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<PhysicsServer2D.DampedSpringParam>(args[1]));
            ret = VariantUtils.CreateFrom<float>(callRet);
            return true;
        }
        if ((method == MethodProxyName__damped_spring_joint_set_param || method == MethodName._DampedSpringJointSetParam) && args.Count == 3 && HasGodotClassMethod((godot_string_name)MethodProxyName__damped_spring_joint_set_param.NativeValue))
        {
            _DampedSpringJointSetParam(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<PhysicsServer2D.DampedSpringParam>(args[1]), VariantUtils.ConvertTo<float>(args[2]));
            ret = default;
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
        if ((method == MethodProxyName__get_process_info || method == MethodName._GetProcessInfo) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_process_info.NativeValue))
        {
            var callRet = _GetProcessInfo(VariantUtils.ConvertTo<PhysicsServer2D.ProcessInfo>(args[0]));
            ret = VariantUtils.CreateFrom<int>(callRet);
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
        if ((method == MethodProxyName__joint_get_param || method == MethodName._JointGetParam) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__joint_get_param.NativeValue))
        {
            var callRet = _JointGetParam(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<PhysicsServer2D.JointParam>(args[1]));
            ret = VariantUtils.CreateFrom<float>(callRet);
            return true;
        }
        if ((method == MethodProxyName__joint_get_type || method == MethodName._JointGetType) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__joint_get_type.NativeValue))
        {
            var callRet = _JointGetType(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<PhysicsServer2D.JointType>(callRet);
            return true;
        }
        if ((method == MethodProxyName__joint_is_disabled_collisions_between_bodies || method == MethodName._JointIsDisabledCollisionsBetweenBodies) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__joint_is_disabled_collisions_between_bodies.NativeValue))
        {
            var callRet = _JointIsDisabledCollisionsBetweenBodies(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__joint_make_damped_spring || method == MethodName._JointMakeDampedSpring) && args.Count == 5 && HasGodotClassMethod((godot_string_name)MethodProxyName__joint_make_damped_spring.NativeValue))
        {
            _JointMakeDampedSpring(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<Vector2>(args[1]), VariantUtils.ConvertTo<Vector2>(args[2]), VariantUtils.ConvertTo<Rid>(args[3]), VariantUtils.ConvertTo<Rid>(args[4]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__joint_make_groove || method == MethodName._JointMakeGroove) && args.Count == 6 && HasGodotClassMethod((godot_string_name)MethodProxyName__joint_make_groove.NativeValue))
        {
            _JointMakeGroove(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<Vector2>(args[1]), VariantUtils.ConvertTo<Vector2>(args[2]), VariantUtils.ConvertTo<Vector2>(args[3]), VariantUtils.ConvertTo<Rid>(args[4]), VariantUtils.ConvertTo<Rid>(args[5]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__joint_make_pin || method == MethodName._JointMakePin) && args.Count == 4 && HasGodotClassMethod((godot_string_name)MethodProxyName__joint_make_pin.NativeValue))
        {
            _JointMakePin(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<Vector2>(args[1]), VariantUtils.ConvertTo<Rid>(args[2]), VariantUtils.ConvertTo<Rid>(args[3]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__joint_set_param || method == MethodName._JointSetParam) && args.Count == 3 && HasGodotClassMethod((godot_string_name)MethodProxyName__joint_set_param.NativeValue))
        {
            _JointSetParam(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<PhysicsServer2D.JointParam>(args[1]), VariantUtils.ConvertTo<float>(args[2]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__pin_joint_get_flag || method == MethodName._PinJointGetFlag) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__pin_joint_get_flag.NativeValue))
        {
            var callRet = _PinJointGetFlag(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<PhysicsServer2D.PinJointFlag>(args[1]));
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__pin_joint_get_param || method == MethodName._PinJointGetParam) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__pin_joint_get_param.NativeValue))
        {
            var callRet = _PinJointGetParam(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<PhysicsServer2D.PinJointParam>(args[1]));
            ret = VariantUtils.CreateFrom<float>(callRet);
            return true;
        }
        if ((method == MethodProxyName__pin_joint_set_flag || method == MethodName._PinJointSetFlag) && args.Count == 3 && HasGodotClassMethod((godot_string_name)MethodProxyName__pin_joint_set_flag.NativeValue))
        {
            _PinJointSetFlag(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<PhysicsServer2D.PinJointFlag>(args[1]), VariantUtils.ConvertTo<bool>(args[2]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__pin_joint_set_param || method == MethodName._PinJointSetParam) && args.Count == 3 && HasGodotClassMethod((godot_string_name)MethodProxyName__pin_joint_set_param.NativeValue))
        {
            _PinJointSetParam(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<PhysicsServer2D.PinJointParam>(args[1]), VariantUtils.ConvertTo<float>(args[2]));
            ret = default;
            return true;
        }
        if ((method == MethodProxyName__rectangle_shape_create || method == MethodName._RectangleShapeCreate) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__rectangle_shape_create.NativeValue))
        {
            var callRet = _RectangleShapeCreate();
            ret = VariantUtils.CreateFrom<Rid>(callRet);
            return true;
        }
        if ((method == MethodProxyName__segment_shape_create || method == MethodName._SegmentShapeCreate) && args.Count == 0 && HasGodotClassMethod((godot_string_name)MethodProxyName__segment_shape_create.NativeValue))
        {
            var callRet = _SegmentShapeCreate();
            ret = VariantUtils.CreateFrom<Rid>(callRet);
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
        if ((method == MethodProxyName__shape_get_type || method == MethodName._ShapeGetType) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__shape_get_type.NativeValue))
        {
            var callRet = _ShapeGetType(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<PhysicsServer2D.ShapeType>(callRet);
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
            ret = VariantUtils.CreateFrom<Vector2[]>(callRet);
            return true;
        }
        if ((method == MethodProxyName__space_get_direct_state || method == MethodName._SpaceGetDirectState) && args.Count == 1 && HasGodotClassMethod((godot_string_name)MethodProxyName__space_get_direct_state.NativeValue))
        {
            var callRet = _SpaceGetDirectState(VariantUtils.ConvertTo<Rid>(args[0]));
            ret = VariantUtils.CreateFrom<PhysicsDirectSpaceState2D>(callRet);
            return true;
        }
        if ((method == MethodProxyName__space_get_param || method == MethodName._SpaceGetParam) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__space_get_param.NativeValue))
        {
            var callRet = _SpaceGetParam(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<PhysicsServer2D.SpaceParameter>(args[1]));
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
            _SpaceSetParam(VariantUtils.ConvertTo<Rid>(args[0]), VariantUtils.ConvertTo<PhysicsServer2D.SpaceParameter>(args[1]), VariantUtils.ConvertTo<float>(args[2]));
            ret = default;
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
        if (method == MethodName._AreaAttachCanvasInstanceId)
        {
            if (HasGodotClassMethod(MethodProxyName__area_attach_canvas_instance_id.NativeValue.DangerousSelfRef))
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
        if (method == MethodName._AreaGetCanvasInstanceId)
        {
            if (HasGodotClassMethod(MethodProxyName__area_get_canvas_instance_id.NativeValue.DangerousSelfRef))
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
        if (method == MethodName._AreaSetPickable)
        {
            if (HasGodotClassMethod(MethodProxyName__area_set_pickable.NativeValue.DangerousSelfRef))
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
        if (method == MethodName._BodyAttachCanvasInstanceId)
        {
            if (HasGodotClassMethod(MethodProxyName__body_attach_canvas_instance_id.NativeValue.DangerousSelfRef))
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
        if (method == MethodName._BodyGetCanvasInstanceId)
        {
            if (HasGodotClassMethod(MethodProxyName__body_get_canvas_instance_id.NativeValue.DangerousSelfRef))
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
        if (method == MethodName._BodyGetContinuousCollisionDetectionMode)
        {
            if (HasGodotClassMethod(MethodProxyName__body_get_continuous_collision_detection_mode.NativeValue.DangerousSelfRef))
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
        if (method == MethodName._BodySetContinuousCollisionDetectionMode)
        {
            if (HasGodotClassMethod(MethodProxyName__body_set_continuous_collision_detection_mode.NativeValue.DangerousSelfRef))
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
        if (method == MethodName._BodySetPickable)
        {
            if (HasGodotClassMethod(MethodProxyName__body_set_pickable.NativeValue.DangerousSelfRef))
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
        if (method == MethodName._BodySetShapeAsOneWayCollision)
        {
            if (HasGodotClassMethod(MethodProxyName__body_set_shape_as_one_way_collision.NativeValue.DangerousSelfRef))
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
        if (method == MethodName._CapsuleShapeCreate)
        {
            if (HasGodotClassMethod(MethodProxyName__capsule_shape_create.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._CircleShapeCreate)
        {
            if (HasGodotClassMethod(MethodProxyName__circle_shape_create.NativeValue.DangerousSelfRef))
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
        if (method == MethodName._ConvexPolygonShapeCreate)
        {
            if (HasGodotClassMethod(MethodProxyName__convex_polygon_shape_create.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._DampedSpringJointGetParam)
        {
            if (HasGodotClassMethod(MethodProxyName__damped_spring_joint_get_param.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._DampedSpringJointSetParam)
        {
            if (HasGodotClassMethod(MethodProxyName__damped_spring_joint_set_param.NativeValue.DangerousSelfRef))
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
        if (method == MethodName._GetProcessInfo)
        {
            if (HasGodotClassMethod(MethodProxyName__get_process_info.NativeValue.DangerousSelfRef))
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
        if (method == MethodName._JointGetParam)
        {
            if (HasGodotClassMethod(MethodProxyName__joint_get_param.NativeValue.DangerousSelfRef))
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
        if (method == MethodName._JointMakeDampedSpring)
        {
            if (HasGodotClassMethod(MethodProxyName__joint_make_damped_spring.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._JointMakeGroove)
        {
            if (HasGodotClassMethod(MethodProxyName__joint_make_groove.NativeValue.DangerousSelfRef))
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
        if (method == MethodName._JointSetParam)
        {
            if (HasGodotClassMethod(MethodProxyName__joint_set_param.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._PinJointGetFlag)
        {
            if (HasGodotClassMethod(MethodProxyName__pin_joint_get_flag.NativeValue.DangerousSelfRef))
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
        if (method == MethodName._PinJointSetFlag)
        {
            if (HasGodotClassMethod(MethodProxyName__pin_joint_set_flag.NativeValue.DangerousSelfRef))
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
        if (method == MethodName._RectangleShapeCreate)
        {
            if (HasGodotClassMethod(MethodProxyName__rectangle_shape_create.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._SegmentShapeCreate)
        {
            if (HasGodotClassMethod(MethodProxyName__segment_shape_create.NativeValue.DangerousSelfRef))
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
    public new class PropertyName : PhysicsServer2D.PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : PhysicsServer2D.MethodName
    {
        /// <summary>
        /// Cached name for the '_area_add_shape' method.
        /// </summary>
        public static readonly StringName _AreaAddShape = "_area_add_shape";
        /// <summary>
        /// Cached name for the '_area_attach_canvas_instance_id' method.
        /// </summary>
        public static readonly StringName _AreaAttachCanvasInstanceId = "_area_attach_canvas_instance_id";
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
        /// Cached name for the '_area_get_canvas_instance_id' method.
        /// </summary>
        public static readonly StringName _AreaGetCanvasInstanceId = "_area_get_canvas_instance_id";
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
        /// Cached name for the '_area_set_pickable' method.
        /// </summary>
        public static readonly StringName _AreaSetPickable = "_area_set_pickable";
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
        /// Cached name for the '_body_attach_canvas_instance_id' method.
        /// </summary>
        public static readonly StringName _BodyAttachCanvasInstanceId = "_body_attach_canvas_instance_id";
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
        /// Cached name for the '_body_get_canvas_instance_id' method.
        /// </summary>
        public static readonly StringName _BodyGetCanvasInstanceId = "_body_get_canvas_instance_id";
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
        /// Cached name for the '_body_get_continuous_collision_detection_mode' method.
        /// </summary>
        public static readonly StringName _BodyGetContinuousCollisionDetectionMode = "_body_get_continuous_collision_detection_mode";
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
        /// Cached name for the '_body_set_continuous_collision_detection_mode' method.
        /// </summary>
        public static readonly StringName _BodySetContinuousCollisionDetectionMode = "_body_set_continuous_collision_detection_mode";
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
        /// Cached name for the '_body_set_pickable' method.
        /// </summary>
        public static readonly StringName _BodySetPickable = "_body_set_pickable";
        /// <summary>
        /// Cached name for the '_body_set_shape' method.
        /// </summary>
        public static readonly StringName _BodySetShape = "_body_set_shape";
        /// <summary>
        /// Cached name for the '_body_set_shape_as_one_way_collision' method.
        /// </summary>
        public static readonly StringName _BodySetShapeAsOneWayCollision = "_body_set_shape_as_one_way_collision";
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
        /// Cached name for the '_capsule_shape_create' method.
        /// </summary>
        public static readonly StringName _CapsuleShapeCreate = "_capsule_shape_create";
        /// <summary>
        /// Cached name for the '_circle_shape_create' method.
        /// </summary>
        public static readonly StringName _CircleShapeCreate = "_circle_shape_create";
        /// <summary>
        /// Cached name for the '_concave_polygon_shape_create' method.
        /// </summary>
        public static readonly StringName _ConcavePolygonShapeCreate = "_concave_polygon_shape_create";
        /// <summary>
        /// Cached name for the '_convex_polygon_shape_create' method.
        /// </summary>
        public static readonly StringName _ConvexPolygonShapeCreate = "_convex_polygon_shape_create";
        /// <summary>
        /// Cached name for the '_damped_spring_joint_get_param' method.
        /// </summary>
        public static readonly StringName _DampedSpringJointGetParam = "_damped_spring_joint_get_param";
        /// <summary>
        /// Cached name for the '_damped_spring_joint_set_param' method.
        /// </summary>
        public static readonly StringName _DampedSpringJointSetParam = "_damped_spring_joint_set_param";
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
        /// Cached name for the '_get_process_info' method.
        /// </summary>
        public static readonly StringName _GetProcessInfo = "_get_process_info";
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
        /// Cached name for the '_joint_get_param' method.
        /// </summary>
        public static readonly StringName _JointGetParam = "_joint_get_param";
        /// <summary>
        /// Cached name for the '_joint_get_type' method.
        /// </summary>
        public static readonly StringName _JointGetType = "_joint_get_type";
        /// <summary>
        /// Cached name for the '_joint_is_disabled_collisions_between_bodies' method.
        /// </summary>
        public static readonly StringName _JointIsDisabledCollisionsBetweenBodies = "_joint_is_disabled_collisions_between_bodies";
        /// <summary>
        /// Cached name for the '_joint_make_damped_spring' method.
        /// </summary>
        public static readonly StringName _JointMakeDampedSpring = "_joint_make_damped_spring";
        /// <summary>
        /// Cached name for the '_joint_make_groove' method.
        /// </summary>
        public static readonly StringName _JointMakeGroove = "_joint_make_groove";
        /// <summary>
        /// Cached name for the '_joint_make_pin' method.
        /// </summary>
        public static readonly StringName _JointMakePin = "_joint_make_pin";
        /// <summary>
        /// Cached name for the '_joint_set_param' method.
        /// </summary>
        public static readonly StringName _JointSetParam = "_joint_set_param";
        /// <summary>
        /// Cached name for the '_pin_joint_get_flag' method.
        /// </summary>
        public static readonly StringName _PinJointGetFlag = "_pin_joint_get_flag";
        /// <summary>
        /// Cached name for the '_pin_joint_get_param' method.
        /// </summary>
        public static readonly StringName _PinJointGetParam = "_pin_joint_get_param";
        /// <summary>
        /// Cached name for the '_pin_joint_set_flag' method.
        /// </summary>
        public static readonly StringName _PinJointSetFlag = "_pin_joint_set_flag";
        /// <summary>
        /// Cached name for the '_pin_joint_set_param' method.
        /// </summary>
        public static readonly StringName _PinJointSetParam = "_pin_joint_set_param";
        /// <summary>
        /// Cached name for the '_rectangle_shape_create' method.
        /// </summary>
        public static readonly StringName _RectangleShapeCreate = "_rectangle_shape_create";
        /// <summary>
        /// Cached name for the '_segment_shape_create' method.
        /// </summary>
        public static readonly StringName _SegmentShapeCreate = "_segment_shape_create";
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
    public new class SignalName : PhysicsServer2D.SignalName
    {
    }
}
