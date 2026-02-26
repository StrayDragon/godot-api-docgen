namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Parameters to be used with a <see cref="Godot.Mesh"/> convex decomposition operation.</para>
/// </summary>
public partial class MeshConvexDecompositionSettings : RefCounted
{
    public enum ModeEnum : long
    {
        /// <summary>
        /// <para>Constant for voxel-based approximate convex decomposition.</para>
        /// </summary>
        Voxel = 0,
        /// <summary>
        /// <para>Constant for tetrahedron-based approximate convex decomposition.</para>
        /// </summary>
        Tetrahedron = 1
    }

    /// <summary>
    /// <para>Maximum concavity. Ranges from <c>0.0</c> to <c>1.0</c>.</para>
    /// </summary>
    public float MaxConcavity
    {
        get
        {
            return GetMaxConcavity();
        }
        set
        {
            SetMaxConcavity(value);
        }
    }

    /// <summary>
    /// <para>Controls the bias toward clipping along symmetry planes. Ranges from <c>0.0</c> to <c>1.0</c>.</para>
    /// </summary>
    public float SymmetryPlanesClippingBias
    {
        get
        {
            return GetSymmetryPlanesClippingBias();
        }
        set
        {
            SetSymmetryPlanesClippingBias(value);
        }
    }

    /// <summary>
    /// <para>Controls the bias toward clipping along revolution axes. Ranges from <c>0.0</c> to <c>1.0</c>.</para>
    /// </summary>
    public float RevolutionAxesClippingBias
    {
        get
        {
            return GetRevolutionAxesClippingBias();
        }
        set
        {
            SetRevolutionAxesClippingBias(value);
        }
    }

    /// <summary>
    /// <para>Controls the adaptive sampling of the generated convex-hulls. Ranges from <c>0.0</c> to <c>0.01</c>.</para>
    /// </summary>
    public float MinVolumePerConvexHull
    {
        get
        {
            return GetMinVolumePerConvexHull();
        }
        set
        {
            SetMinVolumePerConvexHull(value);
        }
    }

    /// <summary>
    /// <para>Maximum number of voxels generated during the voxelization stage.</para>
    /// </summary>
    public uint Resolution
    {
        get
        {
            return GetResolution();
        }
        set
        {
            SetResolution(value);
        }
    }

    /// <summary>
    /// <para>Controls the maximum number of triangles per convex-hull. Ranges from <c>4</c> to <c>1024</c>.</para>
    /// </summary>
    public uint MaxNumVerticesPerConvexHull
    {
        get
        {
            return GetMaxNumVerticesPerConvexHull();
        }
        set
        {
            SetMaxNumVerticesPerConvexHull(value);
        }
    }

    /// <summary>
    /// <para>Controls the granularity of the search for the "best" clipping plane. Ranges from <c>1</c> to <c>16</c>.</para>
    /// </summary>
    public uint PlaneDownsampling
    {
        get
        {
            return GetPlaneDownsampling();
        }
        set
        {
            SetPlaneDownsampling(value);
        }
    }

    /// <summary>
    /// <para>Controls the precision of the convex-hull generation process during the clipping plane selection stage. Ranges from <c>1</c> to <c>16</c>.</para>
    /// </summary>
    public uint ConvexHullDownsampling
    {
        get
        {
            return GetConvexHullDownsampling();
        }
        set
        {
            SetConvexHullDownsampling(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, normalizes the mesh before applying the convex decomposition.</para>
    /// </summary>
    public bool NormalizeMesh
    {
        get
        {
            return GetNormalizeMesh();
        }
        set
        {
            SetNormalizeMesh(value);
        }
    }

    /// <summary>
    /// <para>Mode for the approximate convex decomposition.</para>
    /// </summary>
    public MeshConvexDecompositionSettings.ModeEnum Mode
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
    /// <para>If <see langword="true"/>, uses approximation for computing convex hulls.</para>
    /// </summary>
    public bool ConvexHullApproximation
    {
        get
        {
            return GetConvexHullApproximation();
        }
        set
        {
            SetConvexHullApproximation(value);
        }
    }

    /// <summary>
    /// <para>The maximum number of convex hulls to produce from the merge operation.</para>
    /// </summary>
    public uint MaxConvexHulls
    {
        get
        {
            return GetMaxConvexHulls();
        }
        set
        {
            SetMaxConvexHulls(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, projects output convex hull vertices onto the original source mesh to increase floating-point accuracy of the results.</para>
    /// </summary>
    public bool ProjectHullVertices
    {
        get
        {
            return GetProjectHullVertices();
        }
        set
        {
            SetProjectHullVertices(value);
        }
    }

    private static readonly System.Type CachedType = typeof(MeshConvexDecompositionSettings);

    private static readonly StringName NativeName = "MeshConvexDecompositionSettings";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public MeshConvexDecompositionSettings() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal MeshConvexDecompositionSettings(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal MeshConvexDecompositionSettings(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMaxConcavity, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMaxConcavity(float maxConcavity)
    {
        NativeCalls.godot_icall_1_67(MethodBind0, GodotObject.GetPtr(this), maxConcavity);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMaxConcavity, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetMaxConcavity()
    {
        return NativeCalls.godot_icall_0_68(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSymmetryPlanesClippingBias, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSymmetryPlanesClippingBias(float symmetryPlanesClippingBias)
    {
        NativeCalls.godot_icall_1_67(MethodBind2, GodotObject.GetPtr(this), symmetryPlanesClippingBias);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSymmetryPlanesClippingBias, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetSymmetryPlanesClippingBias()
    {
        return NativeCalls.godot_icall_0_68(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRevolutionAxesClippingBias, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetRevolutionAxesClippingBias(float revolutionAxesClippingBias)
    {
        NativeCalls.godot_icall_1_67(MethodBind4, GodotObject.GetPtr(this), revolutionAxesClippingBias);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRevolutionAxesClippingBias, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetRevolutionAxesClippingBias()
    {
        return NativeCalls.godot_icall_0_68(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMinVolumePerConvexHull, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMinVolumePerConvexHull(float minVolumePerConvexHull)
    {
        NativeCalls.godot_icall_1_67(MethodBind6, GodotObject.GetPtr(this), minVolumePerConvexHull);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMinVolumePerConvexHull, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetMinVolumePerConvexHull()
    {
        return NativeCalls.godot_icall_0_68(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetResolution, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetResolution(uint minVolumePerConvexHull)
    {
        NativeCalls.godot_icall_1_208(MethodBind8, GodotObject.GetPtr(this), minVolumePerConvexHull);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetResolution, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public uint GetResolution()
    {
        return NativeCalls.godot_icall_0_209(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMaxNumVerticesPerConvexHull, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMaxNumVerticesPerConvexHull(uint maxNumVerticesPerConvexHull)
    {
        NativeCalls.godot_icall_1_208(MethodBind10, GodotObject.GetPtr(this), maxNumVerticesPerConvexHull);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMaxNumVerticesPerConvexHull, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public uint GetMaxNumVerticesPerConvexHull()
    {
        return NativeCalls.godot_icall_0_209(MethodBind11, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPlaneDownsampling, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPlaneDownsampling(uint planeDownsampling)
    {
        NativeCalls.godot_icall_1_208(MethodBind12, GodotObject.GetPtr(this), planeDownsampling);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPlaneDownsampling, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public uint GetPlaneDownsampling()
    {
        return NativeCalls.godot_icall_0_209(MethodBind13, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetConvexHullDownsampling, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetConvexHullDownsampling(uint convexHullDownsampling)
    {
        NativeCalls.godot_icall_1_208(MethodBind14, GodotObject.GetPtr(this), convexHullDownsampling);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetConvexHullDownsampling, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public uint GetConvexHullDownsampling()
    {
        return NativeCalls.godot_icall_0_209(MethodBind15, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetNormalizeMesh, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetNormalizeMesh(bool normalizeMesh)
    {
        NativeCalls.godot_icall_1_14(MethodBind16, GodotObject.GetPtr(this), normalizeMesh.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNormalizeMesh, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetNormalizeMesh()
    {
        return NativeCalls.godot_icall_0_15(MethodBind17, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMode, 1668072869ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMode(MeshConvexDecompositionSettings.ModeEnum mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind18, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMode, 23479454ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public MeshConvexDecompositionSettings.ModeEnum GetMode()
    {
        return (MeshConvexDecompositionSettings.ModeEnum)NativeCalls.godot_icall_0_39(MethodBind19, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetConvexHullApproximation, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetConvexHullApproximation(bool convexHullApproximation)
    {
        NativeCalls.godot_icall_1_14(MethodBind20, GodotObject.GetPtr(this), convexHullApproximation.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetConvexHullApproximation, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetConvexHullApproximation()
    {
        return NativeCalls.godot_icall_0_15(MethodBind21, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMaxConvexHulls, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMaxConvexHulls(uint maxConvexHulls)
    {
        NativeCalls.godot_icall_1_208(MethodBind22, GodotObject.GetPtr(this), maxConvexHulls);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMaxConvexHulls, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public uint GetMaxConvexHulls()
    {
        return NativeCalls.godot_icall_0_209(MethodBind23, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetProjectHullVertices, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetProjectHullVertices(bool projectHullVertices)
    {
        NativeCalls.godot_icall_1_14(MethodBind24, GodotObject.GetPtr(this), projectHullVertices.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetProjectHullVertices, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetProjectHullVertices()
    {
        return NativeCalls.godot_icall_0_15(MethodBind25, GodotObject.GetPtr(this)).ToBool();
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
    public new class PropertyName : RefCounted.PropertyName
    {
        /// <summary>
        /// Cached name for the 'max_concavity' property.
        /// </summary>
        public static readonly StringName MaxConcavity = "max_concavity";
        /// <summary>
        /// Cached name for the 'symmetry_planes_clipping_bias' property.
        /// </summary>
        public static readonly StringName SymmetryPlanesClippingBias = "symmetry_planes_clipping_bias";
        /// <summary>
        /// Cached name for the 'revolution_axes_clipping_bias' property.
        /// </summary>
        public static readonly StringName RevolutionAxesClippingBias = "revolution_axes_clipping_bias";
        /// <summary>
        /// Cached name for the 'min_volume_per_convex_hull' property.
        /// </summary>
        public static readonly StringName MinVolumePerConvexHull = "min_volume_per_convex_hull";
        /// <summary>
        /// Cached name for the 'resolution' property.
        /// </summary>
        public static readonly StringName Resolution = "resolution";
        /// <summary>
        /// Cached name for the 'max_num_vertices_per_convex_hull' property.
        /// </summary>
        public static readonly StringName MaxNumVerticesPerConvexHull = "max_num_vertices_per_convex_hull";
        /// <summary>
        /// Cached name for the 'plane_downsampling' property.
        /// </summary>
        public static readonly StringName PlaneDownsampling = "plane_downsampling";
        /// <summary>
        /// Cached name for the 'convex_hull_downsampling' property.
        /// </summary>
        public static readonly StringName ConvexHullDownsampling = "convex_hull_downsampling";
        /// <summary>
        /// Cached name for the 'normalize_mesh' property.
        /// </summary>
        public static readonly StringName NormalizeMesh = "normalize_mesh";
        /// <summary>
        /// Cached name for the 'mode' property.
        /// </summary>
        public static readonly StringName Mode = "mode";
        /// <summary>
        /// Cached name for the 'convex_hull_approximation' property.
        /// </summary>
        public static readonly StringName ConvexHullApproximation = "convex_hull_approximation";
        /// <summary>
        /// Cached name for the 'max_convex_hulls' property.
        /// </summary>
        public static readonly StringName MaxConvexHulls = "max_convex_hulls";
        /// <summary>
        /// Cached name for the 'project_hull_vertices' property.
        /// </summary>
        public static readonly StringName ProjectHullVertices = "project_hull_vertices";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : RefCounted.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_max_concavity' method.
        /// </summary>
        public static readonly StringName SetMaxConcavity = "set_max_concavity";
        /// <summary>
        /// Cached name for the 'get_max_concavity' method.
        /// </summary>
        public static readonly StringName GetMaxConcavity = "get_max_concavity";
        /// <summary>
        /// Cached name for the 'set_symmetry_planes_clipping_bias' method.
        /// </summary>
        public static readonly StringName SetSymmetryPlanesClippingBias = "set_symmetry_planes_clipping_bias";
        /// <summary>
        /// Cached name for the 'get_symmetry_planes_clipping_bias' method.
        /// </summary>
        public static readonly StringName GetSymmetryPlanesClippingBias = "get_symmetry_planes_clipping_bias";
        /// <summary>
        /// Cached name for the 'set_revolution_axes_clipping_bias' method.
        /// </summary>
        public static readonly StringName SetRevolutionAxesClippingBias = "set_revolution_axes_clipping_bias";
        /// <summary>
        /// Cached name for the 'get_revolution_axes_clipping_bias' method.
        /// </summary>
        public static readonly StringName GetRevolutionAxesClippingBias = "get_revolution_axes_clipping_bias";
        /// <summary>
        /// Cached name for the 'set_min_volume_per_convex_hull' method.
        /// </summary>
        public static readonly StringName SetMinVolumePerConvexHull = "set_min_volume_per_convex_hull";
        /// <summary>
        /// Cached name for the 'get_min_volume_per_convex_hull' method.
        /// </summary>
        public static readonly StringName GetMinVolumePerConvexHull = "get_min_volume_per_convex_hull";
        /// <summary>
        /// Cached name for the 'set_resolution' method.
        /// </summary>
        public static readonly StringName SetResolution = "set_resolution";
        /// <summary>
        /// Cached name for the 'get_resolution' method.
        /// </summary>
        public static readonly StringName GetResolution = "get_resolution";
        /// <summary>
        /// Cached name for the 'set_max_num_vertices_per_convex_hull' method.
        /// </summary>
        public static readonly StringName SetMaxNumVerticesPerConvexHull = "set_max_num_vertices_per_convex_hull";
        /// <summary>
        /// Cached name for the 'get_max_num_vertices_per_convex_hull' method.
        /// </summary>
        public static readonly StringName GetMaxNumVerticesPerConvexHull = "get_max_num_vertices_per_convex_hull";
        /// <summary>
        /// Cached name for the 'set_plane_downsampling' method.
        /// </summary>
        public static readonly StringName SetPlaneDownsampling = "set_plane_downsampling";
        /// <summary>
        /// Cached name for the 'get_plane_downsampling' method.
        /// </summary>
        public static readonly StringName GetPlaneDownsampling = "get_plane_downsampling";
        /// <summary>
        /// Cached name for the 'set_convex_hull_downsampling' method.
        /// </summary>
        public static readonly StringName SetConvexHullDownsampling = "set_convex_hull_downsampling";
        /// <summary>
        /// Cached name for the 'get_convex_hull_downsampling' method.
        /// </summary>
        public static readonly StringName GetConvexHullDownsampling = "get_convex_hull_downsampling";
        /// <summary>
        /// Cached name for the 'set_normalize_mesh' method.
        /// </summary>
        public static readonly StringName SetNormalizeMesh = "set_normalize_mesh";
        /// <summary>
        /// Cached name for the 'get_normalize_mesh' method.
        /// </summary>
        public static readonly StringName GetNormalizeMesh = "get_normalize_mesh";
        /// <summary>
        /// Cached name for the 'set_mode' method.
        /// </summary>
        public static readonly StringName SetMode = "set_mode";
        /// <summary>
        /// Cached name for the 'get_mode' method.
        /// </summary>
        public static readonly StringName GetMode = "get_mode";
        /// <summary>
        /// Cached name for the 'set_convex_hull_approximation' method.
        /// </summary>
        public static readonly StringName SetConvexHullApproximation = "set_convex_hull_approximation";
        /// <summary>
        /// Cached name for the 'get_convex_hull_approximation' method.
        /// </summary>
        public static readonly StringName GetConvexHullApproximation = "get_convex_hull_approximation";
        /// <summary>
        /// Cached name for the 'set_max_convex_hulls' method.
        /// </summary>
        public static readonly StringName SetMaxConvexHulls = "set_max_convex_hulls";
        /// <summary>
        /// Cached name for the 'get_max_convex_hulls' method.
        /// </summary>
        public static readonly StringName GetMaxConvexHulls = "get_max_convex_hulls";
        /// <summary>
        /// Cached name for the 'set_project_hull_vertices' method.
        /// </summary>
        public static readonly StringName SetProjectHullVertices = "set_project_hull_vertices";
        /// <summary>
        /// Cached name for the 'get_project_hull_vertices' method.
        /// </summary>
        public static readonly StringName GetProjectHullVertices = "get_project_hull_vertices";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : RefCounted.SignalName
    {
    }
}
