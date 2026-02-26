namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A <see cref="Godot.StyleBox"/> that displays a single line of a given color and thickness. The line can be either horizontal or vertical. Useful for separators.</para>
/// </summary>
public partial class StyleBoxLine : StyleBox
{
    /// <summary>
    /// <para>The line's color.</para>
    /// </summary>
    public Color Color
    {
        get
        {
            return GetColor();
        }
        set
        {
            SetColor(value);
        }
    }

    /// <summary>
    /// <para>The number of pixels the line will extend before the <see cref="Godot.StyleBoxLine"/>'s bounds. If set to a negative value, the line will begin inside the <see cref="Godot.StyleBoxLine"/>'s bounds.</para>
    /// </summary>
    public float GrowBegin
    {
        get
        {
            return GetGrowBegin();
        }
        set
        {
            SetGrowBegin(value);
        }
    }

    /// <summary>
    /// <para>The number of pixels the line will extend past the <see cref="Godot.StyleBoxLine"/>'s bounds. If set to a negative value, the line will end inside the <see cref="Godot.StyleBoxLine"/>'s bounds.</para>
    /// </summary>
    public float GrowEnd
    {
        get
        {
            return GetGrowEnd();
        }
        set
        {
            SetGrowEnd(value);
        }
    }

    /// <summary>
    /// <para>The line's thickness in pixels.</para>
    /// </summary>
    public int Thickness
    {
        get
        {
            return GetThickness();
        }
        set
        {
            SetThickness(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the line will be vertical. If <see langword="false"/>, the line will be horizontal.</para>
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

    private static readonly System.Type CachedType = typeof(StyleBoxLine);

    private static readonly StringName NativeName = "StyleBoxLine";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public StyleBoxLine() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal StyleBoxLine(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal StyleBoxLine(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetColor, 2920490490ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetColor(Color color)
    {
        NativeCalls.godot_icall_1_213(MethodBind0, GodotObject.GetPtr(this), &color);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetColor, 3444240500ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Color GetColor()
    {
        return NativeCalls.godot_icall_0_214(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetThickness, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetThickness(int thickness)
    {
        NativeCalls.godot_icall_1_38(MethodBind2, GodotObject.GetPtr(this), thickness);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetThickness, 3905245786ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public int GetThickness()
    {
        return NativeCalls.godot_icall_0_39(MethodBind3, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetGrowBegin, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetGrowBegin(float offset)
    {
        NativeCalls.godot_icall_1_67(MethodBind4, GodotObject.GetPtr(this), offset);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetGrowBegin, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetGrowBegin()
    {
        return NativeCalls.godot_icall_0_68(MethodBind5, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetGrowEnd, 373806689ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetGrowEnd(float offset)
    {
        NativeCalls.godot_icall_1_67(MethodBind6, GodotObject.GetPtr(this), offset);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetGrowEnd, 1740695150ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float GetGrowEnd()
    {
        return NativeCalls.godot_icall_0_68(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetVertical, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetVertical(bool vertical)
    {
        NativeCalls.godot_icall_1_14(MethodBind8, GodotObject.GetPtr(this), vertical.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsVertical, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsVertical()
    {
        return NativeCalls.godot_icall_0_15(MethodBind9, GodotObject.GetPtr(this)).ToBool();
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
    public new class PropertyName : StyleBox.PropertyName
    {
        /// <summary>
        /// Cached name for the 'color' property.
        /// </summary>
        public static readonly StringName Color = "color";
        /// <summary>
        /// Cached name for the 'grow_begin' property.
        /// </summary>
        public static readonly StringName GrowBegin = "grow_begin";
        /// <summary>
        /// Cached name for the 'grow_end' property.
        /// </summary>
        public static readonly StringName GrowEnd = "grow_end";
        /// <summary>
        /// Cached name for the 'thickness' property.
        /// </summary>
        public static readonly StringName Thickness = "thickness";
        /// <summary>
        /// Cached name for the 'vertical' property.
        /// </summary>
        public static readonly StringName Vertical = "vertical";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : StyleBox.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_color' method.
        /// </summary>
        public static readonly StringName SetColor = "set_color";
        /// <summary>
        /// Cached name for the 'get_color' method.
        /// </summary>
        public static readonly StringName GetColor = "get_color";
        /// <summary>
        /// Cached name for the 'set_thickness' method.
        /// </summary>
        public static readonly StringName SetThickness = "set_thickness";
        /// <summary>
        /// Cached name for the 'get_thickness' method.
        /// </summary>
        public static readonly StringName GetThickness = "get_thickness";
        /// <summary>
        /// Cached name for the 'set_grow_begin' method.
        /// </summary>
        public static readonly StringName SetGrowBegin = "set_grow_begin";
        /// <summary>
        /// Cached name for the 'get_grow_begin' method.
        /// </summary>
        public static readonly StringName GetGrowBegin = "get_grow_begin";
        /// <summary>
        /// Cached name for the 'set_grow_end' method.
        /// </summary>
        public static readonly StringName SetGrowEnd = "set_grow_end";
        /// <summary>
        /// Cached name for the 'get_grow_end' method.
        /// </summary>
        public static readonly StringName GetGrowEnd = "get_grow_end";
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
    public new class SignalName : StyleBox.SignalName
    {
    }
}
