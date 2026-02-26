namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>PhysicsServer3D is the server responsible for all 3D physics. It can directly create and manipulate all physics objects:</para>
/// <para>- A <i>space</i> is a self-contained world for a physics simulation. It contains bodies, areas, and joints. Its state can be queried for collision and intersection information, and several parameters of the simulation can be modified.</para>
/// <para>- A <i>shape</i> is a geometric shape such as a sphere, a box, a cylinder, or a polygon. It can be used for collision detection by adding it to a body/area, possibly with an extra transformation relative to the body/area's origin. Bodies/areas can have multiple (transformed) shapes added to them, and a single shape can be added to bodies/areas multiple times with different local transformations.</para>
/// <para>- A <i>body</i> is a physical object which can be in static, kinematic, or rigid mode. Its state (such as position and velocity) can be queried and updated. A force integration callback can be set to customize the body's physics.</para>
/// <para>- An <i>area</i> is a region in space which can be used to detect bodies and areas entering and exiting it. A body monitoring callback can be set to report entering/exiting body shapes, and similarly an area monitoring callback can be set. Gravity and damping can be overridden within the area by setting area parameters.</para>
/// <para>- A <i>joint</i> is a constraint, either between two bodies or on one body relative to a point. Parameters such as the joint bias and the rest length of a spring joint can be adjusted.</para>
/// <para>Physics objects in <see cref="Godot.PhysicsServer3D"/> may be created and manipulated independently; they do not have to be tied to nodes in the scene tree.</para>
/// <para><b>Note:</b> All the 3D physics nodes use the physics server internally. Adding a physics node to the scene tree will cause a corresponding physics object to be created in the physics server. A rigid body node registers a callback that updates the node's transform with the transform of the respective body object in the physics server (every physics update). An area node registers a callback to inform the area node about overlaps with the respective area object in the physics server. The raycast node queries the direct state of the relevant space in the physics server.</para>
/// </summary>
[GodotClassName("PhysicsServer3D")]
public partial class PhysicsServer3DInstance : GodotObject
{
    private static readonly System.Type CachedType = typeof(PhysicsServer3DInstance);

    private static readonly StringName NativeName = "PhysicsServer3D";

    internal PhysicsServer3DInstance() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal PhysicsServer3DInstance(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal PhysicsServer3DInstance(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.WorldBoundaryShapeCreate, 529393457ul);

    /// <summary>
    /// <para>Creates a 3D world boundary shape in the physics server, and returns the <see cref="Godot.Rid"/> that identifies it. Use <see cref="Godot.PhysicsServer3DInstance.ShapeSetData(Rid, Variant)"/> to set the shape's normal direction and distance properties.</para>
    /// </summary>
    public Rid WorldBoundaryShapeCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind0, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SeparationRayShapeCreate, 529393457ul);

    /// <summary>
    /// <para>Creates a 3D separation ray shape in the physics server, and returns the <see cref="Godot.Rid"/> that identifies it. Use <see cref="Godot.PhysicsServer3DInstance.ShapeSetData(Rid, Variant)"/> to set the shape's <c>length</c> and <c>slide_on_slope</c> properties.</para>
    /// </summary>
    public Rid SeparationRayShapeCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SphereShapeCreate, 529393457ul);

    /// <summary>
    /// <para>Creates a 3D sphere shape in the physics server, and returns the <see cref="Godot.Rid"/> that identifies it. Use <see cref="Godot.PhysicsServer3DInstance.ShapeSetData(Rid, Variant)"/> to set the sphere's radius.</para>
    /// </summary>
    public Rid SphereShapeCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BoxShapeCreate, 529393457ul);

    /// <summary>
    /// <para>Creates a 3D box shape in the physics server, and returns the <see cref="Godot.Rid"/> that identifies it. Use <see cref="Godot.PhysicsServer3DInstance.ShapeSetData(Rid, Variant)"/> to set the box's half-extents.</para>
    /// </summary>
    public Rid BoxShapeCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CapsuleShapeCreate, 529393457ul);

    /// <summary>
    /// <para>Creates a 3D capsule shape in the physics server, and returns the <see cref="Godot.Rid"/> that identifies it. Use <see cref="Godot.PhysicsServer3DInstance.ShapeSetData(Rid, Variant)"/> to set the capsule's height and radius.</para>
    /// </summary>
    public Rid CapsuleShapeCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind4, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CylinderShapeCreate, 529393457ul);

    /// <summary>
    /// <para>Creates a 3D cylinder shape in the physics server, and returns the <see cref="Godot.Rid"/> that identifies it. Use <see cref="Godot.PhysicsServer3DInstance.ShapeSetData(Rid, Variant)"/> to set the cylinder's height and radius.</para>
    /// </summary>
    public Rid CylinderShapeCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ConvexPolygonShapeCreate, 529393457ul);

    /// <summary>
    /// <para>Creates a 3D convex polygon shape in the physics server, and returns the <see cref="Godot.Rid"/> that identifies it. Use <see cref="Godot.PhysicsServer3DInstance.ShapeSetData(Rid, Variant)"/> to set the convex polygon's points.</para>
    /// </summary>
    public Rid ConvexPolygonShapeCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind6, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ConcavePolygonShapeCreate, 529393457ul);

    /// <summary>
    /// <para>Creates a 3D concave polygon shape in the physics server, and returns the <see cref="Godot.Rid"/> that identifies it. Use <see cref="Godot.PhysicsServer3DInstance.ShapeSetData(Rid, Variant)"/> to set the concave polygon's triangles.</para>
    /// </summary>
    public Rid ConcavePolygonShapeCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HeightmapShapeCreate, 529393457ul);

    /// <summary>
    /// <para>Creates a 3D heightmap shape in the physics server, and returns the <see cref="Godot.Rid"/> that identifies it. Use <see cref="Godot.PhysicsServer3DInstance.ShapeSetData(Rid, Variant)"/> to set the heightmap's data.</para>
    /// </summary>
    public Rid HeightmapShapeCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind8, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CustomShapeCreate, 529393457ul);

    /// <summary>
    /// <para>Creates a custom shape in the physics server, and returns the <see cref="Godot.Rid"/> that identifies it. Use <see cref="Godot.PhysicsServer3DInstance.ShapeSetData(Rid, Variant)"/> to set the shape's data.</para>
    /// <para><b>Note:</b> Custom shapes are not supported by the built-in physics servers, so calling this method always produces an error when using Godot Physics or Jolt Physics. Custom physics servers implemented as GDExtensions may support a custom shape.</para>
    /// </summary>
    public Rid CustomShapeCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapeSetData, 3175752987ul);

    /// <summary>
    /// <para>Sets the shape data that configures the shape. The <paramref name="data"/> to be passed depends on the shape's type (see <see cref="Godot.PhysicsServer3DInstance.ShapeGetType(Rid)"/>):</para>
    /// <para>- <see cref="Godot.PhysicsServer3D.ShapeType.WorldBoundary"/>: a <see cref="Godot.Plane"/>,</para>
    /// <para>- <see cref="Godot.PhysicsServer3D.ShapeType.SeparationRay"/>: a dictionary containing the key <c>"length"</c> with a <see cref="float"/> value and the key <c>"slide_on_slope"</c> with a <see cref="bool"/> value,</para>
    /// <para>- <see cref="Godot.PhysicsServer3D.ShapeType.Sphere"/>: a <see cref="float"/> that is the radius of the sphere,</para>
    /// <para>- <see cref="Godot.PhysicsServer3D.ShapeType.Box"/>: a <see cref="Godot.Vector3"/> containing the half-extents of the box,</para>
    /// <para>- <see cref="Godot.PhysicsServer3D.ShapeType.Capsule"/>: a dictionary containing the keys <c>"height"</c> and <c>"radius"</c> with <see cref="float"/> values,</para>
    /// <para>- <see cref="Godot.PhysicsServer3D.ShapeType.Cylinder"/>: a dictionary containing the keys <c>"height"</c> and <c>"radius"</c> with <see cref="float"/> values,</para>
    /// <para>- <see cref="Godot.PhysicsServer3D.ShapeType.ConvexPolygon"/>: a <see cref="Godot.Vector3"/>[] of points defining a convex polygon (the shape will be the convex hull of the points),</para>
    /// <para>- <see cref="Godot.PhysicsServer3D.ShapeType.ConcavePolygon"/>: a dictionary containing the key <c>"faces"</c> with a <see cref="Godot.Vector3"/>[] value (with a length divisible by 3, so that each 3-tuple of points forms a face) and the key <c>"backface_collision"</c> with a <see cref="bool"/> value,</para>
    /// <para>- <see cref="Godot.PhysicsServer3D.ShapeType.Heightmap"/>: a dictionary containing the keys <c>"width"</c> and <c>"depth"</c> with <see cref="int"/> values, and the key <c>"heights"</c> with a value that is a packed array of <see cref="float"/>s of length <c>width * depth</c> (that is a <see cref="float"/>[], or a <see cref="double"/>[] if Godot was compiled with the <c>precision=double</c> option), and optionally the keys <c>"min_height"</c> and <c>"max_height"</c> with <see cref="float"/> values,</para>
    /// <para>- <see cref="Godot.PhysicsServer3D.ShapeType.SoftBody"/>: the input <paramref name="data"/> is ignored and this method has no effect,</para>
    /// <para>- <see cref="Godot.PhysicsServer3D.ShapeType.Custom"/>: the input <paramref name="data"/> is interpreted by a custom physics server, if it supports custom shapes.</para>
    /// </summary>
    public void ShapeSetData(Rid shape, Variant data)
    {
        NativeCalls.godot_icall_2_422(MethodBind10, GodotObject.GetPtr(this), shape, data);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapeSetMargin, 1794382983ul);

    /// <summary>
    /// <para>Sets the collision margin for the shape.</para>
    /// <para><b>Note:</b> This is not used in Godot Physics.</para>
    /// </summary>
    public void ShapeSetMargin(Rid shape, float margin)
    {
        NativeCalls.godot_icall_2_816(MethodBind11, GodotObject.GetPtr(this), shape, margin);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapeGetType, 3418923367ul);

    /// <summary>
    /// <para>Returns the shape's type.</para>
    /// </summary>
    public PhysicsServer3D.ShapeType ShapeGetType(Rid shape)
    {
        return (PhysicsServer3D.ShapeType)NativeCalls.godot_icall_1_835(MethodBind12, GodotObject.GetPtr(this), shape);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapeGetData, 4171304767ul);

    /// <summary>
    /// <para>Returns the shape data that configures the shape, such as the half-extents of a box or the triangles of a concave (trimesh) shape. See <see cref="Godot.PhysicsServer3DInstance.ShapeSetData(Rid, Variant)"/> for the precise format of this data in each case.</para>
    /// </summary>
    public Variant ShapeGetData(Rid shape)
    {
        return NativeCalls.godot_icall_1_423(MethodBind13, GodotObject.GetPtr(this), shape);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ShapeGetMargin, 866169185ul);

    /// <summary>
    /// <para>Returns the collision margin for the shape.</para>
    /// <para><b>Note:</b> This is not used in Godot Physics, so will always return <c>0</c>.</para>
    /// </summary>
    public float ShapeGetMargin(Rid shape)
    {
        return NativeCalls.godot_icall_1_817(MethodBind14, GodotObject.GetPtr(this), shape);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SpaceCreate, 529393457ul);

    /// <summary>
    /// <para>Creates a space. A space is a collection of parameters for the physics engine that can be assigned to an area or a body. It can be assigned to an area with <see cref="Godot.PhysicsServer3DInstance.AreaSetSpace(Rid, Rid)"/>, or to a body with <see cref="Godot.PhysicsServer3DInstance.BodySetSpace(Rid, Rid)"/>.</para>
    /// </summary>
    public Rid SpaceCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind15, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SpaceSetActive, 1265174801ul);

    /// <summary>
    /// <para>Marks a space as active. It will not have an effect, unless it is assigned to an area or body.</para>
    /// </summary>
    public void SpaceSetActive(Rid space, bool active)
    {
        NativeCalls.godot_icall_2_434(MethodBind16, GodotObject.GetPtr(this), space, active.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SpaceIsActive, 4155700596ul);

    /// <summary>
    /// <para>Returns whether the space is active.</para>
    /// </summary>
    public bool SpaceIsActive(Rid space)
    {
        return NativeCalls.godot_icall_1_421(MethodBind17, GodotObject.GetPtr(this), space).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SpaceSetParam, 2406017470ul);

    /// <summary>
    /// <para>Sets the value for a space parameter. A list of available parameters is on the <see cref="Godot.PhysicsServer3D.SpaceParameter"/> constants.</para>
    /// </summary>
    public void SpaceSetParam(Rid space, PhysicsServer3D.SpaceParameter param, float value)
    {
        NativeCalls.godot_icall_3_988(MethodBind18, GodotObject.GetPtr(this), space, (int)param, value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SpaceGetParam, 1523206731ul);

    /// <summary>
    /// <para>Returns the value of a space parameter.</para>
    /// </summary>
    public float SpaceGetParam(Rid space, PhysicsServer3D.SpaceParameter param)
    {
        return NativeCalls.godot_icall_2_989(MethodBind19, GodotObject.GetPtr(this), space, (int)param);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SpaceGetDirectState, 2048616813ul);

    /// <summary>
    /// <para>Returns the state of a space, a <see cref="Godot.PhysicsDirectSpaceState3D"/>. This object can be used to make collision/intersection queries.</para>
    /// </summary>
    public PhysicsDirectSpaceState3D SpaceGetDirectState(Rid space)
    {
        return (PhysicsDirectSpaceState3D)NativeCalls.godot_icall_1_938(MethodBind20, GodotObject.GetPtr(this), space);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AreaCreate, 529393457ul);

    /// <summary>
    /// <para>Creates a 3D area object in the physics server, and returns the <see cref="Godot.Rid"/> that identifies it. The default settings for the created area include a collision layer and mask set to <c>1</c>, and <c>monitorable</c> set to <see langword="false"/>.</para>
    /// <para>Use <see cref="Godot.PhysicsServer3DInstance.AreaAddShape(Rid, Rid, Nullable{Transform3D}, bool)"/> to add shapes to it, use <see cref="Godot.PhysicsServer3DInstance.AreaSetTransform(Rid, Transform3D)"/> to set its transform, and use <see cref="Godot.PhysicsServer3DInstance.AreaSetSpace(Rid, Rid)"/> to add the area to a space. If you want the area to be detectable use <see cref="Godot.PhysicsServer3DInstance.AreaSetMonitorable(Rid, bool)"/>.</para>
    /// </summary>
    public Rid AreaCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind21, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AreaSetSpace, 395945892ul);

    /// <summary>
    /// <para>Assigns a space to the area.</para>
    /// </summary>
    public void AreaSetSpace(Rid area, Rid space)
    {
        NativeCalls.godot_icall_2_430(MethodBind22, GodotObject.GetPtr(this), area, space);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AreaGetSpace, 3814569979ul);

    /// <summary>
    /// <para>Returns the space assigned to the area.</para>
    /// </summary>
    public Rid AreaGetSpace(Rid area)
    {
        return NativeCalls.godot_icall_1_855(MethodBind23, GodotObject.GetPtr(this), area);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AreaAddShape, 3711419014ul);

    /// <summary>
    /// <para>Adds a shape to the area, along with a transform matrix. Shapes are usually referenced by their index, so you should track which shape has a given index.</para>
    /// </summary>
    /// <param name="transform">If the parameter is null, then the default value is <c>Transform3D.Identity</c>.</param>
    public unsafe void AreaAddShape(Rid area, Rid shape, Nullable<Transform3D> transform = null, bool disabled = false)
    {
        Transform3D transformOrDefVal = transform.HasValue ? transform.Value : Transform3D.Identity;
        NativeCalls.godot_icall_4_1000(MethodBind24, GodotObject.GetPtr(this), area, shape, &transformOrDefVal, disabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AreaSetShape, 2310537182ul);

    /// <summary>
    /// <para>Substitutes a given area shape by another. The old shape is selected by its index, the new one by its <see cref="Godot.Rid"/>.</para>
    /// </summary>
    public void AreaSetShape(Rid area, int shapeIdx, Rid shape)
    {
        NativeCalls.godot_icall_3_833(MethodBind25, GodotObject.GetPtr(this), area, shapeIdx, shape);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AreaSetShapeTransform, 675327471ul);

    /// <summary>
    /// <para>Sets the transform matrix for an area shape.</para>
    /// </summary>
    public unsafe void AreaSetShapeTransform(Rid area, int shapeIdx, Transform3D transform)
    {
        NativeCalls.godot_icall_3_1001(MethodBind26, GodotObject.GetPtr(this), area, shapeIdx, &transform);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AreaSetShapeDisabled, 2658558584ul);

    public void AreaSetShapeDisabled(Rid area, int shapeIdx, bool disabled)
    {
        NativeCalls.godot_icall_3_439(MethodBind27, GodotObject.GetPtr(this), area, shapeIdx, disabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AreaGetShapeCount, 2198884583ul);

    /// <summary>
    /// <para>Returns the number of shapes assigned to an area.</para>
    /// </summary>
    public int AreaGetShapeCount(Rid area)
    {
        return NativeCalls.godot_icall_1_835(MethodBind28, GodotObject.GetPtr(this), area);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AreaGetShape, 1066463050ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.Rid"/> of the nth shape of an area.</para>
    /// </summary>
    public Rid AreaGetShape(Rid area, int shapeIdx)
    {
        return NativeCalls.godot_icall_2_830(MethodBind29, GodotObject.GetPtr(this), area, shapeIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AreaGetShapeTransform, 1050775521ul);

    /// <summary>
    /// <para>Returns the transform matrix of a shape within an area.</para>
    /// </summary>
    public Transform3D AreaGetShapeTransform(Rid area, int shapeIdx)
    {
        return NativeCalls.godot_icall_2_1002(MethodBind30, GodotObject.GetPtr(this), area, shapeIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AreaRemoveShape, 3411492887ul);

    /// <summary>
    /// <para>Removes a shape from an area. It does not delete the shape, so it can be reassigned later.</para>
    /// </summary>
    public void AreaRemoveShape(Rid area, int shapeIdx)
    {
        NativeCalls.godot_icall_2_426(MethodBind31, GodotObject.GetPtr(this), area, shapeIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind32 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AreaClearShapes, 2722037293ul);

    /// <summary>
    /// <para>Removes all shapes from an area. It does not delete the shapes, so they can be reassigned later.</para>
    /// </summary>
    public void AreaClearShapes(Rid area)
    {
        NativeCalls.godot_icall_1_286(MethodBind32, GodotObject.GetPtr(this), area);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind33 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AreaSetCollisionLayer, 3411492887ul);

    /// <summary>
    /// <para>Assigns the area to one or many physics layers.</para>
    /// </summary>
    public void AreaSetCollisionLayer(Rid area, uint layer)
    {
        NativeCalls.godot_icall_2_856(MethodBind33, GodotObject.GetPtr(this), area, layer);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind34 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AreaGetCollisionLayer, 2198884583ul);

    /// <summary>
    /// <para>Returns the physics layer or layers an area belongs to.</para>
    /// </summary>
    public uint AreaGetCollisionLayer(Rid area)
    {
        return NativeCalls.godot_icall_1_850(MethodBind34, GodotObject.GetPtr(this), area);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind35 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AreaSetCollisionMask, 3411492887ul);

    /// <summary>
    /// <para>Sets which physics layers the area will monitor.</para>
    /// </summary>
    public void AreaSetCollisionMask(Rid area, uint mask)
    {
        NativeCalls.godot_icall_2_856(MethodBind35, GodotObject.GetPtr(this), area, mask);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind36 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AreaGetCollisionMask, 2198884583ul);

    /// <summary>
    /// <para>Returns the physics layer or layers an area can contact with.</para>
    /// </summary>
    public uint AreaGetCollisionMask(Rid area)
    {
        return NativeCalls.godot_icall_1_850(MethodBind36, GodotObject.GetPtr(this), area);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind37 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AreaSetParam, 2980114638ul);

    /// <summary>
    /// <para>Sets the value for an area parameter. A list of available parameters is on the <see cref="Godot.PhysicsServer3D.AreaParameter"/> constants.</para>
    /// </summary>
    public void AreaSetParam(Rid area, PhysicsServer3D.AreaParameter param, Variant value)
    {
        NativeCalls.godot_icall_3_832(MethodBind37, GodotObject.GetPtr(this), area, (int)param, value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind38 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AreaSetTransform, 3935195649ul);

    /// <summary>
    /// <para>Sets the transform matrix for an area.</para>
    /// </summary>
    public unsafe void AreaSetTransform(Rid area, Transform3D transform)
    {
        NativeCalls.godot_icall_2_873(MethodBind38, GodotObject.GetPtr(this), area, &transform);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind39 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AreaGetParam, 890056067ul);

    /// <summary>
    /// <para>Returns an area parameter value. A list of available parameters is on the <see cref="Godot.PhysicsServer3D.AreaParameter"/> constants.</para>
    /// </summary>
    public Variant AreaGetParam(Rid area, PhysicsServer3D.AreaParameter param)
    {
        return NativeCalls.godot_icall_2_828(MethodBind39, GodotObject.GetPtr(this), area, (int)param);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind40 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AreaGetTransform, 1128465797ul);

    /// <summary>
    /// <para>Returns the transform matrix for an area.</para>
    /// </summary>
    public Transform3D AreaGetTransform(Rid area)
    {
        return NativeCalls.godot_icall_1_874(MethodBind40, GodotObject.GetPtr(this), area);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind41 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AreaAttachObjectInstanceId, 3411492887ul);

    /// <summary>
    /// <para>Assigns the area to a descendant of <see cref="Godot.GodotObject"/>, so it can exist in the node tree.</para>
    /// </summary>
    public void AreaAttachObjectInstanceId(Rid area, ulong id)
    {
        NativeCalls.godot_icall_2_852(MethodBind41, GodotObject.GetPtr(this), area, id);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind42 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AreaGetObjectInstanceId, 2198884583ul);

    /// <summary>
    /// <para>Gets the instance ID of the object the area is assigned to.</para>
    /// </summary>
    public ulong AreaGetObjectInstanceId(Rid area)
    {
        return NativeCalls.godot_icall_1_853(MethodBind42, GodotObject.GetPtr(this), area);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind43 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AreaSetMonitorCallback, 3379118538ul);

    /// <summary>
    /// <para>Sets the area's body monitor callback. This callback will be called when any other (shape of a) body enters or exits (a shape of) the given area, and must take the following five parameters:</para>
    /// <para>1. an integer <c>status</c>: either <see cref="Godot.PhysicsServer3D.AreaBodyStatus.Added"/> or <see cref="Godot.PhysicsServer3D.AreaBodyStatus.Removed"/> depending on whether the other body shape entered or exited the area,</para>
    /// <para>2. an <see cref="Godot.Rid"/> <c>body_rid</c>: the <see cref="Godot.Rid"/> of the body that entered or exited the area,</para>
    /// <para>3. an integer <c>instance_id</c>: the <c>ObjectID</c> attached to the body,</para>
    /// <para>4. an integer <c>body_shape_idx</c>: the index of the shape of the body that entered or exited the area,</para>
    /// <para>5. an integer <c>self_shape_idx</c>: the index of the shape of the area where the body entered or exited.</para>
    /// <para>By counting (or keeping track of) the shapes that enter and exit, it can be determined if a body (with all its shapes) is entering for the first time or exiting for the last time.</para>
    /// </summary>
    public void AreaSetMonitorCallback(Rid area, Callable callback)
    {
        NativeCalls.godot_icall_2_814(MethodBind43, GodotObject.GetPtr(this), area, callback);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind44 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AreaSetAreaMonitorCallback, 3379118538ul);

    /// <summary>
    /// <para>Sets the area's area monitor callback. This callback will be called when any other (shape of an) area enters or exits (a shape of) the given area, and must take the following five parameters:</para>
    /// <para>1. an integer <c>status</c>: either <see cref="Godot.PhysicsServer3D.AreaBodyStatus.Added"/> or <see cref="Godot.PhysicsServer3D.AreaBodyStatus.Removed"/> depending on whether the other area's shape entered or exited the area,</para>
    /// <para>2. an <see cref="Godot.Rid"/> <c>area_rid</c>: the <see cref="Godot.Rid"/> of the other area that entered or exited the area,</para>
    /// <para>3. an integer <c>instance_id</c>: the <c>ObjectID</c> attached to the other area,</para>
    /// <para>4. an integer <c>area_shape_idx</c>: the index of the shape of the other area that entered or exited the area,</para>
    /// <para>5. an integer <c>self_shape_idx</c>: the index of the shape of the area where the other area entered or exited.</para>
    /// <para>By counting (or keeping track of) the shapes that enter and exit, it can be determined if an area (with all its shapes) is entering for the first time or exiting for the last time.</para>
    /// </summary>
    public void AreaSetAreaMonitorCallback(Rid area, Callable callback)
    {
        NativeCalls.godot_icall_2_814(MethodBind44, GodotObject.GetPtr(this), area, callback);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind45 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AreaSetMonitorable, 1265174801ul);

    public void AreaSetMonitorable(Rid area, bool monitorable)
    {
        NativeCalls.godot_icall_2_434(MethodBind45, GodotObject.GetPtr(this), area, monitorable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind46 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AreaSetRayPickable, 1265174801ul);

    /// <summary>
    /// <para>Sets object pickable with rays.</para>
    /// </summary>
    public void AreaSetRayPickable(Rid area, bool enable)
    {
        NativeCalls.godot_icall_2_434(MethodBind46, GodotObject.GetPtr(this), area, enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind47 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyCreate, 529393457ul);

    /// <summary>
    /// <para>Creates a 3D body object in the physics server, and returns the <see cref="Godot.Rid"/> that identifies it. The default settings for the created area include a collision layer and mask set to <c>1</c>, and body mode set to <see cref="Godot.PhysicsServer3D.BodyMode.Rigid"/>.</para>
    /// <para>Use <see cref="Godot.PhysicsServer3DInstance.BodyAddShape(Rid, Rid, Nullable{Transform3D}, bool)"/> to add shapes to it, use <see cref="Godot.PhysicsServer3DInstance.BodySetState(Rid, PhysicsServer3D.BodyState, Variant)"/> to set its transform, and use <see cref="Godot.PhysicsServer3DInstance.BodySetSpace(Rid, Rid)"/> to add the body to a space.</para>
    /// </summary>
    public Rid BodyCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind47, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind48 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodySetSpace, 395945892ul);

    /// <summary>
    /// <para>Assigns a space to the body (see <see cref="Godot.PhysicsServer3DInstance.SpaceCreate()"/>).</para>
    /// </summary>
    public void BodySetSpace(Rid body, Rid space)
    {
        NativeCalls.godot_icall_2_430(MethodBind48, GodotObject.GetPtr(this), body, space);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind49 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyGetSpace, 3814569979ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.Rid"/> of the space assigned to a body.</para>
    /// </summary>
    public Rid BodyGetSpace(Rid body)
    {
        return NativeCalls.godot_icall_1_855(MethodBind49, GodotObject.GetPtr(this), body);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind50 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodySetMode, 606803466ul);

    /// <summary>
    /// <para>Sets the body mode.</para>
    /// </summary>
    public void BodySetMode(Rid body, PhysicsServer3D.BodyMode mode)
    {
        NativeCalls.godot_icall_2_426(MethodBind50, GodotObject.GetPtr(this), body, (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind51 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyGetMode, 2488819728ul);

    /// <summary>
    /// <para>Returns the body mode.</para>
    /// </summary>
    public PhysicsServer3D.BodyMode BodyGetMode(Rid body)
    {
        return (PhysicsServer3D.BodyMode)NativeCalls.godot_icall_1_835(MethodBind51, GodotObject.GetPtr(this), body);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind52 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodySetCollisionLayer, 3411492887ul);

    /// <summary>
    /// <para>Sets the physics layer or layers a body belongs to.</para>
    /// </summary>
    public void BodySetCollisionLayer(Rid body, uint layer)
    {
        NativeCalls.godot_icall_2_856(MethodBind52, GodotObject.GetPtr(this), body, layer);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind53 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyGetCollisionLayer, 2198884583ul);

    /// <summary>
    /// <para>Returns the physics layer or layers a body belongs to.</para>
    /// </summary>
    public uint BodyGetCollisionLayer(Rid body)
    {
        return NativeCalls.godot_icall_1_850(MethodBind53, GodotObject.GetPtr(this), body);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind54 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodySetCollisionMask, 3411492887ul);

    /// <summary>
    /// <para>Sets the physics layer or layers a body can collide with.</para>
    /// </summary>
    public void BodySetCollisionMask(Rid body, uint mask)
    {
        NativeCalls.godot_icall_2_856(MethodBind54, GodotObject.GetPtr(this), body, mask);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind55 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyGetCollisionMask, 2198884583ul);

    /// <summary>
    /// <para>Returns the physics layer or layers a body can collide with.</para>
    /// </summary>
    public uint BodyGetCollisionMask(Rid body)
    {
        return NativeCalls.godot_icall_1_850(MethodBind55, GodotObject.GetPtr(this), body);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind56 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodySetCollisionPriority, 1794382983ul);

    /// <summary>
    /// <para>Sets the body's collision priority.</para>
    /// </summary>
    public void BodySetCollisionPriority(Rid body, float priority)
    {
        NativeCalls.godot_icall_2_816(MethodBind56, GodotObject.GetPtr(this), body, priority);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind57 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyGetCollisionPriority, 866169185ul);

    /// <summary>
    /// <para>Returns the body's collision priority.</para>
    /// </summary>
    public float BodyGetCollisionPriority(Rid body)
    {
        return NativeCalls.godot_icall_1_817(MethodBind57, GodotObject.GetPtr(this), body);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind58 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyAddShape, 3711419014ul);

    /// <summary>
    /// <para>Adds a shape to the body, along with a transform matrix. Shapes are usually referenced by their index, so you should track which shape has a given index.</para>
    /// </summary>
    /// <param name="transform">If the parameter is null, then the default value is <c>Transform3D.Identity</c>.</param>
    public unsafe void BodyAddShape(Rid body, Rid shape, Nullable<Transform3D> transform = null, bool disabled = false)
    {
        Transform3D transformOrDefVal = transform.HasValue ? transform.Value : Transform3D.Identity;
        NativeCalls.godot_icall_4_1000(MethodBind58, GodotObject.GetPtr(this), body, shape, &transformOrDefVal, disabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind59 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodySetShape, 2310537182ul);

    /// <summary>
    /// <para>Substitutes a given body shape by another. The old shape is selected by its index, the new one by its <see cref="Godot.Rid"/>.</para>
    /// </summary>
    public void BodySetShape(Rid body, int shapeIdx, Rid shape)
    {
        NativeCalls.godot_icall_3_833(MethodBind59, GodotObject.GetPtr(this), body, shapeIdx, shape);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind60 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodySetShapeTransform, 675327471ul);

    /// <summary>
    /// <para>Sets the transform matrix for a body shape.</para>
    /// </summary>
    public unsafe void BodySetShapeTransform(Rid body, int shapeIdx, Transform3D transform)
    {
        NativeCalls.godot_icall_3_1001(MethodBind60, GodotObject.GetPtr(this), body, shapeIdx, &transform);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind61 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodySetShapeDisabled, 2658558584ul);

    public void BodySetShapeDisabled(Rid body, int shapeIdx, bool disabled)
    {
        NativeCalls.godot_icall_3_439(MethodBind61, GodotObject.GetPtr(this), body, shapeIdx, disabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind62 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyGetShapeCount, 2198884583ul);

    /// <summary>
    /// <para>Returns the number of shapes assigned to a body.</para>
    /// </summary>
    public int BodyGetShapeCount(Rid body)
    {
        return NativeCalls.godot_icall_1_835(MethodBind62, GodotObject.GetPtr(this), body);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind63 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyGetShape, 1066463050ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.Rid"/> of the nth shape of a body.</para>
    /// </summary>
    public Rid BodyGetShape(Rid body, int shapeIdx)
    {
        return NativeCalls.godot_icall_2_830(MethodBind63, GodotObject.GetPtr(this), body, shapeIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind64 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyGetShapeTransform, 1050775521ul);

    /// <summary>
    /// <para>Returns the transform matrix of a body shape.</para>
    /// </summary>
    public Transform3D BodyGetShapeTransform(Rid body, int shapeIdx)
    {
        return NativeCalls.godot_icall_2_1002(MethodBind64, GodotObject.GetPtr(this), body, shapeIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind65 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyRemoveShape, 3411492887ul);

    /// <summary>
    /// <para>Removes a shape from a body. The shape is not deleted, so it can be reused afterwards.</para>
    /// </summary>
    public void BodyRemoveShape(Rid body, int shapeIdx)
    {
        NativeCalls.godot_icall_2_426(MethodBind65, GodotObject.GetPtr(this), body, shapeIdx);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind66 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyClearShapes, 2722037293ul);

    /// <summary>
    /// <para>Removes all shapes from a body.</para>
    /// </summary>
    public void BodyClearShapes(Rid body)
    {
        NativeCalls.godot_icall_1_286(MethodBind66, GodotObject.GetPtr(this), body);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind67 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyAttachObjectInstanceId, 3411492887ul);

    /// <summary>
    /// <para>Assigns the area to a descendant of <see cref="Godot.GodotObject"/>, so it can exist in the node tree.</para>
    /// </summary>
    public void BodyAttachObjectInstanceId(Rid body, ulong id)
    {
        NativeCalls.godot_icall_2_852(MethodBind67, GodotObject.GetPtr(this), body, id);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind68 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyGetObjectInstanceId, 2198884583ul);

    /// <summary>
    /// <para>Gets the instance ID of the object the area is assigned to.</para>
    /// </summary>
    public ulong BodyGetObjectInstanceId(Rid body)
    {
        return NativeCalls.godot_icall_1_853(MethodBind68, GodotObject.GetPtr(this), body);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind69 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodySetEnableContinuousCollisionDetection, 1265174801ul);

    /// <summary>
    /// <para>If <see langword="true"/>, the continuous collision detection mode is enabled.</para>
    /// <para>Continuous collision detection tries to predict where a moving body will collide, instead of moving it and correcting its movement if it collided.</para>
    /// </summary>
    public void BodySetEnableContinuousCollisionDetection(Rid body, bool enable)
    {
        NativeCalls.godot_icall_2_434(MethodBind69, GodotObject.GetPtr(this), body, enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind70 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyIsContinuousCollisionDetectionEnabled, 4155700596ul);

    /// <summary>
    /// <para>If <see langword="true"/>, the continuous collision detection mode is enabled.</para>
    /// </summary>
    public bool BodyIsContinuousCollisionDetectionEnabled(Rid body)
    {
        return NativeCalls.godot_icall_1_421(MethodBind70, GodotObject.GetPtr(this), body).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind71 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodySetParam, 910941953ul);

    /// <summary>
    /// <para>Sets a body parameter. A list of available parameters is on the <see cref="Godot.PhysicsServer3D.BodyParameter"/> constants.</para>
    /// </summary>
    public void BodySetParam(Rid body, PhysicsServer3D.BodyParameter param, Variant value)
    {
        NativeCalls.godot_icall_3_832(MethodBind71, GodotObject.GetPtr(this), body, (int)param, value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind72 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyGetParam, 3385027841ul);

    /// <summary>
    /// <para>Returns the value of a body parameter. A list of available parameters is on the <see cref="Godot.PhysicsServer3D.BodyParameter"/> constants.</para>
    /// </summary>
    public Variant BodyGetParam(Rid body, PhysicsServer3D.BodyParameter param)
    {
        return NativeCalls.godot_icall_2_828(MethodBind72, GodotObject.GetPtr(this), body, (int)param);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind73 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyResetMassProperties, 2722037293ul);

    /// <summary>
    /// <para>Restores the default inertia and center of mass based on shapes to cancel any custom values previously set using <see cref="Godot.PhysicsServer3DInstance.BodySetParam(Rid, PhysicsServer3D.BodyParameter, Variant)"/>.</para>
    /// </summary>
    public void BodyResetMassProperties(Rid body)
    {
        NativeCalls.godot_icall_1_286(MethodBind73, GodotObject.GetPtr(this), body);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind74 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodySetState, 599977762ul);

    /// <summary>
    /// <para>Sets a body state.</para>
    /// </summary>
    public void BodySetState(Rid body, PhysicsServer3D.BodyState state, Variant value)
    {
        NativeCalls.godot_icall_3_832(MethodBind74, GodotObject.GetPtr(this), body, (int)state, value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind75 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyGetState, 1850449534ul);

    /// <summary>
    /// <para>Returns a body state.</para>
    /// </summary>
    public Variant BodyGetState(Rid body, PhysicsServer3D.BodyState state)
    {
        return NativeCalls.godot_icall_2_828(MethodBind75, GodotObject.GetPtr(this), body, (int)state);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind76 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyApplyCentralImpulse, 3227306858ul);

    /// <summary>
    /// <para>Applies a directional impulse without affecting rotation.</para>
    /// <para>An impulse is time-independent! Applying an impulse every frame would result in a framerate-dependent force. For this reason, it should only be used when simulating one-time impacts (use the "_force" functions otherwise).</para>
    /// <para>This is equivalent to using <see cref="Godot.PhysicsServer3DInstance.BodyApplyImpulse(Rid, Vector3, Nullable{Vector3})"/> at the body's center of mass.</para>
    /// </summary>
    public unsafe void BodyApplyCentralImpulse(Rid body, Vector3 impulse)
    {
        NativeCalls.godot_icall_2_865(MethodBind76, GodotObject.GetPtr(this), body, &impulse);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind77 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyApplyImpulse, 390416203ul);

    /// <summary>
    /// <para>Applies a positioned impulse to the body.</para>
    /// <para>An impulse is time-independent! Applying an impulse every frame would result in a framerate-dependent force. For this reason, it should only be used when simulating one-time impacts (use the "_force" functions otherwise).</para>
    /// <para><paramref name="position"/> is the offset from the body origin in global coordinates.</para>
    /// </summary>
    /// <param name="position">If the parameter is null, then the default value is <c>new Vector3(0.0f, 0.0f, 0.0f)</c>.</param>
    public unsafe void BodyApplyImpulse(Rid body, Vector3 impulse, Nullable<Vector3> position = null)
    {
        Vector3 positionOrDefVal = position.HasValue ? position.Value : new Vector3(0.0f, 0.0f, 0.0f);
        NativeCalls.godot_icall_3_1003(MethodBind77, GodotObject.GetPtr(this), body, &impulse, &positionOrDefVal);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind78 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyApplyTorqueImpulse, 3227306858ul);

    /// <summary>
    /// <para>Applies a rotational impulse to the body without affecting the position.</para>
    /// <para>An impulse is time-independent! Applying an impulse every frame would result in a framerate-dependent force. For this reason, it should only be used when simulating one-time impacts (use the "_force" functions otherwise).</para>
    /// </summary>
    public unsafe void BodyApplyTorqueImpulse(Rid body, Vector3 impulse)
    {
        NativeCalls.godot_icall_2_865(MethodBind78, GodotObject.GetPtr(this), body, &impulse);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind79 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyApplyCentralForce, 3227306858ul);

    /// <summary>
    /// <para>Applies a directional force without affecting rotation. A force is time dependent and meant to be applied every physics update.</para>
    /// <para>This is equivalent to using <see cref="Godot.PhysicsServer3DInstance.BodyApplyForce(Rid, Vector3, Nullable{Vector3})"/> at the body's center of mass.</para>
    /// </summary>
    public unsafe void BodyApplyCentralForce(Rid body, Vector3 force)
    {
        NativeCalls.godot_icall_2_865(MethodBind79, GodotObject.GetPtr(this), body, &force);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind80 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyApplyForce, 390416203ul);

    /// <summary>
    /// <para>Applies a positioned force to the body. A force is time dependent and meant to be applied every physics update.</para>
    /// <para><paramref name="position"/> is the offset from the body origin in global coordinates.</para>
    /// </summary>
    /// <param name="position">If the parameter is null, then the default value is <c>new Vector3(0.0f, 0.0f, 0.0f)</c>.</param>
    public unsafe void BodyApplyForce(Rid body, Vector3 force, Nullable<Vector3> position = null)
    {
        Vector3 positionOrDefVal = position.HasValue ? position.Value : new Vector3(0.0f, 0.0f, 0.0f);
        NativeCalls.godot_icall_3_1003(MethodBind80, GodotObject.GetPtr(this), body, &force, &positionOrDefVal);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind81 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyApplyTorque, 3227306858ul);

    /// <summary>
    /// <para>Applies a rotational force without affecting position. A force is time dependent and meant to be applied every physics update.</para>
    /// </summary>
    public unsafe void BodyApplyTorque(Rid body, Vector3 torque)
    {
        NativeCalls.godot_icall_2_865(MethodBind81, GodotObject.GetPtr(this), body, &torque);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind82 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyAddConstantCentralForce, 3227306858ul);

    /// <summary>
    /// <para>Adds a constant directional force without affecting rotation that keeps being applied over time until cleared with <c>body_set_constant_force(body, Vector3(0, 0, 0))</c>.</para>
    /// <para>This is equivalent to using <see cref="Godot.PhysicsServer3DInstance.BodyAddConstantForce(Rid, Vector3, Nullable{Vector3})"/> at the body's center of mass.</para>
    /// </summary>
    public unsafe void BodyAddConstantCentralForce(Rid body, Vector3 force)
    {
        NativeCalls.godot_icall_2_865(MethodBind82, GodotObject.GetPtr(this), body, &force);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind83 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyAddConstantForce, 390416203ul);

    /// <summary>
    /// <para>Adds a constant positioned force to the body that keeps being applied over time until cleared with <c>body_set_constant_force(body, Vector3(0, 0, 0))</c>.</para>
    /// <para><paramref name="position"/> is the offset from the body origin in global coordinates.</para>
    /// </summary>
    /// <param name="position">If the parameter is null, then the default value is <c>new Vector3(0.0f, 0.0f, 0.0f)</c>.</param>
    public unsafe void BodyAddConstantForce(Rid body, Vector3 force, Nullable<Vector3> position = null)
    {
        Vector3 positionOrDefVal = position.HasValue ? position.Value : new Vector3(0.0f, 0.0f, 0.0f);
        NativeCalls.godot_icall_3_1003(MethodBind83, GodotObject.GetPtr(this), body, &force, &positionOrDefVal);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind84 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyAddConstantTorque, 3227306858ul);

    /// <summary>
    /// <para>Adds a constant rotational force without affecting position that keeps being applied over time until cleared with <c>body_set_constant_torque(body, Vector3(0, 0, 0))</c>.</para>
    /// </summary>
    public unsafe void BodyAddConstantTorque(Rid body, Vector3 torque)
    {
        NativeCalls.godot_icall_2_865(MethodBind84, GodotObject.GetPtr(this), body, &torque);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind85 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodySetConstantForce, 3227306858ul);

    /// <summary>
    /// <para>Sets the body's total constant positional forces applied during each physics update.</para>
    /// <para>See <see cref="Godot.PhysicsServer3DInstance.BodyAddConstantForce(Rid, Vector3, Nullable{Vector3})"/> and <see cref="Godot.PhysicsServer3DInstance.BodyAddConstantCentralForce(Rid, Vector3)"/>.</para>
    /// </summary>
    public unsafe void BodySetConstantForce(Rid body, Vector3 force)
    {
        NativeCalls.godot_icall_2_865(MethodBind85, GodotObject.GetPtr(this), body, &force);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind86 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyGetConstantForce, 531438156ul);

    /// <summary>
    /// <para>Returns the body's total constant positional forces applied during each physics update.</para>
    /// <para>See <see cref="Godot.PhysicsServer3DInstance.BodyAddConstantForce(Rid, Vector3, Nullable{Vector3})"/> and <see cref="Godot.PhysicsServer3DInstance.BodyAddConstantCentralForce(Rid, Vector3)"/>.</para>
    /// </summary>
    public Vector3 BodyGetConstantForce(Rid body)
    {
        return NativeCalls.godot_icall_1_866(MethodBind86, GodotObject.GetPtr(this), body);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind87 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodySetConstantTorque, 3227306858ul);

    /// <summary>
    /// <para>Sets the body's total constant rotational forces applied during each physics update.</para>
    /// <para>See <see cref="Godot.PhysicsServer3DInstance.BodyAddConstantTorque(Rid, Vector3)"/>.</para>
    /// </summary>
    public unsafe void BodySetConstantTorque(Rid body, Vector3 torque)
    {
        NativeCalls.godot_icall_2_865(MethodBind87, GodotObject.GetPtr(this), body, &torque);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind88 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyGetConstantTorque, 531438156ul);

    /// <summary>
    /// <para>Returns the body's total constant rotational forces applied during each physics update.</para>
    /// <para>See <see cref="Godot.PhysicsServer3DInstance.BodyAddConstantTorque(Rid, Vector3)"/>.</para>
    /// </summary>
    public Vector3 BodyGetConstantTorque(Rid body)
    {
        return NativeCalls.godot_icall_1_866(MethodBind88, GodotObject.GetPtr(this), body);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind89 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodySetAxisVelocity, 3227306858ul);

    /// <summary>
    /// <para>Sets an axis velocity. The velocity in the given vector axis will be set as the given vector length. This is useful for jumping behavior.</para>
    /// </summary>
    public unsafe void BodySetAxisVelocity(Rid body, Vector3 axisVelocity)
    {
        NativeCalls.godot_icall_2_865(MethodBind89, GodotObject.GetPtr(this), body, &axisVelocity);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind90 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodySetAxisLock, 2020836892ul);

    public void BodySetAxisLock(Rid body, PhysicsServer3D.BodyAxis axis, bool @lock)
    {
        NativeCalls.godot_icall_3_439(MethodBind90, GodotObject.GetPtr(this), body, (int)axis, @lock.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind91 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyIsAxisLocked, 587853580ul);

    public bool BodyIsAxisLocked(Rid body, PhysicsServer3D.BodyAxis axis)
    {
        return NativeCalls.godot_icall_2_826(MethodBind91, GodotObject.GetPtr(this), body, (int)axis).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind92 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyAddCollisionException, 395945892ul);

    /// <summary>
    /// <para>Adds a body to the list of bodies exempt from collisions.</para>
    /// </summary>
    public void BodyAddCollisionException(Rid body, Rid exceptedBody)
    {
        NativeCalls.godot_icall_2_430(MethodBind92, GodotObject.GetPtr(this), body, exceptedBody);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind93 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyRemoveCollisionException, 395945892ul);

    /// <summary>
    /// <para>Removes a body from the list of bodies exempt from collisions.</para>
    /// <para>Continuous collision detection tries to predict where a moving body will collide, instead of moving it and correcting its movement if it collided.</para>
    /// </summary>
    public void BodyRemoveCollisionException(Rid body, Rid exceptedBody)
    {
        NativeCalls.godot_icall_2_430(MethodBind93, GodotObject.GetPtr(this), body, exceptedBody);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind94 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodySetMaxContactsReported, 3411492887ul);

    /// <summary>
    /// <para>Sets the maximum contacts to report. Bodies can keep a log of the contacts with other bodies. This is enabled by setting the maximum number of contacts reported to a number greater than 0.</para>
    /// </summary>
    public void BodySetMaxContactsReported(Rid body, int amount)
    {
        NativeCalls.godot_icall_2_426(MethodBind94, GodotObject.GetPtr(this), body, amount);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind95 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyGetMaxContactsReported, 2198884583ul);

    /// <summary>
    /// <para>Returns the maximum contacts that can be reported. See <see cref="Godot.PhysicsServer3DInstance.BodySetMaxContactsReported(Rid, int)"/>.</para>
    /// </summary>
    public int BodyGetMaxContactsReported(Rid body)
    {
        return NativeCalls.godot_icall_1_835(MethodBind95, GodotObject.GetPtr(this), body);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind96 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodySetOmitForceIntegration, 1265174801ul);

    /// <summary>
    /// <para>Sets whether the body omits the standard force integration. If <paramref name="enable"/> is <see langword="true"/>, the body will not automatically use applied forces, torques, and damping to update the body's linear and angular velocity. In this case, <see cref="Godot.PhysicsServer3DInstance.BodySetForceIntegrationCallback(Rid, Callable, Variant)"/> can be used to manually update the linear and angular velocity instead.</para>
    /// <para>This method is called when the property <see cref="Godot.RigidBody3D.CustomIntegrator"/> is set.</para>
    /// </summary>
    public void BodySetOmitForceIntegration(Rid body, bool enable)
    {
        NativeCalls.godot_icall_2_434(MethodBind96, GodotObject.GetPtr(this), body, enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind97 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyIsOmittingForceIntegration, 4155700596ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the body is omitting the standard force integration. See <see cref="Godot.PhysicsServer3DInstance.BodySetOmitForceIntegration(Rid, bool)"/>.</para>
    /// </summary>
    public bool BodyIsOmittingForceIntegration(Rid body)
    {
        return NativeCalls.godot_icall_1_421(MethodBind97, GodotObject.GetPtr(this), body).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind98 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodySetStateSyncCallback, 3379118538ul);

    /// <summary>
    /// <para>Sets the body's state synchronization callback function to <paramref name="callable"/>. Use an empty <see cref="Godot.Callable"/> (<c>Callable()</c>) to clear the callback.</para>
    /// <para>The function <paramref name="callable"/> will be called every physics frame, assuming that the body was active during the previous physics tick, and can be used to fetch the latest state from the physics server.</para>
    /// <para>The function <paramref name="callable"/> must take the following parameters:</para>
    /// <para>1. <c>state</c>: a <see cref="Godot.PhysicsDirectBodyState3D"/>, used to retrieve the body's state.</para>
    /// </summary>
    public void BodySetStateSyncCallback(Rid body, Callable callable)
    {
        NativeCalls.godot_icall_2_814(MethodBind98, GodotObject.GetPtr(this), body, callable);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind99 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodySetForceIntegrationCallback, 3059434249ul);

    /// <summary>
    /// <para>Sets the body's custom force integration callback function to <paramref name="callable"/>. Use an empty <see cref="Godot.Callable"/> (<c>Callable()</c>) to clear the custom callback.</para>
    /// <para>The function <paramref name="callable"/> will be called every physics tick, before the standard force integration (see <see cref="Godot.PhysicsServer3DInstance.BodySetOmitForceIntegration(Rid, bool)"/>). It can be used for example to update the body's linear and angular velocity based on contact with other bodies.</para>
    /// <para>If <paramref name="userdata"/> is not <see langword="null"/>, the function <paramref name="callable"/> must take the following two parameters:</para>
    /// <para>1. <c>state</c>: a <see cref="Godot.PhysicsDirectBodyState3D"/>, used to retrieve and modify the body's state,</para>
    /// <para>2. <c>userdata</c>: a <see cref="Godot.Variant"/>; its value will be the <paramref name="userdata"/> passed into this method.</para>
    /// <para>If <paramref name="userdata"/> is <see langword="null"/>, then <paramref name="callable"/> must take only the <c>state</c> parameter.</para>
    /// </summary>
    public void BodySetForceIntegrationCallback(Rid body, Callable callable, Variant userdata = default)
    {
        NativeCalls.godot_icall_3_995(MethodBind99, GodotObject.GetPtr(this), body, callable, userdata);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind100 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodySetRayPickable, 1265174801ul);

    /// <summary>
    /// <para>Sets the body pickable with rays if <paramref name="enable"/> is set.</para>
    /// </summary>
    public void BodySetRayPickable(Rid body, bool enable)
    {
        NativeCalls.godot_icall_2_434(MethodBind100, GodotObject.GetPtr(this), body, enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind101 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyTestMotion, 1944921792ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if a collision would result from moving along a motion vector from a given point in space. <see cref="Godot.PhysicsTestMotionParameters3D"/> is passed to set motion parameters. <see cref="Godot.PhysicsTestMotionResult3D"/> can be passed to return additional information.</para>
    /// </summary>
    public bool BodyTestMotion(Rid body, PhysicsTestMotionParameters3D parameters, PhysicsTestMotionResult3D result = default)
    {
        return NativeCalls.godot_icall_3_996(MethodBind101, GodotObject.GetPtr(this), body, GodotObject.GetPtr(parameters), GodotObject.GetPtr(result)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind102 = ClassDB_get_method_with_compatibility(NativeName, MethodName.BodyGetDirectState, 3029727957ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.PhysicsDirectBodyState3D"/> of the body. Returns <see langword="null"/> if the body is destroyed or removed from the physics space.</para>
    /// </summary>
    public PhysicsDirectBodyState3D BodyGetDirectState(Rid body)
    {
        return (PhysicsDirectBodyState3D)NativeCalls.godot_icall_1_938(MethodBind102, GodotObject.GetPtr(this), body);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind103 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SoftBodyCreate, 529393457ul);

    /// <summary>
    /// <para>Creates a new soft body and returns its internal <see cref="Godot.Rid"/>.</para>
    /// </summary>
    public Rid SoftBodyCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind103, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind104 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SoftBodyUpdateRenderingServer, 2218179753ul);

    /// <summary>
    /// <para>Requests that the physics server updates the rendering server with the latest positions of the given soft body's points through the <paramref name="renderingServerHandler"/> interface.</para>
    /// </summary>
    public void SoftBodyUpdateRenderingServer(Rid body, PhysicsServer3DRenderingServerHandler renderingServerHandler)
    {
        NativeCalls.godot_icall_2_858(MethodBind104, GodotObject.GetPtr(this), body, GodotObject.GetPtr(renderingServerHandler));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind105 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SoftBodySetSpace, 395945892ul);

    /// <summary>
    /// <para>Assigns a space to the given soft body (see <see cref="Godot.PhysicsServer3DInstance.SpaceCreate()"/>).</para>
    /// </summary>
    public void SoftBodySetSpace(Rid body, Rid space)
    {
        NativeCalls.godot_icall_2_430(MethodBind105, GodotObject.GetPtr(this), body, space);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind106 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SoftBodyGetSpace, 3814569979ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.Rid"/> of the space assigned to the given soft body.</para>
    /// </summary>
    public Rid SoftBodyGetSpace(Rid body)
    {
        return NativeCalls.godot_icall_1_855(MethodBind106, GodotObject.GetPtr(this), body);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind107 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SoftBodySetMesh, 395945892ul);

    /// <summary>
    /// <para>Sets the mesh of the given soft body.</para>
    /// </summary>
    public void SoftBodySetMesh(Rid body, Rid mesh)
    {
        NativeCalls.godot_icall_2_430(MethodBind107, GodotObject.GetPtr(this), body, mesh);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind108 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SoftBodyGetBounds, 974181306ul);

    /// <summary>
    /// <para>Returns the bounds of the given soft body in global coordinates.</para>
    /// </summary>
    public Aabb SoftBodyGetBounds(Rid body)
    {
        return NativeCalls.godot_icall_1_876(MethodBind108, GodotObject.GetPtr(this), body);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind109 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SoftBodySetCollisionLayer, 3411492887ul);

    /// <summary>
    /// <para>Sets the physics layer or layers the given soft body belongs to.</para>
    /// </summary>
    public void SoftBodySetCollisionLayer(Rid body, uint layer)
    {
        NativeCalls.godot_icall_2_856(MethodBind109, GodotObject.GetPtr(this), body, layer);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind110 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SoftBodyGetCollisionLayer, 2198884583ul);

    /// <summary>
    /// <para>Returns the physics layer or layers that the given soft body belongs to.</para>
    /// </summary>
    public uint SoftBodyGetCollisionLayer(Rid body)
    {
        return NativeCalls.godot_icall_1_850(MethodBind110, GodotObject.GetPtr(this), body);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind111 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SoftBodySetCollisionMask, 3411492887ul);

    /// <summary>
    /// <para>Sets the physics layer or layers the given soft body can collide with.</para>
    /// </summary>
    public void SoftBodySetCollisionMask(Rid body, uint mask)
    {
        NativeCalls.godot_icall_2_856(MethodBind111, GodotObject.GetPtr(this), body, mask);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind112 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SoftBodyGetCollisionMask, 2198884583ul);

    /// <summary>
    /// <para>Returns the physics layer or layers that the given soft body can collide with.</para>
    /// </summary>
    public uint SoftBodyGetCollisionMask(Rid body)
    {
        return NativeCalls.godot_icall_1_850(MethodBind112, GodotObject.GetPtr(this), body);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind113 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SoftBodyAddCollisionException, 395945892ul);

    /// <summary>
    /// <para>Adds the given body to the list of bodies exempt from collisions.</para>
    /// </summary>
    public void SoftBodyAddCollisionException(Rid body, Rid bodyB)
    {
        NativeCalls.godot_icall_2_430(MethodBind113, GodotObject.GetPtr(this), body, bodyB);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind114 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SoftBodyRemoveCollisionException, 395945892ul);

    /// <summary>
    /// <para>Removes the given body from the list of bodies exempt from collisions.</para>
    /// </summary>
    public void SoftBodyRemoveCollisionException(Rid body, Rid bodyB)
    {
        NativeCalls.godot_icall_2_430(MethodBind114, GodotObject.GetPtr(this), body, bodyB);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind115 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SoftBodySetState, 599977762ul);

    /// <summary>
    /// <para>Sets the given body state for the given body.</para>
    /// <para><b>Note:</b> Godot's default physics implementation does not support <see cref="Godot.PhysicsServer3D.BodyState.LinearVelocity"/>, <see cref="Godot.PhysicsServer3D.BodyState.AngularVelocity"/>, <see cref="Godot.PhysicsServer3D.BodyState.Sleeping"/>, or <see cref="Godot.PhysicsServer3D.BodyState.CanSleep"/>.</para>
    /// </summary>
    public void SoftBodySetState(Rid body, PhysicsServer3D.BodyState state, Variant variant)
    {
        NativeCalls.godot_icall_3_832(MethodBind115, GodotObject.GetPtr(this), body, (int)state, variant);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind116 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SoftBodyGetState, 1850449534ul);

    /// <summary>
    /// <para>Returns the given soft body state.</para>
    /// <para><b>Note:</b> Godot's default physics implementation does not support <see cref="Godot.PhysicsServer3D.BodyState.LinearVelocity"/>, <see cref="Godot.PhysicsServer3D.BodyState.AngularVelocity"/>, <see cref="Godot.PhysicsServer3D.BodyState.Sleeping"/>, or <see cref="Godot.PhysicsServer3D.BodyState.CanSleep"/>.</para>
    /// </summary>
    public Variant SoftBodyGetState(Rid body, PhysicsServer3D.BodyState state)
    {
        return NativeCalls.godot_icall_2_828(MethodBind116, GodotObject.GetPtr(this), body, (int)state);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind117 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SoftBodySetTransform, 3935195649ul);

    /// <summary>
    /// <para>Sets the global transform of the given soft body.</para>
    /// </summary>
    public unsafe void SoftBodySetTransform(Rid body, Transform3D transform)
    {
        NativeCalls.godot_icall_2_873(MethodBind117, GodotObject.GetPtr(this), body, &transform);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind118 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SoftBodySetRayPickable, 1265174801ul);

    /// <summary>
    /// <para>Sets whether the given soft body will be pickable when using object picking.</para>
    /// </summary>
    public void SoftBodySetRayPickable(Rid body, bool enable)
    {
        NativeCalls.godot_icall_2_434(MethodBind118, GodotObject.GetPtr(this), body, enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind119 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SoftBodySetSimulationPrecision, 3411492887ul);

    /// <summary>
    /// <para>Sets the simulation precision of the given soft body. Increasing this value will improve the resulting simulation, but can affect performance. Use with care.</para>
    /// </summary>
    public void SoftBodySetSimulationPrecision(Rid body, int simulationPrecision)
    {
        NativeCalls.godot_icall_2_426(MethodBind119, GodotObject.GetPtr(this), body, simulationPrecision);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind120 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SoftBodyGetSimulationPrecision, 2198884583ul);

    /// <summary>
    /// <para>Returns the simulation precision of the given soft body.</para>
    /// </summary>
    public int SoftBodyGetSimulationPrecision(Rid body)
    {
        return NativeCalls.godot_icall_1_835(MethodBind120, GodotObject.GetPtr(this), body);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind121 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SoftBodySetTotalMass, 1794382983ul);

    /// <summary>
    /// <para>Sets the total mass for the given soft body.</para>
    /// </summary>
    public void SoftBodySetTotalMass(Rid body, float totalMass)
    {
        NativeCalls.godot_icall_2_816(MethodBind121, GodotObject.GetPtr(this), body, totalMass);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind122 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SoftBodyGetTotalMass, 866169185ul);

    /// <summary>
    /// <para>Returns the total mass assigned to the given soft body.</para>
    /// </summary>
    public float SoftBodyGetTotalMass(Rid body)
    {
        return NativeCalls.godot_icall_1_817(MethodBind122, GodotObject.GetPtr(this), body);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind123 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SoftBodySetLinearStiffness, 1794382983ul);

    /// <summary>
    /// <para>Sets the linear stiffness of the given soft body. Higher values will result in a stiffer body, while lower values will increase the body's ability to bend. The value can be between <c>0.0</c> and <c>1.0</c> (inclusive).</para>
    /// </summary>
    public void SoftBodySetLinearStiffness(Rid body, float stiffness)
    {
        NativeCalls.godot_icall_2_816(MethodBind123, GodotObject.GetPtr(this), body, stiffness);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind124 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SoftBodyGetLinearStiffness, 866169185ul);

    /// <summary>
    /// <para>Returns the linear stiffness of the given soft body.</para>
    /// </summary>
    public float SoftBodyGetLinearStiffness(Rid body)
    {
        return NativeCalls.godot_icall_1_817(MethodBind124, GodotObject.GetPtr(this), body);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind125 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SoftBodySetShrinkingFactor, 1794382983ul);

    /// <summary>
    /// <para>Sets the shrinking factor of the given soft body.</para>
    /// </summary>
    public void SoftBodySetShrinkingFactor(Rid body, float shrinkingFactor)
    {
        NativeCalls.godot_icall_2_816(MethodBind125, GodotObject.GetPtr(this), body, shrinkingFactor);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind126 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SoftBodyGetShrinkingFactor, 866169185ul);

    /// <summary>
    /// <para>Returns the shrinking factor of the given soft body.</para>
    /// </summary>
    public float SoftBodyGetShrinkingFactor(Rid body)
    {
        return NativeCalls.godot_icall_1_817(MethodBind126, GodotObject.GetPtr(this), body);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind127 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SoftBodySetPressureCoefficient, 1794382983ul);

    /// <summary>
    /// <para>Sets the pressure coefficient of the given soft body. Simulates pressure build-up from inside this body. Higher values increase the strength of this effect.</para>
    /// </summary>
    public void SoftBodySetPressureCoefficient(Rid body, float pressureCoefficient)
    {
        NativeCalls.godot_icall_2_816(MethodBind127, GodotObject.GetPtr(this), body, pressureCoefficient);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind128 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SoftBodyGetPressureCoefficient, 866169185ul);

    /// <summary>
    /// <para>Returns the pressure coefficient of the given soft body.</para>
    /// </summary>
    public float SoftBodyGetPressureCoefficient(Rid body)
    {
        return NativeCalls.godot_icall_1_817(MethodBind128, GodotObject.GetPtr(this), body);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind129 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SoftBodySetDampingCoefficient, 1794382983ul);

    /// <summary>
    /// <para>Sets the damping coefficient of the given soft body. Higher values will slow down the body more noticeably when forces are applied.</para>
    /// </summary>
    public void SoftBodySetDampingCoefficient(Rid body, float dampingCoefficient)
    {
        NativeCalls.godot_icall_2_816(MethodBind129, GodotObject.GetPtr(this), body, dampingCoefficient);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind130 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SoftBodyGetDampingCoefficient, 866169185ul);

    /// <summary>
    /// <para>Returns the damping coefficient of the given soft body.</para>
    /// </summary>
    public float SoftBodyGetDampingCoefficient(Rid body)
    {
        return NativeCalls.godot_icall_1_817(MethodBind130, GodotObject.GetPtr(this), body);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind131 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SoftBodySetDragCoefficient, 1794382983ul);

    /// <summary>
    /// <para>Sets the drag coefficient of the given soft body. Higher values increase this body's air resistance.</para>
    /// <para><b>Note:</b> This value is currently unused by Godot's default physics implementation.</para>
    /// </summary>
    public void SoftBodySetDragCoefficient(Rid body, float dragCoefficient)
    {
        NativeCalls.godot_icall_2_816(MethodBind131, GodotObject.GetPtr(this), body, dragCoefficient);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind132 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SoftBodyGetDragCoefficient, 866169185ul);

    /// <summary>
    /// <para>Returns the drag coefficient of the given soft body.</para>
    /// </summary>
    public float SoftBodyGetDragCoefficient(Rid body)
    {
        return NativeCalls.godot_icall_1_817(MethodBind132, GodotObject.GetPtr(this), body);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind133 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SoftBodyMovePoint, 831953689ul);

    /// <summary>
    /// <para>Moves the given soft body point to a position in global coordinates.</para>
    /// </summary>
    public unsafe void SoftBodyMovePoint(Rid body, int pointIndex, Vector3 globalPosition)
    {
        NativeCalls.godot_icall_3_1004(MethodBind133, GodotObject.GetPtr(this), body, pointIndex, &globalPosition);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind134 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SoftBodyGetPointGlobalPosition, 3440143363ul);

    /// <summary>
    /// <para>Returns the current position of the given soft body point in global coordinates.</para>
    /// </summary>
    public Vector3 SoftBodyGetPointGlobalPosition(Rid body, int pointIndex)
    {
        return NativeCalls.godot_icall_2_875(MethodBind134, GodotObject.GetPtr(this), body, pointIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind135 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SoftBodyRemoveAllPinnedPoints, 2722037293ul);

    /// <summary>
    /// <para>Unpins all points of the given soft body.</para>
    /// </summary>
    public void SoftBodyRemoveAllPinnedPoints(Rid body)
    {
        NativeCalls.godot_icall_1_286(MethodBind135, GodotObject.GetPtr(this), body);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind136 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SoftBodyPinPoint, 2658558584ul);

    /// <summary>
    /// <para>Pins or unpins the given soft body point based on the value of <paramref name="pin"/>.</para>
    /// <para><b>Note:</b> Pinning a point effectively makes it kinematic, preventing it from being affected by forces, but you can still move it using <see cref="Godot.PhysicsServer3DInstance.SoftBodyMovePoint(Rid, int, Vector3)"/>.</para>
    /// </summary>
    public void SoftBodyPinPoint(Rid body, int pointIndex, bool pin)
    {
        NativeCalls.godot_icall_3_439(MethodBind136, GodotObject.GetPtr(this), body, pointIndex, pin.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind137 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SoftBodyIsPointPinned, 3120086654ul);

    /// <summary>
    /// <para>Returns whether the given soft body point is pinned.</para>
    /// </summary>
    public bool SoftBodyIsPointPinned(Rid body, int pointIndex)
    {
        return NativeCalls.godot_icall_2_826(MethodBind137, GodotObject.GetPtr(this), body, pointIndex).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind138 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SoftBodyApplyPointImpulse, 831953689ul);

    /// <summary>
    /// <para>Applies an impulse to a point.</para>
    /// <para>An impulse is time-independent! Applying an impulse every frame would result in a framerate-dependent force. For this reason, it should only be used when simulating one-time impacts (use the "_force" functions otherwise).</para>
    /// </summary>
    public unsafe void SoftBodyApplyPointImpulse(Rid body, int pointIndex, Vector3 impulse)
    {
        NativeCalls.godot_icall_3_1004(MethodBind138, GodotObject.GetPtr(this), body, pointIndex, &impulse);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind139 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SoftBodyApplyPointForce, 831953689ul);

    /// <summary>
    /// <para>Applies a force to a point. A force is time dependent and meant to be applied every physics update.</para>
    /// </summary>
    public unsafe void SoftBodyApplyPointForce(Rid body, int pointIndex, Vector3 force)
    {
        NativeCalls.godot_icall_3_1004(MethodBind139, GodotObject.GetPtr(this), body, pointIndex, &force);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind140 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SoftBodyApplyCentralImpulse, 3227306858ul);

    /// <summary>
    /// <para>Distributes and applies an impulse to all points.</para>
    /// <para>An impulse is time-independent! Applying an impulse every frame would result in a framerate-dependent force. For this reason, it should only be used when simulating one-time impacts (use the "_force" functions otherwise).</para>
    /// </summary>
    public unsafe void SoftBodyApplyCentralImpulse(Rid body, Vector3 impulse)
    {
        NativeCalls.godot_icall_2_865(MethodBind140, GodotObject.GetPtr(this), body, &impulse);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind141 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SoftBodyApplyCentralForce, 3227306858ul);

    /// <summary>
    /// <para>Distributes and applies a force to all points. A force is time dependent and meant to be applied every physics update.</para>
    /// </summary>
    public unsafe void SoftBodyApplyCentralForce(Rid body, Vector3 force)
    {
        NativeCalls.godot_icall_2_865(MethodBind141, GodotObject.GetPtr(this), body, &force);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind142 = ClassDB_get_method_with_compatibility(NativeName, MethodName.JointCreate, 529393457ul);

    public Rid JointCreate()
    {
        return NativeCalls.godot_icall_0_238(MethodBind142, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind143 = ClassDB_get_method_with_compatibility(NativeName, MethodName.JointClear, 2722037293ul);

    public void JointClear(Rid joint)
    {
        NativeCalls.godot_icall_1_286(MethodBind143, GodotObject.GetPtr(this), joint);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind144 = ClassDB_get_method_with_compatibility(NativeName, MethodName.JointMakePin, 4280171926ul);

    public unsafe void JointMakePin(Rid joint, Rid bodyA, Vector3 localA, Rid bodyB, Vector3 localB)
    {
        NativeCalls.godot_icall_5_1005(MethodBind144, GodotObject.GetPtr(this), joint, bodyA, &localA, bodyB, &localB);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind145 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PinJointSetParam, 810685294ul);

    /// <summary>
    /// <para>Sets a pin joint parameter.</para>
    /// </summary>
    public void PinJointSetParam(Rid joint, PhysicsServer3D.PinJointParam param, float value)
    {
        NativeCalls.godot_icall_3_988(MethodBind145, GodotObject.GetPtr(this), joint, (int)param, value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind146 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PinJointGetParam, 2817972347ul);

    /// <summary>
    /// <para>Gets a pin joint parameter.</para>
    /// </summary>
    public float PinJointGetParam(Rid joint, PhysicsServer3D.PinJointParam param)
    {
        return NativeCalls.godot_icall_2_989(MethodBind146, GodotObject.GetPtr(this), joint, (int)param);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind147 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PinJointSetLocalA, 3227306858ul);

    /// <summary>
    /// <para>Sets position of the joint in the local space of body a of the joint.</para>
    /// </summary>
    public unsafe void PinJointSetLocalA(Rid joint, Vector3 localA)
    {
        NativeCalls.godot_icall_2_865(MethodBind147, GodotObject.GetPtr(this), joint, &localA);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind148 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PinJointGetLocalA, 531438156ul);

    /// <summary>
    /// <para>Returns position of the joint in the local space of body a of the joint.</para>
    /// </summary>
    public Vector3 PinJointGetLocalA(Rid joint)
    {
        return NativeCalls.godot_icall_1_866(MethodBind148, GodotObject.GetPtr(this), joint);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind149 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PinJointSetLocalB, 3227306858ul);

    /// <summary>
    /// <para>Sets position of the joint in the local space of body b of the joint.</para>
    /// </summary>
    public unsafe void PinJointSetLocalB(Rid joint, Vector3 localB)
    {
        NativeCalls.godot_icall_2_865(MethodBind149, GodotObject.GetPtr(this), joint, &localB);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind150 = ClassDB_get_method_with_compatibility(NativeName, MethodName.PinJointGetLocalB, 531438156ul);

    /// <summary>
    /// <para>Returns position of the joint in the local space of body b of the joint.</para>
    /// </summary>
    public Vector3 PinJointGetLocalB(Rid joint)
    {
        return NativeCalls.godot_icall_1_866(MethodBind150, GodotObject.GetPtr(this), joint);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind151 = ClassDB_get_method_with_compatibility(NativeName, MethodName.JointMakeHinge, 1684107643ul);

    public unsafe void JointMakeHinge(Rid joint, Rid bodyA, Transform3D hingeA, Rid bodyB, Transform3D hingeB)
    {
        NativeCalls.godot_icall_5_1006(MethodBind151, GodotObject.GetPtr(this), joint, bodyA, &hingeA, bodyB, &hingeB);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind152 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HingeJointSetParam, 3165502333ul);

    /// <summary>
    /// <para>Sets a hinge joint parameter.</para>
    /// </summary>
    public void HingeJointSetParam(Rid joint, PhysicsServer3D.HingeJointParam param, float value)
    {
        NativeCalls.godot_icall_3_988(MethodBind152, GodotObject.GetPtr(this), joint, (int)param, value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind153 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HingeJointGetParam, 2129207581ul);

    /// <summary>
    /// <para>Gets a hinge joint parameter.</para>
    /// </summary>
    public float HingeJointGetParam(Rid joint, PhysicsServer3D.HingeJointParam param)
    {
        return NativeCalls.godot_icall_2_989(MethodBind153, GodotObject.GetPtr(this), joint, (int)param);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind154 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HingeJointSetFlag, 1601626188ul);

    /// <summary>
    /// <para>Sets a hinge joint flag.</para>
    /// </summary>
    public void HingeJointSetFlag(Rid joint, PhysicsServer3D.HingeJointFlag flag, bool enabled)
    {
        NativeCalls.godot_icall_3_439(MethodBind154, GodotObject.GetPtr(this), joint, (int)flag, enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind155 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HingeJointGetFlag, 4165147865ul);

    /// <summary>
    /// <para>Gets a hinge joint flag.</para>
    /// </summary>
    public bool HingeJointGetFlag(Rid joint, PhysicsServer3D.HingeJointFlag flag)
    {
        return NativeCalls.godot_icall_2_826(MethodBind155, GodotObject.GetPtr(this), joint, (int)flag).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind156 = ClassDB_get_method_with_compatibility(NativeName, MethodName.JointMakeSlider, 1684107643ul);

    public unsafe void JointMakeSlider(Rid joint, Rid bodyA, Transform3D localRefA, Rid bodyB, Transform3D localRefB)
    {
        NativeCalls.godot_icall_5_1006(MethodBind156, GodotObject.GetPtr(this), joint, bodyA, &localRefA, bodyB, &localRefB);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind157 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SliderJointSetParam, 2264833593ul);

    /// <summary>
    /// <para>Gets a slider joint parameter.</para>
    /// </summary>
    public void SliderJointSetParam(Rid joint, PhysicsServer3D.SliderJointParam param, float value)
    {
        NativeCalls.godot_icall_3_988(MethodBind157, GodotObject.GetPtr(this), joint, (int)param, value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind158 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SliderJointGetParam, 3498644957ul);

    /// <summary>
    /// <para>Gets a slider joint parameter.</para>
    /// </summary>
    public float SliderJointGetParam(Rid joint, PhysicsServer3D.SliderJointParam param)
    {
        return NativeCalls.godot_icall_2_989(MethodBind158, GodotObject.GetPtr(this), joint, (int)param);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind159 = ClassDB_get_method_with_compatibility(NativeName, MethodName.JointMakeConeTwist, 1684107643ul);

    public unsafe void JointMakeConeTwist(Rid joint, Rid bodyA, Transform3D localRefA, Rid bodyB, Transform3D localRefB)
    {
        NativeCalls.godot_icall_5_1006(MethodBind159, GodotObject.GetPtr(this), joint, bodyA, &localRefA, bodyB, &localRefB);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind160 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ConeTwistJointSetParam, 808587618ul);

    /// <summary>
    /// <para>Sets a cone twist joint parameter.</para>
    /// </summary>
    public void ConeTwistJointSetParam(Rid joint, PhysicsServer3D.ConeTwistJointParam param, float value)
    {
        NativeCalls.godot_icall_3_988(MethodBind160, GodotObject.GetPtr(this), joint, (int)param, value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind161 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ConeTwistJointGetParam, 1134789658ul);

    /// <summary>
    /// <para>Gets a cone twist joint parameter.</para>
    /// </summary>
    public float ConeTwistJointGetParam(Rid joint, PhysicsServer3D.ConeTwistJointParam param)
    {
        return NativeCalls.godot_icall_2_989(MethodBind161, GodotObject.GetPtr(this), joint, (int)param);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind162 = ClassDB_get_method_with_compatibility(NativeName, MethodName.JointGetType, 4290791900ul);

    /// <summary>
    /// <para>Returns the type of the Joint3D.</para>
    /// </summary>
    public PhysicsServer3D.JointType JointGetType(Rid joint)
    {
        return (PhysicsServer3D.JointType)NativeCalls.godot_icall_1_835(MethodBind162, GodotObject.GetPtr(this), joint);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind163 = ClassDB_get_method_with_compatibility(NativeName, MethodName.JointSetSolverPriority, 3411492887ul);

    /// <summary>
    /// <para>Sets the priority value of the Joint3D.</para>
    /// </summary>
    public void JointSetSolverPriority(Rid joint, int priority)
    {
        NativeCalls.godot_icall_2_426(MethodBind163, GodotObject.GetPtr(this), joint, priority);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind164 = ClassDB_get_method_with_compatibility(NativeName, MethodName.JointGetSolverPriority, 2198884583ul);

    /// <summary>
    /// <para>Gets the priority value of the Joint3D.</para>
    /// </summary>
    public int JointGetSolverPriority(Rid joint)
    {
        return NativeCalls.godot_icall_1_835(MethodBind164, GodotObject.GetPtr(this), joint);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind165 = ClassDB_get_method_with_compatibility(NativeName, MethodName.JointDisableCollisionsBetweenBodies, 1265174801ul);

    /// <summary>
    /// <para>Sets whether the bodies attached to the <see cref="Godot.Joint3D"/> will collide with each other.</para>
    /// </summary>
    public void JointDisableCollisionsBetweenBodies(Rid joint, bool disable)
    {
        NativeCalls.godot_icall_2_434(MethodBind165, GodotObject.GetPtr(this), joint, disable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind166 = ClassDB_get_method_with_compatibility(NativeName, MethodName.JointIsDisabledCollisionsBetweenBodies, 4155700596ul);

    /// <summary>
    /// <para>Returns whether the bodies attached to the <see cref="Godot.Joint3D"/> will collide with each other.</para>
    /// </summary>
    public bool JointIsDisabledCollisionsBetweenBodies(Rid joint)
    {
        return NativeCalls.godot_icall_1_421(MethodBind166, GodotObject.GetPtr(this), joint).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind167 = ClassDB_get_method_with_compatibility(NativeName, MethodName.JointMakeGeneric6Dof, 1684107643ul);

    /// <summary>
    /// <para>Make the joint a generic six degrees of freedom (6DOF) joint. Use <see cref="Godot.PhysicsServer3DInstance.Generic6DofJointSetFlag(Rid, Vector3.Axis, PhysicsServer3D.G6DofJointAxisFlag, bool)"/> and <see cref="Godot.PhysicsServer3DInstance.Generic6DofJointSetParam(Rid, Vector3.Axis, PhysicsServer3D.G6DofJointAxisParam, float)"/> to set the joint's flags and parameters respectively.</para>
    /// </summary>
    public unsafe void JointMakeGeneric6Dof(Rid joint, Rid bodyA, Transform3D localRefA, Rid bodyB, Transform3D localRefB)
    {
        NativeCalls.godot_icall_5_1006(MethodBind167, GodotObject.GetPtr(this), joint, bodyA, &localRefA, bodyB, &localRefB);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind168 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Generic6DofJointSetParam, 2600081391ul);

    /// <summary>
    /// <para>Sets the value of a given generic 6DOF joint parameter.</para>
    /// </summary>
    public void Generic6DofJointSetParam(Rid joint, Vector3.Axis axis, PhysicsServer3D.G6DofJointAxisParam param, float value)
    {
        NativeCalls.godot_icall_4_1007(MethodBind168, GodotObject.GetPtr(this), joint, (int)axis, (int)param, value);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind169 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Generic6DofJointGetParam, 467122058ul);

    /// <summary>
    /// <para>Returns the value of a generic 6DOF joint parameter.</para>
    /// </summary>
    public float Generic6DofJointGetParam(Rid joint, Vector3.Axis axis, PhysicsServer3D.G6DofJointAxisParam param)
    {
        return NativeCalls.godot_icall_3_1008(MethodBind169, GodotObject.GetPtr(this), joint, (int)axis, (int)param);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind170 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Generic6DofJointSetFlag, 3570926903ul);

    /// <summary>
    /// <para>Sets the value of a given generic 6DOF joint flag.</para>
    /// </summary>
    public void Generic6DofJointSetFlag(Rid joint, Vector3.Axis axis, PhysicsServer3D.G6DofJointAxisFlag flag, bool enable)
    {
        NativeCalls.godot_icall_4_1009(MethodBind170, GodotObject.GetPtr(this), joint, (int)axis, (int)flag, enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind171 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Generic6DofJointGetFlag, 4158090196ul);

    /// <summary>
    /// <para>Returns the value of a generic 6DOF joint flag.</para>
    /// </summary>
    public bool Generic6DofJointGetFlag(Rid joint, Vector3.Axis axis, PhysicsServer3D.G6DofJointAxisFlag flag)
    {
        return NativeCalls.godot_icall_3_1010(MethodBind171, GodotObject.GetPtr(this), joint, (int)axis, (int)flag).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind172 = ClassDB_get_method_with_compatibility(NativeName, MethodName.FreeRid, 2722037293ul);

    /// <summary>
    /// <para>Destroys any of the objects created by PhysicsServer3D. If the <see cref="Godot.Rid"/> passed is not one of the objects that can be created by PhysicsServer3D, an error will be sent to the console.</para>
    /// </summary>
    public void FreeRid(Rid rid)
    {
        NativeCalls.godot_icall_1_286(MethodBind172, GodotObject.GetPtr(this), rid);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind173 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetActive, 2586408642ul);

    /// <summary>
    /// <para>Activates or deactivates the 3D physics engine.</para>
    /// </summary>
    public void SetActive(bool active)
    {
        NativeCalls.godot_icall_1_14(MethodBind173, GodotObject.GetPtr(this), active.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind174 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetProcessInfo, 1332958745ul);

    /// <summary>
    /// <para>Returns the value of a physics engine state specified by <paramref name="processInfo"/>.</para>
    /// </summary>
    public int GetProcessInfo(PhysicsServer3D.ProcessInfo processInfo)
    {
        return NativeCalls.godot_icall_1_60(MethodBind174, GodotObject.GetPtr(this), (int)processInfo);
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
        /// Cached name for the 'sphere_shape_create' method.
        /// </summary>
        public static readonly StringName SphereShapeCreate = "sphere_shape_create";
        /// <summary>
        /// Cached name for the 'box_shape_create' method.
        /// </summary>
        public static readonly StringName BoxShapeCreate = "box_shape_create";
        /// <summary>
        /// Cached name for the 'capsule_shape_create' method.
        /// </summary>
        public static readonly StringName CapsuleShapeCreate = "capsule_shape_create";
        /// <summary>
        /// Cached name for the 'cylinder_shape_create' method.
        /// </summary>
        public static readonly StringName CylinderShapeCreate = "cylinder_shape_create";
        /// <summary>
        /// Cached name for the 'convex_polygon_shape_create' method.
        /// </summary>
        public static readonly StringName ConvexPolygonShapeCreate = "convex_polygon_shape_create";
        /// <summary>
        /// Cached name for the 'concave_polygon_shape_create' method.
        /// </summary>
        public static readonly StringName ConcavePolygonShapeCreate = "concave_polygon_shape_create";
        /// <summary>
        /// Cached name for the 'heightmap_shape_create' method.
        /// </summary>
        public static readonly StringName HeightmapShapeCreate = "heightmap_shape_create";
        /// <summary>
        /// Cached name for the 'custom_shape_create' method.
        /// </summary>
        public static readonly StringName CustomShapeCreate = "custom_shape_create";
        /// <summary>
        /// Cached name for the 'shape_set_data' method.
        /// </summary>
        public static readonly StringName ShapeSetData = "shape_set_data";
        /// <summary>
        /// Cached name for the 'shape_set_margin' method.
        /// </summary>
        public static readonly StringName ShapeSetMargin = "shape_set_margin";
        /// <summary>
        /// Cached name for the 'shape_get_type' method.
        /// </summary>
        public static readonly StringName ShapeGetType = "shape_get_type";
        /// <summary>
        /// Cached name for the 'shape_get_data' method.
        /// </summary>
        public static readonly StringName ShapeGetData = "shape_get_data";
        /// <summary>
        /// Cached name for the 'shape_get_margin' method.
        /// </summary>
        public static readonly StringName ShapeGetMargin = "shape_get_margin";
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
        /// Cached name for the 'area_set_ray_pickable' method.
        /// </summary>
        public static readonly StringName AreaSetRayPickable = "area_set_ray_pickable";
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
        /// Cached name for the 'body_set_shape_disabled' method.
        /// </summary>
        public static readonly StringName BodySetShapeDisabled = "body_set_shape_disabled";
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
        /// Cached name for the 'body_attach_object_instance_id' method.
        /// </summary>
        public static readonly StringName BodyAttachObjectInstanceId = "body_attach_object_instance_id";
        /// <summary>
        /// Cached name for the 'body_get_object_instance_id' method.
        /// </summary>
        public static readonly StringName BodyGetObjectInstanceId = "body_get_object_instance_id";
        /// <summary>
        /// Cached name for the 'body_set_enable_continuous_collision_detection' method.
        /// </summary>
        public static readonly StringName BodySetEnableContinuousCollisionDetection = "body_set_enable_continuous_collision_detection";
        /// <summary>
        /// Cached name for the 'body_is_continuous_collision_detection_enabled' method.
        /// </summary>
        public static readonly StringName BodyIsContinuousCollisionDetectionEnabled = "body_is_continuous_collision_detection_enabled";
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
        /// Cached name for the 'body_apply_impulse' method.
        /// </summary>
        public static readonly StringName BodyApplyImpulse = "body_apply_impulse";
        /// <summary>
        /// Cached name for the 'body_apply_torque_impulse' method.
        /// </summary>
        public static readonly StringName BodyApplyTorqueImpulse = "body_apply_torque_impulse";
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
        /// Cached name for the 'body_set_axis_lock' method.
        /// </summary>
        public static readonly StringName BodySetAxisLock = "body_set_axis_lock";
        /// <summary>
        /// Cached name for the 'body_is_axis_locked' method.
        /// </summary>
        public static readonly StringName BodyIsAxisLocked = "body_is_axis_locked";
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
        /// Cached name for the 'body_set_ray_pickable' method.
        /// </summary>
        public static readonly StringName BodySetRayPickable = "body_set_ray_pickable";
        /// <summary>
        /// Cached name for the 'body_test_motion' method.
        /// </summary>
        public static readonly StringName BodyTestMotion = "body_test_motion";
        /// <summary>
        /// Cached name for the 'body_get_direct_state' method.
        /// </summary>
        public static readonly StringName BodyGetDirectState = "body_get_direct_state";
        /// <summary>
        /// Cached name for the 'soft_body_create' method.
        /// </summary>
        public static readonly StringName SoftBodyCreate = "soft_body_create";
        /// <summary>
        /// Cached name for the 'soft_body_update_rendering_server' method.
        /// </summary>
        public static readonly StringName SoftBodyUpdateRenderingServer = "soft_body_update_rendering_server";
        /// <summary>
        /// Cached name for the 'soft_body_set_space' method.
        /// </summary>
        public static readonly StringName SoftBodySetSpace = "soft_body_set_space";
        /// <summary>
        /// Cached name for the 'soft_body_get_space' method.
        /// </summary>
        public static readonly StringName SoftBodyGetSpace = "soft_body_get_space";
        /// <summary>
        /// Cached name for the 'soft_body_set_mesh' method.
        /// </summary>
        public static readonly StringName SoftBodySetMesh = "soft_body_set_mesh";
        /// <summary>
        /// Cached name for the 'soft_body_get_bounds' method.
        /// </summary>
        public static readonly StringName SoftBodyGetBounds = "soft_body_get_bounds";
        /// <summary>
        /// Cached name for the 'soft_body_set_collision_layer' method.
        /// </summary>
        public static readonly StringName SoftBodySetCollisionLayer = "soft_body_set_collision_layer";
        /// <summary>
        /// Cached name for the 'soft_body_get_collision_layer' method.
        /// </summary>
        public static readonly StringName SoftBodyGetCollisionLayer = "soft_body_get_collision_layer";
        /// <summary>
        /// Cached name for the 'soft_body_set_collision_mask' method.
        /// </summary>
        public static readonly StringName SoftBodySetCollisionMask = "soft_body_set_collision_mask";
        /// <summary>
        /// Cached name for the 'soft_body_get_collision_mask' method.
        /// </summary>
        public static readonly StringName SoftBodyGetCollisionMask = "soft_body_get_collision_mask";
        /// <summary>
        /// Cached name for the 'soft_body_add_collision_exception' method.
        /// </summary>
        public static readonly StringName SoftBodyAddCollisionException = "soft_body_add_collision_exception";
        /// <summary>
        /// Cached name for the 'soft_body_remove_collision_exception' method.
        /// </summary>
        public static readonly StringName SoftBodyRemoveCollisionException = "soft_body_remove_collision_exception";
        /// <summary>
        /// Cached name for the 'soft_body_set_state' method.
        /// </summary>
        public static readonly StringName SoftBodySetState = "soft_body_set_state";
        /// <summary>
        /// Cached name for the 'soft_body_get_state' method.
        /// </summary>
        public static readonly StringName SoftBodyGetState = "soft_body_get_state";
        /// <summary>
        /// Cached name for the 'soft_body_set_transform' method.
        /// </summary>
        public static readonly StringName SoftBodySetTransform = "soft_body_set_transform";
        /// <summary>
        /// Cached name for the 'soft_body_set_ray_pickable' method.
        /// </summary>
        public static readonly StringName SoftBodySetRayPickable = "soft_body_set_ray_pickable";
        /// <summary>
        /// Cached name for the 'soft_body_set_simulation_precision' method.
        /// </summary>
        public static readonly StringName SoftBodySetSimulationPrecision = "soft_body_set_simulation_precision";
        /// <summary>
        /// Cached name for the 'soft_body_get_simulation_precision' method.
        /// </summary>
        public static readonly StringName SoftBodyGetSimulationPrecision = "soft_body_get_simulation_precision";
        /// <summary>
        /// Cached name for the 'soft_body_set_total_mass' method.
        /// </summary>
        public static readonly StringName SoftBodySetTotalMass = "soft_body_set_total_mass";
        /// <summary>
        /// Cached name for the 'soft_body_get_total_mass' method.
        /// </summary>
        public static readonly StringName SoftBodyGetTotalMass = "soft_body_get_total_mass";
        /// <summary>
        /// Cached name for the 'soft_body_set_linear_stiffness' method.
        /// </summary>
        public static readonly StringName SoftBodySetLinearStiffness = "soft_body_set_linear_stiffness";
        /// <summary>
        /// Cached name for the 'soft_body_get_linear_stiffness' method.
        /// </summary>
        public static readonly StringName SoftBodyGetLinearStiffness = "soft_body_get_linear_stiffness";
        /// <summary>
        /// Cached name for the 'soft_body_set_shrinking_factor' method.
        /// </summary>
        public static readonly StringName SoftBodySetShrinkingFactor = "soft_body_set_shrinking_factor";
        /// <summary>
        /// Cached name for the 'soft_body_get_shrinking_factor' method.
        /// </summary>
        public static readonly StringName SoftBodyGetShrinkingFactor = "soft_body_get_shrinking_factor";
        /// <summary>
        /// Cached name for the 'soft_body_set_pressure_coefficient' method.
        /// </summary>
        public static readonly StringName SoftBodySetPressureCoefficient = "soft_body_set_pressure_coefficient";
        /// <summary>
        /// Cached name for the 'soft_body_get_pressure_coefficient' method.
        /// </summary>
        public static readonly StringName SoftBodyGetPressureCoefficient = "soft_body_get_pressure_coefficient";
        /// <summary>
        /// Cached name for the 'soft_body_set_damping_coefficient' method.
        /// </summary>
        public static readonly StringName SoftBodySetDampingCoefficient = "soft_body_set_damping_coefficient";
        /// <summary>
        /// Cached name for the 'soft_body_get_damping_coefficient' method.
        /// </summary>
        public static readonly StringName SoftBodyGetDampingCoefficient = "soft_body_get_damping_coefficient";
        /// <summary>
        /// Cached name for the 'soft_body_set_drag_coefficient' method.
        /// </summary>
        public static readonly StringName SoftBodySetDragCoefficient = "soft_body_set_drag_coefficient";
        /// <summary>
        /// Cached name for the 'soft_body_get_drag_coefficient' method.
        /// </summary>
        public static readonly StringName SoftBodyGetDragCoefficient = "soft_body_get_drag_coefficient";
        /// <summary>
        /// Cached name for the 'soft_body_move_point' method.
        /// </summary>
        public static readonly StringName SoftBodyMovePoint = "soft_body_move_point";
        /// <summary>
        /// Cached name for the 'soft_body_get_point_global_position' method.
        /// </summary>
        public static readonly StringName SoftBodyGetPointGlobalPosition = "soft_body_get_point_global_position";
        /// <summary>
        /// Cached name for the 'soft_body_remove_all_pinned_points' method.
        /// </summary>
        public static readonly StringName SoftBodyRemoveAllPinnedPoints = "soft_body_remove_all_pinned_points";
        /// <summary>
        /// Cached name for the 'soft_body_pin_point' method.
        /// </summary>
        public static readonly StringName SoftBodyPinPoint = "soft_body_pin_point";
        /// <summary>
        /// Cached name for the 'soft_body_is_point_pinned' method.
        /// </summary>
        public static readonly StringName SoftBodyIsPointPinned = "soft_body_is_point_pinned";
        /// <summary>
        /// Cached name for the 'soft_body_apply_point_impulse' method.
        /// </summary>
        public static readonly StringName SoftBodyApplyPointImpulse = "soft_body_apply_point_impulse";
        /// <summary>
        /// Cached name for the 'soft_body_apply_point_force' method.
        /// </summary>
        public static readonly StringName SoftBodyApplyPointForce = "soft_body_apply_point_force";
        /// <summary>
        /// Cached name for the 'soft_body_apply_central_impulse' method.
        /// </summary>
        public static readonly StringName SoftBodyApplyCentralImpulse = "soft_body_apply_central_impulse";
        /// <summary>
        /// Cached name for the 'soft_body_apply_central_force' method.
        /// </summary>
        public static readonly StringName SoftBodyApplyCentralForce = "soft_body_apply_central_force";
        /// <summary>
        /// Cached name for the 'joint_create' method.
        /// </summary>
        public static readonly StringName JointCreate = "joint_create";
        /// <summary>
        /// Cached name for the 'joint_clear' method.
        /// </summary>
        public static readonly StringName JointClear = "joint_clear";
        /// <summary>
        /// Cached name for the 'joint_make_pin' method.
        /// </summary>
        public static readonly StringName JointMakePin = "joint_make_pin";
        /// <summary>
        /// Cached name for the 'pin_joint_set_param' method.
        /// </summary>
        public static readonly StringName PinJointSetParam = "pin_joint_set_param";
        /// <summary>
        /// Cached name for the 'pin_joint_get_param' method.
        /// </summary>
        public static readonly StringName PinJointGetParam = "pin_joint_get_param";
        /// <summary>
        /// Cached name for the 'pin_joint_set_local_a' method.
        /// </summary>
        public static readonly StringName PinJointSetLocalA = "pin_joint_set_local_a";
        /// <summary>
        /// Cached name for the 'pin_joint_get_local_a' method.
        /// </summary>
        public static readonly StringName PinJointGetLocalA = "pin_joint_get_local_a";
        /// <summary>
        /// Cached name for the 'pin_joint_set_local_b' method.
        /// </summary>
        public static readonly StringName PinJointSetLocalB = "pin_joint_set_local_b";
        /// <summary>
        /// Cached name for the 'pin_joint_get_local_b' method.
        /// </summary>
        public static readonly StringName PinJointGetLocalB = "pin_joint_get_local_b";
        /// <summary>
        /// Cached name for the 'joint_make_hinge' method.
        /// </summary>
        public static readonly StringName JointMakeHinge = "joint_make_hinge";
        /// <summary>
        /// Cached name for the 'hinge_joint_set_param' method.
        /// </summary>
        public static readonly StringName HingeJointSetParam = "hinge_joint_set_param";
        /// <summary>
        /// Cached name for the 'hinge_joint_get_param' method.
        /// </summary>
        public static readonly StringName HingeJointGetParam = "hinge_joint_get_param";
        /// <summary>
        /// Cached name for the 'hinge_joint_set_flag' method.
        /// </summary>
        public static readonly StringName HingeJointSetFlag = "hinge_joint_set_flag";
        /// <summary>
        /// Cached name for the 'hinge_joint_get_flag' method.
        /// </summary>
        public static readonly StringName HingeJointGetFlag = "hinge_joint_get_flag";
        /// <summary>
        /// Cached name for the 'joint_make_slider' method.
        /// </summary>
        public static readonly StringName JointMakeSlider = "joint_make_slider";
        /// <summary>
        /// Cached name for the 'slider_joint_set_param' method.
        /// </summary>
        public static readonly StringName SliderJointSetParam = "slider_joint_set_param";
        /// <summary>
        /// Cached name for the 'slider_joint_get_param' method.
        /// </summary>
        public static readonly StringName SliderJointGetParam = "slider_joint_get_param";
        /// <summary>
        /// Cached name for the 'joint_make_cone_twist' method.
        /// </summary>
        public static readonly StringName JointMakeConeTwist = "joint_make_cone_twist";
        /// <summary>
        /// Cached name for the 'cone_twist_joint_set_param' method.
        /// </summary>
        public static readonly StringName ConeTwistJointSetParam = "cone_twist_joint_set_param";
        /// <summary>
        /// Cached name for the 'cone_twist_joint_get_param' method.
        /// </summary>
        public static readonly StringName ConeTwistJointGetParam = "cone_twist_joint_get_param";
        /// <summary>
        /// Cached name for the 'joint_get_type' method.
        /// </summary>
        public static readonly StringName JointGetType = "joint_get_type";
        /// <summary>
        /// Cached name for the 'joint_set_solver_priority' method.
        /// </summary>
        public static readonly StringName JointSetSolverPriority = "joint_set_solver_priority";
        /// <summary>
        /// Cached name for the 'joint_get_solver_priority' method.
        /// </summary>
        public static readonly StringName JointGetSolverPriority = "joint_get_solver_priority";
        /// <summary>
        /// Cached name for the 'joint_disable_collisions_between_bodies' method.
        /// </summary>
        public static readonly StringName JointDisableCollisionsBetweenBodies = "joint_disable_collisions_between_bodies";
        /// <summary>
        /// Cached name for the 'joint_is_disabled_collisions_between_bodies' method.
        /// </summary>
        public static readonly StringName JointIsDisabledCollisionsBetweenBodies = "joint_is_disabled_collisions_between_bodies";
        /// <summary>
        /// Cached name for the 'joint_make_generic_6dof' method.
        /// </summary>
        public static readonly StringName JointMakeGeneric6Dof = "joint_make_generic_6dof";
        /// <summary>
        /// Cached name for the 'generic_6dof_joint_set_param' method.
        /// </summary>
        public static readonly StringName Generic6DofJointSetParam = "generic_6dof_joint_set_param";
        /// <summary>
        /// Cached name for the 'generic_6dof_joint_get_param' method.
        /// </summary>
        public static readonly StringName Generic6DofJointGetParam = "generic_6dof_joint_get_param";
        /// <summary>
        /// Cached name for the 'generic_6dof_joint_set_flag' method.
        /// </summary>
        public static readonly StringName Generic6DofJointSetFlag = "generic_6dof_joint_set_flag";
        /// <summary>
        /// Cached name for the 'generic_6dof_joint_get_flag' method.
        /// </summary>
        public static readonly StringName Generic6DofJointGetFlag = "generic_6dof_joint_get_flag";
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
