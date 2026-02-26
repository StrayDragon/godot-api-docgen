namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This class provides access to a number of different monitors related to performance, such as memory usage, draw calls, and FPS. These are the same as the values displayed in the <b>Monitor</b> tab in the editor's <b>Debugger</b> panel. By using the <see cref="Godot.Performance.GetMonitor(Performance.Monitor)"/> method of this class, you can access this data from your code.</para>
/// <para>You can add custom monitors using the <see cref="Godot.Performance.AddCustomMonitor(StringName, Callable, Godot.Collections.Array, Performance.MonitorType)"/> method. Custom monitors are available in <b>Monitor</b> tab in the editor's <b>Debugger</b> panel together with built-in monitors.</para>
/// <para><b>Note:</b> Some of the built-in monitors are only available in debug mode and will always return <c>0</c> when used in a project exported in release mode.</para>
/// <para><b>Note:</b> Some of the built-in monitors are not updated in real-time for performance reasons, so there may be a delay of up to 1 second between changes.</para>
/// <para><b>Note:</b> Custom monitors do not support negative values. Negative values are clamped to 0.</para>
/// </summary>
public static partial class Performance
{
    public enum Monitor : long
    {
        /// <summary>
        /// <para>The number of frames rendered in the last second. This metric is only updated once per second, even if queried more often. <i>Higher is better.</i></para>
        /// </summary>
        TimeFps = 0,
        /// <summary>
        /// <para>Time it took to complete one frame, in seconds. <i>Lower is better.</i></para>
        /// </summary>
        TimeProcess = 1,
        /// <summary>
        /// <para>Time it took to complete one physics frame, in seconds. <i>Lower is better.</i></para>
        /// </summary>
        TimePhysicsProcess = 2,
        /// <summary>
        /// <para>Time it took to complete one navigation step, in seconds. This includes navigation map updates as well as agent avoidance calculations. <i>Lower is better.</i></para>
        /// </summary>
        TimeNavigationProcess = 3,
        /// <summary>
        /// <para>Static memory currently used, in bytes. Not available in release builds. <i>Lower is better.</i></para>
        /// </summary>
        MemoryStatic = 4,
        /// <summary>
        /// <para>Available static memory. Not available in release builds. <i>Lower is better.</i></para>
        /// </summary>
        MemoryStaticMax = 5,
        /// <summary>
        /// <para>Largest amount of memory the message queue buffer has used, in bytes. The message queue is used for deferred functions calls and notifications. <i>Lower is better.</i></para>
        /// </summary>
        MemoryMessageBufferMax = 6,
        /// <summary>
        /// <para>Number of objects currently instantiated (including nodes). <i>Lower is better.</i></para>
        /// </summary>
        ObjectCount = 7,
        /// <summary>
        /// <para>Number of resources currently used. <i>Lower is better.</i></para>
        /// </summary>
        ObjectResourceCount = 8,
        /// <summary>
        /// <para>Number of nodes currently instantiated in the scene tree. This also includes the root node. <i>Lower is better.</i></para>
        /// </summary>
        ObjectNodeCount = 9,
        /// <summary>
        /// <para>Number of orphan nodes, i.e. nodes which are not parented to a node of the scene tree. <i>Lower is better.</i></para>
        /// <para><b>Note:</b> This is only available in debug mode and will always return <c>0</c> when used in a project exported in release mode.</para>
        /// </summary>
        ObjectOrphanNodeCount = 10,
        /// <summary>
        /// <para>The total number of objects in the last rendered frame. This metric doesn't include culled objects (either via hiding nodes, frustum culling or occlusion culling). <i>Lower is better.</i></para>
        /// </summary>
        RenderTotalObjectsInFrame = 11,
        /// <summary>
        /// <para>The total number of vertices or indices rendered in the last rendered frame. This metric doesn't include primitives from culled objects (either via hiding nodes, frustum culling or occlusion culling). Due to the depth prepass and shadow passes, the number of primitives is always higher than the actual number of vertices in the scene (typically double or triple the original vertex count). <i>Lower is better.</i></para>
        /// </summary>
        RenderTotalPrimitivesInFrame = 12,
        /// <summary>
        /// <para>The total number of draw calls performed in the last rendered frame. This metric doesn't include culled objects (either via hiding nodes, frustum culling or occlusion culling), since they do not result in draw calls. <i>Lower is better.</i></para>
        /// </summary>
        RenderTotalDrawCallsInFrame = 13,
        /// <summary>
        /// <para>The amount of video memory used (texture and vertex memory combined, in bytes). Since this metric also includes miscellaneous allocations, this value is always greater than the sum of <see cref="Godot.Performance.Monitor.RenderTextureMemUsed"/> and <see cref="Godot.Performance.Monitor.RenderBufferMemUsed"/>. <i>Lower is better.</i></para>
        /// </summary>
        RenderVideoMemUsed = 14,
        /// <summary>
        /// <para>The amount of texture memory used (in bytes). <i>Lower is better.</i></para>
        /// </summary>
        RenderTextureMemUsed = 15,
        /// <summary>
        /// <para>The amount of render buffer memory used (in bytes). <i>Lower is better.</i></para>
        /// </summary>
        RenderBufferMemUsed = 16,
        /// <summary>
        /// <para>Number of active <see cref="Godot.RigidBody2D"/> nodes in the game. <i>Lower is better.</i></para>
        /// </summary>
        Physics2DActiveObjects = 17,
        /// <summary>
        /// <para>Number of collision pairs in the 2D physics engine. <i>Lower is better.</i></para>
        /// </summary>
        Physics2DCollisionPairs = 18,
        /// <summary>
        /// <para>Number of islands in the 2D physics engine. <i>Lower is better.</i></para>
        /// </summary>
        Physics2DIslandCount = 19,
        /// <summary>
        /// <para>Number of active <see cref="Godot.RigidBody3D"/> and <see cref="Godot.VehicleBody3D"/> nodes in the game. <i>Lower is better.</i></para>
        /// </summary>
        Physics3DActiveObjects = 20,
        /// <summary>
        /// <para>Number of collision pairs in the 3D physics engine. <i>Lower is better.</i></para>
        /// </summary>
        Physics3DCollisionPairs = 21,
        /// <summary>
        /// <para>Number of islands in the 3D physics engine. <i>Lower is better.</i></para>
        /// </summary>
        Physics3DIslandCount = 22,
        /// <summary>
        /// <para>Output latency of the <see cref="Godot.AudioServer"/>. Equivalent to calling <see cref="Godot.AudioServer.GetOutputLatency()"/>, it is not recommended to call this every frame.</para>
        /// </summary>
        AudioOutputLatency = 23,
        /// <summary>
        /// <para>Number of active navigation maps in <see cref="Godot.NavigationServer2D"/> and <see cref="Godot.NavigationServer3D"/>. This also includes the empty default navigation maps created by <see cref="Godot.World2D"/> and <see cref="Godot.World3D"/> instances.</para>
        /// </summary>
        NavigationActiveMaps = 24,
        /// <summary>
        /// <para>Number of active navigation regions in <see cref="Godot.NavigationServer2D"/> and <see cref="Godot.NavigationServer3D"/>.</para>
        /// </summary>
        NavigationRegionCount = 25,
        /// <summary>
        /// <para>Number of active navigation agents processing avoidance in <see cref="Godot.NavigationServer2D"/> and <see cref="Godot.NavigationServer3D"/>.</para>
        /// </summary>
        NavigationAgentCount = 26,
        /// <summary>
        /// <para>Number of active navigation links in <see cref="Godot.NavigationServer2D"/> and <see cref="Godot.NavigationServer3D"/>.</para>
        /// </summary>
        NavigationLinkCount = 27,
        /// <summary>
        /// <para>Number of navigation mesh polygons in <see cref="Godot.NavigationServer2D"/> and <see cref="Godot.NavigationServer3D"/>.</para>
        /// </summary>
        NavigationPolygonCount = 28,
        /// <summary>
        /// <para>Number of navigation mesh polygon edges in <see cref="Godot.NavigationServer2D"/> and <see cref="Godot.NavigationServer3D"/>.</para>
        /// </summary>
        NavigationEdgeCount = 29,
        /// <summary>
        /// <para>Number of navigation mesh polygon edges that were merged due to edge key overlap in <see cref="Godot.NavigationServer2D"/> and <see cref="Godot.NavigationServer3D"/>.</para>
        /// </summary>
        NavigationEdgeMergeCount = 30,
        /// <summary>
        /// <para>Number of polygon edges that are considered connected by edge proximity <see cref="Godot.NavigationServer2D"/> and <see cref="Godot.NavigationServer3D"/>.</para>
        /// </summary>
        NavigationEdgeConnectionCount = 31,
        /// <summary>
        /// <para>Number of navigation mesh polygon edges that could not be merged in <see cref="Godot.NavigationServer2D"/> and <see cref="Godot.NavigationServer3D"/>. The edges still may be connected by edge proximity or with links.</para>
        /// </summary>
        NavigationEdgeFreeCount = 32,
        /// <summary>
        /// <para>Number of active navigation obstacles in the <see cref="Godot.NavigationServer2D"/> and <see cref="Godot.NavigationServer3D"/>.</para>
        /// </summary>
        NavigationObstacleCount = 33,
        /// <summary>
        /// <para>Number of pipeline compilations that were triggered by the 2D canvas renderer.</para>
        /// </summary>
        PipelineCompilationsCanvas = 34,
        /// <summary>
        /// <para>Number of pipeline compilations that were triggered by loading meshes. These compilations will show up as longer loading times the first time a user runs the game and the pipeline is required.</para>
        /// </summary>
        PipelineCompilationsMesh = 35,
        /// <summary>
        /// <para>Number of pipeline compilations that were triggered by building the surface cache before rendering the scene. These compilations will show up as a stutter when loading a scene the first time a user runs the game and the pipeline is required.</para>
        /// </summary>
        PipelineCompilationsSurface = 36,
        /// <summary>
        /// <para>Number of pipeline compilations that were triggered while drawing the scene. These compilations will show up as stutters during gameplay the first time a user runs the game and the pipeline is required.</para>
        /// </summary>
        PipelineCompilationsDraw = 37,
        /// <summary>
        /// <para>Number of pipeline compilations that were triggered to optimize the current scene. These compilations are done in the background and should not cause any stutters whatsoever.</para>
        /// </summary>
        PipelineCompilationsSpecialization = 38,
        /// <summary>
        /// <para>Number of active navigation maps in the <see cref="Godot.NavigationServer2D"/>. This also includes the empty default navigation maps created by <see cref="Godot.World2D"/> instances.</para>
        /// </summary>
        Navigation2DActiveMaps = 39,
        /// <summary>
        /// <para>Number of active navigation regions in the <see cref="Godot.NavigationServer2D"/>.</para>
        /// </summary>
        Navigation2DRegionCount = 40,
        /// <summary>
        /// <para>Number of active navigation agents processing avoidance in the <see cref="Godot.NavigationServer2D"/>.</para>
        /// </summary>
        Navigation2DAgentCount = 41,
        /// <summary>
        /// <para>Number of active navigation links in the <see cref="Godot.NavigationServer2D"/>.</para>
        /// </summary>
        Navigation2DLinkCount = 42,
        /// <summary>
        /// <para>Number of navigation mesh polygons in the <see cref="Godot.NavigationServer2D"/>.</para>
        /// </summary>
        Navigation2DPolygonCount = 43,
        /// <summary>
        /// <para>Number of navigation mesh polygon edges in the <see cref="Godot.NavigationServer2D"/>.</para>
        /// </summary>
        Navigation2DEdgeCount = 44,
        /// <summary>
        /// <para>Number of navigation mesh polygon edges that were merged due to edge key overlap in the <see cref="Godot.NavigationServer2D"/>.</para>
        /// </summary>
        Navigation2DEdgeMergeCount = 45,
        /// <summary>
        /// <para>Number of polygon edges that are considered connected by edge proximity <see cref="Godot.NavigationServer2D"/>.</para>
        /// </summary>
        Navigation2DEdgeConnectionCount = 46,
        /// <summary>
        /// <para>Number of navigation mesh polygon edges that could not be merged in the <see cref="Godot.NavigationServer2D"/>. The edges still may be connected by edge proximity or with links.</para>
        /// </summary>
        Navigation2DEdgeFreeCount = 47,
        /// <summary>
        /// <para>Number of active navigation obstacles in the <see cref="Godot.NavigationServer2D"/>.</para>
        /// </summary>
        Navigation2DObstacleCount = 48,
        /// <summary>
        /// <para>Number of active navigation maps in the <see cref="Godot.NavigationServer3D"/>. This also includes the empty default navigation maps created by <see cref="Godot.World3D"/> instances.</para>
        /// </summary>
        Navigation3DActiveMaps = 49,
        /// <summary>
        /// <para>Number of active navigation regions in the <see cref="Godot.NavigationServer3D"/>.</para>
        /// </summary>
        Navigation3DRegionCount = 50,
        /// <summary>
        /// <para>Number of active navigation agents processing avoidance in the <see cref="Godot.NavigationServer3D"/>.</para>
        /// </summary>
        Navigation3DAgentCount = 51,
        /// <summary>
        /// <para>Number of active navigation links in the <see cref="Godot.NavigationServer3D"/>.</para>
        /// </summary>
        Navigation3DLinkCount = 52,
        /// <summary>
        /// <para>Number of navigation mesh polygons in the <see cref="Godot.NavigationServer3D"/>.</para>
        /// </summary>
        Navigation3DPolygonCount = 53,
        /// <summary>
        /// <para>Number of navigation mesh polygon edges in the <see cref="Godot.NavigationServer3D"/>.</para>
        /// </summary>
        Navigation3DEdgeCount = 54,
        /// <summary>
        /// <para>Number of navigation mesh polygon edges that were merged due to edge key overlap in the <see cref="Godot.NavigationServer3D"/>.</para>
        /// </summary>
        Navigation3DEdgeMergeCount = 55,
        /// <summary>
        /// <para>Number of polygon edges that are considered connected by edge proximity <see cref="Godot.NavigationServer3D"/>.</para>
        /// </summary>
        Navigation3DEdgeConnectionCount = 56,
        /// <summary>
        /// <para>Number of navigation mesh polygon edges that could not be merged in the <see cref="Godot.NavigationServer3D"/>. The edges still may be connected by edge proximity or with links.</para>
        /// </summary>
        Navigation3DEdgeFreeCount = 57,
        /// <summary>
        /// <para>Number of active navigation obstacles in the <see cref="Godot.NavigationServer3D"/>.</para>
        /// </summary>
        Navigation3DObstacleCount = 58,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.Performance.Monitor"/> enum.</para>
        /// </summary>
        MonitorMax = 59
    }

    public enum MonitorType : long
    {
        /// <summary>
        /// <para>Monitor output is formatted as an integer value.</para>
        /// </summary>
        Quantity = 0,
        /// <summary>
        /// <para>Monitor output is formatted as computer memory. Submitted values should represent a number of bytes.</para>
        /// </summary>
        Memory = 1,
        /// <summary>
        /// <para>Monitor output is formatted as time in milliseconds. Submitted values should represent a time in seconds (not milliseconds).</para>
        /// </summary>
        Time = 2,
        /// <summary>
        /// <para>Monitor output is formatted as a percentage. Submitted values should represent a fractional value rather than the percentage directly, e.g. <c>0.5</c> for <c>50.00%</c>.</para>
        /// </summary>
        Percentage = 3
    }

    private static readonly StringName NativeName = "Performance";

    private static PerformanceInstance singleton;

    public static PerformanceInstance Singleton =>
        singleton ??= (PerformanceInstance)InteropUtils.EngineGetSingleton("Performance");

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMonitor, 1943275655ul);

    /// <summary>
    /// <para>Returns the value of one of the available built-in monitors. You should provide one of the <see cref="Godot.Performance.Monitor"/> constants as the argument, like this:</para>
    /// <para><code>
    /// GD.Print(Performance.GetMonitor(Performance.Monitor.TimeFps)); // Prints the FPS to the console.
    /// </code></para>
    /// <para>See <see cref="Godot.Performance.GetCustomMonitor(StringName)"/> to query custom performance monitors' values.</para>
    /// </summary>
    public static double GetMonitor(Performance.Monitor monitor)
    {
        return NativeCalls.godot_icall_1_460(MethodBind0, GodotObject.GetPtr(Singleton), (int)monitor);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AddCustomMonitor, 3655788610ul);

    /// <summary>
    /// <para>Adds a custom monitor with the name <paramref name="id"/>. You can specify the category of the monitor using slash delimiters in <paramref name="id"/> (for example: <c>"Game/NumberOfNPCs"</c>). If there is more than one slash delimiter, then the default category is used. The default category is <c>"Custom"</c>. Prints an error if given <paramref name="id"/> is already present.</para>
    /// <para><code>
    /// public override void _Ready()
    /// {
    /// 	var monitorValue = new Callable(this, MethodName.GetMonitorValue);
    /// 
    /// 	// Adds monitor with name "MyName" to category "MyCategory".
    /// 	Performance.AddCustomMonitor("MyCategory/MyMonitor", monitorValue);
    /// 	// Adds monitor with name "MyName" to category "Custom".
    /// 	// Note: "MyCategory/MyMonitor" and "MyMonitor" have same name but different ids so the code is valid.
    /// 	Performance.AddCustomMonitor("MyMonitor", monitorValue);
    /// 
    /// 	// Adds monitor with name "MyName" to category "Custom".
    /// 	// Note: "MyMonitor" and "Custom/MyMonitor" have same name and same category but different ids so the code is valid.
    /// 	Performance.AddCustomMonitor("Custom/MyMonitor", monitorValue);
    /// 
    /// 	// Adds monitor with name "MyCategoryOne/MyCategoryTwo/MyMonitor" to category "Custom".
    /// 	Performance.AddCustomMonitor("MyCategoryOne/MyCategoryTwo/MyMonitor", monitorValue);
    /// }
    /// 
    /// public int GetMonitorValue()
    /// {
    /// 	return GD.Randi() % 25;
    /// }
    /// </code></para>
    /// <para>The debugger calls the callable to get the value of custom monitor. The callable must return a zero or positive integer or floating-point number.</para>
    /// <para>Callables are called with arguments supplied in argument array.</para>
    /// </summary>
    public static void AddCustomMonitor(StringName id, Callable callable, Godot.Collections.Array arguments = null, Performance.MonitorType type = (Performance.MonitorType)(0))
    {
        NativeCalls.godot_icall_4_975(MethodBind1, GodotObject.GetPtr(Singleton), (godot_string_name)(id?.NativeValue ?? default), callable, (godot_array)(arguments ?? new()).NativeValue, (int)type);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveCustomMonitor, 3304788590ul);

    /// <summary>
    /// <para>Removes the custom monitor with given <paramref name="id"/>. Prints an error if the given <paramref name="id"/> is already absent.</para>
    /// </summary>
    public static void RemoveCustomMonitor(StringName id)
    {
        NativeCalls.godot_icall_1_64(MethodBind2, GodotObject.GetPtr(Singleton), (godot_string_name)(id?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.HasCustomMonitor, 2041966384ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if custom monitor with the given <paramref name="id"/> is present, <see langword="false"/> otherwise.</para>
    /// </summary>
    public static bool HasCustomMonitor(StringName id)
    {
        return NativeCalls.godot_icall_1_105(MethodBind3, GodotObject.GetPtr(Singleton), (godot_string_name)(id?.NativeValue ?? default)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCustomMonitor, 2138907829ul);

    /// <summary>
    /// <para>Returns the value of custom monitor with given <paramref name="id"/>. The callable is called to get the value of custom monitor. See also <see cref="Godot.Performance.HasCustomMonitor(StringName)"/>. Prints an error if the given <paramref name="id"/> is absent.</para>
    /// </summary>
    public static Variant GetCustomMonitor(StringName id)
    {
        return NativeCalls.godot_icall_1_143(MethodBind4, GodotObject.GetPtr(Singleton), (godot_string_name)(id?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMonitorModificationTime, 2455072627ul);

    /// <summary>
    /// <para>Returns the last tick in which custom monitor was added/removed (in microseconds since the engine started). This is set to <see cref="Godot.Time.GetTicksUsec()"/> when the monitor is updated.</para>
    /// </summary>
    public static ulong GetMonitorModificationTime()
    {
        return NativeCalls.godot_icall_0_137(MethodBind5, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCustomMonitorNames, 2915620761ul);

    /// <summary>
    /// <para>Returns the names of active custom monitors in an <see cref="Godot.Collections.Array"/>.</para>
    /// </summary>
    public static Godot.Collections.Array<StringName> GetCustomMonitorNames()
    {
        return new Godot.Collections.Array<StringName>(NativeCalls.godot_icall_0_120(MethodBind6, GodotObject.GetPtr(Singleton)));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCustomMonitorTypes, 969006518ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.Performance.MonitorType"/> values of active custom monitors in an <see cref="Godot.Collections.Array"/>.</para>
    /// </summary>
    public static int[] GetCustomMonitorTypes()
    {
        return NativeCalls.godot_icall_0_151(MethodBind7, GodotObject.GetPtr(Singleton));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = GodotObject.ClassDB_get_method_with_compatibility(NativeName, MethodName.AddCustomMonitor, 4099036814ul);

    /// <summary>
    /// <para>Adds a custom monitor with the name <paramref name="id"/>. You can specify the category of the monitor using slash delimiters in <paramref name="id"/> (for example: <c>"Game/NumberOfNPCs"</c>). If there is more than one slash delimiter, then the default category is used. The default category is <c>"Custom"</c>. Prints an error if given <paramref name="id"/> is already present.</para>
    /// <para><code>
    /// public override void _Ready()
    /// {
    /// 	var monitorValue = new Callable(this, MethodName.GetMonitorValue);
    /// 
    /// 	// Adds monitor with name "MyName" to category "MyCategory".
    /// 	Performance.AddCustomMonitor("MyCategory/MyMonitor", monitorValue);
    /// 	// Adds monitor with name "MyName" to category "Custom".
    /// 	// Note: "MyCategory/MyMonitor" and "MyMonitor" have same name but different ids so the code is valid.
    /// 	Performance.AddCustomMonitor("MyMonitor", monitorValue);
    /// 
    /// 	// Adds monitor with name "MyName" to category "Custom".
    /// 	// Note: "MyMonitor" and "Custom/MyMonitor" have same name and same category but different ids so the code is valid.
    /// 	Performance.AddCustomMonitor("Custom/MyMonitor", monitorValue);
    /// 
    /// 	// Adds monitor with name "MyCategoryOne/MyCategoryTwo/MyMonitor" to category "Custom".
    /// 	Performance.AddCustomMonitor("MyCategoryOne/MyCategoryTwo/MyMonitor", monitorValue);
    /// }
    /// 
    /// public int GetMonitorValue()
    /// {
    /// 	return GD.Randi() % 25;
    /// }
    /// </code></para>
    /// <para>The debugger calls the callable to get the value of custom monitor. The callable must return a zero or positive integer or floating-point number.</para>
    /// <para>Callables are called with arguments supplied in argument array.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static void AddCustomMonitor(StringName id, Callable callable, Godot.Collections.Array arguments)
    {
        NativeCalls.godot_icall_3_976(MethodBind8, GodotObject.GetPtr(Singleton), (godot_string_name)(id?.NativeValue ?? default), callable, (godot_array)(arguments ?? new()).NativeValue);
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
        /// Cached name for the 'get_monitor' method.
        /// </summary>
        public static readonly StringName GetMonitor = "get_monitor";
        /// <summary>
        /// Cached name for the 'add_custom_monitor' method.
        /// </summary>
        public static readonly StringName AddCustomMonitor = "add_custom_monitor";
        /// <summary>
        /// Cached name for the 'remove_custom_monitor' method.
        /// </summary>
        public static readonly StringName RemoveCustomMonitor = "remove_custom_monitor";
        /// <summary>
        /// Cached name for the 'has_custom_monitor' method.
        /// </summary>
        public static readonly StringName HasCustomMonitor = "has_custom_monitor";
        /// <summary>
        /// Cached name for the 'get_custom_monitor' method.
        /// </summary>
        public static readonly StringName GetCustomMonitor = "get_custom_monitor";
        /// <summary>
        /// Cached name for the 'get_monitor_modification_time' method.
        /// </summary>
        public static readonly StringName GetMonitorModificationTime = "get_monitor_modification_time";
        /// <summary>
        /// Cached name for the 'get_custom_monitor_names' method.
        /// </summary>
        public static readonly StringName GetCustomMonitorNames = "get_custom_monitor_names";
        /// <summary>
        /// Cached name for the 'get_custom_monitor_types' method.
        /// </summary>
        public static readonly StringName GetCustomMonitorTypes = "get_custom_monitor_types";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public class SignalName
    {
    }
}
