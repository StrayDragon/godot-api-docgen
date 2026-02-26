namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para><see cref="Godot.GraphElement"/> allows to create custom elements for a <see cref="Godot.GraphEdit"/> graph. By default such elements can be selected, resized, and repositioned, but they cannot be connected. For a graph element that allows for connections see <see cref="Godot.GraphNode"/>.</para>
/// </summary>
public partial class GraphElement : Container
{
    /// <summary>
    /// <para>The offset of the GraphElement, relative to the scroll offset of the <see cref="Godot.GraphEdit"/>.</para>
    /// </summary>
    public Vector2 PositionOffset
    {
        get
        {
            return GetPositionOffset();
        }
        set
        {
            SetPositionOffset(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the user can resize the GraphElement.</para>
    /// <para><b>Note:</b> Dragging the handle will only emit the <see cref="Godot.GraphElement.ResizeRequest"/> and <see cref="Godot.GraphElement.ResizeEnd"/> signals, the GraphElement needs to be resized manually.</para>
    /// </summary>
    public bool Resizable
    {
        get
        {
            return IsResizable();
        }
        set
        {
            SetResizable(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the user can drag the GraphElement.</para>
    /// </summary>
    public bool Draggable
    {
        get
        {
            return IsDraggable();
        }
        set
        {
            SetDraggable(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the user can select the GraphElement.</para>
    /// </summary>
    public bool Selectable
    {
        get
        {
            return IsSelectable();
        }
        set
        {
            SetSelectable(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the GraphElement is selected.</para>
    /// </summary>
    public bool Selected
    {
        get
        {
            return IsSelected();
        }
        set
        {
            SetSelected(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, <see cref="Godot.PopupMenu"/>s that are descendants of the GraphElement are scaled with the <see cref="Godot.GraphEdit"/> zoom.</para>
    /// </summary>
    public bool ScalingMenus
    {
        get
        {
            return IsScalingMenus();
        }
        set
        {
            SetScalingMenus(value);
        }
    }

    private static readonly System.Type CachedType = typeof(GraphElement);

    private static readonly StringName NativeName = "GraphElement";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public GraphElement() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal GraphElement(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal GraphElement(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetResizable, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetResizable(bool resizable)
    {
        NativeCalls.godot_icall_1_14(MethodBind0, GodotObject.GetPtr(this), resizable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsResizable, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsResizable()
    {
        return NativeCalls.godot_icall_0_15(MethodBind1, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDraggable, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDraggable(bool draggable)
    {
        NativeCalls.godot_icall_1_14(MethodBind2, GodotObject.GetPtr(this), draggable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsDraggable, 2240911060ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsDraggable()
    {
        return NativeCalls.godot_icall_0_15(MethodBind3, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSelectable, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSelectable(bool selectable)
    {
        NativeCalls.godot_icall_1_14(MethodBind4, GodotObject.GetPtr(this), selectable.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsSelectable, 2240911060ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsSelectable()
    {
        return NativeCalls.godot_icall_0_15(MethodBind5, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSelected, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSelected(bool selected)
    {
        NativeCalls.godot_icall_1_14(MethodBind6, GodotObject.GetPtr(this), selected.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsSelected, 2240911060ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsSelected()
    {
        return NativeCalls.godot_icall_0_15(MethodBind7, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetScalingMenus, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetScalingMenus(bool scalingMenus)
    {
        NativeCalls.godot_icall_1_14(MethodBind8, GodotObject.GetPtr(this), scalingMenus.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsScalingMenus, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsScalingMenus()
    {
        return NativeCalls.godot_icall_0_15(MethodBind9, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetPositionOffset, 743155724ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetPositionOffset(Vector2 offset)
    {
        NativeCalls.godot_icall_1_36(MethodBind10, GodotObject.GetPtr(this), &offset);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetPositionOffset, 3341600327ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2 GetPositionOffset()
    {
        return NativeCalls.godot_icall_0_37(MethodBind11, GodotObject.GetPtr(this));
    }

    /// <summary>
    /// <para>Emitted when the GraphElement is selected.</para>
    /// </summary>
    public event Action NodeSelected
    {
        add => Connect(SignalName.NodeSelected, Callable.From(value));
        remove => Disconnect(SignalName.NodeSelected, Callable.From(value));
    }

    protected void EmitSignalNodeSelected()
    {
        EmitSignal(SignalName.NodeSelected);
    }

    /// <summary>
    /// <para>Emitted when the GraphElement is deselected.</para>
    /// </summary>
    public event Action NodeDeselected
    {
        add => Connect(SignalName.NodeDeselected, Callable.From(value));
        remove => Disconnect(SignalName.NodeDeselected, Callable.From(value));
    }

    protected void EmitSignalNodeDeselected()
    {
        EmitSignal(SignalName.NodeDeselected);
    }

    /// <summary>
    /// <para>Emitted when displaying the GraphElement over other ones is requested. Happens on focusing (clicking into) the GraphElement.</para>
    /// </summary>
    public event Action RaiseRequest
    {
        add => Connect(SignalName.RaiseRequest, Callable.From(value));
        remove => Disconnect(SignalName.RaiseRequest, Callable.From(value));
    }

    protected void EmitSignalRaiseRequest()
    {
        EmitSignal(SignalName.RaiseRequest);
    }

    /// <summary>
    /// <para>Emitted when removing the GraphElement is requested.</para>
    /// </summary>
    public event Action DeleteRequest
    {
        add => Connect(SignalName.DeleteRequest, Callable.From(value));
        remove => Disconnect(SignalName.DeleteRequest, Callable.From(value));
    }

    protected void EmitSignalDeleteRequest()
    {
        EmitSignal(SignalName.DeleteRequest);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.GraphElement.ResizeRequest"/> event of a <see cref="Godot.GraphElement"/> class.
    /// </summary>
    public delegate void ResizeRequestEventHandler(Vector2 newSize);

    private static void ResizeRequestTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((ResizeRequestEventHandler)delegateObj)(VariantUtils.ConvertTo<Vector2>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when resizing the GraphElement is requested. Happens on dragging the resizer handle (see <see cref="Godot.GraphElement.Resizable"/>).</para>
    /// </summary>
    public unsafe event ResizeRequestEventHandler ResizeRequest
    {
        add => Connect(SignalName.ResizeRequest, Callable.CreateWithUnsafeTrampoline(value, &ResizeRequestTrampoline));
        remove => Disconnect(SignalName.ResizeRequest, Callable.CreateWithUnsafeTrampoline(value, &ResizeRequestTrampoline));
    }

    protected void EmitSignalResizeRequest(Vector2 newSize)
    {
        EmitSignal(SignalName.ResizeRequest, newSize);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.GraphElement.ResizeEnd"/> event of a <see cref="Godot.GraphElement"/> class.
    /// </summary>
    public delegate void ResizeEndEventHandler(Vector2 newSize);

    private static void ResizeEndTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((ResizeEndEventHandler)delegateObj)(VariantUtils.ConvertTo<Vector2>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when releasing the mouse button after dragging the resizer handle (see <see cref="Godot.GraphElement.Resizable"/>).</para>
    /// </summary>
    public unsafe event ResizeEndEventHandler ResizeEnd
    {
        add => Connect(SignalName.ResizeEnd, Callable.CreateWithUnsafeTrampoline(value, &ResizeEndTrampoline));
        remove => Disconnect(SignalName.ResizeEnd, Callable.CreateWithUnsafeTrampoline(value, &ResizeEndTrampoline));
    }

    protected void EmitSignalResizeEnd(Vector2 newSize)
    {
        EmitSignal(SignalName.ResizeEnd, newSize);
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.GraphElement.Dragged"/> event of a <see cref="Godot.GraphElement"/> class.
    /// </summary>
    public delegate void DraggedEventHandler(Vector2 from, Vector2 to);

    private static void DraggedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 2);
        ((DraggedEventHandler)delegateObj)(VariantUtils.ConvertTo<Vector2>(args[0]), VariantUtils.ConvertTo<Vector2>(args[1]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when the GraphElement is dragged.</para>
    /// </summary>
    public unsafe event DraggedEventHandler Dragged
    {
        add => Connect(SignalName.Dragged, Callable.CreateWithUnsafeTrampoline(value, &DraggedTrampoline));
        remove => Disconnect(SignalName.Dragged, Callable.CreateWithUnsafeTrampoline(value, &DraggedTrampoline));
    }

    protected void EmitSignalDragged(Vector2 from, Vector2 to)
    {
        EmitSignal(SignalName.Dragged, from, to);
    }

    /// <summary>
    /// <para>Emitted when the GraphElement is moved.</para>
    /// </summary>
    public event Action PositionOffsetChanged
    {
        add => Connect(SignalName.PositionOffsetChanged, Callable.From(value));
        remove => Disconnect(SignalName.PositionOffsetChanged, Callable.From(value));
    }

    protected void EmitSignalPositionOffsetChanged()
    {
        EmitSignal(SignalName.PositionOffsetChanged);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_node_selected = "NodeSelected";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_node_deselected = "NodeDeselected";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_raise_request = "RaiseRequest";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_delete_request = "DeleteRequest";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_resize_request = "ResizeRequest";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_resize_end = "ResizeEnd";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_dragged = "Dragged";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_position_offset_changed = "PositionOffsetChanged";

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
        if (signal == SignalName.RaiseRequest)
        {
            if (HasGodotClassSignal(SignalProxyName_raise_request.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.DeleteRequest)
        {
            if (HasGodotClassSignal(SignalProxyName_delete_request.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.ResizeRequest)
        {
            if (HasGodotClassSignal(SignalProxyName_resize_request.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.ResizeEnd)
        {
            if (HasGodotClassSignal(SignalProxyName_resize_end.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.Dragged)
        {
            if (HasGodotClassSignal(SignalProxyName_dragged.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.PositionOffsetChanged)
        {
            if (HasGodotClassSignal(SignalProxyName_position_offset_changed.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        return base.HasGodotClassSignal(signal);
    }

    /// <summary>
    /// Cached StringNames for the properties and fields contained in this class, for fast lookup.
    /// </summary>
    public new class PropertyName : Container.PropertyName
    {
        /// <summary>
        /// Cached name for the 'position_offset' property.
        /// </summary>
        public static readonly StringName PositionOffset = "position_offset";
        /// <summary>
        /// Cached name for the 'resizable' property.
        /// </summary>
        public static readonly StringName Resizable = "resizable";
        /// <summary>
        /// Cached name for the 'draggable' property.
        /// </summary>
        public static readonly StringName Draggable = "draggable";
        /// <summary>
        /// Cached name for the 'selectable' property.
        /// </summary>
        public static readonly StringName Selectable = "selectable";
        /// <summary>
        /// Cached name for the 'selected' property.
        /// </summary>
        public static readonly StringName Selected = "selected";
        /// <summary>
        /// Cached name for the 'scaling_menus' property.
        /// </summary>
        public static readonly StringName ScalingMenus = "scaling_menus";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Container.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_resizable' method.
        /// </summary>
        public static readonly StringName SetResizable = "set_resizable";
        /// <summary>
        /// Cached name for the 'is_resizable' method.
        /// </summary>
        public static readonly StringName IsResizable = "is_resizable";
        /// <summary>
        /// Cached name for the 'set_draggable' method.
        /// </summary>
        public static readonly StringName SetDraggable = "set_draggable";
        /// <summary>
        /// Cached name for the 'is_draggable' method.
        /// </summary>
        public static readonly StringName IsDraggable = "is_draggable";
        /// <summary>
        /// Cached name for the 'set_selectable' method.
        /// </summary>
        public static readonly StringName SetSelectable = "set_selectable";
        /// <summary>
        /// Cached name for the 'is_selectable' method.
        /// </summary>
        public static readonly StringName IsSelectable = "is_selectable";
        /// <summary>
        /// Cached name for the 'set_selected' method.
        /// </summary>
        public static readonly StringName SetSelected = "set_selected";
        /// <summary>
        /// Cached name for the 'is_selected' method.
        /// </summary>
        public static readonly StringName IsSelected = "is_selected";
        /// <summary>
        /// Cached name for the 'set_scaling_menus' method.
        /// </summary>
        public static readonly StringName SetScalingMenus = "set_scaling_menus";
        /// <summary>
        /// Cached name for the 'is_scaling_menus' method.
        /// </summary>
        public static readonly StringName IsScalingMenus = "is_scaling_menus";
        /// <summary>
        /// Cached name for the 'set_position_offset' method.
        /// </summary>
        public static readonly StringName SetPositionOffset = "set_position_offset";
        /// <summary>
        /// Cached name for the 'get_position_offset' method.
        /// </summary>
        public static readonly StringName GetPositionOffset = "get_position_offset";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Container.SignalName
    {
        /// <summary>
        /// Cached name for the 'node_selected' signal.
        /// </summary>
        public static readonly StringName NodeSelected = "node_selected";
        /// <summary>
        /// Cached name for the 'node_deselected' signal.
        /// </summary>
        public static readonly StringName NodeDeselected = "node_deselected";
        /// <summary>
        /// Cached name for the 'raise_request' signal.
        /// </summary>
        public static readonly StringName RaiseRequest = "raise_request";
        /// <summary>
        /// Cached name for the 'delete_request' signal.
        /// </summary>
        public static readonly StringName DeleteRequest = "delete_request";
        /// <summary>
        /// Cached name for the 'resize_request' signal.
        /// </summary>
        public static readonly StringName ResizeRequest = "resize_request";
        /// <summary>
        /// Cached name for the 'resize_end' signal.
        /// </summary>
        public static readonly StringName ResizeEnd = "resize_end";
        /// <summary>
        /// Cached name for the 'dragged' signal.
        /// </summary>
        public static readonly StringName Dragged = "dragged";
        /// <summary>
        /// Cached name for the 'position_offset_changed' signal.
        /// </summary>
        public static readonly StringName PositionOffsetChanged = "position_offset_changed";
    }
}
