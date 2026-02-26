namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>This object manages the SceneTree selection in the editor.</para>
/// <para><b>Note:</b> This class shouldn't be instantiated directly. Instead, access the singleton using <see cref="Godot.EditorInterface.GetSelection()"/>.</para>
/// </summary>
public partial class EditorSelection : GodotObject
{
    private static readonly System.Type CachedType = typeof(EditorSelection);

    private static readonly StringName NativeName = "EditorSelection";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public EditorSelection() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal EditorSelection(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal EditorSelection(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.Clear, 3218959716ul);

    /// <summary>
    /// <para>Clear the selection.</para>
    /// </summary>
    public void Clear()
    {
        NativeCalls.godot_icall_0_3(MethodBind0, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddNode, 1078189570ul);

    /// <summary>
    /// <para>Adds a node to the selection.</para>
    /// <para><b>Note:</b> The newly selected node will not be automatically edited in the inspector. If you want to edit a node, use <see cref="Godot.EditorInterface.EditNode(Node)"/>.</para>
    /// </summary>
    public void AddNode(Node node)
    {
        NativeCalls.godot_icall_1_56(MethodBind1, GodotObject.GetPtr(this), GodotObject.GetPtr(node));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.RemoveNode, 1078189570ul);

    /// <summary>
    /// <para>Removes a node from the selection.</para>
    /// </summary>
    public void RemoveNode(Node node)
    {
        NativeCalls.godot_icall_1_56(MethodBind2, GodotObject.GetPtr(this), GodotObject.GetPtr(node));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSelectedNodes, 2915620761ul);

    /// <summary>
    /// <para>Returns the list of selected nodes.</para>
    /// </summary>
    public Godot.Collections.Array<Node> GetSelectedNodes()
    {
        return new Godot.Collections.Array<Node>(NativeCalls.godot_icall_0_120(MethodBind3, GodotObject.GetPtr(this)));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTopSelectedNodes, 2915620761ul);

    /// <summary>
    /// <para>Returns the list of top selected nodes only, excluding any children. This is useful for performing transform operations (moving them, rotating, etc.).</para>
    /// <para>For example, if there is a node A with a child B and a sibling C, then selecting all three will cause this method to return only A and C. Changing the global transform of A will affect the global transform of B, so there is no need to change B separately.</para>
    /// </summary>
    public Godot.Collections.Array<Node> GetTopSelectedNodes()
    {
        return new Godot.Collections.Array<Node>(NativeCalls.godot_icall_0_120(MethodBind4, GodotObject.GetPtr(this)));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetTransformableSelectedNodes, 2915620761ul);

    /// <summary>
    /// <para>Returns the list of top selected nodes only, excluding any children. This is useful for performing transform operations (moving them, rotating, etc.). See <see cref="Godot.EditorSelection.GetTopSelectedNodes()"/>.</para>
    /// </summary>
    [Obsolete("Use 'Godot.EditorSelection.GetTopSelectedNodes()' instead.")]
    public Godot.Collections.Array<Node> GetTransformableSelectedNodes()
    {
        return new Godot.Collections.Array<Node>(NativeCalls.godot_icall_0_120(MethodBind5, GodotObject.GetPtr(this)));
    }

    /// <summary>
    /// <para>Emitted when the selection changes.</para>
    /// </summary>
    public event Action SelectionChanged
    {
        add => Connect(SignalName.SelectionChanged, Callable.From(value));
        remove => Disconnect(SignalName.SelectionChanged, Callable.From(value));
    }

    protected void EmitSignalSelectionChanged()
    {
        EmitSignal(SignalName.SelectionChanged);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_selection_changed = "SelectionChanged";

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
        if (signal == SignalName.SelectionChanged)
        {
            if (HasGodotClassSignal(SignalProxyName_selection_changed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
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
        /// Cached name for the 'clear' method.
        /// </summary>
        public static readonly StringName Clear = "clear";
        /// <summary>
        /// Cached name for the 'add_node' method.
        /// </summary>
        public static readonly StringName AddNode = "add_node";
        /// <summary>
        /// Cached name for the 'remove_node' method.
        /// </summary>
        public static readonly StringName RemoveNode = "remove_node";
        /// <summary>
        /// Cached name for the 'get_selected_nodes' method.
        /// </summary>
        public static readonly StringName GetSelectedNodes = "get_selected_nodes";
        /// <summary>
        /// Cached name for the 'get_top_selected_nodes' method.
        /// </summary>
        public static readonly StringName GetTopSelectedNodes = "get_top_selected_nodes";
        /// <summary>
        /// Cached name for the 'get_transformable_selected_nodes' method.
        /// </summary>
        public static readonly StringName GetTransformableSelectedNodes = "get_transformable_selected_nodes";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : GodotObject.SignalName
    {
        /// <summary>
        /// Cached name for the 'selection_changed' signal.
        /// </summary>
        public static readonly StringName SelectionChanged = "selection_changed";
    }
}
