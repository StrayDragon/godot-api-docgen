namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>Container for parsed source geometry data used in navigation mesh baking.</para>
/// </summary>
public partial class NavigationMeshSourceGeometryData3D : Resource
{
    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public float[] Vertices
    {
        get
        {
            return GetVertices();
        }
        set
        {
            SetVertices(value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public int[] Indices
    {
        get
        {
            return GetIndices();
        }
        set
        {
            SetIndices(value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete.
    public Godot.Collections.Array ProjectedObstructions
    {
        get
        {
            return GetProjectedObstructions();
        }
        set
        {
            SetProjectedObstructions(value);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete.

    private static readonly System.Type CachedType = typeof(NavigationMeshSourceGeometryData3D);

    private static readonly StringName NativeName = "NavigationMeshSourceGeometryData3D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public NavigationMeshSourceGeometryData3D() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal NavigationMeshSourceGeometryData3D(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal NavigationMeshSourceGeometryData3D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVertices, 2899603908ul);

    /// <summary>
    /// <para>Sets the parsed source geometry data vertices. The vertices need to be matched with appropriated indices.</para>
    /// <para><b>Warning:</b> Inappropriate data can crash the baking process of the involved third-party libraries.</para>
    /// </summary>
    public void SetVertices(float[] vertices)
    {
        NativeCalls.godot_icall_1_647(MethodBind0, GodotObject.GetPtr(this), vertices);
    }

    /// <summary>
    /// <para>Sets the parsed source geometry data vertices. The vertices need to be matched with appropriated indices.</para>
    /// <para><b>Warning:</b> Inappropriate data can crash the baking process of the involved third-party libraries.</para>
    /// </summary>
    public void SetVertices(ReadOnlySpan<float> vertices)
    {
        NativeCalls.godot_icall_1_647(MethodBind0, GodotObject.GetPtr(this), vertices);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetVertices, 675695659ul);

    /// <summary>
    /// <para>Returns the parsed source geometry data vertices array.</para>
    /// </summary>
    public float[] GetVertices()
    {
        return NativeCalls.godot_icall_0_368(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetIndices, 3614634198ul);

    /// <summary>
    /// <para>Sets the parsed source geometry data indices. The indices need to be matched with appropriated vertices.</para>
    /// <para><b>Warning:</b> Inappropriate data can crash the baking process of the involved third-party libraries.</para>
    /// </summary>
    public void SetIndices(int[] indices)
    {
        NativeCalls.godot_icall_1_150(MethodBind2, GodotObject.GetPtr(this), indices);
    }

    /// <summary>
    /// <para>Sets the parsed source geometry data indices. The indices need to be matched with appropriated vertices.</para>
    /// <para><b>Warning:</b> Inappropriate data can crash the baking process of the involved third-party libraries.</para>
    /// </summary>
    public void SetIndices(ReadOnlySpan<int> indices)
    {
        NativeCalls.godot_icall_1_150(MethodBind2, GodotObject.GetPtr(this), indices);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetIndices, 1930428628ul);

    /// <summary>
    /// <para>Returns the parsed source geometry data indices array.</para>
    /// </summary>
    public int[] GetIndices()
    {
        return NativeCalls.godot_icall_0_151(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AppendArrays, 3117535015ul);

    /// <summary>
    /// <para>Appends arrays of <paramref name="vertices"/> and <paramref name="indices"/> at the end of the existing arrays. Adds the existing index as an offset to the appended indices.</para>
    /// </summary>
    public void AppendArrays(float[] vertices, int[] indices)
    {
        NativeCalls.godot_icall_2_839(MethodBind4, GodotObject.GetPtr(this), vertices, indices);
    }

    /// <summary>
    /// <para>Appends arrays of <paramref name="vertices"/> and <paramref name="indices"/> at the end of the existing arrays. Adds the existing index as an offset to the appended indices.</para>
    /// </summary>
    public void AppendArrays(ReadOnlySpan<float> vertices, ReadOnlySpan<int> indices)
    {
        NativeCalls.godot_icall_2_839(MethodBind4, GodotObject.GetPtr(this), vertices, indices);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Clear, 3218959716ul);

    /// <summary>
    /// <para>Clears the internal data.</para>
    /// </summary>
    public void Clear()
    {
        NativeCalls.godot_icall_0_3(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasData, 2240911060ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> when parsed source geometry data exists.</para>
    /// </summary>
    public bool HasData()
    {
        return NativeCalls.godot_icall_0_15(MethodBind6, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddMesh, 975462459ul);

    /// <summary>
    /// <para>Adds the geometry data of a <see cref="Godot.Mesh"/> resource to the navigation mesh baking data. The mesh must have valid triangulated mesh data to be considered. Since <see cref="Godot.NavigationMesh"/> resources have no transform, all vertex positions need to be offset by the node's transform using <paramref name="xform"/>.</para>
    /// </summary>
    public unsafe void AddMesh(Mesh mesh, Transform3D xform)
    {
        NativeCalls.godot_icall_2_840(MethodBind7, GodotObject.GetPtr(this), GodotObject.GetPtr(mesh), &xform);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddMeshArray, 4235710913ul);

    /// <summary>
    /// <para>Adds an <see cref="Godot.Collections.Array"/> the size of <see cref="Godot.Mesh.ArrayType.Max"/> and with vertices at index <see cref="Godot.Mesh.ArrayType.Vertex"/> and indices at index <see cref="Godot.Mesh.ArrayType.Index"/> to the navigation mesh baking data. The array must have valid triangulated mesh data to be considered. Since <see cref="Godot.NavigationMesh"/> resources have no transform, all vertex positions need to be offset by the node's transform using <paramref name="xform"/>.</para>
    /// </summary>
    public unsafe void AddMeshArray(Godot.Collections.Array meshArray, Transform3D xform)
    {
        NativeCalls.godot_icall_2_841(MethodBind8, GodotObject.GetPtr(this), (godot_array)(meshArray ?? new()).NativeValue, &xform);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddFaces, 1440358797ul);

    /// <summary>
    /// <para>Adds an array of vertex positions to the geometry data for navigation mesh baking to form triangulated faces. For each face the array must have three vertex positions in clockwise winding order. Since <see cref="Godot.NavigationMesh"/> resources have no transform, all vertex positions need to be offset by the node's transform using <paramref name="xform"/>.</para>
    /// </summary>
    public unsafe void AddFaces(Vector3[] faces, Transform3D xform)
    {
        NativeCalls.godot_icall_2_842(MethodBind9, GodotObject.GetPtr(this), faces, &xform);
    }

    /// <summary>
    /// <para>Adds an array of vertex positions to the geometry data for navigation mesh baking to form triangulated faces. For each face the array must have three vertex positions in clockwise winding order. Since <see cref="Godot.NavigationMesh"/> resources have no transform, all vertex positions need to be offset by the node's transform using <paramref name="xform"/>.</para>
    /// </summary>
    public unsafe void AddFaces(ReadOnlySpan<Vector3> faces, Transform3D xform)
    {
        NativeCalls.godot_icall_2_842(MethodBind9, GodotObject.GetPtr(this), faces, &xform);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Merge, 655828145ul);

    /// <summary>
    /// <para>Adds the geometry data of another <see cref="Godot.NavigationMeshSourceGeometryData3D"/> to the navigation mesh baking data.</para>
    /// </summary>
    public void Merge(NavigationMeshSourceGeometryData3D otherGeometry)
    {
        NativeCalls.godot_icall_1_56(MethodBind10, GodotObject.GetPtr(this), GodotObject.GetPtr(otherGeometry));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddProjectedObstruction, 3351846707ul);

    /// <summary>
    /// <para>Adds a projected obstruction shape to the source geometry. The <paramref name="vertices"/> are considered projected on an xz-axes plane, placed at the global y-axis <paramref name="elevation"/> and extruded by <paramref name="height"/>. If <paramref name="carve"/> is <see langword="true"/> the carved shape will not be affected by additional offsets (e.g. agent radius) of the navigation mesh baking process.</para>
    /// </summary>
    public void AddProjectedObstruction(Vector3[] vertices, float elevation, float height, bool carve)
    {
        NativeCalls.godot_icall_4_843(MethodBind11, GodotObject.GetPtr(this), vertices, elevation, height, carve.ToGodotBool());
    }

    /// <summary>
    /// <para>Adds a projected obstruction shape to the source geometry. The <paramref name="vertices"/> are considered projected on an xz-axes plane, placed at the global y-axis <paramref name="elevation"/> and extruded by <paramref name="height"/>. If <paramref name="carve"/> is <see langword="true"/> the carved shape will not be affected by additional offsets (e.g. agent radius) of the navigation mesh baking process.</para>
    /// </summary>
    public void AddProjectedObstruction(ReadOnlySpan<Vector3> vertices, float elevation, float height, bool carve)
    {
        NativeCalls.godot_icall_4_843(MethodBind11, GodotObject.GetPtr(this), vertices, elevation, height, carve.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ClearProjectedObstructions, 3218959716ul);

    /// <summary>
    /// <para>Clears all projected obstructions.</para>
    /// </summary>
    public void ClearProjectedObstructions()
    {
        NativeCalls.godot_icall_0_3(MethodBind12, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetProjectedObstructions, 381264803ul);

    /// <summary>
    /// <para>Sets the projected obstructions with an Array of Dictionaries with the following key value pairs:</para>
    /// <para></para>
    /// </summary>
    public void SetProjectedObstructions(Godot.Collections.Array projectedObstructions)
    {
        NativeCalls.godot_icall_1_138(MethodBind13, GodotObject.GetPtr(this), (godot_array)(projectedObstructions ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetProjectedObstructions, 3995934104ul);

    /// <summary>
    /// <para>Returns the projected obstructions as an <see cref="Godot.Collections.Array"/> of dictionaries. Each <see cref="Godot.Collections.Dictionary"/> contains the following entries:</para>
    /// <para>- <c>vertices</c> - A <see cref="float"/>[] that defines the outline points of the projected shape.</para>
    /// <para>- <c>elevation</c> - A <see cref="float"/> that defines the projected shape placement on the y-axis.</para>
    /// <para>- <c>height</c> - A <see cref="float"/> that defines how much the projected shape is extruded along the y-axis.</para>
    /// <para>- <c>carve</c> - A <see cref="bool"/> that defines how the obstacle affects the navigation mesh baking. If <see langword="true"/> the projected shape will not be affected by addition offsets, e.g. agent radius.</para>
    /// </summary>
    public Godot.Collections.Array GetProjectedObstructions()
    {
        return NativeCalls.godot_icall_0_120(MethodBind14, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBounds, 1021181044ul);

    /// <summary>
    /// <para>Returns an axis-aligned bounding box that covers all the stored geometry data. The bounds are calculated when calling this function with the result cached until further geometry changes are made.</para>
    /// </summary>
    public Aabb GetBounds()
    {
        return NativeCalls.godot_icall_0_184(MethodBind15, GodotObject.GetPtr(this));
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
        /// Cached name for the 'vertices' property.
        /// </summary>
        public static readonly StringName Vertices = "vertices";
        /// <summary>
        /// Cached name for the 'indices' property.
        /// </summary>
        public static readonly StringName Indices = "indices";
        /// <summary>
        /// Cached name for the 'projected_obstructions' property.
        /// </summary>
        public static readonly StringName ProjectedObstructions = "projected_obstructions";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Resource.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_vertices' method.
        /// </summary>
        public static readonly StringName SetVertices = "set_vertices";
        /// <summary>
        /// Cached name for the 'get_vertices' method.
        /// </summary>
        public static readonly StringName GetVertices = "get_vertices";
        /// <summary>
        /// Cached name for the 'set_indices' method.
        /// </summary>
        public static readonly StringName SetIndices = "set_indices";
        /// <summary>
        /// Cached name for the 'get_indices' method.
        /// </summary>
        public static readonly StringName GetIndices = "get_indices";
        /// <summary>
        /// Cached name for the 'append_arrays' method.
        /// </summary>
        public static readonly StringName AppendArrays = "append_arrays";
        /// <summary>
        /// Cached name for the 'clear' method.
        /// </summary>
        public static readonly StringName Clear = "clear";
        /// <summary>
        /// Cached name for the 'has_data' method.
        /// </summary>
        public static readonly StringName HasData = "has_data";
        /// <summary>
        /// Cached name for the 'add_mesh' method.
        /// </summary>
        public static readonly StringName AddMesh = "add_mesh";
        /// <summary>
        /// Cached name for the 'add_mesh_array' method.
        /// </summary>
        public static readonly StringName AddMeshArray = "add_mesh_array";
        /// <summary>
        /// Cached name for the 'add_faces' method.
        /// </summary>
        public static readonly StringName AddFaces = "add_faces";
        /// <summary>
        /// Cached name for the 'merge' method.
        /// </summary>
        public static readonly StringName Merge = "merge";
        /// <summary>
        /// Cached name for the 'add_projected_obstruction' method.
        /// </summary>
        public static readonly StringName AddProjectedObstruction = "add_projected_obstruction";
        /// <summary>
        /// Cached name for the 'clear_projected_obstructions' method.
        /// </summary>
        public static readonly StringName ClearProjectedObstructions = "clear_projected_obstructions";
        /// <summary>
        /// Cached name for the 'set_projected_obstructions' method.
        /// </summary>
        public static readonly StringName SetProjectedObstructions = "set_projected_obstructions";
        /// <summary>
        /// Cached name for the 'get_projected_obstructions' method.
        /// </summary>
        public static readonly StringName GetProjectedObstructions = "get_projected_obstructions";
        /// <summary>
        /// Cached name for the 'get_bounds' method.
        /// </summary>
        public static readonly StringName GetBounds = "get_bounds";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Resource.SignalName
    {
    }
}
