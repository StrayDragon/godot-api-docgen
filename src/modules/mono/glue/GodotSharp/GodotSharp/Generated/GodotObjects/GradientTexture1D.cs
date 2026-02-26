namespace Godot;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Godot.NativeInterop;

#nullable disable
/// <summary>
/// <para>A 1D texture that obtains colors from a <see cref="Godot.Gradient"/> to fill the texture data. The texture is filled by sampling the gradient for each pixel. Therefore, the texture does not necessarily represent an exact copy of the gradient, as it may miss some colors if there are not enough pixels. See also <see cref="Godot.GradientTexture2D"/>, <see cref="Godot.CurveTexture"/> and <see cref="Godot.CurveXyzTexture"/>.</para>
/// </summary>
public partial class GradientTexture1D : Texture2D
{
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
    /// <para>The number of color samples that will be obtained from the <see cref="Godot.Gradient"/>.</para>
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

    private static readonly System.Type CachedType = typeof(GradientTexture1D);

    private static readonly StringName NativeName = "GradientTexture1D";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly unsafe delegate* unmanaged<godot_bool, IntPtr> NativeCtor = ClassDB_get_constructor(NativeName);

    public GradientTexture1D() : this(true)
    {
        unsafe
        {
            ConstructAndInitialize(NativeCtor, NativeName, CachedType, refCounted: true);
        }
    }

    internal GradientTexture1D(IntPtr ptr) : this(true)
    {
        NativePtr = ptr;
        unsafe
        {
            ConstructAndInitialize(null, NativeName, CachedType, refCounted: true);
        }
    }

    internal GradientTexture1D(bool memoryOwn) : base(memoryOwn) { }

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
    private static readonly IntPtr MethodBind3 = ClassDB_get_method_with_compatibility(NativeName, MethodName.SetUseHdr, 2586408642ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetUseHdr(bool enabled)
    {
        NativeCalls.godot_icall_1_14(MethodBind3, GodotObject.GetPtr(this), enabled.ToGodotBool());
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly IntPtr MethodBind4 = ClassDB_get_method_with_compatibility(NativeName, MethodName.IsUsingHdr, 36873697ul);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsUsingHdr()
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
        /// Cached name for the 'use_hdr' property.
        /// </summary>
        public static readonly StringName UseHdr = "use_hdr";
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
        /// Cached name for the 'set_use_hdr' method.
        /// </summary>
        public static readonly StringName SetUseHdr = "set_use_hdr";
        /// <summary>
        /// Cached name for the 'is_using_hdr' method.
        /// </summary>
        public static readonly StringName IsUsingHdr = "is_using_hdr";
    }

    /// <summary>
    /// Cached StringNames for the signals contained in this class, for fast lookup.
    /// </summary>
    public new class SignalName : Texture2D.SignalName
    {
    }
}
