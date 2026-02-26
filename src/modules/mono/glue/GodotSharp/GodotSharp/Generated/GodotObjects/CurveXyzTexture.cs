namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A 1D texture where the red, green, and blue color channels correspond to points on 3 unit <see cref="Godot.Curve"/> resources. Compared to using separate <see cref="Godot.CurveTexture"/>s, this further simplifies the task of saving curves as image files.</para>
/// <para>If you only need to store one curve within a single texture, use <see cref="Godot.CurveTexture"/> instead. See also <see cref="Godot.GradientTexture1D"/> and <see cref="Godot.GradientTexture2D"/>.</para>
/// </summary>
[GodotClassName("CurveXYZTexture")]
public partial class CurveXyzTexture : Texture2D
{
    /// <summary>
    /// <para>The width of the texture (in pixels). Higher values make it possible to represent high-frequency data better (such as sudden direction changes), at the cost of increased generation time and memory usage.</para>
    /// </summary>
    public int Width
    {
        get
        {
            return GetWidth();
        }
        set
        {
            SetWidth(value);
        }
    }

    /// <summary>
    /// <para>The <see cref="Godot.Curve"/> that is rendered onto the texture's red channel. Should be a unit <see cref="Godot.Curve"/>.</para>
    /// </summary>
    public Curve CurveX
    {
        get
        {
            return GetCurveX();
        }
        set
        {
            SetCurveX(value);
        }
    }

    /// <summary>
    /// <para>The <see cref="Godot.Curve"/> that is rendered onto the texture's green channel. Should be a unit <see cref="Godot.Curve"/>.</para>
    /// </summary>
    public Curve CurveY
    {
        get
        {
            return GetCurveY();
        }
        set
        {
            SetCurveY(value);
        }
    }

    /// <summary>
    /// <para>The <see cref="Godot.Curve"/> that is rendered onto the texture's blue channel. Should be a unit <see cref="Godot.Curve"/>.</para>
    /// </summary>
    public Curve CurveZ
    {
        get
        {
            return GetCurveZ();
        }
        set
        {
            SetCurveZ(value);
        }
    }

    private static readonly System.Type CachedType = typeof(CurveXyzTexture);

    private static readonly StringName NativeName = "CurveXYZTexture";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public CurveXyzTexture() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal CurveXyzTexture(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal CurveXyzTexture(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetWidth, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetWidth(int width)
    {
        NativeCalls.godot_icall_1_38(MethodBind0, GodotObject.GetPtr(this), width);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCurveX, 270443179ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCurveX(Curve curve)
    {
        NativeCalls.godot_icall_1_56(MethodBind1, GodotObject.GetPtr(this), GodotObject.GetPtr(curve));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCurveX, 2460114913ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Curve GetCurveX()
    {
        return (Curve)NativeCalls.godot_icall_0_63(MethodBind2, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCurveY, 270443179ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCurveY(Curve curve)
    {
        NativeCalls.godot_icall_1_56(MethodBind3, GodotObject.GetPtr(this), GodotObject.GetPtr(curve));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCurveY, 2460114913ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Curve GetCurveY()
    {
        return (Curve)NativeCalls.godot_icall_0_63(MethodBind4, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetCurveZ, 270443179ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetCurveZ(Curve curve)
    {
        NativeCalls.godot_icall_1_56(MethodBind5, GodotObject.GetPtr(this), GodotObject.GetPtr(curve));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetCurveZ, 2460114913ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Curve GetCurveZ()
    {
        return (Curve)NativeCalls.godot_icall_0_63(MethodBind6, GodotObject.GetPtr(this));
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
    public new class PropertyName : Texture2D.PropertyName
    {
        /// <summary>
        /// Cached name for the 'width' property.
        /// </summary>
        public static readonly StringName Width = "width";
        /// <summary>
        /// Cached name for the 'curve_x' property.
        /// </summary>
        public static readonly StringName CurveX = "curve_x";
        /// <summary>
        /// Cached name for the 'curve_y' property.
        /// </summary>
        public static readonly StringName CurveY = "curve_y";
        /// <summary>
        /// Cached name for the 'curve_z' property.
        /// </summary>
        public static readonly StringName CurveZ = "curve_z";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Texture2D.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_width' method.
        /// </summary>
        public static readonly StringName SetWidth = "set_width";
        /// <summary>
        /// Cached name for the 'set_curve_x' method.
        /// </summary>
        public static readonly StringName SetCurveX = "set_curve_x";
        /// <summary>
        /// Cached name for the 'get_curve_x' method.
        /// </summary>
        public static readonly StringName GetCurveX = "get_curve_x";
        /// <summary>
        /// Cached name for the 'set_curve_y' method.
        /// </summary>
        public static readonly StringName SetCurveY = "set_curve_y";
        /// <summary>
        /// Cached name for the 'get_curve_y' method.
        /// </summary>
        public static readonly StringName GetCurveY = "get_curve_y";
        /// <summary>
        /// Cached name for the 'set_curve_z' method.
        /// </summary>
        public static readonly StringName SetCurveZ = "set_curve_z";
        /// <summary>
        /// Cached name for the 'get_curve_z' method.
        /// </summary>
        public static readonly StringName GetCurveZ = "get_curve_z";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Texture2D.SignalName
    {
    }
}
