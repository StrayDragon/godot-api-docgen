namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A container that arranges child controls horizontally or vertically and creates grabbers between them. The grabbers can be dragged around to change the size relations between the child controls.</para>
/// </summary>
public partial class SplitContainer : Container
{
    public enum DraggerVisibilityEnum : long
    {
        /// <summary>
        /// <para>The split dragger icon is always visible when <c>autohide</c> is <see langword="false"/>, otherwise visible only when the cursor hovers it.</para>
        /// <para>The size of the grabber icon determines the minimum <c>separation</c>.</para>
        /// <para>The dragger icon is automatically hidden if the length of the grabber icon is longer than the split bar.</para>
        /// </summary>
        Visible = 0,
        /// <summary>
        /// <para>The split dragger icon is never visible regardless of the value of <c>autohide</c>.</para>
        /// <para>The size of the grabber icon determines the minimum <c>separation</c>.</para>
        /// </summary>
        Hidden = 1,
        /// <summary>
        /// <para>The split dragger icon is not visible, and the split bar is collapsed to zero thickness.</para>
        /// </summary>
        HiddenCollapsed = 2
    }

    /// <summary>
    /// <para>Offsets for each dragger in pixels. Each one is the offset of the split between the <see cref="Godot.Control"/> nodes before and after the dragger, with <c>0</c> being the default position. The default position is based on the <see cref="Godot.Control"/> nodes expand flags and minimum sizes. See <see cref="Godot.Control.SizeFlagsHorizontal"/>, <see cref="Godot.Control.SizeFlagsVertical"/>, and <see cref="Godot.Control.SizeFlagsStretchRatio"/>.</para>
    /// <para>If none of the <see cref="Godot.Control"/> nodes before the dragger are expanded, the default position will be at the start of the <see cref="Godot.SplitContainer"/>. If none of the <see cref="Godot.Control"/> nodes after the dragger are expanded, the default position will be at the end of the <see cref="Godot.SplitContainer"/>. If the dragger is in between expanded <see cref="Godot.Control"/> nodes, the default position will be in the middle, based on the <see cref="Godot.Control.SizeFlagsStretchRatio"/>s and minimum sizes.</para>
    /// <para><b>Note:</b> If the split offsets cause <see cref="Godot.Control"/> nodes to overlap, the first split will take priority when resolving the positions.</para>
    /// </summary>
    public int[] SplitOffsets
    {
        get
        {
            return GetSplitOffsets();
        }
        set
        {
            SetSplitOffsets(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the draggers will be disabled and the children will be sized as if all <see cref="Godot.SplitContainer.SplitOffsets"/> were <c>0</c>.</para>
    /// </summary>
    public bool Collapsed
    {
        get
        {
            return IsCollapsed();
        }
        set
        {
            SetCollapsed(value);
        }
    }

    /// <summary>
    /// <para>Enables or disables split dragging.</para>
    /// </summary>
    public bool DraggingEnabled
    {
        get
        {
            return IsDraggingEnabled();
        }
        set
        {
            SetDraggingEnabled(value);
        }
    }

    /// <summary>
    /// <para>Determines the dragger's visibility. This property does not determine whether dragging is enabled or not. Use <see cref="Godot.SplitContainer.DraggingEnabled"/> for that.</para>
    /// </summary>
    public SplitContainer.DraggerVisibilityEnum DraggerVisibility
    {
        get
        {
            return GetDraggerVisibility();
        }
        set
        {
            SetDraggerVisibility(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the <see cref="Godot.SplitContainer"/> will arrange its children vertically, rather than horizontally.</para>
    /// <para>Can't be changed when using <see cref="Godot.HSplitContainer"/> and <see cref="Godot.VSplitContainer"/>.</para>
    /// </summary>
    public bool Vertical
    {
        get
        {
            return IsVertical();
        }
        set
        {
            SetVertical(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, a touch-friendly drag handle will be enabled for better usability on smaller screens. Unlike the standard grabber, this drag handle overlaps the <see cref="Godot.SplitContainer"/>'s children and does not affect their minimum separation. The standard grabber will no longer be drawn when this option is enabled.</para>
    /// </summary>
    public bool TouchDraggerEnabled
    {
        get
        {
            return IsTouchDraggerEnabled();
        }
        set
        {
            SetTouchDraggerEnabled(value);
        }
    }

    /// <summary>
    /// <para>Reduces the size of the drag area and split bar <c>split_bar_background</c> at the beginning of the container.</para>
    /// </summary>
    public int DragAreaMarginBegin
    {
        get
        {
            return GetDragAreaMarginBegin();
        }
        set
        {
            SetDragAreaMarginBegin(value);
        }
    }

    /// <summary>
    /// <para>Reduces the size of the drag area and split bar <c>split_bar_background</c> at the end of the container.</para>
    /// </summary>
    public int DragAreaMarginEnd
    {
        get
        {
            return GetDragAreaMarginEnd();
        }
        set
        {
            SetDragAreaMarginEnd(value);
        }
    }

    /// <summary>
    /// <para>Shifts the drag area in the axis of the container to prevent the drag area from overlapping the <see cref="Godot.ScrollBar"/> or other selectable <see cref="Godot.Control"/> of a child node.</para>
    /// </summary>
    public int DragAreaOffset
    {
        get
        {
            return GetDragAreaOffset();
        }
        set
        {
            SetDragAreaOffset(value);
        }
    }

    /// <summary>
    /// <para>Highlights the drag area <see cref="Godot.Rect2"/> so you can see where it is during development. The drag area is gold if <see cref="Godot.SplitContainer.DraggingEnabled"/> is <see langword="true"/>, and red if <see langword="false"/>.</para>
    /// </summary>
    public bool DragAreaHighlightInEditor
    {
        get
        {
            return IsDragAreaHighlightInEditorEnabled();
        }
        set
        {
            SetDragAreaHighlightInEditor(value);
        }
    }

    /// <summary>
    /// <para>The first element of <see cref="Godot.SplitContainer.SplitOffsets"/>.</para>
    /// </summary>
    [Obsolete("Use 'Godot.SplitContainer.SplitOffsets' instead. The first element of the array is the split offset between the first two children.")]
    public int SplitOffset
    {
        get
        {
            return GetSplitOffset();
        }
        set
        {
            SetSplitOffset(value);
        }
    }

    private static readonly System.Type CachedType = typeof(SplitContainer);

    private static readonly StringName NativeName = "SplitContainer";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public SplitContainer() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal SplitContainer(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal SplitContainer(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSplitOffsets, 3614634198ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSplitOffsets(int[] offsets)
    {
        NativeCalls.godot_icall_1_150(MethodBind0, GodotObject.GetPtr(this), offsets);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSplitOffsets(ReadOnlySpan<int> offsets)
    {
        NativeCalls.godot_icall_1_150(MethodBind0, GodotObject.GetPtr(this), offsets);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSplitOffsets, 1930428628ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int[] GetSplitOffsets()
    {
        return NativeCalls.godot_icall_0_151(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ClampSplitOffset, 1995695955ul);

    /// <summary>
    /// <para>Clamps the <see cref="Godot.SplitContainer.SplitOffsets"/> values to ensure they are within valid ranges and do not overlap with each other. When overlaps occur, this method prioritizes one split offset (at index <paramref name="priorityIndex"/>) by clamping any overlapping split offsets to it.</para>
    /// </summary>
    public void ClampSplitOffset(int priorityIndex = 0)
    {
        NativeCalls.godot_icall_1_38(MethodBind2, GodotObject.GetPtr(this), priorityIndex);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCollapsed, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCollapsed(bool collapsed)
    {
        NativeCalls.godot_icall_1_14(MethodBind3, GodotObject.GetPtr(this), collapsed.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsCollapsed, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsCollapsed()
    {
        return NativeCalls.godot_icall_0_15(MethodBind4, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDraggerVisibility, 1168273952ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDraggerVisibility(SplitContainer.DraggerVisibilityEnum mode)
    {
        NativeCalls.godot_icall_1_38(MethodBind5, GodotObject.GetPtr(this), (int)mode);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDraggerVisibility, 967297479ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public SplitContainer.DraggerVisibilityEnum GetDraggerVisibility()
    {
        return (SplitContainer.DraggerVisibilityEnum)NativeCalls.godot_icall_0_39(MethodBind6, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVertical, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetVertical(bool vertical)
    {
        NativeCalls.godot_icall_1_14(MethodBind7, GodotObject.GetPtr(this), vertical.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsVertical, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsVertical()
    {
        return NativeCalls.godot_icall_0_15(MethodBind8, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDraggingEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDraggingEnabled(bool draggingEnabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind9, GodotObject.GetPtr(this), draggingEnabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsDraggingEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsDraggingEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind10, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDragAreaMarginBegin, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDragAreaMarginBegin(int margin)
    {
        NativeCalls.godot_icall_1_38(MethodBind11, GodotObject.GetPtr(this), margin);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDragAreaMarginBegin, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetDragAreaMarginBegin()
    {
        return NativeCalls.godot_icall_0_39(MethodBind12, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDragAreaMarginEnd, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDragAreaMarginEnd(int margin)
    {
        NativeCalls.godot_icall_1_38(MethodBind13, GodotObject.GetPtr(this), margin);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind14 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDragAreaMarginEnd, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetDragAreaMarginEnd()
    {
        return NativeCalls.godot_icall_0_39(MethodBind14, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind15 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDragAreaOffset, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDragAreaOffset(int offset)
    {
        NativeCalls.godot_icall_1_38(MethodBind15, GodotObject.GetPtr(this), offset);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind16 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDragAreaOffset, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetDragAreaOffset()
    {
        return NativeCalls.godot_icall_0_39(MethodBind16, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind17 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetDragAreaHighlightInEditor, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetDragAreaHighlightInEditor(bool dragAreaHighlightInEditor)
    {
        NativeCalls.godot_icall_1_14(MethodBind17, GodotObject.GetPtr(this), dragAreaHighlightInEditor.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind18 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsDragAreaHighlightInEditorEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsDragAreaHighlightInEditorEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind18, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind19 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDragAreaControls, 2915620761ul);

    /// <summary>
    /// <para>Returns an <see cref="Godot.Collections.Array"/> of the drag area <see cref="Godot.Control"/>s. These are the interactable <see cref="Godot.Control"/> nodes between each child. For example, this can be used to add a pre-configured button to a drag area <see cref="Godot.Control"/> so that it rides along with the split bar. Try setting the <see cref="Godot.Button"/> anchors to <c>center</c> prior to the <see cref="Godot.Node.Reparent(Node, bool)"/> call.</para>
    /// <para><code>
    /// $BarnacleButton.reparent($SplitContainer.get_drag_area_controls()[0])
    /// </code></para>
    /// <para><b>Note:</b> The drag area <see cref="Godot.Control"/>s are drawn over the <see cref="Godot.SplitContainer"/>'s children, so <see cref="Godot.CanvasItem"/> draw objects called from a drag area and children added to it will also appear over the <see cref="Godot.SplitContainer"/>'s children. Try setting <see cref="Godot.Control.MouseFilter"/> of custom children to <see cref="Godot.Control.MouseFilterEnum.Ignore"/> to prevent blocking the mouse from dragging if desired.</para>
    /// <para><b>Warning:</b> These are required internal nodes, removing or freeing them may cause a crash.</para>
    /// </summary>
    public Godot.Collections.Array<Control> GetDragAreaControls()
    {
        return new Godot.Collections.Array<Control>(NativeCalls.godot_icall_0_120(MethodBind19, GodotObject.GetPtr(this)));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind20 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetTouchDraggerEnabled, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetTouchDraggerEnabled(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind20, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind21 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsTouchDraggerEnabled, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsTouchDraggerEnabled()
    {
        return NativeCalls.godot_icall_0_15(MethodBind21, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind22 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetDragAreaControl, 829782337ul);

    /// <summary>
    /// <para>Returns the drag area <see cref="Godot.Control"/>. For example, you can move a pre-configured button into the drag area <see cref="Godot.Control"/> so that it rides along with the split bar. Try setting the <see cref="Godot.Button"/> anchors to <c>center</c> prior to the <c>reparent()</c> call.</para>
    /// <para><code>
    /// $BarnacleButton.reparent($SplitContainer.get_drag_area_control())
    /// </code></para>
    /// <para><b>Note:</b> The drag area <see cref="Godot.Control"/> is drawn over the <see cref="Godot.SplitContainer"/>'s children, so <see cref="Godot.CanvasItem"/> draw objects called from the <see cref="Godot.Control"/> and children added to the <see cref="Godot.Control"/> will also appear over the <see cref="Godot.SplitContainer"/>'s children. Try setting <see cref="Godot.Control.MouseFilter"/> of custom children to <see cref="Godot.Control.MouseFilterEnum.Ignore"/> to prevent blocking the mouse from dragging if desired.</para>
    /// <para><b>Warning:</b> This is a required internal node, removing and freeing it may cause a crash.</para>
    /// </summary>
    [Obsolete("Use the first element of 'Godot.SplitContainer.GetDragAreaControls()' instead.")]
    public Control GetDragAreaControl()
    {
        return (Control)NativeCalls.godot_icall_0_53(MethodBind22, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind23 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetSplitOffset, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetSplitOffset(int offset)
    {
        NativeCalls.godot_icall_1_38(MethodBind23, GodotObject.GetPtr(this), offset);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind24 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetSplitOffset, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetSplitOffset()
    {
        return NativeCalls.godot_icall_0_39(MethodBind24, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind25 = ClassDB_get_method_with_compatibility(NativeName, MethodName.ClampSplitOffset, 3218959716ul);

    /// <summary>
    /// <para>Clamps the <see cref="Godot.SplitContainer.SplitOffsets"/> values to ensure they are within valid ranges and do not overlap with each other. When overlaps occur, this method prioritizes one split offset (at index <paramref name="priorityIndex"/>) by clamping any overlapping split offsets to it.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void ClampSplitOffset()
    {
        NativeCalls.godot_icall_0_3(MethodBind25, GodotObject.GetPtr(this));
    }

    /// <summary>
    /// Represents the method that handles the <see cref="Godot.SplitContainer.Dragged"/> event of a <see cref="Godot.SplitContainer"/> class.
    /// </summary>
    public delegate void DraggedEventHandler(long offset);

    private static void DraggedTrampoline(object delegateObj, NativeVariantPtrArgs args, out godot_variant ret)
    {
        Callable.ThrowIfArgCountMismatch(args, 1);
        ((DraggedEventHandler)delegateObj)(VariantUtils.ConvertTo<long>(args[0]));
        ret = default;
    }

    /// <summary>
    /// <para>Emitted when any dragger is dragged by user.</para>
    /// </summary>
    public unsafe event DraggedEventHandler Dragged
    {
        add => Connect(SignalName.Dragged, Callable.CreateWithUnsafeTrampoline(value, &DraggedTrampoline));
        remove => Disconnect(SignalName.Dragged, Callable.CreateWithUnsafeTrampoline(value, &DraggedTrampoline));
    }

    protected void EmitSignalDragged(long offset)
    {
        EmitSignal(SignalName.Dragged, offset);
    }

    /// <summary>
    /// <para>Emitted when the user starts dragging.</para>
    /// </summary>
    public event Action DragStarted
    {
        add => Connect(SignalName.DragStarted, Callable.From(value));
        remove => Disconnect(SignalName.DragStarted, Callable.From(value));
    }

    protected void EmitSignalDragStarted()
    {
        EmitSignal(SignalName.DragStarted);
    }

    /// <summary>
    /// <para>Emitted when the user ends dragging.</para>
    /// </summary>
    public event Action DragEnded
    {
        add => Connect(SignalName.DragEnded, Callable.From(value));
        remove => Disconnect(SignalName.DragEnded, Callable.From(value));
    }

    protected void EmitSignalDragEnded()
    {
        EmitSignal(SignalName.DragEnded);
    }

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_dragged = "Dragged";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_drag_started = "DragStarted";

    // ReSharper disable once InconsistentNaming
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly StringName SignalProxyName_drag_ended = "DragEnded";

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
        if (signal == SignalName.Dragged)
        {
            if (HasGodotClassSignal(SignalProxyName_dragged.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.DragStarted)
        {
            if (HasGodotClassSignal(SignalProxyName_drag_started.NativeValue.DangerousSelfRef))
            {
                return true;
            }
        }
        if (signal == SignalName.DragEnded)
        {
            if (HasGodotClassSignal(SignalProxyName_drag_ended.NativeValue.DangerousSelfRef))
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
        /// Cached name for the 'split_offsets' property.
        /// </summary>
        public static readonly StringName SplitOffsets = "split_offsets";
        /// <summary>
        /// Cached name for the 'collapsed' property.
        /// </summary>
        public static readonly StringName Collapsed = "collapsed";
        /// <summary>
        /// Cached name for the 'dragging_enabled' property.
        /// </summary>
        public static readonly StringName DraggingEnabled = "dragging_enabled";
        /// <summary>
        /// Cached name for the 'dragger_visibility' property.
        /// </summary>
        public static readonly StringName DraggerVisibility = "dragger_visibility";
        /// <summary>
        /// Cached name for the 'vertical' property.
        /// </summary>
        public static readonly StringName Vertical = "vertical";
        /// <summary>
        /// Cached name for the 'touch_dragger_enabled' property.
        /// </summary>
        public static readonly StringName TouchDraggerEnabled = "touch_dragger_enabled";
        /// <summary>
        /// Cached name for the 'drag_area_margin_begin' property.
        /// </summary>
        public static readonly StringName DragAreaMarginBegin = "drag_area_margin_begin";
        /// <summary>
        /// Cached name for the 'drag_area_margin_end' property.
        /// </summary>
        public static readonly StringName DragAreaMarginEnd = "drag_area_margin_end";
        /// <summary>
        /// Cached name for the 'drag_area_offset' property.
        /// </summary>
        public static readonly StringName DragAreaOffset = "drag_area_offset";
        /// <summary>
        /// Cached name for the 'drag_area_highlight_in_editor' property.
        /// </summary>
        public static readonly StringName DragAreaHighlightInEditor = "drag_area_highlight_in_editor";
        /// <summary>
        /// Cached name for the 'split_offset' property.
        /// </summary>
        public static readonly StringName SplitOffset = "split_offset";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Container.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_split_offsets' method.
        /// </summary>
        public static readonly StringName SetSplitOffsets = "set_split_offsets";
        /// <summary>
        /// Cached name for the 'get_split_offsets' method.
        /// </summary>
        public static readonly StringName GetSplitOffsets = "get_split_offsets";
        /// <summary>
        /// Cached name for the 'clamp_split_offset' method.
        /// </summary>
        public static readonly StringName ClampSplitOffset = "clamp_split_offset";
        /// <summary>
        /// Cached name for the 'set_collapsed' method.
        /// </summary>
        public static readonly StringName SetCollapsed = "set_collapsed";
        /// <summary>
        /// Cached name for the 'is_collapsed' method.
        /// </summary>
        public static readonly StringName IsCollapsed = "is_collapsed";
        /// <summary>
        /// Cached name for the 'set_dragger_visibility' method.
        /// </summary>
        public static readonly StringName SetDraggerVisibility = "set_dragger_visibility";
        /// <summary>
        /// Cached name for the 'get_dragger_visibility' method.
        /// </summary>
        public static readonly StringName GetDraggerVisibility = "get_dragger_visibility";
        /// <summary>
        /// Cached name for the 'set_vertical' method.
        /// </summary>
        public static readonly StringName SetVertical = "set_vertical";
        /// <summary>
        /// Cached name for the 'is_vertical' method.
        /// </summary>
        public static readonly StringName IsVertical = "is_vertical";
        /// <summary>
        /// Cached name for the 'set_dragging_enabled' method.
        /// </summary>
        public static readonly StringName SetDraggingEnabled = "set_dragging_enabled";
        /// <summary>
        /// Cached name for the 'is_dragging_enabled' method.
        /// </summary>
        public static readonly StringName IsDraggingEnabled = "is_dragging_enabled";
        /// <summary>
        /// Cached name for the 'set_drag_area_margin_begin' method.
        /// </summary>
        public static readonly StringName SetDragAreaMarginBegin = "set_drag_area_margin_begin";
        /// <summary>
        /// Cached name for the 'get_drag_area_margin_begin' method.
        /// </summary>
        public static readonly StringName GetDragAreaMarginBegin = "get_drag_area_margin_begin";
        /// <summary>
        /// Cached name for the 'set_drag_area_margin_end' method.
        /// </summary>
        public static readonly StringName SetDragAreaMarginEnd = "set_drag_area_margin_end";
        /// <summary>
        /// Cached name for the 'get_drag_area_margin_end' method.
        /// </summary>
        public static readonly StringName GetDragAreaMarginEnd = "get_drag_area_margin_end";
        /// <summary>
        /// Cached name for the 'set_drag_area_offset' method.
        /// </summary>
        public static readonly StringName SetDragAreaOffset = "set_drag_area_offset";
        /// <summary>
        /// Cached name for the 'get_drag_area_offset' method.
        /// </summary>
        public static readonly StringName GetDragAreaOffset = "get_drag_area_offset";
        /// <summary>
        /// Cached name for the 'set_drag_area_highlight_in_editor' method.
        /// </summary>
        public static readonly StringName SetDragAreaHighlightInEditor = "set_drag_area_highlight_in_editor";
        /// <summary>
        /// Cached name for the 'is_drag_area_highlight_in_editor_enabled' method.
        /// </summary>
        public static readonly StringName IsDragAreaHighlightInEditorEnabled = "is_drag_area_highlight_in_editor_enabled";
        /// <summary>
        /// Cached name for the 'get_drag_area_controls' method.
        /// </summary>
        public static readonly StringName GetDragAreaControls = "get_drag_area_controls";
        /// <summary>
        /// Cached name for the 'set_touch_dragger_enabled' method.
        /// </summary>
        public static readonly StringName SetTouchDraggerEnabled = "set_touch_dragger_enabled";
        /// <summary>
        /// Cached name for the 'is_touch_dragger_enabled' method.
        /// </summary>
        public static readonly StringName IsTouchDraggerEnabled = "is_touch_dragger_enabled";
        /// <summary>
        /// Cached name for the 'get_drag_area_control' method.
        /// </summary>
        public static readonly StringName GetDragAreaControl = "get_drag_area_control";
        /// <summary>
        /// Cached name for the 'set_split_offset' method.
        /// </summary>
        public static readonly StringName SetSplitOffset = "set_split_offset";
        /// <summary>
        /// Cached name for the 'get_split_offset' method.
        /// </summary>
        public static readonly StringName GetSplitOffset = "get_split_offset";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Container.SignalName
    {
        /// <summary>
        /// Cached name for the 'dragged' signal.
        /// </summary>
        public static readonly StringName Dragged = "dragged";
        /// <summary>
        /// Cached name for the 'drag_started' signal.
        /// </summary>
        public static readonly StringName DragStarted = "drag_started";
        /// <summary>
        /// Cached name for the 'drag_ended' signal.
        /// </summary>
        public static readonly StringName DragEnded = "drag_ended";
    }
}
