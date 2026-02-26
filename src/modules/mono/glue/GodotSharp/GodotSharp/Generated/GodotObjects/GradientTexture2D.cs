namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A 2D texture that obtains colors from a <see cref="Godot.Gradient"/> to fill the texture data. This texture is able to transform a color transition into different patterns such as a linear or a radial gradient. The texture is filled by interpolating colors starting from <see cref="Godot.GradientTexture2D.FillFrom"/> to <see cref="Godot.GradientTexture2D.FillTo"/> offsets by default, but the gradient fill can be repeated to cover the entire texture.</para>
/// <para>The gradient is sampled individually for each pixel so it does not necessarily represent an exact copy of the gradient (see <see cref="Godot.GradientTexture2D.Width"/> and <see cref="Godot.GradientTexture2D.Height"/>). See also <see cref="Godot.GradientTexture1D"/>, <see cref="Godot.CurveTexture"/> and <see cref="Godot.CurveXyzTexture"/>.</para>
/// </summary>
public partial class GradientTexture2D : Texture2D
{
    public enum FillEnum : long
    {
        /// <summary>
        /// <para>The colors are linearly interpolated in a straight line.</para>
        /// </summary>
        Linear = 0,
        /// <summary>
        /// <para>The colors are linearly interpolated in a circular pattern.</para>
        /// </summary>
        Radial = 1,
        /// <summary>
        /// <para>The colors are linearly interpolated in a square pattern.</para>
        /// </summary>
        Square = 2
    }

    public enum RepeatEnum : long
    {
        /// <summary>
        /// <para>The gradient fill is restricted to the range defined by <see cref="Godot.GradientTexture2D.FillFrom"/> to <see cref="Godot.GradientTexture2D.FillTo"/> offsets.</para>
        /// </summary>
        None = 0,
        /// <summary>
        /// <para>The texture is filled starting from <see cref="Godot.GradientTexture2D.FillFrom"/> to <see cref="Godot.GradientTexture2D.FillTo"/> offsets, repeating the same pattern in both directions.</para>
        /// </summary>
        Repeat = 1,
        /// <summary>
        /// <para>The texture is filled starting from <see cref="Godot.GradientTexture2D.FillFrom"/> to <see cref="Godot.GradientTexture2D.FillTo"/> offsets, mirroring the pattern in both directions.</para>
        /// </summary>
        Mirror = 2
    }

    /// <summary>
    /// <para>The <see cref="Godot.Gradient"/> used to fill the texture.</para>
    /// </summary>
    public Gradient Gradient
    {
        get
        {
            return GetGradient();
        }
        set
        {
            SetGradient(value);
        }
    }

    /// <summary>
    /// <para>The number of horizontal color samples that will be obtained from the <see cref="Godot.Gradient"/>, which also represents the texture's width.</para>
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
    /// <para>The number of vertical color samples that will be obtained from the <see cref="Godot.Gradient"/>, which also represents the texture's height.</para>
    /// </summary>
    public int Height
    {
        get
        {
            return GetHeight();
        }
        set
        {
            SetHeight(value);
        }
    }

    /// <summary>
    /// <para>If <see langword="true"/>, the generated texture will support high dynamic range (<see cref="Godot.Image.Format.Rgbaf"/> format). This allows for glow effects to work if <see cref="Godot.Environment.GlowEnabled"/> is <see langword="true"/>. If <see langword="false"/>, the generated texture will use low dynamic range; overbright colors will be clamped (<see cref="Godot.Image.Format.Rgba8"/> format).</para>
    /// </summary>
    public bool UseHdr
    {
        get
        {
            return IsUsingHdr();
        }
        set
        {
            SetUseHdr(value);
        }
    }

    /// <summary>
    /// <para>The gradient's fill type.</para>
    /// </summary>
    public GradientTexture2D.FillEnum Fill
    {
        get
        {
            return GetFill();
        }
        set
        {
            SetFill(value);
        }
    }

    /// <summary>
    /// <para>The initial offset used to fill the texture specified in UV coordinates.</para>
    /// </summary>
    public Vector2 FillFrom
    {
        get
        {
            return GetFillFrom();
        }
        set
        {
            SetFillFrom(value);
        }
    }

    /// <summary>
    /// <para>The final offset used to fill the texture specified in UV coordinates.</para>
    /// </summary>
    public Vector2 FillTo
    {
        get
        {
            return GetFillTo();
        }
        set
        {
            SetFillTo(value);
        }
    }

    /// <summary>
    /// <para>The gradient's repeat type.</para>
    /// </summary>
    public GradientTexture2D.RepeatEnum Repeat
    {
        get
        {
            return GetRepeat();
        }
        set
        {
            SetRepeat(value);
        }
    }

    private static readonly System.Type CachedType = typeof(GradientTexture2D);

    private static readonly StringName NativeName = "GradientTexture2D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public GradientTexture2D() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal GradientTexture2D(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal GradientTexture2D(bool memoryOwn) : base(memoryOwn) { }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind0 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetGradient, 2756054477ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetGradient(Gradient gradient)
    {
        NativeCalls.godot_icall_1_56(MethodBind0, GodotObject.GetPtr(this), GodotObject.GetPtr(gradient));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind1 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetGradient, 132272999ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Gradient GetGradient()
    {
        return (Gradient)NativeCalls.godot_icall_0_63(MethodBind1, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind2 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetWidth, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetWidth(int width)
    {
        NativeCalls.godot_icall_1_38(MethodBind2, GodotObject.GetPtr(this), width);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetHeight, 1286410249ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetHeight(int height)
    {
        NativeCalls.godot_icall_1_38(MethodBind3, GodotObject.GetPtr(this), height);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetUseHdr, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetUseHdr(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind4, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind5 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsUsingHdr, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsUsingHdr()
    {
        return NativeCalls.godot_icall_0_15(MethodBind5, GodotObject.GetPtr(this)).ToBool();
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind6 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFill, 3623927636ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetFill(GradientTexture2D.FillEnum fill)
    {
        NativeCalls.godot_icall_1_38(MethodBind6, GodotObject.GetPtr(this), (int)fill);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind7 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFill, 1876227217ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public GradientTexture2D.FillEnum GetFill()
    {
        return (GradientTexture2D.FillEnum)NativeCalls.godot_icall_0_39(MethodBind7, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind8 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFillFrom, 743155724ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetFillFrom(Vector2 fillFrom)
    {
        NativeCalls.godot_icall_1_36(MethodBind8, GodotObject.GetPtr(this), &fillFrom);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind9 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFillFrom, 3341600327ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2 GetFillFrom()
    {
        return NativeCalls.godot_icall_0_37(MethodBind9, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind10 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetFillTo, 743155724ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public unsafe void SetFillTo(Vector2 fillTo)
    {
        NativeCalls.godot_icall_1_36(MethodBind10, GodotObject.GetPtr(this), &fillTo);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind11 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetFillTo, 3341600327ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Vector2 GetFillTo()
    {
        return NativeCalls.godot_icall_0_37(MethodBind11, GodotObject.GetPtr(this));
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind12 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetRepeat, 1357597002ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetRepeat(GradientTexture2D.RepeatEnum repeat)
    {
        NativeCalls.godot_icall_1_38(MethodBind12, GodotObject.GetPtr(this), (int)repeat);
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind13 = ClassDB_get_method_with_compatibility(NativeName, MethodName.GetRepeat, 3351758665ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public GradientTexture2D.RepeatEnum GetRepeat()
    {
        return (GradientTexture2D.RepeatEnum)NativeCalls.godot_icall_0_39(MethodBind13, GodotObject.GetPtr(this));
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
        /// Cached name for the 'gradient' property.
        /// </summary>
        public static readonly StringName Gradient = "gradient";
        /// <summary>
        /// Cached name for the 'width' property.
        /// </summary>
        public static readonly StringName Width = "width";
        /// <summary>
        /// Cached name for the 'height' property.
        /// </summary>
        public static readonly StringName Height = "height";
        /// <summary>
        /// Cached name for the 'use_hdr' property.
        /// </summary>
        public static readonly StringName UseHdr = "use_hdr";
        /// <summary>
        /// Cached name for the 'fill' property.
        /// </summary>
        public static readonly StringName Fill = "fill";
        /// <summary>
        /// Cached name for the 'fill_from' property.
        /// </summary>
        public static readonly StringName FillFrom = "fill_from";
        /// <summary>
        /// Cached name for the 'fill_to' property.
        /// </summary>
        public static readonly StringName FillTo = "fill_to";
        /// <summary>
        /// Cached name for the 'repeat' property.
        /// </summary>
        public static readonly StringName Repeat = "repeat";
    }

    /// <summary>
    /// Cached StringNames for the methods contained in this class, for fast lookup.
    /// </summary>
    public new class MethodName : Texture2D.MethodName
    {
        /// <summary>
        /// Cached name for the 'set_gradient' method.
        /// </summary>
        public static readonly StringName SetGradient = "set_gradient";
        /// <summary>
        /// Cached name for the 'get_gradient' method.
        /// </summary>
        public static readonly StringName GetGradient = "get_gradient";
        /// <summary>
        /// Cached name for the 'set_width' method.
        /// </summary>
        public static readonly StringName SetWidth = "set_width";
        /// <summary>
        /// Cached name for the 'set_height' method.
        /// </summary>
        public static readonly StringName SetHeight = "set_height";
        /// <summary>
        /// Cached name for the 'set_use_hdr' method.
        /// </summary>
        public static readonly StringName SetUseHdr = "set_use_hdr";
        /// <summary>
        /// Cached name for the 'is_using_hdr' method.
        /// </summary>
        public static readonly StringName IsUsingHdr = "is_using_hdr";
        /// <summary>
        /// Cached name for the 'set_fill' method.
        /// </summary>
        public static readonly StringName SetFill = "set_fill";
        /// <summary>
        /// Cached name for the 'get_fill' method.
        /// </summary>
        public static readonly StringName GetFill = "get_fill";
        /// <summary>
        /// Cached name for the 'set_fill_from' method.
        /// </summary>
        public static readonly StringName SetFillFrom = "set_fill_from";
        /// <summary>
        /// Cached name for the 'get_fill_from' method.
        /// </summary>
        public static readonly StringName GetFillFrom = "get_fill_from";
        /// <summary>
        /// Cached name for the 'set_fill_to' method.
        /// </summary>
        public static readonly StringName SetFillTo = "set_fill_to";
        /// <summary>
        /// Cached name for the 'get_fill_to' method.
        /// </summary>
        public static readonly StringName GetFillTo = "get_fill_to";
        /// <summary>
        /// Cached name for the 'set_repeat' method.
        /// </summary>
        public static readonly StringName SetRepeat = "set_repeat";
        /// <summary>
        /// Cached name for the 'get_repeat' method.
        /// </summary>
        public static readonly StringName GetRepeat = "get_repeat";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Texture2D.SignalName
    {
    }
}
