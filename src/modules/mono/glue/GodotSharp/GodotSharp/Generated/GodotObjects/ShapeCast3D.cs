namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Shape casting allows to detect collision objects by sweeping its <see cref="Godot.ShapeCast3D.Shape"/> along the cast direction determined by <see cref="Godot.ShapeCast3D.TargetPosition"/>. This is similar to <see cref="Godot.RayCast3D"/>, but it allows for sweeping a region of space, rather than just a straight line. <see cref="Godot.ShapeCast3D"/> can detect multiple collision objects. It is useful for things like wide laser beams or snapping a simple shape to a floor.</para>
/// <para>Immediate collision overlaps can be done with the <see cref="Godot.ShapeCast3D.TargetPosition"/> set to <c>Vector3(0, 0, 0)</c> and by calling <see cref="Godot.ShapeCast3D.ForceShapecastUpdate()"/> within the same physics frame. This helps to overcome some limitations of <see cref="Godot.Area3D"/> when used as an instantaneous detection area, as collision information isn't immediately available to it.</para>
/// <para><b>Note:</b> Shape casting is more computationally expensive than ray casting.</para>
/// </summary>
public partial class ShapeCast3D : Node3D
{
    /// <summary>
    /// <para>If <see langword="true"/>, collisions will be reported.</para>
    /// </summary>
    public bool Enabled
    {
        get
        {
            return IsEnabled();
        }
        set
        {
            SetEnabled(value);
        }
    }

    /// <summary>
    /// <para>The shape to be used for collision queries.</para>
    /// </summary>
    public Shape3D Shape
    {
        get
        {
            return GetShape();
        }
        set
        {
            SetShape(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the parent node will be excluded from collision detection.</para>
    /// </summary>
    public bool ExcludeParent
    {
        get
        {
            return GetExcludeParentBody();
        }
        set
        {
            SetExcludeParentBody(value);
        }
    }

    /// <summary>
    /// <para>The shape's destination point, relative to this node's <see cref="Godot.Node3D.Position"/>.</para>
    /// </summary>
    public Vector3 TargetPosition
    {
        get
        {
            return GetTargetPosition();
        }
        set
        {
            SetTargetPosition(value);
        }
    }

    /// <summary>
    /// <para>The collision margin for the shape. A larger margin helps detecting collisions more consistently, at the cost of precision.</para>
    /// </summary>
    public float Margin
    {
        get
        {
            return GetMargin();
        }
        set
        {
            SetMargin(value);
        }
    }

    /// <summary>
    /// <para>The number of intersections can be limited with this parameter, to reduce the processing time.</para>
    /// </summary>
    public int MaxResults
    {
        get
        {
            return GetMaxResults();
        }
        set
        {
            SetMaxResults(value);
        }
    }

    /// <summary>
    /// <para>The shape's collision mask. Only objects in at least one collision layer enabled in the mask will be detected. See <a href="$DOCS_URL/tutorials/physics/physics_introduction.html#collision-layers-and-masks">Collision layers and masks</a> in the documentation for more information.</para>
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
    /// <para>Returns the complete collision information from the collision sweep. The data returned is the same as in the <see cref="Godot.PhysicsDirectSpaceState3D.GetRestInfo(PhysicsShapeQueryParameters3D)"/> method.</para>
    /// </summary>
    public Godot.Collections.Array CollisionResult
    {
        get
        {
            return GetCollisionResult();
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, collisions with <see cref="Godot.Area3D"/>s will be reported.</para>
    /// </summary>
    public bool CollideWithAreas
    {
        get
        {
            return IsCollideWithAreasEnabled();
        }
        set
        {
            SetCollideWithAreas(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, collisions with <see cref="Godot.PhysicsBody3D"/>s will be reported.</para>
    /// </summary>
    public bool CollideWithBodies
    {
        get
        {
            return IsCollideWithBodiesEnabled();
        }
        set
        {
            SetCollideWithBodies(value);
        }
    }

    /// <summary>
    /// <para>The custom color to use to draw the shape in the editor and at run-time if <b>Visible Collision Shapes</b> is enabled in the <b>Debug</b> menu. This color will be highlighted at run-time if the <see cref="Godot.ShapeCast3D"/> is colliding with something.</para>
    /// <para>If set to <c>Color(0.0, 0.0, 0.0)</c> (by default), the color set in <c>ProjectSettings.debug/shapes/collision/shape_color</c> is used.</para>
    /// </summary>
    public Color DebugShapeCustomColor
    {
        get
        {
            return GetDebugShapeCustomColor();
        }
        set
        {
            SetDebugShapeCustomColor(value);
        }
    }

    private static readonly System.Type CachedType = typeof(ShapeCast3D);

    private static readonly StringName NativeName = "ShapeCast3D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public ShapeCast3D() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal ShapeCast3D(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal ShapeCast3D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ResourceChanged, 968641751ul);

    /// <summary>
    /// <para>This method does nothing.</para>
    /// </summary>
    [Obsolete("Use 'Godot.Resource.Changed' instead.")]
    public void ResourceChanged(Resource resource)
    {
        NativeCalls.godot_icall_1_56(MethodBind0, GodotObject.GetPtr(this), GodotObject.GetPtr(resource));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEnabled(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind1, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind2, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetShape, 1549710052ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetShape(Shape3D shape)
    {
        NativeCalls.godot_icall_1_56(MethodBind3, GodotObject.GetPtr(this), GodotObject.GetPtr(shape));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetShape, 3214262478ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Shape3D GetShape()
    {
        return (Shape3D)NativeCalls.godot_icall_0_63(MethodBind4, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTargetPosition, 3460891852ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetTargetPosition(Vector3 localPoint)
    {
        NativeCalls.godot_icall_1_177(MethodBind5, GodotObject.GetPtr(this), &localPoint);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTargetPosition, 3360562783ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector3 GetTargetPosition()
    {
        return NativeCalls.godot_icall_0_125(MethodBind6, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMargin, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMargin(float margin)
    {
        NativeCalls.godot_icall_1_67(MethodBind7, GodotObject.GetPtr(this), margin);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMargin, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetMargin()
    {
        return NativeCalls.godot_icall_0_68(MethodBind8, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMaxResults, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMaxResults(int maxResults)
    {
        NativeCalls.godot_icall_1_38(MethodBind9, GodotObject.GetPtr(this), maxResults);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMaxResults, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetMaxResults()
    {
        return NativeCalls.godot_icall_0_39(MethodBind10, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsColliding, 36873697ul);

    /// <summary>
    /// <para>Returns whether any object is intersecting with the shape's vector (considering the vector length).</para>
    /// </summary>
    public bool IsColliding()
    {
        return NativeCalls.godot_icall_0_15(MethodBind11, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCollisionCount, 3905245786ul);

    /// <summary>
    /// <para>The number of collisions detected at the point of impact. Use this to iterate over multiple collisions as provided by <see cref="Godot.ShapeCast3D.GetCollider(int)"/>, <see cref="Godot.ShapeCast3D.GetColliderShape(int)"/>, <see cref="Godot.ShapeCast3D.GetCollisionPoint(int)"/>, and <see cref="Godot.ShapeCast3D.GetCollisionNormal(int)"/> methods.</para>
    /// </summary>
    public int GetCollisionCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind12, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ForceShapecastUpdate, 3218959716ul);

    /// <summary>
    /// <para>Updates the collision information for the shape immediately, without waiting for the next <c>_physics_process</c> call. Use this method, for example, when the shape or its parent has changed state.</para>
    /// <para><b>Note:</b> Setting <see cref="Godot.ShapeCast3D.Enabled"/> to <see langword="true"/> is not required for this to work.</para>
    /// </summary>
    public void ForceShapecastUpdate()
    {
        NativeCalls.godot_icall_0_3(MethodBind13, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCollider, 3332903315ul);

    /// <summary>
    /// <para>Returns the collided <see cref="Godot.GodotObject"/> of one of the multiple collisions at <paramref name="index"/>, or <see langword="null"/> if no object is intersecting the shape (i.e. <see cref="Godot.ShapeCast3D.IsColliding()"/> returns <see langword="false"/>).</para>
    /// </summary>
    public GodotObject GetCollider(int index)
    {
        return (GodotObject)NativeCalls.godot_icall_1_335(MethodBind14, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetColliderRid, 495598643ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.Rid"/> of the collided object of one of the multiple collisions at <paramref name="index"/>.</para>
    /// </summary>
    public Rid GetColliderRid(int index)
    {
        return NativeCalls.godot_icall_1_425(MethodBind15, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetColliderShape, 923996154ul);

    /// <summary>
    /// <para>Returns the shape ID of the colliding shape of one of the multiple collisions at <paramref name="index"/>, or <c>0</c> if no object is intersecting the shape (i.e. <see cref="Godot.ShapeCast3D.IsColliding()"/> returns <see langword="false"/>).</para>
    /// </summary>
    public int GetColliderShape(int index)
    {
        return NativeCalls.godot_icall_1_60(MethodBind16, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCollisionPoint, 711720468ul);

    /// <summary>
    /// <para>Returns the collision point of one of the multiple collisions at <paramref name="index"/> where the shape intersects the colliding object.</para>
    /// <para><b>Note:</b> This point is in the <b>global</b> coordinate system.</para>
    /// </summary>
    public Vector3 GetCollisionPoint(int index)
    {
        return NativeCalls.godot_icall_1_363(MethodBind17, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCollisionNormal, 711720468ul);

    /// <summary>
    /// <para>Returns the normal of one of the multiple collisions at <paramref name="index"/> of the intersecting object.</para>
    /// </summary>
    public Vector3 GetCollisionNormal(int index)
    {
        return NativeCalls.godot_icall_1_363(MethodBind18, GodotObject.GetPtr(this), index);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetClosestCollisionSafeFraction, 1740695150ul);

    /// <summary>
    /// <para>Returns the fraction from this cast's origin to its <see cref="Godot.ShapeCast3D.TargetPosition"/> of how far the shape can move without triggering a collision, as a value between <c>0.0</c> and <c>1.0</c>.</para>
    /// </summary>
    public float GetClosestCollisionSafeFraction()
    {
        return NativeCalls.godot_icall_0_68(MethodBind19, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetClosestCollisionUnsafeFraction, 1740695150ul);

    /// <summary>
    /// <para>Returns the fraction from this cast's origin to its <see cref="Godot.ShapeCast3D.TargetPosition"/> of how far the shape must move to trigger a collision, as a value between <c>0.0</c> and <c>1.0</c>.</para>
    /// <para>In ideal conditions this would be the same as <see cref="Godot.ShapeCast3D.GetClosestCollisionSafeFraction()"/>, however shape casting is calculated in discrete steps, so the precise point of collision can occur between two calculated positions.</para>
    /// </summary>
    public float GetClosestCollisionUnsafeFraction()
    {
        return NativeCalls.godot_icall_0_68(MethodBind20, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddExceptionRid, 2722037293ul);

    /// <summary>
    /// <para>Adds a collision exception so the shape does not report collisions with the specified <see cref="Godot.Rid"/>.</para>
    /// </summary>
    public void AddExceptionRid(Rid rid)
    {
        NativeCalls.godot_icall_1_286(MethodBind21, GodotObject.GetPtr(this), rid);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddException, 1976431078ul);

    /// <summary>
    /// <para>Adds a collision exception so the shape does not report collisions with the specified node.</para>
    /// </summary>
    public void AddException(CollisionObject3D node)
    {
        NativeCalls.godot_icall_1_56(MethodBind22, GodotObject.GetPtr(this), GodotObject.GetPtr(node));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveExceptionRid, 2722037293ul);

    /// <summary>
    /// <para>Removes a collision exception so the shape does report collisions with the specified <see cref="Godot.Rid"/>.</para>
    /// </summary>
    public void RemoveExceptionRid(Rid rid)
    {
        NativeCalls.godot_icall_1_286(MethodBind23, GodotObject.GetPtr(this), rid);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveException, 1976431078ul);

    /// <summary>
    /// <para>Removes a collision exception so the shape does report collisions with the specified node.</para>
    /// </summary>
    public void RemoveException(CollisionObject3D node)
    {
        NativeCalls.godot_icall_1_56(MethodBind24, GodotObject.GetPtr(this), GodotObject.GetPtr(node));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ClearExceptions, 3218959716ul);

    /// <summary>
    /// <para>Removes all collision exceptions for this shape.</para>
    /// </summary>
    public void ClearExceptions()
    {
        NativeCalls.godot_icall_0_3(MethodBind25, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCollisionMask, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCollisionMask(uint mask)
    {
        NativeCalls.godot_icall_1_208(MethodBind26, GodotObject.GetPtr(this), mask);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCollisionMask, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public uint GetCollisionMask()
    {
        return NativeCalls.godot_icall_0_209(MethodBind27, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCollisionMaskValue, 300928843ul);

    /// <summary>
    /// <para>Based on <paramref name="value"/>, enables or disables the specified layer in the <see cref="Godot.ShapeCast3D.CollisionMask"/>, given a <paramref name="layerNumber"/> between 1 and 32.</para>
    /// </summary>
    public void SetCollisionMaskValue(int layerNumber, bool value)
    {
        NativeCalls.godot_icall_2_61(MethodBind28, GodotObject.GetPtr(this), layerNumber, value.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCollisionMaskValue, 1116898809ul);

    /// <summary>
    /// <para>Returns whether or not the specified layer of the <see cref="Godot.ShapeCast3D.CollisionMask"/> is enabled, given a <paramref name="layerNumber"/> between 1 and 32.</para>
    /// </summary>
    public bool GetCollisionMaskValue(int layerNumber)
    {
        return NativeCalls.godot_icall_1_62(MethodBind29, GodotObject.GetPtr(this), layerNumber).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetExcludeParentBody, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetExcludeParentBody(bool mask)
    {
        NativeCalls.godot_icall_1_14(MethodBind30, GodotObject.GetPtr(this), mask.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetExcludeParentBody, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetExcludeParentBody()
    {
        return NativeCalls.godot_icall_0_15(MethodBind31, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind32 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCollideWithAreas, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCollideWithAreas(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind32, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind33 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsCollideWithAreasEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsCollideWithAreasEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind33, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind34 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCollideWithBodies, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCollideWithBodies(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind34, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind35 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsCollideWithBodiesEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsCollideWithBodiesEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind35, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind36 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCollisionResult, 3995934104ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Godot.Collections.Array GetCollisionResult()
    {
        return NativeCalls.godot_icall_0_120(MethodBind36, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind37 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDebugShapeCustomColor, 2920490490ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetDebugShapeCustomColor(Color debugShapeCustomColor)
    {
        NativeCalls.godot_icall_1_213(MethodBind37, GodotObject.GetPtr(this), &debugShapeCustomColor);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind38 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDebugShapeCustomColor, 3444240500ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Color GetDebugShapeCustomColor()
    {
        return NativeCalls.godot_icall_0_214(MethodBind38, GodotObject.GetPtr(this));
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
        /// Cached name for the 'enabled' property.
        /// </summary>
        public static readonly StringName Enabled = "enabled";
        /// <summary>
        /// Cached name for the 'shape' property.
        /// </summary>
        public static readonly StringName Shape = "shape";
        /// <summary>
        /// Cached name for the 'exclude_parent' property.
        /// </summary>
        public static readonly StringName ExcludeParent = "exclude_parent";
        /// <summary>
        /// Cached name for the 'target_position' property.
        /// </summary>
        public static readonly StringName TargetPosition = "target_position";
        /// <summary>
        /// Cached name for the 'margin' property.
        /// </summary>
        public static readonly StringName Margin = "margin";
        /// <summary>
        /// Cached name for the 'max_results' property.
        /// </summary>
        public static readonly StringName MaxResults = "max_results";
        /// <summary>
        /// Cached name for the 'collision_mask' property.
        /// </summary>
        public static readonly StringName CollisionMask = "collision_mask";
        /// <summary>
        /// Cached name for the 'collision_result' property.
        /// </summary>
        public static readonly StringName CollisionResult = "collision_result";
        /// <summary>
        /// Cached name for the 'collide_with_areas' property.
        /// </summary>
        public static readonly StringName CollideWithAreas = "collide_with_areas";
        /// <summary>
        /// Cached name for the 'collide_with_bodies' property.
        /// </summary>
        public static readonly StringName CollideWithBodies = "collide_with_bodies";
        /// <summary>
        /// Cached name for the 'debug_shape_custom_color' property.
        /// </summary>
        public static readonly StringName DebugShapeCustomColor = "debug_shape_custom_color";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Node3D.MethodName
    {
        /// <summary>
        /// Cached name for the 'resource_changed' method.
        /// </summary>
        public static readonly StringName ResourceChanged = "resource_changed";
        /// <summary>
        /// Cached name for the 'set_enabled' method.
        /// </summary>
        public static readonly StringName SetEnabled = "set_enabled";
        /// <summary>
        /// Cached name for the 'is_enabled' method.
        /// </summary>
        public static readonly StringName IsEnabled = "is_enabled";
        /// <summary>
        /// Cached name for the 'set_shape' method.
        /// </summary>
        public static readonly StringName SetShape = "set_shape";
        /// <summary>
        /// Cached name for the 'get_shape' method.
        /// </summary>
        public static readonly StringName GetShape = "get_shape";
        /// <summary>
        /// Cached name for the 'set_target_position' method.
        /// </summary>
        public static readonly StringName SetTargetPosition = "set_target_position";
        /// <summary>
        /// Cached name for the 'get_target_position' method.
        /// </summary>
        public static readonly StringName GetTargetPosition = "get_target_position";
        /// <summary>
        /// Cached name for the 'set_margin' method.
        /// </summary>
        public static readonly StringName SetMargin = "set_margin";
        /// <summary>
        /// Cached name for the 'get_margin' method.
        /// </summary>
        public static readonly StringName GetMargin = "get_margin";
        /// <summary>
        /// Cached name for the 'set_max_results' method.
        /// </summary>
        public static readonly StringName SetMaxResults = "set_max_results";
        /// <summary>
        /// Cached name for the 'get_max_results' method.
        /// </summary>
        public static readonly StringName GetMaxResults = "get_max_results";
        /// <summary>
        /// Cached name for the 'is_colliding' method.
        /// </summary>
        public static readonly StringName IsColliding = "is_colliding";
        /// <summary>
        /// Cached name for the 'get_collision_count' method.
        /// </summary>
        public static readonly StringName GetCollisionCount = "get_collision_count";
        /// <summary>
        /// Cached name for the 'force_shapecast_update' method.
        /// </summary>
        public static readonly StringName ForceShapecastUpdate = "force_shapecast_update";
        /// <summary>
        /// Cached name for the 'get_collider' method.
        /// </summary>
        public static readonly StringName GetCollider = "get_collider";
        /// <summary>
        /// Cached name for the 'get_collider_rid' method.
        /// </summary>
        public static readonly StringName GetColliderRid = "get_collider_rid";
        /// <summary>
        /// Cached name for the 'get_collider_shape' method.
        /// </summary>
        public static readonly StringName GetColliderShape = "get_collider_shape";
        /// <summary>
        /// Cached name for the 'get_collision_point' method.
        /// </summary>
        public static readonly StringName GetCollisionPoint = "get_collision_point";
        /// <summary>
        /// Cached name for the 'get_collision_normal' method.
        /// </summary>
        public static readonly StringName GetCollisionNormal = "get_collision_normal";
        /// <summary>
        /// Cached name for the 'get_closest_collision_safe_fraction' method.
        /// </summary>
        public static readonly StringName GetClosestCollisionSafeFraction = "get_closest_collision_safe_fraction";
        /// <summary>
        /// Cached name for the 'get_closest_collision_unsafe_fraction' method.
        /// </summary>
        public static readonly StringName GetClosestCollisionUnsafeFraction = "get_closest_collision_unsafe_fraction";
        /// <summary>
        /// Cached name for the 'add_exception_rid' method.
        /// </summary>
        public static readonly StringName AddExceptionRid = "add_exception_rid";
        /// <summary>
        /// Cached name for the 'add_exception' method.
        /// </summary>
        public static readonly StringName AddException = "add_exception";
        /// <summary>
        /// Cached name for the 'remove_exception_rid' method.
        /// </summary>
        public static readonly StringName RemoveExceptionRid = "remove_exception_rid";
        /// <summary>
        /// Cached name for the 'remove_exception' method.
        /// </summary>
        public static readonly StringName RemoveException = "remove_exception";
        /// <summary>
        /// Cached name for the 'clear_exceptions' method.
        /// </summary>
        public static readonly StringName ClearExceptions = "clear_exceptions";
        /// <summary>
        /// Cached name for the 'set_collision_mask' method.
        /// </summary>
        public static readonly StringName SetCollisionMask = "set_collision_mask";
        /// <summary>
        /// Cached name for the 'get_collision_mask' method.
        /// </summary>
        public static readonly StringName GetCollisionMask = "get_collision_mask";
        /// <summary>
        /// Cached name for the 'set_collision_mask_value' method.
        /// </summary>
        public static readonly StringName SetCollisionMaskValue = "set_collision_mask_value";
        /// <summary>
        /// Cached name for the 'get_collision_mask_value' method.
        /// </summary>
        public static readonly StringName GetCollisionMaskValue = "get_collision_mask_value";
        /// <summary>
        /// Cached name for the 'set_exclude_parent_body' method.
        /// </summary>
        public static readonly StringName SetExcludeParentBody = "set_exclude_parent_body";
        /// <summary>
        /// Cached name for the 'get_exclude_parent_body' method.
        /// </summary>
        public static readonly StringName GetExcludeParentBody = "get_exclude_parent_body";
        /// <summary>
        /// Cached name for the 'set_collide_with_areas' method.
        /// </summary>
        public static readonly StringName SetCollideWithAreas = "set_collide_with_areas";
        /// <summary>
        /// Cached name for the 'is_collide_with_areas_enabled' method.
        /// </summary>
        public static readonly StringName IsCollideWithAreasEnabled = "is_collide_with_areas_enabled";
        /// <summary>
        /// Cached name for the 'set_collide_with_bodies' method.
        /// </summary>
        public static readonly StringName SetCollideWithBodies = "set_collide_with_bodies";
        /// <summary>
        /// Cached name for the 'is_collide_with_bodies_enabled' method.
        /// </summary>
        public static readonly StringName IsCollideWithBodiesEnabled = "is_collide_with_bodies_enabled";
        /// <summary>
        /// Cached name for the 'get_collision_result' method.
        /// </summary>
        public static readonly StringName GetCollisionResult = "get_collision_result";
        /// <summary>
        /// Cached name for the 'set_debug_shape_custom_color' method.
        /// </summary>
        public static readonly StringName SetDebugShapeCustomColor = "set_debug_shape_custom_color";
        /// <summary>
        /// Cached name for the 'get_debug_shape_custom_color' method.
        /// </summary>
        public static readonly StringName GetDebugShapeCustomColor = "get_debug_shape_custom_color";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Node3D.SignalName
    {
    }
}
