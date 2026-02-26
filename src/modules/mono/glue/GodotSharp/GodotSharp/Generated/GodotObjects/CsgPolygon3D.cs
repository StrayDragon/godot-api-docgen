namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>An array of 2D points is extruded to quickly and easily create a variety of 3D meshes. See also <see cref="Godot.CsgMesh3D"/> for using 3D meshes as CSG nodes.</para>
/// <para><b>Note:</b> CSG nodes are intended to be used for level prototyping. Creating CSG nodes has a significant CPU cost compared to creating a <see cref="Godot.MeshInstance3D"/> with a <see cref="Godot.PrimitiveMesh"/>. Moving a CSG node within another CSG node also has a significant CPU cost, so it should be avoided during gameplay.</para>
/// </summary>
[GodotClassName("CSGPolygon3D")]
public partial class CsgPolygon3D : CsgPrimitive3D
{
    public enum ModeEnum : long
    {
        /// <summary>
        /// <para>The <see cref="Godot.CsgPolygon3D.Polygon"/> shape is extruded along the negative Z axis.</para>
        /// </summary>
        Depth = 0,
        /// <summary>
        /// <para>The <see cref="Godot.CsgPolygon3D.Polygon"/> shape is extruded by rotating it around the Y axis.</para>
        /// </summary>
        Spin = 1,
        /// <summary>
        /// <para>The <see cref="Godot.CsgPolygon3D.Polygon"/> shape is extruded along the <see cref="Godot.Path3D"/> specified in <see cref="Godot.CsgPolygon3D.PathNode"/>.</para>
        /// </summary>
        Path = 2
    }

    public enum PathRotationEnum : long
    {
        /// <summary>
        /// <para>The <see cref="Godot.CsgPolygon3D.Polygon"/> shape is not rotated.</para>
        /// <para><b>Note:</b> Requires the path Z coordinates to continually decrease to ensure viable shapes.</para>
        /// </summary>
        Polygon = 0,
        /// <summary>
        /// <para>The <see cref="Godot.CsgPolygon3D.Polygon"/> shape is rotated along the path, but it is not rotated around the path axis.</para>
        /// <para><b>Note:</b> Requires the path Z coordinates to continually decrease to ensure viable shapes.</para>
        /// </summary>
        Path = 1,
        /// <summary>
        /// <para>The <see cref="Godot.CsgPolygon3D.Polygon"/> shape follows the path and its rotations around the path axis.</para>
        /// </summary>
        PathFollow = 2
    }

    public enum PathIntervalTypeEnum : long
    {
        /// <summary>
        /// <para>When <see cref="Godot.CsgPolygon3D.Mode"/> is set to <see cref="Godot.CsgPolygon3D.ModeEnum.Path"/>, <see cref="Godot.CsgPolygon3D.PathInterval"/> will determine the distance, in meters, each interval of the path will extrude.</para>
        /// </summary>
        Distance = 0,
        /// <summary>
        /// <para>When <see cref="Godot.CsgPolygon3D.Mode"/> is set to <see cref="Godot.CsgPolygon3D.ModeEnum.Path"/>, <see cref="Godot.CsgPolygon3D.PathInterval"/> will subdivide the polygons along the path.</para>
        /// </summary>
        Subdivide = 1
    }

    /// <summary>
    /// <para>The point array that defines the 2D polygon that is extruded. This can be a convex or concave polygon with 3 or more points. The polygon must <i>not</i> have any intersecting edges. Otherwise, triangulation will fail and no mesh will be generated.</para>
    /// <para><b>Note:</b> If only 1 or 2 points are defined in <see cref="Godot.CsgPolygon3D.Polygon"/>, no mesh will be generated.</para>
    /// </summary>
    public Vector2[] Polygon
    {
        get
        {
            return GetPolygon();
        }
        set
        {
            SetPolygon(value);
        }
    }

    /// <summary>
    /// <para>The <see cref="Godot.CsgPolygon3D.Mode"/> used to extrude the <see cref="Godot.CsgPolygon3D.Polygon"/>.</para>
    /// </summary>
    public CsgPolygon3D.ModeEnum Mode
    {
        get
        {
            return GetMode();
        }
        set
        {
            SetMode(value);
        }
    }

    /// <summary>
    /// <para>When <see cref="Godot.CsgPolygon3D.Mode"/> is <see cref="Godot.CsgPolygon3D.ModeEnum.Depth"/>, the depth of the extrusion.</para>
    /// </summary>
    public float Depth
    {
        get
        {
            return GetDepth();
        }
        set
        {
            SetDepth(value);
        }
    }

    /// <summary>
    /// <para>When <see cref="Godot.CsgPolygon3D.Mode"/> is <see cref="Godot.CsgPolygon3D.ModeEnum.Spin"/>, the total number of degrees the <see cref="Godot.CsgPolygon3D.Polygon"/> is rotated when extruding.</para>
    /// </summary>
    public float SpinDegrees
    {
        get
        {
            return GetSpinDegrees();
        }
        set
        {
            SetSpinDegrees(value);
        }
    }

    /// <summary>
    /// <para>When <see cref="Godot.CsgPolygon3D.Mode"/> is <see cref="Godot.CsgPolygon3D.ModeEnum.Spin"/>, the number of extrusions made.</para>
    /// </summary>
    public int SpinSides
    {
        get
        {
            return GetSpinSides();
        }
        set
        {
            SetSpinSides(value);
        }
    }

    /// <summary>
    /// <para>When <see cref="Godot.CsgPolygon3D.Mode"/> is <see cref="Godot.CsgPolygon3D.ModeEnum.Path"/>, the location of the <see cref="Godot.Path3D"/> object used to extrude the <see cref="Godot.CsgPolygon3D.Polygon"/>.</para>
    /// </summary>
    public NodePath PathNode
    {
        get
        {
            return GetPathNode();
        }
        set
        {
            SetPathNode(value);
        }
    }

    /// <summary>
    /// <para>When <see cref="Godot.CsgPolygon3D.Mode"/> is <see cref="Godot.CsgPolygon3D.ModeEnum.Path"/>, this will determine if the interval should be by distance (<see cref="Godot.CsgPolygon3D.PathIntervalTypeEnum.Distance"/>) or subdivision fractions (<see cref="Godot.CsgPolygon3D.PathIntervalTypeEnum.Subdivide"/>).</para>
    /// </summary>
    public CsgPolygon3D.PathIntervalTypeEnum PathIntervalType
    {
        get
        {
            return GetPathIntervalType();
        }
        set
        {
            SetPathIntervalType(value);
        }
    }

    /// <summary>
    /// <para>When <see cref="Godot.CsgPolygon3D.Mode"/> is <see cref="Godot.CsgPolygon3D.ModeEnum.Path"/>, the path interval or ratio of path points to extrusions.</para>
    /// </summary>
    public float PathInterval
    {
        get
        {
            return GetPathInterval();
        }
        set
        {
            SetPathInterval(value);
        }
    }

    /// <summary>
    /// <para>When <see cref="Godot.CsgPolygon3D.Mode"/> is <see cref="Godot.CsgPolygon3D.ModeEnum.Path"/>, extrusions that are less than this angle, will be merged together to reduce polygon count.</para>
    /// </summary>
    public float PathSimplifyAngle
    {
        get
        {
            return GetPathSimplifyAngle();
        }
        set
        {
            SetPathSimplifyAngle(value);
        }
    }

    /// <summary>
    /// <para>When <see cref="Godot.CsgPolygon3D.Mode"/> is <see cref="Godot.CsgPolygon3D.ModeEnum.Path"/>, the path rotation method used to rotate the <see cref="Godot.CsgPolygon3D.Polygon"/> as it is extruded.</para>
    /// </summary>
    public CsgPolygon3D.PathRotationEnum PathRotation
    {
        get
        {
            return GetPathRotation();
        }
        set
        {
            SetPathRotation(value);
        }
    }

    /// <summary>
    /// <para>When <see cref="Godot.CsgPolygon3D.Mode"/> is <see cref="Godot.CsgPolygon3D.ModeEnum.Path"/>, if <see langword="true"/> the polygon will be rotated according to the proper tangent of the path at the sampled points. If <see langword="false"/> an approximation is used, which decreases in accuracy as the number of subdivisions decreases.</para>
    /// </summary>
    public bool PathRotationAccurate
    {
        get
        {
            return GetPathRotationAccurate();
        }
        set
        {
            SetPathRotationAccurate(value);
        }
    }

    /// <summary>
    /// <para>When <see cref="Godot.CsgPolygon3D.Mode"/> is <see cref="Godot.CsgPolygon3D.ModeEnum.Path"/>, if <see langword="true"/> the <see cref="Godot.Transform3D"/> of the <see cref="Godot.CsgPolygon3D"/> is used as the starting point for the extrusions, not the <see cref="Godot.Transform3D"/> of the <see cref="Godot.CsgPolygon3D.PathNode"/>.</para>
    /// </summary>
    public bool PathLocal
    {
        get
        {
            return IsPathLocal();
        }
        set
        {
            SetPathLocal(value);
        }
    }

    /// <summary>
    /// <para>When <see cref="Godot.CsgPolygon3D.Mode"/> is <see cref="Godot.CsgPolygon3D.ModeEnum.Path"/>, by default, the top half of the <see cref="Godot.CsgPolygon3D.Material"/> is stretched along the entire length of the extruded shape. If <see langword="false"/> the top half of the material is repeated every step of the extrusion.</para>
    /// </summary>
    public bool PathContinuousU
    {
        get
        {
            return IsPathContinuousU();
        }
        set
        {
            SetPathContinuousU(value);
        }
    }

    /// <summary>
    /// <para>When <see cref="Godot.CsgPolygon3D.Mode"/> is <see cref="Godot.CsgPolygon3D.ModeEnum.Path"/>, this is the distance along the path, in meters, the texture coordinates will tile. When set to 0, texture coordinates will match geometry exactly with no tiling.</para>
    /// </summary>
    public float PathUDistance
    {
        get
        {
            return GetPathUDistance();
        }
        set
        {
            SetPathUDistance(value);
        }
    }

    /// <summary>
    /// <para>When <see cref="Godot.CsgPolygon3D.Mode"/> is <see cref="Godot.CsgPolygon3D.ModeEnum.Path"/>, if <see langword="true"/> the ends of the path are joined, by adding an extrusion between the last and first points of the path.</para>
    /// </summary>
    public bool PathJoined
    {
        get
        {
            return IsPathJoined();
        }
        set
        {
            SetPathJoined(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, applies smooth shading to the extrusions.</para>
    /// </summary>
    public bool SmoothFaces
    {
        get
        {
            return GetSmoothFaces();
        }
        set
        {
            SetSmoothFaces(value);
        }
    }

    /// <summary>
    /// <para>Material to use for the resulting mesh. The UV maps the top half of the material to the extruded shape (U along the length of the extrusions and V around the outline of the <see cref="Godot.CsgPolygon3D.Polygon"/>), the bottom-left quarter to the front end face, and the bottom-right quarter to the back end face.</para>
    /// </summary>
    public Material Material
    {
        get
        {
            return GetMaterial();
        }
        set
        {
            SetMaterial(value);
        }
    }

    private static readonly System.Type CachedType = typeof(CsgPolygon3D);

    private static readonly StringName NativeName = "CSGPolygon3D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public CsgPolygon3D() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal CsgPolygon3D(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal CsgPolygon3D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPolygon, 1509147220ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPolygon(Vector2[] polygon)
    {
        NativeCalls.godot_icall_1_224(MethodBind0, GodotObject.GetPtr(this), polygon);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPolygon(ReadOnlySpan<Vector2> polygon)
    {
        NativeCalls.godot_icall_1_224(MethodBind0, GodotObject.GetPtr(this), polygon);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPolygon, 2961356807ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2[] GetPolygon()
    {
        return NativeCalls.godot_icall_0_225(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMode, 3158377035ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMode(CsgPolygon3D.ModeEnum mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind2, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMode, 1201612222ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public CsgPolygon3D.ModeEnum GetMode()
    {
        return (CsgPolygon3D.ModeEnum)NativeCalls.godot_icall_0_39(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDepth, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDepth(float depth)
    {
        NativeCalls.godot_icall_1_67(MethodBind4, GodotObject.GetPtr(this), depth);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDepth, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetDepth()
    {
        return NativeCalls.godot_icall_0_68(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSpinDegrees, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSpinDegrees(float degrees)
    {
        NativeCalls.godot_icall_1_67(MethodBind6, GodotObject.GetPtr(this), degrees);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSpinDegrees, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetSpinDegrees()
    {
        return NativeCalls.godot_icall_0_68(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSpinSides, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSpinSides(int spinSides)
    {
        NativeCalls.godot_icall_1_38(MethodBind8, GodotObject.GetPtr(this), spinSides);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSpinSides, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetSpinSides()
    {
        return NativeCalls.godot_icall_0_39(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPathNode, 1348162250ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPathNode(NodePath path)
    {
        NativeCalls.godot_icall_1_123(MethodBind10, GodotObject.GetPtr(this), (godot_node_path)(path?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPathNode, 4075236667ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public NodePath GetPathNode()
    {
        return NativeCalls.godot_icall_0_124(MethodBind11, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPathIntervalType, 3744240707ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPathIntervalType(CsgPolygon3D.PathIntervalTypeEnum intervalType)
    {
        NativeCalls.godot_icall_1_38(MethodBind12, GodotObject.GetPtr(this), (int)intervalType);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPathIntervalType, 3434618397ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public CsgPolygon3D.PathIntervalTypeEnum GetPathIntervalType()
    {
        return (CsgPolygon3D.PathIntervalTypeEnum)NativeCalls.godot_icall_0_39(MethodBind13, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPathInterval, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPathInterval(float interval)
    {
        NativeCalls.godot_icall_1_67(MethodBind14, GodotObject.GetPtr(this), interval);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPathInterval, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetPathInterval()
    {
        return NativeCalls.godot_icall_0_68(MethodBind15, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPathSimplifyAngle, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPathSimplifyAngle(float degrees)
    {
        NativeCalls.godot_icall_1_67(MethodBind16, GodotObject.GetPtr(this), degrees);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPathSimplifyAngle, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetPathSimplifyAngle()
    {
        return NativeCalls.godot_icall_0_68(MethodBind17, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPathRotation, 1412947288ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPathRotation(CsgPolygon3D.PathRotationEnum pathRotation)
    {
        NativeCalls.godot_icall_1_38(MethodBind18, GodotObject.GetPtr(this), (int)pathRotation);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPathRotation, 647219346ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public CsgPolygon3D.PathRotationEnum GetPathRotation()
    {
        return (CsgPolygon3D.PathRotationEnum)NativeCalls.godot_icall_0_39(MethodBind19, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPathRotationAccurate, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPathRotationAccurate(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind20, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPathRotationAccurate, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetPathRotationAccurate()
    {
        return NativeCalls.godot_icall_0_15(MethodBind21, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPathLocal, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPathLocal(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind22, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsPathLocal, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsPathLocal()
    {
        return NativeCalls.godot_icall_0_15(MethodBind23, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPathContinuousU, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPathContinuousU(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind24, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsPathContinuousU, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsPathContinuousU()
    {
        return NativeCalls.godot_icall_0_15(MethodBind25, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPathUDistance, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPathUDistance(float distance)
    {
        NativeCalls.godot_icall_1_67(MethodBind26, GodotObject.GetPtr(this), distance);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPathUDistance, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetPathUDistance()
    {
        return NativeCalls.godot_icall_0_68(MethodBind27, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPathJoined, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPathJoined(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind28, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsPathJoined, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsPathJoined()
    {
        return NativeCalls.godot_icall_0_15(MethodBind29, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMaterial, 2757459619ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMaterial(Material material)
    {
        NativeCalls.godot_icall_1_56(MethodBind30, GodotObject.GetPtr(this), GodotObject.GetPtr(material));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMaterial, 5934680ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Material GetMaterial()
    {
        return (Material)NativeCalls.godot_icall_0_63(MethodBind31, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind32 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSmoothFaces, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSmoothFaces(bool smoothFaces)
    {
        NativeCalls.godot_icall_1_14(MethodBind32, GodotObject.GetPtr(this), smoothFaces.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind33 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSmoothFaces, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetSmoothFaces()
    {
        return NativeCalls.godot_icall_0_15(MethodBind33, GodotObject.GetPtr(this)).ToBool();
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
    public new class PropertyName : CsgPrimitive3D.PropertyName
    {
        /// <summary>
        /// Cached name for the 'polygon' property.
        /// </summary>
        public static readonly StringName Polygon = "polygon";
        /// <summary>
        /// Cached name for the 'mode' property.
        /// </summary>
        public static readonly StringName Mode = "mode";
        /// <summary>
        /// Cached name for the 'depth' property.
        /// </summary>
        public static readonly StringName Depth = "depth";
        /// <summary>
        /// Cached name for the 'spin_degrees' property.
        /// </summary>
        public static readonly StringName SpinDegrees = "spin_degrees";
        /// <summary>
        /// Cached name for the 'spin_sides' property.
        /// </summary>
        public static readonly StringName SpinSides = "spin_sides";
        /// <summary>
        /// Cached name for the 'path_node' property.
        /// </summary>
        public static readonly StringName PathNode = "path_node";
        /// <summary>
        /// Cached name for the 'path_interval_type' property.
        /// </summary>
        public static readonly StringName PathIntervalType = "path_interval_type";
        /// <summary>
        /// Cached name for the 'path_interval' property.
        /// </summary>
        public static readonly StringName PathInterval = "path_interval";
        /// <summary>
        /// Cached name for the 'path_simplify_angle' property.
        /// </summary>
        public static readonly StringName PathSimplifyAngle = "path_simplify_angle";
        /// <summary>
        /// Cached name for the 'path_rotation' property.
        /// </summary>
        public static readonly StringName PathRotation = "path_rotation";
        /// <summary>
        /// Cached name for the 'path_rotation_accurate' property.
        /// </summary>
        public static readonly StringName PathRotationAccurate = "path_rotation_accurate";
        /// <summary>
        /// Cached name for the 'path_local' property.
        /// </summary>
        public static readonly StringName PathLocal = "path_local";
        /// <summary>
        /// Cached name for the 'path_continuous_u' property.
        /// </summary>
        public static readonly StringName PathContinuousU = "path_continuous_u";
        /// <summary>
        /// Cached name for the 'path_u_distance' property.
        /// </summary>
        public static readonly StringName PathUDistance = "path_u_distance";
        /// <summary>
        /// Cached name for the 'path_joined' property.
        /// </summary>
        public static readonly StringName PathJoined = "path_joined";
        /// <summary>
        /// Cached name for the 'smooth_faces' property.
        /// </summary>
        public static readonly StringName SmoothFaces = "smooth_faces";
        /// <summary>
        /// Cached name for the 'material' property.
        /// </summary>
        public static readonly StringName Material = "material";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : CsgPrimitive3D.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_polygon' method.
        /// </summary>
        public static readonly StringName SetPolygon = "set_polygon";
        /// <summary>
        /// Cached name for the 'get_polygon' method.
        /// </summary>
        public static readonly StringName GetPolygon = "get_polygon";
        /// <summary>
        /// Cached name for the 'set_mode' method.
        /// </summary>
        public static readonly StringName SetMode = "set_mode";
        /// <summary>
        /// Cached name for the 'get_mode' method.
        /// </summary>
        public static readonly StringName GetMode = "get_mode";
        /// <summary>
        /// Cached name for the 'set_depth' method.
        /// </summary>
        public static readonly StringName SetDepth = "set_depth";
        /// <summary>
        /// Cached name for the 'get_depth' method.
        /// </summary>
        public static readonly StringName GetDepth = "get_depth";
        /// <summary>
        /// Cached name for the 'set_spin_degrees' method.
        /// </summary>
        public static readonly StringName SetSpinDegrees = "set_spin_degrees";
        /// <summary>
        /// Cached name for the 'get_spin_degrees' method.
        /// </summary>
        public static readonly StringName GetSpinDegrees = "get_spin_degrees";
        /// <summary>
        /// Cached name for the 'set_spin_sides' method.
        /// </summary>
        public static readonly StringName SetSpinSides = "set_spin_sides";
        /// <summary>
        /// Cached name for the 'get_spin_sides' method.
        /// </summary>
        public static readonly StringName GetSpinSides = "get_spin_sides";
        /// <summary>
        /// Cached name for the 'set_path_node' method.
        /// </summary>
        public static readonly StringName SetPathNode = "set_path_node";
        /// <summary>
        /// Cached name for the 'get_path_node' method.
        /// </summary>
        public static readonly StringName GetPathNode = "get_path_node";
        /// <summary>
        /// Cached name for the 'set_path_interval_type' method.
        /// </summary>
        public static readonly StringName SetPathIntervalType = "set_path_interval_type";
        /// <summary>
        /// Cached name for the 'get_path_interval_type' method.
        /// </summary>
        public static readonly StringName GetPathIntervalType = "get_path_interval_type";
        /// <summary>
        /// Cached name for the 'set_path_interval' method.
        /// </summary>
        public static readonly StringName SetPathInterval = "set_path_interval";
        /// <summary>
        /// Cached name for the 'get_path_interval' method.
        /// </summary>
        public static readonly StringName GetPathInterval = "get_path_interval";
        /// <summary>
        /// Cached name for the 'set_path_simplify_angle' method.
        /// </summary>
        public static readonly StringName SetPathSimplifyAngle = "set_path_simplify_angle";
        /// <summary>
        /// Cached name for the 'get_path_simplify_angle' method.
        /// </summary>
        public static readonly StringName GetPathSimplifyAngle = "get_path_simplify_angle";
        /// <summary>
        /// Cached name for the 'set_path_rotation' method.
        /// </summary>
        public static readonly StringName SetPathRotation = "set_path_rotation";
        /// <summary>
        /// Cached name for the 'get_path_rotation' method.
        /// </summary>
        public static readonly StringName GetPathRotation = "get_path_rotation";
        /// <summary>
        /// Cached name for the 'set_path_rotation_accurate' method.
        /// </summary>
        public static readonly StringName SetPathRotationAccurate = "set_path_rotation_accurate";
        /// <summary>
        /// Cached name for the 'get_path_rotation_accurate' method.
        /// </summary>
        public static readonly StringName GetPathRotationAccurate = "get_path_rotation_accurate";
        /// <summary>
        /// Cached name for the 'set_path_local' method.
        /// </summary>
        public static readonly StringName SetPathLocal = "set_path_local";
        /// <summary>
        /// Cached name for the 'is_path_local' method.
        /// </summary>
        public static readonly StringName IsPathLocal = "is_path_local";
        /// <summary>
        /// Cached name for the 'set_path_continuous_u' method.
        /// </summary>
        public static readonly StringName SetPathContinuousU = "set_path_continuous_u";
        /// <summary>
        /// Cached name for the 'is_path_continuous_u' method.
        /// </summary>
        public static readonly StringName IsPathContinuousU = "is_path_continuous_u";
        /// <summary>
        /// Cached name for the 'set_path_u_distance' method.
        /// </summary>
        public static readonly StringName SetPathUDistance = "set_path_u_distance";
        /// <summary>
        /// Cached name for the 'get_path_u_distance' method.
        /// </summary>
        public static readonly StringName GetPathUDistance = "get_path_u_distance";
        /// <summary>
        /// Cached name for the 'set_path_joined' method.
        /// </summary>
        public static readonly StringName SetPathJoined = "set_path_joined";
        /// <summary>
        /// Cached name for the 'is_path_joined' method.
        /// </summary>
        public static readonly StringName IsPathJoined = "is_path_joined";
        /// <summary>
        /// Cached name for the 'set_material' method.
        /// </summary>
        public static readonly StringName SetMaterial = "set_material";
        /// <summary>
        /// Cached name for the 'get_material' method.
        /// </summary>
        public static readonly StringName GetMaterial = "get_material";
        /// <summary>
        /// Cached name for the 'set_smooth_faces' method.
        /// </summary>
        public static readonly StringName SetSmoothFaces = "set_smooth_faces";
        /// <summary>
        /// Cached name for the 'get_smooth_faces' method.
        /// </summary>
        public static readonly StringName GetSmoothFaces = "get_smooth_faces";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : CsgPrimitive3D.SignalName
    {
    }
}
