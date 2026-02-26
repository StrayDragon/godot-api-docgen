namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A rectangular box that displays only a colored border around its rectangle (see <see cref="Godot.Control.GetRect()"/>). It can be used to visualize the extents of a <see cref="Godot.Control"/> node, for testing purposes.</para>
/// </summary>
public partial class ReferenceRect : Control
{
    /// <summary>
    /// <para>Sets the border color of the <see cref="Godot.ReferenceRect"/>.</para>
    /// </summary>
    public Color BorderColor
    {
        get
        {
            return GetBorderColor();
        }
        set
        {
            SetBorderColor(value);
        }
    }

    /// <summary>
    /// <para>Sets the border width of the <see cref="Godot.ReferenceRect"/>. The border grows both inwards and outwards with respect to the rectangle box.</para>
    /// </summary>
    public float BorderWidth
    {
        get
        {
            return GetBorderWidth();
        }
        set
        {
            SetBorderWidth(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the <see cref="Godot.ReferenceRect"/> will only be visible while in editor. Otherwise, <see cref="Godot.ReferenceRect"/> will be visible in the running project.</para>
    /// </summary>
    public bool EditorOnly
    {
        get
        {
            return GetEditorOnly();
        }
        set
        {
            SetEditorOnly(value);
        }
    }

    private static readonly System.Type CachedType = typeof(ReferenceRect);

    private static readonly StringName NativeName = "ReferenceRect";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public ReferenceRect() : this(false)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: false);
        }
    }

    internal ReferenceRect(IntPtr ptr) : this(false)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: false);
        }
    }

    internal ReferenceRect(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBorderColor, 3444240500ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Color GetBorderColor()
    {
        return NativeCalls.godot_icall_0_214(MethodBind0, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBorderColor, 2920490490ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetBorderColor(Color color)
    {
        NativeCalls.godot_icall_1_213(MethodBind1, GodotObject.GetPtr(this), &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetBorderWidth, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetBorderWidth()
    {
        return NativeCalls.godot_icall_0_68(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetBorderWidth, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetBorderWidth(float width)
    {
        NativeCalls.godot_icall_1_67(MethodBind3, GodotObject.GetPtr(this), width);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetEditorOnly, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool GetEditorOnly()
    {
        return NativeCalls.godot_icall_0_15(MethodBind4, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetEditorOnly, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetEditorOnly(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind5, GodotObject.GetPtr(this), enabled.ToGodotBool());
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
    public new class PropertyName : Control.PropertyName
    {
        /// <summary>
        /// Cached name for the 'border_color' property.
        /// </summary>
        public static readonly StringName BorderColor = "border_color";
        /// <summary>
        /// Cached name for the 'border_width' property.
        /// </summary>
        public static readonly StringName BorderWidth = "border_width";
        /// <summary>
        /// Cached name for the 'editor_only' property.
        /// </summary>
        public static readonly StringName EditorOnly = "editor_only";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Control.MethodName
    {
        /// <summary>
        /// Cached name for the 'get_border_color' method.
        /// </summary>
        public static readonly StringName GetBorderColor = "get_border_color";
        /// <summary>
        /// Cached name for the 'set_border_color' method.
        /// </summary>
        public static readonly StringName SetBorderColor = "set_border_color";
        /// <summary>
        /// Cached name for the 'get_border_width' method.
        /// </summary>
        public static readonly StringName GetBorderWidth = "get_border_width";
        /// <summary>
        /// Cached name for the 'set_border_width' method.
        /// </summary>
        public static readonly StringName SetBorderWidth = "set_border_width";
        /// <summary>
        /// Cached name for the 'get_editor_only' method.
        /// </summary>
        public static readonly StringName GetEditorOnly = "get_editor_only";
        /// <summary>
        /// Cached name for the 'set_editor_only' method.
        /// </summary>
        public static readonly StringName SetEditorOnly = "set_editor_only";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Control.SignalName
    {
    }
}
