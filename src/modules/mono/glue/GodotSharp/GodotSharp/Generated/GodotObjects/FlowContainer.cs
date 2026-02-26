namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A container that arranges its child controls horizontally or vertically and wraps them around at the borders. This is similar to how text in a book wraps around when no more words can fit on a line.</para>
/// </summary>
public partial class FlowContainer : Container
{
    public enum AlignmentMode : long
    {
        /// <summary>
        /// <para>The child controls will be arranged at the beginning of the container, i.e. top if orientation is vertical, left if orientation is horizontal (right for RTL layout).</para>
        /// </summary>
        Begin = 0,
        /// <summary>
        /// <para>The child controls will be centered in the container.</para>
        /// </summary>
        Center = 1,
        /// <summary>
        /// <para>The child controls will be arranged at the end of the container, i.e. bottom if orientation is vertical, right if orientation is horizontal (left for RTL layout).</para>
        /// </summary>
        End = 2
    }

    public enum LastWrapAlignmentMode : long
    {
        /// <summary>
        /// <para>The last partially filled row or column will wrap aligned to the previous row or column in accordance with <see cref="Godot.FlowContainer.Alignment"/>.</para>
        /// </summary>
        Inherit = 0,
        /// <summary>
        /// <para>The last partially filled row or column will wrap aligned to the beginning of the previous row or column.</para>
        /// </summary>
        Begin = 1,
        /// <summary>
        /// <para>The last partially filled row or column will wrap aligned to the center of the previous row or column.</para>
        /// </summary>
        Center = 2,
        /// <summary>
        /// <para>The last partially filled row or column will wrap aligned to the end of the previous row or column.</para>
        /// </summary>
        End = 3
    }

    /// <summary>
    /// <para>The alignment of the container's children (must be one of <see cref="Godot.FlowContainer.AlignmentMode.Begin"/>, <see cref="Godot.FlowContainer.AlignmentMode.Center"/>, or <see cref="Godot.FlowContainer.AlignmentMode.End"/>).</para>
    /// </summary>
    public FlowContainer.AlignmentMode Alignment
    {
        get
        {
            return GetAlignment();
        }
        set
        {
            SetAlignment(value);
        }
    }

    /// <summary>
    /// <para>The wrap behavior of the last, partially filled row or column (must be one of <see cref="Godot.FlowContainer.LastWrapAlignmentMode.Inherit"/>, <see cref="Godot.FlowContainer.LastWrapAlignmentMode.Begin"/>, <see cref="Godot.FlowContainer.LastWrapAlignmentMode.Center"/>, or <see cref="Godot.FlowContainer.LastWrapAlignmentMode.End"/>).</para>
    /// </summary>
    public FlowContainer.LastWrapAlignmentMode LastWrapAlignment
    {
        get
        {
            return GetLastWrapAlignment();
        }
        set
        {
            SetLastWrapAlignment(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the <see cref="Godot.FlowContainer"/> will arrange its children vertically, rather than horizontally.</para>
    /// <para>Can't be changed when using <see cref="Godot.HFlowContainer"/> and <see cref="Godot.VFlowContainer"/>.</para>
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
    /// <para>If <see langword="true"/>, reverses fill direction. Horizontal <see cref="Godot.FlowContainer"/>s will fill rows bottom to top, vertical <see cref="Godot.FlowContainer"/>s will fill columns right to left.</para>
    /// <para>When using a vertical <see cref="Godot.FlowContainer"/> with a right to left <see cref="Godot.Control.LayoutDirection"/>, columns will fill left to right instead.</para>
    /// </summary>
    public bool ReverseFill
    {
        get
        {
            return IsReverseFill();
        }
        set
        {
            SetReverseFill(value);
        }
    }

    private static readonly System.Type CachedType = typeof(FlowContainer);

    private static readonly StringName NativeName = "FlowContainer";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public FlowContainer() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal FlowContainer(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal FlowContainer(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLineCount, 3905245786ul);

    /// <summary>
    /// <para>Returns the current line count.</para>
    /// </summary>
    public int GetLineCount()
    {
        return NativeCalls.godot_icall_0_39(MethodBind0, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAlignment, 575250951ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAlignment(FlowContainer.AlignmentMode alignment)
    {
        NativeCalls.godot_icall_1_38(MethodBind1, GodotObject.GetPtr(this), (int)alignment);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAlignment, 3749743559ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public FlowContainer.AlignmentMode GetAlignment()
    {
        return (FlowContainer.AlignmentMode)NativeCalls.godot_icall_0_39(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetLastWrapAlignment, 2899697495ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetLastWrapAlignment(FlowContainer.LastWrapAlignmentMode lastWrapAlignment)
    {
        NativeCalls.godot_icall_1_38(MethodBind3, GodotObject.GetPtr(this), (int)lastWrapAlignment);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetLastWrapAlignment, 3743456014ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public FlowContainer.LastWrapAlignmentMode GetLastWrapAlignment()
    {
        return (FlowContainer.LastWrapAlignmentMode)NativeCalls.godot_icall_0_39(MethodBind4, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVertical, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetVertical(bool vertical)
    {
        NativeCalls.godot_icall_1_14(MethodBind5, GodotObject.GetPtr(this), vertical.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsVertical, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsVertical()
    {
        return NativeCalls.godot_icall_0_15(MethodBind6, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetReverseFill, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetReverseFill(bool reverseFill)
    {
        NativeCalls.godot_icall_1_14(MethodBind7, GodotObject.GetPtr(this), reverseFill.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsReverseFill, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsReverseFill()
    {
        return NativeCalls.godot_icall_0_15(MethodBind8, GodotObject.GetPtr(this)).ToBool();
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
    public new class PropertyName : Container.PropertyName
    {
        /// <summary>
        /// Cached name for the 'alignment' property.
        /// </summary>
        public static readonly StringName Alignment = "alignment";
        /// <summary>
        /// Cached name for the 'last_wrap_alignment' property.
        /// </summary>
        public static readonly StringName LastWrapAlignment = "last_wrap_alignment";
        /// <summary>
        /// Cached name for the 'vertical' property.
        /// </summary>
        public static readonly StringName Vertical = "vertical";
        /// <summary>
        /// Cached name for the 'reverse_fill' property.
        /// </summary>
        public static readonly StringName ReverseFill = "reverse_fill";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Container.MethodName
    {
        /// <summary>
        /// Cached name for the 'get_line_count' method.
        /// </summary>
        public static readonly StringName GetLineCount = "get_line_count";
        /// <summary>
        /// Cached name for the 'set_alignment' method.
        /// </summary>
        public static readonly StringName SetAlignment = "set_alignment";
        /// <summary>
        /// Cached name for the 'get_alignment' method.
        /// </summary>
        public static readonly StringName GetAlignment = "get_alignment";
        /// <summary>
        /// Cached name for the 'set_last_wrap_alignment' method.
        /// </summary>
        public static readonly StringName SetLastWrapAlignment = "set_last_wrap_alignment";
        /// <summary>
        /// Cached name for the 'get_last_wrap_alignment' method.
        /// </summary>
        public static readonly StringName GetLastWrapAlignment = "get_last_wrap_alignment";
        /// <summary>
        /// Cached name for the 'set_vertical' method.
        /// </summary>
        public static readonly StringName SetVertical = "set_vertical";
        /// <summary>
        /// Cached name for the 'is_vertical' method.
        /// </summary>
        public static readonly StringName IsVertical = "is_vertical";
        /// <summary>
        /// Cached name for the 'set_reverse_fill' method.
        /// </summary>
        public static readonly StringName SetReverseFill = "set_reverse_fill";
        /// <summary>
        /// Cached name for the 'is_reverse_fill' method.
        /// </summary>
        public static readonly StringName IsReverseFill = "is_reverse_fill";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Container.SignalName
    {
    }
}
