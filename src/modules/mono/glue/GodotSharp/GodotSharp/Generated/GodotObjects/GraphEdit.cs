namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para><see cref="Godot.GraphEdit"/> provides tools for creation, manipulation, and display of various graphs. Its main purpose in the engine is to power the visual programming systems, such as visual shaders, but it is also available for use in user projects.</para>
/// <para><see cref="Godot.GraphEdit"/> by itself is only an empty container, representing an infinite grid where <see cref="Godot.GraphNode"/>s can be placed. Each <see cref="Godot.GraphNode"/> represents a node in the graph, a single unit of data in the connected scheme. <see cref="Godot.GraphEdit"/>, in turn, helps to control various interactions with nodes and between nodes. When the user attempts to connect, disconnect, or delete a <see cref="Godot.GraphNode"/>, a signal is emitted in the <see cref="Godot.GraphEdit"/>, but no action is taken by default. It is the responsibility of the programmer utilizing this control to implement the necessary logic to determine how each request should be handled.</para>
/// <para><b>Performance:</b> It is greatly advised to enable low-processor usage mode (see <see cref="Godot.OS.LowProcessorUsageMode"/>) when using GraphEdits.</para>
/// <para><b>Note:</b> Keep in mind that <see cref="Godot.Node.GetChildren(bool)"/> will also return the connection layer node named <c>_connection_layer</c> due to technical limitations. This behavior may change in future releases.</para>
/// </summary>
public partial class GraphEdit : Control
{
    public enum PanningSchemeEnum : long
    {
        /// <summary>
        /// <para>Mouse Wheel will zoom, Ctrl + Mouse Wheel will move the view.</para>
        /// </summary>
        Zooms = 0,
        /// <summary>
        /// <para>Mouse Wheel will move the view, Ctrl + Mouse Wheel will zoom.</para>
        /// </summary>
        Pans = 1
    }

    public enum GridPatternEnum : long
    {
        /// <summary>
        /// <para>Draw the grid using solid lines.</para>
        /// </summary>
        Lines = 0,
        /// <summary>
        /// <para>Draw the grid using dots.</para>
        /// </summary>
        Dots = 1
    }

    /// <summary>
    /// <para>The scroll offset.</para>
    /// </summary>
    public Vector2 ScrollOffset
    {
        get
        {
            return GetScrollOffset();
        }
        set
        {
            SetScrollOffset(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the grid is visible.</para>
    /// </summary>
    public bool ShowGrid
    {
        get
        {
            return IsShowingGrid();
        }
        set
        {
            SetShowGrid(value);
        }
    }

    /// <summary>
    /// <para>The pattern used for drawing the grid.</para>
    /// </summary>
    public GraphEdit.GridPatternEnum GridPattern
    {
        get
        {
            return GetGridPattern();
        }
        set
        {
            SetGridPattern(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, enables snapping.</para>
    /// </summary>
    public bool SnappingEnabled
    {
        get
        {
            return IsSnappingEnabled();
        }
        set
        {
            SetSnappingEnabled(value);
        }
    }

    /// <summary>
    /// <para>The snapping distance in pixels, also determines the grid line distance.</para>
    /// </summary>
    public int SnappingDistance
    {
        get
        {
            return GetSnappingDistance();
        }
        set
        {
            SetSnappingDistance(value);
        }
    }

    /// <summary>
    /// <para>Defines the control scheme for panning with mouse wheel.</para>
    /// </summary>
    public GraphEdit.PanningSchemeEnum PanningScheme
    {
        get
        {
            return GetPanningScheme();
        }
        set
        {
            SetPanningScheme(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, enables disconnection of existing connections in the GraphEdit by dragging the right end.</para>
    /// </summary>
    public bool RightDisconnects
    {
        get
        {
            return IsRightDisconnectsEnabled();
        }
        set
        {
            SetRightDisconnects(value);
        }
    }

    /// <summary>
    /// <para><see cref="Godot.Collections.Dictionary"/> of human-readable port type names.</para>
    /// </summary>
    public Godot.Collections.Dictionary TypeNames
    {
        get
        {
            return GetTypeNames();
        }
        set
        {
            SetTypeNames(value);
        }
    }

    /// <summary>
    /// <para>The curvature of the lines between the nodes. 0 results in straight lines.</para>
    /// </summary>
    public float ConnectionLinesCurvature
    {
        get
        {
            return GetConnectionLinesCurvature();
        }
        set
        {
            SetConnectionLinesCurvature(value);
        }
    }

    /// <summary>
    /// <para>The thickness of the lines between the nodes.</para>
    /// </summary>
    public float ConnectionLinesThickness
    {
        get
        {
            return GetConnectionLinesThickness();
        }
        set
        {
            SetConnectionLinesThickness(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the lines between nodes will use antialiasing.</para>
    /// </summary>
    public bool ConnectionLinesAntialiased
    {
        get
        {
            return IsConnectionLinesAntialiased();
        }
        set
        {
            SetConnectionLinesAntialiased(value);
        }
    }

    /// <summary>
    /// <para>The connections between <see cref="Godot.GraphNode"/>s.</para>
    /// <para>A connection is represented as a <see cref="Godot.Collections.Dictionary"/> in the form of:</para>
    /// <para><code>
    /// {
    /// 	from_node: StringName,
    /// 	from_port: int,
    /// 	to_node: StringName,
    /// 	to_port: int,
    /// 	keep_alive: bool
    /// }
    /// </code></para>
    /// <para>Connections with <c>keep_alive</c> set to <see langword="false"/> may be deleted automatically if invalid during a redraw.</para>
    /// </summary>
    public Godot.Collections.Array<Godot.Collections.Dictionary> Connections
    {
        get
        {
            return GetConnectionList();
        }
        set
        {
            SetConnections(value);
        }
    }

    /// <summary>
    /// <para>The current zoom value.</para>
    /// </summary>
    public float Zoom
    {
        get
        {
            return GetZoom();
        }
        set
        {
            SetZoom(value);
        }
    }

    /// <summary>
    /// <para>The lower zoom limit.</para>
    /// </summary>
    public float ZoomMin
    {
        get
        {
            return GetZoomMin();
        }
        set
        {
            SetZoomMin(value);
        }
    }

    /// <summary>
    /// <para>The upper zoom limit.</para>
    /// </summary>
    public float ZoomMax
    {
        get
        {
            return GetZoomMax();
        }
        set
        {
            SetZoomMax(value);
        }
    }

    /// <summary>
    /// <para>The step of each zoom level.</para>
    /// </summary>
    public float ZoomStep
    {
        get
        {
            return GetZoomStep();
        }
        set
        {
            SetZoomStep(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the minimap is visible.</para>
    /// </summary>
    public bool MinimapEnabled
    {
        get
        {
            return IsMinimapEnabled();
        }
        set
        {
            SetMinimapEnabled(value);
        }
    }

    /// <summary>
    /// <para>The size of the minimap rectangle. The map itself is based on the size of the grid area and is scaled to fit this rectangle.</para>
    /// </summary>
    public Vector2 MinimapSize
    {
        get
        {
            return GetMinimapSize();
        }
        set
        {
            SetMinimapSize(value);
        }
    }

    /// <summary>
    /// <para>The opacity of the minimap rectangle.</para>
    /// </summary>
    public float MinimapOpacity
    {
        get
        {
            return GetMinimapOpacity();
        }
        set
        {
            SetMinimapOpacity(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the menu toolbar is visible.</para>
    /// </summary>
    public bool ShowMenu
    {
        get
        {
            return IsShowingMenu();
        }
        set
        {
            SetShowMenu(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the label with the current zoom level is visible. The zoom level is displayed in percents.</para>
    /// </summary>
    public bool ShowZoomLabel
    {
        get
        {
            return IsShowingZoomLabel();
        }
        set
        {
            SetShowZoomLabel(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, buttons that allow to change and reset the zoom level are visible.</para>
    /// </summary>
    public bool ShowZoomButtons
    {
        get
        {
            return IsShowingZoomButtons();
        }
        set
        {
            SetShowZoomButtons(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, buttons that allow to configure grid and snapping options are visible.</para>
    /// </summary>
    public bool ShowGridButtons
    {
        get
        {
            return IsShowingGridButtons();
        }
        set
        {
            SetShowGridButtons(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the button to toggle the minimap is visible.</para>
    /// </summary>
    public bool ShowMinimapButton
    {
        get
        {
            return IsShowingMinimapButton();
        }
        set
        {
            SetShowMinimapButton(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the button to automatically arrange graph nodes is visible.</para>
    /// </summary>
    public bool ShowArrangeButton
    {
        get
        {
            return IsShowingArrangeButton();
        }
        set
        {
            SetShowArrangeButton(value);
        }
    }

    private static readonly System.Type CachedType = typeof(GraphEdit);

    private static readonly StringName NativeName = "GraphEdit";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public GraphEdit() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal GraphEdit(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal GraphEdit(bool memoryOwn) : base(memoryOwn) { }

    /// <summary>
    /// <para>Virtual method which can be overridden to customize how connections are drawn.</para>
    /// </summary>
    public virtual unsafe Vector2[] _GetConnectionLine(Vector2 fromPosition, Vector2 toPosition)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns whether the <paramref name="mousePosition"/> is in the input hot zone.</para>
    /// <para>By default, a hot zone is a <see cref="Godot.Rect2"/> positioned such that its center is at <paramref name="inNode"/>.<see cref="Godot.GraphNode.GetInputPortPosition(int)"/>(<paramref name="inPort"/>) (For output's case, call <see cref="Godot.GraphNode.GetOutputPortPosition(int)"/> instead). The hot zone's width is twice the Theme Property <c>port_grab_distance_horizontal</c>, and its height is twice the <c>port_grab_distance_vertical</c>.</para>
    /// <para>Below is a sample code to help get started:</para>
    /// <para><code>
    /// func _is_in_input_hotzone(in_node, in_port, mouse_position):
    /// 	var port_size = Vector2(get_theme_constant("port_grab_distance_horizontal"), get_theme_constant("port_grab_distance_vertical"))
    /// 	var port_pos = in_node.get_position() + in_node.get_input_port_position(in_port) - port_size / 2
    /// 	var rect = Rect2(port_pos, port_size)
    /// 
    /// 	return rect.has_point(mouse_position)
    /// </code></para>
    /// </summary>
    public virtual unsafe bool _IsInInputHotzone(GodotObject inNode, int inPort, Vector2 mousePosition)
    {
        return default;
    }

    /// <summary>
    /// <para>Returns whether the <paramref name="mousePosition"/> is in the output hot zone. For more information on hot zones, see <see cref="Godot.GraphEdit._IsInInputHotzone(GodotObject, int, Vector2)"/>.</para>
    /// <para>Below is a sample code to help get started:</para>
    /// <para><code>
    /// func _is_in_output_hotzone(in_node, in_port, mouse_position):
    /// 	var port_size = Vector2(get_theme_constant("port_grab_distance_horizontal"), get_theme_constant("port_grab_distance_vertical"))
    /// 	var port_pos = in_node.get_position() + in_node.get_output_port_position(in_port) - port_size / 2
    /// 	var rect = Rect2(port_pos, port_size)
    /// 
    /// 	return rect.has_point(mouse_position)
    /// </code></para>
    /// </summary>
    public virtual unsafe bool _IsInOutputHotzone(GodotObject inNode, int inPort, Vector2 mousePosition)
    {
        return default;
    }

    /// <summary>
    /// <para>This virtual method can be used to insert additional error detection while the user is dragging a connection over a valid port.</para>
    /// <para>Return <see langword="true"/> if the connection is indeed valid or return <see langword="false"/> if the connection is impossible. If the connection is impossible, no snapping to the port and thus no connection request to that port will happen.</para>
    /// <para>In this example a connection to same node is suppressed:</para>
    /// <para><code>
    /// public override bool _IsNodeHoverValid(StringName fromNode, int fromPort, StringName toNode, int toPort)
    /// {
    /// 	return fromNode != toNode;
    /// }
    /// </code></para>
    /// </summary>
    public virtual bool _IsNodeHoverValid(StringName fromNode, int fromPort, StringName toNode, int toPort)
    {
        return default;
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ConnectNode, 1376144231ul);

    /// <summary>
    /// <para>Create a connection between the <paramref name="fromPort"/> of the <paramref name="fromNode"/> <see cref="Godot.GraphNode"/> and the <paramref name="toPort"/> of the <paramref name="toNode"/> <see cref="Godot.GraphNode"/>. If the connection already exists, no connection is created.</para>
    /// <para>Connections with <paramref name="keepAlive"/> set to <see langword="false"/> may be deleted automatically if invalid during a redraw.</para>
    /// </summary>
    public Error ConnectNode(StringName fromNode, int fromPort, StringName toNode, int toPort, bool keepAlive = false)
    {
        return (Error)NativeCalls.godot_icall_5_690(MethodBind0, GodotObject.GetPtr(this), (godot_string_name)(fromNode?.NativeValue ?? default), fromPort, (godot_string_name)(toNode?.NativeValue ?? default), toPort, keepAlive.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsNodeConnected, 4216241294ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the <paramref name="fromPort"/> of the <paramref name="fromNode"/> <see cref="Godot.GraphNode"/> is connected to the <paramref name="toPort"/> of the <paramref name="toNode"/> <see cref="Godot.GraphNode"/>.</para>
    /// </summary>
    public bool IsNodeConnected(StringName fromNode, int fromPort, StringName toNode, int toPort)
    {
        return NativeCalls.godot_icall_4_691(MethodBind1, GodotObject.GetPtr(this), (godot_string_name)(fromNode?.NativeValue ?? default), fromPort, (godot_string_name)(toNode?.NativeValue ?? default), toPort).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DisconnectNode, 1933654315ul);

    /// <summary>
    /// <para>Removes the connection between the <paramref name="fromPort"/> of the <paramref name="fromNode"/> <see cref="Godot.GraphNode"/> and the <paramref name="toPort"/> of the <paramref name="toNode"/> <see cref="Godot.GraphNode"/>. If the connection does not exist, no connection is removed.</para>
    /// </summary>
    public void DisconnectNode(StringName fromNode, int fromPort, StringName toNode, int toPort)
    {
        NativeCalls.godot_icall_4_692(MethodBind2, GodotObject.GetPtr(this), (godot_string_name)(fromNode?.NativeValue ?? default), fromPort, (godot_string_name)(toNode?.NativeValue ?? default), toPort);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetConnectionActivity, 1141899943ul);

    /// <summary>
    /// <para>Sets the coloration of the connection between <paramref name="fromNode"/>'s <paramref name="fromPort"/> and <paramref name="toNode"/>'s <paramref name="toPort"/> with the color provided in the <c>activity</c> theme property. The color is linearly interpolated between the connection color and the activity color using <paramref name="amount"/> as weight.</para>
    /// </summary>
    public void SetConnectionActivity(StringName fromNode, int fromPort, StringName toNode, int toPort, float amount)
    {
        NativeCalls.godot_icall_5_693(MethodBind3, GodotObject.GetPtr(this), (godot_string_name)(fromNode?.NativeValue ?? default), fromPort, (godot_string_name)(toNode?.NativeValue ?? default), toPort, amount);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetConnections, 381264803ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetConnections(Godot.Collections.Array<Godot.Collections.Dictionary> connections)
    {
        NativeCalls.godot_icall_1_138(MethodBind4, GodotObject.GetPtr(this), (godot_array)(connections ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetConnectionList, 3995934104ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Godot.Collections.Array<Godot.Collections.Dictionary> GetConnectionList()
    {
        return new Godot.Collections.Array<Godot.Collections.Dictionary>(NativeCalls.godot_icall_0_120(MethodBind5, GodotObject.GetPtr(this)));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetConnectionCount, 861718734ul);

    /// <summary>
    /// <para>Returns the number of connections from <paramref name="fromPort"/> of <paramref name="fromNode"/>.</para>
    /// </summary>
    public int GetConnectionCount(StringName fromNode, int fromPort)
    {
        return NativeCalls.godot_icall_2_694(MethodBind6, GodotObject.GetPtr(this), (godot_string_name)(fromNode?.NativeValue ?? default), fromPort);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetClosestConnectionAtPoint, 453879819ul);

    /// <summary>
    /// <para>Returns the closest connection to the given point in screen space. If no connection is found within <paramref name="maxDistance"/> pixels, an empty <see cref="Godot.Collections.Dictionary"/> is returned.</para>
    /// <para>A connection is represented as a <see cref="Godot.Collections.Dictionary"/> in the form of:</para>
    /// <para><code>
    /// {
    /// 	from_node: StringName,
    /// 	from_port: int,
    /// 	to_node: StringName,
    /// 	to_port: int,
    /// 	keep_alive: bool
    /// }
    /// </code></para>
    /// <para>For example, getting a connection at a given mouse position can be achieved like this:</para>
    /// <para></para>
    /// </summary>
    public unsafe Godot.Collections.Dictionary GetClosestConnectionAtPoint(Vector2 point, float maxDistance = 4.0f)
    {
        return NativeCalls.godot_icall_2_695(MethodBind7, GodotObject.GetPtr(this), &point, maxDistance);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetConnectionListFromNode, 3147814860ul);

    /// <summary>
    /// <para>Returns an <see cref="Godot.Collections.Array"/> containing a list of all connections for <paramref name="node"/>.</para>
    /// <para>A connection is represented as a <see cref="Godot.Collections.Dictionary"/> in the form of:</para>
    /// <para><code>
    /// {
    /// 	from_node: StringName,
    /// 	from_port: int,
    /// 	to_node: StringName,
    /// 	to_port: int,
    /// 	keep_alive: bool
    /// }
    /// </code></para>
    /// <para><b>Example:</b> Get all connections on a specific port:</para>
    /// <para><code>
    /// func get_connection_list_from_port(node, port):
    /// 	var connections = get_connection_list_from_node(node)
    /// 	var result = []
    /// 	for connection in connections:
    /// 		var dict = {}
    /// 		if connection["from_node"] == node and connection["from_port"] == port:
    /// 			dict["node"] = connection["to_node"]
    /// 			dict["port"] = connection["to_port"]
    /// 			dict["type"] = "left"
    /// 			result.push_back(dict)
    /// 		elif connection["to_node"] == node and connection["to_port"] == port:
    /// 			dict["node"] = connection["from_node"]
    /// 			dict["port"] = connection["from_port"]
    /// 			dict["type"] = "right"
    /// 			result.push_back(dict)
    /// 	return result
    /// </code></para>
    /// </summary>
    public Godot.Collections.Array<Godot.Collections.Dictionary> GetConnectionListFromNode(StringName node)
    {
        return new Godot.Collections.Array<Godot.Collections.Dictionary>(NativeCalls.godot_icall_1_696(MethodBind8, GodotObject.GetPtr(this), (godot_string_name)(node?.NativeValue ?? default)));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetConnectionsIntersectingWithRect, 2709748719ul);

    /// <summary>
    /// <para>Returns an <see cref="Godot.Collections.Array"/> containing the list of connections that intersect with the given <see cref="Godot.Rect2"/>.</para>
    /// <para>A connection is represented as a <see cref="Godot.Collections.Dictionary"/> in the form of:</para>
    /// <para><code>
    /// {
    /// 	from_node: StringName,
    /// 	from_port: int,
    /// 	to_node: StringName,
    /// 	to_port: int,
    /// 	keep_alive: bool
    /// }
    /// </code></para>
    /// </summary>
    public unsafe Godot.Collections.Array<Godot.Collections.Dictionary> GetConnectionsIntersectingWithRect(Rect2 rect)
    {
        return new Godot.Collections.Array<Godot.Collections.Dictionary>(NativeCalls.godot_icall_1_697(MethodBind9, GodotObject.GetPtr(this), &rect));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ClearConnections, 3218959716ul);

    /// <summary>
    /// <para>Removes all connections between nodes.</para>
    /// </summary>
    public void ClearConnections()
    {
        NativeCalls.godot_icall_0_3(MethodBind10, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ForceConnectionDragEnd, 3218959716ul);

    /// <summary>
    /// <para>Ends the creation of the current connection. In other words, if you are dragging a connection you can use this method to abort the process and remove the line that followed your cursor.</para>
    /// <para>This is best used together with <see cref="Godot.GraphEdit.ConnectionDragStarted"/> and <see cref="Godot.GraphEdit.ConnectionDragEnded"/> to add custom behavior like node addition through shortcuts.</para>
    /// <para><b>Note:</b> This method suppresses any other connection request signals apart from <see cref="Godot.GraphEdit.ConnectionDragEnded"/>.</para>
    /// </summary>
    public void ForceConnectionDragEnd()
    {
        NativeCalls.godot_icall_0_3(MethodBind11, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetScrollOffset, 3341600327ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2 GetScrollOffset()
    {
        return NativeCalls.godot_icall_0_37(MethodBind12, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetScrollOffset, 743155724ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetScrollOffset(Vector2 offset)
    {
        NativeCalls.godot_icall_1_36(MethodBind13, GodotObject.GetPtr(this), &offset);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddValidRightDisconnectType, 1286410249ul);

    /// <summary>
    /// <para>Allows to disconnect nodes when dragging from the right port of the <see cref="Godot.GraphNode"/>'s slot if it has the specified type. See also <see cref="Godot.GraphEdit.RemoveValidRightDisconnectType(int)"/>.</para>
    /// </summary>
    public void AddValidRightDisconnectType(int type)
    {
        NativeCalls.godot_icall_1_38(MethodBind14, GodotObject.GetPtr(this), type);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveValidRightDisconnectType, 1286410249ul);

    /// <summary>
    /// <para>Disallows to disconnect nodes when dragging from the right port of the <see cref="Godot.GraphNode"/>'s slot if it has the specified type. Use this to disable a disconnection previously allowed with <see cref="Godot.GraphEdit.AddValidRightDisconnectType(int)"/>.</para>
    /// </summary>
    public void RemoveValidRightDisconnectType(int type)
    {
        NativeCalls.godot_icall_1_38(MethodBind15, GodotObject.GetPtr(this), type);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddValidLeftDisconnectType, 1286410249ul);

    /// <summary>
    /// <para>Allows to disconnect nodes when dragging from the left port of the <see cref="Godot.GraphNode"/>'s slot if it has the specified type. See also <see cref="Godot.GraphEdit.RemoveValidLeftDisconnectType(int)"/>.</para>
    /// </summary>
    public void AddValidLeftDisconnectType(int type)
    {
        NativeCalls.godot_icall_1_38(MethodBind16, GodotObject.GetPtr(this), type);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveValidLeftDisconnectType, 1286410249ul);

    /// <summary>
    /// <para>Disallows to disconnect nodes when dragging from the left port of the <see cref="Godot.GraphNode"/>'s slot if it has the specified type. Use this to disable a disconnection previously allowed with <see cref="Godot.GraphEdit.AddValidLeftDisconnectType(int)"/>.</para>
    /// </summary>
    public void RemoveValidLeftDisconnectType(int type)
    {
        NativeCalls.godot_icall_1_38(MethodBind17, GodotObject.GetPtr(this), type);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddValidConnectionType, 3937882851ul);

    /// <summary>
    /// <para>Allows the connection between two different port types. The port type is defined individually for the left and the right port of each slot with the <see cref="Godot.GraphNode.SetSlot(int, bool, int, Color, bool, int, Color, Texture2D, Texture2D, bool)"/> method.</para>
    /// <para>See also <see cref="Godot.GraphEdit.IsValidConnectionType(int, int)"/> and <see cref="Godot.GraphEdit.RemoveValidConnectionType(int, int)"/>.</para>
    /// </summary>
    public void AddValidConnectionType(int fromType, int toType)
    {
        NativeCalls.godot_icall_2_59(MethodBind18, GodotObject.GetPtr(this), fromType, toType);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveValidConnectionType, 3937882851ul);

    /// <summary>
    /// <para>Disallows the connection between two different port types previously allowed by <see cref="Godot.GraphEdit.AddValidConnectionType(int, int)"/>. The port type is defined individually for the left and the right port of each slot with the <see cref="Godot.GraphNode.SetSlot(int, bool, int, Color, bool, int, Color, Texture2D, Texture2D, bool)"/> method.</para>
    /// <para>See also <see cref="Godot.GraphEdit.IsValidConnectionType(int, int)"/>.</para>
    /// </summary>
    public void RemoveValidConnectionType(int fromType, int toType)
    {
        NativeCalls.godot_icall_2_59(MethodBind19, GodotObject.GetPtr(this), fromType, toType);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsValidConnectionType, 2522259332ul);

    /// <summary>
    /// <para>Returns whether it's possible to make a connection between two different port types. The port type is defined individually for the left and the right port of each slot with the <see cref="Godot.GraphNode.SetSlot(int, bool, int, Color, bool, int, Color, Texture2D, Texture2D, bool)"/> method.</para>
    /// <para>See also <see cref="Godot.GraphEdit.AddValidConnectionType(int, int)"/> and <see cref="Godot.GraphEdit.RemoveValidConnectionType(int, int)"/>.</para>
    /// </summary>
    public bool IsValidConnectionType(int fromType, int toType)
    {
        return NativeCalls.godot_icall_2_40(MethodBind20, GodotObject.GetPtr(this), fromType, toType).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetConnectionLine, 3932192302ul);

    /// <summary>
    /// <para>Returns the points which would make up a connection between <paramref name="fromNode"/> and <paramref name="toNode"/>.</para>
    /// </summary>
    public unsafe Vector2[] GetConnectionLine(Vector2 fromNode, Vector2 toNode)
    {
        return NativeCalls.godot_icall_2_698(MethodBind21, GodotObject.GetPtr(this), &fromNode, &toNode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AttachGraphElementToFrame, 3740211285ul);

    /// <summary>
    /// <para>Attaches the <paramref name="element"/> <see cref="Godot.GraphElement"/> to the <paramref name="frame"/> <see cref="Godot.GraphFrame"/>.</para>
    /// </summary>
    public void AttachGraphElementToFrame(StringName element, StringName frame)
    {
        NativeCalls.godot_icall_2_118(MethodBind22, GodotObject.GetPtr(this), (godot_string_name)(element?.NativeValue ?? default), (godot_string_name)(frame?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DetachGraphElementFromFrame, 3304788590ul);

    /// <summary>
    /// <para>Detaches the <paramref name="element"/> <see cref="Godot.GraphElement"/> from the <see cref="Godot.GraphFrame"/> it is currently attached to.</para>
    /// </summary>
    public void DetachGraphElementFromFrame(StringName element)
    {
        NativeCalls.godot_icall_1_64(MethodBind23, GodotObject.GetPtr(this), (godot_string_name)(element?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetElementFrame, 988084372ul);

    /// <summary>
    /// <para>Returns the <see cref="Godot.GraphFrame"/> that contains the <see cref="Godot.GraphElement"/> with the given name.</para>
    /// </summary>
    public GraphFrame GetElementFrame(StringName element)
    {
        return (GraphFrame)NativeCalls.godot_icall_1_545(MethodBind24, GodotObject.GetPtr(this), (godot_string_name)(element?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAttachedNodesOfFrame, 689397652ul);

    /// <summary>
    /// <para>Returns an array of node names that are attached to the <see cref="Godot.GraphFrame"/> with the given name.</para>
    /// </summary>
    public Godot.Collections.Array<StringName> GetAttachedNodesOfFrame(StringName frame)
    {
        return new Godot.Collections.Array<StringName>(NativeCalls.godot_icall_1_696(MethodBind25, GodotObject.GetPtr(this), (godot_string_name)(frame?.NativeValue ?? default)));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind26 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPanningScheme, 18893313ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetPanningScheme(GraphEdit.PanningSchemeEnum scheme)
    {
        NativeCalls.godot_icall_1_38(MethodBind26, GodotObject.GetPtr(this), (int)scheme);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind27 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPanningScheme, 549924446ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public GraphEdit.PanningSchemeEnum GetPanningScheme()
    {
        return (GraphEdit.PanningSchemeEnum)NativeCalls.godot_icall_0_39(MethodBind27, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind28 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetZoom, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetZoom(float zoom)
    {
        NativeCalls.godot_icall_1_67(MethodBind28, GodotObject.GetPtr(this), zoom);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind29 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetZoom, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetZoom()
    {
        return NativeCalls.godot_icall_0_68(MethodBind29, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind30 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetZoomMin, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetZoomMin(float zoomMin)
    {
        NativeCalls.godot_icall_1_67(MethodBind30, GodotObject.GetPtr(this), zoomMin);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind31 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetZoomMin, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetZoomMin()
    {
        return NativeCalls.godot_icall_0_68(MethodBind31, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind32 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetZoomMax, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetZoomMax(float zoomMax)
    {
        NativeCalls.godot_icall_1_67(MethodBind32, GodotObject.GetPtr(this), zoomMax);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind33 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetZoomMax, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetZoomMax()
    {
        return NativeCalls.godot_icall_0_68(MethodBind33, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind34 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetZoomStep, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetZoomStep(float zoomStep)
    {
        NativeCalls.godot_icall_1_67(MethodBind34, GodotObject.GetPtr(this), zoomStep);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind35 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetZoomStep, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetZoomStep()
    {
        return NativeCalls.godot_icall_0_68(MethodBind35, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind36 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetShowGrid, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetShowGrid(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind36, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind37 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsShowingGrid, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsShowingGrid()
    {
        return NativeCalls.godot_icall_0_15(MethodBind37, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind38 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetGridPattern, 1074098205ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetGridPattern(GraphEdit.GridPatternEnum pattern)
    {
        NativeCalls.godot_icall_1_38(MethodBind38, GodotObject.GetPtr(this), (int)pattern);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind39 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetGridPattern, 1286127528ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public GraphEdit.GridPatternEnum GetGridPattern()
    {
        return (GraphEdit.GridPatternEnum)NativeCalls.godot_icall_0_39(MethodBind39, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind40 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSnappingEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSnappingEnabled(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind40, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind41 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsSnappingEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsSnappingEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind41, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind42 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSnappingDistance, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSnappingDistance(int pixels)
    {
        NativeCalls.godot_icall_1_38(MethodBind42, GodotObject.GetPtr(this), pixels);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind43 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSnappingDistance, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetSnappingDistance()
    {
        return NativeCalls.godot_icall_0_39(MethodBind43, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind44 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetConnectionLinesCurvature, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetConnectionLinesCurvature(float curvature)
    {
        NativeCalls.godot_icall_1_67(MethodBind44, GodotObject.GetPtr(this), curvature);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind45 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetConnectionLinesCurvature, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetConnectionLinesCurvature()
    {
        return NativeCalls.godot_icall_0_68(MethodBind45, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind46 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetConnectionLinesThickness, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetConnectionLinesThickness(float pixels)
    {
        NativeCalls.godot_icall_1_67(MethodBind46, GodotObject.GetPtr(this), pixels);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind47 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetConnectionLinesThickness, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetConnectionLinesThickness()
    {
        return NativeCalls.godot_icall_0_68(MethodBind47, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind48 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetConnectionLinesAntialiased, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetConnectionLinesAntialiased(bool pixels)
    {
        NativeCalls.godot_icall_1_14(MethodBind48, GodotObject.GetPtr(this), pixels.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind49 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsConnectionLinesAntialiased, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsConnectionLinesAntialiased()
    {
        return NativeCalls.godot_icall_0_15(MethodBind49, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind50 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMinimapSize, 743155724ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetMinimapSize(Vector2 size)
    {
        NativeCalls.godot_icall_1_36(MethodBind50, GodotObject.GetPtr(this), &size);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind51 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMinimapSize, 3341600327ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2 GetMinimapSize()
    {
        return NativeCalls.godot_icall_0_37(MethodBind51, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind52 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMinimapOpacity, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMinimapOpacity(float opacity)
    {
        NativeCalls.godot_icall_1_67(MethodBind52, GodotObject.GetPtr(this), opacity);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind53 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMinimapOpacity, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetMinimapOpacity()
    {
        return NativeCalls.godot_icall_0_68(MethodBind53, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind54 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMinimapEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetMinimapEnabled(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind54, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind55 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsMinimapEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsMinimapEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind55, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind56 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetShowMenu, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetShowMenu(bool hidden)
    {
        NativeCalls.godot_icall_1_14(MethodBind56, GodotObject.GetPtr(this), hidden.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind57 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsShowingMenu, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsShowingMenu()
    {
        return NativeCalls.godot_icall_0_15(MethodBind57, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind58 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetShowZoomLabel, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetShowZoomLabel(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind58, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind59 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsShowingZoomLabel, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsShowingZoomLabel()
    {
        return NativeCalls.godot_icall_0_15(MethodBind59, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind60 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetShowGridButtons, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetShowGridButtons(bool hidden)
    {
        NativeCalls.godot_icall_1_14(MethodBind60, GodotObject.GetPtr(this), hidden.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind61 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsShowingGridButtons, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsShowingGridButtons()
    {
        return NativeCalls.godot_icall_0_15(MethodBind61, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind62 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetShowZoomButtons, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetShowZoomButtons(bool hidden)
    {
        NativeCalls.godot_icall_1_14(MethodBind62, GodotObject.GetPtr(this), hidden.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind63 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsShowingZoomButtons, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsShowingZoomButtons()
    {
        return NativeCalls.godot_icall_0_15(MethodBind63, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind64 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetShowMinimapButton, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetShowMinimapButton(bool hidden)
    {
        NativeCalls.godot_icall_1_14(MethodBind64, GodotObject.GetPtr(this), hidden.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind65 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsShowingMinimapButton, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsShowingMinimapButton()
    {
        return NativeCalls.godot_icall_0_15(MethodBind65, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind66 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetShowArrangeButton, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetShowArrangeButton(bool hidden)
    {
        NativeCalls.godot_icall_1_14(MethodBind66, GodotObject.GetPtr(this), hidden.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind67 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsShowingArrangeButton, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsShowingArrangeButton()
    {
        return NativeCalls.godot_icall_0_15(MethodBind67, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind68 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRightDisconnects, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetRightDisconnects(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind68, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind69 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsRightDisconnectsEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsRightDisconnectsEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind69, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind70 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTypeNames, 4155329257ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTypeNames(Godot.Collections.Dictionary typeNames)
    {
        NativeCalls.godot_icall_1_121(MethodBind70, GodotObject.GetPtr(this), (godot_dictionary)(typeNames ?? new()).NativeValue);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind71 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTypeNames, 3102165223ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Godot.Collections.Dictionary GetTypeNames()
    {
        return NativeCalls.godot_icall_0_122(MethodBind71, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind72 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetMenuHBox, 3590609951ul);

    /// <summary>
    /// <para>Gets the <see cref="Godot.HBoxContainer"/> that contains the zooming and grid snap controls in the top left of the graph. You can use this method to reposition the toolbar or to add your own custom controls to it.</para>
    /// <para><b>Warning:</b> This is a required internal node, removing and freeing it may cause a crash. If you wish to hide it or any of its children, use their <see cref="Godot.CanvasItem.Visible"/> property.</para>
    /// </summary>
    public HBoxContainer GetMenuHBox()
    {
        return (HBoxContainer)NativeCalls.godot_icall_0_53(MethodBind72, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind73 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ArrangeNodes, 3218959716ul);

    /// <summary>
    /// <para>Rearranges selected nodes in a layout with minimum crossings between connections and uniform horizontal and vertical gap between nodes.</para>
    /// </summary>
    public void ArrangeNodes()
    {
        NativeCalls.godot_icall_0_3(MethodBind73, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind74 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSelected, 1078189570ul);

    /// <summary>
    /// <para>Sets the specified <paramref name="node"/> as the one selected.</para>
    /// </summary>
    public void SetSelected(Node node)
    {
        NativeCalls.godot_icall_1_56(MethodBind74, GodotObject.GetPtr(this), GodotObject.GetPtr(node));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind75 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ConnectNode, 195065850ul);

    /// <summary>
    /// <para>Create a connection between the <paramref name="fromPort"/> of the <paramref name="fromNode"/> <see cref="Godot.GraphNode"/> and the <paramref name="toPort"/> of the <paramref name="toNode"/> <see cref="Godot.GraphNode"/>. If the connection already exists, no connection is created.</para>
    /// <para>Connections with <paramref name="keepAlive"/> set to <see langword="false"/> may be deleted automatically if invalid during a redraw.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public Error ConnectNode(StringName fromNode, int fromPort, StringName toNode, int toPort)
    {
        return (Error)NativeCalls.godot_icall_4_699(MethodBind75, GodotObject.GetPtr(this), (godot_string_name)(fromNode?.NativeValue ?? default), fromPort, (godot_string_name)(toNode?.NativeValue ?? default), toPort);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind76 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetArrangeNodesButtonHidden, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetArrangeNodesButtonHidden(bool enable)
    {
        NativeCalls.godot_icall_1_14(MethodBind76, GodotObject.GetPtr(this), enable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind77 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsArrangeNodesButtonHidden, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsArrangeNodesButtonHidden()
    {
        return NativeCalls.godot_icall_0_15(MethodBind77, GodotObject.GetPtr(this)).ToBool();
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.GraphEdit.ConnectionRequest"/> event of a <see cref="Godot.GraphEdit"/> class.
    /// </summary>
    public delegate void ConnectionRequestEventHandler(StringName fromNode, long fromPort, StringName toNode, long toPort);

    private static void ConnectionRequestTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 4);
        ((ConnectionRequestEventHandler)delegateObj)(VariantUtils.ConvertTo<StringName>(args[0]), VariantUtils.ConvertTo<long>(args[1]), VariantUtils.ConvertTo<StringName>(args[2]), VariantUtils.ConvertTo<long>(args[3]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted to the GraphEdit when the connection between the <c>fromPort</c> of the <c>fromNode</c> <see cref="Godot.GraphNode"/> and the <c>toPort</c> of the <c>toNode</c> <see cref="Godot.GraphNode"/> is attempted to be created.</para>
    /// </summary>
    public unsafe event ConnectionRequestEventHandler ConnectionRequest
    {
        add => Connect(SignalName.ConnectionRequest, Callable.CreateWithUnsafeTrampoline(value, &ConnectionRequestTrampoline));
        remove => Disconnect(SignalName.ConnectionRequest, Callable.CreateWithUnsafeTrampoline(value, &ConnectionRequestTrampoline));
    }

    protected void EmitSignalConnectionRequest(StringName fromNode, long fromPort, StringName toNode, long toPort)
    {
        EmitSignal(SignalName.ConnectionRequest, fromNode, fromPort, toNode, toPort);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.GraphEdit.DisconnectionRequest"/> event of a <see cref="Godot.GraphEdit"/> class.
    /// </summary>
    public delegate void DisconnectionRequestEventHandler(StringName fromNode, long fromPort, StringName toNode, long toPort);

    private static void DisconnectionRequestTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 4);
        ((DisconnectionRequestEventHandler)delegateObj)(VariantUtils.ConvertTo<StringName>(args[0]), VariantUtils.ConvertTo<long>(args[1]), VariantUtils.ConvertTo<StringName>(args[2]), VariantUtils.ConvertTo<long>(args[3]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted to the GraphEdit when the connection between <c>fromPort</c> of <c>fromNode</c> <see cref="Godot.GraphNode"/> and <c>toPort</c> of <c>toNode</c> <see cref="Godot.GraphNode"/> is attempted to be removed.</para>
    /// </summary>
    public unsafe event DisconnectionRequestEventHandler DisconnectionRequest
    {
        add => Connect(SignalName.DisconnectionRequest, Callable.CreateWithUnsafeTrampoline(value, &DisconnectionRequestTrampoline));
        remove => Disconnect(SignalName.DisconnectionRequest, Callable.CreateWithUnsafeTrampoline(value, &DisconnectionRequestTrampoline));
    }

    protected void EmitSignalDisconnectionRequest(StringName fromNode, long fromPort, StringName toNode, long toPort)
    {
        EmitSignal(SignalName.DisconnectionRequest, fromNode, fromPort, toNode, toPort);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.GraphEdit.ConnectionToEmpty"/> event of a <see cref="Godot.GraphEdit"/> class.
    /// </summary>
    public delegate void ConnectionToEmptyEventHandler(StringName fromNode, long fromPort, Vector2 releasePosition);

    private static void ConnectionToEmptyTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 3);
        ((ConnectionToEmptyEventHandler)delegateObj)(VariantUtils.ConvertTo<StringName>(args[0]), VariantUtils.ConvertTo<long>(args[1]), VariantUtils.ConvertTo<Vector2>(args[2]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when user drags a connection from an output port into the empty space of the graph.</para>
    /// </summary>
    public unsafe event ConnectionToEmptyEventHandler ConnectionToEmpty
    {
        add => Connect(SignalName.ConnectionToEmpty, Callable.CreateWithUnsafeTrampoline(value, &ConnectionToEmptyTrampoline));
        remove => Disconnect(SignalName.ConnectionToEmpty, Callable.CreateWithUnsafeTrampoline(value, &ConnectionToEmptyTrampoline));
    }

    protected void EmitSignalConnectionToEmpty(StringName fromNode, long fromPort, Vector2 releasePosition)
    {
        EmitSignal(SignalName.ConnectionToEmpty, fromNode, fromPort, releasePosition);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.GraphEdit.ConnectionFromEmpty"/> event of a <see cref="Godot.GraphEdit"/> class.
    /// </summary>
    public delegate void ConnectionFromEmptyEventHandler(StringName toNode, long toPort, Vector2 releasePosition);

    private static void ConnectionFromEmptyTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 3);
        ((ConnectionFromEmptyEventHandler)delegateObj)(VariantUtils.ConvertTo<StringName>(args[0]), VariantUtils.ConvertTo<long>(args[1]), VariantUtils.ConvertTo<Vector2>(args[2]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when user drags a connection from an input port into the empty space of the graph.</para>
    /// </summary>
    public unsafe event ConnectionFromEmptyEventHandler ConnectionFromEmpty
    {
        add => Connect(SignalName.ConnectionFromEmpty, Callable.CreateWithUnsafeTrampoline(value, &ConnectionFromEmptyTrampoline));
        remove => Disconnect(SignalName.ConnectionFromEmpty, Callable.CreateWithUnsafeTrampoline(value, &ConnectionFromEmptyTrampoline));
    }

    protected void EmitSignalConnectionFromEmpty(StringName toNode, long toPort, Vector2 releasePosition)
    {
        EmitSignal(SignalName.ConnectionFromEmpty, toNode, toPort, releasePosition);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.GraphEdit.ConnectionDragStarted"/> event of a <see cref="Godot.GraphEdit"/> class.
    /// </summary>
    public delegate void ConnectionDragStartedEventHandler(StringName fromNode, long fromPort, bool isOutput);

    private static void ConnectionDragStartedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 3);
        ((ConnectionDragStartedEventHandler)delegateObj)(VariantUtils.ConvertTo<StringName>(args[0]), VariantUtils.ConvertTo<long>(args[1]), VariantUtils.ConvertTo<bool>(args[2]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted at the beginning of a connection drag.</para>
    /// </summary>
    public unsafe event ConnectionDragStartedEventHandler ConnectionDragStarted
    {
        add => Connect(SignalName.ConnectionDragStarted, Callable.CreateWithUnsafeTrampoline(value, &ConnectionDragStartedTrampoline));
        remove => Disconnect(SignalName.ConnectionDragStarted, Callable.CreateWithUnsafeTrampoline(value, &ConnectionDragStartedTrampoline));
    }

    protected void EmitSignalConnectionDragStarted(StringName fromNode, long fromPort, bool isOutput)
    {
        EmitSignal(SignalName.ConnectionDragStarted, fromNode, fromPort, isOutput);
    }

    /// <summary>
    /// <para>Emitted at the end of a connection drag.</para>
    /// </summary>
    public event Action ConnectionDragEnded
    {
        add => Connect(SignalName.ConnectionDragEnded, Callable.From(value));
        remove => Disconnect(SignalName.ConnectionDragEnded, Callable.From(value));
    }

    protected void EmitSignalConnectionDragEnded()
    {
        EmitSignal(SignalName.ConnectionDragEnded);
    }

    /// <summary>
    /// <para>Emitted when this <see cref="Godot.GraphEdit"/> captures a <c>ui_copy</c> action (Ctrl + C by default). In general, this signal indicates that the selected <see cref="Godot.GraphElement"/>s should be copied.</para>
    /// </summary>
    public event Action CopyNodesRequest
    {
        add => Connect(SignalName.CopyNodesRequest, Callable.From(value));
        remove => Disconnect(SignalName.CopyNodesRequest, Callable.From(value));
    }

    protected void EmitSignalCopyNodesRequest()
    {
        EmitSignal(SignalName.CopyNodesRequest);
    }

    /// <summary>
    /// <para>Emitted when this <see cref="Godot.GraphEdit"/> captures a <c>ui_cut</c> action (Ctrl + X by default). In general, this signal indicates that the selected <see cref="Godot.GraphElement"/>s should be cut.</para>
    /// </summary>
    public event Action CutNodesRequest
    {
        add => Connect(SignalName.CutNodesRequest, Callable.From(value));
        remove => Disconnect(SignalName.CutNodesRequest, Callable.From(value));
    }

    protected void EmitSignalCutNodesRequest()
    {
        EmitSignal(SignalName.CutNodesRequest);
    }

    /// <summary>
    /// <para>Emitted when this <see cref="Godot.GraphEdit"/> captures a <c>ui_paste</c> action (Ctrl + V by default). In general, this signal indicates that previously copied <see cref="Godot.GraphElement"/>s should be pasted.</para>
    /// </summary>
    public event Action PasteNodesRequest
    {
        add => Connect(SignalName.PasteNodesRequest, Callable.From(value));
        remove => Disconnect(SignalName.PasteNodesRequest, Callable.From(value));
    }

    protected void EmitSignalPasteNodesRequest()
    {
        EmitSignal(SignalName.PasteNodesRequest);
    }

    /// <summary>
    /// <para>Emitted when this <see cref="Godot.GraphEdit"/> captures a <c>ui_graph_duplicate</c> action (Ctrl + D by default). In general, this signal indicates that the selected <see cref="Godot.GraphElement"/>s should be duplicated.</para>
    /// </summary>
    public event Action DuplicateNodesRequest
    {
        add => Connect(SignalName.DuplicateNodesRequest, Callable.From(value));
        remove => Disconnect(SignalName.DuplicateNodesRequest, Callable.From(value));
    }

    protected void EmitSignalDuplicateNodesRequest()
    {
        EmitSignal(SignalName.DuplicateNodesRequest);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.GraphEdit.DeleteNodesRequest"/> event of a <see cref="Godot.GraphEdit"/> class.
    /// </summary>
    public delegate void DeleteNodesRequestEventHandler(Godot.Collections.Array<StringName> nodes);

    private static void DeleteNodesRequestTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((DeleteNodesRequestEventHandler)delegateObj)(new Godot.Collections.Array<StringName>(VariantUtils.ConvertToArray(args[0])));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when this <see cref="Godot.GraphEdit"/> captures a <c>ui_graph_delete</c> action (Delete by default).</para>
    /// <para><c>nodes</c> is an array of node names that should be removed. These usually include all selected nodes.</para>
    /// </summary>
    public unsafe event DeleteNodesRequestEventHandler DeleteNodesRequest
    {
        add => Connect(SignalName.DeleteNodesRequest, Callable.CreateWithUnsafeTrampoline(value, &DeleteNodesRequestTrampoline));
        remove => Disconnect(SignalName.DeleteNodesRequest, Callable.CreateWithUnsafeTrampoline(value, &DeleteNodesRequestTrampoline));
    }

    protected void EmitSignalDeleteNodesRequest(Godot.Collections.Array<StringName> nodes)
    {
        EmitSignal(SignalName.DeleteNodesRequest, nodes);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.GraphEdit.NodeSelected"/> event of a <see cref="Godot.GraphEdit"/> class.
    /// </summary>
    public delegate void NodeSelectedEventHandler(Node node);

    private static void NodeSelectedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((NodeSelectedEventHandler)delegateObj)(VariantUtils.ConvertTo<Node>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when the given <see cref="Godot.GraphElement"/> node is selected.</para>
    /// </summary>
    public unsafe event NodeSelectedEventHandler NodeSelected
    {
        add => Connect(SignalName.NodeSelected, Callable.CreateWithUnsafeTrampoline(value, &NodeSelectedTrampoline));
        remove => Disconnect(SignalName.NodeSelected, Callable.CreateWithUnsafeTrampoline(value, &NodeSelectedTrampoline));
    }

    protected void EmitSignalNodeSelected(Node node)
    {
        EmitSignal(SignalName.NodeSelected, node);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.GraphEdit.NodeDeselected"/> event of a <see cref="Godot.GraphEdit"/> class.
    /// </summary>
    public delegate void NodeDeselectedEventHandler(Node node);

    private static void NodeDeselectedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((NodeDeselectedEventHandler)delegateObj)(VariantUtils.ConvertTo<Node>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when the given <see cref="Godot.GraphElement"/> node is deselected.</para>
    /// </summary>
    public unsafe event NodeDeselectedEventHandler NodeDeselected
    {
        add => Connect(SignalName.NodeDeselected, Callable.CreateWithUnsafeTrampoline(value, &NodeDeselectedTrampoline));
        remove => Disconnect(SignalName.NodeDeselected, Callable.CreateWithUnsafeTrampoline(value, &NodeDeselectedTrampoline));
    }

    protected void EmitSignalNodeDeselected(Node node)
    {
        EmitSignal(SignalName.NodeDeselected, node);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.GraphEdit.FrameRectChanged"/> event of a <see cref="Godot.GraphEdit"/> class.
    /// </summary>
    public delegate void FrameRectChangedEventHandler(GraphFrame frame, Rect2 newRect);

    private static void FrameRectChangedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 2);
        ((FrameRectChangedEventHandler)delegateObj)(VariantUtils.ConvertTo<GraphFrame>(args[0]), VariantUtils.ConvertTo<Rect2>(args[1]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when the <see cref="Godot.GraphFrame"/> <c>frame</c> is resized to <c>newRect</c>.</para>
    /// </summary>
    public unsafe event FrameRectChangedEventHandler FrameRectChanged
    {
        add => Connect(SignalName.FrameRectChanged, Callable.CreateWithUnsafeTrampoline(value, &FrameRectChangedTrampoline));
        remove => Disconnect(SignalName.FrameRectChanged, Callable.CreateWithUnsafeTrampoline(value, &FrameRectChangedTrampoline));
    }

    protected void EmitSignalFrameRectChanged(GraphFrame frame, Rect2 newRect)
    {
        EmitSignal(SignalName.FrameRectChanged, frame, newRect);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.GraphEdit.PopupRequest"/> event of a <see cref="Godot.GraphEdit"/> class.
    /// </summary>
    public delegate void PopupRequestEventHandler(Vector2 atPosition);

    private static void PopupRequestTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((PopupRequestEventHandler)delegateObj)(VariantUtils.ConvertTo<Vector2>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when a popup is requested. Happens on right-clicking in the GraphEdit. <c>atPosition</c> is the position of the mouse pointer when the signal is sent.</para>
    /// </summary>
    public unsafe event PopupRequestEventHandler PopupRequest
    {
        add => Connect(SignalName.PopupRequest, Callable.CreateWithUnsafeTrampoline(value, &PopupRequestTrampoline));
        remove => Disconnect(SignalName.PopupRequest, Callable.CreateWithUnsafeTrampoline(value, &PopupRequestTrampoline));
    }

    protected void EmitSignalPopupRequest(Vector2 atPosition)
    {
        EmitSignal(SignalName.PopupRequest, atPosition);
    }

    /// <summary>
    /// <para>Emitted at the beginning of a <see cref="Godot.GraphElement"/>'s movement.</para>
    /// </summary>
    public event Action BeginNodeMove
    {
        add => Connect(SignalName.BeginNodeMove, Callable.From(value));
        remove => Disconnect(SignalName.BeginNodeMove, Callable.From(value));
    }

    protected void EmitSignalBeginNodeMove()
    {
        EmitSignal(SignalName.BeginNodeMove);
    }

    /// <summary>
    /// <para>Emitted at the end of a <see cref="Godot.GraphElement"/>'s movement.</para>
    /// </summary>
    public event Action EndNodeMove
    {
        add => Connect(SignalName.EndNodeMove, Callable.From(value));
        remove => Disconnect(SignalName.EndNodeMove, Callable.From(value));
    }

    protected void EmitSignalEndNodeMove()
    {
        EmitSignal(SignalName.EndNodeMove);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.GraphEdit.GraphElementsLinkedToFrameRequest"/> event of a <see cref="Godot.GraphEdit"/> class.
    /// </summary>
    public delegate void GraphElementsLinkedToFrameRequestEventHandler(Godot.Collections.Array elements, StringName frame);

    private static void GraphElementsLinkedToFrameRequestTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 2);
        ((GraphElementsLinkedToFrameRequestEventHandler)delegateObj)(VariantUtils.ConvertTo<Godot.Collections.Array>(args[0]), VariantUtils.ConvertTo<StringName>(args[1]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when one or more <see cref="Godot.GraphElement"/>s are dropped onto the <see cref="Godot.GraphFrame"/> named <c>frame</c>, when they were not previously attached to any other one.</para>
    /// <para><c>elements</c> is an array of <see cref="Godot.GraphElement"/>s to be attached.</para>
    /// </summary>
    public unsafe event GraphElementsLinkedToFrameRequestEventHandler GraphElementsLinkedToFrameRequest
    {
        add => Connect(SignalName.GraphElementsLinkedToFrameRequest, Callable.CreateWithUnsafeTrampoline(value, &GraphElementsLinkedToFrameRequestTrampoline));
        remove => Disconnect(SignalName.GraphElementsLinkedToFrameRequest, Callable.CreateWithUnsafeTrampoline(value, &GraphElementsLinkedToFrameRequestTrampoline));
    }

    protected void EmitSignalGraphElementsLinkedToFrameRequest(Godot.Collections.Array elements, StringName frame)
    {
        EmitSignal(SignalName.GraphElementsLinkedToFrameRequest, elements, frame);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.GraphEdit.ScrollOffsetChanged"/> event of a <see cref="Godot.GraphEdit"/> class.
    /// </summary>
    public delegate void ScrollOffsetChangedEventHandler(Vector2 offset);

    private static void ScrollOffsetChangedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((ScrollOffsetChangedEventHandler)delegateObj)(VariantUtils.ConvertTo<Vector2>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when the scroll offset is changed by the user. It will not be emitted when changed in code.</para>
    /// </summary>
    public unsafe event ScrollOffsetChangedEventHandler ScrollOffsetChanged
    {
        add => Connect(SignalName.ScrollOffsetChanged, Callable.CreateWithUnsafeTrampoline(value, &ScrollOffsetChangedTrampoline));
        remove => Disconnect(SignalName.ScrollOffsetChanged, Callable.CreateWithUnsafeTrampoline(value, &ScrollOffsetChangedTrampoline));
    }

    protected void EmitSignalScrollOffsetChanged(Vector2 offset)
    {
        EmitSignal(SignalName.ScrollOffsetChanged, offset);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__get_connection_line = "_GetConnectionLine";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__is_in_input_hotzone = "_IsInInputHotzone";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__is_in_output_hotzone = "_IsInOutputHotzone";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName MethodProxyName__is_node_hover_valid = "_IsNodeHoverValid";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_connection_request = "ConnectionRequest";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_disconnection_request = "DisconnectionRequest";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_connection_to_empty = "ConnectionToEmpty";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_connection_from_empty = "ConnectionFromEmpty";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_connection_drag_started = "ConnectionDragStarted";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_connection_drag_ended = "ConnectionDragEnded";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_copy_nodes_request = "CopyNodesRequest";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_cut_nodes_request = "CutNodesRequest";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_paste_nodes_request = "PasteNodesRequest";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_duplicate_nodes_request = "DuplicateNodesRequest";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_delete_nodes_request = "DeleteNodesRequest";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_node_selected = "NodeSelected";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_node_deselected = "NodeDeselected";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_frame_rect_changed = "FrameRectChanged";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_popup_request = "PopupRequest";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_begin_node_move = "BeginNodeMove";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_end_node_move = "EndNodeMove";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_graph_elements_linked_to_frame_request = "GraphElementsLinkedToFrameRequest";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_scroll_offset_changed = "ScrollOffsetChanged";

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
        if ((method == MethodProxyName__get_connection_line || method == MethodName._GetConnectionLine) && args.Count == 2 && HasGodotClassMethod((godot_string_name)MethodProxyName__get_connection_line.NativeValue))
        {
            var callRet = _GetConnectionLine(VariantUtils.ConvertTo<Vector2>(args[0]), VariantUtils.ConvertTo<Vector2>(args[1]));
            ret = VariantUtils.CreateFrom<Vector2[]>(callRet);
            return true;
        }
        if ((method == MethodProxyName__is_in_input_hotzone || method == MethodName._IsInInputHotzone) && args.Count == 3 && HasGodotClassMethod((godot_string_name)MethodProxyName__is_in_input_hotzone.NativeValue))
        {
            var callRet = _IsInInputHotzone(VariantUtils.ConvertTo<GodotObject>(args[0]), VariantUtils.ConvertTo<int>(args[1]), VariantUtils.ConvertTo<Vector2>(args[2]));
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__is_in_output_hotzone || method == MethodName._IsInOutputHotzone) && args.Count == 3 && HasGodotClassMethod((godot_string_name)MethodProxyName__is_in_output_hotzone.NativeValue))
        {
            var callRet = _IsInOutputHotzone(VariantUtils.ConvertTo<GodotObject>(args[0]), VariantUtils.ConvertTo<int>(args[1]), VariantUtils.ConvertTo<Vector2>(args[2]));
            ret = VariantUtils.CreateFrom<bool>(callRet);
            return true;
        }
        if ((method == MethodProxyName__is_node_hover_valid || method == MethodName._IsNodeHoverValid) && args.Count == 4 && HasGodotClassMethod((godot_string_name)MethodProxyName__is_node_hover_valid.NativeValue))
        {
            var callRet = _IsNodeHoverValid(VariantUtils.ConvertTo<StringName>(args[0]), VariantUtils.ConvertTo<int>(args[1]), VariantUtils.ConvertTo<StringName>(args[2]), VariantUtils.ConvertTo<int>(args[3]));
            ret = VariantUtils.CreateFrom<bool>(callRet);
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
        if (method == MethodName._GetConnectionLine)
        {
            if (HasGodotClassMethod(MethodProxyName__get_connection_line.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._IsInInputHotzone)
        {
            if (HasGodotClassMethod(MethodProxyName__is_in_input_hotzone.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._IsInOutputHotzone)
        {
            if (HasGodotClassMethod(MethodProxyName__is_in_output_hotzone.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (method == MethodName._IsNodeHoverValid)
        {
            if (HasGodotClassMethod(MethodProxyName__is_node_hover_valid.NativeValue.DangerousSelfRef))
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
        if (signal == SignalName.ConnectionRequest)
        {
            if (HasGodotClassSignal(SignalProxyName_connection_request.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.DisconnectionRequest)
        {
            if (HasGodotClassSignal(SignalProxyName_disconnection_request.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.ConnectionToEmpty)
        {
            if (HasGodotClassSignal(SignalProxyName_connection_to_empty.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.ConnectionFromEmpty)
        {
            if (HasGodotClassSignal(SignalProxyName_connection_from_empty.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.ConnectionDragStarted)
        {
            if (HasGodotClassSignal(SignalProxyName_connection_drag_started.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.ConnectionDragEnded)
        {
            if (HasGodotClassSignal(SignalProxyName_connection_drag_ended.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.CopyNodesRequest)
        {
            if (HasGodotClassSignal(SignalProxyName_copy_nodes_request.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.CutNodesRequest)
        {
            if (HasGodotClassSignal(SignalProxyName_cut_nodes_request.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.PasteNodesRequest)
        {
            if (HasGodotClassSignal(SignalProxyName_paste_nodes_request.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.DuplicateNodesRequest)
        {
            if (HasGodotClassSignal(SignalProxyName_duplicate_nodes_request.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.DeleteNodesRequest)
        {
            if (HasGodotClassSignal(SignalProxyName_delete_nodes_request.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.NodeSelected)
        {
            if (HasGodotClassSignal(SignalProxyName_node_selected.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.NodeDeselected)
        {
            if (HasGodotClassSignal(SignalProxyName_node_deselected.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.FrameRectChanged)
        {
            if (HasGodotClassSignal(SignalProxyName_frame_rect_changed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.PopupRequest)
        {
            if (HasGodotClassSignal(SignalProxyName_popup_request.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.BeginNodeMove)
        {
            if (HasGodotClassSignal(SignalProxyName_begin_node_move.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.EndNodeMove)
        {
            if (HasGodotClassSignal(SignalProxyName_end_node_move.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.GraphElementsLinkedToFrameRequest)
        {
            if (HasGodotClassSignal(SignalProxyName_graph_elements_linked_to_frame_request.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.ScrollOffsetChanged)
        {
            if (HasGodotClassSignal(SignalProxyName_scroll_offset_changed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        return base.HasGodotClassSignal(signal);
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : Control.PropertyName
    {
        /// <summary>
        /// Cached name for the 'scroll_offset' property.
        /// </summary>
        public static readonly StringName ScrollOffset = "scroll_offset";
        /// <summary>
        /// Cached name for the 'show_grid' property.
        /// </summary>
        public static readonly StringName ShowGrid = "show_grid";
        /// <summary>
        /// Cached name for the 'grid_pattern' property.
        /// </summary>
        public static readonly StringName GridPattern = "grid_pattern";
        /// <summary>
        /// Cached name for the 'snapping_enabled' property.
        /// </summary>
        public static readonly StringName SnappingEnabled = "snapping_enabled";
        /// <summary>
        /// Cached name for the 'snapping_distance' property.
        /// </summary>
        public static readonly StringName SnappingDistance = "snapping_distance";
        /// <summary>
        /// Cached name for the 'panning_scheme' property.
        /// </summary>
        public static readonly StringName PanningScheme = "panning_scheme";
        /// <summary>
        /// Cached name for the 'right_disconnects' property.
        /// </summary>
        public static readonly StringName RightDisconnects = "right_disconnects";
        /// <summary>
        /// Cached name for the 'type_names' property.
        /// </summary>
        public static readonly StringName TypeNames = "type_names";
        /// <summary>
        /// Cached name for the 'connection_lines_curvature' property.
        /// </summary>
        public static readonly StringName ConnectionLinesCurvature = "connection_lines_curvature";
        /// <summary>
        /// Cached name for the 'connection_lines_thickness' property.
        /// </summary>
        public static readonly StringName ConnectionLinesThickness = "connection_lines_thickness";
        /// <summary>
        /// Cached name for the 'connection_lines_antialiased' property.
        /// </summary>
        public static readonly StringName ConnectionLinesAntialiased = "connection_lines_antialiased";
        /// <summary>
        /// Cached name for the 'connections' property.
        /// </summary>
        public static readonly StringName Connections = "connections";
        /// <summary>
        /// Cached name for the 'zoom' property.
        /// </summary>
        public static readonly StringName Zoom = "zoom";
        /// <summary>
        /// Cached name for the 'zoom_min' property.
        /// </summary>
        public static readonly StringName ZoomMin = "zoom_min";
        /// <summary>
        /// Cached name for the 'zoom_max' property.
        /// </summary>
        public static readonly StringName ZoomMax = "zoom_max";
        /// <summary>
        /// Cached name for the 'zoom_step' property.
        /// </summary>
        public static readonly StringName ZoomStep = "zoom_step";
        /// <summary>
        /// Cached name for the 'minimap_enabled' property.
        /// </summary>
        public static readonly StringName MinimapEnabled = "minimap_enabled";
        /// <summary>
        /// Cached name for the 'minimap_size' property.
        /// </summary>
        public static readonly StringName MinimapSize = "minimap_size";
        /// <summary>
        /// Cached name for the 'minimap_opacity' property.
        /// </summary>
        public static readonly StringName MinimapOpacity = "minimap_opacity";
        /// <summary>
        /// Cached name for the 'show_menu' property.
        /// </summary>
        public static readonly StringName ShowMenu = "show_menu";
        /// <summary>
        /// Cached name for the 'show_zoom_label' property.
        /// </summary>
        public static readonly StringName ShowZoomLabel = "show_zoom_label";
        /// <summary>
        /// Cached name for the 'show_zoom_buttons' property.
        /// </summary>
        public static readonly StringName ShowZoomButtons = "show_zoom_buttons";
        /// <summary>
        /// Cached name for the 'show_grid_buttons' property.
        /// </summary>
        public static readonly StringName ShowGridButtons = "show_grid_buttons";
        /// <summary>
        /// Cached name for the 'show_minimap_button' property.
        /// </summary>
        public static readonly StringName ShowMinimapButton = "show_minimap_button";
        /// <summary>
        /// Cached name for the 'show_arrange_button' property.
        /// </summary>
        public static readonly StringName ShowArrangeButton = "show_arrange_button";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Control.MethodName
    {
        /// <summary>
        /// Cached name for the '_get_connection_line' method.
        /// </summary>
        public static readonly StringName _GetConnectionLine = "_get_connection_line";
        /// <summary>
        /// Cached name for the '_is_in_input_hotzone' method.
        /// </summary>
        public static readonly StringName _IsInInputHotzone = "_is_in_input_hotzone";
        /// <summary>
        /// Cached name for the '_is_in_output_hotzone' method.
        /// </summary>
        public static readonly StringName _IsInOutputHotzone = "_is_in_output_hotzone";
        /// <summary>
        /// Cached name for the '_is_node_hover_valid' method.
        /// </summary>
        public static readonly StringName _IsNodeHoverValid = "_is_node_hover_valid";
        /// <summary>
        /// Cached name for the 'connect_node' method.
        /// </summary>
        public static readonly StringName ConnectNode = "connect_node";
        /// <summary>
        /// Cached name for the 'is_node_connected' method.
        /// </summary>
        public static readonly StringName IsNodeConnected = "is_node_connected";
        /// <summary>
        /// Cached name for the 'disconnect_node' method.
        /// </summary>
        public static readonly StringName DisconnectNode = "disconnect_node";
        /// <summary>
        /// Cached name for the 'set_connection_activity' method.
        /// </summary>
        public static readonly StringName SetConnectionActivity = "set_connection_activity";
        /// <summary>
        /// Cached name for the 'set_connections' method.
        /// </summary>
        public static readonly StringName SetConnections = "set_connections";
        /// <summary>
        /// Cached name for the 'get_connection_list' method.
        /// </summary>
        public static readonly StringName GetConnectionList = "get_connection_list";
        /// <summary>
        /// Cached name for the 'get_connection_count' method.
        /// </summary>
        public static readonly StringName GetConnectionCount = "get_connection_count";
        /// <summary>
        /// Cached name for the 'get_closest_connection_at_point' method.
        /// </summary>
        public static readonly StringName GetClosestConnectionAtPoint = "get_closest_connection_at_point";
        /// <summary>
        /// Cached name for the 'get_connection_list_from_node' method.
        /// </summary>
        public static readonly StringName GetConnectionListFromNode = "get_connection_list_from_node";
        /// <summary>
        /// Cached name for the 'get_connections_intersecting_with_rect' method.
        /// </summary>
        public static readonly StringName GetConnectionsIntersectingWithRect = "get_connections_intersecting_with_rect";
        /// <summary>
        /// Cached name for the 'clear_connections' method.
        /// </summary>
        public static readonly StringName ClearConnections = "clear_connections";
        /// <summary>
        /// Cached name for the 'force_connection_drag_end' method.
        /// </summary>
        public static readonly StringName ForceConnectionDragEnd = "force_connection_drag_end";
        /// <summary>
        /// Cached name for the 'get_scroll_offset' method.
        /// </summary>
        public static readonly StringName GetScrollOffset = "get_scroll_offset";
        /// <summary>
        /// Cached name for the 'set_scroll_offset' method.
        /// </summary>
        public static readonly StringName SetScrollOffset = "set_scroll_offset";
        /// <summary>
        /// Cached name for the 'add_valid_right_disconnect_type' method.
        /// </summary>
        public static readonly StringName AddValidRightDisconnectType = "add_valid_right_disconnect_type";
        /// <summary>
        /// Cached name for the 'remove_valid_right_disconnect_type' method.
        /// </summary>
        public static readonly StringName RemoveValidRightDisconnectType = "remove_valid_right_disconnect_type";
        /// <summary>
        /// Cached name for the 'add_valid_left_disconnect_type' method.
        /// </summary>
        public static readonly StringName AddValidLeftDisconnectType = "add_valid_left_disconnect_type";
        /// <summary>
        /// Cached name for the 'remove_valid_left_disconnect_type' method.
        /// </summary>
        public static readonly StringName RemoveValidLeftDisconnectType = "remove_valid_left_disconnect_type";
        /// <summary>
        /// Cached name for the 'add_valid_connection_type' method.
        /// </summary>
        public static readonly StringName AddValidConnectionType = "add_valid_connection_type";
        /// <summary>
        /// Cached name for the 'remove_valid_connection_type' method.
        /// </summary>
        public static readonly StringName RemoveValidConnectionType = "remove_valid_connection_type";
        /// <summary>
        /// Cached name for the 'is_valid_connection_type' method.
        /// </summary>
        public static readonly StringName IsValidConnectionType = "is_valid_connection_type";
        /// <summary>
        /// Cached name for the 'get_connection_line' method.
        /// </summary>
        public static readonly StringName GetConnectionLine = "get_connection_line";
        /// <summary>
        /// Cached name for the 'attach_graph_element_to_frame' method.
        /// </summary>
        public static readonly StringName AttachGraphElementToFrame = "attach_graph_element_to_frame";
        /// <summary>
        /// Cached name for the 'detach_graph_element_from_frame' method.
        /// </summary>
        public static readonly StringName DetachGraphElementFromFrame = "detach_graph_element_from_frame";
        /// <summary>
        /// Cached name for the 'get_element_frame' method.
        /// </summary>
        public static readonly StringName GetElementFrame = "get_element_frame";
        /// <summary>
        /// Cached name for the 'get_attached_nodes_of_frame' method.
        /// </summary>
        public static readonly StringName GetAttachedNodesOfFrame = "get_attached_nodes_of_frame";
        /// <summary>
        /// Cached name for the 'set_panning_scheme' method.
        /// </summary>
        public static readonly StringName SetPanningScheme = "set_panning_scheme";
        /// <summary>
        /// Cached name for the 'get_panning_scheme' method.
        /// </summary>
        public static readonly StringName GetPanningScheme = "get_panning_scheme";
        /// <summary>
        /// Cached name for the 'set_zoom' method.
        /// </summary>
        public static readonly StringName SetZoom = "set_zoom";
        /// <summary>
        /// Cached name for the 'get_zoom' method.
        /// </summary>
        public static readonly StringName GetZoom = "get_zoom";
        /// <summary>
        /// Cached name for the 'set_zoom_min' method.
        /// </summary>
        public static readonly StringName SetZoomMin = "set_zoom_min";
        /// <summary>
        /// Cached name for the 'get_zoom_min' method.
        /// </summary>
        public static readonly StringName GetZoomMin = "get_zoom_min";
        /// <summary>
        /// Cached name for the 'set_zoom_max' method.
        /// </summary>
        public static readonly StringName SetZoomMax = "set_zoom_max";
        /// <summary>
        /// Cached name for the 'get_zoom_max' method.
        /// </summary>
        public static readonly StringName GetZoomMax = "get_zoom_max";
        /// <summary>
        /// Cached name for the 'set_zoom_step' method.
        /// </summary>
        public static readonly StringName SetZoomStep = "set_zoom_step";
        /// <summary>
        /// Cached name for the 'get_zoom_step' method.
        /// </summary>
        public static readonly StringName GetZoomStep = "get_zoom_step";
        /// <summary>
        /// Cached name for the 'set_show_grid' method.
        /// </summary>
        public static readonly StringName SetShowGrid = "set_show_grid";
        /// <summary>
        /// Cached name for the 'is_showing_grid' method.
        /// </summary>
        public static readonly StringName IsShowingGrid = "is_showing_grid";
        /// <summary>
        /// Cached name for the 'set_grid_pattern' method.
        /// </summary>
        public static readonly StringName SetGridPattern = "set_grid_pattern";
        /// <summary>
        /// Cached name for the 'get_grid_pattern' method.
        /// </summary>
        public static readonly StringName GetGridPattern = "get_grid_pattern";
        /// <summary>
        /// Cached name for the 'set_snapping_enabled' method.
        /// </summary>
        public static readonly StringName SetSnappingEnabled = "set_snapping_enabled";
        /// <summary>
        /// Cached name for the 'is_snapping_enabled' method.
        /// </summary>
        public static readonly StringName IsSnappingEnabled = "is_snapping_enabled";
        /// <summary>
        /// Cached name for the 'set_snapping_distance' method.
        /// </summary>
        public static readonly StringName SetSnappingDistance = "set_snapping_distance";
        /// <summary>
        /// Cached name for the 'get_snapping_distance' method.
        /// </summary>
        public static readonly StringName GetSnappingDistance = "get_snapping_distance";
        /// <summary>
        /// Cached name for the 'set_connection_lines_curvature' method.
        /// </summary>
        public static readonly StringName SetConnectionLinesCurvature = "set_connection_lines_curvature";
        /// <summary>
        /// Cached name for the 'get_connection_lines_curvature' method.
        /// </summary>
        public static readonly StringName GetConnectionLinesCurvature = "get_connection_lines_curvature";
        /// <summary>
        /// Cached name for the 'set_connection_lines_thickness' method.
        /// </summary>
        public static readonly StringName SetConnectionLinesThickness = "set_connection_lines_thickness";
        /// <summary>
        /// Cached name for the 'get_connection_lines_thickness' method.
        /// </summary>
        public static readonly StringName GetConnectionLinesThickness = "get_connection_lines_thickness";
        /// <summary>
        /// Cached name for the 'set_connection_lines_antialiased' method.
        /// </summary>
        public static readonly StringName SetConnectionLinesAntialiased = "set_connection_lines_antialiased";
        /// <summary>
        /// Cached name for the 'is_connection_lines_antialiased' method.
        /// </summary>
        public static readonly StringName IsConnectionLinesAntialiased = "is_connection_lines_antialiased";
        /// <summary>
        /// Cached name for the 'set_minimap_size' method.
        /// </summary>
        public static readonly StringName SetMinimapSize = "set_minimap_size";
        /// <summary>
        /// Cached name for the 'get_minimap_size' method.
        /// </summary>
        public static readonly StringName GetMinimapSize = "get_minimap_size";
        /// <summary>
        /// Cached name for the 'set_minimap_opacity' method.
        /// </summary>
        public static readonly StringName SetMinimapOpacity = "set_minimap_opacity";
        /// <summary>
        /// Cached name for the 'get_minimap_opacity' method.
        /// </summary>
        public static readonly StringName GetMinimapOpacity = "get_minimap_opacity";
        /// <summary>
        /// Cached name for the 'set_minimap_enabled' method.
        /// </summary>
        public static readonly StringName SetMinimapEnabled = "set_minimap_enabled";
        /// <summary>
        /// Cached name for the 'is_minimap_enabled' method.
        /// </summary>
        public static readonly StringName IsMinimapEnabled = "is_minimap_enabled";
        /// <summary>
        /// Cached name for the 'set_show_menu' method.
        /// </summary>
        public static readonly StringName SetShowMenu = "set_show_menu";
        /// <summary>
        /// Cached name for the 'is_showing_menu' method.
        /// </summary>
        public static readonly StringName IsShowingMenu = "is_showing_menu";
        /// <summary>
        /// Cached name for the 'set_show_zoom_label' method.
        /// </summary>
        public static readonly StringName SetShowZoomLabel = "set_show_zoom_label";
        /// <summary>
        /// Cached name for the 'is_showing_zoom_label' method.
        /// </summary>
        public static readonly StringName IsShowingZoomLabel = "is_showing_zoom_label";
        /// <summary>
        /// Cached name for the 'set_show_grid_buttons' method.
        /// </summary>
        public static readonly StringName SetShowGridButtons = "set_show_grid_buttons";
        /// <summary>
        /// Cached name for the 'is_showing_grid_buttons' method.
        /// </summary>
        public static readonly StringName IsShowingGridButtons = "is_showing_grid_buttons";
        /// <summary>
        /// Cached name for the 'set_show_zoom_buttons' method.
        /// </summary>
        public static readonly StringName SetShowZoomButtons = "set_show_zoom_buttons";
        /// <summary>
        /// Cached name for the 'is_showing_zoom_buttons' method.
        /// </summary>
        public static readonly StringName IsShowingZoomButtons = "is_showing_zoom_buttons";
        /// <summary>
        /// Cached name for the 'set_show_minimap_button' method.
        /// </summary>
        public static readonly StringName SetShowMinimapButton = "set_show_minimap_button";
        /// <summary>
        /// Cached name for the 'is_showing_minimap_button' method.
        /// </summary>
        public static readonly StringName IsShowingMinimapButton = "is_showing_minimap_button";
        /// <summary>
        /// Cached name for the 'set_show_arrange_button' method.
        /// </summary>
        public static readonly StringName SetShowArrangeButton = "set_show_arrange_button";
        /// <summary>
        /// Cached name for the 'is_showing_arrange_button' method.
        /// </summary>
        public static readonly StringName IsShowingArrangeButton = "is_showing_arrange_button";
        /// <summary>
        /// Cached name for the 'set_right_disconnects' method.
        /// </summary>
        public static readonly StringName SetRightDisconnects = "set_right_disconnects";
        /// <summary>
        /// Cached name for the 'is_right_disconnects_enabled' method.
        /// </summary>
        public static readonly StringName IsRightDisconnectsEnabled = "is_right_disconnects_enabled";
        /// <summary>
        /// Cached name for the 'set_type_names' method.
        /// </summary>
        public static readonly StringName SetTypeNames = "set_type_names";
        /// <summary>
        /// Cached name for the 'get_type_names' method.
        /// </summary>
        public static readonly StringName GetTypeNames = "get_type_names";
        /// <summary>
        /// Cached name for the 'get_menu_hbox' method.
        /// </summary>
        public static readonly StringName GetMenuHBox = "get_menu_hbox";
        /// <summary>
        /// Cached name for the 'arrange_nodes' method.
        /// </summary>
        public static readonly StringName ArrangeNodes = "arrange_nodes";
        /// <summary>
        /// Cached name for the 'set_selected' method.
        /// </summary>
        public static readonly StringName SetSelected = "set_selected";
        /// <summary>
        /// Cached name for the 'set_arrange_nodes_button_hidden' method.
        /// </summary>
        public static readonly StringName SetArrangeNodesButtonHidden = "set_arrange_nodes_button_hidden";
        /// <summary>
        /// Cached name for the 'is_arrange_nodes_button_hidden' method.
        /// </summary>
        public static readonly StringName IsArrangeNodesButtonHidden = "is_arrange_nodes_button_hidden";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Control.SignalName
    {
        /// <summary>
        /// Cached name for the 'connection_request' signal.
        /// </summary>
        public static readonly StringName ConnectionRequest = "connection_request";
        /// <summary>
        /// Cached name for the 'disconnection_request' signal.
        /// </summary>
        public static readonly StringName DisconnectionRequest = "disconnection_request";
        /// <summary>
        /// Cached name for the 'connection_to_empty' signal.
        /// </summary>
        public static readonly StringName ConnectionToEmpty = "connection_to_empty";
        /// <summary>
        /// Cached name for the 'connection_from_empty' signal.
        /// </summary>
        public static readonly StringName ConnectionFromEmpty = "connection_from_empty";
        /// <summary>
        /// Cached name for the 'connection_drag_started' signal.
        /// </summary>
        public static readonly StringName ConnectionDragStarted = "connection_drag_started";
        /// <summary>
        /// Cached name for the 'connection_drag_ended' signal.
        /// </summary>
        public static readonly StringName ConnectionDragEnded = "connection_drag_ended";
        /// <summary>
        /// Cached name for the 'copy_nodes_request' signal.
        /// </summary>
        public static readonly StringName CopyNodesRequest = "copy_nodes_request";
        /// <summary>
        /// Cached name for the 'cut_nodes_request' signal.
        /// </summary>
        public static readonly StringName CutNodesRequest = "cut_nodes_request";
        /// <summary>
        /// Cached name for the 'paste_nodes_request' signal.
        /// </summary>
        public static readonly StringName PasteNodesRequest = "paste_nodes_request";
        /// <summary>
        /// Cached name for the 'duplicate_nodes_request' signal.
        /// </summary>
        public static readonly StringName DuplicateNodesRequest = "duplicate_nodes_request";
        /// <summary>
        /// Cached name for the 'delete_nodes_request' signal.
        /// </summary>
        public static readonly StringName DeleteNodesRequest = "delete_nodes_request";
        /// <summary>
        /// Cached name for the 'node_selected' signal.
        /// </summary>
        public static readonly StringName NodeSelected = "node_selected";
        /// <summary>
        /// Cached name for the 'node_deselected' signal.
        /// </summary>
        public static readonly StringName NodeDeselected = "node_deselected";
        /// <summary>
        /// Cached name for the 'frame_rect_changed' signal.
        /// </summary>
        public static readonly StringName FrameRectChanged = "frame_rect_changed";
        /// <summary>
        /// Cached name for the 'popup_request' signal.
        /// </summary>
        public static readonly StringName PopupRequest = "popup_request";
        /// <summary>
        /// Cached name for the 'begin_node_move' signal.
        /// </summary>
        public static readonly StringName BeginNodeMove = "begin_node_move";
        /// <summary>
        /// Cached name for the 'end_node_move' signal.
        /// </summary>
        public static readonly StringName EndNodeMove = "end_node_move";
        /// <summary>
        /// Cached name for the 'graph_elements_linked_to_frame_request' signal.
        /// </summary>
        public static readonly StringName GraphElementsLinkedToFrameRequest = "graph_elements_linked_to_frame_request";
        /// <summary>
        /// Cached name for the 'scroll_offset_changed' signal.
        /// </summary>
        public static readonly StringName ScrollOffsetChanged = "scroll_offset_changed";
    }
}
