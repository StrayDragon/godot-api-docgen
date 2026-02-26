namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>PhysicsServer2D is the server responsible for all 2D physics. It can directly create and manipulate all physics objects:</para>
/// <para>- A <i>space</i> is a self-contained world for a physics simulation. It contains bodies, areas, and joints. Its state can be queried for collision and intersection information, and several parameters of the simulation can be modified.</para>
/// <para>- A <i>shape</i> is a geometric shape such as a circle, a rectangle, a capsule, or a polygon. It can be used for collision detection by adding it to a body/area, possibly with an extra transformation relative to the body/area's origin. Bodies/areas can have multiple (transformed) shapes added to them, and a single shape can be added to bodies/areas multiple times with different local transformations.</para>
/// <para>- A <i>body</i> is a physical object which can be in static, kinematic, or rigid mode. Its state (such as position and velocity) can be queried and updated. A force integration callback can be set to customize the body's physics.</para>
/// <para>- An <i>area</i> is a region in space which can be used to detect bodies and areas entering and exiting it. A body monitoring callback can be set to report entering/exiting body shapes, and similarly an area monitoring callback can be set. Gravity and damping can be overridden within the area by setting area parameters.</para>
/// <para>- A <i>joint</i> is a constraint, either between two bodies or on one body relative to a point. Parameters such as the joint bias and the rest length of a spring joint can be adjusted.</para>
/// <para>Physics objects in <see cref="Godot.PhysicsServer2D"/> may be created and manipulated independently; they do not have to be tied to nodes in the scene tree.</para>
/// <para><b>Note:</b> All the 2D physics nodes use the physics server internally. Adding a physics node to the scene tree will cause a corresponding physics object to be created in the physics server. A rigid body node registers a callback that updates the node's transform with the transform of the respective body object in the physics server (every physics update). An area node registers a callback to inform the area node about overlaps with the respective area object in the physics server. The raycast node queries the direct state of the relevant space in the physics server.</para>
/// </summary>
[GodotClassName("PhysicsServer2D")]
public partial class PhysicsServer2DInstance : GodotObject
{
    private static readonly System.Type CachedType = typeof(PhysicsServer2DInstance);

    private static readonly StringName NativeName = "PhysicsServer2D";

    internal PhysicsServer2DInstance() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal PhysicsServer2DInstance(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal PhysicsServer2DInstance(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.WorldBoundaryShapeCreate, 529393457ul);

    /// <summary>
    /// <para>Creates a 2D world boundary shape in the physics server, and returns the <see cref="Godot.Rid"/> that identifies it. Use <see cref="Godot.PhysicsServer2DInstance.ShapeSetData(Rid, Variant)"/> to set the shape's normal direction and distance properties.</para>
    /// </summary>
    public Rid WorldBoundaryShapeCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind0, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SeparationRayShapeCreate, 529393457ul);

    /// <summary>
    /// <para>Creates a 2D separation ray shape in the physics server, and returns the <see cref="Godot.Rid"/> that identifies it. Use <see cref="Godot.PhysicsServer2DInstance.ShapeSetData(Rid, Variant)"/> to set the shape's <c>length</c> and <c>slide_on_slope</c> properties.</para>
    /// </summary>
    public Rid SeparationRayShapeCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SegmentShapeCreate, 529393457ul);

    /// <summary>
    /// <para>Creates a 2D segment shape in the physics server, and returns the <see cref="Godot.Rid"/> that identifies it. Use <see cref="Godot.PhysicsServer2DInstance.ShapeSetData(Rid, Variant)"/> to set the segment's start and end points.</para>
    /// </summary>
    public Rid SegmentShapeCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CircleShapeCreate, 529393457ul);

    /// <summary>
    /// <para>Creates a 2D circle shape in the physics server, and returns the <see cref="Godot.Rid"/> that identifies it. Use <see cref="Godot.PhysicsServer2DInstance.ShapeSetData(Rid, Variant)"/> to set the circle's radius.</para>
    /// </summary>
    public Rid CircleShapeCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RectangleShapeCreate, 529393457ul);

    /// <summary>
    /// <para>Creates a 2D rectangle shape in the physics server, and returns the <see cref="Godot.Rid"/> that identifies it. Use <see cref="Godot.PhysicsServer2DInstance.ShapeSetData(Rid, Variant)"/> to set the rectangle's half-extents.</para>
    /// </summary>
    public Rid RectangleShapeCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind4, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CapsuleShapeCreate, 529393457ul);

    /// <summary>
    /// <para>Creates a 2D capsule shape in the physics server, and returns the <see cref="Godot.Rid"/> that identifies it. Use <see cref="Godot.PhysicsServer2DInstance.ShapeSetData(Rid, Variant)"/> to set the capsule's height and radius.</para>
    /// </summary>
    public Rid CapsuleShapeCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ConvexPolygonShapeCreate, 529393457ul);

    /// <summary>
    /// <para>Creates a 2D convex polygon shape in the physics server, and returns the <see cref="Godot.Rid"/> that identifies it. Use <see cref="Godot.PhysicsServer2DInstance.ShapeSetData(Rid, Variant)"/> to set the convex polygon's points.</para>
    /// </summary>
    public Rid ConvexPolygonShapeCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind6, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ConcavePolygonShapeCreate, 529393457ul);

    /// <summary>
    /// <para>Creates a 2D concave polygon shape in the physics server, and returns the <see cref="Godot.Rid"/> that identifies it. Use <see cref="Godot.PhysicsServer2DInstance.ShapeSetData(Rid, Variant)"/> to set the concave polygon's segments.</para>
    /// </summary>
    public Rid ConcavePolygonShapeCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapeSetData, 3175752987ul);

    /// <summary>
    /// <para>Sets the shape data that defines the configuration of the shape. The <paramref name="data"/> to be passed depends on the shape's type (see <see cref="Godot.PhysicsServer2DInstance.ShapeGetType(Rid)"/>):</para>
    /// <para>- <see cref="Godot.PhysicsServer2D.ShapeType.WorldBoundary"/>: an array of length two containing a <see cref="Godot.Vector2"/> <c>normal</c> direction and a <see cref="float"/> distance <c>d</c>,</para>
    /// <para>- <see cref="Godot.PhysicsServer2D.ShapeType.SeparationRay"/>: a dictionary containing the key <c>length</c> with a <see cref="float"/> value and the key <c>slide_on_slope</c> with a <see cref="bool"/> value,</para>
    /// <para>- <see cref="Godot.PhysicsServer2D.ShapeType.Segment"/>: a <see cref="Godot.Rect2"/> <c>rect</c> containing the first point of the segment in <c>rect.position</c> and the second point of the segment in <c>rect.size</c>,</para>
    /// <para>- <see cref="Godot.PhysicsServer2D.ShapeType.Circle"/>: a <see cref="float"/> <c>radius</c>,</para>
    /// <para>- <see cref="Godot.PhysicsServer2D.ShapeType.Rectangle"/>: a <see cref="Godot.Vector2"/> <c>half_extents</c>,</para>
    /// <para>- <see cref="Godot.PhysicsServer2D.ShapeType.Capsule"/>: an array of length two (or a <see cref="Godot.Vector2"/>) containing a <see cref="float"/> <c>height</c> and a <see cref="float"/> <c>radius</c>,</para>
    /// <para>- <see cref="Godot.PhysicsServer2D.ShapeType.ConvexPolygon"/>: either a <see cref="Godot.Vector2"/>[] of points defining a convex polygon in counterclockwise order (the clockwise outward normal of each segment formed by consecutive points is calculated internally), or a <see cref="float"/>[] of length divisible by four so that every 4-tuple of <see cref="float"/>s contains the coordinates of a point followed by the coordinates of the clockwise outward normal vector to the segment between the current point and the next point,</para>
    /// <para>- <see cref="Godot.PhysicsServer2D.ShapeType.ConcavePolygon"/>: a <see cref="Godot.Vector2"/>[] of length divisible by two (each pair of points forms one segment).</para>
    /// <para><b>Warning:</b> In the case of <see cref="Godot.PhysicsServer2D.ShapeType.ConvexPolygon"/>, this method does not check if the points supplied actually form a convex polygon (unlike the <see cref="Godot.CollisionPolygon2D.Polygon"/> property).</para>
    /// </summary>
    public void ShapeSetData(Rid shape, Variant data)
    {
        NativeCalls.godot_icall_2_422(MethodBind8, GodotObject.GetPtr(this), shape, data);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapeGetType, 1240598777ul);

    /// <summary>
    /// <para>Returns the shape's type.</para>
    /// </summary>
    public PhysicsServer2D.ShapeType ShapeGetType(Rid shape)
    {
        return (PhysicsServer2D.ShapeType)NativeCalls.godot_icall_1_835(MethodBind9, GodotObject.GetPtr(this), shape);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapeGetData, 4171304767ul);

    /// <summary>
    /// <para>Returns the shape data that defines the configuration of the shape, such as the half-extents of a rectangle or the segments of a concave shape. See <see cref="Godot.PhysicsServer2DInstance.ShapeSetData(Rid, Variant)"/> for the precise format of this data in each case.</para>
    /// </summary>
    public Variant ShapeGetData(Rid shape)
    {
        return NativeCalls.godot_icall_1_423(MethodBind10, GodotObject.GetPtr(this), shape);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SpaceCreate, 529393457ul);

    /// <summary>
    /// <para>Creates a 2D space in the physics server, and returns the <see cref="Godot.Rid"/> that identifies it. A space contains bodies and areas, and controls the stepping of the physics simulation of the objects in it.</para>
    /// </summary>
    public Rid SpaceCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind11, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SpaceSetActive, 1265174801ul);

    /// <summary>
    /// <para>Activates or deactivates the space. If <paramref name="active"/> is <see langword="false"/>, then the physics server will not do anything with this space in its physics step.</para>
    /// </summary>
    public void SpaceSetActive(Rid space, bool active)
    {
        NativeCalls.godot_icall_2_434(MethodBind12, GodotObject.GetPtr(this), space, active.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SpaceIsActive, 4155700596ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the space is active.</para>
    /// </summary>
    public bool SpaceIsActive(Rid space)
    {
        return NativeCalls.godot_icall_1_421(MethodBind13, GodotObject.GetPtr(this), space).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SpaceSetParam, 949194586ul);

    /// <summary>
    /// <para>Sets the value of the given space parameter.</para>
    /// </summary>
    public void SpaceSetParam(Rid space, PhysicsServer2D.SpaceParameter param, float value)
    {
        NativeCalls.godot_icall_3_988(MethodBind14, GodotObject.GetPtr(this), space, (int)param, value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SpaceGetParam, 874111783ul);

    /// <summary>
    /// <para>Returns the value of the given space parameter.</para>
    /// </summary>
    public float SpaceGetParam(Rid space, PhysicsServer2D.SpaceParameter param)
    {
        return NativeCalls.godot_icall_2_989(MethodBind15, GodotObject.GetPtr(this), space, (int)param);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SpaceGetDirectState, 3160173886ul);

    /// <summary>
    /// <para>Returns the state of a space, a <see cref="Godot.PhysicsDirectSpaceState2D"/>. This object can be used for collision/intersection queries.</para>
    /// </summary>
    public PhysicsDirectSpaceState2D SpaceGetDirectState(Rid space)
    {
        return (PhysicsDirectSpaceState2D)NativeCalls.godot_icall_1_938(MethodBind16, GodotObject.GetPtr(this), space);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AreaCreate, 529393457ul);

    /// <summary>
    /// <para>Creates a 2D area object in the physics server, and returns the <see cref="Godot.Rid"/> that identifies it. The default settings for the created area include a collision layer and mask set to <c>1</c>, and <c>monitorable</c> set to <see langword="false"/>.</para>
    /// <para>Use <see cref="Godot.PhysicsServer2DInstance.AreaAddShape(Rid, Rid, Nullable{Transform2D}, bool)"/> to add shapes to it, use <see cref="Godot.PhysicsServer2DInstance.AreaSetTransform(Rid, Transform2D)"/> to set its transform, and use <see cref="Godot.PhysicsServer2DInstance.AreaSetSpace(Rid, Rid)"/> to add the area to a space. If you want the area to be detectable use <see cref="Godot.PhysicsServer2DInstance.AreaSetMonitorable(Rid, bool)"/>.</para>
    /// </summary>
    public Rid AreaCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind17, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AreaSetSpace, 395945892ul);

    /// <summary>
    /// <para>Adds the area to the given space, after removing the area from the previously assigned space (if any).</para>
    /// <para><b>Note:</b> To remove an area from a space without immediately adding it back elsewhere, use <c>PhysicsServer2D.area_set_space(area, RID())</c>.</para>
    /// </summary>
    public void AreaSetSpace(Rid area, Rid space)
    {
        NativeCalls.godot_icall_2_430(MethodBind18, GodotObject.GetPtr(this), area, space);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AreaGetSpace, 3814569979ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.Rid"/> of the space assigned to the area. Returns an empty <see cref="Godot.Rid"/> if no space is assigned.</para>
    /// </summary>
    public Rid AreaGetSpace(Rid area)
    {
        return NativeCalls.godot_icall_1_855(MethodBind19, GodotObject.GetPtr(this), area);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AreaAddShape, 339056240ul);

    /// <summary>
    /// <para>Adds a shape to the area, with the given local transform. The shape (together with its <paramref name="transform"/> and <paramref name="disabled"/> properties) is added to an array of shapes, and the shapes of an area are usually referenced by their index in this array.</para>
    /// </summary>
    /// <param name="transform">If the parameter is null, then the default value is <c>Transform2D.Identity</c>.</param>
    public unsafe void AreaAddShape(Rid area, Rid shape, Nullable<Transform2D> transform = null, bool disabled = false)
    {
        Transform2D transformOrDefVal = transform.HasValue ? transform.Value : Transform2D.Identity;
        NativeCalls.godot_icall_4_990(MethodBind20, GodotObject.GetPtr(this), area, shape, &transformOrDefVal, disabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AreaSetShape, 2310537182ul);

    /// <summary>
    /// <para>Replaces the area's shape at the given index by another shape, while not affecting the <c>transform</c> and <c>disabled</c> properties at the same index.</para>
    /// </summary>
    public void AreaSetShape(Rid area, int shapeIdx, Rid shape)
    {
        NativeCalls.godot_icall_3_833(MethodBind21, GodotObject.GetPtr(this), area, shapeIdx, shape);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AreaSetShapeTransform, 736082694ul);

    /// <summary>
    /// <para>Sets the local transform matrix of the area's shape with the given index.</para>
    /// </summary>
    public unsafe void AreaSetShapeTransform(Rid area, int shapeIdx, Transform2D transform)
    {
        NativeCalls.godot_icall_3_991(MethodBind22, GodotObject.GetPtr(this), area, shapeIdx, &transform);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AreaSetShapeDisabled, 2658558584ul);

    /// <summary>
    /// <para>Sets the disabled property of the area's shape with the given index. If <paramref name="disabled"/> is <see langword="true"/>, then the shape will not detect any other shapes entering or exiting it.</para>
    /// </summary>
    public void AreaSetShapeDisabled(Rid area, int shapeIdx, bool disabled)
    {
        NativeCalls.godot_icall_3_439(MethodBind23, GodotObject.GetPtr(this), area, shapeIdx, disabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AreaGetShapeCount, 2198884583ul);

    /// <summary>
    /// <para>Returns the number of shapes added to the area.</para>
    /// </summary>
    public int AreaGetShapeCount(Rid area)
    {
        return NativeCalls.godot_icall_1_835(MethodBind24, GodotObject.GetPtr(this), area);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AreaGetShape, 1066463050ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.Rid"/> of the shape with the given index in the area's array of shapes.</para>
    /// </summary>
    public Rid AreaGetShape(Rid area, int shapeIdx)
    {
        return NativeCalls.godot_icall_2_830(MethodBind25, GodotObject.GetPtr(this), area, shapeIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AreaGetShapeTransform, 1324854622ul);

    /// <summary>
    /// <para>Returns the local transform matrix of the shape with the given index in the area's array of shapes.</para>
    /// </summary>
    public Transform2D AreaGetShapeTransform(Rid area, int shapeIdx)
    {
        return NativeCalls.godot_icall_2_992(MethodBind26, GodotObject.GetPtr(this), area, shapeIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AreaRemoveShape, 3411492887ul);

    /// <summary>
    /// <para>Removes the shape with the given index from the area's array of shapes. The shape itself is not deleted, so it can continue to be used elsewhere or added back later. As a result of this operation, the area's shapes which used to have indices higher than <paramref name="shapeIdx"/> will have their index decreased by one.</para>
    /// </summary>
    public void AreaRemoveShape(Rid area, int shapeIdx)
    {
        NativeCalls.godot_icall_2_426(MethodBind27, GodotObject.GetPtr(this), area, shapeIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AreaClearShapes, 2722037293ul);

    /// <summary>
    /// <para>Removes all shapes from the area. This does not delete the shapes themselves, so they can continue to be used elsewhere or added back later.</para>
    /// </summary>
    public void AreaClearShapes(Rid area)
    {
        NativeCalls.godot_icall_1_286(MethodBind28, GodotObject.GetPtr(this), area);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AreaSetCollisionLayer, 3411492887ul);

    /// <summary>
    /// <para>Assigns the area to one or many physics layers, via a bitmask.</para>
    /// </summary>
    public void AreaSetCollisionLayer(Rid area, uint layer)
    {
        NativeCalls.godot_icall_2_856(MethodBind29, GodotObject.GetPtr(this), area, layer);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AreaGetCollisionLayer, 2198884583ul);

    /// <summary>
    /// <para>Returns the physics layer or layers the area belongs to, as a bitmask.</para>
    /// </summary>
    public uint AreaGetCollisionLayer(Rid area)
    {
        return NativeCalls.godot_icall_1_850(MethodBind30, GodotObject.GetPtr(this), area);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AreaSetCollisionMask, 3411492887ul);

    /// <summary>
    /// <para>Sets which physics layers the area will monitor, via a bitmask.</para>
    /// </summary>
    public void AreaSetCollisionMask(Rid area, uint mask)
    {
        NativeCalls.godot_icall_2_856(MethodBind31, GodotObject.GetPtr(this), area, mask);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind32 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AreaGetCollisionMask, 2198884583ul);

    /// <summary>
    /// <para>Returns the physics layer or layers the area can contact with, as a bitmask.</para>
    /// </summary>
    public uint AreaGetCollisionMask(Rid area)
    {
        return NativeCalls.godot_icall_1_850(MethodBind32, GodotObject.GetPtr(this), area);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind33 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AreaSetParam, 1257146028ul);

    /// <summary>
    /// <para>Sets the value of the given area parameter.</para>
    /// </summary>
    public void AreaSetParam(Rid area, PhysicsServer2D.AreaParameter param, Variant value)
    {
        NativeCalls.godot_icall_3_832(MethodBind33, GodotObject.GetPtr(this), area, (int)param, value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind34 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AreaSetTransform, 1246044741ul);

    /// <summary>
    /// <para>Sets the transform matrix of the area.</para>
    /// </summary>
    public unsafe void AreaSetTransform(Rid area, Transform2D transform)
    {
        NativeCalls.godot_icall_2_429(MethodBind34, GodotObject.GetPtr(this), area, &transform);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind35 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AreaGetParam, 3047435120ul);

    /// <summary>
    /// <para>Returns the value of the given area parameter.</para>
    /// </summary>
    public Variant AreaGetParam(Rid area, PhysicsServer2D.AreaParameter param)
    {
        return NativeCalls.godot_icall_2_828(MethodBind35, GodotObject.GetPtr(this), area, (int)param);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind36 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AreaGetTransform, 213527486ul);

    /// <summary>
    /// <para>Returns the transform matrix of the area.</para>
    /// </summary>
    public Transform2D AreaGetTransform(Rid area)
    {
        return NativeCalls.godot_icall_1_857(MethodBind36, GodotObject.GetPtr(this), area);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind37 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AreaAttachObjectInstanceId, 3411492887ul);

    /// <summary>
    /// <para>Attaches the <c>ObjectID</c> of an <see cref="Godot.GodotObject"/> to the area. Use <see cref="Godot.GodotObject.GetInstanceId()"/> to get the <c>ObjectID</c> of a <see cref="Godot.CollisionObject2D"/>.</para>
    /// </summary>
    public void AreaAttachObjectInstanceId(Rid area, ulong id)
    {
        NativeCalls.godot_icall_2_852(MethodBind37, GodotObject.GetPtr(this), area, id);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind38 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AreaGetObjectInstanceId, 2198884583ul);

    /// <summary>
    /// <para>Returns the <c>ObjectID</c> attached to the area. Use <c>@GlobalScope.instance_from_id</c> to retrieve an <see cref="Godot.GodotObject"/> from a nonzero <c>ObjectID</c>.</para>
    /// </summary>
    public ulong AreaGetObjectInstanceId(Rid area)
    {
        return NativeCalls.godot_icall_1_853(MethodBind38, GodotObject.GetPtr(this), area);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind39 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AreaAttachCanvasInstanceId, 3411492887ul);

    /// <summary>
    /// <para>Attaches the <c>ObjectID</c> of a canvas to the area. Use <see cref="Godot.GodotObject.GetInstanceId()"/> to get the <c>ObjectID</c> of a <see cref="Godot.CanvasLayer"/>.</para>
    /// </summary>
    public void AreaAttachCanvasInstanceId(Rid area, ulong id)
    {
        NativeCalls.godot_icall_2_852(MethodBind39, GodotObject.GetPtr(this), area, id);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind40 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AreaGetCanvasInstanceId, 2198884583ul);

    /// <summary>
    /// <para>Returns the <c>ObjectID</c> of the canvas attached to the area. Use <c>@GlobalScope.instance_from_id</c> to retrieve a <see cref="Godot.CanvasLayer"/> from a nonzero <c>ObjectID</c>.</para>
    /// </summary>
    public ulong AreaGetCanvasInstanceId(Rid area)
    {
        return NativeCalls.godot_icall_1_853(MethodBind40, GodotObject.GetPtr(this), area);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind41 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AreaSetMonitorCallback, 3379118538ul);

    /// <summary>
    /// <para>Sets the area's body monitor callback. This callback will be called when any other (shape of a) body enters or exits (a shape of) the given area, and must take the following five parameters:</para>
    /// <para>1. an integer <c>status</c>: either <see cref="Godot.PhysicsServer2D.AreaBodyStatus.Added"/> or <see cref="Godot.PhysicsServer2D.AreaBodyStatus.Removed"/> depending on whether the other body shape entered or exited the area,</para>
    /// <para>2. an <see cref="Godot.Rid"/> <c>body_rid</c>: the <see cref="Godot.Rid"/> of the body that entered or exited the area,</para>
    /// <para>3. an integer <c>instance_id</c>: the <c>ObjectID</c> attached to the body,</para>
    /// <para>4. an integer <c>body_shape_idx</c>: the index of the shape of the body that entered or exited the area,</para>
    /// <para>5. an integer <c>self_shape_idx</c>: the index of the shape of the area where the body entered or exited.</para>
    /// <para>By counting (or keeping track of) the shapes that enter and exit, it can be determined if a body (with all its shapes) is entering for the first time or exiting for the last time.</para>
    /// </summary>
    public void AreaSetMonitorCallback(Rid area, Callable callback)
    {
        NativeCalls.godot_icall_2_814(MethodBind41, GodotObject.GetPtr(this), area, callback);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind42 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AreaSetAreaMonitorCallback, 3379118538ul);

    /// <summary>
    /// <para>Sets the area's area monitor callback. This callback will be called when any other (shape of an) area enters or exits (a shape of) the given area, and must take the following five parameters:</para>
    /// <para>1. an integer <c>status</c>: either <see cref="Godot.PhysicsServer2D.AreaBodyStatus.Added"/> or <see cref="Godot.PhysicsServer2D.AreaBodyStatus.Removed"/> depending on whether the other area's shape entered or exited the area,</para>
    /// <para>2. an <see cref="Godot.Rid"/> <c>area_rid</c>: the <see cref="Godot.Rid"/> of the other area that entered or exited the area,</para>
    /// <para>3. an integer <c>instance_id</c>: the <c>ObjectID</c> attached to the other area,</para>
    /// <para>4. an integer <c>area_shape_idx</c>: the index of the shape of the other area that entered or exited the area,</para>
    /// <para>5. an integer <c>self_shape_idx</c>: the index of the shape of the area where the other area entered or exited.</para>
    /// <para>By counting (or keeping track of) the shapes that enter and exit, it can be determined if an area (with all its shapes) is entering for the first time or exiting for the last time.</para>
    /// </summary>
    public void AreaSetAreaMonitorCallback(Rid area, Callable callback)
    {
        NativeCalls.godot_icall_2_814(MethodBind42, GodotObject.GetPtr(this), area, callback);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind43 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AreaSetMonitorable, 1265174801ul);

    /// <summary>
    /// <para>Sets whether the area is monitorable or not. If <paramref name="monitorable"/> is <see langword="true"/>, the area monitoring callback of other areas will be called when this area enters or exits them.</para>
    /// </summary>
    public void AreaSetMonitorable(Rid area, bool monitorable)
    {
        NativeCalls.godot_icall_2_434(MethodBind43, GodotObject.GetPtr(this), area, monitorable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind44 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyCreate, 529393457ul);

    /// <summary>
    /// <para>Creates a 2D body object in the physics server, and returns the <see cref="Godot.Rid"/> that identifies it. The default settings for the created area include a collision layer and mask set to <c>1</c>, and body mode set to <see cref="Godot.PhysicsServer2D.BodyMode.Rigid"/>.</para>
    /// <para>Use <see cref="Godot.PhysicsServer2DInstance.BodyAddShape(Rid, Rid, Nullable{Transform2D}, bool)"/> to add shapes to it, use <see cref="Godot.PhysicsServer2DInstance.BodySetState(Rid, PhysicsServer2D.BodyState, Variant)"/> to set its transform, and use <see cref="Godot.PhysicsServer2DInstance.BodySetSpace(Rid, Rid)"/> to add the body to a space.</para>
    /// </summary>
    public Rid BodyCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind44, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind45 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodySetSpace, 395945892ul);

    /// <summary>
    /// <para>Adds the body to the given space, after removing the body from the previously assigned space (if any). If the body's mode is set to <see cref="Godot.PhysicsServer2D.BodyMode.Rigid"/>, then adding the body to a space will have the following additional effects:</para>
    /// <para>- If the parameter <see cref="Godot.PhysicsServer2D.BodyParameter.CenterOfMass"/> has never been set explicitly, then the value of that parameter will be recalculated based on the body's shapes.</para>
    /// <para>- If the parameter <see cref="Godot.PhysicsServer2D.BodyParameter.Inertia"/> is set to a value <c>&lt;= 0.0</c>, then the value of that parameter will be recalculated based on the body's shapes, mass, and center of mass.</para>
    /// <para><b>Note:</b> To remove a body from a space without immediately adding it back elsewhere, use <c>PhysicsServer2D.body_set_space(body, RID())</c>.</para>
    /// </summary>
    public void BodySetSpace(Rid body, Rid space)
    {
        NativeCalls.godot_icall_2_430(MethodBind45, GodotObject.GetPtr(this), body, space);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind46 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyGetSpace, 3814569979ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.Rid"/> of the space assigned to the body. Returns an empty <see cref="Godot.Rid"/> if no space is assigned.</para>
    /// </summary>
    public Rid BodyGetSpace(Rid body)
    {
        return NativeCalls.godot_icall_1_855(MethodBind46, GodotObject.GetPtr(this), body);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind47 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodySetMode, 1658067650ul);

    /// <summary>
    /// <para>Sets the body's mode.</para>
    /// </summary>
    public void BodySetMode(Rid body, PhysicsServer2D.BodyMode mode)
    {
        NativeCalls.godot_icall_2_426(MethodBind47, GodotObject.GetPtr(this), body, (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind48 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyGetMode, 3261702585ul);

    /// <summary>
    /// <para>Returns the body's mode.</para>
    /// </summary>
    public PhysicsServer2D.BodyMode BodyGetMode(Rid body)
    {
        return (PhysicsServer2D.BodyMode)NativeCalls.godot_icall_1_835(MethodBind48, GodotObject.GetPtr(this), body);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind49 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyAddShape, 339056240ul);

    /// <summary>
    /// <para>Adds a shape to the area, with the given local transform. The shape (together with its <paramref name="transform"/> and <paramref name="disabled"/> properties) is added to an array of shapes, and the shapes of a body are usually referenced by their index in this array.</para>
    /// </summary>
    /// <param name="transform">If the parameter is null, then the default value is <c>Transform2D.Identity</c>.</param>
    public unsafe void BodyAddShape(Rid body, Rid shape, Nullable<Transform2D> transform = null, bool disabled = false)
    {
        Transform2D transformOrDefVal = transform.HasValue ? transform.Value : Transform2D.Identity;
        NativeCalls.godot_icall_4_990(MethodBind49, GodotObject.GetPtr(this), body, shape, &transformOrDefVal, disabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind50 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodySetShape, 2310537182ul);

    /// <summary>
    /// <para>Replaces the body's shape at the given index by another shape, while not affecting the <c>transform</c>, <c>disabled</c>, and one-way collision properties at the same index.</para>
    /// </summary>
    public void BodySetShape(Rid body, int shapeIdx, Rid shape)
    {
        NativeCalls.godot_icall_3_833(MethodBind50, GodotObject.GetPtr(this), body, shapeIdx, shape);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind51 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodySetShapeTransform, 736082694ul);

    /// <summary>
    /// <para>Sets the local transform matrix of the body's shape with the given index.</para>
    /// </summary>
    public unsafe void BodySetShapeTransform(Rid body, int shapeIdx, Transform2D transform)
    {
        NativeCalls.godot_icall_3_991(MethodBind51, GodotObject.GetPtr(this), body, shapeIdx, &transform);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind52 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyGetShapeCount, 2198884583ul);

    /// <summary>
    /// <para>Returns the number of shapes added to the body.</para>
    /// </summary>
    public int BodyGetShapeCount(Rid body)
    {
        return NativeCalls.godot_icall_1_835(MethodBind52, GodotObject.GetPtr(this), body);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind53 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyGetShape, 1066463050ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.Rid"/> of the shape with the given index in the body's array of shapes.</para>
    /// </summary>
    public Rid BodyGetShape(Rid body, int shapeIdx)
    {
        return NativeCalls.godot_icall_2_830(MethodBind53, GodotObject.GetPtr(this), body, shapeIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind54 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyGetShapeTransform, 1324854622ul);

    /// <summary>
    /// <para>Returns the local transform matrix of the shape with the given index in the area's array of shapes.</para>
    /// </summary>
    public Transform2D BodyGetShapeTransform(Rid body, int shapeIdx)
    {
        return NativeCalls.godot_icall_2_992(MethodBind54, GodotObject.GetPtr(this), body, shapeIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind55 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyRemoveShape, 3411492887ul);

    /// <summary>
    /// <para>Removes the shape with the given index from the body's array of shapes. The shape itself is not deleted, so it can continue to be used elsewhere or added back later. As a result of this operation, the body's shapes which used to have indices higher than <paramref name="shapeIdx"/> will have their index decreased by one.</para>
    /// </summary>
    public void BodyRemoveShape(Rid body, int shapeIdx)
    {
        NativeCalls.godot_icall_2_426(MethodBind55, GodotObject.GetPtr(this), body, shapeIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind56 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyClearShapes, 2722037293ul);

    /// <summary>
    /// <para>Removes all shapes from the body. This does not delete the shapes themselves, so they can continue to be used elsewhere or added back later.</para>
    /// </summary>
    public void BodyClearShapes(Rid body)
    {
        NativeCalls.godot_icall_1_286(MethodBind56, GodotObject.GetPtr(this), body);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind57 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodySetShapeDisabled, 2658558584ul);

    /// <summary>
    /// <para>Sets the disabled property of the body's shape with the given index. If <paramref name="disabled"/> is <see langword="true"/>, then the shape will be ignored in all collision detection.</para>
    /// </summary>
    public void BodySetShapeDisabled(Rid body, int shapeIdx, bool disabled)
    {
        NativeCalls.godot_icall_3_439(MethodBind57, GodotObject.GetPtr(this), body, shapeIdx, disabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind58 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodySetShapeAsOneWayCollision, 2556489974ul);

    /// <summary>
    /// <para>Sets the one-way collision properties of the body's shape with the given index. If <paramref name="enable"/> is <see langword="true"/>, the one-way collision direction given by the shape's local upward axis <c>body_get_shape_transform(body, shape_idx).y</c> will be used to ignore collisions with the shape in the opposite direction, and to ensure depenetration of kinematic bodies happens in this direction.</para>
    /// </summary>
    public void BodySetShapeAsOneWayCollision(Rid body, int shapeIdx, bool enable, float margin)
    {
        NativeCalls.godot_icall_4_993(MethodBind58, GodotObject.GetPtr(this), body, shapeIdx, enable.ToGodotBool(), margin);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind59 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyAttachObjectInstanceId, 3411492887ul);

    /// <summary>
    /// <para>Attaches the <c>ObjectID</c> of an <see cref="Godot.GodotObject"/> to the body. Use <see cref="Godot.GodotObject.GetInstanceId()"/> to get the <c>ObjectID</c> of a <see cref="Godot.CollisionObject2D"/>.</para>
    /// </summary>
    public void BodyAttachObjectInstanceId(Rid body, ulong id)
    {
        NativeCalls.godot_icall_2_852(MethodBind59, GodotObject.GetPtr(this), body, id);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind60 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyGetObjectInstanceId, 2198884583ul);

    /// <summary>
    /// <para>Returns the <c>ObjectID</c> attached to the body. Use <c>@GlobalScope.instance_from_id</c> to retrieve an <see cref="Godot.GodotObject"/> from a nonzero <c>ObjectID</c>.</para>
    /// </summary>
    public ulong BodyGetObjectInstanceId(Rid body)
    {
        return NativeCalls.godot_icall_1_853(MethodBind60, GodotObject.GetPtr(this), body);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind61 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyAttachCanvasInstanceId, 3411492887ul);

    /// <summary>
    /// <para>Attaches the <c>ObjectID</c> of a canvas to the body. Use <see cref="Godot.GodotObject.GetInstanceId()"/> to get the <c>ObjectID</c> of a <see cref="Godot.CanvasLayer"/>.</para>
    /// </summary>
    public void BodyAttachCanvasInstanceId(Rid body, ulong id)
    {
        NativeCalls.godot_icall_2_852(MethodBind61, GodotObject.GetPtr(this), body, id);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind62 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyGetCanvasInstanceId, 2198884583ul);

    /// <summary>
    /// <para>Returns the <c>ObjectID</c> of the canvas attached to the body. Use <c>@GlobalScope.instance_from_id</c> to retrieve a <see cref="Godot.CanvasLayer"/> from a nonzero <c>ObjectID</c>.</para>
    /// </summary>
    public ulong BodyGetCanvasInstanceId(Rid body)
    {
        return NativeCalls.godot_icall_1_853(MethodBind62, GodotObject.GetPtr(this), body);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind63 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodySetContinuousCollisionDetectionMode, 1882257015ul);

    /// <summary>
    /// <para>Sets the continuous collision detection mode.</para>
    /// <para>Continuous collision detection tries to predict where a moving body would collide in between physics updates, instead of moving it and correcting its movement if it collided.</para>
    /// </summary>
    public void BodySetContinuousCollisionDetectionMode(Rid body, PhysicsServer2D.CcdMode mode)
    {
        NativeCalls.godot_icall_2_426(MethodBind63, GodotObject.GetPtr(this), body, (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind64 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyGetContinuousCollisionDetectionMode, 2661282217ul);

    /// <summary>
    /// <para>Returns the body's continuous collision detection mode.</para>
    /// </summary>
    public PhysicsServer2D.CcdMode BodyGetContinuousCollisionDetectionMode(Rid body)
    {
        return (PhysicsServer2D.CcdMode)NativeCalls.godot_icall_1_835(MethodBind64, GodotObject.GetPtr(this), body);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind65 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodySetCollisionLayer, 3411492887ul);

    /// <summary>
    /// <para>Sets the physics layer or layers the body belongs to, via a bitmask.</para>
    /// </summary>
    public void BodySetCollisionLayer(Rid body, uint layer)
    {
        NativeCalls.godot_icall_2_856(MethodBind65, GodotObject.GetPtr(this), body, layer);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind66 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyGetCollisionLayer, 2198884583ul);

    /// <summary>
    /// <para>Returns the physics layer or layers the body belongs to, as a bitmask.</para>
    /// </summary>
    public uint BodyGetCollisionLayer(Rid body)
    {
        return NativeCalls.godot_icall_1_850(MethodBind66, GodotObject.GetPtr(this), body);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind67 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodySetCollisionMask, 3411492887ul);

    /// <summary>
    /// <para>Sets the physics layer or layers the body can collide with, via a bitmask.</para>
    /// </summary>
    public void BodySetCollisionMask(Rid body, uint mask)
    {
        NativeCalls.godot_icall_2_856(MethodBind67, GodotObject.GetPtr(this), body, mask);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind68 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyGetCollisionMask, 2198884583ul);

    /// <summary>
    /// <para>Returns the physics layer or layers the body can collide with, as a bitmask.</para>
    /// </summary>
    public uint BodyGetCollisionMask(Rid body)
    {
        return NativeCalls.godot_icall_1_850(MethodBind68, GodotObject.GetPtr(this), body);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind69 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodySetCollisionPriority, 1794382983ul);

    /// <summary>
    /// <para>Sets the body's collision priority. This is used in the depenetration phase of <see cref="Godot.PhysicsServer2DInstance.BodyTestMotion(Rid, PhysicsTestMotionParameters2D, PhysicsTestMotionResult2D)"/>. The higher the priority is, the lower the penetration into the body will be.</para>
    /// </summary>
    public void BodySetCollisionPriority(Rid body, float priority)
    {
        NativeCalls.godot_icall_2_816(MethodBind69, GodotObject.GetPtr(this), body, priority);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind70 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyGetCollisionPriority, 866169185ul);

    /// <summary>
    /// <para>Returns the body's collision priority. This is used in the depenetration phase of <see cref="Godot.PhysicsServer2DInstance.BodyTestMotion(Rid, PhysicsTestMotionParameters2D, PhysicsTestMotionResult2D)"/>. The higher the priority is, the lower the penetration into the body will be.</para>
    /// </summary>
    public float BodyGetCollisionPriority(Rid body)
    {
        return NativeCalls.godot_icall_1_817(MethodBind70, GodotObject.GetPtr(this), body);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind71 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodySetParam, 2715630609ul);

    /// <summary>
    /// <para>Sets the value of the given body parameter.</para>
    /// </summary>
    public void BodySetParam(Rid body, PhysicsServer2D.BodyParameter param, Variant value)
    {
        NativeCalls.godot_icall_3_832(MethodBind71, GodotObject.GetPtr(this), body, (int)param, value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind72 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyGetParam, 3208033526ul);

    /// <summary>
    /// <para>Returns the value of the given body parameter.</para>
    /// </summary>
    public Variant BodyGetParam(Rid body, PhysicsServer2D.BodyParameter param)
    {
        return NativeCalls.godot_icall_2_828(MethodBind72, GodotObject.GetPtr(this), body, (int)param);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind73 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyResetMassProperties, 2722037293ul);

    /// <summary>
    /// <para>Restores the default inertia and center of mass of the body based on its shapes. This undoes any custom values previously set using <see cref="Godot.PhysicsServer2DInstance.BodySetParam(Rid, PhysicsServer2D.BodyParameter, Variant)"/>.</para>
    /// </summary>
    public void BodyResetMassProperties(Rid body)
    {
        NativeCalls.godot_icall_1_286(MethodBind73, GodotObject.GetPtr(this), body);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind74 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodySetState, 1706355209ul);

    /// <summary>
    /// <para>Sets the value of a body's state.</para>
    /// <para><b>Note:</b> The state change doesn't take effect immediately. The state will change on the next physics frame.</para>
    /// </summary>
    public void BodySetState(Rid body, PhysicsServer2D.BodyState state, Variant value)
    {
        NativeCalls.godot_icall_3_832(MethodBind74, GodotObject.GetPtr(this), body, (int)state, value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind75 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyGetState, 4036367961ul);

    /// <summary>
    /// <para>Returns the value of the given state of the body.</para>
    /// </summary>
    public Variant BodyGetState(Rid body, PhysicsServer2D.BodyState state)
    {
        return NativeCalls.godot_icall_2_828(MethodBind75, GodotObject.GetPtr(this), body, (int)state);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind76 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyApplyCentralImpulse, 3201125042ul);

    /// <summary>
    /// <para>Applies a directional impulse to the body, at the body's center of mass. The impulse does not affect rotation.</para>
    /// <para>An impulse is time-independent! Applying an impulse every frame would result in a framerate-dependent force. For this reason, it should only be used when simulating one-time impacts (use the "_force" functions otherwise).</para>
    /// <para>This is equivalent to using <see cref="Godot.PhysicsServer2DInstance.BodyApplyImpulse(Rid, Vector2, Nullable{Vector2})"/> at the body's center of mass.</para>
    /// </summary>
    public unsafe void BodyApplyCentralImpulse(Rid body, Vector2 impulse)
    {
        NativeCalls.godot_icall_2_861(MethodBind76, GodotObject.GetPtr(this), body, &impulse);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind77 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyApplyTorqueImpulse, 1794382983ul);

    /// <summary>
    /// <para>Applies a rotational impulse to the body. The impulse does not affect position.</para>
    /// <para>An impulse is time-independent! Applying an impulse every frame would result in a framerate-dependent force. For this reason, it should only be used when simulating one-time impacts (use the "_force" functions otherwise).</para>
    /// </summary>
    public void BodyApplyTorqueImpulse(Rid body, float impulse)
    {
        NativeCalls.godot_icall_2_816(MethodBind77, GodotObject.GetPtr(this), body, impulse);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind78 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyApplyImpulse, 205485391ul);

    /// <summary>
    /// <para>Applies a positioned impulse to the body. The impulse can affect rotation if <paramref name="position"/> is different from the body's center of mass.</para>
    /// <para>An impulse is time-independent! Applying an impulse every frame would result in a framerate-dependent force. For this reason, it should only be used when simulating one-time impacts (use the "_force" functions otherwise).</para>
    /// <para><paramref name="position"/> is the offset from the body origin in global coordinates.</para>
    /// </summary>
    /// <param name="position">If the parameter is null, then the default value is <c>new Vector2(0.0f, 0.0f)</c>.</param>
    public unsafe void BodyApplyImpulse(Rid body, Vector2 impulse, Nullable<Vector2> position = null)
    {
        Vector2 positionOrDefVal = position.HasValue ? position.Value : new Vector2(0.0f, 0.0f);
        NativeCalls.godot_icall_3_994(MethodBind78, GodotObject.GetPtr(this), body, &impulse, &positionOrDefVal);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind79 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyApplyCentralForce, 3201125042ul);

    /// <summary>
    /// <para>Applies a directional force to the body, at the body's center of mass. The force does not affect rotation. A force is time dependent and meant to be applied every physics update.</para>
    /// <para>This is equivalent to using <see cref="Godot.PhysicsServer2DInstance.BodyApplyForce(Rid, Vector2, Nullable{Vector2})"/> at the body's center of mass.</para>
    /// </summary>
    public unsafe void BodyApplyCentralForce(Rid body, Vector2 force)
    {
        NativeCalls.godot_icall_2_861(MethodBind79, GodotObject.GetPtr(this), body, &force);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind80 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyApplyForce, 205485391ul);

    /// <summary>
    /// <para>Applies a positioned force to the body. The force can affect rotation if <paramref name="position"/> is different from the body's center of mass. A force is time dependent and meant to be applied every physics update.</para>
    /// <para><paramref name="position"/> is the offset from the body origin in global coordinates.</para>
    /// </summary>
    /// <param name="position">If the parameter is null, then the default value is <c>new Vector2(0.0f, 0.0f)</c>.</param>
    public unsafe void BodyApplyForce(Rid body, Vector2 force, Nullable<Vector2> position = null)
    {
        Vector2 positionOrDefVal = position.HasValue ? position.Value : new Vector2(0.0f, 0.0f);
        NativeCalls.godot_icall_3_994(MethodBind80, GodotObject.GetPtr(this), body, &force, &positionOrDefVal);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind81 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyApplyTorque, 1794382983ul);

    /// <summary>
    /// <para>Applies a rotational force to the body. The force does not affect position. A force is time dependent and meant to be applied every physics update.</para>
    /// </summary>
    public void BodyApplyTorque(Rid body, float torque)
    {
        NativeCalls.godot_icall_2_816(MethodBind81, GodotObject.GetPtr(this), body, torque);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind82 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyAddConstantCentralForce, 3201125042ul);

    /// <summary>
    /// <para>Adds a constant directional force to the body. The force does not affect rotation. The force remains applied over time until cleared with <c>PhysicsServer2D.body_set_constant_force(body, Vector2(0, 0))</c>.</para>
    /// <para>This is equivalent to using <see cref="Godot.PhysicsServer2DInstance.BodyAddConstantForce(Rid, Vector2, Nullable{Vector2})"/> at the body's center of mass.</para>
    /// </summary>
    public unsafe void BodyAddConstantCentralForce(Rid body, Vector2 force)
    {
        NativeCalls.godot_icall_2_861(MethodBind82, GodotObject.GetPtr(this), body, &force);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind83 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyAddConstantForce, 205485391ul);

    /// <summary>
    /// <para>Adds a constant positioned force to the body. The force can affect rotation if <paramref name="position"/> is different from the body's center of mass. The force remains applied over time until cleared with <c>PhysicsServer2D.body_set_constant_force(body, Vector2(0, 0))</c>.</para>
    /// <para><paramref name="position"/> is the offset from the body origin in global coordinates.</para>
    /// </summary>
    /// <param name="position">If the parameter is null, then the default value is <c>new Vector2(0.0f, 0.0f)</c>.</param>
    public unsafe void BodyAddConstantForce(Rid body, Vector2 force, Nullable<Vector2> position = null)
    {
        Vector2 positionOrDefVal = position.HasValue ? position.Value : new Vector2(0.0f, 0.0f);
        NativeCalls.godot_icall_3_994(MethodBind83, GodotObject.GetPtr(this), body, &force, &positionOrDefVal);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind84 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyAddConstantTorque, 1794382983ul);

    /// <summary>
    /// <para>Adds a constant rotational force to the body. The force does not affect position. The force remains applied over time until cleared with <c>PhysicsServer2D.body_set_constant_torque(body, 0)</c>.</para>
    /// </summary>
    public void BodyAddConstantTorque(Rid body, float torque)
    {
        NativeCalls.godot_icall_2_816(MethodBind84, GodotObject.GetPtr(this), body, torque);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind85 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodySetConstantForce, 3201125042ul);

    /// <summary>
    /// <para>Sets the body's total constant positional force applied during each physics update.</para>
    /// <para>See <see cref="Godot.PhysicsServer2DInstance.BodyAddConstantForce(Rid, Vector2, Nullable{Vector2})"/> and <see cref="Godot.PhysicsServer2DInstance.BodyAddConstantCentralForce(Rid, Vector2)"/>.</para>
    /// </summary>
    public unsafe void BodySetConstantForce(Rid body, Vector2 force)
    {
        NativeCalls.godot_icall_2_861(MethodBind85, GodotObject.GetPtr(this), body, &force);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind86 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyGetConstantForce, 2440833711ul);

    /// <summary>
    /// <para>Returns the body's total constant positional force applied during each physics update.</para>
    /// <para>See <see cref="Godot.PhysicsServer2DInstance.BodyAddConstantForce(Rid, Vector2, Nullable{Vector2})"/> and <see cref="Godot.PhysicsServer2DInstance.BodyAddConstantCentralForce(Rid, Vector2)"/>.</para>
    /// </summary>
    public Vector2 BodyGetConstantForce(Rid body)
    {
        return NativeCalls.godot_icall_1_812(MethodBind86, GodotObject.GetPtr(this), body);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind87 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodySetConstantTorque, 1794382983ul);

    /// <summary>
    /// <para>Sets the body's total constant rotational force applied during each physics update.</para>
    /// <para>See <see cref="Godot.PhysicsServer2DInstance.BodyAddConstantTorque(Rid, float)"/>.</para>
    /// </summary>
    public void BodySetConstantTorque(Rid body, float torque)
    {
        NativeCalls.godot_icall_2_816(MethodBind87, GodotObject.GetPtr(this), body, torque);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind88 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyGetConstantTorque, 866169185ul);

    /// <summary>
    /// <para>Returns the body's total constant rotational force applied during each physics update.</para>
    /// <para>See <see cref="Godot.PhysicsServer2DInstance.BodyAddConstantTorque(Rid, float)"/>.</para>
    /// </summary>
    public float BodyGetConstantTorque(Rid body)
    {
        return NativeCalls.godot_icall_1_817(MethodBind88, GodotObject.GetPtr(this), body);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind89 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodySetAxisVelocity, 3201125042ul);

    /// <summary>
    /// <para>Modifies the body's linear velocity so that its projection to the axis <c>axis_velocity.normalized()</c> is exactly <c>axis_velocity.length()</c>. This is useful for jumping behavior.</para>
    /// </summary>
    public unsafe void BodySetAxisVelocity(Rid body, Vector2 axisVelocity)
    {
        NativeCalls.godot_icall_2_861(MethodBind89, GodotObject.GetPtr(this), body, &axisVelocity);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind90 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyAddCollisionException, 395945892ul);

    /// <summary>
    /// <para>Adds <paramref name="exceptedBody"/> to the body's list of collision exceptions, so that collisions with it are ignored.</para>
    /// </summary>
    public void BodyAddCollisionException(Rid body, Rid exceptedBody)
    {
        NativeCalls.godot_icall_2_430(MethodBind90, GodotObject.GetPtr(this), body, exceptedBody);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind91 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyRemoveCollisionException, 395945892ul);

    /// <summary>
    /// <para>Removes <paramref name="exceptedBody"/> from the body's list of collision exceptions, so that collisions with it are no longer ignored.</para>
    /// </summary>
    public void BodyRemoveCollisionException(Rid body, Rid exceptedBody)
    {
        NativeCalls.godot_icall_2_430(MethodBind91, GodotObject.GetPtr(this), body, exceptedBody);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind92 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodySetMaxContactsReported, 3411492887ul);

    /// <summary>
    /// <para>Sets the maximum number of contacts that the body can report. If <paramref name="amount"/> is greater than zero, then the body will keep track of at most this many contacts with other bodies.</para>
    /// </summary>
    public void BodySetMaxContactsReported(Rid body, int amount)
    {
        NativeCalls.godot_icall_2_426(MethodBind92, GodotObject.GetPtr(this), body, amount);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind93 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyGetMaxContactsReported, 2198884583ul);

    /// <summary>
    /// <para>Returns the maximum number of contacts that the body can report. See <see cref="Godot.PhysicsServer2DInstance.BodySetMaxContactsReported(Rid, int)"/>.</para>
    /// </summary>
    public int BodyGetMaxContactsReported(Rid body)
    {
        return NativeCalls.godot_icall_1_835(MethodBind93, GodotObject.GetPtr(this), body);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind94 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodySetOmitForceIntegration, 1265174801ul);

    /// <summary>
    /// <para>Sets whether the body omits the standard force integration. If <paramref name="enable"/> is <see langword="true"/>, the body will not automatically use applied forces, torques, and damping to update the body's linear and angular velocity. In this case, <see cref="Godot.PhysicsServer2DInstance.BodySetForceIntegrationCallback(Rid, Callable, Variant)"/> can be used to manually update the linear and angular velocity instead.</para>
    /// <para>This method is called when the property <see cref="Godot.RigidBody2D.CustomIntegrator"/> is set.</para>
    /// </summary>
    public void BodySetOmitForceIntegration(Rid body, bool enable)
    {
        NativeCalls.godot_icall_2_434(MethodBind94, GodotObject.GetPtr(this), body, enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind95 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyIsOmittingForceIntegration, 4155700596ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the body is omitting the standard force integration. See <see cref="Godot.PhysicsServer2DInstance.BodySetOmitForceIntegration(Rid, bool)"/>.</para>
    /// </summary>
    public bool BodyIsOmittingForceIntegration(Rid body)
    {
        return NativeCalls.godot_icall_1_421(MethodBind95, GodotObject.GetPtr(this), body).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind96 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodySetStateSyncCallback, 3379118538ul);

    /// <summary>
    /// <para>Sets the body's state synchronization callback function to <paramref name="callable"/>. Use an empty <see cref="Godot.Callable"/> (<c>Callable()</c>) to clear the callback.</para>
    /// <para>The function <paramref name="callable"/> will be called every physics frame, assuming that the body was active during the previous physics tick, and can be used to fetch the latest state from the physics server.</para>
    /// <para>The function <paramref name="callable"/> must take the following parameters:</para>
    /// <para>1. <c>state</c>: a <see cref="Godot.PhysicsDirectBodyState2D"/>, used to retrieve the body's state.</para>
    /// </summary>
    public void BodySetStateSyncCallback(Rid body, Callable callable)
    {
        NativeCalls.godot_icall_2_814(MethodBind96, GodotObject.GetPtr(this), body, callable);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind97 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodySetForceIntegrationCallback, 3059434249ul);

    /// <summary>
    /// <para>Sets the body's custom force integration callback function to <paramref name="callable"/>. Use an empty <see cref="Godot.Callable"/> (<c>Callable()</c>) to clear the custom callback.</para>
    /// <para>The function <paramref name="callable"/> will be called every physics tick, before the standard force integration (see <see cref="Godot.PhysicsServer2DInstance.BodySetOmitForceIntegration(Rid, bool)"/>). It can be used for example to update the body's linear and angular velocity based on contact with other bodies.</para>
    /// <para>If <paramref name="userdata"/> is not <see langword="null"/>, the function <paramref name="callable"/> must take the following two parameters:</para>
    /// <para>1. <c>state</c>: a <see cref="Godot.PhysicsDirectBodyState2D"/> used to retrieve and modify the body's state,</para>
    /// <para>2. <c>userdata</c>: a <see cref="Godot.Variant"/>; its value will be the <paramref name="userdata"/> passed into this method.</para>
    /// <para>If <paramref name="userdata"/> is <see langword="null"/>, then <paramref name="callable"/> must take only the <c>state</c> parameter.</para>
    /// </summary>
    public void BodySetForceIntegrationCallback(Rid body, Callable callable, Variant userdata = default)
    {
        NativeCalls.godot_icall_3_995(MethodBind97, GodotObject.GetPtr(this), body, callable, userdata);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind98 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyTestMotion, 1699844009ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if a collision would result from moving the body along a motion vector from a given point in space. See <see cref="Godot.PhysicsTestMotionParameters2D"/> for the available motion parameters. Optionally a <see cref="Godot.PhysicsTestMotionResult2D"/> object can be passed, which will be used to store the information about the resulting collision.</para>
    /// </summary>
    public bool BodyTestMotion(Rid body, PhysicsTestMotionParameters2D parameters, PhysicsTestMotionResult2D result = default)
    {
        return NativeCalls.godot_icall_3_996(MethodBind98, GodotObject.GetPtr(this), body, GodotObject.GetPtr(parameters), GodotObject.GetPtr(result)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind99 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyGetDirectState, 1191931871ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.PhysicsDirectBodyState2D"/> of the body. Returns <see langword="null"/> if the body is destroyed or not assigned to a space.</para>
    /// </summary>
    public PhysicsDirectBodyState2D BodyGetDirectState(Rid body)
    {
        return (PhysicsDirectBodyState2D)NativeCalls.godot_icall_1_938(MethodBind99, GodotObject.GetPtr(this), body);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind100 = ClassDB_get_method_with_compatibility(NativeName, MethodName.JointCreate, 529393457ul);

    /// <summary>
    /// <para>Creates a 2D joint in the physics server, and returns the <see cref="Godot.Rid"/> that identifies it. To set the joint type, use <see cref="Godot.PhysicsServer2DInstance.JointMakeDampedSpring(Rid, Vector2, Vector2, Rid, Rid)"/>, <see cref="Godot.PhysicsServer2DInstance.JointMakeGroove(Rid, Vector2, Vector2, Vector2, Rid, Rid)"/> or <see cref="Godot.PhysicsServer2DInstance.JointMakePin(Rid, Vector2, Rid, Rid)"/>. Use <see cref="Godot.PhysicsServer2DInstance.JointSetParam(Rid, PhysicsServer2D.JointParam, float)"/> to set generic joint parameters.</para>
    /// </summary>
    public Rid JointCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind100, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind101 = ClassDB_get_method_with_compatibility(NativeName, MethodName.JointClear, 2722037293ul);

    /// <summary>
    /// <para>Destroys the joint with the given <see cref="Godot.Rid"/>, creates a new uninitialized joint, and makes the <see cref="Godot.Rid"/> refer to this new joint.</para>
    /// </summary>
    public void JointClear(Rid joint)
    {
        NativeCalls.godot_icall_1_286(MethodBind101, GodotObject.GetPtr(this), joint);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind102 = ClassDB_get_method_with_compatibility(NativeName, MethodName.JointSetParam, 3972556514ul);

    /// <summary>
    /// <para>Sets the value of the given joint parameter.</para>
    /// </summary>
    public void JointSetParam(Rid joint, PhysicsServer2D.JointParam param, float value)
    {
        NativeCalls.godot_icall_3_988(MethodBind102, GodotObject.GetPtr(this), joint, (int)param, value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind103 = ClassDB_get_method_with_compatibility(NativeName, MethodName.JointGetParam, 4016448949ul);

    /// <summary>
    /// <para>Returns the value of the given joint parameter.</para>
    /// </summary>
    public float JointGetParam(Rid joint, PhysicsServer2D.JointParam param)
    {
        return NativeCalls.godot_icall_2_989(MethodBind103, GodotObject.GetPtr(this), joint, (int)param);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind104 = ClassDB_get_method_with_compatibility(NativeName, MethodName.JointDisableCollisionsBetweenBodies, 1265174801ul);

    /// <summary>
    /// <para>Sets whether the bodies attached to the <see cref="Godot.Joint2D"/> will collide with each other.</para>
    /// </summary>
    public void JointDisableCollisionsBetweenBodies(Rid joint, bool disable)
    {
        NativeCalls.godot_icall_2_434(MethodBind104, GodotObject.GetPtr(this), joint, disable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind105 = ClassDB_get_method_with_compatibility(NativeName, MethodName.JointIsDisabledCollisionsBetweenBodies, 4155700596ul);

    /// <summary>
    /// <para>Returns whether the bodies attached to the <see cref="Godot.Joint2D"/> will collide with each other.</para>
    /// </summary>
    public bool JointIsDisabledCollisionsBetweenBodies(Rid joint)
    {
        return NativeCalls.godot_icall_1_421(MethodBind105, GodotObject.GetPtr(this), joint).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind106 = ClassDB_get_method_with_compatibility(NativeName, MethodName.JointMakePin, 1612646186ul);

    /// <summary>
    /// <para>Makes the joint a pin joint. If <paramref name="bodyB"/> is an empty <see cref="Godot.Rid"/>, then <paramref name="bodyA"/> is pinned to the point <paramref name="anchor"/> (given in global coordinates); otherwise, <paramref name="bodyA"/> is pinned to <paramref name="bodyB"/> at the point <paramref name="anchor"/> (given in global coordinates). To set the parameters which are specific to the pin joint, see <see cref="Godot.PhysicsServer2DInstance.PinJointSetParam(Rid, PhysicsServer2D.PinJointParam, float)"/>.</para>
    /// </summary>
    public unsafe void JointMakePin(Rid joint, Vector2 anchor, Rid bodyA, Rid bodyB = default)
    {
        NativeCalls.godot_icall_4_997(MethodBind106, GodotObject.GetPtr(this), joint, &anchor, bodyA, bodyB);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind107 = ClassDB_get_method_with_compatibility(NativeName, MethodName.JointMakeGroove, 481430435ul);

    /// <summary>
    /// <para>Makes the joint a groove joint.</para>
    /// </summary>
    public unsafe void JointMakeGroove(Rid joint, Vector2 groove1A, Vector2 groove2A, Vector2 anchorB, Rid bodyA = default, Rid bodyB = default)
    {
        NativeCalls.godot_icall_6_998(MethodBind107, GodotObject.GetPtr(this), joint, &groove1A, &groove2A, &anchorB, bodyA, bodyB);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind108 = ClassDB_get_method_with_compatibility(NativeName, MethodName.JointMakeDampedSpring, 1994657646ul);

    /// <summary>
    /// <para>Makes the joint a damped spring joint, attached at the point <paramref name="anchorA"/> (given in global coordinates) on the body <paramref name="bodyA"/> and at the point <paramref name="anchorB"/> (given in global coordinates) on the body <paramref name="bodyB"/>. To set the parameters which are specific to the damped spring, see <see cref="Godot.PhysicsServer2DInstance.DampedSpringJointSetParam(Rid, PhysicsServer2D.DampedSpringParam, float)"/>.</para>
    /// </summary>
    public unsafe void JointMakeDampedSpring(Rid joint, Vector2 anchorA, Vector2 anchorB, Rid bodyA, Rid bodyB = default)
    {
        NativeCalls.godot_icall_5_999(MethodBind108, GodotObject.GetPtr(this), joint, &anchorA, &anchorB, bodyA, bodyB);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind109 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PinJointSetFlag, 3520002352ul);

    /// <summary>
    /// <para>Sets a pin joint flag.</para>
    /// </summary>
    public void PinJointSetFlag(Rid joint, PhysicsServer2D.PinJointFlag flag, bool enabled)
    {
        NativeCalls.godot_icall_3_439(MethodBind109, GodotObject.GetPtr(this), joint, (int)flag, enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind110 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PinJointGetFlag, 2647867364ul);

    /// <summary>
    /// <para>Gets a pin joint flag.</para>
    /// </summary>
    public bool PinJointGetFlag(Rid joint, PhysicsServer2D.PinJointFlag flag)
    {
        return NativeCalls.godot_icall_2_826(MethodBind110, GodotObject.GetPtr(this), joint, (int)flag).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind111 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PinJointSetParam, 550574241ul);

    /// <summary>
    /// <para>Sets a pin joint parameter.</para>
    /// </summary>
    public void PinJointSetParam(Rid joint, PhysicsServer2D.PinJointParam param, float value)
    {
        NativeCalls.godot_icall_3_988(MethodBind111, GodotObject.GetPtr(this), joint, (int)param, value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind112 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PinJointGetParam, 348281383ul);

    /// <summary>
    /// <para>Returns the value of a pin joint parameter.</para>
    /// </summary>
    public float PinJointGetParam(Rid joint, PhysicsServer2D.PinJointParam param)
    {
        return NativeCalls.godot_icall_2_989(MethodBind112, GodotObject.GetPtr(this), joint, (int)param);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind113 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DampedSpringJointSetParam, 220564071ul);

    /// <summary>
    /// <para>Sets the value of the given damped spring joint parameter.</para>
    /// </summary>
    public void DampedSpringJointSetParam(Rid joint, PhysicsServer2D.DampedSpringParam param, float value)
    {
        NativeCalls.godot_icall_3_988(MethodBind113, GodotObject.GetPtr(this), joint, (int)param, value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind114 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DampedSpringJointGetParam, 2075871277ul);

    /// <summary>
    /// <para>Returns the value of the given damped spring joint parameter.</para>
    /// </summary>
    public float DampedSpringJointGetParam(Rid joint, PhysicsServer2D.DampedSpringParam param)
    {
        return NativeCalls.godot_icall_2_989(MethodBind114, GodotObject.GetPtr(this), joint, (int)param);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind115 = ClassDB_get_method_with_compatibility(NativeName, MethodName.JointGetType, 4262502231ul);

    /// <summary>
    /// <para>Returns the joint's type.</para>
    /// </summary>
    public PhysicsServer2D.JointType JointGetType(Rid joint)
    {
        return (PhysicsServer2D.JointType)NativeCalls.godot_icall_1_835(MethodBind115, GodotObject.GetPtr(this), joint);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind116 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FreeRid, 2722037293ul);

    /// <summary>
    /// <para>Destroys any of the objects created by PhysicsServer2D. If the <see cref="Godot.Rid"/> passed is not one of the objects that can be created by PhysicsServer2D, an error will be printed to the console.</para>
    /// </summary>
    public void FreeRid(Rid rid)
    {
        NativeCalls.godot_icall_1_286(MethodBind116, GodotObject.GetPtr(this), rid);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind117 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetActive, 2586408642ul);

    /// <summary>
    /// <para>Activates or deactivates the 2D physics server. If <paramref name="active"/> is <see langword="false"/>, then the physics server will not do anything in its physics step.</para>
    /// </summary>
    public void SetActive(bool active)
    {
        NativeCalls.godot_icall_1_14(MethodBind117, GodotObject.GetPtr(this), active.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind118 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetProcessInfo, 576496006ul);

    /// <summary>
    /// <para>Returns the value of a physics engine state specified by <paramref name="processInfo"/>.</para>
    /// </summary>
    public int GetProcessInfo(PhysicsServer2D.ProcessInfo processInfo)
    {
        return NativeCalls.godot_icall_1_60(MethodBind118, GodotObject.GetPtr(this), (int)processInfo);
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
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : GodotObject.MethodName
    {
        /// <summary>
        /// Cached name for the 'world_boundary_shape_create' method.
        /// </summary>
        public static readonly StringName WorldBoundaryShapeCreate = "world_boundary_shape_create";
        /// <summary>
        /// Cached name for the 'separation_ray_shape_create' method.
        /// </summary>
        public static readonly StringName SeparationRayShapeCreate = "separation_ray_shape_create";
        /// <summary>
        /// Cached name for the 'segment_shape_create' method.
        /// </summary>
        public static readonly StringName SegmentShapeCreate = "segment_shape_create";
        /// <summary>
        /// Cached name for the 'circle_shape_create' method.
        /// </summary>
        public static readonly StringName CircleShapeCreate = "circle_shape_create";
        /// <summary>
        /// Cached name for the 'rectangle_shape_create' method.
        /// </summary>
        public static readonly StringName RectangleShapeCreate = "rectangle_shape_create";
        /// <summary>
        /// Cached name for the 'capsule_shape_create' method.
        /// </summary>
        public static readonly StringName CapsuleShapeCreate = "capsule_shape_create";
        /// <summary>
        /// Cached name for the 'convex_polygon_shape_create' method.
        /// </summary>
        public static readonly StringName ConvexPolygonShapeCreate = "convex_polygon_shape_create";
        /// <summary>
        /// Cached name for the 'concave_polygon_shape_create' method.
        /// </summary>
        public static readonly StringName ConcavePolygonShapeCreate = "concave_polygon_shape_create";
        /// <summary>
        /// Cached name for the 'shape_set_data' method.
        /// </summary>
        public static readonly StringName ShapeSetData = "shape_set_data";
        /// <summary>
        /// Cached name for the 'shape_get_type' method.
        /// </summary>
        public static readonly StringName ShapeGetType = "shape_get_type";
        /// <summary>
        /// Cached name for the 'shape_get_data' method.
        /// </summary>
        public static readonly StringName ShapeGetData = "shape_get_data";
        /// <summary>
        /// Cached name for the 'space_create' method.
        /// </summary>
        public static readonly StringName SpaceCreate = "space_create";
        /// <summary>
        /// Cached name for the 'space_set_active' method.
        /// </summary>
        public static readonly StringName SpaceSetActive = "space_set_active";
        /// <summary>
        /// Cached name for the 'space_is_active' method.
        /// </summary>
        public static readonly StringName SpaceIsActive = "space_is_active";
        /// <summary>
        /// Cached name for the 'space_set_param' method.
        /// </summary>
        public static readonly StringName SpaceSetParam = "space_set_param";
        /// <summary>
        /// Cached name for the 'space_get_param' method.
        /// </summary>
        public static readonly StringName SpaceGetParam = "space_get_param";
        /// <summary>
        /// Cached name for the 'space_get_direct_state' method.
        /// </summary>
        public static readonly StringName SpaceGetDirectState = "space_get_direct_state";
        /// <summary>
        /// Cached name for the 'area_create' method.
        /// </summary>
        public static readonly StringName AreaCreate = "area_create";
        /// <summary>
        /// Cached name for the 'area_set_space' method.
        /// </summary>
        public static readonly StringName AreaSetSpace = "area_set_space";
        /// <summary>
        /// Cached name for the 'area_get_space' method.
        /// </summary>
        public static readonly StringName AreaGetSpace = "area_get_space";
        /// <summary>
        /// Cached name for the 'area_add_shape' method.
        /// </summary>
        public static readonly StringName AreaAddShape = "area_add_shape";
        /// <summary>
        /// Cached name for the 'area_set_shape' method.
        /// </summary>
        public static readonly StringName AreaSetShape = "area_set_shape";
        /// <summary>
        /// Cached name for the 'area_set_shape_transform' method.
        /// </summary>
        public static readonly StringName AreaSetShapeTransform = "area_set_shape_transform";
        /// <summary>
        /// Cached name for the 'area_set_shape_disabled' method.
        /// </summary>
        public static readonly StringName AreaSetShapeDisabled = "area_set_shape_disabled";
        /// <summary>
        /// Cached name for the 'area_get_shape_count' method.
        /// </summary>
        public static readonly StringName AreaGetShapeCount = "area_get_shape_count";
        /// <summary>
        /// Cached name for the 'area_get_shape' method.
        /// </summary>
        public static readonly StringName AreaGetShape = "area_get_shape";
        /// <summary>
        /// Cached name for the 'area_get_shape_transform' method.
        /// </summary>
        public static readonly StringName AreaGetShapeTransform = "area_get_shape_transform";
        /// <summary>
        /// Cached name for the 'area_remove_shape' method.
        /// </summary>
        public static readonly StringName AreaRemoveShape = "area_remove_shape";
        /// <summary>
        /// Cached name for the 'area_clear_shapes' method.
        /// </summary>
        public static readonly StringName AreaClearShapes = "area_clear_shapes";
        /// <summary>
        /// Cached name for the 'area_set_collision_layer' method.
        /// </summary>
        public static readonly StringName AreaSetCollisionLayer = "area_set_collision_layer";
        /// <summary>
        /// Cached name for the 'area_get_collision_layer' method.
        /// </summary>
        public static readonly StringName AreaGetCollisionLayer = "area_get_collision_layer";
        /// <summary>
        /// Cached name for the 'area_set_collision_mask' method.
        /// </summary>
        public static readonly StringName AreaSetCollisionMask = "area_set_collision_mask";
        /// <summary>
        /// Cached name for the 'area_get_collision_mask' method.
        /// </summary>
        public static readonly StringName AreaGetCollisionMask = "area_get_collision_mask";
        /// <summary>
        /// Cached name for the 'area_set_param' method.
        /// </summary>
        public static readonly StringName AreaSetParam = "area_set_param";
        /// <summary>
        /// Cached name for the 'area_set_transform' method.
        /// </summary>
        public static readonly StringName AreaSetTransform = "area_set_transform";
        /// <summary>
        /// Cached name for the 'area_get_param' method.
        /// </summary>
        public static readonly StringName AreaGetParam = "area_get_param";
        /// <summary>
        /// Cached name for the 'area_get_transform' method.
        /// </summary>
        public static readonly StringName AreaGetTransform = "area_get_transform";
        /// <summary>
        /// Cached name for the 'area_attach_object_instance_id' method.
        /// </summary>
        public static readonly StringName AreaAttachObjectInstanceId = "area_attach_object_instance_id";
        /// <summary>
        /// Cached name for the 'area_get_object_instance_id' method.
        /// </summary>
        public static readonly StringName AreaGetObjectInstanceId = "area_get_object_instance_id";
        /// <summary>
        /// Cached name for the 'area_attach_canvas_instance_id' method.
        /// </summary>
        public static readonly StringName AreaAttachCanvasInstanceId = "area_attach_canvas_instance_id";
        /// <summary>
        /// Cached name for the 'area_get_canvas_instance_id' method.
        /// </summary>
        public static readonly StringName AreaGetCanvasInstanceId = "area_get_canvas_instance_id";
        /// <summary>
        /// Cached name for the 'area_set_monitor_callback' method.
        /// </summary>
        public static readonly StringName AreaSetMonitorCallback = "area_set_monitor_callback";
        /// <summary>
        /// Cached name for the 'area_set_area_monitor_callback' method.
        /// </summary>
        public static readonly StringName AreaSetAreaMonitorCallback = "area_set_area_monitor_callback";
        /// <summary>
        /// Cached name for the 'area_set_monitorable' method.
        /// </summary>
        public static readonly StringName AreaSetMonitorable = "area_set_monitorable";
        /// <summary>
        /// Cached name for the 'body_create' method.
        /// </summary>
        public static readonly StringName BodyCreate = "body_create";
        /// <summary>
        /// Cached name for the 'body_set_space' method.
        /// </summary>
        public static readonly StringName BodySetSpace = "body_set_space";
        /// <summary>
        /// Cached name for the 'body_get_space' method.
        /// </summary>
        public static readonly StringName BodyGetSpace = "body_get_space";
        /// <summary>
        /// Cached name for the 'body_set_mode' method.
        /// </summary>
        public static readonly StringName BodySetMode = "body_set_mode";
        /// <summary>
        /// Cached name for the 'body_get_mode' method.
        /// </summary>
        public static readonly StringName BodyGetMode = "body_get_mode";
        /// <summary>
        /// Cached name for the 'body_add_shape' method.
        /// </summary>
        public static readonly StringName BodyAddShape = "body_add_shape";
        /// <summary>
        /// Cached name for the 'body_set_shape' method.
        /// </summary>
        public static readonly StringName BodySetShape = "body_set_shape";
        /// <summary>
        /// Cached name for the 'body_set_shape_transform' method.
        /// </summary>
        public static readonly StringName BodySetShapeTransform = "body_set_shape_transform";
        /// <summary>
        /// Cached name for the 'body_get_shape_count' method.
        /// </summary>
        public static readonly StringName BodyGetShapeCount = "body_get_shape_count";
        /// <summary>
        /// Cached name for the 'body_get_shape' method.
        /// </summary>
        public static readonly StringName BodyGetShape = "body_get_shape";
        /// <summary>
        /// Cached name for the 'body_get_shape_transform' method.
        /// </summary>
        public static readonly StringName BodyGetShapeTransform = "body_get_shape_transform";
        /// <summary>
        /// Cached name for the 'body_remove_shape' method.
        /// </summary>
        public static readonly StringName BodyRemoveShape = "body_remove_shape";
        /// <summary>
        /// Cached name for the 'body_clear_shapes' method.
        /// </summary>
        public static readonly StringName BodyClearShapes = "body_clear_shapes";
        /// <summary>
        /// Cached name for the 'body_set_shape_disabled' method.
        /// </summary>
        public static readonly StringName BodySetShapeDisabled = "body_set_shape_disabled";
        /// <summary>
        /// Cached name for the 'body_set_shape_as_one_way_collision' method.
        /// </summary>
        public static readonly StringName BodySetShapeAsOneWayCollision = "body_set_shape_as_one_way_collision";
        /// <summary>
        /// Cached name for the 'body_attach_object_instance_id' method.
        /// </summary>
        public static readonly StringName BodyAttachObjectInstanceId = "body_attach_object_instance_id";
        /// <summary>
        /// Cached name for the 'body_get_object_instance_id' method.
        /// </summary>
        public static readonly StringName BodyGetObjectInstanceId = "body_get_object_instance_id";
        /// <summary>
        /// Cached name for the 'body_attach_canvas_instance_id' method.
        /// </summary>
        public static readonly StringName BodyAttachCanvasInstanceId = "body_attach_canvas_instance_id";
        /// <summary>
        /// Cached name for the 'body_get_canvas_instance_id' method.
        /// </summary>
        public static readonly StringName BodyGetCanvasInstanceId = "body_get_canvas_instance_id";
        /// <summary>
        /// Cached name for the 'body_set_continuous_collision_detection_mode' method.
        /// </summary>
        public static readonly StringName BodySetContinuousCollisionDetectionMode = "body_set_continuous_collision_detection_mode";
        /// <summary>
        /// Cached name for the 'body_get_continuous_collision_detection_mode' method.
        /// </summary>
        public static readonly StringName BodyGetContinuousCollisionDetectionMode = "body_get_continuous_collision_detection_mode";
        /// <summary>
        /// Cached name for the 'body_set_collision_layer' method.
        /// </summary>
        public static readonly StringName BodySetCollisionLayer = "body_set_collision_layer";
        /// <summary>
        /// Cached name for the 'body_get_collision_layer' method.
        /// </summary>
        public static readonly StringName BodyGetCollisionLayer = "body_get_collision_layer";
        /// <summary>
        /// Cached name for the 'body_set_collision_mask' method.
        /// </summary>
        public static readonly StringName BodySetCollisionMask = "body_set_collision_mask";
        /// <summary>
        /// Cached name for the 'body_get_collision_mask' method.
        /// </summary>
        public static readonly StringName BodyGetCollisionMask = "body_get_collision_mask";
        /// <summary>
        /// Cached name for the 'body_set_collision_priority' method.
        /// </summary>
        public static readonly StringName BodySetCollisionPriority = "body_set_collision_priority";
        /// <summary>
        /// Cached name for the 'body_get_collision_priority' method.
        /// </summary>
        public static readonly StringName BodyGetCollisionPriority = "body_get_collision_priority";
        /// <summary>
        /// Cached name for the 'body_set_param' method.
        /// </summary>
        public static readonly StringName BodySetParam = "body_set_param";
        /// <summary>
        /// Cached name for the 'body_get_param' method.
        /// </summary>
        public static readonly StringName BodyGetParam = "body_get_param";
        /// <summary>
        /// Cached name for the 'body_reset_mass_properties' method.
        /// </summary>
        public static readonly StringName BodyResetMassProperties = "body_reset_mass_properties";
        /// <summary>
        /// Cached name for the 'body_set_state' method.
        /// </summary>
        public static readonly StringName BodySetState = "body_set_state";
        /// <summary>
        /// Cached name for the 'body_get_state' method.
        /// </summary>
        public static readonly StringName BodyGetState = "body_get_state";
        /// <summary>
        /// Cached name for the 'body_apply_central_impulse' method.
        /// </summary>
        public static readonly StringName BodyApplyCentralImpulse = "body_apply_central_impulse";
        /// <summary>
        /// Cached name for the 'body_apply_torque_impulse' method.
        /// </summary>
        public static readonly StringName BodyApplyTorqueImpulse = "body_apply_torque_impulse";
        /// <summary>
        /// Cached name for the 'body_apply_impulse' method.
        /// </summary>
        public static readonly StringName BodyApplyImpulse = "body_apply_impulse";
        /// <summary>
        /// Cached name for the 'body_apply_central_force' method.
        /// </summary>
        public static readonly StringName BodyApplyCentralForce = "body_apply_central_force";
        /// <summary>
        /// Cached name for the 'body_apply_force' method.
        /// </summary>
        public static readonly StringName BodyApplyForce = "body_apply_force";
        /// <summary>
        /// Cached name for the 'body_apply_torque' method.
        /// </summary>
        public static readonly StringName BodyApplyTorque = "body_apply_torque";
        /// <summary>
        /// Cached name for the 'body_add_constant_central_force' method.
        /// </summary>
        public static readonly StringName BodyAddConstantCentralForce = "body_add_constant_central_force";
        /// <summary>
        /// Cached name for the 'body_add_constant_force' method.
        /// </summary>
        public static readonly StringName BodyAddConstantForce = "body_add_constant_force";
        /// <summary>
        /// Cached name for the 'body_add_constant_torque' method.
        /// </summary>
        public static readonly StringName BodyAddConstantTorque = "body_add_constant_torque";
        /// <summary>
        /// Cached name for the 'body_set_constant_force' method.
        /// </summary>
        public static readonly StringName BodySetConstantForce = "body_set_constant_force";
        /// <summary>
        /// Cached name for the 'body_get_constant_force' method.
        /// </summary>
        public static readonly StringName BodyGetConstantForce = "body_get_constant_force";
        /// <summary>
        /// Cached name for the 'body_set_constant_torque' method.
        /// </summary>
        public static readonly StringName BodySetConstantTorque = "body_set_constant_torque";
        /// <summary>
        /// Cached name for the 'body_get_constant_torque' method.
        /// </summary>
        public static readonly StringName BodyGetConstantTorque = "body_get_constant_torque";
        /// <summary>
        /// Cached name for the 'body_set_axis_velocity' method.
        /// </summary>
        public static readonly StringName BodySetAxisVelocity = "body_set_axis_velocity";
        /// <summary>
        /// Cached name for the 'body_add_collision_exception' method.
        /// </summary>
        public static readonly StringName BodyAddCollisionException = "body_add_collision_exception";
        /// <summary>
        /// Cached name for the 'body_remove_collision_exception' method.
        /// </summary>
        public static readonly StringName BodyRemoveCollisionException = "body_remove_collision_exception";
        /// <summary>
        /// Cached name for the 'body_set_max_contacts_reported' method.
        /// </summary>
        public static readonly StringName BodySetMaxContactsReported = "body_set_max_contacts_reported";
        /// <summary>
        /// Cached name for the 'body_get_max_contacts_reported' method.
        /// </summary>
        public static readonly StringName BodyGetMaxContactsReported = "body_get_max_contacts_reported";
        /// <summary>
        /// Cached name for the 'body_set_omit_force_integration' method.
        /// </summary>
        public static readonly StringName BodySetOmitForceIntegration = "body_set_omit_force_integration";
        /// <summary>
        /// Cached name for the 'body_is_omitting_force_integration' method.
        /// </summary>
        public static readonly StringName BodyIsOmittingForceIntegration = "body_is_omitting_force_integration";
        /// <summary>
        /// Cached name for the 'body_set_state_sync_callback' method.
        /// </summary>
        public static readonly StringName BodySetStateSyncCallback = "body_set_state_sync_callback";
        /// <summary>
        /// Cached name for the 'body_set_force_integration_callback' method.
        /// </summary>
        public static readonly StringName BodySetForceIntegrationCallback = "body_set_force_integration_callback";
        /// <summary>
        /// Cached name for the 'body_test_motion' method.
        /// </summary>
        public static readonly StringName BodyTestMotion = "body_test_motion";
        /// <summary>
        /// Cached name for the 'body_get_direct_state' method.
        /// </summary>
        public static readonly StringName BodyGetDirectState = "body_get_direct_state";
        /// <summary>
        /// Cached name for the 'joint_create' method.
        /// </summary>
        public static readonly StringName JointCreate = "joint_create";
        /// <summary>
        /// Cached name for the 'joint_clear' method.
        /// </summary>
        public static readonly StringName JointClear = "joint_clear";
        /// <summary>
        /// Cached name for the 'joint_set_param' method.
        /// </summary>
        public static readonly StringName JointSetParam = "joint_set_param";
        /// <summary>
        /// Cached name for the 'joint_get_param' method.
        /// </summary>
        public static readonly StringName JointGetParam = "joint_get_param";
        /// <summary>
        /// Cached name for the 'joint_disable_collisions_between_bodies' method.
        /// </summary>
        public static readonly StringName JointDisableCollisionsBetweenBodies = "joint_disable_collisions_between_bodies";
        /// <summary>
        /// Cached name for the 'joint_is_disabled_collisions_between_bodies' method.
        /// </summary>
        public static readonly StringName JointIsDisabledCollisionsBetweenBodies = "joint_is_disabled_collisions_between_bodies";
        /// <summary>
        /// Cached name for the 'joint_make_pin' method.
        /// </summary>
        public static readonly StringName JointMakePin = "joint_make_pin";
        /// <summary>
        /// Cached name for the 'joint_make_groove' method.
        /// </summary>
        public static readonly StringName JointMakeGroove = "joint_make_groove";
        /// <summary>
        /// Cached name for the 'joint_make_damped_spring' method.
        /// </summary>
        public static readonly StringName JointMakeDampedSpring = "joint_make_damped_spring";
        /// <summary>
        /// Cached name for the 'pin_joint_set_flag' method.
        /// </summary>
        public static readonly StringName PinJointSetFlag = "pin_joint_set_flag";
        /// <summary>
        /// Cached name for the 'pin_joint_get_flag' method.
        /// </summary>
        public static readonly StringName PinJointGetFlag = "pin_joint_get_flag";
        /// <summary>
        /// Cached name for the 'pin_joint_set_param' method.
        /// </summary>
        public static readonly StringName PinJointSetParam = "pin_joint_set_param";
        /// <summary>
        /// Cached name for the 'pin_joint_get_param' method.
        /// </summary>
        public static readonly StringName PinJointGetParam = "pin_joint_get_param";
        /// <summary>
        /// Cached name for the 'damped_spring_joint_set_param' method.
        /// </summary>
        public static readonly StringName DampedSpringJointSetParam = "damped_spring_joint_set_param";
        /// <summary>
        /// Cached name for the 'damped_spring_joint_get_param' method.
        /// </summary>
        public static readonly StringName DampedSpringJointGetParam = "damped_spring_joint_get_param";
        /// <summary>
        /// Cached name for the 'joint_get_type' method.
        /// </summary>
        public static readonly StringName JointGetType = "joint_get_type";
        /// <summary>
        /// Cached name for the 'free_rid' method.
        /// </summary>
        public static readonly StringName FreeRid = "free_rid";
        /// <summary>
        /// Cached name for the 'set_active' method.
        /// </summary>
        public static readonly StringName SetActive = "set_active";
        /// <summary>
        /// Cached name for the 'get_process_info' method.
        /// </summary>
        public static readonly StringName GetProcessInfo = "get_process_info";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : GodotObject.SignalName
    {
    }
}
