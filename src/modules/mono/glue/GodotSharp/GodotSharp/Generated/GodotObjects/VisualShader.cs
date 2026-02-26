namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This class provides a graph-like visual editor for creating a <see cref="Godot.Shader"/>. Although <see cref="Godot.VisualShader"/>s do not require coding, they share the same logic with script shaders. They use <see cref="Godot.VisualShaderNode"/>s that can be connected to each other to control the flow of the shader. The visual shader graph is converted to a script shader behind the scenes.</para>
/// </summary>
public partial class VisualShader : Shader
{
    /// <summary>
    /// <para>Indicates an invalid <see cref="Godot.VisualShader"/> node.</para>
    /// </summary>
    public const long NodeIdInvalid = -1;
    /// <summary>
    /// <para>Indicates an output node of <see cref="Godot.VisualShader"/>.</para>
    /// </summary>
    public const long NodeIdOutput = 0;

    public enum Type : long
    {
        /// <summary>
        /// <para>A vertex shader, operating on vertices.</para>
        /// </summary>
        Vertex = 0,
        /// <summary>
        /// <para>A fragment shader, operating on fragments (pixels).</para>
        /// </summary>
        Fragment = 1,
        /// <summary>
        /// <para>A shader for light calculations.</para>
        /// </summary>
        Light = 2,
        /// <summary>
        /// <para>A function for the "start" stage of particle shader.</para>
        /// </summary>
        Start = 3,
        /// <summary>
        /// <para>A function for the "process" stage of particle shader.</para>
        /// </summary>
        Process = 4,
        /// <summary>
        /// <para>A function for the "collide" stage (particle collision handler) of particle shader.</para>
        /// </summary>
        Collide = 5,
        /// <summary>
        /// <para>A function for the "start" stage of particle shader, with customized output.</para>
        /// </summary>
        StartCustom = 6,
        /// <summary>
        /// <para>A function for the "process" stage of particle shader, with customized output.</para>
        /// </summary>
        ProcessCustom = 7,
        /// <summary>
        /// <para>A shader for 3D environment's sky.</para>
        /// </summary>
        Sky = 8,
        /// <summary>
        /// <para>A compute shader that runs for each froxel of the volumetric fog map.</para>
        /// </summary>
        Fog = 9,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.VisualShader.Type"/> enum.</para>
        /// </summary>
        Max = 10
    }

    public enum VaryingMode : long
    {
        /// <summary>
        /// <para>Varying is passed from <c>Vertex</c> function to <c>Fragment</c> and <c>Light</c> functions.</para>
        /// </summary>
        VertexToFragLight = 0,
        /// <summary>
        /// <para>Varying is passed from <c>Fragment</c> function to <c>Light</c> function.</para>
        /// </summary>
        FragToLight = 1,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.VisualShader.VaryingMode"/> enum.</para>
        /// </summary>
        Max = 2
    }

    public enum VaryingType : long
    {
        /// <summary>
        /// <para>Varying is of type <see cref="float"/>.</para>
        /// </summary>
        Float = 0,
        /// <summary>
        /// <para>Varying is of type <see cref="int"/>.</para>
        /// </summary>
        Int = 1,
        /// <summary>
        /// <para>Varying is of type unsigned <see cref="int"/>.</para>
        /// </summary>
        Uint = 2,
        /// <summary>
        /// <para>Varying is of type <see cref="Godot.Vector2"/>.</para>
        /// </summary>
        Vector2D = 3,
        /// <summary>
        /// <para>Varying is of type <see cref="Godot.Vector3"/>.</para>
        /// </summary>
        Vector3D = 4,
        /// <summary>
        /// <para>Varying is of type <see cref="Godot.Vector4"/>.</para>
        /// </summary>
        Vector4D = 5,
        /// <summary>
        /// <para>Varying is of type <see cref="bool"/>.</para>
        /// </summary>
        Boolean = 6,
        /// <summary>
        /// <para>Varying is of type <see cref="Godot.Transform3D"/>.</para>
        /// </summary>
        Transform = 7,
        /// <summary>
        /// <para>Represents the size of the <see cref="Godot.VisualShader.VaryingType"/> enum.</para>
        /// </summary>
        Max = 8
    }

    /// <summary>
    /// <para>Deprecated.</para>
    /// </summary>
    [Obsolete("This property does nothing and always equals to zero.")]
    public Vector2 GraphOffset
    {
        get
        {
            return GetGraphOffset();
        }
        set
        {
            SetGraphOffset(value);
        }
    }

    private static readonly System.Type CachedType = typeof(VisualShader);

    private static readonly StringName NativeName = "VisualShader";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public VisualShader() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal VisualShader(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal VisualShader(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetMode, 3978014962ul);

    /// <summary>
    /// <para>Sets the mode of this shader.</para>
    /// </summary>
    public void SetMode(Shader.Mode mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind0, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddNode, 1560769431ul);

    /// <summary>
    /// <para>Adds the specified <paramref name="node"/> to the shader.</para>
    /// </summary>
    public unsafe void AddNode(VisualShader.Type type, VisualShaderNode node, Vector2 position, int id)
    {
        NativeCalls.godot_icall_4_1491(MethodBind1, GodotObject.GetPtr(this), (int)type, GodotObject.GetPtr(node), &position, id);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNode, 3784670312ul);

    /// <summary>
    /// <para>Returns the shader node instance with specified <paramref name="type"/> and <paramref name="id"/>.</para>
    /// </summary>
    public VisualShaderNode GetNode(VisualShader.Type type, int id)
    {
        return (VisualShaderNode)NativeCalls.godot_icall_2_101(MethodBind2, GodotObject.GetPtr(this), (int)type, id);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetNodePosition, 2726660721ul);

    /// <summary>
    /// <para>Sets the position of the specified node.</para>
    /// </summary>
    public unsafe void SetNodePosition(VisualShader.Type type, int id, Vector2 position)
    {
        NativeCalls.godot_icall_3_1492(MethodBind3, GodotObject.GetPtr(this), (int)type, id, &position);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNodePosition, 2175036082ul);

    /// <summary>
    /// <para>Returns the position of the specified node within the shader graph.</para>
    /// </summary>
    public Vector2 GetNodePosition(VisualShader.Type type, int id)
    {
        return NativeCalls.godot_icall_2_97(MethodBind4, GodotObject.GetPtr(this), (int)type, id);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNodeList, 2370592410ul);

    /// <summary>
    /// <para>Returns the list of all nodes in the shader with the specified type.</para>
    /// </summary>
    public int[] GetNodeList(VisualShader.Type type)
    {
        return NativeCalls.godot_icall_1_797(MethodBind5, GodotObject.GetPtr(this), (int)type);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetValidNodeId, 629467342ul);

    /// <summary>
    /// <para>Returns next valid node ID that can be added to the shader graph.</para>
    /// </summary>
    public int GetValidNodeId(VisualShader.Type type)
    {
        return NativeCalls.godot_icall_1_60(MethodBind6, GodotObject.GetPtr(this), (int)type);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveNode, 844050912ul);

    /// <summary>
    /// <para>Removes the specified node from the shader.</para>
    /// </summary>
    public void RemoveNode(VisualShader.Type type, int id)
    {
        NativeCalls.godot_icall_2_59(MethodBind7, GodotObject.GetPtr(this), (int)type, id);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ReplaceNode, 3144735253ul);

    /// <summary>
    /// <para>Replaces the specified node with a node of new class type.</para>
    /// </summary>
    public void ReplaceNode(VisualShader.Type type, int id, StringName newClass)
    {
        NativeCalls.godot_icall_3_103(MethodBind8, GodotObject.GetPtr(this), (int)type, id, (godot_string_name)(newClass?.NativeValue ?? default));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsNodeConnection, 3922381898ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the specified node and port connection exist.</para>
    /// </summary>
    public bool IsNodeConnection(VisualShader.Type type, int fromNode, int fromPort, int toNode, int toPort)
    {
        return NativeCalls.godot_icall_5_1493(MethodBind9, GodotObject.GetPtr(this), (int)type, fromNode, fromPort, toNode, toPort).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.CanConnectNodes, 3922381898ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the specified nodes and ports can be connected together.</para>
    /// </summary>
    public bool CanConnectNodes(VisualShader.Type type, int fromNode, int fromPort, int toNode, int toPort)
    {
        return NativeCalls.godot_icall_5_1493(MethodBind10, GodotObject.GetPtr(this), (int)type, fromNode, fromPort, toNode, toPort).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ConnectNodes, 3081049573ul);

    /// <summary>
    /// <para>Connects the specified nodes and ports.</para>
    /// </summary>
    public Error ConnectNodes(VisualShader.Type type, int fromNode, int fromPort, int toNode, int toPort)
    {
        return (Error)NativeCalls.godot_icall_5_462(MethodBind11, GodotObject.GetPtr(this), (int)type, fromNode, fromPort, toNode, toPort);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DisconnectNodes, 2268060358ul);

    /// <summary>
    /// <para>Connects the specified nodes and ports.</para>
    /// </summary>
    public void DisconnectNodes(VisualShader.Type type, int fromNode, int fromPort, int toNode, int toPort)
    {
        NativeCalls.godot_icall_5_1309(MethodBind12, GodotObject.GetPtr(this), (int)type, fromNode, fromPort, toNode, toPort);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ConnectNodesForced, 2268060358ul);

    /// <summary>
    /// <para>Connects the specified nodes and ports, even if they can't be connected. Such connection is invalid and will not function properly.</para>
    /// </summary>
    public void ConnectNodesForced(VisualShader.Type type, int fromNode, int fromPort, int toNode, int toPort)
    {
        NativeCalls.godot_icall_5_1309(MethodBind13, GodotObject.GetPtr(this), (int)type, fromNode, fromPort, toNode, toPort);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetNodeConnections, 1441964831ul);

    /// <summary>
    /// <para>Returns the list of connected nodes with the specified type.</para>
    /// </summary>
    public Godot.Collections.Array<Godot.Collections.Dictionary> GetNodeConnections(VisualShader.Type type)
    {
        return new Godot.Collections.Array<Godot.Collections.Dictionary>(NativeCalls.godot_icall_1_457(MethodBind14, GodotObject.GetPtr(this), (int)type));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AttachNodeToFrame, 2479945279ul);

    /// <summary>
    /// <para>Attaches the given node to the given frame.</para>
    /// </summary>
    public void AttachNodeToFrame(VisualShader.Type type, int id, int frame)
    {
        NativeCalls.godot_icall_3_196(MethodBind15, GodotObject.GetPtr(this), (int)type, id, frame);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.DetachNodeFromFrame, 844050912ul);

    /// <summary>
    /// <para>Detaches the given node from the frame it is attached to.</para>
    /// </summary>
    public void DetachNodeFromFrame(VisualShader.Type type, int id)
    {
        NativeCalls.godot_icall_2_59(MethodBind16, GodotObject.GetPtr(this), (int)type, id);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddVarying, 2084110726ul);

    /// <summary>
    /// <para>Adds a new varying value node to the shader.</para>
    /// </summary>
    public void AddVarying(string name, VisualShader.VaryingMode mode, VisualShader.VaryingType type)
    {
        NativeCalls.godot_icall_3_398(MethodBind17, GodotObject.GetPtr(this), name, (int)mode, (int)type);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveVarying, 83702148ul);

    /// <summary>
    /// <para>Removes a varying value node with the given <paramref name="name"/>. Prints an error if a node with this name is not found.</para>
    /// </summary>
    public void RemoveVarying(string name)
    {
        NativeCalls.godot_icall_1_57(MethodBind18, GodotObject.GetPtr(this), name);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.HasVarying, 3927539163ul);

    /// <summary>
    /// <para>Returns <see langword="true"/> if the shader has a varying with the given <paramref name="name"/>.</para>
    /// </summary>
    public bool HasVarying(string name)
    {
        return NativeCalls.godot_icall_1_131(MethodBind19, GodotObject.GetPtr(this), name).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetGraphOffset, 743155724ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetGraphOffset(Vector2 offset)
    {
        NativeCalls.godot_icall_1_36(MethodBind20, GodotObject.GetPtr(this), &offset);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetGraphOffset, 3341600327ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2 GetGraphOffset()
    {
        return NativeCalls.godot_icall_0_37(MethodBind21, GodotObject.GetPtr(this));
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
    public new class PropertyName : Shader.PropertyName
    {
        /// <summary>
        /// Cached name for the 'graph_offset' property.
        /// </summary>
        public static readonly StringName GraphOffset = "graph_offset";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Shader.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_mode' method.
        /// </summary>
        public static readonly StringName SetMode = "set_mode";
        /// <summary>
        /// Cached name for the 'add_node' method.
        /// </summary>
        public static readonly StringName AddNode = "add_node";
        /// <summary>
        /// Cached name for the 'get_node' method.
        /// </summary>
        public static readonly StringName GetNode = "get_node";
        /// <summary>
        /// Cached name for the 'set_node_position' method.
        /// </summary>
        public static readonly StringName SetNodePosition = "set_node_position";
        /// <summary>
        /// Cached name for the 'get_node_position' method.
        /// </summary>
        public static readonly StringName GetNodePosition = "get_node_position";
        /// <summary>
        /// Cached name for the 'get_node_list' method.
        /// </summary>
        public static readonly StringName GetNodeList = "get_node_list";
        /// <summary>
        /// Cached name for the 'get_valid_node_id' method.
        /// </summary>
        public static readonly StringName GetValidNodeId = "get_valid_node_id";
        /// <summary>
        /// Cached name for the 'remove_node' method.
        /// </summary>
        public static readonly StringName RemoveNode = "remove_node";
        /// <summary>
        /// Cached name for the 'replace_node' method.
        /// </summary>
        public static readonly StringName ReplaceNode = "replace_node";
        /// <summary>
        /// Cached name for the 'is_node_connection' method.
        /// </summary>
        public static readonly StringName IsNodeConnection = "is_node_connection";
        /// <summary>
        /// Cached name for the 'can_connect_nodes' method.
        /// </summary>
        public static readonly StringName CanConnectNodes = "can_connect_nodes";
        /// <summary>
        /// Cached name for the 'connect_nodes' method.
        /// </summary>
        public static readonly StringName ConnectNodes = "connect_nodes";
        /// <summary>
        /// Cached name for the 'disconnect_nodes' method.
        /// </summary>
        public static readonly StringName DisconnectNodes = "disconnect_nodes";
        /// <summary>
        /// Cached name for the 'connect_nodes_forced' method.
        /// </summary>
        public static readonly StringName ConnectNodesForced = "connect_nodes_forced";
        /// <summary>
        /// Cached name for the 'get_node_connections' method.
        /// </summary>
        public static readonly StringName GetNodeConnections = "get_node_connections";
        /// <summary>
        /// Cached name for the 'attach_node_to_frame' method.
        /// </summary>
        public static readonly StringName AttachNodeToFrame = "attach_node_to_frame";
        /// <summary>
        /// Cached name for the 'detach_node_from_frame' method.
        /// </summary>
        public static readonly StringName DetachNodeFromFrame = "detach_node_from_frame";
        /// <summary>
        /// Cached name for the 'add_varying' method.
        /// </summary>
        public static readonly StringName AddVarying = "add_varying";
        /// <summary>
        /// Cached name for the 'remove_varying' method.
        /// </summary>
        public static readonly StringName RemoveVarying = "remove_varying";
        /// <summary>
        /// Cached name for the 'has_varying' method.
        /// </summary>
        public static readonly StringName HasVarying = "has_varying";
        /// <summary>
        /// Cached name for the 'set_graph_offset' method.
        /// </summary>
        public static readonly StringName SetGraphOffset = "set_graph_offset";
        /// <summary>
        /// Cached name for the 'get_graph_offset' method.
        /// </summary>
        public static readonly StringName GetGraphOffset = "get_graph_offset";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Shader.SignalName
    {
    }
}
