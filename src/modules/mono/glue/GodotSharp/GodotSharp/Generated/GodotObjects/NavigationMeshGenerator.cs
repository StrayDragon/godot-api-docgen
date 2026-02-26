namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This class is responsible for creating and clearing 3D navigation meshes used as <see cref="Godot.NavigationMesh"/> resources inside <see cref="Godot.NavigationRegion3D"/>. The <see cref="Godot.NavigationMeshGenerator"/> has very limited to no use for 2D as the navigation mesh baking process expects 3D node types and 3D source geometry to parse.</para>
/// <para>The entire navigation mesh baking is best done in a separate thread as the voxelization, collision tests and mesh optimization steps involved are very slow and performance-intensive operations.</para>
/// <para>Navigation mesh baking happens in multiple steps and the result depends on 3D source geometry and properties of the <see cref="Godot.NavigationMesh"/> resource. In the first step, starting from a root node and depending on <see cref="Godot.NavigationMesh"/> properties all valid 3D source geometry nodes are collected from the <see cref="Godot.SceneTree"/>. Second, all collected nodes are parsed for their relevant 3D geometry data and a combined 3D mesh is build. Due to the many different types of parsable objects, from normal <see cref="Godot.MeshInstance3D"/>s to <see cref="Godot.CsgShape3D"/>s or various <see cref="Godot.CollisionObject3D"/>s, some operations to collect geometry data can trigger <see cref="Godot.RenderingServer"/> and <see cref="Godot.PhysicsServer3D"/> synchronizations. Server synchronization can have a negative effect on baking time or framerate as it often involves <see cref="Godot.Mutex"/> locking for thread security. Many parsable objects and the continuous synchronization with other threaded Servers can increase the baking time significantly. On the other hand only a few but very large and complex objects will take some time to prepare for the Servers which can noticeably stall the next frame render. As a general rule the total number of parsable objects and their individual size and complexity should be balanced to avoid framerate issues or very long baking times. The combined mesh is then passed to the Recast Navigation Object to test the source geometry for walkable terrain suitable to <see cref="Godot.NavigationMesh"/> agent properties by creating a voxel world around the meshes bounding area.</para>
/// <para>The finalized navigation mesh is then returned and stored inside the <see cref="Godot.NavigationMesh"/> for use as a resource inside <see cref="Godot.NavigationRegion3D"/> nodes.</para>
/// <para><b>Note:</b> Using meshes to not only define walkable surfaces but also obstruct navigation baking does not always work. The navigation baking has no concept of what is a geometry "inside" when dealing with mesh source geometry and this is intentional. Depending on current baking parameters, as soon as the obstructing mesh is large enough to fit a navigation mesh area inside, the baking will generate navigation mesh areas that are inside the obstructing source geometry mesh.</para>
/// </summary>
[Obsolete("This class is deprecated.")]
public static partial class NavigationMeshGenerator
{
    private static readonly StringName NativeName = "NavigationMeshGenerator";

    private static NavigationMeshGeneratorInstance singleton;

    public static NavigationMeshGeneratorInstance Singleton =>
        singleton ??= (NavigationMeshGeneratorInstance)InteropUtils.EngineGetSingleton("NavigationMeshGenerator");

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.Bake, 1401173477ul);

    /// <summary>
    /// <para>Bakes the <paramref name="navigationMesh"/> with source geometry collected starting from the <paramref name="rootNode"/>.</para>
    /// </summary>
    [Obsolete("This method is deprecated due to core threading changes. To upgrade existing code, first create a 'NavigationMeshSourceGeometryData3D' resource. Use this resource with 'Godot.NavigationMeshGenerator.ParseSourceGeometryData(NavigationMesh, NavigationMeshSourceGeometryData3D, Node, Callable)' to parse the 'SceneTree' for nodes that should contribute to the navigation mesh baking. The 'SceneTree' parsing needs to happen on the main thread. After the parsing is finished use the resource with 'Godot.NavigationMeshGenerator.BakeFromSourceGeometryData(NavigationMesh, NavigationMeshSourceGeometryData3D, Callable)' to bake a navigation mesh.")]
    public static void Bake(NavigationMesh navigationMesh, Node rootNode)
    {
        NativeCalls.godot_icall_2_239(MethodBind0, GodotObject.GetPtr(Singleton), GodotObject.GetPtr(navigationMesh), GodotObject.GetPtr(rootNode));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.Clear, 2923361153ul);

    /// <summary>
    /// <para>Removes all polygons and vertices from the provided <paramref name="navigationMesh"/> resource.</para>
    /// </summary>
    public static void Clear(NavigationMesh navigationMesh)
    {
        NativeCalls.godot_icall_1_56(MethodBind1, GodotObject.GetPtr(Singleton), GodotObject.GetPtr(navigationMesh));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.ParseSourceGeometryData, 3172802542ul);

    /// <summary>
    /// <para>Parses the <see cref="Godot.SceneTree"/> for source geometry according to the properties of <paramref name="navigationMesh"/>. Updates the provided <paramref name="sourceGeometryData"/> resource with the resulting data. The resource can then be used to bake a navigation mesh with <see cref="Godot.NavigationMeshGenerator.BakeFromSourceGeometryData(NavigationMesh, NavigationMeshSourceGeometryData3D, Callable)"/>. After the process is finished the optional <paramref name="callback"/> will be called.</para>
    /// <para><b>Note:</b> This function needs to run on the main thread or with a deferred call as the SceneTree is not thread-safe.</para>
    /// <para><b>Performance:</b> While convenient, reading data arrays from <see cref="Godot.Mesh"/> resources can affect the frame rate negatively. The data needs to be received from the GPU, stalling the <see cref="Godot.RenderingServer"/> in the process. For performance prefer the use of e.g. collision shapes or creating the data arrays entirely in code.</para>
    /// </summary>
    public static void ParseSourceGeometryData(NavigationMesh navigationMesh, NavigationMeshSourceGeometryData3D sourceGeometryData, Node rootNode, Callable callback = default)
    {
        NativeCalls.godot_icall_4_836(MethodBind2, GodotObject.GetPtr(Singleton), GodotObject.GetPtr(navigationMesh), GodotObject.GetPtr(sourceGeometryData), GodotObject.GetPtr(rootNode), callback);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.BakeFromSourceGeometryData, 1286748856ul);

    /// <summary>
    /// <para>Bakes the provided <paramref name="navigationMesh"/> with the data from the provided <paramref name="sourceGeometryData"/>. After the process is finished the optional <paramref name="callback"/> will be called.</para>
    /// </summary>
    public static void BakeFromSourceGeometryData(NavigationMesh navigationMesh, NavigationMeshSourceGeometryData3D sourceGeometryData, Callable callback = default)
    {
        NativeCalls.godot_icall_3_837(MethodBind3, GodotObject.GetPtr(Singleton), GodotObject.GetPtr(navigationMesh), GodotObject.GetPtr(sourceGeometryData), callback);
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public class PropertyName
    {
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public class MethodName
    {
        /// <summary>
        /// Cached name for the 'bake' method.
        /// </summary>
        public static readonly StringName Bake = "bake";
        /// <summary>
        /// Cached name for the 'clear' method.
        /// </summary>
        public static readonly StringName Clear = "clear";
        /// <summary>
        /// Cached name for the 'parse_source_geometry_data' method.
        /// </summary>
        public static readonly StringName ParseSourceGeometryData = "parse_source_geometry_data";
        /// <summary>
        /// Cached name for the 'bake_from_source_geometry_data' method.
        /// </summary>
        public static readonly StringName BakeFromSourceGeometryData = "bake_from_source_geometry_data";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public class SignalName
    {
    }
}
