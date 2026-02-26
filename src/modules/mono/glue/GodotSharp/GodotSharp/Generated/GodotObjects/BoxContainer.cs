namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A container that arranges its child controls horizontally or vertically, rearranging them automatically when their minimum size changes.</para>
/// </summary>
public partial class BoxContainer : Container
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

    /// <summary>
    /// <para>The alignment of the container's children (must be one of <see cref="Godot.BoxContainer.AlignmentMode.Begin"/>, <see cref="Godot.BoxContainer.AlignmentMode.Center"/>, or <see cref="Godot.BoxContainer.AlignmentMode.End"/>).</para>
    /// </summary>
    public BoxContainer.AlignmentMode Alignment
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
    /// <para>If <see langword="true"/>, the <see cref="Godot.BoxContainer"/> will arrange its children vertically, rather than horizontally.</para>
    /// <para>Can't be changed when using <see cref="Godot.HBoxContainer"/> and <see cref="Godot.VBoxContainer"/>.</para>
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

    private static readonly System.Type CachedType = typeof(BoxContainer);

    private static readonly StringName NativeName = "BoxContainer";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public BoxContainer() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal BoxContainer(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal BoxContainer(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.AddSpacer, 1326660695ul);

    /// <summary>
    /// <para>Adds a <see cref="Godot.Control"/> node to the box as a spacer. If <paramref name="begin"/> is <see langword="true"/>, it will insert the <see cref="Godot.Control"/> node in front of all other children.</para>
    /// </summary>
    public Control AddSpacer(bool begin)
    {
        return (Control)NativeCalls.godot_icall_1_223(MethodBind0, GodotObject.GetPtr(this), begin.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetAlignment, 2456745134ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetAlignment(BoxContainer.AlignmentMode alignment)
    {
        NativeCalls.godot_icall_1_38(MethodBind1, GodotObject.GetPtr(this), (int)alignment);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetAlignment, 1915476527ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public BoxContainer.AlignmentMode GetAlignment()
    {
        return (BoxContainer.AlignmentMode)NativeCalls.godot_icall_0_39(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVertical, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetVertical(bool vertical)
    {
        NativeCalls.godot_icall_1_14(MethodBind3, GodotObject.GetPtr(this), vertical.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsVertical, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsVertical()
    {
        return NativeCalls.godot_icall_0_15(MethodBind4, GodotObject.GetPtr(this)).ToBool();
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
        /// Cached name for the 'vertical' property.
        /// </summary>
        public static readonly StringName Vertical = "vertical";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Container.MethodName
    {
        /// <summary>
        /// Cached name for the 'add_spacer' method.
        /// </summary>
        public static readonly StringName AddSpacer = "add_spacer";
        /// <summary>
        /// Cached name for the 'set_alignment' method.
        /// </summary>
        public static readonly StringName SetAlignment = "set_alignment";
        /// <summary>
        /// Cached name for the 'get_alignment' method.
        /// </summary>
        public static readonly StringName GetAlignment = "get_alignment";
        /// <summary>
        /// Cached name for the 'set_vertical' method.
        /// </summary>
        public static readonly StringName SetVertical = "set_vertical";
        /// <summary>
        /// Cached name for the 'is_vertical' method.
        /// </summary>
        public static readonly StringName IsVertical = "is_vertical";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Container.SignalName
    {
    }
}
